Imports System.ComponentModel
Imports MetroFramework

Public Class Change_Password

    Dim con As New OleDb.OleDbConnection
    Dim dbProvider = "PROVIDER=Microsoft.ACE.OLEDB.12.0;"
    Dim cmd As OleDb.OleDbCommand = Nothing
    Dim FullDataPath As String = Application.StartupPath & "\Student.accdb"
    Dim dbSource As String = "Data Source = " & FullDataPath
    Dim updaterow As Integer = 0
    Dim sql As String
    Dim sql2 As String
    Dim rdr As OleDb.OleDbDataReader = Nothing

    Private Sub Change_Password_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Change password
        Dim Current_Password As String
        If Not TextBox2.Text = TextBox3.Text Then
            MetroMessageBox.Show(Me, "Password Does not Match...", "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Try
            'Connecting string
            con.ConnectionString = dbProvider & dbSource
            If Not con.State = ConnectionState.Open Then
                'Opening Connection
                con.Open()
            End If

            sql = "Select * From [Accounts] Where [User_Name]='" & Login.shareUserName & "'"
            'Database read command

            cmd = New OleDb.OleDbCommand(sql)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()

            rdr.Read()
            Current_Password = rdr.GetValue(5)

            If Current_Password = TextBox1.Text Then
                sql2 = "UPDATE [Accounts] SET [Password]='" & TextBox3.Text & "' Where [User_Name]='" & Login.shareUserName & "'"

                cmd = New OleDb.OleDbCommand(sql2)
                cmd.Connection = con
                updaterow = cmd.ExecuteNonQuery()
                If updaterow > 0 Then
                    MetroMessageBox.Show(Me, "Password Changed Succesfully", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Else
                    MetroMessageBox.Show(Me, "Unable to Change Password..", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MetroMessageBox.Show(Me, "Invalid Admin Password..", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            con.Close()

        Catch ex As Exception
            MetroMessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Cancel the changing password
        Close()
    End Sub

    Private Sub Change_Password_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Admin_Control_Panel.Show()
    End Sub
End Class