Imports AK_POS.ui_class
Public Class receivedItem_add
    Dim uic As New ui_class()
    Public Shared isSuccess As Boolean = False
    Private Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        isSuccess = False
        Me.Hide()
    End Sub

    Private Sub receivedItem_add_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            isSuccess = False
            Me.Hide()
        End If
    End Sub


    Private Sub Panel4_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel4.MouseDown, MyBase.MouseDown, lblheader.MouseDown, Label4.MouseDown, Label3.MouseDown, Label2.MouseDown, Label1.MouseDown
        uic.mouse_down(Me)
    End Sub

    Private Sub Panel4_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel4.MouseMove, MyBase.MouseMove, lblheader.MouseMove, Label4.MouseMove, Label3.MouseMove, Label2.MouseMove, Label1.MouseMove
        uic.mouse_move(Me)
    End Sub

    Private Sub Panel4_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel4.MouseUp, MyBase.MouseUp, lblheader.MouseUp, Label4.MouseUp, Label3.MouseUp, Label2.MouseUp, Label1.MouseUp
        uic.mouse_up()
    End Sub

    Private Sub btnsubmit_Click(sender As Object, e As EventArgs) Handles btnsubmit.Click
        submit()
    End Sub

    Public Sub submit()
        If String.IsNullOrEmpty(Trim(txtquantity.Text)) Then
            MessageBox.Show("Quantity field is required", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtquantity.Focus()
        ElseIf Not IsNumeric(txtquantity.Text) Then
            MessageBox.Show("Invalid Input", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtquantity.Focus()
        ElseIf CDbl(txtquantity.Text) <= 0 Then
            MessageBox.Show("Please input atleast 1 quantity", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtquantity.Focus()
        Else
            isSuccess = True
            Me.Hide()
        End If
    End Sub

    Private Sub txtquantity_KeyDown(sender As Object, e As KeyEventArgs) Handles txtquantity.KeyDown, txtitemname.KeyDown, txtitemcode.KeyDown, txtcategory.KeyDown
        If e.KeyCode = Keys.Enter Then
            submit()
        End If
    End Sub
End Class