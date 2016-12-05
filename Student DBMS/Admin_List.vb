Imports System.ComponentModel
Imports System.Data.OleDb
Imports System.Text.RegularExpressions
Imports MetroFramework
Public Class Admin_List

    Dim con As New OleDbConnection                                        'THE CONNECTION OBJECT
    Dim dbProvider = "PROVIDER=Microsoft.ACE.OLEDB.12.0;"                       'PROVIDER STRING
    Dim cmd As OleDbCommand = Nothing                                     'COMMAND OBJECT
    Dim FullDataPath As String = Application.StartupPath & "\Student.accdb"     'DATABASE LOCATION
    Dim dbSource As String = "Data Source = " & FullDataPath                    'COMPLETE SOURCE STRING
    Dim sql As String                                                           'SQL STRING
    Dim rdr As OleDbDataReader = Nothing                                  'DATABASE READER
    Dim DBDT As New DataTable                                                     'Data Table
    Dim DBDA As OleDbDataAdapter                                          'Data Adapter
    Dim R As DataRow
    Dim RecordCount As Integer
    Dim USER_Name_Value As String
    Dim act_Value As Integer


    Private Sub Admin_List_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Form Loading
        MetroTextBox1.Text = ""
        MetroTextBox2.Text = ""
        MetroTextBox3.Text = ""
        MetroTextBox1.Focus()

        MetroCheckBox1.Checked = False

        RecordCount = 0
        Try
            con.ConnectionString = dbProvider & dbSource
            If Not con.State = ConnectionState.Open Then
                'Opening Connection
                con.Open()
            End If
            sql = "Select User_ID, First_Name, User_Name, Department, Mobile_No, Status From Accounts"
            'Selection Query

            cmd = New OleDbCommand(sql)
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

    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        'Remove Admin
        If MetroTextBox1.Text = Nothing Then
            MetroMessageBox.Show(Me, "Admin That is Needed to remove is not Selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Dim status As Integer = MetroMessageBox.Show(Me, "Are You Sure to Remove this Admin. This can't be undone!!", "Confirmation..", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
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
            sql = "Delete From [Accounts] Where [User_Name]='" & MetroTextBox2.Text & "'"
            'Database Deletion command

            cmd = New OleDb.OleDbCommand(sql)
            cmd.Connection = con
            RecordCount = cmd.ExecuteNonQuery()

            If RecordCount > 0 Then
                MetroMessageBox.Show(Me, "Succesfully Deleated", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Else
                MetroMessageBox.Show(Me, "Unable to Delete The Admin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        RefreshDataGrid() 'Refreshing DataGrid

    End Sub

    Private Sub MetroButton2_Click(sender As Object, e As EventArgs) Handles MetroButton2.Click
        'Update Details
        Dim int As Boolean

        If MetroTextBox1.Text = Nothing Then
            MetroMessageBox.Show(Me, "Please Enter Name of the Admin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If MetroTextBox2.Text = Nothing Then
            MetroMessageBox.Show(Me, "Please Enter User Name of the Admin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If MetroTextBox3.Text = Nothing Then
            MetroMessageBox.Show(Me, "Please Enter Mobile Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If Not Regex.Match(MetroTextBox3.Text, "^[0-9]*$").Success Or MetroTextBox3.Text.Length <> 10 Then
            MetroMessageBox.Show(Me, "Invalid Mobile Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            MetroTextBox3.Clear()
            MetroTextBox3.Focus()
            Return
        End If

        'Split First Name And Last Name
        Dim Name_Array() As String = Split(MetroTextBox1.Text)
        Dim LastNonEmpty As Integer = -1
        For i As Integer = 0 To Name_Array.Length - 1
            If Name_Array(i) <> "" Then
                LastNonEmpty += 1
                Name_Array(LastNonEmpty) = Name_Array(i)
            End If
        Next
        ReDim Preserve Name_Array(LastNonEmpty)

        Dim First_Name = Name_Array(0)
        Dim Last_Name As String = ""
        If LastNonEmpty > 0 Then
            For i As Integer = 1 To LastNonEmpty
                Last_Name = Last_Name & " " & Name_Array(i)
            Next
        End If

        RecordCount = 0
        Try
            'Form Loading
            con.ConnectionString = dbProvider & dbSource
            If Not con.State = ConnectionState.Open Then
                'Opening Connection
                con.Open()
            End If

            If MetroCheckBox1.Checked = True Then
                int = -1
            Else
                int = 0
            End If

            sql = "UPDATE [Accounts] SET [First_Name]='" & First_Name & "',[Last_Name]='" & Last_Name & "',[User_Name]='" & MetroTextBox2.Text & "',[Mobile_No]='" & MetroTextBox3.Text & "', [Status]=" & int & " WHERE [User_Name]='" & USER_Name_Value & "'"

            'Update Query

            cmd = New OleDbCommand(sql)
            cmd.Connection = con
            'Creating Connection

            RecordCount = cmd.ExecuteNonQuery()

            If RecordCount > 0 Then
                MetroMessageBox.Show(Me, "Succesfully Updated", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Else
                MetroMessageBox.Show(Me, "Unable to Update The Admin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            con.Close() 'Closing The connection

        Catch ex As Exception
            MetroMessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        RefreshDataGrid()

    End Sub

    Private Sub MetroGrid1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles MetroGrid1.CellDoubleClick
        'Cell Selection
        MetroTextBox1.Text = ""
        MetroTextBox2.Text = ""
        MetroTextBox3.Text = ""
        MetroCheckBox1.Checked = False

        If MetroGrid1.CurrentRow.Index < 0 Then
            'Selected Row is 1st Row
            Exit Sub
        End If

        Dim value As Integer = MetroGrid1.CurrentRow.Index
        'Get Value of selected Row

        USER_Name_Value = MetroGrid1.SelectedRows(0).Cells(2).Value.ToString
        'To Get the Admin Name of selected ONE record

        Try
            con.ConnectionString = dbProvider & dbSource
            If Not con.State = ConnectionState.Open Then
                'Opening Connection
                con.Open()
            End If
            sql = "Select * From [Accounts] Where [User_Name]='" & USER_Name_Value & "'"
            cmd = New OleDbCommand(sql)
            cmd.Connection = con
            'Creating Connection)

            rdr = cmd.ExecuteReader()

            If rdr.Read Then
                MetroTextBox1.Text = rdr.GetValue(1) & " " & rdr.GetValue(2)    'Name
                MetroTextBox2.Text = rdr.GetValue(4)    'User Name
                MetroTextBox3.Text = rdr.GetValue(6)    'Mobile_No
                act_Value = rdr.GetValue(10)
            End If
            If act_Value = -1 Then
                MetroCheckBox1.Checked = True
            Else
                MetroCheckBox1.Checked = False
            End If
            con.Close() 'Closing The connection

        Catch ex As Exception
            MetroMessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub RefreshDataGrid()
        'Refreshing DataGrid

        MetroTextBox1.Text = ""
        MetroTextBox2.Text = ""
        MetroTextBox3.Text = ""
        MetroCheckBox1.Checked = False

        DBDT.Clear()                    'Cleaning The Data Table
        MetroGrid1.DataSource = DBDT    'Cleaning DataGrid

        RecordCount = 0
        Try
            'Form Loading
            con.ConnectionString = dbProvider & dbSource
            If Not con.State = ConnectionState.Open Then
                'Opening Connection
                con.Open()
            End If
            sql = "Select User_ID, First_Name, User_Name, Department, Mobile_No, Status From Accounts"
            'Selection Query

            cmd = New OleDbCommand(sql)
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

    Private Sub Admin_List_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        'Closing The Panel
        Admin_Control_Panel.Show()

    End Sub

    Private Sub MetroButton3_Click(sender As Object, e As EventArgs) Handles MetroButton3.Click
        'Add New Admins
        New_Admin.Show()
        Close()

    End Sub

    Private Sub Admin_List_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        RefreshDataGrid()

    End Sub
End Class