Imports System.Data.SqlClient
Imports System.IO
Imports AK_POS.connection_class
Public Class loginlogs
    Dim cc As New connection_class
    Dim strconn As String = cc.conString
    Dim con As New SqlConnection(strconn)
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader

    Public Function decryptConString() As String
        Dim base64encoded As String = File.ReadAllText("connectionstring.txt")
        Dim data As Byte() = System.Convert.FromBase64String(base64encoded)
        Return System.Text.ASCIIEncoding.ASCII.GetString(data)
    End Function
    Public Function getSystemDate() As DateTime
        Try
            Dim dt As New DateTime()
            con.Open()
            cmd = New SqlCommand("SELECT GETDATE()", con)
            rdr = cmd.ExecuteReader()
            While rdr.Read
                dt = CDate(rdr(0).ToString)
            End While
            con.Close()
            Return dt
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            con.Close()
        End Try
    End Function
    Private Sub loginlogs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        load_usernames()
        dtfrom.Value = getSystemDate()
        dtto.Value = getSystemDate.AddDays(1)
        dtfrom.MaxDate = getSystemDate()
        dtto.MaxDate = getSystemDate.AddDays(1)
    End Sub
    Public Sub load_usernames()
        cmbusername.Items.Clear()
        cmbusername.Items.Add("All")
        con.Open()
        cmd = New SqlCommand("SELECT username FROM tblusers", con)
        rdr = cmd.ExecuteReader()
        While rdr.Read
            cmbusername.Items.Add(rdr("username"))
        End While
        con.Close()
    End Sub
    Public Sub load_data(ByVal q As String)
        dgvlogs.Rows.Clear()
        con.Open()
        cmd = New SqlCommand(q, con)
        rdr = cmd.ExecuteReader()
        While rdr.Read
            Dim d As New DateTime()
            d = rdr("datelogin")
            dgvlogs.Rows.Add(rdr("username"), rdr("login"), rdr("logout"), d.ToString("MM/dd/yyyy"))
        End While
        con.Close()
        If dgvlogs.Rows.Count = 0 Then
            lblerror.Visible = True
        Else
            lblerror.Visible = False
        End If
    End Sub

    Private Sub cmbusername_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbusername.SelectedIndexChanged
        If cmbusername.SelectedIndex = 0 Then
            load_data("SELECT username,login,logout,datelogin FROM tbllogin WHERE datelogin BETWEEN '" & dtfrom.Value & "' AND '" & dtto.Value & "';")
        Else
            load_data("SELECT username,login,logout,datelogin FROM tbllogin WHERE username='" & cmbusername.Text & "' AND datelogin BETWEEN '" & dtfrom.Value & "' AND '" & dtto.Value & "';")
        End If
    End Sub

    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Dim a As String = MsgBox("Are you sure you want to close?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "")
        If a = vbYes Then
            Me.Close()
        End If
    End Sub

    Private Sub dtfrom_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtfrom.ValueChanged
        If cmbusername.SelectedIndex = 0 Then
            load_data("SELECT username,login,logout,datelogin FROM tbllogin WHERE datelogin BETWEEN '" & dtfrom.Text & "' AND '" & dtto.Text & "';")
        Else
            load_data("SELECT username,login,logout,datelogin FROM tbllogin WHERE username='" & cmbusername.Text & "' AND datelogin BETWEEN '" & dtfrom.Value & "' AND '" & dtto.Value & "';")
        End If
    End Sub

    Private Sub dtto_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtto.ValueChanged
        If cmbusername.SelectedIndex = 0 Then
            load_data("SELECT username,login,logout,datelogin FROM tbllogin WHERE datelogin BETWEEN '" & dtfrom.Text & "' AND '" & dtto.Text & "';")
        Else
            load_data("SELECT username,login,logout,datelogin FROM tbllogin WHERE username='" & cmbusername.Text & "' AND datelogin BETWEEN '" & dtfrom.Value & "' AND '" & dtto.Value & "';")
        End If
    End Sub
End Class