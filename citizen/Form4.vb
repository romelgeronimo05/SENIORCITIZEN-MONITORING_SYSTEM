Public Class Form4
    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' ComboBox items are already initialized in Designer
        ' Set default placeholder
        ComboBox1.SelectedIndex = -1
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Clear all fields
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        MaskedTextBox1.Clear()
        ComboBox1.SelectedIndex = -1
        DateTimePicker1.Value = DateTime.Now
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Register validation - ALL FIELDS REQUIRED

        ' Check ID Number
        If String.IsNullOrWhiteSpace(TextBox1.Text) Then
            MessageBox.Show("❌ ID Number is required!", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TextBox1.Focus()
            Return
        End If

        ' Check Full Name
        If String.IsNullOrWhiteSpace(TextBox2.Text) Then
            MessageBox.Show("❌ Full Name is required!", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TextBox2.Focus()
            Return
        End If

        ' Check Gender
        If ComboBox1.SelectedIndex = -1 Then
            MessageBox.Show("❌ Gender is required!", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ComboBox1.Focus()
            Return
        End If

        ' Check Birthday (must be a valid senior citizen - 60+ years old)
        Dim age As Integer = DateTime.Now.Year - DateTimePicker1.Value.Year
        If DateTimePicker1.Value > DateTime.Now.AddYears(-age) Then
            age -= 1
        End If

        If age < 60 Then
            MessageBox.Show("❌ Senior Citizen must be 60 years old or older!" & vbCrLf & "Current Age: " & age, "Age Requirement", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            DateTimePicker1.Focus()
            Return
        End If

        ' Check Address
        If String.IsNullOrWhiteSpace(TextBox4.Text) Then
            MessageBox.Show("❌ Address is required!", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TextBox4.Focus()
            Return
        End If

        ' Check Relative Name
        If String.IsNullOrWhiteSpace(TextBox3.Text) Then
            MessageBox.Show("❌ Relative Name is required!", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TextBox3.Focus()
            Return
        End If

        ' Check Relative Contact Number
        If String.IsNullOrWhiteSpace(MaskedTextBox1.Text) OrElse MaskedTextBox1.Text.Replace("-", "").Trim().Length < 10 Then
            MessageBox.Show("❌ Relative Contact Number is required!" & vbCrLf & "Please enter a valid phone number (e.g., 0912-345-6789)", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MaskedTextBox1.Focus()
            Return
        End If

        ' ✅ ALL VALIDATIONS PASSED - Show summary for confirmation

        ' Calculate age for display
        Dim displayAge As Integer = DateTime.Now.Year - DateTimePicker1.Value.Year
        If DateTimePicker1.Value > DateTime.Now.AddYears(-displayAge) Then
            displayAge -= 1
        End If

        ' Show summary confirmation dialog
        Dim summaryMessage As String = "📋 SUMMARY OF PERSONAL INFORMATION" & vbCrLf &
                                      "═══════════════════════════════════" & vbCrLf & vbCrLf &
                                      "🆔 ID Number: " & TextBox1.Text & vbCrLf &
                                      "👤 Full Name: " & TextBox2.Text & vbCrLf &
                                      "⚧ Gender: " & ComboBox1.SelectedItem.ToString() & vbCrLf &
                                      "🎂 Birthday: " & DateTimePicker1.Value.ToString("MMMM dd, yyyy") & vbCrLf &
                                      "📅 Age: " & displayAge & " years old" & vbCrLf &
                                      "🏠 Address: " & TextBox4.Text & vbCrLf &
                                      "👥 Relative Name: " & TextBox3.Text & vbCrLf &
                                      "📞 Relative Contact: " & MaskedTextBox1.Text & vbCrLf & vbCrLf &
                                      "═══════════════════════════════════" & vbCrLf &
                                      "Do you want to proceed with registration?"

        Dim confirmResult = MessageBox.Show(summaryMessage,
                                           "Confirm Registration",
                                           MessageBoxButtons.YesNo,
                                           MessageBoxIcon.Question)

        If confirmResult = DialogResult.No Then
            ' User cancelled registration
            MessageBox.Show("⚠️ Registration cancelled. You can review and edit the information.",
                          "Registration Cancelled",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Information)
            Return
        End If

        ' User confirmed - Proceed with registration
        ' Create new senior citizen record (NO ENCRYPTION)
        Dim newCitizen As New SeniorCitizen(
            TextBox1.Text,                    ' ID Number
            TextBox2.Text,                    ' Full Name
            ComboBox1.SelectedItem.ToString(), ' Gender
            DateTimePicker1.Value,            ' Birthday
            TextBox4.Text,                    ' Address (PLAIN TEXT)
            TextBox3.Text,                    ' Relative Name
            MaskedTextBox1.Text               ' Relative Contact Number (PLAIN TEXT)
        )

        ' Save to database
        If DatabaseHelper.RegisterSeniorCitizen(newCitizen) Then
            Dim totalCount As Integer = DatabaseHelper.GetTotalCount()
            MessageBox.Show("✅ Senior Citizen Registered Successfully!" & vbCrLf &
                          "👤 " & TextBox2.Text & vbCrLf &
                          "🆔 " & TextBox1.Text & vbCrLf &
                          "📊 Total Registered: " & totalCount,
                          "Registration Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ' Clear fields after successful registration
            Button1_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ' Log out - close Form4 to return to previous form
        Me.Close()
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

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