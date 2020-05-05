Public Class hourly
    Public temph1 As Integer, temph2 As Integer, temph3 As Integer, temph4 As Integer, temph5 As Integer, temph6 As Integer
    Public temph7 As Integer, temph8 As Integer, temph9 As Integer, temph10 As Integer, temph11 As Integer, temph12 As Integer, temph13 As Integer

    Public salesh1 As Double, salesh2 As Double, salesh3 As Double, salesh4 As Double, salesh5 As Double, salesh6 As Double
    Public salesh7 As Double, salesh8 As Double, salesh9 As Double, salesh10 As Double, salesh11 As Double, salesh12 As Double, salesh13 As Double

    Private Sub hourly_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        lbldate.Text = ""
        lblcash.Text = ""
        grdhour.Rows.Clear()
    End Sub

    Private Sub hourly_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            grdhour.Rows.Clear()

            grdhour.Rows.Add("01", "08:00 - 08:59  AM", temph1, salesh1)
            grdhour.Rows.Add("02", "09:00 - 09:59  AM", temph2, salesh2)
            grdhour.Rows.Add("03", "10:00 - 10:59  AM", temph3, salesh3)
            grdhour.Rows.Add("04", "11:00 - 11:59   AM", temph4, salesh4)
            grdhour.Rows.Add("05", "12:00 - 12:59  PM", temph5, salesh5)
            grdhour.Rows.Add("06", "01:00 - 01:59  PM", temph6, salesh6)
            grdhour.Rows.Add("07", "02:00 - 02:59  PM", temph7, salesh7)
            grdhour.Rows.Add("08", "03:00 - 03:59  PM", temph8, salesh8)
            grdhour.Rows.Add("09", "04:00 - 04:59  PM", temph9, salesh9)
            grdhour.Rows.Add("10", "05:00 - 05:59  PM", temph10, salesh10)
            grdhour.Rows.Add("11", "06:00 - 06:59  PM", temph11, salesh11)
            grdhour.Rows.Add("12", "07:00 - 07:59  PM", temph12, salesh12)
            grdhour.Rows.Add("13", "08:00 - 08:59  PM", temph13, salesh13)
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Information)
        End Try
    End Sub
End Class