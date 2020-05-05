Imports System.Data.SqlClient
Imports AK_POS.connection_class
Public Class overwrite_sap
    Dim cc As New connection_class
    Dim con As New SqlConnection(cc.conString)
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader
    Private Sub overwrite_sap_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = False
        btneditsap.PerformClick()
        cmbtype.SelectedIndex = 0
        dtdate.Text = getSystemDate.ToString("MM/dd/yyyy")
        dtdate.MaxDate = getSystemDate()
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
    Public Sub loadEditSAP(ByVal columnName As String)
        Try
            Dim auto As New AutoCompleteStringCollection()
            dgv.Rows.Clear()
            Dim serverDate As String = getSystemDate.ToString("MM/dd/yyyy")
            con.Open()
            cmd = New SqlCommand("SELECT transaction_number,sap_number,remarks,processed_by" & IIf(columnName = "tblsaplogs", "", ",status") & " FROM " & columnName & " WHERE CAST(date AS date)=@date AND type='" & cmbtype.Text & "' GROUP BY transaction_number,sap_number,remarks,processed_by " & IIf(columnName = "tblsaplogs", "", ",status") & " ORDER BY transaction_number;", con)
            cmd.Parameters.AddWithValue("@date", dtdate.Text)
            rdr = cmd.ExecuteReader
            While rdr.Read
                auto.Add(rdr("sap_number"))
                Dim stat As String = ""
                If columnName = "tblproduction" Then
                    stat = rdr("status")
                Else
                    stat = "N/A"
                End If
                dgv.Rows.Add(rdr("transaction_number"), rdr("sap_number"), rdr("remarks"), rdr("processed_by"), stat)
            End While
            con.Close()
            txtsearch.AutoCompleteCustomSource = auto
            If columnName = "tblproduction" Then
                For index As Integer = 0 To dgv.RowCount - 1
                    dgv.Rows(index).Cells("status").Style.ForeColor = IIf(dgv.Rows(index).Cells("status").Value = "Completed", Color.Green, Color.Red)
                Next
            End If

            dgv.Columns("status").Visible = IIf(columnName = "tblsaplogs", False, True)

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub
    Public Sub search()
        Try
            For index As Integer = 0 To dgv.RowCount - 1
                If dgv.Rows(index).Cells("sapnum").Value = txtsearch.Text Then
                    dgv.Rows(index).Selected = True
                    dgv.CurrentCell = dgv.Rows(index).Cells("sapnum")
                Else
                    dgv.Rows(index).Selected = False
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Public Sub loadLogs()
        Try
            con.Open()
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Private Sub cmbtype_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbtype.SelectedIndexChanged
        clear_edit()
        If btneditsap.ForeColor = Color.Black Then
            loadEditSAP("tblproduction")
        Else
            loadEditSAP("tblsaplogs")
        End If
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles dtdate.ValueChanged
        clear_edit()
        If btneditsap.ForeColor = Color.Black Then
            loadEditSAP("tblproduction")
        Else
            loadEditSAP("tblsaplogs")
        End If
    End Sub

    Private Sub txtsearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtsearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            search()
        End If
    End Sub

    Private Sub btnsearch_Click(sender As Object, e As EventArgs) Handles btnsearch.Click
        search()
    End Sub
    Public Sub clear_edit()
        paneledit.Visible = False
        txtsap.Text = ""
        txtremarks.Text = ""
        lbltransnum.Text = "N/A"
    End Sub
    Private Sub lblclose_Click(sender As Object, e As EventArgs) Handles lblclose.Click
        clear_edit()
    End Sub

    Private Sub btnsubmit_Click(sender As Object, e As EventArgs) Handles btnsubmit.Click
        Try
            If String.IsNullOrEmpty(txtsap.Text) Then
                MessageBox.Show("SAP # field is empty", "Atlantic Water", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf String.IsNullOrEmpty(txtremarks.Text) Then
                MessageBox.Show("Remarks field is empty", "Atlantic Water", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                con.Open()
                cmd = New SqlCommand("UPDATE tblproduction SET sap_number=@sap_number,remarks=@remarks WHERE transaction_number=@transnum;", con)
                cmd.Parameters.AddWithValue("@sap_number", txtsap.Text)
                cmd.Parameters.AddWithValue("@remarks", txtremarks.Text)
                cmd.Parameters.AddWithValue("@transnum", lbltransnum.Text)
                cmd.ExecuteNonQuery()
                con.Close()

                con.Open()
                cmd = New SqlCommand("INSERT INTO tblsaplogs (transaction_number,sap_number,remarks,type,date,processed_by) VALUES (@transnum,@sapno,@remarks,@type,(SELECT GETDATE()), @username);", con)
                cmd.Parameters.AddWithValue("@transnum", lbltransnum.Text)
                cmd.Parameters.AddWithValue("@sapno", txtsap.Text)
                cmd.Parameters.AddWithValue("@remarks", txtremarks.Text)
                cmd.Parameters.AddWithValue("@username", login.username)
                cmd.Parameters.AddWithValue("@type", cmbtype.Text)
                cmd.ExecuteNonQuery()
                con.Close()

                MessageBox.Show("Saved", "Atlantic Water", MessageBoxButtons.OK, MessageBoxIcon.Information)
                clear_edit()
                loadEditSAP("tblproduction")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub txtsap_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtsap.KeyPress
        If Not Char.IsControl(e.KeyChar) And Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentClick
        If dgv.RowCount <> 0 Then
            If e.ColumnIndex = 5 Then
                paneledit.Visible = True
                lbltransnum.Text = dgv.CurrentRow.Cells("transnum").Value
                txtsap.Text = dgv.CurrentRow.Cells("sapnum").Value
                txtremarks.Text = dgv.CurrentRow.Cells("remarks").Value
            End If
        End If
    End Sub

    Private Sub btneditsap_Click(sender As Object, e As EventArgs) Handles btneditsap.Click
        btneditsap.ForeColor = Color.Black
        btnlogs.ForeColor = Color.White
        loadEditSAP("tblproduction")
        dgv.Columns("btnedit").Visible = True
    End Sub

    Private Sub btnlogs_Click(sender As Object, e As EventArgs) Handles btnlogs.Click
        btneditsap.ForeColor = Color.White
        btnlogs.ForeColor = Color.Black
        loadEditSAP("tblsaplogs")
        dgv.Columns("btnedit").Visible = False
    End Sub

    Private Sub dgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellDoubleClick
        If dgv.RowCount <> 0 Then
            Dim frm As New saplogs()
            frm.lblsap.Text = dgv.CurrentRow.Cells("sapnum").Value
            frm.lbltransnum.Text = dgv.CurrentRow.Cells("transnum").Value
            frm.ShowDialog()
        End If
    End Sub
End Class