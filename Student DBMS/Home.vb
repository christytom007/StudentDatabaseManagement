Public Class Home
    Private Sub Home_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        PlayBackgroundSoundFile()
    End Sub

    Private Sub MetroTile1_Click(sender As Object, e As EventArgs) Handles MetroTile1.Click
        Login.Show()
        My.Computer.Audio.Stop()
        Close()
    End Sub

    Private Sub MetroTile2_Click(sender As Object, e As EventArgs) Handles MetroTile2.Click
        View_Student.Show()
        My.Computer.Audio.Stop()
        Close()
    End Sub

    Sub PlayBackgroundSoundFile()
        My.Computer.Audio.Play(Application.StartupPath & "/home.wav",
            AudioPlayMode.Background)
    End Sub

End Class