Imports AK_POS.tendertype_class
Imports System.Data.SqlClient
Public Class change_tendertype
    Dim tenderc As New tendertype_class()

    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer

    Dim strconn As String = login.ss
    Public con As New SqlConnection(strconn)
    Public rdr As SqlDataReader
    Public cmd As SqlCommand
    Private Sub change_tendertype_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tenderc.loadSales(cmbsales)
        cmbtype.SelectedIndex = 0
        dtdate.MaxDate = DateTime.Now
        dtdate.Text = DateTime.Now.ToString("MM/dd/yyyy")
    End Sub

    Public Sub loadData()
        Try
            tenderc.setDatee(dtdate.Value)
            tenderc.setOrdernum(IIf(String.IsNullOrEmpty(txtsearch.Text), "", txtsearch.Text))
            tenderc.setPOSType(cmbtype.Text)
            tenderc.setSalesName(cmbsales.Text)
            Dim dt As New DataTable()
            dt = tenderc.showTransactions()
            dgvtrans.Rows.Clear()
            Dim auto As New AutoCompleteStringCollection()
            For Each r0w As DataRow In dt.Rows
                dgvtrans.Rows.Add(r0w(0), r0w(1), r0w(2), r0w(3), r0w(4), r0w(5), r0w(6), r0w(7), r0w(8))
                auto.Add(r0w(1))
            Next
            txtsearch.AutoCompleteCustomSource = auto
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub btnsearch_Click(sender As Object, e As EventArgs) Handles btnsearch.Click
        If Not IsNumeric(txtsearch.Text) And Not String.IsNullOrEmpty(txtsearch.Text) Then
            MessageBox.Show("Invalid Input", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            loadData()
        End If
    End Sub

    Private Sub txtsearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtsearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnsearch.PerformClick()
        End If
    End Sub

    Private Sub cmbtype_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbtype.SelectedIndexChanged
        loadData()
    End Sub

    Private Sub cmbsales_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbsales.SelectedIndexChanged
        loadData()
    End Sub

    Private Sub dtdate_ValueChanged(sender As Object, e As EventArgs) Handles dtdate.ValueChanged
        loadData()
    End Sub

    Private Sub Panel5_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel5.MouseDown, MyBase.MouseDown, Label3.MouseDown
        drag = True 'Sets the variable drag to true.
        mousex = Windows.Forms.Cursor.Position.X - Me.Left 'Sets variable mousex
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top 'Sets variable mousey
    End Sub

    Private Sub Panel5_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel5.MouseMove, MyBase.MouseMove, Label3.MouseMove
        'If drag is set to true then move the form accordingly.
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub Panel5_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel5.MouseUp, MyBase.MouseUp, Label3.MouseUp
        drag = False 'Sets drag to false, so the form does not move according to the code in MouseMove
    End Sub

    Private Sub dgvtrans_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvtrans.CellClick
        Try
            If dgvtrans.Rows.Count <> 0 Then

                If e.ColumnIndex = 9 Then
                    change_tendertype_dialog.transid = dgvtrans.CurrentRow.Cells("transid").Value
                    change_tendertype_dialog.orderid = dgvtrans.CurrentRow.Cells("orderid").Value
                    change_tendertype_dialog.datee = dtdate.Text
                    change_tendertype_dialog.transnum = dgvtrans.CurrentRow.Cells("transnum").Value
                    change_tendertype_dialog.current_tendertype = dgvtrans.CurrentRow.Cells("tendertype").Value
                    change_tendertype_dialog.ShowDialog()
                    loadData()
                End If

                Dim query As String = "SELECT itemname,qty,price,dscnt,totalprice FROM tblorder WHERE transnum='" & dgvtrans.CurrentRow.Cells("transnum").Value & "'"

                dgvorders.Rows.Clear()
                con.Open()
                cmd = New SqlCommand(query, con)
                rdr = cmd.ExecuteReader
                While rdr.Read
                    dgvorders.Rows.Add(rdr("itemname"), rdr("qty"), CDbl(rdr("price")).ToString("n2"), rdr("dscnt"), CDbl(rdr("totalprice")).ToString("n2"))
                End While
                con.Close()
                lblitems_count.Text = "ITEMS (" & dgvorders.RowCount & ")"
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub change_tendertype_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class