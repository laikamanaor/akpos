Imports System.Data.SqlClient
Imports System.IO
Imports AK_POS.connection_class
Public Class orders
    Dim cc As New connection_class
    Dim con As New SqlConnection(cc.conString)
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader

    Public Function decryptConString() As String
        Dim base64encoded As String = File.ReadAllText("connectionstring.txt")
        Dim data As Byte() = System.Convert.FromBase64String(base64encoded)
        Return System.Text.ASCIIEncoding.ASCII.GetString(data)
    End Function

    Private Sub orders_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadCashiers()
        cmbtendertype.SelectedIndex = 0
        cmbtype.SelectedIndex = 0
        btnlogs.PerformClick()
    End Sub

    Public Sub loadCashiers()
        Try
            cmbcustomers.Items.Clear()
            cmbcustomers.Items.Add("All")
            con.Open()
            cmd = New SqlCommand("SELECT username FROM tblusers WHERE workgroup='Sales' or workgroup='Manager' AND status=1;", con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                cmbcustomers.Items.Add(rdr("username"))
            End While
            con.Close()
            cmbcustomers.SelectedIndex = 0
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Public Sub loadTrans()
        Try
            Dim query As String = "SELECT ISNULL(ordernum,0) [ordernum],ISNULL(amtdue,0) [amtdue],ISNULL(tendertype,'') [tendertype],ISNULL(servicetype, '') [servicetype] FROM tbltransaction2 WHERE area='Sales' AND status2=@status2 AND CAST(datecreated as date)=@datee", status2 As String = IIf(btnlogs.ForeColor = Color.Black, "Paid", "Void")

            dgvorders.Rows.Clear()
            dgvitems.Rows.Clear()
            lblitemscount.Text = "ITEMS (0)"

            Dim auto As New AutoCompleteStringCollection()
            If cmbcustomers.SelectedIndex = 0 And cmbtendertype.SelectedIndex <> 0 Then
                query &= " AND tendertype='" & cmbtendertype.SelectedItem & "'"
            ElseIf cmbcustomers.SelectedIndex <> 0 And cmbtendertype.SelectedIndex = 0 Then
                query &= " AND cashier='" & cmbcustomers.SelectedItem & "'"
            ElseIf cmbcustomers.SelectedIndex <> 0 And cmbtendertype.SelectedIndex <> 0 Then
                query &= " AND tendertype='" & cmbtendertype.SelectedItem & "' AND cashier='" & cmbcustomers.SelectedItem & "'"
            ElseIf cmbtype.SelectedIndex <> 0 Then
                query &= " AND typez='" & cmbtype.SelectedItem & "'"
            End If
            con.Open()
            cmd = New SqlCommand(query, con)
            cmd.Parameters.AddWithValue("@datee", dtsearch.Text)
            cmd.Parameters.AddWithValue("@status2", status2)
            rdr = cmd.ExecuteReader
            While rdr.Read
                auto.Add(rdr("ordernum"))
                dgvorders.Rows.Add(rdr("ordernum"), CDbl(rdr("amtdue")).ToString("n2"), rdr("tendertype"), rdr("servicetype"))
            End While
            con.Close()
            txtsearch.AutoCompleteCustomSource = auto
            lbltranscount.Text = "TRANSACTIONS (" & dgvorders.RowCount.ToString & ")"
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub dgvorders_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvorders.CellDoubleClick
        Try
            If btnvoids.ForeColor = Color.Black Then
                Dim frm As New void_reason()
                frm.ordernum = dgvorders.CurrentRow.Cells("transnum").Value
                frm.ShowDialog()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub btnlogs_Click(sender As Object, e As EventArgs) Handles btnlogs.Click
        lbldate.Text = "TIME_NOT_FOUND"
        btnlogs.ForeColor = Color.Black
        btnvoids.ForeColor = Color.White
        loadTrans()
    End Sub

    Private Sub btnvoids_Click(sender As Object, e As EventArgs) Handles btnvoids.Click
        lbldate.Text = "TIME_NOT_FOUND"
        btnvoids.ForeColor = Color.Black
        btnlogs.ForeColor = Color.White
        loadTrans()
    End Sub

    Private Sub cmbcustomers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbcustomers.SelectedIndexChanged
        loadTrans()
    End Sub

    Private Sub dtsearch_ValueChanged(sender As Object, e As EventArgs) Handles dtsearch.ValueChanged
        loadTrans()
    End Sub

    Private Sub cmbtendertype_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbtendertype.SelectedIndexChanged
        loadTrans()
    End Sub

    Private Sub cmbtype_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbtype.SelectedIndexChanged
        loadTrans()
    End Sub
    Public Sub search()
        Try
            If dgvorders.Rows.Count <> 0 Then
                If Not String.IsNullOrEmpty(txtsearch.Text) Then
                    For index As Integer = 0 To dgvorders.RowCount - 1
                        If txtsearch.Text = dgvorders.Rows(index).Cells("transnum").Value Then
                            dgvorders.Rows(index).Selected = True
                            dgvorders.CurrentCell = dgvorders.Rows(index).Cells("transnum")
                        Else
                            dgvorders.Rows(index).Selected = False
                        End If
                    Next
                Else
                    For index As Integer = 0 To dgvorders.RowCount - 1
                        dgvorders.Rows(index).Selected = False
                    Next
                    dgvorders.Rows(0).Selected = True
                    dgvorders.CurrentCell = dgvorders.Rows(0).Cells("transnum")
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Private Sub btnsearch_Click(sender As Object, e As EventArgs) Handles btnsearch.Click
        search()
    End Sub

    Private Sub txtsearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtsearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            search()
        End If
    End Sub

    Private Sub dgvorders_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvorders.CellClick
        dgvitems.Rows.Clear()

        con.Open()
        cmd = New SqlCommand("SELECT datecreated FROM tbltransaction2 WHERE ordernum=@onum AND CAST(datecreated AS date)='" & dtsearch.Text & "';", con)
        cmd.Parameters.AddWithValue("@onum", dgvorders.CurrentRow.Cells("transnum").Value)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            lbldate.Text = "TIME: " & CDate(rdr("datecreated")).ToString("hh:mm:tt")
        End If
        con.Close()

        con.Open()
        cmd = New SqlCommand("SELECT itemname,qty,price,dscnt,totalprice,request,free FROM tblorder2 WHERE ordernum=@ordernum AND CAST(datecreated AS date)='" & dtsearch.Text & "';", con)
        cmd.Parameters.AddWithValue("@ordernum", dgvorders.CurrentRow.Cells("transnum").Value)
        rdr = cmd.ExecuteReader
        While rdr.Read
            dgvitems.Rows.Add(rdr("itemname"), rdr("qty"), CDbl(rdr("price")).ToString("n2"), rdr("dscnt"), CDbl(rdr("totalprice")).ToString("n2"), rdr("request"), IIf(CInt(rdr("free")) = 1, True, False))
        End While
        con.Close()
        lblitemscount.Text = "ITEMS (" & dgvitems.RowCount.ToString & ")"
    End Sub
End Class