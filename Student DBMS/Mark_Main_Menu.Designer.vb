<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Mark_Main_Menu
    Inherits MetroFramework.Forms.MetroForm

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
        Me.MetroTile8 = New MetroFramework.Controls.MetroTile()
        Me.MetroTile5 = New MetroFramework.Controls.MetroTile()
        Me.MetroTile4 = New MetroFramework.Controls.MetroTile()
        Me.MetroTile1 = New MetroFramework.Controls.MetroTile()
        Me.SuspendLayout()
        '
        'MetroTile8
        '
        Me.MetroTile8.ActiveControl = Nothing
        Me.MetroTile8.Location = New System.Drawing.Point(23, 236)
        Me.MetroTile8.Name = "MetroTile8"
        Me.MetroTile8.Size = New System.Drawing.Size(240, 134)
        Me.MetroTile8.Style = MetroFramework.MetroColorStyle.Purple
        Me.MetroTile8.TabIndex = 0
        Me.MetroTile8.Text = "Generate University Exam Rank List"
        Me.MetroTile8.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.MetroTile8.TileImage = Global.Student_DBMS.My.Resources.Resources.Rank_history64
        Me.MetroTile8.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.MetroTile8.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular
        Me.MetroTile8.UseCustomForeColor = True
        Me.MetroTile8.UseSelectable = True
        Me.MetroTile8.UseTileImage = True
        '
        'MetroTile5
        '
        Me.MetroTile5.ActiveControl = Nothing
        Me.MetroTile5.Location = New System.Drawing.Point(240, 96)
        Me.MetroTile5.Name = "MetroTile5"
        Me.MetroTile5.Size = New System.Drawing.Size(241, 134)
        Me.MetroTile5.Style = MetroFramework.MetroColorStyle.Brown
        Me.MetroTile5.TabIndex = 0
        Me.MetroTile5.Text = "Add / Edit University Exam Marks"
        Me.MetroTile5.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.MetroTile5.TileImage = Global.Student_DBMS.My.Resources.Resources.add_to_favorites64
        Me.MetroTile5.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.MetroTile5.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular
        Me.MetroTile5.UseCustomForeColor = True
        Me.MetroTile5.UseSelectable = True
        Me.MetroTile5.UseTileImage = True
        '
        'MetroTile4
        '
        Me.MetroTile4.ActiveControl = Nothing
        Me.MetroTile4.Location = New System.Drawing.Point(269, 236)
        Me.MetroTile4.Name = "MetroTile4"
        Me.MetroTile4.Size = New System.Drawing.Size(212, 134)
        Me.MetroTile4.Style = MetroFramework.MetroColorStyle.Red
        Me.MetroTile4.TabIndex = 0
        Me.MetroTile4.Text = "Add / Edit Internal Marks"
        Me.MetroTile4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.MetroTile4.TileImage = Global.Student_DBMS.My.Resources.Resources.binary_tree64
        Me.MetroTile4.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.MetroTile4.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular
        Me.MetroTile4.UseCustomForeColor = True
        Me.MetroTile4.UseSelectable = True
        Me.MetroTile4.UseTileImage = True
        '
        'MetroTile1
        '
        Me.MetroTile1.ActiveControl = Nothing
        Me.MetroTile1.Location = New System.Drawing.Point(23, 96)
        Me.MetroTile1.Name = "MetroTile1"
        Me.MetroTile1.Size = New System.Drawing.Size(211, 134)
        Me.MetroTile1.Style = MetroFramework.MetroColorStyle.Yellow
        Me.MetroTile1.TabIndex = 0
        Me.MetroTile1.Text = "Add / Edit Series Exam Marks"
        Me.MetroTile1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.MetroTile1.TileImage = Global.Student_DBMS.My.Resources.Resources.add_to_database64
        Me.MetroTile1.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.MetroTile1.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular
        Me.MetroTile1.UseCustomForeColor = True
        Me.MetroTile1.UseSelectable = True
        Me.MetroTile1.UseTileImage = True
        '
        'Mark_Main_Menu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(510, 394)
        Me.Controls.Add(Me.MetroTile8)
        Me.Controls.Add(Me.MetroTile5)
        Me.Controls.Add(Me.MetroTile4)
        Me.Controls.Add(Me.MetroTile1)
        Me.MaximizeBox = False
        Me.Movable = False
        Me.Name = "Mark_Main_Menu"
        Me.Resizable = False
        Me.Text = "Exam Marks Management"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents MetroTile1 As MetroFramework.Controls.MetroTile
    Friend WithEvents MetroTile4 As MetroFramework.Controls.MetroTile
    Friend WithEvents MetroTile5 As MetroFramework.Controls.MetroTile
    Friend WithEvents MetroTile8 As MetroFramework.Controls.MetroTile
End Class
