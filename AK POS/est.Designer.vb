<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class est
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(est))
        Me.btnbrowse = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnretrieve = New System.Windows.Forms.Button()
        Me.btndelete = New System.Windows.Forms.Button()
        Me.AxAcroPDF1 = New AxAcroPDFLib.AxAcroPDF()
        Me.btnopen = New System.Windows.Forms.Button()
        Me.btnbrowse2 = New System.Windows.Forms.Button()
        CType(Me.AxAcroPDF1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnbrowse
        '
        Me.btnbrowse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnbrowse.BackColor = System.Drawing.SystemColors.HotTrack
        Me.btnbrowse.FlatAppearance.BorderSize = 0
        Me.btnbrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnbrowse.ForeColor = System.Drawing.Color.White
        Me.btnbrowse.Location = New System.Drawing.Point(339, 23)
        Me.btnbrowse.Name = "btnbrowse"
        Me.btnbrowse.Size = New System.Drawing.Size(75, 23)
        Me.btnbrowse.TabIndex = 1
        Me.btnbrowse.Text = "Browse..."
        Me.btnbrowse.UseVisualStyleBackColor = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.Color.ForestGreen
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(339, 290)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Save"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'btnretrieve
        '
        Me.btnretrieve.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnretrieve.BackColor = System.Drawing.Color.ForestGreen
        Me.btnretrieve.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnretrieve.FlatAppearance.BorderSize = 0
        Me.btnretrieve.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnretrieve.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnretrieve.ForeColor = System.Drawing.Color.White
        Me.btnretrieve.Location = New System.Drawing.Point(22, 290)
        Me.btnretrieve.Name = "btnretrieve"
        Me.btnretrieve.Size = New System.Drawing.Size(75, 23)
        Me.btnretrieve.TabIndex = 3
        Me.btnretrieve.Text = "Retrieve File"
        Me.btnretrieve.UseVisualStyleBackColor = False
        '
        'btndelete
        '
        Me.btndelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btndelete.BackColor = System.Drawing.Color.ForestGreen
        Me.btndelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btndelete.FlatAppearance.BorderSize = 0
        Me.btndelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btndelete.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btndelete.ForeColor = System.Drawing.Color.White
        Me.btndelete.Location = New System.Drawing.Point(103, 290)
        Me.btndelete.Name = "btndelete"
        Me.btndelete.Size = New System.Drawing.Size(75, 23)
        Me.btndelete.TabIndex = 4
        Me.btndelete.Text = "Delete"
        Me.btndelete.UseVisualStyleBackColor = False
        Me.btndelete.Visible = False
        '
        'AxAcroPDF1
        '
        Me.AxAcroPDF1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AxAcroPDF1.Enabled = True
        Me.AxAcroPDF1.Location = New System.Drawing.Point(22, 52)
        Me.AxAcroPDF1.Name = "AxAcroPDF1"
        Me.AxAcroPDF1.OcxState = CType(resources.GetObject("AxAcroPDF1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxAcroPDF1.Size = New System.Drawing.Size(392, 217)
        Me.AxAcroPDF1.TabIndex = 0
        '
        'btnopen
        '
        Me.btnopen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnopen.BackColor = System.Drawing.SystemColors.HotTrack
        Me.btnopen.FlatAppearance.BorderSize = 0
        Me.btnopen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnopen.ForeColor = System.Drawing.Color.White
        Me.btnopen.Location = New System.Drawing.Point(22, 23)
        Me.btnopen.Name = "btnopen"
        Me.btnopen.Size = New System.Drawing.Size(75, 23)
        Me.btnopen.TabIndex = 5
        Me.btnopen.Text = "Open"
        Me.btnopen.UseVisualStyleBackColor = False
        Me.btnopen.Visible = False
        '
        'btnbrowse2
        '
        Me.btnbrowse2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnbrowse2.BackColor = System.Drawing.SystemColors.HotTrack
        Me.btnbrowse2.FlatAppearance.BorderSize = 0
        Me.btnbrowse2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnbrowse2.ForeColor = System.Drawing.Color.White
        Me.btnbrowse2.Location = New System.Drawing.Point(103, 23)
        Me.btnbrowse2.Name = "btnbrowse2"
        Me.btnbrowse2.Size = New System.Drawing.Size(75, 23)
        Me.btnbrowse2.TabIndex = 6
        Me.btnbrowse2.Text = "Browse..."
        Me.btnbrowse2.UseVisualStyleBackColor = False
        '
        'est
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(439, 343)
        Me.Controls.Add(Me.btnbrowse2)
        Me.Controls.Add(Me.btnopen)
        Me.Controls.Add(Me.btndelete)
        Me.Controls.Add(Me.btnretrieve)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnbrowse)
        Me.Controls.Add(Me.AxAcroPDF1)
        Me.Name = "est"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "est"
        CType(Me.AxAcroPDF1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents AxAcroPDF1 As AxAcroPDFLib.AxAcroPDF
    Friend WithEvents btnbrowse As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents Button1 As Button
    Friend WithEvents btnretrieve As Button
    Friend WithEvents btndelete As Button
    Friend WithEvents btnopen As Button
    Friend WithEvents btnbrowse2 As Button
End Class
