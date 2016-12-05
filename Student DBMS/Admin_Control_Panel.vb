Imports System.ComponentModel

Public Class Admin_Control_Panel

    Dim con As New OleDb.OleDbConnection                                        'THE CONNECTION OBJECT
    Dim dbProvider = "PROVIDER=Microsoft.ACE.OLEDB.12.0;"                       'PROVIDER STRING
    Dim cmd As OleDb.OleDbCommand = Nothing                                     'COMMAND OBJECT
    Dim FullDataPath As String = Application.StartupPath & "\Student.accdb"     'DATABASE LOCATION
    Dim dbSource As String = "Data Source = " & FullDataPath                    'COMPLETE SOURCE STRING
    Dim update As Boolean                                                   'RETURN VALUE OF DATABASE UPDATE
    Dim sql As String                                                           'SQL STRING
    Dim rdr As OleDb.OleDbDataReader = Nothing                                  'DATABASE READER
    Public Shared Depart As String
    Private Sub Button8_Click(sender As Object, e As EventArgs)
        Login.Show()
        Me.Close()
    End Sub

    Private Sub Admin_Control_Panel_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Form Loads
        Try
            'Connecting string
            con.ConnectionString = dbProvider & dbSource
            If Not con.State = ConnectionState.Open Then
                'Opening Connection
                con.Open()
            End If
            sql = "Select * From [Accounts] Where [User_Name]='" & Login.shareUserName & "'"
            'Database insertion command

            cmd = New OleDb.OleDbCommand(sql)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                Label3.Text = rdr.GetValue(1) & " " & rdr.GetValue(2)
                Label5.Text = rdr.GetValue(6)
                Label9.Text = rdr.GetValue(7)
                Depart = Label9.Text
            End If

            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub MetroTile1_Click(sender As Object, e As EventArgs) Handles MetroTile1.Click
        'Add/Remove/Edit Student
        Student_Modify_Menu.Show()
        Hide()

    End Sub

    Private Sub MetroTile5_Click(sender As Object, e As EventArgs) Handles MetroTile5.Click
        'Student Mark Management
        Mark_Main_Menu.Show()
        Hide()
    End Sub

    Private Sub MetroTile7_Click(sender As Object, e As EventArgs) Handles MetroTile7.Click
        'Admin Management
        Admin_List.Show()
        Hide()

    End Sub

    Private Sub MetroTile8_Click(sender As Object, e As EventArgs) Handles MetroTile8.Click
        'Change Password
        Change_Password.Show()
        Hide()


    End Sub

    Private Sub Button8_Click_1(sender As Object, e As EventArgs) Handles Button8.Click
        'Log Out Button
        Close()

    End Sub

    Private Sub Admin_Control_Panel_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Login.Show()
    End Sub
End Class