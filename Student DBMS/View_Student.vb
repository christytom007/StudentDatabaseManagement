
Imports System.ComponentModel
Imports System.Data.OleDb

Public Class View_Student


    Private Sub MetroTile1_Click(sender As Object, e As EventArgs) Handles MetroTile1.Click
        'View Student Details
        User_Student_Details.Show()

    End Sub

    Private Sub MetroTile2_Click(sender As Object, e As EventArgs) Handles MetroTile2.Click
        'View Fee Structure
        User_Fee_Structure.Show()

    End Sub

    Private Sub MetroTile3_Click(sender As Object, e As EventArgs) Handles MetroTile3.Click
        'View Fee Paid
        User_Fee_Paid.Show()

    End Sub

    Private Sub MetroTile4_Click(sender As Object, e As EventArgs) Handles MetroTile4.Click
        'Rank List
        User_View_Mark_List.Show()
        Hide()

    End Sub

    Private Sub View_Student_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        'Closing
        Home.Show()
    End Sub
End Class