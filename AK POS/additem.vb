Imports System.Data.SqlClient
Imports AK_POS.connection_class
Public Class additem
    Dim cc As New connection_class
    Dim con As New SqlConnection(cc.conString)
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader
    Dim transaction As SqlTransaction
    Public itemid As Integer = 0, current_itemname As String = "", current_itemcode As String = ""
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    Private Sub lblclose_Click(sender As Object, e As EventArgs) Handles lblclose.Click
        Me.Close()
    End Sub
    Public Sub clear_all()
        txtcode.Text = ""
        txtname.Text = ""
        txtdescription.Text = ""
        txtdepositprice.Text = ""
        txtprice.Text = ""
        cmbcategory.SelectedIndex=0
    End Sub
    Private Sub additem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadCategories()
        If lblheader.Text = "EDIT ITEM" And itemid <> 0 Then
            loadIems()
        End If
    End Sub
    Public Sub loadCategories()
        Try
            cmbcategory.Items.Clear()
            con.Open()
            cmd = New SqlCommand("SELECT category FROM tblcat WHERE status=1;", con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                cmbcategory.Items.Add(rdr("category"))
            End While
            con.Close()

            cmbcategory.SelectedIndex = 0
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub
    Public Sub loadIems()
        Try
            con.Open()
            cmd = New SqlCommand("SELECT a.itemcode,a.itemname,a.category,a.description,a.price,a.deposit,ISNULL((SELECT price FROM tbldepositprice WHERE itemid=a.itemid),0) [deposit_price] FROM tblitems a WHERE a.itemid=" & itemid & ";", con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                txtcode.Text = rdr("itemcode")
                current_itemcode = rdr("itemcode")
                txtname.Text = rdr("itemname")
                txtdescription.Text = rdr("description")
                txtprice.Text = CDbl(rdr("price")).ToString("n2")
                cmbcategory.SelectedItem = rdr("category")
                chck.Checked = IIf(CInt(rdr("deposit")) = 1, True, False)
                txtdepositprice.Text = CDbl(rdr("deposit_price")).ToString("n2")
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub txtprice_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtprice.KeyPress, txtdepositprice.KeyPress
        If Not Char.IsControl(e.KeyChar) And Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtprice_Leave(sender As Object, e As EventArgs) Handles txtprice.Leave
        Try
            txtprice.Text = CDbl(txtprice.Text).ToString("n2")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtdepositprice_Leave(sender As Object, e As EventArgs) Handles txtdepositprice.Leave
        Try
            txtdepositprice.Text = CDbl(txtdepositprice.Text).ToString("n2")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chck_CheckedChanged(sender As Object, e As EventArgs) Handles chck.CheckedChanged
        If chck.Checked Then
            txtdepositprice.Visible = True
            Label4.Visible = True
            txtdepositprice.Text = ""
        Else
            txtdepositprice.Visible = False
            Label4.Visible = False
            txtdepositprice.Text = ""
        End If
    End Sub
    Public Sub submit()
        If String.IsNullOrEmpty(txtcode.Text) Then
            MessageBox.Show("Code field is empty", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtcode.Focus()
        ElseIf String.IsNullOrEmpty(txtname.Text) Then
            MessageBox.Show("Item field is empty", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtname.Focus()
        ElseIf String.IsNullOrEmpty(txtdescription.Text) Then
            MessageBox.Show("Description field is empty", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtdescription.Focus()
        ElseIf String.IsNullOrEmpty(txtprice.Text) Then
            MessageBox.Show("Price field is empty", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtprice.Focus()
        ElseIf chck.Checked = True And String.IsNullOrEmpty(txtdepositprice.Text) Then
            MessageBox.Show("Deposit Price field is empty", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtdepositprice.Focus()
        Else
            If lblheader.Text = "ADD ITEM" Then
                addItem()
            ElseIf lblheader.Text = "EDIT ITEM" Then
                updateItem()
            End If
        End If
    End Sub
    Private Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        submit()
    End Sub

    ''' <summary>
    ''' check item if exist
    ''' </summary>
    ''' <returns></returns>
    Public Function checkItem(ByVal itemname As String) As Boolean
        Dim result As Boolean = False
        con.Open()
        cmd = New SqlCommand("SELECT itemname FROM tblitems WHERE itemname=@itemname;", con)
        cmd.Parameters.AddWithValue("@itemname", itemname)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            result = True
        Else
            result = False
        End If
        con.Close()
        Return result
    End Function

    ''' <summary>
    ''' get the server date
    ''' </summary>
    ''' <returns></returns>
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
        End Try
    End Function

    ''' <summary>
    '''  get latest inventory number
    ''' </summary>
    Public Function getInvID() As String
        Dim id As String = ""
        Dim date_ As New DateTime()
        con.Open()
        cmd = New SqlCommand("Select TOP 1 invnum,datecreated from tblinvsum WHERE area='" & "Sales" & "' order by invsumid DESC", con)
        rdr = cmd.ExecuteReader()
        If rdr.Read() Then
            id = rdr("invnum")
            date_ = CDate(rdr("datecreated"))
        End If
        con.Close()
        If date_.ToString("MM/dd/yyyy") = getSystemDate.ToString("MM/dd/yyyy") Then
            Return id
        Else
            Return "N/A"
        End If
    End Function
    Public Function getLastItemID() As Integer
        Dim itemid As Integer = 0
        con.Open()
        cmd = New SqlCommand("Select Top 1 itemid from tblitems order by itemid DESC", con)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            itemid = rdr("itemid")
        End If
        con.Close()
        Return itemid
    End Function
    ''' <summary>
    ''' add item
    ''' </summary>
    Public Sub addItem()
        If checkItem(txtname.Text) Then
            MessageBox.Show("Item is already exist", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf getInvID() = "N/A" Then
            MessageBox.Show("Created New Inventory first", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim invnum As String = getInvID()
            Dim last_itemid As Integer = getLastItemID()
            Dim a As String = MsgBox("Are you sure you want to add item?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Add Item")
            If a = vbYes Then
                Try
                    Using connection As New SqlConnection(login.ss)
                        Dim cmdd As New SqlCommand()
                        cmdd.Connection = connection
                        connection.Open()
                        transaction = connection.BeginTransaction()
                        cmdd.Transaction = transaction

                        cmdd.Parameters.Clear()
                        cmdd.CommandText = "INSERT INTO tblitems (category,itemcode,itemname,description,price,datecreated,createdby,datemodified,status,discontinued,deposit) VALUES (@category,@itemcode,@itemname,@description,@price,(SELECT GETDATE()), @createdby,(SELECT GETDATE()),0,0,@deposit)"
                        cmdd.Parameters.AddWithValue("@category", cmbcategory.SelectedItem)
                        cmdd.Parameters.AddWithValue("@itemcode", txtcode.Text)
                        cmdd.Parameters.AddWithValue("@itemname", txtname.Text)
                        cmdd.Parameters.AddWithValue("@description", txtdescription.Text)
                        cmdd.Parameters.AddWithValue("@price", txtprice.Text)
                        cmdd.Parameters.AddWithValue("@createdby", login.username)
                        cmdd.Parameters.AddWithValue("@deposit", IIf(chck.Checked, 1, 0))
                        cmdd.ExecuteNonQuery()

                        cmdd.Parameters.Clear()
                        cmdd.CommandText = "INSERT INTO tblinvitems (invnum,itemcode,itemname,begbal,produce,good,reject,charge,productionin,itemin,totalav,ctrout,pullout,endbal,actualendbal,variance,shortover,status,convin,archarge,arsales,convout,transfer,area,arreject,supin,adjustmentin,reject_convin,reject_convout,reject_archarge,reject_transfer,reject_totalav,cancelin) VALUES (@invnum,@itemcode,@itemname,0,0,0,0,0,0,0,0,0,0,0,0,0,'',1,0,0,0,0,0,'Sales',0,0,0,0,0,0,0,0,0)"
                        cmdd.Parameters.AddWithValue("@invnum", invnum)
                        cmdd.Parameters.AddWithValue("@itemname", txtcode.Text)
                        cmdd.Parameters.AddWithValue("@itemcode", txtname.Text)
                        cmdd.ExecuteNonQuery()
                        If chck.Checked Then
                            cmdd.Parameters.Clear()
                            cmdd.CommandText = "INSERT INTO tbldepositprice (itemid,price) VALUES (@itemid,@price);"
                            cmdd.Parameters.AddWithValue("@itemid", last_itemid)
                            cmdd.Parameters.AddWithValue("@price", txtdepositprice.Text)
                            cmdd.ExecuteNonQuery()

                            cmdd.Parameters.Clear()
                            cmdd.CommandText = "INSERT  INTO tbldiscitems (itemid) VALUES (@itemid);"
                            cmdd.Parameters.AddWithValue("@itemid", last_itemid)
                            cmdd.ExecuteNonQuery()
                        End If
                        transaction.Commit()
                        MessageBox.Show("Item Added", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.Close()
                    End Using
                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                    Try
                        transaction.Rollback()
                    Catch ex2 As Exception
                        MessageBox.Show(ex2.ToString)
                    End Try
                End Try
            End If
        End If
    End Sub

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown, MyBase.MouseDown, lblheader.MouseDown, Label9.MouseDown, Label8.MouseDown, Label5.MouseDown, Label4.MouseDown, Label3.MouseDown, Label2.MouseDown, Label1.MouseDown
        drag = True 'Sets the variable drag to true.
        mousex = Windows.Forms.Cursor.Position.X - Me.Left 'Sets variable mousex
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top 'Sets variable mousey
    End Sub

    Private Sub Panel1_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel1.MouseUp, MyBase.MouseUp, lblheader.MouseUp, Label9.MouseUp, Label8.MouseUp, Label5.MouseUp, Label4.MouseUp, Label3.MouseUp, Label2.MouseUp, Label1.MouseUp
        drag = False 'Sets drag to false, so the form does not move according to the code in MouseMove
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove, MyBase.MouseMove, lblheader.MouseMove, Label9.MouseMove, Label8.MouseMove, Label5.MouseMove, Label4.MouseMove, Label3.MouseMove, Label2.MouseMove, Label1.MouseMove
        'If drag is set to true then move the form accordingly.
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub additem_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub cmbcategory_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbcategory.KeyDown, txtprice.KeyDown, txtname.KeyDown, txtdescription.KeyDown, txtdepositprice.KeyDown, txtcode.KeyDown
        If e.KeyCode = Keys.Enter Then
            submit()
        End If
    End Sub

    ''' <summary>
    ''' update item
    ''' </summary>
    Public Sub updateItem()
        Dim itemname As String = "", result As Boolean = False, current_itemid As Integer = 0
        Try
            con.Open()
            cmd = New SqlCommand("SELECT itemname,itemid FROM tblitems WHERE itemname=@itemname;", con)
            cmd.Parameters.AddWithValue("@itemname", txtname.Text)
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                itemname = CStr(rdr("itemname"))
                current_itemid = CInt(rdr("itemid"))
                Result = True
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        Try
            Using connection As New SqlConnection(login.ss)
                Dim cmdd As New SqlCommand()
                cmdd.Connection = connection
                connection.Open()
                transaction = connection.BeginTransaction()
                cmdd.Transaction = transaction

                If itemname <> current_itemname And result Then
                    MessageBox.Show("Item Name is already exist", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    cmdd.Parameters.Clear()
                    cmdd.CommandText = "UPDATE tblitems SET category=@category,itemname=@itemname,itemcode=@itemcode,description=@description,price=@price,datemodified=(SELECT GETDATE()),modifiedby=@modby,deposit=@deposit WHERE itemname=@current_itemname"
                    cmdd.Parameters.AddWithValue("@current_itemname", current_itemname)
                    cmdd.Parameters.AddWithValue("@category", cmbcategory.Text)
                    cmdd.Parameters.AddWithValue("@itemname", txtname.Text)
                    cmdd.Parameters.AddWithValue("@itemcode", txtcode.Text)
                    cmdd.Parameters.AddWithValue("@description", txtdescription.Text)
                    cmdd.Parameters.AddWithValue("@price", txtprice.Text)
                    cmdd.Parameters.AddWithValue("@modby", login.username)
                    cmdd.Parameters.AddWithValue("@deposit", IIf(chck.Checked, 1, 0))
                    cmdd.ExecuteNonQuery()

                    cmdd.Parameters.Clear()
                    cmdd.CommandText = "UPDATE tblconversion SET item_code=@itemcode WHERE item_code=@current_itemcode"
                    cmdd.Parameters.AddWithValue("@itemcode", txtcode.Text)
                    cmdd.Parameters.AddWithValue("@current_itemcode", current_itemcode)
                    cmdd.ExecuteNonQuery()

                    cmdd.Parameters.Clear()
                    cmdd.CommandText = "UPDATE tblinvitems SET itemcode=@itemcode,itemname=@itemname WHERE itemcode=@current_itemcode"
                    cmdd.Parameters.AddWithValue("@itemcode", txtcode.Text)
                    cmdd.Parameters.AddWithValue("@itemname", txtname.Text)
                    cmdd.Parameters.AddWithValue("@current_itemcode", current_itemcode)
                    cmdd.ExecuteNonQuery()

                    cmdd.Parameters.Clear()
                    cmdd.CommandText = "UPDATE tblproduction SET item_code=@itemcode,item_name=@itemname WHERE item_code=@current_itemcode"
                    cmdd.Parameters.AddWithValue("@itemcode", txtcode.Text)
                    cmdd.Parameters.AddWithValue("@itemname", txtname.Text)
                    cmdd.Parameters.AddWithValue("@current_itemcode", current_itemcode)
                    cmdd.ExecuteNonQuery()

                    cmdd.Parameters.Clear()
                    cmdd.CommandText = "UPDATE tblorder SET itemname=@itemname WHERE itemname=@current_itemcode"
                    cmdd.Parameters.AddWithValue("@itemname", txtname.Text)
                    cmdd.Parameters.AddWithValue("@current_itemcode", current_itemname)
                    cmdd.ExecuteNonQuery()

                    cmdd.Parameters.Clear()
                    cmdd.CommandText = "UPDATE tblorder2 SET itemname=@itemname WHERE itemname=@current_itemcode"
                    cmdd.Parameters.AddWithValue("@itemname", txtname.Text)
                    cmdd.Parameters.AddWithValue("@current_itemcode", current_itemname)
                    cmdd.ExecuteNonQuery()

                    cmdd.Parameters.Clear()
                    cmdd.CommandText = "UPDATE tblars2 SET description=@description WHERE description=@current_itemname"
                    cmdd.Parameters.AddWithValue("@description", txtname.Text)
                    cmdd.Parameters.AddWithValue("@current_itemname", current_itemname)
                    cmdd.ExecuteNonQuery()
                End If
                If chck.Checked Then

                    Dim haveDeposit As Boolean = False
                    cmdd.CommandText = "SELECT depid FROM tbldepositprice WHERE itemid=@itemid;"
                    cmdd.Parameters.AddWithValue("@itemid", current_itemid)
                    rdr = cmdd.ExecuteReader
                    If rdr.Read Then
                        haveDeposit = True
                    End If
                    rdr.Dispose()

                    If haveDeposit Then
                        cmdd.Parameters.Clear()
                        cmdd.CommandText = "UPDATE tbldepositprice SET price=@price,status=1 WHERE itemid=@itemid"
                        cmdd.Parameters.AddWithValue("@itemid", current_itemid)
                        cmdd.Parameters.AddWithValue("@price", txtdepositprice.Text)
                        cmdd.ExecuteNonQuery()
                    Else
                        cmdd.Parameters.Clear()
                        cmdd.CommandText = "INSERT INTO tbldepositprice (itemid,price) VALUES (@itemid,@price);"
                        cmdd.Parameters.AddWithValue("@itemid", current_itemid)
                        cmdd.Parameters.AddWithValue("@price", txtdepositprice.Text)
                        cmdd.ExecuteNonQuery()
                    End If
                Else
                    Dim haveDeposit As Boolean = False
                    cmdd.Parameters.Clear()
                    cmdd.CommandText = "SELECT depid FROM tbldepositprice WHERE itemid=@itemid;"
                    cmdd.Parameters.AddWithValue("@itemid", current_itemid)
                    rdr = cmdd.ExecuteReader
                    If rdr.Read Then
                        haveDeposit = True
                    End If
                    rdr.Dispose()

                    If haveDeposit Then
                        cmdd.Parameters.Clear()
                        cmdd.CommandText = "UPDATE tbldepositprice SET status=0,price=0 WHERE itemid=@itemid"
                        cmdd.Parameters.AddWithValue("@itemid", current_itemid)
                        cmdd.ExecuteNonQuery()
                    End If
                End If
                transaction.Commit()
                MessageBox.Show("Item Updated", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Try
                transaction.Rollback()
            Catch ex2 As Exception
                MessageBox.Show(ex2.ToString)
            End Try
        End Try
    End Sub
End Class