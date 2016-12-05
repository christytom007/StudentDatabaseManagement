
Imports System.ComponentModel
Imports System.Data.OleDb
Imports System.Text.RegularExpressions
Imports MetroFramework
Imports System.IO

Public Class Student_Remove

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
    Dim RecordCount As Integer
    Dim Gen As String
    Dim GuGen As String

    Dim isNAme As Boolean = False
    Dim isCource As Boolean = False
    Dim IsSem As Boolean = False
    Dim Admission_NO As String

    Private Sub MetroButton6_Click(sender As Object, e As EventArgs) Handles MetroButton6.Click
        'Delete Button

        If MetroLabel36.Text = Nothing Then
            MetroMessageBox.Show(Me, "Please Select A Student before Removing....", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim status As Integer = MetroMessageBox.Show(Me, "Are You Sure to Remove this Student. This can't be undone!!", "Confirmation..", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If status = System.Windows.Forms.DialogResult.No Then
            MetroMessageBox.Show(Me, "Deletion Canceled...", "Canceled", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If

        Try
            'Connecting string
            con.ConnectionString = dbProvider & dbSource
            If Not con.State = ConnectionState.Open Then
                'Opening Connection
                con.Open()
            End If

            sql1 = "DELETE FROM [Student] WHERE [Admission_No]='" & MetroLabel36.Text & "'"
            sql2 = "DELETE FROM [Guardians] WHERE [Student_ID]='" & MetroLabel36.Text & "'"
            'Database Selection command

            cmd = New OleDb.OleDbCommand(sql1)
            cmd.Connection = con
            RecordCount = cmd.ExecuteNonQuery()

            If RecordCount > 0 Then
                MetroMessageBox.Show(Me, "Succesfully Deleated", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Else
                MetroMessageBox.Show(Me, "Unable to Delete The Student", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            con.Close() 'Closing The connection

        Catch ex As Exception
            MetroMessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        RefreshDataGrid()
    End Sub

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
            sql1 = "SELECT Admission_No, First_Name, Last_Name, Seat_Type, Course, Scheme, Semester, Plus_Two_Percentage FROM Student WHERE First_Name LIKE '%" & MetroTextBox26.Text & "%'"
        End If
        If isNAme = True And isCource = True And IsSem = False Then
            sql1 = "SELECT Admission_No, First_Name, Last_Name, Seat_Type, Course, Scheme, Semester, Plus_Two_Percentage FROM Student WHERE First_Name LIKE '%" & MetroTextBox26.Text & "%' AND Course='" & MetroComboBox6.Text & "'"
        End If
        If isNAme = True And isCource = True And IsSem = True Then
            sql1 = "Select Admission_No, First_Name, Last_Name, Seat_Type, Course, Scheme, Semester, Plus_Two_Percentage FROM Student WHERE First_Name Like '%" & MetroTextBox26.Text & "%' AND Course='" & MetroComboBox6.Text & "' AND Semester='" & MetroComboBox7.Text & "'"
        End If
        If isNAme = False And isCource = True And IsSem = True Then
            sql1 = "Select Admission_No, First_Name, Last_Name, Seat_Type, Course, Scheme, Semester, Plus_Two_Percentage FROM Student WHERE Course='" & MetroComboBox6.Text & "' AND Semester='" & MetroComboBox7.Text & "'"
        End If
        If isNAme = True And isCource = False And IsSem = True Then
            sql1 = "Select Admission_No, First_Name, Last_Name, Seat_Type, Course, Scheme, Semester, Plus_Two_Percentage FROM Student WHERE First_Name Like '%" & MetroTextBox26.Text & "%' AND Semester='" & MetroComboBox7.Text & "'"
        End If
        If isNAme = False And isCource = False And IsSem = True Then
            sql1 = "Select Admission_No, First_Name, Last_Name, Seat_Type, Course, Scheme, Semester, Plus_Two_Percentage FROM Student WHERE Semester='" & MetroComboBox7.Text & "'"
        End If
        If isNAme = False And isCource = True And IsSem = False Then
            sql1 = "Select Admission_No, First_Name, Last_Name, Seat_Type, Course, Scheme, Semester, Plus_Two_Percentage FROM Student WHERE Course='" & MetroComboBox6.Text & "'"
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

    Private Sub Student_Remove_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        'When Form Opens

        MetroLabel36.Text = ""
        MetroTextBox26.Clear()

        Try
            con.ConnectionString = dbProvider & dbSource
            If Not con.State = ConnectionState.Open Then
                'Opening Connection
                con.Open()
            End If
            sql1 = "Select Admission_No, First_Name, Last_Name, Seat_Type, Course, Scheme, Semester, Plus_Two_Percentage From Student"
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

    Private Sub RefreshDataGrid()

        DBDT.Clear()                    'Cleaning The Data Table
        MetroGrid1.DataSource = DBDT    'Cleaning DataGrid
        Try
            con.ConnectionString = dbProvider & dbSource
            If Not con.State = ConnectionState.Open Then
                'Opening Connection
                con.Open()
            End If
            sql1 = "Select Admission_No, First_Name, Last_Name, Seat_Type, Course, Scheme, Semester, Plus_Two_Percentage From Student"
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
            sql1 = "Select Admission_No, First_Name, Last_Name, Seat_Type, Course, Scheme, Semester, Plus_Two_Percentage From Student"
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
        If MetroGrid1.CurrentRow.Index < 0 Then
            'Selected Row is 1st Row
            Exit Sub
        End If
        MetroLabel36.Text = MetroGrid1.SelectedRows(0).Cells(0).Value.ToString
        'To Get the Admin Name of selected ONE record
    End Sub

    Private Sub Student_Remove_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Student_Modify_Menu.Show()
    End Sub
End Class