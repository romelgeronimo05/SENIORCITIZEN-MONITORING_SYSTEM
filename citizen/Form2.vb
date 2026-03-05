Public Class Form2
    ' ========================
    ' FORM DRAG SUPPORT
    ' ========================
    Private isDragging As Boolean = False
    Private dragStartPoint As Point

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set password field to show asterisks by default
        TextBox2.PasswordChar = "*"

        ' Enable form dragging
        Me.KeyPreview = True
    End Sub

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        If e.Button = MouseButtons.Left Then
            isDragging = True
            dragStartPoint = New Point(e.X, e.Y)
        End If
    End Sub

    Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
        MyBase.OnMouseMove(e)
        If isDragging Then
            Dim p As Point = PointToScreen(e.Location)
            Me.Location = New Point(p.X - dragStartPoint.X, p.Y - dragStartPoint.Y)
        End If
    End Sub

    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        isDragging = False
    End Sub

    ' Keyboard shortcuts for window control
    Protected Overrides Sub OnKeyDown(e As KeyEventArgs)
        MyBase.OnKeyDown(e)

        ' Alt+F4 to close
        If e.Alt AndAlso e.KeyCode = Keys.F4 Then
            Me.Close()
        End If

        ' Alt+Enter to maximize/restore
        If e.Alt AndAlso e.KeyCode = Keys.Enter Then
            If Me.WindowState = FormWindowState.Maximized Then
                Me.WindowState = FormWindowState.Normal
            Else
                Me.WindowState = FormWindowState.Maximized
            End If
        End If

        ' Escape to minimize
        If e.KeyCode = Keys.Escape AndAlso e.Control Then
            Me.WindowState = FormWindowState.Minimized
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        ' Clear textboxes
        TextBox1.Clear()
        TextBox2.Clear()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Login validation with database
        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MessageBox.Show("Please enter Username and Password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Dim userType As String = ""
            If DatabaseHelper.ValidateUser(TextBox1.Text, TextBox2.Text, userType) Then
                If userType = "user" Then
                    ' Open Form4 (User dashboard)
                    MessageBox.Show("Login Successful! Welcome " & TextBox1.Text, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Hide()
                    Dim form4 As New Form4()
                    form4.ShowDialog()
                    Me.Show()
                    TextBox1.Clear()
                    TextBox2.Clear()
                Else
                    MessageBox.Show("Invalid user type. Please use User login.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Invalid Username or Password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ' Close Form2 to return to HOME
        Me.Close()
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        ' Toggle password visibility for User login
        If CheckBox2.Checked Then
            TextBox2.PasswordChar = ""
        Else
            TextBox2.PasswordChar = "*"
        End If
    End Sub

End Class