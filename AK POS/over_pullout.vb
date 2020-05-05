Imports AK_POS.pullout_class
Public Class over_pullout
    Dim poc As New pullout_class()
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    Private Sub over_pullout_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadCategories()
        loadData()
    End Sub

    Public Sub loadCategories()
        Dim dt As New DataTable()
        dt = poc.showCategories()
        cmbcategory.Items.Clear()
        cmbcategory.Items.Add("All")
        For Each r0w As DataRow In dt.Rows
            cmbcategory.Items.Add(r0w("category"))
        Next
        cmbcategory.SelectedIndex = 0
    End Sub

    Public Sub loadData()
        Dim auto As New AutoCompleteStringCollection()
        poc.setItemName(txtsearch.Text)
        poc.setCategory(cmbcategory.Text)
        poc.setDatee(dtdate.Text)
        Dim dt As New DataTable()
        dt = poc.showInventory()
        dgv.Rows.Clear()
        For Each r0w As DataRow In dt.Rows
            dgv.Rows.Add(r0w("invid"), r0w("category"), r0w("itemname"), CInt(r0w("qty")).ToString("N0"))
            auto.Add(r0w("itemname"))
        Next
        txtsearch.AutoCompleteCustomSource = auto
    End Sub
    Private Sub over_pullout_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown, MyBase.MouseDown, Label3.MouseDown
        drag = True 'Sets the variable drag to true.
        mousex = Windows.Forms.Cursor.Position.X - Me.Left 'Sets variable mousex
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top 'Sets variable mousey
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove, MyBase.MouseMove, Label3.MouseMove
        'If drag is set to true then move the form accordingly.
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub Panel1_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel1.MouseUp, MyBase.MouseUp, Label3.MouseUp
        drag = False 'Sets drag to false, so the form does not move according to the code in MouseMove
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub cmbcategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbcategory.SelectedIndexChanged
        loadData()
    End Sub

    Private Sub btnsearch_Click(sender As Object, e As EventArgs) Handles btnsearch.Click
        loadData()
    End Sub

    Private Sub txtsearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtsearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            loadData()
        End If
    End Sub

    Private Sub dtdate_ValueChanged(sender As Object, e As EventArgs) Handles dtdate.ValueChanged
        loadData()
    End Sub

    Private Sub dgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellClick
        If dgv.Rows.Count <> 0 Then
            If e.ColumnIndex = 4 Then
                over_pullout_dialog.invid = dgv.CurrentRow.Cells("id").Value
                over_pullout_dialog.datee = dtdate.Text
                over_pullout_dialog.ShowDialog()
            End If
        End If
    End Sub
End Class