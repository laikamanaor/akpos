Imports AK_POS.ui_class
Imports AK_POS.cashier_class
Public Class void
    Dim uic As New ui_class(), cashc As New cashier_class()
    Public orderid As Integer = 0
    Private Sub void_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub btnclose_Click_1(sender As Object, e As EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub


    Private Sub Panel6_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel6.MouseDown, MyBase.MouseDown, Label1.MouseDown
        uic.mouse_down(Me)
    End Sub

    Private Sub Panel6_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel6.MouseMove, MyBase.MouseMove, Label1.MouseMove
        uic.mouse_move(Me)
    End Sub

    Private Sub Panel6_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel6.MouseUp, MyBase.MouseUp, Label1.MouseUp
        uic.mouse_up()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub void_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txtreason.Focus()
    End Sub

    Private Sub txtreason_KeyDown(sender As Object, e As KeyEventArgs) Handles txtreason.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnsubmit.PerformClick()
        End If
    End Sub

    Private Sub btnsubmit_Click(sender As Object, e As EventArgs) Handles btnsubmit.Click
        cashc.reason = txtreason.Text
        cashc.orderid = orderid
        If String.IsNullOrEmpty(Trim(txtreason.Text)) Then
            MessageBox.Show("Reason field is required", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf txtreason.Text.Length <= 1 Then
            MessageBox.Show("Reason field is too short", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf cashc.returnOrderStatus() <> "Unpaid" Then
            MessageBox.Show("#" & orderid & " is already " & cashc.returnOrderStatus(), "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim a As String = MsgBox("Are you sure you want to void?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Atlantic Bakery")
            If a = vbYes Then
                cashc.voidOrder()
                Me.Close()
            End If
        End If
    End Sub
End Class