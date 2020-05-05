<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class cutoff
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.btnclose = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvusers = New System.Windows.Forms.DataGridView()
        Me.workgroup = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btncutoff = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lblerror = New System.Windows.Forms.Label()
        Me.cmbstat = New System.Windows.Forms.ComboBox()
        Me.btnremove = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvusers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Panel5)
        Me.Panel1.Controls.Add(Me.btnclose)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(604, 32)
        Me.Panel1.TabIndex = 0
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Gold
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1, 32)
        Me.Panel5.TabIndex = 3
        '
        'btnclose
        '
        Me.btnclose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnclose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnclose.FlatAppearance.BorderSize = 0
        Me.btnclose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick
        Me.btnclose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnclose.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnclose.ForeColor = System.Drawing.Color.White
        Me.btnclose.Location = New System.Drawing.Point(547, 2)
        Me.btnclose.Name = "btnclose"
        Me.btnclose.Size = New System.Drawing.Size(57, 32)
        Me.btnclose.TabIndex = 2
        Me.btnclose.Text = "X"
        Me.btnclose.UseVisualStyleBackColor = True
        Me.btnclose.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 22)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "CUT OFF"
        '
        'dgvusers
        '
        Me.dgvusers.AllowUserToAddRows = False
        Me.dgvusers.AllowUserToDeleteRows = False
        Me.dgvusers.AllowUserToResizeColumns = False
        Me.dgvusers.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvusers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvusers.BackgroundColor = System.Drawing.Color.White
        Me.dgvusers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvusers.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvusers.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvusers.ColumnHeadersHeight = 40
        Me.dgvusers.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.workgroup, Me.btncutoff})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvusers.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvusers.EnableHeadersVisualStyles = False
        Me.dgvusers.GridColor = System.Drawing.Color.Black
        Me.dgvusers.Location = New System.Drawing.Point(35, 114)
        Me.dgvusers.Name = "dgvusers"
        Me.dgvusers.RowHeadersVisible = False
        Me.dgvusers.Size = New System.Drawing.Size(534, 250)
        Me.dgvusers.TabIndex = 1
        '
        'workgroup
        '
        Me.workgroup.HeaderText = "Workgroup"
        Me.workgroup.Name = "workgroup"
        Me.workgroup.ReadOnly = True
        '
        'btncutoff
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        Me.btncutoff.DefaultCellStyle = DataGridViewCellStyle2
        Me.btncutoff.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btncutoff.HeaderText = "Action"
        Me.btncutoff.Name = "btncutoff"
        Me.btncutoff.ReadOnly = True
        Me.btncutoff.Text = "Cut Off"
        Me.btncutoff.UseColumnTextForButtonValue = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Black
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(602, 32)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(2, 372)
        Me.Panel2.TabIndex = 2
        Me.Panel2.Visible = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Black
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(0, 32)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(2, 372)
        Me.Panel3.TabIndex = 3
        Me.Panel3.Visible = False
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Black
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(2, 402)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(600, 2)
        Me.Panel4.TabIndex = 4
        '
        'lblerror
        '
        Me.lblerror.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblerror.AutoSize = True
        Me.lblerror.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblerror.ForeColor = System.Drawing.Color.DimGray
        Me.lblerror.Location = New System.Drawing.Point(213, 178)
        Me.lblerror.Name = "lblerror"
        Me.lblerror.Size = New System.Drawing.Size(157, 18)
        Me.lblerror.TabIndex = 7
        Me.lblerror.Text = "NO FETCH DATA :("
        Me.lblerror.Visible = False
        '
        'cmbstat
        '
        Me.cmbstat.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbstat.BackColor = System.Drawing.Color.DodgerBlue
        Me.cmbstat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbstat.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbstat.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbstat.ForeColor = System.Drawing.Color.White
        Me.cmbstat.FormattingEnabled = True
        Me.cmbstat.Items.AddRange(New Object() {"Active", "In Active"})
        Me.cmbstat.Location = New System.Drawing.Point(415, 85)
        Me.cmbstat.Name = "cmbstat"
        Me.cmbstat.Size = New System.Drawing.Size(154, 23)
        Me.cmbstat.TabIndex = 8
        '
        'btnremove
        '
        Me.btnremove.BackColor = System.Drawing.Color.ForestGreen
        Me.btnremove.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnremove.FlatAppearance.BorderSize = 0
        Me.btnremove.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnremove.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnremove.ForeColor = System.Drawing.Color.White
        Me.btnremove.Location = New System.Drawing.Point(35, 85)
        Me.btnremove.Name = "btnremove"
        Me.btnremove.Size = New System.Drawing.Size(133, 23)
        Me.btnremove.TabIndex = 9
        Me.btnremove.Text = "Remove Cut Off"
        Me.btnremove.UseVisualStyleBackColor = False
        '
        'cutoff
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(604, 404)
        Me.Controls.Add(Me.btnremove)
        Me.Controls.Add(Me.cmbstat)
        Me.Controls.Add(Me.lblerror)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.dgvusers)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "cutoff"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cut Off"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvusers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents dgvusers As DataGridView
    Friend WithEvents btnclose As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents lblerror As Label
    Friend WithEvents cmbstat As ComboBox
    Friend WithEvents workgroup As DataGridViewTextBoxColumn
    Friend WithEvents btncutoff As DataGridViewButtonColumn
    Friend WithEvents btnremove As Button
    Friend WithEvents Panel5 As Panel
End Class
