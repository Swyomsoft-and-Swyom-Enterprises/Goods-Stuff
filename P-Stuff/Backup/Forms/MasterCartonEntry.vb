
'Program Name: -    MasterCartonEntry.vb
'Programmer Name: - Satwadhir B. Pawar Mob No. :- 9323974665
'Company Name:-     Hazel Infotech LTD. Mumbai
'Project Name: -    Sky Stuff Plus (Container Stuffing)
'Date: -            23 Dec 2K8 2.26 PM (Modified Time)

'Tips: - The code is debugging at that particular dimensions, quantity and sequence.
'        you are decide it the logic happen is correct to that way or its are some 
'        different way the understanding to at your best level is the correct logic 
'        of this particular code block.

'Description: - MasterCartonEntry is the form to intake the carton dimensions and weight of 
'               goods name pack code etc records store to the database so the record is the 
'               utilizing in stuffing activity. This form also manipulates the maximum 
'               quantity stored in to the container.

#Region " Importing Objects "

Imports SDO = System.Data.OleDb
Imports MSScriptControl


#End Region

Public NotInheritable Class MasterCartonEntry
    Inherits System.Windows.Forms.Form

#Region " Class Declaration "

    Private ds As New DataSet
    Private introw As Integer
    Dim da As New SDO.OleDbDataAdapter
    Dim BlnFormLod As Boolean
    Dim MaxPayLoad As Single
    Dim MaxSize As Single
    Dim str As String
    Dim i As Integer
    Dim BFlag As Boolean

#End Region

