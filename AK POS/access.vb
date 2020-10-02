Public Class access
    Dim cc As New connection_class()
    Dim accessc As New access_class()
    Private Sub access_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadData()
    End Sub

    Public Sub loadData()
        Dim result As New DataTable()
        result = accessc.loadAccess()
        dgv.Rows.Clear()

        For Each r0w As DataRow In result.Rows
            Dim status As String = IIf(r0w("status") <= 0, "Active", "In Active")
            dgv.Rows.Add(False, r0w("id"), r0w("module"), r0w("username"), status)
        Next
        lblnofound.Visible = IIf(dgv.Rows.Count <= 0, True, False)
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim frm As New access_add()
        frm.ShowDialog()
        loadData()
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click

    End Sub
End Class