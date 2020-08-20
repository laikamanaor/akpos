Imports System.Data.SqlClient
Public Class lastorders
    Dim cc As New connection_class
    Dim uic As New ui_class
    Dim sql As String
    Dim con As New SqlConnection(cc.conString)
    Dim rdr As SqlDataReader
    Dim cmd As SqlCommand
    Private Sub lastorders_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.KeyPreview = True
            con.Open()
            cmd = New SqlCommand("SELECT TOP 10 ordernum,tendertype,status2 FROM tbltransaction2 WHERE cashier=@cashier AND CAST(datecreated AS date)=(SELECT CAST(GETDATE() AS date)) ORDER BY ordernum DESC", con)
            cmd.Parameters.AddWithValue("@cashier", login.username)
            rdr = cmd.ExecuteReader
            While rdr.Read
                dgvorders.Rows.Add(rdr("ordernum"), rdr("tendertype"), rdr("status2"))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub dgvorders_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvorders.CellClick
        Try
            dgvitems.Rows.Clear()

            con.Open()
            cmd = New SqlCommand("SELECT itemname,qty,price,dscnt,totalprice,free FROM tblorder2 WHERE ordernum=@ordernum AND CAST(datecreated AS date)=(SELECT CAST(GETDATE() AS date))", con)
            cmd.Parameters.AddWithValue("@ordernum", dgvorders.CurrentRow.Cells("ordernum").Value)
            rdr = cmd.ExecuteReader
            While rdr.Read
                dgvitems.Rows.Add(rdr("itemname"), rdr("qty"), CDbl(rdr("price")), rdr("dscnt"), CDbl(rdr("totalprice")), IIf(rdr("free") = 1, True, False))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub lastorders_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub

    Private Sub lblclose_Click(sender As Object, e As EventArgs) Handles lblclose.Click
        Me.Close()
    End Sub

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown, MyBase.MouseDown, Label1.MouseDown
        uic.mouse_down(Me)
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove, MyBase.MouseMove, Label1.MouseMove
        uic.mouse_move(Me)
    End Sub

    Private Sub Panel1_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel1.MouseUp, MyBase.MouseUp, Label1.MouseUp
        uic.mouse_up()
    End Sub
End Class