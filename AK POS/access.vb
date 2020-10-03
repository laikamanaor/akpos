Imports System.Data.SqlClient
Public Class access
    Dim cc As New connection_class()
    Dim accessc As New access_class()
    Dim transaction As SqlTransaction
    Private Sub access_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbStatus.SelectedIndex = 0
        loadData()
    End Sub

    Public Sub loadData()
        Dim result As New DataTable()
        Dim comboStatus As Integer = IIf(cmbStatus.SelectedIndex = 0 And cmbStatus.Text = "Active", 1, 0)
        result = accessc.loadAccess(comboStatus)
        dgv.Rows.Clear()

        For Each r0w As DataRow In result.Rows
            Dim status As String = IIf(r0w("status") > 0, "Active", "In Active")
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
        Dim a As String = MsgBox("Are you sure you want to submit?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "")
        If a = vbYes Then
            Try
                Using connection As New SqlConnection(cc.conString)
                    Dim cmdd As New SqlCommand()
                    cmdd.Connection = connection
                    connection.Open()
                    transaction = connection.BeginTransaction()
                    cmdd.Transaction = transaction
                    For index As Integer = 0 To dgv.Rows.Count - 1
                        If Convert.ToBoolean(dgv.Rows(index).Cells("selectt").Value) = True Then
                            Dim status As Integer = IIf(dgv.Rows(index).Cells("status").Value = "Active", 0, 1)
                            Dim id As Integer = CInt(dgv.Rows(index).Cells("id").Value)
                            cmdd.CommandText = "UPDATE tblaccess SET status=" & status & " WHERE id=" & id & ";"
                            cmdd.ExecuteNonQuery()

                        End If
                    Next
                    transaction.Commit()
                    MessageBox.Show("Transaction Completed", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
        End If
    End Sub

    Private Sub cmbStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStatus.SelectedIndexChanged
        loadData()
    End Sub
End Class