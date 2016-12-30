<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.CloseButton = New System.Windows.Forms.Label()
        Me.TitleLabel = New System.Windows.Forms.Label()
        Me.AuthorLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'CloseButton
        '
        Me.CloseButton.BackColor = System.Drawing.Color.Transparent
        Me.CloseButton.Image = Global.Calm.My.Resources.UnityResource.Close_0
        Me.CloseButton.Location = New System.Drawing.Point(528, 10)
        Me.CloseButton.Name = "CloseButton"
        Me.CloseButton.Size = New System.Drawing.Size(64, 64)
        Me.CloseButton.TabIndex = 0
        Me.CloseButton.Tag = "Close"
        '
        'TitleLabel
        '
        Me.TitleLabel.BackColor = System.Drawing.Color.Transparent
        Me.TitleLabel.Font = New System.Drawing.Font("微软雅黑", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TitleLabel.ForeColor = System.Drawing.Color.White
        Me.TitleLabel.Image = Global.Calm.My.Resources.UnityResource.Favicon
        Me.TitleLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.TitleLabel.Location = New System.Drawing.Point(20, 10)
        Me.TitleLabel.Name = "TitleLabel"
        Me.TitleLabel.Size = New System.Drawing.Size(298, 64)
        Me.TitleLabel.TabIndex = 1
        Me.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'AuthorLabel
        '
        Me.AuthorLabel.BackColor = System.Drawing.Color.Transparent
        Me.AuthorLabel.Font = New System.Drawing.Font("微软雅黑", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.AuthorLabel.ForeColor = System.Drawing.Color.White
        Me.AuthorLabel.Location = New System.Drawing.Point(68, 151)
        Me.AuthorLabel.Name = "AuthorLabel"
        Me.AuthorLabel.Size = New System.Drawing.Size(307, 92)
        Me.AuthorLabel.TabIndex = 2
        Me.AuthorLabel.Text = "Leon"
        Me.AuthorLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Calm.My.Resources.UnityResource.HomePage
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(601, 364)
        Me.Controls.Add(Me.AuthorLabel)
        Me.Controls.Add(Me.TitleLabel)
        Me.Controls.Add(Me.CloseButton)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "MainForm"
        Me.Text = "Clam · Leon"
        Me.TopMost = True
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents CloseButton As Label
    Friend WithEvents TitleLabel As Label
    Public WithEvents AuthorLabel As Label
End Class
