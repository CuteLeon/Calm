Imports Microsoft.VisualBasic.ApplicationServices

Namespace My
    ' 以下事件可用于 MyApplication: 
    ' Startup: 应用程序启动时在创建启动窗体之前引发。
    ' Shutdown: 在关闭所有应用程序窗体后引发。 如果应用程序异常终止，则不会引发此事件。
    ' UnhandledException: 在应用程序遇到未经处理的异常时引发。
    ' StartupNextInstance: 在启动单实例应用程序且应用程序已处于活动状态时引发。
    ' NetworkAvailabilityChanged: 在连接或断开网络连接时引发。
    Partial Friend Class MyApplication
        Private Sub MyApplication_Startup(sender As Object, e As StartupEventArgs) Handles Me.Startup
            Dim HasFileInNeed As Boolean
            Dim DLLNames As String() = New String() {"libvlc.dll", "libvlccore.dll", "Vlc.DotNet.Core.dll", "Vlc.DotNet.Core.Interops.dll", "Vlc.DotNet.Forms.dll"}
            For Each DLLName In DLLNames
                If Not IO.File.Exists(System.Environment.CurrentDirectory & "\" & DLLName) Then
                    HasFileInNeed = True
                    If MsgBox(String.Format("缺少动态链接库：{0}{1}需要打开下载页吗？{2}https://github.com/CuteLeon/Calm/blob/master/Calm/{3}", DLLName, vbCrLf, vbCrLf, DLLName), MsgBoxStyle.Question Or MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                        Process.Start("https://github.com/CuteLeon/Calm/blob/master/Calm/" & DLLName)
                    End If
                End If
            Next
            If Not IO.Directory.Exists(Environment.CurrentDirectory & "\Calm") Then
                HasFileInNeed = True
                If MsgBox(String.Format("顺便...你这还缺少 Calm 媒体资源文件夹...{0}需要打开下载页吗？{1}https://github.com/CuteLeon/Calm/tree/master/Calm/Calm", vbCrLf, vbCrLf), MsgBoxStyle.Question Or MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    Process.Start("https://github.com/CuteLeon/Calm/tree/master/Calm/Calm")
                End If
            End If
            If Not IO.Directory.Exists(Environment.CurrentDirectory & "\plugins") Then
                HasFileInNeed = True
                If MsgBox(String.Format("顺便...你这还缺少 VLC 组件的插件文件夹 plugins...{0}需要打开下载页吗？{1}https://github.com/CuteLeon/Calm/tree/master/Calm/plugins", vbCrLf, vbCrLf), MsgBoxStyle.Question Or MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    Process.Start("https://github.com/CuteLeon/Calm/tree/master/Calm/plugins")
                End If
            End If
            If HasFileInNeed Then
                End
            End If
        End Sub
    End Class
End Namespace
