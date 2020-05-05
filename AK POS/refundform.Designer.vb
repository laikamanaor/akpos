<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class refundform
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(refundform))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Label1 = New System.Windows.Forms.Label
        Me.txttrans = New System.Windows.Forms.TextBox
        Me.btncancel = New System.Windows.Forms.Button
        Me.grdorders = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn18 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column1 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label22 = New System.Windows.Forms.Label
        Me.lblvatsales = New System.Windows.Forms.Label
        Me.lblexempt = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblrems = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.txtrems = New System.Windows.Forms.TextBox
        Me.btnremarks = New System.Windows.Forms.Button
        Me.lbltotal = New System.Windows.Forms.Label
        Me.lblvatamt = New System.Windows.Forms.Label
        Me.lblless = New System.Windows.Forms.Label
        Me.lbldisc = New System.Windows.Forms.Label
        Me.lbldel = New System.Windows.Forms.Label
        Me.lblsub = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label15 = New System.Windows.Forms.Label
        Me.lblcashier = New System.Windows.Forms.Label
        Me.lbldate = New System.Windows.Forms.Label
        Me.lbltransnum = New System.Windows.Forms.Label
        Me.btnrefund = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        CType(Me.grdorders, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(35, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Transaction #:"
        '
        'txttrans
        '
        Me.txttrans.Location = New System.Drawing.Point(126, 41)
        Me.txttrans.Name = "txttrans"
        Me.txttrans.Size = New System.Drawing.Size(452, 21)
        Me.txttrans.TabIndex = 0
        '
        'btncancel
        '
        Me.btncancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btncancel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btncancel.Image = CType(resources.GetObject("btncancel.Image"), System.Drawing.Image)
        Me.btncancel.Location = New System.Drawing.Point(740, 45)
        Me.btncancel.Name = "btncancel"
        Me.btncancel.Size = New System.Drawing.Size(109, 23)
        Me.btncancel.TabIndex = 3
        Me.btncancel.Text = "Cancel"
        Me.btncancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btncancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btncancel.UseVisualStyleBackColor = True
        '
        'grdorders
        '
        Me.grdorders.AllowUserToAddRows = False
        Me.grdorders.AllowUserToDeleteRows = False
        Me.grdorders.AllowUserToResizeRows = False
        Me.grdorders.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdorders.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdorders.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdorders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdorders.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn13, Me.DataGridViewTextBoxColumn14, Me.DataGridViewTextBoxColumn15, Me.DataGridViewTextBoxColumn16, Me.DataGridViewTextBoxColumn17, Me.DataGridViewTextBoxColumn18, Me.Column1})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = Nothing
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdorders.DefaultCellStyle = DataGridViewCellStyle2
        Me.grdorders.Location = New System.Drawing.Point(25, 149)
        Me.grdorders.Name = "grdorders"
        Me.grdorders.ReadOnly = True
        Me.grdorders.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdorders.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.grdorders.RowHeadersWidth = 10
        Me.grdorders.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.grdorders.Size = New System.Drawing.Size(824, 199)
        Me.grdorders.TabIndex = 5
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.HeaderText = "Description"
        Me.DataGridViewTextBoxColumn13.MinimumWidth = 190
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        Me.DataGridViewTextBoxColumn13.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn13.Width = 190
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.HeaderText = "Qty"
        Me.DataGridViewTextBoxColumn14.MinimumWidth = 90
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.ReadOnly = True
        Me.DataGridViewTextBoxColumn14.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn14.Width = 90
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.HeaderText = "Price"
        Me.DataGridViewTextBoxColumn15.MinimumWidth = 100
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.ReadOnly = True
        Me.DataGridViewTextBoxColumn15.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.HeaderText = "Discount %"
        Me.DataGridViewTextBoxColumn16.MinimumWidth = 90
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        Me.DataGridViewTextBoxColumn16.ReadOnly = True
        Me.DataGridViewTextBoxColumn16.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn16.Width = 90
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.HeaderText = "Amount"
        Me.DataGridViewTextBoxColumn17.MinimumWidth = 120
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        Me.DataGridViewTextBoxColumn17.ReadOnly = True
        Me.DataGridViewTextBoxColumn17.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn17.Width = 120
        '
        'DataGridViewTextBoxColumn18
        '
        Me.DataGridViewTextBoxColumn18.HeaderText = "Request"
        Me.DataGridViewTextBoxColumn18.MinimumWidth = 130
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        Me.DataGridViewTextBoxColumn18.ReadOnly = True
        Me.DataGridViewTextBoxColumn18.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn18.Width = 130
        '
        'Column1
        '
        Me.Column1.HeaderText = "Free"
        Me.Column1.MinimumWidth = 60
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column1.Width = 60
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel1.Controls.Add(Me.Label22)
        Me.Panel1.Controls.Add(Me.lblvatsales)
        Me.Panel1.Controls.Add(Me.lblexempt)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.lblrems)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.txtrems)
        Me.Panel1.Controls.Add(Me.btnremarks)
        Me.Panel1.Controls.Add(Me.lbltotal)
        Me.Panel1.Controls.Add(Me.lblvatamt)
        Me.Panel1.Controls.Add(Me.lblless)
        Me.Panel1.Controls.Add(Me.lbldisc)
        Me.Panel1.Controls.Add(Me.lbldel)
        Me.Panel1.Controls.Add(Me.lblsub)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Location = New System.Drawing.Point(25, 346)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(824, 189)
        Me.Panel1.TabIndex = 6
        '
        'Label22
        '
        Me.Label22.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Green
        Me.Label22.Location = New System.Drawing.Point(576, 118)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(76, 18)
        Me.Label22.TabIndex = 44
        Me.Label22.Text = "Vat Sales:"
        '
        'lblvatsales
        '
        Me.lblvatsales.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblvatsales.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblvatsales.ForeColor = System.Drawing.Color.Green
        Me.lblvatsales.Location = New System.Drawing.Point(664, 118)
        Me.lblvatsales.Name = "lblvatsales"
        Me.lblvatsales.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblvatsales.Size = New System.Drawing.Size(163, 18)
        Me.lblvatsales.TabIndex = 25
        Me.lblvatsales.Text = "0.00"
        '
        'lblexempt
        '
        Me.lblexempt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblexempt.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblexempt.ForeColor = System.Drawing.Color.Green
        Me.lblexempt.Location = New System.Drawing.Point(664, 96)
        Me.lblexempt.Name = "lblexempt"
        Me.lblexempt.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblexempt.Size = New System.Drawing.Size(163, 18)
        Me.lblexempt.TabIndex = 43
        Me.lblexempt.Text = "0.00"
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Green
        Me.Label17.Location = New System.Drawing.Point(563, 140)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(89, 18)
        Me.Label17.TabIndex = 24
        Me.Label17.Text = "Vat Amount:"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Green
        Me.Label2.Location = New System.Drawing.Point(519, 96)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(133, 18)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "Vat Exempt Sales:"
        '
        'lblrems
        '
        Me.lblrems.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblrems.BackColor = System.Drawing.Color.Gainsboro
        Me.lblrems.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblrems.ForeColor = System.Drawing.Color.Green
        Me.lblrems.Location = New System.Drawing.Point(7, 36)
        Me.lblrems.Name = "lblrems"
        Me.lblrems.Size = New System.Drawing.Size(507, 90)
        Me.lblrems.TabIndex = 21
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Green
        Me.Label14.Location = New System.Drawing.Point(4, 13)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(62, 15)
        Me.Label14.TabIndex = 20
        Me.Label14.Text = "Remarks:"
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(151, 162)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(109, 23)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "Cancel"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'txtrems
        '
        Me.txtrems.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtrems.Location = New System.Drawing.Point(7, 131)
        Me.txtrems.Name = "txtrems"
        Me.txtrems.Size = New System.Drawing.Size(253, 21)
        Me.txtrems.TabIndex = 6
        Me.txtrems.Visible = False
        '
        'btnremarks
        '
        Me.btnremarks.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnremarks.Enabled = False
        Me.btnremarks.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnremarks.Image = CType(resources.GetObject("btnremarks.Image"), System.Drawing.Image)
        Me.btnremarks.Location = New System.Drawing.Point(7, 163)
        Me.btnremarks.Name = "btnremarks"
        Me.btnremarks.Size = New System.Drawing.Size(109, 23)
        Me.btnremarks.TabIndex = 5
        Me.btnremarks.Text = "Add Remarks"
        Me.btnremarks.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnremarks.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnremarks.UseVisualStyleBackColor = True
        Me.btnremarks.Visible = False
        '
        'lbltotal
        '
        Me.lbltotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbltotal.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotal.ForeColor = System.Drawing.Color.Green
        Me.lbltotal.Location = New System.Drawing.Point(664, 160)
        Me.lbltotal.Name = "lbltotal"
        Me.lbltotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lbltotal.Size = New System.Drawing.Size(163, 18)
        Me.lbltotal.TabIndex = 11
        Me.lbltotal.Text = "0.00"
        '
        'lblvatamt
        '
        Me.lblvatamt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblvatamt.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblvatamt.ForeColor = System.Drawing.Color.Green
        Me.lblvatamt.Location = New System.Drawing.Point(664, 140)
        Me.lblvatamt.Name = "lblvatamt"
        Me.lblvatamt.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblvatamt.Size = New System.Drawing.Size(163, 18)
        Me.lblvatamt.TabIndex = 10
        Me.lblvatamt.Text = "0.00"
        '
        'lblless
        '
        Me.lblless.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblless.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblless.ForeColor = System.Drawing.Color.Green
        Me.lblless.Location = New System.Drawing.Point(664, 56)
        Me.lblless.Name = "lblless"
        Me.lblless.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblless.Size = New System.Drawing.Size(163, 18)
        Me.lblless.TabIndex = 9
        Me.lblless.Text = "0.00"
        '
        'lbldisc
        '
        Me.lbldisc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbldisc.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldisc.ForeColor = System.Drawing.Color.Green
        Me.lbldisc.Location = New System.Drawing.Point(664, 33)
        Me.lbldisc.Name = "lbldisc"
        Me.lbldisc.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lbldisc.Size = New System.Drawing.Size(163, 18)
        Me.lbldisc.TabIndex = 8
        Me.lbldisc.Text = "None"
        '
        'lbldel
        '
        Me.lbldel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbldel.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldel.ForeColor = System.Drawing.Color.Green
        Me.lbldel.Location = New System.Drawing.Point(664, 74)
        Me.lbldel.Name = "lbldel"
        Me.lbldel.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lbldel.Size = New System.Drawing.Size(163, 18)
        Me.lbldel.TabIndex = 7
        Me.lbldel.Text = "0.00"
        '
        'lblsub
        '
        Me.lblsub.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblsub.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsub.ForeColor = System.Drawing.Color.Green
        Me.lblsub.Location = New System.Drawing.Point(664, 13)
        Me.lblsub.Name = "lblsub"
        Me.lblsub.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblsub.Size = New System.Drawing.Size(163, 18)
        Me.lblsub.TabIndex = 6
        Me.lblsub.Text = "0.00"
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Green
        Me.Label12.Location = New System.Drawing.Point(516, 160)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(136, 18)
        Me.Label12.TabIndex = 5
        Me.Label12.Text = "Total Amount Due:"
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Green
        Me.Label8.Location = New System.Drawing.Point(573, 13)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(79, 18)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Sub Total:"
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Green
        Me.Label9.Location = New System.Drawing.Point(525, 74)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(127, 18)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "Delivery Charge:"
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Green
        Me.Label11.Location = New System.Drawing.Point(539, 33)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(113, 18)
        Me.Label11.TabIndex = 2
        Me.Label11.Text = "Discount Type:"
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Green
        Me.Label10.Location = New System.Drawing.Point(589, 53)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(63, 18)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "Less %:"
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.Panel2.Controls.Add(Me.Label15)
        Me.Panel2.Controls.Add(Me.lblcashier)
        Me.Panel2.Controls.Add(Me.lbldate)
        Me.Panel2.Controls.Add(Me.lbltransnum)
        Me.Panel2.Location = New System.Drawing.Point(25, 80)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(824, 62)
        Me.Panel2.TabIndex = 16
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Green
        Me.Label15.Location = New System.Drawing.Point(9, 4)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(144, 22)
        Me.Label15.TabIndex = 16
        Me.Label15.Text = "Transaction #:"
        '
        'lblcashier
        '
        Me.lblcashier.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblcashier.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcashier.ForeColor = System.Drawing.Color.Green
        Me.lblcashier.Location = New System.Drawing.Point(636, 9)
        Me.lblcashier.Name = "lblcashier"
        Me.lblcashier.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblcashier.Size = New System.Drawing.Size(191, 18)
        Me.lblcashier.TabIndex = 15
        '
        'lbldate
        '
        Me.lbldate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbldate.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldate.ForeColor = System.Drawing.Color.Green
        Me.lbldate.Location = New System.Drawing.Point(703, 33)
        Me.lbldate.Name = "lbldate"
        Me.lbldate.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lbldate.Size = New System.Drawing.Size(124, 16)
        Me.lbldate.TabIndex = 14
        '
        'lbltransnum
        '
        Me.lbltransnum.AutoSize = True
        Me.lbltransnum.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltransnum.ForeColor = System.Drawing.Color.Green
        Me.lbltransnum.Location = New System.Drawing.Point(6, 32)
        Me.lbltransnum.Name = "lbltransnum"
        Me.lbltransnum.Size = New System.Drawing.Size(0, 22)
        Me.lbltransnum.TabIndex = 13
        '
        'btnrefund
        '
        Me.btnrefund.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnrefund.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnrefund.Image = CType(resources.GetObject("btnrefund.Image"), System.Drawing.Image)
        Me.btnrefund.Location = New System.Drawing.Point(625, 45)
        Me.btnrefund.Name = "btnrefund"
        Me.btnrefund.Size = New System.Drawing.Size(109, 23)
        Me.btnrefund.TabIndex = 2
        Me.btnrefund.Text = "Ok"
        Me.btnrefund.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnrefund.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnrefund.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Vivaldi", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label5.Location = New System.Drawing.Point(22, 525)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 13)
        Me.Label5.TabIndex = 42
        Me.Label5.Text = "-Jecel-"
        '
        'refundform
        '
        Me.AcceptButton = Me.btnrefund
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(876, 547)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.grdorders)
        Me.Controls.Add(Me.btncancel)
        Me.Controls.Add(Me.btnrefund)
        Me.Controls.Add(Me.txttrans)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "refundform"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cancel Transasctions"
        CType(Me.grdorders, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txttrans As System.Windows.Forms.TextBox
    Friend WithEvents btncancel As System.Windows.Forms.Button
    Friend WithEvents grdorders As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblrems As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtrems As System.Windows.Forms.TextBox
    Friend WithEvents btnremarks As System.Windows.Forms.Button
    Friend WithEvents lbltotal As System.Windows.Forms.Label
    Friend WithEvents lblvatamt As System.Windows.Forms.Label
    Friend WithEvents lblless As System.Windows.Forms.Label
    Friend WithEvents lbldisc As System.Windows.Forms.Label
    Friend WithEvents lbldel As System.Windows.Forms.Label
    Friend WithEvents lblsub As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lblcashier As System.Windows.Forms.Label
    Friend WithEvents lbldate As System.Windows.Forms.Label
    Friend WithEvents lbltransnum As System.Windows.Forms.Label
    Friend WithEvents btnrefund As System.Windows.Forms.Button
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblvatsales As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents lblexempt As System.Windows.Forms.Label
End Class
