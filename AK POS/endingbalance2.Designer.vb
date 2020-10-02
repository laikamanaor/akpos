<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class endingbalance2
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(endingbalance2))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.itemname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.actualending = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.endbal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pullout = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.totalsystembalance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.variance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.price = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.totalamt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnProceed = New System.Windows.Forms.Button()
        Me.panelSAP = New System.Windows.Forms.Panel()
        Me.txtactualremarks = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbStatus = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbranches = New System.Windows.Forms.ComboBox()
        Me.lblsapdoc = New System.Windows.Forms.Label()
        Me.lblSAPClose = New System.Windows.Forms.Label()
        Me.txtsap = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtporemarks = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.spinner = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelSAP.SuspendLayout()
        CType(Me.spinner, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(998, 38)
        Me.Panel1.TabIndex = 52
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Gold
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1, 38)
        Me.Panel2.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(12, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(354, 22)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "UPDATE ACTUAL ENDING BALANCE"
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
        Me.dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(222, Byte), Integer), CType(CType(222, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv.ColumnHeadersHeight = 40
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.itemname, Me.actualending, Me.endbal, Me.pullout, Me.totalsystembalance, Me.variance, Me.price, Me.totalamt})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgv.EnableHeadersVisualStyles = False
        Me.dgv.GridColor = System.Drawing.Color.Silver
        Me.dgv.Location = New System.Drawing.Point(33, 64)
        Me.dgv.Name = "dgv"
        Me.dgv.RowHeadersVisible = False
        Me.dgv.Size = New System.Drawing.Size(932, 403)
        Me.dgv.TabIndex = 53
        '
        'itemname
        '
        Me.itemname.HeaderText = "Item Name"
        Me.itemname.Name = "itemname"
        Me.itemname.ReadOnly = True
        '
        'actualending
        '
        Me.actualending.HeaderText = "Actual Ending Inventory"
        Me.actualending.Name = "actualending"
        '
        'endbal
        '
        Me.endbal.HeaderText = "System Inventory"
        Me.endbal.Name = "endbal"
        Me.endbal.ReadOnly = True
        '
        'pullout
        '
        Me.pullout.HeaderText = "Pull Out"
        Me.pullout.Name = "pullout"
        '
        'totalsystembalance
        '
        Me.totalsystembalance.HeaderText = "Total System Inventory"
        Me.totalsystembalance.Name = "totalsystembalance"
        Me.totalsystembalance.ReadOnly = True
        '
        'variance
        '
        Me.variance.HeaderText = "Variance"
        Me.variance.Name = "variance"
        Me.variance.ReadOnly = True
        '
        'price
        '
        Me.price.HeaderText = "Price"
        Me.price.Name = "price"
        Me.price.ReadOnly = True
        '
        'totalamt
        '
        Me.totalamt.HeaderText = "Total Amount"
        Me.totalamt.Name = "totalamt"
        Me.totalamt.ReadOnly = True
        '
        'btnProceed
        '
        Me.btnProceed.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnProceed.BackColor = System.Drawing.Color.ForestGreen
        Me.btnProceed.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnProceed.FlatAppearance.BorderSize = 0
        Me.btnProceed.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProceed.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProceed.ForeColor = System.Drawing.Color.White
        Me.btnProceed.Location = New System.Drawing.Point(852, 473)
        Me.btnProceed.Name = "btnProceed"
        Me.btnProceed.Size = New System.Drawing.Size(113, 41)
        Me.btnProceed.TabIndex = 54
        Me.btnProceed.Text = "Proceed"
        Me.btnProceed.UseVisualStyleBackColor = False
        '
        'panelSAP
        '
        Me.panelSAP.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.panelSAP.BackColor = System.Drawing.SystemColors.HotTrack
        Me.panelSAP.Controls.Add(Me.txtactualremarks)
        Me.panelSAP.Controls.Add(Me.Label2)
        Me.panelSAP.Controls.Add(Me.cmbStatus)
        Me.panelSAP.Controls.Add(Me.Label1)
        Me.panelSAP.Controls.Add(Me.cmbranches)
        Me.panelSAP.Controls.Add(Me.lblsapdoc)
        Me.panelSAP.Controls.Add(Me.lblSAPClose)
        Me.panelSAP.Controls.Add(Me.txtsap)
        Me.panelSAP.Controls.Add(Me.Label4)
        Me.panelSAP.Controls.Add(Me.txtporemarks)
        Me.panelSAP.Controls.Add(Me.Label11)
        Me.panelSAP.Controls.Add(Me.btnSubmit)
        Me.panelSAP.Location = New System.Drawing.Point(314, 125)
        Me.panelSAP.Name = "panelSAP"
        Me.panelSAP.Size = New System.Drawing.Size(371, 369)
        Me.panelSAP.TabIndex = 58
        Me.panelSAP.Visible = False
        '
        'txtactualremarks
        '
        Me.txtactualremarks.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtactualremarks.Location = New System.Drawing.Point(39, 251)
        Me.txtactualremarks.Multiline = True
        Me.txtactualremarks.Name = "txtactualremarks"
        Me.txtactualremarks.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtactualremarks.ShortcutsEnabled = False
        Me.txtactualremarks.Size = New System.Drawing.Size(289, 43)
        Me.txtactualremarks.TabIndex = 23
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(36, 229)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(199, 18)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Actual Ending Remarks:"
        '
        'cmbStatus
        '
        Me.cmbStatus.BackColor = System.Drawing.Color.DodgerBlue
        Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbStatus.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbStatus.ForeColor = System.Drawing.Color.White
        Me.cmbStatus.FormattingEnabled = True
        Me.cmbStatus.Items.AddRange(New Object() {"Pending", "Approved", "Disapproved"})
        Me.cmbStatus.Location = New System.Drawing.Point(39, 114)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Size = New System.Drawing.Size(95, 23)
        Me.cmbStatus.TabIndex = 21
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(36, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 18)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Transfer To:"
        '
        'cmbranches
        '
        Me.cmbranches.BackColor = System.Drawing.Color.DodgerBlue
        Me.cmbranches.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbranches.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbranches.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbranches.ForeColor = System.Drawing.Color.White
        Me.cmbranches.FormattingEnabled = True
        Me.cmbranches.Location = New System.Drawing.Point(39, 55)
        Me.cmbranches.Name = "cmbranches"
        Me.cmbranches.Size = New System.Drawing.Size(289, 23)
        Me.cmbranches.TabIndex = 19
        '
        'lblsapdoc
        '
        Me.lblsapdoc.AutoSize = True
        Me.lblsapdoc.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsapdoc.ForeColor = System.Drawing.Color.White
        Me.lblsapdoc.Location = New System.Drawing.Point(175, 89)
        Me.lblsapdoc.Name = "lblsapdoc"
        Me.lblsapdoc.Size = New System.Drawing.Size(35, 18)
        Me.lblsapdoc.TabIndex = 17
        Me.lblsapdoc.Text = "ITR"
        '
        'lblSAPClose
        '
        Me.lblSAPClose.AutoSize = True
        Me.lblSAPClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblSAPClose.Font = New System.Drawing.Font("Arial Rounded MT Bold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSAPClose.ForeColor = System.Drawing.Color.White
        Me.lblSAPClose.Location = New System.Drawing.Point(345, 1)
        Me.lblSAPClose.Name = "lblSAPClose"
        Me.lblSAPClose.Size = New System.Drawing.Size(23, 24)
        Me.lblSAPClose.TabIndex = 6
        Me.lblSAPClose.Text = "X"
        '
        'txtsap
        '
        Me.txtsap.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsap.Location = New System.Drawing.Point(140, 112)
        Me.txtsap.MaxLength = 6
        Me.txtsap.Name = "txtsap"
        Me.txtsap.ShortcutsEnabled = False
        Me.txtsap.Size = New System.Drawing.Size(188, 29)
        Me.txtsap.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(36, 89)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(133, 18)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "SAP Document:"
        '
        'txtporemarks
        '
        Me.txtporemarks.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtporemarks.Location = New System.Drawing.Point(39, 179)
        Me.txtporemarks.Multiline = True
        Me.txtporemarks.Name = "txtporemarks"
        Me.txtporemarks.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtporemarks.ShortcutsEnabled = False
        Me.txtporemarks.Size = New System.Drawing.Size(289, 43)
        Me.txtporemarks.TabIndex = 2
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(36, 157)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(117, 18)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "P.O Remarks:"
        '
        'btnSubmit
        '
        Me.btnSubmit.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnSubmit.BackColor = System.Drawing.Color.ForestGreen
        Me.btnSubmit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSubmit.FlatAppearance.BorderSize = 0
        Me.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSubmit.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSubmit.ForeColor = System.Drawing.Color.White
        Me.btnSubmit.Location = New System.Drawing.Point(199, 311)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(129, 31)
        Me.btnSubmit.TabIndex = 0
        Me.btnSubmit.Text = "SUBMIT"
        Me.btnSubmit.UseVisualStyleBackColor = False
        '
        'spinner
        '
        Me.spinner.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.spinner.Image = CType(resources.GetObject("spinner.Image"), System.Drawing.Image)
        Me.spinner.Location = New System.Drawing.Point(410, 474)
        Me.spinner.Name = "spinner"
        Me.spinner.Size = New System.Drawing.Size(182, 71)
        Me.spinner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.spinner.TabIndex = 59
        Me.spinner.TabStop = False
        Me.spinner.Visible = False
        '
        'endingbalance2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(998, 557)
        Me.Controls.Add(Me.panelSAP)
        Me.Controls.Add(Me.btnProceed)
        Me.Controls.Add(Me.dgv)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.spinner)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "endingbalance2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "endingbalance2"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelSAP.ResumeLayout(False)
        Me.panelSAP.PerformLayout()
        CType(Me.spinner, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents dgv As DataGridView
    Friend WithEvents btnProceed As Button
    Friend WithEvents itemname As DataGridViewTextBoxColumn
    Friend WithEvents actualending As DataGridViewTextBoxColumn
    Friend WithEvents endbal As DataGridViewTextBoxColumn
    Friend WithEvents pullout As DataGridViewTextBoxColumn
    Friend WithEvents totalsystembalance As DataGridViewTextBoxColumn
    Friend WithEvents variance As DataGridViewTextBoxColumn
    Friend WithEvents price As DataGridViewTextBoxColumn
    Friend WithEvents totalamt As DataGridViewTextBoxColumn
    Friend WithEvents panelSAP As Panel
    Friend WithEvents cmbStatus As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbranches As ComboBox
    Friend WithEvents lblsapdoc As Label
    Friend WithEvents lblSAPClose As Label
    Friend WithEvents txtsap As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtporemarks As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents btnSubmit As Button
    Friend WithEvents txtactualremarks As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents spinner As PictureBox
End Class
