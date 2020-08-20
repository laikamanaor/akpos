Public Class Form1
    Dim price As Double = 4.0
    Private Sub txtquantity_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtquantity.KeyPress, txtdiscount.KeyPress, txtamount.KeyPress
        If Not Char.IsControl(e.KeyChar) And Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        txtquantity.Text = CInt(txtquantity.Text) + 1
        If CDbl(txtdiscount.Text) < 0 Then
            txtamount.Text = CDbl(CInt(txtquantity.Text) * price).ToString("n2")
        Else
            Dim priceBefore As Double = CDbl(CInt(txtquantity.Text) * price)
            txtamount.Text = CDbl(priceBefore - (CDbl(txtdiscount.Text) / 100) * priceBefore).ToString("n2")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If CInt(txtquantity.Text) > 1 Then
            txtquantity.Text = CInt(txtquantity.Text) - 1

            If CDbl(txtdiscount.Text) < 0 Then
                txtamount.Text = CDbl(CInt(txtquantity.Text) * price).ToString("n2")
            Else
                Dim priceBefore As Double = CDbl(CInt(txtquantity.Text) * price)
                txtamount.Text = CDbl(priceBefore - (CDbl(txtdiscount.Text) / 100) * priceBefore).ToString("n2")
            End If

        End If
    End Sub

    Private Sub txtdiscount_TextChanged(sender As Object, e As EventArgs) Handles txtdiscount.TextChanged
        Try
            If CInt(txtquantity.Text) < 0 Then
                txtdiscount.Text = "0"
            ElseIf CInt(txtquantity.Text) > 0 Then
                Dim discountPercent As Double = 0.00,
                    priceBefore As Double = CInt(txtquantity.Text) * price
                If CDbl(txtdiscount.Text) < 25 Then

                    discountPercent = CDbl(txtdiscount.Text)
                    txtamount.Text = CDbl(priceBefore - (discountPercent / 100) * priceBefore)
                    Exit Sub
                ElseIf CDbl(txtdiscount.Text) >= 25 Then

                    'discountPercent = 25
                    'txtdiscount.Text = "25"
                    discountPercent = CDbl(txtdiscount.Text)
                    txtamount.Text = CDbl(priceBefore - (discountPercent / 100) * priceBefore)
                End If
            End If
        Catch ex As Exception
            If String.IsNullOrEmpty(txtdiscount.Text) Then
                txtamount.Text = CDbl(CInt(txtquantity.Text) * price).ToString("n2")
                Exit Sub
            End If
        End Try
    End Sub

    Private Sub txtamount_TextChanged(sender As Object, e As EventArgs) Handles txtamount.TextChanged
        Try
            Dim priceBefore As Double = CInt(txtquantity.Text) * price
            If CDbl(txtamount.Text) > priceBefore Then
                txtdiscount.Text = ((priceBefore - CDbl(txtamount.Text)) / priceBefore) * 100
                txtamount.Text = priceBefore
                Exit Sub
            Else
                txtdiscount.Text = ((priceBefore - CDbl(txtamount.Text)) / priceBefore) * 100
                Exit Sub
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtquantity.Text = "1"
        txtdiscount.Text = "0"
    End Sub

    Private Sub txtamount_Leave(sender As Object, e As EventArgs) Handles txtamount.Leave
        If String.IsNullOrEmpty(txtamount.Text) OrElse CDbl(txtamount.Text) < 0 Then
            txtdiscount.Text = "0"
            txtamount.Text = "0.00"
        End If
    End Sub
End Class