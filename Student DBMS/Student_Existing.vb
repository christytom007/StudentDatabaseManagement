Imports System.ComponentModel
Imports System.Data.OleDb
Imports System.Text.RegularExpressions
Imports MetroFramework
Imports System.IO
Public Class Student_Existing
    Dim con As New OleDbConnection                                              'THE CONNECTION OBJECT
    Dim dbProvider = "PROVIDER=Microsoft.ACE.OLEDB.12.0;"                       'PROVIDER STRING
    Dim cmd As OleDbCommand = Nothing                                           'COMMAND OBJECT
    Dim FullDataPath As String = Application.StartupPath & "\Student.accdb"     'DATABASE LOCATION
    Dim dbSource As String = "Data Source = " & FullDataPath                    'COMPLETE SOURCE STRING
    Dim sql1 As String                                                           'SQL STRING
    Dim sql2 As String                                                           'SQL STRING
    Dim sql3 As String                                                           'SQL STRING
    Dim sqlFee As String                                                          'SQL STRING
    Dim sqls1 As String                                                           'SQL STRING
    Dim sqls2 As String                                                           'SQL STRING
    Dim sqls3 As String                                                           'SQL STRING
    Dim sqls4 As String                                                           'SQL STRING
    Dim sqls5 As String                                                           'SQL STRING
    Dim sqls6 As String                                                           'SQL STRING
    Dim sqls7 As String                                                           'SQL STRING
    Dim sqls8 As String                                                           'SQL STRING
    Dim sqly1 As String                                                           'SQL STRING
    Dim rdr As OleDbDataReader = Nothing                                        'DATABASE READER
    Dim DBDA As OleDbDataAdapter                                                'Data Adapter
    Dim isFileOpened As Boolean = False
    Dim RecordCount As Integer
    Public Shared Admission_Num As String
    Dim status As Integer = 0
    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        'Attaching Photo

        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            isFileOpened = True
            PictureBox1.BackgroundImage = Image.FromFile(OpenFileDialog1.FileName)
            PictureBox1.BackgroundImageLayout = ImageLayout.Stretch
        End If
    End Sub

    Private Sub Student_New_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        'Cloasing The Form
        If Not status Then
            Student_Modify_Menu.Show()
        End If
    End Sub

    Private Sub Student_New_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        'Form Showing
        'Clear all Text Fields
        MetroTextBox1.Clear()
        MetroTextBox10.Clear()
        MetroTextBox11.Clear()
        MetroTextBox12.Clear()
        MetroTextBox13.Clear()
        MetroTextBox14.Clear()
        MetroTextBox15.Clear()
        MetroTextBox16.Clear()
        MetroTextBox17.Clear()
        MetroTextBox2.Clear()
        MetroTextBox20.Clear()
        MetroTextBox21.Clear()
        MetroTextBox22.Clear()
        MetroTextBox23.Clear()
        MetroTextBox3.Clear()
        MetroTextBox4.Clear()
        MetroTextBox5.Clear()
        MetroTextBox6.Clear()
        MetroTextBox7.Clear()
        MetroTextBox8.Clear()
        MetroTextBox9.Clear()
        MetroTextBox24.Clear()
        MetroTextBox25.Clear()
        MetroTabControl1.Focus()
    End Sub

    Private Sub MetroButton2_Click(sender As Object, e As EventArgs) Handles MetroButton2.Click
        'Next Button of 1st page

        If MetroTextBox1.Text = Nothing Or MetroTextBox2.Text = Nothing Then
            MetroMessageBox.Show(Me, "Student Name is not entired..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox1.Focus()
            Exit Sub
        End If
        If MetroTextBox24.Text = Nothing Then
            MetroMessageBox.Show(Me, "Please Enter Admission Number of the student", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox24.Focus()
            Exit Sub
        End If
        If Not Regex.Match(MetroTextBox24.Text, "^[0-9]*$").Success Then
            MetroMessageBox.Show(Me, "Invalid Admission Number ...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox24.Clear()
            MetroTextBox24.Focus()
            Exit Sub
        End If
        If MetroTextBox24.Text.Length < 4 Then
            MetroMessageBox.Show(Me, "Invalid Admission Number ...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox24.Clear()
            MetroTextBox24.Focus()
            Exit Sub
        End If
        If MetroTextBox25.Text = Nothing Then
            MetroMessageBox.Show(Me, "Please Enter Registor Number of the student", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox25.Focus()
            Exit Sub
        End If
        If Not Regex.Match(MetroTextBox25.Text, "^[0-9]*$").Success Then
            MetroMessageBox.Show(Me, "Invalid Registor Number ...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox25.Clear()
            MetroTextBox25.Focus()
            Exit Sub
        End If
        If MetroTextBox25.Text.Length < 8 Then
            MetroMessageBox.Show(Me, "Invalid Registor Number ...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox25.Clear()
            MetroTextBox25.Focus()
            Exit Sub
        End If
        If MetroComboBox5.Text = Nothing Then
            MetroMessageBox.Show(Me, "Student Currently Studing semester is not selected...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroComboBox5.Focus()
            Exit Sub
        End If
        If MetroComboBox2.Text = Nothing Then
            MetroMessageBox.Show(Me, "Student Admission Type not selected..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroComboBox2.Focus()
            Exit Sub
        End If
        If MetroComboBox3.Text = Nothing Then
            MetroMessageBox.Show(Me, "Student Course not selected..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroComboBox3.Focus()
            Exit Sub
        End If
        If MetroComboBox4.Text = Nothing Then
            MetroMessageBox.Show(Me, "Student Scheme not selected..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroComboBox4.Focus()
            Exit Sub
        End If
        If MetroTextBox11.Text = Nothing Then
            MetroMessageBox.Show(Me, "Please Enter Last Studied School Name..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox11.Focus()
            Exit Sub
        End If
        If MetroTextBox12.Text = Nothing Then
            MetroMessageBox.Show(Me, "Please Enter last studied school address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox12.Focus()
            Exit Sub
        End If
        If MetroTextBox13.Text = Nothing Then
            MetroMessageBox.Show(Me, "Please Enter plus 2 percentage", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox13.Focus()
            Exit Sub
        End If
        If Not Regex.Match(MetroTextBox13.Text, "^[0-9]*$").Success Then
            MetroMessageBox.Show(Me, "Invalid +2 Percentage...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox13.Clear()
            MetroTextBox13.Focus()
            Exit Sub
        End If
        If MetroTextBox13.Text.Length <> 2 Then
            MetroMessageBox.Show(Me, "Invalid +2 Percentage...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox13.Clear()
            MetroTextBox13.Focus()
            Exit Sub
        End If
        If Not isFileOpened Then
            MetroMessageBox.Show(Me, "Please Select Student Photo.....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If MetroTextBox24.Text <> Nothing Then
            'Find Next Addmision Number Already Exists
            Try
                'Form Loading
                con.ConnectionString = dbProvider & dbSource
                If Not con.State = ConnectionState.Open Then
                    'Opening Connection
                    con.Open()
                End If

                Dim sql As String = "SELECT * FROM Student WHERE Admission_No ='" & MetroTextBox24.Text.Trim() & "'"
                'Select Query

                cmd = New OleDbCommand(sql)
                cmd.Connection = con
                'Creating Connection

                rdr = cmd.ExecuteReader()
                rdr.Read()

                If rdr.HasRows Then
                    con.Close() 'Closing The connection
                    MetroTextBox24.Clear()
                    MetroTextBox24.Focus()
                    MetroMessageBox.Show(Me, "The Admission Number Already Exists....", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                con.Close() 'Closing The connection

            Catch ex As Exception
                MetroMessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
        If MetroTextBox25.Text <> Nothing Then
            'Find Next Addmision Number Already Exists
            Try
                'Form Loading
                con.ConnectionString = dbProvider & dbSource
                If Not con.State = ConnectionState.Open Then
                    'Opening Connection
                    con.Open()
                End If

                Dim sql As String = "SELECT * FROM Student WHERE Reg_No ='" & MetroTextBox25.Text.Trim() & "'"
                'Select Query

                cmd = New OleDbCommand(sql)
                cmd.Connection = con
                'Creating Connection

                rdr = cmd.ExecuteReader()
                rdr.Read()

                If rdr.HasRows Then
                    con.Close() 'Closing The connection
                    MetroTextBox25.Clear()
                    MetroTextBox25.Focus()
                    MetroMessageBox.Show(Me, "The Registor Number Already Exists....", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                con.Close() 'Closing The connection

            Catch ex As Exception
                MetroMessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If

        MetroTabControl1.SelectTab(1)
    End Sub

    Private Sub MetroButton3_Click(sender As Object, e As EventArgs) Handles MetroButton3.Click
        'Next Button of 2nd Page

        If MetroComboBox1.Text = Nothing Then
            MetroMessageBox.Show(Me, "Please Select Student Blood Group..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox1.Focus()
            Exit Sub
        End If
        If MetroTextBox3.Text = Nothing Then
            MetroMessageBox.Show(Me, "Please Enter Student Address..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox3.Focus()
            Exit Sub
        End If
        If MetroTextBox4.Text = Nothing Then
            MetroMessageBox.Show(Me, "Please Enter the City", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox4.Focus()
            Exit Sub
        End If
        If MetroTextBox5.Text = Nothing Then
            MetroMessageBox.Show(Me, "Please Enter the State", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox5.Focus()
            Exit Sub
        End If
        If MetroTextBox6.Text = Nothing Then
            MetroMessageBox.Show(Me, "Please Enter the Country", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox6.Focus()
            Exit Sub
        End If
        If MetroTextBox7.Text = Nothing Then
            MetroMessageBox.Show(Me, "Please Enter the Postal Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox7.Focus()
            Exit Sub
        End If
        If Not Regex.Match(MetroTextBox7.Text, "^[0-9]*$").Success Then
            MetroMessageBox.Show(Me, "Invalid Postal Code...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox7.Clear()
            MetroTextBox7.Focus()
            Exit Sub
        End If
        If Not (MetroTextBox7.Text.Length = 6) Then
            MetroMessageBox.Show(Me, "Invalid Postal Code...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox7.Clear()
            MetroTextBox7.Focus()
            Exit Sub
        End If
        If validateEmail(MetroTextBox8.Text) = False Then
            'Checking Email ID
            MetroMessageBox.Show(Me, "Invalid Email ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox8.Clear()
            MetroTextBox8.Focus()
            Exit Sub
        End If
        If Not Regex.Match(MetroTextBox9.Text, "^[0-9]*$").Success Then
            MetroMessageBox.Show(Me, "Invalid Home Phone Number...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox9.Clear()
            MetroTextBox9.Focus()
            Exit Sub
        End If
        If Not (MetroTextBox9.Text.Length = 10 Or MetroTextBox9.Text.Length = 11) Then
            MetroMessageBox.Show(Me, "Invalid Home Phone Number...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox9.Clear()
            MetroTextBox9.Focus()
            Exit Sub
        End If
        If Not Regex.Match(MetroTextBox10.Text, "^[0-9]*$").Success Then
            MetroMessageBox.Show(Me, "Invalid Mobile Number...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox10.Clear()
            MetroTextBox10.Focus()
            Exit Sub
        End If
        If MetroTextBox10.Text.Length <> 10 Then
            MetroMessageBox.Show(Me, "Invalid Mobile Number...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox10.Clear()
            MetroTextBox10.Focus()
            Exit Sub
        End If

        MetroTabControl1.SelectTab(2)

    End Sub

    Private Sub MetroButton4_Click(sender As Object, e As EventArgs) Handles MetroButton4.Click
        'Submit Button
        If MetroTextBox16.Text = Nothing Then
            MetroMessageBox.Show(Me, "Please Enter Student's Father's Name.....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox16.Focus()
            Exit Sub
        End If
        If MetroTextBox15.Text = Nothing Then
            MetroMessageBox.Show(Me, "Please Enter Guardians First Name.....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox15.Focus()
            Exit Sub
        End If
        If MetroTextBox14.Text = Nothing Then
            MetroMessageBox.Show(Me, "Please Enter Guardian's Last Name.....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox14.Focus()
            Exit Sub
        End If
        If MetroTextBox17.Text = Nothing Then
            MetroMessageBox.Show(Me, "Please Enter the Relation With Student.....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox17.Focus()
            Exit Sub
        End If
        If MetroTextBox23.Text = Nothing Then
            MetroMessageBox.Show(Me, "Please Enter Guardians Address.....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox23.Focus()
            Exit Sub
        End If
        If Not Regex.Match(MetroTextBox20.Text, "^[0-9]*$").Success Then
            MetroMessageBox.Show(Me, "Invalid Business Phone Number...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox20.Clear()
            MetroTextBox20.Focus()
            Exit Sub
        End If
        If MetroTextBox20.Text.Length <> 10 Then
            MetroMessageBox.Show(Me, "Invalid Business Phone Number...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox20.Clear()
            MetroTextBox20.Focus()
            Exit Sub
        End If
        If Not Regex.Match(MetroTextBox21.Text, "^[0-9]*$").Success Then
            MetroMessageBox.Show(Me, "Invalid Home Phone Number...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox21.Clear()
            MetroTextBox21.Focus()
            Exit Sub
        End If
        If Not (MetroTextBox21.Text.Length = 10 Or MetroTextBox21.Text.Length = 11) Then
            MetroMessageBox.Show(Me, "Invalid Home Phone Number...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox21.Clear()
            MetroTextBox21.Focus()
            Exit Sub
        End If
        If Not Regex.Match(MetroTextBox22.Text, "^[0-9]*$").Success Then
            MetroMessageBox.Show(Me, "Invalid Mobile Phone Number...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox22.Clear()
            MetroTextBox22.Focus()
            Exit Sub
        End If
        If MetroTextBox22.Text.Length <> 10 Then
            MetroMessageBox.Show(Me, "Invalid Mobile Phone Number...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox22.Clear()
            MetroTextBox22.Focus()
            Exit Sub
        End If

        Dim Gen As String
        Dim GuGen As String
        If MetroRadioButton3.Checked Then
            GuGen = "Male"
        Else
            GuGen = "Female"
        End If
        If MetroRadioButton1.Checked Then
            Gen = "Male"
        Else
            Gen = "Female"
        End If

        'Saving Image

        'Declare a file stream object
        Dim o As System.IO.FileStream

        'Declare Steam Reader Object
        Dim r As StreamReader

        'Shorter Variable name for FileStream
        Dim jpgFile As String = OpenFileDialog1.FileName

        'Open the image file
        o = New FileStream(jpgFile, FileMode.Open, FileAccess.Read, FileShare.Read)

        'Read the image into stream reader
        r = New StreamReader(o)


        Try

            'Declare a byte array to hold the image
            Dim FileByteArray(o.Length - 1) As Byte

            'Fill the byte array with image data
            o.Read(FileByteArray, 0, o.Length)

            'Connecting string
            con.ConnectionString = dbProvider & dbSource

            If Not con.State = ConnectionState.Open Then
                'Opening Connection
                con.Open()
            End If

            sql1 = "INSERT INTO [Student] ([Admission_No],[First_Name],[Last_Name],[Gender],[Date_of_Birth],[Blood_Group],[Address],[City],[State],[Country],[Postal_Code],[EMail_ID],[Home_Phone],[Mobile_Phone],[Seat_Type],[Course],[Scheme],[Semester],[Reg_No],[Last_School_Name],[School_Address],[Plus_Two_Percentage],[Student_Photo]) " &
                "VALUES('" & MetroTextBox24.Text & "','" & MetroTextBox1.Text & "','" & MetroTextBox2.Text & "','" & Gen & "','" & MetroDateTime1.Value.Date & "','" & MetroComboBox1.Text & "','" & MetroTextBox3.Text & "','" & MetroTextBox4.Text & "','" & MetroTextBox5.Text & "','" & MetroTextBox6.Text & "','" & MetroTextBox7.Text & "','" & MetroTextBox8.Text & "','" & MetroTextBox9.Text & "','" & MetroTextBox10.Text & "','" & MetroComboBox2.Text & "','" & MetroComboBox3.Text & "','" & MetroComboBox4.Text & "','" & MetroComboBox5.Text & "','" & MetroTextBox25.Text & "','" & MetroTextBox11.Text & "','" & MetroTextBox12.Text & "','" & MetroTextBox13.Text & "',PictureL)"
            'Database insertion command
            sql2 = "INSERT INTO [Guardians] ([Student_ID],[Father_Name],[First_Name],[Last_Name],[Gender],[Relation],[Company],[Job_Title],[Business_Phone],[Home_Phone],[Mobile_Phone],[Address]) " &
                "Values('" & MetroTextBox24.Text & "','" & MetroTextBox16.Text & "','" & MetroTextBox15.Text & "','" & MetroTextBox14.Text & "','" & GuGen & "','" & MetroTextBox17.Text & "','" & MetroTextBox18.Text & "','" & MetroTextBox19.Text & "','" & MetroTextBox20.Text & "','" & MetroTextBox21.Text & "','" & MetroTextBox22.Text & "','" & MetroTextBox23.Text & "')"

            sqlFee = "INSERT INTO [Fee_Paid] (Student_ID) VALUES('" & MetroTextBox24.Text & "')"

            sqls3 = "INSERT INTO [S3] (Student_ID) VALUES('" & MetroTextBox24.Text & "')"
            sqls4 = "INSERT INTO [S4] (Student_ID) VALUES('" & MetroTextBox24.Text & "')"
            sqls5 = "INSERT INTO [S5] (Student_ID) VALUES('" & MetroTextBox24.Text & "')"
            sqls6 = "INSERT INTO [S6] (Student_ID) VALUES('" & MetroTextBox24.Text & "')"
            sqls7 = "INSERT INTO [S7] (Student_ID) VALUES('" & MetroTextBox24.Text & "')"
            sqls8 = "INSERT INTO [S8] (Student_ID) VALUES('" & MetroTextBox24.Text & "')"
            sqly1 = "INSERT INTO [Y1] (Student_ID) VALUES('" & MetroTextBox24.Text & "')"

            cmd = New OleDbCommand(sql1, con)

            'Add Parameters to the oledbCommand object
            cmd.Parameters.Add("@PictureL", System.Data.OleDb.OleDbType.Binary, o.Length).Value = FileByteArray

            RecordCount = cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()

            cmd = New OleDbCommand(sql2, con)
            RecordCount = cmd.ExecuteNonQuery()

            cmd = New OleDbCommand(sqlFee, con)
            RecordCount = cmd.ExecuteNonQuery()


            cmd = New OleDbCommand(sqly1, con)
            RecordCount = cmd.ExecuteNonQuery()
            cmd = New OleDbCommand(sqls3, con)
            RecordCount = cmd.ExecuteNonQuery()
            cmd = New OleDbCommand(sqls4, con)
            RecordCount = cmd.ExecuteNonQuery()
            cmd = New OleDbCommand(sqls5, con)
            RecordCount = cmd.ExecuteNonQuery()
            cmd = New OleDbCommand(sqls6, con)
            RecordCount = cmd.ExecuteNonQuery()
            cmd = New OleDbCommand(sqls7, con)
            RecordCount = cmd.ExecuteNonQuery()
            cmd = New OleDbCommand(sqls8, con)
            RecordCount = cmd.ExecuteNonQuery()

            If RecordCount > 0 Then
                MetroMessageBox.Show(Me, "Student Data Saved Successfully....", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MetroMessageBox.Show(Me, "Error Saving the Data.....", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            con.Close()

        Catch ex As Exception
            MetroMessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        status = MetroMessageBox.Show(Me, "Do you want to add Fee Payment details?", "Confirmation..", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If status = System.Windows.Forms.DialogResult.Yes Then
            Admission_Num = MetroTextBox24.Text
            Student_Fee_Add_Common.Show()
        Else
            Student_Modify_Menu.Show()
        End If
        Close()
    End Sub

    Public Function validateEmail(emailAddress) As Boolean
        'Email Validation
        Dim email As New Regex("([\w-+]+(?:\.[\w-+]+)*@(?:[\w-]+\.)+[a-zA-Z]{2,7})")
        If email.IsMatch(emailAddress) Then
            Return True
        Else
            Return False
        End If
    End Function

End Class