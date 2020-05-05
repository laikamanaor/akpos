<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dsalesreportaccnt
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dsalesreportaccnt))
        Me.datefrom = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.dateto = New System.Windows.Forms.DateTimePicker
        Me.btnok = New System.Windows.Forms.Button
        Me.btncancel = New System.Windows.Forms.Button
        Me.cmbcashier = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmbservice = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmbdisc = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmbtype = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'datefrom
        '
        Me.datefrom.Location = New System.Drawing.Point(142, 22)
        Me.datefrom.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.datefrom.MinDate = New Date(2017, 1, 1, 0, 0, 0, 0)
        Me.datefrom.Name = "datefrom"
        Me.datefrom.Size = New System.Drawing.Size(233, 21)
        Me.datefrom.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Transaction From:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(108, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(23, 15)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "To:"
        '
        'dateto
        '
        Me.dateto.Location = New System.Drawing.Point(142, 52)
        Me.dateto.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dateto.MinDate = New Date(2017, 1, 1, 0, 0, 0, 0)
        Me.dateto.Name = "dateto"
        Me.dateto.Size = New System.Drawing.Size(233, 21)
        Me.dateto.TabIndex = 5
        '
        'btnok
        '
        Me.btnok.Image = CType(resources.GetObject("btnok.Image"), System.Drawing.Image)
        Me.btnok.Location = New System.Drawing.Point(187, 250)
        Me.btnok.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnok.Name = "btnok"
        Me.btnok.Size = New System.Drawing.Size(87, 26)
        Me.btnok.TabIndex = 6
        Me.btnok.Text = "Ok"
        Me.btnok.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnok.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnok.UseVisualStyleBackColor = True
        '
        'btncancel
        '
        Me.btncancel.Image = CType(resources.GetObject("btncancel.Image"), System.Drawing.Image)
        Me.btncancel.Location = New System.Drawing.Point(288, 250)
        Me.btncancel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btncancel.Name = "btncancel"
        Me.btncancel.Size = New System.Drawing.Size(87, 26)
        Me.btncancel.TabIndex = 7
        Me.btncancel.Text = "Cancel"
        Me.btncancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btncancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btncancel.UseVisualStyleBackColor = True
        '
        'cmbcashier
        '
        Me.cmbcashier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbcashier.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbcashier.FormattingEnabled = True
        Me.cmbcashier.Location = New System.Drawing.Point(142, 93)
        Me.cmbcashier.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbcashier.Name = "cmbcashier"
        Me.cmbcashier.Size = New System.Drawing.Size(233, 23)
        Me.cmbcashier.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(77, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 15)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Cashier:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(56, 137)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 15)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Service type:"
        '
        'cmbservice
        '
        Me.cmbservice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbservice.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbservice.FormattingEnabled = True
        Me.cmbservice.Items.AddRange(New Object() {"All", "Take out", "Deliver"})
        Me.cmbservice.Location = New System.Drawing.Point(142, 134)
        Me.cmbservice.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbservice.Name = "cmbservice"
        Me.cmbservice.Size = New System.Drawing.Size(233, 23)
        Me.cmbservice.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(77, 179)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 15)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Choose:"
        '
        'cmbdisc
        '
        Me.cmbdisc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbdisc.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbdisc.FormattingEnabled = True
        Me.cmbdisc.Items.AddRange(New Object() {"All", "With Discount Only", "Without Discount Only"})
        Me.cmbdisc.Location = New System.Drawing.Point(142, 176)
        Me.cmbdisc.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbdisc.Name = "cmbdisc"
        Me.cmbdisc.Size = New System.Drawing.Size(233, 23)
        Me.cmbdisc.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(44, 212)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(87, 15)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Discount Type:"
        Me.Label6.Visible = False
        '
        'cmbtype
        '
        Me.cmbtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbtype.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbtype.FormattingEnabled = True
        Me.cmbtype.Location = New System.Drawing.Point(142, 209)
        Me.cmbtype.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbtype.Name = "cmbtype"
        Me.cmbtype.Size = New System.Drawing.Size(233, 23)
        Me.cmbtype.TabIndex = 3
        Me.cmbtype.Visible = False
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Vivaldi", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label7.Location = New System.Drawing.Point(3, 270)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(39, 13)
        Me.Label7.TabIndex = 42
        Me.Label7.Text = "-Jecel-"
        '
        'dsalesreportaccnt
        '
        Me.AcceptButton = Me.btnok
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(408, 292)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cmbtype)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cmbdisc)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmbservice)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmbcashier)
        Me.Controls.Add(Me.btncancel)
        Me.Controls.Add(Me.btnok)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dateto)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.datefrom)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dsalesreportaccnt"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sales Transaction Report (Accounting)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents datefrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dateto As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnok As System.Windows.Forms.Button
    Friend WithEvents btncancel As System.Windows.Forms.Button
    Friend WithEvents cmbcashier As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbservice As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbdisc As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbtype As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
