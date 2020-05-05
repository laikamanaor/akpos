Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.IO
Imports System.Drawing

Public Class items
    Dim strconn As String = login.ss
    Dim conn As New SqlConnection(strconn)
    Dim cmd As SqlCommand
    Dim dr As SqlDataReader
    Dim sql As String

    Dim updatebool As Boolean = False
    Dim iid As Integer = 0
    Public Shared firmitems As Boolean = False

    Dim inv_id As String = ""
    Public Function decryptConString() As String
        Dim base64encoded As String = File.ReadAllText("connectionstring.txt")
        Dim data As Byte() = System.Convert.FromBase64String(base64encoded)
        Return System.Text.ASCIIEncoding.ASCII.GetString(data)
    End Function

    'Public Sub connect()
    '    conn = New SqlConnection
    '    conn.ConnectionString = strconn
    '    If conn.State <> ConnectionState.Open Then
    '        conn.Open()
    '    End If
    'End Sub

    'Public Sub disconnect()
    '    conn = New SqlConnection
    '    conn.ConnectionString = strconn
    '    If conn.State = ConnectionState.Open Then
    '        conn.Close()
    '    End If
    'End Sub

    Private Sub manageitems_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        'btnview.PerformClick()
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub manageitems_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Cursor = Cursors.WaitCursor
            btnview.PerformClick()
            frmload()
            loadcat()
            cmbcat.Focus()
            'btnview.PerformClick()
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Information)
        End Try
    End Sub

    Private Sub cmbcat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbcat.SelectedIndexChanged
        Try
            If cmbcat.SelectedItem <> "" And updatebool = False Then
                reload()
                loaditem()
            End If
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Information)
        End Try
    End Sub

    Public Sub loadcat()
        Try
            Me.Cursor = Cursors.WaitCursor
            cmbcat.Items.Clear()
            sql = "Select * from tblcat where status='1' order by category"
            conn.Open()
            cmd = New SqlCommand(sql, conn)
            dr = cmd.ExecuteReader
            While dr.Read
                cmbcat.Items.Add(dr("category").ToString)
            End While
            conn.Close()
            Me.Cursor = Cursors.Default
        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Information)
        End Try
    End Sub

    Public Sub loaditem()
        cmbname.Items.Clear()
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim chk As Boolean = False
            If chkhide.Checked = True Then
                sql = "Select * from tblitems where discontinued='1' and category='" & cmbcat.SelectedItem.ToString & "' order by itemname"
            Else
                sql = "Select * from tblitems where discontinued='0' and category='" & cmbcat.SelectedItem.ToString & "' order by itemname"
            End If
            conn.Open()
            cmd = New SqlCommand(sql, conn)
            dr = cmd.ExecuteReader
            While dr.Read
                chk = True
                cmbname.Items.Add(dr("itemname").ToString)
            End While
            conn.Close()
            If chk = True Then
                cmbname.Enabled = True
            Else
                reload()
            End If
            Me.Cursor = Cursors.Default

        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Information)
        End Try
    End Sub

    Private Sub cmbname_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbname.SelectedIndexChanged
        Try
            Me.Cursor = Cursors.WaitCursor
            If cmbcat.SelectedItem <> "" And updatebool = False Then
                'Panel1.Enabled = True

                sql = "Select * from tblitems where category='" & cmbcat.SelectedItem & "' and itemname='" & cmbname.SelectedItem & "'"
                conn.Open()
                cmd = New SqlCommand(sql, conn)
                dr = cmd.ExecuteReader
                If dr.Read Then
                    'filename = dr(0).ToString
                    txtcode.Text = dr("itemcode").ToString
                    txtdes.Text = dr("description").ToString
                    txtprice.Text = Val(dr("price")).ToString("n2")
                    If dr("status") = 1 Then
                        txtstatus.Text = "Available"
                    Else
                        txtstatus.Text = "Not Available"
                    End If
                    txtcode.Enabled = True
                    txtdes.Enabled = True
                    txtprice.Enabled = True
                    txtstatus.Enabled = True
                Else
                    txtcode.Enabled = False
                    txtdes.Enabled = False
                    txtprice.Enabled = False
                    txtstatus.Enabled = False
                End If
                conn.Close()

                txtcode.Enabled = True
                txtdes.Enabled = True
                txtprice.Enabled = True
                txtstatus.Enabled = True

                cmbname.Enabled = True
                txtcode.ReadOnly = True
                txtdes.ReadOnly = True
                txtprice.ReadOnly = True
                txtstatus.ReadOnly = True


                Dim meon As Boolean = False
                For Each row As DataGridViewRow In grditems.Rows
                    If grditems.Rows(row.Index).Cells(2).Value = cmbname.SelectedItem Then

                        grditems.ClearSelection()
                        grditems.CurrentCell = grditems.Rows(row.Index).Cells(2)
                        grditems.Rows(row.Index).Selected = True

                        meon = True
                    End If
                Next
            End If

            Me.Cursor = Cursors.Default
        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Information)
        End Try
    End Sub

    Public Sub frmload()
        Try
            grditems.Columns.Add("itemid", "ID")
            grditems.Columns.Add("itemcode", "Item Code")
            grditems.Columns.Add("itemname", "Item Name")
            grditems.Columns.Add("description", "Description")
            grditems.Columns.Add("price", "Price")
            grditems.Columns.Add("category", "Category")
            grditems.Columns.Add("stock", "Stock")

            Dim dgvcCheckBox As New DataGridViewCheckBoxColumn()
            dgvcCheckBox.HeaderText = "Select"
            dgvcCheckBox.Width = 40
            grditems.Columns.Add(dgvcCheckBox)
            grditems.Columns(7).ReadOnly = False

            grditems.Columns(0).Visible = False
            'grditems.Columns(6).Visible = False
            grditems.Columns(1).Width = 100
            grditems.Columns(1).MinimumWidth = 100
            grditems.Columns(2).Width = 200
            grditems.Columns(2).MinimumWidth = 200
            grditems.Columns(3).Width = 120
            grditems.Columns(3).MinimumWidth = 20
            grditems.Columns(4).Width = 100
            grditems.Columns(4).MinimumWidth = 10
            grditems.Columns(5).Width = 130
            grditems.Columns(5).MinimumWidth = 30
            grditems.Columns(6).Width = 130
            grditems.Columns(6).MinimumWidth = 30
            grditems.Columns(7).Width = 100
            grditems.Columns(7).MinimumWidth = 10

            grditems.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grditems.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Information)
        End Try
    End Sub

    Public Sub reload()
        Try
            Me.Cursor = Cursors.WaitCursor
            cmbname.Enabled = False
            txtcode.Enabled = False
            txtdes.Enabled = False
            txtprice.Enabled = False
            txtstatus.Enabled = False

            cmbname.Visible = True
            cmbname.Text = ""
            txtname.Visible = False
            txtname.Text = ""
            txtcode.Text = ""
            txtdes.Text = ""
            txtprice.Text = ""
            txtstatus.Text = ""
            lblid.Text = ""
            txtdiscount.Text = ""
            lbls.Visible = True

            btnupdate.Text = "&Update Item"
            btnadditem.Text = "&Add Item"
            btnadditem.Enabled = True
            btnupdate.Enabled = True

            paneladd.Visible = False
            updatebool = False
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Information)
        End Try
    End Sub
    Public Function getSystemDate() As DateTime
        Try
            Dim dt As New DateTime()
            conn.Open()
            cmd = New SqlCommand("SELECT GETDATE()", conn)
            dr = cmd.ExecuteReader()
            While dr.Read
                dt = CDate(dr(0).ToString)
            End While
            conn.Close()
            Return dt
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Function
    Private Sub btnadditem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadditem.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            'check if complete fields
            If btnadditem.Text = "&Add Item" Then
                paneladd.Visible = True
                paneladd.Location = New System.Drawing.Point(6, 20)

                acmbcat.Focus()
                Try
                    acmbcat.Items.Clear()
                    sql = "Select * from tblcat where status='1'"
                    conn.Open()
                    cmd = New SqlCommand(sql, conn)
                    dr = cmd.ExecuteReader
                    While dr.Read
                        acmbcat.Items.Add(dr("category").ToString)
                    End While
                    conn.Close()
                Catch ex As Exception
                    Me.Cursor = Cursors.Default
                    MsgBox(ex.Message, MsgBoxStyle.Information)
                End Try

                btnupdate.Enabled = False
                btnadditem.Text = "&Add"
                btncancel.Visible = True
                lbls.Visible = False
            Else
                'passcode here
                'if true
                'try catch then sql=insert

                'If String.IsNullOrEmpty(txtdiscount.Text) Then
                '    MessageBox.Show("Discount % is empty", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                '    txtdiscount.Focus()
                '    Exit Sub
                'End If

                'Dim hasDuplicateItem As Boolean = False
                'connect()
                'cmd = New SqlCommand("SELECT itemid FROM tblitems WHERE itemname=@itemname;", conn)
                'cmd.Parameters.AddWithValue("@itemname", Trim(atxtname.Text))
                'dr = cmd.ExecuteReader
                'If dr.Read Then
                '    hasDuplicateItem = True
                'End If
                'disconnect()

                'If hasDuplicateItem Then
                '    MessageBox.Show("Item Name is already exist", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                '    atxtname.Focus()
                '    Exit Sub
                'End If

                'Dim hasDuplicateItemCode As Boolean = False
                'connect()
                'cmd = New SqlCommand("SELECT itemid FROM tblitems WHERE itemcode=@itemcode;", conn)
                'cmd.Parameters.AddWithValue("@itemcode", Trim(atxtname.Text))
                'dr = cmd.ExecuteReader
                'If dr.Read Then
                '    hasDuplicateItemCode = True
                'End If
                'disconnect()

                'If hasDuplicateItemCode Then
                '    MessageBox.Show("Item Code is already exist", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                '    atxtname.Focus()
                '    Exit Sub
                'End If


                If acmbcat.SelectedItem <> "" And Trim(atxtcode.Text) <> "" And Trim(atxtname.Text) <> "" And Trim(atxtprice.Text) <> "" Then
                    Try
                        Dim a As String = MsgBox("Are you sure you want to add item?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Add Item")
                        If a = vbYes Then

                            Dim deposit As Integer = 0
                            If chckboxdiscount.Checked Then
                                deposit = 1
                            Else
                                deposit = 0
                            End If

                            Dim discid As Integer = 0
                            conn.Open()
                            cmd = New SqlCommand("SELECT discid FROM tbldiscount_items WHERE itemid=(SELECT itemid FROM tblitems WHERE itemname=@item);", conn)
                            cmd.Parameters.AddWithValue("@item", Trim(atxtname.Text))
                            dr = cmd.ExecuteReader
                            If dr.Read Then
                                discid = CInt(dr("discid"))
                            End If
                            conn.Close()

                            If discid = 0 Then
                                conn.Open()
                                cmd = New SqlCommand("INSERT INTO tbldiscount_items (itemid,discount,datecreated,createdby) VALUES ((SELECT itemid FROM tblitems WHERE itemname=@item2),@discount,(SELECT GETDATE()),@createdby);", conn)
                                cmd.Parameters.AddWithValue("@item2", Trim(atxtname.Text))
                                cmd.Parameters.AddWithValue("@discount", txtdiscount.Text)
                                cmd.Parameters.AddWithValue("@createdby", login.username)
                                cmd.ExecuteNonQuery()
                                conn.Close()
                            End If

                            conn.Open()
                            sql = "Insert into tblitems (category, itemcode, itemname, description, price, datecreated, createdby, datemodified, modifiedby, status, discontinued,deposit) values('" & acmbcat.SelectedItem & "','" & Trim(atxtcode.Text) & "','" & Trim(atxtname.Text) & "','" & Trim(atxtdes.Text) & "','" & CDbl(Trim(atxtprice.Text)) & "',(SELECT GETDATE()),'" & login.cashier & "',(SELECT GETDATE()),'" & login.cashier & "','0','0','" & deposit & "')"
                            cmd = New SqlCommand(sql, conn) 'New OleDbCommand(sql, conn)
                            cmd.ExecuteNonQuery()
                            conn.Close()

                            getID()

                            conn.Open()
                            cmd = New SqlCommand("Insert into tblinvitems (invnum, itemcode, itemname, begbal,produce,good,reject,charge,productionin, itemin, totalav, ctrout, pullout, endbal, actualendbal, variance, shortover, status,convin,archarge,arsales,convout,transfer,area,arreject,supin,adjustmentin,reject_convin,reject_convout,reject_archarge,reject_transfer,reject_totalav,cancelin) values('" & inv_id & "', '" & atxtcode.Text & "', '" & atxtname.Text & "', '" & 0 & "','" & 0 & "','0','" & 0 & "','0','0','" & 0 & "', '" & 0 & "', '" & 0 & "', '" & 0 & "', '" & 0 & "', '0', '" & 0 & "', '" & "" & "','0','0','0','0','0','0','" & "Sales" & "','0','0','0','0','0','0','0','0','0')", conn)
                            cmd.ExecuteNonQuery()
                            conn.Close()

                            conn.Open()
                            'select itemid
                            sql = "Select Top 1 * from tblitems order by itemid DESC"
                            cmd = New SqlCommand(sql, conn)
                            dr = cmd.ExecuteReader
                            If dr.Read Then
                                iid = dr("itemid")
                            End If
                            conn.Close()

                            If chckboxdiscount.Checked Then
                                conn.Open()
                                cmd = New SqlCommand("INSERT  INTO tbldepositprice (itemid,price) VALUES ('" & iid & "','" & txtdeposit.Text & "');", conn)
                                cmd.ExecuteNonQuery()
                                conn.Close()
                            End If

                            If chckdiscount.Checked Then
                                conn.Open()
                                cmd = New SqlCommand("INSERT  INTO tbldiscitems (itemid) VALUES ((SELECT itemid FROM tblitems WHERE itemname=@itemname AND itemcode=@itemcode;));", conn)
                                cmd.Parameters.AddWithValue("@itemname", txtname.Text)
                                cmd.Parameters.AddWithValue("@itemcode", txtcode.Text)
                                cmd.ExecuteNonQuery()
                                conn.Close()
                            End If

                            'sql = "Insert into tblinventory (itemid, itemcode, datecreated, createdby, datemodified, modifiedby, status) values('" & iid & "','" & Trim(atxtcode.Text) & "','" & (Format(Date.Now, ("MM-dd-yyyy"))) & "','Administrator','" & (Format(Date.Now, ("MM-dd-yyyy"))) & "','Administrator','0')"
                            'cmd = New SqlCommand(sql, conn) 'New OleDbCommand(sql, conn)
                            'cmd.ExecuteNonQuery()
                            'cmd.Dispose()
                            Me.Cursor = Cursors.Default
                            MsgBox("Successfully Added", MsgBoxStyle.Information, "")
                            btnview.PerformClick()
                            btncancel.Visible = False
                            atxtcode.Text = ""
                            atxtdes.Text = ""
                            atxtname.Text = ""
                            atxtprice.Text = ""
                            chckboxdiscount.Checked = False
                            lbldeposit.Visible = False
                            txtdeposit.Text = ""
                            txtdeposit.Visible = False
                            paneldeposit.Visible = False
                            'reload()
                        Else
                            Me.Cursor = Cursors.Default
                            Exit Sub
                        End If
                    Catch ex As Exception
                        Me.Cursor = Cursors.Default
                        MsgBox(ex.Message, MsgBoxStyle.Information)
                    End Try
                Else
                    MsgBox("Complete the fields.", MsgBoxStyle.Exclamation, "")
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
                reload()
            End If
            'else
            'msgbox complete the fields
            'end if
            Me.Cursor = Cursors.Default
        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Information)
        End Try
    End Sub
    Public Sub getID()
        Dim id As String = ""
        Dim date_ As New DateTime()
        conn.Open()
        cmd = New SqlCommand("Select TOP 1 invnum,datecreated from tblinvsum WHERE area='" & "Sales" & "' order by invsumid DESC", conn)
        dr = cmd.ExecuteReader()
        If dr.Read() Then
            id = dr("invnum")
            date_ = CDate(dr("datecreated"))
        End If
        conn.Close()
        If date_.ToString("MM/dd/yyyy") = getSystemDate.ToString("MM/dd/yyyy") Then
            inv_id = id
        Else
            inv_id = "N/A"
        End If
    End Sub
    Private Sub btnupdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnupdate.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            If btnupdate.Text = "&Update Item" Then
                lbls.Visible = False
                If (grditems.SelectedCells.Count = 1 Or grditems.SelectedRows.Count = 1) Then
                Else
                    MsgBox("Select one only", MsgBoxStyle.Exclamation, "")
                    updatebool = False
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If

                Dim checkCell As DataGridViewCheckBoxCell = CType(grditems.Rows(grditems.CurrentRow.Index).Cells(7), DataGridViewCheckBoxCell)
                If chkhide.Checked = True Then
                    MsgBox("Cannot update discontinued item.", MsgBoxStyle.Exclamation, "")
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If

                updatebool = True

                lblcode.Text = grditems.Item(1, grditems.CurrentRow.Index).Value
                lblname.Text = grditems.Item(2, grditems.CurrentRow.Index).Value
                cmbname.Visible = False
                txtcode.Enabled = True
                txtdes.Enabled = True
                txtprice.Enabled = True
                txtname.Visible = True
                txtcode.ReadOnly = False
                txtdes.ReadOnly = False
                txtprice.ReadOnly = False
                txtname.ReadOnly = False
                'lblid.Text = grditems.Item(0, grditems.CurrentRow.Index).Value
                'txtcode.Text = grditems.Item(1, grditems.CurrentRow.Index).Value
                'txtname.Text = grditems.Item(2, grditems.CurrentRow.Index).Value
                'txtdes.Text = grditems.Item(3, grditems.CurrentRow.Index).Value
                'txtprice.Text = grditems.Item(4, grditems.CurrentRow.Index).Value
                'cmbcat.SelectedItem = StrConv(grditems.Item(5, grditems.CurrentRow.Index).Value.ToString, vbProperCase)
                'txtstatus.Text = grditems.Item(6, grditems.CurrentRow.Index).Value
                lblid.Text = grditems.CurrentRow.Cells("itemid").Value
                txtcode.Text = grditems.CurrentRow.Cells("itemcode").Value
                txtname.Text = grditems.CurrentRow.Cells("itemname").Value
                txtdes.Text = grditems.CurrentRow.Cells("description").Value
                txtprice.Text = grditems.CurrentRow.Cells("price").Value
                cmbcat.Text = grditems.CurrentRow.Cells("category").Value
                txtstatus.Text = grditems.CurrentRow.Cells("stock").Value


                'Dim discount As Double = 0.00
                'connect()
                'cmd = New SqlCommand("SELECT discount FROM tbldiscount_items WHERE itemid=(SELECT itemid FROM tblitems WHERE itemname=@itemname);", conn)
                'cmd.Parameters.AddWithValue("@itemname", grditems.CurrentRow.Cells("itemname").Value)
                'dr = cmd.ExecuteReader
                'If dr.Read Then
                '    discount = CDbl(dr("discount"))
                'End If
                'disconnect()
                'txtdiscount.Text = discount.ToString("n2")

                Dim c As Boolean = False, prc As Double = 0.0
                conn.Open()
                cmd = New SqlCommand("SELECT price FROM tbldepositprice WHERE itemid='" & lblid.Text & "';", conn)
                dr = cmd.ExecuteReader
                If dr.Read Then
                    c = True
                    prc = CDbl(dr("price"))
                End If
                conn.Close()
                If c Then
                    chckboxdiscount.Checked = True
                    lbldeposit.Visible = True
                    txtdeposit.Text = prc.ToString("n2")
                    txtdeposit.Visible = True
                    paneldeposit.Visible = True
                Else
                    chckboxdiscount.Checked = False
                    lbldeposit.Visible = False
                    txtdeposit.Text = prc.ToString("n2")
                    txtdeposit.Visible = False
                    paneldeposit.Visible = False
                End If

                Dim result As Boolean = False
                conn.Open()
                cmd = New SqlCommand("SELECT discid FROM tbldiscitems WHERE itemid=(SELECT itemid FROM tblitems WHERE itemname=@iname AND itemcode=@icode);", conn)
                cmd.Parameters.AddWithValue("@iname", txtname.Text)
                cmd.Parameters.AddWithValue("@icode", txtcode.Text)
                dr = cmd.ExecuteReader
                If dr.Read Then
                    result = True
                End If
                conn.Close()

                chckdiscount.Checked = result

                btnupdate.Text = "&Save Item"
                btnadditem.Enabled = False
                btncancel.Visible = True

            ElseIf btnupdate.Text = "&Save Item" Then
                'check if complete
                If cmbcat.SelectedItem <> "" And Trim(txtcode.Text) <> "" And Trim(txtname.Text) <> "" And Trim(txtprice.Text) <> "" Then
                    Dim a As String = MsgBox("Are you sure you want to save the item?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "")
                    If a = vbYes Then
                        'passcode here
                        'if true
                        'try catch then sql=update
                        confirm.ShowDialog()
                        If firmitems = True Then


                            'Dim discid As Integer = 0
                            'connect()
                            'cmd = New SqlCommand("SELECT discid FROM tbldiscount_items WHERE itemid=(SELECT itemid FROM tblitems WHERE itemname=@item);", conn)
                            'cmd.Parameters.AddWithValue("@item", Trim(txtname.Text))
                            'dr = cmd.ExecuteReader
                            'If dr.Read Then
                            '    discid = CInt(dr("discid"))
                            'End If
                            'disconnect()

                            'If discid = 0 Then
                            '    connect()
                            '    cmd = New SqlCommand("INSERT INTO tbldiscount_items (itemid,discount,datecreated,createdby) VALUES ((SELECT itemid FROM tblitems WHERE itemname=@item2),@discount,(SELECT GETDATE()),@createdby);", conn)
                            '    cmd.Parameters.AddWithValue("@item2", Trim(txtname.Text))
                            '    cmd.Parameters.AddWithValue("@discount", txtdiscount.Text)
                            '    cmd.Parameters.AddWithValue("@createdby", login.username)
                            '    cmd.ExecuteNonQuery()
                            '    disconnect()
                            'Else
                            '    connect()
                            '    cmd = New SqlCommand("UPDATE tbldiscount_items SET discount=@disc WHERE discid=@discid", conn)
                            '    cmd.Parameters.AddWithValue("@disc", CDbl(txtdiscount.Text))
                            '    cmd.Parameters.AddWithValue("@discid", discid)
                            '    cmd.ExecuteNonQuery()
                            '    disconnect()
                            'End If


                            sql = "Update tblitems set category='" & cmbcat.SelectedItem & "', itemcode='" & Trim(txtcode.Text) & "', itemname='" & Trim(txtname.Text) & "', description='" & Trim(txtdes.Text) & "', price='" & CDbl(Trim(txtprice.Text)) & "', datemodified=(SELECT GETDATE()), modifiedby='" & login.cashier & "' where itemid='" & lblid.Text & "' "
                            conn.Open()
                            cmd = New SqlCommand(sql, conn) 'New OleDbCommand(sql, conn)
                            cmd.ExecuteNonQuery()
                            conn.Close()

                            'update tblinvitems itemcode and itemname
                            sql = "Update tblinvitems set itemcode='" & Trim(txtcode.Text) & "', itemname='" & Trim(txtname.Text) & "' where itemcode='" & lblcode.Text & "'"
                            conn.Open()
                            cmd = New SqlCommand(sql, conn)
                            cmd.ExecuteNonQuery()
                            conn.Close()

                            'update tblimage name
                            sql = "Update tblimage set name='" & Trim(txtname.Text) & "' where name='" & lblname.Text & "'"
                            conn.Open()
                            cmd = New SqlCommand(sql, conn)
                            cmd.ExecuteNonQuery()
                            conn.Close()

                            'update tblorder itemname
                            sql = "Update tblorder set itemname='" & Trim(txtname.Text) & "' where itemname='" & lblname.Text & "'"
                            conn.Open()
                            cmd = New SqlCommand(sql, conn)
                            cmd.ExecuteNonQuery()
                            conn.Close()

                            'update tblgroupdisc itemname
                            sql = "Update tblgroupdisc set itemname='" & Trim(txtname.Text) & "',itemcode='" & Trim(txtcode.Text) & "' where itemname='" & lblname.Text & "'"
                            conn.Open()
                            cmd = New SqlCommand(sql, conn)
                            cmd.ExecuteNonQuery()
                            conn.Close()

                            sql = "Update tblgroupdisc set basedname='" & Trim(txtname.Text) & "',basedprice='" & Trim(txtprice.Text) & "' where basedname='" & lblname.Text & "'"
                            conn.Open()
                            cmd = New SqlCommand(sql, conn)
                            cmd.ExecuteNonQuery()
                            conn.Close()

                            If chckboxdiscount.Checked Then

                                Dim z As Boolean = False
                                conn.Open()
                                cmd = New SqlCommand("SELECT depid FROM tbldepositprice WHERE itemid='" & lblid.Text & "';", conn)
                                dr = cmd.ExecuteReader
                                If dr.Read Then
                                    z = True
                                End If
                                conn.Close()
                                If z Then
                                    conn.Open()
                                    cmd = New SqlCommand("UPDATE tbldepositprice SET price=@price WHERE itemid='" & lblid.Text & "';", conn)
                                    cmd.Parameters.AddWithValue("@price", txtdeposit.Text)
                                    cmd.ExecuteNonQuery()
                                    conn.Close()

                                    'conn.Open()
                                    'cmd = New SqlCommand("UPDATE tblitems SET deposit=1 WHERE itemid='" & lblid.Text & "';", conn)
                                    'cmd.ExecuteNonQuery()
                                    'conn.Close()
                                Else
                                    conn.Open()
                                    cmd = New SqlCommand("INSERT INTO tbldepositprice (itemid,price) VALUES(@itemid,@price);", conn)
                                    cmd.Parameters.AddWithValue("@itemid", lblid.Text)
                                    cmd.Parameters.AddWithValue("@price", txtdeposit.Text)
                                    cmd.ExecuteNonQuery()
                                    conn.Close()
                                End If

                            Else
                                'conn.Open()
                                'cmd = New SqlCommand("UPDATE tblitems SET deposit=0 WHERE itemid='" & lblid.Text & "';", conn)
                                'cmd.ExecuteNonQuery()
                                'conn.Close()

                                conn.Open()
                                cmd = New SqlCommand("DELETE FROM tbldepositprice WHERE itemid='" & lblid.Text & "';", conn)
                                cmd.ExecuteNonQuery()
                                conn.Close()
                            End If
                            MsgBox("Successfully Saved.", MsgBoxStyle.Information, "")
                        End If
                        discounted()
                        btnview.PerformClick()
                    End If
                Else
                    Me.Cursor = Cursors.Default
                    MsgBox("Complete the required fields.", MsgBoxStyle.Exclamation, "")
                    Exit Sub
                End If

                reload()
                btnupdate.Text = "&Update Item"
                btnadditem.Enabled = True
                btncancel.Visible = False
            End If
            Me.Cursor = Cursors.Default
        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information)
        End Try
    End Sub
    Public Sub discounted()
        If chckdiscount.Checked Then
            Dim z As Boolean = False
            conn.Open()
            cmd = New SqlCommand("SELECT discid FROM tbldiscitems WHERE itemid='" & lblid.Text & "';", conn)
            dr = cmd.ExecuteReader
            If dr.Read Then
                z = True
            End If
            conn.Close()
            If z Then

                conn.Open()
                cmd = New SqlCommand("DELETE FROM tbldiscitems WHERE itemid='" & lblid.Text & "';", conn)
                cmd.ExecuteNonQuery()
                conn.Close()
            Else
                conn.Open()
                cmd = New SqlCommand("INSERT INTO tbldiscitems (itemid) VALUES(@itemid);", conn)
                cmd.Parameters.AddWithValue("@itemid", lblid.Text)
                cmd.ExecuteNonQuery()
                conn.Close()
            End If
        Else
            conn.Open()
            cmd = New SqlCommand("DELETE FROM tbldiscitems WHERE itemid='" & lblid.Text & "';", conn)
            cmd.ExecuteNonQuery()
            conn.Close()
        End If
    End Sub
    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        Try
            reload()
            updatebool = False

            chckdiscount.Checked = False


            paneladd.Visible = False
            btnadditem.Text = "&Add Item"
            btncancel.Visible = False

            chckboxdiscount.Checked = False
            lbldeposit.Visible = False
            txtdeposit.Text = "0.00"
            txtdeposit.Visible = False
            paneldeposit.Visible = False
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Information)
        End Try
    End Sub

    Private Sub acmbcat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles acmbcat.SelectedIndexChanged
        If acmbcat.SelectedItem <> "" Then
            atxtcode.Enabled = True
            atxtdes.Enabled = True
            atxtname.Enabled = True
            atxtprice.Enabled = True
        End If
    End Sub

    Private Sub atxtcode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles atxtcode.KeyPress
        If Asc(e.KeyChar) = Windows.Forms.Keys.Enter Then
            btnadditem.PerformClick()
        End If
    End Sub

    Private Sub atxtcode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles atxtcode.Leave
        'CHECK IF EXIST NA
        Try
            If Trim(atxtcode.Text) <> "" Then
                sql = "Select * from tblitems where itemcode='" & Trim(atxtcode.Text) & "'"
                conn.Open()
                cmd = New SqlCommand(sql, conn)
                dr = cmd.ExecuteReader
                If dr.Read Then
                    MsgBox("Item Code '" & Trim(atxtcode.Text) & "' is already exist", MsgBoxStyle.Information, "")
                    atxtcode.Text = ""
                End If
                conn.Close()
            End If

        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Information)
        End Try
    End Sub

    Private Sub atxtcode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles atxtcode.TextChanged
        'Dim charactersDisallowed As String = "abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ 0123456789.-/"
        'Dim theText As String = atxtcode.Text
        'Dim Letter As String
        'Dim SelectionIndex As Integer = atxtcode.SelectionStart
        'Dim Change As Integer

        'For x As Integer = 0 To atxtcode.Text.Length - 1
        '    Letter = atxtcode.Text.Substring(x, 1)
        '    If Not charactersDisallowed.Contains(Letter) Then
        '        theText = theText.Replace(Letter, String.Empty)
        '        Change = 1
        '    End If
        'Next

        'atxtcode.Text = theText
        'atxtcode.Select(SelectionIndex - Change, 0)
    End Sub

    Private Sub atxtname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles atxtname.KeyPress
        If Asc(e.KeyChar) = Windows.Forms.Keys.Enter Then
            btnadditem.PerformClick()
        End If
    End Sub

    Private Sub atxtname_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles atxtname.Leave
        'CHECK IF EXIST NA
        Try
            If Trim(atxtname.Text) <> "" Then
                sql = "Select * from tblitems where itemname='" & Trim(atxtname.Text) & "'"
                conn.Open()
                cmd = New SqlCommand(sql, conn)
                dr = cmd.ExecuteReader
                If dr.Read Then
                    MsgBox("Item Name '" & Trim(atxtname.Text) & "' is already exist", MsgBoxStyle.Information, "")
                    atxtname.Text = ""
                End If
                conn.Close()
            End If

        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Information)
        End Try
    End Sub

    Private Sub atxtname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles atxtname.TextChanged
        'Dim charactersDisallowed As String = "abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ 0123456789.-/"
        'Dim theText As String = atxtname.Text
        'Dim Letter As String
        'Dim SelectionIndex As Integer = atxtname.SelectionStart
        'Dim Change As Integer

        'For x As Integer = 0 To atxtname.Text.Length - 1
        '    Letter = atxtname.Text.Substring(x, 1)
        '    If Not charactersDisallowed.Contains(Letter) Then
        '        theText = theText.Replace(Letter, String.Empty)
        '        Change = 1
        '    End If
        'Next

        'atxtname.Text = theText
        'atxtname.Select(SelectionIndex - Change, 0)
    End Sub

    Private Sub atxtdes_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles atxtdes.TextChanged
        'Dim charactersDisallowed As String = "abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ 0123456789.-/"
        'Dim theText As String = atxtdes.Text
        'Dim Letter As String
        'Dim SelectionIndex As Integer = atxtdes.SelectionStart
        'Dim Change As Integer

        'For x As Integer = 0 To atxtdes.Text.Length - 1
        '    Letter = atxtdes.Text.Substring(x, 1)
        '    If Not charactersDisallowed.Contains(Letter) Then
        '        theText = theText.Replace(Letter, String.Empty)
        '        Change = 1
        '    End If
        'Next

        'atxtdes.Text = theText
        'atxtdes.Select(SelectionIndex - Change, 0)
    End Sub

    Private Sub atxtprice_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles atxtprice.KeyPress
        If Asc(e.KeyChar) = Windows.Forms.Keys.Enter Then
            btnadditem.PerformClick()
        End If

        If Asc(e.KeyChar) = 46 And Trim(atxtprice.Text) <> "" And atxtprice.Text.Contains(".") = False Then

        ElseIf Asc(e.KeyChar) = 46 And Trim(atxtprice.Text) <> "" And atxtprice.Text.Contains(".") = True Then
            e.Handled = True
        End If
    End Sub

    Private Sub atxtprice_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles atxtprice.Leave
        Dim pr As Double = Val(atxtprice.Text)
        atxtprice.Text = pr.ToString("n2")
    End Sub

    Private Sub atxtprice_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles atxtprice.TextChanged
        'Dim charactersDisallowed As String = "0123456789."
        'Dim theText As String = atxtprice.Text
        'Dim Letter As String
        'Dim SelectionIndex As Integer = atxtprice.SelectionStart
        'Dim Change As Integer

        'For x As Integer = 0 To atxtprice.Text.Length - 1
        '    Letter = atxtprice.Text.Substring(x, 1)
        '    If Not charactersDisallowed.Contains(Letter) Then
        '        theText = theText.Replace(Letter, String.Empty)
        '        Change = 1
        '    End If
        'Next

        'atxtprice.Text = theText
        'atxtprice.Select(SelectionIndex - Change, 0)
    End Sub

    Private Sub txtprice_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtprice.Leave
        'Dim pr As Double = Val(txtprice.Text)
        'txtprice.Text = pr.ToString("n2")
        'If btnadditem.Enabled = True Then
        '    btnadditem.Focus()
        'Else
        '    btnupdate.Focus()
        'End If
    End Sub

    Private Sub grditems_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grditems.CellContentClick
        Try
            'check kung may chineck nga sa grditems then ska lng sya pde i enabled

            If grditems.CurrentCell.ColumnIndex = 7 Then
                Dim checkCell As DataGridViewCheckBoxCell = CType(grditems.Rows(grditems.CurrentRow.Index).Cells(7), DataGridViewCheckBoxCell)
                Button1.PerformClick()
                If checkCell.Value = False And grditems.Rows(grditems.CurrentRow.Index).Cells(6).Value = "Not Available" Then
                    'check if gamit sya sa ibang tbl ng database
                    If chkhide.Checked = False Then
                        sql = "Select * from tblgroupdisc where (itemname='" & grditems.Rows(grditems.CurrentRow.Index).Cells(2).Value & "' or basedname='" & grditems.Rows(grditems.CurrentRow.Index).Cells(2).Value & "') and status='1'"
                        conn.Open()
                        cmd = New SqlCommand(sql, conn)
                        dr = cmd.ExecuteReader
                        If dr.Read Then
                            MsgBox("Cannot discontinue item. Item is use in senior/pwd discount for group meals.", MsgBoxStyle.Exclamation, "")
                        Else
                            checkCell.Value = True
                        End If
                        conn.Close()
                    Else
                        'check first ung category 
                        sql = "Select * from tblcat where category='" & grditems.Rows(grditems.CurrentRow.Index).Cells(5).Value & "' and status='0'"
                        conn.Open()
                        cmd = New SqlCommand(sql, conn)
                        dr = cmd.ExecuteReader
                        If dr.Read Then
                            MsgBox("Cannot continue item. Category is deactivated.", MsgBoxStyle.Exclamation, "")
                        End If
                        conn.Close()

                        checkCell.Value = True
                    End If
                    Me.Cursor = Cursors.Default

                ElseIf checkCell.Value = False And grditems.Rows(grditems.CurrentRow.Index).Cells(6).Value <> "Not Available" Then
                    MsgBox("Cannot discontinue items with available status.", MsgBoxStyle.Exclamation, "")
                    checkCell.Value = False
                Else
                    checkCell.Value = False
                End If
            End If
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information)
        End Try
    End Sub

    Private Sub grditems_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grditems.CellValueChanged
        Try
            Exit Sub
            If grditems.Columns(e.ColumnIndex).HeaderText = "Discontinued" And grditems.RowCount <> 0 And grditems.CurrentCell.ColumnIndex = 7 Then
                Dim checkCell As DataGridViewCheckBoxCell = CType(grditems.Rows(e.RowIndex).Cells(7), DataGridViewCheckBoxCell)
                Button1.PerformClick()
                If checkCell.Value = True Then
                    'MsgBox("true")
                    'update tblitems discontinue status
                    sql = "Update tblitems set discontinued='1' where itemcode='" & grditems.Rows(grditems.CurrentRow.Index).Cells(1).Value.ToString & "'"
                    conn.Open()
                    cmd = New SqlCommand(sql, conn) 'New OleDbCommand(sql, conn)
                    cmd.ExecuteNonQuery()
                    conn.Close()
                Else
                    'MsgBox("false")
                    sql = "Update tblitems set discontinued='0' where itemcode='" & grditems.Rows(grditems.CurrentRow.Index).Cells(1).Value.ToString & "'"
                    conn.Open()
                    cmd = New SqlCommand(sql, conn) 'New OleDbCommand(sql, conn)
                    cmd.ExecuteNonQuery()
                    conn.Close()
                End If
                grditems.Invalidate()
            End If

        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            'MsgBox(ex.Message, MsgBoxStyle.Information)
        End Try
    End Sub

    'Private Sub txtcode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcode.KeyPress
    '    If Asc(e.KeyChar) = Windows.Forms.Keys.Enter Then
    '        btnupdate.PerformClick()
    '    End If
    'End Sub

    'Private Sub txtcode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcode.TextChanged
    '    Dim charactersDisallowed As String = "abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ 0123456789.-/"
    '    Dim theText As String = txtcode.Text
    '    Dim Letter As String
    '    Dim SelectionIndex As Integer = txtcode.SelectionStart
    '    Dim Change As Integer

    '    For x As Integer = 0 To txtcode.Text.Length - 1
    '        Letter = txtcode.Text.Substring(x, 1)
    '        If Not charactersDisallowed.Contains(Letter) Then
    '            theText = theText.Replace(Letter, String.Empty)
    '            Change = 1
    '        End If
    '    Next

    '    txtcode.Text = theText
    '    txtcode.Select(SelectionIndex - Change, 0)
    'End Sub

    'Private Sub txtname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtname.TextChanged
    '    Dim charactersDisallowed As String = "abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ 0123456789.-/"
    '    Dim theText As String = txtname.Text
    '    Dim Letter As String
    '    Dim SelectionIndex As Integer = txtname.SelectionStart
    '    Dim Change As Integer

    '    For x As Integer = 0 To txtname.Text.Length - 1
    '        Letter = txtname.Text.Substring(x, 1)
    '        If Not charactersDisallowed.Contains(Letter) Then
    '            theText = theText.Replace(Letter, String.Empty)
    '            Change = 1
    '        End If
    '    Next

    '    txtname.Text = theText
    '    txtname.Select(SelectionIndex - Change, 0)
    'End Sub

    'Private Sub txtprice_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtprice.TextChanged
    '    Dim charactersDisallowed As String = "0123456789."
    '    Dim theText As String = txtprice.Text
    '    Dim Letter As String
    '    Dim SelectionIndex As Integer = txtprice.SelectionStart
    '    Dim Change As Integer

    '    For x As Integer = 0 To txtprice.Text.Length - 1
    '        Letter = txtprice.Text.Substring(x, 1)
    '        If Not charactersDisallowed.Contains(Letter) Then
    '            theText = theText.Replace(Letter, String.Empty)
    '            Change = 1
    '        End If
    '    Next

    '    txtprice.Text = theText
    '    txtprice.Select(SelectionIndex - Change, 0)
    'End Sub
    Private Sub btnview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.Click
        getID()
        reload()
        loadcat()
        grditems.Columns.Clear()
        grditems.Rows.Clear()
        frmload()
        btnselect.Text = "Check All"
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim i As Integer = 0
            If chkhide.Checked = True Then
                sql = "Select a.itemid,a.category,a.itemname,a.itemcode,a.description,a.price,b.endbal from tblitems a INNER JOIN tblinvitems b ON a.itemname = b.itemname  WHERE a.discontinued='1' AND b.invnum=@invnum"
            Else
                sql = "Select a.itemid,a.category,a.itemname,a.itemcode,a.description,a.price,b.endbal from tblitems a INNER JOIN tblinvitems b ON a.itemname = b.itemname WHERE a.discontinued='0' AND b.invnum=@invnum"
            End If

            If cmbview.SelectedItem = "" And cmbview.Items.Count <> 0 Then
                sql = sql & " order by a.category, a.itemcode"
            ElseIf cmbview.SelectedItem <> "All" And cmbview.Items.Count <> 0 Then
                sql = sql & " and a.category='" & cmbview.SelectedItem & "' order by a.category, a.itemcode"
            Else
                sql = sql & " order by a.category, a.itemcode"
                cmbview.Items.Clear()
            End If

            conn.Open()
            cmd = New SqlCommand(sql, conn)
            cmd.Parameters.AddWithValue("@invnum", inv_id)
            dr = cmd.ExecuteReader
            While dr.Read
                grditems.Rows.Add()
                grditems.Item(0, i).Value = dr("itemid")
                grditems.Item(1, i).Value = dr("itemcode")
                grditems.Item(2, i).Value = dr("itemname")
                grditems.Item(3, i).Value = dr("description")
                grditems.Item(4, i).Value = dr("price")
                grditems.Columns(4).DefaultCellStyle.Format = "n2"
                grditems.Item(5, i).Value = dr("category")

                If dr("endbal") > 0 Then
                    grditems.Item(6, i).Value = "Available"
                Else
                    grditems.Item(6, i).Value = "Not Available"
                End If

                Dim checkCell As DataGridViewCheckBoxCell = CType(grditems.Rows(i).Cells(7), DataGridViewCheckBoxCell)
                checkCell.Value = False

                i += 1
            End While
            conn.Close()

            sql = "Select * from tblcat order by category"
            conn.Open()
            cmd = New SqlCommand(sql, conn)
            dr = cmd.ExecuteReader
            While dr.Read
                If Not cmbview.Items.Contains(StrConv(dr("category"), VbStrConv.ProperCase)) Then
                    cmbview.Items.Add(dr("category"))
                End If
            End While
            conn.Close()


            '//inv()

            If i <> 0 Then
                btnupdate.Enabled = True
            Else
                btnupdate.Enabled = False
            End If

            If btnadditem.Text = "&Add Item" Then
                btncancel.Visible = False
            Else
                btncancel.Visible = True
            End If

            If cmbview.Items.Count <> 0 And Not cmbview.Items.Contains("All") Then
                cmbview.Items.Add("All")
            End If

            Me.Cursor = Cursors.Default
        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Information)
        End Try
    End Sub

    Public Sub inv()
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim invsumnum As String = ""
            sql = "Select TOP 1 * from tblinvsum order by invsumid DESC"
            conn.Open()
            cmd = New SqlCommand(sql, conn)
            dr = cmd.ExecuteReader
            If dr.Read Then
                invsumnum = dr("invnum")
            End If
            conn.Close()
            ''     conn.Open()
            For Each row As DataGridViewRow In grditems.Rows
                Dim stat As Integer = 0
                sql = "Select TOP 1 * from tblinvitems where itemcode='" & grditems.Rows(row.Index).Cells(1).Value & "' and invnum='" & invsumnum & "' order by invid DESC"
                conn.Open()
                cmd = New SqlCommand(sql, conn)
                dr = cmd.ExecuteReader
                If dr.Read Then
                    If dr("endbal") <> 0 Then
                        grditems.Rows(row.Index).Cells(6).Value = "Available"
                        stat = 1
                    Else
                        grditems.Rows(row.Index).Cells(6).Value = "Not Available"
                        stat = 0
                    End If
                End If
                conn.Close()

                sql = "Update tblitems set status='" & stat & "' where itemcode='" & grditems.Rows(row.Index).Cells(1).Value & "'"
                conn.Open()
                cmd = New SqlCommand(sql, conn)
                cmd.ExecuteNonQuery()
                conn.Close()
            Next

            Me.Cursor = Cursors.Default

        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Information)
        End Try
    End Sub

    Private Sub btnprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnprint.Click
        Me.Cursor = Cursors.WaitCursor
        itemsprintprev.Close()
        itemsprint.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub chkhide_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkhide.CheckedChanged
        btnselect.Text = "Check All"
        If chkhide.Checked = True Then
            btndiscon.Text = "Continue"
            btndiscon.Enabled = True
        Else
            btndiscon.Text = "Discontinue"
        End If
        btnview.PerformClick()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        bundle.ShowDialog()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        importitems.ShowDialog()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnselect.Click
        Dim ChechboxColumnIndex As Integer = 7  '<-- putt the right index here
        If btnselect.Text = "Check All" Then
            cmbgroup.Items.Clear()
            sql = "Select * from tblgroupdisc where status='1'"
            conn.Open()
            cmd = New SqlCommand(sql, conn)
            dr = cmd.ExecuteReader
            While dr.Read
                cmbgroup.Items.Add(dr("itemname"))
                If Not cmbgroup.Items.Contains(dr("basedname")) Then
                    cmbgroup.Items.Add(dr("basedname"))
                End If
            End While
            dr.Dispose()
            conn.Close()

            cmbcategory.Items.Clear()
            sql = "Select * from tblcat where status='0'"
            conn.Open()
            cmd = New SqlCommand(sql, conn)
            dr = cmd.ExecuteReader
            While dr.Read
                cmbcategory.Items.Add(dr("category"))
            End While
            conn.Close()

            For i As Integer = 0 To grditems.RowCount - 1
                If CBool(grditems.Rows(i).Cells(ChechboxColumnIndex).Value) = False And grditems.Rows(i).Cells(6).Value = "Not Available" Then
                    'check if gamit sya sa ibang tbl ng database
                    If Not cmbgroup.Items.Contains(grditems.Rows(i).Cells(2).Value) Then
                        grditems.Rows(i).Cells(ChechboxColumnIndex).Value = True
                    Else
                        Me.Cursor = Cursors.Default
                    End If

                    If cmbcategory.Items.Contains(grditems.Rows(i).Cells(5).Value) Then
                        grditems.Rows(i).Cells(ChechboxColumnIndex).Value = False
                    End If
                End If
            Next
            btnselect.Text = "Uncheck All"
        Else
            For i As Integer = 0 To grditems.RowCount - 1
                If CBool(grditems.Rows(i).Cells(ChechboxColumnIndex).Value) = True Then
                    grditems.Rows(i).Cells(ChechboxColumnIndex).Value = False
                End If
            Next
            btnselect.Text = "Check All"
        End If
    End Sub

    Private Sub btndiscon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndiscon.Click
        Try
            btnselect.Text = "Check All"
            Dim meron As Boolean = False
            For Each row In grditems.Rows
                Dim checkCell As DataGridViewCheckBoxCell = CType(grditems.Rows(row.index).Cells(7), DataGridViewCheckBoxCell)
                Button1.PerformClick()
                If checkCell.Value = True Then
                    meron = True
                End If
            Next

            If meron = False Then
                MsgBox("Select items first.", MsgBoxStyle.Exclamation, "")
                Exit Sub
            End If

            If btndiscon.Text = "Discontinue" Then
                Dim a As String = MsgBox("Are you sure you want to discontinue items?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "")
                If a = vbYes Then
                    firmitems = False
                    confirm.ShowDialog()
                    If firmitems = True Then
                        For Each row In grditems.Rows
                            Dim checkCell As DataGridViewCheckBoxCell = CType(grditems.Rows(row.index).Cells(7), DataGridViewCheckBoxCell)
                            Button1.PerformClick()
                            If checkCell.Value = True And grditems.Rows(row.index).Cells(6).Value = "Not Available" Then
                                sql = "Update tblitems set discontinued='1' where itemcode='" & grditems.Rows(row.index).Cells(1).Value.ToString & "'"
                                conn.Open()
                                cmd = New SqlCommand(sql, conn) 'New OleDbCommand(sql, conn)
                                cmd.ExecuteNonQuery()
                                conn.Close()
                            End If
                        Next
                    End If
                    firmitems = False
                End If
            Else
                'check category if active


                Dim a As String = MsgBox("Are you sure you want to continue items?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "")
                If a = vbYes Then
                    firmitems = False
                    confirm.ShowDialog()
                    If firmitems = True Then
                        getID()
                        For Each row In grditems.Rows
                            Dim checkCell As DataGridViewCheckBoxCell = CType(grditems.Rows(row.index).Cells(7), DataGridViewCheckBoxCell)
                            Button1.PerformClick()
                            If checkCell.Value = True And grditems.Rows(row.index).Cells(6).Value = "Not Available" Then
                                sql = "Update tblitems set discontinued='0' where itemcode='" & grditems.Rows(row.index).Cells(1).Value.ToString & "'"
                                conn.Open()
                                cmd = New SqlCommand(sql, conn) 'New OleDbCommand(sql, conn)
                                cmd.ExecuteNonQuery()
                                conn.Close()


                                Dim result As Boolean = False
                                conn.Open()
                                cmd = New SqlCommand("SELECT invid FROM tblinvitems WHERE invnum@=invnum AND itemname=@itemname;", conn)
                                cmd.Parameters.AddWithValue("@invnum", inv_id)
                                cmd.Parameters.AddWithValue("@itemname", grditems.Rows(row.index).Cells("itemname").Value)
                                dr = cmd.ExecuteReader
                                If dr.Read Then
                                    result = True
                                End If
                                conn.Close()
                                If result = False Then
                                    conn.Open()
                                    cmd = New SqlCommand("Insert into tblinvitems (invnum, itemcode, itemname, begbal,produce,good,reject,charge,productionin, itemin, totalav, ctrout, pullout, endbal, actualendbal, variance, shortover, status,convin,archarge,arsales,convout,transfer,area,arreject,supin,adjustmentin,reject_convin,reject_convout,reject_archarge,reject_transfer,reject_totalav,cancelin) values('" & inv_id & "', '" & grditems.Rows(row.index).Cells("itemcode").Value.ToString & "', '" & grditems.Rows(row.index).Cells("itemname").Value.ToString & "', '" & 0 & "','" & 0 & "','0','" & 0 & "','0','0','" & 0 & "', '" & 0 & "', '" & 0 & "', '" & 0 & "', '" & 0 & "', '0', '" & 0 & "', '" & 0 & "','0','0','0','0','0','0','" & "Sales" & "','0','0','0','0','0','0','0','0','0')", conn)
                                    cmd.ExecuteNonQuery()
                                    conn.Close()
                                End If


                            End If
                        Next
                    End If
                    firmitems = False
                End If
            End If
            btnview.PerformClick()

            Me.Cursor = Cursors.Default
        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Information)
        End Try
    End Sub

    Private Sub cmbview_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbview.SelectedIndexChanged
        Try
            btnview.PerformClick()

            Me.Cursor = Cursors.Default
        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Information)
        End Try
    End Sub

    Private Sub chckboxdiscount_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chckboxdiscount.CheckedChanged
        If chckboxdiscount.Checked Then
            lbldeposit.Visible = True
            txtdeposit.Visible = True
            paneldeposit.Visible = True
        Else
            lbldeposit.Visible = False
            txtdeposit.Visible = False
            paneldeposit.Visible = False
        End If
    End Sub

    Private Sub chckdiscount_CheckedChanged(sender As Object, e As EventArgs) Handles chckdiscount.CheckedChanged

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub btnimport_Click(sender As Object, e As EventArgs) Handles btnimport.Click
        Dim frm As New import_itemcode
        frm.ShowDialog()
        btnview.PerformClick()
    End Sub
End Class