Imports AK_POS.connection_class
Imports System.Data.SqlClient
Public Class pos_class
    Dim cc As New connection_class()
    Dim transaction As SqlTransaction
    Public Function checkOrderNumber(ByVal ordernumber As String) As Boolean
        Dim result_num As Integer = 0, result As Boolean = False
        cc.con.Open()
        cc.cmd = New SqlCommand("SELECT dbo.checkOrderNumber(@ordernum)", cc.con)
        cc.cmd.Parameters.AddWithValue("@ordernum", ordernumber)
        result_num = cc.cmd.ExecuteScalar()
        cc.con.Close()
        result = IIf(result_num = 1, True, False)
        Return result
    End Function

    Public Function checkCustomer(ByVal customername As String, ByVal typee As String) As Boolean
        Dim result_num As Integer = 0, result As Boolean = False
        cc.con.Open()
        cc.cmd = New SqlCommand("SELECT dbo.checkCustomer(@name,@type)", cc.con)
        cc.cmd.Parameters.AddWithValue("@name", customername)
        cc.cmd.Parameters.AddWithValue("@type", typee)
        result_num = cc.cmd.ExecuteScalar()
        cc.con.Close()
        result = IIf(result_num <> 0, True, False)
        Return result
    End Function

    Public Function checkStocks(ByVal dgv As DataGridView, ByVal invnum As String) As String
        Dim resut As String = ""
        For index As Integer = 0 To dgv.RowCount - 1
            Dim currentStock As Double = 0.00
            cc.con.Open()
            cc.cmd = New SqlCommand("Select a.endbal FROM tblinvitems a JOIN tblitems b On a.itemname = b.itemname WHERE a.invnum=@invnum And a.itemcode=@itemcode And a.itemname=@itemname And b.category !='Coffee Shop';", cc.con)
            cc.cmd.Parameters.AddWithValue("@invnum", invnum)
            cc.cmd.Parameters.AddWithValue("@itemcode", dgv.Rows(index).Cells("code").Value)
            cc.cmd.Parameters.AddWithValue("@itemname", dgv.Rows(index).Cells("description").Value)
            cc.rdr = cc.cmd.ExecuteReader
            If cc.rdr.Read Then
                currentStock = CDbl(cc.rdr("endbal"))
            End If
            cc.con.Close()

            If CDbl(dgv.Rows(index).Cells("quantity").Value) > currentStock And dgv.Rows(index).Cells("cat").Value <> "Coffee Shop" Then
                resut &= dgv.Rows(index).Cells("description").Value & " - Ending Balance (" & currentStock & ")" & Environment.NewLine
            End If
        Next
        Return resut
    End Function

    Public Function checkQuantity(ByVal dgv As DataGridView) As String
        Dim result As String = ""
        For index As Integer = 0 To dgv.Rows.Count - 1
            If dgv.Rows(index).Cells("quantity").Value = 0 Then
                result &= dgv.Rows(index).Cells("description").Value & Environment.NewLine
            End If
        Next
        Return result
    End Function

    Public Function checkQuantityLevel2(ByVal dgv As DataGridView) As String
        Dim resut As String = ""
        For index As Integer = 0 To dgv.RowCount - 1
            If CBool(dgv.Rows(index).Cells("free").Value) = False And CDbl(dgv.Rows(index).Cells("amtdue").Value) = 0 And CDbl(dgv.Rows(index).Cells("price").Value) <> 0 Then
                resut &= dgv.Rows(index).Cells("description").Value & Environment.NewLine
            End If
        Next
        Return resut
    End Function

    Public Function checkCSFree(ByVal dgv As DataGridView) As String
        Dim result As String = "", result_temp As String = "", errrrr As Integer = 0
        If pos_dialog.ans = "Coffee Shop" Then
            Dim free_count As Integer = 0
            For index As Integer = 0 To dgv.RowCount - 1
                Dim cs_result As Boolean = False, freee As Double = 0.00
                cc.con.Open()
                cc.cmd = New SqlCommand("SELECT free FROM tblcsitems WHERE itemid=(SELECT itemid FROM tblitems WHERE itemname=@itemname);", cc.con)
                cc.cmd.Parameters.AddWithValue("@itemname", dgv.Rows(index).Cells("description").Value)
                cc.rdr = cc.cmd.ExecuteReader
                If cc.rdr.Read Then
                    cs_result = True
                    freee = cc.rdr("free")
                End If
                cc.con.Close()
                If cs_result Then
                    free_count += freee * dgv.Rows(index).Cells("quantity").Value
                    result_temp = dgv.Rows(index).Cells("description").Value & " - Free(" & freee & ")"
                End If
                If CBool(dgv.Rows(index).Cells("free").Value) <> False And dgv.Rows(index).Cells("quantity").Value = free_count Then
                    errrrr += 1
                End If
            Next
            If errrrr = 0 Then
                result = result_temp
            End If
        End If
        Return result
    End Function

    Public Function checkItemAmount(ByVal dgv As DataGridView) As String
        Dim result As String = ""
        For index As Integer = 0 To dgv.RowCount - 1
            If pos_dialog.ans = "Wholesale" Then
                If CDbl(dgv.Rows(index).Cells("amtdue").Value) = 0 Then
                    result &= dgv.Rows(index).Cells("description").Value & Environment.NewLine
                End If
            End If
        Next
        Return result
    End Function

    Public Function advancePaymentTotal(ByVal value As String) As Double
        Dim wordz() As String = value.Split(New Char() {","c})
        Dim wordd As String = "", apamt As Double = 0.00
        Try
            For Each wordd In wordz
                If Not String.IsNullOrEmpty(wordd) Then
                    cc.con.Open()
                    cc.cmd = New SqlCommand("SELECT amount FROM tbladvancepayment WHERE apnum=@apnum AND type='Advance Payment' AND status='Active';", cc.con)
                    cc.cmd.Parameters.AddWithValue("@apnum", wordd)
                    cc.rdr = cc.cmd.ExecuteReader
                    While cc.rdr.Read
                        apamt += CDbl(cc.rdr("amount"))
                    End While
                    cc.con.Close()
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        Return apamt
    End Function

    Public Function itemsDepositPrice(ByVal dataItems As DataTable) As Double
        Dim result As Double = 0.00
        Try
            For Each r0w As DataRow In dataItems.Rows
                cc.con.Open()
                cc.cmd = New SqlCommand("SELECT ISNULL(SUM(" & CDbl(r0w("quantity")) & " * price),0) [depositPrice] FROM tbldepositprice WHERE itemid=(SELECT itemid FROM tblitems WHERE itemname=@itemname) AND status=1;", cc.con)
                cc.cmd.Parameters.AddWithValue("@itemname", r0w("itemname"))
                result += cc.cmd.ExecuteScalar
                cc.con.Close()
            Next
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        Return result
    End Function

    Public Function returnAPDEP(ByVal columnName As String, ByVal paramater As String) As String
        Dim result As String = ""
        Try
            cc.con.Open()
            cc.cmd = New SqlCommand("SELECT " & columnName & " FROM tbladvancepayment WHERE apnum=@type;", cc.con)
            cc.cmd.Parameters.AddWithValue("@type", paramater)
            result = cc.cmd.ExecuteScalar
            cc.con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        Return result
    End Function

    Public Function loadTransaction(ByVal orderid As Integer, ByVal isTransaction As Boolean) As DataTable
        Dim result As New DataTable(), adapter As New SqlDataAdapter
        Dim tranQuery = "SELECT * FROM tbltransaction2 WHERE orderid=" & orderid & ";"
        Dim ordQuery = "SELECT * FROM tblorder2 WHERE ordernum=(SELECT ordernum FROM tbltransaction2 WHERE orderid=" & orderid & ")"
        Dim resultQuery As String = IIf(isTransaction, tranQuery, ordQuery)
        cc.con.Open()
        cc.cmd = New SqlCommand(resultQuery, cc.con)
        adapter.SelectCommand = cc.cmd
        adapter.Fill(result)
        cc.con.Close()
        Return result
    End Function

    Public Function returnTransnum() As String
        Dim result As String = ""
        Try
            Dim area As String = "Sales"
            Dim selectcount_result As Integer = 0
            Dim branchcode As String = "", temp As String = "0", area_format As String = ""
            cc.con.Open()
            cc.cmd = New SqlCommand("SELECT ISNULL(MAX(transid),0) FROM tbltransaction WHERE area='" & area & "' AND tendertype !='Advance Payment' AND tendertype !='Cash Out' AND tendertype!='Deposit' AND tendertype !='Advance Payment Cash';", cc.con)
            selectcount_result = cc.cmd.ExecuteScalar() + 1
            cc.con.Close()

            cc.con.Open()
            cc.cmd = New SqlCommand("Select branchcode FROM tblbranch WHERE main='1';", cc.con)
            cc.rdr = cc.cmd.ExecuteReader
            If cc.rdr.Read Then
                branchcode = cc.rdr("branchcode")
            End If
            cc.con.Close()
            area_format = "TR - " & branchcode & " - "
            If selectcount_result < 1000000 Then
                Dim cselectcount_result As String = CStr(selectcount_result)
                For vv As Integer = 1 To 6 - cselectcount_result.Length
                    temp += "0"
                Next
                result = area_format & temp & selectcount_result
            Else
                result = area_format & temp & selectcount_result
            End If

            result = area_format & temp & selectcount_result

        Catch ex As System.InvalidOperationException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "")
        End Try
        Return result
    End Function

    Public Function checkSenior(ByVal ordernum As Integer) As Boolean
        Dim result As Boolean
        Try
            cc.con.Open()
            cc.cmd = New SqlCommand("SELECT systemid FROM tblsenior WHERE transnum=@ordernum AND CAST(datedisc AS date)=(select cast(getdate() as date)) AND status=3", cc.con)
            cc.cmd.Parameters.AddWithValue("@ordernum", ordernum)
            cc.rdr = cc.cmd.ExecuteReader
            If cc.rdr.Read Then
                result = True
            End If
            cc.con.Close()
        Catch ex As Exception
            MessageBox.Show("checkSenior() " & ex.ToString)
        End Try
        Return result
    End Function

    Public Function getInventoryType(ByVal orderid As Integer) As String
        Dim result As String = ""
        cc.con.Open()
        cc.cmd = New SqlCommand("SELECT inventory_type [result] FROM tbltransaction2 WHERE orderid=" & orderid & ";", cc.con)
        cc.rdr = cc.cmd.ExecuteReader
        If cc.rdr.Read Then
            result = cc.rdr("result")
        End If
        cc.con.Close()
        Return result
    End Function

    Public Function getDiscountPercent(ByVal discountType As String) As Double
        Dim result As Double = 0.00
        Try
            cc.con.Open()
            cc.cmd = New SqlCommand("SELECT amount [result]  FROM tbldiscount WHERE status = 1 AND disname='" & discountType & "';", cc.con)
            cc.rdr = cc.cmd.ExecuteReader
            If cc.rdr.Read Then
                result = cc.rdr("result")
            End If
            cc.con.Close()
        Catch ex As Exception
            MessageBox.Show("getDiscountPercent() " & ex.ToString)
        End Try
        Return result
    End Function

    Public Sub insertMultiplePOS(ByVal orderids As String)
        orderids = orderids.Remove(orderids.Length - 1)
        Dim words As String() = orderids.Split(New Char() {","c})
        For Each word As String In words
            Dim dtTransaction As New DataTable()
            dtTransaction = loadTransaction(word, True)
            For Each r0w As DataRow In dtTransaction.Rows
                Dim transnum As String = returnTransnum()
                Try
                    Using connection As New SqlConnection(cc.conString)
                        Dim cmdd As New SqlCommand()

                        cmdd.Connection = connection

                        connection.Open()
                        transaction = connection.BeginTransaction()
                        cmdd.Transaction = transaction

                        cmdd.Parameters.Clear()
                        cmdd.CommandText = "UPDATE tbltransaction2 SET transnum=@transnum, status2='Paid' WHERE orderid=@orderid"
                        cmdd.Parameters.AddWithValue("@orderid", word)
                        cmdd.Parameters.AddWithValue("@transnum", transnum)
                        cmdd.ExecuteNonQuery()

                        cmdd.Parameters.Clear()
                        cmdd.CommandText = "Insert into tbltransaction (ornum, transnum, transdate, cashier, tendertype, servicetype, delcharge, subtotal, disctype, less, vatsales, vat, amtdue, gctotal, tenderamt, change, refund, comment, remarks, customer, tinnum, tablenum, pax, datecreated, datemodified, status,area,invnum,partialamt,typenum,sap_number,sap_remarks,typez,discamt,auth_systemid,salesname,inventory_type) values (@or, @transnum, (select cast(getdate()  as date)),@username, @tendertype, @servicetype,@delcharge, @subtotal,@disctype,@less, @vatsales,@vat,@amtdue, @gctotal, @tenderamt,@change, @refund,@comment, @ar_remarks, @customer,@tinum, @tablenum, @pax,(SELECT GETDATE()),(SELECT GETDATE()), @status,@area,(Select TOP 1 invnum from tblinvsum WHERE area='Sales' order by invsumid DESC),@partialamt,@typenum,@sap_number,@sap_remarks,@typez,@discamt,(SELECT systemid FROM tblusers WHERE username=@username),@salesname,@inv_type)"
                        cmdd.Parameters.AddWithValue("@or", r0w("ornum"))
                        cmdd.Parameters.AddWithValue("@transnum", transnum)
                        cmdd.Parameters.AddWithValue("@username", login2.username)
                        cmdd.Parameters.AddWithValue("@tendertype", r0w("tendertype"))
                        cmdd.Parameters.AddWithValue("@servicetype", r0w("servicetype"))
                        cmdd.Parameters.AddWithValue("@delcharge", CDbl(r0w("delcharge")))
                        cmdd.Parameters.AddWithValue("@subtotal", CDbl(r0w("subtotal")))
                        cmdd.Parameters.AddWithValue("@disctype", r0w("disctype"))
                        cmdd.Parameters.AddWithValue("@less", CDbl(r0w("less")))
                        cmdd.Parameters.AddWithValue("@vatsales", CDbl(r0w("vatsales")))
                        cmdd.Parameters.AddWithValue("@vat", CDbl(r0w("vat")))
                        cmdd.Parameters.AddWithValue("@amtdue", CDbl(r0w("amtdue")))
                        cmdd.Parameters.AddWithValue("@gctotal", CDbl(r0w("gctotal")))
                        cmdd.Parameters.AddWithValue("@tenderamt", CDbl(r0w("tenderamt")))
                        cmdd.Parameters.AddWithValue("@change", CDbl(r0w("change")))
                        cmdd.Parameters.AddWithValue("@refund", CDbl(r0w("refund")))
                        cmdd.Parameters.AddWithValue("@comment", "")
                        cmdd.Parameters.AddWithValue("@ar_remarks", "")
                        cmdd.Parameters.AddWithValue("@customer", r0w("customer"))
                        cmdd.Parameters.AddWithValue("@tinum", r0w("tinnum"))
                        cmdd.Parameters.AddWithValue("@tablenum", r0w("tablenum"))
                        cmdd.Parameters.AddWithValue("@pax", r0w("pax"))
                        cmdd.Parameters.AddWithValue("@status", 1)
                        cmdd.Parameters.AddWithValue("@area", "Sales")
                        cmdd.Parameters.AddWithValue("@partialamt", 0)
                        cmdd.Parameters.AddWithValue("@typenum", "AR")
                        cmdd.Parameters.AddWithValue("@sap_number", "To Follow")
                        cmdd.Parameters.AddWithValue("@sap_remarks", "")
                        cmdd.Parameters.AddWithValue("@typez", r0w("typez"))
                        cmdd.Parameters.AddWithValue("@discamt", CDbl(r0w("discamt")))
                        cmdd.Parameters.AddWithValue("@salesname", r0w("cashier"))
                        cmdd.Parameters.AddWithValue("@inv_type", r0w("inventory_type"))
                        cmdd.ExecuteNonQuery()

                        cmdd.Parameters.Clear()
                        cmdd.CommandText = "INSERT INTO tblars1 (arnum,transnum,amountdue,name,status,date_created,created_by, area,invnum,type,balance,typenum,sap_no,remarks,_from) VALUES (@transnum,@transnum, @amtdue, @customer, 'Unpaid',(SELECT GETDATE()), @username,@area,(Select TOP 1 invnum from tblinvsum WHERE area='Sales' order by invsumid DESC),@ar_type, @amtdue,@typenum,'To Follow','','POS')"
                        cmdd.Parameters.AddWithValue("@transnum", transnum)
                        cmdd.Parameters.AddWithValue("@amtdue", CDbl(r0w("amtdue")))
                        cmdd.Parameters.AddWithValue("@customer", r0w("customer"))
                        cmdd.Parameters.AddWithValue("@username", login2.username)
                        cmdd.Parameters.AddWithValue("@area", "Sales")
                        Dim ar_type As String = ""
                        Select Case r0w("tendertype")
                            Case "Cash"
                                ar_type = "AR Cash"
                            Case "A.R Sales"
                                ar_type = "AR Sales"
                            Case "A.R Charge"
                                ar_type = "AR Charge"
                        End Select
                        cmdd.Parameters.AddWithValue("@ar_type", ar_type)
                        cmdd.Parameters.AddWithValue("@typenum", "AR")
                        cmdd.ExecuteNonQuery()

                        Dim haveSenior As Boolean = checkSenior(r0w("ordernum"))
                        If haveSenior Then
                            cmdd.Parameters.Clear()
                            cmdd.CommandText = "UPDATE tblsenior SET status=1,transnum=@transnum WHERE transnum=@ordernum AND CAST(datedisc AS date)=(select cast(getdate() as date)) AND status=3"
                            cmdd.Parameters.Add(New SqlParameter("@transnum", transnum))
                            cmdd.Parameters.Add(New SqlParameter("@ordernum", CInt(r0w("ordernum"))))
                            cmdd.ExecuteNonQuery()
                        End If

                        Dim type As String = r0w("tendertype")
                        Dim dtOrders As New DataTable()
                        Dim adapter2 As New SqlDataAdapter
                        cmdd.Parameters.Clear()
                        cmdd.CommandText = "SELECT * FROM tblorder2 WHERE ordernum=(SELECT ordernum FROM tbltransaction2 WHERE orderid=" & word & ")"
                        adapter2.SelectCommand = cmdd
                        adapter2.Fill(dtOrders)
                        For Each r0w2 As DataRow In dtOrders.Rows
                            cmdd.Parameters.Clear()
                            cmdd.CommandText = "Insert into tblorder (transnum, category, itemname, qty, price, totalprice, dscnt, free, request, status, discprice, disctrans,area,invnum,type,gc,less,deliver,pricebefore,discamt,endbal_variance)values(@transnum,(SELECT category FROM tblitems WHERE itemname=@itemname),@itemname,@qty,(SELECT price FROM tblitems WHERE itemname=@itemname),@totalprice,@discountpercent,@free,'',1,@discprice,0,'Sales',(Select TOP 1 invnum from tblinvsum WHERE area='Sales' order by invsumid DESC),@type,0,0,'" & "0" & "',@pricebefore,@discamt,(SELECT SUM(endbal-@qty) FROM tblinvitems WHERE invnum=(Select TOP 1 invnum from tblinvsum WHERE area='Sales' order by invsumid DESC) AND itemname=@itemname))"
                            cmdd.CommandType = CommandType.Text
                            cmdd.Parameters.AddWithValue("@transnum", transnum)
                            cmdd.Parameters.AddWithValue("@itemname", r0w2("itemname"))
                            cmdd.Parameters.AddWithValue("@qty", CDbl(r0w2("qty")))
                            cmdd.Parameters.AddWithValue("@totalprice", CDbl(r0w2("totalprice")))
                            cmdd.Parameters.AddWithValue("@discountpercent", CDbl(r0w2("dscnt")))
                            cmdd.Parameters.AddWithValue("@free", CInt(r0w2("free")))
                            cmdd.Parameters.AddWithValue("@discprice", CDbl(r0w2("discprice")))
                            cmdd.Parameters.AddWithValue("@type", type)
                            cmdd.Parameters.AddWithValue("@pricebefore", CDbl(r0w2("pricebefore")))
                            cmdd.Parameters.AddWithValue("@discamt", CDbl(r0w2("discamt")))
                            cmdd.ExecuteNonQuery()

                            cmdd.Parameters.Clear()
                            cmdd.CommandText = "INSERT INTO tblars2 (transnum,description,quantity,price,amount,area,name) VALUES (@transnum,@itemname,@qty,(SELECT price FROM tblitems WHERE itemname=@itemname),@amtdue,@workgroup,@name)"
                            cmdd.Parameters.AddWithValue("@transnum", transnum)
                            cmdd.Parameters.AddWithValue("@itemname", r0w2("itemname"))
                            cmdd.Parameters.AddWithValue("@qty", CDbl(r0w2("qty")))
                            cmdd.Parameters.AddWithValue("@amtdue", CDbl(r0w2("totalprice")))
                            cmdd.Parameters.AddWithValue("@workgroup", login2.wrkgrp)
                            cmdd.Parameters.AddWithValue("@name", r0w("customer"))
                            cmdd.ExecuteNonQuery()

                            Dim arVal As String = ""
                            Select Case r0w("tendertype")
                                Case "A.R Charge"
                                    arVal = "archarge"
                                Case "Cash"
                                    arVal = "ctrout"
                                Case "A.R Sales"
                                    arVal = "arsales"
                            End Select

                            If (r0w("inventory_type")) = "Main Inventory" Then
                                cmdd.CommandText = "Update tblinvitems set " & arVal & "+=" & CDbl(r0w2("qty")) & ", endbal-=" & CDbl(r0w2("qty")) & ", variance+=" & CDbl(r0w2("qty")) & " where itemname='" & r0w2("itemname") & "' AND invnum=(Select TOP 1 invnum from tblinvsum WHERE area='Sales' order by invsumid DESC);"
                                cmdd.ExecuteNonQuery()
                            End If
                        Next

                        transaction.Commit()
                    End Using
                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                    Try
                        transaction.Rollback()
                    Catch ex2 As Exception
                        MessageBox.Show(ex2.ToString)
                    End Try
                End Try
            Next
        Next
        MessageBox.Show("Transaction Completed", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class
