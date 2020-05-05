<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class add_spice
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnclose = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvap = New System.Windows.Forms.DataGridView()
        Me.select1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.id1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.namee1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.amount1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.datee1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtap = New System.Windows.Forms.TextBox()
        Me.btnap = New System.Windows.Forms.Button()
        Me.dateap = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.datedep = New System.Windows.Forms.DateTimePicker()
        Me.btndep = New System.Windows.Forms.Button()
        Me.txtdep = New System.Windows.Forms.TextBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dgvdep = New System.Windows.Forms.DataGridView()
        Me.select2 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.id2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.namee2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.amount2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.datee2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnsubmit = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvap, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.dgvdep, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.Panel1.Controls.Add(Me.btnclose)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(627, 36)
        Me.Panel1.TabIndex = 0
        '
        'btnclose
        '
        Me.btnclose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnclose.FlatAppearance.BorderSize = 0
        Me.btnclose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick
        Me.btnclose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnclose.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnclose.ForeColor = System.Drawing.Color.White
        Me.btnclose.Location = New System.Drawing.Point(594, 0)
        Me.btnclose.Name = "btnclose"
        Me.btnclose.Size = New System.Drawing.Size(33, 37)
        Me.btnclose.TabIndex = 4
        Me.btnclose.Text = "X"
        Me.btnclose.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(377, 22)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "ADD ADVANCE PAYMENT OR DEPOSIT"
        '
        'dgvap
        '
        Me.dgvap.AllowUserToAddRows = False
        Me.dgvap.AllowUserToDeleteRows = False
        Me.dgvap.AllowUserToResizeColumns = False
        Me.dgvap.AllowUserToResizeRows = False
        Me.dgvap.BackgroundColor = System.Drawing.Color.White
        Me.dgvap.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvap.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvap.ColumnHeadersHeight = 40
        Me.dgvap.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.select1, Me.id1, Me.namee1, Me.amount1, Me.datee1})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvap.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvap.EnableHeadersVisualStyles = False
        Me.dgvap.Location = New System.Drawing.Point(25, 150)
        Me.dgvap.Name = "dgvap"
        Me.dgvap.RowHeadersVisible = False
        Me.dgvap.Size = New System.Drawing.Size(570, 158)
        Me.dgvap.TabIndex = 4
        '
        'select1
        '
        Me.select1.HeaderText = "Select"
        Me.select1.Name = "select1"
        Me.select1.Width = 50
        '
        'id1
        '
        Me.id1.HeaderText = "ID"
        Me.id1.Name = "id1"
        Me.id1.ReadOnly = True
        Me.id1.Width = 170
        '
        'namee1
        '
        Me.namee1.HeaderText = "Name"
        Me.namee1.Name = "namee1"
        Me.namee1.ReadOnly = True
        Me.namee1.Width = 125
        '
        'amount1
        '
        Me.amount1.HeaderText = "Amount"
        Me.amount1.Name = "amount1"
        Me.amount1.ReadOnly = True
        '
        'datee1
        '
        Me.datee1.HeaderText = "Date Created"
        Me.datee1.Name = "datee1"
        Me.datee1.ReadOnly = True
        Me.datee1.Width = 120
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.Panel6.Controls.Add(Me.Label2)
        Me.Panel6.Location = New System.Drawing.Point(25, 120)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(570, 30)
        Me.Panel6.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(3, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(205, 22)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "ADVANCE PAYMENT"
        '
        'txtap
        '
        Me.txtap.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtap.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtap.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtap.Location = New System.Drawing.Point(25, 89)
        Me.txtap.Name = "txtap"
        Me.txtap.Size = New System.Drawing.Size(224, 29)
        Me.txtap.TabIndex = 8
        '
        'btnap
        '
        Me.btnap.BackColor = System.Drawing.SystemColors.HotTrack
        Me.btnap.FlatAppearance.BorderSize = 0
        Me.btnap.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue
        Me.btnap.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnap.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnap.ForeColor = System.Drawing.Color.White
        Me.btnap.Location = New System.Drawing.Point(248, 89)
        Me.btnap.Name = "btnap"
        Me.btnap.Size = New System.Drawing.Size(107, 29)
        Me.btnap.TabIndex = 10
        Me.btnap.Text = "Search"
        Me.btnap.UseVisualStyleBackColor = False
        '
        'dateap
        '
        Me.dateap.CustomFormat = "MM/dd/yyyy"
        Me.dateap.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dateap.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dateap.Location = New System.Drawing.Point(460, 93)
        Me.dateap.Name = "dateap"
        Me.dateap.Size = New System.Drawing.Size(135, 25)
        Me.dateap.TabIndex = 11
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(407, 99)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 17)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Date:"
        '
        'datedep
        '
        Me.datedep.CustomFormat = "MM/dd/yyyy"
        Me.datedep.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.datedep.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.datedep.Location = New System.Drawing.Point(460, 378)
        Me.datedep.Name = "datedep"
        Me.datedep.Size = New System.Drawing.Size(135, 25)
        Me.datedep.TabIndex = 17
        '
        'btndep
        '
        Me.btndep.BackColor = System.Drawing.SystemColors.HotTrack
        Me.btndep.FlatAppearance.BorderSize = 0
        Me.btndep.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue
        Me.btndep.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btndep.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btndep.ForeColor = System.Drawing.Color.White
        Me.btndep.Location = New System.Drawing.Point(248, 374)
        Me.btndep.Name = "btndep"
        Me.btndep.Size = New System.Drawing.Size(107, 29)
        Me.btndep.TabIndex = 16
        Me.btndep.Text = "Search"
        Me.btndep.UseVisualStyleBackColor = False
        '
        'txtdep
        '
        Me.txtdep.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtdep.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtdep.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdep.Location = New System.Drawing.Point(25, 374)
        Me.txtdep.Name = "txtdep"
        Me.txtdep.Size = New System.Drawing.Size(224, 29)
        Me.txtdep.TabIndex = 15
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.Panel5.Controls.Add(Me.Label3)
        Me.Panel5.Location = New System.Drawing.Point(25, 405)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(570, 30)
        Me.Panel5.TabIndex = 14
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(3, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 22)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "DEPOSIT"
        '
        'dgvdep
        '
        Me.dgvdep.AllowUserToAddRows = False
        Me.dgvdep.AllowUserToDeleteRows = False
        Me.dgvdep.AllowUserToResizeColumns = False
        Me.dgvdep.AllowUserToResizeRows = False
        Me.dgvdep.BackgroundColor = System.Drawing.Color.White
        Me.dgvdep.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvdep.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvdep.ColumnHeadersHeight = 40
        Me.dgvdep.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.select2, Me.id2, Me.namee2, Me.amount2, Me.datee2})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvdep.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvdep.EnableHeadersVisualStyles = False
        Me.dgvdep.Location = New System.Drawing.Point(25, 435)
        Me.dgvdep.Name = "dgvdep"
        Me.dgvdep.RowHeadersVisible = False
        Me.dgvdep.Size = New System.Drawing.Size(570, 158)
        Me.dgvdep.TabIndex = 13
        '
        'select2
        '
        Me.select2.HeaderText = "Select"
        Me.select2.Name = "select2"
        Me.select2.Width = 50
        '
        'id2
        '
        Me.id2.HeaderText = "ID"
        Me.id2.Name = "id2"
        Me.id2.ReadOnly = True
        Me.id2.Width = 170
        '
        'namee2
        '
        Me.namee2.HeaderText = "Name"
        Me.namee2.Name = "namee2"
        Me.namee2.ReadOnly = True
        Me.namee2.Width = 125
        '
        'amount2
        '
        Me.amount2.HeaderText = "Amount"
        Me.amount2.Name = "amount2"
        Me.amount2.ReadOnly = True
        '
        'datee2
        '
        Me.datee2.HeaderText = "Date Created"
        Me.datee2.Name = "datee2"
        Me.datee2.ReadOnly = True
        Me.datee2.Width = 120
        '
        'btnsubmit
        '
        Me.btnsubmit.BackColor = System.Drawing.Color.ForestGreen
        Me.btnsubmit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnsubmit.FlatAppearance.BorderSize = 0
        Me.btnsubmit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.btnsubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnsubmit.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsubmit.ForeColor = System.Drawing.Color.White
        Me.btnsubmit.Location = New System.Drawing.Point(474, 628)
        Me.btnsubmit.Name = "btnsubmit"
        Me.btnsubmit.Size = New System.Drawing.Size(121, 29)
        Me.btnsubmit.TabIndex = 18
        Me.btnsubmit.Text = "SUBMIT"
        Me.btnsubmit.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DimGray
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 36)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1, 622)
        Me.Panel2.TabIndex = 19
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.DimGray
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel3.Location = New System.Drawing.Point(626, 36)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1, 622)
        Me.Panel3.TabIndex = 20
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.DimGray
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(1, 36)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(625, 1)
        Me.Panel4.TabIndex = 21
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.DimGray
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel7.Location = New System.Drawing.Point(1, 657)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(625, 1)
        Me.Panel7.TabIndex = 21
        '
        'add_spice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(644, 399)
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.btnsubmit)
        Me.Controls.Add(Me.datedep)
        Me.Controls.Add(Me.btndep)
        Me.Controls.Add(Me.txtdep)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.dgvdep)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dateap)
        Me.Controls.Add(Me.btnap)
        Me.Controls.Add(Me.txtap)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.dgvap)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "add_spice"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvap, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        CType(Me.dgvdep, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnclose As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents dgvap As DataGridView
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents txtap As TextBox
    Friend WithEvents btnap As Button
    Friend WithEvents dateap As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents datedep As DateTimePicker
    Friend WithEvents btndep As Button
    Friend WithEvents txtdep As TextBox
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents dgvdep As DataGridView
    Friend WithEvents btnsubmit As Button
    Friend WithEvents select1 As DataGridViewCheckBoxColumn
    Friend WithEvents id1 As DataGridViewTextBoxColumn
    Friend WithEvents namee1 As DataGridViewTextBoxColumn
    Friend WithEvents amount1 As DataGridViewTextBoxColumn
    Friend WithEvents datee1 As DataGridViewTextBoxColumn
    Friend WithEvents select2 As DataGridViewCheckBoxColumn
    Friend WithEvents id2 As DataGridViewTextBoxColumn
    Friend WithEvents namee2 As DataGridViewTextBoxColumn
    Friend WithEvents amount2 As DataGridViewTextBoxColumn
    Friend WithEvents datee2 As DataGridViewTextBoxColumn
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel7 As Panel
End Class
