Public Class frmStep

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click

        Try
            TransactionMenu.btnStepTrials.BackColor = Color.MediumTurquoise
            MessageBox.Show("Exit the step trial", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Call TransactionMenu.btnStatus_Click(sender, e)
            Me.Dispose(True)
            Me.Close()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in Exit the trial show", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub frmStep_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        Try
            TransactionMenu.btnStepTrials.BackColor = Color.MediumTurquoise
            Call TransactionMenu.btnStatus_Click(sender, e)
        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in Closed Form", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub frmStep_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Try
            TransactionMenu.btnStepTrials.BackColor = Color.MediumTurquoise
            Call TransactionMenu.btnStatus_Click(sender, e)
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in Closing Form", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub frmStep_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            StepCount = 1
            Me.TopMost = True
            Me.ShowInTaskbar = False

            Dim DSsz As System.Drawing.Size = New System.Drawing.Size(172, 208)

            With DgvDisplaySteps
                .Size = DSsz
                .RowHeadersWidth = 22
                .AutoGenerateColumns = False
                .RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
                .ColumnHeadersVisible = True
                .ColumnHeadersDefaultCellStyle.BackColor = Color.FloralWhite
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.Black
                .ColumnHeadersDefaultCellStyle.Font = New Font(DgvDisplaySteps.Font, FontStyle.Bold)
                .ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
                .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize

                .EditMode = DataGridViewEditMode.EditOnEnter
                .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
                .CellBorderStyle = DataGridViewCellBorderStyle.SunkenVertical
                .GridColor = SystemColors.ActiveBorder
                .BackgroundColor = Color.Honeydew
                .SelectionMode = DataGridViewSelectionMode.CellSelect
                .MultiSelect = False
                .RowHeadersVisible = False
                .ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single

                .Columns.Add("ColNm0", "SrNo")
                .Columns(0).Width = 45
                .Columns(0).ReadOnly = True
                .Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable

                .Columns.Add("ColNm1", "Step Show")
                .Columns(1).Width = 105
                .Columns(1).ReadOnly = True
                .Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable

            End With

            With DgvDisplaySteps.ColumnHeadersDefaultCellStyle
                .ForeColor = Color.MediumBlue
            End With

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in frmStep_Load", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub DgvDisplaySteps_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DgvDisplaySteps.DataError
        Exit Sub
    End Sub

    Private Sub DgvDisplaySteps_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DgvDisplaySteps.MouseClick

        Try
            Dim HtInfo As DataGridView.HitTestInfo
            HtInfo = DgvDisplaySteps.HitTest(e.X, e.Y)

            If HtInfo.Type = DataGridViewHitTestType.Cell Then
                Dim SButton As Boolean = DgvDisplaySteps.Columns(HtInfo.ColumnIndex).HeaderText = "Step Show"
                Dim Button As Button = IIf(SButton, Me.StepShow, Me.StepShow)
                Button.BringToFront()
                Button.Text = "Show"
                Button.BackColor = Color.MediumTurquoise
                Button.Top = DgvDisplaySteps.Location.Y + HtInfo.RowY
                Button.Left = DgvDisplaySteps.Location.X + HtInfo.ColumnX
                Button.Width = DgvDisplaySteps(HtInfo.ColumnIndex, HtInfo.RowIndex).Size.Width
                Button.Height = DgvDisplaySteps(HtInfo.ColumnIndex, HtInfo.RowIndex).Size.Height
                Button.Visible = False
                StepShow.Cursor = Cursors.Hand

                If SButton Then
                    Button.Visible = True
                End If

                If StpShowFlg Then
                    StepShow.BackColor = Color.HotPink
                Else
                    StepShow.BackColor = Color.MediumTurquoise
                End If

            End If
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in DgvDisplaySteps_MouseClick", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub StepShow_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles StepShow.MouseClick

        Try
            Try
                myProcess.Kill()
            Catch
            End Try

            StepShow.BackColor = Color.HotPink
            Me.Refresh()
            StpShowFlg = True
            Dim fCount As Integer = 0
            Dim wrlFnm As String = Nothing
            Dim rwIdx As Integer = DgvDisplaySteps.CurrentCell.RowIndex

            fCount = DgvDisplaySteps.Item(0, rwIdx).Value
            wrlFnm = CurDir() & "\OutPut\Firststp" & fCount & ".wrl"
            Show3DViewWrlTrials(wrlFnm)
            StepShow.BackColor = Color.MediumTurquoise

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in Step show Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub AddSteps(ByVal StpCount As Integer)

        Try

            DgvDisplaySteps.Rows.Add()
            DgvDisplaySteps.Item(0, StpCount - 1).Value = StpCount
            DgvDisplaySteps.Refresh()

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in AddSteps", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub DgvDisplaySteps_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles DgvDisplaySteps.Scroll
        StepShow.Visible = False
    End Sub

End Class