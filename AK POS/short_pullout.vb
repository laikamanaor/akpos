Imports System.Data.SqlClient
Imports AK_POS.connection_class
Public Class short_pullout
    Dim cc As New connection_class
    Dim strconn As String = cc.conString
    Dim con As New SqlConnection(strconn)
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader
    Private Sub short_pullout_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtdate.MaxDate = getSystemDate()
        dtdate.Text = getSystemDate.ToString("MM/dd/yyyy")
        loadCategories()
    End Sub
    Public Sub loadCategories()
        Try
            cmbcategory.Items.Clear()
            cmbcategory.Items.Add("All")
            con.Open()
            cmd = New SqlCommand("SELECT category FROM tblcat WHERE status=1 ORDER BY category ASC;", con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                cmbcategory.Items.Add(rdr("category"))
            End While
            con.Close()
            cmbcategory.SelectedIndex = 0
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub
    Public Sub loadShort()
        Try
            Dim auto As New AutoCompleteStringCollection()
            dgv.Rows.Clear()
            con.Open()
            cmd = New SqlCommand("SELECT item_name,charge FROM tblproduction WHERE type='Actual Ending Balance' AND CAST(date AS date)='" & dtdate.Text & "' AND inv_id=(SELECT invnum FROM tblinvsum WHERE CAST(datecreated AS date)='" & dtdate.Text & "') AND charge !=0 AND item_name LIKE '%" & txtsearch.Text & "%' " & IIf(cmbcategory.SelectedIndex <> 0, " AND category='" & cmbcategory.Text & "';", ";"), con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                dgv.Rows.Add(rdr("item_name"), CInt(rdr("charge")))
                auto.Add(rdr("item_name"))
            End While
            con.Close()
            txtsearch.AutoCompleteCustomSource = auto
            lblerr.Visible = IIf(dgv.RowCount = 0, True, False)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub

    Public Function getSystemDate() As DateTime
        Try
            Dim dt As New DateTime()
            con.Open()
            cmd = New SqlCommand("SELECT GETDATE()", con)
            rdr = cmd.ExecuteReader()
            While rdr.Read
                dt = CDate(rdr(0).ToString)
            End While
            con.Close()
            Return dt
        Catch ex As SqlException
            If ex.Number = -2 Then
                MessageBox.Show("Timeout Occurred", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Function

    Public Function getInventoryNumber() As String
        Dim result As String = ""
        con.Open()
        cmd = New SqlCommand("SELECT invnum FROM tblinvsum WHERE CAST(datecreated AS date)='" & dtdate.Text & "';", con)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            result = rdr("invnum")
        End If
        con.Close()
        result = IIf(result = "", "INVENTORY_NOT_FOUND", result)
        lblinvnum.ForeColor = IIf(result = "INVENTORY_NOT_FOUND", Color.Red, Color.Black)
        Return result
    End Function

    Private Sub dgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellClick
        If e.ColumnIndex = 2 Then
            Dim frm As New short_pullout_dialog()
            frm.lblitemname.Text = dgv.CurrentRow.Cells("itemname").Value
            frm.lblquantity.Text = dgv.CurrentRow.Cells("quantity").Value
            frm.txtquantity.Text = dgv.CurrentRow.Cells("quantity").Value
            frm.datecreated = dtdate.Text
            frm.ShowDialog()
            loadShort()
        End If
    End Sub

    Private Sub cmbcategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbcategory.SelectedIndexChanged
        loadShort()
    End Sub

    Private Sub dtdate_ValueChanged(sender As Object, e As EventArgs) Handles dtdate.ValueChanged
        lblinvnum.Text = getInventoryNumber()
        loadShort()
    End Sub

    Private Sub txtsearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtsearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            loadShort()
        End If
    End Sub

    Private Sub btnsearch_Click(sender As Object, e As EventArgs) Handles btnsearch.Click
        loadShort()
    End Sub
End Class