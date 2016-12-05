<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Student_Remove
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.MetroButton6 = New MetroFramework.Controls.MetroButton()
        Me.MetroButton7 = New MetroFramework.Controls.MetroButton()
        Me.MetroButton5 = New MetroFramework.Controls.MetroButton()
        Me.MetroLabel36 = New MetroFramework.Controls.MetroLabel()
        Me.MetroLabel35 = New MetroFramework.Controls.MetroLabel()
        Me.MetroComboBox7 = New MetroFramework.Controls.MetroComboBox()
        Me.MetroLabel34 = New MetroFramework.Controls.MetroLabel()
        Me.MetroComboBox6 = New MetroFramework.Controls.MetroComboBox()
        Me.MetroLabel33 = New MetroFramework.Controls.MetroLabel()
        Me.MetroTextBox26 = New MetroFramework.Controls.MetroTextBox()
        Me.MetroLabel32 = New MetroFramework.Controls.MetroLabel()
        Me.MetroGrid1 = New MetroFramework.Controls.MetroGrid()
        CType(Me.MetroGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MetroButton6
        '
        Me.MetroButton6.Location = New System.Drawing.Point(981, 459)
        Me.MetroButton6.Name = "MetroButton6"
        Me.MetroButton6.Size = New System.Drawing.Size(197, 47)
        Me.MetroButton6.Style = MetroFramework.MetroColorStyle.Yellow
        Me.MetroButton6.TabIndex = 10
        Me.MetroButton6.Text = "Delete"
        Me.MetroButton6.UseSelectable = True
        '
        'MetroButton7
        '
        Me.MetroButton7.Location = New System.Drawing.Point(851, 270)
        Me.MetroButton7.Name = "MetroButton7"
        Me.MetroButton7.Size = New System.Drawing.Size(118, 47)
        Me.MetroButton7.Style = MetroFramework.MetroColorStyle.Yellow
        Me.MetroButton7.TabIndex = 11
        Me.MetroButton7.Text = "Clear All"
        Me.MetroButton7.UseSelectable = True
        '
        'MetroButton5
        '
        Me.MetroButton5.Location = New System.Drawing.Point(975, 270)
        Me.MetroButton5.Name = "MetroButton5"
        Me.MetroButton5.Size = New System.Drawing.Size(197, 47)
        Me.MetroButton5.Style = MetroFramework.MetroColorStyle.Yellow
        Me.MetroButton5.TabIndex = 12
        Me.MetroButton5.Text = "Search"
        Me.MetroButton5.UseSelectable = True
        '
        'MetroLabel36
        '
        Me.MetroLabel36.AutoSize = True
        Me.MetroLabel36.FontWeight = MetroFramework.MetroLabelWeight.Bold
        Me.MetroLabel36.Location = New System.Drawing.Point(1045, 365)
        Me.MetroLabel36.Name = "MetroLabel36"
        Me.MetroLabel36.Size = New System.Drawing.Size(77, 19)
        Me.MetroLabel36.Style = MetroFramework.MetroColorStyle.Yellow
        Me.MetroLabel36.TabIndex = 20
        Me.MetroLabel36.Text = "................."
        '
        'MetroLabel35
        '
        Me.MetroLabel35.AutoSize = True
        Me.MetroLabel35.FontWeight = MetroFramework.MetroLabelWeight.Bold
        Me.MetroLabel35.Location = New System.Drawing.Point(929, 365)
        Me.MetroLabel35.Name = "MetroLabel35"
        Me.MetroLabel35.Size = New System.Drawing.Size(110, 19)
        Me.MetroLabel35.Style = MetroFramework.MetroColorStyle.Yellow
        Me.MetroLabel35.TabIndex = 21
        Me.MetroLabel35.Text = "Admission No :"
        '
        'MetroComboBox7
        '
        Me.MetroComboBox7.FontWeight = MetroFramework.MetroComboBoxWeight.Bold
        Me.MetroComboBox7.FormattingEnabled = True
        Me.MetroComboBox7.ItemHeight = 23
        Me.MetroComboBox7.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8"})
        Me.MetroComboBox7.Location = New System.Drawing.Point(942, 212)
        Me.MetroComboBox7.Name = "MetroComboBox7"
        Me.MetroComboBox7.Size = New System.Drawing.Size(230, 29)
        Me.MetroComboBox7.Style = MetroFramework.MetroColorStyle.Yellow
        Me.MetroComboBox7.TabIndex = 13
        Me.MetroComboBox7.UseSelectable = True
        '
        'MetroLabel34
        '
        Me.MetroLabel34.AutoSize = True
        Me.MetroLabel34.FontWeight = MetroFramework.MetroLabelWeight.Bold
        Me.MetroLabel34.Location = New System.Drawing.Point(832, 222)
        Me.MetroLabel34.Name = "MetroLabel34"
        Me.MetroLabel34.Size = New System.Drawing.Size(71, 19)
        Me.MetroLabel34.Style = MetroFramework.MetroColorStyle.Yellow
        Me.MetroLabel34.TabIndex = 14
        Me.MetroLabel34.Text = "Semester"
        '
        'MetroComboBox6
        '
        Me.MetroComboBox6.FontWeight = MetroFramework.MetroComboBoxWeight.Bold
        Me.MetroComboBox6.FormattingEnabled = True
        Me.MetroComboBox6.ItemHeight = 23
        Me.MetroComboBox6.Items.AddRange(New Object() {"Computer Science", "Electronics and Communications", "Electrical and Electronics", "Information Technology"})
        Me.MetroComboBox6.Location = New System.Drawing.Point(942, 148)
        Me.MetroComboBox6.Name = "MetroComboBox6"
        Me.MetroComboBox6.Size = New System.Drawing.Size(230, 29)
        Me.MetroComboBox6.Style = MetroFramework.MetroColorStyle.Yellow
        Me.MetroComboBox6.TabIndex = 15
        Me.MetroComboBox6.UseSelectable = True
        '
        'MetroLabel33
        '
        Me.MetroLabel33.AutoSize = True
        Me.MetroLabel33.FontWeight = MetroFramework.MetroLabelWeight.Bold
        Me.MetroLabel33.Location = New System.Drawing.Point(832, 158)
        Me.MetroLabel33.Name = "MetroLabel33"
        Me.MetroLabel33.Size = New System.Drawing.Size(55, 19)
        Me.MetroLabel33.Style = MetroFramework.MetroColorStyle.Yellow
        Me.MetroLabel33.TabIndex = 16
        Me.MetroLabel33.Text = "Course"
        '
        'MetroTextBox26
        '
        '
        '
        '
        Me.MetroTextBox26.CustomButton.Image = Nothing
        Me.MetroTextBox26.CustomButton.Location = New System.Drawing.Point(206, 1)
        Me.MetroTextBox26.CustomButton.Name = ""
        Me.MetroTextBox26.CustomButton.Size = New System.Drawing.Size(23, 23)
        Me.MetroTextBox26.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.MetroTextBox26.CustomButton.TabIndex = 1
        Me.MetroTextBox26.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.MetroTextBox26.CustomButton.UseSelectable = True
        Me.MetroTextBox26.CustomButton.Visible = False
        Me.MetroTextBox26.Lines = New String() {" "}
        Me.MetroTextBox26.Location = New System.Drawing.Point(942, 89)
        Me.MetroTextBox26.MaxLength = 32767
        Me.MetroTextBox26.Name = "MetroTextBox26"
        Me.MetroTextBox26.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.MetroTextBox26.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.MetroTextBox26.SelectedText = ""
        Me.MetroTextBox26.SelectionLength = 0
        Me.MetroTextBox26.SelectionStart = 0
        Me.MetroTextBox26.Size = New System.Drawing.Size(230, 25)
        Me.MetroTextBox26.Style = MetroFramework.MetroColorStyle.Yellow
        Me.MetroTextBox26.TabIndex = 17
        Me.MetroTextBox26.Text = " "
        Me.MetroTextBox26.UseSelectable = True
        Me.MetroTextBox26.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.MetroTextBox26.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'MetroLabel32
        '
        Me.MetroLabel32.AutoSize = True
        Me.MetroLabel32.FontWeight = MetroFramework.MetroLabelWeight.Bold
        Me.MetroLabel32.Location = New System.Drawing.Point(832, 95)
        Me.MetroLabel32.Name = "MetroLabel32"
        Me.MetroLabel32.Size = New System.Drawing.Size(104, 19)
        Me.MetroLabel32.Style = MetroFramework.MetroColorStyle.Yellow
        Me.MetroLabel32.TabIndex = 18
        Me.MetroLabel32.Text = "Student Name"
        '
        'MetroGrid1
        '
        Me.MetroGrid1.AllowUserToAddRows = False
        Me.MetroGrid1.AllowUserToDeleteRows = False
        Me.MetroGrid1.AllowUserToResizeRows = False
        Me.MetroGrid1.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.MetroGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.MetroGrid1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.MetroGrid1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(196, Byte), Integer), CType(CType(37, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(201, Byte), Integer), CType(CType(57, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer))
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.MetroGrid1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.MetroGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(136, Byte), Integer))
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(201, Byte), Integer), CType(CType(57, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.MetroGrid1.DefaultCellStyle = DataGridViewCellStyle2
        Me.MetroGrid1.EnableHeadersVisualStyles = False
        Me.MetroGrid1.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.MetroGrid1.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.MetroGrid1.Location = New System.Drawing.Point(23, 63)
        Me.MetroGrid1.Name = "MetroGrid1"
        Me.MetroGrid1.ReadOnly = True
        Me.MetroGrid1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(196, Byte), Integer), CType(CType(37, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(201, Byte), Integer), CType(CType(57, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.MetroGrid1.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.MetroGrid1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.MetroGrid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.MetroGrid1.Size = New System.Drawing.Size(803, 443)
        Me.MetroGrid1.Style = MetroFramework.MetroColorStyle.Yellow
        Me.MetroGrid1.TabIndex = 19
        '
        'Student_Remove
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1201, 529)
        Me.Controls.Add(Me.MetroButton6)
        Me.Controls.Add(Me.MetroButton7)
        Me.Controls.Add(Me.MetroButton5)
        Me.Controls.Add(Me.MetroLabel36)
        Me.Controls.Add(Me.MetroLabel35)
        Me.Controls.Add(Me.MetroComboBox7)
        Me.Controls.Add(Me.MetroLabel34)
        Me.Controls.Add(Me.MetroComboBox6)
        Me.Controls.Add(Me.MetroLabel33)
        Me.Controls.Add(Me.MetroTextBox26)
        Me.Controls.Add(Me.MetroLabel32)
        Me.Controls.Add(Me.MetroGrid1)
        Me.MaximizeBox = False
        Me.Movable = False
        Me.Name = "Student_Remove"
        Me.Resizable = False
        Me.Style = MetroFramework.MetroColorStyle.Yellow
        Me.Text = "Remove Student"
        CType(Me.MetroGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MetroButton6 As MetroFramework.Controls.MetroButton
    Friend WithEvents MetroButton7 As MetroFramework.Controls.MetroButton
    Friend WithEvents MetroButton5 As MetroFramework.Controls.MetroButton
    Friend WithEvents MetroLabel36 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroLabel35 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroComboBox7 As MetroFramework.Controls.MetroComboBox
    Friend WithEvents MetroLabel34 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroComboBox6 As MetroFramework.Controls.MetroComboBox
    Friend WithEvents MetroLabel33 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroTextBox26 As MetroFramework.Controls.MetroTextBox
    Friend WithEvents MetroLabel32 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroGrid1 As MetroFramework.Controls.MetroGrid
End Class
