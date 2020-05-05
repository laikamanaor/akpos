Imports System.Data.SqlClient
Imports AK_POS.connection_class
Public Class saplogs
    Dim cc As New connection_class
    Dim strconn As String = cc.conString
    Dim con As New SqlConnection(strconn)
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader

    Private Sub saplogs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.KeyPreview = False
            dgv.Rows.Clear()
            con.Open()
            cmd = New SqlCommand("SELECT item_code,item_name,category,quantity,charge FROM tblproduction WHERE transaction_number=@transnum AND sap_number=@sapno ORDER BY item_name", con)
            cmd.Parameters.AddWithValue("@transnum", lbltransnum.Text)
            cmd.Parameters.AddWithValue("@sapno", lblsap.Text)
            rdr = cmd.ExecuteReader
            While rdr.Read
                dgv.Rows.Add(rdr("item_code"), rdr("item_name"), rdr("category"), rdr("quantity"), rdr("charge"))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub saplogs_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class