Public Class TipsForm

    Private Sub TipsForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        TitleLabel.Parent = BGILabel
        TextLabel.Parent = BGILabel
        OKButton.Parent = BGILabel
        CancelTipButton.Parent = BGILabel
        CloseTipsButton.Parent = BGILabel
    End Sub

#Region "按钮动态效果"

    Public Sub Button_MouseDown(sender As Label, e As MouseEventArgs) Handles OKButton.MouseDown, CancelTipButton.MouseDown, CloseTipsButton.MouseDown
        sender.Image = My.Resources.UnityResource.ResourceManager.GetObject(sender.Tag & "_2")
    End Sub

    Public Sub Button_MouseEnter(sender As Label, e As EventArgs) Handles OKButton.MouseEnter, CancelTipButton.MouseEnter, CloseTipsButton.MouseEnter
        sender.Image = My.Resources.UnityResource.ResourceManager.GetObject(sender.Tag & "_1")
    End Sub

    Public Sub Button_MouseLeave(sender As Label, e As EventArgs) Handles OKButton.MouseLeave, CancelTipButton.MouseLeave, CloseTipsButton.MouseLeave
        sender.Image = My.Resources.UnityResource.ResourceManager.GetObject(sender.Tag & "_0")
    End Sub

    Public Sub Button_MouseUp(sender As Label, e As MouseEventArgs) Handles OKButton.MouseUp, CancelTipButton.MouseUp, CloseTipsButton.MouseUp
        sender.Image = My.Resources.UnityResource.ResourceManager.GetObject(sender.Tag & "_1")
    End Sub

#End Region

    Private Sub CloseTipsButton_Click(sender As Object, e As EventArgs) Handles CloseTipsButton.Click
        Me.DialogResult = DialogResult.Abort
    End Sub

    Private Sub CancelButton_Click(sender As Object, e As EventArgs) Handles CancelTipButton.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub OKButton_Click(sender As Object, e As EventArgs) Handles OKButton.Click
        Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub Button_MouseDown(sender As Object, e As MouseEventArgs) Handles OKButton.MouseDown, CloseTipsButton.MouseDown, CancelTipButton.MouseDown

    End Sub

    Private Sub Button_MouseEnter(sender As Object, e As EventArgs) Handles OKButton.MouseEnter, CloseTipsButton.MouseEnter, CancelTipButton.MouseEnter

    End Sub

    Private Sub Button_MouseLeave(sender As Object, e As EventArgs) Handles OKButton.MouseLeave, CloseTipsButton.MouseLeave, CancelTipButton.MouseLeave

    End Sub

    Private Sub Button_MouseUp(sender As Object, e As MouseEventArgs) Handles OKButton.MouseUp, CloseTipsButton.MouseUp, CancelTipButton.MouseUp

    End Sub
End Class