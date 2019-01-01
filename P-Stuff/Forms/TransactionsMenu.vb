
'Program Name: -    TransactionsMenu.vb
'Programmer Name: - Satwadhir B. Pawar Mob No. :- 9323974665
'Company Name:-     Hazel Infotech LTD. Mumbai
'Project Name: -    Sky Stuff Plus (Container Stuffing)
'Date: -            23 Dec 2K8 4.21 PM (Modified Time)

'Tips: - The code is debugging at that particular dimensions, quantity and sequence.
'        you are decide it the logic happen is correct to that way or its are some 
'        different way the understanding to at your best level is the correct logic 
'        of this particular code block.

'Description: - TransactionsMenu is the transaction form which is used to generate the 3D VRML 
'               program showing the isometric view of the drum i.e. cylinder type geometry and
'               also finding particular maximum quantity.
'               Also the orthographic view is generated in word document. There are the
'               simple arrangement and the cross arrangement stuffing position shown.
'               The shuffling activity is also done in this form to place the drum (cylinder) geometry.

#Region " Importing Object "

Imports System.Drawing
Imports SDOleDb = System.Data.OleDb

#End Region

Public NotInheritable Class TransactionsMenu
    Inherits System.Windows.Forms.Form

#Region " Class Declaration "

    Friend WithEvents panel1 As System.Windows.Forms.Panel
    Dim Arc As New CDArea                                   'Container Area store
    Dim Ard As New CDArea

    Dim ItmNms As String
    Dim Str As String

    Dim y1 As Single = 0
    Dim y2 As Single = 0

    Dim BFlag As Boolean
    Dim DircnFlg As Boolean = False
    Dim ShowEmp As Boolean
    Friend DHDStopflg As Boolean = True         'only one time the logic loop runs

    Public ColArr As New List(Of List(Of Byte))

    Dim CDLstmm As New List(Of CDArea)
    Dim CDLst1 As New List(Of CDArea)

    Dim ContArr(2) As Double

    Dim TotVol As Double

    Dim Ds1 As New DataSet
    Dim Da1 As SDOleDb.OleDbDataAdapter
    Private IntRows As Integer               'The row in Grid valu increase and see value

#End Region

