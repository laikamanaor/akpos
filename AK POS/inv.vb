Imports System.IO
Imports System.Data.SqlClient
Imports System.Drawing

Public Class inv
    Dim strconn As String = login.ss
    Dim conn As New SqlConnection(strconn)
    Dim cmd As SqlCommand
    Dim dr As SqlDataReader
    Dim sql As String
    Dim ccode As String = ""

    Public manager As String = ""
    Public Function decryptConString() As String
        Dim base64encoded As String = File.ReadAllText("connectionstring.txt")
        Dim data As Byte() = System.Convert.FromBase64String(base64encoded)
        Return System.Text.ASCIIEncoding.ASCII.GetString(data)
    End Function

    Dim nn As Boolean = False, updact As Integer, newyes As Integer = 0
    Dim lastin As Double, lasttotal As Double, lastpull As Double, lastout As Double, lastend As Double, lastactual As Double, rems As String
    Public Shared actual As Boolean = False
    Dim deaccatstat As Boolean = False, trans_num As String = ""

    'Public Sub connect()
    '    conn = New SqlConnection
    '    conn.ConnectionString = strconn

    '    Dim objCmd = conn.CreateCommand()

    '    If conn.State <> ConnectionState.Open Then
    '        conn.Open()
    '        objCmd.CommandTimeout = 420
    '    End If
    'End Sub

    'Public Sub disconnect()
    '    conn = New SqlConnection

    '    Dim objCmd = conn.CreateCommand()

    '    conn.ConnectionString = strconn
    '    If conn.State = ConnectionState.Open Then
    '        conn.Close()
    '        objCmd.CommandTimeout = 420
    '    End If
    'End Sub
    Public Function ctramount(ByVal itemName As String, ByVal tenderType As String) As Double
        Try
            Dim result As Double = 0.00
            conn.Open()
            cmd = New SqlCommand("SELECT ISNULL(SUM(a.totalprice),0) FROM tblorder a JOIN tbltransaction b ON a.transnum = b.transnum WHERE a.invnum=@invnum AND a.itemname=@itemname AND b.status=1 AND b.tendertype='" & tenderType & "';", conn)
            cmd.Parameters.AddWithValue("@invnum", lblinvid.Text)
            cmd.Parameters.AddWithValue("@itemname", itemName)
            result += cmd.ExecuteScalar()
            conn.Close()
            Return result
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Function
    Private Sub inv_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated, MyBase.Load
        If manager = "Production" Then
            grdinv.Columns("itemin").Visible = False
            grdinv.Columns("counterout").Visible = False
            grdinv.Columns("productionin").Visible = False
            grdinv.Columns("supin").Visible = False
            grdinv.Columns("produce").HeaderText = "Total Produce Available"
            grdinv.Columns("ctrout_amt").Visible = False
            grdinv.Columns("arsales_amt").Visible = False
            grdinv.Columns("ap_amt").Visible = False
            lblarsalesamount.Visible = False
            Label17.Visible = False
            lblcounteramount.Visible = False
            Label12.Visible = False
        Else
            grdinv.Columns("produce").Visible = False
            grdinv.Columns("good").Visible = False
            grdinv.Columns("reject").Visible = False
            grdinv.Columns("reject_convin").Visible = False
            grdinv.Columns("reject_totalav").Visible = False
            grdinv.Columns("totalquantity").Visible = False
            grdinv.Columns("arreject").Visible = False
            grdinv.Columns("reject_archarge").Visible = False
            grdinv.Columns("reject_transfer").Visible = False
            grdinv.Columns("reject_convout").Visible = False

            grdinv.Columns("arsales_amt").Visible = True
            grdinv.Columns("ap_amt").Visible = False
            lblarsalesamount.Visible = True
            Label17.Visible = True
            lblcounteramount.Visible = True
            Label12.Visible = True
        End If

        dtinvsearch.MaxDate = getSystemDate()
        dtinvsearch.Text = getSystemDate.ToString("MM/dd/yyyy")
        Me.WindowState = FormWindowState.Maximized
        'btnrefresh.PerformClick()
        btnbegbal.Visible = False

        If rb1.Checked Then
            btnverify.Enabled = checkVerify()
            If btnverify.Text = "Verified" Then
                btnverify.Enabled = False
            End If
        Else
            btnverify.Enabled = False
        End If

        If grdinv.RowCount = 0 Then
            btnverify.Enabled = False
        End If
    End Sub


    Public Function checkVerify() As Boolean
        Try
            Dim z As Integer = 0, totalav As Double = 0.00, reject_totalav As Double = 0.00
            For r0w As Integer = 0 To grdinv.Rows.Count - 1
                conn.Open()
                cmd = New SqlCommand("SELECT tblproduction.item_name FROM tblinvitems JOIN tblproduction ON tblinvitems.itemcode = tblproduction.item_code AND tblinvitems.itemname = tblproduction.item_name WHERE tblproduction.type='Actual Ending Balance' AND tblproduction.inv_id='" & lblinvid.Text & "' AND tblinvitems.itemcode='" & grdinv.Rows(r0w).Cells("itemcode").Value & "' AND tblinvitems.itemname='" & grdinv.Rows(r0w).Cells("itemname").Value & "'  GROUP BY tblproduction.item_name;", conn)
                Dim dt As New DataTable()
                Dim adptr As New SqlDataAdapter()
                adptr.SelectCommand = cmd
                adptr.Fill(dt)
                conn.Close()
                For Each row As DataRow In dt.Rows
                    conn.Open()
                    cmd = New SqlCommand("SELECT invid FROM tblinvitems WHERE totalav !=0 OR reject_totalav !=0;", conn)
                    dr = cmd.ExecuteReader
                    If dr.Read Then
                        z += 1
                    End If
                    conn.Close()
                Next
            Next
            If z = grdinv.Rows.Count Then
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

    Public Sub amount(ByVal cellName As String, ByVal lbl As Label)
        Try
            Dim result As Double = 0.0
            For index As Integer = 0 To grdinv.Rows.Count - 1
                result += CDbl(grdinv.Rows(index).Cells(cellName).Value)
            Next
            result = (Math.Abs(result))
            lbl.Text = result.ToString("n2")
        Catch ex As SqlException
            If ex.Number = -2 Then
                MessageBox.Show("Timeout Occurred", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Public Sub searchCode()
        conn.Open()
        Dim auto As New AutoCompleteStringCollection()
        cmd = New SqlCommand("SELECT * FROM tblitems WHERE category='" & cmbcat.SelectedItem & "' and discontinued='0' order by itemcode;", conn)
        Dim rdr As SqlDataReader = cmd.ExecuteReader()
        While rdr.Read()
            auto.Add(rdr("itemcode"))
        End While
        conn.Close()
        cmbcode.AutoCompleteCustomSource = auto
    End Sub
    Public Sub compute_total()
        Dim gTotal As Double = 0.0, ar2Total As Double = 0.0, apTotal As Double = 0.0, cTotal As Double = 0.0, arCharge As Double = 0.0
        For index As Integer = 0 To grdinv.Rows.Count - 1
            'counterout total:
            cTotal += CDbl(grdinv.Rows(index).Cells("ctrout_amt").Value)
            'a.r cash total:
            'ar1Total += CDbl(grdinv.Rows(index).Cells("arsales_amt").Value)
            'a.r payment total:
            ar2Total += CDbl(grdinv.Rows(index).Cells("arsales_amt").Value)
            'advance payment total:
            apTotal += CDbl(grdinv.Rows(index).Cells("ap_amt").Value)
            arCharge += CDbl(grdinv.Rows(index).Cells("archarge_amt").Value)
        Next
        'display counterout total:
        'lblcashtotal.Text = cTotal.ToString("n2")
        'lblcashsales.Text = cTotal.ToString("n2")
        'lblarcharge.Text = arCharge.ToString("n2")
        'display a.r cash total
        'lblarcashtotal.Text = ar1Total.ToString("n2")
        'display advance payment cash total:
        'apcash("Advance Payment Sales", lblapcash)
        'apcash("Advance Payment", lblap)
        'display cash total
        'miracle_nights()
        'luckymoney()
        'lblgtotal.Text = (cTotal + CDbl(lblapcash.Text) + CDbl(lblarcashtotal.Text) + CDbl(lblluckymoney.Text)).ToString("n2")
        'display a.r payment total:
        'lblar2cashtotal.Text = ar2Total.ToString("n2")
        'display advance payment total:
        'lblap.Text = apTotal.ToString("n2")
        'display payment total:
        'If manager = "Production" Then
        '    lblpaymenttotal.Text = (arCharge).ToString("n2")
        'Else
        '    lblpaymenttotal.Text = (ar2Total + apTotal + arCharge).ToString("n2")
        'End If

        'lblgrandtotal.Text = (CDbl(lblgtotal.Text) + CDbl(lblpaymenttotal.Text)).ToString("n2")
        'lblcashonhand.Text = (CDbl(lblarcashtotal.Text) + CDbl(lblapcash.Text)).ToString("n2")
    End Sub
    'Public Sub luckymoney()
    '    Try
    '        connect()
    '        Dim amtcashout As Double = 0.0
    '        cmd = New SqlCommand("SELECT ISNULL(SUM(tblcredits.amount),0) FROM tblcredits JOIN tblusers ON tblcredits.systemid=tblusers.systemid WHERE tblcredits.invnum=@invnum;", conn)
    '        cmd.Parameters.AddWithValue("@invnum", lblinvid.Text)
    '        amtcashout = cmd.ExecuteScalar()

    '        'lblluckymoney.Text = amtcashout.ToString("n2")

    '        Dim drawerout As Double = 0.0
    '        cmd = New SqlCommand("SELECT ISNULL(SUM(tblcredits.cashout),0) FROM tblcredits JOIN tblusers ON tblcredits.systemid=tblusers.systemid WHERE tblcredits.invnum=@invnum2;", conn)
    '        cmd.Parameters.AddWithValue("@invnum2", lblinvid.Text)
    '        drawerout = cmd.ExecuteScalar()

    '        lbldrawer.Text = drawerout.ToString("n2")
    '    Catch ex As Exception
    '        MessageBox.Show(ex.ToString)
    '    Finally
    '        disconnect()
    '    End Try
    'End Sub
    'Public Sub miracle_nights()
    '    Try
    '        connect()
    '        cmd = New SqlCommand("SELECT SUM(amtdue) FROM tbltransaction WHERE invnum='" & lblinvid.Text & "' AND tendertype='Advance Payment Cash';", conn)
    '        Dim z As Double = cmd.ExecuteScalar()
    '        lblapcash.Text = z.ToString("n2")
    '    Catch ex As Exception
    '    Finally
    '        disconnect()
    '    End Try
    'End Sub
    Public Sub arcash(ByVal typee As String, ByVal lbl As Label)
        Try
            Dim z As Double = 0.0
            conn.Open()
            cmd = New SqlCommand("SELECT  ISNULL(SUM(amtdue + partialamt),0) FROM tbltransaction WHERE invnum='" & lblinvid.Text & "' AND tendertype='" & typee & "';", conn)
            z = cmd.ExecuteScalar()
            conn.Close()
            lbl.Text = z.ToString("n2")
            compute_total()
        Catch ex As SqlException
            If ex.Number = -2 Then
                MessageBox.Show("Timeout Occurred", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub apcash(ByVal ttype As String, ByVal lbl As Label)
        Try
            'MessageBox.Show(ttype
            Dim amtdue As Double = 0.0
            conn.Open()
            cmd = New SqlCommand("SELECT ISNULL(sum(amtdue),0)FROM tbltransaction WHERE invnum='" & lblinvid.Text & "' AND tendertype='" & ttype & "';", conn)
            amtdue = cmd.ExecuteScalar()
            conn.Close()
            lbl.Text = amtdue.ToString("n2")

            If ttype = "Advance Payment" Then
                Dim count As Integer = 0
                conn.Open()
                cmd = New SqlCommand("SELECT count(*) FROM tbltransaction WHERE invnum='" & lblinvid.Text & "' AND tendertype='" & ttype & "';", conn)
                count = cmd.ExecuteScalar()
                conn.Close()
                Dim s(count) As String
                Dim i As Integer = 0, q As String = ""
                conn.Open()
                cmd = New SqlCommand("SELECT transnum,amtdue FROM tbltransaction WHERE invnum='" & lblinvid.Text & "' AND tendertype='" & ttype & "';", conn)
                dr = cmd.ExecuteReader
                While dr.Read
                    s(i) = dr("transnum") & "," & dr("amtdue")
                    i = i + 1
                End While
                conn.Close()
                For Each z As String In s
                    Dim amtd As Double = 0.0, t As Integer = 0, trnum As String = ""
                    If z <> "" Then
                        t = z.IndexOf(",")
                        trnum = z.Substring(0, t)
                        amtd = z.Substring(t + 1)
                        Dim x As Integer = 0
                        conn.Open()
                        cmd = New SqlCommand("SELECT count(*) FROM tblorder WHERE transnum='" & trnum & "';", conn)
                        x = cmd.ExecuteScalar()
                        conn.Close()
                        Dim results As Double = 0
                        results = amtd / x
                        conn.Open()
                        cmd = New SqlCommand("SELECT itemname FROM tblorder WHERE transnum='" & trnum & "';", conn)
                        dr = cmd.ExecuteReader()
                        While dr.Read
                            For index As Integer = 0 To grdinv.Rows.Count - 1
                                If grdinv.Rows(index).Cells("itemname").Value = dr("itemname") Then
                                    grdinv.Rows(index).Cells("ap_amt").Value = "0.00"
                                    grdinv.Rows(index).Cells("ap_amt").Value = (CDbl(grdinv.Rows(index).Cells("ap_amt").Value) + results)
                                    grdinv.Rows(index).Cells("ap_amt").Style.ForeColor = Color.Green
                                End If
                            Next
                        End While
                        conn.Close()
                    End If
                Next

                For index As Integer = 0 To grdinv.Rows.Count - 1
                    If grdinv.Rows(index).Cells("ap_amt").Value = 0 Then
                        grdinv.Rows(index).Cells("ap_amt").Value = "0.00"
                    End If
                Next

            End If
        Catch ex As SqlException
            If ex.Number = -2 Then
                MessageBox.Show("Timeout Occurred", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Public Sub DepXCo(ByVal tenderType As String, ByVal lbl As Label)
        Try
            Dim total As Double = 0.0
            conn.Open()
            cmd = New SqlCommand("SELECT ISNULL(SUM(amtdue),0) FROM tbltransaction WHERE tendertype='" & tenderType & "' AND invnum='" & lblinvid.Text & "';", conn)
            total = cmd.ExecuteScalar()
            conn.Close()
            lbl.Text = total.ToString("n2")
        Catch ex As SqlException
            If ex.Number = -2 Then
                MessageBox.Show("Timeout Occurred", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Public Sub cat()
        Try
            cmbcat.Items.Clear()

            sql = "Select * from tblcat where status='1' order by category"
            conn.Open()
            cmd = New SqlCommand(sql, conn)
            dr = cmd.ExecuteReader
            While dr.Read
                cmbcat.Items.Add(dr("category"))
            End While
            conn.Close()
            If cmbcat.Items.Count <> 0 Then
                cmbcat.Items.Add("All")
            End If
        Catch ex As SqlException
            If ex.Number = -2 Then
                MessageBox.Show("Timeout Occurred", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information)
        End Try
    End Sub

    Public Sub viewlast()
        Try
            Dim dt As New DataTable()

            dt.Columns.Add("invid")
            dt.Columns.Add("itemcode")
            dt.Columns.Add("itemname")
            dt.Columns.Add("begbal")
            dt.Columns.Add("produce")
            dt.Columns.Add("good")
            dt.Columns.Add("charge")
            dt.Columns.Add("productionin")
            dt.Columns.Add("itemin")
            dt.Columns.Add("supin")
            dt.Columns.Add("adjustmentin")
            dt.Columns.Add("convin")
            dt.Columns.Add("cancelin")
            dt.Columns.Add("totalav")
            dt.Columns.Add("transfer")
            dt.Columns.Add("ctrout")
            dt.Columns.Add("archarge")
            dt.Columns.Add("arsales")
            dt.Columns.Add("convout")
            dt.Columns.Add("pullout")
            dt.Columns.Add("reject")
            dt.Columns.Add("reject_convin")
            dt.Columns.Add("reject_totalav")
            dt.Columns.Add("arreject")
            dt.Columns.Add("reject_archarge")
            dt.Columns.Add("reject_convout")
            dt.Columns.Add("reject_transfer")
            dt.Columns.Add("endbal")
            dt.Columns.Add("actualendbal")
            dt.Columns.Add("variance")
            dt.Columns.Add("shortover")

            Dim ver As Boolean = False
            grdinv.Rows.Clear()

            Dim area As String = ""
            If manager = "Sales" Then
                area = "Sales"
            ElseIf manager = "Production" Then
                area = "Production"
            End If
            '  sql = "Select TOP 1 * from tblinvsum WHERE area='" & area & "' order by invsumid DESC"

            Dim serverDate As String = getSystemDate.ToString("MM/dd/yyyy")

            'conn.Open()
            'cmd = New SqlCommand(sql, conn)
            'dr = cmd.ExecuteReader
            'If dr.Read Then
            '    Me.Cursor = Cursors.WaitCursor
            '    lblinvsumid.Text = dr("invsumid")
            '    lblinvid.Text = dr("invnum")
            '    lbldate.Text = Format(dr("datecreated"), "MM/dd/yyyy HH:mm")
            '    If dr("verify") = 1 Then
            '        ver = True
            '        btnverify.Text = "Verified"
            '        btnverify.Enabled = False
            '        checkbtns()
            '    Else
            '        btnverify.Text = "Verify"
            '        ver = False
            '        btnactual.Enabled = True
            '        btnbegbal.Enabled = True
            '        checkbtns()
            '    End If

            '    If CDate(lbldate.Text.Substring(0, 10)) <> CDate(serverDate).ToString("MM/dd/yyyy") Then
            '        lblreminder.Visible = True
            '    Else
            '        lblreminder.Visible = False
            '    End If

            'End If
            'conn.Close()

            Me.Cursor = Cursors.Default

            If rb1.Checked Then
                dt.Rows.Clear()
                sql = "SELECT * from tblinvitems WHERE area='" & area & "' AND invnum='" & lblinvid.Text & "' ORDER BY itemcode"
                conn.Open()
                cmd = New SqlCommand(sql, conn)
                Dim adptr As New SqlDataAdapter()
                Dim d1 As New DataTable()
                adptr.SelectCommand = cmd
                adptr.Fill(d1)
                conn.Close()
                For Each r0w As DataRow In d1.Rows
                    Dim so As String = ""
                    If CDbl(r0w("actualendbal")) <> 0 Then
                        so = r0w("shortover")
                    End If
                    If CDbl(r0w("totalav")) <> 0 Or CDbl(r0w("reject_totalav")) <> 0 Then
                        dt.Rows.Add(r0w("invid"), r0w("itemcode"), r0w("itemname"), r0w("begbal"), r0w("produce"), r0w("good"), r0w("charge"), r0w("productionin"), r0w("itemin"), r0w("supin"), r0w("adjustmentin"), r0w("convin"), r0w("cancelin"), r0w("totalav"), r0w("transfer"), r0w("ctrout"), r0w("archarge"), r0w("arsales"), r0w("convout"), r0w("pullout"), r0w("reject"), r0w("reject_convin"), r0w("reject_totalav"), r0w("arreject"), r0w("reject_archarge"), r0w("reject_convout"), r0w("reject_transfer"), r0w("endbal"), r0w("actualendbal"), r0w("variance"), so)
                    End If
                Next

                'sql = "Select  * from tblinvitems where invnum='" & lblinvid.Text & "' AND actualendbal != 0 AND area='" & area & "'  order by itemcode"
                'cmd = New SqlCommand(sql, conn)
                'Dim adptr1 As New SqlDataAdapter()
                'Dim d2 As New DataTable()
                'adptr1.SelectCommand = cmd
                'adptr1.Fill(d2)
                'For Each r0w As DataRow In d2.Rows
                '    Dim so As String = ""
                '    If CDbl(r0w("actualendbal")) <> 0 Then
                '        so = r0w("shortover")
                '    End If
                '    If CDbl(r0w("endbal")) = 0 Then
                '        dt.Rows.Add(r0w("invid"), r0w("itemcode"), r0w("itemname"), r0w("begbal"), r0w("produce"), r0w("good"), r0w("reject"), r0w("charge"), r0w("productionin"), r0w("itemin"), r0w("supin"), r0w("convin"), r0w("totalav"), r0w("transfer"), r0w("ctrout"), r0w("arreject"), r0w("archarge"), r0w("arsales"), r0w("convout"), r0w("pullout"), r0w("endbal"), r0w("actualendbal"), r0w("variance"), so)
                '    End If
                'Next
            ElseIf rb2.Checked Then
                dt.Rows.Clear()
                sql = "Select * from tblinvitems where invnum='" & lblinvid.Text & "' AND area='" & area & "' AND totalav = 0  order by itemcode"
                conn.Open()
                cmd = New SqlCommand(sql, conn)
                Dim adptr As New SqlDataAdapter()
                Dim d1 As New DataTable()
                adptr.SelectCommand = cmd
                adptr.Fill(d1)
                conn.Close()
                For Each r0w As DataRow In d1.Rows

                    Dim so As String = ""
                    If CDbl(r0w("actualendbal")) <> 0 Then
                        so = r0w("shortover")
                    End If
                    If CDbl(r0w("totalav")) = 0 Or CDbl(r0w("reject_totalav")) = 0 Then
                        dt.Rows.Add(r0w("invid"), r0w("itemcode"), r0w("itemname"), r0w("begbal"), r0w("produce"), r0w("good"), r0w("charge"), r0w("productionin"), r0w("itemin"), r0w("supin"), r0w("adjustmentin"), r0w("convin"), r0w("cancelin"), r0w("totalav"), r0w("transfer"), r0w("ctrout"), r0w("archarge"), r0w("arsales"), r0w("convout"), r0w("pullout"), r0w("reject"), r0w("reject_convin"), r0w("reject_totalav"), r0w("arreject"), r0w("reject_archarge"), r0w("reject_convout"), r0w("reject_transfer"), r0w("endbal"), r0w("actualendbal"), r0w("variance"), so)
                    End If

                Next
            End If
            ' TextBox2.Text = sql

            'grdinv.Rows.Add(dr("invid"), dr("itemcode"), dr("itemname"), dr("begbal"), dr("produce"), dr("good"), dr("reject"), dr("charge"), dr("productionin"), dr("itemin"), dr("supin"), dr("convin"), dr("totalav"), dr("transfer"), dr("ctrout"), dr("arreject"), dr("archarge"), dr("arsales"), dr("convout"), dr("pullout"), dr("endbal"), dr("actualendbal"), dr("variance"), so)

            For Each r0w As DataRow In dt.Rows
                Dim totalqty As Double = CDbl(r0w("totalav")) + CDbl(r0w("reject_totalav"))

                grdinv.Rows.Add(r0w("invid"), r0w("itemcode"), r0w("itemname"), r0w("begbal"), r0w("produce"), r0w("good"), r0w("charge"), r0w("productionin"), r0w("itemin"), r0w("supin"), r0w("adjustmentin"), r0w("convin"), r0w("cancelin"), r0w("totalav"), r0w("transfer"), r0w("ctrout"), r0w("archarge"), r0w("arsales"), r0w("convout"), r0w("pullout"), r0w("reject"), r0w("reject_convin"), r0w("reject_totalav"), totalqty.ToString, r0w("arreject"), r0w("reject_archarge"), r0w("reject_convout"), r0w("reject_transfer"), r0w("endbal"), r0w("actualendbal"), r0w("variance"), r0w("shortover"))

                colors()
            Next

            Me.Cursor = Cursors.Default
            'grdinv.Columns("itemname").Frozen = True

            If grdinv.Rows.Count <> 0 Then
                cat()
                'and if verified na ung inv then
                checkbtns()
                grdinv.Enabled = True
                btnviewall.Enabled = True
                lblinvid.Enabled = True
                lbldate.Enabled = True

            Else
                btnnew.Enabled = True
                'GroupBox2.Enabled = False
            End If

            checkbtns()
            shortover()

            btnverify.Enabled = checkVerify()

            If grdinv.RowCount = 0 Then
                btnverify.Enabled = False
            End If

            If manager = "Manager" Then
                btnverify.Enabled = True
            End If

            Me.Cursor = Cursors.Default

        Catch ex As SqlException
            If ex.Number = -2 Then
                MessageBox.Show("Timeout Occurred", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            'MsgBox(ex.ToString, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information)
        End Try
    End Sub

    Public Sub nnew()
        Try
            Dim a As String = MsgBox("Are you sure you want to create New inventory?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "")
            If a <> vbYes Then
                newyes = 1
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            viewlast()
            grdinv.Rows.Clear()

            loadinvnum()

            sql = "Select * from tblitems where discontinued='0'"
            conn.Open()
            cmd = New SqlCommand(sql, conn)
            dr = cmd.ExecuteReader
            While dr.Read
                Me.Cursor = Cursors.WaitCursor
                grdinv.Rows.Add("", dr("itemcode"), dr("itemname"), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "")
            End While
            conn.Close()

            Me.Cursor = Cursors.Default

            For Each row As DataGridViewRow In grdinv.Rows
                Me.Cursor = Cursors.WaitCursor
                sql = "Select TOP 1 * from tblinvitems where itemcode='" & grdinv.Rows(row.Index).Cells("itemcode").Value & "' AND area='" & login.wrkgrp & "'  order by invid DESC"
                conn.Open()
                cmd = New SqlCommand(sql, conn)
                dr = cmd.ExecuteReader
                If dr.Read Then
                    grdinv.Rows(row.Index).Cells("itemin").Value = dr("actualendbal")
                    grdinv.Rows(row.Index).Cells("counterout").Value = dr("actualendbal")
                    grdinv.Rows(row.Index).Cells("actualendbal").Value = dr("actualendbal")
                    grdinv.Rows(row.Index).Cells("variance").Value = 0 - dr("actualendbal")
                    If grdinv.Rows(row.Index).Cells("variance").Value < 0 Then
                        grdinv.Rows(row.Index).Cells("shov").Value = "Short"
                    ElseIf grdinv.Rows(row.Index).Cells("variance").Value > 0 Then
                        grdinv.Rows(row.Index).Cells("shov").Value = "Over"
                    End If
                End If
                conn.Close()
            Next
            Me.Cursor = Cursors.Default

            'savenew
            'change shift
            Dim hour As String = getSystemDate.ToString("HH")
            Dim shift As String
            If Val(hour) < 12 Then
                shift = "AM"
            Else
                shift = "PM"
            End If
            Dim zz As String = getSystemDate.ToString("MM/dd/yyyy")
            sql = "Insert into tblinvsum (invnum, invdate, cashier, shift, verify, datecreated, datemodified, modifiedby, status,area) values('" & lblinvid.Text & "', '" & zz & "', '" & login.cashier & "', '" & shift & "', '0',(SELECT GETDATE()),(SELECT GETDATE()), '" & login.cashier & "', '1','Production')"
            conn.Open()
            cmd = New SqlCommand(sql, conn)
            cmd.ExecuteNonQuery()
            conn.Close()

            computation()

            For Each row As DataGridViewRow In grdinv.Rows
                Me.Cursor = Cursors.WaitCursor
                Dim icode As String = grdinv.Rows(row.Index).Cells("itemcode").Value
                Dim iname As String = grdinv.Rows(row.Index).Cells("itemname").Value
                Dim ibeg As Double = Val(grdinv.Rows(row.Index).Cells("begbal").Value)
                Dim iin As Double = Val(grdinv.Rows(row.Index).Cells("itemin").Value)
                Dim itotal As Double = Val(grdinv.Rows(row.Index).Cells("totalqty").Value)
                Dim iout As Double = Val(grdinv.Rows(row.Index).Cells("counterout").Value)
                Dim ipull As Double = Val(grdinv.Rows(row.Index).Cells("pullout").Value)
                Dim iend As Double = Val(grdinv.Rows(row.Index).Cells("endbal").Value)
                Dim ivar As Double = Val(grdinv.Rows(row.Index).Cells("variance").Value)
                Dim irem As String = grdinv.Rows(row.Index).Cells("shov").Value

                sql = "Insert into tblinvitems (invnum, itemcode, itemname, begbal, itemin, totalav, ctrout, pullout, endbal, actualendbal, variance, shortover, status,area) values('" & lblinvid.Text & "', '" & icode & "', '" & iname & "', '" & ibeg & "', '" & iin & "', '" & itotal & "', '" & iout & "', '" & ipull & "', '" & iend & "', '0', '" & ivar & "', '" & irem & "', '1','" & login.wrkgrp & "')"
                conn.Open()
                cmd = New SqlCommand(sql, conn)
                cmd.ExecuteNonQuery()
                conn.Close()
            Next
            Me.Cursor = Cursors.Default

            'btnverify.Enabled = True
            btnactual.Enabled = True
            btnbegbal.Enabled = True
            btnimport.Enabled = True
            shortover()
        Catch ex As SqlException
            If ex.Number = -2 Then
                MessageBox.Show("Timeout Occurred", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information)
        End Try
    End Sub

    Public Sub newcode()
        Try
            sql = "Select * from tblitems where discontinued='0' and itemcode='" & cmbcode.SelectedItem & "'"
            conn.Open()
            cmd = New SqlCommand(sql, conn)
            dr = cmd.ExecuteReader
            If dr.Read Then
                grdinv.Rows.Add("", dr("itemcode"), dr("itemname"), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "", "0.00", "")
            End If
            conn.Close()

            For Each row As DataGridViewRow In grdinv.Rows
                Me.Cursor = Cursors.WaitCursor
                If grdinv.Rows(row.Index).Cells("itemcode").Value = cmbcode.SelectedItem Then
                    Dim icode As String = grdinv.Rows(row.Index).Cells("itemcode").Value
                    Dim iname As String = grdinv.Rows(row.Index).Cells("itemname").Value
                    Dim ibeg As Double = Val(grdinv.Rows(row.Index).Cells("begbal").Value)
                    Dim iin As Double = Val(grdinv.Rows(row.Index).Cells("itemin").Value)
                    Dim itotal As Double = Val(grdinv.Rows(row.Index).Cells("totalqty").Value)
                    Dim iout As Double = Val(grdinv.Rows(row.Index).Cells("counterout").Value)
                    Dim ipull As Double = Val(grdinv.Rows(row.Index).Cells("pullout").Value)
                    Dim iend As Double = Val(grdinv.Rows(row.Index).Cells("endbal").Value)
                    Dim ivar As Double = Val(grdinv.Rows(row.Index).Cells("actualendbal").Value)
                    Dim irem As String = grdinv.Rows(row.Index).Cells("shov").Value


                    sql = "Insert into tblinvitems (invnum, itemcode, itemname, begbal, itemin, totalav, ctrout, pullout, endbal, actualendbal, variance, shortover, status,area) values('" & lblinvid.Text & "', '" & icode & "', '" & iname & "', '" & ibeg & "', '" & iin & "', '" & itotal & "', '" & iout & "', '" & ipull & "', '" & iend & "', '0', '" & ivar & "', '" & irem & "', '1','" & login.wrkgrp & "')"
                    conn.Open()
                    cmd = New SqlCommand(sql, conn)
                    cmd.ExecuteNonQuery()
                    conn.Close()
                End If
            Next

            shortover()
            Me.Cursor = Cursors.Default
        Catch ex As SqlException
            If ex.Number = -2 Then
                MessageBox.Show("Timeout Occurred", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information)
        End Try
    End Sub

    Private Sub btnnew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnew.Click
        'check ung last sa invsum then check if verify is 1
        Dim zz As String = getSystemDate.ToString("MM/dd/yyyy")
        Try
            sql = "Select TOP 1 * from tblinvsum WHERE area='" & login.wrkgrp & "' order by invsumid DESC"
            conn.Open()
            cmd = New SqlCommand(sql, conn)
            dr = cmd.ExecuteReader
            If dr.Read Then
                If dr("verify") = 1 Then
                    If dr("invdate") = zz Then
                        MsgBox("Creating new inventory failed! Inventory end for this day.", MsgBoxStyle.Critical, "")
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                    nn = True
                    nnew()
                    btnviewall.PerformClick()
                Else
                    viewlast()
                End If
            Else
                nn = True
                nnew()
                'MsgBox("create new")
                btnviewall.PerformClick()
            End If
            conn.Close()
            checkbtns()

            If newyes = 1 Then
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            chkrows()
            btnnew.Enabled = False
        Catch ex As SqlException
            If ex.Number = -2 Then
                MessageBox.Show("Timeout Occurred", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information, "")
        End Try
    End Sub

    Public Sub chkrows()
        If grdinv.Rows.Count <> 0 Then
            GroupBox2.Enabled = True
            grdinv.Enabled = True
            btnviewall.Enabled = True
            lblinvid.Enabled = True
            lbldate.Enabled = True
            btnrems.Enabled = True

            checkbtns()

            cat()
        End If
    End Sub

    Private Sub rbin_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbin.CheckedChanged
        If rbin.Checked = True Then
            Label5.Text = "Qty Item In:"
        End If
    End Sub

    Private Sub rbout_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbout.CheckedChanged
        If rbout.Checked = True Then
            Label5.Text = "Qty PullOut:"
        End If
    End Sub

    Public Sub loadcode()
        Try
            Exit Sub
            cmbcode.Items.Clear()
            cmbcode.Items.Add("")
            Dim auto As New AutoCompleteStringCollection()
            sql = "Select itemname from tblitems where discontinued='0' order by itemname"
            conn.Open()
            cmd = New SqlCommand(sql, conn)
            dr = cmd.ExecuteReader
            While dr.Read
                If Not cmbcode.Items.Contains(dr("itemname")) Then
                    auto.Add(dr("itemname"))
                    cmbcode.Items.Add(dr("itemname"))
                End If
            End While
            conn.Close()
            cmbcode.AutoCompleteCustomSource = auto
        Catch ex As SqlException
            If ex.Number = -2 Then
                MessageBox.Show("Timeout Occurred", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information, "")
        End Try
    End Sub

    Private Sub btnadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadd.Click
        Try
            If ccode <> "" And txtitemin.Text <> "" And cmbcat.SelectedItem <> "" Then
                If rbin.Checked = True Then
                    'sa in sya pupunta
                    Dim a As String = MsgBox("Are you sure you want to add item in for " & cmbcode.SelectedItem, MsgBoxStyle.Question + MsgBoxStyle.YesNo + MessageBoxDefaultButton.Button2, "")
                    If a = vbYes Then
                        'check if its category is deactivated
                        checkcat()
                        If deaccatstat = True Then
                            MsgBox("Category of the item is deactivated. Cannot add item in for " & cmbcode.SelectedItem, MsgBoxStyle.Exclamation, "")
                            deaccatstat = False
                            Me.Cursor = Cursors.Default
                            Exit Sub
                        End If

                        'check first if the selected code is in the row else insert muna bago update
                        Dim meron As Boolean = False
                        For Each row As DataGridViewRow In grdinv.Rows
                            If grdinv.Rows(row.Index).Cells("itemcode").Value = cmbcode.SelectedItem Then
                                'MsgBox(cmbcode.SelectedItem)
                                meron = True
                            End If
                        Next
                        If meron = False Then
                            newcode()
                        End If


                        sql = "Select * from tblinvitems where itemcode='" & ccode & "' and invnum='" & lblinvid.Text & "' AND area='" & login.wrkgrp & "'"
                        conn.Open()
                        cmd = New SqlCommand(sql, conn)
                        dr = cmd.ExecuteReader
                        If dr.Read Then
                            lastin = dr("itemin")
                            lasttotal = dr("begbal") + dr("itemin")
                            lastout = dr("ctrout") + dr("pullout")
                            lastactual = dr("actualendbal")
                            lastpull = dr("pullout")
                            lastend = dr("endbal")
                        End If
                        conn.Close()

                        Dim uin As Double = Val(txtitemin.Text) + lastin
                        Dim utotal As Double = Val(txtitemin.Text) + lasttotal
                        Dim uend As Double = utotal - lastout
                        Dim uvar As Double = lastactual - uend
                        Dim urems As String = ""
                        If uvar < 0 Then
                            urems = "Short"
                        ElseIf uvar > 0 Then
                            urems = "Over"
                        End If

                        sql = "Update tblinvitems set itemin='" & uin & "', totalav='" & utotal & "', endbal='" & uend & "', variance='" & uvar & "', shortover='" & urems & "' where itemcode='" & ccode & "' and invnum='" & lblinvid.Text & "' AND area='" & login.wrkgrp & "'"
                        conn.Open()
                        cmd = New SqlCommand(sql, conn)
                        cmd.ExecuteNonQuery()
                        conn.Close()

                        sql = "Update tblitems set status='1' where itemcode='" & cmbcode.SelectedItem & "'"
                        conn.Open()
                        cmd = New SqlCommand(sql, conn)
                        cmd.ExecuteNonQuery()
                        conn.Close()

                        txtitemin.Text = ""
                        cmbcode.SelectedIndex = 0
                        btnrefresh.PerformClick()
                    End If
                Else
                    'check if anu ung total av if 0 then no need to pull out
                    Dim meron As Boolean = False
                    For Each row As DataGridViewRow In grdinv.Rows
                        If grdinv.Rows(row.Index).Cells("itemcode").Value = cmbcode.SelectedItem Then
                            meron = True
                        End If
                    Next

                    If meron = False Then
                        MsgBox("There's no item available to pull out. Add item in first.", MsgBoxStyle.Exclamation, "")
                        txtitemin.Text = ""
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If

                    Dim a As String = MsgBox("Are you sure you want to add item pull out for " & cmbcode.SelectedItem, MsgBoxStyle.Question + MsgBoxStyle.YesNo + MessageBoxDefaultButton.Button2, "")
                    If a = vbYes Then
                        sql = "Select * from tblinvitems where itemcode='" & ccode & "' and invnum='" & lblinvid.Text & "' AND area='" & login.wrkgrp & "'"
                        conn.Open()
                        cmd = New SqlCommand(sql, conn)
                        dr = cmd.ExecuteReader
                        If dr.Read Then
                            lastin = dr("itemin")
                            lasttotal = dr("begbal") + dr("itemin")
                            lastout = dr("ctrout") + dr("pullout")
                            lastactual = dr("actualendbal")
                            lastpull = dr("pullout")
                            lastend = dr("endbal")
                        End If
                        conn.Close()

                        Dim upull As Double = lastpull + Val(txtitemin.Text)
                        Dim uend2 As Double = lastend - Val(txtitemin.Text)
                        Dim uvar As Double = lastactual - uend2
                        Dim urems As String = ""
                        If uvar < 0 Then
                            urems = "Short"
                        ElseIf uvar > 0 Then
                            urems = "Over"
                        End If

                        If uend2 < 0 Then
                            MsgBox("Cannot pullout items that is more than the end balance of item", MsgBoxStyle.Exclamation, "")
                            txtitemin.Text = ""
                            Me.Cursor = Cursors.Default
                            Exit Sub
                        End If

                        'update
                        sql = "Update tblinvitems set  pullout='" & upull & "', endbal='" & uend2 & "', variance='" & uvar & "', shortover='" & urems & "' where itemcode='" & ccode & "' and invnum='" & lblinvid.Text & "' AND area='" & login.wrkgrp & "'"
                        conn.Open()
                        cmd = New SqlCommand(sql, conn)
                        cmd.ExecuteNonQuery()
                        conn.Close()

                        If uend2 = 0 Then
                            sql = "Update tblitems set status='0' where itemcode='" & ccode & "'"
                            conn.Open()
                            cmd = New SqlCommand(sql, conn)
                            cmd.ExecuteNonQuery()
                            conn.Close()
                        End If
                    End If

                    txtitemin.Text = ""
                    cmbcode.SelectedIndex = 0
                    btnrefresh.PerformClick()
                End If
            Else
                MsgBox("Complete the fields.", MsgBoxStyle.Exclamation, "")
                txtitemin.Focus()
            End If
        Catch ex As SqlException
            If ex.Number = -2 Then
                MessageBox.Show("Timeout Occurred", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information, "")
        End Try
    End Sub

    Public Sub checkcat()
        Try
            Dim cat As String = ""
            sql = "Select * from tblitems where itemcode='" & cmbcode.SelectedItem & "'"
            conn.Open()
            cmd = New SqlCommand(sql, conn)
            dr = cmd.ExecuteReader
            If dr.Read Then
                cat = dr("category")
            End If
            conn.Close()

            sql = "Select * from tblcat where category='" & cat & "'"
            conn.Open()
            cmd = New SqlCommand(sql, conn)
            dr = cmd.ExecuteReader
            If dr.Read Then
                If dr("status") = "0" Then
                    deaccatstat = True
                End If
            End If
            conn.Close()
        Catch ex As SqlException
            If ex.Number = -2 Then
                MessageBox.Show("Timeout Occurred", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information, "")
        End Try
    End Sub


    Private Sub txtitemin_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtitemin.KeyPress
        Dim n As Integer = 0

        If Asc(e.KeyChar) = Windows.Forms.Keys.Enter Then
            btnadd.PerformClick()
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        If Asc(e.KeyChar) <> 8 And Asc(e.KeyChar) <> 1 And Asc(e.KeyChar) <> 3 And Asc(e.KeyChar) <> 24 And Asc(e.KeyChar) <> 25 And Asc(e.KeyChar) <> 26 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            Else
                If Val(txtitemin.Text) = 0 Then
                    If Asc(e.KeyChar) = 48 Then
                        e.Handled = True
                    Else
                        txtitemin.Text = ""
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub cmbcode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbcode.SelectedIndexChanged
        txtitemin.Focus()
        ccode = cmbcode.SelectedItem
        Dim meon As Boolean = False
        For index As Integer = 0 To grdinv.RowCount - 1
            If grdinv.Rows(index).Cells("itemcode").Value = cmbcode.Text Then
                grdinv.ClearSelection()
                grdinv.CurrentCell = grdinv.Rows(index).Cells("itemname")
                grdinv.Rows(index).Selected = True

                meon = True

            End If
        Next

        If cmbcat.SelectedItem = "" Then
            lblcode.Text = cmbcode.SelectedItem
            sql = "Select tblitems.category from tblinvitems JOIN tblitems ON tblinvitems.itemname= tblitems.itemname where tblinvitems.itemname='" & cmbcode.SelectedItem & "' AND tblinvitems.endbal !=0"
            conn.Open()
            cmd = New SqlCommand(sql, conn)
            dr = cmd.ExecuteReader
            If dr.Read Then
                cmbcat.SelectedItem = dr("category")
            End If
            conn.Close()
        End If

        'weeeh
        'apcash("Advance Payment", lblap)
        'cash("Cash", "ctrout_amt")
        ''gcXDel("gc", lblgc)
        ''gcXDel("deliver", lbldelcharge)
        'cash("AR Sales", "arsales_amt")
        'cash("AR Charge", "archarge_amt")
        'arcash("A.R Cash", lblarcashtotal)
        'DepXCo("Deposit", lbldeposit)
        'DepXCo("Cash Out", lblcashout)
        'amount("shortamount", lblshortamount)
        'amount("overamount", lbloveramount)
        'amount("ctrout_amt", lblcounteramount)
        'amount("archarge_amt", lblarchargeamount)
        'amount("arsales_amt", lblarsalesamount)
    End Sub

    Public Sub computation()
        Try
            'gawa ng computation BASED SA LAST ENTRIES
            sql = "Select * from tblinvitems where itemcode='" & cmbcode.SelectedItem & "' and invnum='" & lblinvid.Text & "' AND area='" & login.wrkgrp & "'"
            conn.Open()
            cmd = New SqlCommand(sql, conn)
            dr = cmd.ExecuteReader
            If dr.Read Then
                lastin = dr("itemin")
                lasttotal = dr("begbal") + dr("itemin")
                lastout = dr("ctrout") + dr("pullout")
                lastactual = dr("actualendbal")
                lastpull = dr("pullout")
                lastend = dr("endbal")
            End If
            conn.Close()
        Catch ex As SqlException
            If ex.Number = -2 Then
                MessageBox.Show("Timeout Occurred", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information, "")
        End Try
    End Sub

    Private Sub btnviewall_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnviewall.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            lblcat.Text = "All"
            cat()
            cmbcode.SelectedItem = ""
            viewlast()

            btnactual.Text = "Update Actual End Bal"
            btnbegbal.Text = "Overwrite Beg Bal"
            grdinv.Columns("begbal").ReadOnly = True
            grdinv.Columns("actualendbal").ReadOnly = True
            checkbtns()

            For Each row As DataGridViewRow In grdinv.Rows
                Dim iend As Double = Val(grdinv.Rows(row.Index).Cells("endbal").Value)
                If iend > 0 Then
                    sql = "Update tblitems set status='1' where itemcode = '" & grdinv.Rows(row.Index).Cells("itemcode").Value & "'"
                Else
                    sql = "Update tblitems set status='0' where itemcode = '" & grdinv.Rows(row.Index).Cells("itemcode").Value & "'"
                    'MsgBox(grdinv.Rows(updact).Cells(1).Value.ToString)
                End If
                conn.Open()
                cmd = New SqlCommand(sql, conn)
                cmd.ExecuteNonQuery()
                conn.Close()
            Next

            shortover()
            Me.Cursor = Cursors.Default
        Catch ex As SqlException
            If ex.Number = -2 Then
                MessageBox.Show("Timeout Occurred", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information, "")
        End Try
    End Sub

    Private Sub btnactual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnactual.Click
        Try
            If btnactual.Text = "Update Actual End Bal" Then
                btnrefresh.PerformClick()
                grdinv.Columns("actualendbal").ReadOnly = False
                grdinv.ClearSelection()
                grdinv.Rows(0).Cells("actualendbal").Selected = True
                grdinv.BeginEdit(True)
                btnactual.Text = "Save Actual End Bal"
                btnverify.Enabled = False
                btnrems.Enabled = False
                btnbegbal.Enabled = False
                'GroupBox2.Enabled = False
                btnimport.Enabled = False
                computation()
            Else
                confirm.ShowDialog()

                If actual = True Then
                    For Each row As DataGridViewRow In grdinv.Rows
                        Dim uactual As Double = Val(grdinv.Rows(row.Index).Cells("actualendbal").Value)
                        Dim uendd As Double = Val(grdinv.Rows(row.Index).Cells("endbal").Value)
                        Dim uvar As Double = Val(grdinv.Rows(row.Index).Cells("variance").Value)
                        Dim urems As String = grdinv.Rows(row.Index).Cells("shov").Value

                        sql = "Update tblinvitems set  actualendbal='" & uactual & "', variance='" & uvar & "', shortover='" & urems & "' where itemcode='" & grdinv.Rows(row.Index).Cells("itemcode").Value & "' and invnum='" & lblinvid.Text & "' AND area='" & login.wrkgrp & "'"
                        conn.Open()
                        cmd = New SqlCommand(sql, conn)
                        cmd.ExecuteNonQuery()
                        conn.Close()
                    Next
                End If

                actual = False
                txtitemin.Text = ""
                btnrefresh.PerformClick()

                btnactual.Text = "Update Actual End Bal"
                checkbtns()
                grdinv.Columns("actualendbal").ReadOnly = True
                GroupBox2.Enabled = True
                btnrems.Enabled = True
                btnbegbal.Enabled = True
            End If

            actual = False
        Catch ex As SqlException
            If ex.Number = -2 Then
                MessageBox.Show("Timeout Occurred", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information, "")
        End Try
    End Sub

    Private Sub grdinv_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdinv.CellClick
        grdinv.BeginEdit(True)
    End Sub

    Private Sub btnverify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnverify.Click
        Try
            If btnverify.Text = "Verified" Then
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
            Dim area As String = ""
            If manager = "Sales" Then
                area = "Sales"
            Else
                area = login.wrkgrp
            End If

            btnviewall.PerformClick()
            Dim a As String = MsgBox("WARNING! You are about to end the inventory for " & lbldate.Text.Substring(0, 10) & ". Are you sure you want to verify?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "")
            If a = vbYes Then
                confirm.ShowDialog()
                If actual = True Then
                    'update verify
                    sql = "Update tblinvsum set verify='1', datemodified=(SELECT GETDATE()), modifiedby='" & login.cashier & "' where invnum='" & lblinvid.Text & "' AND area='" & area & "'"
                    conn.Open()
                    cmd = New SqlCommand(sql, conn)
                    cmd.ExecuteNonQuery()
                    conn.Close()

                    saveahortoveramt()

                    btnverify.Enabled = False
                    btnimport.Enabled = False
                Else
                    'MessageBox.Show("yi")
                End If
            End If

            actual = False
            viewlast()

            btnverify.Enabled = checkVerify()
            If btnverify.Text = "Verified" Then
                btnverify.Enabled = False
            End If

        Catch ex As SqlException
            If ex.Number = -2 Then
                MessageBox.Show("Timeout Occurred", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information, "")
        End Try
    End Sub

    Private Sub grdinv_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdinv.CellEndEdit
        '    Try
        '        updact = grdinv.CurrentRow.Index

        '        If btnactual.Text = "Save Actual End Bal" Then
        '            'check if ung item is nka discontinued or not
        '            sql = "Select * from tblitems where itemname='" & grdinv.Rows(updact).Cells("itemname").Value & "' and discontinued='1'"
        '            connect()
        '            cmd = New SqlCommand(sql, conn)
        '            dr = cmd.ExecuteReader
        '            If dr.Read Then
        '                MsgBox("Item is discontinued", MsgBoxStyle.Exclamation, "")
        '                btnrefresh.PerformClick()
        '                Me.Cursor = Cursors.Default
        '                Exit Sub
        '            End If
        '            dr.Dispose()
        '            cmd.Dispose()


        '            If IsNumeric(grdinv.Rows(updact).Cells("actualendbal").Value) = False Then
        '                MsgBox("Invalid input.", MsgBoxStyle.Exclamation, "")
        '                grdinv.Rows(updact).Cells("actualendbal").Value = "0.00"
        '                grdinv.ClearSelection()
        '                grdinv.Rows(updact).Cells("actualendbal").Selected = True
        '                Me.Cursor = Cursors.Default
        '                Exit Sub
        '            Else
        '                If grdinv.Rows(updact).Cells("actualendbal").Value < 0 Then
        '                    MsgBox("Invalid input.", MsgBoxStyle.Exclamation, "")
        '                    grdinv.Rows(updact).Cells("actualendbal").Value = "0.00"
        '                    grdinv.ClearSelection()
        '                    grdinv.Rows(updact).Cells("actualendbal").Selected = True
        '                    Me.Cursor = Cursors.Default
        '                    Exit Sub
        '                Else
        '                    grdinv.Rows(updact).Cells("actualendbal").Value = Val(grdinv.Rows(updact).Cells("actualendbal").Value)
        '                End If
        '            End If

        '            Dim icode As String = grdinv.Rows(updact).Cells("itemcode").Value
        '            Dim iend As Double = Val(grdinv.Rows(updact).Cells("endbal").Value)
        '            Dim actual As Double = Val(grdinv.Rows(updact).Cells("actualendbal").Value)

        '            Dim ivar As Double, irem As String = ""

        '            ivar = actual - iend
        '            If ivar < 0 Then
        '                irem = "Short"
        '            ElseIf ivar > 0 Then
        '                irem = "Over"
        '            End If

        '            grdinv.Rows(updact).Cells("endbal").Value = iend
        '            grdinv.Rows(updact).Cells("variance").Value = ivar
        '            grdinv.Rows(updact).Cells("shov").Value = irem

        '            connect()
        '            If iend > 0 Then
        '                sql = "Update tblitems set status='1' where itemcode = '" & grdinv.Rows(updact).Cells("itemcode").Value & "'"
        '            Else
        '                sql = "Update tblitems set status='0' where itemcode = '" & grdinv.Rows(updact).Cells("itemcode").Value & "'"
        '            End If
        '            cmd = New SqlCommand(sql, conn)
        '            cmd.ExecuteNonQuery()
        '            cmd.Dispose()

        '        ElseIf btnbegbal.Text = "Save Overwrite Beg Bal" Then
        '            If IsNumeric(grdinv.Rows(updact).Cells("begbal").Value) = False Then
        '                MsgBox("Invalid input.", MsgBoxStyle.Exclamation, "")
        '                grdinv.Rows(updact).Cells("begbal").Value = "0.00"
        '                grdinv.ClearSelection()
        '                grdinv.Rows(updact).Cells("begbal").Selected = True
        '                Me.Cursor = Cursors.Default
        '                Exit Sub
        '            Else
        '                If grdinv.Rows(updact).Cells("begbal").Value < 0 Then
        '                    MsgBox("Invalid input.", MsgBoxStyle.Exclamation, "")
        '                    grdinv.Rows(updact).Cells("begbal").Value = "0.00"
        '                    grdinv.ClearSelection()
        '                    grdinv.Rows(updact).Cells("begbal").Selected = True
        '                    Me.Cursor = Cursors.Default
        '                    Exit Sub
        '                Else
        '                    grdinv.Rows(updact).Cells("begbal").Value = Val(grdinv.Rows(updact).Cells("begbal").Value)

        '                    'check if ung item is nka discontinued or not
        '                    sql = "Select * from tblitems where itemname='" & grdinv.Rows(updact).Cells("itemname").Value & "' and discontinued='1'"
        '                    connect()
        '                    cmd = New SqlCommand(sql, conn)
        '                    dr = cmd.ExecuteReader
        '                    If dr.Read Then
        '                        MsgBox("Cannot overwrite. Item is discontinued.", MsgBoxStyle.Exclamation, "")
        '                        btnviewall.PerformClick()
        '                        Me.Cursor = Cursors.Default
        '                        Exit Sub
        '                    End If
        '                    dr.Dispose()
        '                    cmd.Dispose()

        '                    'check if may previuos ba na inv.. ung item if wla msgbox(no beg bal.. this is th first entry of inventory)
        '                    If Val(lblinvsumid.Text) > 1 Then
        '                        Dim tempinvnum As String = ""

        '                        'select top 2 * from invsumid order by invsumid desc.. to get the last invsumid
        '                        sql = "Select TOP 2 * from tblinvsum where invsumid<>'" & Val(lblinvsumid.Text) & "' AND area='" & login.wrkgrp & "' order by invsumid DESC"
        '                        connect()
        '                        cmd = New SqlCommand(sql, conn)
        '                        dr = cmd.ExecuteReader
        '                        If dr.Read Then
        '                            tempinvnum = dr("invnum")
        '                        End If
        '                        dr.Dispose()
        '                        cmd.Dispose()

        '                        'select all items in prev inv to update
        '                        sql = "Select * from tblinvitems where invnum='" & tempinvnum & "' and itemcode = '" & grdinv.Rows(updact).Cells("itemcode").Value & "' AND area='" & login.wrkgrp & "'"
        '                        connect()
        '                        cmd = New SqlCommand(sql, conn)
        '                        dr = cmd.ExecuteReader
        '                        If dr.Read Then
        '                            'ok proceed to overwriting
        '                            'update status at the end
        '                        Else
        '                            If Val(grdinv.Rows(updact).Cells("begbal").Value) <> 0 Then
        '                                MsgBox("Invalid Input. This is the first entry of item.", MsgBoxStyle.Exclamation, "")
        '                                grdinv.Rows(updact).Cells("begbal").Value = "0.00"
        '                                grdinv.ClearSelection()
        '                                grdinv.Rows(updact).Cells("begbal").Selected = True
        '                                Me.Cursor = Cursors.Default
        '                                Exit Sub
        '                            End If
        '                        End If
        '                        dr.Dispose()
        '                        cmd.Dispose()
        '                    Else
        '                        MsgBox("Invalid Input. This is the first entry of inventory.", MsgBoxStyle.Exclamation, "")
        '                        grdinv.Rows(updact).Cells("begbal").Value = "0.00"
        '                        grdinv.ClearSelection()
        '                        grdinv.Rows(updact).Cells("begbal").Selected = True
        '                        Me.Cursor = Cursors.Default
        '                        Exit Sub
        '                    End If
        '                End If
        '            End If

        '            Dim icode As String = grdinv.Rows(updact).Cells("itemcode").Value
        '            Dim ibeg As Double = Val(grdinv.Rows(updact).Cells("begbal").Value)
        '            Dim itemin As Double = Val(grdinv.Rows(updact).Cells("itemin").Value)
        '            Dim itotal As Double '= Val(grdinv.Rows(updact).Cells(5).Value)
        '            Dim ictr As Double = Val(grdinv.Rows(updact).Cells("counterout").Value)
        '            Dim ipull As Double = Val(grdinv.Rows(updact).Cells("pullout").Value)
        '            Dim iend As Double '= Val(grdinv.Rows(updact).Cells(8).Value)
        '            Dim actual As Double = Val(grdinv.Rows(updact).Cells("actualendbal").Value)

        '            Dim ivar As Double, irems As String = ""

        '            'compute for itotal, iend, ivar
        '            itotal = ibeg + itemin
        '            iend = itotal - (ictr + ipull)
        '            ivar = actual - iend
        '            If ivar < 0 Then
        '                irems = "Short"
        '            ElseIf ivar > 0 Then
        '                irems = "Over"
        '            End If

        '            grdinv.Rows(updact).Cells("totalqty").Value = itotal
        '            grdinv.Rows(updact).Cells("endbal").Value = iend
        '            grdinv.Rows(updact).Cells("variance").Value = ivar
        '            grdinv.Rows(updact).Cells("shov").Value = irems

        '            'update status in tblitems
        '            connect()
        '            If iend > 0 Then
        '                sql = "Update tblitems set status='1' where itemcode = '" & grdinv.Rows(updact).Cells("itemcode").Value & "'"
        '            Else
        '                sql = "Update tblitems set status='0' where itemcode = '" & grdinv.Rows(updact).Cells("itemcode").Value & "'"
        '            End If
        '            cmd = New SqlCommand(sql, conn)
        '            cmd.ExecuteNonQuery()
        '            cmd.Dispose()

        '        End If

        '        shortover()
        '        Me.Cursor = Cursors.Default
        '    Catch ex As System.InvalidOperationException
        '        Me.Cursor = Cursors.Default
        '        MsgBox(ex.ToString, MsgBoxStyle.Critical, "")
        '    Catch ex As Exception
        '        Me.Cursor = Cursors.Default
        '        MsgBox(ex.ToString, MsgBoxStyle.Information, "")
        '    Finally
        '        disconnect()
        '    End Try
    End Sub

    Public Sub loadinvnum()
        Try
            Dim get_area As String = ""
            Dim area_format As String = ""
            Dim invid As String = "1", temp As String = ""
            sql = "Select Top 1 * from tblinvsum WHERE area='" & manager & "'  order by invsumid DESC"
            conn.Open()
            cmd = New SqlCommand(sql, conn)
            dr = cmd.ExecuteReader
            If dr.Read Then
                invid = Val(dr("invsumid")) + 1
                get_area = dr("invnum")
            End If
            conn.Close()
            Dim hour As String = getSystemDate.ToString("HH")

            If invid < 100000 Then
                For vv As Integer = 1 To 6 - invid.Length
                    temp += "0"
                Next
                If get_area = "Production" Then
                    area_format = "I.PROD"
                ElseIf get_area = "QC" Then
                    area_format = "I.QC"
                End If
                lblinvid.Text = area_format & " - " & getSystemDate.Year() Mod 100 & " - " & temp & invid
            End If
        Catch ex As SqlException
            If ex.Number = -2 Then
                MessageBox.Show("Timeout Occurred", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information, "")
        End Try
    End Sub

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        cmbcode.SelectedItem = ""
        txtitemin.Text = ""
        txtfind.Text = ""
        txtfind.Visible = False
        btnadd.Enabled = True
        txtitemin.Enabled = True
        btnsearch.Text = "&Search"
    End Sub

    Private Sub btnrems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrems.Click
        Try
            sql = "Select * from tblinvsum where invnum='" & lblinvid.Text & "' AND area='" & manager & "'"
            conn.Open()
            cmd = New SqlCommand(sql, conn)
            dr = cmd.ExecuteReader
            If dr.Read Then
                invremarks.txtrems.Text = dr("rems").ToString
                invremarks.lblinv.Text = dr("invnum").ToString
            End If
            conn.Close()
            invremarks.ShowDialog()
        Catch ex As SqlException
            If ex.Number = -2 Then
                MessageBox.Show("Timeout Occurred", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information, "")
        End Try
    End Sub

    Private Sub btnreport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnreport.Click
        'invreport.MdiParent = mdi
        invreportprev.Close()
        invreport.Close()
        invreport.ctr = True
        invreport.ShowDialog()
        'invreport.WindowState = FormWindowState.Normal
    End Sub

    Public Sub checkbtns()
        If grdinv.Rows.Count = 0 Then
            btnviewall.Enabled = True
            btnnew.Enabled = True
            btnreport.Enabled = False
            ' btnverify.Enabled = False
            btnactual.Enabled = False
            btnbegbal.Enabled = False
            btnrems.Visible = False
            btnimport.Enabled = False
        Else
            btnviewall.Enabled = True
            If btnverify.Text = "Verify" Then
                btnreport.Enabled = False
                btnnew.Enabled = False
                btnverify.Enabled = True
                btnactual.Enabled = True
                btnbegbal.Enabled = True
                GroupBox2.Enabled = True
                btnrems.Enabled = True
                btnimport.Enabled = True
            Else
                'GroupBox2.Enabled = False
                btnreport.Enabled = True
                btnnew.Enabled = True
                ' btnverify.Enabled = False
                btnactual.Enabled = False
                btnbegbal.Enabled = False
                btnrems.Enabled = True
                btnimport.Enabled = False
            End If

            If login.neym = "Sales" Or login.neym = "Manager" Then
                btnrems.Visible = True
            Else
                btnrems.Visible = False
            End If
        End If
    End Sub

    Private Sub btnbegbal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbegbal.Click
        Try
            If btnbegbal.Text = "Overwrite Beg Bal" Then
                grdinv.Columns("begbal").ReadOnly = False
                btnbegbal.Text = "Save Beg Bal"
            ElseIf btnbegbal.Text = "Save Beg Bal" Then
                GetTransID()
                For index As Integer = 0 To grdinv.RowCount - 1
                    Dim current_totalav As Double = 0.00, current_out As Double = 0.00, endbal As Double = 0.00, actualendbal As Double = 0.00, variance_result As Double = 0.00, so_result As String = "", invid As Integer = 0
                    If CDbl(grdinv.Rows(index).Cells("begbal").Value) <> 0 Then
                        conn.Open()
                        cmd = New SqlCommand("SELECT invid,good,reject,charge,productionin,itemin,supin,convin,transfer,ctrout,arreject,archarge,arsales,convout,pullout,actualendbal FROM tblinvitems WHERE itemcode=@itemcode AND itemname=@itemname AND invnum=@invnum;", conn)
                        cmd.Parameters.AddWithValue("@itemcode", grdinv.Rows(index).Cells("itemcode").Value)
                        cmd.Parameters.AddWithValue("@itemname", grdinv.Rows(index).Cells("itemname").Value)
                        cmd.Parameters.AddWithValue("@invnum", lblinvid.Text)
                        dr = cmd.ExecuteReader
                        If dr.Read Then
                            current_totalav = CDbl(grdinv.Rows(index).Cells("begbal").Value) + dr("good") + dr("reject") + dr("charge") + dr("convin")
                            current_out = dr("transfer") + dr("ctrout") + dr("arreject") + dr("archarge") + dr("arsales") + dr("pullout")
                            actualendbal = dr("actualendbal")
                            invid = dr("invid")
                        End If
                        conn.Close()
                        endbal = current_totalav - current_out
                        variance_result = actualendbal - endbal
                        If variance_result < 0 Then
                            so_result = "Short"
                        Else
                            so_result = "Over"
                        End If

                        conn.Open()
                        cmd = New SqlCommand("UPDATE tblinvitems SET begbal=@begbal,totalav=@totalav,endbal=@endbal,variance=@variance,shortover=@so WHERE invid=@invid;", conn)
                        cmd.Parameters.AddWithValue("@begbal", CDbl(grdinv.Rows(index).Cells("begbal").Value))
                        cmd.Parameters.AddWithValue("@totalav", current_totalav)
                        cmd.Parameters.AddWithValue("@endbal", endbal)
                        cmd.Parameters.AddWithValue("@variance", variance_result)
                        cmd.Parameters.AddWithValue("@so", so_result)
                        cmd.Parameters.AddWithValue("@invid", invid)
                        cmd.ExecuteNonQuery()
                        conn.Close()


                        conn.Open()
                        cmd = New SqlCommand("INSERT INTO tblproduction (transaction_number,inv_id,item_code,item_name,category,quantity,date,processed_by,type,area,status) VALUES ('" & trans_num & "','" & lblinvid.Text & "','" & grdinv.Rows(index).Cells("itemcode").Value & "','" & grdinv.Rows(index).Cells("itemname").Value & "',(SELECT category FROM tblitems WHERE itemcode='" & grdinv.Rows(index).Cells("itemcode").Value & "' AND itemname='" & grdinv.Rows(index).Cells("itemname").Value & "'),'" & CDbl(grdinv.Rows(index).Cells("begbal").Value) & "',(SELECT GETDATE()),'" & login.neym & "','Overwrite Beg Bal', '" & manager & "', 'Completed');", conn)
                        cmd.ExecuteNonQuery()
                        conn.Close()
                    End If
                Next
                MessageBox.Show("Overwrite Completed", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                grdinv.Columns("begbal").ReadOnly = True
                btnbegbal.Text = "Overwrite Beg Bal"

                viewlast()
            End If

        Catch ex As SqlException
            If ex.Number = -2 Then
                MessageBox.Show("Timeout Occurred", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            Dim taypz As String = ""
            conn.Open()
            cmd = New SqlCommand("Select DISTINCT transaction_number  from tblproduction WHERE area='" & manager & "' AND type='" & "Overwrite Beg Bal" & "';", conn)
            dr = cmd.ExecuteReader
            While dr.Read
                selectcount_result += 1
            End While
            conn.Close()
            selectcount_result += 1

            Dim branchcode As String = ""
            conn.Open()
            cmd = New SqlCommand("SELECT branchcode FROM tblbranch WHERE main='1';", conn)
            dr = cmd.ExecuteReader
            If dr.Read Then
                branchcode = dr("branchcode")
            End If
            conn.Close()

            If manager = "Sales" Then
                area_format = "OBB - " & branchcode & " - "
            ElseIf manager = "Production" Then
                area_format = "OBB(PRD) - " & branchcode & " - "
            End If

            If selectcount_result < 1000000 Then
                Dim cselectcount_result As String = CStr(selectcount_result)
                For vv As Integer = 1 To 6 - cselectcount_result.Length
                    temp += "0"
                Next
                trans_num = area_format & temp & selectcount_result
            End If

        Catch ex As SqlException
            If ex.Number = -2 Then
                MessageBox.Show("Timeout Occurred", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information, "")
        End Try
    End Sub
    Private Sub btnadmin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadmin.Click
        Try

            If login.neym <> "Sales" Then
                MsgBox("Authorization failed!", MsgBoxStyle.Critical, "")
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            Dim zz As String = getSystemDate.ToString("MM/dd/yyyy")
            Dim over As Boolean = False, invnum As String = ""
            sql = "Select TOP 1 * from tblinvsum WHERE area='" & manager & "' order by invsumid DESC"
            conn.Open()
            cmd = New SqlCommand(sql, conn)
            dr = cmd.ExecuteReader
            If dr.Read Then
                If dr("verify") = 1 Then
                    If dr("invdate") = zz Then
                        invnum = dr("invnum")
                        over = True
                    End If
                End If
            End If
            conn.Close()


            If over = True Then
                confirm.ShowDialog()
                If actual = True Then
                    sql = "Update tblinvsum set verify='0' where invnum='" & invnum & "' AND area='" & manager & "'"
                    conn.Open()
                    cmd = New SqlCommand(sql, conn)
                    cmd.ExecuteNonQuery()
                    conn.Close()

                    over = False
                    btnviewall.PerformClick()
                End If
            End If
        Catch ex As SqlException
            If ex.Number = -2 Then
                MessageBox.Show("Timeout Occurred", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "")
        End Try
    End Sub

    Private Sub btnsearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsearch.Click
        If btnsearch.Text = "&Search" Then
            cat()
            cmbcat.Enabled = False
            txtfind.Visible = True
            txtfind.Focus()
            txtitemin.Enabled = False
            btnsearch.Text = "Find"
            btnadd.Enabled = False
        Else
            'may items na wla sa invnum pero nkacontinue nmn ito ung items na na discontinue tas cinontinue or bagong item na di pa naaad sa inv
            grdinv.Rows.Clear()
            sql = "Select * from tblinvitems where invnum='" & lblinvid.Text & "' and itemcode like '" & Trim(txtfind.Text) & "%' AND area='" & manager & "'"
            conn.Open()
            cmd = New SqlCommand(sql, conn)
            dr = cmd.ExecuteReader
            While dr.Read
                Me.Cursor = Cursors.WaitCursor
                grdinv.Rows.Add(dr("invid"), dr("itemcode"), dr("itemname"), dr("begbal"), dr("produce"), dr("good"), dr("reject"), dr("charge"), dr("productionin"), dr("itemin"), dr("supin"), dr("convin"), dr("totalav"), dr("transfer"), dr("ctrout"), dr("arreject"), dr("archarge"), dr("arsales"), dr("convout"), dr("pullout"), dr("endbal"), dr("actualendbal"), dr("variance"), dr("shortover"))
                grdinv.Item(3, grdinv.Rows.Count - 1).Style.BackColor = Color.FromArgb(255, 255, 128)
                grdinv.Item(4, grdinv.Rows.Count - 1).Style.BackColor = Color.FromArgb(255, 255, 128)
                grdinv.Item(5, grdinv.Rows.Count - 1).Style.BackColor = Color.FromArgb(255, 255, 128)
                grdinv.Item(6, grdinv.Rows.Count - 1).Style.BackColor = Color.FromArgb(255, 255, 128)
                grdinv.Item(7, grdinv.Rows.Count - 1).Style.BackColor = Color.FromArgb(255, 255, 128)
                grdinv.Item(8, grdinv.Rows.Count - 1).Style.BackColor = Color.FromArgb(255, 255, 128)
                grdinv.Item(9, grdinv.Rows.Count - 1).Style.BackColor = Color.FromArgb(255, 255, 128)
                grdinv.Item(10, grdinv.Rows.Count - 1).Style.BackColor = Color.FromArgb(255, 255, 128)
                grdinv.Item(11, grdinv.Rows.Count - 1).Style.BackColor = Color.FromArgb(255, 255, 128)
                grdinv.Item(12, grdinv.Rows.Count - 1).Style.BackColor = Color.FromArgb(255, 255, 128)
                grdinv.Item(13, grdinv.Rows.Count - 1).Style.BackColor = Color.FromArgb(255, 255, 128)
                grdinv.Item(14, grdinv.Rows.Count - 1).Style.BackColor = Color.FromArgb(255, 255, 128)
                grdinv.Item(15, grdinv.Rows.Count - 1).Style.BackColor = Color.FromArgb(192, 255, 192)
                grdinv.Item(16, grdinv.Rows.Count - 1).Style.BackColor = Color.FromArgb(192, 255, 192)
                grdinv.Item(17, grdinv.Rows.Count - 1).Style.BackColor = Color.FromArgb(192, 255, 192)
                grdinv.Item(18, grdinv.Rows.Count - 1).Style.BackColor = Color.FromArgb(192, 255, 192)
                grdinv.Item(19, grdinv.Rows.Count - 1).Style.BackColor = Color.FromArgb(192, 255, 192)
                grdinv.Item(20, grdinv.Rows.Count - 1).Style.BackColor = Color.FromArgb(192, 255, 192)
                grdinv.Item(21, grdinv.Rows.Count - 1).Style.BackColor = Color.FromArgb(192, 255, 192)
                grdinv.Item(22, grdinv.Rows.Count - 1).Style.BackColor = Color.FromArgb(192, 255, 192)
                grdinv.Item(23, grdinv.Rows.Count - 1).Style.BackColor = Color.FromArgb(192, 255, 192)
                grdinv.Item(24, grdinv.Rows.Count - 1).Style.BackColor = Color.FromArgb(255, 192, 128)
                grdinv.Item(25, grdinv.Rows.Count - 1).Style.BackColor = Color.FromArgb(255, 192, 128)
                grdinv.Item(26, grdinv.Rows.Count - 1).Style.BackColor = Color.FromArgb(255, 192, 128)
                grdinv.Item(27, grdinv.Rows.Count - 1).Style.BackColor = Color.FromArgb(255, 192, 128)
            End While
            conn.Close()

            shortover()
            Me.Cursor = Cursors.Default

            If grdinv.Rows.Count = 0 Then
                If Trim(txtfind.Text) <> "" Then
                    MsgBox("Cannot find " & Trim(txtfind.Text) & ".", MsgBoxStyle.Critical, "")
                    txtfind.Text = ""
                    txtfind.Focus()
                    'disable some buttons
                    btnviewall.PerformClick()
                    Exit Sub
                Else
                    MsgBox("Input Item Code first.", MsgBoxStyle.Exclamation, "")
                    Exit Sub
                End If
            End If

            cmbcode.SelectedItem = ""
            txtitemin.Text = ""
            txtfind.Text = ""
            txtfind.Visible = False
            btnadd.Enabled = True
            txtitemin.Enabled = True
            cmbcat.Enabled = True
            btnsearch.Text = "&Search"
        End If
    End Sub

    Private Sub btnimport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnimport.Click
        Try
            If btnverify.Text = "Verify" Then
                If grdinv.Rows.Count <> 0 Then
                    importinv.ShowDialog()
                End If
            Else
                MsgBox("Create new inventory first.", MsgBoxStyle.Critical, "")
            End If
        Catch ex As SqlException
            If ex.Number = -2 Then
                MessageBox.Show("Timeout Occurred", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information, "")
        End Try
    End Sub

    Private Sub txtfind_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtfind.KeyPress
        If Asc(e.KeyChar) = Windows.Forms.Keys.Enter Then
            btnsearch.PerformClick()
        End If

        If Asc(e.KeyChar) = 39 Then
            e.Handled = True
        End If
    End Sub

    Private Sub cmbcat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbcat.SelectedIndexChanged
        Try
            lblcat.Text = cmbcat.SelectedItem
            cmbcode.SelectedIndex = -1
            If cmbcat.SelectedItem <> "All" Then

                grdinv.Rows.Clear()
                cmbtemp.Items.Clear()
                If rb1.Checked Then
                    sql = "Select tblinvitems.itemcode from tblinvitems JOIN tblitems ON tblinvitems.itemcode = tblitems.itemcode AND tblinvitems.itemname = tblitems.itemname where tblitems.category ='" & cmbcat.SelectedItem & "' AND tblinvitems.invnum='" & lblinvid.Text & "' AND tblinvitems.endbal !=0 AND tblinvitems.area='" & manager & "' order by tblinvitems.itemcode"
                ElseIf rb2.Checked Then
                    sql = "Select tblinvitems.itemcode from tblinvitems JOIN tblitems ON tblinvitems.itemcode = tblitems.itemcode AND tblinvitems.itemname = tblitems.itemname where tblitems.category ='" & cmbcat.SelectedItem & "' AND tblinvitems.invnum='" & lblinvid.Text & "' AND tblinvitems.area='" & manager & "' order by tblinvitems.itemcode"
                End If

                conn.Open()
                cmd = New SqlCommand(sql, conn)
                dr = cmd.ExecuteReader
                While dr.Read
                    cmbtemp.Items.Add(dr("itemcode"))
                End While
                conn.Close()

                cmbitemcode.Items.Clear()

                If rb1.Checked Then
                    sql = "Select tblinvitems.itemcode AS aa from tblinvitems JOIN tblitems ON tblinvitems.itemcode = tblitems.itemcode AND tblinvitems.itemname = tblitems.itemname where tblitems.category ='" & cmbcat.SelectedItem & "' AND tblinvitems.invnum='" & lblinvid.Text & "' AND tblinvitems.endbal !=0 AND tblinvitems.area='" & manager & "' order by tblinvitems.itemcode"
                ElseIf rb2.Checked Then
                    sql = "Select tblinvitems.itemcode AS aa from tblinvitems JOIN tblitems ON tblinvitems.itemcode = tblitems.itemcode AND tblinvitems.itemname = tblitems.itemname where tblitems.category ='" & cmbcat.SelectedItem & "' AND tblinvitems.invnum='" & lblinvid.Text & "'  AND tblinvitems.area='" & manager & "' order by tblinvitems.itemcode"
                End If
                conn.Open()
                Dim cmd1 As SqlCommand = New SqlCommand(sql, conn)
                Dim dr1 As SqlDataReader = cmd1.ExecuteReader
                While dr1.Read
                    cmbitemcode.Items.Add(dr1("aa"))
                End While
                conn.Close()

                For i = 0 To cmbitemcode.Items.Count - 1
                    cmbitemcode.SelectedIndex = i

                    If rb1.Checked Then
                        sql = "Select * from tblinvitems where invnum='" & lblinvid.Text & "' AND endbal !=0 and itemcode='" & cmbitemcode.SelectedItem & "' AND area='" & manager & "' order by itemcode"
                    ElseIf rb2.Checked Then
                        sql = "Select * from tblinvitems where invnum='" & lblinvid.Text & "' AND itemcode='" & cmbitemcode.SelectedItem & "' AND area='" & manager & "' order by itemcode"
                    End If

                    conn.Open()
                    cmd = New SqlCommand(sql, conn)
                    dr = cmd.ExecuteReader
                    While dr.Read
                        grdinv.Rows.Add(dr("invid"), dr("itemcode"), dr("itemname"), dr("begbal"), dr("produce"), dr("good"), dr("charge"), dr("productionin"), dr("itemin"), dr("supin"), dr("adjustmentin"), dr("convin"), dr("cancelin"), dr("totalav"), dr("transfer"), dr("ctrout"), dr("archarge"), dr("arsales"), dr("convout"), dr("pullout"), dr("reject"), dr("reject_convin"), dr("reject_totalav"), totalqty.ToString, dr("arreject"), dr("reject_archarge"), dr("reject_convout"), dr("reject_transfer"), dr("endbal"), dr("actualendbal"), dr("variance"), dr("shortover"))

                        colors()
                    End While
                    conn.Close()
                Next

                cmbcode.Items.Clear()
                cmbcode.Items.Add("")
                For i = 0 To cmbitemcode.Items.Count - 1
                    cmbitemcode.SelectedIndex = i
                    If rb1.Checked Then
                        sql = "Select tblinvitems.itemcode AS aa from tblinvitems JOIN tblitems ON tblinvitems.itemcode = tblitems.itemcode AND tblinvitems.itemname = tblitems.itemname where tblitems.category ='" & cmbcat.SelectedItem & "' AND tblinvitems.invnum='" & lblinvid.Text & "' AND tblinvitems.endbal !=0 AND tblinvitems.area='" & manager & "' order by tblinvitems.itemcode"
                    ElseIf rb2.Checked Then
                        sql = "Select tblinvitems.itemcode AS aa from tblinvitems JOIN tblitems ON tblinvitems.itemcode = tblitems.itemcode AND tblinvitems.itemname = tblitems.itemname where tblitems.category ='" & cmbcat.SelectedItem & "' AND tblinvitems.invnum='" & lblinvid.Text & "'  AND tblinvitems.area='" & manager & "' order by tblinvitems.itemcode"
                    End If
                    conn.Open()
                    cmd = New SqlCommand(sql, conn)
                    dr = cmd.ExecuteReader
                    While dr.Read
                        If Not cmbcode.Items.Contains(dr("aa")) Then
                            cmbcode.Items.Add(dr("aa"))
                        End If
                    End While
                    conn.Close()
                Next

            Else
                btnviewall.PerformClick()

                cmbcode.Items.Clear()
                cmbcode.Items.Add("")
                conn.Open()
                ' For i = 0 To cmbitemcode.Items.Count - 1
                'cmbitemcode.SelectedIndex = i
                sql = "Select * from tblitems where discontinued='0' order by itemcode"
                cmd = New SqlCommand(sql, conn)
                dr = cmd.ExecuteReader
                While dr.Read
                    If Not cmbcode.Items.Contains(dr("itemcode")) Then
                        cmbcode.Items.Add(dr("itemcode"))
                    End If
                End While
                conn.Close()
                ' Next
            End If
            'weeeh
            cmbcode.SelectedItem = lblcode.Text
            shortover()
            'apcash("Advance Payment", lblap)
            'cash("Cash", "ctrout_amt")
            'gcXDel("gc", lblgc)
            'gcXDel("deliver", lbldelcharge)
            'appayment2("AR Sales", "arsales_amt")
            'appayment2("AR Charge", "archarge_amt")
            'arcash("A.R Cash", lblarcashtotal)
            'DepXCo("Deposit", lbldeposit)
            'DepXCo("Cash Out", lblcashout)
            'amount("shortamount", lblshortamount)
            'amount("overamount", lbloveramount)
            'amount("ctrout_amt", lblcounteramount)
            'amount("archarge_amt", lblarchargeamount)
            'amount("arsales_amt", lblarsalesamount)
            Me.Cursor = Cursors.Default
            searchCode()
        Catch ex As SqlException
            If ex.Number = -2 Then
                MessageBox.Show("Timeout Occurred", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString)
        End Try
    End Sub

    Public Sub colors()
        grdinv.Item(3, grdinv.Rows.Count - 1).Style.BackColor = Color.FromArgb(255, 255, 128)
        grdinv.Item(4, grdinv.Rows.Count - 1).Style.BackColor = Color.FromArgb(255, 255, 128)
        grdinv.Item(5, grdinv.Rows.Count - 1).Style.BackColor = Color.FromArgb(255, 255, 128)
        grdinv.Item(6, grdinv.Rows.Count - 1).Style.BackColor = Color.FromArgb(255, 255, 128)
        grdinv.Item(7, grdinv.Rows.Count - 1).Style.BackColor = Color.FromArgb(255, 255, 128)
        grdinv.Item(8, grdinv.Rows.Count - 1).Style.BackColor = Color.FromArgb(255, 255, 128)
        grdinv.Item(9, grdinv.Rows.Count - 1).Style.BackColor = Color.FromArgb(255, 255, 128)
        grdinv.Item(10, grdinv.Rows.Count - 1).Style.BackColor = Color.FromArgb(255, 255, 128)
        grdinv.Item(11, grdinv.Rows.Count - 1).Style.BackColor = Color.FromArgb(255, 255, 128)
        grdinv.Item(12, grdinv.Rows.Count - 1).Style.BackColor = Color.FromArgb(255, 255, 128)
        grdinv.Item(13, grdinv.Rows.Count - 1).Style.BackColor = Color.FromArgb(255, 255, 128)
        grdinv.Item(14, grdinv.Rows.Count - 1).Style.BackColor = Color.FromArgb(192, 255, 192)
        grdinv.Item(15, grdinv.Rows.Count - 1).Style.BackColor = Color.FromArgb(192, 255, 192)
        grdinv.Item(16, grdinv.Rows.Count - 1).Style.BackColor = Color.FromArgb(192, 255, 192)
        grdinv.Item(17, grdinv.Rows.Count - 1).Style.BackColor = Color.FromArgb(192, 255, 192)
        grdinv.Item(18, grdinv.Rows.Count - 1).Style.BackColor = Color.FromArgb(192, 255, 192)

        grdinv.Item(19, grdinv.Rows.Count - 1).Style.BackColor = Color.FromArgb(192, 255, 192)
        grdinv.Item(20, grdinv.Rows.Count - 1).Style.BackColor = Color.FromArgb(247, 247, 87)


        grdinv.Item(21, grdinv.Rows.Count - 1).Style.BackColor = Color.FromArgb(247, 247, 87)
        grdinv.Item(22, grdinv.Rows.Count - 1).Style.BackColor = Color.FromArgb(157, 224, 157)
        grdinv.Item(23, grdinv.Rows.Count - 1).Style.BackColor = Color.FromArgb(157, 224, 157)
        grdinv.Item(24, grdinv.Rows.Count - 1).Style.BackColor = Color.FromArgb(157, 224, 157)
        grdinv.Item(25, grdinv.Rows.Count - 1).Style.BackColor = Color.FromArgb(157, 224, 157)
        grdinv.Item(26, grdinv.Rows.Count - 1).Style.BackColor = Color.FromArgb(157, 224, 157)

        grdinv.Item(27, grdinv.Rows.Count - 1).Style.BackColor = Color.FromArgb(157, 224, 157)
        grdinv.Item(28, grdinv.Rows.Count - 1).Style.BackColor = Color.FromArgb(255, 192, 128)
        grdinv.Item(29, grdinv.Rows.Count - 1).Style.BackColor = Color.FromArgb(255, 192, 128)
        grdinv.Item(30, grdinv.Rows.Count - 1).Style.BackColor = Color.FromArgb(255, 192, 128)
    End Sub

    Private Sub btnrefresh_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrefresh.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            btnactual.Text = "Update Actual End Bal"
            btnbegbal.Text = "Overwrite Beg Bal"
            grdinv.Columns("begbal").ReadOnly = True
            grdinv.Columns("actualendbal").ReadOnly = True
            checkbtns()

            If lblcat.Text <> "All" Then

                Dim d As String = manager

                grdinv.Rows.Clear()
                cmbtemp.Items.Clear()
                sql = "Select * from tblinvitems where invnum='" & lblinvid.Text & "' AND area='" & d & "'  order by itemcode"
                conn.Open()
                cmd = New SqlCommand(sql, conn)
                dr = cmd.ExecuteReader
                While dr.Read
                    cmbtemp.Items.Add(dr("itemcode"))
                End While
                conn.Close()
                cmbitemcode.Items.Clear()
                For i = 0 To cmbtemp.Items.Count - 1
                    cmbtemp.SelectedIndex = i
                    conn.Open()
                    sql = "Select * from tblitems where itemcode='" & cmbtemp.SelectedItem & "' and category='" & lblcat.Text & "' order by itemcode"
                    Dim cmd1 As SqlCommand = New SqlCommand(sql, conn)
                    Dim dr1 As SqlDataReader = cmd1.ExecuteReader
                    If dr1.Read Then
                        cmbitemcode.Items.Add(dr1("itemcode"))
                    End If
                    conn.Close()
                Next

                For i = 0 To cmbitemcode.Items.Count - 1
                    cmbitemcode.SelectedIndex = i
                    sql = "Select * from tblinvitems where invnum='" & lblinvid.Text & "' and itemcode='" & cmbitemcode.SelectedItem & "' AND area='" & d & "'  order by itemcode"
                    conn.Open()
                    cmd = New SqlCommand(sql, conn)
                    dr = cmd.ExecuteReader
                    While dr.Read
                        grdinv.Rows.Add(dr("invid"), dr("itemcode"), dr("itemname"), dr("begbal"), dr("produce"), dr("good"), dr("reject"), dr("charge"), dr("productionin"), dr("itemin"), dr("supin"), dr("convin"), dr("totalav"), dr("transfer"), dr("ctrout"), dr("arsales"), dr("convout"), dr("pullout"), dr("endbal"), dr("actualendbal"), dr("variance"), dr("shortover"))
                        grdinv.Item(3, grdinv.Rows.Count - 1).Style.BackColor = Color.FromArgb(255, 255, 128)
                        grdinv.Item(4, grdinv.Rows.Count - 1).Style.BackColor = Color.FromArgb(255, 255, 128)
                        grdinv.Item(5, grdinv.Rows.Count - 1).Style.BackColor = Color.FromArgb(255, 255, 128)
                        grdinv.Item(6, grdinv.Rows.Count - 1).Style.BackColor = Color.FromArgb(255, 255, 128)
                        grdinv.Item(7, grdinv.Rows.Count - 1).Style.BackColor = Color.FromArgb(255, 255, 128)
                        grdinv.Item(8, grdinv.Rows.Count - 1).Style.BackColor = Color.FromArgb(255, 255, 128)
                        grdinv.Item(9, grdinv.Rows.Count - 1).Style.BackColor = Color.FromArgb(255, 255, 128)
                        grdinv.Item(10, grdinv.Rows.Count - 1).Style.BackColor = Color.FromArgb(255, 255, 128)
                        grdinv.Item(11, grdinv.Rows.Count - 1).Style.BackColor = Color.FromArgb(255, 255, 128)
                        grdinv.Item(12, grdinv.Rows.Count - 1).Style.BackColor = Color.FromArgb(255, 255, 128)
                        grdinv.Item(13, grdinv.Rows.Count - 1).Style.BackColor = Color.FromArgb(192, 255, 192)
                        grdinv.Item(14, grdinv.Rows.Count - 1).Style.BackColor = Color.FromArgb(192, 255, 192)
                        grdinv.Item(15, grdinv.Rows.Count - 1).Style.BackColor = Color.FromArgb(192, 255, 192)
                        grdinv.Item(16, grdinv.Rows.Count - 1).Style.BackColor = Color.FromArgb(192, 255, 192)
                        grdinv.Item(17, grdinv.Rows.Count - 1).Style.BackColor = Color.FromArgb(192, 255, 192)
                        grdinv.Item(18, grdinv.Rows.Count - 1).Style.BackColor = Color.FromArgb(192, 255, 192)
                        grdinv.Item(19, grdinv.Rows.Count - 1).Style.BackColor = Color.FromArgb(255, 192, 128)
                        grdinv.Item(20, grdinv.Rows.Count - 1).Style.BackColor = Color.FromArgb(255, 192, 128)
                        grdinv.Item(21, grdinv.Rows.Count - 1).Style.BackColor = Color.FromArgb(255, 192, 128)
                        grdinv.Item(22, grdinv.Rows.Count - 1).Style.BackColor = Color.FromArgb(255, 192, 128)
                        grdinv.Item(23, grdinv.Rows.Count - 1).Style.BackColor = Color.FromArgb(255, 192, 128)
                        grdinv.Item(23, grdinv.Rows.Count - 1).Style.BackColor = Color.FromArgb(255, 192, 128)
                    End While
                    conn.Close()
                Next

            Else
                btnviewall.PerformClick()
            End If

            cat()
            cmbcat.SelectedItem = lblcat.Text

            Dim ctramt_total As Double = 0.00, archarge_amt As Double = 0.00, arsales_amt As Double = 0.00
            For index As Integer = 0 To grdinv.RowCount - 1
                grdinv.Rows(index).Cells("ctrout_amt").Value = ctramount(grdinv.Rows(index).Cells("itemname").Value, "Cash")
                ctramt_total += ctramount(grdinv.Rows(index).Cells("itemname").Value, "Cash")
                If grdinv.Rows(index).Cells("ctrout_amt").Value > 0 Then
                    grdinv.Rows(index).Cells("ctrout_amt").Style.ForeColor = Color.Green
                End If
                grdinv.Rows(index).Cells("arsales_amt").Value = ctramount(grdinv.Rows(index).Cells("itemname").Value, "A.R Sales")

                If grdinv.Rows(index).Cells("arsales_amt").Value > 0 Then
                    grdinv.Rows(index).Cells("arsales_amt").Style.ForeColor = Color.Green
                End If
                arsales_amt += ctramount(grdinv.Rows(index).Cells("itemname").Value, "A.R Sales")
                grdinv.Rows(index).Cells("archarge_amt").Value = ctramount(grdinv.Rows(index).Cells("itemname").Value, "A.R Charge")
                archarge_amt += ctramount(grdinv.Rows(index).Cells("itemname").Value, "A.R Charge")
                If grdinv.Rows(index).Cells("archarge_amt").Value > 0 Then
                    grdinv.Rows(index).Cells("archarge_amt").Style.ForeColor = Color.Green
                End If
            Next

            lblcounteramount.Text = ctramt_total.ToString("n2")
            lblarchargeamount.Text = archarge_amt.ToString("n2")
            lblarsalesamount.Text = arsales_amt.ToString("n2")
            'ctramount("ctrout_amt", "Cash")
            'ctramount("arsales_amt", "A.R Sales")
            'ctramount("archarge_amt", "A.R Charge")
            'weeeh
            'cash("Cash", "ctrout_amt")
            'appayment2("AR Sales", "arsales_amt")
            'appayment2("AR Charge", "archarge_amt")
            'amount("shortamount", lblshortamount)
            'amount("overamount", lbloveramount)
            'amount("ctrout_amt", lblcounteramount)
            'amount("archarge_amt", lblarchargeamount)
            'amount("arsales_amt", lblarsalesamount)
            Me.Cursor = Cursors.Default
            If rb1.Checked Then
                btnverify.Enabled = checkVerify()
                If btnverify.Text = "Verified" Then
                    btnverify.Enabled = False
                End If
            Else
                btnverify.Enabled = False
            End If
            If login.wrkgrp = "LC Accounting" Or login.wrkgrp = "Manager" Then
                btnverify.Enabled = False
            End If
            lbltotal.Text = (CDbl(lblshortamount.Text) + CDbl(lbloveramount.Text) + CDbl(lblcounteramount.Text) + CDbl(lblarchargeamount.Text) + CDbl(lblarsalesamount.Text)).ToString("n2")
        Catch ex As SqlException
            If ex.Number = -2 Then
                MessageBox.Show("Timeout Occurred", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information, "")
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
        Catch ex As SqlException
            If ex.Number = -2 Then
                MessageBox.Show("Timeout Occurred", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Function

    Public Function checkCutOff() As Boolean
        Try
            Dim status As String = "", date_from As New DateTime()

            Dim serverDate As String = getSystemDate.ToString("MM/dd/yyyy")

            conn.Open()
            cmd = New SqlCommand("Select status,Date FROM tblcutoff WHERE userid= (Select systemid FROM tblusers WHERE username=@username) ORDER BY cid DESC;", conn)
            cmd.Parameters.AddWithValue("@username", login.username)
            dr = cmd.ExecuteReader
            If dr.Read Then
                status = dr("status")
                date_from = CDate(dr("Date"))
            End If
            conn.Close()
            If status = "In Active" And date_from.ToString("MM/dd/yyyy") = serverDate Then
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
    Private Sub grdinv_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles grdinv.EditingControlShowing
        If grdinv.CurrentCell.ColumnIndex = 3 Then
            AddHandler CType(e.Control, TextBox).KeyPress, AddressOf TextBox_keyPress
        End If
    End Sub

    Private Sub rb1_CheckedChanged(sender As Object, e As EventArgs) Handles rb1.CheckedChanged
        'main.Timer1.Stop()
        viewlast()
        'weeh
        'cash("Cash", "ctrout_amt")
        'appayment2("AR Sales", "arsales_amt")
        'appayment2("AR Charge", "archarge_amt")
        'amount("shortamount", lblshortamount)
        'amount("overamount", lbloveramount)
        'amount("ctrout_amt", lblcounteramount)
        'amount("archarge_amt", lblarchargeamount)
        'amount("arsales_amt", lblarsalesamount)
        'lbltotal.Text = (CDbl(lblshortamount.Text) + CDbl(lbloveramount.Text) + CDbl(lblcounteramount.Text) + CDbl(lblarchargeamount.Text) + CDbl(lblarsalesamount.Text)).ToString("n2")
        'main.Timer1.Start()
    End Sub

    Private Sub rb2_CheckedChanged(sender As Object, e As EventArgs) Handles rb2.CheckedChanged
        '  main.Timer1.Stop()
        viewlast()
        'weeeh
        'cash("Cash", "ctrout_amt")
        'appayment2("AR Sales", "arsales_amt")
        'appayment2("AR Charge", "archarge_amt")
        'amount("shortamount", lblshortamount)
        'amount("overamount", lbloveramount)
        'amount("ctrout_amt", lblcounteramount)
        'amount("archarge_amt", lblarchargeamount)
        ''amount("arsales_amt", lblarsalesamount)
        'lbltotal.Text = (CDbl(lblshortamount.Text) + CDbl(lbloveramount.Text) + CDbl(lblcounteramount.Text) + CDbl(lblarchargeamount.Text) + CDbl(lblarsalesamount.Text)).ToString("n2")
        'main.Timer1.Start()
    End Sub

    Private Sub inv_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        grdinv.ScrollBars = ScrollBars.Both
        lbltotal.Text = (CDbl(lblshortamount.Text) + CDbl(lbloveramount.Text) + CDbl(lblcounteramount.Text) + CDbl(lblarchargeamount.Text) + CDbl(lblarsalesamount.Text)).ToString("n2")
    End Sub

    Private Sub TextBox_keyPress(sender As Object, e As KeyPressEventArgs)
        If Not Char.IsControl(e.KeyChar) And Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub dtinvsearch_ValueChanged(sender As Object, e As EventArgs) Handles dtinvsearch.ValueChanged
        Try
            Dim ver As Boolean = False

            Dim serverDate As String = getSystemDate.ToString("MM/dd/yyyy")

            conn.Open()
            cmd = New SqlCommand("Select * FROM tblinvsum WHERE CAST(datecreated As Date)='" & dtinvsearch.Text & "';", conn)
            dr = cmd.ExecuteReader
            If dr.Read Then
                lblinvid.Text = dr("invnum")

                lblinvsumid.Text = dr("invsumid")
                lbldate.Text = Format(dr("datecreated"), "MM/dd/yyyy HH:mm")
                If dr("verify") = 1 Then
                    ver = True
                    btnverify.Text = "Verified"
                    btnverify.Enabled = False
                    checkbtns()
                Else
                    btnverify.Text = "Verify"
                    ver = False
                    btnactual.Enabled = True
                    btnbegbal.Enabled = True
                    checkbtns()
                End If

                If CDate(lbldate.Text.Substring(0, 10)) <> CDate(serverDate).ToString("MM/dd/yyyy") Then
                    lblreminder.Visible = True
                Else
                    lblreminder.Visible = False
                End If

            Else
                lblinvid.Text = "N/A"
            End If
            conn.Close()
            btnrefresh.PerformClick()
        Catch ex As SqlException
            If ex.Number = -2 Then
                MessageBox.Show("Timeout Occurred", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Public Sub shortover()
        Try
            If grdinv.Rows.Count > 0 Then
                If btnverify.Text = "Verified" Then
                    'view values from database
                    For i = 0 To grdinv.Rows.Count - 1
                        If grdinv.Rows(i).Cells("shov").Value = "Short" Then
                            conn.Open()
                            sql = "Select * from tblinvitems where invnum='" & lblinvid.Text & "' and itemcode='" & grdinv.Rows(i).Cells("itemcode").Value & "' AND area='" & manager & "'"
                            cmd = New SqlCommand(sql, conn)
                            dr = cmd.ExecuteReader
                            If dr.Read Then
                                grdinv.Rows(i).Cells("shortamount").Value = dr("shortamt")
                            End If
                            conn.Close()

                        ElseIf grdinv.Rows(i).Cells("shov").Value = "Over" Then
                            sql = "Select * from tblinvitems where invnum='" & lblinvid.Text & "' and itemcode='" & grdinv.Rows(i).Cells("itemcode").Value & "' AND area='" & manager & "'"
                            conn.Open()
                            cmd = New SqlCommand(sql, conn)
                            dr = cmd.ExecuteReader
                            If dr.Read Then
                                grdinv.Rows(i).Cells("overamount").Value = dr("overamt")
                            End If
                            conn.Close()
                        End If
                    Next
                Else
                    For i = 0 To grdinv.Rows.Count - 1



                        If grdinv.Rows(i).Cells("shov").Value = "Short" Then
                            sql = "Select * from tblitems where itemcode='" & grdinv.Rows(i).Cells("itemcode").Value & "'"
                            conn.Open()
                            cmd = New SqlCommand(sql, conn)
                            dr = cmd.ExecuteReader
                            If dr.Read Then
                                grdinv.Rows(i).Cells("shortamount").Value = Val(dr("price")) * Val(grdinv.Rows(i).Cells("variance").Value)
                                grdinv.Rows(i).Cells("overamount").Value = Nothing
                            End If
                            conn.Close()

                        ElseIf grdinv.Rows(i).Cells("shov").Value = "Over" Then
                            sql = "Select * from tblitems where itemcode='" & grdinv.Rows(i).Cells("itemcode").Value & "'"
                            conn.Open()
                            cmd = New SqlCommand(sql, conn)
                            dr = cmd.ExecuteReader
                            If dr.Read Then
                                grdinv.Rows(i).Cells("overamount").Value = Val(dr("price")) * Val(grdinv.Rows(i).Cells("variance").Value)
                                grdinv.Rows(i).Cells("shortamount").Value = Nothing
                            End If
                            conn.Close()
                        Else
                            grdinv.Rows(i).Cells("shortamount").Value = Nothing
                            grdinv.Rows(i).Cells("overamount").Value = Nothing
                        End If
                    Next
                End If
            End If
            Me.Cursor = Cursors.Default
        Catch ex As SqlException
            If ex.Number = -2 Then
                MessageBox.Show("Timeout Occurred", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information, "")
        End Try
    End Sub

    Public Sub saveahortoveramt()
        Try
            For Each row In grdinv.Rows
                If grdinv.Rows(row.index).Cells("shortamount").Value IsNot Nothing Then
                    sql = "Update tblinvitems set shortamt='" & grdinv.Rows(row.index).Cells("shortamount").Value & "' where invnum='" & lblinvid.Text & "' and itemcode='" & grdinv.Rows(row.index).Cells("itemcode").Value.ToString & "' AND area='" & manager & "'"
                ElseIf grdinv.Rows(row.index).Cells("overamount").Value IsNot Nothing Then
                    sql = "Update tblinvitems set overamt='" & grdinv.Rows(row.index).Cells("overamount").Value & "' where invnum='" & lblinvid.Text & "' and itemcode='" & grdinv.Rows(row.index).Cells("itemcode").Value.ToString & "' AND area='" & manager & "'"
                Else
                    sql = ""
                End If
                If sql <> "" Then
                    conn.Open()
                    cmd = New SqlCommand(sql, conn)
                    cmd.ExecuteNonQuery()
                    conn.Close()
                End If
            Next

            Me.Cursor = Cursors.Default
        Catch ex As SqlException
            If ex.Number = -2 Then
                MessageBox.Show("Timeout Occurred", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information, "")
        End Try
    End Sub
    Public Sub appayment(ByVal typee As String, ByVal cellName As String)
        Try
            Dim prce As Double = 0, areas As String = ""
            'If typee = "Cash" Or typee = "A.R Sales" Or login.wrkgrp = "Administrator" Or login.wrkgrp = "Production" Then
            '    areas = "Sales"
            'End If
            For index As Integer = 0 To grdinv.Rows.Count - 1
                conn.Open()
                cmd = New SqlCommand("SELECT ISNULL(sum(totalprice),0) from tbltransaction JOIN tblorder ON tbltransaction.transnum=tblorder.transnum WHERE tendertype='" & typee & "' AND tblorder.itemname='" & grdinv.Rows(index).Cells("itemname").Value & "' AND tbltransaction.area='" & manager & "';", conn)
                prce = cmd.ExecuteScalar()
                conn.Close()
                If prce = 0 Then
                    grdinv.Rows(index).Cells(cellName).Value = "0.00"
                Else
                    'If grdinv.Rows(index).Cells("ap_amt").Value <> "0.00" Then
                    '    grdinv.Rows(index).Cells(cellName).Value = prce - CDbl(grdinv.Rows(index).Cells("ap_amt").Value)
                    '    grdinv.Rows(index).Cells(cellName).Style.ForeColor = Color.Green
                    'Else
                    grdinv.Rows(index).Cells(cellName).Value = prce
                    grdinv.Rows(index).Cells(cellName).Style.ForeColor = Color.Green
                    'End If
                End If
                prce = 0
            Next
            compute_total()
        Catch ex As SqlException
            If ex.Number = -2 Then
                MessageBox.Show("Timeout Occurred", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Public Sub appayment2(ByVal typee As String, ByVal cellName As String)
        Try
            'If typee = "Cash" Or typee = "A.R Sales" Or login.wrkgrp = "Administrator" Or login.wrkgrp = "Production" Then
            '    areas = "Sales"
            'End If
            For index As Integer = 0 To grdinv.Rows.Count - 1


                'cmd = New SqlCommand("SELECT ISNULL(sum(totalprice),0) from tbltransaction JOIN tblorder ON tbltransaction.transnum=tblorder.transnum WHERE tendertype='" & typee & "' AND tblorder.itemname='" & grdinv.Rows(index).Cells("itemname").Value & "' AND tbltransaction.area='Administrator' AND tbltransaction.invnum='" & lblinvid.Text & "';", conn)
                'prce = cmd.ExecuteScalar()
                'If prce = 0 Then
                '    grdinv.Rows(index).Cells(cellName).Value = "0.00"
                'End If

                Dim x As String = ""
                If manager = "Production" Then
                    x = "Production"
                Else
                    x = "Sales"
                End If
                Dim price As Double = 0.0
                conn.Open()
                cmd = New SqlCommand("Select DISTINCT tblars2.amount  from tblars2 join tblars1 on tblars2.transnum= tblars1.transnum  WHERE tblars2.description='" & grdinv.Rows(index).Cells("itemname").Value & "' AND tblars1.type='" & typee & "' AND tblars1.invnum='" & lblinvid.Text & "' and tblars1.area='" & x & "';", conn)
                dr = cmd.ExecuteReader
                While dr.Read
                    price += CDbl(dr("amount"))
                End While
                conn.Close()

                If price = 0 Then
                    grdinv.Rows(index).Cells(cellName).Value = "0.00"
                Else
                    grdinv.Rows(index).Cells(cellName).Value = price.ToString("n2")
                    grdinv.Rows(index).Cells(cellName).Style.ForeColor = Color.Green
                End If
            Next
            compute_total()
        Catch ex As SqlException
            If ex.Number = -2 Then
                MessageBox.Show("Timeout Occurred", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Public Sub cash(ByVal typee As String, ByVal cellName As String)
        Try
            'If typee = "Cash" Or typee = "A.R Sales" Or login.wrkgrp = "Administrator" Or login.wrkgrp = "Production" Then
            '    areas = "Sales"
            'End If 
            Dim systemDate As String = getSystemDate.ToString("MM/dd/yyyy")
            For index As Integer = 0 To grdinv.Rows.Count - 1
                Dim totalprice As Double = 0.0
                conn.Open()
                cmd = New SqlCommand("SELECT ISNULL(SUM(tblorder.totalprice),0) FROM tblorder JOIN tbltransaction ON tblorder.transnum = tbltransaction.transnum where tblorder.invnum='" & lblinvid.Text & "' AND tblorder.itemname='" & grdinv.Rows(index).Cells("itemname").Value & "' AND tbltransaction.tendertype='" & typee & "' AND tbltransaction.status=1;", conn)
                totalprice = cmd.ExecuteScalar
                conn.Close()
                totalprice = Math.Abs(totalprice)

                If grdinv.Rows(index).Cells("ap_amt").Value <> "0.00" Then
                    grdinv.Rows(index).Cells(cellName).Value = totalprice
                    grdinv.Rows(index).Cells(cellName).Style.ForeColor = Color.Green
                Else
                    grdinv.Rows(index).Cells(cellName).Value = totalprice
                    grdinv.Rows(index).Cells(cellName).Style.ForeColor = Color.Green
                End If
                If totalprice = 0 Then
                    grdinv.Rows(index).Cells(cellName).Style.ForeColor = Color.Black
                End If
            Next
            compute_total()
        Catch ex As SqlException
            If ex.Number = -2 Then
                MessageBox.Show("Timeout Occurred", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Public Sub ctramt_aramt(ByVal ttype As String, ByVal cellName As String, ByVal typee As String)
        Try
            Dim chck As Boolean = False
            Dim tttnum As String = ""
            For index As Integer = 0 To grdinv.Rows.Count - 1
                conn.Open()
                cmd = New SqlCommand("SELECT transnum FROM tbltransaction WHERE invnum='" & lblinvid.Text & "' AND tendertype='" & ttype & "' AND refund='0';", conn)
                dr = cmd.ExecuteReader()
                If dr.Read Then
                    chck = True
                    tttnum = dr("transnum")
                End If
                conn.Close()
                If chck Then
                    conn.Open()
                    cmd = New SqlCommand("SELECT totalprice FROM tblorder WHERE invnum='" & lblinvid.Text & "' AND itemname='" & grdinv.Rows(index).Cells("itemname").Value & "' AND type='" & ttype & "' AND transnum='" & tttnum & "';", conn)
                    dr = cmd.ExecuteReader()
                    If dr.Read Then
                        grdinv.Rows(index).Cells(cellName).Value = dr("totalprice")
                        grdinv.Rows(index).Cells(cellName).Style.ForeColor = Color.Green
                    Else
                        grdinv.Rows(index).Cells(cellName).Value = "0.00"
                        grdinv.Rows(index).Cells(cellName).Style.ForeColor = Color.Black
                    End If
                    conn.Close()
                End If
            Next
        Catch ex As SqlException
            If ex.Number = -2 Then
                MessageBox.Show("Timeout Occurred", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        compute_total()
    End Sub
    Public Sub ctrout_(ByVal ttype As String, ByVal cellName As String)
        Try

            Dim transnumber As String = ""
            For index As Integer = 0 To grdinv.Rows.Count - 1
                Dim chck As Boolean = False
                Dim tttnum As String = ""
                If ttype = "Advance Payment" Then
                    conn.Open()
                    cmd = New SqlCommand("SELECT transnum FROM tblorder WHERE itemname='" & grdinv.Rows(index).Cells("itemname").Value & "';", conn)
                Else
                    conn.Open()
                    cmd = New SqlCommand("SELECT transnum FROM tblorder WHERE itemname='" & grdinv.Rows(index).Cells("itemname").Value & "' AND type='" & ttype & "';", conn)
                End If
                dr = cmd.ExecuteReader()
                If dr.Read Then
                    tttnum = dr("transnum")
                    chck = True
                Else
                    grdinv.Rows(index).Cells(cellName).Value = "0.00"
                End If
                conn.Close()
                If chck Then
                    conn.Open()
                    cmd = New SqlCommand("SELECT amtdue,tendertype FROM tbltransaction WHERE invnum='" & lblinvid.Text & "'AND tendertype='" & ttype & "' AND transnum='" & tttnum & "';", conn)
                    dr = cmd.ExecuteReader()
                    If dr.Read Then
                        grdinv.Rows(index).Cells(cellName).Value = CDbl(dr("amtdue")).ToString("n2")
                        grdinv.Rows(index).Cells(cellName).Style.ForeColor = Color.Green
                    Else
                        grdinv.Rows(index).Cells(cellName).Value = "0.00"
                    End If
                    conn.Close()
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        compute_total()
    End Sub
End Class