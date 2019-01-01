
'Program Name: -    MasterCartonDrmEntry.vb
'Programmer Name: - Satwadhir B. Pawar Mob No. :- 9323974665
'Company Name:-     Hazel Infotech LTD. Mumbai
'Project Name: -    Sky Stuff Plus (Container Stuffing)
'Date: -            23 Dec 2K8 3.55 PM (Modified Time)

'Tips: - The code is debugging at that particular dimensions, quantity and sequence.
'        you are decide it the logic happen is correct to that way or its are some 
'        different way the understanding to at your best level is the correct logic 
'        of this particular code block.

'Description: - MasterCartonDrmEntry is the forms to enter the drum geometry information 
'               like name diameter height weights etc. this also calculate maximum quantity 
'               is placed in to the container. This information is further used to stuff
'               the drum type geometry.

#Region " Importing Objects "

Imports SDOleDb = System.Data.OleDb

#End Region

Public NotInheritable Class MasterCartonDrmEntry
    Inherits System.Windows.Forms.Form

#Region " Class Declaration "

    Private Ds As New DataSet
    Private IntRow As Integer
    Dim Da As New SDOleDb.OleDbDataAdapter
    Dim BlnFormLod As Boolean
    Dim MaxPayLoad As Single
    Dim MaxSize As Single
    Dim Str As String
    Dim i As Integer
    Dim BFlag As Boolean

#End Region

