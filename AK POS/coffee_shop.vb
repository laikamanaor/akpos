Imports System.Data.SqlClient
Imports AK_POS.connection_class
Public Class coffee_shop
    Dim cc As New connection_class
    Dim con As New SqlConnection(cc.conString)
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader


    Dim cs_id As Integer = 0
    Private Sub coffee_shop_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadCs()
    End Sub

    Public Sub loadCs()
        Try

            Dim auto As New AutoCompleteStringCollection()

            dgv.Rows.Clear()
            con.Open()
            cmd = New SqlCommand("SELECT b.free,b.csid,a.itemname FROM tblitems a JOIN tblcsitems b ON a.itemid = b.itemid WHERE a.category='Coffee Shop';", con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                auto.Add(rdr("itemname"))
                dgv.Rows.Add(rdr("csid"), rdr("itemname"), rdr("free"))
            End While
            con.Close()
            txtsearch.AutoCompleteCustomSource = auto
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub btnadditem_Click(sender As Object, e As EventArgs) Handles btnadditem.Click
        Dim frm As New addcs()
        frm.Text = "Add"
        frm.txt.ReadOnly = False
        frm.btnadd.Text = "ADD"
        frm.txt.Focus()
        frm.ShowDialog()
        loadCs()
    End Sub

    Private Sub dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentClick
        If e.ColumnIndex = 3 Then
            Dim frm As New addcs()
            frm.Text = "Edit"
            frm.txt.Text = dgv.CurrentRow.Cells("itemname").Value
            frm.txt.ReadOnly = True
            frm.txtfree.Text = dgv.CurrentRow.Cells("free").Value
            frm.btnadd.Text = "SAVE"
            frm.csid = dgv.CurrentRow.Cells("id").Value
            frm.txtfree.Focus()
            frm.ShowDialog()
            loadCs()
        ElseIf e.ColumnIndex = 4 Then
            Dim a As String = MsgBox("Are you sure you want to delete?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "")
            If a = vbYes Then
                con.Open()
                cmd = New SqlCommand("DELETE FROM tblcsitems WHERE csid=@csid", con)
                cmd.Parameters.AddWithValue("@csid", dgv.CurrentRow.Cells("id").Value)
                cmd.ExecuteNonQuery()
                con.Close()

                MessageBox.Show("Item Deleted", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Information)

                loadCs()
            End If
        End If
    End Sub
    Public Sub search()
        Try
            For index As Integer = 0 To dgv.RowCount - 1
                If dgv.Rows(index).Cells("itemname").Value = txtsearch.Text Then
                    dgv.Rows(index).Selected = True
                    dgv.CurrentCell = dgv.Rows(index).Cells("itemname")
                Else
                    dgv.Rows(index).Selected = False
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Private Sub btnsearch_Click(sender As Object, e As EventArgs) Handles btnsearch.Click
        search()
    End Sub

    Private Sub txtsearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtsearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            search()
        End If
    End Sub
End Class