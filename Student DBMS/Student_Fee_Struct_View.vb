Imports System.ComponentModel
Imports System.Data.OleDb
Imports System.Text.RegularExpressions
Imports MetroFramework
Imports System.IO

Public Class Student_Fee_Struct_View

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

    Private Sub Student_Fee_Struct_View_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Student_Fee_Mang_Menu.Show()

    End Sub
End Class