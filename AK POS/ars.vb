Imports System.Data.SqlClient
Imports System.Text
Imports System.IO
Imports System.Security
Imports System.Security.Cryptography
Imports AK_POS.connection_class
Public Class ars
    Dim cc As New connection_class
    Dim con As New SqlConnection(cc.conString)
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader
    Dim transaction As SqlTransaction
    Public paid As Boolean = False
    Dim trnum As String = "", servicetype As String = "", gctotal As String = "", name_ As String = "", tnum As String = ""
    Dim trnum_temp As String = "", inv_id As String = ""
    Public tayp As String = "", lcacc As String = ""


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

    Private Sub ars_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtdate.Text = getSystemDate.ToString("MM/dd/yyyy")
        dtdate.MaxDate = getSystemDate()
        loadars1("Paid", tayp)
        getID()
        datesearch.Text = getSystemDate()
        datesearch.MaxDate = getSystemDate()
        lblheader.Text = Me.Text
    End Sub
    Public Sub getID()
        Try
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
                inv_id = id
            Else
                inv_id = "N/A"
            End If
        Catch ex As Exception

        Finally
        End Try
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
    Public Sub GetTransID()
        Try
            Dim area As String = ""
            If lcacc = "Cashier" Or lcacc = "Sales" Then
                area = "Sales"
            Else
                area = lcacc
            End If
            Dim selectcount_result As Integer = 0
            Dim branchcode As String = "", temp As String = "0", area_format As String = ""
            con.Open()
            cmd = New SqlCommand("Select ISNULL(MAX(transid),0) FROM tbltransaction WHERE area='" & area & "' AND tendertype !='Advance Payment' AND tendertype !='Cash Out' AND tendertype!='Deposit' AND tendertype !='Advance Payment Cash';", con)
            selectcount_result = cmd.ExecuteScalar() + 1
            con.Close()

            con.Open()
            cmd = New SqlCommand("Select branchcode FROM tblbranch WHERE main='1';", con)
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                branchcode = rdr("branchcode")
            End If
            area_format = "TR - " & branchcode & " - "
            If selectcount_result < 1000000 Then
                Dim cselectcount_result As String = CStr(selectcount_result)
                For vv As Integer = 1 To 6 - cselectcount_result.Length
                    temp += "0"
                Next
                trnum = area_format & temp & selectcount_result
            Else
                trnum = area_format & temp & selectcount_result
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
    Public Sub loadars1(ByVal stat As String, ByVal taypp As String)
        Dim q As String = ""
        If lcacc = "Manager" Then
            q = "SELECT DISTINCT *  FROM tblars1 WHERE status='Paid' AND type='" & taypp & "' AND CAST(date_created AS date)='" & datesearch.Text & "' ORDER BY transnum ASC"
            btnunpaid.Visible = False
            btnpaid.ForeColor = Color.Black
            dgvARS.Columns("action").Visible = False
            btnSubmit.Visible = False
        Else
            If taypp = "AR Sales" Then
                q = "SELECT DISTINCT *  FROM tblars1 WHERE status='" & stat & "' AND area='" & "Sales" & "' AND type='" & taypp & "'  AND CAST(date_created AS date)='" & datesearch.Text & "' ORDER BY transnum ASC"
            Else

                If stat = "" Then
                    Dim invv As String = "", zz As String = getSystemDate.AddDays(-1).ToString("yyyy-MM-dd")
                    con.Open()
                    cmd = New SqlCommand("Select TOP 1 invnum from tblinvsum WHERE area='" & lcacc & "' AND invdate='" & zz & "' AND verify=1 order by invsumid DESC", con)
                    rdr = cmd.ExecuteReader()
                    If rdr.Read() Then
                        invv = rdr("invnum")
                    End If
                    con.Close()
                    q = "SELECT DISTINCT tblars1.arnum, tblars1.transnum, tblars1.name, tblars1.amountdue, tblars1.date_created FROM tblars1 JOIN tblproduction ON tblars1.date_created = tblproduction.date WHERE tblproduction.type='Actual Ending Balance' AND tblproduction.area='" & lcacc & "' AND tblars1.invnum='" & invv & "';"
                Else
                    q = "Select DISTINCT *  FROM tblars1 WHERE status='" & stat & "' AND area='" & lcacc & "' AND type='" & taypp & "'  AND CAST(date_created AS date)='" & datesearch.Text & "' ORDER BY transnum ASC"
                End If
            End If
        End If
        dgvARS.Rows.Clear()
        Dim auto As New AutoCompleteStringCollection()
        con.Open()
        TextBox2.Text = q
        cmd = New SqlCommand(q, con)
        rdr = cmd.ExecuteReader()
        While rdr.Read
            Dim a As Double = 0.0
            Dim datetime As New DateTime()
            datetime = CDate(rdr("date_created"))
            dgvARS.Rows.Add(False, rdr("arnum"), rdr("transnum"), CInt(rdr("amountdue")).ToString("#,##0.##"), rdr("name"), datetime.ToString("MM/dd/yyyy hh:mm:ss tt"))
            auto.Add(rdr("transnum"))
            auto.Add(rdr("name"))
        End While
        con.Close()

        txtboxsearch.AutoCompleteCustomSource = auto
        checkrowcount()
    End Sub
    Public Sub checkrowcount()
        If dgvARS.Rows.Count = 0 Then
            lblErrror1.Visible = True
        Else
            lblErrror1.Visible = False
        End If
        If dgvArs2.Rows.Count = 0 Then
            lblError2.Visible = True
        Else
            lblError2.Visible = False
        End If
    End Sub
    Private Sub dgvARS_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvARS.CellContentClick, dgvARS.CellClick
        If e.ColumnIndex = 6 Then
            panelRemarks.Visible = True

        End If
        If e.ColumnIndex = 0 Or e.ColumnIndex = 1 Or e.ColumnIndex = 2 Or e.ColumnIndex = 3 And dgvARS.RowCount = 0 Then

            If btnpaid.ForeColor = Color.Black And tayp = "AR Charge" Or tayp = "AR Reject" Or tayp = "AR Cash" Or btneditar.ForeColor = Color.Black Then

                Panel1.Visible = True
                con.Open()
                cmd = New SqlCommand("SELECT sap_no,remarks,typenum FROM tblars1 WHERE transnum=@tnum;", con)
                cmd.Parameters.AddWithValue("@tnum", dgvARS.CurrentRow.Cells("transnum").Value)
                rdr = cmd.ExecuteReader
                If rdr.Read Then
                    lbltype.Text = rdr("typenum") & " #:"
                    lblSAPNo.Text = rdr("sap_no")
                    lblRemarks.Text = rdr("remarks")
                End If
                con.Close()
            ElseIf btnpaid.ForeColor = Color.Black And tayp = "AR Sales" Then
                Panel1.Visible = True
                con.Open()
                cmd = New SqlCommand("SELECT sap_no,remarks,typenum FROM tblars1 WHERE transnum=@tnum;", con)
                cmd.Parameters.AddWithValue("@tnum", dgvARS.CurrentRow.Cells("transnum").Value)
                rdr = cmd.ExecuteReader
                If rdr.Read Then
                    lbltype.Text = rdr("typenum") & " #:"
                    lblSAPNo.Text = rdr("sap_no")
                    lblRemarks.Text = rdr("remarks")
                End If
                con.Close()
            Else
                Panel1.Visible = False
            End If


            trnum_temp = dgvARS.CurrentRow.Cells("transnum").Value
            dgvArs2.Rows.Clear()
            con.Open()
            cmd = New SqlCommand("SELECT * FROM tblars2 WHERE transnum=@num AND name=@name;", con)
            cmd.Parameters.AddWithValue("@num", dgvARS.CurrentRow.Cells("transnum").Value)
            cmd.Parameters.AddWithValue("@name", dgvARS.CurrentRow.Cells("namee").Value)
            rdr = cmd.ExecuteReader()
            While rdr.Read
                dgvArs2.Rows.Add(rdr("description"), rdr("quantity"), CInt(rdr("price")).ToString("#,##0.##"), CInt(rdr("amount")).ToString("#,##0.##"))
                checkrowcount()
            End While
            con.Close()
        End If
        If dgvARS.CurrentRow.Cells("namee").Value = "Reject" Then
            paid = True
        Else
            paid = False
        End If
        con.Open()
        cmd = New SqlCommand("SELECT subtotal,disctype,less,delcharge,vatsales,vat,amtdue,servicetype,gctotal,customer,tinnum FROM tbltransaction WHERE transnum='" & dgvARS.CurrentRow.Cells("transnum").Value & "';", con)
        rdr = cmd.ExecuteReader()
        If rdr.Read Then
            Dim na As String = ""
            lblsubtotal.Text = CInt(rdr("subtotal")).ToString("#,000.00")
            If rdr("disctype") = "" Then
                na = "N/A"
            Else
                na = rdr("disctype")
            End If
            If paid = False Then
                lbldisctype.Text = na
                lblless.Text = CInt(rdr("less")).ToString("#,000.00")
                lbldelcharge.Text = CInt(rdr("delcharge")).ToString("#,000.00")
                lblvatsales.Text = CInt(rdr("vatsales")).ToString("#,000.00")
                lblvatamount.Text = CInt(rdr("vat")).ToString("#,000.00")
                servicetype = rdr("servicetype")
                gctotal = CInt(rdr("gctotal")).ToString("#,000.00")
                name_ = rdr("customer")
                If rdr("tinnum") = "" Then
                    na = "N/A"
                Else
                    na = rdr("tinnum")
                End If
                tnum = na
            Else
                lblsubtotal.Text = "000.00"
                lbldisctype.Text = "N/A"
                lblless.Text = "0.00"
                lbldelcharge.Text = "000.00"
                lbldelcharge.Text = "000.00"
                lblvatexemptsales.Text = "000.00"
                lblvatsales.Text = "000.00"
                lblvatamount.Text = "000.00"
                lbltotalamount.Text = "00.00"
                lblbalanceamount.Text = "00.00"
            End If
        End If
        con.Close()

        con.Open()
        cmd = New SqlCommand("SELECT amountdue,balance FROM tblars1 WHERE transnum='" & dgvARS.CurrentRow.Cells("transnum").Value & "';", con)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            lbltotalamount.Text = CDbl(rdr("amountdue")).ToString("n2")
            If IsDBNull(rdr("balance")) Then
                lblbalanceamount.Text = "0.00"
            Else
                lblbalanceamount.Text = CDbl(rdr("balance")).ToString("n2")
            End If
        End If
        con.Close()
    End Sub
    Public Function checkCutOff() As Boolean
        Try
            Dim status As String = "", date_from As New DateTime()
            con.Open()
            cmd = New SqlCommand("SELECT status,date FROM tblcutoff WHERE userid=(SELECT systemid FROM tblusers WHERE username=@username) ORDER BY cid DESC;", con)
            cmd.Parameters.AddWithValue("@username", login2.username)
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
    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        If tayp = "AR Charge" Or tayp = "AR Reject" Then
            Dim errors As Integer = 0
            For index As Integer = 0 To dgvARS.Rows.Count - 1
                If CBool(dgvARS.Rows(index).Cells("action").Value) = True Then
                    errors += 1
                End If
            Next

            If errors = 0 Or dgvARS.Rows.Count = 0 Then
                MsgBox("No A.R selected", MsgBoxStyle.Exclamation, "")
                Exit Sub
            End If
            If dgvARS.Rows.Count = 0 Or dgvArs2.Rows.Count = 0 Then
                MsgBox("Select A.R first.", MsgBoxStyle.Exclamation, "")
                Exit Sub
            ElseIf String.IsNullOrEmpty(txttenderamt.Text) Or CDbl(txttenderamt.Text) = 0 Then
                MsgBox("Amount tendered is empty. Enter amount.", MsgBoxStyle.Exclamation, "")
                Exit Sub
            End If
        ElseIf tayp = "AR Sales" Then
            If checkCutOff() Then
                MessageBox.Show("Your account is already cut off", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf dgvARS.Rows.Count = 0 Or dgvArs2.Rows.Count = 0 Then
                MsgBox("No A.R selected", MsgBoxStyle.Exclamation, "")
            Else
                If login2.wrkgrp <> "LC Accounting" Then
                    proceed()
                Else
                    paneldate.Visible = True
                End If
            End If
        End If
    End Sub

    Private Sub btnsearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsearch.Click
        con.Open()
        cmd = New SqlCommand("SELECT transnum,name FROM tblars1 WHERE transnum=@search OR name=@search;", con)
        cmd.Parameters.AddWithValue("@search", txtboxsearch.Text)
        rdr = cmd.ExecuteReader()
        If rdr.Read() Then

            For i As Integer = 0 To dgvARS.Rows.Count - 1
                If dgvARS.Rows(i).Cells("transnum").Value = rdr("transnum") Or dgvARS.Rows(i).Cells("namee").Value = rdr("name") Then
                    dgvARS.Rows(i).Selected = True
                    dgvARS.CurrentCell = dgvARS.Rows(i).Cells("transnum")
                Else
                    dgvARS.Rows(i).Selected = False
                End If
            Next
        End If

        con.Close()
    End Sub

    Private Sub btnunpaid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnunpaid.Click
        loadars1("Unpaid", tayp)
        paid = False
        If tayp = "AR Charge" Or tayp = "AR Reject" Then
            If paid Then
                dgvARS.Columns("action").Visible = False
                btnSubmit.Visible = False
            Else
                dgvARS.Columns("action").Visible = True
                btnSubmit.Visible = True
            End If
        ElseIf tayp = "AR Sales" Then
            If paid Then
                btnSubmit.Visible = False
                GroupBox1.Visible = False
                PanelSAP.Visible = False
            Else
                btnSubmit.Visible = True
                GroupBox1.Visible = True
                PanelSAP.Visible = False
            End If
        End If
        Panel1.Visible = False
        lblSAPNo.Text = ""
        lblRemarks.Text = ""
        dgvArs2.Rows.Clear()
        lblError2.Visible = True
        btnunpaid.ForeColor = Color.Black
        btnpaid.ForeColor = Color.White
        dgvARS.Columns("action").ReadOnly = False
    End Sub

    Private Sub btnpaid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnpaid.Click
        loadars1("Paid", tayp)
        paid = True
        If tayp = "AR Charge" Or tayp = "AR Reject" Then
            If paid Then
                dgvARS.Columns("action").Visible = False
                btnSubmit.Visible = False
            Else
                dgvARS.Columns("action").Visible = True
                btnSubmit.Visible = True
            End If
        ElseIf tayp = "AR Sales" Then
            If paid Then
                btnSubmit.Visible = False
                GroupBox1.Visible = False
                PanelSAP.Visible = False
            Else
                btnSubmit.Visible = True
                GroupBox1.Visible = True
                PanelSAP.Visible = False
            End If
        End If
        Panel1.Visible = False
        lblSAPNo.Text = ""
        lblRemarks.Text = ""
        dgvArs2.Rows.Clear()
        btnpaid.ForeColor = Color.Black
        btnunpaid.ForeColor = Color.White
        btneditar.ForeColor = Color.White
        dgvARS.Columns("action").ReadOnly = True
        dgvARS.Columns("btnedit").Visible = False
    End Sub

    Private Sub txttenderamt_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttenderamt.Leave
        If String.IsNullOrEmpty(txttenderamt.Text) Then
            Exit Sub
        Else
            Dim new_format As Double = txttenderamt.Text
            txttenderamt.Text = new_format.ToString("n2")
        End If
    End Sub


    Private Sub ars_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        'cmbtype.SelectedIndex = 0
        'If tayp = "AR Charge" Or tayp = "AR Reject" Then
        '    GroupBox1.Visible = False
        '    dgvARS.Columns("action").Visible = True
        '    btnpaid.PerformClick()
        'ElseIf tayp = "AR Sales" Then
        '    GroupBox1.Visible = True
        '    dgvARS.Columns("action").Visible = False
        '    btnunpaid.PerformClick()
        'End If
        'GetTransID()
    End Sub

    Private Sub datesearch_ValueChanged(sender As Object, e As EventArgs) Handles datesearch.ValueChanged
        loadars1(IIf(btnpaid.ForeColor = Color.Black, "Paid", "Unpaid"), tayp)
        Panel1.Visible = False
        lblSAPNo.Text = ""
        lblRemarks.Text = ""
        dgvArs2.Rows.Clear()
    End Sub

    Private Sub btnProceed_Click(sender As Object, e As EventArgs) Handles btnProceed.Click

    End Sub

    Private Sub btnproceed1_Click(sender As Object, e As EventArgs) Handles btnproceed1.Click
        Dim a As String = MsgBox("Are you sure you want to Cancel?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "")
        If a = vbYes Then

            Dim zz As String = getSystemDate()

            con.Open()
            cmd = New SqlCommand("UPDATE tblars1 SET sap_no='N/A',status='Paid',remarks=@remarks,date_cancelled='" & zz & "',cancelled_by='" & login2.username & "' WHERE transnum=@transnum;", con)
            cmd.Parameters.AddWithValue("@transnum", dgvARS.CurrentRow.Cells("transnum").Value)
            cmd.Parameters.AddWithValue("@remarks", txtremarks.Text)
            cmd.ExecuteNonQuery()
            con.Close()

            MessageBox.Show("Transaction Completed", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            loadars1("", tayp)
            panelRemarks.Visible = False
            txtremarks.Text = ""

        End If
    End Sub

    Private Sub lblhide_Click(sender As Object, e As EventArgs) Handles lblhide.Click
        panelRemarks.Visible = False
        txtremarks.Text = ""
    End Sub

    Private Sub ars_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        btnpaid.PerformClick()
    End Sub

    Private Sub txttenderamt_TextChanged(sender As Object, e As EventArgs) Handles txttenderamt.TextChanged
        Try
            Dim change As Double = 0.00
            change = CDbl(txttenderamt.Text) - CDbl(lblbalanceamount.Text)
            If txttenderamt.Text = "" Then
                txtchange.Text = 0.00
            ElseIf CDbl(txttenderamt.Text) = 0 Then
                txtchange.Text = 0.00
            ElseIf CDbl(txttenderamt.Text) > CDbl(lblbalanceamount.Text) Then
                txtchange.Text = change.ToString("n2")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnok_Click(sender As Object, e As EventArgs) Handles btnok.Click
        proceed()
    End Sub

    Private Sub lblclose3_Click(sender As Object, e As EventArgs) Handles lblclose3.Click
        paneldate.Visible = False
    End Sub

    Private Sub btneditar_Click(sender As Object, e As EventArgs) Handles btneditar.Click
        loadars1("", tayp)
        Panel1.Visible = False
        lblSAPNo.Text = ""
        lblRemarks.Text = ""
        dgvArs2.Rows.Clear()
        dgvARS.Columns("btnedit").Visible = True
        btnpaid.ForeColor = Color.White
        btnunpaid.ForeColor = Color.White
        btneditar.ForeColor = Color.Black
    End Sub

    Private Sub dgvARS_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvARS.DataError
        e.Cancel = True
    End Sub

    Private Sub lblProductionClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblProductionClose.Click
        dgvARS.Columns("action").ReadOnly = False
        PanelSAP.Visible = False
    End Sub
    Public Sub proceed()
        Try
            If tayp = "AR Sales" Then
                getID()
                GetTransID()
                Dim a As String = MsgBox("Are you sure you want to proceed?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "")
                If a = vbYes Then
                    Try
                        Using connection As New SqlConnection(cc.conString)
                            Dim cmdd As New SqlCommand()
                            cmdd.Connection = connection
                            connection.Open()
                            transaction = connection.BeginTransaction()
                            cmdd.Transaction = transaction
                            If CDbl(lblbalanceamount.Text) = 0 Then
                                If CDbl(txttenderamt.Text) < CDbl(lbltotalamount.Text) Then
                                    Dim balanceAmt As Double = CDbl(lbltotalamount.Text) - CDbl(txttenderamt.Text)
                                    cmdd.Parameters.Clear()
                                    cmdd.CommandText = "UPDATE tblars1 SET balance=@balance WHERE transnum=@num AND name=@name AND type='AR Sales';"
                                    cmdd.Parameters.AddWithValue("@balance", balanceAmt)
                                    cmdd.Parameters.AddWithValue("@num", dgvARS.CurrentRow.Cells("transnum").Value)
                                    cmdd.Parameters.AddWithValue("@name", dgvARS.CurrentRow.Cells("namee").Value)
                                    cmdd.ExecuteNonQuery()
                                Else
                                    cmdd.Parameters.Clear()
                                    cmdd.CommandText = "UPDATE tblars1 SET balance=0, status='Paid' WHERE transnum=@num AND name=@name AND type='AR Sales';"
                                    cmdd.Parameters.AddWithValue("@num", dgvARS.CurrentRow.Cells("transnum").Value)
                                    cmdd.Parameters.AddWithValue("@name", dgvARS.CurrentRow.Cells("namee").Value)
                                    cmdd.ExecuteNonQuery()
                                    Dim zz As String = IIf(login2.wrkgrp = "LC Accounting", dtdate.Text, getSystemDate.ToString("MM/dd/yyyy hh:mm:ss tt"))

                                    cmdd.CommandText = "INSERT INTO tblars1 (arnum,transnum,amountdue,name,status,date_created,created_by,area,invnum,type,balance,typenum,sap_no,remarks,from_transnum) VALUES (@arnum,@transnum, @amountdue, @name, @status, @date, @createdby,@area,@invnum,@taypp,@balance,@typenum,@sap_no,@remarks,@from_transnum)"
                                    cmdd.Parameters.AddWithValue("@arnum", "")
                                    cmdd.Parameters.AddWithValue("@transnum", trnum)
                                    cmdd.Parameters.AddWithValue("@amountdue", CDbl(dgvARS.CurrentRow.Cells("amtdue").Value))
                                    cmdd.Parameters.AddWithValue("@name", dgvARS.CurrentRow.Cells("namee").Value)
                                    cmdd.Parameters.AddWithValue("@status", "Paid")
                                    cmdd.Parameters.AddWithValue("@date", zz)
                                    cmdd.Parameters.AddWithValue("@createdby", login2.username)
                                    cmdd.Parameters.AddWithValue("@area", "Sales")
                                    cmdd.Parameters.AddWithValue("@invnum", inv_id)
                                    cmdd.Parameters.AddWithValue("@taypp", "AR Cash")
                                    cmdd.Parameters.AddWithValue("@balance", 0)
                                    cmdd.Parameters.AddWithValue("@typenum", "AR")
                                    cmdd.Parameters.AddWithValue("@sap_no", "To Follow")
                                    cmdd.Parameters.AddWithValue("@remarks", "")
                                    cmdd.Parameters.AddWithValue("@from_trans", dgvARS.CurrentRow.Cells("transnum").Value)
                                    cmdd.ExecuteNonQuery()

                                    For index As Integer = 0 To dgvArs2.Rows.Count - 1
                                        cmdd.Parameters.Clear()
                                        cmdd.CommandText = "INSERT INTO tblars2 (transnum,description,quantity,price,amount,area,name) VALUES (@tnum, @des,@qua,@price,@am,@area,@n)"
                                        cmdd.Parameters.AddWithValue("@tnum", trnum)
                                        cmdd.Parameters.AddWithValue("@des", dgvArs2.Rows(index).Cells("description").Value)
                                        cmdd.Parameters.AddWithValue("@qua", CDbl(dgvArs2.Rows(index).Cells("quantity").Value))
                                        cmdd.Parameters.AddWithValue("@price", CDbl(dgvArs2.Rows(index).Cells("price").Value))
                                        cmdd.Parameters.AddWithValue("@am", CDbl(dgvArs2.Rows(index).Cells("amount").Value))
                                        cmdd.Parameters.AddWithValue("@area", lcacc)
                                        cmdd.Parameters.AddWithValue("@n", dgvARS.CurrentRow.Cells("namee").Value)
                                        cmdd.ExecuteNonQuery()
                                    Next
                                End If
                            Else
                                If CDbl(txttenderamt.Text) < CDbl(lblbalanceamount.Text) Then
                                    Dim balanceAmt As Double = CDbl(lblbalanceamount.Text) - CDbl(txttenderamt.Text)
                                    cmdd.Parameters.Clear()
                                    cmdd.CommandText = "UPDATE tblars1 SET balance=@balance WHERE transnum=@num AND name=@name AND type='AR Sales';"
                                    cmdd.Parameters.AddWithValue("@balance", balanceAmt)
                                    cmdd.Parameters.AddWithValue("@num", dgvARS.CurrentRow.Cells("transnum").Value)
                                    cmdd.Parameters.AddWithValue("@name", dgvARS.CurrentRow.Cells("namee").Value)
                                    cmdd.ExecuteNonQuery()
                                Else
                                    cmdd.Parameters.Clear()
                                    cmdd.CommandText = "UPDATE tblars1 SET balance=0, status='Paid' WHERE transnum=@num AND name=@name AND type='AR Sales';"
                                    cmdd.Parameters.AddWithValue("@num", dgvARS.CurrentRow.Cells("transnum").Value)
                                    cmdd.Parameters.AddWithValue("@name", dgvARS.CurrentRow.Cells("namee").Value)
                                    cmdd.ExecuteNonQuery()
                                    Dim zz As String = IIf(login2.wrkgrp = "LC Accounting", dtdate.Text, getSystemDate.ToString("MM/dd/yyyy hh:mm:ss tt"))
                                    cmdd.Parameters.Clear()
                                    cmdd.CommandText = "INSERT INTO tblars1 (arnum,transnum,amountdue,name,status,date_created,created_by,area,invnum,type,balance,typenum,sap_no,remarks,from_transnum) VALUES (@arnum,@transnum, @amountdue, @name, @status, @date, @createdby,@area,@invnum,@taypp,@balance,@typenum,@sap_no,@remarks,@from_transnum)"
                                    cmdd.Parameters.AddWithValue("@arnum", "")
                                    cmdd.Parameters.AddWithValue("@transnum", trnum)
                                    cmdd.Parameters.AddWithValue("@amountdue", CDbl(dgvARS.CurrentRow.Cells("amtdue").Value))
                                    cmdd.Parameters.AddWithValue("@name", dgvARS.CurrentRow.Cells("namee").Value)
                                    cmdd.Parameters.AddWithValue("@status", "Paid")
                                    cmdd.Parameters.AddWithValue("@date", zz)
                                    cmdd.Parameters.AddWithValue("@createdby", login2.username)
                                    cmdd.Parameters.AddWithValue("@area", "Sales")
                                    cmdd.Parameters.AddWithValue("@invnum", inv_id)
                                    cmdd.Parameters.AddWithValue("@taypp", "AR Cash")
                                    cmdd.Parameters.AddWithValue("@balance", 0)
                                    cmdd.Parameters.AddWithValue("@typenum", "AR")
                                    cmdd.Parameters.AddWithValue("@sap_no", "To Follow")
                                    cmdd.Parameters.AddWithValue("@remarks", "")
                                    cmdd.Parameters.AddWithValue("@from_transnum", dgvARS.CurrentRow.Cells("transnum").Value)
                                    cmdd.ExecuteNonQuery()
                                    For index As Integer = 0 To dgvArs2.Rows.Count - 1
                                        cmdd.Parameters.Clear()
                                        cmdd.CommandText = "INSERT INTO tblars2 (transnum,description,quantity,price,amount,area,name) VALUES (@tnum, @des,@qua,@price,@am,@area,@n)"
                                        cmdd.Parameters.AddWithValue("@tnum", trnum)
                                        cmdd.Parameters.AddWithValue("@des", dgvArs2.Rows(index).Cells("description").Value)
                                        cmdd.Parameters.AddWithValue("@qua", CDbl(dgvArs2.Rows(index).Cells("quantity").Value))
                                        cmdd.Parameters.AddWithValue("@price", CDbl(dgvArs2.Rows(index).Cells("price").Value))
                                        cmdd.Parameters.AddWithValue("@am", CDbl(dgvArs2.Rows(index).Cells("amount").Value))
                                        cmdd.Parameters.AddWithValue("@area", lcacc)
                                        cmdd.Parameters.AddWithValue("@n", dgvARS.CurrentRow.Cells("namee").Value)
                                        cmdd.ExecuteNonQuery()
                                    Next
                                End If
                            End If
                            Dim partialamt As Double = 0.00, amtdue As Double = 0.0
                            If CDbl(lblbalanceamount.Text) = 0 Then
                                If CDbl(lbltotalamount.Text) <= CDbl(txttenderamt.Text) Then
                                    amtdue = CDbl(lbltotalamount.Text)
                                Else
                                    partialamt = CDbl(txttenderamt.Text)
                                End If
                            Else
                                If CDbl(lblbalanceamount.Text) <= CDbl(txttenderamt.Text) Then
                                    amtdue = CDbl(lblbalanceamount.Text)
                                Else
                                    partialamt = CDbl(txttenderamt.Text)
                                End If
                            End If
                            Dim serverDate As DateTime = IIf(login2.wrkgrp = "LC Accounting", dtdate.Text, getSystemDate())
                            cmdd.Parameters.Clear()
                            cmdd.CommandText = "Insert into tbltransaction (ornum, transnum, transdate, cashier, tendertype, servicetype, delcharge, subtotal, disctype, less, vatsales, vat, amtdue, gctotal, tenderamt, change, refund, comment, remarks, customer, tinnum, tablenum, pax, datecreated, datemodified, status,area,invnum,partialamt,typez) values ('0', '" & trnum & "', '" & Format(serverDate, "MM/dd/yyyy hh:mm:ss tt") & "','" & login2.username & "', 'A.R Cash', '" & "A.R Cash" & "', '" & "0" & "', '" & CDbl(lblsubtotal.Text) & "', '" & "N/A" & "', '" & "0.00" & "', '" & "0.00" & "', '" & "0.00" & "', '" & amtdue & "', '" & "0" & "', '" & "0" & "', '" & "0.00" & "', '0', '', '', '" & dgvARS.CurrentRow.Cells("namee").Value & "','', '', '1', '" & serverDate & "', '" & serverDate & "', '1','" & "Sales" & "','" & inv_id & "','" & partialamt & "',(SELECT typez FROM tbltransaction WHERE transnum='" & dgvARS.CurrentRow.Cells("transnum").Value & "'))"
                            cmdd.ExecuteNonQuery()

                            cmdd.Parameters.Clear()
                            cmdd.CommandText = "INSERT INTO tbltransaction2 (ornum,ordernum,transdate,cashier,tendertype,servicetype,delcharge,subtotal,disctype,less,vatsales,vat,amtdue,tenderamt,change,refund,comment,remarks,customer,tinnum,tablenum,pax,createdby,datecreated,datemodified,status,status2,area,gctotal,typez,discamt,transnum)VALUES ('000',@ordernum,@transdate,@cashier,@tendertype,@servicetype,@delcharge,@subtotal,@disctype,@less,@vatsales,@vat,@amtdue,@tenderamt,@change,@refund,@comment,@remarks,@customer,@tinum,0,0,@createdby,@date,@date,1,'Paid','Sales',@gctotal,(SELECT typez FROM tbltransaction WHERE transnum='" & dgvARS.CurrentRow.Cells("transnum").Value & "'),@discamt,@transnum)"
                            cmdd.Parameters.AddWithValue("@ordernum", 0)
                            cmdd.Parameters.AddWithValue("@transdate", serverDate)
                            cmdd.Parameters.AddWithValue("@cashier", login2.username)
                            cmdd.Parameters.AddWithValue("@tendertype", "A.R Cash")
                            cmdd.Parameters.AddWithValue("@servicetype", servicetype)
                            cmdd.Parameters.AddWithValue("@delcharge", 0)
                            cmdd.Parameters.AddWithValue("@subtotal", CDbl(lblsubtotal.Text))
                            cmdd.Parameters.AddWithValue("@disctype", "N/A")
                            cmdd.Parameters.AddWithValue("@less", 0)
                            cmdd.Parameters.AddWithValue("@vatsales", 0)
                            cmdd.Parameters.AddWithValue("@vat", 0)
                            cmdd.Parameters.AddWithValue("@amtdue", amtdue)
                            cmdd.Parameters.AddWithValue("@tenderamt", 0)
                            cmdd.Parameters.AddWithValue("@change", 0)
                            cmdd.Parameters.AddWithValue("@refund", 0)
                            cmdd.Parameters.AddWithValue("@comment", "")
                            cmdd.Parameters.AddWithValue("@remarks", "")
                            cmdd.Parameters.AddWithValue("@customer", dgvARS.CurrentRow.Cells("namee").Value)
                            cmdd.Parameters.AddWithValue("@tinum", 0)
                            cmdd.Parameters.AddWithValue("@createdby", login2.username)
                            cmdd.Parameters.AddWithValue("@gctotal", 0)
                            cmdd.Parameters.AddWithValue("@discamt", 0)
                            cmdd.Parameters.AddWithValue("@transnum", trnum)
                            cmdd.Parameters.AddWithValue("@date", serverDate)
                            cmdd.ExecuteNonQuery()
                            transaction.Commit()
                            MessageBox.Show("Transaction Completed", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            paneldate.Visible = False
                            loadars1("Unpaid", tayp)
                            dgvArs2.Rows.Clear()
                            checkrowcount()
                            txttenderamt.Text = "0.00"
                            txtchange.Text = "0.00"
                            txtboxSAPNo.Text = ""
                            txtboxRemarks.Text = ""
                            lbltotalamount.Text = "0.00"
                            lblbalanceamount.Text = "0.00"
                            PanelSAP.Visible = False
                            dgvARS.Columns("action").ReadOnly = False
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
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub checkfollowup_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles checkfollowup.CheckedChanged
        If checkfollowup.Checked Then
            txtboxSAPNo.Text = ""
            txtboxSAPNo.Enabled = False
        Else
            txtboxSAPNo.Enabled = True
        End If
    End Sub

    Private Sub txtboxSAPNo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtboxSAPNo.KeyPress
        If Not Char.IsControl(e.KeyChar) And Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
End Class