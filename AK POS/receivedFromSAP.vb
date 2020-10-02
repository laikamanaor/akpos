Imports System.Data.SqlClient
Public Class receivedFromSAP
    Dim cc As New connection_class()
    Private Sub receivedFromSAP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Control.CheckForIllegalCrossThreadCalls = False
        cmbtype.SelectedIndex = 0
    End Sub

    Public Sub tt()
        Control.CheckForIllegalCrossThreadCalls = False
        Dim th As New Threading.Thread(AddressOf loadData)
        th.Start()
    End Sub

    Public Sub enableDisable(ByVal value As Boolean)
        txtSearch.Enabled = value
        btnsearch.Enabled = value
        cmbtype.Enabled = value
    End Sub

    Public Sub loadData()
        dgv.Rows.Clear()
        lblNoDataFound.Visible = False
        enableDisable(False)
        Dim receievedType As String = IIf(cmbtype.SelectedIndex.Equals(1), "A1 P-FG", "")

        If cmbtype.SelectedIndex.Equals(0) Then
            receievedType = "FromWhsCod LIKE '%%'"
        ElseIf cmbtype.SelectedIndex.Equals(1) Then
            receievedType = "FromWhsCod LIKE '%A1 P-FG%'"
        ElseIf cmbtype.SelectedIndex.Equals(2) Then
            receievedType = "NOT FromWhsCod LIKE '%A1 P-FG%'"
        End If

        Dim adptr As New SqlClient.SqlDataAdapter, result As New DataTable, auto As New AutoCompleteStringCollection
        Dim query As String = "SELECT DISTINCT docNum [sap_number], FromWhsCod [fromWhat] FROM vSAP_IT WHERE CAST(DocDate AS date)=(select cast(getdate() as date)) AND " & receievedType & " AND docNum LIKE '%" & IIf(txtSearch.Text.Equals("Search SAP #"), "", txtSearch.Text) & "%' ORDER BY docNum"
        'Dim query As String = "SELECT docNum [sap_number], ItemCode [item_code],Dscription [item_name],Quantity [quantity], FromWhsCod [fromWhat] FROM vSAP_IT WHERE CAST(DocDate AS date)=(select cast(getdate() as date)) ORDER BY FromWhsCod"
        spinner.Visible = True
        Try

            If cc.con.State = ConnectionState.Open Then
                cc.con.Close()
            End If

            cc.con.Open()
            cc.cmd = New SqlClient.SqlCommand(query, cc.con)
            adptr.SelectCommand = cc.cmd
            adptr.Fill(result)
            cc.con.Close()
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show("No Internet Connection", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            cc.con.Close()
        End Try

        Try
            If result.Rows.Count <> 0 Then
                For Each r0w As DataRow In result.Rows
                    cc.con.Open()
                    cc.cmd = New SqlClient.SqlCommand("SELECT transaction_id FROM tblproduction WHERE CAST(date AS date)=(select cast(getdate() as date)) AND sap_number=@sapNumber AND sap_number !='To Follow' AND status='Completed';", cc.con)
                    cc.cmd.Parameters.AddWithValue("@sapNumber", r0w("sap_number").ToString)
                    cc.rdr = cc.cmd.ExecuteReader
                    If Not cc.rdr.Read Then
                        Dim sap_number As String = r0w("sap_number")
                        Dim fromWhat As String = r0w("fromWhat")
                        Dim fromReceived As String = IIf(fromWhat.Equals("A1 P-FG"), "Received from Production", "Received from Other Branch")
                        dgv.Rows.Add(sap_number, fromReceived, fromWhat)
                        Me.Refresh()
                    End If
                    cc.con.Close()
                Next
            End If
            spinner.Visible = False
            Me.Cursor = Cursors.Default
            lblCount.Text = "Pending (" & dgv.Rows.Count.ToString("N0") & ")"
            lblNoDataFound.Visible = IIf(dgv.Rows.Count <> 0, False, True)
            lblNoDataFound.Text = IIf(dgv.Rows.Count <> 0, "NO DATA FOUND", "")
            enableDisable(True)
        Catch ex As Exception
            MessageBox.Show("No Internet Connection", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            cc.con.Close()
        End Try

    End Sub


    Private Sub cmbtype_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbtype.SelectedIndexChanged
        tt()
    End Sub

    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            tt()
        End If
    End Sub

    Private Sub dgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellDoubleClick
        If dgv.Rows.Count <> 0 Then
            Dim frm As New receivedFromSAPItems()
            frm.sapNumber = dgv.CurrentRow.Cells("sapNumber").Value.ToString
            frm.ShowDialog()
            tt()
        End If
    End Sub

    Private Sub btnsearch_Click(sender As Object, e As EventArgs) Handles btnsearch.Click
        tt()
    End Sub

    Private Sub txtSearch_Enter(sender As Object, e As EventArgs) Handles txtSearch.Enter
        If txtSearch.Text.Equals("Search SAP #") Then
            txtSearch.Text = ""
            txtSearch.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txtSearch_Leave(sender As Object, e As EventArgs) Handles txtSearch.Leave
        If txtSearch.Text.Equals("") Then
            txtSearch.Text = "Search SAP #"
            txtSearch.ForeColor = Color.LightGray
        End If
    End Sub

    Private Sub txtSearch_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSearch.KeyPress
        If Not Char.IsControl(e.KeyChar) And Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
End Class