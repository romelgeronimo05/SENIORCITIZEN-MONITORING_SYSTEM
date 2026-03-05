Imports MySql.Data.MySqlClient

Public Class Form5
    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Test database connection
        If Not DatabaseHelper.TestConnection() Then
            MessageBox.Show("Cannot connect to database. Please make sure XAMPP MySQL is running.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Setup DataGridView
        SetupDataGridView()
        ' Load registered citizens data from database
        LoadRegisteredCitizens()
        ' Update statistics
        UpdateStatistics()
    End Sub

    Private Sub SetupDataGridView()
        ' Clear existing columns
        DataGridView1.Columns.Clear()

        ' Add data columns
        DataGridView1.Columns.Add("IDNumber", "ID NUMBER")
        DataGridView1.Columns.Add("FullName", "FULL NAME")
        DataGridView1.Columns.Add("Gender", "GENDER")
        DataGridView1.Columns.Add("Birthday", "BIRTHDAY")
        DataGridView1.Columns.Add("CurrentAge", "CURRENT AGE")
        DataGridView1.Columns.Add("Address", "ADDRESS")
        DataGridView1.Columns.Add("RelativeName", "RELATIVE NAME")
        DataGridView1.Columns.Add("RelativeContact", "RELATIVE CONTACT")

        ' Add EDIT button column
        Dim btnEdit As New DataGridViewButtonColumn()
        btnEdit.HeaderText = "EDIT"
        btnEdit.Text = "✏️ Edit"
        btnEdit.Name = "btnEdit"
        btnEdit.UseColumnTextForButtonValue = True
        btnEdit.Width = 80
        DataGridView1.Columns.Add(btnEdit)

        ' Add DELETE button column
        Dim btnDelete As New DataGridViewButtonColumn()
        btnDelete.HeaderText = "DELETE"
        btnDelete.Text = "🗑️ Delete"
        btnDelete.Name = "btnDelete"
        btnDelete.UseColumnTextForButtonValue = True
        btnDelete.Width = 80
        DataGridView1.Columns.Add(btnDelete)

        ' Format settings
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView1.MultiSelect = False
        DataGridView1.ReadOnly = True
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.AllowUserToDeleteRows = False
    End Sub

    Private Sub LoadRegisteredCitizens()
        ' Clear existing rows
        DataGridView1.Rows.Clear()

        ' Load all registered citizens from database
        Dim citizens As List(Of SeniorCitizen) = DatabaseHelper.GetAllSeniorCitizens()

        For Each sc As SeniorCitizen In citizens
            ' Display data directly (NO DECRYPTION)
            DataGridView1.Rows.Add(
                sc.IDNumber,
                sc.FullName,
                sc.Gender,
                sc.Birthday.ToString("MM/dd/yyyy"),
                sc.CurrentAge,
                sc.Address,                    ' Plain text address
                sc.RelativeName,
                sc.RelativeContactNumber       ' Plain text contact
            )
        Next

        ' Update status
        Label3.Text = "Registered Senior Citizens (Total: " & citizens.Count & ")"

        ' Update statistics
        UpdateStatistics()
    End Sub

    Private Sub SearchCitizens(searchText As String)
        ' Clear existing rows
        DataGridView1.Rows.Clear()

        ' Search in database by Name or ID
        Dim citizens As List(Of SeniorCitizen) = DatabaseHelper.SearchSeniorCitizens(searchText)

        For Each sc As SeniorCitizen In citizens
            ' Display data directly (NO DECRYPTION)
            DataGridView1.Rows.Add(
                sc.IDNumber,
                sc.FullName,
                sc.Gender,
                sc.Birthday.ToString("MM/dd/yyyy"),
                sc.CurrentAge,
                sc.Address,                    ' Plain text address
                sc.RelativeName,
                sc.RelativeContactNumber       ' Plain text contact
            )
        Next

        ' Update status with search results
        Dim totalCount As Integer = DatabaseHelper.GetTotalCount()
        Label3.Text = "🔍 Search Results (Found: " & citizens.Count & " of " & totalCount & ")"
    End Sub

    Private Sub UpdateStatistics()
        ' Get all citizens for statistics
        Dim allCitizens As List(Of SeniorCitizen) = DatabaseHelper.GetAllSeniorCitizens()

        ' Calculate statistics
        Dim totalCount As Integer = allCitizens.Count
        Dim maleCount As Integer = allCitizens.Where(Function(c) c.Gender.ToLower() = "male").Count()
        Dim femaleCount As Integer = allCitizens.Where(Function(c) c.Gender.ToLower() = "female").Count()

        ' Count registered this month
        Dim thisMonthCount As Integer = 0
        Try
            Using conn = DatabaseHelper.GetConnection()
                conn.Open()
                Dim query As String = "SELECT COUNT(*) FROM senior_citizens WHERE MONTH(registered_date) = MONTH(CURRENT_DATE()) AND YEAR(registered_date) = YEAR(CURRENT_DATE())"
                Using cmd As New MySqlCommand(query, conn)
                    thisMonthCount = Convert.ToInt32(cmd.ExecuteScalar())
                End Using
            End Using
        Catch ex As Exception
            ' If registered_date column doesn't exist, thisMonthCount stays 0
        End Try

        ' Update statistics cards
        Label6.Text = totalCount.ToString()  ' Total Seniors
        Label8.Text = maleCount.ToString()   ' Male
        Label10.Text = femaleCount.ToString() ' Female
        Label12.Text = thisMonthCount.ToString() ' New This Month
    End Sub

    ' Search textbox event
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        ' Real-time search as user types (by Name or ID)
        If String.IsNullOrWhiteSpace(TextBox1.Text) Then
            LoadRegisteredCitizens()
        Else
            SearchCitizens(TextBox1.Text.Trim())
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Refresh button - reload the data from database
        TextBox1.Clear()
        LoadRegisteredCitizens()
        MessageBox.Show("✅ Data refreshed successfully from database!", "Refresh", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Clear search button
        TextBox1.Clear()
        LoadRegisteredCitizens()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ' Logout button - return to HOME (Form1)
        Dim result = MessageBox.Show(
            "Are you sure you want to log out?" & vbCrLf & vbCrLf &
            "You will be returned to the HOME screen.",
            "Confirm Logout",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            ' Set DialogResult to signal logout to Form3
            DialogResult = DialogResult.OK
            Close() ' This closes Form5 and returns to Form3
        End If
    End Sub

    ' Security: Migrate passwords to hashed format
    Private Sub MigratePasswords_Click(sender As Object, e As EventArgs)
        ' Call the migration function
        DatabaseHelper.MigratePasswordsToHashed()
    End Sub

    ' Handle Edit and Delete button clicks in DataGridView
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        ' Make sure it's not the header row
        If e.RowIndex < 0 Then Return

        ' Get the ID number from the row
        Dim idNumber As String = DataGridView1.Rows(e.RowIndex).Cells("IDNumber").Value.ToString()
        Dim fullName As String = DataGridView1.Rows(e.RowIndex).Cells("FullName").Value.ToString()

        ' Check which button was clicked
        If e.ColumnIndex = DataGridView1.Columns("btnEdit").Index Then
            ' EDIT button clicked
            EditCitizen(idNumber, fullName)
        ElseIf e.ColumnIndex = DataGridView1.Columns("btnDelete").Index Then
            ' DELETE button clicked
            DeleteCitizen(idNumber, fullName)
        End If
    End Sub

    Private Sub EditCitizen(idNumber As String, fullName As String)
        ' Get the full record from database
        Dim citizen As SeniorCitizen = Nothing
        Try
            Using conn = DatabaseHelper.GetConnection()
                conn.Open()
                Dim query As String = "SELECT * FROM senior_citizens WHERE id_number = @idNumber"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@idNumber", idNumber)
                    Using reader = cmd.ExecuteReader()
                        If reader.Read() Then
                            citizen = New SeniorCitizen(
                                reader("id_number").ToString(),
                                reader("full_name").ToString(),
                                reader("gender").ToString(),
                                Convert.ToDateTime(reader("birthday")),
                                reader("address").ToString(),
                                reader("relative_name").ToString(),
                                reader("relative_contact").ToString()
                            )
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"❌ Error loading record: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try

        If citizen Is Nothing Then
            MessageBox.Show("❌ Record not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Create edit form dynamically
        Dim editForm As New Form()
        editForm.Text = "Edit Senior Citizen"
        editForm.Size = New Size(600, 550)
        editForm.StartPosition = FormStartPosition.CenterParent
        editForm.FormBorderStyle = FormBorderStyle.FixedDialog
        editForm.MaximizeBox = False
        editForm.MinimizeBox = False
        editForm.BackColor = Color.White

        ' Title Label
        Dim lblTitle As New Label()
        lblTitle.Text = "EDIT SENIOR CITIZEN INFORMATION"
        lblTitle.Font = New Font("Arial", 12, FontStyle.Bold)
        lblTitle.Location = New Point(20, 20)
        lblTitle.Size = New Size(550, 25)
        lblTitle.ForeColor = Color.FromArgb(66, 133, 244)
        editForm.Controls.Add(lblTitle)

        ' ID Number (Read-only)
        Dim lblID As New Label With {.Text = "ID Number:", .Location = New Point(20, 60), .Size = New Size(150, 20), .Font = New Font("Arial", 9)}
        Dim txtID As New TextBox With {.Text = citizen.IDNumber, .Location = New Point(20, 85), .Size = New Size(250, 25), .ReadOnly = True, .BackColor = Color.LightGray}
        editForm.Controls.AddRange({lblID, txtID})

        ' Full Name
        Dim lblName As New Label With {.Text = "Full Name:", .Location = New Point(290, 60), .Size = New Size(150, 20), .Font = New Font("Arial", 9)}
        Dim txtName As New TextBox With {.Text = citizen.FullName, .Location = New Point(290, 85), .Size = New Size(270, 25)}
        editForm.Controls.AddRange({lblName, txtName})

        ' Gender
        Dim lblGender As New Label With {.Text = "Gender:", .Location = New Point(20, 125), .Size = New Size(150, 20), .Font = New Font("Arial", 9)}
        Dim cmbGender As New ComboBox With {.Location = New Point(20, 150), .Size = New Size(250, 25), .DropDownStyle = ComboBoxStyle.DropDownList}
        cmbGender.Items.AddRange(New Object() {"Male", "Female"})
        cmbGender.SelectedItem = citizen.Gender
        editForm.Controls.AddRange({lblGender, cmbGender})

        ' Birthday
        Dim lblBirthday As New Label With {.Text = "Birthday:", .Location = New Point(290, 125), .Size = New Size(150, 20), .Font = New Font("Arial", 9)}
        Dim dtpBirthday As New DateTimePicker With {.Location = New Point(290, 150), .Size = New Size(270, 25), .Format = DateTimePickerFormat.Short, .Value = citizen.Birthday}
        editForm.Controls.AddRange({lblBirthday, dtpBirthday})

        ' Address
        Dim lblAddress As New Label With {.Text = "Address:", .Location = New Point(20, 190), .Size = New Size(150, 20), .Font = New Font("Arial", 9)}
        Dim txtAddress As New TextBox With {.Text = citizen.Address, .Location = New Point(20, 215), .Size = New Size(540, 60), .Multiline = True, .ScrollBars = ScrollBars.Vertical}
        editForm.Controls.AddRange({lblAddress, txtAddress})

        ' Relative Name
        Dim lblRelative As New Label With {.Text = "Relative Name:", .Location = New Point(20, 290), .Size = New Size(150, 20), .Font = New Font("Arial", 9)}
        Dim txtRelative As New TextBox With {.Text = citizen.RelativeName, .Location = New Point(20, 315), .Size = New Size(540, 25)}
        editForm.Controls.AddRange({lblRelative, txtRelative})

        ' Relative Contact
        Dim lblContact As New Label With {.Text = "Relative Contact Number:", .Location = New Point(20, 355), .Size = New Size(200, 20), .Font = New Font("Arial", 9)}
        Dim mskContact As New MaskedTextBox With {.Text = citizen.RelativeContactNumber, .Location = New Point(20, 380), .Size = New Size(250, 25), .Mask = "0000-000-0000"}
        editForm.Controls.AddRange({lblContact, mskContact})

        ' Buttons
        Dim btnSave As New Button With {
            .Text = "💾 Save Changes",
            .Location = New Point(310, 460),
            .Size = New Size(130, 35),
            .BackColor = Color.FromArgb(66, 133, 244),
            .ForeColor = Color.White,
            .FlatStyle = FlatStyle.Flat,
            .Font = New Font("Arial", 9, FontStyle.Bold)
        }
        btnSave.FlatAppearance.BorderSize = 0

        Dim btnCancel As New Button With {
            .Text = "✕ Cancel",
            .Location = New Point(450, 460),
            .Size = New Size(110, 35),
            .BackColor = Color.White,
            .ForeColor = Color.FromArgb(100, 100, 100),
            .FlatStyle = FlatStyle.Flat,
            .Font = New Font("Arial", 9, FontStyle.Bold)
        }

        editForm.Controls.AddRange({btnSave, btnCancel})

        ' Button handlers
        AddHandler btnSave.Click, Sub()
                                      ' Validate inputs
                                      If String.IsNullOrWhiteSpace(txtName.Text) Then
                                          MessageBox.Show("❌ Full Name is required!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                          Return
                                      End If

                                      If cmbGender.SelectedIndex = -1 Then
                                          MessageBox.Show("❌ Gender is required!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                          Return
                                      End If

                                      ' Check age requirement
                                      Dim age As Integer = DateTime.Now.Year - dtpBirthday.Value.Year
                                      If dtpBirthday.Value > DateTime.Now.AddYears(-age) Then
                                          age -= 1
                                      End If

                                      If age < 60 Then
                                          MessageBox.Show($"❌ Senior Citizen must be 60 years old or older!{vbCrLf}Current Age: {age}", "Age Requirement", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                          Return
                                      End If

                                      If String.IsNullOrWhiteSpace(txtAddress.Text) Then
                                          MessageBox.Show("❌ Address is required!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                          Return
                                      End If

                                      If String.IsNullOrWhiteSpace(txtRelative.Text) Then
                                          MessageBox.Show("❌ Relative Name is required!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                          Return
                                      End If

                                      If String.IsNullOrWhiteSpace(mskContact.Text) OrElse mskContact.Text.Replace("-", "").Trim().Length < 10 Then
                                          MessageBox.Show("❌ Valid Relative Contact Number is required!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                          Return
                                      End If

                                      ' Update database
                                      Try
                                          Using conn = DatabaseHelper.GetConnection()
                                              conn.Open()
                                              Dim updateQuery As String = "UPDATE senior_citizens SET full_name = @name, gender = @gender, birthday = @birthday, address = @address, relative_name = @relative, relative_contact = @contact WHERE id_number = @id"
                                              Using cmd As New MySqlCommand(updateQuery, conn)
                                                  cmd.Parameters.AddWithValue("@name", txtName.Text.Trim())
                                                  cmd.Parameters.AddWithValue("@gender", cmbGender.SelectedItem.ToString())
                                                  cmd.Parameters.AddWithValue("@birthday", dtpBirthday.Value)
                                                  cmd.Parameters.AddWithValue("@address", txtAddress.Text.Trim())
                                                  cmd.Parameters.AddWithValue("@relative", txtRelative.Text.Trim())
                                                  cmd.Parameters.AddWithValue("@contact", mskContact.Text)
                                                  cmd.Parameters.AddWithValue("@id", txtID.Text)

                                                  Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                                                  If rowsAffected > 0 Then
                                                      MessageBox.Show($"✅ Successfully updated record for {txtName.Text}!", "Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                                      editForm.DialogResult = DialogResult.OK
                                                      editForm.Close()
                                                  Else
                                                      MessageBox.Show("❌ No changes were made.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                                  End If
                                              End Using
                                          End Using
                                      Catch ex As Exception
                                          MessageBox.Show($"❌ Error updating record: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                      End Try
                                  End Sub

        AddHandler btnCancel.Click, Sub()
                                        editForm.DialogResult = DialogResult.Cancel
                                        editForm.Close()
                                    End Sub

        ' Show form and reload data if saved
        If editForm.ShowDialog() = DialogResult.OK Then
            LoadRegisteredCitizens() ' Reload the data grid
        End If
    End Sub

    Private Sub DeleteCitizen(idNumber As String, fullName As String)
        ' Confirm deletion
        Dim result = MessageBox.Show(
            $"⚠️ Are you sure you want to DELETE this record?{vbCrLf}{vbCrLf}" &
            $"ID Number: {idNumber}{vbCrLf}" &
            $"Full Name: {fullName}{vbCrLf}{vbCrLf}" &
            "This action CANNOT be undone!",
            "Confirm Delete",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning)

        If result = DialogResult.Yes Then
            Try
                Using conn = DatabaseHelper.GetConnection()
                    conn.Open()
                    Dim query As String = "DELETE FROM senior_citizens WHERE id_number = @idNumber"
                    Using cmd As New MySql.Data.MySqlClient.MySqlCommand(query, conn)
                        cmd.Parameters.AddWithValue("@idNumber", idNumber)
                        Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                        If rowsAffected > 0 Then
                            MessageBox.Show($"✅ Successfully deleted record for {fullName}!", "Delete Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            ' Reload the list
                            LoadRegisteredCitizens()
                        Else
                            MessageBox.Show("❌ Record not found or already deleted.", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show($"❌ Error deleting record: {ex.Message}", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    ' ========================
    ' WINDOW CONTROL BUTTONS
    ' ========================
    ' TODO: Add 3 buttons in Designer (top-right of Panel1):
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
    '     If MessageBox.Show("Close Admin Dashboard?", "Confirm", MessageBoxButtons.YesNo) = DialogResult.Yes Then
    '         Me.Close()
    '     End If
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