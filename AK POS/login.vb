Imports System.Data.OleDb
Imports System.IO
Imports System.Data.SqlClient
Imports System.Security
Imports System.Security.Cryptography
Imports System.Runtime.InteropServices
Imports System.Text.RegularExpressions
Imports System.Text

Public Class login
    Dim strconn As String = Decrypt(System.IO.File.ReadAllText("connectionstring.txt"))
    Public Shared ss As String = ""
    Dim sql As String
    Dim conn As SqlConnection
    Dim dr As SqlDataReader
    Dim cmd As SqlCommand
    Dim a As String
    Public neym As String
    Public cashier As String
    Dim cutoff As Boolean = False

    Public Shared wrkgrp As String = ""

    Public timein As String = ""
    Public Shared username As String = "", inv_id As String = ""
    Public Shared braout As String = ""

    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer


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
        Catch ex As SqlException
            If ex.Number = 2 Then
                MessageBox.Show("Timeout Occured", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)

        End Try
    End Sub
    Public Function loadBranch() As String
        Dim result As String = ""
        connect()
        cmd = New SqlCommand("SELECT branch FROM tblbranch WHERE brid=(SELECT brid FROM tblusers WHERE username=@username) AND status=1;", conn)
        cmd.Parameters.AddWithValue("@username", txtusername.Text)
        dr = cmd.ExecuteReader
        If dr.Read Then
            result = dr("branch")
        End If
        disconnect()
        Return result
    End Function
    Private Sub login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer1.Start()
        txtusername.Focus()
        'txtusername.Text = ""
        'txtpass.Text = ""
        '  loadBranches()
    End Sub

    Public Sub checkLM()
        Try
            getID()
            Dim lm As Boolean = False, status As String = "", date_from As New DateTime()
            connect()
            cmd = New SqlCommand("SELECT status,date FROM tblcutoff WHERE userid=(SELECT systemid FROM tblusers WHERE username=@username) ORDER BY cid DESC;", conn)
            cmd.Parameters.AddWithValue("@username", login.username)
            dr = cmd.ExecuteReader
            If dr.Read Then
                lm = True
                status = dr("status")
                date_from = CDate(dr("date"))
            Else
                lm = False
            End If
            disconnect()
            If lm Then
                If status = "In Active" And date_from.ToString("MM/dd/yyyy") = getSystemDate().ToString("MM/dd/yyyy") Then
                ElseIf status = "In Active" And date_from.ToString("MM/dd/yyyy") <> getSystemDate().ToString("MM/dd/yyyy") Then
                    connect()
                    cmd = New SqlCommand("INSERT INTO tblcutoff (userid,status,date) VALUES ((SELECT systemid FROM tblusers WHERE username=@username2), 'Active',GETDATE());", conn)
                    cmd.Parameters.AddWithValue("@username2", login.username)
                    cmd.ExecuteNonQuery()
                    disconnect()
                ElseIf status = "Active" And date_from.ToString("MM/dd/yyyy") <> getSystemDate().ToString("MM/dd/yyyy") Then
                ElseIf status = "Active" And date_from.ToString("MM/dd/yyyy") = getSystemDate().ToString("MM/dd/yyyy") Then
                End If
            Else
                connect()
                cmd = New SqlCommand("INSERT INTO tblcutoff (userid,status,date) VALUES ((SELECT systemid FROM tblusers WHERE username=@username2), 'Active',GETDATE());", conn)
                cmd.Parameters.AddWithValue("@username2", login.username)
                cmd.ExecuteNonQuery()
                disconnect()
            End If
            Me.Cursor = Cursors.Default
        Catch ex As SqlException
            If ex.Number = -2 Then
                MessageBox.Show("Timeout Occurred", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Public Function checkLuckyMoney() As Boolean
        Try
            Dim d As New DateTime()
            connect()
            cmd = New SqlCommand("SELECT date FROM tblcredits WHERE systemid=(SELECT systemid FROM tblusers WHERE username=@username) ORDER BY date DESC;", conn)
            cmd.Parameters.AddWithValue("@username", txtusername.Text)
            dr = cmd.ExecuteReader
            If dr.Read Then
                d = CDate(dr("date"))
            End If
            disconnect()
            If d.ToString("MM/dd/yyyy") <> getSystemDate().ToString("MM/dd/yyyy") Then
                Return True
            End If
        Catch ex As SqlException
            If ex.Number = -2 Then
                MessageBox.Show("Timeout Occurred", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Function

    Public Sub updateMain()
        Try
            connect()
            cmd = New SqlCommand("UPDATE tblbranch SET main=0;", conn)
            cmd.ExecuteNonQuery()
            disconnect()

            connect()
            cmd = New SqlCommand("UPDATE tblbranch SET main=1 WHERE branch=@branch;", conn)
            cmd.Parameters.AddWithValue("@branch", cmbraout.SelectedItem)
            cmd.ExecuteNonQuery()
            disconnect()
        Catch ex As SqlException
            If ex.Number = -2 Then
                MessageBox.Show("Timeout Occurred", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Public Sub updateCredits()
        Try
            Dim systemDate As String = getSystemDate.AddDays(-1).ToString("MM/dd/yyyy")
            connect()
            cmd = New SqlCommand("UPDATE tblcredits SET status='In Active' WHERE CAST(date AS date)='" & systemDate & "';", conn)
            cmd.ExecuteNonQuery()
            disconnect()
        Catch ex As SqlException
            If ex.Number = -2 Then
                MessageBox.Show("Timeout Occurred", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Private Sub btnlogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnlogin.Click
        Try
            username = txtusername.Text
            connect()
            cmd = New SqlCommand("SELECT version FROM tblversion WHERE version='" & lblversions.Text & "' AND status='0';", conn)
            dr = cmd.ExecuteReader()
            If dr.Read Then
                MessageBox.Show("Your system is outdated", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            disconnect()
            updateCredits()
            If Trim(txtusername.Text) = "" Or Trim(txtpass.Text) = "" Then
                MsgBox("Incomplete Fields.", MsgBoxStyle.Exclamation, "Login")
                txtusername.Focus()
                Me.Cursor = Cursors.Default
                Exit Sub
            Else

                sql = "SELECT * from tblusers"
                connect()
                cmd = New SqlCommand(sql, conn) 'New OleDbCommand(sql, conn)
                dr = cmd.ExecuteReader
                While dr.Read
                    Me.Cursor = Cursors.WaitCursor
                    If txtusername.Text = dr("username").ToString And txtpass.Text = Decrypt(dr("password").ToString) And dr("workgroup").ToString = "Cashier" Then
                        If dr("status").ToString = "0" Then
                            MsgBox("Account Deactivated", MsgBoxStyle.Exclamation, "Status")
                            txtusername.Text = ""
                            txtpass.Text = ""
                            txtusername.Focus()
                            Me.Cursor = Cursors.Default
                            Exit Sub
                        Else
                            wrkgrp = dr("workgroup").ToString
                            neym = "Cashier"
                            cashier = txtusername.Text

                            'If checkLuckyMoney() Then
                            '    MessageBox.Show("Add Lucky Money first", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            '    Me.Cursor = Cursors.Default
                            '    Exit Sub
                            'End If

                            braout = loadBranch()

                            insertLogs()
                            checkLM()
                            'updateMain()

                            ss = strconn
                            'If cutoff = True Then
                            '    txtusername.Focus()
                            '    txtusername.Text = ""
                            '    txtpass.Text = ""
                            '    cutoff = False
                            '    Me.Cursor = Cursors.Default
                            '    Exit Sub
                            'End If
                            username = txtusername.Text
                            txtusername.Focus()
                            txtusername.Text = ""
                            txtpass.Text = ""
                            Me.Cursor = Cursors.Default


                            Me.Hide()
                            Dim frm As New main()
                            frm.ShowDialog()
                            Me.Cursor = Cursors.Default
                            Exit Sub
                        End If
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    ElseIf txtusername.Text = dr("username").ToString And txtpass.Text = Decrypt(dr("password").ToString) And dr("workgroup").ToString = "Sales" Then
                        wrkgrp = dr("workgroup").ToString
                        neym = "Sales"
                        ss = strconn


                        checkLM()
                        ' updateMain()
                        insertLogs()
                        braout = loadBranch()

                        username = txtusername.Text
                        cashier = txtusername.Text
                        txtusername.Focus()
                        txtusername.Text = ""
                        txtpass.Text = ""
                        Me.Cursor = Cursors.Default

                        pos_dialog.ShowDialog()

                        Me.Hide()
                        Dim cas As New main()
                        cas.ShowDialog()
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    ElseIf txtusername.Text = dr("username").ToString And txtpass.Text = Decrypt(dr("password").ToString) And dr("workgroup").ToString = "LC Accounting" Then
                        wrkgrp = dr("workgroup").ToString
                        neym = "LC Accounting"

                        ' updateMain()
                        insertLogs()

                        ss = strconn

                        braout = loadBranch()

                        username = txtusername.Text
                        cashier = txtusername.Text
                        txtusername.Focus()
                        txtusername.Text = ""
                        txtpass.Text = ""
                        Me.Cursor = Cursors.Default
                        Me.Hide()
                        Dim frm As New main()
                        frm.Show()
                        Exit Sub
                    ElseIf txtusername.Text = dr("username").ToString And txtpass.Text = Decrypt(dr("password").ToString) And dr("workgroup").ToString = "Production" Then
                        insertLogs()
                        wrkgrp = "Production"
                        neym = "Production"

                        checkLM()
                        ' updateMain()

                        braout = loadBranch()

                        ss = strconn

                        username = txtusername.Text
                        cashier = txtusername.Text
                        txtusername.Focus()
                        txtusername.Text = ""
                        txtpass.Text = ""
                        Me.Cursor = Cursors.Default
                        Me.Hide()
                        Dim frm As New main()
                        frm.ShowDialog()
                        Exit Sub
                    ElseIf txtusername.Text = dr("username").ToString And txtpass.Text = Decrypt(dr("password").ToString) And dr("workgroup").ToString = "Administrator" Then
                        wrkgrp = "Administrator"
                        neym = "Administrator"
                        cashier = txtusername.Text

                        ss = strconn

                        'checkLM()
                        ' updateMain()
                        braout = loadBranch()
                        insertLogs()

                        username = txtusername.Text
                        txtusername.Focus()
                        txtusername.Text = ""
                        txtpass.Text = ""
                        Me.Cursor = Cursors.Default
                        Me.Hide()
                        Dim frm As New main()
                        frm.ShowDialog()
                        Exit Sub
                    ElseIf txtusername.Text = dr("username").ToString And txtpass.Text = Decrypt(dr("password").ToString) And dr("workgroup").ToString = "Manager" Then
                        insertLogs()
                        wrkgrp = "Manager"
                        neym = "Manager"

                        ' updateMain()
                        braout = loadBranch()
                        ss = strconn

                        pos_dialog.ShowDialog()

                        username = txtusername.Text
                        cashier = txtusername.Text
                        txtusername.Focus()
                        txtusername.Text = ""
                        txtpass.Text = ""
                        Me.Cursor = Cursors.Default
                        Me.Hide()
                        Dim frm As New main()
                        frm.ShowDialog()
                        Exit Sub
                    End If
                End While
                dr.Close()
                cmd.Dispose()
                MsgBox("Invalid Username or Password", MsgBoxStyle.Critical, "Invalid")
                txtusername.Text = ""
                txtpass.Text = ""
                txtusername.Focus()
                Me.Cursor = Cursors.Default
            End If
            'Catch ex As System.Data.SqlClient.SqlException
            'Me.Cursor = Cursors.Default
            'MsgBox("The server was not found or was not accessible.", MsgBoxStyle.Critical, "Server Error")
        Catch ex As SqlException
            If ex.Number = -2 Then
                MessageBox.Show("Timeout Occurred", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As System.FormatException
            Me.Cursor = Cursors.Default
            MsgBox("Invalid Username or Password", MsgBoxStyle.Critical, "Invalid")
            txtusername.Text = ""
            txtpass.Text = ""
            txtusername.Focus()
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Information)
        Finally
            disconnect()
        End Try
    End Sub
    Public Sub insertLogs()
        Try
            Dim dd As String = getSystemDate.ToString("hh:mm tt")
            Dim dt As String = getSystemDate.ToString("MM/dd/yyyy")
            connect()
            cmd = New SqlCommand("INSERT INTO tbllogin (username,login,logout,datelogin) VALUES (@username,@login,@logout,@datelogin)", conn)
            cmd.Parameters.AddWithValue("@username", username)
            cmd.Parameters.AddWithValue("@login", dd)
            cmd.Parameters.AddWithValue("@logout", dd)
            cmd.Parameters.AddWithValue("@datelogin", dt)
            cmd.ExecuteNonQuery()
            disconnect()
        Catch ex As SqlException
            If ex.Number = -2 Then
                MessageBox.Show("Timeout Occurred", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            disconnect()
        End Try
    End Sub
    Private Sub txtusername_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtusername.KeyPress
        If Asc(e.KeyChar) = Windows.Forms.Keys.Enter Then
            btnlogin.PerformClick()
        End If
    End Sub

    Private Sub txtpass_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpass.KeyPress
        If Asc(e.KeyChar) = Windows.Forms.Keys.Enter Then
            btnlogin.PerformClick()
        End If
    End Sub

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
        Dim keyBytes As Byte() = password.GetBytes(keySize \ 8)

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

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Label4.Text = Date.Now.ToString
    End Sub
    Public Sub getID()
        Try
            Dim id As String = ""
            Dim date_ As New DateTime()
            connect()
            cmd = New SqlCommand("Select TOP 1 invnum, datecreated from tblinvsum WHERE area='Sales' order by invsumid DESC", conn)
            dr = cmd.ExecuteReader()
            If dr.Read() Then
                id = dr("invnum")
                date_ = CDate(dr("datecreated"))
            End If
            If date_.ToString("MM/dd/yyyy") = getSystemDate.ToString("MM/dd/yyyy") Then
                inv_id = id
            Else
                inv_id = "N/A"
            End If
        Catch ex As SqlException
            If ex.Number = -2 Then
                MessageBox.Show("Timeout Occurred", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception

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

    Private Sub login_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Me.Focus()
    End Sub

    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Application.Exit()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        wrkgrp = "Cashier"
        main.Show()
    End Sub

    Private Sub btnminimize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnminimize.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ss = strconn
        Dim frm As New heyy()
        frm.ShowDialog()
    End Sub

    Private Sub btnok_Click(sender As Object, e As EventArgs) Handles btnok.Click
        connect()
        cmd = New SqlCommand("select a.description, sum(quantity)-isnull(x." & "cash_free" & ",0)[sold],ISNULL(x.cash_free,0)[cash_free],ISNULL(x.ar_charged_free,0)[ar_charged_free],ISNULL(x.ar_sales_free,0)[ar_sales_free],i3.itemcode,i3.price,x.ar_sales_free2,x.ar_charged_free2 from tblars2 a left join tblars1 b on a.transnum=b.transnum LEFT JOIN tblitems i3 ON a.description = i3.itemname outer apply (SELECT a1.itemname,ISNULL(SUM(CASE WHEN a2.tendertype = 'CASH' THEN a1.qty END),0)[cash_free],ISNULL(SUM(CASE WHEN a2.tendertype = 'A.R Sales'  AND a2.customer=@name THEN a1.qty END),0)[ar_sales_free],ISNULL(SUM(CASE WHEN a2.tendertype = 'A.R Charge' AND a2.customer=@name THEN a1.qty END),0)[ar_charged_free],ISNULL(SUM(CASE WHEN a2.tendertype = 'A.R Charge'  THEN a1.qty END),0)[ar_charged_free2],ISNULL(SUM(CASE WHEN a2.tendertype = 'A.R Sales'  THEN a1.qty END),0)[ar_sales_free2]  FROM tblorder a1 LEFT JOIN tbltransaction a2 on a1.transnum=a2.transnum WHERE a.description = a1.itemname AND a1.free = 1 AND CAST(a2.datecreated AS date)='" & "02/17/2020" & "' GROUP BY a1.itemname)x where cast(b.date_created As Date) ='" & "02/17/2020" & "' AND a.name=@name GROUP BY a.description ,x.ar_charged_free, x.ar_sales_free,x.cash_free,i3.itemcode,i3.price,x.ar_sales_free2,x.ar_charged_free2 ", conn)
        cmd.Parameters.AddWithValue("@name", "CASH")
        dr = cmd.ExecuteReader
        While dr.Read
            'Dim cs_quantity As Double = 0.00, archarged As Double = 0.00, arsales As Double = 0.00

            'If IsDBNull(rdr("ar_charged_free2")) Then
            '    archarged = 0
            'Else
            '    archarged = rdr("ar_charged_free2")
            'End If
            'If IsDBNull(rdr("ar_sales_free2")) Then
            '    arsales = 0
            'Else
            '    arsales = rdr("ar_sales_free2")
            'End If
            'cs_quantity = (rdr("cash_free") + archarged + arsales)
            'If cs_quantity > 0 Then
            '    MessageBox.Show(rdr("description") & "/cs_qantty")
            '    dataCs.Rows.Add(rdr("itemcode"), rdr("description"), rdr("price"), cs_quantity)
            'End If
            'If CDbl(rdr("sold")) > 0 Then

            '    dt1.Rows.Add(r0w("DocNum"), "LineNum", rdr("itemcode"), rdr("description"), rdr("sold"), rdr("price"), gr, sales, r0w("CardCode"), r0w("CardName"))
            'End If
            MessageBox.Show(dr("description"))
        End While
        conn.Close()
    End Sub

    Private Sub checkseepass_CheckedChanged(sender As Object, e As EventArgs) Handles checkseepass.CheckedChanged
        If checkseepass.Checked = True Then
            txtpass.Font = New Font("Arial", 12, FontStyle.Bold)
            txtpass.UseSystemPasswordChar = True
        Else
            txtpass.UseSystemPasswordChar = False
            txtpass.Font = New Font("Arial", 18, FontStyle.Bold)
        End If
    End Sub

    Private Sub btndamn_Click(sender As Object, e As EventArgs) Handles btndamn.Click
        Dim frm As New test
        frm.ShowDialog()
    End Sub

    Private Sub Panel3_MouseDown(sender As Object, e As MouseEventArgs) Handles Label5.MouseDown, MyBase.MouseDown, Panel7.MouseDown, lblversions.MouseDown, Label9.MouseDown, Label8.MouseDown, Label6.MouseDown, Label4.MouseDown, Label3.MouseDown, Label10.MouseDown, PictureBox1.MouseDown
        drag = True 'Sets the variable drag to true.
        mousex = Windows.Forms.Cursor.Position.X - Me.Left 'Sets variable mousex
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top 'Sets variable mousey
    End Sub

    Private Sub Panel3_MouseMove(sender As Object, e As MouseEventArgs) Handles Label5.MouseMove, MyBase.MouseMove, Panel7.MouseMove, lblversions.MouseMove, Label9.MouseMove, Label8.MouseMove, Label6.MouseMove, Label4.MouseMove, Label3.MouseMove, Label10.MouseMove, PictureBox1.MouseMove
        'If drag is set to true then move the form accordingly.
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub Panel3_MouseUp(sender As Object, e As MouseEventArgs) Handles Label5.MouseUp, MyBase.MouseUp, Panel7.MouseUp, lblversions.MouseUp, Label9.MouseUp, Label8.MouseUp, Label6.MouseUp, Label4.MouseUp, Label3.MouseUp, Label10.MouseUp, PictureBox1.MouseUp
        drag = False 'Sets drag to false, so the form does not move according to the code in MouseMove
    End Sub

    Private Sub txtusername_Enter(sender As Object, e As EventArgs) Handles txtusername.Enter
        If txtusername.Text = "Username" Then
            txtusername.Text = ""
            txtusername.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txtusername_Leave(sender As Object, e As EventArgs) Handles txtusername.Leave
        If txtusername.Text = "" Then
            txtusername.Text = "Username"
            txtusername.ForeColor = Color.LightGray
        End If
    End Sub

    Private Sub txtpass_Enter(sender As Object, e As EventArgs) Handles txtpass.Enter
        If txtpass.Text = "Password" Then
            txtpass.Text = ""
            txtpass.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txtpass_Leave(sender As Object, e As EventArgs) Handles txtpass.Leave
        If txtpass.Text = "" Then
            txtpass.Text = "Password"
            txtpass.ForeColor = Color.LightGray
        End If
    End Sub

    Public Function getSystemDate() As DateTime
        Try
            connect()
            Dim dt As New DateTime()
            cmd = New SqlCommand("SELECT GETDATE()", conn)
            dr = cmd.ExecuteReader()
            If dr.Read Then
                dt = CDate(dr(0).ToString)
            End If
            disconnect()
            Return dt
        Catch ex As SqlException
            If ex.Number = -2 Then
                MessageBox.Show("Timeout Occurred", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            disconnect()
        End Try
    End Function
End Class
