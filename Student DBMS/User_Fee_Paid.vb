Imports System.ComponentModel
Imports System.Data.OleDb
Imports System.Text.RegularExpressions
Imports MetroFramework
Imports System.IO
Public Class User_Fee_Paid

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

    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        'Search Button

        Admission_NO = MetroTextBox33.Text
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
            Else
                MetroMessageBox.Show(Me, "Inavlid Admission Number.....", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                con.Close()
                Clear_All()
                Exit Sub
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
        MetroTabControl1.SelectTab(1)

    End Sub

    Private Sub User_Fee_Paid_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        'Closing
        View_Student.Show()
    End Sub
    Sub Clear_All()
        MetroLabel2.Text = ""
        MetroLabel6.Text = ""
        MetroLabel4.Text = ""
        MetroTextBox1.Text = ""
        MetroTextBox2.Text = ""
        MetroTextBox3.Text = ""
        MetroTextBox4.Text = ""
        MetroTextBox5.Text = ""
        MetroTextBox6.Text = ""
        MetroTextBox7.Text = ""
        MetroTextBox8.Text = ""
        MetroTextBox9.Text = ""
        MetroTextBox10.Text = ""
        MetroTextBox11.Text = ""
        MetroTextBox12.Text = ""
        MetroTextBox13.Text = ""
        MetroTextBox14.Text = ""
        MetroTextBox15.Text = ""
        MetroTextBox16.Text = ""
        MetroTextBox17.Text = ""
        MetroTextBox18.Text = ""
        MetroTextBox19.Text = ""
        MetroTextBox20.Text = ""
        MetroTextBox21.Text = ""
        MetroTextBox22.Text = ""
        MetroTextBox23.Text = ""
        MetroTextBox24.Text = ""
        MetroTextBox25.Text = ""
        MetroTextBox26.Text = ""
        MetroTextBox27.Text = ""
        MetroTextBox28.Text = ""
        MetroTextBox29.Text = ""
        MetroTextBox30.Text = ""
        MetroTextBox31.Text = ""
        MetroTextBox32.Text = ""
    End Sub

    Private Sub User_Fee_Paid_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        'Form Loads
        MetroTextBox33.Clear()
    End Sub

End Class