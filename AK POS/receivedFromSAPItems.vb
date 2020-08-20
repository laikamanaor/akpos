Imports System.Data.SqlClient
Public Class receivedFromSAPItems
    Dim recc As New received_class()
    Dim itemc As New items_class()
    Dim uic As New ui_class
    Dim cc As New connection_class

    Dim conString As String = "Data Source=192.168.30.6;Network Library=DBMSSOCN;Initial Catalog=AKPOS;User ID=admin;Password=abC@43212020;MultipleActiveResultSets=true;"
    Public con As New SqlConnection(conString)
    Public rdr As SqlDataReader
    Public cmd As SqlCommand

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
            Dim query As String = "SELECT Dscription [item_name],Quantity [quantity],FromWhsCod [fromWhat] FROM vSAP_IT WHERE CAST(DocDate AS date)=(select cast(getdate() as date)) AND DocNum=" & sapNumber & " ORDER BY docNum"
            con.Open()
            cmd = New SqlClient.SqlCommand(query, con)
            cmd.CommandType = CommandType.Text
            adptr.SelectCommand = cmd
            con.Close()
            adptr.Fill(result)
            For Each r0w As DataRow In result.Rows
                dgv.Rows.Add(r0w("item_name"), CInt(r0w("quantity")).ToString("N0"), 0)
                lblBranch.Text = "FROM: " & r0w("fromWhat")
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
        con.Open()
        cmd = New SqlCommand("SELECT FromWhsCod FROM vSAP_IT WHERE DocNum=@sapNumber", con)
        cmd.Parameters.AddWithValue("@sapNumber", sapNumber)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            result = rdr("FromWhsCod")
        End If
        con.Close()
        result = IIf(result.Equals("A1 P-FG"), "productionin", "itemin")
        Return result
    End Function

    Public Function returnFromBranch() As String
        Dim result As String = ""
        con.Open()
        cmd = New SqlCommand("SELECT FromWhsCod FROM vSAP_IT WHERE DocNum=@sapNumber", con)
        cmd.Parameters.AddWithValue("@sapNumber", sapNumber)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            result = rdr("FromWhsCod")
        End If
        con.Close()
        Return result
    End Function


    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnProceed.Click
        Dim hasZeroQuantity As String = "Zero Quantity in Item Below:" & Environment.NewLine
        For i As Integer = 0 To dgv.RowCount - 1
            If CInt(dgv.Rows(i).Cells("actual_quantity").Value) <= 0 Then
                hasZeroQuantity &= dgv.Rows(i).Cells("item_name").Value & Environment.NewLine
            End If
        Next
        If hasZeroQuantity <> "Zero Quantity in Item Below:" & Environment.NewLine Then
            MessageBox.Show(hasZeroQuantity, "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            clearPanelRemarks(True)
        End If
    End Sub

    Private Sub dgv_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellEnter
        dgv.Focus()
    End Sub

    Private Sub dgv_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellEndEdit
        If dgv.CurrentRow.Cells("actual_quantity").Value = Nothing Then
            MessageBox.Show("Please Input atleast 1", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            dgv.CurrentRow.Cells("actual_quantity").Value = 0
        ElseIf Not IsNumeric(dgv.CurrentRow.Cells("actual_quantity").Value.ToString) Then
            MessageBox.Show("Invalid Input", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            dgv.CurrentRow.Cells("actual_quantity").Value = 0
        ElseIf CInt(dgv.CurrentRow.Cells("actual_quantity").Value.ToString) <= 0 Then
            MessageBox.Show("Please Input atleast 1", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            dgv.CurrentRow.Cells("actual_quantity").Value = 0
        End If
    End Sub

    Private Sub btnProceed_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        If String.IsNullOrEmpty(txtremarks.Text) Then
            MessageBox.Show("Remarks field is required", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
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
            For i As Integer = 0 To dgv.RowCount - 1
                dtItems.Rows.Add(dgv.Rows(i).Cells("item_name").Value, dgv.Rows(i).Cells("actual_quantity").Value)
            Next
            recc.updateInventory(dtItems)
            clearPanelRemarks(False)
            Me.Hide()
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
End Class