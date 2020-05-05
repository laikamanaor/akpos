<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class sorttt
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
        Me.btnsort = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.transnum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnsort
        '
        Me.btnsort.Location = New System.Drawing.Point(610, 257)
        Me.btnsort.Name = "btnsort"
        Me.btnsort.Size = New System.Drawing.Size(75, 23)
        Me.btnsort.TabIndex = 1
        Me.btnsort.Text = "Sort"
        Me.btnsort.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.transnum})
        Me.DataGridView1.Location = New System.Drawing.Point(34, 34)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(651, 208)
        Me.DataGridView1.TabIndex = 2
        '
        'transnum
        '
        Me.transnum.HeaderText = "Transnum"
        Me.transnum.Name = "transnum"
        Me.transnum.ReadOnly = True
        '
        'sorttt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(720, 304)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.btnsort)
        Me.Name = "sorttt"
        Me.Text = "sorttt"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnsort As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents transnum As DataGridViewTextBoxColumn
End Class
