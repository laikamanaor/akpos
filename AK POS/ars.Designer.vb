<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ars
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvARS = New System.Windows.Forms.DataGridView()
        Me.action = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.arnum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.transnum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.amtdue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.namee = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.datee = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnedit = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.dgvArs2 = New System.Windows.Forms.DataGridView()
        Me.description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.quantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.price = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.amount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.lblError2 = New System.Windows.Forms.Label()
        Me.lblErrror1 = New System.Windows.Forms.Label()
        Me.btnsearch = New System.Windows.Forms.Button()
        Me.txtboxsearch = New System.Windows.Forms.TextBox()
        Me.btnunpaid = New System.Windows.Forms.Button()
        Me.btnpaid = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblbalanceamount = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtchange = New System.Windows.Forms.TextBox()
        Me.txttenderamt = New System.Windows.Forms.TextBox()
        Me.lbltotalamount = New System.Windows.Forms.Label()
        Me.lblvatamount = New System.Windows.Forms.Label()
        Me.lblvatsales = New System.Windows.Forms.Label()
        Me.lblvatexemptsales = New System.Windows.Forms.Label()
        Me.lbldelcharge = New System.Windows.Forms.Label()
        Me.lblless = New System.Windows.Forms.Label()
        Me.lbldisctype = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblsubtotal = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.lblProductionClose = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblRemarks = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblSAPNo = New System.Windows.Forms.Label()
        Me.lbltype = New System.Windows.Forms.Label()
        Me.datesearch = New System.Windows.Forms.DateTimePicker()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.btnProceed = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtboxRemarks = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtboxSAPNo = New System.Windows.Forms.TextBox()
        Me.cmbtype = New System.Windows.Forms.ComboBox()
        Me.checkfollowup = New System.Windows.Forms.CheckBox()
        Me.PanelSAP = New System.Windows.Forms.Panel()
        Me.btneditar = New System.Windows.Forms.Button()
        Me.panelRemarks = New System.Windows.Forms.Panel()
        Me.lblhide = New System.Windows.Forms.Label()
        Me.btnproceed1 = New System.Windows.Forms.Button()
        Me.txtremarks = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblheader = New System.Windows.Forms.Label()
        Me.paneldate = New System.Windows.Forms.Panel()
        Me.lblclose3 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.btnok = New System.Windows.Forms.Button()
        Me.dtdate = New System.Windows.Forms.DateTimePicker()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        CType(Me.dgvARS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvArs2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.PanelSAP.SuspendLayout()
        Me.panelRemarks.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.paneldate.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvARS
        '
        Me.dgvARS.AllowUserToAddRows = False
        Me.dgvARS.AllowUserToDeleteRows = False
        Me.dgvARS.AllowUserToResizeColumns = False
        Me.dgvARS.AllowUserToResizeRows = False
        Me.dgvARS.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvARS.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvARS.BackgroundColor = System.Drawing.Color.White
        Me.dgvARS.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvARS.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvARS.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvARS.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvARS.ColumnHeadersHeight = 40
        Me.dgvARS.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.action, Me.arnum, Me.transnum, Me.amtdue, Me.namee, Me.datee, Me.btnedit})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvARS.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgvARS.EnableHeadersVisualStyles = False
        Me.dgvARS.GridColor = System.Drawing.Color.White
        Me.dgvARS.Location = New System.Drawing.Point(29, 131)
        Me.dgvARS.Name = "dgvARS"
        Me.dgvARS.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvARS.RowHeadersVisible = False
        Me.dgvARS.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvARS.Size = New System.Drawing.Size(1289, 290)
        Me.dgvARS.TabIndex = 0
        '
        'action
        '
        Me.action.FillWeight = 50.0!
        Me.action.HeaderText = "Action"
        Me.action.Name = "action"
        '
        'arnum
        '
        Me.arnum.HeaderText = "A.R #"
        Me.arnum.Name = "arnum"
        Me.arnum.ReadOnly = True
        Me.arnum.Visible = False
        '
        'transnum
        '
        Me.transnum.HeaderText = "Trans. #"
        Me.transnum.Name = "transnum"
        Me.transnum.ReadOnly = True
        '
        'amtdue
        '
        Me.amtdue.HeaderText = "Amount Due"
        Me.amtdue.Name = "amtdue"
        Me.amtdue.ReadOnly = True
        '
        'namee
        '
        Me.namee.HeaderText = "Name"
        Me.namee.Name = "namee"
        Me.namee.ReadOnly = True
        '
        'datee
        '
        Me.datee.HeaderText = "Date"
        Me.datee.Name = "datee"
        Me.datee.ReadOnly = True
        '
        'btnedit
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.White
        Me.btnedit.DefaultCellStyle = DataGridViewCellStyle7
        Me.btnedit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnedit.HeaderText = "Edit"
        Me.btnedit.Name = "btnedit"
        Me.btnedit.ReadOnly = True
        Me.btnedit.Text = "Edit A.R #"
        Me.btnedit.UseColumnTextForButtonValue = True
        '
        'dgvArs2
        '
        Me.dgvArs2.AllowUserToAddRows = False
        Me.dgvArs2.AllowUserToDeleteRows = False
        Me.dgvArs2.AllowUserToResizeColumns = False
        Me.dgvArs2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvArs2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvArs2.BackgroundColor = System.Drawing.Color.White
        Me.dgvArs2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvArs2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvArs2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvArs2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvArs2.ColumnHeadersHeight = 40
        Me.dgvArs2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.description, Me.quantity, Me.price, Me.amount})
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvArs2.DefaultCellStyle = DataGridViewCellStyle10
        Me.dgvArs2.EnableHeadersVisualStyles = False
        Me.dgvArs2.GridColor = System.Drawing.Color.White
        Me.dgvArs2.Location = New System.Drawing.Point(29, 427)
        Me.dgvArs2.Name = "dgvArs2"
        Me.dgvArs2.ReadOnly = True
        Me.dgvArs2.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvArs2.RowHeadersVisible = False
        Me.dgvArs2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvArs2.Size = New System.Drawing.Size(721, 253)
        Me.dgvArs2.TabIndex = 1
        '
        'description
        '
        Me.description.HeaderText = "Description"
        Me.description.Name = "description"
        Me.description.ReadOnly = True
        '
        'quantity
        '
        Me.quantity.HeaderText = "Quantity"
        Me.quantity.Name = "quantity"
        Me.quantity.ReadOnly = True
        '
        'price
        '
        Me.price.HeaderText = "Price"
        Me.price.Name = "price"
        Me.price.ReadOnly = True
        '
        'amount
        '
        Me.amount.HeaderText = "Amount"
        Me.amount.Name = "amount"
        Me.amount.ReadOnly = True
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
        Me.btnSubmit.Location = New System.Drawing.Point(431, 202)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(105, 31)
        Me.btnSubmit.TabIndex = 2
        Me.btnSubmit.Text = "SUBMIT"
        Me.btnSubmit.UseVisualStyleBackColor = False
        '
        'lblError2
        '
        Me.lblError2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblError2.AutoSize = True
        Me.lblError2.BackColor = System.Drawing.Color.White
        Me.lblError2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblError2.ForeColor = System.Drawing.Color.DimGray
        Me.lblError2.Location = New System.Drawing.Point(275, 486)
        Me.lblError2.Name = "lblError2"
        Me.lblError2.Size = New System.Drawing.Size(185, 22)
        Me.lblError2.TabIndex = 3
        Me.lblError2.Text = "NO FETCH DATA :("
        Me.lblError2.Visible = False
        '
        'lblErrror1
        '
        Me.lblErrror1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblErrror1.AutoSize = True
        Me.lblErrror1.BackColor = System.Drawing.Color.White
        Me.lblErrror1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrror1.ForeColor = System.Drawing.Color.DimGray
        Me.lblErrror1.Location = New System.Drawing.Point(489, 179)
        Me.lblErrror1.Name = "lblErrror1"
        Me.lblErrror1.Size = New System.Drawing.Size(185, 22)
        Me.lblErrror1.TabIndex = 4
        Me.lblErrror1.Text = "NO FETCH DATA :("
        Me.lblErrror1.Visible = False
        '
        'btnsearch
        '
        Me.btnsearch.BackColor = System.Drawing.SystemColors.HotTrack
        Me.btnsearch.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnsearch.FlatAppearance.BorderSize = 0
        Me.btnsearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnsearch.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsearch.ForeColor = System.Drawing.Color.White
        Me.btnsearch.Location = New System.Drawing.Point(230, 103)
        Me.btnsearch.Name = "btnsearch"
        Me.btnsearch.Size = New System.Drawing.Size(75, 25)
        Me.btnsearch.TabIndex = 8
        Me.btnsearch.Text = "Search"
        Me.btnsearch.UseVisualStyleBackColor = False
        '
        'txtboxsearch
        '
        Me.txtboxsearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtboxsearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtboxsearch.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtboxsearch.ForeColor = System.Drawing.Color.Black
        Me.txtboxsearch.Location = New System.Drawing.Point(28, 103)
        Me.txtboxsearch.Name = "txtboxsearch"
        Me.txtboxsearch.ShortcutsEnabled = False
        Me.txtboxsearch.Size = New System.Drawing.Size(203, 25)
        Me.txtboxsearch.TabIndex = 7
        '
        'btnunpaid
        '
        Me.btnunpaid.BackColor = System.Drawing.SystemColors.HotTrack
        Me.btnunpaid.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnunpaid.FlatAppearance.BorderSize = 0
        Me.btnunpaid.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnunpaid.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnunpaid.ForeColor = System.Drawing.Color.Black
        Me.btnunpaid.Location = New System.Drawing.Point(26, 57)
        Me.btnunpaid.Name = "btnunpaid"
        Me.btnunpaid.Size = New System.Drawing.Size(203, 39)
        Me.btnunpaid.TabIndex = 9
        Me.btnunpaid.Text = "UNPAID A.R"
        Me.btnunpaid.UseVisualStyleBackColor = False
        Me.btnunpaid.Visible = False
        '
        'btnpaid
        '
        Me.btnpaid.BackColor = System.Drawing.SystemColors.HotTrack
        Me.btnpaid.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnpaid.FlatAppearance.BorderSize = 0
        Me.btnpaid.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnpaid.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnpaid.ForeColor = System.Drawing.Color.White
        Me.btnpaid.Location = New System.Drawing.Point(235, 57)
        Me.btnpaid.Name = "btnpaid"
        Me.btnpaid.Size = New System.Drawing.Size(203, 39)
        Me.btnpaid.TabIndex = 10
        Me.btnpaid.Text = "PAID A.R"
        Me.btnpaid.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.lblbalanceamount)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtchange)
        Me.GroupBox1.Controls.Add(Me.txttenderamt)
        Me.GroupBox1.Controls.Add(Me.lbltotalamount)
        Me.GroupBox1.Controls.Add(Me.lblvatamount)
        Me.GroupBox1.Controls.Add(Me.lblvatsales)
        Me.GroupBox1.Controls.Add(Me.lblvatexemptsales)
        Me.GroupBox1.Controls.Add(Me.lbldelcharge)
        Me.GroupBox1.Controls.Add(Me.lblless)
        Me.GroupBox1.Controls.Add(Me.lbldisctype)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.btnSubmit)
        Me.GroupBox1.Controls.Add(Me.lblsubtotal)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(772, 425)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(546, 255)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        '
        'lblbalanceamount
        '
        Me.lblbalanceamount.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblbalanceamount.AutoSize = True
        Me.lblbalanceamount.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblbalanceamount.ForeColor = System.Drawing.Color.DarkGreen
        Me.lblbalanceamount.Location = New System.Drawing.Point(428, 118)
        Me.lblbalanceamount.Name = "lblbalanceamount"
        Me.lblbalanceamount.Size = New System.Drawing.Size(53, 18)
        Me.lblbalanceamount.TabIndex = 52
        Me.lblbalanceamount.Text = "00.00"
        '
        'Label16
        '
        Me.Label16.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.DimGray
        Me.Label16.Location = New System.Drawing.Point(247, 92)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(144, 18)
        Me.Label16.TabIndex = 51
        Me.Label16.Text = "TOTAL AMOUNT:"
        '
        'Label10
        '
        Me.Label10.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!)
        Me.Label10.ForeColor = System.Drawing.Color.DimGray
        Me.Label10.Location = New System.Drawing.Point(252, 142)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 14)
        Me.Label10.TabIndex = 50
        Me.Label10.Text = "Change:"
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!)
        Me.Label9.ForeColor = System.Drawing.Color.DimGray
        Me.Label9.Location = New System.Drawing.Point(40, 145)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(101, 14)
        Me.Label9.TabIndex = 49
        Me.Label9.Text = "Tender Amount:"
        '
        'txtchange
        '
        Me.txtchange.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtchange.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtchange.Location = New System.Drawing.Point(255, 159)
        Me.txtchange.Name = "txtchange"
        Me.txtchange.ReadOnly = True
        Me.txtchange.Size = New System.Drawing.Size(181, 26)
        Me.txtchange.TabIndex = 48
        Me.txtchange.Text = "0.00"
        '
        'txttenderamt
        '
        Me.txttenderamt.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txttenderamt.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttenderamt.Location = New System.Drawing.Point(37, 162)
        Me.txttenderamt.Name = "txttenderamt"
        Me.txttenderamt.Size = New System.Drawing.Size(181, 26)
        Me.txttenderamt.TabIndex = 47
        '
        'lbltotalamount
        '
        Me.lbltotalamount.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbltotalamount.AutoSize = True
        Me.lbltotalamount.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotalamount.ForeColor = System.Drawing.Color.DarkGreen
        Me.lbltotalamount.Location = New System.Drawing.Point(428, 92)
        Me.lbltotalamount.Name = "lbltotalamount"
        Me.lbltotalamount.Size = New System.Drawing.Size(53, 18)
        Me.lbltotalamount.TabIndex = 46
        Me.lbltotalamount.Text = "00.00"
        '
        'lblvatamount
        '
        Me.lblvatamount.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblvatamount.AutoSize = True
        Me.lblvatamount.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!)
        Me.lblvatamount.ForeColor = System.Drawing.Color.DarkGreen
        Me.lblvatamount.Location = New System.Drawing.Point(428, 67)
        Me.lblvatamount.Name = "lblvatamount"
        Me.lblvatamount.Size = New System.Drawing.Size(39, 14)
        Me.lblvatamount.TabIndex = 45
        Me.lblvatamount.Text = "00.00"
        '
        'lblvatsales
        '
        Me.lblvatsales.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblvatsales.AutoSize = True
        Me.lblvatsales.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!)
        Me.lblvatsales.ForeColor = System.Drawing.Color.DarkGreen
        Me.lblvatsales.Location = New System.Drawing.Point(428, 42)
        Me.lblvatsales.Name = "lblvatsales"
        Me.lblvatsales.Size = New System.Drawing.Size(39, 14)
        Me.lblvatsales.TabIndex = 44
        Me.lblvatsales.Text = "00.00"
        '
        'lblvatexemptsales
        '
        Me.lblvatexemptsales.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblvatexemptsales.AutoSize = True
        Me.lblvatexemptsales.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!)
        Me.lblvatexemptsales.ForeColor = System.Drawing.Color.DarkGreen
        Me.lblvatexemptsales.Location = New System.Drawing.Point(428, 15)
        Me.lblvatexemptsales.Name = "lblvatexemptsales"
        Me.lblvatexemptsales.Size = New System.Drawing.Size(39, 14)
        Me.lblvatexemptsales.TabIndex = 43
        Me.lblvatexemptsales.Text = "00.00"
        '
        'lbldelcharge
        '
        Me.lbldelcharge.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbldelcharge.AutoSize = True
        Me.lbldelcharge.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!)
        Me.lbldelcharge.ForeColor = System.Drawing.Color.DarkGreen
        Me.lbldelcharge.Location = New System.Drawing.Point(158, 95)
        Me.lbldelcharge.Name = "lbldelcharge"
        Me.lbldelcharge.Size = New System.Drawing.Size(46, 14)
        Me.lbldelcharge.TabIndex = 42
        Me.lbldelcharge.Text = "000.00"
        '
        'lblless
        '
        Me.lblless.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblless.AutoSize = True
        Me.lblless.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!)
        Me.lblless.ForeColor = System.Drawing.Color.DarkGreen
        Me.lblless.Location = New System.Drawing.Point(158, 68)
        Me.lblless.Name = "lblless"
        Me.lblless.Size = New System.Drawing.Size(46, 14)
        Me.lblless.TabIndex = 41
        Me.lblless.Text = "000.00"
        '
        'lbldisctype
        '
        Me.lbldisctype.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbldisctype.AutoSize = True
        Me.lbldisctype.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!)
        Me.lbldisctype.ForeColor = System.Drawing.Color.DarkGreen
        Me.lbldisctype.Location = New System.Drawing.Point(158, 45)
        Me.lbldisctype.Name = "lbldisctype"
        Me.lbldisctype.Size = New System.Drawing.Size(28, 14)
        Me.lbldisctype.TabIndex = 40
        Me.lbldisctype.Text = "N/A"
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DimGray
        Me.Label7.Location = New System.Drawing.Point(247, 118)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(170, 18)
        Me.Label7.TabIndex = 38
        Me.Label7.Text = "BALANCE AMOUNT:"
        '
        'lblsubtotal
        '
        Me.lblsubtotal.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblsubtotal.AutoSize = True
        Me.lblsubtotal.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!)
        Me.lblsubtotal.ForeColor = System.Drawing.Color.DarkGreen
        Me.lblsubtotal.Location = New System.Drawing.Point(158, 21)
        Me.lblsubtotal.Name = "lblsubtotal"
        Me.lblsubtotal.Size = New System.Drawing.Size(46, 14)
        Me.lblsubtotal.TabIndex = 39
        Me.lblsubtotal.Text = "000.00"
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!)
        Me.Label8.ForeColor = System.Drawing.Color.DimGray
        Me.Label8.Location = New System.Drawing.Point(247, 67)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(84, 14)
        Me.Label8.TabIndex = 37
        Me.Label8.Text = "VAT Amount:"
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!)
        Me.Label6.ForeColor = System.Drawing.Color.DimGray
        Me.Label6.Location = New System.Drawing.Point(247, 42)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(90, 14)
        Me.Label6.TabIndex = 36
        Me.Label6.Text = "Vatable Sales:"
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!)
        Me.Label5.ForeColor = System.Drawing.Color.DimGray
        Me.Label5.Location = New System.Drawing.Point(247, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(118, 14)
        Me.Label5.TabIndex = 35
        Me.Label5.Text = "VAT Exempt Sales:"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.DimGray
        Me.Label3.Location = New System.Drawing.Point(6, 95)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(105, 14)
        Me.Label3.TabIndex = 34
        Me.Label3.Text = "Delivery Charge:"
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.DimGray
        Me.Label4.Location = New System.Drawing.Point(6, 68)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 14)
        Me.Label4.TabIndex = 33
        Me.Label4.Text = "Less %:"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.DimGray
        Me.Label2.Location = New System.Drawing.Point(6, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 14)
        Me.Label2.TabIndex = 32
        Me.Label2.Text = "Discount Type:"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.DimGray
        Me.Label1.Location = New System.Drawing.Point(6, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 14)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "Sub Total:"
        '
        'lblProductionClose
        '
        Me.lblProductionClose.AutoSize = True
        Me.lblProductionClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblProductionClose.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProductionClose.ForeColor = System.Drawing.Color.White
        Me.lblProductionClose.Location = New System.Drawing.Point(350, 0)
        Me.lblProductionClose.Name = "lblProductionClose"
        Me.lblProductionClose.Size = New System.Drawing.Size(21, 22)
        Me.lblProductionClose.TabIndex = 6
        Me.lblProductionClose.Text = "X"
        Me.ToolTip1.SetToolTip(Me.lblProductionClose, "Close")
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.Goldenrod
        Me.Panel1.Controls.Add(Me.lblRemarks)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.lblSAPNo)
        Me.Panel1.Controls.Add(Me.lbltype)
        Me.Panel1.Location = New System.Drawing.Point(931, 45)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(386, 83)
        Me.Panel1.TabIndex = 39
        Me.Panel1.Visible = False
        '
        'lblRemarks
        '
        Me.lblRemarks.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRemarks.AutoSize = True
        Me.lblRemarks.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRemarks.ForeColor = System.Drawing.Color.White
        Me.lblRemarks.Location = New System.Drawing.Point(121, 48)
        Me.lblRemarks.Name = "lblRemarks"
        Me.lblRemarks.Size = New System.Drawing.Size(30, 15)
        Me.lblRemarks.TabIndex = 23
        Me.lblRemarks.Text = "N/A"
        '
        'Label14
        '
        Me.Label14.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(17, 42)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(98, 22)
        Me.Label14.TabIndex = 22
        Me.Label14.Text = "Remarks:"
        '
        'lblSAPNo
        '
        Me.lblSAPNo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSAPNo.AutoSize = True
        Me.lblSAPNo.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSAPNo.ForeColor = System.Drawing.Color.Green
        Me.lblSAPNo.Location = New System.Drawing.Point(121, 12)
        Me.lblSAPNo.Name = "lblSAPNo"
        Me.lblSAPNo.Size = New System.Drawing.Size(30, 15)
        Me.lblSAPNo.TabIndex = 21
        Me.lblSAPNo.Text = "N/A"
        '
        'lbltype
        '
        Me.lbltype.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbltype.AutoSize = True
        Me.lbltype.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltype.ForeColor = System.Drawing.Color.White
        Me.lbltype.Location = New System.Drawing.Point(17, 6)
        Me.lbltype.Name = "lbltype"
        Me.lbltype.Size = New System.Drawing.Size(26, 22)
        Me.lbltype.TabIndex = 20
        Me.lbltype.Text = "#:"
        '
        'datesearch
        '
        Me.datesearch.CustomFormat = "MM/dd/yyyy"
        Me.datesearch.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.datesearch.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.datesearch.Location = New System.Drawing.Point(352, 103)
        Me.datesearch.Name = "datesearch"
        Me.datesearch.Size = New System.Drawing.Size(163, 26)
        Me.datesearch.TabIndex = 40
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.Location = New System.Drawing.Point(650, 98)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 41
        Me.TextBox1.Visible = False
        '
        'btnProceed
        '
        Me.btnProceed.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnProceed.BackColor = System.Drawing.Color.ForestGreen
        Me.btnProceed.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnProceed.FlatAppearance.BorderSize = 0
        Me.btnProceed.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProceed.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProceed.ForeColor = System.Drawing.Color.White
        Me.btnProceed.Location = New System.Drawing.Point(201, 210)
        Me.btnProceed.Name = "btnProceed"
        Me.btnProceed.Size = New System.Drawing.Size(129, 31)
        Me.btnProceed.TabIndex = 0
        Me.btnProceed.Text = "Proceed"
        Me.btnProceed.UseVisualStyleBackColor = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(38, 83)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(79, 18)
        Me.Label13.TabIndex = 1
        Me.Label13.Text = "Remarks"
        '
        'txtboxRemarks
        '
        Me.txtboxRemarks.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtboxRemarks.Location = New System.Drawing.Point(41, 108)
        Me.txtboxRemarks.Multiline = True
        Me.txtboxRemarks.Name = "txtboxRemarks"
        Me.txtboxRemarks.ShortcutsEnabled = False
        Me.txtboxRemarks.Size = New System.Drawing.Size(289, 90)
        Me.txtboxRemarks.TabIndex = 2
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(38, 24)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(133, 18)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "Please select #:"
        '
        'txtboxSAPNo
        '
        Me.txtboxSAPNo.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtboxSAPNo.Location = New System.Drawing.Point(132, 47)
        Me.txtboxSAPNo.Multiline = True
        Me.txtboxSAPNo.Name = "txtboxSAPNo"
        Me.txtboxSAPNo.ShortcutsEnabled = False
        Me.txtboxSAPNo.Size = New System.Drawing.Size(107, 26)
        Me.txtboxSAPNo.TabIndex = 5
        '
        'cmbtype
        '
        Me.cmbtype.BackColor = System.Drawing.SystemColors.HotTrack
        Me.cmbtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbtype.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbtype.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbtype.ForeColor = System.Drawing.Color.White
        Me.cmbtype.FormattingEnabled = True
        Me.cmbtype.Items.AddRange(New Object() {"---", "AR"})
        Me.cmbtype.Location = New System.Drawing.Point(41, 47)
        Me.cmbtype.Name = "cmbtype"
        Me.cmbtype.Size = New System.Drawing.Size(85, 26)
        Me.cmbtype.Sorted = True
        Me.cmbtype.TabIndex = 10
        '
        'checkfollowup
        '
        Me.checkfollowup.AutoSize = True
        Me.checkfollowup.Checked = True
        Me.checkfollowup.CheckState = System.Windows.Forms.CheckState.Checked
        Me.checkfollowup.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkfollowup.ForeColor = System.Drawing.Color.White
        Me.checkfollowup.Location = New System.Drawing.Point(245, 51)
        Me.checkfollowup.Name = "checkfollowup"
        Me.checkfollowup.Size = New System.Drawing.Size(86, 20)
        Me.checkfollowup.TabIndex = 17
        Me.checkfollowup.Text = "To Follow"
        Me.checkfollowup.UseVisualStyleBackColor = True
        '
        'PanelSAP
        '
        Me.PanelSAP.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PanelSAP.BackColor = System.Drawing.SystemColors.HotTrack
        Me.PanelSAP.Controls.Add(Me.checkfollowup)
        Me.PanelSAP.Controls.Add(Me.cmbtype)
        Me.PanelSAP.Controls.Add(Me.lblProductionClose)
        Me.PanelSAP.Controls.Add(Me.txtboxSAPNo)
        Me.PanelSAP.Controls.Add(Me.Label11)
        Me.PanelSAP.Controls.Add(Me.txtboxRemarks)
        Me.PanelSAP.Controls.Add(Me.Label13)
        Me.PanelSAP.Controls.Add(Me.btnProceed)
        Me.PanelSAP.Location = New System.Drawing.Point(527, 153)
        Me.PanelSAP.Name = "PanelSAP"
        Me.PanelSAP.Size = New System.Drawing.Size(371, 268)
        Me.PanelSAP.TabIndex = 38
        Me.PanelSAP.Visible = False
        '
        'btneditar
        '
        Me.btneditar.BackColor = System.Drawing.SystemColors.HotTrack
        Me.btneditar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btneditar.FlatAppearance.BorderSize = 0
        Me.btneditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btneditar.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btneditar.ForeColor = System.Drawing.Color.White
        Me.btneditar.Location = New System.Drawing.Point(444, 57)
        Me.btneditar.Name = "btneditar"
        Me.btneditar.Size = New System.Drawing.Size(203, 39)
        Me.btneditar.TabIndex = 42
        Me.btneditar.Text = "EDIT A.R #"
        Me.btneditar.UseVisualStyleBackColor = False
        '
        'panelRemarks
        '
        Me.panelRemarks.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.panelRemarks.BackColor = System.Drawing.Color.DodgerBlue
        Me.panelRemarks.Controls.Add(Me.lblhide)
        Me.panelRemarks.Controls.Add(Me.btnproceed1)
        Me.panelRemarks.Controls.Add(Me.txtremarks)
        Me.panelRemarks.Controls.Add(Me.Label12)
        Me.panelRemarks.Location = New System.Drawing.Point(459, 124)
        Me.panelRemarks.Name = "panelRemarks"
        Me.panelRemarks.Size = New System.Drawing.Size(368, 233)
        Me.panelRemarks.TabIndex = 43
        Me.panelRemarks.Visible = False
        '
        'lblhide
        '
        Me.lblhide.AutoSize = True
        Me.lblhide.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblhide.Font = New System.Drawing.Font("Arial Rounded MT Bold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblhide.ForeColor = System.Drawing.Color.White
        Me.lblhide.Location = New System.Drawing.Point(345, 0)
        Me.lblhide.Name = "lblhide"
        Me.lblhide.Size = New System.Drawing.Size(23, 24)
        Me.lblhide.TabIndex = 3
        Me.lblhide.Text = "X"
        '
        'btnproceed1
        '
        Me.btnproceed1.BackColor = System.Drawing.Color.ForestGreen
        Me.btnproceed1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnproceed1.FlatAppearance.BorderSize = 0
        Me.btnproceed1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnproceed1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnproceed1.ForeColor = System.Drawing.Color.White
        Me.btnproceed1.Location = New System.Drawing.Point(247, 175)
        Me.btnproceed1.Name = "btnproceed1"
        Me.btnproceed1.Size = New System.Drawing.Size(98, 36)
        Me.btnproceed1.TabIndex = 2
        Me.btnproceed1.Text = "Proceed"
        Me.btnproceed1.UseVisualStyleBackColor = False
        '
        'txtremarks
        '
        Me.txtremarks.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtremarks.Location = New System.Drawing.Point(26, 55)
        Me.txtremarks.Multiline = True
        Me.txtremarks.Name = "txtremarks"
        Me.txtremarks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtremarks.Size = New System.Drawing.Size(319, 114)
        Me.txtremarks.TabIndex = 1
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(23, 34)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(84, 18)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Remarks:"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.Panel2.Controls.Add(Me.lblheader)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1344, 28)
        Me.Panel2.TabIndex = 44
        '
        'lblheader
        '
        Me.lblheader.AutoSize = True
        Me.lblheader.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblheader.ForeColor = System.Drawing.Color.White
        Me.lblheader.Location = New System.Drawing.Point(2, 3)
        Me.lblheader.Name = "lblheader"
        Me.lblheader.Size = New System.Drawing.Size(38, 22)
        Me.lblheader.TabIndex = 0
        Me.lblheader.Text = "AR"
        '
        'paneldate
        '
        Me.paneldate.BackColor = System.Drawing.SystemColors.HotTrack
        Me.paneldate.Controls.Add(Me.lblclose3)
        Me.paneldate.Controls.Add(Me.Label15)
        Me.paneldate.Controls.Add(Me.btnok)
        Me.paneldate.Controls.Add(Me.dtdate)
        Me.paneldate.Location = New System.Drawing.Point(509, 87)
        Me.paneldate.Name = "paneldate"
        Me.paneldate.Size = New System.Drawing.Size(257, 181)
        Me.paneldate.TabIndex = 45
        Me.paneldate.Visible = False
        '
        'lblclose3
        '
        Me.lblclose3.AutoSize = True
        Me.lblclose3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblclose3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblclose3.ForeColor = System.Drawing.Color.White
        Me.lblclose3.Location = New System.Drawing.Point(231, 0)
        Me.lblclose3.Name = "lblclose3"
        Me.lblclose3.Size = New System.Drawing.Size(23, 24)
        Me.lblclose3.TabIndex = 4
        Me.lblclose3.Text = "X"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(63, 39)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(47, 17)
        Me.Label15.TabIndex = 2
        Me.Label15.Text = "Date:"
        '
        'btnok
        '
        Me.btnok.BackColor = System.Drawing.Color.ForestGreen
        Me.btnok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnok.FlatAppearance.BorderSize = 0
        Me.btnok.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnok.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnok.ForeColor = System.Drawing.Color.White
        Me.btnok.Location = New System.Drawing.Point(66, 101)
        Me.btnok.Name = "btnok"
        Me.btnok.Size = New System.Drawing.Size(138, 36)
        Me.btnok.TabIndex = 1
        Me.btnok.Text = "OK"
        Me.btnok.UseVisualStyleBackColor = False
        '
        'dtdate
        '
        Me.dtdate.CustomFormat = "MM/dd/yyyy"
        Me.dtdate.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtdate.Location = New System.Drawing.Point(68, 59)
        Me.dtdate.Name = "dtdate"
        Me.dtdate.Size = New System.Drawing.Size(136, 26)
        Me.dtdate.TabIndex = 0
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(786, 44)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(100, 20)
        Me.TextBox2.TabIndex = 46
        Me.TextBox2.Visible = False
        '
        'ars
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1344, 701)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.paneldate)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.panelRemarks)
        Me.Controls.Add(Me.PanelSAP)
        Me.Controls.Add(Me.btneditar)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.datesearch)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnpaid)
        Me.Controls.Add(Me.lblError2)
        Me.Controls.Add(Me.btnunpaid)
        Me.Controls.Add(Me.btnsearch)
        Me.Controls.Add(Me.txtboxsearch)
        Me.Controls.Add(Me.lblErrror1)
        Me.Controls.Add(Me.dgvArs2)
        Me.Controls.Add(Me.dgvARS)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ars"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "A.R Sales"
        CType(Me.dgvARS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvArs2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.PanelSAP.ResumeLayout(False)
        Me.PanelSAP.PerformLayout()
        Me.panelRemarks.ResumeLayout(False)
        Me.panelRemarks.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.paneldate.ResumeLayout(False)
        Me.paneldate.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvARS As System.Windows.Forms.DataGridView
    Friend WithEvents dgvArs2 As System.Windows.Forms.DataGridView
    Friend WithEvents btnSubmit As System.Windows.Forms.Button
    Friend WithEvents lblError2 As System.Windows.Forms.Label
    Friend WithEvents lblErrror1 As System.Windows.Forms.Label
    Friend WithEvents btnsearch As System.Windows.Forms.Button
    Friend WithEvents txtboxsearch As System.Windows.Forms.TextBox
    Friend WithEvents btnunpaid As System.Windows.Forms.Button
    Friend WithEvents btnpaid As System.Windows.Forms.Button
    Friend WithEvents description As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents quantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents price As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents amount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtchange As System.Windows.Forms.TextBox
    Friend WithEvents txttenderamt As System.Windows.Forms.TextBox
    Friend WithEvents lbltotalamount As System.Windows.Forms.Label
    Friend WithEvents lblvatamount As System.Windows.Forms.Label
    Friend WithEvents lblvatsales As System.Windows.Forms.Label
    Friend WithEvents lblvatexemptsales As System.Windows.Forms.Label
    Friend WithEvents lbldelcharge As System.Windows.Forms.Label
    Friend WithEvents lblless As System.Windows.Forms.Label
    Friend WithEvents lbldisctype As System.Windows.Forms.Label
    Friend WithEvents lblsubtotal As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblRemarks As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lblSAPNo As System.Windows.Forms.Label
    Friend WithEvents lbltype As System.Windows.Forms.Label
    Friend WithEvents lblbalanceamount As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents datesearch As DateTimePicker
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents btnProceed As Button
    Friend WithEvents Label13 As Label
    Friend WithEvents txtboxRemarks As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txtboxSAPNo As TextBox
    Friend WithEvents lblProductionClose As Label
    Friend WithEvents cmbtype As ComboBox
    Friend WithEvents checkfollowup As CheckBox
    Friend WithEvents PanelSAP As Panel
    Friend WithEvents btneditar As Button
    Friend WithEvents panelRemarks As Panel
    Friend WithEvents lblhide As Label
    Friend WithEvents btnproceed1 As Button
    Friend WithEvents txtremarks As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents action As DataGridViewCheckBoxColumn
    Friend WithEvents arnum As DataGridViewTextBoxColumn
    Friend WithEvents transnum As DataGridViewTextBoxColumn
    Friend WithEvents amtdue As DataGridViewTextBoxColumn
    Friend WithEvents namee As DataGridViewTextBoxColumn
    Friend WithEvents datee As DataGridViewTextBoxColumn
    Friend WithEvents btnedit As DataGridViewButtonColumn
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lblheader As Label
    Friend WithEvents paneldate As Panel
    Friend WithEvents Label15 As Label
    Friend WithEvents btnok As Button
    Friend WithEvents dtdate As DateTimePicker
    Friend WithEvents lblclose3 As Label
    Friend WithEvents TextBox2 As TextBox
End Class
