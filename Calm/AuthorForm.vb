Imports System.ComponentModel

Public Class AuthorForm
    Private Sub AuthorForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.UnityResource.Calm
        Me.Location = New Point(-Me.Width, (My.Computer.Screen.Bounds.Height - Me.Height) / 2)
        DrawImage(Me, My.Resources.UnityResource.Author)
    End Sub

    Private Sub AuthorForm_Click(sender As Object, e As EventArgs) Handles Me.Click
        SwitchVisible(True)
    End Sub

    Public Sub SwitchVisible(ToHide As Boolean)
        If ToHide Then
            Threading.ThreadPool.QueueUserWorkItem(New Threading.WaitCallback(
            Sub()
                Do While Me.Left < My.Computer.Screen.Bounds.Width
                    Me.Left += 10
                    Threading.Thread.Sleep(5)
                Loop
                Me.Hide()
            End Sub))
        Else
            Me.Left = -Me.Width
            Me.Show(MainForm)
            Threading.ThreadPool.QueueUserWorkItem(New Threading.WaitCallback(
            Sub()
                Do While Me.Left < (My.Computer.Screen.Bounds.Width - Me.Width) / 2
                    Me.Left += 10
                    Threading.Thread.Sleep(5)
                Loop
                Me.Left = (My.Computer.Screen.Bounds.Width - Me.Width) / 2
            End Sub))
        End If
    End Sub

    Private Sub AuthorForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        e.Cancel = True
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