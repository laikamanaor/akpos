<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class inv_logs_items
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(inv_logs_items))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.itemname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.del_qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.act_qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.variance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lbltransnum = New System.Windows.Forms.Label()
        Me.lblfromBranch = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.spinner = New System.Windows.Forms.PictureBox()
        Me.lblclose = New System.Windows.Forms.Label()
        Me.Panel5.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.spinner, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(755, 1)
        Me.Panel1.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Black
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 1)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1, 362)
        Me.Panel2.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Black
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel3.Location = New System.Drawing.Point(754, 1)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1, 362)
        Me.Panel3.TabIndex = 1
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Black
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(1, 362)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(753, 1)
        Me.Panel4.TabIndex = 1
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.Panel5.Controls.Add(Me.lblclose)
        Me.Panel5.Controls.Add(Me.Panel6)
        Me.Panel5.Controls.Add(Me.Label1)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(1, 1)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(753, 37)
        Me.Panel5.TabIndex = 29
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.Gold
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(1, 37)
        Me.Panel6.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(23, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 22)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ITEMS"
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.AllowUserToResizeColumns = False
        Me.dgv.AllowUserToResizeRows = False
        Me.dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgv.BackgroundColor = System.Drawing.Color.White
        Me.dgv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(28, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgv.ColumnHeadersHeight = 40
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.itemname, Me.del_qty, Me.act_qty, Me.variance})
        Me.dgv.EnableHeadersVisualStyles = False
        Me.dgv.GridColor = System.Drawing.Color.Black
        Me.dgv.Location = New System.Drawing.Point(28, 97)
        Me.dgv.Name = "dgv"
        Me.dgv.RowHeadersVisible = False
        Me.dgv.Size = New System.Drawing.Size(702, 214)
        Me.dgv.TabIndex = 30
        '
        'itemname
        '
        Me.itemname.HeaderText = "Item"
        Me.itemname.Name = "itemname"
        Me.itemname.ReadOnly = True
        '
        'del_qty
        '
        Me.del_qty.HeaderText = "Delivered Qty."
        Me.del_qty.Name = "del_qty"
        Me.del_qty.ReadOnly = True
        '
        'act_qty
        '
        Me.act_qty.HeaderText = "Actual Qty."
        Me.act_qty.Name = "act_qty"
        Me.act_qty.ReadOnly = True
        '
        'variance
        '
        Me.variance.HeaderText = "Variance"
        Me.variance.Name = "variance"
        Me.variance.ReadOnly = True
        '
        'lbltransnum
        '
        Me.lbltransnum.AutoSize = True
        Me.lbltransnum.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltransnum.ForeColor = System.Drawing.Color.Black
        Me.lbltransnum.Location = New System.Drawing.Point(134, 60)
        Me.lbltransnum.Name = "lbltransnum"
        Me.lbltransnum.Size = New System.Drawing.Size(30, 15)
        Me.lbltransnum.TabIndex = 31
        Me.lbltransnum.Text = "N/A"
        '
        'lblfromBranch
        '
        Me.lblfromBranch.AutoSize = True
        Me.lblfromBranch.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfromBranch.ForeColor = System.Drawing.Color.Black
        Me.lblfromBranch.Location = New System.Drawing.Point(134, 79)
        Me.lblfromBranch.Name = "lblfromBranch"
        Me.lblfromBranch.Size = New System.Drawing.Size(30, 15)
        Me.lblfromBranch.TabIndex = 32
        Me.lblfromBranch.Text = "N/A"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DimGray
        Me.Label2.Location = New System.Drawing.Point(25, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 15)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "BRANCH:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DimGray
        Me.Label3.Location = New System.Drawing.Point(25, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(103, 15)
        Me.Label3.TabIndex = 33
        Me.Label3.Text = "REFERENCE #:"
        '
        'spinner
        '
        Me.spinner.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.spinner.Image = CType(resources.GetObject("spinner.Image"), System.Drawing.Image)
        Me.spinner.Location = New System.Drawing.Point(308, 317)
        Me.spinner.Name = "spinner"
        Me.spinner.Size = New System.Drawing.Size(118, 34)
        Me.spinner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.spinner.TabIndex = 58
        Me.spinner.TabStop = False
        '
        'lblclose
        '
        Me.lblclose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblclose.AutoSize = True
        Me.lblclose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblclose.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblclose.ForeColor = System.Drawing.Color.White
        Me.lblclose.Location = New System.Drawing.Point(729, 7)
        Me.lblclose.Name = "lblclose"
        Me.lblclose.Size = New System.Drawing.Size(21, 22)
        Me.lblclose.TabIndex = 2
        Me.lblclose.Text = "X"
        '
        'inv_logs_items
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(755, 363)
        Me.Controls.Add(Me.spinner)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblfromBranch)
        Me.Controls.Add(Me.lbltransnum)
        Me.Controls.Add(Me.dgv)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "inv_logs_items"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "inv_logs_items"
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.spinner, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents dgv As DataGridView
    Friend WithEvents itemname As DataGridViewTextBoxColumn
    Friend WithEvents del_qty As DataGridViewTextBoxColumn
    Friend WithEvents act_qty As DataGridViewTextBoxColumn
    Friend WithEvents variance As DataGridViewTextBoxColumn
    Friend WithEvents lbltransnum As Label
    Friend WithEvents lblfromBranch As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents spinner As PictureBox
    Friend WithEvents lblclose As Label
End Class
