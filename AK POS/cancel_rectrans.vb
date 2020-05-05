Imports System.Data.SqlClient
Imports AK_POS.connection_class
Public Class cancel_rectrans
    Dim cc As New connection_class
    Dim con As New SqlConnection(cc.conString)
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader


    Private Sub cancel_rectrans_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dt.MaxDate = getSystemDate()
        dt.Text = getSystemDate.ToString("MM/dd/yyyy")
        btn1.ForeColor = Color.Black
        cmbtype.SelectedIndex = 0
    End Sub
    Public Sub loadTrans(ByVal status As String)
        Try

            If status = "Completed" Then
                dgvtrans.Columns("btncancel").Visible = True
            Else
                dgvtrans.Columns("btncancel").Visible = False
            End If
            Dim trcount As Integer = 0

            lbltr.Text = "TRANSACTIONS (0)"
            lblitems.Text = "ITEMS (0)"



            Dim serverDate As String = dt.Text
            dgvtrans.Rows.Clear()
            dgvitems.Rows.Clear()
            con.Open()

            Dim query As String = ""

            If String.IsNullOrEmpty(txtsearch.Text) Then
                query = "SELECT DISTINCT inv_id,transaction_number,type2,sap_number,remarks,processed_by FROM tblproduction WHERE type='" & cmbtype.SelectedItem & "' AND CAST(date AS date)='" & serverDate & "' AND status ='" & status & "' ORDER BY transaction_number ASC;"
            Else
                query = "SELECT DISTINCT inv_id,transaction_number,type2,sap_number,remarks,processed_by FROM tblproduction WHERE type='" & cmbtype.SelectedItem & "' AND CAST(date AS date)='" & serverDate & "' AND status ='" & status & "' AND transaction_number LIKE @search ORDER BY transaction_number ASC;"
            End If
            Dim auto As New AutoCompleteStringCollection()
            cmd = New SqlCommand(query, con)
            If Not String.IsNullOrEmpty(txtsearch.Text) Then
                cmd.Parameters.AddWithValue("@search", "%" & txtsearch.Text & "%")
            End If
            rdr = cmd.ExecuteReader
            While rdr.Read
                dgvtrans.Rows.Add(rdr("inv_id"), rdr("transaction_number"), rdr("type2"), rdr("sap_number"), rdr("remarks"), rdr("processed_by"))

                If String.IsNullOrEmpty(txtsearch.Text) Then
                    auto.Add(rdr("transaction_number"))
                End If

                trcount += 1
            End While
            con.Close()
            If String.IsNullOrEmpty(txtsearch.Text) Then
                txtsearch.AutoCompleteCustomSource = auto
            End If
            lbltr.Text = "TRANSACTIONS (" & trcount & ")"

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Public Function getSystemDate() As DateTime
        Try
            Dim dt As New DateTime()
            con.Open()
            cmd = New SqlCommand("SELECT GETDATE()", con)
            rdr = cmd.ExecuteReader()
            While rdr.Read
                dt = CDate(rdr(0).ToString)
            End While
            con.Close()
            Return dt
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Function

    Private Sub cmbtype_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbtype.SelectedIndexChanged
        loadTrans(IIf(btn1.ForeColor = Color.Black, "Completed", "Cancelled"))
    End Sub
    Private Sub dgvtrans_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvtrans.CellClick
        Try
            If e.ColumnIndex = 6 Then
                Dim result As Boolean = False
                con.Open()
                cmd = New SqlCommand("SELECT transaction_id FROM tblproduction WHERE transaction_number=@transnum AND status != 'Cancelled';", con)
                cmd.Parameters.AddWithValue("@transnum", dgvtrans.CurrentRow.Cells("transnum").Value)
                rdr = cmd.ExecuteReader
                If rdr.Read Then
                    result = True
                End If
                con.Close()

                If result = False Then
                    MessageBox.Show("This transaction is already Cancelled", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                Dim invnum As String = dgvtrans.CurrentRow.Cells("invnum").Value

                Dim errStr As String = "You can't cancel this transaction because the item(s) below of ending balance is less than the Received quantity:" & Environment.NewLine & Environment.NewLine
                con.Open()
                cmd = New SqlCommand("SELECT a.item_name,a.quantity,b.endbal AS endbal FROM tblproduction a JOIN tblinvitems b ON a.item_name = b.itemname  WHERE a.transaction_number=@transnum  AND b.invnum=@invnum;", con)
                cmd.Parameters.AddWithValue("@transnum", dgvtrans.CurrentRow.Cells("transnum").Value)
                cmd.Parameters.AddWithValue("@invnum", invnum)
                rdr = cmd.ExecuteReader
                While rdr.Read
                    If CDbl(rdr("quantity")) > CDbl(rdr("endbal")) Then
                        errStr &= rdr("item_name") & "/Ending Balance: (" & rdr("endbal") & ")/Received Item: (" & rdr("quantity") & ")" & Environment.NewLine
                    End If
                End While
                con.Close()

                If errStr <> "You can't cancel this transaction because the item(s) below of ending balance is less than the Received quantity:" & Environment.NewLine & Environment.NewLine Then
                    MessageBox.Show(errStr, "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
                Dim a As String = MsgBox("Are you sure you want to cancel this transaction?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "")
                If a = vbYes Then
                    con.Open()
                    cmd = New SqlCommand("UPDATE tblproduction SET status='Cancelled' WHERE transaction_number=@transnum;", con)
                    cmd.Parameters.AddWithValue("@transnum", dgvtrans.CurrentRow.Cells("transnum").Value)
                    cmd.ExecuteNonQuery()
                    con.Close()

                    Dim iin As String = ""
                    Select Case dgvtrans.CurrentRow.Cells("type").Value
                        Case "Received from Other Branch"
                            iin = "itemin"
                        Case "Received From Production"
                            iin = "productionin"
                        Case "Transfer"
                            iin = "transfer"
                    End Select

                    con.Open()
                    cmd = New SqlCommand("SELECT item_name,quantity,a.charge,b.variance FROM tblproduction a JOIN tblinvitems b ON a.item_name=b.itemname WHERE transaction_number=@transnum AND b.invnum=@invnum;", con)
                    cmd.Parameters.AddWithValue("@invnum", invnum)
                    cmd.Parameters.AddWithValue("@transnum", dgvtrans.CurrentRow.Cells("transnum").Value)
                    Dim dt As New DataTable()
                    Dim adptr As New SqlDataAdapter()
                    adptr.SelectCommand = cmd
                    adptr.Fill(dt)
                    con.Close()
                    For Each r0w In dt.Rows

                        Dim variance As Double = CDbl(r0w("variance"))
                        variance = variance + CDbl(r0w("quantity"))
                        con.Open()
                        cmd = New SqlCommand("UPDATE tblinvitems SET " & iin & "-=@quantity,charge-=@charge,archarge-=@charge,totalav-=@quantity,endbal-=@quantity,variance=@variance WHERE invnum=@invnum AND itemname=@itemname;", con)
                        cmd.Parameters.AddWithValue("@variance", variance)
                        cmd.Parameters.AddWithValue("@charge", CDbl(r0w("charge")))
                        cmd.Parameters.AddWithValue("@quantity", CDbl(r0w("quantity")))
                        cmd.Parameters.AddWithValue("@invnum", invnum)
                        cmd.Parameters.AddWithValue("@itemname", CStr(r0w("item_name")))
                        cmd.ExecuteNonQuery()
                        con.Close()

                        Dim tr As String = "", name As String = ""
                        con.Open()
                        cmd = New SqlCommand("SELECT transnum,name FROM tblars1 WHERE arnum=@arnum", con)
                        cmd.Parameters.AddWithValue("@arnum", dgvtrans.CurrentRow.Cells("transnum").Value)
                        rdr = cmd.ExecuteReader
                        If rdr.Read Then
                            tr = rdr("transnum")
                            name = rdr("name")
                        End If
                        con.Close()

                        con.Open()
                        cmd = New SqlCommand("DELETE FROM tblars1 WHERE name=@name AND transnum=@transnum;", con)
                        cmd.Parameters.AddWithValue("@name", name)
                        cmd.Parameters.AddWithValue("@transnum", tr)
                        cmd.ExecuteNonQuery()
                        con.Close()

                        con.Open()
                        cmd = New SqlCommand("DELETE FROM tblars2 WHERE name=@name AND transnum=@transnum;", con)
                        cmd.Parameters.AddWithValue("@name", name)
                        cmd.Parameters.AddWithValue("@transnum", tr)
                        cmd.ExecuteNonQuery()
                        con.Close()

                        con.Open()
                        cmd = New SqlCommand("", con)
                        con.Close()

                    Next

                    MessageBox.Show("Transaction Completed", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    loadTrans("Completed")
                End If
            Else
                viewItems()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Private Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click
        btn1.ForeColor = Color.Black
        btn2.ForeColor = Color.White
        loadTrans("Completed")
    End Sub

    Private Sub btn2_Click(sender As Object, e As EventArgs) Handles btn2.Click
        btn2.ForeColor = Color.Black
        btn1.ForeColor = Color.White
        loadTrans("Cancelled")
    End Sub
    Public Sub viewItems()
        If dgvtrans.RowCount <> 0 Then

            Dim itemcount As Integer = 0

            dgvitems.Rows.Clear()
            con.Open()
            cmd = New SqlCommand("SELECT item_name,category,quantity,charge FROM tblproduction WHERE transaction_number=@transnum;", con)
            cmd.Parameters.AddWithValue("@transnum", dgvtrans.CurrentRow.Cells("transnum").Value)
            rdr = cmd.ExecuteReader
            While rdr.Read
                dgvitems.Rows.Add(rdr("item_name"), rdr("category"), rdr("quantity"), rdr("charge"))
                itemcount += 1
            End While
            con.Close()

            lblitems.Text = "ITEMS (" & itemcount & ")"

        End If
    End Sub

    Private Sub txtsearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtsearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            loadTrans(IIf(btn1.ForeColor = Color.Black, "Completed", "Cancelled"))
        End If
    End Sub

    Private Sub btnsearch_Click(sender As Object, e As EventArgs) Handles btnsearch.Click
        loadTrans(IIf(btn1.ForeColor = Color.Black, "Completed", "Cancelled"))
    End Sub

    Private Sub dgvtrans_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvtrans.CellDoubleClick
        If dgvtrans.RowCount <> 0 Then
            Dim frm As New saplogs()
            frm.lblsap.Text = dgvtrans.CurrentRow.Cells("sapnumber").Value
            frm.lbltransnum.Text = dgvtrans.CurrentRow.Cells("transnum").Value
            frm.ShowDialog()
        End If
    End Sub

    Private Sub dt_ValueChanged(sender As Object, e As EventArgs) Handles dt.ValueChanged
        loadTrans(IIf(btn1.ForeColor = Color.Black, "Completed", "Cancelled"))
    End Sub
End Class