Imports System.IO
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Security
Imports System.Security.Cryptography
Imports System.Runtime.InteropServices
Imports System.Text.RegularExpressions
Imports System.Text
Imports AK_POS.connection_class
Public Class users
    Dim cc As New connection_class
    Dim strconn As String = cc.conString
    Dim conn As SqlConnection
    Dim cmd As SqlCommand
    Dim dr As SqlDataReader
    Dim sql As String

    Public Shared cnf As Integer = 0, firm As Boolean = False


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

    Private Sub users_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub users_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim a As String = MsgBox("Are you sure you want to close Manage Users Form?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "")
        If a = vbYes Then
            Me.Dispose()
        Else
            e.Cancel = True
        End If
    End Sub
    Public Sub loadBranches()
        Try
            cmbraout.Items.Clear()
            connect()
            cmd = New SqlCommand("SELECT branch FROM tblbranch WHERE status=1;", conn)
            dr = cmd.ExecuteReader
            While dr.Read
                cmbraout.Items.Add(dr("branch"))
            End While
            disconnect()
            cmbraout.Items.Add("All Branch/Outlet")
            cmbraout.SelectedIndex = 0
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Private Sub users_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Cursor = Cursors.WaitCursor
            loadBranches()
            viewall()

            cmbgroup.SelectedIndex = 0
            cmbpostype.SelectedIndex = 0
            If grdusers.Rows.Count = 0 Then
                btnupdate.Enabled = False
                btndeactivate.Enabled = False
            Else
                btnupdate.Enabled = True
                btndeactivate.Enabled = True
            End If
            grdselect()

            grdusers.Columns(1).Width = 160
            grdusers.Columns(2).Width = 140
            grdusers.Columns(3).Width = 120
            grdusers.Columns(4).Width = 120
            grdusers.Columns(5).Width = 120

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

    Public Sub viewall()
        Try
            Me.Cursor = Cursors.WaitCursor

            grdusers.Rows.Clear()
            Dim i As Integer = 0
            Dim pass As String = ""
            sql = "SELECT *,ISNULL((SELECT branch FROM tblbranch WHERE brid=tblusers.brid),'All Branch/Outlet') AS b from tblusers
"
            connect()
            cmd = New SqlCommand(sql, conn)
            dr = cmd.ExecuteReader
            While dr.Read
                Me.Cursor = Cursors.WaitCursor
                grdusers.Rows.Add()
                grdusers.Item(0, i).Value = dr("systemid")
                grdusers.Item(1, i).Value = dr("fullname")
                grdusers.Item(2, i).Value = dr("username")
                pass = Decrypt(dr("password"))
                If pass <> "" Then
                    grdusers.Item(3, i).Value = New String(CChar("*"), pass.Length)
                End If

                grdusers.Item(4, i).Value = dr("workgroup")
                grdusers.Item(5, i).Value = dr("b")
                grdusers.Item(8, i).Value = dr("postype")
                If dr("status") = 1 Then
                    grdusers.Item(6, i).Value = "Active"
                Else
                    grdusers.Item(6, i).Value = "Deactivated"
                End If
                grdusers.Item(7, i).Value = pass
                i += 1
            End While
            dr.Dispose()
            cmd.Dispose()

            Me.Cursor = Cursors.Default

            If pass <> "" Then
                chkpass.Enabled = True
            End If
            grdselect()

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

    Private Sub btnupdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnupdate.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            If grdusers.SelectedRows.Count = 1 Or grdusers.SelectedCells.Count = 1 Then
                If btnupdate.Text = "Update" Then
                    If grdusers.Rows(grdusers.CurrentRow.Index).Cells(4).Value = "Administrator" And login.neym <> "Administrator" Then
                        MsgBox("Authorization Failed.", MsgBoxStyle.Critical, "")
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If


                    If grdusers.Rows(grdusers.CurrentRow.Index).Cells(5).Value = "Deactivated" Then
                        MsgBox("Cannot update deactivated user account.", MsgBoxStyle.Exclamation, "")
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If

                    chkpass.Enabled = True
                    btnadd.Enabled = False
                    btndeactivate.Enabled = False
                    btncancel.Enabled = True
                    txtpass.Enabled = False
                    txtconfirm.Enabled = False

                    lbluserid.Text = grdusers.Rows(grdusers.CurrentRow.Index).Cells(0).Value
                    txtfull.Text = grdusers.Rows(grdusers.CurrentRow.Index).Cells(1).Value
                    txtusername.Text = grdusers.Rows(grdusers.CurrentRow.Index).Cells(2).Value



                    txtpass.Text = grdusers.Rows(grdusers.CurrentRow.Index).Cells(7).Value
                    txtpass.Tag = grdusers.Rows(grdusers.CurrentRow.Index).Cells(7).Value
                    cmbgroup.SelectedItem = grdusers.Rows(grdusers.CurrentRow.Index).Cells(4).Value
                    cmbraout.SelectedItem = grdusers.Rows(grdusers.CurrentRow.Index).Cells(5).Value
                    cmbpostype.SelectedItem = grdusers.Rows(grdusers.CurrentRow.Index).Cells("postype").Value
                    lblcas.Text = txtusername.Text

                    btnupdate.Text = "Save"
                Else
                    If txtpass.Enabled = True And (Trim(txtusername.Text) = "" Or Trim(txtpass.Text) = "" Or Trim(txtconfirm.Text) = "" Or cmbgroup.Text = "") And cmbraout.SelectedIndex = -1 Then
                        MsgBox("Complete the fields.", MsgBoxStyle.Exclamation, "")
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                    Try
                        Me.Cursor = Cursors.WaitCursor
                        Dim readd As Integer = 0
                        Dim a As String = MsgBox("Are you sure you want to update record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "")
                        If a = vbYes Then
                            confirm.ShowDialog()
                            If firm = False Then
                                Me.Cursor = Cursors.Default
                                Exit Sub
                            End If
                            sql = "Select * from tblusers where systemid='" & lbluserid.Text & "'"
                            connect()
                            cmd = New SqlCommand(sql, conn)
                            dr = cmd.ExecuteReader
                            If dr.Read Then
                                readd = 1
                            End If
                            dr.Dispose()
                            cmd.Dispose()
                            disconnect()

                            If readd = 1 Then

                                Dim z As Integer = 0
                                connect()
                                cmd = New SqlCommand("SELECT brid FROM tblbranch WHERE branch=@branch;", conn)
                                cmd.Parameters.AddWithValue("@branch", cmbraout.SelectedItem)
                                dr = cmd.ExecuteReader
                                If dr.Read Then
                                    z = CInt(dr("brid"))
                                End If
                                disconnect()

                                connect()
                                sql = "Update tblusers set fullname='" & Trim(txtfull.Text) & "', username='" & Trim(txtusername.Text) & "', password='" & Encrypt(Trim(txtpass.Text)) & "', workgroup='" & Trim(cmbgroup.SelectedItem) & "', datemodified=(SELECT GETDATE()), modifiedby='" & login.cashier & "',brid='" & IIf(cmbraout.SelectedIndex = cmbraout.Items.Count - 1, 0, z) & "',postype='" & cmbpostype.Text & "' where systemid='" & lbluserid.Text & "' "
                                cmd = New SqlCommand(sql, conn) 'New OleDbCommand(sql, conn)
                                cmd.ExecuteNonQuery()
                                cmd.Dispose()
                                disconnect()

                                If (cmbgroup.SelectedIndex) = 0 Then
                                    'update tbltransaction
                                    sql = "Update tbltransaction set cashier='" & Trim(txtusername.Text) & "' where cashier='" & lblcas.Text & "'"
                                    connect()
                                    cmd = New SqlCommand(sql, conn)
                                    cmd.ExecuteNonQuery()
                                    cmd.Dispose()
                                    disconnect()

                                    'update tbllogin
                                    sql = "Update tbllogin set username='" & Trim(txtusername.Text) & "' where username='" & lblcas.Text & "'"
                                    connect()
                                    cmd = New SqlCommand(sql, conn)
                                    cmd.ExecuteNonQuery()
                                    cmd.Dispose()
                                    disconnect()
                                End If

                                MsgBox("Successfully Saved.", MsgBoxStyle.Information, "")
                                btncancel.PerformClick()
                                btnviewall.PerformClick()
                            End If
                            firm = False
                            Me.Cursor = Cursors.Default
                        Else
                            btncancel.PerformClick()
                            firm = False
                            Me.Cursor = Cursors.Default
                            Exit Sub
                        End If
                    Catch ex As Exception
                        Me.Cursor = Cursors.Default
                        MsgBox(ex.Message, MsgBoxStyle.Information)
                    Finally
                        disconnect()
                    End Try

                    btnupdate.Text = "Update"
                    btncancel.Enabled = False
                    btnadd.Enabled = True
                    btndeactivate.Enabled = Enabled
                End If
            Else
                MsgBox("Select only one.", MsgBoxStyle.Exclamation, "")
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

    Private Sub btnviewall_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnviewall.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            btncancel.PerformClick()
            txtfull.Text = ""
            txtusername.Text = ""
            txtpass.Text = ""
            txtpass.Enabled = True
            txtconfirm.Text = ""
            txtconfirm.Enabled = False
            cmbgroup.SelectedIndex = 0
            chkpass.Checked = False
            btnupdate.Text = "Update"
            btnadd.Enabled = True
            btncancel.Enabled = False
            cmbgroup.Enabled = True

            viewall()
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Information)
        Finally
            disconnect()
        End Try
    End Sub

    Public Function Encrypt(ByVal plainText As String) As String

        Dim passPhrase As String = "minePassPhrase"
        Dim saltValue As String = "mySaltValue"
        Dim hashAlgorithm As String = "SHA1"

        Dim passwordIterations As Integer = 2
        Dim initVector As String = "@1B2c3D4e5F6g7H8"
        Dim keySize As Integer = 256

        Dim initVectorBytes As Byte() = Encoding.ASCII.GetBytes(initVector)
        Dim saltValueBytes As Byte() = Encoding.ASCII.GetBytes(saltValue)

        Dim plainTextBytes As Byte() = Encoding.UTF8.GetBytes(plainText)


        Dim password As New PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations)

        Dim keyBytes As Byte() = password.GetBytes(keySize \ 8)
        Dim symmetricKey As New RijndaelManaged()

        symmetricKey.Mode = CipherMode.CBC

        Dim encryptor As ICryptoTransform = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes)

        Dim memoryStream As New MemoryStream()
        Dim cryptoStream As New CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write)

        cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length)
        cryptoStream.FlushFinalBlock()
        Dim cipherTextBytes As Byte() = memoryStream.ToArray()
        memoryStream.Close()
        cryptoStream.Close()
        Dim cipherText As String = Convert.ToBase64String(cipherTextBytes)
        Return cipherText
    End Function

    Public Function Decrypt(ByVal cipherText As String) As String
        Dim passPhrase As String = "minePassPhrase"
        Dim saltValue As String = "mySaltValue"
        Dim hashAlgorithm As String = "SHA1"

        Dim passwordIterations As Integer = 2
        Dim initVector As String = "@1B2c3D4e5F6g7H8"
        Dim keySize As Integer = 256
        ' Convert strings defining encryption key characteristics into byte
        ' arrays. Let us assume that strings only contain ASCII codes.
        ' If strings include Unicode characters, use Unicode, UTF7, or UTF8
        ' encoding.
        Dim initVectorBytes As Byte() = Encoding.ASCII.GetBytes(initVector)
        Dim saltValueBytes As Byte() = Encoding.ASCII.GetBytes(saltValue)

        ' Convert our ciphertext into a byte array.
        Dim cipherTextBytes As Byte() = Convert.FromBase64String(cipherText)

        ' First, we must create a password, from which the key will be 
        ' derived. This password will be generated from the specified 
        ' passphrase and salt value. The password will be created using
        ' the specified hash algorithm. Password creation can be done in
        ' several iterations.
        Dim password As New PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations)

        ' Use the password to generate pseudo-random bytes for the encryption
        ' key. Specify the size of the key in bytes (instead of bits).
        Dim keyBytes As Byte() = password.GetBytes(keySize / 8)

        ' Create uninitialized Rijndael encryption object.
        Dim symmetricKey As New RijndaelManaged()

        ' It is reasonable to set encryption mode to Cipher Block Chaining
        ' (CBC). Use default options for other symmetric key parameters.
        symmetricKey.Mode = CipherMode.CBC

        ' Generate decryptor from the existing key bytes and initialization 
        ' vector. Key size will be defined based on the number of the key 
        ' bytes.
        Dim decryptor As ICryptoTransform = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes)

        ' Define memory stream which will be used to hold encrypted data.
        Dim memoryStream As New MemoryStream(cipherTextBytes)

        ' Define cryptographic stream (always use Read mode for encryption).
        Dim cryptoStream As New CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read)

        ' Since at this point we don't know what the size of decrypted data
        ' will be, allocate the buffer long enough to hold ciphertext;
        ' plaintext is never longer than ciphertext.
        Dim plainTextBytes As Byte() = New Byte(cipherTextBytes.Length - 1) {}

        ' Start decrypting.
        Dim decryptedByteCount As Integer = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length)

        ' Close both streams.
        memoryStream.Close()
        cryptoStream.Close()

        ' Convert decrypted data into a string. 
        ' Let us assume that the original plaintext string was UTF8-encoded.
        Dim plainText As String = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount)

        ' Return decrypted string.   
        Return plainText
    End Function

    Private Sub chkpass_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkpass.CheckedChanged
        If chkpass.Checked = True Then
            txtpass.PasswordChar = ""
        Else
            txtpass.PasswordChar = "*"
        End If
    End Sub

    Private Sub link_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles link.LinkClicked
        If btnupdate.Text = "Save" Then
            txtpass.Text = ""
            txtpass.Enabled = True
            txtpass.Focus()
            btncancel.Enabled = True
        End If
    End Sub

    Private Sub txtpass_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpass.Leave
        Try
            Me.Cursor = Cursors.WaitCursor
            If Trim(txtpass.Text) <> "" Then
                If Trim(txtpass.Text) = Trim(txtpass.Tag) Then
                    MsgBox("New password is similar to old password. Try another password.", MsgBoxStyle.Critical, "")
                    txtpass.Text = ""
                    txtpass.Focus()
                    txtconfirm.Enabled = False
                    txtconfirm.Text = ""
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
                txtconfirm.Enabled = True
                txtconfirm.Focus()
            Else
                txtconfirm.Enabled = False
            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Information)
        Finally
            disconnect()
        End Try
    End Sub

    Private Sub txtconfirm_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtconfirm.Leave
        Try
            If Trim(txtpass.Text) <> Trim(txtconfirm.Text) Then
                txtconfirm.Text = ""
                txtconfirm.Enabled = False
                txtpass.Text = ""
                MsgBox("Password not match.", MsgBoxStyle.Critical, "")
                txtpass.Focus()
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
            If btnupdate.Text = "Save" Then
                btnupdate.Focus()
            Else
                btnadd.Focus()
            End If
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Information)
        Finally
            disconnect()
        End Try
    End Sub

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        'If btnupdate.Text = "Save" Then
        txtfull.Text = ""
        txtusername.Text = ""
        txtpass.Text = ""
        txtpass.Enabled = True
        txtconfirm.Text = ""
        txtconfirm.Enabled = False
        cmbgroup.SelectedIndex = 0
        chkpass.Checked = False
        btnupdate.Text = "Update"
        btnadd.Enabled = True
        btncancel.Enabled = False
        cmbgroup.Enabled = True
        cmbpostype.SelectedIndex = 0
        'End If
    End Sub

    Private Sub btnadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadd.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            If grdusers.Rows.Count <> 0 Then
                If btnadd.Text = "Add" Then

                    If cmbraout.SelectedIndex = -1 Then
                        MsgBox("Please select branch/outlet", MsgBoxStyle.Exclamation, "")
                        cmbraout.Focus()
                        Exit Sub
                    End If

                    sql = "Select * from tblusers where username='" & Trim(txtusername.Text) & "' and status='1'"
                    connect()
                    cmd = New SqlCommand(sql, conn)
                    dr = cmd.ExecuteReader
                    If dr.Read Then
                        MsgBox("Username is already exist.", MsgBoxStyle.Information, "")
                        txtusername.Text = ""
                    End If
                    dr.Dispose()
                    cmd.Dispose()


                    sql = "Select * from tblusers where fullname='" & Trim(txtfull.Text) & "' and status='1'"
                    connect()
                    cmd = New SqlCommand(sql, conn)
                    dr = cmd.ExecuteReader
                    If dr.Read Then
                        MsgBox("Full name is already exist.", MsgBoxStyle.Information, "")
                        txtfull.Text = ""
                    End If
                    dr.Dispose()
                    cmd.Dispose()


                    If Trim(txtfull.Text) = "" Or Trim(txtusername.Text) = "" Or Trim(txtpass.Text) = "" Or Trim(txtconfirm.Text) = "" Or cmbgroup.Text = "" Then
                        MsgBox("Complete the fields.", MsgBoxStyle.Exclamation, "")
                        txtusername.Focus()
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If

                    'For Each row As DataGridViewRow In grdusers.Rows
                    '    If grdusers.Rows(row.Index).Cells(4).Value = "Administrator" And cmbgroup.SelectedIndex = 2 Then
                    '        MsgBox("Administrator is already exist.", MsgBoxStyle.Information, "")
                    '        cmbgroup.SelectedIndex = 0
                    '        Me.Cursor = Cursors.Default
                    '        Exit Sub
                    '    End If
                    'Next

                    Dim a As String = MsgBox("Are you sure you want to add user?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "")
                    If a = vbYes Then
                        confirm.ShowDialog()
                        If firm = False Then
                            Me.Cursor = Cursors.Default
                            Exit Sub
                        End If
                        Try
                            Dim z As Integer = 0
                            connect()
                            cmd = New SqlCommand("SELECT brid FROM tblbranch WHERE branch=@branch;", conn)
                            cmd.Parameters.AddWithValue("@branch", cmbraout.SelectedItem)
                            dr = cmd.ExecuteReader
                            If dr.Read Then
                                z = CInt(dr("brid"))
                            End If
                            disconnect()

                            sql = "Insert into tblusers(fullname,username,password,workgroup,datecreated,createdby,datemodified,modifiedby,status,brid,postype)values('" & Trim(txtfull.Text) & "','" & Trim(txtusername.Text) & "','" & Encrypt(Trim(txtpass.Text)) & "','" & cmbgroup.SelectedItem & "',(SELECT GETDATE()),'" & login.cashier & "',(SELECT GETDATE()),'" & login.cashier & "','1','" & IIf(cmbraout.SelectedIndex = cmbraout.Items.Count - 1, 0, z) & "','" & cmbpostype.Text & "')"
                            connect()
                            cmd = New SqlCommand(sql, conn)
                            cmd.ExecuteNonQuery()
                            MsgBox("Successfully Added.", MsgBoxStyle.Information, "")
                            btncancel.PerformClick()
                            btnviewall.PerformClick()
                            firm = False

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
                    End If
                End If
            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Information)
        Finally
            disconnect()
        End Try
    End Sub

    Private Sub txtusername_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtusername.TextChanged
        Dim charactersDisallowed As String = "abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ 0123456789.-/"
        Dim theText As String = txtusername.Text
        Dim Letter As String
        Dim SelectionIndex As Integer = txtusername.SelectionStart
        Dim Change As Integer

        For x As Integer = 0 To txtusername.Text.Length - 1
            Letter = txtusername.Text.Substring(x, 1)
            If Not charactersDisallowed.Contains(Letter) Then
                theText = theText.Replace(Letter, String.Empty)
                Change = 1
            End If
        Next

        txtusername.Text = theText
        txtusername.Select(SelectionIndex - Change, 0)

        If Trim(txtusername.Text) <> "" And btnupdate.Text = "Update" Then
            btncancel.Enabled = True
        Else
            btncancel.Enabled = False
        End If
    End Sub

    Private Sub txtpass_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpass.TextChanged
        Dim charactersDisallowed As String = "'"
        Dim theText As String = txtpass.Text
        Dim Letter As String
        Dim SelectionIndex As Integer = txtpass.SelectionStart
        Dim Change As Integer

        For x As Integer = 0 To txtpass.Text.Length - 1
            Letter = txtpass.Text.Substring(x, 1)
            If charactersDisallowed.Contains(Letter) Then
                theText = theText.Replace(Letter, String.Empty)
                Change = 1
            End If
        Next

        txtpass.Text = theText
        txtpass.Select(SelectionIndex - Change, 0)

        If Trim(txtpass.Text) <> "" And btnupdate.Text = "Update" Then
            btncancel.Enabled = True
        ElseIf Trim(txtpass.Text) <> "" And btnupdate.Text = "Save" Then
            btncancel.Enabled = True
        ElseIf Trim(txtpass.Text) = "" And btnupdate.Text = "Save" Then
            btncancel.Enabled = True
        Else
            btncancel.Enabled = False
        End If
    End Sub

    Private Sub btndeactivate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndeactivate.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            If grdusers.Rows.Count <> 0 Then
                If grdusers.SelectedCells.Count = 1 Or grdusers.SelectedRows.Count = 1 Then
                    Try
                        Dim a As String = MsgBox("Are you sure you want to " & btndeactivate.Text & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "")
                        If a = vbYes Then
                            confirm.ShowDialog()
                            If firm = False Then
                                Me.Cursor = Cursors.Default
                                Exit Sub
                            End If

                            If btndeactivate.Text = "Deactivate" Then
                                sql = "Update tblusers set status='0' where systemid='" & grdusers.Rows(grdusers.CurrentRow.Index).Cells(0).Value & "' and workgroup<>'Administrator'"
                            Else
                                sql = "Update tblusers set status='1' where systemid='" & grdusers.Rows(grdusers.CurrentRow.Index).Cells(0).Value & "' and workgroup<>'Administrator'"
                            End If
                            connect()
                            cmd = New SqlCommand(sql, conn)
                            cmd.ExecuteNonQuery()

                            btnviewall.PerformClick()

                            Me.Cursor = Cursors.Default
                        End If

                    Catch ex As System.InvalidOperationException
                        Me.Cursor = Cursors.Default
                        MsgBox(ex.Message, MsgBoxStyle.Critical, "")
                    Catch ex As Exception
                        Me.Cursor = Cursors.Default
                        MsgBox(ex.Message, MsgBoxStyle.Information)
                    Finally
                        disconnect()
                    End Try
                Else
                    MsgBox("Select only one.", MsgBoxStyle.Exclamation, "")
                End If
                firm = False
            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Information)
        Finally
            disconnect()
        End Try
    End Sub

    Private Sub grdusers_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdusers.SelectionChanged
        grdselect()
    End Sub

    Public Sub grdselect()
        Try
            Me.Cursor = Cursors.WaitCursor
            If grdusers.Rows.Count <> 0 Then
                If grdusers.Rows(grdusers.CurrentRow.Index).Cells(5).Value = "Active" Then
                    btndeactivate.Text = "Deactivate"
                Else
                    btndeactivate.Text = "Activate"
                End If
                If grdusers.Rows(grdusers.CurrentRow.Index).Cells(4).Value = "Administrator" Then
                    btndeactivate.Enabled = False
                Else
                    btndeactivate.Enabled = True
                End If
            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Information)
        Finally
            disconnect()
        End Try
    End Sub

    Private Sub txtfull_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtfull.Leave
        txtfull.Text = StrConv(txtfull.Text, VbStrConv.ProperCase)
    End Sub

    Private Sub txtfull_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtfull.TextChanged
        Dim charactersDisallowed As String = "abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ 0123456789.-/"
        Dim theText As String = txtfull.Text
        Dim Letter As String
        Dim SelectionIndex As Integer = txtfull.SelectionStart
        Dim Change As Integer

        For x As Integer = 0 To txtfull.Text.Length - 1
            Letter = txtfull.Text.Substring(x, 1)
            If Not charactersDisallowed.Contains(Letter) Then
                theText = theText.Replace(Letter, String.Empty)
                Change = 1
            End If
        Next

        txtfull.Text = theText
        txtfull.Select(SelectionIndex - Change, 0)
    End Sub

    Private Sub txtconfirm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtconfirm.TextChanged
        Dim charactersDisallowed As String = "'"
        Dim theText As String = txtconfirm.Text
        Dim Letter As String
        Dim SelectionIndex As Integer = txtconfirm.SelectionStart
        Dim Change As Integer

        For x As Integer = 0 To txtconfirm.Text.Length - 1
            Letter = txtconfirm.Text.Substring(x, 1)
            If charactersDisallowed.Contains(Letter) Then
                theText = theText.Replace(Letter, String.Empty)
                Change = 1
            End If
        Next

        txtconfirm.Text = theText
        txtconfirm.Select(SelectionIndex - Change, 0)
    End Sub
End Class