Imports System.Data.SqlClient
Public Class endingbalance2
    Dim rec As New received_class
    Dim brc As New branch_class()
    Dim itemc As New items_class()
    Dim cc As New connection_class()

    Dim transaction As SqlTransaction
    Public Sub loadData()
        spinner.Visible = True
        dgv.Rows.Clear()
        Dim result As New DataTable()
        result = rec.loadActualEndbal()
        If result.Rows.Count > 0 Then
            For Each r0w As DataRow In result.Rows
                dgv.Rows.Add(r0w("itemname"), 0, CInt(r0w("quantity")).ToString("N0"), 0, CInt(r0w("quantity")).ToString("N0"), (0 - CInt(r0w("quantity"))).ToString("N0"), CInt(r0w("price")).ToString("N0"), ((0 - CInt(r0w("quantity"))) * CInt(r0w("price"))).ToString("N0"))
            Next
        End If
        spinner.Visible = False
    End Sub

    Private Sub endingbalance2_Load_1(sender As Object, e As EventArgs) Handles MyBase.Load
        Control.CheckForIllegalCrossThreadCalls = False
        Dim th As New Threading.Thread(AddressOf loadData)
        th.Start()
        loadBranches()
    End Sub

    Public Sub loadBranches()
        Dim result As New DataTable
        result = brc.loadBranches()
        For Each r0w As DataRow In result.Rows
            cmbranches.Items.Add(r0w("result"))
        Next
    End Sub

    Private Sub dgv_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellEndEdit
        If dgv.Rows.Count > 0 Then
            If e.ColumnIndex = 1 Then
                If String.IsNullOrEmpty(dgv.CurrentRow.Cells("actualending").Value) Then
                    dgv.CurrentRow.Cells("actualending").Value = 0
                    compute()
                    po()
                ElseIf Not IsNumeric(dgv.CurrentRow.Cells("actualending").Value) Then
                    MessageBox.Show("Invalid Input", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    dgv.CurrentRow.Cells("actualending").Value = 0
                    compute()
                    po()
                Else
                    compute()
                    po()
                End If
            ElseIf e.ColumnIndex = 3 Then
                If String.IsNullOrEmpty(dgv.CurrentRow.Cells("pullout").Value) Then
                    dgv.CurrentRow.Cells("pullout").Value = 0
                    po()
                    compute()
                ElseIf Not IsNumeric(dgv.CurrentRow.Cells("pullout").Value) Then
                    MessageBox.Show("Invalid Input", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    dgv.CurrentRow.Cells("pullout").Value = 0
                    po()
                Else
                    Dim pullout As Integer = dgv.CurrentRow.Cells("pullout").Value
                    po()
                    compute()
                End If
            End If
        End If
    End Sub

    Public Sub po()
        Dim pullout As Integer = CInt(dgv.CurrentRow.Cells("pullout").Value)
        Dim endbal As Integer = CInt(dgv.CurrentRow.Cells("endbal").Value)
        Dim totalendbal As Integer = endbal + pullout
        dgv.CurrentRow.Cells("totalsystembalance").Value = totalendbal.ToString("N0")
    End Sub

    Public Sub compute()
        Dim variance As Integer = CInt(dgv.CurrentRow.Cells("actualending").Value) - CInt(dgv.CurrentRow.Cells("endbal").Value)
        Dim hold As Integer = variance + CInt(dgv.CurrentRow.Cells("pullout").Value)
        dgv.CurrentRow.Cells("variance").Value = hold.ToString("N0")
        dgv.CurrentRow.Cells("totalamt").Value = hold * CDbl(dgv.CurrentRow.Cells("price").Value)
        For index As Integer = 0 To dgv.Rows.Count - 1
            dgv.Rows(index).Cells("pullout").Style.BackColor = IIf(CInt(dgv.Rows(index).Cells("pullout").Value) > 0, Color.Red, Color.White)
            dgv.Rows(index).Cells("pullout").Style.ForeColor = IIf(CInt(dgv.Rows(index).Cells("pullout").Value) > 0, Color.White, Color.Black)
        Next
    End Sub

    Private Sub btnProceed_Click(sender As Object, e As EventArgs) Handles btnProceed.Click
        If dgv.Rows.Count < 0 Then
            MessageBox.Show("No item to proceed", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            showPanelSAP(True)
        End If
    End Sub

    Public Sub showPanelSAP(ByVal value As Boolean)
        cmbranches.SelectedIndex = -1
        cmbStatus.SelectedIndex = -1
        txtactualremarks.Text = ""
        txtporemarks.Text = ""
        txtsap.Text = ""
        panelSAP.Visible = value
    End Sub

    Private Sub cmbStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStatus.SelectedIndexChanged
        txtsap.Text = ""
        txtsap.Enabled = IIf(cmbStatus.SelectedIndex.Equals(1), True, False)
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Try
            If String.IsNullOrEmpty(txtsap.Text) And cmbStatus.SelectedIndex.Equals(1) Then
                MessageBox.Show("Please input SAP #", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf Not IsNumeric(txtsap.Text) And cmbStatus.SelectedIndex.Equals(1) Then
                MessageBox.Show("SAP # must be a number", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf Trim(txtsap.Text).Length <= 5 And cmbStatus.SelectedIndex.Equals(1) Then
                MessageBox.Show("SAP # must be a 6 numbers", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf String.IsNullOrEmpty(cmbranches.Text) Then
                MessageBox.Show("Branch field is empty", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf String.IsNullOrEmpty(txtactualremarks.Text) Then
                MessageBox.Show("Actual Remarks field is empty", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf String.IsNullOrEmpty(txtporemarks.Text) Then
                MessageBox.Show("P.O Remarks field is empty", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                Dim dtItems As New DataTable()
                dtItems.Columns.Add("item")
                dtItems.Columns.Add("quantity")
                For i As Integer = 0 To dgv.RowCount - 1
                    If dgv.Rows(i).Cells("pullout").Value > 0 Then
                        dtItems.Rows.Add(dgv.Rows(i).Cells("itemname").Value, dgv.Rows(i).Cells("pullout").Value)
                    End If
                Next
                rec.inventoryNumber = itemc.getInvID()
                rec.tableName = "pullout2"
                rec.sapDocument = lblsapdoc.Text
                rec.headerText = "Pull Out"
                rec.remarks = txtporemarks.Text
                rec.fromBranchSupplier = cmbranches.Text
                rec.sapNumber = IIf(String.IsNullOrEmpty(Trim(txtsap.Text)), 0, txtsap.Text)
                rec.type = "Pull Out"
                rec.type2 = "Pull Out"
                Dim transactionNumber As String = rec.returnTransactionNumber(True)
                rec.transactionNumber = transactionNumber
                rec.updatePullOut(dtItems)

                actualendbal()

                showPanelSAP(False)

                Control.CheckForIllegalCrossThreadCalls = False
                Dim th As New Threading.Thread(AddressOf loadData)
                th.Start()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Function GetTransID() As String
        Dim result As String = ""
        Try
            Dim selectcount_result As Integer = 0
            Dim get_area As String = "", temp As String = ""
            cc.con.Open()
            cc.cmd = New SqlClient.SqlCommand("Select ISNULL(MAX(transaction_id),0)+1 transaction_number  from tblproduction WHERE area='Sales' AND type='Actual Ending Balance';", cc.con)
            selectcount_result = cc.cmd.ExecuteScalar
            cc.con.Close()

            Dim branchcode As String = ""
            cc.con.Open()
            cc.cmd = New SqlClient.SqlCommand("SELECT branchcode FROM tblbranch WHERE main='1';", cc.con)
            cc.rdr = cc.cmd.ExecuteReader
            If cc.rdr.Read Then
                branchcode = cc.rdr("branchcode")
            End If
            cc.con.Close()

            If selectcount_result < 1000000 Then
                Dim cselectcount_result As String = CStr(selectcount_result)
                For vv As Integer = 1 To 6 - cselectcount_result.Length
                    temp += "0"
                Next
                Result = "AEB - " & branchcode & " - " & temp & selectcount_result
            End If
        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information, "")
        Finally
            cc.con.Close()
        End Try
        Return result
    End Function

    Public Function getOrdernum() As Integer
        Dim selectcount_result As Integer = 0
        cc.con.Open()
        cc.cmd = New SqlCommand("Select ISNULL(MAX(ordernum),0) from tbltransaction2 WHERE area='" & "Sales" & "' AND CAST(datecreated AS date)='" & DateTime.Now.ToString("MM/dd/yyyy") & "';", cc.con)
        selectcount_result = cc.cmd.ExecuteScalar() + 1
        cc.con.Close()

        cc.con.Open()
        cc.cmd = New SqlCommand("SELECT ordernum FROM tbltransaction2 WHERE ordernum=@ordernum AND CAST(datecreated AS date)='" & DateTime.Now.ToString("MM/dd/yyyy") & "';", cc.con)
        cc.cmd.Parameters.AddWithValue("@ordernum", selectcount_result)
        cc.rdr = cc.cmd.ExecuteReader
        If cc.rdr.Read Then
            selectcount_result += 1
        End If
        cc.con.Close()
        Return selectcount_result
    End Function

    Public Function getARNum(ByVal typee As String, ByVal formatsu As String) As String
        Dim result As String = ""
        Try
            Dim temp As String = "0", area_format As String = "", selectcount_result As Integer = 0
            cc.con.Open()
            cc.cmd = New SqlCommand("SELECT ISNULL(MAX(CAST(REPLACE(transnum,SUBSTRING(transnum,1,20),'') AS INT)),0)+1 FROM tblars1 WHERE name ='Short' AND type=@type;", cc.con)
            cc.cmd.Parameters.AddWithValue("@type", typee)
            selectcount_result = cc.cmd.ExecuteScalar()
            cc.con.Close()

            Dim branchcode As String = ""
            cc.con.Open()
            cc.cmd = New SqlCommand("SELECT branchcode FROM tblbranch WHERE main='1';", cc.con)
            cc.rdr = cc.cmd.ExecuteReader
            If cc.rdr.Read Then
                branchcode = cc.rdr("branchcode")
            End If
            cc.con.Close()

            Dim format As String = "SALAR" & formatsu & " - "
            area_format = format & branchcode & " - "

            If selectcount_result < 1000000 Then
                Dim cselectcount_result As String = CStr(selectcount_result)
                For vv As Integer = 1 To 6 - cselectcount_result.Length
                    temp += "0"
                Next
                result = area_format & temp & selectcount_result
            End If
        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information, "")
        Finally
            cc.con.Close()
        End Try
        Return result
    End Function

    Public Sub actualendbal()
        Try
            Dim a As String = MsgBox("Are you sure you want to update?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MessageBoxDefaultButton.Button2, "")
            If a = vbYes Then
                Dim ordernum As Integer = getOrdernum()
                Dim trans_num As String = GetTransID()
                Dim dt As New DataTable()
                dt.Columns.Add("itemname")
                dt.Columns.Add("quantity")
                dt.Columns.Add("charge")
                dt.Columns.Add("endbal")
                dt.Columns.Add("actual")

                For index As Integer = 0 To dgv.Rows.Count - 1
                    Dim charge As Integer = CInt(dgv.Rows(index).Cells("actualending").Value) - CInt(dgv.Rows(index).Cells("endbal").Value)
                    Dim hold = charge + CInt(dgv.Rows(index).Cells("pullout").Value)
                    Dim endbal As Integer = CInt(dgv.Rows(index).Cells("endbal").Value) - CInt(dgv.Rows(index).Cells("pullout").Value)
                    MessageBox.Show("ENDBAL : " & endbal)
                    Dim actual As Integer = CInt(dgv.Rows(index).Cells("actualending").Value)

                    dt.Rows.Add(dgv.Rows(index).Cells("itemname").Value, dgv.Rows(index).Cells("actualending").Value, hold, endbal, actual)
                Next
                Using connection As New SqlConnection(cc.conString)
                    Dim cmdd As New SqlCommand()
                    Dim rdr As SqlDataReader
                    cmdd.Connection = connection

                    connection.Open()
                    transaction = connection.BeginTransaction()

                    cmdd.Transaction = transaction
                    For Each index As DataRow In dt.Rows

                        cmdd.Parameters.Clear()

                        cmdd.CommandText = "Update tblinvitems set endbal=" & index("endbal") & ", actualendbal=" & index("actual") & ", variance=0,archarge+=" & index("charge") & " where itemcode=(SELECT itemcode FROM tblitems WHERE itemname='" & index("itemname") & "') and invnum=(Select TOP 1 invnum from tblinvsum WHERE area='Sales' order by invsumid DESC)"
                        cmdd.ExecuteNonQuery()

                        cmdd.Parameters.Clear()
                        cmdd.CommandText = "INSERT INTO tblproduction (transaction_number,inv_id,item_code,item_name,category,quantity,charge,date,processed_by,type,area,status,remarks) VALUES ('" & trans_num & "',(Select TOP 1 invnum from tblinvsum WHERE area='Sales' order by invsumid DESC),(SELECT itemcode FROM tblitems WHERE itemname='" & index("itemname") & "'),'" & index("itemname") & "',(SELECT category FROM tblitems WHERE itemname='" & index("itemname") & "'),'" & index("quantity") & "','" & index("charge") & "',(SELECT GETDATE()),'" & login2.username & "','Actual Ending Balance', 'Sales', 'Completed',@remarks);"
                        cmdd.Parameters.AddWithValue("@remarks", txtactualremarks.Text)
                        cmdd.ExecuteNonQuery()
                    Next
                    Dim amount As Double = 0.0, price As Double = 0.0
                    amount = 0
                    Dim ar_number As String = getARNum("AR Charge", "CH")

                    For Each _res As DataRow In dt.Rows
                        If CInt(_res("charge")) > 0 Then
                            Dim totalprice As Double = 0.00
                            cmdd.Parameters.Clear()
                            cmdd.CommandText = "SELECT price FROM tblitems WHERE itemname=@itemname"
                            cmdd.Parameters.AddWithValue("@itemname", _res("itemname"))
                            rdr = cmdd.ExecuteReader
                            While rdr.Read
                                amount += (CInt(_res("charge")) * CDbl(rdr("price")))
                                totalprice = (CInt(_res("charge")) * CDbl(rdr("price")))
                                price = CDbl(rdr("price"))
                            End While
                            rdr.Close()

                            cmdd.Parameters.Clear()
                            cmdd.CommandText = "Insert into tblorder (transnum, category, itemname, qty, price, totalprice, dscnt, free, request, status, discprice, disctrans,area,invnum,type)values('" & ar_number & "',(SELECT category FROM tblitems WHERE itemname='" & _res("itemname") & "'),'" & _res("itemname") & "','" & _res("charge") & "','" & price & "','" & totalprice & "','0','0','0','1','0','0','Sales',(Select TOP 1 invnum from tblinvsum WHERE area='Sales' order by invsumid DESC),'" & "A.R Charge" & "')"
                            cmdd.ExecuteNonQuery()

                            cmdd.Parameters.Clear()
                            cmdd.CommandText = "Insert into tblorder2 (ordernum, category, itemname, qty, price, totalprice, dscnt, free, request, status, discprice, disctrans,area,datecreated)values('" & ordernum & "',(SELECT category FROM tblitems WHERE itemname='" & _res("itemname") & "'),'" & _res("itemname") & "','" & _res("charge") & "','" & price & "','" & totalprice & "','0','0','0','1','0','0','Sales',(SELECT GETDATE()))"
                            cmdd.ExecuteNonQuery()

                            cmdd.Parameters.Clear()
                            cmdd.CommandText = "INSERT INTO tblars2 (transnum,description,quantity,price,amount,area,name) VALUES (@tnum, @des,@qua,@price,@am,@area,@name)"
                            cmdd.Parameters.AddWithValue("@tnum", ar_number)
                            cmdd.Parameters.AddWithValue("@des", _res("itemname"))
                            cmdd.Parameters.AddWithValue("@qua", _res("charge"))
                            cmdd.Parameters.AddWithValue("@price", price)
                            cmdd.Parameters.AddWithValue("@am", totalprice)
                            cmdd.Parameters.AddWithValue("@area", "Sales")
                            cmdd.Parameters.AddWithValue("@name", "Short")
                            cmdd.ExecuteNonQuery()
                        End If
                    Next
                    cmdd.Parameters.Clear()
                    cmdd.CommandText = "Insert into tbltransaction (ornum, transnum, transdate, cashier, tendertype, servicetype, delcharge, subtotal, disctype, less, vatsales, vat, amtdue, gctotal, tenderamt, change, refund, comment, remarks, customer, tinnum, tablenum, pax, datecreated, datemodified, status, area, invnum, partialamt,typenum,sap_number,sap_remarks,typez,discamt,salesname) values ('0', '" & ar_number & "', (SELECT CAST(GETDATE() AS date)),'" & login2.username & "','A.R Charge','N/A','0', '" & amount & "', 'N/A', '0', '0', '0', '" & amount & "', '0', '0', '0', '0', '', '','Short' , 'N/A', '0','1', (SELECT GETDATE()), (SELECT GETDATE()), '1','Sales',(Select TOP 1 invnum from tblinvsum WHERE area='Sales' order by invsumid DESC),'0','AR','To Follow','','Retail',0,'" & login2.username & "')"
                    cmdd.ExecuteNonQuery()

                    cmdd.Parameters.Clear()
                    cmdd.CommandText = "Insert into tbltransaction2 (ornum, ordernum, transdate, cashier, tendertype, servicetype, delcharge, subtotal, disctype, less, vatsales, vat, amtdue, gctotal, tenderamt, change, refund, comment, remarks, customer, tinnum, tablenum, pax, datecreated, datemodified, status, area,transnum) values ('0', '" & ordernum & "', (SELECT CAST(GETDATE() AS date)),'" & login2.username & "','A.R Charge','N/A','0', '" & amount & "', 'N/A', '0', '0', '0', '" & amount & "', '0', '0', '0', '0', '', '','Short', 'N/A', '0','1', (SELECT GETDATE()), (SELECT GETDATE()), '1','Sales','" & ar_number & "')"
                    cmdd.ExecuteNonQuery()

                    cmdd.Parameters.Clear()
                    cmdd.CommandText = "INSERT INTO tblars1 (arnum,transnum,amountdue,name,status,date_created,created_by,area,invnum,type,typenum,sap_no,remarks,_from) VALUES (@arnum,@transnum, @amountdue, @name, @status,(SELECT GETDATE()), @createdby,@area,(Select TOP 1 invnum from tblinvsum WHERE area='Sales' order by invsumid DESC),@tayp,@typenum,@sap_no,@remarks,@_from)"
                    cmdd.Parameters.AddWithValue("@arnum", ar_number)
                    cmdd.Parameters.AddWithValue("@transnum", ar_number)
                    cmdd.Parameters.AddWithValue("@amountdue", amount)
                    cmdd.Parameters.AddWithValue("@name", "Short")
                    cmdd.Parameters.AddWithValue("@status", "Unpaid")
                    cmdd.Parameters.AddWithValue("@createdby", login2.username)
                    cmdd.Parameters.AddWithValue("@area", "Sales")
                    cmdd.Parameters.AddWithValue("@tayp", "AR Charge")
                    cmdd.Parameters.AddWithValue("@typenum", "AR")
                    cmdd.Parameters.AddWithValue("@sap_no", "To Follow")
                    cmdd.Parameters.AddWithValue("@remarks", "")
                    cmdd.Parameters.AddWithValue("@_from", "Actual Ending Balance")
                    cmdd.ExecuteNonQuery()
                    transaction.Commit()
                End Using
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Try
                transaction.Rollback()
            Catch ex2 As Exception
                MessageBox.Show(ex2.ToString)
            End Try
        End Try
    End Sub
End Class