Imports MessagingToolkit.QRCode.Codec.QRCodeEncoder
Public Class ar_cancel
    Dim qrCode As New MessagingToolkit.QRCode.Codec.QRCodeEncoder

    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        If String.IsNullOrEmpty(txt.Text) Then
            MessageBox.Show("Insert text", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            PictureBox1.Image = qrCode.Encode(txt.Text)
        End If
    End Sub

    Private Sub txt_KeyDown(sender As Object, e As KeyEventArgs) Handles txt.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnGenerate.PerformClick()
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim qrcode As New MessagingToolkit.QRCode.Codec.QRCodeEncoder
        Dim sfd As New SaveFileDialog
        sfd.Title = "Save QR Code"
        sfd.FileName = txt.Text
        sfd.Filter = "PNG (*.png) | *.png"
        If sfd.ShowDialog = Windows.Forms.DialogResult.OK Then
            PictureBox1.Image.Save(sfd.FileName)
            MessageBox.Show("Saved", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub PictureBox1_Paint(sender As Object, e As PaintEventArgs) Handles PictureBox1.Paint
        Dim stringtoDraw As String = txt.Text
        Dim myBrush As New SolidBrush(Color.Red)
        Dim stringFont As New Font("Arial", 20)
        Dim pixelsCross As Integer = 90
        Dim pixelDown As Integer = 60
        e.Graphics.DrawString(stringtoDraw, stringFont, myBrush, pixelsCross, pixelDown)
    End Sub
End Class