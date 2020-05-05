<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class importcustomers
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
        Me.dgvitems = New System.Windows.Forms.DataGridView()
        Me.namee = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.contactnumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.address = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.code = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnsubmit = New System.Windows.Forms.Button()
        Me.btnbrowse = New System.Windows.Forms.Button()
        CType(Me.dgvitems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvitems
        '
        Me.dgvitems.AllowUserToAddRows = False
        Me.dgvitems.AllowUserToDeleteRows = False
        Me.dgvitems.AllowUserToResizeColumns = False
        Me.dgvitems.AllowUserToResizeRows = False
        Me.dgvitems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvitems.ColumnHeadersHeight = 40
        Me.dgvitems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.namee, Me.contactnumber, Me.address, Me.type, Me.code})
        Me.dgvitems.Location = New System.Drawing.Point(21, 69)
        Me.dgvitems.Name = "dgvitems"
        Me.dgvitems.Size = New System.Drawing.Size(668, 188)
        Me.dgvitems.TabIndex = 0
        '
        'namee
        '
        Me.namee.HeaderText = "Name"
        Me.namee.Name = "namee"
        Me.namee.ReadOnly = True
        '
        'contactnumber
        '
        Me.contactnumber.HeaderText = "Contact Number"
        Me.contactnumber.Name = "contactnumber"
        Me.contactnumber.ReadOnly = True
        '
        'address
        '
        Me.address.HeaderText = "Address"
        Me.address.Name = "address"
        Me.address.ReadOnly = True
        '
        'type
        '
        Me.type.HeaderText = "Type"
        Me.type.Name = "type"
        Me.type.ReadOnly = True
        '
        'code
        '
        Me.code.HeaderText = "Code"
        Me.code.Name = "code"
        Me.code.ReadOnly = True
        '
        'btnsubmit
        '
        Me.btnsubmit.Location = New System.Drawing.Point(614, 272)
        Me.btnsubmit.Name = "btnsubmit"
        Me.btnsubmit.Size = New System.Drawing.Size(75, 23)
        Me.btnsubmit.TabIndex = 1
        Me.btnsubmit.Text = "SUBMIT"
        Me.btnsubmit.UseVisualStyleBackColor = True
        '
        'btnbrowse
        '
        Me.btnbrowse.Location = New System.Drawing.Point(524, 272)
        Me.btnbrowse.Name = "btnbrowse"
        Me.btnbrowse.Size = New System.Drawing.Size(75, 23)
        Me.btnbrowse.TabIndex = 2
        Me.btnbrowse.Text = "BROWSE..."
        Me.btnbrowse.UseVisualStyleBackColor = True
        '
        'importcustomers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(705, 327)
        Me.Controls.Add(Me.btnbrowse)
        Me.Controls.Add(Me.btnsubmit)
        Me.Controls.Add(Me.dgvitems)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "importcustomers"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Import"
        CType(Me.dgvitems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvitems As DataGridView
    Friend WithEvents namee As DataGridViewTextBoxColumn
    Friend WithEvents contactnumber As DataGridViewTextBoxColumn
    Friend WithEvents address As DataGridViewTextBoxColumn
    Friend WithEvents type As DataGridViewTextBoxColumn
    Friend WithEvents code As DataGridViewTextBoxColumn
    Friend WithEvents btnsubmit As Button
    Friend WithEvents btnbrowse As Button
End Class
