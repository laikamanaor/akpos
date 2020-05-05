<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class importbranch
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
        Me.btnbrowse = New System.Windows.Forms.Button()
        Me.btnsubmit = New System.Windows.Forms.Button()
        Me.dgvitems = New System.Windows.Forms.DataGridView()
        Me.branchcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.branchname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sales = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.address = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.remarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvitems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnbrowse
        '
        Me.btnbrowse.Location = New System.Drawing.Point(533, 240)
        Me.btnbrowse.Name = "btnbrowse"
        Me.btnbrowse.Size = New System.Drawing.Size(75, 23)
        Me.btnbrowse.TabIndex = 5
        Me.btnbrowse.Text = "BROWSE..."
        Me.btnbrowse.UseVisualStyleBackColor = True
        '
        'btnsubmit
        '
        Me.btnsubmit.Location = New System.Drawing.Point(623, 240)
        Me.btnsubmit.Name = "btnsubmit"
        Me.btnsubmit.Size = New System.Drawing.Size(75, 23)
        Me.btnsubmit.TabIndex = 4
        Me.btnsubmit.Text = "SUBMIT"
        Me.btnsubmit.UseVisualStyleBackColor = True
        '
        'dgvitems
        '
        Me.dgvitems.AllowUserToAddRows = False
        Me.dgvitems.AllowUserToDeleteRows = False
        Me.dgvitems.AllowUserToResizeColumns = False
        Me.dgvitems.AllowUserToResizeRows = False
        Me.dgvitems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvitems.ColumnHeadersHeight = 40
        Me.dgvitems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.branchcode, Me.branchname, Me.gr, Me.sales, Me.address, Me.remarks})
        Me.dgvitems.Location = New System.Drawing.Point(30, 34)
        Me.dgvitems.Name = "dgvitems"
        Me.dgvitems.RowHeadersVisible = False
        Me.dgvitems.Size = New System.Drawing.Size(668, 188)
        Me.dgvitems.TabIndex = 3
        '
        'branchcode
        '
        Me.branchcode.HeaderText = "Branch Code"
        Me.branchcode.Name = "branchcode"
        Me.branchcode.ReadOnly = True
        '
        'branchname
        '
        Me.branchname.HeaderText = "Branch Name"
        Me.branchname.Name = "branchname"
        Me.branchname.ReadOnly = True
        '
        'gr
        '
        Me.gr.HeaderText = "GR"
        Me.gr.Name = "gr"
        Me.gr.ReadOnly = True
        '
        'sales
        '
        Me.sales.HeaderText = "Sales"
        Me.sales.Name = "sales"
        Me.sales.ReadOnly = True
        '
        'address
        '
        Me.address.HeaderText = "Address"
        Me.address.Name = "address"
        Me.address.ReadOnly = True
        '
        'remarks
        '
        Me.remarks.HeaderText = "Remarks"
        Me.remarks.Name = "remarks"
        Me.remarks.ReadOnly = True
        '
        'importbranch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(725, 276)
        Me.Controls.Add(Me.btnbrowse)
        Me.Controls.Add(Me.btnsubmit)
        Me.Controls.Add(Me.dgvitems)
        Me.Name = "importbranch"
        Me.Text = "importbranch"
        CType(Me.dgvitems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnbrowse As Button
    Friend WithEvents btnsubmit As Button
    Friend WithEvents dgvitems As DataGridView
    Friend WithEvents branchcode As DataGridViewTextBoxColumn
    Friend WithEvents branchname As DataGridViewTextBoxColumn
    Friend WithEvents gr As DataGridViewTextBoxColumn
    Friend WithEvents sales As DataGridViewTextBoxColumn
    Friend WithEvents address As DataGridViewTextBoxColumn
    Friend WithEvents remarks As DataGridViewTextBoxColumn
End Class
