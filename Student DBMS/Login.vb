
Imports MetroFramework

Public Class Login

    Dim con As New OleDb.OleDbConnection                                        'THE CONNECTION OBJECT
    Dim dbProvider = "PROVIDER=Microsoft.ACE.OLEDB.12.0;"                       'PROVIDER STRING
    Dim cmd As OleDb.OleDbCommand = Nothing                                     'COMMAND OBJECT
    Dim FullDataPath As String = Application.StartupPath & "\Student.accdb"     'DATABASE LOCATION
    Dim dbSource As String = "Data Source = " & FullDataPath                    'COMPLETE SOURCE STRING
    Dim update As Boolean                                                       'RETURN VALUE OF DATABASE UPDATE
    Dim sql As String                                                           'SQL STRING
    Dim rdr As OleDb.OleDbDataReader = Nothing                                  'DATABASE READER
    Public Shared shareUserName As String
    Dim status As Boolean


    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        'Login Button

        Try
            If MetroTextBox1.Text = Nothing Or MetroTextBox2.Text = Nothing Then
                MetroMessageBox.Show(Me, "Enter Username And Password...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            'Connecting string
            con.ConnectionString = dbProvider & dbSource
            If Not con.State = ConnectionState.Open Then
                'Opening Connection
                con.Open()
            End If

            sql = "Select * From [Accounts] where [User_Name]='" & MetroTextBox1.Text & "' AND [Password]='" & MetroTextBox2.Text & "'"
            'Database Selection command

            cmd = New OleDb.OleDbCommand(sql)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()

            update = rdr.Read() 'Database Reading Command
            If update = True Then
                shareUserName = rdr.GetValue(4) 'Geting User Name
                status = rdr.GetValue(10) 'Getting Account Status
            End If

            con.Close() 'Closing The connection

        Catch ex As Exception
            MetroMessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        If Not (shareUserName = MetroTextBox1.Text And status = True) Then
            MetroLabel3.Visible = True
            MetroLink1.Visible = True
            MetroMessageBox.Show(Me, "Invalid User Name and Password", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If

        Admin_Control_Panel.Show()
        Me.Close()

    End Sub

    Private Sub MetroButton2_Click(sender As Object, e As EventArgs) Handles MetroButton2.Click
        'Exit Button
        Home.Show()
        Close()

    End Sub

    Private Sub MetroLink1_Click(sender As Object, e As EventArgs) Handles MetroLink1.Click
        'Forgot Password
        Forgot_Password.Show()
        Close()

    End Sub

    Private Sub MetroLink2_Click(sender As Object, e As EventArgs) Handles MetroLink2.Click
        MetroMessageBox.Show(Me, "Contact Other Administators For Further Help", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub Login_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        MetroTextBox1.Text = ""
        MetroTextBox2.Text = ""
    End Sub
End Class