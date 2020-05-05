<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class endingbalance
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle26 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle27 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblDateNow = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.lblID = New System.Windows.Forms.Label()
        Me.lblSelectedItemCount = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblListItemCount = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.panelQuantity = New System.Windows.Forms.Panel()
        Me.txtname = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblcharge = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblQuantityCategory = New System.Windows.Forms.Label()
        Me.lblQuantityItemCode = New System.Windows.Forms.Label()
        Me.lblQuantityItemName = New System.Windows.Forms.Label()
        Me.lblClose = New System.Windows.Forms.Label()
        Me.txtboxQuantity = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnQuantity = New System.Windows.Forms.Button()
        Me.dgvSelectedItem = New System.Windows.Forms.DataGridView()
        Me.itemcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.itemname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.category = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.quantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.charge = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.employee = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtboxSelectedItem = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbCategoryListItem = New System.Windows.Forms.ComboBox()
        Me.btnSearchListItem = New System.Windows.Forms.Button()
        Me.txtboxListItemSearch = New System.Windows.Forms.TextBox()
        Me.dgvListItem = New System.Windows.Forms.DataGridView()
        Me.itemcodee = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.itemnamee = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.categoryy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnadd = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.rb1 = New System.Windows.Forms.RadioButton()
        Me.rb2 = New System.Windows.Forms.RadioButton()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.btnimport = New System.Windows.Forms.Button()
        Me.panelremarks = New System.Windows.Forms.Panel()
        Me.btnok = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtboxremarks = New System.Windows.Forms.TextBox()
        Me.lblcloseremarks = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.panelQuantity.SuspendLayout()
        CType(Me.dgvSelectedItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvListItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelremarks.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial Rounded MT Bold", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.ForestGreen
        Me.Label6.Location = New System.Drawing.Point(618, 66)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(206, 32)
        Me.Label6.TabIndex = 44
        Me.Label6.Text = "INVENTORY #:"
        Me.Label6.Visible = False
        '
        'lblDateNow
        '
        Me.lblDateNow.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDateNow.AutoSize = True
        Me.lblDateNow.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDateNow.Location = New System.Drawing.Point(972, 73)
        Me.lblDateNow.Name = "lblDateNow"
        Me.lblDateNow.Size = New System.Drawing.Size(177, 22)
        Me.lblDateNow.TabIndex = 45
        Me.lblDateNow.Text = "DATE_TIME_NOW"
        Me.lblDateNow.Visible = False
        '
        'lblID
        '
        Me.lblID.AutoSize = True
        Me.lblID.Font = New System.Drawing.Font("Arial Rounded MT Bold", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblID.ForeColor = System.Drawing.Color.ForestGreen
        Me.lblID.Location = New System.Drawing.Point(799, 44)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(70, 32)
        Me.lblID.TabIndex = 43
        Me.lblID.Text = " N/A"
        Me.lblID.Visible = False
        '
        'lblSelectedItemCount
        '
        Me.lblSelectedItemCount.AutoSize = True
        Me.lblSelectedItemCount.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelectedItemCount.ForeColor = System.Drawing.Color.White
        Me.lblSelectedItemCount.Location = New System.Drawing.Point(90, 5)
        Me.lblSelectedItemCount.Name = "lblSelectedItemCount"
        Me.lblSelectedItemCount.Size = New System.Drawing.Size(15, 15)
        Me.lblSelectedItemCount.TabIndex = 42
        Me.lblSelectedItemCount.Text = "0"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(3, 5)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(89, 15)
        Me.Label9.TabIndex = 41
        Me.Label9.Text = "TOTAL ITEM:"
        '
        'lblListItemCount
        '
        Me.lblListItemCount.AutoSize = True
        Me.lblListItemCount.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblListItemCount.ForeColor = System.Drawing.Color.White
        Me.lblListItemCount.Location = New System.Drawing.Point(90, 4)
        Me.lblListItemCount.Name = "lblListItemCount"
        Me.lblListItemCount.Size = New System.Drawing.Size(15, 15)
        Me.lblListItemCount.TabIndex = 40
        Me.lblListItemCount.Text = "0"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(3, 3)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(89, 15)
        Me.Label7.TabIndex = 39
        Me.Label7.Text = "TOTAL ITEM:"
        '
        'btnSubmit
        '
        Me.btnSubmit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSubmit.BackColor = System.Drawing.Color.ForestGreen
        Me.btnSubmit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSubmit.FlatAppearance.BorderSize = 0
        Me.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSubmit.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSubmit.ForeColor = System.Drawing.Color.White
        Me.btnSubmit.Location = New System.Drawing.Point(1172, 636)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(147, 47)
        Me.btnSubmit.TabIndex = 29
        Me.btnSubmit.Text = "SUBMIT"
        Me.btnSubmit.UseVisualStyleBackColor = False
        '
        'panelQuantity
        '
        Me.panelQuantity.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.panelQuantity.BackColor = System.Drawing.SystemColors.Highlight
        Me.panelQuantity.Controls.Add(Me.txtname)
        Me.panelQuantity.Controls.Add(Me.Label10)
        Me.panelQuantity.Controls.Add(Me.lblcharge)
        Me.panelQuantity.Controls.Add(Me.Label4)
        Me.panelQuantity.Controls.Add(Me.lblQuantityCategory)
        Me.panelQuantity.Controls.Add(Me.lblQuantityItemCode)
        Me.panelQuantity.Controls.Add(Me.lblQuantityItemName)
        Me.panelQuantity.Controls.Add(Me.lblClose)
        Me.panelQuantity.Controls.Add(Me.txtboxQuantity)
        Me.panelQuantity.Controls.Add(Me.Label5)
        Me.panelQuantity.Controls.Add(Me.btnQuantity)
        Me.panelQuantity.Location = New System.Drawing.Point(440, 214)
        Me.panelQuantity.Name = "panelQuantity"
        Me.panelQuantity.Size = New System.Drawing.Size(371, 382)
        Me.panelQuantity.TabIndex = 36
        Me.panelQuantity.Visible = False
        '
        'txtname
        '
        Me.txtname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtname.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtname.Location = New System.Drawing.Point(39, 279)
        Me.txtname.Name = "txtname"
        Me.txtname.ShortcutsEnabled = False
        Me.txtname.Size = New System.Drawing.Size(289, 29)
        Me.txtname.TabIndex = 10
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(36, 249)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(189, 18)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Enter Name Employee:"
        '
        'lblcharge
        '
        Me.lblcharge.AutoSize = True
        Me.lblcharge.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcharge.ForeColor = System.Drawing.Color.White
        Me.lblcharge.Location = New System.Drawing.Point(185, 215)
        Me.lblcharge.Name = "lblcharge"
        Me.lblcharge.Size = New System.Drawing.Size(18, 18)
        Me.lblcharge.TabIndex = 8
        Me.lblcharge.Text = "0"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(35, 215)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(144, 18)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Charge Quantity:"
        '
        'lblQuantityCategory
        '
        Me.lblQuantityCategory.AutoSize = True
        Me.lblQuantityCategory.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQuantityCategory.ForeColor = System.Drawing.Color.White
        Me.lblQuantityCategory.Location = New System.Drawing.Point(35, 92)
        Me.lblQuantityCategory.Name = "lblQuantityCategory"
        Me.lblQuantityCategory.Size = New System.Drawing.Size(87, 18)
        Me.lblQuantityCategory.TabIndex = 6
        Me.lblQuantityCategory.Text = "Category:"
        '
        'lblQuantityItemCode
        '
        Me.lblQuantityItemCode.AutoSize = True
        Me.lblQuantityItemCode.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQuantityItemCode.ForeColor = System.Drawing.Color.White
        Me.lblQuantityItemCode.Location = New System.Drawing.Point(35, 20)
        Me.lblQuantityItemCode.Name = "lblQuantityItemCode"
        Me.lblQuantityItemCode.Size = New System.Drawing.Size(94, 18)
        Me.lblQuantityItemCode.TabIndex = 5
        Me.lblQuantityItemCode.Text = "Item Code:"
        Me.lblQuantityItemCode.Visible = False
        '
        'lblQuantityItemName
        '
        Me.lblQuantityItemName.AutoSize = True
        Me.lblQuantityItemName.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQuantityItemName.ForeColor = System.Drawing.Color.White
        Me.lblQuantityItemName.Location = New System.Drawing.Point(36, 60)
        Me.lblQuantityItemName.Name = "lblQuantityItemName"
        Me.lblQuantityItemName.Size = New System.Drawing.Size(98, 18)
        Me.lblQuantityItemName.TabIndex = 4
        Me.lblQuantityItemName.Text = "Item Name:"
        '
        'lblClose
        '
        Me.lblClose.AutoSize = True
        Me.lblClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblClose.Font = New System.Drawing.Font("Arial Rounded MT Bold", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClose.ForeColor = System.Drawing.Color.White
        Me.lblClose.Location = New System.Drawing.Point(345, 0)
        Me.lblClose.Name = "lblClose"
        Me.lblClose.Size = New System.Drawing.Size(26, 28)
        Me.lblClose.TabIndex = 3
        Me.lblClose.Text = "X"
        Me.ToolTip1.SetToolTip(Me.lblClose, "Close")
        '
        'txtboxQuantity
        '
        Me.txtboxQuantity.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtboxQuantity.Location = New System.Drawing.Point(39, 154)
        Me.txtboxQuantity.Name = "txtboxQuantity"
        Me.txtboxQuantity.ShortcutsEnabled = False
        Me.txtboxQuantity.Size = New System.Drawing.Size(289, 29)
        Me.txtboxQuantity.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(36, 124)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(126, 18)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Enter quantity:"
        '
        'btnQuantity
        '
        Me.btnQuantity.BackColor = System.Drawing.Color.ForestGreen
        Me.btnQuantity.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnQuantity.FlatAppearance.BorderSize = 0
        Me.btnQuantity.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnQuantity.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnQuantity.ForeColor = System.Drawing.Color.White
        Me.btnQuantity.Location = New System.Drawing.Point(201, 331)
        Me.btnQuantity.Name = "btnQuantity"
        Me.btnQuantity.Size = New System.Drawing.Size(129, 31)
        Me.btnQuantity.TabIndex = 0
        Me.btnQuantity.Text = "Proceed"
        Me.btnQuantity.UseVisualStyleBackColor = False
        '
        'dgvSelectedItem
        '
        Me.dgvSelectedItem.AllowUserToAddRows = False
        Me.dgvSelectedItem.AllowUserToResizeRows = False
        Me.dgvSelectedItem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvSelectedItem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvSelectedItem.BackgroundColor = System.Drawing.Color.White
        Me.dgvSelectedItem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvSelectedItem.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle19.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        DataGridViewCellStyle19.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle19.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSelectedItem.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle19
        Me.dgvSelectedItem.ColumnHeadersHeight = 40
        Me.dgvSelectedItem.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.itemcode, Me.itemname, Me.category, Me.quantity, Me.charge, Me.employee, Me.Column6, Me.Column3})
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle22.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle22.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle22.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvSelectedItem.DefaultCellStyle = DataGridViewCellStyle22
        Me.dgvSelectedItem.EnableHeadersVisualStyles = False
        Me.dgvSelectedItem.GridColor = System.Drawing.Color.White
        Me.dgvSelectedItem.Location = New System.Drawing.Point(36, 463)
        Me.dgvSelectedItem.Name = "dgvSelectedItem"
        Me.dgvSelectedItem.ReadOnly = True
        DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle23.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle23.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle23.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSelectedItem.RowHeadersDefaultCellStyle = DataGridViewCellStyle23
        Me.dgvSelectedItem.RowHeadersVisible = False
        Me.dgvSelectedItem.RowHeadersWidth = 50
        Me.dgvSelectedItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSelectedItem.Size = New System.Drawing.Size(1283, 153)
        Me.dgvSelectedItem.TabIndex = 38
        '
        'itemcode
        '
        Me.itemcode.HeaderText = "Item Code"
        Me.itemcode.Name = "itemcode"
        Me.itemcode.ReadOnly = True
        Me.itemcode.Visible = False
        '
        'itemname
        '
        Me.itemname.HeaderText = "Item"
        Me.itemname.Name = "itemname"
        Me.itemname.ReadOnly = True
        '
        'category
        '
        Me.category.HeaderText = "Category"
        Me.category.Name = "category"
        Me.category.ReadOnly = True
        '
        'quantity
        '
        Me.quantity.HeaderText = "Quantity"
        Me.quantity.Name = "quantity"
        Me.quantity.ReadOnly = True
        '
        'charge
        '
        Me.charge.HeaderText = "Charge"
        Me.charge.Name = "charge"
        Me.charge.ReadOnly = True
        '
        'employee
        '
        Me.employee.HeaderText = "Employee"
        Me.employee.Name = "employee"
        Me.employee.ReadOnly = True
        '
        'Column6
        '
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle20.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle20.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle20.ForeColor = System.Drawing.Color.White
        Me.Column6.DefaultCellStyle = DataGridViewCellStyle20
        Me.Column6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Column6.HeaderText = "Update Quantity"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Text = "Update"
        Me.Column6.ToolTipText = "Update Quantity"
        Me.Column6.UseColumnTextForButtonValue = True
        '
        'Column3
        '
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle21.BackColor = System.Drawing.Color.Firebrick
        DataGridViewCellStyle21.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle21.ForeColor = System.Drawing.Color.White
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle21
        Me.Column3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Column3.HeaderText = "Remove Item"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column3.Text = "Remove"
        Me.Column3.ToolTipText = "Remove Item"
        Me.Column3.UseColumnTextForButtonValue = True
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(1244, 414)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 25)
        Me.Button2.TabIndex = 35
        Me.Button2.Text = "Search"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'txtboxSelectedItem
        '
        Me.txtboxSelectedItem.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtboxSelectedItem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtboxSelectedItem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtboxSelectedItem.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtboxSelectedItem.ForeColor = System.Drawing.Color.Black
        Me.txtboxSelectedItem.Location = New System.Drawing.Point(1042, 414)
        Me.txtboxSelectedItem.Name = "txtboxSelectedItem"
        Me.txtboxSelectedItem.ShortcutsEnabled = False
        Me.txtboxSelectedItem.Size = New System.Drawing.Size(203, 25)
        Me.txtboxSelectedItem.TabIndex = 34
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DimGray
        Me.Label1.Location = New System.Drawing.Point(326, 146)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 12)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "Category:"
        '
        'cmbCategoryListItem
        '
        Me.cmbCategoryListItem.BackColor = System.Drawing.SystemColors.HotTrack
        Me.cmbCategoryListItem.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbCategoryListItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCategoryListItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbCategoryListItem.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCategoryListItem.ForeColor = System.Drawing.Color.White
        Me.cmbCategoryListItem.FormattingEnabled = True
        Me.cmbCategoryListItem.Location = New System.Drawing.Point(391, 138)
        Me.cmbCategoryListItem.Name = "cmbCategoryListItem"
        Me.cmbCategoryListItem.Size = New System.Drawing.Size(141, 26)
        Me.cmbCategoryListItem.TabIndex = 32
        '
        'btnSearchListItem
        '
        Me.btnSearchListItem.BackColor = System.Drawing.SystemColors.HotTrack
        Me.btnSearchListItem.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSearchListItem.FlatAppearance.BorderSize = 0
        Me.btnSearchListItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchListItem.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearchListItem.ForeColor = System.Drawing.Color.White
        Me.btnSearchListItem.Location = New System.Drawing.Point(238, 138)
        Me.btnSearchListItem.Name = "btnSearchListItem"
        Me.btnSearchListItem.Size = New System.Drawing.Size(75, 25)
        Me.btnSearchListItem.TabIndex = 31
        Me.btnSearchListItem.Text = "Search"
        Me.btnSearchListItem.UseVisualStyleBackColor = False
        '
        'txtboxListItemSearch
        '
        Me.txtboxListItemSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtboxListItemSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtboxListItemSearch.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtboxListItemSearch.ForeColor = System.Drawing.Color.Black
        Me.txtboxListItemSearch.Location = New System.Drawing.Point(36, 138)
        Me.txtboxListItemSearch.Name = "txtboxListItemSearch"
        Me.txtboxListItemSearch.ShortcutsEnabled = False
        Me.txtboxListItemSearch.Size = New System.Drawing.Size(203, 25)
        Me.txtboxListItemSearch.TabIndex = 30
        '
        'dgvListItem
        '
        Me.dgvListItem.AllowUserToAddRows = False
        Me.dgvListItem.AllowUserToResizeRows = False
        Me.dgvListItem.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvListItem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvListItem.BackgroundColor = System.Drawing.Color.White
        Me.dgvListItem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvListItem.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle24.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        DataGridViewCellStyle24.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle24.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvListItem.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle24
        Me.dgvListItem.ColumnHeadersHeight = 40
        Me.dgvListItem.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.itemcodee, Me.itemnamee, Me.categoryy, Me.btnadd})
        DataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle26.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle26.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle26.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle26.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle26.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvListItem.DefaultCellStyle = DataGridViewCellStyle26
        Me.dgvListItem.EnableHeadersVisualStyles = False
        Me.dgvListItem.GridColor = System.Drawing.Color.White
        Me.dgvListItem.Location = New System.Drawing.Point(36, 190)
        Me.dgvListItem.Name = "dgvListItem"
        Me.dgvListItem.ReadOnly = True
        DataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle27.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle27.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle27.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle27.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle27.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvListItem.RowHeadersDefaultCellStyle = DataGridViewCellStyle27
        Me.dgvListItem.RowHeadersVisible = False
        Me.dgvListItem.RowHeadersWidth = 50
        Me.dgvListItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvListItem.Size = New System.Drawing.Size(1283, 179)
        Me.dgvListItem.TabIndex = 26
        '
        'itemcodee
        '
        Me.itemcodee.HeaderText = "Item Code"
        Me.itemcodee.Name = "itemcodee"
        Me.itemcodee.ReadOnly = True
        Me.itemcodee.Visible = False
        '
        'itemnamee
        '
        Me.itemnamee.HeaderText = "Item"
        Me.itemnamee.Name = "itemnamee"
        Me.itemnamee.ReadOnly = True
        '
        'categoryy
        '
        Me.categoryy.HeaderText = "Category"
        Me.categoryy.Name = "categoryy"
        Me.categoryy.ReadOnly = True
        '
        'btnadd
        '
        DataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle25.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle25.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle25.ForeColor = System.Drawing.Color.White
        Me.btnadd.DefaultCellStyle = DataGridViewCellStyle25
        Me.btnadd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnadd.HeaderText = "Add Quantity"
        Me.btnadd.Name = "btnadd"
        Me.btnadd.ReadOnly = True
        Me.btnadd.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.btnadd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.btnadd.Text = "Add"
        Me.btnadd.ToolTipText = "Add Quantity"
        Me.btnadd.UseColumnTextForButtonValue = True
        '
        'rb1
        '
        Me.rb1.AutoSize = True
        Me.rb1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rb1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb1.ForeColor = System.Drawing.Color.Black
        Me.rb1.Location = New System.Drawing.Point(33, 66)
        Me.rb1.Name = "rb1"
        Me.rb1.Size = New System.Drawing.Size(191, 21)
        Me.rb1.TabIndex = 46
        Me.rb1.Text = "Actual Ending Balance"
        Me.rb1.UseVisualStyleBackColor = True
        Me.rb1.Visible = False
        '
        'rb2
        '
        Me.rb2.AutoSize = True
        Me.rb2.Checked = True
        Me.rb2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rb2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb2.ForeColor = System.Drawing.Color.Black
        Me.rb2.Location = New System.Drawing.Point(246, 66)
        Me.rb2.Name = "rb2"
        Me.rb2.Size = New System.Drawing.Size(224, 21)
        Me.rb2.TabIndex = 47
        Me.rb2.TabStop = True
        Me.rb2.Text = "Non Actual Ending Balance"
        Me.rb2.UseVisualStyleBackColor = True
        Me.rb2.Visible = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(654, 44)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 48
        Me.TextBox1.Visible = False
        '
        'btnimport
        '
        Me.btnimport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnimport.BackColor = System.Drawing.Color.ForestGreen
        Me.btnimport.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnimport.FlatAppearance.BorderSize = 0
        Me.btnimport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnimport.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnimport.ForeColor = System.Drawing.Color.White
        Me.btnimport.Location = New System.Drawing.Point(1019, 636)
        Me.btnimport.Name = "btnimport"
        Me.btnimport.Size = New System.Drawing.Size(147, 47)
        Me.btnimport.TabIndex = 49
        Me.btnimport.Text = "IMPORT"
        Me.btnimport.UseVisualStyleBackColor = False
        Me.btnimport.Visible = False
        '
        'panelremarks
        '
        Me.panelremarks.BackColor = System.Drawing.SystemColors.Highlight
        Me.panelremarks.Controls.Add(Me.btnok)
        Me.panelremarks.Controls.Add(Me.Label2)
        Me.panelremarks.Controls.Add(Me.txtboxremarks)
        Me.panelremarks.Controls.Add(Me.lblcloseremarks)
        Me.panelremarks.Location = New System.Drawing.Point(406, 198)
        Me.panelremarks.Name = "panelremarks"
        Me.panelremarks.Size = New System.Drawing.Size(418, 200)
        Me.panelremarks.TabIndex = 50
        Me.panelremarks.Visible = False
        '
        'btnok
        '
        Me.btnok.BackColor = System.Drawing.Color.ForestGreen
        Me.btnok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnok.FlatAppearance.BorderSize = 0
        Me.btnok.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnok.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnok.ForeColor = System.Drawing.Color.White
        Me.btnok.Location = New System.Drawing.Point(301, 151)
        Me.btnok.Name = "btnok"
        Me.btnok.Size = New System.Drawing.Size(96, 31)
        Me.btnok.TabIndex = 3
        Me.btnok.Text = "OK"
        Me.btnok.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(13, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 22)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Remarks:"
        '
        'txtboxremarks
        '
        Me.txtboxremarks.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtboxremarks.Location = New System.Drawing.Point(17, 54)
        Me.txtboxremarks.Multiline = True
        Me.txtboxremarks.Name = "txtboxremarks"
        Me.txtboxremarks.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.txtboxremarks.Size = New System.Drawing.Size(380, 81)
        Me.txtboxremarks.TabIndex = 1
        '
        'lblcloseremarks
        '
        Me.lblcloseremarks.AutoSize = True
        Me.lblcloseremarks.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblcloseremarks.Font = New System.Drawing.Font("Arial Rounded MT Bold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcloseremarks.ForeColor = System.Drawing.Color.White
        Me.lblcloseremarks.Location = New System.Drawing.Point(390, 0)
        Me.lblcloseremarks.Name = "lblcloseremarks"
        Me.lblcloseremarks.Size = New System.Drawing.Size(23, 24)
        Me.lblcloseremarks.TabIndex = 0
        Me.lblcloseremarks.Text = "X"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1344, 38)
        Me.Panel1.TabIndex = 51
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Gold
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1, 38)
        Me.Panel2.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(12, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(354, 22)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "UPDATE ACTUAL ENDING BALANCE"
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.lblListItemCount)
        Me.Panel3.Location = New System.Drawing.Point(36, 169)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1283, 23)
        Me.Panel3.TabIndex = 52
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.Panel4.Controls.Add(Me.Label9)
        Me.Panel4.Controls.Add(Me.lblSelectedItemCount)
        Me.Panel4.Location = New System.Drawing.Point(36, 440)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1283, 23)
        Me.Panel4.TabIndex = 53
        '
        'endingbalance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1344, 738)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.panelremarks)
        Me.Controls.Add(Me.panelQuantity)
        Me.Controls.Add(Me.btnimport)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.rb2)
        Me.Controls.Add(Me.rb1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lblDateNow)
        Me.Controls.Add(Me.lblID)
        Me.Controls.Add(Me.btnSubmit)
        Me.Controls.Add(Me.dgvSelectedItem)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.txtboxSelectedItem)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbCategoryListItem)
        Me.Controls.Add(Me.btnSearchListItem)
        Me.Controls.Add(Me.txtboxListItemSearch)
        Me.Controls.Add(Me.dgvListItem)
        Me.Controls.Add(Me.Panel4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "endingbalance"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Actual Ending Balance"
        Me.panelQuantity.ResumeLayout(False)
        Me.panelQuantity.PerformLayout()
        CType(Me.dgvSelectedItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvListItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelremarks.ResumeLayout(False)
        Me.panelremarks.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblDateNow As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents lblID As System.Windows.Forms.Label
    Friend WithEvents lblSelectedItemCount As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblListItemCount As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnSubmit As System.Windows.Forms.Button
    Friend WithEvents panelQuantity As System.Windows.Forms.Panel
    Friend WithEvents lblQuantityCategory As System.Windows.Forms.Label
    Friend WithEvents lblQuantityItemCode As System.Windows.Forms.Label
    Friend WithEvents lblQuantityItemName As System.Windows.Forms.Label
    Friend WithEvents lblClose As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents txtboxQuantity As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnQuantity As System.Windows.Forms.Button
    Friend WithEvents dgvSelectedItem As System.Windows.Forms.DataGridView
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents txtboxSelectedItem As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbCategoryListItem As System.Windows.Forms.ComboBox
    Friend WithEvents btnSearchListItem As System.Windows.Forms.Button
    Friend WithEvents txtboxListItemSearch As System.Windows.Forms.TextBox
    Friend WithEvents dgvListItem As System.Windows.Forms.DataGridView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtname As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblcharge As System.Windows.Forms.Label
    Friend WithEvents rb1 As RadioButton
    Friend WithEvents rb2 As RadioButton
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents itemcodee As DataGridViewTextBoxColumn
    Friend WithEvents itemnamee As DataGridViewTextBoxColumn
    Friend WithEvents categoryy As DataGridViewTextBoxColumn
    Friend WithEvents btnadd As DataGridViewButtonColumn
    Friend WithEvents itemcode As DataGridViewTextBoxColumn
    Friend WithEvents itemname As DataGridViewTextBoxColumn
    Friend WithEvents category As DataGridViewTextBoxColumn
    Friend WithEvents quantity As DataGridViewTextBoxColumn
    Friend WithEvents charge As DataGridViewTextBoxColumn
    Friend WithEvents employee As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewButtonColumn
    Friend WithEvents Column3 As DataGridViewButtonColumn
    Friend WithEvents btnimport As Button
    Friend WithEvents panelremarks As Panel
    Friend WithEvents txtboxremarks As TextBox
    Friend WithEvents lblcloseremarks As Label
    Friend WithEvents btnok As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
End Class
