Imports System.ComponentModel
Imports System.Data.OleDb
Imports System.Text.RegularExpressions
Imports MetroFramework
Public Class Forgot_Password
    Dim con As New OleDbConnection                                        'THE CONNECTION OBJECT
    Dim dbProvider = "PROVIDER=Microsoft.ACE.OLEDB.12.0;"                       'PROVIDER STRING
    Dim cmd As OleDbCommand = Nothing                                     'COMMAND OBJECT
    Dim FullDataPath As String = Application.StartupPath & "\Student.accdb"     'DATABASE LOCATION
    Dim dbSource As String = "Data Source = " & FullDataPath                    'COMPLETE SOURCE STRING
    Dim sql As String                                                           'SQL STRING
    Dim rdr As OleDbDataReader = Nothing                                  'DATABASE READER
    Dim RecordCount As Integer
    Dim Pass As String
    Dim Status As Boolean = False

    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        'Recover the Password
        If MetroTextBox1.Text = Nothing Or MetroTextBox2.Text = Nothing Or MetroTextBox3.Text = Nothing Then
            MetroMessageBox.Show(Me, "Please Enter Details to recover the password..", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        RecordCount = 0
        Try
            con.ConnectionString = dbProvider & dbSource
            If Not con.State = ConnectionState.Open Then
                'Opening Connection
                con.Open()
            End If
            sql = "SELECT User_Name, Password, Mobile_No, Secure_Que, Answers FROM Accounts WHERE User_Name='" & MetroTextBox1.Text & "'"
            'Selection Query

            cmd = New OleDbCommand(sql)
            cmd.Connection = con
            'Creating Connection

            rdr = cmd.ExecuteReader()

            If rdr.Read() Then
                If rdr.GetValue(0) = MetroTextBox1.Text And rdr.GetValue(2) = MetroTextBox2.Text And rdr.GetValue(3) = MetroComboBox1.Text And rdr.GetValue(4) = MetroTextBox3.Text Then
                    MetroMessageBox.Show(Me, "Password : " & rdr.GetValue(1), "Password", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MetroMessageBox.Show(Me, "Inputed Details are not correct..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
            con.Close() 'Closing The connection
        Catch ex As Exception
            MetroMessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Close()
    End Sub

    Private Sub Forgot_Password_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        'Closing Form
        Login.Show()
    End Sub

    Private Sub Forgot_Password_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        'Form Loads
        MetroTextBox1.Clear()
        MetroTextBox2.Clear()
        MetroTextBox3.Clear()
    End Sub
End Class