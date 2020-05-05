Imports System.Data.SqlClient
Imports System.IO
Imports AK_POS.connection_class
Public Class newsfeed
    Dim cc As New connection_class()
    Dim con As New SqlConnection(cc.conString)
    Dim cmd As SqlCommand
    Dim rdr As SqlDataReader
    Dim adptr As New SqlDataAdapter

    Public manager As String = ""
    Private Sub btnclose_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Public Function decryptConString() As String
        Dim base64encoded As String = File.ReadAllText("connectionstring.txt")
        Dim data As Byte() = System.Convert.FromBase64String(base64encoded)
        Return System.Text.ASCIIEncoding.ASCII.GetString(data)
    End Function

    Public Sub loadMessages()
        Try
            FlowLayoutPanel1.Controls.Clear()
            Dim panelid As Integer = 1, query As String = ""

            If manager = "Manager" Then
                query = "SELECT tblmessages.message,(SELECT tblusers.fullname FROM tblusers WHERE tblusers.systemid=tblmessages.fromid) AS _from,(SELECT tblusers.fullname FROM tblusers WHERE tblusers.systemid=tblmessages.toid) AS _to, tblmessages.datecreated FROM tblmessages WHERE status='Active';"
                txtsend.Visible = True
                txtsendto.Visible = True
                btnsend.Visible = True
                Label10.Visible = True
            Else
                query = "SELECT tblmessages.message,(SELECT tblusers.fullname FROM tblusers WHERE tblusers.systemid=tblmessages.fromid) AS _from,(SELECT tblusers.fullname FROM tblusers WHERE tblusers.systemid=tblmessages.toid) AS _to, tblmessages.datecreated FROM tblmessages WHERE status='Active' AND toid=(SELECT tblusers.systemid FROM tblusers WHERE tblusers.username='" & login.username & "');"
                txtsend.Visible = False
                txtsendto.Visible = False
                btnsend.Visible = False
                Label10.Visible = False
            End If

            con.Open()
            cmd = New SqlCommand(query, con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                Dim pan As New Panel(), lbl As New Label(), txt As New TextBox(), lblTime As New Label(), lblDate As New Label()
                pan.Name = "pan" & panelid
                pan.Width = 828
                pan.Height = 100
                pan.BorderStyle = BorderStyle.FixedSingle
                pan.BackColor = Color.White

                lbl.Name = "lblname" & panelid
                lbl.Font = New Font("Arial", 15, FontStyle.Bold)
                lbl.ForeColor = Color.White
                lbl.Text = rdr("_from")
                lbl.Location = New Point(298, 2)
                lbl.Width = 1000

                txt.Name = "txtmessage" & panelid
                txt.Font = New Font("Arial", 11, FontStyle.Bold)
                txt.BackColor = Color.White
                If manager = "Manager" Then
                    txt.Text = "To: " & rdr("_to") & Environment.NewLine & "- " & rdr("message")
                Else
                    txt.Text = "- " & rdr("message")
                End If
                txt.Location = New Point(3, 40)
                txt.Width = 794
                txt.Height = 57
                txt.ForeColor = Color.Black
                txt.BorderStyle = BorderStyle.FixedSingle
                txt.Multiline = True
                txt.MaxLength = 1221211221
                txt.ReadOnly = True
                txt.Cursor = Cursors.Default
                txt.ScrollBars = ScrollBars.Vertical

                lblTime.Name = "lbltime" & panelid
                lblTime.Font = New Font("Arial", 11, FontStyle.Bold)
                lblTime.ForeColor = Color.DimGray
                lblTime.Height = 17
                lblTime.Width = 100
                lblTime.Location = New Point(3, 2)
                lblTime.Text = CDate(rdr("datecreated")).ToString("hh:mm tt")


                lblDate.Name = "lbldate" & panelid
                lblDate.Font = New Font("Arial", 11, FontStyle.Bold)
                lblDate.ForeColor = Color.DimGray
                lblDate.Height = 17
                lblDate.Width = 100
                lblDate.Location = New Point(100, 2)
                lblDate.Text = CDate(rdr("datecreated")).ToString("MM/dd/yyyy")


                FlowLayoutPanel1.Controls.Add(pan)
                pan.Controls.Add(lbl)
                pan.Controls.Add(txt)
                pan.Controls.Add(lblTime)
                pan.Controls.Add(lblDate)
                panelid += 1
            End While
            con.Close()
            If panelid = 1 Then
                lblerr.Visible = True
            Else
                lblerr.Visible = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Public Sub loadUsers()
        Try
            Dim auto As New AutoCompleteStringCollection()
            con.Open()
            cmd = New SqlCommand("SELECT username FROM tblusers WHERE status=1;", con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                auto.Add(rdr("username"))
            End While
            con.Close()
            txtsendto.AutoCompleteCustomSource = auto
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Private Sub btnsend_Click(sender As Object, e As EventArgs) Handles btnsend.Click
        Try
            If String.IsNullOrEmpty(txtsend.Text) And String.IsNullOrEmpty(txtsendto.Text) Then
                MessageBox.Show("Please fill all fields", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf String.IsNullOrEmpty(txtsendto.Text) Then
                MessageBox.Show("Send to field is empty", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf String.IsNullOrEmpty(txtsend.Text) Then
                MessageBox.Show("Message field is empty", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                If checkUser() = False Then
                    MessageBox.Show("User not found", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    con.Open()
                    cmd = New SqlCommand("INSERT INTO tblmessages (message,fromid,toid,datecreated,status) VALUES (@message,(SELECT tblusers.systemid FROM tblusers WHERE tblusers.username='" & login.username & "'),(SELECT tblusers.systemid FROM tblusers WHERE tblusers.username='" & txtsendto.Text & "'),(SELECT GETDATE()),@status);", con)
                    cmd.Parameters.AddWithValue("@message", txtsend.Text)
                    cmd.Parameters.AddWithValue("@status", "Active")
                    cmd.ExecuteNonQuery()
                    con.Close()
                    loadMessages()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Public Function checkUser() As Boolean
        Try
            Dim b As Boolean = False
            con.Open()
            cmd = New SqlCommand("SELECT systemid FROM tblusers WHERE username=@username;", con)
            cmd.Parameters.AddWithValue("@username", txtsendto.Text)
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                b = True
            End If
            con.Close()
            Return b
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Function
    Private Sub newsfeed_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadMessages()
        loadUsers()
    End Sub
End Class