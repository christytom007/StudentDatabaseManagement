Imports System.ComponentModel
Imports System.Data.OleDb
Imports System.Text.RegularExpressions
Imports MetroFramework
Imports System.IO

Public Class Mark_Series_Add
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

    Private Sub Mark_Series_Add_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        'Form Closing
        Mark_Main_Menu.Show()
    End Sub

    Private Sub MetroButton4_Click(sender As Object, e As EventArgs) Handles MetroButton4.Click
        'Y1 Add Button

        If Not Regex.Match(MetroTextBox1.Text, "^[0-9]*$").Success Then
            MetroMessageBox.Show(Me, "Invalid Mark Inputed...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox1.Clear()
            MetroTextBox1.Focus()
            Exit Sub
        End If
        If MetroTextBox1.Text = Nothing Or MetroTextBox1.Text > 50 Then
            MetroMessageBox.Show(Me, "Inavlid Mark inputed.....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox1.Focus()
            MetroTextBox1.Clear()
            Exit Sub
        End If
        If Not Regex.Match(MetroTextBox2.Text, "^[0-9]*$").Success Then
            MetroMessageBox.Show(Me, "Invalid Mark Inputed...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox2.Clear()
            MetroTextBox2.Focus()
            Exit Sub
        End If
        If MetroTextBox2.Text = Nothing Or MetroTextBox2.Text > 50 Then
            MetroMessageBox.Show(Me, "Inavlid Mark inputed.....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox2.Focus()
            MetroTextBox2.Clear()
            Exit Sub
        End If
        If Not Regex.Match(MetroTextBox3.Text, "^[0-9]*$").Success Then
            MetroMessageBox.Show(Me, "Invalid Mark Inputed...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox3.Clear()
            MetroTextBox3.Focus()
            Exit Sub
        End If
        If MetroTextBox3.Text = Nothing Or MetroTextBox3.Text > 50 Then
            MetroMessageBox.Show(Me, "Inavlid Mark inputed.....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox3.Focus()
            MetroTextBox3.Clear()
            Exit Sub
        End If
        If Not Regex.Match(MetroTextBox4.Text, "^[0-9]*$").Success Then
            MetroMessageBox.Show(Me, "Invalid Mark Inputed...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox4.Clear()
            MetroTextBox4.Focus()
            Exit Sub
        End If
        If MetroTextBox4.Text = Nothing Or MetroTextBox4.Text > 50 Then
            MetroMessageBox.Show(Me, "Inavlid Mark inputed.....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox4.Focus()
            MetroTextBox4.Clear()
            Exit Sub
        End If
        If Not Regex.Match(MetroTextBox5.Text, "^[0-9]*$").Success Then
            MetroMessageBox.Show(Me, "Invalid Mark Inputed...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox5.Clear()
            MetroTextBox5.Focus()
            Exit Sub
        End If
        If MetroTextBox5.Text = Nothing Or MetroTextBox5.Text > 50 Then
            MetroMessageBox.Show(Me, "Inavlid Mark inputed.....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox5.Focus()
            MetroTextBox5.Clear()
            Exit Sub
        End If
        If Not Regex.Match(MetroTextBox6.Text, "^[0-9]*$").Success Then
            MetroMessageBox.Show(Me, "Invalid Mark Inputed...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox6.Clear()
            MetroTextBox6.Focus()
            Exit Sub
        End If
        If MetroTextBox6.Text = Nothing Or MetroTextBox6.Text > 50 Then
            MetroMessageBox.Show(Me, "Inavlid Mark inputed.....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox6.Focus()
            MetroTextBox6.Clear()
            Exit Sub
        End If
        If Not Regex.Match(MetroTextBox7.Text, "^[0-9]*$").Success Then
            MetroMessageBox.Show(Me, "Invalid Mark Inputed...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox7.Clear()
            MetroTextBox7.Focus()
            Exit Sub
        End If
        If MetroTextBox7.Text = Nothing Or MetroTextBox7.Text > 50 Then
            MetroMessageBox.Show(Me, "Inavlid Mark inputed.....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox7.Focus()
            MetroTextBox7.Clear()
            Exit Sub
        End If
        If Not Regex.Match(MetroTextBox8.Text, "^[0-9]*$").Success Then
            MetroMessageBox.Show(Me, "Invalid Mark Inputed...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox8.Clear()
            MetroTextBox8.Focus()
            Exit Sub
        End If
        If MetroTextBox8.Text = Nothing Or MetroTextBox8.Text > 50 Then
            MetroMessageBox.Show(Me, "Inavlid Mark inputed.....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox8.Focus()
            MetroTextBox8.Clear()
            Exit Sub
        End If
        If Not Regex.Match(MetroTextBox9.Text, "^[0-9]*$").Success Then
            MetroMessageBox.Show(Me, "Invalid Mark Inputed...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox9.Clear()
            MetroTextBox9.Focus()
            Exit Sub
        End If
        If MetroTextBox9.Text = Nothing Or MetroTextBox9.Text > 50 Then
            MetroMessageBox.Show(Me, "Inavlid Mark inputed.....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox9.Focus()
            MetroTextBox9.Clear()
            Exit Sub
        End If
        If Not Regex.Match(MetroTextBox10.Text, "^[0-9]*$").Success Then
            MetroMessageBox.Show(Me, "Invalid Mark Inputed...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox10.Clear()
            MetroTextBox10.Focus()
            Exit Sub
        End If
        If MetroTextBox10.Text = Nothing Or MetroTextBox10.Text > 50 Then
            MetroMessageBox.Show(Me, "Inavlid Mark inputed.....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox10.Focus()
            MetroTextBox10.Clear()
            Exit Sub
        End If
        If Not Regex.Match(MetroTextBox11.Text, "^[0-9]*$").Success Then
            MetroMessageBox.Show(Me, "Invalid Mark Inputed...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox11.Clear()
            MetroTextBox11.Focus()
            Exit Sub
        End If
        If MetroTextBox11.Text = Nothing Or MetroTextBox11.Text > 50 Then
            MetroMessageBox.Show(Me, "Inavlid Mark inputed.....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox11.Focus()
            MetroTextBox11.Clear()
            Exit Sub
        End If
        If Not Regex.Match(MetroTextBox12.Text, "^[0-9]*$").Success Then
            MetroMessageBox.Show(Me, "Invalid Mark Inputed...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox12.Clear()
            MetroTextBox12.Focus()
            Exit Sub
        End If
        If MetroTextBox12.Text = Nothing Or MetroTextBox12.Text > 50 Then
            MetroMessageBox.Show(Me, "Inavlid Mark inputed.....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox12.Focus()
            MetroTextBox12.Clear()
            Exit Sub
        End If
        If Not Regex.Match(MetroTextBox13.Text, "^[0-9]*$").Success Then
            MetroMessageBox.Show(Me, "Invalid Mark Inputed...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox13.Clear()
            MetroTextBox13.Focus()
            Exit Sub
        End If
        If MetroTextBox13.Text = Nothing Or MetroTextBox13.Text > 50 Then
            MetroMessageBox.Show(Me, "Inavlid Mark inputed.....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox13.Focus()
            MetroTextBox13.Clear()
            Exit Sub
        End If
        If Not Regex.Match(MetroTextBox14.Text, "^[0-9]*$").Success Then
            MetroMessageBox.Show(Me, "Invalid Mark Inputed...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox14.Clear()
            MetroTextBox14.Focus()
            Exit Sub
        End If
        If MetroTextBox14.Text = Nothing Or MetroTextBox14.Text > 50 Then
            MetroMessageBox.Show(Me, "Inavlid Mark inputed.....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox14.Focus()
            MetroTextBox14.Clear()
            Exit Sub
        End If
        If Not Regex.Match(MetroTextBox15.Text, "^[0-9]*$").Success Then
            MetroMessageBox.Show(Me, "Invalid Mark Inputed...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox15.Clear()
            MetroTextBox15.Focus()
            Exit Sub
        End If
        If MetroTextBox15.Text = Nothing Or MetroTextBox15.Text > 50 Then
            MetroMessageBox.Show(Me, "Inavlid Mark inputed.....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox15.Focus()
            MetroTextBox15.Clear()
            Exit Sub
        End If
        If Not Regex.Match(MetroTextBox16.Text, "^[0-9]*$").Success Then
            MetroMessageBox.Show(Me, "Invalid Mark Inputed...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox16.Clear()
            MetroTextBox16.Focus()
            Exit Sub
        End If
        If MetroTextBox16.Text = Nothing Or MetroTextBox16.Text > 50 Then
            MetroMessageBox.Show(Me, "Inavlid Mark inputed.....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox16.Focus()
            MetroTextBox16.Clear()
            Exit Sub
        End If
        If Not Regex.Match(MetroTextBox17.Text, "^[0-9]*$").Success Then
            MetroMessageBox.Show(Me, "Invalid Mark Inputed...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox17.Clear()
            MetroTextBox17.Focus()
            Exit Sub
        End If
        If MetroTextBox17.Text = Nothing Or MetroTextBox17.Text > 50 Then
            MetroMessageBox.Show(Me, "Inavlid Mark inputed.....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox17.Focus()
            MetroTextBox17.Clear()
            Exit Sub
        End If
        If Not Regex.Match(MetroTextBox18.Text, "^[0-9]*$").Success Then
            MetroMessageBox.Show(Me, "Invalid Mark Inputed...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox18.Clear()
            MetroTextBox18.Focus()
            Exit Sub
        End If
        If MetroTextBox18.Text = Nothing Or MetroTextBox18.Text > 50 Then
            MetroMessageBox.Show(Me, "Inavlid Mark inputed.....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox18.Focus()
            MetroTextBox18.Clear()
            Exit Sub
        End If
        If Not Regex.Match(MetroTextBox19.Text, "^[0-9]*$").Success Then
            MetroMessageBox.Show(Me, "Invalid Mark Inputed...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox19.Clear()
            MetroTextBox19.Focus()
            Exit Sub
        End If
        If MetroTextBox19.Text = Nothing Or MetroTextBox19.Text > 50 Then
            MetroMessageBox.Show(Me, "Inavlid Mark inputed.....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox19.Focus()
            MetroTextBox19.Clear()
            Exit Sub
        End If
        If Not Regex.Match(MetroTextBox20.Text, "^[0-9]*$").Success Then
            MetroMessageBox.Show(Me, "Invalid Mark Inputed...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox20.Clear()
            MetroTextBox20.Focus()
            Exit Sub
        End If
        If MetroTextBox20.Text = Nothing Or MetroTextBox20.Text > 50 Then
            MetroMessageBox.Show(Me, "Inavlid Mark inputed.....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox20.Focus()
            MetroTextBox20.Clear()
            Exit Sub
        End If
        If Not Regex.Match(MetroTextBox21.Text, "^[0-9]*$").Success Then
            MetroMessageBox.Show(Me, "Invalid Mark Inputed...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox21.Clear()
            MetroTextBox21.Focus()
            Exit Sub
        End If
        If MetroTextBox21.Text = Nothing Or MetroTextBox21.Text > 50 Then
            MetroMessageBox.Show(Me, "Inavlid Mark inputed.....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox21.Focus()
            MetroTextBox21.Clear()
            Exit Sub
        End If
        If Not Regex.Match(MetroTextBox22.Text, "^[0-9]*$").Success Then
            MetroMessageBox.Show(Me, "Invalid Mark Inputed...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox22.Clear()
            MetroTextBox22.Focus()
            Exit Sub
        End If
        If MetroTextBox22.Text = Nothing Or MetroTextBox22.Text > 50 Then
            MetroMessageBox.Show(Me, "Inavlid Mark inputed.....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox22.Focus()
            MetroTextBox22.Clear()
            Exit Sub
        End If
        If Not Regex.Match(MetroTextBox23.Text, "^[0-9]*$").Success Then
            MetroMessageBox.Show(Me, "Invalid Mark Inputed...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox23.Clear()
            MetroTextBox23.Focus()
            Exit Sub
        End If
        If MetroTextBox23.Text = Nothing Or MetroTextBox23.Text > 50 Then
            MetroMessageBox.Show(Me, "Inavlid Mark inputed.....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox23.Focus()
            MetroTextBox23.Clear()
            Exit Sub
        End If
        If Not Regex.Match(MetroTextBox24.Text, "^[0-9]*$").Success Then
            MetroMessageBox.Show(Me, "Invalid Mark Inputed...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox24.Clear()
            MetroTextBox24.Focus()
            Exit Sub
        End If
        If MetroTextBox24.Text = Nothing Or MetroTextBox24.Text > 50 Then
            MetroMessageBox.Show(Me, "Inavlid Mark inputed.....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox24.Focus()
            MetroTextBox24.Clear()
            Exit Sub
        End If


        RecordCount = 0
        Try
            con.ConnectionString = dbProvider & dbSource
            If Not con.State = ConnectionState.Open Then
                'Opening Connection
                con.Open()
            End If
            sql1 = "UPDATE Y1 SET [Ser1_Sub1]=" & Convert.ToInt32(MetroTextBox1.Text) & ",[Ser1_Sub2]=" & Convert.ToInt32(MetroTextBox2.Text) & ",[Ser1_Sub3]=" & Convert.ToInt32(MetroTextBox3.Text) & ",[Ser1_Sub4]=" & Convert.ToInt32(MetroTextBox4.Text) & ",[Ser1_Sub5]=" & Convert.ToInt32(MetroTextBox5.Text) & ",[Ser1_Sub6]=" & Convert.ToInt32(MetroTextBox6.Text) & ",[Ser1_Sub7]=" & Convert.ToInt32(MetroTextBox7.Text) & ",[Ser1_Sub8]=" & Convert.ToInt32(MetroTextBox8.Text) & ",[Ser1_Sub9]=" & Convert.ToInt32(MetroTextBox9.Text) & ",[Ser1_Lab1]=" & Convert.ToInt32(MetroTextBox10.Text) & ",[Ser1_Lab2]=" & Convert.ToInt32(MetroTextBox11.Text) & ",[Ser1_Lab3]=" & Convert.ToInt32(MetroTextBox12.Text) & "," &
                "[Ser2_Sub1]=" & Convert.ToInt32(MetroTextBox24.Text) & ",[Ser2_Sub2]=" & Convert.ToInt32(MetroTextBox23.Text) & ",[Ser2_Sub3]=" & Convert.ToInt32(MetroTextBox22.Text) & ",[Ser2_Sub4]=" & Convert.ToInt32(MetroTextBox21.Text) & ",[Ser2_Sub5]=" & Convert.ToInt32(MetroTextBox20.Text) & ",[Ser2_Sub6]=" & Convert.ToInt32(MetroTextBox19.Text) & ",[Ser2_Sub7]=" & Convert.ToInt32(MetroTextBox18.Text) & ",[Ser2_Sub8]=" & Convert.ToInt32(MetroTextBox17.Text) & ",[Ser2_Sub9]=" & Convert.ToInt32(MetroTextBox16.Text) & ",[Ser2_Lab1]=" & Convert.ToInt32(MetroTextBox15.Text) & ",[Ser2_Lab2]=" & Convert.ToInt32(MetroTextBox14.Text) & ",[Ser2_Lab3]=" & Convert.ToInt32(MetroTextBox13.Text) & " " &
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

        If Not Regex.Match(MetroTextBox25.Text, "^[0-9]*$").Success Then
            MetroMessageBox.Show(Me, "Invalid Mark Inputed...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox25.Clear()
            MetroTextBox25.Focus()
            Exit Sub
        End If
        If MetroTextBox25.Text = Nothing Or MetroTextBox25.Text > 50 Then
            MetroMessageBox.Show(Me, "Inavlid Mark inputed.....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox25.Focus()
            MetroTextBox25.Clear()
            Exit Sub
        End If
        If Not Regex.Match(MetroTextBox27.Text, "^[0-9]*$").Success Then
            MetroMessageBox.Show(Me, "Invalid Mark Inputed...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox27.Clear()
            MetroTextBox27.Focus()
            Exit Sub
        End If
        If MetroTextBox27.Text = Nothing Or MetroTextBox27.Text > 50 Then
            MetroMessageBox.Show(Me, "Inavlid Mark inputed.....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox27.Focus()
            MetroTextBox27.Clear()
            Exit Sub
        End If
        If Not Regex.Match(MetroTextBox28.Text, "^[0-9]*$").Success Then
            MetroMessageBox.Show(Me, "Invalid Mark Inputed...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox28.Clear()
            MetroTextBox28.Focus()
            Exit Sub
        End If
        If MetroTextBox28.Text = Nothing Or MetroTextBox28.Text > 50 Then
            MetroMessageBox.Show(Me, "Inavlid Mark inputed.....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox28.Focus()
            MetroTextBox28.Clear()
            Exit Sub
        End If
        If Not Regex.Match(MetroTextBox29.Text, "^[0-9]*$").Success Then
            MetroMessageBox.Show(Me, "Invalid Mark Inputed...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox29.Clear()
            MetroTextBox29.Focus()
            Exit Sub
        End If
        If MetroTextBox29.Text = Nothing Or MetroTextBox29.Text > 50 Then
            MetroMessageBox.Show(Me, "Inavlid Mark inputed.....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox29.Focus()
            MetroTextBox29.Clear()
            Exit Sub
        End If
        If Not Regex.Match(MetroTextBox30.Text, "^[0-9]*$").Success Then
            MetroMessageBox.Show(Me, "Invalid Mark Inputed...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox30.Clear()
            MetroTextBox30.Focus()
            Exit Sub
        End If
        If MetroTextBox30.Text = Nothing Or MetroTextBox30.Text > 50 Then
            MetroMessageBox.Show(Me, "Inavlid Mark inputed.....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox30.Focus()
            MetroTextBox30.Clear()
            Exit Sub
        End If
        If Not Regex.Match(MetroTextBox31.Text, "^[0-9]*$").Success Then
            MetroMessageBox.Show(Me, "Invalid Mark Inputed...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox31.Clear()
            MetroTextBox31.Focus()
            Exit Sub
        End If
        If MetroTextBox31.Text = Nothing Or MetroTextBox31.Text > 50 Then
            MetroMessageBox.Show(Me, "Inavlid Mark inputed.....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox31.Focus()
            MetroTextBox31.Clear()
            Exit Sub
        End If
        If Not Regex.Match(MetroTextBox32.Text, "^[0-9]*$").Success Then
            MetroMessageBox.Show(Me, "Invalid Mark Inputed...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox32.Clear()
            MetroTextBox32.Focus()
            Exit Sub
        End If
        If MetroTextBox32.Text = Nothing Or MetroTextBox32.Text > 50 Then
            MetroMessageBox.Show(Me, "Inavlid Mark inputed.....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox32.Focus()
            MetroTextBox32.Clear()
            Exit Sub
        End If
        If Not Regex.Match(MetroTextBox33.Text, "^[0-9]*$").Success Then
            MetroMessageBox.Show(Me, "Invalid Mark Inputed...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox33.Clear()
            MetroTextBox33.Focus()
            Exit Sub
        End If
        If MetroTextBox33.Text = Nothing Or MetroTextBox33.Text > 50 Then
            MetroMessageBox.Show(Me, "Inavlid Mark inputed.....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox33.Focus()
            MetroTextBox33.Clear()
            Exit Sub
        End If
        If Not Regex.Match(MetroTextBox34.Text, "^[0-9]*$").Success Then
            MetroMessageBox.Show(Me, "Invalid Mark Inputed...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox34.Clear()
            MetroTextBox34.Focus()
            Exit Sub
        End If
        If MetroTextBox34.Text = Nothing Or MetroTextBox34.Text > 50 Then
            MetroMessageBox.Show(Me, "Inavlid Mark inputed.....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox34.Focus()
            MetroTextBox34.Clear()
            Exit Sub
        End If
        If Not Regex.Match(MetroTextBox35.Text, "^[0-9]*$").Success Then
            MetroMessageBox.Show(Me, "Invalid Mark Inputed...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox35.Clear()
            MetroTextBox35.Focus()
            Exit Sub
        End If
        If MetroTextBox35.Text = Nothing Or MetroTextBox35.Text > 50 Then
            MetroMessageBox.Show(Me, "Inavlid Mark inputed.....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox35.Focus()
            MetroTextBox35.Clear()
            Exit Sub
        End If
        If Not Regex.Match(MetroTextBox36.Text, "^[0-9]*$").Success Then
            MetroMessageBox.Show(Me, "Invalid Mark Inputed...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox36.Clear()
            MetroTextBox36.Focus()
            Exit Sub
        End If
        If MetroTextBox36.Text = Nothing Or MetroTextBox36.Text > 50 Then
            MetroMessageBox.Show(Me, "Inavlid Mark inputed.....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox36.Focus()
            MetroTextBox36.Clear()
            Exit Sub
        End If
        If Not Regex.Match(MetroTextBox37.Text, "^[0-9]*$").Success Then
            MetroMessageBox.Show(Me, "Invalid Mark Inputed...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox37.Clear()
            MetroTextBox37.Focus()
            Exit Sub
        End If
        If MetroTextBox37.Text = Nothing Or MetroTextBox37.Text > 50 Then
            MetroMessageBox.Show(Me, "Inavlid Mark inputed.....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox37.Focus()
            MetroTextBox37.Clear()
            Exit Sub
        End If
        If Not Regex.Match(MetroTextBox38.Text, "^[0-9]*$").Success Then
            MetroMessageBox.Show(Me, "Invalid Mark Inputed...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox38.Clear()
            MetroTextBox38.Focus()
            Exit Sub
        End If
        If MetroTextBox38.Text = Nothing Or MetroTextBox38.Text > 50 Then
            MetroMessageBox.Show(Me, "Inavlid Mark inputed.....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox38.Focus()
            MetroTextBox38.Clear()
            Exit Sub
        End If
        If Not Regex.Match(MetroTextBox39.Text, "^[0-9]*$").Success Then
            MetroMessageBox.Show(Me, "Invalid Mark Inputed...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox39.Clear()
            MetroTextBox39.Focus()
            Exit Sub
        End If
        If MetroTextBox39.Text = Nothing Or MetroTextBox39.Text > 50 Then
            MetroMessageBox.Show(Me, "Inavlid Mark inputed.....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox39.Focus()
            MetroTextBox39.Clear()
            Exit Sub
        End If
        If Not Regex.Match(MetroTextBox40.Text, "^[0-9]*$").Success Then
            MetroMessageBox.Show(Me, "Invalid Mark Inputed...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox40.Clear()
            MetroTextBox40.Focus()
            Exit Sub
        End If
        If MetroTextBox40.Text = Nothing Or MetroTextBox40.Text > 50 Then
            MetroMessageBox.Show(Me, "Inavlid Mark inputed.....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox40.Focus()
            MetroTextBox40.Clear()
            Exit Sub
        End If
        If Not Regex.Match(MetroTextBox41.Text, "^[0-9]*$").Success Then
            MetroMessageBox.Show(Me, "Invalid Mark Inputed...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox41.Clear()
            MetroTextBox41.Focus()
            Exit Sub
        End If
        If MetroTextBox41.Text = Nothing Or MetroTextBox41.Text > 50 Then
            MetroMessageBox.Show(Me, "Inavlid Mark inputed.....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox41.Focus()
            MetroTextBox41.Clear()
            Exit Sub
        End If



        RecordCount = 0
        Try
            con.ConnectionString = dbProvider & dbSource
            If Not con.State = ConnectionState.Open Then
                'Opening Connection
                con.Open()
            End If
            sql1 = "UPDATE S3 SET [Ser1_Sub1]=" & Convert.ToInt32(MetroTextBox31.Text) & ",[Ser1_Sub2]=" & Convert.ToInt32(MetroTextBox30.Text) & ",[Ser1_Sub3]=" & Convert.ToInt32(MetroTextBox29.Text) & ",[Ser1_Sub4]=" & Convert.ToInt32(MetroTextBox28.Text) & ",[Ser1_Sub5]=" & Convert.ToInt32(MetroTextBox27.Text) & ",[Ser1_Sub6]=" & Convert.ToInt32(MetroTextBox25.Text) & ",[Ser1_Lab1]=" & Convert.ToInt32(MetroTextBox32.Text) & ",[Ser1_Lab2]=" & Convert.ToInt32(MetroTextBox33.Text) & "," &
                "[Ser2_Sub1]=" & Convert.ToInt32(MetroTextBox34.Text) & ",[Ser2_Sub2]=" & Convert.ToInt32(MetroTextBox36.Text) & ",[Ser2_Sub3]=" & Convert.ToInt32(MetroTextBox38.Text) & ",[Ser2_Sub4]=" & Convert.ToInt32(MetroTextBox39.Text) & ",[Ser2_Sub5]=" & Convert.ToInt32(MetroTextBox40.Text) & ",[Ser2_Sub6]=" & Convert.ToInt32(MetroTextBox41.Text) & ",[Ser2_Lab1]=" & Convert.ToInt32(MetroTextBox35.Text) & ",[Ser2_Lab2]=" & Convert.ToInt32(MetroTextBox37.Text) & " " &
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
            sql1 = "UPDATE S4 SET [Ser1_Sub1]=" & Convert.ToInt32(MetroTextBox57.Text) & ",[Ser1_Sub2]=" & Convert.ToInt32(MetroTextBox53.Text) & ",[Ser1_Sub3]=" & Convert.ToInt32(MetroTextBox49.Text) & ",[Ser1_Sub4]=" & Convert.ToInt32(MetroTextBox47.Text) & ",[Ser1_Sub5]=" & Convert.ToInt32(MetroTextBox45.Text) & ",[Ser1_Sub6]=" & Convert.ToInt32(MetroTextBox43.Text) & ",[Ser1_Lab1]=" & Convert.ToInt32(MetroTextBox56.Text) & ",[Ser1_Lab2]=" & Convert.ToInt32(MetroTextBox51.Text) & "," &
                "[Ser2_Sub1]=" & Convert.ToInt32(MetroTextBox55.Text) & ",[Ser2_Sub2]=" & Convert.ToInt32(MetroTextBox52.Text) & ",[Ser2_Sub3]=" & Convert.ToInt32(MetroTextBox48.Text) & ",[Ser2_Sub4]=" & Convert.ToInt32(MetroTextBox46.Text) & ",[Ser2_Sub5]=" & Convert.ToInt32(MetroTextBox44.Text) & ",[Ser2_Sub6]=" & Convert.ToInt32(MetroTextBox42.Text) & ",[Ser2_Lab1]=" & Convert.ToInt32(MetroTextBox54.Text) & ",[Ser2_Lab2]=" & Convert.ToInt32(MetroTextBox50.Text) & " " &
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
            sql1 = "UPDATE S5 SET [Ser1_Sub1]=" & Convert.ToInt32(MetroTextBox73.Text) & ",[Ser1_Sub2]=" & Convert.ToInt32(MetroTextBox69.Text) & ",[Ser1_Sub3]=" & Convert.ToInt32(MetroTextBox65.Text) & ",[Ser1_Sub4]=" & Convert.ToInt32(MetroTextBox63.Text) & ",[Ser1_Sub5]=" & Convert.ToInt32(MetroTextBox61.Text) & ",[Ser1_Sub6]=" & Convert.ToInt32(MetroTextBox59.Text) & ",[Ser1_Lab1]=" & Convert.ToInt32(MetroTextBox72.Text) & ",[Ser1_Lab2]=" & Convert.ToInt32(MetroTextBox67.Text) & "," &
                "[Ser2_Sub1]=" & Convert.ToInt32(MetroTextBox71.Text) & ",[Ser2_Sub2]=" & Convert.ToInt32(MetroTextBox68.Text) & ",[Ser2_Sub3]=" & Convert.ToInt32(MetroTextBox64.Text) & ",[Ser2_Sub4]=" & Convert.ToInt32(MetroTextBox62.Text) & ",[Ser2_Sub5]=" & Convert.ToInt32(MetroTextBox60.Text) & ",[Ser2_Sub6]=" & Convert.ToInt32(MetroTextBox58.Text) & ",[Ser2_Lab1]=" & Convert.ToInt32(MetroTextBox70.Text) & ",[Ser2_Lab2]=" & Convert.ToInt32(MetroTextBox66.Text) & " " &
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
            sql1 = "UPDATE S6 SET [Ser1_Sub1]=" & Convert.ToInt32(MetroTextBox89.Text) & ",[Ser1_Sub2]=" & Convert.ToInt32(MetroTextBox85.Text) & ",[Ser1_Sub3]=" & Convert.ToInt32(MetroTextBox81.Text) & ",[Ser1_Sub4]=" & Convert.ToInt32(MetroTextBox79.Text) & ",[Ser1_Sub5]=" & Convert.ToInt32(MetroTextBox77.Text) & ",[Ser1_Sub6]=" & Convert.ToInt32(MetroTextBox75.Text) & ",[Ser1_Lab1]=" & Convert.ToInt32(MetroTextBox88.Text) & ",[Ser1_Lab2]=" & Convert.ToInt32(MetroTextBox83.Text) & "," &
                "[Ser2_Sub1]=" & Convert.ToInt32(MetroTextBox87.Text) & ",[Ser2_Sub2]=" & Convert.ToInt32(MetroTextBox84.Text) & ",[Ser2_Sub3]=" & Convert.ToInt32(MetroTextBox80.Text) & ",[Ser2_Sub4]=" & Convert.ToInt32(MetroTextBox78.Text) & ",[Ser2_Sub5]=" & Convert.ToInt32(MetroTextBox76.Text) & ",[Ser2_Sub6]=" & Convert.ToInt32(MetroTextBox74.Text) & ",[Ser2_Lab1]=" & Convert.ToInt32(MetroTextBox86.Text) & ",[Ser2_Lab2]=" & Convert.ToInt32(MetroTextBox82.Text) & " " &
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
            sql1 = "UPDATE S7 SET [Ser1_Sub1]=" & Convert.ToInt32(MetroTextBox105.Text) & ",[Ser1_Sub2]=" & Convert.ToInt32(MetroTextBox101.Text) & ",[Ser1_Sub3]=" & Convert.ToInt32(MetroTextBox97.Text) & ",[Ser1_Sub4]=" & Convert.ToInt32(MetroTextBox95.Text) & ",[Ser1_Sub5]=" & Convert.ToInt32(MetroTextBox93.Text) & ",[Ser1_Sub6]=" & Convert.ToInt32(MetroTextBox91.Text) & ",[Ser1_Lab1]=" & Convert.ToInt32(MetroTextBox104.Text) & ",[Ser1_Lab2]=" & Convert.ToInt32(MetroTextBox99.Text) & "," &
                "[Ser2_Sub1]=" & Convert.ToInt32(MetroTextBox103.Text) & ",[Ser2_Sub2]=" & Convert.ToInt32(MetroTextBox100.Text) & ",[Ser2_Sub3]=" & Convert.ToInt32(MetroTextBox96.Text) & ",[Ser2_Sub4]=" & Convert.ToInt32(MetroTextBox94.Text) & ",[Ser2_Sub5]=" & Convert.ToInt32(MetroTextBox92.Text) & ",[Ser2_Sub6]=" & Convert.ToInt32(MetroTextBox90.Text) & ",[Ser2_Lab1]=" & Convert.ToInt32(MetroTextBox102.Text) & ",[Ser2_Lab2]=" & Convert.ToInt32(MetroTextBox98.Text) & " " &
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
            sql1 = "UPDATE S8 SET [Ser1_Sub1]=" & Convert.ToInt32(MetroTextBox121.Text) & ",[Ser1_Sub2]=" & Convert.ToInt32(MetroTextBox117.Text) & ",[Ser1_Sub3]=" & Convert.ToInt32(MetroTextBox113.Text) & ",[Ser1_Sub4]=" & Convert.ToInt32(MetroTextBox111.Text) & ",[Ser1_Lab1]=" & Convert.ToInt32(MetroTextBox109.Text) & ",[Ser1_Lab2]=" & Convert.ToInt32(MetroTextBox107.Text) & "," &
                "[Ser2_Sub1]=" & Convert.ToInt32(MetroTextBox119.Text) & ",[Ser2_Sub2]=" & Convert.ToInt32(MetroTextBox116.Text) & ",[Ser2_Sub3]=" & Convert.ToInt32(MetroTextBox112.Text) & ",[Ser2_Sub4]=" & Convert.ToInt32(MetroTextBox110.Text) & ",[Ser2_Lab1]=" & Convert.ToInt32(MetroTextBox108.Text) & ",[Ser2_Lab2]=" & Convert.ToInt32(MetroTextBox106.Text) & " " &
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

    Private Sub Mark_Series_Add_Shown(sender As Object, e As EventArgs) Handles Me.Shown
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
            MetroLabel6.Text = "Electronics And Communications"
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

    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        'Add Mark Button
        If MetroLabel4.Text = Nothing Then
            MetroMessageBox.Show(Me, "Please Select A Student before Editing....", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        MetroTabControl1.SelectTab(1)

    End Sub
    Private Sub Clear_All_Text()
        MetroTextBox1.Text = 0
        MetroTextBox10.Text = 0
        MetroTextBox100.Text = 0
        MetroTextBox101.Text = 0
        MetroTextBox102.Text = 0
        MetroTextBox103.Text = 0
        MetroTextBox104.Text = 0
        MetroTextBox105.Text = 0
        MetroTextBox106.Text = 0
        MetroTextBox107.Text = 0
        MetroTextBox108.Text = 0
        MetroTextBox109.Text = 0
        MetroTextBox11.Text = 0
        MetroTextBox110.Text = 0
        MetroTextBox111.Text = 0
        MetroTextBox112.Text = 0
        MetroTextBox113.Text = 0
        MetroTextBox116.Text = 0
        MetroTextBox117.Text = 0
        MetroTextBox12.Text = 0
        MetroTextBox119.Text = 0
        MetroTextBox121.Text = 0
        MetroTextBox13.Text = 0
        MetroTextBox14.Text = 0
        MetroTextBox15.Text = 0
        MetroTextBox16.Text = 0
        MetroTextBox17.Text = 0
        MetroTextBox18.Text = 0
        MetroTextBox19.Text = 0
        MetroTextBox2.Text = 0
        MetroTextBox20.Text = 0
        MetroTextBox21.Text = 0
        MetroTextBox22.Text = 0
        MetroTextBox23.Text = 0
        MetroTextBox24.Text = 0
        MetroTextBox25.Text = 0
        MetroTextBox27.Text = 0
        MetroTextBox28.Text = 0
        MetroTextBox29.Text = 0
        MetroTextBox3.Text = 0
        MetroTextBox30.Text = 0
        MetroTextBox31.Text = 0
        MetroTextBox32.Text = 0
        MetroTextBox33.Text = 0
        MetroTextBox34.Text = 0
        MetroTextBox35.Text = 0
        MetroTextBox36.Text = 0
        MetroTextBox37.Text = 0
        MetroTextBox38.Text = 0
        MetroTextBox39.Text = 0
        MetroTextBox4.Text = 0
        MetroTextBox40.Text = 0
        MetroTextBox41.Text = 0
        MetroTextBox42.Text = 0
        MetroTextBox43.Text = 0
        MetroTextBox44.Text = 0
        MetroTextBox45.Text = 0
        MetroTextBox46.Text = 0
        MetroTextBox47.Text = 0
        MetroTextBox48.Text = 0
        MetroTextBox49.Text = 0
        MetroTextBox5.Text = 0
        MetroTextBox50.Text = 0
        MetroTextBox51.Text = 0
        MetroTextBox52.Text = 0
        MetroTextBox53.Text = 0
        MetroTextBox54.Text = 0
        MetroTextBox55.Text = 0
        MetroTextBox56.Text = 0
        MetroTextBox57.Text = 0
        MetroTextBox58.Text = 0
        MetroTextBox59.Text = 0
        MetroTextBox6.Text = 0
        MetroTextBox60.Text = 0
        MetroTextBox61.Text = 0
        MetroTextBox62.Text = 0
        MetroTextBox63.Text = 0
        MetroTextBox64.Text = 0
        MetroTextBox65.Text = 0
        MetroTextBox66.Text = 0
        MetroTextBox67.Text = 0
        MetroTextBox68.Text = 0
        MetroTextBox69.Text = 0
        MetroTextBox69.Text = 0
        MetroTextBox7.Text = 0
        MetroTextBox70.Text = 0
        MetroTextBox71.Text = 0
        MetroTextBox72.Text = 0
        MetroTextBox73.Text = 0
        MetroTextBox74.Text = 0
        MetroTextBox75.Text = 0
        MetroTextBox76.Text = 0
        MetroTextBox77.Text = 0
        MetroTextBox78.Text = 0
        MetroTextBox79.Text = 0
        MetroTextBox8.Text = 0
        MetroTextBox80.Text = 0
        MetroTextBox81.Text = 0
        MetroTextBox82.Text = 0
        MetroTextBox83.Text = 0
        MetroTextBox84.Text = 0
        MetroTextBox85.Text = 0
        MetroTextBox86.Text = 0
        MetroTextBox87.Text = 0
        MetroTextBox88.Text = 0
        MetroTextBox89.Text = 0
        MetroTextBox9.Text = 0
        MetroTextBox90.Text = 0
        MetroTextBox91.Text = 0
        MetroTextBox92.Text = 0
        MetroTextBox93.Text = 0
        MetroTextBox94.Text = 0
        MetroTextBox95.Text = 0
        MetroTextBox96.Text = 0
        MetroTextBox97.Text = 0
        MetroTextBox98.Text = 0
        MetroTextBox99.Text = 0
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
            sql1 = "SELECT Ser1_Sub1,Ser1_Sub2,Ser1_Sub3,Ser1_Sub4,Ser1_Sub5,Ser1_Sub6,Ser1_Sub7,Ser1_Sub8,Ser1_Sub9,Ser1_Lab1,Ser1_Lab2,Ser1_Lab3,Ser2_Sub1,Ser2_Sub2,Ser2_Sub3,Ser2_Sub4,Ser2_Sub5,Ser2_Sub6,Ser2_Sub7,Ser2_Sub8,Ser2_Sub9,Ser2_Lab1,Ser2_Lab2,Ser2_Lab3 From Y1 WHERE Student_ID='" & Admission_NO & "'"
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

                MetroTextBox24.Text = rdr1.GetValue(12)
                MetroTextBox23.Text = rdr1.GetValue(13)
                MetroTextBox22.Text = rdr1.GetValue(14)
                MetroTextBox21.Text = rdr1.GetValue(15)
                MetroTextBox20.Text = rdr1.GetValue(16)
                MetroTextBox19.Text = rdr1.GetValue(17)
                MetroTextBox18.Text = rdr1.GetValue(18)
                MetroTextBox17.Text = rdr1.GetValue(19)
                MetroTextBox16.Text = rdr1.GetValue(20)
                MetroTextBox15.Text = rdr1.GetValue(21)
                MetroTextBox14.Text = rdr1.GetValue(22)
                MetroTextBox13.Text = rdr1.GetValue(23)
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
            sql1 = "SELECT Ser1_Sub1,Ser1_Sub2,Ser1_Sub3,Ser1_Sub4,Ser1_Sub5,Ser1_Sub6,Ser1_Lab1,Ser1_Lab2,Ser2_Sub1,Ser2_Sub2,Ser2_Sub3,Ser2_Sub4,Ser2_Sub5,Ser2_Sub6,Ser2_Lab1,Ser2_Lab2 From S3 WHERE Student_ID='" & Admission_NO & "'"
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

                MetroTextBox34.Text = rdr1.GetValue(8)
                MetroTextBox36.Text = rdr1.GetValue(9)
                MetroTextBox38.Text = rdr1.GetValue(10)
                MetroTextBox39.Text = rdr1.GetValue(11)
                MetroTextBox40.Text = rdr1.GetValue(12)
                MetroTextBox41.Text = rdr1.GetValue(13)
                MetroTextBox35.Text = rdr1.GetValue(14)
                MetroTextBox37.Text = rdr1.GetValue(15)
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
            sql1 = "SELECT Ser1_Sub1,Ser1_Sub2,Ser1_Sub3,Ser1_Sub4,Ser1_Sub5,Ser1_Sub6,Ser1_Lab1,Ser1_Lab2,Ser2_Sub1,Ser2_Sub2,Ser2_Sub3,Ser2_Sub4,Ser2_Sub5,Ser2_Sub6,Ser2_Lab1,Ser2_Lab2 From S4 WHERE Student_ID='" & Admission_NO & "'"
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

                MetroTextBox55.Text = rdr1.GetValue(8)
                MetroTextBox52.Text = rdr1.GetValue(9)
                MetroTextBox48.Text = rdr1.GetValue(10)
                MetroTextBox46.Text = rdr1.GetValue(11)
                MetroTextBox44.Text = rdr1.GetValue(12)
                MetroTextBox42.Text = rdr1.GetValue(13)
                MetroTextBox54.Text = rdr1.GetValue(14)
                MetroTextBox50.Text = rdr1.GetValue(15)
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
            sql1 = "SELECT Ser1_Sub1,Ser1_Sub2,Ser1_Sub3,Ser1_Sub4,Ser1_Sub5,Ser1_Sub6,Ser1_Lab1,Ser1_Lab2,Ser2_Sub1,Ser2_Sub2,Ser2_Sub3,Ser2_Sub4,Ser2_Sub5,Ser2_Sub6,Ser2_Lab1,Ser2_Lab2 From S5 WHERE Student_ID='" & Admission_NO & "'"
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

                MetroTextBox71.Text = rdr1.GetValue(8)
                MetroTextBox68.Text = rdr1.GetValue(9)
                MetroTextBox64.Text = rdr1.GetValue(10)
                MetroTextBox62.Text = rdr1.GetValue(11)
                MetroTextBox60.Text = rdr1.GetValue(12)
                MetroTextBox58.Text = rdr1.GetValue(13)
                MetroTextBox70.Text = rdr1.GetValue(14)
                MetroTextBox66.Text = rdr1.GetValue(15)
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
            sql1 = "SELECT Ser1_Sub1,Ser1_Sub2,Ser1_Sub3,Ser1_Sub4,Ser1_Sub5,Ser1_Sub6,Ser1_Lab1,Ser1_Lab2,Ser2_Sub1,Ser2_Sub2,Ser2_Sub3,Ser2_Sub4,Ser2_Sub5,Ser2_Sub6,Ser2_Lab1,Ser2_Lab2 From S6 WHERE Student_ID='" & Admission_NO & "'"
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

                MetroTextBox87.Text = rdr1.GetValue(8)
                MetroTextBox84.Text = rdr1.GetValue(9)
                MetroTextBox80.Text = rdr1.GetValue(10)
                MetroTextBox78.Text = rdr1.GetValue(11)
                MetroTextBox76.Text = rdr1.GetValue(12)
                MetroTextBox74.Text = rdr1.GetValue(13)
                MetroTextBox86.Text = rdr1.GetValue(14)
                MetroTextBox82.Text = rdr1.GetValue(15)
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
            sql1 = "SELECT Ser1_Sub1,Ser1_Sub2,Ser1_Sub3,Ser1_Sub4,Ser1_Sub5,Ser1_Sub6,Ser1_Lab1,Ser1_Lab2,Ser2_Sub1,Ser2_Sub2,Ser2_Sub3,Ser2_Sub4,Ser2_Sub5,Ser2_Sub6,Ser2_Lab1,Ser2_Lab2 From S7 WHERE Student_ID='" & Admission_NO & "'"
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

                MetroTextBox103.Text = rdr1.GetValue(8)
                MetroTextBox100.Text = rdr1.GetValue(9)
                MetroTextBox96.Text = rdr1.GetValue(10)
                MetroTextBox94.Text = rdr1.GetValue(11)
                MetroTextBox92.Text = rdr1.GetValue(12)
                MetroTextBox90.Text = rdr1.GetValue(13)
                MetroTextBox102.Text = rdr1.GetValue(14)
                MetroTextBox98.Text = rdr1.GetValue(15)
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
            sql1 = "SELECT Ser1_Sub1,Ser1_Sub2,Ser1_Sub3,Ser1_Sub4,Ser1_Lab1,Ser1_Lab2,Ser2_Sub1,Ser2_Sub2,Ser2_Sub3,Ser2_Sub4,Ser2_Lab1,Ser2_Lab2 From S8 WHERE Student_ID='" & Admission_NO & "'"
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

                MetroTextBox119.Text = rdr1.GetValue(6)
                MetroTextBox116.Text = rdr1.GetValue(7)
                MetroTextBox112.Text = rdr1.GetValue(8)
                MetroTextBox110.Text = rdr1.GetValue(9)
                MetroTextBox108.Text = rdr1.GetValue(10)
                MetroTextBox106.Text = rdr1.GetValue(11)
            End If
            con.Close() 'Closing The connection
        Catch ex As Exception
            MetroMessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class