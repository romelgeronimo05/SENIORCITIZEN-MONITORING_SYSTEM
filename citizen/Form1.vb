Imports MySql.Data.MySqlClient

Public Class HOME
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Enable double buffering for smooth rendering
        Me.DoubleBuffered = True



        ' Center Panel1 on load
        CenterPanel()
    End Sub

    ' Center Panel1 when form resizes
    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        CenterPanel()
    End Sub

    Private Sub CenterPanel()
        If Panel1 IsNot Nothing Then
            ' Center Panel1 in the form
            Panel1.Left = (Me.ClientSize.Width - Panel1.Width) \ 2
            Panel1.Top = (Me.ClientSize.Height - Panel1.Height) \ 2
        End If
    End Sub

    ''' <summary>
    ''' Setup strong default passwords that meet security requirements
    ''' Run this ONCE to replace weak default passwords
    ''' </summary>
    Private Sub SetupSecurePasswords()
        Try
            ' Check if default weak passwords exist
            Using conn As MySqlConnection = DatabaseHelper.GetConnection()
                conn.Open()
                Dim query As String = "SELECT COUNT(*) FROM users WHERE password IN ('user123', 'admin123')"
                Using cmd As New MySql.Data.MySqlClient.MySqlCommand(query, conn)
                    Dim weakPasswordCount As Integer = Convert.ToInt32(cmd.ExecuteScalar())

                    If weakPasswordCount > 0 Then
                        ' Weak passwords detected - offer to update
                        Dim result = MessageBox.Show(
                            "⚠️ SECURITY WARNING" & vbCrLf & vbCrLf &
                            "Default passwords detected that don't meet security requirements:" & vbCrLf & vbCrLf &
                            "Would you like to update to secure passwords now?",
                            "Security Warning",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning)

                        If result = DialogResult.Yes Then
                            ' Delete old users
                            Dim deleteQuery As String = "DELETE FROM users WHERE username IN ('admin', 'user')"
                            Using deleteCmd As New MySql.Data.MySqlClient.MySqlCommand(deleteQuery, conn)
                                deleteCmd.ExecuteNonQuery()
                            End Using

                            ' Insert new strong passwords
                            Dim insertQuery As String = "INSERT INTO users (username, password, user_type) VALUES " &
                                                       "('admin', 'Admin@2026', 'admin'), " &
                                                       "('user', 'User@2026', 'user')"
                            Using insertCmd As New MySql.Data.MySqlClient.MySqlCommand(insertQuery, conn)
                                insertCmd.ExecuteNonQuery()
                            End Using

                            MessageBox.Show(
                                "✅ Passwords updated successfully!" & vbCrLf & vbCrLf &
                                "NEW LOGIN CREDENTIALS:" & vbCrLf &
                                "━━━━━━━━━━━━━━━━━━━━━━" & vbCrLf &
                                "👤 USER:" & vbCrLf &
                                "   Username: user" & vbCrLf &
                                "   Password: User@2026" & vbCrLf & vbCrLf &
                                "👨‍💼 ADMIN:" & vbCrLf &
                                "   Username: admin" & vbCrLf &
                                "   Password: Admin@2026" & vbCrLf & vbCrLf &
                                "Now running password migration...",
                                "Success",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information)

                            ' Now run migration to hash the new passwords
                            DatabaseHelper.MigratePasswordsToHashed()
                        End If
                    Else
                        ' No weak passwords found - just run migration
                        DatabaseHelper.MigratePasswordsToHashed()
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error setting up passwords: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ' Still try to run migration
            DatabaseHelper.MigratePasswordsToHashed()
        End Try
    End Sub

    ' Override OnPaintBackground to draw background image with 50% transparency
    Protected Overrides Sub OnPaintBackground(e As PaintEventArgs)
        MyBase.OnPaintBackground(e)

        ' If BackgroundImage is set, draw it with 50% transparency
        If Me.BackgroundImage IsNot Nothing Then
            ' Create a semi-transparent color matrix (50% opacity = 0.5 alpha)
            Dim colorMatrix As New System.Drawing.Imaging.ColorMatrix()
            colorMatrix.Matrix33 = 0.5F ' Set alpha to 50%

            ' Create image attributes with the color matrix
            Dim imageAttributes As New System.Drawing.Imaging.ImageAttributes()
            imageAttributes.SetColorMatrix(colorMatrix)

            ' Draw the background image with transparency
            e.Graphics.DrawImage(Me.BackgroundImage,
                                New Rectangle(0, 0, Me.ClientSize.Width, Me.ClientSize.Height),
                                0, 0, Me.BackgroundImage.Width, Me.BackgroundImage.Height,
                                GraphicsUnit.Pixel, imageAttributes)
        End If
    End Sub

    ' Close button click
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        If MessageBox.Show("Are you sure you want to exit?", "Exit Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

    ' Close button hover effects
    Private Sub btnClose_MouseEnter(sender As Object, e As EventArgs) Handles btnClose.MouseEnter
        btnClose.BackColor = Color.FromArgb(244, 67, 54) ' Red
        btnClose.ForeColor = Color.White
    End Sub

    Private Sub btnClose_MouseLeave(sender As Object, e As EventArgs) Handles btnClose.MouseLeave
        btnClose.BackColor = Color.Transparent
        btnClose.ForeColor = Color.FromArgb(100, 100, 100)
    End Sub

    ' Maximize button click
    Private Sub btnMaximize_Click(sender As Object, e As EventArgs) Handles btnMaximize.Click
        If Me.WindowState = FormWindowState.Maximized Then
            ' Restore to normal size
            Me.WindowState = FormWindowState.Normal
            btnMaximize.Text = "⬜" ' Square icon for maximize
        Else
            ' Maximize the form
            Me.WindowState = FormWindowState.Maximized
            btnMaximize.Text = "❐" ' Overlapping squares icon for restore
        End If
    End Sub

    ' Maximize button hover effects
    Private Sub btnMaximize_MouseEnter(sender As Object, e As EventArgs) Handles btnMaximize.MouseEnter
        btnMaximize.BackColor = Color.FromArgb(224, 224, 224) ' Light gray
    End Sub

    Private Sub btnMaximize_MouseLeave(sender As Object, e As EventArgs) Handles btnMaximize.MouseLeave
        btnMaximize.BackColor = Color.Transparent
    End Sub

    ' Minimize button click (Button3)
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    ' Minimize button hover effects
    Private Sub Button3_MouseEnter(sender As Object, e As EventArgs) Handles Button3.MouseEnter
        Button3.BackColor = Color.FromArgb(224, 224, 224) ' Light gray
    End Sub

    Private Sub Button3_MouseLeave(sender As Object, e As EventArgs) Handles Button3.MouseLeave
        Button3.BackColor = Color.Transparent
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Dim form2 As New Form2()
        form2.ShowDialog()
        Me.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Dim form3 As New Form3()
        form3.ShowDialog()
        Me.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)
        ' 🔒 Click this button ONCE to secure your 2 passwords
        HashTwoPasswords()
    End Sub

    ' ============================================
    ' 🔒 HASH THE 2 PASSWORDS (Run ONCE)
    ' ============================================
    Private Sub HashTwoPasswords()
        Try
            Using conn As MySqlConnection = DatabaseHelper.GetConnection()
                conn.Open()

                ' Check if already hashed
                Dim checkQuery As String = "SELECT password FROM users WHERE username = 'admin'"
                Using checkCmd As New MySqlCommand(checkQuery, conn)
                    Dim currentPass As String = checkCmd.ExecuteScalar()?.ToString()
                    If currentPass?.Length = 64 Then
                        MessageBox.Show("✅ Passwords are already secured!", "Already Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return
                    End If
                End Using

                ' Hash admin password: Admin@2026
                Dim adminHash As String = SecurityHelper.HashPassword("Admin@2026")
                Dim updateAdmin As String = "UPDATE users SET password = @pass WHERE username = 'admin'"
                Using cmdAdmin As New MySqlCommand(updateAdmin, conn)
                    cmdAdmin.Parameters.AddWithValue("@pass", adminHash)
                    cmdAdmin.ExecuteNonQuery()
                End Using

                ' Hash user password: User@2026
                Dim userHash As String = SecurityHelper.HashPassword("User@2026")
                Dim updateUser As String = "UPDATE users SET password = @pass WHERE username = 'user'"
                Using cmdUser As New MySqlCommand(updateUser, conn)
                    cmdUser.Parameters.AddWithValue("@pass", userHash)
                    cmdUser.ExecuteNonQuery()
                End Using

                MessageBox.Show(
                    "✅ PASSWORDS SECURED!" & vbCrLf & vbCrLf &
                    "Both passwords hashed with PBKDF2-SHA256" & vbCrLf & vbCrLf &
                    "Login still works the same:" & vbCrLf &
                    "• admin / Admin@2026" & vbCrLf &
                    "• user / User@2026",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information)
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
