<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class inv2
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.itemcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.itemname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.category = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.begbal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.produce = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.good = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.charge = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.productionin = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.branchin = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.supin = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.adjustmentin = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.convin = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.salesin = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.totalav = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.transfer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pullout2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ctrout = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.archarge = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.arsales = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.convout = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.adjustmentout = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.salesout = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.endbal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.actualendbal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.variance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.shortover = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.overamt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ctrout_amt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.archarge_amt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.arsales_amt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmbcategory = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbinventory = New System.Windows.Forms.ComboBox()
        Me.txtsearch = New System.Windows.Forms.TextBox()
        Me.rb2 = New System.Windows.Forms.RadioButton()
        Me.rb1 = New System.Windows.Forms.RadioButton()
        Me.lblinvnum = New System.Windows.Forms.Label()
        Me.lbldatetime = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dtinvsearch = New System.Windows.Forms.DateTimePicker()
        Me.btnverify = New System.Windows.Forms.Button()
        Me.btnrefresh = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lbltotal = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lblarsalesamount = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblcounteramount = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblarchargeamount = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lbloveramount = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblshortamount = New System.Windows.Forms.Label()
        Me.lblnodata = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lblcount = New System.Windows.Forms.Label()
        Me.btnPrint = New System.Windows.Forms.Button()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.AllowUserToResizeRows = False
        Me.dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv.BackgroundColor = System.Drawing.Color.White
        Me.dgv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgv.ColumnHeadersHeight = 40
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.itemcode, Me.itemname, Me.category, Me.begbal, Me.produce, Me.good, Me.charge, Me.productionin, Me.branchin, Me.supin, Me.adjustmentin, Me.convin, Me.salesin, Me.totalav, Me.transfer, Me.pullout2, Me.ctrout, Me.archarge, Me.arsales, Me.convout, Me.adjustmentout, Me.salesout, Me.endbal, Me.actualendbal, Me.variance, Me.shortover, Me.overamt, Me.ctrout_amt, Me.archarge_amt, Me.arsales_amt})
        Me.dgv.EnableHeadersVisualStyles = False
        Me.dgv.GridColor = System.Drawing.Color.Black
        Me.dgv.Location = New System.Drawing.Point(24, 213)
        Me.dgv.Name = "dgv"
        Me.dgv.RowHeadersVisible = False
        Me.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv.Size = New System.Drawing.Size(893, 133)
        Me.dgv.TabIndex = 0
        '
        'id
        '
        Me.id.Frozen = True
        Me.id.HeaderText = "ID"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Visible = False
        '
        'itemcode
        '
        Me.itemcode.Frozen = True
        Me.itemcode.HeaderText = "Item Code"
        Me.itemcode.Name = "itemcode"
        Me.itemcode.ReadOnly = True
        Me.itemcode.Width = 150
        '
        'itemname
        '
        Me.itemname.Frozen = True
        Me.itemname.HeaderText = "Item Name"
        Me.itemname.Name = "itemname"
        Me.itemname.ReadOnly = True
        Me.itemname.Width = 150
        '
        'category
        '
        Me.category.Frozen = True
        Me.category.HeaderText = "Category"
        Me.category.Name = "category"
        Me.category.ReadOnly = True
        Me.category.Visible = False
        '
        'begbal
        '
        Me.begbal.HeaderText = "Beg Bal"
        Me.begbal.Name = "begbal"
        Me.begbal.ReadOnly = True
        '
        'produce
        '
        Me.produce.HeaderText = "Produce"
        Me.produce.Name = "produce"
        Me.produce.ReadOnly = True
        Me.produce.Visible = False
        '
        'good
        '
        Me.good.HeaderText = "Good"
        Me.good.Name = "good"
        Me.good.ReadOnly = True
        Me.good.Visible = False
        '
        'charge
        '
        Me.charge.HeaderText = "Charge"
        Me.charge.Name = "charge"
        Me.charge.ReadOnly = True
        '
        'productionin
        '
        Me.productionin.HeaderText = "Production In"
        Me.productionin.Name = "productionin"
        Me.productionin.ReadOnly = True
        '
        'branchin
        '
        Me.branchin.HeaderText = "Branch In"
        Me.branchin.Name = "branchin"
        Me.branchin.ReadOnly = True
        '
        'supin
        '
        Me.supin.HeaderText = "Supplier In"
        Me.supin.Name = "supin"
        Me.supin.ReadOnly = True
        '
        'adjustmentin
        '
        Me.adjustmentin.HeaderText = "Adjustment In"
        Me.adjustmentin.Name = "adjustmentin"
        Me.adjustmentin.ReadOnly = True
        '
        'convin
        '
        Me.convin.HeaderText = "Conv. In"
        Me.convin.Name = "convin"
        Me.convin.ReadOnly = True
        '
        'salesin
        '
        Me.salesin.HeaderText = "Transfer from Sales"
        Me.salesin.Name = "salesin"
        Me.salesin.ReadOnly = True
        '
        'totalav
        '
        Me.totalav.HeaderText = "Total Qty. Available"
        Me.totalav.Name = "totalav"
        Me.totalav.ReadOnly = True
        '
        'transfer
        '
        Me.transfer.HeaderText = "Transfer"
        Me.transfer.Name = "transfer"
        Me.transfer.ReadOnly = True
        '
        'pullout2
        '
        Me.pullout2.HeaderText = "Pull Out"
        Me.pullout2.Name = "pullout2"
        Me.pullout2.ReadOnly = True
        '
        'ctrout
        '
        Me.ctrout.HeaderText = "Counter Out"
        Me.ctrout.Name = "ctrout"
        Me.ctrout.ReadOnly = True
        '
        'archarge
        '
        Me.archarge.HeaderText = "A.R Charge"
        Me.archarge.Name = "archarge"
        Me.archarge.ReadOnly = True
        '
        'arsales
        '
        Me.arsales.HeaderText = "A.R Sales"
        Me.arsales.Name = "arsales"
        Me.arsales.ReadOnly = True
        '
        'convout
        '
        Me.convout.HeaderText = "Conv. Out"
        Me.convout.Name = "convout"
        Me.convout.ReadOnly = True
        '
        'adjustmentout
        '
        Me.adjustmentout.HeaderText = "Adjustment Out"
        Me.adjustmentout.Name = "adjustmentout"
        Me.adjustmentout.ReadOnly = True
        '
        'salesout
        '
        Me.salesout.HeaderText = "Transfer to Sales"
        Me.salesout.Name = "salesout"
        Me.salesout.ReadOnly = True
        '
        'endbal
        '
        Me.endbal.HeaderText = "End Bal"
        Me.endbal.Name = "endbal"
        Me.endbal.ReadOnly = True
        '
        'actualendbal
        '
        Me.actualendbal.HeaderText = "Actual End Bal"
        Me.actualendbal.Name = "actualendbal"
        Me.actualendbal.ReadOnly = True
        '
        'variance
        '
        Me.variance.HeaderText = "Variance"
        Me.variance.Name = "variance"
        Me.variance.ReadOnly = True
        '
        'shortover
        '
        Me.shortover.HeaderText = "Short/Over"
        Me.shortover.Name = "shortover"
        Me.shortover.ReadOnly = True
        Me.shortover.Visible = False
        '
        'overamt
        '
        Me.overamt.HeaderText = "Over Amt."
        Me.overamt.Name = "overamt"
        Me.overamt.ReadOnly = True
        '
        'ctrout_amt
        '
        Me.ctrout_amt.HeaderText = "Counter Out Amt."
        Me.ctrout_amt.Name = "ctrout_amt"
        Me.ctrout_amt.ReadOnly = True
        '
        'archarge_amt
        '
        Me.archarge_amt.HeaderText = "A.R Charge Amt."
        Me.archarge_amt.Name = "archarge_amt"
        Me.archarge_amt.ReadOnly = True
        '
        'arsales_amt
        '
        Me.arsales_amt.HeaderText = "A.R Sales Amt."
        Me.arsales_amt.Name = "arsales_amt"
        Me.arsales_amt.ReadOnly = True
        '
        'cmbcategory
        '
        Me.cmbcategory.BackColor = System.Drawing.SystemColors.HotTrack
        Me.cmbcategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbcategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbcategory.ForeColor = System.Drawing.Color.White
        Me.cmbcategory.FormattingEnabled = True
        Me.cmbcategory.Location = New System.Drawing.Point(102, 30)
        Me.cmbcategory.Name = "cmbcategory"
        Me.cmbcategory.Size = New System.Drawing.Size(195, 23)
        Me.cmbcategory.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(15, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 15)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Category:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(15, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 15)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Item Name:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cmbinventory)
        Me.GroupBox1.Controls.Add(Me.txtsearch)
        Me.GroupBox1.Controls.Add(Me.rb2)
        Me.GroupBox1.Controls.Add(Me.rb1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cmbcategory)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.DimGray
        Me.GroupBox1.Location = New System.Drawing.Point(24, 75)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(617, 94)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Parameters"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(300, 36)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 15)
        Me.Label4.TabIndex = 83
        Me.Label4.Text = "Inventory:"
        '
        'cmbinventory
        '
        Me.cmbinventory.BackColor = System.Drawing.SystemColors.HotTrack
        Me.cmbinventory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbinventory.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbinventory.ForeColor = System.Drawing.Color.White
        Me.cmbinventory.FormattingEnabled = True
        Me.cmbinventory.Location = New System.Drawing.Point(303, 57)
        Me.cmbinventory.Name = "cmbinventory"
        Me.cmbinventory.Size = New System.Drawing.Size(186, 23)
        Me.cmbinventory.TabIndex = 82
        '
        'txtsearch
        '
        Me.txtsearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtsearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtsearch.ForeColor = System.Drawing.Color.Black
        Me.txtsearch.Location = New System.Drawing.Point(102, 57)
        Me.txtsearch.Name = "txtsearch"
        Me.txtsearch.Size = New System.Drawing.Size(195, 23)
        Me.txtsearch.TabIndex = 81
        '
        'rb2
        '
        Me.rb2.AutoSize = True
        Me.rb2.Location = New System.Drawing.Point(495, 60)
        Me.rb2.Name = "rb2"
        Me.rb2.Size = New System.Drawing.Size(107, 19)
        Me.rb2.TabIndex = 80
        Me.rb2.Text = "Non-stock(s)"
        Me.rb2.UseVisualStyleBackColor = True
        '
        'rb1
        '
        Me.rb1.AutoSize = True
        Me.rb1.Checked = True
        Me.rb1.Location = New System.Drawing.Point(495, 34)
        Me.rb1.Name = "rb1"
        Me.rb1.Size = New System.Drawing.Size(79, 19)
        Me.rb1.TabIndex = 79
        Me.rb1.TabStop = True
        Me.rb1.Text = "Stock(s)"
        Me.rb1.UseVisualStyleBackColor = True
        '
        'lblinvnum
        '
        Me.lblinvnum.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblinvnum.AutoSize = True
        Me.lblinvnum.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblinvnum.ForeColor = System.Drawing.Color.ForestGreen
        Me.lblinvnum.Location = New System.Drawing.Point(690, 132)
        Me.lblinvnum.Name = "lblinvnum"
        Me.lblinvnum.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblinvnum.Size = New System.Drawing.Size(36, 18)
        Me.lblinvnum.TabIndex = 6
        Me.lblinvnum.Text = "N/A"
        '
        'lbldatetime
        '
        Me.lbldatetime.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbldatetime.AutoSize = True
        Me.lbldatetime.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldatetime.ForeColor = System.Drawing.SystemColors.ButtonShadow
        Me.lbldatetime.Location = New System.Drawing.Point(796, 157)
        Me.lbldatetime.Name = "lbldatetime"
        Me.lbldatetime.Size = New System.Drawing.Size(121, 12)
        Me.lbldatetime.TabIndex = 7
        Me.lbldatetime.Text = "01/13/2017 08:54 AM"
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DimGray
        Me.Label9.Location = New System.Drawing.Point(778, 110)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(42, 15)
        Me.Label9.TabIndex = 84
        Me.Label9.Text = "Date:"
        '
        'dtinvsearch
        '
        Me.dtinvsearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtinvsearch.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtinvsearch.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtinvsearch.Location = New System.Drawing.Point(826, 106)
        Me.dtinvsearch.Name = "dtinvsearch"
        Me.dtinvsearch.Size = New System.Drawing.Size(91, 23)
        Me.dtinvsearch.TabIndex = 83
        '
        'btnverify
        '
        Me.btnverify.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnverify.BackColor = System.Drawing.Color.ForestGreen
        Me.btnverify.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnverify.FlatAppearance.BorderSize = 0
        Me.btnverify.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnverify.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnverify.ForeColor = System.Drawing.Color.White
        Me.btnverify.Location = New System.Drawing.Point(701, 348)
        Me.btnverify.Name = "btnverify"
        Me.btnverify.Size = New System.Drawing.Size(105, 23)
        Me.btnverify.TabIndex = 85
        Me.btnverify.Text = "Verify"
        Me.btnverify.UseVisualStyleBackColor = False
        '
        'btnrefresh
        '
        Me.btnrefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnrefresh.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnrefresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnrefresh.FlatAppearance.BorderSize = 0
        Me.btnrefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnrefresh.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnrefresh.ForeColor = System.Drawing.Color.White
        Me.btnrefresh.Location = New System.Drawing.Point(812, 348)
        Me.btnrefresh.Name = "btnrefresh"
        Me.btnrefresh.Size = New System.Drawing.Size(105, 23)
        Me.btnrefresh.TabIndex = 86
        Me.btnrefresh.Text = "Refresh"
        Me.btnrefresh.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel1.AutoScroll = True
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.lbltotal)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.lblarsalesamount)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.lblcounteramount)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.lblarchargeamount)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.lbloveramount)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.lblshortamount)
        Me.Panel1.Location = New System.Drawing.Point(24, 348)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(483, 101)
        Me.Panel1.TabIndex = 87
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(224, 64)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(82, 22)
        Me.Label15.TabIndex = 108
        Me.Label15.Text = "TOTAL:"
        '
        'lbltotal
        '
        Me.lbltotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbltotal.AutoSize = True
        Me.lbltotal.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotal.ForeColor = System.Drawing.Color.White
        Me.lbltotal.Location = New System.Drawing.Point(343, 64)
        Me.lbltotal.Name = "lbltotal"
        Me.lbltotal.Size = New System.Drawing.Size(48, 22)
        Me.lbltotal.TabIndex = 109
        Me.lbltotal.Text = "0.00"
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(225, 40)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(108, 14)
        Me.Label17.TabIndex = 110
        Me.Label17.Text = "A.R Sales Amount:"
        '
        'lblarsalesamount
        '
        Me.lblarsalesamount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblarsalesamount.AutoSize = True
        Me.lblarsalesamount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblarsalesamount.ForeColor = System.Drawing.Color.White
        Me.lblarsalesamount.Location = New System.Drawing.Point(354, 40)
        Me.lblarsalesamount.Name = "lblarsalesamount"
        Me.lblarsalesamount.Size = New System.Drawing.Size(28, 14)
        Me.lblarsalesamount.TabIndex = 111
        Me.lblarsalesamount.Text = "0.00"
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(9, 64)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(102, 14)
        Me.Label12.TabIndex = 106
        Me.Label12.Text = "Counter Amount:"
        '
        'lblcounteramount
        '
        Me.lblcounteramount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblcounteramount.AutoSize = True
        Me.lblcounteramount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcounteramount.ForeColor = System.Drawing.Color.White
        Me.lblcounteramount.Location = New System.Drawing.Point(138, 64)
        Me.lblcounteramount.Name = "lblcounteramount"
        Me.lblcounteramount.Size = New System.Drawing.Size(28, 14)
        Me.lblcounteramount.TabIndex = 107
        Me.lblcounteramount.Text = "0.00"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(225, 14)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(118, 14)
        Me.Label10.TabIndex = 104
        Me.Label10.Text = "A.R Charge Amount:"
        '
        'lblarchargeamount
        '
        Me.lblarchargeamount.AutoSize = True
        Me.lblarchargeamount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblarchargeamount.ForeColor = System.Drawing.Color.White
        Me.lblarchargeamount.Location = New System.Drawing.Point(349, 13)
        Me.lblarchargeamount.Name = "lblarchargeamount"
        Me.lblarchargeamount.Size = New System.Drawing.Size(28, 14)
        Me.lblarchargeamount.TabIndex = 105
        Me.lblarchargeamount.Text = "0.00"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(9, 38)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(83, 14)
        Me.Label8.TabIndex = 102
        Me.Label8.Text = "Over Amount:"
        '
        'lbloveramount
        '
        Me.lbloveramount.AutoSize = True
        Me.lbloveramount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbloveramount.ForeColor = System.Drawing.Color.White
        Me.lbloveramount.Location = New System.Drawing.Point(138, 38)
        Me.lbloveramount.Name = "lbloveramount"
        Me.lbloveramount.Size = New System.Drawing.Size(28, 14)
        Me.lbloveramount.TabIndex = 103
        Me.lbloveramount.Text = "0.00"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(9, 13)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(87, 14)
        Me.Label6.TabIndex = 100
        Me.Label6.Text = "Short Amount:"
        Me.Label6.Visible = False
        '
        'lblshortamount
        '
        Me.lblshortamount.AutoSize = True
        Me.lblshortamount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblshortamount.ForeColor = System.Drawing.Color.White
        Me.lblshortamount.Location = New System.Drawing.Point(138, 13)
        Me.lblshortamount.Name = "lblshortamount"
        Me.lblshortamount.Size = New System.Drawing.Size(28, 14)
        Me.lblshortamount.TabIndex = 101
        Me.lblshortamount.Text = "0.00"
        Me.lblshortamount.Visible = False
        '
        'lblnodata
        '
        Me.lblnodata.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblnodata.AutoSize = True
        Me.lblnodata.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblnodata.ForeColor = System.Drawing.Color.DimGray
        Me.lblnodata.Location = New System.Drawing.Point(428, 268)
        Me.lblnodata.Name = "lblnodata"
        Me.lblnodata.Size = New System.Drawing.Size(142, 18)
        Me.lblnodata.TabIndex = 88
        Me.lblnodata.Text = "NO DATA FETCH"
        Me.lblnodata.Visible = False
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.Color.ForestGreen
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(798, 377)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(105, 23)
        Me.Button1.TabIndex = 89
        Me.Button1.Text = "CHECK"
        Me.Button1.UseVisualStyleBackColor = False
        Me.Button1.Visible = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(942, 32)
        Me.Panel2.TabIndex = 90
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Gold
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1, 32)
        Me.Panel3.TabIndex = 91
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(20, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(123, 22)
        Me.Label3.TabIndex = 91
        Me.Label3.Text = "INVENTORY"
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.Panel4.Controls.Add(Me.lblcount)
        Me.Panel4.Location = New System.Drawing.Point(24, 191)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(893, 25)
        Me.Panel4.TabIndex = 92
        '
        'lblcount
        '
        Me.lblcount.AutoSize = True
        Me.lblcount.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcount.ForeColor = System.Drawing.Color.White
        Me.lblcount.Location = New System.Drawing.Point(3, 4)
        Me.lblcount.Name = "lblcount"
        Me.lblcount.Size = New System.Drawing.Size(30, 15)
        Me.lblcount.TabIndex = 82
        Me.lblcount.Text = "N/A"
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.BackColor = System.Drawing.SystemColors.HotTrack
        Me.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPrint.FlatAppearance.BorderSize = 0
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.ForeColor = System.Drawing.Color.White
        Me.btnPrint.Location = New System.Drawing.Point(565, 348)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(130, 23)
        Me.btnPrint.TabIndex = 93
        Me.btnPrint.Text = "Print Inventory"
        Me.btnPrint.UseVisualStyleBackColor = False
        '
        'inv2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(942, 489)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lblnodata)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnrefresh)
        Me.Controls.Add(Me.btnverify)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.dtinvsearch)
        Me.Controls.Add(Me.lbldatetime)
        Me.Controls.Add(Me.lblinvnum)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgv)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "inv2"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inventory"
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgv As DataGridView
    Friend WithEvents cmbcategory As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents rb2 As RadioButton
    Friend WithEvents rb1 As RadioButton
    Friend WithEvents lblinvnum As Label
    Friend WithEvents lbldatetime As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents dtinvsearch As DateTimePicker
    Friend WithEvents btnverify As Button
    Friend WithEvents btnrefresh As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblnodata As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents lbltotal As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents lblarsalesamount As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents lblcounteramount As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents lblarchargeamount As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents lbloveramount As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lblshortamount As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents txtsearch As TextBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents lblcount As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbinventory As ComboBox
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents itemcode As DataGridViewTextBoxColumn
    Friend WithEvents itemname As DataGridViewTextBoxColumn
    Friend WithEvents category As DataGridViewTextBoxColumn
    Friend WithEvents begbal As DataGridViewTextBoxColumn
    Friend WithEvents produce As DataGridViewTextBoxColumn
    Friend WithEvents good As DataGridViewTextBoxColumn
    Friend WithEvents charge As DataGridViewTextBoxColumn
    Friend WithEvents productionin As DataGridViewTextBoxColumn
    Friend WithEvents branchin As DataGridViewTextBoxColumn
    Friend WithEvents supin As DataGridViewTextBoxColumn
    Friend WithEvents adjustmentin As DataGridViewTextBoxColumn
    Friend WithEvents convin As DataGridViewTextBoxColumn
    Friend WithEvents salesin As DataGridViewTextBoxColumn
    Friend WithEvents totalav As DataGridViewTextBoxColumn
    Friend WithEvents transfer As DataGridViewTextBoxColumn
    Friend WithEvents pullout2 As DataGridViewTextBoxColumn
    Friend WithEvents ctrout As DataGridViewTextBoxColumn
    Friend WithEvents archarge As DataGridViewTextBoxColumn
    Friend WithEvents arsales As DataGridViewTextBoxColumn
    Friend WithEvents convout As DataGridViewTextBoxColumn
    Friend WithEvents adjustmentout As DataGridViewTextBoxColumn
    Friend WithEvents salesout As DataGridViewTextBoxColumn
    Friend WithEvents endbal As DataGridViewTextBoxColumn
    Friend WithEvents actualendbal As DataGridViewTextBoxColumn
    Friend WithEvents variance As DataGridViewTextBoxColumn
    Friend WithEvents shortover As DataGridViewTextBoxColumn
    Friend WithEvents overamt As DataGridViewTextBoxColumn
    Friend WithEvents ctrout_amt As DataGridViewTextBoxColumn
    Friend WithEvents archarge_amt As DataGridViewTextBoxColumn
    Friend WithEvents arsales_amt As DataGridViewTextBoxColumn
    Friend WithEvents btnPrint As Button
End Class
