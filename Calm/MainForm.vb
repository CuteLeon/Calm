Imports System.ComponentModel
Imports System.IO
Imports Vlc.DotNet
Imports Vlc.DotNet.Core
Imports Vlc.DotNet.Forms

Public Class MainForm
    '播放音频相关
    Private Declare Function GetShortPathName Lib "kernel32.dll" Alias "GetShortPathNameA" (ByVal lpszLongPath As String, ByVal shortFile As String, ByVal cchBuffer As Integer) As Integer
    Private Declare Function mciSendString Lib "winmm.dll" Alias "mciSendStringA" (ByVal lpstrCommand As String, ByVal lpstrRetumString As String, ByVal uReturnLength As Integer, ByVal hwndCallback As Integer) As Integer
    ''' <summary>
    ''' 标签间边距
    ''' </summary>
    Dim PaddingSize As Integer = 10
    ''' <summary>
    ''' 首页列表行列规模
    ''' </summary>
    Dim TabelSize As Size = New Size(5, 6)
    ''' <summary>
    ''' 放置标签的区域
    ''' </summary>
    Dim TabelRectangle As Rectangle
    ''' <summary>
    ''' VLC 视频播放器
    ''' </summary>
    Public VLCVideoPlayer As VlcControl = New VlcControl
    ''' <summary>
    ''' VLC 音乐播放器
    ''' </summary>
    Public VLCMusicPlayer As VlcControl = New VlcControl
    ''' <summary>
    ''' 正在播放媒体
    ''' </summary>
    Public CalmPlaying As Boolean

#Region "窗体事件"

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetStyle(ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.ResizeRedraw Or ControlStyles.SupportsTransparentBackColor, True)
        CheckForIllegalCrossThreadCalls = False
        UpdateStyles()
        Me.Icon = My.Resources.UnityResource.Calm
        Me.Size = My.Computer.Screen.Bounds.Size
        Dim Zoom As Double = Math.Min((Me.Width * 0.9 - PaddingSize * (TabelSize.Width - 1)) / TabelSize.Width / 640,
                    (Me.Height - 134) * 0.9 - PaddingSize * (TabelSize.Height - 1) / TabelSize.Height / 220)
        AuthorLabel.Size = New Size(640 * Zoom, 220 * Zoom)
        TabelRectangle.Size = New Size(TabelSize.Width * (AuthorLabel.Width + PaddingSize) - PaddingSize, TabelSize.Height * (AuthorLabel.Height + PaddingSize) - PaddingSize)
        TabelRectangle.Location = New Point((Me.Width - TabelRectangle.Width) / 2, 74 + (Me.Height - 134 - TabelRectangle.Height) / 2)
        AuthorLabel.Image = New Bitmap(My.Resources.UnityResource.AuthorLabel, AuthorLabel.Size)

        VLCVideoPlayer.VlcLibDirectory = New DirectoryInfo(Application.StartupPath)
        VLCVideoPlayer.EndInit()
        VLCMusicPlayer.VlcLibDirectory = New DirectoryInfo(Application.StartupPath)
        VLCMusicPlayer.EndInit()
    End Sub

    Private Sub MainForm_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Me.TopMost = True
    End Sub

    Private Sub MainForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        CloseButton.Show(Me)
        CloseButton.Size = New Size(64, 64)
        CloseButton.Location = New Point(Me.Width - CloseButton.Width - 10, 10)

        LoadResource()

        AddHandler VLCMusicPlayer.EndReached, AddressOf EndReached
        With VLCVideoPlayer
            .Location = New Point(0, -My.Computer.Screen.Bounds.Height)
            .Size = My.Computer.Screen.Bounds.Size
            .Video.AspectRatio = String.Format("{0}:{1}", My.Computer.Screen.Bounds.Width, My.Computer.Screen.Bounds.Height)
            .Hide()
            AddHandler .EndReached, AddressOf EndReached
        End With
        Me.Controls.Add(VLCVideoPlayer)
    End Sub

    Private Sub MainForm_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(50, Color.White)), New Rectangle(TabelRectangle.Left - 20, TabelRectangle.Top - 20, TabelRectangle.Width + 40, TabelRectangle.Height + 40))
        e.Graphics.DrawImage(My.Resources.UnityResource.Favicon, 15, 10, 298, 64)
    End Sub

    Private Sub MainForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        e.Cancel = True
        CloseButton.CloseApplication()
    End Sub

#End Region

