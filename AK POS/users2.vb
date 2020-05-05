Imports AK_POS.user_class
Public Class users2
    Dim userc As New user_class()
    Dim offset As Integer = 0, totalCount As Integer = 0, totalPage As Integer = 0, currentPage As Integer = 1, rowsFetch As Integer = 50

    Private Sub btnnext_Click(sender As Object, e As EventArgs) Handles btnnext.Click
        offset += rowsFetch
        currentPage += 1
        If offset <= totalCount Then
            loadData()
            userc.setUsername(txtsearch.Text)
            userc.setStatus(IIf(cmbstatus.SelectedIndex = 0, 1, 0))
            userc.setWorkgroup(cmbworkgroup.Text)
            totalCount = userc.countData()
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
            userc.setUsername(txtsearch.Text)
            userc.setStatus(IIf(cmbstatus.SelectedIndex = 0, 1, 0))
            userc.setWorkgroup(cmbworkgroup.Text)
            totalCount = userc.countData()
            totalPage = Math.Ceiling(totalCount / rowsFetch) * 1
            lblcount.Text = "Page: " & currentPage & "/" & totalPage
        Else
            offset = 0
            currentPage = 1
            lblcount.Text = "Page: " & currentPage & "/" & totalPage
        End If
    End Sub
    Public Sub refreshh()
        currentPage = 1
        offset = 0
        userc.setUsername(txtsearch.Text)
        userc.setStatus(IIf(cmbstatus.SelectedIndex = 0, 1, 0))
        userc.setWorkgroup(cmbworkgroup.Text)
        totalCount = userc.countData()
        totalPage = Math.Ceiling(totalCount / rowsFetch) * 1
        lblcount.Text = "Page: " & currentPage & "/" & totalPage
        loadData()
    End Sub

    Private Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        adduser.lblheader.Text = "ADD USER"
        adduser.ShowDialog()
        refreshh()
    End Sub

    Private Sub dgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellClick
        Try
            If dgv.Rows.Count <> 0 Then
                If e.ColumnIndex = 7 Then
                    adduser.lblheader.Text = "EDIT USER"
                    adduser.userid = dgv.CurrentRow.Cells("userid").Value
                    adduser.ShowDialog()
                    refreshh()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub users2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbworkgroup.SelectedIndex = 0
        cmbstatus.SelectedIndex = 0
        totalCount = userc.countData()
        totalPage = Math.Ceiling(totalCount / rowsFetch) * 1
        loadData()
    End Sub
    Public Sub loadData()
        Dim dtesult As New DataTable()
        userc.setUsername(txtsearch.Text)
        userc.setWorkgroup(cmbworkgroup.Text)
        userc.setStatus(IIf(cmbstatus.SelectedIndex = 0, 1, 0))
        dtesult = userc.loadData(offset, rowsFetch)
        dgv.Rows.Clear()
        Dim auto As New AutoCompleteStringCollection
        For Each r0w As DataRow In dtesult.Rows
            dgv.Rows.Add(r0w("systemid"), r0w("fullname"), r0w("username"), r0w("workgroup"), r0w("branchcode"), IIf(r0w("status") = 1, "Active", "In Active"), r0w("postype"))
            auto.Add(r0w("username"))
        Next
        txtsearch.AutoCompleteCustomSource = auto
    End Sub

    Private Sub cmbworkgroup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbworkgroup.SelectedIndexChanged, cmbstatus.SelectedIndexChanged, btnsearch.Click
        refreshh()
    End Sub

    Private Sub txtsearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtsearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            refreshh()
        End If
    End Sub
End Class