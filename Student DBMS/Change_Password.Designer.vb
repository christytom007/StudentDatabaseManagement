<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Change_Password
    Inherits MetroFramework.Forms.MetroForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Change_Password))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.MetroLabel1 = New MetroFramework.Controls.MetroLabel()
        Me.MetroLabel2 = New MetroFramework.Controls.MetroLabel()
        Me.MetroLabel3 = New MetroFramework.Controls.MetroLabel()
        Me.TextBox1 = New MetroFramework.Controls.MetroTextBox()
        Me.TextBox2 = New MetroFramework.Controls.MetroTextBox()
        Me.TextBox3 = New MetroFramework.Controls.MetroTextBox()
        Me.Button1 = New MetroFramework.Controls.MetroButton()
        Me.Button2 = New MetroFramework.Controls.MetroButton()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox1.Location = New System.Drawing.Point(23, 63)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(212, 210)
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'MetroLabel1
        '
        Me.MetroLabel1.AutoSize = True
        Me.MetroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular
        Me.MetroLabel1.Location = New System.Drawing.Point(265, 79)
        Me.MetroLabel1.Name = "MetroLabel1"
        Me.MetroLabel1.Size = New System.Drawing.Size(118, 19)
        Me.MetroLabel1.Style = MetroFramework.MetroColorStyle.Green
        Me.MetroLabel1.TabIndex = 5
        Me.MetroLabel1.Text = "Current Password"
        '
        'MetroLabel2
        '
        Me.MetroLabel2.AutoSize = True
        Me.MetroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular
        Me.MetroLabel2.Location = New System.Drawing.Point(265, 146)
        Me.MetroLabel2.Name = "MetroLabel2"
        Me.MetroLabel2.Size = New System.Drawing.Size(98, 19)
        Me.MetroLabel2.Style = MetroFramework.MetroColorStyle.Green
        Me.MetroLabel2.TabIndex = 5
        Me.MetroLabel2.Text = "New Password"
        '
        'MetroLabel3
        '
        Me.MetroLabel3.AutoSize = True
        Me.MetroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular
        Me.MetroLabel3.Location = New System.Drawing.Point(265, 209)
        Me.MetroLabel3.Name = "MetroLabel3"
        Me.MetroLabel3.Size = New System.Drawing.Size(120, 19)
        Me.MetroLabel3.Style = MetroFramework.MetroColorStyle.Green
        Me.MetroLabel3.TabIndex = 5
        Me.MetroLabel3.Text = "Re-Type Password"
        '
        'TextBox1
        '
        '
        '
        '
        Me.TextBox1.CustomButton.Image = Nothing
        Me.TextBox1.CustomButton.Location = New System.Drawing.Point(301, 2)
        Me.TextBox1.CustomButton.Name = ""
        Me.TextBox1.CustomButton.Size = New System.Drawing.Size(17, 17)
        Me.TextBox1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.TextBox1.CustomButton.TabIndex = 1
        Me.TextBox1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.TextBox1.CustomButton.UseSelectable = True
        Me.TextBox1.CustomButton.Visible = False
        Me.TextBox1.FontWeight = MetroFramework.MetroTextBoxWeight.Bold
        Me.TextBox1.Lines = New String() {" "}
        Me.TextBox1.Location = New System.Drawing.Point(265, 101)
        Me.TextBox1.MaxLength = 32767
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.TextBox1.SelectedText = ""
        Me.TextBox1.SelectionLength = 0
        Me.TextBox1.SelectionStart = 0
        Me.TextBox1.Size = New System.Drawing.Size(321, 22)
        Me.TextBox1.Style = MetroFramework.MetroColorStyle.Green
        Me.TextBox1.TabIndex = 6
        Me.TextBox1.Text = " "
        Me.TextBox1.UseSelectable = True
        Me.TextBox1.UseSystemPasswordChar = True
        Me.TextBox1.WaterMark = "Enter Your Current Password"
        Me.TextBox1.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.TextBox1.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'TextBox2
        '
        '
        '
        '
        Me.TextBox2.CustomButton.Image = Nothing
        Me.TextBox2.CustomButton.Location = New System.Drawing.Point(301, 2)
        Me.TextBox2.CustomButton.Name = ""
        Me.TextBox2.CustomButton.Size = New System.Drawing.Size(17, 17)
        Me.TextBox2.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.TextBox2.CustomButton.TabIndex = 1
        Me.TextBox2.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.TextBox2.CustomButton.UseSelectable = True
        Me.TextBox2.CustomButton.Visible = False
        Me.TextBox2.FontWeight = MetroFramework.MetroTextBoxWeight.Bold
        Me.TextBox2.Lines = New String() {" "}
        Me.TextBox2.Location = New System.Drawing.Point(265, 168)
        Me.TextBox2.MaxLength = 32767
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.TextBox2.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.TextBox2.SelectedText = ""
        Me.TextBox2.SelectionLength = 0
        Me.TextBox2.SelectionStart = 0
        Me.TextBox2.Size = New System.Drawing.Size(321, 22)
        Me.TextBox2.Style = MetroFramework.MetroColorStyle.Green
        Me.TextBox2.TabIndex = 6
        Me.TextBox2.Text = " "
        Me.TextBox2.UseSelectable = True
        Me.TextBox2.UseSystemPasswordChar = True
        Me.TextBox2.WaterMark = "Enter New Password"
        Me.TextBox2.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.TextBox2.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'TextBox3
        '
        '
        '
        '
        Me.TextBox3.CustomButton.Image = Nothing
        Me.TextBox3.CustomButton.Location = New System.Drawing.Point(301, 2)
        Me.TextBox3.CustomButton.Name = ""
        Me.TextBox3.CustomButton.Size = New System.Drawing.Size(17, 17)
        Me.TextBox3.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.TextBox3.CustomButton.TabIndex = 1
        Me.TextBox3.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.TextBox3.CustomButton.UseSelectable = True
        Me.TextBox3.CustomButton.Visible = False
        Me.TextBox3.FontWeight = MetroFramework.MetroTextBoxWeight.Bold
        Me.TextBox3.Lines = New String() {" "}
        Me.TextBox3.Location = New System.Drawing.Point(265, 231)
        Me.TextBox3.MaxLength = 32767
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.TextBox3.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.TextBox3.SelectedText = ""
        Me.TextBox3.SelectionLength = 0
        Me.TextBox3.SelectionStart = 0
        Me.TextBox3.Size = New System.Drawing.Size(321, 22)
        Me.TextBox3.Style = MetroFramework.MetroColorStyle.Green
        Me.TextBox3.TabIndex = 6
        Me.TextBox3.Text = " "
        Me.TextBox3.UseSelectable = True
        Me.TextBox3.UseSystemPasswordChar = True
        Me.TextBox3.WaterMark = "Re-Type The New Password"
        Me.TextBox3.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.TextBox3.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(153, 298)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(148, 46)
        Me.Button1.Style = MetroFramework.MetroColorStyle.Green
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "Change"
        Me.Button1.UseSelectable = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(336, 298)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(148, 46)
        Me.Button2.Style = MetroFramework.MetroColorStyle.Green
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "Cancel"
        Me.Button2.UseSelectable = True
        '
        'Change_Password
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(637, 405)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.MetroLabel3)
        Me.Controls.Add(Me.MetroLabel2)
        Me.Controls.Add(Me.MetroLabel1)
        Me.Controls.Add(Me.PictureBox1)
        Me.ForeColor = System.Drawing.Color.Red
        Me.Movable = False
        Me.Name = "Change_Password"
        Me.Resizable = False
        Me.Style = MetroFramework.MetroColorStyle.Green
        Me.Text = "Change Password"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents MetroLabel1 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroLabel2 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroLabel3 As MetroFramework.Controls.MetroLabel
    Friend WithEvents TextBox1 As MetroFramework.Controls.MetroTextBox
    Friend WithEvents TextBox2 As MetroFramework.Controls.MetroTextBox
    Friend WithEvents TextBox3 As MetroFramework.Controls.MetroTextBox
    Friend WithEvents Button1 As MetroFramework.Controls.MetroButton
    Friend WithEvents Button2 As MetroFramework.Controls.MetroButton
End Class
