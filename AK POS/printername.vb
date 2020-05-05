Imports System.Drawing.Printing

Public Class printername

    Private Sub printername_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PopulateInstalledPrintersCombo()
    End Sub

    Private Sub PopulateInstalledPrintersCombo()
        ' Add list of installed printers found to the combo box.
        ' The pkInstalledPrinters string will be used to provide the display string.
        Dim i As Integer
        Dim pkInstalledPrinters As String

        For i = 0 To PrinterSettings.InstalledPrinters.Count - 1
            pkInstalledPrinters = PrinterSettings.InstalledPrinters.Item(i)
            cmbprinter.Items.Add(pkInstalledPrinters)
        Next
    End Sub

    Private Sub cmbprinter_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbprinter.SelectedIndexChanged
        ' Set the printer to a printer in the combo box when the selection changes.

        If cmbprinter.SelectedIndex <> -1 Then
            ' The combo box's Text property returns the selected item's text, which is the printer name.
            dailysalesprev.printerneym = cmbprinter.Text
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class