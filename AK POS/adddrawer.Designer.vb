<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class adddrawer
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnclose = New System.Windows.Forms.Button()
        Me.lblheader = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.lblclose = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbcashier = New System.Windows.Forms.ComboBox()
        Me.txtamount = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnsubmit = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblavailable = New System.Windows.Forms.Label()
        Me.panelSAP = New System.Windows.Forms.Panel()
        Me.btnProceed = New System.Windows.Forms.Button()
        Me.lblsapdoc = New System.Windows.Forms.Label()
        Me.checkfollowup = New System.Windows.Forms.CheckBox()
        Me.txtboxSAPNo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtboxRemarks = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.panelSAP.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.Panel1.Controls.Add(Me.btnclose)
        Me.Panel1.Controls.Add(Me.lblheader)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(491, 32)
        Me.Panel1.TabIndex = 0
        '
        'btnclose
        '
        Me.btnclose.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.btnclose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnclose.FlatAppearance.BorderSize = 0
        Me.btnclose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick
        Me.btnclose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnclose.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnclose.ForeColor = System.Drawing.Color.White
        Me.btnclose.Location = New System.Drawing.Point(454, 1)
        Me.btnclose.Name = "btnclose"
        Me.btnclose.Size = New System.Drawing.Size(37, 30)
        Me.btnclose.TabIndex = 2
        Me.btnclose.Text = "X"
        Me.ToolTip1.SetToolTip(Me.btnclose, "Close")
        Me.btnclose.UseVisualStyleBackColor = False
        '
        'lblheader
        '
        Me.lblheader.AutoSize = True
        Me.lblheader.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblheader.ForeColor = System.Drawing.Color.White
        Me.lblheader.Location = New System.Drawing.Point(11, 8)
        Me.lblheader.Name = "lblheader"
        Me.lblheader.Size = New System.Drawing.Size(39, 18)
        Me.lblheader.TabIndex = 2
        Me.lblheader.Text = "ADD"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer))
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 32)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1, 249)
        Me.Panel2.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer))
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel3.Location = New System.Drawing.Point(490, 32)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1, 249)
        Me.Panel3.TabIndex = 1
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer))
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(1, 280)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(489, 1)
        Me.Panel4.TabIndex = 1
        '
        'lblclose
        '
        Me.lblclose.AutoSize = True
        Me.lblclose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblclose.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblclose.ForeColor = System.Drawing.Color.White
        Me.lblclose.Location = New System.Drawing.Point(324, 0)
        Me.lblclose.Name = "lblclose"
        Me.lblclose.Size = New System.Drawing.Size(21, 22)
        Me.lblclose.TabIndex = 0
        Me.lblclose.Text = "X"
        Me.ToolTip1.SetToolTip(Me.lblclose, "Close")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(32, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 18)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Cashier:"
        '
        'cmbcashier
        '
        Me.cmbcashier.BackColor = System.Drawing.SystemColors.HotTrack
        Me.cmbcashier.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbcashier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbcashier.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbcashier.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbcashier.ForeColor = System.Drawing.Color.White
        Me.cmbcashier.FormattingEnabled = True
        Me.cmbcashier.Location = New System.Drawing.Point(108, 71)
        Me.cmbcashier.Name = "cmbcashier"
        Me.cmbcashier.Size = New System.Drawing.Size(357, 28)
        Me.cmbcashier.TabIndex = 6
        '
        'txtamount
        '
        Me.txtamount.BackColor = System.Drawing.Color.White
        Me.txtamount.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtamount.Location = New System.Drawing.Point(108, 165)
        Me.txtamount.Name = "txtamount"
        Me.txtamount.ShortcutsEnabled = False
        Me.txtamount.Size = New System.Drawing.Size(357, 26)
        Me.txtamount.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(32, 169)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 18)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Amount:"
        '
        'btnsubmit
        '
        Me.btnsubmit.BackColor = System.Drawing.Color.ForestGreen
        Me.btnsubmit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnsubmit.FlatAppearance.BorderSize = 0
        Me.btnsubmit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.btnsubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnsubmit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsubmit.ForeColor = System.Drawing.Color.White
        Me.btnsubmit.Location = New System.Drawing.Point(377, 209)
        Me.btnsubmit.Name = "btnsubmit"
        Me.btnsubmit.Size = New System.Drawing.Size(88, 36)
        Me.btnsubmit.TabIndex = 10
        Me.btnsubmit.Text = "Submit"
        Me.btnsubmit.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(32, 126)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 18)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Available:"
        Me.Label4.Visible = False
        '
        'lblavailable
        '
        Me.lblavailable.AutoSize = True
        Me.lblavailable.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblavailable.Location = New System.Drawing.Point(118, 126)
        Me.lblavailable.Name = "lblavailable"
        Me.lblavailable.Size = New System.Drawing.Size(36, 18)
        Me.lblavailable.TabIndex = 12
        Me.lblavailable.Text = "0.00"
        Me.lblavailable.Visible = False
        '
        'panelSAP
        '
        Me.panelSAP.BackColor = System.Drawing.SystemColors.HotTrack
        Me.panelSAP.Controls.Add(Me.btnProceed)
        Me.panelSAP.Controls.Add(Me.lblsapdoc)
        Me.panelSAP.Controls.Add(Me.checkfollowup)
        Me.panelSAP.Controls.Add(Me.txtboxSAPNo)
        Me.panelSAP.Controls.Add(Me.Label1)
        Me.panelSAP.Controls.Add(Me.txtboxRemarks)
        Me.panelSAP.Controls.Add(Me.Label11)
        Me.panelSAP.Controls.Add(Me.lblclose)
        Me.panelSAP.Location = New System.Drawing.Point(81, 20)
        Me.panelSAP.Name = "panelSAP"
        Me.panelSAP.Size = New System.Drawing.Size(345, 210)
        Me.panelSAP.TabIndex = 13
        Me.panelSAP.Visible = False
        '
        'btnProceed
        '
        Me.btnProceed.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnProceed.BackColor = System.Drawing.Color.ForestGreen
        Me.btnProceed.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnProceed.FlatAppearance.BorderSize = 0
        Me.btnProceed.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProceed.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProceed.ForeColor = System.Drawing.Color.White
        Me.btnProceed.Location = New System.Drawing.Point(190, 155)
        Me.btnProceed.Name = "btnProceed"
        Me.btnProceed.Size = New System.Drawing.Size(129, 31)
        Me.btnProceed.TabIndex = 24
        Me.btnProceed.Text = "Proceed"
        Me.btnProceed.UseVisualStyleBackColor = False
        '
        'lblsapdoc
        '
        Me.lblsapdoc.AutoSize = True
        Me.lblsapdoc.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsapdoc.ForeColor = System.Drawing.Color.White
        Me.lblsapdoc.Location = New System.Drawing.Point(166, 20)
        Me.lblsapdoc.Name = "lblsapdoc"
        Me.lblsapdoc.Size = New System.Drawing.Size(24, 18)
        Me.lblsapdoc.TabIndex = 23
        Me.lblsapdoc.Text = "IP"
        '
        'checkfollowup
        '
        Me.checkfollowup.AutoSize = True
        Me.checkfollowup.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkfollowup.ForeColor = System.Drawing.Color.White
        Me.checkfollowup.Location = New System.Drawing.Point(237, 47)
        Me.checkfollowup.Name = "checkfollowup"
        Me.checkfollowup.Size = New System.Drawing.Size(86, 20)
        Me.checkfollowup.TabIndex = 22
        Me.checkfollowup.Text = "To Follow"
        Me.checkfollowup.UseVisualStyleBackColor = True
        '
        'txtboxSAPNo
        '
        Me.txtboxSAPNo.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtboxSAPNo.Location = New System.Drawing.Point(30, 43)
        Me.txtboxSAPNo.Multiline = True
        Me.txtboxSAPNo.Name = "txtboxSAPNo"
        Me.txtboxSAPNo.ShortcutsEnabled = False
        Me.txtboxSAPNo.Size = New System.Drawing.Size(201, 26)
        Me.txtboxSAPNo.TabIndex = 21
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(27, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(133, 18)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "SAP Document:"
        '
        'txtboxRemarks
        '
        Me.txtboxRemarks.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtboxRemarks.Location = New System.Drawing.Point(30, 104)
        Me.txtboxRemarks.Multiline = True
        Me.txtboxRemarks.Name = "txtboxRemarks"
        Me.txtboxRemarks.ShortcutsEnabled = False
        Me.txtboxRemarks.Size = New System.Drawing.Size(289, 40)
        Me.txtboxRemarks.TabIndex = 19
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(27, 79)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(79, 18)
        Me.Label11.TabIndex = 18
        Me.Label11.Text = "Remarks"
        '
        'adddrawer
        '
        Me.AcceptButton = Me.btnsubmit
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(491, 281)
        Me.Controls.Add(Me.panelSAP)
        Me.Controls.Add(Me.lblavailable)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnsubmit)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtamount)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbcashier)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "adddrawer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.panelSAP.ResumeLayout(False)
        Me.panelSAP.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents lblheader As System.Windows.Forms.Label
    Friend WithEvents btnclose As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbcashier As System.Windows.Forms.ComboBox
    Friend WithEvents txtamount As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnsubmit As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblavailable As System.Windows.Forms.Label
    Friend WithEvents panelSAP As Panel
    Friend WithEvents lblclose As Label
    Friend WithEvents lblsapdoc As Label
    Friend WithEvents checkfollowup As CheckBox
    Friend WithEvents txtboxSAPNo As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtboxRemarks As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents btnProceed As Button
End Class
