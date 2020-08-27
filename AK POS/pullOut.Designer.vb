<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class pullOut
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(pullOut))
        Me.dgvList = New System.Windows.Forms.DataGridView()
        Me.itemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnAddQuantity = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtList = New System.Windows.Forms.TextBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dgvSelected = New System.Windows.Forms.DataGridView()
        Me.itemNamee = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.quantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnEditQuantity = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.btnRemoveQuantity = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.btnSelected = New System.Windows.Forms.Button()
        Me.txtSelected = New System.Windows.Forms.TextBox()
        Me.btnProceed = New System.Windows.Forms.Button()
        Me.spinner = New System.Windows.Forms.PictureBox()
        Me.panelSAP = New System.Windows.Forms.Panel()
        Me.cmbStatus = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbranches = New System.Windows.Forms.ComboBox()
        Me.lblsapdoc = New System.Windows.Forms.Label()
        Me.lblSAPClose = New System.Windows.Forms.Label()
        Me.txtsap = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtremarks = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblheader = New System.Windows.Forms.Label()
        CType(Me.dgvList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgvSelected, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.spinner, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelSAP.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvList
        '
        Me.dgvList.AllowUserToAddRows = False
        Me.dgvList.AllowUserToDeleteRows = False
        Me.dgvList.AllowUserToResizeColumns = False
        Me.dgvList.AllowUserToResizeRows = False
        Me.dgvList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvList.BackgroundColor = System.Drawing.Color.White
        Me.dgvList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvList.ColumnHeadersHeight = 30
        Me.dgvList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.itemName, Me.btnAddQuantity})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvList.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvList.EnableHeadersVisualStyles = False
        Me.dgvList.Location = New System.Drawing.Point(28, 124)
        Me.dgvList.Name = "dgvList"
        Me.dgvList.RowHeadersVisible = False
        Me.dgvList.Size = New System.Drawing.Size(901, 132)
        Me.dgvList.TabIndex = 1
        '
        'itemName
        '
        Me.itemName.HeaderText = "Item Name"
        Me.itemName.Name = "itemName"
        Me.itemName.ReadOnly = True
        '
        'btnAddQuantity
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.ForestGreen
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        Me.btnAddQuantity.DefaultCellStyle = DataGridViewCellStyle2
        Me.btnAddQuantity.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddQuantity.HeaderText = "Action"
        Me.btnAddQuantity.Name = "btnAddQuantity"
        Me.btnAddQuantity.ReadOnly = True
        Me.btnAddQuantity.Text = "Add Quantity"
        Me.btnAddQuantity.UseColumnTextForButtonValue = True
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(28, 102)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(901, 23)
        Me.Panel1.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "LIST OF ITEMS"
        '
        'txtList
        '
        Me.txtList.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtList.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtList.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtList.Location = New System.Drawing.Point(28, 74)
        Me.txtList.Name = "txtList"
        Me.txtList.Size = New System.Drawing.Size(171, 25)
        Me.txtList.TabIndex = 3
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.SystemColors.HotTrack
        Me.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSearch.FlatAppearance.BorderSize = 0
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.ForeColor = System.Drawing.Color.White
        Me.btnSearch.Location = New System.Drawing.Point(199, 74)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 25)
        Me.btnSearch.TabIndex = 4
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Location = New System.Drawing.Point(28, 306)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(901, 23)
        Me.Panel2.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(3, 4)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(119, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "SELECTED ITEMS"
        '
        'dgvSelected
        '
        Me.dgvSelected.AllowUserToAddRows = False
        Me.dgvSelected.AllowUserToDeleteRows = False
        Me.dgvSelected.AllowUserToResizeColumns = False
        Me.dgvSelected.AllowUserToResizeRows = False
        Me.dgvSelected.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvSelected.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvSelected.BackgroundColor = System.Drawing.Color.White
        Me.dgvSelected.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvSelected.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvSelected.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSelected.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvSelected.ColumnHeadersHeight = 30
        Me.dgvSelected.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.itemNamee, Me.quantity, Me.btnEditQuantity, Me.btnRemoveQuantity})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvSelected.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgvSelected.EnableHeadersVisualStyles = False
        Me.dgvSelected.Location = New System.Drawing.Point(28, 328)
        Me.dgvSelected.Name = "dgvSelected"
        Me.dgvSelected.RowHeadersVisible = False
        Me.dgvSelected.Size = New System.Drawing.Size(901, 162)
        Me.dgvSelected.TabIndex = 3
        '
        'itemNamee
        '
        Me.itemNamee.HeaderText = "Item Name"
        Me.itemNamee.Name = "itemNamee"
        Me.itemNamee.ReadOnly = True
        '
        'quantity
        '
        Me.quantity.HeaderText = "Quantity"
        Me.quantity.Name = "quantity"
        Me.quantity.ReadOnly = True
        '
        'btnEditQuantity
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.White
        Me.btnEditQuantity.DefaultCellStyle = DataGridViewCellStyle5
        Me.btnEditQuantity.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEditQuantity.HeaderText = "Action"
        Me.btnEditQuantity.Name = "btnEditQuantity"
        Me.btnEditQuantity.ReadOnly = True
        Me.btnEditQuantity.Text = "Edit Quantity"
        Me.btnEditQuantity.UseColumnTextForButtonValue = True
        '
        'btnRemoveQuantity
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.Firebrick
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.White
        Me.btnRemoveQuantity.DefaultCellStyle = DataGridViewCellStyle6
        Me.btnRemoveQuantity.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRemoveQuantity.HeaderText = "Action"
        Me.btnRemoveQuantity.Name = "btnRemoveQuantity"
        Me.btnRemoveQuantity.ReadOnly = True
        Me.btnRemoveQuantity.Text = "Remove Quantity"
        Me.btnRemoveQuantity.UseColumnTextForButtonValue = True
        '
        'btnSelected
        '
        Me.btnSelected.BackColor = System.Drawing.SystemColors.HotTrack
        Me.btnSelected.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSelected.FlatAppearance.BorderSize = 0
        Me.btnSelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSelected.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSelected.ForeColor = System.Drawing.Color.White
        Me.btnSelected.Location = New System.Drawing.Point(199, 278)
        Me.btnSelected.Name = "btnSelected"
        Me.btnSelected.Size = New System.Drawing.Size(75, 25)
        Me.btnSelected.TabIndex = 6
        Me.btnSelected.Text = "Search"
        Me.btnSelected.UseVisualStyleBackColor = False
        '
        'txtSelected
        '
        Me.txtSelected.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtSelected.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtSelected.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSelected.Location = New System.Drawing.Point(28, 278)
        Me.txtSelected.Name = "txtSelected"
        Me.txtSelected.Size = New System.Drawing.Size(171, 25)
        Me.txtSelected.TabIndex = 5
        '
        'btnProceed
        '
        Me.btnProceed.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnProceed.BackColor = System.Drawing.SystemColors.HotTrack
        Me.btnProceed.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnProceed.FlatAppearance.BorderSize = 0
        Me.btnProceed.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProceed.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProceed.ForeColor = System.Drawing.Color.White
        Me.btnProceed.Location = New System.Drawing.Point(778, 515)
        Me.btnProceed.Name = "btnProceed"
        Me.btnProceed.Size = New System.Drawing.Size(151, 43)
        Me.btnProceed.TabIndex = 7
        Me.btnProceed.Text = "PROCEED"
        Me.btnProceed.UseVisualStyleBackColor = False
        '
        'spinner
        '
        Me.spinner.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.spinner.Image = CType(resources.GetObject("spinner.Image"), System.Drawing.Image)
        Me.spinner.Location = New System.Drawing.Point(367, 496)
        Me.spinner.Name = "spinner"
        Me.spinner.Size = New System.Drawing.Size(182, 71)
        Me.spinner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.spinner.TabIndex = 8
        Me.spinner.TabStop = False
        Me.spinner.Visible = False
        '
        'panelSAP
        '
        Me.panelSAP.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.panelSAP.BackColor = System.Drawing.SystemColors.HotTrack
        Me.panelSAP.Controls.Add(Me.cmbStatus)
        Me.panelSAP.Controls.Add(Me.Label3)
        Me.panelSAP.Controls.Add(Me.cmbranches)
        Me.panelSAP.Controls.Add(Me.lblsapdoc)
        Me.panelSAP.Controls.Add(Me.lblSAPClose)
        Me.panelSAP.Controls.Add(Me.txtsap)
        Me.panelSAP.Controls.Add(Me.Label4)
        Me.panelSAP.Controls.Add(Me.txtremarks)
        Me.panelSAP.Controls.Add(Me.Label11)
        Me.panelSAP.Controls.Add(Me.btnSubmit)
        Me.panelSAP.Location = New System.Drawing.Point(294, 166)
        Me.panelSAP.Name = "panelSAP"
        Me.panelSAP.Size = New System.Drawing.Size(371, 306)
        Me.panelSAP.TabIndex = 57
        Me.panelSAP.Visible = False
        '
        'cmbStatus
        '
        Me.cmbStatus.BackColor = System.Drawing.Color.DodgerBlue
        Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbStatus.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbStatus.ForeColor = System.Drawing.Color.White
        Me.cmbStatus.FormattingEnabled = True
        Me.cmbStatus.Items.AddRange(New Object() {"Pending", "Approved", "Disapproved"})
        Me.cmbStatus.Location = New System.Drawing.Point(39, 114)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Size = New System.Drawing.Size(95, 23)
        Me.cmbStatus.TabIndex = 21
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(36, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 18)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Branch:"
        '
        'cmbranches
        '
        Me.cmbranches.BackColor = System.Drawing.Color.DodgerBlue
        Me.cmbranches.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbranches.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbranches.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbranches.ForeColor = System.Drawing.Color.White
        Me.cmbranches.FormattingEnabled = True
        Me.cmbranches.Location = New System.Drawing.Point(39, 55)
        Me.cmbranches.Name = "cmbranches"
        Me.cmbranches.Size = New System.Drawing.Size(289, 23)
        Me.cmbranches.TabIndex = 19
        '
        'lblsapdoc
        '
        Me.lblsapdoc.AutoSize = True
        Me.lblsapdoc.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsapdoc.ForeColor = System.Drawing.Color.White
        Me.lblsapdoc.Location = New System.Drawing.Point(175, 89)
        Me.lblsapdoc.Name = "lblsapdoc"
        Me.lblsapdoc.Size = New System.Drawing.Size(35, 18)
        Me.lblsapdoc.TabIndex = 17
        Me.lblsapdoc.Text = "ITR"
        '
        'lblSAPClose
        '
        Me.lblSAPClose.AutoSize = True
        Me.lblSAPClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblSAPClose.Font = New System.Drawing.Font("Arial Rounded MT Bold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSAPClose.ForeColor = System.Drawing.Color.White
        Me.lblSAPClose.Location = New System.Drawing.Point(345, 1)
        Me.lblSAPClose.Name = "lblSAPClose"
        Me.lblSAPClose.Size = New System.Drawing.Size(23, 24)
        Me.lblSAPClose.TabIndex = 6
        Me.lblSAPClose.Text = "X"
        '
        'txtsap
        '
        Me.txtsap.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsap.Location = New System.Drawing.Point(140, 112)
        Me.txtsap.MaxLength = 6
        Me.txtsap.Name = "txtsap"
        Me.txtsap.ShortcutsEnabled = False
        Me.txtsap.Size = New System.Drawing.Size(188, 29)
        Me.txtsap.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(36, 89)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(133, 18)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "SAP Document:"
        '
        'txtremarks
        '
        Me.txtremarks.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtremarks.Location = New System.Drawing.Point(39, 179)
        Me.txtremarks.Multiline = True
        Me.txtremarks.Name = "txtremarks"
        Me.txtremarks.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtremarks.ShortcutsEnabled = False
        Me.txtremarks.Size = New System.Drawing.Size(289, 77)
        Me.txtremarks.TabIndex = 2
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(36, 157)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(79, 18)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "Remarks"
        '
        'btnSubmit
        '
        Me.btnSubmit.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnSubmit.BackColor = System.Drawing.Color.ForestGreen
        Me.btnSubmit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSubmit.FlatAppearance.BorderSize = 0
        Me.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSubmit.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSubmit.ForeColor = System.Drawing.Color.White
        Me.btnSubmit.Location = New System.Drawing.Point(199, 262)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(129, 31)
        Me.btnSubmit.TabIndex = 0
        Me.btnSubmit.Text = "SUBMIT"
        Me.btnSubmit.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.Panel3.Controls.Add(Me.lblheader)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(958, 31)
        Me.Panel3.TabIndex = 58
        '
        'lblheader
        '
        Me.lblheader.AutoSize = True
        Me.lblheader.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblheader.ForeColor = System.Drawing.Color.White
        Me.lblheader.Location = New System.Drawing.Point(2, 5)
        Me.lblheader.Name = "lblheader"
        Me.lblheader.Size = New System.Drawing.Size(105, 22)
        Me.lblheader.TabIndex = 33
        Me.lblheader.Text = "PULL OUT"
        '
        'pullOut
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(958, 599)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.panelSAP)
        Me.Controls.Add(Me.spinner)
        Me.Controls.Add(Me.btnProceed)
        Me.Controls.Add(Me.btnSelected)
        Me.Controls.Add(Me.txtSelected)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.dgvSelected)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.txtList)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.dgvList)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "pullOut"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgvList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.dgvSelected, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.spinner, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelSAP.ResumeLayout(False)
        Me.panelSAP.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvList As DataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents txtList As TextBox
    Friend WithEvents btnSearch As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents dgvSelected As DataGridView
    Friend WithEvents btnSelected As Button
    Friend WithEvents txtSelected As TextBox
    Friend WithEvents btnProceed As Button
    Friend WithEvents itemName As DataGridViewTextBoxColumn
    Friend WithEvents btnAddQuantity As DataGridViewButtonColumn
    Friend WithEvents spinner As PictureBox
    Friend WithEvents itemNamee As DataGridViewTextBoxColumn
    Friend WithEvents quantity As DataGridViewTextBoxColumn
    Friend WithEvents btnEditQuantity As DataGridViewButtonColumn
    Friend WithEvents btnRemoveQuantity As DataGridViewButtonColumn
    Friend WithEvents panelSAP As Panel
    Friend WithEvents lblsapdoc As Label
    Friend WithEvents lblSAPClose As Label
    Friend WithEvents txtsap As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtremarks As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents btnSubmit As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbranches As ComboBox
    Friend WithEvents Panel3 As Panel
    Public WithEvents lblheader As Label
    Friend WithEvents cmbStatus As ComboBox
End Class
