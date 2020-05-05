Imports System.IO
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Globalization

Public Class refundform
    Dim strconn As String = login.ss
    Dim conn As SqlConnection
    Dim cmd As SqlCommand
    Dim dr As SqlDataReader
    Dim sql As String

    Public ref As Boolean = False
    Dim culture As CultureInfo = Nothing

    Public Function decryptConString() As String
        Dim base64encoded As String = File.ReadAllText("connectionstring.txt")
        Dim data As Byte() = System.Convert.FromBase64String(base64encoded)
        Return System.Text.ASCIIEncoding.ASCII.GetString(data)
    End Function

    Public Sub connect()
        conn = New SqlConnection
        conn.ConnectionString = strconn
        If conn.State <> ConnectionState.Open Then
            conn.Open()
        End If
    End Sub

    Public Sub disconnect()
        conn = New SqlConnection
        conn.ConnectionString = strconn
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
    End Sub

    Private Sub refundform_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub refundform_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        btnrefund.Text = "Ok"
        lbltransnum.Text = ""
        lblcashier.Text = ""
        lbldate.Text = ""
        lblsub.Text = "0.00"
        lbldisc.Text = "None"
        lblless.Text = "0.00"
        lbldel.Text = "0.00"
        lblvatamt.Text = "0.00"
        lblvatsales.Text = "0.00"
        lbltotal.Text = "0.00"
        lblexempt.Text = "0.00"
        txttrans.Text = ""
        grdorders.Rows.Clear()
        txttrans.Focus()
    End Sub

    Private Sub refundform_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txttrans.Focus()
    End Sub

    Private Sub txttrans_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttrans.KeyPress
        If Asc(e.KeyChar) = Windows.Forms.Keys.Enter And Trim(txttrans.Text) <> "" Then
            btnrefund.PerformClick()
        End If
    End Sub

    Private Sub txttrans_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttrans.TextChanged
        'Dim charactersDisallowed As String = "0123456789-"
        'Dim theText As String = txttrans.Text
        'Dim Letter As String
        'Dim SelectionIndex As Integer = txttrans.SelectionStart
        'Dim Change As Integer

        'For x As Integer = 0 To txttrans.Text.Length - 1
        '    Letter = txttrans.Text.Substring(x, 1)
        '    If Not charactersDisallowed.Contains(Letter) Then
        '        theText = theText.Replace(Letter, String.Empty)
        '        Change = 1
        '    End If
        'Next

        'txttrans.Text = theText
        'txttrans.Select(SelectionIndex - Change, 0)

        'If Trim(txttrans.Text) <> "" Then
        '    btnrefund.Text = "Ok"
        'Else
        '    If lbltransnum.Text <> "" Then
        '        btnrefund.Text = "Refund"
        '    End If
        'End If
    End Sub
    Public Function getSystemDate() As DateTime
        Try
            Dim dt As New DateTime()
            connect()
            cmd = New SqlCommand("SELECT GETDATE()", conn)
            dr = cmd.ExecuteReader()
            While dr.Read
                dt = CDate(dr(0).ToString)
            End While
            disconnect()
            Return dt
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            disconnect()
        End Try
    End Function
    Private Sub btnrefund_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrefund.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            If btnrefund.Text = "Ok" Then
                If Trim(txttrans.Text) = "" Then
                    MsgBox("Input transaction number.", MsgBoxStyle.Exclamation, "")
                    txttrans.Focus()
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If


                Dim tr As Integer = 0, re As Integer = 0, da As Integer = 0

                sql = "Select * from tbltransaction where transnum='" & txttrans.Text & "'"
                connect()
                cmd = New SqlCommand(sql, conn)
                dr = cmd.ExecuteReader
                While dr.Read
                    tr = 1
                    If Format(dr("transdate"), "MM/dd/yyyy") = getSystemDate.ToString("MM/dd/yyyy") Then
                        da = 1
                        If CInt(dr("refund")) = 1 Then
                            MsgBox("Transactiion is already refunded.", MsgBoxStyle.Information, "")
                            Me.Cursor = Cursors.Default
                            txttrans.Text = ""
                            txttrans.Focus()
                            Exit Sub
                        End If
                    Else
                        If dr("refund") = 1 Then
                            MsgBox("Transactiion is already refunded.", MsgBoxStyle.Information, "")
                            Me.Cursor = Cursors.Default
                            txttrans.Text = ""
                            txttrans.Focus()
                            Exit Sub
                        End If
                        Dim m As String = MsgBox("Do you want to refund transaction from previous days?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "")
                        If m <> vbYes Then
                            Me.Cursor = Cursors.Default
                            txttrans.Text = ""
                            txttrans.Focus()
                            Exit Sub
                        End If
                    End If
                End While
                dr.Dispose()
                cmd.Dispose()

                If tr = 0 Then
                    MsgBox("Invalid transaction #.", MsgBoxStyle.Critical, "")
                    Me.Cursor = Cursors.Default
                    txttrans.Text = ""
                    txttrans.Focus()
                    Exit Sub
                End If


                'if ok lahat then load the transaction information in grdorder

                Dim i As Integer = 0
                'grd.Rows.Clear()
                grdorders.Rows.Clear()

                sql = "Select * from tbltransaction where transnum='" & Trim(txttrans.Text) & "'"
                connect()
                cmd = New SqlCommand(sql, conn)
                dr = cmd.ExecuteReader
                If dr.Read Then
                    Me.Cursor = Cursors.WaitCursor
                    lbltransnum.Text = dr("transnum")
                    lblcashier.Text = dr("cashier")
                    lbldate.Text = Format(dr("datecreated"), "HH:mm   MM/dd/yyyy")
                    lblsub.Text = Val(dr("subtotal")).ToString("n2")
                    lbldel.Text = Val(dr("delcharge")).ToString("n2")
                    lbldisc.Text = dr("disctype")
                    lblless.Text = Val(dr("less")).ToString("n2")
                    lblvatsales.Text = Val(dr("vatsales")).ToString("n2")
                    lblvatamt.Text = Val(dr("vat")).ToString("n2")
                    lbltotal.Text = Val(dr("amtdue")).ToString("n2")
                    lblrems.Text = dr("remarks") & dr("comment")
                    lblrems.Tag = dr("remarks")
                End If
                dr.Dispose()
                cmd.Dispose()

                If lbldisc.Text.ToString.Contains("Senior") Or lbldisc.Text.ToString.Contains("Pwd") Then
                    culture = CultureInfo.CreateSpecificCulture("en-US")
                    Dim subttal As Double = Double.Parse(lblsub.Text, culture)

                    If lblrems.Tag.Contains("W/ GRPM") Then
                        'get the vinclude first equals subtotal minus based
                        'get the not disc amt in based equals based/1.12 * .8
                        'then amount due equals add the vinclude and the 80% of the based
                        Dim vatamt As Double = Double.Parse(lblvatamt.Text, culture)
                        Dim vatsales As Double = Double.Parse(lblvatsales.Text, culture)
                        Dim total As Double = Double.Parse(lblsub.Text, culture)
                        Dim vinclude As Double = total - (vatamt + vatsales)
                        lblexempt.Text = Val((vatamt + vatsales) / 1.12).ToString("n2")
                        lblvatsales.Text = Val(vinclude / 1.12).ToString("n2")
                        lblvatamt.Text = Val(vinclude - (vinclude / 1.12)).ToString("n2")
                    Else
                        lblexempt.Text = Val(subttal / 1.12).ToString("n2")
                        lblvatamt.Text = "0.00"
                        lblvatsales.Text = "0.00"
                    End If
                Else
                    lblexempt.Text = "0.00"
                End If

                Me.Cursor = Cursors.Default

                sql = "Select * from tblorder where transnum='" & Trim(txttrans.Text) & "'"
                connect()
                cmd = New SqlCommand(sql, conn)
                dr = cmd.ExecuteReader
                While dr.Read
                    Me.Cursor = Cursors.WaitCursor
                    grdorders.Rows.Add()
                    grdorders.Item(0, i).Value = dr("itemname")
                    grdorders.Item(1, i).Value = dr("qty")
                    grdorders.Item(2, i).Value = dr("price")
                    grdorders.Item(3, i).Value = dr("dscnt")
                    grdorders.Item(4, i).Value = dr("totalprice")
                    grdorders.Item(5, i).Value = dr("request")
                    Dim checkCell As DataGridViewCheckBoxCell = CType(grdorders.Rows(i).Cells(6), DataGridViewCheckBoxCell)
                    If dr("free") <> 0 Then
                        checkCell.Value = True
                    Else
                        checkCell.Value = False
                    End If
                    i += 1
                End While
                dr.Dispose()
                cmd.Dispose()

                Me.Cursor = Cursors.Default

                'If grdorders.Rows.Count = 0 Then
                'lbltransnum.Text = ""
                'lblcashier.Text = ""
                'lbldate.Text = ""
                'lblsub.Text = "0.00"
                'lbldisc.Text = "None"
                'lblless.Text = "0.00"
                'lbldel.Text = "0.00"
                'lblvatamt.Text = "0.00"
                'lblvatsales.Text = "0.00"
                'lbltotal.Text = "0.00"
                'txttrans.Text = ""
                'Me.Cursor = Cursors.Default
                'Exit Sub
                'End If


                btnrefund.Text = "Refund"
                txttrans.Text = ""
                btnrefund.Focus()
            Else
                If grdorders.Rows.Count <> 0 Then 'chkprev = True And
                    'check first if theres a discontinued items
                    Dim invnum As String = ""
                    sql = "Select TOP 1 * from tblinvsum order by invsumid DESc"
                    connect()
                    cmd = New SqlCommand(sql, conn)
                    dr = cmd.ExecuteReader
                    If dr.Read Then
                        invnum = dr("invnum")
                    End If
                    dr.Dispose()
                    cmd.Dispose()

                    connect()
                    For Each row As DataGridViewRow In grdorders.Rows
                        sql = "Select * from tblitems where itemname='" & grdorders.Rows(row.Index).Cells(0).Value & "' and discontinued='1'"
                        cmd = New SqlCommand(sql, conn)
                        dr = cmd.ExecuteReader
                        If dr.Read Then
                            MsgBox("Cannot refund transaction. Item " & grdorders.Rows(row.Index).Cells(0).Value & " was discontinued.", MsgBoxStyle.Critical, "")
                            Me.Cursor = Cursors.Default
                            Exit Sub
                        End If
                        dr.Dispose()
                        cmd.Dispose()


                        sql = "Select * from tblinvitems where invnum='" & invnum & "' and itemname='" & grdorders.Rows(row.Index).Cells(0).Value & "'"
                        cmd = New SqlCommand(sql, conn)
                        dr = cmd.ExecuteReader
                        If dr.Read Then
                            'proceed to refund
                        Else
                            MsgBox("Cannot refund transaction. Item " & grdorders.Rows(row.Index).Cells(0).Value & " is not in the list of the latest inventory.", MsgBoxStyle.Critical, "")
                            Me.Cursor = Cursors.Default
                            Exit Sub
                        End If
                        dr.Dispose()
                        cmd.Dispose()
                    Next
                End If

                Dim a As String = MsgBox("Are you sure you want to refund transaction?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "")
                If a = vbYes Then

                    Dim checkinv As Integer
                    ref = False
                    'check if transaction is today /////////////

                    confirm.ShowDialog()

                    If ref = True Then
                        Me.Cursor = Cursors.WaitCursor

                        sql = "Update tblgctrans set status='0' where transnum='" & Trim(lbltransnum.Text) & "'"
                        connect()
                        cmd = New SqlCommand(sql, conn)
                        cmd.ExecuteNonQuery()
                        cmd.Dispose()

                        sql = "Update tbltransaction set refund='1' where transnum='" & Trim(lbltransnum.Text) & "'"
                        connect()
                        cmd = New SqlCommand(sql, conn)
                        cmd.ExecuteNonQuery()
                        cmd.Dispose()

                        sql = "Select * from tblorder where transnum='" & Trim(lbltransnum.Text) & "'"
                        connect()
                        cmd = New SqlCommand(sql, conn)
                        dr = cmd.ExecuteReader
                        While dr.Read
                            'MsgBox(dr("itemname") & " " & dr("qty"))
                            'lahat ng qty - i subtract nmn sa counter out
                            'update inventory stocks
                            Dim lastinvid As String = ""
                            Dim lastin As Integer, lasttotal As Integer, lastout As Integer, lastactual As Integer, lasttotalout As Integer, lastpull As Integer, lastend As Integer
                            sql = "Select TOP 1 * from tblinvitems where itemname='" & dr("itemname") & "' order by invid DESC"
                            connect()
                            Dim cmd1 As SqlCommand = New SqlCommand(sql, conn)
                            Dim dr1 As SqlDataReader = cmd1.ExecuteReader
                            If dr1.Read Then
                                lastin = dr1("itemin")
                                lasttotal = dr1("begbal") + dr1("itemin")
                                lastout = dr1("ctrout")
                                lasttotalout = dr1("ctrout") + dr1("pullout")
                                lastactual = dr1("actualendbal")
                                lastpull = dr1("pullout")
                                lastend = dr1("endbal")
                                lastinvid = dr1("invnum")

                            End If
                            dr1.Dispose()
                            cmd1.Dispose()

                            'Dim uin As Double = dr("qty") + lastin
                            'Dim utotal As Double = dr("qty") + lasttotal
                            Dim uctr As Double = lastout - dr("qty")
                            'Dim uend As Double = lasttotal - ((lastout - dr("qty")) + lastpull)
                            Dim uend As Double = lastend + dr("qty")
                            Dim uvar As Double = lastactual - uend
                            Dim urems As String = ""
                            If uvar < 0 Then
                                urems = "Short"
                            ElseIf uvar > 0 Then
                                urems = "Over"
                            End If

                            checkinv = uend

                            sql = "Update tblinvitems set ctrout='" & uctr & "', endbal='" & uend & "', variance='" & uvar & "', shortover='" & urems & "' where itemname='" & dr("itemname") & "' and invnum='" & lastinvid & "'"
                            connect()
                            cmd1 = New SqlCommand(sql, conn)
                            cmd1.ExecuteNonQuery()
                            cmd1.Dispose()


                            If checkinv > 0 Then
                                sql = "Update tblitems set status='1' where itemname='" & dr("itemname") & "'"
                                connect()
                                cmd1 = New SqlCommand(sql, conn)
                                cmd1.ExecuteNonQuery()
                                cmd1.Dispose()
                            End If
                        End While
                        dr.Dispose()
                        cmd.Dispose()


                        MsgBox("Refund Transaction Successfully.", MsgBoxStyle.Information, "")
                        Me.Cursor = Cursors.Default

                        Dim ab As String = MsgBox("Do you want to print receipt?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "")
                        If ab = vbYes Then
                            'check muna if may tblorder sya
                            sql = "Select transnum from tblorder where transnum='" & Trim(lbltransnum.Text) & "'"
                            connect()
                            cmd = New SqlCommand(sql, conn)
                            dr = cmd.ExecuteReader
                            If dr.Read Then
                                reprintnew.sngle = True
                                reprintnew.condition = " where transnum='" & Trim(lbltransnum.Text) & "'"
                                reprintnew.ShowDialog()
                            Else
                                reprintinvalid.sngle = True
                                reprintinvalid.condition = " where transnum='" & Trim(lbltransnum.Text) & "'"
                                reprintinvalid.ShowDialog()
                            End If
                            dr.Dispose()
                            cmd.Dispose()

                        End If

                        txttrans.Text = ""
                        ref = False
                        btnrefund.Text = "Ok"
                        lbltransnum.Text = ""
                        lblcashier.Text = ""
                        lbldate.Text = ""
                        lblsub.Text = "0.00"
                        lbldisc.Text = "None"
                        lblless.Text = "0.00"
                        lbldel.Text = "0.00"
                        lblvatamt.Text = "0.00"
                        lblvatsales.Text = "0.00"
                        lbltotal.Text = "0.00"
                        txttrans.Text = ""
                        grdorders.Rows.Clear()

                        mainmenu.ref()

                        Me.Close()
                    End If
                    ref = False
                End If
                btnrefund.Text = "Ok"
                lbltransnum.Text = ""
                lblcashier.Text = ""
                lbldate.Text = ""
                lblsub.Text = "0.00"
                lbldisc.Text = "None"
                lblless.Text = "0.00"
                lbldel.Text = "0.00"
                lblvatamt.Text = "0.00"
                lblvatsales.Text = "0.00"
                lbltotal.Text = "0.00"
                txttrans.Text = ""
                grdorders.Rows.Clear()
                txttrans.Focus()
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
            Me.Cursor = Cursors.Default
        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information)
        Finally
            disconnect()
        End Try
    End Sub

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        btnrefund.Text = "Ok"
        lbltransnum.Text = ""
        lblcashier.Text = ""
        lbldate.Text = ""
        lblsub.Text = "0.00"
        lbldisc.Text = "None"
        lblless.Text = "0.00"
        lbldel.Text = "0.00"
        lblvatamt.Text = "0.00"
        lblvatsales.Text = "0.00"
        lbltotal.Text = "0.00"
        lblexempt.Text = "0.00"
        txttrans.Text = ""
        grdorders.Rows.Clear()
        txttrans.Focus()
        Me.Close()
    End Sub
End Class