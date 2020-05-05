Imports AK_POS.connection_class
Imports AK_POS.branch_class
Public Class branches
    Dim cc As New connection_class(), brc As New branch_class()
    Dim offset As Integer = 0, totalCount As Integer = 0, totalPage As Integer = 0, currentPage As Integer = 1, rowsFetch As Integer = 50
    Private Sub branches_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub branches_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbstatus.SelectedIndex = 0
        totalCount = brc.countData()
        totalPage = Math.Ceiling(totalCount / rowsFetch) * 1
        loadData()
    End Sub

    Private Sub btnnext_Click(sender As Object, e As EventArgs) Handles btnnext.Click
        offset += rowsFetch
        currentPage += 1
        If offset <= totalCount Then
            loadData()
            brc.setBranchCode(txtsearch.Text)
            brc.setStatus(IIf(cmbstatus.SelectedIndex = 0, 1, 0))
            totalCount = brc.countData()
            totalPage = Math.Ceiling(totalCount / rowsFetch) * 1
            lblcount.Text = "Page: " & currentPage & "/" & totalPage
        Else
            offset -= rowsFetch
            currentPage -= 1
            lblcount.Text = "Page: " & currentPage & "/" & totalPage
        End If
    End Sub

    Private Sub btnprev_Click(sender As Object, e As EventArgs) Handles btnprev.Click
        If offset > 0 Then
            offset -= rowsFetch
            currentPage -= 1
            loadData()
            brc.setBranchCode(txtsearch.Text)
            brc.setStatus(IIf(cmbstatus.SelectedIndex = 0, 1, 0))
            totalCount = brc.countData()
            totalPage = Math.Ceiling(totalCount / rowsFetch) * 1
            lblcount.Text = "Page: " & currentPage & "/" & totalPage
        Else
            offset = 0
            currentPage = 1
            lblcount.Text = "Page: " & currentPage & "/" & totalPage
        End If
    End Sub

    Private Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        addbranch.clear()
        addbranch.ShowDialog()
        refreshh()
    End Sub

    Private Sub dgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellClick
        If dgv.Rows.Count <> 0 Then
            If e.ColumnIndex = 6 Then
                addbranch.clear()
                addbranch.lblheader.Text = "EDIT BRANCH"
                addbranch.brid = dgv.CurrentRow.Cells("brid").Value
                addbranch.ShowDialog()
                refreshh()
            End If
        End If
    End Sub

    Private Sub cmbstatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbstatus.SelectedIndexChanged
        refreshh()
    End Sub

    Private Sub btnsearch_Click(sender As Object, e As EventArgs) Handles btnsearch.Click
        refreshh()
    End Sub

    Private Sub txtsearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtsearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            refreshh()
        End If
    End Sub
    Public Sub refreshh()
        currentPage = 1
        offset = 0
        brc.setBranchCode(txtsearch.Text)
        brc.setStatus(IIf(cmbstatus.SelectedIndex = 0, 1, 0))
        totalCount = brc.countData()
        totalPage = Math.Ceiling(totalCount / rowsFetch) * 1
        lblcount.Text = "Page: " & currentPage & "/" & totalPage
        loadData()
    End Sub
    Public Sub loadData()
        Try
            Dim dtData As New DataTable()
            brc.setBranchCode(txtsearch.Text)
            brc.setStatus(IIf(cmbstatus.SelectedIndex = 0, 1, 0))
            dtData = brc.loadData(offset, rowsFetch)
            dgv.Rows.Clear()
            Dim auto As New AutoCompleteStringCollection()
            For Each r0w As DataRow In dtData.Rows
                dgv.Rows.Add(r0w("brid"), r0w("branchcode"), r0w("branch"), r0w("gr"), r0w("sales"), IIf(r0w("status") = 1, "Active", "In Active"))
                auto.Add(r0w("branchcode"))
            Next
            txtsearch.AutoCompleteCustomSource = auto
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            cc.con.Close()
        End Try
    End Sub
End Class