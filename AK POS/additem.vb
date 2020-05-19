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
        'call loadcategories sub
        loadCategories()
        'check header
        If lblheader.Text = "EDIT ITEM" And itemid <> 0 Then
            'call loaditems sub
            loadIems()
        End If
    End Sub
    ''' <summary>
    ''' get category from tblcat
    ''' </summary>
    Public Sub loadCategories()
        Try
            'clear combobox item
            cmbcategory.Items.Clear()
            'open connection
            con.Open()
            'syntax
            cmd = New SqlCommand("SELECT category FROM tblcat WHERE status=1;", con)
            'read
            rdr = cmd.ExecuteReader
            'loop through
            While rdr.Read
                'add item to combobox
                cmbcategory.Items.Add(rdr("category"))
            End While
            'close connection
            con.Close()
            'check if item count is not equal to zero
            If cmbcategory.Items.Count <> 0 Then
                'assign selectedindex to zero
                cmbcategory.SelectedIndex = 0
            End If
        Catch ex As Exception
            'error msg
            MessageBox.Show(ex.ToString)
        Finally
            'close connection
            con.Close()
        End Try
    End Sub
    ''' <summary>
    ''' load items where itemid
    ''' </summary>
    Public Sub loadIems()
        Try
            'open connectopm
            con.Open()
            'syntax
            cmd = New SqlCommand("SELECT a.itemcode,a.itemname,a.category,a.description,a.price,a.deposit,ISNULL((SELECT price FROM tbldepositprice WHERE itemid=a.itemid),0) [deposit_price] FROM tblitems a WHERE a.itemid=" & itemid & ";", con)
            'read command
            rdr = cmd.ExecuteReader
            'loop through
            While rdr.Read
                'assign values
                txtcode.Text = rdr("itemcode")
                current_itemcode = rdr("itemcode")
                txtname.Text = rdr("itemname")
                txtdescription.Text = rdr("description")
                txtprice.Text = CDbl(rdr("price")).ToString("n2")
                cmbcategory.SelectedItem = rdr("category")
                chck.Checked = IIf(CInt(rdr("deposit")) = 1, True, False)
                txtdepositprice.Text = CDbl(rdr("deposit_price")).ToString("n2")
            End While
            'close connection
            con.Close()
        Catch ex As Exception
            'error msg
            MessageBox.Show(ex.ToString)
        Finally
            'close connection
            con.Close()
        End Try
    End Sub

    Private Sub txtprice_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtprice.KeyPress, txtdepositprice.KeyPress
        'check if user press not numeric
        If Not Char.IsControl(e.KeyChar) And Not Char.IsDigit(e.KeyChar) Then
            'stop
            e.Handled = True
        End If
    End Sub

    Private Sub txtprice_Leave(sender As Object, e As EventArgs) Handles txtprice.Leave
        Try
            'assign price to double format
            txtprice.Text = CDbl(txtprice.Text).ToString("n2")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtdepositprice_Leave(sender As Object, e As EventArgs) Handles txtdepositprice.Leave
        Try
            'assign deposit price to double format
            txtdepositprice.Text = CDbl(txtdepositprice.Text).ToString("n2")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub chck_CheckedChanged(sender As Object, e As EventArgs) Handles chck.CheckedChanged
        'check if checkbox is checked
        If chck.Checked Then
            'assign values
            txtdepositprice.Visible = True
            Label4.Visible = True
            txtdepositprice.Text = ""
        Else
            'assign values
            txtdepositprice.Visible = False
            Label4.Visible = False
            txtdepositprice.Text = ""
        End If
    End Sub
    ''' <summary>
    ''' submit button
    ''' </summary>
    Public Sub submit()
        'check if item code is empty
        If String.IsNullOrEmpty(txtcode.Text) Then
            'msg
            MessageBox.Show("Code field is empty", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'focus
            txtcode.Focus()
            'check if item name is empty
        ElseIf String.IsNullOrEmpty(txtname.Text) Then
            'msg
            MessageBox.Show("Item field is empty", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'focus
            txtname.Focus()
            'check if description is empty
        ElseIf String.IsNullOrEmpty(txtdescription.Text) Then
            'msg
            MessageBox.Show("Description field is empty", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'focus
            txtdescription.Focus()
            'check if price is empty
        ElseIf String.IsNullOrEmpty(txtprice.Text) Then
            'msg
            MessageBox.Show("Price field is empty", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'focus
            txtprice.Focus()
            'check if deposit price is empty
        ElseIf chck.Checked = True And String.IsNullOrEmpty(txtdepositprice.Text) Then
            'msg
            MessageBox.Show("Deposit Price field is empty", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'focus
            txtdepositprice.Focus()
        Else
            'check if header text is ADD
            If lblheader.Text = "ADD ITEM" Then
                'call addItem sub
                addItem()
                'check if header text is EDIT
            ElseIf lblheader.Text = "EDIT ITEM" Then
                'call updateItem sub
                updateItem()
            End If
        End If
    End Sub
    Private Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        'call submit sub
        submit()
    End Sub

    ''' <summary>
    ''' check item if exist
    ''' </summary>
    ''' <returns></returns>
    Public Function checkItem(ByVal itemname As String) As Boolean
        'init result
        Dim result As Boolean = False
        'open connection
        con.Open()
        'syntax
        cmd = New SqlCommand("SELECT itemname FROM tblitems WHERE itemname=@itemname;", con)
        'assign parameter
        cmd.Parameters.AddWithValue("@itemname", itemname)
        'read command
        rdr = cmd.ExecuteReader
        'check if read has row
        If rdr.Read Then
            'assign
            result = True
        Else
            'assign
            result = False
        End If
        'close connection
        con.Close()
        'return result
        Return result
    End Function

    ''' <summary>
    ''' get the server date
    ''' </summary>
    ''' <returns></returns>
    Public Function getSystemDate() As DateTime
        Try
            'init result
            Dim result As New DateTime()
            'open connection
            con.Open()
            'syntax
            cmd = New SqlCommand("SELECT GETDATE()", con)
            'read command
            rdr = cmd.ExecuteReader()
            'loop through
            While rdr.Read
                'assign value
                result = CDate(rdr(0).ToString)
            End While
            'close connection
            con.Close()
            'return result
            Return result
        Catch ex As Exception
            'msg error
            MessageBox.Show(ex.ToString)
        End Try
    End Function

    ''' <summary>
    '''  get latest inventory number
    ''' </summary>
    Public Function getInvID() As String
        'init variables
        Dim id As String = "", date_ As New DateTime()
        'open connection
        con.Open()
        'syntax
        cmd = New SqlCommand("Select TOP 1 invnum,datecreated from tblinvsum WHERE area='" & "Sales" & "' order by invsumid DESC", con)
        'read command
        rdr = cmd.ExecuteReader()
        'check if read has row
        If rdr.Read() Then
            'assign values
            id = rdr("invnum")
            date_ = CDate(rdr("datecreated"))
        End If
        'close connection
        con.Close()
        'return expression
        If date_.ToString("MM/dd/yyyy") = getSystemDate.ToString("MM/dd/yyyy") Then
            Return id
        Else
            Return "N/A"
        End If
    End Function
    ''' <summary>
    ''' get latest item id that inserted
    ''' </summary>
    ''' <returns></returns>
    Public Function getLastItemID() As Integer
        'init result
        Dim result As Integer = 0
        'open connection
        con.Open()
        'syntax
        cmd = New SqlCommand("Select Top 1 itemid from tblitems order by itemid DESC", con)
        'assign result
        result = cmd.ExecuteScalar
        'close connection
        con.Close()
        'return result
        Return result
    End Function
    ''' <summary>
    ''' add item
    ''' </summary>
    Public Sub addItem()
        'check if item name is already inserted in database
        If checkItem(txtname.Text) Then
            MessageBox.Show("Item is already exist", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'check inventory number
        ElseIf getInvID() = "N/A" Then
            MessageBox.Show("Created New Inventory first", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            'init inventory id and latest itemid
            Dim invnum As String = getInvID(), last_itemid As Integer = getLastItemID()
            'confirm dialog
            Dim a As String = MsgBox("Are you sure you want to add item?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Add Item")
            'check if user click ok button
            If a = vbYes Then
                Try
                    'create new connection
                    Using connection As New SqlConnection(cc.conString)
                        'init command
                        Dim cmdd As New SqlCommand()
                        'open connection
                        cmdd.Connection = connection
                        connection.Open()
                        'begin transaction
                        transaction = connection.BeginTransaction()
                        cmdd.Transaction = transaction

                        'clear parameter first
                        cmdd.Parameters.Clear()
                        'syntax
                        cmdd.CommandText = "INSERT INTO tblitems (category,itemcode,itemname,description,price,datecreated,createdby,datemodified,status,discontinued,deposit) VALUES (@category,@itemcode,@itemname,@description,@price,(SELECT GETDATE()), @createdby,(SELECT GETDATE()),0,0,@deposit)"
                        'assign parameters
                        cmdd.Parameters.AddWithValue("@category", cmbcategory.SelectedItem)
                        cmdd.Parameters.AddWithValue("@itemcode", txtcode.Text)
                        cmdd.Parameters.AddWithValue("@itemname", txtname.Text)
                        cmdd.Parameters.AddWithValue("@description", txtdescription.Text)
                        cmdd.Parameters.AddWithValue("@price", txtprice.Text)
                        cmdd.Parameters.AddWithValue("@createdby", login2.username)
                        cmdd.Parameters.AddWithValue("@deposit", IIf(chck.Checked, 1, 0))
                        'execute query
                        cmdd.ExecuteNonQuery()

                        'clear parameter first
                        cmdd.Parameters.Clear()
                        'command syntax
                        cmdd.CommandText = "INSERT INTO tblinvitems (invnum,itemcode,itemname,begbal,produce,good,reject,charge,productionin,itemin,totalav,ctrout,pullout,endbal,actualendbal,variance,shortover,status,convin,archarge,arsales,convout,transfer,area,arreject,supin,adjustmentin,reject_convin,reject_convout,reject_archarge,reject_transfer,reject_totalav,cancelin) VALUES (@invnum,@itemcode,@itemname,0,0,0,0,0,0,0,0,0,0,0,0,0,'',1,0,0,0,0,0,'Sales',0,0,0,0,0,0,0,0,0)"
                        'assign parameters
                        cmdd.Parameters.AddWithValue("@invnum", invnum)
                        cmdd.Parameters.AddWithValue("@itemname", txtcode.Text)
                        cmdd.Parameters.AddWithValue("@itemcode", txtname.Text)
                        'execute query
                        cmdd.ExecuteNonQuery()
                        'check if checkbox is checked
                        If chck.Checked Then
                            'clear parameters first
                            cmdd.Parameters.Clear()
                            'command syntax
                            cmdd.CommandText = "INSERT INTO tbldepositprice (itemid,price) VALUES (@itemid,@price);"
                            'assign parameters
                            cmdd.Parameters.AddWithValue("@itemid", last_itemid)
                            cmdd.Parameters.AddWithValue("@price", txtdepositprice.Text)
                            'execute query
                            cmdd.ExecuteNonQuery()


                            'clear parameters first
                            cmdd.Parameters.Clear()
                            'command syntax
                            cmdd.CommandText = "INSERT  INTO tbldiscitems (itemid) VALUES (@itemid);"
                            'assign parameter
                            cmdd.Parameters.AddWithValue("@itemid", last_itemid)
                            'execute query
                            cmdd.ExecuteNonQuery()
                        End If
                        'commit query
                        transaction.Commit()
                        'msg 
                        MessageBox.Show("Item Added", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        'close the form
                        Me.Close()
                    End Using
                Catch ex As Exception
                    'msg error
                    MessageBox.Show(ex.ToString)
                    Try
                        'rollback query
                        transaction.Rollback()
                    Catch ex2 As Exception
                        'msg sql error
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
        'check if user pressed ESC button
        If e.KeyCode = Keys.Escape Then
            'close the form
            Me.Close()
        End If
    End Sub

    Private Sub cmbcategory_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbcategory.KeyDown, txtprice.KeyDown, txtname.KeyDown, txtdescription.KeyDown, txtdepositprice.KeyDown, txtcode.KeyDown
        'check if user pressed Enter button
        If e.KeyCode = Keys.Enter Then
            'call submit sub
            submit()
        End If
    End Sub

    ''' <summary>
    ''' update item
    ''' </summary>
    Public Sub updateItem()
        'init variables
        Dim itemname As String = "", result As Boolean = False, current_itemid As Integer = 0
        Try
            'open connection
            con.Open()
            'syntax
            cmd = New SqlCommand("SELECT itemname,itemid FROM tblitems WHERE itemname=@itemname;", con)
            'assign parameters
            cmd.Parameters.AddWithValue("@itemname", txtname.Text)
            'read command 
            rdr = cmd.ExecuteReader
            'check if read has row
            If rdr.Read Then
                'assign values
                itemname = CStr(rdr("itemname"))
                current_itemid = CInt(rdr("itemid"))
                result = True
            End If
            'close connection
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        Try
            'create new connection
            Using connection As New SqlConnection(cc.conString)
                'init command
                Dim cmdd As New SqlCommand()
                'open connection
                cmdd.Connection = connection
                connection.Open()
                'begin connection
                transaction = connection.BeginTransaction()
                cmdd.Transaction = transaction

                'check if itemname is already inserted to database
                If itemname <> current_itemname And result Then
                    'msg error
                    MessageBox.Show("Item Name is already exist", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    'clear parameter first
                    cmdd.Parameters.Clear()
                    'command syntax
                    cmdd.CommandText = "UPDATE tblitems SET category=@category,itemname=@itemname,itemcode=@itemcode,description=@description,price=@price,datemodified=(SELECT GETDATE()),modifiedby=@modby,deposit=@deposit WHERE itemname=@current_itemname"
                    'assign parameters
                    cmdd.Parameters.AddWithValue("@current_itemname", current_itemname)
                    cmdd.Parameters.AddWithValue("@category", cmbcategory.Text)
                    cmdd.Parameters.AddWithValue("@itemname", txtname.Text)
                    cmdd.Parameters.AddWithValue("@itemcode", txtcode.Text)
                    cmdd.Parameters.AddWithValue("@description", txtdescription.Text)
                    cmdd.Parameters.AddWithValue("@price", txtprice.Text)
                    cmdd.Parameters.AddWithValue("@modby", login2.username)
                    cmdd.Parameters.AddWithValue("@deposit", IIf(chck.Checked, 1, 0))
                    'execute query
                    cmdd.ExecuteNonQuery()

                    'clear parameters first
                    cmdd.Parameters.Clear()
                    'command syntax
                    cmdd.CommandText = "UPDATE tblconversion SET item_code=@itemcode WHERE item_code=@current_itemcode"
                    'assign parameters
                    cmdd.Parameters.AddWithValue("@itemcode", txtcode.Text)
                    cmdd.Parameters.AddWithValue("@current_itemcode", current_itemcode)
                    'execute query
                    cmdd.ExecuteNonQuery()

                    'clear parameter first
                    cmdd.Parameters.Clear()
                    'command syntax
                    cmdd.CommandText = "UPDATE tblinvitems SET itemcode=@itemcode,itemname=@itemname WHERE itemcode=@current_itemcode"
                    'assign parameters
                    cmdd.Parameters.AddWithValue("@itemcode", txtcode.Text)
                    cmdd.Parameters.AddWithValue("@itemname", txtname.Text)
                    cmdd.Parameters.AddWithValue("@current_itemcode", current_itemcode)
                    'execute query
                    cmdd.ExecuteNonQuery()

                    'clear parameters clear
                    cmdd.Parameters.Clear()
                    'command syntax
                    cmdd.CommandText = "UPDATE tblproduction SET item_code=@itemcode,item_name=@itemname WHERE item_code=@current_itemcode"
                    'assign command parameters
                    cmdd.Parameters.AddWithValue("@itemcode", txtcode.Text)
                    cmdd.Parameters.AddWithValue("@itemname", txtname.Text)
                    cmdd.Parameters.AddWithValue("@current_itemcode", current_itemcode)
                    'execute query
                    cmdd.ExecuteNonQuery()

                    'clear parameters first
                    cmdd.Parameters.Clear()
                    'command syntax
                    cmdd.CommandText = "UPDATE tblorder SET itemname=@itemname WHERE itemname=@current_itemcode"
                    'assign parameters
                    cmdd.Parameters.AddWithValue("@itemname", txtname.Text)
                    cmdd.Parameters.AddWithValue("@current_itemcode", current_itemname)
                    'execute query
                    cmdd.ExecuteNonQuery()

                    'clear parameters first
                    cmdd.Parameters.Clear()
                    'command syntax
                    cmdd.CommandText = "UPDATE tblorder2 SET itemname=@itemname WHERE itemname=@current_itemcode"
                    'assign command parameters
                    cmdd.Parameters.AddWithValue("@itemname", txtname.Text)
                    cmdd.Parameters.AddWithValue("@current_itemcode", current_itemname)
                    'execute query
                    cmdd.ExecuteNonQuery()

                    'clear parameter first
                    cmdd.Parameters.Clear()
                    'command syntax
                    cmdd.CommandText = "UPDATE tblars2 SET description=@description WHERE description=@current_itemname"
                    'assign parameters
                    cmdd.Parameters.AddWithValue("@description", txtname.Text)
                    cmdd.Parameters.AddWithValue("@current_itemname", current_itemname)
                    'execute query
                    cmdd.ExecuteNonQuery()
                End If
                'check if item id has deposit price
                If chck.Checked Then
                    'init variable
                    Dim haveDeposit As Boolean = False
                    'command syntax
                    cmdd.CommandText = "SELECT depid FROM tbldepositprice WHERE itemid=@itemid;"
                    'assign parameter
                    cmdd.Parameters.AddWithValue("@itemid", current_itemid)
                    'read command
                    rdr = cmdd.ExecuteReader
                    'check read has row
                    If rdr.Read Then
                        'assign value
                        haveDeposit = True
                    End If
                    'dispose read
                    rdr.Dispose()

                    'check haveDeposit is true
                    If haveDeposit Then
                        'clear parameter first
                        cmdd.Parameters.Clear()
                        'command syntax
                        cmdd.CommandText = "UPDATE tbldepositprice SET price=@price,status=1 WHERE itemid=@itemid"
                        'assign parameters
                        cmdd.Parameters.AddWithValue("@itemid", current_itemid)
                        cmdd.Parameters.AddWithValue("@price", txtdepositprice.Text)
                        'execute query
                        cmdd.ExecuteNonQuery()
                    Else
                        'clear parameter first
                        cmdd.Parameters.Clear()
                        'command syntax
                        cmdd.CommandText = "INSERT INTO tbldepositprice (itemid,price) VALUES (@itemid,@price);"
                        'assign parameters
                        cmdd.Parameters.AddWithValue("@itemid", current_itemid)
                        cmdd.Parameters.AddWithValue("@price", txtdepositprice.Text)
                        'execute query
                        cmdd.ExecuteNonQuery()
                    End If
                Else
                    'init variable that check itemname has deposit price
                    Dim haveDeposit As Boolean = False
                    'clear parameter first
                    cmdd.Parameters.Clear()
                    'syntax
                    cmdd.CommandText = "SELECT depid FROM tbldepositprice WHERE itemid=@itemid;"
                    'assign parameters
                    cmdd.Parameters.AddWithValue("@itemid", current_itemid)
                    'read command
                    rdr = cmdd.ExecuteReader
                    'check read has row
                    If rdr.Read Then
                        'assign haveDeposit to true that means item name has deposit price
                        haveDeposit = True
                    End If
                    'dispose read
                    rdr.Dispose()

                    'check if haveDeposit is true
                    If haveDeposit Then
                        'clear parameter first
                        cmdd.Parameters.Clear()
                        'command syntax
                        cmdd.CommandText = "UPDATE tbldepositprice SET status=0,price=0 WHERE itemid=@itemid"
                        'assign parameter
                        cmdd.Parameters.AddWithValue("@itemid", current_itemid)
                        'execute query
                        cmdd.ExecuteNonQuery()
                    End If
                End If
                'commit query
                transaction.Commit()
                'msg
                MessageBox.Show("Item Updated", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'close the form
                Me.Close()
            End Using
        Catch ex As Exception
            'msg error
            MessageBox.Show(ex.ToString)
            Try
                'rollback query
                transaction.Rollback()
            Catch ex2 As Exception
                'sql msg error
                MessageBox.Show(ex2.ToString)
            End Try
        End Try
    End Sub
End Class