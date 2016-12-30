Imports System.IO

Public Class MainForm
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

#Region "窗体事件"

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetStyle(ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.ResizeRedraw Or ControlStyles.SupportsTransparentBackColor, True)

        Me.Icon = My.Resources.UnityResource.Calm
        CloseButton.Location = New Point(Me.Width - CloseButton.Width - 10, 10)
        TitleLabel.Location = New Point(15, 10)
        Dim Zoom As Double = Math.Min((Me.Width * 0.9 - PaddingSize * (TabelSize.Width - 1)) / TabelSize.Width / 640,
                    (Me.Height - TitleLabel.Bottom - 60) * 0.9 - PaddingSize * (TabelSize.Height - 1) / TabelSize.Height / 220)
        AuthorLabel.Size = New Size(640 * Zoom, 220 * Zoom)
        TabelRectangle.Size = New Size(TabelSize.Width * (AuthorLabel.Width + PaddingSize) - PaddingSize, TabelSize.Height * (AuthorLabel.Height + PaddingSize) - PaddingSize)
        TabelRectangle.Location = New Point((Me.Width - TabelRectangle.Width) / 2, TitleLabel.Bottom + (Me.Height - TitleLabel.Bottom - 60 - TabelRectangle.Height) / 2)
        AuthorLabel.Image = New Bitmap(My.Resources.UnityResource.AuthorLabel, AuthorLabel.Size)

        GC.Collect()
    End Sub

    Private Sub MainForm_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Me.TopMost = True
    End Sub

    Private Sub MainForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        LoadResource()
    End Sub

#End Region

#Region "按钮动态效果"

    Private Sub Button_MouseDown(sender As Label, e As MouseEventArgs) Handles CloseButton.MouseDown
        sender.Image = My.Resources.UnityResource.ResourceManager.GetObject(sender.Tag & "_2")
    End Sub

    Private Sub Button_MouseEnter(sender As Label, e As EventArgs) Handles CloseButton.MouseEnter
        sender.Image = My.Resources.UnityResource.ResourceManager.GetObject(sender.Tag & "_1")
    End Sub

    Private Sub Button_MouseLeave(sender As Label, e As EventArgs) Handles CloseButton.MouseLeave
        sender.Image = My.Resources.UnityResource.ResourceManager.GetObject(sender.Tag & "_0")
    End Sub

    Private Sub Button_MouseUp(sender As Label, e As MouseEventArgs) Handles CloseButton.MouseUp
        sender.Image = My.Resources.UnityResource.ResourceManager.GetObject(sender.Tag & "_1")
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
                AddHandler .MouseEnter, AddressOf Label_MouseEnter
                AddHandler .MouseDown, AddressOf Label_MouseDown
                AddHandler .MouseLeave, AddressOf Label_MouseLeave
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
    End Sub

#End Region

#Region "控件事件"

    Private Sub TitleLabel_MouseEnter(sender As Object, e As EventArgs) Handles TitleLabel.MouseEnter
        Me.BackgroundImage = My.Resources.UnityResource.HomePage
    End Sub

    Private Sub CloseButton_Click(sender As Object, e As EventArgs) Handles CloseButton.Click
        Application.Exit()
    End Sub

    Private Sub AuthorLabel_Click(sender As Object, e As EventArgs) Handles AuthorLabel.Click
        MsgBox("TODO:此处提倡装逼...")
    End Sub

#End Region

#Region "标签事件"

    Private Sub Label_MouseEnter(sender As Label, e As EventArgs) Handles AuthorLabel.MouseEnter
        sender.BorderStyle = BorderStyle.FixedSingle
        Me.BackgroundImage = New Bitmap(sender.Image)
        GC.Collect()
    End Sub

    Private Sub Label_MouseDown(sender As Label, e As MouseEventArgs) Handles AuthorLabel.MouseDown
        sender.Location = New Point(sender.Location.X + 2, sender.Location.Y + 2)
        Me.Refresh()
        '
        sender.Location = New Point(sender.Location.X - 2, sender.Location.Y - 2)
    End Sub

    Private Sub Label_MouseLeave(sender As Label, e As EventArgs) Handles AuthorLabel.MouseLeave
        sender.BorderStyle = BorderStyle.None
    End Sub

#End Region

End Class