#Region " Routine Definitions "

    Private Sub tsbtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnAdd.Click

        Try
            Call gbDim1_Click(sender, e)
            Call cmdAdd_Click(sender, e)

        Catch Err As Exception
            MsgBox(Err.Message)
            MessageBox.Show("Error in tsbtnAdd_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tslblAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tslblAdd.Click

        Try
            Call gbDim1_Click(sender, e)
            Call cmdAdd_Click(sender, e)

        Catch Err As Exception
            MsgBox(Err.Message)
            MessageBox.Show("Error in tslblAdd_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnEdit.Click

        Try
            Call gbDim1_Click(sender, e)
            Call cmdEdit_Click(sender, e)

        Catch err As Exception
            MsgBox(err.Message)
            MessageBox.Show("Error in tsbtnEdit_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tslblEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tslblEdit.Click

        Try
            Call gbDim1_Click(sender, e)
            Call cmdEdit_Click(sender, e)

        Catch err As Exception
            MsgBox(err.Message)
            MessageBox.Show("Error in tslblEdit_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnDelete.Click

        Try
            Call gbDim1_Click(sender, e)
            Call cmdDel_Click(sender, e)

        Catch ex As Exception
            MsgBox(ex.Message)
            MessageBox.Show("Error in tsbtnDelete_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tslblDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tslblDelete.Click

        Try
            Call gbDim1_Click(sender, e)
            Call cmdDel_Click(sender, e)

        Catch ex As Exception
            MsgBox(ex.Message)
            MessageBox.Show("Error in tslblDelete_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbtnFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnFirst.Click

        Try
            Call gbDim1_Click(sender, e)
            Call cmdFirst_Click(sender, e)

        Catch Err As Exception
            MsgBox(Err.Message)
            MessageBox.Show("Error in tsbtnFirst_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tslblFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tslblFirst.Click

        Try
            Call gbDim1_Click(sender, e)
            Call cmdFirst_Click(sender, e)

        Catch Err As Exception
            MsgBox(Err.Message)
            MessageBox.Show("Error in tslblFirst_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbtnPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnPrev.Click

        Try
            Call gbDim1_Click(sender, e)
            Call cmdPrev_Click(sender, e)

        Catch err As Exception
            MsgBox(err.Message)
            MessageBox.Show("Error in tsbtnPrev_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tslblPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tslblPrev.Click

        Try
            Call gbDim1_Click(sender, e)
            Call cmdPrev_Click(sender, e)

        Catch err As Exception
            MsgBox(err.Message)
            MessageBox.Show("Error in tsbtnPrev_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnNext.Click

        Try
            Call gbDim1_Click(sender, e)
            Call cmdNext_Click(sender, e)

        Catch Err As Exception
            MsgBox(Err.Message)
            MessageBox.Show("Error in tsbtnNext_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tslblNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tslblNext.Click

        Try
            Call gbDim1_Click(sender, e)
            Call cmdNext_Click(sender, e)

        Catch Err As Exception
            MsgBox(Err.Message)
            MessageBox.Show("Error in tsbtnNext_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbtnLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnLast.Click

        Try
            Call gbDim1_Click(sender, e)
            Call cmdLast_Click(sender, e)

        Catch ex As Exception
            MsgBox(ex.Message)
            MessageBox.Show("Error in tsbtnLast_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tslblLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tslblLast.Click

        Try
            Call gbDim1_Click(sender, e)
            Call cmdLast_Click(sender, e)

        Catch ex As Exception
            MsgBox(ex.Message)
            MessageBox.Show("Error in tslblLast_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnFind.Click

        Try
            Call gbDim1_Click(sender, e)
            Call cmdFind_Click(sender, e)

        Catch ex As Exception
            MsgBox(ex.Message)
            MessageBox.Show("Error in tsbtnFind_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tslblFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tslblFind.Click

        Try
            Call gbDim1_Click(sender, e)
            Call cmdFind_Click(sender, e)

        Catch ex As Exception
            MsgBox(ex.Message)
            MessageBox.Show("Error in tsbtnFind_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbtnHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnHelp.Click

        Try
            Call gbDim1_Click(sender, e)
            Call cmdHelp_Click(sender, e)

        Catch ex As Exception
            MsgBox(ex.Message)
            MessageBox.Show("Error in tsbtnHelp_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tslblHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tslblHelp.Click

        Try
            Call gbDim1_Click(sender, e)
            Call cmdHelp_Click(sender, e)

        Catch ex As Exception
            MsgBox(ex.Message)
            MessageBox.Show("Error in tslblHelp_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnExit.Click

        Try
            Call gbDim1_Click(sender, e)
            Call cmdExit_Click(sender, e)

        Catch Err As Exception
            MsgBox(Err.Message)
            MessageBox.Show("Error in tsbtnExit_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tslblExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tslblExit.Click

        Try
            Call gbDim1_Click(sender, e)
            Call cmdExit_Click(sender, e)

        Catch Err As Exception
            MsgBox(Err.Message)
            MessageBox.Show("Error in tslblExit_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbtnDrumCM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnDrumCM.Click

        Try
            Call cmdExit_Click(sender, e)
            GC.Collect()
            Try
                DisplayActivity.lblDisplayActivity.Visible = True
                DisplayActivity.lblDisplayActivity.Text = "Please wait..." & vbCrLf & "Drum type item entry activity show"

                DisplayActivity.Show()
                Me.Dispose(True)
            Catch ex As Exception
                Exit Try
            Finally
                Me.Close()
                MasterCartonDrmEntry.Show()
                MasterCartonDrmEntry.Focus()
            End Try

        Catch ex As Exception
            MsgBox(ex.Message)
            MessageBox.Show("Error in tsbtnDrumCM_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbtnBoxDrumCM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnBoxDrumCM.Click

        MessageBox.Show(" Work in progress ", "Info.....", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub tsbtnOtherTypeStuff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnOtherTypeStuff.Click

        MessageBox.Show(" Work in progress ", "Info.....", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub tsbtnRestart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnRestart.Click

        Try
            MDIForm.Focus()
            GC.Collect()

            Try
                DisplayActivity.lblDisplayActivity.Visible = True
                DisplayActivity.lblDisplayActivity.Text = "Please wait..." & Chr(13) & "The container stuffing application is restarting"
                DisplayActivity.Show()
                Me.Dispose(True)
            Catch Ex As Exception
                Exit Try
            Finally
                Me.Dispose(True)
                Me.Close()
                Application.Exit()
                GC.Collect()
                Process.Start(CurDir() & "\Container Stuff.exe")
            End Try

        Catch ex As Exception
            MsgBox(ex.Message)
            MessageBox.Show("Error in tsbtnRestart_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Box3DViewerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Box3DViewerToolStripMenuItem.Click

        Dim fName As String = "C:\CSP.Box.wrl"

        Try

            Process.Start("D:\Program Files\Alteros 3D\alteros.exe", fName)

        Catch Err As Exception
            MsgBox(Err.Message)
            MessageBox.Show("Error in Box3DViewerToolStripMenuItem_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Drum3DViewerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Drum3DViewerToolStripMenuItem.Click

        Dim fName As String = "C:\CSP.Drum.wrl"

        Try

            Process.Start("D:\Program Files\Alteros 3D\alteros.exe", fName)

        Catch Err As Exception
            MsgBox(Err.Message)
            MessageBox.Show("Error in Drum3DViewerToolStripMenuItem_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub BoxDrum3DViewerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BoxDrum3DViewerToolStripMenuItem.Click

        MessageBox.Show(" Work in progress ", "Info.....", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub Other3DViewerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Other3DViewerToolStripMenuItem.Click

        MessageBox.Show(" Work in progress ", "Info.....", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub tsbtnBoxTCM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnBoxTCM.Click

        Try

            Call cmdExit_Click(sender, e)
            MDIForm.Focus()
            Me.Dispose(True)
            Me.Close()
            GC.Collect()

            Try
            Catch ex As Exception
                Exit Try
            Finally
                ShowBoxCartMst(sender, e)
            End Try

        Catch Err As Exception
            MsgBox(Err.Message)
            MessageBox.Show("Error in tsbtnBoxTCM_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbtnSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnSettings.Click

        Try

            ActivitySettings.Show()
            ActivitySettings.Focus()

        Catch Err As Exception
            MsgBox(Err.Message)
            MessageBox.Show("Error in tsbtnSettings_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub loadenable()

        cmdAdd.Enabled = True
        cmdEdit.Enabled = True
        cmdDel.Enabled = True
        cmdUpdate.Enabled = False
        cmdRef.Enabled = False
        cmdExit.Enabled = True
        cmdFirst.Enabled = True
        cmdNext.Enabled = True
        cmdPrev.Enabled = True
        cmdLast.Enabled = True
        cmdFind.Enabled = True

    End Sub

    Private Sub addenable()

        cmdAdd.Enabled = False
        cmdEdit.Enabled = False
        cmdDel.Enabled = False
        cmdUpdate.Enabled = True
        cmdRef.Enabled = True
        cmdExit.Enabled = True
        cmdFirst.Enabled = False
        cmdNext.Enabled = False
        cmdPrev.Enabled = False
        cmdLast.Enabled = False
        cmdFind.Enabled = False

    End Sub

    Private Sub editenable()

        cmdAdd.Enabled = False
        cmdEdit.Enabled = False
        cmdDel.Enabled = False
        cmdUpdate.Enabled = True
        cmdRef.Enabled = True
        cmdExit.Enabled = True
        cmdFirst.Enabled = False
        cmdNext.Enabled = False
        cmdPrev.Enabled = False
        cmdLast.Enabled = False
        cmdFind.Enabled = False

    End Sub

    Private Sub saveenable()

        cmdAdd.Enabled = True
        cmdEdit.Enabled = True
        cmdDel.Enabled = True
        cmdUpdate.Enabled = False
        cmdRef.Enabled = False
        cmdExit.Enabled = True
        cmdFirst.Enabled = True
        cmdNext.Enabled = True
        cmdPrev.Enabled = True
        cmdLast.Enabled = True
        cmdFind.Enabled = True

    End Sub

    Private Sub refenable()

        cmdAdd.Enabled = True
        cmdEdit.Enabled = True
        cmdDel.Enabled = True
        cmdUpdate.Enabled = False
        cmdRef.Enabled = False
        cmdExit.Enabled = True
        cmdFirst.Enabled = True
        cmdNext.Enabled = True
        cmdPrev.Enabled = True
        cmdLast.Enabled = True
        cmdFind.Enabled = True
        MasterCartonDetails.Enabled = False

    End Sub

    Public Sub TotalSize()

        Try
            Dim totalsizeic As Single
            totallengthic = (Val(txtlengthf.Text) * 12) + (Val(txtlengthi.Text)) + (Val(txtlengthc.Text) * 0.3937) + (Val(txtlengthm.Text) * 0.03937) ' 0.0394
            totallengthic = FormatNumber(totallengthic, 4, , , False)
            totalwidthic = (Val(txtwidthf.Text) * 12) + (Val(txtwidthi.Text)) + (Val(txtwidthc.Text) * 0.3937) + (Val(txtwidthm.Text) * 0.03937)
            totalwidthic = FormatNumber(totalwidthic, 4, , , False)
            totalheightic = (Val(txtheightf.Text) * 12) + (Val(txtheighti.Text)) + (Val(txtheightc.Text) * 0.3937) + (Val(txtheightm.Text) * 0.03937)
            totalheightic = FormatNumber(totalheightic, 4, , , False)
            totalsizeic = Val(totallengthic) * Val(totalwidthic) * Val(totalheightic)
            totalsizemc = Val(totalsizeic * 0.000016387064)
            txttotalsize.Text = totalsizemc
            txttotalsize.Text = FormatNumber(totalsizemc, 4, , , False)
            txttotalsizef.Text = Val(txttotalsize.Text) * 35.314
            txttotalsizef.Text = FormatNumber(Val(txttotalsizef.Text), 4, , , False)
            If Val(txttotalsize.Text) = 0 Then txttotalsize.Text = ""
            If Val(txttotalsizef.Text) = 0 Then txttotalsizef.Text = ""
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "TotalSize")
        End Try

    End Sub

    Public Sub TotalSizeS()

        Try
            Dim totalsizeic As Single
            totallengthic = (Val(Stxtlengthf.Text) * 12) + (Val(Stxtlengthi.Text)) + (Val(Stxtlengthc.Text) * 0.3937) + (Val(Stxtlengthm.Text) * 0.03937) ' 0.0394
            totallengthic = FormatNumber(totallengthic, 4, , , False)
            totalwidthic = (Val(Stxtwidthf.Text) * 12) + (Val(Stxtwidthi.Text)) + (Val(Stxtwidthc.Text) * 0.3937) + (Val(Stxtwidthm.Text) * 0.03937)
            totalwidthic = FormatNumber(totalwidthic, 4, , , False)
            totalheightic = (Val(Stxtheightf.Text) * 12) + (Val(Stxtheighti.Text)) + (Val(Stxtheightc.Text) * 0.3937) + (Val(Stxtheightm.Text) * 0.03937)
            totalheightic = FormatNumber(totalheightic, 4, , , False)
            totalsizeic = Val(totallengthic) * Val(totalwidthic) * Val(totalheightic)
            totalsizemc = Val(totalsizeic * 0.000016387064)
            txttotalsize.Text = totalsizemc
            txttotalsize.Text = FormatNumber(totalsizemc, 4, , , False)
            txttotalsizef.Text = Val(txttotalsize.Text) * 35.314
            txttotalsizef.Text = FormatNumber(Val(txttotalsizef.Text), 4, , , False)
            If Val(txttotalsize.Text) = 0 Then txttotalsize.Text = ""
            If Val(txttotalsizef.Text) = 0 Then txttotalsizef.Text = ""
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "TotalSize")
        End Try

    End Sub

    Private Sub MasterCartonEntry_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DoubleClick
        If ColDlgCarMst.ShowDialog Then
            Me.BackColor = ColDlgCarMst.Color
        End If
    End Sub

    Private Sub MasterCartonEntry_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Call MDIForm.BringFront()
    End Sub

    Private Sub MasterCartonEntry_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        If e.KeyCode = Keys.Escape Then Close()

    End Sub

    Private Sub MasterCartonEntry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor
            DisplayActivity.Close()
            btnBoxtypeitem.Enabled = False
            'Me.Top = 65 : Me.Left = 130
            Me.StartPosition = FormStartPosition.CenterScreen
            BFlag = False
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            FillDataSet()
            MasterCartonDetails.Enabled = False
            lblpackcode.Visible = False
            txtpackcode.Visible = False
            cmdUpdate.Enabled = False
            cmdRef.Enabled = False
            txtpackname.Focus()
            Call getContainerName()
            If ds.Tables!Text.Rows.Count = 0 Then
                Call NoRecorddisplay()
                Call txtclear()
                Exit Sub
            ElseIf ds.Tables!Text.Rows.Count - 1 >= 0 Then
                introw = ds.Tables!Text.Rows.Count - 1
                Call txtbind()
                Call loadenable()
            End If
            cmdLast_Click(Nothing, Nothing)
        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in MasterCartonEntry_Load", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub FillDataSet()

        Try
            Dim strSQL As String
            strSQL = "Select * from PackMast"
            Dim da As New SDO.OleDbDataAdapter(strSQL, conn)
            If ds.Tables.CanRemove(ds.Tables("Text")) Then
                ds.Tables("Text").Rows.Clear()
                ds.Tables("Text").Columns.Clear()
            End If
            da.Fill(ds, "Text")
            da = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
            MessageBox.Show("Error in FillDataSet", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtbind()

        Try
            txtpackcode.Text = IIf(IsDBNull(ds.Tables!Text.Rows(introw).Item("PackCode")), "", ds.Tables!Text.Rows(introw).Item("PackCode"))
            txtpackname.Text = IIf(IsDBNull(ds.Tables!Text.Rows(introw).Item("PackName")), "", ds.Tables!Text.Rows(introw).Item("PackName"))
            txtnetweight.Text = IIf(IsDBNull(ds.Tables!Text.Rows(introw).Item("NetWeight")), "", ds.Tables!Text.Rows(introw).Item("NetWeight"))
            txtgrossweight.Text = IIf(IsDBNull(ds.Tables!Text.Rows(introw).Item("GrossWeight")), "", ds.Tables!Text.Rows(introw).Item("GrossWeight"))
            txtfactor.Text = IIf(IsDBNull(ds.Tables!Text.Rows(introw).Item("Factor")), "", ds.Tables!Text.Rows(introw).Item("Factor"))
            If Val(ds.Tables!Text.Rows(introw).Item("LengthF")) = 0 Then
                txtlengthf.Text = ""
            Else
                txtlengthf.Text = ds.Tables!Text.Rows(introw).Item("LengthF")
            End If

            If Val(ds.Tables!Text.Rows(introw).Item("LengthI")) = 0 Then
                txtlengthi.Text = ""
            Else
                txtlengthi.Text = ds.Tables!Text.Rows(introw).Item("LengthI")
            End If

            If Val(ds.Tables!Text.Rows(introw).Item("LengthC")) = 0 Then
                txtlengthc.Text = ""
            Else
                txtlengthc.Text = ds.Tables!Text.Rows(introw).Item("LengthC")
            End If

            If Val(ds.Tables!Text.Rows(introw).Item("LengthM")) = 0 Then
                txtlengthm.Text = ""
            Else
                txtlengthm.Text = ds.Tables!Text.Rows(introw).Item("LengthM")
            End If

            If Val(ds.Tables!Text.Rows(introw).Item("WidthF")) = 0 Then
                txtwidthf.Text = ""
            Else
                txtwidthf.Text = ds.Tables!Text.Rows(introw).Item("WidthF")
            End If

            If Val(ds.Tables!Text.Rows(introw).Item("WidthI")) = 0 Then
                txtwidthi.Text = ""
            Else
                txtwidthi.Text = ds.Tables!Text.Rows(introw).Item("WidthI")
            End If

            If Val(ds.Tables!Text.Rows(introw).Item("WidthC")) = 0 Then
                txtwidthc.Text = ""
            Else
                txtwidthc.Text = ds.Tables!Text.Rows(introw).Item("WidthC")
            End If

            If Val(ds.Tables!Text.Rows(introw).Item("WidthM")) = 0 Then
                txtwidthm.Text = ""
            Else
                txtwidthm.Text = ds.Tables!Text.Rows(introw).Item("WidthM")
            End If

            If Val(ds.Tables!Text.Rows(introw).Item("HeightF")) = 0 Then
                txtheightf.Text = ""
            Else
                txtheightf.Text = ds.Tables!Text.Rows(introw).Item("HeightF")
            End If

            If Val(ds.Tables!Text.Rows(introw).Item("HeightI")) = 0 Then
                txtheighti.Text = ""
            Else
                txtheighti.Text = ds.Tables!Text.Rows(introw).Item("HeightI")
            End If

            If Val(ds.Tables!Text.Rows(introw).Item("HeightC")) = 0 Then
                txtheightc.Text = ""
            Else
                txtheightc.Text = ds.Tables!Text.Rows(introw).Item("HeightC")
            End If

            If Val(ds.Tables!Text.Rows(introw).Item("HeightM")) = 0 Then
                txtheightm.Text = ""
            Else
                txtheightm.Text = ds.Tables!Text.Rows(introw).Item("HeightM")
            End If

            txttotalsize.Text = IIf(IsDBNull(ds.Tables!Text.Rows(introw).Item("TotalSize")), "", ds.Tables!Text.Rows(introw).Item("TotalSize"))
            If Val(txttotalsize.Text) = 0 Then txttotalsize.Text = ""
            txttotalsizef.Text = IIf(IsDBNull(ds.Tables!Text.Rows(introw).Item("TotalSizeF")), "", ds.Tables!Text.Rows(introw).Item("TotalSizeF"))
            If Val(txttotalsizef.Text) = 0 Then txttotalsizef.Text = ""
            txtpackingmode.Text = IIf(IsDBNull(ds.Tables!Text.Rows(introw).Item("PackingMode")), "", ds.Tables!Text.Rows(introw).Item("PackingMode"))
            If IsDBNull(ds.Tables!Text.Rows(introw).Item("ContainerName")) = True Then
                cmbcontname.SelectedIndex = -1
            Else
                cmbcontname.Text = ds.Tables!Text.Rows(introw).Item("ContainerName")
            End If
            If Trim(cmbcontname.Text) = "" Or IsDBNull(ds.Tables!Text.Rows(introw).Item("FOrient")) = True Then
                CmbOrient.SelectedIndex = -1
            Else
                CmbOrient.Text = ds.Tables!Text.Rows(introw).Item("FOrient")
            End If
            txtmaxcont.Text = IIf(IsDBNull(ds.Tables!Text.Rows(introw).Item("maxcont")), "", ds.Tables!Text.Rows(introw).Item("maxcont"))
            If Val(txtmaxcont.Text) = 0 Then txtmaxcont.Text = ""
            txtmaxweight.Text = IIf(IsDBNull(ds.Tables!Text.Rows(introw).Item("maxweight")), "", ds.Tables!Text.Rows(introw).Item("maxweight"))
            If Val(txtmaxweight.Text) = 0 Then txtmaxweight.Text = ""
            TxtCId.Text = IIf(IsDBNull(ds.Tables!Text.Rows(introw).Item("ContainerId")), "", ds.Tables!Text.Rows(introw).Item("ContainerId"))

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MessageBox.Show("Error in txtbind", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click

        Try
            txtclear()
            addenable()
            str = "Add"
            MasterCartonDetails.Enabled = True
            BFlag = True
            txtpackname.Focus()
        Catch Err As Exception
            MsgBox(Err.Message)
            MessageBox.Show("Error in cmdAdd_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click

        Try
            editenable()
            str = "Edit"
            MasterCartonDetails.Enabled = True
            BFlag = True
            txtpackname.Focus()
        Catch Err As Exception
            MsgBox(Err.Message)
            MessageBox.Show("Error in ", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDel.Click

        Dim comm As SDO.OleDbCommand

        If MsgBox("Are you sure you want to delete this Record?", MsgBoxStyle.YesNo + vbCritical, "Carton Master") = MsgBoxResult.Yes Then

            Try
                comm = New SDO.OleDbCommand("Delete from PackMast where PackCode=" & Val(txtpackcode.Text), conn)

                If conn.State = ConnectionState.Closed Then conn.Open()

                comm.ExecuteNonQuery()
                Call FillDataSet()
                If ds.Tables!Text.Rows.Count = 0 Then
                    Call txtclear()
                    Call NoRecorddisplay()
                    cmdAdd.Focus()
                    Exit Sub
                Else
                    introw = ds.Tables!Text.Rows.Count - 1
                    Call txtclear()
                    Call txtbind()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
                MessageBox.Show("Error in cmdDel", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If

    End Sub

    Private Sub txtclear()

        txtpackcode.Text = ""
        txtpackname.Text = ""
        txtnetweight.Text = ""
        txtgrossweight.Text = ""
        txtfactor.Text = 6000
        txtlengthf.Text = ""
        txtlengthi.Text = ""
        txtlengthc.Text = ""
        txtlengthm.Text = ""
        txtwidthf.Text = ""
        txtwidthi.Text = ""
        txtwidthc.Text = ""
        txtwidthm.Text = ""
        txtheightf.Text = ""
        txtheighti.Text = ""
        txtheightc.Text = ""
        txtheightm.Text = ""
        txttotalsize.Text = ""
        txttotalsizef.Text = ""
        txtpackingmode.Text = ""
        cmbcontname.SelectedIndex = -1
        CmbOrient.SelectedIndex = -1
        txtmaxcont.Text = ""
        txtmaxweight.Text = ""
        TxtCId.Text = ""

    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click

        Dim strSQL As String

        Try
            Call gbDim1_Click(sender, e)
            Dim comm As SDO.OleDbCommand
            If Trim(txtpackname.Text) = "" Then
                MsgBox("Please enter Pack Name.", MsgBoxStyle.Exclamation, "Carton Master")
                addenable()
                txtpackname.Focus()
                Exit Sub
            End If
            If str = "Add" Then
                '---------Check Duplicate Record
                Dim strId As String
                strId = FCount("Select Count(PackName) as PackName1  from PackMast where PackName='" & Trim(txtpackname.Text) & "'")
                If strId <> 0 Then
                    MsgBox("Dublicate Pack name should not allow", MsgBoxStyle.Exclamation, "Carton Master")
                    txtpackname.Focus()
                    Exit Sub
                End If
                '--------------------------
                Dim Str1 As String
                Str1 = "Select Max(PackCode) As Pid from PackMast"
                txtpackcode.Text = GenId(Str1)
                strSQL = "Insert into PackMast(PackCode,PackName,LengthF,LengthI,LengthC,WidthF,WidthI,WidthC,HeightF,HeightI,HeightC,"
                strSQL = strSQL & "PackingMode,Netweight,Grossweight,Totalsize,Factor,HeightM,WidthM,LengthM,TotalsizeF,MaxCont,MaxWeight,ContainerName,ContainerId,FOrient)"
                strSQL = strSQL & "values(" & Val(txtpackcode.Text) & ", '" & Replace(Trim(txtpackname.Text), "'", "`") & "', " & Val(txtlengthf.Text) & ", " & Val(txtlengthi.Text) & ","
                strSQL = strSQL & " " & Val(txtlengthc.Text) & ", " & Val(txtwidthf.Text) & ", " & Val(txtwidthi.Text) & ", " & Val(txtwidthc.Text) & ", " & Val(txtheightf.Text) & ","
                strSQL = strSQL & " " & Val(txtheighti.Text) & ", " & Val(txtheightc.Text) & ", '" & (txtpackingmode.Text) & "', " & Val(txtnetweight.Text) & " , " & Val(txtgrossweight.Text) & ","
                strSQL = strSQL & " " & Val(txttotalsize.Text) & ", " & Val(txtfactor.Text) & ", " & Val(txtheightm.Text) & ", " & Val(txtwidthm.Text) & ", " & Val(txtlengthm.Text) & ","
                strSQL = strSQL & " " & Val(txttotalsizef.Text) & ", " & Val(txtmaxcont.Text) & ", " & Val(txtmaxweight.Text) & ", '" & (cmbcontname.Text) & "', " & Val(TxtCId.Text) & "," & Val(CmbOrient.Text) & ")"
                comm = New SDO.OleDbCommand(strSQL, conn)
                Try
                    If conn.State = ConnectionState.Closed Then conn.Open()
                    comm.ExecuteNonQuery()
                    FillDataSet()
                    introw = ds.Tables!Text.Rows.Count - 1
                    txtbind()
                    conn.Close()
                    BFlag = False
                    Call saveenable()
                    cmdAdd.Focus()
                    MasterCartonDetails.Enabled = False
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                    Exit Sub
                End Try
            ElseIf str = "Edit" Then
                strSQL = "Update PackMast set PackName='" & Replace(Trim(txtpackname.Text), "'", "`") & "', LengthF=" & Val(txtlengthf.Text) & ","
                strSQL = strSQL & " LengthI=" & Val(txtlengthi.Text) & ", LengthC=" & Val(txtlengthc.Text) & ", WidthF=" & Val(txtwidthf.Text) & ","
                strSQL = strSQL & " WidthI=" & Val(txtwidthi.Text) & ", WidthC=" & Val(txtwidthc.Text) & ", HeightF=" & Val(txtheightf.Text) & ","
                strSQL = strSQL & " HeightI=" & Val(txtheighti.Text) & ", HeightC=" & Val(txtheightc.Text) & ", PackingMode='" & (txtpackingmode.Text) & "',"
                strSQL = strSQL & " Netweight=" & Val(txtnetweight.Text) & ", Grossweight=" & Val(txtgrossweight.Text) & ", Totalsize=" & Val(txttotalsize.Text) & ","
                strSQL = strSQL & " Factor=" & Val(txtfactor.Text) & ", HeightM=" & Val(txtheightm.Text) & ", WidthM=" & Val(txtwidthm.Text) & ", LengthM=" & Val(txtlengthm.Text) & ","
                strSQL = strSQL & " TotalSizeF=" & Val(txttotalsizef.Text) & ", maxcont=" & Val(txtmaxcont.Text) & ", maxweight=" & Val(txtmaxweight.Text) & ","
                strSQL = strSQL & " ContainerName='" & cmbcontname.Text & "', ContainerId=" & Val(TxtCId.Text) & ",FOrient=" & Val(CmbOrient.Text) & " where PackCode =" & Val(txtpackcode.Text) & ""
                comm = New SDO.OleDbCommand(strSQL, conn)
                Try
                    If conn.State = ConnectionState.Closed Then conn.Open()
                    comm.ExecuteNonQuery()
                    FillDataSet()
                    txtbind()
                    conn.Close()
                    BFlag = False
                    Call saveenable()
                    cmdAdd.Focus()
                    MasterCartonDetails.Enabled = False
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                    Exit Sub
                End Try

            End If

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MessageBox.Show("Error in cmdUpdate_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdRef_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRef.Click

        Dim comm As New SDO.OleDbCommand 'delete

        Try
            If MsgBox("Are you sure you want to refresh this record?", MsgBoxStyle.YesNo + vbInformation, "Carton Master") = MsgBoxResult.Yes Then
                If ds.Tables!Text.Rows.Count = 0 Then
                    Call txtclear()
                    Call NoRecorddisplay()
                    MasterCartonDetails.Enabled = False
                    introw = 0
                    BFlag = False
                    cmdAdd.Focus()
                    Exit Sub
                ElseIf introw > 0 Or introw <= ds.Tables!Text.Rows.Count - 1 Then
                    refenable()
                    introw = introw
                    txtclear()
                    txtbind()
                    BFlag = False
                    cmdAdd.Focus()
                End If
            Else
                txtpackname.Focus()
                Exit Sub
            End If
        Catch Er As Exception
            MsgBox(Er.Message)
            MessageBox.Show("Error in cmdRef_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click

        Dim strSQL As String
        Dim comm As SDO.OleDbCommand

        Try
            If BFlag = True Then
                If MsgBox("Do you want to save this record?", MsgBoxStyle.YesNo + vbExclamation, "Carton Master") = MsgBoxResult.Yes Then
                    If Trim(txtpackname.Text) = "" Then
                        MsgBox("Please enter Pack Name.", MsgBoxStyle.Exclamation, "Carton Master")
                        addenable()
                        txtpackname.Focus()
                        Exit Sub
                    End If
                    If Trim(cmbcontname.Text) <> "" Then
                        If Val(CmbOrient.Text) = 0 Then
                            addenable()
                            CmbOrient.Focus()
                            Exit Sub
                        End If
                    End If
                    If str = "Add" Then
                        '---------Check Duplicate Record
                        Dim strId As String
                        strId = FCount("Select Count(PackName) as PackName1  from PackMast where PackName='" & Trim(txtpackname.Text) & "'")
                        If strId <> 0 Then
                            MsgBox("Dublicate Pack name should not allow", MsgBoxStyle.Exclamation, "Carton Master")
                            txtpackname.Focus()
                            Exit Sub
                        End If
                        '--------------------------
                        Dim Str1 As String
                        Str1 = "Select Max(PackCode) As Pid from PackMast"
                        txtpackcode.Text = GenId(Str1)
                        strSQL = "Insert into PackMast(PackCode,PackName,LengthF,LengthI,LengthC,WidthF,WidthI,WidthC,HeightF,HeightI,HeightC,"
                        strSQL = strSQL & "PackingMode,Netweight,Grossweight,Totalsize,Factor,HeightM,WidthM,LengthM,TotalsizeF,MaxCont,MaxWeight,ContainerName,ContainerId,FOrient)"
                        strSQL = strSQL & "values(" & Val(txtpackcode.Text) & ", '" & Replace(Trim(txtpackname.Text), "'", "`") & "', " & Val(txtlengthf.Text) & ", " & Val(txtlengthi.Text) & ","
                        strSQL = strSQL & " " & Val(txtlengthc.Text) & ", " & Val(txtwidthf.Text) & ", " & Val(txtwidthi.Text) & ", " & Val(txtwidthc.Text) & ", " & Val(txtheightf.Text) & ","
                        strSQL = strSQL & " " & Val(txtheighti.Text) & ", " & Val(txtheightc.Text) & ", '" & (txtpackingmode.Text) & "', " & Val(txtnetweight.Text) & " , " & Val(txtgrossweight.Text) & ","
                        strSQL = strSQL & " " & Val(txttotalsize.Text) & ", " & Val(txtfactor.Text) & ", " & Val(txtheightm.Text) & ", " & Val(txtwidthm.Text) & ", " & Val(txtlengthm.Text) & ","
                        strSQL = strSQL & " " & Val(txttotalsizef.Text) & ", " & Val(txtmaxcont.Text) & ", " & Val(txtmaxweight.Text) & ", '" & (cmbcontname.Text) & "', " & Val(TxtCId.Text) & "," & Val(CmbOrient.Text) & ")"
                        comm = New SDO.OleDbCommand(strSQL, conn)
                        Try
                            If conn.State = ConnectionState.Closed Then conn.Open()
                            comm.ExecuteNonQuery()
                            FillDataSet()
                            introw = ds.Tables!Text.Rows.Count - 1
                            txtbind()
                            conn.Close()
                            BFlag = False
                            Call saveenable()
                            cmdAdd.Focus()
                            MasterCartonDetails.Enabled = False
                            Close()
                        Catch ex As Exception
                            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                            Exit Sub
                        End Try
                    ElseIf str = "Edit" Then
                        strSQL = "Update PackMast set PackName='" & Replace(Trim(txtpackname.Text), "'", "`") & "', LengthF=" & Val(txtlengthf.Text) & ","
                        strSQL = strSQL & " LengthI=" & Val(txtlengthi.Text) & ", LengthC=" & Val(txtlengthc.Text) & ", WidthF=" & Val(txtwidthf.Text) & ","
                        strSQL = strSQL & " WidthI=" & Val(txtwidthi.Text) & ", WidthC=" & Val(txtwidthc.Text) & ", HeightF=" & Val(txtheightf.Text) & ","
                        strSQL = strSQL & " HeightI=" & Val(txtheighti.Text) & ", HeightC=" & Val(txtheightc.Text) & ", PackingMode='" & (txtpackingmode.Text) & "',"
                        strSQL = strSQL & " Netweight=" & Val(txtnetweight.Text) & ", Grossweight=" & Val(txtgrossweight.Text) & ", Totalsize=" & Val(txttotalsize.Text) & ","
                        strSQL = strSQL & " Factor=" & Val(txtfactor.Text) & ", HeightM=" & Val(txtheightm.Text) & ", WidthM=" & Val(txtwidthm.Text) & ", LengthM=" & Val(txtlengthm.Text) & ","
                        strSQL = strSQL & " TotalSizeF=" & Val(txttotalsizef.Text) & ", maxcont=" & Val(txtmaxcont.Text) & ", maxweight=" & Val(txtmaxweight.Text) & ","
                        strSQL = strSQL & " ContainerName='" & cmbcontname.Text & "', ContainerId=" & Val(TxtCId.Text) & ",FOrient=" & Val(CmbOrient.Text) & " where PackCode =" & Val(txtpackcode.Text) & ""
                        comm = New SDO.OleDbCommand(strSQL, conn)
                        Try
                            If conn.State = ConnectionState.Closed Then conn.Open()
                            comm.ExecuteNonQuery()
                            FillDataSet()
                            txtbind()
                            conn.Close()
                            cmdAdd.Focus()
                            BFlag = False
                            Call saveenable()
                            MasterCartonDetails.Enabled = False
                            Close()
                        Catch ex As Exception
                            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                            Exit Sub
                        End Try
                    End If
                Else
                    Close()
                End If
            Else
                Close()
            End If

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MessageBox.Show("Error in cmdExit_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFirst.Click

        Try
            If ds.Tables!Text.Rows.Count - 1 >= 0 Then
                introw = 0
                txtbind()
                cmdEdit.Enabled = True
                cmdDel.Enabled = True
            End If
        Catch Ex As Exception
            MsgBox(Ex.Message)
            MessageBox.Show("Error in cmdFirst_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNext.Click

        Try
            If introw < ds.Tables!Text.Rows.Count - 1 Then
                introw = introw + 1
                txtbind()
            End If
            cmdEdit.Enabled = True
            cmdDel.Enabled = True
        Catch Ex As Exception
            MsgBox(Ex.Message)
            MessageBox.Show("Error in cmdNext_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrev.Click

        Try

            If introw > 0 Then
                introw = introw - 1
                txtbind()
            End If
            cmdEdit.Enabled = True
            cmdDel.Enabled = True

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MessageBox.Show("Error in cmdPrev_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLast.Click

        Try
            If ds.Tables!Text.Rows.Count - 1 >= 0 Then
                introw = ds.Tables!Text.Rows.Count - 1
                Call txtbind()
                cmdEdit.Enabled = True
                cmdDel.Enabled = True
            End If
        Catch Ex As Exception
            MsgBox(Ex.Message)
            MessageBox.Show("Error in cmdLast_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFind.Click

        Try
            'Me.Top = 50 : Me.Left = 150
            DT = "MasterCartonEntry"
            FindStr = "SELECT * FROM PackMast ORDER BY PackName"
            title = "PackMast"
            frmSearch.ShowDialog()
            Me.ActivateMdiChild(frmSearch)
            frmSearch.Txtsearch.Focus()
        Catch Ex As Exception
            MsgBox(Ex.Message)
            MessageBox.Show("Error in cmdFind_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtpackname_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpackname.GotFocus

        txtpackname.Select(0, 10)

    End Sub

    Private Sub txtpackname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtpackname.KeyDown

        If e.KeyCode = Keys.Enter Then txtnetweight.Focus()

    End Sub

    Private Sub txtnetweight_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnetweight.GotFocus

        txtnetweight.Select(0, 10)

    End Sub

    Private Sub txtnetweight_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtnetweight.KeyDown

        If e.KeyCode = Keys.Enter Then txtgrossweight.Focus()

    End Sub

    Private Sub txtgrossweight_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtgrossweight.GotFocus

        txtgrossweight.Select(0, 10)

    End Sub

    Private Sub txtgrossweight_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtgrossweight.KeyDown

        If e.KeyCode = Keys.Enter Then txtfactor.Focus()

    End Sub

    Private Sub txtfactor_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtfactor.GotFocus

        txtfactor.Select(0, 10)

    End Sub

    Private Sub txtfactor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtfactor.KeyDown

        If e.KeyCode = Keys.Enter Then txtlengthf.Focus()

    End Sub

    Private Sub txtheightm_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtheightm.GotFocus

        txtheightm.Select(0, 10)

    End Sub

    Private Sub txtheightm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtheightm.KeyDown

        If e.KeyCode = Keys.Enter Then txtpackingmode.Focus()

    End Sub

    Private Sub txtheightm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtheightm.LostFocus

        Call TotalSize()

    End Sub

    Private Sub txttotalsize_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txttotalsize.KeyDown

        If e.KeyCode = Keys.Enter Then txttotalsizef.Focus()

    End Sub

    Private Sub txttotalsizef_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txttotalsizef.KeyDown

        If e.KeyCode = Keys.Enter Then txtpackingmode.Focus()

    End Sub

    Private Sub txtpackingmode_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpackingmode.GotFocus

        txtpackingmode.Select()

    End Sub

    Private Sub txtpackingmode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtpackingmode.KeyDown

        If e.KeyCode = Keys.Enter Then cmbcontname.Focus()

    End Sub

    Private Sub txtlengthf_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtlengthf.GotFocus

        txtlengthf.Select(0, 10)

    End Sub

    Private Sub txtlengthf_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtlengthf.KeyDown

        If e.KeyCode = Keys.Enter Then txtwidthf.Focus()

    End Sub

    Private Sub txtwidthf_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtwidthf.GotFocus

        txtwidthf.Select(0, 10)

    End Sub

    Private Sub txtwidthf_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtwidthf.KeyDown

        If e.KeyCode = Keys.Enter Then txtheightf.Focus()

    End Sub

    Private Sub txtheightf_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtheightf.GotFocus

        txtheightf.Select(0, 10)

    End Sub

    Private Sub txtheightf_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtheightf.KeyDown

        If e.KeyCode = Keys.Enter Then txtlengthi.Focus()

    End Sub

    Private Sub txtlengthi_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtlengthi.GotFocus

        txtlengthi.Select(0, 10)

    End Sub

    Private Sub txtlengthi_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtlengthi.KeyDown

        If e.KeyCode = Keys.Enter Then txtwidthi.Focus()

    End Sub

    Private Sub txtwidthi_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtwidthi.GotFocus

        txtwidthi.Select(0, 10)

    End Sub

    Private Sub txtwidthi_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtwidthi.KeyDown

        If e.KeyCode = Keys.Enter Then txtheighti.Focus()

    End Sub

    Private Sub txtheighti_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtheighti.GotFocus

        txtheighti.Select(0, 10)

    End Sub

    Private Sub txtheighti_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtheighti.KeyDown

        If e.KeyCode = Keys.Enter Then txtlengthc.Focus()

    End Sub

    Private Sub txtlengthc_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtlengthc.GotFocus

        txtlengthc.Select(0, 10)

    End Sub

    Private Sub txtlengthc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtlengthc.KeyDown

        If e.KeyCode = Keys.Enter Then txtwidthc.Focus()

    End Sub

    Private Sub txtwidthc_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtwidthc.GotFocus

        txtwidthc.Select(0, 10)

    End Sub

    Private Sub txtwidthc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtwidthc.KeyDown

        If e.KeyCode = Keys.Enter Then txtheightc.Focus()

    End Sub

    Private Sub txtheightc_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtheightc.GotFocus

        txtheightc.Select(0, 10)

    End Sub

    Private Sub txtheightc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtheightc.KeyDown

        If e.KeyCode = Keys.Enter Then txtlengthm.Focus()

    End Sub

    Private Sub txtlengthm_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtlengthm.GotFocus

        txtlengthm.Select(0, 10)

    End Sub

    Private Sub txtlengthm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtlengthm.KeyDown

        If e.KeyCode = Keys.Enter Then txtwidthm.Focus()

    End Sub

    Private Sub txtwidthm_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtwidthm.GotFocus

        txtwidthm.Select(0, 10)

    End Sub

    Private Sub txtwidthm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtwidthm.KeyDown

        If e.KeyCode = Keys.Enter Then txtheightm.Focus()

    End Sub

    Private Sub getContainerName()

        Dim StrSQL As String
        Try
            StrSQL = "Select * From ContainerMaster ORDER BY ContainerName"
            If conn.State = ConnectionState.Closed Then conn.Open()
            da = New SDO.OleDbDataAdapter(StrSQL, conn)
            If ds.Tables.CanRemove(ds.Tables("TabCust")) = True Then
                ds.Tables("TabCust").Rows.Clear()
                ds.Tables("TabCust").Columns.Clear()
            End If
            da.Fill(ds, "TabCust")
            conn.Close()
            cmbcontname.DataSource = Nothing
            cmbcontname.DataSource = ds.Tables("Tabcust").DefaultView
            cmbcontname.DisplayMember = "ContainerName"
        Catch Ex As Exception
            MsgBox(Ex.Message)
            MessageBox.Show("Error in getContainerName", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdHelp.Click

        Try
            Process.Start(CurDir() & "\HelpContainerStuff\Index.chm")
        Catch Ex As Exception
            MsgBox(Ex.Message)
            MessageBox.Show("Error in cmdHelp_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdUpdate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmdUpdate.KeyDown

        If e.KeyCode = Keys.Enter Then
            cmdAdd.Focus() : cmdUpdate_Click(Nothing, Nothing)
        Else
            Exit Sub
        End If
    End Sub

    Private Sub cmbcontname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbcontname.KeyDown
        If e.KeyCode = Keys.Enter Then CmbOrient.Focus()
    End Sub

    Private Sub txtnetweight_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnetweight.KeyPress

        Dim k As Integer

        k = Asc(e.KeyChar)
        Select Case k
            Case 48 To 57, 8, 13, 32
            Case 45
            Case 46
            Case Else
                k = 0
        End Select
        If k = 0 Then
            e.Handled = True
        Else
            e.Handled = False
        End If

    End Sub

    Private Sub cmbcontname_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcontname.SelectionChangeCommitted

        Try
            Dim FlagMax As Boolean
            Dim MaxPayLoad1 As String

            MaxPayLoad1 = Val(cmbcontname.Items(cmbcontname.SelectedIndex)(14) & "")

            If Val(txtgrossweight.Text) > 0 Then
                MaxPayLoad1 = Val(cmbcontname.Items(cmbcontname.SelectedIndex)(14) & "") \ Val(txtgrossweight.Text)
                txtmaxweight.Text = MaxPayLoad1
            Else
                txtmaxweight.Text = ""
            End If

            CmbOrient.SelectedIndex = 0
            If CmbOrient.Text = 6 Then
                FlagMax = False
            Else
                FlagMax = True
            End If
            totallengthic = Val(Format((cmbcontname.Items(cmbcontname.SelectedIndex)(2) * 12), "0.0000")) + Val(Format((cmbcontname.Items(cmbcontname.SelectedIndex)(5)), "0.0000")) + Val(Format((cmbcontname.Items(cmbcontname.SelectedIndex)(8) / 2.54), "0.0000")) + Val(Format((cmbcontname.Items(cmbcontname.SelectedIndex)(11) / 25.4), "0.0000"))
            totalwidthic = Val(Format((cmbcontname.Items(cmbcontname.SelectedIndex)(3) * 12), "0.0000")) + Val(Format((cmbcontname.Items(cmbcontname.SelectedIndex)(6)), "0.0000")) + Val(Format((cmbcontname.Items(cmbcontname.SelectedIndex)(9) / 2.54), "0.0000")) + Val(Format((cmbcontname.Items(cmbcontname.SelectedIndex)(12) / 25.4), "0.0000"))
            totalheightic = Val(Format((cmbcontname.Items(cmbcontname.SelectedIndex)(4) * 12), "0.0000")) + Val(Format((cmbcontname.Items(cmbcontname.SelectedIndex)(7)), "0.0000")) + Val(Format((cmbcontname.Items(cmbcontname.SelectedIndex)(10) / 2.54), "0.0000")) + Val(Format((cmbcontname.Items(cmbcontname.SelectedIndex)(13) / 25.4), "0.0000"))
            Dim ans = MsgBox("Do you want to calculate maximum quantity?", MsgBoxStyle.YesNo)
            If ans = MsgBoxResult.Yes Then

                txtmaxcont.Text = calcmxqty1(totallengthic, totalwidthic, totalheightic, FlagMax)
            Else
                Exit Sub
            End If
        Catch Ex As Exception
            MsgBox(Ex.Message)
            MessageBox.Show("Error in cmbcontname_SelectionChangeCommitted", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtgrossweight_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtgrossweight.KeyPress

        Dim k As Integer
        k = Asc(e.KeyChar)
        Select Case k
            Case 48 To 57, 8, 13, 32
            Case 45
            Case 46
            Case Else
                k = 0
        End Select
        If k = 0 Then
            e.Handled = True
        Else
            e.Handled = False
        End If

    End Sub

    Private Sub txtfactor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtfactor.KeyPress

        Dim k As Integer

        k = Asc(e.KeyChar)

        Select Case k
            Case 48 To 57, 8, 13, 32
            Case 45
            Case Else
                k = 0
        End Select
        If k = 0 Then
            e.Handled = True
        Else
            e.Handled = False
        End If

    End Sub

    Private Sub NoRecorddisplay()

        cmdAdd.Enabled = True
        cmdExit.Enabled = True
        cmdEdit.Enabled = False
        cmdDel.Enabled = False
        cmdFirst.Enabled = False
        cmdNext.Enabled = False
        cmdPrev.Enabled = False
        cmdLast.Enabled = False
        cmdFind.Enabled = False
        cmdUpdate.Enabled = False
        cmdRef.Enabled = False
        MasterCartonDetails.Enabled = False

    End Sub

    Private Sub txtpackname_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpackname.LostFocus

        txtpackname.Text = Replace(txtpackname.Text, "'", "`")

    End Sub

    Private Sub txtheightc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtheightc.LostFocus

        Call TotalSize()

    End Sub

    Private Sub txtheightf_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtheightf.LostFocus

        Call TotalSize()

    End Sub

    Private Sub txtheighti_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtheighti.LostFocus

        Call TotalSize()

    End Sub

    Private Sub txtlengthc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtlengthc.LostFocus

        Call TotalSize()

    End Sub

    Private Sub txtlengthf_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtlengthf.LostFocus

        Call TotalSize()

    End Sub

    Private Sub txtlengthi_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtlengthi.LostFocus

        Call TotalSize()

    End Sub

    Private Sub txtlengthm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtlengthm.LostFocus

        Call TotalSize()

    End Sub

    Private Sub txtwidthc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtwidthc.LostFocus

        Call TotalSize()

    End Sub

    Private Sub txtwidthf_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtwidthf.LostFocus

        Call TotalSize()

    End Sub

    Private Sub txtwidthi_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtwidthi.LostFocus

        Call TotalSize()

    End Sub

    Private Sub txtwidthm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtwidthm.LostFocus

        Call TotalSize()

    End Sub

    Private Sub CmbOrient_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbOrient.KeyDown

        If e.KeyCode = Keys.Enter Then cmdUpdate.Focus()

    End Sub

    Private Sub CmbOrient_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbOrient.SelectionChangeCommitted

        Try
            Dim FlagMax As Boolean
            If cmbcontname.Text <> "" Then
                If Val(CmbOrient.Text) = 6 Then
                    FlagMax = False
                ElseIf Val(CmbOrient.Text) = 2 Then
                    FlagMax = True
                Else
                    Exit Sub
                End If
                totallengthic = Val(cmbcontname.Items(cmbcontname.SelectedIndex)(2) * 12) + Val(cmbcontname.Items(cmbcontname.SelectedIndex)(5) + Val(cmbcontname.Items(cmbcontname.SelectedIndex)(8) / 2.54)) + Val(cmbcontname.Items(cmbcontname.SelectedIndex)(11) / 25.4)
                totalwidthic = Val(cmbcontname.Items(cmbcontname.SelectedIndex)(3) * 12) + Val(cmbcontname.Items(cmbcontname.SelectedIndex)(6) + Val(cmbcontname.Items(cmbcontname.SelectedIndex)(9) / 2.54)) + Val(cmbcontname.Items(cmbcontname.SelectedIndex)(12) / 25.4)
                totalheightic = Val(cmbcontname.Items(cmbcontname.SelectedIndex)(4) * 12) + Val(cmbcontname.Items(cmbcontname.SelectedIndex)(7) + Val(cmbcontname.Items(cmbcontname.SelectedIndex)(10) / 2.54)) + Val(cmbcontname.Items(cmbcontname.SelectedIndex)(13) / 25.4)
                txtmaxcont.Text = calcmxqty1(totallengthic, totalwidthic, totalheightic, FlagMax)
            End If

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MessageBox.Show("Error in CmbOrient_SelectionChangeCommitted", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    'Private Sub btnRestart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRestart.Click

    '    mdiform.Focus()
    '    GC.Collect()
    '    Try
    '        DisplayActivity.lblDisplayActivity.Visible = True
    '        DisplayActivity.lblDisplayActivity.Text = "Please wait..." & Chr(13) & "The container stuffing application is restarting"
    '        DisplayActivity.Show()
    '        Me.Dispose(True)
    '    Catch Ex As Exception
    '        Exit Try
    '    Finally
    '        Me.Dispose(True)
    '        Me.Close()
    '        Application.Exit()
    '        GC.Collect()
    '        Process.Start(CurDir() & "\Container Stuff.exe")
    '    End Try

    'End Sub

    'Private Sub btnDrumtypeitem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDrumtypeitem.Click

    'Call cmdExit_Click(sender, e)
    'GC.Collect()
    'Try
    '    DisplayActivity.lblDisplayActivity.Visible = True
    '    DisplayActivity.lblDisplayActivity.Text = "Please wait..." & vbCrLf & "Drum type item entry activity show"

    '    DisplayActivity.Show()
    '    Me.Dispose(True)
    'Catch ex As Exception
    '    Exit Try
    'Finally
    '    Me.Close()

    '    MasterCartonDrmEntry.Show()
    '    MasterCartonDrmEntry.Focus()

    'End Try

    'End Sub

#End Region

#Region " Function Definitions "

    Public Function calcmxqty1(ByVal clength As Single, ByVal cwidth As Single, ByVal cheight As Single, ByVal tpup As Boolean) As Integer

        Dim ar() As Area
        Dim ari() As String
        Dim arwt() As Single
        Dim ar1 As New Area
        Dim wt As String = Nothing
        Dim transparr() As Boolean
        Dim topup() As Boolean
        ReDim ar(0)
        ReDim ari(0)
        ReDim arwt(0)
        ReDim transparr(0)
        ReDim topup(0)
        Dim cmd As New OleDb.OleDbCommand
        Dim cnt As Integer = 0
        Dim lstcol As New List(Of Byte)
        Dim arc As New Area
        arc.StrtPt.x = 0
        arc.StrtPt.y = 0
        arc.StrtPt.z = 0
        arc.length = clength
        arc.width = cwidth
        arc.height = cheight
        Dim mm As New Area
        Dim mm1 As New Area

        Dim vol1 As Double = 0
        Dim vol2 As Double = 0
        Dim maxqty As Integer
        Dim arx As New List(Of Area)
        Dim colarr As New List(Of List(Of Byte))

        Try
            mm.length = Val(txtlengthi.Text) + Val(txtlengthf.Text) * 12 + Val(txtlengthc.Text) / 2.54 + Val(txtlengthm.Text) / 25.4
            mm.width = Val(txtwidthi.Text) + Val(txtwidthf.Text) * 12 + Val(txtwidthc.Text) / 2.54 + Val(txtwidthm.Text) / 25.4
            mm.height = Val(txtheighti.Text) + Val(txtheightf.Text) * 12 + Val(txtheightc.Text) / 2.54 + Val(txtheightm.Text) / 25.4

            Bqtylst.Add(-1)
            vol1 = mm.length * mm.height * mm.width
            If vol1 <> 0 Then
                vol2 = arc.length * arc.width * arc.height
                maxqty = Fix(vol2 / vol1)

                ReDim ar(0)
                ReDim ari(0)
                For j As Integer = 0 To maxqty - 1
                    ar(UBound(ar)) = New Area
                    ar(UBound(ar)).length = mm.length
                    ar(UBound(ar)).width = mm.width
                    ar(UBound(ar)).height = mm.height
                    ari(UBound(ari)) = ""
                    arwt(UBound(arwt)) = wt
                    transparr(UBound(transparr)) = False
                    topup(UBound(topup)) = tpup
                    colarr.Add(lstcol)
                    ReDim Preserve ar(UBound(ar) + 1)
                    ReDim Preserve ari(UBound(ari) + 1)
                    ReDim Preserve arwt(UBound(arwt) + 1)
                    ReDim Preserve transparr(UBound(transparr) + 1)
                    ReDim Preserve topup(UBound(topup) + 1)
                Next
                ReDim Preserve ar(UBound(ar) - 1)
                ReDim Preserve ari(UBound(ari) - 1)
                ReDim Preserve arwt(UBound(arwt) - 1)
                ReDim Preserve transparr(UBound(transparr) - 1)
                ReDim Preserve topup(UBound(topup) - 1)
                stk.Clear()
                stk.Add(arc)
                Bitemqty = 0

                Call stuff_orig(arc, ar, ari, arwt, False, False, "", False, Nothing, topup, False, False, False, True, colarr)

                ReDim ar(0)
                ReDim ari(0)
                ReDim arwt(0)
                ReDim transparr(0)
                ReDim topup(0)

                Form8.Close()
                stk.Clear()
                stk.Add(arc)
            Else

            End If

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MessageBox.Show("Error in calcmxqty1", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        stk.Clear()
        stk.Add(arc)
        Return Bitemqty

    End Function

#End Region

   
    Private Sub gbDim0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles gbDim0.Click

        gbDim1.Visible = True

        Stxtlengthf.Text = txtlengthf.Text
        Stxtwidthf.Text = txtwidthf.Text
        Stxtheightf.Text = txtheightf.Text

        Stxtlengthi.Text = txtlengthi.Text
        Stxtwidthi.Text = txtwidthi.Text
        Stxtheighti.Text = txtheighti.Text

        Stxtlengthc.Text = txtlengthc.Text
        Stxtwidthc.Text = txtwidthc.Text
        Stxtheightc.Text = txtheightc.Text

        Stxtlengthm.Text = txtlengthm.Text
        Stxtwidthm.Text = txtwidthm.Text
        Stxtheightm.Text = txtheightm.Text

        Call TotalSize()
        Call TotalSizeS()

    End Sub

    Private Sub gbDim1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles gbDim1.Click

        gbDim1.Visible = False

        If Stxtlengthf.Text = "" Or Stxtwidthf.Text = "" Or Stxtheightf.Text = "" Or Stxtlengthi.Text = "" Or Stxtwidthi.Text = "" Or Stxtheighti.Text = "" Or Stxtlengthc.Text = "" Or Stxtwidthc.Text = "" Or Stxtheightc.Text = "" Or Stxtlengthm.Text = "" Or Stxtwidthm.Text = "" Or Stxtheightm.Text = "" Then
            GoTo Nxtsx
        Else

            txtlengthf.Text = Stxtlengthf.Text
            txtwidthf.Text = Stxtwidthf.Text
            txtheightf.Text = Stxtheightf.Text

            txtlengthi.Text = Stxtlengthi.Text
            txtwidthi.Text = Stxtwidthi.Text
            txtheighti.Text = Stxtheighti.Text

            txtlengthc.Text = Stxtlengthc.Text
            txtwidthc.Text = Stxtwidthc.Text
            txtheightc.Text = Stxtheightc.Text

            txtlengthm.Text = Stxtlengthm.Text
            txtwidthm.Text = Stxtwidthm.Text
            txtheightm.Text = Stxtheightm.Text

        End If

Nxtsx:
        Call TotalSizeS()
        Call TotalSize()

    End Sub

    Public Function TCalc(ByVal inVal As String) As String

        If inVal.Trim = "" Then
            Return inVal
            Exit Function
        End If

        Dim MCalc As New ScriptControl()

        MCalc.Language = "VBScript"

        Try
            inVal = CStr(MCalc.Eval(inVal))
            Return inVal
        Catch
            MessageBox.Show("Invalid entry", "Calculation Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return inVal
        End Try

        Return inVal

    End Function

    Private Sub Stxtheightc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Stxtheightc.LostFocus
        Stxtheightc.Text = TCalc(Stxtheightc.Text)
        Call TotalSizeS()
    End Sub

    Private Sub Stxtheightf_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Stxtheightf.LostFocus
        Stxtheightf.Text = TCalc(Stxtheightf.Text)
        Call TotalSizeS()
    End Sub

    Private Sub Stxtheighti_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Stxtheighti.LostFocus
        Stxtheighti.Text = TCalc(Stxtheighti.Text)
        Call TotalSizeS()
    End Sub

    Private Sub Stxtheightm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Stxtheightm.LostFocus
        Stxtheightm.Text = TCalc(Stxtheightm.Text)
        Call TotalSizeS()
    End Sub

    Private Sub Stxtlengthc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Stxtlengthc.LostFocus
        Stxtlengthc.Text = TCalc(Stxtlengthc.Text)
        Call TotalSizeS()
    End Sub

    Private Sub Stxtlengthf_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Stxtlengthf.LostFocus
        Stxtlengthf.Text = TCalc(Stxtlengthf.Text)
        Call TotalSizeS()
    End Sub

    Private Sub Stxtlengthi_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Stxtlengthi.LostFocus
        Stxtlengthi.Text = TCalc(Stxtlengthi.Text)
        Call TotalSizeS()
    End Sub

    Private Sub Stxtlengthm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Stxtlengthm.LostFocus
        Stxtlengthm.Text = TCalc(Stxtlengthm.Text)
        Call TotalSizeS()
    End Sub

    Private Sub Stxtwidthc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Stxtwidthc.LostFocus
        Stxtwidthc.Text = TCalc(Stxtwidthc.Text)
        Call TotalSizeS()
    End Sub

    Private Sub Stxtwidthf_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Stxtwidthf.LostFocus
        Stxtwidthf.Text = TCalc(Stxtwidthc.Text)
        Call TotalSizeS()
    End Sub

    Private Sub Stxtwidthi_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Stxtwidthi.LostFocus
        Stxtwidthi.Text = TCalc(Stxtwidthi.Text)
        Call TotalSizeS()
    End Sub

    Private Sub Stxtwidthm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Stxtwidthm.LostFocus
        Stxtwidthm.Text = TCalc(Stxtwidthm.Text)
        Call TotalSizeS()
    End Sub

    Private Sub cmdUpdate_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdUpdate.MouseEnter
        Call updates()
        Call gbDim1_Click(sender, e)
    End Sub

    Private Sub cmdUpdate_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdUpdate.MouseHover
        Call gbDim1_Click(sender, e)
    End Sub

    Protected Sub add()
        'ToolTip.SetToolTip(cmdAdd, "Add the carton data into the master")
    End Sub

    Protected Sub edit()
        'ToolTip.SetToolTip(cmdEdit, "Edit the carton data into the master")
    End Sub

    Protected Sub delete()
        'ToolTip.SetToolTip(cmdDel, "Delete the carton data into the master")
    End Sub

    Protected Sub first()
        'ToolTip.SetToolTip(cmdFirst, "Go to the first record of the carton master")
    End Sub

    Protected Sub previous()
        'ToolTip.SetToolTip(cmdPrev, "Go to the previous record of the carton master")
    End Sub

    Protected Sub nexts()
        'ToolTip.SetToolTip(cmdNext, "Go to the next record of the carton master")
    End Sub

    Protected Sub last()
        'ToolTip.SetToolTip(cmdLast, "Go to the last record of the carton master")
    End Sub

    Protected Sub find()
        'ToolTip.SetToolTip(cmdFind, "Find the record of carton master")
    End Sub

    Protected Sub help()
        'ToolTip.SetToolTip(cmdHelp, "Help of the application")
    End Sub

    Protected Sub exits()
        'ToolTip.SetToolTip(cmdExit, "Exit the carton master")
    End Sub

    Protected Sub cartonname()
        'ToolTip.SetToolTip(txtpackname, "Enter the carton identity name")
    End Sub

    Protected Sub weight()
        'ToolTip.SetToolTip(txtnetweight, "Enter the weight in kg. Of each carton")
    End Sub

    Protected Sub flength()
        'ToolTip.SetToolTip(txtlengthf, "Enter the length in feet unit")
    End Sub

    Protected Sub ilength()
        'ToolTip.SetToolTip(txtlengthi, "Enter the length in inch unit")
    End Sub

    Protected Sub clength()
        'ToolTip.SetToolTip(txtlengthc, "Enter the length in centimeter unit")
    End Sub

    Protected Sub mlength()
        'ToolTip.SetToolTip(txtlengthm, "Enter the length in millimeter unit")
    End Sub

    Protected Sub fwidth()
        'ToolTip.SetToolTip(txtwidthf, "Enter the width in feet unit")
    End Sub

    Protected Sub iwidth()
        'ToolTip.SetToolTip(txtwidthi, "Enter the width in inch unit")
    End Sub

    Protected Sub cwidth()
        'ToolTip.SetToolTip(txtwidthc, "Enter the width in centimeter unit")
    End Sub

    Protected Sub mwidth()
        'ToolTip.SetToolTip(txtwidthm, "Enter the width in millimeter unit")
    End Sub

    Protected Sub fheight()
        'ToolTip.SetToolTip(txtheightf, "Enter the height in feet unit")
    End Sub

    Protected Sub iheight()
        'ToolTip.SetToolTip(txtheighti, "Enter the height in inch unit")
    End Sub

    Protected Sub cheight()
        'ToolTip.SetToolTip(txtheightc, "Enter the height in centimeter unit")
    End Sub

    Protected Sub mheight()
        'ToolTip.SetToolTip(txtheightm, "Enter the height in millimeter unit")
    End Sub

    Protected Sub updates()
        'ToolTip.SetToolTip(cmdUpdate, "Update the carton master")
    End Sub

    Protected Sub refreshs()
        'ToolTip.SetToolTip(cmdRef, "Refresh the carton master")
    End Sub

    Private Sub cmdAdd_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAdd.MouseEnter
        Call add()
    End Sub

    Private Sub cmdEdit_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdEdit.MouseEnter
        Call edit()
    End Sub

    Private Sub cmdDel_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdDel.MouseEnter
        Call delete()
    End Sub

    Private Sub cmdFirst_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdFirst.MouseEnter
        Call first()
    End Sub

    Private Sub cmdPrev_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdPrev.MouseEnter
        Call previous()
    End Sub

    Private Sub cmdNext_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdNext.MouseEnter
        Call nexts()
    End Sub

    Private Sub cmdLast_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdLast.MouseEnter
        Call last()
    End Sub

    Private Sub cmdFind_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdFind.MouseEnter
        Call find()
    End Sub

    Private Sub cmdHelp_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdHelp.MouseEnter
        Call help()
    End Sub

    Private Sub cmdExit_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdExit.MouseEnter
        Call exits()
    End Sub

    Private Sub txtpackname_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpackname.MouseEnter
        Call cartonname()
    End Sub

    Private Sub txtnetweight_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnetweight.MouseEnter
        Call weight()
    End Sub

    Private Sub Stxtlengthf_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Stxtlengthf.MouseEnter
        Call flength()
    End Sub

    Private Sub Stxtlengthi_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Stxtlengthi.MouseEnter
        Call ilength()
    End Sub

    Private Sub Stxtlengthc_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Stxtlengthc.MouseEnter
        Call clength()
    End Sub

    Private Sub Stxtlengthm_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Stxtlengthm.MouseEnter
        Call mlength()
    End Sub

    Private Sub Stxtwidthf_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Stxtwidthf.MouseEnter
        Call fwidth()
    End Sub

    Private Sub Stxtwidthi_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Stxtwidthi.MouseEnter
        Call iwidth()
    End Sub

    Private Sub Stxtwidthc_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Stxtwidthc.MouseEnter
        Call cwidth()
    End Sub

    Private Sub Stxtwidthm_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Stxtwidthm.MouseEnter
        Call mwidth()
    End Sub

    Private Sub Stxtheightf_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Stxtheightf.MouseEnter
        Call fheight()
    End Sub

    Private Sub Stxtheighti_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Stxtheighti.MouseEnter
        Call iheight()
    End Sub

    Private Sub Stxtheightc_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Stxtheightc.MouseEnter
        Call cheight()
    End Sub

    Private Sub Stxtheightm_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Stxtheightm.MouseEnter
        Call mheight()
    End Sub

    Private Sub cmdRef_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdRef.MouseEnter
        Call refreshs()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

End Class