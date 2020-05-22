Imports System.Data.SqlClient
Imports AK_POS.connection_class
Imports AK_POS.items_class
Public Class additem
    Dim cc As New connection_class, itemc As New items_class()
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
    ''' get category from item class
    ''' </summary>
    Public Sub loadCategories()
        Try
            'clear category combo box
            cmbcategory.Items.Clear()
            'init result to hold categories
            Dim result As New DataTable()
            'assign datatable to get data
            result = itemc.loadCategories()
            'loop through
            For Each r0w As DataRow In result.Rows
                'add category to combo box
                cmbcategory.Items.Add(r0w("category"))
            Next
            'check if item count is greater than zero
            If cmbcategory.Items.Count > 0 Then
                'set selected index to zero
                cmbcategory.SelectedIndex = 0
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    ''' <summary>
    ''' load items where itemid
    ''' </summary>
    Public Sub loadIems()
        Try
            'set itemid to item class
            itemc.itemid = itemid
            'init datatable that hold data
            Dim result As New DataTable()
            'get data from item class
            result = itemc.loadIemsWhereID()
            'loop through
            For Each r0w As DataRow In result.Rows
                'assign values
                txtcode.Text = r0w("itemcode")
                current_itemcode = r0w("itemcode")
                txtname.Text = r0w("itemname")
                txtdescription.Text = r0w("description")
                txtprice.Text = CDbl(r0w("price")).ToString("n2")
                cmbcategory.SelectedItem = r0w("category")
                chck.Checked = IIf(CInt(r0w("deposit")) = 1, True, False)
                txtdepositprice.Text = CDbl(r0w("deposit_price")).ToString("n2")
            Next
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
            MessageBox.Show("Code field Is empty", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'focus
            txtcode.Focus()
            'check if item name is empty
        ElseIf String.IsNullOrEmpty(txtname.Text) Then
            'msg
            MessageBox.Show("Item field Is empty", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'focus
            txtname.Focus()
            'check if description is empty
        ElseIf String.IsNullOrEmpty(txtdescription.Text) Then
            'msg
            MessageBox.Show("Description field Is empty", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'focus
            txtdescription.Focus()
            'check if price is empty
        ElseIf String.IsNullOrEmpty(txtprice.Text) Then
            'msg
            MessageBox.Show("Price field Is empty", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'focus
            txtprice.Focus()
            'check if deposit price is empty
        ElseIf chck.Checked = True And String.IsNullOrEmpty(txtdepositprice.Text) Then
            'msg
            MessageBox.Show("Deposit Price field Is empty", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
    ''' add item
    ''' </summary>
    Public Sub addItem()
        'check if item name is already inserted in database
        itemc.itemName = txtname.Text
        If itemc.checkItem(txtname.Text) Then
            MessageBox.Show("Item is already exist", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'check inventory number
        ElseIf itemc.getInvID() = "N/A" Then
            MessageBox.Show("Created New Inventory first", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            'confirm dialog
            Dim a As String = MsgBox("Are you sure you want to add item?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Add Item")
            'check if user click ok button
            If a = vbYes Then
                'assign values
                itemc.setCategory(cmbcategory.Text)
                itemc.itemName = txtname.Text
                itemc.itemcode = txtcode.Text
                itemc.description = txtdescription.Text
                itemc.price = CDbl(txtprice.Text)
                itemc.chck = IIf(chck.Checked, 1, 0)
                'check if checkbox deposit is checked
                If chck.Checked Then
                    'assign deposit price if true
                    itemc.depositPrice = CDbl(txtdepositprice.Text)
                Else
                    'assign zero if false
                    itemc.depositPrice = 0.00
                End If
                'call addItem sub from item_class
                itemc.addItem()
                'close the form
                Me.Close()
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
        If txtname.Text <> current_itemname And itemc.checkItem(txtname.Text) Then
            'msg error
            MessageBox.Show("Item Name is already exist", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            'assign values
            itemc.itemid = itemid
            itemc.setCategory(cmbcategory.Text)
            itemc.itemName = txtname.Text
            itemc.itemcode = txtcode.Text
            itemc.description = txtdescription.Text
            itemc.price = CDbl(txtprice.Text)
            itemc.chck = IIf(chck.Checked, 1, 0)
            'check if check box deposit is checked
            If chck.Checked Then
                'assign deposit price if true
                itemc.depositPrice = CDbl(txtdepositprice.Text)
            Else
                'assign zero if false
                itemc.depositPrice = 0.00
            End If
            'call updateItem sub to item class
            itemc.updateItem(current_itemcode, current_itemname)
            'close the form
            Me.Close()
        End If
    End Sub
End Class