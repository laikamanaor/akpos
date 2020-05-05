Imports System.Data.SqlClient
Imports AK_POS.connection_class
Public Class overwrite_short
    Dim cc As New connection_class
    Dim con As New SqlConnection(cc.conString)
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader
    Private Sub overwrite_short_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadLists()
    End Sub

    Public Sub loadLists()
        Try
            dgv_lists.Rows.Clear()
            con.Open()
            cmd = New SqlCommand("getShort", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@date", select_date.dtdate.Text)
            rdr = cmd.ExecuteReader
            While rdr.Read
                dgv_lists.Rows.Add(rdr("item_code"), rdr("item_name"), rdr("quantity"), rdr("charge"), rdr("name"))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub dgv_lists_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_lists.CellClick
        If dgv_lists.RowCount <> 0 Then
            If e.ColumnIndex = 5 Then
                Dim frm As New overwrite_short_form()
                frm.lblcode.Text = dgv_lists.CurrentRow.Cells("itemcode").Value
                frm.lblname.Text = dgv_lists.CurrentRow.Cells("itemname").Value
                frm.txtquantity.Text = dgv_lists.CurrentRow.Cells("qty").Value
                frm.txtcharge.Text = dgv_lists.CurrentRow.Cells("charge").Value
                frm.txtemployee.Text = dgv_lists.CurrentRow.Cells("employee").Value
                frm.txtquantity.Focus()
                frm.ShowDialog()
                If frm.isValid Then
                    dgv_selected.Rows.Add(frm.lblcode.Text, frm.lblname.Text, frm.txtquantity.Text, frm.txtcharge.Text, frm.txtemployee.Text)
                Else
                    MessageBox.Show("ERROR")
                End If
            End If
        End If
    End Sub
End Class