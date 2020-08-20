<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditRemarks
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
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbType = New System.Windows.Forms.ComboBox()
        Me.dtDate = New System.Windows.Forms.DateTimePicker()
        Me.lblheader = New System.Windows.Forms.Label()
        Me.btnEditRemarks = New System.Windows.Forms.Button()
        Me.panelremarks = New System.Windows.Forms.Panel()
        Me.lblcloseRemarks = New System.Windows.Forms.Label()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.selectt = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.transid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.itemname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.quantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.transferTo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.remarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sap = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sapnum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rbEdit = New System.Windows.Forms.RadioButton()
        Me.rbConcat = New System.Windows.Forms.RadioButton()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.panelremarks.SuspendLayout()
        Me.SuspendLayout()
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
        Me.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgv.BackgroundColor = System.Drawing.Color.White
        Me.dgv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgv.ColumnHeadersHeight = 40
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.selectt, Me.transid, Me.itemname, Me.quantity, Me.transferTo, Me.remarks, Me.sap, Me.sapnum})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgv.EnableHeadersVisualStyles = False
        Me.dgv.GridColor = System.Drawing.Color.Black
        Me.dgv.Location = New System.Drawing.Point(49, 102)
        Me.dgv.Name = "dgv"
        Me.dgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgv.RowHeadersVisible = False
        Me.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv.Size = New System.Drawing.Size(766, 264)
        Me.dgv.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(867, 34)
        Me.Panel1.TabIndex = 11
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(3, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(158, 22)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "EDIT REMARKS"
        '
        'cmbType
        '
        Me.cmbType.BackColor = System.Drawing.Color.DodgerBlue
        Me.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbType.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbType.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbType.ForeColor = System.Drawing.Color.White
        Me.cmbType.FormattingEnabled = True
        Me.cmbType.Items.AddRange(New Object() {"Select Type", "Received Item", "Transfer Item"})
        Me.cmbType.Location = New System.Drawing.Point(49, 73)
        Me.cmbType.Name = "cmbType"
        Me.cmbType.Size = New System.Drawing.Size(189, 25)
        Me.cmbType.TabIndex = 12
        '
        'dtDate
        '
        Me.dtDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtDate.CustomFormat = "MM/dd/yyyy"
        Me.dtDate.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtDate.Location = New System.Drawing.Point(689, 73)
        Me.dtDate.Name = "dtDate"
        Me.dtDate.Size = New System.Drawing.Size(126, 25)
        Me.dtDate.TabIndex = 13
        '
        'lblheader
        '
        Me.lblheader.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblheader.AutoSize = True
        Me.lblheader.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblheader.ForeColor = System.Drawing.Color.DimGray
        Me.lblheader.Location = New System.Drawing.Point(363, 183)
        Me.lblheader.Name = "lblheader"
        Me.lblheader.Size = New System.Drawing.Size(150, 22)
        Me.lblheader.TabIndex = 14
        Me.lblheader.Text = "No fetch data :("
        '
        'btnEditRemarks
        '
        Me.btnEditRemarks.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEditRemarks.BackColor = System.Drawing.Color.ForestGreen
        Me.btnEditRemarks.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEditRemarks.FlatAppearance.BorderSize = 0
        Me.btnEditRemarks.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEditRemarks.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditRemarks.ForeColor = System.Drawing.Color.White
        Me.btnEditRemarks.Location = New System.Drawing.Point(699, 372)
        Me.btnEditRemarks.Name = "btnEditRemarks"
        Me.btnEditRemarks.Size = New System.Drawing.Size(116, 36)
        Me.btnEditRemarks.TabIndex = 15
        Me.btnEditRemarks.Text = "Edit"
        Me.btnEditRemarks.UseVisualStyleBackColor = False
        '
        'panelremarks
        '
        Me.panelremarks.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.panelremarks.BackColor = System.Drawing.Color.DodgerBlue
        Me.panelremarks.Controls.Add(Me.rbConcat)
        Me.panelremarks.Controls.Add(Me.rbEdit)
        Me.panelremarks.Controls.Add(Me.lblcloseRemarks)
        Me.panelremarks.Controls.Add(Me.btnUpdate)
        Me.panelremarks.Controls.Add(Me.txtRemarks)
        Me.panelremarks.Controls.Add(Me.Label1)
        Me.panelremarks.Location = New System.Drawing.Point(258, 118)
        Me.panelremarks.Name = "panelremarks"
        Me.panelremarks.Size = New System.Drawing.Size(346, 248)
        Me.panelremarks.TabIndex = 16
        Me.panelremarks.Visible = False
        '
        'lblcloseRemarks
        '
        Me.lblcloseRemarks.AutoSize = True
        Me.lblcloseRemarks.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblcloseRemarks.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcloseRemarks.ForeColor = System.Drawing.Color.White
        Me.lblcloseRemarks.Location = New System.Drawing.Point(325, 2)
        Me.lblcloseRemarks.Name = "lblcloseRemarks"
        Me.lblcloseRemarks.Size = New System.Drawing.Size(18, 18)
        Me.lblcloseRemarks.TabIndex = 18
        Me.lblcloseRemarks.Text = "X"
        '
        'btnUpdate
        '
        Me.btnUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnUpdate.BackColor = System.Drawing.Color.ForestGreen
        Me.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUpdate.FlatAppearance.BorderSize = 0
        Me.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpdate.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate.ForeColor = System.Drawing.Color.White
        Me.btnUpdate.Location = New System.Drawing.Point(260, 201)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(69, 36)
        Me.btnUpdate.TabIndex = 17
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = False
        '
        'txtRemarks
        '
        Me.txtRemarks.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRemarks.Location = New System.Drawing.Point(18, 81)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(311, 114)
        Me.txtRemarks.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(15, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Remarks:"
        '
        'selectt
        '
        Me.selectt.HeaderText = "Select"
        Me.selectt.Name = "selectt"
        Me.selectt.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.selectt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'transid
        '
        Me.transid.HeaderText = "ID"
        Me.transid.Name = "transid"
        Me.transid.ReadOnly = True
        Me.transid.Visible = False
        '
        'itemname
        '
        Me.itemname.HeaderText = "Item Name"
        Me.itemname.Name = "itemname"
        '
        'quantity
        '
        Me.quantity.HeaderText = "Quantity"
        Me.quantity.Name = "quantity"
        Me.quantity.ReadOnly = True
        '
        'transferTo
        '
        Me.transferTo.HeaderText = "Transfer To"
        Me.transferTo.Name = "transferTo"
        Me.transferTo.ReadOnly = True
        '
        'remarks
        '
        Me.remarks.HeaderText = "Remarks"
        Me.remarks.Name = "remarks"
        Me.remarks.ReadOnly = True
        '
        'sap
        '
        Me.sap.HeaderText = "SAP"
        Me.sap.Name = "sap"
        Me.sap.ReadOnly = True
        '
        'sapnum
        '
        Me.sapnum.HeaderText = "SAP #"
        Me.sapnum.Name = "sapnum"
        Me.sapnum.ReadOnly = True
        '
        'rbEdit
        '
        Me.rbEdit.AutoSize = True
        Me.rbEdit.Checked = True
        Me.rbEdit.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbEdit.ForeColor = System.Drawing.Color.White
        Me.rbEdit.Location = New System.Drawing.Point(18, 36)
        Me.rbEdit.Name = "rbEdit"
        Me.rbEdit.Size = New System.Drawing.Size(104, 18)
        Me.rbEdit.TabIndex = 19
        Me.rbEdit.TabStop = True
        Me.rbEdit.Text = "Edit Remarks"
        Me.rbEdit.UseVisualStyleBackColor = True
        '
        'rbConcat
        '
        Me.rbConcat.AutoSize = True
        Me.rbConcat.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbConcat.ForeColor = System.Drawing.Color.White
        Me.rbConcat.Location = New System.Drawing.Point(128, 36)
        Me.rbConcat.Name = "rbConcat"
        Me.rbConcat.Size = New System.Drawing.Size(122, 18)
        Me.rbConcat.TabIndex = 20
        Me.rbConcat.TabStop = True
        Me.rbConcat.Text = "Concat Remarks"
        Me.rbConcat.UseVisualStyleBackColor = True
        '
        'EditRemarks
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(867, 438)
        Me.Controls.Add(Me.panelremarks)
        Me.Controls.Add(Me.btnEditRemarks)
        Me.Controls.Add(Me.lblheader)
        Me.Controls.Add(Me.dtDate)
        Me.Controls.Add(Me.cmbType)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.dgv)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "EditRemarks"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "EditRemarks"
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.panelremarks.ResumeLayout(False)
        Me.panelremarks.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgv As DataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbType As ComboBox
    Friend WithEvents dtDate As DateTimePicker
    Friend WithEvents lblheader As Label
    Friend WithEvents btnEditRemarks As Button
    Friend WithEvents panelremarks As Panel
    Friend WithEvents btnUpdate As Button
    Friend WithEvents txtRemarks As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lblcloseRemarks As Label
    Friend WithEvents selectt As DataGridViewCheckBoxColumn
    Friend WithEvents transid As DataGridViewTextBoxColumn
    Friend WithEvents itemname As DataGridViewTextBoxColumn
    Friend WithEvents quantity As DataGridViewTextBoxColumn
    Friend WithEvents transferTo As DataGridViewTextBoxColumn
    Friend WithEvents remarks As DataGridViewTextBoxColumn
    Friend WithEvents sap As DataGridViewTextBoxColumn
    Friend WithEvents sapnum As DataGridViewTextBoxColumn
    Friend WithEvents rbConcat As RadioButton
    Friend WithEvents rbEdit As RadioButton
End Class
