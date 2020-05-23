Imports AK_POS.conversion_class
Imports AK_POS.received_class
Public Class conv_logs
    Dim convc As New conversion_class(), recc As New received_class()
    Private Sub conv_logs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtdate.Text = DateTime.Now.ToString("MM/dd/yyyy")
        loadCategories()
        loadConvOut()
    End Sub

    ''' <summary>
    ''' load categories to combobox
    ''' </summary>
    Public Sub loadCategories()
        Dim result As New DataTable()
        result = recc.loadCategories()
        cmbcategory.Items.Clear()
        cmbcategoryy.Items.Clear()
        cmbcategory.Items.Add("All")
        cmbcategoryy.Items.Add("All")
        For Each r0w As DataRow In result.Rows
            cmbcategory.Items.Add(r0w("result"))
            cmbcategoryy.Items.Add(r0w("result"))
        Next
        cmbcategory.SelectedIndex = 0
        cmbcategoryy.SelectedIndex = 0
    End Sub

    Private Sub btnsearch_Click(sender As Object, e As EventArgs) Handles btnsearch.Click
        loadConvOut()
    End Sub

    Public Sub loadConvOut()
        convc.typee = "Parent"
        convc.dateParameter = dtdate.Text
        convc.category = cmbcategory.Text
        convc.itemname = txtboxsearch.Text
        Dim result As New DataTable(), auto As New AutoCompleteStringCollection()
        result = convc.loadConvOut()
        dgv.Rows.Clear()
        dgvv.Rows.Clear()
        For Each r0w As DataRow In result.Rows
            dgv.Rows.Add(r0w("convnum"), r0w("category"), r0w("itemname"), CInt(r0w("quantity")).ToString("N0"), CDate(r0w("timee")).ToString("hh:mm tt"))
            auto.Add(r0w("itemname"))
        Next
        txtboxsearch.AutoCompleteCustomSource = auto
    End Sub

    Private Sub btnsearchh_Click(sender As Object, e As EventArgs) Handles btnsearchh.Click
        loadConvIn()
    End Sub

    Private Sub txtboxsearchh_KeyDown(sender As Object, e As KeyEventArgs) Handles txtboxsearchh.KeyDown
        If e.KeyCode = Keys.Enter Then
            loadConvIn()
        End If
    End Sub

    Private Sub cmbcategoryy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbcategoryy.SelectedIndexChanged
        loadConvIn()
    End Sub

    Private Sub dtdate_ValueChanged(sender As Object, e As EventArgs) Handles dtdate.ValueChanged
        loadConvOut()
        dgvv.Rows.Clear()
    End Sub

    Private Sub cmbcategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbcategory.SelectedIndexChanged
        loadConvOut()
    End Sub

    Private Sub txtboxsearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtboxsearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            loadConvOut()
        End If
    End Sub

    Private Sub dgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellClick
        loadConvIn()
    End Sub

    Public Sub loadConvIn()
        If dgv.Rows.Count <> 0 Then
            convc.typee = "Child"
            convc.dateParameter = dtdate.Text
            convc.category = cmbcategoryy.Text
            convc.itemname = txtboxsearchh.Text
            convc.refnum = dgv.CurrentRow.Cells("convnum").Value
            Dim result As New DataTable(), auto As New AutoCompleteStringCollection()
            result = convc.loadConvIn()
            dgvv.Rows.Clear()
            For Each r0w As DataRow In result.Rows
                dgvv.Rows.Add(r0w("convnum"), r0w("category"), r0w("itemname"), CInt(r0w("quantity")).ToString("N0"), CDate(r0w("timee")).ToString("hh:mm tt"))
                auto.Add(r0w("itemname"))
                lblinsap.Text = r0w("sap")
                lblinremarks.Text = r0w("remarks")
                lbloutsap.Text = r0w("outSAP")
                lbloutremarks.Text = r0w("outRemarks")
            Next
            txtboxsearchh.AutoCompleteCustomSource = auto
        Else
            lblinsap.Text = ""
            lblinremarks.Text = ""
            lbloutsap.Text = ""
            lbloutremarks.Text = ""
            dgvv.Rows.Clear()
        End If
    End Sub
End Class