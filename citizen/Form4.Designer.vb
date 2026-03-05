<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form4
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form4))
        Label2 = New Label()
        Label1 = New Label()
        PictureBox1 = New PictureBox()
        Label5 = New Label()
        Panel1 = New Panel()
        Button4 = New Button()
        DateTimePicker1 = New DateTimePicker()
        ComboBox1 = New ComboBox()
        MaskedTextBox1 = New MaskedTextBox()
        Label3 = New Label()
        Label4 = New Label()
        Label6 = New Label()
        Label7 = New Label()
        Label8 = New Label()
        Label9 = New Label()
        Label10 = New Label()
        Label11 = New Label()
        TextBox1 = New TextBox()
        TextBox2 = New TextBox()
        TextBox3 = New TextBox()
        TextBox4 = New TextBox()
        Button2 = New Button()
        Button1 = New Button()
        Panel2 = New Panel()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Arial", 10F)
        Label2.ForeColor = Color.Black
        Label2.Location = New Point(79, 40)
        Label2.Name = "Label2"
        Label2.Size = New Size(156, 16)
        Label2.TabIndex = 7
        Label2.Text = "District III, Cauayan City"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Arial", 14F, FontStyle.Bold)
        Label1.ForeColor = Color.Black
        Label1.Location = New Point(79, 17)
        Label1.Name = "Label1"
        Label1.Size = New Size(248, 22)
        Label1.TabIndex = 6
        Label1.Text = "SENIOR CITIZEN SYSTEM"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(11, 11)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(62, 59)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 8
        PictureBox1.TabStop = False
        ' 
        ' Label5
        ' 
        Label5.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Label5.AutoSize = True
        Label5.Font = New Font("Arial", 10F)
        Label5.ForeColor = Color.Black
        Label5.Location = New Point(1050, 35)
        Label5.Name = "Label5"
        Label5.Size = New Size(119, 16)
        Label5.TabIndex = 10
        Label5.Text = "WELCOME USER"
        ' 
        ' Panel1
        ' 
        Panel1.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Panel1.BackColor = Color.White
        Panel1.Controls.Add(Button4)
        Panel1.Controls.Add(Label5)
        Panel1.Controls.Add(PictureBox1)
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(Label1)
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1280, 88)
        Panel1.TabIndex = 11
        ' 
        ' Button4
        ' 
        Button4.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Button4.BackColor = Color.Navy
        Button4.FlatStyle = FlatStyle.Flat
        Button4.Font = New Font("Arial", 9F, FontStyle.Bold)
        Button4.ForeColor = SystemColors.ButtonHighlight
        Button4.Location = New Point(1185, 29)
        Button4.Name = "Button4"
        Button4.Size = New Size(82, 29)
        Button4.TabIndex = 30
        Button4.Text = "LOG OUT"
        Button4.UseVisualStyleBackColor = False
        ' 
        ' DateTimePicker1
        ' 
        DateTimePicker1.Font = New Font("Segoe UI", 10F)
        DateTimePicker1.Format = DateTimePickerFormat.Short
        DateTimePicker1.Location = New Point(40, 305)
        DateTimePicker1.Name = "DateTimePicker1"
        DateTimePicker1.Size = New Size(370, 25)
        DateTimePicker1.TabIndex = 12
        ' 
        ' ComboBox1
        ' 
        ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBox1.Font = New Font("Segoe UI", 10F)
        ComboBox1.FormattingEnabled = True
        ComboBox1.Items.AddRange(New Object() {"Male", "Female"})
        ComboBox1.Location = New Point(40, 238)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(370, 25)
        ComboBox1.TabIndex = 13
        ' 
        ' MaskedTextBox1
        ' 
        MaskedTextBox1.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        MaskedTextBox1.BorderStyle = BorderStyle.FixedSingle
        MaskedTextBox1.Font = New Font("Segoe UI", 10F)
        MaskedTextBox1.Location = New Point(490, 305)
        MaskedTextBox1.Mask = "0000-000-0000"
        MaskedTextBox1.Name = "MaskedTextBox1"
        MaskedTextBox1.Size = New Size(550, 25)
        MaskedTextBox1.TabIndex = 14
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Arial", 14F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = Color.FromArgb(CByte(50), CByte(50), CByte(50))
        Label3.Location = New Point(40, 30)
        Label3.Name = "Label3"
        Label3.Size = New Size(253, 22)
        Label3.TabIndex = 15
        Label3.Text = "PERSONAL INFORMATION"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Arial", 10F)
        Label4.ForeColor = Color.FromArgb(CByte(70), CByte(70), CByte(70))
        Label4.Location = New Point(40, 80)
        Label4.Name = "Label4"
        Label4.Size = New Size(77, 16)
        Label4.TabIndex = 16
        Label4.Text = "ID Number:"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Arial", 10F)
        Label6.ForeColor = Color.FromArgb(CByte(70), CByte(70), CByte(70))
        Label6.Location = New Point(40, 147)
        Label6.Name = "Label6"
        Label6.Size = New Size(74, 16)
        Label6.TabIndex = 17
        Label6.Text = "Full Name:"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Arial", 10F)
        Label7.ForeColor = Color.FromArgb(CByte(70), CByte(70), CByte(70))
        Label7.Location = New Point(40, 213)
        Label7.Name = "Label7"
        Label7.Size = New Size(59, 16)
        Label7.TabIndex = 18
        Label7.Text = "Gender:"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Arial", 10F)
        Label8.ForeColor = Color.FromArgb(CByte(70), CByte(70), CByte(70))
        Label8.Location = New Point(40, 280)
        Label8.Name = "Label8"
        Label8.Size = New Size(63, 16)
        Label8.TabIndex = 19
        Label8.Text = "Birthday:"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label9.ForeColor = Color.FromArgb(CByte(70), CByte(70), CByte(70))
        Label9.Location = New Point(490, 80)
        Label9.Name = "Label9"
        Label9.Size = New Size(63, 16)
        Label9.TabIndex = 20
        Label9.Text = "Address:"
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Font = New Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label10.ForeColor = Color.FromArgb(CByte(70), CByte(70), CByte(70))
        Label10.Location = New Point(490, 213)
        Label10.Name = "Label10"
        Label10.Size = New Size(102, 16)
        Label10.TabIndex = 21
        Label10.Text = "Relative Name:"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label11.ForeColor = Color.FromArgb(CByte(70), CByte(70), CByte(70))
        Label11.Location = New Point(490, 280)
        Label11.Name = "Label11"
        Label11.Size = New Size(168, 16)
        Label11.TabIndex = 22
        Label11.Text = "Relative Contact Number:"
        ' 
        ' TextBox1
        ' 
        TextBox1.BorderStyle = BorderStyle.FixedSingle
        TextBox1.Font = New Font("Segoe UI", 10F)
        TextBox1.Location = New Point(40, 100)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(370, 25)
        TextBox1.TabIndex = 23
        ' 
        ' TextBox2
        ' 
        TextBox2.BorderStyle = BorderStyle.FixedSingle
        TextBox2.Font = New Font("Segoe UI", 10F)
        TextBox2.Location = New Point(40, 167)
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(370, 25)
        TextBox2.TabIndex = 24
        ' 
        ' TextBox3
        ' 
        TextBox3.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        TextBox3.BorderStyle = BorderStyle.FixedSingle
        TextBox3.Font = New Font("Segoe UI", 10F)
        TextBox3.Location = New Point(490, 238)
        TextBox3.Name = "TextBox3"
        TextBox3.Size = New Size(550, 25)
        TextBox3.TabIndex = 25
        ' 
        ' TextBox4
        ' 
        TextBox4.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        TextBox4.BorderStyle = BorderStyle.FixedSingle
        TextBox4.Font = New Font("Segoe UI", 10F)
        TextBox4.Location = New Point(490, 99)
        TextBox4.Multiline = True
        TextBox4.Name = "TextBox4"
        TextBox4.ScrollBars = ScrollBars.Vertical
        TextBox4.Size = New Size(550, 92)
        TextBox4.TabIndex = 26
        ' 
        ' Button2
        ' 
        Button2.BackColor = Color.FromArgb(CByte(66), CByte(133), CByte(244))
        Button2.FlatStyle = FlatStyle.Flat
        Button2.Font = New Font("Arial", 10F, FontStyle.Bold)
        Button2.ForeColor = SystemColors.ButtonHighlight
        Button2.Location = New Point(572, 380)
        Button2.Name = "Button2"
        Button2.Size = New Size(137, 40)
        Button2.TabIndex = 27
        Button2.Text = "REGISTER"
        Button2.UseVisualStyleBackColor = False
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.White
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Font = New Font("Arial", 10F, FontStyle.Bold)
        Button1.ForeColor = Color.FromArgb(CByte(100), CByte(100), CByte(100))
        Button1.Location = New Point(418, 380)
        Button1.Name = "Button1"
        Button1.Size = New Size(137, 40)
        Button1.TabIndex = 28
        Button1.Text = "CLEAR"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Panel2
        ' 
        Panel2.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Panel2.BackColor = Color.White
        Panel2.Controls.Add(Button1)
        Panel2.Controls.Add(Label3)
        Panel2.Controls.Add(Button2)
        Panel2.Controls.Add(Label9)
        Panel2.Controls.Add(MaskedTextBox1)
        Panel2.Controls.Add(TextBox3)
        Panel2.Controls.Add(TextBox4)
        Panel2.Controls.Add(Label4)
        Panel2.Controls.Add(Label6)
        Panel2.Controls.Add(TextBox2)
        Panel2.Controls.Add(DateTimePicker1)
        Panel2.Controls.Add(ComboBox1)
        Panel2.Controls.Add(Label7)
        Panel2.Controls.Add(TextBox1)
        Panel2.Controls.Add(Label8)
        Panel2.Controls.Add(Label11)
        Panel2.Controls.Add(Label10)
        Panel2.Location = New Point(100, 135)
        Panel2.Name = "Panel2"
        Panel2.Padding = New Padding(20)
        Panel2.Size = New Size(1080, 465)
        Panel2.TabIndex = 29
        ' 
        ' Form4
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.DarkSlateGray
        ClientSize = New Size(1279, 634)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Name = "Form4"
        StartPosition = FormStartPosition.CenterScreen
        Text = "User Dashboard"
        WindowState = FormWindowState.Maximized
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents MaskedTextBox1 As MaskedTextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Panel2 As Panel
End Class
