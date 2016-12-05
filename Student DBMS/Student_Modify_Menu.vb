Imports System.ComponentModel

Public Class Student_Modify_Menu
    Private Sub MetroTile1_Click(sender As Object, e As EventArgs) Handles MetroTile1.Click
        'Add New Student
        Student_New.Show()
        Hide()
    End Sub

    Private Sub MetroTile2_Click(sender As Object, e As EventArgs) Handles MetroTile2.Click
        'Add Existing Student
        Student_Existing.Show()
        Close()
    End Sub

    Private Sub MetroTile3_Click(sender As Object, e As EventArgs) Handles MetroTile3.Click
        'Edit Student Details
        Student_Edit.Show()
        Hide()

    End Sub

    Private Sub MetroTile5_Click(sender As Object, e As EventArgs) Handles MetroTile5.Click
        'Search For Student
        Student_Search.Show()
        Hide()

    End Sub

    Private Sub MetroTile4_Click(sender As Object, e As EventArgs) Handles MetroTile4.Click
        'Remove Student
        Student_Remove.Show()
        Hide()

    End Sub

    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        'Back Button
        Close()

    End Sub

    Private Sub Student_Modify_Menu_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Admin_Control_Panel.Show()

    End Sub

    Private Sub MetroTile6_Click(sender As Object, e As EventArgs) Handles MetroTile6.Click
        'Fee Mangement
        Student_Fee_Mang_Menu.Show()

    End Sub
End Class