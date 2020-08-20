Public Class versions
    Private Sub btnaddVersion_Click(sender As Object, e As EventArgs) Handles btnaddVersion.Click
        Dim frm As New add_version
        frm.lblHeader.Text = "ADD VERSION"
        frm.ShowDialog()
    End Sub
End Class