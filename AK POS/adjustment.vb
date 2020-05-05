Public Class adjustment
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    Private Sub lblclose_Click(sender As Object, e As EventArgs) Handles lblclose.Click
        Me.Close()
    End Sub

    Private Sub Panel2_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel2.MouseDown, Label3.MouseDown, MyBase.MouseDown
        drag = True 'Sets the variable drag to true.
        mousex = Windows.Forms.Cursor.Position.X - Me.Left 'Sets variable mousex
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top 'Sets variable mousey
    End Sub

    Private Sub Panel2_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel2.MouseMove, Label3.MouseMove, MyBase.MouseMove
        'If drag is set to true then move the form accordingly.
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub Panel2_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel2.MouseUp, Label3.MouseUp, MyBase.MouseUp
        drag = False 'Sets drag to false, so the form does not move according to the code in MouseMove
    End Sub

    Private Sub adjustment_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub btnchangetendertype_Click(sender As Object, e As EventArgs) Handles btnchangetendertype.Click
        Dim frm As New change_tendertype()
        frm.ShowDialog()
    End Sub

    Private Sub btnchangeoverpullout_Click(sender As Object, e As EventArgs) Handles btnchangeoverpullout.Click
        Dim frm As New over_pullout()
        frm.ShowDialog()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        MessageBox.Show("Under Development", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub btnpos_Click(sender As Object, e As EventArgs) Handles btnpos.Click
        Dim frm As New add_pos()
        frm.ShowDialog()
    End Sub
End Class