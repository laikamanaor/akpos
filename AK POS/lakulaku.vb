Imports System.Data.SqlClient
Imports System.Text
Imports System.IO
Public Class lakulaku
    Dim strconn As String = login.ss
    Dim con As New SqlConnection(strconn)
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader

    Dim ar_number As String = "", inv_id As String = ""

    Public lcacc As String = ""
    Public Sub loadLakus()
        Try
            cmblaku.Items.Clear()
            con.Open()
            cmd = New SqlCommand("SELECT name FROM tblcustomers WHERE type='Laku' AND status=1 ORDER BY name ASC;", con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                cmblaku.Items.Add(rdr("name"))
            End While
            con.Close()
            cmblaku.SelectedIndex = 0
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Public Function decryptConString() As String
        Dim base64encoded As String = File.ReadAllText("connectionstring.txt")
        Dim data As Byte() = System.Convert.FromBase64String(base64encoded)
        Return System.Text.ASCIIEncoding.ASCII.GetString(data)
    End Function

    Public Sub loadPendings()
        Try
            dgvpendings.Rows.Clear()
            con.Open()
            cmd = New SqlCommand("SELECT * FROM tblakutrans WHERE status='Active' AND customer_id=(SELECT customer_id FROM tblcustomers WHERE name=@name AND status=1);", con)
            cmd.Parameters.AddWithValue("@name", cmblaku.Text)
            rdr = cmd.ExecuteReader
            While rdr.Read
                dgvpendings.Rows.Add(rdr("transnum"), rdr("totalqty"), CDbl(rdr("amt")).ToString("n2"), CDate(rdr("datecreated")).ToString("MM/dd/yyyy hh:mm tt"))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub lakulaku_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadLakus()
        loadPendings()
    End Sub
    Public Sub pendings_cellclick()
        Try
            If dgvpendings.RowCount <> 0 Then
                dgvitems.Rows.Clear()
                clear_paneledit()
                con.Open()
                cmd = New SqlCommand("SELECT itemcode,itemname,category,qty,sales_qty,returned_qty FROM tblakuitems WHERE transnum=@tnum;", con)
                cmd.Parameters.AddWithValue("@tnum", dgvpendings.CurrentRow.Cells("refnum").Value)
                rdr = cmd.ExecuteReader
                While rdr.Read
                    dgvitems.Rows.Add(rdr("itemcode"), rdr("itemname"), rdr("category"), rdr("qty"), rdr("sales_qty"), rdr("returned_qty"))
                End While
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Private Sub dgvpendings_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvpendings.CellClick
        pendings_cellclick()
    End Sub
    Public Sub clear_paneledit()
        paneledit.Visible = False
        txtsales.Text = "0"
        lblqty.Text = "0"
        lblreturn.Text = "0"
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

    Private Sub btnsubmit_Click(sender As Object, e As EventArgs) Handles btnsubmit.Click
        Try

            If dgvpendings.RowCount = 0 Then
                MessageBox.Show("No transaction selected", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            If dgvitems.RowCount = 0 Then
                MessageBox.Show("No items selected", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            getID()
            Dim errmsg As String = "Please input Sales or Returned Quantity in the Item below" & Environment.NewLine
            For index As Integer = 0 To dgvitems.RowCount - 1

                Dim qty As Double = 0.00, sales_qty As Double = 0.00, returned_qty As Double = 0.00

                con.Open()
                cmd = New SqlCommand("SELECT qty,sales_qty, returned_qty FROM tblakuitems WHERE transnum=@transnum AND itemcode=@itemcode AND itemname=@itemname AND category=@category;", con)
                cmd.Parameters.AddWithValue("@transnum", dgvpendings.CurrentRow.Cells("refnum").Value)
                cmd.Parameters.AddWithValue("@itemcode", dgvitems.Rows(index).Cells("itemcode").Value)
                cmd.Parameters.AddWithValue("@itemname", dgvitems.Rows(index).Cells("itemname").Value)
                cmd.Parameters.AddWithValue("@category", dgvitems.Rows(index).Cells("category").Value)
                rdr = cmd.ExecuteReader
                If rdr.Read Then
                    qty = CDbl(rdr("qty"))
                    sales_qty = CDbl(rdr("sales_qty"))
                    returned_qty = CDbl(rdr("returned_qty"))
                End If
                con.Close()

                If sales_qty = 0 And returned_qty = 0 Then
                    errmsg &= dgvitems.Rows(index).Cells("itemname").Value & Environment.NewLine
                End If
            Next

            If errmsg <> "Please input Sales or Returned Quantity in the Item below" & Environment.NewLine Then
                MessageBox.Show(errmsg, "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                loadtransnum()
                Dim sales As Double = 0.00
                For index As Integer = 0 To dgvitems.RowCount - 1
                    sales = CDbl(dgvitems.Rows(index).Cells("quantity_sales").Value)
                    Dim returned As Double = CDbl(dgvitems.Rows(index).Cells("quantity_returned").Value)

                    If sales <> 0 Then

                        Dim prce As Double = 0.00, amt As Double = 0.00
                        con.Open()
                        cmd = New SqlCommand("SELECT price FROM tblitems WHERE itemname=@iiname;", con)
                        cmd.Parameters.AddWithValue("@iiname", dgvitems.Rows(index).Cells("itemname").Value)
                        prce = cmd.ExecuteScalar()
                        con.Close()

                        amt = prce * CDbl(dgvitems.Rows(index).Cells("quantity").Value)

                        con.Open()
                        cmd = New SqlCommand("INSERT INTO tblars2 (transnum,description,quantity,price,amount,area,name) VALUES (@tnum, @des,@qua,@price,@am,@area,@n)", con)
                        cmd.Parameters.AddWithValue("@tnum", ar_number)
                        cmd.Parameters.AddWithValue("@des", CStr(dgvitems.Rows(index).Cells("itemname").Value))
                        cmd.Parameters.AddWithValue("@qua", CDbl(dgvitems.Rows(index).Cells("quantity_sales").Value))
                        cmd.Parameters.AddWithValue("@price", prce)
                        cmd.Parameters.AddWithValue("@am", amt)
                        cmd.Parameters.AddWithValue("@area", "Sales")
                        cmd.Parameters.AddWithValue("@n", cmblaku.Text)
                        cmd.ExecuteNonQuery()
                        con.Close()

                        con.Open()
                        cmd = New SqlCommand("Insert into tblorder (transnum, category, itemname, qty, price, totalprice, dscnt, free, request, status, discprice, disctrans,area,invnum,type)values(@znum,@zcategory,@zitemname,@zquantity,@zprice,@zamount,@dscnt,@free,@request,@status,@discprice,@disctrans,@area,@invnum,@type);", con)
                        cmd.Parameters.AddWithValue("@znum", ar_number)
                        cmd.Parameters.AddWithValue("@zcategory", dgvitems.Rows(index).Cells("category").Value)
                        cmd.Parameters.AddWithValue("@zitemname", dgvitems.Rows(index).Cells("itemname").Value)
                        cmd.Parameters.AddWithValue("@zquantity", dgvitems.Rows(index).Cells("quantity_sales").Value)
                        cmd.Parameters.AddWithValue("@zprice", prce)
                        cmd.Parameters.AddWithValue("@zamount", amt)
                        cmd.Parameters.AddWithValue("@dscnt", 0)
                        cmd.Parameters.AddWithValue("@free", 0)
                        cmd.Parameters.AddWithValue("@request", "")
                        cmd.Parameters.AddWithValue("@status", 1)
                        cmd.Parameters.AddWithValue("@discprice", 0)
                        cmd.Parameters.AddWithValue("@disctrans", 0)
                        cmd.Parameters.AddWithValue("@area", "Sales")
                        cmd.Parameters.AddWithValue("@invnum", inv_id)
                        cmd.Parameters.AddWithValue("@type", "A.R Sales")
                        cmd.ExecuteNonQuery()
                        con.Close()
                    End If

                    If returned <> 0 Then
                        Dim itemin As Double = 0.00, totalav As Double = 0.00, endbal As Double = 0.00, actualendbal As Double = 0.00, variance As Double = 0.00, so As String = ""
                        con.Open()
                        cmd = New SqlCommand("SELECT itemin,totalav,endbal,actualendbal FROM tblinvitems WHERE invnum=@invnum AND itemcode=@itemcode AND itemname=@itemname;", con)
                        cmd.Parameters.AddWithValue("@itemcode", dgvitems.Rows(index).Cells("itemcode").Value)
                        cmd.Parameters.AddWithValue("@itemname", dgvitems.Rows(index).Cells("itemname").Value)
                        cmd.Parameters.AddWithValue("@invnum", inv_id)
                        rdr = cmd.ExecuteReader
                        If rdr.Read Then
                            itemin = CDbl(rdr("itemin")) + returned
                            totalav = CDbl(rdr("totalav")) + returned
                            endbal = CDbl(rdr("endbal")) + returned
                            actualendbal = CDbl(rdr("actualendbal"))
                        End If
                        con.Close()
                        variance = actualendbal - endbal
                        If variance < 0 Then
                            so = "Short"
                        Else
                            so = "Over"
                        End If

                        con.Open()
                        cmd = New SqlCommand("UPDATE tblinvitems SET itemin=@itemin,totalav=@totalav,endbal=@endbal,variance=@variance,shortover=@so WHERE invnum=@invnum AND itemcode=@itemc AND itemname=@itemn;", con)
                        cmd.Parameters.AddWithValue("@itemin", itemin)
                        cmd.Parameters.AddWithValue("@totalav", totalav)
                        cmd.Parameters.AddWithValue("@endbal", endbal)
                        cmd.Parameters.AddWithValue("@variance", variance)
                        cmd.Parameters.AddWithValue("@so", so)
                        cmd.Parameters.AddWithValue("@invnum", inv_id)
                        cmd.Parameters.AddWithValue("@itemc", dgvitems.Rows(index).Cells("itemcode").Value)
                        cmd.Parameters.AddWithValue("@itemn", dgvitems.Rows(index).Cells("itemname").Value)
                        cmd.ExecuteNonQuery()
                        con.Close()
                    End If
                Next
                If sales <> 0 Then
                    con.Open()
                    cmd = New SqlCommand("INSERT INTO tblars1 (arnum,transnum,amountdue,name,status,date_created,created_by,area,invnum,type,balance,typenum,sap_no,remarks,_from) VALUES (@arnum,@transnum, @amountdue, @name, @status,(SELECT GETDATE()), @createdby,@area,@invnum,@taypp,@balance,@typenum,@sap_no,@remarks,@_from)", con)
                    cmd.Parameters.AddWithValue("@arnum", ar_number)
                    cmd.Parameters.AddWithValue("@transnum", ar_number)
                    cmd.Parameters.AddWithValue("@amountdue", CDbl(dgvpendings.CurrentRow.Cells("amount").Value))
                    cmd.Parameters.AddWithValue("@name", cmblaku.Text)
                    cmd.Parameters.AddWithValue("@status", "Paid")
                    cmd.Parameters.AddWithValue("@createdby", login.username)
                    cmd.Parameters.AddWithValue("@area", "Sales")
                    cmd.Parameters.AddWithValue("@invnum", inv_id)
                    cmd.Parameters.AddWithValue("@taypp", "AR Sales")
                    cmd.Parameters.AddWithValue("@balance", CDbl(dgvpendings.CurrentRow.Cells("amount").Value))
                    cmd.Parameters.AddWithValue("@typenum", "AR")
                    cmd.Parameters.AddWithValue("@sap_no", "To Follow")
                    cmd.Parameters.AddWithValue("@remarks", "")
                    cmd.Parameters.AddWithValue("@_from", "Laku")
                    cmd.ExecuteNonQuery()
                    con.Close()

                    Dim zz As String = getSystemDate.ToString("MM/dd/yyyy")

                    con.Open()
                    cmd = New SqlCommand("Insert into tbltransaction (ornum, transnum, transdate, cashier, tendertype, servicetype, delcharge, subtotal, disctype, less, vatsales, vat, amtdue, gctotal, tenderamt, change, refund, comment, remarks, customer, tinnum, tablenum, pax, datecreated, datemodified, status,area,invnum,partialamt) values ('0', '" & ar_number & "', '" & zz & "','" & login.cashier & "','A.R Sales','N/A','0', '" & CDbl(dgvpendings.CurrentRow.Cells("amount").Value) & "', 'N/A', '0', '0', '0', '" & CDbl(dgvpendings.CurrentRow.Cells("amount").Value) & "', '0', '0', '0', '0', '', '','" & cmblaku.Text & "' , 'N/A', '0','1',(SELECT GETDATE()),(SELECT GETDATE()), '1','" & "Sales" & "','" & inv_id & "','0')", con)
                    cmd.ExecuteNonQuery()
                    con.Close()

                End If

                con.Open()
                cmd = New SqlCommand("UPDATE tblakutrans SET status='In Active' WHERE transnum=@tnum;", con)
                cmd.Parameters.AddWithValue("@tnum", dgvpendings.CurrentRow.Cells("refnum").Value)
                cmd.ExecuteNonQuery()
                con.Close()

                MessageBox.Show("Transaction Completed", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Information)
                loadPendings()
                dgvitems.Rows.Clear()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Public Sub getID()
        Try
            Dim id As String = ""
            Dim date_ As New DateTime()
            con.Open()
            cmd = New SqlCommand("Select TOP 1 invnum,datecreated from tblinvsum WHERE area='" & lcacc & "' order by invsumid DESC", con)
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
            con.Close()
        End Try
    End Sub

    Public Sub loadtransnum()
        Try
            Dim area As String = ""
            If lcacc = "Cashier" Or lcacc = "Sales" Then
                area = "Sales"
            Else
                area = lcacc
            End If
            Dim selectcount_result As Integer = 0
            Dim branchcode As String = "", temp As String = "1", area_format As String = ""
            con.Open()
            cmd = New SqlCommand("Select DISTINCT transnum  FROM tbltransaction WHERE area='" & area & "';", con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                selectcount_result += 1
            End While
            selectcount_result += 1

            cmd = New SqlCommand("Select branchcode FROM tblbranch WHERE main='1';", con)
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                branchcode = rdr("branchcode")
            End If
            area_format = "TR - " & branchcode & " - "
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
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub dgvitems_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvitems.CellContentClick
        If e.ColumnIndex = 6 Then
            clear_paneledit()
            paneledit.Visible = True
            lblqty.Text = dgvitems.CurrentRow.Cells("quantity").Value
        End If
    End Sub

    Private Sub btnok_Click(sender As Object, e As EventArgs) Handles btnok.Click
        Try

            If String.IsNullOrEmpty(txtsales.Text) Then
                MessageBox.Show("Please input sales quantity", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim qty As Double = CDbl(lblqty.Text)
            Dim sales_quantity As Double = CDbl(txtsales.Text)
            Dim returned_quantity As Double = CDbl(lblreturn.Text)
            con.Open()
            cmd = New SqlCommand("UPDATE tblakuitems SET sales_qty=@sales, returned_qty=@returned WHERE transnum=@transnum AND itemcode=@itemcode AND itemname=@itemname AND category=@category;", con)
            cmd.Parameters.AddWithValue("@sales", sales_quantity)
            cmd.Parameters.AddWithValue("@returned", returned_quantity)
            cmd.Parameters.AddWithValue("@transnum", dgvpendings.CurrentRow.Cells("refnum").Value)
            cmd.Parameters.AddWithValue("@itemcode", dgvitems.CurrentRow.Cells("itemcode").Value)
            cmd.Parameters.AddWithValue("@itemname", dgvitems.CurrentRow.Cells("itemname").Value)
            cmd.Parameters.AddWithValue("@category", dgvitems.CurrentRow.Cells("category").Value)
            cmd.ExecuteNonQuery()
            con.Close()
            pendings_cellclick()
            clear_paneledit()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub cmblaku_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmblaku.SelectedIndexChanged
        loadPendings()
        clear_paneledit()
    End Sub


    Private Sub txtsales_TextChanged(sender As Object, e As EventArgs) Handles txtsales.TextChanged
        Try
            If CDbl(txtsales.Text) <= CDbl(lblqty.Text) Then
                lblreturn.Text = (CDbl(lblqty.Text) - CDbl(txtsales.Text))
            Else
                txtsales.Text = lblqty.Text
                lblreturn.Text = "0"
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class