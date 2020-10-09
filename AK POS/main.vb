Imports System.Data.SqlClient
Imports System.IO
Public Class main
    'classes
    Dim cc As New connection_class
    Dim loginc As New login_class
    Dim invc As New inventory_class
    Dim userc As New user_class
    Dim accessc As New access_class

    'local variable
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    Dim toggle_max As Boolean = False

    Dim transaction As SqlTransaction
    Private Sub btn1_Click(sender As Object, e As EventArgs) Handles btnsettings.Click
        hideShow(panelsubsettings)
    End Sub
    Public Sub hideShow(ByVal panel As Panel)
        If panel.Visible = True Then
            panel.Visible = False
        Else
            panel.Visible = True
        End If
    End Sub

    Public Sub showForm(ByVal form As Form)
        panelchildform.Controls.Clear()
        form.TopLevel = False
        form.Dock = DockStyle.Fill
        panelchildform.Controls.Add(form)
        form.BringToFront()
        form.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnlogout.Click
        Try
            Dim a As String = MsgBox("Are you sure you want to logout?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "")
            If a = vbYes Then
                loginc.setUsername(login2.username)
                loginc.logOut()
                Me.Hide()
                Dim frm As New login2
                frm.ShowDialog()
            End If
        Catch ex As SqlException
            If ex.Number = -2 Then
                MessageBox.Show("Timeout Occured", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles btnitems.Click
        hideShow(panelsubitems)
    End Sub

    Private Sub btnreports_Click(sender As Object, e As EventArgs) Handles btnreports.Click
        hideShow(panelsubreports)
    End Sub

    Private Sub Button11_Click_1(sender As Object, e As EventArgs) Handles btninvtrans.Click
        hideShow(panelsubinventorytransaction)
    End Sub

    Private Sub btncutoff_Click(sender As Object, e As EventArgs) Handles btncutoff.Click
        If login2.wrkgrp = "Cashier" Then
            MessageBox.Show("Access Denied", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Else
            hideShow(panelsubsettings)
            Dim f As New cutoff()
            showForm(f)
        End If
    End Sub
    Private Sub btncategory_Click(sender As Object, e As EventArgs)
        If login2.wrkgrp = "Administrator" Or login2.wrkgrp = "LC Accounting" Then
            hideShow(panelsubitems)
            Dim f As New categories()
            showForm(f)
        Else
            MessageBox.Show("Access Denied", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnmanageitem_Click(sender As Object, e As EventArgs) Handles btnmanageitem.Click
        If login2.wrkgrp = "Administrator" Then
            hideShow(panelsubitems)
            Dim f As New items2()
            showForm(f)
        Else
            MessageBox.Show("Access Denied", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnitemimage_Click(sender As Object, e As EventArgs) Handles btnitemimage.Click
        If login2.wrkgrp = "Administrator" Or login2.wrkgrp = "LC Accounting" Then
            hideShow(panelsubitems)
            Dim f As New saveimg()
            showForm(f)
        Else
            MessageBox.Show("Access Denied", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
    End Sub

    Private Sub btntransfer_Click(sender As Object, e As EventArgs) Handles btntransfer.Click
        If login2.wrkgrp = "LC Accounting" Or login2.wrkgrp = "Production" Then
            MessageBox.Show("Access Denied", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        ElseIf loginc.checkCutOff() Then
            MessageBox.Show("Your account is already cut off", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            hideShow(panelsubinventorytransaction)
            Dim frm As New received_item2()
            frm.received_type = "Transfer Out"
            showForm(frm)
        End If
    End Sub

    Private Sub bntarcharge_Click(sender As Object, e As EventArgs) Handles bntarcharge.Click
        If login2.wrkgrp = "Cashier" Then
            MessageBox.Show("Access Denied", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Else
            hideShow(panelsubinventorytransaction)
            Dim f As New ars()
            f.TopLevel = False
            f.Dock = DockStyle.Fill
            panelchildform.Controls.Add(f)
            f.BringToFront()
            f.tayp = "AR Charge"
            f.Text = "A.R Charge"
            f.GroupBox1.Visible = False
            f.btnunpaid.ForeColor = Color.White
            f.lcacc = "Sales"
            f.dgvArs2.Rows.Clear()
            f.btnpaid.ForeColor = Color.Black
            f.btnSubmit.Visible = False
            f.dgvARS.Columns("action").Visible = False
            f.Panel1.Visible = False
            f.lblSAPNo.Text = ""
            f.lblRemarks.Text = ""
            f.btnpaid.Text = "PAID A.R"
            f.btnpaid.PerformClick()
            If login2.wrkgrp = "LC Accounting" Then
                ars.btneditar.Visible = True
            Else
                f.btneditar.Visible = False
            End If
            If login2.wrkgrp = "Manager" Then
                f.btnpaid.ForeColor = Color.Black
                f.dgvARS.Columns("action").Visible = False
                f.btnSubmit.Visible = False
                f.GroupBox1.Visible = False
            End If
            f.Show()
        End If
    End Sub

    Private Sub btnarsales_Click(sender As Object, e As EventArgs) Handles btnarsales.Click
        hideShow(panelsubinventorytransaction)

        Dim f As New ars()
        f.TopLevel = False
        f.Dock = DockStyle.Fill
        panelchildform.Controls.Add(f)
        f.BringToFront()

        f.tayp = "AR Sales"
        f.Text = "A.R Sales"
        f.lcacc = "Sales"
        f.GroupBox1.Visible = True
        f.PanelSAP.Visible = False
        f.txtboxRemarks.Text = ""
        f.txtboxSAPNo.Text = ""
        f.btnunpaid.Visible = True
        f.btnpaid.Text = "PAID A.R"
        f.btnunpaid.ForeColor = Color.Black
        f.btnpaid.ForeColor = Color.White
        f.dgvArs2.Rows.Clear()
        f.dgvARS.Columns("action").Visible = False
        f.Panel1.Visible = False
        f.lblSAPNo.Text = ""
        f.lblRemarks.Text = ""
        f.btnSubmit.Visible = True
        If login2.wrkgrp = "Manager" Then
            f.btnpaid.ForeColor = Color.Black
            f.dgvARS.Columns("action").Visible = False
            f.btnSubmit.Visible = False
            f.GroupBox1.Visible = False
        End If
        f.btneditar.Visible = False
        f.btnpaid.PerformClick()
        f.Show()
    End Sub
    Public Sub createNewInventory()
        Dim invNum As String = invc.getInvNum()
        Dim items As New List(Of Integer)
        cc.con.Open()
        cc.cmd = New SqlCommand("SELECT itemid FROM tblitems WHERE discontinued=0", cc.con)
        cc.rdr = cc.cmd.ExecuteReader
        While cc.rdr.Read
            items.Add(cc.rdr("itemid"))
        End While
        cc.con.Close()
        Try
            Dim yesterdayInvDate As String = getInventoryDate().ToString("MM/dd/yyyy")
            Me.Cursor = Cursors.WaitCursor
            Using connection As New SqlConnection(cc.conString)
                Dim cmdd As New SqlCommand(), rdrr As SqlDataReader
                cmdd.Connection = connection
                connection.Open()
                transaction = connection.BeginTransaction()
                cmdd.Transaction = transaction

                cmdd.CommandText = "Insert into tblinvsum (invnum, invdate, cashier, shift, verify, datecreated, datemodified, modifiedby, status,area) values('" + invNum + "',(select cast(getdate() as date)), '" & login2.username & "', '', 0, (SELECT GETDATE()),(SELECT GETDATE()), '" & login2.username & "', 1,'" & "Sales" & "')"
                cmdd.ExecuteNonQuery()
                For Each itemid As Integer In items
                    Dim begbal As Double = 0.00, variance As Double = 0.00, itemname As String = "", itemcode As String = ""

                    cmdd.CommandText = "SELECT ISNULL(SUM(b.actualendbal),0)  FROM tblitems a INNER JOIN tblinvitems b ON a.itemname = b.itemname WHERE a.discontinued=0 AND b.invnum=(select invnum FROM tblinvsum WHERE CAST(datecreated AS date)=(select cast(getdate()-1 as date))) AND actualendbal !=0 AND a.itemid=" & itemid & ""
                    begbal = cmdd.ExecuteScalar

                    cmdd.CommandText = "SELECT ISNULL(SUM(quantity),0) [po] FROM tblproduction WHERE type='Pull Out' AND status='Completed' AND sap_number='To Follow' AND CAST(date as date)='" + yesterdayInvDate + "' AND item_name=(SELECT Itemname FROM tblitems WHERE itemid=" & itemid & " AND quantity > 0);"
                    Dim po As Double = cmdd.ExecuteScalar
                    begbal = begbal + po

                    variance = 0 - begbal

                    cmdd.CommandText = "SELECT itemcode,itemname FROM tblitems WHERE itemid=" & itemid & ""
                    rdrr = cmdd.ExecuteReader
                    If rdrr.Read Then
                        itemcode = rdrr("itemcode")
                        itemname = rdrr("itemname")
                    End If
                    rdrr.Close()

                    cmdd.CommandText = "Insert into tblinvitems (invnum, itemcode, itemname, begbal,produce,good,reject,charge,productionin, itemin, totalav, ctrout, pullout, endbal, actualendbal, variance, shortover, status,convin,archarge,arsales,convout,transfer,area,arreject,supin,adjustmentin,reject_convin,reject_convout,reject_archarge,reject_transfer,reject_totalav,cancelin,pullout2,salesout,salesin) values('" + invNum + "','" & itemcode & "','" & itemname & "'," & begbal & ",0,0,0,0,0,0," & begbal & ",0,0," & begbal & ",0," & variance & ",'',1,0,0,0,0,0,'Sales',0,0,0,0,0,0,0,0,0,0,0,0)"
                    cmdd.ExecuteNonQuery()
                Next
                transaction.Commit()
                connection.Close()
                Me.Cursor = Cursors.Default
                MessageBox.Show("Inventory Created", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        Catch ex As Exception
            Try
                MessageBox.Show(ex.ToString)
                transaction.Rollback()
            Catch ex2 As Exception
                MessageBox.Show(ex2.ToString)
            End Try
        End Try
    End Sub

    Public Function getInventoryDate() As Date
        Dim result As Date
        Try
            cc.con.Open()
            cc.cmd = New SqlCommand("SELECT TOP 1 CAST(datecreated AS date)[date] FROM tblinvsum ORDER BY invsumid DESC", cc.con)
            result = cc.cmd.ExecuteScalar
            cc.con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        Return result
    End Function

    Private Sub btncreatenew_Click(sender As Object, e As EventArgs) Handles btncreatenew.Click
        If loginc.checkCutOff() Then
            MessageBox.Show("Your account is already cut off", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf login2.wrkgrp = "Cashier" Then
            MessageBox.Show("Access Denied", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            hideShow(panelsubinventorytransaction)
            cc.con.Open()
            cc.cmd = New SqlCommand("Select TOP 1 verify,invdate from tblinvsum WHERE area='Sales' order by invsumid DESC", cc.con)
            Dim dt As New DataTable()
            cc.adptr.SelectCommand = cc.cmd
            cc.adptr.Fill(dt)
            cc.con.Close()
            If dt.Rows.Count = 0 Then
                Dim a As String = MsgBox("Are you sure you want to create new inventory?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "")
                If a = vbYes Then
                    Control.CheckForIllegalCrossThreadCalls = False
                    Dim th As New Threading.Thread(AddressOf createNewInventory)
                    th.Start()
                End If
            Else
                    For Each row As DataRow In dt.Rows
                    If row("verify") = 1 Then
                        If row("invdate") = cc.getSystemDate.ToString("MM/dd/yyyy") Then
                            MsgBox("Creating new inventory failed! Inventory end for this day.", MsgBoxStyle.Critical, "")
                        Else
                            Dim a As String = MsgBox("Are you sure you want to create new inventory?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "")
                            If a = vbYes Then
                                Control.CheckForIllegalCrossThreadCalls = False
                                Dim th As New Threading.Thread(AddressOf createNewInventory)
                                th.Start()
                            End If
                        End If
                            Else
                        MessageBox.Show("Verify first", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Next
            End If
        End If
    End Sub


    Private Sub btninvsales_Click(sender As Object, e As EventArgs) Handles btninventory.Click
        If login2.wrkgrp = "Manager" Or login2.wrkgrp = "LC Accounting" Or login2.wrkgrp = "Cashier" Or login2.wrkgrp = "Administrator" Or login2.wrkgrp = "Sales" Then

            hideShow(panelsubinventorytransaction)

            Dim f As New inv2()
            showForm(f)
        Else
            MessageBox.Show("Access Denied", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
    End Sub

    Private Sub btnadjinsales_Click(sender As Object, e As EventArgs) Handles btnadjustmentin.Click
        Try
            If login2.wrkgrp = "LC Accounting" Then
                hideShow(panelsubinventorytransaction)
                Dim f As New received_item2()
                f.received_type = "Received from Adjustment"
                showForm(f)
            Else
                MessageBox.Show("Access Denied", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub btnadjoutsales_Click(sender As Object, e As EventArgs)
        If login2.wrkgrp = "LC Accounting" Then
            hideShow(panelsubinventorytransaction)
            Dim f As New pull_out()
            f.TopLevel = False
            f.Dock = DockStyle.Fill
            panelchildform.Controls.Add(f)
            f.BringToFront()

            f.lcacc = "Sales"
            f.Text = "Adjustment Out (Sales)"
            f.GetTransID()
            f.getID()
            f.panelQuantity.Visible = False
            f.lblQuantityItemCode.Text = "Item Code:"
            f.lblQuantityItemName.Text = "Item Name:"
            f.lblQuantityCategory.Text = "Category:"
            f.txtboxQuantity.Text = ""
            f.dgvSelectedItem.Rows.Clear()
            f.loadd()
            f.Show()
        Else
            MessageBox.Show("Access Denied", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
    End Sub


    Private Sub btnbranches_Click(sender As Object, e As EventArgs) Handles btnbranches.Click
        If login2.wrkgrp = "Administrator" Or login2.wrkgrp = "LC Accounting" Then
            hideShow(panelsubsales)

            Dim f As New branches()
            showForm(f)
        Else
            MessageBox.Show("Access Denied", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
    End Sub

    Private Sub btnordertrans_Click(sender As Object, e As EventArgs) Handles btnordertrans.Click
        hideShow(panelsubsales)
        Dim f As New fake_transaction()
        showForm(f)
    End Sub

    Private Sub btnsales_Click(sender As Object, e As EventArgs) Handles btnsales.Click
        hideShow(panelsubsales)
    End Sub
    Private Sub main_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        lblheader.Text = "ATLANTIC BAKERY INVENTORY SYSTEM " & "[" & userc.loadNameUser() & "]" & "[" & login2.wrkgrp & "]"
    End Sub

    Private Sub btnrecprod_Click(sender As Object, e As EventArgs) Handles btnrecprod.Click
        If login2.wrkgrp = "LC Accounting" Or login2.wrkgrp = "Production" Then
            MessageBox.Show("Access Denied", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf loginc.checkCutOff() Then
            MessageBox.Show("Your account is already cut off", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf Not accessc.isUserAllowed("Received from Production") Then
            MessageBox.Show("Access Denied", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            hideShow(panelsubinventorytransaction)
            Dim frm As New received_item2()
            frm.received_type = "Received from Production"
            showForm(frm)
        End If
    End Sub

    Private Sub btnrecbranch_Click(sender As Object, e As EventArgs) Handles btnrecbranch.Click
        If login2.wrkgrp = "LC Accounting" Or login2.wrkgrp = "Production" Then
            MessageBox.Show("Access Denied", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf loginc.checkCutOff() Then
            MessageBox.Show("Your account is already cut off", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf Not accessc.isUserAllowed("Received from Other Branch") Then
            MessageBox.Show("Access Denied", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            hideShow(panelsubinventorytransaction)
            Dim frm As New received_item2()
            frm.received_type = "Received from Other Branch"
            showForm(frm)
        End If
    End Sub

    Private Sub btnrecsup_Click(sender As Object, e As EventArgs) Handles btnrecsup.Click
        If login2.wrkgrp = "LC Accounting" Or login2.wrkgrp = "Production" Then
            MessageBox.Show("Access Denied", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf loginc.checkCutOff() Then
            MessageBox.Show("Your account is already cut off", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf Not accessc.isUserAllowed("Received from Direct Supplier") Then
            MessageBox.Show("Access Denied", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            hideShow(panelsubinventorytransaction)
            Dim frm As New received_item2()
            frm.received_type = "Received from Direct Supplier"
            showForm(frm)
        End If
    End Sub

    Private Sub btnmanusers_Click(sender As Object, e As EventArgs) Handles btnmanusers.Click
        If login2.wrkgrp = "Administrator" Then
            hideShow(panelsubusers)
            Dim f As New users2()
            showForm(f)
        Else
            MessageBox.Show("Access Denied", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnmancustomers_Click(sender As Object, e As EventArgs) Handles btnmancustomers.Click
        If login2.wrkgrp = "Administrator" Or login2.wrkgrp = "LC Accounting" Then
            hideShow(panelsubsales)
            Dim f As New customers()
            showForm(f)
        Else
            MessageBox.Show("Access Denied", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
    End Sub

    Private Sub btnusers_Click(sender As Object, e As EventArgs) Handles btnusers.Click
        hideShow(panelsubusers)
    End Sub

    Private Sub btnpos_Click(sender As Object, e As EventArgs) Handles btnpos.Click

        If login2.wrkgrp = "Sales" Or login2.wrkgrp = "Manager" Or login2.wrkgrp = "LC Accounting" Or login2.wrkgrp = "Administrator" Then
            If loginc.checkCutOff() Then
                MessageBox.Show("Your account is already cut off", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            cc.con.Open()
            cc.cmd = New SqlCommand("Select TOP 1 * from tblinvsum WHERE area='" & "Sales" & "' order by invsumid DESC", cc.con)
            Dim dt As New DataTable()
            cc.adptr.SelectCommand = cc.cmd
            cc.adptr.Fill(dt)
            cc.con.Close()
            For Each row As DataRow In dt.Rows
                If row("verify") = 1 Then
                    If row("invdate") = cc.getSystemDate.ToString("MM/dd/yyyy") Then
                        MsgBox("POS failed! Inventory end for this day.", MsgBoxStyle.Critical, "")
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    Else
                        Dim f As New mainmenu()
                        f.cas = "Sales"
                        f.Show()
                    End If
                Else
                    Dim f As New mainmenu()
                    f.cas = "Sales"
                    f.Show()
                End If
            Next
        Else
            MessageBox.Show("Access Denied", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnapdep_Click(sender As Object, e As EventArgs) Handles btnapdep.Click
        If login2.wrkgrp = "Manager" Or login2.wrkgrp = "Cashier" Or login2.wrkgrp = "LC Accounting" Then
            Dim f As New returnstand()
            If login2.wrkgrp = "Manager" Or login2.wrkgrp = "Cashier" Then
                If login2.wrkgrp = "Manager" Then
                    returnstand.dgvlists.Columns("btnreturn").Visible = False
                End If
                showForm(f)
            Else
                If login2.wrkgrp = "Manager" Then
                    f.dgvlists.Columns("btnreturn").Visible = False
                End If
                showForm(f)
            End If
        Else
            MessageBox.Show("Access Denied", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnconvlogssales_Click(sender As Object, e As EventArgs) Handles btnconvlogssales.Click
        If login2.wrkgrp = "Sales" Or login2.wrkgrp = "Manager" Or login2.wrkgrp = "LC Accounting" Or login2.wrkgrp = "Administrator" Then
            hideShow(panelsubreports)
            Dim f As New conv_logs
            showForm(f)
        Else
            MessageBox.Show("Access Denied", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub btninvlogssales_Click(sender As Object, e As EventArgs) Handles btninvlogssales.Click
        If login2.wrkgrp = "Sales" Or login2.wrkgrp = "Manager" Or login2.wrkgrp = "LC Accounting" Or login2.wrkgrp = "Administrator" Then
            hideShow(panelsubreports)
            Dim f As New inv_logs2
            showForm(f)
        Else
            MessageBox.Show("Access Denied", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnpendingsapsales_Click(sender As Object, e As EventArgs) Handles btnpendingsap.Click
        If login2.wrkgrp = "Sales" Or login2.wrkgrp = "Manager" Or login2.wrkgrp = "LC Accounting" Or login2.wrkgrp = "Administrator" Then
            hideShow(panelsubinventorytransaction)
            Dim f As New pendingsap2
            f.manager = "Sales"
            showForm(f)
        Else
            MessageBox.Show("Access Denied", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
    End Sub

    Private Sub btnendingbalance_Click(sender As Object, e As EventArgs) Handles btnendingbalance.Click
        'If (login2.wrkgrp.Equals("Administrator") Or login2.wrkgrp.Equals("LC Accounting")) Then
        '    MessageBox.Show("Access Denied", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'ElseIf Not loginc.checkCutOff() Then
        '    MessageBox.Show("Cut off first", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'Else
        '    hideShow(panelsubinventorytransaction)
        '    Dim f As New endingbalance2
        '    showForm(f)
        'End If
        hideShow(panelsubinventorytransaction)
        Dim f As New endingbalance
        showForm(f)
    End Sub
    Private Sub btnlogs_Click(sender As Object, e As EventArgs) Handles btnlogs.Click
        If login2.wrkgrp = "Administrator" Then
            hideShow(panelsubusers)
            Dim f As New loginlogs
            showForm(f)
        Else
            MessageBox.Show("Access Denied", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnconvsales_Click(sender As Object, e As EventArgs) Handles btnconversion.Click
        If login2.wrkgrp = "LC Accounting" Or login2.wrkgrp = "Production" Then
            MessageBox.Show("Access Denied", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf loginc.checkCutOff() Then
            MessageBox.Show("Your account is already cut off", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            hideShow(panelsubinventorytransaction)
            Dim frm As New received_item2()
            frm.received_type = "Conversion Out"
            showForm(frm)
        End If
    End Sub

    Private Sub btnorders_Click(sender As Object, e As EventArgs) Handles btnorders.Click
        hideShow(panelsuborders)
    End Sub

    Private Sub btnpendingorder_Click(sender As Object, e As EventArgs) Handles btnpendingorder.Click
        If login2.wrkgrp = "Cashier" Or login2.wrkgrp = "LC Accounting" Or login2.wrkgrp = "Administrator" Then
            hideShow(panelsuborders)
            Dim f As New cashier()
            showForm(f)
        Else
            MessageBox.Show("Access Denied", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnorderhistory_Click(sender As Object, e As EventArgs) Handles btnorderhistory.Click
        hideShow(panelsuborders)
        Dim f As New orders()
        showForm(f)
    End Sub

    Private Sub main_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        Me.Height = Screen.PrimaryScreen.WorkingArea.Height
        Me.Width = Screen.PrimaryScreen.WorkingArea.Width
        Me.Location = Screen.PrimaryScreen.WorkingArea.Location
    End Sub

    Private Sub btndischarge_Click(sender As Object, e As EventArgs) Handles btndischarge.Click
        If login2.wrkgrp = "Administrator" Or login2.wrkgrp = "LC Accounting" Then
            hideShow(panelsubsales)
            Dim f As New discount()
            showForm(f)
        Else
            MessageBox.Show("Access Denied", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        lbldatetime.Text = "Date: " & DateTime.Now.ToString("MM/dd/yyyy") & " Time: " & DateTime.Now.ToString("hh:mm tt")
    End Sub

    Private Sub btnprintreports_Click(sender As Object, e As EventArgs) Handles btnprintreports.Click
        hideShow(panelsubreports)
        Dim f As New reportss
        showForm(f)
    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btnrectrans.Click
        If login2.wrkgrp = "LC Accounting" Or login2.wrkgrp = "Administrator" Then
            hideShow(panelsubreports)
            Dim f As New cancel_rectrans
            showForm(f)
        Else
            MessageBox.Show("Access Denied", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btncoffeeshop_Click(sender As Object, e As EventArgs) Handles btncoffeeshop.Click
        If login2.wrkgrp = "LC Accounting" Or login2.wrkgrp = "Administrator" Then
            hideShow(panelsubitems)
            Dim f As New coffee_shop
            showForm(f)
        Else
            MessageBox.Show("Access Denied", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnsapupload_Click(sender As Object, e As EventArgs) Handles btnsapupload.Click
        If login2.wrkgrp = "Administrator" Or login2.wrkgrp = "LC Accounting" Then
            Dim frm As New sap_uploading()
            frm.ShowDialog()
            hideShow(panelsubreports)
        Else
            MessageBox.Show("Access Denied", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btneditsap_Click(sender As Object, e As EventArgs) Handles btneditsap.Click
        If login2.wrkgrp = "Administrator" Or login2.wrkgrp = "LC Accounting" Then
            hideShow(panelsubinventorytransaction)

            Dim f As New overwrite_sap()
            f.TopLevel = False
            f.Dock = DockStyle.Fill
            panelchildform.Controls.Add(f)
            f.BringToFront()
            f.Show()
        Else
            MessageBox.Show("Access Denied", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub Panel2_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel2.MouseDown, panelchildform.MouseDown, Panel1.MouseDown, lblheader.MouseDown, lbldatetime.MouseDown
        drag = True 'Sets the variable drag to true.
        mousex = Windows.Forms.Cursor.Position.X - Me.Left 'Sets variable mousex
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top 'Sets variable mousey
    End Sub

    Private Sub Panel2_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel2.MouseMove, panelchildform.MouseMove, Panel1.MouseMove, lblheader.MouseMove, lbldatetime.MouseMove
        'If drag is set to true then move the form accordingly.
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub Panel2_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel2.MouseUp, panelchildform.MouseUp, Panel1.MouseUp, lblheader.MouseUp, lbldatetime.MouseUp
        drag = False 'Sets drag to false, so the form does not move according to the code in MouseMove
    End Sub

    Private Sub maximize_Click(sender As Object, e As EventArgs) Handles maximize.Click
        If toggle_max Then
            Me.WindowState = FormWindowState.Maximized
            toggle_max = False
        Else
            toggle_max = True
            Me.WindowState = FormWindowState.Normal
        End If
        panelchildform.Dock = DockStyle.Fill
    End Sub

    Private Sub btnminimize_Click(sender As Object, e As EventArgs) Handles btnminimize.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btnRemarks_Click(sender As Object, e As EventArgs) Handles btnRemarks.Click
        If login2.wrkgrp = "LC Accounting" Then
            hideShow(panelsubreports)
            Dim f As New EditRemarks
            showForm(f)
        Else
            MessageBox.Show("Access Denied", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnReceivedSAP_Click(sender As Object, e As EventArgs) Handles btnReceivedSAP.Click
        If login2.wrkgrp <> "Cashier" Or login2.wrkgrp <> "LC Accounting" Then
            hideShow(panelsubreports)
            Dim f As New receivedFromSAP
            showForm(f)
        Else
            MessageBox.Show("Access Denied", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnCategory_Click_1(sender As Object, e As EventArgs) Handles btnCategory.Click
        If login2.wrkgrp = "Administrator" Then
            hideShow(panelsubitems)
            Dim f As New categories()
            showForm(f)
        Else
            MessageBox.Show("Access Denied", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnPullOut_Click(sender As Object, e As EventArgs) Handles btnPullOut.Click
        If login2.wrkgrp <> "Cashier" Then
            hideShow(panelsubitems)
            Dim f As New pullOut()
            showForm(f)
        Else
            MessageBox.Show("Access Denied", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnAccess_Click(sender As Object, e As EventArgs) Handles btnAccess.Click
        If login2.wrkgrp = "Manager" Then
            hideShow(panelsubitems)
            Dim f As New access()
            showForm(f)
        Else
            MessageBox.Show("Access Denied", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub main_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class