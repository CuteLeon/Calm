<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TipsForm
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
        Me.BGILabel = New System.Windows.Forms.Label()
        Me.TitleLabel = New System.Windows.Forms.Label()
        Me.OKButton = New System.Windows.Forms.Label()
        Me.CancelTipButton = New System.Windows.Forms.Label()
        Me.CloseTipsButton = New System.Windows.Forms.Label()
        Me.TextLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'BGILabel
        '
        Me.BGILabel.BackColor = System.Drawing.Color.Transparent
        Me.BGILabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BGILabel.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.BGILabel.ForeColor = System.Drawing.Color.Transparent
        Me.BGILabel.Image = Global.Calm.My.Resources.UnityResource.TipsBGI
        Me.BGILabel.Location = New System.Drawing.Point(0, 0)
        Me.BGILabel.Name = "BGILabel"
        Me.BGILabel.Size = New System.Drawing.Size(500, 260)
        Me.BGILabel.TabIndex = 0
        '
        'TitleLabel
        '
        Me.TitleLabel.BackColor = System.Drawing.Color.Transparent
        Me.TitleLabel.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TitleLabel.ForeColor = System.Drawing.Color.Transparent
        Me.TitleLabel.Image = Global.Calm.My.Resources.UnityResource.FaviconSmall
        Me.TitleLabel.Location = New System.Drawing.Point(8, 8)
        Me.TitleLabel.Name = "TitleLabel"
        Me.TitleLabel.Size = New System.Drawing.Size(150, 32)
        Me.TitleLabel.TabIndex = 1
        '
        'OKButton
        '
        Me.OKButton.BackColor = System.Drawing.Color.Transparent
        Me.OKButton.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.OKButton.ForeColor = System.Drawing.Color.Transparent
        Me.OKButton.Image = Global.Calm.My.Resources.UnityResource.OK_0
        Me.OKButton.Location = New System.Drawing.Point(286, 192)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.Size = New System.Drawing.Size(106, 44)
        Me.OKButton.TabIndex = 2
        Me.OKButton.Tag = "OK"
        '
        'CancelTipButton
        '
        Me.CancelTipButton.BackColor = System.Drawing.Color.Transparent
        Me.CancelTipButton.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.CancelTipButton.ForeColor = System.Drawing.Color.Transparent
        Me.CancelTipButton.Image = Global.Calm.My.Resources.UnityResource.Cancel_0
        Me.CancelTipButton.Location = New System.Drawing.Point(108, 192)
        Me.CancelTipButton.Name = "CancelTipButton"
        Me.CancelTipButton.Size = New System.Drawing.Size(106, 44)
        Me.CancelTipButton.TabIndex = 3
        Me.CancelTipButton.Tag = "Cancel"
        '
        'CloseTipsButton
        '
        Me.CloseTipsButton.BackColor = System.Drawing.Color.Transparent
        Me.CloseTipsButton.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.CloseTipsButton.ForeColor = System.Drawing.Color.Transparent
        Me.CloseTipsButton.Image = Global.Calm.My.Resources.UnityResource.CloseTips_0
        Me.CloseTipsButton.Location = New System.Drawing.Point(460, 0)
        Me.CloseTipsButton.Name = "CloseTipsButton"
        Me.CloseTipsButton.Size = New System.Drawing.Size(40, 40)
        Me.CloseTipsButton.TabIndex = 4
        Me.CloseTipsButton.Tag = "CloseTips"
        '
        'TextLabel
        '
        Me.TextLabel.BackColor = System.Drawing.Color.Transparent
        Me.TextLabel.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TextLabel.ForeColor = System.Drawing.Color.Transparent
        Me.TextLabel.Image = Global.Calm.My.Resources.UnityResource.TextBitmap
        Me.TextLabel.Location = New System.Drawing.Point(62, 105)
        Me.TextLabel.Name = "TextLabel"
        Me.TextLabel.Size = New System.Drawing.Size(375, 49)
        Me.TextLabel.TabIndex = 5
        Me.TextLabel.Tag = ""
        '
        'TipsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(500, 260)
        Me.Controls.Add(Me.TextLabel)
        Me.Controls.Add(Me.CloseTipsButton)
        Me.Controls.Add(Me.CancelTipButton)
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(Me.TitleLabel)
        Me.Controls.Add(Me.BGILabel)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "TipsForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TipsForm"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BGILabel As Label
    Friend WithEvents TitleLabel As Label
    Friend WithEvents OKButton As Label
    Friend WithEvents CancelTipButton As Label
    Friend WithEvents CloseTipsButton As Label
    Friend WithEvents TextLabel As Label
End Class
