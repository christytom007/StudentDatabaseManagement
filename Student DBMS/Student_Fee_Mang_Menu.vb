Imports System.ComponentModel
Imports System.Data.OleDb
Imports System.Text.RegularExpressions
Imports MetroFramework
Imports System.IO
Public Class Student_Fee_Mang_Menu

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
    Dim DBDT As New DataTable
    Dim RecordCount As Integer

    Dim sqlFee1 As String
    Dim sqlFee2 As String
    Dim sqlFee3 As String
    Dim sqlFee4 As String
    Dim sqlFee5 As String

    Dim Admission_NO As String
    Dim Seat_Type As String
    Dim Sem As Integer

    Private Sub MetroTile1_Click(sender As Object, e As EventArgs) Handles MetroTile1.Click
        'Add Student Fee
        Student_Fee_Add.Show()
        Hide()
    End Sub

    Private Sub MetroTile4_Click(sender As Object, e As EventArgs) Handles MetroTile4.Click
        'Edit Fee Structure
        Student_Fee_Struct_Edit.Show()
        Hide()

    End Sub

    Private Sub MetroTile3_Click(sender As Object, e As EventArgs) Handles MetroTile3.Click
        'View Fee Structure
        Student_Fee_Struct_View.Show()

    End Sub

    Private Sub MetroTile5_Click(sender As Object, e As EventArgs) Handles MetroTile5.Click
        'Students paid fee details
        Student_Fee_Paid_Detail.Show()

    End Sub

    Private Sub Student_Fee_Mang_Menu_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        'Form Shows

        RecordCount = 0
        Try
            con.ConnectionString = dbProvider & dbSource
            If Not con.State = ConnectionState.Open Then
                'Opening Connection
                con.Open()
            End If
            sql1 = "SELECT Student_ID, Y1_Remaining, Y2_Remaining, Y3_Remaining, Y4_Remaining FROM Fee_Paid WHERE Y1_Remaining > 0 OR Y2_Remaining > 0 OR Y3_Remaining > 0 OR Y4_Remaining > 0"
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

    Private Sub Student_Fee_Mang_Menu_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        'Closing
        Student_Modify_Menu.Show()
    End Sub

End Class