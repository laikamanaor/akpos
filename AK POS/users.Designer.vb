<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class users
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btncancel = New System.Windows.Forms.Button()
        Me.link = New System.Windows.Forms.LinkLabel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtconfirm = New System.Windows.Forms.TextBox()
        Me.lbluserid = New System.Windows.Forms.Label()
        Me.chkpass = New System.Windows.Forms.CheckBox()
        Me.btnviewall = New System.Windows.Forms.Button()
        Me.btndeactivate = New System.Windows.Forms.Button()
        Me.btnupdate = New System.Windows.Forms.Button()
        Me.btnadd = New System.Windows.Forms.Button()
        Me.cmbgroup = New System.Windows.Forms.ComboBox()
        Me.txtpass = New System.Windows.Forms.TextBox()
        Me.txtusername = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grdusers = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.branch = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.postype = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtfull = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblcas = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbraout = New System.Windows.Forms.ComboBox()
        Me.cmbpostype = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        CType(Me.grdusers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btncancel
        '
        Me.btncancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btncancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.btncancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btncancel.Enabled = False
        Me.btncancel.FlatAppearance.BorderSize = 0
        Me.btncancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btncancel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btncancel.ForeColor = System.Drawing.Color.White
        Me.btncancel.Location = New System.Drawing.Point(739, 268)
        Me.btncancel.Name = "btncancel"
        Me.btncancel.Size = New System.Drawing.Size(73, 30)
        Me.btncancel.TabIndex = 9
        Me.btncancel.Text = "Cancel"
        Me.btncancel.UseVisualStyleBackColor = False
        '
        'link
        '
        Me.link.AutoSize = True
        Me.link.Cursor = System.Windows.Forms.Cursors.Hand
        Me.link.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.link.LinkColor = System.Drawing.Color.Red
        Me.link.Location = New System.Drawing.Point(289, 204)
        Me.link.Name = "link"
        Me.link.Size = New System.Drawing.Size(90, 13)
        Me.link.TabIndex = 11
        Me.link.TabStop = True
        Me.link.Text = "Change Password"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(477, 121)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(116, 15)
        Me.Label4.TabIndex = 31
        Me.Label4.Text = "Confirm Password:"
        '
        'txtconfirm
        '
        Me.txtconfirm.Enabled = False
        Me.txtconfirm.Location = New System.Drawing.Point(599, 119)
        Me.txtconfirm.Name = "txtconfirm"
        Me.txtconfirm.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtconfirm.Size = New System.Drawing.Size(213, 20)
        Me.txtconfirm.TabIndex = 3
        '
        'lbluserid
        '
        Me.lbluserid.AutoSize = True
        Me.lbluserid.Location = New System.Drawing.Point(12, 25)
        Me.lbluserid.Name = "lbluserid"
        Me.lbluserid.Size = New System.Drawing.Size(0, 13)
        Me.lbluserid.TabIndex = 30
        Me.lbluserid.Visible = False
        '
        'chkpass
        '
        Me.chkpass.AutoSize = True
        Me.chkpass.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkpass.Enabled = False
        Me.chkpass.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.chkpass.Location = New System.Drawing.Point(385, 184)
        Me.chkpass.Name = "chkpass"
        Me.chkpass.Size = New System.Drawing.Size(52, 17)
        Me.chkpass.TabIndex = 10
        Me.chkpass.Text = "Show"
        Me.chkpass.UseVisualStyleBackColor = True
        '
        'btnviewall
        '
        Me.btnviewall.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnviewall.BackColor = System.Drawing.SystemColors.HotTrack
        Me.btnviewall.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnviewall.FlatAppearance.BorderSize = 0
        Me.btnviewall.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnviewall.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnviewall.ForeColor = System.Drawing.Color.White
        Me.btnviewall.Location = New System.Drawing.Point(662, 268)
        Me.btnviewall.Name = "btnviewall"
        Me.btnviewall.Size = New System.Drawing.Size(76, 30)
        Me.btnviewall.TabIndex = 8
        Me.btnviewall.Text = "View All"
        Me.btnviewall.UseVisualStyleBackColor = False
        '
        'btndeactivate
        '
        Me.btndeactivate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btndeactivate.BackColor = System.Drawing.Color.Maroon
        Me.btndeactivate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btndeactivate.FlatAppearance.BorderSize = 0
        Me.btndeactivate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btndeactivate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btndeactivate.ForeColor = System.Drawing.Color.White
        Me.btndeactivate.Location = New System.Drawing.Point(570, 268)
        Me.btndeactivate.Name = "btndeactivate"
        Me.btndeactivate.Size = New System.Drawing.Size(91, 30)
        Me.btndeactivate.TabIndex = 7
        Me.btndeactivate.Text = "Deactivate"
        Me.btndeactivate.UseVisualStyleBackColor = False
        '
        'btnupdate
        '
        Me.btnupdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnupdate.BackColor = System.Drawing.Color.BlueViolet
        Me.btnupdate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnupdate.FlatAppearance.BorderSize = 0
        Me.btnupdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnupdate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnupdate.ForeColor = System.Drawing.Color.White
        Me.btnupdate.Location = New System.Drawing.Point(487, 268)
        Me.btnupdate.Name = "btnupdate"
        Me.btnupdate.Size = New System.Drawing.Size(82, 30)
        Me.btnupdate.TabIndex = 6
        Me.btnupdate.Text = "Update"
        Me.btnupdate.UseVisualStyleBackColor = False
        '
        'btnadd
        '
        Me.btnadd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnadd.BackColor = System.Drawing.Color.ForestGreen
        Me.btnadd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnadd.FlatAppearance.BorderSize = 0
        Me.btnadd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnadd.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnadd.ForeColor = System.Drawing.Color.White
        Me.btnadd.Location = New System.Drawing.Point(428, 268)
        Me.btnadd.Name = "btnadd"
        Me.btnadd.Size = New System.Drawing.Size(58, 30)
        Me.btnadd.TabIndex = 5
        Me.btnadd.Text = "Add"
        Me.btnadd.UseVisualStyleBackColor = False
        '
        'cmbgroup
        '
        Me.cmbgroup.BackColor = System.Drawing.Color.DodgerBlue
        Me.cmbgroup.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbgroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbgroup.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbgroup.ForeColor = System.Drawing.Color.White
        Me.cmbgroup.FormattingEnabled = True
        Me.cmbgroup.Items.AddRange(New Object() {"Cashier", "Sales", "Manager", "Administrator", "Production", "LC Accounting"})
        Me.cmbgroup.Location = New System.Drawing.Point(599, 151)
        Me.cmbgroup.Name = "cmbgroup"
        Me.cmbgroup.Size = New System.Drawing.Size(213, 21)
        Me.cmbgroup.TabIndex = 4
        '
        'txtpass
        '
        Me.txtpass.Location = New System.Drawing.Point(166, 180)
        Me.txtpass.Name = "txtpass"
        Me.txtpass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtpass.Size = New System.Drawing.Size(213, 20)
        Me.txtpass.TabIndex = 2
        '
        'txtusername
        '
        Me.txtusername.Location = New System.Drawing.Point(166, 151)
        Me.txtusername.Name = "txtusername"
        Me.txtusername.Size = New System.Drawing.Size(213, 20)
        Me.txtusername.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(477, 153)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 15)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Workgroup:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(44, 180)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 15)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Password:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(43, 151)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 15)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Username:"
        '
        'grdusers
        '
        Me.grdusers.AllowUserToAddRows = False
        Me.grdusers.AllowUserToDeleteRows = False
        Me.grdusers.AllowUserToResizeRows = False
        Me.grdusers.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdusers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grdusers.BackgroundColor = System.Drawing.Color.White
        Me.grdusers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.grdusers.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.grdusers.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdusers.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.grdusers.ColumnHeadersHeight = 40
        Me.grdusers.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column7, Me.Column2, Me.Column3, Me.Column4, Me.branch, Me.Column5, Me.Column6, Me.postype})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdusers.DefaultCellStyle = DataGridViewCellStyle6
        Me.grdusers.EnableHeadersVisualStyles = False
        Me.grdusers.Location = New System.Drawing.Point(47, 304)
        Me.grdusers.Name = "grdusers"
        Me.grdusers.ReadOnly = True
        Me.grdusers.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.grdusers.RowHeadersVisible = False
        Me.grdusers.RowHeadersWidth = 10
        Me.grdusers.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.grdusers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdusers.Size = New System.Drawing.Size(765, 279)
        Me.grdusers.TabIndex = 12
        '
        'Column1
        '
        Me.Column1.HeaderText = "userid"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Visible = False
        '
        'Column7
        '
        Me.Column7.HeaderText = "Full Name"
        Me.Column7.MinimumWidth = 164
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "Username"
        Me.Column2.MinimumWidth = 164
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "Password"
        Me.Column3.MinimumWidth = 120
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Column4
        '
        Me.Column4.HeaderText = "Workgroup"
        Me.Column4.MinimumWidth = 120
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'branch
        '
        Me.branch.HeaderText = "Branch/Outlet"
        Me.branch.Name = "branch"
        Me.branch.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.HeaderText = "Status"
        Me.Column5.MinimumWidth = 100
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.HeaderText = "pass"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Visible = False
        '
        'postype
        '
        Me.postype.HeaderText = "POS type"
        Me.postype.Name = "postype"
        Me.postype.ReadOnly = True
        '
        'txtfull
        '
        Me.txtfull.Location = New System.Drawing.Point(166, 122)
        Me.txtfull.Name = "txtfull"
        Me.txtfull.Size = New System.Drawing.Size(213, 20)
        Me.txtfull.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(44, 120)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 15)
        Me.Label5.TabIndex = 34
        Me.Label5.Text = "Full Name:"
        '
        'lblcas
        '
        Me.lblcas.AutoSize = True
        Me.lblcas.Location = New System.Drawing.Point(340, 106)
        Me.lblcas.Name = "lblcas"
        Me.lblcas.Size = New System.Drawing.Size(0, 13)
        Me.lblcas.TabIndex = 35
        Me.lblcas.Visible = False
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Vivaldi", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label6.Location = New System.Drawing.Point(9, 586)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 13)
        Me.Label6.TabIndex = 42
        Me.Label6.Text = "-Jecel-"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(476, 186)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 15)
        Me.Label7.TabIndex = 44
        Me.Label7.Text = "Branch/Outlet:"
        '
        'cmbraout
        '
        Me.cmbraout.BackColor = System.Drawing.Color.DodgerBlue
        Me.cmbraout.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbraout.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbraout.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbraout.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbraout.ForeColor = System.Drawing.Color.White
        Me.cmbraout.FormattingEnabled = True
        Me.cmbraout.Location = New System.Drawing.Point(599, 184)
        Me.cmbraout.Name = "cmbraout"
        Me.cmbraout.Size = New System.Drawing.Size(213, 21)
        Me.cmbraout.TabIndex = 51
        '
        'cmbpostype
        '
        Me.cmbpostype.BackColor = System.Drawing.Color.DodgerBlue
        Me.cmbpostype.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbpostype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbpostype.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbpostype.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbpostype.ForeColor = System.Drawing.Color.White
        Me.cmbpostype.FormattingEnabled = True
        Me.cmbpostype.Items.AddRange(New Object() {"Retail", "Wholesale", "Coffee Shop"})
        Me.cmbpostype.Location = New System.Drawing.Point(599, 221)
        Me.cmbpostype.Name = "cmbpostype"
        Me.cmbpostype.Size = New System.Drawing.Size(213, 21)
        Me.cmbpostype.TabIndex = 53
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(476, 223)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(64, 15)
        Me.Label8.TabIndex = 52
        Me.Label8.Text = "POS Type:"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(857, 38)
        Me.Panel1.TabIndex = 54
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Gold
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1, 38)
        Me.Panel2.TabIndex = 56
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(43, 9)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(77, 22)
        Me.Label9.TabIndex = 55
        Me.Label9.Text = "USERS"
        '
        'users
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(857, 603)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.cmbpostype)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cmbraout)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lblcas)
        Me.Controls.Add(Me.txtfull)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btncancel)
        Me.Controls.Add(Me.link)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtconfirm)
        Me.Controls.Add(Me.lbluserid)
        Me.Controls.Add(Me.chkpass)
        Me.Controls.Add(Me.btnviewall)
        Me.Controls.Add(Me.btndeactivate)
        Me.Controls.Add(Me.btnupdate)
        Me.Controls.Add(Me.btnadd)
        Me.Controls.Add(Me.cmbgroup)
        Me.Controls.Add(Me.txtpass)
        Me.Controls.Add(Me.txtusername)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.grdusers)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "users"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Manage Users"
        CType(Me.grdusers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btncancel As System.Windows.Forms.Button
    Friend WithEvents link As System.Windows.Forms.LinkLabel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtconfirm As System.Windows.Forms.TextBox
    Friend WithEvents lbluserid As System.Windows.Forms.Label
    Friend WithEvents chkpass As System.Windows.Forms.CheckBox
    Friend WithEvents btnviewall As System.Windows.Forms.Button
    Friend WithEvents btndeactivate As System.Windows.Forms.Button
    Friend WithEvents btnupdate As System.Windows.Forms.Button
    Friend WithEvents btnadd As System.Windows.Forms.Button
    Friend WithEvents cmbgroup As System.Windows.Forms.ComboBox
    Friend WithEvents txtpass As System.Windows.Forms.TextBox
    Friend WithEvents txtusername As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grdusers As System.Windows.Forms.DataGridView
    Friend WithEvents txtfull As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblcas As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As Label
    Friend WithEvents cmbraout As ComboBox
    Friend WithEvents cmbpostype As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents branch As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents postype As DataGridViewTextBoxColumn
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label9 As Label
End Class
