Public Class overwrite_short_form
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer


    Dim current_itemcode As String = "",
        current_itemname As String = "",
        current_quantity As Double = 0.00,
        current_charge As Double = 0.00,
        current_employee As String = ""
    Public isValid As Boolean = False
    Private Sub lblclose_Click(sender As Object, e As EventArgs) Handles lblclose.Click
        isValid = False
        Me.Close()
    End Sub

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown
        drag = True 'Sets the variable drag to true.
        mousex = Windows.Forms.Cursor.Position.X - Me.Left 'Sets variable mousex
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top 'Sets variable mousey
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove
        'If drag is set to true then move the form accordingly.
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub btnsubmit_Click(sender As Object, e As EventArgs) Handles btnsubmit.Click
        submit()
    End Sub

    Private Sub Panel1_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel1.MouseUp
        drag = False 'Sets drag to false, so the form does not move according to the code in MouseMove
    End Sub

    Private Sub overwrite_short_form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        current_itemcode = lblcode.Text
        current_itemname = lblname.Text
        current_quantity = txtquantity.Text
        current_charge = txtcharge.Text
        current_employee = txtemployee.Text
    End Sub

    Public Sub submit()
        Try
            If current_quantity = txtquantity.Text And current_charge = txtcharge.Text And current_employee = txtemployee.Text Then
                MessageBox.Show("You can't add item without any changes", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                isValid = True
                Me.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub txtquantity_KeyDown(sender As Object, e As KeyEventArgs) Handles txtquantity.KeyDown, txtemployee.KeyDown, txtcharge.KeyDown
        If e.KeyCode = Keys.Enter Then
            submit()
        End If
    End Sub

End Class