Imports System.Threading.Tasks

Public Class version
    Dim cc As New connection_class
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

    Private Sub version_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub version_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadVersion()
    End Sub

    Public Sub loadVersion()
        cmbversion.Items.Clear()
        Dim di As New IO.DirectoryInfo(versionRoot & folderRoot)
        Dim aryFi As IO.FileInfo() = di.GetFiles("*" & versionExtensionName)
        For Each fi As IO.FileInfo In aryFi
            Dim fileName As String = fi.Name.Replace(versionName, "")
            fileName = fileName.Replace(versionExtensionName, "")
            cmbversion.Items.Add(fileName)
        Next
    End Sub

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown
        uic.mouse_down(Me)
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove
        uic.mouse_move(Me)
    End Sub

    Private Sub Panel1_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel1.MouseUp
        uic.mouse_up()
    End Sub

    Private Sub cmbversion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbversion.SelectedIndexChanged
        Dim path As String = versionRoot & folderRoot & versionName & cmbversion.Text & descriptionExtensionName
        If IO.File.Exists(path) Then
            Dim dateDeployed As New DateTime()
            dateDeployed = System.IO.File.GetLastWriteTime(path)
            txtdescription.Text = My.Computer.FileSystem.ReadAllText(path)
            lbldatedeployed.Text = dateDeployed.ToString("MM/dd/yyyy") & Environment.NewLine & dateDeployed.ToString("hh:mm tt")
        Else
            MessageBox.Show("Description for this version is not exist", "Atlantic Bakery", MessageBoxButtons.OK, MessageBoxIcon.Error)
            lbldatedeployed.Text = "DATE_DEPLOYED"
            txtdescription.Text = ""
        End If
    End Sub

    Private Sub txtdescription_MouseEnter(sender As Object, e As EventArgs) Handles txtdescription.MouseEnter
        ToolTip1.SetToolTip(txtdescription, txtdescription.Text)
    End Sub

    Private Sub btnupdate_Click(sender As Object, e As EventArgs) Handles btnupdate.Click
        Dim fromPath As String = versionRoot & folderRoot & versionName & cmbversion.Text & descriptionExtensionName
        Dim destionationPath As String = IO.Path.GetFullPath(Application.ExecutablePath)
        Application.Exit()
        'My.Computer.FileSystem.CopyFile(fromPath, destionationPath, True)
        'End
        MessageBox.Show("qw")
    End Sub
End Class