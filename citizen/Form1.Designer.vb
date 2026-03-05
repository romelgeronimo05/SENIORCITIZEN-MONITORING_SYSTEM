<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class HOME
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HOME))
        Panel1 = New Panel()
        Label2 = New Label()
        Label1 = New Label()
        PictureBox1 = New PictureBox()
        Button1 = New Button()
        Button2 = New Button()
        btnMaximize = New Button()
        Panel1.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.White
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(PictureBox1)
        Panel1.Controls.Add(Button1)
        Panel1.Controls.Add(Button2)
        Panel1.Location = New Point(269, 61)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(500, 514)
        Panel1.TabIndex = 0
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 11F)
        Label2.ForeColor = Color.FromArgb(CByte(100), CByte(100), CByte(100))
        Label2.Location = New Point(124, 144)
        Label2.Name = "Label2"
        Label2.Size = New Size(254, 20)
        Label2.TabIndex = 2
        Label2.Text = "District III, Cauayan City, Isabela 3305"
        Label2.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Label1
        ' 
        Label1.Font = New Font("Segoe UI", 22F, FontStyle.Bold)
        Label1.ForeColor = Color.Navy
        Label1.Location = New Point(35, 174)
        Label1.Name = "Label1"
        Label1.Size = New Size(440, 50)
        Label1.TabIndex = 1
        Label1.Text = "SENIOR CITIZEN SYSTEM"
        Label1.TextAlign = ContentAlignment.TopCenter
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(170, 22)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(135, 108)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox1.TabIndex = 3
        PictureBox1.TabStop = False
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.FromArgb(CByte(33), CByte(150), CByte(243))
        Button1.Cursor = Cursors.Hand
        Button1.FlatAppearance.BorderSize = 0
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Font = New Font("Segoe UI", 16F, FontStyle.Bold)
        Button1.ForeColor = Color.White
        Button1.Location = New Point(100, 266)
        Button1.Name = "Button1"
        Button1.Size = New Size(300, 60)
        Button1.TabIndex = 4
        Button1.Text = "👤 USER"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Button2
        ' 
        Button2.BackColor = Color.FromArgb(CByte(33), CByte(150), CByte(243))
        Button2.Cursor = Cursors.Hand
        Button2.FlatAppearance.BorderSize = 0
        Button2.FlatStyle = FlatStyle.Flat
        Button2.Font = New Font("Segoe UI", 16F, FontStyle.Bold)
        Button2.ForeColor = Color.White
        Button2.Location = New Point(100, 358)
        Button2.Name = "Button2"
        Button2.Size = New Size(300, 60)
        Button2.TabIndex = 5
        Button2.Text = "👨‍💼 ADMIN"
        Button2.UseVisualStyleBackColor = False
        ' 
        ' btnMaximize
        ' 
        btnMaximize.Location = New Point(0, 0)
        btnMaximize.Name = "btnMaximize"
        btnMaximize.Size = New Size(75, 23)
        btnMaximize.TabIndex = 0
        ' 
        ' HOME
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(25), CByte(118), CByte(210))
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        ClientSize = New Size(1001, 635)
        Controls.Add(Panel1)
        Name = "HOME"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Senior Citizen Management System"
        WindowState = FormWindowState.Maximized
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents btnMaximize As Button
    Friend WithEvents btnClose As Button

End Class
