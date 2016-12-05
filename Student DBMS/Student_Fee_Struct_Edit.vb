Imports System.ComponentModel
Imports System.Data.OleDb
Imports System.Text.RegularExpressions
Imports MetroFramework
Imports System.IO
Public Class Student_Fee_Struct_Edit

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
    Dim Seat_Type As String

    Private Sub Student_Fee_Struct_Edit_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        'Form Loaded

    End Sub

    Private Sub MetroComboBox1_TextChanged(sender As Object, e As EventArgs) Handles MetroComboBox1.TextChanged
        'Combobox Selection
        Seat_Type = MetroComboBox1.Text
        RecordCount = 0
        Try
            con.ConnectionString = dbProvider & dbSource
            If Not con.State = ConnectionState.Open Then
                'Opening Connection
                con.Open()
            End If
            sqlFee1 = "SELECT Y1_Merit, Y1_Manage, Y1_NRI, Y2_Merit, Y2_Manage, Y2_NRI, Y3_Merit, Y3_Manage, Y3_NRI, Y4_Merit, Y4_Manage, Y4_NRI, Last_Date FROM Fee_Structure WHERE Num ='1'"
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
                    MetroDateTime1.Value = rdr1.GetValue(12)
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

            con.Close() 'Closing The connection
        Catch ex As Exception
            MetroMessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        '1st Year Submit
        If MetroComboBox1.Text = Nothing Then
            MetroMessageBox.Show(Me, "Please Enter Admission Type Befor submission...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If MetroTextBox1.Text = Nothing Then
            MetroMessageBox.Show(Me, "Please Enter Tuition Fee Befor submission...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox1.Clear()
            MetroTextBox1.Focus()
            Exit Sub
        End If
        If Not Regex.Match(MetroTextBox1.Text, "^[0-9]*$").Success Then
            MetroMessageBox.Show(Me, "Invalid Tuition Fee Amount...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox1.Clear()
            MetroTextBox1.Focus()
            Exit Sub
        End If
        If MetroTextBox2.Text = Nothing Then
            MetroMessageBox.Show(Me, "Please Enter Other Fee Befor submission...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox2.Clear()
            MetroTextBox2.Focus()
            Exit Sub
        End If
        If Not Regex.Match(MetroTextBox2.Text, "^[0-9]*$").Success Then
            MetroMessageBox.Show(Me, "Invalid Other Fee Amount...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox2.Clear()
            MetroTextBox2.Focus()
            Exit Sub
        End If
        If MetroTextBox3.Text = Nothing Then
            MetroMessageBox.Show(Me, "Please Enter PTA Fee Befor submission...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox3.Clear()
            MetroTextBox3.Focus()
            Exit Sub
        End If
        If Not Regex.Match(MetroTextBox3.Text, "^[0-9]*$").Success Then
            MetroMessageBox.Show(Me, "Invalid PTA Fee Amount...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox3.Clear()
            MetroTextBox3.Focus()
            Exit Sub
        End If
        If MetroTextBox4.Text = Nothing Then
            MetroMessageBox.Show(Me, "Please Enter Caution Deposit Befor submission...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox4.Clear()
            MetroTextBox4.Focus()
            Exit Sub
        End If
        If Not Regex.Match(MetroTextBox4.Text, "^[0-9]*$").Success Then
            MetroMessageBox.Show(Me, "Invalid Caution Deposit Amount...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox4.Clear()
            MetroTextBox4.Focus()
            Exit Sub
        End If
        If MetroTextBox5.Text = Nothing Then
            MetroMessageBox.Show(Me, "Please Enter Library Fee Befor submission...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox5.Clear()
            MetroTextBox5.Focus()
            Exit Sub
        End If
        If Not Regex.Match(MetroTextBox5.Text, "^[0-9]*$").Success Then
            MetroMessageBox.Show(Me, "Invalid Library Fee Amount...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox5.Clear()
            MetroTextBox5.Focus()
            Exit Sub
        End If

        MetroTextBox6.Text = Convert.ToInt32(MetroTextBox1.Text) + Convert.ToInt32(MetroTextBox2.Text) + Convert.ToInt32(MetroTextBox3.Text) + Convert.ToInt32(MetroTextBox4.Text) + Convert.ToInt32(MetroTextBox5.Text)

        RecordCount = 0
        Try
            con.ConnectionString = dbProvider & dbSource
            If Not con.State = ConnectionState.Open Then
                'Opening Connection
                con.Open()
            End If
            If Seat_Type = "Merit" Then
                sqlFee1 = "UPDATE Fee_Structure SET Y1_Merit='" & Convert.ToInt32(MetroTextBox1.Text) & "',Last_Date='" & MetroDateTime1.Value.Date & "' WHERE Num ='1'"
                sqlFee2 = "UPDATE Fee_Structure SET Y1_Merit='" & Convert.ToInt32(MetroTextBox2.Text) & "' WHERE Num ='2'"
                sqlFee3 = "UPDATE Fee_Structure SET Y1_Merit='" & Convert.ToInt32(MetroTextBox3.Text) & "' WHERE Num ='3'"
                sqlFee4 = "UPDATE Fee_Structure SET Y1_Merit='" & Convert.ToInt32(MetroTextBox4.Text) & "' WHERE Num ='4'"
                sqlFee5 = "UPDATE Fee_Structure SET Y1_Merit='" & Convert.ToInt32(MetroTextBox5.Text) & "' WHERE Num ='5'"
            ElseIf Seat_Type = "Management"
                sqlFee1 = "UPDATE Fee_Structure SET Y1_Manage='" & Convert.ToInt32(MetroTextBox1.Text) & "',Last_Date='" & MetroDateTime1.Value.Date & "' WHERE Num ='1'"
                sqlFee2 = "UPDATE Fee_Structure SET Y1_Manage='" & Convert.ToInt32(MetroTextBox2.Text) & "' WHERE Num ='2'"
                sqlFee3 = "UPDATE Fee_Structure SET Y1_Manage='" & Convert.ToInt32(MetroTextBox3.Text) & "' WHERE Num ='3'"
                sqlFee4 = "UPDATE Fee_Structure SET Y1_Manage='" & Convert.ToInt32(MetroTextBox4.Text) & "' WHERE Num ='4'"
                sqlFee5 = "UPDATE Fee_Structure SET Y1_Manage='" & Convert.ToInt32(MetroTextBox5.Text) & "' WHERE Num ='5'"
            ElseIf Seat_Type = "NRI"
                sqlFee1 = "UPDATE Fee_Structure SET Y1_NRI='" & Convert.ToInt32(MetroTextBox1.Text) & "',Last_Date='" & MetroDateTime1.Value.Date & "' WHERE Num ='1'"
                sqlFee2 = "UPDATE Fee_Structure SET Y1_NRI='" & Convert.ToInt32(MetroTextBox2.Text) & "' WHERE Num ='2'"
                sqlFee3 = "UPDATE Fee_Structure SET Y1_NRI='" & Convert.ToInt32(MetroTextBox3.Text) & "' WHERE Num ='3'"
                sqlFee4 = "UPDATE Fee_Structure SET Y1_NRI='" & Convert.ToInt32(MetroTextBox4.Text) & "' WHERE Num ='4'"
                sqlFee5 = "UPDATE Fee_Structure SET Y1_NRI='" & Convert.ToInt32(MetroTextBox5.Text) & "' WHERE Num ='5'"
            End If
            cmd = New OleDbCommand(sqlFee1)
            cmd.Connection = con
            RecordCount = cmd.ExecuteNonQuery()
            cmd = New OleDbCommand(sqlFee2)
            cmd.Connection = con
            RecordCount = cmd.ExecuteNonQuery()
            cmd = New OleDbCommand(sqlFee3)
            cmd.Connection = con
            RecordCount = cmd.ExecuteNonQuery()
            cmd = New OleDbCommand(sqlFee4)
            cmd.Connection = con
            RecordCount = cmd.ExecuteNonQuery()
            cmd = New OleDbCommand(sqlFee5)
            cmd.Connection = con
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
    End Sub

    Private Sub MetroButton2_Click(sender As Object, e As EventArgs) Handles MetroButton2.Click
        '2nd Year Submit
        If MetroComboBox1.Text = Nothing Then
            MetroMessageBox.Show(Me, "Please Enter Admission Type Befor submission...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If MetroTextBox16.Text = Nothing Then
            MetroMessageBox.Show(Me, "Please Enter Tuition Fee Befor submission...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox16.Clear()
            MetroTextBox16.Focus()
            Exit Sub
        End If
        If Not Regex.Match(MetroTextBox16.Text, "^[0-9]*$").Success Then
            MetroMessageBox.Show(Me, "Invalid Tuition Fee Amount...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox16.Clear()
            MetroTextBox16.Focus()
            Exit Sub
        End If
        If MetroTextBox15.Text = Nothing Then
            MetroMessageBox.Show(Me, "Please Enter Other Fee Befor submission...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox15.Clear()
            MetroTextBox15.Focus()
            Exit Sub
        End If
        If Not Regex.Match(MetroTextBox15.Text, "^[0-9]*$").Success Then
            MetroMessageBox.Show(Me, "Invalid Other Fee Amount...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox15.Clear()
            MetroTextBox15.Focus()
            Exit Sub
        End If
        If MetroTextBox14.Text = Nothing Then
            MetroMessageBox.Show(Me, "Please Enter PTA Fee Befor submission...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox14.Clear()
            MetroTextBox14.Focus()
            Exit Sub
        End If
        If Not Regex.Match(MetroTextBox14.Text, "^[0-9]*$").Success Then
            MetroMessageBox.Show(Me, "Invalid PTA Fee Amount...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox14.Clear()
            MetroTextBox14.Focus()
            Exit Sub
        End If
        If MetroTextBox13.Text = Nothing Then
            MetroMessageBox.Show(Me, "Please Enter Caution Deposit Befor submission...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox13.Clear()
            MetroTextBox13.Focus()
            Exit Sub
        End If
        If Not Regex.Match(MetroTextBox13.Text, "^[0-9]*$").Success Then
            MetroMessageBox.Show(Me, "Invalid Caution Deposit Amount...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox13.Clear()
            MetroTextBox13.Focus()
            Exit Sub
        End If
        If MetroTextBox12.Text = Nothing Then
            MetroMessageBox.Show(Me, "Please Enter Library Fee Befor submission...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox12.Clear()
            MetroTextBox12.Focus()
            Exit Sub
        End If
        If Not Regex.Match(MetroTextBox12.Text, "^[0-9]*$").Success Then
            MetroMessageBox.Show(Me, "Invalid Library Fee Amount...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox12.Clear()
            MetroTextBox12.Focus()
            Exit Sub
        End If

        MetroTextBox11.Text = Convert.ToInt32(MetroTextBox16.Text) + Convert.ToInt32(MetroTextBox15.Text) + Convert.ToInt32(MetroTextBox14.Text) + Convert.ToInt32(MetroTextBox13.Text) + Convert.ToInt32(MetroTextBox12.Text)

        RecordCount = 0
        Try
            con.ConnectionString = dbProvider & dbSource
            If Not con.State = ConnectionState.Open Then
                'Opening Connection
                con.Open()
            End If
            If Seat_Type = "Merit" Then
                sqlFee1 = "UPDATE Fee_Structure SET Y2_Merit='" & Convert.ToInt32(MetroTextBox16.Text) & "',Last_Date='" & MetroDateTime1.Value.Date & "' WHERE Num ='1'"
                sqlFee2 = "UPDATE Fee_Structure SET Y2_Merit='" & Convert.ToInt32(MetroTextBox15.Text) & "' WHERE Num ='2'"
                sqlFee3 = "UPDATE Fee_Structure SET Y2_Merit='" & Convert.ToInt32(MetroTextBox14.Text) & "' WHERE Num ='3'"
                sqlFee4 = "UPDATE Fee_Structure SET Y2_Merit='" & Convert.ToInt32(MetroTextBox13.Text) & "' WHERE Num ='4'"
                sqlFee5 = "UPDATE Fee_Structure SET Y2_Merit='" & Convert.ToInt32(MetroTextBox12.Text) & "' WHERE Num ='5'"
            ElseIf Seat_Type = "Management"
                sqlFee1 = "UPDATE Fee_Structure SET Y2_Manage='" & Convert.ToInt32(MetroTextBox16.Text) & "',Last_Date='" & MetroDateTime1.Value.Date & "' WHERE Num ='1'"
                sqlFee2 = "UPDATE Fee_Structure SET Y2_Manage='" & Convert.ToInt32(MetroTextBox15.Text) & "' WHERE Num ='2'"
                sqlFee3 = "UPDATE Fee_Structure SET Y2_Manage='" & Convert.ToInt32(MetroTextBox14.Text) & "' WHERE Num ='3'"
                sqlFee4 = "UPDATE Fee_Structure SET Y2_Manage='" & Convert.ToInt32(MetroTextBox13.Text) & "' WHERE Num ='4'"
                sqlFee5 = "UPDATE Fee_Structure SET Y2_Manage='" & Convert.ToInt32(MetroTextBox12.Text) & "' WHERE Num ='5'"
            ElseIf Seat_Type = "NRI"
                sqlFee1 = "UPDATE Fee_Structure SET Y2_NRI='" & Convert.ToInt32(MetroTextBox16.Text) & "',Last_Date='" & MetroDateTime1.Value.Date & "' WHERE Num ='1'"
                sqlFee2 = "UPDATE Fee_Structure SET Y2_NRI='" & Convert.ToInt32(MetroTextBox15.Text) & "' WHERE Num ='2'"
                sqlFee3 = "UPDATE Fee_Structure SET Y2_NRI='" & Convert.ToInt32(MetroTextBox14.Text) & "' WHERE Num ='3'"
                sqlFee4 = "UPDATE Fee_Structure SET Y2_NRI='" & Convert.ToInt32(MetroTextBox13.Text) & "' WHERE Num ='4'"
                sqlFee5 = "UPDATE Fee_Structure SET Y2_NRI='" & Convert.ToInt32(MetroTextBox12.Text) & "' WHERE Num ='5'"
            End If
            cmd = New OleDbCommand(sqlFee1)
            cmd.Connection = con
            RecordCount = cmd.ExecuteNonQuery()
            cmd = New OleDbCommand(sqlFee2)
            cmd.Connection = con
            RecordCount = cmd.ExecuteNonQuery()
            cmd = New OleDbCommand(sqlFee3)
            cmd.Connection = con
            RecordCount = cmd.ExecuteNonQuery()
            cmd = New OleDbCommand(sqlFee4)
            cmd.Connection = con
            RecordCount = cmd.ExecuteNonQuery()
            cmd = New OleDbCommand(sqlFee5)
            cmd.Connection = con
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
    End Sub

    Private Sub MetroButton3_Click(sender As Object, e As EventArgs) Handles MetroButton3.Click
        '3rd Year Submit

        If MetroComboBox1.Text = Nothing Then
            MetroMessageBox.Show(Me, "Please Enter Admission Type Befor submission...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If MetroTextBox24.Text = Nothing Then
            MetroMessageBox.Show(Me, "Please Enter Tuition Fee Befor submission...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox24.Clear()
            MetroTextBox24.Focus()
            Exit Sub
        End If
        If Not Regex.Match(MetroTextBox24.Text, "^[0-9]*$").Success Then
            MetroMessageBox.Show(Me, "Invalid Tuition Fee Amount...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox24.Clear()
            MetroTextBox24.Focus()
            Exit Sub
        End If
        If MetroTextBox23.Text = Nothing Then
            MetroMessageBox.Show(Me, "Please Enter Other Fee Befor submission...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox23.Clear()
            MetroTextBox23.Focus()
            Exit Sub
        End If
        If Not Regex.Match(MetroTextBox23.Text, "^[0-9]*$").Success Then
            MetroMessageBox.Show(Me, "Invalid Other Fee Amount...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox23.Clear()
            MetroTextBox23.Focus()
            Exit Sub
        End If
        If MetroTextBox22.Text = Nothing Then
            MetroMessageBox.Show(Me, "Please Enter PTA Fee Befor submission...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox22.Clear()
            MetroTextBox22.Focus()
            Exit Sub
        End If
        If Not Regex.Match(MetroTextBox22.Text, "^[0-9]*$").Success Then
            MetroMessageBox.Show(Me, "Invalid PTA Fee Amount...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox22.Clear()
            MetroTextBox22.Focus()
            Exit Sub
        End If
        If MetroTextBox21.Text = Nothing Then
            MetroMessageBox.Show(Me, "Please Enter Caution Deposit Befor submission...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox21.Clear()
            MetroTextBox21.Focus()
            Exit Sub
        End If
        If Not Regex.Match(MetroTextBox21.Text, "^[0-9]*$").Success Then
            MetroMessageBox.Show(Me, "Invalid Caution Deposit Amount...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox21.Clear()
            MetroTextBox21.Focus()
            Exit Sub
        End If
        If MetroTextBox20.Text = Nothing Then
            MetroMessageBox.Show(Me, "Please Enter Library Fee Befor submission...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox20.Clear()
            MetroTextBox20.Focus()
            Exit Sub
        End If
        If Not Regex.Match(MetroTextBox20.Text, "^[0-9]*$").Success Then
            MetroMessageBox.Show(Me, "Invalid Library Fee Amount...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox20.Clear()
            MetroTextBox20.Focus()
            Exit Sub
        End If

        MetroTextBox19.Text = Convert.ToInt32(MetroTextBox24.Text) + Convert.ToInt32(MetroTextBox23.Text) + Convert.ToInt32(MetroTextBox22.Text) + Convert.ToInt32(MetroTextBox21.Text) + Convert.ToInt32(MetroTextBox20.Text)

        RecordCount = 0
        Try
            con.ConnectionString = dbProvider & dbSource
            If Not con.State = ConnectionState.Open Then
                'Opening Connection
                con.Open()
            End If
            If Seat_Type = "Merit" Then
                sqlFee1 = "UPDATE Fee_Structure SET Y3_Merit='" & Convert.ToInt32(MetroTextBox24.Text) & "',Last_Date='" & MetroDateTime1.Value.Date & "' WHERE Num ='1'"
                sqlFee2 = "UPDATE Fee_Structure SET Y3_Merit='" & Convert.ToInt32(MetroTextBox23.Text) & "' WHERE Num ='2'"
                sqlFee3 = "UPDATE Fee_Structure SET Y3_Merit='" & Convert.ToInt32(MetroTextBox22.Text) & "' WHERE Num ='3'"
                sqlFee4 = "UPDATE Fee_Structure SET Y3_Merit='" & Convert.ToInt32(MetroTextBox21.Text) & "' WHERE Num ='4'"
                sqlFee5 = "UPDATE Fee_Structure SET Y3_Merit='" & Convert.ToInt32(MetroTextBox20.Text) & "' WHERE Num ='5'"
            ElseIf Seat_Type = "Management"
                sqlFee1 = "UPDATE Fee_Structure SET Y3_Manage='" & Convert.ToInt32(MetroTextBox24.Text) & "',Last_Date='" & MetroDateTime1.Value.Date & "' WHERE Num ='1'"
                sqlFee2 = "UPDATE Fee_Structure SET Y3_Manage='" & Convert.ToInt32(MetroTextBox23.Text) & "' WHERE Num ='2'"
                sqlFee3 = "UPDATE Fee_Structure SET Y3_Manage='" & Convert.ToInt32(MetroTextBox22.Text) & "' WHERE Num ='3'"
                sqlFee4 = "UPDATE Fee_Structure SET Y3_Manage='" & Convert.ToInt32(MetroTextBox21.Text) & "' WHERE Num ='4'"
                sqlFee5 = "UPDATE Fee_Structure SET Y3_Manage='" & Convert.ToInt32(MetroTextBox20.Text) & "' WHERE Num ='5'"
            ElseIf Seat_Type = "NRI"
                sqlFee1 = "UPDATE Fee_Structure SET Y3_NRI='" & Convert.ToInt32(MetroTextBox24.Text) & "',Last_Date='" & MetroDateTime1.Value.Date & "' WHERE Num ='1'"
                sqlFee2 = "UPDATE Fee_Structure SET Y3_NRI='" & Convert.ToInt32(MetroTextBox23.Text) & "' WHERE Num ='2'"
                sqlFee3 = "UPDATE Fee_Structure SET Y3_NRI='" & Convert.ToInt32(MetroTextBox22.Text) & "' WHERE Num ='3'"
                sqlFee4 = "UPDATE Fee_Structure SET Y3_NRI='" & Convert.ToInt32(MetroTextBox21.Text) & "' WHERE Num ='4'"
                sqlFee5 = "UPDATE Fee_Structure SET Y3_NRI='" & Convert.ToInt32(MetroTextBox20.Text) & "' WHERE Num ='5'"
            End If
            cmd = New OleDbCommand(sqlFee1)
            cmd.Connection = con
            RecordCount = cmd.ExecuteNonQuery()
            cmd = New OleDbCommand(sqlFee2)
            cmd.Connection = con
            RecordCount = cmd.ExecuteNonQuery()
            cmd = New OleDbCommand(sqlFee3)
            cmd.Connection = con
            RecordCount = cmd.ExecuteNonQuery()
            cmd = New OleDbCommand(sqlFee4)
            cmd.Connection = con
            RecordCount = cmd.ExecuteNonQuery()
            cmd = New OleDbCommand(sqlFee5)
            cmd.Connection = con
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
    End Sub

    Private Sub MetroButton4_Click(sender As Object, e As EventArgs) Handles MetroButton4.Click
        '4th Year Submit

        If MetroComboBox1.Text = Nothing Then
            MetroMessageBox.Show(Me, "Please Enter Admission Type Befor submission...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If MetroTextBox32.Text = Nothing Then
            MetroMessageBox.Show(Me, "Please Enter Tuition Fee Befor submission...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox32.Clear()
            MetroTextBox32.Focus()
            Exit Sub
        End If
        If Not Regex.Match(MetroTextBox32.Text, "^[0-9]*$").Success Then
            MetroMessageBox.Show(Me, "Invalid Tuition Fee Amount...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox32.Clear()
            MetroTextBox32.Focus()
            Exit Sub
        End If
        If MetroTextBox31.Text = Nothing Then
            MetroMessageBox.Show(Me, "Please Enter Other Fee Befor submission...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox31.Clear()
            MetroTextBox31.Focus()
            Exit Sub
        End If
        If Not Regex.Match(MetroTextBox31.Text, "^[0-9]*$").Success Then
            MetroMessageBox.Show(Me, "Invalid Other Fee Amount...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox31.Clear()
            MetroTextBox31.Focus()
            Exit Sub
        End If
        If MetroTextBox30.Text = Nothing Then
            MetroMessageBox.Show(Me, "Please Enter PTA Fee Befor submission...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox30.Clear()
            MetroTextBox30.Focus()
            Exit Sub
        End If
        If Not Regex.Match(MetroTextBox30.Text, "^[0-9]*$").Success Then
            MetroMessageBox.Show(Me, "Invalid PTA Fee Amount...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox30.Clear()
            MetroTextBox30.Focus()
            Exit Sub
        End If
        If MetroTextBox29.Text = Nothing Then
            MetroMessageBox.Show(Me, "Please Enter Caution Deposit Befor submission...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox29.Clear()
            MetroTextBox29.Focus()
            Exit Sub
        End If
        If Not Regex.Match(MetroTextBox29.Text, "^[0-9]*$").Success Then
            MetroMessageBox.Show(Me, "Invalid Caution Deposit Amount...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox29.Clear()
            MetroTextBox29.Focus()
            Exit Sub
        End If
        If MetroTextBox28.Text = Nothing Then
            MetroMessageBox.Show(Me, "Please Enter Library Fee Befor submission...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox28.Clear()
            MetroTextBox28.Focus()
            Exit Sub
        End If
        If Not Regex.Match(MetroTextBox28.Text, "^[0-9]*$").Success Then
            MetroMessageBox.Show(Me, "Invalid Library Fee Amount...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox28.Clear()
            MetroTextBox28.Focus()
            Exit Sub
        End If

        MetroTextBox27.Text = Convert.ToInt32(MetroTextBox32.Text) + Convert.ToInt32(MetroTextBox31.Text) + Convert.ToInt32(MetroTextBox30.Text) + Convert.ToInt32(MetroTextBox29.Text) + Convert.ToInt32(MetroTextBox28.Text)

        RecordCount = 0
        Try
            con.ConnectionString = dbProvider & dbSource
            If Not con.State = ConnectionState.Open Then
                'Opening Connection
                con.Open()
            End If
            If Seat_Type = "Merit" Then
                sqlFee1 = "UPDATE Fee_Structure SET Y4_Merit='" & Convert.ToInt32(MetroTextBox32.Text) & "',Last_Date='" & MetroDateTime1.Value.Date & "' WHERE Num ='1'"
                sqlFee2 = "UPDATE Fee_Structure SET Y4_Merit='" & Convert.ToInt32(MetroTextBox31.Text) & "' WHERE Num ='2'"
                sqlFee3 = "UPDATE Fee_Structure SET Y4_Merit='" & Convert.ToInt32(MetroTextBox30.Text) & "' WHERE Num ='3'"
                sqlFee4 = "UPDATE Fee_Structure SET Y4_Merit='" & Convert.ToInt32(MetroTextBox29.Text) & "' WHERE Num ='4'"
                sqlFee5 = "UPDATE Fee_Structure SET Y4_Merit='" & Convert.ToInt32(MetroTextBox28.Text) & "' WHERE Num ='5'"
            ElseIf Seat_Type = "Management"
                sqlFee1 = "UPDATE Fee_Structure SET Y4_Manage='" & Convert.ToInt32(MetroTextBox32.Text) & "',Last_Date='" & MetroDateTime1.Value.Date & "' WHERE Num ='1'"
                sqlFee2 = "UPDATE Fee_Structure SET Y4_Manage='" & Convert.ToInt32(MetroTextBox31.Text) & "' WHERE Num ='2'"
                sqlFee3 = "UPDATE Fee_Structure SET Y4_Manage='" & Convert.ToInt32(MetroTextBox30.Text) & "' WHERE Num ='3'"
                sqlFee4 = "UPDATE Fee_Structure SET Y4_Manage='" & Convert.ToInt32(MetroTextBox29.Text) & "' WHERE Num ='4'"
                sqlFee5 = "UPDATE Fee_Structure SET Y4_Manage='" & Convert.ToInt32(MetroTextBox28.Text) & "' WHERE Num ='5'"
            ElseIf Seat_Type = "NRI"
                sqlFee1 = "UPDATE Fee_Structure SET Y4_NRI='" & Convert.ToInt32(MetroTextBox32.Text) & "',Last_Date='" & MetroDateTime1.Value.Date & "' WHERE Num ='1'"
                sqlFee2 = "UPDATE Fee_Structure SET Y4_NRI='" & Convert.ToInt32(MetroTextBox31.Text) & "' WHERE Num ='2'"
                sqlFee3 = "UPDATE Fee_Structure SET Y4_NRI='" & Convert.ToInt32(MetroTextBox30.Text) & "' WHERE Num ='3'"
                sqlFee4 = "UPDATE Fee_Structure SET Y4_NRI='" & Convert.ToInt32(MetroTextBox29.Text) & "' WHERE Num ='4'"
                sqlFee5 = "UPDATE Fee_Structure SET Y4_NRI='" & Convert.ToInt32(MetroTextBox28.Text) & "' WHERE Num ='5'"
            End If
            cmd = New OleDbCommand(sqlFee1)
            cmd.Connection = con
            RecordCount = cmd.ExecuteNonQuery()
            cmd = New OleDbCommand(sqlFee2)
            cmd.Connection = con
            RecordCount = cmd.ExecuteNonQuery()
            cmd = New OleDbCommand(sqlFee3)
            cmd.Connection = con
            RecordCount = cmd.ExecuteNonQuery()
            cmd = New OleDbCommand(sqlFee4)
            cmd.Connection = con
            RecordCount = cmd.ExecuteNonQuery()
            cmd = New OleDbCommand(sqlFee5)
            cmd.Connection = con
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
    End Sub

    Private Sub Student_Fee_Struct_Edit_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Student_Fee_Mang_Menu.Show()
    End Sub
End Class