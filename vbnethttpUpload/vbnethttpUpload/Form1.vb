Imports System.Net
Imports System.Net.Mime
Imports InetCtlsObjects

Public Class Form1
    Dim filename As String
    Private Sub BtnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBrowse.Click
        Dim ofd As New OpenFileDialog
        ofd.Filter = "text files(*.txt)|*.txt|all files(*.*)|*.*"
        ofd.InitialDirectory = Application.StartupPath
        If DialogResult.OK = ofd.ShowDialog Then
            TextBox_file.Text = ofd.FileName
            filename = ofd.SafeFileName()
            MsgBox(filename)
        End If
    End Sub

    Private Sub btnUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpload.Click
        If TextBox_file.Text.Trim = "" Then
            MsgBox("Please Enter Or Choose File")
            TextBox_file.Focus()
        Else
            '' My.Computer.Network.UploadFile(TextBox_file.Text, "http://localhost/Default.aspx")
            '' My.Computer.Network.UploadFile(TextBox_file.Text, "https://fishc.com.cn/forum-84-1.html", "kennycai2018", "Kenny197512")
            ''My.Computer.Network.UploadFile(TextBox_file.Text, "https://www.dropbox.com/home/index.html", "kenny887@gmail.com", "kenny1975")

            'Dim client As New WebClient()
            'client.Headers.Add("Connect_Type", "application/x-www-form-urlencoded")
            ''client.Credentials = New NetworkCredential("kennycai2018", "Kenny197512")

            ''client.UploadFile("https://fishc.com.cn/forum-84-1.html", TextBox_file.Text)
            ''client.UploadFile("https://fishc.com.cn/home.php", TextBox_file.Text)
            ''client.Credentials = New NetworkCredential("kenny887@gmail.com", "kenny1975")
            ''client.UploadFile("https://www.dropbox.com/home/", TextBox_file.Text)
            'client.Credentials = New NetworkCredential("kenny887@gmail.com", "kenny1975")
            ''client.UploadFile("https://www.youtube.com/channel/UCGFF66nQkLHrTXkXS6DN7yw/videos?view=0&sort=dd&shelf_id=0", TextBox_file.Text)
            ''client.UploadFile("https://www.youtube.com/upload?redirect_to_creator=true&fr=2", TextBox_file.Text)
            ''client.UploadFile("https://drive.google.com/drive/u/0/folders/18y_2OMe84f_5PaWJMfHBn5Rsp13f1YZa", TextBox_file.Text)
            'client.UploadFile("https://drive.google.com/drive/u/0/folders/1rDVq6LscFlSFZx4JDlOvq1AVr6PSf0BX", "POST", TextBox_file.Text)

            'client.Dispose()
            Dim inet1 As InetCtlsObjects.Inet = New InetCtlsObjects.Inet()
            'inet1.URL = "https://drive.google.com/drive/u/0/folders/1rDVq6LscFlSFZx4JDlOvq1AVr6PSf0BX"
            'inet1.UserName = "kenny887@gmail.com"
            'inet1.Password = "kenny1975"

            'TextBox1.Text = inet1.OpenURL("https://drive.google.com/drive/u/0/folders/1nuQZ3NkIsBACaBoxExea_v_p9aUqlmQB")
            'inet1.Execute("https://drive.google.com/drive/u/0/folders/1nuQZ3NkIsBACaBoxExea_v_p9aUqlmQB", "POST", TextBox_file.Text)
            TextBox1.Text = inet1.OpenURL("http://localhost/Default.aspx")
            inet1.Execute("http://localhost/up/", "PUT", TextBox_file.Text)
            'My.Computer.Network.UploadFile(TextBox_file.Text, "http://localhost/Default.aspx")
        End If

    End Sub
End Class
