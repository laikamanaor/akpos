<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MultiplePOS
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.panelbody = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnPay = New System.Windows.Forms.Button()
        Me.lblGrandTotal = New System.Windows.Forms.Label()
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.item = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.quantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.price = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.discpercent = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.amount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.free = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.pricebefore = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.discamt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnremove = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.panelbody.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panelbody
        '
        Me.panelbody.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panelbody.AutoScroll = True
        Me.panelbody.BackColor = System.Drawing.Color.White
        Me.panelbody.Controls.Add(Me.Panel2)
        Me.panelbody.Location = New System.Drawing.Point(34, 34)
        Me.panelbody.Name = "panelbody"
        Me.panelbody.Size = New System.Drawing.Size(935, 334)
        Me.panelbody.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.Panel2.Controls.Add(Me.dgv)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Location = New System.Drawing.Point(13, 16)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(911, 183)
        Me.Panel2.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 153)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Total: 200"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "ORDER #: 1"
        '
        'btnPay
        '
        Me.btnPay.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPay.Font = New System.Drawing.Font("Arial Rounded MT Bold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPay.Location = New System.Drawing.Point(802, 382)
        Me.btnPay.Name = "btnPay"
        Me.btnPay.Size = New System.Drawing.Size(167, 53)
        Me.btnPay.TabIndex = 1
        Me.btnPay.Text = "PAY"
        Me.btnPay.UseVisualStyleBackColor = True
        '
        'lblGrandTotal
        '
        Me.lblGrandTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblGrandTotal.AutoSize = True
        Me.lblGrandTotal.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGrandTotal.ForeColor = System.Drawing.Color.ForestGreen
        Me.lblGrandTotal.Location = New System.Drawing.Point(30, 398)
        Me.lblGrandTotal.Name = "lblGrandTotal"
        Me.lblGrandTotal.Size = New System.Drawing.Size(222, 22)
        Me.lblGrandTotal.TabIndex = 3
        Me.lblGrandTotal.Text = "GRAND TOTAL: 600.00"
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
        Me.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgv.BackgroundColor = System.Drawing.Color.White
        Me.dgv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgv.ColumnHeadersHeight = 40
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.item, Me.quantity, Me.price, Me.discpercent, Me.amount, Me.free, Me.pricebefore, Me.discamt, Me.btnremove, Me.id})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgv.EnableHeadersVisualStyles = False
        Me.dgv.GridColor = System.Drawing.Color.White
        Me.dgv.Location = New System.Drawing.Point(15, 30)
        Me.dgv.MultiSelect = False
        Me.dgv.Name = "dgv"
        Me.dgv.RowHeadersVisible = False
        Me.dgv.Size = New System.Drawing.Size(884, 120)
        Me.dgv.TabIndex = 96
        '
        'item
        '
        Me.item.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.item.HeaderText = "Item"
        Me.item.Name = "item"
        Me.item.ReadOnly = True
        Me.item.Width = 150
        '
        'quantity
        '
        Me.quantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.quantity.FillWeight = 110.6557!
        Me.quantity.HeaderText = "Qty."
        Me.quantity.Name = "quantity"
        '
        'price
        '
        Me.price.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.price.FillWeight = 111.5509!
        Me.price.HeaderText = "Price"
        Me.price.Name = "price"
        Me.price.ReadOnly = True
        '
        'discpercent
        '
        Me.discpercent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.discpercent.FillWeight = 110.6405!
        Me.discpercent.HeaderText = "Disc. %"
        Me.discpercent.Name = "discpercent"
        '
        'amount
        '
        Me.amount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.amount.FillWeight = 111.5383!
        Me.amount.HeaderText = "Amount"
        Me.amount.Name = "amount"
        '
        'free
        '
        Me.free.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.free.FillWeight = 112.2693!
        Me.free.HeaderText = "Free"
        Me.free.Name = "free"
        '
        'pricebefore
        '
        Me.pricebefore.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.pricebefore.HeaderText = "Price Before"
        Me.pricebefore.Name = "pricebefore"
        Me.pricebefore.ReadOnly = True
        Me.pricebefore.Visible = False
        '
        'discamt
        '
        Me.discamt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.discamt.HeaderText = "Disc. Amt."
        Me.discamt.Name = "discamt"
        Me.discamt.ReadOnly = True
        Me.discamt.Visible = False
        '
        'btnremove
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.Red
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.White
        Me.btnremove.DefaultCellStyle = DataGridViewCellStyle5
        Me.btnremove.FillWeight = 43.34524!
        Me.btnremove.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnremove.HeaderText = "Action"
        Me.btnremove.Name = "btnremove"
        Me.btnremove.ReadOnly = True
        Me.btnremove.Text = "Remove"
        Me.btnremove.ToolTipText = "Remove this item"
        Me.btnremove.UseColumnTextForButtonValue = True
        Me.btnremove.Width = 53
        '
        'id
        '
        Me.id.HeaderText = "ID"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Visible = False
        Me.id.Width = 46
        '
        'MultiplePOS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1000, 450)
        Me.Controls.Add(Me.lblGrandTotal)
        Me.Controls.Add(Me.btnPay)
        Me.Controls.Add(Me.panelbody)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "MultiplePOS"
        Me.Text = "MultiplePOS"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.panelbody.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents panelbody As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnPay As Button
    Friend WithEvents lblGrandTotal As Label
    Friend WithEvents dgv As DataGridView
    Friend WithEvents item As DataGridViewTextBoxColumn
    Friend WithEvents quantity As DataGridViewTextBoxColumn
    Friend WithEvents price As DataGridViewTextBoxColumn
    Friend WithEvents discpercent As DataGridViewTextBoxColumn
    Friend WithEvents amount As DataGridViewTextBoxColumn
    Friend WithEvents free As DataGridViewCheckBoxColumn
    Friend WithEvents pricebefore As DataGridViewTextBoxColumn
    Friend WithEvents discamt As DataGridViewTextBoxColumn
    Friend WithEvents btnremove As DataGridViewButtonColumn
    Friend WithEvents id As DataGridViewTextBoxColumn
End Class