#Region " Routine Definition "

    Private Sub ComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)

        'Stop
        Dim Ans As String = Nothing
        Dim MxQtFlg As Boolean = True

        If FlgArngmnt = False Then
            Try
                ChkDimns()      'check Dimensions of drums
            Catch Ex As Exception
                MsgBox(Ex.Message)
                MsgBox(Ex.ToString)
                MessageBox.Show("Error in ShowButton_MouseClick in ChkDimns", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            'Try

            If flgDHD Then
                DrumsToolStripStatusLabel.Text = "The drum diameter and height are different"
                'MsgBox("Drums diameter and height is different !")
                'MsgBox("Application Exit!")
                'Application.Exit()
                GC.Collect()
                GoTo QtySADHD
            Else
                GoTo QtySADHE
            End If
            GC.Collect()

            '*******************************************************************************
            'Drums Simple Arrangement Start
QtySADHE:

            GC.Collect()

            Try
                If FlgArngmnt = False Then

                    DrmRWidx = DgvI.CurrentCell.RowIndex

                    Dim ComboBoxI As ComboBox = CType(sender, ComboBox)

                    If DgvI.CurrentCell.ColumnIndex = 1 Then
                        ItmNms = sender.text
                        DQTpUpI = IIf(DgvI.Item(7, DrmRWidx).Value = "6", False, True)
                    Else
                        ItmNms = DgvI.Item(1, DgvI.CurrentCell.RowIndex).Value
                        DQTpUpI = IIf(sender.text = "6", False, True)
                    End If

                    Dim Cmd As New OleDb.OleDbCommand
                    Dim Rdr As OleDb.OleDbDataReader
                    Dim DLni As Single
                    Dim DWdi As Single
                    Dim DHti As Single

                    Dim Gapi As Double

                    Gapi = Gap(Gapi)

                    Cmd.Connection = connDrums
                    Cmd.CommandText = "select lengthf,widthf,heightf,lengthi,widthi,heighti,lengthc,widthc,heightc,lengthm,widthm,heightm,grossweight,packingmode from packmast where packname ='" & ItmNms & "'"
                    If connDrums.State = ConnectionState.Closed Then connDrums.Open()
                    Rdr = Cmd.ExecuteReader
                    Rdr.Read()

                    Try
                        DLni = Val(Format((Rdr("lengthi") + (12 * Rdr("lengthf")) + (Rdr("lengthc") * 0.3937) + (Rdr("lengthm") * 0.03937)), "0.0000"))
                        DWdi = Val(Format((Rdr("Widthi") + (12 * Rdr("Widthf")) + (Rdr("Widthc") * 0.3937) + (Rdr("Widthm") * 0.03937)), "0.0000"))
                        DHti = Val(Format((Rdr("heighti") + (12 * Rdr("heightf")) + (Rdr("heightc") * 0.3937) + (Rdr("heightm") * 0.03937)), "0.0000"))

                    Catch Ex As Exception
                        MsgBox(Ex.Message)
                        MsgBox(Ex.ToString)
                        MessageBox.Show("Error in Combobox_SelectedIndexChanged", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        'MsgBox(Ex.Message, MsgBoxStyle.Critical, "Error in Combobox_SelectedIndexChanged")
                        Exit Sub
                    End Try

                    If DircnFlg = False Then
                        DWdi = DWdi + Gapi
                    ElseIf DircnFlg = True Then
                        DLni = DLni + Gapi
                    Else
                        DWdi = DWdi
                        DLni = DLni
                    End If

                    Try
                        DgvI.Item(1, DrmRWidx).Value = ItmNms
                        DgvI.Item(4, DrmRWidx).Value = DLni
                        DgvI.Item(5, DrmRWidx).Value = DWdi
                        DgvI.Item(6, DrmRWidx).Value = DHti
                        DgvI.Item(3, DrmRWidx).Value = ((DLni * DWdi * DHti) * 0.7853981633) * 0.000016387064   '/ 61024
                        DgvI.Item(2, DrmRWidx).Value = Rdr("packingmode")
                        DgvI.Item(8, DrmRWidx).Value = Rdr("grossweight")
                    Catch

                    Finally
                        Try
                            Call getAllInwardDetailDiaHt()
                        Catch Er As Exception
                            MsgBox(Er.Message)
                            MessageBox.Show("Error in getAllInwardDetailDiaHt in ComboBox_SelectedIndexChanged", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    End Try
                    Dim Btn As String = btnDirection.Text
                    If Gapi = 0 Then
                        Btn = "X <-----> Y"
                    End If

                    If Not CheckBox1.Checked Then
                        Ans = MsgBox("The gap between two items is : " & Gapi & "   Inches, In " & Btn & " Direction" & Chr(13) & vbCrLf & "Do you want to calculate maximum quantity?", MsgBoxStyle.YesNo, "Estimate Maximum Quantity For Simple Row Column Arrangement ")
                        If Ans = MsgBoxResult.Yes Then

                            CDLst.Clear()
                            CDLst.Add(Arc)

                            Dim OldOpt As Boolean = chkwt

                            Dim ReStr As String = MessageBox.Show("The simple row column arrangement is shown!", "Stuffing Arrangement shown", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                            If ReStr = MsgBoxResult.No Then

                                Exit Sub

                            End If

                            lblArrangement.BackColor = Color.Pink
                            DisplayPicture.btn_DrumDHE.Visible = True
                            DisplayPicture.lblCSPPicDisplay.Refresh()
                            DHSDrums()       'Display photo here
                            MxQtFlg = False          'Double entry avoided

                            SMaxQtyIDrm = SimpleArngmtCalcMxmQty(DrmRWidx, DQTpUpI)

                            chkwt = OldOpt
                            DplclstSA.Clear()

                        Else
                            DircnFlg = False
                            btnDirection.Text = "X ----->"
                        End If
                    End If

                    Rdr.Close()

                    '#################################################################################################
                    'Cross Stuff Arangement is started from here For calculation of Maximum Quantity
                    '#################################################################################################

                    'ElseIf FlgArngmnt = True Then

                    'MsgBox("Cross Arangement is shown")

                    '    RwIdx = dgv1.CurrentCell.RowIndex

                    '    Dim ComboBox1 As ComboBox = CType(sender, ComboBox)

                    '    Dim TpUp1 As Boolean
                    '    If dgv1.CurrentCell.ColumnIndex = 1 Then
                    '        ItmNm = sender.text
                    '        TpUp1 = IIf(dgv1.Item(7, RwIdx).Value = "6", False, True)
                    '    Else
                    '        ItmNm = dgv1.Item(1, dgv1.CurrentCell.RowIndex).Value
                    '        TpUp1 = IIf(sender.text = "6", False, True)
                    '    End If

                    '    Dim Cmd As New OleDb.OleDbCommand
                    '    Dim Rdr As OleDb.OleDbDataReader
                    '    Dim DLni As Single
                    '    Dim DWdi As Single
                    '    Dim DHti As Single

                    '    Dim CMaxQty1 As Integer

                    '    Dim Gapi As Double

                    '    Gapi = Gap(Gapi)

                    '    Cmd.Connection = connDrums
                    '    Cmd.CommandText = "select lengthf,widthf,heightf,lengthi,widthi,heighti,lengthc,widthc,heightc,lengthm,widthm,heightm,grossweight,packingmode from packmast where packname ='" & ItmNm & "'"
                    '    If connDrums.State = ConnectionState.Closed Then connDrums.Open()
                    '    Rdr = Cmd.ExecuteReader
                    '    Rdr.Read()

                    '    Try
                    '        DLni = Val(Format((Rdr("lengthi") + (12 * Rdr("lengthf")) + (Rdr("lengthc") * 0.3937) + (Rdr("lengthm") * 0.03937)), "0.0000"))
                    '        DWdi = Val(Format((Rdr("Widthi") + (12 * Rdr("Widthf")) + (Rdr("Widthc") * 0.3937) + (Rdr("Widthm") * 0.03937)), "0.0000"))
                    '        DHti = Val(Format((Rdr("heighti") + (12 * Rdr("heightf")) + (Rdr("heightc") * 0.3937) + (Rdr("heightm") * 0.03937)), "0.0000"))

                    '    Catch Ex As Exception
                    '        MsgBox(Ex.Message)
                    '        Exit Sub
                    '    End Try

                    '    If DircnFlg = False Then
                    '        DWdi = DWdi + Gapi
                    '    ElseIf DircnFlg = True Then
                    '        DLni = DLni + Gapi
                    '    Else
                    '        DWdi = DWdi
                    '        DLni = DLni
                    '    End If

                    '    dgv1.Item(1, RwIdx).Value = ItmNm
                    '    dgv1.Item(4, RwIdx).Value = DLni
                    '    dgv1.Item(5, RwIdx).Value = DWdi
                    '    dgv1.Item(6, RwIdx).Value = DHti
                    '    dgv1.Item(3, RwIdx).Value = ((DLni * DWdi * DHti) * 0.7853981633) * 0.000016387064   '/ 61024
                    '    dgv1.Item(2, RwIdx).Value = Rdr("packingmode")
                    '    dgv1.Item(8, RwIdx).Value = Rdr("grossweight")

                    '    Dim Btn As String = btnDirection.Text
                    '    If Gapi = 0 Then
                    '        Btn = "X <-----> Y"
                    '    End If

                    '    If Not CheckBox1.Checked Then
                    '        Dim Ans = MsgBox("The gap between two items is : " & Gapi & "   Inches, In " & Btn & " Direction" & Chr(13) & vbCrLf & "Do you want to calculate maximum quantity?", MsgBoxStyle.YesNo, "Estimate Maximum Quantity For Cross Row Column Arrangement ")
                    '        If Ans = MsgBoxResult.Yes Then

                    '            CDLst.Clear()
                    '            CDLst.Add(Arc)

                    '            Dim OldOpt As Boolean = ChkWt

                    '            CMaxQty1 = CrossArngmtCalcMxmQty(RwIdx, TpUp1)

                    '            ChkWt = OldOpt
                    '            PlcLst.Clear()
                    '        Else
                    '            DircnFlg = False
                    '            btnDirection.Text = "X ----->"
                    '        End If
                    '    End If

                    '    Rdr.Close()

                    'Else

                    '    MsgBox("Arrangement is Different", MsgBoxStyle.Information, "Stuff Arrangement")
                End If
                'Stop

            Catch Ex As Exception
                MsgBox(Ex.Message)
                MsgBox(Ex.ToString)
                MessageBox.Show("Error in ComboBox_SelectedIndexChanged", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
                connDrums.Close()
                siSW.Close()
            Finally
                'ChkDimns()      'check Dimensions of drums
            End Try

QtySADHD:

            GC.Collect()

            'Try
            If FlgArngmnt = False AndAlso MxQtFlg Then

                DrmRWidx = DgvI.CurrentCell.RowIndex

                Dim ComboBoxI As ComboBox = CType(sender, ComboBox)

                If DgvI.CurrentCell.ColumnIndex = 1 Then
                    ItmNms = sender.text
                    DQTpUpI = IIf(DgvI.Item(7, DrmRWidx).Value = "6", False, True)
                Else
                    ItmNms = DgvI.Item(1, DgvI.CurrentCell.RowIndex).Value
                    DQTpUpI = IIf(sender.text = "6", False, True)
                End If

                Dim Cmd As New OleDb.OleDbCommand
                Dim Rdr As OleDb.OleDbDataReader
                Dim DLni As Single
                Dim DWdi As Single
                Dim DHti As Single

                Dim Gapi As Double

                Gapi = Gap(Gapi)

                Cmd.Connection = connDrums
                Cmd.CommandText = "select lengthf,widthf,heightf,lengthi,widthi,heighti,lengthc,widthc,heightc,lengthm,widthm,heightm,grossweight,packingmode from packmast where packname ='" & ItmNms & "'"
                If connDrums.State = ConnectionState.Closed Then connDrums.Open()
                Rdr = Cmd.ExecuteReader
                Rdr.Read()

                Try
                    DLni = Val(Format((Rdr("lengthi") + (12 * Rdr("lengthf")) + (Rdr("lengthc") * 0.3937) + (Rdr("lengthm") * 0.03937)), "0.0000"))
                    DWdi = Val(Format((Rdr("Widthi") + (12 * Rdr("Widthf")) + (Rdr("Widthc") * 0.3937) + (Rdr("Widthm") * 0.03937)), "0.0000"))
                    DHti = Val(Format((Rdr("heighti") + (12 * Rdr("heightf")) + (Rdr("heightc") * 0.3937) + (Rdr("heightm") * 0.03937)), "0.0000"))

                Catch Ex As Exception
                    MsgBox(Ex.Message, MsgBoxStyle.Critical, "Error in Combobox_SelectedIndexChanged")
                    Exit Sub
                End Try

                If DircnFlg = False Then
                    DWdi = DWdi + Gapi
                ElseIf DircnFlg = True Then
                    DLni = DLni + Gapi
                Else
                    DWdi = DWdi
                    DLni = DLni
                End If

                Try
                    DgvI.Item(1, DrmRWidx).Value = ItmNms
                    DgvI.Item(4, DrmRWidx).Value = DLni
                    DgvI.Item(5, DrmRWidx).Value = DWdi
                    DgvI.Item(6, DrmRWidx).Value = DHti
                    DgvI.Item(3, DrmRWidx).Value = ((DLni * DWdi * DHti) * 0.7853981633) * 0.000016387064   '/ 61024
                    DgvI.Item(2, DrmRWidx).Value = Rdr("packingmode")
                    DgvI.Item(8, DrmRWidx).Value = Rdr("grossweight")
                Catch

                Finally
                    Try
                        Call getAllInwardDetailDiaHt()
                    Catch Er As Exception
                        MsgBox(Er.Message)
                        MessageBox.Show("Error in getAllInwardDetailDiaHt in ComboBox_SelectedIndexChanged", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End Try
                Dim Btn As String = btnDirection.Text
                If Gapi = 0 Then
                    Btn = "X <-----> Y"
                End If

                'Stop

                If Not CheckBox1.Checked Then
                    'Dim Ans = MsgBox("The gap between two items is : " & Gapi & "   Inches, In " & Btn & " Direction" & Chr(13) & vbCrLf & "Do you want to calculate maximum quantity?", MsgBoxStyle.YesNo, "Estimate Maximum Quantity For Simple Row Column Arrangement ")
                    If Ans = MsgBoxResult.Yes Then

                        'Stop

                        CDLst.Clear()
                        CDLst.Add(Arc)

                        Dim OldOpt As Boolean = chkwt

                        Dim ReStr As String = MessageBox.Show("The simple row column arrangement is shown!", "Stuffing Arrangement shown", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                        If ReStr = MsgBoxResult.No Then

                            Exit Sub

                        End If

                        DisplayPicture.btn_DrumDHE.Visible = True
                        DisplayPicture.lblCSPPicDisplay.Refresh()
                        DHSDrums()       'Display photo here

                        'SMaxQtyIDrm = SimpleArngmtCalcMxmQty(DrmRWidx, DQTpUpI)
                        SMaxQtyIDrm = DrumMxmQty(DrmRWidx, DQTpUpI)
                        chkwt = OldOpt
                        DplclstSA.Clear()

                    Else
                        DircnFlg = False
                        btnDirection.Text = "X ----->"
                    End If
                End If

                Rdr.Close()

            End If

        ElseIf FlgArngmnt = True Then

            MessageBox.Show("Do you want to calculate maximum quantity ?")

        End If

    End Sub

    Private Sub TransactionsMenu_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try

            Me.Cursor = Cursors.WaitCursor
            DisplayActivity.Close()
            ChooseActivity.Close()
            'btnDrumtype.Enabled = False

            GapVisibleF()        'CAOLMdl Impliment procedure for visibility 

            DCANxtDel()     'Drum CA nxt argmt Db clear

            Dim CC As DataGridViewComboBoxColumn

            BFlag = False
            Button1.BackColor = Color.LightYellow
            Button1.ForeColor = Color.DarkRed
            CheckBox1.Checked = False

            If connDrums.State = ConnectionState.Closed Then connDrums.Open()

            dgEmpty.Visible = False
            dgUsage.Visible = False
            Label6.Visible = False
            Label7.Visible = False
            lblStatus.Visible = False
            lblStatusINm.Visible = False
            btnStatus.Visible = False

            Call getContainerName()
            Call getAllReceiptNo()
            Call ItmePackName()

            With DgvI

                .AutoGenerateColumns = False
                .DataSource = Ds1.Tables("TabIDetail")
                .ColumnHeadersDefaultCellStyle.BackColor = Color.FloralWhite
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.Black
                .ColumnHeadersDefaultCellStyle.Font = New Font(DgvI.Font, FontStyle.Bold)
                .ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
                .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
                .ColumnHeadersVisible = True

                .EditMode = DataGridViewEditMode.EditOnEnter
                .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
                .CellBorderStyle = DataGridViewCellBorderStyle.SunkenVertical
                .GridColor = SystemColors.ActiveBorder
                .BackgroundColor = Color.Honeydew
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .MultiSelect = False
                .RowHeadersVisible = False

            End With

            DgvI.AutoGenerateColumns = False

            CC = DgvI.Columns(1)
            CC.DataSource = Ds1.Tables("TabPack").DefaultView
            CC.DisplayMember = "packname"
            CC.ValueMember = "packname"

            Call getAllInwardDetail()

            cmdUpdate.Enabled = False
            cmdRef.Enabled = False
            If Ds1.Tables!TabIHead.Rows.Count = 0 Then
                Call NoRecordDisplay()
                Call TxtClear()
                Exit Sub
            ElseIf Ds1.Tables!TabIHead.Rows.Count - 1 >= 0 Then
                IntRows = Ds1.Tables!TabIHead.Rows.Count - 1
                Call TxtBind()
                Call LoadEnable()
            End If

            Me.Cursor = Cursors.Arrow

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MessageBox.Show("Error in Drum type stuffing form loading TransactionsMenu_Load", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally

            Try

                Call getAllInwardDetailDiaHt()

            Catch Er As Exception
                MsgBox(Er.Message)
                MsgBox(Er.ToString)
                MessageBox.Show("Error in getAllInwardDetailDiaHt in TransactionsMenu_Load", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End Try

    End Sub

    Private Sub getContainerName()      'Getting container Name

        Try
            Dim StrSQL As String
            StrSQL = "Select * From ContainerMaster ORDER BY ContainerName"
            If connDrums.State = ConnectionState.Closed Then connDrums.Open()
            Da1 = New SDOleDb.OleDbDataAdapter(StrSQL, connDrums)
            If Ds1.Tables.CanRemove(Ds1.Tables("TabContainer")) = True Then
                Ds1.Tables("TabContainer").Rows.Clear()
                Ds1.Tables("TabContainer").Columns.Clear()
            End If
            Da1.Fill(Ds1, "TabContainer")
            'conn.close()
            CmbContainer.DataSource = Nothing
            CmbContainer.DataSource = Ds1.Tables("TabContainer").DefaultView
            CmbContainer.DisplayMember = "ContainerName"

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in Getting Container Name getContainerName", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub getAllReceiptNo()

        Try
            Dim MComm As New SDOleDb.OleDbCommand("select distinct receiptno,ReceiptDate,ContainerName from NInwardDetail order by receiptno", connDrums)

            Da1 = New SDOleDb.OleDbDataAdapter(MComm)

            If Ds1.Tables.CanRemove(Ds1.Tables("TabIHead")) = True Then
                Ds1.Tables("TabIHead").Rows.Clear()
                Ds1.Tables("TabIHead").Columns.Clear()
            End If
            Da1.Fill(Ds1, "TabIHead")
            'If conn.State = ConnectionState.Open Then 'conn.close()

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in getAllReceiptNo ", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub ItmePackName()

        Try
            DgvI.AutoGenerateColumns = False

            Dim mPack As SDOleDb.OleDbCommand

            mPack = New SDOleDb.OleDbCommand("select distinct packname from packmast", connDrums)
            Da1 = New SDOleDb.OleDbDataAdapter(mPack)

            If Ds1.Tables.CanRemove(Ds1.Tables("TabPack")) = True Then
                Ds1.Tables("TabPack").Rows.Clear()
                Ds1.Tables("TabPack").Columns.Clear()
            End If
            Da1.Fill(Ds1, "TabPack")

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in ItmePackName", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub getAllInwardDetail()

        Try

            Dim MComm As New SDOleDb.OleDbCommand("select * from NInwardDetail where receiptno=" & Val(TxtRecNo.Text), connDrums)
            Da1 = New SDOleDb.OleDbDataAdapter(MComm)
            If Ds1.Tables.CanRemove(Ds1.Tables("TabIDetail")) = True Then
                Ds1.Tables("TabIDetail").Rows.Clear()
                Ds1.Tables("TabIDetail").Columns.Clear()
            End If

            Da1.Fill(Ds1, "TabIDetail")
            'If conn.State = ConnectionState.Open Then 'conn.close()
            Dim i As Int16
            DgvI.Rows.Clear()
            For i = 0 To Ds1.Tables("TabIDetail").Rows.Count - 1
                DgvI.Rows.Add()
                DgvI.Item(0, i).Value = Ds1.Tables!TabIDetail.Rows(i).Item("SerialNo")
                DgvI.Item(1, i).Value = Ds1.Tables!TabIDetail.Rows(i).Item("ItemName")
                DgvI.Item(2, i).Value = Ds1.Tables!TabIDetail.Rows(i).Item("PackTypeName")
                DgvI.Item(3, i).Value = Ds1.Tables!TabIDetail.Rows(i).Item("Size")
                DgvI.Item(4, i).Value = Ds1.Tables!TabIDetail.Rows(i).Item("Length")
                DgvI.Item(5, i).Value = Ds1.Tables!TabIDetail.Rows(i).Item("Width")
                DgvI.Item(6, i).Value = Ds1.Tables!TabIDetail.Rows(i).Item("Height")
                DgvI.Item(7, i).Value = Ds1.Tables!TabIDetail.Rows(i).Item("Orient")
                DgvI.Item(8, i).Value = Ds1.Tables!TabIDetail.Rows(i).Item("Seq")
                DgvI.Item(10, i).Value = Ds1.Tables!TabIDetail.Rows(i).Item("Maxqty")
                DgvI.Item(11, i).Value = Ds1.Tables!TabIDetail.Rows(i).Item("Quantity")
            Next

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in getAllInwardDetail", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub getAllInwardDetailDiaHt()

        Dim R As Int16
        Dim dL As Double = 0
        Dim dW As Double = 0
        Dim dH As Double = 0
        Dim DiaDrm As Double = 0
        'Dim DCAQty As UInt64 = 0            'Make it public
        Try
            For R = 0 To DgvI.RowCount
                dL = DgvI.Item(4, R).Value()
                dW = DgvI.Item(5, R).Value()
                dH = DgvI.Item(6, R).Value()
                'DCAQty = DgvI.Item(10, R).Value()
                DgvI.Item(16, R).Value() = dH
                DiaDrm = (dL + dW) * 0.5
                DgvI.Item(15, R).Value() = DiaDrm

            Next

        Catch Ex As Exception
            Exit Sub
        End Try

    End Sub

    '   This routine is checking the drum diameter and height are same or different according 
    '   to that the flag is set and is used to stuffing the drum geometry.

    Friend Sub ChkDimns()

        Dim Flg As Boolean = False
        Dim D As Double = 0
        Dim H As Double = 0
        Dim R As Int16

        Try
            For R = 0 To DgvI.RowCount
                D = DgvI.Item(15, R).Value()
                H = DgvI.Item(16, R).Value()

                If D = H Then
                    Flg = True
                Else
                    Flg = False
                    flgDHD = True
                End If
            Next
        Catch Ex As Exception
            Exit Try
        End Try

        If Flg Then
            Exit Sub
        Else
            MessageBox.Show("The diameter and height of drums different " & Chr(13) & vbCrLf & "Application Exit !")
            MsgBox("Application Exit!")
            Application.Exit()
        End If

    End Sub

    Private Sub NoRecordDisplay()

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

    End Sub

    Private Sub TxtClear()

        TxtRecNo.Text = ""
        DtReceipt.Value = Today
        CmbContainer.SelectedIndex = -1
        DgvI.Rows.Clear()
        TxtCapacity.Text = ""
        TxtPayLoad.Text = ""
        TxtOccuCbm.Text = ""
        TxtOccuKgs.Text = ""
        TxtFreeCbm.Text = ""
        TxtFreeKgs.Text = ""
        Label8.Text = ""

    End Sub

    Private Sub TxtBind()

        Try

            TxtRecNo.Text = Ds1.Tables!TabIHead.Rows(IntRows).Item("receiptno")
            DtReceipt.Value = Ds1.Tables!TabIHead.Rows(IntRows).Item("ReceiptDate")
            CmbContainer.Text = Ds1.Tables!TabIHead.Rows(IntRows).Item("ContainerName")
            Call getAllInwardDetail()

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in TxtBind", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            connDrums.Close()
            siSW.Close()
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

    Private Sub dgvI_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DgvI.EditingControlShowing

        On Error Resume Next
        Dim Combo As ComboBox
        Dim TxtBx As TextBox

        If CmbContainer.Text = "" Then
            Exit Sub
        End If

        Combo = CType(e.Control, ComboBox)
        TxtBx = CType(e.Control, TextBox)
        If (Combo IsNot Nothing) Then

            RemoveHandler Combo.DropDownClosed, _
            New EventHandler(AddressOf ComboBox_SelectedIndexChanged)

            AddHandler Combo.DropDownClosed, _
            New EventHandler(AddressOf ComboBox_SelectedIndexChanged)

        End If

    End Sub

    Private Sub txtGapf_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtGapf.GotFocus

        txtGapi.Text = 0.0
        txtGapc.Text = 0.0
        txtGapm.Text = 0.0

    End Sub

    Private Sub txtGapi_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtGapi.GotFocus

        txtGapf.Text = 0.0
        txtGapc.Text = 0.0
        txtGapm.Text = 0.0

    End Sub

    Private Sub txtGapm_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtGapm.GotFocus

        txtGapi.Text = 0.0
        txtGapc.Text = 0.0
        txtGapf.Text = 0.0

    End Sub

    Private Sub txtGapc_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtGapc.GotFocus

        txtGapi.Text = 0.0
        txtGapf.Text = 0.0
        txtGapm.Text = 0.0

    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click

        Dim strSQL As String
        Dim comm As New SDOleDb.OleDbCommand
        Dim maxqty1 As Integer
        Dim qty1 As Integer

        Try
            For i As Integer = 0 To DgvI.RowCount - 2
                If TypeOf (DgvI.Item(11, i).Value) Is DBNull Then
                    MsgBox("Invalid quantity at row " & (i + 1).ToString, MsgBoxStyle.Information + vbOKOnly, "Stuffing Entry")
                    Exit Sub
                Else
                    If Not IsNumeric(DgvI.Item(11, i).Value) Then
                        MsgBox("Invalid quantity at row " & (i + 1).ToString, MsgBoxStyle.Information + vbOKOnly, "Stuffing Entry")
                        Exit Sub
                    End If
                End If
            Next

            If CmbContainer.Text = "" Then
                MsgBox("Please Select Container Name", MsgBoxStyle.Information + vbOKOnly, "Stuffing Entry")
                AddEnable()
                CmbContainer.Focus()
                Exit Sub
            End If

            If connDrums.State = ConnectionState.Closed Then connDrums.Open()

            DgvI.Enabled = False
            ShowButton.Visible = False
            If Str = "Add" Then
                For i As Integer = 0 To DgvI.RowCount - 2
                    maxqty1 = DgvI.Item(10, i).Value
                    qty1 = DgvI.Item(11, i).Value
                    strSQL = "insert into Ninwarddetail values(" & TxtRecNo.Text & ",#" & DtReceipt.Value & "#,'" & CmbContainer.Text & "'," & _
                    DgvI.Item(0, i).Value & ",'" & DgvI.Item(1, i).Value & "','" & DgvI.Item(2, i).Value & "'," & DgvI.Item(3, i).Value & "," & _
                    DgvI.Item(4, i).Value & "," & DgvI.Item(5, i).Value & "," & DgvI.Item(6, i).Value & "," & maxqty1 & "," & qty1 & _
                    "," & DgvI.Item(7, i).Value & "," & DgvI.Item(8, i).Value & ")"
                    comm.Connection = connDrums
                    comm.CommandText = strSQL
                    comm.ExecuteNonQuery()
                Next
                getAllReceiptNo()
                IntRows = Ds1.Tables!TabIHead.Rows.Count - 1
                TxtBind()
                'conn.close()
                BFlag = False
                Call SaveEnable()
                CmbContainer.Enabled = False
                DtReceipt.Enabled = False
                cmdAdd.Focus()

            ElseIf Str = "Edit" Then
                strSQL = "delete from NInwardDetail where receiptno = " & TxtRecNo.Text
                comm.Connection = connDrums
                comm.CommandText = strSQL
                If connDrums.State = ConnectionState.Closed Then connDrums.Open()
                comm.ExecuteNonQuery()
                'conn.close()
                Str = "Add"
                Call cmdUpdate_Click(Nothing, Nothing)
            End If

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in cmdUpdate button cmdUpdate_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            connDrums.Close()
            siSW.Close()
        End Try

    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click

        Try

            If BFlag = True Then

                If MsgBox("Do you want to save this record?", MsgBoxStyle.Information + vbYesNo, "Stuffing Entry") = MsgBoxResult.Yes Then

                    Dim strSQL As String
                    Dim comm As New SDOleDb.OleDbCommand
                    Dim MaxQty1 As Integer
                    Dim Qty1 As Integer
                    For i As Integer = 0 To DgvI.RowCount - 2
                        If TypeOf (DgvI.Item(11, i).Value) Is DBNull Then
                            MsgBox("Invalid quantity at row " & (i + 1).ToString, MsgBoxStyle.Critical + vbOKOnly)
                            Exit Sub
                        Else
                            If Not IsNumeric(DgvI.Item(11, i).Value) Then
                                MsgBox("Invalid quantity at row " & (i + 1).ToString, MsgBoxStyle.Critical + vbOKOnly)
                                Exit Sub
                            End If
                        End If
                    Next

                    If CmbContainer.Text = "" Then
                        MsgBox("Please Select Container Name", MsgBoxStyle.Information + vbOKOnly, "Stuffing Entry")
                        AddEnable()
                        CmbContainer.Focus()
                        Exit Sub
                    End If

                    If connDrums.State = ConnectionState.Closed Then connDrums.Open()

                    If Str = "Add" Then
                        For i As Integer = 0 To DgvI.RowCount - 2
                            MaxQty1 = DgvI.Item(9, i).Value
                            Qty1 = DgvI.Item(11, i).Value
                            strSQL = "insert into Ninwarddetail values(" & TxtRecNo.Text & ",#" & DtReceipt.Value & "#,'" & CmbContainer.Text & "'," & _
                            DgvI.Item(0, i).Value & ",'" & DgvI.Item(1, i).Value & "','" & DgvI.Item(2, i).Value & "'," & DgvI.Item(3, i).Value & "," & _
                            DgvI.Item(4, i).Value & "," & DgvI.Item(5, i).Value & "," & DgvI.Item(6, i).Value & "," & MaxQty1 & "," & Qty1 & _
                            "," & DgvI.Item(7, i).Value & "," & DgvI.Item(8, i).Value & ")"
                            comm.Connection = connDrums
                            comm.CommandText = strSQL
                            comm.ExecuteNonQuery()
                        Next

                        getAllReceiptNo()
                        IntRows = Ds1.Tables!TabIHead.Rows.Count - 1
                        TxtBind()
                        'conn.close()
                        BFlag = False
                        Call SaveEnable()
                        cmdAdd.Focus()
                    ElseIf Str = "Edit" Then
                        strSQL = "delete from NInwardDetail where receiptno = " & TxtRecNo.Text
                        comm.Connection = connDrums
                        comm.CommandText = strSQL
                        If connDrums.State = ConnectionState.Closed Then connDrums.Open()
                        comm.ExecuteNonQuery()
                        'conn.close()
                        Str = "Add"
                        Call cmdUpdate_Click(Nothing, Nothing)
                    End If
                Else
                    Close()
                End If
            Else
                Close()
            End If
            Close()
        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in cmdExit_Click" & vbCrLf & "Data Updating failure!", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            connDrums.Close()
            CDLst.Clear()
            DEventless()
            GC.Collect()
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

    Public Function DGenId(ByVal StrQry As String) As Integer 'maxId +1

        Try
            Dim Cmd As New SDOleDb.OleDbCommand

            With Cmd
                If connDrums.State = ConnectionState.Closed Then
                    connDrums.Open()
                End If

                Cmd.Connection = connDrums
                Cmd.CommandType = CommandType.Text
                Cmd.CommandText = StrQry
                DGenId = Val(Cmd.ExecuteScalar().ToString)
                DGenId = DGenId + 1
            End With

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in DGenId", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click

        Dim StrId As String
        Call TxtClear()
        CmbContainer.Enabled = True
        DtReceipt.Enabled = True
        AddEnable()
        Str = "Add"
        DtReceipt.Focus()

        Try
            StrId = "select max(receiptno) as RId from Ninwarddetail"
            TxtRecNo.Text = DGenId(StrId)
            BFlag = True
            DgvI.Enabled = True
            Button1.Enabled = True
            ShowButton.Visible = False

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in cmdAdd Button cmdAdd_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    End Sub

#End Region

#Region " Function Definition "

    Public Function Gap(ByVal Gapi As Double) As Double

        Try
            If txtGapf.Text > 0 Then

                Gapi = txtGapf.Text * 12

            ElseIf txtGapi.Text > 0 Then

                Gapi = txtGapi.Text

            ElseIf txtGapc.Text > 0 Then

                Gapi = txtGapc.Text * 0.3937

            ElseIf txtGapm.Text > 0 Then

                Gapi = txtGapm.Text * 0.03937

            Else
                Gapi = 0
            End If
        Catch Ex As Exception
            MsgBox(Ex.Message)
            MessageBox.Show("Error in Gap", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return Gapi

    End Function

    Public Function SimpleArngmtCalcMxmQty(ByVal RowNo1 As Integer, ByVal TpUpx As Boolean)

        DItemNoSA = 0
        chkwt = True
        Dim Ar() As CDArea
        Dim Ar1 As New CDArea

        Dim Ari() As String
        Dim ArWt() As Single

        Dim Dln As Double
        Dim Dwd As Double
        Dim Dht As Double
        Dim Dqty As Integer
        Dim Dseq As Integer
        Dim DItmNm1 As String = Nothing
        Dim Dwt As String = Nothing
        Dim TranspArr() As Boolean
        Dim Transp As Boolean
        Dim TopUp() As Boolean
        Dim TpUp As Boolean

        ReDim Ar(0)
        ReDim Ari(0)
        ReDim ArWt(0)
        ReDim TranspArr(0)
        ReDim TopUp(0)

        Dim Cmd As New OleDb.OleDbCommand

        Dim Cnt As Integer = 0
        Dim LstCol As New List(Of Byte)

        Try
            DeleteTable("DTemp1")

            If CmbContainer.Text = "" Then
                MsgBox("Container not selected")
                CmbContainer.Focus()
                Return Nothing
                Exit Function
            End If

            For i As Integer = 0 To RowNo1 - 1
                If DgvI.Item(11, i).Value Is Nothing OrElse Not IsNumeric(DgvI.Item(11, i).Value) OrElse DgvI.Item(11, i).Value.ToString.Contains(".") OrElse CInt(DgvI.Item(11, i).Value) <= 0 Then
                    MsgBox("Invalid quantity at row " & CStr(i + 1))
                    Return Nothing
                    Exit Function
                End If
            Next

            For i As Integer = 0 To RowNo1

                DItmNm1 = DgvI.Item(1, i).Value
                Dln = Math.Round(DgvI.Item(4, i).Value, 4)
                Dwd = Math.Round(DgvI.Item(5, i).Value, 4)
                Dht = Math.Round(DgvI.Item(6, i).Value, 4)
                If i = RowNo1 Then
                    Dqty = 0
                    DgvI.Item(11, i).Value = ""
                Else
                    Dqty = DgvI.Item(11, i).Value
                End If

                Dwt = DgvI.Item(8, i).Value
                Dseq = DgvI.Item(0, i).Value
                Transp = False
                If RowNo1 = 0 Then
                    TpUp = TpUpx
                Else
                    TpUp = IIf(DgvI.Item(7, i).Value = "6", False, True)
                End If

                For j As Integer = 0 To Dqty

                    Ar(UBound(Ar)) = New CDArea
                    Ar(UBound(Ar)).DLengths = Dln
                    Ar(UBound(Ar)).DWidth = Dwd
                    Ar(UBound(Ar)).DHeight = Dht
                    Ari(UBound(Ari)) = DItmNm1
                    ArWt(UBound(ArWt)) = Dwt
                    TranspArr(UBound(TranspArr)) = Transp
                    TopUp(UBound(TopUp)) = TpUp

                    ColArr.Add(LstCol)

                    ReDim Preserve Ar(UBound(Ar) + 1)
                    ReDim Preserve Ari(UBound(Ari) + 1)
                    ReDim Preserve ArWt(UBound(ArWt) + 1)
                    ReDim Preserve TranspArr(UBound(TranspArr) + 1)
                    ReDim Preserve TopUp(UBound(TopUp) + 1)

                Next

                ReDim Preserve Ar(UBound(Ar) - 1)
                ReDim Preserve Ari(UBound(Ari) - 1)
                ReDim Preserve ArWt(UBound(ArWt) - 1)
                ReDim Preserve TranspArr(UBound(TranspArr) - 1)
                ReDim Preserve TopUp(UBound(TopUp) - 1)
                Cnt += 1

            Next i

            stpDrum += 1

            If stpDrum = DgvI.RowCount Then
                stpDrum = 0
                Cnt = 0

            End If

            ReDim Preserve Ar(UBound(Ar) - 1)
            If UBound(Ari) > 0 Then
                ReDim Preserve Ari(UBound(Ari) - 1)
                ReDim Preserve ArWt(UBound(ArWt) - 1)
                ReDim Preserve TranspArr(UBound(TranspArr) - 1)
                ReDim Preserve TopUp(UBound(TopUp) - 1)

            End If

            Arc.DStrtPt.x = 0
            Arc.DStrtPt.y = 0
            Arc.DStrtPt.z = 0

            Arc.DCntPt.X = 0
            Arc.DCntPt.Y = 0
            Arc.DCntPt.Z = 0

            Arc.DLengths = ContArr(0)
            Arc.DWidth = ContArr(1)
            Arc.DHeight = ContArr(2)
            Dqty = 0

            Dim OutFile As String = CurDir() & "\" & "First.wrl" '

            If Ar.Length > 0 Then

                If CDLst.Count = 0 Then CDLst.Add(Arc)
                If Not CheckBox1.Checked Then

                    'Stop
                    CDLst1 = DrumQtStuff(Arc, Ar, Ari, ArWt, False, False, OutFile, False, TranspArr, TopUp, Dtxtopt, False, False, True, ColArr)

                    'Else
                    'stk1 = stuffx(Arc, Ar, Ari, ArWt, True, False, outfile, False, TranspArr, TopUp, txtopt, False, False, True, colarr)
                    'Dim ar3() As Area
                    'Dim ari3() As String
                    'Dim arwt3() As Single
                    'Dim transparr3() As Boolean
                    'Dim topup1() As Boolean

                    'ReDim ar3(0)
                    'ReDim ari3(0)
                    'ReDim arwt3(0)
                    'ReDim transparr3(0)
                    'ReDim topup1(0)
                    'xcnt = xid
                    'For ii As Integer = xid To UBound(Ar)
                    'ar3(UBound(ar3)) = Ar(ii)
                    'ari3(UBound(ari3)) = Ari(ii)
                    'arwt3(UBound(arwt3)) = ArWt(ii)
                    'transparr3(UBound(transparr3)) = TranspArr(ii)
                    'topup1(UBound(topup1)) = True
                    'ReDim Preserve ar3(UBound(ar3) + 1)
                    'ReDim Preserve ari3(UBound(ari3) + 1)
                    'ReDim Preserve arwt3(UBound(arwt3) + 1)
                    'ReDim Preserve transparr3(UBound(transparr3) + 1)
                    'ReDim Preserve topup1(UBound(topup1) + 1)
                    'Next
                    'ReDim Preserve ar3(UBound(ar3) - 1)
                    'ReDim Preserve ari3(UBound(ari3) - 1)
                    'ReDim Preserve arwt3(UBound(arwt3) - 1)
                    'ReDim Preserve transparr3(UBound(transparr3) - 1)
                    'ReDim Preserve topup1(UBound(topup1) - 1)

                    'stk.Clear()

                    'For iu As Integer = 0 To stksav(xid - 1).Count - 1
                    'stk.Add(stksav(xid - 1)(iu))
                    'Next

                    'Dim ar4() As Area
                    'ReDim ar4(0)
                    'For uu As Integer = LBound(ar3) To UBound(ar3)
                    'Dim arr1 As New Area
                    'Dim arr As Area = ar3(uu)
                    'Dim ln4 As Single = arr.length
                    'Dim wd4 As Single = arr.width
                    'Dim ht4 As Single = arr.height
                    'Dim min As String = "l"
                    'Dim min1 As Single = ln4
                    'If wd4 < min1 Then
                    'min1 = wd4
                    'min = "w"
                    'End If

                    'If ht4 < min1 Then
                    'min1 = ht4
                    'min = "h"
                    'End If

                    'arr1.StrtPt.x = arr.StrtPt.x
                    'arr1.StrtPt.y = arr.StrtPt.y
                    'arr1.StrtPt.z = arr.StrtPt.z
                    'arr1.height = min1

                    'If min = "l" Then

                    'arr1.width = arr.width
                    'arr1.length = arr.height

                    'End If

                    'If min = "w" Then
                    'arr1.width = arr.height
                    'arr1.length = arr.length

                    'End If

                    'If min = "h" Then
                    'arr1.length = arr.length
                    'arr1.width = arr.width
                    'End If

                    'ar4(UBound(ar4)) = arr1
                    'ReDim Preserve ar4(UBound(ar4) + 1)

                    'Next
                    'ReDim Preserve ar4(UBound(ar4) - 1)
                    'stuffx(Arc, ar4, ari3, arwt3, True, False, outfile, False, transparr3, topup1, False, False, False, False, colarr)

                End If

                'Plclst.Clear()
                'ReDim Ar(0)
                'ReDim Ari(0)
                'ReDim ArWt(0)
                'ReDim TranspArr(0)
                'ReDim TopUp(0)
                'MsgBox(itemqty)

                'Check here 22 May 2K8 11.30 AM

                DplclstSA.Clear()
                ReDim Ar(0)
                ReDim Ari(0)
                ReDim ArWt(0)
                ReDim TranspArr(0)
                ReDim TopUp(0)
                'MsgBox(DItemQty)
                DisplayPicture.lblCSPPicDisplay.Text = "The Number of Items " & DItemQtySa & " placed."
                DisplayPicture.btn_DrumDHE.Visible = True
                DisplayPicture.lblCSPPicDisplay.Refresh()
                DHSDrums()       'Display photo here
                'DisplayPicture.lblCSPPicDisplay.Text = ""
                'MessageBox.Show("The Number of Items " & DItemQty & " placed", "Maximum Quantity Info.....", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else
                If DgvI.RowCount > 1 Then
                    If Ar.Length <> 0 Then
                        For i As Integer = 0 To DgvI.RowCount - 1
                            For j As Integer = 0 To DgvI.ColumnCount - 1
                                DgvI.Item(j, i).Style.BackColor = Color.White
                            Next
                        Next

                    End If

                End If

            End If

            Dim CDmm As New CDArea
            Dim CDmm1 As New CDArea

            Dim ContVol As Double = 0
            Dim ItmVol As Double = 0
            Dim MaxQty As Integer
            Dim Arx As New List(Of CDArea)

            If RowNo1 > 0 Then
                CDmm.DLengths = Math.Round(DgvI.Item(4, RowNo1).Value, 4)
                CDmm.DWidth = Math.Round(DgvI.Item(5, RowNo1).Value, 4)
                CDmm.DHeight = Math.Round(DgvI.Item(6, RowNo1).Value, 4)
                TpUp = TpUpx
            Else
                CDmm.DLengths = Math.Round(DgvI.Item(4, 0).Value, 4)
                CDmm.DWidth = Math.Round(DgvI.Item(5, 0).Value, 4)
                CDmm.DHeight = Math.Round(DgvI.Item(6, 0).Value, 4)
                TpUp = TpUpx
                DqtylstSA.Add(-1)
            End If

            ItmVol = CDmm.DLengths * CDmm.DHeight * CDmm.DWidth
            If ItmVol <> 0 Then
                ContVol = 0
                For j As Integer = 0 To CDLst.Count - 1
                    CDmm1 = CDLst(j)
                    ContVol = ContVol + (CDmm1.DLengths * CDmm1.DWidth * CDmm1.DHeight)
                Next

                MaxQty = Fix(ContVol / ItmVol)

                ReDim Ar(0)
                ReDim Ari(0)

                For j As Integer = 0 To MaxQty - 1
                    'Stop
                    Ar(UBound(Ar)) = New CDArea
                    Ar(UBound(Ar)).DLengths = CDmm.DLengths
                    Ar(UBound(Ar)).DWidth = CDmm.DWidth
                    Ar(UBound(Ar)).DHeight = CDmm.DHeight
                    Ari(UBound(Ari)) = DItmNm1
                    ArWt(UBound(ArWt)) = Dwt
                    TranspArr(UBound(TranspArr)) = False
                    TopUp(UBound(TopUp)) = TpUp
                    ColArr.Add(LstCol)
                    ReDim Preserve Ar(UBound(Ar) + 1)
                    ReDim Preserve Ari(UBound(Ari) + 1)
                    ReDim Preserve ArWt(UBound(ArWt) + 1)
                    ReDim Preserve TranspArr(UBound(TranspArr) + 1)
                    ReDim Preserve TopUp(UBound(TopUp) + 1)

                Next
                'Stop
                ReDim Preserve Ar(UBound(Ar) - 1)
                ReDim Preserve Ari(UBound(Ari) - 1)
                ReDim Preserve ArWt(UBound(ArWt) - 1)
                ReDim Preserve TranspArr(UBound(TranspArr) - 1)
                ReDim Preserve TopUp(UBound(TopUp) - 1)

                If Not CheckBox1.Checked Then

                    Call DrumQtStuff(Arc, Ar, Ari, ArWt, False, False, "", False, Nothing, TopUp, False, False, False, True, ColArr)

                Else
                    'Call stuffx(Arc, Ar, Ari, ArWt, True, False, "", False, Nothing, TopUp, False, False, False, True, ColArr)
                    If Not fullflag Then
                        Dim Ar3() As CDArea
                        Dim Ari3() As String
                        Dim ArWt3() As Single
                        Dim TranspArr3() As Boolean
                        Dim TopUp1() As Boolean

                        ReDim Ar3(0)
                        ReDim Ari3(0)
                        ReDim ArWt3(0)
                        ReDim TranspArr3(0)
                        ReDim TopUp1(0)

                        xcnt = xid
                        For ii As Integer = xid To UBound(Ar)

                            Ar3(UBound(Ar3)) = Ar(ii)
                            Ari3(UBound(Ari3)) = Ari(ii)
                            ArWt3(UBound(ArWt3)) = ArWt(ii)
                            TranspArr3(UBound(TranspArr3)) = TranspArr(ii)
                            TopUp1(UBound(TopUp1)) = True
                            ReDim Preserve Ar3(UBound(Ar3) + 1)
                            ReDim Preserve Ari3(UBound(Ari3) + 1)
                            ReDim Preserve ArWt3(UBound(ArWt3) + 1)
                            ReDim Preserve TranspArr3(UBound(TranspArr3) + 1)
                            ReDim Preserve TopUp1(UBound(TopUp1) + 1)

                        Next

                        ReDim Preserve Ar3(UBound(Ar3) - 1)
                        ReDim Preserve Ari3(UBound(Ari3) - 1)
                        ReDim Preserve ArWt3(UBound(ArWt3) - 1)
                        ReDim Preserve TranspArr3(UBound(TranspArr3) - 1)
                        ReDim Preserve TopUp1(UBound(TopUp1) - 1)

                        CDLst.Clear()

                        For iu As Integer = 0 To LstSav(xid - 1).Count - 1
                            CDLst.Add(LstSav(xid - 1)(iu))
                        Next

                        Dim Ar4() As CDArea

                        ReDim Ar4(0)

                        For UU As Integer = LBound(Ar3) To UBound(Ar3)

                            Dim Arr1 As New CDArea
                            Dim Arr As CDArea = Ar3(UU)

                            Dim Dln4 As Single = Arr.DLengths
                            Dim Dwd4 As Single = Arr.DWidth
                            Dim Dht4 As Single = Arr.DHeight
                            Dim Dmin As String = "l"
                            Dim Dmin1 As Single = Dln4
                            If Dwd4 < Dmin1 Then
                                Dmin1 = Dwd4
                                Dmin = "w"
                            End If

                            If Dht4 < Dmin1 Then
                                Dmin1 = Dht4
                                Dmin = "h"
                            End If

                            Arr1.DStrtPt.x = Arr.DStrtPt.x
                            Arr1.DStrtPt.y = Arr.DStrtPt.y
                            Arr1.DStrtPt.z = Arr.DStrtPt.z
                            Arr1.DHeight = Dmin1

                            If Dmin = "l" Then
                                Arr1.DWidth = Arr.DWidth
                                Arr1.DLengths = Arr.DHeight
                            End If

                            If Dmin = "w" Then
                                Arr1.DWidth = Arr.DHeight
                                Arr1.DLengths = Arr.DLengths
                            End If

                            If Dmin = "h" Then
                                Arr1.DLengths = Arr.DLengths
                                Arr1.DWidth = Arr.DWidth
                            End If
                            Ar4(UBound(Ar4)) = Arr1
                            ReDim Preserve Ar4(UBound(Ar4) + 1)
                        Next

                        If chkwt Then
                            xcnt1 = xcnt
                        End If
                        ReDim Preserve Ar4(UBound(Ar4) - 1)
                        'stuffx(Arc, ar4, ari3, arwt3, False, False, outfile, False, transparr3, topup1, False, False, False, False, colarr)
                    End If

                End If

                ReDim Ar(0)
                ReDim Ari(0)
                ReDim ArWt(0)
                ReDim TranspArr(0)
                ReDim TopUp(0)

                If CInt(DgvI.Item(10, DgvI.RowCount - 1).Value) > DItemQtySa Then
                    MsgBox("Requested Quantity " & DgvI.Item(11, DgvI.RowCount - 2).Value & " is greater than maximum quatity")
                    DgvI.Item(11, DgvI.RowCount - 1).Value = DItemQtySa
                End If

                If CheckBox1.Checked Then
                    If chkwt Then
                        DItemQtySa = xcnt + DItemQtySa
                        DItemQtySa += 1
                    End If
                End If

                DgvI.Item(10, RowNo1).Value = DItemQtySa
                'Form8.Close()
                lblStatus.Visible = False
                lblStatusINm.Visible = False
                btnStatus.Visible = False
                DItemQtySa = 0
                CDLst.Clear()
                CDLst.Add(Arc)
            Else
                DgvI.AllowUserToAddRows = False
            End If

            CDLst.Clear()
            CDLst.Add(Arc)
            DqtylstSA.Clear()
            chkwt = True

        Catch Er As Exception
            CDLst.Clear()
            CDLst.Add(Arc)
            DqtylstSA.Clear()
            DEventless()
            Me.pbCSPD.Value = 0
            MsgBox(Er.Message)
            MessageBox.Show("Error in SimpleArngmtCalcMxmQty", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return DItemQtySa

    End Function

    Public Function DrumMxmQty(ByVal RowNo1 As Integer, ByVal TpUpx As Boolean)

        DItemNoSA = 0
        chkwt = True
        Dim Ar() As CDArea
        Dim Ar1 As New CDArea

        Dim Ari() As String
        Dim ArWt() As Single

        Dim Dln As Double
        Dim Dwd As Double
        Dim Dht As Double
        Dim Drds As Double
        Dim Dqty As Integer
        Dim Dseq As Integer
        Dim DItmNm1 As String = Nothing
        Dim Dwt As String = Nothing
        Dim TranspArr() As Boolean
        Dim Transp As Boolean
        Dim TopUp() As Boolean
        Dim TpUp As Boolean

        ReDim Ar(0)
        ReDim Ari(0)
        ReDim ArWt(0)
        ReDim TranspArr(0)
        ReDim TopUp(0)

        Dim Cmd As New OleDb.OleDbCommand

        Dim Cnt As Integer = 0
        Dim LstCol As New List(Of Byte)

        Try
            DeleteTable("DTemp1")

            If CmbContainer.Text = "" Then
                MsgBox("Container not selected")
                CmbContainer.Focus()
                Return Nothing
                Exit Function
            End If

            For i As Integer = 0 To RowNo1 - 1
                If DgvI.Item(11, i).Value Is Nothing OrElse Not IsNumeric(DgvI.Item(11, i).Value) OrElse DgvI.Item(11, i).Value.ToString.Contains(".") OrElse CInt(DgvI.Item(11, i).Value) <= 0 Then
                    MsgBox("Invalid quantity at row " & CStr(i + 1))
                    Return Nothing
                    Exit Function
                End If
            Next

            For i As Integer = 0 To RowNo1

                DItmNm1 = DgvI.Item(1, i).Value
                Dln = Math.Round(DgvI.Item(4, i).Value, 5)
                Dwd = Math.Round(DgvI.Item(5, i).Value, 5)
                Dht = Math.Round(DgvI.Item(6, i).Value, 5)
                Drds = (Dln + Dwd) * 0.25
                'Stop
                If i = RowNo1 Then
                    Dqty = 0
                    DgvI.Item(11, i).Value = ""
                Else
                    Dqty = DgvI.Item(11, i).Value
                End If

                Dwt = DgvI.Item(8, i).Value
                Dseq = DgvI.Item(0, i).Value
                Transp = False
                If RowNo1 = 0 Then
                    TpUp = TpUpx
                Else
                    TpUp = IIf(DgvI.Item(7, i).Value = "6", False, True)
                End If

                For j As Integer = 0 To Dqty

                    Ar(UBound(Ar)) = New CDArea
                    Ar(UBound(Ar)).DLengths = Dln
                    Ar(UBound(Ar)).DWidth = Dwd
                    Ar(UBound(Ar)).DHeight = Dht
                    Ar(UBound(Ar)).DRadius = Drds
                    Ari(UBound(Ari)) = DItmNm1
                    ArWt(UBound(ArWt)) = Dwt
                    TranspArr(UBound(TranspArr)) = Transp
                    TopUp(UBound(TopUp)) = TpUp

                    ColArr.Add(LstCol)

                    ReDim Preserve Ar(UBound(Ar) + 1)
                    ReDim Preserve Ari(UBound(Ari) + 1)
                    ReDim Preserve ArWt(UBound(ArWt) + 1)
                    ReDim Preserve TranspArr(UBound(TranspArr) + 1)
                    ReDim Preserve TopUp(UBound(TopUp) + 1)

                Next

                ReDim Preserve Ar(UBound(Ar) - 1)
                ReDim Preserve Ari(UBound(Ari) - 1)
                ReDim Preserve ArWt(UBound(ArWt) - 1)
                ReDim Preserve TranspArr(UBound(TranspArr) - 1)
                ReDim Preserve TopUp(UBound(TopUp) - 1)
                Cnt += 1

            Next i

            stpDrum += 1

            If stpDrum = DgvI.RowCount Then
                stpDrum = 0
                Cnt = 0

            End If

            ReDim Preserve Ar(UBound(Ar) - 1)
            If UBound(Ari) > 0 Then
                ReDim Preserve Ari(UBound(Ari) - 1)
                ReDim Preserve ArWt(UBound(ArWt) - 1)
                ReDim Preserve TranspArr(UBound(TranspArr) - 1)
                ReDim Preserve TopUp(UBound(TopUp) - 1)

            End If

            Arc.DStrtPt.x = 0
            Arc.DStrtPt.y = 0
            Arc.DStrtPt.z = 0

            Arc.DCntPt.X = 0
            Arc.DCntPt.Y = 0
            Arc.DCntPt.Z = 0

            Arc.DLengths = ContArr(0)
            Arc.DWidth = ContArr(1)
            Arc.DHeight = ContArr(2)
            Dqty = 0
            'Stop
            Dim OutFile As String = CurDir() & "\" & "First.wrl" '

            If Ar.Length > 0 Then

                If CDLst.Count = 0 Then CDLst.Add(Arc)
                If Not CheckBox1.Checked Then

                    'Stop
                    CDLst1 = DrumStuffQt(Arc, Ar, Ari, ArWt, False, False, OutFile, False, TranspArr, TopUp, Dtxtopt, False, False, True, ColArr)

                    'Else
                    'stk1 = stuffx(Arc, Ar, Ari, ArWt, True, False, outfile, False, TranspArr, TopUp, txtopt, False, False, True, colarr)
                    'Dim ar3() As Area
                    'Dim ari3() As String
                    'Dim arwt3() As Single
                    'Dim transparr3() As Boolean
                    'Dim topup1() As Boolean

                    'ReDim ar3(0)
                    'ReDim ari3(0)
                    'ReDim arwt3(0)
                    'ReDim transparr3(0)
                    'ReDim topup1(0)
                    'xcnt = xid
                    'For ii As Integer = xid To UBound(Ar)
                    'ar3(UBound(ar3)) = Ar(ii)
                    'ari3(UBound(ari3)) = Ari(ii)
                    'arwt3(UBound(arwt3)) = ArWt(ii)
                    'transparr3(UBound(transparr3)) = TranspArr(ii)
                    'topup1(UBound(topup1)) = True
                    'ReDim Preserve ar3(UBound(ar3) + 1)
                    'ReDim Preserve ari3(UBound(ari3) + 1)
                    'ReDim Preserve arwt3(UBound(arwt3) + 1)
                    'ReDim Preserve transparr3(UBound(transparr3) + 1)
                    'ReDim Preserve topup1(UBound(topup1) + 1)
                    'Next
                    'ReDim Preserve ar3(UBound(ar3) - 1)
                    'ReDim Preserve ari3(UBound(ari3) - 1)
                    'ReDim Preserve arwt3(UBound(arwt3) - 1)
                    'ReDim Preserve transparr3(UBound(transparr3) - 1)
                    'ReDim Preserve topup1(UBound(topup1) - 1)

                    'stk.Clear()

                    'For iu As Integer = 0 To stksav(xid - 1).Count - 1
                    'stk.Add(stksav(xid - 1)(iu))
                    'Next

                    'Dim ar4() As Area
                    'ReDim ar4(0)
                    'For uu As Integer = LBound(ar3) To UBound(ar3)
                    'Dim arr1 As New Area
                    'Dim arr As Area = ar3(uu)
                    'Dim ln4 As Single = arr.length
                    'Dim wd4 As Single = arr.width
                    'Dim ht4 As Single = arr.height
                    'Dim min As String = "l"
                    'Dim min1 As Single = ln4
                    'If wd4 < min1 Then
                    'min1 = wd4
                    'min = "w"
                    'End If

                    'If ht4 < min1 Then
                    'min1 = ht4
                    'min = "h"
                    'End If

                    'arr1.StrtPt.x = arr.StrtPt.x
                    'arr1.StrtPt.y = arr.StrtPt.y
                    'arr1.StrtPt.z = arr.StrtPt.z
                    'arr1.height = min1

                    'If min = "l" Then

                    'arr1.width = arr.width
                    'arr1.length = arr.height

                    'End If

                    'If min = "w" Then
                    'arr1.width = arr.height
                    'arr1.length = arr.length

                    'End If

                    'If min = "h" Then
                    'arr1.length = arr.length
                    'arr1.width = arr.width
                    'End If

                    'ar4(UBound(ar4)) = arr1
                    'ReDim Preserve ar4(UBound(ar4) + 1)

                    'Next
                    'ReDim Preserve ar4(UBound(ar4) - 1)
                    'stuffx(Arc, ar4, ari3, arwt3, True, False, outfile, False, transparr3, topup1, False, False, False, False, colarr)

                End If

                'Plclst.Clear()
                'ReDim Ar(0)
                'ReDim Ari(0)
                'ReDim ArWt(0)
                'ReDim TranspArr(0)
                'ReDim TopUp(0)
                'MsgBox(itemqty)

                'Check here 22 May 2K8 11.30 AM

                DplclstSA.Clear()
                ReDim Ar(0)
                ReDim Ari(0)
                ReDim ArWt(0)
                ReDim TranspArr(0)
                ReDim TopUp(0)
                'MsgBox(DItemQty)
                DisplayPicture.lblCSPPicDisplay.Text = "The Number of Items " & DItemQtySa & " placed."
                DisplayPicture.btn_DrumDHE.Visible = True
                DisplayPicture.lblCSPPicDisplay.Refresh()
                DHSDrums()       'Display photo here
                'DisplayPicture.lblCSPPicDisplay.Text = ""
                'MessageBox.Show("The Number of Items " & DItemQty & " placed", "Maximum Quantity Info.....", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else
                If DgvI.RowCount > 1 Then
                    If Ar.Length <> 0 Then
                        For i As Integer = 0 To DgvI.RowCount - 1
                            For j As Integer = 0 To DgvI.ColumnCount - 1
                                DgvI.Item(j, i).Style.BackColor = Color.White
                            Next
                        Next

                    End If

                End If

            End If

            Dim CDmm As New CDArea
            Dim CDmm1 As New CDArea

            Dim ContVol As Double = 0
            Dim ItmVol As Double = 0
            Dim MaxQty As Integer
            Dim Arx As New List(Of CDArea)

            If RowNo1 > 0 Then
                CDmm.DLengths = Math.Round(DgvI.Item(4, RowNo1).Value, 4)
                CDmm.DWidth = Math.Round(DgvI.Item(5, RowNo1).Value, 4)
                CDmm.DHeight = Math.Round(DgvI.Item(6, RowNo1).Value, 4)
                TpUp = TpUpx
            Else
                CDmm.DLengths = Math.Round(DgvI.Item(4, 0).Value, 4)
                CDmm.DWidth = Math.Round(DgvI.Item(5, 0).Value, 4)
                CDmm.DHeight = Math.Round(DgvI.Item(6, 0).Value, 4)
                TpUp = TpUpx
                DqtylstSA.Add(-1)
            End If

            ItmVol = CDmm.DLengths * CDmm.DHeight * CDmm.DWidth
            If ItmVol <> 0 Then
                ContVol = 0
                For j As Integer = 0 To CDLst.Count - 1
                    CDmm1 = CDLst(j)
                    ContVol = ContVol + (CDmm1.DLengths * CDmm1.DWidth * CDmm1.DHeight)
                Next

                MaxQty = Fix(ContVol / ItmVol)

                ReDim Ar(0)
                ReDim Ari(0)

                For j As Integer = 0 To MaxQty - 1
                    'Stop
                    Ar(UBound(Ar)) = New CDArea
                    Ar(UBound(Ar)).DLengths = CDmm.DLengths
                    Ar(UBound(Ar)).DWidth = CDmm.DWidth
                    Ar(UBound(Ar)).DHeight = CDmm.DHeight
                    Ar(UBound(Ar)).DRadius = Drds
                    Ari(UBound(Ari)) = DItmNm1
                    ArWt(UBound(ArWt)) = Dwt
                    TranspArr(UBound(TranspArr)) = False
                    TopUp(UBound(TopUp)) = TpUp
                    ColArr.Add(LstCol)
                    ReDim Preserve Ar(UBound(Ar) + 1)
                    ReDim Preserve Ari(UBound(Ari) + 1)
                    ReDim Preserve ArWt(UBound(ArWt) + 1)
                    ReDim Preserve TranspArr(UBound(TranspArr) + 1)
                    ReDim Preserve TopUp(UBound(TopUp) + 1)

                Next
                'Stop
                ReDim Preserve Ar(UBound(Ar) - 1)
                ReDim Preserve Ari(UBound(Ari) - 1)
                ReDim Preserve ArWt(UBound(ArWt) - 1)
                ReDim Preserve TranspArr(UBound(TranspArr) - 1)
                ReDim Preserve TopUp(UBound(TopUp) - 1)

                If Not CheckBox1.Checked Then

                    Call DrumStuffQt(Arc, Ar, Ari, ArWt, False, False, "", False, Nothing, TopUp, False, False, False, True, ColArr)

                Else
                    'Call stuffx(Arc, Ar, Ari, ArWt, True, False, "", False, Nothing, TopUp, False, False, False, True, ColArr)
                    If Not fullflag Then
                        Dim Ar3() As CDArea
                        Dim Ari3() As String
                        Dim ArWt3() As Single
                        Dim TranspArr3() As Boolean
                        Dim TopUp1() As Boolean

                        ReDim Ar3(0)
                        ReDim Ari3(0)
                        ReDim ArWt3(0)
                        ReDim TranspArr3(0)
                        ReDim TopUp1(0)

                        xcnt = xid
                        For ii As Integer = xid To UBound(Ar)

                            Ar3(UBound(Ar3)) = Ar(ii)
                            Ari3(UBound(Ari3)) = Ari(ii)
                            ArWt3(UBound(ArWt3)) = ArWt(ii)
                            TranspArr3(UBound(TranspArr3)) = TranspArr(ii)
                            TopUp1(UBound(TopUp1)) = True
                            ReDim Preserve Ar3(UBound(Ar3) + 1)
                            ReDim Preserve Ari3(UBound(Ari3) + 1)
                            ReDim Preserve ArWt3(UBound(ArWt3) + 1)
                            ReDim Preserve TranspArr3(UBound(TranspArr3) + 1)
                            ReDim Preserve TopUp1(UBound(TopUp1) + 1)

                        Next

                        ReDim Preserve Ar3(UBound(Ar3) - 1)
                        ReDim Preserve Ari3(UBound(Ari3) - 1)
                        ReDim Preserve ArWt3(UBound(ArWt3) - 1)
                        ReDim Preserve TranspArr3(UBound(TranspArr3) - 1)
                        ReDim Preserve TopUp1(UBound(TopUp1) - 1)

                        CDLst.Clear()

                        For iu As Integer = 0 To LstSav(xid - 1).Count - 1
                            CDLst.Add(LstSav(xid - 1)(iu))
                        Next

                        Dim Ar4() As CDArea

                        ReDim Ar4(0)

                        For UU As Integer = LBound(Ar3) To UBound(Ar3)

                            Dim Arr1 As New CDArea
                            Dim Arr As CDArea = Ar3(UU)

                            Dim Dln4 As Single = Arr.DLengths
                            Dim Dwd4 As Single = Arr.DWidth
                            Dim Dht4 As Single = Arr.DHeight
                            Dim Dmin As String = "l"
                            Dim Dmin1 As Single = Dln4
                            If Dwd4 < Dmin1 Then
                                Dmin1 = Dwd4
                                Dmin = "w"
                            End If

                            If Dht4 < Dmin1 Then
                                Dmin1 = Dht4
                                Dmin = "h"
                            End If

                            Arr1.DStrtPt.x = Arr.DStrtPt.x
                            Arr1.DStrtPt.y = Arr.DStrtPt.y
                            Arr1.DStrtPt.z = Arr.DStrtPt.z
                            Arr1.DHeight = Dmin1

                            If Dmin = "l" Then
                                Arr1.DWidth = Arr.DWidth
                                Arr1.DLengths = Arr.DHeight
                            End If

                            If Dmin = "w" Then
                                Arr1.DWidth = Arr.DHeight
                                Arr1.DLengths = Arr.DLengths
                            End If

                            If Dmin = "h" Then
                                Arr1.DLengths = Arr.DLengths
                                Arr1.DWidth = Arr.DWidth
                            End If
                            Ar4(UBound(Ar4)) = Arr1
                            ReDim Preserve Ar4(UBound(Ar4) + 1)
                        Next

                        If chkwt Then
                            xcnt1 = xcnt
                        End If
                        ReDim Preserve Ar4(UBound(Ar4) - 1)
                        'stuffx(Arc, ar4, ari3, arwt3, False, False, outfile, False, transparr3, topup1, False, False, False, False, colarr)
                    End If

                End If

                ReDim Ar(0)
                ReDim Ari(0)
                ReDim ArWt(0)
                ReDim TranspArr(0)
                ReDim TopUp(0)

                If CInt(DgvI.Item(10, DgvI.RowCount - 1).Value) > DItemQtySa Then
                    MsgBox("Requested Quantity " & DgvI.Item(11, DgvI.RowCount - 2).Value & " is greater than maximum quatity")
                    DgvI.Item(11, DgvI.RowCount - 1).Value = DItemQtySa
                End If

                If CheckBox1.Checked Then
                    If chkwt Then
                        DItemQtySa = xcnt + DItemQtySa
                        DItemQtySa += 1
                    End If
                End If

                DgvI.Item(10, RowNo1).Value = DItemQtySa
                'Form8.Close()
                lblStatus.Visible = False
                lblStatusINm.Visible = False
                btnStatus.Visible = False
                DItemQtySa = 0
                CDLst.Clear()
                CDLst.Add(Arc)
            Else
                DgvI.AllowUserToAddRows = False
            End If

            CDLst.Clear()
            CDLst.Add(Arc)
            DqtylstSA.Clear()
            chkwt = True

        Catch Er As Exception
            CDLst.Clear()
            CDLst.Add(Arc)
            DqtylstSA.Clear()
            DEventless()
            Me.pbCSPD.Value = 0
            MsgBox(Er.Message)
            MessageBox.Show("Error in SimpleArngmtCalcMxmQty", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return DItemQtySa

    End Function

    Public Function CheckOneRowGrid()

        Try
            If DgvI.RowCount = 2 Then

                CAFRA = True

            End If
        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in CheckOneRowGrid", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return CAFRA

    End Function

    Public Function UserQtyAllot()
        'DDStop
        'Dim Rg As Integer = 0
        Dim Qt As UInt64

        Try
            Try

                For Rg = 0 To DgvI.RowCount - 2

                    Qt = DgvI.Item(11, Rg).Value()
                    LCAQty.Add(Qt)

                Next
            Catch ex As Exception
                Exit Try
            End Try

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in UserQtyAllot", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try

        Return LCAQty

    End Function

#End Region

#Region " Procedure Definition "

    Private Sub dgvI_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvI.CellClick

        Try
            Button1.Enabled = False
            If e.ColumnIndex = 12 Or e.ColumnIndex = 13 Then
                If DgvI.Item(1, e.RowIndex).Value = "" Then
                    MsgBox("Invalid quantity at row " & (e.RowIndex + 1).ToString, MsgBoxStyle.Critical + vbOKOnly)

                    ShowButton.Visible = False
                    showbutton1.Visible = False
                    Exit Sub
                Else
                    Dim x As Integer
                    Dim coli As Integer = e.ColumnIndex
                    Dim rowi As Integer = e.RowIndex
                    For i As Integer = 0 To coli - 1
                        If DgvI.Columns(i).Visible Then
                            x += DgvI.Columns(i).Width
                        End If
                    Next
                    Dim y As Integer
                    For i As Integer = 0 To rowi
                        y += DgvI.Rows(i).Height

                    Next

                    Dim wd As Integer = DgvI.Columns(e.ColumnIndex).Width
                    Dim ht As Integer = DgvI.Rows(e.RowIndex).Height

                    ShowButton.Top = DgvI.Location.Y - 2 + y + y2
                    ShowButton.Left = DgvI.Location.X + 1 + x
                    ShowButton.Width = wd
                    ShowButton.Height = ht
                    ShowButton.Visible = True
                    showbutton1.Visible = False
                    ShowButton.Text = "Show"
                    ShowButton.BringToFront()

                End If

            Else
                ShowButton.Visible = False
                showbutton1.Visible = False
            End If

            If e.ColumnIndex = 14 Then
                If DgvI.Item(1, e.RowIndex).Value = "" Then
                    MsgBox("Invalid quantity at row " & (e.RowIndex + 1).ToString, MsgBoxStyle.Critical + vbOKOnly)
                    showbutton1.Visible = False
                    ShowButton.Visible = False
                    Exit Sub
                Else
                    Dim x As Integer
                    Dim coli As Integer = e.ColumnIndex
                    Dim rowi As Integer = e.RowIndex
                    For i As Integer = 0 To coli - 1
                        If DgvI.Columns(i).Visible Then
                            x += DgvI.Columns(i).Width
                        End If
                    Next
                    Dim y As Integer
                    For i As Integer = 0 To rowi
                        y += DgvI.Rows(i).Height

                    Next
                    Dim wd As Integer = DgvI.Columns(e.ColumnIndex).Width
                    Dim ht As Integer = DgvI.Rows(e.RowIndex).Height

                    showbutton1.Top = DgvI.Location.Y - 2 + y + y2
                    showbutton1.Left = DgvI.Location.X + 1 + x
                    showbutton1.Width = wd
                    showbutton1.Height = ht
                    showbutton1.Visible = True
                    ShowButton.Visible = False
                    showbutton1.Text = "Show"
                    showbutton1.BringToFront()
                End If

            End If
        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in dgvI_CellClick", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click

        EditEnable()
        CmbContainer.Enabled = True
        DtReceipt.Enabled = True
        Str = "Edit"

        DtReceipt.Focus()
        BFlag = True

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

    Private Sub cmdDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDel.Click

        Dim Comm As New SDOleDb.OleDbCommand 'delete

        If MsgBox("Are you sure you want to delete this Record?", MsgBoxStyle.YesNo + vbCritical, "Inward Entry") = MsgBoxResult.Yes Then

            Try
                Comm = New SDOleDb.OleDbCommand("Delete from NInwardDetail where ReceiptNo=" & Val(TxtRecNo.Text), connDrums)
                If connDrums.State = ConnectionState.Closed Then connDrums.Open()

                Comm.ExecuteNonQuery()

                Call getAllReceiptNo()

                If Ds1.Tables!TabIHead.Rows.Count = 0 Then
                    Call TxtClear()
                    Call NoRecordDisplay()
                    cmdAdd.Focus()
                    Exit Sub
                Else
                    IntRows = Ds1.Tables!TabIHead.Rows.Count - 1
                    Call TxtClear()
                    Call TxtBind()
                End If

            Catch Ex As Exception
                MsgBox(Ex.Message)
                MsgBox(Ex.ToString)
                MessageBox.Show("Error in cmdDel_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
                connDrums.Close()
            End Try

        End If

    End Sub

    Private Sub cmdFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFirst.Click
        'Stop
        Try
            If Ds1.Tables!TabIHead.Rows.Count - 1 >= 0 Then
                IntRows = 0
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
            If IntRows > 0 Then
                IntRows = IntRows - 1
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
            If IntRows < Ds1.Tables!TabIHead.Rows.Count - 1 Then
                IntRows = IntRows + 1
                TxtBind()
            End If
            cmdEdit.Enabled = True
            cmdDel.Enabled = True
        Catch Ex As Exception
            connDrums.Close()
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in cmdNext_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLast.Click

        Try
            If Ds1.Tables!TabIHead.Rows.Count - 1 >= 0 Then
                IntRows = Ds1.Tables!TabIHead.Rows.Count - 1
                Call TxtBind()
                cmdEdit.Enabled = True
                cmdDel.Enabled = True
            End If
        Catch Ex As Exception
            connDrums.Close()
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in cmdLast_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFind.Click

        Try
            DT = "NInwardDetail"
            FindStr = "Select distinct ReceiptNo,ReceiptDate,ContainerName FROM NInwardDetail ORDER BY ReceiptNo"
            title = "InwardEntry"
            frmSearch.ShowDialog()
            Me.ActivateMdiChild(frmSearch)
            frmSearch.Txtsearch.Focus()
        Catch Ex As Exception
            connDrums.Close()
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in cmdFind_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub dgvI_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DgvI.RowsAdded

        Dim clm As DataGridViewComboBoxCell

        Try
            clm = DgvI.Item(7, e.RowIndex)
            clm.Items.AddRange(New Object() {"6", "2"})
            clm.Value = "6"

            DgvI.Item(0, e.RowIndex).Value = e.RowIndex + 1
            DgvI.Item(3, e.RowIndex).Value = 0
            DgvI.Item(4, e.RowIndex).Value = 0
            DgvI.Item(5, e.RowIndex).Value = 0
            DgvI.Item(6, e.RowIndex).Value = 0
            DgvI.Item(9, e.RowIndex).Value = 0

            '******************
            Dim totvol As Double = 0
            Dim totwt As Double = 0
            For i As Integer = 0 To DgvI.RowCount - 1
                totvol = totvol + (CDbl(DgvI.Item(3, i).Value) * CDbl(DgvI.Item(12, i).Value))
                totwt = totwt + CDbl(DgvI.Item(8, i).Value)
            Next

            For i As Integer = 0 To DgvI.RowCount - 1

                DgvI.Item(0, i).Value = i + 1

            Next

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in dgvI_RowsAdded", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'TxtOccuCbm.Text = FormatNumber(totvol, 4, , , False)
        'TxtOccuKgs.Text = FormatNumber(totwt, 4, , , False)
        'TxtFreeCbm.Text = FormatNumber((arc.length * arc.width * arc.height / 61024) - totvol, 4, , , False)
        'If TxtPayLoad.Text = "" Then TxtPayLoad.Text = "0"
        'TxtFreeKgs.Text = FormatNumber(CDbl(TxtPayLoad.Text) - CDbl(TxtOccuKgs.Text), 4, , , False)

    End Sub

    Private Sub DtReceipt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtReceipt.KeyDown

        If e.KeyCode = Keys.Enter Then CmbContainer.Focus()

    End Sub

    Private Sub cmdRef_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRef.Click

        Dim comm As New SDOleDb.OleDbCommand 'delete
        Try
            If MsgBox("Are you sure you want to refresh this record?", MsgBoxStyle.YesNo + vbInformation, "Customer Master") = MsgBoxResult.Yes Then
                If Ds1.Tables!TabIHead.Rows.Count = 0 Then
                    Call TxtClear()
                    Call NoRecordDisplay()
                    IntRows = 0
                    BFlag = False
                    CmbContainer.Enabled = False
                    DtReceipt.Enabled = False
                    cmdAdd.Focus()
                    ShowButton.Visible = False
                    Exit Sub
                ElseIf IntRows > 0 Or IntRows <= Ds1.Tables!TabIHead.Rows.Count - 1 Then
                    RefEnable()
                    TxtBind()
                    BFlag = False
                    CmbContainer.Enabled = False
                    DtReceipt.Enabled = False
                    ShowButton.Visible = False
                    cmdAdd.Focus()
                End If

            Else
                DtReceipt.Focus()
                Exit Sub
            End If
        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in cmdRef_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    End Sub

    Private Sub CmbContainer_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbContainer.SelectedIndexChanged

        Dim Rdr As OleDb.OleDbDataReader
        Dim Cmd As New OleDb.OleDbCommand
        Cmd.Connection = connDrums

        Dim Dlni As Single
        Dim Dwdi As Single
        Dim Dhti As Single

        Try
            Cmd.CommandText = "select lengthf,widthf,heightf,lengthi,widthi,heighti,lengthc,widthc,heightc,lengthm,widthm,heightm,payload from containermaster where containername ='" & CmbContainer.Text & "'"

            If connDrums.State = ConnectionState.Closed Then connDrums.Open()
            Rdr = Cmd.ExecuteReader
            Rdr.Read()

            Try
                Dlni = Rdr("lengthi") + (12 * Rdr("lengthf")) + (Rdr("lengthc") * 0.3937) + (Rdr("lengthm") * 0.03937)
            Catch Ex As Exception
                Exit Sub
            End Try

            Dwdi = Rdr("Widthi") + (12 * Rdr("Widthf")) + (Rdr("Widthc") * 0.3937) + (Rdr("Widthm") * 0.03937)
            Dhti = Rdr("heighti") + (12 * Rdr("heightf")) + (Rdr("heightc") * 0.3937) + (Rdr("heightm") * 0.03937)

            Label8.Text = "Length=" & Format(Dlni, "0.00") & " Width=" & Format(Dwdi, "0.00") & " Height=" & Format(Dhti, "0.00")
            TxtPayLoad.Text = Format(Rdr("payload"), "0.0000")

            CL = Format(Dlni, "0.00")
            CW = Format(Dwdi, "0.00")
            CH = Format(Dhti, "0.00")

            contcap = Rdr("payload")

            ContArr(0) = Dlni
            ContArr(1) = Dwdi
            ContArr(2) = Dhti
            Arc.DLengths = ContArr(0)
            Arc.DWidth = ContArr(1)
            Arc.DHeight = ContArr(2)
            TxtCapacity.Text = Format((Arc.DLengths * Arc.DWidth * Arc.DHeight * 0.000016387064))  '

            CDLst.Clear()
            CDLst.Add(Arc)
            Rdr.Close()

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in SelectedIndexChanged", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtbx_click(ByVal sender As Object, ByVal e As EventArgs)

        Dim TpUp1 As Boolean

        Try
            If DgvI.CurrentCell.ColumnIndex = 1 Then
                ItmNms = sender.text
                TpUp1 = IIf(DgvI.Item(7, DrmRWidx).Value = "6", False, True)
            Else
                ItmNms = DgvI.Item(1, DgvI.CurrentCell.RowIndex).Value
                TpUp1 = IIf(sender.text = "6", False, True)
            End If

            Dim Cmd As New OleDb.OleDbCommand
            Dim Rdr As OleDb.OleDbDataReader
            Dim Dlni As Single
            Dim Dwdi As Single
            Dim Dhti As Single

            Dim MaxQty1 As Integer

            Cmd.Connection = connDrums
            Cmd.CommandText = "select lengthf,widthf,heightf,lengthi,widthi,heighti,lengthc,widthc,heightc,lengthm,widthm,heightm,grossweight,packingmode from packmast where packname ='" & ItmNms & "'"
            If connDrums.State = ConnectionState.Closed Then connDrums.Open()
            Rdr = Cmd.ExecuteReader
            Rdr.Read()

            Try
                Dlni = Val(Format((Rdr("lengthi") + (12 * Rdr("lengthf")) + (Rdr("lengthc") * 0.3937) + (Rdr("lengthm") * 0.03937)), "0.0000"))
            Catch
                Exit Sub
            End Try
            Dwdi = Val(Format((Rdr("Widthi") + (12 * Rdr("Widthf")) + (Rdr("Widthc") * 0.3937) + (Rdr("Widthm") * 0.03937)), "0.0000"))
            Dhti = Val(Format((Rdr("heighti") + (12 * Rdr("heightf")) + (Rdr("heightc") * 0.3937) + (Rdr("heightm") * 0.03937)), "0.0000"))
            DgvI.Item(0, DrmRWidx).Value = DrmRWidx + 1
            DgvI.Item(1, DrmRWidx).Value = ItmNms
            DgvI.Item(4, DrmRWidx).Value = Dlni
            DgvI.Item(5, DrmRWidx).Value = Dwdi
            DgvI.Item(6, DrmRWidx).Value = Dhti
            DgvI.Item(3, DrmRWidx).Value = Dlni * Dwdi * Dhti * 0.000016387064   '/ 61024
            DgvI.Item(2, DrmRWidx).Value = Rdr("packingmode")
            DgvI.Item(8, DrmRWidx).Value = Rdr("grossweight")
            DgvI.Item(7, DrmRWidx).Value = 6

            If Not CheckBox1.Checked Then
                Dim Ans = MsgBox("Do you want to calculate maximum quantity?", MsgBoxStyle.YesNo)
                If Ans = MsgBoxResult.Yes Then


                    CDLst.Clear()
                    CDLst.Add(Arc)

                    Dim OldOpt As Boolean = chkwt

                    Dim ReStr As String = MessageBox.Show("The simple row column arrangement is shown!" & vbCrLf & "The Drums orientation is always Vertical", "Stuffing Arrangement shown", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                    If ReStr = MsgBoxResult.No Then
                        Exit Sub
                    End If

                    MaxQty1 = SimpleArngmtCalcMxmQty(DrmRWidx, TpUp1)

                    chkwt = OldOpt

                End If
            End If
        Catch Ex As Exception
            connDrums.Close()
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in txtbx_click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub DrumButton3_ClickDHE(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim Ar As New CDArea
        Dim x As Double
        Dim y As Double
        Dim z As Double
        Dim Dln As Double
        Dim Dwd As Double
        Dim Dht As Double
        Dim Dvol As Double
        Dim Dtotvol1 As Double

        Dim Lst As New List(Of String)

        TotVol = 0

        Try
            If CDLstmm.Count = 0 And DareaarrSA.Count = 0 Then
                If Not ShowEmp Then
                    CDLstmm.Add(Arc)
                Else
                    MsgBox("Container Is Fully Occupied. No Empty Area Left", MsgBoxStyle.Critical + vbOKOnly)
                    Exit Sub
                End If
            End If

            For i As Integer = 0 To CDLstmm.Count - 1
                Ar = CDLstmm(i)
                If ShowEmp Then
                    Ar.AutoDrawDrm(CurDir() & "\First.wrl", "r", 0, "", CStr(i + 1), 0, False, True, "E", 0, False, "b")

                End If
                x = Ar.DStrtPt.x
                y = Ar.DStrtPt.y
                z = Ar.DStrtPt.z
                Dln = Ar.DLengths
                Dwd = Ar.DWidth
                Dht = Ar.DHeight
                Dvol = Dln * Dwd * Dht
                TotVol = TotVol + Dvol
                dgEmpty.Rows.Add(CStr(i + 1), CStr(x), CStr(y), CStr(z), CStr(Dln), CStr(Dwd), CStr(Dht), Dvol)
                If dgEmpty.RowCount = 0 Then
                    'MsgBox("All rows deleted")
                    MessageBox.Show("All rows deleted", "Rows Info.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Next

            If DareaarrSA.Count > 0 Then
                Lst = DareaarrSA(0)

                Dtotvol1 = 0
                For i As Integer = 0 To Lst.Count - 1 Step 2
                    dgUsage.Rows.Add(Lst(i), Lst(i + 1))
                    Dtotvol1 = Dtotvol1 + CDbl(Lst(i + 1))
                Next
            End If

            dgUsage.Rows.Add("Total Occupied", CStr(Dtotvol1))
            dgUsage.Rows.Add("Empty", CStr(TotVol))

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in Button3_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub gb1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles gb1.Click

        Try
            Me.showbutton1.Visible = False
            Me.ShowButton.Visible = False
            Me.DgvI.Columns(4).Visible = True
            Me.DgvI.Columns(5).Visible = True
            Me.DgvI.Columns(6).Visible = True
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in gb1_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            lblArrangement.BackColor = Color.White
        End Try

    End Sub

    Private Sub btnStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStatus.Click

        Try
            Call Progress8.btnStatus_Click()
            DircnFlg = False
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in btnStatus_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub dgvI_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DgvI.DataError

        Exit Sub

    End Sub

    Private Sub ShowButton_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ShowButton.MouseClick

        'DDStop
        Try
            UserQtyAllot()

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in ShowButton_MouseClick", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        CAFRA = False

        If FlgArngmnt = False Then

            Try
                ChkDimns()      'check Dimensions of drums
            Catch Ex As Exception
                MsgBox(ex.Message)
                MsgBox(ex.ToString)
                MessageBox.Show("Error in ShowButton_MouseClick in ChkDimns", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            Try

                If flgDHD Then
                    DrumsToolStripStatusLabel.Text = "The drum diameter and height are different"
                    'MsgBox("Drums diameter and height is different !")
                    'MsgBox("Application Exit!")
                    'Application.Exit()
                    GC.Collect()
                    GoTo SADHD
                Else
                    GoTo SADHE
                End If
                GC.Collect()

                '*******************************************************************************
                'Drums Simple Arrangement Start
SADHE:
                DHDStopflg = False
                DrumsToolStripStatusLabel.Text = "The drum diameter and height are equal"

                If 12345 Then                   'If FlgArngmnt = False Then

                    btnStatus.ImageIndex = 0
                    lblStatus.Visible = True
                    lblStatus.Text = "Please wait....."

                    MsgBox("The simple row column arrangement is shown!", MsgBoxStyle.Information, "Display Arrangement .....")

                    lblArrangement.BackColor = Color.Pink
                    lblStatus.Visible = False
                    lblStatusINm.Visible = False
                    Dim Ans As MsgBoxResult

                    DrmRWidx = DgvI.CurrentCell.RowIndex
                    Dim RowNo1 As Integer = DrmRWidx
                    Dim PlcLst1 As New List(Of Integer)
                    chkwt = True

                    Try

                        If DgvI.CurrentCell.ColumnIndex = 12 Or DgvI.CurrentCell.ColumnIndex = 13 Or DgvI.CurrentCell.ColumnIndex = 14 Then
                            If DgvI.Item(1, RowNo1).Value Is Nothing _
                        OrElse DgvI.Item(11, RowNo1).Value Is Nothing _
                        OrElse Not IsNumeric(DgvI.Item(11, RowNo1).Value) _
                        OrElse CInt(DgvI.Item(11, RowNo1).Value) <= 0 _
                        OrElse DgvI.Item(11, RowNo1).Value.ToString.Contains(".") _
                        Then

                                If DgvI.CurrentCell.ColumnIndex <> 14 Then
                                    MsgBox("Cannot show this item." & ControlChars.CrLf & "Item name not selected or quantity is invalid", MsgBoxStyle.Critical + vbOKOnly)
                                    Exit Sub
                                End If

                            End If

                            If DgvI.CurrentCell.ColumnIndex <> 14 Then

                                Ans = MsgBoxResult.Yes
                                If Ans = MsgBoxResult.Yes Then
                                    For i As Integer = 0 To DgvI.RowCount - 1
                                        If DgvI.Item(1, i).Value Is Nothing _
                                        OrElse DgvI.Item(8, i).Value Is Nothing _
                                        OrElse DgvI.Item(11, i).Value Is Nothing _
                                        OrElse Not IsNumeric(DgvI.Item(8, i).Value) _
                                        OrElse Not IsNumeric(DgvI.Item(11, i).Value) _
                                        OrElse CInt(DgvI.Item(8, i).Value) < 0 _
                                        OrElse CInt(DgvI.Item(11, i).Value) <= 0 _
                                        OrElse DgvI.Item(11, i).Value.ToString.Contains(".") _
                                        OrElse DgvI.Item(11, i).Value.ToString.Contains(".") _
                                        Then
                                            Try
                                                DgvI.Rows.Remove(DgvI.Rows(i))
                                            Catch
                                                Exit For
                                            End Try
                                            i -= 1
                                            If i < RowNo1 Then

                                            End If
                                        End If
                                    Next
                                Else
                                    Exit Sub
                                End If
                            End If

                            If CmbContainer.Text = "" Then
                                MsgBox("Container not selected", MsgBoxStyle.Critical + vbOKOnly)
                                CmbContainer.Focus()
                                Exit Sub
                            End If
                            dsItemNo = 0
                            Dim StE3 As New StructE1
                            Dim qtyarr1 As New List(Of StructE1)
                            qtyarr1.Clear()
                            For i As Integer = 0 To RowNo1
                                StE3.ItmNm = DgvI.Item(1, i).Value
                                StE3.Qty = DgvI.Item(11, i).Value
                                qtyarr1.Add(StE3)
                            Next

                            TxtFreeCbm.Clear()
                            TxtOccuCbm.Clear()

                            Dim Ptx As New CDPoint
                            Ptx.x = Arc.DLengths
                            Ptx.y = Arc.DWidth
                            Ptx.z = Arc.DHeight

                            WrVrmlDrmContnrStrt(True, CurDir() & "\First.wrl", Ptx)

                            Dim PutQty As Integer

                            Dim MatchIdx As Integer = -1

                            If MatchIdx = 0 Then MatchIdx = -1
                            If MatchIdx = -1 Then
                                CDLst.Clear()

                                Dim CmdSd As New OleDb.OleDbCommand

                                CmdSd.Connection = connDrums
                                CmdSd.CommandText = "delete from stuffdata"
xx:
                                Try
                                    CmdSd.ExecuteNonQuery()

                                Catch Ex As Exception
                                    If Ex.Message = "Cannot open any more tables." Then
                                        connDrums.Close()
                                        connDrums.Dispose()
                                        OleDb.OleDbConnection.ReleaseObjectPool()
                                        CmdSd.Dispose()
                                        GC.Collect()

                                        connDrums.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\Drums.mdb;Persist Security Info=False"

                                        connDrums.Open()
                                        GoTo xx
                                    End If

                                End Try

                                '*************************************************************************
                                'Container Writing Program  is starting here
                                '*************************************************************************

                                Arc.AutoDrawDrm(CurDir() & "First.wrl", ContnrColor, 0.5, "", "", 0, True, False, "container", 0, True, "B")

                                Dim Ard As New CDArea
                                Ard.DStrtPt.x = Arc.DLengths
                                Ard.DStrtPt.y = 0
                                Ard.DStrtPt.z = 0
                                Ard.DLengths = 0.5
                                Ard.DWidth = Arc.DWidth
                                Ard.DHeight = Arc.DHeight

                                Ard.AutoDrawDrm(CurDir() & "\First.wrl", ContnrColor, 0, "file:///c:\contdoor.png", "", 0, True, False, "door", 0, False, "B")

                                Dim Ard1 As New CDArea
                                Ard1.DStrtPt.x = Arc.DLengths - 0.01
                                Ard1.DStrtPt.y = 0
                                Ard1.DStrtPt.z = 0
                                Ard1.DLengths = 0.5
                                Ard1.DWidth = Ard.DWidth
                                Ard1.DHeight = Ard.DHeight

                                Ard1.AutoDrawDrm(CurDir() & "First.wrl", ContnrColor, 0, "file:///c:\contdoor.png", "", 0, True, False, "door1", 0, False, "B")

                                DstrtclrSA = "r"
                            Else

                                PutQty = 0
                                For i As Integer = 0 To MatchIdx - 1
                                    PutQty += qtyarr1(i).Qty
                                Next
                                CDLst.Clear()
                                If MatchIdx <> -1 Then
                                    For i As Integer = 0 To dsQtyArr(MatchIdx - 1).E1StLst.Count - 1
                                        CDLst.Add(dsQtyArr(MatchIdx - 1).E1StLst(i))
                                    Next
                                End If

                                Arc.AutoDrawDrm(CurDir() & "\First.wrl", ContnrColor, 0.5, "", "", 0, True, False, "container", 0, True, "B")

                                Dim Ard As New CDArea

                                Ard.DStrtPt.x = Arc.DLengths
                                Ard.DStrtPt.y = 0
                                Ard.DStrtPt.z = 0
                                Ard.DLengths = 0.5
                                Ard.DWidth = Arc.DWidth
                                Ard.DHeight = Arc.DHeight

                                Ard.AutoDrawDrm(CurDir() & "\First.wrl", ContnrColor, 0, "file:///c:\contdoor.png", "", 0, True, False, "door", 0, False, "B")

                                Dim Ard1 As New CDArea

                                Ard1.DStrtPt.x = Arc.DLengths - 0.01
                                Ard1.DStrtPt.y = 0
                                Ard1.DStrtPt.z = 0
                                Ard1.DLengths = 0.5
                                Ard1.DWidth = Ard.DWidth
                                Ard1.DHeight = Ard.DHeight

                                Ard1.AutoDrawDrm(CurDir() & "First.wrl", ContnrColor, 0, "file:///c:\contdoor.png", "", 0, True, False, "door1", 0, False, "B")

                                Dim col1 As String = Nothing         'Dim col1 As String = "r"

                                DplclstSA.Clear()
                                DqtylstSA.Clear()

                                qtyarr.Clear()

                                Dim LstAhistArr1 As New List(Of StructR1)

                                LstAhistArr1.Clear()
                                lblStatus.Text = "Please wait....."         'Form8.Label1.Text = "Please wait...."
                                'Form8.Label2.Text = ""
                                btnStatus.Visible = False                   'Form8.Button1.Visible = False
                                lblStatus.Visible = True                    'Form8.Show()
                                lblStatusINm.Visible = True

                                If DgvI.CurrentCell.ColumnIndex = 12 Then
                                    ShowEmp = False
                                ElseIf DgvI.CurrentCell.ColumnIndex = 13 Then
                                    ShowEmp = True
                                End If

                                If CDLst.Count = 0 Then
                                    If ShowEmp Then
                                        MsgBox("Container Is Fully Occupied. No Empty Area Left", MsgBoxStyle.Critical + vbOKOnly)
                                        Exit Sub
                                    End If
                                End If

                                Dim Ar11 As New CDArea

                                For i As Integer = 0 To CDLst.Count - 1

                                    Ar11 = CDLst(i)

                                    If ShowEmp Then

                                        Ar11.AutoDrawDrm(CurDir() & "First.wrl", ContnrColor, 0, "", CStr(i + 1), 0, False, True, "E", 0, False, "B")

                                    End If

                                Next

                                If ShowEmp Then

                                    Try
                                        DrumEndfDHE(CurDir() & "\First.wrl")
                                        lblStatus.Visible = False            'Form8.Close()
                                        lblStatusINm.Visible = False
                                        btnStatus.Visible = False


                                        '##############

                                        Try

                                            Dim FName As String = CurDir() & "\First.wrl"
                                            Process.Start("c:\Program Files\Alteros 3D\alteros.exe", FName)

                                        Catch Err As Exception
                                            MsgBox(Err.Message)
                                            MessageBox.Show("Error in Alteros 3D running", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                        End Try

                                        '##############


                                        'Dim RsultStr As String

                                        'RsultStr = MsgBox("Do you show stuffing in three dimensional (Isometric) view ?", MsgBoxStyle.YesNo, "3DViewer")
                                        'If RsultStr = MsgBoxResult.Yes Then

                                        '    ThreeDViewerDrumDHE() ' (3D)Three Dimentional Arrangement are shown 
                                        'Else
                                        '    Dim Str As String

                                        '    Str = MsgBox("Do you close stuffing entry?", MsgBoxStyle.YesNo, "Stuffing Entry ...")
                                        '    If Str = MsgBoxResult.Yes Then
                                        '        Me.Close()
                                        '    Else
                                        '        Me.Focus()
                                        '    End If
                                        'End If

                                    Catch Ex As Exception

                                        MsgBox(Ex.Message, MsgBoxStyle.Critical, "Message :: In method 'MouseClick'  " & vbCrLf & "VRML Programme Running is failure!")
                                        Me.Close()

                                    Finally

                                        lblStatus.Visible = False            'Form8.Close()
                                        lblStatusINm.Visible = False
                                        btnStatus.Visible = False

                                    End Try

                                    Exit Sub
                                End If

                                Dim Qtyx As Integer = 0

                                dsItemNo = 0

                                For i As Integer = 0 To PutQty - 1

                                    Qtyx += 1
                                    LstAhistArr(i).Ar.AutoDrawDrm(CurDir() & "First.wrl", ContnrColor, 0, "file\\\c:\t2.png", LstAhistArr(i).ItmNm, 0, False, True, "", LstAhistArr(i).Method, False, "B")
                                    LstAhistArr1.Add(LstAhistArr(i))

                                    If i = PutQty - 1 Then

                                        PlcLst1.Add(Qtyx)

                                        DqtylstSA.Add(Qtyx)

                                        Dim Stm1 As New StructE1
                                        Stm1.ItmNm = LstAhistArr(i).ItmNm
                                        Stm1.Qty = Qtyx
                                        Stm1.E1StLst = LstAhistArr(i).R1CDLst
                                        dsQtyArr.Add(Stm1)

                                        Qtyx = 0
                                        Exit For
                                    End If

                                    If LstAhistArr(i).ItmNm <> LstAhistArr(i + 1).ItmNm Then

                                        dsItemNo += 1
                                        If col1 = "r" Then
                                            col1 = "g"
                                        ElseIf col1 = "g" Then
                                            col1 = "b"
                                        ElseIf col1 = "b" Then
                                            col1 = "m"
                                        ElseIf col1 = "m" Then
                                            col1 = "c"
                                        ElseIf col1 = "c" Then
                                            col1 = "y"
                                        End If
                                        PlcLst1.Add(Qtyx)
                                        DqtylstSA.Add(Qtyx)

                                        Dim Stm1 As New StructE1
                                        Stm1.ItmNm = LstAhistArr(i).ItmNm
                                        Stm1.Qty = Qtyx
                                        Stm1.E1StLst = LstAhistArr(i).R1CDLst
                                        dsQtyArr.Add(Stm1)
                                        Qtyx = 0

                                    End If

                                Next

                                dsItemNo += 1

                                lblStatus.Visible = False             'Form8.Close()
                                lblStatusINm.Visible = False

                                LstAhistArr.Clear()

                                For i As Integer = 0 To LstAhistArr1.Count - 1

                                    LstAhistArr.Add(LstAhistArr1(i))

                                Next

                                DplclstSA.Clear()

                                For i As Integer = 0 To DqtylstSA.Count - 1

                                    DplclstSA.Add(DqtylstSA(i) - 1)

                                Next

                                If col1 = "r" Then
                                    col1 = "g"
                                ElseIf col1 = "g" Then
                                    col1 = "b"
                                ElseIf col1 = "b" Then
                                    col1 = "m"
                                ElseIf col1 = "m" Then
                                    col1 = "c"
                                ElseIf col1 = "c" Then
                                    col1 = "y"
                                End If

                                DstrtclrSA = col1

                            End If

                            siSW.WriteLine("]}]}]}]}]}")

                            '*************************************************************************
                            'Container Writing Program  is finished here
                            '*************************************************************************

                            Dim CDLst1 As New List(Of CDArea)
                            Dim CDLst2 As New List(Of CDArea)

                            Dim Qtyf As Boolean = False
                            Dim RowLvFlg As Boolean = False

                            Dim dsStp As Integer
                            Dim Cntm As Integer = 1

                            Dim TotQty = 25

                            Dim TotQty1 As Integer = 0

                            Dim DrwStp As Integer

                            Dim CntFlg As Boolean = False

                            Dim Flg1 As Boolean = True

                            Dim Button1Flag As Boolean = False

                            Dim ItmNm As String

                            Button1Flag = True

                            Dim Cnt As Integer = 0
                            Dim DupFlg As Boolean = False

                            Cnt = 0

                            Dim Ar() As CDArea

                            Dim Ari() As String
                            Dim Arwt() As Single

                            Dim Ar1 As New CDArea

                            Dim Dln As Double
                            Dim Dwd As Double
                            Dim Dht As Double
                            Dim Dqty As Integer
                            Dim Dseq As Integer
                            Dim Dwt As String
                            Dim Dtransparr() As Boolean
                            Dim Dtransp As Boolean
                            Dim Dtopup() As Boolean
                            Dim Dtpup As Boolean

                            ReDim Ar(0)
                            ReDim Ari(0)
                            ReDim Arwt(0)
                            ReDim Dtransparr(0)
                            ReDim Dtopup(0)

                            Dim Cmd As New OleDb.OleDbCommand

                            Dim Cntx As Integer = 0

                            Dim PlcQty As Integer = 0

                            Dim k As Integer
                            Dim m As Integer

                            DeleteTable("DTemp1")
                            If CmbContainer.Text = "" Then

                                MsgBox("Container not selected", MsgBoxStyle.Critical + vbOKOnly)
                                CmbContainer.Focus()
                                Exit Sub

                            End If

                            lblStatus.Text = "Please wait...."      'Form8.Label1.Text = "Please wait...."
                            'Form8.Label2.Text = ""
                            btnStatus.Visible = False       'Form8.Button1.Visible = False
                            lblStatus.Visible = True        'Form8.Show()
                            lblStatusINm.Visible = True
                            lblStatus.Refresh()
                            lblStatusINm.Refresh()
                            System.Windows.Forms.Application.DoEvents()

                            Dim i1, j1 As Integer
                            Dim ExtFlg As Boolean = False

                            Dim Zz As Integer

                            Zz = RowNo1

                            Dim MatchIdx1 As Integer

                            If MatchIdx = -1 Then
                                MatchIdx1 = 0
                            Else
                                MatchIdx1 = MatchIdx
                            End If

                            For i1 = MatchIdx1 To Zz

                                ItmNm = DgvI.Item(1, i1).Value
                                Dln = Math.Round(DgvI.Item(4, i1).Value, 4)
                                Dwd = Math.Round(DgvI.Item(5, i1).Value, 4)
                                Dht = Math.Round(DgvI.Item(6, i1).Value, 4)
                                Dqty = DgvI.Item(11, i1).Value

                                Dwt = DgvI.Item(8, i1).Value
                                Dseq = DgvI.Item(0, i1).Value
                                Dtransp = False

                                Dtpup = IIf(DgvI.Item(7, i1).Value = "6", False, True)
                                DqtylstSA.Add(Dqty)

                                For j1 = 0 To Dqty - 1

                                    TotQty1 += 1

                                    Qtyf = True

                                    Ar1.DLengths = Dln
                                    Ar1.DWidth = Dwd
                                    Ar1.DHeight = Dht
                                    Ar1.DStrtPt.x = 0
                                    Ar1.DStrtPt.y = 0
                                    Ar1.DStrtPt.z = 0

                                    Ar(UBound(Ar)) = New CDArea
                                    Ar(UBound(Ar)).DLengths = Ar1.DLengths
                                    Ar(UBound(Ar)).DWidth = Ar1.DWidth
                                    Ar(UBound(Ar)).DHeight = Ar1.DHeight
                                    Ari(UBound(Ari)) = ItmNm
                                    Arwt(UBound(Arwt)) = Dwt
                                    Dtransparr(UBound(Dtransparr)) = Dtransp
                                    Dtopup(UBound(Dtopup)) = Dtpup
                                    ReDim Preserve Ar(UBound(Ar) + 1)
                                    ReDim Preserve Ari(UBound(Ari) + 1)
                                    ReDim Preserve Arwt(UBound(Arwt) + 1)
                                    ReDim Preserve Dtransparr(UBound(Dtransparr) + 1)
                                    ReDim Preserve Dtopup(UBound(Dtopup) + 1)
                                Next

                            Next i1

                            DplclstfSA.Clear()
                            For i As Integer = 0 To DplclstSA.Count - 1
                                DplclstfSA.Add(DplclstSA(i) + 1)
                            Next

                            For m = 0 To DplclstfSA.Count - 1
                                If DplclstfSA(m) = 0 Then
                                    k = m - 1
                                    Exit For
                                End If
                            Next

                            If k = 0 Then
                                k = m - 1
                            End If

                            If k = 0 Then
                                k = m + 1
                            End If

                            TotQty = 0
                            For i As Integer = 0 To DqtylstSA.Count - 1
                                TotQty = TotQty + DqtylstSA(i)
                            Next

                            PlcQty = 0
                            For i As Integer = 0 To DplclstfSA.Count - 1
                                PlcQty = PlcQty + DplclstfSA(i) - 1
                            Next

                            ReDim Preserve Ar(UBound(Ar) - 1)
                            ReDim Preserve Ari(UBound(Ari) - 1)
                            ReDim Preserve Arwt(UBound(Arwt) - 1)
                            ReDim Preserve Dtransparr(UBound(Dtransparr) - 1)
                            ReDim Preserve Dtopup(UBound(Dtopup) - 1)

                            dsStp += 1

                            Dim Ar2() As CDArea
                            Dim Ari2() As String
                            Dim Arwt2() As Single
                            Dim TranspArr2() As Boolean

                            ReDim Ar2(0)
                            ReDim Ari2(0)
                            ReDim Arwt2(0)
                            ReDim TranspArr2(0)

                            For i As Integer = LBound(Ar) To UBound(Ar)

                                Ar2(UBound(Ar2)) = Ar(i)
                                Ari2(UBound(Ari2)) = Ari(i)
                                Arwt2(UBound(Arwt2)) = Arwt(i)
                                TranspArr2(UBound(TranspArr2)) = Dtransparr(i)
                                ReDim Preserve Ar2(UBound(Ar2) + 1)
                                ReDim Preserve Ari2(UBound(Ari2) + 1)
                                ReDim Preserve Arwt2(UBound(Arwt2) + 1)
                                ReDim Preserve TranspArr2(UBound(TranspArr2) + 1)
                                ReDim Preserve Dtopup(UBound(Dtopup) + 1)
                            Next

                            ReDim Preserve Ar2(UBound(Ar2) - 1)
                            ReDim Preserve Ari2(UBound(Ari2) - 1)
                            ReDim Preserve Arwt2(UBound(Arwt2) - 1)
                            ReDim Preserve TranspArr2(UBound(TranspArr2) - 1)

                            Try
                                ReDim Preserve Dtopup(UBound(Dtopup) - 1)
                            Catch

                            End Try

                            If dsStp = DgvI.RowCount Then
                                dsStp = 0
                                Cnt = 0
                            End If

                            Arc.DStrtPt.x = 0
                            Arc.DStrtPt.y = 0
                            Arc.DStrtPt.z = 0
                            Arc.DLengths = ContArr(0)
                            Arc.DWidth = ContArr(1)
                            Arc.DHeight = ContArr(2)
                            Dqty = 0

                            lblStatus.Visible = False            'Form8.Close()
                            btnStatus.Visible = False

                            Dim OutFile As String = CurDir() & "\First.wrl"

                            If Ar.Length > 0 Then
                                If CDLst.Count = 0 Then CDLst.Add(Arc)
                                DItemQtySa = 0
                                DplclstSA.Clear()
                                Dtxtopt = False

                                If DgvI.CurrentCell.ColumnIndex = 12 Then
                                    If Not CheckBox1.Checked Then

                                        CDLst2 = DrumStuffDHE(Arc, Ar2, Ari2, Arwt2, False, False, OutFile, True, TranspArr2, Dtopup, Dtxtopt, True, False, True, ColArr)

                                        'Stop
                                    Else
                                        Dim Ar12 As New CDArea

                                        Dqty = DgvI.Item(11, 0).Value

                                        Ar12.DStrtPt.x = 0
                                        Ar12.DStrtPt.y = 0
                                        Ar12.DStrtPt.z = 0
                                        Ar12.DLengths = Math.Round(DgvI.Item(4, 0).Value, 4)
                                        Ar12.DWidth = Math.Round(DgvI.Item(5, 0).Value, 4)
                                        Ar12.DHeight = Math.Round(DgvI.Item(6, 0).Value, 4)
                                        Dim pt As New CDPoint
                                        pt.x = Ar1.DLengths
                                        pt.y = Ar1.DWidth
                                        pt.z = Ar1.DHeight
                                        ItmNm = DgvI.Item(1, 0).Value

                                        Dim Hg As Integer
                                        'Hg = stuffy(Arc, Ar12, True, True, qty, ItmNm)
                                        MsgBox((Hg - 1).ToString & " items placed")
                                        Hg = 0
                                        'Closef(OutFile)

                                    End If

                                    ShowEmp = True

                                End If

                                Dim EmVol As Double = 0

                                For Kk As Integer = 0 To CDLst.Count - 1
                                    EmVol = EmVol + (CDLst(Kk).DLengths * CDLst(Kk).DWidth * CDLst(Kk).DHeight)
                                Next

                                EmVol = EmVol * (0.0254 * 0.0254 * 0.0254)
                                TxtFreeCbm.Text = Format(EmVol, "0.000")
                                TxtOccuCbm.Text = Format((CDbl(TxtCapacity.Text) - CDbl(TxtFreeCbm.Text)), "0.000")

                                If DgvI.CurrentCell.ColumnIndex = 12 Then
                                    ShowEmp = False
                                ElseIf DgvI.CurrentCell.ColumnIndex = 13 Then
                                    ShowEmp = True
                                End If

                                Dim Mn As Integer = 0

                                Dim Are As CDArea
                                CDLstmm.Clear()

                                Dim Vol1 As Double

                                For jjj As Integer = 0 To CDLst2.Count - 1
                                    Vol1 = Vol1 + (CDLst2(jjj).DLengths * CDLst2(jjj).DWidth * CDLst2(jjj).DHeight)
                                Next

                                For Rr As Integer = 0 To CDLst2.Count - 1
                                    Are = New CDArea
                                    Are.DStrtPt.x = CDLst2(Rr).DStrtPt.x
                                    Are.DStrtPt.y = CDLst2(Rr).DStrtPt.y
                                    Are.DStrtPt.z = CDLst2(Rr).DStrtPt.z
                                    Are.DLengths = CDLst2(Rr).DLengths
                                    Are.DWidth = CDLst2(Rr).DWidth
                                    Are.DHeight = CDLst2(Rr).DHeight
                                    CDLstmm.Add(Are)
                                Next
                                CDLst.Clear()
                                ReDim Ar2(0)
                                ReDim Ar2(0)
                                ReDim Ari2(0)
                                ReDim Arwt2(0)
                                ReDim TranspArr2(0)
                                ReDim Dtopup(0)

                                'Three Comment Mark 

                                For i As Integer = 0 To DItemNoSA

                                    If CInt(DgvI.Item(11, i).Value) > DqtylstSA(i) + 1 Then

                                        Dim Qtyv As Integer

                                        If DqtylstSA(i) <= 0 Then
                                            Qtyv = 0
                                        Else
                                            Qtyv = DqtylstSA(i) + 1
                                        End If
                                        MsgBox(DgvI.Item(11, i).Value.ToString & " no of " & DgvI.Item(1, i).Value & " cannot be placed." & vbCrLf & CStr(Qtyv) & " placed.", MsgBoxStyle.Information + vbOKOnly)
                                        DgvI.Item(11, i).Value = Qtyv
                                        DrwStp = DrwStp - DqtylstSA(i) + DplclstSA(i) + 1
                                        DqtylstSA(i) = DplclstSA(i) + 1

                                    End If
                                Next

                                'Three Commenting Marks

                                If Not CheckBox1.Checked Then
                                    TxtOccuKgs.Text = Format(CDbl(DgvI.Item(8, DgvI.CurrentCell.RowIndex).Value) * (DplclstSA(CInt(DgvI.CurrentCell.RowIndex)) + 1), "0.000")
                                    TxtFreeKgs.Text = Format(CDbl(TxtPayLoad.Text) - CDbl(TxtOccuKgs.Text), "0.000")

                                    For i As Integer = 0 To RowNo1
                                        Dim qtyv As Integer = DplclstSA(i)
                                        qtyv += 1
                                        If CheckBox1.Checked = True Then
                                            If fullflag Then
                                                'qtyv = xcnt - 1
                                                qtyv = xcnt
                                            Else
                                                qtyv = xcnt
                                            End If
                                        End If
                                        If CInt(DgvI.Item(11, i).Value) > qtyv Then
                                            MsgBox(DgvI.Item(11, i).Value.ToString & " no of " & DgvI.Item(1, i).Value & " cannot be placed." & vbCrLf & CStr(qtyv) & " placed.", MsgBoxStyle.Information + vbOKOnly)
                                            DgvI.Item(11, i).Value = qtyv
                                        End If
                                    Next

                                    DplclstfSA.Clear()
                                    For i As Integer = 0 To DplclstSA.Count - 1
                                        DplclstfSA.Add(DplclstSA(i) + 1)
                                    Next
                                    k = 0

                                    For m = 0 To DplclstfSA.Count - 1

                                        If DplclstfSA(m) = 0 Then
                                            k = m - 1
                                            Exit For
                                        End If
                                    Next

                                    If k = 0 Then
                                        k = m - 1
                                    End If

                                    TotQty = 0
                                    Dim bn As Integer

                                    If MatchIdx = -1 Then
                                        bn = 0
                                    Else
                                        bn = MatchIdx
                                    End If

                                    For i As Integer = 0 To DqtylstSA.Count - 1
                                        TotQty = TotQty + DqtylstSA(i)
                                    Next

                                    PlcQty = 0

                                    For i As Integer = 0 To DplclstfSA.Count - 1
                                        PlcQty = PlcQty + DplclstfSA(i)
                                    Next

                                    Do While Not dgEmpty.RowCount = 0

                                        Try
                                            dgEmpty.Rows.Remove(dgEmpty.Rows(0))
                                        Catch
                                            Exit Do
                                        End Try
                                    Loop

                                    Do While Not dgUsage.RowCount = 0
                                        Try
                                            dgUsage.Rows.Remove(dgUsage.Rows(0))
                                        Catch
                                            Exit Do
                                        End Try
                                    Loop

                                    Call DrumButton3_ClickDHE(Nothing, Nothing)
                                    DrumEndfDHE(CurDir() & "\First.wrl")
                                    DEventless()
                                End If
                            End If

                            '$#
                            'siSW.Close()

                            '------------------------------------------------
                            DrumsToolStripStatusLabel.Text = ""

                            'Dim RsltStr As String
                            'Dim RsltSv As String

                            'RsltSv = MessageBox.Show("Auto file save ", "Stuff viewer Drum file save", MessageBoxButtons.YesNo, MessageBoxIcon.Information)

                            'Dim Ofd As Stuff_Viewers = New Stuff_Viewers
                            'Ofd.DestroyOldFile("C:\CSP.Drum.wrl")

                            ''If RsltSv = MsgBoxResult.Yes Then
                            'DrumFinalOutPutWriter()
                            ''Else

                            'Stuff_Viewers.Show()
                            'Stuff_Viewers.Focus()
                            'End If

                            '##############

                            Try

                                Dim FName As String = CurDir() & "\First.wrl"
                                Process.Start("c:\Program Files\Alteros 3D\alteros.exe", FName)

                            Catch Err As Exception
                                MsgBox(Err.Message)
                                MsgBox(Err.ToString)
                                MessageBox.Show("Error in Alteros 3D running", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End Try

                            '##############

                            'RsltStr = MsgBox("Do you show stuffing in three dimensional (Isometric) view ?", MsgBoxStyle.YesNo, "3DViewer")

                            'If RsltStr = MsgBoxResult.Yes Then

                            '    ThreeDViewerDrumDHE() ' (3D)Three Dimentional Arrangement are shown 

                            'Else

                            '    Dim Str As String

                            '    Str = MsgBox("Do you close stuffing entry?", MsgBoxStyle.YesNo, "Stuffing Entry ...")
                            '    If Str = MsgBoxResult.Yes Then
                            '        Me.Close()
                            '    Else
                            '        Me.Focus()
                            '    End If

                            'ThreeDViewerDrumDHE() ' (3D)Three Dimentional Arrangement are shown 

                            DplclstSA.Clear()
                            DqtylstSA.Clear()
                            'End If

                            '------------------------------------------------
                        End If

                    Catch Ex As Exception
                        DrumsToolStripStatusLabel.Text = ""
                        MsgBox(Ex.Message)
                        MsgBox(Ex.ToString)
                        MessageBox.Show("Error in ShowButton_MouseClick" & vbCrLf & "Programme Running is failure!", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        connDrums.Close()
                        siSW.Close()
                    End Try

                End If

                '*******************************************************************************

                '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
                '#####################################################################################################
                'Drum Simple Arrangement Start DHD

SADHD:
                If DHDStopflg Then
                    flgDHD = False
                    'MsgBox("Drums diameter and height is different !")
                    'MsgBox("Application Exit!")
                    'Application.Exit()

                    If 67890 Then                           'If FlgArngmnt = False Then

                        btnStatus.ImageIndex = 0

                        lblStatus.Visible = True
                        lblStatus.Text = "Please wait....."

                        MsgBox("The simple row column arrangement is shown!", MsgBoxStyle.Information, "Display Arrangement .....")

                        lblArrangement.BackColor = Color.Pink
                        lblStatus.Visible = False
                        lblStatusINm.Visible = False
                        Dim Ans As MsgBoxResult

                        DrmRWidx = DgvI.CurrentCell.RowIndex
                        Dim RowNo1 As Integer = DrmRWidx
                        Dim PlcLst1 As New List(Of Integer)
                        chkwt = True

                        'DStop

                        Try

                            If DgvI.CurrentCell.ColumnIndex = 12 Or DgvI.CurrentCell.ColumnIndex = 13 Or DgvI.CurrentCell.ColumnIndex = 14 Then
                                If DgvI.Item(1, RowNo1).Value Is Nothing _
                            OrElse DgvI.Item(11, RowNo1).Value Is Nothing _
                            OrElse Not IsNumeric(DgvI.Item(11, RowNo1).Value) _
                            OrElse CInt(DgvI.Item(11, RowNo1).Value) <= 0 _
                            OrElse DgvI.Item(11, RowNo1).Value.ToString.Contains(".") _
                            Then
                                    If DgvI.CurrentCell.ColumnIndex <> 14 Then
                                        MsgBox("Cannot show this item." & ControlChars.CrLf & "Item name not selected or quantity is invalid", MsgBoxStyle.Critical + vbOKOnly)
                                        Exit Sub
                                    End If

                                End If

                                If DgvI.CurrentCell.ColumnIndex <> 14 Then
                                    Ans = MsgBoxResult.Yes
                                    If Ans = MsgBoxResult.Yes Then
                                        For i As Integer = 0 To DgvI.RowCount - 1
                                            If DgvI.Item(1, i).Value Is Nothing _
                                            OrElse DgvI.Item(8, i).Value Is Nothing _
                                            OrElse DgvI.Item(11, i).Value Is Nothing _
                                            OrElse Not IsNumeric(DgvI.Item(8, i).Value) _
                                            OrElse Not IsNumeric(DgvI.Item(11, i).Value) _
                                            OrElse CInt(DgvI.Item(8, i).Value) < 0 _
                                            OrElse CInt(DgvI.Item(11, i).Value) <= 0 _
                                            OrElse DgvI.Item(11, i).Value.ToString.Contains(".") _
                                            OrElse DgvI.Item(11, i).Value.ToString.Contains(".") _
                                            Then
                                                Try
                                                    DgvI.Rows.Remove(DgvI.Rows(i))
                                                Catch
                                                    Exit For
                                                End Try
                                                i -= 1
                                                If i < RowNo1 Then

                                                End If
                                            End If
                                        Next
                                    Else
                                        Exit Sub
                                    End If
                                End If

                                If CmbContainer.Text = "" Then
                                    MsgBox("Container not selected", MsgBoxStyle.Critical + vbOKOnly)
                                    CmbContainer.Focus()
                                    Exit Sub
                                End If
                                DItemNoSA = 0
                                Dim StE3 As New StructE1
                                Dim qtyarr1 As New List(Of StructE1)
                                qtyarr1.Clear()
                                For i As Integer = 0 To RowNo1
                                    StE3.ItmNm = DgvI.Item(1, i).Value
                                    StE3.Qty = DgvI.Item(11, i).Value
                                    qtyarr1.Add(StE3)
                                Next

                                'DStop

                                TxtFreeCbm.Clear()
                                TxtOccuCbm.Clear()

                                'Dim Ptx As New CPoint
                                'Ptx.x = Arc.DLengths
                                'Ptx.y = Arc.DWidth
                                'Ptx.z = Arc.DHeight

                                Dim Ptx As New CDrum
                                Ptx.DStrtPt.x = Arc.DLengths
                                Ptx.DStrtPt.y = Arc.DWidth
                                Ptx.DStrtPt.z = Arc.DHeight

                                'The child class drum used in following function
                                WrVrmlDrmContnrStrt(CurDir() & "\First.wrl", True, Ptx)      'WrVrmlStrt(CurDir() & "\DVRML.wrl", True, Ptx)

                                '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

                                Dim PutQty As Integer

                                Dim MatchIdx As Integer = -1

                                If MatchIdx = 0 Then MatchIdx = -1
                                If MatchIdx = -1 Then
                                    CDLst.Clear()

                                    Dim CmdSd As New OleDb.OleDbCommand

                                    CmdSd.Connection = connDrums
                                    CmdSd.CommandText = "delete from stuffdata"
Drumxx:
                                    Try
                                        CmdSd.ExecuteNonQuery()

                                    Catch Ex As Exception
                                        If Ex.Message = "Cannot open any more tables." Then
                                            connDrums.Close()
                                            connDrums.Dispose()
                                            OleDb.OleDbConnection.ReleaseObjectPool()
                                            CmdSd.Dispose()
                                            GC.Collect()

                                            connDrums.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\Drums.mdb;Persist Security Info=False"

                                            connDrums.Open()
                                            GoTo drumxx
                                        End If

                                    End Try

                                    '*************************************************************************
                                    'Container Writing Program  is starting here
                                    '*************************************************************************

                                    Arc.AutoDrawDrm(CurDir() & "First.wrl", ContnrColor, 0.5, "", "", 0, True, False, "container", 0, True, "B")

                                    Dim Ard As New CDArea
                                    Ard.DStrtPt.x = Arc.DLengths
                                    Ard.DStrtPt.y = 0
                                    Ard.DStrtPt.z = 0
                                    Ard.DLengths = 0.5
                                    Ard.DWidth = Arc.DWidth
                                    Ard.DHeight = Arc.DHeight

                                    Ard.AutoDrawDrm(CurDir() & "\First.wrl", ContnrColor, 0, "file:///c:\contdoor.png", "", 0, True, False, "door", 0, False, "B")

                                    Dim Ard1 As New CDArea
                                    Ard1.DStrtPt.x = Arc.DLengths - 0.01
                                    Ard1.DStrtPt.y = 0
                                    Ard1.DStrtPt.z = 0
                                    Ard1.DLengths = 0.5
                                    Ard1.DWidth = Ard.DWidth
                                    Ard1.DHeight = Ard.DHeight

                                    Ard1.AutoDrawDrm(CurDir() & "First.wrl", ContnrColor, 0, "file:///c:\contdoor.png", "", 0, True, False, "door1", 0, False, "B")

                                    DstrtclrSA = "r"
                                Else

                                    PutQty = 0
                                    For i As Integer = 0 To MatchIdx - 1
                                        PutQty += qtyarr1(i).Qty
                                    Next
                                    CDLst.Clear()
                                    If MatchIdx <> -1 Then
                                        For i As Integer = 0 To dsQtyArr(MatchIdx - 1).E1StLst.Count - 1
                                            CDLst.Add(dsQtyArr(MatchIdx - 1).E1StLst(i))
                                        Next
                                    End If

                                    Arc.AutoDrawDrm(CurDir() & "\First.wrl", ContnrColor, 0.5, "", "", 0, True, False, "container", 0, True, "B")

                                    Dim Ard As New CDArea

                                    Ard.DStrtPt.x = Arc.DLengths
                                    Ard.DStrtPt.y = 0
                                    Ard.DStrtPt.z = 0
                                    Ard.DLengths = 0.5
                                    Ard.DWidth = Arc.DWidth
                                    Ard.DHeight = Arc.DHeight

                                    Ard.AutoDrawDrm(CurDir() & "\First.wrl", ContnrColor, 0, "file:///c:\contdoor.png", "", 0, True, False, "door", 0, False, "B")

                                    Dim Ard1 As New CDArea

                                    Ard1.DStrtPt.x = Arc.DLengths - 0.01
                                    Ard1.DStrtPt.y = 0
                                    Ard1.DStrtPt.z = 0
                                    Ard1.DLengths = 0.5
                                    Ard1.DWidth = Ard.DWidth
                                    Ard1.DHeight = Ard.DHeight

                                    Ard1.AutoDrawDrm(CurDir() & "First.wrl", ContnrColor, 0, "file:///c:\contdoor.png", "", 0, True, False, "door1", 0, False, "B")

                                    'Dim col1 As String = "r"

                                    Dim col1 As String = Nothing

                                    DplclstSA.Clear()
                                    DqtylstSA.Clear()

                                    qtyarr.Clear()

                                    Dim LstAhistArr1 As New List(Of StructR1)

                                    LstAhistArr1.Clear()
                                    lblStatus.Text = "Please wait....."         'Form8.Label1.Text = "Please wait...."
                                    'Form8.Label2.Text = ""
                                    btnStatus.Visible = False                   'Form8.Button1.Visible = False
                                    lblStatus.Visible = True                    'Form8.Show()
                                    lblStatusINm.Visible = True

                                    If DgvI.CurrentCell.ColumnIndex = 12 Then
                                        ShowEmp = False
                                    ElseIf DgvI.CurrentCell.ColumnIndex = 13 Then
                                        ShowEmp = True
                                    End If

                                    If CDLst.Count = 0 Then
                                        If ShowEmp Then
                                            MsgBox("Container Is Fully Occupied. No Empty Area Left", MsgBoxStyle.Critical + vbOKOnly)
                                            Exit Sub
                                        End If
                                    End If

                                    Dim Ar11 As New CDArea

                                    For i As Integer = 0 To CDLst.Count - 1
                                        Ar11 = CDLst(i)

                                        If ShowEmp Then

                                            Ar11.AutoDrawDrm(CurDir() & "First.wrl", ContnrColor, 0, "", CStr(i + 1), 0, False, True, "E", 0, False, "B")

                                        End If

                                    Next

                                    'Above Up to 30 May 2k8


                                    If ShowEmp Then
                                        Try
                                            DrumEndfDHE(CurDir() & "\First.wrl")
                                            lblStatus.Visible = False            'Form8.Close()
                                            lblStatusINm.Visible = False
                                            btnStatus.Visible = False

                                            '##############

                                            Try

                                                Dim FName As String = CurDir() & "\First.wrl"
                                                Process.Start("c:\Program Files\Alteros 3D\alteros.exe", FName)

                                            Catch Err As Exception
                                                MsgBox(Err.Message)
                                                MsgBox(Err.ToString)
                                                MessageBox.Show("Error in Alteros 3D running", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                            End Try

                                            '##############

                                            'Dim RsultStr As String

                                            'RsultStr = MsgBox("Do you show stuffing in three dimensional (Isometric) view ?", MsgBoxStyle.YesNo, "3DViewer")
                                            'If RsultStr = MsgBoxResult.Yes Then

                                            '    ThreeDViewerDrumDHE() ' (3D)Three Dimentional Arrangement are shown 
                                            'Else
                                            '    Dim Str As String

                                            '    Str = MsgBox("Do you close stuffing entry?", MsgBoxStyle.YesNo, "Stuffing Entry ...")
                                            '    If Str = MsgBoxResult.Yes Then
                                            '        Me.Close()
                                            '    Else
                                            '        Me.Focus()
                                            '    End If
                                            'End If

                                        Catch Ex As Exception

                                            MsgBox(Ex.Message, MsgBoxStyle.Critical, "Message :: In method 'MouseClick'  " & vbCrLf & "VRML Programme Running is failure!")
                                            Me.Close()

                                        Finally
                                            lblStatus.Visible = False            'Form8.Close()
                                            lblStatusINm.Visible = False
                                            btnStatus.Visible = False
                                        End Try

                                        Exit Sub
                                    End If

                                    Dim Qtyx As Integer = 0

                                    dsItemNo = 0

                                    For i As Integer = 0 To PutQty - 1
                                        Qtyx += 1
                                        LstAhistArr(i).Ar.AutoDrawDrm(CurDir() & "First.wrl", ContnrColor, 0, "file\\\c:\t2.png", LstAhistArr(i).ItmNm, 0, False, True, "", LstAhistArr(i).Method, False, "B")
                                        LstAhistArr1.Add(LstAhistArr(i))
                                        If i = PutQty - 1 Then
                                            PlcLst1.Add(Qtyx)

                                            DqtylstSA.Add(Qtyx)

                                            Dim Stm1 As New StructE1
                                            Stm1.ItmNm = LstAhistArr(i).ItmNm
                                            Stm1.Qty = Qtyx
                                            Stm1.E1StLst = LstAhistArr(i).R1CDLst
                                            dsQtyArr.Add(Stm1)

                                            Qtyx = 0
                                            Exit For
                                        End If
                                        If LstAhistArr(i).ItmNm <> LstAhistArr(i + 1).ItmNm Then
                                            dsItemNo += 1
                                            If col1 = "r" Then
                                                col1 = "g"
                                            ElseIf col1 = "g" Then
                                                col1 = "b"
                                            ElseIf col1 = "b" Then
                                                col1 = "m"
                                            ElseIf col1 = "m" Then
                                                col1 = "c"
                                            ElseIf col1 = "c" Then
                                                col1 = "y"
                                            End If
                                            PlcLst1.Add(Qtyx)
                                            DqtylstSA.Add(Qtyx)

                                            Dim Stm1 As New StructE1
                                            Stm1.ItmNm = LstAhistArr(i).ItmNm
                                            Stm1.Qty = Qtyx
                                            Stm1.E1StLst = LstAhistArr(i).R1CDLst
                                            dsQtyArr.Add(Stm1)
                                            Qtyx = 0
                                        End If

                                    Next

                                    dsItemNo += 1

                                    lblStatus.Visible = False             'Form8.Close()
                                    lblStatusINm.Visible = False

                                    LstAhistArr.Clear()

                                    For i As Integer = 0 To LstAhistArr1.Count - 1
                                        LstAhistArr.Add(LstAhistArr1(i))

                                    Next

                                    DplclstSA.Clear()

                                    For i As Integer = 0 To DqtylstSA.Count - 1
                                        DplclstSA.Add(DqtylstSA(i) - 1)
                                    Next

                                    If col1 = "r" Then
                                        col1 = "g"
                                    ElseIf col1 = "g" Then
                                        col1 = "b"
                                    ElseIf col1 = "b" Then
                                        col1 = "m"
                                    ElseIf col1 = "m" Then
                                        col1 = "c"
                                    ElseIf col1 = "c" Then
                                        col1 = "y"
                                    End If

                                    DstrtclrSA = col1

                                End If

                                siSW.WriteLine("]}]}]}]}]}")

                                '*************************************************************************
                                'Container Writing Program  is finished here
                                '*************************************************************************

                                'DStop

                                Dim CDLst1 As New List(Of CDArea)
                                Dim CDLst2 As New List(Of CDArea)

                                Dim Qtyf As Boolean = False
                                Dim RowLvFlg As Boolean = False

                                Dim dsStp As Integer
                                Dim Cntm As Integer = 1

                                Dim TotQty = 25

                                Dim TotQty1 As Integer = 0

                                Dim DrwStp As Integer

                                Dim CntFlg As Boolean = False

                                Dim Flg1 As Boolean = True

                                Dim Button1Flag As Boolean = False

                                Dim ItmNm As String

                                Button1Flag = True

                                Dim Cnt As Integer = 0
                                Dim DupFlg As Boolean = False

                                Cnt = 0

                                Dim Ar() As CDArea

                                Dim Ari() As String
                                Dim Arwt() As Single

                                Dim Ar1 As New CDArea

                                Dim Dln As Double
                                Dim Dwd As Double
                                Dim Dht As Double
                                Dim DRdus As Double
                                Dim Dqty As Integer
                                Dim Dseq As Integer
                                Dim Dwt As String
                                Dim Dtransparr() As Boolean
                                Dim Dtransp As Boolean
                                Dim Dtopup() As Boolean
                                Dim Dtpup As Boolean

                                ReDim Ar(0)
                                ReDim Ari(0)
                                ReDim Arwt(0)
                                ReDim Dtransparr(0)
                                ReDim Dtopup(0)

                                Dim Cmd As New OleDb.OleDbCommand

                                Dim Cntx As Integer = 0

                                Dim PlcQty As Integer = 0

                                Dim k As Integer
                                Dim m As Integer

                                Try
                                    DeleteTable("DTemp1")
                                    If CmbContainer.Text = "" Then
                                        MsgBox("Container not selected", MsgBoxStyle.Critical + vbOKOnly)
                                        CmbContainer.Focus()
                                        Exit Sub
                                    End If

                                    lblStatus.Text = "Please wait...."      'Form8.Label1.Text = "Please wait...."
                                    'Form8.Label2.Text = ""
                                    btnStatus.Visible = False       'Form8.Button1.Visible = False
                                    lblStatus.Visible = True        'Form8.Show()
                                    lblStatusINm.Visible = True
                                    lblStatus.Refresh()
                                    lblStatusINm.Refresh()
                                    System.Windows.Forms.Application.DoEvents()

                                    Dim i1, j1 As Integer
                                    Dim ExtFlg As Boolean = False

                                    Dim Zz As Integer

                                    Zz = RowNo1

                                    Dim MatchIdx1 As Integer

                                    If MatchIdx = -1 Then
                                        MatchIdx1 = 0
                                    Else
                                        MatchIdx1 = MatchIdx
                                    End If

                                    For i1 = MatchIdx1 To Zz

                                        ItmNm = DgvI.Item(1, i1).Value
                                        Dln = Math.Round(DgvI.Item(4, i1).Value, 4)
                                        Dwd = Math.Round(DgvI.Item(5, i1).Value, 4)
                                        Dht = Math.Round(DgvI.Item(6, i1).Value, 4)
                                        Dqty = DgvI.Item(11, i1).Value
                                        'Stop
                                        '///////////Radius manupulation
                                        If Dln = Dwd Then

                                            DRdus = (Dln + Dwd) * 0.25

                                        ElseIf Dln <> Dwd Then

                                            MessageBox.Show("The diameter-> length and widths are not same", "ShowButton_MouseClick :: Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                                        Else

                                            MessageBox.Show("The diameter-> length and widths are Inadequate", "ShowButton_MouseClick :: Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                            MsgBox("Application Exit!")
                                            GC.Collect()
                                            Application.Exit()
                                        End If

                                        'DStop

                                        Dwt = DgvI.Item(8, i1).Value
                                        Dseq = DgvI.Item(0, i1).Value
                                        Dtransp = False

                                        Dtpup = IIf(DgvI.Item(7, i1).Value = "6", False, True)
                                        DqtylstSA.Add(Dqty)

                                        For j1 = 0 To Dqty - 1

                                            TotQty1 += 1

                                            Qtyf = True

                                            Ar1.DLengths = Dln
                                            Ar1.DWidth = Dwd
                                            Ar1.DHeight = Dht
                                            Ar1.DRadius = DRdus
                                            Ar1.DStrtPt.x = 0
                                            Ar1.DStrtPt.y = 0
                                            Ar1.DStrtPt.z = 0

                                            Ar(UBound(Ar)) = New CDArea
                                            Ar(UBound(Ar)).DLengths = Ar1.DLengths
                                            Ar(UBound(Ar)).DWidth = Ar1.DWidth
                                            Ar(UBound(Ar)).DHeight = Ar1.DHeight
                                            Ar(UBound(Ar)).DRadius = Ar1.DRadius
                                            Ari(UBound(Ari)) = ItmNm
                                            Arwt(UBound(Arwt)) = Dwt
                                            Dtransparr(UBound(Dtransparr)) = Dtransp
                                            Dtopup(UBound(Dtopup)) = Dtpup
                                            ReDim Preserve Ar(UBound(Ar) + 1)
                                            ReDim Preserve Ari(UBound(Ari) + 1)
                                            ReDim Preserve Arwt(UBound(Arwt) + 1)
                                            ReDim Preserve Dtransparr(UBound(Dtransparr) + 1)
                                            ReDim Preserve Dtopup(UBound(Dtopup) + 1)
                                        Next

                                    Next i1
                                    'DStop
                                    DplclstfSA.Clear()

                                Catch Ex As Exception
                                    MsgBox(Ex.Message)
                                    MsgBox(Ex.ToString)
                                    MessageBox.Show("Error in TransactionsMenu", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End Try

                                For i As Integer = 0 To DplclstSA.Count - 1
                                    DplclstfSA.Add(DplclstSA(i) + 1)
                                Next

                                For m = 0 To DplclstfSA.Count - 1
                                    If DplclstfSA(m) = 0 Then
                                        k = m - 1
                                        Exit For
                                    End If
                                Next

                                If k = 0 Then
                                    k = m - 1
                                End If

                                If k = 0 Then
                                    k = m + 1
                                End If

                                TotQty = 0
                                For i As Integer = 0 To DqtylstSA.Count - 1
                                    TotQty = TotQty + DqtylstSA(i)
                                Next

                                PlcQty = 0
                                For i As Integer = 0 To DplclstfSA.Count - 1
                                    PlcQty = PlcQty + DplclstfSA(i) - 1
                                Next

                                ReDim Preserve Ar(UBound(Ar) - 1)
                                ReDim Preserve Ari(UBound(Ari) - 1)
                                ReDim Preserve Arwt(UBound(Arwt) - 1)
                                ReDim Preserve Dtransparr(UBound(Dtransparr) - 1)
                                ReDim Preserve Dtopup(UBound(Dtopup) - 1)

                                dsStp += 1

                                Dim Ar2() As CDArea
                                Dim Ari2() As String
                                Dim Arwt2() As Single
                                Dim TranspArr2() As Boolean

                                ReDim Ar2(0)
                                ReDim Ari2(0)
                                ReDim Arwt2(0)
                                ReDim TranspArr2(0)

                                'DStop

                                For i As Integer = LBound(Ar) To UBound(Ar)

                                    Ar2(UBound(Ar2)) = Ar(i)
                                    Ari2(UBound(Ari2)) = Ari(i)
                                    Arwt2(UBound(Arwt2)) = Arwt(i)
                                    TranspArr2(UBound(TranspArr2)) = Dtransparr(i)
                                    ReDim Preserve Ar2(UBound(Ar2) + 1)
                                    ReDim Preserve Ari2(UBound(Ari2) + 1)
                                    ReDim Preserve Arwt2(UBound(Arwt2) + 1)
                                    ReDim Preserve TranspArr2(UBound(TranspArr2) + 1)
                                    ReDim Preserve Dtopup(UBound(Dtopup) + 1)
                                Next

                                ReDim Preserve Ar2(UBound(Ar2) - 1)
                                ReDim Preserve Ari2(UBound(Ari2) - 1)
                                ReDim Preserve Arwt2(UBound(Arwt2) - 1)
                                ReDim Preserve TranspArr2(UBound(TranspArr2) - 1)

                                'DStop

                                Try
                                    ReDim Preserve Dtopup(UBound(Dtopup) - 1)
                                Catch

                                End Try

                                If dsStp = DgvI.RowCount Then
                                    dsStp = 0
                                    Cnt = 0
                                End If

                                Arc.DStrtPt.x = 0
                                Arc.DStrtPt.y = 0
                                Arc.DStrtPt.z = 0
                                Arc.DLengths = ContArr(0)
                                Arc.DWidth = ContArr(1)
                                Arc.DHeight = ContArr(2)
                                Dqty = 0

                                lblStatus.Visible = False            'Form8.Close()
                                btnStatus.Visible = False

                                Dim OutFile As String = CurDir() & "\First.wrl"

                                If Ar.Length > 0 Then
                                    If CDLst.Count = 0 Then CDLst.Add(Arc)
                                    DItemQtySa = 0
                                    DplclstSA.Clear()
                                    Dtxtopt = False

                                    If DgvI.CurrentCell.ColumnIndex = 12 Then
                                        If Not CheckBox1.Checked Then

                                            'DStop

                                            CDLst2 = DrumStuff(Arc, Ar2, Ari2, Arwt2, False, False, OutFile, True, TranspArr2, Dtopup, Dtxtopt, True, False, True, ColArr)

                                            'DStop
                                            '*********@
                                        Else

                                            Dim DAr12 As New CDrum                 'Dim Ar12 As New CDArea

                                            Dqty = DgvI.Item(11, 0).Value

                                            DAr12.DStrtPt.x = 0
                                            DAr12.DStrtPt.y = 0
                                            DAr12.DStrtPt.z = 0
                                            DAr12.DLengths = Math.Round(DgvI.Item(4, 0).Value, 5)
                                            DAr12.DWidth = Math.Round(DgvI.Item(5, 0).Value, 5)
                                            DAr12.DHeight = Math.Round(DgvI.Item(6, 0).Value, 5)

                                            Dim Pt As New CDMidPoint            'Dim pt As New CDPoint

                                            Pt.X = Ar1.DLengths
                                            Pt.Y = Ar1.DWidth
                                            Pt.Z = Ar1.DHeight
                                            ItmNm = DgvI.Item(1, 0).Value

                                            Dim Hg As Integer
                                            'Hg = stuffy(Arc, Ar12, True, True, qty, ItmNm)
                                            MsgBox((Hg - 1).ToString & " items placed")
                                            Hg = 0
                                            'Closef(OutFile)

                                        End If

                                        ShowEmp = True

                                    End If

                                    Dim EmVol As Double = 0

                                    For Kk As Integer = 0 To CDLst.Count - 1
                                        EmVol = EmVol + (CDLst(Kk).DLengths * CDLst(Kk).DWidth * CDLst(Kk).DHeight)
                                    Next

                                    EmVol = EmVol * (0.0254 * 0.0254 * 0.0254)
                                    TxtFreeCbm.Text = Format(EmVol, "0.000")
                                    TxtOccuCbm.Text = Format((CDbl(TxtCapacity.Text) - CDbl(TxtFreeCbm.Text)), "0.000")

                                    If DgvI.CurrentCell.ColumnIndex = 12 Then
                                        ShowEmp = False
                                    ElseIf DgvI.CurrentCell.ColumnIndex = 13 Then
                                        ShowEmp = True
                                    End If

                                    Dim Mn As Integer = 0

                                    Dim Are As CDArea
                                    CDLstmm.Clear()

                                    Dim Vol1 As Double

                                    For jjj As Integer = 0 To CDLst2.Count - 1
                                        Vol1 = Vol1 + (CDLst2(jjj).DLengths * CDLst2(jjj).DWidth * CDLst2(jjj).DHeight)
                                    Next

                                    For Rr As Integer = 0 To CDLst2.Count - 1
                                        Are = New CDrum
                                        Are.DStrtPt.x = CDLst2(Rr).DStrtPt.x
                                        Are.DStrtPt.y = CDLst2(Rr).DStrtPt.y
                                        Are.DStrtPt.z = CDLst2(Rr).DStrtPt.z
                                        Are.DLengths = CDLst2(Rr).DLengths
                                        Are.DWidth = CDLst2(Rr).DWidth
                                        Are.DHeight = CDLst2(Rr).DHeight
                                        CDLstmm.Add(Are)
                                    Next

                                    CDLst.Clear()
                                    ReDim Ar2(0)
                                    ReDim Ar2(0)
                                    ReDim Ari2(0)
                                    ReDim Arwt2(0)
                                    ReDim TranspArr2(0)
                                    ReDim Dtopup(0)

                                    'Three Comment Mark 

                                    For i As Integer = 0 To DItemNoSA

                                        If CInt(DgvI.Item(11, i).Value) > DqtylstSA(i) + 1 Then

                                            Dim Qtyv As Integer

                                            If DqtylstSA(i) <= 0 Then
                                                Qtyv = 0
                                            Else
                                                Qtyv = DqtylstSA(i) + 1
                                            End If
                                            MsgBox(DgvI.Item(11, i).Value.ToString & " no of " & DgvI.Item(1, i).Value & " cannot be placed." & vbCrLf & CStr(Qtyv) & " placed.", MsgBoxStyle.Information + vbOKOnly)
                                            DgvI.Item(11, i).Value = Qtyv
                                            DrwStp = DrwStp - DqtylstSA(i) + DplclstSA(i) + 1
                                            DqtylstSA(i) = DplclstSA(i) + 1

                                        End If
                                    Next

                                    'Three Commenting Marks

                                    If Not CheckBox1.Checked Then
                                        TxtOccuKgs.Text = Format(CDbl(DgvI.Item(8, DgvI.CurrentCell.RowIndex).Value) * (DplclstSA(CInt(DgvI.CurrentCell.RowIndex)) + 1), "0.000")
                                        TxtFreeKgs.Text = Format(CDbl(TxtPayLoad.Text) - CDbl(TxtOccuKgs.Text), "0.000")

                                        For i As Integer = 0 To RowNo1
                                            Dim qtyv As Integer = DplclstSA(i)
                                            qtyv += 1
                                            If CheckBox1.Checked = True Then
                                                If fullflag Then
                                                    'qtyv = xcnt - 1
                                                    qtyv = xcnt
                                                Else
                                                    qtyv = xcnt
                                                End If
                                            End If
                                            If CInt(DgvI.Item(11, i).Value) > qtyv Then
                                                MsgBox(DgvI.Item(11, i).Value.ToString & " no of " & DgvI.Item(1, i).Value & " cannot be placed." & vbCrLf & CStr(qtyv) & " placed.", MsgBoxStyle.Information + vbOKOnly)
                                                DgvI.Item(11, i).Value = qtyv
                                            End If
                                        Next

                                        DplclstfSA.Clear()
                                        For i As Integer = 0 To DplclstSA.Count - 1
                                            DplclstfSA.Add(DplclstSA(i) + 1)
                                        Next
                                        k = 0
                                        For m = 0 To DplclstfSA.Count - 1
                                            If DplclstfSA(m) = 0 Then
                                                k = m - 1
                                                Exit For
                                            End If
                                        Next

                                        If k = 0 Then
                                            k = m - 1
                                        End If

                                        TotQty = 0
                                        Dim bn As Integer
                                        If MatchIdx = -1 Then
                                            bn = 0
                                        Else
                                            bn = MatchIdx
                                        End If
                                        For i As Integer = 0 To DqtylstSA.Count - 1
                                            TotQty = TotQty + DqtylstSA(i)
                                        Next

                                        PlcQty = 0
                                        For i As Integer = 0 To DplclstfSA.Count - 1
                                            PlcQty = PlcQty + DplclstfSA(i)
                                        Next

                                        Do While Not dgEmpty.RowCount = 0
                                            Try
                                                dgEmpty.Rows.Remove(dgEmpty.Rows(0))
                                            Catch
                                                Exit Do
                                            End Try
                                        Loop
                                        Do While Not dgUsage.RowCount = 0
                                            Try
                                                dgUsage.Rows.Remove(dgUsage.Rows(0))
                                            Catch
                                                Exit Do
                                            End Try
                                        Loop

                                        Call DrumButton3_ClickDHE(Nothing, Nothing)
                                        DrumEndfDHE(CurDir() & "\First.wrl")
                                        DEventless()
                                    End If
                                End If

                                '$#
                                'siSW.Close()
                                '------------------------------------------------
                                DrumsToolStripStatusLabel.Text = ""

                                'Dim RsltStr As String
                                'Dim RsltSv As String

                                'RsltSv = MessageBox.Show("Auto file save ", "Stuff viewer Drum file save", MessageBoxButtons.YesNo, MessageBoxIcon.Information)

                                'Dim Ofd As Stuff_Viewers = New Stuff_Viewers
                                'Ofd.DestroyOldFile("C:\CSP.Drum.wrl")

                                ''If RsltSv = MsgBoxResult.Yes Then
                                'DrumFinalOutPutWriter()
                                ''Else

                                'Stuff_Viewers.Show()
                                'Stuff_Viewers.Focus()
                                ''End If

                                ''RsltStr = MsgBox("Do you show stuffing in three dimensional (Isometric) view ?", MsgBoxStyle.YesNo, "3DViewer")
                                ''If RsltStr = MsgBoxResult.Yes Then

                                'ThreeDViewerDrumDHE() ' (3D)Three Dimentional Arrangement are shown

                                '##############

                                Try

                                    Dim FName As String = CurDir() & "\First.wrl"
                                    Process.Start("c:\Program Files\Alteros 3D\alteros.exe", FName)

                                Catch Err As Exception
                                    MsgBox(Err.Message)
                                    MsgBox(Err.ToString)
                                    MessageBox.Show("Error in Alteros 3D running", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End Try

                                '##############

                                'Else
                                'Dim Str As String

                                'Str = MsgBox("Do you close stuffing entry?", MsgBoxStyle.YesNo, "Stuffing Entry ...")
                                'If Str = MsgBoxResult.Yes Then
                                'Me.Close()
                                'Else
                                'Me.Focus()
                                ' End If

                                DplclstSA.Clear()
                                DqtylstSA.Clear()
                                'End If

                                '------------------------------------------------
                            End If

                        Catch Ex As Exception
                            DrumsToolStripStatusLabel.Text = ""
                            MsgBox(Ex.Message)
                            MsgBox(Ex.ToString)
                            MessageBox.Show("Error in ShowButton_MouseClick" & vbCrLf & "Programme Running is failure!", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            connDrums.Close()
                            siSW.Close()
                        End Try

                    End If

                End If


            Catch Err As Exception
                MsgBox(Err.Message)
                MsgBox(Err.ToString)
                MessageBox.Show("Error in ShowButton_MouseClick", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            '#####################################################################################################

            '$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
            'Cross Arangement Starts Here
            '$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

        ElseIf FlgArngmnt = True Then

            CAFRA = False               'Initialise flag

            btnStatus.ImageIndex = 0
            lblStatus.Visible = True
            lblStatus.Text = "Please wait....."

            MessageBox.Show("The cross row column arrangement is shown!", "Display Arrangement .....", MessageBoxButtons.OK, MessageBoxIcon.Information)

            lblArrangement.BackColor = Color.Pink
            lblStatus.Visible = False
            lblStatusINm.Visible = False
            Dim Ans As MsgBoxResult

            DrmRWidx = DgvI.CurrentCell.RowIndex
            Dim RowNo1 As Integer = DrmRWidx
            Dim PlcLst1 As New List(Of Integer)
            chkwt = True

            Try

                If DgvI.CurrentCell.ColumnIndex = 12 Or DgvI.CurrentCell.ColumnIndex = 13 Or DgvI.CurrentCell.ColumnIndex = 14 Then
                    If DgvI.Item(1, RowNo1).Value Is Nothing _
                OrElse DgvI.Item(11, RowNo1).Value Is Nothing _
                OrElse Not IsNumeric(DgvI.Item(11, RowNo1).Value) _
                OrElse CInt(DgvI.Item(11, RowNo1).Value) <= 0 _
                OrElse DgvI.Item(11, RowNo1).Value.ToString.Contains(".") _
                Then
                        If DgvI.CurrentCell.ColumnIndex <> 14 Then
                            MsgBox("Cannot show this item." & ControlChars.CrLf & "Item name not selected or quantity is invalid", MsgBoxStyle.Critical + vbOKOnly)
                            Exit Sub
                        End If

                    End If

                    If DgvI.CurrentCell.ColumnIndex <> 14 Then
                        Ans = MsgBoxResult.Yes
                        If Ans = MsgBoxResult.Yes Then
                            For i As Integer = 0 To DgvI.RowCount - 1
                                If DgvI.Item(1, i).Value Is Nothing _
                                OrElse DgvI.Item(8, i).Value Is Nothing _
                                OrElse DgvI.Item(11, i).Value Is Nothing _
                                OrElse Not IsNumeric(DgvI.Item(8, i).Value) _
                                OrElse Not IsNumeric(DgvI.Item(11, i).Value) _
                                OrElse CInt(DgvI.Item(8, i).Value) < 0 _
                                OrElse CInt(DgvI.Item(11, i).Value) <= 0 _
                                OrElse DgvI.Item(11, i).Value.ToString.Contains(".") _
                                OrElse DgvI.Item(11, i).Value.ToString.Contains(".") _
                                Then
                                    Try
                                        DgvI.Rows.Remove(DgvI.Rows(i))
                                    Catch
                                        Exit For
                                    End Try
                                    i -= 1
                                    If i < RowNo1 Then

                                    End If
                                End If
                            Next
                        Else
                            Exit Sub
                        End If
                    End If

                    If CmbContainer.Text = "" Then
                        MsgBox("Container not selected", MsgBoxStyle.Critical + vbOKOnly)
                        CmbContainer.Focus()
                        Exit Sub
                    End If
                    DItemNoCA = 0
                    Dim StE3 As New StructE1
                    Dim qtyarr1 As New List(Of StructE1)
                    qtyarr1.Clear()
                    For i As Integer = 0 To RowNo1
                        StE3.ItmNm = DgvI.Item(1, i).Value
                        StE3.Qty = DgvI.Item(11, i).Value
                        qtyarr1.Add(StE3)
                    Next

                    'DStop

                    TxtFreeCbm.Clear()
                    TxtOccuCbm.Clear()

                    'Dim Ptx As New CPoint
                    'Ptx.x = Arc.DLengths
                    'Ptx.y = Arc.DWidth
                    'Ptx.z = Arc.DHeight

                    Dim Ptx As New CDrum
                    Ptx.DStrtPt.x = Arc.DLengths
                    Ptx.DStrtPt.y = Arc.DWidth
                    Ptx.DStrtPt.z = Arc.DHeight

                    'The child class drum used in following function
                    WrVrmlDrmContnrStrt(CurDir() & "\First.wrl", True, Ptx)      'WrVrmlStrt(CurDir() & "\DVRML.wrl", True, Ptx)

                    '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

                    Dim PutQty As Integer

                    Dim MatchIdx As Integer = -1

                    If MatchIdx = 0 Then MatchIdx = -1
                    If MatchIdx = -1 Then
                        CDLst.Clear()

                        Dim CmdSd As New OleDb.OleDbCommand

                        CmdSd.Connection = connDrums
                        CmdSd.CommandText = "delete from stuffdata"
DrumCAxx:
                        Try
                            CmdSd.ExecuteNonQuery()

                        Catch Ex As Exception
                            If Ex.Message = "Cannot open any more tables." Then
                                connDrums.Close()
                                connDrums.Dispose()
                                OleDb.OleDbConnection.ReleaseObjectPool()
                                CmdSd.Dispose()
                                GC.Collect()

                                connDrums.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\Drums.mdb;Persist Security Info=False"

                                connDrums.Open()
                                GoTo drumCAxx
                            End If

                        End Try

                        '*************************************************************************
                        'Container Writing Program  is starting here
                        '*************************************************************************

                        Arc.AutoDrawDrm(CurDir() & "First.wrl", ContnrColor, 0.5, "", "", 0, True, False, "container", 0, True, "B")

                        Dim Ard As New CDArea
                        Ard.DStrtPt.x = Arc.DLengths
                        Ard.DStrtPt.y = 0
                        Ard.DStrtPt.z = 0
                        Ard.DLengths = 0.5
                        Ard.DWidth = Arc.DWidth
                        Ard.DHeight = Arc.DHeight

                        Ard.AutoDrawDrm(CurDir() & "\First.wrl", ContnrColor, 0, "file:///c:\contdoor.png", "", 0, True, False, "door", 0, False, "B")

                        Dim Ard1 As New CDArea
                        Ard1.DStrtPt.x = Arc.DLengths - 0.01
                        Ard1.DStrtPt.y = 0
                        Ard1.DStrtPt.z = 0
                        Ard1.DLengths = 0.5
                        Ard1.DWidth = Ard.DWidth
                        Ard1.DHeight = Ard.DHeight

                        Ard1.AutoDrawDrm(CurDir() & "First.wrl", ContnrColor, 0, "file:///c:\contdoor.png", "", 0, True, False, "door1", 0, False, "B")

                        DstrtclrCA = "r"
                    Else

                        PutQty = 0
                        For i As Integer = 0 To MatchIdx - 1
                            PutQty += qtyarr1(i).Qty
                        Next
                        CDLst.Clear()
                        If MatchIdx <> -1 Then
                            For i As Integer = 0 To dsQtyArr(MatchIdx - 1).E1StLst.Count - 1
                                CDLst.Add(dsQtyArr(MatchIdx - 1).E1StLst(i))
                            Next
                        End If

                        Arc.AutoDrawDrm(CurDir() & "\First.wrl", ContnrColor, 0.5, "", "", 0, True, False, "container", 0, True, "B")

                        Dim Ard As New CDArea

                        Ard.DStrtPt.x = Arc.DLengths
                        Ard.DStrtPt.y = 0
                        Ard.DStrtPt.z = 0
                        Ard.DLengths = 0.5
                        Ard.DWidth = Arc.DWidth
                        Ard.DHeight = Arc.DHeight

                        Ard.AutoDrawDrm(CurDir() & "\First.wrl", ContnrColor, 0, "file:///c:\contdoor.png", "", 0, True, False, "door", 0, False, "B")

                        Dim Ard1 As New CDArea

                        Ard1.DStrtPt.x = Arc.DLengths - 0.01
                        Ard1.DStrtPt.y = 0
                        Ard1.DStrtPt.z = 0
                        Ard1.DLengths = 0.5
                        Ard1.DWidth = Ard.DWidth
                        Ard1.DHeight = Ard.DHeight

                        Ard1.AutoDrawDrm(CurDir() & "First.wrl", ContnrColor, 0, "file:///c:\contdoor.png", "", 0, True, False, "door1", 0, False, "B")

                        'Dim col1 As String = "r"

                        Dim col1 As String = Nothing

                        DPlcLstCA.Clear()
                        DQtyLstCA.Clear()

                        qtyarr.Clear()

                        Dim LstAhistArr1 As New List(Of StructR1)

                        LstAhistArr1.Clear()
                        lblStatus.Text = "Please wait....."         'Form8.Label1.Text = "Please wait...."
                        'Form8.Label2.Text = ""
                        btnStatus.Visible = False                   'Form8.Button1.Visible = False
                        lblStatus.Visible = True                    'Form8.Show()
                        lblStatusINm.Visible = True

                        If DgvI.CurrentCell.ColumnIndex = 12 Then
                            ShowEmp = False
                        ElseIf DgvI.CurrentCell.ColumnIndex = 13 Then
                            ShowEmp = True
                        End If

                        If CDLst.Count = 0 Then
                            If ShowEmp Then
                                MsgBox("Container Is Fully Occupied. No Empty Area Left", MsgBoxStyle.Critical + vbOKOnly)
                                Exit Sub
                            End If
                        End If

                        Dim Ar11 As New CDArea

                        For i As Integer = 0 To CDLst.Count - 1
                            Ar11 = CDLst(i)

                            If ShowEmp Then

                                Ar11.AutoDrawDrm(CurDir() & "First.wrl", ContnrColor, 0, "", CStr(i + 1), 0, False, True, "E", 0, False, "B")

                            End If

                        Next

                        'Above Up to 30 May 2k8


                        If ShowEmp Then
                            Try
                                DrumEndfDHE(CurDir() & "\First.wrl")
                                lblStatus.Visible = False            'Form8.Close()
                                lblStatusINm.Visible = False
                                btnStatus.Visible = False

                                '##############

                                Try

                                    Dim FName As String = CurDir() & "\First.wrl"
                                    Process.Start("c:\Program Files\Alteros 3D\alteros.exe", FName)

                                Catch Err As Exception
                                    MsgBox(Err.Message)
                                    MsgBox(Err.ToString)
                                    MessageBox.Show("Error in Alteros 3D running", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End Try

                                '##############

                                'Dim RsultStr As String

                                'RsultStr = MsgBox("Do you show stuffing in three dimensional (Isometric) view ?", MsgBoxStyle.YesNo, "3DViewer")
                                'If RsultStr = MsgBoxResult.Yes Then

                                '    ThreeDViewerDrumDHE() ' (3D)Three Dimentional Arrangement are shown 
                                'Else
                                '    Dim Str As String

                                '    Str = MsgBox("Do you close stuffing entry?", MsgBoxStyle.YesNo, "Stuffing Entry ...")
                                '    If Str = MsgBoxResult.Yes Then
                                '        Me.Close()
                                '    Else
                                '        Me.Focus()
                                '    End If
                                'End If

                            Catch Ex As Exception

                                MsgBox(Ex.Message) 'MsgBox(Ex.Message, MsgBoxStyle.Critical, "Message :: In method 'MouseClick'  " & vbCrLf & "VRML Programme Running is failure!")
                                MsgBox(Ex.ToString)
                                MessageBox.Show("Error in ShowButton_MouseClick" & vbCrLf & "VRML Programme Running is failure!", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Me.Close()

                            Finally
                                lblStatus.Visible = False            'Form8.Close()
                                lblStatusINm.Visible = False
                                btnStatus.Visible = False
                            End Try

                            Exit Sub
                        End If

                        Dim Qtyx As Integer = 0

                        dsItemNo = 0

                        For i As Integer = 0 To PutQty - 1
                            Qtyx += 1
                            LstAhistArr(i).Ar.AutoDrawDrm(CurDir() & "First.wrl", ContnrColor, 0, "file\\\c:\t2.png", LstAhistArr(i).ItmNm, 0, False, True, "", LstAhistArr(i).Method, False, "B")
                            LstAhistArr1.Add(LstAhistArr(i))
                            If i = PutQty - 1 Then
                                PlcLst1.Add(Qtyx)

                                DQtyLstCA.Add(Qtyx)

                                Dim Stm1 As New StructE1
                                Stm1.ItmNm = LstAhistArr(i).ItmNm
                                Stm1.Qty = Qtyx
                                Stm1.E1StLst = LstAhistArr(i).R1CDLst
                                dsQtyArr.Add(Stm1)

                                Qtyx = 0
                                Exit For
                            End If
                            If LstAhistArr(i).ItmNm <> LstAhistArr(i + 1).ItmNm Then
                                dsItemNo += 1
                                If col1 = "r" Then
                                    col1 = "g"
                                ElseIf col1 = "g" Then
                                    col1 = "b"
                                ElseIf col1 = "b" Then
                                    col1 = "m"
                                ElseIf col1 = "m" Then
                                    col1 = "c"
                                ElseIf col1 = "c" Then
                                    col1 = "y"
                                End If
                                PlcLst1.Add(Qtyx)
                                DQtyLstCA.Add(Qtyx)

                                Dim Stm1 As New StructE1
                                Stm1.ItmNm = LstAhistArr(i).ItmNm
                                Stm1.Qty = Qtyx
                                Stm1.E1StLst = LstAhistArr(i).R1CDLst
                                dsQtyArr.Add(Stm1)
                                Qtyx = 0
                            End If

                        Next

                        dsItemNo += 1

                        lblStatus.Visible = False             'Form8.Close()
                        lblStatusINm.Visible = False

                        LstAhistArr.Clear()

                        For i As Integer = 0 To LstAhistArr1.Count - 1
                            LstAhistArr.Add(LstAhistArr1(i))

                        Next

                        DPlcLstCA.Clear()

                        For i As Integer = 0 To DQtyLstCA.Count - 1
                            DPlcLstCA.Add(DQtyLstCA(i) - 1)
                        Next

                        If col1 = "r" Then
                            col1 = "g"
                        ElseIf col1 = "g" Then
                            col1 = "b"
                        ElseIf col1 = "b" Then
                            col1 = "m"
                        ElseIf col1 = "m" Then
                            col1 = "c"
                        ElseIf col1 = "c" Then
                            col1 = "y"
                        End If

                        DstrtclrCA = col1

                    End If

                    siSW.WriteLine("]}]}]}]}]}")

                    '*************************************************************************
                    'Container Writing Program  is finished here
                    '*************************************************************************

                    'DStop

                    Dim CDLst1 As New List(Of CDArea)
                    Dim CDLst2 As New List(Of CDArea)

                    Dim Qtyf As Boolean = False
                    Dim RowLvFlg As Boolean = False

                    Dim dsStp As Integer
                    Dim Cntm As Integer = 1

                    Dim TotQty = 25

                    Dim TotQty1 As Integer = 0

                    Dim DrwStp As Integer

                    Dim CntFlg As Boolean = False

                    Dim Flg1 As Boolean = True

                    Dim Button1Flag As Boolean = False

                    Dim ItmNm As String

                    Button1Flag = True

                    Dim Cnt As Integer = 0
                    Dim DupFlg As Boolean = False

                    Cnt = 0

                    Dim Ar() As CDArea

                    Dim Ari() As String
                    Dim Arwt() As Single

                    Dim Ar1 As New CDArea

                    Dim Dln As Double
                    Dim Dwd As Double
                    Dim Dht As Double
                    Dim DRdus As Double
                    Dim Dqty As Integer
                    Dim Dseq As Integer
                    Dim Dwt As String
                    Dim Dtransparr() As Boolean
                    Dim Dtransp As Boolean
                    Dim Dtopup() As Boolean
                    Dim Dtpup As Boolean

                    ReDim Ar(0)
                    ReDim Ari(0)
                    ReDim Arwt(0)
                    ReDim Dtransparr(0)
                    ReDim Dtopup(0)

                    Dim Cmd As New OleDb.OleDbCommand

                    Dim Cntx As Integer = 0

                    Dim PlcQty As Integer = 0

                    Dim k As Integer
                    Dim m As Integer

                    Try
                        DeleteTable("DTemp1")
                        If CmbContainer.Text = "" Then
                            MsgBox("Container not selected", MsgBoxStyle.Critical + vbOKOnly)
                            CmbContainer.Focus()
                            Exit Sub
                        End If

                        lblStatus.Text = "Please wait...."      'Form8.Label1.Text = "Please wait...."
                        'Form8.Label2.Text = ""
                        btnStatus.Visible = False       'Form8.Button1.Visible = False
                        lblStatus.Visible = True        'Form8.Show()
                        lblStatusINm.Visible = True
                        lblStatus.Refresh()
                        lblStatusINm.Refresh()
                        System.Windows.Forms.Application.DoEvents()

                        Dim i1, j1 As Integer
                        Dim ExtFlg As Boolean = False

                        Dim Zz As Integer

                        Zz = RowNo1

                        Dim MatchIdx1 As Integer

                        If MatchIdx = -1 Then
                            MatchIdx1 = 0
                        Else
                            MatchIdx1 = MatchIdx
                        End If

                        'DDStop

                        For i1 = MatchIdx1 To Zz

                            ItmNm = DgvI.Item(1, i1).Value
                            Dln = Math.Round(DgvI.Item(4, i1).Value, 4)
                            Dwd = Math.Round(DgvI.Item(5, i1).Value, 4)
                            Dht = Math.Round(DgvI.Item(6, i1).Value, 4)
                            Dqty = DgvI.Item(11, i1).Value

                            'Stop
                            '///////////Radius manupulation
                            If Dln = Dwd Then

                                DRdus = (Dln + Dwd) * 0.25

                            ElseIf Dln <> Dwd Then

                                MessageBox.Show("The diameter-> length and widths are not same", "ShowButton_MouseClick :: Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                            Else

                                MessageBox.Show("The diameter-> length and widths are Inadequate", "ShowButton_MouseClick :: Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                MsgBox("Application Exit!")
                                GC.Collect()
                                Application.Exit()
                            End If

                            'DStop

                            Dwt = DgvI.Item(8, i1).Value
                            Dseq = DgvI.Item(0, i1).Value
                            Dtransp = False

                            Dtpup = IIf(DgvI.Item(7, i1).Value = "6", False, True)
                            DQtyLstCA.Add(Dqty)

                            For j1 = 0 To Dqty - 1

                                TotQty1 += 1

                                Qtyf = True

                                Ar1.DLengths = Dln
                                Ar1.DWidth = Dwd
                                Ar1.DHeight = Dht
                                Ar1.DRadius = DRdus
                                Ar1.DStrtPt.x = 0
                                Ar1.DStrtPt.y = 0
                                Ar1.DStrtPt.z = 0

                                Ar(UBound(Ar)) = New CDArea
                                Ar(UBound(Ar)).DLengths = Ar1.DLengths
                                Ar(UBound(Ar)).DWidth = Ar1.DWidth
                                Ar(UBound(Ar)).DHeight = Ar1.DHeight
                                Ar(UBound(Ar)).DRadius = Ar1.DRadius
                                Ari(UBound(Ari)) = ItmNm
                                Arwt(UBound(Arwt)) = Dwt
                                Dtransparr(UBound(Dtransparr)) = Dtransp
                                Dtopup(UBound(Dtopup)) = Dtpup
                                ReDim Preserve Ar(UBound(Ar) + 1)
                                ReDim Preserve Ari(UBound(Ari) + 1)
                                ReDim Preserve Arwt(UBound(Arwt) + 1)
                                ReDim Preserve Dtransparr(UBound(Dtransparr) + 1)
                                ReDim Preserve Dtopup(UBound(Dtopup) + 1)
                            Next

                        Next i1

                        'DDDStop

                        DPlcLstfCA.Clear()

                    Catch Ex As Exception
                        MsgBox(Ex.Message)
                        MsgBox(Ex.ToString)
                        MessageBox.Show("Error in TransactionsMenu", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try

                    For i As Integer = 0 To DPlcLstCA.Count - 1
                        DPlcLstfCA.Add(DPlcLstCA(i) + 1)
                    Next

                    For m = 0 To DPlcLstfCA.Count - 1
                        If DPlcLstfCA(m) = 0 Then
                            k = m - 1
                            Exit For
                        End If
                    Next

                    If k = 0 Then
                        k = m - 1
                    End If

                    If k = 0 Then
                        k = m + 1
                    End If

                    TotQty = 0
                    For i As Integer = 0 To DQtyLstCA.Count - 1
                        TotQty = TotQty + DQtyLstCA(i)
                    Next

                    PlcQty = 0
                    For i As Integer = 0 To DPlcLstfCA.Count - 1
                        PlcQty = PlcQty + DPlcLstfCA(i) - 1
                    Next

                    ReDim Preserve Ar(UBound(Ar) - 1)
                    ReDim Preserve Ari(UBound(Ari) - 1)
                    ReDim Preserve Arwt(UBound(Arwt) - 1)
                    ReDim Preserve Dtransparr(UBound(Dtransparr) - 1)
                    ReDim Preserve Dtopup(UBound(Dtopup) - 1)

                    dsStp += 1

                    Dim Ar2() As CDArea
                    Dim Ari2() As String
                    Dim Arwt2() As Single
                    Dim TranspArr2() As Boolean

                    ReDim Ar2(0)
                    ReDim Ari2(0)
                    ReDim Arwt2(0)
                    ReDim TranspArr2(0)

                    'DStop

                    For i As Integer = LBound(Ar) To UBound(Ar)

                        Ar2(UBound(Ar2)) = Ar(i)
                        Ari2(UBound(Ari2)) = Ari(i)
                        Arwt2(UBound(Arwt2)) = Arwt(i)
                        TranspArr2(UBound(TranspArr2)) = Dtransparr(i)
                        ReDim Preserve Ar2(UBound(Ar2) + 1)
                        ReDim Preserve Ari2(UBound(Ari2) + 1)
                        ReDim Preserve Arwt2(UBound(Arwt2) + 1)
                        ReDim Preserve TranspArr2(UBound(TranspArr2) + 1)
                        ReDim Preserve Dtopup(UBound(Dtopup) + 1)
                    Next

                    ReDim Preserve Ar2(UBound(Ar2) - 1)
                    ReDim Preserve Ari2(UBound(Ari2) - 1)
                    ReDim Preserve Arwt2(UBound(Arwt2) - 1)
                    ReDim Preserve TranspArr2(UBound(TranspArr2) - 1)

                    'DDDStop

                    Try
                        ReDim Preserve Dtopup(UBound(Dtopup) - 1)
                    Catch

                    End Try

                    If dsStp = DgvI.RowCount Then
                        dsStp = 0
                        Cnt = 0
                    End If

                    'DDDStop

                    Arc.DStrtPt.x = 0
                    Arc.DStrtPt.y = 0
                    Arc.DStrtPt.z = 0
                    Arc.DLengths = ContArr(0)
                    Arc.DWidth = ContArr(1)
                    Arc.DHeight = ContArr(2)
                    Dqty = 0

                    'DDDStop

                    'Arc.DLengths = 188
                    'Arc.DWidth = 92
                    'Arc.DHeight = 94


                    lblStatus.Visible = False            'Form8.Close()
                    btnStatus.Visible = False

                    Dim OutFile As String = CurDir() & "\First.wrl"

                    If Ar.Length > 0 Then
                        If CDLst.Count = 0 Then CDLst.Add(Arc)
                        DItemQtyCA = 0
                        DPlcLstCA.Clear()
                        Dtxtopt = False

                        If DgvI.CurrentCell.ColumnIndex = 12 Then
                            If Not CheckBox1.Checked Then

                                'Stop

                                'Implements for cross arrangement                         'CDLst2 = DrumStuff(Arc, Ar2, Ari2, Arwt2, False, False, OutFile, True, TranspArr2, Dtopup, Dtxtopt, True, False, True, ColArr)

                                CAFRA = False

                                CheckOneRowGrid()         'Remove comment

                                If CAFRA Then

                                    CDLst2 = DSgrCrossStuff(Arc, Ar2, Ari2, Arwt2, False, False, OutFile, True, TranspArr2, Dtopup, Dtxtopt, True, False, True, ColArr)

                                Else

                                    'DDDStop

                                    'Impliments here from 3 July 2K8

                                    'CDLst2 = DMgrCrossStuff(Arc, Ar2, Ari2, Arwt2, False, False, OutFile, True, TranspArr2, Dtopup, Dtxtopt, True, False, True, ColArr)


                                    CDLst2 = DNxtgrCrossStuff(Arc, Ar2, Ari, Arwt2, False, False, OutFile, True, TranspArr2, Dtopup, Dtxtopt, True, False, True, ColArr)
                                    'Stop

                                    'siSW.Close()


                                    'MessageBox.Show("The second row in grid arrangement of item is placed in different function", "Info.....", MessageBoxButtons.OK, MessageBoxIcon.Information)

                                End If


                                '*********@

                            Else

                                Stop

                                Dim DAr12 As New CDrum                 'Dim Ar12 As New CDArea

                                Dqty = DgvI.Item(11, 0).Value

                                DAr12.DStrtPt.x = 0
                                DAr12.DStrtPt.y = 0
                                DAr12.DStrtPt.z = 0
                                DAr12.DLengths = Math.Round(DgvI.Item(4, 0).Value, 5)
                                DAr12.DWidth = Math.Round(DgvI.Item(5, 0).Value, 5)
                                DAr12.DHeight = Math.Round(DgvI.Item(6, 0).Value, 5)

                                Dim Pt As New CDMidPoint            'Dim pt As New CDPoint

                                Pt.X = Ar1.DLengths
                                Pt.Y = Ar1.DWidth
                                Pt.Z = Ar1.DHeight
                                ItmNm = DgvI.Item(1, 0).Value

                                Dim Hg As Integer
                                'Hg = stuffy(Arc, Ar12, True, True, qty, ItmNm)
                                MsgBox((Hg - 1).ToString & " items placed")
                                Hg = 0
                                'Closef(OutFile)

                            End If

                            'DDDStop
                            'siSW.Close()

                            ShowEmp = True

                        End If

                        Dim EmVol As Double = 0

                        For Kk As Integer = 0 To CDLst.Count - 1
                            EmVol = EmVol + (CDLst(Kk).DLengths * CDLst(Kk).DWidth * CDLst(Kk).DHeight)
                        Next

                        EmVol = EmVol * (0.0254 * 0.0254 * 0.0254)
                        TxtFreeCbm.Text = Format(EmVol, "0.000")
                        TxtOccuCbm.Text = Format((CDbl(TxtCapacity.Text) - CDbl(TxtFreeCbm.Text)), "0.000")

                        If DgvI.CurrentCell.ColumnIndex = 12 Then
                            ShowEmp = False
                        ElseIf DgvI.CurrentCell.ColumnIndex = 13 Then
                            ShowEmp = True
                        End If

                        Dim Mn As Integer = 0

                        Dim Are As CDArea
                        CDLstmm.Clear()

                        Dim Vol1 As Double

                        For jjj As Integer = 0 To CDLst2.Count - 1
                            Vol1 = Vol1 + (CDLst2(jjj).DLengths * CDLst2(jjj).DWidth * CDLst2(jjj).DHeight)
                        Next

                        For Rr As Integer = 0 To CDLst2.Count - 1
                            Are = New CDrum
                            Are.DStrtPt.x = CDLst2(Rr).DStrtPt.x
                            Are.DStrtPt.y = CDLst2(Rr).DStrtPt.y
                            Are.DStrtPt.z = CDLst2(Rr).DStrtPt.z
                            Are.DLengths = CDLst2(Rr).DLengths
                            Are.DWidth = CDLst2(Rr).DWidth
                            Are.DHeight = CDLst2(Rr).DHeight
                            CDLstmm.Add(Are)
                        Next

                        CDLst.Clear()
                        ReDim Ar2(0)
                        ReDim Ar2(0)
                        ReDim Ari2(0)
                        ReDim Arwt2(0)
                        ReDim TranspArr2(0)
                        ReDim Dtopup(0)

                        'Three Comment Mark 

                        DEventless()
                        'DDDStop

                        For i As Integer = 0 To DItemNoCA

                            If CInt(DgvI.Item(11, i).Value) > DQtyLstCA(i) + 1 Then

                                Dim Qtyv As Integer

                                If DQtyLstCA(i) <= 0 Then
                                    Qtyv = 0
                                Else
                                    Qtyv = DQtyLstCA(i) + 1
                                End If
                                MsgBox(DgvI.Item(11, i).Value.ToString & " no of " & DgvI.Item(1, i).Value & " cannot be placed." & vbCrLf & CStr(Qtyv) & " placed.", MsgBoxStyle.Information + vbOKOnly)
                                DgvI.Item(11, i).Value = Qtyv
                                DrwStp = DrwStp - DQtyLstCA(i) + DPlcLstCA(i) + 1
                                DQtyLstCA(i) = DPlcLstCA(i) + 1

                            End If
                        Next

                        'Three Commenting Marks

                        If Not CheckBox1.Checked Then
                            TxtOccuKgs.Text = Format(CDbl(DgvI.Item(8, DgvI.CurrentCell.RowIndex).Value) * (DPlcLstCA(CInt(DgvI.CurrentCell.RowIndex)) + 1), "0.000")
                            TxtFreeKgs.Text = Format(CDbl(TxtPayLoad.Text) - CDbl(TxtOccuKgs.Text), "0.000")

                            For i As Integer = 0 To RowNo1
                                Dim qtyv As Integer = DPlcLstCA(i)
                                qtyv += 1
                                If CheckBox1.Checked = True Then
                                    If fullflag Then
                                        'qtyv = xcnt - 1
                                        qtyv = xcnt
                                    Else
                                        qtyv = xcnt
                                    End If
                                End If

                                If 1 Then               'Row 1 of grid box iteam placed only

                                    qtyv = ItrQty

                                End If

                                If CInt(DgvI.Item(11, i).Value) > qtyv Then
                                    MsgBox(DgvI.Item(11, i).Value.ToString & " no of " & DgvI.Item(1, i).Value & " cannot be placed." & vbCrLf & CStr(qtyv) & " placed.", MsgBoxStyle.Information + vbOKOnly)
                                    DgvI.Item(11, i).Value = qtyv
                                End If
                            Next

                            DPlcLstfCA.Clear()
                            For i As Integer = 0 To DPlcLstCA.Count - 1
                                DPlcLstfCA.Add(DPlcLstCA(i) + 1)
                            Next
                            k = 0
                            For m = 0 To DPlcLstfCA.Count - 1
                                If DPlcLstfCA(m) = 0 Then
                                    k = m - 1
                                    Exit For
                                End If
                            Next

                            If k = 0 Then
                                k = m - 1
                            End If

                            TotQty = 0
                            Dim bn As Integer

                            If MatchIdx = -1 Then
                                bn = 0
                            Else
                                bn = MatchIdx
                            End If

                            For i As Integer = 0 To DQtyLstCA.Count - 1
                                TotQty = TotQty + DQtyLstCA(i)
                            Next

                            PlcQty = 0
                            For i As Integer = 0 To DPlcLstfCA.Count - 1
                                PlcQty = PlcQty + DPlcLstfCA(i)
                            Next

                            Do While Not dgEmpty.RowCount = 0
                                Try
                                    dgEmpty.Rows.Remove(dgEmpty.Rows(0))
                                Catch
                                    Exit Do
                                End Try
                            Loop

                            Do While Not dgUsage.RowCount = 0
                                Try
                                    dgUsage.Rows.Remove(dgUsage.Rows(0))
                                Catch
                                    Exit Do
                                End Try
                            Loop

                            Call DrumButton3_ClickDHE(Nothing, Nothing)
                            DEventless()
                            DrumEndfDHE(CurDir() & "\First.wrl")

                        End If
                    End If

                    '$#
                    'siSW.Close()
                    '------------------------------------------------
                    DrumsToolStripStatusLabel.Text = ""

                    'Dim RsltStr As String
                    'Dim RsltSv As String

                    'RsltSv = MessageBox.Show("Auto file save ", "Stuff viewer Drum file save", MessageBoxButtons.YesNo, MessageBoxIcon.Information)

                    'Dim Ofd As Stuff_Viewers = New Stuff_Viewers
                    'Ofd.DestroyOldFile("C:\CSP.Drum.wrl")

                    ''If RsltSv = MsgBoxResult.Yes Then
                    'DrumFinalOutPutWriter()
                    ''Else

                    'Stuff_Viewers.Show()
                    'Stuff_Viewers.Focus()
                    'End If

                    'RsltStr = MsgBox("Do you show stuffing in three dimensional (Isometric) view ?", MsgBoxStyle.YesNo, "3DViewer")
                    'If RsltStr = MsgBoxResult.Yes Then

                    'ThreeDViewerDrumDHE() ' (3D)Three Dimentional Arrangement are shown 

                    '##############

                    Try

                        Dim FName As String = CurDir() & "\First.wrl"
                        Process.Start("c:\Program Files\Alteros 3D\alteros.exe", FName)

                    Catch Err As Exception
                        MsgBox(Err.Message)
                        MsgBox(Err.ToString)
                        MessageBox.Show("Error in Alteros 3D running", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try

                    '##############

                    'Else
                    'Dim Str As String

                    'Str = MsgBox("Do you close stuffing entry?", MsgBoxStyle.YesNo, "Stuffing Entry ...")
                    'If Str = MsgBoxResult.Yes Then
                    'Me.Close()
                    'Else
                    'Me.Focus()
                    ' End If

                    DPlcLstCA.Clear()
                    DQtyLstCA.Clear()
                    'End If

                    '------------------------------------------------
                End If

            Catch Ex As Exception
                DrumsToolStripStatusLabel.Text = ""
                MsgBox(Ex.Message)
                MsgBox(Ex.ToString)
                MessageBox.Show("Error in ShowButton_MouseClick" & vbCrLf & "Programme Running is failure!", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
                connDrums.Close()
                siSW.Close()
            End Try

        End If

        'End If


        '    Catch Err As Exception
        '    MsgBox(Err.Message)
        '    MessageBox.Show("Error in ShowButton_MouseClick", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try

    End Sub

    Public Sub DrumEndfDHE(ByVal fn As String)

        Try
            siSW.WriteLine("#EMPTY AREA")
            siSW.WriteLine("")
            siSW.WriteLine("#END DRUM_STUFF PROGRAMME")
            siSW.WriteLine("")
            siSW.WriteLine("")
            siSW.WriteLine("# $$ Hazel Infotech Ltd $$ #")
            siSW.WriteLine("")
        Catch Ex As Exception
            MsgBox(Ex.Message)
            MessageBox.Show("Error in DrumEndfDHE" & vbCrLf & "DVRML Programme writting is failure!", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            siSW.Close()
            connDrums.Close()
        Finally
            siSW.Close()
            connDrums.Close()
        End Try

    End Sub

    Private Sub DgvI_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles DgvI.Scroll

        Try
            Me.showbutton1.Visible = False
            Me.ShowButton.Visible = False
            Me.DgvI.Columns(4).Visible = False
            Me.DgvI.Columns(5).Visible = False
            Me.DgvI.Columns(6).Visible = False
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in DgvI_Scroll", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally

        End Try

    End Sub

    Private Sub DgvI_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvI.CellContentClick

        Try
            Me.DgvI.Columns(4).Visible = True
            Me.DgvI.Columns(5).Visible = True
            Me.DgvI.Columns(6).Visible = True
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in DgvI_CellContentClick", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub chkbxArrangement_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkbxArrangement.CheckedChanged

        Try

            If chkbxArrangement.CheckState Then
                lblArrangement.Text = "Cross Row Column Arrangement"
                FlgArngmnt = True
                lblArrangement.BackColor = Color.Lavender
                GapVisibleT()

                SARDel() 'clear arrangement   'Remove Comment // 

                CARDel()        'Database Clear
                DCANxtDel()     'Drum CA nxt argmt Db clear

            Else
                lblArrangement.Text = "Simple Row Column Arrangement"
                FlgArngmnt = False
                lblArrangement.BackColor = Color.Pink
                GapVisibleF()
            End If

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in chkbxArrangement_CheckedChanged", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Box3DViewerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Box3DViewerToolStripMenuItem.Click

        Dim FName As String = "C:\CSP.Box.wrl"

        Try

            Process.Start("D:\Program Files\Alteros 3D\alteros.exe", FName)

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in btn3DViewersBox_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Drum3DViewerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Drum3DViewerToolStripMenuItem.Click

        Dim FName As String = "C:\CSP.Drum.wrl"

        Try

            Process.Start("D:\Program Files\Alteros 3D\alteros.exe", FName)

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in btn3DViewersDrum_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbtnRestart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnRestart.Click

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
            GC.Collect()
            Application.Exit()
            Try
                Process.Start(CurDir() & "\Container Stuff.exe")
            Catch Er As Exception
                MsgBox(Er.Message)
                MsgBox(Er.ToString)
                MessageBox.Show("Error in tsbtnRestart_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Try

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

    Private Sub tsbtnOtherTypeStuff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnOtherTypeStuff.Click

        MessageBox.Show(" Work in progress ", "Info.....", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub


    Private Sub tsbtnBoxDrumType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnBoxDrumType.Click

        MessageBox.Show(" Work in progress ", "Info.....", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub tsbtnDrumTypeStuff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnDrumTypeStuff.Click

        Try
            Me.Dispose(True)
            Me.Close()
            Call DrumStuffingActivity()

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in close drum stuffing activity.", "Error .....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbtnBoxTypeStuff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnBoxTypeStuff.Click

        Try

            Call cmdExit_Click(sender, e)

            MDIForm.Focus()
            Me.Close()
            GC.Collect()
            Try
                DisplayActivity.lblDisplayActivity.Visible = True
                DisplayActivity.lblDisplayActivity.Text = "Please wait..." & vbCrLf & "Box type stuffing activity show"
                DisplayActivity.Show()
            Catch ex As Exception
                Exit Try
            Finally
                TransactionMenu.Show()
            End Try

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in tsbtnBoxTypeStuff_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    Private Sub BoxDrum3DViewerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BoxDrum3DViewerToolStripMenuItem.Click

        MessageBox.Show(" Work in progress ", "Info.....", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub Other3DViewerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Other3DViewerToolStripMenuItem.Click

        MessageBox.Show(" Work in progress ", "Info.....", MessageBoxButtons.OK, MessageBoxIcon.Information)

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

    Private Sub tsbtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnExit.Click

        Try
            Call cmdExit_Click(sender, e)
        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in tsbtnExit_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    Private Sub tsbtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnFind.Click

        Try
            Call cmdFind_Click(sender, e)
        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in tslblFind_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    Private Sub tsbtnLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnLast.Click

        Try
            Call cmdLast_Click(sender, e)
        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in tsbtnLast_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tslblNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tslblNext.Click

        Try
            Call cmdNext_Click(sender, e)
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in ", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    Private Sub tslblPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tslblPrev.Click

        Try
            Call cmdPrev_Click(sender, e)
        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in tslblPrev_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbtnPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnPrev.Click

        Try
            Call cmdPrev_Click(sender, e)
        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in tslblPrev_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    Private Sub tsbtnFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnFirst.Click

        Try
            Call cmdFirst_Click(sender, e)
        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in tslblFirst_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    Private Sub tsbtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnDelete.Click

        Try
            Call cmdDel_Click(sender, e)
        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in tsbtnDelete_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    Private Sub tsbtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnEdit.Click

        Try

            Call cmdEdit_Click(sender, e)
        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in tsbtnEdit_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    Private Sub tsbtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnAdd.Click

        Try
            Call cmdAdd_Click(sender, e)
        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in tsbtnAdd_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    Private Sub tsbtnHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnHelp.Click

        Try

            Process.Start(CurDir() & "\HelpContainerStuff\Carton Master.chm")

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in tsbtnHelp_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tslblHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tslblHelp.Click

        Try

            Process.Start(CurDir() & "\HelpContainerStuff\Carton Master.chm")

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in tslblHelp_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tslblNMms_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tslblNMms.Click

        tsCSPNav.Visible = True
        tsCSPNavMaster.Visible = False

    End Sub

    Private Sub tslblNm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tslblNm.Click

        tsCSPNav.Visible = False
        tsCSPNavMaster.Visible = True

    End Sub

#End Region

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

 End Class
