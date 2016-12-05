Imports System.ComponentModel
Imports System.Data.OleDb
Imports System.Text.RegularExpressions
Imports MetroFramework
Imports System.IO

Public Class Student_Fee_Add
    Dim con As New OleDbConnection                                              'THE CONNECTION OBJECT
    Dim dbProvider = "PROVIDER=Microsoft.ACE.OLEDB.12.0;"                       'PROVIDER STRING
    Dim cmd As OleDbCommand = Nothing                                           'COMMAND OBJECT
    Dim FullDataPath As String = Application.StartupPath & "\Student.accdb"     'DATABASE LOCATION
    Dim dbSource As String = "Data Source = " & FullDataPath                    'COMPLETE SOURCE STRING
    Dim sql1 As String                                                          'SQL STRING
    Dim sql2 As String                                                          'SQL STRING
    Dim DBDT As New DataTable                                                   'Data Table
    Dim DBDT2 As New DataTable
    Dim rdr1 As OleDbDataReader = Nothing                                        'DATABASE READER
    Dim rdr2 As OleDbDataReader = Nothing                                        'DATABASE READER
    Dim DBDA As OleDbDataAdapter                                                'Data Adapter
    Dim isFileOpened As Boolean = False
    Dim RecordCount As Integer
    Dim Gen As String
    Dim GuGen As String

    Dim isCource As Boolean = False
    Dim IsSem As Boolean = False
    Dim Admission_NO As String
    Public Shared Add_New_From_Fee_Mange As Integer = 0
    Public Shared Admission_Student_Fee_Add As String

    Private Sub MetroButton5_Click(sender As Object, e As EventArgs) Handles MetroButton5.Click
        'Search Button

        If MetroComboBox6.Text = Nothing And MetroComboBox7.Text = Nothing Then
            MetroMessageBox.Show(Me, "Select Some Parametrs to Search...", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If Not MetroComboBox6.Text = Nothing Then
            'Cource Selected
            isCource = True
        End If
        If Not MetroComboBox7.Text = Nothing Then
            'Semester Selected
            IsSem = True
        End If

        If isCource = True And IsSem = False Then
            sql1 = "SELECT Admission_No, First_Name, Last_Name, Course, Scheme, Semester FROM Student WHERE Course='" & MetroComboBox6.Text & "'"
        End If
        If isCource = True And IsSem = True Then
            sql1 = "Select Admission_No, First_Name, Last_Name, Course, Scheme, Semester FROM Student WHERE Course='" & MetroComboBox6.Text & "' AND Semester='" & MetroComboBox7.Text & "'"
        End If
        If isCource = False And IsSem = True Then
            sql1 = "Select Admission_No, First_Name, Last_Name, Course, Scheme, Semester FROM Student WHERE Semester='" & MetroComboBox7.Text & "'"
        End If

        RecordCount = 0
        Try
            DBDT2.Clear()                    'Cleaning The Data Table
            MetroGrid1.DataSource = DBDT2    'Cleaning DataGrid
            DBDT.Clear()

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

            For i As Integer = 0 To DBDT.Rows.Count - 1

                sql2 = "SELECT Student_ID, Y1_Paid, Y1_Remaining, Y2_Paid, Y2_Remaining, Y3_Paid, Y3_Remaining, Y4_Paid, Y4_Remaining FROM Fee_Paid WHERE Student_ID ='" & DBDT.Rows(i).Item(0) & "'"
                cmd = New OleDbCommand(sql2)
                cmd.Connection = con
                DBDA = New OleDbDataAdapter(cmd)
                DBDA.Fill(DBDT2)

            Next

            MetroGrid1.DataSource = DBDT2

            con.Close() 'Closing The connection

        Catch ex As Exception
            MetroMessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub MetroButton7_Click(sender As Object, e As EventArgs) Handles MetroButton7.Click
        'Clear all Button

        RecordCount = 0
        Try
            DBDT2.Clear()                    'Cleaning The Data Table
            MetroGrid1.DataSource = DBDT2    'Cleaning DataGrid
            DBDT.Clear()

            con.ConnectionString = dbProvider & dbSource
            If Not con.State = ConnectionState.Open Then
                'Opening Connection
                con.Open()
            End If
            sql1 = "SELECT Admission_No, First_Name, Last_Name, Course, Scheme, Semester FROM Student"
            cmd = New OleDbCommand(sql1)
            cmd.Connection = con
            'Creating Connection

            DBDA = New OleDbDataAdapter(cmd)
            RecordCount = DBDA.Fill(DBDT)

            For i As Integer = 0 To DBDT.Rows.Count - 1
                'Featch each record from Fee_Paid table
                sql2 = "SELECT Student_ID, Y1_Paid, Y1_Remaining, Y2_Paid, Y2_Remaining, Y3_Paid, Y3_Remaining, Y4_Paid, Y4_Remaining FROM Fee_Paid WHERE Student_ID ='" & DBDT.Rows(i).Item(0) & "'"
                cmd = New OleDbCommand(sql2)
                cmd.Connection = con
                DBDA = New OleDbDataAdapter(cmd)
                DBDA.Fill(DBDT2)
            Next

            MetroGrid1.DataSource = DBDT2
            con.Close() 'Closing The connection
        Catch ex As Exception
            MetroMessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub MetroButton6_Click(sender As Object, e As EventArgs) Handles MetroButton6.Click
        'Add Fee Detail Button

        If MetroLabel36.Text = Nothing Then
            MetroMessageBox.Show(Me, "Please Select A Student before Editing....", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Add_New_From_Fee_Mange = 1
        Admission_Student_Fee_Add = MetroLabel36.Text
        Student_Fee_Add_Common.Show()
        Hide()
    End Sub

    Private Sub MetroGrid1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles MetroGrid1.CellDoubleClick
        'Cell Double click for student selection

        If MetroGrid1.CurrentRow.Index < 0 Then
            'Selected Row is 1st Row
            Exit Sub
        End If

        MetroLabel36.Text = MetroGrid1.SelectedRows(0).Cells(0).Value.ToString
        'To Get the Admin Name of selected ONE record

        RecordCount = 0
        Try
            con.ConnectionString = dbProvider & dbSource
            If Not con.State = ConnectionState.Open Then
                'Opening Connection
                con.Open()
            End If

            sql1 = "SELECT First_Name, Last_Name, Course, Scheme, Semester FROM Student WHERE Admission_No='" & MetroLabel36.Text & "'"
            cmd = New OleDbCommand(sql1)
            cmd.Connection = con
            'Creating Connection
            rdr1 = cmd.ExecuteReader
            rdr1.Read()
            MetroLabel1.Text = rdr1.GetValue(0) & " " & rdr1.GetValue(1) 'Name
            MetroLabel3.Text = rdr1.GetValue(3) 'Scheme
            MetroLabel4.Text = rdr1.GetValue(4) 'Sem
            MetroLabel6.Text = rdr1.GetValue(2) 'Course
            con.Close() 'Closing The connection

        Catch ex As Exception
            MetroMessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Student_Fee_Add_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        'Form Loads
        MetroLabel36.Text = ""
        MetroLabel1.Text = ""
        MetroLabel6.Text = ""
        MetroLabel3.Text = ""
        MetroLabel4.Text = ""
        RecordCount = 0
        Try
            DBDT2.Clear()                    'Cleaning The Data Table
            MetroGrid1.DataSource = DBDT2    'Cleaning DataGrid
            DBDT.Clear()

            con.ConnectionString = dbProvider & dbSource
            If Not con.State = ConnectionState.Open Then
                'Opening Connection
                con.Open()
            End If
            sql1 = "SELECT Admission_No, First_Name, Last_Name, Course, Scheme, Semester FROM Student"
            cmd = New OleDbCommand(sql1)
            cmd.Connection = con
            'Creating Connection

            DBDA = New OleDbDataAdapter(cmd)
            RecordCount = DBDA.Fill(DBDT)

            For i As Integer = 0 To DBDT.Rows.Count - 1
                'Featch each record from Fee_Paid table
                sql2 = "SELECT Student_ID, Y1_Paid, Y1_Remaining, Y2_Paid, Y2_Remaining, Y3_Paid, Y3_Remaining, Y4_Paid, Y4_Remaining FROM Fee_Paid WHERE Student_ID ='" & DBDT.Rows(i).Item(0) & "'"
                cmd = New OleDbCommand(sql2)
                cmd.Connection = con
                DBDA = New OleDbDataAdapter(cmd)
                DBDA.Fill(DBDT2)
            Next

            MetroGrid1.DataSource = DBDT2
            con.Close() 'Closing The connection
        Catch ex As Exception
            MetroMessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Student_Fee_Add_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        'Form CLosing
        Student_Fee_Mang_Menu.Show()
    End Sub

End Class