Imports System.Data.SqlClient
Imports System.IO
Imports AK_POS.connection_class
Public Class cashier
    Dim cc As New connection_class
    Dim con As New SqlConnection(cc.conString)
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader

    Dim invid As String = ""
    Dim area As String = ""
    Dim adpay As Integer = 0
    Dim servicetypeName As String = ""
    Dim servicetypeVal As Boolean = False
    Dim rowcountnames As Integer = 0, ap_result As Double = 0.0
    Dim type_holder As String = ""
    Public Function decryptConString() As String
        Dim base64encoded As String = File.ReadAllText("connectionstring.txt")
        Dim data As Byte() = System.Convert.FromBase64String(base64encoded)
        Return System.Text.ASCIIEncoding.ASCII.GetString(data)
    End Function

    Private Sub checkboxvoidorders_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles checkboxvoidorders.CheckedChanged
        If checkboxvoidorders.Checked Then
            dgvorders.Columns("selectt").Visible = True
            btnvoidsubmit.Visible = True
        Else
            dgvorders.Columns("selectt").Visible = False
            btnvoidsubmit.Visible = False
        End If
    End Sub
    Public Sub submit(ByVal a As String)
        If lblordernum.Text = "N/A" Then
            MessageBox.Show("Select order first", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            yowCheck()
        End If
    End Sub

    Public Function checkTrans() As Boolean
        Try
            Dim z As Boolean = False
            con.Open()
            cmd = New SqlCommand("SELECT orderid FROM tbltransaction2 WHERE ordernum=@ornum AND status2='Paid';", con)
            cmd.Parameters.AddWithValue("@ornum", lblordernum.Text)
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                z = True
            End If
            con.Close()
            Return z
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Function

    Public Sub yowCheck()
        Try
            If Not String.IsNullOrEmpty(isDeposit()) Then
                Dim zxc As String = isDeposit()
                If "d" = zxc.Substring(zxc.Length - 1) Then
                    MessageBox.Show(isDeposit(), "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    ap_result = isDeposit()
                    owshitt()
                End If
            Else
                MessageBox.Show("qwe")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Public Sub owshitt()
        Dim main As New mainmenu()
        For row As Integer = 0 To dgvitems.Rows.Count - 1
            con.Open()
            cmd = New SqlCommand("SELECT * FROM tblitems WHERE itemname=@itemname", con)
            cmd.Parameters.AddWithValue("@itemname", dgvitems.Rows(row).Cells("description").Value)
            rdr = cmd.ExecuteReader()
            While rdr.Read

                Dim free As Boolean = False
                If CBool(dgvitems.Rows(row).Cells("free").Value) = True Then
                    free = True
                Else
                    free = False
                End If
                main.grd.Rows.Add(dgvitems.Rows(row).Cells("description").Value, CDbl(dgvitems.Rows(row).Cells("quantity").Value).ToString("n2"), CDbl(dgvitems.Rows(row).Cells("price").Value).ToString("n2"), CDbl(dgvitems.Rows(row).Cells("discountpercent").Value).ToString("n2"), CDbl(dgvitems.Rows(row).Cells("amount").Value).ToString("n2"), dgvitems.Rows(row).Cells("request").Value, free, rdr("itemcode"), rdr("category"), dgvitems.Rows(row).Cells("pricebefore").Value, dgvitems.Rows(row).Cells("discamt").Value)

            End While
            con.Close()
        Next
        main.ornum = lblordernum.Text
        main.cas = "Cashier"
        main.lblordernumber.Text = lblordernum.Text
        main.order_id = dgvorders.CurrentRow.Cells("orderid").Value
        con.Open()
        cmd = New SqlCommand("SELECT servicetype,tendertype,delcharge,customer,tenderamt,subtotal,disctype,less,delcharge,gctotal FROM tbltransaction2 WHERE orderid='" & dgvorders.CurrentRow.Cells("orderid").Value & "';", con)
        rdr = cmd.ExecuteReader()
        If rdr.Read Then
            'MessageBox.Show(rdr("servicetype") & Environment.NewLine & rdr("tendertype"))
            If rdr("servicetype") = "Take out" Then
                main.rbtake.Checked = True
            ElseIf rdr("servicetype") = "Dine in" Then
                main.rbdine.Checked = True
            End If
            If rdr("tendertype") = "Cash" Then
                main.rbcash.Checked = True
                main.txtname.Text = rdr("customer")
            ElseIf rdr("tendertype") = "A.R Sales" Then
                main.rbAR.Checked = True
                main.txtname.Text = rdr("customer")
            ElseIf rdr("tendertype") = "A.R Charge" Then
                main.rbARCharge.Checked = True
                main.txtname.Text = rdr("customer")
            End If
            main.txttendered.Text = CDbl(rdr("tenderamt")).ToString("n2")
            main.cSub = rdr("subtotal")
            main.cDisType = rdr("disctype")
            main.cLess = rdr("less")
            main.cDelCharge = rdr("delcharge")
            main.cGc = rdr("gctotal")
        End If
        con.Close()
        main.amt = txtresult.Text
        main.apdepamt = ap_result
        main.sales_ans = type_holder
        main.ShowDialog()
        load_orders()
        dgvitems.Rows.Clear()
        txtresult.Text = ""
        chckboxadvancepayment.Checked = False
        loadAdvanceNames()


    End Sub
    Public Function isDeposit() As String
        Dim z As Integer = 0, current_amt As Double = 0.0

        Dim wordz() As String = txtresult.Text.Split(New Char() {","c})
        Dim wordd As String = "", apamt As Double = 0.00
        For Each wordd In wordz
            If Not String.IsNullOrEmpty(wordd) Then
                con.Open()
                cmd = New SqlCommand("SELECT amount FROM tbladvancepayment WHERE apnum=@apnum AND type='Deposit' AND status='Active';", con)
                cmd.Parameters.AddWithValue("@apnum", wordd)
                rdr = cmd.ExecuteReader
                While rdr.Read
                    apamt += CDbl(rdr("amount"))
                End While
                con.Close()
            End If
        Next
        For index As Integer = 0 To dgvitems.RowCount - 1
            con.Open()
            cmd = New SqlCommand("SELECT price FROM tbldepositprice WHERE itemid=(SELECT itemid FROM tblitems WHERE itemname=@itemname) AND status=1;", con)
            cmd.Parameters.AddWithValue("@itemname", CStr(dgvitems.Rows(index).Cells("description").Value))
            rdr = cmd.ExecuteReader
            While rdr.Read
                z += 1
                current_amt += CDbl(dgvitems.Rows(index).Cells("quantity").Value) * CDbl(rdr("price"))
            End While
            con.Close()
        Next
        If z <> 0 And String.IsNullOrEmpty(txtresult.Text) Then
            Return "This transaction have deposit item, add deposit to proceed"
        ElseIf z <> 0 And Not String.IsNullOrEmpty(txtresult.Text) Then
            Dim words() As String = txtresult.Text.Split(New Char() {","c})
            Dim word As String, countDeposits As Integer = 0, totalamt As Double = 0.00
            For Each word In words
                If Not String.IsNullOrEmpty(word) Then
                    con.Open()
                    cmd = New SqlCommand("SELECT amount FROM tbladvancepayment WHERE apnum=@apnum AND type='Deposit' AND status='Active';", con)
                    cmd.Parameters.AddWithValue("@apnum", word)
                    rdr = cmd.ExecuteReader
                    While rdr.Read
                        countDeposits += 1
                        totalamt += CDbl(rdr("amount"))
                    End While
                    con.Close()

                End If
            Next
            If countDeposits = 0 Then
                Return "This transaction have deposit item, add deposit to proceed"
            End If
            If current_amt > totalamt Then
                Return "Deposit amount is not enough, add more to proceed"
            Else
                Return apamt
            End If
        Else
            Return apamt
        End If
    End Function
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
            If status = "In Active" And date_from.ToString("MM/dd/yyyy") = DateTime.Now.ToString("MM/dd/yyyy") Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Function
    Private Sub btncheckout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncheckout.Click
        If checkCutOff() Then
            MessageBox.Show("Your account is already cut off", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else

            If lblordernum.Text = "N/A" Then
                MessageBox.Show("Select order number first", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim status As String = ""
            con.Open()
            cmd = New SqlCommand("SELECT status2 FROM tbltransaction2 WHERE ordernum=@ordernum AND CAST(datecreated AS date)='" & DateTime.Now.ToString("MM/dd/yyyy") & "';", con)
            cmd.Parameters.AddWithValue("@ordernum", lblordernum.Text)
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                status = rdr("status2")
            End If
            con.Close()

            If status = "Paid" Then
                MessageBox.Show("This transaction is already paid", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            ElseIf status = "Void" Then
                MessageBox.Show("This transaction is already void", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            submit("Confirm")
        End If
    End Sub
    Public Sub load_orders()
        Try
            dgvorders.Rows.Clear()
            dgvorders.Columns("amountdue").DefaultCellStyle.Format = "n2"
            cmd.Parameters.Clear()
            con.Open()
            cmd = New SqlCommand("SELECT ordernum,amtdue,servicetype,tendertype,createdby,typez,datecreated,orderid FROM funcLoadOrders(@isales,@itypee,@iservicetype,@area,@sales,@typee,@tendertype)", con)
            cmd.Parameters.AddWithValue("@isales", cmbsales.SelectedIndex)
            cmd.Parameters.AddWithValue("@itypee", cmbtypee.SelectedIndex)
            cmd.Parameters.AddWithValue("@iservicetype", cmbservicetype.SelectedIndex)
            cmd.Parameters.AddWithValue("@area", "Sales")
            cmd.Parameters.AddWithValue("@sales", cmbsales.Text)
            cmd.Parameters.AddWithValue("@typee", cmbtypee.Text)
            cmd.Parameters.AddWithValue("@tendertype", cmbservicetype.Text)
            rdr = cmd.ExecuteReader()
            While rdr.Read
                dgvorders.Rows.Add("", rdr("ordernum"), rdr("amtdue"), rdr("servicetype"), rdr("tendertype"), rdr("createdby"), rdr("typez"), rdr("datecreated"), rdr("orderid"))
            End While
            con.Close()
            Dim amt As Double = 0.00
            For index As Integer = 0 To dgvorders.RowCount - 1
                amt += CDbl(dgvorders.Rows(index).Cells("amountdue").Value)
            Next
            lbltotalamt.Text = "Pending Total Amt. Due:   " & amt.ToString("n2")
            dgvitems.Rows.Clear()
            lblservicetype.Text = "N/A"
            lblordernum.Text = "N/A"
            lbldelcharge.Text = "0.00"
            lblsubtotal.Text = "0.00"
            lbldiscountype.Text = "None"
            lblless.Text = "0.00"
            lblgc.Text = "0.00"
            lblvatsales.Text = "0.00"
            lblvatamount.Text = "0.00"
            lbltenderamt.Text = "0.00"
            lblchange.Text = "0.00"
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub
    Public Sub getID()
        Try
            Dim id As String = ""
            Dim date_ As New DateTime()
            con.Open()
            cmd = New SqlCommand("Select TOP 1 invnum,datecreated from tblinvsum  WHERE area='" & "Sales" & "' order by invsumid DESC", con)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                id = rdr("invnum")
                date_ = CDate(rdr("datecreated"))
            End If
            con.Close()
            If date_.ToString("MM/dd/yyyy") = DateTime.Now.ToString("MM/dd/yyyy") Then
                invid = id
            Else
                invid = "N/A"
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Public Sub loadAdvanceNames()
        Try
            txtname.Text = ""
            txtamount.Text = ""
            Dim auto As New AutoCompleteStringCollection()
            con.Open()
            cmd = New SqlCommand("SELECT apnum FROM tbladvancepayment WHERE status='Active' AND type=@type", con)
            cmd.Parameters.AddWithValue("@type", cmbtype.Text)
            rdr = cmd.ExecuteReader()
            While rdr.Read
                auto.Add(rdr("apnum"))
            End While
            con.Close()
            txtname.AutoCompleteCustomSource = auto
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Public Sub loadSalesAgent()
        Try
            cmbsales.Items.Clear()
            cmbsales.Items.Add("All")
            con.Open()
            cmd = New SqlCommand("SELECT username FROM tblusers WHERE  workgroup IN ('Sales','Manager');", con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                cmbsales.Items.Add(rdr("username"))
            End While
            con.Close()
            cmbsales.SelectedIndex = 0
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub dgvorders_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvorders.DataError
        'e.Cancel = True
    End Sub
    Public Sub loadItems()
        dgvitems.Rows.Clear()
        lblordernum.Text = dgvorders.CurrentRow.Cells("ordernum").Value
        lblservicetype.Text = dgvorders.CurrentRow.Cells("servicetype").Value
        type_holder = dgvorders.CurrentRow.Cells("typee").Value
        con.Open()
        cmd = New SqlCommand("SELECT itemname,qty,price,dscnt,totalprice,request,free,pricebefore,discamt FROM funcLoadOrderItems(@ordernum,@datee)", con)
        cmd.Parameters.AddWithValue("@ordernum", lblordernum.Text)
        cmd.Parameters.AddWithValue("@datee", dgvorders.CurrentRow.Cells("datecreated").Value)
        rdr = cmd.ExecuteReader()
        While rdr.Read
            Dim f As Boolean = False
            dgvitems.Columns("quantity").DefaultCellStyle.Format = "n2"
            dgvitems.Columns("price").DefaultCellStyle.Format = "n2"
            dgvitems.Columns("discountpercent").DefaultCellStyle.Format = "n2"
            dgvitems.Columns("amount").DefaultCellStyle.Format = "n2"
            If CDbl(rdr("free")) <> 0 Then
                f = True
            End If
            dgvitems.Rows.Add(rdr("itemname"), rdr("qty"), rdr("price"), rdr("dscnt"), rdr("totalprice"), rdr("request"), f, rdr("pricebefore"), rdr("discamt"))
        End While
        con.Close()

        con.Open()
        cmd = New SqlCommand("SELECT remarks,subtotal,disctype,less,delcharge,vatsales,vat,amtdue,tenderamt,change,gctotal FROM tbltransaction2 WHERE ordernum=@num AND CAST(tbltransaction2.datecreated AS date)='" & dgvorders.CurrentRow.Cells("datecreated").Value & "';", con)
        cmd.Parameters.AddWithValue("@num", lblordernum.Text)
        rdr = cmd.ExecuteReader()
        While rdr.Read
            txtboxremarks.Text = rdr("remarks")
            lblsubtotal.Text = CDbl(rdr("subtotal")).ToString("n2")
            'lbldiscountype.Text = rdr("disctype")
            'If lbldiscountype.Text = "" Then
            '    lbldiscountype.Text = "N/A"
            'End If
            lbldiscountype.Text = IIf(rdr("disctype") = "", "N/A", rdr("disctype"))
            lblless.Text = CInt(rdr("less")).ToString("n2")
            lbldelcharge.Text = CDbl(rdr("delcharge")).ToString("n2")
            lblvatsales.Text = CDbl(rdr("vatsales")).ToString("n2")
            lblvatamount.Text = CDbl(rdr("vat")).ToString("n2")
            lblgc.Text = CDbl(rdr("gctotal")).ToString("n2")
            lbltotal.Text = CDbl(rdr("amtdue")).ToString("n2")
            lbltenderamt.Text = CDbl(rdr("tenderamt")).ToString("n2")
            lblchange.Text = CDbl(rdr("change")).ToString("n2")
        End While
        con.Close()
    End Sub
    Private Sub dgvorders_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvorders.CellContentClick, dgvorders.CellClick
        If dgvorders.RowCount <> 0 Then
            loadItems()
        End If
    End Sub

    Private Sub btnvoidsubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnvoidsubmit.Click
        txtremarks.Focus()
        panelreasons.Visible = True
    End Sub
    Public Sub clear_all()
        dgvitems.Rows.Clear()
        lblordernum.Text = "N/A"
        lblservicetype.Text = "N/A"
        txtboxremarks.Text = ""
        lblsubtotal.Text = "0.00"
        lbldiscountype.Text = "N/A"
        lbldelcharge.Text = "0.00"
        lblvatamount.Text = "0.00"
        lblvatsales.Text = "0.00"
        lbltotal.Text = "0.00"
        lbltenderamt.Text = "0.00"
        lblchange.Text = "0.00"
    End Sub


    Private Sub chckboxadvancepayment_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chckboxadvancepayment.CheckedChanged
        If chckboxadvancepayment.Checked Then
            If lblordernum.Text = "N/A" Then
                MessageBox.Show("Select Order Number first", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                chckboxadvancepayment.Checked = False
                Exit Sub
            Else

                GroupBox1.Visible = True
                chckboxadvancepayment.ForeColor = Color.Green
            End If
        Else
            GroupBox1.Visible = False
            chckboxadvancepayment.ForeColor = Color.Red
            txtname.Text = ""
            txtamount.Text = "0.00"
            adpay = 0
        End If
    End Sub

    Private Sub btncheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncheck.Click
        Try
            Dim status As String = "", isTrue As Boolean = False
            con.Open()
            cmd = New SqlCommand("SELECT apnum,amount FROM tbladvancepayment WHERE apnum=@apnum AND amount=@amount AND status='Active' AND type=@type", con)
            cmd.Parameters.AddWithValue("@apnum", txtname.Text)
            cmd.Parameters.AddWithValue("@amount", CDbl(txtamount.Text))
            cmd.Parameters.AddWithValue("@type", cmbtype.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                isTrue = True
            End If
            con.Close()
            If isTrue Then
                MessageBox.Show("Account Found", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Account not found or already used", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub txtamount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtamount.TextChanged
        Try
            Dim d As Double = CDbl(txtamount.Text)
            txtamount.Text = d.ToString("n2")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtname.TextChanged
        Try
            Dim am As Double = 0.0, ad As Integer = 0
            con.Open()
            cmd = New SqlCommand("SELECT ap_id,amount FROM tbladvancepayment WHERE apnum=@name AND status='Active' AND type=@type", con)
            cmd.Parameters.AddWithValue("@name", txtname.Text)
            cmd.Parameters.AddWithValue("@type", cmbtype.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                am = CDbl(rdr("amount"))
                ad = CInt(rdr("ap_id"))
            End If
            con.Close()
            txtamount.Text = am
            adpay = ad
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

    Private Sub btnrefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrefresh.Click
        txtname.Text = ""
        txtamount.Text = "0.00"
        loadAdvanceNames()
    End Sub
    Private Sub cashier_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        If login.wrkgrp = "Cashier" Or login.wrkgrp = "Manager" Then
            area = "Sales"
        Else
            area = login.wrkgrp
        End If
        getID()
        loadAdvanceNames()
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub cmbtype_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbtype.SelectedIndexChanged
        loadAdvanceNames()
    End Sub

    Private Sub Panel2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub btnhide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhide.Click
        panelreasons.Visible = False
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

    Private Sub btnok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnok.Click
        Try

            If checkCutOff() Then
                MessageBox.Show("Your account is already cut off", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            If String.IsNullOrEmpty(txtremarks.Text) Then
                MessageBox.Show("Reason field is empty", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim errcount As Integer = 0
            For index As Integer = 0 To dgvorders.RowCount - 1
                If dgvorders.Rows(index).Cells("selectt").Value.ToString = "True" Then
                    errcount += 1
                End If
            Next

            If errcount = 0 Then
                MessageBox.Show("Please select order number to void", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim err As String = "The transaction(s) below are already paid or void" & Environment.NewLine

            For index As Integer = 0 To dgvorders.RowCount - 1

                Dim systemDate As String = getSystemDate.ToString("MM/dd/yyyy")

                Dim z As String = CStr(dgvorders.Rows(index).Cells("selectt").Value)
                If z <> "" Then
                    Dim status As String = ""
                    con.Open()
                    cmd = New SqlCommand("SELECT status2 FROM tbltransaction2 WHERE ordernum=@ordernum AND CAST(datecreated AS date)='" & systemDate & "';", con)
                    cmd.Parameters.AddWithValue("@ordernum", dgvorders.Rows(index).Cells("ordernum").Value)
                    rdr = cmd.ExecuteReader
                    If rdr.Read Then
                        status = rdr("status2")
                    End If
                    con.Close()
                    If status = "Paid" Then
                        err &= dgvorders.Rows(index).Cells("ordernum").Value & " (PAID)" & Environment.NewLine
                    ElseIf status = "Void" Then
                        err &= dgvorders.Rows(index).Cells("ordernum").Value & " (VOID)" & Environment.NewLine
                    End If
                End If
            Next

            If err.ToLower <> "The transaction(s) below are already paid or void".ToLower & Environment.NewLine Then
                MessageBox.Show(err, "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim a As String = MsgBox("Are you sure you want to void?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "")
            If a = vbYes Then
                For index As Integer = 0 To dgvorders.Rows.Count - 1
                    If String.IsNullOrEmpty(dgvorders.Rows(index).Cells(0).Value) Then
                        Continue For
                    ElseIf dgvorders.Rows(index).Cells(0).Value = True Then
                        con.Open()
                        cmd = New SqlCommand("UPDATE tbltransaction2 Set status2='Void',reason=@reason WHERE ordernum=@num", con)
                        cmd.Parameters.AddWithValue("@num", dgvorders.Rows(index).Cells("ordernum").Value)
                        cmd.Parameters.AddWithValue("@reason", txtremarks.Text)
                        cmd.ExecuteNonQuery()
                        con.Close()


                        Dim seniorResult As Boolean = False, serverDate As String = getSystemDate.ToString("MM/dd/yyyy")
                        con.Open()
                        cmd = New SqlCommand("SELECT systemid FROM tblsenior WHERE transnum=@ordernum AND CAST(datedisc AS date)=@discdate AND status=3", con)
                        cmd.Parameters.AddWithValue("@ordernum", dgvorders.Rows(index).Cells("ordernum").Value)
                        cmd.Parameters.AddWithValue("@discdate", serverDate)
                        rdr = cmd.ExecuteReader
                        If rdr.Read Then
                            seniorResult = True
                        End If
                        con.Close()

                        If seniorResult Then
                            con.Open()
                            cmd = New SqlCommand("UPDATE tblsenior SET status=1 WHERE transnum=@transnum AND CAST(datedisc AS date)=@discdate AND status=3", con)
                            cmd.Parameters.AddWithValue("@transnum", dgvorders.Rows(index).Cells("ordernum").Value)
                            cmd.Parameters.AddWithValue("@discdate", serverDate)
                            cmd.ExecuteNonQuery()
                            con.Close()
                        End If
                    End If
                Next
            End If
            MessageBox.Show("Order(s) Voided", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            checkboxvoidorders.Checked = False
            panelreasons.Visible = False
            txtremarks.Text = ""
            load_orders()
            clear_all()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

    Private Sub cmbsales_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbsales.SelectedIndexChanged
        load_orders()
    End Sub

    Private Sub btnref_Click(sender As Object, e As EventArgs) Handles btnref.Click
        load_orders()
    End Sub

    Private Sub cmbtypee_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbtypee.SelectedIndexChanged
        load_orders()
    End Sub

    Private Sub btnsearch_Click(sender As Object, e As EventArgs) Handles btnsearch.Click
        Try
            Dim result As Boolean = False
            con.Open()
            cmd = New SqlCommand("SELECT ordernum FROM tbltransaction2 WHERE ordernum=@ordernum AND status2='Unpaid' AND CAST(datecreated AS date)='" & DateTime.Now.ToString("MM/dd/yyyy") & "';", con)
            cmd.Parameters.AddWithValue("@ordernum", txtboxsearch.Text)
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                result = True
            End If
            con.Close()

            If result Then
                For index As Integer = 0 To dgvorders.RowCount - 1
                    If txtboxsearch.Text = dgvorders.Rows(index).Cells("ordernum").Value Then
                        dgvorders.Rows(index).Selected = True
                        lblordernum.Text = dgvorders.Rows(index).Cells("ordernum").Value
                        lblservicetype.Text = dgvorders.Rows(index).Cells("servicetype").Value

                        dgvitems.Rows.Clear()
                        type_holder = dgvorders.Rows(index).Cells("typee").Value
                        con.Open()
                        cmd = New SqlCommand("SELECT tblorder2.itemname,tblorder2.qty,tblorder2.price,tblorder2.dscnt,tblorder2.totalprice,tblorder2.request,tblorder2.free FROM tblorder2 WHERE tblorder2.ordernum=@ordernum AND CAST(tblorder2.datecreated AS date)='" & DateTime.Now.ToString("MM/dd/yyyy") & "';", con)
                        cmd.Parameters.AddWithValue("@ordernum", lblordernum.Text)
                        rdr = cmd.ExecuteReader()
                        While rdr.Read
                            Dim f As Boolean = False
                            dgvitems.Columns("quantity").DefaultCellStyle.Format = "n2"
                            dgvitems.Columns("price").DefaultCellStyle.Format = "n2"
                            dgvitems.Columns("discountpercent").DefaultCellStyle.Format = "n2"
                            dgvitems.Columns("amount").DefaultCellStyle.Format = "n2"
                            If CDbl(rdr("free")) <> 0 Then
                                f = True
                            End If
                            dgvitems.Rows.Add(rdr("itemname"), rdr("qty"), rdr("price"), rdr("dscnt"), rdr("totalprice"), rdr("request"), f)
                        End While
                        con.Close()

                        con.Open()
                        cmd = New SqlCommand("SELECT remarks,subtotal,disctype,less,delcharge,vatsales,vat,amtdue,tenderamt,change,gctotal FROM tbltransaction2 WHERE ordernum=@num AND CAST(tbltransaction2.datecreated AS date)='" & DateTime.Now.ToString("MM/dd/yyyy") & "';", con)
                        cmd.Parameters.AddWithValue("@num", lblordernum.Text)
                        rdr = cmd.ExecuteReader()
                        While rdr.Read
                            txtboxremarks.Text = rdr("remarks")
                            lblsubtotal.Text = CDbl(rdr("subtotal")).ToString("n2")
                            lbldiscountype.Text = rdr("disctype")
                            If lbldiscountype.Text = "" Then
                                lbldiscountype.Text = "N/A"
                            End If
                            lblless.Text = CInt(rdr("less")).ToString("n2")
                            lbldelcharge.Text = CDbl(rdr("delcharge")).ToString("n2")
                            lblvatsales.Text = CDbl(rdr("vatsales")).ToString("n2")
                            lblvatamount.Text = CDbl(rdr("vat")).ToString("n2")
                            lblgc.Text = CDbl(rdr("gctotal")).ToString("n2")
                            lbltotal.Text = CDbl(rdr("amtdue")).ToString("n2")
                            lbltenderamt.Text = CDbl(rdr("tenderamt")).ToString("n2")
                            lblchange.Text = CDbl(rdr("change")).ToString("n2")
                        End While
                        con.Close()
                    Else
                        dgvorders.Rows(index).Selected = False
                    End If
                Next
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub cmbservicetype_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbservicetype.SelectedIndexChanged
        load_orders()
    End Sub

    Private Sub cashier_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        If login.wrkgrp = "Cashier" Or login.wrkgrp = "Manager" Then
            area = "Sales"
        Else
            area = login.wrkgrp
        End If
        getID()
        loadSalesAgent()
        cmbservicetype.SelectedIndex = 0
        cmbtype.SelectedIndex = 0
        cmbtypee.SelectedIndex = 0
    End Sub

    Private Sub cashier_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            btncheckout.PerformClick()
        ElseIf e.KeyCode = Keys.F1 Then
            If checkboxvoidorders.Checked Then
                checkboxvoidorders.Checked = False
            Else
                checkboxvoidorders.Checked = True
            End If
        End If
    End Sub

    Private Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        txtresult.Text = ""
        Dim f As New add_spice()
        f.ShowDialog()
        If Not String.IsNullOrEmpty(txtresult.Text) Then
            txtresult.Text = txtresult.Text.Substring(0, txtresult.TextLength - 1)
        End If
    End Sub
End Class