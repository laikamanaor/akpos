<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cancel_tr
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvtrans = New System.Windows.Forms.DataGridView()
        Me.transnum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ordernum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.amtdue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.partialamt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tendertype = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.servicetype = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btncancel = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.dgvorders = New System.Windows.Forms.DataGridView()
        Me.txtsearch = New System.Windows.Forms.TextBox()
        Me.btnsearch = New System.Windows.Forms.Button()
        Me.cmbsales = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbtype = New System.Windows.Forms.ComboBox()
        Me.dtdate = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblclose = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lbltrans_count = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblitems_count = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.price = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.disc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.amt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvtrans, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvorders, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvtrans
        '
        Me.dgvtrans.AllowUserToAddRows = False
        Me.dgvtrans.AllowUserToDeleteRows = False
        Me.dgvtrans.AllowUserToResizeColumns = False
        Me.dgvtrans.AllowUserToResizeRows = False
        Me.dgvtrans.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvtrans.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvtrans.BackgroundColor = System.Drawing.Color.White
        Me.dgvtrans.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvtrans.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvtrans.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvtrans.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvtrans.ColumnHeadersHeight = 40
        Me.dgvtrans.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.transnum, Me.ordernum, Me.amtdue, Me.partialamt, Me.tendertype, Me.servicetype, Me.type, Me.btncancel})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvtrans.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvtrans.EnableHeadersVisualStyles = False
        Me.dgvtrans.GridColor = System.Drawing.Color.White
        Me.dgvtrans.Location = New System.Drawing.Point(41, 146)
        Me.dgvtrans.Name = "dgvtrans"
        Me.dgvtrans.RowHeadersVisible = False
        Me.dgvtrans.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvtrans.Size = New System.Drawing.Size(984, 166)
        Me.dgvtrans.TabIndex = 0
        '
        'transnum
        '
        Me.transnum.HeaderText = "Transnum"
        Me.transnum.Name = "transnum"
        Me.transnum.ReadOnly = True
        '
        'ordernum
        '
        Me.ordernum.HeaderText = "Ordernum"
        Me.ordernum.Name = "ordernum"
        Me.ordernum.ReadOnly = True
        '
        'amtdue
        '
        Me.amtdue.HeaderText = "Amount Due"
        Me.amtdue.Name = "amtdue"
        Me.amtdue.ReadOnly = True
        '
        'partialamt
        '
        Me.partialamt.HeaderText = "Partial Amount"
        Me.partialamt.Name = "partialamt"
        Me.partialamt.ReadOnly = True
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
        'type
        '
        Me.type.HeaderText = "Type"
        Me.type.Name = "type"
        Me.type.ReadOnly = True
        '
        'btncancel
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Firebrick
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        Me.btncancel.DefaultCellStyle = DataGridViewCellStyle2
        Me.btncancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btncancel.HeaderText = "Cancel"
        Me.btncancel.Name = "btncancel"
        Me.btncancel.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.btncancel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.btncancel.Text = "Cancel"
        Me.btncancel.UseColumnTextForButtonValue = True
        '
        'dgvorders
        '
        Me.dgvorders.AllowUserToAddRows = False
        Me.dgvorders.AllowUserToDeleteRows = False
        Me.dgvorders.AllowUserToResizeColumns = False
        Me.dgvorders.AllowUserToResizeRows = False
        Me.dgvorders.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvorders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvorders.BackgroundColor = System.Drawing.Color.White
        Me.dgvorders.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvorders.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvorders.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvorders.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvorders.ColumnHeadersHeight = 40
        Me.dgvorders.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.description, Me.qty, Me.price, Me.disc, Me.amt})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvorders.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvorders.EnableHeadersVisualStyles = False
        Me.dgvorders.GridColor = System.Drawing.Color.White
        Me.dgvorders.Location = New System.Drawing.Point(40, 345)
        Me.dgvorders.Name = "dgvorders"
        Me.dgvorders.RowHeadersVisible = False
        Me.dgvorders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvorders.Size = New System.Drawing.Size(984, 177)
        Me.dgvorders.TabIndex = 1
        '
        'txtsearch
        '
        Me.txtsearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtsearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtsearch.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsearch.Location = New System.Drawing.Point(41, 92)
        Me.txtsearch.Name = "txtsearch"
        Me.txtsearch.Size = New System.Drawing.Size(201, 25)
        Me.txtsearch.TabIndex = 2
        '
        'btnsearch
        '
        Me.btnsearch.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnsearch.FlatAppearance.BorderSize = 0
        Me.btnsearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnsearch.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsearch.ForeColor = System.Drawing.Color.White
        Me.btnsearch.Location = New System.Drawing.Point(242, 92)
        Me.btnsearch.Name = "btnsearch"
        Me.btnsearch.Size = New System.Drawing.Size(75, 25)
        Me.btnsearch.TabIndex = 3
        Me.btnsearch.Text = "Search"
        Me.btnsearch.UseVisualStyleBackColor = False
        '
        'cmbsales
        '
        Me.cmbsales.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbsales.BackColor = System.Drawing.Color.DodgerBlue
        Me.cmbsales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbsales.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbsales.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbsales.ForeColor = System.Drawing.Color.White
        Me.cmbsales.FormattingEnabled = True
        Me.cmbsales.Location = New System.Drawing.Point(904, 92)
        Me.cmbsales.Name = "cmbsales"
        Me.cmbsales.Size = New System.Drawing.Size(121, 25)
        Me.cmbsales.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DimGray
        Me.Label1.Location = New System.Drawing.Point(851, 97)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 15)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Sales:"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DimGray
        Me.Label2.Location = New System.Drawing.Point(649, 97)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 15)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Type:"
        '
        'cmbtype
        '
        Me.cmbtype.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbtype.BackColor = System.Drawing.Color.DodgerBlue
        Me.cmbtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbtype.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbtype.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbtype.ForeColor = System.Drawing.Color.White
        Me.cmbtype.FormattingEnabled = True
        Me.cmbtype.Items.AddRange(New Object() {"All", "Retail", "Wholesale", "Coffee Shop"})
        Me.cmbtype.Location = New System.Drawing.Point(702, 92)
        Me.cmbtype.Name = "cmbtype"
        Me.cmbtype.Size = New System.Drawing.Size(121, 25)
        Me.cmbtype.TabIndex = 6
        '
        'dtdate
        '
        Me.dtdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtdate.CustomFormat = "MM/dd/yyyy"
        Me.dtdate.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtdate.Location = New System.Drawing.Point(921, 63)
        Me.dtdate.Name = "dtdate"
        Me.dtdate.Size = New System.Drawing.Size(104, 23)
        Me.dtdate.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DimGray
        Me.Label3.Location = New System.Drawing.Point(873, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 15)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Date:"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.Panel1.Controls.Add(Me.lblclose)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1068, 34)
        Me.Panel1.TabIndex = 10
        '
        'lblclose
        '
        Me.lblclose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblclose.AutoSize = True
        Me.lblclose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblclose.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblclose.ForeColor = System.Drawing.Color.White
        Me.lblclose.Location = New System.Drawing.Point(1044, 6)
        Me.lblclose.Name = "lblclose"
        Me.lblclose.Size = New System.Drawing.Size(21, 22)
        Me.lblclose.TabIndex = 1
        Me.lblclose.Text = "X"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(3, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(237, 22)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "CANCEL TRANSACTION"
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.Panel2.Controls.Add(Me.lbltrans_count)
        Me.Panel2.Location = New System.Drawing.Point(42, 119)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(983, 28)
        Me.Panel2.TabIndex = 11
        '
        'lbltrans_count
        '
        Me.lbltrans_count.AutoSize = True
        Me.lbltrans_count.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltrans_count.ForeColor = System.Drawing.Color.White
        Me.lbltrans_count.Location = New System.Drawing.Point(3, 6)
        Me.lbltrans_count.Name = "lbltrans_count"
        Me.lbltrans_count.Size = New System.Drawing.Size(166, 18)
        Me.lbltrans_count.TabIndex = 15
        Me.lbltrans_count.Text = "TRANSACTIONS (0)"
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.Panel3.Controls.Add(Me.lblitems_count)
        Me.Panel3.Location = New System.Drawing.Point(41, 318)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(983, 28)
        Me.Panel3.TabIndex = 12
        '
        'lblitems_count
        '
        Me.lblitems_count.AutoSize = True
        Me.lblitems_count.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblitems_count.ForeColor = System.Drawing.Color.White
        Me.lblitems_count.Location = New System.Drawing.Point(4, 6)
        Me.lblitems_count.Name = "lblitems_count"
        Me.lblitems_count.Size = New System.Drawing.Size(84, 18)
        Me.lblitems_count.TabIndex = 16
        Me.lblitems_count.Text = "ITEMS (0)"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.DimGray
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel4.Location = New System.Drawing.Point(0, 34)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1, 520)
        Me.Panel4.TabIndex = 13
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.DimGray
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel5.Location = New System.Drawing.Point(1, 553)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1067, 1)
        Me.Panel5.TabIndex = 14
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.DimGray
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel6.Location = New System.Drawing.Point(1067, 34)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(1, 519)
        Me.Panel6.TabIndex = 14
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
        'disc
        '
        Me.disc.HeaderText = "Disc. %"
        Me.disc.Name = "disc"
        Me.disc.ReadOnly = True
        '
        'amt
        '
        Me.amt.HeaderText = "Amount"
        Me.amt.Name = "amt"
        Me.amt.ReadOnly = True
        '
        'cancel_tr
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1068, 554)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dtdate)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbtype)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbsales)
        Me.Controls.Add(Me.btnsearch)
        Me.Controls.Add(Me.txtsearch)
        Me.Controls.Add(Me.dgvorders)
        Me.Controls.Add(Me.dgvtrans)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "cancel_tr"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cancel Transaction"
        CType(Me.dgvtrans, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvorders, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvtrans As DataGridView
    Friend WithEvents dgvorders As DataGridView
    Friend WithEvents txtsearch As TextBox
    Friend WithEvents btnsearch As Button
    Friend WithEvents cmbsales As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbtype As ComboBox
    Friend WithEvents transnum As DataGridViewTextBoxColumn
    Friend WithEvents ordernum As DataGridViewTextBoxColumn
    Friend WithEvents amtdue As DataGridViewTextBoxColumn
    Friend WithEvents partialamt As DataGridViewTextBoxColumn
    Friend WithEvents tendertype As DataGridViewTextBoxColumn
    Friend WithEvents servicetype As DataGridViewTextBoxColumn
    Friend WithEvents type As DataGridViewTextBoxColumn
    Friend WithEvents btncancel As DataGridViewButtonColumn
    Friend WithEvents dtdate As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblclose As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents lbltrans_count As Label
    Friend WithEvents lblitems_count As Label
    Friend WithEvents description As DataGridViewTextBoxColumn
    Friend WithEvents qty As DataGridViewTextBoxColumn
    Friend WithEvents price As DataGridViewTextBoxColumn
    Friend WithEvents disc As DataGridViewTextBoxColumn
    Friend WithEvents amt As DataGridViewTextBoxColumn
End Class
