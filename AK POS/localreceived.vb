Imports System.Data.SqlClient
Imports System.Text
Imports System.IO
Public Class localreceived
    Dim strconn As String = login.ss
    Dim con As New SqlConnection(strconn)
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader

    Dim ar_number As String = "", trnum As String = ""
    Public lcacc As String = ""

    Public Function decryptConString() As String
        Dim base64encoded As String = File.ReadAllText("connectionstring.txt")
        Dim data As Byte() = System.Convert.FromBase64String(base64encoded)
        Return System.Text.ASCIIEncoding.ASCII.GetString(data)
    End Function

    Private Sub localreceived_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GetTransID()
    End Sub
    Public Sub loadPendingTrans()
        Try
            dgvpendings.Rows.Clear()
            con.Open()
            cmd = New SqlCommand("SELECT * FROM tblpendingtrans WHERE status='Pending';", con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                dgvpendings.Rows.Add(False, rdr("transnum"), rdr("quantity"), CDate(rdr("date")).ToString("MM/dd/yyyy hh:mm tt"))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
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
    Public Function removeVowels(ByVal workgrp As String) As String
        Dim result = New StringBuilder
        For Each c In workgrp
            If Not "aeiou".Contains(c.ToString.ToLower) Then
                result.Append(c)
            End If
        Next
        Return result.ToString
    End Function
    Public Sub getPOSID()
        Try
            Dim selectcount_result As Integer = 0
            Dim branchcode As String = "", temp As String = "1", area_format As String = ""
            con.Open()
            cmd = New SqlCommand("Select DISTINCT transnum  FROM tbltransaction WHERE area='" & "Sales" & "';", con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                selectcount_result += 1
            End While
            con.Close()
            selectcount_result += 1

            con.Open()
            cmd = New SqlCommand("Select branchcode FROM tblbranch WHERE main='1';", con)
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                branchcode = rdr("branchcode")
            End If
            con.Close()
            area_format = "TR - " & branchcode & " - "
            If selectcount_result < 1000000 Then
                Dim cselectcount_result As String = CStr(selectcount_result)
                For vv As Integer = 1 To 6 - cselectcount_result.Length
                    temp += "0"
                Next
                trnum = area_format & temp & selectcount_result
            End If
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
            Dim taypz As String = ""
            If lcacc = "Production" Then
                taypz = "Produce Item"
            Else
                taypz = "Received Item"
            End If

            cmd = New SqlCommand("Select DISTINCT transaction_number  from tblproduction WHERE area='" & lcacc & "' AND type='" & taypz & "' AND type2='Local';", con)
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
            If rdr.Read Then
                branchcode = rdr("branchcode")
            End If
            con.Close()

            If lcacc = "Sales" Then
                area_format = "RECPROD - " & branchcode & " - "
            End If

            If selectcount_result < 1000000 Then
                Dim cselectcount_result As String = CStr(selectcount_result)
                For vv As Integer = 1 To 6 - cselectcount_result.Length
                    temp += "0"
                Next
                lblTransactionID.Text = area_format & temp & selectcount_result
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
    Public Sub getARNum()
        Try
            Dim temp As String = "1", area_format As String = "", selectcount_result As Integer = 0
            con.Open()
            cmd = New SqlCommand("Select COUNT(*)  from tblars1 WHERE area='Sales' AND type='AR Charge';", con)
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

            area_format = "SALARCH - " & branchcode & " - "

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
    Private Sub localreceived_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        getID()
        GetTransID()
        loadPendingTrans()
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub dgvitems_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvitems.CellContentClick
        If e.ColumnIndex = 6 Then
            lblitemcode.Text = dgvitems.CurrentRow.Cells("itemcode").Value
            lblitemname.Text = dgvitems.CurrentRow.Cells("itemname").Value
            lblcategory.Text = dgvitems.CurrentRow.Cells("category").Value
            lblquantity.Text = dgvitems.CurrentRow.Cells("quantity").Value
            txtgood.Text = dgvitems.CurrentRow.Cells("good").Value
            txtcharge.Text = dgvitems.CurrentRow.Cells("charge").Value
            panelupdate.Visible = True
        End If
    End Sub

    Private Sub lblclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblclose.Click
        panelupdate.Visible = False
    End Sub

    Private Sub lblclosesap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblclosesap.Click
        panelsap.Visible = False
    End Sub

    Private Sub btnsubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsubmit.Click
        Dim errors_txt As String = "Please input good or charge in item: " & Environment.NewLine & Environment.NewLine & Environment.NewLine, errors_bool As Boolean = False
        For index As Integer = 0 To dgvitems.Rows.Count - 1
            If dgvitems.Rows(index).Cells("good").Value = 0 And dgvitems.Rows(index).Cells("charge").Value = 0 Then
                errors_txt += dgvitems.Rows(index).Cells("itemname").Value & Environment.NewLine
                errors_bool = True
            End If
        Next
        If errors_bool Then
            MessageBox.Show(errors_txt, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf dgvpendings.Rows.Count = 0 Or dgvitems.Rows.Count = 0 Then
            MessageBox.Show("No transaction number selected", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            con.Open()
            cmd = New SqlCommand("SELECT sap_number FROM tblproduction WHERE transaction_number=@tnum AND type='Transfer Item';", con)
            cmd.Parameters.AddWithValue("@tnum", dgvpendings.CurrentRow.Cells("transnum").Value)
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                txtsapno.Text = rdr("sap_number")
            End If
            con.Close()
            panelsap.Visible = True
        End If
    End Sub

    Private Sub dgvpendings_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvpendings.SelectionChanged

    End Sub

    Private Sub dgvpendings_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvpendings.CellContentClick
        Try
            dgvitems.Rows.Clear()
            con.Open()
            cmd = New SqlCommand("SELECT itemcode,itemname,category,quantity,good,charge FROM tblpendingitems WHERE transnum=@trnum", con)
            cmd.Parameters.AddWithValue("@trnum", dgvpendings.CurrentRow.Cells("transnum").Value)
            rdr = cmd.ExecuteReader
            While rdr.Read
                dgvitems.Rows.Add(rdr("itemcode"), rdr("itemname"), rdr("category"), rdr("quantity"), rdr("good"), rdr("charge"))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub txtgood_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtgood.KeyPress, txtcharge.KeyPress
        If Not Char.IsControl(e.KeyChar) And Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnok.Click
        Dim result As Double = CDbl(txtgood.Text) + CDbl(txtcharge.Text)
        If String.IsNullOrEmpty(Trim(txtgood.Text) And String.IsNullOrEmpty(Trim(txtcharge.Text))) Then
            MessageBox.Show("Please input good and charge", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf String.IsNullOrEmpty(Trim(txtgood.Text)) Then
            MessageBox.Show("Please input good", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf String.IsNullOrEmpty(Trim(txtcharge.Text)) Then
            MessageBox.Show("Please input charge", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf result > CDbl(lblquantity.Text) Or result < CDbl(lblquantity.Text) Then
            MessageBox.Show("Good + Charge should be equal to Quantity", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            For index As Integer = 0 To dgvitems.Rows.Count - 1
                If dgvitems.Rows(index).Cells("itemcode").Value = lblitemcode.Text And dgvitems.Rows(index).Cells("itemname").Value = lblitemname.Text And dgvitems.Rows(index).Cells("category").Value = lblcategory.Text Then

                    con.Open()
                    cmd = New SqlCommand("UPDATE tblpendingitems SET good=@good, charge=@charge WHERE transnum=@trnum AND itemname=@itemname AND itemcode=@itemcode AND category=@category;", con)
                    cmd.Parameters.AddWithValue("@good", CDbl(txtgood.Text))
                    cmd.Parameters.AddWithValue("@charge", CDbl(txtcharge.Text))
                    cmd.Parameters.AddWithValue("@trnum", dgvpendings.CurrentRow.Cells("transnum").Value)
                    cmd.Parameters.AddWithValue("@itemname", lblitemname.Text)
                    cmd.Parameters.AddWithValue("@itemcode", lblitemcode.Text)
                    cmd.Parameters.AddWithValue("@category", lblcategory.Text)
                    cmd.ExecuteNonQuery()
                    con.Close()
                    dgvitems.Rows(index).Cells("good").Value = txtgood.Text
                    dgvitems.Rows(index).Cells("charge").Value = txtcharge.Text
                End If
            Next
            panelupdate.Visible = False
            lblitemcode.Text = "N/A"
            lblitemname.Text = "N/A"
            lblcategory.Text = "N/A"
            lblquantity.Text = "N/A"
            txtgood.Text = ""
            txtcharge.Text = ""
        End If
    End Sub
    Public Function checkCutOff() As Boolean
        Try
            Dim status As String = "", date_from As New DateTime()
            con.Open()
            cmd = New SqlCommand("SELECT status,date FROM tblcutoff WHERE userid=(SELECT systemid FROM tblusers WHERE username=@username) ORDER BY cid DESC;", con)
            cmd.Parameters.AddWithValue("@username", login.username)
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                status = rdr("status")
                date_from = CDate(rdr("date"))
            End If
            con.Close()
            If status = "In Active" And date_from.ToString("MM/dd/yyyy") = getSystemDate.ToString("MM/dd/yyyy") Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Function
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
    Private Sub btnproceed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnproceed.Click

        If checkCutOff() Then
            MessageBox.Show("Your account is already cut off", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If String.IsNullOrEmpty(Trim(txtsapno.Text)) And String.IsNullOrEmpty(Trim(txtremarks.Text)) Then
            MessageBox.Show("Please fill up Sap # and Remarks", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf String.IsNullOrEmpty(Trim(txtsapno.Text)) And checkfollowup.Checked = False Then
            MessageBox.Show("Please fill up Sap #", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf String.IsNullOrEmpty(Trim(txtremarks.Text)) Then
            MessageBox.Show("Please fill up Remarks", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else

            Dim mahBranch As String = ""
            con.Open()
            cmd = New SqlCommand("SELECT branchcode FROM tblbranch WHERE main='1';", con)
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                mahBranch = rdr("branchcode")
            End If
            con.Close()

            For Each r0w As DataGridViewRow In dgvitems.Rows
                Dim lastin As Double, lasttotal As Double, lastpull As Double, lastout As Double, lastend As Double, lastactual As Double, good As Double = 0.0, charge As Double = 0.0, ars As Double = 0.0
                con.Open()
                cmd = New SqlCommand("Select itemin,begbal,ctrout,pullout,actualendbal,endbal,convout,convin,transfer,produce,productionin,arsales,archarge,charge,reject,good,arreject,supin,adjustmentin from tblinvitems where itemcode='" & dgvitems.Rows(r0w.Index).Cells("itemcode").Value & "' and invnum='" & lblID.Text & "' AND area='" & lcacc & "'", con)
                rdr = cmd.ExecuteReader()
                If rdr.Read() Then
                    lastin = rdr("itemin")
                    lasttotal = rdr("begbal") + rdr("itemin") + rdr("productionin") + rdr("convin") + rdr("charge") + rdr("reject") + rdr("supin") + rdr("adjustmentin")
                    lastout = rdr("ctrout") + rdr("pullout") + rdr("convout") + rdr("transfer") + rdr("arsales") + rdr("archarge") + rdr("arreject")
                    lastactual = rdr("actualendbal")
                    lastpull = rdr("pullout")
                    lastend = rdr("endbal")
                    charge = rdr("charge")
                    good = rdr("good")
                    ars = rdr("archarge")
                End If
                con.Close()
                Dim uin As Double = Val(dgvitems.Rows(r0w.Index).Cells("good").Value) + lastin
                Dim utotal As Double = lasttotal + Val(dgvitems.Rows(r0w.Index).Cells("good").Value) + Val(dgvitems.Rows(r0w.Index).Cells("charge").Value)
                ars += CDbl(dgvitems.Rows(r0w.Index).Cells("charge").Value)
                Dim uend As Double = utotal - lastout - Val(dgvitems.Rows(r0w.Index).Cells("charge").Value)
                Dim uvar As Double = lastactual - uend
                good += Val(dgvitems.Rows(r0w.Index).Cells("good").Value)
                charge += Val(dgvitems.Rows(r0w.Index).Cells("charge").Value)
                Dim urems As String = ""
                If uvar < 0 Then
                    urems = "Short"
                ElseIf uvar > 0 Then
                    urems = "Over"
                End If

                con.Open()
                cmd = New SqlCommand("Update tblinvitems set productionin='" & uin & "',charge='" & charge & "',archarge='" & ars & "', totalav='" & utotal & "', endbal='" & uend & "', variance='" & uvar & "', shortover='" & urems & "' where itemcode='" & dgvitems.Rows(r0w.Index).Cells("itemcode").Value & "' and invnum='" & lblID.Text & "' AND area='" & lcacc & "'", con)
                cmd.ExecuteNonQuery()
                con.Close()

                con.Open()
                cmd = New SqlCommand("Update tblitems set status='1' where itemcode='" & dgvitems.Rows(r0w.Index).Cells("itemcode").Value & "'", con)
                cmd.ExecuteNonQuery()
                con.Close()

                Dim query As String = "INSERT INTO tblproduction (transaction_number,inv_id,item_code,item_name,category,quantity,reject,charge,sap_number,remarks,date,processed_by,type,area,status,transfer_from,transfer_to,from_transnum,typenum,type2) VALUES (@trans_id,@id, @code,@name,@cat,@qty,@reject,@charge,@sap,@remarks,(SELECT GETDATE()),@processed_by,@type,@area,@status,@from,@to,@from_transnum,@typenum,@type2)"

                con.Open()
                cmd = New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@trans_id", lblTransactionID.Text)
                cmd.Parameters.AddWithValue("@id", lblID.Text)
                cmd.Parameters.AddWithValue("@code", dgvitems.Rows(r0w.Index).Cells("itemcode").Value)
                cmd.Parameters.AddWithValue("@name", dgvitems.Rows(r0w.Index).Cells("itemname").Value)
                cmd.Parameters.AddWithValue("@cat", dgvitems.Rows(r0w.Index).Cells("category").Value)
                cmd.Parameters.AddWithValue("@qty", dgvitems.Rows(r0w.Index).Cells("quantity").Value)
                cmd.Parameters.AddWithValue("@reject", "0")
                cmd.Parameters.AddWithValue("@charge", dgvitems.Rows(r0w.Index).Cells("charge").Value)
                cmd.Parameters.AddWithValue("@type2", "Received From Production")

                Dim sap As String = ""
                If checkfollowup.Checked = True Then
                    sap = "To Follow"
                Else
                    sap = txtsapno.Text
                End If

                cmd.Parameters.AddWithValue("@sap", sap)
                cmd.Parameters.AddWithValue("@remarks", txtremarks.Text)
                cmd.Parameters.AddWithValue("@processed_by", login.neym)
                cmd.Parameters.AddWithValue("@type", "Received Item")
                cmd.Parameters.AddWithValue("@area", lcacc)
                cmd.Parameters.AddWithValue("@status", "Completed")
                cmd.Parameters.AddWithValue("@from", mahBranch & "(PRD)")
                cmd.Parameters.AddWithValue("@to", mahBranch & "(SLS)")
                cmd.Parameters.AddWithValue("@from_transnum", dgvpendings.CurrentRow.Cells("transnum").Value)
                cmd.Parameters.AddWithValue("@typenum", lbltype.Text)
                cmd.ExecuteNonQuery()
                con.Close()
            Next

            getARNum()

            Dim amount As Double = 0.0
            con.Open()
            cmd = New SqlCommand("SELECT ISNULL(SUM(tblitems.price * tblpendingitems.charge),0) FROM tblpendingitems JOIN tblitems ON tblpendingitems.itemname=tblitems.itemname AND tblpendingitems.itemcode = tblitems.itemcode AND tblpendingitems.category = tblitems.category WHERE transnum=@tttnum", con)
            cmd.Parameters.AddWithValue("@tttnum", dgvpendings.CurrentRow.Cells("transnum").Value)
            amount = cmd.ExecuteScalar()
            con.Close()
            If amount <> 0 Then
                getPOSID()
                con.Open()
                cmd = New SqlCommand("INSERT INTO tblars1 (arnum,transnum,amountdue,name,status,date_created,created_by,area,invnum,type,typenum,sap_no,remarks,_from) VALUES (@arnum,@transnum, @amountdue, @name, @status,(SELECT GETDATE()), @createdby,@area,@invnum,@tayp,@typenum,@sap_no,@remarks,@_from)", con)
                cmd.Parameters.AddWithValue("@arnum", ar_number)
                cmd.Parameters.AddWithValue("@transnum", ar_number)
                cmd.Parameters.AddWithValue("@amountdue", amount)
                cmd.Parameters.AddWithValue("@name", mahBranch & "(PRD)")
                cmd.Parameters.AddWithValue("@status", "Unpaid")
                cmd.Parameters.AddWithValue("@createdby", login.username)
                cmd.Parameters.AddWithValue("@area", "Sales")
                cmd.Parameters.AddWithValue("@invnum", lblID.Text)
                cmd.Parameters.AddWithValue("@tayp", "AR Charge")

                cmd.Parameters.AddWithValue("@typenum", "AR")
                cmd.Parameters.AddWithValue("@sap_no", "To Follow")
                cmd.Parameters.AddWithValue("@remarks", "")
                cmd.Parameters.AddWithValue("@_from", Me.Text)
                cmd.ExecuteNonQuery()
                con.Close()

                Dim zz As String = getSystemDate.ToString("MM/dd/yyyy")

                con.Open()
                cmd = New SqlCommand("Insert into tbltransaction (ornum, transnum, transdate, cashier, tendertype, servicetype, delcharge, subtotal, disctype, less, vatsales, vat, amtdue, gctotal, tenderamt, change, refund, comment, remarks, customer, tinnum, tablenum, pax, datecreated, datemodified, status,area,invnum,partialamt) values ('0', '" & trnum & "', '" & zz & "','" & login.cashier & "','A.R Charge','N/A','0', '" & amount & "', 'N/A', '0', '0', '0', '" & amount & "', '0', '0', '0', '0', '', '','" & mahBranch & "(SLS)" & "' , 'N/A', '0','1',(SELECT GETDATE()),(SELECT GETDATE()), '1','" & "Sales" & "','" & lblID.Text & "','0')", con)
                cmd.ExecuteNonQuery()
                con.Close()

            End If

            For index As Integer = 0 To dgvitems.Rows.Count - 1
                If dgvitems.Rows(index).Cells("charge").Value <> 0 Then
                    Dim price As Double = 0.0
                    con.Open()
                    cmd = New SqlCommand("SELECT price FROM tblitems WHERE itemname=@itemname AND itemcode=@itemcode AND category=@category;", con)
                    cmd.Parameters.AddWithValue("@itemname", dgvitems.Rows(index).Cells("itemname").Value)
                    cmd.Parameters.AddWithValue("@itemcode", dgvitems.Rows(index).Cells("itemcode").Value)
                    cmd.Parameters.AddWithValue("@category", dgvitems.Rows(index).Cells("category").Value)
                    rdr = cmd.ExecuteReader
                    If rdr.Read Then
                        price = rdr("price")
                    End If
                    con.Close()

                    Dim totalprice As Double = price * CInt(dgvitems.Rows(index).Cells("charge").Value)

                    con.Open()
                    cmd = New SqlCommand("INSERT INTO tblars2 (transnum,description,quantity,price,amount,area,name) VALUES (@tnum, @des,@qua,@price,@am,@area,@name)", con)
                    cmd.Parameters.AddWithValue("@tnum", ar_number)
                    cmd.Parameters.AddWithValue("@des", dgvitems.Rows(index).Cells("itemname").Value)
                    cmd.Parameters.AddWithValue("@qua", dgvitems.Rows(index).Cells("charge").Value)
                    cmd.Parameters.AddWithValue("@price", price)
                    cmd.Parameters.AddWithValue("@am", totalprice)
                    cmd.Parameters.AddWithValue("@area", "Sales")
                    cmd.Parameters.AddWithValue("@name", mahBranch & "(PRD)")
                    cmd.ExecuteNonQuery()
                    con.Close()

                    con.Open()
                    cmd = New SqlCommand("Insert into tblorder (transnum, category, itemname, qty, price, totalprice, dscnt, free, request, status, discprice, disctrans,area,invnum,type)values('" & trnum & "','" & dgvitems.Rows(index).Cells("category").Value & "','" & dgvitems.Rows(index).Cells("itemname").Value & "','" & dgvitems.Rows(index).Cells("charge").Value & "','" & price & "','" & totalprice & "','0','0','0','1','0','0','" & "Sales" & "','" & lblID.Text & "','" & "A.R Charge" & "')", con)
                    cmd.ExecuteNonQuery()
                    con.Close()
                End If
            Next

            con.Open()
            cmd = New SqlCommand("UPDATE tblpendingtrans SET status='Completed' WHERE transnum=@tnum", con)
            cmd.Parameters.AddWithValue("@tnum", dgvpendings.CurrentRow.Cells("transnum").Value)
            cmd.ExecuteNonQuery()
            con.Close()

            dgvitems.Rows.Clear()
            loadPendingTrans()
            GetTransID()
            MessageBox.Show("Transaction Completed", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            panelsap.Visible = False
            txtsapno.Text = ""
            txtremarks.Text = ""

        End If
    End Sub

    Private Sub localreceived_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Dim a As String = MsgBox("Are you sure you want to close Received Item Form?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "")
        If a = vbYes Then
            Me.Dispose()
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub checkfollowup_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles checkfollowup.CheckedChanged
        If checkfollowup.Checked Then
            txtsapno.Text = ""
            txtsapno.Enabled = False
        Else
            txtsapno.Enabled = True
        End If
    End Sub

    Private Sub txtsapno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtsapno.KeyPress
        If Not Char.IsControl(e.KeyChar) And Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnsearchitems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsearchitems.Click

    End Sub

    Private Sub btnsearchpendings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsearchpendings.Click

    End Sub
End Class