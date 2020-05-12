Public Class dashboard2
    Private Sub btnhourly_Click(sender As Object, e As EventArgs) Handles btnhourly.Click
        hourly()
    End Sub

    Public Sub hourly()
        Dim f As New dashboard_hourly
        f.TopLevel = False
        f.Dock = DockStyle.Fill
        panelbody.Controls.Add(f)
        f.BringToFront()
        f.Show()
    End Sub

    Private Sub dashboard2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class