Imports System.IO

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim filePath As String = ""

        Using GamePathf As New OpenFileDialog
            GamePathf.Filter = "All files (*.*)|*.*"
            GamePathf.Title = "請選擇檔案"
            GamePathf.ShowDialog()
            filePath = GamePathf.FileName
        End Using

        If File.Exists(filePath) Then
            TextBox1.Text = filePath
            TextBox2.Text = File.GetLastAccessTime(filePath)
            TextBox3.Text = File.GetLastWriteTime(filePath)
            TextBox4.Text = File.GetCreationTime(filePath)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim filePath As String = TextBox1.Text

        If File.Exists(filePath) Then
            Try
                File.SetLastAccessTime(filePath, DateTime.Parse(TextBox2.Text))
                File.SetLastWriteTime(filePath, DateTime.Parse(TextBox3.Text))
                File.SetCreationTime(filePath, DateTime.Parse(TextBox4.Text))
            Catch ex As Exception
                MsgBox("格式錯誤")
            End Try
            MsgBox("修改完成")
        End If
    End Sub
End Class
