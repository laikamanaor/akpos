Imports System.IO
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Text
Imports System.Globalization
Imports AK_POS.pos_class
Imports AK_POS.user_class
Imports AK_POS.connection_class
Public Class mainmenu
    Dim cc As New connection_class
    Dim sql As String
    Dim conn As New SqlConnection(cc.conString)
    Dim dr As SqlDataReader
    Dim cmd As SqlCommand
    Dim transaction As SqlTransaction
    Dim dt As Integer = 0
    Dim lasttext As String
    Dim iftxt As Integer = 0
    Dim lastdgv As String
    Public activeTextBox As TextBox
    Public clickbtn As Button
    Public Shared voidd As Boolean = False
    Dim culture As CultureInfo = Nothing
    Dim tempamt As Double
    Public counters As Boolean = False
    Public ornum As String = ""
    Dim based As Double = 0, yesbased As Boolean = False, ibabawas As Double = 0
    Dim ordernum As String = ""
    Public cas As String = ""
    Public cas2 As String = ""

    Dim identify_area As String = ""
    Public amt As String = ""
    Public adpay As Integer = 0
    Dim inv_id As String = ""

    Dim ar_number As String = ""
    Dim onee As Integer = 0
    Public cSub As Double = 0, cDisType As String = 0, cLess As Double = 0, cDelCharge As Double = 0, cGc As Double = 0, returnnum As String = "", apdepamt As Double = 0.0, tendertype As String = "", servicetype As String = "", apdep_ans As String = ""

    Public sales_ans As String = "", order_id As Integer = 0
    Public Shared cnfrm3 As Boolean = False
    Public Shared free_val As Boolean = False

    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    Dim toggle_max As Boolean = True
    Dim posc As New pos_class(), userc As New user_class()
    Public Function decryptConString() As String
        Dim base64encoded As String = File.ReadAllText("connectionstring.txt")
        Dim data As Byte() = System.Convert.FromBase64String(base64encoded)
        Return System.Text.ASCIIEncoding.ASCII.GetString(data)
    End Function

    Private Sub mainmenu_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        loadItems()
        If login2.wrkgrp = "Cashier" Then
            btncutoff.Enabled = True
        ElseIf login2.wrkgrp = "Sales" Then
            btncutoff.Enabled = False
        End If
        getReturnNum()
        Me.Height = Screen.PrimaryScreen.WorkingArea.Height
        Me.Width = Screen.PrimaryScreen.WorkingArea.Width
        Me.Location = Screen.PrimaryScreen.WorkingArea.Location
    End Sub

    Private Sub mainmenu_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F1 Then
            btnok.PerformClick()
        ElseIf e.KeyCode = Keys.F2 And login2.wrkgrp <> "Cashier" Then
            btnlast10.PerformClick()
        ElseIf e.KeyCode = Keys.F3 Then
            btncancel.PerformClick()
        ElseIf e.KeyCode = Keys.F4 Then
            btnvoid.PerformClick()
        ElseIf e.KeyCode = Keys.F5 Then
            btngc.PerformClick()
        ElseIf e.KeyCode = Keys.F6 Then
            If chkkey.Checked Then
                chkkey.Checked = False
            Else
                chkkey.Checked = True
            End If
        ElseIf e.KeyCode = Keys.Escape Then
            Me.Dispose()
        ElseIf e.KeyCode = Keys.F7 Then
            txtname.Focus()
        ElseIf e.KeyCode = Keys.F8 Then
            txttendered.Focus()
        End If
    End Sub
    Public Sub load_customers()
        Try
            conn.Open()
            Dim auto As New AutoCompleteStringCollection()
            cmd = New SqlCommand("SELECT name FROM tblcustomers WHERE status='1' AND type=@type;", conn)
            cmd.Parameters.AddWithValue("@type", cmbtype.Text)
            dr = cmd.ExecuteReader()
            While dr.Read()
                auto.Add(dr("name"))
            End While
            txtname.AutoCompleteCustomSource = auto
            conn.Close()
            conn.Open()
            cmd = New SqlCommand("SELECT type FROM tblcustomers WHERE name='" & txtname.Text & "';", conn)
            dr = cmd.ExecuteReader
            If dr.Read And rbAR.Checked Then
                cmbtype.Text = dr("type")
            End If
            conn.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Public Function getSystemDate() As DateTime
        Try
            Dim dt As New DateTime()
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If

            Dim date1 As DateTime = dtdate.Text
            Dim date2 As DateTime = DateTime.Now

            conn.Open()
            cmd = New SqlCommand("SELECT GETDATE()", conn)
            date2 = cmd.ExecuteScalar
            conn.Close()

            Dim ts As TimeSpan = date2.Subtract(date1)
            conn.Open()
            cmd = New SqlCommand("SELECT GETDATE() " & IIf(login2.wrkgrp = "LC Accounting", "- " & ts.Days, ""), conn)
            dt = cmd.ExecuteScalar
            conn.Close()
            Return dt
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Function

    Public Sub getID()
        Try
            Dim id As String = ""
            Dim date_ As New DateTime()
            Dim query As String = ""
            If login2.wrkgrp = "LC Accounting" Then
                query = "Select TOP 1 invnum from tblinvsum WHERE area='Sales' AND CAST(datecreated AS date)='" & dtdate.Text & "' order by invsumid DESC"
            ElseIf login2.wrkgrp = "Cashier" Then
                query = "Select TOP 1 invnum from tblinvsum WHERE area='Sales' AND CAST(datecreated AS date)=(SELECT transdate FROM tbltransaction2 WHERE orderid=" & order_id & ") order by invsumid DESC"
            Else
                query = "Select TOP 1 invnum from tblinvsum WHERE area='Sales' order by invsumid DESC"
            End If
            conn.Open()
            cmd = New SqlCommand(query, conn)
            id = cmd.ExecuteScalar
            conn.Close()
            inv_id = id
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub mainmenu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.KeyPreview = True
            If login2.wrkgrp = "Sales" Or login2.wrkgrp = "Manager" Then
                btnlast10.Visible = True
            Else
                btnlast10.Visible = False
            End If

            getID()
            If login2.wrkgrp = "Cashier" Then
                identify_area = "Sales"
                btncutoff.Enabled = True
            Else
                btncutoff.Enabled = False
                identify_area = login2.wrkgrp
            End If
            If cas = "Sales" Or cas = "Wholesale" Then
                lbltrnum.Visible = False
                Label22.Visible = False
                btnback.Enabled = False
                loadordernum()
                loadtransnum()
                load_customers()
                'MessageBox.Show("cAs sales wholesale")
            ElseIf cas = "Cashier" Then
                loadtransnum()
                lbltrnum.Visible = True
                Label22.Visible = True
                btnback.Enabled = True
                amount()
                computetotal()
                load_customers()
            End If
            If login2.wrkgrp <> "Cashier" Then
                rbtake.Checked = True
                rbcash.Checked = True
                txtname.Text = "CASH"
            End If

            Me.TableLayoutPanel1.SetRowSpan(Panel2, 2)

            'grd.Columns(0).ReadOnly = True

            grd.Columns(4).ReadOnly = False
            grd.Columns(3).ReadOnly = True
            grd.Columns(2).ReadOnly = True
            grd.Columns("discountpercent").ReadOnly = False
            grd.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grd.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grd.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            grd.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            viewcat()
            viewdiscount()

            If cas.Equals("Cashier") And cas2.Equals("Confirm") Then
                grd.ReadOnly = True
                Panel5.Visible = False
                Return
            End If
            'If cas = "Cashier" Then
            '    ''chack if inventory is new
            '    'sql = "Select TOP 1 * from tblinvsum WHERE area='" & "Sales" & "' order by invsumid DESC"
            '    'conn.Open()
            '    'cmd = New SqlCommand(sql, conn)
            '    'dr = cmd.ExecuteReader
            '    'If dr.Read Then
            '    '    If dr("verify") = 1 Then
            '    '        MsgBox("Create new inventory of items first to continue.", MsgBoxStyle.Exclamation, "")
            '    '        Panel4.Enabled = False
            '    '        Panel5.Enabled = False
            '    '        Panel8.Enabled = False
            '    '        Panel9.Enabled = False
            '    '        Panel17.Enabled = False
            '    '        Me.Cursor = Cursors.Default
            '    '        conn.Close()
            '    '        Exit Sub
            '    '    Else
            '    '        If dr("invdate") <> getSystemDate.ToString("MM/dd/yyyy") Then
            '    '            MsgBox("Verify the previous inventory first, then, create new inventory of items to continue.", MsgBoxStyle.Exclamation, "")
            '    '            Panel4.Enabled = False
            '    '            Panel5.Enabled = False
            '    '            Panel8.Enabled = False
            '    '            Panel9.Enabled = False
            '    '            Panel17.Enabled = False
            '    '            Me.Cursor = Cursors.Default
            '    '            conn.Close()
            '    '            Exit Sub
            '    '        End If
            '    '        Panel4.Enabled = True
            '    '        Panel5.Enabled = True
            '    '        Panel8.Enabled = True
            '    '        Panel9.Enabled = True
            '    '        Panel17.Enabled = True
            '    '    End If
            '    'Else
            '    '    MsgBox("Create new inventory of items first to continue.", MsgBoxStyle.Exclamation, "")
            '    '    Panel4.Enabled = False
            '    '    Panel5.Enabled = False
            '    '    Panel8.Enabled = False
            '    '    Panel9.Enabled = False
            '    '    Panel17.Enabled = False
            '    '    conn.Close()
            '    '    Exit Sub
            '    'End If
            '    'conn.Close()
            'End If


            If pos_dialog.ans = "Coffee Shop" Or pos_dialog.ans = "Wholesale" Then
                grd.Columns("discountpercent").ReadOnly = False
            Else
                grd.Columns("discountpercent").ReadOnly = True
            End If

            If login2.wrkgrp = "Cashier" Then
                Label12.Visible = True
                txtgc.Visible = True
                btngc.Visible = True
            Else
                Label12.Visible = False
                txtgc.Visible = False
                btngc.Visible = False
            End If

            ' defaultload()
            Me.Cursor = Cursors.Default
            dtdate.Text = getSystemDate.ToString("MM/dd/yyyy")
            dtdate.MaxDate = getSystemDate()
            paneldate.Visible = IIf(login2.wrkgrp = "LC Accounting", True, False)
        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information)
        End Try
    End Sub

    Private Sub btnrefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrefresh.Click
        viewcat()
        viewdiscount()
        If grd.Rows.Count = 0 Then
            defaultload()
        Else
            MsgBox("Customer order list is not empty. Cancel the previous transaction first.", MsgBoxStyle.Critical, "")
        End If
    End Sub

    Public Sub viewcat()
        Try
            Dim btncat(100) As Button
            Dim ctr As Integer = 0

            If pos_dialog.ans = "Coffee Shop" Then
                sql = "Select * from tblcat where status='1' AND category='Coffee Shop' OR category='Beverages' or category='Breads' order by category"
            Else
                sql = "Select * from tblcat where status='1' AND Not category='Coffee Shop' order by category"
            End If
            conn.Open()
            cmd = New SqlCommand(sql, conn)
            dr = cmd.ExecuteReader
            While dr.Read
                ctr += 1
                btncat(ctr) = New Button()
                btncat(ctr).Width = 100
                btncat(ctr).Height = 30
                btncat(ctr).Text = dr(1).ToString
                btncat(ctr).Tag = dr(0)
                btncat(ctr).Font = New Drawing.Font("Arial", 9.5)
                btncat(ctr).Font = New Font(btncat(ctr).Font, FontStyle.Bold)
                btncat(ctr).ForeColor = Color.White
                btncat(ctr).FlatStyle = FlatStyle.Flat
                btncat(ctr).FlatAppearance.BorderSize = 0
                btncat(ctr).Cursor = Cursors.Hand
                Dim MyColor(5) As Color

                MyColor(1) = Color.FromArgb(223, 233, 84)
                MyColor(2) = Color.FromArgb(158, 209, 85)
                MyColor(3) = Color.FromArgb(80, 184, 131)
                MyColor(4) = Color.FromArgb(95, 187, 197)
                MyColor(5) = Color.FromArgb(38, 109, 120)
                btncat(ctr).BackColor = MyColor(CInt(Int((5 * Rnd()) + 1)))
                If ctr < 51 Then
                    btncat(ctr).Top = 25 * 1
                    btncat(ctr).Left = 100 * (ctr - 1)
                End If

                Panel5.Controls.Add(btncat(ctr))
                AddHandler btncat(ctr).Click, AddressOf CatClicked

            End While
            conn.Close()

        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information)
        End Try
    End Sub

    Public Sub CatClicked(ByVal sender As Object, ByVal e As EventArgs)
        Try
            clickbtn = CType(sender, Button)
            clearpanel()
            viewitems("")
            Panel5.Visible = False
            Panel5.Controls.Clear()
            Panel5.Visible = True
            viewcat()
            'enablelahat()
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information)
        End Try
    End Sub

    Public Sub clearpanel()
        Try
            Panel14.Visible = False
            Panel14.Controls.Clear()
            Panel14.Visible = True
            'enablelahat()
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information)
        End Try
    End Sub

    Public Sub enablelahat()
        Try
            For Each btn As Button In Panel5.Controls
                If btn.Text <> clickbtn.Text Then
                    btn.Enabled = True
                Else
                    btn.Enabled = False
                End If
            Next
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information)
        End Try
    End Sub
    Public Sub loadItems()
        Dim aut As New AutoCompleteStringCollection()

        Dim query As String = "Select a.itemcode,a.itemname from tblitems a INNER JOIN tblcat b ON a.category = b.category where  a.discontinued='0' AND b.status=1"

        If pos_dialog.ans = "Coffee Shop" Then
            query &= " AND a.category ='Coffee Shop'"
        Else
            query &= " AND a.category !='Coffee Shop'"
        End If

        conn.Open()
        cmd = New SqlCommand(query, conn)
        dr = cmd.ExecuteReader
        While dr.Read
            aut.Add(dr("itemname"))
            aut.Add(dr("itemcode"))
        End While
        conn.Close()
        txtsearch.AutoCompleteCustomSource = aut
    End Sub
    Public Sub viewitems(ByVal s As String)
        Try

            'update status of items
            Panel14.Controls.Clear()

            Dim btn(500) As Button
            Dim wid As Int32
            Dim ctr As Integer = 0, y As Integer, mody As Integer, row As Integer, query As String = ""
            Dim aut As New AutoCompleteStringCollection()
            getID()
            If s <> "" Then
                sql = "SELECT a.itemname,a.itemcode,a.endbal FROM tblinvitems a INNER JOIN tblitems b ON a.itemname = b.itemname INNER JOIN tblcat c ON b.category = c.category WHERE invnum='" & inv_id & "' AND b.discontinued=0 AND a.itemname LIKE @name AND c.status=1 ORDER BY a.endbal DESC,a.itemname ASC"
            ElseIf IsNothing(clickbtn) And s = "" Then
                Exit Sub
            ElseIf clickbtn.Text <> "" Then
                sql = "SELECT a.itemname,a.itemcode,a.endbal FROM tblinvitems a INNER JOIN tblitems b ON a.itemname = b.itemname INNER JOIN tblcat c ON b.category = c.category WHERE invnum='" & inv_id & "' AND b.discontinued=0 AND b.category='" & clickbtn.Text & "' AND c.status=1 ORDER BY a.endbal DESC,a.itemname ASC"
            End If

            conn.Open()
            cmd = New SqlCommand(sql, conn)
            If s <> "" Then
                cmd.Parameters.AddWithValue("@name", "%" & s & "%")
            End If
            Dim adptr As New SqlDataAdapter()
            Dim dt As New DataTable()
            adptr.SelectCommand = cmd
            adptr.Fill(dt)
            conn.Close()
            For Each r0w As DataRow In dt.Rows
                ctr += 1
                btn(ctr) = New Button()
                'btn(ctr).Width = 126
                'btn(ctr).Height = 90
                btn(ctr).Text = r0w("itemname").ToString
                btn(ctr).Tag = r0w("itemcode")
                btn(ctr).TextAlign = ContentAlignment.BottomCenter
                btn(ctr).Font = New Drawing.Font("Arial", 11)
                btn(ctr).Font = New Font(btn(ctr).Font, FontStyle.Bold)
                btn(ctr).TextImageRelation = TextImageRelation.ImageAboveText
                If r0w("endbal") > 0 Then
                    btn(ctr).ForeColor = Color.Black
                Else
                    btn(ctr).Text = r0w("itemname").ToString & " - N/A"
                    btn(ctr).ForeColor = Color.Red
                End If

                conn.Open()
                cmd = New SqlCommand("Select img from tblimage where name='" & btn(ctr).Tag & "'", conn)
                Dim dr1 As SqlDataReader = cmd.ExecuteReader()
                If dr1.HasRows Then
                    dr1.Read()
                    'txt_imgname.Text = dr("name").ToString()
                    Dim data As Byte() = DirectCast(dr1("img"), Byte())
                    Dim ms As New MemoryStream(data)
                    btn(ctr).BackgroundImage = Image.FromStream(ms)
                    btn(ctr).BackgroundImageLayout = ImageLayout.Stretch
                    ' img_box.Image = Image.FromStream(ms)
                End If
                conn.Close()

                'btn(ctr).BackColor = Color.FromArgb(192, 255, 192)
                Dim MyColor(5) As Color
                MyColor(1) = Color.FromArgb(205, 193, 252)
                MyColor(2) = Color.FromArgb(148, 130, 179)
                MyColor(3) = Color.FromArgb(255, 253, 121)
                MyColor(4) = Color.FromArgb(194, 230, 255)
                MyColor(5) = Color.FromArgb(255, 145, 142)
                btn(ctr).BackColor = MyColor(CInt(Int((5 * Rnd()) + 1)))

                'btn(ctr).BackColor = Color.White
                btn(ctr).FlatStyle = FlatStyle.Flat
                btn(ctr).FlatAppearance.BorderColor = Color.Gray
                btn(ctr).FlatAppearance.BorderSize = 1
                btn(ctr).FlatAppearance.MouseOverBackColor = Color.White
                btn(ctr).Cursor = Cursors.Hand
                mody = ctr Mod 4
                row = ctr / 4

                If mody = 1 Then
                    y = (row * 90) + (10 * row)
                    wid = 0
                End If

                btn(ctr).SetBounds(wid, y, 126, 90)
                wid += 139

                Panel14.Controls.Add(btn(ctr))
                AddHandler btn(ctr).Click, AddressOf ItemClicked
            Next

        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information)
        End Try
    End Sub

    Public Sub ItemClicked(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim totalav As Double = 0.00
            If Microsoft.VisualBasic.Right(sender.text.ToString, 6) = " - N/A" Then
                Dim iname As String = sender.text.ToString.Substring(0, sender.text.ToString.Length - 6)
                getID()
                conn.Open()
                cmd = New SqlCommand("SELECT totalav FROM tblinvitems WHERE itemname=@itemname AND invnum=@invnum;", conn)
                cmd.Parameters.AddWithValue("@itemname", iname)
                cmd.Parameters.AddWithValue("@invnum", inv_id)
                dr = cmd.ExecuteReader
                If dr.Read Then
                    totalav = CDbl(dr("totalav"))
                End If
                conn.Close()
            End If

            If totalav = 0 And Microsoft.VisualBasic.Right(sender.text.ToString, 6) = " - N/A" And pos_dialog.ans <> "Coffee Shop" Then
                MsgBox("The Item is Not Available", MsgBoxStyle.Exclamation, "")
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
            grd.Rows.Add()
            Dim s As String = sender.text
            If s.Length > 6 Then
                If s.Substring(s.Length - 6) = " - N/A" Then
                    grd.Item(0, grd.RowCount - 1).Value = s.Replace(s.Substring(s.Length - 6), "")
                Else
                    grd.Item(0, grd.RowCount - 1).Value = sender.text
                End If
            Else
                grd.Item(0, grd.RowCount - 1).Value = sender.text
            End If

            grd.Item(1, grd.RowCount - 1).Value = "0.00"
            grd.Item(7, grd.RowCount - 1).Value = sender.tag
            amount()
            Try
                sql = "Select price,category from tblitems where itemcode='" & sender.tag & "'"
                conn.Open()
                cmd = New SqlCommand(sql, conn)
                dr = cmd.ExecuteReader
                If dr.Read Then
                    'grd.Item(4, grd.RowCount - 1).Value = CDbl(dr("price"))
                    grd.Item(2, grd.RowCount - 1).Value = dr("price")
                    grd.Item(8, grd.RowCount - 1).Value = dr("category")
                End If

                grd.Item(3, grd.RowCount - 1).Value = 0
                conn.Close()
                'MessageBox.Show(sender.tag)

                grd.Rows(grd.RowCount - 1).Cells(1).Selected = True
            Catch ex As Exception
                Me.Cursor = Cursors.Default
                MsgBox(ex.ToString, MsgBoxStyle.Information)
            End Try

            Me.grd.Columns(2).DefaultCellStyle.Format = "n2"
            Me.grd.Columns(3).DefaultCellStyle.Format = "n2"
            lblcount.Text = "ITEMS (" & grd.RowCount & ")"
        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information)
        End Try
    End Sub

    Private Sub chkkey_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkkey.CheckedChanged
        If chkkey.Checked = False Then
            Panel12.Visible = False
            Panel10.Visible = False
            panelfalse()
        End If
    End Sub

    Public Sub panelfalse()
        If Panel12.Visible = True Or Panel10.Visible = True Then
            Panel14.Enabled = False
            Panel5.Enabled = False
        Else
            Panel14.Enabled = True
            Panel5.Enabled = True
        End If
    End Sub

    Private Sub grd_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grd.CellContentClick
        Try
            grd.BeginEdit(True)
            Dim checkCell As DataGridViewCheckBoxCell = CType(grd.Rows(e.RowIndex).Cells(6), DataGridViewCheckBoxCell)
            If grd.CurrentCell.ColumnIndex = 6 Then
                Button1.PerformClick()
            End If
        Catch ex As Exception
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub grd_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grd.CellEndEdit
        Try
            getID()
            If e.ColumnIndex = 1 Then

                If Not IsNumeric(grd.Rows(grd.CurrentRow.Index).Cells("quantity").Value) Then
                    MessageBox.Show("Invalid Input", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    grd.Rows(grd.CurrentRow.Index).Cells(1).Value = 0.00
                    computetotal()
                    Exit Sub
                End If

                If grd.CurrentRow.Cells("quantity").Value = 0 Then
                    MessageBox.Show("Please input atleast 1", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    grd.Rows(grd.CurrentRow.Index).Cells("discountpercent").Value = 0.00
                    grd.Rows(grd.CurrentRow.Index).Cells("amtdue").Value = 0.00
                    computetotal()
                    Exit Sub
                End If

                Dim p As Double
                sql = "Select price from tblitems where itemname='" & grd.Rows(grd.CurrentRow.Index).Cells("description").Value.ToString & "'"
                conn.Open()
                cmd = New SqlCommand(sql, conn)
                dr = cmd.ExecuteReader
                If dr.Read Then
                    p = CDbl(dr("price"))
                End If
                conn.Close()
                If CBool(grd.CurrentRow.Cells("free").Value) = False Then
                    grd.Rows(grd.CurrentRow.Index).Cells("price").Value = p.ToString("n2")
                    Dim q As Double = CDbl(grd.Rows(grd.CurrentRow.Index).Cells("quantity").Value)
                    Dim d As Double = (q * p) * (CDbl(grd.Rows(grd.CurrentRow.Index).Cells("discountpercent").Value / 100))
                    Dim amt As Double = (q * p) - d

                    Dim endbal As Double = 0.00
                    conn.Open()
                    cmd = New SqlCommand("SELECT endbal FROM tblinvitems WHERE invnum=@invnum AND itemname=@itemname;", conn)
                    cmd.Parameters.AddWithValue("@invnum", inv_id)
                    cmd.Parameters.AddWithValue("@itemname", Trim(grd.CurrentRow.Cells("description").Value))
                    dr = cmd.ExecuteReader
                    If dr.Read Then
                        endbal = CDbl(dr("endbal"))
                    End If
                    conn.Close()

                    If endbal < CDbl(grd.CurrentRow.Cells("quantity").Value) And pos_dialog.ans <> "Coffee Shop" Then
                        MessageBox.Show("Available stock only is " & endbal, "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        'grd.CurrentRow.Cells(1).Value = endbal

                        Dim q2 As Double = CDbl(grd.Rows(grd.CurrentRow.Index).Cells("quantity").Value)
                        Dim d2 As Double = (q2 * p) * (CDbl(grd.Rows(grd.CurrentRow.Index).Cells("discountpercent").Value / 100))
                        Dim amt2 As Double = (q2 * p) - d2

                        grd.Rows(grd.CurrentRow.Index).Cells("amtdue").Value = amt2.ToString("n2")
                        computetotal()
                    End If
                    grd.Rows(grd.CurrentRow.Index).Cells("amtdue").Value = amt.ToString("n2")

                    grd.CurrentRow.Cells("pricebefore").Value = (CDbl(grd.CurrentRow.Cells("price").Value) * CDbl(grd.CurrentRow.Cells("quantity").Value)).ToString("n2")
                    grd.CurrentRow.Cells("discamt").Value = (grd.CurrentRow.Cells("discountpercent").Value / 100) * grd.CurrentRow.Cells("pricebefore").Value
                End If
            ElseIf e.ColumnIndex = 3 Then

                If Not IsNumeric(grd.Rows(grd.CurrentRow.Index).Cells(3).Value) Then
                    MessageBox.Show("Invalid Input", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    grd.Rows(grd.CurrentRow.Index).Cells(3).Value = 0.00
                    computetotal()
                    Exit Sub
                End If

                Dim quantity As Double = CDbl(grd.CurrentRow.Cells("quantity").Value)
                Dim price As Double = CDbl(grd.CurrentRow.Cells("price").Value)
                Dim origPrice As Double = quantity * price


                Dim d As Double = (quantity * price) * (CDbl(grd.Rows(grd.CurrentRow.Index).Cells("discountpercent").Value / 100))
                Dim legit As Double = 0.00

                If grd.Rows(grd.CurrentRow.Index).Cells("discountpercent").Value >= 25 Then
                    Dim disk As Double = CDbl(50 / 100)
                    grd.Rows(grd.CurrentRow.Index).Cells("discountpercent").Value = 25
                    d = (quantity * price) * (CDbl(grd.Rows(grd.CurrentRow.Index).Cells("discountpercent").Value / 100))
                    legit = origPrice - d
                    grd.Rows(grd.CurrentRow.Index).Cells("amtdue").Value = legit.ToString("n2")


                    grd.CurrentRow.Cells("discamt").Value = (CDbl(grd.CurrentRow.Cells("discountpercent").Value / 100) * CDbl(grd.CurrentRow.Cells("pricebefore").Value)).ToString("n2")
                Else
                    Dim disk As Double = CDbl(grd.Rows(grd.CurrentRow.Index).Cells("discountpercent").Value / 100)
                    legit = origPrice - d
                    grd.Rows(grd.CurrentRow.Index).Cells("amtdue").Value = legit.ToString("n2")


                    grd.CurrentRow.Cells("discamt").Value = (grd.CurrentRow.Cells("discountpercent").Value / 100) * grd.CurrentRow.Cells("pricebefore").Value
                End If
            ElseIf e.ColumnIndex = 4 Then

                If Not IsNumeric(grd.Rows(grd.CurrentRow.Index).Cells(4).Value) Then
                    MessageBox.Show("Invalid Input", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    grd.Rows(grd.CurrentRow.Index).Cells(4).Value = 0.00
                    grd.Rows(grd.CurrentRow.Index).Cells("discountpercent").Value = "0.00"
                    grd.Rows(grd.CurrentRow.Index).Cells("discamt").Value = "0.00"
                    computetotal()
                    Exit Sub
                End If

                If grd.CurrentRow.Cells("amtdue").Value > (CDbl(grd.CurrentRow.Cells("quantity").Value) * CDbl(grd.CurrentRow.Cells("price").Value)) Then
                    MessageBox.Show("Invalid Input", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    grd.CurrentRow.Cells("amtdue").Value = CDbl(grd.CurrentRow.Cells("quantity").Value) * CDbl(grd.CurrentRow.Cells("price").Value)
                    grd.Rows(grd.CurrentRow.Index).Cells("discountpercent").Value = "0.00"
                    grd.Rows(grd.CurrentRow.Index).Cells("discamt").Value = "0.00"
                    computetotal()
                    Exit Sub
                End If



                grd.Rows(grd.CurrentRow.Index).Cells(3).Value = 0.00


                Dim quantity As Double = CDbl(grd.CurrentRow.Cells("quantity").Value)
                Dim price As Double = CDbl(grd.CurrentRow.Cells("price").Value)
                Dim origPrice As Double = quantity * price

                Dim disc As Double = 0.00
                disc = ((origPrice - grd.CurrentRow.Cells(4).Value) / origPrice) * 100

                If disc < 0 Then
                    grd.CurrentRow.Cells("discountpercent").Value = 0
                    grd.CurrentRow.Cells("discamt").Value = 0
                Else
                    grd.CurrentRow.Cells("discountpercent").Value = disc.ToString("n2")
                    grd.CurrentRow.Cells("discountpercent").Value = CDbl(grd.CurrentRow.Cells("discountpercent").Value).ToString("n2")

                    grd.CurrentRow.Cells("discamt").Value = (grd.CurrentRow.Cells("discountpercent").Value / 100) * grd.CurrentRow.Cells("pricebefore").Value
                End If
            ElseIf e.ColumnIndex = 6 Then
                If Not CBool(grd.CurrentRow.Cells("free").Value) = False And grd.RowCount <> 0 Then
                    Dim checkCell As DataGridViewCheckBoxCell = CType(grd.Rows(e.RowIndex).Cells(6), DataGridViewCheckBoxCell)
                    If checkCell.Value = True Then
                        If grd.CurrentRow.Cells("cat").Value <> "Packaging" And pos_dialog.ans <> "Coffee Shop" Then
                            confirm.ShowDialog()
                        Else
                            grd.Rows(grd.CurrentRow.Index).Cells(2).Value = "0.00"
                            grd.Rows(grd.CurrentRow.Index).Cells(3).Value = "0.00"
                            grd.Rows(grd.CurrentRow.Index).Cells(4).Value = "0.00"
                            grd.CurrentRow.Cells("discamt").Value = "0.00"
                        End If

                        If voidd = True Then
                            grd.Rows(grd.CurrentRow.Index).Cells(2).Value = "0.00"
                            grd.Rows(grd.CurrentRow.Index).Cells(3).Value = "0.00"
                            grd.Rows(grd.CurrentRow.Index).Cells(4).Value = "0.00"
                            grd.CurrentRow.Cells("discamt").Value = "0.00"
                        Else
                            If grd.CurrentRow.Cells("cat").Value <> "Packaging" And pos_dialog.ans <> "Coffee Shop" Then
                                checkCell.Value = False
                            End If
                        End If
                        voidd = False
                    End If
                Else
                    'grd.CurrentRow.Cells("amtdue").Value = CDbl(CDbl(grd.CurrentRow.Cells("price").Value) * CDbl(grd.CurrentRow.Cells("quantity").Value)).ToString("n2")
                    If grd.RowCount <> 0 Then
                        Dim price As Double = 0.00
                        conn.Open()
                        cmd = New SqlCommand("SELECT price FROM tblitems WHERE itemname=@itemname;", conn)
                        cmd.Parameters.AddWithValue("@itemname", grd.CurrentRow.Cells("description").Value)
                        dr = cmd.ExecuteReader
                        If dr.Read Then
                            price = CDbl(dr("price"))
                        End If
                        conn.Close()
                        grd.Rows(grd.CurrentRow.Index).Cells(1).Value = Val(grd.Rows(grd.CurrentRow.Index).Cells(1).Value)
                        grd.Rows(grd.CurrentRow.Index).Cells("discountpercent").Value = "0.00"
                        grd.Rows(grd.CurrentRow.Index).Cells("discamt").Value = "0.00"
                        grd.CurrentRow.Cells("price").Value = price.ToString("n2")
                        Dim q As Double = CDbl(grd.Rows(grd.CurrentRow.Index).Cells("quantity").Value)
                        Dim d As Double = CDbl(grd.Rows(grd.CurrentRow.Index).Cells(3).Value)
                        Dim amt As Double = (q * price) - d
                        grd.Rows(grd.CurrentRow.Index).Cells(4).Value = amt.ToString("n2")
                    End If
                End If
            End If
            computetotal()
            ' cellendedit()
            ' checksupply()
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information)
        End Try
    End Sub

    Public Sub cellendedit()
        Try
            If grd.CurrentCell.ColumnIndex = 1 Then
                If Panel12.Visible = False And IsNumeric((grd.Rows(grd.CurrentRow.Index).Cells(1).Value)) Then
                    If grd.Rows(grd.CurrentRow.Index).Cells(1).Value.ToString IsNot Nothing And (grd.Rows(grd.CurrentRow.Index).Cells(1).Value) = 0 Then
                        MsgBox("Input must be a non zero number", MsgBoxStyle.Exclamation, "")
                        grd.Rows(grd.CurrentRow.Index).Cells(1).Value = "0.00"
                        amount()
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    ElseIf grd.Rows(grd.CurrentRow.Index).Cells(1).Value.ToString IsNot Nothing And (grd.Rows(grd.CurrentRow.Index).Cells(1).Value) < 1 Then
                        MsgBox("Invalid input", MsgBoxStyle.Exclamation, "")
                        grd.Rows(grd.CurrentRow.Index).Cells(1).Value = lastdgv
                        amount()
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    Else
                        'computeamt()
                        grd.Rows(grd.CurrentRow.Index).Cells(1).Value = CInt(Val(grd.Rows(grd.CurrentRow.Index).Cells(1).Value.ToString()))
                        amount()
                        'check if stocks are enough to purchase the quantity of orders
                        Try
                            sql = "Select Top 1 endbal from tblinvitems  where itemcode='" & grd.Rows(grd.CurrentRow.Index).Cells(7).Value & "' AND area='" & "Sales" & "' AND invnum='" & inv_id & "' order by invid DESC"
                            conn.Open()
                            cmd = New SqlCommand(sql, conn)
                            dr = cmd.ExecuteReader

                            If dr.Read Then
                                If Val(dr("endbal")) - Val(grd.Rows(grd.CurrentRow.Index).Cells(1).Value) < 0 Then
                                    If pos_dialog.ans <> "Coffee Shop" And sales_ans <> "Coffee Shop" Then
                                        MsgBox("Insufficient Supply.", MsgBoxStyle.Exclamation, "")
                                        grd.Rows(grd.CurrentRow.Index).Cells(1).Value = ""
                                        amount()

                                    End If
                                End If
                            End If
                            conn.Close()
                            grd.CurrentCell = grd.CurrentRow.Cells(1)
                        Catch ex As Exception
                            Me.Cursor = Cursors.Default
                            MsgBox(ex.ToString, MsgBoxStyle.Information)
                        End Try
                    End If
                Else
                    If Panel12.Visible = False And grd.Rows(grd.CurrentRow.Index).Cells(1).Value IsNot Nothing Then

                        MsgBox("Input must be a non zero number", MsgBoxStyle.Exclamation, "")
                        grd.Rows(grd.CurrentRow.Index).Cells(1).Value = "0.00"
                        amount()
                        ' MessageBox.Show("1.2")
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                End If
            ElseIf grd.CurrentCell.ColumnIndex = 3 Then
                If Panel12.Visible = False And IsNumeric((grd.Rows(grd.CurrentRow.Index).Cells(3).Value.ToString)) Then
                    If grd.Rows(grd.CurrentRow.Index).Cells(3).Value.ToString IsNot Nothing And Val(grd.Rows(grd.CurrentRow.Index).Cells(3).Value) = 0 Then
                    ElseIf grd.Rows(grd.CurrentRow.Index).Cells(3).Value.ToString IsNot Nothing And (grd.Rows(grd.CurrentRow.Index).Cells(3).Value) > 100 Then
                        MsgBox("Input must not higher than 100%", MsgBoxStyle.Exclamation, "")
                        grd.Rows(grd.CurrentRow.Index).Cells(3).Value = lastdgv
                    ElseIf grd.Rows(grd.CurrentRow.Index).Cells(3).Value.ToString IsNot Nothing And (grd.Rows(grd.CurrentRow.Index).Cells(3).Value) < 1 Then
                        MsgBox("Invalid input", MsgBoxStyle.Exclamation, "")
                        grd.Rows(grd.CurrentRow.Index).Cells(3).Value = lastdgv
                    End If
                Else
                    If Panel12.Visible = False And grd.Rows(grd.CurrentRow.Index).Cells(3).Value.ToString IsNot Nothing Then
                        grd.Rows(grd.CurrentRow.Index).Cells(3).Value = lastdgv
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                End If
            End If

            amount()
            Dim checkCell As DataGridViewCheckBoxCell = CType(grd.Rows(grd.CurrentRow.Index).Cells(6), DataGridViewCheckBoxCell)
            If checkCell.Value = True Then
                grd.Rows(grd.CurrentRow.Index).Cells(3).Value = "0.00"
                grd.Rows(grd.CurrentRow.Index).Cells(4).Value = "0.00"
            End If
            computetotal()

        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information)
        End Try
    End Sub

    Public Sub checksupply()
        Try
            For Each row As DataGridViewRow In grd.Rows
                Dim name As String = grd.Rows(row.Index).Cells(0).Value

                If name = "" Then
                    Exit Sub
                End If

                If Not list1.Items.Contains(name) Then
                    list1.Items.Add(name)
                End If
            Next

            conn.Open()
            For i = 0 To list1.Items.Count - 1
                list1.SelectedIndex = i
                Dim name As String = list1.SelectedItem
                Dim temp As Integer = 0
                '//// MsgBox(name)
                For Each row As DataGridViewRow In grd.Rows
                    If grd.Rows(row.Index).Cells(0).Value = name Then
                        temp += Val(grd.Rows(row.Index).Cells(1).Value)
                    End If
                    sql = "Select Top 1 endbal from tblinvitems where itemname='" & name & "' AND area='" & "Sales" & "' AND invnum='" & inv_id & "' order by invid DESC"
                    conn.Open()
                    cmd = New SqlCommand(sql, conn)
                    dr = cmd.ExecuteReader

                    If dr.Read Then
                        If Val(dr("endbal")) - temp < 0 Then
                            If pos_dialog.ans = "Coffee Shop" And cas = "Cashier" Then
                                grd.Rows(row.Index).Cells(1).Value = "0.00"
                                amount()
                                Exit Sub
                            ElseIf pos_dialog.ans <> "Coffee Shop" And cas = "Sales" Then
                                grd.Rows(row.Index).Cells(1).Value = "0.00"
                                amount()
                                Exit Sub
                            ElseIf pos_dialog.ans <> "Coffee Shop" And cas = "Cashier" Then
                                grd.Rows(row.Index).Cells(1).Value = "0.00"
                                amount()
                                Exit Sub
                            End If
                        End If
                    End If
                    conn.Close()
                Next
                '/// MsgBox(temp)
            Next


        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information)
        End Try
    End Sub

    Public Sub amount()
        Try
            Dim checkCell As DataGridViewCheckBoxCell = CType(grd.Rows(grd.CurrentRow.Index).Cells(6), DataGridViewCheckBoxCell)
            If grd.RowCount <> 0 And checkCell.Value = False Then
                If (grd.Rows(grd.CurrentRow.Index).Cells(1).Value IsNot Nothing) Or (grd.Rows(grd.CurrentRow.Index).Cells(3).Value IsNot Nothing) Then
                    Dim bd As Double = CDbl(Val(grd.Rows(grd.CurrentRow.Index).Cells(1).Value))
                    Dim db As Double = CDbl(Val(grd.Rows(grd.CurrentRow.Index).Cells(3).Value))
                    Dim isnm As Boolean = IsNumeric(bd)
                    Dim isnm1 As Boolean = IsNumeric(db)
                    If isnm = True And isnm1 = True Then

                        ''discount
                        'Dim discount As Double = 0.00, hasDiscount As Boolean = False
                        'connect()
                        'cmd = New SqlCommand("SELECT discount FROM tbldiscount_items WHERE itemid=(SELECT itemid FROM tblitems WHERE itemname=@itemname);", conn)
                        'cmd.Parameters.AddWithValue("@itemname", grd.CurrentRow.Cells("description").Value)
                        'dr = cmd.ExecuteReader
                        'If dr.Read Then
                        '    discount = CDbl(dr("discount"))
                        '    hasDiscount = True
                        'End If
                        'disconnect()
                        'If discount <> 0 Then
                        '    discount = 100 - discount
                        '    discount = discount / 100
                        'End If
                        'grd.Rows(grd.CurrentRow.Index).Cells(1).Value = Val(grd.Rows(grd.CurrentRow.Index).Cells(1).Value)
                        'grd.Rows(grd.CurrentRow.Index).Cells(3).Value = Val(grd.Rows(grd.CurrentRow.Index).Cells(3).Value)
                        Dim q As Double = CDbl(grd.Rows(grd.CurrentRow.Index).Cells(1).Value)
                        Dim p As Double
                        sql = "Select price from tblitems where itemname='" & grd.Rows(grd.CurrentRow.Index).Cells(0).Value.ToString & "'"
                        conn.Open()
                        cmd = New SqlCommand(sql, conn)
                        dr = cmd.ExecuteReader
                        If dr.Read Then
                            p = CDbl(dr("price"))
                        End If
                        conn.Close()
                        'If grd.CurrentRow.Cells("cat").Value = "Coffee Shop" Then
                        '    If hasDiscount Then
                        '        Dim holderPrice As Double = p * discount
                        '        p = holderPrice
                        '    End If
                        'End If

                        '////Dim p As Double = CDbl(grd.Rows(grd.CurrentRow.Index).Cells(2).Value)
                        'Dim d As Double = (q * p) * (CDbl(grd.Rows(grd.CurrentRow.Index).Cells(3).Value / 100))
                        'Dim amt As Double = (q * p) - d
                        grd.Rows(grd.CurrentRow.Index).Cells(2).Value = p.ToString("n2")
                        Dim d As Double = (q * p) * (CDbl(grd.Rows(grd.CurrentRow.Index).Cells(3).Value / 100))
                        Dim amt As Double = (q * p) - d

                        'grd.Rows(grd.CurrentRow.Index).Cells(4).Value = amt.ToString("n2")

                        'If pos_dialog.ans = "Wholesale" Or sales_ans = "Wholesale" Or pos_dialog.ans = "Coffee Shop" Or sales_ans = "Coffee Shop" Then
                        '    grd.Rows(grd.CurrentRow.Index).Cells(4).Value = CDbl(grd.Rows(grd.CurrentRow.Index).Cells(4).Value).ToString("n2")
                        'Else
                        '    grd.Rows(grd.CurrentRow.Index).Cells(4).Value = amt
                        'End If
                        If pos_dialog.ans = "Coffee Shop" Or sales_ans = "Coffee Shop" Then

                            Dim dgv As DataGridViewTextBoxCell = CType(grd.CurrentRow.Cells("quantity"), DataGridViewTextBoxCell)
                            If dgv.ColumnIndex = 1 Then

                            End If

                            Dim amtdue As DataGridViewTextBoxCell = CType(grd.CurrentRow.Cells("amtdue"), DataGridViewTextBoxCell)
                            If amtdue.ColumnIndex = 4 Then

                            End If

                            Dim discountpercent As DataGridViewTextBoxCell = CType(grd.CurrentRow.Cells("discountpercent"), DataGridViewTextBoxCell)
                            If discountpercent.ColumnIndex = 3 Then

                            End If

                        End If


                        'Dim holderamt As Double = grd.CurrentRow.Cells(4).Value
                        'If pos_dialog.ans = "Coffee Shop" Or sales_ans = "Coffee Shop" Then
                        '    Dim quantity As Double = CDbl(grd.CurrentRow.Cells("quantity").Value)
                        '    Dim price As Double = CDbl(grd.CurrentRow.Cells("price").Value)
                        '    Dim origPrice As Double = quantity * price

                        '    grd.Rows(grd.CurrentRow.Index).Cells(4).Value = amt
                        '    If origPrice > holderamt Then
                        '        grd.Rows(grd.CurrentRow.Index).Cells(4).Value = holderamt
                        '        Dim disc As Double = ((origPrice - grd.CurrentRow.Cells("amtdue").Value) / origPrice) * 100
                        '        If disc <= 100 Then
                        '            grd.CurrentRow.Cells("discountpercent").Value = disc
                        '        Else
                        '            grd.CurrentRow.Cells("discountpercent").Value = 0.00
                        '        End If
                        '    Else
                        '        grd.Rows(grd.CurrentRow.Index).Cells(4).Value = origPrice
                        '        grd.CurrentRow.Cells("discountpercent").Value = 0.00
                        '    End If
                        'End If


                        grd.Columns(1).DefaultCellStyle.Format = "n2"
                        grd.Columns(2).DefaultCellStyle.Format = "n2"
                        grd.Columns(3).DefaultCellStyle.Format = "n2"
                        grd.Columns(4).DefaultCellStyle.Format = "n2"
                    End If
                End If
            ElseIf grd.RowCount <> 0 And checkCell.Value = True Then
                grd.Rows(grd.CurrentRow.Index).Cells(2).Value = "0.00"
                grd.Rows(grd.CurrentRow.Index).Cells(3).Value = "0.00"
                grd.Rows(grd.CurrentRow.Index).Cells(4).Value = "0.00"
            End If
            computetotal()

        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information) '////////
        End Try
    End Sub

    Private Sub grd_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grd.CellEnter
        grd.Focus()
    End Sub

    'Private Sub grd_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grd.CellValueChanged
    '    Try

    '        If grd.Columns(e.ColumnIndex).HeaderText = "Free" And grd.RowCount <> 0 Then
    '            Dim checkCell As DataGridViewCheckBoxCell = CType(grd.Rows(e.RowIndex).Cells(6), DataGridViewCheckBoxCell)
    '            If checkCell.Value = True Then
    '                'MsgBox("true")
    '                voidd = False

    '                'If pos_dialog.ans = "Coffee Shop" Then
    '                '    MessageBox.Show("whaaat")
    '                '    Dim words As String = ""
    '                '    For index As Integer = 0 To grd.RowCount - 1
    '                '        conn.Open()
    '                '        cmd = New SqlCommand("SELECT b.itemname FROM tblcsitems a JOIN tblitems b ON a.itemid = b.itemid WHERE b.itemname=@itemname;", conn)
    '                '        cmd.Parameters.AddWithValue("@itemname", grd.Rows(index).Cells("itemname").Value)
    '                '        dr = cmd.ExecuteReader
    '                '        While dr.Read
    '                '            words &= dr("itemname") & ","
    '                '        End While
    '                '        conn.Close()
    '                '    Next

    '                'words.Substring(0, words.Length - 1)
    '                '    MessageBox.Show(words)
    '                'End If


    '                If grd.CurrentRow.Cells("cat").Value <> "Packaging" And pos_dialog.ans <> "Coffee Shop" Then
    '                    confirm.ShowDialog()
    '                End If

    '                If voidd = True Then
    '                    grd.Rows(grd.CurrentRow.Index).Cells(2).Value = "0.00"
    '                    grd.Rows(grd.CurrentRow.Index).Cells(3).Value = "0.00"
    '                    grd.Rows(grd.CurrentRow.Index).Cells(4).Value = "0.00"
    '                Else
    '                    If grd.CurrentRow.Cells("cat").Value <> "Packaging" And pos_dialog.ans <> "Coffee Shop" Then
    '                        checkCell.Value = False
    '                    End If
    '                End If
    '                voidd = False
    '            Else
    '                'MsgBox("false")
    '                If grd.RowCount <> 0 Then
    '                    If (grd.Rows(grd.CurrentRow.Index).Cells(1).Value.ToString IsNot Nothing) And (grd.Rows(grd.CurrentRow.Index).Cells(2).Value.ToString IsNot Nothing) And IsNumeric(grd.Rows(grd.CurrentRow.Index).Cells(1).Value) = True And IsNumeric(grd.Rows(grd.CurrentRow.Index).Cells(2).Value) = True Then
    '                        grd.Rows(grd.CurrentRow.Index).Cells(1).Value = Val(grd.Rows(grd.CurrentRow.Index).Cells(1).Value)
    '                        grd.Rows(grd.CurrentRow.Index).Cells(3).Value = Val(grd.Rows(grd.CurrentRow.Index).Cells(3).Value)
    '                        Dim q As Double = CDbl(grd.Rows(grd.CurrentRow.Index).Cells(1).Value)
    '                        Dim p As Double = CDbl(grd.Rows(grd.CurrentRow.Index).Cells(2).Value)
    '                        Dim d As Double = CDbl(grd.Rows(grd.CurrentRow.Index).Cells(3).Value)
    '                        Dim amt As Double = (q * p) - d
    '                        grd.Rows(grd.CurrentRow.Index).Cells(4).Value = amt
    '                        grd.Columns(1).DefaultCellStyle.Format = "n2"
    '                        grd.Columns(3).DefaultCellStyle.Format = "n2"
    '                        grd.Columns(4).DefaultCellStyle.Format = "n2"
    '                    End If
    '                    computetotal()
    '                End If
    '            End If
    '            grd.Invalidate()
    '            amount()
    '        End If
    '    Catch ex As Exception
    '        Me.Cursor = Cursors.Default
    '        'MessageBox.Show(ex.Message, MsgBoxStyle.Information)
    '    End Try
    'End Sub


    Public Sub computetotal()
        Try
            Dim total As Double, temptotal As Double
            Dim totalitem As Double, temptotalitem As Double

            If grd.RowCount <> 0 Then
                culture = CultureInfo.CreateSpecificCulture("en-US")
                Dim result As Double = 0
                For Each row As DataGridViewRow In grd.Rows
                    result += CDbl(grd.Rows(row.Index).Cells(4).Value)
                    temptotal = Val(grd.Rows(row.Index).Cells(4).Value)
                    total = total + temptotal
                    If grd.Rows(row.Index).Cells(5).Value Is Nothing Then
                        'MsgBox("true")
                        grd.Rows(row.Index).Cells(5).Value = ""
                    End If
                    'hi
                    temptotalitem = Val(grd.Rows(row.Index).Cells(1).Value)
                    totalitem = totalitem + temptotalitem
                Next
                Dim subtot As String = result.ToString("n2")
                txtsub.Text = subtot
                txtsubtotal2.Text = CDbl(subtot - (subtot * (CDbl(txtless.Text) / 100))).ToString("n2")
                txtdiscamt.Text = CDbl(CDbl(txtsub.Text) * (CDbl(txtless.Text) / 100)).ToString("n2")
                If txttendered.Text <> "" Then
                    Dim er As Double = 0.0
                    Dim less As Double = 0.0
                    Dim fLess As Double = 0.0
                    fLess = 100 - CDbl(txtless.Text)
                    less = fLess / 100
                    If grd.Rows.Count <> 0 Then
                        If cmbdis.Text <> "" Then
                            For index As Integer = 0 To grd.Rows.Count - 1
                                If cmbdis.Text = "Senior Citizen" Or cmbdis.Text = "Pwd" Then
                                    conn.Open()
                                    cmd = New SqlCommand("SELECT basedprice FROM tblgroupdisc WHERE itemname='" & grd.Rows(index).Cells("description").Value & "' AND status='1';", conn)
                                    dr = cmd.ExecuteReader
                                    If dr.Read Then
                                        Dim totalPrice As Double = 0.0, totalPrice2 As Double = 0.0
                                        totalPrice = CDbl(grd.Rows(index).Cells("price").Value) * CDbl(grd.Rows(index).Cells("quantity").Value)
                                        totalPrice = totalPrice - CDbl(dr("basedprice"))
                                        totalPrice2 = CDbl(dr("basedprice")) / 1.12 * less
                                        er += totalPrice + totalPrice2
                                    Else
                                        er += CDbl(grd.Rows(index).Cells("price").Value) * CDbl(grd.Rows(index).Cells("quantity").Value) / 1.12 * less
                                    End If
                                    conn.Open()
                                Else
                                    conn.Open()
                                    cmd = New SqlCommand("SELECT basedprice FROM tblgroupdisc WHERE itemname='" & grd.Rows(index).Cells("description").Value & "' AND status='1';", conn)
                                    dr = cmd.ExecuteReader
                                    If dr.Read Then
                                        Dim totalPrice As Double = 0.0, totalPrice2 As Double = 0.0
                                        totalPrice = CDbl(grd.Rows(index).Cells("price").Value) * CDbl(grd.Rows(index).Cells("quantity").Value)
                                        totalPrice = totalPrice - CDbl(dr("basedprice"))
                                        totalPrice2 = CDbl(dr("basedprice")) * less
                                        er += totalPrice + totalPrice2
                                    Else
                                        'er += CDbl(grd.Rows(index).Cells("price").Value) * CDbl(grd.Rows(index).Cells("quantity").Value) * less
                                        er = CDbl(txtsubtotal2.Text) - CDbl(txtgc.Text)
                                    End If
                                    conn.Close()
                                End If
                            Next
                        Else
                            er = CDbl(txtsubtotal2.Text) - CDbl(txtgc.Text)
                        End If
                    Else
                        er = 0
                    End If
                    Dim amtpayable As Double = 0.00, change As Double = 0.00
                    If apdepamt <> 0 Then
                        If apdepamt > er Then
                            amtpayable = 0
                        Else
                            amtpayable = er - apdepamt
                        End If
                    Else
                        amtpayable = er
                    End If
                    Dim amttendered As Double = CDbl(txttendered.Text)
                    txtboxamountpayable.Text = amtpayable.ToString("n2")
                    change = amttendered + apdepamt - er
                    If change > 0 Then
                        txtchange.Text = change.ToString("n2")
                    Else
                        txtchange.Text = "0.00"
                    End If
                End If
                txttotal.Text = txtboxamountpayable.Text
                Dim totalitemm As Integer = 0
                For index As Integer = 0 To grd.Rows.Count - 1
                    totalitemm += CInt(grd.Rows(index).Cells("quantity").Value)
                Next
                txtitem.Text = totalitemm.ToString("n2")
                If Val(txtless.Text) = "100" Then
                    txtvatsales.Text = "0.00"
                    txtvatex.Text = "0.00"
                    txtvatamt.Text = "0.00"
                End If
                btnok.Focus()
            End If
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information)
        End Try
    End Sub

    Public Sub computetotalbackup()
        Try
            Dim total As Double, temptotal As Double
            Dim totalitem As Double, temptotalitem As Double

            If grd.RowCount <> 0 Then
                culture = CultureInfo.CreateSpecificCulture("en-US")

                For Each row As DataGridViewRow In grd.Rows
                    temptotal = Val(grd.Rows(row.Index).Cells(4).Value)
                    total = total + temptotal
                    If grd.Rows(row.Index).Cells(5).Value Is Nothing Then
                        'MsgBox("true")
                        grd.Rows(row.Index).Cells(5).Value = ""
                    End If

                    temptotalitem = Val(grd.Rows(row.Index).Cells(1).Value)
                    totalitem = totalitem + temptotalitem
                Next

                Dim subtot As String = total.ToString("n2")
                txtsub.Text = subtot
                txtsubtotal2.Text = CDbl(subtot - (subtot * (CDbl(txtless.Text) / 100))).ToString("n2")
                txtdiscamt.Text = CDbl(CDbl(txtsub.Text) * (CDbl(txtless.Text) / 100)).ToString("n2")
                Dim txttotalitem As String = totalitem.ToString("n2")
                txtitem.Text = txttotalitem

                Dim lessdisc As String = ""

                Dim numsubtot As Double = Double.Parse(txtsub.Text, culture)
                lessdisc = numsubtot * Val(txtless.Text) / 100
                'if senior citizen WITH VAT EXEMT SALES
                Dim cmbd As String = cmbdis.SelectedItem
                If cmbdis.SelectedItem <> "" Then
                    If cmbd.Contains("Senior") Or cmbd.Contains("Pwd") Then
                        lessdisc = (numsubtot / 1.12) * (Val(txtless.Text) / 100)
                        total = total / 1.12
                        based = 0

                        'MsgBox("bundle")
                        For Each row As DataGridViewRow In grd.Rows
                            If grd.Rows(row.Index).Cells(1).Value IsNot Nothing And grd.Rows(row.Index).Cells(1).Value >= 1 Then
                                sql = "Select * from tblgroupdisc where itemname='" & grd.Rows(row.Index).Cells(0).Value.ToString & "' and status='1'"
                                conn.Open()
                                cmd = New SqlCommand(sql, conn)
                                dr = cmd.ExecuteReader
                                If dr.Read Then
                                    based = dr("basedprice")
                                    Exit For
                                End If
                                conn.Close()
                            End If
                        Next

                        If based <> 0 Then
                            total = Double.Parse(txtsub.Text, culture)
                            Dim vinclude As Double = Val(total) - based
                            Dim notdisc As Double = (based / 1.12) * 0.8
                            lessdisc = Val(total) - (vinclude + notdisc)
                        End If

                    End If
                End If

                Dim num3 As Double = Double.Parse(txtdeliver.Text, culture)
                Dim num4 As Double = Double.Parse(lessdisc, culture)

                Dim ttl As Double = (total + num3 - num4)
                Dim numtotal As String = ttl.ToString("n2")

                txttotal.Text = numtotal

                If txttendered.Text <> "" Then

                    Dim num1 As Double = Double.Parse(txttendered.Text, culture)
                    Dim num2 As Double = Double.Parse(txtsubtotal2.Text, culture)
                    Dim num5 As Double = Double.Parse(txtgc.Text, culture)
                    Dim num6 As Double = Double.Parse(apdepamt, culture)
                    Dim change As Double = (num1 + num5 + num6) - num2
                    Dim amtpayable As Double = num2 - (num5 + num6)
                    txtboxamountpayable.Text = amtpayable.ToString("n2")
                    If change > 0 Then
                        txtchange.Text = change.ToString("n2")
                    Else
                        txtchange.Text = "0.00"
                    End If
                End If

                btnok.Focus()

            End If
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information)
        End Try
    End Sub

    Private Sub txttendered_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttendered.GotFocus
        Try
            If chkkey.Checked = True Then
                activeTextBox = CType(sender, TextBox)
                iftxt = 1
                If Val(Trim(txttendered.Text)) = 0 Then
                    lasttext = 0
                Else
                    lasttext = txttendered.Text
                End If
                Panel12.Visible = True
                panelfalse()
                txttendered.Text = "0"
                dot.Enabled = True
            Else
                txttendered.Text = ""
            End If
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information)
        End Try
    End Sub

    Private Sub txttendered_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttendered.KeyPress
        Try
            Dim n As Integer = 0
            If Asc(e.KeyChar) = Windows.Forms.Keys.Enter Then
                cmp()
            End If

            If Asc(e.KeyChar) <> 8 And Asc(e.KeyChar) <> 1 And Asc(e.KeyChar) <> 3 And Asc(e.KeyChar) <> 24 And Asc(e.KeyChar) <> 25 And Asc(e.KeyChar) <> 26 And Asc(e.KeyChar) <> 46 Then
                If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                    e.Handled = True
                Else
                    If Val(txttendered.Text) = 0 Then
                        If Asc(e.KeyChar) = 48 Then
                            e.Handled = True
                        Else
                            txttendered.Text = ""
                        End If
                    End If
                End If
            Else
                If Asc(e.KeyChar) = 46 And Trim(txttendered.Text) <> "" And txttendered.Text.Contains(".") = False Then

                ElseIf Asc(e.KeyChar) = 46 And Trim(txttendered.Text) <> "" And txttendered.Text.Contains(".") = True Then
                    e.Handled = True
                End If
            End If
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information)
        End Try
    End Sub

    Private Sub txtchange_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtchange.GotFocus
        Try
            cmp()
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information)
        End Try
    End Sub

    Public Sub cmp()
        Try
            culture = CultureInfo.CreateSpecificCulture("en-US")
            Dim num1 As Double
            Dim num2 As Double
            If txttendered.Text <> "" And Panel12.Visible = False Then
                num1 = Double.Parse(txttendered.Text, culture)
                num2 = Double.Parse(txttotal.Text, culture)
                txttendered.Text = num1.ToString("n2")
            ElseIf txttendered.Text <> "" And Panel12.Visible = True Then
                num1 = Double.Parse(txttendered.Text, culture)
                num2 = Double.Parse(txttotal.Text, culture)
                txttendered.Text = Val(txttendered.Text) '.ToString("n2")
            End If


            'check if ung total is mas malaki kumpara sa cash tendered
            If num2 > num1 Then
                computetotal()
            Else
                computetotal()
            End If

            btnok.Focus()
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information)
        End Try
    End Sub

    Private Sub grd_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grd.CellClick
        Try
            If grd.RowCount <> 0 Then
                Dim cellcolumn As Integer = grd.CurrentCell.ColumnIndex
                If (grd.CurrentCell.ColumnIndex = 1 Or grd.CurrentCell.ColumnIndex = 3) And chkkey.Checked = True Then
                    iftxt = 0
                    If Not (grd.Rows(grd.CurrentRow.Index).Cells(cellcolumn).Value) Is Nothing Then
                        lastdgv = grd.Rows(grd.CurrentRow.Index).Cells(cellcolumn).Value.ToString
                    Else
                        grd.Rows(grd.CurrentRow.Index).Cells(cellcolumn).Value = ""
                        lastdgv = grd.Rows(grd.CurrentRow.Index).Cells(cellcolumn).Value.ToString
                    End If
                    grd.Rows(grd.CurrentRow.Index).Cells(cellcolumn).Value = ""
                    Panel12.Visible = True
                    Panel10.Visible = False
                    panelfalse()
                ElseIf (grd.CurrentCell.ColumnIndex = 5) And chkkey.Checked = True Then
                    iftxt = 0
                    If Not (grd.Rows(grd.CurrentRow.Index).Cells(cellcolumn).Value) Is Nothing Then
                        lastdgv = grd.Rows(grd.CurrentRow.Index).Cells(cellcolumn).Value.ToString
                    Else
                        grd.Rows(grd.CurrentRow.Index).Cells(cellcolumn).Value = ""
                        lastdgv = grd.Rows(grd.CurrentRow.Index).Cells(cellcolumn).Value.ToString
                    End If
                    grd.Rows(grd.CurrentRow.Index).Cells(cellcolumn).Value = ""
                    Panel10.Visible = True
                    Panel12.Visible = False
                    panelfalse()
                End If
            End If
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information)
        End Try
    End Sub

    Private Sub a1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles a1.Click
        grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value = grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value.ToString & "1"
    End Sub
    Private Sub a2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles a2.Click
        grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value = grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value.ToString & "2"
    End Sub
    Private Sub a3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles a3.Click
        grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value = grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value.ToString & "3"
    End Sub
    Private Sub a4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles a4.Click
        grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value = grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value.ToString & "4"
    End Sub
    Private Sub a5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles a5.Click
        grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value = grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value.ToString & "5"
    End Sub
    Private Sub a6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles a6.Click
        grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value = grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value.ToString & "6"
    End Sub
    Private Sub a7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles a7.Click
        grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value = grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value.ToString & "7"
    End Sub
    Private Sub a8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles a8.Click
        grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value = grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value.ToString & "8"
    End Sub
    Private Sub a9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles a9.Click
        grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value = grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value.ToString & "9"
    End Sub
    Private Sub a0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles a0.Click
        grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value = grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value.ToString & "0"
    End Sub
    Private Sub Aq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Aq.Click
        grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value = grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value.ToString & "q"
    End Sub
    Private Sub Aw_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Aw.Click
        grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value = grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value.ToString & "w"
    End Sub
    Private Sub Ae_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ae.Click
        grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value = grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value.ToString & "e"
    End Sub
    Private Sub Ar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ar.Click
        grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value = grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value.ToString & "r"
    End Sub
    Private Sub At_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles At.Click
        grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value = grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value.ToString & "t"
    End Sub
    Private Sub Ay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ay.Click
        grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value = grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value.ToString & "y"
    End Sub
    Private Sub Au_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Au.Click
        grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value = grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value.ToString & "u"
    End Sub
    Private Sub Ai_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ai.Click
        grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value = grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value.ToString & "i"
    End Sub
    Private Sub Ao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ao.Click
        grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value = grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value.ToString & "o"
    End Sub
    Private Sub Ap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ap.Click
        grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value = grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value.ToString & "p"
    End Sub
    Private Sub Aa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Aa.Click
        grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value = grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value.ToString & "a"
    End Sub
    Private Sub Aas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Aas.Click
        grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value = grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value.ToString & "s"
    End Sub
    Private Sub Ad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ad.Click
        grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value = grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value.ToString & "d"
    End Sub
    Private Sub Af_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Af.Click
        grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value = grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value.ToString & "f"
    End Sub
    Private Sub Ag_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ag.Click
        grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value = grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value.ToString & "g"
    End Sub
    Private Sub ah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ah.Click
        grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value = grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value.ToString & "h"
    End Sub
    Private Sub Aj_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Aj.Click
        grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value = grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value.ToString & "j"
    End Sub
    Private Sub Ak_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ak.Click
        grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value = grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value.ToString & "k"
    End Sub
    Private Sub Al_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Al.Click
        grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value = grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value.ToString & "l"
    End Sub
    Private Sub Az_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Az.Click
        grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value = grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value.ToString & "z"
    End Sub
    Private Sub Ax_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ax.Click
        grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value = grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value.ToString & "x"
    End Sub
    Private Sub Ac_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ac.Click
        grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value = grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value.ToString & "c"
    End Sub
    Private Sub Av_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Av.Click
        grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value = grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value.ToString & "v"
    End Sub
    Private Sub Ab_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ab.Click
        grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value = grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value.ToString & "b"
    End Sub
    Private Sub An_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles An.Click
        grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value = grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value.ToString & "n"
    End Sub
    Private Sub Am_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Am.Click
        grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value = grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value.ToString & "m"
    End Sub
    Private Sub Adash_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Adash.Click
        grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value = grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value.ToString & "-"
    End Sub
    Private Sub Adot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Adot.Click
        grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value = grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value.ToString & "."
    End Sub
    Private Sub Acomma_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Acomma.Click
        grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value = grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value.ToString & ","
    End Sub
    Private Sub Aplus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Aplus.Click
        grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value = grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value.ToString & "+"
    End Sub
    Private Sub Aspace_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Aspace.Click
        grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value = grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value.ToString & " "
    End Sub
    Private Sub Aclear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Aclear.Click
        grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value = ""
    End Sub
    Private Sub Aexit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Aexit.Click
        grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value = lastdgv
        Panel10.Visible = False
        panelfalse()
    End Sub
    Private Sub Aback_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Aback.Click
        Dim cellcolumn As Integer = grd.CurrentCell.ColumnIndex
        If Trim(grd.Rows(grd.CurrentRow.Index).Cells(cellcolumn).Value.ToString) IsNot Nothing And grd.Rows(grd.CurrentRow.Index).Cells(cellcolumn).Value.ToString.Length <> 0 Then
            Dim a As String = grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value.ToString
            grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value = a.Remove(a.Length - 1)
        End If
    End Sub
    Private Sub Aenter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Aenter.Click
        'grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value = lastdgv
        Panel10.Visible = False
        panelfalse()
    End Sub

    Private Sub zero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles zero.Click
        If iftxt = 1 Then
            If Trim(activeTextBox.Text) <> "0" Then
                activeTextBox.Text = activeTextBox.Text & "0"
            End If
        Else
            grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value = grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value.ToString & "0"
        End If
        dot.Enabled = True
    End Sub
    Private Sub one_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles one.Click
        If iftxt = 1 Then
            If activeTextBox.Text = "0" Then
                activeTextBox.Text = "1"
            ElseIf (activeTextBox.Text = "0." Or activeTextBox.Text <> "0") Then
                activeTextBox.Text = activeTextBox.Text & "1"
            End If
        Else
            grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value = grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value.ToString & "1"
        End If
    End Sub
    Private Sub two_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles two.Click
        If iftxt = 1 Then
            If activeTextBox.Text = "0" Then
                activeTextBox.Text = "2"
            ElseIf (activeTextBox.Text = "0." Or activeTextBox.Text <> "0") Then
                activeTextBox.Text = activeTextBox.Text & "2"
            End If
        Else
            grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value = grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value.ToString & "2"
        End If
    End Sub
    Private Sub three_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles three.Click
        If iftxt = 1 Then
            If activeTextBox.Text = "0" Then
                activeTextBox.Text = "3"
            ElseIf (activeTextBox.Text = "0." Or activeTextBox.Text <> "0") Then
                activeTextBox.Text = activeTextBox.Text & "3"
            End If
        Else
            grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value = grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value.ToString & "3"
        End If
    End Sub
    Private Sub four_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles four.Click
        If iftxt = 1 Then
            If activeTextBox.Text = "0" Then
                activeTextBox.Text = "4"
            ElseIf (activeTextBox.Text = "0." Or activeTextBox.Text <> "0") Then
                activeTextBox.Text = activeTextBox.Text & "4"
            End If
        Else
            grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value = grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value.ToString & "4"
        End If
    End Sub
    Private Sub five_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles five.Click
        If iftxt = 1 Then
            If activeTextBox.Text = "0" Then
                activeTextBox.Text = "5"
            ElseIf (activeTextBox.Text = "0." Or activeTextBox.Text <> "0") Then
                activeTextBox.Text = activeTextBox.Text & "5"
            End If
        Else
            grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value = grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value.ToString & "5"
        End If
    End Sub
    Private Sub six_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles six.Click
        If iftxt = 1 Then
            If activeTextBox.Text = "0" Then
                activeTextBox.Text = "6"
            ElseIf (activeTextBox.Text = "0." Or activeTextBox.Text <> "0") Then
                activeTextBox.Text = activeTextBox.Text & "6"
            End If
        Else
            grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value = grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value.ToString & "6"
        End If
    End Sub
    Private Sub seven_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles seven.Click
        If iftxt = 1 Then
            If activeTextBox.Text = "0" Then
                activeTextBox.Text = "7"
            ElseIf (activeTextBox.Text = "0." Or activeTextBox.Text <> "0") Then
                activeTextBox.Text = activeTextBox.Text & "7"
            End If
        Else
            grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value = grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value.ToString & "7"
        End If
    End Sub
    Private Sub eight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles eight.Click
        If iftxt = 1 Then
            If activeTextBox.Text = "0" Then
                activeTextBox.Text = "8"
            ElseIf (activeTextBox.Text = "0." Or activeTextBox.Text <> "0") Then
                activeTextBox.Text = activeTextBox.Text & "8"
            End If
        Else
            grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value = grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value.ToString & "8"
        End If
    End Sub
    Private Sub nine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nine.Click
        If iftxt = 1 Then
            If activeTextBox.Text = "0" Then
                activeTextBox.Text = "9"
            ElseIf (activeTextBox.Text = "0." Or activeTextBox.Text <> "0") Then
                activeTextBox.Text = activeTextBox.Text & "9"
            End If
        Else
            grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value = grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value.ToString & "9"
        End If
    End Sub
    Private Sub numexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numexit.Click
        If iftxt = 1 Then
            activeTextBox.Text = lasttext 'dating laman nya
            Panel12.Visible = False
            panelfalse()
        Else
            If grd.Rows.Count <> 0 Then
                grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value = lastdgv
            End If
            Panel12.Visible = False
            panelfalse()
            'computeamt()
            amount()
            cellendedit()
        End If
    End Sub
    Private Sub numclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numclear.Click
        If iftxt = 1 Then
            activeTextBox.Text = ""
        Else
            grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value = ""
        End If
        dot.Enabled = True
    End Sub
    Private Sub numok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numok.Click
        If iftxt = 1 Then
            activeTextBox.Text = Math.Floor(Val(activeTextBox.Text) * 100) / 100
            If (activeTextBox.Name = "txttable" Or activeTextBox.Name = "txtpax") And activeTextBox.Text = "0" Then
                activeTextBox.Text = ""
            End If
            If activeTextBox.Text.Length > 3 And activeTextBox.Name = "txttable" Then
                activeTextBox.Text = activeTextBox.Text.Substring(0, 3)
            End If
            If activeTextBox.Text.Length > 4 And activeTextBox.Name = "txtpax" Then
                activeTextBox.Text = activeTextBox.Text.Substring(0, 4)
            End If

            Panel12.Visible = False
            panelfalse()
            txtchange.Focus()

            computetotal()
        Else
            'check what column.. if qty, whole num else double
            Dim valy As Double = Val(Trim(grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value.ToString))
            grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value = Math.Floor(Val(valy) * 100) / 100
            If grd.CurrentCell.ColumnIndex = 1 And grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value = 0 Then
                grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value = ""
            End If
            Panel12.Visible = False
            panelfalse()
            'computeamt()
            amount()
            cellendedit()
        End If
    End Sub
    Private Sub dot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dot.Click
        dt = 1
        If iftxt = 1 Then
            If dt = 1 And (Trim(activeTextBox.Text)) <> "" And activeTextBox.Text.Contains(".") = False Then
                activeTextBox.Text = activeTextBox.Text & "."
                dot.Enabled = False
            Else
                dot.Enabled = True
            End If
        Else
            Dim dgvtemp As String = grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value.ToString
            If dt = 1 And (Trim(dgvtemp)) <> "" And dgvtemp.Contains(".") = False Then
                grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value = grd.Rows(grd.CurrentRow.Index).Cells(grd.CurrentCell.ColumnIndex).Value & "."
                dot.Enabled = False
            Else
                dot.Enabled = True
            End If
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        computetotal()
    End Sub

    ''' <summary>
    ''' This is my summary
    ''' </summary>d
    Public Function checkCutOff(ByVal s As String) As Boolean
        Try
            Dim status As String = "", date_from As New DateTime(), query As String = ""

            If login2.wrkgrp = "LC Accounting" Or login2.wrkgrp = "Manager" Then
                query = "Select tblcutoff.status,tblcutoff.date FROM tblcutoff JOIN tblusers ON tblcutoff.userid = tblusers.systemid AND tblusers.workgroup='Sales' ORDER BY cid DESC;"
            Else
                query = "SELECT status,date FROM tblcutoff WHERE userid=(SELECT TOP 1 systemid FROM tblusers WHERE username='" & login2.username & "') ORDER BY cid DESC;"
            End If
            conn.Open()
            cmd = New SqlCommand(query, conn)
            dr = cmd.ExecuteReader
            If dr.Read Then
                status = dr("status")
                date_from = CDate(dr("date"))
            End If
            conn.Close()
            If status = "In Active" And date_from.ToString("MM/dd/yyyy") = getSystemDate.ToString("MM/dd/yyyy") Then
                Return True
            Else
                Return False
            End If
        Catch ex As SqlException
            If ex.Number = -2 Then
                MessageBox.Show("Timeout Occurred", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Function
    Public Function getTransID() As String
        Dim selectcount_result As Long = 0
        Dim temp As String = "0", area_format As String = ""

        conn.Open()
        cmd = New SqlCommand("Select ISNULL(MAX(transaction_id),0) from tblproduction WHERE area='Sales' AND type='Received Item' AND type2='Received From Production';", conn)
        selectcount_result = cmd.ExecuteScalar + 1
        conn.Close()

        Dim branchcode As String = ""

        conn.Open()
        cmd = New SqlCommand("SELECT branchcode FROM tblbranch WHERE main='1';", conn)
        dr = cmd.ExecuteReader
        If dr.Read Then
            branchcode = dr("branchcode")
        End If
        conn.Close()
        area_format = "RECPROD - " & branchcode & " - "

        Dim form As String = ""
        If selectcount_result < 1000000 Then
            Dim cselectcount_result As String = CStr(selectcount_result)
            For vv As Integer = 0 To 6 - cselectcount_result.Length
                temp += "0"
            Next
            form = area_format & temp & selectcount_result
        Else
            form = area_format & temp & selectcount_result
        End If
        Return form
    End Function
    Private Sub btnok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnok.Click
        getID()
        If userc.checkCutOff() Then
            MessageBox.Show("POS already cut off", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf posc.checkQuantity(grd) <> "" Then
            MessageBox.Show("The item(s) below are 0 quantity. Please enter valid input" & Environment.NewLine & posc.checkQuantity(grd), "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf posc.checkQuantityLevel2(grd) <> "" Then
            MessageBox.Show("The item(s) below are 0 quantity. Please enter valid input" & Environment.NewLine & posc.checkQuantityLevel2(grd), "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf posc.checkCSFree(grd) <> "" Then
            MessageBox.Show("The item(s) below have free bread(s). Please enter valid input" & Environment.NewLine & posc.checkCSFree(grd), "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf posc.checkItemAmount(grd) <> "" Then
            MessageBox.Show("Please input amount In item. Please enter valid input" & Environment.NewLine & posc.checkCSFree(grd), "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf posc.checkOrderNumber(ordernum) = True And login2.wrkgrp = "Cashier" Then
            MessageBox.Show("Order # " & lblordernumber.Text & " is already transact", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf grd.RowCount = 0 Then
            MessageBox.Show("No orders entered", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf CDbl(txttendered.Text) < (CDbl(txtboxamountpayable.Text)) And rbtransfer.Checked = False And rbcash.Checked And login2.wrkgrp = "Cashier" Then
            amount()
            MsgBox("Amount tendered Is Not enough To pay the bill. Enter amount.", MsgBoxStyle.Exclamation, "")
            txttendered.Focus()
        ElseIf String.IsNullOrEmpty(txtname.Text) Then
            MessageBox.Show("Please enter name", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtname.Focus()
        ElseIf posc.checkCustomer(txtname.Text, cmbtype.Text) = False And rbcash.Checked = False Then
            MessageBox.Show("Name '" & txtname.Text & "' not found", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtname.Focus()
        ElseIf checkCoffeeShopItem(pos_dialog.ans).ToLower <> "Below item Is invalid for ".ToLower & pos_dialog.ans.ToLower & Environment.NewLine Then
            MessageBox.Show(checkCoffeeShopItem(pos_dialog.ans), "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf Trim(txttendered.Text) = "" Or Val(txttendered.Text) = 0 And login2.wrkgrp = "Cashier" And rbcash.Checked Then
            If String.IsNullOrEmpty(txtchange.Text) And rbcash.Checked Then
                amount()
                MsgBox("Amount tendered is empty. Enter amount first.", MsgBoxStyle.Exclamation, "")
                txttendered.Focus()
            Else
                If posc.checkStocks(grd, inv_id) <> "" Then
                    Dim a As String = MsgBox("Insufficient supply of item below. Are you sure you want to proceed?" & Environment.NewLine & posc.checkStocks(grd, inv_id), MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Atlantic Bakery")
                    If a = vbYes Then
                        confirm.ShowDialog()
                        If voidd Then
                            final()
                        End If
                    End If
                Else
                    final()
                End If
            End If
        Else
            If posc.checkStocks(grd, inv_id) <> "" Then
                Dim a As String = MsgBox("Insufficient supply of item below. Are you sure you want to proceed?" & Environment.NewLine & posc.checkStocks(grd, inv_id), MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Atlantic Bakery")
                If a = vbYes Then
                    confirm.ShowDialog()
                    If voidd Then
                        final()
                    End If
                End If
            Else
                final()
            End If
        End If
    End Sub
    Public Sub final()
        Dim a As String = MsgBox("Confirmed Order?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Atlantic Bakery")
        If a = vbYes Then
            If cas = "Cashier" And CDbl(txtboxamountpayable.Text) < apdepamt Then
                apdep_ans = "No"
            End If
            savetransaction()
        End If
    End Sub
    Public Function checkCoffeeShopItem(posdialog As String) As String
        Dim errorCategory As String = "Below item is invalid for " & posdialog & Environment.NewLine
        For index As Integer = 0 To grd.RowCount - 1
            Dim chckCategory As String = ""
            If pos_dialog.ans = posdialog Then
                conn.Open()
                cmd = New SqlCommand("Select category FROM tblitems WHERE itemname=@iname;", conn)
                cmd.Parameters.AddWithValue("@iname", grd.Rows(index).Cells("description").Value)
                dr = cmd.ExecuteReader
                If dr.Read Then
                    chckCategory = dr("category")
                End If
                conn.Close()

                If posdialog = "Coffee Shop" Then
                    If chckCategory = "Breads" Or chckCategory = "Beverages" Or chckCategory = "Coffee Shop" Then
                        Continue For
                    Else
                        errorCategory &= grd.Rows(index).Cells("description").Value & Environment.NewLine
                    End If
                Else
                    If pos_dialog.ans <> posdialog Then
                        errorCategory &= grd.Rows(index).Cells("description").Value & Environment.NewLine
                    End If
                End If
            End If
        Next
        If errorCategory <> "Below item Is invalid for " & posdialog & Environment.NewLine Then
            Return errorCategory
        End If
    End Function

    Public Sub getARNum(ByVal typee As String, ByVal formatsu As String)
        Try
            Dim temp As String = "0", area_format As String = "", selectcount_result As Integer = 0
            conn.Open()

            cmd = New SqlCommand("Select COUNT(*)  from tblars1 WHERE area='Sales' AND type=@type;", conn)
            cmd.Parameters.AddWithValue("@type", typee)
            selectcount_result = cmd.ExecuteScalar() + 1
            conn.Close()

            Dim branchcode As String = ""
            conn.Open()
            cmd = New SqlCommand("SELECT branchcode FROM tblbranch WHERE main='1';", conn)
            dr = cmd.ExecuteReader
            If dr.Read Then
                branchcode = dr("branchcode")
            End If
            conn.Close()

            area_format = formatsu & " - " & branchcode & " - "

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
        End Try
    End Sub

    Public Function getSalesName() As String
        Dim zz As String = getSystemDate.ToString("MM/dd/yyyy")
        Dim result As String = ""
        conn.Open()
        cmd = New SqlCommand("SELECT cashier FROM tbltransaction2 WHERE CAST(datecreated AS date)='" & zz & "' AND ordernum='" & ornum & "';", conn)
        dr = cmd.ExecuteReader
        If dr.Read Then
            result = dr("cashier")
        End If
        conn.Close()
        Return result
    End Function

    Public Function getTimeSpan() As Integer

        Dim date1 As DateTime = dtdate.Text
        Dim date2 As DateTime = DateTime.Now

        conn.Open()
        cmd = New SqlCommand("SELECT datecreated FROM tbltransaction2 WHERE orderid=" & order_id & ";", conn)
        date1 = cmd.ExecuteScalar
        conn.Close()

        conn.Open()
        cmd = New SqlCommand("SELECT GETDATE()", conn)
        date2 = cmd.ExecuteScalar
        conn.Close()

        Dim ts As TimeSpan = date2.Subtract(date1)
        Return ts.Days
    End Function

    ''' <summary>
    ''' all the motherfucking transaction comes here
    ''' </summary>
    ''' 
    Public Sub savetransaction()
        Try
            getID()
            loadtransnum()
            loadordernum()
            Using connection As New SqlConnection(cc.conString)
                Dim cmdd As New SqlCommand(),
                currentStock As Double = 0.00, addStock As Double = 0.00, seniorResult As Boolean = False, tayp As String = "", resultNo As Double = 0.00
                Dim getServerDate As String = getSystemDate.ToString("MM/dd/yyyy")
                cmdd.Connection = connection

                connection.Open()
                transaction = connection.BeginTransaction()

                cmdd.Transaction = transaction

                If sales_ans = "Coffee Shop" And login2.wrkgrp = "Cashier" Then
                    For index As Integer = 0 To grd.RowCount - 1
                        If grd.Rows(index).Cells("cat").Value = "Coffee Shop" Then
                            conn.Open()
                            cmd = New SqlCommand("Select endbal FROM tblinvitems WHERE invnum=@invnum And itemcode=@itemcode And itemname=@itemname;", conn)
                            cmd.Parameters.AddWithValue("@invnum", inv_id)
                            cmd.Parameters.AddWithValue("@itemcode", grd.Rows(index).Cells("code").Value)
                            cmd.Parameters.AddWithValue("@itemname", grd.Rows(index).Cells("description").Value)
                            dr = cmd.ExecuteReader
                            If dr.Read Then
                                currentStock = CDbl(dr("endbal"))
                            End If
                            conn.Close()
                            If CDbl(grd.Rows(index).Cells("quantity").Value) > currentStock Then
                                addStock = CDbl(grd.Rows(index).Cells("quantity").Value) - currentStock
                            End If
                            If addStock <> 0 Then
                                cmdd.CommandText = "insertCSItems"
                                cmdd.CommandType = CommandType.StoredProcedure
                                cmdd.Parameters.Add(New SqlParameter("@itemcode", grd.Rows(index).Cells("code").Value))
                                cmdd.Parameters.Add(New SqlParameter("@itemname", grd.Rows(index).Cells("description").Value))
                                cmdd.Parameters.Add(New SqlParameter("@category", grd.Rows(index).Cells("cat").Value))
                                cmdd.Parameters.Add(New SqlParameter("@quantity", grd.Rows(index).Cells("quantity").Value))
                                cmdd.Parameters.Add(New SqlParameter("@invnum", inv_id))
                                cmdd.Parameters.Add(New SqlParameter("@transnum", getTransID()))
                                cmdd.Parameters.Add(New SqlParameter("@username", login2.username))
                                cmdd.ExecuteNonQuery()
                            End If
                        End If
                    Next
                End If

                If login2.wrkgrp = "Cashier" Then

                    Dim arRemarks As String = ""
                    If rbAR.Checked Then
                        ar_remarks.ShowDialog()
                        arRemarks = ar_remarks.txtremarks.Text
                    End If
                    cmdd.Parameters.Clear()
                    cmdd.CommandText = "insertTransaction"
                    cmdd.CommandType = CommandType.StoredProcedure
                    cmdd.Parameters.Add(New SqlParameter("@ordernum", order_id))
                    cmdd.Parameters.Add(New SqlParameter("@or", txtor.Text))
                    cmdd.Parameters.Add(New SqlParameter("@transnum", lbltrnum.Text))
                    cmdd.Parameters.Add(New SqlParameter("@invnum", inv_id))
                    cmdd.Parameters.Add(New SqlParameter("@cashier", login2.username))
                    cmdd.Parameters.Add(New SqlParameter("@tendertype", tendertype))
                    cmdd.Parameters.Add(New SqlParameter("@servicetype", servicetype))
                    cmdd.Parameters.Add(New SqlParameter("@delcharge", CDbl(txtdeliver.Text)))
                    cmdd.Parameters.Add(New SqlParameter("@subtotal", CDbl(txtsub.Text)))
                    cmdd.Parameters.Add(New SqlParameter("@disctype", cmbdis.Text))
                    cmdd.Parameters.Add(New SqlParameter("@less", txtless.Text))
                    cmdd.Parameters.Add(New SqlParameter("@vatsales", 0))
                    cmdd.Parameters.Add(New SqlParameter("@vat", 0))
                    cmdd.Parameters.Add(New SqlParameter("@amtdue", CDbl(txtboxamountpayable.Text)))
                    cmdd.Parameters.Add(New SqlParameter("@gctotal", CDbl(txtgc.Text)))
                    cmdd.Parameters.Add(New SqlParameter("@tenderamt", CDbl(txttendered.Text)))
                    cmdd.Parameters.Add(New SqlParameter("@ar_amtdue", IIf(apdep_ans <> "", CDbl(txtsub.Text), CDbl(txtboxamountpayable.Text))))
                    cmdd.Parameters.Add(New SqlParameter("@change", CDbl(txtchange.Text)))
                    cmdd.Parameters.Add(New SqlParameter("@refund", 0))
                    cmdd.Parameters.Add(New SqlParameter("@comment", ""))
                    cmdd.Parameters.Add(New SqlParameter("@remarks", ""))
                    cmdd.Parameters.Add(New SqlParameter("@customer", txtname.Text))
                    cmdd.Parameters.Add(New SqlParameter("@tinum", "n/A"))
                    cmdd.Parameters.Add(New SqlParameter("@tablenum", 0))
                    cmdd.Parameters.Add(New SqlParameter("@pax", 0))
                    cmdd.Parameters.Add(New SqlParameter("@status", 1))
                    cmdd.Parameters.Add(New SqlParameter("@area", "Sales"))
                    cmdd.Parameters.Add(New SqlParameter("@partialamt", 0))
                    cmdd.Parameters.Add(New SqlParameter("@typenum", "AR"))
                    cmdd.Parameters.Add(New SqlParameter("@sap_number", "To Follow"))
                    cmdd.Parameters.Add(New SqlParameter("@sap_remarks", ""))
                    cmdd.Parameters.Add(New SqlParameter("@typez", sales_ans))
                    cmdd.Parameters.Add(New SqlParameter("@discamt", txtdiscamt.Text))
                    cmdd.Parameters.Add(New SqlParameter("@salesname", getSalesName()))
                    cmdd.Parameters.Add(New SqlParameter("@username", login2.username))
                    cmdd.Parameters.Add(New SqlParameter("@ar_remarks", arRemarks))
                    Dim ar_type As String = ""
                    Select Case tendertype
                        Case "Cash"
                            ar_type = "AR Cash"
                        Case "A.R Sales"
                            ar_type = "AR Sales"
                        Case "A.R Charge"
                            ar_type = "AR Charge"
                    End Select
                    cmdd.Parameters.Add(New SqlParameter("@ar_type", ar_type))
                    cmdd.Parameters.Add(New SqlParameter("@ts", getTimeSpan()))
                    cmdd.ExecuteNonQuery()

                    cmdd.Parameters.Clear()
                    cmdd.CommandType = CommandType.Text
                    cmdd.CommandText = "SELECT systemid FROM tblsenior WHERE transnum=@ordernum AND CAST(datedisc AS date)=(select cast(getdate() as date)) AND status=3"
                    cmdd.Parameters.AddWithValue("@ordernum", ornum)
                    dr = cmdd.ExecuteReader
                    If dr.Read Then
                        seniorResult = True
                    End If
                    dr.Close()

                    If seniorResult Then
                        cmdd.Parameters.Clear()
                        cmdd.CommandText = "UPDATE tblsenior SET status=1,transnum=@transnum WHERE transnum=@ordernum AND CAST(datedisc AS date)=(select cast(getdate() as date)) AND status=3"
                        cmdd.Parameters.Add(New SqlParameter("@transnum", lbltrnum.Text))
                        cmdd.Parameters.Add(New SqlParameter("@ordernum", ornum))
                        cmdd.ExecuteNonQuery()
                    End If

                    For index As Integer = 0 To grd.Rows.Count - 1
                        Dim dscntprice As Double = CDbl(grd.Rows(index).Cells("price").Value - ((grd.Rows(index).Cells("discountpercent").Value / 100) * grd.Rows(index).Cells("price").Value))
                        Dim ifree As Double = If(CBool(grd.Rows(index).Cells("free").Value) = True, 1, 0)
                        Dim _gc As Double = 0.0
                        If CDbl(txtgc.Text) <> 0 Then
                            _gc = CDbl(txtgc.Text) / grd.Rows.Count
                        Else
                            _gc = 0
                        End If
                        Dim _less As Double = 0.0, less As Double = 0.0
                        If CDbl(txtless.Text) <> 0 Then
                            Dim fLess As Double = 100 - CDbl(txtless.Text)
                            less = CDbl(fLess) / 100
                            If cmbdis.Text = "Senior Citizen" Or cmbdis.Text = "Pwd" Then
                                cmdd.CommandText = "SELECT basedprice FROM tblgroupdisc WHERE itemname='" & grd.Rows(index).Cells("description").Value & "' AND status='1';"
                                dr = cmdd.ExecuteReader
                                If dr.Read Then
                                    Dim totalPrice As Double = 0.0, tprice As Double = 0.0, ttprice As Double = 0.0
                                    totalPrice = CDbl(grd.Rows(index).Cells("price").Value) * CDbl(grd.Rows(index).Cells("quantity").Value)
                                    tprice = totalPrice - CDbl(dr("basedprice"))
                                    _less = CDbl(dr("basedprice")) / 1.12 * less
                                    ttprice = tprice + _less
                                    _less = totalPrice - ttprice
                                Else
                                    Dim totalPrice As Double = 0.0
                                    totalPrice = CDbl(grd.Rows(index).Cells("price").Value) * CDbl(grd.Rows(index).Cells("quantity").Value)
                                    _less = CDbl(grd.Rows(index).Cells("price").Value) * CDbl(grd.Rows(index).Cells("quantity").Value) / 1.12 * less
                                    _less = totalPrice - _less
                                End If
                                dr.Close()
                            Else
                                cmdd.CommandText = "SELECT basedprice FROM tblgroupdisc WHERE itemname='" & grd.Rows(index).Cells("description").Value & "' AND status='1';"
                                dr = cmdd.ExecuteReader
                                If dr.Read Then
                                    Dim totalPrice As Double = 0.0, tprice As Double = 0.0, ttprice As Double = 0.0
                                    totalPrice = CDbl(grd.Rows(index).Cells("price").Value) * CDbl(grd.Rows(index).Cells("quantity").Value)
                                    tprice = totalPrice - CDbl(dr("basedprice"))
                                    _less = CDbl(dr("basedprice")) * less
                                    ttprice = tprice + _less
                                    _less = totalPrice - ttprice
                                Else
                                    Dim totalPrice As Double = 0.0
                                    totalPrice = CDbl(grd.Rows(index).Cells("price").Value) * CDbl(grd.Rows(index).Cells("quantity").Value)
                                    _less = CDbl(grd.Rows(index).Cells("price").Value) * CDbl(grd.Rows(index).Cells("quantity").Value) * less
                                    _less = totalPrice - _less
                                End If
                                dr.Close()
                            End If
                        Else
                            _less = 0
                        End If

                        'Dim endbal As Double = 0.00, endbal_variance As Double = 0.00
                        'cmd = New SqlCommand("SELECT endbal FROM tblinvitems WHERE invnum=@invnum AND itemname=@itemname;", connection)
                        'cmd.Parameters.AddWithValue("@invnum", inv_id)
                        'cmd.Parameters.AddWithValue("@itemname", Trim(grd.Rows(index).Cells("description").Value))
                        'dr = cmd.ExecuteReader
                        'If dr.Read Then
                        '    endbal = CDbl(dr("endbal"))
                        'End If

                        'If endbal < CDbl(grd.Rows(index).Cells("quantity").Value) Then
                        '    If endbal > 0 Then
                        '        endbal_variance = endbal - CDbl(grd.Rows(index).Cells("quantity").Value)
                        '    Else
                        '        endbal_variance = 0 - CDbl(grd.Rows(index).Cells("quantity").Value)
                        '    End If
                        'End If

                        Dim ff As String = ""
                        If cmbtype.Text = "Customer" Then
                            ff = "A.R Sales"
                        ElseIf cmbtype.Text = "Employee" Then
                            ff = "A.R Charge"
                        End If
                        cmdd.CommandText = "Insert into tblorder (transnum, category, itemname, qty, price, totalprice, dscnt, free, request, status, discprice, disctrans,area,invnum,type,gc,less,deliver,pricebefore,discamt,endbal_variance)values('" & lbltrnum.Text & "','" & grd.Rows(index).Cells("cat").Value & "','" & grd.Rows(index).Cells("description").Value & "','" & CDbl(grd.Rows(index).Cells("quantity").Value) & "','" & CDbl(grd.Rows(index).Cells("price").Value) & "','" & CDbl(grd.Rows(index).Cells("amtdue").Value) & "','" & CDbl(grd.Rows(index).Cells("discountpercent").Value) & "','" & ifree & "','" & grd.Rows(index).Cells("request").Value & "','1','" & dscntprice & "','" & "0" & "','" & "Sales" & "','" & inv_id & "','" & ff & "','" & _gc & "','" & _less & "','" & "0" & "','" & CDbl(grd.Rows(index).Cells("pricebefore").Value) & "','" & CDbl(grd.Rows(index).Cells("discamt").Value) & "',(SELECT SUM(endbal-" & CDbl(grd.Rows(index).Cells("quantity").Value) & ") FROM tblinvitems WHERE invnum='" & inv_id & "' AND itemname='" & grd.Rows(index).Cells("description").Value & "'))"
                        cmdd.CommandType = CommandType.Text
                        cmdd.ExecuteNonQuery()

                        Dim sdate As String = getSystemDate.ToString("MM/dd/yyyy")
                        cmdd.Parameters.Clear()
                        cmdd.CommandText = "UPDATE tblorder2 SET qty=@qty,dscnt=@discount,totalprice=@totalprice,discprice=@discprice,free=@free,pricebefore=@pricebefore,discamt=@discamt WHERE ordernum=@ordernum AND CAST(datecreated AS date)=@date"
                        cmdd.Parameters.Add(New SqlParameter("@qty", CDbl(grd.Rows(index).Cells("quantity").Value)))
                        cmdd.Parameters.Add(New SqlParameter("@discount", CDbl(grd.Rows(index).Cells("discountpercent").Value)))
                        cmdd.Parameters.Add(New SqlParameter("@totalprice", CDbl(grd.Rows(index).Cells("amtdue").Value)))
                        cmdd.Parameters.Add(New SqlParameter("@free", IIf(CBool(grd.Rows(index).Cells("free").Value) <> False, 1, 0)))
                        cmdd.Parameters.Add(New SqlParameter("@pricebefore", CDbl(grd.Rows(index).Cells("pricebefore").Value)))
                        cmdd.Parameters.Add(New SqlParameter("@discamt", CDbl(grd.Rows(index).Cells("discamt").Value)))
                        cmdd.Parameters.Add(New SqlParameter("@discprice", dscntprice))
                        cmdd.Parameters.Add(New SqlParameter("@ordernum", ornum))
                        cmdd.Parameters.Add(New SqlParameter("date", sdate))
                        cmdd.ExecuteNonQuery()

                        cmdd.CommandText = "INSERT INTO tblars2 (transnum,description,quantity,price,amount,area,name) VALUES ('" & lbltrnum.Text & "', '" & grd.Rows(index).Cells("description").Value & "' ,'" & CDbl(grd.Rows(index).Cells("quantity").Value) & "','" & CDbl(grd.Rows(index).Cells("price").Value) & "','" & CDbl(grd.Rows(index).Cells("amtdue").Value) & "','" & login2.wrkgrp & "','" & txtname.Text & "')"
                        cmdd.ExecuteNonQuery()
                        Dim arVal As String = ""
                        Select Case tendertype
                            Case "A.R Charge"
                                arVal = "archarge"
                            Case "Cash"
                                arVal = "ctrout"
                            Case "A.R Sales"
                                arVal = "arsales"
                        End Select

                        cmdd.CommandText = "Update tblinvitems set " & arVal & "+=" & CDbl(grd.Rows(index).Cells("quantity").Value) & ", endbal-=" & CDbl(grd.Rows(index).Cells("quantity").Value) & ", variance+=" & CDbl(grd.Rows(index).Cells("quantity").Value) & " where itemname='" & grd.Rows(index).Cells("description").Value & "' AND invnum='" & inv_id & "';"
                        cmdd.ExecuteNonQuery()
                    Next
                Else
                    Dim zz As String = getSystemDate.ToString("yyyy-MM-dd")
                    Dim zzz As String = getSystemDate()
                    cmdd.Parameters.Clear()
                    cmdd.CommandText = "INSERT INTO tbltransaction2 (ornum, ordernum, transdate, cashier, tendertype, servicetype, delcharge, subtotal, disctype, less, vatsales, vat, amtdue, tenderamt, change, refund, comment, remarks, customer, tinnum, tablenum, pax, createdby, datecreated, datemodified, status, status2, area, gctotal, typez, discamt) VALUES ('000',@ordernum,@transdate,@cashier,@tendertype,@servicetype,@delcharge,@subtotal,@disctype,@less,@vatsales,@vat,@amtdue,@tenderamt,@change,@refund,@comment,@remarks,@customer,@tinum,0,0,@createdby,@zz,@zz,1,'Unpaid','Sales',@gctotal,@type,@discamt);"
                    cmdd.Parameters.AddWithValue("@ordernum", lblordernumber.Text)
                    cmdd.Parameters.AddWithValue("@transdate", zz)
                    cmdd.Parameters.AddWithValue("@zz", zzz)
                    cmdd.Parameters.AddWithValue("@cashier", login2.username)
                    cmdd.Parameters.AddWithValue("@tendertype", tendertype)
                    cmdd.Parameters.AddWithValue("@servicetype", servicetype)
                    cmdd.Parameters.AddWithValue("@delcharge", 0)
                    cmdd.Parameters.AddWithValue("@subtotal", CDbl(txtsub.Text))
                    cmdd.Parameters.AddWithValue("@disctype", cmbdis.Text)
                    cmdd.Parameters.AddWithValue("@less", CDbl(txtless.Text))
                    cmdd.Parameters.AddWithValue("@vatsales", CDbl(txtvatsales.Text))
                    cmdd.Parameters.AddWithValue("@vat", CDbl(txtvatamt.Text))
                    cmdd.Parameters.AddWithValue("@amtdue", CDbl(txtboxamountpayable.Text))
                    cmdd.Parameters.AddWithValue("@tenderamt", CDbl(txttendered.Text))
                    cmdd.Parameters.AddWithValue("@change", CDbl(txtchange.Text))
                    cmdd.Parameters.AddWithValue("@refund", 0)
                    cmdd.Parameters.AddWithValue("@comment", "")
                    cmdd.Parameters.AddWithValue("@remarks", "")
                    cmdd.Parameters.AddWithValue("@customer", txtname.Text)
                    cmdd.Parameters.AddWithValue("@tinum", txttin.Text)
                    cmdd.Parameters.AddWithValue("@createdby", login2.username)
                    cmdd.Parameters.AddWithValue("@gctotal", CDbl(txtgc.Text))
                    cmdd.Parameters.AddWithValue("@type", pos_dialog.ans)
                    cmdd.Parameters.AddWithValue("@discamt", CDbl(txtdiscamt.Text))
                    cmdd.ExecuteNonQuery()
                    If cmbdis.Text <> "" Then
                        cmdd.Parameters.Clear()
                        cmdd.CommandText = "INSERT INTO tblsenior (transnum,idno,name,disctype,datedisc,status) VALUES (@transnum,@idno,@name,@disctype,@zz,3)"
                        cmdd.Parameters.AddWithValue("@transnum", lblordernumber.Text)
                        cmdd.Parameters.AddWithValue("@idno", senior.txtidno.Text)
                        cmdd.Parameters.AddWithValue("@name", senior.txtname.Text)
                        cmdd.Parameters.AddWithValue("@disctype", cmbdis.Text)
                        cmdd.ExecuteNonQuery()
                    End If

                    For index As Integer = 0 To grd.Rows.Count - 1
                        Dim dscntprice As Double = CDbl(grd.Rows(index).Cells("price").Value - ((grd.Rows(index).Cells("discountpercent").Value / 100) * grd.Rows(index).Cells("price").Value))
                        Dim ifree As Double = If(CBool(grd.Rows(index).Cells("free").Value) = True, 1, 0)
                        cmdd.CommandText = "Insert into tblorder2 (ordernum, category, itemname, qty, price, totalprice, dscnt, free, request, status, discprice, disctrans,area,gc,less,deliver,datecreated,pricebefore,discamt)values('" & lblordernumber.Text & "','" & grd.Rows(index).Cells("cat").Value & "','" & grd.Rows(index).Cells("description").Value & "','" & CDbl(grd.Rows(index).Cells("quantity").Value) & "','" & CDbl(grd.Rows(index).Cells("price").Value) & "','" & CDbl(grd.Rows(index).Cells("amtdue").Value) & "','" & CDbl(grd.Rows(index).Cells("discountpercent").Value) & "','" & ifree & "','" & grd.Rows(index).Cells("request").Value & "',1,'" & dscntprice & "','" & "0" & "','" & "Sales" & "','" & "0" & "','" & "0" & "','" & "0" & "','" & zzz & "', '" & CDbl(grd.Rows(index).Cells("pricebefore").Value) & "','" & CDbl(grd.Rows(index).Cells("discamt").Value) & "')"
                        cmdd.ExecuteNonQuery()
                    Next

                End If
                If txtadvancepayment.Text <> "0.00" Or txtadvancepayment.Text <> "" Then
                    Dim words() As String = txtadvancepayment.Text.Split(New Char() {","c})
                    Dim word As String
                    For Each word In words
                        Dim zzz As String = getSystemDate()
                        If Not String.IsNullOrEmpty(word) Then
                            Dim amt As Double = 0.00, ap_id As Integer = 0
                            cmdd.CommandText = "SELECT ap_id,amount,type FROM tbladvancepayment WHERE apnum='" & word & "';"
                            dr = cmdd.ExecuteReader
                            If dr.Read Then
                                amt = CDbl(dr("amount"))
                                tayp = CStr(dr("type"))
                                ap_id = CInt(dr("ap_id"))
                            End If
                            dr.Close()

                            If tayp = "Deposit" Then
                                cmdd.CommandText = "INSERT INTO tblreturns (ap_id,returnum,transnum,status,byy,date) VALUES (@id,@returnum,@transnum,@status,@byy,@zz);"
                                cmdd.Parameters.Clear()
                                cmdd.Parameters.AddWithValue("@id", ap_id)
                                cmdd.Parameters.AddWithValue("@returnum", returnnum)
                                cmdd.Parameters.AddWithValue("@transnum", lbltrnum.Text)
                                cmdd.Parameters.AddWithValue("@status", "Active")
                                cmdd.Parameters.AddWithValue("@byy", login2.username)
                                cmdd.Parameters.AddWithValue("@zz", zzz)
                                cmdd.ExecuteNonQuery()
                                'getReturnNum()

                                cmdd.Parameters.Clear()
                                cmdd.CommandText = "UPDATE tbladvancepayment SET status='Used',from_trans=@trans WHERE apnum=@id;"
                                cmdd.Parameters.AddWithValue("@id", word)
                                cmdd.Parameters.AddWithValue("@trans", lbltrnum.Text)
                                cmdd.ExecuteNonQuery()
                            ElseIf tayp = "Advance Payment" Then
                                Dim zz As String = getSystemDate.ToString("MM/dd/yyyy")
                                cmdd.Parameters.Clear()
                                cmdd.CommandText = "Insert into tbltransaction (ornum, transnum, transdate, cashier, tendertype, servicetype, delcharge, subtotal, disctype, less, vatsales, vat, amtdue, gctotal, tenderamt, change, refund, comment, remarks, customer, tinnum, tablenum, pax, datecreated, datemodified, status,area,invnum,partialamt,typenum,sap_number,sap_remarks,typez,salesname) values ('" & txtor.Text & "', '" & lbltrnum.Text & "',(select cast(getdate() as date)),'" & login2.username & "', '" & "Advance Payment" & "', '" & "Advance Payment" & "', '" & CDbl(txtdeliver.Text) & "', '" & CDbl(txtsub.Text) & "', '" & cmbdis.SelectedItem & "', '" & CDbl(txtless.Text) & "', '" & CDbl(txtvatsales.Text) & "', '" & CDbl(txtvatamt.Text) & "', '" & IIf(CDbl(txtsub.Text) < CDbl(amt), CDbl(txtsub.Text), amt) & "', '" & CDbl(txtgc.Text) & "', '" & CDbl(txttendered.Text) & "', '" & CDbl(txtchange.Text) & "', '0', '', '', '" & txtname.Text & "', '" & "N/A" & "', '" & "0" & "', '" & "0" & "','" & zzz & "','" & zzz & "', '1','" & "Sales" & "','" & inv_id & "','0','','','','" & sales_ans & "',(SELECT cashier FROM tbltransaction2 WHERE CAST(datecreated AS date)='" & zz & "' And ordernum='" & ornum & "'))"
                                cmdd.ExecuteNonQuery()
                                If CDbl(txtboxamountpayable.Text) < amt Then
                                    resultNo = amt - CDbl(txtsub.Text)
                                End If

                                If apdep_ans = "Yes" Then
                                    cmdd.CommandText = "Insert into tbltransaction (ornum, transnum, transdate, cashier, tendertype, servicetype, delcharge, subtotal, disctype, less, vatsales, vat, amtdue, gctotal, tenderamt, change, refund, comment, remarks, customer, tinnum, tablenum, pax, datecreated, datemodified, status,area,invnum,partialamt,typez,salesname) values ('" & "0" & "', '" & lbltrnum.Text & "',(select cast(getdate() as date)),'" & login2.username & "', '" & "Cash Out" & "', '" & "Cash Out" & "', '" & "0" & "', '" & "0" & "', '" & "N/A" & "', '" & "0" & "', '" & "0" & "', '" & "0" & "', '" & resultNo & "', '" & "0" & "', '" & "0" & "', '" & "0" & "', '0', '', '', '" & txtname.Text & "', '" & "0" & "', '" & "0" & "', '" & "0" & "','" & zzz & "','" & zzz & "', '1','" & "Sales" & "','" & inv_id & "','0','" & sales_ans & "',(SELECT cashier FROM tbltransaction2 WHERE CAST(datecreated AS date)=(select cast(getdate() as date)) AND ordernum='" & ornum & "'))"
                                    cmdd.ExecuteNonQuery()

                                    cmdd.Parameters.Clear()
                                    cmdd.CommandText = "UPDATE tbladvancepayment SET status='Used',from_trans=@trans WHERE apnum=@id;"
                                    cmdd.Parameters.AddWithValue("@id", word)
                                    cmdd.Parameters.AddWithValue("@trans", lbltrnum.Text)
                                    cmdd.ExecuteNonQuery()
                                ElseIf apdep_ans = "No" Then
                                    If resultNo = 0 Then

                                        cmdd.Parameters.Clear()
                                        cmdd.CommandText = "UPDATE tbladvancepayment SET status='Used',from_trans=@trans WHERE apnum=@id;"
                                        cmdd.Parameters.AddWithValue("@id", word)
                                        cmdd.Parameters.AddWithValue("@trans", lbltrnum.Text)
                                        cmdd.ExecuteNonQuery()
                                    Else

                                        cmdd.Parameters.Clear()
                                        cmdd.CommandText = "UPDATE tbladvancepayment SET amount=@amount,from_trans=@trans WHERE apnum=@id;"
                                        cmdd.Parameters.AddWithValue("@id", word)
                                        cmdd.Parameters.AddWithValue("@amount", resultNo)
                                        cmdd.Parameters.AddWithValue("@trans", lbltrnum.Text)
                                        cmdd.ExecuteNonQuery()
                                    End If
                                ElseIf apdep_ans = "" Then
                                    cmdd.CommandText = "UPDATE tbladvancepayment SET status='Used',from_trans=@trans WHERE apnum=@id;"
                                    cmdd.Parameters.AddWithValue("@id", word)
                                    cmdd.Parameters.AddWithValue("@trans", lbltrnum.Text)
                                    cmdd.ExecuteNonQuery()
                                End If
                            End If
                        End If
                    Next
                End If
                transaction.Commit()
            End Using
            If login2.wrkgrp <> "Cashier" Then

                Dim frm As New form_printorder()
                frm.lblordernum.Text = ordernum
                frm.ShowDialog()

                defaultload()
                txtname.ReadOnly = True
                txtname.BackColor = Color.WhiteSmoke
                rbcash.Checked = True
                txtname.Text = "CASH"
                grd.Rows.Clear()
                loadtransnum()
                loadordernum()
            End If

            If login2.wrkgrp = "Cashier" Then
                defaultload()
                txtname.ReadOnly = True
                txtname.BackColor = Color.WhiteSmoke
                MessageBox.Show("Transaction Completed", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Information)
                sales_ans = ""
                rbcash.Checked = True
                txtname.Text = "CASH"
                grd.Rows.Clear()
                loadtransnum()
                loadordernum()
                lblcount.Text = "ITEMS (" & grd.RowCount & ")"
                Me.Dispose()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Try
                transaction.Rollback()
            Catch ex2 As Exception
                MessageBox.Show(ex2.ToString)
            End Try
        Finally
            conn.Close()
        End Try
    End Sub
    Public Sub getReturnNum()
        Try
            Dim selectcount_result As Integer = 0
            Dim get_area As String = "", temp As String = "0"
            Dim area_format As String = ""
            conn.Open()
            cmd = New SqlCommand("Select COUNT(id) FROM tblreturns;", conn)
            cmd.Parameters.AddWithValue("@type", cmbtype.Text)
            selectcount_result = cmd.ExecuteScalar() + 1
            conn.Close()

            Dim branchcode As String = ""
            conn.Open()
            cmd = New SqlCommand("SELECT branchcode FROM tblbranch WHERE main='1';", conn)
            dr = cmd.ExecuteReader
            While dr.Read
                branchcode = dr("branchcode")
            End While
            conn.Close()
            area_format = "SALRETURN - " & branchcode & " - "
            If selectcount_result < 1000000 Then
                Dim cselectcount_result As String = CStr(selectcount_result)
                For vv As Integer = 1 To 6 - cselectcount_result.Length
                    temp += "0"
                Next
                returnnum = area_format & temp & selectcount_result
            End If
        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information, "")
        End Try
    End Sub
    Private Sub btncutoff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncutoff.Click
        Try
            Dim systemid As Integer = 0
            Dim a As String = MsgBox("Are you sure you want to cut off?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "")
            If a = vbYes Then
                confirm.ShowDialog()
                conn.Open()
                cmd = New SqlCommand("SELECT systemid FROM tblusers WHERE username=@username;", conn)
                cmd.Parameters.AddWithValue("@username", login2.username)
                dr = cmd.ExecuteReader
                If dr.Read Then
                    systemid = CInt(dr("systemid"))
                End If
                conn.Close()
                If systemid = 0 Then
                    MessageBox.Show("No user found", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    conn.Open()
                    cmd = New SqlCommand("UPDATE tblcredits SET cutoff='1' WHERE systemid=@id AND invnum=@invnum;", conn)
                    cmd.Parameters.AddWithValue("@id", systemid)
                    cmd.Parameters.AddWithValue("@invnum", inv_id)
                    cmd.ExecuteNonQuery()
                    conn.Close()
                    MessageBox.Show("Done", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Dispose()
                    login2.Show()
                End If
            End If
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information)
        End Try
    End Sub

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        Try
            If grd.Rows.Count <> 0 Then
                Dim a As String = MsgBox("Please confirm CANCELLATION of this transaction.", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MessageBoxDefaultButton.Button2, "")
                If a = vbYes Then
                    grd.Rows.Clear()
                    defaultload()
                    gcform.grdgc.Rows.Clear()
                    gcform.txtamt.Text = "100.00"
                    gcform.txtserial.Text = ""
                    gcform.lblgctotal.Text = "0.00"

                    voidd = False
                    lblcount.Text = "ITEMS (" & grd.RowCount & ")"
                End If
            Else
                MsgBox("No orders entered. Please check entries.", MsgBoxStyle.Exclamation, "")
                rbdeliver.Checked = False
                rbcash.Checked = True
                '/   btnok.Enabled = True
                defaultload()
                lblcount.Text = "ITEMS (" & grd.RowCount & ")"
                Exit Sub
            End If
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information)
        End Try
    End Sub



    Public Sub loadtransnum()
        Try
            Dim area As String = "Sales"
            Dim selectcount_result As Integer = 0
            Dim branchcode As String = "", temp As String = "0", area_format As String = ""
            conn.Open()
            cmd = New SqlCommand("SELECT ISNULL(MAX(transid),0) FROM tbltransaction WHERE area='" & area & "' AND tendertype !='Advance Payment' AND tendertype !='Cash Out' AND tendertype!='Deposit' AND tendertype !='Advance Payment Cash';", conn)
            selectcount_result = cmd.ExecuteScalar() + 1
            conn.Close()

            conn.Open()
            cmd = New SqlCommand("Select branchcode FROM tblbranch WHERE main='1';", conn)
            dr = cmd.ExecuteReader
            If dr.Read Then
                branchcode = dr("branchcode")
            End If
            conn.Close()
            area_format = "TR - " & branchcode & " - "
            If selectcount_result < 1000000 Then
                Dim cselectcount_result As String = CStr(selectcount_result)
                For vv As Integer = 1 To 6 - cselectcount_result.Length
                    temp += "0"
                Next
                lbltrnum.Text = area_format & temp & selectcount_result
            Else
                lbltrnum.Text = area_format & temp & selectcount_result
            End If

            lbltrnum.Text = area_format & temp & selectcount_result

        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information, "")
        End Try
    End Sub
    Public Sub loadordernum()
        Try
            Dim selectcount_result As Integer = 0
            Dim temp As String = "0", area_format As String = "", branchcode As String = ""

            Dim area As String = "Sales"
            Dim getserverDate As String = getSystemDate.ToString("MM/dd/yyyy")

            conn.Open()
            cmd = New SqlCommand("Select ISNULL(MAX(ordernum),0) from tbltransaction2 WHERE area='" & area & "' AND CAST(datecreated AS date)='" & getserverDate & "';", conn)
            selectcount_result = cmd.ExecuteScalar() + 1
            conn.Close()

            conn.Open()
            cmd = New SqlCommand("SELECT ordernum FROM tbltransaction2 WHERE ordernum=@ordernum AND CAST(datecreated AS date)='" & getserverDate & "';", conn)
            cmd.Parameters.AddWithValue("@ordernum", selectcount_result)
            dr = cmd.ExecuteReader
            If dr.Read Then
                selectcount_result += 1
            End If
            conn.Close()

            lblordernumber.Text = selectcount_result
            ordernum = lblordernumber.Text
        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information, "")
        End Try
    End Sub
    Private Sub btnvoid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnvoid.Click
        If grd.Rows.Count = 0 Then
            txtitem.Text = "0.00"
            txtsub.Text = "0.00"
            txttendered.Text = "0.00"
            txtchange.Text = "0.00"
            txttotal.Text = "0.00"
            txtboxamountpayable.Text = "0.00"
            MessageBox.Show("No item selected", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            grd.Rows.Remove(grd.CurrentRow)
            computetotal()
        End If
        lblcount.Text = "ITEMS (" & grd.RowCount & ")"
    End Sub

    Private Sub rbtake_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtake.CheckedChanged
        If rbtake.Checked = True Then
            txtdeliver.Text = "0.00"
            computetotal()
            lblbranch.Text = ""
            If login2.wrkgrp = "Sales" Then
                txtname.Text = "CASH"
                txtname.BackColor = Color.WhiteSmoke
                txtname.ReadOnly = True
            End If
        End If
        servicetype = "Take out"
    End Sub

    Private Sub rbdinein_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbdine.CheckedChanged
        txtdeliver.Text = "0.00"
        computetotal()
        lblbranch.Text = ""
        If login2.wrkgrp = "Sales" Then
            txtname.Text = "CASH"
            txtname.BackColor = Color.WhiteSmoke
            txtname.ReadOnly = True
        End If
        servicetype = "Dine in"
    End Sub

    Private Sub btnrefund_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrefund.Click
        Dim a As String = MsgBox("Please confirm to cancel transaction.", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "")
        If a = vbYes Then
            confirm.ShowDialog()
            If voidd = True Then
                refundform.ShowDialog()
            End If
            voidd = False
        End If
    End Sub

    Public Sub viewdiscount()
        Try
            cmbdis.Items.Clear()
            cmbdis.Items.Add("")
            sql = "Select * from tbldiscount where status='1' order by disname"
            conn.Open()
            cmd = New SqlCommand(sql, conn)
            dr = cmd.ExecuteReader
            While dr.Read
                cmbdis.Items.Add(dr("disname"))
            End While
            conn.Close()

            txtless.Text = "0.00"
            lblidno.Text = ""
            lblname.Text = ""


        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information)
        End Try
    End Sub

    Private Sub cmbdis_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbdis.Click
        viewdiscount()
    End Sub

    Private Sub cmbdis_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbdis.Leave
        If cmbdis.Text = "" Then
            txtless.Text = "0.00"
            lblidno.Text = ""
            lblname.Text = ""
            computetotal()
        End If
    End Sub


    Public Sub defaultload()
        txtitem.Text = "0.00"
        txtsub.Text = "0.00"
        txtdeliver.Text = "0.00"
        cmbdis.SelectedIndex = 0
        txtless.Text = "0.00"
        txtgc.Text = "0.00"
        txttendered.Text = "0.00"
        txtchange.Text = "0.00"
        txttotal.Text = "0.00"
        lblidno.Text = ""
        lblname.Text = ""
        rbtake.Checked = True
        txtor.Text = "0000"
        txtboxamountpayable.Text = "0.00"
        If login2.wrkgrp = "Sales" Then
            txtname.Text = "CASH"
        End If
        txttin.Text = "N/A"

        txtvatsales.Text = "0.00"
        txtvatamt.Text = "0.00"
        txtvatex.Text = "0.00"

        Panel14.Enabled = True
        Panel5.Enabled = True
        TableLayoutPanel2.Enabled = True
        Panel15.Enabled = True
        cmbdis.Enabled = True
        txttendered.Enabled = True
        chkkey.Enabled = True
        btncancel.Enabled = True
        btnvoid.Enabled = True
        btnok.Enabled = True
        'End If
    End Sub

    Private Sub btnreprint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnreprint.Click
        reprintor.ShowDialog()
    End Sub

    Public Sub btntrans1()
        counters = True
        transactions.Dispose()
        dailysalesprev.Close()
        transactions.ShowDialog()
        counters = False
    End Sub

    Private Sub txttendered_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttendered.Leave
        cmp()
        If Trim(txttendered.Text) = "" Then
            txttendered.Text = "0.00"
        End If
    End Sub

    Public Sub savelogout()
        Try
            Dim logid As Integer = 0, zz As String = getSystemDate.ToString("MM/dd/yyyy"), aa As String = getSystemDate.ToString("HH:mm")

            sql = "Select * from tbllogin where datelogin='" & zz & "' and username='" & login2.wrkgrp & "'"
            conn.Open()
            cmd = New SqlCommand(sql, conn)
            dr = cmd.ExecuteReader
            If dr.Read Then
                logid = dr("systemid")
            End If
            conn.Close()

            sql = "Update tbllogin set logout='" & aa & "' where systemid='" & logid & "'"
            conn.Open()
            cmd = New SqlCommand(sql, conn)
            cmd.ExecuteNonQuery()
            conn.Close()

        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information)
        End Try
    End Sub

    Public Sub ref()
        Try
            For Each btn As Button In Panel5.Controls
                If btn.Enabled = False Then
                    clickbtn = CType(btn, Button)
                    clearpanel()
                    viewitems("")
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub mainmenu_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If cas <> "Cashier" And amt = "" And apdepamt = 0 Then
            defaultload()
        Else
            txtadvancepayment.Text = amt
            txtgc.Text = cGc.ToString("n2")
            cmbdis.Text = cDisType
            txtless.Text = cLess.ToString("n2")
            txtdeliver.Text = cDelCharge.ToString("n2")
            computetotal()
        End If



    End Sub

    Private Sub txtor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtor.KeyPress
        If Asc(e.KeyChar) = Windows.Forms.Keys.Enter Then
            cmp()
        End If

        If (Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57) And Asc(e.KeyChar) <> 8 And Asc(e.KeyChar) <> 127 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtor_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtor.Leave
        Try
            If Trim(txtor.Text) <> "" Then
                sql = "Select ornum from tbltransaction where ornum='" & Trim(txtor.Text) & "'"
                conn.Open()
                cmd = New SqlCommand(sql, conn)
                dr = cmd.ExecuteReader
                If dr.Read Then
                    MsgBox("OR number " & Trim(txtor.Text) & " is already exist!", MsgBoxStyle.Exclamation, "")
                    txtor.Text = "0000"
                    'txtor.Focus()
                Else
                    txtor.Text = Trim(txtor.Text)
                End If
                conn.Close()
            Else
                MsgBox("OR number should not be empty.", MsgBoxStyle.Exclamation, "")
                txtor.Focus()
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub txtname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtname.KeyPress
        If Asc(e.KeyChar) = Windows.Forms.Keys.Enter Then
            cmp()
        End If

        If Asc(e.KeyChar) = 39 Then
            e.Handled = True
        End If
    End Sub

    Private Sub grd_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles grd.DataError
        If (e.Context = DataGridViewDataErrorContexts.LeaveControl) Then
            MessageBox.Show("leave control error")
        End If
    End Sub

    Private Sub grd_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles grd.EditingControlShowing
        'Dim comboBoxColumn As DataGridViewComboBoxColumn = grd.Columns(0)
        'If (grd.CurrentCellAddress.X = comboBoxColumn.DisplayIndex) Then
        '    Dim cb As ComboBox = e.Control
        '    If (cb IsNot Nothing) Then
        '        cb.DropDownStyle = ComboBoxStyle.DropDown
        '        cb.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        '    End If
        'End If
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles rbcoffee.CheckedChanged
        If rbcoffee.Checked Then

            If conn.State <> ConnectionState.Open Then
                conn.Close()
            Else
                conn.Open()
            End If

            Dim result As Boolean = False
            conn.Open()
            cmd = New SqlCommand("SELECT userid FROM tblusers WHERE username=@username AND postype=@postype;", conn)
            cmd.Parameters.AddWithValue("@username", login2.username)
            cmd.Parameters.AddWithValue("@postype", "Coffee Shop")
            dr = cmd.ExecuteReader
            If dr.Read Then
                result = True
            End If
            conn.Close()
            If result = False Then
                confirm.ShowDialog()
                If voidd = True Then
                    pos_dialog.ans = "Coffee Shop"
                    grd.Columns("amtdue").ReadOnly = False

                    Panel5.Controls.Clear()
                    Panel14.Controls.Clear()
                    viewcat()
                    loadItems()
                    grd.Columns("discountpercent").ReadOnly = False
                    grd.Rows.Clear()
                End If
            Else
                pos_dialog.ans = "Coffee Shop"
                grd.Columns("amtdue").ReadOnly = False

                Panel5.Controls.Clear()
                Panel14.Controls.Clear()
                viewcat()
                loadItems()
                grd.Columns("discountpercent").ReadOnly = False
                grd.Rows.Clear()
            End If

        End If
    End Sub

    Private Sub rbretail_CheckedChanged(sender As Object, e As EventArgs) Handles rbretail.CheckedChanged
        If rbretail.Checked Then
            Dim result As Boolean = False

            If conn.State <> ConnectionState.Open Then
                conn.Close()
            Else
                conn.Open()
            End If

            conn.Open()
            cmd = New SqlCommand("SELECT userid FROM tblusers WHERE username=@username AND postype=@postype;", conn)
            cmd.Parameters.AddWithValue("@username", login2.username)
            cmd.Parameters.AddWithValue("@postype", "Retail")
            dr = cmd.ExecuteReader
            If dr.Read Then
                result = True
            End If
            conn.Close()
            If result = False Then
                confirm.ShowDialog()
                If voidd = True Then
                    pos_dialog.ans = "Retail"
                    grd.Columns("amtdue").ReadOnly = False
                    Panel5.Controls.Clear()
                    Panel14.Controls.Clear()
                    viewcat()
                    loadItems()

                    grd.Columns("discountpercent").ReadOnly = False
                    grd.Rows.Clear()
                End If
            Else
                pos_dialog.ans = "Retail"
                grd.Columns("amtdue").ReadOnly = False
                Panel5.Controls.Clear()
                Panel14.Controls.Clear()
                viewcat()
                loadItems()

                grd.Columns("discountpercent").ReadOnly = False
                grd.Rows.Clear()
            End If
        End If
    End Sub

    Private Sub rbwholesale_CheckedChanged(sender As Object, e As EventArgs) Handles rbwholesale.CheckedChanged

        If rbwholesale.Checked Then

            If conn.State <> ConnectionState.Open Then
                conn.Close()
            Else
                conn.Open()
            End If

            Dim result As Boolean = False
            conn.Open()
            cmd = New SqlCommand("SELECT userid FROM tblusers WHERE username=@username AND postype=@postype;", conn)
            cmd.Parameters.AddWithValue("@username", login2.username)
            cmd.Parameters.AddWithValue("@postype", "Wholesale")
            dr = cmd.ExecuteReader
            If dr.Read Then
                result = True
            End If
            conn.Close()
            If result = False Then
                confirm.ShowDialog()
                If voidd = True Then
                    pos_dialog.ans = "Wholesale"
                    grd.Columns("amtdue").ReadOnly = False

                    Panel5.Controls.Clear()
                    Panel14.Controls.Clear()
                    viewcat()
                    loadItems()
                    grd.Columns("discountpercent").ReadOnly = False
                    grd.Rows.Clear()
                End If
            Else
                pos_dialog.ans = "Wholesale"
                grd.Columns("amtdue").ReadOnly = False

                Panel5.Controls.Clear()
                Panel14.Controls.Clear()
                viewcat()
                loadItems()
                grd.Columns("discountpercent").ReadOnly = False
                grd.Rows.Clear()
            End If
        End If
    End Sub


    Private Sub txtsearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtsearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            viewitems(txtsearch.Text)
        End If
    End Sub

    Private Sub btnlast10_Click(sender As Object, e As EventArgs) Handles btnlast10.Click
        Dim frm As New lastorders()
        frm.ShowDialog()
    End Sub

    Private Sub lblclose_Click(sender As Object, e As EventArgs) Handles lblclose.Click
        Me.Close()
    End Sub

    Private Sub Panel29_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel29.MouseDown, Panel4.MouseDown, Panel17.MouseDown, Label15.MouseDown, lbldate.MouseDown
        drag = True 'Sets the variable drag to true.
        mousex = Windows.Forms.Cursor.Position.X - Me.Left 'Sets variable mousex
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top 'Sets variable mousey
    End Sub

    Private Sub Panel29_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel29.MouseMove, Panel4.MouseMove, Panel17.MouseMove, Label15.MouseMove, lbldate.MouseMove
        'If drag is set to true then move the form accordingly.
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub Panel29_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel29.MouseUp, Panel4.MouseUp, Panel17.MouseUp, Label15.MouseUp, lbldate.MouseUp
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
    End Sub

    Private Sub dtdate_ValueChanged(sender As Object, e As EventArgs) Handles dtdate.ValueChanged
        getID()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lbldate.Text = DateTime.Now.ToString("hh:mm tt")
    End Sub

    Private Sub Panel29_Paint(sender As Object, e As PaintEventArgs) Handles Panel29.Paint

    End Sub


    'Private Sub txtname_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtname.Leave
    '    If Trim(txtname.Text) = "" Then
    '        MsgBox("Customer name should not be empty.", MsgBoxStyle.Exclamation, "")
    '        txtname.Focus()
    '    End If
    'End Sub


    Private Sub txttin_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttin.KeyPress
        If Asc(e.KeyChar) = Windows.Forms.Keys.Enter Then
            cmp()
        End If

        If Asc(e.KeyChar) = 39 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txttin_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttin.Leave
        If Trim(txttin.Text) = "" Then
            MsgBox("TIN number should not be empty.", MsgBoxStyle.Exclamation, "")
            txttin.Focus()
        End If
    End Sub

    Private Sub btngc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btngc.Click
        If grd.Rows.Count <> 0 Then
            gcform.ShowDialog()
            txtgc.Text = gcform.lblgctotal.Text
            cmp()
        Else
            MsgBox("Enter order first.", MsgBoxStyle.Exclamation, "")
        End If
    End Sub

    Private Sub btndelch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndelch.Click
        Try
            If grd.Rows.Count <> 0 Then
                If rbdeliver.Checked = True Then
                    delcharge.ShowDialog()
                    txtdeliver.Text = delcharge.del_charge.ToString("n2")
                    computetotal()
                Else
                    MsgBox("Choose Deliver service type first.", MsgBoxStyle.Exclamation, "")
                End If
            Else
                MsgBox("No orders entered. Please check entries.", MsgBoxStyle.Exclamation, "")
            End If
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information)
        End Try
    End Sub

    Private Sub rbAR_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbAR.CheckedChanged
        cmbtype.Items.Clear()
        cmbtype.Items.Add("Customer")
        cmbtype.SelectedIndex = 0
        computetotal()
        lblbranch.Text = ""
        txtname.BackColor = Color.White
        txtname.Focus()
        txtname.Text = ""
        txtname.ReadOnly = False
        txttendered.Text = "0.00"
        txtchange.Text = "0.00"
        txttendered.BackColor = Color.WhiteSmoke
        txttendered.ReadOnly = True
        If cmbtype.Text = "Customer" Then
            getARNum("AR Sales", "SLS")
        ElseIf cmbtype.Text = "Employee" Then
            getARNum("AR Charge", "CH")
        End If
        tendertype = "A.R Sales"
    End Sub

    Private Sub btnsearch_Click(sender As Object, e As EventArgs) Handles btnsearch.Click
        viewitems(txtsearch.Text)

        'Dim result As Boolean = False, prce As Double = 0.00, itemcode As String = "", category As String = ""
        'connect()
        'cmd = New SqlCommand("SELECT price,itemcode,category FROM tblitems WHERE itemname=@itemname;", conn)
        'cmd.Parameters.AddWithValue("@itemname", txtsearch.Text)
        'dr = cmd.ExecuteReader
        'If dr.Read Then
        '    result = True
        '    prce = CDbl(dr("price"))
        '    itemcode = dr("itemcode")
        '    category = dr("category")
        'End If
        'disconnect()
        'If result Then
        '    If grd.RowCount = 0 Then
        '        grd.Rows.Add(txtsearch.Text, 0.00, prce.ToString("n2"), 0.00, 0.00, "", False, itemcode, category)
        '        amount()
        '    End If
        '    For index As Integer = 0 To grd.RowCount - 1
        '        If grd.Rows(index).Cells("description").Value <> txtsearch.Text Then
        '            grd.Rows.Add(txtsearch.Text, 0.00, prce.ToString("n2"), 0.00, 0.00, "", False, itemcode, category)
        '            amount()
        '            Exit Sub

        '        End If
        '    Next
        'End If
    End Sub

    Private Sub btnback_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnback.Click
        Me.Close()
        cashier.lblordernum.Text = "N/A"
        cashier.lblservicetype.Text = "N/A"
        cashier.dgvitems.Rows.Clear()
        cashier.lblsubtotal.Text = "0.00"
        cashier.lbldiscountype.Text = "None"
        cashier.lblless.Text = "0.00"
        cashier.lblgc.Text = "0.00"
        cashier.lblvatsales.Text = "0.00"
        cashier.lblvatamount.Text = "0.00"
        cashier.lbltotal.Text = "0.00"
        cashier.lbltenderamt.Text = "0.00"
        cashier.lblchange.Text = "0.00"
        cashier.chckboxadvancepayment.Checked = False
        'mdiform.Focus()
    End Sub

    Private Sub rbcash_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbcash.CheckedChanged
        txtname.Text = "CASH"
        txtname.BackColor = Color.WhiteSmoke
        txtname.ReadOnly = True
        txttendered.BackColor = Color.White
        txttendered.ReadOnly = False
        cmbtype.Items.Clear()
        tendertype = "Cash"
    End Sub

    Private Sub cmbtype_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbtype.SelectedIndexChanged
        load_customers()
        If rbAR.Checked Then
            cmbtype.Enabled = True
        Else
            cmbtype.Enabled = False
        End If
        If cmbtype.Text = "Customer" Then
            getARNum("AR Sales", "SALARSLS")
        ElseIf cmbtype.Text = "Employee" Then
            getARNum("AR Charge", "SALARCH")
        End If
    End Sub

    Private Sub cmbdis_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbdis.SelectedValueChanged
        Try
            If cmbdis.SelectedIndex <> 0 Then
                sql = "Select * from tbldiscount where disname='" & cmbdis.SelectedItem & "'"
                conn.Open()
                cmd = New SqlCommand(sql, conn)
                dr = cmd.ExecuteReader
                If dr.Read Then
                    txtless.Text = dr("amount")
                End If
                conn.Close()

                'insert info there
                If login2.wrkgrp <> "Cashier" And cmbdis.SelectedItem <> "Ar Discount Pullout" Then
                    senior.ShowDialog()
                End If

                computetotal()

                voidd = False
                Exit Sub
            Else
                cmbdis.SelectedIndex = 0
            End If
            computetotal()

        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information)
        End Try
    End Sub

    Private Sub rbARCharge_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbARCharge.CheckedChanged
        cmbtype.Items.Clear()
        cmbtype.Items.Add("Employee")
        cmbtype.SelectedIndex = 0
        computetotal()
        lblbranch.Text = ""
        txtname.BackColor = Color.White
        txtname.Focus()
        txtname.Text = ""
        txtname.ReadOnly = False
        txttendered.Text = "0.00"
        txtchange.Text = "0.00"
        txttendered.BackColor = Color.WhiteSmoke
        txttendered.ReadOnly = True
        If cmbtype.SelectedIndex = 0 Then
            getARNum("AR Sales", "SLS")
        ElseIf cmbtype.SelectedIndex = 1 Then
            getARNum("AR Charge", "CH")
        End If
        tendertype = "A.R Charge"
    End Sub
End Class