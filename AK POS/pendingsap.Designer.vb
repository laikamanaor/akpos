<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class pendingsap
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
        Me.dgvlists = New System.Windows.Forms.DataGridView()
        Me.chck = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.transnum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.namee = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sapdocument = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sap = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.from = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.remarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.datecreated = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmbtype = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PanelSAP = New System.Windows.Forms.Panel()
        Me.lblProductionClose = New System.Windows.Forms.Label()
        Me.txtboxSAPNo = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtboxRemarks = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btnProceed = New System.Windows.Forms.Button()
        Me.dgvitems = New System.Windows.Forms.DataGridView()
        Me.itemcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.itemname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.category = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.quantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.reject = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.charge = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnsubmit = New System.Windows.Forms.Button()
        Me.btnimport = New System.Windows.Forms.Button()
        Me.btnexport = New System.Windows.Forms.Button()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblcount1 = New System.Windows.Forms.Label()
        Me.lblcount2 = New System.Windows.Forms.Label()
        Me.txtsearch = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnsearch = New System.Windows.Forms.Button()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.panelsap2 = New System.Windows.Forms.Panel()
        Me.lblclose = New System.Windows.Forms.Label()
        Me.btnproc = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtremarks = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtsap = New System.Windows.Forms.TextBox()
        CType(Me.dgvlists, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelSAP.SuspendLayout()
        CType(Me.dgvitems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelsap2.SuspendLayout()
        Me.SuspendLayout()
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
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvlists.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvlists.ColumnHeadersHeight = 40
        Me.dgvlists.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.chck, Me.type, Me.transnum, Me.namee, Me.sapdocument, Me.sap, Me.from, Me.remarks, Me.datecreated})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvlists.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvlists.EnableHeadersVisualStyles = False
        Me.dgvlists.GridColor = System.Drawing.Color.White
        Me.dgvlists.Location = New System.Drawing.Point(52, 122)
        Me.dgvlists.Name = "dgvlists"
        Me.dgvlists.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dgvlists.RowHeadersWidth = 20
        Me.dgvlists.Size = New System.Drawing.Size(776, 208)
        Me.dgvlists.TabIndex = 0
        '
        'chck
        '
        Me.chck.HeaderText = "Select"
        Me.chck.Name = "chck"
        Me.chck.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.chck.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'type
        '
        Me.type.HeaderText = "Type"
        Me.type.Name = "type"
        Me.type.ReadOnly = True
        Me.type.Visible = False
        '
        'transnum
        '
        Me.transnum.HeaderText = "Transaction #"
        Me.transnum.Name = "transnum"
        Me.transnum.ReadOnly = True
        '
        'namee
        '
        Me.namee.HeaderText = "Name"
        Me.namee.Name = "namee"
        Me.namee.ReadOnly = True
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
        Me.from.Visible = False
        '
        'remarks
        '
        Me.remarks.HeaderText = "Remarks"
        Me.remarks.Name = "remarks"
        Me.remarks.ReadOnly = True
        '
        'datecreated
        '
        Me.datecreated.HeaderText = "Date Created"
        Me.datecreated.Name = "datecreated"
        Me.datecreated.ReadOnly = True
        '
        'cmbtype
        '
        Me.cmbtype.BackColor = System.Drawing.Color.DodgerBlue
        Me.cmbtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbtype.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbtype.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbtype.ForeColor = System.Drawing.Color.White
        Me.cmbtype.FormattingEnabled = True
        Me.cmbtype.Location = New System.Drawing.Point(124, 90)
        Me.cmbtype.Name = "cmbtype"
        Me.cmbtype.Size = New System.Drawing.Size(252, 26)
        Me.cmbtype.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(52, 93)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Type:"
        '
        'PanelSAP
        '
        Me.PanelSAP.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PanelSAP.BackColor = System.Drawing.SystemColors.HotTrack
        Me.PanelSAP.Controls.Add(Me.lblProductionClose)
        Me.PanelSAP.Controls.Add(Me.txtboxSAPNo)
        Me.PanelSAP.Controls.Add(Me.Label11)
        Me.PanelSAP.Controls.Add(Me.txtboxRemarks)
        Me.PanelSAP.Controls.Add(Me.Label13)
        Me.PanelSAP.Controls.Add(Me.btnProceed)
        Me.PanelSAP.Location = New System.Drawing.Point(-301, 9951)
        Me.PanelSAP.Name = "PanelSAP"
        Me.PanelSAP.Size = New System.Drawing.Size(371, 266)
        Me.PanelSAP.TabIndex = 39
        Me.PanelSAP.Visible = False
        '
        'lblProductionClose
        '
        Me.lblProductionClose.AutoSize = True
        Me.lblProductionClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblProductionClose.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProductionClose.ForeColor = System.Drawing.Color.White
        Me.lblProductionClose.Location = New System.Drawing.Point(347, 0)
        Me.lblProductionClose.Name = "lblProductionClose"
        Me.lblProductionClose.Size = New System.Drawing.Size(21, 22)
        Me.lblProductionClose.TabIndex = 6
        Me.lblProductionClose.Text = "X"
        '
        'txtboxSAPNo
        '
        Me.txtboxSAPNo.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtboxSAPNo.Location = New System.Drawing.Point(42, 51)
        Me.txtboxSAPNo.Multiline = True
        Me.txtboxSAPNo.Name = "txtboxSAPNo"
        Me.txtboxSAPNo.ShortcutsEnabled = False
        Me.txtboxSAPNo.Size = New System.Drawing.Size(289, 26)
        Me.txtboxSAPNo.TabIndex = 5
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(39, 28)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(22, 18)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "#:"
        '
        'txtboxRemarks
        '
        Me.txtboxRemarks.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtboxRemarks.Location = New System.Drawing.Point(42, 111)
        Me.txtboxRemarks.Multiline = True
        Me.txtboxRemarks.Name = "txtboxRemarks"
        Me.txtboxRemarks.ShortcutsEnabled = False
        Me.txtboxRemarks.Size = New System.Drawing.Size(289, 90)
        Me.txtboxRemarks.TabIndex = 2
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(39, 90)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(79, 18)
        Me.Label13.TabIndex = 1
        Me.Label13.Text = "Remarks"
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
        Me.btnProceed.Location = New System.Drawing.Point(202, 219)
        Me.btnProceed.Name = "btnProceed"
        Me.btnProceed.Size = New System.Drawing.Size(129, 31)
        Me.btnProceed.TabIndex = 0
        Me.btnProceed.Text = "Proceed"
        Me.btnProceed.UseVisualStyleBackColor = False
        '
        'dgvitems
        '
        Me.dgvitems.AllowUserToAddRows = False
        Me.dgvitems.AllowUserToDeleteRows = False
        Me.dgvitems.AllowUserToResizeColumns = False
        Me.dgvitems.AllowUserToResizeRows = False
        Me.dgvitems.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvitems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvitems.BackgroundColor = System.Drawing.Color.White
        Me.dgvitems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvitems.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvitems.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvitems.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvitems.ColumnHeadersHeight = 40
        Me.dgvitems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.itemcode, Me.itemname, Me.category, Me.quantity, Me.reject, Me.charge})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvitems.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvitems.EnableHeadersVisualStyles = False
        Me.dgvitems.GridColor = System.Drawing.Color.White
        Me.dgvitems.Location = New System.Drawing.Point(61, 381)
        Me.dgvitems.Name = "dgvitems"
        Me.dgvitems.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dgvitems.RowHeadersWidth = 20
        Me.dgvitems.Size = New System.Drawing.Size(767, 263)
        Me.dgvitems.TabIndex = 41
        '
        'itemcode
        '
        Me.itemcode.HeaderText = "Code"
        Me.itemcode.Name = "itemcode"
        Me.itemcode.ReadOnly = True
        '
        'itemname
        '
        Me.itemname.HeaderText = "Name"
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
        Me.btnsubmit.Location = New System.Drawing.Point(736, 87)
        Me.btnsubmit.Name = "btnsubmit"
        Me.btnsubmit.Size = New System.Drawing.Size(92, 32)
        Me.btnsubmit.TabIndex = 42
        Me.btnsubmit.Text = "Submit"
        Me.btnsubmit.UseVisualStyleBackColor = False
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
        Me.btnimport.Location = New System.Drawing.Point(445, 85)
        Me.btnimport.Name = "btnimport"
        Me.btnimport.Size = New System.Drawing.Size(127, 32)
        Me.btnimport.TabIndex = 43
        Me.btnimport.Text = "Import"
        Me.btnimport.UseVisualStyleBackColor = False
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
        Me.btnexport.Location = New System.Drawing.Point(578, 86)
        Me.btnexport.Name = "btnexport"
        Me.btnexport.Size = New System.Drawing.Size(152, 32)
        Me.btnexport.TabIndex = 44
        Me.btnexport.Text = "Export"
        Me.btnexport.UseVisualStyleBackColor = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(12, 10)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 45
        '
        'Label2
        '
        Me.Label2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(58, 333)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(137, 17)
        Me.Label2.TabIndex = 46
        Me.Label2.Text = "TOTAL PENDING:"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(58, 361)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(113, 17)
        Me.Label3.TabIndex = 47
        Me.Label3.Text = "TOTAL ITEMS:"
        '
        'lblcount1
        '
        Me.lblcount1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblcount1.AutoSize = True
        Me.lblcount1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcount1.Location = New System.Drawing.Point(200, 333)
        Me.lblcount1.Name = "lblcount1"
        Me.lblcount1.Size = New System.Drawing.Size(17, 17)
        Me.lblcount1.TabIndex = 48
        Me.lblcount1.Text = "0"
        '
        'lblcount2
        '
        Me.lblcount2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblcount2.AutoSize = True
        Me.lblcount2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcount2.Location = New System.Drawing.Point(200, 361)
        Me.lblcount2.Name = "lblcount2"
        Me.lblcount2.Size = New System.Drawing.Size(17, 17)
        Me.lblcount2.TabIndex = 49
        Me.lblcount2.Text = "0"
        '
        'txtsearch
        '
        Me.txtsearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtsearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtsearch.Enabled = False
        Me.txtsearch.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsearch.Location = New System.Drawing.Point(124, 55)
        Me.txtsearch.Name = "txtsearch"
        Me.txtsearch.Size = New System.Drawing.Size(252, 29)
        Me.txtsearch.TabIndex = 50
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(52, 62)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 17)
        Me.Label4.TabIndex = 51
        Me.Label4.Text = "Search:"
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
        Me.btnsearch.Location = New System.Drawing.Point(375, 54)
        Me.btnsearch.Name = "btnsearch"
        Me.btnsearch.Size = New System.Drawing.Size(92, 30)
        Me.btnsearch.TabIndex = 52
        Me.btnsearch.Text = "Search"
        Me.btnsearch.UseVisualStyleBackColor = False
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DateTimePicker1.CustomFormat = "MM/dd/yyyy"
        Me.DateTimePicker1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker1.Location = New System.Drawing.Point(628, 55)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(200, 29)
        Me.DateTimePicker1.TabIndex = 53
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(575, 64)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 17)
        Me.Label5.TabIndex = 54
        Me.Label5.Text = "Date:"
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
        Me.panelsap2.Location = New System.Drawing.Point(299, 146)
        Me.panelsap2.Name = "panelsap2"
        Me.panelsap2.Size = New System.Drawing.Size(415, 262)
        Me.panelsap2.TabIndex = 55
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
        'pendingsap
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(906, 306)
        Me.Controls.Add(Me.panelsap2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.btnsearch)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtsearch)
        Me.Controls.Add(Me.lblcount1)
        Me.Controls.Add(Me.lblcount2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.btnexport)
        Me.Controls.Add(Me.btnimport)
        Me.Controls.Add(Me.PanelSAP)
        Me.Controls.Add(Me.btnsubmit)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dgvitems)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbtype)
        Me.Controls.Add(Me.dgvlists)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "pendingsap"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pending SAP #"
        CType(Me.dgvlists, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelSAP.ResumeLayout(False)
        Me.PanelSAP.PerformLayout()
        CType(Me.dgvitems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelsap2.ResumeLayout(False)
        Me.panelsap2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvlists As System.Windows.Forms.DataGridView
    Friend WithEvents cmbtype As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PanelSAP As System.Windows.Forms.Panel
    Friend WithEvents lblProductionClose As System.Windows.Forms.Label
    Friend WithEvents txtboxSAPNo As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtboxRemarks As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents btnProceed As System.Windows.Forms.Button
    Friend WithEvents dgvitems As System.Windows.Forms.DataGridView
    Friend WithEvents btnsubmit As System.Windows.Forms.Button
    Friend WithEvents itemcode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents itemname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents category As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents quantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents reject As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents charge As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnimport As System.Windows.Forms.Button
    Friend WithEvents btnexport As System.Windows.Forms.Button
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblcount1 As Label
    Friend WithEvents lblcount2 As Label
    Friend WithEvents txtsearch As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents btnsearch As Button
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents panelsap2 As Panel
    Friend WithEvents lblclose As Label
    Friend WithEvents btnproc As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents txtremarks As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtsap As TextBox
    Friend WithEvents chck As DataGridViewCheckBoxColumn
    Friend WithEvents type As DataGridViewTextBoxColumn
    Friend WithEvents transnum As DataGridViewTextBoxColumn
    Friend WithEvents namee As DataGridViewTextBoxColumn
    Friend WithEvents sapdocument As DataGridViewTextBoxColumn
    Friend WithEvents sap As DataGridViewTextBoxColumn
    Friend WithEvents from As DataGridViewTextBoxColumn
    Friend WithEvents remarks As DataGridViewTextBoxColumn
    Friend WithEvents datecreated As DataGridViewTextBoxColumn
End Class
