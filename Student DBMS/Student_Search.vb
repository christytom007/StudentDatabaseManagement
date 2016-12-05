
Imports System.ComponentModel
Imports System.Data.OleDb
Imports System.Text.RegularExpressions
Imports MetroFramework
Imports System.IO

Public Class Student_Search

    Dim con As New OleDbConnection                                              'THE CONNECTION OBJECT
    Dim dbProvider = "PROVIDER=Microsoft.ACE.OLEDB.12.0;"                       'PROVIDER STRING
    Dim cmd As OleDbCommand = Nothing                                           'COMMAND OBJECT
    Dim FullDataPath As String = Application.StartupPath & "\Student.accdb"     'DATABASE LOCATION
    Dim dbSource As String = "Data Source = " & FullDataPath                    'COMPLETE SOURCE STRING
    Dim sql1 As String                                                          'SQL STRING
    Dim sql2 As String                                                          'SQL STRING
    Dim DBDT As New DataTable                                                   'Data Table
    Dim rdr1 As OleDbDataReader = Nothing                                        'DATABASE READER
    Dim rdr2 As OleDbDataReader = Nothing                                        'DATABASE READER
    Dim DBDA As OleDbDataAdapter                                                'Data Adapter
    Dim isFileOpened As Boolean = False
    Dim RecordCount As Integer
    Dim Gen As String
    Dim GuGen As String

    Dim isNAme As Boolean = False
    Dim isCource As Boolean = False
    Dim IsSem As Boolean = False
    Dim Admission_NO As String

    Private Sub MetroButton5_Click(sender As Object, e As EventArgs) Handles MetroButton5.Click
        'Search Button

        If MetroTextBox26.Text = Nothing And MetroComboBox6.Text = Nothing And MetroComboBox7.Text = Nothing Then
            MetroMessageBox.Show(Me, "Select Some Parametrs to Search...", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If Not MetroTextBox26.Text = Nothing Then
            'Student Name Entired
            isNAme = True
        End If
        If Not MetroComboBox6.Text = Nothing Then
            'Cource Selected
            isCource = True
        End If
        If Not MetroComboBox7.Text = Nothing Then
            'Semester Selected
            IsSem = True
        End If

        If isNAme = True And isCource = False And IsSem = False Then
            sql1 = "SELECT Admission_No, First_Name, Last_Name, Course, Scheme, Semester FROM Student WHERE First_Name LIKE '%" & MetroTextBox26.Text & "%'"
        End If
        If isNAme = True And isCource = True And IsSem = False Then
            sql1 = "SELECT Admission_No, First_Name, Last_Name, Course, Scheme, Semester FROM Student WHERE First_Name LIKE '%" & MetroTextBox26.Text & "%' AND Course='" & MetroComboBox6.Text & "'"
        End If
        If isNAme = True And isCource = True And IsSem = True Then
            sql1 = "Select Admission_No, First_Name, Last_Name, Course, Scheme, Semester FROM Student WHERE First_Name Like '%" & MetroTextBox26.Text & "%' AND Course='" & MetroComboBox6.Text & "' AND Semester='" & MetroComboBox7.Text & "'"
        End If
        If isNAme = False And isCource = True And IsSem = True Then
            sql1 = "Select Admission_No, First_Name, Last_Name, Course, Scheme, Semester FROM Student WHERE Course='" & MetroComboBox6.Text & "' AND Semester='" & MetroComboBox7.Text & "'"
        End If
        If isNAme = True And isCource = False And IsSem = True Then
            sql1 = "Select Admission_No, First_Name, Last_Name, Course, Scheme, Semester FROM Student WHERE First_Name Like '%" & MetroTextBox26.Text & "%' AND Semester='" & MetroComboBox7.Text & "'"
        End If
        If isNAme = False And isCource = False And IsSem = True Then
            sql1 = "Select Admission_No, First_Name, Last_Name, Course, Scheme, Semester FROM Student WHERE Semester='" & MetroComboBox7.Text & "'"
        End If
        If isNAme = False And isCource = True And IsSem = False Then
            sql1 = "Select Admission_No, First_Name, Last_Name, Course, Scheme, Semester FROM Student WHERE Course='" & MetroComboBox6.Text & "'"
        End If
        RecordCount = 0
        Try
            DBDT.Clear()                    'Cleaning The Data Table
            MetroGrid1.DataSource = DBDT    'Cleaning DataGrid

            con.ConnectionString = dbProvider & dbSource
            If Not con.State = ConnectionState.Open Then
                'Opening Connection
                con.Open()
            End If
            cmd = New OleDbCommand(sql1)
            cmd.Connection = con
            'Creating Connection

            DBDA = New OleDbDataAdapter(cmd)
            RecordCount = DBDA.Fill(DBDT)

            MetroGrid1.DataSource = DBDT

            con.Close() 'Closing The connection

        Catch ex As Exception
            MetroMessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub


    Private Sub MetroButton6_Click(sender As Object, e As EventArgs) Handles MetroButton6.Click
        'View Button

        If MetroLabel36.Text = Nothing Then
            MetroMessageBox.Show(Me, "Please Select A Student before Viewing....", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        MetroLabel37.Text = MetroLabel36.Text

        Try
            'Connecting string
            con.ConnectionString = dbProvider & dbSource
            If Not con.State = ConnectionState.Open Then
                'Opening Connection
                con.Open()
            End If

            sql1 = "Select * From [Student] where [Admission_No]='" & MetroLabel36.Text & "'"
            sql2 = "Select * From [Guardians] where [Student_ID]='" & MetroLabel36.Text & "'"
            'Database Selection command

            cmd = New OleDb.OleDbCommand(sql1)
            cmd.Connection = con
            rdr1 = cmd.ExecuteReader()

            rdr1.Read()

            MetroLabel37.Text = rdr1.GetValue(0)    'Addmision no
            MetroLabel38.Text = rdr1.GetValue(1) & rdr1.GetValue(2)    ' Name
            If rdr1.GetValue(3) = "Male" Then
                MetroLabel48.Text = "Male"
            Else
                MetroLabel48.Text = "Female"
            End If
            MetroLabel49.Text = rdr1.GetValue(4) 'DOB
            MetroLabel50.Text = rdr1.GetValue(5) 'Blood
            MetroLabel51.Text = rdr1.GetValue(6) 'Address
            MetroLabel52.Text = rdr1.GetValue(7)   'City
            MetroLabel53.Text = rdr1.GetValue(8)   'State
            MetroLabel57.Text = rdr1.GetValue(9)   'Country
            MetroLabel58.Text = rdr1.GetValue(10)  'postal code
            MetroLabel54.Text = rdr1.GetValue(11)  'Email ID
            MetroLabel55.Text = rdr1.GetValue(12)  'Home ph
            MetroLabel56.Text = rdr1.GetValue(13) 'Mobile No
            MetroLabel42.Text = rdr1.GetValue(14) 'Seat Type
            MetroLabel43.Text = rdr1.GetValue(15) 'Course
            MetroLabel44.Text = rdr1.GetValue(16) 'Scheme
            MetroLabel41.Text = rdr1.GetValue(17) 'Sem
            MetroLabel40.Text = rdr1.GetValue(18)  'Reg no
            MetroLabel45.Text = rdr1.GetValue(19)  'Last School name
            MetroLabel46.Text = rdr1.GetValue(20) 'School address
            MetroLabel47.Text = rdr1.GetValue(21) '+2 Percentage

            Dim bytes As [Byte]() = rdr1.GetValue(22) ' photo
            Dim ms As New MemoryStream(bytes)
            PictureBox1.BackgroundImage = Image.FromStream(ms)

            cmd = New OleDb.OleDbCommand(sql2)
            cmd.Connection = con
            rdr2 = cmd.ExecuteReader()

            rdr2.Read()
            MetroLabel59.Text = rdr2.GetValue(1) 'Father Name
            MetroLabel60.Text = rdr2.GetValue(2) & rdr2.GetValue(3) ' Name
            If rdr2.GetValue(4) = "Male" Then 'Gender
                MetroLabel62.Text = "Male"
            Else
                MetroLabel62.Text = "Female"
            End If

            MetroLabel63.Text = rdr2.GetValue(5) 'Relation
            MetroLabel64.Text = rdr2.GetValue(6) 'Company
            MetroLabel65.Text = rdr2.GetValue(7) 'Job
            MetroLabel67.Text = rdr2.GetValue(8) 'Business ph
            MetroLabel68.Text = rdr2.GetValue(9) 'Home ph
            MetroLabel69.Text = rdr2.GetValue(10) 'Mobile ph
            MetroLabel66.Text = rdr2.GetValue(11) 'Address

            con.Close() 'Closing The connection

        Catch ex As Exception
            MetroMessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        MetroTabControl1.SelectTab(1)

    End Sub

    Private Sub MetroButton4_Click(sender As Object, e As EventArgs) Handles MetroButton4.Click
        'Exit Button
        Close()

    End Sub

    Private Sub Student_Edit_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        'When Form Opens

        MetroLabel36.Text = ""
        MetroTextBox26.Clear()

        MetroTabControl1.SelectTab(0)
        Try
            con.ConnectionString = dbProvider & dbSource
            If Not con.State = ConnectionState.Open Then
                'Opening Connection
                con.Open()
            End If
            sql1 = "Select Admission_No, First_Name, Last_Name, Course, Scheme, Semester From Student"
            'Selection Query

            cmd = New OleDbCommand(sql1)
            cmd.Connection = con
            'Creating Connection

            DBDA = New OleDbDataAdapter(cmd)
            RecordCount = DBDA.Fill(DBDT)

            MetroGrid1.DataSource = DBDT

            con.Close() 'Closing The connection

        Catch ex As Exception
            MetroMessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub MetroButton7_Click(sender As Object, e As EventArgs) Handles MetroButton7.Click
        'Clearing Search Parametrs

        DBDT.Clear()                    'Cleaning The Data Table
        MetroGrid1.DataSource = DBDT    'Cleaning DataGrid

        MetroTextBox26.Clear()

        Try
            con.ConnectionString = dbProvider & dbSource
            If Not con.State = ConnectionState.Open Then
                'Opening Connection
                con.Open()
            End If
            sql1 = "Select Admission_No, First_Name, Last_Name, Course, Scheme, Semester From Student"
            'Selection Query

            cmd = New OleDbCommand(sql1)
            cmd.Connection = con
            'Creating Connection

            DBDA = New OleDbDataAdapter(cmd)
            RecordCount = DBDA.Fill(DBDT)

            MetroGrid1.DataSource = DBDT

            con.Close() 'Closing The connection

        Catch ex As Exception
            MetroMessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub MetroGrid1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles MetroGrid1.CellDoubleClick
        'Selecting A Cell 

        If MetroGrid1.CurrentRow.Index < 0 Then
            'Selected Row is 1st Row
            Exit Sub
        End If

        MetroLabel36.Text = MetroGrid1.SelectedRows(0).Cells(0).Value.ToString
        'To Get the Admin Name of selected ONE record

    End Sub

    Private Sub MetroButton8_Click(sender As Object, e As EventArgs) Handles MetroButton8.Click
        'Back Button
        MetroTabControl1.SelectTab(0)

    End Sub

    Private Sub MetroButton2_Click(sender As Object, e As EventArgs) Handles MetroButton2.Click
        'Next Button of 1st page
        MetroTabControl1.SelectTab(2)
    End Sub

    Private Sub MetroButton3_Click(sender As Object, e As EventArgs) Handles MetroButton3.Click
        'Next Button in 2nd Page
        MetroTabControl1.SelectTab(3)

    End Sub

    Private Sub Student_Search_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Student_Modify_Menu.Show()
    End Sub

End Class