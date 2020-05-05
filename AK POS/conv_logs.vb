Imports System.Data.SqlClient
Imports System.IO
Imports AK_POS.connection_class
Public Class conv_logs
    Dim cc As New connection_class
    Dim strconn As String = cc.conString
    Dim con As New SqlConnection(strconn)
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader
    Dim adptr As New SqlDataAdapter

    Public manager As String = ""

    Public Function decryptConString() As String
        Dim base64encoded As String = File.ReadAllText("connectionstring.txt")
        Dim data As Byte() = System.Convert.FromBase64String(base64encoded)
        Return System.Text.ASCIIEncoding.ASCII.GetString(data)
    End Function

    Public Sub categories1()
        con.Open()
        cmd = New SqlCommand("SELECT DISTINCT category FROM tblconversion WHERE status='Closed' AND type='Parent'", con)
        rdr = cmd.ExecuteReader()
        While rdr.Read()
            cmbcategory1.Items.Add(rdr("category"))
        End While
        con.Close()
        cmbcategory1.Items.Add("All")
        cmbcategory1.Text = "All"
    End Sub
    Public Sub load1(ByVal q As String, ByVal dd As String)
        Dim auto As New AutoCompleteStringCollection()
        Dim qdd As String = ""
        If dd = "" Then
            qdd = q
        Else
            qdd = q & dd
        End If
        dgv1.Rows.Clear()
        con.Open()
        cmd = New SqlCommand(qdd, con)
        TextBox1.Text = qdd
        rdr = cmd.ExecuteReader()
        While rdr.Read()
            auto.Add(rdr("item_code"))
            auto.Add(rdr("item_name"))
            auto.Add(rdr("inv_number"))
            auto.Add(rdr("conv_number"))
            Dim d As New DateTime()
            d = CDate(rdr("date_created"))
            dgv1.Rows.Add("", rdr("inv_number"), rdr("conv_number"), rdr("item_code"), rdr("item_name"), rdr("category"), rdr("quantity"), rdr("type"), d.ToString("MM/dd/yyyy hh:mm:ss tt"), rdr("reference_number"))
        End While
        con.Close()
        txtboxsearch1.AutoCompleteCustomSource = auto
    End Sub

    Private Sub cmbcategory1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbcategory1.SelectedIndexChanged
        If cmbcategory1.Text = "All" Then
            load1("SELECT * FROM tblconversion WHERE status='Closed' AND type='Parent' AND area='" & manager & "'", "")
        Else
            load1("SELECT * FROM tblconversion WHERE status='Closed' AND type='Parent' AND category='" & cmbcategory1.Text & "' AND area='" & manager & "'", "")
        End If
        txtboxsearch1.Text = ""
    End Sub

    Private Sub btnsearch1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsearch1.Click
        Dim query As String = ""
        Dim meron As Boolean = False
        If cmbcategory1.Text <> "All" Then
            query = "SELECT item_code,item_name,inv_number,conv_number FROM tblconversion WHERE  item_code=@itemcode OR item_name=@itemname OR inv_number=@invnum OR conv_number=@convnum AND status='Closed' AND type='Parent' AND category='" & cmbcategory1.Text & "'"
        Else
            query = "SELECT item_code,item_name,inv_number,conv_number FROM tblconversion WHERE  item_code=@itemcode OR item_name=@itemname OR inv_number=@invnum OR conv_number=@convnum AND status='Closed' AND type='Parent'"
        End If
        con.Open()
        cmd = New SqlCommand(query, con)
        cmd.Parameters.AddWithValue("@itemcode", txtboxsearch1.Text)
        cmd.Parameters.AddWithValue("@itemname", txtboxsearch1.Text)
        cmd.Parameters.AddWithValue("@invnum", txtboxsearch1.Text)
        cmd.Parameters.AddWithValue("@convnum", txtboxsearch1.Text)
        rdr = cmd.ExecuteReader()
        If rdr.Read Then
            For i As Integer = 0 To dgv1.Rows.Count - 1
                If dgv1.Rows(i).Cells("code").Value = rdr("item_code") Or dgv1.Rows(i).Cells("namee").Value = rdr("item_name") Then
                    dgv1.Rows(i).Selected = True
                    dgv1.CurrentCell = dgv1.Rows(i).Cells(0)
                    meron = True
                End If
            Next
        End If
        con.Close()
        If meron = False Then
            MessageBox.Show("No search found", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Public Sub load2(ByVal q As String)
        Dim auto As New AutoCompleteStringCollection()
        dgv2.Rows.Clear()
        con.Open()
        cmd = New SqlCommand(q, con)
        rdr = cmd.ExecuteReader()
        While rdr.Read()
            auto.Add(rdr("item_code"))
            auto.Add(rdr("item_name"))
            auto.Add(rdr("inv_number"))
            auto.Add(rdr("conv_number"))
            Dim d As New DateTime()
            d = CDate(rdr("date_created"))
            dgv2.Rows.Add(rdr("inv_number"), rdr("conv_number"), rdr("item_code"), rdr("item_name"), rdr("category"), rdr("quantity"), rdr("type"), d.ToString("MM/dd/yyyy hh:mm:ss tt"))
        End While
        con.Close()
        txtboxsearch2.AutoCompleteCustomSource = auto
    End Sub

    Private Sub dgv1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv1.CellContentClick, dgv1.CellClick
        load2("SELECT * FROM tblconversion WHERE status='Closed' AND type='Child' AND reference_number='" & dgv1.CurrentRow.Cells("reference").Value & "' AND area='" & manager & "'")

        con.Open()
        cmd = New SqlCommand("SELECT sap_id,remarks,typenum FROM tblconversion WHERE status='Closed' AND type='Parent' AND conv_number='" & dgv1.CurrentRow.Cells("reference").Value & "' AND area='" & manager & "'", con)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            lblsap.Text = rdr("sap_id")
            lblremark.Text = rdr("remarks")
            lbltypee.Text = rdr("typenum") & " #:"
        End If
        con.Close()

        con.Open()
        cmd = New SqlCommand("SELECT sap_id,remarks,typenum FROM tblconversion WHERE status='Closed' AND type='Child' AND reference_number='" & dgv1.CurrentRow.Cells("reference").Value & "' AND area='" & manager & "'", con)
        rdr = cmd.ExecuteReader
        If rdr.Read Then
            lblSAPNo.Text = rdr("sap_id")
            lblRemarks.Text = rdr("remarks")
            lbltype.Text = rdr("typenum") & " #:"
        End If
        con.Close()
    End Sub

    Private Sub conv_logs_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        dtfrom1.Value = DateTime.Now


        load1("SELECT * FROM tblconversion WHERE status='Closed' AND type='Parent' AND area='" & manager & "' AND CAST(date_created AS date)='" & dtfrom1.Text & "' AND area='" & manager & "'", "")
        categories1()
    End Sub

    Private Sub conv_logs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtfrom1.Value = DateTime.Now
        load1("SELECT * FROM tblconversion WHERE status='Closed' AND type='Parent' AND area='" & manager & "' AND CAST(date_created AS date)='" & dtfrom1.Text & "' AND area='" & manager & "'", "")
        categories1()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub dtfrom1_ValueChanged(sender As Object, e As EventArgs) Handles dtfrom1.ValueChanged
        cmbcategory1.Text = "All"
        load1("SELECT * FROM tblconversion WHERE status='Closed' AND type='Parent' AND CAST(date_created AS date)='" & dtfrom1.Text & "' AND area='" & manager & "'", "")
    End Sub
End Class