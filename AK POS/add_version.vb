Public Class add_version
    Dim uic As New ui_class
    Dim fc As New file_config
    Dim versionRoot As String = fc.version_root
    Dim folderRoot As String = fc.folder_root
    Dim versionName As String = fc.version_name
    Dim versionExtensionName As String = fc.version_extensionName
    Dim descriptionExtensionName As String = fc.descrition_extensionName
    Private Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub

    Private Sub Panel2_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel2.MouseDown, MyBase.MouseDown, Label4.MouseDown, Label1.MouseDown
        uic.mouse_down(Me)
    End Sub

    Private Sub Panel2_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel2.MouseMove, MyBase.MouseMove, Label4.MouseMove, Label1.MouseMove
        uic.mouse_move(Me)
    End Sub

    Private Sub Panel2_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel2.MouseUp, MyBase.MouseUp, Label4.MouseUp, Label1.MouseUp
        uic.mouse_up()
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        Dim open As OpenFileDialog
        open = New OpenFileDialog
        open.Title = "Save As Application File"
        open.Filter = "Application File (*.exe) | *.exe"
        If open.ShowDialog = Windows.Forms.DialogResult.OK Then
            'Dim path As String = IO.Path.GetDirectoryName(open.FileName) & open.FileName
            Dim path As String = IO.Path.Combine(IO.Path.GetDirectoryName(open.FileName), open.FileName)
            txtupload.Text = path
        End If
    End Sub
    Public Sub insertFile()
        Dim path As String = versionRoot & folderRoot & versionName
        If Not System.IO.Directory.Exists(versionRoot & folderRoot) Then
            System.IO.Directory.CreateDirectory(versionRoot & folderRoot)
        End If
        My.Computer.FileSystem.CopyFile(txtupload.Text, path & txtversion.Text & versionExtensionName, True)
        Dim pathDescription As String = path & txtversion.Text & descriptionExtensionName
        Dim fs As IO.FileStream = IO.File.Create(pathDescription)
        Dim info As Byte() = New System.Text.UTF8Encoding(True).GetBytes(txtdescription.Text)
        fs.Write(info, 0, info.Length)
        fs.Close()
        MessageBox.Show("Version Created", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        If String.IsNullOrEmpty(txtversion.Text) Then
            MessageBox.Show("Version field is required", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf IO.File.Exists(versionRoot & folderRoot & versionName & txtversion.Text & versionExtensionName) Then
            MessageBox.Show("'" & txtversion.Text & "' version is already exist", "AtlantIc Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf String.IsNullOrEmpty(txtdescription.Text) Then
            MessageBox.Show("Description field is required", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf String.IsNullOrEmpty(txtupload.Text) Then
            MessageBox.Show("Upload File field is required", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            insertFile()
        End If
    End Sub

    Private Sub txtupload_MouseEnter(sender As Object, e As EventArgs) Handles txtupload.MouseEnter
        ToolTip1.SetToolTip(txtupload, txtupload.Text)
    End Sub

    Private Sub txtversion_MouseEnter(sender As Object, e As EventArgs) Handles txtversion.MouseEnter
        ToolTip1.SetToolTip(txtversion, txtversion.Text)
    End Sub

    Private Sub txtdescription_MouseEnter(sender As Object, e As EventArgs) Handles txtdescription.MouseEnter
        ToolTip1.SetToolTip(txtdescription, txtdescription.Text)
    End Sub
End Class