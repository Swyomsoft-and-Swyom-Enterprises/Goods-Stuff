Option Strict Off

Imports System
Imports Microsoft.VisualBasic

Public NotInheritable Class frmTrial
    Inherits System.Windows.Forms.Form

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click

        Try
            TransactionMenu.btnPilot.BackColor = Color.MediumTurquoise
            TransactionMenu.btnTrlO.BackColor = Color.MediumTurquoise
            Call Reposition(sender, e)
            frmTrial_exitFlg = True
            MessageBox.Show("Exit the trial view", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Call TransactionMenu.btnStatus_Click(sender, e)
            TransactionMenu.Enabled = True
            Me.Dispose(True)
            Me.Close()

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in exit trial view", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub frmTrial_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Try
            TransactionMenu.btnPilot.BackColor = Color.MediumTurquoise
            TransactionMenu.btnTrlO.BackColor = Color.MediumTurquoise

            MessageBox.Show("Exit the trial view", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Dim ee As New System.EventArgs
            Call Reposition(sender, ee)
            frmTrial_exitFlg = True
            Call TransactionMenu.btnStatus_Click(sender, e)
            TransactionMenu.Enabled = True
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in Closing form", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub Reposition(ByVal sender As Object, ByVal e As System.EventArgs)

        Try
            Dim ee As System.Windows.Forms.MouseEventArgs = New MouseEventArgs(Windows.Forms.MouseButtons.Left, 0, 0, 0, 0)
            TransactionMenu.Rdb1.Checked = False
            TransactionMenu.Rdb2.Checked = False
            TransactionMenu.Rdb3.Checked = False
            TransactionMenu.Rdb4.Checked = False
            TransactionMenu.Rdb5.Checked = False
            TransactionMenu.Rdb6.Checked = False
            TransactionMenu.Rdb7.Checked = False
            TransactionMenu.Rdb8.Checked = False
            TransactionMenu.Rdb9.Checked = False
            TransactionMenu.Rdb10.Checked = False
            TransactionMenu.Rdb11.Checked = False
            TransactionMenu.Rdb12.Checked = False
            TransactionMenu.Rdb13.Checked = False
            TransactionMenu.Rdb14.Checked = False
            TransactionMenu.Rdb15.Checked = False
            TransactionMenu.Rdb16.Checked = False
            TransactionMenu.chkBxAutoStuff.Checked = False
            TransactionMenu.chkBxAutoStuffRC.Checked = False
            Call TransactionMenu.chkBxAutoStuff_MouseClick(sender, ee)

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in Reposition", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub frmTrial_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            Me.TopMost = True
            TrialShow.SendToBack()
            'Dim TrDgSz As System.Drawing.Size = New System.Drawing.Size(405, 99)
            Dim TrDgSz As System.Drawing.Size = New System.Drawing.Size(325, 99)
            Me.ShowInTaskbar = False
            With DgvTrial
                .Size = TrDgSz
                .RowHeadersWidth = 21
                .AutoGenerateColumns = False
                .RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
                .ColumnHeadersVisible = True
                .ColumnHeadersDefaultCellStyle.BackColor = Color.FloralWhite
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.Black
                .ColumnHeadersDefaultCellStyle.Font = New Font(DgvTrial.Font, FontStyle.Bold)
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
                .Columns(0).Width = 37
                .Columns(0).ReadOnly = True
                .Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable

                .Columns.Add("ColNm1", "LeftQty")
                .Columns(1).Width = 55
                .Columns(1).ReadOnly = True
                .Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable

                .Columns.Add("ColNm2", "Used Vol%")
                .Columns(2).Width = 75
                .Columns(2).ReadOnly = True
                .Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable

                .Columns.Add("ColNm2", "Compact %")
                .Columns(3).Width = 85      '75
                .Columns(3).ReadOnly = True
                .Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable

                ''.Columns.Add("ColNm3", "Rdb.Opt.No")
                ''.Columns(4).Width = 75
                ''.Columns(4).ReadOnly = True
                ''.Columns(4).Visible = False
                ''.Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable

                .Columns.Add("ColNm3", "Show")
                .Columns(4).Width = 70          '75
                .Columns(4).ReadOnly = True
                .Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable

                .Columns.Add("ColNm4", "        Rdb.Opt.No")
                .Columns(5).Width = 55
                .Columns(5).ReadOnly = True
                .Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable

                ''.Columns.Add("ColNm4", "Show")
                ''.Columns(5).Width = 55  '45
                ''.Columns(5).ReadOnly = True
                ''.Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable

                .Columns.Add("ColNm5", "RCsep")
                .Columns(6).Width = 45
                .Columns(6).ReadOnly = True
                '.Columns(6).Visible = False
                .Columns(6).SortMode = DataGridViewColumnSortMode.NotSortable
                .ScrollBars = ScrollBars.Vertical

            End With

            With DgvTrial.ColumnHeadersDefaultCellStyle
                .ForeColor = Color.MediumBlue
            End With

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in trial form loading", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub DgvTrial_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DgvTrial.DataError
        Exit Sub
    End Sub

    Private Sub DgvTrial_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DgvTrial.MouseClick

        Try
            Dim HtInfo As DataGridView.HitTestInfo
            HtInfo = DgvTrial.HitTest(e.X, e.Y)

            If HtInfo.Type = DataGridViewHitTestType.Cell Then
                Dim sbutton As Boolean = DgvTrial.Columns(HtInfo.ColumnIndex).HeaderText = "Show"
                Dim button As Button = IIf(sbutton, Me.TrialShow, Me.TrialShow)
                button.BringToFront()
                button.Text = "Show"
                button.BackColor = Color.MediumTurquoise
                button.Top = DgvTrial.Location.Y + HtInfo.RowY
                button.Left = DgvTrial.Location.X + HtInfo.ColumnX
                button.Width = DgvTrial(HtInfo.ColumnIndex, HtInfo.RowIndex).Size.Width
                button.Height = DgvTrial(HtInfo.ColumnIndex, HtInfo.RowIndex).Size.Height
                button.Visible = False
                If sbutton Then
                    button.Visible = True
                End If

                If TrialShowFlg Then
                    TrialShow.BackColor = Color.HotPink
                Else
                    TrialShow.BackColor = Color.MediumTurquoise
                End If

            End If

            If HtInfo.Type = DataGridViewHitTestType.ColumnHeader Then

                Select Case HtInfo.ColumnIndex

                    Case 0
                        Call DGVnotSortable()
                        'MessageBox.Show("SrNo column is not sorting", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Case 1
                        Call DGVnotSortable()
                        'MessageBox.Show("LeftQty column is not sorting", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Case 2
                        Call DGVnotSortable()
                        ' MessageBox.Show("Occ. Vol % column is not sorting", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Case 5
                        Call DGVnotSortable()
                        MessageBox.Show("Rdb. Opt. No. column is not sorting", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Case 4
                        Call DGVnotSortable()
                        MessageBox.Show("Show column is not sorting", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Case 6
                        Call DGVnotSortable()
                        MessageBox.Show("RCsep column is not sorting", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Select

            End If

            If Not (TransactionMenu.btnPilot.BackColor = Color.HotPink) Then
                If Not (TransactionMenu.btnTrlO.BackColor = Color.HotPink) Then
                    If HtInfo.ColumnIndex = 0 Or HtInfo.ColumnIndex = 1 Or HtInfo.ColumnIndex = 2 Or HtInfo.ColumnIndex = 3 Then
                        Dim MReslt As MsgBoxResult = MessageBox.Show("Do you want to sort the column?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        If MReslt = MsgBoxResult.No Then
                            Call DGVnotSortable()
                            Exit Sub
                        ElseIf MReslt = MsgBoxResult.Yes Then
                            Call DGVSortable()
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in Trial show button click", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub DGVSortable()

        Try
            DgvTrial.Columns(0).SortMode = DataGridViewColumnSortMode.Automatic
            DgvTrial.Columns(1).SortMode = DataGridViewColumnSortMode.Automatic
            DgvTrial.Columns(2).SortMode = DataGridViewColumnSortMode.Automatic
            DgvTrial.Columns(3).SortMode = DataGridViewColumnSortMode.Automatic

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in DGVSortable", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub DGVnotSortable()

        Try
            DgvTrial.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
            DgvTrial.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
            DgvTrial.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
            DgvTrial.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
            DgvTrial.Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
            DgvTrial.Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable
            DgvTrial.Columns(6).SortMode = DataGridViewColumnSortMode.NotSortable

            DgvTrial.Refresh()

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in notSortable", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub DgvTrial_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles DgvTrial.Scroll

        Try
            TrialShow.Visible = False
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in DgvTrial_Scroll", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub TrialShow_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TrialShow.MouseClick
        'Private Sub TrialShow_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TrialShow.MouseClick

        Try
            TrialShow.BringToFront()

            'Try
            '    frmStep.Close()
            'Catch
            'End Try

            'If chkbxStepTrials.Checked = True Then
            '    chkbxQuickShow.Checked = False
            '    TransactionMenu.btnStepTrials.BackColor = Color.HotPink
            '    frmStep.Show()
            '    TransactionMenu.Refresh()
            'Else
            '    chkbxQuickShow.Checked = False
            '    TransactionMenu.btnStepTrials.BackColor = Color.MediumTurquoise
            '    frmStep.Close()
            '    TransactionMenu.Refresh()
            'End If

            If Not TransactionMenu.TrlsFlg Then
                TransactionMenu.TrlsFlg = True
                If Not TrialShowFlg Then
                    If Not TransactionMenu.pilotFlg Then
                        TrialShowFlg = True
                        TrialShow.Visible = False
                        'Try
                        '    Dim CmdTrial As New OleDb.OleDbCommand
                        '    CmdTrial.Connection = conn
                        '    CmdTrial.CommandText = "delete from Trial"
                        '    CmdTrial.ExecuteNonQuery()
                        'Catch
                        'End Try

                        TransactionMenu.pilotFlg = False        'True     
                        TrialShow.BackColor = Color.HotPink
                        TransactionMenu.Rdb1.Checked = False
                        TransactionMenu.Rdb2.Checked = False
                        TransactionMenu.Rdb3.Checked = False
                        TransactionMenu.Rdb4.Checked = False
                        TransactionMenu.Rdb5.Checked = False
                        TransactionMenu.Rdb6.Checked = False
                        TransactionMenu.Rdb7.Checked = False
                        TransactionMenu.Rdb8.Checked = False
                        TransactionMenu.Rdb9.Checked = False
                        TransactionMenu.Rdb10.Checked = False
                        TransactionMenu.Rdb11.Checked = False
                        TransactionMenu.Rdb12.Checked = False
                        TransactionMenu.Rdb13.Checked = False
                        TransactionMenu.Rdb14.Checked = False
                        TransactionMenu.Rdb15.Checked = False
                        TransactionMenu.Rdb16.Checked = False

                        TransactionMenu.chkBxAutoStuff.Checked = False
                        TransactionMenu.chkBxAutoStuffRC.Checked = False
                        Call TransactionMenu.chkBxAutoStuff_MouseClick(sender, e)

                        Dim Rdo As Integer = 0
                        Dim rcSepr As String = Nothing
                        Dim FNwrl As String = Nothing

                        Dim Ri As Integer = DgvTrial.CurrentCell.RowIndex

                        Rdo = DgvTrial.Item(5, Ri).Value
                        rcSepr = DgvTrial.Item(6, Ri).Value

                        If rcSepr = Nothing Then

                            Rdo = RadioButtonRCSep(Rdo, rcSepr)

                        End If

                        If chkbxQuickShow.Checked = False Then
                            GoTo In_of_Step
                            TransactionMenu.pilotFlg = False
                        End If

                        Try
                            FNwrl = RetrivewrlFileName(Rdo, rcSepr)
                            Rdo = Rdo
                            rcSepr = rcSepr
                            FNwrl = FNwrl

                            If FNwrl = Nothing Then
                                MsgBox("The displaying file is wrong")
                            End If

                        Catch
                        End Try

                        Show3DViewWrlTrials(FNwrl)

                        'Try
                        '    Dim CmdTrial As New OleDb.OleDbCommand
                        '    CmdTrial.Connection = conn
                        '    CmdTrial.CommandText = "delete from Trial"
                        '    CmdTrial.ExecuteNonQuery()
                        'Catch
                        'End Try

                        GoTo Out_of_Step

In_of_Step:

                        If rcSepr = "TRUE" Then
                            TransactionMenu.chkBxAutoStuffRC.Checked = True
                        ElseIf rcSepr = "FALSE" Then
                            TransactionMenu.chkBxAutoStuffRC.Checked = False
                        ElseIf rcSepr = "" Then
                            TransactionMenu.chkBxAutoStuffRC.Checked = False
                        End If

                        If Rdo = 0 Then
                            TransactionMenu.Rdb1.Checked = False
                            TransactionMenu.Rdb2.Checked = False
                            TransactionMenu.Rdb3.Checked = False
                            TransactionMenu.Rdb4.Checked = False
                            TransactionMenu.Rdb5.Checked = False
                            TransactionMenu.Rdb6.Checked = False
                            TransactionMenu.Rdb7.Checked = False
                            TransactionMenu.Rdb8.Checked = False
                            TransactionMenu.Rdb9.Checked = False
                            TransactionMenu.Rdb10.Checked = False
                            TransactionMenu.Rdb11.Checked = False
                            TransactionMenu.Rdb12.Checked = False
                            TransactionMenu.Rdb13.Checked = False
                            TransactionMenu.Rdb14.Checked = False
                            TransactionMenu.Rdb15.Checked = False
                            TransactionMenu.Rdb16.Checked = False
                        End If

                        If Rdo = 1 Then
                            TransactionMenu.Rdb1.Checked = True
                        End If
                        If Rdo = 2 Then
                            TransactionMenu.Rdb2.Checked = True
                        End If
                        If Rdo = 3 Then
                            TransactionMenu.Rdb3.Checked = True
                        End If
                        If Rdo = 4 Then
                            TransactionMenu.Rdb4.Checked = True
                        End If
                        If Rdo = 5 Then
                            TransactionMenu.Rdb5.Checked = True
                        End If
                        If Rdo = 6 Then
                            TransactionMenu.Rdb6.Checked = True
                        End If
                        If Rdo = 7 Then
                            TransactionMenu.Rdb7.Checked = True
                        End If
                        If Rdo = 8 Then
                            TransactionMenu.Rdb8.Checked = True
                        End If
                        If Rdo = 9 Then
                            TransactionMenu.Rdb9.Checked = True
                        End If
                        If Rdo = 10 Then
                            TransactionMenu.Rdb10.Checked = True
                        End If
                        If Rdo = 11 Then
                            TransactionMenu.Rdb11.Checked = True
                        End If
                        If Rdo = 12 Then
                            TransactionMenu.Rdb12.Checked = True
                        End If
                        If Rdo = 13 Then
                            TransactionMenu.Rdb13.Checked = True
                        End If
                        If Rdo = 14 Then
                            TransactionMenu.Rdb14.Checked = True
                        End If
                        If Rdo = 15 Then
                            TransactionMenu.Rdb15.Checked = True
                        End If
                        If Rdo = 16 Then
                            TransactionMenu.Rdb16.Checked = True
                        End If
                        TransactionMenu.chkBxAutoStuff.Checked = True
                        Call TransactionMenu.chkBxAutoStuff_MouseClick(sender, e)
                        TransactionMenu.dgv1.Refresh()
                        Me.Refresh()

                        Call TransactionMenu.generateTable()
                        Call StopStep()
Out_of_Step:

                        TrialShow.BackColor = Color.MediumTurquoise
                        TransactionMenu.pilotFlg = False
                        TrialShow.Visible = True
                        TrialShowFlg = False
                    End If
                End If
                TransactionMenu.TrlsFlg = False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in Trial Show Mouse Click", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            TrialShow.SendToBack()
        End Try

    End Sub

    Private Function RetrivewrlFileName(ByVal rdbtn As Integer, ByVal rcsep As String) As String

        Dim StrfnWrl As String = Nothing

        Try

            Dim cmd As New OleDb.OleDbCommand
            Dim rdr As OleDb.OleDbDataReader

            conn.Close()
            If conn.State = ConnectionState.Closed Then conn.Open()
            cmd.Connection = conn

            cmd.CommandText = "select wrlFn from Trial where RdOpt=" & rdbtn & " and " & "RCSep='" & rcsep & "'"

            rdr = cmd.ExecuteReader()

            Do While (rdr.Read())

                StrfnWrl = rdr("wrlFn")

            Loop

            Return StrfnWrl

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in RetrivewrlFileName", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return StrfnWrl

    End Function

    Public Function RadioButtonRCSep(ByRef Rdbtn As Integer, ByRef RcSep As String) As Integer

        Dim dRw As DataRow()

        Dim srn As Integer
        Dim Lqty As Integer
        Dim OccVp As Double
        Dim CpVp As Double
        Dim RdBt As Integer
        Dim Rsep As String
        Dim wrlFn As String

        Try

            dRw = ReadRowxml("TrialStuff", "", "SrN, LeftQty, OccVolPer, Comper, RdOpt, RCSep, wrlFn")

            srn = dRw(0)("SrN")
            Lqty = dRw(0)("LeftQty")
            OccVp = dRw(0)("OccVolPer")
            CpVp = dRw(0)("Comper")
            RdBt = dRw(0)("RdOpt")
            Rsep = dRw(0)("RCSep")
            wrlFn = dRw(0)("wrlFn")


            RcSep = Rsep
            Return RdBt

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in RadioButton", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function

    Private Sub btnStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStop.Click

        Try
            TrialShow.Visible = False
            TrialShow.SendToBack()
            TrialShowFlg = False
            TransactionMenu.pilotFlg = False
            frmTrial_exitFlg = True
            Call TransactionMenu.btnStatus_Click(sender, e)

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in Stop Trials", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub chkbxStepTrials_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkbxStepTrials.CheckedChanged

        If chkbxStepTrials.Checked = True Then
            chkbxQuickShow.Checked = False
            TransactionMenu.btnStepTrials.BackColor = Color.HotPink
            frmStep.Show()
            TransactionMenu.Refresh()
        Else
            chkbxQuickShow.Checked = True
            TransactionMenu.btnStepTrials.BackColor = Color.MediumTurquoise
            frmStep.Close()
            TransactionMenu.Refresh()
        End If

    End Sub

    Private Sub chkbxQuickShow_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkbxQuickShow.CheckedChanged

        If chkbxStepTrials.Checked = True Then
            chkbxQuickShow.Checked = False
        End If

    End Sub
End Class
