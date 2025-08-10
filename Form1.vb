Public Class Form1

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Guna2CircleProgressBar1.Increment(2)
        If Guna2CircleProgressBar1.Value = 100 Then
            Me.Hide()
            Form2.Show()
            Timer1.Enabled = False
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
    End Sub

End Class
