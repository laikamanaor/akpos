<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class orders
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(orders))
        Me.dgvorders = New System.Windows.Forms.DataGridView()
        Me.transnum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.amtdue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tendertype = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.servicetype = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvitems = New System.Windows.Forms.DataGridView()
        Me.description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.price = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.discpercent = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.amt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.request = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.free = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cmbcustomers = New System.Windows.Forms.ComboBox()
        Me.dtsearch = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbtendertype = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbltranscount = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblitemscount = New System.Windows.Forms.Label()
        Me.btnvoids = New System.Windows.Forms.Button()
        Me.btnlogs = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbtype = New System.Windows.Forms.ComboBox()
        Me.lbldate = New System.Windows.Forms.Label()
        Me.txtsearch = New System.Windows.Forms.TextBox()
        Me.btnsearch = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btncanceltransaction = New System.Windows.Forms.Button()
        Me.btncancellogs = New System.Windows.Forms.Button()
        CType(Me.dgvorders, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvitems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvorders
        '
        Me.dgvorders.AllowUserToAddRows = False
        Me.dgvorders.AllowUserToDeleteRows = False
        Me.dgvorders.AllowUserToResizeColumns = False
        Me.dgvorders.AllowUserToResizeRows = False
        Me.dgvorders.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvorders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvorders.BackgroundColor = System.Drawing.Color.White
        Me.dgvorders.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvorders.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvorders.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvorders.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvorders.ColumnHeadersHeight = 40
        Me.dgvorders.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.transnum, Me.amtdue, Me.tendertype, Me.servicetype})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvorders.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvorders.EnableHeadersVisualStyles = False
        Me.dgvorders.GridColor = System.Drawing.Color.Black
        Me.dgvorders.Location = New System.Drawing.Point(60, 179)
        Me.dgvorders.Name = "dgvorders"
        Me.dgvorders.RowHeadersVisible = False
        Me.dgvorders.Size = New System.Drawing.Size(892, 192)
        Me.dgvorders.TabIndex = 0
        '
        'transnum
        '
        Me.transnum.HeaderText = "Order #"
        Me.transnum.Name = "transnum"
        Me.transnum.ReadOnly = True
        '
        'amtdue
        '
        Me.amtdue.HeaderText = "Amount Due"
        Me.amtdue.Name = "amtdue"
        Me.amtdue.ReadOnly = True
        '
        'tendertype
        '
        Me.tendertype.HeaderText = "Tender Type"
        Me.tendertype.Name = "tendertype"
        Me.tendertype.ReadOnly = True
        '
        'servicetype
        '
        Me.servicetype.HeaderText = "Service Type"
        Me.servicetype.Name = "servicetype"
        Me.servicetype.ReadOnly = True
        '
        'dgvitems
        '
        Me.dgvitems.AllowUserToAddRows = False
        Me.dgvitems.AllowUserToDeleteRows = False
        Me.dgvitems.AllowUserToResizeColumns = False
        Me.dgvitems.AllowUserToResizeRows = False
        Me.dgvitems.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvitems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvitems.BackgroundColor = System.Drawing.Color.White
        Me.dgvitems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvitems.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvitems.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvitems.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvitems.ColumnHeadersHeight = 40
        Me.dgvitems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.description, Me.qty, Me.price, Me.discpercent, Me.amt, Me.request, Me.free})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvitems.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgvitems.EnableHeadersVisualStyles = False
        Me.dgvitems.GridColor = System.Drawing.Color.Black
        Me.dgvitems.Location = New System.Drawing.Point(60, 418)
        Me.dgvitems.Name = "dgvitems"
        Me.dgvitems.RowHeadersVisible = False
        Me.dgvitems.Size = New System.Drawing.Size(892, 89)
        Me.dgvitems.TabIndex = 1
        '
        'description
        '
        Me.description.HeaderText = "Description"
        Me.description.Name = "description"
        Me.description.ReadOnly = True
        '
        'qty
        '
        Me.qty.HeaderText = "Quantity"
        Me.qty.Name = "qty"
        Me.qty.ReadOnly = True
        '
        'price
        '
        Me.price.HeaderText = "Price"
        Me.price.Name = "price"
        Me.price.ReadOnly = True
        '
        'discpercent
        '
        Me.discpercent.HeaderText = "Disc. %"
        Me.discpercent.Name = "discpercent"
        Me.discpercent.ReadOnly = True
        '
        'amt
        '
        Me.amt.HeaderText = "Amount"
        Me.amt.Name = "amt"
        Me.amt.ReadOnly = True
        '
        'request
        '
        Me.request.HeaderText = "Request"
        Me.request.Name = "request"
        Me.request.ReadOnly = True
        '
        'free
        '
        Me.free.HeaderText = "Free"
        Me.free.Name = "free"
        Me.free.ReadOnly = True
        '
        'cmbcustomers
        '
        Me.cmbcustomers.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbcustomers.BackColor = System.Drawing.Color.White
        Me.cmbcustomers.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbcustomers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbcustomers.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbcustomers.ForeColor = System.Drawing.Color.Black
        Me.cmbcustomers.FormattingEnabled = True
        Me.cmbcustomers.Location = New System.Drawing.Point(574, 99)
        Me.cmbcustomers.Name = "cmbcustomers"
        Me.cmbcustomers.Size = New System.Drawing.Size(124, 26)
        Me.cmbcustomers.TabIndex = 6
        '
        'dtsearch
        '
        Me.dtsearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtsearch.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtsearch.CustomFormat = "MM/dd/yyyy"
        Me.dtsearch.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtsearch.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtsearch.Location = New System.Drawing.Point(574, 131)
        Me.dtsearch.Name = "dtsearch"
        Me.dtsearch.Size = New System.Drawing.Size(124, 23)
        Me.dtsearch.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(502, 104)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 15)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Sales:"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(502, 134)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 15)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Date:"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(718, 99)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 15)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Tender Type:"
        '
        'cmbtendertype
        '
        Me.cmbtendertype.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbtendertype.BackColor = System.Drawing.Color.White
        Me.cmbtendertype.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbtendertype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbtendertype.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbtendertype.ForeColor = System.Drawing.Color.Black
        Me.cmbtendertype.FormattingEnabled = True
        Me.cmbtendertype.Items.AddRange(New Object() {"All", "Cash", "A.R Charge", "A.R Sales"})
        Me.cmbtendertype.Location = New System.Drawing.Point(825, 93)
        Me.cmbtendertype.Name = "cmbtendertype"
        Me.cmbtendertype.Size = New System.Drawing.Size(127, 26)
        Me.cmbtendertype.TabIndex = 11
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.Panel1.Controls.Add(Me.lbltranscount)
        Me.Panel1.Location = New System.Drawing.Point(60, 157)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(892, 23)
        Me.Panel1.TabIndex = 13
        '
        'lbltranscount
        '
        Me.lbltranscount.AutoSize = True
        Me.lbltranscount.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.lbltranscount.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltranscount.ForeColor = System.Drawing.Color.White
        Me.lbltranscount.Location = New System.Drawing.Point(3, 5)
        Me.lbltranscount.Name = "lbltranscount"
        Me.lbltranscount.Size = New System.Drawing.Size(112, 15)
        Me.lbltranscount.TabIndex = 14
        Me.lbltranscount.Text = "TRANSACTIONS"
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.Panel2.Controls.Add(Me.lblitemscount)
        Me.Panel2.Location = New System.Drawing.Point(60, 399)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(892, 23)
        Me.Panel2.TabIndex = 15
        '
        'lblitemscount
        '
        Me.lblitemscount.AutoSize = True
        Me.lblitemscount.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.lblitemscount.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblitemscount.ForeColor = System.Drawing.Color.White
        Me.lblitemscount.Location = New System.Drawing.Point(3, 5)
        Me.lblitemscount.Name = "lblitemscount"
        Me.lblitemscount.Size = New System.Drawing.Size(48, 15)
        Me.lblitemscount.TabIndex = 14
        Me.lblitemscount.Text = "ITEMS"
        '
        'btnvoids
        '
        Me.btnvoids.BackColor = System.Drawing.Color.Firebrick
        Me.btnvoids.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnvoids.FlatAppearance.BorderSize = 0
        Me.btnvoids.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnvoids.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnvoids.ForeColor = System.Drawing.Color.White
        Me.btnvoids.Image = CType(resources.GetObject("btnvoids.Image"), System.Drawing.Image)
        Me.btnvoids.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnvoids.Location = New System.Drawing.Point(190, 66)
        Me.btnvoids.Name = "btnvoids"
        Me.btnvoids.Size = New System.Drawing.Size(130, 31)
        Me.btnvoids.TabIndex = 5
        Me.btnvoids.Text = "VOIDS"
        Me.btnvoids.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnvoids.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnvoids.UseVisualStyleBackColor = False
        '
        'btnlogs
        '
        Me.btnlogs.BackColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.btnlogs.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnlogs.FlatAppearance.BorderSize = 0
        Me.btnlogs.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnlogs.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnlogs.ForeColor = System.Drawing.Color.White
        Me.btnlogs.Image = CType(resources.GetObject("btnlogs.Image"), System.Drawing.Image)
        Me.btnlogs.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnlogs.Location = New System.Drawing.Point(60, 66)
        Me.btnlogs.Name = "btnlogs"
        Me.btnlogs.Size = New System.Drawing.Size(130, 31)
        Me.btnlogs.TabIndex = 4
        Me.btnlogs.Text = "LOGS"
        Me.btnlogs.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnlogs.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnlogs.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(718, 131)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 15)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Type:"
        '
        'cmbtype
        '
        Me.cmbtype.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbtype.BackColor = System.Drawing.Color.White
        Me.cmbtype.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbtype.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbtype.ForeColor = System.Drawing.Color.Black
        Me.cmbtype.FormattingEnabled = True
        Me.cmbtype.Items.AddRange(New Object() {"All", "Retail", "Wholesale", "Coffee Shop"})
        Me.cmbtype.Location = New System.Drawing.Point(825, 128)
        Me.cmbtype.Name = "cmbtype"
        Me.cmbtype.Size = New System.Drawing.Size(127, 26)
        Me.cmbtype.TabIndex = 16
        '
        'lbldate
        '
        Me.lbldate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbldate.AutoSize = True
        Me.lbldate.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldate.Location = New System.Drawing.Point(718, 66)
        Me.lbldate.Name = "lbldate"
        Me.lbldate.Size = New System.Drawing.Size(146, 17)
        Me.lbldate.TabIndex = 3
        Me.lbldate.Text = "TIME_NOT_FOUND"
        '
        'txtsearch
        '
        Me.txtsearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtsearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtsearch.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsearch.Location = New System.Drawing.Point(60, 128)
        Me.txtsearch.Name = "txtsearch"
        Me.txtsearch.Size = New System.Drawing.Size(130, 23)
        Me.txtsearch.TabIndex = 18
        '
        'btnsearch
        '
        Me.btnsearch.BackColor = System.Drawing.SystemColors.HotTrack
        Me.btnsearch.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnsearch.FlatAppearance.BorderSize = 0
        Me.btnsearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnsearch.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsearch.ForeColor = System.Drawing.Color.White
        Me.btnsearch.Location = New System.Drawing.Point(190, 128)
        Me.btnsearch.Name = "btnsearch"
        Me.btnsearch.Size = New System.Drawing.Size(75, 23)
        Me.btnsearch.TabIndex = 19
        Me.btnsearch.Text = "Search"
        Me.btnsearch.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1010, 34)
        Me.Panel3.TabIndex = 20
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Gold
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1, 34)
        Me.Panel4.TabIndex = 22
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(56, 6)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(139, 22)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "ORDER LOGS"
        '
        'btncanceltransaction
        '
        Me.btncanceltransaction.BackColor = System.Drawing.Color.OrangeRed
        Me.btncanceltransaction.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btncanceltransaction.FlatAppearance.BorderSize = 0
        Me.btncanceltransaction.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btncanceltransaction.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btncanceltransaction.ForeColor = System.Drawing.Color.White
        Me.btncanceltransaction.Image = CType(resources.GetObject("btncanceltransaction.Image"), System.Drawing.Image)
        Me.btncanceltransaction.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btncanceltransaction.Location = New System.Drawing.Point(450, 66)
        Me.btncanceltransaction.Name = "btncanceltransaction"
        Me.btncanceltransaction.Size = New System.Drawing.Size(218, 31)
        Me.btncanceltransaction.TabIndex = 21
        Me.btncanceltransaction.Text = "CANCEL TRANSACTION"
        Me.btncanceltransaction.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btncanceltransaction.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btncanceltransaction.UseVisualStyleBackColor = False
        '
        'btncancellogs
        '
        Me.btncancellogs.BackColor = System.Drawing.Color.DarkOrange
        Me.btncancellogs.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btncancellogs.FlatAppearance.BorderSize = 0
        Me.btncancellogs.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btncancellogs.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btncancellogs.ForeColor = System.Drawing.Color.White
        Me.btncancellogs.Image = CType(resources.GetObject("btncancellogs.Image"), System.Drawing.Image)
        Me.btncancellogs.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btncancellogs.Location = New System.Drawing.Point(320, 66)
        Me.btncancellogs.Name = "btncancellogs"
        Me.btncancellogs.Size = New System.Drawing.Size(130, 31)
        Me.btncancellogs.TabIndex = 22
        Me.btncancellogs.Text = "CANCEL"
        Me.btncancellogs.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btncancellogs.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btncancellogs.UseVisualStyleBackColor = False
        '
        'orders
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1010, 508)
        Me.Controls.Add(Me.btncancellogs)
        Me.Controls.Add(Me.btncanceltransaction)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.btnsearch)
        Me.Controls.Add(Me.txtsearch)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbtype)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmbtendertype)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dtsearch)
        Me.Controls.Add(Me.cmbcustomers)
        Me.Controls.Add(Me.btnvoids)
        Me.Controls.Add(Me.btnlogs)
        Me.Controls.Add(Me.lbldate)
        Me.Controls.Add(Me.dgvitems)
        Me.Controls.Add(Me.dgvorders)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "orders"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Orders"
        CType(Me.dgvorders, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvitems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvorders As DataGridView
    Friend WithEvents dgvitems As DataGridView
    Friend WithEvents btnlogs As Button
    Friend WithEvents btnvoids As Button
    Friend WithEvents cmbcustomers As ComboBox
    Friend WithEvents dtsearch As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbtendertype As ComboBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lbltranscount As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lblitemscount As Label
    Friend WithEvents description As DataGridViewTextBoxColumn
    Friend WithEvents qty As DataGridViewTextBoxColumn
    Friend WithEvents price As DataGridViewTextBoxColumn
    Friend WithEvents discpercent As DataGridViewTextBoxColumn
    Friend WithEvents amt As DataGridViewTextBoxColumn
    Friend WithEvents request As DataGridViewTextBoxColumn
    Friend WithEvents free As DataGridViewCheckBoxColumn
    Friend WithEvents transnum As DataGridViewTextBoxColumn
    Friend WithEvents amtdue As DataGridViewTextBoxColumn
    Friend WithEvents tendertype As DataGridViewTextBoxColumn
    Friend WithEvents servicetype As DataGridViewTextBoxColumn
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbtype As ComboBox
    Friend WithEvents lbldate As Label
    Friend WithEvents txtsearch As TextBox
    Friend WithEvents btnsearch As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents btncanceltransaction As Button
    Friend WithEvents btncancellogs As Button
End Class
