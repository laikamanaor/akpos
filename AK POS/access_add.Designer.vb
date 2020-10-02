<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class access_add
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
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.lblclose = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.cmbusernames = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.rbActive = New System.Windows.Forms.RadioButton()
        Me.rbInActive = New System.Windows.Forms.RadioButton()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.cmbmodules = New System.Windows.Forms.ComboBox()
        Me.Panel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.Panel5.Controls.Add(Me.lblclose)
        Me.Panel5.Controls.Add(Me.Label24)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(412, 33)
        Me.Panel5.TabIndex = 15
        '
        'lblclose
        '
        Me.lblclose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblclose.AutoSize = True
        Me.lblclose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblclose.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblclose.ForeColor = System.Drawing.Color.White
        Me.lblclose.Location = New System.Drawing.Point(385, 5)
        Me.lblclose.Name = "lblclose"
        Me.lblclose.Size = New System.Drawing.Size(21, 22)
        Me.lblclose.TabIndex = 1
        Me.lblclose.Text = "X"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.White
        Me.Label24.Location = New System.Drawing.Point(3, 5)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(130, 24)
        Me.Label24.TabIndex = 0
        Me.Label24.Text = "ADD ACCESS"
        '
        'cmbusernames
        '
        Me.cmbusernames.BackColor = System.Drawing.Color.DodgerBlue
        Me.cmbusernames.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbusernames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbusernames.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbusernames.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbusernames.ForeColor = System.Drawing.Color.White
        Me.cmbusernames.FormattingEnabled = True
        Me.cmbusernames.Location = New System.Drawing.Point(50, 88)
        Me.cmbusernames.Name = "cmbusernames"
        Me.cmbusernames.Size = New System.Drawing.Size(321, 25)
        Me.cmbusernames.TabIndex = 16
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DimGray
        Me.Label1.Location = New System.Drawing.Point(47, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 17)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Username:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DimGray
        Me.Label2.Location = New System.Drawing.Point(45, 129)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 17)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Module:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DimGray
        Me.Label3.Location = New System.Drawing.Point(45, 193)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 17)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "Status:"
        '
        'rbActive
        '
        Me.rbActive.AutoSize = True
        Me.rbActive.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rbActive.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbActive.Location = New System.Drawing.Point(50, 219)
        Me.rbActive.Name = "rbActive"
        Me.rbActive.Size = New System.Drawing.Size(66, 19)
        Me.rbActive.TabIndex = 22
        Me.rbActive.TabStop = True
        Me.rbActive.Text = "Active"
        Me.rbActive.UseVisualStyleBackColor = True
        '
        'rbInActive
        '
        Me.rbInActive.AutoSize = True
        Me.rbInActive.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rbInActive.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbInActive.Location = New System.Drawing.Point(48, 244)
        Me.rbInActive.Name = "rbInActive"
        Me.rbInActive.Size = New System.Drawing.Size(81, 19)
        Me.rbInActive.TabIndex = 23
        Me.rbInActive.TabStop = True
        Me.rbInActive.Text = "In Active"
        Me.rbInActive.UseVisualStyleBackColor = True
        '
        'btnSubmit
        '
        Me.btnSubmit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSubmit.BackColor = System.Drawing.Color.ForestGreen
        Me.btnSubmit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSubmit.FlatAppearance.BorderSize = 0
        Me.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSubmit.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSubmit.ForeColor = System.Drawing.Color.White
        Me.btnSubmit.Location = New System.Drawing.Point(48, 283)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(321, 35)
        Me.btnSubmit.TabIndex = 24
        Me.btnSubmit.Text = "Submit"
        Me.btnSubmit.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 395)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(412, 1)
        Me.Panel1.TabIndex = 25
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Black
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 33)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1, 362)
        Me.Panel2.TabIndex = 26
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Black
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel4.Location = New System.Drawing.Point(411, 33)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1, 362)
        Me.Panel4.TabIndex = 26
        '
        'cmbmodules
        '
        Me.cmbmodules.BackColor = System.Drawing.Color.DodgerBlue
        Me.cmbmodules.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbmodules.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbmodules.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbmodules.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbmodules.ForeColor = System.Drawing.Color.White
        Me.cmbmodules.FormattingEnabled = True
        Me.cmbmodules.Location = New System.Drawing.Point(48, 149)
        Me.cmbmodules.Name = "cmbmodules"
        Me.cmbmodules.Size = New System.Drawing.Size(321, 25)
        Me.cmbmodules.TabIndex = 27
        '
        'access_add
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(412, 396)
        Me.Controls.Add(Me.cmbmodules)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnSubmit)
        Me.Controls.Add(Me.rbInActive)
        Me.Controls.Add(Me.rbActive)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbusernames)
        Me.Controls.Add(Me.Panel5)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "access_add"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "access_add"
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label24 As Label
    Friend WithEvents cmbusernames As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents rbActive As RadioButton
    Friend WithEvents rbInActive As RadioButton
    Friend WithEvents lblclose As Label
    Friend WithEvents btnSubmit As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents cmbmodules As ComboBox
End Class
