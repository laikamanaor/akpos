<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dashboard2
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
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnhourly = New System.Windows.Forms.Button()
        Me.btndaily = New System.Windows.Forms.Button()
        Me.btnmonthly = New System.Windows.Forms.Button()
        Me.panelbody = New System.Windows.Forms.Panel()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1239, 32)
        Me.Panel2.TabIndex = 91
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Gold
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1, 32)
        Me.Panel3.TabIndex = 91
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(30, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(136, 22)
        Me.Label3.TabIndex = 91
        Me.Label3.Text = "DASHBOARD"
        '
        'btnhourly
        '
        Me.btnhourly.BackColor = System.Drawing.Color.ForestGreen
        Me.btnhourly.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnhourly.FlatAppearance.BorderSize = 0
        Me.btnhourly.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnhourly.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnhourly.ForeColor = System.Drawing.Color.White
        Me.btnhourly.Location = New System.Drawing.Point(34, 61)
        Me.btnhourly.Name = "btnhourly"
        Me.btnhourly.Size = New System.Drawing.Size(117, 25)
        Me.btnhourly.TabIndex = 92
        Me.btnhourly.Text = "Hourly"
        Me.btnhourly.UseVisualStyleBackColor = False
        '
        'btndaily
        '
        Me.btndaily.BackColor = System.Drawing.Color.DarkGreen
        Me.btndaily.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btndaily.FlatAppearance.BorderSize = 0
        Me.btndaily.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btndaily.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btndaily.ForeColor = System.Drawing.Color.White
        Me.btndaily.Location = New System.Drawing.Point(151, 61)
        Me.btndaily.Name = "btndaily"
        Me.btndaily.Size = New System.Drawing.Size(117, 25)
        Me.btndaily.TabIndex = 93
        Me.btndaily.Text = "Daily"
        Me.btndaily.UseVisualStyleBackColor = False
        '
        'btnmonthly
        '
        Me.btnmonthly.BackColor = System.Drawing.Color.Green
        Me.btnmonthly.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnmonthly.FlatAppearance.BorderSize = 0
        Me.btnmonthly.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnmonthly.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnmonthly.ForeColor = System.Drawing.Color.White
        Me.btnmonthly.Location = New System.Drawing.Point(268, 61)
        Me.btnmonthly.Name = "btnmonthly"
        Me.btnmonthly.Size = New System.Drawing.Size(117, 25)
        Me.btnmonthly.TabIndex = 94
        Me.btnmonthly.Text = "Monthly"
        Me.btnmonthly.UseVisualStyleBackColor = False
        '
        'panelbody
        '
        Me.panelbody.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panelbody.BackColor = System.Drawing.SystemColors.Control
        Me.panelbody.Location = New System.Drawing.Point(34, 119)
        Me.panelbody.Name = "panelbody"
        Me.panelbody.Size = New System.Drawing.Size(1171, 496)
        Me.panelbody.TabIndex = 95
        '
        'dashboard2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1239, 650)
        Me.Controls.Add(Me.panelbody)
        Me.Controls.Add(Me.btnmonthly)
        Me.Controls.Add(Me.btndaily)
        Me.Controls.Add(Me.btnhourly)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "dashboard2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DASHBOARD"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents btnhourly As Button
    Friend WithEvents btndaily As Button
    Friend WithEvents btnmonthly As Button
    Friend WithEvents panelbody As Panel
End Class
