Public Class Form3
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set password field to show asterisks by default (TextBox3 = Password)
        TextBox3.PasswordChar = "*"
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ' Back to Home button - Close Form3 to return to HOME
        Me.Close()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ' Admin login validation with database (Button5 = LOGIN button)
        If TextBox4.Text = "" Or TextBox3.Text = "" Then
            MessageBox.Show("Please enter Admin Username and Password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Dim userType As String = ""
            If DatabaseHelper.ValidateUser(TextBox4.Text, TextBox3.Text, userType) Then
                If userType = "admin" Then
                    ' Open Form5 (Admin dashboard)
                    MessageBox.Show("Admin Login Successful! Welcome " & TextBox4.Text, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Hide()
                    Dim form5 As New Form5()
                    Dim loginResult = form5.ShowDialog()

                    ' Check if user logged out (DialogResult.OK means logout)
                    If loginResult = DialogResult.OK Then
                        MessageBox.Show("✅ Logged out successfully!", "Logout", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.Close() ' Close Form3 to return to Form1
                    Else
                        ' User just closed Form5 without logout - show Form3 again
                        Me.Show()
                        TextBox4.Clear()
                        TextBox3.Clear()
                    End If
                Else
                    MessageBox.Show("Invalid admin credentials. Please use Admin login.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Invalid Username or Password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        ' Toggle password visibility for Admin login
        If CheckBox2.Checked Then
            TextBox3.PasswordChar = ""
        Else
            TextBox3.PasswordChar = "*"
        End If
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged

    End Sub

    ' ========================
    ' WINDOW CONTROL BUTTONS
    ' ========================
    ' TODO: Add 3 buttons in Designer (top-right):
    ' btnMinimize (Text: ─), btnMaximize (Text: ⬜), btnWindowClose (Text: ✕)
    ' Then uncomment these methods:

    ' Private Sub btnMinimize_Click(sender As Object, e As EventArgs) Handles btnMinimize.Click
    '     Me.WindowState = FormWindowState.Minimized
    ' End Sub

    ' Private Sub btnMaximize_Click(sender As Object, e As EventArgs) Handles btnMaximize.Click
    '     If Me.WindowState = FormWindowState.Maximized Then
    '         Me.WindowState = FormWindowState.Normal
    '         btnMaximize.Text = "⬜"
    '     Else
    '         Me.WindowState = FormWindowState.Maximized
    '         btnMaximize.Text = "❐"
    '     End If
    ' End Sub

    ' Private Sub btnWindowClose_Click(sender As Object, e As EventArgs) Handles btnWindowClose.Click
    '     Me.Close()
    ' End Sub

    ' Private Sub btnMinimize_MouseEnter(sender As Object, e As EventArgs) Handles btnMinimize.MouseEnter
    '     btnMinimize.BackColor = Color.FromArgb(224, 224, 224)
    ' End Sub

    ' Private Sub btnMinimize_MouseLeave(sender As Object, e As EventArgs) Handles btnMinimize.MouseLeave
    '     btnMinimize.BackColor = Color.Transparent
    ' End Sub

    ' Private Sub btnMaximize_MouseEnter(sender As Object, e As EventArgs) Handles btnMaximize.MouseEnter
    '     btnMaximize.BackColor = Color.FromArgb(224, 224, 224)
    ' End Sub

    ' Private Sub btnMaximize_MouseLeave(sender As Object, e As EventArgs) Handles btnMaximize.MouseLeave
    '     btnMaximize.BackColor = Color.Transparent
    ' End Sub

    ' Private Sub btnWindowClose_MouseEnter(sender As Object, e As EventArgs) Handles btnWindowClose.MouseEnter
    '     btnWindowClose.BackColor = Color.FromArgb(244, 67, 54)
    '     btnWindowClose.ForeColor = Color.White
    ' End Sub

    ' Private Sub btnWindowClose_MouseLeave(sender As Object, e As EventArgs) Handles btnWindowClose.MouseLeave
    '     btnWindowClose.BackColor = Color.Transparent
    '     btnWindowClose.ForeColor = Color.FromArgb(100, 100, 100)
    ' End Sub
End Class
