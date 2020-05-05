<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class salessum2
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.lblarcharge = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblcashsales = New System.Windows.Forms.Label()
        Me.lblpaymenttotal = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lblap = New System.Windows.Forms.Label()
        Me.lblarsales = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.lblARCASH = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lblcashtotal = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.lblcashout = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lbldeposit = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblapcash = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblcash = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblgtotal = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmbCashiers = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.datefrom = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dgvhour = New System.Windows.Forms.DataGridView()
        Me.time = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.numtakeout = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.salestakeout = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.numdeliver = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.salesdeliver = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.numarcharge = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.salesarcharge = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.numarcash = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.salesarcash = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.numarsales = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.salesarsales = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.numapcash = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.salesapcash = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.numap = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.salesap = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.numtotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.totalsales = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.lbldailygtotal = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.lbldailyarcharge = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.lbldailycashsales = New System.Windows.Forms.Label()
        Me.lbldailypaymenttotal = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lbldailyap = New System.Windows.Forms.Label()
        Me.lbldailyarsales = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.lbldailyarcash = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.lbldailycashtotal = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.lbldailycashout = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.lbldailydeposit = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.lbldailyapcash = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.lbldailycash = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.dateToDaily = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbCashiers2 = New System.Windows.Forms.ComboBox()
        Me.dateFromDaily = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dgvDaily = New System.Windows.Forms.DataGridView()
        Me.dailydate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dailynumtakeout = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dailysalestakeout = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dailynumdeliver = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dailysalesdeliver = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dailynumarcharge = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dailysalesarcharge = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dailynumarsales = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dailysalesarsales = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dailynumarcash = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dailysalesarcash = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dailynumapcash = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dailysalesapcash = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dailynumap = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dailysalesap = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dailynumtotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dailytotalsales = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.lblyearlygtotal = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.cmbyear = New System.Windows.Forms.ComboBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.lblyearlyarcharge = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.lblyearlycashsales = New System.Windows.Forms.Label()
        Me.lblyearlypaymenttotal = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.lblyearlyap = New System.Windows.Forms.Label()
        Me.lblyearlyarsales = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.lblyearlyarcash = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.lblyearlycashtotal = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.lblyearlycashout = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.lblyearlydeposit = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.lblyearlyapcash = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.lblyearlycash = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.cmbCashiers3 = New System.Windows.Forms.ComboBox()
        Me.dgvyearly = New System.Windows.Forms.DataGridView()
        Me.yearlymonth = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.yearlynumtakeout = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.yearlysalestakeout = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.yearlynumdeliver = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.yearlysalesdeliver = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.yearlynumarcharge = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.yearlysalesarcharge = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.yearlynumarsales = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.yearlysalesarsales = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.yearlynumarcash = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.yearlysalesarcash = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.yearlynumapcash = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.yearlysalesapcash = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.yearlynumap = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.yearlysalesap = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.yearlynumtotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.yearlytotalsales = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvhour, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.dgvDaily, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel6.SuspendLayout()
        CType(Me.dgvyearly, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(25, 23)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(974, 532)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Panel2)
        Me.TabPage1.Controls.Add(Me.Panel1)
        Me.TabPage1.Controls.Add(Me.lblgtotal)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.cmbCashiers)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.datefrom)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.dgvhour)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(966, 506)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Hourly Sales"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Label30)
        Me.Panel2.Controls.Add(Me.lblarcharge)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.lblcashsales)
        Me.Panel2.Controls.Add(Me.lblpaymenttotal)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.Label18)
        Me.Panel2.Controls.Add(Me.lblap)
        Me.Panel2.Controls.Add(Me.lblarsales)
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Location = New System.Drawing.Point(595, 365)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(351, 98)
        Me.Panel2.TabIndex = 66
        '
        'Label30
        '
        Me.Label30.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.White
        Me.Label30.Location = New System.Drawing.Point(14, 14)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(79, 14)
        Me.Label30.TabIndex = 97
        Me.Label30.Text = "A.R Charge:"
        '
        'lblarcharge
        '
        Me.lblarcharge.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblarcharge.AutoSize = True
        Me.lblarcharge.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblarcharge.ForeColor = System.Drawing.Color.LimeGreen
        Me.lblarcharge.Location = New System.Drawing.Point(201, 14)
        Me.lblarcharge.Name = "lblarcharge"
        Me.lblarcharge.Size = New System.Drawing.Size(39, 14)
        Me.lblarcharge.TabIndex = 98
        Me.lblarcharge.Text = "00.00"
        '
        'Label5
        '
        Me.Label5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(14, 31)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 14)
        Me.Label5.TabIndex = 95
        Me.Label5.Text = "Cash Sales:"
        '
        'lblcashsales
        '
        Me.lblcashsales.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblcashsales.AutoSize = True
        Me.lblcashsales.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcashsales.ForeColor = System.Drawing.Color.LimeGreen
        Me.lblcashsales.Location = New System.Drawing.Point(201, 31)
        Me.lblcashsales.Name = "lblcashsales"
        Me.lblcashsales.Size = New System.Drawing.Size(39, 14)
        Me.lblcashsales.TabIndex = 96
        Me.lblcashsales.Text = "00.00"
        '
        'lblpaymenttotal
        '
        Me.lblpaymenttotal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblpaymenttotal.AutoSize = True
        Me.lblpaymenttotal.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblpaymenttotal.ForeColor = System.Drawing.Color.LimeGreen
        Me.lblpaymenttotal.Location = New System.Drawing.Point(201, 75)
        Me.lblpaymenttotal.Name = "lblpaymenttotal"
        Me.lblpaymenttotal.Size = New System.Drawing.Size(53, 18)
        Me.lblpaymenttotal.TabIndex = 94
        Me.lblpaymenttotal.Text = "00.00"
        '
        'Label8
        '
        Me.Label8.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(14, 75)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(127, 18)
        Me.Label8.TabIndex = 93
        Me.Label8.Text = "SALES TOTAL:"
        '
        'Label18
        '
        Me.Label18.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(14, 47)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(68, 14)
        Me.Label18.TabIndex = 89
        Me.Label18.Text = "A.R Sales:"
        '
        'lblap
        '
        Me.lblap.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblap.AutoSize = True
        Me.lblap.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblap.ForeColor = System.Drawing.Color.LimeGreen
        Me.lblap.Location = New System.Drawing.Point(201, 61)
        Me.lblap.Name = "lblap"
        Me.lblap.Size = New System.Drawing.Size(39, 14)
        Me.lblap.TabIndex = 92
        Me.lblap.Text = "00.00"
        '
        'lblarsales
        '
        Me.lblarsales.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblarsales.AutoSize = True
        Me.lblarsales.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblarsales.ForeColor = System.Drawing.Color.LimeGreen
        Me.lblarsales.Location = New System.Drawing.Point(201, 47)
        Me.lblarsales.Name = "lblarsales"
        Me.lblarsales.Size = New System.Drawing.Size(39, 14)
        Me.lblarsales.TabIndex = 90
        Me.lblarsales.Text = "00.00"
        '
        'Label13
        '
        Me.Label13.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(14, 61)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(135, 14)
        Me.Label13.TabIndex = 91
        Me.Label13.Text = "ADVANCE PAYMENT:"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label38)
        Me.Panel1.Controls.Add(Me.lblARCASH)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.lblcashtotal)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.lblcashout)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.lbldeposit)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.lblapcash)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.lblcash)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Location = New System.Drawing.Point(28, 363)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(390, 100)
        Me.Panel1.TabIndex = 65
        '
        'Label38
        '
        Me.Label38.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.ForeColor = System.Drawing.Color.Firebrick
        Me.Label38.Location = New System.Drawing.Point(173, 63)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(11, 14)
        Me.Label38.TabIndex = 89
        Me.Label38.Text = "-"
        '
        'lblARCASH
        '
        Me.lblARCASH.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblARCASH.AutoSize = True
        Me.lblARCASH.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblARCASH.ForeColor = System.Drawing.Color.LimeGreen
        Me.lblARCASH.Location = New System.Drawing.Point(190, 6)
        Me.lblARCASH.Name = "lblARCASH"
        Me.lblARCASH.Size = New System.Drawing.Size(39, 14)
        Me.lblARCASH.TabIndex = 88
        Me.lblARCASH.Text = "00.00"
        '
        'Label17
        '
        Me.Label17.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(4, 20)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(41, 14)
        Me.Label17.TabIndex = 87
        Me.Label17.Text = "Cash:"
        '
        'lblcashtotal
        '
        Me.lblcashtotal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblcashtotal.AutoSize = True
        Me.lblcashtotal.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcashtotal.ForeColor = System.Drawing.Color.LimeGreen
        Me.lblcashtotal.Location = New System.Drawing.Point(190, 77)
        Me.lblcashtotal.Name = "lblcashtotal"
        Me.lblcashtotal.Size = New System.Drawing.Size(53, 18)
        Me.lblcashtotal.TabIndex = 86
        Me.lblcashtotal.Text = "00.00"
        '
        'Label16
        '
        Me.Label16.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(3, 77)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(119, 18)
        Me.Label16.TabIndex = 85
        Me.Label16.Text = "CASH TOTAL:"
        '
        'lblcashout
        '
        Me.lblcashout.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblcashout.AutoSize = True
        Me.lblcashout.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcashout.ForeColor = System.Drawing.Color.Firebrick
        Me.lblcashout.Location = New System.Drawing.Point(190, 63)
        Me.lblcashout.Name = "lblcashout"
        Me.lblcashout.Size = New System.Drawing.Size(39, 14)
        Me.lblcashout.TabIndex = 84
        Me.lblcashout.Text = "00.00"
        '
        'Label12
        '
        Me.Label12.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(3, 63)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(71, 14)
        Me.Label12.TabIndex = 83
        Me.Label12.Text = "Cash OUT:"
        '
        'lbldeposit
        '
        Me.lbldeposit.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbldeposit.AutoSize = True
        Me.lbldeposit.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldeposit.ForeColor = System.Drawing.Color.LimeGreen
        Me.lbldeposit.Location = New System.Drawing.Point(190, 49)
        Me.lbldeposit.Name = "lbldeposit"
        Me.lbldeposit.Size = New System.Drawing.Size(39, 14)
        Me.lbldeposit.TabIndex = 82
        Me.lbldeposit.Text = "00.00"
        '
        'Label14
        '
        Me.Label14.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(3, 49)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(56, 14)
        Me.Label14.TabIndex = 81
        Me.Label14.Text = "Deposit:"
        '
        'lblapcash
        '
        Me.lblapcash.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblapcash.AutoSize = True
        Me.lblapcash.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblapcash.ForeColor = System.Drawing.Color.LimeGreen
        Me.lblapcash.Location = New System.Drawing.Point(190, 34)
        Me.lblapcash.Name = "lblapcash"
        Me.lblapcash.Size = New System.Drawing.Size(39, 14)
        Me.lblapcash.TabIndex = 80
        Me.lblapcash.Text = "00.00"
        '
        'Label10
        '
        Me.Label10.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(4, 34)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(150, 14)
        Me.Label10.TabIndex = 79
        Me.Label10.Text = "Advance Payment Cash:"
        '
        'lblcash
        '
        Me.lblcash.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblcash.AutoSize = True
        Me.lblcash.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcash.ForeColor = System.Drawing.Color.LimeGreen
        Me.lblcash.Location = New System.Drawing.Point(190, 20)
        Me.lblcash.Name = "lblcash"
        Me.lblcash.Size = New System.Drawing.Size(39, 14)
        Me.lblcash.TabIndex = 78
        Me.lblcash.Text = "00.00"
        '
        'Label7
        '
        Me.Label7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(4, 6)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 14)
        Me.Label7.TabIndex = 77
        Me.Label7.Text = "A.R Cash:"
        '
        'lblgtotal
        '
        Me.lblgtotal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblgtotal.AutoSize = True
        Me.lblgtotal.Font = New System.Drawing.Font("Arial Rounded MT Bold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblgtotal.ForeColor = System.Drawing.Color.Red
        Me.lblgtotal.Location = New System.Drawing.Point(164, 472)
        Me.lblgtotal.Name = "lblgtotal"
        Me.lblgtotal.Size = New System.Drawing.Size(65, 24)
        Me.lblgtotal.TabIndex = 2
        Me.lblgtotal.Text = "00.00"
        Me.lblgtotal.Visible = False
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(666, 18)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(54, 15)
        Me.Label9.TabIndex = 64
        Me.Label9.Text = "Cashier:"
        '
        'cmbCashiers
        '
        Me.cmbCashiers.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbCashiers.BackColor = System.Drawing.Color.DodgerBlue
        Me.cmbCashiers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCashiers.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbCashiers.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCashiers.ForeColor = System.Drawing.Color.White
        Me.cmbCashiers.FormattingEnabled = True
        Me.cmbCashiers.Location = New System.Drawing.Point(726, 13)
        Me.cmbCashiers.Name = "cmbCashiers"
        Me.cmbCashiers.Size = New System.Drawing.Size(220, 26)
        Me.cmbCashiers.TabIndex = 63
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(25, 475)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(133, 18)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "GRAND TOTAL:"
        Me.Label1.Visible = False
        '
        'datefrom
        '
        Me.datefrom.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.datefrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.datefrom.Location = New System.Drawing.Point(78, 18)
        Me.datefrom.MinDate = New Date(2017, 1, 1, 0, 0, 0, 0)
        Me.datefrom.Name = "datefrom"
        Me.datefrom.Size = New System.Drawing.Size(166, 21)
        Me.datefrom.TabIndex = 59
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(36, 23)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(36, 15)
        Me.Label6.TabIndex = 61
        Me.Label6.Text = "Date:"
        '
        'dgvhour
        '
        Me.dgvhour.AllowUserToAddRows = False
        Me.dgvhour.AllowUserToDeleteRows = False
        Me.dgvhour.AllowUserToResizeColumns = False
        Me.dgvhour.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvhour.BackgroundColor = System.Drawing.Color.White
        Me.dgvhour.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvhour.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvhour.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvhour.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvhour.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.time, Me.numtakeout, Me.salestakeout, Me.numdeliver, Me.salesdeliver, Me.numarcharge, Me.salesarcharge, Me.numarcash, Me.salesarcash, Me.numarsales, Me.salesarsales, Me.numapcash, Me.salesapcash, Me.numap, Me.salesap, Me.numtotal, Me.totalsales})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvhour.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvhour.EnableHeadersVisualStyles = False
        Me.dgvhour.GridColor = System.Drawing.Color.White
        Me.dgvhour.Location = New System.Drawing.Point(28, 58)
        Me.dgvhour.Name = "dgvhour"
        Me.dgvhour.ReadOnly = True
        Me.dgvhour.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvhour.RowHeadersVisible = False
        Me.dgvhour.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvhour.Size = New System.Drawing.Size(918, 301)
        Me.dgvhour.TabIndex = 0
        '
        'time
        '
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Coral
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        Me.time.DefaultCellStyle = DataGridViewCellStyle2
        Me.time.HeaderText = "Time"
        Me.time.Name = "time"
        Me.time.ReadOnly = True
        '
        'numtakeout
        '
        Me.numtakeout.HeaderText = "No. of Transaction (Take Out)"
        Me.numtakeout.Name = "numtakeout"
        Me.numtakeout.ReadOnly = True
        '
        'salestakeout
        '
        Me.salestakeout.HeaderText = "Sales Amount (Take Out)"
        Me.salestakeout.Name = "salestakeout"
        Me.salestakeout.ReadOnly = True
        '
        'numdeliver
        '
        Me.numdeliver.HeaderText = "No. of Transaction (Deliver)"
        Me.numdeliver.Name = "numdeliver"
        Me.numdeliver.ReadOnly = True
        '
        'salesdeliver
        '
        Me.salesdeliver.HeaderText = "Sales Amount (Deliver)"
        Me.salesdeliver.Name = "salesdeliver"
        Me.salesdeliver.ReadOnly = True
        '
        'numarcharge
        '
        Me.numarcharge.HeaderText = "No. of Transaction (A.R Charge)"
        Me.numarcharge.Name = "numarcharge"
        Me.numarcharge.ReadOnly = True
        '
        'salesarcharge
        '
        Me.salesarcharge.HeaderText = "Sales Amount (A.R Charge)"
        Me.salesarcharge.Name = "salesarcharge"
        Me.salesarcharge.ReadOnly = True
        '
        'numarcash
        '
        Me.numarcash.HeaderText = "No. of Transaction (A.R Cash)"
        Me.numarcash.Name = "numarcash"
        Me.numarcash.ReadOnly = True
        '
        'salesarcash
        '
        Me.salesarcash.HeaderText = "Sales Amount (A.R Cash)"
        Me.salesarcash.Name = "salesarcash"
        Me.salesarcash.ReadOnly = True
        '
        'numarsales
        '
        Me.numarsales.HeaderText = "No. of Transaction (A.R Sales)"
        Me.numarsales.Name = "numarsales"
        Me.numarsales.ReadOnly = True
        '
        'salesarsales
        '
        Me.salesarsales.HeaderText = "Sales Amount (A.R Sales)"
        Me.salesarsales.Name = "salesarsales"
        Me.salesarsales.ReadOnly = True
        '
        'numapcash
        '
        Me.numapcash.HeaderText = "No. of Transaction (Advance Payment Cash)"
        Me.numapcash.Name = "numapcash"
        Me.numapcash.ReadOnly = True
        '
        'salesapcash
        '
        Me.salesapcash.HeaderText = "Sales Amount (Advance Payment Cash)"
        Me.salesapcash.Name = "salesapcash"
        Me.salesapcash.ReadOnly = True
        '
        'numap
        '
        Me.numap.HeaderText = "No. of Transaction (Advance Payment)"
        Me.numap.Name = "numap"
        Me.numap.ReadOnly = True
        '
        'salesap
        '
        Me.salesap.HeaderText = "Sales Amount (Advance Payment)"
        Me.salesap.Name = "salesap"
        Me.salesap.ReadOnly = True
        '
        'numtotal
        '
        Me.numtotal.HeaderText = "No. of Transaction"
        Me.numtotal.Name = "numtotal"
        Me.numtotal.ReadOnly = True
        '
        'totalsales
        '
        Me.totalsales.HeaderText = "Total Sales Amount"
        Me.totalsales.Name = "totalsales"
        Me.totalsales.ReadOnly = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.lbldailygtotal)
        Me.TabPage2.Controls.Add(Me.Label19)
        Me.TabPage2.Controls.Add(Me.Panel3)
        Me.TabPage2.Controls.Add(Me.Panel4)
        Me.TabPage2.Controls.Add(Me.dateToDaily)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.cmbCashiers2)
        Me.TabPage2.Controls.Add(Me.dateFromDaily)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.dgvDaily)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(966, 506)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Daily Sales"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'lbldailygtotal
        '
        Me.lbldailygtotal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbldailygtotal.AutoSize = True
        Me.lbldailygtotal.Font = New System.Drawing.Font("Arial Rounded MT Bold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldailygtotal.ForeColor = System.Drawing.Color.Red
        Me.lbldailygtotal.Location = New System.Drawing.Point(164, 472)
        Me.lbldailygtotal.Name = "lbldailygtotal"
        Me.lbldailygtotal.Size = New System.Drawing.Size(65, 24)
        Me.lbldailygtotal.TabIndex = 74
        Me.lbldailygtotal.Text = "00.00"
        Me.lbldailygtotal.Visible = False
        '
        'Label19
        '
        Me.Label19.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Red
        Me.Label19.Location = New System.Drawing.Point(25, 475)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(133, 18)
        Me.Label19.TabIndex = 73
        Me.Label19.Text = "GRAND TOTAL:"
        Me.Label19.Visible = False
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.Panel3.Controls.Add(Me.Label34)
        Me.Panel3.Controls.Add(Me.lbldailyarcharge)
        Me.Panel3.Controls.Add(Me.Label26)
        Me.Panel3.Controls.Add(Me.lbldailycashsales)
        Me.Panel3.Controls.Add(Me.lbldailypaymenttotal)
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Controls.Add(Me.Label15)
        Me.Panel3.Controls.Add(Me.lbldailyap)
        Me.Panel3.Controls.Add(Me.lbldailyarsales)
        Me.Panel3.Controls.Add(Me.Label21)
        Me.Panel3.Location = New System.Drawing.Point(595, 365)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(351, 98)
        Me.Panel3.TabIndex = 72
        '
        'Label34
        '
        Me.Label34.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.Color.White
        Me.Label34.Location = New System.Drawing.Point(14, 12)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(79, 14)
        Me.Label34.TabIndex = 97
        Me.Label34.Text = "A.R Charge:"
        '
        'lbldailyarcharge
        '
        Me.lbldailyarcharge.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbldailyarcharge.AutoSize = True
        Me.lbldailyarcharge.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldailyarcharge.ForeColor = System.Drawing.Color.LimeGreen
        Me.lbldailyarcharge.Location = New System.Drawing.Point(201, 12)
        Me.lbldailyarcharge.Name = "lbldailyarcharge"
        Me.lbldailyarcharge.Size = New System.Drawing.Size(39, 14)
        Me.lbldailyarcharge.TabIndex = 98
        Me.lbldailyarcharge.Text = "00.00"
        '
        'Label26
        '
        Me.Label26.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.White
        Me.Label26.Location = New System.Drawing.Point(14, 29)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(76, 14)
        Me.Label26.TabIndex = 95
        Me.Label26.Text = "Cash Sales:"
        '
        'lbldailycashsales
        '
        Me.lbldailycashsales.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbldailycashsales.AutoSize = True
        Me.lbldailycashsales.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldailycashsales.ForeColor = System.Drawing.Color.LimeGreen
        Me.lbldailycashsales.Location = New System.Drawing.Point(201, 29)
        Me.lbldailycashsales.Name = "lbldailycashsales"
        Me.lbldailycashsales.Size = New System.Drawing.Size(39, 14)
        Me.lbldailycashsales.TabIndex = 96
        Me.lbldailycashsales.Text = "00.00"
        '
        'lbldailypaymenttotal
        '
        Me.lbldailypaymenttotal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbldailypaymenttotal.AutoSize = True
        Me.lbldailypaymenttotal.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldailypaymenttotal.ForeColor = System.Drawing.Color.LimeGreen
        Me.lbldailypaymenttotal.Location = New System.Drawing.Point(201, 75)
        Me.lbldailypaymenttotal.Name = "lbldailypaymenttotal"
        Me.lbldailypaymenttotal.Size = New System.Drawing.Size(53, 18)
        Me.lbldailypaymenttotal.TabIndex = 94
        Me.lbldailypaymenttotal.Text = "00.00"
        '
        'Label11
        '
        Me.Label11.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(14, 75)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(127, 18)
        Me.Label11.TabIndex = 93
        Me.Label11.Text = "SALES TOTAL:"
        '
        'Label15
        '
        Me.Label15.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(14, 46)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(68, 14)
        Me.Label15.TabIndex = 89
        Me.Label15.Text = "A.R Sales:"
        '
        'lbldailyap
        '
        Me.lbldailyap.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbldailyap.AutoSize = True
        Me.lbldailyap.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldailyap.ForeColor = System.Drawing.Color.LimeGreen
        Me.lbldailyap.Location = New System.Drawing.Point(201, 61)
        Me.lbldailyap.Name = "lbldailyap"
        Me.lbldailyap.Size = New System.Drawing.Size(39, 14)
        Me.lbldailyap.TabIndex = 92
        Me.lbldailyap.Text = "00.00"
        '
        'lbldailyarsales
        '
        Me.lbldailyarsales.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbldailyarsales.AutoSize = True
        Me.lbldailyarsales.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldailyarsales.ForeColor = System.Drawing.Color.LimeGreen
        Me.lbldailyarsales.Location = New System.Drawing.Point(201, 46)
        Me.lbldailyarsales.Name = "lbldailyarsales"
        Me.lbldailyarsales.Size = New System.Drawing.Size(39, 14)
        Me.lbldailyarsales.TabIndex = 90
        Me.lbldailyarsales.Text = "00.00"
        '
        'Label21
        '
        Me.Label21.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.White
        Me.Label21.Location = New System.Drawing.Point(14, 61)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(135, 14)
        Me.Label21.TabIndex = 91
        Me.Label21.Text = "ADVANCE PAYMENT:"
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.Panel4.Controls.Add(Me.Label46)
        Me.Panel4.Controls.Add(Me.lbldailyarcash)
        Me.Panel4.Controls.Add(Me.Label23)
        Me.Panel4.Controls.Add(Me.lbldailycashtotal)
        Me.Panel4.Controls.Add(Me.Label25)
        Me.Panel4.Controls.Add(Me.lbldailycashout)
        Me.Panel4.Controls.Add(Me.Label27)
        Me.Panel4.Controls.Add(Me.lbldailydeposit)
        Me.Panel4.Controls.Add(Me.Label29)
        Me.Panel4.Controls.Add(Me.lbldailyapcash)
        Me.Panel4.Controls.Add(Me.Label31)
        Me.Panel4.Controls.Add(Me.lbldailycash)
        Me.Panel4.Controls.Add(Me.Label33)
        Me.Panel4.Location = New System.Drawing.Point(28, 363)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(390, 100)
        Me.Panel4.TabIndex = 71
        '
        'Label46
        '
        Me.Label46.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label46.AutoSize = True
        Me.Label46.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label46.ForeColor = System.Drawing.Color.Firebrick
        Me.Label46.Location = New System.Drawing.Point(173, 63)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(11, 14)
        Me.Label46.TabIndex = 89
        Me.Label46.Text = "-"
        '
        'lbldailyarcash
        '
        Me.lbldailyarcash.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbldailyarcash.AutoSize = True
        Me.lbldailyarcash.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldailyarcash.ForeColor = System.Drawing.Color.LimeGreen
        Me.lbldailyarcash.Location = New System.Drawing.Point(190, 6)
        Me.lbldailyarcash.Name = "lbldailyarcash"
        Me.lbldailyarcash.Size = New System.Drawing.Size(39, 14)
        Me.lbldailyarcash.TabIndex = 88
        Me.lbldailyarcash.Text = "00.00"
        '
        'Label23
        '
        Me.Label23.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.White
        Me.Label23.Location = New System.Drawing.Point(4, 20)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(41, 14)
        Me.Label23.TabIndex = 87
        Me.Label23.Text = "Cash:"
        '
        'lbldailycashtotal
        '
        Me.lbldailycashtotal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbldailycashtotal.AutoSize = True
        Me.lbldailycashtotal.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldailycashtotal.ForeColor = System.Drawing.Color.LimeGreen
        Me.lbldailycashtotal.Location = New System.Drawing.Point(190, 77)
        Me.lbldailycashtotal.Name = "lbldailycashtotal"
        Me.lbldailycashtotal.Size = New System.Drawing.Size(53, 18)
        Me.lbldailycashtotal.TabIndex = 86
        Me.lbldailycashtotal.Text = "00.00"
        '
        'Label25
        '
        Me.Label25.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.White
        Me.Label25.Location = New System.Drawing.Point(3, 77)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(119, 18)
        Me.Label25.TabIndex = 85
        Me.Label25.Text = "CASH TOTAL:"
        '
        'lbldailycashout
        '
        Me.lbldailycashout.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbldailycashout.AutoSize = True
        Me.lbldailycashout.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldailycashout.ForeColor = System.Drawing.Color.Firebrick
        Me.lbldailycashout.Location = New System.Drawing.Point(190, 63)
        Me.lbldailycashout.Name = "lbldailycashout"
        Me.lbldailycashout.Size = New System.Drawing.Size(39, 14)
        Me.lbldailycashout.TabIndex = 84
        Me.lbldailycashout.Text = "00.00"
        '
        'Label27
        '
        Me.Label27.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.White
        Me.Label27.Location = New System.Drawing.Point(3, 63)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(71, 14)
        Me.Label27.TabIndex = 83
        Me.Label27.Text = "Cash OUT:"
        '
        'lbldailydeposit
        '
        Me.lbldailydeposit.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbldailydeposit.AutoSize = True
        Me.lbldailydeposit.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldailydeposit.ForeColor = System.Drawing.Color.LimeGreen
        Me.lbldailydeposit.Location = New System.Drawing.Point(190, 49)
        Me.lbldailydeposit.Name = "lbldailydeposit"
        Me.lbldailydeposit.Size = New System.Drawing.Size(39, 14)
        Me.lbldailydeposit.TabIndex = 82
        Me.lbldailydeposit.Text = "00.00"
        '
        'Label29
        '
        Me.Label29.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.White
        Me.Label29.Location = New System.Drawing.Point(3, 49)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(56, 14)
        Me.Label29.TabIndex = 81
        Me.Label29.Text = "Deposit:"
        '
        'lbldailyapcash
        '
        Me.lbldailyapcash.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbldailyapcash.AutoSize = True
        Me.lbldailyapcash.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldailyapcash.ForeColor = System.Drawing.Color.LimeGreen
        Me.lbldailyapcash.Location = New System.Drawing.Point(190, 34)
        Me.lbldailyapcash.Name = "lbldailyapcash"
        Me.lbldailyapcash.Size = New System.Drawing.Size(39, 14)
        Me.lbldailyapcash.TabIndex = 80
        Me.lbldailyapcash.Text = "00.00"
        '
        'Label31
        '
        Me.Label31.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.ForeColor = System.Drawing.Color.White
        Me.Label31.Location = New System.Drawing.Point(4, 34)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(150, 14)
        Me.Label31.TabIndex = 79
        Me.Label31.Text = "Advance Payment Cash:"
        '
        'lbldailycash
        '
        Me.lbldailycash.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbldailycash.AutoSize = True
        Me.lbldailycash.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldailycash.ForeColor = System.Drawing.Color.LimeGreen
        Me.lbldailycash.Location = New System.Drawing.Point(190, 20)
        Me.lbldailycash.Name = "lbldailycash"
        Me.lbldailycash.Size = New System.Drawing.Size(39, 14)
        Me.lbldailycash.TabIndex = 78
        Me.lbldailycash.Text = "00.00"
        '
        'Label33
        '
        Me.Label33.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.White
        Me.Label33.Location = New System.Drawing.Point(4, 6)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(66, 14)
        Me.Label33.TabIndex = 77
        Me.Label33.Text = "A.R Cash:"
        '
        'dateToDaily
        '
        Me.dateToDaily.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dateToDaily.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dateToDaily.Location = New System.Drawing.Point(346, 18)
        Me.dateToDaily.MinDate = New Date(2017, 1, 1, 0, 0, 0, 0)
        Me.dateToDaily.Name = "dateToDaily"
        Me.dateToDaily.Size = New System.Drawing.Size(166, 21)
        Me.dateToDaily.TabIndex = 69
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(288, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 15)
        Me.Label4.TabIndex = 70
        Me.Label4.Text = "Date To:"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(666, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 15)
        Me.Label2.TabIndex = 68
        Me.Label2.Text = "Cashier:"
        '
        'cmbCashiers2
        '
        Me.cmbCashiers2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbCashiers2.BackColor = System.Drawing.Color.DodgerBlue
        Me.cmbCashiers2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCashiers2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbCashiers2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCashiers2.ForeColor = System.Drawing.Color.White
        Me.cmbCashiers2.FormattingEnabled = True
        Me.cmbCashiers2.Location = New System.Drawing.Point(726, 13)
        Me.cmbCashiers2.Name = "cmbCashiers2"
        Me.cmbCashiers2.Size = New System.Drawing.Size(220, 26)
        Me.cmbCashiers2.TabIndex = 67
        '
        'dateFromDaily
        '
        Me.dateFromDaily.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dateFromDaily.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dateFromDaily.Location = New System.Drawing.Point(114, 18)
        Me.dateFromDaily.MinDate = New Date(2017, 1, 1, 0, 0, 0, 0)
        Me.dateFromDaily.Name = "dateFromDaily"
        Me.dateFromDaily.Size = New System.Drawing.Size(166, 21)
        Me.dateFromDaily.TabIndex = 65
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(36, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 15)
        Me.Label3.TabIndex = 66
        Me.Label3.Text = "Date From:"
        '
        'dgvDaily
        '
        Me.dgvDaily.AllowUserToAddRows = False
        Me.dgvDaily.AllowUserToDeleteRows = False
        Me.dgvDaily.AllowUserToResizeColumns = False
        Me.dgvDaily.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDaily.BackgroundColor = System.Drawing.Color.White
        Me.dgvDaily.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvDaily.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dgvDaily.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDaily.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dailydate, Me.dailynumtakeout, Me.dailysalestakeout, Me.dailynumdeliver, Me.dailysalesdeliver, Me.dailynumarcharge, Me.dailysalesarcharge, Me.dailynumarsales, Me.dailysalesarsales, Me.dailynumarcash, Me.dailysalesarcash, Me.dailynumapcash, Me.dailysalesapcash, Me.dailynumap, Me.dailysalesap, Me.dailynumtotal, Me.dailytotalsales})
        Me.dgvDaily.EnableHeadersVisualStyles = False
        Me.dgvDaily.GridColor = System.Drawing.Color.White
        Me.dgvDaily.Location = New System.Drawing.Point(28, 58)
        Me.dgvDaily.Name = "dgvDaily"
        Me.dgvDaily.ReadOnly = True
        Me.dgvDaily.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvDaily.RowHeadersVisible = False
        Me.dgvDaily.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDaily.Size = New System.Drawing.Size(918, 294)
        Me.dgvDaily.TabIndex = 1
        '
        'dailydate
        '
        Me.dailydate.HeaderText = "Date"
        Me.dailydate.Name = "dailydate"
        Me.dailydate.ReadOnly = True
        '
        'dailynumtakeout
        '
        Me.dailynumtakeout.HeaderText = "No. of Transaction (Take Out)"
        Me.dailynumtakeout.Name = "dailynumtakeout"
        Me.dailynumtakeout.ReadOnly = True
        '
        'dailysalestakeout
        '
        Me.dailysalestakeout.HeaderText = "Sales Amount (Take Out)"
        Me.dailysalestakeout.Name = "dailysalestakeout"
        Me.dailysalestakeout.ReadOnly = True
        '
        'dailynumdeliver
        '
        Me.dailynumdeliver.HeaderText = "No. of Transaction (Deliver)"
        Me.dailynumdeliver.Name = "dailynumdeliver"
        Me.dailynumdeliver.ReadOnly = True
        '
        'dailysalesdeliver
        '
        Me.dailysalesdeliver.HeaderText = "Sales Amount (Deliver)"
        Me.dailysalesdeliver.Name = "dailysalesdeliver"
        Me.dailysalesdeliver.ReadOnly = True
        '
        'dailynumarcharge
        '
        Me.dailynumarcharge.HeaderText = "No. of Transaction (A.R Charge)"
        Me.dailynumarcharge.Name = "dailynumarcharge"
        Me.dailynumarcharge.ReadOnly = True
        '
        'dailysalesarcharge
        '
        Me.dailysalesarcharge.HeaderText = "Sales Amount (A.R Charge"
        Me.dailysalesarcharge.Name = "dailysalesarcharge"
        Me.dailysalesarcharge.ReadOnly = True
        '
        'dailynumarsales
        '
        Me.dailynumarsales.HeaderText = "No. of Transaction (A.R Sales)"
        Me.dailynumarsales.Name = "dailynumarsales"
        Me.dailynumarsales.ReadOnly = True
        '
        'dailysalesarsales
        '
        Me.dailysalesarsales.HeaderText = "Sales Amount (A.R Sales)"
        Me.dailysalesarsales.Name = "dailysalesarsales"
        Me.dailysalesarsales.ReadOnly = True
        '
        'dailynumarcash
        '
        Me.dailynumarcash.HeaderText = "No. of Transaction (A.R Cash)"
        Me.dailynumarcash.Name = "dailynumarcash"
        Me.dailynumarcash.ReadOnly = True
        '
        'dailysalesarcash
        '
        Me.dailysalesarcash.HeaderText = "Sales Amount (A.R Cash)"
        Me.dailysalesarcash.Name = "dailysalesarcash"
        Me.dailysalesarcash.ReadOnly = True
        '
        'dailynumapcash
        '
        Me.dailynumapcash.HeaderText = "No. of Transaction (Advance Payment Cash)"
        Me.dailynumapcash.Name = "dailynumapcash"
        Me.dailynumapcash.ReadOnly = True
        '
        'dailysalesapcash
        '
        Me.dailysalesapcash.HeaderText = "Sales Amount (Advance Payment Cash)"
        Me.dailysalesapcash.Name = "dailysalesapcash"
        Me.dailysalesapcash.ReadOnly = True
        '
        'dailynumap
        '
        Me.dailynumap.HeaderText = "No. of Transaction (Advance Payment)"
        Me.dailynumap.Name = "dailynumap"
        Me.dailynumap.ReadOnly = True
        '
        'dailysalesap
        '
        Me.dailysalesap.HeaderText = "Sales Amount (Advance Payment)"
        Me.dailysalesap.Name = "dailysalesap"
        Me.dailysalesap.ReadOnly = True
        '
        'dailynumtotal
        '
        Me.dailynumtotal.HeaderText = "No. of Transaction"
        Me.dailynumtotal.Name = "dailynumtotal"
        Me.dailynumtotal.ReadOnly = True
        '
        'dailytotalsales
        '
        Me.dailytotalsales.HeaderText = "Total Sales Amount"
        Me.dailytotalsales.Name = "dailytotalsales"
        Me.dailytotalsales.ReadOnly = True
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.lblyearlygtotal)
        Me.TabPage3.Controls.Add(Me.Label24)
        Me.TabPage3.Controls.Add(Me.Label45)
        Me.TabPage3.Controls.Add(Me.cmbyear)
        Me.TabPage3.Controls.Add(Me.Panel5)
        Me.TabPage3.Controls.Add(Me.Panel6)
        Me.TabPage3.Controls.Add(Me.Label44)
        Me.TabPage3.Controls.Add(Me.cmbCashiers3)
        Me.TabPage3.Controls.Add(Me.dgvyearly)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(966, 506)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Monthly Sales"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'lblyearlygtotal
        '
        Me.lblyearlygtotal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblyearlygtotal.AutoSize = True
        Me.lblyearlygtotal.Font = New System.Drawing.Font("Arial Rounded MT Bold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblyearlygtotal.ForeColor = System.Drawing.Color.Red
        Me.lblyearlygtotal.Location = New System.Drawing.Point(164, 472)
        Me.lblyearlygtotal.Name = "lblyearlygtotal"
        Me.lblyearlygtotal.Size = New System.Drawing.Size(65, 24)
        Me.lblyearlygtotal.TabIndex = 81
        Me.lblyearlygtotal.Text = "00.00"
        Me.lblyearlygtotal.Visible = False
        '
        'Label24
        '
        Me.Label24.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.Red
        Me.Label24.Location = New System.Drawing.Point(25, 475)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(133, 18)
        Me.Label24.TabIndex = 80
        Me.Label24.Text = "GRAND TOTAL:"
        Me.Label24.Visible = False
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.Location = New System.Drawing.Point(36, 23)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(35, 15)
        Me.Label45.TabIndex = 79
        Me.Label45.Text = "Year:"
        '
        'cmbyear
        '
        Me.cmbyear.BackColor = System.Drawing.Color.DodgerBlue
        Me.cmbyear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbyear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbyear.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbyear.ForeColor = System.Drawing.Color.White
        Me.cmbyear.FormattingEnabled = True
        Me.cmbyear.Location = New System.Drawing.Point(77, 18)
        Me.cmbyear.Name = "cmbyear"
        Me.cmbyear.Size = New System.Drawing.Size(220, 26)
        Me.cmbyear.Sorted = True
        Me.cmbyear.TabIndex = 78
        '
        'Panel5
        '
        Me.Panel5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.Panel5.Controls.Add(Me.Label40)
        Me.Panel5.Controls.Add(Me.lblyearlyarcharge)
        Me.Panel5.Controls.Add(Me.Label36)
        Me.Panel5.Controls.Add(Me.lblyearlycashsales)
        Me.Panel5.Controls.Add(Me.lblyearlypaymenttotal)
        Me.Panel5.Controls.Add(Me.Label20)
        Me.Panel5.Controls.Add(Me.Label22)
        Me.Panel5.Controls.Add(Me.lblyearlyap)
        Me.Panel5.Controls.Add(Me.lblyearlyarsales)
        Me.Panel5.Controls.Add(Me.Label28)
        Me.Panel5.Location = New System.Drawing.Point(595, 365)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(351, 98)
        Me.Panel5.TabIndex = 77
        '
        'Label40
        '
        Me.Label40.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.ForeColor = System.Drawing.Color.White
        Me.Label40.Location = New System.Drawing.Point(14, 13)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(79, 14)
        Me.Label40.TabIndex = 97
        Me.Label40.Text = "A.R Charge:"
        '
        'lblyearlyarcharge
        '
        Me.lblyearlyarcharge.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblyearlyarcharge.AutoSize = True
        Me.lblyearlyarcharge.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblyearlyarcharge.ForeColor = System.Drawing.Color.LimeGreen
        Me.lblyearlyarcharge.Location = New System.Drawing.Point(201, 13)
        Me.lblyearlyarcharge.Name = "lblyearlyarcharge"
        Me.lblyearlyarcharge.Size = New System.Drawing.Size(39, 14)
        Me.lblyearlyarcharge.TabIndex = 98
        Me.lblyearlyarcharge.Text = "00.00"
        '
        'Label36
        '
        Me.Label36.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.ForeColor = System.Drawing.Color.White
        Me.Label36.Location = New System.Drawing.Point(14, 30)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(76, 14)
        Me.Label36.TabIndex = 95
        Me.Label36.Text = "Cash Sales:"
        '
        'lblyearlycashsales
        '
        Me.lblyearlycashsales.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblyearlycashsales.AutoSize = True
        Me.lblyearlycashsales.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblyearlycashsales.ForeColor = System.Drawing.Color.LimeGreen
        Me.lblyearlycashsales.Location = New System.Drawing.Point(201, 30)
        Me.lblyearlycashsales.Name = "lblyearlycashsales"
        Me.lblyearlycashsales.Size = New System.Drawing.Size(39, 14)
        Me.lblyearlycashsales.TabIndex = 96
        Me.lblyearlycashsales.Text = "00.00"
        '
        'lblyearlypaymenttotal
        '
        Me.lblyearlypaymenttotal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblyearlypaymenttotal.AutoSize = True
        Me.lblyearlypaymenttotal.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblyearlypaymenttotal.ForeColor = System.Drawing.Color.LimeGreen
        Me.lblyearlypaymenttotal.Location = New System.Drawing.Point(201, 75)
        Me.lblyearlypaymenttotal.Name = "lblyearlypaymenttotal"
        Me.lblyearlypaymenttotal.Size = New System.Drawing.Size(53, 18)
        Me.lblyearlypaymenttotal.TabIndex = 94
        Me.lblyearlypaymenttotal.Text = "00.00"
        '
        'Label20
        '
        Me.Label20.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(14, 75)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(127, 18)
        Me.Label20.TabIndex = 93
        Me.Label20.Text = "SALES TOTAL:"
        '
        'Label22
        '
        Me.Label22.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.Location = New System.Drawing.Point(14, 46)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(68, 14)
        Me.Label22.TabIndex = 89
        Me.Label22.Text = "A.R Sales:"
        '
        'lblyearlyap
        '
        Me.lblyearlyap.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblyearlyap.AutoSize = True
        Me.lblyearlyap.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblyearlyap.ForeColor = System.Drawing.Color.LimeGreen
        Me.lblyearlyap.Location = New System.Drawing.Point(201, 61)
        Me.lblyearlyap.Name = "lblyearlyap"
        Me.lblyearlyap.Size = New System.Drawing.Size(39, 14)
        Me.lblyearlyap.TabIndex = 92
        Me.lblyearlyap.Text = "00.00"
        '
        'lblyearlyarsales
        '
        Me.lblyearlyarsales.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblyearlyarsales.AutoSize = True
        Me.lblyearlyarsales.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblyearlyarsales.ForeColor = System.Drawing.Color.LimeGreen
        Me.lblyearlyarsales.Location = New System.Drawing.Point(201, 46)
        Me.lblyearlyarsales.Name = "lblyearlyarsales"
        Me.lblyearlyarsales.Size = New System.Drawing.Size(39, 14)
        Me.lblyearlyarsales.TabIndex = 90
        Me.lblyearlyarsales.Text = "00.00"
        '
        'Label28
        '
        Me.Label28.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.White
        Me.Label28.Location = New System.Drawing.Point(14, 61)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(135, 14)
        Me.Label28.TabIndex = 91
        Me.Label28.Text = "ADVANCE PAYMENT:"
        '
        'Panel6
        '
        Me.Panel6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.Panel6.Controls.Add(Me.Label42)
        Me.Panel6.Controls.Add(Me.lblyearlyarcash)
        Me.Panel6.Controls.Add(Me.Label32)
        Me.Panel6.Controls.Add(Me.lblyearlycashtotal)
        Me.Panel6.Controls.Add(Me.Label35)
        Me.Panel6.Controls.Add(Me.lblyearlycashout)
        Me.Panel6.Controls.Add(Me.Label37)
        Me.Panel6.Controls.Add(Me.lblyearlydeposit)
        Me.Panel6.Controls.Add(Me.Label39)
        Me.Panel6.Controls.Add(Me.lblyearlyapcash)
        Me.Panel6.Controls.Add(Me.Label41)
        Me.Panel6.Controls.Add(Me.lblyearlycash)
        Me.Panel6.Controls.Add(Me.Label43)
        Me.Panel6.Location = New System.Drawing.Point(28, 363)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(390, 100)
        Me.Panel6.TabIndex = 76
        '
        'Label42
        '
        Me.Label42.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.ForeColor = System.Drawing.Color.Firebrick
        Me.Label42.Location = New System.Drawing.Point(173, 63)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(11, 14)
        Me.Label42.TabIndex = 89
        Me.Label42.Text = "-"
        '
        'lblyearlyarcash
        '
        Me.lblyearlyarcash.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblyearlyarcash.AutoSize = True
        Me.lblyearlyarcash.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblyearlyarcash.ForeColor = System.Drawing.Color.LimeGreen
        Me.lblyearlyarcash.Location = New System.Drawing.Point(190, 6)
        Me.lblyearlyarcash.Name = "lblyearlyarcash"
        Me.lblyearlyarcash.Size = New System.Drawing.Size(39, 14)
        Me.lblyearlyarcash.TabIndex = 88
        Me.lblyearlyarcash.Text = "00.00"
        '
        'Label32
        '
        Me.Label32.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.Color.White
        Me.Label32.Location = New System.Drawing.Point(4, 20)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(41, 14)
        Me.Label32.TabIndex = 87
        Me.Label32.Text = "Cash:"
        '
        'lblyearlycashtotal
        '
        Me.lblyearlycashtotal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblyearlycashtotal.AutoSize = True
        Me.lblyearlycashtotal.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblyearlycashtotal.ForeColor = System.Drawing.Color.LimeGreen
        Me.lblyearlycashtotal.Location = New System.Drawing.Point(190, 77)
        Me.lblyearlycashtotal.Name = "lblyearlycashtotal"
        Me.lblyearlycashtotal.Size = New System.Drawing.Size(53, 18)
        Me.lblyearlycashtotal.TabIndex = 86
        Me.lblyearlycashtotal.Text = "00.00"
        '
        'Label35
        '
        Me.Label35.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.ForeColor = System.Drawing.Color.White
        Me.Label35.Location = New System.Drawing.Point(3, 77)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(119, 18)
        Me.Label35.TabIndex = 85
        Me.Label35.Text = "CASH TOTAL:"
        '
        'lblyearlycashout
        '
        Me.lblyearlycashout.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblyearlycashout.AutoSize = True
        Me.lblyearlycashout.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblyearlycashout.ForeColor = System.Drawing.Color.Firebrick
        Me.lblyearlycashout.Location = New System.Drawing.Point(190, 63)
        Me.lblyearlycashout.Name = "lblyearlycashout"
        Me.lblyearlycashout.Size = New System.Drawing.Size(39, 14)
        Me.lblyearlycashout.TabIndex = 84
        Me.lblyearlycashout.Text = "00.00"
        '
        'Label37
        '
        Me.Label37.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.ForeColor = System.Drawing.Color.White
        Me.Label37.Location = New System.Drawing.Point(3, 63)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(71, 14)
        Me.Label37.TabIndex = 83
        Me.Label37.Text = "Cash OUT:"
        '
        'lblyearlydeposit
        '
        Me.lblyearlydeposit.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblyearlydeposit.AutoSize = True
        Me.lblyearlydeposit.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblyearlydeposit.ForeColor = System.Drawing.Color.LimeGreen
        Me.lblyearlydeposit.Location = New System.Drawing.Point(190, 49)
        Me.lblyearlydeposit.Name = "lblyearlydeposit"
        Me.lblyearlydeposit.Size = New System.Drawing.Size(39, 14)
        Me.lblyearlydeposit.TabIndex = 82
        Me.lblyearlydeposit.Text = "00.00"
        '
        'Label39
        '
        Me.Label39.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.ForeColor = System.Drawing.Color.White
        Me.Label39.Location = New System.Drawing.Point(3, 49)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(56, 14)
        Me.Label39.TabIndex = 81
        Me.Label39.Text = "Deposit:"
        '
        'lblyearlyapcash
        '
        Me.lblyearlyapcash.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblyearlyapcash.AutoSize = True
        Me.lblyearlyapcash.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblyearlyapcash.ForeColor = System.Drawing.Color.LimeGreen
        Me.lblyearlyapcash.Location = New System.Drawing.Point(190, 34)
        Me.lblyearlyapcash.Name = "lblyearlyapcash"
        Me.lblyearlyapcash.Size = New System.Drawing.Size(39, 14)
        Me.lblyearlyapcash.TabIndex = 80
        Me.lblyearlyapcash.Text = "00.00"
        '
        'Label41
        '
        Me.Label41.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.ForeColor = System.Drawing.Color.White
        Me.Label41.Location = New System.Drawing.Point(4, 34)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(150, 14)
        Me.Label41.TabIndex = 79
        Me.Label41.Text = "Advance Payment Cash:"
        '
        'lblyearlycash
        '
        Me.lblyearlycash.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblyearlycash.AutoSize = True
        Me.lblyearlycash.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblyearlycash.ForeColor = System.Drawing.Color.LimeGreen
        Me.lblyearlycash.Location = New System.Drawing.Point(190, 20)
        Me.lblyearlycash.Name = "lblyearlycash"
        Me.lblyearlycash.Size = New System.Drawing.Size(39, 14)
        Me.lblyearlycash.TabIndex = 78
        Me.lblyearlycash.Text = "00.00"
        '
        'Label43
        '
        Me.Label43.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label43.AutoSize = True
        Me.Label43.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.ForeColor = System.Drawing.Color.White
        Me.Label43.Location = New System.Drawing.Point(4, 6)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(66, 14)
        Me.Label43.TabIndex = 77
        Me.Label43.Text = "A.R Cash:"
        '
        'Label44
        '
        Me.Label44.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label44.AutoSize = True
        Me.Label44.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.Location = New System.Drawing.Point(666, 18)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(54, 15)
        Me.Label44.TabIndex = 75
        Me.Label44.Text = "Cashier:"
        '
        'cmbCashiers3
        '
        Me.cmbCashiers3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbCashiers3.BackColor = System.Drawing.Color.DodgerBlue
        Me.cmbCashiers3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCashiers3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbCashiers3.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCashiers3.ForeColor = System.Drawing.Color.White
        Me.cmbCashiers3.FormattingEnabled = True
        Me.cmbCashiers3.Location = New System.Drawing.Point(726, 13)
        Me.cmbCashiers3.Name = "cmbCashiers3"
        Me.cmbCashiers3.Size = New System.Drawing.Size(220, 26)
        Me.cmbCashiers3.TabIndex = 74
        '
        'dgvyearly
        '
        Me.dgvyearly.AllowUserToAddRows = False
        Me.dgvyearly.AllowUserToDeleteRows = False
        Me.dgvyearly.AllowUserToResizeColumns = False
        Me.dgvyearly.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvyearly.BackgroundColor = System.Drawing.Color.White
        Me.dgvyearly.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvyearly.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dgvyearly.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvyearly.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.yearlymonth, Me.yearlynumtakeout, Me.yearlysalestakeout, Me.yearlynumdeliver, Me.yearlysalesdeliver, Me.yearlynumarcharge, Me.yearlysalesarcharge, Me.yearlynumarsales, Me.yearlysalesarsales, Me.yearlynumarcash, Me.yearlysalesarcash, Me.yearlynumapcash, Me.yearlysalesapcash, Me.yearlynumap, Me.yearlysalesap, Me.yearlynumtotal, Me.yearlytotalsales})
        Me.dgvyearly.EnableHeadersVisualStyles = False
        Me.dgvyearly.GridColor = System.Drawing.Color.White
        Me.dgvyearly.Location = New System.Drawing.Point(28, 58)
        Me.dgvyearly.Name = "dgvyearly"
        Me.dgvyearly.ReadOnly = True
        Me.dgvyearly.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvyearly.RowHeadersVisible = False
        Me.dgvyearly.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvyearly.Size = New System.Drawing.Size(918, 294)
        Me.dgvyearly.TabIndex = 73
        '
        'yearlymonth
        '
        Me.yearlymonth.HeaderText = "Month"
        Me.yearlymonth.Name = "yearlymonth"
        Me.yearlymonth.ReadOnly = True
        '
        'yearlynumtakeout
        '
        Me.yearlynumtakeout.HeaderText = "No. of Transaction (Take Out)"
        Me.yearlynumtakeout.Name = "yearlynumtakeout"
        Me.yearlynumtakeout.ReadOnly = True
        '
        'yearlysalestakeout
        '
        Me.yearlysalestakeout.HeaderText = "Sales Amount (Take Out)"
        Me.yearlysalestakeout.Name = "yearlysalestakeout"
        Me.yearlysalestakeout.ReadOnly = True
        '
        'yearlynumdeliver
        '
        Me.yearlynumdeliver.HeaderText = "No. of Transaction (Deliver)"
        Me.yearlynumdeliver.Name = "yearlynumdeliver"
        Me.yearlynumdeliver.ReadOnly = True
        '
        'yearlysalesdeliver
        '
        Me.yearlysalesdeliver.HeaderText = "Sales Amount (Deliver)"
        Me.yearlysalesdeliver.Name = "yearlysalesdeliver"
        Me.yearlysalesdeliver.ReadOnly = True
        '
        'yearlynumarcharge
        '
        Me.yearlynumarcharge.HeaderText = "No. of Transaction (A.R Charge)"
        Me.yearlynumarcharge.Name = "yearlynumarcharge"
        Me.yearlynumarcharge.ReadOnly = True
        '
        'yearlysalesarcharge
        '
        Me.yearlysalesarcharge.HeaderText = "Sales Amount (A.R Charge)"
        Me.yearlysalesarcharge.Name = "yearlysalesarcharge"
        Me.yearlysalesarcharge.ReadOnly = True
        '
        'yearlynumarsales
        '
        Me.yearlynumarsales.HeaderText = "No. of Transaction (A.R Sales)"
        Me.yearlynumarsales.Name = "yearlynumarsales"
        Me.yearlynumarsales.ReadOnly = True
        '
        'yearlysalesarsales
        '
        Me.yearlysalesarsales.HeaderText = "Sales Amount (A.R Sales)"
        Me.yearlysalesarsales.Name = "yearlysalesarsales"
        Me.yearlysalesarsales.ReadOnly = True
        '
        'yearlynumarcash
        '
        Me.yearlynumarcash.HeaderText = "No. of Transaction (A.R Cash)"
        Me.yearlynumarcash.Name = "yearlynumarcash"
        Me.yearlynumarcash.ReadOnly = True
        '
        'yearlysalesarcash
        '
        Me.yearlysalesarcash.HeaderText = "Sales Amount (A.R Cash)"
        Me.yearlysalesarcash.Name = "yearlysalesarcash"
        Me.yearlysalesarcash.ReadOnly = True
        '
        'yearlynumapcash
        '
        Me.yearlynumapcash.HeaderText = "No. of Transaction (Advance Payment Cash)"
        Me.yearlynumapcash.Name = "yearlynumapcash"
        Me.yearlynumapcash.ReadOnly = True
        '
        'yearlysalesapcash
        '
        Me.yearlysalesapcash.HeaderText = "Sales Amount (Advance Payment Cash)"
        Me.yearlysalesapcash.Name = "yearlysalesapcash"
        Me.yearlysalesapcash.ReadOnly = True
        '
        'yearlynumap
        '
        Me.yearlynumap.HeaderText = "No. of Transaction (Advance Payment)"
        Me.yearlynumap.Name = "yearlynumap"
        Me.yearlynumap.ReadOnly = True
        '
        'yearlysalesap
        '
        Me.yearlysalesap.HeaderText = "Sales Amount (Advance Payment)"
        Me.yearlysalesap.Name = "yearlysalesap"
        Me.yearlysalesap.ReadOnly = True
        '
        'yearlynumtotal
        '
        Me.yearlynumtotal.HeaderText = "No. of Transaction"
        Me.yearlynumtotal.Name = "yearlynumtotal"
        Me.yearlynumtotal.ReadOnly = True
        '
        'yearlytotalsales
        '
        Me.yearlytotalsales.HeaderText = "Total Sales Amount"
        Me.yearlytotalsales.Name = "yearlytotalsales"
        Me.yearlytotalsales.ReadOnly = True
        '
        'salessum2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1031, 582)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "salessum2"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sales Summary"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvhour, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.dgvDaily, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        CType(Me.dgvyearly, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents dgvhour As System.Windows.Forms.DataGridView
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmbCashiers As System.Windows.Forms.ComboBox
    Friend WithEvents datefrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblgtotal As System.Windows.Forms.Label
    Friend WithEvents dgvDaily As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbCashiers2 As System.Windows.Forms.ComboBox
    Friend WithEvents dateFromDaily As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dateToDaily As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblARCASH As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents lblcashtotal As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents lblcashout As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lbldeposit As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lblapcash As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblcash As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblpaymenttotal As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents lblap As System.Windows.Forms.Label
    Friend WithEvents lblarsales As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents lbldailypaymenttotal As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lbldailyap As System.Windows.Forms.Label
    Friend WithEvents lbldailyarsales As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents lbldailyarcash As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents lbldailycashtotal As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents lbldailycashout As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents lbldailydeposit As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents lbldailyapcash As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents lbldailycash As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents lbldailygtotal As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents cmbyear As System.Windows.Forms.ComboBox
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents lblyearlypaymenttotal As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents lblyearlyap As System.Windows.Forms.Label
    Friend WithEvents lblyearlyarsales As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents lblyearlyarcash As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents lblyearlycashtotal As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents lblyearlycashout As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents lblyearlydeposit As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents lblyearlyapcash As System.Windows.Forms.Label
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents lblyearlycash As System.Windows.Forms.Label
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents cmbCashiers3 As System.Windows.Forms.ComboBox
    Friend WithEvents dgvyearly As System.Windows.Forms.DataGridView
    Friend WithEvents lblyearlygtotal As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents lblarcharge As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblcashsales As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents lbldailyarcharge As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents lbldailycashsales As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents lblyearlyarcharge As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents lblyearlycashsales As System.Windows.Forms.Label
    Friend WithEvents time As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents numtakeout As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents salestakeout As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents numdeliver As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents salesdeliver As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents numarcharge As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents salesarcharge As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents numarcash As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents salesarcash As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents numarsales As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents salesarsales As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents numapcash As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents salesapcash As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents numap As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents salesap As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents numtotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents totalsales As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dailydate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dailynumtakeout As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dailysalestakeout As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dailynumdeliver As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dailysalesdeliver As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dailynumarcharge As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dailysalesarcharge As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dailynumarsales As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dailysalesarsales As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dailynumarcash As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dailysalesarcash As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dailynumapcash As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dailysalesapcash As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dailynumap As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dailysalesap As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dailynumtotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dailytotalsales As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents yearlymonth As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents yearlynumtakeout As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents yearlysalestakeout As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents yearlynumdeliver As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents yearlysalesdeliver As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents yearlynumarcharge As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents yearlysalesarcharge As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents yearlynumarsales As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents yearlysalesarsales As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents yearlynumarcash As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents yearlysalesarcash As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents yearlynumapcash As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents yearlysalesapcash As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents yearlynumap As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents yearlysalesap As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents yearlynumtotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents yearlytotalsales As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents Label46 As System.Windows.Forms.Label
End Class
