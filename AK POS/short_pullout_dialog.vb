Imports System.Data.SqlClient
Imports AK_POS.connection_class
Public Class short_pullout_dialog
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    Dim cc As New connection_class
    Dim strconn As String = cc.conString
    Dim con As New SqlConnection(strconn)
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader
    Public datecreated As String=""
    Private Sub lblclose_Click(sender As Object, e As EventArgs) Handles lblclose.Click
        Me.Close()
    End Sub

    Private Sub short_pullout_dialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtquantity.Focus()
        cmbtransferto.Items.Clear()
        Dim auto As New AutoCompleteStringCollection()
        con.Open()
        cmd = New SqlCommand("SELECT branchcode FROM tblbranch WHERE main=0 ORDER BY branchcode ASC", con)
        rdr = cmd.ExecuteReader()
        While rdr.Read
            cmbtransferto.Items.Add(rdr("branchcode"))
            auto.Add(rdr("branchcode"))
        End While
        con.Close()
        cmbtransferto.AutoCompleteCustomSource = auto
        cmbtransferto.SelectedIndex = 0
    End Sub

    Private Sub Panel2_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel2.MouseDown, MyBase.MouseDown, lblitemname.MouseDown, Label3.MouseDown, Label2.MouseDown, Label1.MouseDown
        drag = True 'Sets the variable drag to true.
        mousex = Windows.Forms.Cursor.Position.X - Me.Left 'Sets variable mousex
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top 'Sets variable mousey
    End Sub

    Private Sub Panel2_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel2.MouseMove, MyBase.MouseMove, lblitemname.MouseMove, Label3.MouseMove, Label2.MouseMove, Label1.MouseMove
        'If drag is set to true then move the form accordingly.
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub Panel2_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel2.MouseUp, MyBase.MouseUp, lblitemname.MouseUp, Label3.MouseUp, Label2.MouseUp, Label1.MouseUp
        drag = False 'Sets drag to false, so the form does not move according to the code in MouseMove
    End Sub

    Private Sub short_pullout_dialog_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub btnsubmit_Click(sender As Object, e As EventArgs) Handles btnsubmit.Click
        If String.IsNullOrEmpty(txtquantity.Text) Then
            MessageBox.Show("Quantity field is required", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtquantity.Focus()
        ElseIf CDbl(txtquantity.Text) > CDbl(lblquantity.Text) Then
            MessageBox.Show("Maximum quantity is " & lblquantity.Text, "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtquantity.Focus()
        ElseIf String.IsNullOrEmpty(cmbtransferto.Text) Then
            MessageBox.Show("Branch field is required", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbtransferto.Focus()
        ElseIf checkBranch() Then
            MessageBox.Show("Branch not found", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbtransferto.Focus()
        ElseIf String.IsNullOrEmpty(txtsap.Text) And check.Checked = False Then
            MessageBox.Show("SAP # field is required", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtsap.Focus()
        Else
            If CDbl(lblquantity.Text) = CDbl(txtquantity.Text) Then
                Dim ars1_transnum As String = "", ars2_price As Double = 0.00, ars_quantity As Double = 0.00
                con.Open()
                cmd = New SqlCommand("SELECT a.transnum,b.price,b.quantity FROM tblars1 a INNER JOIN tblars2 b ON a.transnum = b.transnum WHERE b.description=@itemname AND a.name='Short' AND a.invnum=(SELECT invnum FROM tblinvsum WHERE CAST(datecreated AS date)='" & datecreated & "')", con)
                cmd.Parameters.AddWithValue("@itemname", lblitemname.Text)
                rdr = cmd.ExecuteReader
                If rdr.Read Then
                    ars1_transnum = rdr("transnum")
                    ars_quantity = rdr("quantity")
                    ars2_price = rdr("price")
                End If
                con.Close()
                Dim remaining_amtdue As Double = ars_quantity * ars2_price

                con.Open()
                cmd = New SqlCommand("DELETE FROM tblproduction WHERE Type ='Actual Ending Balance' AND inv_id=(SELECT invnum FROM tblinvsum WHERE CAST(datecreated AS date)='" & datecreated & "') AND item_name=@itemname", con)
                cmd.Parameters.AddWithValue("@itemname", lblitemname.Text)
                cmd.ExecuteNonQuery()
                con.Close()

                con.Open()
                cmd = New SqlCommand("UPDATE tblars1 SET amountdue-=@amtdue WHERE transnum=@transnum AND name='Short';", con)
                cmd.Parameters.AddWithValue("@amtdue", remaining_amtdue)
                cmd.Parameters.AddWithValue("@transnum", ars1_transnum)
                cmd.ExecuteNonQuery()
                con.Close()

                con.Open()
                cmd = New SqlCommand("UPDATE tbltransaction SET amtdue-=@amtdue WHERE transnum=@transnum AND customer='Short';", con)
                cmd.Parameters.AddWithValue("@amtdue", remaining_amtdue)
                cmd.Parameters.AddWithValue("@transnum", ars1_transnum)
                cmd.ExecuteNonQuery()
                con.Close()

                con.Open()
                cmd = New SqlCommand("UPDATE tbltransaction2 SET amtdue-=@amtdue WHERE transnum=@transnum AND customer='Short';", con)
                cmd.Parameters.AddWithValue("@amtdue", remaining_amtdue)
                cmd.Parameters.AddWithValue("@transnum", ars1_transnum)
                cmd.ExecuteNonQuery()
                con.Close()

                Dim orderid As Integer = 0
                con.Open()
                cmd = New SqlCommand("SELECT ordernum FROM tbltransaction2 WHERE transnum=@transnum AND customer='Short';", con)
                cmd.Parameters.AddWithValue("@transnum", ars1_transnum)
                rdr = cmd.ExecuteReader
                If rdr.Read Then
                    orderid = CInt(rdr("ordernum"))
                End If
                con.Close()

                Dim checkAmountDue As Boolean = False
                con.Open()
                cmd = New SqlCommand("SELECT transnum FROM tblars1 WHERE amountdue !=0 AND transnum=@transnum AND name='Short';", con)
                cmd.Parameters.AddWithValue("@transnum", ars1_transnum)
                rdr = cmd.ExecuteReader
                If rdr.Read Then
                    checkAmountDue = True
                End If
                con.Close()

                If checkAmountDue = False Then
                    con.Open()
                    cmd = New SqlCommand("DELETE FROM tblars1 WHERE transnum=@transnum AND name='Short';", con)
                    cmd.Parameters.AddWithValue("@transnum", ars1_transnum)
                    cmd.ExecuteNonQuery()
                    con.Close()

                    con.Open()
                    cmd = New SqlCommand("DELETE FROM tbltransaction WHERE transnum=@transnum AND customer='Short';", con)
                    cmd.Parameters.AddWithValue("@transnum", ars1_transnum)
                    cmd.ExecuteNonQuery()
                    con.Close()

                    con.Open()
                    cmd = New SqlCommand("DELETE FROM tbltransaction2 WHERE transnum=@transnum AND customer='Short';", con)
                    cmd.Parameters.AddWithValue("@transnum", ars1_transnum)
                    cmd.ExecuteNonQuery()
                    con.Close()
                End If

                con.Open()
                cmd = New SqlCommand("DELETE FROM tblars2 WHERE transnum=@transnum AND description=@itemname AND name='Short';", con)
                cmd.Parameters.AddWithValue("@transnum", ars1_transnum)
                cmd.Parameters.AddWithValue("@itemname", lblitemname.Text)
                cmd.ExecuteNonQuery()
                con.Close()

                con.Open()
                cmd = New SqlCommand("DELETE FROM tblorder WHERE transnum=@transnum AND itemname=@itemname;", con)
                cmd.Parameters.AddWithValue("@transnum", ars1_transnum)
                cmd.Parameters.AddWithValue("@itemname", lblitemname.Text)
                cmd.ExecuteNonQuery()
                con.Close()

                con.Open()
                cmd = New SqlCommand("DELETE FROM tblorder2 WHERE CAST(datecreated AS date)='" & datecreated & "' AND ordernum=@id  AND itemname=@itemname;", con)
                cmd.Parameters.AddWithValue("@transnum", ars1_transnum)
                cmd.Parameters.AddWithValue("@id", orderid)
                cmd.Parameters.AddWithValue("@itemname", lblitemname.Text)
                cmd.ExecuteNonQuery()
                con.Close()

                con.Open()
                cmd = New SqlCommand("UPDATE tblinvitems SET archarge-=@qty,transfer+=@qty WHERE itemname=@itemname AND invnum=(SELECT invnum FROM tblinvsum WHERE CAST(datecreated AS date)='" & datecreated & "');", con)
                cmd.Parameters.AddWithValue("@qty", txtquantity.Text)
                cmd.Parameters.AddWithValue("@itemname", lblitemname.Text)
                cmd.ExecuteNonQuery()
                con.Close()

                Dim transid As String = GetTransID()
                Dim from_datecreated As New DateTime()
                from_datecreated = CDate(datecreated)
                Dim datecreated_newformat As New DateTime(from_datecreated.Year, from_datecreated.Month, from_datecreated.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond)
                con.Open()
                cmd = New SqlCommand("INSERT INTO tblproduction (transaction_number,inv_id,item_code,item_name,category,quantity,sap_number,remarks,date,processed_by,type,transfer_to,transfer_from,status,area,from_transnum,reject,charge,typenum,type2) VALUES (@trans_id,(SELECT invnum FROM tblinvsum WHERE CAST(datecreated AS date)='" & datecreated & "'), (SELECT itemcode FROM tblitems WHERE itemname=@name),@name,(SELECT category FROM tblitems WHERE itemname=@name),@qty,@sap,@remarks,@date,@processed_by,'Transfer Item',@transfer_to,(SELECT branchcode FROM tblbranch WHERE main=1),'Completed','Sales','',0,0,'IT','Transfer')", con)
                cmd.Parameters.AddWithValue("@trans_id", transid)
                cmd.Parameters.AddWithValue("@name", lblitemname.Text)
                cmd.Parameters.AddWithValue("@qty", txtquantity.Text)
                cmd.Parameters.AddWithValue("@sap", IIf(check.Checked, "To Follow", txtsap.Text))
                cmd.Parameters.AddWithValue("@remarks", "p.o from short")
                cmd.Parameters.AddWithValue("@date", datecreated_newformat)
                cmd.Parameters.AddWithValue("@processed_by", login.username)
                cmd.Parameters.AddWithValue("@transfer_to", cmbtransferto.Text)
                cmd.ExecuteNonQuery()
                con.Close()

                MessageBox.Show("Transaction Completed", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            Else
                Dim ars1_transnum As String = "", ars2_price As Double = 0.00, ars_quantity As Double = 0.00
                con.Open()
                cmd = New SqlCommand("SELECT a.transnum,b.price,b.quantity FROM tblars1 a INNER JOIN tblars2 b ON a.transnum = b.transnum WHERE b.description=@itemname AND a.name='Short' AND a.invnum=(SELECT invnum FROM tblinvsum WHERE CAST(datecreated AS date)='" & datecreated & "')", con)
                cmd.Parameters.AddWithValue("@itemname", lblitemname.Text)
                rdr = cmd.ExecuteReader
                If rdr.Read Then
                    ars1_transnum = rdr("transnum")
                    ars_quantity = rdr("quantity")
                    ars2_price = rdr("price")
                End If
                con.Close()
                Dim remaining_amtdue As Double = txtquantity.Text * ars2_price



                con.Open()
                cmd = New SqlCommand("UPDATE tblproduction SET charge-=@qty WHERE Type ='Actual Ending Balance' AND inv_id=(SELECT invnum FROM tblinvsum WHERE CAST(datecreated AS date)='" & datecreated & "') AND item_name=@itemname;", con)
                cmd.Parameters.AddWithValue("@qty", txtquantity.Text)
                cmd.Parameters.AddWithValue("@itemname", lblitemname.Text)
                cmd.ExecuteNonQuery()
                con.Close()

                con.Open()
                cmd = New SqlCommand("UPDATE tblars1 SET amountdue-=@amtdue WHERE transnum=@transnum AND name='Short';", con)
                cmd.Parameters.AddWithValue("@amtdue", remaining_amtdue)
                cmd.Parameters.AddWithValue("@transnum", ars1_transnum)
                cmd.ExecuteNonQuery()
                con.Close()

                con.Open()
                cmd = New SqlCommand("UPDATE tbltransaction SET amtdue-=@amtdue WHERE transnum=@transnum AND customer='Short';", con)
                cmd.Parameters.AddWithValue("@amtdue", remaining_amtdue)
                cmd.Parameters.AddWithValue("@transnum", ars1_transnum)
                cmd.ExecuteNonQuery()
                con.Close()

                con.Open()
                cmd = New SqlCommand("UPDATE tbltransaction2 SET amtdue-=@amtdue WHERE transnum=@transnum AND customer='Short';", con)
                cmd.Parameters.AddWithValue("@amtdue", remaining_amtdue)
                cmd.Parameters.AddWithValue("@transnum", ars1_transnum)
                cmd.ExecuteNonQuery()
                con.Close()

                con.Open()
                cmd = New SqlCommand("UPDATE tblars2 SET quantity-=@qty,amount=@amt  WHERE transnum=@transnum AND description=@itemname AND name='Short';", con)
                cmd.Parameters.AddWithValue("@qty", txtquantity.Text)
                cmd.Parameters.AddWithValue("@transnum", ars1_transnum)
                cmd.Parameters.AddWithValue("@amt", remaining_amtdue)
                cmd.Parameters.AddWithValue("@itemname", lblitemname.Text)
                cmd.ExecuteNonQuery()
                con.Close()

                con.Open()
                cmd = New SqlCommand("UPDATE tblorder SET qty-=@qty,totalprice=@amt WHERE transnum=@transnum AND itemname=@itemname;", con)
                cmd.Parameters.AddWithValue("@transnum", ars1_transnum)
                cmd.Parameters.AddWithValue("@itemname", lblitemname.Text)
                cmd.Parameters.AddWithValue("@qty", txtquantity.Text)
                cmd.Parameters.AddWithValue("@amt", remaining_amtdue)
                cmd.ExecuteNonQuery()
                con.Close()

                Dim orderid As Integer = 0
                con.Open()
                cmd = New SqlCommand("SELECT ordernum FROM tbltransaction2 WHERE transnum=@transnum AND customer='Short';", con)
                cmd.Parameters.AddWithValue("@transnum", ars1_transnum)
                rdr = cmd.ExecuteReader
                If rdr.Read Then
                    orderid = CInt(rdr("ordernum"))
                End If
                con.Close()

                con.Open()
                cmd = New SqlCommand("UPDATE tblorder2 SET qty-=@qty,totalprice=@amt WHERE CAST(datecreated AS date)='" & datecreated & "' AND ordernum=@id  AND itemname=@itemname;", con)
                cmd.Parameters.AddWithValue("@transnum", ars1_transnum)
                cmd.Parameters.AddWithValue("@id", orderid)
                cmd.Parameters.AddWithValue("@itemname", lblitemname.Text)
                cmd.Parameters.AddWithValue("@qty", txtquantity.Text)
                cmd.Parameters.AddWithValue("@amt", remaining_amtdue)
                cmd.ExecuteNonQuery()
                con.Close()

                con.Open()
                cmd = New SqlCommand("UPDATE tblinvitems SET archarge-=@qty,transfer+=@qty WHERE itemname=@itemname AND invnum=(SELECT invnum FROM tblinvsum WHERE CAST(datecreated AS date)='" & datecreated & "');", con)
                cmd.Parameters.AddWithValue("@qty", txtquantity.Text)
                cmd.Parameters.AddWithValue("@itemname", lblitemname.Text)
                cmd.ExecuteNonQuery()
                con.Close()

                Dim transid As String = GetTransID()
                Dim from_datecreated As New DateTime()
                from_datecreated = CDate(datecreated)
                Dim datecreated_newformat As New DateTime(from_datecreated.Year, from_datecreated.Month, from_datecreated.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond)
                con.Open()
                cmd = New SqlCommand("INSERT INTO tblproduction (transaction_number,inv_id,item_code,item_name,category,quantity,sap_number,remarks,date,processed_by,type,transfer_to,transfer_from,status,area,from_transnum,reject,charge,typenum,type2) VALUES (@trans_id,(SELECT invnum FROM tblinvsum WHERE CAST(datecreated AS date)='" & datecreated & "'), (SELECT itemcode FROM tblitems WHERE itemname=@name),@name,(SELECT category FROM tblitems WHERE itemname=@name),@qty,@sap,@remarks,@date,@processed_by,'Transfer Item',@transfer_to,(SELECT branchcode FROM tblbranch WHERE main=1),'Completed','Sales','',0,0,'IT','Transfer')", con)
                cmd.Parameters.AddWithValue("@trans_id", transid)
                cmd.Parameters.AddWithValue("@name", lblitemname.Text)
                cmd.Parameters.AddWithValue("@qty", txtquantity.Text)
                cmd.Parameters.AddWithValue("@sap", IIf(check.Checked, "To Follow", txtsap.Text))
                cmd.Parameters.AddWithValue("@remarks", "p.o from short")
                cmd.Parameters.AddWithValue("@date", datecreated_newformat)
                cmd.Parameters.AddWithValue("@processed_by", login.username)
                cmd.Parameters.AddWithValue("@transfer_to", cmbtransferto.Text)
                cmd.ExecuteNonQuery()
                con.Close()

                MessageBox.Show("Transaction Completed", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            End If
        End If
    End Sub

    Public Function GetTransID() As String
        Dim selectcount_result As Integer = 0
        Dim get_area As String = "", temp As String = "0"
        Dim area_format As String = "", result As String = ""
        con.Open()
        cmd = New SqlCommand("Select ISNULL(MAX(transaction_id),0) from tblproduction WHERE area='" & "Sales" & "' AND type='Transfer Item' AND type2='Transfer';", con)
        selectcount_result = cmd.ExecuteScalar + 1
        con.Close()
        Dim branchcode As String = ""
        con.Open()
        cmd = New SqlCommand("SELECT branchcode FROM tblbranch WHERE main='1';", con)
        rdr = cmd.ExecuteReader
        While rdr.Read
            branchcode = rdr("branchcode")
        End While
        con.Close()

        area_format = "TRA - " & branchcode & " - "

        If selectcount_result < 1000000 Then
            Dim cselectcount_result As String = CStr(selectcount_result)
            For vv As Integer = 1 To 6 - cselectcount_result.Length
                temp += "0"
            Next
            result = area_format & temp & selectcount_result
        Else
            result = area_format & temp & selectcount_result
        End If
        Return result
    End Function

    Public Function checkBranch() As Boolean
        Dim result As Boolean = False
        con.Open()
        cmd = New SqlCommand("SELECT brid FROM tblbranch WHERE branchcode=@branchcode AND main=0;", con)
        cmd.Parameters.AddWithValue("@branchcode", cmbtransferto.Text)
        rdr = cmd.ExecuteReader
        If Not rdr.Read Then
            result = True
        End If
        con.Close()
        Return result
    End Function
    Private Sub txtquantity_TextChanged(sender As Object, e As EventArgs) Handles txtquantity.TextChanged
        Try
            If CDbl(txtquantity.Text) > CDbl(lblquantity.Text) Then
                txtquantity.Text = lblquantity.Text
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub check_CheckedChanged(sender As Object, e As EventArgs) Handles check.CheckedChanged
        txtsap.Enabled = IIf(check.Checked, False, True)
        txtsap.Text = IIf(check.Checked, "", txtsap.Text)
    End Sub

    Private Sub txtquantity_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtquantity.KeyPress, txtsap.KeyPress
        If Not Char.IsControl(e.KeyChar) And Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtquantity_KeyDown(sender As Object, e As KeyEventArgs) Handles txtquantity.KeyDown, txtsap.KeyDown, cmbtransferto.KeyDown, check.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnsubmit.PerformClick()
        End If
    End Sub
End Class