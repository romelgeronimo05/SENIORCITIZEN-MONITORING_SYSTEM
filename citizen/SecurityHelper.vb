Imports System.Security.Cryptography
Imports System.Text

''' <summary>
''' Security Helper Class - Provides password hashing, AES encryption, and account security
''' </summary>
Public Class SecurityHelper

    ' ========================
    ' PASSWORD HASHING (PBKDF2 - BCrypt Alternative)
    ' ========================
    Private Const SaltSize As Integer = 16
    Private Const HashSize As Integer = 32
    Private Const Iterations As Integer = 10000

    ''' <summary>
    ''' Hash a password using PBKDF2 with SHA256 (similar to BCrypt)
    ''' </summary>
    Public Shared Function HashPassword(password As String) As String
        ' Generate random salt
        Dim salt(SaltSize - 1) As Byte
        Using rng As New RNGCryptoServiceProvider()
            rng.GetBytes(salt)
        End Using

        ' Hash password with salt
        Using pbkdf2 As New Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256)
            Dim hash As Byte() = pbkdf2.GetBytes(HashSize)

            ' Combine salt + hash
            Dim hashBytes(SaltSize + HashSize - 1) As Byte
            Array.Copy(salt, 0, hashBytes, 0, SaltSize)
            Array.Copy(hash, 0, hashBytes, SaltSize, HashSize)

            ' Return as Base64
            Return Convert.ToBase64String(hashBytes)
        End Using
    End Function

    ''' <summary>
    ''' Verify password against stored hash
    ''' </summary>
    Public Shared Function VerifyPassword(password As String, hashedPassword As String) As Boolean
        Try
            ' Decode hash
            Dim hashBytes As Byte() = Convert.FromBase64String(hashedPassword)

            ' Extract salt
            Dim salt(SaltSize - 1) As Byte
            Array.Copy(hashBytes, 0, salt, 0, SaltSize)

            ' Hash the input password with extracted salt
            Using pbkdf2 As New Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256)
                Dim hash As Byte() = pbkdf2.GetBytes(HashSize)

                ' Compare hashes
                For i As Integer = 0 To HashSize - 1
                    If hashBytes(i + SaltSize) <> hash(i) Then
                        Return False
                    End If
                Next
            End Using

            Return True
        Catch
            Return False
        End Try
    End Function

    ' ========================
    ' AES ENCRYPTION/DECRYPTION (256-bit)
    ' ========================
    ' ⚠️ IMPORTANT: Change these keys in production!
    Private Shared ReadOnly AESKey As Byte() = Encoding.UTF8.GetBytes("SeniorCitizen2026KeyForEncryption") ' 32 bytes = AES-256
    Private Shared ReadOnly AESIV As Byte() = Encoding.UTF8.GetBytes("InitializationV1") ' 16 bytes

    ''' <summary>
    ''' Encrypt data using AES-256
    ''' </summary>
    Public Shared Function EncryptAES(plainText As String) As String
        If String.IsNullOrEmpty(plainText) Then Return String.Empty

        Try
            Using aes As Aes = Aes.Create()
                aes.Key = AESKey
                aes.IV = AESIV
                aes.Mode = CipherMode.CBC
                aes.Padding = PaddingMode.PKCS7

                Using encryptor As ICryptoTransform = aes.CreateEncryptor(aes.Key, aes.IV)
                    Using ms As New IO.MemoryStream()
                        Using cs As New CryptoStream(ms, encryptor, CryptoStreamMode.Write)
                            Using sw As New IO.StreamWriter(cs)
                                sw.Write(plainText)
                            End Using
                            Return Convert.ToBase64String(ms.ToArray())
                        End Using
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Encryption Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return String.Empty
        End Try
    End Function

    ''' <summary>
    ''' Decrypt AES-256 encrypted data
    ''' </summary>
    Public Shared Function DecryptAES(cipherText As String) As String
        If String.IsNullOrEmpty(cipherText) Then Return String.Empty

        Try
            Using aes As Aes = Aes.Create()
                aes.Key = AESKey
                aes.IV = AESIV
                aes.Mode = CipherMode.CBC
                aes.Padding = PaddingMode.PKCS7

                Using decryptor As ICryptoTransform = aes.CreateDecryptor(aes.Key, aes.IV)
                    Using ms As New IO.MemoryStream(Convert.FromBase64String(cipherText))
                        Using cs As New CryptoStream(ms, decryptor, CryptoStreamMode.Read)
                            Using sr As New IO.StreamReader(cs)
                                Return sr.ReadToEnd()
                            End Using
                        End Using
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Decryption Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return String.Empty
        End Try
    End Function

    ' ========================
    ' PASSWORD STRENGTH VALIDATION
    ' ========================

    ''' <summary>
    ''' Validate password strength requirements
    ''' </summary>
    Public Shared Function ValidatePasswordStrength(password As String, ByRef message As String) As Boolean
        If String.IsNullOrEmpty(password) Then
            message = "Password cannot be empty"
            Return False
        End If

        If password.Length < 8 Then
            message = "Password must be at least 8 characters long"
            Return False
        End If

        Dim hasUpper As Boolean = password.Any(Function(c) Char.IsUpper(c))
        Dim hasLower As Boolean = password.Any(Function(c) Char.IsLower(c))
        Dim hasDigit As Boolean = password.Any(Function(c) Char.IsDigit(c))
        Dim hasSpecial As Boolean = password.Any(Function(c) "!@#$%^&*()_+-=[]{}|;:',.<>?/".Contains(c))

        If Not hasUpper Then
            message = "Password must contain at least one uppercase letter (A-Z)"
            Return False
        End If

        If Not hasLower Then
            message = "Password must contain at least one lowercase letter (a-z)"
            Return False
        End If

        If Not hasDigit Then
            message = "Password must contain at least one number (0-9)"
            Return False
        End If

        If Not hasSpecial Then
            message = "Password must contain at least one special character (!@#$%^&*)"
            Return False
        End If

        message = "Password is strong ✓"
        Return True
    End Function

    ''' <summary>
    ''' Get password strength level (Weak, Medium, Strong, Very Strong)
    ''' </summary>
    Public Shared Function GetPasswordStrength(password As String) As String
        If String.IsNullOrEmpty(password) Then Return "None"

        Dim score As Integer = 0

        ' Length scoring
        If password.Length >= 8 Then score += 1
        If password.Length >= 12 Then score += 1
        If password.Length >= 16 Then score += 1

        ' Character variety scoring
        If password.Any(Function(c) Char.IsUpper(c)) Then score += 1
        If password.Any(Function(c) Char.IsLower(c)) Then score += 1
        If password.Any(Function(c) Char.IsDigit(c)) Then score += 1
        If password.Any(Function(c) "!@#$%^&*()_+-=[]{}|;:',.<>?/".Contains(c)) Then score += 1

        Select Case score
            Case 0 To 2
                Return "Weak"
            Case 3 To 4
                Return "Medium"
            Case 5 To 6
                Return "Strong"
            Case Else
                Return "Very Strong"
        End Select
    End Function

    ' ========================
    ' USERNAME VALIDATION
    ' ========================

    ''' <summary>
    ''' Validate username format
    ''' </summary>
    Public Shared Function ValidateUsername(username As String, ByRef message As String) As Boolean
        If String.IsNullOrWhiteSpace(username) Then
            message = "Username cannot be empty"
            Return False
        End If

        If username.Length < 4 Then
            message = "Username must be at least 4 characters long"
            Return False
        End If

        If username.Length > 20 Then
            message = "Username cannot exceed 20 characters"
            Return False
        End If

        ' Only alphanumeric and underscore allowed
        If Not username.All(Function(c) Char.IsLetterOrDigit(c) OrElse c = "_"c) Then
            message = "Username can only contain letters, numbers, and underscores"
            Return False
        End If

        message = "Username is valid ✓"
        Return True
    End Function

    ' ========================
    ' ACCOUNT LOCKOUT SYSTEM
    ' ========================
    Private Shared LoginAttempts As New Dictionary(Of String, Integer)
    Private Shared LockoutTime As New Dictionary(Of String, DateTime)
    Private Const MaxLoginAttempts As Integer = 5
    Private Const LockoutMinutes As Integer = 15

    ''' <summary>
    ''' Check if account is currently locked
    ''' </summary>
    Public Shared Function IsAccountLocked(username As String) As Boolean
        If LockoutTime.ContainsKey(username) Then
            If DateTime.Now < LockoutTime(username) Then
                Return True ' Still locked
            Else
                ' Lockout expired - reset
                LockoutTime.Remove(username)
                LoginAttempts.Remove(username)
                Return False
            End If
        End If
        Return False
    End Function

    ''' <summary>
    ''' Record a failed login attempt
    ''' </summary>
    Public Shared Sub RecordFailedLogin(username As String)
        If Not LoginAttempts.ContainsKey(username) Then
            LoginAttempts(username) = 0
        End If

        LoginAttempts(username) += 1

        If LoginAttempts(username) >= MaxLoginAttempts Then
            LockoutTime(username) = DateTime.Now.AddMinutes(LockoutMinutes)
        End If
    End Sub

    ''' <summary>
    ''' Reset login attempts after successful login
    ''' </summary>
    Public Shared Sub ResetLoginAttempts(username As String)
        If LoginAttempts.ContainsKey(username) Then
            LoginAttempts.Remove(username)
        End If
        If LockoutTime.ContainsKey(username) Then
            LockoutTime.Remove(username)
        End If
    End Sub

    ''' <summary>
    ''' Get remaining lockout time in minutes
    ''' </summary>
    Public Shared Function GetRemainingLockoutTime(username As String) As Integer
        If LockoutTime.ContainsKey(username) Then
            Dim remaining As TimeSpan = LockoutTime(username) - DateTime.Now
            If remaining.TotalMinutes > 0 Then
                Return CInt(Math.Ceiling(remaining.TotalMinutes))
            End If
        End If
        Return 0
    End Function

    ''' <summary>
    ''' Get remaining login attempts before lockout
    ''' </summary>
    Public Shared Function GetRemainingAttempts(username As String) As Integer
        If LoginAttempts.ContainsKey(username) Then
            Return Math.Max(0, MaxLoginAttempts - LoginAttempts(username))
        End If
        Return MaxLoginAttempts
    End Function
End Class
