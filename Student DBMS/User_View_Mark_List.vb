
Imports System.ComponentModel
Imports System.Data.OleDb
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Text.RegularExpressions
Imports MetroFramework
Imports System.IO
Public Class User_View_Mark_List

    Dim con As New OleDbConnection                                              'THE CONNECTION OBJECT
    Dim dbProvider = "PROVIDER=Microsoft.ACE.OLEDB.12.0;"                       'PROVIDER STRING
    Dim cmd As OleDbCommand = Nothing                                           'COMMAND OBJECT
    Dim FullDataPath As String = Application.StartupPath & "\Student.accdb"     'DATABASE LOCATION

    Dim dbSource As String = "Data Source = " & FullDataPath                    'COMPLETE SOURCE STRING
    Dim sql1 As String                                                          'SQL STRING
    Dim sql2 As String                                                          'SQL STRING
    Dim DBDT As New DataTable                                                   'Data Table
    Dim tables As DataTableCollection
    Dim Source1 As New BindingSource
    Dim APP As Excel.Application = New Microsoft.Office.Interop.Excel.Application()
    Dim WorkSheet As New Excel.Worksheet
    Dim WorkBook As Excel.Workbook
    Dim rdr1 As OleDbDataReader = Nothing                                        'DATABASE READER
    Dim DBDA As OleDbDataAdapter                                                'Data Adapter
    Dim RecordCount As Integer

    Dim isNAme As Boolean = False
    Dim isCource As Boolean = False
    Dim IsSem As Boolean = False
    Dim IsScheme As Boolean = False
    Dim Sem As Integer
    Dim IsMark As Boolean = False

    Private Sub User_View_Mark_List_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        'Closing
        View_Student.Show()

    End Sub

    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        'Search Button

        If MetroComboBox1.Text = Nothing Or MetroComboBox2.Text = Nothing Or MetroComboBox3.Text = Nothing Or MetroComboBox4.Text = Nothing Then
            MetroMessageBox.Show(Me, "All Parametrs are REQUIRED to Search...", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        DBDT.Rows.Clear()                    'Cleaning The Data Table
        DBDT.Columns.Clear()
        MetroGrid1.DataSource = DBDT    'Cleaning DataGrid
        Call CType(MetroGrid1.DataSource, DataTable).Rows.Clear()

        RecordCount = 0
        Try
            con.ConnectionString = dbProvider & dbSource
            If Not con.State = ConnectionState.Open Then
                'Opening Connection
                con.Open()
            End If
            If MetroComboBox2.Text = "1" Or MetroComboBox2.Text = "2" Then
                '1st year
                If MetroComboBox4.Text = "Series Exam 1" Then
                    sql1 = "SELECT Reg_No,First_Name,Ser1_Sub1,Ser1_Sub2,Ser1_Sub3,Ser1_Sub4,Ser1_Sub5,Ser1_Sub6,Ser1_Sub7,Ser1_Sub8,Ser1_Sub9,Ser1_Lab1,Ser1_Lab2,Ser1_Lab3 FROM Student INNER JOIN Y1 ON Student.Admission_No = Y1.Student_ID WHERE Student.Course='" & MetroComboBox1.Text & "' AND Student.Scheme='" & MetroComboBox3.Text & "' AND Student.Semester='" & MetroComboBox2.Text & "'"
                ElseIf MetroComboBox4.Text = "Series Exam 2"
                    sql1 = "SELECT Reg_No,First_Name,Ser2_Sub1,Ser2_Sub2,Ser2_Sub3,Ser2_Sub4,Ser2_Sub5,Ser2_Sub6,Ser2_Sub7,Ser2_Sub8,Ser2_Sub9,Ser2_Lab1,Ser2_Lab2,Ser2_Lab3 FROM Student INNER JOIN Y1 ON Student.Admission_No = Y1.Student_ID WHERE Student.Course='" & MetroComboBox1.Text & "' AND Student.Scheme='" & MetroComboBox3.Text & "' AND Student.Semester='" & MetroComboBox2.Text & "'"
                ElseIf MetroComboBox4.Text = "Internal Mark"
                    sql1 = "SELECT Reg_No,First_Name,Inter_Sub1,Inter_Sub2,Inter_Sub3,Inter_Sub4,Inter_Sub5,Inter_Sub6,Inter_Sub7,Inter_Sub8,Inter_Sub9,Inter_Lab1,Inter_Lab2,Inter_Lab3 FROM Student INNER JOIN Y1 ON Student.Admission_No = Y1.Student_ID WHERE Student.Course='" & MetroComboBox1.Text & "' AND Student.Scheme='" & MetroComboBox3.Text & "' AND Student.Semester='" & MetroComboBox2.Text & "'"
                ElseIf MetroComboBox4.Text = "University Exam"
                    sql1 = "SELECT Reg_No,First_Name,Uni_Sub1,Uni_Sub2,Uni_Sub3,Uni_Sub4,Uni_Sub5,Uni_Sub6,Uni_Sub7,Uni_Sub8,Uni_Sub9,Uni_Lab1,Uni_Lab2,Uni_Lab3 FROM Student INNER JOIN Y1 ON Student.Admission_No = Y1.Student_ID WHERE Student.Course='" & MetroComboBox1.Text & "' AND Student.Scheme='" & MetroComboBox3.Text & "' AND Student.Semester='" & MetroComboBox2.Text & "'"
                End If
            ElseIf MetroComboBox2.Text = "3"
                'S3
                If MetroComboBox4.Text = "Series Exam 1" Then
                    sql1 = "SELECT Reg_No,First_Name,Ser1_Sub1,Ser1_Sub2,Ser1_Sub3,Ser1_Sub4,Ser1_Sub5,Ser1_Sub6,Ser1_Lab1,Ser1_Lab2 FROM Student INNER JOIN S3 ON Student.Admission_No = S3.Student_ID WHERE Student.Course='" & MetroComboBox1.Text & "' AND Student.Scheme='" & MetroComboBox3.Text & "' AND Student.Semester='" & MetroComboBox2.Text & "'"
                ElseIf MetroComboBox4.Text = "Series Exam 2"
                    sql1 = "SELECT Reg_No,First_Name,Ser2_Sub1,Ser2_Sub2,Ser2_Sub3,Ser2_Sub4,Ser2_Sub5,Ser2_Sub6,Ser2_Lab1,Ser2_Lab2 FROM Student INNER JOIN S3 ON Student.Admission_No = S3.Student_ID WHERE Student.Course='" & MetroComboBox1.Text & "' AND Student.Scheme='" & MetroComboBox3.Text & "' AND Student.Semester='" & MetroComboBox2.Text & "'"
                ElseIf MetroComboBox4.Text = "Internal Mark"
                    sql1 = "SELECT Reg_No,First_Name,Inter_Sub1,Inter_Sub2,Inter_Sub3,Inter_Sub4,Inter_Sub5,Inter_Sub6,Inter_Lab1,Inter_Lab2 FROM Student INNER JOIN S3 ON Student.Admission_No = S3.Student_ID WHERE Student.Course='" & MetroComboBox1.Text & "' AND Student.Scheme='" & MetroComboBox3.Text & "' AND Student.Semester='" & MetroComboBox2.Text & "'"
                ElseIf MetroComboBox4.Text = "University Exam"
                    sql1 = "SELECT Reg_No,First_Name,Uni_Sub1,Uni_Sub2,Uni_Sub3,Uni_Sub4,Uni_Sub5,Uni_Sub6,Uni_Lab1,Uni_Lab2 FROM Student INNER JOIN S3 ON Student.Admission_No = S3.Student_ID WHERE Student.Course='" & MetroComboBox1.Text & "' AND Student.Scheme='" & MetroComboBox3.Text & "' AND Student.Semester='" & MetroComboBox2.Text & "'"
                End If
            ElseIf MetroComboBox2.Text = "4"
                'S4
                If MetroComboBox4.Text = "Series Exam 1" Then
                    sql1 = "SELECT Reg_No,First_Name,Ser1_Sub1,Ser1_Sub2,Ser1_Sub3,Ser1_Sub4,Ser1_Sub5,Ser1_Sub6,Ser1_Lab1,Ser1_Lab2 FROM Student INNER JOIN S4 ON Student.Admission_No = S4.Student_ID WHERE Student.Course='" & MetroComboBox1.Text & "' AND Student.Scheme='" & MetroComboBox3.Text & "' AND Student.Semester='" & MetroComboBox2.Text & "'"
                ElseIf MetroComboBox4.Text = "Series Exam 2"
                    sql1 = "SELECT Reg_No,First_Name,Ser2_Sub1,Ser2_Sub2,Ser2_Sub3,Ser2_Sub4,Ser2_Sub5,Ser2_Sub6,Ser2_Lab1,Ser2_Lab2 FROM Student INNER JOIN S4 ON Student.Admission_No = S4.Student_ID WHERE Student.Course='" & MetroComboBox1.Text & "' AND Student.Scheme='" & MetroComboBox3.Text & "' AND Student.Semester='" & MetroComboBox2.Text & "'"
                ElseIf MetroComboBox4.Text = "Internal Mark"
                    sql1 = "SELECT Reg_No,First_Name,Inter_Sub1,Inter_Sub2,Inter_Sub3,Inter_Sub4,Inter_Sub5,Inter_Sub6,Inter_Lab1,Inter_Lab2 FROM Student INNER JOIN S4 ON Student.Admission_No = S4.Student_ID WHERE Student.Course='" & MetroComboBox1.Text & "' AND Student.Scheme='" & MetroComboBox3.Text & "' AND Student.Semester='" & MetroComboBox2.Text & "'"
                ElseIf MetroComboBox4.Text = "University Exam"
                    sql1 = "SELECT Reg_No,First_Name,Uni_Sub1,Uni_Sub2,Uni_Sub3,Uni_Sub4,Uni_Sub5,Uni_Sub6,Uni_Lab1,Uni_Lab2 FROM Student INNER JOIN S4 ON Student.Admission_No = S4.Student_ID WHERE Student.Course='" & MetroComboBox1.Text & "' AND Student.Scheme='" & MetroComboBox3.Text & "' AND Student.Semester='" & MetroComboBox2.Text & "'"
                End If
            ElseIf MetroComboBox2.Text = "5"
                'S5
                If MetroComboBox4.Text = "Series Exam 1" Then
                    sql1 = "SELECT Reg_No,First_Name,Ser1_Sub1,Ser1_Sub2,Ser1_Sub3,Ser1_Sub4,Ser1_Sub5,Ser1_Sub6,Ser1_Lab1,Ser1_Lab2 FROM Student INNER JOIN S5 ON Student.Admission_No = S5.Student_ID WHERE Student.Course='" & MetroComboBox1.Text & "' AND Student.Scheme='" & MetroComboBox3.Text & "' AND Student.Semester='" & MetroComboBox2.Text & "'"
                ElseIf MetroComboBox4.Text = "Series Exam 2"
                    sql1 = "SELECT Reg_No,First_Name,Ser2_Sub1,Ser2_Sub2,Ser2_Sub3,Ser2_Sub4,Ser2_Sub5,Ser2_Sub6,Ser2_Lab1,Ser2_Lab2 FROM Student INNER JOIN S5 ON Student.Admission_No = S5.Student_ID WHERE Student.Course='" & MetroComboBox1.Text & "' AND Student.Scheme='" & MetroComboBox3.Text & "' AND Student.Semester='" & MetroComboBox2.Text & "'"
                ElseIf MetroComboBox4.Text = "Internal Mark"
                    sql1 = "SELECT Reg_No,First_Name,Inter_Sub1,Inter_Sub2,Inter_Sub3,Inter_Sub4,Inter_Sub5,Inter_Sub6,Inter_Lab1,Inter_Lab2 FROM Student INNER JOIN S5 ON Student.Admission_No = S5.Student_ID WHERE Student.Course='" & MetroComboBox1.Text & "' AND Student.Scheme='" & MetroComboBox3.Text & "' AND Student.Semester='" & MetroComboBox2.Text & "'"
                ElseIf MetroComboBox4.Text = "University Exam"
                    sql1 = "SELECT Reg_No,First_Name,Uni_Sub1,Uni_Sub2,Uni_Sub3,Uni_Sub4,Uni_Sub5,Uni_Sub6,Uni_Lab1,Uni_Lab2 FROM Student INNER JOIN S5 ON Student.Admission_No = S5.Student_ID WHERE Student.Course='" & MetroComboBox1.Text & "' AND Student.Scheme='" & MetroComboBox3.Text & "' AND Student.Semester='" & MetroComboBox2.Text & "'"
                End If
            ElseIf MetroComboBox2.Text = "6"
                'S6
                If MetroComboBox4.Text = "Series Exam 1" Then
                    sql1 = "SELECT Reg_No,First_Name,Ser1_Sub1,Ser1_Sub2,Ser1_Sub3,Ser1_Sub4,Ser1_Sub5,Ser1_Sub6,Ser1_Lab1,Ser1_Lab2 FROM Student INNER JOIN S6 ON Student.Admission_No = S6.Student_ID WHERE Student.Course='" & MetroComboBox1.Text & "' AND Student.Scheme='" & MetroComboBox3.Text & "' AND Student.Semester='" & MetroComboBox2.Text & "'"
                ElseIf MetroComboBox4.Text = "Series Exam 2"
                    sql1 = "SELECT Reg_No,First_Name,Ser2_Sub1,Ser2_Sub2,Ser2_Sub3,Ser2_Sub4,Ser2_Sub5,Ser2_Sub6,Ser2_Lab1,Ser2_Lab2 FROM Student INNER JOIN S6 ON Student.Admission_No = S6.Student_ID WHERE Student.Course='" & MetroComboBox1.Text & "' AND Student.Scheme='" & MetroComboBox3.Text & "' AND Student.Semester='" & MetroComboBox2.Text & "'"
                ElseIf MetroComboBox4.Text = "Internal Mark"
                    sql1 = "SELECT Reg_No,First_Name,Inter_Sub1,Inter_Sub2,Inter_Sub3,Inter_Sub4,Inter_Sub5,Inter_Sub6,Inter_Lab1,Inter_Lab2 FROM Student INNER JOIN S6 ON Student.Admission_No = S6.Student_ID WHERE Student.Course='" & MetroComboBox1.Text & "' AND Student.Scheme='" & MetroComboBox3.Text & "' AND Student.Semester='" & MetroComboBox2.Text & "'"
                ElseIf MetroComboBox4.Text = "University Exam"
                    sql1 = "SELECT Reg_No,First_Name,Uni_Sub1,Uni_Sub2,Uni_Sub3,Uni_Sub4,Uni_Sub5,Uni_Sub6,Uni_Lab1,Uni_Lab2 FROM Student INNER JOIN S6 ON Student.Admission_No = S6.Student_ID WHERE Student.Course='" & MetroComboBox1.Text & "' AND Student.Scheme='" & MetroComboBox3.Text & "' AND Student.Semester='" & MetroComboBox2.Text & "'"
                End If
            ElseIf MetroComboBox2.Text = "7"
                'S7
                If MetroComboBox4.Text = "Series Exam 1" Then
                    sql1 = "SELECT Reg_No,First_Name,Ser1_Sub1,Ser1_Sub2,Ser1_Sub3,Ser1_Sub4,Ser1_Sub5,Ser1_Sub6,Ser1_Lab1,Ser1_Lab2 FROM Student INNER JOIN S7 ON Student.Admission_No = S7.Student_ID WHERE Student.Course='" & MetroComboBox1.Text & "' AND Student.Scheme='" & MetroComboBox3.Text & "' AND Student.Semester='" & MetroComboBox2.Text & "'"
                ElseIf MetroComboBox4.Text = "Series Exam 2"
                    sql1 = "SELECT Reg_No,First_Name,Ser2_Sub1,Ser2_Sub2,Ser2_Sub3,Ser2_Sub4,Ser2_Sub5,Ser2_Sub6,Ser2_Lab1,Ser2_Lab2 FROM Student INNER JOIN S7 ON Student.Admission_No = S7.Student_ID WHERE Student.Course='" & MetroComboBox1.Text & "' AND Student.Scheme='" & MetroComboBox3.Text & "' AND Student.Semester='" & MetroComboBox2.Text & "'"
                ElseIf MetroComboBox4.Text = "Internal Mark"
                    sql1 = "SELECT Reg_No,First_Name,Inter_Sub1,Inter_Sub2,Inter_Sub3,Inter_Sub4,Inter_Sub5,Inter_Sub6,Inter_Lab1,Inter_Lab2 FROM Student INNER JOIN S7 ON Student.Admission_No = S7.Student_ID WHERE Student.Course='" & MetroComboBox1.Text & "' AND Student.Scheme='" & MetroComboBox3.Text & "' AND Student.Semester='" & MetroComboBox2.Text & "'"
                ElseIf MetroComboBox4.Text = "University Exam"
                    sql1 = "SELECT Reg_No,First_Name,Uni_Sub1,Uni_Sub2,Uni_Sub3,Uni_Sub4,Uni_Sub5,Uni_Sub6,Uni_Lab1,Uni_Lab2 FROM Student INNER JOIN S7 ON Student.Admission_No = S7.Student_ID WHERE Student.Course='" & MetroComboBox1.Text & "' AND Student.Scheme='" & MetroComboBox3.Text & "' AND Student.Semester='" & MetroComboBox2.Text & "'"
                End If
            ElseIf MetroComboBox2.Text = "8"
                'S8
                If MetroComboBox4.Text = "Series Exam 1" Then
                    sql1 = "SELECT Reg_No,First_Name,Ser1_Sub1,Ser1_Sub2,Ser1_Sub3,Ser1_Sub4,Ser1_Lab1,Ser1_Lab2 FROM Student INNER JOIN S8 ON Student.Admission_No = S8.Student_ID WHERE Student.Course='" & MetroComboBox1.Text & "' AND Student.Scheme='" & MetroComboBox3.Text & "' AND Student.Semester='" & MetroComboBox2.Text & "'"
                ElseIf MetroComboBox4.Text = "Series Exam 2"
                    sql1 = "SELECT Reg_No,First_Name,Ser2_Sub1,Ser2_Sub2,Ser2_Sub3,Ser2_Sub4,Ser2_Lab1,Ser2_Lab2 FROM Student INNER JOIN S8 ON Student.Admission_No = S8.Student_ID WHERE Student.Course='" & MetroComboBox1.Text & "' AND Student.Scheme='" & MetroComboBox3.Text & "' AND Student.Semester='" & MetroComboBox2.Text & "'"
                ElseIf MetroComboBox4.Text = "Internal Mark"
                    sql1 = "SELECT Reg_No,First_Name,Inter_Sub1,Inter_Sub2,Inter_Sub3,Inter_Sub4,Inter_Lab1,Inter_Lab2 FROM Student INNER JOIN S8 ON Student.Admission_No = S8.Student_ID WHERE Student.Course='" & MetroComboBox1.Text & "' AND Student.Scheme='" & MetroComboBox3.Text & "' AND Student.Semester='" & MetroComboBox2.Text & "'"
                ElseIf MetroComboBox4.Text = "University Exam"
                    sql1 = "SELECT Reg_No,First_Name,Uni_Sub1,Uni_Sub2,Uni_Sub3,Uni_Sub4,Uni_Lab1,Uni_Lab2 FROM Student INNER JOIN S8 ON Student.Admission_No = S8.Student_ID WHERE Student.Course='" & MetroComboBox1.Text & "' AND Student.Scheme='" & MetroComboBox3.Text & "' AND Student.Semester='" & MetroComboBox2.Text & "'"
                End If
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

    Private Sub MetroButton3_Click(sender As Object, e As EventArgs) Handles MetroButton3.Click
        'Exporting to Excel

        If MetroComboBox1.Text = Nothing Or MetroComboBox2.Text = Nothing Or MetroComboBox3.Text = Nothing Or MetroComboBox4.Text = Nothing Then
            MetroMessageBox.Show(Me, "All Parametrs are REQUIRED Before Exporting...", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        'Export Header Names Start
        WorkBook = APP.Workbooks.Add()
        WorkSheet = WorkBook.Worksheets("sheet1")

        Dim columnsCount As Integer = MetroGrid1.Columns.Count
        For Each column In MetroGrid1.Columns
            WorkSheet.Cells(1, column.Index + 1).Value = column.Name
        Next

        'Export Each Rows Start
        For i As Integer = 0 To MetroGrid1.RowCount - 1
            Dim columnIndex As Integer = 0
            Do Until columnIndex = columnsCount
                WorkSheet.Cells(i + 2, columnIndex + 1).Value = MetroGrid1.Item(columnIndex, i).Value.ToString
                columnIndex += 1
            Loop
        Next

        WorkBook.SaveAs(Application.StartupPath & "/" & DateTime.Now.ToString("yyyyMMdd_HH_mm_ss") & ".xlsx")
        WorkBook.Close()
        APP.Quit()
        MetroMessageBox.Show(Me, "Successfully Exported..", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class