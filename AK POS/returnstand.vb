Imports System.Data.SqlClient
Imports System.IO
Imports AK_POS.connection_class
Public Class returnstand
    Dim cc As New connection_class
    Dim con As New SqlConnection(cc.conString)
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader

    Dim inv_id As String = "", apnum As String = "", trnum As String = ""
    Public Shared cnfrm As Boolean = False

    Public Function decryptConString() As String
        Dim base64encoded As String = File.ReadAllText("connectionstring.txt")
        Dim data As Byte() = System.Convert.FromBase64String(base64encoded)
        Return System.Text.ASCIIEncoding.ASCII.GetString(data)
    End Function

    Private Sub returnstand_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        btnreturns.PerformClick()
        loadd()
        If login.wrkgrp = "Manager" Then
            dgvlists.Columns("btnreturn").Visible = False
        End If
        Me.WindowState = FormWindowState.Maximized

        cmbstatus.SelectedIndex = 0

        cmbstatus2.SelectedIndex = 0

        getID()
        loadtransnum()
        If login.wrkgrp = "Manager" Then
            'ap
            Label3.Visible = False
            Label4.Visible = False
            Label6.Visible = False
            txtboxamount.Visible = False
            txtboxname.Visible = False
            lblap.Visible = False
            btnadd.Visible = False
            dgv.Columns("reprint").Visible = False

            'dep
            Label5.Visible = False
            txtname.Visible = False
            Label2.Visible = False
            txtamount.Visible = False
            Label1.Visible = False
            lbldeposit.Visible = False
            btnadd2.Visible = False
            dgv2.Columns("reprint2").Visible = False
        End If

    End Sub
    Public Sub loadItems(ByVal stats As String, ByVal stats2 As String)
        Try
            dgvlists.Rows.Clear()
            con.Open()
            cmd = New SqlCommand("SELECT DISTINCT tblreturns.returnum, tbladvancepayment.amount,tblitems.itemname,tblitems.itemcode, tbladvancepayment.name, tbladvancepayment.ap_id,tblitems.category, tbladvancepayment.date,tbltransaction.transnum,ISNULL(tblreturns.date,'') AS dd,ISNULL(tblreturns.byy,'') AS byy FROM tblreturns JOIN tbladvancepayment ON tblreturns.ap_id = tbladvancepayment.ap_id JOIN tbltransaction ON tblreturns.transnum = tbltransaction.transnum JOIN tblorder ON tblorder.transnum = tblreturns.transnum JOIN tblitems ON tblorder.itemname = tblitems.itemname WHERE  tbladvancepayment.status='" & stats & "' AND tblreturns.status='" & stats2 & "' ORDER BY tblreturns.returnum;", con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                dgvlists.Rows.Add(rdr("returnum"), rdr("ap_id"), rdr("transnum"), rdr("name"), rdr("itemcode"), rdr("itemname"), rdr("category"), rdr("amount"), rdr("date"), rdr("dd"), rdr("byy"), "")
            End While
            con.Close()
            getID()
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
        Try
            Dim id As String = ""
            Dim date_ As New DateTime()
            con.Open()
            cmd = New SqlCommand("Select TOP 1 invnum,datecreated from tblinvsum WHERE area='Sales' order by invsumid DESC", con)
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
    Private Sub dgvlists_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvlists.CellContentClick
        If e.ColumnIndex = 11 Then
            Dim a As String = MsgBox("Are you sure you want to submit?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "")
            If a = vbYes Then

                If checkCutOff() Then
                    MessageBox.Show("Your account is already cut off", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                Dim c As New confirm()
                c.ShowDialog()
                If cnfrm = False Then
                    Exit Sub
                End If

                con.Open()
                cmd = New SqlCommand("UPDATE tblreturns SET status='Used',date=(SELECT GETDATE()),byy='" & login.username & "' WHERE returnum='" & dgvlists.CurrentRow.Cells("id2").Value & "';", con)
                cmd.ExecuteNonQuery()
                con.Close()

                con.Open()
                cmd = New SqlCommand("UPDATE tbladvancepayment SET status='Used' WHERE ap_id='" & dgvlists.CurrentRow.Cells("id").Value & "';", con)
                cmd.ExecuteNonQuery()
                con.Close()

                Dim zz As String = getSystemDate.ToString("MM/dd/yyy")

                con.Open()
                cmd = New SqlCommand("Insert into tbltransaction (ornum, transnum, transdate, cashier, tendertype, servicetype, delcharge, subtotal, disctype, less, vatsales, vat, amtdue, gctotal, tenderamt, change, refund, comment, remarks, customer, tinnum, tablenum, pax, datecreated, datemodified, status,area,invnum,partialamt) values ('" & "0" & "', '" & dgvlists.CurrentRow.Cells("transnum").Value & "', '" & zz & "','" & login.cashier & "', '" & "Cash Out" & "', '" & "Cash Out" & "', '" & "0" & "', '" & "0" & "', '" & "N/A" & "', '" & "0" & "', '" & "0" & "', '" & "0" & "', '" & dgvlists.CurrentRow.Cells("amount").Value & "', '" & "0" & "', '" & "0" & "', '" & "0" & "', '0', '', '', '" & dgvlists.CurrentRow.Cells("custname").Value & "', '" & "0" & "', '" & "0" & "', '" & "0" & "',(SELECT GETDATE()),(SELECT GETDATE()), '1','" & "Sales" & "','" & inv_id & "','0')", con)
                cmd.ExecuteNonQuery()
                con.Close()

                MessageBox.Show("Transaction Completed", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                loadItems("Used", "Active")
            End If
        End If
    End Sub

    Private Sub btnreturns_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnreturns.Click
        loadItems("Used", "Active")

        btnreturns.ForeColor = Color.Black
        btnhistory.ForeColor = Color.White
        dgvlists.Columns("btnreturn").Visible = True
        If login.wrkgrp = "Manager" Then
            dgvlists.Columns("btnreturn").Visible = False
        End If
        dgvlists.Columns("datereturned").Visible = False
        dgvlists.Columns("by").Visible = False
    End Sub

    Private Sub btnhistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhistory.Click
        loadItems("Used", "Used")
        btnreturns.ForeColor = Color.White
        btnhistory.ForeColor = Color.Black
        dgvlists.Columns("btnreturn").Visible = False
        dgvlists.Columns("datereturned").Visible = True
        dgvlists.Columns("by").Visible = True
    End Sub

    Public Sub getApNum(ByVal cm As Label)
        Try
            Dim selectcount_result As Integer = 0
            Dim get_area As String = "", temp As String = "0"
            Dim area_format As String = ""
            con.Open()
            cmd = New SqlCommand("Select ISNULL(MAX(ap_id),0) FROM tbladvancepayment WHERE type=@type;", con)
            cmd.Parameters.AddWithValue("@type", cm.Text)
            selectcount_result = cmd.ExecuteScalar() + 1
            con.Close()
            Dim branchcode As String = ""
            con.Open()
            cmd = New SqlCommand("SELECT branchcode FROM tblbranch WHERE main='1';", con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                branchcode = rdr("branchcode")
            End While
            con.Close()

            If cm.Text = "Advance Payment" Then
                area_format = "SALADV - " & branchcode & " - "
            Else
                area_format = "SALDEP - " & branchcode & " - "
            End If

            If selectcount_result < 1000000 Then
                Dim cselectcount_result As String = CStr(selectcount_result)
                For vv As Integer = 1 To 6 - cselectcount_result.Length
                    temp += "0"
                Next
                apnum = area_format & temp & selectcount_result
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
    Public Sub loadCustomers(ByVal txtbox As TextBox)
        Dim auto As New AutoCompleteStringCollection()
        con.Open()
        cmd = New SqlCommand("SELECT name FROM tblcustomers WHERE type != 'Employee';", con)
        rdr = cmd.ExecuteReader
        While rdr.Read
            auto.Add(rdr("name"))
        End While
        con.Close()
        txtbox.AutoCompleteCustomSource = auto
    End Sub

    Public Sub loadData(ByVal q As String, ByVal grd As DataGridView, ByVal err As Label, ByVal tname As TextBox)
        Dim auto As New AutoCompleteStringCollection()
        grd.Rows.Clear()
        con.Open()
        cmd = New SqlCommand(q, con)
        rdr = cmd.ExecuteReader()
        While rdr.Read
            Dim d As New DateTime()
            d = CDate(rdr("date"))
            Dim amount As Double = rdr("amount")
            grd.Rows.Add(rdr("apnum"), rdr("name"), amount.ToString("n2"), d.ToString("MM/dd/yyyy"), rdr("status"), rdr("type"))
            auto.Add(rdr("name"))
        End While
        con.Close()
        'If grd.Rows.Count = 0 Then
        '    err.Visible = True
        'Else
        '    err.Visible = False
        'End If
        loadCustomers(tname)
    End Sub
    Public Sub loadtransnum()
        Dim area As String = ""
        If login.wrkgrp = "Cashier" Or login.wrkgrp = "Sales" Then
            area = "Sales"
        Else
            area = login.wrkgrp
        End If
        Dim temp As String = "0", selectcount_result As Integer = 0, area_format As String = ""
        con.Open()
        cmd = New SqlCommand("Select ISNULL(MAX(transid),0)  from tbltransaction WHERE area='" & area & "'", con)
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

        area_format = "TR - " & branchcode & " - "

        If selectcount_result < 1000000 Then
            Dim cselectcount_result As String = CStr(selectcount_result)
            For vv As Integer = 1 To 6 - cselectcount_result.Length
                temp += "0"
            Next
            trnum = area_format & temp & selectcount_result
        End If
    End Sub

    Public Function checkCutOff() As Boolean
        Try
            Dim status As String = "", date_from As New DateTime()
            connect()
            cmd = New SqlCommand("SELECT status,date FROM tblcutoff WHERE userid=(SELECT systemid FROM tblusers WHERE username=@username) ORDER BY cid DESC;", con)
            cmd.Parameters.AddWithValue("@username", login.username)
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                status = rdr("status")
                date_from = CDate(rdr("date"))
            End If
            disconnect()
            If status = "In Active" And date_from.ToString("MM/dd/yyyy") = getSystemDate.ToString("MM/dd/yyyy") Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Function

    Public Sub add(ByVal tname As TextBox, ByVal tamount As TextBox, ByVal lbltype As Label, ByVal cmstatus As ComboBox, ByVal grd As DataGridView, ByVal err As Label)
        Try
            If checkCutOff() Then
                MessageBox.Show("Your account is already cut off", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf tname.Text = "" And tamount.Text = "" Then
                MessageBox.Show("Fields is empty", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            ElseIf tname.Text = "" Then
                MessageBox.Show("Name is empty", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            ElseIf tamount.Text = "" Then
                MessageBox.Show("Amount is empty", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            ElseIf Not IsNumeric(tamount.Text) Then
                MessageBox.Show("Amount must be a number", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            ElseIf tname.Text.Length < 2 Then
                MessageBox.Show("Name is too short", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Else
                getApNum(lbltype)
                con.Open()
                cmd = New SqlCommand("INSERT INTO tbladvancepayment (name,amount,date,status,type,apnum) VALUES (@name,@amount,(SELECT GETDATE()),@status,@typeee,@apnum)", con)
                cmd.Parameters.AddWithValue("@name", tname.Text)
                cmd.Parameters.AddWithValue("@amount", CDbl(tamount.Text))
                cmd.Parameters.AddWithValue("@status", "Active")
                cmd.Parameters.AddWithValue("@typeee", lbltype.Text)
                cmd.Parameters.AddWithValue("@apnum", apnum)
                cmd.ExecuteNonQuery()
                con.Close()

                Dim tayp As String = If(lbltype.Text = "Advance Payment", "Advance Payment Cash", "Deposit")

                Dim zz As String = getSystemDate.ToString("MM/dd/yyyy")

                con.Open()
                cmd = New SqlCommand("Insert into tbltransaction (ornum, transnum, transdate, cashier, tendertype, servicetype, delcharge, subtotal, disctype, less, vatsales, vat, amtdue, gctotal, tenderamt, change, refund, comment, remarks, customer, tinnum, tablenum, pax, datecreated, datemodified, status,area,invnum) values (0,'" & apnum & "','" & zz & "','" & login.cashier & "','" & tayp & "','" & tayp & "','0','0','N/A','0','0','0','" & CDbl(tamount.Text) & "','0','0','0','0','','','','N/A','','1',(SELECT GETDATE()),(SELECT GETDATE()),'1','Sales','" & inv_id & "')", con)
                cmd.ExecuteNonQuery()
                con.Close()

                MessageBox.Show("Transaction Completed", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                getApNum(lbltype)
                loadtransnum()
                loadData("SELECT * FROM tbladvancepayment WHERE status='" & cmstatus.Text & "' AND type='" & lbltype.Text & "'", grd, err, tname)
                tamount.Text = ""
                tname.Text = ""
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub btnadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadd.Click
        add(txtboxname, txtboxamount, lblap, cmbstatus, dgv, lblerror)
    End Sub
    Public Sub cmbstatus_selectedindexchanged(ByVal cmstatus As ComboBox, ByVal grd As DataGridView, ByVal columnNameReprint As String, ByVal err As Label, ByVal tname As TextBox, ByVal lbltype As Label, ByVal columnNameCancel As String)

        loadData("SELECT * FROM tbladvancepayment WHERE status='" & cmstatus.SelectedItem & "' AND type='" & lbltype.Text & "'", grd, err, tname)
        If cmstatus.SelectedIndex = 0 Then
            grd.Columns(columnNameReprint).Visible = True
            grd.Columns(columnNameCancel).Visible = True
        ElseIf cmstatus.SelectedIndex = 1 Then
            grd.Columns(columnNameReprint).Visible = False
            grd.Columns(columnNameCancel).Visible = False
        ElseIf cmstatus.SelectedIndex = 2 Then
            grd.Columns(columnNameReprint).Visible = False
            grd.Columns(columnNameCancel).Visible = False
        End If
    End Sub
    Private Sub cmbstatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbstatus.SelectedIndexChanged
        loadd()
    End Sub
    Public Sub txtname_leave(ByVal tname As TextBox)
        tname.Text = StrConv(tname.Text, VbStrConv.ProperCase)
    End Sub
    Private Sub txtboxname_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtboxname.Leave
        txtname_leave(txtboxname)
    End Sub
    Public Sub dgv_contentclick(ByVal e As System.Windows.Forms.DataGridViewCellEventArgs, ByVal grd As DataGridView, ByVal cellID As String, ByVal cellName As String, ByVal cellAmount As String, ByVal cellDate As String, ByVal cellType As String, ByVal cmstatus As ComboBox, ByVal lbltype As Label, ByVal err As Label, ByVal tname As TextBox)
        If e.ColumnIndex = 6 Then
            Dim cform As New cform_advancepayment()
            cform.Show()
            Dim c As New c_advancepayment2()
            c.SetParameterValue("id", grd.CurrentRow.Cells(cellID).Value)
            c.SetParameterValue("name", grd.CurrentRow.Cells(cellName).Value)
            c.SetParameterValue("amount", grd.CurrentRow.Cells(cellAmount).Value)
            c.SetParameterValue("date", grd.CurrentRow.Cells(cellDate).Value)
            Dim name As String = ""
            con.Open()
            cmd = New SqlCommand("SELECT fullname FROM tblusers WHERE username=@username;", con)
            cmd.Parameters.AddWithValue("@username", login.username)
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                name = rdr("fullname")
            Else
                name = login.username
            End If
            con.Close()

            c.SetParameterValue("processed_by", name)
            Dim txtType As String = ""
            If grd.CurrentRow.Cells(cellType).Value = "Advance Payment" Then
                txtType = "ADVANCE PAYMENT SLIP"
            Else
                txtType = "DEPOSIT SLIP"
            End If
            c.SetParameterValue("header", "ATLANTIC BAKERY" & Environment.NewLine & txtType)
            cform.CrystalReportViewer1.ReportSource = c
            cform.CrystalReportViewer1.Refresh()
        ElseIf e.ColumnIndex = 7 Then
            Dim a As String = MsgBox("Are you sure you want to cancel?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "")
            If a = vbYes Then

                'If checkCutOff() Then
                '    MessageBox.Show("Your account is already cut off", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                '    Exit Sub
                'End If

                If grd.Name = "dgv2" Then
                    txtdepreason.Text = ""
                    txtdepreason.Focus()
                    paneldepreason.Visible = True
                Else
                    txtapreason.Text = ""
                    txtapreason.Focus()
                    panelapreason.Visible = True
                End If
            End If
        End If
    End Sub
    Private Sub dgv_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellContentClick
        dgv_contentclick(e, dgv, "apid", "apname", "apamount", "apdate", "aptype", cmbstatus, lblap, lblerror, txtboxname)
    End Sub
    'Public Sub cmbserarchtype_indexchanged(ByVal cmstatus As ComboBox, ByVal cmtype As ComboBox, ByVal err As Label, ByVal tname As TextBox, ByVal grd As DataGridView)
    '    loadData("SELECT * FROM tbladvancepayment WHERE status='" & cmstatus.SelectedItem & "' AND type='" & cmtype.SelectedItem & "'", grd, err, tname)
    'End Sub

    Private Sub cmbtype_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        getApNum(lbldeposit)
    End Sub

    Private Sub btnadd2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadd2.Click
        add(txtname, txtamount, lbldeposit, cmbstatus2, dgv2, lblerror2)
    End Sub

    Private Sub txtname_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtname.Leave
        txtname_leave(txtname)
    End Sub

    Private Sub cmbtype2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        getApNum(lbldeposit)
    End Sub
    Public Sub loadd()
        cmbstatus_selectedindexchanged(cmbstatus2, dgv2, "reprint2", lblerror2, txtname, lblsearchdeposit, "btncancel2")
        loadItems("Used", "Active")
        cmbstatus_selectedindexchanged(cmbstatus, dgv, "reprint", lblerror, txtboxname, lblsearchap, "btncancel")
    End Sub
    Private Sub cmbstatus2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbstatus2.SelectedIndexChanged
        loadd()
    End Sub

    Private Sub dgv2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv2.CellContentClick
        dgv_contentclick(e, dgv2, "depid", "depname", "depamount", "depdate", "deptype", cmbstatus2, lbldeposit, lblerror2, txtname)
    End Sub

    Private Sub lblcloseremarks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblcloseremarks.Click
        paneldepreason.Visible = False
    End Sub

    Private Sub btnsubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsubmit.Click
        Try
            If checkCutOff() Then
                MessageBox.Show("Your account is already cut off", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf String.IsNullOrEmpty(txtdepreason.Text) Then
                MessageBox.Show("Enter Reason", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                confirm.ShowDialog()
                If cnfrm = False Then
                    Exit Sub
                End If
                con.Open()
                cmd = New SqlCommand("UPDATE tbladvancepayment SET status='Cancelled',date_cancelled=(SELECT GETDATE()),cancelled_by='" & login.username & "',remarks='" & txtdepreason.Text & "' WHERE apnum='" & dgv2.CurrentRow.Cells("depid").Value & "';", con)
                cmd.ExecuteNonQuery()
                con.Close()

                Dim zz As String = getSystemDate.ToString("MM/dd/yyyy")

                con.Open()
                cmd = New SqlCommand("Insert into tbltransaction (ornum, transnum, transdate, cashier, tendertype, servicetype, delcharge, subtotal, disctype, less, vatsales, vat, amtdue, gctotal, tenderamt, change, refund, comment, remarks, customer, tinnum, tablenum, pax, datecreated, datemodified, status,area,invnum,partialamt) values ('" & "0" & "', '" & dgv2.CurrentRow.Cells("depid").Value & "', '" & zz & "','" & login.cashier & "', '" & "Cash Out" & "', '" & "Cash Out" & "', '" & "0" & "', '" & "0" & "', '" & "N/A" & "', '" & "0" & "', '" & "0" & "', '" & "0" & "', '" & dgv2.CurrentRow.Cells("depamount").Value & "', '" & "0" & "', '" & "0" & "', '" & "0" & "', '0', '', '', '" & dgv2.CurrentRow.Cells("depname").Value & "', '" & "0" & "', '" & "0" & "', '" & "0" & "',(SELECT GETDATE()),(SELECT GETDATE()), '1','" & "Sales" & "','" & inv_id & "','0')", con)
                cmd.ExecuteNonQuery()
                con.Close()

                con.Open()
                cmd = New SqlCommand("Insert into tbltransaction2 (ornum, transnum, transdate, cashier, tendertype, servicetype, delcharge, subtotal, disctype, less, vatsales, vat, amtdue, gctotal, tenderamt, change, refund, comment, remarks, customer, tinnum, tablenum, pax, datecreated, datemodified, status,area,status2) values ('" & "0" & "', '" & dgv2.CurrentRow.Cells("depid").Value & "', '" & zz & "','" & login.cashier & "', '" & "Cash Out" & "', '" & "Cash Out" & "', '" & "0" & "', '" & "0" & "', '" & "N/A" & "', '" & "0" & "', '" & "0" & "', '" & "0" & "', '" & dgv2.CurrentRow.Cells("depamount").Value & "', '" & "0" & "', '" & "0" & "', '" & "0" & "', '0', '', '', '" & dgv2.CurrentRow.Cells("depname").Value & "', '" & "0" & "', '" & "0" & "', '" & "0" & "',(SELECT GETDATE()),(SELECT GETDATE()), '1','" & "Sales" & "','Paid')", con)
                cmd.ExecuteNonQuery()
                con.Close()

                MessageBox.Show("Transaction Completed", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'loadData("SELECT * FROM tbladvancepayment WHERE status='" & cmbstatus2.Text & "' AND type='" & lbldeposit.Text & "'", dgv2, lblerror2, txtname)
                paneldepreason.Visible = False
                txtdepreason.Text = ""
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub lblapclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblapclose.Click
        panelapreason.Visible = False
        txtapreason.Text = ""
    End Sub

    Private Sub btnsubmit2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsubmit2.Click
        Try
            'If checkCutOff() Then
            '    MessageBox.Show("Your account is already cut off", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            If String.IsNullOrEmpty(txtapreason.Text) Then
                MessageBox.Show("Enter Reason", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                con.Open()
                cmd = New SqlCommand("UPDATE tbladvancepayment SET status='Cancelled',date_cancelled=(SELECT GETDATE()),cancelled_by='" & login.username & "',remarks='" & txtapreason.Text & "' WHERE apnum='" & dgv.CurrentRow.Cells("apid").Value & "';", con)
                cmd.ExecuteNonQuery()
                con.Close()

                Dim zz As String = getSystemDate.ToString("MM/dd/yyyy")

                con.Open()
                cmd = New SqlCommand("Insert into tbltransaction (ornum, transnum, transdate, cashier, tendertype, servicetype, delcharge, subtotal, disctype, less, vatsales, vat, amtdue, gctotal, tenderamt, change, refund, comment, remarks, customer, tinnum, tablenum, pax, datecreated, datemodified, status,area,invnum,partialamt) values ('" & "0" & "', '" & dgv.CurrentRow.Cells("apid").Value & "', '" & zz & "','" & login.cashier & "', '" & "Cash Out" & "', '" & "Cash Out" & "', '" & "0" & "', '" & "0" & "', '" & "N/A" & "', '" & "0" & "', '" & "0" & "', '" & "0" & "', '" & dgv.CurrentRow.Cells("apamount").Value & "', '" & "0" & "', '" & "0" & "', '" & "0" & "', '0', '', '', '" & dgv.CurrentRow.Cells("apname").Value & "', '" & "0" & "', '" & "0" & "', '" & "0" & "','" & zz & "','" & zz & "', '1','" & "Sales" & "','" & inv_id & "','0')", con)
                cmd.ExecuteNonQuery()
                con.Close()
                MessageBox.Show("Transaction Completed", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                loadData("SELECT * FROM tbladvancepayment WHERE status='" & cmbstatus.Text & "' AND type='" & lblap.Text & "'", dgv, lblerror, txtboxname)
                panelapreason.Visible = False
                txtapreason.Text = ""
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub returnstand_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnreturns.PerformClick()
        loadd()
        If login.wrkgrp = "Manager" Then
            dgvlists.Columns("btnreturn").Visible = False
        End If
        Me.WindowState = FormWindowState.Maximized

        cmbstatus.SelectedIndex = 0

        cmbstatus2.SelectedIndex = 0

        getID()
        loadtransnum()
        If login.wrkgrp = "Manager" Then
            'ap
            Label3.Visible = False
            Label4.Visible = False
            Label6.Visible = False
            txtboxamount.Visible = False
            txtboxname.Visible = False
            lblap.Visible = False
            btnadd.Visible = False
            dgv.Columns("reprint").Visible = False

            'dep
            Label5.Visible = False
            txtname.Visible = False
            Label2.Visible = False
            txtamount.Visible = False
            Label1.Visible = False
            lbldeposit.Visible = False
            btnadd2.Visible = False
            dgv2.Columns("reprint2").Visible = False
        End If
        dtReturn.MaxDate = getSystemDate()
        dtReturn.Value = getSystemDate()
    End Sub
    Public Sub connect()
        If con.State <> ConnectionState.Open Then
            con.Open()
        End If
    End Sub
    Public Sub disconnect()
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
    End Sub
    Public Function apdep() As Double
        Try
            Dim z As Double = 0.00
            connect()
            cmd = New SqlCommand("SELECT DISTINCT tblreturns.returnum, tbladvancepayment.amount,tblitems.itemname,tblitems.itemcode, tbladvancepayment.name, tbladvancepayment.ap_id,tblitems.category, tbladvancepayment.date,tbltransaction.transnum,ISNULL(tblreturns.date,'') AS dd,ISNULL(tblreturns.byy,'') AS byy FROM tblreturns JOIN tbladvancepayment ON tblreturns.ap_id = tbladvancepayment.ap_id JOIN tbltransaction ON tblreturns.transnum = tbltransaction.transnum JOIN tblorder ON tblorder.transnum = tblreturns.transnum JOIN tblitems ON tblorder.itemname = tblitems.itemname WHERE tblitems.deposit='1' AND tbladvancepayment.status='Used' AND tblreturns.status='Active' ORDER BY tblreturns.returnum;", con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                z += 1
            End While
            disconnect()
            Return z
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Function
    Public Function activeAPDEP(ByVal tayp As String) As Double
        Try
            Dim z As Double = 0.00
            con.Open()
            cmd = New SqlCommand("SELECT ap_id  FROM tbladvancepayment WHERE type=@type AND status='Active';", con)
            cmd.Parameters.AddWithValue("@type", tayp)
            rdr = cmd.ExecuteReader
            While rdr.Read
                z += 1
            End While
            con.Close()
            Return z
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Function
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim ap_result As Double = 0.00, dep_result As Double = 0.00, return_result As Double = 0.00
        dep_result += activeAPDEP("Deposit")
        ap_result += activeAPDEP("Advance Payment")
        return_result += apdep()


        If dep_result <> 0 Then
            TabPage3.Text = "Deposit (" & dep_result & ")"
        Else
            TabPage3.Text = "Deposit"
        End If
        If ap_result <> 0 Then
            TabPage2.Text = "Advance Payment (" & ap_result & ")"
        Else
            TabPage2.Text = "Advance Payment"
        End If
        If return_result <> 0 Then
            TabPage1.Text = "Return Item (" & return_result & ")"
        Else
            TabPage1.Text = "Return Item"
        End If
    End Sub

    Private Sub dtReturn_ValueChanged(sender As Object, e As EventArgs) Handles dtReturn.ValueChanged
        Dim status As String = IIf(btnreturns.ForeColor = Color.Black, "Active", "Used")
        Dim status2 As String = IIf(btnhistory.ForeColor = Color.Black, "Active", "Used")
        loadItems(status, status2)
    End Sub

    Private Sub txtname_KeyDown(sender As Object, e As KeyEventArgs) Handles txtname.KeyDown, txtamount.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnadd2.PerformClick()
        End If
    End Sub

    Private Sub txtboxname_KeyDown(sender As Object, e As KeyEventArgs) Handles txtboxname.KeyDown, txtboxamount.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnadd.PerformClick()
        End If
    End Sub

    Private Sub dgv_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellDoubleClick
        If dgv.CurrentRow.Cells("apstatus").Value = "Cancelled" Then
            cancel_apdep.num = dgv.CurrentRow.Cells("apid").Value
            cancel_apdep.ShowDialog()
        End If
    End Sub

    Private Sub dgv2_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv2.CellDoubleClick
        If dgv2.CurrentRow.Cells("depstatus").Value = "Cancelled" Then
            cancel_apdep.num = dgv2.CurrentRow.Cells("depid").Value
            cancel_apdep.ShowDialog()
        End If
    End Sub
End Class