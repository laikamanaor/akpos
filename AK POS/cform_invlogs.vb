Imports System.Data.SqlClient
Imports System.IO
Public Class cform_invlogs
    Dim strconn As String = login.ss
    Dim con As New SqlConnection(strconn)
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader
    Dim adptr As New SqlDataAdapter

    Public query As String = "", typez As String = "", datez As String = ""

    Public Function decryptConString() As String
        Dim base64encoded As String = File.ReadAllText("connectionstring.txt")
        Dim data As Byte() = System.Convert.FromBase64String(base64encoded)
        Return System.Text.ASCIIEncoding.ASCII.GetString(data)
    End Function

    Private Sub cform_invlogs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        con.Open()
        cmd = New SqlCommand(query, con)
        adptr = New SqlDataAdapter(cmd)
        Dim ds As New DataSet()
        adptr.Fill(ds, "tblproduction")
        Dim c_form As New c_invlogs()
        c_form.SetDataSource(ds)
        c_form.SetParameterValue("typez", typez)
        c_form.SetParameterValue("datez", datez)
        c_form.SetParameterValue("processed_by", login.neym)
        CrystalReportViewer1.ReportSource = c_form
        CrystalReportViewer1.Refresh()
        con.Close()
    End Sub
End Class