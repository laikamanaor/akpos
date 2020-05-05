Imports AK_POS.category_class
Public Class categories
    Dim catc As New category_class
    Dim offset As Integer = 0, totalCount As Integer = 0, totalPage As Integer = 0, currentPage As Integer = 1, rowsFetch As Integer = 50

    Private Sub btnprev_Click(sender As Object, e As EventArgs) Handles btnprev.Click
        If offset > 0 Then
            offset -= rowsFetch
            currentPage -= 1
            loadData()
            catc.setCategory(txtsearch.Text)
            catc.setStatus(IIf(cmbstatus.SelectedIndex = 0, 1, 0))
            totalCount = catc.countData()
            totalPage = Math.Ceiling(totalCount / rowsFetch) * 1
            lblcount.Text = "Page: " & currentPage & "/" & totalPage
        Else
            offset = 0
            currentPage = 1
            lblcount.Text = "Page: " & currentPage & "/" & totalPage
        End If
    End Sub

    Private Sub txtsearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtsearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            refreshh()
        End If
    End Sub

    Private Sub btnsearch_Click(sender As Object, e As EventArgs) Handles btnsearch.Click
        refreshh()
    End Sub

    Private Sub cmbstatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbstatus.SelectedIndexChanged
        refreshh()
    End Sub

    Private Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        addcategory.txtcategory.Text = ""
        addcategory.lblheader.Text = "ADD CATEGORY"
        addcategory.ShowDialog()
        refreshh()
    End Sub

    Private Sub dgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellClick
        Try
            If dgv.RowCount <> 0 Then
                If e.ColumnIndex = 3 Then
                    addcategory.lblheader.Text = "EDIT CATEGORY"
                    addcategory.txtcategory.Text = ""
                    addcategory.catid = dgv.CurrentRow.Cells("catid").Value
                    addcategory.ShowDialog()
                    refreshh()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub btnnext_Click(sender As Object, e As EventArgs) Handles btnnext.Click
        offset += rowsFetch
        currentPage += 1
        If offset <= totalCount Then
            loadData()
            catc.setCategory(txtsearch.Text)
            catc.setStatus(IIf(cmbstatus.SelectedIndex = 0, 1, 0))
            totalCount = catc.countData()
            totalPage = Math.Ceiling(totalCount / rowsFetch) * 1
            lblcount.Text = "Page: " & currentPage & "/" & totalPage
        Else
            offset -= rowsFetch
            currentPage -= 1
            lblcount.Text = "Page: " & currentPage & "/" & totalPage
        End If
    End Sub

    Private Sub categories_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbstatus.SelectedIndex = 0
        totalCount = catc.countData()
        totalPage = Math.Ceiling(totalCount / rowsFetch) * 1
        loadData()
    End Sub

    Public Sub loadData()
        catc.setCategory(txtsearch.Text)
        catc.setStatus(IIf(cmbstatus.SelectedIndex = 0, 1, 0))
        Dim dtData As New DataTable()
        dtData = catc.loadData(offset, rowsFetch)
        dgv.Rows.Clear()
        Dim auto As New AutoCompleteStringCollection()
        For Each r0w As DataRow In dtData.Rows
            dgv.Rows.Add(r0w("catid"), r0w("category"), IIf(r0w("status") = 1, "Active", "In Active"))
            auto.Add(r0w("category"))
        Next
        txtsearch.AutoCompleteCustomSource = auto
    End Sub
    Public Sub refreshh()
        currentPage = 1
        offset = 0
        catc.setCategory(txtsearch.Text)
        catc.setStatus(IIf(cmbstatus.SelectedIndex = 0, 1, 0))
        totalCount = catc.countData()
        totalPage = Math.Ceiling(totalCount / rowsFetch) * 1
        lblcount.Text = "Page: " & currentPage & "/" & totalPage
        loadData()
    End Sub
End Class