Imports System.Data.SqlClient
Imports AK_POS.connection_class
Public Class customers
    Dim cc As New connection_class
    Dim con As New SqlConnection(cc.conString)
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader
    Private Sub addcustomer2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbtype.SelectedIndex = 0
    End Sub

    Public Sub loadd()
        Try
            dgv.Rows.Clear()
            Dim query As String = "SELECT customer_id,name, code, contact_number, status,type,address FROM tblcustomers WHERE name Like '%" & txtsearch.Text & "%'", auto As New AutoCompleteStringCollection()

            If cmbtype.SelectedIndex <> 0 Then
                query &= " AND type='" & cmbtype.Text & "';"
            End If
            con.Open()
            cmd = New SqlCommand(query, con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                dgv.Rows.Add(rdr("customer_id"), rdr("name"), rdr("code"), rdr("contact_number"), rdr("address"), IIf(rdr("status") = 1, "Active", "In Active"), rdr("type"))
                auto.Add(rdr("name"))
            End While
            con.Close()
            txtsearch.AutoCompleteCustomSource = auto
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentClick
        If e.ColumnIndex = 7 Then
            Dim edit As New editcustomer()
            edit.id = dgv.CurrentRow.Cells(0).Value
            edit.txtname.Text = dgv.CurrentRow.Cells("namee").Value
            edit.txtcode.Text = dgv.CurrentRow.Cells("code").Value
            edit.txtboxContactNo.Text = dgv.CurrentRow.Cells("contact").Value
            edit.txtboxAddress.Text = dgv.CurrentRow.Cells("address").Value
            edit.cmbStatus.Text = dgv.CurrentRow.Cells("status").Value
            edit.ShowDialog()
            loadd()
        End If
    End Sub

    Private Sub cmbtype_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbtype.SelectedIndexChanged
        loadd()
    End Sub

    Private Sub btnsearch_Click(sender As Object, e As EventArgs) Handles btnsearch.Click
        loadd()
    End Sub

    Private Sub txtsearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtsearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            loadd()
        End If
    End Sub

    Private Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        Dim frm As New addcustomer3()
        frm.ShowDialog()
        loadd()
    End Sub
End Class