Imports System.ComponentModel
Imports System.Data.OleDb
Imports System.Text.RegularExpressions
Imports MetroFramework
Imports System.IO
Public Class Mark_Internal
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

    Dim isNAme As Boolean = False
    Dim isCource As Boolean = False
    Dim IsSem As Boolean = False
    Dim Admission_NO As String
    Dim Sem As Integer

    Private Sub Mark_Internal_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        'Closing
        Mark_Main_Menu.Show()

    End Sub

    Private Sub Mark_Internal_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        'Form Loads
        MetroLabel4.Text = ""
        MetroTabControl1.TabPages(1).Enabled = False
        MetroTabControl1.TabPages(2).Enabled = False
        MetroTabControl1.TabPages(3).Enabled = False
        MetroTabControl1.TabPages(4).Enabled = False
        MetroTabControl1.TabPages(5).Enabled = False
        MetroTabControl1.TabPages(6).Enabled = False
        MetroTabControl1.TabPages(7).Enabled = False
        Clear_All_Text()

        If Admin_Control_Panel.Depart = "CS" Then
            MetroLabel6.Text = "Computer Science"
        ElseIf Admin_Control_Panel.Depart = "EE"
            MetroLabel6.Text = "Electrical And Electronics"
        ElseIf Admin_Control_Panel.Depart = "EC"
            MetroLabel6.Text = "Electronics And CommIntercations"
        Else
            MetroLabel6.Text = "Information Technology"
        End If

        MetroTabControl1.TabPages(1).Hide()
        MetroTabControl1.TabPages(2).Hide()
        MetroTabControl1.TabPages(3).Hide()
        MetroTabControl1.TabPages(4).Hide()
        MetroTabControl1.TabPages(5).Hide()
        MetroTabControl1.TabPages(6).Hide()
        MetroTabControl1.TabPages(7).Hide()

        MetroLabel4.Text = ""
        MetroTextBox26.Clear()

        MetroTabControl1.SelectTab(0)

        Try
            con.ConnectionString = dbProvider & dbSource
            If Not con.State = ConnectionState.Open Then
                'Opening Connection
                con.Open()
            End If
            sql1 = "SELECT Admission_No, First_Name, Last_Name, Scheme, Semester FROM Student WHERE Course='" & MetroLabel6.Text & "'"
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

    Private Sub Clear_All_Text()
        MetroTextBox1.Text = 0
        MetroTextBox10.Text = 0
        MetroTextBox101.Text = 0
        MetroTextBox104.Text = 0
        MetroTextBox105.Text = 0
        MetroTextBox107.Text = 0
        MetroTextBox109.Text = 0
        MetroTextBox11.Text = 0
        MetroTextBox111.Text = 0
        MetroTextBox113.Text = 0
        MetroTextBox117.Text = 0
        MetroTextBox12.Text = 0
        MetroTextBox121.Text = 0
        MetroTextBox2.Text = 0
        MetroTextBox25.Text = 0
        MetroTextBox27.Text = 0
        MetroTextBox28.Text = 0
        MetroTextBox29.Text = 0
        MetroTextBox3.Text = 0
        MetroTextBox30.Text = 0
        MetroTextBox31.Text = 0
        MetroTextBox32.Text = 0
        MetroTextBox33.Text = 0
        MetroTextBox4.Text = 0
        MetroTextBox43.Text = 0
        MetroTextBox45.Text = 0
        MetroTextBox47.Text = 0
        MetroTextBox49.Text = 0
        MetroTextBox5.Text = 0
        MetroTextBox51.Text = 0
        MetroTextBox53.Text = 0
        MetroTextBox56.Text = 0
        MetroTextBox57.Text = 0
        MetroTextBox59.Text = 0
        MetroTextBox6.Text = 0
        MetroTextBox61.Text = 0
        MetroTextBox63.Text = 0
        MetroTextBox65.Text = 0
        MetroTextBox67.Text = 0
        MetroTextBox69.Text = 0
        MetroTextBox69.Text = 0
        MetroTextBox7.Text = 0
        MetroTextBox72.Text = 0
        MetroTextBox73.Text = 0
        MetroTextBox75.Text = 0
        MetroTextBox77.Text = 0
        MetroTextBox79.Text = 0
        MetroTextBox8.Text = 0
        MetroTextBox81.Text = 0
        MetroTextBox83.Text = 0
        MetroTextBox85.Text = 0
        MetroTextBox88.Text = 0
        MetroTextBox89.Text = 0
        MetroTextBox9.Text = 0
        MetroTextBox91.Text = 0
        MetroTextBox93.Text = 0
        MetroTextBox95.Text = 0
        MetroTextBox97.Text = 0
        MetroTextBox99.Text = 0
    End Sub

    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        'Add Mark Button
        If MetroLabel4.Text = Nothing Then
            MetroMessageBox.Show(Me, "Please Select A Student before Editing....", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        MetroTabControl1.SelectTab(1)
    End Sub

    Private Sub MetroButton3_Click(sender As Object, e As EventArgs) Handles MetroButton3.Click
        'Search Button
        If MetroTextBox26.Text = Nothing And MetroComboBox7.Text = Nothing Then
            MetroMessageBox.Show(Me, "Select Some Parametrs to Search...", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If Not MetroTextBox26.Text = Nothing Then
            'Student Name Entired
            isNAme = True
        End If
        If Not MetroLabel6.Text = Nothing Then
            'Cource Selected
            isCource = True
        End If
        If Not MetroComboBox7.Text = Nothing Then
            'Semester Selected
            IsSem = True
        End If

        If isNAme = True And isCource = False And IsSem = False Then
            sql1 = "SELECT Admission_No, First_Name, Last_Name, Scheme, Semester FROM Student WHERE First_Name LIKE '%" & MetroTextBox26.Text & "%'"
        End If
        If isNAme = True And isCource = True And IsSem = False Then
            sql1 = "SELECT Admission_No, First_Name, Last_Name, Scheme, Semester FROM Student WHERE First_Name LIKE '%" & MetroTextBox26.Text & "%' AND Course='" & MetroLabel6.Text & "'"
        End If
        If isNAme = True And isCource = True And IsSem = True Then
            sql1 = "Select Admission_No, First_Name, Last_Name, Scheme, Semester FROM Student WHERE First_Name Like '%" & MetroTextBox26.Text & "%' AND Course='" & MetroLabel6.Text & "' AND Semester='" & MetroComboBox7.Text & "'"
        End If
        If isNAme = False And isCource = True And IsSem = True Then
            sql1 = "Select Admission_No, First_Name, Last_Name, Scheme, Semester FROM Student WHERE Course='" & MetroLabel6.Text & "' AND Semester='" & MetroComboBox7.Text & "'"
        End If
        If isNAme = True And isCource = False And IsSem = True Then
            sql1 = "Select Admission_No, First_Name, Last_Name, Scheme, Semester FROM Student WHERE First_Name Like '%" & MetroTextBox26.Text & "%' AND Semester='" & MetroComboBox7.Text & "'"
        End If
        If isNAme = False And isCource = False And IsSem = True Then
            sql1 = "Select Admission_No, First_Name, Last_Name, Scheme, Semester FROM Student WHERE Semester='" & MetroComboBox7.Text & "'"
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

    Private Sub MetroButton2_Click(sender As Object, e As EventArgs) Handles MetroButton2.Click
        'Clear Button
        DBDT.Clear()                    'Cleaning The Data Table
        MetroGrid1.DataSource = DBDT    'Cleaning DataGrid

        MetroTextBox26.Clear()
        MetroComboBox7.Text = ""

        Try
            con.ConnectionString = dbProvider & dbSource
            If Not con.State = ConnectionState.Open Then
                'Opening Connection
                con.Open()
            End If
            sql1 = "SELECT Admission_No, First_Name, Last_Name, Scheme, Semester FROM Student WHERE Course='" & MetroLabel6.Text & "'"
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
        'Data Grid Cell Double Click
        Clear_All_Text()
        If MetroGrid1.CurrentRow.Index < 0 Then
            'Selected Row is 1st Row
            Exit Sub
        End If

        MetroLabel4.Text = MetroGrid1.SelectedRows(0).Cells(0).Value.ToString
        Admission_NO = MetroLabel4.Text
        Sem = Convert.ToInt32(MetroGrid1.SelectedRows(0).Cells(4).Value.ToString)
        If Sem = 1 Or Sem = 2 Then
            MetroTabControl1.TabPages(1).Enabled = True
            MetroTabControl1.TabPages(2).Enabled = False
            MetroTabControl1.TabPages(3).Enabled = False
            MetroTabControl1.TabPages(4).Enabled = False
            MetroTabControl1.TabPages(5).Enabled = False
            MetroTabControl1.TabPages(6).Enabled = False
            MetroTabControl1.TabPages(7).Enabled = False
        End If
        If Sem = 3 Then
            MetroTabControl1.TabPages(1).Enabled = True
            MetroTabControl1.TabPages(2).Enabled = True
            MetroTabControl1.TabPages(3).Enabled = False
            MetroTabControl1.TabPages(4).Enabled = False
            MetroTabControl1.TabPages(5).Enabled = False
            MetroTabControl1.TabPages(6).Enabled = False
            MetroTabControl1.TabPages(7).Enabled = False
        End If
        If Sem = 4 Then
            MetroTabControl1.TabPages(1).Enabled = True
            MetroTabControl1.TabPages(2).Enabled = True
            MetroTabControl1.TabPages(3).Enabled = True
            MetroTabControl1.TabPages(4).Enabled = False
            MetroTabControl1.TabPages(5).Enabled = False
            MetroTabControl1.TabPages(6).Enabled = False
            MetroTabControl1.TabPages(7).Enabled = False
        End If
        If Sem = 5 Then
            MetroTabControl1.TabPages(1).Enabled = True
            MetroTabControl1.TabPages(2).Enabled = True
            MetroTabControl1.TabPages(3).Enabled = True
            MetroTabControl1.TabPages(4).Enabled = True
            MetroTabControl1.TabPages(5).Enabled = False
            MetroTabControl1.TabPages(6).Enabled = False
            MetroTabControl1.TabPages(7).Enabled = False
        End If
        If Sem = 6 Then
            MetroTabControl1.TabPages(1).Enabled = True
            MetroTabControl1.TabPages(2).Enabled = True
            MetroTabControl1.TabPages(3).Enabled = True
            MetroTabControl1.TabPages(4).Enabled = True
            MetroTabControl1.TabPages(5).Enabled = True
            MetroTabControl1.TabPages(6).Enabled = False
            MetroTabControl1.TabPages(7).Enabled = False
        End If
        If Sem = 7 Then
            MetroTabControl1.TabPages(1).Enabled = True
            MetroTabControl1.TabPages(2).Enabled = True
            MetroTabControl1.TabPages(3).Enabled = True
            MetroTabControl1.TabPages(4).Enabled = True
            MetroTabControl1.TabPages(5).Enabled = True
            MetroTabControl1.TabPages(6).Enabled = True
            MetroTabControl1.TabPages(7).Enabled = False
        End If
        If Sem = 8 Then
            MetroTabControl1.TabPages(1).Enabled = True
            MetroTabControl1.TabPages(2).Enabled = True
            MetroTabControl1.TabPages(3).Enabled = True
            MetroTabControl1.TabPages(4).Enabled = True
            MetroTabControl1.TabPages(5).Enabled = True
            MetroTabControl1.TabPages(6).Enabled = True
            MetroTabControl1.TabPages(7).Enabled = True
        End If
        'Y1 Reading
        Try
            con.ConnectionString = dbProvider & dbSource
            If Not con.State = ConnectionState.Open Then
                'Opening Connection
                con.Open()
            End If
            sql1 = "SELECT Inter_Sub1,Inter_Sub2,Inter_Sub3,Inter_Sub4,Inter_Sub5,Inter_Sub6,Inter_Sub7,Inter_Sub8,Inter_Sub9,Inter_Lab1,Inter_Lab2,Inter_Lab3 From Y1 WHERE Student_ID='" & Admission_NO & "'"
            cmd = New OleDbCommand(sql1)
            cmd.Connection = con
            rdr1 = cmd.ExecuteReader()
            If rdr1.Read Then
                MetroTextBox1.Text = rdr1.GetValue(0)
                MetroTextBox2.Text = rdr1.GetValue(1)
                MetroTextBox3.Text = rdr1.GetValue(2)
                MetroTextBox4.Text = rdr1.GetValue(3)
                MetroTextBox5.Text = rdr1.GetValue(4)
                MetroTextBox6.Text = rdr1.GetValue(5)
                MetroTextBox7.Text = rdr1.GetValue(6)
                MetroTextBox8.Text = rdr1.GetValue(7)
                MetroTextBox9.Text = rdr1.GetValue(8)
                MetroTextBox10.Text = rdr1.GetValue(9)
                MetroTextBox11.Text = rdr1.GetValue(10)
                MetroTextBox12.Text = rdr1.GetValue(11)
            End If
            con.Close() 'Closing The connection
        Catch ex As Exception
            MetroMessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'S3 Reading
        Try
            con.ConnectionString = dbProvider & dbSource
            If Not con.State = ConnectionState.Open Then
                'Opening Connection
                con.Open()
            End If
            sql1 = "SELECT Inter_Sub1,Inter_Sub2,Inter_Sub3,Inter_Sub4,Inter_Sub5,Inter_Sub6,Inter_Lab1,Inter_Lab2 From S3 WHERE Student_ID='" & Admission_NO & "'"
            cmd = New OleDbCommand(sql1)
            cmd.Connection = con
            rdr1 = cmd.ExecuteReader()
            If rdr1.Read Then
                MetroTextBox31.Text = rdr1.GetValue(0)
                MetroTextBox30.Text = rdr1.GetValue(1)
                MetroTextBox29.Text = rdr1.GetValue(2)
                MetroTextBox28.Text = rdr1.GetValue(3)
                MetroTextBox27.Text = rdr1.GetValue(4)
                MetroTextBox25.Text = rdr1.GetValue(5)
                MetroTextBox32.Text = rdr1.GetValue(6)
                MetroTextBox33.Text = rdr1.GetValue(7)
            End If
            con.Close() 'Closing The connection
        Catch ex As Exception
            MetroMessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'S4 Reading
        Try
            con.ConnectionString = dbProvider & dbSource
            If Not con.State = ConnectionState.Open Then
                'Opening Connection
                con.Open()
            End If
            sql1 = "SELECT Inter_Sub1,Inter_Sub2,Inter_Sub3,Inter_Sub4,Inter_Sub5,Inter_Sub6,Inter_Lab1,Inter_Lab2 From S4 WHERE Student_ID='" & Admission_NO & "'"
            cmd = New OleDbCommand(sql1)
            cmd.Connection = con
            rdr1 = cmd.ExecuteReader()
            If rdr1.Read Then
                MetroTextBox57.Text = rdr1.GetValue(0)
                MetroTextBox53.Text = rdr1.GetValue(1)
                MetroTextBox49.Text = rdr1.GetValue(2)
                MetroTextBox47.Text = rdr1.GetValue(3)
                MetroTextBox45.Text = rdr1.GetValue(4)
                MetroTextBox43.Text = rdr1.GetValue(5)
                MetroTextBox56.Text = rdr1.GetValue(6)
                MetroTextBox51.Text = rdr1.GetValue(7)
            End If
            con.Close() 'Closing The connection
        Catch ex As Exception
            MetroMessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'S5 Reading
        Try
            con.ConnectionString = dbProvider & dbSource
            If Not con.State = ConnectionState.Open Then
                'Opening Connection
                con.Open()
            End If
            sql1 = "SELECT Inter_Sub1,Inter_Sub2,Inter_Sub3,Inter_Sub4,Inter_Sub5,Inter_Sub6,Inter_Lab1,Inter_Lab2 From S5 WHERE Student_ID='" & Admission_NO & "'"
            cmd = New OleDbCommand(sql1)
            cmd.Connection = con
            rdr1 = cmd.ExecuteReader()
            If rdr1.Read() Then
                MetroTextBox73.Text = rdr1.GetValue(0)
                MetroTextBox69.Text = rdr1.GetValue(1)
                MetroTextBox65.Text = rdr1.GetValue(2)
                MetroTextBox63.Text = rdr1.GetValue(3)
                MetroTextBox61.Text = rdr1.GetValue(4)
                MetroTextBox59.Text = rdr1.GetValue(5)
                MetroTextBox72.Text = rdr1.GetValue(6)
                MetroTextBox67.Text = rdr1.GetValue(7)

            End If
            con.Close() 'Closing The connection
        Catch ex As Exception
            MetroMessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'S6 Reading
        Try
            con.ConnectionString = dbProvider & dbSource
            If Not con.State = ConnectionState.Open Then
                'Opening Connection
                con.Open()
            End If
            sql1 = "SELECT Inter_Sub1,Inter_Sub2,Inter_Sub3,Inter_Sub4,Inter_Sub5,Inter_Sub6,Inter_Lab1,Inter_Lab2 From S6 WHERE Student_ID='" & Admission_NO & "'"
            cmd = New OleDbCommand(sql1)
            cmd.Connection = con
            rdr1 = cmd.ExecuteReader()
            If rdr1.Read Then
                MetroTextBox89.Text = rdr1.GetValue(0)
                MetroTextBox85.Text = rdr1.GetValue(1)
                MetroTextBox81.Text = rdr1.GetValue(2)
                MetroTextBox79.Text = rdr1.GetValue(3)
                MetroTextBox77.Text = rdr1.GetValue(4)
                MetroTextBox75.Text = rdr1.GetValue(5)
                MetroTextBox88.Text = rdr1.GetValue(6)
                MetroTextBox83.Text = rdr1.GetValue(7)

            End If
            con.Close() 'Closing The connection
        Catch ex As Exception
            MetroMessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'S7 Reading
        Try
            con.ConnectionString = dbProvider & dbSource
            If Not con.State = ConnectionState.Open Then
                'Opening Connection
                con.Open()
            End If
            sql1 = "SELECT Inter_Sub1,Inter_Sub2,Inter_Sub3,Inter_Sub4,Inter_Sub5,Inter_Sub6,Inter_Lab1,Inter_Lab2 From S7 WHERE Student_ID='" & Admission_NO & "'"
            cmd = New OleDbCommand(sql1)
            cmd.Connection = con
            rdr1 = cmd.ExecuteReader()
            If rdr1.Read Then
                MetroTextBox105.Text = rdr1.GetValue(0)
                MetroTextBox101.Text = rdr1.GetValue(1)
                MetroTextBox97.Text = rdr1.GetValue(2)
                MetroTextBox95.Text = rdr1.GetValue(3)
                MetroTextBox93.Text = rdr1.GetValue(4)
                MetroTextBox91.Text = rdr1.GetValue(5)
                MetroTextBox104.Text = rdr1.GetValue(6)
                MetroTextBox99.Text = rdr1.GetValue(7)
            End If
            con.Close() 'Closing The connection
        Catch ex As Exception
            MetroMessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        'S7=8 Reading
        Try
            con.ConnectionString = dbProvider & dbSource
            If Not con.State = ConnectionState.Open Then
                'Opening Connection
                con.Open()
            End If
            sql1 = "SELECT Inter_Sub1,Inter_Sub2,Inter_Sub3,Inter_Sub4,Inter_Lab1,Inter_Lab2 From S8 WHERE Student_ID='" & Admission_NO & "'"
            cmd = New OleDbCommand(sql1)
            cmd.Connection = con
            rdr1 = cmd.ExecuteReader()
            If rdr1.Read Then
                MetroTextBox121.Text = rdr1.GetValue(0)
                MetroTextBox117.Text = rdr1.GetValue(1)
                MetroTextBox113.Text = rdr1.GetValue(2)
                MetroTextBox111.Text = rdr1.GetValue(3)
                MetroTextBox109.Text = rdr1.GetValue(4)
                MetroTextBox107.Text = rdr1.GetValue(5)
            End If
            con.Close() 'Closing The connection
        Catch ex As Exception
            MetroMessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub MetroButton4_Click(sender As Object, e As EventArgs) Handles MetroButton4.Click
        'Y1 Add Button
        RecordCount = 0
        Try
            con.ConnectionString = dbProvider & dbSource
            If Not con.State = ConnectionState.Open Then
                'Opening Connection
                con.Open()
            End If
            sql1 = "UPDATE Y1 SET [Inter_Sub1]=" & Convert.ToInt32(MetroTextBox1.Text) & ",[Inter_Sub2]=" & Convert.ToInt32(MetroTextBox2.Text) & ",[Inter_Sub3]=" & Convert.ToInt32(MetroTextBox3.Text) & ",[Inter_Sub4]=" & Convert.ToInt32(MetroTextBox4.Text) & ",[Inter_Sub5]=" & Convert.ToInt32(MetroTextBox5.Text) & ",[Inter_Sub6]=" & Convert.ToInt32(MetroTextBox6.Text) & ",[Inter_Sub7]=" & Convert.ToInt32(MetroTextBox7.Text) & ",[Inter_Sub8]=" & Convert.ToInt32(MetroTextBox8.Text) & ",[Inter_Sub9]=" & Convert.ToInt32(MetroTextBox9.Text) & ",[Inter_Lab1]=" & Convert.ToInt32(MetroTextBox10.Text) & ",[Inter_Lab2]=" & Convert.ToInt32(MetroTextBox11.Text) & ",[Inter_Lab3]=" & Convert.ToInt32(MetroTextBox12.Text) & " " &
            "WHERE Student_ID='" & Admission_NO & "'"
            cmd = New OleDbCommand(sql1)
            cmd.Connection = con
            RecordCount = cmd.ExecuteNonQuery()

            If RecordCount > 0 Then
                MetroMessageBox.Show(Me, "Student Marks Saved Successfully....", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MetroMessageBox.Show(Me, "Error Saving the Marks.....", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            con.Close() 'Closing The connection
        Catch ex As Exception
            MetroMessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        MetroTabControl1.SelectTab(2)
    End Sub

    Private Sub MetroButton5_Click(sender As Object, e As EventArgs) Handles MetroButton5.Click
        'S3 Add Button
        RecordCount = 0
        Try
            con.ConnectionString = dbProvider & dbSource
            If Not con.State = ConnectionState.Open Then
                'Opening Connection
                con.Open()
            End If
            sql1 = "UPDATE S3 SET [Inter_Sub1]=" & Convert.ToInt32(MetroTextBox31.Text) & ",[Inter_Sub2]=" & Convert.ToInt32(MetroTextBox30.Text) & ",[Inter_Sub3]=" & Convert.ToInt32(MetroTextBox29.Text) & ",[Inter_Sub4]=" & Convert.ToInt32(MetroTextBox28.Text) & ",[Inter_Sub5]=" & Convert.ToInt32(MetroTextBox27.Text) & ",[Inter_Sub6]=" & Convert.ToInt32(MetroTextBox25.Text) & ",[Inter_Lab1]=" & Convert.ToInt32(MetroTextBox32.Text) & ",[Inter_Lab2]=" & Convert.ToInt32(MetroTextBox33.Text) & " " &
                "WHERE Student_ID='" & Admission_NO & "'"
            cmd = New OleDbCommand(sql1)
            cmd.Connection = con
            RecordCount = cmd.ExecuteNonQuery()

            If RecordCount > 0 Then
                MetroMessageBox.Show(Me, "Student Marks Saved Successfully....", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MetroMessageBox.Show(Me, "Error Saving the Marks.....", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            con.Close() 'Closing The connection
        Catch ex As Exception
            MetroMessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        MetroTabControl1.SelectTab(3)
    End Sub

    Private Sub MetroButton6_Click(sender As Object, e As EventArgs) Handles MetroButton6.Click
        'S4 Add Button
        RecordCount = 0
        Try
            con.ConnectionString = dbProvider & dbSource
            If Not con.State = ConnectionState.Open Then
                'Opening Connection
                con.Open()
            End If
            sql1 = "UPDATE S4 SET [Inter_Sub1]=" & Convert.ToInt32(MetroTextBox57.Text) & ",[Inter_Sub2]=" & Convert.ToInt32(MetroTextBox53.Text) & ",[Inter_Sub3]=" & Convert.ToInt32(MetroTextBox49.Text) & ",[Inter_Sub4]=" & Convert.ToInt32(MetroTextBox47.Text) & ",[Inter_Sub5]=" & Convert.ToInt32(MetroTextBox45.Text) & ",[Inter_Sub6]=" & Convert.ToInt32(MetroTextBox43.Text) & ",[Inter_Lab1]=" & Convert.ToInt32(MetroTextBox56.Text) & ",[Inter_Lab2]=" & Convert.ToInt32(MetroTextBox51.Text) & " " &
                "WHERE Student_ID='" & Admission_NO & "'"
            cmd = New OleDbCommand(sql1)
            cmd.Connection = con
            RecordCount = cmd.ExecuteNonQuery()

            If RecordCount > 0 Then
                MetroMessageBox.Show(Me, "Student Marks Saved Successfully....", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MetroMessageBox.Show(Me, "Error Saving the Marks.....", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            con.Close() 'Closing The connection
        Catch ex As Exception
            MetroMessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        MetroTabControl1.SelectTab(4)
    End Sub

    Private Sub MetroButton7_Click(sender As Object, e As EventArgs) Handles MetroButton7.Click
        'S5 Add Button
        RecordCount = 0
        Try
            con.ConnectionString = dbProvider & dbSource
            If Not con.State = ConnectionState.Open Then
                'Opening Connection
                con.Open()
            End If
            sql1 = "UPDATE S5 SET [Inter_Sub1]=" & Convert.ToInt32(MetroTextBox73.Text) & ",[Inter_Sub2]=" & Convert.ToInt32(MetroTextBox69.Text) & ",[Inter_Sub3]=" & Convert.ToInt32(MetroTextBox65.Text) & ",[Inter_Sub4]=" & Convert.ToInt32(MetroTextBox63.Text) & ",[Inter_Sub5]=" & Convert.ToInt32(MetroTextBox61.Text) & ",[Inter_Sub6]=" & Convert.ToInt32(MetroTextBox59.Text) & ",[Inter_Lab1]=" & Convert.ToInt32(MetroTextBox72.Text) & ",[Inter_Lab2]=" & Convert.ToInt32(MetroTextBox67.Text) & " " &
                   "WHERE Student_ID='" & Admission_NO & "'"
            cmd = New OleDbCommand(sql1)
            cmd.Connection = con
            RecordCount = cmd.ExecuteNonQuery()

            If RecordCount > 0 Then
                MetroMessageBox.Show(Me, "Student Marks Saved Successfully....", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MetroMessageBox.Show(Me, "Error Saving the Marks.....", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            con.Close() 'Closing The connection
        Catch ex As Exception
            MetroMessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        MetroTabControl1.SelectTab(5)

    End Sub

    Private Sub MetroButton8_Click(sender As Object, e As EventArgs) Handles MetroButton8.Click
        'S6 Add Button
        RecordCount = 0
        Try
            con.ConnectionString = dbProvider & dbSource
            If Not con.State = ConnectionState.Open Then
                'Opening Connection
                con.Open()
            End If
            sql1 = "UPDATE S6 SET [Inter_Sub1]=" & Convert.ToInt32(MetroTextBox89.Text) & ",[Inter_Sub2]=" & Convert.ToInt32(MetroTextBox85.Text) & ",[Inter_Sub3]=" & Convert.ToInt32(MetroTextBox81.Text) & ",[Inter_Sub4]=" & Convert.ToInt32(MetroTextBox79.Text) & ",[Inter_Sub5]=" & Convert.ToInt32(MetroTextBox77.Text) & ",[Inter_Sub6]=" & Convert.ToInt32(MetroTextBox75.Text) & ",[Inter_Lab1]=" & Convert.ToInt32(MetroTextBox88.Text) & ",[Inter_Lab2]=" & Convert.ToInt32(MetroTextBox83.Text) & " " &
                   "WHERE Student_ID='" & Admission_NO & "'"
            cmd = New OleDbCommand(sql1)
            cmd.Connection = con
            RecordCount = cmd.ExecuteNonQuery()

            If RecordCount > 0 Then
                MetroMessageBox.Show(Me, "Student Marks Saved Successfully....", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MetroMessageBox.Show(Me, "Error Saving the Marks.....", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            con.Close() 'Closing The connection
        Catch ex As Exception
            MetroMessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        MetroTabControl1.SelectTab(6)

    End Sub

    Private Sub MetroButton9_Click(sender As Object, e As EventArgs) Handles MetroButton9.Click
        'S7 Add Button
        RecordCount = 0
        Try
            con.ConnectionString = dbProvider & dbSource
            If Not con.State = ConnectionState.Open Then
                'Opening Connection
                con.Open()
            End If
            sql1 = "UPDATE S7 SET [Inter_Sub1]=" & Convert.ToInt32(MetroTextBox105.Text) & ",[Inter_Sub2]=" & Convert.ToInt32(MetroTextBox101.Text) & ",[Inter_Sub3]=" & Convert.ToInt32(MetroTextBox97.Text) & ",[Inter_Sub4]=" & Convert.ToInt32(MetroTextBox95.Text) & ",[Inter_Sub5]=" & Convert.ToInt32(MetroTextBox93.Text) & ",[Inter_Sub6]=" & Convert.ToInt32(MetroTextBox91.Text) & ",[Inter_Lab1]=" & Convert.ToInt32(MetroTextBox104.Text) & ",[Inter_Lab2]=" & Convert.ToInt32(MetroTextBox99.Text) & " " &
                "WHERE Student_ID='" & Admission_NO & "'"
            cmd = New OleDbCommand(sql1)
            cmd.Connection = con
            RecordCount = cmd.ExecuteNonQuery()

            If RecordCount > 0 Then
                MetroMessageBox.Show(Me, "Student Marks Saved Successfully....", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MetroMessageBox.Show(Me, "Error Saving the Marks.....", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            con.Close() 'Closing The connection
        Catch ex As Exception
            MetroMessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        MetroTabControl1.SelectTab(7)
    End Sub

    Private Sub MetroButton10_Click(sender As Object, e As EventArgs) Handles MetroButton10.Click
        'S8 Add Button
        RecordCount = 0
        Try
            con.ConnectionString = dbProvider & dbSource
            If Not con.State = ConnectionState.Open Then
                'Opening Connection
                con.Open()
            End If
            sql1 = "UPDATE S8 SET [Inter_Sub1]=" & Convert.ToInt32(MetroTextBox121.Text) & ",[Inter_Sub2]=" & Convert.ToInt32(MetroTextBox117.Text) & ",[Inter_Sub3]=" & Convert.ToInt32(MetroTextBox113.Text) & ",[Inter_Sub4]=" & Convert.ToInt32(MetroTextBox111.Text) & ",[Inter_Lab1]=" & Convert.ToInt32(MetroTextBox109.Text) & ",[Inter_Lab2]=" & Convert.ToInt32(MetroTextBox107.Text) & " " &
                "WHERE Student_ID='" & Admission_NO & "'"
            cmd = New OleDbCommand(sql1)
            cmd.Connection = con
            RecordCount = cmd.ExecuteNonQuery()

            If RecordCount > 0 Then
                MetroMessageBox.Show(Me, "Student Marks Saved Successfully....", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MetroMessageBox.Show(Me, "Error Saving the Marks.....", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            con.Close() 'Closing The connection
        Catch ex As Exception
            MetroMessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class