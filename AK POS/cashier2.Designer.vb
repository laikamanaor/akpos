<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class cashier2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cashier2))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.txtresult = New System.Windows.Forms.TextBox()
        Me.btnadd = New System.Windows.Forms.Button()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.btnitemnxt = New System.Windows.Forms.Button()
        Me.btnitemprev = New System.Windows.Forms.Button()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblpendingorders = New System.Windows.Forms.Label()
        Me.lblpendingamount = New System.Windows.Forms.Label()
        Me.btnrefresh = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbtype = New System.Windows.Forms.ComboBox()
        Me.cmbsales = New System.Windows.Forms.ComboBox()
        Me.cmbtendertype = New System.Windows.Forms.ComboBox()
        Me.btnsearch = New System.Windows.Forms.Button()
        Me.txtsearch = New System.Windows.Forms.TextBox()
        Me.dgvorders = New System.Windows.Forms.DataGridView()
        Me.orderid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ordernum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.amount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tendertype = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.counter = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.postype = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnvoid = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.btnmodify = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.btnconfirm = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.dgvitems = New System.Windows.Forms.DataGridView()
        Me.item = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.quantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.price = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.discpercent = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.totalprice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.free = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblchange = New System.Windows.Forms.Label()
        Me.lbltenderamount = New System.Windows.Forms.Label()
        Me.lblamount = New System.Windows.Forms.Label()
        Me.lblless = New System.Windows.Forms.Label()
        Me.lbldisctype = New System.Windows.Forms.Label()
        Me.lblsubtotal = New System.Windows.Forms.Label()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel6.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel13.SuspendLayout()
        Me.Panel12.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvorders, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.dgvitems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.Panel6.Controls.Add(Me.Panel11)
        Me.Panel6.Controls.Add(Me.Label1)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(935, 37)
        Me.Panel6.TabIndex = 6
        '
        'Panel11
        '
        Me.Panel11.BackColor = System.Drawing.Color.Gold
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel11.Location = New System.Drawing.Point(0, 0)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(1, 37)
        Me.Panel11.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(21, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(206, 24)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "PENDING ORDERS"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.Panel13)
        Me.Panel1.Controls.Add(Me.btnitemnxt)
        Me.Panel1.Controls.Add(Me.btnitemprev)
        Me.Panel1.Controls.Add(Me.Panel12)
        Me.Panel1.Controls.Add(Me.lblpendingamount)
        Me.Panel1.Controls.Add(Me.btnrefresh)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.cmbtype)
        Me.Panel1.Controls.Add(Me.cmbsales)
        Me.Panel1.Controls.Add(Me.cmbtendertype)
        Me.Panel1.Controls.Add(Me.btnsearch)
        Me.Panel1.Controls.Add(Me.txtsearch)
        Me.Panel1.Controls.Add(Me.dgvorders)
        Me.Panel1.Location = New System.Drawing.Point(25, 56)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(469, 488)
        Me.Panel1.TabIndex = 7
        '
        'Panel13
        '
        Me.Panel13.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel13.BackColor = System.Drawing.Color.White
        Me.Panel13.Controls.Add(Me.txtresult)
        Me.Panel13.Controls.Add(Me.btnadd)
        Me.Panel13.Controls.Add(Me.Label18)
        Me.Panel13.Location = New System.Drawing.Point(163, 366)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(303, 113)
        Me.Panel13.TabIndex = 50
        '
        'txtresult
        '
        Me.txtresult.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtresult.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtresult.Location = New System.Drawing.Point(34, 33)
        Me.txtresult.Multiline = True
        Me.txtresult.Name = "txtresult"
        Me.txtresult.ReadOnly = True
        Me.txtresult.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.txtresult.Size = New System.Drawing.Size(250, 25)
        Me.txtresult.TabIndex = 47
        '
        'btnadd
        '
        Me.btnadd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnadd.BackColor = System.Drawing.Color.ForestGreen
        Me.btnadd.FlatAppearance.BorderSize = 0
        Me.btnadd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnadd.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnadd.ForeColor = System.Drawing.Color.White
        Me.btnadd.Location = New System.Drawing.Point(211, 73)
        Me.btnadd.Name = "btnadd"
        Me.btnadd.Size = New System.Drawing.Size(75, 25)
        Me.btnadd.TabIndex = 46
        Me.btnadd.Text = "ADD"
        Me.btnadd.UseVisualStyleBackColor = False
        '
        'Label18
        '
        Me.Label18.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.DimGray
        Me.Label18.Location = New System.Drawing.Point(31, 14)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(260, 15)
        Me.Label18.TabIndex = 48
        Me.Label18.Text = "ADD DEPOSIT OR ADVANCE PAYMENT:"
        '
        'btnitemnxt
        '
        Me.btnitemnxt.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnitemnxt.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.btnitemnxt.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnitemnxt.FlatAppearance.BorderSize = 0
        Me.btnitemnxt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnitemnxt.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnitemnxt.ForeColor = System.Drawing.Color.White
        Me.btnitemnxt.Image = CType(resources.GetObject("btnitemnxt.Image"), System.Drawing.Image)
        Me.btnitemnxt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnitemnxt.Location = New System.Drawing.Point(278, 336)
        Me.btnitemnxt.Name = "btnitemnxt"
        Me.btnitemnxt.Size = New System.Drawing.Size(78, 23)
        Me.btnitemnxt.TabIndex = 21
        Me.btnitemnxt.Text = "Nxt."
        Me.btnitemnxt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnitemnxt.UseVisualStyleBackColor = False
        '
        'btnitemprev
        '
        Me.btnitemprev.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnitemprev.BackColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(117, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.btnitemprev.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnitemprev.FlatAppearance.BorderSize = 0
        Me.btnitemprev.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnitemprev.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnitemprev.ForeColor = System.Drawing.Color.White
        Me.btnitemprev.Image = CType(resources.GetObject("btnitemprev.Image"), System.Drawing.Image)
        Me.btnitemprev.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnitemprev.Location = New System.Drawing.Point(200, 336)
        Me.btnitemprev.Name = "btnitemprev"
        Me.btnitemprev.Size = New System.Drawing.Size(78, 23)
        Me.btnitemprev.TabIndex = 20
        Me.btnitemprev.Text = "Prev."
        Me.btnitemprev.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnitemprev.UseVisualStyleBackColor = False
        '
        'Panel12
        '
        Me.Panel12.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel12.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.Panel12.Controls.Add(Me.PictureBox1)
        Me.Panel12.Controls.Add(Me.lblpendingorders)
        Me.Panel12.Location = New System.Drawing.Point(3, 85)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(463, 28)
        Me.Panel12.TabIndex = 11
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(3, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(20, 20)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 9
        Me.PictureBox1.TabStop = False
        '
        'lblpendingorders
        '
        Me.lblpendingorders.AutoSize = True
        Me.lblpendingorders.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblpendingorders.ForeColor = System.Drawing.Color.White
        Me.lblpendingorders.Location = New System.Drawing.Point(27, 8)
        Me.lblpendingorders.Name = "lblpendingorders"
        Me.lblpendingorders.Size = New System.Drawing.Size(79, 14)
        Me.lblpendingorders.TabIndex = 8
        Me.lblpendingorders.Text = "(0) Page: 0/0"
        '
        'lblpendingamount
        '
        Me.lblpendingamount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblpendingamount.AutoSize = True
        Me.lblpendingamount.Font = New System.Drawing.Font("Arial Unicode MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblpendingamount.ForeColor = System.Drawing.Color.ForestGreen
        Me.lblpendingamount.Location = New System.Drawing.Point(3, 338)
        Me.lblpendingamount.Name = "lblpendingamount"
        Me.lblpendingamount.Size = New System.Drawing.Size(157, 18)
        Me.lblpendingamount.TabIndex = 10
        Me.lblpendingamount.Text = "Pending Amount: 0.00"
        '
        'btnrefresh
        '
        Me.btnrefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnrefresh.BackColor = System.Drawing.SystemColors.HotTrack
        Me.btnrefresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnrefresh.FlatAppearance.BorderSize = 0
        Me.btnrefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnrefresh.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnrefresh.ForeColor = System.Drawing.Color.White
        Me.btnrefresh.Image = CType(resources.GetObject("btnrefresh.Image"), System.Drawing.Image)
        Me.btnrefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnrefresh.Location = New System.Drawing.Point(362, 332)
        Me.btnrefresh.Name = "btnrefresh"
        Me.btnrefresh.Size = New System.Drawing.Size(104, 31)
        Me.btnrefresh.TabIndex = 9
        Me.btnrefresh.Text = "Refresh"
        Me.btnrefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnrefresh.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DimGray
        Me.Label4.Location = New System.Drawing.Point(243, 60)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 14)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Type:"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DimGray
        Me.Label3.Location = New System.Drawing.Point(243, 33)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 14)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Sales Agent:"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DimGray
        Me.Label2.Location = New System.Drawing.Point(243, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 14)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Tender Type:"
        '
        'cmbtype
        '
        Me.cmbtype.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbtype.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.cmbtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbtype.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbtype.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbtype.ForeColor = System.Drawing.Color.Black
        Me.cmbtype.FormattingEnabled = True
        Me.cmbtype.Items.AddRange(New Object() {"All", "Retail", "Wholesale", "Coffee Shop"})
        Me.cmbtype.Location = New System.Drawing.Point(335, 57)
        Me.cmbtype.Name = "cmbtype"
        Me.cmbtype.Size = New System.Drawing.Size(131, 22)
        Me.cmbtype.TabIndex = 5
        '
        'cmbsales
        '
        Me.cmbsales.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbsales.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.cmbsales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbsales.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbsales.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbsales.ForeColor = System.Drawing.Color.Black
        Me.cmbsales.FormattingEnabled = True
        Me.cmbsales.Items.AddRange(New Object() {"All"})
        Me.cmbsales.Location = New System.Drawing.Point(335, 30)
        Me.cmbsales.Name = "cmbsales"
        Me.cmbsales.Size = New System.Drawing.Size(131, 22)
        Me.cmbsales.TabIndex = 4
        '
        'cmbtendertype
        '
        Me.cmbtendertype.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbtendertype.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.cmbtendertype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbtendertype.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbtendertype.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbtendertype.ForeColor = System.Drawing.Color.Black
        Me.cmbtendertype.FormattingEnabled = True
        Me.cmbtendertype.Items.AddRange(New Object() {"All", "Cash", "A.R Sales", "A.R Charge"})
        Me.cmbtendertype.Location = New System.Drawing.Point(335, 3)
        Me.cmbtendertype.Name = "cmbtendertype"
        Me.cmbtendertype.Size = New System.Drawing.Size(131, 22)
        Me.cmbtendertype.TabIndex = 3
        '
        'btnsearch
        '
        Me.btnsearch.BackColor = System.Drawing.SystemColors.HotTrack
        Me.btnsearch.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnsearch.FlatAppearance.BorderSize = 0
        Me.btnsearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnsearch.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsearch.ForeColor = System.Drawing.Color.White
        Me.btnsearch.Location = New System.Drawing.Point(143, 57)
        Me.btnsearch.Name = "btnsearch"
        Me.btnsearch.Size = New System.Drawing.Size(75, 25)
        Me.btnsearch.TabIndex = 2
        Me.btnsearch.Text = "Search"
        Me.btnsearch.UseVisualStyleBackColor = False
        '
        'txtsearch
        '
        Me.txtsearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtsearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtsearch.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsearch.Location = New System.Drawing.Point(3, 57)
        Me.txtsearch.Name = "txtsearch"
        Me.txtsearch.Size = New System.Drawing.Size(141, 25)
        Me.txtsearch.TabIndex = 1
        '
        'dgvorders
        '
        Me.dgvorders.AllowUserToAddRows = False
        Me.dgvorders.AllowUserToDeleteRows = False
        Me.dgvorders.AllowUserToResizeRows = False
        Me.dgvorders.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvorders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvorders.BackgroundColor = System.Drawing.Color.White
        Me.dgvorders.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvorders.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvorders.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvorders.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvorders.ColumnHeadersHeight = 40
        Me.dgvorders.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.orderid, Me.ordernum, Me.amount, Me.tendertype, Me.counter, Me.postype, Me.btnvoid, Me.btnmodify, Me.btnconfirm})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvorders.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvorders.EnableHeadersVisualStyles = False
        Me.dgvorders.GridColor = System.Drawing.Color.DimGray
        Me.dgvorders.Location = New System.Drawing.Point(3, 110)
        Me.dgvorders.Name = "dgvorders"
        Me.dgvorders.RowHeadersVisible = False
        Me.dgvorders.Size = New System.Drawing.Size(463, 216)
        Me.dgvorders.TabIndex = 0
        '
        'orderid
        '
        Me.orderid.HeaderText = "ID"
        Me.orderid.Name = "orderid"
        Me.orderid.ReadOnly = True
        Me.orderid.Visible = False
        '
        'ordernum
        '
        Me.ordernum.HeaderText = "#"
        Me.ordernum.Name = "ordernum"
        Me.ordernum.ReadOnly = True
        '
        'amount
        '
        Me.amount.HeaderText = "Amount"
        Me.amount.Name = "amount"
        Me.amount.ReadOnly = True
        '
        'tendertype
        '
        Me.tendertype.HeaderText = "Tender Type"
        Me.tendertype.Name = "tendertype"
        Me.tendertype.ReadOnly = True
        '
        'counter
        '
        Me.counter.HeaderText = "Counter"
        Me.counter.Name = "counter"
        Me.counter.ReadOnly = True
        '
        'postype
        '
        Me.postype.HeaderText = "Type"
        Me.postype.Name = "postype"
        Me.postype.ReadOnly = True
        '
        'btnvoid
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Firebrick
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        Me.btnvoid.DefaultCellStyle = DataGridViewCellStyle2
        Me.btnvoid.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnvoid.HeaderText = "Action"
        Me.btnvoid.Name = "btnvoid"
        Me.btnvoid.ReadOnly = True
        Me.btnvoid.Text = "Void"
        Me.btnvoid.ToolTipText = "Void Order"
        Me.btnvoid.UseColumnTextForButtonValue = True
        '
        'btnmodify
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White
        Me.btnmodify.DefaultCellStyle = DataGridViewCellStyle3
        Me.btnmodify.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnmodify.HeaderText = "Action"
        Me.btnmodify.Name = "btnmodify"
        Me.btnmodify.ReadOnly = True
        Me.btnmodify.Text = "Modify"
        Me.btnmodify.ToolTipText = "Modify Order"
        Me.btnmodify.UseColumnTextForButtonValue = True
        '
        'btnconfirm
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.ForestGreen
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.White
        Me.btnconfirm.DefaultCellStyle = DataGridViewCellStyle4
        Me.btnconfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnconfirm.HeaderText = "Action"
        Me.btnconfirm.Name = "btnconfirm"
        Me.btnconfirm.ReadOnly = True
        Me.btnconfirm.Text = "Confirm"
        Me.btnconfirm.ToolTipText = "Confirm Order"
        Me.btnconfirm.UseColumnTextForButtonValue = True
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.dgvitems)
        Me.Panel2.Location = New System.Drawing.Point(500, 56)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(423, 220)
        Me.Panel2.TabIndex = 8
        '
        'dgvitems
        '
        Me.dgvitems.AllowUserToAddRows = False
        Me.dgvitems.AllowUserToDeleteRows = False
        Me.dgvitems.AllowUserToResizeRows = False
        Me.dgvitems.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvitems.BackgroundColor = System.Drawing.Color.White
        Me.dgvitems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvitems.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvitems.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvitems.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvitems.ColumnHeadersHeight = 40
        Me.dgvitems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.item, Me.quantity, Me.price, Me.discpercent, Me.totalprice, Me.free})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvitems.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgvitems.EnableHeadersVisualStyles = False
        Me.dgvitems.GridColor = System.Drawing.Color.DimGray
        Me.dgvitems.Location = New System.Drawing.Point(3, 5)
        Me.dgvitems.Name = "dgvitems"
        Me.dgvitems.RowHeadersVisible = False
        Me.dgvitems.Size = New System.Drawing.Size(417, 212)
        Me.dgvitems.TabIndex = 9
        '
        'item
        '
        Me.item.HeaderText = "Item"
        Me.item.Name = "item"
        Me.item.ReadOnly = True
        '
        'quantity
        '
        Me.quantity.HeaderText = "Qty."
        Me.quantity.Name = "quantity"
        Me.quantity.ReadOnly = True
        Me.quantity.Width = 60
        '
        'price
        '
        Me.price.HeaderText = "Price"
        Me.price.Name = "price"
        Me.price.ReadOnly = True
        Me.price.Width = 75
        '
        'discpercent
        '
        Me.discpercent.HeaderText = "Disc. %"
        Me.discpercent.Name = "discpercent"
        Me.discpercent.ReadOnly = True
        Me.discpercent.Width = 60
        '
        'totalprice
        '
        Me.totalprice.HeaderText = "Total Price"
        Me.totalprice.Name = "totalprice"
        Me.totalprice.ReadOnly = True
        Me.totalprice.Width = 80
        '
        'free
        '
        Me.free.HeaderText = "Free"
        Me.free.Name = "free"
        Me.free.ReadOnly = True
        Me.free.Width = 40
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer))
        Me.Panel3.Controls.Add(Me.lblchange)
        Me.Panel3.Controls.Add(Me.lbltenderamount)
        Me.Panel3.Controls.Add(Me.lblamount)
        Me.Panel3.Controls.Add(Me.lblless)
        Me.Panel3.Controls.Add(Me.lbldisctype)
        Me.Panel3.Controls.Add(Me.lblsubtotal)
        Me.Panel3.Controls.Add(Me.Panel10)
        Me.Panel3.Controls.Add(Me.Panel9)
        Me.Panel3.Controls.Add(Me.Panel8)
        Me.Panel3.Controls.Add(Me.Panel7)
        Me.Panel3.Controls.Add(Me.Panel5)
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Location = New System.Drawing.Point(503, 282)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(417, 259)
        Me.Panel3.TabIndex = 9
        '
        'lblchange
        '
        Me.lblchange.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblchange.BackColor = System.Drawing.Color.Transparent
        Me.lblchange.Enabled = False
        Me.lblchange.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblchange.ForeColor = System.Drawing.Color.White
        Me.lblchange.Location = New System.Drawing.Point(169, 233)
        Me.lblchange.Name = "lblchange"
        Me.lblchange.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblchange.Size = New System.Drawing.Size(216, 18)
        Me.lblchange.TabIndex = 23
        Me.lblchange.Text = "0.00"
        '
        'lbltenderamount
        '
        Me.lbltenderamount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbltenderamount.BackColor = System.Drawing.Color.Transparent
        Me.lbltenderamount.Enabled = False
        Me.lbltenderamount.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltenderamount.ForeColor = System.Drawing.Color.White
        Me.lbltenderamount.Location = New System.Drawing.Point(169, 201)
        Me.lbltenderamount.Name = "lbltenderamount"
        Me.lbltenderamount.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lbltenderamount.Size = New System.Drawing.Size(216, 18)
        Me.lbltenderamount.TabIndex = 22
        Me.lbltenderamount.Text = "0.00"
        '
        'lblamount
        '
        Me.lblamount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblamount.BackColor = System.Drawing.Color.Transparent
        Me.lblamount.Enabled = False
        Me.lblamount.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblamount.ForeColor = System.Drawing.Color.White
        Me.lblamount.Location = New System.Drawing.Point(169, 169)
        Me.lblamount.Name = "lblamount"
        Me.lblamount.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblamount.Size = New System.Drawing.Size(216, 18)
        Me.lblamount.TabIndex = 21
        Me.lblamount.Text = "0.00"
        '
        'lblless
        '
        Me.lblless.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblless.BackColor = System.Drawing.Color.Transparent
        Me.lblless.Enabled = False
        Me.lblless.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblless.ForeColor = System.Drawing.Color.White
        Me.lblless.Location = New System.Drawing.Point(169, 137)
        Me.lblless.Name = "lblless"
        Me.lblless.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblless.Size = New System.Drawing.Size(216, 18)
        Me.lblless.TabIndex = 20
        Me.lblless.Text = "0%"
        '
        'lbldisctype
        '
        Me.lbldisctype.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbldisctype.BackColor = System.Drawing.Color.Transparent
        Me.lbldisctype.Enabled = False
        Me.lbldisctype.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldisctype.ForeColor = System.Drawing.Color.White
        Me.lbldisctype.Location = New System.Drawing.Point(169, 102)
        Me.lbldisctype.Name = "lbldisctype"
        Me.lbldisctype.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lbldisctype.Size = New System.Drawing.Size(216, 18)
        Me.lbldisctype.TabIndex = 19
        Me.lbldisctype.Text = "N/A"
        '
        'lblsubtotal
        '
        Me.lblsubtotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblsubtotal.BackColor = System.Drawing.Color.Transparent
        Me.lblsubtotal.Enabled = False
        Me.lblsubtotal.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsubtotal.ForeColor = System.Drawing.Color.White
        Me.lblsubtotal.Location = New System.Drawing.Point(169, 61)
        Me.lblsubtotal.Name = "lblsubtotal"
        Me.lblsubtotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblsubtotal.Size = New System.Drawing.Size(216, 18)
        Me.lblsubtotal.TabIndex = 18
        Me.lblsubtotal.Text = "0.00"
        '
        'Panel10
        '
        Me.Panel10.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel10.BackColor = System.Drawing.Color.White
        Me.Panel10.Location = New System.Drawing.Point(25, 226)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(357, 1)
        Me.Panel10.TabIndex = 8
        '
        'Panel9
        '
        Me.Panel9.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel9.BackColor = System.Drawing.Color.White
        Me.Panel9.Location = New System.Drawing.Point(25, 194)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(357, 1)
        Me.Panel9.TabIndex = 8
        '
        'Panel8
        '
        Me.Panel8.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel8.BackColor = System.Drawing.Color.White
        Me.Panel8.Location = New System.Drawing.Point(25, 162)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(357, 1)
        Me.Panel8.TabIndex = 9
        '
        'Panel7
        '
        Me.Panel7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel7.BackColor = System.Drawing.Color.White
        Me.Panel7.Location = New System.Drawing.Point(25, 129)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(357, 1)
        Me.Panel7.TabIndex = 8
        '
        'Panel5
        '
        Me.Panel5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel5.BackColor = System.Drawing.Color.White
        Me.Panel5.Location = New System.Drawing.Point(25, 93)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(357, 1)
        Me.Panel5.TabIndex = 8
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.BackColor = System.Drawing.Color.White
        Me.Panel4.Location = New System.Drawing.Point(25, 48)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(357, 1)
        Me.Panel4.TabIndex = 7
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(22, 233)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(61, 15)
        Me.Label11.TabIndex = 6
        Me.Label11.Text = "Change:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(22, 201)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(110, 15)
        Me.Label10.TabIndex = 5
        Me.Label10.Text = "Tender Amount:"
        '
        'Label9
        '
        Me.Label9.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(22, 169)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(116, 15)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "Amount Payable:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(22, 137)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 15)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "Less:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(22, 102)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(103, 15)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Discount Type:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(22, 61)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 15)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Sub Total:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(21, 13)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 22)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "BILLS"
        '
        'cashier2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(935, 556)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel6)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "cashier2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "cashier2"
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel13.ResumeLayout(False)
        Me.Panel13.PerformLayout()
        Me.Panel12.ResumeLayout(False)
        Me.Panel12.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvorders, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.dgvitems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel6 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents dgvorders As DataGridView
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents btnsearch As Button
    Friend WithEvents txtsearch As TextBox
    Friend WithEvents cmbtendertype As ComboBox
    Friend WithEvents cmbtype As ComboBox
    Friend WithEvents cmbsales As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Panel10 As Panel
    Friend WithEvents Panel9 As Panel
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents lblchange As Label
    Friend WithEvents lbltenderamount As Label
    Friend WithEvents lblamount As Label
    Friend WithEvents lblless As Label
    Friend WithEvents lbldisctype As Label
    Friend WithEvents lblsubtotal As Label
    Friend WithEvents orderid As DataGridViewTextBoxColumn
    Friend WithEvents ordernum As DataGridViewTextBoxColumn
    Friend WithEvents amount As DataGridViewTextBoxColumn
    Friend WithEvents tendertype As DataGridViewTextBoxColumn
    Friend WithEvents counter As DataGridViewTextBoxColumn
    Friend WithEvents postype As DataGridViewTextBoxColumn
    Friend WithEvents btnvoid As DataGridViewButtonColumn
    Friend WithEvents btnmodify As DataGridViewButtonColumn
    Friend WithEvents btnconfirm As DataGridViewButtonColumn
    Friend WithEvents dgvitems As DataGridView
    Friend WithEvents item As DataGridViewTextBoxColumn
    Friend WithEvents quantity As DataGridViewTextBoxColumn
    Friend WithEvents price As DataGridViewTextBoxColumn
    Friend WithEvents discpercent As DataGridViewTextBoxColumn
    Friend WithEvents totalprice As DataGridViewTextBoxColumn
    Friend WithEvents free As DataGridViewCheckBoxColumn
    Friend WithEvents btnrefresh As Button
    Friend WithEvents Panel11 As Panel
    Friend WithEvents lblpendingamount As Label
    Friend WithEvents Panel12 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblpendingorders As Label
    Friend WithEvents btnitemnxt As Button
    Friend WithEvents btnitemprev As Button
    Friend WithEvents Panel13 As Panel
    Friend WithEvents txtresult As TextBox
    Friend WithEvents btnadd As Button
    Friend WithEvents Label18 As Label
End Class
