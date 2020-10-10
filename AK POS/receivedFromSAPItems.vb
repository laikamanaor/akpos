Imports System.Data.SqlClient
Public Class receivedFromSAPItems
    Dim recc As New received_class()
    Dim itemc As New items_class()
    Dim uic As New ui_class
    Dim cc As New connection_class

    Public sapNumber As Integer = 0
    Private Sub receivedFromSAPItems_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblheader.Text = "SAP #: " & sapNumber
        th()
    End Sub

    Public Sub th()
        Dim th As New Threading.Thread(AddressOf loadItems)
        th.Start()
    End Sub

    Public Sub loadItems()
        dgv.Rows.Clear()
        lblNoDataFound.Visible = False
        btnProceed.Enabled = False
        btnSubmit.Enabled = False
        Dim adptr As New SqlClient.SqlDataAdapter, result As New DataTable, auto As New AutoCompleteStringCollection
        Try
            spinner.Visible = True
            Dim query As String = "SELECT DISTINCT DocNum [sap_number],FromWhsCod [fromWhat],Dscription [item_name], Quantity [quantity]  FROM VSAP_IT WHERE CAST(DocDate AS date)>='10/09/2020' AND docNum LIKE '%" & sapNumber & "%';"
            cc.con.Open()
            cc.cmd = New SqlClient.SqlCommand(query, cc.con)
            cc.cmd.CommandType = CommandType.Text
            adptr.SelectCommand = cc.cmd
            cc.con.Close()
            adptr.Fill(result)
            For Each r0w As DataRow In result.Rows
                cc.con.Open()
                cc.cmd = New SqlClient.SqlCommand("SELECT transaction_id FROM tblproduction WHERE CAST(date AS date)>='10/09/2020' AND sap_number='" & r0w("sap_number") & "' AND item_name='" & r0w("item_name") & "' AND sap_number !='To Follow' AND status='Completed'", cc.con)
                cc.rdr = cc.cmd.ExecuteReader
                If Not cc.rdr.Read Then
                    dgv.Rows.Add(r0w("item_name"), CInt(r0w("quantity")).ToString("N0"), "")
                    lblBranch.Text = "FROM: " & r0w("fromWhat")
                End If
                cc.con.Close()

            Next
            lblCount.Text = "ITEMS (" & dgv.Rows.Count.ToString("N0") & ")"
            lblNoDataFound.Visible = IIf(dgv.Rows.Count <> 0, False, True)
            spinner.Visible = False
            btnProceed.Enabled = True
            btnSubmit.Enabled = True
        Catch ex As Exception
            spinner.Visible = False
            MessageBox.Show(ex.Message, "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            cc.con.Close()
        End Try
    End Sub

    Private Sub receivedFromSAPItems_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Hide()
        End If
    End Sub

    Public Function returnTableName() As String
        Dim result As String = ""
        cc.con.Open()
        cc.cmd = New SqlCommand("SELECT FromWhsCod FROM vSAP_IT WHERE DocNum=@sapNumber", cc.con)
        cc.cmd.Parameters.AddWithValue("@sapNumber", sapNumber)
        cc.rdr = cc.cmd.ExecuteReader
        If cc.rdr.Read Then
            result = cc.rdr("FromWhsCod")
        End If
        cc.con.Close()
        result = IIf(result.Equals("A1 P-FG"), "productionin", "itemin")
        Return result
    End Function

    Public Function returnFromBranch() As String
        Dim result As String = ""
        cc.con.Open()
        cc.cmd = New SqlCommand("SELECT FromWhsCod FROM vSAP_IT WHERE DocNum=@sapNumber", cc.con)
        cc.cmd.Parameters.AddWithValue("@sapNumber", sapNumber)
        cc.rdr = cc.cmd.ExecuteReader
        If cc.rdr.Read Then
            result = cc.rdr("FromWhsCod")
        End If
        cc.con.Close()
        Return result
    End Function


    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnProceed.Click
        clearPanelRemarks(True)
    End Sub

    Private Sub dgv_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellEnter
        dgv.Focus()
    End Sub

    Private Sub dgv_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellEndEdit
        If dgv.CurrentRow.Cells("actual_quantity").Value = Nothing Then
            MessageBox.Show("Please Input quantity", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            dgv.CurrentRow.Cells("actual_quantity").Value = ""
        ElseIf Not IsNumeric(dgv.CurrentRow.Cells("actual_quantity").Value.ToString) Then
            MessageBox.Show("Invalid Input", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            dgv.CurrentRow.Cells("actual_quantity").Value = ""
        End If
    End Sub

    Private Sub btnProceed_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        If String.IsNullOrEmpty(txtremarks.Text) Then
            MessageBox.Show("Remarks field is required", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim a As String = MsgBox("Are you sure you want to submit?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "")
            If a = vbYes Then
                recc.inventoryNumber = itemc.getInvID()
                Dim tableName As String = returnTableName()
                recc.fromBranchSupplier = returnFromBranch()
                recc.headerText = IIf(tableName.Equals("productionin"), "Received from Production", "Received from Other Branch")
                recc.tableName = tableName
                recc.sapDocument = "IT"
                recc.remarks = txtremarks.Text
                recc.sapNumber = sapNumber
                Dim transactionNumber As String = recc.returnTransactionNumber(True)
                recc.transactionNumber = transactionNumber
                Dim dtItems As New DataTable
                dtItems.Columns.Add("item")
                dtItems.Columns.Add("quantity")
                If dgv.Rows.Count > 0 Then
                    For i As Integer = 0 To dgv.RowCount - 1
                        If IsNumeric(dgv.Rows(i).Cells("actual_quantity").Value) Then
                            dtItems.Rows.Add(dgv.Rows(i).Cells("item_name").Value, dgv.Rows(i).Cells("actual_quantity").Value)
                        End If
                    Next
                End If
                recc.updateInventory(dtItems)
                Me.Hide()
            End If
        End If
    End Sub

    Public Sub clearPanelRemarks(ByVal isOpened As Boolean)
        panelRemarks.Visible = isOpened
        txtremarks.Text = ""
    End Sub

    Private Sub lblSAPClose_Click(sender As Object, e As EventArgs) Handles lblSAPClose.Click
        clearPanelRemarks(False)
    End Sub

    Private Sub txtremarks_KeyDown(sender As Object, e As KeyEventArgs) Handles txtremarks.KeyDown
        If e.KeyCode = Keys.Escape Then
            clearPanelRemarks(False)
        ElseIf e.KeyCode = Keys.Enter Then
            btnSubmit.PerformClick()
        End If
    End Sub

    Private Sub lblclose_Click(sender As Object, e As EventArgs) Handles lblclose.Click
        Me.Hide()
    End Sub

    Private Sub Panel3_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel3.MouseDown, MyBase.MouseDown, lblheader.MouseDown
        uic.mouse_down(Me)
    End Sub

    Private Sub Panel3_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel3.MouseMove, MyBase.MouseMove, lblheader.MouseMove
        uic.mouse_move(Me)
    End Sub

    Private Sub Panel3_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel3.MouseUp, MyBase.MouseUp, lblheader.MouseUp
        uic.mouse_up()
    End Sub

    Private Sub dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentClick
        dgv.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub

    Private Sub dgv_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellValueChanged
        If dgv.Rows.Count > 0 Then
            If e.ColumnIndex = 2 Then
                If IsNumeric(dgv.CurrentRow.Cells("actual_quantity").Value) Then
                    Dim deliveredQuantity As Integer = dgv.CurrentRow.Cells("quantity").Value
                    Dim actualQuantity As Integer = dgv.CurrentRow.Cells("actual_quantity").Value
                    Dim variance As Double = actualQuantity - deliveredQuantity
                    dgv.CurrentRow.Cells("variance").Value = variance.ToString("N0")
                Else
                    Dim deliveredQuantity As Integer = dgv.CurrentRow.Cells("quantity").Value
                    Dim actualQuantity As Integer = 0
                    Dim variance As Double = actualQuantity - deliveredQuantity
                    dgv.CurrentRow.Cells("variance").Value = variance.ToString("N0")
                End If
            End If
        End If
    End Sub
End Class