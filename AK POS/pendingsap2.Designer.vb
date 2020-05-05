<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class pendingsap2
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvitems = New System.Windows.Forms.DataGridView()
        Me.itemname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.quantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.reject = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.charge = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvlists = New System.Windows.Forms.DataGridView()
        Me.chck = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.namee = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nameee = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sapdocument = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sap = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.from = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.datecreated = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.datee = New System.Windows.Forms.DateTimePicker()
        Me.btnsearch = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtsearch = New System.Windows.Forms.TextBox()
        Me.btnexport = New System.Windows.Forms.Button()
        Me.btnimport = New System.Windows.Forms.Button()
        Me.btnsubmit = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbtype = New System.Windows.Forms.ComboBox()
        Me.panelsap2 = New System.Windows.Forms.Panel()
        Me.lblclose = New System.Windows.Forms.Label()
        Me.btnproc = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtremarks = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtsap = New System.Windows.Forms.TextBox()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lbltrans_count = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblitems_count = New System.Windows.Forms.Label()
        CType(Me.dgvitems, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvlists, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelsap2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
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
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvitems.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvitems.ColumnHeadersHeight = 40
        Me.dgvitems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.itemname, Me.quantity, Me.reject, Me.charge})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvitems.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvitems.EnableHeadersVisualStyles = False
        Me.dgvitems.GridColor = System.Drawing.Color.White
        Me.dgvitems.Location = New System.Drawing.Point(44, 379)
        Me.dgvitems.Name = "dgvitems"
        Me.dgvitems.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dgvitems.RowHeadersWidth = 20
        Me.dgvitems.Size = New System.Drawing.Size(849, 87)
        Me.dgvitems.TabIndex = 43
        '
        'itemname
        '
        Me.itemname.HeaderText = "Name"
        Me.itemname.Name = "itemname"
        Me.itemname.ReadOnly = True
        '
        'quantity
        '
        Me.quantity.HeaderText = "Quantity"
        Me.quantity.Name = "quantity"
        Me.quantity.ReadOnly = True
        '
        'reject
        '
        Me.reject.HeaderText = "Reject"
        Me.reject.Name = "reject"
        Me.reject.ReadOnly = True
        Me.reject.Visible = False
        '
        'charge
        '
        Me.charge.HeaderText = "Charge"
        Me.charge.Name = "charge"
        Me.charge.ReadOnly = True
        Me.charge.Visible = False
        '
        'dgvlists
        '
        Me.dgvlists.AllowUserToAddRows = False
        Me.dgvlists.AllowUserToDeleteRows = False
        Me.dgvlists.AllowUserToOrderColumns = True
        Me.dgvlists.AllowUserToResizeColumns = False
        Me.dgvlists.AllowUserToResizeRows = False
        Me.dgvlists.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvlists.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvlists.BackgroundColor = System.Drawing.Color.White
        Me.dgvlists.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvlists.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvlists.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvlists.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvlists.ColumnHeadersHeight = 40
        Me.dgvlists.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.chck, Me.namee, Me.nameee, Me.sapdocument, Me.sap, Me.from, Me.datecreated})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvlists.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvlists.EnableHeadersVisualStyles = False
        Me.dgvlists.GridColor = System.Drawing.Color.White
        Me.dgvlists.Location = New System.Drawing.Point(44, 173)
        Me.dgvlists.Name = "dgvlists"
        Me.dgvlists.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dgvlists.RowHeadersWidth = 20
        Me.dgvlists.Size = New System.Drawing.Size(849, 174)
        Me.dgvlists.TabIndex = 42
        '
        'chck
        '
        Me.chck.HeaderText = "Select"
        Me.chck.Name = "chck"
        Me.chck.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.chck.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'namee
        '
        Me.namee.HeaderText = "Trans. #"
        Me.namee.Name = "namee"
        Me.namee.ReadOnly = True
        '
        'nameee
        '
        Me.nameee.HeaderText = "Name"
        Me.nameee.Name = "nameee"
        Me.nameee.ReadOnly = True
        '
        'sapdocument
        '
        Me.sapdocument.HeaderText = "SAP Document"
        Me.sapdocument.Name = "sapdocument"
        Me.sapdocument.ReadOnly = True
        '
        'sap
        '
        Me.sap.HeaderText = "#"
        Me.sap.Name = "sap"
        Me.sap.ReadOnly = True
        '
        'from
        '
        Me.from.HeaderText = "From"
        Me.from.Name = "from"
        Me.from.ReadOnly = True
        '
        'datecreated
        '
        Me.datecreated.HeaderText = "Date"
        Me.datecreated.Name = "datecreated"
        Me.datecreated.ReadOnly = True
        '
        'datee
        '
        Me.datee.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.datee.CustomFormat = "MM/dd/yyyy"
        Me.datee.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.datee.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.datee.Location = New System.Drawing.Point(693, 77)
        Me.datee.Name = "datee"
        Me.datee.Size = New System.Drawing.Size(200, 29)
        Me.datee.TabIndex = 62
        '
        'btnsearch
        '
        Me.btnsearch.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnsearch.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnsearch.Enabled = False
        Me.btnsearch.FlatAppearance.BorderSize = 0
        Me.btnsearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnsearch.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsearch.ForeColor = System.Drawing.Color.White
        Me.btnsearch.Location = New System.Drawing.Point(368, 78)
        Me.btnsearch.Name = "btnsearch"
        Me.btnsearch.Size = New System.Drawing.Size(92, 30)
        Me.btnsearch.TabIndex = 61
        Me.btnsearch.Text = "Search"
        Me.btnsearch.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DimGray
        Me.Label4.Location = New System.Drawing.Point(45, 86)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 17)
        Me.Label4.TabIndex = 60
        Me.Label4.Text = "Search:"
        '
        'txtsearch
        '
        Me.txtsearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtsearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtsearch.Enabled = False
        Me.txtsearch.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsearch.Location = New System.Drawing.Point(117, 79)
        Me.txtsearch.Name = "txtsearch"
        Me.txtsearch.Size = New System.Drawing.Size(252, 29)
        Me.txtsearch.TabIndex = 59
        '
        'btnexport
        '
        Me.btnexport.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnexport.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnexport.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack
        Me.btnexport.FlatAppearance.BorderSize = 2
        Me.btnexport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnexport.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnexport.ForeColor = System.Drawing.Color.Black
        Me.btnexport.Location = New System.Drawing.Point(643, 108)
        Me.btnexport.Name = "btnexport"
        Me.btnexport.Size = New System.Drawing.Size(152, 32)
        Me.btnexport.TabIndex = 58
        Me.btnexport.Text = "Export"
        Me.btnexport.UseVisualStyleBackColor = False
        Me.btnexport.Visible = False
        '
        'btnimport
        '
        Me.btnimport.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnimport.BackColor = System.Drawing.SystemColors.HotTrack
        Me.btnimport.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnimport.FlatAppearance.BorderSize = 0
        Me.btnimport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnimport.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnimport.ForeColor = System.Drawing.Color.White
        Me.btnimport.Location = New System.Drawing.Point(510, 107)
        Me.btnimport.Name = "btnimport"
        Me.btnimport.Size = New System.Drawing.Size(127, 32)
        Me.btnimport.TabIndex = 57
        Me.btnimport.Text = "Import"
        Me.btnimport.UseVisualStyleBackColor = False
        Me.btnimport.Visible = False
        '
        'btnsubmit
        '
        Me.btnsubmit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnsubmit.BackColor = System.Drawing.Color.ForestGreen
        Me.btnsubmit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnsubmit.FlatAppearance.BorderSize = 0
        Me.btnsubmit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.btnsubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnsubmit.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsubmit.ForeColor = System.Drawing.Color.White
        Me.btnsubmit.Location = New System.Drawing.Point(801, 109)
        Me.btnsubmit.Name = "btnsubmit"
        Me.btnsubmit.Size = New System.Drawing.Size(92, 32)
        Me.btnsubmit.TabIndex = 56
        Me.btnsubmit.Text = "Submit"
        Me.btnsubmit.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DimGray
        Me.Label1.Location = New System.Drawing.Point(45, 117)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 17)
        Me.Label1.TabIndex = 55
        Me.Label1.Text = "Type:"
        '
        'cmbtype
        '
        Me.cmbtype.BackColor = System.Drawing.Color.DodgerBlue
        Me.cmbtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbtype.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbtype.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbtype.ForeColor = System.Drawing.Color.White
        Me.cmbtype.FormattingEnabled = True
        Me.cmbtype.Location = New System.Drawing.Point(117, 114)
        Me.cmbtype.Name = "cmbtype"
        Me.cmbtype.Size = New System.Drawing.Size(252, 26)
        Me.cmbtype.TabIndex = 54
        '
        'panelsap2
        '
        Me.panelsap2.BackColor = System.Drawing.Color.DodgerBlue
        Me.panelsap2.Controls.Add(Me.lblclose)
        Me.panelsap2.Controls.Add(Me.btnproc)
        Me.panelsap2.Controls.Add(Me.Label7)
        Me.panelsap2.Controls.Add(Me.txtremarks)
        Me.panelsap2.Controls.Add(Me.Label6)
        Me.panelsap2.Controls.Add(Me.txtsap)
        Me.panelsap2.Location = New System.Drawing.Point(261, 79)
        Me.panelsap2.Name = "panelsap2"
        Me.panelsap2.Size = New System.Drawing.Size(415, 262)
        Me.panelsap2.TabIndex = 63
        Me.panelsap2.Visible = False
        '
        'lblclose
        '
        Me.lblclose.AutoSize = True
        Me.lblclose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblclose.Font = New System.Drawing.Font("Arial Rounded MT Bold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblclose.ForeColor = System.Drawing.Color.White
        Me.lblclose.Location = New System.Drawing.Point(392, 0)
        Me.lblclose.Name = "lblclose"
        Me.lblclose.Size = New System.Drawing.Size(23, 24)
        Me.lblclose.TabIndex = 59
        Me.lblclose.Text = "X"
        '
        'btnproc
        '
        Me.btnproc.BackColor = System.Drawing.Color.ForestGreen
        Me.btnproc.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnproc.FlatAppearance.BorderSize = 0
        Me.btnproc.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnproc.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnproc.ForeColor = System.Drawing.Color.White
        Me.btnproc.Location = New System.Drawing.Point(267, 210)
        Me.btnproc.Name = "btnproc"
        Me.btnproc.Size = New System.Drawing.Size(107, 34)
        Me.btnproc.TabIndex = 58
        Me.btnproc.Text = "PROCEED"
        Me.btnproc.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(49, 94)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(89, 17)
        Me.Label7.TabIndex = 57
        Me.Label7.Text = "REMARKS:"
        '
        'txtremarks
        '
        Me.txtremarks.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtremarks.Location = New System.Drawing.Point(52, 114)
        Me.txtremarks.Multiline = True
        Me.txtremarks.Name = "txtremarks"
        Me.txtremarks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtremarks.Size = New System.Drawing.Size(322, 90)
        Me.txtremarks.TabIndex = 56
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(49, 34)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 17)
        Me.Label6.TabIndex = 55
        Me.Label6.Text = "SAP #:"
        '
        'txtsap
        '
        Me.txtsap.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsap.Location = New System.Drawing.Point(52, 54)
        Me.txtsap.Name = "txtsap"
        Me.txtsap.Size = New System.Drawing.Size(322, 29)
        Me.txtsap.TabIndex = 0
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(537, 77)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 64
        Me.TextBox1.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(940, 32)
        Me.Panel1.TabIndex = 65
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(3, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(144, 22)
        Me.Label2.TabIndex = 66
        Me.Label2.Text = "PENDING SAP"
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.Panel2.Controls.Add(Me.lbltrans_count)
        Me.Panel2.Location = New System.Drawing.Point(44, 146)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(849, 28)
        Me.Panel2.TabIndex = 66
        '
        'lbltrans_count
        '
        Me.lbltrans_count.AutoSize = True
        Me.lbltrans_count.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltrans_count.ForeColor = System.Drawing.Color.White
        Me.lbltrans_count.Location = New System.Drawing.Point(3, 5)
        Me.lbltrans_count.Name = "lbltrans_count"
        Me.lbltrans_count.Size = New System.Drawing.Size(152, 17)
        Me.lbltrans_count.TabIndex = 56
        Me.lbltrans_count.Text = "TRANSACTIONS (0)"
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.Panel3.Controls.Add(Me.lblitems_count)
        Me.Panel3.Location = New System.Drawing.Point(44, 354)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(849, 28)
        Me.Panel3.TabIndex = 67
        '
        'lblitems_count
        '
        Me.lblitems_count.AutoSize = True
        Me.lblitems_count.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblitems_count.ForeColor = System.Drawing.Color.White
        Me.lblitems_count.Location = New System.Drawing.Point(3, 5)
        Me.lblitems_count.Name = "lblitems_count"
        Me.lblitems_count.Size = New System.Drawing.Size(77, 17)
        Me.lblitems_count.TabIndex = 56
        Me.lblitems_count.Text = "ITEMS (0)"
        '
        'pendingsap2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(940, 469)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.panelsap2)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.datee)
        Me.Controls.Add(Me.btnsearch)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtsearch)
        Me.Controls.Add(Me.btnexport)
        Me.Controls.Add(Me.btnimport)
        Me.Controls.Add(Me.btnsubmit)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbtype)
        Me.Controls.Add(Me.dgvitems)
        Me.Controls.Add(Me.dgvlists)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "pendingsap2"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pending SAP"
        CType(Me.dgvitems, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvlists, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelsap2.ResumeLayout(False)
        Me.panelsap2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvitems As DataGridView
    Friend WithEvents dgvlists As DataGridView
    Friend WithEvents datee As DateTimePicker
    Friend WithEvents btnsearch As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents txtsearch As TextBox
    Friend WithEvents btnexport As Button
    Friend WithEvents btnimport As Button
    Friend WithEvents btnsubmit As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbtype As ComboBox
    Friend WithEvents itemname As DataGridViewTextBoxColumn
    Friend WithEvents quantity As DataGridViewTextBoxColumn
    Friend WithEvents reject As DataGridViewTextBoxColumn
    Friend WithEvents charge As DataGridViewTextBoxColumn
    Friend WithEvents panelsap2 As Panel
    Friend WithEvents lblclose As Label
    Friend WithEvents btnproc As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents txtremarks As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtsap As TextBox
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents chck As DataGridViewCheckBoxColumn
    Friend WithEvents namee As DataGridViewTextBoxColumn
    Friend WithEvents nameee As DataGridViewTextBoxColumn
    Friend WithEvents sapdocument As DataGridViewTextBoxColumn
    Friend WithEvents sap As DataGridViewTextBoxColumn
    Friend WithEvents from As DataGridViewTextBoxColumn
    Friend WithEvents datecreated As DataGridViewTextBoxColumn
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lbltrans_count As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents lblitems_count As Label
End Class
