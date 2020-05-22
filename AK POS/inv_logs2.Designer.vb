<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class inv_logs2
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnobb = New System.Windows.Forms.Button()
        Me.btnActualEndingBalance = New System.Windows.Forms.Button()
        Me.btnPullOut = New System.Windows.Forms.Button()
        Me.btnTransfer = New System.Windows.Forms.Button()
        Me.btnreceived = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txttrans = New System.Windows.Forms.TextBox()
        Me.dgvtrans = New System.Windows.Forms.DataGridView()
        Me.transnum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fromreceived = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.toreceived = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.processedby = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.time = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnsearch2 = New System.Windows.Forms.Button()
        Me.txtitems = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbcategory = New System.Windows.Forms.ComboBox()
        Me.dgvitems = New System.Windows.Forms.DataGridView()
        Me.itemname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.category = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.quantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dtdate = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel2.SuspendLayout()
        CType(Me.dgvtrans, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvitems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(934, 37)
        Me.Panel2.TabIndex = 28
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
        'btnobb
        '
        Me.btnobb.BackColor = System.Drawing.Color.Teal
        Me.btnobb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnobb.FlatAppearance.BorderColor = System.Drawing.Color.LightSeaGreen
        Me.btnobb.FlatAppearance.BorderSize = 0
        Me.btnobb.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnobb.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnobb.ForeColor = System.Drawing.Color.White
        Me.btnobb.Location = New System.Drawing.Point(721, 57)
        Me.btnobb.Name = "btnobb"
        Me.btnobb.Size = New System.Drawing.Size(189, 29)
        Me.btnobb.TabIndex = 30
        Me.btnobb.Text = "Adjustment In Item"
        Me.btnobb.UseVisualStyleBackColor = False
        '
        'btnActualEndingBalance
        '
        Me.btnActualEndingBalance.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnActualEndingBalance.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnActualEndingBalance.FlatAppearance.BorderColor = System.Drawing.Color.Purple
        Me.btnActualEndingBalance.FlatAppearance.BorderSize = 0
        Me.btnActualEndingBalance.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnActualEndingBalance.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnActualEndingBalance.ForeColor = System.Drawing.Color.White
        Me.btnActualEndingBalance.Location = New System.Drawing.Point(317, 57)
        Me.btnActualEndingBalance.Name = "btnActualEndingBalance"
        Me.btnActualEndingBalance.Size = New System.Drawing.Size(209, 29)
        Me.btnActualEndingBalance.TabIndex = 29
        Me.btnActualEndingBalance.Text = "Actual Ending Balance"
        Me.btnActualEndingBalance.UseVisualStyleBackColor = False
        '
        'btnPullOut
        '
        Me.btnPullOut.BackColor = System.Drawing.Color.Firebrick
        Me.btnPullOut.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPullOut.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed
        Me.btnPullOut.FlatAppearance.BorderSize = 0
        Me.btnPullOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPullOut.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPullOut.ForeColor = System.Drawing.Color.White
        Me.btnPullOut.Location = New System.Drawing.Point(527, 57)
        Me.btnPullOut.Name = "btnPullOut"
        Me.btnPullOut.Size = New System.Drawing.Size(193, 29)
        Me.btnPullOut.TabIndex = 28
        Me.btnPullOut.Text = "Adjustment Out Item"
        Me.btnPullOut.UseVisualStyleBackColor = False
        '
        'btnTransfer
        '
        Me.btnTransfer.BackColor = System.Drawing.SystemColors.HotTrack
        Me.btnTransfer.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTransfer.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue
        Me.btnTransfer.FlatAppearance.BorderSize = 0
        Me.btnTransfer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTransfer.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTransfer.ForeColor = System.Drawing.Color.White
        Me.btnTransfer.Location = New System.Drawing.Point(169, 57)
        Me.btnTransfer.Name = "btnTransfer"
        Me.btnTransfer.Size = New System.Drawing.Size(147, 29)
        Me.btnTransfer.TabIndex = 27
        Me.btnTransfer.Text = "Transfer"
        Me.btnTransfer.UseVisualStyleBackColor = False
        '
        'btnreceived
        '
        Me.btnreceived.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnreceived.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnreceived.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnreceived.FlatAppearance.BorderSize = 0
        Me.btnreceived.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnreceived.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnreceived.ForeColor = System.Drawing.Color.White
        Me.btnreceived.Location = New System.Drawing.Point(21, 57)
        Me.btnreceived.Name = "btnreceived"
        Me.btnreceived.Size = New System.Drawing.Size(147, 29)
        Me.btnreceived.TabIndex = 26
        Me.btnreceived.Text = "Received Item"
        Me.btnreceived.UseVisualStyleBackColor = False
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
        Me.btnSearch.Location = New System.Drawing.Point(274, 135)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(81, 27)
        Me.btnSearch.TabIndex = 32
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'txttrans
        '
        Me.txttrans.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txttrans.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txttrans.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttrans.Location = New System.Drawing.Point(21, 135)
        Me.txttrans.Name = "txttrans"
        Me.txttrans.ShortcutsEnabled = False
        Me.txttrans.Size = New System.Drawing.Size(253, 26)
        Me.txttrans.TabIndex = 31
        '
        'dgvtrans
        '
        Me.dgvtrans.AllowUserToAddRows = False
        Me.dgvtrans.AllowUserToDeleteRows = False
        Me.dgvtrans.AllowUserToResizeColumns = False
        Me.dgvtrans.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvtrans.BackgroundColor = System.Drawing.Color.White
        Me.dgvtrans.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvtrans.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvtrans.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvtrans.ColumnHeadersHeight = 40
        Me.dgvtrans.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.transnum, Me.fromreceived, Me.toreceived, Me.processedby, Me.time})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvtrans.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvtrans.EnableHeadersVisualStyles = False
        Me.dgvtrans.GridColor = System.Drawing.Color.Black
        Me.dgvtrans.Location = New System.Drawing.Point(21, 164)
        Me.dgvtrans.Name = "dgvtrans"
        Me.dgvtrans.RowHeadersVisible = False
        Me.dgvtrans.Size = New System.Drawing.Size(537, 348)
        Me.dgvtrans.TabIndex = 33
        '
        'transnum
        '
        Me.transnum.HeaderText = "Reference #"
        Me.transnum.Name = "transnum"
        Me.transnum.ReadOnly = True
        Me.transnum.Width = 150
        '
        'fromreceived
        '
        Me.fromreceived.HeaderText = "From"
        Me.fromreceived.Name = "fromreceived"
        Me.fromreceived.ReadOnly = True
        Me.fromreceived.Width = 120
        '
        'toreceived
        '
        Me.toreceived.HeaderText = "To"
        Me.toreceived.Name = "toreceived"
        Me.toreceived.ReadOnly = True
        Me.toreceived.Width = 120
        '
        'processedby
        '
        Me.processedby.HeaderText = "Processed By"
        Me.processedby.Name = "processedby"
        Me.processedby.ReadOnly = True
        '
        'time
        '
        Me.time.HeaderText = "Time"
        Me.time.Name = "time"
        Me.time.ReadOnly = True
        Me.time.Width = 75
        '
        'btnsearch2
        '
        Me.btnsearch2.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnsearch2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnsearch2.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack
        Me.btnsearch2.FlatAppearance.BorderSize = 0
        Me.btnsearch2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnsearch2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsearch2.ForeColor = System.Drawing.Color.White
        Me.btnsearch2.Location = New System.Drawing.Point(698, 135)
        Me.btnsearch2.Name = "btnsearch2"
        Me.btnsearch2.Size = New System.Drawing.Size(81, 27)
        Me.btnsearch2.TabIndex = 36
        Me.btnsearch2.Text = "Search"
        Me.btnsearch2.UseVisualStyleBackColor = False
        '
        'txtitems
        '
        Me.txtitems.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtitems.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtitems.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtitems.Location = New System.Drawing.Point(564, 135)
        Me.txtitems.Name = "txtitems"
        Me.txtitems.ShortcutsEnabled = False
        Me.txtitems.Size = New System.Drawing.Size(134, 26)
        Me.txtitems.TabIndex = 35
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DimGray
        Me.Label2.Location = New System.Drawing.Point(696, 142)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 15)
        Me.Label2.TabIndex = 38
        Me.Label2.Text = "Category:"
        '
        'cmbcategory
        '
        Me.cmbcategory.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbcategory.BackColor = System.Drawing.Color.DodgerBlue
        Me.cmbcategory.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbcategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbcategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbcategory.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbcategory.ForeColor = System.Drawing.Color.White
        Me.cmbcategory.FormattingEnabled = True
        Me.cmbcategory.Location = New System.Drawing.Point(773, 136)
        Me.cmbcategory.Name = "cmbcategory"
        Me.cmbcategory.Size = New System.Drawing.Size(137, 26)
        Me.cmbcategory.TabIndex = 37
        '
        'dgvitems
        '
        Me.dgvitems.AllowUserToAddRows = False
        Me.dgvitems.AllowUserToDeleteRows = False
        Me.dgvitems.AllowUserToResizeColumns = False
        Me.dgvitems.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvitems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvitems.BackgroundColor = System.Drawing.Color.White
        Me.dgvitems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvitems.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvitems.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvitems.ColumnHeadersHeight = 40
        Me.dgvitems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.itemname, Me.category, Me.quantity})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvitems.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvitems.EnableHeadersVisualStyles = False
        Me.dgvitems.GridColor = System.Drawing.Color.Black
        Me.dgvitems.Location = New System.Drawing.Point(564, 164)
        Me.dgvitems.Name = "dgvitems"
        Me.dgvitems.RowHeadersVisible = False
        Me.dgvitems.Size = New System.Drawing.Size(346, 348)
        Me.dgvitems.TabIndex = 39
        '
        'itemname
        '
        Me.itemname.HeaderText = "Item"
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
        'dtdate
        '
        Me.dtdate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtdate.CustomFormat = "MM/dd/yyyy"
        Me.dtdate.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtdate.Location = New System.Drawing.Point(449, 137)
        Me.dtdate.Name = "dtdate"
        Me.dtdate.Size = New System.Drawing.Size(109, 22)
        Me.dtdate.TabIndex = 40
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DimGray
        Me.Label3.Location = New System.Drawing.Point(401, 141)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 15)
        Me.Label3.TabIndex = 41
        Me.Label3.Text = "Date:"
        '
        'inv_logs2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(934, 524)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dtdate)
        Me.Controls.Add(Me.dgvitems)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbcategory)
        Me.Controls.Add(Me.btnsearch2)
        Me.Controls.Add(Me.txtitems)
        Me.Controls.Add(Me.dgvtrans)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.txttrans)
        Me.Controls.Add(Me.btnobb)
        Me.Controls.Add(Me.btnActualEndingBalance)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.btnPullOut)
        Me.Controls.Add(Me.btnreceived)
        Me.Controls.Add(Me.btnTransfer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "inv_logs2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "z"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.dgvtrans, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvitems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents btnobb As Button
    Friend WithEvents btnActualEndingBalance As Button
    Friend WithEvents btnPullOut As Button
    Friend WithEvents btnTransfer As Button
    Friend WithEvents btnreceived As Button
    Friend WithEvents btnSearch As Button
    Friend WithEvents txttrans As TextBox
    Friend WithEvents dgvtrans As DataGridView
    Friend WithEvents btnsearch2 As Button
    Friend WithEvents txtitems As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbcategory As ComboBox
    Friend WithEvents dgvitems As DataGridView
    Friend WithEvents itemname As DataGridViewTextBoxColumn
    Friend WithEvents category As DataGridViewTextBoxColumn
    Friend WithEvents quantity As DataGridViewTextBoxColumn
    Friend WithEvents transnum As DataGridViewTextBoxColumn
    Friend WithEvents fromreceived As DataGridViewTextBoxColumn
    Friend WithEvents toreceived As DataGridViewTextBoxColumn
    Friend WithEvents processedby As DataGridViewTextBoxColumn
    Friend WithEvents time As DataGridViewTextBoxColumn
    Friend WithEvents dtdate As DateTimePicker
    Friend WithEvents Label3 As Label
End Class
