Imports AK_POS.connection_class
Imports System.Data.SqlClient
Public Class EditRemarks
    Dim cc As New connection_class()
    Dim transaction As SqlClient.SqlTransaction
    Private Sub EditRemarks_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbType.SelectedIndex = 0
    End Sub

    Public Sub loadData()
        dgv.Rows.Clear()
        Dim rdr As SqlClient.SqlDataReader
        cc.con.Open()
        cc.cmd = New SqlClient.SqlCommand("SELECT transaction_id, item_name,quantity, transfer_to,remarks,typenum, sap_number FROM tblproduction WHERE type=@type AND CAST(date AS date)='" + dtDate.Text + "' AND status='Completed';", cc.con)
        cc.cmd.Parameters.AddWithValue("@type", cmbType.Text)
        rdr = cc.cmd.ExecuteReader
        While rdr.Read
            Dim id As String = IIf(IsDBNull(rdr("transaction_id")), "", rdr("transaction_id"))
            Dim itemName As String = IIf(IsDBNull(rdr("item_name")), "", rdr("item_name"))
            Dim tranferto As String = IIf(IsDBNull(rdr("transfer_to")), "", rdr("transfer_to"))
            Dim remarks As String = IIf(IsDBNull(rdr("remarks")), "", rdr("remarks"))
            Dim typeNum As String = IIf(IsDBNull(rdr("typenum")), "", rdr("typenum"))
            Dim sapNum As String = IIf(IsDBNull(rdr("sap_number")), "", rdr("sap_number"))
            Dim quantity As Integer = IIf(IsDBNull(rdr("quantity")), 0, rdr("quantity"))
            dgv.Rows.Add(False, id, itemName, quantity.ToString("N0"), tranferto, remarks, typeNum, sapNum)
        End While
        cc.con.Close()
        lblheader.Visible = IIf(dgv.Rows.Count > 0, False, True)
    End Sub

    Private Sub cmbType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbType.SelectedIndexChanged
        loadData()
        hidePanelRemarks(False)
    End Sub

    Private Sub dtDate_ValueChanged(sender As Object, e As EventArgs) Handles dtDate.ValueChanged
        loadData()
    End Sub

    Public Function checkChecked() As Boolean
        Dim result As Boolean = False,
            result_int As Integer = 0
        For i As Integer = 0 To dgv.Rows.Count - 1
            If dgv.Rows(i).Cells("selectt").Value = True Then
                result_int += 1
            End If
        Next
        result = IIf(result_int > 0, True, False)
        Return result
    End Function

    Private Sub btnEditRemarks_Click(sender As Object, e As EventArgs) Handles btnEditRemarks.Click
        If dgv.Rows.Count <= 0 Then
            MessageBox.Show("No item fetch", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            hidePanelRemarks(False)
        ElseIf checkChecked() = False Then
            MessageBox.Show("No item selected", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            hidePanelRemarks(False)
        Else
            hidePanelRemarks(True)
        End If
    End Sub

    Public Sub hidePanelRemarks(ByVal value As Boolean)
        panelremarks.Visible = value
        txtRemarks.Clear()
    End Sub

    Private Sub lblcloseRemarks_Click(sender As Object, e As EventArgs) Handles lblcloseRemarks.Click
        hidePanelRemarks(False)
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        submit()
    End Sub

    Public Sub submit()
        If dgv.Rows.Count <= 0 Then
            MessageBox.Show("No item fetch", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            hidePanelRemarks(False)
        ElseIf checkChecked() = False Then
            MessageBox.Show("No item selected", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            hidePanelRemarks(False)
        ElseIf String.IsNullOrEmpty(Trim(txtRemarks.Text)) Then
            MessageBox.Show("Remarks field is required", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtRemarks.Focus()
        Else
            Dim conditional As Boolean = IIf(rbEdit.Checked, True, False)
            updateRemarks(conditional)
        End If
    End Sub

    Public Sub updateRemarks(ByVal conditional As Boolean)
        Try
            Dim conditionalTrueQuery As String = "UPDATE tblproduction SET remarks=@remarks  WHERE transaction_id=@id",
                conditionalFalseQuery As String = "UPDATE tblproduction SET remarks+=@remarks  WHERE transaction_id=@id",
                resultQuery As String = ""
            resultQuery = IIf(conditional, conditionalTrueQuery, conditionalFalseQuery)
            Dim command As New SqlCommand
            Using connection As New SqlClient.SqlConnection(cc.conString)
                command.Connection = connection

                connection.Open()
                transaction = connection.BeginTransaction()

                command.Transaction = transaction
                For i As Integer = 0 To dgv.Rows.Count - 1
                    If CBool(dgv.Rows(i).Cells("selectt").Value) = True Then
                        command.Parameters.Clear()
                        command.CommandText = resultQuery
                        command.Parameters.AddWithValue("@remarks", " " & Trim(txtRemarks.Text))
                        command.Parameters.AddWithValue("@id", dgv.Rows(i).Cells("transid").Value)
                        command.ExecuteNonQuery()
                    End If
                Next
                transaction.Commit()
                MessageBox.Show("Remarks Updated", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Information)
                hidePanelRemarks(False)
                loadData()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Try
                transaction.Rollback()
            Catch ex2 As Exception
                MessageBox.Show(ex2.ToString)
            End Try
        End Try
    End Sub

    Private Sub txtRemarks_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRemarks.KeyDown
        If e.KeyCode = Keys.Enter Then
            submit()
        End If
    End Sub
End Class