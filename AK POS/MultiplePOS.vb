Imports System.Data.SqlClient
Public Class MultiplePOS
    Public orderids As String
    Dim cc As New connection_class
    Dim transaction As SqlTransaction
    Private Sub MultiplePOS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadData()
    End Sub

    Public Sub loadData()
        panelbody.Controls.Clear()
        orderids = orderids.Remove(orderids.Length - 1)
        Dim words As String() = orderids.Split(New Char() {","c})
        Dim word As String
        Dim grandTotal As Double = 0.00

        Dim y As Integer = 16
        Dim yAdd As Integer = 208
        For Each word In words
            grandTotal = grandTotal + returnGrandTotal(CInt(word))

            Dim panel As New Panel
            panel.Name = "panelSquare" & word
            panel.Size = New Size(1250, 183)
            panel.BackColor = Color.Gainsboro
            panel.Location = New Point(13, y)

            Dim labelOrder As New Label
            labelOrder.Name = "lblOrder" & word
            labelOrder.Text = "ORDER #: " & returnOrderNumber(CInt(word))
            labelOrder.Font = New Font("Arial Rounded MT Bold", 11.25)
            labelOrder.Size = New Size(500, 17)
            labelOrder.Location = New Point(12, 10)


            Dim dgv As New DataGridView
            dgv.Name = "dgv" & word
            dgv.Size = New Size(1200, 120)
            dgv.Anchor = AnchorStyles.Bottom AndAlso AnchorStyles.Top
            dgv.Location = New Point(15, 35)
            dgv.BorderStyle = BorderStyle.None
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
            dgv.ColumnHeadersHeight = 40
            dgv.EnableHeadersVisualStyles = False
            dgv.BackgroundColor = Color.White
            dgv.GridColor = Color.White
            dgv.RowHeadersVisible = False
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(218, 37, 28)
            dgv.ColumnHeadersDefaultCellStyle.Font = New Font("Arial Rounded MT Bold", 9.75)
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            dgv.AllowUserToAddRows = False

            Dim col As New DataGridViewTextBoxColumn
            col.HeaderText = "ITEM"
            col.Name = "itemname" & word
            col.ReadOnly = True
            dgv.Columns.Add(col)

            Dim col1 As New DataGridViewTextBoxColumn
            col1.HeaderText = "Qty"
            col1.Name = "qty" & word
            col1.ReadOnly = False
            dgv.Columns.Add(col1)

            Dim col2 As New DataGridViewTextBoxColumn
            col2.HeaderText = "Price"
            col2.Name = "price" & word
            col2.ReadOnly = True
            dgv.Columns.Add(col2)

            Dim col3 As New DataGridViewTextBoxColumn
            col3.HeaderText = "Disc.%"
            col3.Name = "discpercent" & word
            col3.ReadOnly = True
            dgv.Columns.Add(col3)

            Dim col4 As New DataGridViewTextBoxColumn
            col4.HeaderText = "Amount"
            col4.Name = "amtdue"
            col4.ReadOnly = True
            dgv.Columns.Add(col4)

            Dim col5 As New DataGridViewCheckBoxColumn
            col5.HeaderText = "Free"
            col5.Name = "checkfree" & word
            col5.ReadOnly = True
            dgv.Columns.Add(col5)

            Dim col6 As New DataGridViewTextBoxColumn
            col6.HeaderText = "Disc Amt."
            col6.Name = "discamt"
            col6.ReadOnly = True
            col6.Visible = False
            dgv.Columns.Add(col6)


            Dim col7 As New DataGridViewTextBoxColumn
            col7.HeaderText = "Price Before"
            col7.Name = "pricebefore" & word
            col7.ReadOnly = True
            col7.Visible = False
            dgv.Columns.Add(col7)

            Dim col8 As New DataGridViewButtonColumn
            col8.HeaderText = "Action"
            col8.Name = "btnRemove" & word
            col8.UseColumnTextForButtonValue = True
            col8.DefaultCellStyle.BackColor = Color.FromArgb(218, 37, 28)
            col8.DefaultCellStyle.ForeColor = Color.White
            col8.Text = "Remove"
            col8.FlatStyle = FlatStyle.Flat
            col8.Visible = False
            dgv.Columns.Add(col8)

            Dim col9 As New DataGridViewTextBoxColumn
            col9.HeaderText = "ID"
            col9.Name = "id" & word
            col9.ReadOnly = True
            col9.Visible = False
            dgv.Columns.Add(col9)

            Dim total As Double = 0.00
            cc.con.Open()
            cc.cmd = New SqlClient.SqlCommand("SELECT itemname,qty,price,dscnt,totalprice,free,discamt,pricebefore FROM tblorder2 where orderid=(SELECT orderid FROM tbltransaction2 WHERE orderid=" & word & ")", cc.con)
            cc.rdr = cc.cmd.ExecuteReader
            While cc.rdr.Read
                Dim itemName As String = cc.rdr("itemname")
                Dim qty As Double = cc.rdr("qty")
                Dim price As Double = cc.rdr("price")
                Dim dscnt As Double = cc.rdr("dscnt")
                Dim totalPrice As Double = cc.rdr("totalprice")
                Dim free As Integer = cc.rdr("free")
                Dim discamt As Double = cc.rdr("discamt")
                Dim priceBefore As Double = cc.rdr("pricebefore")

                dgv.Rows.Add(itemName, qty, price, dscnt, totalPrice, free, discamt, priceBefore, "")
                total = total + totalPrice
            End While
            cc.con.Close()


            Dim labelTotal As New Label
            labelTotal.Name = "labelTotal" & word
            labelTotal.Text = "TOTAL: " & total.ToString("n2")
            labelTotal.Font = New Font("Arial Rounded MT Bold", 11.25)
            labelTotal.Location = New Point(12, 160)
            labelTotal.Size = New Size(500, 17)

            panel.Controls.Add(labelOrder)
            panel.Controls.Add(dgv)
            panel.Controls.Add(labelTotal)
            panelbody.Controls.Add(panel)

            y = y + yAdd
        Next
        lblGrandTotal.Text = "GRAND TOTAL: " & grandTotal.ToString("n2")
    End Sub

    Public Function returnOrderNumber(ByVal orderid As Integer) As Integer
        Dim result As Integer = 0
        Try
            cc.con.Open()
            cc.cmd = New SqlClient.SqlCommand("SELECT ordernum FROM tblorder2 WHERE orderid=" & orderid & ";", cc.con)
            cc.rdr = cc.cmd.ExecuteReader
            If cc.rdr.Read Then
                result = cc.rdr("ordernum")
            End If
            cc.con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return result
    End Function

    Public Function returnGrandTotal(ByVal orderid As Integer) As Double
        Dim result As Double = 0.00
        Try
            cc.con.Open()
            cc.cmd = New SqlClient.SqlCommand("SELECT totalprice FROM tblorder2 WHERE orderid=" & orderid & ";", cc.con)
            cc.rdr = cc.cmd.ExecuteReader
            If cc.rdr.Read Then
                result = cc.rdr("totalprice")
            End If
            cc.con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return result
    End Function

    Public Function loadtransnum() As String
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
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information, "")
        End Try
        Return result
    End Function

    Public Function getID() As String
        Dim result As String = ""
        Try
            Dim id As String = ""
            Dim date_ As New DateTime()
            Dim query As String = "Select TOP 1 invnum from tblinvsum WHERE area='Sales' order by invsumid DESC"
            cc.con.Open()
            cc.cmd = New SqlCommand(query, cc.con)
            result = cc.cmd.ExecuteScalar
            cc.con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        Return result
    End Function

    Private Sub btnPay_Click(sender As Object, e As EventArgs) Handles btnPay.Click
        Dim transnum As String = loadtransnum()
        Dim inv_id As String = getID()

        Try
            Using connection As New SqlConnection(cc.conString)
                Dim cmdd As New SqlCommand(), seniorResult As Boolean = False, adptr As New SqlDataAdapter
                cmdd.Connection = connection

                connection.Open()
                transaction = connection.BeginTransaction()
                cmdd.Transaction = transaction


                orderids = orderids.Remove(orderids.Length - 1)
                Dim words As String() = orderids.Split(New Char() {","c})
                Dim word As String

                For Each word In words
                    If word <> "" Then
                        Dim dt As New DataTable
                        cmdd.Parameters.Clear()
                        cmdd.CommandType = CommandType.Text
                        cmdd.CommandText = "SELECT * FROM tbltransaction2 WHERE ordernum=(SELECT ordernum FROM tbltransaction2 WHERE orderid=" & word & ";"
                        adptr.SelectCommand = cmdd
                        adptr.Fill(dt)

                        For Each r0w As DataRow In dt.Rows
                            Dim arRemarks As String = ""
                            If r0w("tendertype") = "AR Sales" Or r0w("tendertype") = "AR Charge" Then
                                ar_remarks.ShowDialog()
                                arRemarks = ar_remarks.txtremarks.Text
                            End If

                            cmdd.Parameters.Clear()
                            cmdd.CommandText = "insertTransaction"
                            cmdd.CommandType = CommandType.StoredProcedure
                            cmdd.Parameters.Add(New SqlParameter("@ordernum", word))
                            cmdd.Parameters.Add(New SqlParameter("@or", r0w("ornum")))
                            cmdd.Parameters.Add(New SqlParameter("@transnum", transnum))
                            cmdd.Parameters.Add(New SqlParameter("@invnum", inv_id))
                            cmdd.Parameters.Add(New SqlParameter("@cashier", login2.username))
                            cmdd.Parameters.Add(New SqlParameter("@tendertype", r0w("tendertype")))
                            cmdd.Parameters.Add(New SqlParameter("@servicetype", r0w("servicetype")))
                            cmdd.Parameters.Add(New SqlParameter("@delcharge", CDbl(r0w("delcharge"))))
                            cmdd.Parameters.Add(New SqlParameter("@subtotal", CDbl(r0w("subtotal"))))
                            cmdd.Parameters.Add(New SqlParameter("@disctype", r0w("disctype")))
                            cmdd.Parameters.Add(New SqlParameter("@less", r0w("less")))
                            cmdd.Parameters.Add(New SqlParameter("@vatsales", 0))
                            cmdd.Parameters.Add(New SqlParameter("@vat", 0))
                            cmdd.Parameters.Add(New SqlParameter("@amtdue", CDbl(r0w("amtdue"))))
                            cmdd.Parameters.Add(New SqlParameter("@gctotal", CDbl(r0w("gctotal"))))
                            cmdd.Parameters.Add(New SqlParameter("@tenderamt", CDbl(r0w("tenderamt"))))
                            cmdd.Parameters.Add(New SqlParameter("@change", CDbl(r0w("change"))))
                            cmdd.Parameters.Add(New SqlParameter("@refund", 0))
                            cmdd.Parameters.Add(New SqlParameter("@comment", ""))
                            cmdd.Parameters.Add(New SqlParameter("@remarks", ""))
                            cmdd.Parameters.Add(New SqlParameter("@customer", r0w("customer")))
                            cmdd.Parameters.Add(New SqlParameter("@tinum", "N/A"))
                            cmdd.Parameters.Add(New SqlParameter("@tablenum", 0))
                            cmdd.Parameters.Add(New SqlParameter("@pax", 0))
                            cmdd.Parameters.Add(New SqlParameter("@status", 1))
                            cmdd.Parameters.Add(New SqlParameter("@area", "Sales"))
                            cmdd.Parameters.Add(New SqlParameter("@partialamt", 0))
                            cmdd.Parameters.Add(New SqlParameter("@typenum", "AR"))
                            cmdd.Parameters.Add(New SqlParameter("@sap_number", "To Follow"))
                            cmdd.Parameters.Add(New SqlParameter("@sap_remarks", ""))
                            cmdd.Parameters.Add(New SqlParameter("@typez", r0w("typez")))
                            cmdd.Parameters.Add(New SqlParameter("@discamt", CDbl(r0w("discamt"))))
                            cmdd.Parameters.Add(New SqlParameter("@salesname", r0w("cashier")))
                            cmdd.Parameters.Add(New SqlParameter("@username", login2.username))
                            cmdd.Parameters.Add(New SqlParameter("@ar_remarks", arRemarks))
                            Dim ar_type As String = ""
                            Select Case r0w("tendertype")
                                Case "Cash"
                                    ar_type = "AR Cash"
                                Case "A.R Sales"
                                    ar_type = "AR Sales"
                                Case "A.R Charge"
                                    ar_type = "AR Charge"
                            End Select
                            cmdd.Parameters.Add(New SqlParameter("@ar_type", ar_type))
                            cmdd.Parameters.Add(New SqlParameter("@ts", 0))
                            cmdd.ExecuteNonQuery()
                            cmdd.Parameters.Clear()
                            cmdd.CommandType = CommandType.Text
                            cmdd.CommandText = "SELECT systemid FROM tblsenior WHERE transnum=@ordernum AND CAST(datedisc AS date)=(select cast(getdate() as date)) AND status=3"
                            cmdd.Parameters.AddWithValue("@ordernum", word)
                            Dim drr As SqlDataReader = cmdd.ExecuteReader
                            If drr.Read Then
                                seniorResult = True
                            End If
                            drr.Close()

                            If seniorResult Then
                                cmdd.Parameters.Clear()
                                cmdd.CommandText = "UPDATE tblsenior SET status=1,transnum=@transnum WHERE transnum=@ordernum AND CAST(datedisc AS date)=(select cast(getdate() as date)) AND status=3"
                                cmdd.Parameters.Add(New SqlParameter("@transnum", transnum))
                                cmdd.Parameters.Add(New SqlParameter("@ordernum", r0w("ordernum")))
                                cmdd.ExecuteNonQuery()
                            End If
                        Next

                        Dim dtt As New DataTable
                        cmdd.Parameters.Clear()
                        cmdd.CommandText = "SELECT orderid,ordernum,itemname,qty,price,dscnt,totalprice,free,discamt,pricebefore FROM tblorder2 where orderid=(SELECT orderid FROM tbltransaction2 WHERE orderid=" & word & ")"
                        adptr.SelectCommand = cmdd
                        adptr.Fill(dtt)

                        For Each r0w As DataRow In dtt.Rows

                            cmdd.CommandText = "Insert into tblorder (transnum, category, itemname, qty, price, totalprice, dscnt, free, request, status, discprice, disctrans,area,invnum,type,gc,less,deliver,pricebefore,discamt,endbal_variance)values('" & transnum & "',(SELECT category FROM tblitems WHERE itemname='" & r0w("itemname") & "'),'" & r0w("itemname") & "','" & CDbl(r0w("qty")) & "','" & CDbl(r0w("price")) & "','" & CDbl(r0w("totalprice")) & "','" & CDbl(r0w("dscnt")) & "','" & r0w("free") & "','','1','0','" & "0" & "','" & "Sales" & "','" & inv_id & "',(SELECT tendertype FROM tbltransaction2 WHERE orderid=" & word & "),'0','0','" & "0" & "','" & CDbl(r0w("pricebefore")) & "','" & CDbl(r0w("discamt")) & "',(SELECT SUM(endbal-" & CDbl(r0w("qty")) & ") FROM tblinvitems WHERE invnum='" & inv_id & "' AND itemname='" & r0w("itemname") & "'))"
                            cmdd.CommandType = CommandType.Text
                            cmdd.ExecuteNonQuery()

                            cmdd.Parameters.Clear()
                            cmdd.CommandText = "UPDATE tblorder2 SET qty=@qty,dscnt=@discount,totalprice=@totalprice,discprice=@discprice,free=@free,pricebefore=@pricebefore,discamt=@discamt WHERE ordernum=@ordernum AND CAST(datecreated AS date)=(SELECT CAST(GETDATE() AS date))"
                            cmdd.Parameters.Add(New SqlParameter("@qty", CDbl(r0w("qty"))))
                            cmdd.Parameters.Add(New SqlParameter("@discount", CDbl(r0w("dscnt"))))
                            cmdd.Parameters.Add(New SqlParameter("@totalprice", CDbl(r0w("totalprice"))))
                            cmdd.Parameters.Add(New SqlParameter("@free", r0w("free")))
                            cmdd.Parameters.Add(New SqlParameter("@pricebefore", CDbl(r0w("pricebefore"))))
                            cmdd.Parameters.Add(New SqlParameter("@discamt", CDbl(r0w("discamt"))))
                            cmdd.Parameters.Add(New SqlParameter("@discprice", 0))
                            cmdd.Parameters.Add(New SqlParameter("@ordernum", r0w("ordernum")))
                            cmdd.ExecuteNonQuery()

                            cmdd.CommandText = "INSERT INTO tblars2 (transnum,description,quantity,price,amount,area,name) VALUES ('" & transnum & "', '" & r0w("itemname") & "' ,'" & CDbl(r0w("qty")) & "','" & CDbl(r0w("price")) & "','" & CDbl(r0w("totalprice")) & "','" & login2.wrkgrp & "',(SELECT tendertype FROM tbltransaction2 WHERE orderid=" & word & "))"
                            cmdd.ExecuteNonQuery()


                            Dim arVal As String = "", tendertype As String = ""
                            cmdd.Parameters.Clear()
                            cmdd.CommandType = CommandType.Text
                            cmdd.CommandText = "SELECT tendertype FROM tbltransaction2 WHERE orderid=" & word & ";"
                            Dim drr As SqlDataReader = cmdd.ExecuteReader
                            If drr.Read Then
                                tendertype = drr("tendertype")
                            End If
                            drr.Close()

                            Select Case tendertype
                                Case "A.R Charge"
                                    arVal = "archarge"
                                Case "Cash"
                                    arVal = "ctrout"
                                Case "A.R Sales"
                                    arVal = "arsales"
                            End Select

                            cmdd.CommandText = "Update tblinvitems set " & arVal & "+=" & CDbl(r0w("qty")) & ", endbal-=" & CDbl(r0w("qty")) & ", variance+=" & CDbl(r0w("qty")) & " where itemname='" & r0w("itemname") & "' AND invnum='" & inv_id & "';"
                            cmdd.ExecuteNonQuery()
                        Next
                    End If
                Next
                transaction.Commit()
            End Using
            MessageBox.Show("Transaction Completed", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Information)
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