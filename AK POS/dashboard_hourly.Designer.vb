<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class dashboard_hourly
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea3 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend3 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series3 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea4 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend4 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series4 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.chartitems = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.chartsales = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.chartar = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.chartpostype = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.dtdate = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbsales = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.chartitems, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chartsales, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chartar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chartpostype, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chartitems
        '
        Me.chartitems.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ChartArea1.Name = "ChartArea1"
        Me.chartitems.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.chartitems.Legends.Add(Legend1)
        Me.chartitems.Location = New System.Drawing.Point(12, 53)
        Me.chartitems.Name = "chartitems"
        Me.chartitems.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Series1.YValuesPerPoint = 2
        Me.chartitems.Series.Add(Series1)
        Me.chartitems.Size = New System.Drawing.Size(1094, 194)
        Me.chartitems.TabIndex = 0
        Me.chartitems.Text = "Chart1"
        '
        'chartsales
        '
        Me.chartsales.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ChartArea2.Name = "ChartArea1"
        Me.chartsales.ChartAreas.Add(ChartArea2)
        Legend2.Name = "Legend1"
        Me.chartsales.Legends.Add(Legend2)
        Me.chartsales.Location = New System.Drawing.Point(12, 254)
        Me.chartsales.Name = "chartsales"
        Series2.ChartArea = "ChartArea1"
        Series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar
        Series2.Legend = "Legend1"
        Series2.Name = "Series1"
        Series2.YValuesPerPoint = 2
        Me.chartsales.Series.Add(Series2)
        Me.chartsales.Size = New System.Drawing.Size(635, 277)
        Me.chartsales.TabIndex = 1
        Me.chartsales.Text = "Chart2"
        '
        'chartar
        '
        Me.chartar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ChartArea3.Name = "ChartArea1"
        Me.chartar.ChartAreas.Add(ChartArea3)
        Legend3.Name = "Legend1"
        Me.chartar.Legends.Add(Legend3)
        Me.chartar.Location = New System.Drawing.Point(653, 254)
        Me.chartar.Name = "chartar"
        Me.chartar.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel
        Series3.ChartArea = "ChartArea1"
        Series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut
        Series3.Legend = "Legend1"
        Series3.Name = "Series1"
        Series3.YValuesPerPoint = 2
        Me.chartar.Series.Add(Series3)
        Me.chartar.Size = New System.Drawing.Size(453, 147)
        Me.chartar.TabIndex = 2
        Me.chartar.Text = "Chart3"
        '
        'chartpostype
        '
        Me.chartpostype.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ChartArea4.Name = "ChartArea1"
        Me.chartpostype.ChartAreas.Add(ChartArea4)
        Legend4.Name = "Legend1"
        Me.chartpostype.Legends.Add(Legend4)
        Me.chartpostype.Location = New System.Drawing.Point(653, 407)
        Me.chartpostype.Name = "chartpostype"
        Me.chartpostype.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SemiTransparent
        Series4.ChartArea = "ChartArea1"
        Series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea
        Series4.Legend = "Legend1"
        Series4.Name = "Series1"
        Series4.YValuesPerPoint = 2
        Me.chartpostype.Series.Add(Series4)
        Me.chartpostype.Size = New System.Drawing.Size(453, 124)
        Me.chartpostype.TabIndex = 3
        Me.chartpostype.Text = "Chart4"
        '
        'dtdate
        '
        Me.dtdate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtdate.CustomFormat = "MM/dd/yyyy"
        Me.dtdate.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtdate.Location = New System.Drawing.Point(12, 24)
        Me.dtdate.Name = "dtdate"
        Me.dtdate.Size = New System.Drawing.Size(131, 26)
        Me.dtdate.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 18)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Date:"
        '
        'cmbsales
        '
        Me.cmbsales.BackColor = System.Drawing.Color.DodgerBlue
        Me.cmbsales.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbsales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbsales.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbsales.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbsales.ForeColor = System.Drawing.Color.White
        Me.cmbsales.FormattingEnabled = True
        Me.cmbsales.Location = New System.Drawing.Point(149, 24)
        Me.cmbsales.Name = "cmbsales"
        Me.cmbsales.Size = New System.Drawing.Size(163, 26)
        Me.cmbsales.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(146, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 18)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Sales:"
        '
        'dashboard_hourly
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1118, 543)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbsales)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtdate)
        Me.Controls.Add(Me.chartpostype)
        Me.Controls.Add(Me.chartar)
        Me.Controls.Add(Me.chartsales)
        Me.Controls.Add(Me.chartitems)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "dashboard_hourly"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "dashboard_hourly"
        CType(Me.chartitems, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chartsales, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chartar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chartpostype, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents chartitems As DataVisualization.Charting.Chart
    Friend WithEvents chartsales As DataVisualization.Charting.Chart
    Friend WithEvents chartar As DataVisualization.Charting.Chart
    Friend WithEvents chartpostype As DataVisualization.Charting.Chart
    Friend WithEvents dtdate As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbsales As ComboBox
    Friend WithEvents Label2 As Label
End Class
