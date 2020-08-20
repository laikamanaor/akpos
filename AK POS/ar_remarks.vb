Public Class ar_remarks
    Dim uic As New ui_class
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

    Private Sub Panel5_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel5.MouseDown, MyBase.MouseDown, Label15.MouseDown, Label1.MouseDown
        uic.mouse_down(Me)
    End Sub

    Private Sub Panel5_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel5.MouseMove, MyBase.MouseMove, Label15.MouseMove, Label1.MouseMove
        uic.mouse_move(Me)
    End Sub

    Private Sub Panel5_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel5.MouseUp, MyBase.MouseUp, Label15.MouseUp, Label1.MouseUp
        uic.mouse_up()
    End Sub
End Class