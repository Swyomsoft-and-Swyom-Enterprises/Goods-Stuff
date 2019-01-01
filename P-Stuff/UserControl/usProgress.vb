Public Class usProgress

    Private Sub usProgress_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        For i As Integer = 0 To 5

            Me.Focus()
            Me.BringToFront()

        Next

        PbUC.Width = 398
        PbUC.Height = 13

    End Sub

    Private Sub lblClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblClose1.Click
        Me.Dispose(True)
    End Sub

    Private Sub lblClose2_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblClose2.MouseHover
        lblClose1.Visible = True
        lblClose2.Visible = False
    End Sub

    Private Sub usProgress_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseEnter
        lblClose1.Visible = False
        lblClose2.Visible = True
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Dispose(True)
    End Sub

    Private Sub usProgress_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        xLocUc = Me.Location.X
        yLocUc = Me.Location.Y
    End Sub

    Private Sub usProgress_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp

        Dim x As Integer = e.X
        Dim y As Integer = e.Y

        Dim ucM As System.Drawing.Point = New System.Drawing.Point((xLocUc + x), (yLocUc + y))

        Me.Location = ucM

    End Sub

End Class
