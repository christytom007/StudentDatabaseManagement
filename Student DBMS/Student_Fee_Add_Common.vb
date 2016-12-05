Imports System.ComponentModel
Imports System.Data.OleDb
Imports System.Text.RegularExpressions
Imports MetroFramework
Imports System.IO
Public Class Student_Fee_Add_Common
    Dim con As New OleDbConnection                                              'THE CONNECTION OBJECT
    Dim dbProvider = "PROVIDER=Microsoft.ACE.OLEDB.12.0;"                       'PROVIDER STRING
    Dim cmd As OleDbCommand = Nothing                                           'COMMAND OBJECT
    Dim FullDataPath As String = Application.StartupPath & "\Student.accdb"     'DATABASE LOCATION
    Dim dbSource As String = "Data Source = " & FullDataPath                    'COMPLETE SOURCE STRING
    Dim sql1 As String                                                          'SQL STRING
    Dim sql2 As String                                                          'SQL STRING
    Dim rdr1 As OleDbDataReader = Nothing                                        'DATABASE READER
    Dim rdr2 As OleDbDataReader = Nothing                                        'DATABASE READER
    Dim DBDA As OleDbDataAdapter                                                'Data Adapter
    Dim RecordCount As Integer

    Dim sqlFee1 As String
    Dim sqlFee2 As String
    Dim sqlFee3 As String
    Dim sqlFee4 As String
    Dim sqlFee5 As String


    Dim Admission_NO As String
    Dim Seat_Type As String
    Dim Sem As Integer

    Private Sub Student_Fee_Add_Common_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        'Form Loading

        If Student_Fee_Add.Add_New_From_Fee_Mange = 1 Then
            'Update the value from Student_Fee_Add
            Admission_NO = Student_Fee_Add.Admission_Student_Fee_Add
        Else
            Admission_NO = Student_Existing.Admission_Num
        End If
        RecordCount = 0
        Try
            con.ConnectionString = dbProvider & dbSource
            If Not con.State = ConnectionState.Open Then
                'Opening Connection
                con.Open()
            End If
            sql1 = "SELECT Admission_No, First_Name, Last_Name, Semester,Seat_Type FROM Student WHERE Admission_No='" & Admission_NO & "'"
            cmd = New OleDbCommand(sql1)
            cmd.Connection = con
            'Creating Connection

            rdr1 = cmd.ExecuteReader
            If rdr1.Read() Then
                MetroLabel2.Text = rdr1.GetValue(0) 'Admission No
                MetroLabel6.Text = rdr1.GetValue(1) & " " & rdr1.GetValue(2) 'Name
                Sem = Convert.ToInt32(rdr1.GetValue(3)) 'Sem
                MetroLabel4.Text = rdr1.GetValue(4) 'Seat Type
                Seat_Type = rdr1.GetValue(4)
            End If

            sqlFee1 = "SELECT Y1_Merit, Y1_Manage, Y1_NRI, Y2_Merit, Y2_Manage, Y2_NRI, Y3_Merit, Y3_Manage, Y3_NRI, Y4_Merit, Y4_Manage, Y4_NRI FROM Fee_Structure WHERE Num ='1'"
            sqlFee2 = "SELECT Y1_Merit, Y1_Manage, Y1_NRI, Y2_Merit, Y2_Manage, Y2_NRI, Y3_Merit, Y3_Manage, Y3_NRI, Y4_Merit, Y4_Manage, Y4_NRI FROM Fee_Structure WHERE Num ='2'"
            sqlFee3 = "SELECT Y1_Merit, Y1_Manage, Y1_NRI, Y2_Merit, Y2_Manage, Y2_NRI, Y3_Merit, Y3_Manage, Y3_NRI, Y4_Merit, Y4_Manage, Y4_NRI FROM Fee_Structure WHERE Num ='3'"
            sqlFee4 = "SELECT Y1_Merit, Y1_Manage, Y1_NRI, Y2_Merit, Y2_Manage, Y2_NRI, Y3_Merit, Y3_Manage, Y3_NRI, Y4_Merit, Y4_Manage, Y4_NRI FROM Fee_Structure WHERE Num ='4'"
            sqlFee5 = "SELECT Y1_Merit, Y1_Manage, Y1_NRI, Y2_Merit, Y2_Manage, Y2_NRI, Y3_Merit, Y3_Manage, Y3_NRI, Y4_Merit, Y4_Manage, Y4_NRI FROM Fee_Structure WHERE Num ='5'"

            cmd = New OleDbCommand(sqlFee1)
            cmd.Connection = con
            rdr1 = cmd.ExecuteReader
            If rdr1.Read Then
                If Seat_Type = "Merit" Then
                    MetroTextBox1.Text = rdr1.GetValue(0)
                    MetroTextBox16.Text = rdr1.GetValue(3)
                    MetroTextBox24.Text = rdr1.GetValue(6)
                    MetroTextBox32.Text = rdr1.GetValue(9)
                ElseIf Seat_Type = "Management"
                    MetroTextBox1.Text = rdr1.GetValue(1)
                    MetroTextBox16.Text = rdr1.GetValue(4)
                    MetroTextBox24.Text = rdr1.GetValue(7)
                    MetroTextBox32.Text = rdr1.GetValue(10)
                ElseIf Seat_Type = "NRI"
                    MetroTextBox1.Text = rdr1.GetValue(2)
                    MetroTextBox16.Text = rdr1.GetValue(5)
                    MetroTextBox24.Text = rdr1.GetValue(8)
                    MetroTextBox32.Text = rdr1.GetValue(11)
                End If
            End If
            cmd = New OleDbCommand(sqlFee2)
            cmd.Connection = con
            rdr1 = cmd.ExecuteReader
            If rdr1.Read Then
                If Seat_Type = "Merit" Then
                    MetroTextBox2.Text = rdr1.GetValue(0)
                    MetroTextBox15.Text = rdr1.GetValue(3)
                    MetroTextBox23.Text = rdr1.GetValue(6)
                    MetroTextBox31.Text = rdr1.GetValue(9)
                ElseIf Seat_Type = "Management"
                    MetroTextBox2.Text = rdr1.GetValue(1)
                    MetroTextBox15.Text = rdr1.GetValue(4)
                    MetroTextBox23.Text = rdr1.GetValue(7)
                    MetroTextBox31.Text = rdr1.GetValue(10)
                ElseIf Seat_Type = "NRI"
                    MetroTextBox2.Text = rdr1.GetValue(2)
                    MetroTextBox15.Text = rdr1.GetValue(5)
                    MetroTextBox23.Text = rdr1.GetValue(8)
                    MetroTextBox31.Text = rdr1.GetValue(11)
                End If
            End If
            cmd = New OleDbCommand(sqlFee3)
            cmd.Connection = con
            rdr1 = cmd.ExecuteReader
            If rdr1.Read Then
                If Seat_Type = "Merit" Then
                    MetroTextBox3.Text = rdr1.GetValue(0)
                    MetroTextBox14.Text = rdr1.GetValue(3)
                    MetroTextBox22.Text = rdr1.GetValue(6)
                    MetroTextBox30.Text = rdr1.GetValue(9)
                ElseIf Seat_Type = "Management"
                    MetroTextBox3.Text = rdr1.GetValue(1)
                    MetroTextBox14.Text = rdr1.GetValue(4)
                    MetroTextBox22.Text = rdr1.GetValue(7)
                    MetroTextBox30.Text = rdr1.GetValue(10)
                ElseIf Seat_Type = "NRI"
                    MetroTextBox3.Text = rdr1.GetValue(2)
                    MetroTextBox14.Text = rdr1.GetValue(5)
                    MetroTextBox22.Text = rdr1.GetValue(8)
                    MetroTextBox30.Text = rdr1.GetValue(11)
                End If
            End If
            cmd = New OleDbCommand(sqlFee4)
            cmd.Connection = con
            rdr1 = cmd.ExecuteReader
            If rdr1.Read Then
                If Seat_Type = "Merit" Then
                    MetroTextBox4.Text = rdr1.GetValue(0)
                    MetroTextBox13.Text = rdr1.GetValue(3)
                    MetroTextBox21.Text = rdr1.GetValue(6)
                    MetroTextBox29.Text = rdr1.GetValue(9)
                ElseIf Seat_Type = "Management"
                    MetroTextBox4.Text = rdr1.GetValue(1)
                    MetroTextBox13.Text = rdr1.GetValue(4)
                    MetroTextBox21.Text = rdr1.GetValue(7)
                    MetroTextBox29.Text = rdr1.GetValue(10)
                ElseIf Seat_Type = "NRI"
                    MetroTextBox4.Text = rdr1.GetValue(2)
                    MetroTextBox13.Text = rdr1.GetValue(5)
                    MetroTextBox21.Text = rdr1.GetValue(8)
                    MetroTextBox29.Text = rdr1.GetValue(11)
                End If
            End If
            cmd = New OleDbCommand(sqlFee5)
            cmd.Connection = con
            rdr1 = cmd.ExecuteReader
            If rdr1.Read Then
                If Seat_Type = "Merit" Then
                    MetroTextBox5.Text = rdr1.GetValue(0)
                    MetroTextBox12.Text = rdr1.GetValue(3)
                    MetroTextBox20.Text = rdr1.GetValue(6)
                    MetroTextBox28.Text = rdr1.GetValue(9)
                ElseIf Seat_Type = "Management"
                    MetroTextBox5.Text = rdr1.GetValue(1)
                    MetroTextBox12.Text = rdr1.GetValue(4)
                    MetroTextBox20.Text = rdr1.GetValue(7)
                    MetroTextBox28.Text = rdr1.GetValue(10)
                ElseIf Seat_Type = "NRI"
                    MetroTextBox5.Text = rdr1.GetValue(2)
                    MetroTextBox12.Text = rdr1.GetValue(5)
                    MetroTextBox20.Text = rdr1.GetValue(8)
                    MetroTextBox28.Text = rdr1.GetValue(11)
                End If
            End If
            MetroTextBox6.Text = Convert.ToInt32(MetroTextBox1.Text) + Convert.ToInt32(MetroTextBox2.Text) + Convert.ToInt32(MetroTextBox3.Text) + Convert.ToInt32(MetroTextBox4.Text) + Convert.ToInt32(MetroTextBox5.Text)
            MetroTextBox11.Text = Convert.ToInt32(MetroTextBox16.Text) + Convert.ToInt32(MetroTextBox15.Text) + Convert.ToInt32(MetroTextBox14.Text) + Convert.ToInt32(MetroTextBox13.Text) + Convert.ToInt32(MetroTextBox12.Text)
            MetroTextBox19.Text = Convert.ToInt32(MetroTextBox24.Text) + Convert.ToInt32(MetroTextBox23.Text) + Convert.ToInt32(MetroTextBox22.Text) + Convert.ToInt32(MetroTextBox21.Text) + Convert.ToInt32(MetroTextBox20.Text)
            MetroTextBox27.Text = Convert.ToInt32(MetroTextBox32.Text) + Convert.ToInt32(MetroTextBox31.Text) + Convert.ToInt32(MetroTextBox30.Text) + Convert.ToInt32(MetroTextBox29.Text) + Convert.ToInt32(MetroTextBox28.Text)

            'Featch each record from Fee_Paid table
            sql2 = "SELECT Y1_Paid, Y1_Remaining, Y2_Paid, Y2_Remaining, Y3_Paid, Y3_Remaining, Y4_Paid, Y4_Remaining FROM Fee_Paid WHERE Student_ID ='" & Admission_NO & "'"
            cmd = New OleDbCommand(sql2)
            cmd.Connection = con
            rdr2 = cmd.ExecuteReader
            'Paid And Remaining
            If rdr2.Read Then
                MetroTextBox7.Text = rdr2.GetValue(0)
                MetroTextBox8.Text = Convert.ToInt32(MetroTextBox6.Text) - Convert.ToInt32(MetroTextBox7.Text)
                MetroTextBox10.Text = rdr2.GetValue(2)
                MetroTextBox9.Text = Convert.ToInt32(MetroTextBox11.Text) - Convert.ToInt32(MetroTextBox10.Text)
                MetroTextBox18.Text = rdr2.GetValue(4)
                MetroTextBox17.Text = Convert.ToInt32(MetroTextBox19.Text) - Convert.ToInt32(MetroTextBox18.Text)
                MetroTextBox26.Text = rdr2.GetValue(6)
                MetroTextBox25.Text = Convert.ToInt32(MetroTextBox27.Text) - Convert.ToInt32(MetroTextBox26.Text)
            End If

            con.Close() 'Closing The connection
        Catch ex As Exception
            MetroMessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try


        If Sem = 5 Or Sem = 6 Then
            MetroTabControl1.TabPages(3).Enabled = False
        ElseIf Sem = 3 Or Sem = 4
            MetroTabControl1.TabPages(3).Enabled = False
            MetroTabControl1.TabPages(2).Enabled = False
        ElseIf Sem = 1 Or Sem = 2
            MetroTabControl1.TabPages(3).Enabled = False
            MetroTabControl1.TabPages(2).Enabled = False
            MetroTabControl1.TabPages(1).Enabled = False
        End If
    End Sub

    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        '1st year submit button
        RecordCount = 0
        If MetroTextBox7.Text = Nothing Then
            MetroMessageBox.Show(Me, "Please Enter Payment Amount Befor submission...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox7.Clear()
            MetroTextBox7.Focus()
            Exit Sub
        End If
        If Not Regex.Match(MetroTextBox7.Text, "^[0-9]*$").Success Then
            MetroMessageBox.Show(Me, "Invalid Payment Amount...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox7.Clear()
            MetroTextBox7.Focus()
            Exit Sub
        End If
        If (Convert.ToInt32(MetroTextBox7.Text)) > (Convert.ToInt32(MetroTextBox6.Text)) Then
            MetroMessageBox.Show(Me, "Payment Amount is Larger than Total Amount...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox7.Clear()
            MetroTextBox7.Focus()
            Exit Sub
        End If
        'Updating Remaining
        MetroTextBox8.Text = Convert.ToInt32(MetroTextBox6.Text) - Convert.ToInt32(MetroTextBox7.Text)
        Try
            con.ConnectionString = dbProvider & dbSource
            If Not con.State = ConnectionState.Open Then
                'Opening Connection
                con.Open()
            End If
            sql1 = "UPDATE Fee_Paid SET Y1_Paid='" & Convert.ToInt32(MetroTextBox7.Text) & "', Y1_Remaining='" & Convert.ToInt32(MetroTextBox8.Text) & "', Y1_Date='" & MetroDateTime1.Value.Date & "' WHERE Student_ID ='" & Admission_NO & "'"
            cmd = New OleDbCommand(sql1)
            cmd.Connection = con
            'Creating Connection
            RecordCount = cmd.ExecuteNonQuery()
            con.Close() 'Closing The connection
            If RecordCount > 0 Then
                MetroMessageBox.Show(Me, "Payment Amount Updated Successfully...", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MetroMessageBox.Show(Me, "Unable to Update the payment amount...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MetroMessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Dim status As Integer = MetroMessageBox.Show(Me, "Do you want to continue updating.....", "Confirmation..", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If status = System.Windows.Forms.DialogResult.No Then
            Close()
            Exit Sub
        End If
        MetroTabControl1.SelectTab(1)

    End Sub

    Private Sub MetroButton2_Click(sender As Object, e As EventArgs) Handles MetroButton2.Click
        '2nd year submit button

        RecordCount = 0
        If MetroTextBox10.Text = Nothing Then
            MetroMessageBox.Show(Me, "Please Enter Payment Amount Befor submission...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox10.Clear()
            MetroTextBox10.Focus()
            Exit Sub
        End If
        If Not Regex.Match(MetroTextBox10.Text, "^[0-9]*$").Success Then
            MetroMessageBox.Show(Me, "Invalid Payment Amount...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox10.Clear()
            MetroTextBox10.Focus()
            Exit Sub
        End If
        If (Convert.ToInt32(MetroTextBox10.Text)) > (Convert.ToInt32(MetroTextBox11.Text)) Then
            MetroMessageBox.Show(Me, "Payment Amount is Larger than Total Amount...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox10.Clear()
            MetroTextBox10.Focus()
            Exit Sub
        End If
        'Updating Remaining
        MetroTextBox9.Text = Convert.ToInt32(MetroTextBox11.Text) - Convert.ToInt32(MetroTextBox10.Text)
        Try
            con.ConnectionString = dbProvider & dbSource
            If Not con.State = ConnectionState.Open Then
                'Opening Connection
                con.Open()
            End If
            sql1 = "UPDATE Fee_Paid SET Y2_Paid='" & Convert.ToInt32(MetroTextBox10.Text) & "', Y2_Remaining='" & Convert.ToInt32(MetroTextBox9.Text) & "', Y2_Date='" & MetroDateTime2.Value.Date & "' WHERE Student_ID ='" & Admission_NO & "'"
            cmd = New OleDbCommand(sql1)
            cmd.Connection = con
            'Creating Connection
            RecordCount = cmd.ExecuteNonQuery()
            con.Close() 'Closing The connection
            If RecordCount > 0 Then
                MetroMessageBox.Show(Me, "Payment Amount Updated Successfully...", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MetroMessageBox.Show(Me, "Unable to Update the payment amount...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MetroMessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Dim status As Integer = MetroMessageBox.Show(Me, "Do you want to continue updating.....", "Confirmation..", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If status = System.Windows.Forms.DialogResult.No Then
            Close()
            Exit Sub
        End If
        MetroTabControl1.SelectTab(2)

    End Sub

    Private Sub MetroButton3_Click(sender As Object, e As EventArgs) Handles MetroButton3.Click
        '3rd year submit button

        RecordCount = 0
        If MetroTextBox18.Text = Nothing Then
            MetroMessageBox.Show(Me, "Please Enter Payment Amount Befor submission...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox18.Clear()
            MetroTextBox18.Focus()
            Exit Sub
        End If
        If Not Regex.Match(MetroTextBox18.Text, "^[0-9]*$").Success Then
            MetroMessageBox.Show(Me, "Invalid Payment Amount...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox18.Clear()
            MetroTextBox18.Focus()
            Exit Sub
        End If
        If (Convert.ToInt32(MetroTextBox18.Text)) > (Convert.ToInt32(MetroTextBox19.Text)) Then
            MetroMessageBox.Show(Me, "Payment Amount is Larger than Total Amount...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox18.Clear()
            MetroTextBox18.Focus()
            Exit Sub
        End If
        'Updating Remaining
        MetroTextBox17.Text = Convert.ToInt32(MetroTextBox19.Text) - Convert.ToInt32(MetroTextBox18.Text)
        Try
            con.ConnectionString = dbProvider & dbSource
            If Not con.State = ConnectionState.Open Then
                'Opening Connection
                con.Open()
            End If
            sql1 = "UPDATE Fee_Paid SET Y3_Paid='" & Convert.ToInt32(MetroTextBox18.Text) & "', Y3_Remaining='" & Convert.ToInt32(MetroTextBox17.Text) & "', Y3_Date='" & MetroDateTime3.Value.Date & "' WHERE Student_ID ='" & Admission_NO & "'"
            cmd = New OleDbCommand(sql1)
            cmd.Connection = con
            'Creating Connection
            RecordCount = cmd.ExecuteNonQuery()
            con.Close() 'Closing The connection
            If RecordCount > 0 Then
                MetroMessageBox.Show(Me, "Payment Amount Updated Successfully...", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MetroMessageBox.Show(Me, "Unable to Update the payment amount...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MetroMessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Dim status As Integer = MetroMessageBox.Show(Me, "Do you want to continue updating.....", "Confirmation..", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If status = System.Windows.Forms.DialogResult.No Then
            Close()
            Exit Sub
        End If
        MetroTabControl1.SelectTab(3)

    End Sub

    Private Sub MetroButton4_Click(sender As Object, e As EventArgs) Handles MetroButton4.Click
        '4th year submit button

        RecordCount = 0
        If MetroTextBox26.Text = Nothing Then
            MetroMessageBox.Show(Me, "Please Enter Payment Amount Befor submission...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox26.Clear()
            MetroTextBox26.Focus()
            Exit Sub
        End If
        If Not Regex.Match(MetroTextBox26.Text, "^[0-9]*$").Success Then
            MetroMessageBox.Show(Me, "Invalid Payment Amount...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox26.Clear()
            MetroTextBox26.Focus()
            Exit Sub
        End If
        If (Convert.ToInt32(MetroTextBox26.Text)) > (Convert.ToInt32(MetroTextBox27.Text)) Then
            MetroMessageBox.Show(Me, "Payment Amount is Larger than Total Amount...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox26.Clear()
            MetroTextBox26.Focus()
            Exit Sub
        End If
        'Updating Remaining
        MetroTextBox25.Text = Convert.ToInt32(MetroTextBox27.Text) - Convert.ToInt32(MetroTextBox26.Text)
        Try
            con.ConnectionString = dbProvider & dbSource
            If Not con.State = ConnectionState.Open Then
                'Opening Connection
                con.Open()
            End If
            sql1 = "UPDATE Fee_Paid SET Y4_Paid='" & Convert.ToInt32(MetroTextBox26.Text) & "', Y4_Remaining='" & Convert.ToInt32(MetroTextBox25.Text) & "', Y4_Date='" & MetroDateTime4.Value.Date & "' WHERE Student_ID ='" & Admission_NO & "'"
            cmd = New OleDbCommand(sql1)
            cmd.Connection = con
            'Creating Connection
            RecordCount = cmd.ExecuteNonQuery()
            con.Close() 'Closing The connection
            If RecordCount > 0 Then
                MetroMessageBox.Show(Me, "Payment Amount Updated Successfully...", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MetroMessageBox.Show(Me, "Unable to Update the payment amount...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MetroMessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Dim status As Integer = MetroMessageBox.Show(Me, "Do you want to continue updating.....", "Confirmation..", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If status = System.Windows.Forms.DialogResult.No Then
            Close()
            Exit Sub
        End If
    End Sub

    Private Sub Student_Fee_Add_Common_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        'Closing
        If Student_Fee_Add.Add_New_From_Fee_Mange = 1 Then
            Student_Fee_Add.Show()
        Else
            Student_Modify_Menu.Show()
        End If
    End Sub
End Class