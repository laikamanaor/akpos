Imports System.Data.SqlClient
Imports System.IO
Public Class reprintorder
    Dim strconn As String = login.ss
    Dim con As New SqlConnection(strconn)
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader

    Public Function decryptConString() As String
        Dim base64encoded As String = File.ReadAllText("connectionstring.txt")
        Dim data As Byte() = System.Convert.FromBase64String(base64encoded)
        Return System.Text.ASCIIEncoding.ASCII.GetString(data)
    End Function

    Private Sub reprintorder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        load_orders()
    End Sub
    Public Sub load_orders()
        dgvlists.Rows.Clear()
        dgvlists.Columns("amountdue").DefaultCellStyle.Format = "n2"
        con.Open()
        cmd = New SqlCommand("SELECT ordernum,customer,tendertype,amtdue,createdby FROM tbltransaction2 WHERE status2='Unpaid' AND area='" & "Sales" & "';", con)
        rdr = cmd.ExecuteReader()
        While rdr.Read
            dgvlists.Rows.Add(rdr("ordernum"), rdr("customer"), rdr("tendertype"), rdr("amtdue"), rdr("createdby"))
        End While
        con.Close()
    End Sub

    Private Sub dgvlists_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvlists.CellContentClick
        If e.ColumnIndex = 5 Then

            receiptordernumber.ordernum = dgvlists.CurrentRow.Cells("ordernum").Value
            receiptordernumber.ShowDialog()
        End If
    End Sub

    Private Sub dgvlists_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvlists.CellDoubleClick
        Try
            dgvitems.Rows.Clear()
            con.Open()
            cmd = New SqlCommand("SELECT itemname,qty,price,dscnt,totalprice,request,free FROM tblorder2 WHERE ordernum=@ordernum", con)
            cmd.Parameters.AddWithValue("@ordernum", dgvlists.CurrentRow.Cells("ordernum").Value)
            rdr = cmd.ExecuteReader()
            While rdr.Read

                Dim z As Boolean = False

                If CDbl(rdr("free")) = 1 Then
                    z = True
                Else
                    z = False
                End If

                dgvitems.Rows.Add(rdr("itemname"), rdr("qty"), rdr("price"), rdr("dscnt"), rdr("totalprice"), rdr("request"), z)
            End While
            con.Close()
            dgvitems.Columns("quantity").DefaultCellStyle.Format = "n2"
            dgvitems.Columns("price").DefaultCellStyle.Format = "n2"
            dgvitems.Columns("discountpercent").DefaultCellStyle.Format = "n2"
            dgvitems.Columns("amt").DefaultCellStyle.Format = "n2"
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub dgvlists_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvlists.DataError
        e.Cancel = False
    End Sub

    Private Sub reprintorder_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        load_orders()
    End Sub
End Class