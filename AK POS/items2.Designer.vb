<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class items2
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(items2))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.itemid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.category = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.itemcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.itemname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.price = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.havedeposit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.depositprice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btndis = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.btnedit = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.btnGenerateQRCode = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.cmbcategory = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtsearch = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.chck = New System.Windows.Forms.CheckBox()
        Me.btnrefresh = New System.Windows.Forms.Button()
        Me.btnadd = New System.Windows.Forms.Button()
        Me.btnimport = New System.Windows.Forms.Button()
        Me.btnexport = New System.Windows.Forms.Button()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.lblcount = New System.Windows.Forms.Label()
        Me.btnnext = New System.Windows.Forms.Button()
        Me.btnprev = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.spinner = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.spinner, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Panel7)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1107, 37)
        Me.Panel1.TabIndex = 0
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.Gold
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel7.Location = New System.Drawing.Point(0, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(1, 37)
        Me.Panel7.TabIndex = 3
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(12, 7)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(70, 22)
        Me.Label16.TabIndex = 2
        Me.Label16.Text = "ITEMS"
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.AllowUserToResizeColumns = False
        Me.dgv.AllowUserToResizeRows = False
        Me.dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.itemid, Me.category, Me.itemcode, Me.itemname, Me.description, Me.price, Me.havedeposit, Me.depositprice, Me.btndis, Me.btnedit, Me.btnGenerateQRCode})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgv.EnableHeadersVisualStyles = False
        Me.dgv.GridColor = System.Drawing.Color.Black
        Me.dgv.Location = New System.Drawing.Point(60, 232)
        Me.dgv.Name = "dgv"
        Me.dgv.RowHeadersVisible = False
        Me.dgv.Size = New System.Drawing.Size(992, 324)
        Me.dgv.TabIndex = 1
        '
        'itemid
        '
        Me.itemid.HeaderText = "ID"
        Me.itemid.Name = "itemid"
        Me.itemid.ReadOnly = True
        Me.itemid.Visible = False
        '
        'category
        '
        Me.category.HeaderText = "Category"
        Me.category.Name = "category"
        Me.category.ReadOnly = True
        '
        'itemcode
        '
        Me.itemcode.HeaderText = "Code"
        Me.itemcode.Name = "itemcode"
        Me.itemcode.ReadOnly = True
        '
        'itemname
        '
        Me.itemname.HeaderText = "Item"
        Me.itemname.Name = "itemname"
        Me.itemname.ReadOnly = True
        '
        'description
        '
        Me.description.HeaderText = "Description"
        Me.description.Name = "description"
        Me.description.ReadOnly = True
        '
        'price
        '
        Me.price.HeaderText = "Price"
        Me.price.Name = "price"
        Me.price.ReadOnly = True
        '
        'havedeposit
        '
        Me.havedeposit.HeaderText = "Have Deposit"
        Me.havedeposit.Name = "havedeposit"
        Me.havedeposit.ReadOnly = True
        Me.havedeposit.Visible = False
        '
        'depositprice
        '
        Me.depositprice.HeaderText = "Deposit Price"
        Me.depositprice.Name = "depositprice"
        Me.depositprice.ReadOnly = True
        Me.depositprice.Visible = False
        '
        'btndis
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.OrangeRed
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        Me.btndis.DefaultCellStyle = DataGridViewCellStyle2
        Me.btndis.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btndis.HeaderText = "Action"
        Me.btndis.Name = "btndis"
        Me.btndis.ReadOnly = True
        Me.btndis.Text = "Continue/Discontinue"
        Me.btndis.UseColumnTextForButtonValue = True
        '
        'btnedit
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White
        Me.btnedit.DefaultCellStyle = DataGridViewCellStyle3
        Me.btnedit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnedit.HeaderText = "Action"
        Me.btnedit.Name = "btnedit"
        Me.btnedit.ReadOnly = True
        Me.btnedit.Text = "Edit"
        Me.btnedit.UseColumnTextForButtonValue = True
        '
        'btnGenerateQRCode
        '
        Me.btnGenerateQRCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGenerateQRCode.HeaderText = "Action"
        Me.btnGenerateQRCode.Name = "btnGenerateQRCode"
        Me.btnGenerateQRCode.ReadOnly = True
        Me.btnGenerateQRCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.btnGenerateQRCode.Text = "QR Code"
        Me.btnGenerateQRCode.ToolTipText = "Generate QR Code"
        Me.btnGenerateQRCode.UseColumnTextForButtonValue = True
        '
        'cmbcategory
        '
        Me.cmbcategory.BackColor = System.Drawing.Color.DodgerBlue
        Me.cmbcategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbcategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbcategory.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbcategory.ForeColor = System.Drawing.Color.White
        Me.cmbcategory.FormattingEnabled = True
        Me.cmbcategory.Location = New System.Drawing.Point(364, 184)
        Me.cmbcategory.Name = "cmbcategory"
        Me.cmbcategory.Size = New System.Drawing.Size(190, 22)
        Me.cmbcategory.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DimGray
        Me.Label1.Location = New System.Drawing.Point(361, 166)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 15)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Category:"
        '
        'txtsearch
        '
        Me.txtsearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtsearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtsearch.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsearch.ForeColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer))
        Me.txtsearch.Location = New System.Drawing.Point(60, 181)
        Me.txtsearch.Name = "txtsearch"
        Me.txtsearch.Size = New System.Drawing.Size(216, 25)
        Me.txtsearch.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DimGray
        Me.Label2.Location = New System.Drawing.Point(57, 166)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 15)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Search:"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.DodgerBlue
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(275, 181)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(69, 25)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Search"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'chck
        '
        Me.chck.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chck.AutoSize = True
        Me.chck.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chck.ForeColor = System.Drawing.Color.DimGray
        Me.chck.Location = New System.Drawing.Point(856, 187)
        Me.chck.Name = "chck"
        Me.chck.Size = New System.Drawing.Size(196, 19)
        Me.chck.TabIndex = 7
        Me.chck.Text = "View Discontinued Item(s)"
        Me.chck.UseVisualStyleBackColor = True
        '
        'btnrefresh
        '
        Me.btnrefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnrefresh.BackColor = System.Drawing.SystemColors.HotTrack
        Me.btnrefresh.FlatAppearance.BorderSize = 0
        Me.btnrefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnrefresh.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnrefresh.ForeColor = System.Drawing.Color.White
        Me.btnrefresh.Location = New System.Drawing.Point(297, 562)
        Me.btnrefresh.Name = "btnrefresh"
        Me.btnrefresh.Size = New System.Drawing.Size(89, 28)
        Me.btnrefresh.TabIndex = 8
        Me.btnrefresh.Text = "Refresh"
        Me.btnrefresh.UseVisualStyleBackColor = False
        Me.btnrefresh.Visible = False
        '
        'btnadd
        '
        Me.btnadd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnadd.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnadd.FlatAppearance.BorderSize = 0
        Me.btnadd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnadd.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnadd.ForeColor = System.Drawing.Color.White
        Me.btnadd.Location = New System.Drawing.Point(918, 102)
        Me.btnadd.Name = "btnadd"
        Me.btnadd.Size = New System.Drawing.Size(134, 25)
        Me.btnadd.TabIndex = 9
        Me.btnadd.Text = "ADD ITEM"
        Me.btnadd.UseVisualStyleBackColor = False
        '
        'btnimport
        '
        Me.btnimport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnimport.BackColor = System.Drawing.SystemColors.HotTrack
        Me.btnimport.FlatAppearance.BorderSize = 0
        Me.btnimport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnimport.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnimport.ForeColor = System.Drawing.Color.White
        Me.btnimport.Location = New System.Drawing.Point(60, 558)
        Me.btnimport.Name = "btnimport"
        Me.btnimport.Size = New System.Drawing.Size(115, 28)
        Me.btnimport.TabIndex = 10
        Me.btnimport.Text = "Import Item(s)"
        Me.btnimport.UseVisualStyleBackColor = False
        '
        'btnexport
        '
        Me.btnexport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnexport.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnexport.FlatAppearance.BorderSize = 0
        Me.btnexport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnexport.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnexport.ForeColor = System.Drawing.Color.White
        Me.btnexport.Location = New System.Drawing.Point(176, 558)
        Me.btnexport.Name = "btnexport"
        Me.btnexport.Size = New System.Drawing.Size(115, 28)
        Me.btnexport.TabIndex = 11
        Me.btnexport.Text = "Export Item(s)"
        Me.btnexport.UseVisualStyleBackColor = False
        '
        'lblcount
        '
        Me.lblcount.AutoSize = True
        Me.lblcount.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcount.ForeColor = System.Drawing.Color.White
        Me.lblcount.Location = New System.Drawing.Point(8, 4)
        Me.lblcount.Name = "lblcount"
        Me.lblcount.Size = New System.Drawing.Size(54, 18)
        Me.lblcount.TabIndex = 12
        Me.lblcount.Text = "Page:"
        '
        'btnnext
        '
        Me.btnnext.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnnext.BackColor = System.Drawing.SystemColors.HotTrack
        Me.btnnext.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnnext.FlatAppearance.BorderSize = 0
        Me.btnnext.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnnext.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnnext.ForeColor = System.Drawing.Color.White
        Me.btnnext.Location = New System.Drawing.Point(977, 558)
        Me.btnnext.Name = "btnnext"
        Me.btnnext.Size = New System.Drawing.Size(75, 23)
        Me.btnnext.TabIndex = 14
        Me.btnnext.Text = "Next"
        Me.btnnext.UseVisualStyleBackColor = False
        '
        'btnprev
        '
        Me.btnprev.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnprev.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnprev.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnprev.FlatAppearance.BorderSize = 0
        Me.btnprev.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnprev.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnprev.ForeColor = System.Drawing.Color.White
        Me.btnprev.Location = New System.Drawing.Point(902, 558)
        Me.btnprev.Name = "btnprev"
        Me.btnprev.Size = New System.Drawing.Size(75, 23)
        Me.btnprev.TabIndex = 13
        Me.btnprev.Text = "Previous"
        Me.btnprev.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.Panel2.Controls.Add(Me.lblcount)
        Me.Panel2.Location = New System.Drawing.Point(60, 208)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(992, 25)
        Me.Panel2.TabIndex = 15
        '
        'spinner
        '
        Me.spinner.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.spinner.Image = CType(resources.GetObject("spinner.Image"), System.Drawing.Image)
        Me.spinner.Location = New System.Drawing.Point(502, 67)
        Me.spinner.Name = "spinner"
        Me.spinner.Size = New System.Drawing.Size(140, 89)
        Me.spinner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.spinner.TabIndex = 17
        Me.spinner.TabStop = False
        '
        'items2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1107, 639)
        Me.Controls.Add(Me.spinner)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.btnnext)
        Me.Controls.Add(Me.btnprev)
        Me.Controls.Add(Me.btnexport)
        Me.Controls.Add(Me.btnimport)
        Me.Controls.Add(Me.btnadd)
        Me.Controls.Add(Me.btnrefresh)
        Me.Controls.Add(Me.chck)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtsearch)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbcategory)
        Me.Controls.Add(Me.dgv)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "items2"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.spinner, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Label16 As Label
    Friend WithEvents dgv As DataGridView
    Friend WithEvents cmbcategory As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtsearch As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents chck As CheckBox
    Friend WithEvents btnrefresh As Button
    Friend WithEvents btnadd As Button
    Friend WithEvents btnimport As Button
    Friend WithEvents btnexport As Button
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents lblcount As Label
    Friend WithEvents btnnext As Button
    Friend WithEvents btnprev As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents itemid As DataGridViewTextBoxColumn
    Friend WithEvents category As DataGridViewTextBoxColumn
    Friend WithEvents itemcode As DataGridViewTextBoxColumn
    Friend WithEvents itemname As DataGridViewTextBoxColumn
    Friend WithEvents description As DataGridViewTextBoxColumn
    Friend WithEvents price As DataGridViewTextBoxColumn
    Friend WithEvents havedeposit As DataGridViewTextBoxColumn
    Friend WithEvents depositprice As DataGridViewTextBoxColumn
    Friend WithEvents btndis As DataGridViewButtonColumn
    Friend WithEvents btnedit As DataGridViewButtonColumn
    Friend WithEvents btnGenerateQRCode As DataGridViewButtonColumn
    Friend WithEvents spinner As PictureBox
End Class
