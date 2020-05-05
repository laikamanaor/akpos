Imports System.Data.SqlClient
Imports System.IO
Imports System.Text
Imports System.Security
Imports System.Security.Cryptography
Imports AK_POS.connection_class
Public Class adddrawer
    Dim cc As New connection_class
    Dim con As New SqlConnection(cc.conString)
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader

    Dim invnum As String = "", creditnum
    Public Shared cnfrm As Boolean = False
    Public Shared cnfrm_cashier As Boolean = False

    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        lblavailable.Text = ""
        txtamount.Text = ""
        cmbcashier.SelectedIndex = -1
        Me.Close()
    End Sub
    Public Sub getCreditsNum()
        Dim temp As String = "0", area_format As String = "", selectcount_result As Integer = 0

        con.Open()
        cmd = New SqlCommand("SELECT COUNT(*) FROM tblcredits;", con)
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

        area_format = "SALDR - " & branchcode & " - "

        If selectcount_result < 1000000 Then
            Dim cselectcount_result As String = CStr(selectcount_result)
            For vv As Integer = 1 To 6 - cselectcount_result.Length
                temp += "0"
            Next
            creditnum = area_format & temp & selectcount_result
        End If
    End Sub
    Private Sub txtamount_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtamount.KeyPress
        If Not Char.IsControl(e.KeyChar) And Not Char.IsDigit(e.KeyChar) And Not e.KeyChar = "." And Not e.KeyChar = "," Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtamount_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtamount.Leave
        Try
            txtamount.Text = CDbl(txtamount.Text).ToString("n2")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnsubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsubmit.Click
        Try
            If String.IsNullOrEmpty(cmbcashier.Text) And String.IsNullOrEmpty(txtamount.Text) Then
                MessageBox.Show("Please fill all fields", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf String.IsNullOrEmpty(cmbcashier.Text) Then
                MessageBox.Show("Please fill cashier fields", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf String.IsNullOrEmpty(txtamount.Text) Then
                MessageBox.Show("Please fill amount fields", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf CDbl(txtamount.Text) = 0 Then
                MessageBox.Show("Please fill amount fields", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf invnum = "N/A" Then
                MessageBox.Show("Create New Inventory first", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'ElseIf lblheader.Text = "CASH OUT" And CDbl(lblavailable.Text) < CDbl(txtamount.Text) Then
                '    MessageBox.Show("Available amount only is " & CDbl(lblavailable.Text).ToString("n2"), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf CDbl(lblavailable.Text) = 0 And lblheader.Text <> "ADD" Then
                MessageBox.Show(cmbcashier.Text & " has 0 balance", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                If lblheader.Text = "ADD" Then
                    confirm.ShowDialog()
                    If cnfrm Then
                        add()
                        cnfrm = False
                    End If
                ElseIf lblheader.Text = "CASH COUNT" Then
                    cnfrm = False
                    cnfrm_cashier = False
                    btnsubmit.Enabled = False
                    cashcount()
                    Me.Close()
                ElseIf lblheader.Text = "CASH OUT" Then
                    panelSAP.Visible = True
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Public Sub cashcount()
        Try

            con.Open()
            cmd = New SqlCommand("INSERT INTO tblcreditslogs (creditnum,systemid,available,amt,datecreated,processedby,type,sapdoc,sap,remarks,description) VALUES (@creditnum,(SELECT tblusers.systemid FROM tblusers WHERE username=@uname),@available,@amt,(SELECT GETDATE()),@processedby,@type,@sapdoc,@sap,@remarks,@description);", con)
            cmd.Parameters.AddWithValue("@creditnum", creditnum)
            cmd.Parameters.AddWithValue("@uname", cmbcashier.Text)
            cmd.Parameters.AddWithValue("@available", CDbl(lblavailable.Text))
            cmd.Parameters.AddWithValue("@amt", CDbl(txtamount.Text))
            cmd.Parameters.AddWithValue("@processedby", login.username)
            cmd.Parameters.AddWithValue("@type", "Cash Count")
            cmd.Parameters.AddWithValue("@sapdoc", "")
            cmd.Parameters.AddWithValue("@sap", "")
            cmd.Parameters.AddWithValue("@remarks", "")

            Dim des As String = ""
            If CDbl(lblavailable.Text) < CDbl(txtamount.Text) Then
                des = "Over"
            ElseIf CDbl(lblavailable.Text) = CDbl(txtamount.Text) Then
                des = ""
            Else
                des = "Short"
            End If

            cmd.Parameters.AddWithValue("@description", des)

            cmd.ExecuteNonQuery()
            con.Close()

            MessageBox.Show("Transaction Completed", "", MessageBoxButtons.OK, MessageBoxIcon.Information)

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
    Public Sub cashout()
        Try
            Dim cashout As Double = 0.00
            con.Open()
            cmd = New SqlCommand("SELECT ISNULL(SUM(cashout),0) FROM tblcredits WHERE systemid=(SELECT systemid FROM tblusers WHERE username=@user) AND status='Active';", con)
            cmd.Parameters.AddWithValue("@user", cmbcashier.Text)
            cashout = cmd.ExecuteScalar
            con.Close()

            cashout += CDbl(txtamount.Text)
            con.Open()
            cmd = New SqlCommand("UPDATE tblcredits SET cashout='" & cashout & "' WHERE systemid=(SELECT systemid FROM tblusers WHERE username='" & cmbcashier.Text & "') AND status='Active';", con)
            cmd.ExecuteNonQuery()
            con.Close()

            con.Open()
            cmd = New SqlCommand("INSERT INTO tblcreditslogs (creditnum,systemid,available,amt,datecreated,processedby,type,sapdoc,sap,remarks,description) VALUES (@creditnum,(SELECT tblusers.systemid FROM tblusers WHERE username=@uname),@available,@amt,(SELECT GETDATE()),@processedby,@type,@sapdoc,@sap,@remarks,@description);", con)
            cmd.Parameters.AddWithValue("@creditnum", creditnum)
            cmd.Parameters.AddWithValue("@uname", cmbcashier.Text)
            cmd.Parameters.AddWithValue("@available", CDbl(lblavailable.Text))
            cmd.Parameters.AddWithValue("@amt", CDbl(txtamount.Text))
            cmd.Parameters.AddWithValue("@processedby", login.username)
            cmd.Parameters.AddWithValue("@type", "Cash Out")
            cmd.Parameters.AddWithValue("@sapdoc", "IP")

            Dim des As String = ""
            If CDbl(lblavailable.Text) < CDbl(txtamount.Text) Then
                des = "Over"
            ElseIf CDbl(lblavailable.Text) = CDbl(txtamount.Text) Then
                des = ""
            Else
                des = ""
            End If

            cmd.Parameters.AddWithValue("@description", des)
            Dim z As String = ""
            If checkfollowup.Checked Then
                z = "To Follow"
            Else
                z = txtboxSAPNo.Text
            End If

            cmd.Parameters.AddWithValue("@sap", z)
            cmd.Parameters.AddWithValue("@remarks", txtboxRemarks.Text)
            cmd.ExecuteNonQuery()
            con.Close()


            con.Open()
            cmd = New SqlCommand("SELECT ISNULL(SUM(cashout),0) FROM tblcredits WHERE systemid=(SELECT systemid FROM tblusers WHERE username=@user2) AND status='Active';", con)
            cmd.Parameters.AddWithValue("@user2", cmbcashier.Text)
            cashout = cmd.ExecuteScalar
            con.Close()

            Dim amtdue As Double = 0.0
            con.Open()
            cmd = New SqlCommand("SELECT ISNULL(SUM(amtdue),0) from tbltransaction WHERE tendertype='Cash' OR tendertype='Advance Payment Cash' or tendertype='A.R Cash' or tendertype='Deposit' AND cashier=@cashier2;", con)
            cmd.Parameters.AddWithValue("@cashier2", cmbcashier.Text)
            amtdue = cmd.ExecuteScalar()
            con.Close()

            con.Open()
            cmd = New SqlCommand("SELECT ISNULL(SUM(amtdue),0) FROM tbltransaction WHERE cashier=@cashier3 AND tendertype='Cash Out';", con)
            cmd.Parameters.AddWithValue("@cashier3", cmbcashier.Text)
            amtdue = amtdue - cmd.ExecuteScalar()
            con.Close()

            If amtdue = cashout Then

                Dim zz As String = getSystemDate.ToString("MM/dd/yyyy")

                con.Open()
                cmd = New SqlCommand("UPDATE tblcredits SET status='In Active' WHERE systemid=(SELECT systemid FROM tblusers WHERE username='" & cmbcashier.Text & "') AND CAST(date as date)='" & zz & "';", con)
                cmd.ExecuteNonQuery()
                con.Close()
            End If

            MessageBox.Show("Transaction Completed", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            panelSAP.Visible = False
            txtboxSAPNo.Text = ""
            txtboxRemarks.Text = ""
            Me.Close()
            lblavailable.Text = ""
            txtamount.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Public Sub add()

        Dim systemid As Integer = 0
        con.Open()
        cmd = New SqlCommand("SELECT systemid FROM tblusers WHERE username=@username", con)
        cmd.Parameters.AddWithValue("@username", cmbcashier.Text)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            systemid = rdr("systemid")
        End If
        con.Close()

        Dim zxc As Boolean = False
        Dim zz As String = getSystemDate.ToString("MM/dd/yyyy")

        con.Open()
        cmd = New SqlCommand("SELECT creditid FROM tblcredits WHERE CAST(date as date)='" & zz & "' AND systemid='" & systemid & "';", con)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            zxc = True
        End If
        con.Close()

        If zxc Then
            MessageBox.Show("You can add lucky money once a day", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        con.Open()
        cmd = New SqlCommand("INSERT INTO tblcredits (creditnum,systemid,amount,date,status,cashout) VALUES (@creditnum,@systemid,@amount,(SELECT GETDATE()),@status,@cashout);", con)
        cmd.Parameters.AddWithValue("@creditnum", creditnum)
        cmd.Parameters.AddWithValue("@systemid", systemid)
        cmd.Parameters.AddWithValue("@amount", CDbl(txtamount.Text))
        cmd.Parameters.AddWithValue("@status", "Active")
        cmd.Parameters.AddWithValue("@cashout", 0)
        cmd.ExecuteNonQuery()
        con.Close()

        con.Open()
        cmd = New SqlCommand("INSERT INTO tblcreditslogs (creditnum,systemid,available,amt,datecreated,processedby,type) VALUES (@creditnum,(SELECT tblusers.systemid FROM tblusers WHERE username=@uname),@available,@amt,(SELECT GETDATE()),@processedby,@type);", con)
        cmd.Parameters.AddWithValue("@creditnum", creditnum)
        cmd.Parameters.AddWithValue("@uname", cmbcashier.Text)
        cmd.Parameters.AddWithValue("@available", CDbl(txtamount.Text))
        cmd.Parameters.AddWithValue("@amt", CDbl(txtamount.Text))
        cmd.Parameters.AddWithValue("@processedby", login.username)
        cmd.Parameters.AddWithValue("@type", "Lucky Money")
        cmd.ExecuteNonQuery()
        con.Close()

        MessageBox.Show("Added", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        getCreditsNum()
        Me.Close()
    End Sub

    Public Function amt(ByVal tendertype As String) As Double
        Try
            Dim result As Double = 0.00
            Dim systemDate As String = getSystemDate.ToString("MM/dd/yyyy")

            con.Open()
            cmd = New SqlCommand("SELECT ISNULL(SUM(amtdue),0) from tbltransaction WHERE cashier=@cashier AND tendertype='" & tendertype & "' AND CAST(datecreated AS date)='" & systemDate & "' AND status=1", con)
            cmd.Parameters.AddWithValue("@cashier", cmbcashier.Text)
            result = cmd.ExecuteScalar()
            con.Close()
            Return result
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Function

    Private Sub cmbcashier_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbcashier.SelectedValueChanged
        If cmbcashier.Text <> "" Or lblheader.Text = "CASH OUT" Or lblheader.Text = "CASH COUNT" Then

            Dim systemDate As String = getSystemDate.ToString("MM/dd/yyyy")

            Dim amtdue As Double = 0.0, result As Double = 0.0, aa As Double = 0.00

            amtdue += amt("Cash")
            amtdue += amt("Advance Payment Cash")
            amtdue += amt("Deposit")
            amtdue += amt("A.R Cash")
            amtdue -= amt("Cash Out")

            Dim serverDate As String = getSystemDate.ToString("MM/dd/yyyy")
            con.Open()
            cmd = New SqlCommand("SELECT ISNULL(SUM(amt),0) FROM tblcreditslogs JOIN tblusers ON tblcreditslogs.systemid=tblusers.systemid WHERE tblusers.username=@username2 AND type='Cash Out' AND CAST(tblcreditslogs.datecreated AS date)=@date;", con)
            cmd.Parameters.AddWithValue("@date", serverDate)
            cmd.Parameters.AddWithValue("username2", cmbcashier.Text)
            aa = cmd.ExecuteScalar()
            con.Close()
            result = amtdue - aa
            If result < 0 Then
                result = 0
            Else
                result = result
            End If
            lblavailable.Text = result.ToString("n2")
        End If
    End Sub

    Private Sub adddrawer_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        txtamount.Text = ""
    End Sub

    Private Sub lblclose_Click(sender As Object, e As EventArgs) Handles lblclose.Click
        panelSAP.Visible = False
    End Sub

    Private Sub checkfollowup_CheckedChanged(sender As Object, e As EventArgs) Handles checkfollowup.CheckedChanged
        If checkfollowup.Checked Then
            txtboxSAPNo.Text = ""
            txtboxSAPNo.Enabled = False
        Else
            txtboxSAPNo.Enabled = True
        End If
    End Sub

    Private Sub btnProceed_Click(sender As Object, e As EventArgs) Handles btnProceed.Click
        If checkfollowup.Checked Then
            If String.IsNullOrEmpty(txtboxRemarks.Text) Then
                MessageBox.Show("Please fill remarks field", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                confirm.ShowDialog()
                If cnfrm Then
                    cashout()
                End If
            End If
        Else
            If String.IsNullOrEmpty(txtboxRemarks.Text) And String.IsNullOrEmpty(txtboxSAPNo.Text) Then
                MessageBox.Show("Please fill remarks field", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf String.IsNullOrEmpty(txtboxSAPNo.Text) Then
                MessageBox.Show("Please fill sap field", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                confirm.ShowDialog()
                If cnfrm Then
                    cashout()
                End If
            End If
        End If
    End Sub

    Private Sub cmbcashier_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbcashier.SelectedIndexChanged

    End Sub

    Private Sub adddrawer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblavailable.Text = "0.00"
        cmbcashier.Items.Clear()
        If lblheader.Text = "ADD" Or login.wrkgrp = "Manager" Then
            con.Open()
            cmd = New SqlCommand("SELECT username  FROM tblusers WHERE workgroup='Cashier' AND status=1;", con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                cmbcashier.Items.Add(rdr("username"))
            End While
            con.Close()
        Else
            If login.wrkgrp <> "Manager" Then
                cmbcashier.Items.Add(login.username)
            End If
        End If
            getCreditsNum()
    End Sub
End Class