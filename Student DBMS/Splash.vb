Public Class Splash
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If MetroProgressSpinner1.Value < 100 Then
            MetroProgressSpinner1.Value = MetroProgressSpinner1.Value + 5
        Else
            Home.Show()
            Close()
        End If
    End Sub

End Class