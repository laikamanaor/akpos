<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class chargetoemployee
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvSelectedItem = New System.Windows.Forms.DataGridView()
        Me.itemcodee = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.itemnamee = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.categoryy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.quantityy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.reject = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.charge = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.updatequantity = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.deletequantity = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.txtboxSelectedItem = New System.Windows.Forms.TextBox()
        Me.cmbCategoryListItem = New System.Windows.Forms.ComboBox()
        Me.btnSearchListItem = New System.Windows.Forms.Button()
        Me.txtboxListItemSearch = New System.Windows.Forms.TextBox()
        Me.dgvListItem = New System.Windows.Forms.DataGridView()
        Me.itemcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.itemname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblID = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblTransactionID = New System.Windows.Forms.Label()
        Me.lblListItemCount = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.panelQuantity = New System.Windows.Forms.Panel()
        Me.lblQuantityCategory = New System.Windows.Forms.Label()
        Me.lblQuantityItemCode = New System.Windows.Forms.Label()
        Me.lblQuantityItemName = New System.Windows.Forms.Label()
        Me.lblClose = New System.Windows.Forms.Label()
        Me.txtboxQuantity = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnQuantity = New System.Windows.Forms.Button()
        CType(Me.dgvSelectedItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvListItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelQuantity.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvSelectedItem
        '
        Me.dgvSelectedItem.AllowUserToAddRows = False
        Me.dgvSelectedItem.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.dgvSelectedItem.BackgroundColor = System.Drawing.Color.White
        Me.dgvSelectedItem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvSelectedItem.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSelectedItem.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvSelectedItem.ColumnHeadersHeight = 40
        Me.dgvSelectedItem.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.itemcodee, Me.itemnamee, Me.categoryy, Me.quantityy, Me.reject, Me.charge, Me.updatequantity, Me.deletequantity})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvSelectedItem.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvSelectedItem.EnableHeadersVisualStyles = False
        Me.dgvSelectedItem.GridColor = System.Drawing.Color.White
        Me.dgvSelectedItem.Location = New System.Drawing.Point(731, 221)
        Me.dgvSelectedItem.Name = "dgvSelectedItem"
        Me.dgvSelectedItem.ReadOnly = True
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSelectedItem.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvSelectedItem.RowHeadersVisible = False
        Me.dgvSelectedItem.RowHeadersWidth = 50
        Me.dgvSelectedItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSelectedItem.Size = New System.Drawing.Size(536, 350)
        Me.dgvSelectedItem.TabIndex = 21
        '
        'itemcodee
        '
        Me.itemcodee.HeaderText = "Item Code"
        Me.itemcodee.Name = "itemcodee"
        Me.itemcodee.ReadOnly = True
        Me.itemcodee.Width = 67
        '
        'itemnamee
        '
        Me.itemnamee.HeaderText = "Item"
        Me.itemnamee.Name = "itemnamee"
        Me.itemnamee.ReadOnly = True
        Me.itemnamee.Width = 66
        '
        'categoryy
        '
        Me.categoryy.HeaderText = "Category"
        Me.categoryy.Name = "categoryy"
        Me.categoryy.ReadOnly = True
        Me.categoryy.Width = 67
        '
        'quantityy
        '
        Me.quantityy.HeaderText = "Good"
        Me.quantityy.Name = "quantityy"
        Me.quantityy.ReadOnly = True
        '
        'reject
        '
        Me.reject.HeaderText = "Reject"
        Me.reject.Name = "reject"
        Me.reject.ReadOnly = True
        '
        'charge
        '
        Me.charge.HeaderText = "Charge"
        Me.charge.Name = "charge"
        Me.charge.ReadOnly = True
        '
        'updatequantity
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        Me.updatequantity.DefaultCellStyle = DataGridViewCellStyle2
        Me.updatequantity.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.updatequantity.HeaderText = "Update Quantity"
        Me.updatequantity.Name = "updatequantity"
        Me.updatequantity.ReadOnly = True
        Me.updatequantity.Text = "Update"
        Me.updatequantity.ToolTipText = "Update Quantity"
        Me.updatequantity.UseColumnTextForButtonValue = True
        '
        'deletequantity
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Firebrick
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White
        Me.deletequantity.DefaultCellStyle = DataGridViewCellStyle3
        Me.deletequantity.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.deletequantity.HeaderText = "Delete Item"
        Me.deletequantity.Name = "deletequantity"
        Me.deletequantity.ReadOnly = True
        Me.deletequantity.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.deletequantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.deletequantity.Text = "Delete"
        Me.deletequantity.ToolTipText = "Delete Item"
        Me.deletequantity.UseColumnTextForButtonValue = True
        '
        'Button2
        '
        Me.Button2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Button2.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(933, 191)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 25)
        Me.Button2.TabIndex = 20
        Me.Button2.Text = "Search"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'txtboxSelectedItem
        '
        Me.txtboxSelectedItem.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtboxSelectedItem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtboxSelectedItem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtboxSelectedItem.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtboxSelectedItem.ForeColor = System.Drawing.Color.Black
        Me.txtboxSelectedItem.Location = New System.Drawing.Point(731, 191)
        Me.txtboxSelectedItem.Name = "txtboxSelectedItem"
        Me.txtboxSelectedItem.ShortcutsEnabled = False
        Me.txtboxSelectedItem.Size = New System.Drawing.Size(203, 25)
        Me.txtboxSelectedItem.TabIndex = 19
        '
        'cmbCategoryListItem
        '
        Me.cmbCategoryListItem.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmbCategoryListItem.BackColor = System.Drawing.SystemColors.HotTrack
        Me.cmbCategoryListItem.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbCategoryListItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCategoryListItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbCategoryListItem.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCategoryListItem.ForeColor = System.Drawing.Color.White
        Me.cmbCategoryListItem.FormattingEnabled = True
        Me.cmbCategoryListItem.Location = New System.Drawing.Point(510, 190)
        Me.cmbCategoryListItem.Name = "cmbCategoryListItem"
        Me.cmbCategoryListItem.Size = New System.Drawing.Size(141, 26)
        Me.cmbCategoryListItem.TabIndex = 18
        '
        'btnSearchListItem
        '
        Me.btnSearchListItem.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnSearchListItem.BackColor = System.Drawing.SystemColors.HotTrack
        Me.btnSearchListItem.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSearchListItem.FlatAppearance.BorderSize = 0
        Me.btnSearchListItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchListItem.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearchListItem.ForeColor = System.Drawing.Color.White
        Me.btnSearchListItem.Location = New System.Drawing.Point(317, 190)
        Me.btnSearchListItem.Name = "btnSearchListItem"
        Me.btnSearchListItem.Size = New System.Drawing.Size(75, 25)
        Me.btnSearchListItem.TabIndex = 17
        Me.btnSearchListItem.Text = "Search"
        Me.btnSearchListItem.UseVisualStyleBackColor = False
        '
        'txtboxListItemSearch
        '
        Me.txtboxListItemSearch.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtboxListItemSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtboxListItemSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtboxListItemSearch.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtboxListItemSearch.ForeColor = System.Drawing.Color.Black
        Me.txtboxListItemSearch.Location = New System.Drawing.Point(115, 190)
        Me.txtboxListItemSearch.Name = "txtboxListItemSearch"
        Me.txtboxListItemSearch.ShortcutsEnabled = False
        Me.txtboxListItemSearch.Size = New System.Drawing.Size(203, 25)
        Me.txtboxListItemSearch.TabIndex = 16
        '
        'dgvListItem
        '
        Me.dgvListItem.AllowUserToAddRows = False
        Me.dgvListItem.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.dgvListItem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvListItem.BackgroundColor = System.Drawing.Color.White
        Me.dgvListItem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvListItem.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer))
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvListItem.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvListItem.ColumnHeadersHeight = 40
        Me.dgvListItem.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.itemcode, Me.itemname, Me.Column7, Me.Column2})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvListItem.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgvListItem.EnableHeadersVisualStyles = False
        Me.dgvListItem.GridColor = System.Drawing.Color.White
        Me.dgvListItem.Location = New System.Drawing.Point(115, 221)
        Me.dgvListItem.Name = "dgvListItem"
        Me.dgvListItem.ReadOnly = True
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvListItem.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvListItem.RowHeadersVisible = False
        Me.dgvListItem.RowHeadersWidth = 50
        Me.dgvListItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvListItem.Size = New System.Drawing.Size(536, 350)
        Me.dgvListItem.TabIndex = 15
        '
        'itemcode
        '
        Me.itemcode.HeaderText = "Item Code"
        Me.itemcode.Name = "itemcode"
        Me.itemcode.ReadOnly = True
        '
        'itemname
        '
        Me.itemname.HeaderText = "Item"
        Me.itemname.Name = "itemname"
        Me.itemname.ReadOnly = True
        '
        'Column7
        '
        Me.Column7.HeaderText = "Category"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'Column2
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.White
        Me.Column2.DefaultCellStyle = DataGridViewCellStyle7
        Me.Column2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Column2.HeaderText = "Add Quantity"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column2.Text = "Add"
        Me.Column2.ToolTipText = "Add Quantity"
        Me.Column2.UseColumnTextForButtonValue = True
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(445, 197)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 12)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Category:"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(725, 105)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(196, 32)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "Selected Item"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(111, 105)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(160, 32)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "List of Item"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial Rounded MT Bold", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.ForestGreen
        Me.Label6.Location = New System.Drawing.Point(109, 27)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(206, 32)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "INVENTORY #:"
        '
        'lblID
        '
        Me.lblID.AutoSize = True
        Me.lblID.Font = New System.Drawing.Font("Arial Rounded MT Bold", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblID.ForeColor = System.Drawing.Color.ForestGreen
        Me.lblID.Location = New System.Drawing.Point(311, 27)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(70, 32)
        Me.lblID.TabIndex = 25
        Me.lblID.Text = " N/A"
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(113, 73)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(104, 22)
        Me.Label8.TabIndex = 28
        Me.Label8.Text = "TRANS. #:"
        '
        'lblTransactionID
        '
        Me.lblTransactionID.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblTransactionID.AutoSize = True
        Me.lblTransactionID.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTransactionID.Location = New System.Drawing.Point(223, 73)
        Me.lblTransactionID.Name = "lblTransactionID"
        Me.lblTransactionID.Size = New System.Drawing.Size(43, 22)
        Me.lblTransactionID.TabIndex = 27
        Me.lblTransactionID.Text = "N/A"
        '
        'lblListItemCount
        '
        Me.lblListItemCount.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblListItemCount.AutoSize = True
        Me.lblListItemCount.Font = New System.Drawing.Font("Arial Rounded MT Bold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblListItemCount.Location = New System.Drawing.Point(223, 574)
        Me.lblListItemCount.Name = "lblListItemCount"
        Me.lblListItemCount.Size = New System.Drawing.Size(22, 24)
        Me.lblListItemCount.TabIndex = 30
        Me.lblListItemCount.Text = "0"
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(112, 574)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(111, 18)
        Me.Label7.TabIndex = 29
        Me.Label7.Text = "TOTAL ITEM:"
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Rounded MT Bold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(839, 574)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(22, 24)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "0"
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(728, 574)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(111, 18)
        Me.Label5.TabIndex = 31
        Me.Label5.Text = "TOTAL ITEM:"
        '
        'btnSubmit
        '
        Me.btnSubmit.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnSubmit.BackColor = System.Drawing.Color.ForestGreen
        Me.btnSubmit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSubmit.FlatAppearance.BorderSize = 0
        Me.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSubmit.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSubmit.ForeColor = System.Drawing.Color.White
        Me.btnSubmit.Location = New System.Drawing.Point(1120, 604)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(147, 47)
        Me.btnSubmit.TabIndex = 33
        Me.btnSubmit.Text = "SUBMIT"
        Me.btnSubmit.UseVisualStyleBackColor = False
        '
        'panelQuantity
        '
        Me.panelQuantity.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.panelQuantity.BackColor = System.Drawing.SystemColors.Highlight
        Me.panelQuantity.Controls.Add(Me.lblQuantityCategory)
        Me.panelQuantity.Controls.Add(Me.lblQuantityItemCode)
        Me.panelQuantity.Controls.Add(Me.lblQuantityItemName)
        Me.panelQuantity.Controls.Add(Me.lblClose)
        Me.panelQuantity.Controls.Add(Me.txtboxQuantity)
        Me.panelQuantity.Controls.Add(Me.Label9)
        Me.panelQuantity.Controls.Add(Me.btnQuantity)
        Me.panelQuantity.Location = New System.Drawing.Point(468, 274)
        Me.panelQuantity.Name = "panelQuantity"
        Me.panelQuantity.Size = New System.Drawing.Size(371, 247)
        Me.panelQuantity.TabIndex = 34
        Me.panelQuantity.Visible = False
        '
        'lblQuantityCategory
        '
        Me.lblQuantityCategory.AutoSize = True
        Me.lblQuantityCategory.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQuantityCategory.ForeColor = System.Drawing.Color.White
        Me.lblQuantityCategory.Location = New System.Drawing.Point(36, 73)
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
        '
        'lblQuantityItemName
        '
        Me.lblQuantityItemName.AutoSize = True
        Me.lblQuantityItemName.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQuantityItemName.ForeColor = System.Drawing.Color.White
        Me.lblQuantityItemName.Location = New System.Drawing.Point(36, 45)
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
        '
        'txtboxQuantity
        '
        Me.txtboxQuantity.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtboxQuantity.Location = New System.Drawing.Point(39, 123)
        Me.txtboxQuantity.Multiline = True
        Me.txtboxQuantity.Name = "txtboxQuantity"
        Me.txtboxQuantity.ShortcutsEnabled = False
        Me.txtboxQuantity.Size = New System.Drawing.Size(289, 41)
        Me.txtboxQuantity.TabIndex = 2
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(36, 105)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(129, 18)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "Enter Quantity:"
        '
        'btnQuantity
        '
        Me.btnQuantity.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnQuantity.BackColor = System.Drawing.Color.ForestGreen
        Me.btnQuantity.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnQuantity.FlatAppearance.BorderSize = 0
        Me.btnQuantity.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnQuantity.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnQuantity.ForeColor = System.Drawing.Color.White
        Me.btnQuantity.Location = New System.Drawing.Point(199, 185)
        Me.btnQuantity.Name = "btnQuantity"
        Me.btnQuantity.Size = New System.Drawing.Size(129, 31)
        Me.btnQuantity.TabIndex = 0
        Me.btnQuantity.Text = "Add Quantity"
        Me.btnQuantity.UseVisualStyleBackColor = False
        '
        'chargetoemployee
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1344, 701)
        Me.Controls.Add(Me.panelQuantity)
        Me.Controls.Add(Me.btnSubmit)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblListItemCount)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.lblTransactionID)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lblID)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvSelectedItem)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.txtboxSelectedItem)
        Me.Controls.Add(Me.cmbCategoryListItem)
        Me.Controls.Add(Me.btnSearchListItem)
        Me.Controls.Add(Me.txtboxListItemSearch)
        Me.Controls.Add(Me.dgvListItem)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "chargetoemployee"
        Me.Text = "Charge to Employee"
        CType(Me.dgvSelectedItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvListItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelQuantity.ResumeLayout(False)
        Me.panelQuantity.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvSelectedItem As System.Windows.Forms.DataGridView
    Friend WithEvents itemcodee As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents itemnamee As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents categoryy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents quantityy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents reject As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents charge As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents updatequantity As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents deletequantity As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents txtboxSelectedItem As System.Windows.Forms.TextBox
    Friend WithEvents cmbCategoryListItem As System.Windows.Forms.ComboBox
    Friend WithEvents btnSearchListItem As System.Windows.Forms.Button
    Friend WithEvents txtboxListItemSearch As System.Windows.Forms.TextBox
    Friend WithEvents dgvListItem As System.Windows.Forms.DataGridView
    Friend WithEvents itemcode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents itemname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblID As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblTransactionID As System.Windows.Forms.Label
    Friend WithEvents lblListItemCount As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnSubmit As System.Windows.Forms.Button
    Friend WithEvents panelQuantity As System.Windows.Forms.Panel
    Friend WithEvents lblQuantityCategory As System.Windows.Forms.Label
    Friend WithEvents lblQuantityItemCode As System.Windows.Forms.Label
    Friend WithEvents lblQuantityItemName As System.Windows.Forms.Label
    Friend WithEvents lblClose As System.Windows.Forms.Label
    Friend WithEvents txtboxQuantity As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnQuantity As System.Windows.Forms.Button
End Class
