Imports AK_POS.pendingsap_class
Public Class pendingsap3
    Dim sapc As New pendingsap_class()
    Private Sub pendingsap3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbtype.SelectedIndex = 0
        'dgvtrans.Rows.Add(True, "1", "Gordon", "AR Sales", "To Follow", "---", "From POS", "05:00 PM")
        'dgvtrans.Rows.Add(True, "1", "Gordon", "AR Sales", "To Follow", "---", "From POS", "05:00 PM")
        'dgvtrans.Rows.Add(True, "1", "Gordon", "AR Sales", "To Follow", "---", "From POS", "05:00 PM")
        'dgvtrans.Rows.Add(True, "1", "Gordon", "AR Sales", "To Follow", "---", "From POS", "05:00 PM")
        'dgvtrans.Rows.Add(True, "1", "Gordon", "AR Sales", "To Follow", "---", "From POS", "05:00 PM")
    End Sub

    Public Sub loadTransaction()
        If cmbtype.SelectedIndex <> 0 Then
            sapc.transnum = Trim(txtsearch.Text)
            sapc.datecreated = datee.Text
            sapc.typee = cmbtype.Text
            Dim result As New DataTable()
            result = sapc.loadTransactions()
            dgvtrans.Rows.Clear()
            For Each r0w As DataRow In result.Rows
                dgvtrans.Rows.Add(False, r0w("transnum"), r0w("name"), r0w("sapdoc"), r0w("sapnum"), r0w("remarks"), r0w("from"), CDate(r0w("time")).ToString("hh:mm tt"))
            Next
        Else
            clear()
        End If
    End Sub

    Private Sub datee_ValueChanged(sender As Object, e As EventArgs) Handles datee.ValueChanged
        loadTransaction()
    End Sub
    Public Sub clear()
        dgvtrans.Rows.Clear()
        dgvitems.Rows.Clear()
        txtsearch.Text = ""
        datee.Text = DateTime.Now.ToString("MM/dd/yyyy")
    End Sub
    Private Sub cmbtype_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbtype.SelectedIndexChanged
        If cmbtype.SelectedIndex = 0 Then
            clear()
        Else
            loadTransaction()
        End If
    End Sub

    Private Sub btnsearch_Click(sender As Object, e As EventArgs) Handles btnsearch.Click
        loadTransaction()
    End Sub

    Private Sub txtsearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtsearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            loadTransaction()
        End If
    End Sub
End Class