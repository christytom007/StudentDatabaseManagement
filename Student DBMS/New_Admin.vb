
Imports System.Data.OleDb
Imports MetroFramework
Imports System.ComponentModel
Imports System.Text.RegularExpressions

Public Class New_Admin

    Dim con As New OleDbConnection                                        'THE CONNECTION OBJECT
    Dim dbProvider = "PROVIDER=Microsoft.ACE.OLEDB.12.0;"                       'PROVIDER STRING
    Dim cmd As OleDbCommand = Nothing                                     'COMMAND OBJECT
    Dim FullDataPath As String = Application.StartupPath & "\Student.accdb"     'DATABASE LOCATION
    Dim dbSource As String = "Data Source = " & FullDataPath                    'COMPLETE SOURCE STRING
    Dim sql As String                                                           'SQL STRING
    Dim rdr As OleDbDataReader = Nothing                                  'DATABASE READER
    Dim DBDT As New DataTable                                                     'Data Table
    Dim DBDA As OleDbDataAdapter                                          'Data Adapter
    Dim RecordCount As Integer
    Dim Gen As String
    Dim act_Value As Boolean

    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        'Submittting Button

        If MetroTextBox1.Text = Nothing Then
            MetroMessageBox.Show(Me, "Please Enter Name of the Admin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If MetroTextBox2.Text = Nothing Then
            MetroMessageBox.Show(Me, "Please Enter User Name of the Admin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If MetroTextBox3.Text = Nothing Then
            MetroMessageBox.Show(Me, "Please Enter Password of the Admin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If MetroTextBox4.Text = Nothing Then
            MetroMessageBox.Show(Me, "Please Enter Mobile Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If MetroTextBox5.Text = Nothing Then
            MetroMessageBox.Show(Me, "Please Enter Security Answer for the Question", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If MetroComboBox1.Text = Nothing Then
            MetroMessageBox.Show(Me, "Please Select the Dipartment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If MetroComboBox2.Text = Nothing Then
            MetroMessageBox.Show(Me, "Please Select the Security Question", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If MetroTextBox3.Text.Length < 4 Then
            MetroMessageBox.Show(Me, "Password Minimum Length is 4", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            MetroTextBox3.Clear()
            MetroTextBox3.Focus()
            Exit Sub
        End If

        If Not Regex.Match(MetroTextBox4.Text, "^[0-9]*$").Success Then
            MetroMessageBox.Show(Me, "Invalid Mobile Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            MetroTextBox4.Clear()
            MetroTextBox4.Focus()
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

            sql = "Insert into [Accounts] " &
                "([First_Name],[Last_Name],[Gender],[User_Name],[Password],[Mobile_No],[Department],[Secure_Que],[Answers],[Status]) " &
                "Values('" & First_Name & "','" & Last_Name & "','" & Gen & "','" & MetroTextBox2.Text & "','" & MetroTextBox3.Text & "','" & MetroTextBox4.Text & "','" & MetroComboBox2.Text & "','" & MetroComboBox1.Text & "','" & MetroTextBox5.Text & "'," & act_Value & ")"

            cmd = New OleDbCommand(sql)
            cmd.Connection = con
            'Creating Connection
            RecordCount = cmd.ExecuteNonQuery()

            If RecordCount > 0 Then
                MetroMessageBox.Show(Me, "Succesfully Added the new Admin", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Else
                MetroMessageBox.Show(Me, "Unable to Add The Admin into Database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            con.Close() 'Closing The connection

        Catch ex As Exception
            MetroMessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Admin_List.Show()
        Close()

    End Sub

    Private Sub New_Admin_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        MetroTextBox1.Clear()
        MetroTextBox2.Clear()
        MetroTextBox3.Clear()
        MetroTextBox4.Clear()
        MetroTextBox5.Clear()

        MetroTextBox1.Focus()

    End Sub

    Private Sub MetroRadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles MetroRadioButton1.CheckedChanged
        If MetroRadioButton1.Checked = True Then
            Gen = "Male"
        End If
    End Sub

    Private Sub MetroRadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles MetroRadioButton2.CheckedChanged
        If MetroRadioButton2.Checked = True Then
            Gen = "Female"
        End If
    End Sub

    Private Sub MetroCheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles MetroCheckBox1.CheckedChanged
        If MetroCheckBox1.Checked = True Then
            act_Value = -1
        Else
            act_Value = 0
        End If
    End Sub
End Class