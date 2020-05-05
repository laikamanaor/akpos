<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ar_cancel
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvData = New System.Windows.Forms.DataGridView()
        Me.transnum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.namee = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.amtdue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.datee = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.processed_by = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btncancel = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.btn1 = New System.Windows.Forms.Button()
        Me.btn2 = New System.Windows.Forms.Button()
        Me.lblerror = New System.Windows.Forms.Label()
        Me.dgvitems = New System.Windows.Forms.DataGridView()
        Me.itemname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.quantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.price = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.amount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.panelRemarks = New System.Windows.Forms.Panel()
        Me.lblhide = New System.Windows.Forms.Label()
        Me.btnproceed = New System.Windows.Forms.Button()
        Me.txtremarks = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvitems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.panelRemarks.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvData
        '
        Me.dgvData.AllowUserToAddRows = False
        Me.dgvData.AllowUserToDeleteRows = False
        Me.dgvData.AllowUserToResizeColumns = False
        Me.dgvData.AllowUserToResizeRows = False
        Me.dgvData.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvData.BackgroundColor = System.Drawing.Color.White
        Me.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvData.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.DodgerBlue
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvData.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvData.ColumnHeadersHeight = 60
        Me.dgvData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.transnum, Me.namee, Me.amtdue, Me.datee, Me.processed_by, Me.btncancel})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(32, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvData.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvData.EnableHeadersVisualStyles = False
        Me.dgvData.GridColor = System.Drawing.Color.Black
        Me.dgvData.Location = New System.Drawing.Point(45, 132)
        Me.dgvData.Name = "dgvData"
        Me.dgvData.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvData.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvData.RowHeadersWidth = 20
        Me.dgvData.Size = New System.Drawing.Size(615, 278)
        Me.dgvData.TabIndex = 0
        '
        'transnum
        '
        Me.transnum.FillWeight = 200.0!
        Me.transnum.HeaderText = "Transaction #"
        Me.transnum.Name = "transnum"
        Me.transnum.ReadOnly = True
        '
        'namee
        '
        Me.namee.FillWeight = 200.0!
        Me.namee.HeaderText = "Name"
        Me.namee.Name = "namee"
        Me.namee.ReadOnly = True
        '
        'amtdue
        '
        Me.amtdue.HeaderText = "Amount Due"
        Me.amtdue.Name = "amtdue"
        Me.amtdue.ReadOnly = True
        '
        'datee
        '
        Me.datee.FillWeight = 200.0!
        Me.datee.HeaderText = "Date"
        Me.datee.Name = "datee"
        Me.datee.ReadOnly = True
        '
        'processed_by
        '
        Me.processed_by.FillWeight = 200.0!
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
        Me.btncancel.ToolTipText = "Cancel A.R Charge"
        Me.btncancel.UseColumnTextForButtonValue = True
        '
        'btn1
        '
        Me.btn1.BackColor = System.Drawing.Color.Maroon
        Me.btn1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn1.FlatAppearance.BorderSize = 0
        Me.btn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn1.ForeColor = System.Drawing.Color.White
        Me.btn1.Location = New System.Drawing.Point(45, 39)
        Me.btn1.Name = "btn1"
        Me.btn1.Size = New System.Drawing.Size(127, 30)
        Me.btn1.TabIndex = 1
        Me.btn1.Text = "TO CANCEL"
        Me.btn1.UseVisualStyleBackColor = False
        '
        'btn2
        '
        Me.btn2.BackColor = System.Drawing.Color.Firebrick
        Me.btn2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn2.FlatAppearance.BorderSize = 0
        Me.btn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn2.ForeColor = System.Drawing.Color.White
        Me.btn2.Location = New System.Drawing.Point(178, 39)
        Me.btn2.Name = "btn2"
        Me.btn2.Size = New System.Drawing.Size(127, 30)
        Me.btn2.TabIndex = 2
        Me.btn2.Text = "CANCELLED"
        Me.btn2.UseVisualStyleBackColor = False
        '
        'lblerror
        '
        Me.lblerror.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblerror.AutoSize = True
        Me.lblerror.BackColor = System.Drawing.Color.White
        Me.lblerror.Font = New System.Drawing.Font("Arial Rounded MT Bold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblerror.ForeColor = System.Drawing.Color.DimGray
        Me.lblerror.Location = New System.Drawing.Point(387, 210)
        Me.lblerror.Name = "lblerror"
        Me.lblerror.Size = New System.Drawing.Size(163, 24)
        Me.lblerror.TabIndex = 3
        Me.lblerror.Text = "No fetch data :("
        Me.lblerror.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblerror.Visible = False
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
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.DodgerBlue
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvitems.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvitems.ColumnHeadersHeight = 60
        Me.dgvitems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.itemname, Me.quantity, Me.price, Me.amount})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(32, Byte), Integer))
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvitems.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvitems.EnableHeadersVisualStyles = False
        Me.dgvitems.GridColor = System.Drawing.Color.Black
        Me.dgvitems.Location = New System.Drawing.Point(45, 451)
        Me.dgvitems.Name = "dgvitems"
        Me.dgvitems.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvitems.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvitems.RowHeadersWidth = 20
        Me.dgvitems.Size = New System.Drawing.Size(615, 250)
        Me.dgvitems.TabIndex = 4
        '
        'itemname
        '
        Me.itemname.FillWeight = 200.0!
        Me.itemname.HeaderText = "Item"
        Me.itemname.Name = "itemname"
        Me.itemname.ReadOnly = True
        '
        'quantity
        '
        Me.quantity.HeaderText = "Quantity"
        Me.quantity.Name = "quantity"
        Me.quantity.ReadOnly = True
        '
        'price
        '
        Me.price.FillWeight = 200.0!
        Me.price.HeaderText = "Price"
        Me.price.Name = "price"
        Me.price.ReadOnly = True
        '
        'amount
        '
        Me.amount.FillWeight = 200.0!
        Me.amount.HeaderText = "Amount"
        Me.amount.Name = "amount"
        Me.amount.ReadOnly = True
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(45, 100)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(615, 31)
        Me.Panel1.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(140, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "TRANSACTIONS"
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Location = New System.Drawing.Point(45, 420)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(615, 31)
        Me.Panel2.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(0, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 18)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "ITEMS"
        '
        'panelRemarks
        '
        Me.panelRemarks.BackColor = System.Drawing.Color.DodgerBlue
        Me.panelRemarks.Controls.Add(Me.lblhide)
        Me.panelRemarks.Controls.Add(Me.btnproceed)
        Me.panelRemarks.Controls.Add(Me.txtremarks)
        Me.panelRemarks.Controls.Add(Me.Label3)
        Me.panelRemarks.Location = New System.Drawing.Point(332, 237)
        Me.panelRemarks.Name = "panelRemarks"
        Me.panelRemarks.Size = New System.Drawing.Size(368, 233)
        Me.panelRemarks.TabIndex = 7
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
        'btnproceed
        '
        Me.btnproceed.BackColor = System.Drawing.Color.ForestGreen
        Me.btnproceed.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnproceed.FlatAppearance.BorderSize = 0
        Me.btnproceed.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnproceed.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnproceed.ForeColor = System.Drawing.Color.White
        Me.btnproceed.Location = New System.Drawing.Point(247, 175)
        Me.btnproceed.Name = "btnproceed"
        Me.btnproceed.Size = New System.Drawing.Size(98, 36)
        Me.btnproceed.TabIndex = 2
        Me.btnproceed.Text = "Proceed"
        Me.btnproceed.UseVisualStyleBackColor = False
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
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(23, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 18)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Remarks:"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(415, 51)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(170, 20)
        Me.TextBox1.TabIndex = 8
        Me.TextBox1.Visible = False
        '
        'ar_cancel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(956, 469)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.panelRemarks)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.dgvitems)
        Me.Controls.Add(Me.lblerror)
        Me.Controls.Add(Me.btn2)
        Me.Controls.Add(Me.btn1)
        Me.Controls.Add(Me.dgvData)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "ar_cancel"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvitems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.panelRemarks.ResumeLayout(False)
        Me.panelRemarks.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvData As DataGridView
    Friend WithEvents transnum As DataGridViewTextBoxColumn
    Friend WithEvents namee As DataGridViewTextBoxColumn
    Friend WithEvents amtdue As DataGridViewTextBoxColumn
    Friend WithEvents datee As DataGridViewTextBoxColumn
    Friend WithEvents processed_by As DataGridViewTextBoxColumn
    Friend WithEvents btncancel As DataGridViewButtonColumn
    Friend WithEvents btn1 As Button
    Friend WithEvents btn2 As Button
    Friend WithEvents lblerror As Label
    Friend WithEvents dgvitems As DataGridView
    Friend WithEvents itemname As DataGridViewTextBoxColumn
    Friend WithEvents quantity As DataGridViewTextBoxColumn
    Friend WithEvents price As DataGridViewTextBoxColumn
    Friend WithEvents amount As DataGridViewTextBoxColumn
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents panelRemarks As Panel
    Friend WithEvents btnproceed As Button
    Friend WithEvents txtremarks As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents lblhide As Label
    Friend WithEvents TextBox1 As TextBox
End Class
