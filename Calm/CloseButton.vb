Imports System.ComponentModel

Public Class CloseButton
    Private Declare Function GetWindowLong Lib "user32" Alias "GetWindowLongA" (ByVal hwnd As IntPtr, ByVal nIndex As Integer) As Integer
    Private Declare Function SetWindowLong Lib "user32" Alias "SetWindowLongA" (ByVal hwnd As IntPtr, ByVal nIndex As Integer, ByVal dwNewLong As Integer) As Integer

    Private Sub SuspensionForm_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        '防止窗体激活抢占焦点
        SetWindowLong(Me.Handle, -20, GetWindowLong(Me.Handle, -20) Or &H8000000)
    End Sub

    Private Sub CloseButton_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        '防止窗体被关闭
        e.Cancel = True
    End Sub

    Private Sub CloseButton_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '初始化：允许多线程访问前端
        System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False
        DrawImage(Me, My.Resources.UnityResource.Close_0)
    End Sub

    Private Sub CloseButton_MouseEnter(sender As Object, e As EventArgs) Handles Me.MouseEnter
        '鼠标进入，从屏幕边缘进入屏幕
        DrawImage(Me, My.Resources.UnityResource.Close_1)
        Threading.ThreadPool.QueueUserWorkItem(New Threading.WaitCallback(
            Sub()
                RemoveHandler Me.MouseEnter, AddressOf CloseButton_MouseEnter
                RemoveHandler Me.MouseLeave, AddressOf CloseButton_MouseLeave
                Do While Me.Left > My.Computer.Screen.Bounds.Width - Me.Width - 10
                    Me.Left -= 2
                    Threading.Thread.Sleep(5)
                Loop
                Me.Left = My.Computer.Screen.Bounds.Width - Me.Width - 10
                AddHandler Me.MouseEnter, AddressOf CloseButton_MouseEnter
                AddHandler Me.MouseLeave, AddressOf CloseButton_MouseLeave
            End Sub))
    End Sub

    Private Sub CloseButton_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        DrawImage(Me, My.Resources.UnityResource.Close_2)
    End Sub

    Private Sub CloseButton_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
        DrawImage(Me, My.Resources.UnityResource.Close_1)
    End Sub

    Private Sub CloseButton_MouseLeave(sender As Object, e As EventArgs) Handles Me.MouseLeave
        '鼠标离开，从屏幕隐藏到屏幕边缘
        DrawImage(Me, My.Resources.UnityResource.Close_0)
        Threading.ThreadPool.QueueUserWorkItem(New Threading.WaitCallback(
            Sub()
                RemoveHandler Me.MouseEnter, AddressOf CloseButton_MouseEnter
                RemoveHandler Me.MouseLeave, AddressOf CloseButton_MouseLeave
                Do While Me.Left < My.Computer.Screen.Bounds.Width
                    Me.Left += 2
                    Threading.Thread.Sleep(5)
                Loop
                Me.Left = My.Computer.Screen.Bounds.Width - 2
                AddHandler Me.MouseEnter, AddressOf CloseButton_MouseEnter
                AddHandler Me.MouseLeave, AddressOf CloseButton_MouseLeave
            End Sub))
    End Sub

    Private Sub CloseButton_Click(sender As Object, e As EventArgs) Handles Me.Click
        If MainForm.CalmPlaying Then
            '关闭媒体播放模式
            MainForm.StopCalm()
        Else
            '关闭应用程序
            CloseApplication()
        End If
        GC.Collect()
    End Sub

    Public Sub CloseApplication()
        If New TipsForm().ShowDialog(Me) = MsgBoxResult.Ok Then
            MainForm.VLCPlayer.Stop()
            Application.Exit()
        End If
    End Sub

    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            On Error Resume Next
            If Not DesignMode Then
                Dim cp As CreateParams = MyBase.CreateParams
                cp.ExStyle = cp.ExStyle Or WS_EX_LAYERED
                Return cp
            Else
                Return MyBase.CreateParams
            End If
        End Get
    End Property

End Class