#Region "功能函数"

    Private Sub LoadResource()
        Dim RootDirectory As String = Application.StartupPath & "\Calm"
        Dim CalmDirectory As String() = Directory.GetDirectories(RootDirectory)
        Dim X As Integer = TabelRectangle.Left, Y As Integer = TabelRectangle.Top
        For Index As Integer = 0 To CalmDirectory.Count - 1
            Dim CalmLabel As Label = New Label
            With CalmLabel
                .Tag = (CalmDirectory(Index))
                .BackColor = AuthorLabel.BackColor
                .Font = AuthorLabel.Font
                .ForeColor = AuthorLabel.ForeColor
                .Size = AuthorLabel.Size
                .Location = New Point(X, Y)
                .TextAlign = AuthorLabel.TextAlign
                .ImageAlign = AuthorLabel.ImageAlign
                .Text = New DirectoryInfo(CalmDirectory(Index)).Name
                .Image = New Bitmap(Bitmap.FromFile(CalmDirectory(Index) & "\Calm.jpg"), .Size)
                AddHandler .Click, AddressOf Label_Click
                AddHandler .MouseEnter, AddressOf Label_MouseEnter
                AddHandler .MouseLeave, AddressOf Label_MouseLeave
                AddHandler .MouseDown, AddressOf Label_MouseDown
                .Show()
            End With
            Me.Controls.Add(CalmLabel)
            If (Index Mod TabelSize.Width = 4) Then
                X = TabelRectangle.Left
                Y += AuthorLabel.Height + PaddingSize
            Else
                X += AuthorLabel.Width + PaddingSize
            End If
        Next
        AuthorLabel.Location = New Point(X, Y)
        GC.Collect()
    End Sub

    'Private Sub PlayMusic(ByVal MusicFile As String)
    '    Dim ShortPath As String = Space(256)
    '    Dim PathLength As Integer
    '    PathLength = GetShortPathName(MusicFile, ShortPath, 256) - 2
    '    ShortPath = Strings.Left(ShortPath, PathLength)
    '    Dim Command As String = "Open """ & ShortPath & """  alias LeonMusic"
    '    mciSendString(Command, Nothing, 0&, IntPtr.Zero)
    '    mciSendString("Play LeonMusic Repeat", Nothing, 0, IntPtr.Zero)
    'End Sub

    'Private Sub StopMusic()
    '    mciSendString("Close LeonMusic", Nothing, 0, IntPtr.Zero)
    'End Sub

    Private Sub PlayCalm(ByVal CalmDirectory As String)
        CalmPlaying = True
        VLCMusicPlayer.Tag = New FileInfo(CalmDirectory & "\Calm.mp3")
        VLCMusicPlayer.Play(VLCMusicPlayer.Tag)
        VLCVideoPlayer.Tag = New FileInfo(CalmDirectory & "\Calm.mp4")
        With VLCVideoPlayer
            .Top = -My.Computer.Screen.Bounds.Height
            .Show()
            .BringToFront()
            .Play(VLCVideoPlayer.Tag)
        End With
        Threading.ThreadPool.QueueUserWorkItem(New Threading.WaitCallback(
            Sub()
                Do While VLCVideoPlayer.Top < 0
                    VLCVideoPlayer.Top += 15
                    Threading.Thread.Sleep(5)
                Loop
                VLCVideoPlayer.Top = 0
            End Sub))
    End Sub

    Public Sub StopCalm()
        CalmPlaying = False
        VLCMusicPlayer.Stop()
        Threading.ThreadPool.QueueUserWorkItem(New Threading.WaitCallback(
            Sub()
                Do While VLCVideoPlayer.Top < My.Computer.Screen.Bounds.Height
                    VLCVideoPlayer.Top += 15
                    Threading.Thread.Sleep(5)
                Loop
                VLCVideoPlayer.Stop()
                VLCVideoPlayer.Hide()
            End Sub))
    End Sub

    Private Sub EndReached(sender As VlcControl, e As VlcMediaPlayerEndReachedEventArgs)
        Threading.ThreadPool.QueueUserWorkItem(New Threading.WaitCallback(
            Sub()
                VLCVideoPlayer.Play(sender.Tag)
            End Sub))
    End Sub

#End Region

#Region "控件事件"

    Private Sub AuthorLabel_Click(sender As Object, e As EventArgs) Handles AuthorLabel.Click
        AuthorForm.SwitchVisible(AuthorForm.Visible)
    End Sub

#End Region

#Region "标签事件"

    Private Sub Label_Click(sender As Label, e As EventArgs)
        PlayCalm(sender.Tag)
        GC.Collect()
    End Sub

    Private Sub Label_MouseEnter(sender As Label, e As EventArgs)
        sender.BorderStyle = BorderStyle.FixedSingle
        Me.BackgroundImage = Bitmap.FromFile(sender.Tag & "\Calm.jpg")
        GC.Collect()
    End Sub

    Private Sub Label_MouseDown(sender As Label, e As MouseEventArgs) Handles AuthorLabel.MouseDown
        sender.Location = New Point(sender.Location.X + 2, sender.Location.Y + 2)
        Me.Refresh()
        sender.Location = New Point(sender.Location.X - 2, sender.Location.Y - 2)
    End Sub

    Private Sub Label_MouseLeave(sender As Label, e As EventArgs) Handles AuthorLabel.MouseLeave
        sender.BorderStyle = BorderStyle.None
    End Sub

#End Region

End Class
