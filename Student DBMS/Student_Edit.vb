Imports System.ComponentModel
Imports System.Data.OleDb
Imports System.Text.RegularExpressions
Imports MetroFramework
Imports System.IO

Public Class Student_Edit

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
    Dim Gen As String
    Dim GuGen As String

    Dim isNAme As Boolean = False
    Dim isCource As Boolean = False
    Dim IsSem As Boolean = False
    Dim Admission_NO As String

    Private Sub MetroButton5_Click(sender As Object, e As EventArgs) Handles MetroButton5.Click
        'Search Button

        If MetroTextBox26.Text = Nothing And MetroComboBox6.Text = Nothing And MetroComboBox7.Text = Nothing Then
            MetroMessageBox.Show(Me, "Select Some Parametrs to Search...", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If Not MetroTextBox26.Text = Nothing Then
            'Student Name Entired
            isNAme = True
        End If
        If Not MetroComboBox6.Text = Nothing Then
            'Cource Selected
            isCource = True
        End If
        If Not MetroComboBox7.Text = Nothing Then
            'Semester Selected
            IsSem = True
        End If

        If isNAme = True And isCource = False And IsSem = False Then
            sql1 = "SELECT Admission_No, First_Name, Last_Name, Course, Scheme, Semester FROM Student WHERE First_Name LIKE '%" & MetroTextBox26.Text & "%'"
        End If
        If isNAme = True And isCource = True And IsSem = False Then
            sql1 = "SELECT Admission_No, First_Name, Last_Name, Course, Scheme, Semester FROM Student WHERE First_Name LIKE '%" & MetroTextBox26.Text & "%' AND Course='" & MetroComboBox6.Text & "'"
        End If
        If isNAme = True And isCource = True And IsSem = True Then
            sql1 = "Select Admission_No, First_Name, Last_Name, Course, Scheme, Semester FROM Student WHERE First_Name Like '%" & MetroTextBox26.Text & "%' AND Course='" & MetroComboBox6.Text & "' AND Semester='" & MetroComboBox7.Text & "'"
        End If
        If isNAme = False And isCource = True And IsSem = True Then
            sql1 = "Select Admission_No, First_Name, Last_Name, Course, Scheme, Semester FROM Student WHERE Course='" & MetroComboBox6.Text & "' AND Semester='" & MetroComboBox7.Text & "'"
        End If
        If isNAme = True And isCource = False And IsSem = True Then
            sql1 = "Select Admission_No, First_Name, Last_Name, Course, Scheme, Semester FROM Student WHERE First_Name Like '%" & MetroTextBox26.Text & "%' AND Semester='" & MetroComboBox7.Text & "'"
        End If
        If isNAme = False And isCource = False And IsSem = True Then
            sql1 = "Select Admission_No, First_Name, Last_Name, Course, Scheme, Semester FROM Student WHERE Semester='" & MetroComboBox7.Text & "'"
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


    Private Sub MetroButton6_Click(sender As Object, e As EventArgs) Handles MetroButton6.Click
        'Edit Button

        If MetroLabel36.Text = Nothing Then
            MetroMessageBox.Show(Me, "Please Select A Student before Editing....", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        MetroLabel37.Text = MetroLabel36.Text

        Try
            'Connecting string
            con.ConnectionString = dbProvider & dbSource
            If Not con.State = ConnectionState.Open Then
                'Opening Connection
                con.Open()
            End If

            sql1 = "Select * From [Student] where [Admission_No]='" & MetroLabel36.Text & "'"
            sql2 = "Select * From [Guardians] where [Student_ID]='" & MetroLabel36.Text & "'"
            'Database Selection command

            cmd = New OleDb.OleDbCommand(sql1)
            cmd.Connection = con
            rdr1 = cmd.ExecuteReader()

            rdr1.Read()

            MetroLabel36.Text = rdr1.GetValue(0)    'Addmision no
            MetroTextBox1.Text = rdr1.GetValue(1)   'First Name
            MetroTextBox2.Text = rdr1.GetValue(2)   'Last Name
            If rdr1.GetValue(3) = "Male" Then
                MetroRadioButton1.Checked = True
            Else
                MetroRadioButton2.Checked = True
            End If
            MetroDateTime1.Value = rdr1.GetValue(4) 'DOB
            MetroComboBox1.Text = rdr1.GetValue(5) 'Blood
            MetroTextBox3.Text = rdr1.GetValue(6) 'Address
            MetroTextBox4.Text = rdr1.GetValue(7)   'City
            MetroTextBox5.Text = rdr1.GetValue(8)   'State
            MetroTextBox6.Text = rdr1.GetValue(9)   'Country
            MetroTextBox7.Text = rdr1.GetValue(10)  'postal code
            MetroTextBox8.Text = rdr1.GetValue(11)  'Email ID
            MetroTextBox9.Text = rdr1.GetValue(12)  'Home ph
            MetroTextBox10.Text = rdr1.GetValue(13) 'Mobile No
            MetroComboBox2.Text = rdr1.GetValue(14) 'Seat Type
            MetroComboBox3.Text = rdr1.GetValue(15) 'Course
            MetroComboBox4.Text = rdr1.GetValue(16) 'Scheme
            MetroComboBox5.Text = rdr1.GetValue(17) 'Sem
            MetroTextBox25.Text = rdr1.GetValue(18)  'Reg no
            MetroTextBox11.Text = rdr1.GetValue(19)  'Last School name
            MetroTextBox12.Text = rdr1.GetValue(20) 'School address
            MetroTextBox13.Text = rdr1.GetValue(21) '+2 Percentage

            Dim bytes As [Byte]() = rdr1.GetValue(22)
            Dim ms As New MemoryStream(bytes)
            PictureBox1.BackgroundImage = Image.FromStream(ms)

            cmd = New OleDb.OleDbCommand(sql2)
            cmd.Connection = con
            rdr2 = cmd.ExecuteReader()

            rdr2.Read()
            MetroTextBox16.Text = rdr2.GetValue(1) 'Father Name
            MetroTextBox15.Text = rdr2.GetValue(2) 'First Name
            MetroTextBox14.Text = rdr2.GetValue(3)   'Last Name
            If rdr2.GetValue(4) = "Male" Then 'Gender
                MetroRadioButton3.Checked = True
            Else
                MetroRadioButton4.Checked = True
            End If

            MetroTextBox17.Text = rdr2.GetValue(5) 'Relation
            MetroTextBox18.Text = rdr2.GetValue(6) 'Company
            MetroTextBox19.Text = rdr2.GetValue(7) 'Job
            MetroTextBox20.Text = rdr2.GetValue(8) 'Business ph
            MetroTextBox21.Text = rdr2.GetValue(9) 'Home ph
            MetroTextBox22.Text = rdr2.GetValue(10) 'Mobile ph
            MetroTextBox23.Text = rdr2.GetValue(11) 'Address

            con.Close() 'Closing The connection

        Catch ex As Exception
            MetroMessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        MetroTabControl1.SelectTab(1)

    End Sub

    Private Sub MetroButton4_Click(sender As Object, e As EventArgs) Handles MetroButton4.Click
        'Update Button

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
        Dim Gu_Gen As String
        If MetroRadioButton3.Checked Then
            Gu_Gen = "Male"
        Else
            Gu_Gen = "Female"
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

        Dim jpgFile As String
        Dim Done As Boolean = False
        Try
            'Connecting string
            con.ConnectionString = dbProvider & dbSource

            If Not con.State = ConnectionState.Open Then
                'Opening Connection
                con.Open()
            End If

            If isFileOpened = True Then

                'Shorter Variable name for FileStream
                jpgFile = OpenFileDialog1.FileName

                'Open the image file
                o = New FileStream(jpgFile, FileMode.Open, FileAccess.Read, FileShare.Read)

                'Read the image into stream reader
                r = New StreamReader(o)

                'Declare a byte array to hold the image
                Dim FileByteArray(o.Length - 1) As Byte

                'Fill the byte array with image data
                o.Read(FileByteArray, 0, o.Length)

                sql1 = "UPDATE [Student] SET [First_Name]= '" & MetroTextBox1.Text & "',[Last_Name]='" & MetroTextBox2.Text & "',[Gender]='" & Gen & "',[Date_of_Birth]='" & MetroDateTime1.Value.Date & "',[Blood_Group]='" & MetroComboBox1.Text & "',[Address]='" & MetroTextBox3.Text & "',[City]='" & MetroTextBox4.Text & "',[State]='" & MetroTextBox5.Text & "',[Country]='" & MetroTextBox6.Text & "',[Postal_Code]='" & MetroTextBox7.Text & "',[EMail_ID]='" & MetroTextBox8.Text & "',[Home_Phone]='" & MetroTextBox9.Text & "',[Mobile_Phone]='" & MetroTextBox10.Text & "',[Seat_Type]='" & MetroComboBox2.Text & "',[Course]='" & MetroComboBox3.Text & "',[Scheme]='" & MetroComboBox4.Text & "',[Semester]='" & MetroComboBox5.Text & "',[Reg_No]='" & MetroTextBox25.Text & "',[Last_School_Name]='" & MetroTextBox11.Text & "',[School_Address]='" & MetroTextBox12.Text & "',[Plus_Two_Percentage]='" & MetroTextBox13.Text & "',[Student_Photo]=PictureL WHERE Admission_No='" & MetroLabel37.Text & "'"
                cmd = New OleDbCommand(sql1, con)

                'Add Parameters to the oledbCommand object
                cmd.Parameters.Add("@PictureL", System.Data.OleDb.OleDbType.Binary, o.Length).Value = FileByteArray

                RecordCount = cmd.ExecuteNonQuery()
                cmd.Parameters.Clear()
                Done = True
            End If

            If Done = False Then

                sql1 = "UPDATE [Student] SET [First_Name]= '" & MetroTextBox1.Text & "',[Last_Name]='" & MetroTextBox2.Text & "',[Gender]='" & Gen & "',[Date_of_Birth]='" & MetroDateTime1.Value.Date & "',[Blood_Group]='" & MetroComboBox1.Text & "',[Address]='" & MetroTextBox3.Text & "',[City]='" & MetroTextBox4.Text & "',[State]='" & MetroTextBox5.Text & "',[Country]='" & MetroTextBox6.Text & "',[Postal_Code]='" & MetroTextBox7.Text & "',[EMail_ID]='" & MetroTextBox8.Text & "',[Home_Phone]='" & MetroTextBox9.Text & "',[Mobile_Phone]='" & MetroTextBox10.Text & "',[Seat_Type]='" & MetroComboBox2.Text & "',[Course]='" & MetroComboBox3.Text & "',[Scheme]='" & MetroComboBox4.Text & "',[Semester]='" & MetroComboBox5.Text & "',[Reg_No]='" & MetroTextBox25.Text & "',[Last_School_Name]='" & MetroTextBox11.Text & "',[School_Address]='" & MetroTextBox12.Text & "',[Plus_Two_Percentage]='" & MetroTextBox13.Text & "' WHERE Admission_No='" & MetroLabel37.Text & "'"

                cmd = New OleDbCommand(sql1, con)
                RecordCount = cmd.ExecuteNonQuery()
            End If

            sql2 = "UPDATE [Guardians] Set [Father_Name]='" & MetroTextBox16.Text & "',[First_Name]='" & MetroTextBox15.Text & "',[Last_Name]='" & MetroTextBox14.Text & "',[Gender]='" & Gu_Gen & "',[Relation]='" & MetroTextBox17.Text & "',[Company]='" & MetroTextBox18.Text & "',[Job_Title]='" & MetroTextBox19.Text & "',[Business_Phone]='" & MetroTextBox20.Text & "',[Home_phone]='" & MetroTextBox21.Text & "',[Mobile_Phone]='" & MetroTextBox22.Text & "',[Address]='" & MetroTextBox23.Text & "' WHERE [Student_ID]='" & MetroLabel37.Text & "'"

            cmd = New OleDbCommand(sql2, con)
            RecordCount = cmd.ExecuteNonQuery()

            If RecordCount > 0 Then
                MetroMessageBox.Show(Me, "Student Data Updated Successfully....", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MetroMessageBox.Show(Me, "Error Updating the Data.....", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            con.Close()

        Catch ex As Exception
            MetroMessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Student_Modify_Menu.Show()
        Close()
    End Sub

    Private Sub Student_Edit_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        'When Form Opens

        MetroLabel36.Text = ""
        MetroTextBox26.Clear()

        MetroTabControl1.SelectTab(0)

        Try
            con.ConnectionString = dbProvider & dbSource
            If Not con.State = ConnectionState.Open Then
                'Opening Connection
                con.Open()
            End If
            sql1 = "Select Admission_No, First_Name, Last_Name, Course, Scheme, Semester From Student"
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

    Private Sub MetroButton7_Click(sender As Object, e As EventArgs) Handles MetroButton7.Click
        'Clearing Search Parametrs

        DBDT.Clear()                    'Cleaning The Data Table
        MetroGrid1.DataSource = DBDT    'Cleaning DataGrid

        MetroTextBox26.Clear()

        Try
            con.ConnectionString = dbProvider & dbSource
            If Not con.State = ConnectionState.Open Then
                'Opening Connection
                con.Open()
            End If
            sql1 = "Select Admission_No, First_Name, Last_Name, Course, Scheme, Semester From Student"
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

    Private Sub MetroGrid1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles MetroGrid1.CellDoubleClick
        'Selecting A Cell 

        If MetroGrid1.CurrentRow.Index < 0 Then
            'Selected Row is 1st Row
            Exit Sub
        End If

        MetroLabel36.Text = MetroGrid1.SelectedRows(0).Cells(0).Value.ToString
        'To Get the Admin Name of selected ONE record

    End Sub

    Private Sub MetroButton8_Click(sender As Object, e As EventArgs) Handles MetroButton8.Click
        'Cancel Button
        MetroTabControl1.SelectTab(0)

    End Sub

    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        'Open Picture

        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            isFileOpened = True
            PictureBox1.BackgroundImage = Image.FromFile(OpenFileDialog1.FileName)
            PictureBox1.BackgroundImageLayout = ImageLayout.Stretch
        End If

    End Sub

    Private Sub MetroButton2_Click(sender As Object, e As EventArgs) Handles MetroButton2.Click
        'Next Button of 1st page

        If MetroTextBox1.Text = Nothing Or MetroTextBox2.Text = Nothing Then
            MetroMessageBox.Show(Me, "Student Name is not entired..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MetroTextBox1.Focus()
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
        MetroTabControl1.SelectTab(2)
    End Sub

    Private Sub MetroButton3_Click(sender As Object, e As EventArgs) Handles MetroButton3.Click
        'Next Button in 2nd Page

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

        MetroTabControl1.SelectTab(3)

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

    Private Sub Student_Edit_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Student_Modify_Menu.Show()
    End Sub
End Class