<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class inv_logs
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnReceivedItem = New System.Windows.Forms.Button()
        Me.btnTransfer = New System.Windows.Forms.Button()
        Me.btnPullOut = New System.Windows.Forms.Button()
        Me.btnActualEndingBalance = New System.Windows.Forms.Button()
        Me.dgvData = New System.Windows.Forms.DataGridView()
        Me.transnum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.invnum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.itemcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.itemname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.category = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.quantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.reject = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.charge = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.transferfrom = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.transferto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.processed_by = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.datee = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.area = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.printreceipt = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.txtboxSearch = New System.Windows.Forms.TextBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.cmbCategory = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.dtFrom = New System.Windows.Forms.DateTimePicker()
        Me.dtTo = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnSearchDate = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lbltransnum = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblRemarks = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblSAPNo = New System.Windows.Forms.Label()
        Me.lbltype = New System.Windows.Forms.Label()
        Me.lblError = New System.Windows.Forms.Label()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbreceived = New System.Windows.Forms.ComboBox()
        Me.btnobb = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lbltotal = New System.Windows.Forms.Label()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnReceivedItem
        '
        Me.btnReceivedItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnReceivedItem.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnReceivedItem.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnReceivedItem.FlatAppearance.BorderSize = 0
        Me.btnReceivedItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReceivedItem.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReceivedItem.ForeColor = System.Drawing.Color.White
        Me.btnReceivedItem.Location = New System.Drawing.Point(20, 123)
        Me.btnReceivedItem.Name = "btnReceivedItem"
        Me.btnReceivedItem.Size = New System.Drawing.Size(147, 42)
        Me.btnReceivedItem.TabIndex = 0
        Me.btnReceivedItem.Text = "Received Item"
        Me.btnReceivedItem.UseVisualStyleBackColor = False
        '
        'btnTransfer
        '
        Me.btnTransfer.BackColor = System.Drawing.SystemColors.HotTrack
        Me.btnTransfer.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTransfer.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue
        Me.btnTransfer.FlatAppearance.BorderSize = 0
        Me.btnTransfer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTransfer.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTransfer.ForeColor = System.Drawing.Color.White
        Me.btnTransfer.Location = New System.Drawing.Point(168, 123)
        Me.btnTransfer.Name = "btnTransfer"
        Me.btnTransfer.Size = New System.Drawing.Size(147, 42)
        Me.btnTransfer.TabIndex = 1
        Me.btnTransfer.Text = "Transfer"
        Me.btnTransfer.UseVisualStyleBackColor = False
        '
        'btnPullOut
        '
        Me.btnPullOut.BackColor = System.Drawing.Color.Firebrick
        Me.btnPullOut.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPullOut.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed
        Me.btnPullOut.FlatAppearance.BorderSize = 0
        Me.btnPullOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPullOut.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPullOut.ForeColor = System.Drawing.Color.White
        Me.btnPullOut.Location = New System.Drawing.Point(230, 166)
        Me.btnPullOut.Name = "btnPullOut"
        Me.btnPullOut.Size = New System.Drawing.Size(193, 42)
        Me.btnPullOut.TabIndex = 2
        Me.btnPullOut.Text = "Adjustment Out Item"
        Me.btnPullOut.UseVisualStyleBackColor = False
        '
        'btnActualEndingBalance
        '
        Me.btnActualEndingBalance.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnActualEndingBalance.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnActualEndingBalance.FlatAppearance.BorderColor = System.Drawing.Color.Purple
        Me.btnActualEndingBalance.FlatAppearance.BorderSize = 0
        Me.btnActualEndingBalance.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnActualEndingBalance.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnActualEndingBalance.ForeColor = System.Drawing.Color.White
        Me.btnActualEndingBalance.Location = New System.Drawing.Point(316, 123)
        Me.btnActualEndingBalance.Name = "btnActualEndingBalance"
        Me.btnActualEndingBalance.Size = New System.Drawing.Size(209, 42)
        Me.btnActualEndingBalance.TabIndex = 3
        Me.btnActualEndingBalance.Text = "Actual Ending Balance"
        Me.btnActualEndingBalance.UseVisualStyleBackColor = False
        '
        'dgvData
        '
        Me.dgvData.AllowUserToAddRows = False
        Me.dgvData.AllowUserToDeleteRows = False
        Me.dgvData.AllowUserToResizeColumns = False
        Me.dgvData.AllowUserToResizeRows = False
        Me.dgvData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvData.BackgroundColor = System.Drawing.Color.White
        Me.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvData.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvData.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvData.ColumnHeadersHeight = 50
        Me.dgvData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.transnum, Me.invnum, Me.itemcode, Me.itemname, Me.category, Me.quantity, Me.reject, Me.charge, Me.transferfrom, Me.transferto, Me.processed_by, Me.datee, Me.type, Me.area, Me.printreceipt})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvData.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvData.EnableHeadersVisualStyles = False
        Me.dgvData.Location = New System.Drawing.Point(19, 348)
        Me.dgvData.Name = "dgvData"
        Me.dgvData.ReadOnly = True
        Me.dgvData.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvData.RowHeadersVisible = False
        Me.dgvData.RowHeadersWidth = 50
        Me.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvData.Size = New System.Drawing.Size(1296, 262)
        Me.dgvData.TabIndex = 4
        '
        'transnum
        '
        Me.transnum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.transnum.DefaultCellStyle = DataGridViewCellStyle2
        Me.transnum.HeaderText = "Trans. #"
        Me.transnum.MinimumWidth = 100
        Me.transnum.Name = "transnum"
        Me.transnum.ReadOnly = True
        Me.transnum.Width = 170
        '
        'invnum
        '
        Me.invnum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!)
        Me.invnum.DefaultCellStyle = DataGridViewCellStyle3
        Me.invnum.FillWeight = 576.0!
        Me.invnum.HeaderText = "Inv. #"
        Me.invnum.MinimumWidth = 100
        Me.invnum.Name = "invnum"
        Me.invnum.ReadOnly = True
        Me.invnum.Visible = False
        Me.invnum.Width = 170
        '
        'itemcode
        '
        Me.itemcode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.itemcode.FillWeight = 32.0!
        Me.itemcode.HeaderText = "Item Code"
        Me.itemcode.MinimumWidth = 100
        Me.itemcode.Name = "itemcode"
        Me.itemcode.ReadOnly = True
        Me.itemcode.Width = 200
        '
        'itemname
        '
        Me.itemname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.itemname.FillWeight = 32.0!
        Me.itemname.HeaderText = "Item Name"
        Me.itemname.MinimumWidth = 100
        Me.itemname.Name = "itemname"
        Me.itemname.ReadOnly = True
        Me.itemname.Width = 300
        '
        'category
        '
        Me.category.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.category.FillWeight = 32.0!
        Me.category.HeaderText = "Category"
        Me.category.MinimumWidth = 100
        Me.category.Name = "category"
        Me.category.ReadOnly = True
        Me.category.Width = 250
        '
        'quantity
        '
        Me.quantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.quantity.FillWeight = 32.0!
        Me.quantity.HeaderText = "Good"
        Me.quantity.MinimumWidth = 100
        Me.quantity.Name = "quantity"
        Me.quantity.ReadOnly = True
        Me.quantity.Width = 150
        '
        'reject
        '
        Me.reject.HeaderText = "Reject"
        Me.reject.MinimumWidth = 100
        Me.reject.Name = "reject"
        Me.reject.ReadOnly = True
        '
        'charge
        '
        Me.charge.HeaderText = "Charge"
        Me.charge.MinimumWidth = 100
        Me.charge.Name = "charge"
        Me.charge.ReadOnly = True
        '
        'transferfrom
        '
        Me.transferfrom.HeaderText = "From"
        Me.transferfrom.MinimumWidth = 100
        Me.transferfrom.Name = "transferfrom"
        Me.transferfrom.ReadOnly = True
        Me.transferfrom.Visible = False
        '
        'transferto
        '
        Me.transferto.HeaderText = "To"
        Me.transferto.MinimumWidth = 100
        Me.transferto.Name = "transferto"
        Me.transferto.ReadOnly = True
        Me.transferto.Visible = False
        '
        'processed_by
        '
        Me.processed_by.HeaderText = "Processed By"
        Me.processed_by.MinimumWidth = 100
        Me.processed_by.Name = "processed_by"
        Me.processed_by.ReadOnly = True
        '
        'datee
        '
        Me.datee.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.datee.FillWeight = 32.0!
        Me.datee.HeaderText = "Time"
        Me.datee.MinimumWidth = 100
        Me.datee.Name = "datee"
        Me.datee.ReadOnly = True
        Me.datee.Width = 250
        '
        'type
        '
        Me.type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.type.FillWeight = 32.0!
        Me.type.HeaderText = "Type"
        Me.type.MinimumWidth = 100
        Me.type.Name = "type"
        Me.type.ReadOnly = True
        Me.type.Visible = False
        Me.type.Width = 300
        '
        'area
        '
        Me.area.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.area.FillWeight = 32.0!
        Me.area.HeaderText = "Area"
        Me.area.MinimumWidth = 100
        Me.area.Name = "area"
        Me.area.ReadOnly = True
        Me.area.Visible = False
        Me.area.Width = 300
        '
        'printreceipt
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.White
        Me.printreceipt.DefaultCellStyle = DataGridViewCellStyle4
        Me.printreceipt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.printreceipt.HeaderText = "Receipt"
        Me.printreceipt.MinimumWidth = 1000
        Me.printreceipt.Name = "printreceipt"
        Me.printreceipt.ReadOnly = True
        Me.printreceipt.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.printreceipt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.printreceipt.Text = "Print"
        Me.printreceipt.UseColumnTextForButtonValue = True
        '
        'txtboxSearch
        '
        Me.txtboxSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtboxSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtboxSearch.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtboxSearch.Location = New System.Drawing.Point(18, 292)
        Me.txtboxSearch.Name = "txtboxSearch"
        Me.txtboxSearch.ShortcutsEnabled = False
        Me.txtboxSearch.Size = New System.Drawing.Size(265, 26)
        Me.txtboxSearch.TabIndex = 5
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSearch.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack
        Me.btnSearch.FlatAppearance.BorderSize = 0
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.ForeColor = System.Drawing.Color.White
        Me.btnSearch.Location = New System.Drawing.Point(282, 292)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(81, 27)
        Me.btnSearch.TabIndex = 6
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'cmbCategory
        '
        Me.cmbCategory.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbCategory.BackColor = System.Drawing.Color.DodgerBlue
        Me.cmbCategory.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbCategory.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCategory.ForeColor = System.Drawing.Color.White
        Me.cmbCategory.FormattingEnabled = True
        Me.cmbCategory.Location = New System.Drawing.Point(1094, 293)
        Me.cmbCategory.Name = "cmbCategory"
        Me.cmbCategory.Size = New System.Drawing.Size(221, 26)
        Me.cmbCategory.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(1017, 298)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 15)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Category:"
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.BackColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer))
        Me.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnPrint.FlatAppearance.BorderSize = 0
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.ForeColor = System.Drawing.Color.White
        Me.btnPrint.Location = New System.Drawing.Point(977, 620)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(191, 36)
        Me.btnPrint.TabIndex = 10
        Me.btnPrint.Text = "REPORT PRINT"
        Me.btnPrint.UseVisualStyleBackColor = False
        Me.btnPrint.Visible = False
        '
        'dtFrom
        '
        Me.dtFrom.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dtFrom.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtFrom.CustomFormat = "MM/dd/yyyy"
        Me.dtFrom.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtFrom.Location = New System.Drawing.Point(76, 623)
        Me.dtFrom.Name = "dtFrom"
        Me.dtFrom.Size = New System.Drawing.Size(113, 26)
        Me.dtFrom.TabIndex = 11
        '
        'dtTo
        '
        Me.dtTo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dtTo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtTo.CustomFormat = "MM/dd/yyyy"
        Me.dtTo.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtTo.Location = New System.Drawing.Point(352, 623)
        Me.dtTo.Name = "dtTo"
        Me.dtTo.Size = New System.Drawing.Size(113, 26)
        Me.dtTo.TabIndex = 12
        Me.dtTo.Visible = False
        '
        'Label3
        '
        Me.Label3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(25, 629)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 15)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "From:"
        '
        'Label4
        '
        Me.Label4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(319, 629)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(27, 15)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "To:"
        Me.Label4.Visible = False
        '
        'btnSearchDate
        '
        Me.btnSearchDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSearchDate.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnSearchDate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSearchDate.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight
        Me.btnSearchDate.FlatAppearance.BorderSize = 0
        Me.btnSearchDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchDate.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearchDate.ForeColor = System.Drawing.Color.White
        Me.btnSearchDate.Location = New System.Drawing.Point(189, 623)
        Me.btnSearchDate.Name = "btnSearchDate"
        Me.btnSearchDate.Size = New System.Drawing.Size(106, 26)
        Me.btnSearchDate.TabIndex = 15
        Me.btnSearchDate.Text = "Search Date"
        Me.btnSearchDate.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.Goldenrod
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.lbltransnum)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.lblRemarks)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.lblSAPNo)
        Me.Panel1.Controls.Add(Me.lbltype)
        Me.Panel1.Location = New System.Drawing.Point(816, 95)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(499, 141)
        Me.Panel1.TabIndex = 20
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox1.Image = Global.AK_POS.My.Resources.Resources.not_available
        Me.PictureBox1.Location = New System.Drawing.Point(7, 8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(145, 126)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 23
        Me.PictureBox1.TabStop = False
        '
        'lbltransnum
        '
        Me.lbltransnum.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbltransnum.AutoSize = True
        Me.lbltransnum.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltransnum.ForeColor = System.Drawing.Color.White
        Me.lbltransnum.Location = New System.Drawing.Point(299, 97)
        Me.lbltransnum.Name = "lbltransnum"
        Me.lbltransnum.Size = New System.Drawing.Size(30, 15)
        Me.lbltransnum.TabIndex = 25
        Me.lbltransnum.Text = "N/A"
        '
        'Label6
        '
        Me.Label6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(158, 91)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(139, 22)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "Transaction #:"
        '
        'lblRemarks
        '
        Me.lblRemarks.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRemarks.AutoSize = True
        Me.lblRemarks.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRemarks.ForeColor = System.Drawing.Color.White
        Me.lblRemarks.Location = New System.Drawing.Point(262, 62)
        Me.lblRemarks.Name = "lblRemarks"
        Me.lblRemarks.Size = New System.Drawing.Size(30, 15)
        Me.lblRemarks.TabIndex = 23
        Me.lblRemarks.Text = "N/A"
        '
        'Label7
        '
        Me.Label7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(158, 56)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(98, 22)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "Remarks:"
        '
        'lblSAPNo
        '
        Me.lblSAPNo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSAPNo.AutoSize = True
        Me.lblSAPNo.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSAPNo.ForeColor = System.Drawing.Color.Green
        Me.lblSAPNo.Location = New System.Drawing.Point(262, 26)
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
        Me.lbltype.Location = New System.Drawing.Point(158, 20)
        Me.lbltype.Name = "lbltype"
        Me.lbltype.Size = New System.Drawing.Size(26, 22)
        Me.lbltype.TabIndex = 20
        Me.lbltype.Text = "#:"
        '
        'lblError
        '
        Me.lblError.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblError.AutoSize = True
        Me.lblError.BackColor = System.Drawing.Color.White
        Me.lblError.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblError.ForeColor = System.Drawing.Color.DimGray
        Me.lblError.Location = New System.Drawing.Point(556, 412)
        Me.lblError.Name = "lblError"
        Me.lblError.Size = New System.Drawing.Size(185, 22)
        Me.lblError.TabIndex = 21
        Me.lblError.Text = "NO FETCH DATA :("
        Me.lblError.Visible = False
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.BackColor = System.Drawing.Color.ForestGreen
        Me.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen
        Me.btnRefresh.FlatAppearance.BorderSize = 0
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefresh.ForeColor = System.Drawing.Color.White
        Me.btnRefresh.Location = New System.Drawing.Point(1174, 620)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(141, 36)
        Me.btnRefresh.TabIndex = 22
        Me.btnRefresh.Text = "REFRESH"
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(726, 299)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 15)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "From:"
        Me.Label5.Visible = False
        '
        'cmbreceived
        '
        Me.cmbreceived.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbreceived.BackColor = System.Drawing.Color.DodgerBlue
        Me.cmbreceived.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbreceived.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbreceived.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbreceived.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbreceived.ForeColor = System.Drawing.Color.White
        Me.cmbreceived.FormattingEnabled = True
        Me.cmbreceived.Location = New System.Drawing.Point(777, 293)
        Me.cmbreceived.Name = "cmbreceived"
        Me.cmbreceived.Size = New System.Drawing.Size(221, 26)
        Me.cmbreceived.TabIndex = 23
        Me.cmbreceived.Visible = False
        '
        'btnobb
        '
        Me.btnobb.BackColor = System.Drawing.Color.Teal
        Me.btnobb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnobb.FlatAppearance.BorderColor = System.Drawing.Color.LightSeaGreen
        Me.btnobb.FlatAppearance.BorderSize = 0
        Me.btnobb.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnobb.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnobb.ForeColor = System.Drawing.Color.White
        Me.btnobb.Location = New System.Drawing.Point(20, 166)
        Me.btnobb.Name = "btnobb"
        Me.btnobb.Size = New System.Drawing.Size(209, 42)
        Me.btnobb.TabIndex = 25
        Me.btnobb.Text = "Adjustment In Item"
        Me.btnobb.UseVisualStyleBackColor = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(486, 271)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 26
        Me.TextBox1.Visible = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1344, 37)
        Me.Panel2.TabIndex = 27
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Gold
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1, 37)
        Me.Panel3.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(182, 22)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "INVENTORY LOGS"
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.Panel4.Controls.Add(Me.lbltotal)
        Me.Panel4.Location = New System.Drawing.Point(18, 324)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1297, 27)
        Me.Panel4.TabIndex = 28
        '
        'lbltotal
        '
        Me.lbltotal.AutoSize = True
        Me.lbltotal.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotal.ForeColor = System.Drawing.Color.White
        Me.lbltotal.Location = New System.Drawing.Point(7, 5)
        Me.lbltotal.Name = "lbltotal"
        Me.lbltotal.Size = New System.Drawing.Size(68, 18)
        Me.lbltotal.TabIndex = 29
        Me.lbltotal.Text = "TOTAL:"
        '
        'inv_logs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1344, 701)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.btnobb)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cmbreceived)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.lblError)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnSearchDate)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dtTo)
        Me.Controls.Add(Me.dtFrom)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbCategory)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.txtboxSearch)
        Me.Controls.Add(Me.dgvData)
        Me.Controls.Add(Me.btnActualEndingBalance)
        Me.Controls.Add(Me.btnPullOut)
        Me.Controls.Add(Me.btnTransfer)
        Me.Controls.Add(Me.btnReceivedItem)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.Name = "inv_logs"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inventory Logs"
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnReceivedItem As System.Windows.Forms.Button
    Friend WithEvents btnTransfer As System.Windows.Forms.Button
    Friend WithEvents btnPullOut As System.Windows.Forms.Button
    Friend WithEvents btnActualEndingBalance As System.Windows.Forms.Button
    Friend WithEvents dgvData As System.Windows.Forms.DataGridView
    Friend WithEvents txtboxSearch As System.Windows.Forms.TextBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents cmbCategory As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents dtFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnSearchDate As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblRemarks As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblSAPNo As System.Windows.Forms.Label
    Friend WithEvents lbltype As System.Windows.Forms.Label
    Friend WithEvents lblError As System.Windows.Forms.Label
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents lbltransnum As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbreceived As System.Windows.Forms.ComboBox
    Friend WithEvents btnobb As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents lbltotal As Label
    Friend WithEvents transnum As DataGridViewTextBoxColumn
    Friend WithEvents invnum As DataGridViewTextBoxColumn
    Friend WithEvents itemcode As DataGridViewTextBoxColumn
    Friend WithEvents itemname As DataGridViewTextBoxColumn
    Friend WithEvents category As DataGridViewTextBoxColumn
    Friend WithEvents quantity As DataGridViewTextBoxColumn
    Friend WithEvents reject As DataGridViewTextBoxColumn
    Friend WithEvents charge As DataGridViewTextBoxColumn
    Friend WithEvents transferfrom As DataGridViewTextBoxColumn
    Friend WithEvents transferto As DataGridViewTextBoxColumn
    Friend WithEvents processed_by As DataGridViewTextBoxColumn
    Friend WithEvents datee As DataGridViewTextBoxColumn
    Friend WithEvents type As DataGridViewTextBoxColumn
    Friend WithEvents area As DataGridViewTextBoxColumn
    Friend WithEvents printreceipt As DataGridViewButtonColumn
End Class
