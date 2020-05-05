Imports System.Data.SqlClient
Imports System.Text
Imports System.IO
Public Class mdiform
    Dim strconn As String = login.ss
    Dim con As New SqlConnection(strconn)
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader
    Dim adptr As New SqlDataAdapter


    Dim invsum As String = "", invnum As String = ""
    Dim invsum_newformat As String = ""
    Dim lastin As Double, lasttotal As Double, lastpull As Double, lastout As Double, lastend As Double, lastactual As Double, rems As String

    Public Function decryptConString() As String
        Dim base64encoded As String = File.ReadAllText("connectionstring.txt")
        Dim data As Byte() = System.Convert.FromBase64String(base64encoded)
        Return System.Text.ASCIIEncoding.ASCII.GetString(data)
    End Function

    Private Sub mdiform_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim a As String = MsgBox("Are you sure you want to logout?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "")
        If a = vbYes Then
            con.Open()
            cmd = New SqlCommand("INSERT INTO tbllogin (username,login,logout,datelogin) VALUES ('" & login.username & "','" & login.timein & "','" & DateTime.Now.ToString("hh:mm") & "','" & DateTime.Now.ToString("MM/dd/yyyy") & "')", con)
            cmd.ExecuteNonQuery()
            con.Close()
            Me.Dispose()
            login.Show()
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub mdiform_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If login.neym <> "Cashier" Then
            countertool.Visible = False
        End If

        If login.wrkgrp = "Manager" Or login.wrkgrp = "Administrator" Then
            Dim d As New dashboard()
            d.MdiParent = Me
            d.Focus()
            d.Show()
            d.WindowState = FormWindowState.Maximized
        End If
    End Sub

    Private Sub BackupDatabaseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub SalesSummaryReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub MenuStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs)

    End Sub
    Private Sub logouttool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles logouttool.Click
        Dim a As String = MsgBox("Are you sure you want to logout?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "")
        If a = vbYes Then
            con.Open()
            cmd = New SqlCommand("INSERT INTO tbllogin (username,login,logout,datelogin) VALUES ('" & login.username & "','" & login.timein & "','" & DateTime.Now.ToString("hh:mm") & "','" & DateTime.Now.ToString("MM/dd/yyyy") & "')", con)
            cmd.ExecuteNonQuery()
            con.Close()
            login.Show()
            Me.Dispose()
        Else
            Return
        End If
    End Sub

    Private Sub cattool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cattool.Click
        category.MdiParent = Me
        category.Show()
        category.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub itemstool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles itemstool.Click
        items.MdiParent = Me
        items.Show()
        items.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub imagetool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imagetool.Click
        saveimg.MdiParent = Me
        saveimg.Show()
        saveimg.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub invtool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        inv.MdiParent = Me
        inv.Show()
        inv.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub discounttool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles discounttool.Click
        discount.MdiParent = Me
        discount.Show()
        discount.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub ordertool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ordertool.Click
        fake_transaction.MdiParent = Me
        fake_transaction.Show()
        fake_transaction.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub countertool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles countertool.Click
        mainmenu.Show()
        mainmenu.WindowState = FormWindowState.Maximized
        Me.Hide()
    End Sub

    Private Sub usertool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles usertool.Click
        users.MdiParent = Me
        users.Focus()
        users.Show()
        users.WindowState = FormWindowState.Normal
    End Sub

    Private Sub summarytool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles summarytool.Click
        salessum2.MdiParent = Me
        salessum2.Focus()
        salessum2.Show()
        salessum2.WindowState = FormWindowState.Normal
    End Sub

    Private Sub salestool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles salestool.Click
        dailysalesprev.Close()
        dsalesreport.MdiParent = Me
        dsalesreport.Focus()
        dsalesreport.Show()
        dsalesreport.WindowState = FormWindowState.Normal
    End Sub

    Private Sub invreporttool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles invreporttool.Click
        invreport.MdiParent = Me
        invreport.Focus()
        invreport.Show()
        invreport.WindowState = FormWindowState.Normal
    End Sub

    Private Sub backuptool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        backup.MdiParent = Me
        backup.Focus()
        backup.Show()
        backup.WindowState = FormWindowState.Normal
    End Sub

    Private Sub MenuStrip2_ItemAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemEventArgs) Handles MenuStrip2.ItemAdded
        Dim s As String = e.Item.GetType().ToString()
        If (s = "System.Windows.Forms.MdiControlStrip+SystemMenuItem") Then
            e.Item.Visible = False
        End If
    End Sub

    Private Sub SalesTransReportAccountingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesTransReportAccountingToolStripMenuItem.Click
        dsalesreportaccnt.Close()
        dsalesreportaccnt.MdiParent = Me
        dsalesreportaccnt.Focus()
        dsalesreportaccnt.Show()
        dsalesreportaccnt.WindowState = FormWindowState.Normal
    End Sub

    Private Sub BranchesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BranchesToolStripMenuItem.Click
        branch.MdiParent = Me
        branch.Show()
        branch.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub TransferToOtherBranchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransferToOtherBranchToolStripMenuItem.Click
        transferform.MdiParent = Me
        transferform.Show()
        transferform.WindowState = FormWindowState.Maximized
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
            If status = "In Active" And date_from.ToString("MM/dd/yyyy") = DateTime.Now.ToString("MM/dd/yyyy") Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Function
    Private Sub CreateNewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateNewToolStripMenuItem.Click

        If checkCutOff() Then
            MessageBox.Show("Your account is already cut off", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        loadinvnum()
        con.Open()
        cmd = New SqlCommand("Select TOP 1 * from tblinvsum WHERE area='" & login.wrkgrp & "' order by invsumid DESC", con)
        Dim dt As New DataTable()
        adptr.SelectCommand = cmd
        adptr.Fill(dt)
        con.Close()
        If dt.Rows.Count = 0 Then
            createNewInventory()
            Exit Sub
        End If
        For Each row As DataRow In dt.Rows
            If row("verify") = 1 Then
                If row("invdate") = Format(Date.Now, "MM/dd/yyyy") Then
                    MsgBox("Creating new inventory failed! Inventory end for this day.", MsgBoxStyle.Critical, "")
                    Me.Cursor = Cursors.Default
                    Exit Sub
                Else
                    createNewInventory()
                End If
            Else
                MessageBox.Show("Verify first", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Next
    End Sub
    Public Sub createNewInventory()
        Dim a As String = MsgBox("Are you sure you want to create new inventory?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "")
        If a <> vbYes Then
            Me.Cursor = Cursors.Default
            Exit Sub
        End If
        loadinvnum()

        Dim query As String = ""
        If login.wrkgrp = "Production" Then
            query = "Select * from tblitems where discontinued='0' AND Not category='Packaging' AND Not category='Drinks' AND Not category='Meal' AND Not category='Combo' AND NOT category='Noodles'"
        Else
            query = "Select * from tblitems where discontinued='0'"
        End If

        con.Open()
        cmd = New SqlCommand(query, con)
        Dim dt As New DataTable()

        'create column for data table
        dt.Columns.Add("itemid", GetType(Integer))
        dt.Columns.Add("itemcode", GetType(String))
        dt.Columns.Add("itemname", GetType(String))
        dt.Columns.Add("beg", GetType(Double))
        dt.Columns.Add("itemin", GetType(Double))
        dt.Columns.Add("totalquantity", GetType(Double))
        dt.Columns.Add("couterout", GetType(Double))
        dt.Columns.Add("pullout", GetType(Double))
        dt.Columns.Add("endbal", GetType(Double))
        dt.Columns.Add("actualbal", GetType(Double))
        dt.Columns.Add("variance", GetType(Double))
        dt.Columns.Add("short", GetType(String))
        dt.Columns.Add("shortamount", GetType(String))
        dt.Columns.Add("overamount", GetType(String))

        dt.Columns.Add("reject", GetType(Double))
        rdr = cmd.ExecuteReader
        While rdr.Read
            dt.Rows.Add(rdr("itemid"), rdr("itemcode"), rdr("itemname"), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "", "", "0.00")
        End While
        con.Close()
        For Each row As DataRow In dt.Rows
            connect()
            cmd = New SqlCommand("Select TOP 1 * from tblinvitems where itemcode='" & row("itemcode") & "' AND area='" & login.wrkgrp & "' order by invid DESC", con)
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                'MessageBox.Show(rdr("reject") & "/" & rdr("reject_undecided"))
                row("reject") = CDbl(rdr("reject_undecided"))
                ' MessageBox.Show(ireject & " luhhh")
                row("beg") = rdr("actualendbal")
                row("totalquantity") = rdr("actualendbal") + CDbl(rdr("reject_undecided"))
                row("endbal") = rdr("actualendbal")
                row("variance") = 0 - row("endbal")

                'Dim uend As Double = utotal - lastout - CDbl(dgvSelectedItem.Rows(r0w.Index).Cells(5).Value) - CDbl(dgvSelectedItem.Rows(r0w.Index).Cells("reject").Value)
                'Dim uvar As Double = lastactual - uend
                If row("variance") < 0 Then
                    row("short") = "Short"
                ElseIf row(10) > 0 Then
                    row("short") = "Over"
                End If
            End If
            disconnect()
        Next

        Dim hour As String = Format(Date.Now, "HH")
        Dim shift As String
        If Val(hour) < 12 Then
            shift = "AM"
        Else
            shift = "PM"
        End If

        con.Open()
        cmd = New SqlCommand("Insert into tblinvsum (invnum, invdate, cashier, shift, verify, datecreated, datemodified, modifiedby, status,area) values('" & invsum & "', '" & Format(Date.Now, "MM/dd/yyyy") & "', '" & login.cashier & "', '" & shift & "', '0', '" & Date.Now & "', '" & Date.Now & "', '" & login.cashier & "', '1','" & login.wrkgrp & "')", con)
        cmd.ExecuteNonQuery()
        con.Close()

        For Each row As DataRow In dt.Rows
            Dim icode As String = row("itemcode")
            Dim iname As String = row("itemname")
            Dim ibeg As Double = Val(row("beg"))
            Dim iin As Double = Val(row("itemin"))
            Dim itotal As Double = Val(row("totalquantity"))
            Dim iout As Double = Val(row("couterout"))
            Dim ipull As Double = Val(row("pullout"))
            Dim iend As Double = Val(row("endbal"))
            Dim ivar As Double = Val(row("variance"))
            Dim irem As String = row("short")
            Dim ireject As Double = 0.00
            If IsDBNull(row("reject")) Then
                ireject = 0
            Else
                ireject = row("reject")
            End If
            If login.wrkgrp = "Administrator" Then
                Dim innum As String = ""
                con.Open()
                cmd = New SqlCommand("SELECT invnum FROM tblinvsum WHERE verify='0' AND area='Production';", con)
                rdr = cmd.ExecuteReader
                If rdr.Read Then
                    innum = rdr("invnum")
                Else
                End If
                con.Close()

                Dim prdc As Double = 0.0
                con.Open()
                cmd = New SqlCommand("SELECT * FROM tblinvitems WHERE itemcode='" & icode & "' AND itemname='" & iname & "' AND invnum='" & innum & "';", con)
                rdr = cmd.ExecuteReader()
                If rdr.Read Then
                    prdc = rdr("produce")
                End If
                con.Close()

                con.Open()
                cmd = New SqlCommand("Insert into tblinvitems (invnum, itemcode, itemname, begbal,produce,good,reject,charge,productionin, itemin, totalav, ctrout, pullout, endbal, actualendbal, variance, shortover, status,convin,archarge,arsales,convout,transfer,area,arreject,supin,adjustmentin,reject_undecided,reject_convin,reject_convout) values('" & invsum & "', '" & icode & "', '" & iname & "', '" & ibeg & "','" & prdc & "','0','" & ireject & "','0','0','" & iin & "', '" & itotal & "', '" & iout & "', '" & ipull & "', '" & iend & "', '0', '" & ivar & "', '" & irem & "','0','0','0','0','0','0','" & login.wrkgrp & "','0','0','0','0','0','0')", con)
                cmd.ExecuteNonQuery()
                con.Close()
            Else
                con.Open()
                cmd = New SqlCommand("Insert into tblinvitems (invnum, itemcode, itemname, begbal,produce,good,reject,charge,productionin, itemin, totalav, ctrout, pullout, endbal, actualendbal, variance, shortover, status,convin,archarge,arsales,convout,transfer,area,arreject,supin,adjustmentin,reject_undecided,reject_convin,reject_convout) values('" & invsum & "', '" & icode & "', '" & iname & "', '" & ibeg & "','0','0','" & ireject & "','0', '" & iin & "','0', '" & itotal & "', '" & iout & "', '" & ipull & "', '" & iend & "', '0', '" & ivar & "', '" & irem & "', '0','0','0','0','0','0','" & login.wrkgrp & "','0','0','0','0','0','0')", con)
                cmd.ExecuteNonQuery()
                con.Close()
            End If
        Next
        MessageBox.Show("Added", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

    Public Sub loadinvnum()
        Try
            Dim selectcount_result As Integer = 0
            Dim get_area As String = "", temp As String = "1"
            Dim area_format As String = ""
            con.Open()
            cmd = New SqlCommand("Select COUNT(*)  from tblinvsum WHERE area='" & login.wrkgrp & "'", con)
            selectcount_result = cmd.ExecuteScalar() + 1
            con.Close()

            con.Open()
            cmd = New SqlCommand("Select area  from tblinvsum WHERE area='" & login.wrkgrp & "'", con)
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                get_area = rdr("area")
            End If
            con.Close()

            Dim branchcode As String = ""
            con.Open()
            cmd = New SqlCommand("SELECT branchcode FROM tblbranch WHERE main='1';", con)
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                branchcode = rdr("branchcode")
            End If
            con.Close()
            If get_area = "" Then
                If login.wrkgrp = "Administrator" Then
                    area_format = "SAL" & "INV - " & branchcode.ToUpper() & " - "
                ElseIf login.wrkgrp = "Production" Then
                    'area_format = "I." & removeVowels(login.wrkgrp.Substring(0, 4)).ToUpper
                    area_format = "PROD" & "INV - " & branchcode.ToUpper() & " - "
                End If
            Else
                If login.wrkgrp = "Administrator" Then
                    'area_format = "I." & removeVowels("Sales").ToUpper
                    area_format = "SAL" & "INV - " & branchcode.ToUpper() & " - "
                Else
                    'area_format = "I." & removeVowels(login.wrkgrp.Substring(0, 4)).ToUpper
                    area_format = "PROD" & "INV - " & branchcode.ToUpper() & " - "
                End If
            End If
            If selectcount_result < 1000000 Then
                Dim cselectcount_result As String = CStr(selectcount_result)
                For vv As Integer = 1 To 6 - cselectcount_result.Length
                    temp += "0"
                Next
            End If
            invsum = area_format & temp & selectcount_result
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

    Private Sub TransferToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransferToolStripMenuItem.Click
        con.Open()
        cmd = New SqlCommand("Select TOP 1 * from tblinvsum WHERE area='" & login.wrkgrp & "' order by invsumid DESC", con)
        Dim dt As New DataTable()
        adptr.SelectCommand = cmd
        adptr.Fill(dt)
        con.Close()
        For Each row As DataRow In dt.Rows
            If row("verify") = 1 Then
                If row("invdate") = Format(Date.Now, "MM/dd/yyyy") Then
                    MsgBox("Transfer Item failed! Inventory end for this day.", MsgBoxStyle.Critical, "")
                    Me.Cursor = Cursors.Default
                    Exit Sub
                Else
                    transfer.MdiParent = Me
                    transfer.Show()
                    transfer.WindowState = FormWindowState.Maximized
                End If
            Else
                transfer.MdiParent = Me
                transfer.Show()
                transfer.WindowState = FormWindowState.Maximized
            End If
        Next
    End Sub


    Private Sub EndingBalanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EndingBalanceToolStripMenuItem.Click
        If checkCutOff() = False Then
            MessageBox.Show("Cut off first", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        con.Open()
        cmd = New SqlCommand("Select TOP 1 * from tblinvsum WHERE area='" & login.wrkgrp & "' order by invsumid DESC", con)
        Dim dt As New DataTable()
        adptr.SelectCommand = cmd
        adptr.Fill(dt)
        con.Close()
        For Each row As DataRow In dt.Rows
            If row("verify") = 1 Then
                If row("invdate") = Format(Date.Now, "MM/dd/yyyy") Then
                    MsgBox("Update Actual Ending Balance failed! Inventory end for this day.", MsgBoxStyle.Critical, "")
                    Me.Cursor = Cursors.Default
                    Exit Sub
                Else
                    endingbalance.MdiParent = Me
                    endingbalance.Show()
                    endingbalance.WindowState = FormWindowState.Maximized
                End If
            Else
                endingbalance.MdiParent = Me
                endingbalance.Show()
                endingbalance.WindowState = FormWindowState.Maximized
            End If
        Next
    End Sub

    Private Sub InventoryLogsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InventoryLogsToolStripMenuItem.Click
        inv_logs.MdiParent = Me
        inv_logs.manager = login.wrkgrp
        inv_logs.Show()
        inv_logs.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub ManageCustomersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManageCustomersToolStripMenuItem.Click
        addcustomer.MdiParent = Me
        addcustomer.Focus()
        addcustomer.Show()
        addcustomer.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub ConversionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConversionToolStripMenuItem.Click
        con.Open()
        cmd = New SqlCommand("Select TOP 1 * from tblinvsum WHERE area='" & login.wrkgrp & "' order by invsumid DESC", con)
        Dim dt As New DataTable()
        adptr.SelectCommand = cmd
        adptr.Fill(dt)
        con.Close()
        For Each row As DataRow In dt.Rows
            If row("verify") = 1 Then
                If row("invdate") = Format(Date.Now, "MM/dd/yyyy") Then
                    MsgBox("Coversion failed! Inventory end for this day.", MsgBoxStyle.Critical, "")
                    Me.Cursor = Cursors.Default
                    Exit Sub
                Else
                    conversions.MdiParent = Me
                    conversions.Show()
                    conversions.WindowState = FormWindowState.Maximized
                End If
            Else
                conversions.MdiParent = Me
                conversions.Show()
                conversions.WindowState = FormWindowState.Maximized
            End If
        Next
    End Sub

    Private Sub LakuToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LakuToolStripMenuItem.Click
        lakulaku.MdiParent = Me
        lakulaku.Focus()
        lakulaku.Show()
        lakulaku.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub ConversionLogsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConversionLogsToolStripMenuItem.Click
        conv_logs.MdiParent = Me
        If login.wrkgrp = "Production" Then
            conv_logs.manager = "Production"
        Else
            conv_logs.manager = "Sales"
        End If
        conv_logs.Focus()
        conv_logs.Show()
        conv_logs.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub VersionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VersionToolStripMenuItem.Click
        version.MdiParent = Me
        version.Focus()
        version.Show()
        version.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub ProductionToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductionToolStripMenuItem1.Click
        MessageBox.Show("qwe")
        con.Open()
        cmd = New SqlCommand("Select TOP 1 * from tblinvsum WHERE area='" & login.wrkgrp & "' order by invsumid DESC", con)
        Dim dt As New DataTable()
        adptr.SelectCommand = cmd
        adptr.Fill(dt)
        con.Close()
        For Each row As DataRow In dt.Rows
            If row("verify") = 1 Then
                If row("invdate") = Format(Date.Now, "MM/dd/yyyy") Then
                    MsgBox("Received Item failed! Inventory end for this day.", MsgBoxStyle.Critical, "")
                    Me.Cursor = Cursors.Default
                    Exit Sub
                Else
                    received_item.MdiParent = Me
                    received_item.lcacc = "Production"
                    received_item.Show()
                    received_item.WindowState = FormWindowState.Maximized
                End If
            Else
                received_item.MdiParent = Me
                received_item.lcacc = "Production"
                received_item.Show()
                received_item.WindowState = FormWindowState.Maximized
            End If
        Next
    End Sub
    Private Sub PendingOrderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PendingOrderToolStripMenuItem.Click
        cashier.MdiParent = Me
        cashier.Show()
        cashier.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub POSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles POSToolStripMenuItem.Click

        If checkCutOff() Then
            MessageBox.Show("Your account is already cut off", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        con.Open()
        cmd = New SqlCommand("Select TOP 1 * from tblinvsum WHERE area='" & login.wrkgrp & "' order by invsumid DESC", con)
        Dim dt As New DataTable()
        adptr.SelectCommand = cmd
        adptr.Fill(dt)
        con.Close()
        For Each row As DataRow In dt.Rows
            If row("verify") = 1 Then
                If row("invdate") = Format(Date.Now, "MM/dd/yyyy") Then
                    MsgBox("POS failed! Inventory end for this day.", MsgBoxStyle.Critical, "")
                    Me.Cursor = Cursors.Default
                    Exit Sub
                Else
                    mainmenu.MdiParent = Me
                    mainmenu.cas = "Sales"
                    mainmenu.Show()
                    mainmenu.WindowState = FormWindowState.Maximized
                End If
            Else
                mainmenu.MdiParent = Me
                mainmenu.cas = "Sales"
                mainmenu.Show()
                mainmenu.WindowState = FormWindowState.Maximized
            End If
        Next
    End Sub

    Private Sub LoginLogsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoginLogsToolStripMenuItem.Click
        Dim log As New loginlogs()
        log.ShowDialog()
    End Sub

    Private Sub AdvancePaymentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdvancePaymentToolStripMenuItem.Click
        Dim ad As New advancepayment()
        ad.ShowDialog()
    End Sub

    Private Sub InventoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InventoryToolStripMenuItem.Click
        inv.MdiParent = Me
        inv.manager = login.wrkgrp
        inv.Show()
        inv.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub ARChargeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ARChargeToolStripMenuItem.Click

        ars.MdiParent = Me
        ars.tayp = "AR Charge"
        If ars.tayp = "AR Charge" Then
            ars.Text = "A.R Charge"
            ars.GroupBox1.Visible = False
            ars.btnunpaid.ForeColor = Color.White
            ars.lcacc = login.wrkgrp
            ars.dgvArs2.Rows.Clear()
            ars.btnpaid.ForeColor = Color.Black
            ars.btnSubmit.Visible = False
            ars.dgvARS.Columns("action").Visible = False
            ars.Panel1.Visible = False
            ars.lblSAPNo.Text = ""
            ars.lblRemarks.Text = ""
            ars.btnpaid.Text = "PAID A.R"
            ars.btnpaid.PerformClick()

            If login.wrkgrp = "LC Accounting" Then
                ars.btneditar.Visible = True
            Else
                ars.btneditar.Visible = False
            End If

        End If
        If login.wrkgrp = "Manager" Then
            ars.btnpaid.ForeColor = Color.Black
            ars.dgvARS.Columns("action").Visible = False
            ars.btnSubmit.Visible = False
            ars.GroupBox1.Visible = False
        End If
        ars.Focus()
        ars.Show()
        ars.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub ARSalesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ARSalesToolStripMenuItem.Click
        ars.MdiParent = Me
        ars.tayp = "AR Sales"
        If ars.tayp = "AR Sales" Then
            ars.Text = "A.R Sales"
            ars.lcacc = login.wrkgrp
            ars.GroupBox1.Visible = True
            ars.PanelSAP.Visible = False
            ars.txtboxRemarks.Text = ""
            ars.txtboxSAPNo.Text = ""
            ars.btnunpaid.Visible = True
            ars.btnpaid.Text = "PAID A.R"
            ars.loadars1("Unpaid", "AR Sales")
            ars.btnunpaid.ForeColor = Color.Black
            ars.btnpaid.ForeColor = Color.White
            ars.dgvArs2.Rows.Clear()
            ars.dgvARS.Columns("action").Visible = False
            ars.Panel1.Visible = False
            ars.lblSAPNo.Text = ""
            ars.lblRemarks.Text = ""
            ars.btnSubmit.Visible = True
        End If
        If login.wrkgrp = "Manager" Then
            ars.btnpaid.ForeColor = Color.Black
            ars.dgvARS.Columns("action").Visible = False
            ars.btnSubmit.Visible = False
            ars.GroupBox1.Visible = False
        End If
        ars.btneditar.Visible = False
        ars.Focus()
        ars.Show()
        ars.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub LocalSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LocalSToolStripMenuItem.Click
        con.Open()
        cmd = New SqlCommand("Select TOP 1 * from tblinvsum WHERE area='" & login.wrkgrp & "' order by invsumid DESC", con)
        Dim dt As New DataTable()
        adptr.SelectCommand = cmd
        adptr.Fill(dt)
        con.Close()
        For Each row As DataRow In dt.Rows
            If row("verify") = 1 Then
                If row("invdate") = Format(Date.Now, "MM/dd/yyyy") Then
                    MsgBox("Received Item failed! Inventory end for this day.", MsgBoxStyle.Critical, "")
                    Me.Cursor = Cursors.Default
                    Exit Sub
                Else
                    localreceived.MdiParent = Me
                    localreceived.Show()
                    localreceived.WindowState = FormWindowState.Maximized
                End If
            Else
                localreceived.MdiParent = Me
                localreceived.Show()
                localreceived.WindowState = FormWindowState.Maximized
            End If
        Next
    End Sub

    Private Sub BranchesToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BranchesToolStripMenuItem1.Click
        con.Open()
        cmd = New SqlCommand("Select TOP 1 * from tblinvsum WHERE area='" & login.wrkgrp & "' order by invsumid DESC", con)
        Dim dt As New DataTable()
        adptr.SelectCommand = cmd
        adptr.Fill(dt)
        con.Close()
        For Each row As DataRow In dt.Rows
            If row("verify") = 1 Then
                If row("invdate") = Format(Date.Now, "MM/dd/yyyy") Then
                    MsgBox("Received Item failed! Inventory end for this day.", MsgBoxStyle.Critical, "")
                    Me.Cursor = Cursors.Default
                    Exit Sub
                Else
                    received_item.MdiParent = Me
                    received_item.Text = "Received from Other Branch"
                    received_item.received_type = "Branch"
                    received_item.dgvSelectedItem.Rows.Clear()
                    received_item.lcacc = login.wrkgrp
                    received_item.type = ""
                    received_item.load_cb()
                    received_item.GetTransID()
                    received_item.loadz()
                    received_item.Show()
                    received_item.WindowState = FormWindowState.Maximized
                End If
            Else
                received_item.MdiParent = Me
                received_item.received_type = "Branch"
                received_item.Text = "Received from Other Branch"
                received_item.lcacc = login.wrkgrp
                received_item.dgvSelectedItem.Rows.Clear()
                received_item.type = ""
                received_item.GetTransID()
                received_item.load_cb()
                received_item.loadz()
                received_item.Show()
                received_item.WindowState = FormWindowState.Maximized
            End If
        Next
    End Sub

    Private Sub ARRejectToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ARRejectToolStripMenuItem.Click
        ars.MdiParent = Me
        ars.tayp = "AR Reject"
        If ars.tayp = "AR Reject" Then
            ars.Text = "A.R Reject"
            ars.lcacc = login.wrkgrp
            ars.GroupBox1.Visible = False
            ars.dgvArs2.Rows.Clear()
            ars.btnunpaid.ForeColor = Color.Wheat
            ars.btnpaid.ForeColor = Color.Black
            ars.btnSubmit.Visible = False
            ars.dgvARS.Columns("action").Visible = False
            ars.dgvARS.Columns("action").ReadOnly = True
            ars.Panel1.Visible = False
            ars.lblSAPNo.Text = ""
            ars.lblRemarks.Text = ""
            ars.loadars1("Paid", "AR Reject")
            ars.btnpaid.Text = "Reject History"
        End If
        If login.wrkgrp = "Manager" Then
            ars.btnpaid.ForeColor = Color.Black
            ars.dgvARS.Columns("action").Visible = False
            ars.btnSubmit.Visible = False
            ars.GroupBox1.Visible = False
        End If
        ars.btneditar.Visible = False
        ars.Focus()
        ars.Show()
        ars.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub FromDirectSupplierToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FromDirectSupplierToolStripMenuItem.Click
        con.Open()
        cmd = New SqlCommand("Select TOP 1 * from tblinvsum WHERE area='" & login.wrkgrp & "' order by invsumid DESC", con)
        Dim dt As New DataTable()
        adptr.SelectCommand = cmd
        adptr.Fill(dt)
        con.Close()
        For Each row As DataRow In dt.Rows
            If row("verify") = 1 Then
                If row("invdate") = Format(Date.Now, "MM/dd/yyyy") Then
                    MsgBox("Received Item failed! Inventory end for this day.", MsgBoxStyle.Critical, "")
                    Me.Cursor = Cursors.Default
                    Exit Sub
                Else
                    received_item.MdiParent = Me
                    received_item.received_type = "Direct"
                    received_item.type = "Direct"
                    received_item.Text = "Received from Direct Supplier"
                    received_item.lcacc = login.wrkgrp
                    received_item.load_cb()
                    received_item.GetTransID()
                    received_item.dgvSelectedItem.Rows.Clear()
                    received_item.loadz()
                    received_item.Show()
                    received_item.WindowState = FormWindowState.Maximized
                End If
            Else
                received_item.MdiParent = Me
                received_item.received_type = "Direct"
                received_item.Text = "Received from Direct Supplier"
                received_item.type = "Direct"
                received_item.lcacc = login.wrkgrp
                received_item.GetTransID()
                received_item.load_cb()
                received_item.dgvSelectedItem.Rows.Clear()
                received_item.loadz()
                received_item.Show()
                received_item.WindowState = FormWindowState.Maximized
            End If
        Next
    End Sub
    Private Sub ReturnItemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReturnItemToolStripMenuItem.Click
        returnstand.MdiParent = Me
        If login.wrkgrp = "Manager" Then
            returnstand.dgvlists.Columns("btnreturn").Visible = False
        End If
        returnstand.Show()
        returnstand.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub CreditsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreditsToolStripMenuItem.Click
        drawerr.MdiParent = Me
        If login.wrkgrp = "Manager" Then
            drawerr.manager = "Manager"
        Else
            drawerr.manager = login.wrkgrp
        End If
        drawerr.Show()
        drawerr.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub PendingSAPToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PendingSAPToolStripMenuItem.Click
        pendingsap.MdiParent = Me
        pendingsap.manager = login.wrkgrp
        pendingsap.Show()
        pendingsap.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub mdiform_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        If login.wrkgrp = "Administrator" Then
            PendingOrderToolStripMenuItem.Visible = False
            AdvancePaymentToolStripMenuItem.Visible = False
            BranchesToolStripMenuItem1.Text = "From Branch"
            ARToolStripMenuItem.Visible = True
            ARSalesToolStripMenuItem.Visible = False
            CreditsToolStripMenuItem.Visible = True
            ProduceItemToolStripMenuItem.Visible = False
            ReprintOrderToolStripMenuItem.Visible = True
            CreditsToolStripMenuItem.Visible = False
        ElseIf login.wrkgrp = "Cashier" Then
            ToolStripMenuItem3.Visible = False
            ToolStripMenuItem12.Visible = False
            ToolStripMenuItem14.Visible = False
            requesttool.Visible = False
            InventoryTransactionToolStripMenuItem.Visible = True
            CreateNewToolStripMenuItem.Visible = False
            ReceivedItemToolStripMenuItem.Visible = False
            TransferToolStripMenuItem.Visible = False
            ConversionToolStripMenuItem.Visible = False
            EndingBalanceToolStripMenuItem.Visible = False
            PendingSAPToolStripMenuItem.Visible = False
            InventoryToolStripMenuItem.Visible = False
            ARRejectToolStripMenuItem.Visible = False
            ARChargeToolStripMenuItem.Visible = False
            AdministratorToolStripMenuItem.Visible = False
            POSToolStripMenuItem.Visible = False
            ReturnItemToolStripMenuItem.Visible = True
            ARCashToolStripMenuItem.Visible = False
            ProduceItemToolStripMenuItem.Visible = False
            BranchesToolStripMenuItem.Visible = False
            discounttool.Visible = False
            CreditsToolStripMenuItem.Visible = True
        ElseIf login.wrkgrp = "Sales" Then
            ToolStripMenuItem3.Visible = False
            ToolStripMenuItem8.Visible = False
            ToolStripMenuItem12.Visible = False
            ToolStripMenuItem14.Visible = False
            requesttool.Visible = False
            InventoryTransactionToolStripMenuItem.Visible = False
            AdministratorToolStripMenuItem.Visible = False
            PendingOrderToolStripMenuItem.Visible = False
            AdvancePaymentToolStripMenuItem.Visible = False
            ProduceItemToolStripMenuItem.Visible = False
            ReprintOrderToolStripMenuItem.Visible = True
            CreditsToolStripMenuItem.Visible = False
        ElseIf login.wrkgrp = "Production" Then
            ReceivedItemToolStripMenuItem.Visible = False
            ToolStripMenuItem8.Visible = False
            ToolStripMenuItem12.Visible = False
            requesttool.Visible = False
            summarytool.Visible = False
            salestool.Visible = False
            invreporttool.Visible = False
            SalesTransReportAccountingToolStripMenuItem.Visible = False
            InventoryTransactionToolStripMenuItem.Visible = True
            AdministratorToolStripMenuItem.Visible = False
            PendingOrderToolStripMenuItem.Visible = False
            POSToolStripMenuItem.Visible = False
            AdvancePaymentToolStripMenuItem.Visible = False
            ARToolStripMenuItem.Visible = True
            ARSalesToolStripMenuItem.Visible = False
            ARCashToolStripMenuItem.Visible = False
            SalesSummaryReportToolStripMenuItem.Visible = False
            requesttool.Visible = True
            CreditsToolStripMenuItem.Visible = False
            RejectsToolStripMenuItem.Visible = True
        ElseIf login.wrkgrp = "Manager" Then
            CreateNewToolStripMenuItem.Visible = False
            usertool.Visible = False
            requesttool.Visible = False
            ReceivedItemToolStripMenuItem.Visible = False
            TransferToolStripMenuItem.Visible = False
            ConversionToolStripMenuItem.Visible = False
            EndingBalanceToolStripMenuItem.Visible = False
            AdministratorToolStripMenuItem.Visible = False
            PendingOrderToolStripMenuItem.Visible = False
            POSToolStripMenuItem.Visible = False
            InventoryToolStripMenuItem.Visible = False
            InventoryToolStripMenuItem1.Visible = True
            ConversionLogsToolStripMenuItem1.Visible = True
            ConversionLogsToolStripMenuItem.Visible = False
            InventoryLogsToolStripMenuItem.Visible = False
            InventoryLogsToolStripMenuItem1.Visible = True
            ReturnItemToolStripMenuItem.Visible = True
            CreditsToolStripMenuItem.Visible = True
            ProduceItemToolStripMenuItem.Visible = False
            PendingSAPToolStripMenuItem.Visible = False
            PendingSAPToolStripMenuItem1.Visible = True
            ManageCutOffToolStripMenuItem.Visible = True
        ElseIf login.wrkgrp = "LC Accounting" Then
            ToolStripMenuItem3.Visible = False
            ToolStripMenuItem8.Visible = False
            ToolStripMenuItem12.Visible = False

            SalesSummaryReportToolStripMenuItem.Visible = False
            InventoryLogsToolStripMenuItem.Visible = False
            ConversionLogsToolStripMenuItem.Visible = False
            InventoryLogsToolStripMenuItem1.Visible = True
            ConversionLogsToolStripMenuItem1.Visible = True

            AdministratorToolStripMenuItem.Visible = False
            PendingOrderToolStripMenuItem.Visible = False
            POSToolStripMenuItem.Visible = False
            PendingSAPToolStripMenuItem.Visible = False
            PendingSAPToolStripMenuItem1.Visible = True
            CreateNewToolStripMenuItem.Visible = False

            ProduceItemToolStripMenuItem.Visible = False
            TransferToolStripMenuItem.Visible = False
            ConversionToolStripMenuItem.Visible = False

            ReceivedItemToolStripMenuItem.Visible = False
            AdjustmentInToolStripMenuItem.Visible = True

            ARChargeToolStripMenuItem.Visible = True
            ARCashToolStripMenuItem.Visible = False
            ARSalesToolStripMenuItem.Visible = False
            ARRejectToolStripMenuItem.Visible = False
            ARChargeToolStripMenuItem.Visible = False
            InventoryToolStripMenuItem.Visible = False
            InventoryToolStripMenuItem1.Visible = True
            EndingBalanceToolStripMenuItem.Visible = False
            PullOutToolStripMenuItem.Visible = True
            lc_archarge.Visible = True

            RequestLetterToolStripMenuItem.Visible = False
        End If
        If login.wrkgrp = "Administrator" Then
            Me.Text = "Atlantic Bakery (Sales) "
        Else
            Me.Text = "Atlantic Bakery (" & login.wrkgrp & ") "
        End If
    End Sub
    Private Sub ProductionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductionToolStripMenuItem.Click
        inv.MdiParent = Me
        inv.manager = "Production"
        inv.viewlast()
        If inv.manager <> "Administrator" Then
            inv.btnverify.Enabled = False
            inv.btnbegbal.Enabled = False
            inv.btnrems.Enabled = False
        End If
        If login.wrkgrp = "LC Accounting" Then
            inv.btnverify.Enabled = False
            inv.btnbegbal.Visible = False
        Else
            inv.btnbegbal.Visible = False
            inv.btnverify.Enabled = False
        End If
        inv.Show()
        inv.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub SalesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesToolStripMenuItem.Click
        inv.MdiParent = Me
        inv.manager = "Administrator"
        inv.viewlast()
        If login.wrkgrp = "Manager" Then
            inv.btnverify.Enabled = False
            inv.btnbegbal.Enabled = False
            inv.btnrems.Enabled = False
        End If
        If login.wrkgrp = "LC Accounting" Then
            inv.btnverify.Enabled = False
            inv.btnbegbal.Visible = False
        Else
            inv.btnbegbal.Visible = False
            inv.btnverify.Enabled = False
        End If
        inv.Show()
        inv.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub ProductionToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductionToolStripMenuItem2.Click
        conv_logs.MdiParent = Me
        conv_logs.manager = "Production"
        conv_logs.Focus()
        conv_logs.Show()
        conv_logs.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub SalesToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesToolStripMenuItem1.Click
        conv_logs.MdiParent = Me
        conv_logs.manager = "Sales"
        conv_logs.Focus()
        conv_logs.Show()
        conv_logs.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub ProductionToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductionToolStripMenuItem3.Click
        inv_logs.MdiParent = Me
        inv_logs.manager = "Production"
        inv_logs.Show()
        inv_logs.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub SalesSummaryReportToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles SalesSummaryReportToolStripMenuItem.Click
        Dim d As New dashboard()
        d.MdiParent = Me
        d.Focus()
        d.Show()
        d.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub SalesToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesToolStripMenuItem2.Click
        inv_logs.MdiParent = Me
        inv_logs.manager = "Administrator"
        inv_logs.Show()
        inv_logs.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub ProduceItemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProduceItemToolStripMenuItem.Click
        con.Open()
        cmd = New SqlCommand("Select TOP 1 * from tblinvsum WHERE area='" & login.wrkgrp & "' order by invsumid DESC", con)
        Dim dt As New DataTable()
        adptr.SelectCommand = cmd
        adptr.Fill(dt)
        con.Close()
        For Each row As DataRow In dt.Rows
            If row("verify") = 1 Then
                If row("invdate") = Format(Date.Now, "MM/dd/yyyy") Then
                    MsgBox("Received Item failed! Inventory end for this day.", MsgBoxStyle.Critical, "")
                    Me.Cursor = Cursors.Default
                    Exit Sub
                Else
                    received_item.MdiParent = Me
                    received_item.dgvSelectedItem.Rows.Clear()
                    received_item.lcacc = "Production"
                    received_item.received_type = "Produce"
                    received_item.Text = "Produce Item"
                    received_item.load_cb()
                    received_item.cmbranches.Visible = False
                    received_item.GetTransID()
                    received_item.Show()
                    received_item.WindowState = FormWindowState.Maximized
                End If
            Else
                received_item.MdiParent = Me
                received_item.dgvSelectedItem.Rows.Clear()
                received_item.lcacc = "Production"
                received_item.received_type = "Produce"
                received_item.Text = "Produce Item"
                received_item.load_cb()
                received_item.GetTransID()
                received_item.cmbranches.Visible = False
                received_item.Show()
                received_item.WindowState = FormWindowState.Maximized
            End If
        Next
    End Sub

    Private Sub BackUpDatabaseToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BackUpDatabaseToolStripMenuItem.Click
        backup.MdiParent = Me
        backup.Focus()
        backup.Show()
        backup.WindowState = FormWindowState.Normal
    End Sub

    Private Sub ARCashToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ARCashToolStripMenuItem.Click
        ars.MdiParent = Me
        ars.tayp = "AR Cash"
        If ars.tayp = "AR Cash" Then
            ars.lcacc = login.wrkgrp
            ars.Text = "A.R Cash"
            ars.GroupBox1.Visible = False
            ars.btnunpaid.ForeColor = Color.White
            ars.dgvArs2.Rows.Clear()
            ars.btnpaid.ForeColor = Color.Black
            ars.btnSubmit.Visible = False
            ars.dgvARS.Columns("arnum").Visible = False
            ars.dgvARS.Columns("action").Visible = False
            ars.Panel1.Visible = False
            ars.lblSAPNo.Text = ""
            ars.lblRemarks.Text = ""
            ars.btnpaid.Text = "PAID A.R"
            ars.btnpaid.PerformClick()
        End If
        If login.wrkgrp = "Manager" Then
            ars.btnpaid.ForeColor = Color.Black
            ars.dgvARS.Columns("arnum").Visible = False
            ars.dgvARS.Columns("action").Visible = False
            ars.btnSubmit.Visible = False
            ars.GroupBox1.Visible = False
        End If
        ars.btneditar.Visible = False
        ars.Focus()
        ars.Show()
        ars.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub ReprintOrderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReprintOrderToolStripMenuItem.Click
        reprintorder.MdiParent = Me
        reprintorder.Focus()
        reprintorder.Show()
        reprintorder.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub OrderTransactionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        fake_transaction.MdiParent = Me
        fake_transaction.Focus()
        fake_transaction.Show()
        fake_transaction.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub messages_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles notif.Click

        Try

            connect()
            Dim count As Integer = 0
            cmd = New SqlCommand("select dateseen,messageid from tblmessages WHERE toid=(SELECT systemid FROM tblusers WHERE username='" & login.username & "')", con)
            adptr.SelectCommand = cmd
            Dim dt As New DataTable()
            adptr.Fill(dt)
            disconnect()

            For Each r0w As DataRow In dt.Rows
                If IsDBNull(r0w("dateseen")) Then
                    connect()
                    cmd = New SqlCommand("UPDATE tblmessages SET dateseen=@dateseen WHERE toid=(SELECT systemid FROM tblusers WHERE username='" & login.username & "') AND messageid=@id", con)
                    cmd.Parameters.AddWithValue("@dateseen", DateTime.Now)
                    cmd.Parameters.AddWithValue("@id", r0w("messageid"))
                    cmd.ExecuteNonQuery()
                    disconnect()
                End If
            Next


            Dim d As New newsfeed()
            d.manager = login.wrkgrp
            d.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub


    Public Sub loadNotifMessages()
        Try
            If login.wrkgrp = "Manager" Then
            Else
                Dim count As Integer = 0
                connect()
                cmd = New SqlCommand("select dateseen from tblmessages WHERE toid=(SELECT systemid FROM tblusers WHERE username='" & login.username & "')", con)
                rdr = cmd.ExecuteReader
                While rdr.Read
                    If IsDBNull(rdr("dateseen")) Then
                        count += 1
                    End If
                End While
                disconnect()
                If count <> 0 Then
                    notif.Font = New Font("Segoe UI", 9, FontStyle.Bold)
                    notif.Text = "Messages (" & count & ")"
                Else
                    notif.Font = New Font("Segoe UI", 9, FontStyle.Regular)
                    notif.Text = "Messages"
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Private Sub RequestLetterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RequestLetterToolStripMenuItem.Click
        Dim f As New request()
        f.ShowDialog()
    End Sub

    Private Sub PendingRequetsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PendingRequetsToolStripMenuItem.Click

        Try
            If login.wrkgrp = "LC Accounting" Then
                connect()
                cmd = New SqlCommand("UPDATE tblrequests SET dateseen='" & DateTime.Now & "' WHERE status='Pending';", con)
                cmd.ExecuteNonQuery()
                disconnect()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

        Dim f As New pendingrequests()
        f.ShowDialog()
    End Sub

    Private Sub SalesToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles SalesToolStripMenuItem3.Click
        pendingsap.MdiParent = Me
        pendingsap.manager = "Administrator"
        pendingsap.loadTypes()
        pendingsap.dgvlists.Rows.Clear()
        pendingsap.dgvitems.Rows.Clear()
        pendingsap.lblcount1.Text = "0"
        pendingsap.lblcount2.Text = "0"
        pendingsap.PanelSAP.Visible = False
        pendingsap.txtboxSAPNo.Text = ""
        pendingsap.txtboxRemarks.Text = ""
        pendingsap.Show()
        pendingsap.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub ProductionToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ProductionToolStripMenuItem4.Click
        pendingsap.MdiParent = Me
        pendingsap.manager = "Production"
        pendingsap.loadTypes()
        pendingsap.dgvlists.Rows.Clear()
        pendingsap.dgvitems.Rows.Clear()
        pendingsap.lblcount1.Text = "0"
        pendingsap.lblcount2.Text = "0"
        pendingsap.PanelSAP.Visible = False
        pendingsap.txtboxSAPNo.Text = ""
        pendingsap.txtboxRemarks.Text = ""
        pendingsap.Show()
        pendingsap.WindowState = FormWindowState.Maximized
    End Sub

    Public Sub connect()
        If con.State <> ConnectionState.Open Then
            con.Open()
        End If
    End Sub


    Private Sub ProductionToolStripMenuItem6_Click(sender As Object, e As EventArgs) Handles ProductionToolStripMenuItem6.Click
        ars.MdiParent = Me
        ars.tayp = "AR Charge"
        If ars.tayp = "AR Charge" Then
            ars.Text = "A.R Charge"
            ars.GroupBox1.Visible = False
            ars.btnunpaid.ForeColor = Color.White
            ars.lcacc = "Production"
            ars.dgvArs2.Rows.Clear()
            ars.btnpaid.ForeColor = Color.Black
            ars.btnSubmit.Visible = False
            ars.dgvARS.Columns("action").Visible = False
            ars.Panel1.Visible = False
            ars.lblSAPNo.Text = ""
            ars.lblRemarks.Text = ""
            ars.btnpaid.Text = "PAID A.R"
            ars.btnpaid.PerformClick()

            If login.wrkgrp = "LC Accounting" Then
                ars.btneditar.Visible = True
            Else
                ars.btneditar.Visible = False
            End If

        End If
        If login.wrkgrp = "Manager" Then
            ars.btnpaid.ForeColor = Color.Black
            ars.dgvARS.Columns("action").Visible = False
            ars.btnSubmit.Visible = False
            ars.GroupBox1.Visible = False
        End If
        ars.Focus()
        ars.Show()
        ars.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub SalesToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles SalesToolStripMenuItem5.Click
        ars.MdiParent = Me
        ars.tayp = "AR Charge"
        If ars.tayp = "AR Charge" Then
            ars.Text = "A.R Charge"
            ars.GroupBox1.Visible = False
            ars.btnunpaid.ForeColor = Color.White
            ars.lcacc = "Sales"
            ars.dgvArs2.Rows.Clear()
            ars.btnpaid.ForeColor = Color.Black
            ars.btnSubmit.Visible = False
            ars.dgvARS.Columns("action").Visible = False
            ars.Panel1.Visible = False
            ars.lblSAPNo.Text = ""
            ars.lblRemarks.Text = ""
            ars.btnpaid.Text = "PAID A.R"
            ars.btnpaid.PerformClick()

            If login.wrkgrp = "LC Accounting" Then
                ars.btneditar.Visible = True
            Else
                ars.btneditar.Visible = False
            End If

        End If
        If login.wrkgrp = "Manager" Then
            ars.btnpaid.ForeColor = Color.Black
            ars.dgvARS.Columns("action").Visible = False
            ars.btnSubmit.Visible = False
            ars.GroupBox1.Visible = False
        End If
        ars.Focus()
        ars.Show()
        ars.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub ManageCutOffToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ManageCutOffToolStripMenuItem.Click
        Dim c As New cutoff()
        c.ShowDialog()
    End Sub

    Public Sub disconnect()
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
    End Sub
    Public Function countPendings(ByVal transnum As String, typee As String, ByVal db As String, ByVal sap_no As String, ByVal area As String) As Double
        Dim z As Double = 0.00
        Dim query As String = ""
        If login.wrkgrp = "LC Accounting" Or login.wrkgrp = "Manager" Then
            query = "SELECT DISTINCT " & transnum & "  FROM " & db & " WHERE type='" & typee & "'  AND " & sap_no & "='To Follow';"
        Else
            query = "SELECT DISTINCT " & transnum & "  FROM " & db & " WHERE type='" & typee & "' AND area='" & area & "' AND " & sap_no & "='To Follow';"
        End If
        connect()
        cmd = New SqlCommand(query, con)
        rdr = cmd.ExecuteReader
        While rdr.Read
            z += 1
        End While
        disconnect()
        Return z
    End Function

    Private Sub SalesToolStripMenuItem6_Click(sender As Object, e As EventArgs) Handles SalesToolStripMenuItem6.Click
        con.Open()
        cmd = New SqlCommand("Select TOP 1 * from tblinvsum WHERE area='" & "Administrator" & "' order by invsumid DESC", con)
        Dim dt As New DataTable()
        adptr.SelectCommand = cmd
        adptr.Fill(dt)
        con.Close()
        For Each row As DataRow In dt.Rows
            If row("verify") = 1 Then
                If row("invdate") = Format(Date.Now, "MM/dd/yyyy") Then
                    MsgBox("Pull Out failed! Inventory end for this day.", MsgBoxStyle.Critical, "")
                    Me.Cursor = Cursors.Default
                    Exit Sub
                Else
                    pull_out.MdiParent = Me
                    pull_out.lcacc = "Administrator"
                    pull_out.GetTransID()
                    pull_out.getID()
                    pull_out.panelQuantity.Visible = False
                    pull_out.lblQuantityItemCode.Text = "Item Code:"
                    pull_out.lblQuantityItemName.Text = "Item Name:"
                    pull_out.lblQuantityCategory.Text = "Category:"
                    pull_out.txtboxQuantity.Text = ""
                    pull_out.dgvSelectedItem.Rows.Clear()
                    pull_out.loadd()
                    pull_out.Show()
                    pull_out.WindowState = FormWindowState.Maximized
                End If
            Else
                pull_out.MdiParent = Me
                pull_out.lcacc = "Administrator"
                pull_out.GetTransID()
                pull_out.getID()
                pull_out.panelQuantity.Visible = False
                pull_out.lblQuantityItemCode.Text = "Item Code:"
                pull_out.lblQuantityItemName.Text = "Item Name:"
                pull_out.lblQuantityCategory.Text = "Category:"
                pull_out.txtboxQuantity.Text = ""
                pull_out.dgvSelectedItem.Rows.Clear()
                pull_out.loadd()
                pull_out.Show()
                pull_out.WindowState = FormWindowState.Maximized
            End If
        Next
    End Sub

    Private Sub ProductionToolStripMenuItem7_Click(sender As Object, e As EventArgs) Handles ProductionToolStripMenuItem7.Click
        con.Open()
        cmd = New SqlCommand("Select TOP 1 * from tblinvsum WHERE area='" & "Production" & "' order by invsumid DESC", con)
        Dim dt As New DataTable()
        adptr.SelectCommand = cmd
        adptr.Fill(dt)
        con.Close()
        For Each row As DataRow In dt.Rows
            If row("verify") = 1 Then
                If row("invdate") = Format(Date.Now, "MM/dd/yyyy") Then
                    MsgBox("Pull Out failed! Inventory end for this day.", MsgBoxStyle.Critical, "")
                    Me.Cursor = Cursors.Default
                    Exit Sub
                Else
                    pull_out.MdiParent = Me
                    pull_out.lcacc = "Production"
                    pull_out.GetTransID()
                    pull_out.getID()
                    pull_out.panelQuantity.Visible = False
                    pull_out.lblQuantityItemCode.Text = "Item Code:"
                    pull_out.lblQuantityItemName.Text = "Item Name:"
                    pull_out.lblQuantityCategory.Text = "Category:"
                    pull_out.txtboxQuantity.Text = ""
                    pull_out.dgvSelectedItem.Rows.Clear()
                    pull_out.loadd()
                    pull_out.Show()
                    pull_out.WindowState = FormWindowState.Maximized
                End If
            Else
                pull_out.MdiParent = Me
                pull_out.lcacc = "Production"
                pull_out.GetTransID()
                pull_out.getID()
                pull_out.panelQuantity.Visible = False
                pull_out.lblQuantityItemCode.Text = "Item Code:"
                pull_out.lblQuantityItemName.Text = "Item Name:"
                pull_out.lblQuantityCategory.Text = "Category:"
                pull_out.txtboxQuantity.Text = ""
                pull_out.dgvSelectedItem.Rows.Clear()
                pull_out.loadd()
                pull_out.Show()
                pull_out.WindowState = FormWindowState.Maximized
            End If
        Next
    End Sub

    Private Sub ProductionToolStripMenuItem8_Click(sender As Object, e As EventArgs) Handles ProductionToolStripMenuItem8.Click
        con.Open()
        cmd = New SqlCommand("Select TOP 1 * from tblinvsum WHERE area='" & "Production" & "' order by invsumid DESC", con)
        Dim dt As New DataTable()
        adptr.SelectCommand = cmd
        adptr.Fill(dt)
        con.Close()
        For Each row As DataRow In dt.Rows
            If row("verify") = 1 Then
                If row("invdate") = Format(Date.Now, "MM/dd/yyyy") Then
                    MsgBox("Received Item failed! Inventory end for this day.", MsgBoxStyle.Critical, "")
                    Me.Cursor = Cursors.Default
                    Exit Sub
                Else
                    received_item.MdiParent = Me
                    received_item.Text = "Received From Adjustment"
                    received_item.lcacc = "Production"
                    received_item.load_cb()
                    received_item.GetTransID()
                    received_item.loadz()
                    received_item.Show()
                    received_item.WindowState = FormWindowState.Maximized
                End If
            Else
                received_item.MdiParent = Me
                received_item.Text = "Received From Adjustment"
                received_item.lcacc = "Production"
                received_item.load_cb()
                received_item.GetTransID()
                received_item.loadz()
                received_item.Show()
                received_item.WindowState = FormWindowState.Maximized
            End If
        Next
    End Sub

    Private Sub SalesToolStripMenuItem7_Click(sender As Object, e As EventArgs) Handles SalesToolStripMenuItem7.Click
        con.Open()
        cmd = New SqlCommand("Select TOP 1 * from tblinvsum WHERE area='" & "Administrator" & "' order by invsumid DESC", con)
        Dim dt As New DataTable()
        adptr.SelectCommand = cmd
        adptr.Fill(dt)
        con.Close()
        For Each row As DataRow In dt.Rows
            If row("verify") = 1 Then
                If row("invdate") = Format(Date.Now, "MM/dd/yyyy") Then
                    MsgBox("Received Item failed! Inventory end for this day.", MsgBoxStyle.Critical, "")
                    Me.Cursor = Cursors.Default
                    Exit Sub
                Else
                    received_item.lcacc = "Administrator"
                    received_item.MdiParent = Me
                    received_item.Text = "Received From Adjustment"
                    received_item.load_cb()
                    received_item.GetTransID()
                    received_item.loadz()
                    received_item.Show()
                    received_item.WindowState = FormWindowState.Maximized
                End If
            Else
                received_item.lcacc = "Administrator"
                received_item.MdiParent = Me
                received_item.Text = "Received From Adjustment"
                received_item.load_cb()
                received_item.GetTransID()
                received_item.loadz()
                received_item.Show()
                received_item.WindowState = FormWindowState.Maximized
            End If
        Next
    End Sub

    Private Sub RejectsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RejectsToolStripMenuItem.Click
        Dim fom As New rejects2()
        fom.MdiParent = Me
        fom.Show()
        fom.WindowState = FormWindowState.Maximized
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
    Public Function loadPendingOrders() As Double
        Try
            Dim z As Double = 0.00
            connect()
            cmd = New SqlCommand("SELECT COUNT(*) FROM tbltransaction2 WHERE status2='Unpaid';", con)
            z = cmd.ExecuteScalar
            disconnect()
            Return z
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Function
    Public Function checkLocalReceived() As Double
        Try
            Dim z As Double = 0.00
            connect()
            cmd = New SqlCommand("SELECT COUNT(id) FROM tblpendingtrans WHERE status='Pending';", con)
            z = cmd.ExecuteScalar
            disconnect()
            Return z
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Function
    Public Function requestsNotif() As Integer
        Try
            Dim z As Integer = 0
            connect()
            cmd = New SqlCommand("SELECT dateseen,(SELECT systemid FROM tblusers WHERE username=@username) AS zxc FROM tblrequests WHERE status='Pending';", con)
            cmd.Parameters.AddWithValue("@username", login.username)
            rdr = cmd.ExecuteReader
            While rdr.Read
                If IsDBNull(rdr("dateseen")) Then
                    z = +1
                End If
            End While
            disconnect()
            Return z
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Function
    Public Function requestsNotifFrom() As Integer
        Try
            Dim z As Integer = 0
            connect()
            cmd = New SqlCommand("SELECT requestid FROM tblrequests WHERE status='Pending' AND fromid=(SELECT systemid FROM tblusers WHERE username=@username);", con)
            cmd.Parameters.AddWithValue("@username", login.username)
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
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        loadNotifMessages()
        Try
            Dim result As Double = 0.0, apdep_result As Double = 0.00, pending_result As Double = 0.00, localrec_result As Double = 0.00
            If login.wrkgrp = "Production" Then
                result += countPendings("transaction_number", "Produce Item", "tblproduction", "sap_number", "Production")
                result += countPendings("transaction_number", "Transfer Item", "tblproduction", "sap_number", "Production")
                result += countPendings("transnum", "AR Reject", "tblars1", "sap_no", "Production")
                result += countPendings("transnum", "AR Charge", "tblars1", "sap_no", "Production")
                result += countPendings("conv_number", "Parent", "tblconversion", "sap_id", "Production")
                result += countPendings("conv_number", "Child", "tblconversion", "sap_id", "Production")
            ElseIf login.wrkgrp = "Administrator" Then
                result += countPendings("transaction_number", "Received Item", "tblproduction", "sap_number", "Administrator")
                result += countPendings("transaction_number", "Transfer Item", "tblproduction", "sap_number", "Administrator")
                result += countPendings("transnum", "AR Charge", "tblars1", "sap_no", "Sales")
                result += countPendings("transnum", "AR Sales", "tblars1", "sap_no", "Sales")
                result += countPendings("transnum", "AR Cash", "tblars1", "sap_no", "Sales")
                result += countPendings("conv_number", "Parent", "tblconversion", "sap_id", "Administrator")
                result += countPendings("conv_number", "Child", "tblconversion", "sap_id", "Administrator")
                localrec_result += checkLocalReceived()
            ElseIf login.wrkgrp = "Cashier" Then
                apdep_result += apdep()
                apdep_result += activeAPDEP("Advance Payment")
                apdep_result += activeAPDEP("Deposit")
                pending_result += loadPendingOrders()
            ElseIf login.wrkgrp = "LC Accounting" Then
                If requestsNotif() <> 0 Then
                    requesttool.Text = "Request (" & requestsNotif() & ")"
                    PendingRequetsToolStripMenuItem.Text = "Requests (" & requestsNotif() & ")"
                    requesttool.Font = New Font("Segoe UI", 9, FontStyle.Bold)
                    PendingRequetsToolStripMenuItem.Font = New Font("Segoe UI", 9, FontStyle.Bold)
                    RequestLetterToolStripMenuItem.Font = New Font("Segoe UI", 9, FontStyle.Regular)
                Else
                    requesttool.Text = "Request"
                    PendingRequetsToolStripMenuItem.Text = "Request"
                    requesttool.Font = New Font("Segoe UI", 9, FontStyle.Regular)
                    PendingRequetsToolStripMenuItem.Font = New Font("Segoe UI", 9, FontStyle.Regular)
                    RequestLetterToolStripMenuItem.Font = New Font("Segoe UI", 9, FontStyle.Regular)
                End If
            End If
            If login.wrkgrp <> "LC Accounting" Then
                If requestsNotifFrom() <> 0 Then
                    requesttool.Text = "Request (" & requestsNotifFrom() & ")"
                    PendingRequetsToolStripMenuItem.Text = "Requests (" & requestsNotifFrom() & ")"
                    requesttool.Font = New Font("Segoe UI", 9, FontStyle.Bold)
                    PendingRequetsToolStripMenuItem.Font = New Font("Segoe UI", 9, FontStyle.Bold)
                    RequestLetterToolStripMenuItem.Font = New Font("Segoe UI", 9, FontStyle.Regular)
                Else
                    requesttool.Text = "Request"
                    PendingRequetsToolStripMenuItem.Text = "Request"
                    requesttool.Font = New Font("Segoe UI", 9, FontStyle.Regular)
                    PendingRequetsToolStripMenuItem.Font = New Font("Segoe UI", 9, FontStyle.Regular)
                    RequestLetterToolStripMenuItem.Font = New Font("Segoe UI", 9, FontStyle.Regular)
                End If
            End If
            If localrec_result <> 0 Then
                ReceivedItemToolStripMenuItem.Text = "Received Item (" & localrec_result & ")"
                LocalSToolStripMenuItem.Text = "From Production (" & localrec_result & ")"
                ReceivedItemToolStripMenuItem.Font = New Font("Segoe UI", 9, FontStyle.Bold)
                LocalSToolStripMenuItem.Font = New Font("Segoe UI", 9, FontStyle.Bold)

                BranchesToolStripMenuItem1.Font = New Font("Segoe UI", 9, FontStyle.Regular)
                FromDirectSupplierToolStripMenuItem.Font = New Font("Segoe UI", 9, FontStyle.Regular)
            Else
                ReceivedItemToolStripMenuItem.Text = "Received Item"
                ReceivedItemToolStripMenuItem.Font = New Font("Segoe UI", 9, FontStyle.Regular)

                LocalSToolStripMenuItem.Text = "From Production"
                LocalSToolStripMenuItem.Font = New Font("Segoe UI", 9, FontStyle.Regular)


                BranchesToolStripMenuItem1.Font = New Font("Segoe UI", 9, FontStyle.Regular)
                FromDirectSupplierToolStripMenuItem.Font = New Font("Segoe UI", 9, FontStyle.Regular)
            End If

            If result <> 0 Then
                InventoryTransactionToolStripMenuItem.Font = New Font("Segoe UI", 9, FontStyle.Bold)

                InventoryTransactionToolStripMenuItem.Text = "Inventory Transaction (" & result + localrec_result & ")"


                PendingSAPToolStripMenuItem.Text = "Pending SAP # (" & result & ")"
                PendingSAPToolStripMenuItem.Font = New Font("Segoe UI", 9, FontStyle.Bold)


                CreateNewToolStripMenuItem.Font = New Font("Segoe UI", 9, FontStyle.Regular)
                ReceivedItemToolStripMenuItem.Font = New Font("Segoe UI", 9, FontStyle.Regular)
                ProduceItemToolStripMenuItem.Font = New Font("Segoe UI", 9, FontStyle.Regular)
                TransferToolStripMenuItem.Font = New Font("Segoe UI", 9, FontStyle.Regular)
                ConversionToolStripMenuItem.Font = New Font("Segoe UI", 9, FontStyle.Regular)
                ARToolStripMenuItem.Font = New Font("Segoe UI", 9, FontStyle.Regular)
                InventoryToolStripMenuItem.Font = New Font("Segoe UI", 9, FontStyle.Regular)
                InventoryToolStripMenuItem1.Font = New Font("Segoe UI", 9, FontStyle.Regular)
                EndingBalanceToolStripMenuItem.Font = New Font("Segoe UI", 9, FontStyle.Regular)
                PullOutToolStripMenuItem.Font = New Font("Segoe UI", 9, FontStyle.Regular)
                RejectsToolStripMenuItem.Font = New Font("Segoe UI", 9, FontStyle.Regular)
            Else
                InventoryTransactionToolStripMenuItem.Font = New Font("Segoe UI", 9, FontStyle.Regular)
                InventoryTransactionToolStripMenuItem.Text = "Inventory Transaction"
                PendingSAPToolStripMenuItem.Text = "Pending SAP #"
                PendingSAPToolStripMenuItem.Font = New Font("Segoe UI", 9, FontStyle.Regular)
            End If
            'active return item
            If apdep_result <> 0 Then
                ReturnItemToolStripMenuItem.Text = "Advance Payment / Deposit (" & apdep_result & ")"
                ReturnItemToolStripMenuItem.Font = New Font("Segoe UI", 9, FontStyle.Bold)
            Else
                ReturnItemToolStripMenuItem.Text = "Advance Payment / Deposit"
                ReturnItemToolStripMenuItem.Font = New Font("Segoe UI", 9, FontStyle.Regular)
            End If
            If pending_result <> 0 Then
                PendingOrderToolStripMenuItem.Text = "Pending Order (" & pending_result & ")"
                PendingOrderToolStripMenuItem.Font = New Font("Segoe UI", 9, FontStyle.Bold)
            Else
                PendingOrderToolStripMenuItem.Text = "Pending Order"
                PendingOrderToolStripMenuItem.Font = New Font("Segoe UI", 9, FontStyle.Regular)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class