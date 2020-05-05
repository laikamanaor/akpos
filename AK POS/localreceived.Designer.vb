<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class localreceived
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvpendings = New System.Windows.Forms.DataGridView()
        Me.actionn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.transnum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.datee = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvitems = New System.Windows.Forms.DataGridView()
        Me.itemcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.itemname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.category = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.quantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.good = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.charge = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.action = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.btnsubmit = New System.Windows.Forms.Button()
        Me.lblTransactionID = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtsearchpendings = New System.Windows.Forms.TextBox()
        Me.btnsearchpendings = New System.Windows.Forms.Button()
        Me.btnsearchitems = New System.Windows.Forms.Button()
        Me.txtsearchitems = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbsearchcategory = New System.Windows.Forms.ComboBox()
        Me.panelupdate = New System.Windows.Forms.Panel()
        Me.lblitemcode = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblclose = New System.Windows.Forms.Label()
        Me.btnok = New System.Windows.Forms.Button()
        Me.txtcharge = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtgood = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblquantity = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblcategory = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblitemname = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.lblclosesap = New System.Windows.Forms.Label()
        Me.panelsap = New System.Windows.Forms.Panel()
        Me.lbltype = New System.Windows.Forms.Label()
        Me.checkfollowup = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnproceed = New System.Windows.Forms.Button()
        Me.txtremarks = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtsapno = New System.Windows.Forms.TextBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblID = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        CType(Me.dgvpendings, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvitems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelupdate.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.panelsap.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvpendings
        '
        Me.dgvpendings.AllowUserToAddRows = False
        Me.dgvpendings.AllowUserToDeleteRows = False
        Me.dgvpendings.AllowUserToResizeColumns = False
        Me.dgvpendings.AllowUserToResizeRows = False
        Me.dgvpendings.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvpendings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvpendings.BackgroundColor = System.Drawing.Color.White
        Me.dgvpendings.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvpendings.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer))
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvpendings.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.dgvpendings.ColumnHeadersHeight = 40
        Me.dgvpendings.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.actionn, Me.transnum, Me.qty, Me.datee})
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvpendings.DefaultCellStyle = DataGridViewCellStyle12
        Me.dgvpendings.EnableHeadersVisualStyles = False
        Me.dgvpendings.Location = New System.Drawing.Point(68, 121)
        Me.dgvpendings.Name = "dgvpendings"
        Me.dgvpendings.RowHeadersVisible = False
        Me.dgvpendings.Size = New System.Drawing.Size(1224, 237)
        Me.dgvpendings.TabIndex = 0
        '
        'actionn
        '
        Me.actionn.HeaderText = "Select"
        Me.actionn.Name = "actionn"
        Me.actionn.Visible = False
        '
        'transnum
        '
        Me.transnum.HeaderText = "Transaction #"
        Me.transnum.Name = "transnum"
        Me.transnum.ReadOnly = True
        Me.transnum.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.transnum.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'qty
        '
        Me.qty.HeaderText = "Quantity"
        Me.qty.Name = "qty"
        Me.qty.ReadOnly = True
        '
        'datee
        '
        Me.datee.HeaderText = "Date"
        Me.datee.Name = "datee"
        Me.datee.ReadOnly = True
        '
        'dgvitems
        '
        Me.dgvitems.AllowUserToAddRows = False
        Me.dgvitems.AllowUserToDeleteRows = False
        Me.dgvitems.AllowUserToResizeColumns = False
        Me.dgvitems.AllowUserToResizeRows = False
        Me.dgvitems.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvitems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvitems.BackgroundColor = System.Drawing.Color.White
        Me.dgvitems.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvitems.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer))
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvitems.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.dgvitems.ColumnHeadersHeight = 40
        Me.dgvitems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.itemcode, Me.itemname, Me.category, Me.quantity, Me.good, Me.charge, Me.action})
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle15.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvitems.DefaultCellStyle = DataGridViewCellStyle15
        Me.dgvitems.EnableHeadersVisualStyles = False
        Me.dgvitems.Location = New System.Drawing.Point(68, 411)
        Me.dgvitems.Name = "dgvitems"
        Me.dgvitems.RowHeadersVisible = False
        Me.dgvitems.Size = New System.Drawing.Size(1224, 213)
        Me.dgvitems.TabIndex = 1
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
        'good
        '
        Me.good.HeaderText = "Good"
        Me.good.Name = "good"
        Me.good.ReadOnly = True
        '
        'charge
        '
        Me.charge.HeaderText = "Charge"
        Me.charge.Name = "charge"
        Me.charge.ReadOnly = True
        '
        'action
        '
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.ForestGreen
        DataGridViewCellStyle14.ForeColor = System.Drawing.Color.White
        Me.action.DefaultCellStyle = DataGridViewCellStyle14
        Me.action.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.action.HeaderText = "Update Good/Charge"
        Me.action.Name = "action"
        Me.action.Text = "Action"
        Me.action.UseColumnTextForButtonValue = True
        '
        'btnsubmit
        '
        Me.btnsubmit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnsubmit.BackColor = System.Drawing.Color.ForestGreen
        Me.btnsubmit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnsubmit.FlatAppearance.BorderSize = 0
        Me.btnsubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnsubmit.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsubmit.ForeColor = System.Drawing.Color.White
        Me.btnsubmit.Location = New System.Drawing.Point(1163, 630)
        Me.btnsubmit.Name = "btnsubmit"
        Me.btnsubmit.Size = New System.Drawing.Size(129, 44)
        Me.btnsubmit.TabIndex = 2
        Me.btnsubmit.Text = "Submit"
        Me.btnsubmit.UseVisualStyleBackColor = False
        '
        'lblTransactionID
        '
        Me.lblTransactionID.AutoSize = True
        Me.lblTransactionID.Font = New System.Drawing.Font("Arial Rounded MT Bold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTransactionID.ForeColor = System.Drawing.Color.Firebrick
        Me.lblTransactionID.Location = New System.Drawing.Point(186, 54)
        Me.lblTransactionID.Name = "lblTransactionID"
        Me.lblTransactionID.Size = New System.Drawing.Size(47, 24)
        Me.lblTransactionID.TabIndex = 3
        Me.lblTransactionID.Text = "N/A"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(66, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(114, 24)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "TRANS. #:"
        '
        'txtsearchpendings
        '
        Me.txtsearchpendings.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtsearchpendings.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtsearchpendings.BackColor = System.Drawing.SystemColors.Control
        Me.txtsearchpendings.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtsearchpendings.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsearchpendings.Location = New System.Drawing.Point(72, 93)
        Me.txtsearchpendings.Name = "txtsearchpendings"
        Me.txtsearchpendings.Size = New System.Drawing.Size(252, 19)
        Me.txtsearchpendings.TabIndex = 7
        '
        'btnsearchpendings
        '
        Me.btnsearchpendings.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnsearchpendings.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnsearchpendings.FlatAppearance.BorderSize = 0
        Me.btnsearchpendings.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.HotTrack
        Me.btnsearchpendings.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnsearchpendings.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsearchpendings.ForeColor = System.Drawing.Color.White
        Me.btnsearchpendings.Location = New System.Drawing.Point(330, 89)
        Me.btnsearchpendings.Name = "btnsearchpendings"
        Me.btnsearchpendings.Size = New System.Drawing.Size(95, 26)
        Me.btnsearchpendings.TabIndex = 8
        Me.btnsearchpendings.Text = "Search"
        Me.btnsearchpendings.UseVisualStyleBackColor = False
        '
        'btnsearchitems
        '
        Me.btnsearchitems.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnsearchitems.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnsearchitems.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnsearchitems.FlatAppearance.BorderSize = 0
        Me.btnsearchitems.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.HotTrack
        Me.btnsearchitems.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnsearchitems.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsearchitems.ForeColor = System.Drawing.Color.White
        Me.btnsearchitems.Location = New System.Drawing.Point(326, 379)
        Me.btnsearchitems.Name = "btnsearchitems"
        Me.btnsearchitems.Size = New System.Drawing.Size(95, 26)
        Me.btnsearchitems.TabIndex = 10
        Me.btnsearchitems.Text = "Search"
        Me.btnsearchitems.UseVisualStyleBackColor = False
        '
        'txtsearchitems
        '
        Me.txtsearchitems.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtsearchitems.BackColor = System.Drawing.SystemColors.Control
        Me.txtsearchitems.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtsearchitems.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsearchitems.Location = New System.Drawing.Point(68, 383)
        Me.txtsearchitems.Name = "txtsearchitems"
        Me.txtsearchitems.Size = New System.Drawing.Size(252, 19)
        Me.txtsearchitems.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(1001, 384)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 17)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Category:"
        '
        'cmbsearchcategory
        '
        Me.cmbsearchcategory.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbsearchcategory.BackColor = System.Drawing.SystemColors.HotTrack
        Me.cmbsearchcategory.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbsearchcategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbsearchcategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbsearchcategory.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbsearchcategory.ForeColor = System.Drawing.Color.White
        Me.cmbsearchcategory.FormattingEnabled = True
        Me.cmbsearchcategory.Location = New System.Drawing.Point(1087, 379)
        Me.cmbsearchcategory.Name = "cmbsearchcategory"
        Me.cmbsearchcategory.Size = New System.Drawing.Size(205, 26)
        Me.cmbsearchcategory.TabIndex = 12
        '
        'panelupdate
        '
        Me.panelupdate.BackColor = System.Drawing.Color.Salmon
        Me.panelupdate.Controls.Add(Me.lblitemcode)
        Me.panelupdate.Controls.Add(Me.Label17)
        Me.panelupdate.Controls.Add(Me.Panel2)
        Me.panelupdate.Controls.Add(Me.btnok)
        Me.panelupdate.Controls.Add(Me.txtcharge)
        Me.panelupdate.Controls.Add(Me.Label12)
        Me.panelupdate.Controls.Add(Me.txtgood)
        Me.panelupdate.Controls.Add(Me.Label11)
        Me.panelupdate.Controls.Add(Me.lblquantity)
        Me.panelupdate.Controls.Add(Me.Label10)
        Me.panelupdate.Controls.Add(Me.lblcategory)
        Me.panelupdate.Controls.Add(Me.Label8)
        Me.panelupdate.Controls.Add(Me.lblitemname)
        Me.panelupdate.Controls.Add(Me.Label5)
        Me.panelupdate.Location = New System.Drawing.Point(460, 89)
        Me.panelupdate.Name = "panelupdate"
        Me.panelupdate.Size = New System.Drawing.Size(333, 328)
        Me.panelupdate.TabIndex = 13
        Me.panelupdate.Visible = False
        '
        'lblitemcode
        '
        Me.lblitemcode.AutoSize = True
        Me.lblitemcode.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblitemcode.ForeColor = System.Drawing.Color.White
        Me.lblitemcode.Location = New System.Drawing.Point(124, 34)
        Me.lblitemcode.Name = "lblitemcode"
        Me.lblitemcode.Size = New System.Drawing.Size(34, 17)
        Me.lblitemcode.TabIndex = 28
        Me.lblitemcode.Text = "N/A"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(20, 34)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(97, 17)
        Me.Label17.TabIndex = 27
        Me.Label17.Text = "ITEM CODE:"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.OrangeRed
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Controls.Add(Me.lblclose)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(333, 24)
        Me.Panel2.TabIndex = 26
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(3, 4)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(191, 17)
        Me.Label13.TabIndex = 27
        Me.Label13.Text = "UPDATE GOOD/CHARGE"
        '
        'lblclose
        '
        Me.lblclose.AutoSize = True
        Me.lblclose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblclose.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblclose.ForeColor = System.Drawing.Color.White
        Me.lblclose.Location = New System.Drawing.Point(312, 0)
        Me.lblclose.Name = "lblclose"
        Me.lblclose.Size = New System.Drawing.Size(21, 22)
        Me.lblclose.TabIndex = 25
        Me.lblclose.Text = "X"
        Me.ToolTip1.SetToolTip(Me.lblclose, "Close")
        Me.lblclose.Visible = False
        '
        'btnok
        '
        Me.btnok.BackColor = System.Drawing.Color.ForestGreen
        Me.btnok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnok.FlatAppearance.BorderSize = 0
        Me.btnok.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnok.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnok.ForeColor = System.Drawing.Color.White
        Me.btnok.Location = New System.Drawing.Point(207, 274)
        Me.btnok.Name = "btnok"
        Me.btnok.Size = New System.Drawing.Size(106, 31)
        Me.btnok.TabIndex = 24
        Me.btnok.Text = "OK"
        Me.btnok.UseVisualStyleBackColor = False
        '
        'txtcharge
        '
        Me.txtcharge.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcharge.Location = New System.Drawing.Point(22, 232)
        Me.txtcharge.Name = "txtcharge"
        Me.txtcharge.ShortcutsEnabled = False
        Me.txtcharge.Size = New System.Drawing.Size(291, 26)
        Me.txtcharge.TabIndex = 23
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(19, 212)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(79, 17)
        Me.Label12.TabIndex = 22
        Me.Label12.Text = "CHARGE:"
        '
        'txtgood
        '
        Me.txtgood.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtgood.Location = New System.Drawing.Point(22, 174)
        Me.txtgood.Name = "txtgood"
        Me.txtgood.ShortcutsEnabled = False
        Me.txtgood.Size = New System.Drawing.Size(291, 26)
        Me.txtgood.TabIndex = 21
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(19, 154)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(60, 17)
        Me.Label11.TabIndex = 20
        Me.Label11.Text = "GOOD:"
        '
        'lblquantity
        '
        Me.lblquantity.AutoSize = True
        Me.lblquantity.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblquantity.ForeColor = System.Drawing.Color.White
        Me.lblquantity.Location = New System.Drawing.Point(123, 120)
        Me.lblquantity.Name = "lblquantity"
        Me.lblquantity.Size = New System.Drawing.Size(34, 17)
        Me.lblquantity.TabIndex = 19
        Me.lblquantity.Text = "N/A"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(19, 120)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(90, 17)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "QUANTITY:"
        '
        'lblcategory
        '
        Me.lblcategory.AutoSize = True
        Me.lblcategory.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcategory.ForeColor = System.Drawing.Color.White
        Me.lblcategory.Location = New System.Drawing.Point(123, 90)
        Me.lblcategory.Name = "lblcategory"
        Me.lblcategory.Size = New System.Drawing.Size(34, 17)
        Me.lblcategory.TabIndex = 17
        Me.lblcategory.Text = "N/A"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(19, 90)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(98, 17)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "CATEGORY:"
        '
        'lblitemname
        '
        Me.lblitemname.AutoSize = True
        Me.lblitemname.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblitemname.ForeColor = System.Drawing.Color.White
        Me.lblitemname.Location = New System.Drawing.Point(123, 63)
        Me.lblitemname.Name = "lblitemname"
        Me.lblitemname.Size = New System.Drawing.Size(34, 17)
        Me.lblitemname.TabIndex = 15
        Me.lblitemname.Text = "N/A"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(19, 63)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 17)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "ITEM:"
        '
        'lblclosesap
        '
        Me.lblclosesap.AutoSize = True
        Me.lblclosesap.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblclosesap.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblclosesap.ForeColor = System.Drawing.Color.White
        Me.lblclosesap.Location = New System.Drawing.Point(391, 0)
        Me.lblclosesap.Name = "lblclosesap"
        Me.lblclosesap.Size = New System.Drawing.Size(21, 22)
        Me.lblclosesap.TabIndex = 25
        Me.lblclosesap.Text = "X"
        Me.ToolTip1.SetToolTip(Me.lblclosesap, "Close")
        '
        'panelsap
        '
        Me.panelsap.BackColor = System.Drawing.Color.Salmon
        Me.panelsap.Controls.Add(Me.lbltype)
        Me.panelsap.Controls.Add(Me.checkfollowup)
        Me.panelsap.Controls.Add(Me.Label3)
        Me.panelsap.Controls.Add(Me.btnproceed)
        Me.panelsap.Controls.Add(Me.txtremarks)
        Me.panelsap.Controls.Add(Me.Label15)
        Me.panelsap.Controls.Add(Me.txtsapno)
        Me.panelsap.Controls.Add(Me.Panel4)
        Me.panelsap.Location = New System.Drawing.Point(422, 162)
        Me.panelsap.Name = "panelsap"
        Me.panelsap.Size = New System.Drawing.Size(412, 269)
        Me.panelsap.TabIndex = 14
        Me.panelsap.Visible = False
        '
        'lbltype
        '
        Me.lbltype.AutoSize = True
        Me.lbltype.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltype.ForeColor = System.Drawing.Color.White
        Me.lbltype.Location = New System.Drawing.Point(165, 49)
        Me.lbltype.Name = "lbltype"
        Me.lbltype.Size = New System.Drawing.Size(23, 18)
        Me.lbltype.TabIndex = 37
        Me.lbltype.Text = "IT"
        '
        'checkfollowup
        '
        Me.checkfollowup.AutoSize = True
        Me.checkfollowup.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkfollowup.ForeColor = System.Drawing.Color.White
        Me.checkfollowup.Location = New System.Drawing.Point(297, 74)
        Me.checkfollowup.Name = "checkfollowup"
        Me.checkfollowup.Size = New System.Drawing.Size(86, 20)
        Me.checkfollowup.TabIndex = 36
        Me.checkfollowup.Text = "To Follow"
        Me.checkfollowup.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(26, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(133, 18)
        Me.Label3.TabIndex = 33
        Me.Label3.Text = "SAP Document:"
        '
        'btnproceed
        '
        Me.btnproceed.BackColor = System.Drawing.Color.ForestGreen
        Me.btnproceed.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnproceed.FlatAppearance.BorderSize = 0
        Me.btnproceed.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnproceed.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnproceed.ForeColor = System.Drawing.Color.White
        Me.btnproceed.Location = New System.Drawing.Point(275, 212)
        Me.btnproceed.Name = "btnproceed"
        Me.btnproceed.Size = New System.Drawing.Size(106, 31)
        Me.btnproceed.TabIndex = 32
        Me.btnproceed.Text = "Proceed"
        Me.btnproceed.UseVisualStyleBackColor = False
        '
        'txtremarks
        '
        Me.txtremarks.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtremarks.Location = New System.Drawing.Point(29, 128)
        Me.txtremarks.Multiline = True
        Me.txtremarks.Name = "txtremarks"
        Me.txtremarks.Size = New System.Drawing.Size(352, 65)
        Me.txtremarks.TabIndex = 31
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(26, 108)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(89, 17)
        Me.Label15.TabIndex = 30
        Me.Label15.Text = "REMARKS:"
        '
        'txtsapno
        '
        Me.txtsapno.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsapno.Location = New System.Drawing.Point(27, 70)
        Me.txtsapno.Name = "txtsapno"
        Me.txtsapno.Size = New System.Drawing.Size(264, 26)
        Me.txtsapno.TabIndex = 29
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.OrangeRed
        Me.Panel4.Controls.Add(Me.Label14)
        Me.Panel4.Controls.Add(Me.lblclosesap)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(412, 24)
        Me.Panel4.TabIndex = 27
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(3, 4)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(39, 17)
        Me.Label14.TabIndex = 27
        Me.Label14.Text = "SAP"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(66, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 24)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "INV. #:"
        '
        'lblID
        '
        Me.lblID.AutoSize = True
        Me.lblID.Font = New System.Drawing.Font("Arial Rounded MT Bold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblID.ForeColor = System.Drawing.Color.Green
        Me.lblID.Location = New System.Drawing.Point(186, 15)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(47, 24)
        Me.lblID.TabIndex = 15
        Me.lblID.Text = "N/A"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.Location = New System.Drawing.Point(70, 113)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(254, 2)
        Me.Panel1.TabIndex = 17
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel3.BackColor = System.Drawing.Color.Black
        Me.Panel3.Location = New System.Drawing.Point(68, 403)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(254, 2)
        Me.Panel3.TabIndex = 18
        '
        'localreceived
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1334, 691)
        Me.Controls.Add(Me.panelsap)
        Me.Controls.Add(Me.panelupdate)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblID)
        Me.Controls.Add(Me.cmbsearchcategory)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnsearchitems)
        Me.Controls.Add(Me.txtsearchitems)
        Me.Controls.Add(Me.btnsearchpendings)
        Me.Controls.Add(Me.txtsearchpendings)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblTransactionID)
        Me.Controls.Add(Me.btnsubmit)
        Me.Controls.Add(Me.dgvitems)
        Me.Controls.Add(Me.dgvpendings)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "localreceived"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Received Item from Production"
        CType(Me.dgvpendings, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvitems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelupdate.ResumeLayout(False)
        Me.panelupdate.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.panelsap.ResumeLayout(False)
        Me.panelsap.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvpendings As System.Windows.Forms.DataGridView
    Friend WithEvents dgvitems As System.Windows.Forms.DataGridView
    Friend WithEvents btnsubmit As System.Windows.Forms.Button
    Friend WithEvents lblTransactionID As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtsearchpendings As System.Windows.Forms.TextBox
    Friend WithEvents btnsearchpendings As System.Windows.Forms.Button
    Friend WithEvents btnsearchitems As System.Windows.Forms.Button
    Friend WithEvents txtsearchitems As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbsearchcategory As System.Windows.Forms.ComboBox
    Friend WithEvents panelupdate As System.Windows.Forms.Panel
    Friend WithEvents lblquantity As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblcategory As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblitemname As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnok As System.Windows.Forms.Button
    Friend WithEvents txtcharge As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtgood As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblclose As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents panelsap As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lblclosesap As System.Windows.Forms.Label
    Friend WithEvents btnproceed As System.Windows.Forms.Button
    Friend WithEvents txtremarks As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtsapno As System.Windows.Forms.TextBox
    Friend WithEvents itemcode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents itemname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents category As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents quantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents good As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents charge As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents action As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents lblitemcode As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblID As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents actionn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents transnum As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents qty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents datee As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents checkfollowup As System.Windows.Forms.CheckBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents lbltype As System.Windows.Forms.Label
End Class
