Imports System.Data.SqlClient
Imports System.IO
Imports System.Text
Imports System.Security
Imports System.Security.Cryptography
Public Class advancepayment
    Dim strconn As String = decryptConString()
    Dim con As New SqlConnection(strconn)
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader
    Dim inv_id As String = "", trnum As String = "", apnum As String = ""

    Public Function decryptConString() As String
        Dim passPhrase As String = "minePassPhrase"
        Dim saltValue As String = "mySaltValue"
        Dim hashAlgorithm As String = "SHA1"

        Dim passwordIterations As Integer = 2
        Dim initVector As String = "@1B2c3D4e5F6g7H8"
        Dim keySize As Integer = 256
        Dim initVectorBytes As Byte() = Encoding.ASCII.GetBytes(initVector)
        Dim saltValueBytes As Byte() = Encoding.ASCII.GetBytes(saltValue)

        Dim cipherTextBytes As Byte() = Convert.FromBase64String(System.IO.File.ReadAllText("connectionstring.txt"))

        Dim password As New PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations)

        Dim keyBytes As Byte() = password.GetBytes(keySize \ 8)

        Dim symmetricKey As New RijndaelManaged()
        symmetricKey.Mode = CipherMode.CBC
        Dim decryptor As ICryptoTransform = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes)

        Dim memoryStream As New MemoryStream(cipherTextBytes)
        Dim cryptoStream As New CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read)
        Dim plainTextBytes As Byte() = New Byte(cipherTextBytes.Length - 1) {}
        Dim decryptedByteCount As Integer = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length)
        memoryStream.Close()
        cryptoStream.Close()
        Dim plainText As String = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount)
        Return plainText
    End Function

    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Dim a As String = MsgBox("Are you sure you want to close?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "")
        If a = vbYes Then
            Me.Close()
        End If
    End Sub
    Public Sub getApNum()
        Try
            Dim selectcount_result As Integer = 0
            Dim get_area As String = "", temp As String = "1"
            Dim area_format As String = ""
            con.Open()
            cmd = New SqlCommand("Select COUNT(ap_id) FROM tbladvancepayment WHERE type=@type;", con)
            cmd.Parameters.AddWithValue("@type", cmbtype.Text)
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

            If cmbtype.SelectedIndex = 1 Then
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
    Public Sub loadCustomers()
        Dim auto As New AutoCompleteStringCollection()
        con.Open()
        cmd = New SqlCommand("SELECT name FROM tblcustomers WHERE type != 'Employee';", con)
        rdr = cmd.ExecuteReader
        While rdr.Read
            auto.Add(rdr("name"))
        End While
        con.Close()
        txtboxname.AutoCompleteCustomSource = auto
    End Sub
    Private Sub advancepayment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbstatus.SelectedIndex = 0
        cmbsearchtype.SelectedIndex = 0
        cmbtype.SelectedIndex = 0
        getID()
        loadtransnum()
        If login.wrkgrp = "Manager" Then
            Label3.Visible = False
            Label4.Visible = False
            Label6.Visible = False
            txtboxamount.Visible = False
            txtboxname.Visible = False
            cmbtype.Visible = False
            btnadd.Visible = False
            dgv.Columns("reprint").Visible = False
        End If
    End Sub
    Public Sub loadData(ByVal q As String)
        Dim auto As New AutoCompleteStringCollection()
        dgv.Rows.Clear()
        con.Open()
        cmd = New SqlCommand(q, con)
        rdr = cmd.ExecuteReader()
        While rdr.Read
            Dim d As New DateTime()
            d = CDate(rdr("date"))
            Dim amount As Double = rdr("amount")
            dgv.Rows.Add(rdr("apnum"), rdr("name"), amount.ToString("n2"), d.ToString("MM/dd/yyyy"), rdr("status"), rdr("type"))
            auto.Add(rdr("name"))
        End While
        con.Close()
        txtboxsearch.AutoCompleteCustomSource = auto
        If dgv.Rows.Count = 0 Then
            lblerror.Visible = True
        Else
            lblerror.Visible = False
        End If
        loadCustomers()
    End Sub
    Public Sub getID()
        Dim id As String = ""
        Dim date_ As New DateTime()
        con.Open()
        cmd = New SqlCommand("Select TOP 1 invnum,datecreated from tblinvsum WHERE area='Administrator' order by invsumid DESC", con)
        rdr = cmd.ExecuteReader()
        If rdr.Read() Then
            id = rdr("invnum")
            date_ = CDate(rdr("datecreated"))
        End If
        con.Close()
        If date_.ToString("MM/dd/yyyy") = DateTime.Now.ToString("MM/dd/yyyy") Then
            inv_id = id
        Else
            inv_id = "N/A"
        End If
    End Sub
    Public Sub loadtransnum()
        Dim area As String = ""
        If login.wrkgrp = "Cashier" Or login.wrkgrp = "Sales" Or login.wrkgrp = "Administrator" Then
            area = "Sales"
        Else
            area = login.wrkgrp
        End If
        Dim temp As String = "1", selectcount_result As Integer = 0, area_format As String = ""
        con.Open()
        cmd = New SqlCommand("Select COUNT(*)  from tbltransaction WHERE area='" & area & "'", con)
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
    Private Sub btnadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadd.Click
        Try
            If txtboxname.Text = "" And txtboxamount.Text = "" Then
                MessageBox.Show("Fields is empty", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            ElseIf txtboxname.Text = "" Then
                MessageBox.Show("Name is empty", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            ElseIf txtboxamount.Text = "" Then
                MessageBox.Show("Amount is empty", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            ElseIf txtboxname.Text.Length < 2 Then
                MessageBox.Show("Name is too short", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            ElseIf cmbtype.SelectedIndex = 0 Then
                MessageBox.Show("PLease choose type.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Else
                Dim amount As Double = 0.0
                con.Open()
                cmd = New SqlCommand("SELECT ISNULL(SUM(amount),0) FROM tbladvancepayment WHERE name=@name AND status='Active' AND type='" & cmbtype.Text & "';", con)
                cmd.Parameters.AddWithValue("@name", txtboxname.Text)
                amount = cmd.ExecuteScalar + CDbl(txtboxamount.Text)
                con.Close()

                Dim ap_id As Integer = 0
                con.Open()
                cmd = New SqlCommand("SELECT ap_id FROM tbladvancepayment WHERE name=@neym AND type=@type AND status='Active';", con)
                cmd.Parameters.AddWithValue("@neym", txtboxname.Text)
                cmd.Parameters.AddWithValue("@type", cmbtype.Text)
                rdr = cmd.ExecuteReader
                If rdr.Read Then
                    ap_id = rdr("ap_id")
                End If
                con.Close()
                If ap_id <> 0 Then
                    con.Open()
                    cmd = New SqlCommand("UPDATE tbladvancepayment SET amount=@am WHERE name=@namee AND type=@typee AND status='Active';", con)
                    cmd.Parameters.AddWithValue("@am", amount)
                    cmd.Parameters.AddWithValue("@namee", txtboxname.Text)
                    cmd.Parameters.AddWithValue("@typee", cmbtype.Text)
                    cmd.ExecuteNonQuery()
                    con.Close()
                Else
                    con.Open()
                    cmd = New SqlCommand("INSERT INTO tbladvancepayment (name,amount,date,status,type,apnum) VALUES (@name,@amount,@date,@status,@typeee,@apnum)", con)
                    cmd.Parameters.AddWithValue("@name", txtboxname.Text)
                    cmd.Parameters.AddWithValue("@amount", CDbl(txtboxamount.Text))
                    cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt"))
                    cmd.Parameters.AddWithValue("@status", "Active")
                    cmd.Parameters.AddWithValue("@typeee", cmbtype.Text)
                    cmd.Parameters.AddWithValue("@apnum", apnum)
                    cmd.ExecuteNonQuery()
                    con.Close()
                End If

                Dim tayp As String = If(cmbtype.Text = "Advance Payment", "Advance Payment Cash", "Deposit")

                con.Open()
                cmd = New SqlCommand("Insert into tbltransaction (ornum, transnum, transdate, cashier, tendertype, servicetype, delcharge, subtotal, disctype, less, vatsales, vat, amtdue, gctotal, tenderamt, change, refund, comment, remarks, customer, tinnum, tablenum, pax, datecreated, datemodified, status,area,invnum) values (0,'" & trnum & "','" & DateTime.Now.ToString("MM/dd/yyyy") & "','" & login.cashier & "','" & tayp & "','" & tayp & "','0','0','N/A','0','0','0','" & CDbl(txtboxamount.Text) & "','0','0','0','0','','','','N/A','','1','" & DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt") & "','" & DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt") & "','1','Sales','" & inv_id & "')", con)
                cmd.ExecuteNonQuery()
                con.Close()

                MessageBox.Show("Transaction Completed", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                getApNum()
                loadtransnum()
                loadData("SELECT * FROM tbladvancepayment WHERE status='" & cmbstatus.Text & "'")
                txtboxamount.Text = ""
                txtboxname.Text = ""
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub txtboxamount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtboxamount.TextChanged
        Try
            Dim am As Double = CDbl(txtboxamount.Text)
            txtboxamount.Text = am.ToString("n2")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbstatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbstatus.SelectedIndexChanged
        loadData("SELECT * FROM tbladvancepayment WHERE status='" & cmbstatus.Text & "'")
        If cmbstatus.SelectedIndex = 0 Then
            dgv.Columns("reprint").Visible = True
        ElseIf cmbstatus.SelectedIndex = 1 Then
            dgv.Columns("reprint").Visible = False
        End If
    End Sub

    Private Sub txtboxname_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtboxname.Leave
        txtboxname.Text = StrConv(txtboxname.Text, VbStrConv.ProperCase)
    End Sub

    Private Sub btnsearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsearch.Click
        con.Open()
        cmd = New SqlCommand("SELECT name FROM tbladvancepayment WHERE name=@name", con)
        cmd.Parameters.AddWithValue("@name", txtboxsearch.Text)
        rdr = cmd.ExecuteReader()

        If rdr.Read() Then

            For i As Integer = 0 To dgv.Rows.Count - 1
                If dgv.Rows(i).Cells(0).Value = rdr("name") Then
                    dgv.Rows(i).Selected = True
                    dgv.CurrentCell = dgv.Rows(i).Cells(0)
                Else
                    dgv.Rows(i).Selected = False
                End If
            Next
        End If

        con.Close()
    End Sub

    Private Sub txtboxsearch_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtboxsearch.Leave
        txtboxsearch.Text = StrConv(txtboxsearch.Text, VbStrConv.ProperCase)
    End Sub

    Private Sub dgv_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellContentClick
        If e.ColumnIndex = 6 Then
            Dim cform As New cform_advancepayment()
            cform.Show()
            Dim c As New c_advancepayment()
            c.SetParameterValue("id", dgv.CurrentRow.Cells("id").Value)
            c.SetParameterValue("name", dgv.CurrentRow.Cells("namee").Value)
            c.SetParameterValue("amount", dgv.CurrentRow.Cells("amount").Value)
            c.SetParameterValue("date", dgv.CurrentRow.Cells("datee").Value)
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
            If dgv.CurrentRow.Cells("type").Value = "Advance Payment" Then
                txtType = "ADVANCE PAYMENT SLIP"
            Else
                txtType = "DEPOSIT SLIP"
            End If
            c.SetParameterValue("header", "ATLANTIC BAKERY" & Environment.NewLine & txtType)
            cform.CrystalReportViewer1.ReportSource = c
            cform.CrystalReportViewer1.Refresh()
        End If
    End Sub

    Private Sub cmbsearchtype_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbsearchtype.SelectedIndexChanged
        loadData("SELECT * FROM tbladvancepayment WHERE status='" & cmbstatus.Text & "' AND type='" & cmbsearchtype.Text & "'")
    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click

    End Sub

    Private Sub cmbtype_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbtype.SelectedIndexChanged
        getApNum()
    End Sub
End Class