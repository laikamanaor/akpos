<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class overwrite_short
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnsubmit = New System.Windows.Forms.Button()
        Me.dgv_lists = New System.Windows.Forms.DataGridView()
        Me.itemcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.itemname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.charge = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.employee = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnadd = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lbllist_count = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lblselected_count = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtsearch_selected = New System.Windows.Forms.TextBox()
        Me.txtsearch_lists = New System.Windows.Forms.TextBox()
        Me.btnsearch_lists = New System.Windows.Forms.Button()
        Me.btnsearch_selected = New System.Windows.Forms.Button()
        Me.dgv_selected = New System.Windows.Forms.DataGridView()
        Me.itemcode2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.itemname2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.qty2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.charge2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.employee2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        CType(Me.dgv_lists, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.dgv_selected, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(918, 39)
        Me.Panel1.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Gold
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1, 39)
        Me.Panel2.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(201, 22)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "OVERWRITE SHORT"
        '
        'btnsubmit
        '
        Me.btnsubmit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnsubmit.BackColor = System.Drawing.Color.ForestGreen
        Me.btnsubmit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnsubmit.FlatAppearance.BorderSize = 0
        Me.btnsubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnsubmit.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsubmit.ForeColor = System.Drawing.Color.White
        Me.btnsubmit.Location = New System.Drawing.Point(737, 507)
        Me.btnsubmit.Name = "btnsubmit"
        Me.btnsubmit.Size = New System.Drawing.Size(130, 44)
        Me.btnsubmit.TabIndex = 0
        Me.btnsubmit.Text = "SUBMIT"
        Me.btnsubmit.UseVisualStyleBackColor = False
        '
        'dgv_lists
        '
        Me.dgv_lists.AllowUserToAddRows = False
        Me.dgv_lists.AllowUserToDeleteRows = False
        Me.dgv_lists.AllowUserToResizeColumns = False
        Me.dgv_lists.AllowUserToResizeRows = False
        Me.dgv_lists.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_lists.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgv_lists.BackgroundColor = System.Drawing.Color.White
        Me.dgv_lists.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgv_lists.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgv_lists.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_lists.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_lists.ColumnHeadersHeight = 30
        Me.dgv_lists.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.itemcode, Me.itemname, Me.qty, Me.charge, Me.employee, Me.btnadd})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_lists.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgv_lists.EnableHeadersVisualStyles = False
        Me.dgv_lists.Location = New System.Drawing.Point(49, 137)
        Me.dgv_lists.Name = "dgv_lists"
        Me.dgv_lists.RowHeadersVisible = False
        Me.dgv_lists.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_lists.Size = New System.Drawing.Size(818, 167)
        Me.dgv_lists.TabIndex = 1
        '
        'itemcode
        '
        Me.itemcode.HeaderText = "Code"
        Me.itemcode.Name = "itemcode"
        Me.itemcode.ReadOnly = True
        '
        'itemname
        '
        Me.itemname.HeaderText = "Name"
        Me.itemname.Name = "itemname"
        Me.itemname.ReadOnly = True
        '
        'qty
        '
        Me.qty.HeaderText = "Quantity"
        Me.qty.Name = "qty"
        Me.qty.ReadOnly = True
        '
        'charge
        '
        Me.charge.HeaderText = "Charge"
        Me.charge.Name = "charge"
        Me.charge.ReadOnly = True
        '
        'employee
        '
        Me.employee.HeaderText = "Employee"
        Me.employee.Name = "employee"
        Me.employee.ReadOnly = True
        '
        'btnadd
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.ForestGreen
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        Me.btnadd.DefaultCellStyle = DataGridViewCellStyle2
        Me.btnadd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnadd.HeaderText = "Add"
        Me.btnadd.Name = "btnadd"
        Me.btnadd.ReadOnly = True
        Me.btnadd.Text = "Add"
        Me.btnadd.UseColumnTextForButtonValue = True
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.Panel3.Controls.Add(Me.lbllist_count)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Location = New System.Drawing.Point(49, 117)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(818, 21)
        Me.Panel3.TabIndex = 3
        '
        'lbllist_count
        '
        Me.lbllist_count.AutoSize = True
        Me.lbllist_count.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbllist_count.ForeColor = System.Drawing.Color.White
        Me.lbllist_count.Location = New System.Drawing.Point(101, 5)
        Me.lbllist_count.Name = "lbllist_count"
        Me.lbllist_count.Size = New System.Drawing.Size(14, 14)
        Me.lbllist_count.TabIndex = 1
        Me.lbllist_count.Text = "0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(3, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 14)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "LIST OF ITEMS:"
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.Panel4.Controls.Add(Me.lblselected_count)
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Location = New System.Drawing.Point(49, 347)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(818, 21)
        Me.Panel4.TabIndex = 4
        '
        'lblselected_count
        '
        Me.lblselected_count.AutoSize = True
        Me.lblselected_count.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblselected_count.ForeColor = System.Drawing.Color.White
        Me.lblselected_count.Location = New System.Drawing.Point(119, 4)
        Me.lblselected_count.Name = "lblselected_count"
        Me.lblselected_count.Size = New System.Drawing.Size(14, 14)
        Me.lblselected_count.TabIndex = 2
        Me.lblselected_count.Text = "0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(3, 4)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(117, 14)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "SELECTED ITEMS:"
        '
        'txtsearch_selected
        '
        Me.txtsearch_selected.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsearch_selected.Location = New System.Drawing.Point(49, 321)
        Me.txtsearch_selected.Name = "txtsearch_selected"
        Me.txtsearch_selected.Size = New System.Drawing.Size(172, 23)
        Me.txtsearch_selected.TabIndex = 5
        '
        'txtsearch_lists
        '
        Me.txtsearch_lists.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsearch_lists.Location = New System.Drawing.Point(49, 91)
        Me.txtsearch_lists.Name = "txtsearch_lists"
        Me.txtsearch_lists.Size = New System.Drawing.Size(172, 23)
        Me.txtsearch_lists.TabIndex = 6
        '
        'btnsearch_lists
        '
        Me.btnsearch_lists.BackColor = System.Drawing.SystemColors.HotTrack
        Me.btnsearch_lists.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnsearch_lists.FlatAppearance.BorderSize = 0
        Me.btnsearch_lists.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnsearch_lists.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsearch_lists.ForeColor = System.Drawing.Color.White
        Me.btnsearch_lists.Location = New System.Drawing.Point(220, 91)
        Me.btnsearch_lists.Name = "btnsearch_lists"
        Me.btnsearch_lists.Size = New System.Drawing.Size(76, 23)
        Me.btnsearch_lists.TabIndex = 7
        Me.btnsearch_lists.Text = "Search"
        Me.btnsearch_lists.UseVisualStyleBackColor = False
        '
        'btnsearch_selected
        '
        Me.btnsearch_selected.BackColor = System.Drawing.SystemColors.HotTrack
        Me.btnsearch_selected.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnsearch_selected.FlatAppearance.BorderSize = 0
        Me.btnsearch_selected.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnsearch_selected.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsearch_selected.ForeColor = System.Drawing.Color.White
        Me.btnsearch_selected.Location = New System.Drawing.Point(220, 321)
        Me.btnsearch_selected.Name = "btnsearch_selected"
        Me.btnsearch_selected.Size = New System.Drawing.Size(76, 23)
        Me.btnsearch_selected.TabIndex = 8
        Me.btnsearch_selected.Text = "Search"
        Me.btnsearch_selected.UseVisualStyleBackColor = False
        '
        'dgv_selected
        '
        Me.dgv_selected.AllowUserToAddRows = False
        Me.dgv_selected.AllowUserToDeleteRows = False
        Me.dgv_selected.AllowUserToResizeColumns = False
        Me.dgv_selected.AllowUserToResizeRows = False
        Me.dgv_selected.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_selected.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgv_selected.BackgroundColor = System.Drawing.Color.White
        Me.dgv_selected.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgv_selected.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgv_selected.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_selected.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgv_selected.ColumnHeadersHeight = 30
        Me.dgv_selected.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.itemcode2, Me.itemname2, Me.qty2, Me.charge2, Me.employee2})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_selected.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgv_selected.EnableHeadersVisualStyles = False
        Me.dgv_selected.Location = New System.Drawing.Point(49, 368)
        Me.dgv_selected.Name = "dgv_selected"
        Me.dgv_selected.RowHeadersVisible = False
        Me.dgv_selected.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_selected.Size = New System.Drawing.Size(818, 133)
        Me.dgv_selected.TabIndex = 9
        '
        'itemcode2
        '
        Me.itemcode2.HeaderText = "Code"
        Me.itemcode2.Name = "itemcode2"
        Me.itemcode2.ReadOnly = True
        '
        'itemname2
        '
        Me.itemname2.HeaderText = "Name"
        Me.itemname2.Name = "itemname2"
        Me.itemname2.ReadOnly = True
        '
        'qty2
        '
        Me.qty2.HeaderText = "Quantity"
        Me.qty2.Name = "qty2"
        Me.qty2.ReadOnly = True
        '
        'charge2
        '
        Me.charge2.HeaderText = "Charge"
        Me.charge2.Name = "charge2"
        Me.charge2.ReadOnly = True
        '
        'employee2
        '
        Me.employee2.HeaderText = "Employee"
        Me.employee2.Name = "employee2"
        Me.employee2.ReadOnly = True
        '
        'overwrite_short
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(918, 586)
        Me.Controls.Add(Me.dgv_selected)
        Me.Controls.Add(Me.btnsearch_selected)
        Me.Controls.Add(Me.btnsearch_lists)
        Me.Controls.Add(Me.txtsearch_lists)
        Me.Controls.Add(Me.txtsearch_selected)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.dgv_lists)
        Me.Controls.Add(Me.btnsubmit)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "overwrite_short"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "overwrite_short"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgv_lists, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.dgv_selected, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnsubmit As Button
    Friend WithEvents dgv_lists As DataGridView
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents txtsearch_selected As TextBox
    Friend WithEvents txtsearch_lists As TextBox
    Friend WithEvents btnsearch_lists As Button
    Friend WithEvents btnsearch_selected As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents lbllist_count As Label
    Friend WithEvents lblselected_count As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents dgv_selected As DataGridView
    Friend WithEvents itemcode2 As DataGridViewTextBoxColumn
    Friend WithEvents itemname2 As DataGridViewTextBoxColumn
    Friend WithEvents qty2 As DataGridViewTextBoxColumn
    Friend WithEvents charge2 As DataGridViewTextBoxColumn
    Friend WithEvents employee2 As DataGridViewTextBoxColumn
    Friend WithEvents itemcode As DataGridViewTextBoxColumn
    Friend WithEvents itemname As DataGridViewTextBoxColumn
    Friend WithEvents qty As DataGridViewTextBoxColumn
    Friend WithEvents charge As DataGridViewTextBoxColumn
    Friend WithEvents employee As DataGridViewTextBoxColumn
    Friend WithEvents btnadd As DataGridViewButtonColumn
End Class
