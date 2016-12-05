Imports System.ComponentModel

Public Class Mark_Main_Menu
    Private Sub Mark_Main_Menu_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        'Closing
        Admin_Control_Panel.Show()
    End Sub

    Private Sub MetroTile1_Click(sender As Object, e As EventArgs) Handles MetroTile1.Click
        'Add / Edit Series Exam Marks
        Mark_Series_Add.Show()

    End Sub

    Private Sub MetroTile4_Click(sender As Object, e As EventArgs) Handles MetroTile4.Click
        'Add / Edit Internal Marks
        Mark_Internal.Show()
    End Sub

    Private Sub MetroTile5_Click(sender As Object, e As EventArgs) Handles MetroTile5.Click
        'Add / Edit University Exam Marks
        Mark_University.Show()
    End Sub

    Private Sub MetroTile8_Click(sender As Object, e As EventArgs) Handles MetroTile8.Click
        'Generate Rank List For University Exam
        Mark_List_Generation.Show()
    End Sub
End Class