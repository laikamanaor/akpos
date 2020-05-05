<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class drawerr
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnaddnew = New System.Windows.Forms.Button()
        Me.btncashout = New System.Windows.Forms.Button()
        Me.btnlogs = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbcashier = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dt = New System.Windows.Forms.DateTimePicker()
        Me.dgvlists = New System.Windows.Forms.DataGridView()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.systemid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cashiername = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.available = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.amt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.datecreated = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.processedby = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.typee = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btncashcount = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        CType(Me.dgvlists, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnaddnew
        '
        Me.btnaddnew.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnaddnew.BackColor = System.Drawing.Color.ForestGreen
        Me.btnaddnew.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnaddnew.FlatAppearance.BorderSize = 0
        Me.btnaddnew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.btnaddnew.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnaddnew.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnaddnew.ForeColor = System.Drawing.Color.White
        Me.btnaddnew.Location = New System.Drawing.Point(808, 204)
        Me.btnaddnew.Name = "btnaddnew"
        Me.btnaddnew.Size = New System.Drawing.Size(137, 26)
        Me.btnaddnew.TabIndex = 1
        Me.btnaddnew.Text = "Add New"
        Me.btnaddnew.UseVisualStyleBackColor = False
        '
        'btncashout
        '
        Me.btncashout.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btncashout.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.btncashout.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btncashout.FlatAppearance.BorderSize = 0
        Me.btncashout.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.HotTrack
        Me.btncashout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btncashout.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btncashout.ForeColor = System.Drawing.Color.White
        Me.btncashout.Location = New System.Drawing.Point(726, 97)
        Me.btncashout.Name = "btncashout"
        Me.btncashout.Size = New System.Drawing.Size(219, 36)
        Me.btncashout.TabIndex = 8
        Me.btncashout.Text = "CASH OUT FOR DEPOSIT"
        Me.btncashout.UseVisualStyleBackColor = False
        '
        'btnlogs
        '
        Me.btnlogs.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnlogs.BackColor = System.Drawing.Color.ForestGreen
        Me.btnlogs.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnlogs.FlatAppearance.BorderSize = 0
        Me.btnlogs.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.btnlogs.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnlogs.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnlogs.ForeColor = System.Drawing.Color.White
        Me.btnlogs.Location = New System.Drawing.Point(480, 97)
        Me.btnlogs.Name = "btnlogs"
        Me.btnlogs.Size = New System.Drawing.Size(93, 36)
        Me.btnlogs.TabIndex = 9
        Me.btnlogs.Text = "LOGS"
        Me.btnlogs.UseVisualStyleBackColor = False
        Me.btnlogs.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(59, 213)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 15)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Cashier:"
        '
        'cmbcashier
        '
        Me.cmbcashier.BackColor = System.Drawing.Color.DodgerBlue
        Me.cmbcashier.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbcashier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbcashier.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbcashier.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbcashier.ForeColor = System.Drawing.Color.White
        Me.cmbcashier.FormattingEnabled = True
        Me.cmbcashier.Location = New System.Drawing.Point(120, 206)
        Me.cmbcashier.Name = "cmbcashier"
        Me.cmbcashier.Size = New System.Drawing.Size(237, 25)
        Me.cmbcashier.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(364, 213)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 15)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Date:"
        '
        'dt
        '
        Me.dt.CustomFormat = "MM/dd/yyyy"
        Me.dt.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dt.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dt.Location = New System.Drawing.Point(412, 205)
        Me.dt.Name = "dt"
        Me.dt.Size = New System.Drawing.Size(103, 25)
        Me.dt.TabIndex = 12
        '
        'dgvlists
        '
        Me.dgvlists.AllowUserToAddRows = False
        Me.dgvlists.AllowUserToDeleteRows = False
        Me.dgvlists.AllowUserToResizeColumns = False
        Me.dgvlists.AllowUserToResizeRows = False
        Me.dgvlists.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvlists.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvlists.BackgroundColor = System.Drawing.Color.White
        Me.dgvlists.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvlists.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvlists.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvlists.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvlists.ColumnHeadersHeight = 40
        Me.dgvlists.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.systemid, Me.cashiername, Me.available, Me.amt, Me.description, Me.datecreated, Me.processedby, Me.typee})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvlists.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgvlists.EnableHeadersVisualStyles = False
        Me.dgvlists.Location = New System.Drawing.Point(60, 232)
        Me.dgvlists.Name = "dgvlists"
        Me.dgvlists.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvlists.RowHeadersVisible = False
        Me.dgvlists.Size = New System.Drawing.Size(885, 186)
        Me.dgvlists.TabIndex = 14
        '
        'id
        '
        Me.id.HeaderText = "ID"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        '
        'systemid
        '
        Me.systemid.HeaderText = "ID"
        Me.systemid.Name = "systemid"
        Me.systemid.ReadOnly = True
        Me.systemid.Visible = False
        '
        'cashiername
        '
        Me.cashiername.HeaderText = "Name"
        Me.cashiername.Name = "cashiername"
        Me.cashiername.ReadOnly = True
        '
        'available
        '
        Me.available.HeaderText = "Available"
        Me.available.Name = "available"
        Me.available.ReadOnly = True
        '
        'amt
        '
        Me.amt.HeaderText = "Amount"
        Me.amt.Name = "amt"
        Me.amt.ReadOnly = True
        '
        'description
        '
        Me.description.HeaderText = "Description"
        Me.description.Name = "description"
        Me.description.ReadOnly = True
        '
        'datecreated
        '
        Me.datecreated.HeaderText = "Date"
        Me.datecreated.Name = "datecreated"
        Me.datecreated.ReadOnly = True
        '
        'processedby
        '
        Me.processedby.HeaderText = "Processed By"
        Me.processedby.Name = "processedby"
        Me.processedby.ReadOnly = True
        '
        'typee
        '
        Me.typee.HeaderText = "Type"
        Me.typee.Name = "typee"
        Me.typee.ReadOnly = True
        '
        'btncashcount
        '
        Me.btncashcount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btncashcount.BackColor = System.Drawing.Color.ForestGreen
        Me.btncashcount.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btncashcount.FlatAppearance.BorderSize = 0
        Me.btncashcount.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.HotTrack
        Me.btncashcount.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btncashcount.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btncashcount.ForeColor = System.Drawing.Color.White
        Me.btncashcount.Location = New System.Drawing.Point(579, 97)
        Me.btncashcount.Name = "btncashcount"
        Me.btncashcount.Size = New System.Drawing.Size(141, 36)
        Me.btncashcount.TabIndex = 15
        Me.btncashcount.Text = "CASH COUNT"
        Me.btncashcount.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(994, 45)
        Me.Panel1.TabIndex = 16
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(58, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(157, 22)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "CASHIER LOGS"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Gold
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1, 45)
        Me.Panel2.TabIndex = 1
        '
        'drawerr
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(994, 457)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btncashcount)
        Me.Controls.Add(Me.dgvlists)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dt)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmbcashier)
        Me.Controls.Add(Me.btnlogs)
        Me.Controls.Add(Me.btncashout)
        Me.Controls.Add(Me.btnaddnew)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "drawerr"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cashier Logs"
        CType(Me.dgvlists, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnaddnew As System.Windows.Forms.Button
    Friend WithEvents btncashout As System.Windows.Forms.Button
    Friend WithEvents btnlogs As System.Windows.Forms.Button
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbcashier As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents dt As DateTimePicker
    Friend WithEvents dgvlists As DataGridView
    Friend WithEvents btncashcount As Button
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents systemid As DataGridViewTextBoxColumn
    Friend WithEvents cashiername As DataGridViewTextBoxColumn
    Friend WithEvents available As DataGridViewTextBoxColumn
    Friend WithEvents amt As DataGridViewTextBoxColumn
    Friend WithEvents description As DataGridViewTextBoxColumn
    Friend WithEvents datecreated As DataGridViewTextBoxColumn
    Friend WithEvents processedby As DataGridViewTextBoxColumn
    Friend WithEvents typee As DataGridViewTextBoxColumn
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel2 As Panel
End Class
