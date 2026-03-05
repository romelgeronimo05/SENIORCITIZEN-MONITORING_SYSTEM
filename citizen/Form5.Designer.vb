<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form5
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form5))
        Panel1 = New Panel()
        Button4 = New Button()
        Label5 = New Label()
        Label2 = New Label()
        Label1 = New Label()
        PictureBox1 = New PictureBox()
        Panel2 = New Panel()
        Label6 = New Label()
        Label7 = New Label()
        Panel3 = New Panel()
        Label8 = New Label()
        Label9 = New Label()
        Panel4 = New Panel()
        Label10 = New Label()
        Label11 = New Label()
        Panel5 = New Panel()
        Label12 = New Label()
        Label13 = New Label()
        DataGridView1 = New DataGridView()
        TextBox1 = New TextBox()
        Button1 = New Button()
        Button2 = New Button()
        Label3 = New Label()
        Panel1.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        Panel2.SuspendLayout()
        Panel3.SuspendLayout()
        Panel4.SuspendLayout()
        Panel5.SuspendLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Panel1.BackColor = Color.White
        Panel1.Controls.Add(Button4)
        Panel1.Controls.Add(Label5)
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(PictureBox1)
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1280, 90)
        Panel1.TabIndex = 0
        ' 
        ' Button4
        ' 
        Button4.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Button4.BackColor = Color.Navy
        Button4.FlatAppearance.BorderSize = 0
        Button4.FlatStyle = FlatStyle.Flat
        Button4.Font = New Font("Arial", 9F, FontStyle.Bold)
        Button4.ForeColor = Color.White
        Button4.Location = New Point(1176, 36)
        Button4.Name = "Button4"
        Button4.Size = New Size(82, 25)
        Button4.TabIndex = 4
        Button4.Text = "Logout"
        Button4.UseVisualStyleBackColor = False
        ' 
        ' Label5
        ' 
        Label5.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Label5.AutoSize = True
        Label5.Font = New Font("Arial", 10F)
        Label5.ForeColor = Color.FromArgb(CByte(100), CByte(100), CByte(100))
        Label5.Location = New Point(1052, 39)
        Label5.Name = "Label5"
        Label5.Size = New Size(107, 16)
        Label5.TabIndex = 3
        Label5.Text = "Welcome Admin"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Arial", 10F)
        Label2.ForeColor = Color.FromArgb(CByte(100), CByte(100), CByte(100))
        Label2.Location = New Point(90, 45)
        Label2.Name = "Label2"
        Label2.Size = New Size(156, 16)
        Label2.TabIndex = 2
        Label2.Text = "District III, Cauayan City"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Arial", 14F, FontStyle.Bold)
        Label1.ForeColor = Color.FromArgb(CByte(50), CByte(50), CByte(50))
        Label1.Location = New Point(90, 20)
        Label1.Name = "Label1"
        Label1.Size = New Size(213, 22)
        Label1.TabIndex = 1
        Label1.Text = "Senior Citizen System"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(20, 15)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(60, 60)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.White
        Panel2.Controls.Add(Label6)
        Panel2.Controls.Add(Label7)
        Panel2.Location = New Point(50, 110)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(167, 71)
        Panel2.TabIndex = 1
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Arial", 15F, FontStyle.Bold)
        Label6.ForeColor = Color.FromArgb(CByte(66), CByte(133), CByte(244))
        Label6.Location = New Point(20, 34)
        Label6.Name = "Label6"
        Label6.Size = New Size(21, 24)
        Label6.TabIndex = 1
        Label6.Text = "0"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Arial", 12F, FontStyle.Bold)
        Label7.ForeColor = Color.FromArgb(CByte(80), CByte(80), CByte(80))
        Label7.Location = New Point(20, 15)
        Label7.Name = "Label7"
        Label7.Size = New Size(109, 19)
        Label7.TabIndex = 0
        Label7.Text = "Total Seniors"
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.White
        Panel3.Controls.Add(Label8)
        Panel3.Controls.Add(Label9)
        Panel3.Location = New Point(236, 110)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(167, 71)
        Panel3.TabIndex = 2
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Arial", 15F, FontStyle.Bold)
        Label8.ForeColor = Color.FromArgb(CByte(66), CByte(133), CByte(244))
        Label8.Location = New Point(20, 34)
        Label8.Name = "Label8"
        Label8.Size = New Size(21, 24)
        Label8.TabIndex = 1
        Label8.Text = "0"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Arial", 12F, FontStyle.Bold)
        Label9.ForeColor = Color.FromArgb(CByte(80), CByte(80), CByte(80))
        Label9.Location = New Point(20, 15)
        Label9.Name = "Label9"
        Label9.Size = New Size(44, 19)
        Label9.TabIndex = 0
        Label9.Text = "Male"
        ' 
        ' Panel4
        ' 
        Panel4.BackColor = Color.White
        Panel4.Controls.Add(Label10)
        Panel4.Controls.Add(Label11)
        Panel4.Location = New Point(423, 110)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(167, 71)
        Panel4.TabIndex = 3
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Font = New Font("Arial", 15F, FontStyle.Bold)
        Label10.ForeColor = Color.FromArgb(CByte(244), CByte(143), CByte(177))
        Label10.Location = New Point(20, 34)
        Label10.Name = "Label10"
        Label10.Size = New Size(21, 24)
        Label10.TabIndex = 1
        Label10.Text = "0"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("Arial", 12F, FontStyle.Bold)
        Label11.ForeColor = Color.FromArgb(CByte(80), CByte(80), CByte(80))
        Label11.Location = New Point(20, 15)
        Label11.Name = "Label11"
        Label11.Size = New Size(64, 19)
        Label11.TabIndex = 0
        Label11.Text = "Female"
        ' 
        ' Panel5
        ' 
        Panel5.BackColor = Color.White
        Panel5.Controls.Add(Label12)
        Panel5.Controls.Add(Label13)
        Panel5.Location = New Point(608, 110)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(167, 71)
        Panel5.TabIndex = 4
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Font = New Font("Arial", 15F, FontStyle.Bold)
        Label12.ForeColor = Color.FromArgb(CByte(76), CByte(175), CByte(80))
        Label12.Location = New Point(20, 34)
        Label12.Name = "Label12"
        Label12.Size = New Size(21, 24)
        Label12.TabIndex = 1
        Label12.Text = "0"
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Font = New Font("Arial", 12F, FontStyle.Bold)
        Label13.ForeColor = Color.FromArgb(CByte(80), CByte(80), CByte(80))
        Label13.Location = New Point(20, 15)
        Label13.Name = "Label13"
        Label13.Size = New Size(132, 19)
        Label13.TabIndex = 0
        Label13.Text = "New This Month"
        ' 
        ' DataGridView1
        ' 
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.AllowUserToDeleteRows = False
        DataGridView1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.BackgroundColor = Color.White
        DataGridView1.BorderStyle = BorderStyle.None
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(50, 215)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.ReadOnly = True
        DataGridView1.RowHeadersVisible = False
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView1.Size = New Size(1180, 415)
        DataGridView1.TabIndex = 5
        ' 
        ' TextBox1
        ' 
        TextBox1.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        TextBox1.BorderStyle = BorderStyle.FixedSingle
        TextBox1.Font = New Font("Arial", 10F)
        TextBox1.Location = New Point(795, 144)
        TextBox1.Multiline = True
        TextBox1.Name = "TextBox1"
        TextBox1.PlaceholderText = "🔍 Search by name or ID..."
        TextBox1.Size = New Size(251, 23)
        TextBox1.TabIndex = 6
        ' 
        ' Button1
        ' 
        Button1.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Button1.BackColor = Color.Navy
        Button1.FlatAppearance.BorderSize = 0
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Font = New Font("Arial", 9F, FontStyle.Bold)
        Button1.ForeColor = Color.White
        Button1.Location = New Point(1052, 139)
        Button1.Name = "Button1"
        Button1.Size = New Size(85, 28)
        Button1.TabIndex = 7
        Button1.Text = "🔄 Refresh"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Button2
        ' 
        Button2.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Button2.BackColor = Color.White
        Button2.FlatAppearance.BorderColor = Color.FromArgb(CByte(244), CByte(67), CByte(54))
        Button2.FlatStyle = FlatStyle.Flat
        Button2.Font = New Font("Arial", 9F, FontStyle.Bold)
        Button2.ForeColor = Color.FromArgb(CByte(244), CByte(67), CByte(54))
        Button2.Location = New Point(1150, 140)
        Button2.Name = "Button2"
        Button2.Size = New Size(80, 28)
        Button2.TabIndex = 8
        Button2.Text = "✕ Clear"
        Button2.UseVisualStyleBackColor = False
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Arial", 11F, FontStyle.Bold)
        Label3.ForeColor = Color.FromArgb(CByte(60), CByte(60), CByte(60))
        Label3.Location = New Point(46, 194)
        Label3.Name = "Label3"
        Label3.Size = New Size(200, 18)
        Label3.TabIndex = 9
        Label3.Text = "Registered Senior Citizens"
        ' 
        ' Form5
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Aquamarine
        ClientSize = New Size(1280, 650)
        Controls.Add(Label3)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Controls.Add(TextBox1)
        Controls.Add(DataGridView1)
        Controls.Add(Panel5)
        Controls.Add(Panel4)
        Controls.Add(Panel3)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Name = "Form5"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Admin Dashboard"
        WindowState = FormWindowState.Maximized
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        Panel4.ResumeLayout(False)
        Panel4.PerformLayout()
        Panel5.ResumeLayout(False)
        Panel5.PerformLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button4 As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Label3 As Label
End Class