#Region " Routine Definitions "

    Private Sub tsbtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnAdd.Click

        Try

            Call cmdAdd_Click(sender, e)

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in tsbtnAdd_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tslblAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tslblAdd.Click

        Try

            Call cmdAdd_Click(sender, e)

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in tslblAdd_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnEdit.Click

        Try

            Call cmdEdit_Click(sender, e)

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in tsbtnEdit_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tslblEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tslblEdit.Click

        Try

            Call cmdEdit_Click(sender, e)

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in tslblEdit_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnDelete.Click

        Try

            Call cmdDel_Click(sender, e)

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in tsbtnDelete_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tslblDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tslblDelete.Click

        Try

            Call cmdDel_Click(sender, e)

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in tslblDelete_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbtnFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnFirst.Click

        Try

            Call cmdFirst_Click(sender, e)

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in tsbtnFirst_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tslblFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tslblFirst.Click

        Try

            Call cmdFirst_Click(sender, e)

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in tslblFirst_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbtnPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnPrev.Click

        Try

            Call cmdPrev_Click(sender, e)

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in tsbtnPrev_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tslblPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tslblPrev.Click

        Try

            Call cmdPrev_Click(sender, e)

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in tslblPrev_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tslblNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tslblNext.Click

        Try
            Call cmdNext_Click(sender, e)

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in tslblNext_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnNext.Click

        Try
            Call cmdNext_Click(sender, e)

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in tsbtnNext_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbtnLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnLast.Click

        Try

            Call cmdLast_Click(sender, e)

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in tsbtnLast_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tslblLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tslblLast.Click

        Try

            Call cmdLast_Click(sender, e)

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in tslblLast_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnFind.Click

        Try

            Call cmdFind_Click(sender, e)

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in tsbtnFind_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tslblFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tslblFind.Click

        Try

            Call cmdFind_Click(sender, e)

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in tslblFind_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbtnHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnHelp.Click

        Try

            Call cmdHelp_Click(sender, e)

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in tsbtnHelp_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tslblHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tslblHelp.Click

        Try

            Call cmdHelp_Click(sender, e)

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in tsbtnHelp_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnExit.Click

        Try

            Call cmdExit_Click(sender, e)

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in tsbtnExit_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tslblExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tslblExit.Click

        Try

            Call cmdExit_Click(sender, e)

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in tslblExit_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbtnRestart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnRestart.Click

        Try

            Call RestartApp(sender, e)

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in tsbtnRestart_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbtnBoxTCM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnBoxTCM.Click

        Try

            Call BoxtypeItem(sender, e)

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in tsbtnBoxTCM_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbtnDrumCM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnDrumCM.Click

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
                'ShowBoxCartMst(sender, e)
                ShowMasterCartDrmEntry(sender, e)
            End Try

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in tsbtnDrumCM_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbtnBoxDrumCM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnBoxDrumCM.Click

        MessageBox.Show(" Work in progress ", "Info.....", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub tsbtnOtherTypeStuff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnOtherTypeStuff.Click

        MessageBox.Show(" Work in progress ", "Info.....", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub tsbtnSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnSettings.Click

        Try

            ActivitySettings.Show()
            ActivitySettings.Focus()

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in tsbtnSettings_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtgrossweight_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtgrossweight.KeyPress

        Try

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

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in txtgrossweight_KeyPress", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtfactor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtfactor.KeyPress

        Try
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

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in txtfactor_KeyPress", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtpackname_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpackname.LostFocus

        txtpackname.Text = Replace(txtpackname.Text, "'", "`")

    End Sub

    Private Sub txtheightc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDheightc.LostFocus

        Try

            If DiaFlg = False Then
                Call TotalSize()
            End If

            If DiaFlg = True Then
                Call DTotalSize()
            End If

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in txtheightc_LostFocus", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtheightf_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDheightf.LostFocus

        Try

            If DiaFlg = False Then
                Call TotalSize()
            End If

            If DiaFlg = True Then
                Call DTotalSize()
            End If

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in txtheightf_LostFocus", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtheighti_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDheighti.LostFocus

        Try

            If DiaFlg = False Then
                Call TotalSize()
            End If

            If DiaFlg = True Then
                Call DTotalSize()
            End If

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in txtheighti_LostFocus", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtlengthc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDlengthc.LostFocus

        Try
            If DiaFlg = False Then
                Call TotalSize()
            End If

            If DiaFlg = True Then
                Call DTotalSize()
            End If

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in txtlengthc_LostFocus", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtlengthf_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDlengthf.LostFocus

        Try
            If DiaFlg = False Then
                Call TotalSize()
            End If

            If DiaFlg = True Then
                Call DTotalSize()
            End If
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in txtlengthf_LostFocus", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtlengthm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDlengthm.LostFocus

        Try

            If DiaFlg = False Then
                Call TotalSize()
            End If

            If DiaFlg = True Then
                Call DTotalSize()
            End If
        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in txtlengthm_LostFocus", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtwidthc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDwidthc.LostFocus

        Try
            If DiaFlg = False Then
                Call TotalSize()
            End If

            If DiaFlg = True Then
                Call DTotalSize()
            End If
        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in txtwidthc_LostFocus", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtwidthf_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDwidthf.LostFocus

        Try

            If DiaFlg = False Then
                Call TotalSize()
            End If

            If DiaFlg = True Then
                Call DTotalSize()
            End If
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in txtwidthf_LostFocus", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtwidthm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDwidthm.LostFocus

        Try
            If DiaFlg = False Then
                Call TotalSize()
            End If

            If DiaFlg = True Then
                Call DTotalSize()
            End If
        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in txtwidthm_LostFocus", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub CmbOrient_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbOrient.KeyDown

        If e.KeyCode = Keys.Enter Then cmdUpdate.Focus()

    End Sub

    Private Sub CmbOrient_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbOrient.SelectionChangeCommitted

        'Dim FlagMax As Boolean
        'If cmbcontname.Text <> "" Then
        'If Val(CmbOrient.Text) = 6 Then
        'FlagMax = False
        'ElseIf Val(CmbOrient.Text) = 2 Then
        'FlagMax = True
        'Else
        'Exit Sub
        'End If
        'totallengthic = Val(cmbcontname.Items(cmbcontname.SelectedIndex)(2) * 12) + Val(cmbcontname.Items(cmbcontname.SelectedIndex)(5) + Val(cmbcontname.Items(cmbcontname.SelectedIndex)(8) / 2.54)) + Val(cmbcontname.Items(cmbcontname.SelectedIndex)(11) / 25.4)
        'TotalWidthic = Val(cmbcontname.Items(cmbcontname.SelectedIndex)(3) * 12) + Val(cmbcontname.Items(cmbcontname.SelectedIndex)(6) + Val(cmbcontname.Items(cmbcontname.SelectedIndex)(9) / 2.54)) + Val(cmbcontname.Items(cmbcontname.SelectedIndex)(12) / 25.4)
        'TotalHeightic = Val(cmbcontname.Items(cmbcontname.SelectedIndex)(4) * 12) + Val(cmbcontname.Items(cmbcontname.SelectedIndex)(7) + Val(cmbcontname.Items(cmbcontname.SelectedIndex)(10) / 2.54)) + Val(cmbcontname.Items(cmbcontname.SelectedIndex)(13) / 25.4)
        'txtmaxcont.Text = CalcMxQty1(totallengthic, TotalWidthic, TotalHeightic, FlagMax)
        'End If

    End Sub

    Private Sub rdobtnDia_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        MsgBox("Enter Diameter Length and Width ", MsgBoxStyle.Information, "Diameter Length & Width Entering ...")

        txtDDiameterc.Enabled = False
        txtDDiameterf.Enabled = False
        txtDDiameteri.Enabled = False
        txtDDiameterm.Enabled = False

        txtDlengthc.Enabled = True
        txtDlengthf.Enabled = True
        txtDlengthi.Enabled = True
        txtDlengthm.Enabled = True

        txtDwidthc.Enabled = True
        txtDwidthf.Enabled = True
        txtDwidthi.Enabled = True
        txtDwidthm.Enabled = True

    End Sub

    'Private Sub rdobtnDia_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdobtnDia.CheckedChanged

    '    MsgBox("Enter Diameter Length and Width ", MsgBoxStyle.Information, "Diameter Length & Width Entering ...")

    '    txtDDiameterc.Enabled = False
    '    txtDDiameterf.Enabled = False
    '    txtDDiameteri.Enabled = False
    '    txtDDiameterm.Enabled = False


    '    txtDlengthctxt.Visible = True
    '    txtDwidthctxt.Visible = True
    '    txtDlengthftxt.Visible = True
    '    txtDwidthftxt.Visible = True
    '    txtDlengthitxt.Visible = True
    '    txtDwidthitxt.Visible = True
    '    txtDlengthmtxt.Visible = True
    '    txtDwidthmtxt.Visible = True

    '    txtDlengthc.Visible = False
    '    txtDwidthc.Visible = False
    '    txtDlengthf.Visible = False
    '    txtDwidthf.Visible = False
    '    txtDlengthi.Visible = False
    '    txtDwidthi.Visible = False
    '    txtDlengthm.Visible = False
    '    txtDwidthm.Visible = False

    '    txtDlengthctxt.Text = ""
    '    txtDwidthctxt.Text = ""
    '    txtDlengthftxt.Text = ""
    '    txtDwidthftxt.Text = ""
    '    txtDlengthitxt.Text = ""
    '    txtDwidthitxt.Text = ""
    '    txtDlengthmtxt.Text = ""
    '    txtDwidthmtxt.Text = ""

    '    'txtDlengthc.Enabled = True
    '    'txtDlengthf.Enabled = True
    '    'txtDlengthi.Enabled = True
    '    'txtDlengthm.Enabled = True

    '    'txtDwidthc.Enabled = True
    '    'txtDwidthf.Enabled = True
    '    'txtDwidthi.Enabled = True
    '    'txtDwidthm.Enabled = True

    'End Sub

    Private Sub txtDlengthi_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDlengthi.LostFocus

        Try

            If DiaFlg = False Then
                Call TotalSize()
            End If

            If DiaFlg = True Then
                Call DTotalSize()
            End If

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in txtDlengthi_LostFocus", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtDwidthi_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDwidthi.LostFocus

        Try
            If DiaFlg = False Then
                Call TotalSize()
            End If

            If DiaFlg = True Then
                Call DTotalSize()
            End If
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in txtDwidthi_LostFocus", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub DrumTotalSize()

        Try
            Dim TotalSizeic As Single

            DTotalLengthsic = (Val(txtDlengthftxt.Text) * 12) + (Val(txtDlengthitxt.Text)) + (Val(txtDlengthctxt.Text) * 0.3937) + (Val(txtDlengthmtxt.Text) * 0.03937) ' 0.0394
            'DTotalLengthsic = (Val(txtDlengthf.Text) * 12) + (Val(txtDlengthi.Text)) + (Val(txtDlengthc.Text) * 0.3937) + (Val(txtDlengthm.Text) * 0.03937) ' 0.0394

            DTotalLengthsic = FormatNumber(DTotalLengthsic, 4, , , False)

            totalwidthic = (Val(txtDwidthftxt.Text) * 12) + (Val(txtDwidthitxt.Text)) + (Val(txtDwidthctxt.Text) * 0.3937) + (Val(txtDwidthmtxt.Text) * 0.03937)
            'totalwidthic = (Val(txtDwidthf.Text) * 12) + (Val(txtDwidthi.Text)) + (Val(txtDwidthc.Text) * 0.3937) + (Val(txtDwidthm.Text) * 0.03937)
            totalwidthic = FormatNumber(totalwidthic, 4, , , False)

            totalheightic = (Val(txtDheightf.Text) * 12) + (Val(txtDheighti.Text)) + (Val(txtDheightc.Text) * 0.3937) + (Val(txtDheightm.Text) * 0.03937)
            totalheightic = FormatNumber(totalheightic, 4, , , False)

            TotalSizeic = Val(DTotalLengthsic) * Val(totalwidthic) * Val(totalheightic) * 0.785398163   'Pi / 4 = 0.785398163

            totalsizemc = Val(TotalSizeic * 0.000016387064)

            txttotalsize.Text = totalsizemc
            txttotalsize.Text = FormatNumber(totalsizemc, 4, , , False)
            txttotalsizef.Text = Val(txttotalsize.Text) * 35.314
            txttotalsizef.Text = FormatNumber(Val(txttotalsizef.Text), 4, , , False)

            DrmCalcdiameter()

            If Val(txttotalsize.Text) = 0 Then txttotalsize.Text = ""
            If Val(txttotalsizef.Text) = 0 Then txttotalsizef.Text = ""

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MsgBox(Ex.Message, MsgBoxStyle.Critical, "TotalSize() procedure")
            MessageBox.Show("Error in DrumTotalSize", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub DrmCalcdiameter()

        Dim DDiameter As Single

        Try
            DDiameter = (((Val(txtDlengthftxt.Text)) + (Val(txtDwidthftxt.Text))) * 0.5)
            If DDiameter > 0 Then
                txtDDiameterf.Text = FormatNumber(DDiameter, 4, , , False)
            Else
                txtDDiameterf.Text = ""
            End If

            DDiameter = (((Val(txtDlengthitxt.Text)) + (Val(txtDwidthitxt.Text))) * 0.5)
            If DDiameter > 0 Then
                txtDDiameteri.Text = FormatNumber(DDiameter, 4, , , False)
            Else
                txtDDiameteri.Text = ""
            End If

            DDiameter = (((Val(txtDlengthctxt.Text)) + (Val(txtDwidthctxt.Text))) * 0.5)
            If DDiameter > 0 Then
                txtDDiameterc.Text = FormatNumber(DDiameter, 4, , , False)
            Else
                txtDDiameterc.Text = ""
            End If

            DDiameter = (((Val(txtDlengthmtxt.Text)) + (Val(txtDwidthmtxt.Text))) * 0.5)
            If DDiameter > 0 Then
                txtDDiameterm.Text = FormatNumber(DDiameter, 4, , , False)
            Else
                txtDDiameterm.Text = ""
            End If

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in DrmCalcdiameter", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtDlengthftxt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDlengthftxt.LostFocus

        Try
            Call DrumTotalSize()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in txtDlengthftxt_LostFocus", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtDlengthitxt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDlengthitxt.LostFocus

        Try
            Call DrumTotalSize()
        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in txtDlengthitxt_LostFocus", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtDlengthmtxt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDlengthmtxt.LostFocus

        Try
            Call DrumTotalSize()
        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in txtDlengthmtxt_LostFocus", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtDwidthctxt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDwidthctxt.LostFocus

        Try
            Call DrumTotalSize()
        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in txtDwidthctxt_LostFocus", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtDwidthftxt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDwidthftxt.LostFocus

        Try
            Call DrumTotalSize()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in txtDwidthftxt_LostFocus", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtDwidthitxt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDwidthitxt.LostFocus

        Try
            Call DrumTotalSize()
        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in txtDwidthitxt_LostFocus", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtDwidthmtxt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDwidthmtxt.LostFocus

        Try
            Call DrumTotalSize()
        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in txtDwidthmtxt_LostFocus", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click

        'Stop
        Try
            If DiaFlg = False Then
                Call TotalSize()
            End If

            If DiaFlg = True Then
                Call DTotalSize()
            End If

            Dim strSQL As String
            Dim Comm As SDOleDb.OleDbCommand
            If Trim(txtpackname.Text) = "" Then
                MsgBox("Please enter Pack Name.", MsgBoxStyle.Exclamation, "Carton Master")
                AddEnable()
                txtpackname.Focus()
                Exit Sub
            End If

            If Str = "Add" Then
                '---------Check Duplicate Record
                Dim strId As String
                strId = DFCount("Select Count(PackName) as PackName1  from PackMast where PackName='" & Trim(txtpackname.Text) & "'")
                If strId <> 0 Then
                    MsgBox("Dublicate Pack name should not allow", MsgBoxStyle.Exclamation, "Carton Master")
                    txtpackname.Focus()
                    Exit Sub
                End If
                '--------------------------
                Dim Str1 As String
                Str1 = "Select Max(PackCode) As Pid from PackMast"
                txtpackcode.Text = DGenId(Str1)
                strSQL = "Insert into PackMast(PackCode,PackName,LengthF,LengthI,LengthC,WidthF,WidthI,WidthC,HeightF,HeightI,HeightC,"
                strSQL = strSQL & "PackingMode,Netweight,Grossweight,Totalsize,Factor,HeightM,WidthM,LengthM,TotalsizeF,MaxCont,MaxWeight,ContainerName,ContainerId,FOrient)"
                strSQL = strSQL & "values(" & Val(txtpackcode.Text) & ", '" & Replace(Trim(txtpackname.Text), "'", "`") & "', " & Val(txtDlengthf.Text) & ", " & Val(txtDlengthi.Text) & ","
                strSQL = strSQL & " " & Val(txtDlengthc.Text) & ", " & Val(txtDwidthf.Text) & ", " & Val(txtDwidthi.Text) & ", " & Val(txtDwidthc.Text) & ", " & Val(txtDheightf.Text) & ","
                strSQL = strSQL & " " & Val(txtDheighti.Text) & ", " & Val(txtDheightc.Text) & ", '" & (txtpackingmode.Text) & "', " & Val(txtnetweight.Text) & " , " & Val(txtgrossweight.Text) & ","
                strSQL = strSQL & " " & Val(txttotalsize.Text) & ", " & Val(txtfactor.Text) & ", " & Val(txtDheightm.Text) & ", " & Val(txtDwidthm.Text) & ", " & Val(txtDlengthm.Text) & ","
                strSQL = strSQL & " " & Val(txttotalsizef.Text) & ", " & Val(txtmaxcont.Text) & ", " & Val(txtmaxweight.Text) & ", '" & (cmbcontname.Text) & "', " & Val(TxtCId.Text) & "," & Val(CmbOrient.Text) & ")"

                Comm = New SDOleDb.OleDbCommand(strSQL, connDrums)
                Try
                    If connDrums.State = ConnectionState.Closed Then connDrums.Open()
                    Comm.ExecuteNonQuery()
                    FillDataSet()
                    IntRow = Ds.Tables!Text.Rows.Count - 1
                    TxtBind()
                    connDrums.Close()
                    BFlag = False
                    Call SaveEnable()
                    cmdAdd.Focus()
                    MasterCartonDetails.Enabled = False
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                    Exit Sub
                End Try
            ElseIf Str = "Edit" Then
                strSQL = "Update PackMast set PackName='" & Replace(Trim(txtpackname.Text), "'", "`") & "', LengthF=" & Val(txtDlengthf.Text) & ","
                strSQL = strSQL & " LengthI=" & Val(txtDlengthi.Text) & ", LengthC=" & Val(txtDlengthc.Text) & ", WidthF=" & Val(txtDwidthf.Text) & ","
                strSQL = strSQL & " WidthI=" & Val(txtDwidthi.Text) & ", WidthC=" & Val(txtDwidthc.Text) & ", HeightF=" & Val(txtDheightf.Text) & ","
                strSQL = strSQL & " HeightI=" & Val(txtDheighti.Text) & ", HeightC=" & Val(txtDheightc.Text) & ", PackingMode='" & (txtpackingmode.Text) & "',"
                strSQL = strSQL & " Netweight=" & Val(txtnetweight.Text) & ", Grossweight=" & Val(txtgrossweight.Text) & ", Totalsize=" & Val(txttotalsize.Text) & ","
                strSQL = strSQL & " Factor=" & Val(txtfactor.Text) & ", HeightM=" & Val(txtDheightm.Text) & ", WidthM=" & Val(txtDwidthm.Text) & ", LengthM=" & Val(txtDlengthm.Text) & ","
                strSQL = strSQL & " TotalSizeF=" & Val(txttotalsizef.Text) & ", maxcont=" & Val(txtmaxcont.Text) & ", maxweight=" & Val(txtmaxweight.Text) & ","
                strSQL = strSQL & " ContainerName='" & cmbcontname.Text & "', ContainerId=" & Val(TxtCId.Text) & ",FOrient=" & Val(CmbOrient.Text) & " where PackCode =" & Val(txtpackcode.Text) & ""

                Comm = New SDOleDb.OleDbCommand(strSQL, connDrums)

                Try
                    If connDrums.State = ConnectionState.Closed Then connDrums.Open()
                    Comm.ExecuteNonQuery()
                    FillDataSet()
                    TxtBind()
                    connDrums.Close()
                    BFlag = False
                    Call SaveEnable()
                    cmdAdd.Focus()
                    MasterCartonDetails.Enabled = False

                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                    Exit Sub
                End Try

            End If

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in cmdUpdate_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub RefEnable()

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

    Private Sub cmdRef_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRef.Click

        Dim Comm As New SDOleDb.OleDbCommand 'delete

        Try
            If MsgBox("Are you sure you want to refresh this record?", MsgBoxStyle.YesNo + vbInformation, "Carton Master") = MsgBoxResult.Yes Then

                If Ds.Tables!Text.Rows.Count = 0 Then
                    Call TxtClear()
                    Call NoRecorddisplay()
                    MasterCartonDetails.Enabled = False
                    IntRow = 0
                    BFlag = False
                    cmdAdd.Focus()
                    Exit Sub
                ElseIf IntRow > 0 Or IntRow <= Ds.Tables!Text.Rows.Count - 1 Then
                    RefEnable()
                    IntRow = IntRow
                    TxtClear()
                    TxtBind()
                    BFlag = False
                    cmdAdd.Focus()
                End If
            Else
                txtpackname.Focus()
                Exit Sub
            End If
        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in ", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub RestartApp(ByVal sender As System.Object, ByVal e As System.EventArgs)

        MDIForm.Focus()
        GC.Collect()
        'Stop
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

    End Sub

    Private Sub BoxtypeItem(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Try
            Call cmdExit_Click(sender, e)
            GC.Collect()
            Try

                DisplayActivity.lblDisplayActivity.Visible = True
                DisplayActivity.lblDisplayActivity.Text = "Please wait..." & vbCrLf & "Box type item entry activity show"

                DisplayActivity.Show()
                Me.Dispose(True)

            Catch ex As Exception
                Exit Try
            Finally

                Me.Close()

                MasterCartonEntry.Show()
                MasterCartonEntry.Focus()

            End Try

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in BoxtypeItem", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub MasterCartonDrmEntry_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        DisplayActivity.Close()
        'rdobtnDia.Enabled = False
        rdobtnDia.Visible = False

        Try
            'btnDrumtypeitem.Enabled = False

            txtDDiameterc.Text = ""
            txtDDiameterf.Text = ""
            txtDDiameteri.Text = ""
            txtDDiameterm.Text = ""

            txtDlengthc.Enabled = False
            txtDlengthf.Enabled = False
            txtDlengthi.Enabled = False
            txtDlengthm.Enabled = False

            txtDwidthc.Enabled = False
            txtDwidthf.Enabled = False
            txtDwidthi.Enabled = False
            txtDwidthm.Enabled = False

            DiaFlg = True

            Me.Top = 65 : Me.Left = 130

            BFlag = False

            If connDrums.State = ConnectionState.Closed Then
                connDrums.Open()
            End If

            FillDataSet()

            MasterCartonDetails.Enabled = False
            lblpackcode.Visible = False
            txtpackcode.Visible = False
            cmdUpdate.Enabled = False
            cmdRef.Enabled = False
            txtpackname.Focus()

            Call getContainerName()

            If Ds.Tables!Text.Rows.Count = 0 Then
                Call NoRecorddisplay()
                Call TxtClear()
                Exit Sub
            ElseIf Ds.Tables!Text.Rows.Count - 1 >= 0 Then
                IntRow = Ds.Tables!Text.Rows.Count - 1
                Call TxtBind()
                Call LoadEnable()
            End If

            cmdLast_Click(Nothing, Nothing)

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in MasterCartonDrmEntry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLast.Click

        Try

            If Ds.Tables!Text.Rows.Count - 1 >= 0 Then
                IntRow = Ds.Tables!Text.Rows.Count - 1
                Call TxtBind()
                cmdEdit.Enabled = True
                cmdDel.Enabled = True
            End If

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in cmdLast_Click", "Error......", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub LoadEnable()

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

    Private Sub TxtBind()

        Try
            txtpackcode.Text = IIf(IsDBNull(Ds.Tables!Text.Rows(IntRow).Item("PackCode")), "", Ds.Tables!Text.Rows(IntRow).Item("PackCode"))
            txtpackname.Text = IIf(IsDBNull(Ds.Tables!Text.Rows(IntRow).Item("PackName")), "", Ds.Tables!Text.Rows(IntRow).Item("PackName"))
            txtnetweight.Text = IIf(IsDBNull(Ds.Tables!Text.Rows(IntRow).Item("NetWeight")), "", Ds.Tables!Text.Rows(IntRow).Item("NetWeight"))
            txtgrossweight.Text = IIf(IsDBNull(Ds.Tables!Text.Rows(IntRow).Item("GrossWeight")), "", Ds.Tables!Text.Rows(IntRow).Item("GrossWeight"))
            txtfactor.Text = IIf(IsDBNull(Ds.Tables!Text.Rows(IntRow).Item("Factor")), "", Ds.Tables!Text.Rows(IntRow).Item("Factor"))
            If Val(Ds.Tables!Text.Rows(IntRow).Item("LengthF")) = 0 Then
                txtDlengthf.Text = ""
            Else
                txtDlengthf.Text = Ds.Tables!Text.Rows(IntRow).Item("LengthF")
            End If

            If Val(Ds.Tables!Text.Rows(IntRow).Item("LengthI")) = 0 Then
                txtDlengthi.Text = ""
            Else
                txtDlengthi.Text = Ds.Tables!Text.Rows(IntRow).Item("LengthI")
            End If

            If Val(Ds.Tables!Text.Rows(IntRow).Item("LengthC")) = 0 Then
                txtDlengthc.Text = ""
            Else
                txtDlengthc.Text = Ds.Tables!Text.Rows(IntRow).Item("LengthC")
            End If

            If Val(Ds.Tables!Text.Rows(IntRow).Item("LengthM")) = 0 Then
                txtDlengthm.Text = ""
            Else
                txtDlengthm.Text = Ds.Tables!Text.Rows(IntRow).Item("LengthM")
            End If

            If Val(Ds.Tables!Text.Rows(IntRow).Item("WidthF")) = 0 Then
                txtDwidthf.Text = ""
            Else
                txtDwidthf.Text = Ds.Tables!Text.Rows(IntRow).Item("WidthF")
            End If

            If Val(Ds.Tables!Text.Rows(IntRow).Item("WidthI")) = 0 Then
                txtDwidthi.Text = ""
            Else
                txtDwidthi.Text = Ds.Tables!Text.Rows(IntRow).Item("WidthI")
            End If

            If Val(Ds.Tables!Text.Rows(IntRow).Item("WidthC")) = 0 Then
                txtDwidthc.Text = ""
            Else
                txtDwidthc.Text = Ds.Tables!Text.Rows(IntRow).Item("WidthC")
            End If

            If Val(Ds.Tables!Text.Rows(IntRow).Item("WidthM")) = 0 Then
                txtDwidthm.Text = ""
            Else
                txtDwidthm.Text = Ds.Tables!Text.Rows(IntRow).Item("WidthM")
            End If

            If Val(Ds.Tables!Text.Rows(IntRow).Item("HeightF")) = 0 Then
                txtDheightf.Text = ""
            Else
                txtDheightf.Text = Ds.Tables!Text.Rows(IntRow).Item("HeightF")
            End If

            If Val(Ds.Tables!Text.Rows(IntRow).Item("HeightI")) = 0 Then
                txtDheighti.Text = ""
            Else
                txtDheighti.Text = Ds.Tables!Text.Rows(IntRow).Item("HeightI")
            End If

            If Val(Ds.Tables!Text.Rows(IntRow).Item("HeightC")) = 0 Then
                txtDheightc.Text = ""
            Else
                txtDheightc.Text = Ds.Tables!Text.Rows(IntRow).Item("HeightC")
            End If

            If Val(Ds.Tables!Text.Rows(IntRow).Item("HeightM")) = 0 Then
                txtDheightm.Text = ""
            Else
                txtDheightm.Text = Ds.Tables!Text.Rows(IntRow).Item("HeightM")
            End If

            txttotalsize.Text = IIf(IsDBNull(Ds.Tables!Text.Rows(IntRow).Item("TotalSize")), "", Ds.Tables!Text.Rows(IntRow).Item("TotalSize"))
            If Val(txttotalsize.Text) = 0 Then txttotalsize.Text = ""
            txttotalsizef.Text = IIf(IsDBNull(Ds.Tables!Text.Rows(IntRow).Item("TotalSizeF")), "", Ds.Tables!Text.Rows(IntRow).Item("TotalSizeF"))
            If Val(txttotalsizef.Text) = 0 Then txttotalsizef.Text = ""
            txtpackingmode.Text = IIf(IsDBNull(Ds.Tables!Text.Rows(IntRow).Item("PackingMode")), "", Ds.Tables!Text.Rows(IntRow).Item("PackingMode"))
            If IsDBNull(Ds.Tables!Text.Rows(IntRow).Item("ContainerName")) = True Then
                cmbcontname.SelectedIndex = -1
            Else
                cmbcontname.Text = Ds.Tables!Text.Rows(IntRow).Item("ContainerName")
            End If
            If Trim(cmbcontname.Text) = "" Or IsDBNull(Ds.Tables!Text.Rows(IntRow).Item("FOrient")) = True Then
                CmbOrient.SelectedIndex = -1
            Else
                CmbOrient.Text = Ds.Tables!Text.Rows(IntRow).Item("FOrient")
            End If
            txtmaxcont.Text = IIf(IsDBNull(Ds.Tables!Text.Rows(IntRow).Item("maxcont")), "", Ds.Tables!Text.Rows(IntRow).Item("maxcont"))
            If Val(txtmaxcont.Text) = 0 Then txtmaxcont.Text = ""
            txtmaxweight.Text = IIf(IsDBNull(Ds.Tables!Text.Rows(IntRow).Item("maxweight")), "", Ds.Tables!Text.Rows(IntRow).Item("maxweight"))
            If Val(txtmaxweight.Text) = 0 Then txtmaxweight.Text = ""
            TxtCId.Text = IIf(IsDBNull(Ds.Tables!Text.Rows(IntRow).Item("ContainerId")), "", Ds.Tables!Text.Rows(IntRow).Item("ContainerId"))

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in TxtBind", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub TxtClear()

        txtpackcode.Text = ""
        txtpackname.Text = ""
        txtnetweight.Text = ""
        txtgrossweight.Text = ""
        txtfactor.Text = 6000
        txtDlengthf.Text = ""
        txtDlengthi.Text = ""
        txtDlengthc.Text = ""
        txtDlengthm.Text = ""
        txtDwidthf.Text = ""
        txtDwidthi.Text = ""
        txtDwidthc.Text = ""
        txtDwidthm.Text = ""
        txtDheightf.Text = ""
        txtDheighti.Text = ""
        txtDheightc.Text = ""
        txtDheightm.Text = ""
        txttotalsize.Text = ""
        txttotalsizef.Text = ""
        txtpackingmode.Text = ""
        cmbcontname.SelectedIndex = -1
        CmbOrient.SelectedIndex = -1
        txtmaxcont.Text = ""
        txtmaxweight.Text = ""
        TxtCId.Text = ""

        txtDDiameterc.Text = ""
        txtDDiameterf.Text = ""
        txtDDiameteri.Text = ""
        txtDDiameterm.Text = ""

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

    Private Sub getContainerName()

        Try
            Dim StrSQL As String
            StrSQL = "Select * From ContainerMaster ORDER BY ContainerName"

            If connDrums.State = ConnectionState.Closed Then connDrums.Open()
            Da = New SDOleDb.OleDbDataAdapter(StrSQL, connDrums)

            If Ds.Tables.CanRemove(Ds.Tables("TabCust")) = True Then
                Ds.Tables("TabCust").Rows.Clear()
                Ds.Tables("TabCust").Columns.Clear()
            End If

            Da.Fill(Ds, "TabCust")
            connDrums.Close()
            cmbcontname.DataSource = Nothing
            cmbcontname.DataSource = Ds.Tables("Tabcust").DefaultView
            cmbcontname.DisplayMember = "ContainerName"

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in getContainerName", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub FillDataSet()

        Try
            Dim strSQL As String
            strSQL = "Select * from PackMast"
            Dim Da As New SDOleDb.OleDbDataAdapter(strSQL, connDrums)
            If Ds.Tables.CanRemove(Ds.Tables("Text")) Then
                Ds.Tables("Text").Rows.Clear()
                Ds.Tables("Text").Columns.Clear()
            End If
            Da.Fill(Ds, "Text")
            Da = Nothing
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in FillDataSet", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click

        Try
            TxtClear()
            AddEnable()
            Str = "Add"
            MasterCartonDetails.Enabled = True
            BFlag = True
            txtpackname.Focus()

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in cmdAdd_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub AddEnable()

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
        rdobtnDia.Enabled = True

    End Sub

    Private Sub EditEnable()

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

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click

        Try

            EditEnable()
            Str = "Edit"
            MasterCartonDetails.Enabled = True
            BFlag = True
            txtpackname.Focus()

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in cmdEdit_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDel.Click

        Dim Comm As SDOleDb.OleDbCommand

        If MsgBox("Are you sure you want to delete this Record?", MsgBoxStyle.YesNo + vbCritical, "Carton Master") = MsgBoxResult.Yes Then

            Try
                Comm = New SDOleDb.OleDbCommand("Delete from PackMast where PackCode=" & Val(txtpackcode.Text), connDrums)

                If connDrums.State = ConnectionState.Closed Then connDrums.Open()

                Comm.ExecuteNonQuery()
                Call FillDataSet()
                If Ds.Tables!Text.Rows.Count = 0 Then
                    Call TxtClear()
                    Call NoRecorddisplay()
                    cmdAdd.Focus()
                    Exit Sub
                Else
                    IntRow = Ds.Tables!Text.Rows.Count - 1
                    Call TxtClear()
                    Call TxtBind()
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
                MsgBox(ex.ToString)
                MessageBox.Show("Error in cmdDel_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If

    End Sub

    Private Sub cmdFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFirst.Click

        Try
            If Ds.Tables!Text.Rows.Count - 1 >= 0 Then
                IntRow = 0
                TxtBind()
                cmdEdit.Enabled = True
                cmdDel.Enabled = True
            End If

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in cmdFirst_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrev.Click

        Try
            If IntRow > 0 Then
                IntRow = IntRow - 1
                TxtBind()
            End If
            cmdEdit.Enabled = True
            cmdDel.Enabled = True

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in cmdPrev_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNext.Click

        Try
            If IntRow < Ds.Tables!text.Rows.Count - 1 Then
                IntRow = IntRow + 1
                TxtBind()
            End If
            cmdEdit.Enabled = True
            cmdDel.Enabled = True

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in cmdNext_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFind.Click

        Try
            Me.Top = 50 : Me.Left = 150
            DT = "MasterCartonEntry"
            FindStr = "SELECT * FROM PackMast ORDER BY PackName"
            title = "PackMast"
            frmSearch.ShowDialog()
            Me.ActivateMdiChild(frmSearch)
            frmSearch.Txtsearch.Focus()

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in cmdFind_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdHelp.Click

        Try
            Process.Start(CurDir() & "\HelpContainerStuff\Carton Master.chm")
        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in cmdHelp_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click

        Dim strSQL As String
        Dim Comm As SDOleDb.OleDbCommand

        Try
            If BFlag = True Then
                If MsgBox("Do you want to save this record?", MsgBoxStyle.YesNo + vbExclamation, "Carton Master") = MsgBoxResult.Yes Then
                    If Trim(txtpackname.Text) = "" Then
                        MsgBox("Please enter Pack Name.", MsgBoxStyle.Exclamation, "Carton Master")
                        AddEnable()
                        txtpackname.Focus()
                        Exit Sub
                    End If
                    If Trim(cmbcontname.Text) <> "" Then
                        If Val(CmbOrient.Text) = 0 Then
                            AddEnable()
                            CmbOrient.Focus()
                            Exit Sub
                        End If
                    End If

                    If Str = "Add" Then
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
                        strSQL = strSQL & "values(" & Val(txtpackcode.Text) & ", '" & Replace(Trim(txtpackname.Text), "'", "`") & "', " & Val(txtDlengthf.Text) & ", " & Val(txtDlengthi.Text) & ","
                        strSQL = strSQL & " " & Val(txtDlengthc.Text) & ", " & Val(txtDwidthf.Text) & ", " & Val(txtDwidthi.Text) & ", " & Val(txtDwidthc.Text) & ", " & Val(txtDheightf.Text) & ","
                        strSQL = strSQL & " " & Val(txtDheighti.Text) & ", " & Val(txtDheightc.Text) & ", '" & (txtpackingmode.Text) & "', " & Val(txtnetweight.Text) & " , " & Val(txtgrossweight.Text) & ","
                        strSQL = strSQL & " " & Val(txttotalsize.Text) & ", " & Val(txtfactor.Text) & ", " & Val(txtDheightm.Text) & ", " & Val(txtDwidthm.Text) & ", " & Val(txtDlengthm.Text) & ","
                        strSQL = strSQL & " " & Val(txttotalsizef.Text) & ", " & Val(txtmaxcont.Text) & ", " & Val(txtmaxweight.Text) & ", '" & (cmbcontname.Text) & "', " & Val(TxtCId.Text) & "," & Val(CmbOrient.Text) & ")"

                        Comm = New SDOleDb.OleDbCommand(strSQL, connDrums)

                        Try
                            If connDrums.State = ConnectionState.Closed Then connDrums.Open()
                            Comm.ExecuteNonQuery()
                            FillDataSet()
                            IntRow = Ds.Tables!Text.Rows.Count - 1
                            TxtBind()
                            connDrums.Close()
                            BFlag = False
                            Call SaveEnable()
                            cmdAdd.Focus()
                            MasterCartonDetails.Enabled = False
                            Close()
                        Catch ex As Exception
                            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                            Exit Sub
                        End Try
                    ElseIf Str = "Edit" Then
                        strSQL = "Update PackMast set PackName='" & Replace(Trim(txtpackname.Text), "'", "`") & "', LengthF=" & Val(txtDlengthf.Text) & ","
                        strSQL = strSQL & " LengthI=" & Val(txtDlengthi.Text) & ", LengthC=" & Val(txtDlengthc.Text) & ", WidthF=" & Val(txtDwidthf.Text) & ","
                        strSQL = strSQL & " WidthI=" & Val(txtDwidthi.Text) & ", WidthC=" & Val(txtDwidthc.Text) & ", HeightF=" & Val(txtDheightf.Text) & ","
                        strSQL = strSQL & " HeightI=" & Val(txtDheighti.Text) & ", HeightC=" & Val(txtDheightc.Text) & ", PackingMode='" & (txtpackingmode.Text) & "',"
                        strSQL = strSQL & " Netweight=" & Val(txtnetweight.Text) & ", Grossweight=" & Val(txtgrossweight.Text) & ", Totalsize=" & Val(txttotalsize.Text) & ","
                        strSQL = strSQL & " Factor=" & Val(txtfactor.Text) & ", HeightM=" & Val(txtDheightm.Text) & ", WidthM=" & Val(txtDwidthm.Text) & ", LengthM=" & Val(txtDlengthm.Text) & ","
                        strSQL = strSQL & " TotalSizeF=" & Val(txttotalsizef.Text) & ", maxcont=" & Val(txtmaxcont.Text) & ", maxweight=" & Val(txtmaxweight.Text) & ","
                        strSQL = strSQL & " ContainerName='" & cmbcontname.Text & "', ContainerId=" & Val(TxtCId.Text) & ",FOrient=" & Val(CmbOrient.Text) & " where PackCode =" & Val(txtpackcode.Text) & ""

                        Comm = New SDOleDb.OleDbCommand(strSQL, connDrums)

                        Try
                            If connDrums.State = ConnectionState.Closed Then connDrums.Open()
                            Comm.ExecuteNonQuery()
                            FillDataSet()
                            TxtBind()
                            connDrums.Close()
                            cmdAdd.Focus()
                            BFlag = False
                            Call SaveEnable()
                            MasterCartonDetails.Enabled = False
                            Close()
                        Catch ex As Exception
                            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                            Exit Sub
                        Finally
                            Close()
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
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in cmdExit_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub SaveEnable()

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

    Private Sub txtpackname_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpackname.GotFocus

        Try
            txtpackname.Select(0, 10)
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in txtpackname_GotFocus", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtpackname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtpackname.KeyDown

        Try
            If e.KeyCode = Keys.Enter Then txtnetweight.Focus()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in txtpackname_KeyDown", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtnetweight_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnetweight.GotFocus

        Try
            txtnetweight.Select(0, 10)
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in txtnetweight_GotFocus", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtnetweight_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtnetweight.KeyDown

        Try
            If e.KeyCode = Keys.Enter Then txtgrossweight.Focus()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in txtnetweight_KeyDown", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtgrossweight_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtgrossweight.GotFocus

        Try
            txtgrossweight.Select(0, 10)
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in txtgrossweight_GotFocus", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtgrossweight_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtgrossweight.KeyDown

        Try
            If e.KeyCode = Keys.Enter Then txtfactor.Focus()
        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in txtgrossweight_KeyDown", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtfactor_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtfactor.GotFocus

        Try
            txtfactor.Select(0, 10)
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in txtfactor_GotFocus", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtfactor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtfactor.KeyDown

        Try
            If e.KeyCode = Keys.Enter Then txtDlengthf.Focus()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in txtfactor_KeyDown", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtheightm_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDheightm.GotFocus

        Try
            txtDheightm.Select(0, 10)
        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in txtheightm_GotFocus", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtheightm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDheightm.KeyDown

        Try
            If e.KeyCode = Keys.Enter Then txtpackingmode.Focus()
        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in txtheightm_KeyDown", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtheightm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDheightm.LostFocus

        Try
            If DiaFlg = False Then
                Call TotalSize()
            End If

            If DiaFlg = True Then
                Call DTotalSize()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in txtheightm_LostFocus", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub TotalSize()

        Try
            Dim TotalSizeic As Single

            DTotalLengthsic = (Val(txtDlengthf.Text) * 12) + (Val(txtDlengthi.Text)) + (Val(txtDlengthc.Text) * 0.3937) + (Val(txtDlengthm.Text) * 0.03937) ' 0.0394
            DTotalLengthsic = FormatNumber(DTotalLengthsic, 4, , , False)

            totalwidthic = (Val(txtDwidthf.Text) * 12) + (Val(txtDwidthi.Text)) + (Val(txtDwidthc.Text) * 0.3937) + (Val(txtDwidthm.Text) * 0.03937)
            totalwidthic = FormatNumber(totalwidthic, 4, , , False)

            totalheightic = (Val(txtDheightf.Text) * 12) + (Val(txtDheighti.Text)) + (Val(txtDheightc.Text) * 0.3937) + (Val(txtDheightm.Text) * 0.03937)
            totalheightic = FormatNumber(totalheightic, 4, , , False)

            TotalSizeic = Val(DTotalLengthsic) * Val(totalwidthic) * Val(totalheightic) * 0.785398163   'Pi / 4 = 0.785398163

            totalsizemc = Val(TotalSizeic * 0.000016387064)

            txttotalsize.Text = totalsizemc
            txttotalsize.Text = FormatNumber(totalsizemc, 4, , , False)
            txttotalsizef.Text = Val(txttotalsize.Text) * 35.314
            txttotalsizef.Text = FormatNumber(Val(txttotalsizef.Text), 4, , , False)

            Calcdiameter()

            If Val(txttotalsize.Text) = 0 Then txttotalsize.Text = ""
            If Val(txttotalsizef.Text) = 0 Then txttotalsizef.Text = ""

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in TotalSize", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub Calcdiameter()

        Dim DDiameter As Single

        Try
            DDiameter = (((Val(txtDlengthf.Text)) + (Val(txtDwidthf.Text))) * 0.5)
            If DDiameter > 0 Then
                txtDDiameterf.Text = FormatNumber(DDiameter, 4, , , False)
            Else
                txtDDiameterf.Text = ""
            End If

            DDiameter = (((Val(txtDlengthi.Text)) + (Val(txtDwidthi.Text))) * 0.5)
            If DDiameter > 0 Then
                txtDDiameteri.Text = FormatNumber(DDiameter, 4, , , False)
            Else
                txtDDiameteri.Text = ""
            End If

            DDiameter = (((Val(txtDlengthc.Text)) + (Val(txtDwidthc.Text))) * 0.5)
            If DDiameter > 0 Then
                txtDDiameterc.Text = FormatNumber(DDiameter, 4, , , False)
            Else
                txtDDiameterc.Text = ""
            End If

            DDiameter = (((Val(txtDlengthm.Text)) + (Val(txtDwidthm.Text))) * 0.5)
            If DDiameter > 0 Then
                txtDDiameterm.Text = FormatNumber(DDiameter, 4, , , False)
            Else
                txtDDiameterm.Text = ""
            End If

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in Calcdiameter", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub DTotalSize()

        Try
            DTotalDiameterc = (Val(txtDDiameterf.Text) * 12) + (Val(txtDDiameteri.Text)) + (Val(txtDDiameterc.Text) * 0.3937) + (Val(txtDDiameterm.Text) * 0.03937) ' 0.0394
            DTotalDiameterc = FormatNumber(DTotalDiameterc, 4, , , False)

            totalheightic = (Val(txtDheightf.Text) * 12) + (Val(txtDheighti.Text)) + (Val(txtDheightc.Text) * 0.3937) + (Val(txtDheightm.Text) * 0.03937)
            totalheightic = FormatNumber(totalheightic, 4, , , False)

            totalsizeic = (DTotalDiameterc) * (DTotalDiameterc) * (totalheightic) * 0.785398163   'Pi / 4 = 0.785398163

            totalsizemc = (totalsizeic * 0.000016387064)

            txttotalsize.Text = totalsizemc
            txttotalsize.Text = FormatNumber(totalsizemc, 4, , , False)
            txttotalsizef.Text = Val(txttotalsize.Text) * 35.314
            txttotalsizef.Text = FormatNumber(Val(txttotalsizef.Text), 4, , , False)

            CalcDLDW()
        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in DTotalSize", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub CalcDLDW()

        Try

            If (Val(txtDDiameterf.Text)) > 0 Then
                txtDlengthf.Text = FormatNumber((Val(txtDDiameterf.Text)), 4, , , False)
                txtDwidthf.Text = FormatNumber((Val(txtDDiameterf.Text)), 4, , , False)
            Else
                txtDlengthf.Text = ""
                txtDwidthf.Text = ""
            End If

            If (Val(txtDDiameteri.Text)) > 0 Then
                txtDlengthi.Text = FormatNumber((Val(txtDDiameteri.Text)), 4, , , False)
                txtDwidthi.Text = FormatNumber((Val(txtDDiameteri.Text)), 4, , , False)
            Else
                txtDlengthi.Text = ""
                txtDwidthi.Text = ""
            End If

            If (Val(txtDDiameterc.Text)) > 0 Then
                txtDlengthc.Text = FormatNumber((Val(txtDDiameterc.Text)), 4, , , False)
                txtDwidthc.Text = FormatNumber((Val(txtDDiameterc.Text)), 4, , , False)
            Else
                txtDlengthc.Text = ""
                txtDwidthc.Text = ""
            End If

            If (Val(txtDDiameterm.Text)) > 0 Then
                txtDlengthm.Text = FormatNumber((Val(txtDDiameterm.Text)), 4, , , False)
                txtDwidthm.Text = FormatNumber((Val(txtDDiameterm.Text)), 4, , , False)
            Else
                txtDlengthm.Text = ""
                txtDwidthm.Text = ""
            End If

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in CalcDLDW", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txttotalsize_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txttotalsize.KeyDown

        Try
            If e.KeyCode = Keys.Enter Then txttotalsizef.Focus()
        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in txttotalsize_KeyDown", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txttotalsizef_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txttotalsizef.KeyDown

        Try
            If e.KeyCode = Keys.Enter Then txtpackingmode.Focus()
        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in txttotalsizef_KeyDown", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtpackingmode_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpackingmode.GotFocus

        Try
            txtpackingmode.Select()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in txtpackingmode_GotFocus", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtpackingmode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtpackingmode.KeyDown

        Try
            If e.KeyCode = Keys.Enter Then cmbcontname.Focus()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in txtpackingmode_KeyDown", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtlengthf_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDlengthf.GotFocus

        Try
            txtDlengthf.Select(0, 10)
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in txtlengthf_GotFocus", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtlengthf_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDlengthf.KeyDown

        Try
            If e.KeyCode = Keys.Enter Then txtDwidthf.Focus()
        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in txtlenthf_KeyDown", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtwidthf_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDwidthf.GotFocus

        Try
            txtDwidthf.Select(0, 10)
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in txtwidthf_GotFocus", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtwidthf_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDwidthf.KeyDown

        Try
            If e.KeyCode = Keys.Enter Then txtDheightf.Focus()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in txtwidthf_KeyDown", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtheightf_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDheightf.GotFocus

        Try
            txtDheightf.Select(0, 10)
        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in txtheightf_GotFocus", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtheightf_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDheightf.KeyDown

        Try
            If e.KeyCode = Keys.Enter Then txtDlengthi.Focus()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in txtheightf_KeyDown", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtlengthi_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDlengthi.GotFocus

        Try
            txtDlengthi.Select(0, 10)
        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in txtlengthi_GotFocus", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtlengthi_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDlengthi.KeyDown

        Try
            If e.KeyCode = Keys.Enter Then txtDwidthi.Focus()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in txtlengthi_KeyDown", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtwidthi_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDwidthi.GotFocus

        Try
            txtDwidthi.Select(0, 10)
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in txtwidthi_GotFocus", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtwidthi_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDwidthi.KeyDown

        Try
            If e.KeyCode = Keys.Enter Then txtDheighti.Focus()
        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in txtwidthi_KeyDown", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtheighti_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDheighti.GotFocus

        Try
            txtDheighti.Select(0, 10)
        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in txtheighti_GotFocus", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtheighti_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDheighti.KeyDown

        Try
            If e.KeyCode = Keys.Enter Then txtDlengthc.Focus()
        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in txtheighti_KeyDown", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtlengthc_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDlengthc.GotFocus

        Try
            txtDlengthc.Select(0, 10)
        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in txtlengthc_GotFocus", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtlengthc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDlengthc.KeyDown

        Try
            If e.KeyCode = Keys.Enter Then txtDwidthc.Focus()
        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in txtlengthc_KeyDown", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtwidthc_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDwidthc.GotFocus

        Try
            txtDwidthc.Select(0, 10)
        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in txtwidthc_GotFocus", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtwidthc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDwidthc.KeyDown

        Try
            If e.KeyCode = Keys.Enter Then txtDheightc.Focus()
        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in txtwidthc_KeyDown", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtheightc_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDheightc.GotFocus

        Try
            txtDheightc.Select(0, 10)
        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in txtheightc_GotFocus", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtheightc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDheightc.KeyDown

        Try
            If e.KeyCode = Keys.Enter Then txtDlengthm.Focus()
        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in txtheightc_KeyDown", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtlengthm_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDlengthm.GotFocus

        Try
            txtDlengthm.Select(0, 10)
        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in txtlengthm_GotFocus", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtlengthm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDlengthm.KeyDown

        Try
            If e.KeyCode = Keys.Enter Then txtDwidthm.Focus()
        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in txtlengthm_KeyDown", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtwidthm_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDwidthm.GotFocus

        Try
            txtDwidthm.Select(0, 10)
        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in txtwidthm_GotFocus", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtwidthm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDwidthm.KeyDown

        Try
            If e.KeyCode = Keys.Enter Then txtDheightm.Focus()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in txtwidthm_KeyDown", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmbcontname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbcontname.KeyDown

        Try
            If e.KeyCode = Keys.Enter Then CmbOrient.Focus()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in cmbcontname_KeyDown", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtnetweight_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnetweight.KeyPress

        Try
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
        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in txtnetweight_KeyPress", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmbcontname_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcontname.SelectionChangeCommitted

        Dim FlagMax As Boolean
        Dim MaxPayLoad1 As String

        Try
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
            DTotalLengthsic = Val(Format((cmbcontname.Items(cmbcontname.SelectedIndex)(2) * 12), "0.0000")) + Val(Format((cmbcontname.Items(cmbcontname.SelectedIndex)(5)), "0.0000")) + Val(Format((cmbcontname.Items(cmbcontname.SelectedIndex)(8) / 2.54), "0.0000")) + Val(Format((cmbcontname.Items(cmbcontname.SelectedIndex)(11) / 25.4), "0.0000"))
            totalwidthic = Val(Format((cmbcontname.Items(cmbcontname.SelectedIndex)(3) * 12), "0.0000")) + Val(Format((cmbcontname.Items(cmbcontname.SelectedIndex)(6)), "0.0000")) + Val(Format((cmbcontname.Items(cmbcontname.SelectedIndex)(9) / 2.54), "0.0000")) + Val(Format((cmbcontname.Items(cmbcontname.SelectedIndex)(12) / 25.4), "0.0000"))
            totalheightic = Val(Format((cmbcontname.Items(cmbcontname.SelectedIndex)(4) * 12), "0.0000")) + Val(Format((cmbcontname.Items(cmbcontname.SelectedIndex)(7)), "0.0000")) + Val(Format((cmbcontname.Items(cmbcontname.SelectedIndex)(10) / 2.54), "0.0000")) + Val(Format((cmbcontname.Items(cmbcontname.SelectedIndex)(13) / 25.4), "0.0000"))
            txtmaxcont.Text = CalcMxQty1(DTotalLengthsic, totalwidthic, totalheightic, FlagMax)
        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in cmbcontname_SelectionChangeCommitted", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

#End Region

#Region " Function Definitions "

    Public Function CalcMxQty1(ByVal clength As Single, ByVal cwidth As Single, ByVal cheight As Single, ByVal tpup As Boolean) As Integer

        'Dim ar() As Area
        'Dim ari() As String
        'Dim arwt() As Single
        'Dim ar1 As New Area
        'Dim wt As String = Nothing
        'Dim transparr() As Boolean
        'Dim topup() As Boolean
        'ReDim ar(0)
        'ReDim ari(0)
        'ReDim arwt(0)
        'ReDim transparr(0)
        'ReDim topup(0)
        'Dim cmd As New OleDb.OleDbCommand
        'Dim cnt As Integer = 0
        'Dim lstcol As New List(Of Byte)
        'Dim arc As New Area
        'arc.StrtPt.x = 0
        'arc.StrtPt.y = 0
        'arc.StrtPt.z = 0
        'arc.length = clength
        'arc.width = cwidth
        'arc.height = cheight
        'Dim mm As New Area
        'Dim mm1 As New Area

        'Dim vol1 As Double = 0
        'Dim vol2 As Double = 0
        'Dim maxqty As Integer
        'Dim arx As New List(Of Area)
        'Dim colarr As New List(Of List(Of Byte))
        'mm.length = Val(txtlengthi.Text) + Val(txtlengthf.Text) * 12 + Val(txtlengthc.Text) / 2.54 + Val(txtlengthm.Text) / 25.4
        'mm.width = Val(txtwidthi.Text) + Val(txtwidthf.Text) * 12 + Val(txtwidthc.Text) / 2.54 + Val(txtwidthm.Text) / 25.4
        'mm.height = Val(txtheighti.Text) + Val(txtheightf.Text) * 12 + Val(txtheightc.Text) / 2.54 + Val(txtheightm.Text) / 25.4

        'qtylst.Add(-1)
        'vol1 = mm.length * mm.height * mm.width
        'If vol1 <> 0 Then
        'vol2 = arc.length * arc.width * arc.height
        'maxqty = Fix(vol2 / vol1)

        'ReDim ar(0)
        'ReDim ari(0)
        'For j As Integer = 0 To maxqty - 1
        'ar(UBound(ar)) = New Area
        'ar(UBound(ar)).length = mm.length
        'ar(UBound(ar)).width = mm.width
        'ar(UBound(ar)).height = mm.height
        'ari(UBound(ari)) = ""
        'arwt(UBound(arwt)) = wt
        'transparr(UBound(transparr)) = False
        'topup(UBound(topup)) = tpup
        'colarr.Add(lstcol)
        'ReDim Preserve ar(UBound(ar) + 1)
        'ReDim Preserve ari(UBound(ari) + 1)
        'ReDim Preserve arwt(UBound(arwt) + 1)
        'ReDim Preserve transparr(UBound(transparr) + 1)
        'ReDim Preserve topup(UBound(topup) + 1)
        'Next
        'ReDim Preserve ar(UBound(ar) - 1)
        'ReDim Preserve ari(UBound(ari) - 1)
        'ReDim Preserve arwt(UBound(arwt) - 1)
        'ReDim Preserve transparr(UBound(transparr) - 1)
        'ReDim Preserve topup(UBound(topup) - 1)
        'stk.Clear()
        'stk.Add(arc)
        'itemqty = 0
        'Call Stuff(arc, ar, ari, arwt, False, False, "", False, Nothing, topup, False, False, False, True, colarr)
        'ReDim ar(0)
        'ReDim ari(0)
        'ReDim arwt(0)
        'ReDim transparr(0)
        'ReDim topup(0)

        '         Form8.Close()
        '          stk.Clear()
        '           stk.Add(arc)
        '        Else

        'End If
        ' stk.Clear()
        '  stk.Add(arc)
        '   Return itemqty

    End Function

#End Region

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
   
End Class
