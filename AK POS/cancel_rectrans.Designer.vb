<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cancel_rectrans
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
        Me.invnum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.transnum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.typez = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.processed_by = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btncancel = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.dgvitems = New System.Windows.Forms.DataGridView()
        Me.itemname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Category = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.quantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.charge = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblitems = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lbltr = New System.Windows.Forms.Label()
        Me.cmbtype = New System.Windows.Forms.ComboBox()
        Me.btn1 = New System.Windows.Forms.Button()
        Me.btn2 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtsearch = New System.Windows.Forms.TextBox()
        Me.btnsearch = New System.Windows.Forms.Button()
        Me.dt = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnprev = New System.Windows.Forms.Button()
        Me.btnnext = New System.Windows.Forms.Button()
        CType(Me.dgvtrans, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvitems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvtrans
        '
        Me.dgvtrans.AllowUserToAddRows = False
        Me.dgvtrans.AllowUserToDeleteRows = False
        Me.dgvtrans.AllowUserToResizeRows = False
        Me.dgvtrans.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
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
        Me.dgvtrans.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.invnum, Me.transnum, Me.typez, Me.processed_by, Me.btncancel})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvtrans.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvtrans.EnableHeadersVisualStyles = False
        Me.dgvtrans.GridColor = System.Drawing.Color.White
        Me.dgvtrans.Location = New System.Drawing.Point(35, 196)
        Me.dgvtrans.Name = "dgvtrans"
        Me.dgvtrans.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvtrans.RowHeadersVisible = False
        Me.dgvtrans.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvtrans.Size = New System.Drawing.Size(789, 205)
        Me.dgvtrans.TabIndex = 0
        '
        'invnum
        '
        Me.invnum.HeaderText = "Inv. #"
        Me.invnum.Name = "invnum"
        Me.invnum.ReadOnly = True
        '
        'transnum
        '
        Me.transnum.HeaderText = "Reference #"
        Me.transnum.Name = "transnum"
        Me.transnum.ReadOnly = True
        '
        'typez
        '
        Me.typez.HeaderText = "Type"
        Me.typez.Name = "typez"
        Me.typez.ReadOnly = True
        '
        'processed_by
        '
        Me.processed_by.HeaderText = "Processed By"
        Me.processed_by.Name = "processed_by"
        Me.processed_by.ReadOnly = True
        '
        'btncancel
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Firebrick
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        Me.btncancel.DefaultCellStyle = DataGridViewCellStyle2
        Me.btncancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btncancel.HeaderText = "Action"
        Me.btncancel.Name = "btncancel"
        Me.btncancel.ReadOnly = True
        Me.btncancel.Text = "Cancel"
        Me.btncancel.ToolTipText = "Cancel this transaction"
        Me.btncancel.UseColumnTextForButtonValue = True
        '
        'dgvitems
        '
        Me.dgvitems.AllowUserToAddRows = False
        Me.dgvitems.AllowUserToDeleteRows = False
        Me.dgvitems.AllowUserToResizeRows = False
        Me.dgvitems.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvitems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvitems.BackgroundColor = System.Drawing.Color.White
        Me.dgvitems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvitems.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvitems.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvitems.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvitems.ColumnHeadersHeight = 40
        Me.dgvitems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.itemname, Me.Category, Me.quantity, Me.charge})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvitems.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvitems.EnableHeadersVisualStyles = False
        Me.dgvitems.GridColor = System.Drawing.Color.White
        Me.dgvitems.Location = New System.Drawing.Point(34, 462)
        Me.dgvitems.Name = "dgvitems"
        Me.dgvitems.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvitems.RowHeadersVisible = False
        Me.dgvitems.Size = New System.Drawing.Size(789, 55)
        Me.dgvitems.TabIndex = 1
        '
        'itemname
        '
        Me.itemname.HeaderText = "Item Name"
        Me.itemname.Name = "itemname"
        Me.itemname.ReadOnly = True
        '
        'Category
        '
        Me.Category.HeaderText = "Category"
        Me.Category.Name = "Category"
        Me.Category.ReadOnly = True
        '
        'quantity
        '
        Me.quantity.HeaderText = "Quantity"
        Me.quantity.Name = "quantity"
        Me.quantity.ReadOnly = True
        '
        'charge
        '
        Me.charge.HeaderText = "Charge"
        Me.charge.Name = "charge"
        Me.charge.ReadOnly = True
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.Panel1.Controls.Add(Me.lblitems)
        Me.Panel1.Location = New System.Drawing.Point(34, 432)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(789, 31)
        Me.Panel1.TabIndex = 2
        '
        'lblitems
        '
        Me.lblitems.AutoSize = True
        Me.lblitems.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblitems.ForeColor = System.Drawing.Color.White
        Me.lblitems.Location = New System.Drawing.Point(5, 6)
        Me.lblitems.Name = "lblitems"
        Me.lblitems.Size = New System.Drawing.Size(54, 17)
        Me.lblitems.TabIndex = 3
        Me.lblitems.Text = "ITEMS"
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.Panel2.Controls.Add(Me.lbltr)
        Me.Panel2.Location = New System.Drawing.Point(35, 166)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(789, 31)
        Me.Panel2.TabIndex = 4
        '
        'lbltr
        '
        Me.lbltr.AutoSize = True
        Me.lbltr.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltr.ForeColor = System.Drawing.Color.White
        Me.lbltr.Location = New System.Drawing.Point(5, 6)
        Me.lbltr.Name = "lbltr"
        Me.lbltr.Size = New System.Drawing.Size(71, 17)
        Me.lbltr.TabIndex = 3
        Me.lbltr.Text = "Page 0/0"
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
        Me.cmbtype.Items.AddRange(New Object() {"Received Item", "Transfer Item", "Pull Out"})
        Me.cmbtype.Location = New System.Drawing.Point(631, 139)
        Me.cmbtype.Name = "cmbtype"
        Me.cmbtype.Size = New System.Drawing.Size(193, 25)
        Me.cmbtype.TabIndex = 5
        '
        'btn1
        '
        Me.btn1.BackColor = System.Drawing.Color.ForestGreen
        Me.btn1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn1.FlatAppearance.BorderSize = 0
        Me.btn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn1.ForeColor = System.Drawing.Color.Black
        Me.btn1.Location = New System.Drawing.Point(35, 68)
        Me.btn1.Name = "btn1"
        Me.btn1.Size = New System.Drawing.Size(104, 34)
        Me.btn1.TabIndex = 6
        Me.btn1.Text = "COMPLETED"
        Me.btn1.UseVisualStyleBackColor = False
        '
        'btn2
        '
        Me.btn2.BackColor = System.Drawing.Color.ForestGreen
        Me.btn2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn2.FlatAppearance.BorderSize = 0
        Me.btn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn2.ForeColor = System.Drawing.Color.White
        Me.btn2.Location = New System.Drawing.Point(145, 68)
        Me.btn2.Name = "btn2"
        Me.btn2.Size = New System.Drawing.Size(104, 34)
        Me.btn2.TabIndex = 7
        Me.btn2.Text = "CANCELLED"
        Me.btn2.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DimGray
        Me.Label3.Location = New System.Drawing.Point(584, 145)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 14)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Type:"
        '
        'txtsearch
        '
        Me.txtsearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtsearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtsearch.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsearch.Location = New System.Drawing.Point(35, 139)
        Me.txtsearch.Name = "txtsearch"
        Me.txtsearch.Size = New System.Drawing.Size(235, 25)
        Me.txtsearch.TabIndex = 10
        '
        'btnsearch
        '
        Me.btnsearch.BackColor = System.Drawing.Color.ForestGreen
        Me.btnsearch.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnsearch.FlatAppearance.BorderSize = 0
        Me.btnsearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnsearch.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsearch.ForeColor = System.Drawing.Color.White
        Me.btnsearch.Location = New System.Drawing.Point(269, 139)
        Me.btnsearch.Name = "btnsearch"
        Me.btnsearch.Size = New System.Drawing.Size(75, 25)
        Me.btnsearch.TabIndex = 11
        Me.btnsearch.Text = "Search"
        Me.btnsearch.UseVisualStyleBackColor = False
        '
        'dt
        '
        Me.dt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dt.CustomFormat = "MM/dd/yyyy"
        Me.dt.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dt.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dt.Location = New System.Drawing.Point(689, 110)
        Me.dt.Name = "dt"
        Me.dt.Size = New System.Drawing.Size(135, 23)
        Me.dt.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DimGray
        Me.Label1.Location = New System.Drawing.Point(645, 117)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 14)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Date:"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(866, 37)
        Me.Panel3.TabIndex = 14
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Gold
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1, 37)
        Me.Panel4.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(30, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(339, 22)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "CANCEL RECEIVED OR TRANSFER"
        '
        'btnprev
        '
        Me.btnprev.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnprev.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnprev.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnprev.FlatAppearance.BorderSize = 0
        Me.btnprev.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnprev.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnprev.ForeColor = System.Drawing.Color.White
        Me.btnprev.Location = New System.Drawing.Point(672, 403)
        Me.btnprev.Name = "btnprev"
        Me.btnprev.Size = New System.Drawing.Size(75, 23)
        Me.btnprev.TabIndex = 28
        Me.btnprev.Text = "Previous"
        Me.btnprev.UseVisualStyleBackColor = False
        '
        'btnnext
        '
        Me.btnnext.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnnext.BackColor = System.Drawing.SystemColors.HotTrack
        Me.btnnext.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnnext.FlatAppearance.BorderSize = 0
        Me.btnnext.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnnext.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnnext.ForeColor = System.Drawing.Color.White
        Me.btnnext.Location = New System.Drawing.Point(748, 403)
        Me.btnnext.Name = "btnnext"
        Me.btnnext.Size = New System.Drawing.Size(75, 23)
        Me.btnnext.TabIndex = 27
        Me.btnnext.Text = "Next"
        Me.btnnext.UseVisualStyleBackColor = False
        '
        'cancel_rectrans
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(866, 528)
        Me.Controls.Add(Me.btnprev)
        Me.Controls.Add(Me.btnnext)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dt)
        Me.Controls.Add(Me.btnsearch)
        Me.Controls.Add(Me.txtsearch)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btn2)
        Me.Controls.Add(Me.btn1)
        Me.Controls.Add(Me.cmbtype)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.dgvitems)
        Me.Controls.Add(Me.dgvtrans)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "cancel_rectrans"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cancel Received/Transfer"
        CType(Me.dgvtrans, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvitems, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents dgvitems As DataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblitems As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lbltr As Label
    Friend WithEvents cmbtype As ComboBox
    Friend WithEvents btn1 As Button
    Friend WithEvents btn2 As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents itemname As DataGridViewTextBoxColumn
    Friend WithEvents Category As DataGridViewTextBoxColumn
    Friend WithEvents quantity As DataGridViewTextBoxColumn
    Friend WithEvents charge As DataGridViewTextBoxColumn
    Friend WithEvents txtsearch As TextBox
    Friend WithEvents btnsearch As Button
    Friend WithEvents dt As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents btnprev As Button
    Friend WithEvents btnnext As Button
    Friend WithEvents invnum As DataGridViewTextBoxColumn
    Friend WithEvents transnum As DataGridViewTextBoxColumn
    Friend WithEvents typez As DataGridViewTextBoxColumn
    Friend WithEvents processed_by As DataGridViewTextBoxColumn
    Friend WithEvents btncancel As DataGridViewButtonColumn
End Class
