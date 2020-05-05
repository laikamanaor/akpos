Public Class ar_remarks
    Private Sub btnsubmit_Click(sender As Object, e As EventArgs) Handles btnsubmit.Click
        subbmitt()
    End Sub
    Public Sub subbmitt()
        If String.IsNullOrEmpty(txtremarks.Text) Then
            MessageBox.Show("Enter remarks", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Me.Hide()
        End If
    End Sub
    Private Sub ar_remarks_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtremarks.Text = ""
    End Sub

    Private Sub txtremarks_KeyDown(sender As Object, e As KeyEventArgs) Handles txtremarks.KeyDown
        If e.KeyCode = Keys.Enter Then
            subbmitt()
        End If
    End Sub
End Class