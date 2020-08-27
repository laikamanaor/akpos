<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class main
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(main))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.panelsuborders = New System.Windows.Forms.Panel()
        Me.btnpendingorder = New System.Windows.Forms.Button()
        Me.btnorderhistory = New System.Windows.Forms.Button()
        Me.btnorders = New System.Windows.Forms.Button()
        Me.btnapdep = New System.Windows.Forms.Button()
        Me.btnpos = New System.Windows.Forms.Button()
        Me.panelsubusers = New System.Windows.Forms.Panel()
        Me.btnlogs = New System.Windows.Forms.Button()
        Me.btnmanusers = New System.Windows.Forms.Button()
        Me.btnusers = New System.Windows.Forms.Button()
        Me.panelsubsales = New System.Windows.Forms.Panel()
        Me.btndischarge = New System.Windows.Forms.Button()
        Me.btnitemprice = New System.Windows.Forms.Button()
        Me.btnordertrans = New System.Windows.Forms.Button()
        Me.btnmancustomers = New System.Windows.Forms.Button()
        Me.btnbranches = New System.Windows.Forms.Button()
        Me.btnsales = New System.Windows.Forms.Button()
        Me.panelsubinventorytransaction = New System.Windows.Forms.Panel()
        Me.btnRemarks = New System.Windows.Forms.Button()
        Me.btneditsap = New System.Windows.Forms.Button()
        Me.btnrectrans = New System.Windows.Forms.Button()
        Me.btnendingbalance = New System.Windows.Forms.Button()
        Me.btninventory = New System.Windows.Forms.Button()
        Me.btnpendingsap = New System.Windows.Forms.Button()
        Me.btnarsales = New System.Windows.Forms.Button()
        Me.bntarcharge = New System.Windows.Forms.Button()
        Me.btnconversion = New System.Windows.Forms.Button()
        Me.btnadjustmentout = New System.Windows.Forms.Button()
        Me.btnadjustmentin = New System.Windows.Forms.Button()
        Me.btnPullOut = New System.Windows.Forms.Button()
        Me.btntransfer = New System.Windows.Forms.Button()
        Me.btnrecsup = New System.Windows.Forms.Button()
        Me.btnrecbranch = New System.Windows.Forms.Button()
        Me.btnrecprod = New System.Windows.Forms.Button()
        Me.btnReceivedSAP = New System.Windows.Forms.Button()
        Me.btncreatenew = New System.Windows.Forms.Button()
        Me.btninvtrans = New System.Windows.Forms.Button()
        Me.panelsubreports = New System.Windows.Forms.Panel()
        Me.btnsapupload = New System.Windows.Forms.Button()
        Me.btnprintreports = New System.Windows.Forms.Button()
        Me.btnconvlogssales = New System.Windows.Forms.Button()
        Me.btninvlogssales = New System.Windows.Forms.Button()
        Me.btnreports = New System.Windows.Forms.Button()
        Me.panelsubitems = New System.Windows.Forms.Panel()
        Me.btnCategory = New System.Windows.Forms.Button()
        Me.btncoffeeshop = New System.Windows.Forms.Button()
        Me.btnitemimage = New System.Windows.Forms.Button()
        Me.btnmanageitem = New System.Windows.Forms.Button()
        Me.btnitems = New System.Windows.Forms.Button()
        Me.panelsubsettings = New System.Windows.Forms.Panel()
        Me.btncutoff = New System.Windows.Forms.Button()
        Me.btnlogout = New System.Windows.Forms.Button()
        Me.btnsettings = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnminimize = New System.Windows.Forms.Button()
        Me.maximize = New System.Windows.Forms.PictureBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lbldatetime = New System.Windows.Forms.Label()
        Me.lblheader = New System.Windows.Forms.Label()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.panelchildform = New System.Windows.Forms.Panel()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.Panel1.SuspendLayout()
        Me.panelsuborders.SuspendLayout()
        Me.panelsubusers.SuspendLayout()
        Me.panelsubsales.SuspendLayout()
        Me.panelsubinventorytransaction.SuspendLayout()
        Me.panelsubreports.SuspendLayout()
        Me.panelsubitems.SuspendLayout()
        Me.panelsubsettings.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.maximize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer))
        Me.Panel1.Controls.Add(Me.panelsuborders)
        Me.Panel1.Controls.Add(Me.btnorders)
        Me.Panel1.Controls.Add(Me.btnapdep)
        Me.Panel1.Controls.Add(Me.btnpos)
        Me.Panel1.Controls.Add(Me.panelsubusers)
        Me.Panel1.Controls.Add(Me.btnusers)
        Me.Panel1.Controls.Add(Me.panelsubsales)
        Me.Panel1.Controls.Add(Me.btnsales)
        Me.Panel1.Controls.Add(Me.panelsubinventorytransaction)
        Me.Panel1.Controls.Add(Me.btninvtrans)
        Me.Panel1.Controls.Add(Me.panelsubreports)
        Me.Panel1.Controls.Add(Me.btnreports)
        Me.Panel1.Controls.Add(Me.panelsubitems)
        Me.Panel1.Controls.Add(Me.btnitems)
        Me.Panel1.Controls.Add(Me.panelsubsettings)
        Me.Panel1.Controls.Add(Me.btnsettings)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(235, 334)
        Me.Panel1.TabIndex = 0
        '
        'panelsuborders
        '
        Me.panelsuborders.BackColor = System.Drawing.Color.White
        Me.panelsuborders.Controls.Add(Me.btnpendingorder)
        Me.panelsuborders.Controls.Add(Me.btnorderhistory)
        Me.panelsuborders.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelsuborders.Location = New System.Drawing.Point(0, 1565)
        Me.panelsuborders.Name = "panelsuborders"
        Me.panelsuborders.Size = New System.Drawing.Size(218, 66)
        Me.panelsuborders.TabIndex = 20
        Me.panelsuborders.Visible = False
        '
        'btnpendingorder
        '
        Me.btnpendingorder.BackColor = System.Drawing.Color.White
        Me.btnpendingorder.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnpendingorder.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnpendingorder.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.btnpendingorder.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnpendingorder.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnpendingorder.ForeColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.btnpendingorder.Location = New System.Drawing.Point(0, 31)
        Me.btnpendingorder.Name = "btnpendingorder"
        Me.btnpendingorder.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.btnpendingorder.Size = New System.Drawing.Size(218, 31)
        Me.btnpendingorder.TabIndex = 2
        Me.btnpendingorder.Text = "Pending Orders"
        Me.btnpendingorder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnpendingorder.UseVisualStyleBackColor = False
        '
        'btnorderhistory
        '
        Me.btnorderhistory.BackColor = System.Drawing.Color.White
        Me.btnorderhistory.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnorderhistory.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnorderhistory.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.btnorderhistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnorderhistory.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnorderhistory.ForeColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.btnorderhistory.Location = New System.Drawing.Point(0, 0)
        Me.btnorderhistory.Name = "btnorderhistory"
        Me.btnorderhistory.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.btnorderhistory.Size = New System.Drawing.Size(218, 31)
        Me.btnorderhistory.TabIndex = 1
        Me.btnorderhistory.Text = "Order Logs"
        Me.btnorderhistory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnorderhistory.UseVisualStyleBackColor = False
        '
        'btnorders
        '
        Me.btnorders.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.btnorders.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnorders.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnorders.FlatAppearance.BorderSize = 0
        Me.btnorders.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.btnorders.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnorders.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnorders.ForeColor = System.Drawing.Color.White
        Me.btnorders.Location = New System.Drawing.Point(0, 1514)
        Me.btnorders.Name = "btnorders"
        Me.btnorders.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.btnorders.Size = New System.Drawing.Size(218, 51)
        Me.btnorders.TabIndex = 19
        Me.btnorders.Text = "ORDERS"
        Me.btnorders.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnorders.UseVisualStyleBackColor = False
        '
        'btnapdep
        '
        Me.btnapdep.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.btnapdep.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnapdep.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnapdep.FlatAppearance.BorderSize = 0
        Me.btnapdep.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.btnapdep.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnapdep.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnapdep.ForeColor = System.Drawing.Color.White
        Me.btnapdep.Location = New System.Drawing.Point(0, 1463)
        Me.btnapdep.Name = "btnapdep"
        Me.btnapdep.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.btnapdep.Size = New System.Drawing.Size(218, 51)
        Me.btnapdep.TabIndex = 17
        Me.btnapdep.Text = "ADVANCE PAYMENT / DEPOSIT"
        Me.btnapdep.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnapdep.UseVisualStyleBackColor = False
        '
        'btnpos
        '
        Me.btnpos.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.btnpos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnpos.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnpos.FlatAppearance.BorderSize = 0
        Me.btnpos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.btnpos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnpos.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnpos.ForeColor = System.Drawing.Color.White
        Me.btnpos.Location = New System.Drawing.Point(0, 1412)
        Me.btnpos.Name = "btnpos"
        Me.btnpos.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.btnpos.Size = New System.Drawing.Size(218, 51)
        Me.btnpos.TabIndex = 14
        Me.btnpos.Text = "POS"
        Me.btnpos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnpos.UseVisualStyleBackColor = False
        '
        'panelsubusers
        '
        Me.panelsubusers.BackColor = System.Drawing.Color.White
        Me.panelsubusers.Controls.Add(Me.btnlogs)
        Me.panelsubusers.Controls.Add(Me.btnmanusers)
        Me.panelsubusers.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelsubusers.Location = New System.Drawing.Point(0, 1347)
        Me.panelsubusers.Name = "panelsubusers"
        Me.panelsubusers.Size = New System.Drawing.Size(218, 65)
        Me.panelsubusers.TabIndex = 13
        Me.panelsubusers.Visible = False
        '
        'btnlogs
        '
        Me.btnlogs.BackColor = System.Drawing.Color.White
        Me.btnlogs.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnlogs.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnlogs.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.btnlogs.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnlogs.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnlogs.ForeColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.btnlogs.Location = New System.Drawing.Point(0, 31)
        Me.btnlogs.Name = "btnlogs"
        Me.btnlogs.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.btnlogs.Size = New System.Drawing.Size(218, 31)
        Me.btnlogs.TabIndex = 3
        Me.btnlogs.Text = "Login Logs"
        Me.btnlogs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnlogs.UseVisualStyleBackColor = False
        '
        'btnmanusers
        '
        Me.btnmanusers.BackColor = System.Drawing.Color.White
        Me.btnmanusers.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnmanusers.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnmanusers.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.btnmanusers.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnmanusers.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnmanusers.ForeColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.btnmanusers.Location = New System.Drawing.Point(0, 0)
        Me.btnmanusers.Name = "btnmanusers"
        Me.btnmanusers.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.btnmanusers.Size = New System.Drawing.Size(218, 31)
        Me.btnmanusers.TabIndex = 1
        Me.btnmanusers.Text = "Manage Users"
        Me.btnmanusers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnmanusers.UseVisualStyleBackColor = False
        '
        'btnusers
        '
        Me.btnusers.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.btnusers.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnusers.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnusers.FlatAppearance.BorderSize = 0
        Me.btnusers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.btnusers.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnusers.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnusers.ForeColor = System.Drawing.Color.White
        Me.btnusers.Location = New System.Drawing.Point(0, 1296)
        Me.btnusers.Name = "btnusers"
        Me.btnusers.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.btnusers.Size = New System.Drawing.Size(218, 51)
        Me.btnusers.TabIndex = 12
        Me.btnusers.Text = "USERS"
        Me.btnusers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnusers.UseVisualStyleBackColor = False
        '
        'panelsubsales
        '
        Me.panelsubsales.BackColor = System.Drawing.Color.White
        Me.panelsubsales.Controls.Add(Me.btndischarge)
        Me.panelsubsales.Controls.Add(Me.btnitemprice)
        Me.panelsubsales.Controls.Add(Me.btnordertrans)
        Me.panelsubsales.Controls.Add(Me.btnmancustomers)
        Me.panelsubsales.Controls.Add(Me.btnbranches)
        Me.panelsubsales.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelsubsales.Location = New System.Drawing.Point(0, 1138)
        Me.panelsubsales.Name = "panelsubsales"
        Me.panelsubsales.Size = New System.Drawing.Size(218, 158)
        Me.panelsubsales.TabIndex = 11
        Me.panelsubsales.Visible = False
        '
        'btndischarge
        '
        Me.btndischarge.BackColor = System.Drawing.Color.White
        Me.btndischarge.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btndischarge.Dock = System.Windows.Forms.DockStyle.Top
        Me.btndischarge.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.btndischarge.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btndischarge.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btndischarge.ForeColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.btndischarge.Location = New System.Drawing.Point(0, 124)
        Me.btndischarge.Name = "btndischarge"
        Me.btndischarge.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.btndischarge.Size = New System.Drawing.Size(218, 31)
        Me.btndischarge.TabIndex = 10
        Me.btndischarge.Text = "Discount and Charges"
        Me.btndischarge.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btndischarge.UseVisualStyleBackColor = False
        '
        'btnitemprice
        '
        Me.btnitemprice.BackColor = System.Drawing.Color.White
        Me.btnitemprice.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnitemprice.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnitemprice.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.btnitemprice.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnitemprice.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnitemprice.ForeColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.btnitemprice.Location = New System.Drawing.Point(0, 93)
        Me.btnitemprice.Name = "btnitemprice"
        Me.btnitemprice.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.btnitemprice.Size = New System.Drawing.Size(218, 31)
        Me.btnitemprice.TabIndex = 9
        Me.btnitemprice.Text = "Items w/ Price"
        Me.btnitemprice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnitemprice.UseVisualStyleBackColor = False
        '
        'btnordertrans
        '
        Me.btnordertrans.BackColor = System.Drawing.Color.White
        Me.btnordertrans.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnordertrans.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnordertrans.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.btnordertrans.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnordertrans.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnordertrans.ForeColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.btnordertrans.Location = New System.Drawing.Point(0, 62)
        Me.btnordertrans.Name = "btnordertrans"
        Me.btnordertrans.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.btnordertrans.Size = New System.Drawing.Size(218, 31)
        Me.btnordertrans.TabIndex = 8
        Me.btnordertrans.Text = "Order Transactions"
        Me.btnordertrans.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnordertrans.UseVisualStyleBackColor = False
        '
        'btnmancustomers
        '
        Me.btnmancustomers.BackColor = System.Drawing.Color.White
        Me.btnmancustomers.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnmancustomers.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnmancustomers.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.btnmancustomers.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnmancustomers.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnmancustomers.ForeColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.btnmancustomers.Location = New System.Drawing.Point(0, 31)
        Me.btnmancustomers.Name = "btnmancustomers"
        Me.btnmancustomers.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.btnmancustomers.Size = New System.Drawing.Size(218, 31)
        Me.btnmancustomers.TabIndex = 7
        Me.btnmancustomers.Text = "Manage Customers"
        Me.btnmancustomers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnmancustomers.UseVisualStyleBackColor = False
        '
        'btnbranches
        '
        Me.btnbranches.BackColor = System.Drawing.Color.White
        Me.btnbranches.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnbranches.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnbranches.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.btnbranches.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnbranches.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnbranches.ForeColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.btnbranches.Location = New System.Drawing.Point(0, 0)
        Me.btnbranches.Name = "btnbranches"
        Me.btnbranches.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.btnbranches.Size = New System.Drawing.Size(218, 31)
        Me.btnbranches.TabIndex = 1
        Me.btnbranches.Text = "Branches"
        Me.btnbranches.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnbranches.UseVisualStyleBackColor = False
        '
        'btnsales
        '
        Me.btnsales.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.btnsales.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnsales.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnsales.FlatAppearance.BorderSize = 0
        Me.btnsales.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.btnsales.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnsales.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsales.ForeColor = System.Drawing.Color.White
        Me.btnsales.Location = New System.Drawing.Point(0, 1087)
        Me.btnsales.Name = "btnsales"
        Me.btnsales.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.btnsales.Size = New System.Drawing.Size(218, 51)
        Me.btnsales.TabIndex = 10
        Me.btnsales.Text = "SALES"
        Me.btnsales.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnsales.UseVisualStyleBackColor = False
        '
        'panelsubinventorytransaction
        '
        Me.panelsubinventorytransaction.BackColor = System.Drawing.Color.White
        Me.panelsubinventorytransaction.Controls.Add(Me.btnRemarks)
        Me.panelsubinventorytransaction.Controls.Add(Me.btneditsap)
        Me.panelsubinventorytransaction.Controls.Add(Me.btnrectrans)
        Me.panelsubinventorytransaction.Controls.Add(Me.btnendingbalance)
        Me.panelsubinventorytransaction.Controls.Add(Me.btninventory)
        Me.panelsubinventorytransaction.Controls.Add(Me.btnpendingsap)
        Me.panelsubinventorytransaction.Controls.Add(Me.btnarsales)
        Me.panelsubinventorytransaction.Controls.Add(Me.bntarcharge)
        Me.panelsubinventorytransaction.Controls.Add(Me.btnconversion)
        Me.panelsubinventorytransaction.Controls.Add(Me.btnadjustmentout)
        Me.panelsubinventorytransaction.Controls.Add(Me.btnadjustmentin)
        Me.panelsubinventorytransaction.Controls.Add(Me.btnPullOut)
        Me.panelsubinventorytransaction.Controls.Add(Me.btntransfer)
        Me.panelsubinventorytransaction.Controls.Add(Me.btnrecsup)
        Me.panelsubinventorytransaction.Controls.Add(Me.btnrecbranch)
        Me.panelsubinventorytransaction.Controls.Add(Me.btnrecprod)
        Me.panelsubinventorytransaction.Controls.Add(Me.btnReceivedSAP)
        Me.panelsubinventorytransaction.Controls.Add(Me.btncreatenew)
        Me.panelsubinventorytransaction.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelsubinventorytransaction.Location = New System.Drawing.Point(0, 525)
        Me.panelsubinventorytransaction.Name = "panelsubinventorytransaction"
        Me.panelsubinventorytransaction.Size = New System.Drawing.Size(218, 562)
        Me.panelsubinventorytransaction.TabIndex = 8
        Me.panelsubinventorytransaction.Visible = False
        '
        'btnRemarks
        '
        Me.btnRemarks.BackColor = System.Drawing.Color.White
        Me.btnRemarks.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRemarks.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnRemarks.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.btnRemarks.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRemarks.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemarks.ForeColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.btnRemarks.Location = New System.Drawing.Point(0, 527)
        Me.btnRemarks.Name = "btnRemarks"
        Me.btnRemarks.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.btnRemarks.Size = New System.Drawing.Size(218, 31)
        Me.btnRemarks.TabIndex = 100
        Me.btnRemarks.Text = "Edit Remarks"
        Me.btnRemarks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRemarks.UseVisualStyleBackColor = False
        '
        'btneditsap
        '
        Me.btneditsap.BackColor = System.Drawing.Color.White
        Me.btneditsap.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btneditsap.Dock = System.Windows.Forms.DockStyle.Top
        Me.btneditsap.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.btneditsap.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btneditsap.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btneditsap.ForeColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.btneditsap.Location = New System.Drawing.Point(0, 496)
        Me.btneditsap.Name = "btneditsap"
        Me.btneditsap.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.btneditsap.Size = New System.Drawing.Size(218, 31)
        Me.btneditsap.TabIndex = 99
        Me.btneditsap.Text = "Edit SAP #"
        Me.btneditsap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btneditsap.UseVisualStyleBackColor = False
        '
        'btnrectrans
        '
        Me.btnrectrans.BackColor = System.Drawing.Color.White
        Me.btnrectrans.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnrectrans.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnrectrans.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.btnrectrans.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnrectrans.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnrectrans.ForeColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.btnrectrans.Location = New System.Drawing.Point(0, 465)
        Me.btnrectrans.Name = "btnrectrans"
        Me.btnrectrans.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.btnrectrans.Size = New System.Drawing.Size(218, 31)
        Me.btnrectrans.TabIndex = 98
        Me.btnrectrans.Text = "Cancel Rec/Trans"
        Me.btnrectrans.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnrectrans.UseVisualStyleBackColor = False
        '
        'btnendingbalance
        '
        Me.btnendingbalance.BackColor = System.Drawing.Color.White
        Me.btnendingbalance.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnendingbalance.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnendingbalance.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.btnendingbalance.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnendingbalance.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnendingbalance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.btnendingbalance.Location = New System.Drawing.Point(0, 434)
        Me.btnendingbalance.Name = "btnendingbalance"
        Me.btnendingbalance.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.btnendingbalance.Size = New System.Drawing.Size(218, 31)
        Me.btnendingbalance.TabIndex = 97
        Me.btnendingbalance.Text = "Update Actual Ending Balance"
        Me.btnendingbalance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnendingbalance.UseVisualStyleBackColor = False
        '
        'btninventory
        '
        Me.btninventory.BackColor = System.Drawing.Color.White
        Me.btninventory.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btninventory.Dock = System.Windows.Forms.DockStyle.Top
        Me.btninventory.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.btninventory.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btninventory.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btninventory.ForeColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.btninventory.Location = New System.Drawing.Point(0, 403)
        Me.btninventory.Name = "btninventory"
        Me.btninventory.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.btninventory.Size = New System.Drawing.Size(218, 31)
        Me.btninventory.TabIndex = 96
        Me.btninventory.Text = "Inventory"
        Me.btninventory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btninventory.UseVisualStyleBackColor = False
        '
        'btnpendingsap
        '
        Me.btnpendingsap.BackColor = System.Drawing.Color.White
        Me.btnpendingsap.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnpendingsap.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnpendingsap.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.btnpendingsap.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnpendingsap.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnpendingsap.ForeColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.btnpendingsap.Location = New System.Drawing.Point(0, 372)
        Me.btnpendingsap.Name = "btnpendingsap"
        Me.btnpendingsap.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.btnpendingsap.Size = New System.Drawing.Size(218, 31)
        Me.btnpendingsap.TabIndex = 95
        Me.btnpendingsap.Text = "Pending SAP"
        Me.btnpendingsap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnpendingsap.UseVisualStyleBackColor = False
        '
        'btnarsales
        '
        Me.btnarsales.BackColor = System.Drawing.Color.White
        Me.btnarsales.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnarsales.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnarsales.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.btnarsales.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnarsales.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnarsales.ForeColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.btnarsales.Location = New System.Drawing.Point(0, 341)
        Me.btnarsales.Name = "btnarsales"
        Me.btnarsales.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.btnarsales.Size = New System.Drawing.Size(218, 31)
        Me.btnarsales.TabIndex = 94
        Me.btnarsales.Text = "A.R Sales"
        Me.btnarsales.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnarsales.UseVisualStyleBackColor = False
        '
        'bntarcharge
        '
        Me.bntarcharge.BackColor = System.Drawing.Color.White
        Me.bntarcharge.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bntarcharge.Dock = System.Windows.Forms.DockStyle.Top
        Me.bntarcharge.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.bntarcharge.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bntarcharge.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bntarcharge.ForeColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.bntarcharge.Location = New System.Drawing.Point(0, 310)
        Me.bntarcharge.Name = "bntarcharge"
        Me.bntarcharge.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.bntarcharge.Size = New System.Drawing.Size(218, 31)
        Me.bntarcharge.TabIndex = 93
        Me.bntarcharge.Text = "A.R Charge"
        Me.bntarcharge.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bntarcharge.UseVisualStyleBackColor = False
        '
        'btnconversion
        '
        Me.btnconversion.BackColor = System.Drawing.Color.White
        Me.btnconversion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnconversion.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnconversion.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.btnconversion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnconversion.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnconversion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.btnconversion.Location = New System.Drawing.Point(0, 279)
        Me.btnconversion.Name = "btnconversion"
        Me.btnconversion.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.btnconversion.Size = New System.Drawing.Size(218, 31)
        Me.btnconversion.TabIndex = 92
        Me.btnconversion.Text = "Conversion"
        Me.btnconversion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnconversion.UseVisualStyleBackColor = False
        '
        'btnadjustmentout
        '
        Me.btnadjustmentout.BackColor = System.Drawing.Color.White
        Me.btnadjustmentout.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnadjustmentout.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnadjustmentout.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.btnadjustmentout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnadjustmentout.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnadjustmentout.ForeColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.btnadjustmentout.Location = New System.Drawing.Point(0, 248)
        Me.btnadjustmentout.Name = "btnadjustmentout"
        Me.btnadjustmentout.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.btnadjustmentout.Size = New System.Drawing.Size(218, 31)
        Me.btnadjustmentout.TabIndex = 91
        Me.btnadjustmentout.Text = "Adjustment Out"
        Me.btnadjustmentout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnadjustmentout.UseVisualStyleBackColor = False
        '
        'btnadjustmentin
        '
        Me.btnadjustmentin.BackColor = System.Drawing.Color.White
        Me.btnadjustmentin.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnadjustmentin.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnadjustmentin.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.btnadjustmentin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnadjustmentin.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnadjustmentin.ForeColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.btnadjustmentin.Location = New System.Drawing.Point(0, 217)
        Me.btnadjustmentin.Name = "btnadjustmentin"
        Me.btnadjustmentin.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.btnadjustmentin.Size = New System.Drawing.Size(218, 31)
        Me.btnadjustmentin.TabIndex = 90
        Me.btnadjustmentin.Text = "Adjustment In"
        Me.btnadjustmentin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnadjustmentin.UseVisualStyleBackColor = False
        '
        'btnPullOut
        '
        Me.btnPullOut.BackColor = System.Drawing.Color.White
        Me.btnPullOut.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPullOut.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnPullOut.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.btnPullOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPullOut.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPullOut.ForeColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.btnPullOut.Location = New System.Drawing.Point(0, 186)
        Me.btnPullOut.Name = "btnPullOut"
        Me.btnPullOut.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.btnPullOut.Size = New System.Drawing.Size(218, 31)
        Me.btnPullOut.TabIndex = 89
        Me.btnPullOut.Text = "Pull Out"
        Me.btnPullOut.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPullOut.UseVisualStyleBackColor = False
        '
        'btntransfer
        '
        Me.btntransfer.BackColor = System.Drawing.Color.White
        Me.btntransfer.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btntransfer.Dock = System.Windows.Forms.DockStyle.Top
        Me.btntransfer.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.btntransfer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btntransfer.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btntransfer.ForeColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.btntransfer.Location = New System.Drawing.Point(0, 155)
        Me.btntransfer.Name = "btntransfer"
        Me.btntransfer.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.btntransfer.Size = New System.Drawing.Size(218, 31)
        Me.btntransfer.TabIndex = 77
        Me.btntransfer.Text = "Transfer Out"
        Me.btntransfer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btntransfer.UseVisualStyleBackColor = False
        '
        'btnrecsup
        '
        Me.btnrecsup.BackColor = System.Drawing.Color.White
        Me.btnrecsup.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnrecsup.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnrecsup.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.btnrecsup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnrecsup.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnrecsup.ForeColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.btnrecsup.Location = New System.Drawing.Point(0, 124)
        Me.btnrecsup.Name = "btnrecsup"
        Me.btnrecsup.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.btnrecsup.Size = New System.Drawing.Size(218, 31)
        Me.btnrecsup.TabIndex = 76
        Me.btnrecsup.Text = "Received From Direct Supplier"
        Me.btnrecsup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnrecsup.UseVisualStyleBackColor = False
        '
        'btnrecbranch
        '
        Me.btnrecbranch.BackColor = System.Drawing.Color.White
        Me.btnrecbranch.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnrecbranch.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnrecbranch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.btnrecbranch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnrecbranch.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnrecbranch.ForeColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.btnrecbranch.Location = New System.Drawing.Point(0, 93)
        Me.btnrecbranch.Name = "btnrecbranch"
        Me.btnrecbranch.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.btnrecbranch.Size = New System.Drawing.Size(218, 31)
        Me.btnrecbranch.TabIndex = 75
        Me.btnrecbranch.Text = "Received From Other Branch"
        Me.btnrecbranch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnrecbranch.UseVisualStyleBackColor = False
        '
        'btnrecprod
        '
        Me.btnrecprod.BackColor = System.Drawing.Color.White
        Me.btnrecprod.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnrecprod.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnrecprod.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.btnrecprod.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnrecprod.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnrecprod.ForeColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.btnrecprod.Location = New System.Drawing.Point(0, 62)
        Me.btnrecprod.Name = "btnrecprod"
        Me.btnrecprod.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.btnrecprod.Size = New System.Drawing.Size(218, 31)
        Me.btnrecprod.TabIndex = 74
        Me.btnrecprod.Text = "Received From Production"
        Me.btnrecprod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnrecprod.UseVisualStyleBackColor = False
        '
        'btnReceivedSAP
        '
        Me.btnReceivedSAP.BackColor = System.Drawing.Color.White
        Me.btnReceivedSAP.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnReceivedSAP.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnReceivedSAP.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.btnReceivedSAP.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReceivedSAP.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReceivedSAP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.btnReceivedSAP.Location = New System.Drawing.Point(0, 31)
        Me.btnReceivedSAP.Name = "btnReceivedSAP"
        Me.btnReceivedSAP.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.btnReceivedSAP.Size = New System.Drawing.Size(218, 31)
        Me.btnReceivedSAP.TabIndex = 73
        Me.btnReceivedSAP.Text = "Received From SAP"
        Me.btnReceivedSAP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReceivedSAP.UseVisualStyleBackColor = False
        '
        'btncreatenew
        '
        Me.btncreatenew.BackColor = System.Drawing.Color.White
        Me.btncreatenew.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btncreatenew.Dock = System.Windows.Forms.DockStyle.Top
        Me.btncreatenew.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.btncreatenew.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btncreatenew.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btncreatenew.ForeColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.btncreatenew.Location = New System.Drawing.Point(0, 0)
        Me.btncreatenew.Name = "btncreatenew"
        Me.btncreatenew.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.btncreatenew.Size = New System.Drawing.Size(218, 31)
        Me.btncreatenew.TabIndex = 1
        Me.btncreatenew.Text = "Create New"
        Me.btncreatenew.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btncreatenew.UseVisualStyleBackColor = False
        '
        'btninvtrans
        '
        Me.btninvtrans.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.btninvtrans.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btninvtrans.Dock = System.Windows.Forms.DockStyle.Top
        Me.btninvtrans.FlatAppearance.BorderSize = 0
        Me.btninvtrans.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.btninvtrans.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btninvtrans.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btninvtrans.ForeColor = System.Drawing.Color.White
        Me.btninvtrans.Location = New System.Drawing.Point(0, 474)
        Me.btninvtrans.Name = "btninvtrans"
        Me.btninvtrans.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.btninvtrans.Size = New System.Drawing.Size(218, 51)
        Me.btninvtrans.TabIndex = 9
        Me.btninvtrans.Text = "INVENTORY TRANSACTION"
        Me.btninvtrans.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btninvtrans.UseVisualStyleBackColor = False
        '
        'panelsubreports
        '
        Me.panelsubreports.BackColor = System.Drawing.Color.White
        Me.panelsubreports.Controls.Add(Me.btnsapupload)
        Me.panelsubreports.Controls.Add(Me.btnprintreports)
        Me.panelsubreports.Controls.Add(Me.btnconvlogssales)
        Me.panelsubreports.Controls.Add(Me.btninvlogssales)
        Me.panelsubreports.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelsubreports.Location = New System.Drawing.Point(0, 346)
        Me.panelsubreports.Name = "panelsubreports"
        Me.panelsubreports.Size = New System.Drawing.Size(218, 128)
        Me.panelsubreports.TabIndex = 4
        Me.panelsubreports.Visible = False
        '
        'btnsapupload
        '
        Me.btnsapupload.BackColor = System.Drawing.Color.White
        Me.btnsapupload.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnsapupload.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnsapupload.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.btnsapupload.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnsapupload.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsapupload.ForeColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.btnsapupload.Location = New System.Drawing.Point(0, 93)
        Me.btnsapupload.Name = "btnsapupload"
        Me.btnsapupload.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.btnsapupload.Size = New System.Drawing.Size(218, 31)
        Me.btnsapupload.TabIndex = 68
        Me.btnsapupload.Text = "SAP Uploading"
        Me.btnsapupload.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnsapupload.UseVisualStyleBackColor = False
        '
        'btnprintreports
        '
        Me.btnprintreports.BackColor = System.Drawing.Color.White
        Me.btnprintreports.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnprintreports.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnprintreports.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.btnprintreports.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnprintreports.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnprintreports.ForeColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.btnprintreports.Location = New System.Drawing.Point(0, 62)
        Me.btnprintreports.Name = "btnprintreports"
        Me.btnprintreports.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.btnprintreports.Size = New System.Drawing.Size(218, 31)
        Me.btnprintreports.TabIndex = 66
        Me.btnprintreports.Text = "Print Reports"
        Me.btnprintreports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnprintreports.UseVisualStyleBackColor = False
        '
        'btnconvlogssales
        '
        Me.btnconvlogssales.BackColor = System.Drawing.Color.White
        Me.btnconvlogssales.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnconvlogssales.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnconvlogssales.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.btnconvlogssales.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnconvlogssales.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnconvlogssales.ForeColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.btnconvlogssales.Location = New System.Drawing.Point(0, 31)
        Me.btnconvlogssales.Name = "btnconvlogssales"
        Me.btnconvlogssales.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.btnconvlogssales.Size = New System.Drawing.Size(218, 31)
        Me.btnconvlogssales.TabIndex = 7
        Me.btnconvlogssales.Text = "Conv. Logs"
        Me.btnconvlogssales.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnconvlogssales.UseVisualStyleBackColor = False
        '
        'btninvlogssales
        '
        Me.btninvlogssales.BackColor = System.Drawing.Color.White
        Me.btninvlogssales.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btninvlogssales.Dock = System.Windows.Forms.DockStyle.Top
        Me.btninvlogssales.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.btninvlogssales.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btninvlogssales.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btninvlogssales.ForeColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.btninvlogssales.Location = New System.Drawing.Point(0, 0)
        Me.btninvlogssales.Name = "btninvlogssales"
        Me.btninvlogssales.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.btninvlogssales.Size = New System.Drawing.Size(218, 31)
        Me.btninvlogssales.TabIndex = 4
        Me.btninvlogssales.Text = "Inv. Logs"
        Me.btninvlogssales.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btninvlogssales.UseVisualStyleBackColor = False
        '
        'btnreports
        '
        Me.btnreports.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.btnreports.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnreports.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnreports.FlatAppearance.BorderSize = 0
        Me.btnreports.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.btnreports.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnreports.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnreports.ForeColor = System.Drawing.Color.White
        Me.btnreports.Location = New System.Drawing.Point(0, 295)
        Me.btnreports.Name = "btnreports"
        Me.btnreports.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.btnreports.Size = New System.Drawing.Size(218, 51)
        Me.btnreports.TabIndex = 5
        Me.btnreports.Text = "REPORTS"
        Me.btnreports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnreports.UseVisualStyleBackColor = False
        '
        'panelsubitems
        '
        Me.panelsubitems.BackColor = System.Drawing.Color.White
        Me.panelsubitems.Controls.Add(Me.btnCategory)
        Me.panelsubitems.Controls.Add(Me.btncoffeeshop)
        Me.panelsubitems.Controls.Add(Me.btnitemimage)
        Me.panelsubitems.Controls.Add(Me.btnmanageitem)
        Me.panelsubitems.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelsubitems.Location = New System.Drawing.Point(0, 168)
        Me.panelsubitems.Name = "panelsubitems"
        Me.panelsubitems.Size = New System.Drawing.Size(218, 127)
        Me.panelsubitems.TabIndex = 2
        Me.panelsubitems.Visible = False
        '
        'btnCategory
        '
        Me.btnCategory.BackColor = System.Drawing.Color.White
        Me.btnCategory.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCategory.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnCategory.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.btnCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCategory.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCategory.ForeColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.btnCategory.Location = New System.Drawing.Point(0, 93)
        Me.btnCategory.Name = "btnCategory"
        Me.btnCategory.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.btnCategory.Size = New System.Drawing.Size(218, 31)
        Me.btnCategory.TabIndex = 5
        Me.btnCategory.Text = "Categories"
        Me.btnCategory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCategory.UseVisualStyleBackColor = False
        '
        'btncoffeeshop
        '
        Me.btncoffeeshop.BackColor = System.Drawing.Color.White
        Me.btncoffeeshop.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btncoffeeshop.Dock = System.Windows.Forms.DockStyle.Top
        Me.btncoffeeshop.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.btncoffeeshop.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btncoffeeshop.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btncoffeeshop.ForeColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.btncoffeeshop.Location = New System.Drawing.Point(0, 62)
        Me.btncoffeeshop.Name = "btncoffeeshop"
        Me.btncoffeeshop.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.btncoffeeshop.Size = New System.Drawing.Size(218, 31)
        Me.btncoffeeshop.TabIndex = 4
        Me.btncoffeeshop.Text = "Coffee Shop"
        Me.btncoffeeshop.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btncoffeeshop.UseVisualStyleBackColor = False
        '
        'btnitemimage
        '
        Me.btnitemimage.BackColor = System.Drawing.Color.White
        Me.btnitemimage.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnitemimage.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnitemimage.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.btnitemimage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnitemimage.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnitemimage.ForeColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.btnitemimage.Location = New System.Drawing.Point(0, 31)
        Me.btnitemimage.Name = "btnitemimage"
        Me.btnitemimage.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.btnitemimage.Size = New System.Drawing.Size(218, 31)
        Me.btnitemimage.TabIndex = 3
        Me.btnitemimage.Text = "Item Image"
        Me.btnitemimage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnitemimage.UseVisualStyleBackColor = False
        '
        'btnmanageitem
        '
        Me.btnmanageitem.BackColor = System.Drawing.Color.White
        Me.btnmanageitem.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnmanageitem.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnmanageitem.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.btnmanageitem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnmanageitem.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnmanageitem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.btnmanageitem.Location = New System.Drawing.Point(0, 0)
        Me.btnmanageitem.Name = "btnmanageitem"
        Me.btnmanageitem.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.btnmanageitem.Size = New System.Drawing.Size(218, 31)
        Me.btnmanageitem.TabIndex = 2
        Me.btnmanageitem.Text = "Manage Item"
        Me.btnmanageitem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnmanageitem.UseVisualStyleBackColor = False
        '
        'btnitems
        '
        Me.btnitems.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.btnitems.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnitems.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnitems.FlatAppearance.BorderSize = 0
        Me.btnitems.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.btnitems.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnitems.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnitems.ForeColor = System.Drawing.Color.White
        Me.btnitems.Location = New System.Drawing.Point(0, 117)
        Me.btnitems.Name = "btnitems"
        Me.btnitems.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.btnitems.Size = New System.Drawing.Size(218, 51)
        Me.btnitems.TabIndex = 3
        Me.btnitems.Text = "ITEMS"
        Me.btnitems.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnitems.UseVisualStyleBackColor = False
        '
        'panelsubsettings
        '
        Me.panelsubsettings.BackColor = System.Drawing.Color.White
        Me.panelsubsettings.Controls.Add(Me.btncutoff)
        Me.panelsubsettings.Controls.Add(Me.btnlogout)
        Me.panelsubsettings.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelsubsettings.Location = New System.Drawing.Point(0, 51)
        Me.panelsubsettings.Name = "panelsubsettings"
        Me.panelsubsettings.Size = New System.Drawing.Size(218, 66)
        Me.panelsubsettings.TabIndex = 1
        Me.panelsubsettings.Visible = False
        '
        'btncutoff
        '
        Me.btncutoff.BackColor = System.Drawing.Color.White
        Me.btncutoff.Dock = System.Windows.Forms.DockStyle.Top
        Me.btncutoff.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.btncutoff.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btncutoff.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btncutoff.ForeColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.btncutoff.Location = New System.Drawing.Point(0, 31)
        Me.btncutoff.Name = "btncutoff"
        Me.btncutoff.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.btncutoff.Size = New System.Drawing.Size(218, 31)
        Me.btncutoff.TabIndex = 2
        Me.btncutoff.Text = "Cut Off"
        Me.btncutoff.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btncutoff.UseVisualStyleBackColor = False
        '
        'btnlogout
        '
        Me.btnlogout.BackColor = System.Drawing.Color.White
        Me.btnlogout.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnlogout.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.btnlogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnlogout.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnlogout.ForeColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.btnlogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnlogout.Location = New System.Drawing.Point(0, 0)
        Me.btnlogout.Name = "btnlogout"
        Me.btnlogout.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.btnlogout.Size = New System.Drawing.Size(218, 31)
        Me.btnlogout.TabIndex = 1
        Me.btnlogout.Text = "Logout"
        Me.btnlogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnlogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnlogout.UseVisualStyleBackColor = False
        '
        'btnsettings
        '
        Me.btnsettings.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.btnsettings.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnsettings.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnsettings.FlatAppearance.BorderSize = 0
        Me.btnsettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.btnsettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnsettings.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsettings.ForeColor = System.Drawing.Color.White
        Me.btnsettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnsettings.Location = New System.Drawing.Point(0, 0)
        Me.btnsettings.Name = "btnsettings"
        Me.btnsettings.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.btnsettings.Size = New System.Drawing.Size(218, 51)
        Me.btnsettings.TabIndex = 1
        Me.btnsettings.Text = "SETTINGS"
        Me.btnsettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnsettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnsettings.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.Panel2.Controls.Add(Me.btnminimize)
        Me.Panel2.Controls.Add(Me.maximize)
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.lbldatetime)
        Me.Panel2.Controls.Add(Me.lblheader)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(235, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(564, 29)
        Me.Panel2.TabIndex = 1
        '
        'btnminimize
        '
        Me.btnminimize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnminimize.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnminimize.FlatAppearance.BorderSize = 0
        Me.btnminimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnminimize.Font = New System.Drawing.Font("Arial Rounded MT Bold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnminimize.ForeColor = System.Drawing.Color.White
        Me.btnminimize.Image = CType(resources.GetObject("btnminimize.Image"), System.Drawing.Image)
        Me.btnminimize.Location = New System.Drawing.Point(498, 3)
        Me.btnminimize.Name = "btnminimize"
        Me.btnminimize.Size = New System.Drawing.Size(28, 23)
        Me.btnminimize.TabIndex = 4
        Me.btnminimize.UseVisualStyleBackColor = True
        '
        'maximize
        '
        Me.maximize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.maximize.Image = CType(resources.GetObject("maximize.Image"), System.Drawing.Image)
        Me.maximize.Location = New System.Drawing.Point(528, 0)
        Me.maximize.Name = "maximize"
        Me.maximize.Size = New System.Drawing.Size(36, 27)
        Me.maximize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.maximize.TabIndex = 0
        Me.maximize.TabStop = False
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Gold
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1, 28)
        Me.Panel4.TabIndex = 3
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Gold
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 28)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(564, 1)
        Me.Panel3.TabIndex = 2
        '
        'lbldatetime
        '
        Me.lbldatetime.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbldatetime.AutoSize = True
        Me.lbldatetime.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldatetime.ForeColor = System.Drawing.Color.White
        Me.lbldatetime.Location = New System.Drawing.Point(303, 9)
        Me.lbldatetime.Name = "lbldatetime"
        Me.lbldatetime.Size = New System.Drawing.Size(113, 14)
        Me.lbldatetime.TabIndex = 1
        Me.lbldatetime.Text = "DATE_TIME_NOW"
        '
        'lblheader
        '
        Me.lblheader.AutoSize = True
        Me.lblheader.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblheader.ForeColor = System.Drawing.Color.White
        Me.lblheader.Location = New System.Drawing.Point(5, 5)
        Me.lblheader.Name = "lblheader"
        Me.lblheader.Size = New System.Drawing.Size(292, 18)
        Me.lblheader.TabIndex = 0
        Me.lblheader.Text = "ATLANTIC BAKERY (PRODUCTION)"
        '
        'Timer2
        '
        Me.Timer2.Enabled = True
        '
        'panelchildform
        '
        Me.panelchildform.BackColor = System.Drawing.Color.White
        Me.panelchildform.BackgroundImage = Global.AK_POS.My.Resources.Resources.logo
        Me.panelchildform.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.panelchildform.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelchildform.Location = New System.Drawing.Point(235, 29)
        Me.panelchildform.Name = "panelchildform"
        Me.panelchildform.Size = New System.Drawing.Size(564, 305)
        Me.panelchildform.TabIndex = 2
        '
        'main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(799, 334)
        Me.Controls.Add(Me.panelchildform)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Atlantic Bakery"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.panelsuborders.ResumeLayout(False)
        Me.panelsubusers.ResumeLayout(False)
        Me.panelsubsales.ResumeLayout(False)
        Me.panelsubinventorytransaction.ResumeLayout(False)
        Me.panelsubreports.ResumeLayout(False)
        Me.panelsubitems.ResumeLayout(False)
        Me.panelsubsettings.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.maximize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents panelsubsettings As Panel
    Friend WithEvents btncutoff As Button
    Friend WithEvents btnlogout As Button
    Friend WithEvents btnsettings As Button
    Friend WithEvents panelsubitems As Panel
    Friend WithEvents btnitemimage As Button
    Friend WithEvents btnmanageitem As Button
    Friend WithEvents btnitems As Button
    Friend WithEvents panelsubreports As Panel
    Friend WithEvents btnreports As Button
    Friend WithEvents panelsubinventorytransaction As Panel
    Friend WithEvents btncreatenew As Button
    Friend WithEvents btninvtrans As Button
    Friend WithEvents btnsales As Button
    Friend WithEvents panelsubsales As Panel
    Friend WithEvents btnbranches As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents panelchildform As Panel
    Friend WithEvents lblheader As Label
    Friend WithEvents btnusers As Button
    Friend WithEvents panelsubusers As Panel
    Friend WithEvents btnmanusers As Button
    Friend WithEvents btnpos As Button
    Friend WithEvents btnapdep As Button
    Friend WithEvents btninvlogssales As Button
    Friend WithEvents btnconvlogssales As Button
    Friend WithEvents lbldatetime As Label
    Friend WithEvents btnlogs As Button
    Friend WithEvents btnorders As Button
    Friend WithEvents panelsuborders As Panel
    Friend WithEvents btnpendingorder As Button
    Friend WithEvents btnorderhistory As Button
    Friend WithEvents btnmancustomers As Button
    Friend WithEvents btndischarge As Button
    Friend WithEvents btnitemprice As Button
    Friend WithEvents btnordertrans As Button
    Friend WithEvents Timer2 As Timer
    Friend WithEvents btnprintreports As Button
    Friend WithEvents btncoffeeshop As Button
    Friend WithEvents btnsapupload As Button
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents maximize As PictureBox
    Friend WithEvents btnminimize As Button
    Friend WithEvents btnReceivedSAP As Button
    Friend WithEvents btnCategory As Button
    Friend WithEvents btntransfer As Button
    Friend WithEvents btnrecsup As Button
    Friend WithEvents btnrecbranch As Button
    Friend WithEvents btnrecprod As Button
    Friend WithEvents btnPullOut As Button
    Friend WithEvents btnRemarks As Button
    Friend WithEvents btneditsap As Button
    Friend WithEvents btnrectrans As Button
    Friend WithEvents btnendingbalance As Button
    Friend WithEvents btninventory As Button
    Friend WithEvents btnpendingsap As Button
    Friend WithEvents btnarsales As Button
    Friend WithEvents bntarcharge As Button
    Friend WithEvents btnconversion As Button
    Friend WithEvents btnadjustmentout As Button
    Friend WithEvents btnadjustmentin As Button
End Class
