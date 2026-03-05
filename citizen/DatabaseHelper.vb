Imports MySql.Data.MySqlClient

Public Class DatabaseHelper
    ' Connection string - Update if needed
    Private Shared connectionString As String = "Server=localhost;Database=senior_citizen_db;Uid=root;Pwd=;"

    ' Get database connection
    Public Shared Function GetConnection() As MySqlConnection
        Return New MySqlConnection(connectionString)
    End Function

    ' Test database connection
    Public Shared Function TestConnection() As Boolean
        Try
            Using conn As MySqlConnection = GetConnection()
                conn.Open()
                Return True
            End Using
        Catch ex As Exception
            MessageBox.Show("Database Connection Error: " & ex.Message & vbCrLf & vbCrLf & "Please make sure XAMPP MySQL is running!", "Connection Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    ' User Login Authentication - SECURE WITH HASHING (CASE-SENSITIVE)
    Public Shared Function ValidateUser(username As String, password As String, ByRef userType As String) As Boolean
        Try
            Using conn As MySqlConnection = GetConnection()
                conn.Open()
                ' Get hashed password from database with BINARY comparison for case-sensitive username
                Dim query As String = "SELECT password, user_type FROM users WHERE BINARY username = @username"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@username", username)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Dim storedPassword As String = reader("password").ToString()
                            userType = reader("user_type").ToString()

                            ' Check if password is hashed (64 chars) or plain text
                            If storedPassword.Length = 64 Then
                                ' Hashed password - use secure verification (case-sensitive)
                                If SecurityHelper.VerifyPassword(password, storedPassword) Then
                                    Return True
                                End If
                            Else
                                ' Plain text password - CASE-SENSITIVE direct comparison
                                If password = storedPassword Then
                                    MessageBox.Show("⚠️ Your password is stored as plain text!" & vbCrLf &
                                                  "For security, please contact admin to migrate to hashed passwords.",
                                                  "Security Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    Return True
                                End If
                            End If
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Login Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return False
    End Function

    ' Register Senior Citizen
    Public Shared Function RegisterSeniorCitizen(citizen As SeniorCitizen) As Boolean
        Try
            Using conn As MySqlConnection = GetConnection()
                conn.Open()
                Dim query As String = "INSERT INTO senior_citizens (id_number, full_name, gender, birthday, current_age, address, relative_name, relative_contact) " &
                                    "VALUES (@id_number, @full_name, @gender, @birthday, @current_age, @address, @relative_name, @relative_contact)"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@id_number", citizen.IDNumber)
                    cmd.Parameters.AddWithValue("@full_name", citizen.FullName)
                    cmd.Parameters.AddWithValue("@gender", citizen.Gender)
                    cmd.Parameters.AddWithValue("@birthday", citizen.Birthday)
                    cmd.Parameters.AddWithValue("@current_age", citizen.CurrentAge)
                    cmd.Parameters.AddWithValue("@address", citizen.Address)
                    cmd.Parameters.AddWithValue("@relative_name", citizen.RelativeName)
                    cmd.Parameters.AddWithValue("@relative_contact", citizen.RelativeContactNumber)

                    cmd.ExecuteNonQuery()
                    Return True
                End Using
            End Using
        Catch ex As MySqlException
            If ex.Number = 1062 Then ' Duplicate entry
                MessageBox.Show("ID Number already exists in database!", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                MessageBox.Show("Database Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return False
    End Function

    ' Get All Senior Citizens
    Public Shared Function GetAllSeniorCitizens() As List(Of SeniorCitizen)
        Dim citizens As New List(Of SeniorCitizen)
        Try
            Using conn As MySqlConnection = GetConnection()
                conn.Open()
                Dim query As String = "SELECT * FROM senior_citizens ORDER BY registered_date DESC"

                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim citizen As New SeniorCitizen With {
                                .IDNumber = reader("id_number").ToString(),
                                .FullName = reader("full_name").ToString(),
                                .Gender = reader("gender").ToString(),
                                .Birthday = Convert.ToDateTime(reader("birthday")),
                                .CurrentAge = Convert.ToInt32(reader("current_age")),
                                .Address = reader("address").ToString(),
                                .RelativeName = reader("relative_name").ToString(),
                                .RelativeContactNumber = reader("relative_contact").ToString()
                            }
                            citizens.Add(citizen)
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return citizens
    End Function

    ' Search Senior Citizens
    Public Shared Function SearchSeniorCitizens(searchText As String) As List(Of SeniorCitizen)
        Dim citizens As New List(Of SeniorCitizen)
        Try
            Using conn As MySqlConnection = GetConnection()
                conn.Open()
                Dim query As String = "SELECT * FROM senior_citizens WHERE " &
                                    "id_number LIKE @search OR " &
                                    "full_name LIKE @search OR " &
                                    "gender LIKE @search OR " &
                                    "address LIKE @search OR " &
                                    "relative_name LIKE @search OR " &
                                    "relative_contact LIKE @search " &
                                    "ORDER BY registered_date DESC"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@search", "%" & searchText & "%")

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim citizen As New SeniorCitizen With {
                                .IDNumber = reader("id_number").ToString(),
                                .FullName = reader("full_name").ToString(),
                                .Gender = reader("gender").ToString(),
                                .Birthday = Convert.ToDateTime(reader("birthday")),
                                .CurrentAge = Convert.ToInt32(reader("current_age")),
                                .Address = reader("address").ToString(),
                                .RelativeName = reader("relative_name").ToString(),
                                .RelativeContactNumber = reader("relative_contact").ToString()
                            }
                            citizens.Add(citizen)
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Search Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return citizens
    End Function

    ' Get Total Count
    Public Shared Function GetTotalCount() As Integer
        Try
            Using conn As MySqlConnection = GetConnection()
                conn.Open()
                Dim query As String = "SELECT COUNT(*) FROM senior_citizens"
                Using cmd As New MySqlCommand(query, conn)
                    Return Convert.ToInt32(cmd.ExecuteScalar())
                End Using
            End Using
        Catch ex As Exception
            Return 0
        End Try
    End Function

    ' ========================
    ' USER MANAGEMENT WITH SECURITY
    ' ========================

    ''' <summary>
    ''' Create new user with hashed password and validation
    ''' </summary>
    Public Shared Function CreateUser(username As String, password As String, userType As String) As Boolean
        Try
            ' Validate username
            Dim usernameMessage As String = ""
            If Not SecurityHelper.ValidateUsername(username, usernameMessage) Then
                MessageBox.Show(usernameMessage, "Invalid Username", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If

            ' Validate password strength
            Dim passwordMessage As String = ""
            If Not SecurityHelper.ValidatePasswordStrength(password, passwordMessage) Then
                MessageBox.Show(passwordMessage, "Weak Password", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If

            ' Hash the password
            Dim hashedPassword As String = SecurityHelper.HashPassword(password)

            Using conn As MySqlConnection = GetConnection()
                conn.Open()
                Dim query As String = "INSERT INTO users (username, password, user_type) VALUES (@username, @password, @userType)"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@username", username)
                    cmd.Parameters.AddWithValue("@password", hashedPassword)
                    cmd.Parameters.AddWithValue("@userType", userType)
                    cmd.ExecuteNonQuery()
                    Return True
                End Using
            End Using
        Catch ex As MySqlException
            If ex.Number = 1062 Then ' Duplicate username
                MessageBox.Show("❌ Username already exists! Please choose a different username.", "Duplicate Username", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                MessageBox.Show("Error creating user: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return False
    End Function

    ''' <summary>
    ''' Change user password (requires old password verification)
    ''' </summary>
    Public Shared Function ChangePassword(username As String, oldPassword As String, newPassword As String) As Boolean
        Try
            ' Validate new password strength
            Dim message As String = ""
            If Not SecurityHelper.ValidatePasswordStrength(newPassword, message) Then
                MessageBox.Show(message, "Weak Password", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If

            Using conn As MySqlConnection = GetConnection()
                conn.Open()

                ' Verify old password
                Dim selectQuery As String = "SELECT password FROM users WHERE username = @username"
                Using selectCmd As New MySqlCommand(selectQuery, conn)
                    selectCmd.Parameters.AddWithValue("@username", username)
                    Dim storedHash As Object = selectCmd.ExecuteScalar()

                    If storedHash Is Nothing Then
                        MessageBox.Show("User not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return False
                    End If

                    If Not SecurityHelper.VerifyPassword(oldPassword, storedHash.ToString()) Then
                        MessageBox.Show("❌ Current password is incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return False
                    End If
                End Using

                ' Update with new hashed password
                Dim newHash As String = SecurityHelper.HashPassword(newPassword)
                Dim updateQuery As String = "UPDATE users SET password = @password WHERE username = @username"
                Using updateCmd As New MySqlCommand(updateQuery, conn)
                    updateCmd.Parameters.AddWithValue("@password", newHash)
                    updateCmd.Parameters.AddWithValue("@username", username)
                    updateCmd.ExecuteNonQuery()
                    MessageBox.Show("✅ Password changed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return True
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error changing password: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return False
    End Function

    ''' <summary>
    ''' Migrate existing plain-text passwords to hashed passwords (ONE-TIME USE ONLY)
    ''' </summary>
    Public Shared Sub MigratePasswordsToHashed()
        Try
            Dim result = MessageBox.Show("⚠️ This will convert all existing plain-text passwords to secure hashed passwords." & vbCrLf & vbCrLf &
                                       "This should only be done ONCE!" & vbCrLf & vbCrLf &
                                       "Do you want to continue?",
                                       "Password Migration", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If result <> DialogResult.Yes Then Return

            Using conn As MySqlConnection = GetConnection()
                conn.Open()

                ' Get all users with plain text passwords (not 64 chars)
                Dim selectQuery As String = "SELECT id, username, password FROM users"
                Dim usersToUpdate As New List(Of Tuple(Of Integer, String, String))

                Using selectCmd As New MySqlCommand(selectQuery, conn)
                    Using reader As MySqlDataReader = selectCmd.ExecuteReader()
                        While reader.Read()
                            Dim id As Integer = Convert.ToInt32(reader("id"))
                            Dim username As String = reader("username").ToString()
                            Dim plainPassword As String = reader("password").ToString()

                            ' Only migrate if not already hashed (hash is 64 chars)
                            If plainPassword.Length <> 64 Then
                                usersToUpdate.Add(New Tuple(Of Integer, String, String)(id, username, plainPassword))
                            End If
                        End While
                    End Using
                End Using

                If usersToUpdate.Count = 0 Then
                    MessageBox.Show("✅ All passwords are already securely hashed!", "Migration Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If

                ' Hash and update each password
                For Each user In usersToUpdate
                    Dim hashedPassword As String = SecurityHelper.HashPassword(user.Item3)
                    Dim updateQuery As String = "UPDATE users SET password = @password WHERE id = @id"
                    Using updateCmd As New MySqlCommand(updateQuery, conn)
                        updateCmd.Parameters.AddWithValue("@password", hashedPassword)
                        updateCmd.Parameters.AddWithValue("@id", user.Item1)
                        updateCmd.ExecuteNonQuery()
                    End Using
                Next

                MessageBox.Show($"✅ Successfully migrated {usersToUpdate.Count} user passwords to secure hashed format!" & vbCrLf & vbCrLf &
                              "🔒 Algorithm: PBKDF2 with SHA-256" & vbCrLf &
                              "🔄 Iterations: 10,000" & vbCrLf &
                              "🔐 Hash Length: 256-bit" & vbCrLf & vbCrLf &
                              "All users can now login with their original passwords, but they are now securely stored.",
                              "Migration Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        Catch ex As Exception
            MessageBox.Show("Migration Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
