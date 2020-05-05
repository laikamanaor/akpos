<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class downloadss
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblselected = New System.Windows.Forms.Label()
        Me.btnbrowsepdf = New System.Windows.Forms.Button()
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnselect = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.btnuploadpdf = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbcs = New System.Windows.Forms.RadioButton()
        Me.btnbrowse = New System.Windows.Forms.Button()
        Me.btnupload = New System.Windows.Forms.Button()
        Me.rbconv = New System.Windows.Forms.RadioButton()
        Me.rbendingbal = New System.Windows.Forms.RadioButton()
        Me.rbsap = New System.Windows.Forms.RadioButton()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.datee = New System.Windows.Forms.DateTimePicker()
        Me.dgvdownloads = New System.Windows.Forms.DataGridView()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.filename = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.subtype = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btndownload = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.rbpdf = New System.Windows.Forms.RadioButton()
        Me.rbexcel = New System.Windows.Forms.RadioButton()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvdownloads, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(27, 67)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(843, 320)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(835, 291)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Upload File"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.lblselected)
        Me.GroupBox2.Controls.Add(Me.btnbrowsepdf)
        Me.GroupBox2.Controls.Add(Me.dgv)
        Me.GroupBox2.Controls.Add(Me.btnuploadpdf)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.White
        Me.GroupBox2.Location = New System.Drawing.Point(24, 171)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(792, 114)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "PDF"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(476, 154)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 17)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Selected:"
        '
        'lblselected
        '
        Me.lblselected.AutoSize = True
        Me.lblselected.Location = New System.Drawing.Point(550, 155)
        Me.lblselected.Name = "lblselected"
        Me.lblselected.Size = New System.Drawing.Size(34, 17)
        Me.lblselected.TabIndex = 7
        Me.lblselected.Text = "N/A"
        '
        'btnbrowsepdf
        '
        Me.btnbrowsepdf.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnbrowsepdf.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnbrowsepdf.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnbrowsepdf.FlatAppearance.BorderSize = 0
        Me.btnbrowsepdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnbrowsepdf.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnbrowsepdf.Location = New System.Drawing.Point(633, 24)
        Me.btnbrowsepdf.Name = "btnbrowsepdf"
        Me.btnbrowsepdf.Size = New System.Drawing.Size(144, 33)
        Me.btnbrowsepdf.TabIndex = 6
        Me.btnbrowsepdf.Text = "Browse..."
        Me.btnbrowsepdf.UseVisualStyleBackColor = False
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.AllowUserToResizeColumns = False
        Me.dgv.AllowUserToResizeRows = False
        Me.dgv.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgv.BackgroundColor = System.Drawing.Color.White
        Me.dgv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv.ColumnHeadersHeight = 40
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.description, Me.btnselect})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgv.EnableHeadersVisualStyles = False
        Me.dgv.GridColor = System.Drawing.Color.Black
        Me.dgv.Location = New System.Drawing.Point(20, 23)
        Me.dgv.Name = "dgv"
        Me.dgv.RowHeadersVisible = False
        Me.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv.Size = New System.Drawing.Size(450, 85)
        Me.dgv.TabIndex = 0
        '
        'description
        '
        Me.description.HeaderText = "Description"
        Me.description.Name = "description"
        Me.description.ReadOnly = True
        '
        'btnselect
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Purple
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        Me.btnselect.DefaultCellStyle = DataGridViewCellStyle2
        Me.btnselect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnselect.HeaderText = "Action"
        Me.btnselect.Name = "btnselect"
        Me.btnselect.ReadOnly = True
        Me.btnselect.Text = "Select"
        Me.btnselect.Visible = False
        '
        'btnuploadpdf
        '
        Me.btnuploadpdf.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnuploadpdf.BackColor = System.Drawing.SystemColors.HotTrack
        Me.btnuploadpdf.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnuploadpdf.FlatAppearance.BorderSize = 0
        Me.btnuploadpdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnuploadpdf.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnuploadpdf.Location = New System.Drawing.Point(633, 75)
        Me.btnuploadpdf.Name = "btnuploadpdf"
        Me.btnuploadpdf.Size = New System.Drawing.Size(144, 33)
        Me.btnuploadpdf.TabIndex = 5
        Me.btnuploadpdf.Text = "Upload"
        Me.btnuploadpdf.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.ForestGreen
        Me.GroupBox1.Controls.Add(Me.rbcs)
        Me.GroupBox1.Controls.Add(Me.btnbrowse)
        Me.GroupBox1.Controls.Add(Me.btnupload)
        Me.GroupBox1.Controls.Add(Me.rbconv)
        Me.GroupBox1.Controls.Add(Me.rbendingbal)
        Me.GroupBox1.Controls.Add(Me.rbsap)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(24, 22)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(792, 143)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "EXCEL"
        '
        'rbcs
        '
        Me.rbcs.AutoSize = True
        Me.rbcs.Location = New System.Drawing.Point(244, 24)
        Me.rbcs.Name = "rbcs"
        Me.rbcs.Size = New System.Drawing.Size(115, 21)
        Me.rbcs.TabIndex = 5
        Me.rbcs.TabStop = True
        Me.rbcs.Text = "Coffee Shop"
        Me.rbcs.UseVisualStyleBackColor = True
        '
        'btnbrowse
        '
        Me.btnbrowse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnbrowse.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnbrowse.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnbrowse.FlatAppearance.BorderSize = 0
        Me.btnbrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnbrowse.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnbrowse.Location = New System.Drawing.Point(633, 37)
        Me.btnbrowse.Name = "btnbrowse"
        Me.btnbrowse.Size = New System.Drawing.Size(144, 33)
        Me.btnbrowse.TabIndex = 4
        Me.btnbrowse.Text = "Browse..."
        Me.btnbrowse.UseVisualStyleBackColor = False
        '
        'btnupload
        '
        Me.btnupload.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnupload.BackColor = System.Drawing.SystemColors.HotTrack
        Me.btnupload.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnupload.FlatAppearance.BorderSize = 0
        Me.btnupload.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnupload.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnupload.Location = New System.Drawing.Point(633, 88)
        Me.btnupload.Name = "btnupload"
        Me.btnupload.Size = New System.Drawing.Size(144, 33)
        Me.btnupload.TabIndex = 3
        Me.btnupload.Text = "Upload"
        Me.btnupload.UseVisualStyleBackColor = False
        '
        'rbconv
        '
        Me.rbconv.AutoSize = True
        Me.rbconv.Location = New System.Drawing.Point(20, 100)
        Me.rbconv.Name = "rbconv"
        Me.rbconv.Size = New System.Drawing.Size(109, 21)
        Me.rbconv.TabIndex = 2
        Me.rbconv.TabStop = True
        Me.rbconv.Text = "Conversion"
        Me.rbconv.UseVisualStyleBackColor = True
        '
        'rbendingbal
        '
        Me.rbendingbal.AutoSize = True
        Me.rbendingbal.Location = New System.Drawing.Point(20, 61)
        Me.rbendingbal.Name = "rbendingbal"
        Me.rbendingbal.Size = New System.Drawing.Size(184, 21)
        Me.rbendingbal.TabIndex = 1
        Me.rbendingbal.TabStop = True
        Me.rbendingbal.Text = "Ending Balance Short"
        Me.rbendingbal.UseVisualStyleBackColor = True
        '
        'rbsap
        '
        Me.rbsap.AutoSize = True
        Me.rbsap.Checked = True
        Me.rbsap.Location = New System.Drawing.Point(20, 24)
        Me.rbsap.Name = "rbsap"
        Me.rbsap.Size = New System.Drawing.Size(57, 21)
        Me.rbsap.TabIndex = 0
        Me.rbsap.TabStop = True
        Me.rbsap.Text = "SAP"
        Me.rbsap.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Panel1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(835, 291)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Files"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.datee)
        Me.Panel1.Controls.Add(Me.dgvdownloads)
        Me.Panel1.Controls.Add(Me.rbpdf)
        Me.Panel1.Controls.Add(Me.rbexcel)
        Me.Panel1.Location = New System.Drawing.Point(22, 26)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(787, 322)
        Me.Panel1.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(603, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 15)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Date:"
        '
        'datee
        '
        Me.datee.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.datee.CustomFormat = "MM/dd/yyyy"
        Me.datee.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.datee.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.datee.Location = New System.Drawing.Point(651, 28)
        Me.datee.Name = "datee"
        Me.datee.Size = New System.Drawing.Size(112, 25)
        Me.datee.TabIndex = 5
        '
        'dgvdownloads
        '
        Me.dgvdownloads.AllowUserToAddRows = False
        Me.dgvdownloads.AllowUserToDeleteRows = False
        Me.dgvdownloads.AllowUserToResizeColumns = False
        Me.dgvdownloads.AllowUserToResizeRows = False
        Me.dgvdownloads.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvdownloads.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvdownloads.BackgroundColor = System.Drawing.Color.White
        Me.dgvdownloads.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvdownloads.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvdownloads.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvdownloads.ColumnHeadersHeight = 40
        Me.dgvdownloads.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.filename, Me.subtype, Me.btndownload})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvdownloads.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvdownloads.EnableHeadersVisualStyles = False
        Me.dgvdownloads.Location = New System.Drawing.Point(21, 69)
        Me.dgvdownloads.Name = "dgvdownloads"
        Me.dgvdownloads.Size = New System.Drawing.Size(742, 232)
        Me.dgvdownloads.TabIndex = 4
        '
        'id
        '
        Me.id.HeaderText = "id"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Visible = False
        '
        'filename
        '
        Me.filename.HeaderText = "File Name"
        Me.filename.Name = "filename"
        Me.filename.ReadOnly = True
        '
        'subtype
        '
        Me.subtype.HeaderText = "Type"
        Me.subtype.Name = "subtype"
        Me.subtype.ReadOnly = True
        '
        'btndownload
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.White
        Me.btndownload.DefaultCellStyle = DataGridViewCellStyle5
        Me.btndownload.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btndownload.HeaderText = "Action"
        Me.btndownload.Name = "btndownload"
        Me.btndownload.ReadOnly = True
        Me.btndownload.Text = "Download"
        Me.btndownload.UseColumnTextForButtonValue = True
        '
        'rbpdf
        '
        Me.rbpdf.AutoSize = True
        Me.rbpdf.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbpdf.ForeColor = System.Drawing.Color.White
        Me.rbpdf.Location = New System.Drawing.Point(154, 28)
        Me.rbpdf.Name = "rbpdf"
        Me.rbpdf.Size = New System.Drawing.Size(56, 21)
        Me.rbpdf.TabIndex = 3
        Me.rbpdf.Text = "PDF"
        Me.rbpdf.UseVisualStyleBackColor = True
        '
        'rbexcel
        '
        Me.rbexcel.AutoSize = True
        Me.rbexcel.Checked = True
        Me.rbexcel.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbexcel.ForeColor = System.Drawing.Color.White
        Me.rbexcel.Location = New System.Drawing.Point(21, 28)
        Me.rbexcel.Name = "rbexcel"
        Me.rbexcel.Size = New System.Drawing.Size(75, 21)
        Me.rbexcel.TabIndex = 2
        Me.rbexcel.TabStop = True
        Me.rbexcel.Text = "EXCEL"
        Me.rbexcel.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(896, 25)
        Me.Panel2.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(2, 3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 18)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "FILES"
        '
        'downloadss
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(896, 422)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "downloadss"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvdownloads, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents rbendingbal As RadioButton
    Friend WithEvents rbsap As RadioButton
    Friend WithEvents rbconv As RadioButton
    Friend WithEvents btnupload As Button
    Friend WithEvents btnbrowse As Button
    Friend WithEvents dgv As DataGridView
    Friend WithEvents btnbrowsepdf As Button
    Friend WithEvents btnuploadpdf As Button
    Friend WithEvents lblselected As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents rbpdf As RadioButton
    Friend WithEvents rbexcel As RadioButton
    Friend WithEvents dgvdownloads As DataGridView
    Friend WithEvents Label2 As Label
    Friend WithEvents datee As DateTimePicker
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents Label1 As Label
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents filename As DataGridViewTextBoxColumn
    Friend WithEvents subtype As DataGridViewTextBoxColumn
    Friend WithEvents btndownload As DataGridViewButtonColumn
    Friend WithEvents description As DataGridViewTextBoxColumn
    Friend WithEvents btnselect As DataGridViewButtonColumn
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents rbcs As RadioButton
End Class
