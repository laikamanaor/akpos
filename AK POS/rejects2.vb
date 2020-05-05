Imports System.Data.SqlClient
Imports System.IO
Public Class rejects2
    Dim strconn As String = login.ss
    Dim con As New SqlConnection(strconn)
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader

    Dim tayp As String = "", ar_number As String = "", conv_number As String = "", selectQuantity As String = "", transnum As String = ""


    Public lcacc As String = ""

    Public Function decryptConString() As String
        Dim base64encoded As String = File.ReadAllText("connectionstring.txt")
        Dim data As Byte() = System.Convert.FromBase64String(base64encoded)
        Return System.Text.ASCIIEncoding.ASCII.GetString(data)
    End Function

    Private Sub rejects2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rbarreject.Checked = True
        loadItems()
        loadEmployees()
    End Sub

    Public Sub loadEmployees()
        Try
            Dim auto As New AutoCompleteStringCollection()
            con.Open()
            cmd = New SqlCommand("SELECT name FROM tblcustomers WHERE status=1 AND type='Employee';", con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                auto.Add(CStr(rdr("name")))
            End While
            con.Close()
            txtname.AutoCompleteCustomSource = auto
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
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
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Function
    Public Sub getID()
        Dim id As String = ""
        Dim date_ As New DateTime()
        con.Open()
        cmd = New SqlCommand("Select TOP 1 invnum,datecreated from tblinvsum WHERE area='" & lcacc & "' order by invsumid DESC", con)
        rdr = cmd.ExecuteReader()
        If rdr.Read() Then
            id = rdr("invnum")
            date_ = CDate(rdr("datecreated"))
        End If
        con.Close()
        If date_.ToString("MM/dd/yyyy") = getSystemDate.ToString("MM/dd/yyyy") Then
            lblID.Text = id
        Else
            lblID.Text = "N/A"
        End If
    End Sub
    Public Sub loadItems()
        Try
            getID()
            dgvListItem.Rows.Clear()
            con.Open()
            cmd = New SqlCommand("SELECT tblinvitems.itemcode,tblinvitems.itemname,tblitems.category,tblinvitems.reject FROM tblinvitems JOIN tblitems ON tblitems.itemname = tblinvitems.itemname AND tblitems.itemcode = tblinvitems.itemcode WHERE invnum='" & lblID.Text & "' AND reject !=0;", con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                dgvListItem.Rows.Add(rdr("itemcode"), rdr("itemname"), rdr("category"), rdr("reject"))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub dgvListItem_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvListItem.CellClick
        Try
            If e.ColumnIndex = 4 Then
                lblQuantityItemCode.Text = "Item Code: " & dgvListItem.CurrentRow.Cells("itemcode").Value.ToString
                lblQuantityItemName.Text = "Item Name: " & dgvListItem.CurrentRow.Cells("itemname").Value.ToString
                lblQuantityCategory.Text = "Category: " & dgvListItem.CurrentRow.Cells("category").Value.ToString
                txtboxQuantity.Text = ""
                selectQuantity = "Add"
                panelQuantity.Visible = True
                panelQuantity.BringToFront()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Public Function checkRowsExist() As Boolean
        Dim get_itemname As String = lblQuantityItemName.Text.Replace("Item Name: ", "")
        Dim get_itemcode As String = lblQuantityItemCode.Text.Replace("Item Code: ", "")
        For i As Integer = 0 To dgvSelectedItem.Rows.Count - 1
            If get_itemcode = dgvSelectedItem.Rows(i).Cells(0).Value And get_itemname = dgvSelectedItem.Rows(i).Cells(1).Value Then
                Dim quantity_add As Integer = Val(dgvSelectedItem.Rows(i).Cells("quantityy").Value) + Val(txtboxQuantity.Text)

                If selectQuantity = "Add" Then
                    dgvSelectedItem.Rows(i).Cells("quantityy").Value = quantity_add
                Else
                    dgvSelectedItem.Rows(i).Cells("quantityy").Value = txtboxQuantity.Text
                End If

                Me.Cursor = Cursors.WaitCursor
                panelQuantity.Visible = False
                Me.Cursor = Cursors.Default
                txtboxQuantity.Text = ""
                dgvSelectedItem.ClearSelection()
                dgvSelectedItem.Rows(dgvSelectedItem.Rows.Count - 1).Selected = True
                Return True
            End If
        Next
    End Function
    Private Sub btnQuantity_Click(sender As Object, e As EventArgs) Handles btnQuantity.Click
        Try
            Dim get_itemname As String = lblQuantityItemName.Text.Replace("Item Name: ", "")
            Dim get_itemcode As String = lblQuantityItemCode.Text.Replace("Item Code: ", "")
            Dim get_category As String = lblQuantityCategory.Text.Replace("Category: ", "")
            If String.IsNullOrEmpty(txtboxQuantity.Text) Then
                MessageBox.Show("Please input quantity", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf CDbl(txtboxQuantity.Text) < 0 Then
                MessageBox.Show("Please input quantity", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf checkRowsExist() Then
                Return
            Else
                Dim result As Double = 0.00
                con.Open()
                cmd = New SqlCommand("SELECT reject FROM tblinvitems WHERE itemname=@itemname AND itemcode=itemcode AND invnum=@invnum;", con)
                cmd.Parameters.AddWithValue("@itemname", dgvListItem.CurrentRow.Cells("itemname").Value)
                cmd.Parameters.AddWithValue("@itemcode", dgvListItem.CurrentRow.Cells("itemcode").Value)
                cmd.Parameters.AddWithValue("@invnum", lblID.Text)
                rdr = cmd.ExecuteReader
                If rdr.Read Then
                    result = CDbl(rdr("reject"))
                End If
                con.Close()
                If result < CDbl(txtboxQuantity.Text) Then
                    MessageBox.Show("Insufficient Stock", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    loadItems()
                Else
                    dgvSelectedItem.Rows.Add(get_itemcode, get_itemname, get_category, txtboxQuantity.Text)
                    txtboxQuantity.Text = ""
                    panelQuantity.Visible = False
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub dgvSelectedItem_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSelectedItem.CellClick
        If e.ColumnIndex = 4 Then
            lblQuantityItemCode.Text = "Item Code: " & dgvSelectedItem.CurrentRow.Cells("itemcodee").Value.ToString
            lblQuantityItemName.Text = "Item Name: " & dgvSelectedItem.CurrentRow.Cells("itemnamee").Value.ToString
            lblQuantityCategory.Text = "Category: " & dgvSelectedItem.CurrentRow.Cells("categoryy").Value.ToString
            panelQuantity.Visible = True
            selectQuantity = "Edit"
            panelQuantity.BringToFront()
            txtboxQuantity.Text = dgvSelectedItem.CurrentRow.Cells("quantityy").Value
        ElseIf e.ColumnIndex = 5 Then
            Dim a As String = MsgBox("Are you sure you want to delete?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "")
            If a = vbYes Then
                dgvSelectedItem.Rows.RemoveAt(e.RowIndex)
            End If
        End If
    End Sub

    Private Sub lblClose_Click(sender As Object, e As EventArgs) Handles lblClose.Click
        panelQuantity.Visible = False
        txtboxQuantity.Text = ""
    End Sub

    Private Sub lblclosesap_Click(sender As Object, e As EventArgs) Handles lblclosesap.Click
        panelsap.Visible = False
        txtname.Text = ""
        txtsap.Text = ""
        txtremarks.Text = ""
    End Sub

    Private Sub rbarreject_CheckedChanged(sender As Object, e As EventArgs) Handles rbarreject.CheckedChanged
        txtname.Enabled = False
        txtname.Text = ""
        lblsapdoc.Text = "AR"
        tayp = "AR Reject"
    End Sub

    Private Sub rbarcharge_CheckedChanged(sender As Object, e As EventArgs) Handles rbarcharge.CheckedChanged
        txtname.Enabled = True
        txtname.Text = ""
        lblsapdoc.Text = "AR"
        tayp = "AR Charge"
    End Sub

    Private Sub rbconvout_CheckedChanged(sender As Object, e As EventArgs) Handles rbconvout.CheckedChanged
        txtname.Enabled = False
        txtname.Text = ""
        lblsapdoc.Text = "Conversion Out"
        tayp = "Parent"
    End Sub
    Public Sub getARNum(ByVal typee As String, ByVal formatsu As String)
        Try
            Dim temp As String = "1", area_format As String = "", selectcount_result As Integer = 0
            con.Open()
            cmd = New SqlCommand("Select COUNT(*)  from tblars1 WHERE area='" & lcacc & "' AND type=@type;", con)
            cmd.Parameters.AddWithValue("@type", typee)
            selectcount_result = cmd.ExecuteScalar() + 1
            con.Close()

            Dim branchcode As String = ""
            con.Open()
            cmd = New SqlCommand("SELECT branchcode FROM tblbranch WHERE main='1';", con)
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                branchcode = rdr("branchcode")
            End If
            con.Close()


            Dim format As String = "PRODAR" & formatsu & " - "

            area_format = format & branchcode & " - "

            If selectcount_result < 1000000 Then
                Dim cselectcount_result As String = CStr(selectcount_result)
                For vv As Integer = 1 To 6 - cselectcount_result.Length
                    temp += "0"
                Next
                ar_number = area_format & temp & selectcount_result
            End If
        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information, "")
        Finally
            con.Close()
        End Try
    End Sub

    Public Sub insertQuery(tayp As String, formatsu As String)
        Dim aa As String = lcacc

        Dim amt As Double = 0.0
        If tayp = "AR Charge" Then
            For i As Integer = 0 To dgvSelectedItem.Rows.Count - 1
                con.Open()
                cmd = New SqlCommand("SELECT price FROM tblitems WHERE itemname='" & dgvSelectedItem.Rows(i).Cells("itemnamee").Value & "' AND itemcode='" & dgvSelectedItem.Rows(i).Cells("itemcodee").Value & "' AND category='" & dgvSelectedItem.Rows(i).Cells("categoryy").Value & "';", con)
                rdr = cmd.ExecuteReader()
                If rdr.Read Then
                    amt += Val(rdr("price")) * Val(dgvSelectedItem.Rows(i).Cells("quantityy").Value)
                End If
                con.Close()
            Next
        End If

        getARNum(tayp, formatsu)
        con.Open()
        cmd = New SqlCommand("INSERT INTO tblars1 (arnum,transnum,amountdue,name,status,date_created,created_by,area,invnum,type,typenum,sap_no,remarks,_from) VALUES (@arnum,@transnum, @amountdue, @name, @status,(SELECT GETDATE()), @createdby,@area,@invnum,@tayp,@typenum,@sap_no,@remarks,@from)", con)
        cmd.Parameters.AddWithValue("@arnum", ar_number)
        cmd.Parameters.AddWithValue("@transnum", ar_number)
        cmd.Parameters.AddWithValue("@amountdue", amt)
        cmd.Parameters.AddWithValue("@name", IIf(tayp = "AR Reject", "Reject", txtname.Text))
        cmd.Parameters.AddWithValue("@status", "Unpaid")
        cmd.Parameters.AddWithValue("@createdby", login.username)


        cmd.Parameters.AddWithValue("@area", aa)
        cmd.Parameters.AddWithValue("@invnum", lblID.Text)
        cmd.Parameters.AddWithValue("@tayp", tayp)
        cmd.Parameters.AddWithValue("@from", "Rejects")
        cmd.Parameters.AddWithValue("@typenum", "AR")

        Dim sap As String = ""
        If txtsap.Enabled = True Then
            sap = txtsap.Text
        Else
            sap = "To Follow"
        End If

        cmd.Parameters.AddWithValue("@sap_no", sap)
        cmd.Parameters.AddWithValue("@remarks", txtremarks.Text)
        cmd.ExecuteNonQuery()
        con.Close()

        If tayp = "AR Charge" Then

            Dim zz As String = getSystemDate.ToString("MM/dd/yyyy")

            con.Open()
            cmd = New SqlCommand("Insert into tbltransaction (ornum, transnum, transdate, cashier, tendertype, servicetype, delcharge, subtotal, disctype, less, vatsales, vat, amtdue, gctotal, tenderamt, change, refund, comment, remarks, customer, tinnum, tablenum, pax, datecreated, datemodified, status,area,invnum,partialamt) values ('0', '" & ar_number & "', '" & zz & "','" & login.cashier & "','A.R Charge','N/A','0', '" & amt & "', 'N/A', '0', '0', '0', '" & amt & "', '0', '0', '0', '0', '', '','" & txtname.Text & "' , 'N/A', '0','1',(SELECT GETDATE()),(SELECT GETDATE()), '1','" & aa & "','" & lblID.Text & "','0')", con)
            cmd.ExecuteNonQuery()
            con.Close()
        End If

        For j As Integer = 0 To dgvSelectedItem.Rows.Count - 1
            Dim price As Double = 0.0, amount As Double = 0.0
            If tayp = "AR Charge" Then
                con.Open()
                cmd = New SqlCommand("SELECT price FROM tblitems WHERE itemname='" & dgvSelectedItem.Rows(j).Cells("itemnamee").Value & "' AND itemcode='" & dgvSelectedItem.Rows(j).Cells("itemcodee").Value & "' AND category='" & dgvSelectedItem.Rows(j).Cells("categoryy").Value & "';", con)
                rdr = cmd.ExecuteReader()
                If rdr.Read Then
                    price = Val(rdr("price"))
                    amount += Val(rdr("price")) * Val(dgvSelectedItem.Rows(j).Cells("quantityy").Value)
                End If
                con.Close()
            End If


            con.Open()
            cmd = New SqlCommand("INSERT INTO tblars2 (transnum,description,quantity,price,amount,area,name) VALUES (@tnum, @des,@qua,@price,@am,@area,@name)", con)
            cmd.Parameters.AddWithValue("@tnum", ar_number)
            cmd.Parameters.AddWithValue("@des", dgvSelectedItem.Rows(j).Cells("itemnamee").Value)
            cmd.Parameters.AddWithValue("@qua", dgvSelectedItem.Rows(j).Cells("quantityy").Value)
            cmd.Parameters.AddWithValue("@price", price)
            cmd.Parameters.AddWithValue("@am", amount)
            cmd.Parameters.AddWithValue("@area", aa)
            cmd.Parameters.AddWithValue("@name", IIf(tayp = "AR Reject", "Reject", txtname.Text))
            cmd.ExecuteNonQuery()
            con.Close()

            If tayp = "AR Charge" Then
                con.Open()
                cmd = New SqlCommand("Insert into tblorder (transnum, category, itemname, qty, price, totalprice, dscnt, free, request, status, discprice, disctrans,area,invnum,type)values('" & ar_number & "','" & dgvSelectedItem.Rows(j).Cells("categoryy").Value & "','" & dgvSelectedItem.Rows(j).Cells("itemnamee").Value & "','" & dgvSelectedItem.Rows(j).Cells("quantityy").Value & "','" & price & "','" & amount & "','0','0','0','1','0','0','" & aa & "','" & lblID.Text & "','" & "A.R Charge" & "')", con)
                cmd.ExecuteNonQuery()
                con.Close()
            End If

            updateInventory(IIf(tayp = "AR Charge", "reject_archarge", "arreject"), CDbl(dgvSelectedItem.Rows(j).Cells("quantityy").Value), dgvSelectedItem.Rows(j).Cells("itemnamee").Value)
        Next
        MessageBox.Show("Transaction Completed", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Information)
        panelsap.Visible = False
    End Sub
    Public Sub getConvNum()
        Try
            Dim temp As String = "1", area_format As String = "", selectcount_result As Integer = 0
            con.Open()
            cmd = New SqlCommand("Select COUNT(*)  from tblconversion WHERE area='" & lcacc & "' AND type='Parent';", con)
            selectcount_result = cmd.ExecuteScalar() + 1
            con.Close()

            Dim branchcode As String = ""
            con.Open()
            cmd = New SqlCommand("SELECT branchcode FROM tblbranch WHERE main='1';", con)
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                branchcode = rdr("branchcode")
            End If
            con.Close()


            Dim format As String = ""
            If lcacc = "Production" Then
                format = "PRODCONVOUT - "
            ElseIf lcacc = "Sales" Then
                format = "SALCONVOUT - "
            End If

            area_format = format & branchcode & " - "

            If selectcount_result < 1000000 Then
                Dim cselectcount_result As String = CStr(selectcount_result)
                For vv As Integer = 1 To 6 - cselectcount_result.Length
                    temp += "0"
                Next
                conv_number = area_format & temp & selectcount_result
            End If
        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information, "")
        Finally
            con.Close()
        End Try
    End Sub

    Public Sub updateInventory(a As String, current As Double, itemname As String)
        Try
            Dim b As Double = 0.00, reject_undecided As Double = 0.00, totalav As Double = 0.00, endbal As Double = 0.00, actualendbal As Double = 0.00, variance As Double = 0.00, so As String = ""
            con.Open()
            cmd = New SqlCommand("SELECT endbal,reject, " & a & " AS b,actualendbal,reject_totalav,actualendbal FROM tblinvitems WHERE invnum=@invnum AND itemname=@itemname;", con)
            cmd.Parameters.AddWithValue("@invnum", lblID.Text)
            cmd.Parameters.AddWithValue("@itemname", itemname)
            rdr = cmd.ExecuteReader
            While rdr.Read
                reject_undecided = CDbl(rdr("reject"))
                b = CDbl(rdr("b"))
                totalav = CDbl(rdr("reject_totalav"))
                endbal = CDbl(rdr("endbal"))
                actualendbal = CDbl(rdr("actualendbal"))
            End While
            con.Close()

            b += current
            reject_undecided -= current
            totalav -= current
            endbal -= current

            variance = actualendbal - endbal
            If variance < 0 Then
                so = "Short"
            Else
                so = "Over"
            End If

            con.Open()
            cmd = New SqlCommand("UPDATE tblinvitems SET reject=@r, " & a & "=@a,reject_totalav=@total,endbal=@ee,variance=@var,shortover=@so WHERE invnum=@invnum2 AND itemname=@itemname2;", con)
            cmd.Parameters.AddWithValue("@r", reject_undecided)
            cmd.Parameters.AddWithValue("@a", b)
            cmd.Parameters.AddWithValue("@ee", endbal)
            cmd.Parameters.AddWithValue("@total", totalav)
            cmd.Parameters.AddWithValue("@var", variance)
            cmd.Parameters.AddWithValue("@so", so)
            cmd.Parameters.AddWithValue("@invnum2", lblID.Text)
            cmd.Parameters.AddWithValue("@itemname2", itemname)
            cmd.ExecuteNonQuery()
            con.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub rbtransfer_CheckedChanged(sender As Object, e As EventArgs) Handles rbtransfer.CheckedChanged
        txtname.Enabled = False
        txtname.Text = ""
        lblsapdoc.Text = "IT"
        tayp = "transfer"
    End Sub

    Private Sub btnProceed_Click(sender As Object, e As EventArgs) Handles btnProceed.Click
        Try
            Dim z As String = ""
            Select Case tayp
                Case "AR Reject"
                    insertQuery("AR Reject", "RE")
                Case "AR Charge"
                    insertQuery("AR Charge", "CH")
                Case "Parent"
                    getConvNum()
                    For index As Integer = 0 To dgvSelectedItem.Rows.Count - 1
                        con.Open()
                        cmd = New SqlCommand("INSERT INTO tblconversion (conv_number,inv_number,item_code,item_name,category,quantity,type,status,date_created,created_by,area,typenum,sap_id,remarks,reference_number,marks) VALUES (@conv_number,@inv_number,@code,@name,@category,@quantity,@type,@status,(SELECT GETDATE()),@created_by,@area,@typenum,@sap_id,@remarks,@reference,@marks)", con)
                        cmd.Parameters.AddWithValue("@conv_number", conv_number)
                        cmd.Parameters.AddWithValue("@inv_number", lblID.Text)
                        cmd.Parameters.AddWithValue("@code", dgvSelectedItem.Rows(index).Cells("itemcodee").Value)
                        cmd.Parameters.AddWithValue("@name", dgvSelectedItem.Rows(index).Cells("itemnamee").Value)
                        cmd.Parameters.AddWithValue("@category", dgvSelectedItem.Rows(index).Cells("categoryy").Value)
                        cmd.Parameters.AddWithValue("@quantity", dgvSelectedItem.Rows(index).Cells("quantityy").Value)
                        cmd.Parameters.AddWithValue("@type", tayp)
                        cmd.Parameters.AddWithValue("@status", "Open")
                        cmd.Parameters.AddWithValue("@created_by", login.neym)

                        cmd.Parameters.AddWithValue("@area", lcacc)
                        cmd.Parameters.AddWithValue("@typenum", "GI")

                        Dim sap As String = ""
                        If checkfollowup.Checked = True Then
                            sap = "To Follow"
                        Else
                            sap = txtsap.Text
                        End If

                        cmd.Parameters.AddWithValue("@sap_id", sap)
                        cmd.Parameters.AddWithValue("@remarks", txtremarks.Text)
                        cmd.Parameters.AddWithValue("@reference", conv_number)
                        cmd.Parameters.AddWithValue("@marks", "Rejects")
                        cmd.ExecuteNonQuery()
                        con.Close()

                        updateInventory("reject_convout", CDbl(dgvSelectedItem.Rows(index).Cells("quantityy").Value), dgvSelectedItem.Rows(index).Cells("itemnamee").Value)
                        z = "1"
                    Next
                    getConvNum()
                    MessageBox.Show("Transaction Completed", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    panelsap.Visible = False
                    loadItems()
                    If z <> "" Then
                        Dim xz As New conversions2()
                        'xz.mark = "Rejects"
                        xz.ShowDialog()
                    End If
                Case "transfer"
                    GetTransID()
                    Dim endbal As Double = 0.00, variance As Double = 0.00, so As String = "", actualendbal As Double = 0.00, totalav As Double = 0.00, totalquantity As Double = 0.00, rejectt As Double = 0.00

                    For index As Integer = 0 To dgvSelectedItem.RowCount - 1

                        totalquantity += CDbl(dgvSelectedItem.Rows(index).Cells("quantityy").Value)
                        con.Open()
                        cmd = New SqlCommand("SELECT reject,endbal,actualendbal,reject_totalav FROM tblinvitems WHERE itemname=@iname AND itemcode=@icode AND area=@iarea AND invnum=@iinvnum", con)
                        cmd.Parameters.AddWithValue("@iname", dgvSelectedItem.Rows(index).Cells("itemnamee").Value)
                        cmd.Parameters.AddWithValue("@icode", dgvSelectedItem.Rows(index).Cells("itemcodee").Value)
                        cmd.Parameters.AddWithValue("@iarea", lcacc)
                        cmd.Parameters.AddWithValue("@iinvnum", lblID.Text)
                        rdr = cmd.ExecuteReader
                        If rdr.Read Then
                            endbal = CDbl(rdr("endbal"))
                            actualendbal = CDbl(rdr("actualendbal"))
                            totalav = CDbl(rdr("reject_totalav"))
                            rejectt = CDbl(rdr("reject"))

                        End If
                        con.Close()
                        rejectt -= CDbl(dgvSelectedItem.Rows(index).Cells("quantityy").Value)
                        endbal -= CDbl(dgvSelectedItem.Rows(index).Cells("quantityy").Value)
                        totalav -= CDbl(dgvSelectedItem.Rows(index).Cells("quantityy").Value)
                        variance = actualendbal - endbal
                        If variance < 0 Then
                            so = "Short"
                        Else
                            so = "Over"
                        End If


                        con.Open()
                        cmd = New SqlCommand("UPDATE tblinvitems SET reject_transfer=@reject_transfer,reject=@r,reject_totalav=@reject_totalav, endbal=@endbal,variance=@variance WHERE itemname=@itemname AND itemcode=@itemcode AND area=@area AND invnum=@invnum;", con)
                        cmd.Parameters.AddWithValue("@reject_transfer", CDbl(dgvSelectedItem.Rows(index).Cells("quantityy").Value))
                        cmd.Parameters.AddWithValue("@r", rejectt)
                        cmd.Parameters.AddWithValue("@reject_totalav", totalav)
                        cmd.Parameters.AddWithValue("@endbal", endbal)
                        cmd.Parameters.AddWithValue("@variance", variance)

                        cmd.Parameters.AddWithValue("@itemname", dgvSelectedItem.Rows(index).Cells("itemnamee").Value)
                        cmd.Parameters.AddWithValue("@itemcode", dgvSelectedItem.Rows(index).Cells("itemcodee").Value)
                        cmd.Parameters.AddWithValue("@area", lcacc)
                        cmd.Parameters.AddWithValue("@invnum", lblID.Text)
                        cmd.ExecuteNonQuery()
                        con.Close()

                        Dim mahBranch As String = "", fromBranch As String = "", toBranch As String = ""
                        con.Open()
                        cmd = New SqlCommand("SELECT branchcode FROM tblbranch WHERE main='1';", con)
                        rdr = cmd.ExecuteReader
                        If rdr.Read Then
                            mahBranch = rdr("branchcode")
                        End If
                        con.Close()

                        toBranch = "PRD(" & mahBranch & ")"
                        fromBranch = "SLS(" & mahBranch & ")"

                        con.Open()
                        cmd = New SqlCommand("INSERT INTO tblproduction (transaction_number,inv_id,item_code,item_name,category,quantity,sap_number,remarks,date,processed_by,type,transfer_to,transfer_from,status,area,from_transnum,reject,charge,typenum,type2) VALUES (@trans_id,@id, @code,@name,@cat,@qty,@sap,@remarks,(SELECT GETDATE()),@processed_by,@type,@transfer_to,@transfer_from,@status,@area,@from_transnum,@reject,@charge,@typenum,@type2)", con)
                        cmd.Parameters.AddWithValue("@trans_id", transnum)
                        cmd.Parameters.AddWithValue("@id", lblID.Text)
                        cmd.Parameters.AddWithValue("@code", dgvSelectedItem.Rows(index).Cells("itemcodee").Value)
                        cmd.Parameters.AddWithValue("@name", dgvSelectedItem.Rows(index).Cells("itemnamee").Value)
                        cmd.Parameters.AddWithValue("@cat", dgvSelectedItem.Rows(index).Cells("categoryy").Value)
                        cmd.Parameters.AddWithValue("@qty", CDbl(dgvSelectedItem.Rows(index).Cells("quantityy").Value))

                        Dim sap_number As String = ""
                        If checkfollowup.Checked = True Then
                            sap_number = "To Follow"
                        Else
                            sap_number = txtsap.Text
                        End If

                        cmd.Parameters.AddWithValue("@sap", sap_number)
                        cmd.Parameters.AddWithValue("@remarks", txtremarks.Text)
                        cmd.Parameters.AddWithValue("@processed_by", login.username)
                        cmd.Parameters.AddWithValue("@type", "Transfer Item")
                        cmd.Parameters.AddWithValue("@transfer_to", fromBranch)
                        cmd.Parameters.AddWithValue("@transfer_from", toBranch)
                        cmd.Parameters.AddWithValue("@status", "Completed")
                        cmd.Parameters.AddWithValue("@area", lcacc)
                        cmd.Parameters.AddWithValue("@from_transnum", transnum)
                        cmd.Parameters.AddWithValue("@reject", "0")
                        cmd.Parameters.AddWithValue("@charge", "0")
                        cmd.Parameters.AddWithValue("@typenum", lblsapdoc.Text)
                        cmd.Parameters.AddWithValue("@type2", "Transfer")
                        cmd.ExecuteNonQuery()
                        con.Close()

                        'con.Open()
                        'cmd = New SqlCommand("INSERT INTO tblpendingitems (transnum,itemcode,itemname,category,quantity,good,charge) VALUES (@tnum,@itemcode,@itemname,@category,@qty,@good,@charge);", con)
                        'cmd.Parameters.AddWithValue("@tnum", transnum)
                        'cmd.Parameters.AddWithValue("@itemcode", dgvSelectedItem.Rows(index).Cells("itemcodee").Value)
                        'cmd.Parameters.AddWithValue("@itemname", dgvSelectedItem.Rows(index).Cells("itemnamee").Value)
                        'cmd.Parameters.AddWithValue("@category", dgvSelectedItem.Rows(index).Cells("categoryy").Value)
                        'cmd.Parameters.AddWithValue("@qty", dgvSelectedItem.Rows(index).Cells("quantityy").Value)
                        'cmd.Parameters.AddWithValue("@good", "0")
                        'cmd.Parameters.AddWithValue("@charge", "0")
                        'cmd.ExecuteNonQuery()
                        'con.Close()
                    Next
                    'con.Open()
                    'cmd = New SqlCommand("INSERT INTO tblpendingtrans (invnum,transnum,quantity,date,createdby,status) VALUES(@invnum,@transnum,@quantity,@date,@createdby,@status);", con)
                    'cmd.Parameters.AddWithValue("@invnum", lblID.Text)
                    'cmd.Parameters.AddWithValue("@transnum", transnum)
                    'cmd.Parameters.AddWithValue("@quantity", totalquantity)
                    'cmd.Parameters.AddWithValue("@date", DateTime.Now)
                    'cmd.Parameters.AddWithValue("@createdby", login.username)
                    'cmd.Parameters.AddWithValue("@status", "Pending")
                    'cmd.ExecuteNonQuery()
                    'con.Close()

                    MessageBox.Show("Transaction Completed", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    panelsap.Visible = False
                    loadItems()
            End Select
            dgvSelectedItem.Rows.Clear()
            'bawas na sa inventory susunod
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Public Sub GetTransID()
        Try
            Dim selectcount_result As Integer = 0
            Dim get_area As String = "", temp As String = "1"
            Dim area_format As String = ""
            con.Open()
            cmd = New SqlCommand("Select DISTINCT transaction_number  from tblproduction WHERE area='" & lcacc & "' AND type='Transfer Item' AND type2='Transfer';", con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                selectcount_result += 1
            End While
            con.Close()
            selectcount_result += 1

            Dim branchcode As String = ""
            con.Open()
            cmd = New SqlCommand("SELECT branchcode FROM tblbranch WHERE main='1';", con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                branchcode = rdr("branchcode")
            End While
            con.Close()

            area_format = "PRODTRA - " & branchcode & " - "

            If selectcount_result < 1000000 Then
                Dim cselectcount_result As String = CStr(selectcount_result)
                For vv As Integer = 1 To 6 - cselectcount_result.Length
                    temp += "0"
                Next
                transnum = area_format & temp & selectcount_result
            End If
        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information, "")
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub checkfollowup_CheckedChanged(sender As Object, e As EventArgs) Handles checkfollowup.CheckedChanged
        If checkfollowup.Checked Then
            txtsap.Enabled = False
            txtsap.Text = ""
        End If
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        panelsap.Visible = True
    End Sub
End Class