Imports System.IO
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Globalization

Public Class chargeform
    Dim strconn As String = login.ss
    Dim conn As SqlConnection
    Dim cmd As SqlCommand
    Dim dr As SqlDataReader
    Dim sql As String

    Public chcnf As Boolean = False
    Dim culture As CultureInfo = Nothing

    Public Function decryptConString() As String
        Dim base64encoded As String = File.ReadAllText("connectionstring.txt")
        Dim data As Byte() = System.Convert.FromBase64String(base64encoded)
        Return System.Text.ASCIIEncoding.ASCII.GetString(data)
    End Function

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

        If Trim(txttrans.Text) <> "" Then
            btnrefund.Text = "Ok"
        Else
            If lbltransnum.Text <> "" Then
                btnrefund.Text = "Charge to Employee"
            End If
        End If
    End Sub

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

                Dim zz As String = getSystemDate().ToString("MM/dd/yyyy")

                sql = "Select * from tbltransaction where transnum='" & Trim(txttrans.Text) & "'"
                connect()
                cmd = New SqlCommand(sql, conn)
                dr = cmd.ExecuteReader
                While dr.Read
                    tr = 1
                    If Format(dr("transdate"), "MM/dd/yyyy") = zz Then
                        da = 1
                        If dr("refund") = 1 Then
                            MsgBox("Refunded Transaction.", MsgBoxStyle.Information, "")
                            Me.Cursor = Cursors.Default
                            txttrans.Text = ""
                            txttrans.Focus()
                            Exit Sub
                        End If
                        If dr("remarks").ToString.Contains("Charge to Employee") Then
                            MsgBox("Transaction is already charged to employee.", MsgBoxStyle.Information, "")
                            Me.Cursor = Cursors.Default
                            txttrans.Text = ""
                            txttrans.Focus()
                            Exit Sub
                        End If
                    Else
                        If dr("refund") = 1 Then
                            MsgBox("Refunded Transaction.", MsgBoxStyle.Information, "")
                            Me.Cursor = Cursors.Default
                            txttrans.Text = ""
                            txttrans.Focus()
                            Exit Sub
                        End If
                        If dr("remarks").ToString.Contains("Charge to Employee") Then
                            MsgBox("Transaction is already charged to employee.", MsgBoxStyle.Information, "")
                            Me.Cursor = Cursors.Default
                            txttrans.Text = ""
                            txttrans.Focus()
                            Exit Sub
                        End If
                        Dim m As String = MsgBox("Do you want to charge transaction from previous days?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "")
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

                btnrefund.Text = "Charge to Employee"
                txttrans.Text = ""
                btnrefund.Focus()
            Else
                'charge to employee
                Dim a As String = MsgBox("Are you sure you want to charge transaction to employee?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "")
                If a = vbYes Then

                    chcnf = False
                    'input emp id and name client name din
                    charge.ShowDialog()
                    If lblidno.Text = "" Then
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If

                    confirm.ShowDialog()

                    If chcnf = True Then
                        Me.Cursor = Cursors.WaitCursor
                        Dim remms As String = ""

                        sql = "Select * from tbltransaction where transnum='" & Trim(lbltransnum.Text) & "'"
                        connect()
                        cmd = New SqlCommand(sql, conn)
                        dr = cmd.ExecuteReader
                        If dr.Read Then
                            remms = dr("remarks")
                        End If
                        dr.Dispose()
                        cmd.Dispose()

                        If remms = "" Then
                            remms = remms & "Charge to Employee"
                        Else
                            remms = remms & ", Charge to Employee"
                        End If

                        sql = "Update tbltransaction set remarks='" & remms & "' where transnum='" & Trim(lbltransnum.Text) & "'"
                        connect()
                        cmd = New SqlCommand(sql, conn)
                        cmd.ExecuteNonQuery()
                        cmd.Dispose()

                        sql = "Insert into tblcharge (transnum,empid,empname,customer,amt,datecreated,createdby,datemodified,modifiedby,status) values('" & Trim(lbltransnum.Text) & "','" & Trim(lblidno.Text) & "','" & Trim(lblname.Text) & "','" & Trim(lblclient.Text) & "','" & Trim(lbltotal.Text) & "',(SELECT GETDATE()),'" & login.cashier & "',(SELECT GETDATE()),'" & login.cashier & "','1')"
                        connect()
                        cmd = New SqlCommand(sql, conn)
                        cmd.ExecuteNonQuery()
                        cmd.Dispose()

                        MsgBox("Transaction Charged to Employee Successfully.", MsgBoxStyle.Information, "")
                        Me.Cursor = Cursors.Default

                        'print ng receipt

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
                        chcnf = False
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
                    chcnf = False
                End If
                lblidno.Text = ""
                lblname.Text = ""
                lblclient.Text = ""
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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information)
        Finally
            disconnect()
        End Try
    End Sub

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        lblidno.Text = ""
        lblname.Text = ""
        lblclient.Text = ""
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