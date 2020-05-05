<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class sap_uploading
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
        Me.datee = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnok = New System.Windows.Forms.Button()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.btnsap = New System.Windows.Forms.Button()
        Me.btnendingbal = New System.Windows.Forms.Button()
        Me.btncs = New System.Windows.Forms.Button()
        Me.btnconversion = New System.Windows.Forms.Button()
        Me.btnpo = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblclose = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'datee
        '
        Me.datee.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.datee.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.datee.Location = New System.Drawing.Point(210, 173)
        Me.datee.Name = "datee"
        Me.datee.Size = New System.Drawing.Size(136, 26)
        Me.datee.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ButtonShadow
        Me.Label1.Location = New System.Drawing.Point(231, 152)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 18)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Enter Date:"
        '
        'btnok
        '
        Me.btnok.BackColor = System.Drawing.Color.ForestGreen
        Me.btnok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnok.FlatAppearance.BorderSize = 0
        Me.btnok.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnok.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnok.ForeColor = System.Drawing.Color.White
        Me.btnok.Location = New System.Drawing.Point(384, 216)
        Me.btnok.Name = "btnok"
        Me.btnok.Size = New System.Drawing.Size(130, 34)
        Me.btnok.TabIndex = 2
        Me.btnok.Text = "OK"
        Me.btnok.UseVisualStyleBackColor = False
        '
        'btnsap
        '
        Me.btnsap.BackColor = System.Drawing.Color.ForestGreen
        Me.btnsap.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnsap.FlatAppearance.BorderSize = 0
        Me.btnsap.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnsap.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsap.ForeColor = System.Drawing.Color.Black
        Me.btnsap.Location = New System.Drawing.Point(16, 82)
        Me.btnsap.Name = "btnsap"
        Me.btnsap.Size = New System.Drawing.Size(124, 30)
        Me.btnsap.TabIndex = 3
        Me.btnsap.Text = "SAP"
        Me.btnsap.UseVisualStyleBackColor = False
        '
        'btnendingbal
        '
        Me.btnendingbal.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnendingbal.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnendingbal.FlatAppearance.BorderSize = 0
        Me.btnendingbal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnendingbal.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnendingbal.ForeColor = System.Drawing.Color.White
        Me.btnendingbal.Location = New System.Drawing.Point(141, 82)
        Me.btnendingbal.Name = "btnendingbal"
        Me.btnendingbal.Size = New System.Drawing.Size(158, 30)
        Me.btnendingbal.TabIndex = 4
        Me.btnendingbal.Text = "Ending Balance Short"
        Me.btnendingbal.UseVisualStyleBackColor = False
        '
        'btncs
        '
        Me.btncs.BackColor = System.Drawing.SystemColors.HotTrack
        Me.btncs.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btncs.FlatAppearance.BorderSize = 0
        Me.btncs.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btncs.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btncs.ForeColor = System.Drawing.Color.White
        Me.btncs.Location = New System.Drawing.Point(409, 82)
        Me.btncs.Name = "btncs"
        Me.btncs.Size = New System.Drawing.Size(105, 30)
        Me.btncs.TabIndex = 6
        Me.btncs.Text = "Coffee Shop"
        Me.btncs.UseVisualStyleBackColor = False
        '
        'btnconversion
        '
        Me.btnconversion.BackColor = System.Drawing.Color.OrangeRed
        Me.btnconversion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnconversion.FlatAppearance.BorderSize = 0
        Me.btnconversion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnconversion.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnconversion.ForeColor = System.Drawing.Color.White
        Me.btnconversion.Location = New System.Drawing.Point(300, 82)
        Me.btnconversion.Name = "btnconversion"
        Me.btnconversion.Size = New System.Drawing.Size(108, 30)
        Me.btnconversion.TabIndex = 7
        Me.btnconversion.Text = "Conversion"
        Me.btnconversion.UseVisualStyleBackColor = False
        '
        'btnpo
        '
        Me.btnpo.BackColor = System.Drawing.Color.DeepPink
        Me.btnpo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnpo.FlatAppearance.BorderSize = 0
        Me.btnpo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnpo.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnpo.ForeColor = System.Drawing.Color.White
        Me.btnpo.Location = New System.Drawing.Point(16, 113)
        Me.btnpo.Name = "btnpo"
        Me.btnpo.Size = New System.Drawing.Size(124, 30)
        Me.btnpo.TabIndex = 8
        Me.btnpo.Text = "P.O"
        Me.btnpo.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.Panel1.Controls.Add(Me.lblclose)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(541, 33)
        Me.Panel1.TabIndex = 9
        '
        'lblclose
        '
        Me.lblclose.AutoSize = True
        Me.lblclose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblclose.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblclose.ForeColor = System.Drawing.Color.White
        Me.lblclose.Location = New System.Drawing.Point(517, 6)
        Me.lblclose.Name = "lblclose"
        Me.lblclose.Size = New System.Drawing.Size(21, 22)
        Me.lblclose.TabIndex = 11
        Me.lblclose.Text = "X"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(3, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(171, 22)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "SAP UPLOADING"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.DimGray
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 286)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(541, 1)
        Me.Panel3.TabIndex = 11
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.DimGray
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel4.Location = New System.Drawing.Point(0, 33)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1, 253)
        Me.Panel4.TabIndex = 11
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.DimGray
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel5.Location = New System.Drawing.Point(540, 33)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1, 253)
        Me.Panel5.TabIndex = 11
        '
        'sap_uploading
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(541, 287)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnpo)
        Me.Controls.Add(Me.btnconversion)
        Me.Controls.Add(Me.btncs)
        Me.Controls.Add(Me.btnendingbal)
        Me.Controls.Add(Me.btnsap)
        Me.Controls.Add(Me.btnok)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.datee)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "sap_uploading"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SAP Upload"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents datee As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents btnok As Button
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents btnsap As Button
    Friend WithEvents btnendingbal As Button
    Friend WithEvents btncs As Button
    Friend WithEvents btnconversion As Button
    Friend WithEvents btnpo As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents lblclose As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel5 As Panel
End Class
