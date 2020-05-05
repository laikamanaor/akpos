<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class pulloutss
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dgvSelectedItem = New System.Windows.Forms.DataGridView()
        Me.itemcodee = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.itemnamee = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.categoryy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.quantityy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.updatequantity = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.deletequantity = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbCategoryListItem = New System.Windows.Forms.ComboBox()
        Me.btnSearchListItem = New System.Windows.Forms.Button()
        Me.txtboxListItemSearch = New System.Windows.Forms.TextBox()
        Me.dgvListItem = New System.Windows.Forms.DataGridView()
        Me.itemcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.itemname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.category = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.quantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.panelsap = New System.Windows.Forms.Panel()
        Me.rbtransfer = New System.Windows.Forms.RadioButton()
        Me.lblclosesap = New System.Windows.Forms.Label()
        Me.rbconvout = New System.Windows.Forms.RadioButton()
        Me.rbarcharge = New System.Windows.Forms.RadioButton()
        Me.rbarreject = New System.Windows.Forms.RadioButton()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtname = New System.Windows.Forms.TextBox()
        Me.lblSAPClose = New System.Windows.Forms.Label()
        Me.btnProceed = New System.Windows.Forms.Button()
        Me.lblsapdoc = New System.Windows.Forms.Label()
        Me.checkfollowup = New System.Windows.Forms.CheckBox()
        Me.txtsap = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtremarks = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.panelQuantity = New System.Windows.Forms.Panel()
        Me.lblQuantityCategory = New System.Windows.Forms.Label()
        Me.lblQuantityItemCode = New System.Windows.Forms.Label()
        Me.lblQuantityItemName = New System.Windows.Forms.Label()
        Me.lblClose = New System.Windows.Forms.Label()
        Me.txtboxQuantity = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnQuantity = New System.Windows.Forms.Button()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvSelectedItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvListItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.panelsap.SuspendLayout()
        Me.panelQuantity.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(36, 84)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1248, 24)
        Me.Panel1.TabIndex = 56
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(7, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(125, 18)
        Me.Label2.TabIndex = 49
        Me.Label2.Text = "LIST OF ITEMS"
        '
        'dgvSelectedItem
        '
        Me.dgvSelectedItem.AllowUserToAddRows = False
        Me.dgvSelectedItem.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvSelectedItem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
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
        Me.dgvSelectedItem.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.itemcodee, Me.itemnamee, Me.categoryy, Me.quantityy, Me.updatequantity, Me.deletequantity})
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
        Me.dgvSelectedItem.Location = New System.Drawing.Point(36, 412)
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
        Me.dgvSelectedItem.Size = New System.Drawing.Size(1248, 219)
        Me.dgvSelectedItem.TabIndex = 55
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
        'quantityy
        '
        Me.quantityy.HeaderText = "Quantity"
        Me.quantityy.Name = "quantityy"
        Me.quantityy.ReadOnly = True
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
        Me.deletequantity.HeaderText = "Remove Item"
        Me.deletequantity.Name = "deletequantity"
        Me.deletequantity.ReadOnly = True
        Me.deletequantity.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.deletequantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.deletequantity.Text = "Remove"
        Me.deletequantity.ToolTipText = "Remove Item"
        Me.deletequantity.UseColumnTextForButtonValue = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(366, 65)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 12)
        Me.Label1.TabIndex = 54
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
        Me.cmbCategoryListItem.Location = New System.Drawing.Point(431, 57)
        Me.cmbCategoryListItem.Name = "cmbCategoryListItem"
        Me.cmbCategoryListItem.Size = New System.Drawing.Size(141, 26)
        Me.cmbCategoryListItem.TabIndex = 53
        '
        'btnSearchListItem
        '
        Me.btnSearchListItem.BackColor = System.Drawing.SystemColors.HotTrack
        Me.btnSearchListItem.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSearchListItem.FlatAppearance.BorderSize = 0
        Me.btnSearchListItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchListItem.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearchListItem.ForeColor = System.Drawing.Color.White
        Me.btnSearchListItem.Location = New System.Drawing.Point(238, 58)
        Me.btnSearchListItem.Name = "btnSearchListItem"
        Me.btnSearchListItem.Size = New System.Drawing.Size(75, 25)
        Me.btnSearchListItem.TabIndex = 52
        Me.btnSearchListItem.Text = "Search"
        Me.btnSearchListItem.UseVisualStyleBackColor = False
        '
        'txtboxListItemSearch
        '
        Me.txtboxListItemSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtboxListItemSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtboxListItemSearch.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtboxListItemSearch.ForeColor = System.Drawing.Color.Black
        Me.txtboxListItemSearch.Location = New System.Drawing.Point(36, 58)
        Me.txtboxListItemSearch.Name = "txtboxListItemSearch"
        Me.txtboxListItemSearch.ShortcutsEnabled = False
        Me.txtboxListItemSearch.Size = New System.Drawing.Size(203, 25)
        Me.txtboxListItemSearch.TabIndex = 51
        '
        'dgvListItem
        '
        Me.dgvListItem.AllowUserToAddRows = False
        Me.dgvListItem.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
        Me.dgvListItem.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.itemcode, Me.itemname, Me.category, Me.quantity, Me.Column2})
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
        Me.dgvListItem.Location = New System.Drawing.Point(36, 107)
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
        Me.dgvListItem.Size = New System.Drawing.Size(1248, 274)
        Me.dgvListItem.TabIndex = 50
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
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Location = New System.Drawing.Point(36, 388)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1248, 24)
        Me.Panel2.TabIndex = 57
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(7, 3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(150, 18)
        Me.Label3.TabIndex = 49
        Me.Label3.Text = "SELECTED ITEMS"
        '
        'panelsap
        '
        Me.panelsap.BackColor = System.Drawing.SystemColors.HotTrack
        Me.panelsap.Controls.Add(Me.rbtransfer)
        Me.panelsap.Controls.Add(Me.lblclosesap)
        Me.panelsap.Controls.Add(Me.rbconvout)
        Me.panelsap.Controls.Add(Me.rbarcharge)
        Me.panelsap.Controls.Add(Me.rbarreject)
        Me.panelsap.Controls.Add(Me.Label9)
        Me.panelsap.Controls.Add(Me.txtname)
        Me.panelsap.Controls.Add(Me.lblSAPClose)
        Me.panelsap.Controls.Add(Me.btnProceed)
        Me.panelsap.Controls.Add(Me.lblsapdoc)
        Me.panelsap.Controls.Add(Me.checkfollowup)
        Me.panelsap.Controls.Add(Me.txtsap)
        Me.panelsap.Controls.Add(Me.Label4)
        Me.panelsap.Controls.Add(Me.txtremarks)
        Me.panelsap.Controls.Add(Me.Label11)
        Me.panelsap.Location = New System.Drawing.Point(479, 183)
        Me.panelsap.Name = "panelsap"
        Me.panelsap.Size = New System.Drawing.Size(348, 374)
        Me.panelsap.TabIndex = 59
        Me.panelsap.Visible = False
        '
        'rbtransfer
        '
        Me.rbtransfer.AutoSize = True
        Me.rbtransfer.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rbtransfer.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtransfer.ForeColor = System.Drawing.Color.White
        Me.rbtransfer.Location = New System.Drawing.Point(19, 10)
        Me.rbtransfer.Name = "rbtransfer"
        Me.rbtransfer.Size = New System.Drawing.Size(80, 19)
        Me.rbtransfer.TabIndex = 33
        Me.rbtransfer.TabStop = True
        Me.rbtransfer.Text = "Transfer"
        Me.rbtransfer.UseVisualStyleBackColor = True
        '
        'lblclosesap
        '
        Me.lblclosesap.AutoSize = True
        Me.lblclosesap.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblclosesap.Font = New System.Drawing.Font("Arial Rounded MT Bold", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblclosesap.ForeColor = System.Drawing.Color.White
        Me.lblclosesap.Location = New System.Drawing.Point(322, -3)
        Me.lblclosesap.Name = "lblclosesap"
        Me.lblclosesap.Size = New System.Drawing.Size(26, 28)
        Me.lblclosesap.TabIndex = 32
        Me.lblclosesap.Text = "X"
        '
        'rbconvout
        '
        Me.rbconvout.AutoSize = True
        Me.rbconvout.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rbconvout.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbconvout.ForeColor = System.Drawing.Color.White
        Me.rbconvout.Location = New System.Drawing.Point(209, 38)
        Me.rbconvout.Name = "rbconvout"
        Me.rbconvout.Size = New System.Drawing.Size(125, 19)
        Me.rbconvout.TabIndex = 31
        Me.rbconvout.TabStop = True
        Me.rbconvout.Text = "Conversion Out"
        Me.rbconvout.UseVisualStyleBackColor = True
        '
        'rbarcharge
        '
        Me.rbarcharge.AutoSize = True
        Me.rbarcharge.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rbarcharge.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbarcharge.ForeColor = System.Drawing.Color.White
        Me.rbarcharge.Location = New System.Drawing.Point(115, 38)
        Me.rbarcharge.Name = "rbarcharge"
        Me.rbarcharge.Size = New System.Drawing.Size(94, 19)
        Me.rbarcharge.TabIndex = 30
        Me.rbarcharge.TabStop = True
        Me.rbarcharge.Text = "AR Charge"
        Me.rbarcharge.UseVisualStyleBackColor = True
        '
        'rbarreject
        '
        Me.rbarreject.AutoSize = True
        Me.rbarreject.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rbarreject.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbarreject.ForeColor = System.Drawing.Color.White
        Me.rbarreject.Location = New System.Drawing.Point(19, 38)
        Me.rbarreject.Name = "rbarreject"
        Me.rbarreject.Size = New System.Drawing.Size(88, 19)
        Me.rbarreject.TabIndex = 29
        Me.rbarreject.TabStop = True
        Me.rbarreject.Text = "AR Reject"
        Me.rbarreject.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(25, 69)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(59, 18)
        Me.Label9.TabIndex = 28
        Me.Label9.Text = "Name:"
        '
        'txtname
        '
        Me.txtname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtname.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtname.Location = New System.Drawing.Point(28, 91)
        Me.txtname.Name = "txtname"
        Me.txtname.ShortcutsEnabled = False
        Me.txtname.Size = New System.Drawing.Size(274, 29)
        Me.txtname.TabIndex = 27
        '
        'lblSAPClose
        '
        Me.lblSAPClose.AutoSize = True
        Me.lblSAPClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblSAPClose.Font = New System.Drawing.Font("Arial Rounded MT Bold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSAPClose.ForeColor = System.Drawing.Color.White
        Me.lblSAPClose.Location = New System.Drawing.Point(387, 0)
        Me.lblSAPClose.Name = "lblSAPClose"
        Me.lblSAPClose.Size = New System.Drawing.Size(23, 24)
        Me.lblSAPClose.TabIndex = 26
        Me.lblSAPClose.Text = "X"
        '
        'btnProceed
        '
        Me.btnProceed.BackColor = System.Drawing.Color.ForestGreen
        Me.btnProceed.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnProceed.FlatAppearance.BorderSize = 0
        Me.btnProceed.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProceed.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProceed.ForeColor = System.Drawing.Color.White
        Me.btnProceed.Location = New System.Drawing.Point(188, 313)
        Me.btnProceed.Name = "btnProceed"
        Me.btnProceed.Size = New System.Drawing.Size(129, 31)
        Me.btnProceed.TabIndex = 25
        Me.btnProceed.Text = "Proceed"
        Me.btnProceed.UseVisualStyleBackColor = False
        '
        'lblsapdoc
        '
        Me.lblsapdoc.AutoSize = True
        Me.lblsapdoc.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsapdoc.ForeColor = System.Drawing.Color.White
        Me.lblsapdoc.Location = New System.Drawing.Point(164, 133)
        Me.lblsapdoc.Name = "lblsapdoc"
        Me.lblsapdoc.Size = New System.Drawing.Size(41, 18)
        Me.lblsapdoc.TabIndex = 24
        Me.lblsapdoc.Text = "N/A:"
        '
        'checkfollowup
        '
        Me.checkfollowup.AutoSize = True
        Me.checkfollowup.Cursor = System.Windows.Forms.Cursors.Hand
        Me.checkfollowup.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkfollowup.ForeColor = System.Drawing.Color.White
        Me.checkfollowup.Location = New System.Drawing.Point(235, 160)
        Me.checkfollowup.Name = "checkfollowup"
        Me.checkfollowup.Size = New System.Drawing.Size(86, 20)
        Me.checkfollowup.TabIndex = 23
        Me.checkfollowup.Text = "To Follow"
        Me.checkfollowup.UseVisualStyleBackColor = True
        '
        'txtsap
        '
        Me.txtsap.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsap.Location = New System.Drawing.Point(28, 156)
        Me.txtsap.Multiline = True
        Me.txtsap.Name = "txtsap"
        Me.txtsap.ShortcutsEnabled = False
        Me.txtsap.Size = New System.Drawing.Size(201, 26)
        Me.txtsap.TabIndex = 22
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(25, 133)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(133, 18)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "SAP Document:"
        '
        'txtremarks
        '
        Me.txtremarks.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtremarks.Location = New System.Drawing.Point(28, 217)
        Me.txtremarks.Multiline = True
        Me.txtremarks.Name = "txtremarks"
        Me.txtremarks.ShortcutsEnabled = False
        Me.txtremarks.Size = New System.Drawing.Size(289, 90)
        Me.txtremarks.TabIndex = 20
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(25, 192)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(79, 18)
        Me.Label11.TabIndex = 19
        Me.Label11.Text = "Remarks"
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
        Me.panelQuantity.Controls.Add(Me.Label5)
        Me.panelQuantity.Controls.Add(Me.btnQuantity)
        Me.panelQuantity.Location = New System.Drawing.Point(476, 218)
        Me.panelQuantity.Name = "panelQuantity"
        Me.panelQuantity.Size = New System.Drawing.Size(371, 233)
        Me.panelQuantity.TabIndex = 58
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
        Me.lblQuantityItemCode.Visible = False
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
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(36, 105)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(129, 18)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Enter Quantity:"
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
        Me.btnQuantity.Location = New System.Drawing.Point(199, 182)
        Me.btnQuantity.Name = "btnQuantity"
        Me.btnQuantity.Size = New System.Drawing.Size(129, 31)
        Me.btnQuantity.TabIndex = 0
        Me.btnQuantity.Text = "Add Quantity"
        Me.btnQuantity.UseVisualStyleBackColor = False
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
        Me.btnSubmit.Location = New System.Drawing.Point(1137, 637)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(147, 47)
        Me.btnSubmit.TabIndex = 60
        Me.btnSubmit.Text = "SUBMIT"
        Me.btnSubmit.UseVisualStyleBackColor = False
        '
        'pulloutss
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1344, 701)
        Me.Controls.Add(Me.panelQuantity)
        Me.Controls.Add(Me.panelsap)
        Me.Controls.Add(Me.btnSubmit)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.dgvSelectedItem)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbCategoryListItem)
        Me.Controls.Add(Me.btnSearchListItem)
        Me.Controls.Add(Me.txtboxListItemSearch)
        Me.Controls.Add(Me.dgvListItem)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "pulloutss"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pull Out"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvSelectedItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvListItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.panelsap.ResumeLayout(False)
        Me.panelsap.PerformLayout()
        Me.panelQuantity.ResumeLayout(False)
        Me.panelQuantity.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents dgvSelectedItem As DataGridView
    Friend WithEvents itemcodee As DataGridViewTextBoxColumn
    Friend WithEvents itemnamee As DataGridViewTextBoxColumn
    Friend WithEvents categoryy As DataGridViewTextBoxColumn
    Friend WithEvents quantityy As DataGridViewTextBoxColumn
    Friend WithEvents updatequantity As DataGridViewButtonColumn
    Friend WithEvents deletequantity As DataGridViewButtonColumn
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbCategoryListItem As ComboBox
    Friend WithEvents btnSearchListItem As Button
    Friend WithEvents txtboxListItemSearch As TextBox
    Friend WithEvents dgvListItem As DataGridView
    Friend WithEvents itemcode As DataGridViewTextBoxColumn
    Friend WithEvents itemname As DataGridViewTextBoxColumn
    Friend WithEvents category As DataGridViewTextBoxColumn
    Friend WithEvents quantity As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewButtonColumn
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents panelsap As Panel
    Friend WithEvents rbtransfer As RadioButton
    Friend WithEvents lblclosesap As Label
    Friend WithEvents rbconvout As RadioButton
    Friend WithEvents rbarcharge As RadioButton
    Friend WithEvents rbarreject As RadioButton
    Friend WithEvents Label9 As Label
    Friend WithEvents txtname As TextBox
    Friend WithEvents lblSAPClose As Label
    Friend WithEvents btnProceed As Button
    Friend WithEvents lblsapdoc As Label
    Friend WithEvents checkfollowup As CheckBox
    Friend WithEvents txtsap As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtremarks As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents panelQuantity As Panel
    Friend WithEvents lblQuantityCategory As Label
    Friend WithEvents lblQuantityItemCode As Label
    Friend WithEvents lblQuantityItemName As Label
    Friend WithEvents lblClose As Label
    Friend WithEvents txtboxQuantity As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents btnQuantity As Button
    Friend WithEvents btnSubmit As Button
End Class
