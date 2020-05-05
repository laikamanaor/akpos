<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class pos_dialog
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
        Me.btnretail = New System.Windows.Forms.Button()
        Me.btnwholesale = New System.Windows.Forms.Button()
        Me.btncoffeeshop = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnretail
        '
        Me.btnretail.BackColor = System.Drawing.Color.ForestGreen
        Me.btnretail.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnretail.FlatAppearance.BorderSize = 0
        Me.btnretail.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnretail.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnretail.ForeColor = System.Drawing.Color.White
        Me.btnretail.Location = New System.Drawing.Point(83, 53)
        Me.btnretail.Name = "btnretail"
        Me.btnretail.Size = New System.Drawing.Size(67, 31)
        Me.btnretail.TabIndex = 0
        Me.btnretail.Text = "Retail"
        Me.btnretail.UseVisualStyleBackColor = False
        '
        'btnwholesale
        '
        Me.btnwholesale.BackColor = System.Drawing.Color.ForestGreen
        Me.btnwholesale.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnwholesale.FlatAppearance.BorderSize = 0
        Me.btnwholesale.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnwholesale.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnwholesale.ForeColor = System.Drawing.Color.White
        Me.btnwholesale.Location = New System.Drawing.Point(156, 53)
        Me.btnwholesale.Name = "btnwholesale"
        Me.btnwholesale.Size = New System.Drawing.Size(88, 31)
        Me.btnwholesale.TabIndex = 1
        Me.btnwholesale.Text = "Wholesale"
        Me.btnwholesale.UseVisualStyleBackColor = False
        '
        'btncoffeeshop
        '
        Me.btncoffeeshop.BackColor = System.Drawing.Color.ForestGreen
        Me.btncoffeeshop.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btncoffeeshop.FlatAppearance.BorderSize = 0
        Me.btncoffeeshop.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btncoffeeshop.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btncoffeeshop.ForeColor = System.Drawing.Color.White
        Me.btncoffeeshop.Location = New System.Drawing.Point(250, 53)
        Me.btncoffeeshop.Name = "btncoffeeshop"
        Me.btncoffeeshop.Size = New System.Drawing.Size(99, 31)
        Me.btncoffeeshop.TabIndex = 2
        Me.btncoffeeshop.Text = "Coffee Shop"
        Me.btncoffeeshop.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(429, 25)
        Me.Panel1.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "POS DIALOG"
        '
        'pos_dialog
        '
        Me.AcceptButton = Me.btnretail
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(429, 106)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btncoffeeshop)
        Me.Controls.Add(Me.btnwholesale)
        Me.Controls.Add(Me.btnretail)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "pos_dialog"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnretail As Button
    Friend WithEvents btnwholesale As Button
    Friend WithEvents btncoffeeshop As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
End Class
