Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.IO
Imports System.Drawing
Imports AK_POS.connection_class
Public Class saveimg
    Dim cc As New connection_class
    Dim strconn As String = cc.conString
    Dim conn As SqlConnection
    Dim cmd As SqlCommand
    Dim dr As SqlDataReader
    Dim sql As String

    Dim path As String
    Dim filename As String

    Public Function decryptConString() As String
        Dim base64encoded As String = File.ReadAllText("connectionstring.txt")
        Dim data As Byte() = System.Convert.FromBase64String(base64encoded)
        Return System.Text.ASCIIEncoding.ASCII.GetString(data)
    End Function

    Public Sub connect()
        conn = New SqlConnection
        conn.ConnectionString = strconn
        If conn.State <> ConnectionState.Open Then
            conn.Open()
        End If
    End Sub

    Public Sub disconnect()
        conn = New SqlConnection
        conn.ConnectionString = strconn
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
    End Sub

    Private Sub saveimg_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        btnview.PerformClick()
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub saveimg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Cursor = Cursors.WaitCursor
            loadcat()
            frmload()
            path = (Microsoft.VisualBasic.Left(Application.StartupPath, Len(Application.StartupPath) - 9))
            loadimages()
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Information)
        Finally
            disconnect()
        End Try
    End Sub

    Public Sub frmload()
        Try
            Dim dgvImageColumn As New DataGridViewImageColumn
            dgvImageColumn.HeaderText = "Item Image"
            dgvImageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch
            dgvImageColumn.Width = 300
            grdimages.Columns.Add(dgvImageColumn)
            ' grdimages.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            grdimages.RowTemplate.Height = 100
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Information)
        Finally
            disconnect()
        End Try
    End Sub

    Public Sub loadcat()
        Try
            Me.Cursor = Cursors.WaitCursor
            cmbcat.Items.Clear()

            sql = "Select * from tblcat where status='1'"
            connect()
            cmd = New SqlCommand(sql, conn)
            dr = cmd.ExecuteReader
            While dr.Read
                cmbcat.Items.Add(dr(1).ToString)
            End While
            dr.Dispose()
            cmd.Dispose()
            Me.Cursor = Cursors.Default
        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Information)
        Finally
            disconnect()
        End Try
    End Sub

    Private Sub cmbcat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcat.Click
        loadcat()
    End Sub

    Private Sub cmbcat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbcat.SelectedIndexChanged
        Try
            If cmbcat.SelectedItem <> "" Then
                txtcode.Text = ""
                imgbox.BackgroundImage = Nothing
                loaditem()
            End If
            Panel1.Enabled = False
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Information)
        Finally
            disconnect()
        End Try
    End Sub

    Public Sub loaditem()
        cmbname.Items.Clear()
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim chk As Boolean = False
            sql = "Select * from tblitems where category='" & cmbcat.SelectedItem.ToString & "' and discontinued='0'"
            connect()
            cmd = New SqlCommand(sql, conn)
            dr = cmd.ExecuteReader
            While dr.Read
                chk = True
                cmbname.Items.Add(dr(3).ToString)
            End While
            dr.Dispose()
            cmd.Dispose()
            If chk = True Then
                cmbname.Enabled = True
            Else
                cmbname.Enabled = False
                Panel1.Enabled = False
            End If
            Me.Cursor = Cursors.Default

        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Information)
        Finally
            disconnect()
        End Try
    End Sub

    Private Sub cmbname_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbname.SelectedIndexChanged
        Try
            Me.Cursor = Cursors.WaitCursor
            If cmbcat.SelectedItem <> "" Then
                Panel1.Enabled = True
                btnbrowse.Enabled = False
                btncancel.Enabled = False

                sql = "Select * from tblitems where category='" & cmbcat.SelectedItem.ToString & "' and itemname='" & cmbname.SelectedItem.ToString & "' and discontinued='0'"
                connect()
                cmd = New SqlCommand(sql, conn)
                dr = cmd.ExecuteReader
                If dr.Read Then
                    filename = dr(2).ToString
                    txtcode.Text = dr(2).ToString
                End If
                dr.Dispose()
                cmd.Dispose()

                sql = "Select * from tblimage where name='" & txtcode.Text & "'"
                cmd = New SqlCommand(sql, conn)
                Dim dr1 As SqlDataReader = cmd.ExecuteReader()
                If dr1.HasRows Then
                    dr1.Read()
                    'txt_imgname.Text = dr("name").ToString()
                    Dim data As Byte() = DirectCast(dr1("img"), Byte())
                    Dim ms As New MemoryStream(data)
                    imgbox.BackgroundImage = Image.FromStream(ms)
                    imgbox.BackgroundImageLayout = ImageLayout.Stretch
                    ' img_box.Image = Image.FromStream(ms)
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
                dr1.Dispose()
                cmd.Dispose()

                imgbox.BackgroundImage = Nothing
                imgbox.BackColor = Color.Empty
                imgbox.Invalidate()
                MsgBox("No image", MsgBoxStyle.Critical, "")
                btnsave.Enabled = True
                txtpath.Text = ""
                btnsave.Focus()
                imgnull()
            End If
            Me.Cursor = Cursors.Default

        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Information)
        Finally
            disconnect()
        End Try
    End Sub

    Private Sub btnbrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbrowse.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim open As OpenFileDialog
            open = New OpenFileDialog
            open.FileName = ""
            open.Filter = "Image Formats(*.jpg;*.jpeg;*.bmp;*.gif;*.png;*.tif)|*.jpg;*.jpeg;*.bmp;*.gif;*.png;*.tif|JPEG Format(*.jpg;*.jpeg)|*.jpg;*.jpeg|BITMAP Format(*.bmp)|*.bmp|GIF Format(*.gif)|*.gif|PNG Format(*.png)|*.png"
            If open.ShowDialog = Windows.Forms.DialogResult.OK Then
                imgbox.BackgroundImageLayout = ImageLayout.Stretch
                imgbox.BackgroundImage = Image.FromFile(open.FileName.ToUpper)
                txtpath.Text = path
                'filename = open.SafeFileName.ToString() 'Get as image name
                btnsave.Focus()
            Else
                btncancel.PerformClick()
            End If
            Me.Cursor = Cursors.Default
            btnsave.Enabled = True
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            If btnsave.Text = "Update" Then
                imgbox.BackgroundImage = Nothing
                imgbox.BackColor = Color.Empty
                imgbox.Invalidate()
                btnbrowse.Enabled = True
                btncancel.Enabled = True
                btnsave.Text = "Save"
                MsgBox("Browse image first.", MsgBoxStyle.Information, "")
                btnbrowse.Focus()
                btnsave.Enabled = False
            ElseIf btnsave.Text = "Save" Then
                Dim ms As New MemoryStream()

                'search image name if existing
                connect()
                cmd = New SqlCommand("Select * from tblimage where name='" & filename & "'", conn)
                dr = cmd.ExecuteReader()
                If dr.Read = True Then
                    'update photo
                    MessageBox.Show("Image for " & cmbname.SelectedItem.ToString & " is already exist.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Dim msg As String = MsgBox("Are you sure you want to update image for " & cmbname.SelectedItem.ToString, MsgBoxStyle.Question + MsgBoxStyle.YesNo, "")
                    If msg <> vbYes Then
                        txtpath.Text = ""
                        btnsave.Text = "Update"
                        imgbox.BackgroundImage = Nothing
                        imgbox.BackColor = Color.Empty
                        imgbox.Invalidate()
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    Else
                        Dim imgidd As Integer = dr(0)
                        Dim code As String = dr(1)
                        dr.Dispose()
                        cmd.Dispose()

                        'sql = "Delete from tblimage where imgid='" & imgidd & "' and name=@name"
                        'cmd = New SqlCommand(sql, conn) 'New OleDbCommand(sql, conn)
                        'cmd.Parameters.AddWithValue("@name", code)
                        'cmd.ExecuteNonQuery()
                        'cmd.Dispose()

                        connect()
                        cmd = New SqlCommand("Update tblimage set img=@img where name=@name", conn)
                        cmd.Parameters.Add(New SqlClient.SqlParameter("name", filename))
                        imgbox.BackgroundImage.Save(ms, imgbox.BackgroundImage.RawFormat)
                        Dim data As Byte() = ms.GetBuffer()
                        Dim img As New SqlParameter("@img", SqlDbType.Image)
                        img.Value = data
                        cmd.Parameters.Add(img)
                        cmd.ExecuteNonQuery()

                        MessageBox.Show("Image saved.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        filename = Nothing
                        'imgbox.BackgroundImage = Nothing
                        txtpath.Text = ""
                        btnview.PerformClick()
                    End If
                    Me.Cursor = Cursors.Default
                Else
                    Dim msg As String = MsgBox("Are you sure you want to update image for " & cmbname.SelectedItem.ToString, MsgBoxStyle.Question + MsgBoxStyle.YesNo, "")
                    If msg <> vbYes Then
                        txtpath.Text = ""
                        btnsave.Text = "Update"
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    Else
                        'save record in database
                        connect()
                        cmd = New SqlCommand("Insert into tblimage values(@name,@img)", conn)
                        cmd.Parameters.Add(New SqlClient.SqlParameter("name", filename))
                        imgbox.BackgroundImage.Save(ms, imgbox.BackgroundImage.RawFormat)
                        Dim data As Byte() = ms.GetBuffer()
                        Dim img As New SqlParameter("@img", SqlDbType.Image)
                        img.Value = data
                        cmd.Parameters.Add(img)
                        cmd.ExecuteNonQuery()
                        MessageBox.Show("Image saved.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        txtpath.Text = ""
                        btnsave.Text = "Update"
                        'imgbox.BackgroundImage = Nothing
                        imgbox.BackColor = Color.Empty
                        imgbox.Invalidate()
                        Me.Cursor = Cursors.Default
                        btnview.PerformClick()
                    End If
                End If
                Me.Cursor = Cursors.Default
                btnsave.Text = "Update"
            End If
            Me.Cursor = Cursors.Default

        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            'MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
            MsgBox(ex.Message, MsgBoxStyle.Information)
        Finally
            disconnect()
        End Try
    End Sub

    Public Sub imgnull()
        If imgbox.BackgroundImage Is Nothing Then
            btnbrowse.Enabled = False
            btncancel.Enabled = False
        Else
            btnsave.Enabled = True
        End If
    End Sub

    Private Sub imgbox_BackgroundImageChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles imgbox.BackgroundImageChanged
        Try
            imgnull()
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Information)
        Finally
            disconnect()
        End Try
    End Sub

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        Try
            txtpath.Text = ""
            txtcode.Text = ""
            btnsave.Text = "Update"
            imgbox.BackgroundImage = Nothing
            imgbox.BackColor = Color.Empty
            imgbox.Invalidate()
            Panel1.Enabled = False
            cmbcat.Focus()
            loaditem()
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Information)
        Finally
            disconnect()
        End Try
    End Sub

    Public Sub loadimages()
        Try
            grdimages.Rows.Clear()
            Dim i As Integer = 0

            sql = "Select * from tblimage order by name"
            connect()
            cmd = New SqlCommand(sql, conn)
            dr = cmd.ExecuteReader
            Me.Cursor = Cursors.WaitCursor
            While dr.Read
                sql = "Select * from tblitems where itemcode='" & dr("name") & "' and discontinued='0'"
                connect()
                Dim cmd1 As SqlCommand = New SqlCommand(sql, conn)
                Dim dr1 As SqlDataReader = cmd1.ExecuteReader
                If dr1.Read Then
                    Dim data As Byte() = DirectCast(dr("img"), Byte())
                    Dim ms As New MemoryStream(data)

                    grdimages.Rows.Add(dr(0), dr(1), "name", Image.FromStream(ms))
                    i += 1
                End If
            End While
            dr.Dispose()
            cmd.Dispose()

            Me.Cursor = Cursors.Default

            'palitan ung namessssss
            connect()
            For Each row As DataGridViewRow In grdimages.Rows
                Me.Cursor = Cursors.WaitCursor
                sql = "Select itemname,itemcode from tblitems where itemcode='" & grdimages.Rows(row.Index).Cells(1).Value & "'"
                cmd = New SqlCommand(sql, conn)
                dr = cmd.ExecuteReader
                If dr.Read Then
                    grdimages.Rows(row.Index).Cells(2).Value = dr("itemname")
                End If
                dr.Dispose()
                cmd.Dispose()
            Next

            Me.Cursor = Cursors.Default

        Catch ex As System.Data.SqlClient.SqlException
            Me.Cursor = Cursors.Default
            MsgBox("The server was not found or was not accessible.", MsgBoxStyle.Critical, "Server Error")
        Catch ex As System.InvalidOperationException
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Critical, "")
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Information)
        Finally
            disconnect()
        End Try
    End Sub

    Private Sub btnview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.Click
        Try
            loadimages()
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Information)
        Finally
            disconnect()
        End Try
    End Sub
End Class