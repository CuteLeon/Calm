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
        Me.AuthorLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'AuthorLabel
        '
        Me.AuthorLabel.BackColor = System.Drawing.Color.Transparent
        Me.AuthorLabel.Font = New System.Drawing.Font("微软雅黑", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.AuthorLabel.ForeColor = System.Drawing.Color.White
        Me.AuthorLabel.Location = New System.Drawing.Point(192, 74)
        Me.AuthorLabel.Name = "AuthorLabel"
        Me.AuthorLabel.Size = New System.Drawing.Size(307, 92)
        Me.AuthorLabel.TabIndex = 2
        Me.AuthorLabel.Text = "  Leon"
        Me.AuthorLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Calm.My.Resources.UnityResource.HomePage
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(626, 414)
        Me.Controls.Add(Me.AuthorLabel)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "MainForm"
        Me.Text = "Clam · Leon"
        Me.TopMost = True
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents AuthorLabel As Label
End Class
