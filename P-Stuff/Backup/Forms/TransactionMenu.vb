Option Strict Off

'Program Name: -    TransactionMenu.vb
'Programmer Name: - Satwadhir B. Pawar Mob No. :- 9323974665
'Company Name:-     Hazel Infotech LTD. Mumbai
'Project Name: -    Sky Stuff Plus (Container Stuffing)
'Date: -            22 Dec 2K8 10.55 AM (Modified Time)

'Tips: - The code is debugging at that particular dimensions, quantity and sequence.
'        you are decide it the logic happen is correct to that way or its are some 
'        different way the understanding to at your best level is the correct logic 
'        of this particular code block.

'Description: - This form is to utilize as transaction process of stuffing i.e. placing 
'               boxes goods in to container in optimize space and shown three dimensional 
'               isometric view in Alteros viewer and various settings to view this particular
'               dimensions, sequence and quantity in appropriate manner also shown the 
'               orthographic view in word document and finding maximum quantity in particular
'               goods, also open the container door to visualize the quantity to be placed in 
'               correct and accurate. Switches to stop pause switch of stuffing the quantity 
'               and the switch to shuffle the quantity, length, width, height, size, name wise etc.  

#Region " Importing Object "

Imports SDO = System.Data.OleDb
Imports MSScriptControl
Imports OptMthd
Imports eCSP
Imports IoTv = System.IO
Imports System.Threading

#End Region

Public NotInheritable Class TransactionMenu
    Inherits System.Windows.Forms.Form

#Region " Class declaration "

    Dim Da1 As SDO.OleDbDataAdapter
    Dim Ds1 As New DataSet
    'Dim Str As String
    Dim itmnm As String
    Private Introw As Integer
    Friend arc As New Area
    Friend RegArc As New Region
    Friend totvol As Double
    Friend contarr(2) As Double
    Friend showemp As Boolean
    Friend stkmm As New List(Of Area)
    Public colarr As New List(Of List(Of Byte))
    Dim stk1 As New List(Of Area)
    Dim BFlag As Boolean
    Dim y1 As Single = 0
    Dim y2 As Single = 0
    Dim UnM As Boolean = False
    Dim UnE As Boolean = False
    Public MetUnFlg As Boolean = False          'The metric units change flag
    Public EngUnFlg As Boolean = False           'The english units change flag
    Public Sauto As New List(Of AutoStuff)
    Public ScnAut As New List(Of AutoStuffCmn)
    Public FdAut As New List(Of AutoStuffCmn)
    Dim AtStf1 As Boolean = False
    Dim AtStf0 As Boolean = False

    Dim rowinfo() As Object
    Dim lwhc As Boolean = False

    Public pilotFlg As Boolean = False
    Public TrlsFlg As Boolean = False

    Public szFact As Double = 0
    Public szFlg As Boolean = False
    Dim flgOrient As Boolean = False

#End Region

#Region " Routine Definitions "

    Private Sub dgv1_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv1.CellEndEdit

        Try

            With dgv1

                'Try

                '    If e.ColumnIndex = 11 Then

                '        Calculation.Rdgv1 = e.RowIndex
                '        Calculation.Cdgv1 = e.ColumnIndex

                '        Dim MthCalg As New ScriptControl()

                '        MthCalg.Language = "VBScript"

                '        Dim Valm As String = dgv1.Item(Calculation.Cdgv1, Calculation.Rdgv1).Value

                '        Dim aval() As Char = Valm.ToCharArray
                '        Dim i As Short, j As Char
                '        For i = 0 To aval.Length - 1
                '            j = aval(i)
                '            If Not (Char.IsNumber(j) Or "+-*/=.".IndexOf(j) >= 0 Or Char.IsSymbol(j)) Then
                '                MsgBox("Only numbers allowed!", , Me.Text)
                '                'dgv1.CurrentCell.Value = 0
                '                Exit Sub
                '            Else
                '                If occurs(Valm, ".") > 1 Then
                '                    MsgBox("Decimal Points not allowed  more than once", , Me.Text)
                '                    '   dgv1.CurrentCell.Value = 0
                '                    Exit Sub
                '                End If
                '            End If

                '        Next

                '        Valm = MthCalg.Eval(Valm)

                '        dgv1.Item(Calculation.Cdgv1, Calculation.Rdgv1).Value = Math.Round(CInt(Valm))

                '        dgv1.Refresh()
                '        Me.Refresh()

                '    End If

                'Catch
                'End Try

                'Dim ee As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs

                ''Call ComboBox_SelectedIndexChanged(sender, ee)

                'Call dgv1_EditingControlShowing(sender, ee)

                'Dim maxQty As Integer = MaxQuantity(e)

                'Try
                '    Dim srn As Integer = 1
                '    For s As Integer = 0 To dgv1.RowCount - 2
                '        dgv1.Item(0, s).Value = srn
                '        srn += 1
                '    Next
                'Catch
                'End Try

                '    If e.ColumnIndex = 1 Then
                '        Dim itmname As String = dgv1(e.ColumnIndex, e.RowIndex).Value
                '        If itmname <> dgv1.Tag Then
                '            fill_measurement(itmname)

                '            If Not (CheckBox1.Checked) Then
                '                Dim ans = MsgBox("Do you want to calculate maximum quantity?", MsgBoxStyle.YesNo)
                '                If ans = MsgBoxResult.Yes Then
                '                    stk.Clear()
                '                    stk.Add(arc)
                '                    '            Button1.Enabled = False
                '                    Dim oldopt As Boolean = chkwt

                '                    If stk.Count > 1 Then
                '                        stk.Clear()         'initiliase the list generic
                '                    End If

                '                    dgv1(9, e.RowIndex).Value = calcmxqtyShow(rwidx, dgv1(7, e.RowIndex).Value = "6")


                '                    chkwt = oldopt
                '                    plclst.Clear()
                '                End If
                '            End If
                '        End If
                '    End If

            End With

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in CellEndEdit", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Function MaxQuantity(ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) As Integer

        Dim Qt As Integer = 0
        With dgv1

            If e.ColumnIndex = 1 Then
                Dim itmname As String = dgv1(e.ColumnIndex, e.RowIndex).Value
                If itmname <> dgv1.Tag Then
                    fill_measurement(itmname)

                    If Not (CheckBox1.Checked) Then
                        ' Dim ans = MsgBox("Do you want to calculate maximum quantity?", MsgBoxStyle.YesNo)
                        'If ans = MsgBoxResult.Yes Then
                        stk.Clear()
                        stk.Add(arc)
                        '            Button1.Enabled = False
                        Dim oldopt As Boolean = chkwt

                        If stk.Count > 1 Then
                            stk.Clear()         'initiliase the list generic
                        End If

                        'dgv1(9, e.RowIndex).Value = calcmxqtyShow(rwidx, dgv1(7, e.RowIndex).Value = "6")

                        'Qt = dgv1(9, e.RowIndex).Value

                        chkwt = oldopt
                        plclst.Clear()
                        'End If
                    End If
                End If
            End If

        End With

        Return Qt

    End Function

    'Data grid error handling to exit the routine
    Private Sub dgv1_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgv1.DataError

        Exit Sub

    End Sub

    Private Sub dgv1_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgv1.EditingControlShowing

        On Error Resume Next
        Dim combo As ComboBox
        Dim txtbx As TextBox
        If CmbContainer.Text = "" Then
            Exit Sub
        End If

        combo = CType(e.Control, ComboBox)
        txtbx = CType(e.Control, TextBox)

        If (combo IsNot Nothing) Then

            RemoveHandler combo.DropDownClosed, _
                New EventHandler(AddressOf ComboBox_SelectedIndexChanged)

            AddHandler combo.DropDownClosed, _
                New EventHandler(AddressOf ComboBox_SelectedIndexChanged)

        End If

    End Sub

    Private Sub CmbContainer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbContainer.KeyDown

        If e.KeyCode = Keys.Enter Then dgv1.Focus()

    End Sub

    Private Sub CmbContainer_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbContainer.LostFocus

        Try

            If Str = "Add" Or Str = "Update" Then
                AdRefFlg = True
                Exit Sub
            Else
                AdRefFlg = False
            End If

            If Not AdRefFlg Then

                If CmbContainer.Text = "" Then
                    MsgBox("Container not selected", MsgBoxStyle.Critical + vbOKOnly)
                    CmbContainer.Focus()
                    dgv1.StandardTab = False
                    Exit Sub
                End If
            End If

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in selecting container in Combo", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub CmbContainer_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbContainer.MouseEnter
        Call selectcontainername()
    End Sub

    Private Sub CmbContainer_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbContainer.SelectedIndexChanged

        Try
            'If rdbMetric.Checked = True Then
            '    'MsgBox("Deliberately change the units Metric to English.", MsgBoxStyle.Information + vbOKOnly, Me.Text)
            '    rdbEnglish.Checked = True
            '    rdbMetric.Checked = False
            '    'chkBxEnglishUnits.Checked = True
            '    'chkBxMetricUnits.Checked = False
            '    Call rdbEnglish_MouseClick(sender, e)                    'chkBxEnglishUnits_MouseClick(sender, e)
            'End If

            Dim rdr As OleDb.OleDbDataReader
            Dim cmd As New OleDb.OleDbCommand
            cmd.Connection = conn

            Dim lni As Single
            Dim wdi As Single
            Dim hti As Single

            cmd.CommandText = "select lengthf,widthf,heightf,lengthi,widthi,heighti,lengthc,widthc,heightc,lengthm,widthm,heightm,payload from containermaster where containername ='" & CmbContainer.Text & "'"
            If conn.State = ConnectionState.Closed Then conn.Open()
            rdr = cmd.ExecuteReader
            rdr.Read()

            Try
                lni = rdr("lengthi") + (12 * rdr("lengthf")) + (rdr("lengthc") / 2.54) + (rdr("lengthm") / 25.4)
            Catch e1 As Exception
                Exit Sub
            End Try
            wdi = rdr("Widthi") + (12 * rdr("Widthf")) + (rdr("Widthc") / 2.54) + (rdr("Widthm") / 25.4)
            hti = rdr("heighti") + (12 * rdr("heightf")) + (rdr("heightc") / 2.54) + (rdr("heightm") / 25.4)

            'Label8.Text = "Length=" & Format(lni, "0.00") & " Width=" & Format(wdi, "0.00") & " Height=" & Format(hti, "0.00")

            lblContDim.Text = "Length = " & Format(lni, "0.00") & "  Width = " & Format(wdi, "0.00") & "  Height = " & Format(hti, "0.00")

            TxtPayLoad.Text = Format(rdr("payload"), "0.0000")
            contcap = rdr("payload")
            contarr(0) = lni
            contarr(1) = wdi
            contarr(2) = hti
            arc.length = contarr(0)
            arc.width = contarr(1)
            arc.height = contarr(2)
            TxtCapacity.Text = Format((arc.length * arc.width * arc.height * 0.000016387064))
            'Stop
            CL = Format(lni, "0.00")
            CW = Format(wdi, "0.00")
            CH = Format(hti, "0.00")
            rdr.Close()

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in CmbContainer_SelectedIndexChanged", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            stk.Clear()
            stk.Add(arc)
        End Try

    End Sub

    Public Sub ContainerDimension()

        Try
            Dim rdr As OleDb.OleDbDataReader
            Dim cmd As New OleDb.OleDbCommand
            cmd.Connection = conn

            Dim lni As Single
            Dim wdi As Single
            Dim hti As Single

            cmd.CommandText = "select lengthf,widthf,heightf,lengthi,widthi,heighti,lengthc,widthc,heightc,lengthm,widthm,heightm,payload from containermaster where containername ='" & CmbContainer.Text & "'"
            If conn.State = ConnectionState.Closed Then conn.Open()
            rdr = cmd.ExecuteReader
            rdr.Read()

            Try
                lni = rdr("lengthi") + (12 * rdr("lengthf")) + (rdr("lengthc") / 2.54) + (rdr("lengthm") / 25.4)
            Catch e1 As Exception
                Exit Sub
            End Try
            wdi = rdr("Widthi") + (12 * rdr("Widthf")) + (rdr("Widthc") / 2.54) + (rdr("Widthm") / 25.4)
            hti = rdr("heighti") + (12 * rdr("heightf")) + (rdr("heightc") / 2.54) + (rdr("heightm") / 25.4)

            'Label8.Text = "Length=" & Format(lni, "0.00") & " Width=" & Format(wdi, "0.00") & " Height=" & Format(hti, "0.00")

            lblContDim.Text = "Length = " & Format(lni, "0.00") & "  Width = " & Format(wdi, "0.00") & "  Height = " & Format(hti, "0.00")

            TxtPayLoad.Text = Format(rdr("payload"), "0.0000")
            contcap = rdr("payload")
            contarr(0) = lni
            contarr(1) = wdi
            contarr(2) = hti
            arc.length = contarr(0)
            arc.width = contarr(1)
            arc.height = contarr(2)
            TxtCapacity.Text = Format((arc.length * arc.width * arc.height * 0.000016387064))

            'Stop

            CL = Format(lni, "0.00")
            CW = Format(wdi, "0.00")
            CH = Format(hti, "0.00")

            rdr.Close()

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in CmbContainer_SelectedIndexChanged", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            stk.Clear()
            stk.Add(arc)
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

    Private Sub cmdFirst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdFirst.Click

        Try
            Call CGRoutine()
            ShowButton.Visible = False
            If chkBxAutoStuff.Checked = True Then
                MessageBox.Show("Auto stuff arrangement is checked", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            'If rdbMetric.Checked = True Then                        'If chkBxMetricUnits.Checked = True Then
            '    'MsgBox("Deliberately change the units Metric to English.", MsgBoxStyle.Information + vbOKOnly, Me.Text)
            '    rdbEnglish.Checked = True                            'chkBxEnglishUnits.Checked = True
            '    rdbMetric.Checked = False                            'chkBxMetricUnits.Checked = False
            '    Call rdbEnglish_MouseClick(sender, e)                'chkBxEnglishUnits_MouseClick(sender, e)
            'End If

            If Ds1.Tables!TabIHead.Rows.Count - 1 >= 0 Then
                Introw = 0
                TxtBind()
                cmdEdit.Enabled = True
                cmdDel.Enabled = True
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in cmdFirst_Click", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdNext.Click

        Try
            Call CGRoutine()
            ShowButton.Visible = False
            If chkBxAutoStuff.Checked = True Then
                MessageBox.Show("Auto stuff arrangement is checked", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            'If rdbMetric.Checked = True Then                    'If chkBxMetricUnits.Checked = True Then
            '    'MsgBox("Deliberately change the units Metric to English.", MsgBoxStyle.Information + vbOKOnly, Me.Text)
            '    rdbEnglish.Checked = True                       'chkBxEnglishUnits.Checked = True
            '    rdbMetric.Checked = False                       'chkBxMetricUnits.Checked = False
            '    Call rdbEnglish_MouseClick(sender, e)           'chkBxEnglishUnits_MouseClick(sender, e)
            'End If

            If Introw < Ds1.Tables!TabIHead.Rows.Count - 1 Then
                Introw = Introw + 1
                TxtBind()
            End If

            cmdEdit.Enabled = True
            cmdDel.Enabled = True

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in cmdNext_Click", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdPrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdPrev.Click

        Try
            Call CGRoutine()
            ShowButton.Visible = False
            If chkBxAutoStuff.Checked = True Then
                MessageBox.Show("Auto stuff arrangement is checked", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            'If rdbMetric.Checked = True Then             'If chkBxMetricUnits.Checked = True Then
            '    'MsgBox("Deliberately change the units Metric to English.", MsgBoxStyle.Information + vbOKOnly, Me.Text)
            '    rdbEnglish.Checked = True                'chkBxEnglishUnits.Checked = True
            '    rdbMetric.Checked = False                'chkBxMetricUnits.Checked = False
            '    Call rdbEnglish_MouseClick(sender, e)    'chkBxEnglishUnits_MouseClick(sender, e)
            'End If

            If Introw > 0 Then
                Introw = Introw - 1
                TxtBind()
            End If
            cmdEdit.Enabled = True
            cmdDel.Enabled = True

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in cmdPrev_Click", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdLast.Click

        Try
            Call CGRoutine()
            ShowButton.Visible = False
            If chkBxAutoStuff.Checked = True Then
                MessageBox.Show("Auto stuff arrangement is checked", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            'If rdbMetric.Checked = True Then              'If chkBxMetricUnits.Checked = True Then
            '    'MsgBox("Deliberately change the units Metric to English.", MsgBoxStyle.Information + vbOKOnly, Me.Text)
            '    rdbEnglish.Checked = True                 'chkBxEnglishUnits.Checked = True
            '    rdbMetric.Checked = False                 'chkBxMetricUnits.Checked = False
            '    Call rdbEnglish_MouseClick(sender, e)     'chkBxEnglishUnits_MouseClick(sender, e)
            'End If

            If Ds1.Tables!TabIHead.Rows.Count - 1 >= 0 Then
                Introw = Ds1.Tables!TabIHead.Rows.Count - 1
                Call TxtBind()
                cmdEdit.Enabled = True
                cmdDel.Enabled = True
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in cmdLast_Click", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdDel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdDel.Click

        Call CGRoutine()
        ShowButton.Visible = False
        If chkBxAutoStuff.Checked = True Then
            MessageBox.Show("Auto stuff arrangement is checked", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        'If rdbMetric.Checked = True Then          'If chkBxMetricUnits.Checked = True Then
        '    'MsgBox("Deliberately change the units Metric to English.", MsgBoxStyle.Information + vbOKOnly, Me.Text)
        '    rdbEnglish.Checked = True             'chkBxEnglishUnits.Checked = True
        '    rdbMetric.Checked = False             'chkBxMetricUnits.Checked = False
        '    Call rdbEnglish_MouseClick(sender, e) 'chkBxEnglishUnits_MouseClick(sender, e)
        'End If

        Dim comm As New SDO.OleDbCommand 'delete
        If MsgBox("Are you sure you want to delete this Record?", MsgBoxStyle.YesNo + vbCritical, "Stuffing Entry") = MsgBoxResult.Yes Then

            comm = New SDO.OleDbCommand("Delete from NInwardDetail where ReceiptNo=" & Val(TxtRecNo.Text), conn)
            If conn.State = ConnectionState.Closed Then conn.Open()
            Try
                comm.ExecuteNonQuery()
                Call getAllReceiptNo()
                If Ds1.Tables!TabIHead.Rows.Count = 0 Then
                    Call Txtclear()
                    Call NoRecorddisplay()
                    cmdAdd.Focus()
                    Exit Sub
                Else
                    Introw = Ds1.Tables!TabIHead.Rows.Count - 1
                    Call Txtclear()
                    Call TxtBind()
                End If
            Catch Ex As Exception
                MsgBox(Ex.Message)
                MsgBox(Ex.ToString)
                MessageBox.Show("Error in cmdDel_Click", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                'MsgBox(Ex.Message, MsgBoxStyle.Critical, "Error in :: cmdDel_Click Procedure")
            End Try
        End If

    End Sub

    Public Sub AutoStuffEventTrue()

        TxtOccuCbm.Text = ""
        TxtOccuKgs.Text = ""
        TxtFreeCbm.Text = ""
        TxtFreeKgs.Text = ""
        TxtpercentVolOcc.Text = ""
        txtCompactPer.Text = ""
        chkBxAutoStuffRC.Enabled = False

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

    Public Sub AutoStuffEventFalse()

        TxtOccuCbm.Text = ""
        TxtOccuKgs.Text = ""
        TxtFreeCbm.Text = ""
        TxtFreeKgs.Text = ""

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
        chkBxAutoStuffRC.Enabled = True

    End Sub

    Private Sub cmdAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAdd.Click

        Try
            Call CGRoutine()
            ShowButton.Visible = False
            lblContDim.Text = ""
            If chkBxAutoStuff.Checked = True Then
                MessageBox.Show("Auto stuff arrangement is checked", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If rdbMetric.Checked = True Then                'If chkBxMetricUnits.Checked = True Then 
                'MsgBox("Deliberately change the units Metric to English.", MsgBoxStyle.Information + vbOKOnly, Me.Text)
                rdbEnglish.Checked = True                       'chkBxEnglishUnits.Checked = True
                rdbMetric.Checked = False                       'chkBxMetricUnits.Checked = False
                Try
                    Call rdbEnglish_MouseClick(sender, e)           'chkBxEnglishUnits_MouseClick(sender, e)
                Catch
                    Exit Try
                End Try
            End If

            Dim StrId As String
            Call Txtclear()
            CmbContainer.Enabled = True
            DtReceipt.Enabled = True
            addenable()
            Str = "Add"
            DtReceipt.Focus()
            StrId = "select max(receiptno) as RId from Ninwarddetail"
            TxtRecNo.Text = GenId(StrId)
            BFlag = True
            dgv1.Enabled = True
            Button1.Enabled = True
            ShowButton.Visible = False
            lblContDim.Text = ""
            dgv1.Columns(1).ReadOnly = False
            dgv1.Columns(11).ReadOnly = False

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in cmdAdd_Click", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub addenable()

        Try
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

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in addenable", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub RdbBtnClear()

        Try
            With Me

                .Rdb1.Checked = False
                .Rdb2.Checked = False
                .Rdb3.Checked = False
                .Rdb4.Checked = False
                .Rdb5.Checked = False
                .Rdb6.Checked = False
                .Rdb7.Checked = False
                .Rdb8.Checked = False
                .Rdb9.Checked = False
                .Rdb10.Checked = False
                .Rdb11.Checked = False
                .Rdb12.Checked = False
                .Rdb13.Checked = False
                .Rdb14.Checked = False
                .Rdb15.Checked = False
                .Rdb16.Checked = False
                .chkBxAutoStuffRC.Checked = False

            End With

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in RdbBtnClear", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdEdit.Click

        Try

            ShowButton.Visible = False
            gbUnits.Enabled = True
            If chkBxAutoStuff.Checked = True Then
                MessageBox.Show("Auto stuff arrangement is checked", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Call RdbBtnClear()

            If rdbMetric.Checked = True Then                         'If chkBxMetricUnits.Checked = True Then
                'MsgBox("Deliberately change the units Metric to English.", MsgBoxStyle.Information + vbOKOnly, Me.Text)
                rdbEnglish.Checked = True                             'chkBxEnglishUnits.Checked = True
                rdbMetric.Checked = False                             'chkBxMetricUnits.Checked = False
                Call rdbEnglish_MouseClick(sender, e)                 'chkBxEnglishUnits_MouseClick(sender, e)
            End If

            dgv1.Enabled = True
            editenable()
            CmbContainer.Enabled = True
            DtReceipt.Enabled = True
            Str = "Edit"

            DtReceipt.Focus()
            BFlag = True

            Call CGRoutine()
            btnContLWH.Enabled = True
            chkBxAutoStuff.Enabled = False
            chkBxAutoStuffRC.Enabled = False

            Call nogridcolor()
            dgv1.Columns(1).ReadOnly = False
            dgv1.Columns(11).ReadOnly = False
            dgv1.Columns(7).ReadOnly = False

            Call ClearReview()

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in cmdEdit_Click", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub ClearReview()
        lblTotQty.Text = ""
        lblTotVol.Text = ""
        lblTotWt.Text = ""
    End Sub

    Private Sub editenable()

        Try
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

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in editenable", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdRef_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdRef.Click

        Try
            If Str = "Add" Then
                AdRefFlg = True
                'Exit Sub
            Else
                Str = "Update"
                AdRefFlg = False
            End If

            Call CGRoutine()
            Dim comm As New SDO.OleDbCommand 'delete
            If MsgBox("Are you sure you want to refresh this record?", MsgBoxStyle.YesNo + vbInformation, "Stuffing Entry") = MsgBoxResult.Yes Then
                If Ds1.Tables!TabIHead.Rows.Count = 0 Then
                    Call Txtclear()
                    Call NoRecorddisplay()
                    Introw = 0
                    BFlag = False
                    CmbContainer.Enabled = False
                    DtReceipt.Enabled = False
                    cmdAdd.Focus()
                    ShowButton.Visible = False
                    Exit Sub
                ElseIf Introw > 0 Or Introw <= Ds1.Tables!TabIHead.Rows.Count - 1 Then
                    refenable()
                    TxtBind()
                    BFlag = False
                    CmbContainer.Enabled = False
                    DtReceipt.Enabled = False
                    ShowButton.Visible = False
                    cmdAdd.Focus()
                End If

            Else
                AdRefFlg = True
                DtReceipt.Focus()
                Exit Sub
            End If

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in cmdRef_Click", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Str = "Update"
            dgv1.Columns(1).ReadOnly = True
            dgv1.Columns(11).ReadOnly = True
        End Try

    End Sub

    Private Sub refenable()

        Try
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

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in refenable", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFind.Click

        Try
            Call CGRoutine()
            ShowButton.Visible = False
            If chkBxAutoStuff.Checked = True Then
                MessageBox.Show("Auto stuff arrangement is checked", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            'If rdbMetric.Checked = True Then                                 'If chkBxMetricUnits.Checked = True Then
            '    'MsgBox("Deliberately change the units Metric to English.", MsgBoxStyle.Information + vbOKOnly, Me.Text)
            '    rdbEnglish.Checked = True                                    'chkBxEnglishUnits.Checked = True
            '    rdbMetric.Checked = False                                    'chkBxMetricUnits.Checked = False
            '    Call rdbEnglish_MouseClick(sender, e)                        'chkBxEnglishUnits_MouseClick(sender, e)
            'End If

            DT = "NInwardDetail"
            FindStr = "Select distinct ReceiptNo,ReceiptDate,ContainerName FROM NInwardDetail ORDER BY ReceiptNo"
            title = "InwardEntry"
            frmSearch.ShowDialog()
            Me.ActivateMdiChild(frmSearch)
            frmSearch.Txtsearch.Focus()
            '**********************************
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in cmdFind_Click", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click

        Try

            Try
                Dim srn As Integer = 1
                For s As Integer = 0 To dgv1.RowCount - 2
                    dgv1.Item(0, s).Value = srn
                    srn += 1
                Next
            Catch
            End Try

            dgv1.Columns(1).ReadOnly = True
            dgv1.Columns(11).ReadOnly = True
            dgv1.Columns(7).ReadOnly = True
            Call CGRoutine()
            btnContLWH.Enabled = False
            chkBxAutoStuff.Enabled = True
            chkBxAutoStuffRC.Enabled = True

            If lwhc Then
                CL = contarr(0)
                CW = contarr(1)
                CH = contarr(2)
                lblContDim.Text = "Length = " & Format(CL, "0.00") & "  Width = " & Format(CW, "0.00") & "  Height = " & Format(CH, "0.00")
                lblContDim.Refresh()
            End If

            Dim strSQL As String
            Dim comm As New SDO.OleDbCommand
            Dim maxqty1 As Integer
            Dim qty1 As Integer

            'If rdbMetric.Checked = True Then
            '    'MsgBox("Deliberately change the units Metric to English.", MsgBoxStyle.Information + vbOKOnly, Me.Text)
            '    rdbEnglish.Checked = True                                 'chkBxEnglishUnits.Checked = True
            '    rdbMetric.Checked = False                                 'chkBxMetricUnits.Checked = False
            '    Call rdbEnglish_MouseClick(sender, e)                     'chkBxEnglishUnits_MouseClick(sender, e)
            'End If

            For i As Integer = 0 To dgv1.RowCount - 2

                If TypeOf (dgv1.Item(11, i).Value) Is DBNull Then
                    MsgBox("Invalid quantity at row " & (i + 1).ToString, MsgBoxStyle.Information + vbOKOnly, "Stuffing Entry")

                    dgv1.Columns(1).ReadOnly = False
                    dgv1.Columns(11).ReadOnly = False
                    dgv1.Columns(7).ReadOnly = False
                    Exit Sub
                Else
                    If Not IsNumeric(dgv1.Item(11, i).Value) Then
                        MsgBox("Invalid quantity at row " & (i + 1).ToString, MsgBoxStyle.Information + vbOKOnly, "Stuffing Entry")

                        dgv1.Columns(1).ReadOnly = False
                        dgv1.Columns(11).ReadOnly = False
                        dgv1.Columns(7).ReadOnly = False
                        Exit Sub
                    End If
                End If
            Next

            If CmbContainer.Text = "" Then
                MsgBox("Please Select Container Name", MsgBoxStyle.Information + vbOKOnly, "Stuffing Entry")
                addenable()
                CmbContainer.Focus()
                Exit Sub
            End If

            Dim U As String = Nothing
            If rdbEnglish.Checked = True Then
                U = "English"
            ElseIf rdbMetric.Checked = True Then
                U = "Metric"
            End If

            If conn.State = ConnectionState.Closed Then conn.Open()
            dgv1.Enabled = False
            ShowButton.Visible = False
            If Str = "Add" Then
                For i As Integer = 0 To dgv1.RowCount - 2
                    maxqty1 = dgv1.Item(10, i).Value
                    qty1 = dgv1.Item(11, i).Value
                    strSQL = "insert into Ninwarddetail values(" & TxtRecNo.Text & ",#" & DtReceipt.Value & "#,'" & CmbContainer.Text & "'," & _
                    dgv1.Item(0, i).Value & ",'" & dgv1.Item(1, i).Value & "','" & dgv1.Item(2, i).Value & "'," & dgv1.Item(3, i).Value & "," & _
                    dgv1.Item(4, i).Value & "," & dgv1.Item(5, i).Value & "," & dgv1.Item(6, i).Value & "," & maxqty1 & "," & qty1 & _
                    "," & dgv1.Item(7, i).Value & "," & dgv1.Item(8, i).Value & ",'" & U & "')"
                    comm.Connection = conn
                    comm.CommandText = strSQL
                    comm.ExecuteNonQuery()
                Next

                'MessageBox.Show("Update successfully", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

                Dim MsgR As MsgBoxResult = MessageBox.Show("Do you want update complete?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                Str = "Update"
                If MsgR = MsgBoxResult.Yes Then
                    Call UpdateDataBaseBind()
                    Str = "UpdateComplete"
                Else
                    Str = "Update"
                End If

                'getAllReceiptNo()
                'Introw = Ds1.Tables!TabIHead.Rows.Count - 1
                'TxtBind()
                conn.Close()
                BFlag = False
                Call saveenable()
                CmbContainer.Enabled = False
                DtReceipt.Enabled = False
                cmdAdd.Focus()

            ElseIf Str = "Edit" Then
                strSQL = "delete from NInwardDetail where receiptno = " & TxtRecNo.Text
                comm.Connection = conn
                comm.CommandText = strSQL
                If conn.State = ConnectionState.Closed Then conn.Open()
                comm.ExecuteNonQuery()
                'conn.close()
                Str = "Add"
                Call cmdUpdate_Click(Nothing, Nothing)
            End If
            dgv1.Enabled = True
        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in cmdUpdate_Click", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Try
                Call gridColor()
            Catch
            End Try
        End Try

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

    End Sub

    Private Sub dgv1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgv1.MouseClick

        Try
            '' --------- shailesh
            Dim htinfo As DataGridView.HitTestInfo
            htinfo = dgv1.HitTest(e.X, e.Y)

            ShowButton.Visible = False
            ShowButton.Top = 0
            ShowButton.Left = 0
            ShowButton.Width = 0
            ShowButton.Height = 0
            ToolTip1.IsBalloon = True
            '  dgv1.Columns(htinfo.ColumnIndex).HeaderCell.ErrorText = ""
            If htinfo.Type = DataGridViewHitTestType.ColumnHeader Then

                Select Case htinfo.ColumnIndex
                    Case 14
                        MessageBox.Show("Layout column is not sorting.", "Stuffing Entry :- Pick activity info.....", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    Case 13
                        MessageBox.Show("Empty column is not sorting.", "Stuffing Entry :- Pick activity info.....", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    Case 12
                        MessageBox.Show("Show column is not sorting.", "Stuffing Entry :- Pick activity info.....", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    Case 11
                        If flgDGV1 Then
                            If SrNFlg Then
                                snDgv1QtySrt(sender, e)
                            Else
                                Dgv1QtySrt(sender, e)
                            End If
                        Else
                            MessageBox.Show("Please switch on sort arrangement switch for quantity sorting", "Stuffing Entry :- Pick activity info.....", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    Case 10
                        If flgDGV1 Then
                            If SrNFlg Then
                                snDgv1MxQtySrt(sender, e)
                            Else
                                Dgv1MxQtySrt(sender, e)
                            End If
                        Else
                            MessageBox.Show("Please switch on sort arrangement switch for maximum quantity sorting", "Stuffing Entry :- Pick activity info.....", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    Case 8
                        If flgDGV1 Then
                            If SrNFlg Then
                                snDgv1WeightSrt(sender, e)
                            Else
                                Dgv1WeightSrt(sender, e)
                            End If
                        Else
                            MessageBox.Show("Please switch on sort arrangement switch for weight sorting", "Stuffing Entry :- Pick activity info.....", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    Case 7
                        If flgDGV1 Then
                            If SrNFlg Then
                                snDgv1OrientSrt(sender, e)
                            Else

                                Dgv1OrientSrt(sender, e)
                            End If
                        Else
                            MessageBox.Show("Please switch on sort arrangement switch for orientation sorting", "Stuffing Entry :- Pick activity info.....", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    Case 6
                        If flgDGV1 Then
                            If SrNFlg Then
                                snDgv1HeightSrt(sender, e)
                            Else

                                Dgv1HeightSrt(sender, e)
                            End If
                        Else
                            MessageBox.Show("Please switch on sort arrangement switch for height sorting", "Stuffing Entry :- Pick activity info.....", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                    Case 5
                        If flgDGV1 Then
                            If SrNFlg Then
                                snDgv1WidthSrt(sender, e)
                            Else
                                Dgv1WidthSrt(sender, e)
                            End If
                        Else
                            MessageBox.Show("Please switch on sort arrangement switch for width sorting", "Stuffing Entry :- Pick activity info.....", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    Case 4
                        If flgDGV1 Then
                            If SrNFlg Then
                                snDgv1LengthSrt(sender, e)
                            Else
                                Dgv1LengthSrt(sender, e)
                            End If

                        Else
                            MessageBox.Show("Please switch on sort arrangement switch for length sorting", "Stuffing Entry :- Pick activity info.....", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    Case 3
                        If flgDGV1 Then
                            If SrNFlg Then
                                snDgv1SizeSrt(sender, e)
                            Else
                                Dgv1SizeSrt(sender, e)
                            End If
                        Else
                            MessageBox.Show("Please switch on sort arrangement switch for size sorting", "Stuffing Entry :- Pick activity info.....", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    Case 2
                        If flgDGV1 Then
                            If SrNFlg Then
                                snDgv1PackSrt(sender, e)
                            Else
                                Dgv1PackSrt(sender, e)
                            End If
                        Else
                            MessageBox.Show("Please switch on sort arrangement switch for pack sorting", "Stuffing Entry :- Pick activity info.....", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    Case 1
                        If flgDGV1 Then
                            If SrNFlg Then
                                snDgv1ItemNameSrt(sender, e)
                            Else
                                Dgv1ItemNameSrt(sender, e)
                            End If
                        Else
                            MessageBox.Show("Please switch on sort arrangement switch for item name sorting", "Stuffing Entry :- Pick activity info.....", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    Case 0
                        If flgDGV1 Then
                            If SrNFlg Then
                                snDgv1SrNoSrt(sender, e)
                            Else
                                Dgv1SrNoSrt(sender, e)
                            End If
                        Else
                            MessageBox.Show("Please switch on sort arrangement switch for serial number sorting", "Stuffing Entry :- Pick activity info.....", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If


                End Select
            End If

            Button1.Enabled = False


            ''----------- shailesh 


            If htinfo.Type = DataGridViewHitTestType.Cell Then

                Dim sbutton As Boolean = dgv1.Columns(htinfo.ColumnIndex).HeaderText = "Show"
                Dim lbutton As Boolean = dgv1.Columns(htinfo.ColumnIndex).HeaderText = "Layout"
                Dim button As Button = IIf(sbutton, Me.ShowButton, Me.showbutton1)
                button.Parent = Me.gb1
                button.BringToFront()
                button.Text = "Show"
                button.Top = dgv1.Location.Y + htinfo.RowY
                button.Left = dgv1.Location.X + htinfo.ColumnX
                button.Width = dgv1(htinfo.ColumnIndex, htinfo.RowIndex).Size.Width
                button.Height = dgv1(htinfo.ColumnIndex, htinfo.RowIndex).Size.Height
                button.Visible = False
                If sbutton Or lbutton Then
                    If dgv1.Item(1, htinfo.RowIndex).Value <> "" Then
                        button.Visible = True
                    End If
                Else
                End If

            End If

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in dgv1_MouseClick", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Dgv1Dup_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles Dgv1Dup.DataError
        Exit Sub
    End Sub

    Private Sub Dgv1Dup_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles Dgv1Dup.RowsAdded

        'Dim clm As DataGridViewComboBoxCell

        'clm = Dgv1Dup.Item(7, e.RowIndex)
        'clm.Items.AddRange(New Object() {"6", "2"})
        'clm.Value = "6"

        '' clm.Value = "6"

        'If Not (Str = "Edit") Then

        '    Dgv1Dup.Item(0, e.RowIndex).Value = e.RowIndex + 1
        '    Dgv1Dup.Item(3, e.RowIndex).Value = 0
        '    Dgv1Dup.Item(4, e.RowIndex).Value = 0
        '    Dgv1Dup.Item(5, e.RowIndex).Value = 0
        '    Dgv1Dup.Item(6, e.RowIndex).Value = 0
        '    Dgv1Dup.Item(9, e.RowIndex).Value = 0

        '    '******************
        '    Dim totvol As Double = 0
        '    Dim totwt As Double = 0
        '    'For i As Integer = 0 To Dgv1Dup.RowCount - 1
        '    '    totvol = totvol + (CDbl(Dgv1Dup.Item(3, i).Value) * CDbl(Dgv1Dup.Item(12, i).Value))
        '    '    totwt = totwt + CDbl(Dgv1Dup.Item(8, i).Value)
        '    'Next

        '    For i As Integer = 0 To Dgv1Dup.RowCount - 1

        '        Dgv1Dup.Item(0, i).Value = i + 1

        '    Next

        '    'TxtOccuCbm.Text = FormatNumber(totvol, 4, , , False)
        '    'TxtOccuKgs.Text = FormatNumber(totwt, 4, , , False)
        '    'TxtFreeCbm.Text = FormatNumber((arc.length * arc.width * arc.height / 61024) - totvol, 4, , , False)
        '    'If TxtPayLoad.Text = "" Then TxtPayLoad.Text = "0"
        '    'TxtFreeKgs.Text = FormatNumber(CDbl(TxtPayLoad.Text) - CDbl(TxtOccuKgs.Text), 4, , , False)

        'End If


    End Sub

    Private Sub dgv1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgv1.RowsAdded

        '***************************************************

        If Not flgOrient Then

            Dim clm As DataGridViewComboBoxCell
            clm = dgv1.Item(7, e.RowIndex)
            clm.Items.AddRange(New Object() {"6", "2"})
            ''clm.Items.AddRange(New Object() {"2", "6"})
            ''clm.Value = "2"
            clm.Value = "6"

        End If

        '***************************************************

        If Not (Str = "Edit") Then

            dgv1.Item(0, e.RowIndex).Value = e.RowIndex + 1
            dgv1.Item(3, e.RowIndex).Value = 0
            dgv1.Item(4, e.RowIndex).Value = 0
            dgv1.Item(5, e.RowIndex).Value = 0
            dgv1.Item(6, e.RowIndex).Value = 0
            dgv1.Item(9, e.RowIndex).Value = 0

            '******************
            Dim totvol As Double = 0
            Dim totwt As Double = 0

            For i As Integer = 0 To dgv1.RowCount - 1
                totvol = totvol + (CDbl(dgv1.Item(3, i).Value) * CDbl(dgv1.Item(12, i).Value))
                totwt = totwt + CDbl(dgv1.Item(8, i).Value)
            Next

            For i As Integer = 0 To dgv1.RowCount - 1

                dgv1.Item(0, i).Value = i + 1

            Next

            'TxtOccuCbm.Text = FormatNumber(totvol, 4, , , False)
            'TxtOccuKgs.Text = FormatNumber(totwt, 4, , , False)
            'TxtFreeCbm.Text = FormatNumber((arc.length * arc.width * arc.height / 61024) - totvol, 4, , , False)
            'If TxtPayLoad.Text = "" Then TxtPayLoad.Text = "0"
            'TxtFreeKgs.Text = FormatNumber(CDbl(TxtPayLoad.Text) - CDbl(TxtOccuKgs.Text), 4, , , False)

        End If

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'Dim ar As New Area
        'Dim x As Double
        'Dim y As Double
        'Dim z As Double
        'Dim ln As Double
        'Dim wd As Double
        'Dim ht As Double
        'Dim vol As Double
        'Dim totvol1 As Double

        'Dim lst As New List(Of String)

        'totvol = 0
        'If stkmm.Count = 0 And Bareaarr.Count = 0 Then
        '    If Not showemp Then
        '        stkmm.Add(arc)
        '    Else
        '        MsgBox("Container Is Fully Occupied. No Empty Area Left", MsgBoxStyle.Critical + vbOKOnly)
        '        Exit Sub
        '    End If
        'End If
        'For i As Integer = 0 To stkmm.Count - 1
        '    ar = stkmm(i)
        '    If showemp Then
        '        ar.AutoDraw(CurDir() & "\First.wrl", "r", 0, "", CStr(i + 1), 0, False, True, "E", 0, False, "b", "1")

        '    End If
        '    x = ar.StrtPt.x
        '    y = ar.StrtPt.y
        '    z = ar.StrtPt.z
        '    ln = ar.length
        '    wd = ar.width
        '    ht = ar.height
        '    vol = ln * wd * ht
        '    totvol = totvol + vol
        '    dgEmpty.Rows.Add(CStr(i + 1), CStr(x), CStr(y), CStr(z), CStr(ln), CStr(wd), CStr(ht), vol)
        '    If dgEmpty.RowCount = 0 Then
        '        MsgBox("All rows deleted")
        '    End If
        'Next

        'If Bareaarr.Count > 0 Then
        '    lst = Bareaarr(0)

        '    totvol1 = 0
        '    For i As Integer = 0 To lst.Count - 1 Step 2
        '        dgUsage.Rows.Add(lst(i), lst(i + 1))
        '        totvol1 = totvol1 + CDbl(lst(i + 1))
        '    Next
        'End If
        'dgUsage.Rows.Add("Total Occupied", CStr(totvol1))
        'dgUsage.Rows.Add("Empty", CStr(totvol))

    End Sub

    Private Sub cmdExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdExit.Click

        Try
            Call btnStatus_Click(sender, e)
            Call CGRoutine()
            ShowButton.Visible = False
            If BFlag = True Then
                'If rdbMetric.Checked = True Then                               'If chkBxMetricUnits.Checked = True Then
                '    'MsgBox("Deliberately change the units Metric to English.", MsgBoxStyle.Information + vbOKOnly, Me.Text)
                '    rdbEnglish.Checked = True                                   'chkBxEnglishUnits.Checked = True
                '    rdbMetric.Checked = False                                   'chkBxMetricUnits.Checked = False
                '    Call rdbEnglish_MouseClick(sender, e)                       'chkBxEnglishUnits_MouseClick(sender, e)
                'End If

                If MsgBox("Do you want to save this record?", MsgBoxStyle.Information + vbYesNo, "Stuffing Entry") = MsgBoxResult.Yes Then
                    Dim strSQL As String
                    Dim comm As New SDO.OleDbCommand
                    Dim maxqty1 As Integer
                    Dim qty1 As Integer
                    For i As Integer = 0 To dgv1.RowCount - 2
                        If TypeOf (dgv1.Item(11, i).Value) Is DBNull Then
                            MsgBox("Invalid quantity at row " & (i + 1).ToString, MsgBoxStyle.Critical + vbOKOnly)
                            Exit Sub
                        Else
                            If Not IsNumeric(dgv1.Item(11, i).Value) Then
                                MsgBox("Invalid quantity at row " & (i + 1).ToString, MsgBoxStyle.Critical + vbOKOnly)
                                Exit Sub
                            End If
                        End If
                    Next
                    If CmbContainer.Text = "" Then
                        MsgBox("Please Select Container Name", MsgBoxStyle.Information + vbOKOnly, "Stuffing Entry")
                        addenable()
                        CmbContainer.Focus()
                        Exit Sub
                    End If
                    If conn.State = ConnectionState.Closed Then conn.Open()

                    Dim U As String = Nothing
                    If rdbEnglish.Checked = True Then
                        U = "English"
                    ElseIf rdbMetric.Checked = True Then
                        U = "Metric"
                    End If

                    If Str = "Add" Then
                        For i As Integer = 0 To dgv1.RowCount - 2
                            maxqty1 = dgv1.Item(9, i).Value
                            qty1 = dgv1.Item(11, i).Value
                            strSQL = "insert into Ninwarddetail values(" & TxtRecNo.Text & ",#" & DtReceipt.Value & "#,'" & CmbContainer.Text & "'," & _
                             dgv1.Item(0, i).Value & ",'" & dgv1.Item(1, i).Value & "','" & dgv1.Item(2, i).Value & "'," & dgv1.Item(3, i).Value & "," & _
                             dgv1.Item(4, i).Value & "," & dgv1.Item(5, i).Value & "," & dgv1.Item(6, i).Value & "," & maxqty1 & "," & qty1 & _
                             "," & dgv1.Item(7, i).Value & "," & dgv1.Item(8, i).Value & ",'" & U & "')"
                            comm.Connection = conn
                            comm.CommandText = strSQL
                            comm.ExecuteNonQuery()
                        Next
                        getAllReceiptNo()
                        Introw = Ds1.Tables!TabIHead.Rows.Count - 1
                        TxtBind()
                        'conn.close()
                        BFlag = False
                        Call saveenable()
                        cmdAdd.Focus()
                    ElseIf Str = "Edit" Then
                        strSQL = "delete from NInwardDetail where receiptno = " & TxtRecNo.Text
                        comm.Connection = conn
                        comm.CommandText = strSQL
                        If conn.State = ConnectionState.Closed Then conn.Open()
                        comm.ExecuteNonQuery()
                        'conn.close()
                        Str = "Add"
                        Call cmdUpdate_Click(Nothing, Nothing)
                    End If
                Else
                    'Close()
                End If
            Else
                'Close()
            End If
            'Close()

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in cmdExit_Click", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Dispose(True)
            Call MDIForm.BringFront()
            Me.Close()
        End Try

    End Sub

    Private Sub DtReceipt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtReceipt.KeyDown

        If e.KeyCode = Keys.Enter Then CmbContainer.Focus()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        For i As Integer = 0 To dgv1.Rows.Count - 1
            dgv1.Item(9, i).Value = dgv1.Item(8, i).Value * dgv1.Item(11, i).Value
        Next
        dgv1.Sort(dgv1.Columns(9), System.ComponentModel.ListSortDirection.Descending)

    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If Button1.BackColor = Color.DarkRed Then
            Button1.BackColor = Color.LightYellow
            Button1.ForeColor = Color.DarkRed
            CheckBox1.Checked = False
        ElseIf Button1.BackColor = Color.LightYellow Then
            Button1.BackColor = Color.DarkRed
            Button1.ForeColor = Color.LightYellow
            CheckBox1.Checked = True
        End If
        For i As Integer = 0 To dgv1.Rows.Count - 1
            dgv1.Item(9, i).Value = dgv1.Item(8, i).Value * dgv1.Item(11, i).Value
        Next
        dgv1.Sort(dgv1.Columns(9), System.ComponentModel.ListSortDirection.Descending)
        For i As Integer = 0 To dgv1.RowCount - 1

            dgv1.Item(0, i).Value = i + 1

        Next

    End Sub

    Private Sub DuplDgvCl()

        Try
            Dim j As Integer = 0
            Try

                Dgv1Dup.Visible = False
LpR:
                For i As Integer = 0 To Dgv1Dup.RowCount - 1
                    Dgv1Dup.Rows.Remove(Dgv1Dup.Rows(i))
                Next

            Catch
                j += 1
                If j > 5 Then
                    Exit Sub
                End If
                GoTo LpR
            End Try
        Catch
            Exit Sub
        End Try

    End Sub

    Private Sub DuplDgv()

        Try

            Dim x As Integer = dgv1.Location.X
            Dim y As Integer = dgv1.Location.Y

            Dgv1Dup.Location = New System.Drawing.Point(x, y)

            Dgv1Dup.Size = dgv1.Size

            With Dgv1Dup

                .AutoGenerateColumns = False
                .ColumnHeadersDefaultCellStyle.BackColor = Color.FloralWhite
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.Black
                .ColumnHeadersDefaultCellStyle.Font = New Font(dgv1.Font, FontStyle.Bold)
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

            Dgv1Dup.AutoGenerateColumns = False
            Dgv1Dup.ColumnHeadersHeight = 30
            Dgv1Dup.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect
            Dgv1Dup.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing

            Dgv1Dup.RowHeadersVisible = True
            Dgv1Dup.RowHeadersWidth = 21

            With Dgv1Dup.ColumnHeadersDefaultCellStyle
                .ForeColor = Color.Blue
            End With

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in datagrid loading", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Call DuplDgvCl()

        Dim clm As DataGridViewComboBoxCell

        Try

            For i As Integer = 0 To dgv1.RowCount - 2

                Dim Inm As String = dgv1.Item(1, i).Value

                Dgv1Dup.Rows.Add()
                Dgv1Dup.Item(0, i).Value = dgv1.Item(0, i).Value
                Dgv1Dup.Item(1, i).Value = Inm
                Dgv1Dup.Item(2, i).Value = dgv1.Item(2, i).Value
                Dgv1Dup.Item(3, i).Value = dgv1.Item(3, i).Value
                Dgv1Dup.Item(4, i).Value = dgv1.Item(4, i).Value
                Dgv1Dup.Item(5, i).Value = dgv1.Item(5, i).Value
                Dgv1Dup.Item(6, i).Value = dgv1.Item(6, i).Value

                clm = Dgv1Dup.Item(7, i)
                clm.Items.AddRange(New Object() {"6", "2"})
                clm.Value = "6"

                clm = Dgv1Dup.Item(1, i)
                clm.Items.AddRange(New Object() {Inm})
                clm.Value = Inm

                Dgv1Dup.Item(8, i).Value = dgv1.Item(8, i).Value
                Dgv1Dup.Item(10, i).Value = dgv1.Item(10, i).Value
                Dgv1Dup.Item(11, i).Value = dgv1.Item(11, i).Value

            Next

            For k As Integer = 0 To dgv1.RowCount - 2
                Dim GrdCol As Drawing.Color = dgv1.Rows(k).HeaderCell.Style.BackColor
                Dgv1Dup.Rows(k).HeaderCell.Style.BackColor = GrdCol
            Next

        Catch Erx As Exception
            MsgBox(Erx.Message)
            MsgBox(Erx.ToString)
            MessageBox.Show("Error in DuplDgv", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Dgv1Dup.Enabled = False
        End Try


    End Sub

    Public Sub ShowButton_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ShowButton.MouseClick
        'Private Sub ShowButton_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ShowButton.MouseClick

        Dim sn As Int16, i As Int16, j As Int16, itmnm As String
        Dim ccell As DataGridViewCell = dgv1.CurrentCell
        Dim bkclr As System.Drawing.Color
        Dim Bo As Int16 = 0

        Try
            btnPilot.Enabled = False
            chkBxAutoStuff.Enabled = False

            'If Not (Str = Nothing Or Str = "Update" Or Str = "UpdateComplete") Then
            '    MessageBox.Show("Update the stuffing entry then continue", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            '    Exit Sub
            'End If

            Me.pbCSP1.ForeColor = Color.HotPink
            System.Windows.Forms.Application.DoEvents()
            Call TransactionMenu_Resize(sender, e)
            dgv1.SuspendLayout()
            showbutton1.Visible = False

            For i = 0 To dgv1.RowCount - 2

                sn = dgv1(0, i).Value
                itmnm = dgv1(1, i).Value

                bkclr = dgv1.Rows(i).HeaderCell.Style.BackColor

                If bkclr.Name = "0" Then

                    Dim colval As Short = Val(dgv1(0, i).Value)     'Val(dgv1(0, 1).Value)

                    If colval > 7 Then colval = colval - 7 'If colval > 6 Then colval = colval - 6

                    Select Case colval              'Val(dgv1(0, i).Value)
                        Case 1
                            bkclr = Color.Red
                        Case 2
                            bkclr = Color.Green
                        Case 3
                            bkclr = Color.Blue
                        Case 4
                            bkclr = Color.Magenta
                        Case 5
                            bkclr = Color.Cyan
                        Case 6
                            bkclr = Color.Yellow
                        Case 7
                            bkclr = Color.White
                    End Select

                    dgv1.Rows(i).HeaderCell.Style.BackColor = bkclr

                End If

                For j = i + 1 To dgv1.RowCount - 2
                    If dgv1(1, j).Value = itmnm Then
                        dgv1(0, j).Value = sn
                        dgv1.Rows(j).HeaderCell.Style.BackColor = bkclr
                    End If
                Next
            Next
            Try
                dgv1.CurrentCell = ccell
            Catch
            End Try

            If chkBxAutoStuff.Checked = True Then
                For i = 0 To Dgv1Dup.RowCount - 2
                    sn = Dgv1Dup(0, i).Value
                    itmnm = Dgv1Dup(1, i).Value

                    bkclr = Dgv1Dup.Rows(i).HeaderCell.Style.BackColor

                    If bkclr.Name = "0" Then

                        Dim colval As Short = Val(Dgv1Dup(0, i).Value)     'Val(dgv1(0, 1).Value)

                        If colval > 7 Then colval = colval - 7 'If colval > 6 Then colval = colval - 6

                        Select Case colval              'Val(dgv1(0, i).Value)
                            Case 1
                                bkclr = Color.Red
                            Case 2
                                bkclr = Color.Green
                            Case 3
                                bkclr = Color.Blue
                            Case 4
                                bkclr = Color.Magenta
                            Case 5
                                bkclr = Color.Cyan
                            Case 6
                                bkclr = Color.Yellow
                            Case 7
                                bkclr = Color.White
                        End Select

                        Dgv1Dup.Rows(i).HeaderCell.Style.BackColor = bkclr

                    End If

                    For j = i + 1 To Dgv1Dup.RowCount - 2
                        If Dgv1Dup(1, j).Value = itmnm Then
                            Dgv1Dup(0, j).Value = sn
                            Dgv1Dup.Rows(j).HeaderCell.Style.BackColor = bkclr
                        End If
                    Next
                Next

            End If

            ShowStuff.ShowStuff(Me)
Bindone:
            GC.Collect()

            Dim colqty, colstuff, colbal As Int16

            For i = 0 To dgv1.Columns.Count - 1
                If dgv1.Columns(i).HeaderText.ToLower = "quantity" Then colqty = i
                If dgv1.Columns(i).HeaderText.ToLower = "stuffqty" Then colstuff = i
                If dgv1.Columns(i).HeaderText.ToLower = "balqty" Then colbal = i
            Next

            Try
                Dim ocol As DataGridViewColumn = dgv1.Columns(0)
                For i = 0 To dgv1.RowCount - 2
                    dgv1(0, i).Value = CInt(dgv1(0, i).Value)
                Next

                dgv1.Sort(ocol, 0)
            Catch
            End Try

            i = 0
            Dim col0, col10, col13, col14 As Int16
            Dim xcol0, xcol10, xcol13, xcol14 As Int16

            For i = 0 To dgv1.RowCount - 2
                col0 = dgv1(0, i).Value
                xcol0 = dgv1(0, i + 1).Value
                If col0 = xcol0 Then
                    col10 = Val(dgv1(colqty, i).Value)
                    col13 = Val(dgv1(colstuff, i).Value)
                    col14 = Val(dgv1(colbal, i).Value)
                    xcol10 = Val(dgv1(colqty, i + 1).Value)
                    xcol13 = Val(dgv1(colstuff, i + 1).Value)

                    xcol14 = Val(dgv1(colbal, i + 1).Value)
                    dgv1(colqty, i).Value = col10 + xcol10
                    dgv1(colstuff, i).Value = col13 + xcol13
                    dgv1(colbal, i).Value = col14 + xcol14
                    dgv1(colqty, i + 1).Value = 0
                    dgv1(colstuff, i + 1).Value = 0
                    dgv1(colbal, i + 1).Value = 0
                    dgv1(colqty - 1, i).Value = 0
                End If

            Next

            i = 0
            j = dgv1.RowCount - 2

            Try
                Do While i <= j
                    If dgv1(colqty, i).Value = 0 Then
                        dgv1.Rows.RemoveAt(i)
                        j -= 1
                    Else
                        i += 1
                    End If
                Loop
            Catch
            End Try

            Try
                dgv1.CurrentCell = dgv1(ccell.ColumnIndex, dgv1.RowCount - 2)
            Catch
                Exit Sub
            End Try

            If chkBxAutoStuffRC.Checked = True Then
                Bo += 1
                If Bo > 2 Then
                    GoTo nextp
                End If
                GoTo Bindone
            End If
nextp:
            ShowButton.Visible = False
            showbutton1.Visible = False
            dgv1.ResumeLayout()
            dgv1.ScrollBars = ScrollBars.Both

            If chkBxAutoStuff.Checked = True Then
                Call DuplDgvCl()
            End If

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in Show activity", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            MessageBox.Show("Close application due to fatal error", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Application.Exit()
        Finally
            'Call OLEDBCompactDb()
        End Try

    End Sub

    Private Sub dgv1_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles dgv1.Scroll

        ShowButton.Visible = False
        showbutton1.Visible = False

        'ShowButton.Visible = False
        'ShowButton.Top = 0
        'ShowButton.Left = 0
        'ShowButton.Width = 0
        'ShowButton.Height = 0

        'Try
        '    y1 = dgv1.Rows(0).Height * -(e.OldValue - e.NewValue)
        '    y2 = y2 - y1

        '    If ShowButton.Visible Then
        '        ShowButton.Top = ShowButton.Top - y1
        '    End If


        'Catch ex As Exception
        '    MsgBox(ex.Message)
        '    MsgBox(ex.ToString)
        '    MessageBox.Show("Error in dgv1_Scroll", "Error....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim r As New RectBox

        r.xxxx()

        Dim mm() As System.Diagnostics.Process
        'mm = Process.GetProcessesByName("alteros.exe")
        mm = Process.GetProcesses
        For i As Integer = LBound(mm) To UBound(mm)
            If mm(i).MainWindowTitle.Length = 10 Then
                If mm(i).MainWindowTitle.Substring(0, 7).ToLower() = "alteros" Then
                    Dim mnj As Graphics = Graphics.FromHwndInternal(mm(i).Handle)
                    Dim pt1 As New System.Drawing.Point
                    Dim pt2 As New System.Drawing.Point
                    pt1.X = 0
                    pt1.Y = 0
                    pt2.X = 100
                    pt2.Y = 100
                    Dim mnjh As New System.Drawing.Size
                    mnjh.Height = 100
                    mnjh.Width = 100
                    mnj.CopyFromScreen(pt1, pt2, mnjh)
                    mnj.DrawLine(Pens.Aqua, 0, 0, 50, 50)
                    Dim mn As New Bitmap(2000, 2000, mnj)
                    mn.Save("aa.bmp")

                    Exit For
                End If
90:         End If
        Next

    End Sub

    Private Sub showbutton1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles showbutton1.MouseClick

        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            rwidx = dgv1.CurrentCell.RowIndex
            Dim rowno1 As Integer = rwidx
            If dgv1.CurrentCell.ColumnIndex = 14 Then
                If itemstuffed(dgv1.Item(1, rowno1).Value, sender, e) Then
                    strtword(app)
                    Dim lst As contret

                    lst = generatecontainer(app, DtReceipt.Value.ToString, TxtRecNo.Text)
                    Try
                        If CheckBox1.Checked Then
                            generate1(app.Documents.Item(1), dgv1.Item(1, rowno1).Value, lst, dgv1.Item(0, rowno1).Value)
                        Else
                            generate(app.Documents.Item(1), dgv1.Item(1, rowno1).Value, lst, dgv1.Item(0, rowno1).Value)
                        End If
                    Catch e1 As Exception
                        Exit Sub
                    End Try
                    Exit Sub
                Else
                    Exit Sub
                End If
            End If

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in showbutton layout", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Function itemstuffed(ByVal itmnm As String, ByVal send As Object, ByVal obj As System.Windows.Forms.MouseEventArgs) As Boolean

        Dim cmd As New OleDb.OleDbCommand
        Dim rdr As OleDb.OleDbDataReader

        Try

            If conn.State = ConnectionState.Closed Then conn.Open()

            cmd.Connection = conn
            cmd.CommandText = "select * from stuffdata where itemname ='" & itmnm & "'"
            rdr = cmd.ExecuteReader

            If Not rdr.HasRows Then
                Dim mRs As MsgBoxResult = MessageBox.Show("Item not stuffed. Do you want to stuff", "P-Stuff", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If mRs = MsgBoxResult.Yes Then

                    Me.Focus()
                    ShowButton.Visible = True
                    showbutton1.Visible = False
                    ShowButton.Focus()

                    dgv1.CurrentCell = dgv1(12, dgv1.RowCount - 2)
                    Me.ShowButton_MouseClick(send, obj)

                    rdr.Close()
                    Return True

                ElseIf mRs = MsgBoxResult.No Then

                    MsgBox("Item not stuffed. Cannot show layout.")
                    Return False

                End If
            Else
                rdr.Close()
                Return True
            End If

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in itemstuffed", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function

    Public Sub ThreeDViewer()

        Try
            Eventless()
            Stuff_Viewers.Show()
            Stuff_Viewers.Focus()
        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MsgBox(Ex.Message, MsgBoxStyle.Critical, "Exception :: In Procedure 'ThreeDViewer'  " & vbCrLf & "VRML Programme Running is failure!")
            Me.Close()
        Finally
            GC.Collect()
        End Try

    End Sub

    Public Sub btnStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStatus.Click
        '    Private Sub btnStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStatus.Click

        Try
            mClk = False
            StopFlg = True
            Call Form8.Button1_Click(sender, e)
        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in statusbutton ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        ActivitySettings.Show()
        ActivitySettings.Focus()

    End Sub

    Private Sub dgvI_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv1.CellClick
        '' paste the code to dgv1_mouseclick event

    End Sub

    Private Sub dgv1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv1.CellDoubleClick

        'Calculation.btnOk1.Visible = False

        'If e.ColumnIndex = 11 Then
        '    Calculation.Show()
        '    Rdgv1 = e.RowIndex
        '    Cdgv1 = e.ColumnIndex
        'End If

        ''Rdgv1 = e.RowIndex
        ''Cdgv1 = e.ColumnIndex


        'dgv1.Item(e.ColumnIndex, e.RowIndex).Value = cReslt

    End Sub

    Public Sub dgvValAsgn()

        Dim Rval As Integer = Math.Round(Calculation.cReslt)

        dgv1.Item(Calculation.Cdgv1, Calculation.Rdgv1).Value = Rval

        dgv1.Refresh()
        Me.Refresh()

    End Sub

    Private Sub TransactionMenu_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DoubleClick

        Try

            If ColDlgTranFrm.ShowDialog Then
                Me.BackColor = ColDlgTranFrm.Color
            End If

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in TransactionMenu_DoubleClick", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub TransactionMenu_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Try
            Call AnimateWindow(Me.Handle, 1500, AnimateStyles.HOR_Negative Or AnimateStyles.Center)
            Call MDIForm.BringFront()

            stk.Clear()
            Bplclst.Clear()
        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in close the menu", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TransactionMenu_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        Try

            If e.KeyCode = Keys.Escape Then Close()


            If e.KeyCode = Keys.ControlKey + Keys.S Then

                Dim f As System.Windows.Forms.MouseEventArgs = New MouseEventArgs(Windows.Forms.MouseButtons.Left, 0, 0, 0, 0)

                ShowButton_MouseClick(sender, f)

            End If

        Catch Bg As Exception
            MsgBox(Bg.Message)
            MsgBox(Bg.ToString)
            MessageBox.Show("Error in key down close the menu", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub TransactionMenu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            NumUdDimnsSizeRatio.Cursor = Cursors.Hand
            Str = Nothing
            Call TransactionMenu_Resize(sender, e)
            'Me.AutoScroll = True
            'Me.WindowState = FormWindowState.Minimized
            GC.Collect()
            Me.Cursor = Cursors.WaitCursor
            'Me.Cursor = Cursors.Arrow
            ShowButton.BackColor = Color.MediumTurquoise
            BoxStatusStriplbl.Text = "Pick the activity"
            DisplayActivity.Close()
            ChooseActivity.Close()
            'btnPause.BackColor = Color.Green
            'btnBoxType.Enabled = False

            Dim cc As DataGridViewComboBoxColumn

            BFlag = False
            Button1.BackColor = Color.LightYellow
            Button1.ForeColor = Color.DarkRed
            CheckBox1.Checked = False

            If conn.State = ConnectionState.Closed Then conn.Open()

            dgEmpty.Visible = False
            dgUsage.Visible = False
            Label6.Visible = False
            Label7.Visible = False

            Call getContainerName()
            Call getAllReceiptNo()
            Call ItmePackName()

            '**********************************

            With dgv1

                .AutoGenerateColumns = False
                .DataSource = Ds1.Tables("TabIDetail")
                .ColumnHeadersDefaultCellStyle.BackColor = Color.FloralWhite
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.Black
                .ColumnHeadersDefaultCellStyle.Font = New Font(dgv1.Font, FontStyle.Bold)
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

            dgv1.AutoGenerateColumns = False
            dgv1.ColumnHeadersHeight = 30
            dgv1.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect
            dgv1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing

            dgv1.RowHeadersVisible = True
            dgv1.RowHeadersWidth = 21

            With dgv1.ColumnHeadersDefaultCellStyle
                .ForeColor = Color.Blue
                '.Font = New Font("Ms Sans Serif", 12, FontStyle.Bold, GraphicsUnit.Point)
            End With

            cc = dgv1.Columns(1)
            cc.DataSource = Ds1.Tables("TabPack").DefaultView
            cc.DisplayMember = "packname"
            cc.ValueMember = "packname"

            '**********************************
            'Call getAllInwardDetail()
            cmdUpdate.Enabled = False
            cmdRef.Enabled = False

            If Ds1.Tables!TabIHead.Rows.Count = 0 Then
                Call NoRecorddisplay()
                Call Txtclear()
                Exit Sub

            ElseIf Ds1.Tables!TabIHead.Rows.Count - 1 >= 0 Then

                Introw = Ds1.Tables!TabIHead.Rows.Count - 1

                Call TxtBind()
                Call loadenable()

            End If

            Call btnDoor_Click(sender, e)
            Me.Cursor = Cursors.Arrow

            Call gridColor()

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in TransactionMenu_Load", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally

            'Call AnimateWindow(Me.Handle, 1500, AnimateStyles.HOR_Positive Or AnimateStyles.Center)

            Call MemoryManagement.FlushMemory()
            GC.Collect()
            Me.Cursor = Cursors.Default

            Call Form10.utilityProgressBarGet()    ' The progress bar setting loading

        End Try

    End Sub

    Protected Sub nogridcolor()

        Try
            Dim GrdCol As Drawing.Color = dgv1.Columns(0).HeaderCell.Style.BackColor
            Dim k As Integer = 0
            For k = 0 To dgv1.RowCount - 2
                dgv1.Rows(k).HeaderCell.Style.BackColor = GrdCol
                'dgv1(0, k).Style.BackColor = Color.White
            Next
        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in nogridcolor", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Protected Sub gridColor()

        Dim j, k As Integer
        Dim SrN As Int16
        Dim INm As String
        Dim BkCol As Drawing.Color
        Dim CrCell As DataGridViewCell = dgv1.CurrentCell

        Try

            For j = 0 To dgv1.RowCount - 2

                SrN = dgv1.Item(0, j).Value
                INm = dgv1.Item(1, j).Value
                BkCol = dgv1.Rows(j).HeaderCell.Style.BackColor

                If BkCol.Name = "0" Then

                    Dim ColVal As Short = Val(dgv1.Item(0, j).Value)    'Val(dgv1.Item(0, 1).Value)

                    If ColVal > 7 Then ColVal = ColVal - 7

                    Select Case ColVal                  'Val(dgv1(0, j).Value)

                        Case 1
                            BkCol = Color.Red
                        Case 2
                            BkCol = Color.Green
                        Case 3
                            BkCol = Color.Blue
                        Case 4
                            BkCol = Color.Magenta
                        Case 5
                            BkCol = Color.Cyan
                        Case 6
                            BkCol = Color.Yellow
                        Case 7
                            BkCol = Color.White
                    End Select

                    dgv1.Rows(j).HeaderCell.Style.BackColor = BkCol
                    'dgv1(0, j).Style.BackColor = BkCol

                End If

                For k = j + 1 To dgv1.RowCount - 2

                    If dgv1(1, k).Value = INm Then
                        dgv1(0, k).Value = SrN
                        dgv1.Rows(k).HeaderCell.Style.BackColor = BkCol
                        'dgv1(0, k).Style.BackColor = BkCol
                    End If

                Next
            Next

            CrCell = dgv1.CurrentCell

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in gridColor", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Txtclear()

        Try
            TxtRecNo.Text = ""
            DtReceipt.Value = Today
            CmbContainer.SelectedIndex = -1
            dgv1.Rows.Clear()
            TxtCapacity.Text = ""
            TxtPayLoad.Text = ""
            TxtOccuCbm.Text = ""
            TxtOccuKgs.Text = ""
            TxtFreeCbm.Text = ""
            TxtFreeKgs.Text = ""
            Label8.Text = ""
            lblTotQty.Text = ""
            lblTotVol.Text = ""
            lblTotWt.Text = ""

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in Txtclear", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub getContainerName()

        Try

            Dim StrSQL As String
            StrSQL = "Select * From ContainerMaster ORDER BY ContainerName"
            If conn.State = ConnectionState.Closed Then conn.Open()
            Da1 = New SDO.OleDbDataAdapter(StrSQL, conn)

            If Ds1.Tables.CanRemove(Ds1.Tables("TabContainer")) = True Then
                Ds1.Tables("TabContainer").Rows.Clear()
                Ds1.Tables("TabContainer").Columns.Clear()
            End If

            Da1.Fill(Ds1, "TabContainer")

            'conn.close()
            CmbContainer.DataSource = Nothing
            CmbContainer.DataSource = Ds1.Tables("TabContainer").DefaultView
            CmbContainer.DisplayMember = "ContainerName"

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in getContainerName", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub getAllReceiptNo()

        Try
            Dim MComm As New SDO.OleDbCommand("select distinct receiptno,ReceiptDate,ContainerName from NInwardDetail order by receiptno", conn)
            Da1 = New SDO.OleDbDataAdapter(MComm)
            If Ds1.Tables.CanRemove(Ds1.Tables("TabIHead")) = True Then
                Ds1.Tables("TabIHead").Rows.Clear()
                Ds1.Tables("TabIHead").Columns.Clear()
            End If
            Da1.Fill(Ds1, "TabIHead")
            'If conn.State = ConnectionState.Open Then 'conn.close()

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in getAllReceiptNo", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub TxtBind()

        Try

            TxtRecNo.Text = Ds1.Tables!TabIHead.Rows(Introw).Item("receiptno")
            DtReceipt.Value = Ds1.Tables!TabIHead.Rows(Introw).Item("ReceiptDate")
            CmbContainer.Text = Ds1.Tables!TabIHead.Rows(Introw).Item("ContainerName")
            Call getAllInwardDetail()

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in TxtBind", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub getAllInwardDetail()

        Try

            Call ContainerDimension()

            Dim MComm As New SDO.OleDbCommand("select * from NInwardDetail where receiptno=" & Val(TxtRecNo.Text), conn)
            Da1 = New SDO.OleDbDataAdapter(MComm)
            gbUnits.Enabled = False

            If Ds1.Tables.CanRemove(Ds1.Tables("TabIDetail")) = True Then

                Ds1.Tables("TabIDetail").Rows.Clear()
                Ds1.Tables("TabIDetail").Columns.Clear()

            End If

            Da1.Fill(Ds1, "TabIDetail")
            'If conn.State = ConnectionState.Open Then 'conn.close()
            Dim i As Int16
            Try
                dgv1.Rows.Clear()
            Catch
            End Try

            Dim Unit As String = Nothing

            '***********************************************************
            'Dim clm As DataGridViewComboBoxCell
            'clm = dgv1.Item(7, e.RowIndex)
            'clm.Items.AddRange(New Object() {"6", "2"})
            ''clm.Items.AddRange(New Object() {"2", "6"})
            ''clm.Value = "2"
            'clm.Value = "6"
            '***********************************************************

            Dim totQty As Int64 = Nothing
            Dim totWt As Double = Nothing
            Dim totVol As Double = Nothing
            Dim totQtyrv As Int64 = Nothing
            Dim totWtrv As Double = Nothing
            Dim totVolrv As Double = Nothing

            Dim clm As DataGridViewComboBoxCell

            For i = 0 To Ds1.Tables("TabIDetail").Rows.Count - 1

                flgOrient = True

                Dim stro1 As String = Nothing
                Dim stro2 As String = Nothing

                dgv1.Rows.Add()
                dgv1.Item(0, i).Value = Ds1.Tables!TabIDetail.Rows(i).Item("SerialNo")
                dgv1.Item(1, i).Value = Ds1.Tables!TabIDetail.Rows(i).Item("ItemName")
                dgv1.Item(2, i).Value = Ds1.Tables!TabIDetail.Rows(i).Item("PackTypeName")
                totVol = Ds1.Tables!TabIDetail.Rows(i).Item("Size")
                totVolrv += totVol
                dgv1.Item(3, i).Value = totVol              'dgv1.Item(3, i).Value = Ds1.Tables!TabIDetail.Rows(i).Item("Size")
                dgv1.Item(4, i).Value = Ds1.Tables!TabIDetail.Rows(i).Item("Length")
                dgv1.Item(5, i).Value = Ds1.Tables!TabIDetail.Rows(i).Item("Width")
                dgv1.Item(6, i).Value = Ds1.Tables!TabIDetail.Rows(i).Item("Height")
                stro1 = Ds1.Tables!TabIDetail.Rows(i).Item("Orient")
                dgv1.Item(7, i).Value = stro1                                       'Ds1.Tables!TabIDetail.Rows(i).Item("Orient")
                totWt = Ds1.Tables!TabIDetail.Rows(i).Item("Seq")
                totWtrv += totWt
                dgv1.Item(8, i).Value = totWt               'dgv1.Item(8, i).Value = Ds1.Tables!TabIDetail.Rows(i).Item("Seq")
                dgv1.Item(10, i).Value = Ds1.Tables!TabIDetail.Rows(i).Item("Maxqty")
                totQty = Ds1.Tables!TabIDetail.Rows(i).Item("Quantity")
                totQtyrv += totQty
                dgv1.Item(11, i).Value = totQty             'dgv1.Item(11, i).Value = Ds1.Tables!TabIDetail.Rows(i).Item("Quantity")
                Unit = Ds1.Tables!TabIDetail.Rows(i).Item("Unit")

                If stro1 = "2" Then         ' Satwadhir 18 Jan 2K10 3.29 PM
                    stro2 = "6"
                ElseIf stro1 = "6" Then
                    stro2 = "2"
                End If

                clm = dgv1.Item(7, i)
                clm.Items.AddRange(New Object() {stro1, stro2})
                clm.Value = stro1

            Next

            If Unit = "English" Then
                rdbMetric.Checked = False
                rdbEnglish.Checked = True
                lblCapacity.Text = "Cu.M."
                lblOccupied.Text = "Cu.M."
                lblFree.Text = "Cu.M."

                'CL = 25.4 / CL
                'CW = 25.4 / CW
                'CH = 25.4 / CH

                'contarr(0) = CL
                'contarr(1) = CW
                'contarr(2) = CH

                'lblContDim.Text = "Length=" & Format(CL, "0.00") & "  Width=" & Format(CW, "0.00") & "  Height=" & Format(CH, "0.00")
                'lblContDim.Refresh()

                lblTotQty.Text = "Total Quantity  = " & totQtyrv
                lblTotWt.Text = "Weight Sum   = " & Format(totWtrv, "0.00") & " Kg."
                lblTotVol.Text = "Volume Sum   = " & Format(totVolrv, "0.00") & " Cu.M."


            ElseIf Unit = "Metric" Then

                rdbMetric.Checked = True
                rdbEnglish.Checked = False

                lblCapacity.Text = "Cu.MM."
                lblOccupied.Text = "Cu.MM."
                lblFree.Text = "Cu.MM."

                TxtCapacity.Text = Val(TxtCapacity.Text) * (25.4 * 25.4 * 25.4)

                CL = 25.4 * CL
                CW = 25.4 * CW
                CH = 25.4 * CH

                contarr(0) = CL
                contarr(1) = CW
                contarr(2) = CH

                lblContDim.Text = "Length = " & Format(CL, "0.00") & "  Width = " & Format(CW, "0.00") & "  Height = " & Format(CH, "0.00")
                lblContDim.Refresh()

                lblTotQty.Text = "Total Quantity = " & totQtyrv
                lblTotWt.Text = "Weight Sum    = " & Format(totWtrv, "0.00") & " Kg."
                lblTotVol.Text = "Volume Sum   = " & Format(totVolrv, "0.00") & " Cu.MM."

            End If

            gbUnits.Enabled = False

            Call gridColor()

            Me.Refresh()

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in getAllInwardDetail", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            flgOrient = False
        End Try

    End Sub

    Public Sub InsrtDgvDbAutoStuff()

        Dim SrN As Int32 = 0
        Dim INm As String = Nothing
        Dim Pck As String = Nothing
        Dim Sz As Double = 0
        Dim Ln As Double = 0
        Dim Wd As Double = 0
        Dim Ht As Double = 0
        Dim Ori As Int16 = 0
        Dim Wt As Double = 0
        Dim MxQty As Int32 = 0
        Dim UQty As Int32 = 0

        Try

            For Rg = 0 To dgv1.RowCount - 2
                SrN = dgv1.Item(0, Rg).Value
                INm = dgv1.Item(1, Rg).Value
                Pck = dgv1.Item(2, Rg).Value
                Sz = dgv1.Item(3, Rg).Value
                Ln = dgv1.Item(4, Rg).Value
                Wd = dgv1.Item(5, Rg).Value
                Ht = dgv1.Item(6, Rg).Value
                Ori = dgv1.Item(7, Rg).Value
                Wt = dgv1.Item(8, Rg).Value
                MxQty = dgv1.Item(10, Rg).Value
                UQty = dgv1.Item(11, Rg).Value

                DbTrackIns(SrN, INm, Pck, Sz, Ln, Wd, Ht, Ori, Wt, MxQty, UQty)

                SrN = SrN
                INm = INm
                Ln = Ln
                Wd = Wd
                Ht = Ht
                Ori = Ori
                UQty = UQty

                'Dim Qz As Int64 = 0
                'Dim Qy As Int64 = 0
                'Dim Qx As Int64 = 0

                'Dim Qzz As Double = 0
                'Dim Qyy As Double = 0
                'Dim Qxx As Double = 0

                'Dim Frcl As Int64 = 0
                'Dim Rcnt As Int64 = 0
                'Dim FnlQty As Int64 = 0
                'Dim RemnQty As Int64 = 0

                'Dim Bxx As Int64 = 0
                'Dim Byy As Int64 = 0
                'Dim Bzz As Int64 = 0

                'Qzz = CH / Ln
                'Qyy = CW / Wd
                'Qxx = CL / Ht

                'Qz = Math.Floor(Qzz)
                'Qy = Math.Floor(Qyy)
                'Qx = Math.Floor(Qxx)

                'Frcl = CInt(Qz * Qy)
                'Rcnt = CInt(UQty / Frcl)
                'FnlQty = CInt(Rcnt * Frcl)

                'RemnQty = UQty - FnlQty

                'If FnlQty < 0 Then
                '    FnlQty = -RemnQty
                'End If

            Next

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in InsrtDgvDbAutoStuff", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cons.Close()
        End Try

    End Sub

    ' User entering the container and goods and goods quantity the manipulation of 
    ' container dimensions with goods dimensions to find out the particular quantity in random 
    ' to properly arrange it in to container and it’s shown to data grid of transaction form.

    Public Sub InsrtDgvDb()

        Dim SrN As Int32 = 0
        Dim INm As String = Nothing
        Dim Pck As String = Nothing
        Dim Sz As Double = 0
        Dim Ln As Double = 0
        Dim Wd As Double = 0
        Dim Ht As Double = 0
        Dim Ori As Int16 = 0
        Dim Wt As Double = 0
        Dim MxQty As Int32 = 0
        Dim UQty As Int32 = 0

        Try
            For Rg = 0 To dgv1.RowCount - 2

                SrN = dgv1.Item(0, Rg).Value
                INm = dgv1.Item(1, Rg).Value
                Pck = dgv1.Item(2, Rg).Value
                Sz = dgv1.Item(3, Rg).Value
                Ln = dgv1.Item(4, Rg).Value
                Wd = dgv1.Item(5, Rg).Value
                Ht = dgv1.Item(6, Rg).Value
                Ori = dgv1.Item(7, Rg).Value
                Wt = dgv1.Item(8, Rg).Value
                MxQty = dgv1.Item(10, Rg).Value
                UQty = dgv1.Item(11, Rg).Value

                DbTrackIns(SrN, INm, Pck, Sz, Ln, Wd, Ht, Ori, Wt, MxQty, UQty)

                '#####

                SrN = SrN
                INm = INm
                Ln = Ln
                Wd = Wd
                Ht = Ht
                Ori = Ori
                UQty = UQty

                '================================================
                'Dim Qz As Integer = 0
                'Dim Qy As Integer = 0
                'Dim Qx As Integer = 0

                'Dim Qzz As Double = 0
                'Dim Qyy As Double = 0
                'Dim Qxx As Double = 0

                'Dim FrcL As Integer = 0
                'Dim Rcnt As Integer = 0
                'Dim FnlQty As Integer = 0
                'Dim RemnQty As Integer = 0

                'Dim BXx As Integer = 0
                'Dim Byy As Integer = 0
                'Dim Bzz As Integer = 0

                ''================================================

                'Qzz = CH / Ln
                'Qyy = CW / Wd
                'Qxx = CL / Ht

                'Qz = Math.Floor(Qzz)
                'Qy = Math.Floor(Qyy)
                'Qx = Math.Floor(Qxx)

                'FrcL = Qz * Qy
                'Rcnt = UQty / FrcL
                'FnlQty = Rcnt * FrcL

                'RemnQty = UQty - FnlQty

                'If FnlQty < 0 Then
                '    FnlQty = -RemnQty
                'End If

                ' ''#####

                'AutoStuffIns(SrN, INm, Ln, Wd, Ht, Ori, FnlQty, Qz, Qy, Qx, FrcL, Rcnt, FnlQty, RemnQty)

                'Public Sub AutoStuffIns(ByVal SrN As Integer, ByVal INm As String, ByVal L As Double, ByVal W As Double, ByVal H As Double, ByVal Orint As Integer, ByVal Qty As Integer, ByVal Qz As Integer, ByVal Qy As Integer, ByVal Qx As Integer, ByVal FcrL As Integer, ByVal RowCont As Integer, ByVal FnlQtys As Integer, ByVal RemnQtys As Integer)

            Next

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in InsrtDgvDb", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cons.Close()
        End Try

    End Sub

    Public Sub DbTrackInsDup()
        'Stop
        Try
            Dim SN As Integer = 1
            Dim Dgn As Integer = 0
            Dim SrN As Int32 = 0
            Dim INm As String = Nothing
            Dim Pck As String = Nothing
            Dim Sz As Double = 0
            Dim L As Double = 0
            Dim W As Double = 0
            Dim H As Double = 0
            Dim Ori As Int16 = 0
            Dim Wt As Double = 0
            Dim MxQty As Int32 = 0
            Dim UQty As Int32 = 0

            Try

                If Cons.State = ConnectionState.Closed Then Cons.Open()
                Dim cmds As New OleDb.OleDbCommand
                Dim Rdrs As OleDb.OleDbDataReader
                cmds.Connection = Cons

                If ADflg Then

                    cmds.CommandText = "select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA order by Qty asc"
                    ADflg = False
                    BoxStatusStriplbl.Text = "Data arranged by lower to higher quantity"
                Else
                    cmds.CommandText = "select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA order by Qty desc"
                    ADflg = True
                    BoxStatusStriplbl.Text = "Data arranged by higher to lower quantity"
                End If

                Rdrs = cmds.ExecuteReader

                'Stop

                Do While (Rdrs.Read())

                    SrN = Rdrs("SrNo")
                    INm = Rdrs("ItmName")
                    Pck = Rdrs("Pack")
                    Sz = Rdrs("Sizes")
                    L = Rdrs("Length")
                    W = Rdrs("Width")
                    H = Rdrs("Height")
                    Ori = Rdrs("Orient")
                    Wt = Rdrs("Wt")
                    MxQty = Rdrs("MaxQty")
                    UQty = Rdrs("Qty")

                    dgv1.Item(0, Dgn).Value = SN
                    dgv1.Item(1, Dgn).Value = INm
                    dgv1.Item(2, Dgn).Value = Pck
                    dgv1.Item(3, Dgn).Value = Sz
                    dgv1.Item(4, Dgn).Value = L
                    dgv1.Item(5, Dgn).Value = W
                    dgv1.Item(6, Dgn).Value = H
                    dgv1.Item(7, Dgn).Value = Ori
                    dgv1.Item(8, Dgn).Value = Wt
                    dgv1.Item(10, Dgn).Value = MxQty
                    dgv1.Item(11, Dgn).Value = UQty

                    DbTrackDupIns(SN, INm, Pck, Sz, L, W, H, Ori, Wt, MxQty, UQty)

                    SN = SN + 1
                    Dgn = Dgn + 1
                Loop

            Catch Err As Exception
                MsgBox(Err.Message)
                MsgBox(Err.ToString)
                MessageBox.Show("Error in DbTrackInsDup", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Cons.Close()
            End Try

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in DbTrackInsDup", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub snDbTrackInsDup()
        'Stop
        Try
            Dim Dgn As Integer = 0
            Dim SrN As Int32 = 0
            Dim INm As String = Nothing
            Dim Pck As String = Nothing
            Dim Sz As Double = 0
            Dim L As Double = 0
            Dim W As Double = 0
            Dim H As Double = 0
            Dim Ori As Int16 = 0
            Dim Wt As Double = 0
            Dim MxQty As Int32 = 0
            Dim UQty As Int32 = 0

            Try
                If Cons.State = ConnectionState.Closed Then Cons.Open()
                Dim cmds As New OleDb.OleDbCommand
                Dim Rdrs As OleDb.OleDbDataReader
                cmds.Connection = Cons

                If ADflg Then
                    cmds.CommandText = "select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA order by Qty asc"
                    ADflg = False
                    BoxStatusStriplbl.Text = "Data arranged by lower to higher quantity"
                Else
                    cmds.CommandText = "select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA order by Qty desc"
                    ADflg = True
                    BoxStatusStriplbl.Text = "Data arranged by higher to lower quantity"
                End If

                Rdrs = cmds.ExecuteReader

                'Stop

                Do While (Rdrs.Read())

                    SrN = Rdrs("SrNo")
                    INm = Rdrs("ItmName")
                    Pck = Rdrs("Pack")
                    Sz = Rdrs("Sizes")
                    L = Rdrs("Length")
                    W = Rdrs("Width")
                    H = Rdrs("Height")
                    Ori = Rdrs("Orient")
                    Wt = Rdrs("Wt")
                    MxQty = Rdrs("MaxQty")
                    UQty = Rdrs("Qty")

                    dgv1.Item(0, Dgn).Value = SrN
                    dgv1.Item(1, Dgn).Value = INm
                    dgv1.Item(2, Dgn).Value = Pck
                    dgv1.Item(3, Dgn).Value = Sz
                    dgv1.Item(4, Dgn).Value = L
                    dgv1.Item(5, Dgn).Value = W
                    dgv1.Item(6, Dgn).Value = H
                    dgv1.Item(7, Dgn).Value = Ori
                    dgv1.Item(8, Dgn).Value = Wt
                    dgv1.Item(10, Dgn).Value = MxQty
                    dgv1.Item(11, Dgn).Value = UQty

                    DbTrackDupIns(SN, INm, Pck, Sz, L, W, H, Ori, Wt, MxQty, UQty)

                    SN = SN + 1
                    Dgn = Dgn + 1

                Loop

            Catch Err As Exception
                MsgBox(Err.Message)
                MsgBox(Err.ToString)
                MessageBox.Show("Error in snDbTrackInsDup", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Cons.Close()
            End Try

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in snDbTrackInsDup", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub DbTrackInsDupMxQty()
        'Stop
        Try
            Dim SN As Integer = 1
            Dim Dgn As Integer = 0
            Dim SrN As Int32 = 0
            Dim INm As String = Nothing
            Dim Pck As String = Nothing
            Dim Sz As Double = 0
            Dim L As Double = 0
            Dim W As Double = 0
            Dim H As Double = 0
            Dim Ori As Int16 = 0
            Dim Wt As Double = 0
            Dim MxQty As Int32 = 0
            Dim UQty As Int32 = 0

            Try

                If Cons.State = ConnectionState.Closed Then Cons.Open()
                Dim cmds As New OleDb.OleDbCommand
                Dim Rdrs As OleDb.OleDbDataReader
                cmds.Connection = Cons

                If ADflg Then

                    cmds.CommandText = "select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA order by MaxQty asc"
                    ADflg = False
                    BoxStatusStriplbl.Text = "Data arranged by lower to higher quantity"
                Else
                    cmds.CommandText = "select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA order by MaxQty desc"
                    ADflg = True
                    BoxStatusStriplbl.Text = "Data arranged by higher to lower quantity"
                End If

                Rdrs = cmds.ExecuteReader

                'Stop
                Do While (Rdrs.Read())

                    SrN = Rdrs("SrNo")
                    INm = Rdrs("ItmName")
                    Pck = Rdrs("Pack")
                    Sz = Rdrs("Sizes")
                    L = Rdrs("Length")
                    W = Rdrs("Width")
                    H = Rdrs("Height")
                    Ori = Rdrs("Orient")
                    Wt = Rdrs("Wt")
                    MxQty = Rdrs("MaxQty")
                    UQty = Rdrs("Qty")

                    dgv1.Item(0, Dgn).Value = SN
                    dgv1.Item(1, Dgn).Value = INm
                    dgv1.Item(2, Dgn).Value = Pck
                    dgv1.Item(3, Dgn).Value = Sz
                    dgv1.Item(4, Dgn).Value = L
                    dgv1.Item(5, Dgn).Value = W
                    dgv1.Item(6, Dgn).Value = H
                    dgv1.Item(7, Dgn).Value = Ori
                    dgv1.Item(8, Dgn).Value = Wt
                    dgv1.Item(10, Dgn).Value = MxQty
                    dgv1.Item(11, Dgn).Value = UQty

                    DbTrackDupIns(SN, INm, Pck, Sz, L, W, H, Ori, Wt, MxQty, UQty)

                    SN = SN + 1
                    Dgn = Dgn + 1
                Loop

            Catch Err As Exception
                MsgBox(Err.Message)
                MsgBox(Err.ToString)
                MessageBox.Show("Error in DbTrackInsDupMxQty", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Cons.Close()
            End Try

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in DbTrackInsDup", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub snDbTrackInsDupMxQty()
        'Stop
        Try

            Dim Dgn As Integer = 0
            Dim SrN As Int32 = 0
            Dim INm As String = Nothing
            Dim Pck As String = Nothing
            Dim Sz As Double = 0
            Dim L As Double = 0
            Dim W As Double = 0
            Dim H As Double = 0
            Dim Ori As Int16 = 0
            Dim Wt As Double = 0
            Dim MxQty As Int32 = 0
            Dim UQty As Int32 = 0

            Try

                If Cons.State = ConnectionState.Closed Then Cons.Open()
                Dim cmds As New OleDb.OleDbCommand
                Dim Rdrs As OleDb.OleDbDataReader
                cmds.Connection = Cons

                If ADflg Then

                    cmds.CommandText = "select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA order by MaxQty asc"
                    ADflg = False
                    BoxStatusStriplbl.Text = "Data arranged by lower to higher quantity"
                Else
                    cmds.CommandText = "select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA order by MaxQty desc"
                    ADflg = True
                    BoxStatusStriplbl.Text = "Data arranged by higher to lower quantity"
                End If

                Rdrs = cmds.ExecuteReader

                'Stop

                Do While (Rdrs.Read())

                    SrN = Rdrs("SrNo")
                    INm = Rdrs("ItmName")
                    Pck = Rdrs("Pack")
                    Sz = Rdrs("Sizes")
                    L = Rdrs("Length")
                    W = Rdrs("Width")
                    H = Rdrs("Height")
                    Ori = Rdrs("Orient")
                    Wt = Rdrs("Wt")
                    MxQty = Rdrs("MaxQty")
                    UQty = Rdrs("Qty")

                    dgv1.Item(0, Dgn).Value = SrN
                    dgv1.Item(1, Dgn).Value = INm
                    dgv1.Item(2, Dgn).Value = Pck
                    dgv1.Item(3, Dgn).Value = Sz
                    dgv1.Item(4, Dgn).Value = L
                    dgv1.Item(5, Dgn).Value = W
                    dgv1.Item(6, Dgn).Value = H
                    dgv1.Item(7, Dgn).Value = Ori
                    dgv1.Item(8, Dgn).Value = Wt
                    dgv1.Item(10, Dgn).Value = MxQty
                    dgv1.Item(11, Dgn).Value = UQty

                    DbTrackDupIns(SN, INm, Pck, Sz, L, W, H, Ori, Wt, MxQty, UQty)

                    SN = SN + 1
                    Dgn = Dgn + 1
                Loop

            Catch Err As Exception
                MsgBox(Err.Message)
                MsgBox(Err.ToString)
                MessageBox.Show("Error in snDbTrackInsDupMxQty", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Cons.Close()
            End Try

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in snDbTrackInsDup", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub ItmePackName()

        Try
            dgv1.AutoGenerateColumns = False

            Dim mPack As SDO.OleDbCommand

            mPack = New SDO.OleDbCommand("select distinct packname from packmast", conn)

            Da1 = New SDO.OleDbDataAdapter(mPack)

            If Ds1.Tables.CanRemove(Ds1.Tables("TabPack")) = True Then
                Ds1.Tables("TabPack").Rows.Clear()
                Ds1.Tables("TabPack").Columns.Clear()
            End If

            Da1.Fill(Ds1, "TabPack")

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in ItmePackName", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    'The Originally one maximum quantity showing

    'Private Sub ComboBox_SelectedIndexChanged( _
    '  ByVal sender As Object, ByVal e As EventArgs)

    '    '**********************************************************************************************************************************

    '    'Stop
    '    Dim rowno1 As Integer

    '    Try
    '        GC.Collect()


    '        rwidx = dgv1.CurrentCell.RowIndex

    '        Dim comboBox1 As ComboBox = CType(sender, ComboBox)
    '        Dim tpup1 As Boolean

    '        rowno1 = rwidx

    '        If dgv1.CurrentCell.ColumnIndex = 1 Then

    '            itmnm = sender.text
    '            tpup1 = IIf(dgv1.Item(7, rwidx).Value = "6", False, True)

    '        Else
    '            itmnm = dgv1.Item(1, dgv1.CurrentCell.RowIndex).Value
    '            tpup1 = IIf(sender.text = "6", False, True)
    '        End If

    '        Dim cmd As New OleDb.OleDbCommand
    '        Dim rdr As OleDb.OleDbDataReader
    '        Dim lni As Single
    '        Dim wdi As Single
    '        Dim hti As Single
    '        Dim maxqty1 As Integer

    '        cmd.Connection = conn

    '        cmd.CommandText = "select lengthf,widthf,heightf,lengthi,widthi,heighti,lengthc,widthc,heightc,lengthm,widthm,heightm,grossweight,packingmode from packmast where packname ='" & itmnm & "'"
    '        If conn.State = ConnectionState.Closed Then conn.Open()
    '        rdr = cmd.ExecuteReader
    '        rdr.Read()

    '        Try
    '            lni = Val(Format((rdr("lengthi") + (12 * rdr("lengthf")) + (rdr("lengthc") / 2.54) + (rdr("lengthm") / 25.4)), "0.0000"))
    '        Catch
    '            Exit Sub
    '        End Try

    '        wdi = Val(Format((rdr("Widthi") + (12 * rdr("Widthf")) + (rdr("Widthc") / 2.54) + (rdr("Widthm") / 25.4)), "0.0000"))
    '        hti = Val(Format((rdr("heighti") + (12 * rdr("heightf")) + (rdr("heightc") / 2.54) + (rdr("heightm") / 25.4)), "0.0000"))
    '        dgv1.Item(1, rwidx).Value = itmnm
    '        dgv1.Item(4, rwidx).Value = lni
    '        dgv1.Item(5, rwidx).Value = wdi
    '        dgv1.Item(6, rwidx).Value = hti
    '        dgv1.Item(3, rwidx).Value = lni * wdi * hti * 0.000016387064   '/ 61024
    '        dgv1.Item(2, rwidx).Value = rdr("packingmode")
    '        dgv1.Item(8, rwidx).Value = rdr("grossweight")

    '        If Not CheckBox1.Checked Then
    '            'Dim ans = MsgBox("Do you want to calculate maximum quantity?", MsgBoxStyle.YesNo)

    '            Dim ans = MessageBox.Show("Do you want to calculate maximum quantity?", "Stuffing Entry", MessageBoxButtons.YesNo, MessageBoxIcon.Information)

    '            'Stop
    '            If ans = MsgBoxResult.Yes Then
    '                stk.Clear()
    '                stk.Add(arc)

    '                'DisplayPicture.btn_BoxesDiffDim.Visible = True
    '                'DisplayPicture.lblCSPPicDisplay.Refresh()
    '                'DHSDrums()

    '                Dim oldopt As Boolean = chkwt
    '                maxqty1 = calcmxqty(rwidx, tpup1)
    '                'maxqty1 = CalcShowMxQty(rwidx, tpup1)
    '                chkwt = oldopt
    '                Bplclst.Clear()
    '            End If
    '        End If

    '        rdr.Close()

    '    Catch Err As Exception
    '        GC.Collect()
    '        conn.Close()
    '        MsgBox(Err.Message)
    '        MsgBox(Err.ToString)
    '        MessageBox.Show("Error in ComboBox_SelectedIndexChanged", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        MessageBox.Show("Exit the application", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        Application.Exit()
    '    Finally
    '        Try
    '            dgv1.Item(10, rowno1).Value = BxItmQty         'dgv1.Item(10, rowno1).Value = Bitemqty
    '        Catch
    '        End Try
    '    End Try

    '    '**********************************************************************************************************************

    'End Sub

    '    Private Sub ComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)

    '        Try
    '            GC.Collect()

    '            Dim rowno1 As Integer

    '            rwidx = dgv1.CurrentCell.RowIndex

    '            Dim comboBox1 As ComboBox = CType(sender, ComboBox)
    '            Dim tpup1 As Boolean

    '            rowno1 = rwidx

    '            If dgv1.CurrentCell.ColumnIndex = 1 Then

    '                itmnm = sender.text
    '                tpup1 = IIf(dgv1.Item(7, rwidx).Value = "6", False, True)

    '            Else
    '                itmnm = dgv1.Item(1, dgv1.CurrentCell.RowIndex).Value
    '                tpup1 = IIf(sender.text = "6", False, True)
    '            End If

    '            Dim cmd As New OleDb.OleDbCommand
    '            Dim rdr As OleDb.OleDbDataReader
    '            Dim lni As Single
    '            Dim wdi As Single
    '            Dim hti As Single
    '            Dim maxqty1 As Integer

    '            cmd.Connection = conn

    '            cmd.CommandText = "select lengthf,widthf,heightf,lengthi,widthi,heighti,lengthc,widthc,heightc,lengthm,widthm,heightm,grossweight,packingmode from packmast where packname ='" & itmnm & "'"
    '            If conn.State = ConnectionState.Closed Then conn.Open()
    '            rdr = cmd.ExecuteReader
    '            rdr.Read()

    '            Try
    '                lni = Val(Format((rdr("lengthi") + (12 * rdr("lengthf")) + (rdr("lengthc") / 2.54) + (rdr("lengthm") / 25.4)), "0.0000"))
    '            Catch
    '                Exit Sub
    '            End Try

    '            wdi = Val(Format((rdr("Widthi") + (12 * rdr("Widthf")) + (rdr("Widthc") / 2.54) + (rdr("Widthm") / 25.4)), "0.0000"))
    '            hti = Val(Format((rdr("heighti") + (12 * rdr("heightf")) + (rdr("heightc") / 2.54) + (rdr("heightm") / 25.4)), "0.0000"))
    '            dgv1.Item(1, rwidx).Value = itmnm
    '            dgv1.Item(4, rwidx).Value = lni
    '            dgv1.Item(5, rwidx).Value = wdi
    '            dgv1.Item(6, rwidx).Value = hti
    '            dgv1.Item(3, rwidx).Value = lni * wdi * hti * 0.000016387064   '/ 61024
    '            dgv1.Item(2, rwidx).Value = rdr("packingmode")
    '            dgv1.Item(8, rwidx).Value = rdr("grossweight")


    '            Dim Reslt = MsgBox("Do you want to calculate maximum quantity ?", MsgBoxStyle.YesNo)

    '            If Reslt = MsgBoxResult.Yes Then

    '                MsgBox("Ok")

    '                Stop

    '                Dim ans As MsgBoxResult

    '                rwidx = dgv1.CurrentCell.RowIndex
    '                rowno1 = rwidx
    '                Dim plclst1 As New List(Of Integer)
    '                chkwt = True
    '                GoTo MxStp

    '                If dgv1.CurrentCell.ColumnIndex = 12 Or dgv1.CurrentCell.ColumnIndex = 13 Or dgv1.CurrentCell.ColumnIndex = 14 Then



    '                    If dgv1.Item(1, rowno1).Value Is Nothing _
    '                OrElse dgv1.Item(11, rowno1).Value Is Nothing _
    '                OrElse Not IsNumeric(dgv1.Item(11, rowno1).Value) _
    '                OrElse CInt(dgv1.Item(11, rowno1).Value) <= 0 _
    '                OrElse dgv1.Item(11, rowno1).Value.ToString.Contains(".") _
    '                Then
    '                        If dgv1.CurrentCell.ColumnIndex <> 14 Then
    '                            MsgBox("Cannot show this item." & ControlChars.CrLf & "Item name not selected or quantity is invalid", MsgBoxStyle.Critical + vbOKOnly)
    '                            Exit Sub
    '                        End If

    '                    End If
    '                End If
    '                If dgv1.CurrentCell.ColumnIndex <> 14 Then

    '                    ans = MsgBoxResult.Yes
    '                    If ans = MsgBoxResult.Yes Then

    'MxStp:

    '                        For i As Integer = 0 To dgv1.RowCount - 1

    '                            If dgv1.Item(1, i).Value Is Nothing _
    '                            OrElse dgv1.Item(8, i).Value Is Nothing _
    '                            OrElse dgv1.Item(11, i).Value Is Nothing _
    '                            OrElse Not IsNumeric(dgv1.Item(8, i).Value) _
    '                            OrElse Not IsNumeric(dgv1.Item(11, i).Value) _
    '                            OrElse CInt(dgv1.Item(8, i).Value) < 0 _
    '                            OrElse CInt(dgv1.Item(11, i).Value) <= 0 _
    '                            OrElse dgv1.Item(11, i).Value.ToString.Contains(".") _
    '                            OrElse dgv1.Item(11, i).Value.ToString.Contains(".") _
    '                            Then

    '                                Try
    '                                    dgv1.Rows.Remove(dgv1.Rows(i))
    '                                Catch
    '                                    Exit For
    '                                End Try

    '                                i -= 1

    '                                If i < rowno1 Then

    '                                End If

    '                            End If
    '                        Next
    '                    Else
    '                        Exit Sub
    '                    End If
    '                End If

    '                If CmbContainer.Text = "" Then
    '                    MsgBox("Container not selected", MsgBoxStyle.Critical + vbOKOnly)
    '                    CmbContainer.Focus()
    '                    Exit Sub
    '                End If

    '                Bitemno = 0
    '                Dim e3 As New e1

    '                Dim qtyarr1 As New List(Of e1)
    '                qtyarr1.Clear()

    '                Stop

    '                For i As Integer = 0 To rowno1
    '                    e3.itmnm = dgv1.Item(1, i).Value
    '                    e3.qty = dgv1.Item(11, i).Value
    '                    qtyarr1.Add(e3)
    '                Next

    '                Dim putqty As Integer

    '                Dim matchidx As Integer = -1
    '                TxtFreeCbm.Clear()
    '                TxtOccuCbm.Clear()

    '                Stop

    '                Dim ptx As New Point
    '                ptx.x = arc.length
    '                ptx.y = arc.width
    '                ptx.z = arc.height

    '                Lbc = ptx.x
    '                Wbc = ptx.y
    '                Hbc = ptx.z
    '                Stop

    '                Strt(CurDir() & "\First.wrl", True, ptx)

    '                Stop

    '                If matchidx = 0 Then matchidx = -1
    '                If matchidx = -1 Then
    '                    stk.Clear()

    '                    Dim cmd1 As New OleDb.OleDbCommand
    '                    cmd1.Connection = conn
    '                    cmd1.CommandText = "delete from stuffdata"

    '                    Dim CmdB As New OleDb.OleDbCommand
    '                    CmdB.Connection = conn
    '                    CmdB.CommandText = "delete from BoxStuffData"

    '                    Dim CmdW As New OleDb.OleDbCommand
    '                    CmdW.Connection = conn
    '                    CmdW.CommandText = "delete from ArtData"

    '                    Dim CmdVtx As New OleDb.OleDbCommand
    '                    CmdVtx.Connection = conn
    '                    CmdVtx.CommandText = "delete from Vertex"
    'x:

    '                    Try
    '                        cmd1.ExecuteNonQuery()
    '                        CmdB.ExecuteNonQuery()
    '                        CmdW.ExecuteNonQuery()
    '                        CmdVtx.ExecuteNonQuery()
    '                    Catch ec As Exception
    '                        If ec.Message = "Cannot open any more tables." Then
    '                            conn.Close()
    '                            conn.Dispose()
    '                            OleDb.OleDbConnection.ReleaseObjectPool()
    '                            cmd1.Dispose()
    '                            GC.Collect()

    '                            conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\container.mdb;Persist Security Info=False"

    '                            conn.Open()
    '                            GoTo x
    '                        End If

    '                    End Try

    '                    Stop

    '                    arc.AutoDraw(CurDir() & "First.wrl", 1, 0.5, "", "", 0, True, False, "container", 0, True, "b", "1")

    '                    Dim ard As New Area
    '                    Dim ard1 As New Area

    '                    Stop

    '                    #######################################
    '                    Door 1 option begin 
    '                    #######################################
    '                    If rdb1D.Checked = True Then

    '                        ard.StrtPt.x = arc.length
    '                        ard.StrtPt.y = 0
    '                        ard.StrtPt.z = 0
    '                        ard.length = 0.5
    '                        ard.width = arc.width
    '                        ard.height = arc.height

    '                        If DbxFlg Then
    '                            DbxFlgO = True
    '                        Else
    '                            DbxFlgO = False
    '                        End If

    '                        ard.AutoDraw(CurDir() & "\First.wrl", "", 0, "file:///c:\contdoor.png", "", 0, True, False, "door", 0, False, "b", "1")

    '                        ard1.StrtPt.x = arc.length - 0.01
    '                        ard1.StrtPt.y = 0
    '                        ard1.StrtPt.z = 0
    '                        ard1.length = 0.5
    '                        ard1.width = ard.width
    '                        ard1.height = ard.height

    '                        Stop
    '                        If DbxFlg Then
    '                            DbxFlgO = True
    '                        Else
    '                            DbxFlgO = False
    '                        End If

    '                        ard1.AutoDraw(CurDir() & "First.wrl", "b", 0, "file:///c:\contdoor.png", "", 0, True, False, "door1", 0, False, "b", "1")

    '                        DbxFlgO = False

    '                    End If
    '                    #######################################
    '                    Door 1 option End 
    '                    #######################################

    '                    Stop

    '                    #######################################
    '                    Door 2 option begin 
    '                    #######################################

    '                    $$$$$
    '                    First half door begin 
    '                    $$$$$

    '                    If rdb2D.Checked = True Then

    '                        ard.StrtPt.x = arc.length
    '                        ard.StrtPt.y = 0
    '                        ard.StrtPt.z = 0
    '                        ard.length = 0.5
    '                        ard.width = arc.width * 0.5
    '                        ard.height = arc.height

    '                        If DbxFlg Then
    '                            DbxFlgO = True
    '                        Else
    '                            DbxFlgO = False
    '                        End If

    '                        ard.AutoDrawBxDrOpn1(CurDir() & "\First.wrl", "", 0, "file:///c:\contdoor.png", "", 0, True, False, "door", 0, False, "b")                                 'ard.AutoDraw(CurDir() & "\Box.wrl", "", 0, "file:///c:\contdoor.png", "", 0, True, False, "door", 0, False, "b")

    '                        ard1.StrtPt.x = arc.length - 0.01
    '                        ard1.StrtPt.y = 0
    '                        ard1.StrtPt.z = 0
    '                        ard1.length = 0.5
    '                        ard1.width = ard.width
    '                        ard1.height = ard.height

    '                        Stop

    '                        If DbxFlg Then
    '                            DbxFlgO = True
    '                        Else
    '                            DbxFlgO = False
    '                        End If

    '                        ard.AutoDrawBxDrOpn1(CurDir() & "\First.wrl", "", 0, "file:///c:\contdoor.png", "", 0, True, False, "door", 0, False, "b")                                 'ard1.AutoDraw(CurDir() & "Box.wrl", "b", 0, "file:///c:\contdoor.png", "", 0, True, False, "door1", 0, False, "b")

    '                        DbxFlgO = False

    '                        $$$$$
    '                        First half door end 
    '                        $$$$$
    '                        Stop

    '                        ################################################################

    '                        $$$$$
    '                        Second half door begin 
    '                        $$$$$

    '                        Stop

    '                        ard.StrtPt.x = arc.length
    '                        ard.StrtPt.y = 0
    '                        ard.StrtPt.z = 0
    '                        ard.length = 0.5
    '                        ard.width = arc.width * 0.5
    '                        ard.height = arc.height

    '                        If DbxFlg Then
    '                            DbxFlgO = True
    '                        Else
    '                            DbxFlgO = False
    '                        End If

    '                        ard.AutoDrawBxDrOpn2(CurDir() & "\First.wrl", "", 0, "file:///c:\contdoor.png", "", 0, True, False, "door", 0, False, "b")

    '                        ard1.StrtPt.x = arc.length - 0.01
    '                        ard1.StrtPt.y = 0
    '                        ard1.StrtPt.z = 0
    '                        ard1.length = 0.5
    '                        ard1.width = ard.width
    '                        ard1.height = ard.height

    '                        Stop

    '                        If DbxFlg Then
    '                            DbxFlgO = True
    '                        Else
    '                            DbxFlgO = False
    '                        End If

    '                        ard.AutoDrawBxDrOpn2(CurDir() & "\First.wrl", "", 0, "file:///c:\contdoor.png", "", 0, True, False, "door", 0, False, "b")

    '                        DbxFlgO = False

    '                        $$$$$
    '                        First half door end 
    '                        $$$$$

    '                    End If

    '                    #######################################
    '                    Door 2 option End 
    '                    #######################################

    '                    Stop

    '                    Bstrtclr = "r"

    '                    Stop

    '                Else

    '                    putqty = 0
    '                    For i As Integer = 0 To matchidx - 1
    '                        putqty += qtyarr1(i).qty
    '                    Next
    '                    stk.Clear()

    '                    If matchidx <> -1 Then
    '                        For i As Integer = 0 To qtyarr(matchidx - 1).stk.Count - 1
    '                            stk.Add(qtyarr(matchidx - 1).stk(i))
    '                        Next
    '                    End If

    '                    Stop
    '                    arc.AutoDraw(CurDir() & "\First.wrl", 1, 0.5, "", "", 0, True, False, "container", 0, True, "b", "1")
    '                    Dim ard As New Area
    '                    ard.StrtPt.x = arc.length
    '                    ard.StrtPt.y = 0
    '                    ard.StrtPt.z = 0
    '                    ard.length = 0.5
    '                    ard.width = arc.width
    '                    ard.height = arc.height

    '                    Stop
    '                    ard.AutoDraw(CurDir() & "\First.wrl", "", 0, "file:///c:\contdoor.png", "", 0, True, False, "door", 0, False, "b", "1")
    '                    Dim ard1 As New Area
    '                    ard1.StrtPt.x = arc.length - 0.01
    '                    ard1.StrtPt.y = 0
    '                    ard1.StrtPt.z = 0
    '                    ard1.length = 0.5
    '                    ard1.width = ard.width
    '                    ard1.height = ard.height

    '                    Stop

    '                    ard1.AutoDraw(CurDir() & "First.wrl", "b", 0, "file:///c:\contdoor.png", "", 0, True, False, "door1", 0, False, "b", "1")
    '                    Dim col1 As String = "r"
    '                    Bplclst.Clear()
    '                    Bqtylst.Clear()
    '                    Dim qtyx As Integer = 0
    '                    qtyarr.Clear()
    '                    Dim ahistarr1 As New List(Of r1)

    '                    ahistarr1.Clear()
    '                    Form8.Label1.Text = "Please wait ....."
    '                    Form8.Label2.Text = ""
    '                    Form8.Button1.Visible = False
    '                    Form8.Show()

    '                    btnStatus.Visible = False
    '                    lblStatus.Visible = True
    '                    lblStatusINm.Visible = True

    '                    pbCSP1.Visible = True
    '                    ProgressBarRunning()

    '                    lblStatus.Text = "Please wait ....."

    '                    If dgv1.CurrentCell.ColumnIndex = 12 Then
    '                        showemp = False
    '                    ElseIf dgv1.CurrentCell.ColumnIndex = 13 Then
    '                        showemp = True
    '                    End If

    '                    If stk.Count = 0 Then

    '                        If showemp Then
    '                            MsgBox("Container Is Fully Occupied. No Empty Area Left", MsgBoxStyle.Critical + vbOKOnly)
    '                            Exit Sub
    '                        End If

    '                    End If

    '                    Dim ar11 As New Area

    '                    For i As Integer = 0 To stk.Count - 1

    '                        ar11 = stk(i)
    '                        If showemp Then

    '                            ar11.AutoDraw(CurDir() & "First.wrl", "r", 0, "", CStr(i + 1), 0, False, True, "E", 0, False, "b", "1")

    '                        End If

    '                    Next

    '                    If showemp Then

    '                        Try
    '                            Closef(CurDir() & "\First.wrl")
    '                            Form8.Close()

    '                            lblStatus.Visible = False
    '                            lblStatusINm.Visible = False
    '                            btnStatus.Visible = False

    '                            pbCSP1.Visible = False

    '                            Eventless()

    '                            #################@@@@@@@@@@@@@@@@@@@@@@@@@@

    '                            ThreeDViewer()
    '                            #################@@@@@@@@@@@@@@@@@@@@@@@@@@
    '                            Dim RsultStr As String

    '                            ##############

    '                            Try

    '                                Dim FName As String = CurDir() & "\First.wrl"
    '                                Process.Start("c:\Program Files\Alteros 3D\alteros.exe", FName)

    '                            Catch Err As Exception
    '                                MsgBox(Err.Message)
    '                                MsgBox(Err.ToString)
    '                                MessageBox.Show("Error in Alteros 3D running", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                                conn.Close()
    '                                off.Close()
    '                                MessageBox.Show("Error in ShowButton", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                                MsgBox("Exit Application")
    '                                Application.Exit()
    '                            End Try

    '                            ##############

    '                            RsultStr = MsgBox("Do you show stuffing in three dimensional (Isometric) view ?", MsgBoxStyle.YesNo, "3DViewer")
    '                            If RsultStr = MsgBoxResult.Yes Then

    '                                ThreeDViewer() ' (3D)Three Dimentional Arrangement are shown 
    '                            Else
    '                                Dim Str As String

    '                                Str = MsgBox("Do you close stuffing entry?", MsgBoxStyle.YesNo, "Stuffing Entry ...")
    '                                If Str = MsgBoxResult.Yes Then
    '                                    Me.Close()
    '                                Else
    '                                    Me.Focus()
    '                                End If
    '                            End If
    '                            ThreeDViewer() ' (3D)Three Dimentional Arrangement are shown 
    '                            #################@@@@@@@@@@@@@@@@@@@@@@@@@@

    '                        Catch Ex As Exception
    '                            MsgBox(Ex.Message)
    '                            MsgBox(Ex.ToString)
    '                            MsgBox(Ex.Message, MsgBoxStyle.Critical, "Message :: In method 'MouseClick'  " & vbCrLf & "VRML Programme Running is failure!")
    '                            Me.Close()

    '                        Finally
    '                            Form8.Close()

    '                            lblStatus.Visible = False
    '                            lblStatusINm.Visible = False
    '                            btnStatus.Visible = False

    '                            pbCSP1.Visible = False

    '                            Eventless()
    '                        End Try

    '                        Exit Sub
    '                    End If

    '                    Bitemno = 0

    '                    For i As Integer = 0 To putqty - 1
    '                        qtyx += 1
    '                        Bahistarr(i).ar.AutoDraw(CurDir() & "First.wrl", col1, 0, "file\\\c:\t2.png", Bahistarr(i).itmnm, 0, False, True, "", Bahistarr(i).method, False, "b", "1")
    '                        ahistarr1.Add(Bahistarr(i))
    '                        If i = putqty - 1 Then
    '                            plclst1.Add(qtyx)

    '                            Bqtylst.Add(qtyx)

    '                            Dim m1 As New e1
    '                            m1.itmnm = Bahistarr(i).itmnm
    '                            m1.qty = qtyx
    '                            m1.stk = Bahistarr(i).stk
    '                            qtyarr.Add(m1)

    '                            qtyx = 0
    '                            Exit For

    '                        End If

    '                        If Bahistarr(i).itmnm <> Bahistarr(i + 1).itmnm Then

    '                            Bitemno += 1
    '                            If col1 = "r" Then
    '                                col1 = "g"
    '                            ElseIf col1 = "g" Then
    '                                col1 = "b"
    '                            ElseIf col1 = "b" Then
    '                                col1 = "m"
    '                            ElseIf col1 = "m" Then
    '                                col1 = "c"
    '                            ElseIf col1 = "c" Then
    '                                col1 = "y"
    '                            End If
    '                            plclst1.Add(qtyx)
    '                            Bqtylst.Add(qtyx)

    '                            Dim m1 As New e1
    '                            m1.itmnm = Bahistarr(i).itmnm
    '                            m1.qty = qtyx
    '                            m1.stk = Bahistarr(i).stk
    '                            qtyarr.Add(m1)
    '                            qtyx = 0

    '                        End If
    '                    Next

    '                    Bitemno += 1
    '                    Form8.Close()

    '                    lblStatus.Visible = False
    '                    lblStatusINm.Visible = False
    '                    btnStatus.Visible = False

    '                    pbCSP1.Visible = False

    '                    Eventless()

    '                    Bahistarr.Clear()
    '                    For i As Integer = 0 To ahistarr1.Count - 1
    '                        Bahistarr.Add(ahistarr1(i))
    '                    Next

    '                    Bplclst.Clear()
    '                    For i As Integer = 0 To Bqtylst.Count - 1
    '                        Bplclst.Add(Bqtylst(i) - 1)
    '                    Next

    '                    If col1 = "r" Then
    '                        col1 = "g"
    '                    ElseIf col1 = "g" Then
    '                        col1 = "b"
    '                    ElseIf col1 = "b" Then
    '                        col1 = "m"
    '                    ElseIf col1 = "m" Then
    '                        col1 = "c"
    '                    ElseIf col1 = "c" Then
    '                        col1 = "y"
    '                    End If
    '                    Bstrtclr = col1
    '                    Stop

    '                End If
    '                *************
    '                Stop
    '                *************
    '                Dim Stk1 As New List(Of Area)
    '                Dim Stk2 As New List(Of Area)

    '                Dim qtyf As Boolean = False
    '                Dim rowlvflg As Boolean = False
    '                Dim stp As Integer
    '                Dim cntm As Integer = 1
    '                Dim totqty = 25
    '                Dim totqty1 As Integer = 0
    '                Dim drwstp As Integer

    '                Dim cntflg As Boolean = False

    '                Dim flg1 As Boolean = True

    '                Dim button1flag As Boolean = False
    '                Dim Itmnm As String
    '                Dim SLbl As String

    '                button1flag = True
    '                Dim cnt As Integer = 0
    '                Dim dupflg As Boolean = False

    '                cnt = 0

    '                Dim ar() As Area

    '                Dim ari() As String
    '                Dim arwt() As Single
    '                Dim ar1 As New Area
    '                Dim ln As Double
    '                Dim wd As Double
    '                Dim ht As Double
    '                Dim qty As Integer
    '                Dim seq As Integer
    '                Dim wt As String
    '                Dim transparr() As Boolean
    '                Dim transp As Boolean
    '                Dim topup() As Boolean
    '                Dim Tpup As Boolean

    '                ReDim ar(0)
    '                ReDim ari(0)
    '                ReDim arwt(0)
    '                ReDim transparr(0)
    '                ReDim topup(0)
    '                ReDim arl(0)

    '                Dim cmd As New OleDb.OleDbCommand

    '                Dim cntx As Integer = 0

    '                Dim plcqty As Integer = 0

    '                Dim k As Integer
    '                Dim m As Integer

    '                DelTab("temp1")

    '                If CmbContainer.Text = "" Then
    '                    MsgBox("Container not selected", MsgBoxStyle.Critical + vbOKOnly)
    '                    MessageBox.Show("Container not selected", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                    CmbContainer.Focus()
    '                    Exit Sub
    '                End If

    '                Form8.Label1.Text = "Please wait ....."
    '                Form8.Label2.Text = ""
    '                Form8.Button1.Visible = False
    '                btnStatus.Visible = False
    '                Form8.Show()

    '                lblStatus.Text = "Please wait ....."
    '                lblStatus.Visible = True
    '                lblStatusINm.Visible = True
    '                btnStatus.Visible = False

    '                pbCSP1.Visible = True
    '                ProgressBarRunning()

    '                System.Windows.Forms.Application.DoEvents()

    '                Dim i1, j1 As Integer
    '                Dim extflg As Boolean = False

    '                Dim zz As Integer

    '                zz = rowno1

    '                Dim matchidx1 As Integer
    '                If matchidx = -1 Then
    '                    matchidx1 = 0
    '                Else
    '                    matchidx1 = matchidx
    '                End If

    '                Stop

    '                Try

    '                    If Not ADclFlg Then

    '                        For i1 = matchidx1 To zz

    '                            Itmnm = dgv1.Item(1, i1).Value
    '                            ln = Math.Round(dgv1.Item(4, i1).Value, 4)
    '                            wd = Math.Round(dgv1.Item(5, i1).Value, 4)
    '                            ht = Math.Round(dgv1.Item(6, i1).Value, 4)
    '                            qty = dgv1.Item(11, i1).Value

    '                            wt = dgv1.Item(8, i1).Value
    '                            seq = dgv1.Item(0, i1).Value

    '                            transp = False

    '                            Tpup = IIf(dgv1.Item(7, i1).Value = "6", False, True)

    '                            Bqtylst.Add(qty)

    '                            Stop

    '                            For j1 = 0 To qty - 1

    '                                totqty1 += 1

    '                                qtyf = True

    '                                ar1.length = ln
    '                                ar1.width = wd
    '                                ar1.height = ht
    '                                ar1.StrtPt.x = 0
    '                                ar1.StrtPt.y = 0
    '                                ar1.StrtPt.z = 0
    '                                ar(UBound(ar)) = New Area
    '                                ar(UBound(ar)).length = ar1.length
    '                                ar(UBound(ar)).width = ar1.width
    '                                ar(UBound(ar)).height = ar1.height
    '                                ari(UBound(ari)) = Itmnm
    '                                arwt(UBound(arwt)) = wt
    '                                transparr(UBound(transparr)) = transp
    '                                topup(UBound(topup)) = Tpup

    '                                ReDim Preserve ar(UBound(ar) + 1)
    '                                ReDim Preserve ari(UBound(ari) + 1)
    '                                ReDim Preserve arwt(UBound(arwt) + 1)
    '                                ReDim Preserve transparr(UBound(transparr) + 1)
    '                                ReDim Preserve topup(UBound(topup) + 1)

    '                            Next

    '                        Next i1

    '                        Stop

    '                        !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    '                    Else
    '                        !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!D

    '                        For i1 = matchidx1 To zz

    '                            Itmnm = dgv1.Item(1, i1).Value
    '                            ln = Math.Round(dgv1.Item(4, i1).Value, 4)
    '                            wd = Math.Round(dgv1.Item(5, i1).Value, 4)
    '                            ht = Math.Round(dgv1.Item(6, i1).Value, 4)
    '                            qty = dgv1.Item(11, i1).Value

    '                            wt = dgv1.Item(8, i1).Value
    '                            seq = dgv1.Item(0, i1).Value
    '                            SLbl = dgv1.Item(15, i1).Value

    '                            If SLbl = Nothing Then
    '                                SLbl = Itmnm
    '                            End If

    '                            transp = False

    '                            Tpup = IIf(dgv1.Item(7, i1).Value = "6", False, True)

    '                            Bqtylst.Add(qty)

    '                            Stop

    '                            For j1 = 0 To qty - 1

    '                                totqty1 += 1

    '                                qtyf = True

    '                                ar1.length = ln
    '                                ar1.width = wd
    '                                ar1.height = ht
    '                                ar1.StrtPt.x = 0
    '                                ar1.StrtPt.y = 0
    '                                ar1.StrtPt.z = 0
    '                                ar(UBound(ar)) = New Area
    '                                ar(UBound(ar)).length = ar1.length
    '                                ar(UBound(ar)).width = ar1.width
    '                                ar(UBound(ar)).height = ar1.height
    '                                ari(UBound(ari)) = Itmnm
    '                                arwt(UBound(arwt)) = wt
    '                                transparr(UBound(transparr)) = transp
    '                                topup(UBound(topup)) = Tpup
    '                                arl(UBound(arl)) = SLbl

    '                                ReDim Preserve ar(UBound(ar) + 1)
    '                                ReDim Preserve ari(UBound(ari) + 1)
    '                                ReDim Preserve arwt(UBound(arwt) + 1)
    '                                ReDim Preserve transparr(UBound(transparr) + 1)
    '                                ReDim Preserve topup(UBound(topup) + 1)
    '                                ReDim Preserve arl(UBound(arl) + 1)

    '                            Next

    '                        Next i1

    '                        Stop
    '                        !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!D

    '                    End If

    '                Catch Err As Exception
    '                    MsgBox(Err.Message)
    '                    MsgBox(Err.ToString)
    '                    MessageBox.Show("Error in Datagrid entry looping entry to stuffing assigning", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                End Try

    '                Bplclstf.Clear()
    '                For i As Integer = 0 To Bplclst.Count - 1
    '                    Bplclstf.Add(Bplclst(i) + 1)
    '                Next

    '                For m = 0 To Bplclstf.Count - 1
    '                    If Bplclstf(m) = 0 Then
    '                        k = m - 1
    '                        Exit For
    '                    End If
    '                Next

    '                If k = 0 Then
    '                    k = m - 1
    '                End If

    '                If k = 0 Then
    '                    k = m + 1
    '                End If

    '                totqty = 0
    '                For i As Integer = 0 To Bqtylst.Count - 1
    '                    totqty = totqty + Bqtylst(i)
    '                Next

    '                plcqty = 0
    '                For i As Integer = 0 To Bplclstf.Count - 1
    '                    plcqty = plcqty + Bplclstf(i) - 1
    '                Next

    '                ReDim Preserve ar(UBound(ar) - 1)
    '                ReDim Preserve ari(UBound(ari) - 1)
    '                ReDim Preserve arwt(UBound(arwt) - 1)
    '                ReDim Preserve transparr(UBound(transparr) - 1)
    '                ReDim Preserve topup(UBound(topup) - 1)

    '                If ADclFlg Then
    '                    ReDim Preserve arl(UBound(arl) - 1)
    '                End If

    '                stp += 1

    '                Dim ar2() As Area
    '                Dim ari2() As String
    '                Dim arwt2() As Single
    '                Dim transparr2() As Boolean

    '                ReDim ar2(0)
    '                ReDim ari2(0)
    '                ReDim arwt2(0)
    '                ReDim transparr2(0)

    '                *************
    '                Stop
    '                *************
    '                For i As Integer = LBound(ar) To UBound(ar)

    '                    ar2(UBound(ar2)) = ar(i)
    '                    ari2(UBound(ari2)) = ari(i)
    '                    arwt2(UBound(arwt2)) = arwt(i)
    '                    transparr2(UBound(transparr2)) = transparr(i)
    '                    ReDim Preserve ar2(UBound(ar2) + 1)
    '                    ReDim Preserve ari2(UBound(ari2) + 1)
    '                    ReDim Preserve arwt2(UBound(arwt2) + 1)
    '                    ReDim Preserve transparr2(UBound(transparr2) + 1)
    '                    ReDim Preserve topup(UBound(topup) + 1)

    '                Next

    '                ReDim Preserve ar2(UBound(ar2) - 1)
    '                ReDim Preserve ari2(UBound(ari2) - 1)
    '                ReDim Preserve arwt2(UBound(arwt2) - 1)
    '                ReDim Preserve transparr2(UBound(transparr2) - 1)

    '                Try
    '                    ReDim Preserve topup(UBound(topup) - 1)
    '                Catch

    '                End Try

    '                *************
    '                Stop
    '                *************
    '                If stp = dgv1.RowCount Then
    '                    stp = 0
    '                    cnt = 0
    '                End If

    '                arc.StrtPt.x = 0
    '                arc.StrtPt.y = 0
    '                arc.StrtPt.z = 0
    '                arc.length = contarr(0)
    '                arc.width = contarr(1)
    '                arc.height = contarr(2)
    '                qty = 0
    '                Form8.Close()

    '                lblStatus.Visible = False
    '                lblStatusINm.Visible = False
    '                btnStatus.Visible = False

    '                pbCSP1.Visible = False

    '                Eventless()

    '                Stop

    '                Dim outfile As String = CurDir() & "\First.wrl"

    '                Try

    '                    Xl3d = 0        'Initialising the optimum stuff
    '                    Yl3d = 0
    '                    Zl3d = 0

    '                    RiCnt = 0
    '                    flg_RiCnt = False

    '                    If conn.State = ConnectionState.Closed Then conn.Open()

    '                    Dim Cmdo As New OleDb.OleDbCommand
    '                    Cmdo.Connection = conn
    '                    Cmdo.CommandText = "delete from pgRecord"
    '                    Cmdo.ExecuteNonQuery()

    '                    Dim CmdOp As New OleDb.OleDbCommand
    '                    CmdOp.Connection = conn
    '                    CmdOp.CommandText = "delete from pgCord"
    '                    CmdOp.ExecuteNonQuery()

    '                Catch ex As Exception
    '                    MsgBox(ex.Message)
    '                    MsgBox(ex.ToString)
    '                    MessageBox.Show("Error in OptStuff Module", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                End Try


    '                If ar.Length > 0 Then
    '                    If stk.Count = 0 Then stk.Add(arc)
    '                    Bitemqty = 0
    '                    Bplclst.Clear()
    '                    Btxtopt = False

    '                    Stop

    '                    If dgv1.CurrentCell.ColumnIndex = 12 Then

    '                        If chkbxWadStuff.Checked Then

    '                            ###########################################
    '                            Try

    '                                MessageBox.Show("Work in progress wad stuff is done", "Wad stuff info.....", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                                Stop
    '                                Stk2 = WadBoxStuff(arc, ar2, ari2, arwt2, False, False, outfile, True, transparr2, topup, Btxtopt, True, False, True, colarr)

    '                                Stk2 = BoxStuff(arc, ar2, ari2, arwt2, False, False, outfile, True, transparr2, topup, Btxtopt, True, False, True, colarr)

    '                                Stk2 = Stuffx(arc, ar2, ari2, arwt2, False, False, outfile, True, transparr2, topup, Btxtopt, True, False, True, colarr)
    '                                LibWrapper.stuff(arc, ar2, ari2, arwt2, False, False, outfile, True, transparr2, topup, Btxtopt, True, False, True, colarr)

    '                                GoTo BxStfEnd

    '                            Catch ex As Exception
    '                                MsgBox(ex.Message)
    '                                MsgBox(ex.ToString)
    '                                MessageBox.Show("Error in Stuff", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                            End Try

    '                            ###########################################

    '                        End If

    '                        If chkBxPlyStuff.Checked Then

    '                            Try

    '                                $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

    '                                Dim PlyAr As New Area
    '                                Dim RemAr As New Area
    '                                Dim PlyCnt As Integer
    '                                Dim Grt As Double

    '                                PlyAr.StrtPt.x = 0
    '                                PlyAr.StrtPt.y = 0
    '                                PlyAr.StrtPt.z = 0

    '                                For i As Integer = 0 To dgv1.RowCount - 2

    '                                    qty = dgv1.Item(11, i).Value            'qty = dgv1.Item(11, 0).Value

    '                                    PlyAr.length = Math.Round(dgv1.Item(4, i).Value, 4)         'PlyAr.length = Math.Round(dgv1.Item(4, 0).Value, 4)
    '                                    PlyAr.width = Math.Round(dgv1.Item(5, i).Value, 4)          'PlyAr.width = Math.Round(dgv1.Item(5, 0).Value, 4)
    '                                    PlyAr.height = Math.Round(dgv1.Item(6, i).Value, 4)         'PlyAr.height = Math.Round(dgv1.Item(6, 0).Value, 4)

    '                                    Itmnm = dgv1.Item(1, i).Value           'Itmnm = dgv1.Item(1, 0).Value

    '                                    PlyCnt = StuffPly(arc, PlyAr, True, True, qty, Itmnm)

    '                                    RemAr = PlyDrwLst(PlyCnt - 1)

    '                                    Dim Lp As Double
    '                                    Dim Wp As Double
    '                                    Dim Hp As Double

    '                                    Lp = PlyAr.length
    '                                    Wp = PlyAr.width
    '                                    Hp = PlyAr.height

    '                                    Grt = Greater(Lp, Wp, Hp)

    '                                    If Grt = Nothing Then
    '                                        Grt = PlyAr.length
    '                                    End If

    '                                    PlyAr.StrtPt.x = RemAr.StrtPt.x + Grt               'PlyAr.StrtPt.x = RemAr.StrtPt.x + PlyAr.length '
    '                                    PlyAr.StrtPt.y = 0
    '                                    PlyAr.StrtPt.z = 0

    '                                Next i

    '                                Stop

    '                                Dim ItmPlaced As Int64 = (PlyCnt - 1).ToString

    '                                MessageBox.Show("In Ply Stuff  out of  " & qty & "  quantity only  " & ItmPlaced & "  placed", "Ply Stuff Info.....", MessageBoxButtons.OK, MessageBoxIcon.Information)

    '                                MsgBox((PlyCnt - 1).ToString & " Items placed")

    '                                PlyCnt = 0

    '                                Closef(outfile)

    '                                $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

    '                            Catch Exx As Exception
    '                                MsgBox(Exx.Message)
    '                                MsgBox(Exx.ToString)
    '                                MessageBox.Show("Error in Plystuff ShowButton", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                            End Try

    '                            GoTo PlyEnd
    '                        End If

    '                        If ADclFlg Then
    '                            BoxLBLStuff(arc, ar2, ari2, arl, arwt2, False, False, outfile, True, transparr2, topup, Btxtopt, True, False, True, colarr)
    '                            GoTo BxStfEnd
    '                        End If

    '                        If chkBxSlideStuff.Checked Or chkbxOptStuff.Checked Or chkbxManualChng.Checked Then
    '                            MoveBoxStuff(arc, ar2, ari2, arwt2, False, False, outfile, True, transparr2, topup, Btxtopt, True, False, True, colarr)
    '                            GoTo BxStfEnd
    '                        End If

    '                        If chkbxOptStuff.Checked Then
    '                            BoxStuff_Optm(arc, ar2, ari2, arwt2, False, False, outfile, True, transparr2, topup, Btxtopt, True, False, True, colarr)
    '                        End If

    '                        If Not CheckBox1.Checked AndAlso Not chkBxSlideStuff.Checked Then

    '                            Stk2 = BoxStuff(arc, ar2, ari2, arwt2, False, False, outfile, True, transparr2, topup, Btxtopt, True, False, True, colarr)

    '                        ElseIf CheckBox1.Checked Then

    '                            Dim ar12 As New Area

    '                            qty = dgv1.Item(11, 0).Value

    '                            ar12.StrtPt.x = 0
    '                            ar12.StrtPt.y = 0
    '                            ar12.StrtPt.z = 0
    '                            ar12.length = Math.Round(dgv1.Item(4, 0).Value, 4)
    '                            ar12.width = Math.Round(dgv1.Item(5, 0).Value, 4)
    '                            ar12.height = Math.Round(dgv1.Item(6, 0).Value, 4)

    '                            Dim pt As New Point
    '                            pt.x = ar1.length
    '                            pt.y = ar1.width
    '                            pt.z = ar1.height

    '                            Itmnm = dgv1.Item(1, 0).Value

    '                            *********
    '                            Stop
    '                            *********
    '                            Dim hg As Integer = 0

    '                            hg = Stuffy(arc, ar12, True, True, qty, Itmnm)

    '                            Stop

    '                            MsgBox((hg - 1).ToString & " Items placed")

    '                            hg = 0

    '                            Closef(outfile)

    '                        End If
    '                        showemp = True

    '                    End If

    'BxStfEnd:
    '                    ****************
    '                    Stop
    '                    ****************
    '                    Dim emvol As Double = 0
    '                    For kk As Integer = 0 To stk.Count - 1
    '                        emvol = emvol + (stk(kk).length * stk(kk).width * stk(kk).height)
    '                    Next
    '                    emvol = emvol * (0.0254 * 0.0254 * 0.0254)
    '                    TxtFreeCbm.Text = Format(emvol, "0.000")
    '                    TxtOccuCbm.Text = Format((CDbl(TxtCapacity.Text) - CDbl(TxtFreeCbm.Text)), "0.000")
    '                    If dgv1.CurrentCell.ColumnIndex = 12 Then
    '                        showemp = False
    '                    ElseIf dgv1.CurrentCell.ColumnIndex = 13 Then
    '                        showemp = True
    '                    End If
    '                    Dim mn As Integer = 0

    '                    Dim are As Area
    '                    stkmm.Clear()
    '                    Dim vol1 As Double
    '                    For jjj As Integer = 0 To Stk2.Count - 1
    '                        vol1 = vol1 + (Stk2(jjj).length * Stk2(jjj).width * Stk2(jjj).height)
    '                    Next
    '                    For rr As Integer = 0 To Stk2.Count - 1
    '                        are = New Area
    '                        are.StrtPt.x = Stk2(rr).StrtPt.x
    '                        are.StrtPt.y = Stk2(rr).StrtPt.y
    '                        are.StrtPt.z = Stk2(rr).StrtPt.z
    '                        are.length = Stk2(rr).length
    '                        are.width = Stk2(rr).width
    '                        are.height = Stk2(rr).height
    '                        stkmm.Add(are)
    '                    Next

    '                    stk.Clear()
    '                    ReDim ar2(0)
    '                    ReDim ar2(0)
    '                    ReDim ari2(0)
    '                    ReDim arwt2(0)
    '                    ReDim transparr2(0)
    '                    ReDim topup(0)

    '                    For i As Integer = 0 To Bitemno

    '                        If CInt(dgv1.Item(11, i).Value) > Bqtylst(i) + 1 Then
    '                            Dim qtyv As Integer
    '                            If Bqtylst(i) <= 0 Then
    '                                qtyv = 0
    '                            Else
    '                                qtyv = Bqtylst(i) + 1
    '                            End If
    '                            MsgBox(dgv1.Item(11, i).Value.ToString & " no of " & dgv1.Item(1, i).Value & " cannot be placed." & vbCrLf & CStr(qtyv) & " placed.", MsgBoxStyle.Information + vbOKOnly)

    '                            MessageBox.Show(dgv1.Item(11, i).Value.ToString & " no of " & dgv1.Item(1, i).Value & " cannot be placed. " & vbCrLf & CStr(qtyv) & " placed.", "Stuffing Entry", MessageBoxButtons.OK)

    '                            dgv1.Item(11, i).Value = qtyv
    '                            drwstp = drwstp - Bqtylst(i) + Bplclst(i) + 1
    '                            Bqtylst(i) = Bplclst(i) + 1

    '                        End If
    '                    Next

    '                    If Not CheckBox1.Checked Then

    '                        TxtOccuKgs.Text = Format(CDbl(dgv1.Item(8, dgv1.CurrentCell.RowIndex).Value) * (Bplclst(CInt(dgv1.CurrentCell.RowIndex)) + 1), "0.000")
    '                        TxtFreeKgs.Text = Format(CDbl(TxtPayLoad.Text) - CDbl(TxtOccuKgs.Text), "0.000")

    '                        For i As Integer = 0 To rowno1
    '                            Dim qtyv As Integer = Bplclst(i)
    '                            qtyv += 1
    '                            If CheckBox1.Checked = True Then
    '                                If fullflag Then
    '                                    qtyv = xcnt - 1
    '                                    qtyv = xcnt
    '                                Else
    '                                    qtyv = xcnt
    '                                End If
    '                            End If
    '                            If CInt(dgv1.Item(11, i).Value) > qtyv Then
    '                                MsgBox(dgv1.Item(11, i).Value.ToString & " no of " & dgv1.Item(1, i).Value & " cannot be placed." & vbCrLf & CStr(qtyv) & " placed.", MsgBoxStyle.Information + vbOKOnly)
    '                                MessageBox.Show(dgv1.Item(11, i).Value.ToString & " no of " & dgv1.Item(1, i).Value & " cannot be placed." & vbCrLf & CStr(qtyv) & " placed.", "Stuffing Entry", MessageBoxButtons.OK)
    '                                dgv1.Item(11, i).Value = qtyv
    '                            End If

    '                        Next

    '                        Bplclstf.Clear()
    '                        For i As Integer = 0 To Bplclst.Count - 1
    '                            Bplclstf.Add(Bplclst(i) + 1)
    '                        Next
    '                        k = 0
    '                        For m = 0 To Bplclstf.Count - 1
    '                            If Bplclstf(m) = 0 Then
    '                                k = m - 1
    '                                Exit For
    '                            End If
    '                        Next

    '                        If k = 0 Then
    '                            k = m - 1
    '                        End If

    '                        totqty = 0
    '                        Dim bn As Integer
    '                        If matchidx = -1 Then
    '                            bn = 0
    '                        Else
    '                            bn = matchidx
    '                        End If
    '                        For i As Integer = 0 To Bqtylst.Count - 1
    '                            totqty = totqty + Bqtylst(i)
    '                        Next

    '                        plcqty = 0
    '                        For i As Integer = 0 To Bplclstf.Count - 1
    '                            plcqty = plcqty + Bplclstf(i)
    '                        Next

    'SBMCEnd:

    '                        Do While Not dgEmpty.RowCount = 0
    '                            Try
    '                                dgEmpty.Rows.Remove(dgEmpty.Rows(0))
    '                            Catch
    '                                Exit Do
    '                            End Try
    '                        Loop

    '                        Do While Not dgUsage.RowCount = 0

    '                            Try
    '                                dgUsage.Rows.Remove(dgUsage.Rows(0))
    '                            Catch
    '                                Exit Do
    '                            End Try
    '                        Loop

    '                        Call Button3_Click(Nothing, Nothing)
    '                        Closef(CurDir() & "\First.wrl")

    '                    End If
    '                End If

    '                Dim dq As Char = Chr(34)

    '                ThreeDViewer()
    '                #################@@@@@@@@@@@@@@@@@@@@@@@@@@
    '                Dim RsltStr As String
    '                Dim RsltSv As String

    '                RsltSv = MessageBox.Show("Auto file save ", "Stuff viewer Box file save", MessageBoxButtons.YesNo, MessageBoxIcon.Information)

    '                Dim dof As Stuff_Viewers = New Stuff_Viewers
    '                dof.DestroyOldFile("C:\CSP.Box.wrl")

    '                'If RsltSv = MsgBoxResult.Yes Then
    '                FinalOutPutWriter()
    '                'Else

    '                Stuff_Viewers.Show()
    '                Stuff_Viewers.Focus()
    '            End If

    '            RsltStr = MsgBox("Do you show stuffing in three dimensional (Isometric) view ?", MsgBoxStyle.YesNo, "3DViewer")
    '            If RsltStr = MsgBoxResult.Yes Then

    '                #####

    '                If Not chkBxAutoStuff.Checked Then
    'PlyEnd:
    '                    Try

    '                        Dim FName As String = CurDir() & "\First.wrl"
    '                        Process.Start("c:\Program Files\Alteros 3D\alteros.exe", FName)

    '                    Catch Err As Exception
    '                        MsgBox(Err.Message)
    '                        MsgBox(Err.ToString)
    '                        MessageBox.Show("Error in Alteros 3D running", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                        conn.Close()
    '                        off.Close()
    '                        MessageBox.Show("Fatal error in ShowButton", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                        MsgBox("Exit Application")
    '                        Application.Exit()
    '                    End Try
    '                End If

    '                #####

    '                ThreeDViewer() ' (3D)Three Dimentional Arrangement are shown 

    '            Else
    '                Dim Str As String

    '                Str = MsgBox("Do you close stuffing entry?", MsgBoxStyle.YesNo, "Stuffing Entry ...")
    '                If Str = MsgBoxResult.Yes Then
    '                    Me.Close()
    '                Else
    '                    Me.Focus()
    '                End If

    '                ThreeDViewer() ' (3D)Three Dimentional Arrangement are shown 
    '                #################@@@@@@@@@@@@@@@@@@@@@@@@@@

    '                Bplclst.Clear()
    '                Bqtylst.Clear()
    '            End If
    '            End If



    '        End If

    '    End Sub

    Private Sub ComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)

        Try

            rwidx = dgv1.CurrentCell.RowIndex

            Dim comboBox1 As ComboBox = CType(sender, ComboBox)
            Dim tpup1 As Boolean
            If dgv1.CurrentCell.ColumnIndex = 1 Then
                itmnm = sender.text
                tpup1 = IIf(dgv1.Item(7, rwidx).Value = "6", False, True)
            Else
                itmnm = dgv1.Item(1, dgv1.CurrentCell.RowIndex).Value
                tpup1 = IIf(sender.text = "6", False, True)
            End If
            Dim cmd As New OleDb.OleDbCommand
            Dim rdr As OleDb.OleDbDataReader
            Dim lni As Single
            Dim wdi As Single
            Dim hti As Single
            Dim maxqty1 As Integer
            cmd.Connection = conn
            cmd.CommandText = "select lengthf,widthf,heightf,lengthi,widthi,heighti,lengthc,widthc,heightc,lengthm,widthm,heightm,grossweight,packingmode from packmast where packname ='" & itmnm & "'"
            If conn.State = ConnectionState.Closed Then conn.Open()
            rdr = cmd.ExecuteReader
            rdr.Read()
            Try
                lni = Val(Format((rdr("lengthi") + (12 * rdr("lengthf")) + (rdr("lengthc") / 2.538) + (rdr("lengthm") / 25.38)), "0.0000"))
            Catch
                Exit Sub
            End Try
            wdi = Val(Format((rdr("Widthi") + (12 * rdr("Widthf")) + (rdr("Widthc") / 2.538) + (rdr("Widthm") / 25.38)), "0.0000"))
            hti = Val(Format((rdr("heighti") + (12 * rdr("heightf")) + (rdr("heightc") / 2.538) + (rdr("heightm") / 25.38)), "0.0000"))
            dgv1.Item(1, rwidx).Value = itmnm
            dgv1.Item(4, rwidx).Value = lni
            dgv1.Item(5, rwidx).Value = wdi
            dgv1.Item(6, rwidx).Value = hti
            dgv1.Item(3, rwidx).Value = lni * wdi * hti / 61024
            dgv1.Item(2, rwidx).Value = rdr("packingmode")
            dgv1.Item(8, rwidx).Value = rdr("grossweight")

            Try
                Dim srn As Integer = 1
                For s As Integer = 0 To dgv1.RowCount - 2
                    dgv1.Item(0, s).Value = srn
                    srn += 1
                Next
            Catch
            End Try

            MxQTpUp = tpup1     'The Maximum quantity of topup flag is set to that friend flag

            If Not CheckBox1.Checked Then
                Dim ans = MessageBox.Show("Do you want to calculate maximum quantity?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                If ans = MsgBoxResult.Yes Then
                    stk.Clear()
                    stk.Add(arc)

                    'Stop
                    '            Button1.Enabled = False
                    Dim oldopt As Boolean = chkwt
                    'maxqty1 = calcmxqty(rwidx, tpup1)      'Old tpup with calling
                    maxqty1 = calcmxqty(rwidx, MxQTpUp)    'New tpup with calling
                    'Dim t As Thread = New Thread(New ThreadStart(AddressOf MaxThreadCalcQty))
                    't.Start()
                    chkwt = oldopt
                    plclst.Clear()
                End If
            End If
            rdr.Close()
            ''conn.close()

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in maximum quantity calculation", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub MaxThreadCalcQty()

        Try
            Dim Mxqty As Integer = 0

            Mxqty = calcmxqty(rwidx, MxQTpUp)

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in MaxThreadCalcQty", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub ShowbtnDisplay(ByVal sender As Object, ByVal f As System.Windows.Forms.DataGridViewCellEventArgs) ' Handles dgv1.CellClick

        Try

            ShowButton.Visible = False
            ShowButton.Top = 0
            ShowButton.Left = 0
            ShowButton.Width = 0
            ShowButton.Height = 0

            If f.ColumnIndex = 1 Or f.ColumnIndex = 2 Then

                If dgv1.Item(1, f.RowIndex).Value = "" Then
                    ShowButton.Visible = False
                    'showbutton1.Visible = False
                    Exit Sub
                Else
                    Dim x As Integer
                    Dim coli As Integer = f.ColumnIndex
                    Dim rowi As Integer = f.RowIndex
                    For i As Integer = 0 To coli - 1
                        If dgv1.Columns(i).Visible Then
                            x += dgv1.Columns(i).Width
                        End If
                    Next
                    Dim y As Integer
                    For i As Integer = 0 To rowi
                        y += dgv1.Rows(i).Height

                    Next
                    Dim wd As Integer = dgv1.Columns(f.ColumnIndex).Width
                    Dim ht As Integer = dgv1.Rows(f.RowIndex).Height

                    ShowButton.Top = dgv1.Location.Y - 2 + y + y2
                    ShowButton.Left = dgv1.Location.X + 1 + x
                    ShowButton.Width = wd
                    ShowButton.Height = ht
                    ShowButton.Visible = True
                    showbutton1.Visible = False
                    ShowButton.Text = "Show"
                    ShowButton.BringToFront()
                End If
            Else
                ShowButton.Visible = False
                'showbutton1.Visible = False
            End If

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in ShowbtnDisplay", Me.Text, MessageBoxButtons.OK)
        End Try

    End Sub

    Private Sub txtbx_click(ByVal sender As Object, ByVal e As EventArgs)

        Try

            If rdbMetric.Checked = True Then
                'MsgBox("Deliberately change the units Metric to English.", MsgBoxStyle.Information + vbOKOnly, Me.Text)
                rdbEnglish.Checked = True                                    'chkBxEnglishUnits.Checked = True
                rdbMetric.Checked = False                                    'chkBxMetricUnits.Checked = False
                Call rdbEnglish_MouseClick(sender, e)                        'chkBxEnglishUnits_MouseClick(sender, e)
            End If

            Dim tpup1 As Boolean
            If dgv1.CurrentCell.ColumnIndex = 1 Then
                itmnm = sender.text
                tpup1 = IIf(dgv1.Item(7, rwidx).Value = "6", False, True)
            Else
                itmnm = dgv1.Item(1, dgv1.CurrentCell.RowIndex).Value
                tpup1 = IIf(sender.text = "6", False, True)
            End If
            Dim cmd As New OleDb.OleDbCommand
            Dim rdr As OleDb.OleDbDataReader
            Dim lni As Single
            Dim wdi As Single
            Dim hti As Single
            Dim maxqty1 As Integer
            cmd.Connection = conn
            cmd.CommandText = "select lengthf,widthf,heightf,lengthi,widthi,heighti,lengthc,widthc,heightc,lengthm,widthm,heightm,grossweight,packingmode from packmast where packname ='" & itmnm & "'"
            If conn.State = ConnectionState.Closed Then conn.Open()
            rdr = cmd.ExecuteReader
            rdr.Read()

            Try
                lni = Val(Format((rdr("lengthi") + (12 * rdr("lengthf")) + (rdr("lengthc") / 2.54) + (rdr("lengthm") / 25.4)), "0.0000"))
            Catch
                Exit Sub
            End Try
            wdi = Val(Format((rdr("Widthi") + (12 * rdr("Widthf")) + (rdr("Widthc") / 2.54) + (rdr("Widthm") / 25.4)), "0.0000"))
            hti = Val(Format((rdr("heighti") + (12 * rdr("heightf")) + (rdr("heightc") / 2.54) + (rdr("heightm") / 25.4)), "0.0000"))
            dgv1.Item(0, rwidx).Value = rwidx + 1
            dgv1.Item(1, rwidx).Value = itmnm
            dgv1.Item(4, rwidx).Value = lni
            dgv1.Item(5, rwidx).Value = wdi
            dgv1.Item(6, rwidx).Value = hti
            dgv1.Item(3, rwidx).Value = lni * wdi * hti '* 0.000016387064   '/ 61024
            dgv1.Item(2, rwidx).Value = rdr("packingmode")
            dgv1.Item(8, rwidx).Value = rdr("grossweight")
            dgv1.Item(7, rwidx).Value = 6
            If Not CheckBox1.Checked Then
                Dim ans = MsgBox("Do you want to calculate maximum quantity?", MsgBoxStyle.YesNo)
                If ans = MsgBoxResult.Yes Then
                    stk.Clear()
                    stk.Add(arc)
                    Dim oldopt As Boolean = chkwt
                    'maxqty1 = CalcMxmQty(rwidx, tpup1)
                    maxqty1 = calcmxqty(rwidx, tpup1)
                    chkwt = oldopt
                End If
            End If

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in textbox changed", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tslblExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Try
            Call cmdExit_Click(sender, e)
        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in tslblExit_Click", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Try
            Call cmdExit_Click(sender, e)
        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in tslblExit_Click", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tslblFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Try
            Call cmdFind_Click(sender, e)
        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in tslblFind_Click", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Try

            Call cmdFind_Click(sender, e)

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in tslblFind_Click", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tslblLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Try

            Call cmdLast_Click(sender, e)

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in tslblLast_Click", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbtnLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Try

            Call cmdLast_Click(sender, e)

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in tslblLast_Click", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tslblNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Try

            Call cmdNext_Click(sender, e)

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in tslblNext_Click", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Try

            Call cmdNext_Click(sender, e)

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in tslblNext_Click", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tslblPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Try
            Call cmdPrev_Click(sender, e)
        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in tslblPrev_Click", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbtnPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Try

            Call cmdPrev_Click(sender, e)

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in tslblPrev_Click", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tslblFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Try

            Call cmdFirst_Click(sender, e)

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in tslblFirst_Click", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbtnFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Try

            Call cmdFirst_Click(sender, e)

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in tslblFirst_Click", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tslblDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Try

            Call cmdDel_Click(sender, e)

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in tslblDelete_Click", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Try

            Call cmdDel_Click(sender, e)

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in tsbtnDelete_Click", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tslblEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Try

            Call cmdEdit_Click(sender, e)

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in tslblEdit_Click", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Try

            Call cmdEdit_Click(sender, e)

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in tslblEdit_Click", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tslblAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Try

            Call cmdAdd_Click(sender, e)

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in tslblAdd_Click", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Try

            Call cmdAdd_Click(sender, e)

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in tsbtnAdd_Click", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Box3DViewerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Box3DViewerToolStripMenuItem.Click

        Dim FName As String = "C:\CSP.Box.wrl"

        Try

            Process.Start("D:\Program Files\Alteros 3D\alteros.exe", FName)

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in Box3DViewerToolStripMenuItem_Click", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Drum3DViewerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Drum3DViewerToolStripMenuItem.Click

        Dim FName As String = "C:\CSP.Drum.wrl"

        Try

            Process.Start("D:\Program Files\Alteros 3D\alteros.exe", FName)

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in Drum3DViewerToolStripMenuItem_Click", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub BoxDrum3DViewerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BoxDrum3DViewerToolStripMenuItem.Click

        MessageBox.Show(" Work in progress ", "Info.....", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub Other3DViewerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Other3DViewerToolStripMenuItem.Click

        MessageBox.Show(" Work in progress ", "Info.....", MessageBoxButtons.OK, MessageBoxIcon.Information)

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
            Catch ex As Exception
                MsgBox(ex.Message)
                MsgBox(ex.ToString)
                MessageBox.Show("Error in btnRestart_Click", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Try

    End Sub

    Private Sub tsbtnBoxTypeStuff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnBoxTypeStuff.Click

        Try

            Me.Dispose(True)
            Me.Close()
            Call BoxStuffingActivity()

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in close box stuffing activity.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbtnDrumTypeStuff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnDrumTypeStuff.Click

        Call cmdExit_Click(sender, e)
        MDIForm.Focus()
        Me.Close()
        GC.Collect()

        Try
            DisplayActivity.lblDisplayActivity.Visible = True
            DisplayActivity.lblDisplayActivity.Text = "Please wait..." & vbCrLf & "Drum type stuffing activity show"
            DisplayActivity.Show()
            Me.Dispose(True)
        Catch ex As Exception
            Exit Try
        Finally
            TransactionsMenu.Show()
            DisplayActivity.lblDisplayActivity.Text = ""
            DisplayActivity.lblDisplayActivity.Visible = False
        End Try

    End Sub

    Private Sub tsbtnBoxDrumType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnBoxDrumType.Click

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
            MessageBox.Show("Error in tsbtnSettings_Click", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tslblExit_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tslblExit.Click

        Try

            btnArngmtAct.Enabled = True
            dgv1.Cursor = Cursors.Default
            flgDGV1 = False
            btnArngmtAct.Text = "&Sort arrangement"

            btnSrN.Enabled = False
            btnNm.Enabled = False
            btnCartonLabel.Text = "&Lablel generation"
            ADclFlg = False

            Call cmdExit_Click(sender, e)

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in tslblExit_Click_1", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbtnExit_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnExit.Click

        Try

            btnArngmtAct.Enabled = True
            dgv1.Cursor = Cursors.Default
            flgDGV1 = False
            btnArngmtAct.Text = "&Sort arrangement"

            btnSrN.Enabled = False
            btnNm.Enabled = False
            btnCartonLabel.Text = "&Lablel generation"
            ADclFlg = False

            Call cmdExit_Click(sender, e)

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in tsbtnExit_Click_1", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tslblFind_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tslblFind.Click

        Try

            btnArngmtAct.Enabled = True
            dgv1.Cursor = Cursors.Default
            flgDGV1 = False
            btnArngmtAct.Text = "&Sort arrangement"

            btnSrN.Enabled = False
            btnNm.Enabled = False
            btnCartonLabel.Text = "&Lablel generation"
            ADclFlg = False

            Call cmdFind_Click(sender, e)

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in tslblFind_Click_1", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbtnFind_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnFind.Click

        Try

            btnArngmtAct.Enabled = True
            dgv1.Cursor = Cursors.Default
            flgDGV1 = False
            btnArngmtAct.Text = "&Sort arrangement"

            btnSrN.Enabled = False
            btnNm.Enabled = False
            btnCartonLabel.Text = "&Lablel generation"
            ADclFlg = False

            Call cmdFind_Click(sender, e)

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in tsbtnFind_Click_1", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tslblLast_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tslblLast.Click

        Try

            btnArngmtAct.Enabled = True
            dgv1.Cursor = Cursors.Default
            flgDGV1 = False
            btnArngmtAct.Text = "&Sort arrangement"

            btnSrN.Enabled = False
            btnNm.Enabled = False
            btnCartonLabel.Text = "&Lablel generation"
            ADclFlg = False

            Call cmdLast_Click(sender, e)

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in tslblLast_Click_1", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbtnLast_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnLast.Click

        Try

            btnArngmtAct.Enabled = True
            dgv1.Cursor = Cursors.Default
            flgDGV1 = False
            btnArngmtAct.Text = "&Sort arrangement"

            btnSrN.Enabled = False
            btnNm.Enabled = False
            btnCartonLabel.Text = "&Lablel generation"
            ADclFlg = False

            Call cmdLast_Click(sender, e)

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in tsbtnLast_Click_1", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tslblNext_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tslblNext.Click

        Try

            btnArngmtAct.Enabled = True
            dgv1.Cursor = Cursors.Default
            flgDGV1 = False
            btnArngmtAct.Text = "&Sort arrangement"

            btnSrN.Enabled = False
            btnNm.Enabled = False
            btnCartonLabel.Text = "&Lablel generation"
            ADclFlg = False

            Call cmdNext_Click(sender, e)

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in tslblNext_Click_1", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbtnNext_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnNext.Click

        Try

            btnArngmtAct.Enabled = True
            dgv1.Cursor = Cursors.Default
            flgDGV1 = False
            btnArngmtAct.Text = "&Sort arrangement"

            btnSrN.Enabled = False
            btnNm.Enabled = False
            btnCartonLabel.Text = "&Lablel generation"
            ADclFlg = False

            Call cmdNext_Click(sender, e)

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in tsbtnNext_Click_1", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tslblPrev_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tslblPrev.Click

        Try

            btnArngmtAct.Enabled = True
            dgv1.Cursor = Cursors.Default
            flgDGV1 = False
            btnArngmtAct.Text = "&Sort arrangement"

            btnSrN.Enabled = False
            btnNm.Enabled = False
            btnCartonLabel.Text = "&Lablel generation"
            ADclFlg = False

            Call cmdPrev_Click(sender, e)

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in tslblPrev_Click_1", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbtnPrev_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnPrev.Click

        Try

            btnArngmtAct.Enabled = True
            dgv1.Cursor = Cursors.Default
            flgDGV1 = False
            btnArngmtAct.Text = "&Sort arrangement"

            btnSrN.Enabled = False
            btnNm.Enabled = False
            btnCartonLabel.Text = "&Lablel generation"
            ADclFlg = False

            Call cmdPrev_Click(sender, e)

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in tsbtnPrev_Click_1", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tslblFirst_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tslblFirst.Click

        Try

            btnArngmtAct.Enabled = True
            dgv1.Cursor = Cursors.Default
            flgDGV1 = False
            btnArngmtAct.Text = "&Sort arrangement"

            btnSrN.Enabled = False
            btnNm.Enabled = False
            btnCartonLabel.Text = "&Lablel generation"
            ADclFlg = False

            Call cmdFirst_Click(sender, e)

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in tslblFirst_Click_1", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbtnFirst_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnFirst.Click

        Try

            btnArngmtAct.Enabled = True
            dgv1.Cursor = Cursors.Default
            flgDGV1 = False
            btnArngmtAct.Text = "&Sort arrangement"

            btnSrN.Enabled = False
            btnNm.Enabled = False
            btnCartonLabel.Text = "&Lablel generation"
            ADclFlg = False

            Call cmdFirst_Click(sender, e)

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in tsbtnFirst_Click_1", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tslblDelete_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tslblDelete.Click

        Try

            btnArngmtAct.Enabled = True
            dgv1.Cursor = Cursors.Default
            flgDGV1 = False
            btnArngmtAct.Text = "&Sort arrangement"

            btnSrN.Enabled = False
            btnNm.Enabled = False
            btnCartonLabel.Text = "&Lablel generation"
            ADclFlg = False

            Call cmdDel_Click(sender, e)

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in tslblDelete_Click_1", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbtnDelete_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnDelete.Click

        Try

            btnArngmtAct.Enabled = True
            dgv1.Cursor = Cursors.Default
            flgDGV1 = False
            btnArngmtAct.Text = "&Sort arrangement"

            btnSrN.Enabled = False
            btnNm.Enabled = False
            btnCartonLabel.Text = "&Lablel generation"
            ADclFlg = False

            Call cmdDel_Click(sender, e)

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in tslblDelete_Click_1", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tslblEdit_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tslblEdit.Click

        Try

            btnArngmtAct.Enabled = True
            dgv1.Cursor = Cursors.Default
            flgDGV1 = False
            btnArngmtAct.Text = "&Sort arrangement"

            btnSrN.Enabled = False
            btnNm.Enabled = False
            btnCartonLabel.Text = "&Lablel generation"
            ADclFlg = False

            Call cmdEdit_Click(sender, e)

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in tslblEdit_Click_1", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbtnEdit_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnEdit.Click

        Try

            btnArngmtAct.Enabled = True
            dgv1.Cursor = Cursors.Default
            flgDGV1 = False
            btnArngmtAct.Text = "&Sort arrangement"

            btnSrN.Enabled = False
            btnNm.Enabled = False
            btnCartonLabel.Text = "&Lablel generation"
            ADclFlg = False

            Call cmdEdit_Click(sender, e)

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in tsbtnEdit_Click_1", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tslblAdd_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tslblAdd.Click

        Try

            btnArngmtAct.Enabled = True
            dgv1.Cursor = Cursors.Default
            flgDGV1 = False
            btnArngmtAct.Text = "&Sort arrangement"

            btnSrN.Enabled = False
            btnNm.Enabled = False
            btnCartonLabel.Text = "&Lablel generation"
            ADclFlg = False

            Call cmdAdd_Click(sender, e)

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in tslblAdd_Click_1", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbtnAdd_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnAdd.Click

        Try

            btnArngmtAct.Enabled = True
            dgv1.Cursor = Cursors.Default
            flgDGV1 = False
            btnArngmtAct.Text = "&Sort arrangement"

            btnSrN.Enabled = False
            btnNm.Enabled = False
            btnCartonLabel.Text = "&Lablel generation"
            ADclFlg = False

            Call cmdAdd_Click(sender, e)

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in tsbtnAdd_Click_1", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

#End Region

#Region " Function Definitions "

    Public Function CalcMxmQty(ByVal rowno1 As Integer, ByVal tpupx As Boolean)

        Stop

        Try
            Bitemno = 0
            chkwt = True
            Dim ar() As Area
            Dim ari() As String
            Dim arwt() As Single
            Dim ar1 As New Area

            Dim ln As Double
            Dim wd As Double
            Dim ht As Double
            Dim qty As Integer
            Dim seq As Integer
            Dim itmnm1 As String = Nothing
            Dim wt As String = Nothing
            Dim transparr() As Boolean
            Dim transp As Boolean
            Dim topup() As Boolean
            Dim tpup As Boolean

            ReDim ar(0)
            ReDim ari(0)
            ReDim arwt(0)
            ReDim transparr(0)
            ReDim topup(0)
            Dim cmd As New OleDb.OleDbCommand

            Dim cnt As Integer = 0
            Dim lstcol As New List(Of Byte)

            DelTab("temp1")
            If CmbContainer.Text = "" Then
                MsgBox("Container not selected")
                CmbContainer.Focus()
                Return Nothing
                Exit Function
            End If

            For i As Integer = 0 To rowno1 - 1
                If dgv1.Item(11, i).Value Is Nothing OrElse Not IsNumeric(dgv1.Item(11, i).Value) OrElse dgv1.Item(11, i).Value.ToString.Contains(".") OrElse CInt(dgv1.Item(11, i).Value) <= 0 Then
                    MsgBox("Invalid quantity at row " & CStr(i + 1))
                    Return Nothing
                    Exit Function
                End If

            Next
            For i As Integer = 0 To rowno1
                itmnm1 = dgv1.Item(1, i).Value
                ln = Math.Round(dgv1.Item(4, i).Value, 4)
                wd = Math.Round(dgv1.Item(5, i).Value, 4)
                ht = Math.Round(dgv1.Item(6, i).Value, 4)
                If i = rowno1 Then
                    qty = 0
                    dgv1.Item(11, i).Value = ""
                Else
                    qty = dgv1.Item(11, i).Value
                End If

                wt = dgv1.Item(8, i).Value
                seq = dgv1.Item(0, i).Value
                transp = False
                If rowno1 = 0 Then
                    tpup = tpupx
                Else
                    tpup = IIf(dgv1.Item(7, i).Value = "6", False, True)
                End If

                For j As Integer = 0 To qty
                    ar(UBound(ar)) = New Area
                    ar(UBound(ar)).length = ln
                    ar(UBound(ar)).width = wd
                    ar(UBound(ar)).height = ht
                    ari(UBound(ari)) = itmnm1
                    arwt(UBound(arwt)) = wt
                    transparr(UBound(transparr)) = transp
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
                cnt += 1

            Next i

            stpBox += 1

            If stpBox = dgv1.RowCount Then
                stpBox = 0
                cnt = 0
            End If
            ReDim Preserve ar(UBound(ar) - 1)
            If UBound(ari) > 0 Then
                ReDim Preserve ari(UBound(ari) - 1)
                ReDim Preserve arwt(UBound(arwt) - 1)
                ReDim Preserve transparr(UBound(transparr) - 1)
                ReDim Preserve topup(UBound(topup) - 1)
            End If
            arc.StrtPt.x = 0
            arc.StrtPt.y = 0
            arc.StrtPt.z = 0
            arc.length = contarr(0)
            arc.width = contarr(1)
            arc.height = contarr(2)
            qty = 0

            Stop

            Dim outfile As String = CurDir() & "\" & "First.wrl"
            If ar.Length > 0 Then

                If stk.Count = 0 Then stk.Add(arc)

                If Not CheckBox1.Checked Then

                    stk1 = stuff(arc, ar, ari, arwt, False, False, outfile, False, transparr, topup, Btxtopt, False, False, True, colarr)

                Else

                    stk1 = Stuffx(arc, ar, ari, arwt, True, False, outfile, False, transparr, topup, Btxtopt, False, False, True, colarr)

                    Dim ar3() As Area
                    Dim ari3() As String
                    Dim arwt3() As Single
                    Dim transparr3() As Boolean
                    Dim topup1() As Boolean

                    ReDim ar3(0)
                    ReDim ari3(0)
                    ReDim arwt3(0)
                    ReDim transparr3(0)
                    ReDim topup1(0)
                    xcnt = xid
                    For ii As Integer = xid To UBound(ar)
                        ar3(UBound(ar3)) = ar(ii)
                        ari3(UBound(ari3)) = ari(ii)
                        arwt3(UBound(arwt3)) = arwt(ii)
                        transparr3(UBound(transparr3)) = transparr(ii)
                        topup1(UBound(topup1)) = True
                        ReDim Preserve ar3(UBound(ar3) + 1)
                        ReDim Preserve ari3(UBound(ari3) + 1)
                        ReDim Preserve arwt3(UBound(arwt3) + 1)
                        ReDim Preserve transparr3(UBound(transparr3) + 1)
                        ReDim Preserve topup1(UBound(topup1) + 1)
                    Next
                    ReDim Preserve ar3(UBound(ar3) - 1)
                    ReDim Preserve ari3(UBound(ari3) - 1)
                    ReDim Preserve arwt3(UBound(arwt3) - 1)
                    ReDim Preserve transparr3(UBound(transparr3) - 1)
                    ReDim Preserve topup1(UBound(topup1) - 1)


                    stk.Clear()

                    For iu As Integer = 0 To stksav(xid - 1).Count - 1
                        stk.Add(stksav(xid - 1)(iu))
                    Next

                    Dim ar4() As Area
                    ReDim ar4(0)
                    For uu As Integer = LBound(ar3) To UBound(ar3)
                        Dim arr1 As New Area
                        Dim arr As Area = ar3(uu)
                        Dim ln4 As Single = arr.length
                        Dim wd4 As Single = arr.width
                        Dim ht4 As Single = arr.height
                        Dim min As String = "l"
                        Dim min1 As Single = ln4
                        If wd4 < min1 Then
                            min1 = wd4
                            min = "w"
                        End If

                        If ht4 < min1 Then
                            min1 = ht4
                            min = "h"
                        End If

                        arr1.StrtPt.x = arr.StrtPt.x
                        arr1.StrtPt.y = arr.StrtPt.y
                        arr1.StrtPt.z = arr.StrtPt.z
                        arr1.height = min1

                        If min = "l" Then

                            arr1.width = arr.width
                            arr1.length = arr.height

                        End If

                        If min = "w" Then
                            arr1.width = arr.height
                            arr1.length = arr.length

                        End If

                        If min = "h" Then
                            arr1.length = arr.length
                            arr1.width = arr.width
                        End If

                        ar4(UBound(ar4)) = arr1
                        ReDim Preserve ar4(UBound(ar4) + 1)

                    Next
                    ReDim Preserve ar4(UBound(ar4) - 1)
                    Stuffx(arc, ar4, ari3, arwt3, True, False, outfile, False, transparr3, topup1, False, False, False, False, colarr)

                End If

                Bplclst.Clear()
                ReDim ar(0)
                ReDim ari(0)
                ReDim arwt(0)
                ReDim transparr(0)
                ReDim topup(0)
                MsgBox(Bitemqty)

                'DisplayPicture.lblCSPPicDisplay.Text = "The Number of Items " & Bitemqty & " placed."
                'DisplayPicture.btn_BoxesDiffDim.Visible = True
                'DisplayPicture.lblCSPPicDisplay.Refresh()
                'DHSDrums()

                MessageBox.Show("The Number of Items " & Bitemqty & " placed", "Maximum Quantity Info.....", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else
                If dgv1.RowCount > 1 Then
                    If ar.Length <> 0 Then
                        For i As Integer = 0 To dgv1.RowCount - 1
                            For j As Integer = 0 To dgv1.ColumnCount - 1
                                dgv1.Item(j, i).Style.BackColor = Color.White
                            Next
                        Next
                    End If
                Else

                End If

            End If
            Dim mm As New Area
            Dim mm1 As New Area

            Dim vol1 As Double = 0
            Dim vol2 As Double = 0
            Dim maxqty As Integer
            Dim arx As New List(Of Area)

            If rowno1 > 0 Then
                mm.length = Math.Round(dgv1.Item(4, rowno1).Value, 4)
                mm.width = Math.Round(dgv1.Item(5, rowno1).Value, 4)
                mm.height = Math.Round(dgv1.Item(6, rowno1).Value, 4)
                tpup = tpupx
            Else
                mm.length = Math.Round(dgv1.Item(4, 0).Value, 4)
                mm.width = Math.Round(dgv1.Item(5, 0).Value, 4)
                mm.height = Math.Round(dgv1.Item(6, 0).Value, 4)
                tpup = tpupx
                Bqtylst.Add(-1)
            End If
            vol1 = mm.length * mm.height * mm.width
            If vol1 <> 0 Then
                vol2 = 0
                For j As Integer = 0 To stk.Count - 1
                    mm1 = stk(j)
                    vol2 = vol2 + (mm1.length * mm1.width * mm1.height)
                Next

                maxqty = Fix(vol2 / vol1)

                ReDim ar(0)
                ReDim ari(0)
                For j As Integer = 0 To maxqty - 1
                    ar(UBound(ar)) = New Area
                    ar(UBound(ar)).length = mm.length
                    ar(UBound(ar)).width = mm.width
                    ar(UBound(ar)).height = mm.height
                    ari(UBound(ari)) = itmnm1
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

                Stop

                If Not CheckBox1.Checked Then

                    Call stuff(arc, ar, ari, arwt, False, False, "", False, Nothing, topup, False, False, False, True, colarr)

                Else

                    Call Stuffx(arc, ar, ari, arwt, True, False, "", False, Nothing, topup, False, False, False, True, colarr)

                    If Not fullflag Then
                        Dim ar3() As Area
                        Dim ari3() As String
                        Dim arwt3() As Single
                        Dim transparr3() As Boolean
                        Dim topup1() As Boolean

                        ReDim ar3(0)
                        ReDim ari3(0)
                        ReDim arwt3(0)
                        ReDim transparr3(0)
                        ReDim topup1(0)
                        xcnt = xid
                        For ii As Integer = xid To UBound(ar)
                            ar3(UBound(ar3)) = ar(ii)
                            ari3(UBound(ari3)) = ari(ii)
                            arwt3(UBound(arwt3)) = arwt(ii)
                            transparr3(UBound(transparr3)) = transparr(ii)
                            topup1(UBound(topup1)) = True
                            ReDim Preserve ar3(UBound(ar3) + 1)
                            ReDim Preserve ari3(UBound(ari3) + 1)
                            ReDim Preserve arwt3(UBound(arwt3) + 1)
                            ReDim Preserve transparr3(UBound(transparr3) + 1)
                            ReDim Preserve topup1(UBound(topup1) + 1)
                        Next
                        ReDim Preserve ar3(UBound(ar3) - 1)
                        ReDim Preserve ari3(UBound(ari3) - 1)
                        ReDim Preserve arwt3(UBound(arwt3) - 1)
                        ReDim Preserve transparr3(UBound(transparr3) - 1)
                        ReDim Preserve topup1(UBound(topup1) - 1)

                        stk.Clear()

                        For iu As Integer = 0 To stksav(xid - 1).Count - 1
                            stk.Add(stksav(xid - 1)(iu))
                        Next

                        Dim ar4() As Area
                        ReDim ar4(0)
                        For uu As Integer = LBound(ar3) To UBound(ar3)
                            Dim arr1 As New Area
                            Dim arr As Area = ar3(uu)
                            Dim ln4 As Single = arr.length
                            Dim wd4 As Single = arr.width
                            Dim ht4 As Single = arr.height
                            Dim min As String = "l"
                            Dim min1 As Single = ln4
                            If wd4 < min1 Then
                                min1 = wd4
                                min = "w"
                            End If

                            If ht4 < min1 Then
                                min1 = ht4
                                min = "h"
                            End If

                            arr1.StrtPt.x = arr.StrtPt.x
                            arr1.StrtPt.y = arr.StrtPt.y
                            arr1.StrtPt.z = arr.StrtPt.z
                            arr1.height = min1

                            If min = "l" Then

                                arr1.width = arr.width
                                arr1.length = arr.height

                            End If

                            If min = "w" Then
                                arr1.width = arr.height
                                arr1.length = arr.length

                            End If

                            If min = "h" Then
                                arr1.length = arr.length
                                arr1.width = arr.width
                            End If

                            ar4(UBound(ar4)) = arr1
                            ReDim Preserve ar4(UBound(ar4) + 1)

                        Next
                        If chkwt Then
                            xcnt1 = xcnt
                        End If
                        ReDim Preserve ar4(UBound(ar4) - 1)
                        Stuffx(arc, ar4, ari3, arwt3, False, False, outfile, False, transparr3, topup1, False, False, False, False, colarr)
                    End If

                End If

                ReDim ar(0)
                ReDim ari(0)
                ReDim arwt(0)
                ReDim transparr(0)
                ReDim topup(0)

                If CInt(dgv1.Item(10, dgv1.RowCount - 1).Value) > Bitemqty Then
                    MsgBox("Requested Quantity " & dgv1.Item(11, dgv1.RowCount - 2).Value & " is greater than maximum quatity")
                    dgv1.Item(11, dgv1.RowCount - 1).Value = Bitemqty
                End If

                If CheckBox1.Checked Then
                    If chkwt Then
                        Bitemqty = xcnt + Bitemqty
                        'itemqty += 1
                    End If
                End If
                dgv1.Item(10, rowno1).Value = Bitemqty
                'Form8.Close()

                lblStatus.Visible = False
                lblStatusINm.Visible = False
                btnStatus.Visible = False

                pbCSP1.Visible = False

                Bitemqty = 0
                stk.Clear()
                stk.Add(arc)
            Else
                'dgv1.AllowUserToAddRows = False
            End If

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in CalcMxmQty", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        stk.Clear()
        stk.Add(arc)
        Bqtylst.Clear()
        'Stop
        chkwt = True
        Return Bitemqty

    End Function

    Public Function CalcShowMxQty(ByVal rowno1 As Integer, ByVal tpupx As Boolean)

        itemno = 0
        chkwt = True
        Dim ar() As Area
        Dim ari() As String
        Dim arwt() As Single
        Dim ar1 As New Area

        Dim ln As Double
        Dim wd As Double
        Dim ht As Double
        Dim qty As Integer
        Dim seq As Integer
        Dim itmnm1 As String = Nothing
        Dim wt As String = Nothing
        Dim transparr() As Boolean
        Dim transp As Boolean
        Dim topup() As Boolean
        Dim tpup As Boolean
        Dim rowno As Integer = 0
        ReDim ar(0)
        ReDim ari(0)
        ReDim arwt(0)
        ReDim transparr(0)
        ReDim topup(0)
        Dim cmd As New OleDb.OleDbCommand
        Dim rdr As OleDb.OleDbDataReader = Nothing
        Dim cnt As Integer = 0
        Dim lstcol As New List(Of Byte)
        Button1.Enabled = False
        DelTab("temp1")
        If CmbContainer.Text = "" Then
            MsgBox("Container not selected")
            CmbContainer.Focus()
            Return Nothing
            Exit Function
        End If

        For i As Integer = 0 To rowno1 - 1
            If dgv1.Item(11, i).Value Is Nothing OrElse Not IsNumeric(dgv1.Item(11, i).Value) OrElse dgv1.Item(11, i).Value.ToString.Contains(".") OrElse CInt(dgv1.Item(11, i).Value) <= 0 Then
                MsgBox("Invalid quantity at row " & CStr(i + 1))
                Return Nothing
                Exit Function
            End If

        Next
        For i As Integer = 0 To rowno1
            itmnm1 = dgv1.Item(1, i).Value
            ln = Math.Round(dgv1.Item(4, i).Value, 4)
            wd = Math.Round(dgv1.Item(5, i).Value, 4)
            ht = Math.Round(dgv1.Item(6, i).Value, 4)
            If i = rowno1 Then
                qty = 0
                dgv1.Item(11, i).Value = ""
            Else
                qty = dgv1.Item(11, i).Value
            End If

            wt = dgv1.Item(8, i).Value
            seq = dgv1.Item(0, i).Value
            transp = False
            If rowno1 = 0 Then
                tpup = tpupx
            Else
                tpup = IIf(dgv1.Item(7, i).Value = "6", False, True)
            End If

            For j As Integer = 0 To qty
                ar(UBound(ar)) = New Area
                ar(UBound(ar)).length = ln
                ar(UBound(ar)).width = wd
                ar(UBound(ar)).height = ht
                ari(UBound(ari)) = itmnm1
                arwt(UBound(arwt)) = wt
                transparr(UBound(transparr)) = transp
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
            cnt += 1

            ''dgv1.Item(11, i).Value = ""
            'instab("temp1", New Object() {itmnm1, CStr(ln), CStr(wd), CStr(ht), CStr(qty), CStr(wt), CStr(seq), CStr(transp), CStr(tpup)})
        Next i
        'Dim rdr1 As DataRow()
        'rdr1 = getf("temp1", "", "seq ASC")
        'cnt = 0

        'For i As Integer = 1 To rdr1.Length - 1

        '    itmnm1 = rdr1(i)("itmnm")
        '    ln = rdr1(i)("ln")
        '    wd = rdr1(i)("wd")
        '    ht = rdr1(i)("ht")
        '    qty = rdr1(i)("qty")
        '    wt = rdr1(i)("wt")
        '    transp = rdr1(i)("transp")
        '    tpup = rdr1(i)("tpup")
        '    seq = rdr1(i)("seq")
        '    qtylst.Add(qty)

        '    ar1.length = ln
        '    ar1.width = wd
        '    ar1.height = ht
        '    ar1.strtpt.x = 0
        '    ar1.strtpt.y = 0
        '    ar1.strtpt.z = 0
        '    For j As Integer = 0 To qty
        '        ar(UBound(ar)) = New Area
        '        ar(UBound(ar)).length = ar1.length
        '        ar(UBound(ar)).width = ar1.width
        '        ar(UBound(ar)).height = ar1.height
        '        ari(UBound(ari)) = itmnm1
        '        arwt(UBound(arwt)) = wt
        '        transparr(UBound(transparr)) = transp
        '        topup(UBound(topup)) = tpup
        '        colarr.Add(lstcol)
        '        ReDim Preserve ar(UBound(ar) + 1)
        '        ReDim Preserve ari(UBound(ari) + 1)
        '        ReDim Preserve arwt(UBound(arwt) + 1)
        '        ReDim Preserve transparr(UBound(transparr) + 1)
        '        ReDim Preserve topup(UBound(topup) + 1)
        '    Next
        '    ReDim Preserve ar(UBound(ar) - 1)
        '    ReDim Preserve ari(UBound(ari) - 1)
        '    ReDim Preserve arwt(UBound(arwt) - 1)
        '    ReDim Preserve transparr(UBound(transparr) - 1)
        '    ReDim Preserve topup(UBound(topup) - 1)
        '    cnt += 1
        'Next
        stp += 1

        If stp = dgv1.RowCount Then
            stp = 0
            cnt = 0
        End If
        ReDim Preserve ar(UBound(ar) - 1)
        If UBound(ari) > 0 Then
            ReDim Preserve ari(UBound(ari) - 1)
            ReDim Preserve arwt(UBound(arwt) - 1)
            ReDim Preserve transparr(UBound(transparr) - 1)
            ReDim Preserve topup(UBound(topup) - 1)
        End If
        arc.StrtPt.x = 0
        arc.StrtPt.y = 0
        arc.StrtPt.z = 0
        arc.length = contarr(0)
        arc.width = contarr(1)
        arc.height = contarr(2)
        qty = 0
        Dim outfile As String = CurDir() & "\" & "first.wrl"
        If ar.Length > 0 Then
            If stk.Count = 0 Then stk.Add(arc)
            If Not CheckBox1.Checked Then
                stk1 = stuff(arc, ar, ari, arwt, False, False, outfile, False, transparr, topup, Btxtopt, False, False, True, colarr)
            Else
                stk1 = Stuffx(arc, ar, ari, arwt, True, False, outfile, False, transparr, topup, Btxtopt, False, False, True, colarr)
                Dim ar3() As Area
                Dim ari3() As String
                Dim arwt3() As Single
                Dim transparr3() As Boolean
                Dim topup1() As Boolean

                ReDim ar3(0)
                ReDim ari3(0)
                ReDim arwt3(0)
                ReDim transparr3(0)
                ReDim topup1(0)
                xcnt = xid
                For ii As Integer = xid To UBound(ar)
                    ar3(UBound(ar3)) = ar(ii)
                    ari3(UBound(ari3)) = ari(ii)
                    arwt3(UBound(arwt3)) = arwt(ii)
                    transparr3(UBound(transparr3)) = transparr(ii)
                    topup1(UBound(topup1)) = True
                    ReDim Preserve ar3(UBound(ar3) + 1)
                    ReDim Preserve ari3(UBound(ari3) + 1)
                    ReDim Preserve arwt3(UBound(arwt3) + 1)
                    ReDim Preserve transparr3(UBound(transparr3) + 1)
                    ReDim Preserve topup1(UBound(topup1) + 1)
                Next
                ReDim Preserve ar3(UBound(ar3) - 1)
                ReDim Preserve ari3(UBound(ari3) - 1)
                ReDim Preserve arwt3(UBound(arwt3) - 1)
                ReDim Preserve transparr3(UBound(transparr3) - 1)
                ReDim Preserve topup1(UBound(topup1) - 1)
                'FileClose(1)
                'off.Close()

                stk.Clear()
                'Dim rwx() As DataRow
                'rwx = getf("temp8", "seq = " & xid, "")
                For iu As Integer = 0 To stksav(xid - 1).Count - 1
                    stk.Add(stksav(xid - 1)(iu))
                Next
                'For iu As Integer = LBound(rwx) To UBound(rwx)
                '    Dim mn1 As New Area
                '    mn1.strtpt.x = rwx(iu)("x")
                '    mn1.strtpt.y = rwx(iu)("y")
                '    mn1.strtpt.z = rwx(iu)("z")
                '    mn1.length = rwx(iu)("l")
                '    mn1.width = rwx(iu)("w")
                '    mn1.height = rwx(iu)("h")
                '    stk.Add(mn1)
                'Next
                Dim ar4() As Area
                ReDim ar4(0)
                For uu As Integer = LBound(ar3) To UBound(ar3)
                    Dim arr1 As New Area
                    Dim arr As Area = ar3(uu)
                    Dim ln4 As Single = arr.length
                    Dim wd4 As Single = arr.width
                    Dim ht4 As Single = arr.height
                    Dim min As String = "l"
                    Dim min1 As Single = ln4
                    If wd4 < min1 Then
                        min1 = wd4
                        min = "w"
                    End If

                    If ht4 < min1 Then
                        min1 = ht4
                        min = "h"
                    End If

                    arr1.StrtPt.x = arr.StrtPt.x
                    arr1.StrtPt.y = arr.StrtPt.y
                    arr1.StrtPt.z = arr.StrtPt.z
                    arr1.height = min1

                    If min = "l" Then

                        arr1.width = arr.width
                        arr1.length = arr.height


                    End If

                    If min = "w" Then
                        arr1.width = arr.height
                        arr1.length = arr.length


                    End If

                    If min = "h" Then
                        arr1.length = arr.length
                        arr1.width = arr.width
                    End If


                    ar4(UBound(ar4)) = arr1
                    ReDim Preserve ar4(UBound(ar4) + 1)


                Next
                ReDim Preserve ar4(UBound(ar4) - 1)
                Stuffx(arc, ar4, ari3, arwt3, True, False, outfile, False, transparr3, topup1, False, False, False, False, colarr)

            End If

            Bplclst.Clear()
            ReDim ar(0)
            ReDim ari(0)
            ReDim arwt(0)
            ReDim transparr(0)
            ReDim topup(0)
            MsgBox(itemqty)
        Else
            If dgv1.RowCount > 1 Then
                If ar.Length <> 0 Then
                    For i As Integer = 0 To dgv1.RowCount - 1
                        For j As Integer = 0 To dgv1.ColumnCount - 1
                            dgv1.Item(j, i).Style.BackColor = Color.White
                        Next
                    Next
                End If
            Else

            End If

        End If
        Dim mm As New Area
        Dim mm1 As New Area

        Dim vol1 As Double = 0
        Dim vol2 As Double = 0
        Dim maxqty As Integer
        Dim arx As New List(Of Area)

        If rowno1 > 0 Then
            mm.length = Math.Round(dgv1.Item(4, rowno1).Value, 4)
            mm.width = Math.Round(dgv1.Item(5, rowno1).Value, 4)
            mm.height = Math.Round(dgv1.Item(6, rowno1).Value, 4)
            tpup = tpupx
        Else
            mm.length = Math.Round(dgv1.Item(4, 0).Value, 4)
            mm.width = Math.Round(dgv1.Item(5, 0).Value, 4)
            mm.height = Math.Round(dgv1.Item(6, 0).Value, 4)
            tpup = tpupx
            Bqtylst.Add(-1)
        End If
        vol1 = mm.length * mm.height * mm.width
        If vol1 <> 0 Then
            vol2 = 0
            For j As Integer = 0 To stk.Count - 1
                mm1 = stk(j)
                vol2 = vol2 + (mm1.length * mm1.width * mm1.height)
            Next

            maxqty = Fix(vol2 / vol1)
            'If MsgBox("Approx. Maximum Quantity is: " & maxqty.ToString & vbCrLf & "Do you want to proceed?", MsgBoxStyle.Information + vbYesNo) = MsgBoxResult.No Then
            'Exit Function
            'End If
            ReDim ar(0)
            ReDim ari(0)
            For j As Integer = 0 To maxqty - 1
                ar(UBound(ar)) = New Area
                ar(UBound(ar)).length = mm.length
                ar(UBound(ar)).width = mm.width
                ar(UBound(ar)).height = mm.height
                ari(UBound(ari)) = itmnm1
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
            If Not CheckBox1.Checked Then
                Call stuff(arc, ar, ari, arwt, False, False, "", False, Nothing, topup, False, False, False, True, colarr)
            Else
                Call Stuffx(arc, ar, ari, arwt, True, False, "", False, Nothing, topup, False, False, False, True, colarr)
                If Not fullflag Then
                    Dim ar3() As Area
                    Dim ari3() As String
                    Dim arwt3() As Single
                    Dim transparr3() As Boolean
                    Dim topup1() As Boolean

                    ReDim ar3(0)
                    ReDim ari3(0)
                    ReDim arwt3(0)
                    ReDim transparr3(0)
                    ReDim topup1(0)
                    xcnt = xid
                    For ii As Integer = xid To UBound(ar)
                        ar3(UBound(ar3)) = ar(ii)
                        ari3(UBound(ari3)) = ari(ii)
                        arwt3(UBound(arwt3)) = arwt(ii)
                        transparr3(UBound(transparr3)) = transparr(ii)
                        topup1(UBound(topup1)) = True
                        ReDim Preserve ar3(UBound(ar3) + 1)
                        ReDim Preserve ari3(UBound(ari3) + 1)
                        ReDim Preserve arwt3(UBound(arwt3) + 1)
                        ReDim Preserve transparr3(UBound(transparr3) + 1)
                        ReDim Preserve topup1(UBound(topup1) + 1)
                    Next
                    ReDim Preserve ar3(UBound(ar3) - 1)
                    ReDim Preserve ari3(UBound(ari3) - 1)
                    ReDim Preserve arwt3(UBound(arwt3) - 1)
                    ReDim Preserve transparr3(UBound(transparr3) - 1)
                    ReDim Preserve topup1(UBound(topup1) - 1)
                    'FileClose(1)
                    'off.Close()

                    stk.Clear()
                    'Dim rwx() As DataRow
                    'rwx = getf("temp8", "seq = " & xid, "")
                    For iu As Integer = 0 To stksav(xid - 1).Count - 1
                        stk.Add(stksav(xid - 1)(iu))
                    Next
                    'For iu As Integer = LBound(rwx) To UBound(rwx)
                    '    Dim mn1 As New Area
                    '    mn1.strtpt.x = rwx(iu)("x")
                    '    mn1.strtpt.y = rwx(iu)("y")
                    '    mn1.strtpt.z = rwx(iu)("z")
                    '    mn1.length = rwx(iu)("l")
                    '    mn1.width = rwx(iu)("w")
                    '    mn1.height = rwx(iu)("h")
                    '    stk.Add(mn1)
                    'Next
                    Dim ar4() As Area
                    ReDim ar4(0)
                    For uu As Integer = LBound(ar3) To UBound(ar3)
                        Dim arr1 As New Area
                        Dim arr As Area = ar3(uu)
                        Dim ln4 As Single = arr.length
                        Dim wd4 As Single = arr.width
                        Dim ht4 As Single = arr.height
                        Dim min As String = "l"
                        Dim min1 As Single = ln4
                        If wd4 < min1 Then
                            min1 = wd4
                            min = "w"
                        End If

                        If ht4 < min1 Then
                            min1 = ht4
                            min = "h"
                        End If

                        arr1.StrtPt.x = arr.StrtPt.x
                        arr1.StrtPt.y = arr.StrtPt.y
                        arr1.StrtPt.z = arr.StrtPt.z
                        arr1.height = min1

                        If min = "l" Then

                            arr1.width = arr.width
                            arr1.length = arr.height


                        End If

                        If min = "w" Then
                            arr1.width = arr.height
                            arr1.length = arr.length


                        End If

                        If min = "h" Then
                            arr1.length = arr.length
                            arr1.width = arr.width
                        End If


                        ar4(UBound(ar4)) = arr1
                        ReDim Preserve ar4(UBound(ar4) + 1)


                    Next
                    If chkwt Then
                        xcnt1 = xcnt
                    End If
                    ReDim Preserve ar4(UBound(ar4) - 1)
                    Stuffx(arc, ar4, ari3, arwt3, False, False, outfile, False, transparr3, topup1, False, False, False, False, colarr)
                End If
                'If chkwt Then
                'xcnt = xcnt1
                'End If
            End If

            ReDim ar(0)
            ReDim ari(0)
            ReDim arwt(0)
            ReDim transparr(0)
            ReDim topup(0)
            'Stop
            If CInt(dgv1.Item(10, dgv1.RowCount - 1).Value) > itemqty Then
                MsgBox("Requested Quantity " & dgv1.Item(11, dgv1.RowCount - 2).Value & " is greater than maximum quatity")
                dgv1.Item(11, dgv1.RowCount - 1).Value = itemqty
            End If
            'If CheckBox1.Checked Then
            'itemqty = xcnt1
            'End If
            If CheckBox1.Checked Then
                If chkwt Then
                    itemqty = xcnt + itemqty
                    'itemqty += 1
                End If
            End If
            dgv1.Item(10, rowno1).Value = itemqty
            Form8.Close()
            itemqty = 0
            stk.Clear()
            stk.Add(arc)
        Else
            'dgv1.AllowUserToAddRows = False
        End If

        stk.Clear()
        stk.Add(arc)
        Bqtylst.Clear()
        'Stop
        chkwt = True
        Return itemqty

    End Function

    Public Function calcmxqtyShow(ByVal rowno1 As Integer, ByVal tpupx As Boolean) As Integer

        itemno = 0
        chkwt = True
        Dim ar() As Area
        Dim ari() As String
        Dim arwt() As Single
        Dim ar1 As New Area

        Dim ln As Double
        Dim wd As Double
        Dim ht As Double
        Dim qty As Integer
        Dim seq As Integer
        Dim itmnm1 As String = Nothing
        Dim wt As String = Nothing
        Dim transparr() As Boolean
        Dim transp As Boolean
        Dim topup() As Boolean
        Dim tpup As Boolean
        Dim rowno As Integer = 0
        ReDim ar(0)
        ReDim ari(0)
        ReDim arwt(0)
        ReDim transparr(0)
        ReDim topup(0)
        Dim cmd As New OleDb.OleDbCommand
        Dim rdr As OleDb.OleDbDataReader = Nothing
        Dim cnt As Integer = 0
        Dim lstcol As New List(Of Byte)
        Button1.Enabled = False
        DelTab("temp1")
        If CmbContainer.Text = "" Then
            MsgBox("Container not selected")
            CmbContainer.Focus()
            Return 0

        End If

        For i As Integer = 0 To rowno1 - 1
            If dgv1.Item(11, i).Value Is Nothing OrElse Not IsNumeric(dgv1.Item(11, i).Value) OrElse dgv1.Item(11, i).Value.ToString.Contains(".") OrElse CInt(dgv1.Item(11, i).Value) <= 0 Then
                MsgBox("Invalid quantity at row " & CStr(i + 1))
                Return 0
            End If

        Next
        For i As Integer = 0 To rowno1
            itmnm1 = dgv1.Item(1, i).Value
            ln = Math.Round(dgv1.Item(4, i).Value, 4)
            wd = Math.Round(dgv1.Item(5, i).Value, 4)
            ht = Math.Round(dgv1.Item(6, i).Value, 4)
            If i = rowno1 Then
                qty = 0
                dgv1.Item(11, i).Value = ""
            Else
                qty = dgv1.Item(11, i).Value
            End If

            wt = dgv1.Item(8, i).Value
            seq = dgv1.Item(0, i).Value
            transp = False
            If rowno1 = 0 Then
                tpup = tpupx
            Else
                tpup = IIf(dgv1.Item(7, i).Value = "6", False, True)
            End If

            For j As Integer = 0 To qty
                ar(UBound(ar)) = New Area
                ar(UBound(ar)).length = ln
                ar(UBound(ar)).width = wd
                ar(UBound(ar)).height = ht
                ari(UBound(ari)) = itmnm1
                arwt(UBound(arwt)) = wt
                transparr(UBound(transparr)) = transp
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
            cnt += 1

            ''dgv1.Item(11, i).Value = ""
            'instab("temp1", New Object() {itmnm1, CStr(ln), CStr(wd), CStr(ht), CStr(qty), CStr(wt), CStr(seq), CStr(transp), CStr(tpup)})
        Next i
        'Dim rdr1 As DataRow()
        'rdr1 = getf("temp1", "", "seq ASC")
        'cnt = 0

        'For i As Integer = 1 To rdr1.Length - 1

        '    itmnm1 = rdr1(i)("itmnm")
        '    ln = rdr1(i)("ln")
        '    wd = rdr1(i)("wd")
        '    ht = rdr1(i)("ht")
        '    qty = rdr1(i)("qty")
        '    wt = rdr1(i)("wt")
        '    transp = rdr1(i)("transp")
        '    tpup = rdr1(i)("tpup")
        '    seq = rdr1(i)("seq")
        '    qtylst.Add(qty)

        '    ar1.length = ln
        '    ar1.width = wd
        '    ar1.height = ht
        '    ar1.strtpt.x = 0
        '    ar1.strtpt.y = 0
        '    ar1.strtpt.z = 0
        '    For j As Integer = 0 To qty
        '        ar(UBound(ar)) = New Area
        '        ar(UBound(ar)).length = ar1.length
        '        ar(UBound(ar)).width = ar1.width
        '        ar(UBound(ar)).height = ar1.height
        '        ari(UBound(ari)) = itmnm1
        '        arwt(UBound(arwt)) = wt
        '        transparr(UBound(transparr)) = transp
        '        topup(UBound(topup)) = tpup
        '        colarr.Add(lstcol)
        '        ReDim Preserve ar(UBound(ar) + 1)
        '        ReDim Preserve ari(UBound(ari) + 1)
        '        ReDim Preserve arwt(UBound(arwt) + 1)
        '        ReDim Preserve transparr(UBound(transparr) + 1)
        '        ReDim Preserve topup(UBound(topup) + 1)
        '    Next
        '    ReDim Preserve ar(UBound(ar) - 1)
        '    ReDim Preserve ari(UBound(ari) - 1)
        '    ReDim Preserve arwt(UBound(arwt) - 1)
        '    ReDim Preserve transparr(UBound(transparr) - 1)
        '    ReDim Preserve topup(UBound(topup) - 1)
        '    cnt += 1
        'Next
        stp += 1

        If stp = dgv1.RowCount Then
            stp = 0
            cnt = 0
        End If
        ReDim Preserve ar(UBound(ar) - 1)
        If UBound(ari) > 0 Then
            ReDim Preserve ari(UBound(ari) - 1)
            ReDim Preserve arwt(UBound(arwt) - 1)
            ReDim Preserve transparr(UBound(transparr) - 1)
            ReDim Preserve topup(UBound(topup) - 1)
        End If
        arc.StrtPt.x = 0
        arc.StrtPt.y = 0
        arc.StrtPt.z = 0
        arc.length = contarr(0)
        arc.width = contarr(1)
        arc.height = contarr(2)
        qty = 0
        Dim outfile As String = CurDir() & "\" & "first.wrl"
        If ar.Length > 0 Then
            If stk.Count = 0 Then stk.Add(arc)
            If Not CheckBox1.Checked Then
                stk1 = stuff(arc, ar, ari, arwt, False, False, outfile, False, transparr, topup, txtopt, False, False, True, colarr)
                'Stop
            Else
                stk1 = Stuffx(arc, ar, ari, arwt, True, False, outfile, False, transparr, topup, txtopt, False, False, True, colarr)
                Dim ar3() As Area
                Dim ari3() As String
                Dim arwt3() As Single
                Dim transparr3() As Boolean
                Dim topup1() As Boolean

                ReDim ar3(0)
                ReDim ari3(0)
                ReDim arwt3(0)
                ReDim transparr3(0)
                ReDim topup1(0)
                xcnt = xid
                For ii As Integer = xid To UBound(ar)
                    ar3(UBound(ar3)) = ar(ii)
                    ari3(UBound(ari3)) = ari(ii)
                    arwt3(UBound(arwt3)) = arwt(ii)
                    transparr3(UBound(transparr3)) = transparr(ii)
                    topup1(UBound(topup1)) = True
                    ReDim Preserve ar3(UBound(ar3) + 1)
                    ReDim Preserve ari3(UBound(ari3) + 1)
                    ReDim Preserve arwt3(UBound(arwt3) + 1)
                    ReDim Preserve transparr3(UBound(transparr3) + 1)
                    ReDim Preserve topup1(UBound(topup1) + 1)
                Next
                ReDim Preserve ar3(UBound(ar3) - 1)
                ReDim Preserve ari3(UBound(ari3) - 1)
                ReDim Preserve arwt3(UBound(arwt3) - 1)
                ReDim Preserve transparr3(UBound(transparr3) - 1)
                ReDim Preserve topup1(UBound(topup1) - 1)
                'FileClose(1)
                'off.Close()

                stk.Clear()
                'Dim rwx() As DataRow
                'rwx = getf("temp8", "seq = " & xid, "")
                For iu As Integer = 0 To stksav(xid - 1).Count - 1
                    stk.Add(stksav(xid - 1)(iu))
                Next
                'For iu As Integer = LBound(rwx) To UBound(rwx)
                '    Dim mn1 As New Area
                '    mn1.strtpt.x = rwx(iu)("x")
                '    mn1.strtpt.y = rwx(iu)("y")
                '    mn1.strtpt.z = rwx(iu)("z")
                '    mn1.length = rwx(iu)("l")
                '    mn1.width = rwx(iu)("w")
                '    mn1.height = rwx(iu)("h")
                '    stk.Add(mn1)
                'Next
                Dim ar4() As Area
                ReDim ar4(0)
                For uu As Integer = LBound(ar3) To UBound(ar3)
                    Dim arr1 As New Area
                    Dim arr As Area = ar3(uu)
                    Dim ln4 As Single = arr.length
                    Dim wd4 As Single = arr.width
                    Dim ht4 As Single = arr.height
                    Dim min As String = "l"
                    Dim min1 As Single = ln4
                    If wd4 < min1 Then
                        min1 = wd4
                        min = "w"
                    End If

                    If ht4 < min1 Then
                        min1 = ht4
                        min = "h"
                    End If

                    arr1.StrtPt.x = arr.StrtPt.x
                    arr1.StrtPt.y = arr.StrtPt.y
                    arr1.StrtPt.z = arr.StrtPt.z
                    arr1.height = min1

                    If min = "l" Then

                        arr1.width = arr.width
                        arr1.length = arr.height


                    End If

                    If min = "w" Then
                        arr1.width = arr.height
                        arr1.length = arr.length


                    End If

                    If min = "h" Then
                        arr1.length = arr.length
                        arr1.width = arr.width
                    End If


                    ar4(UBound(ar4)) = arr1
                    ReDim Preserve ar4(UBound(ar4) + 1)


                Next
                ReDim Preserve ar4(UBound(ar4) - 1)
                Stuffx(arc, ar4, ari3, arwt3, True, False, outfile, False, transparr3, topup1, False, False, False, False, colarr)

            End If

            plclst.Clear()
            ReDim ar(0)
            ReDim ari(0)
            ReDim arwt(0)
            ReDim transparr(0)
            ReDim topup(0)

            MessageBox.Show("The manually total entered quantity is '" & itemqty & "' stuffed.", "Maximum quantity progress", MessageBoxButtons.OK)

            'MsgBox(itemqty)

            'Stop

        Else
            If dgv1.RowCount > 1 Then
                If ar.Length <> 0 Then
                    For i As Integer = 0 To dgv1.RowCount - 1
                        For j As Integer = 0 To dgv1.ColumnCount - 1
                            dgv1.Item(j, i).Style.BackColor = Color.White
                        Next
                    Next
                End If
            Else

            End If

        End If
        Dim mm As New Area
        Dim mm1 As New Area

        Dim vol1 As Double = 0
        Dim vol2 As Double = 0
        Dim maxqty As Integer
        Dim arx As New List(Of Area)

        If rowno1 > 0 Then
            mm.length = Math.Round(dgv1.Item(4, rowno1).Value, 4)
            mm.width = Math.Round(dgv1.Item(5, rowno1).Value, 4)
            mm.height = Math.Round(dgv1.Item(6, rowno1).Value, 4)
            tpup = tpupx
        Else
            mm.length = Math.Round(dgv1.Item(4, 0).Value, 4)
            mm.width = Math.Round(dgv1.Item(5, 0).Value, 4)
            mm.height = Math.Round(dgv1.Item(6, 0).Value, 4)
            tpup = tpupx
            qtylst.Add(-1)
        End If
        vol1 = mm.length * mm.height * mm.width
        If vol1 <> 0 Then
            vol2 = 0
            For j As Integer = 0 To stk.Count - 1
                mm1 = stk(j)
                vol2 = vol2 + (mm1.length * mm1.width * mm1.height)
            Next

            maxqty = Fix(vol2 / vol1)
            'maxqty = 500
            'If MsgBox("Approx. Maximum Quantity is: " & maxqty.ToString & vbCrLf & "Do you want to proceed?", MsgBoxStyle.Information + vbYesNo) = MsgBoxResult.No Then
            'Exit Function
            'End If
            ReDim ar(0)
            ReDim ari(0)
            For j As Integer = 0 To maxqty - 1
                ar(UBound(ar)) = New Area
                ar(UBound(ar)).length = mm.length
                ar(UBound(ar)).width = mm.width
                ar(UBound(ar)).height = mm.height
                ari(UBound(ari)) = itmnm1
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

            If Not CheckBox1.Checked Then
                Call stuff(arc, ar, ari, arwt, False, False, "", False, Nothing, topup, False, False, False, True, colarr)
            Else
                Call Stuffx(arc, ar, ari, arwt, True, False, "", False, Nothing, topup, False, False, False, True, colarr)
                If Not fullflag Then
                    Dim ar3() As Area
                    Dim ari3() As String
                    Dim arwt3() As Single
                    Dim transparr3() As Boolean
                    Dim topup1() As Boolean

                    ReDim ar3(0)
                    ReDim ari3(0)
                    ReDim arwt3(0)
                    ReDim transparr3(0)
                    ReDim topup1(0)
                    xcnt = xid
                    For ii As Integer = xid To UBound(ar)
                        ar3(UBound(ar3)) = ar(ii)
                        ari3(UBound(ari3)) = ari(ii)
                        arwt3(UBound(arwt3)) = arwt(ii)
                        transparr3(UBound(transparr3)) = transparr(ii)
                        topup1(UBound(topup1)) = True
                        ReDim Preserve ar3(UBound(ar3) + 1)
                        ReDim Preserve ari3(UBound(ari3) + 1)
                        ReDim Preserve arwt3(UBound(arwt3) + 1)
                        ReDim Preserve transparr3(UBound(transparr3) + 1)
                        ReDim Preserve topup1(UBound(topup1) + 1)
                    Next
                    ReDim Preserve ar3(UBound(ar3) - 1)
                    ReDim Preserve ari3(UBound(ari3) - 1)
                    ReDim Preserve arwt3(UBound(arwt3) - 1)
                    ReDim Preserve transparr3(UBound(transparr3) - 1)
                    ReDim Preserve topup1(UBound(topup1) - 1)
                    'FileClose(1)
                    'off.Close()

                    stk.Clear()
                    'Dim rwx() As DataRow
                    'rwx = getf("temp8", "seq = " & xid, "")
                    For iu As Integer = 0 To stksav(xid - 1).Count - 1
                        stk.Add(stksav(xid - 1)(iu))
                    Next
                    'For iu As Integer = LBound(rwx) To UBound(rwx)
                    '    Dim mn1 As New Area
                    '    mn1.strtpt.x = rwx(iu)("x")
                    '    mn1.strtpt.y = rwx(iu)("y")
                    '    mn1.strtpt.z = rwx(iu)("z")
                    '    mn1.length = rwx(iu)("l")
                    '    mn1.width = rwx(iu)("w")
                    '    mn1.height = rwx(iu)("h")
                    '    stk.Add(mn1)
                    'Next
                    Dim ar4() As Area
                    ReDim ar4(0)
                    For uu As Integer = LBound(ar3) To UBound(ar3)
                        Dim arr1 As New Area
                        Dim arr As Area = ar3(uu)
                        Dim ln4 As Single = arr.length
                        Dim wd4 As Single = arr.width
                        Dim ht4 As Single = arr.height
                        Dim min As String = "l"
                        Dim min1 As Single = ln4
                        If wd4 < min1 Then
                            min1 = wd4
                            min = "w"
                        End If

                        If ht4 < min1 Then
                            min1 = ht4
                            min = "h"
                        End If

                        arr1.StrtPt.x = arr.StrtPt.x
                        arr1.StrtPt.y = arr.StrtPt.y
                        arr1.StrtPt.z = arr.StrtPt.z
                        arr1.height = min1

                        If min = "l" Then

                            arr1.width = arr.width
                            arr1.length = arr.height


                        End If

                        If min = "w" Then
                            arr1.width = arr.height
                            arr1.length = arr.length


                        End If

                        If min = "h" Then
                            arr1.length = arr.length
                            arr1.width = arr.width
                        End If


                        ar4(UBound(ar4)) = arr1
                        ReDim Preserve ar4(UBound(ar4) + 1)


                    Next
                    If chkwt Then
                        xcnt1 = xcnt
                    End If
                    ReDim Preserve ar4(UBound(ar4) - 1)
                    Stuffx(arc, ar4, ari3, arwt3, False, False, outfile, False, transparr3, topup1, False, False, False, False, colarr)
                End If
                'If chkwt Then
                'xcnt = xcnt1
                'End If
            End If

            ReDim ar(0)
            ReDim ari(0)
            ReDim arwt(0)
            ReDim transparr(0)
            ReDim topup(0)
            'Stop
            Try
                If CInt(dgv1.Item(10, dgv1.RowCount - 1).Value) > itemqty Then
                    MsgBox("Requested Quantity " & dgv1.Item(11, dgv1.RowCount - 2).Value & " is greater than maximum quatity")
                    dgv1.Item(11, dgv1.RowCount - 1).Value = itemqty
                End If
            Catch
            End Try

            'If CheckBox1.Checked Then
            'itemqty = xcnt1
            'End If
            If CheckBox1.Checked Then
                If chkwt Then
                    itemqty = xcnt + itemqty
                    'itemqty += 1
                End If
            End If

            dgv1.Item(10, rowno1).Value = itemqty

            Form8.Close()
            itemqty = 0
            stk.Clear()
            stk.Add(arc)
        Else
            'dgv1.AllowUserToAddRows = False
        End If

        stk.Clear()
        stk.Add(arc)
        qtylst.Clear()
        'Stop
        chkwt = True
        Return itemqty

    End Function

    Public Function calcmxqty(ByVal rowno1 As Integer, ByVal tpupx As Boolean)

        Bitemno = 0
        BxItmQty = 0
        chkwt = True
        Dim ar() As Area
        Dim ari() As String
        Dim arwt() As Single
        Dim arSzr() As Area
        Dim ar1 As New Area

        Dim ln As Double
        Dim wd As Double
        Dim ht As Double
        Dim qty As Integer
        Dim seq As Integer
        Dim itmnm1 As String = Nothing
        Dim wt As String = Nothing
        Dim transparr() As Boolean
        Dim transp As Boolean
        Dim topup() As Boolean
        Dim tpup As Boolean
        'Dim rowno As Integer
        ReDim ar(0)
        ReDim ari(0)
        ReDim arwt(0)
        ReDim transparr(0)
        ReDim topup(0)
        ReDim arSzr(0)
        Dim cmd As New OleDb.OleDbCommand
        'Dim rdr As OleDb.OleDbDataReader
        Dim cnt As Integer = 0
        Dim lstcol As New List(Of Byte)
        Button1.Enabled = False
        DelTab("temp1")

        If CmbContainer.Text = "" Then
            MsgBox("Container not selected")
            CmbContainer.Focus()
            Return Bitemqty
            Exit Function
        End If

        For i As Integer = 0 To rowno1 - 1
            If dgv1.Item(11, i).Value Is Nothing OrElse Not IsNumeric(dgv1.Item(11, i).Value) OrElse dgv1.Item(11, i).Value.ToString.Contains(".") OrElse CInt(dgv1.Item(11, i).Value) <= 0 Then
                MsgBox("Invalid quantity at row " & CStr(i + 1))
                Return Bitemqty
                Exit Function
            End If

        Next

        For i As Integer = 0 To rowno1
            itmnm1 = dgv1.Item(1, i).Value
            ln = Math.Round(dgv1.Item(4, i).Value, 4)
            wd = Math.Round(dgv1.Item(5, i).Value, 4)
            ht = Math.Round(dgv1.Item(6, i).Value, 4)
            If i = rowno1 Then
                qty = 0
                dgv1.Item(11, i).Value = ""
            Else
                qty = dgv1.Item(11, i).Value
            End If

            wt = dgv1.Item(8, i).Value
            seq = dgv1.Item(0, i).Value
            transp = False
            If rowno1 = 0 Then
                tpup = tpupx
            Else
                tpup = IIf(dgv1.Item(7, i).Value = "6", False, True)
            End If

            For j As Integer = 0 To qty
                ar(UBound(ar)) = New Area
                ar(UBound(ar)).length = ln
                ar(UBound(ar)).width = wd
                ar(UBound(ar)).height = ht
                ari(UBound(ari)) = itmnm1
                arwt(UBound(arwt)) = wt
                transparr(UBound(transparr)) = transp
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
            cnt += 1

        Next i

        stpBox += 1

        If stpBox = dgv1.RowCount Then
            stpBox = 0
            cnt = 0
        End If
        ReDim Preserve ar(UBound(ar) - 1)

        If UBound(ari) > 0 Then
            ReDim Preserve ari(UBound(ari) - 1)
            ReDim Preserve arwt(UBound(arwt) - 1)
            ReDim Preserve transparr(UBound(transparr) - 1)
            ReDim Preserve topup(UBound(topup) - 1)
        End If

        '*****
        'Stop
        '*****
        arc.StrtPt.x = 0
        arc.StrtPt.y = 0
        arc.StrtPt.z = 0
        arc.length = contarr(0)
        arc.width = contarr(1)
        arc.height = contarr(2)
        qty = 0

        Try

            If szFlg Then

                arc.length = Math.Round(szFact * arc.length, 2)
                arc.width = Math.Round(szFact * arc.width, 2)
                arc.height = Math.Round(szFact * arc.height, 2)

                arc.StrtPt.x = 0
                arc.StrtPt.y = 0
                arc.StrtPt.z = 0

                For kk As Integer = 0 To ar.Length - 1

                    arSzr(UBound(arSzr)) = New Area
                    arSzr(UBound(arSzr)).length = Math.Round(ar(kk).length * szFact, 2)
                    arSzr(UBound(arSzr)).width = Math.Round(ar(kk).width * szFact, 2)
                    arSzr(UBound(arSzr)).height = Math.Round(ar(kk).height * szFact, 2)

                    arSzr(UBound(arSzr)).StrtPt.x = Math.Round(ar(kk).StrtPt.x * szFact, 2)
                    arSzr(UBound(arSzr)).StrtPt.y = Math.Round(ar(kk).StrtPt.y * szFact, 2)
                    arSzr(UBound(arSzr)).StrtPt.z = Math.Round(ar(kk).StrtPt.z * szFact, 2)

                    ReDim Preserve arSzr(UBound(arSzr) + 1)

                Next kk

                ReDim Preserve arSzr(UBound(arSzr) - 1)

            End If

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in Maximum quantity calculation size factor manipulation change.")
        End Try

        'Stop

        Dim outfile As String = CurDir() & "\" & "first.wrl"

        If ar.Length > 0 Then
            If stk.Count = 0 Then stk.Add(arc)
            If Not CheckBox1.Checked Then

                If szFlg Then
                    stk1 = stuff(arc, arSzr, ari, arwt, False, False, outfile, False, transparr, topup, Btxtopt, False, False, True, colarr)
                Else
                    stk1 = stuff(arc, ar, ari, arwt, False, False, outfile, False, transparr, topup, Btxtopt, False, False, True, colarr)
                    'stk1 = stuffQtyMx(arc, ar, ari, arwt, False, False, outfile, False, transparr, topup, Btxtopt, False, False, True, colarr)
                End If

            Else
                stk1 = Stuffx(arc, ar, ari, arwt, True, False, outfile, False, transparr, topup, Btxtopt, False, False, True, colarr)
                Dim ar3() As Area
                Dim ari3() As String
                Dim arwt3() As Single
                Dim transparr3() As Boolean
                Dim topup1() As Boolean

                ReDim ar3(0)
                ReDim ari3(0)
                ReDim arwt3(0)
                ReDim transparr3(0)
                ReDim topup1(0)
                xcnt = xid
                For ii As Integer = xid To UBound(ar)
                    ar3(UBound(ar3)) = ar(ii)
                    ari3(UBound(ari3)) = ari(ii)
                    arwt3(UBound(arwt3)) = arwt(ii)
                    transparr3(UBound(transparr3)) = transparr(ii)
                    topup1(UBound(topup1)) = True
                    ReDim Preserve ar3(UBound(ar3) + 1)
                    ReDim Preserve ari3(UBound(ari3) + 1)
                    ReDim Preserve arwt3(UBound(arwt3) + 1)
                    ReDim Preserve transparr3(UBound(transparr3) + 1)
                    ReDim Preserve topup1(UBound(topup1) + 1)
                Next
                ReDim Preserve ar3(UBound(ar3) - 1)
                ReDim Preserve ari3(UBound(ari3) - 1)
                ReDim Preserve arwt3(UBound(arwt3) - 1)
                ReDim Preserve transparr3(UBound(transparr3) - 1)
                ReDim Preserve topup1(UBound(topup1) - 1)
                'FileClose(1)
                'off.Close()

                stk.Clear()
                'Dim rwx() As DataRow
                'rwx = getf("temp8", "seq = " & xid, "")
                For iu As Integer = 0 To stksav(xid - 1).Count - 1
                    stk.Add(stksav(xid - 1)(iu))
                Next
                'For iu As Integer = LBound(rwx) To UBound(rwx)
                '    Dim mn1 As New Area
                '    mn1.strtpt.x = rwx(iu)("x")
                '    mn1.strtpt.y = rwx(iu)("y")
                '    mn1.strtpt.z = rwx(iu)("z")
                '    mn1.length = rwx(iu)("l")
                '    mn1.width = rwx(iu)("w")
                '    mn1.height = rwx(iu)("h")
                '    stk.Add(mn1)
                'Next
                Dim ar4() As Area
                ReDim ar4(0)
                For uu As Integer = LBound(ar3) To UBound(ar3)
                    Dim arr1 As New Area
                    Dim arr As Area = ar3(uu)
                    Dim ln4 As Single = arr.length
                    Dim wd4 As Single = arr.width
                    Dim ht4 As Single = arr.height
                    Dim min As String = "l"
                    Dim min1 As Single = ln4
                    If wd4 < min1 Then
                        min1 = wd4
                        min = "w"
                    End If

                    If ht4 < min1 Then
                        min1 = ht4
                        min = "h"
                    End If

                    arr1.StrtPt.x = arr.StrtPt.x
                    arr1.StrtPt.y = arr.StrtPt.y
                    arr1.StrtPt.z = arr.StrtPt.z
                    arr1.height = min1

                    If min = "l" Then

                        arr1.width = arr.width
                        arr1.length = arr.height


                    End If

                    If min = "w" Then
                        arr1.width = arr.height
                        arr1.length = arr.length


                    End If

                    If min = "h" Then
                        arr1.length = arr.length
                        arr1.width = arr.width
                    End If


                    ar4(UBound(ar4)) = arr1
                    ReDim Preserve ar4(UBound(ar4) + 1)


                Next
                ReDim Preserve ar4(UBound(ar4) - 1)
                Stuffx(arc, ar4, ari3, arwt3, True, False, outfile, False, transparr3, topup1, False, False, False, False, colarr)

            End If

            Bplclst.Clear()
            ReDim ar(0)
            ReDim ari(0)
            ReDim arwt(0)
            ReDim transparr(0)
            ReDim topup(0)
            'MsgBox(Bitemqty)
            'MsgBox(itemqty)
            MessageBox.Show("The manually total entered quantity is '" & itemqty & "' stuffed.", "Maximum quantity progress", MessageBoxButtons.OK)

            'Stop

        Else
            If dgv1.RowCount > 1 Then
                If ar.Length <> 0 Then
                    For i As Integer = 0 To dgv1.RowCount - 1
                        For j As Integer = 0 To dgv1.ColumnCount - 1
                            dgv1.Item(j, i).Style.BackColor = Color.White
                        Next
                    Next
                End If
            Else

            End If

        End If
        Dim mm As New Area
        Dim mm1 As New Area

        Dim vol1 As Double = 0
        Dim vol2 As Double = 0
        Dim maxqty As Int64                                         'Dim maxqty As Integer
        Dim arx As New List(Of Area)

        If rowno1 > 0 Then
            mm.length = Math.Round(dgv1.Item(4, rowno1).Value, 4)
            mm.width = Math.Round(dgv1.Item(5, rowno1).Value, 4)
            mm.height = Math.Round(dgv1.Item(6, rowno1).Value, 4)
            tpup = tpupx
        Else
            mm.length = Math.Round(dgv1.Item(4, 0).Value, 4)
            mm.width = Math.Round(dgv1.Item(5, 0).Value, 4)
            mm.height = Math.Round(dgv1.Item(6, 0).Value, 4)
            tpup = tpupx
            Bqtylst.Add(-1)
        End If

        'Stop

        If szFlg Then

            mm.length = szFact * mm.length
            mm.width = szFact * mm.width
            mm.height = szFact * mm.height

            mm.StrtPt.x = 0
            mm.StrtPt.y = 0
            mm.StrtPt.z = 0

            mm1.length = szFact * mm1.length
            mm1.width = szFact * mm1.width
            mm1.height = szFact * mm1.height

            mm1.StrtPt.x = 0
            mm1.StrtPt.y = 0
            mm1.StrtPt.z = 0

        End If

        vol1 = mm.length * mm.height * mm.width

        If vol1 <> 0 Then
            vol2 = 0
            For j As Integer = 0 To stk.Count - 1
                mm1 = stk(j)

                If szFlg Then

                    mm1.length = mm1.length * szFact
                    mm1.width = mm1.width * szFact
                    mm1.height = mm1.height * szFact

                    mm1.StrtPt.x = 0
                    mm1.StrtPt.y = 0
                    mm1.StrtPt.z = 0

                End If

                vol2 = vol2 + (mm1.length * mm1.width * mm1.height)
            Next

            maxqty = Fix(vol2 / vol1)
            'If MsgBox("Approx. Maximum Quantity is: " & maxqty.ToString & vbCrLf & "Do you want to proceed?", MsgBoxStyle.Information + vbYesNo) = MsgBoxResult.No Then
            'Exit Function
            'End If
            ReDim ar(0)
            ReDim ari(0)

            ' Stop

            'Try

            '    Dim st() As Integer

            '    For jk As Int64 = 0 To maxqty - 1

            '        ReDim Preserve st(jk)

            '        st(jk) = jk

            '        If jk = 100009 Then

            '            Stop

            '            Exit For

            '        End If

            '    Next

            '    Stop

            'Catch Er As Exception
            '    MsgBox(Er.Message)
            '    MsgBox(Er.ToString)
            'End Try

            'Stop

            For j As Int64 = 0 To maxqty - 1                    'For j As Integer = 0 To maxqty - 1
                ar(UBound(ar)) = New Area
                ar(UBound(ar)).length = mm.length
                ar(UBound(ar)).width = mm.width
                ar(UBound(ar)).height = mm.height
                ari(UBound(ari)) = itmnm1
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

            'Stop

            ReDim Preserve ar(UBound(ar) - 1)
            ReDim Preserve ari(UBound(ari) - 1)
            ReDim Preserve arwt(UBound(arwt) - 1)
            ReDim Preserve transparr(UBound(transparr) - 1)
            ReDim Preserve topup(UBound(topup) - 1)


            If Not CheckBox1.Checked Then
                Call stuff(arc, ar, ari, arwt, False, False, "", False, Nothing, topup, False, False, False, True, colarr)
            Else
                Call Stuffx(arc, ar, ari, arwt, True, False, "", False, Nothing, topup, False, False, False, True, colarr)
                If Not fullflag Then
                    Dim ar3() As Area
                    Dim ari3() As String
                    Dim arwt3() As Single
                    Dim transparr3() As Boolean
                    Dim topup1() As Boolean

                    ReDim ar3(0)
                    ReDim ari3(0)
                    ReDim arwt3(0)
                    ReDim transparr3(0)
                    ReDim topup1(0)
                    xcnt = xid
                    For ii As Integer = xid To UBound(ar)
                        ar3(UBound(ar3)) = ar(ii)
                        ari3(UBound(ari3)) = ari(ii)
                        arwt3(UBound(arwt3)) = arwt(ii)
                        transparr3(UBound(transparr3)) = transparr(ii)
                        topup1(UBound(topup1)) = True
                        ReDim Preserve ar3(UBound(ar3) + 1)
                        ReDim Preserve ari3(UBound(ari3) + 1)
                        ReDim Preserve arwt3(UBound(arwt3) + 1)
                        ReDim Preserve transparr3(UBound(transparr3) + 1)
                        ReDim Preserve topup1(UBound(topup1) + 1)
                    Next
                    ReDim Preserve ar3(UBound(ar3) - 1)
                    ReDim Preserve ari3(UBound(ari3) - 1)
                    ReDim Preserve arwt3(UBound(arwt3) - 1)
                    ReDim Preserve transparr3(UBound(transparr3) - 1)
                    ReDim Preserve topup1(UBound(topup1) - 1)
                    'FileClose(1)
                    'off.Close()

                    stk.Clear()
                    'Dim rwx() As DataRow
                    'rwx = getf("temp8", "seq = " & xid, "")
                    For iu As Integer = 0 To stksav(xid - 1).Count - 1
                        stk.Add(stksav(xid - 1)(iu))
                    Next
                    'For iu As Integer = LBound(rwx) To UBound(rwx)
                    '    Dim mn1 As New Area
                    '    mn1.strtpt.x = rwx(iu)("x")
                    '    mn1.strtpt.y = rwx(iu)("y")
                    '    mn1.strtpt.z = rwx(iu)("z")
                    '    mn1.length = rwx(iu)("l")
                    '    mn1.width = rwx(iu)("w")
                    '    mn1.height = rwx(iu)("h")
                    '    stk.Add(mn1)
                    'Next
                    Dim ar4() As Area
                    ReDim ar4(0)
                    For uu As Integer = LBound(ar3) To UBound(ar3)
                        Dim arr1 As New Area
                        Dim arr As Area = ar3(uu)
                        Dim ln4 As Single = arr.length
                        Dim wd4 As Single = arr.width
                        Dim ht4 As Single = arr.height
                        Dim min As String = "l"
                        Dim min1 As Single = ln4
                        If wd4 < min1 Then
                            min1 = wd4
                            min = "w"
                        End If

                        If ht4 < min1 Then
                            min1 = ht4
                            min = "h"
                        End If

                        arr1.StrtPt.x = arr.StrtPt.x
                        arr1.StrtPt.y = arr.StrtPt.y
                        arr1.StrtPt.z = arr.StrtPt.z
                        arr1.height = min1

                        If min = "l" Then

                            arr1.width = arr.width
                            arr1.length = arr.height


                        End If

                        If min = "w" Then
                            arr1.width = arr.height
                            arr1.length = arr.length


                        End If

                        If min = "h" Then
                            arr1.length = arr.length
                            arr1.width = arr.width
                        End If


                        ar4(UBound(ar4)) = arr1
                        ReDim Preserve ar4(UBound(ar4) + 1)


                    Next
                    If chkwt Then
                        xcnt1 = xcnt
                    End If
                    ReDim Preserve ar4(UBound(ar4) - 1)
                    Stuffx(arc, ar4, ari3, arwt3, False, False, outfile, False, transparr3, topup1, False, False, False, False, colarr)
                End If
                'If chkwt Then
                'xcnt = xcnt1
                'End If
            End If

            ReDim ar(0)
            ReDim ari(0)
            ReDim arwt(0)
            ReDim transparr(0)
            ReDim topup(0)
            'Stop
            If CInt(dgv1.Item(10, dgv1.RowCount - 1).Value) > Bitemqty Then
                MsgBox("Requested Quantity " & dgv1.Item(11, dgv1.RowCount - 2).Value & " is greater than maximum quatity")
                dgv1.Item(11, dgv1.RowCount - 1).Value = Bitemqty
            End If
            'If CheckBox1.Checked Then
            'itemqty = xcnt1
            'End If
            If CheckBox1.Checked Then
                If chkwt Then
                    Bitemqty = xcnt + Bitemqty
                    'itemqty += 1
                End If
            End If
            dgv1.Item(10, rowno1).Value = BxItmQty         'dgv1.Item(10, rowno1).Value = Bitemqty
            dgv1.Item(10, rowno1).Value = itemqty
            Form8.Close()
            Bitemqty = 0
            stk.Clear()
            stk.Add(arc)
        Else
            'dgv1.AllowUserToAddRows = False
        End If

        Try

            dgv1.Item(10, rowno1).Value = BxItmQty            'dgv1.Item(10, rowno1).Value = Bitemqty
            dgv1.Item(10, rowno1).Value = itemqty

        Catch
        End Try

        stk.Clear()
        stk.Add(arc)
        Bqtylst.Clear()
        'Stop
        chkwt = True
        'Return Bitemqty
        Return itemqty

    End Function

#End Region

#Region "Routine Definitions"

    Private Sub tsbtnHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnHelp.Click

        Try
            btnArngmtAct.Enabled = True
            dgv1.Cursor = Cursors.Default
            flgDGV1 = False
            btnArngmtAct.Text = "&Sort arrangement"

            btnSrN.Enabled = False
            btnNm.Enabled = False
            btnCartonLabel.Text = "&Lablel generation"
            ADclFlg = False

            Process.Start(CurDir() & "\HelpContainerStuff\Carton Master.chm")

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in tsbtnHelp_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tslblHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tslblHelp.Click

        Try
            btnArngmtAct.Enabled = True
            dgv1.Cursor = Cursors.Default
            flgDGV1 = False
            btnArngmtAct.Text = "&Sort arrangement"

            btnSrN.Enabled = False
            btnNm.Enabled = False
            btnCartonLabel.Text = "&Lablel generation"
            ADclFlg = False

            Process.Start(CurDir() & "\HelpContainerStuff\Carton Master.chm")

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in tslblHelp_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tslblNm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tslblNm.Click

        'tsCSPNavMaster.Visible = True
        'tsCSPNav.Visible = False

    End Sub

    Private Sub tslblNMms_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tslblNMms.Click

        'tsCSPNavMaster.Visible = False
        'tsCSPNav.Visible = True

    End Sub

    Private Sub tsbtnBoxTypemaster_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnBoxTypemaster.Click

        Try
            Me.Focus()
            GC.Collect()

            Try
                'DisplayActivity.lblDisplayActivity.Visible = True
                'DisplayActivity.lblDisplayActivity.Text = "Please wait..." & vbCrLf & "Box Container master activity show"

                'DisplayActivity.Show()
                'Me.Dispose(True)

            Catch ex As Exception
                Exit Try
            Finally

                Try
                    ContainerMaster.Show()
                    ContainerMaster.WindowState = FormWindowState.Normal
                Catch Ex As Exception
                    MessageBox.Show("Fatal error in tsbtnBoxTypemaster", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    MsgBox(Ex.Message)
                    MsgBox(Ex.ToString)
                    Application.Exit()
                End Try

            End Try

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in tsbtnBoxTypemaster_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbtnBoxTypeCartonMaster_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnBoxTypeCartonMaster.Click

        Try

            Me.Focus()
            GC.Collect()

            Try
                'DisplayActivity.lblDisplayActivity.Visible = True
                'DisplayActivity.lblDisplayActivity.Text = "Please wait..." & vbCrLf & "Box type item entry activity show"

                'DisplayActivity.Show()
                'Me.Dispose(True)
            Catch ex As Exception
                Exit Try
            Finally

                Try
                    MasterCartonEntry.Show()
                    MasterCartonEntry.WindowState = FormWindowState.Normal
                Catch Ex As Exception
                    MsgBox(Ex.Message)
                    MsgBox(Ex.ToString)
                    MessageBox.Show("Fatal error in tsbtnBoxTypeCartonMaster", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Application.Exit()
                End Try
            End Try

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in tsbtnBoxTypeCartonMaster_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbtnBoxDrumMaster_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnBoxDrumMaster.Click

        MessageBox.Show(" Work in progress ", "Info.....", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub tsbtnOtherTypeMaster_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnOtherTypeMaster.Click

        MessageBox.Show(" Work in progress ", "Info.....", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub tsbtnSettingsMasters_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnSettingsMasters.Click

        Try
            ActivitySettings.Show()
            ActivitySettings.Focus()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in tsbtnSettingsMasters_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbtnRestartMaster_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnRestartMaster.Click

        Try

            MDIForm.Focus()
            GC.Collect()

            Try

                'DisplayActivity.lblDisplayActivity.Visible = True
                'DisplayActivity.lblDisplayActivity.Text = "Please wait..." & Chr(13) & "The container stuffing application is restarting"
                'DisplayActivity.Show()
                'Me.Dispose(True)

            Catch Ex As Exception
                Exit Try
            Finally

                Me.Dispose(True)
                Me.Close()
                GC.Collect()
                Application.Exit()

                Try

                    Process.Start(CurDir() & "\Container Stuff.exe")

                Catch Ex As Exception
                    MsgBox(Ex.Message)
                    MsgBox(Ex.ToString)
                    MessageBox.Show("Error in tsbtnRestartMaster_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Try

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in tsbtnRestartMaster_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnArngmtAct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArngmtAct.Click

        Try

            BoxStatusStriplbl.Text = "Sort arrangement switch is on, allowing sorting of data."
            'btnArngmtAct.Enabled = False

            If Not flgDGV1 Then

                btnArngmtAct.Text = "&Sort arrangement on"

                flgDGV1 = True
            Else
                btnArngmtAct.Text = "&Sort arrangement off"

                flgDGV1 = False

            End If

            dgv1.Cursor = Cursors.Hand

            DbTrackDel()

            InsrtDgvDb()

            editenable()
            CmbContainer.Enabled = True
            DtReceipt.Enabled = True
            Str = "Edit"
            BFlag = True

        Catch Err As Exception
            Cons.Close()
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in btnArngmtAct_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cons.Close()
        End Try

    End Sub

    Private Sub btnQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Try

            ADsFlg = False
            btnArngmtAct.Enabled = True
            BoxStatusStriplbl.Text = "Pick the activity"

            cmdExit_Click(sender, e)

        Catch ex As Exception
            Cons.Close()
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in btnQuit_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cons.Close()
        End Try

    End Sub

    Private Sub btnQuit2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Try

            ADsFlg = False
            btnArngmtAct.Enabled = True
            BoxStatusStriplbl.Text = "Pick the activity"

            cmdExit_Click(sender, e)

        Catch Err As Exception
            Cons.Close()
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in btnQuit2_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cons.Close()
        End Try

    End Sub

    Private Sub btnQuit1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Try

            ADsFlg = False
            btnArngmtAct.Enabled = True
            BoxStatusStriplbl.Text = "Pick the activity"

            cmdExit_Click(sender, e)

        Catch Err As Exception
            Cons.Close()
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in btnQuit1_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cons.Close()
        End Try

    End Sub

    Private Sub btnCartonLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCartonLabel.Click

        Try

            btnSrN.Text = "&SrNo off"

            If Not ADclFlg Then

                Me.dgv1.Columns(15).Visible = True
                Me.dgv1.Columns(13).Visible = False

                btnSrN.Enabled = True
                btnNm.Enabled = True
                btnCartonLabel.Text = "&Lablel generation on"
                ADclFlg = True

            Else
                Me.dgv1.Columns(15).Visible = False
                Me.dgv1.Columns(13).Visible = True

                btnSrN.Enabled = False
                btnNm.Enabled = False
                btnCartonLabel.Text = "&Lablel generation off"
                ADclFlg = False
                SrNFlg = False
            End If

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in btnCartonLabel_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub Dgv1OrientSrt(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim Flg As Boolean = False

        Dim Dgn As Integer = 0
        Dim SrN As Int32 = 0
        Dim INm As String = Nothing
        Dim Pck As String = Nothing
        Dim Sz As Double = 0
        Dim L As Double = 0
        Dim W As Double = 0
        Dim H As Double = 0
        Dim Orint As Int16 = 0
        Dim Ori As String = Nothing
        Dim Wt As Double = 0
        Dim MxQty As Int32 = 0
        Dim UQty As Int32 = 0

        'Stop

        Try
            If Not AoFlg Then
                DbTrackerDupDel()
            Else
                Flg = True
            End If

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in Dgv1OrientSrt", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Try

            If Cons.State = ConnectionState.Closed Then Cons.Open()
            Dim Cmdo As New OleDb.OleDbCommand
            Dim Rdro As OleDb.OleDbDataReader
            Cmdo.Connection = Cons

            If Not AoFlg Then
                Cmdo.CommandText = "select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA"
                AoFlg = True
            Else
                Cmdo.CommandText = "select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaADpt"
                AoFlg = False
            End If

            Rdro = Cmdo.ExecuteReader

            Do While (Rdro.Read())

                SrN = Rdro("SrNo")
                INm = Rdro("ItmName")
                Pck = Rdro("Pack")
                Sz = Rdro("Sizes")
                L = Rdro("Length")
                W = Rdro("Width")
                H = Rdro("Height")
                Orint = Rdro("Orient")
                Wt = Rdro("Wt")
                MxQty = Rdro("MaxQty")
                UQty = Rdro("Qty")

                If DbDll.DgvDbOrientFlg(Orint) Then
                    Orint = 2
                    Ori = "2"
                    BoxStatusStriplbl.Text = "Way of orientation change from 6 to 2"
                Else
                    Orint = 6
                    Ori = "6"
                    BoxStatusStriplbl.Text = "Way of orientation change from 2 to 6"
                End If

                dgv1.Item(0, Dgn).Value = SN
                dgv1.Item(1, Dgn).Value = INm
                dgv1.Item(2, Dgn).Value = Pck
                dgv1.Item(3, Dgn).Value = Sz
                dgv1.Item(4, Dgn).Value = L
                dgv1.Item(5, Dgn).Value = W
                dgv1.Item(6, Dgn).Value = H
                dgv1.Item(7, Dgn).Value = Ori
                dgv1.Item(8, Dgn).Value = Wt
                dgv1.Item(10, Dgn).Value = MxQty
                dgv1.Item(11, Dgn).Value = UQty


                If Not Flg Then

                    DbTrackDupIns(SN, INm, Pck, Sz, L, W, H, Orint, Wt, MxQty, UQty)

                End If

                SN = SN + 1
                Dgn = Dgn + 1

            Loop

        Catch Er As Exception
            Cons.Close()
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in Dgv1OrientSrt", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cons.Close()
        End Try

    End Sub

    Public Sub snDgv1OrientSrt(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim Flg As Boolean = False

        Dim Dgn As Integer = 0
        Dim SrN As Int32 = 0
        Dim INm As String = Nothing
        Dim Pck As String = Nothing
        Dim Sz As Double = 0
        Dim L As Double = 0
        Dim W As Double = 0
        Dim H As Double = 0
        Dim Orint As Int16 = 0
        Dim Ori As String = Nothing
        Dim Wt As Double = 0
        Dim MxQty As Int32 = 0
        Dim UQty As Int32 = 0

        'Stop

        Try
            If Not AoFlg Then
                DbTrackerDupDel()
            Else
                Flg = True
            End If

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in snDgv1OrientSrt", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Try

            If Cons.State = ConnectionState.Closed Then Cons.Open()
            Dim Cmdo As New OleDb.OleDbCommand
            Dim Rdro As OleDb.OleDbDataReader
            Cmdo.Connection = Cons

            If Not AoFlg Then
                Cmdo.CommandText = "select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA"
                AoFlg = True
            Else
                Cmdo.CommandText = "select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaADpt"
                AoFlg = False
            End If

            Rdro = Cmdo.ExecuteReader

            Do While (Rdro.Read())

                SrN = Rdro("SrNo")
                INm = Rdro("ItmName")
                Pck = Rdro("Pack")
                Sz = Rdro("Sizes")
                L = Rdro("Length")
                W = Rdro("Width")
                H = Rdro("Height")
                Orint = Rdro("Orient")
                Wt = Rdro("Wt")
                MxQty = Rdro("MaxQty")
                UQty = Rdro("Qty")

                If DbDll.DgvDbOrientFlg(Orint) Then
                    Orint = 2
                    Ori = "2"
                    BoxStatusStriplbl.Text = "Way of orientation change from 6 to 2"
                Else
                    Orint = 6
                    Ori = "6"
                    BoxStatusStriplbl.Text = "Way of orientation change from 2 to 6"
                End If

                dgv1.Item(0, Dgn).Value = SrN
                dgv1.Item(1, Dgn).Value = INm
                dgv1.Item(2, Dgn).Value = Pck
                dgv1.Item(3, Dgn).Value = Sz
                dgv1.Item(4, Dgn).Value = L
                dgv1.Item(5, Dgn).Value = W
                dgv1.Item(6, Dgn).Value = H
                dgv1.Item(7, Dgn).Value = Ori
                dgv1.Item(8, Dgn).Value = Wt
                dgv1.Item(10, Dgn).Value = MxQty
                dgv1.Item(11, Dgn).Value = UQty


                If Not Flg Then

                    DbTrackDupIns(SN, INm, Pck, Sz, L, W, H, Orint, Wt, MxQty, UQty)

                End If

                SN = SN + 1
                Dgn = Dgn + 1

            Loop

        Catch Er As Exception
            Cons.Close()
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in snDgv1OrientSrt", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cons.Close()
        End Try

    End Sub

    Public Sub Dgv1WeightSrt(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'Stop
        Try
            Dim SN As Integer = 1
            Dim Dgn As Integer = 0
            Dim SrN As Int32 = 0
            Dim INm As String = Nothing
            Dim Pck As String = Nothing
            Dim Sz As Double = 0
            Dim L As Double = 0
            Dim W As Double = 0
            Dim H As Double = 0
            Dim Orint As Int16 = 0
            Dim Wt As Double = 0
            Dim MxQty As Int32 = 0
            Dim UQty As Int32 = 0

            Try
                DbTrackerDupDel()

            Catch Er As Exception
                MsgBox(Er.Message)
                MsgBox(Er.ToString)
                MessageBox.Show("Error in Dgv1WeightSrt", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            If Cons.State = ConnectionState.Closed Then Cons.Open()
            Dim CmdW As New OleDb.OleDbCommand
            Dim RdrW As OleDb.OleDbDataReader
            CmdW.Connection = Cons

            If ADflg Then
                CmdW.CommandText = "select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA order by Wt asc"
                ADflg = False
                BoxStatusStriplbl.Text = "Data arranged by minimum to maximum weight"
            Else
                CmdW.CommandText = "select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA order by Wt desc"
                ADflg = True
                BoxStatusStriplbl.Text = "Data arranged by maximum to minimum weight"
            End If

            RdrW = CmdW.ExecuteReader

            Do While (RdrW.Read())

                SrN = RdrW("SrNo")
                INm = RdrW("ItmName")
                Pck = RdrW("Pack")
                Sz = RdrW("Sizes")
                L = RdrW("Length")
                W = RdrW("Width")
                H = RdrW("Height")
                Orint = RdrW("Orient")
                Wt = RdrW("Wt")
                MxQty = RdrW("MaxQty")
                UQty = RdrW("Qty")

                dgv1.Item(0, Dgn).Value = SN
                dgv1.Item(1, Dgn).Value = INm
                dgv1.Item(2, Dgn).Value = Pck
                dgv1.Item(3, Dgn).Value = Sz
                dgv1.Item(4, Dgn).Value = L
                dgv1.Item(5, Dgn).Value = W
                dgv1.Item(6, Dgn).Value = H
                dgv1.Item(7, Dgn).Value = Orint
                dgv1.Item(8, Dgn).Value = Wt
                dgv1.Item(10, Dgn).Value = MxQty
                dgv1.Item(11, Dgn).Value = UQty

                DbTrackDupIns(SN, INm, Pck, Sz, L, W, H, Orint, Wt, MxQty, UQty)

                SN = SN + 1
                Dgn = Dgn + 1

            Loop

        Catch Err As Exception
            Cons.Close()
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in Dgv1WeightSrt", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cons.Close()
        End Try

    End Sub

    Public Sub snDgv1WeightSrt(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'Stop
        Try
            Dim Dgn As Integer = 0
            Dim SrN As Int32 = 0
            Dim INm As String = Nothing
            Dim Pck As String = Nothing
            Dim Sz As Double = 0
            Dim L As Double = 0
            Dim W As Double = 0
            Dim H As Double = 0
            Dim Orint As Int16 = 0
            Dim Wt As Double = 0
            Dim MxQty As Int32 = 0
            Dim UQty As Int32 = 0

            Try
                DbTrackerDupDel()

            Catch Er As Exception
                MsgBox(Er.Message)
                MsgBox(Er.ToString)
                MessageBox.Show("Error in snDgv1WeightSrt", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            If Cons.State = ConnectionState.Closed Then Cons.Open()
            Dim CmdW As New OleDb.OleDbCommand
            Dim RdrW As OleDb.OleDbDataReader
            CmdW.Connection = Cons

            If ADflg Then
                CmdW.CommandText = "select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA order by Wt asc"
                ADflg = False
                BoxStatusStriplbl.Text = "Data arranged by minimum to maximum weight"
            Else
                CmdW.CommandText = "select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA order by Wt desc"
                ADflg = True
                BoxStatusStriplbl.Text = "Data arranged by maximum to minimum weight"
            End If

            RdrW = CmdW.ExecuteReader

            Do While (RdrW.Read())

                SrN = RdrW("SrNo")
                INm = RdrW("ItmName")
                Pck = RdrW("Pack")
                Sz = RdrW("Sizes")
                L = RdrW("Length")
                W = RdrW("Width")
                H = RdrW("Height")
                Orint = RdrW("Orient")
                Wt = RdrW("Wt")
                MxQty = RdrW("MaxQty")
                UQty = RdrW("Qty")

                dgv1.Item(0, Dgn).Value = SrN
                dgv1.Item(1, Dgn).Value = INm
                dgv1.Item(2, Dgn).Value = Pck
                dgv1.Item(3, Dgn).Value = Sz
                dgv1.Item(4, Dgn).Value = L
                dgv1.Item(5, Dgn).Value = W
                dgv1.Item(6, Dgn).Value = H
                dgv1.Item(7, Dgn).Value = Orint
                dgv1.Item(8, Dgn).Value = Wt
                dgv1.Item(10, Dgn).Value = MxQty
                dgv1.Item(11, Dgn).Value = UQty

                DbTrackDupIns(SN, INm, Pck, Sz, L, W, H, Orint, Wt, MxQty, UQty)

                SN = SN + 1
                Dgn = Dgn + 1

            Loop

        Catch Err As Exception
            Cons.Close()
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in snDgv1WeightSrt", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cons.Close()
        End Try

    End Sub

    Private Sub btnQuit5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Try
            ADsFlg = False
            btnArngmtAct.Enabled = True
            BoxStatusStriplbl.Text = "Pick the activity"

            cmdExit_Click(sender, e)

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in btnQuit5_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cons.Close()
        End Try

    End Sub

    Public Sub Dgv1SizeSrt(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'Stop
        Try

            If Not ADsFlg Then

                DbTrackerPerimDel()
                DbTrackerPerimIns()
                ADsFlg = True
            End If

            Dim SN As Integer = 1
            Dim Dgn As Integer = 0
            Dim SrN As Int32 = 0
            Dim INm As String = Nothing
            Dim Pck As String = Nothing
            Dim Sz As Double = 0
            Dim L As Double = 0
            Dim W As Double = 0
            Dim H As Double = 0
            Dim Orint As Int16 = 0
            Dim Wt As Double = 0
            Dim MxQty As Int32 = 0
            Dim UQty As Int32 = 0
            Dim Perim As Double = 0

            If Cons.State = ConnectionState.Closed Then Cons.Open()
            Dim Cmd As New OleDb.OleDbCommand
            Dim Rdr As OleDb.OleDbDataReader
            Cmd.Connection = Cons

            If Not ADmsFlg Then
                Cmd.CommandText = "select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty, Perim from BoxAPerim order by Perim desc"
                ADmsFlg = True
                BoxStatusStriplbl.Text = "Data arranged by maximum to minimum dimensions"
            Else
                Cmd.CommandText = "select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty, Perim from BoxAPerim order by Perim asc"
                ADmsFlg = False
                BoxStatusStriplbl.Text = "Data arranged by minimum to maximum dimensions"
            End If

            Rdr = Cmd.ExecuteReader

            Do While (Rdr.Read)

                SrN = Rdr("SrNo")
                INm = Rdr("ItmName")
                Pck = Rdr("Pack")
                Sz = Rdr("Sizes")
                L = Rdr("Length")
                W = Rdr("Width")
                H = Rdr("Height")
                Orint = Rdr("Orient")
                Wt = Rdr("Wt")
                MxQty = Rdr("MaxQty")
                UQty = Rdr("Qty")
                Perim = Rdr("Perim")

                dgv1.Item(0, Dgn).Value = SN
                dgv1.Item(1, Dgn).Value = INm
                dgv1.Item(2, Dgn).Value = Pck
                dgv1.Item(3, Dgn).Value = Sz
                dgv1.Item(4, Dgn).Value = L
                dgv1.Item(5, Dgn).Value = W
                dgv1.Item(6, Dgn).Value = H
                dgv1.Item(7, Dgn).Value = Orint
                dgv1.Item(8, Dgn).Value = Wt
                dgv1.Item(10, Dgn).Value = MxQty
                dgv1.Item(11, Dgn).Value = UQty

                DbTrackDupIns(SN, INm, Pck, Sz, L, W, H, Orint, Wt, MxQty, UQty)

                SN = SN + 1
                Dgn = Dgn + 1

            Loop

        Catch Err As Exception
            Cons.Close()
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in Dgv1SizeSrt", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cons.Close()
        End Try

    End Sub

    Public Sub snDgv1SizeSrt(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'Stop
        Try

            If Not ADsFlg Then

                DbTrackerPerimDel()
                DbTrackerPerimIns()
                ADsFlg = True
            End If

            Dim Dgn As Integer = 0
            Dim SrN As Int32 = 0
            Dim INm As String = Nothing
            Dim Pck As String = Nothing
            Dim Sz As Double = 0
            Dim L As Double = 0
            Dim W As Double = 0
            Dim H As Double = 0
            Dim Orint As Int16 = 0
            Dim Wt As Double = 0
            Dim MxQty As Int32 = 0
            Dim UQty As Int32 = 0
            Dim Perim As Double = 0

            If Cons.State = ConnectionState.Closed Then Cons.Open()
            Dim Cmd As New OleDb.OleDbCommand
            Dim Rdr As OleDb.OleDbDataReader
            Cmd.Connection = Cons

            If Not ADmsFlg Then
                Cmd.CommandText = "select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty, Perim from BoxAPerim order by Perim desc"
                ADmsFlg = True
                BoxStatusStriplbl.Text = "Data arranged by maximum to minimum dimensions"
            Else
                Cmd.CommandText = "select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty, Perim from BoxAPerim order by Perim asc"
                ADmsFlg = False
                BoxStatusStriplbl.Text = "Data arranged by minimum to maximum dimensions"
            End If

            Rdr = Cmd.ExecuteReader

            Do While (Rdr.Read)

                SrN = Rdr("SrNo")
                INm = Rdr("ItmName")
                Pck = Rdr("Pack")
                Sz = Rdr("Sizes")
                L = Rdr("Length")
                W = Rdr("Width")
                H = Rdr("Height")
                Orint = Rdr("Orient")
                Wt = Rdr("Wt")
                MxQty = Rdr("MaxQty")
                UQty = Rdr("Qty")
                Perim = Rdr("Perim")

                dgv1.Item(0, Dgn).Value = SrN
                dgv1.Item(1, Dgn).Value = INm
                dgv1.Item(2, Dgn).Value = Pck
                dgv1.Item(3, Dgn).Value = Sz
                dgv1.Item(4, Dgn).Value = L
                dgv1.Item(5, Dgn).Value = W
                dgv1.Item(6, Dgn).Value = H
                dgv1.Item(7, Dgn).Value = Orint
                dgv1.Item(8, Dgn).Value = Wt
                dgv1.Item(10, Dgn).Value = MxQty
                dgv1.Item(11, Dgn).Value = UQty

                DbTrackDupIns(SN, INm, Pck, Sz, L, W, H, Orint, Wt, MxQty, UQty)

                SN = SN + 1
                Dgn = Dgn + 1

            Loop

        Catch Err As Exception
            Cons.Close()
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in snDgv1SizeSrt", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cons.Close()
        End Try

    End Sub

    Public Sub Dgv1LengthSrt(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'Stop

        Dim SN As Integer = 1
        Dim Dgn As Integer = 0
        Dim SrN As Int32 = 0
        Dim INm As String = Nothing
        Dim Pck As String = Nothing
        Dim Sz As Double = 0
        Dim L As Double = 0
        Dim W As Double = 0
        Dim H As Double = 0
        Dim Ori As Int16 = 0
        Dim Wt As Double = 0
        Dim MxQty As Int32 = 0
        Dim UQty As Int32 = 0

        'Stop

        Try
            DbTrackerDupDel()

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in Dgv1LengthSrt", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Try
            If Cons.State = ConnectionState.Closed Then Cons.Open()
            Dim Cmdo As New OleDb.OleDbCommand
            Dim Rdro As OleDb.OleDbDataReader
            Cmdo.Connection = Cons

            If Not AoFlg Then
                Cmdo.CommandText = "select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA order by Length desc"
                AoFlg = True
                BoxStatusStriplbl.Text = "Data arranged by maximum to maximum length"
            Else
                Cmdo.CommandText = "select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA  order by Length asc"
                AoFlg = False
                BoxStatusStriplbl.Text = "Data arranged by minimum to maximum length"
            End If

            Rdro = Cmdo.ExecuteReader

            Do While (Rdro.Read())

                SrN = Rdro("SrNo")
                INm = Rdro("ItmName")
                Pck = Rdro("Pack")
                Sz = Rdro("Sizes")
                L = Rdro("Length")
                W = Rdro("Width")
                H = Rdro("Height")
                Ori = Rdro("Orient")
                Wt = Rdro("Wt")
                MxQty = Rdro("MaxQty")
                UQty = Rdro("Qty")

                dgv1.Item(0, Dgn).Value = SN
                dgv1.Item(1, Dgn).Value = INm
                dgv1.Item(2, Dgn).Value = Pck
                dgv1.Item(3, Dgn).Value = Sz
                dgv1.Item(4, Dgn).Value = L
                dgv1.Item(5, Dgn).Value = W
                dgv1.Item(6, Dgn).Value = H
                dgv1.Item(7, Dgn).Value = Ori
                dgv1.Item(8, Dgn).Value = Wt
                dgv1.Item(10, Dgn).Value = MxQty
                dgv1.Item(11, Dgn).Value = UQty

                DbTrackDupIns(SN, INm, Pck, Sz, L, W, H, Ori, Wt, MxQty, UQty)

                SN = SN + 1
                Dgn = Dgn + 1

            Loop

        Catch Er As Exception
            Cons.Close()
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in Dgv1LengthSrt", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cons.Close()
        End Try

    End Sub

    Public Sub snDgv1LengthSrt(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'Stop
        Dim Dgn As Integer = 0
        Dim SrN As Int32 = 0
        Dim INm As String = Nothing
        Dim Pck As String = Nothing
        Dim Sz As Double = 0
        Dim L As Double = 0
        Dim W As Double = 0
        Dim H As Double = 0
        Dim Ori As Int16 = 0
        Dim Wt As Double = 0
        Dim MxQty As Int32 = 0
        Dim UQty As Int32 = 0
        'Stop

        Try
            DbTrackerDupDel()

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in snDgv1LengthSrt", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Try

            If Cons.State = ConnectionState.Closed Then Cons.Open()
            Dim Cmdo As New OleDb.OleDbCommand
            Dim Rdro As OleDb.OleDbDataReader
            Cmdo.Connection = Cons

            If Not AoFlg Then
                Cmdo.CommandText = "select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA order by Length desc"
                AoFlg = True
                BoxStatusStriplbl.Text = "Data arranged by maximum to maximum length"
            Else
                Cmdo.CommandText = "select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA  order by Length asc"
                AoFlg = False
                BoxStatusStriplbl.Text = "Data arranged by minimum to maximum length"
            End If

            Rdro = Cmdo.ExecuteReader

            Do While (Rdro.Read())

                SrN = Rdro("SrNo")
                INm = Rdro("ItmName")
                Pck = Rdro("Pack")
                Sz = Rdro("Sizes")
                L = Rdro("Length")
                W = Rdro("Width")
                H = Rdro("Height")
                Ori = Rdro("Orient")
                Wt = Rdro("Wt")
                MxQty = Rdro("MaxQty")
                UQty = Rdro("Qty")

                dgv1.Item(0, Dgn).Value = SrN
                dgv1.Item(1, Dgn).Value = INm
                dgv1.Item(2, Dgn).Value = Pck
                dgv1.Item(3, Dgn).Value = Sz
                dgv1.Item(4, Dgn).Value = L
                dgv1.Item(5, Dgn).Value = W
                dgv1.Item(6, Dgn).Value = H
                dgv1.Item(7, Dgn).Value = Ori
                dgv1.Item(8, Dgn).Value = Wt
                dgv1.Item(10, Dgn).Value = MxQty
                dgv1.Item(11, Dgn).Value = UQty

                DbTrackDupIns(SN, INm, Pck, Sz, L, W, H, Ori, Wt, MxQty, UQty)

                SN = SN + 1
                Dgn = Dgn + 1

            Loop

        Catch Er As Exception
            Cons.Close()
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in snDgv1LengthSrt", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cons.Close()
        End Try

    End Sub

    Public Sub Dgv1WidthSrt(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'Stop
        Dim SN As Integer = 1
        Dim Dgn As Integer = 0
        Dim SrN As Int32 = 0
        Dim INm As String = Nothing
        Dim Pck As String = Nothing
        Dim Sz As Double = 0
        Dim L As Double = 0
        Dim W As Double = 0
        Dim H As Double = 0
        Dim Ori As Int16 = 0
        Dim Wt As Double = 0
        Dim MxQty As Int32 = 0
        Dim UQty As Int32 = 0
        'Stop

        Try

            DbTrackerDupDel()

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in Dgv1WidthSrt", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Try

            If Cons.State = ConnectionState.Closed Then Cons.Open()
            Dim Cmdo As New OleDb.OleDbCommand
            Dim Rdro As OleDb.OleDbDataReader
            Cmdo.Connection = Cons

            If Not AoFlg Then
                Cmdo.CommandText = "select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA order by Width desc"
                AoFlg = True
                BoxStatusStriplbl.Text = "Data arranged by maximum to minimum width"
            Else
                Cmdo.CommandText = "select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA  order by Width asc"
                AoFlg = False
                BoxStatusStriplbl.Text = "Data arranged by minimum to maximum width"
            End If

            Rdro = Cmdo.ExecuteReader

            Do While (Rdro.Read())

                SrN = Rdro("SrNo")
                INm = Rdro("ItmName")
                Pck = Rdro("Pack")
                Sz = Rdro("Sizes")
                L = Rdro("Length")
                W = Rdro("Width")
                H = Rdro("Height")
                Ori = Rdro("Orient")
                Wt = Rdro("Wt")
                MxQty = Rdro("MaxQty")
                UQty = Rdro("Qty")

                dgv1.Item(0, Dgn).Value = SN
                dgv1.Item(1, Dgn).Value = INm
                dgv1.Item(2, Dgn).Value = Pck
                dgv1.Item(3, Dgn).Value = Sz
                dgv1.Item(4, Dgn).Value = L
                dgv1.Item(5, Dgn).Value = W
                dgv1.Item(6, Dgn).Value = H
                dgv1.Item(7, Dgn).Value = Ori
                dgv1.Item(8, Dgn).Value = Wt
                dgv1.Item(10, Dgn).Value = MxQty
                dgv1.Item(11, Dgn).Value = UQty

                DbTrackDupIns(SN, INm, Pck, Sz, L, W, H, Ori, Wt, MxQty, UQty)

                SN = SN + 1
                Dgn = Dgn + 1

            Loop

        Catch Er As Exception
            Cons.Close()
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in Dgv1WidthSrt", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cons.Close()
        End Try

    End Sub

    Public Sub snDgv1WidthSrt(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Stop
        Dim Dgn As Integer = 0
        Dim SrN As Int32 = 0
        Dim INm As String = Nothing
        Dim Pck As String = Nothing
        Dim Sz As Double = 0
        Dim L As Double = 0
        Dim W As Double = 0
        Dim H As Double = 0
        Dim Ori As Int16 = 0
        Dim Wt As Double = 0
        Dim MxQty As Int32 = 0
        Dim UQty As Int32 = 0
        'Stop

        Try

            DbTrackerDupDel()

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in snDgv1WidthSrt", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Try

            If Cons.State = ConnectionState.Closed Then Cons.Open()
            Dim Cmdo As New OleDb.OleDbCommand
            Dim Rdro As OleDb.OleDbDataReader
            Cmdo.Connection = Cons

            If Not AoFlg Then
                Cmdo.CommandText = "select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA order by Width desc"
                AoFlg = True
                BoxStatusStriplbl.Text = "Data arranged by maximum to minimum width"
            Else
                Cmdo.CommandText = "select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA  order by Width asc"
                AoFlg = False
                BoxStatusStriplbl.Text = "Data arranged by minimum to maximum width"
            End If

            Rdro = Cmdo.ExecuteReader

            Do While (Rdro.Read())

                SrN = Rdro("SrNo")
                INm = Rdro("ItmName")
                Pck = Rdro("Pack")
                Sz = Rdro("Sizes")
                L = Rdro("Length")
                W = Rdro("Width")
                H = Rdro("Height")
                Ori = Rdro("Orient")
                Wt = Rdro("Wt")
                MxQty = Rdro("MaxQty")
                UQty = Rdro("Qty")

                dgv1.Item(0, Dgn).Value = SrN
                dgv1.Item(1, Dgn).Value = INm
                dgv1.Item(2, Dgn).Value = Pck
                dgv1.Item(3, Dgn).Value = Sz
                dgv1.Item(4, Dgn).Value = L
                dgv1.Item(5, Dgn).Value = W
                dgv1.Item(6, Dgn).Value = H
                dgv1.Item(7, Dgn).Value = Ori
                dgv1.Item(8, Dgn).Value = Wt
                dgv1.Item(10, Dgn).Value = MxQty
                dgv1.Item(11, Dgn).Value = UQty

                DbTrackDupIns(SN, INm, Pck, Sz, L, W, H, Ori, Wt, MxQty, UQty)

                SN = SN + 1
                Dgn = Dgn + 1

            Loop

        Catch Er As Exception
            Cons.Close()
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in snDgv1WidthSrt", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cons.Close()
        End Try

    End Sub

    Public Sub Dgv1HeightSrt(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Stop
        Dim SN As Integer = 1
        Dim Dgn As Integer = 0
        Dim SrN As Int32 = 0
        Dim INm As String = Nothing
        Dim Pck As String = Nothing
        Dim Sz As Double = 0
        Dim L As Double = 0
        Dim W As Double = 0
        Dim H As Double = 0
        Dim Ori As Int16 = 0
        Dim Wt As Double = 0
        Dim MxQty As Int32 = 0
        Dim UQty As Int32 = 0
        'Stop

        Try

            DbTrackerDupDel()

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in Dgv1HeightSrt", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Try

            If Cons.State = ConnectionState.Closed Then Cons.Open()
            Dim Cmdo As New OleDb.OleDbCommand
            Dim Rdro As OleDb.OleDbDataReader
            Cmdo.Connection = Cons

            If Not AoFlg Then
                Cmdo.CommandText = "select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA order by Height desc"
                AoFlg = True
                BoxStatusStriplbl.Text = "Data arranged by maximum to minimum height"
            Else
                Cmdo.CommandText = "select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA  order by Height asc"
                AoFlg = False
                BoxStatusStriplbl.Text = "Data arranged by minimum to maximum height"
            End If

            Rdro = Cmdo.ExecuteReader

            Do While (Rdro.Read())

                SrN = Rdro("SrNo")
                INm = Rdro("ItmName")
                Pck = Rdro("Pack")
                Sz = Rdro("Sizes")
                L = Rdro("Length")
                W = Rdro("Width")
                H = Rdro("Height")
                Ori = Rdro("Orient")
                Wt = Rdro("Wt")
                MxQty = Rdro("MaxQty")
                UQty = Rdro("Qty")

                dgv1.Item(0, Dgn).Value = SN
                dgv1.Item(1, Dgn).Value = INm
                dgv1.Item(2, Dgn).Value = Pck
                dgv1.Item(3, Dgn).Value = Sz
                dgv1.Item(4, Dgn).Value = L
                dgv1.Item(5, Dgn).Value = W
                dgv1.Item(6, Dgn).Value = H
                dgv1.Item(7, Dgn).Value = Ori
                dgv1.Item(8, Dgn).Value = Wt
                dgv1.Item(10, Dgn).Value = MxQty
                dgv1.Item(11, Dgn).Value = UQty

                DbTrackDupIns(SN, INm, Pck, Sz, L, W, H, Ori, Wt, MxQty, UQty)

                SN = SN + 1
                Dgn = Dgn + 1

            Loop

        Catch Er As Exception
            Cons.Close()
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in Dgv1HeightSrt", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cons.Close()
        End Try

    End Sub

    Public Sub snDgv1HeightSrt(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Stop

        Dim Dgn As Integer = 0
        Dim SrN As Int32 = 0
        Dim INm As String = Nothing
        Dim Pck As String = Nothing
        Dim Sz As Double = 0
        Dim L As Double = 0
        Dim W As Double = 0
        Dim H As Double = 0
        Dim Ori As Int16 = 0
        Dim Wt As Double = 0
        Dim MxQty As Int32 = 0
        Dim UQty As Int32 = 0
        'Stop

        Try

            DbTrackerDupDel()

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in snDgv1HeightSrt", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Try

            If Cons.State = ConnectionState.Closed Then Cons.Open()
            Dim Cmdo As New OleDb.OleDbCommand
            Dim Rdro As OleDb.OleDbDataReader
            Cmdo.Connection = Cons

            If Not AoFlg Then
                Cmdo.CommandText = "select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA order by Height desc"
                AoFlg = True
                BoxStatusStriplbl.Text = "Data arranged by maximum to minimum height"
            Else
                Cmdo.CommandText = "select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA  order by Height asc"
                AoFlg = False
                BoxStatusStriplbl.Text = "Data arranged by minimum to maximum height"
            End If

            Rdro = Cmdo.ExecuteReader

            Do While (Rdro.Read())

                SrN = Rdro("SrNo")
                INm = Rdro("ItmName")
                Pck = Rdro("Pack")
                Sz = Rdro("Sizes")
                L = Rdro("Length")
                W = Rdro("Width")
                H = Rdro("Height")
                Ori = Rdro("Orient")
                Wt = Rdro("Wt")
                MxQty = Rdro("MaxQty")
                UQty = Rdro("Qty")

                dgv1.Item(0, Dgn).Value = SrN
                dgv1.Item(1, Dgn).Value = INm
                dgv1.Item(2, Dgn).Value = Pck
                dgv1.Item(3, Dgn).Value = Sz
                dgv1.Item(4, Dgn).Value = L
                dgv1.Item(5, Dgn).Value = W
                dgv1.Item(6, Dgn).Value = H
                dgv1.Item(7, Dgn).Value = Ori
                dgv1.Item(8, Dgn).Value = Wt
                dgv1.Item(10, Dgn).Value = MxQty
                dgv1.Item(11, Dgn).Value = UQty

                DbTrackDupIns(SN, INm, Pck, Sz, L, W, H, Ori, Wt, MxQty, UQty)

                SN = SN + 1
                Dgn = Dgn + 1

            Loop

        Catch Er As Exception
            Cons.Close()
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in snDgv1HeightSrt", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cons.Close()
        End Try

    End Sub

    Public Sub Dgv1SrNoSrt(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim SN As Integer = 1
        Dim Dgn As Integer = 0
        Dim SrN As Int32 = 0
        Dim INm As String = Nothing
        Dim Pck As String = Nothing
        Dim Sz As Double = 0
        Dim L As Double = 0
        Dim W As Double = 0
        Dim H As Double = 0
        Dim Ori As Int16 = 0
        Dim Wt As Double = 0
        Dim MxQty As Int32 = 0
        Dim UQty As Int32 = 0

        'Stop

        Try

            DbTrackerDupDel()

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in Dgv1SrNoSrt", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Try

            If Cons.State = ConnectionState.Closed Then Cons.Open()
            Dim Cmdo As New OleDb.OleDbCommand
            Dim Rdro As OleDb.OleDbDataReader
            Cmdo.Connection = Cons

            If Not AoFlg Then
                Cmdo.CommandText = "select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA order by SrNo desc"
                AoFlg = True
                BoxStatusStriplbl.Text = "Data arranged by grid serial number descending"
            Else
                Cmdo.CommandText = "select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA  order by SrNo asc"
                AoFlg = False
                BoxStatusStriplbl.Text = "Data arranged by grid serial number ascending"
            End If

            Rdro = Cmdo.ExecuteReader

            Do While (Rdro.Read())

                SrN = Rdro("SrNo")
                INm = Rdro("ItmName")
                Pck = Rdro("Pack")
                Sz = Rdro("Sizes")
                L = Rdro("Length")
                W = Rdro("Width")
                H = Rdro("Height")
                Ori = Rdro("Orient")
                Wt = Rdro("Wt")
                MxQty = Rdro("MaxQty")
                UQty = Rdro("Qty")

                dgv1.Item(0, Dgn).Value = SN
                dgv1.Item(1, Dgn).Value = INm
                dgv1.Item(2, Dgn).Value = Pck
                dgv1.Item(3, Dgn).Value = Sz
                dgv1.Item(4, Dgn).Value = L
                dgv1.Item(5, Dgn).Value = W
                dgv1.Item(6, Dgn).Value = H
                dgv1.Item(7, Dgn).Value = Ori
                dgv1.Item(8, Dgn).Value = Wt
                dgv1.Item(10, Dgn).Value = MxQty
                dgv1.Item(11, Dgn).Value = UQty

                DbTrackDupIns(SN, INm, Pck, Sz, L, W, H, Ori, Wt, MxQty, UQty)

                SN = SN + 1
                Dgn = Dgn + 1

            Loop

        Catch Er As Exception
            Cons.Close()
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in Dgv1SrNoSrt", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cons.Close()
        End Try

    End Sub

    Public Sub snDgv1SrNoSrt(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim Dgn As Integer = 0
        Dim SrN As Int32 = 0
        Dim INm As String = Nothing
        Dim Pck As String = Nothing
        Dim Sz As Double = 0
        Dim L As Double = 0
        Dim W As Double = 0
        Dim H As Double = 0
        Dim Ori As Int16 = 0
        Dim Wt As Double = 0
        Dim MxQty As Int32 = 0
        Dim UQty As Int32 = 0

        'Stop

        Try

            DbTrackerDupDel()

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in snDgv1SrNoSrt", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Try

            If Cons.State = ConnectionState.Closed Then Cons.Open()
            Dim Cmdo As New OleDb.OleDbCommand
            Dim Rdro As OleDb.OleDbDataReader
            Cmdo.Connection = Cons

            If Not AoFlg Then
                Cmdo.CommandText = "select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA order by SrNo desc"
                AoFlg = True
                BoxStatusStriplbl.Text = "Data arranged by grid serial number descending"
            Else
                Cmdo.CommandText = "select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA  order by SrNo asc"
                AoFlg = False
                BoxStatusStriplbl.Text = "Data arranged by grid serial number ascending"
            End If

            Rdro = Cmdo.ExecuteReader

            Do While (Rdro.Read())

                SrN = Rdro("SrNo")
                INm = Rdro("ItmName")
                Pck = Rdro("Pack")
                Sz = Rdro("Sizes")
                L = Rdro("Length")
                W = Rdro("Width")
                H = Rdro("Height")
                Ori = Rdro("Orient")
                Wt = Rdro("Wt")
                MxQty = Rdro("MaxQty")
                UQty = Rdro("Qty")

                dgv1.Item(0, Dgn).Value = SrN
                dgv1.Item(1, Dgn).Value = INm
                dgv1.Item(2, Dgn).Value = Pck
                dgv1.Item(3, Dgn).Value = Sz
                dgv1.Item(4, Dgn).Value = L
                dgv1.Item(5, Dgn).Value = W
                dgv1.Item(6, Dgn).Value = H
                dgv1.Item(7, Dgn).Value = Ori
                dgv1.Item(8, Dgn).Value = Wt
                dgv1.Item(10, Dgn).Value = MxQty
                dgv1.Item(11, Dgn).Value = UQty

                DbTrackDupIns(SN, INm, Pck, Sz, L, W, H, Ori, Wt, MxQty, UQty)

                SN = SN + 1
                Dgn = Dgn + 1

            Loop

        Catch Er As Exception
            Cons.Close()
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in snDgv1SrNoSrt", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cons.Close()
        End Try

    End Sub

    Public Sub Dgv1ItemNameSrt(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Stop
        Dim SN As Integer = 1
        Dim Dgn As Integer = 0
        Dim SrN As Int32 = 0
        Dim INm As String = Nothing
        Dim Pck As String = Nothing
        Dim Sz As Double = 0
        Dim L As Double = 0
        Dim W As Double = 0
        Dim H As Double = 0
        Dim Ori As Int16 = 0
        Dim Wt As Double = 0
        Dim MxQty As Int32 = 0
        Dim UQty As Int32 = 0

        Try

            DbTrackerDupDel()

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in Dgv1ItemNameSrt", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Try

            If Cons.State = ConnectionState.Closed Then Cons.Open()
            Dim CmdAb As New OleDb.OleDbCommand
            Dim RdrAb As OleDb.OleDbDataReader

            CmdAb.Connection = Cons

            If Not ADabFlg Then

                CmdAb.CommandText = "select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA order by ItmName desc"
                ADabFlg = True
                BoxStatusStriplbl.Text = "Data arranged by alphabetical descending"
            Else

                CmdAb.CommandText = "select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA order by ItmName asc"
                ADabFlg = False
                BoxStatusStriplbl.Text = "Data arranged by alphabetical ascending"
            End If

            RdrAb = CmdAb.ExecuteReader

            Do While (RdrAb.Read)

                SrN = RdrAb("SrNo")
                INm = RdrAb("ItmName")
                Pck = RdrAb("Pack")
                Sz = RdrAb("Sizes")
                L = RdrAb("Length")
                W = RdrAb("Width")
                H = RdrAb("Height")
                Ori = RdrAb("Orient")
                Wt = RdrAb("Wt")
                MxQty = RdrAb("MaxQty")
                UQty = RdrAb("Qty")

                dgv1.Item(0, Dgn).Value = SN
                dgv1.Item(1, Dgn).Value = INm
                dgv1.Item(2, Dgn).Value = Pck
                dgv1.Item(3, Dgn).Value = Sz
                dgv1.Item(4, Dgn).Value = L
                dgv1.Item(5, Dgn).Value = W
                dgv1.Item(6, Dgn).Value = H
                dgv1.Item(7, Dgn).Value = Ori
                dgv1.Item(8, Dgn).Value = Wt
                dgv1.Item(10, Dgn).Value = MxQty
                dgv1.Item(11, Dgn).Value = UQty

                DbTrackDupIns(SN, INm, Pck, Sz, L, W, H, Ori, Wt, MxQty, UQty)

                SN = SN + 1
                Dgn = Dgn + 1

            Loop

        Catch Err As Exception
            Cons.Close()
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in Dgv1ItemNameSrt", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cons.Close()
        End Try

    End Sub

    Public Sub snDgv1ItemNameSrt(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'Stop
        Dim Dgn As Integer = 0
        Dim SrN As Int32 = 0
        Dim INm As String = Nothing
        Dim Pck As String = Nothing
        Dim Sz As Double = 0
        Dim L As Double = 0
        Dim W As Double = 0
        Dim H As Double = 0
        Dim Ori As Int16 = 0
        Dim Wt As Double = 0
        Dim MxQty As Int32 = 0
        Dim UQty As Int32 = 0

        Try

            DbTrackerDupDel()

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in snDgv1ItemNameSrt", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Try

            If Cons.State = ConnectionState.Closed Then Cons.Open()
            Dim CmdAb As New OleDb.OleDbCommand
            Dim RdrAb As OleDb.OleDbDataReader

            CmdAb.Connection = Cons

            If Not ADabFlg Then

                CmdAb.CommandText = "select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA order by ItmName desc"
                ADabFlg = True
                BoxStatusStriplbl.Text = "Data arranged by alphabetical descending"
            Else

                CmdAb.CommandText = "select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA order by ItmName asc"
                ADabFlg = False
                BoxStatusStriplbl.Text = "Data arranged by alphabetical ascending"
            End If

            RdrAb = CmdAb.ExecuteReader

            Do While (RdrAb.Read)

                SrN = RdrAb("SrNo")
                INm = RdrAb("ItmName")
                Pck = RdrAb("Pack")
                Sz = RdrAb("Sizes")
                L = RdrAb("Length")
                W = RdrAb("Width")
                H = RdrAb("Height")
                Ori = RdrAb("Orient")
                Wt = RdrAb("Wt")
                MxQty = RdrAb("MaxQty")
                UQty = RdrAb("Qty")

                dgv1.Item(0, Dgn).Value = SrN
                dgv1.Item(1, Dgn).Value = INm
                dgv1.Item(2, Dgn).Value = Pck
                dgv1.Item(3, Dgn).Value = Sz
                dgv1.Item(4, Dgn).Value = L
                dgv1.Item(5, Dgn).Value = W
                dgv1.Item(6, Dgn).Value = H
                dgv1.Item(7, Dgn).Value = Ori
                dgv1.Item(8, Dgn).Value = Wt
                dgv1.Item(10, Dgn).Value = MxQty
                dgv1.Item(11, Dgn).Value = UQty

                DbTrackDupIns(SN, INm, Pck, Sz, L, W, H, Ori, Wt, MxQty, UQty)

                SN = SN + 1
                Dgn = Dgn + 1

            Loop

        Catch Err As Exception
            Cons.Close()
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in snDgv1ItemNameSrt", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cons.Close()
        End Try

    End Sub

    Public Sub Dgv1QtySrt(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Stop
        Try

            DbTrackerDupDel()
            DbTrackInsDup()

        Catch Err As Exception
            Cons.Close()
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in Dgv1QtySrt", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cons.Close()
        End Try

    End Sub

    Public Sub snDgv1QtySrt(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Stop
        Try

            DbTrackerDupDel()
            snDbTrackInsDup()

        Catch Err As Exception
            Cons.Close()
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in snDgv1QtySrt", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cons.Close()
        End Try

    End Sub

    Public Sub Dgv1MxQtySrt(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Stop

        Try
            DbTrackerDupDel()
            DbTrackInsDupMxQty()

        Catch Err As Exception
            Cons.Close()
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in Dgv1QtySrt", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cons.Close()
        End Try

    End Sub

    Public Sub snDgv1MxQtySrt(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Stop

        Try
            DbTrackerDupDel()
            snDbTrackInsDupMxQty()

        Catch Err As Exception
            Cons.Close()
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in snDgv1QtySrt", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cons.Close()
        End Try

    End Sub

    Public Sub Dgv1PackSrt(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'Stop
        Try

            Dim SN As Integer = 1
            Dim Dgn As Integer = 0
            Dim SrN As Int32 = 0
            Dim INm As String = Nothing
            Dim Pck As String = Nothing
            Dim Sz As Double = 0
            Dim L As Double = 0
            Dim W As Double = 0
            Dim H As Double = 0
            Dim Orint As Int16 = 0
            Dim Wt As Double = 0
            Dim MxQty As Int32 = 0
            Dim UQty As Int32 = 0

            Try
                DbTrackerDupDel()

            Catch Er As Exception
                MsgBox(Er.Message)
                MsgBox(Er.ToString)
                MessageBox.Show("Error in Dgv1PackSrt", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            If Cons.State = ConnectionState.Closed Then Cons.Open()
            Dim CmdW As New OleDb.OleDbCommand
            Dim RdrW As OleDb.OleDbDataReader
            CmdW.Connection = Cons

            If ADflg Then
                CmdW.CommandText = "select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA order by Pack asc"
                ADflg = False
                BoxStatusStriplbl.Text = "Data arranged by minimum to maximum weight"
            Else
                CmdW.CommandText = "select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA order by Pack desc"
                ADflg = True
                BoxStatusStriplbl.Text = "Data arranged by maximum to minimum weight"
            End If

            RdrW = CmdW.ExecuteReader

            Do While (RdrW.Read())

                SrN = RdrW("SrNo")
                INm = RdrW("ItmName")
                Pck = RdrW("Pack")
                Sz = RdrW("Sizes")
                L = RdrW("Length")
                W = RdrW("Width")
                H = RdrW("Height")
                Orint = RdrW("Orient")
                Wt = RdrW("Wt")
                MxQty = RdrW("MaxQty")
                UQty = RdrW("Qty")

                dgv1.Item(0, Dgn).Value = SN
                dgv1.Item(1, Dgn).Value = INm
                dgv1.Item(2, Dgn).Value = Pck
                dgv1.Item(3, Dgn).Value = Sz
                dgv1.Item(4, Dgn).Value = L
                dgv1.Item(5, Dgn).Value = W
                dgv1.Item(6, Dgn).Value = H
                dgv1.Item(7, Dgn).Value = Orint
                dgv1.Item(8, Dgn).Value = Wt
                dgv1.Item(10, Dgn).Value = MxQty
                dgv1.Item(11, Dgn).Value = UQty

                DbTrackDupIns(SN, INm, Pck, Sz, L, W, H, Orint, Wt, MxQty, UQty)

                SN = SN + 1
                Dgn = Dgn + 1
            Loop

        Catch Err As Exception
            Cons.Close()
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in Dgv1PackSrt", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cons.Close()
        End Try

    End Sub

    Public Sub snDgv1PackSrt(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'Stop
        Try

            Dim SN As Integer = 1
            Dim Dgn As Integer = 0
            Dim SrN As Int32 = 0
            Dim INm As String = Nothing
            Dim Pck As String = Nothing
            Dim Sz As Double = 0
            Dim L As Double = 0
            Dim W As Double = 0
            Dim H As Double = 0
            Dim Orint As Int16 = 0
            Dim Wt As Double = 0
            Dim MxQty As Int32 = 0
            Dim UQty As Int32 = 0

            Try
                DbTrackerDupDel()

            Catch Er As Exception
                MsgBox(Er.Message)
                MsgBox(Er.ToString)
                MessageBox.Show("Error in snDgv1PackSrt", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            If Cons.State = ConnectionState.Closed Then Cons.Open()
            Dim CmdW As New OleDb.OleDbCommand
            Dim RdrW As OleDb.OleDbDataReader
            CmdW.Connection = Cons

            If ADflg Then
                CmdW.CommandText = "select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA order by Pack asc"
                ADflg = False
                BoxStatusStriplbl.Text = "Data arranged by minimum to maximum weight"
            Else
                CmdW.CommandText = "select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA order by Pack desc"
                ADflg = True
                BoxStatusStriplbl.Text = "Data arranged by maximum to minimum weight"
            End If

            RdrW = CmdW.ExecuteReader

            Do While (RdrW.Read())

                SrN = RdrW("SrNo")
                INm = RdrW("ItmName")
                Pck = RdrW("Pack")
                Sz = RdrW("Sizes")
                L = RdrW("Length")
                W = RdrW("Width")
                H = RdrW("Height")
                Orint = RdrW("Orient")
                Wt = RdrW("Wt")
                MxQty = RdrW("MaxQty")
                UQty = RdrW("Qty")

                dgv1.Item(0, Dgn).Value = SrN
                dgv1.Item(1, Dgn).Value = INm
                dgv1.Item(2, Dgn).Value = Pck
                dgv1.Item(3, Dgn).Value = Sz
                dgv1.Item(4, Dgn).Value = L
                dgv1.Item(5, Dgn).Value = W
                dgv1.Item(6, Dgn).Value = H
                dgv1.Item(7, Dgn).Value = Orint
                dgv1.Item(8, Dgn).Value = Wt
                dgv1.Item(10, Dgn).Value = MxQty
                dgv1.Item(11, Dgn).Value = UQty

                DbTrackDupIns(SN, INm, Pck, Sz, L, W, H, Orint, Wt, MxQty, UQty)

                SN = SN + 1
                Dgn = Dgn + 1

            Loop

        Catch Err As Exception
            Cons.Close()
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in snDgv1PackSrt", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cons.Close()
        End Try

    End Sub

    Private Sub btnNm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNm.Click

        Try
            PngStarter()
        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in btnNm_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnSrN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSrN.Click

        If Not SrNFlg Then
            SrNFlg = True
            btnSrN.Text = "&SrNo on"
        Else
            SrNFlg = False
            btnSrN.Text = "&SrNo off"
        End If

    End Sub

    'Implements Track bar from here 2 August 2K8
    Dim flgDr As Boolean = False

    Private Sub btnDoor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDoor.Click

        If Not flgDr Then
            TrackBarContBxDor.Enabled = True
            TrackBarContBxDor.Value = 0
            flgDr = True
            btnDoor.Text = "&Door open on"
            TrackBarContBxDor.BackColor = Color.LightPink
            DbxFlg = True

            rdb1D.Enabled = True
            rdb2D.Enabled = True

            TrackBarContBxDor.Value = 5

        Else
            TrackBarContBxDor.Enabled = False
            TrackBarContBxDor.Value = 0
            flgDr = False
            btnDoor.Text = "&Door open off"
            TrackBarContBxDor.BackColor = Color.Gainsboro
            DbxFlg = False

            rdb1D.Enabled = False
            rdb2D.Enabled = False
            rdb2D.Checked = True

        End If

    End Sub

    Private Sub TrackBarContBxDor_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrackBarContBxDor.LostFocus
        Try
            dgv1.StandardTab = False
            dgv1(1, dgv1.RowCount - 1).Selected = True
            dgv1.Columns(1).Selected = True
        Catch
        End Try
    End Sub

    Private Sub TrackBarContBxDor_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrackBarContBxDor.ValueChanged

        Try

            If TrackBarContBxDor.Value = 0 Then
                OpnDeg = 0
                TrnsGrd = 1
                'MsgBox("0         " & OpnDeg)
                BoxStatusStriplbl.Text = "The door open position is 0 % open"

            ElseIf TrackBarContBxDor.Value = 1 Then
                OpnDeg = 342
                TrnsGrd = 0.5
                'MsgBox("1         " & OpnDeg)
                BoxStatusStriplbl.Text = "The door open position is 10 % open"

            ElseIf TrackBarContBxDor.Value = 2 Then
                OpnDeg = 324
                TrnsGrd = 0.5
                'MsgBox("2         " & OpnDeg)
                BoxStatusStriplbl.Text = "The door open position is 20 % open"

            ElseIf TrackBarContBxDor.Value = 3 Then
                OpnDeg = 306
                TrnsGrd = 0.5
                'MsgBox("3         " & OpnDeg)
                BoxStatusStriplbl.Text = "The door open position is 30 % open"

            ElseIf TrackBarContBxDor.Value = 4 Then
                OpnDeg = 288
                TrnsGrd = 0.5
                'MsgBox("4         " & OpnDeg)
                BoxStatusStriplbl.Text = "The door open position is 40 % open"

            ElseIf TrackBarContBxDor.Value = 5 Then
                OpnDeg = 270
                TrnsGrd = 0.5
                'MsgBox("5         " & OpnDeg)
                BoxStatusStriplbl.Text = "The door open position is 50 % open"

            ElseIf TrackBarContBxDor.Value = 6 Then
                OpnDeg = 252
                TrnsGrd = 0.5
                'MsgBox("6         " & OpnDeg)
                BoxStatusStriplbl.Text = "The door open position is 60 % open"

            ElseIf TrackBarContBxDor.Value = 7 Then
                OpnDeg = 234
                TrnsGrd = 0.5
                'MsgBox("7         " & OpnDeg)
                BoxStatusStriplbl.Text = "The door open position is 70 % open"

            ElseIf TrackBarContBxDor.Value = 8 Then
                OpnDeg = 216
                TrnsGrd = 0.5
                'MsgBox("8         " & OpnDeg)
                BoxStatusStriplbl.Text = "The door open position is 80 % open"

            ElseIf TrackBarContBxDor.Value = 9 Then
                OpnDeg = 198
                TrnsGrd = 0.5
                ' MsgBox("9         " & OpnDeg)
                BoxStatusStriplbl.Text = "The door open position is 90 % open"

            ElseIf TrackBarContBxDor.Value = 10 Then
                OpnDeg = 180            '0
                TrnsGrd = 0.5           '1
                'MsgBox("10         " & OpnDeg)
                BoxStatusStriplbl.Text = "The door open position is 100 % open"

            End If
            'Stop

            'Dim YN As String
            'YN = MessageBox.Show("Do you want to see empty container ?", "Container stuff info.....", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            ''Stop
            'If MsgBoxResult.Yes = YN Then
            '    Stop
            '    Dim em As System.Windows.Forms.MouseEventArgs = Nothing

            '    DrBxOpn = True
            '    Call AutoStuffShow(sender, em)
            '    Stop
            '    StartViewer()

            'End If

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in TrackBarContBxDor_ValueChanged", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    'Implements from stuffing arrangements wise point shifting position

    Private Sub btnManualPosition_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnManualPosition.Click

        'Stop

        Try

            If PosChngFlg = False Then

                Dim X As String = Mtxtbx_X.Text
                Dim Y As String = Mtxtbx_Y.Text
                Dim Z As String = Mtxtbx_Z.Text
                Dim Qty0 As String = Mtxtbx_Qty0.Text
                Dim Qty1 As String = Mtxtbx_Qty1.Text

                Try
                    XPosPt = Convert.ToDouble(X)
                Catch ex As Exception
                    XPosPt = 0
                    GoTo Spn1
                End Try

Spn1:

                Try
                    YPosPt = Convert.ToDouble(Y)
                Catch ex As Exception
                    YPosPt = 0
                    GoTo Spn2
                End Try

Spn2:
                Try
                    ZPosPt = Convert.ToDouble(Z)
                Catch ex As Exception
                    ZPosPt = 0
                    GoTo Spn3
                End Try

Spn3:

                Try
                    QtyPosPt0 = Convert.ToDouble(Qty0)
                Catch ex As Exception
                    QtyPosPt0 = 0
                    GoTo Spn4
                End Try

Spn4:

                Try
                    QtyPosPt1 = Convert.ToDouble(Qty1)
                Catch ex As Exception
                    QtyPosPt1 = 0
                    GoTo Spn5
                End Try

Spn5:

                btnManualPosition.Text = "&Manual position change on"
                PosChngFlg = True

            Else

                PosChngFlg = False

                XPosPt = 0
                YPosPt = 0
                ZPosPt = 0
                QtyPosPt0 = 0
                QtyPosPt1 = 0

                btnManualPosition.Text = "&Manual position change off"

                Mtxtbx_X.Text = ""
                Mtxtbx_Y.Text = ""
                Mtxtbx_Z.Text = ""
                Mtxtbx_Qty0.Text = ""
                Mtxtbx_Qty1.Text = ""

            End If

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in btnManualPosition_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnPause_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPause.Click

        'Stop
        Try
            mClk = False
            btnPause.BackColor = Color.Red
            flgPause = True
            SecPause = mtxtbxPause.Text
            Eventless()

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in btnPause_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub chkBxSlideStuff_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBxSlideStuff.CheckedChanged

        Try
            chkBxAutoStuff.Checked = False
            CheckBox1.Checked = False
            chkbxOptStuff.Checked = False
            chkBxPlyStuff.Checked = False

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in chkBxSlideStuff_CheckedChanged", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Try
            'If Not SlidStfPosFlg Then

            '    gbPositionChangeBox.Enabled = True
            '    SlidStfPosFlg = True

            'Else
            '    gbPositionChangeBox.Enabled = False
            '    SlidStfPosFlg = False
            'End If

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in chkBxSlideStuff_CheckedChanged", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub chkBxAutoStuff_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBxAutoStuff.CheckedChanged

        Try

            ShowButton.Visible = False
        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in chkBxAutoStuff_CheckedChanged", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Try

            'Me.Column10.HeaderText = "MthQty"
            'DbTrackDel()
            'InsrtDgvDb()
            'editenable()
            'CmbContainer.Enabled = True
            'DtReceipt.Enabled = True
            'Str = "Edit"
            'BFlag = True
            'Call Dgv1QtySrt(sender, e)

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in chkBxAutoStuff_CheckedChanged", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Structure AutoStuff
        Dim Srn As Int16
        Dim Inm As String
        Dim Pck As String
        Dim Sz As Double
        Dim L As Double
        Dim W As Double
        Dim H As Double
        Dim Ori As Int16
        Dim Wt As Double
        Dim RemnQty As Int64
        Dim FnlQty As Int64
        Dim qX As Int64
        Dim qY As Int64
        Dim qZ As Int64
    End Structure

    Public Structure AutoStuffCmn
        Dim srn As Int16
        Dim Inm As String
        Dim Pck As String
        Dim Sz As Double
        Dim L As Double
        Dim W As Double
        Dim H As Double
        Dim Ori As Int16
        Dim Wt As Double
        Dim RemnQty As Int64
        Dim FnlQty As Int64
        Dim qX As Int64
        Dim qY As Int64
        Dim qZ As Int64
    End Structure

    Public Sub UnCheckedAutostuff()

        Dim dgN As Integer = 0

        Try
            TxtpercentVolOcc.Text = ""
            txtCompactPer.Text = ""

            Dim RcDg As Integer = dgv1.RowCount

            Try
                Do While (RcDg - 1 > 0)
                    RcDg -= 2
                    dgv1.Rows.RemoveAt(RcDg)
                Loop
            Catch
            End Try

            dgv1.Refresh()

            If Cons.State = ConnectionState.Closed Then Cons.Open()

            Dim cmds As New OleDb.OleDbCommand
            Dim Rdrs As OleDb.OleDbDataReader

            cmds.Connection = Cons
            cmds.CommandText = "Select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA"
            Rdrs = cmds.ExecuteReader

            Try

                dgv1.Rows.Add()

                Do While (Rdrs.Read())

                    dgv1.Item(0, dgN).Value = Rdrs("SrNo")
                    dgv1.Item(1, dgN).Value = Rdrs("ItmName")
                    dgv1.Item(2, dgN).Value = Rdrs("Pack")
                    dgv1.Item(3, dgN).Value = Rdrs("sizes")
                    dgv1.Item(4, dgN).Value = Rdrs("Length")
                    dgv1.Item(5, dgN).Value = Rdrs("Width")
                    dgv1.Item(6, dgN).Value = Rdrs("Height")
                    dgv1.Item(7, dgN).Value = Rdrs("Orient")
                    dgv1.Item(8, dgN).Value = Rdrs("Wt")
                    dgv1.Item(10, dgN).Value = Rdrs("MaxQty")
                    dgv1.Item(11, dgN).Value = Rdrs("Qty")

                    dgN += 1

                Loop

            Catch
            End Try

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in UnCheckedAutostuff", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub FlowDgvDataMngAutoStuffRandC()

        Try
            Sauto.Clear()
            ScnAut.Clear()
            FdAut.Clear()

            Dim Dgn As Integer = 0
            Dim SrN As Int32 = 0
            Dim INm As String = Nothing
            Dim Pck As String = Nothing
            Dim Sz As Double = 0
            Dim L As Double = 0
            Dim W As Double = 0
            Dim H As Double = 0
            Dim Ori As Int16 = 0
            Dim Wt As Double = 0
            Dim MxQty As Int32 = 0
            Dim UQty As Int32 = 0
            Dim FnlQty As Int64 = 0
            Dim RemnQty As Int64 = 0

            Dim Sat As AutoStuff
            Dim Scn As AutoStuffCmn

            Try

                If Cons.State = ConnectionState.Closed Then Cons.Open()
                Dim Cmds As New OleDb.OleDbCommand
                Dim Rdrs As OleDb.OleDbDataReader
                Cmds.Connection = Cons

                'Cmds.CommandText = "Select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA order by Qty desc, Sizes desc, Wt desc"

                If Rdb1.Checked = True Then
                    Cmds.CommandText = "Select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA order by Qty desc"
                ElseIf Rdb2.Checked = True Then
                    Cmds.CommandText = "Select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA order by Qty asc"
                ElseIf Rdb3.Checked = True Then
                    Cmds.CommandText = "Select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA order by Wt desc"
                ElseIf Rdb4.Checked = True Then
                    Cmds.CommandText = "Select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA order by Wt asc"
                ElseIf Rdb5.Checked = True Then
                    Cmds.CommandText = "Select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA order by Height desc"
                ElseIf Rdb6.Checked = True Then
                    Cmds.CommandText = "Select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA order by Height asc"
                ElseIf Rdb7.Checked = True Then
                    Cmds.CommandText = "Select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA order by Width desc"
                ElseIf Rdb8.Checked = True Then
                    Cmds.CommandText = "Select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA order by Width asc"
                ElseIf Rdb9.Checked = True Then
                    Cmds.CommandText = "Select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA order by Length desc"
                ElseIf Rdb10.Checked = True Then
                    Cmds.CommandText = "Select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA order by Length asc"
                ElseIf Rdb11.Checked = True Then
                    Cmds.CommandText = "Select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA order by Sizes desc"
                ElseIf Rdb12.Checked = True Then
                    Cmds.CommandText = "Select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA order by Sizes asc"
                ElseIf Rdb13.Checked = True Then
                    Cmds.CommandText = "Select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA order by ItmName desc"
                ElseIf Rdb14.Checked = True Then
                    Cmds.CommandText = "Select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA order by ItmName asc"
                ElseIf Rdb15.Checked = True Then
                    Cmds.CommandText = "Select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA order by SrNo desc"
                ElseIf Rdb16.Checked = True Then
                    Cmds.CommandText = "Select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA order by SrNo asc"
                Else
                    Cmds.CommandText = "Select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA"
                End If

                Rdrs = Cmds.ExecuteReader

                Do While (Rdrs.Read())

                    SrN = Rdrs("SrNo")
                    INm = Rdrs("ItmName")
                    Pck = Rdrs("Pack")
                    Sz = Rdrs("Sizes")
                    L = Rdrs("Length")
                    W = Rdrs("width")
                    H = Rdrs("height")
                    Ori = Rdrs("orient")
                    Wt = Rdrs("Wt")
                    MxQty = Rdrs("MaxQty")
                    UQty = Rdrs("Qty")

                    'dgv1.Item(0, Dgn).Value = SN
                    dgv1.Item(1, Dgn).Value = INm
                    dgv1.Item(2, Dgn).Value = Pck
                    dgv1.Item(3, Dgn).Value = Sz
                    dgv1.Item(4, Dgn).Value = L
                    dgv1.Item(5, Dgn).Value = W
                    dgv1.Item(6, Dgn).Value = H
                    dgv1.Item(7, Dgn).Value = Ori
                    dgv1.Item(8, Dgn).Value = Wt
                    dgv1.Item(10, Dgn).Value = MxQty
                    dgv1.Item(11, Dgn).Value = UQty

                    DbTrackDupIns(SN, INm, Pck, Sz, L, W, H, Ori, Wt, MxQty, UQty)

                    '$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

                    'SrN = SrN
                    INm = INm
                    L = L
                    W = W
                    H = H
                    Ori = Ori
                    UQty = UQty

                    '================================================
                    Dim Qz As Int64 = 0
                    Dim Qy As Int64 = 0
                    Dim Qx As Int64 = 0

                    Dim Qzz As Double = 0
                    Dim Qyy As Double = 0
                    Dim Qxx As Double = 0

                    Dim FrcL As Int64 = 0
                    Dim Rcnt As Int64 = 0

                    '================================================

                    '****************************************************************

                    Dim Foptm As New OptMthd.OptMthd.FndOptMthd
                    Dim Bx As New OptMthd.OptMthd.FndOptMthd.Areas
                    Dim Cont As New OptMthd.OptMthd.FndOptMthd.Areas

                    Bx.length = L
                    Bx.width = W
                    Bx.height = H
                    Bx.StrtPt.x = 0
                    Bx.StrtPt.y = 0
                    Bx.StrtPt.z = 0

                    Cont.length = CL
                    Cont.width = CW
                    Cont.height = CH
                    Cont.StrtPt.x = 0
                    Cont.StrtPt.y = 0
                    Cont.StrtPt.z = 0

                    Dim ii As Integer = Foptm.FindOptMethod(Bx, Cont, FnlQty, False)

                    If UQty > 0 Then

                        Dim ln As Double = Bx.length
                        Dim wd As Double = Bx.width
                        Dim ht As Double = Bx.height

                        If ii = 1 Then
                            L = ln
                            W = wd
                            H = ht

                        End If

                        If ii = 2 Then
                            L = ln
                            W = ht
                            H = wd

                        End If

                        If ii = 3 Then
                            L = wd
                            W = ht
                            H = ln

                        End If

                        If ii = 4 Then
                            L = wd
                            W = ln
                            H = ht

                        End If

                        If ii = 5 Then
                            L = ht
                            W = wd
                            H = ln

                        End If

                        If ii = 6 Then
                            L = ht
                            W = ln
                            H = wd

                        End If

                    End If

                    ''****************************************************************

                    Dim fdM As New eCSP.HIL.Resolution

                    fdM.VI = CL
                    fdM.VII = L

                    Qxx = fdM.Part

                    fdM.VI = CW
                    fdM.VII = W

                    Qyy = fdM.Part

                    fdM.VI = CH
                    fdM.VII = H

                    Qzz = fdM.Part

                    fdM.VI = Qzz
                    Qz = fdM.Truncate()
                    fdM.VI = Qyy
                    Qy = fdM.Truncate
                    fdM.VI = Qxx
                    Qx = fdM.Truncate

                    fdM.VI = Qz
                    fdM.VII = Qy
                    FrcL = fdM.Swell

                    fdM.VI = UQty
                    fdM.VII = FrcL
                    Rcnt = fdM.Part

                    fdM.VI = Rcnt
                    fdM.VII = FrcL
                    FnlQty = fdM.Swell

                    fdM.VI = UQty
                    fdM.VII = FnlQty
                    RemnQty = fdM.WithTake

                    If RemnQty < 0 Then
                        RemnQty = -RemnQty
                    End If

                    If FnlQty = 0 Then

                        FnlQty = RemnQty
                        RemnQty = 0

                    End If

                    '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    'The final quantity is greater than the user enter quantity the logic to assign the final quantity and reamining quantity

                    'If FnlQty > UQty Then
                    '    FnlQty = UQty
                    '    RemnQty = 0
                    'Else
                    '    FnlQty = FnlQty
                    'End If

                    If FnlQty > UQty Then

                        Dim cQ As Double = UQty / FrcL

                        cQ = Math.Floor(cQ)

                        If Not cQ <= 0 Then

                            FnlQty = FrcL * cQ

                            RemnQty = UQty - FnlQty

                        ElseIf FnlQty > UQty Then

                            FnlQty = UQty
                            RemnQty = 0

                        End If
                    Else

                        FnlQty = FnlQty
                        RemnQty = RemnQty

                    End If

                    '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

                    ''-----------------------------------

                    'Me.DataGridViewButtonColumn1.HeaderText = "Show"
                    'Me.Column10.HeaderText = "MthQty"

                    '///////////////////////////////////////////////////

                    If Not (RemnQty <= 0) Then

                        'dgv1.Item(0, Dgn).Value = SN
                        dgv1.Item(1, Dgn).Value = INm
                        dgv1.Item(2, Dgn).Value = Pck
                        dgv1.Item(3, Dgn).Value = Sz
                        dgv1.Item(4, Dgn).Value = L
                        dgv1.Item(5, Dgn).Value = W
                        dgv1.Item(6, Dgn).Value = H
                        dgv1.Item(7, Dgn).Value = Ori
                        dgv1.Item(8, Dgn).Value = Wt
                        dgv1.Item(10, Dgn).Value = RemnQty
                        dgv1.Item(11, Dgn).Value = FnlQty

                    End If

                    'Dim Sat As AutoStuff
                    'Dim Scn As AutoStuffCmn

                    Sat.Srn = SrN
                    Sat.Inm = INm
                    Sat.Pck = Pck
                    Sat.Sz = Sz
                    Sat.L = L
                    Sat.W = W
                    Sat.H = H
                    Sat.Ori = Ori
                    Sat.Wt = Wt
                    Sat.RemnQty = RemnQty
                    Sat.FnlQty = FnlQty
                    Sat.qX = Qx
                    Sat.qY = Qy
                    Sat.qZ = Qz

                    Scn.srn = SrN
                    Scn.Inm = INm
                    Scn.Pck = Pck
                    Scn.Sz = Sz
                    Scn.L = L
                    Scn.W = W
                    Scn.H = H
                    Scn.Ori = Ori
                    Scn.Wt = Wt
                    Scn.RemnQty = RemnQty
                    Scn.FnlQty = FnlQty
                    Scn.qX = Qx
                    Scn.qY = Qy
                    Scn.qZ = Qz

                    ScnAut.Add(Scn)

                    If Not (RemnQty <= 0) Then

                        Sauto.Add(Sat)

                    End If

                    'Dim SnC As Integer = ScnAut.Count

                    'If Not SnC <= 0 Then

                    '    Dim i As Integer = 0
                    '    Dim qZs As Int64 = 0
                    '    Dim tQ As Int64 = 0
                    '    Dim div As Double = 0
                    '    Dim FacDiv As Int64 = 0
                    '    Dim rQ As Int64 = 0

                    '    For i = 0 To SnC - 1

                    '        qZs = ScnAut.Item(i).qZ
                    '        tQ = ScnAut.Item(i).FnlQty

                    '        div = tQ / qZs

                    '        FacDiv = Math.Floor(div)

                    '        rQ = qZs * FacDiv

                    '        rQ = tQ - rQ

                    '        tQ = tQ - rQ


                    '    Next

                    'End If


                    'Stop

                    '///////////////////////////////////////////////////

                    AutoStuffIns(SN, INm, L, W, H, Ori, FnlQty, Qz, Qy, Qx, FrcL, Rcnt, FnlQty, RemnQty)

                    '$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

                    SN = SN + 1
                    Dgn = Dgn + 1

                Loop

                'Stop

                'Dim SnC As Integer = ScnAut.Count

                'If Not SnC <= 0 Then

                '    Dim i As Integer = 0
                '    Dim qZ As Int64 = 0
                '    Dim tQ As Int64 = 0
                '    Dim div As Double = 0
                '    Dim FacDiv As Int64 = 0
                '    Dim rQ As Int64 = 0

                '    For i = 0 To SnC - 1

                '        qZ = ScnAut.Item(i).qZ
                '        tQ = ScnAut.Item(i).FnlQty

                '        div = tQ / qZ

                '        FacDiv = Math.Floor(div)

                '        rQ = qZ * FacDiv

                '        rQ = tQ - rQ

                '        tQ = tQ - rQ


                '    Next

                'End If

                'Stop

                Dim Dgrn As Integer = dgv1.RowCount - 1

                Dim SaN As Integer = Sauto.Count

                Dim K As Integer = 0
                Dim j As Integer = 0
                Dim Dgno As Integer = Dgrn

                If Not SaN <= 0 Then

                    Try

                        For K = 1 To SaN            'Dgrn

                            Dim Ll As Integer = dgv1.Rows.Add

                            dgv1.Rows(Ll).Cells(0).Value = Dgno + 1
                            dgv1.Rows(Ll).Cells(1).Value = Sauto.Item(j).Inm
                            dgv1.Rows(Ll).Cells(2).Value = Sauto.Item(j).Pck
                            dgv1.Rows(Ll).Cells(3).Value = Sauto.Item(j).Sz
                            dgv1.Rows(Ll).Cells(4).Value = Sauto.Item(j).L
                            dgv1.Rows(Ll).Cells(5).Value = Sauto.Item(j).W
                            dgv1.Rows(Ll).Cells(6).Value = Sauto.Item(j).H
                            dgv1.Rows(Ll).Cells(7).Value = Sauto.Item(j).Ori
                            dgv1.Rows(Ll).Cells(8).Value = Sauto.Item(j).Wt
                            dgv1.Rows(Ll).Cells(10).Value = 0
                            dgv1.Rows(Ll).Cells(11).Value = Sauto.Item(j).RemnQty
                            'dgv1.Rows(Ll).Visible = False

                            'Dim Scn As AutoStuffCmn

                            Scn.srn = Dgno + 1
                            Scn.Inm = Sauto.Item(j).Inm
                            Scn.Pck = Sauto.Item(j).Pck
                            Scn.Sz = Sauto.Item(j).Sz
                            Scn.L = Sauto.Item(j).L
                            Scn.W = Sauto.Item(j).W
                            Scn.H = Sauto.Item(j).H
                            Scn.Ori = Sauto.Item(j).Ori
                            Scn.Wt = Sauto.Item(j).Wt
                            Scn.RemnQty = 0
                            Scn.FnlQty = Sauto.Item(j).RemnQty
                            Scn.qX = Sauto.Item(j).qX
                            Scn.qY = Sauto.Item(j).qY
                            Scn.qZ = Sauto.Item(j).qZ

                            ScnAut.Add(Scn)

                            Ll += 1

                            Dgno += 1
                            j += 1

                        Next K

                    Catch
                    End Try

                End If

                'Stop

                Sauto.Clear()

                Dim SnC As Integer = ScnAut.Count

                If Not SnC <= 0 Then

                    Dim i As Integer = 0
                    Dim qZ As Int64 = 0
                    Dim tQ As Int64 = 0
                    Dim div As Double = 0
                    Dim FacDiv As Int64 = 0
                    Dim rQ As Int64 = 0

                    For i = 0 To SnC - 1

                        If ScnAut.Item(i).RemnQty = 0 Then

                            qZ = ScnAut.Item(i).qZ
                            tQ = ScnAut.Item(i).FnlQty

                            div = tQ / qZ

                            FacDiv = Math.Floor(div)

                            rQ = qZ * FacDiv

                            rQ = tQ - rQ

                            tQ = tQ - rQ

                            Dim Frc As AutoStuffCmn

                            Frc.srn = ScnAut.Item(i).srn
                            Frc.Inm = ScnAut.Item(i).Inm
                            Frc.Pck = ScnAut.Item(i).Pck
                            Frc.Sz = ScnAut.Item(i).Sz
                            Frc.L = ScnAut.Item(i).L
                            Frc.W = ScnAut.Item(i).W
                            Frc.H = ScnAut.Item(i).H
                            Frc.Ori = ScnAut.Item(i).Ori
                            Frc.Wt = ScnAut.Item(i).Wt
                            Frc.RemnQty = rQ
                            Frc.FnlQty = tQ
                            Frc.qX = ScnAut.Item(j).qX
                            Frc.qY = ScnAut.Item(j).qY
                            Frc.qZ = ScnAut.Item(j).qZ

                            FdAut.Add(Frc)

                        ElseIf Not (ScnAut.Item(i).RemnQty = 0) Then

                            Dim Ffc As AutoStuffCmn

                            Ffc.srn = ScnAut.Item(i).srn
                            Ffc.Inm = ScnAut.Item(i).Inm
                            Ffc.Pck = ScnAut.Item(i).Pck
                            Ffc.Sz = ScnAut.Item(i).Sz
                            Ffc.L = ScnAut.Item(i).L
                            Ffc.W = ScnAut.Item(i).W
                            Ffc.H = ScnAut.Item(i).H
                            Ffc.Ori = ScnAut.Item(i).Ori
                            Ffc.Wt = ScnAut.Item(i).Wt
                            Ffc.RemnQty = 0
                            Ffc.FnlQty = ScnAut.Item(i).FnlQty
                            Ffc.qX = ScnAut.Item(j).qX
                            Ffc.qY = ScnAut.Item(j).qY
                            Ffc.qZ = ScnAut.Item(j).qZ

                            FdAut.Add(Ffc)

                        End If


                    Next

                End If

                Sauto.Clear()

                Dim FnC As Integer = FdAut.Count

                Dim pp As Integer

                For pp = 0 To FnC - 1

                    If Not (FdAut.Item(pp).RemnQty = 0) Then

                        Dim rz As AutoStuffCmn

                        rz.srn = FdAut.Item(pp).srn
                        rz.Inm = FdAut.Item(pp).Inm
                        rz.Pck = FdAut.Item(pp).Pck
                        rz.Sz = FdAut.Item(pp).Sz
                        rz.L = FdAut.Item(pp).L
                        rz.W = FdAut.Item(pp).W
                        rz.H = FdAut.Item(pp).H
                        rz.Ori = FdAut.Item(pp).Ori
                        rz.Wt = FdAut.Item(pp).Wt
                        rz.RemnQty = 0
                        rz.FnlQty = FdAut.Item(pp).RemnQty
                        rz.qX = FdAut.Item(pp).qX
                        rz.qY = FdAut.Item(pp).qY
                        rz.qZ = FdAut.Item(pp).qZ

                        FdAut.Add(rz)

                    End If

                Next

                Dim indx As Integer = (Dgrn + SaN) - 1

                Dim ndgv As Integer = FdAut.Count - 1

                For ll As Integer = 0 To ndgv

                    dgv1.Rows(ll).Cells(0).Value = FdAut.Item(ll).srn
                    dgv1.Rows(ll).Cells(1).Value = FdAut.Item(ll).Inm
                    dgv1.Rows(ll).Cells(2).Value = FdAut.Item(ll).Pck
                    dgv1.Rows(ll).Cells(3).Value = FdAut.Item(ll).Sz
                    dgv1.Rows(ll).Cells(4).Value = FdAut.Item(ll).L
                    dgv1.Rows(ll).Cells(5).Value = FdAut.Item(ll).W
                    dgv1.Rows(ll).Cells(6).Value = FdAut.Item(ll).H
                    dgv1.Rows(ll).Cells(7).Value = FdAut.Item(ll).Ori
                    dgv1.Rows(ll).Cells(8).Value = FdAut.Item(ll).Wt
                    dgv1.Rows(ll).Cells(10).Value = 0
                    dgv1.Rows(ll).Cells(11).Value = FdAut.Item(ll).FnlQty

                    If (indx) <= ll Then
                        Dim Lls As Integer = dgv1.Rows.Add
                    End If

                Next

            Catch ex As Exception
                MsgBox(ex.Message)
                MsgBox(ex.ToString)
                MessageBox.Show("Error in FlowDgvDataMngAutoStuff", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Cons.Close()
            End Try

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in FlowDgvDataMngAutoStuff", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub FlowDgvDataMngAutoStuff()

        Try
            Dim Dgn As Integer = 0
            Dim SrN As Int32 = 0
            Dim INm As String = Nothing
            Dim Pck As String = Nothing
            Dim Sz As Double = 0
            Dim L As Double = 0
            Dim W As Double = 0
            Dim H As Double = 0
            Dim Ori As Int16 = 0
            Dim Wt As Double = 0
            Dim MxQty As Int32 = 0
            Dim UQty As Int32 = 0
            Dim FnlQty As Int64 = 0
            Dim RemnQty As Int64 = 0

            Dim Sat As AutoStuff
            Dim Scn As AutoStuffCmn

            Try

                If Cons.State = ConnectionState.Closed Then Cons.Open()
                Dim Cmds As New OleDb.OleDbCommand
                Dim Rdrs As OleDb.OleDbDataReader
                Cmds.Connection = Cons

                'Cmds.CommandText = "Select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA order by MaxQty desc"
                'Cmds.CommandText = "Select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA order by Qty desc, Sizes desc, Wt desc"

                If Rdb1.Checked = True Then
                    Cmds.CommandText = "Select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA order by Qty desc"
                ElseIf Rdb2.Checked = True Then
                    Cmds.CommandText = "Select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA order by Qty asc"
                ElseIf Rdb3.Checked = True Then
                    Cmds.CommandText = "Select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA order by Wt desc"
                ElseIf Rdb4.Checked = True Then
                    Cmds.CommandText = "Select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA order by Wt asc"
                ElseIf Rdb5.Checked = True Then
                    Cmds.CommandText = "Select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA order by Height desc"
                ElseIf Rdb6.Checked = True Then
                    Cmds.CommandText = "Select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA order by Height asc"
                ElseIf Rdb7.Checked = True Then
                    Cmds.CommandText = "Select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA order by Width desc"
                ElseIf Rdb8.Checked = True Then
                    Cmds.CommandText = "Select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA order by Width asc"
                ElseIf Rdb9.Checked = True Then
                    Cmds.CommandText = "Select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA order by Length desc"
                ElseIf Rdb10.Checked = True Then
                    Cmds.CommandText = "Select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA order by Length asc"
                ElseIf Rdb11.Checked = True Then
                    Cmds.CommandText = "Select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA order by Sizes desc"
                ElseIf Rdb12.Checked = True Then
                    Cmds.CommandText = "Select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA order by Sizes asc"
                ElseIf Rdb13.Checked = True Then
                    Cmds.CommandText = "Select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA order by ItmName desc"
                ElseIf Rdb14.Checked = True Then
                    Cmds.CommandText = "Select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA order by ItmName asc"
                ElseIf Rdb15.Checked = True Then
                    Cmds.CommandText = "Select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA order by SrNo desc"
                ElseIf Rdb16.Checked = True Then
                    Cmds.CommandText = "Select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA order by SrNo asc"
                Else
                    Cmds.CommandText = "Select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA"
                End If

                Rdrs = Cmds.ExecuteReader

                Do While (Rdrs.Read())

                    SrN = Rdrs("SrNo")
                    INm = Rdrs("ItmName")
                    Pck = Rdrs("Pack")
                    Sz = Rdrs("Sizes")
                    L = Rdrs("Length")
                    W = Rdrs("width")
                    H = Rdrs("height")
                    Ori = Rdrs("orient")
                    Wt = Rdrs("Wt")
                    MxQty = Rdrs("MaxQty")
                    UQty = Rdrs("Qty")

                    'dgv1.Item(0, Dgn).Value = SN
                    dgv1.Item(1, Dgn).Value = INm
                    dgv1.Item(2, Dgn).Value = Pck
                    dgv1.Item(3, Dgn).Value = Sz
                    dgv1.Item(4, Dgn).Value = L
                    dgv1.Item(5, Dgn).Value = W
                    dgv1.Item(6, Dgn).Value = H
                    dgv1.Item(7, Dgn).Value = Ori
                    dgv1.Item(8, Dgn).Value = Wt
                    dgv1.Item(10, Dgn).Value = MxQty
                    dgv1.Item(11, Dgn).Value = UQty

                    DbTrackDupIns(SN, INm, Pck, Sz, L, W, H, Ori, Wt, MxQty, UQty)

                    '$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

                    'SrN = SrN
                    INm = INm
                    L = L
                    W = W
                    H = H
                    Ori = Ori
                    UQty = UQty

                    '================================================
                    Dim Qz As Int64 = 0
                    Dim Qy As Int64 = 0
                    Dim Qx As Int64 = 0

                    Dim Qzz As Double = 0
                    Dim Qyy As Double = 0
                    Dim Qxx As Double = 0

                    Dim FrcL As Int64 = 0
                    Dim Rcnt As Int64 = 0

                    '================================================

                    '****************************************************************

                    Dim Foptm As New OptMthd.OptMthd.FndOptMthd
                    Dim Bx As New OptMthd.OptMthd.FndOptMthd.Areas
                    Dim Cont As New OptMthd.OptMthd.FndOptMthd.Areas

                    Bx.length = L
                    Bx.width = W
                    Bx.height = H
                    Bx.StrtPt.x = 0
                    Bx.StrtPt.y = 0
                    Bx.StrtPt.z = 0

                    Cont.length = CL
                    Cont.width = CW
                    Cont.height = CH
                    Cont.StrtPt.x = 0
                    Cont.StrtPt.y = 0
                    Cont.StrtPt.z = 0

                    Dim ii As Integer = Foptm.FindOptMethod(Bx, Cont, FnlQty, False)

                    If UQty > 0 Then

                        Dim ln As Double = Bx.length
                        Dim wd As Double = Bx.width
                        Dim ht As Double = Bx.height

                        If ii = 1 Then
                            L = ln
                            W = wd
                            H = ht

                        End If

                        If ii = 2 Then
                            L = ln
                            W = ht
                            H = wd

                        End If

                        If ii = 3 Then
                            L = wd
                            W = ht
                            H = ln

                        End If

                        If ii = 4 Then
                            L = wd
                            W = ln
                            H = ht

                        End If

                        If ii = 5 Then
                            L = ht
                            W = wd
                            H = ln

                        End If

                        If ii = 6 Then
                            L = ht
                            W = ln
                            H = wd

                        End If

                    End If


                    ''****************************************************************

                    Dim fdM As New eCSP.HIL.Resolution

                    fdM.VI = CL
                    fdM.VII = L

                    Qxx = fdM.Part

                    fdM.VI = CW
                    fdM.VII = W

                    Qyy = fdM.Part

                    fdM.VI = CH
                    fdM.VII = H

                    Qzz = fdM.Part

                    fdM.VI = Qzz
                    Qz = fdM.Truncate()

                    fdM.VI = Qyy
                    Qy = fdM.Truncate

                    fdM.VI = Qxx
                    Qx = fdM.Truncate

                    fdM.VI = Qz
                    fdM.VII = Qy
                    FrcL = fdM.Swell

                    fdM.VI = UQty
                    fdM.VII = FrcL
                    Rcnt = fdM.Part

                    fdM.VI = Rcnt
                    fdM.VII = FrcL
                    FnlQty = fdM.Swell

                    fdM.VI = UQty
                    fdM.VII = FnlQty
                    RemnQty = fdM.WithTake

                    If RemnQty < 0 Then
                        RemnQty = -RemnQty
                    End If

                    If FnlQty = 0 Then
                        FnlQty = RemnQty
                        RemnQty = 0
                    End If

                    '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    'The final quantity is greater than the user enter quantity the logic to assign the final quantity and reamining quantity

                    'If FnlQty > UQty Then
                    '    FnlQty = UQty
                    '    RemnQty = 0
                    'Else
                    '    FnlQty = FnlQty
                    'End If

                    If FnlQty > UQty Then

                        Dim cQ As Double = UQty / FrcL

                        cQ = Math.Floor(cQ)

                        If Not cQ <= 0 Then

                            FnlQty = FrcL * cQ

                            RemnQty = UQty - FnlQty

                        ElseIf FnlQty > UQty Then

                            FnlQty = UQty
                            RemnQty = 0

                        End If


                    Else

                        FnlQty = FnlQty
                        RemnQty = RemnQty

                    End If

                    '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

                    ''-----------------------------------

                    'Me.DataGridViewButtonColumn1.HeaderText = "Show"
                    'Me.Column10.HeaderText = "MthQty"

                    '///////////////////////////////////////////////////

                    If Not (RemnQty <= 0) Then

                        'dgv1.Item(0, Dgn).Value = SN
                        dgv1.Item(1, Dgn).Value = INm
                        dgv1.Item(2, Dgn).Value = Pck
                        dgv1.Item(3, Dgn).Value = Sz
                        dgv1.Item(4, Dgn).Value = L
                        dgv1.Item(5, Dgn).Value = W
                        dgv1.Item(6, Dgn).Value = H
                        dgv1.Item(7, Dgn).Value = Ori
                        dgv1.Item(8, Dgn).Value = Wt
                        dgv1.Item(10, Dgn).Value = RemnQty
                        dgv1.Item(11, Dgn).Value = FnlQty

                    End If

                    'Dim Sat As AutoStuff
                    'Dim Scn As AutoStuffCmn

                    Sat.Srn = SrN
                    Sat.Inm = INm
                    Sat.Pck = Pck
                    Sat.Sz = Sz
                    Sat.L = L
                    Sat.W = W
                    Sat.H = H
                    Sat.Ori = Ori
                    Sat.Wt = Wt
                    Sat.RemnQty = RemnQty
                    Sat.FnlQty = FnlQty

                    Scn.srn = SrN
                    Scn.Inm = INm
                    Scn.Pck = Pck
                    Scn.Sz = Sz
                    Scn.L = L
                    Scn.W = W
                    Scn.H = H
                    Scn.Ori = Ori
                    Scn.Wt = Wt
                    Scn.RemnQty = RemnQty
                    Scn.FnlQty = FnlQty
                    Scn.qX = Qx
                    Scn.qY = Qy
                    Scn.qZ = Qz

                    If Not (RemnQty <= 0) Then

                        Sauto.Add(Sat)

                    Else

                        ScnAut.Add(Scn)

                    End If



                    'Dim SnC As Integer = ScnAut.Count

                    'If Not SnC <= 0 Then

                    '    Dim i As Integer = 0
                    '    Dim qZs As Int64 = 0
                    '    Dim tQ As Int64 = 0
                    '    Dim div As Double = 0
                    '    Dim FacDiv As Int64 = 0
                    '    Dim rQ As Int64 = 0

                    '    For i = 0 To SnC - 1

                    '        qZs = ScnAut.Item(i).qZ
                    '        tQ = ScnAut.Item(i).FnlQty

                    '        div = tQ / qZs

                    '        FacDiv = Math.Floor(div)

                    '        rQ = qZs * FacDiv

                    '        rQ = tQ - rQ

                    '        tQ = tQ - rQ


                    '    Next

                    'End If


                    'Stop

                    '///////////////////////////////////////////////////

                    AutoStuffIns(SN, INm, L, W, H, Ori, FnlQty, Qz, Qy, Qx, FrcL, Rcnt, FnlQty, RemnQty)

                    '$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

                    SN = SN + 1
                    Dgn = Dgn + 1

                Loop

                'Stop

                'Dim SnC As Integer = ScnAut.Count

                'If Not SnC <= 0 Then

                '    Dim i As Integer = 0
                '    Dim qZ As Int64 = 0
                '    Dim tQ As Int64 = 0
                '    Dim div As Double = 0
                '    Dim FacDiv As Int64 = 0
                '    Dim rQ As Int64 = 0

                '    For i = 0 To SnC - 1

                '        qZ = ScnAut.Item(i).qZ
                '        tQ = ScnAut.Item(i).FnlQty

                '        div = tQ / qZ

                '        FacDiv = Math.Floor(div)

                '        rQ = qZ * FacDiv

                '        rQ = tQ - rQ

                '        tQ = tQ - rQ






                '    Next

                'End If


                Dim Dgrn As Integer = dgv1.RowCount - 1

                Dim SaN As Integer = Sauto.Count

                Dim K As Integer = 0
                Dim j As Integer = 0
                Dim Dgno As Integer = Dgrn

                If Not SaN <= 0 Then

                    Try

                        For K = 1 To SaN            'Dgrn

                            Dim Ll As Integer = dgv1.Rows.Add

                            dgv1.Rows(Ll).Cells(0).Value = Dgno + 1
                            dgv1.Rows(Ll).Cells(1).Value = Sauto.Item(j).Inm
                            dgv1.Rows(Ll).Cells(2).Value = Sauto.Item(j).Pck
                            dgv1.Rows(Ll).Cells(3).Value = Sauto.Item(j).Sz
                            dgv1.Rows(Ll).Cells(4).Value = Sauto.Item(j).L
                            dgv1.Rows(Ll).Cells(5).Value = Sauto.Item(j).W
                            dgv1.Rows(Ll).Cells(6).Value = Sauto.Item(j).H
                            dgv1.Rows(Ll).Cells(7).Value = Sauto.Item(j).Ori
                            dgv1.Rows(Ll).Cells(8).Value = Sauto.Item(j).Wt
                            dgv1.Rows(Ll).Cells(10).Value = 0
                            dgv1.Rows(Ll).Cells(11).Value = Sauto.Item(j).RemnQty
                            'dgv1.Rows(Ll).Visible = False
                            Ll += 1

                            Dgno += 1
                            j += 1

                            'Dim Scn As AutoStuffCmn

                            'Scn.srn = SrN
                            'Scn.Inm = INm
                            'Scn.Pck = Pck
                            'Scn.Sz = Sz
                            'Scn.L = L
                            'Scn.W = W
                            'Scn.H = H
                            'Scn.Ori = Ori
                            'Scn.Wt = Wt
                            'Scn.RemnQty = RemnQty
                            'Scn.FnlQty = FnlQty
                            'Scn.qX = Qx
                            'Scn.qY = Qy
                            'Scn.qZ = Qz


                            'ScnAut.Add(Scn)

                        Next K

                    Catch
                    End Try

                End If

                'Stop

                DeleteDataBaseAutoStuffFinal()

                For mm As Integer = 0 To dgv1.RowCount - 2

                    Dim srns As Integer = dgv1(0, mm).Value
                    Dim inms As String = dgv1(1, mm).Value
                    Dim pcks As String = dgv1(2, mm).Value
                    Dim szs As Double = dgv1(3, mm).Value
                    Dim lns As Double = dgv1(4, mm).Value
                    Dim wds As Double = dgv1(5, mm).Value
                    Dim hts As Double = dgv1(6, mm).Value
                    Dim oris As Integer = dgv1(7, mm).Value
                    Dim wts As Double = dgv1(8, mm).Value
                    Dim mxqts As Integer = dgv1(10, mm).Value
                    Dim qts As Integer = dgv1(11, mm).Value

                    Call FinalAutostuffDataEnter(srns, inms, pcks, szs, lns, wds, hts, oris, wts, mxqts, qts)

                Next

            Catch ex As Exception
                MsgBox(ex.Message)
                MsgBox(ex.ToString)
                MessageBox.Show("Error in FlowDgvDataMngAutoStuff", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Cons.Close()
            End Try

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in FlowDgvDataMngAutoStuff", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub DeleteDataBaseAutoStuffFinal()

        Try

            Dim cmd As New OleDb.OleDbCommand
            If conn.State = ConnectionState.Closed Then conn.Open()
            cmd.Connection = conn
            cmd.CommandText = "delete from BoxaADpt"
            cmd.ExecuteNonQuery()

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in DeleteDataBaseAutoStuffFinal", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub FinalAutostuffDataEnter(ByVal srn As Integer, ByVal inm As String, ByVal pck As String, ByVal sz As Double, ByVal l As Double, ByVal w As Double, ByVal h As Double, ByVal ori As Integer, ByVal wt As Double, ByVal maxqty As Integer, ByVal qty As Integer)

        Try

            l = Format(l, "0.00")
            w = Format(w, "0.00")
            h = Format(h, "0.00")

            Dim cmds As New OleDb.OleDbCommand
            cmds.Connection = conn
            cmds.CommandText = "insert into BoxaADpt values(" & srn & ",'" & inm & "','" & pck & "'," & sz & "," & l & "," & w & "," & h & "," & ori & "," & wt & "," & maxqty & "," & qty & ")"
            cmds.ExecuteNonQuery()

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in FinalAutostuffDataEnter", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    ' User entering the container and goods and goods quantity the manipulation of container 
    ' dimensions with goods dimensions to find out the particular quantity in random to properly
    ' arrange it in to container and it’s shown to data grid of transaction form.

    Public Sub FlowDgvDataMng()

        'Stop

        Try
            Dim Dgn As Integer = 0
            Dim SrN As Int32 = 0
            Dim INm As String = Nothing
            Dim Pck As String = Nothing
            Dim Sz As Double = 0
            Dim L As Double = 0
            Dim W As Double = 0
            Dim H As Double = 0
            Dim Ori As Int16 = 0
            Dim Wt As Double = 0
            Dim MxQty As Int32 = 0
            Dim UQty As Int32 = 0

            Try

                If Cons.State = ConnectionState.Closed Then Cons.Open()
                Dim cmds As New OleDb.OleDbCommand
                Dim Rdrs As OleDb.OleDbDataReader
                cmds.Connection = Cons

                cmds.CommandText = "select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA order by MaxQty desc"
                Rdrs = cmds.ExecuteReader

                Do While (Rdrs.Read())

                    SrN = Rdrs("SrNo")
                    INm = Rdrs("ItmName")
                    Pck = Rdrs("Pack")
                    Sz = Rdrs("Sizes")
                    L = Rdrs("Length")
                    W = Rdrs("Width")
                    H = Rdrs("Height")
                    Ori = Rdrs("Orient")
                    Wt = Rdrs("Wt")
                    MxQty = Rdrs("MaxQty")
                    UQty = Rdrs("Qty")

                    'dgv1.Item(0, Dgn).Value = SN
                    dgv1.Item(1, Dgn).Value = INm
                    dgv1.Item(2, Dgn).Value = Pck
                    dgv1.Item(3, Dgn).Value = Sz
                    dgv1.Item(4, Dgn).Value = L
                    dgv1.Item(5, Dgn).Value = W
                    dgv1.Item(6, Dgn).Value = H
                    dgv1.Item(7, Dgn).Value = Ori
                    dgv1.Item(8, Dgn).Value = Wt
                    dgv1.Item(10, Dgn).Value = MxQty
                    dgv1.Item(11, Dgn).Value = UQty

                    DbTrackDupIns(SN, INm, Pck, Sz, L, W, H, Ori, Wt, MxQty, UQty)

                    '$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

                    'SrN = SrN
                    INm = INm
                    L = L
                    W = W
                    H = H
                    Ori = Ori
                    UQty = UQty

                    '================================================
                    Dim Qz As Int64 = 0
                    Dim Qy As Int64 = 0
                    Dim Qx As Int64 = 0

                    Dim Qzz As Double = 0
                    Dim Qyy As Double = 0
                    Dim Qxx As Double = 0

                    Dim FrcL As Int64 = 0
                    Dim Rcnt As Int64 = 0
                    Dim FnlQty As Int64 = 0
                    Dim RemnQty As Int64 = 0
                    '================================================

                    Qzz = CH / L
                    Qyy = CW / W
                    Qxx = CL / H

                    Qz = Math.Floor(Qzz)
                    Qy = Math.Floor(Qyy)
                    Qx = Math.Floor(Qxx)

                    FrcL = Qz * Qy
                    Rcnt = UQty / FrcL
                    FnlQty = Rcnt * FrcL
                    RemnQty = UQty - FnlQty

                    If RemnQty < 0 Then
                        RemnQty = -RemnQty
                    End If

                    If FnlQty = 0 Then

                        FnlQty = RemnQty

                    End If

                  ''Satwadhir Pawar 9/17/2005 7:11:27 PM
                    ''-----------------------------------

                    If FnlQty > UQty Then
                        FnlQty = UQty
                        RemnQty = 0
                    Else
                        FnlQty = FnlQty
                    End If

                    ''-----------------------------------

                    'Me.DataGridViewButtonColumn1.HeaderText = "Show"
                    'Me.Column10.HeaderText = "MthQty"

                    '///////////////////////////////////////////////////

                    'dgv1.Item(0, Dgn).Value = SN
                    dgv1.Item(1, Dgn).Value = INm
                    dgv1.Item(2, Dgn).Value = Pck
                    dgv1.Item(3, Dgn).Value = Sz
                    dgv1.Item(4, Dgn).Value = L
                    dgv1.Item(5, Dgn).Value = W
                    dgv1.Item(6, Dgn).Value = H
                    dgv1.Item(7, Dgn).Value = Ori
                    dgv1.Item(8, Dgn).Value = Wt
                    dgv1.Item(10, Dgn).Value = RemnQty
                    dgv1.Item(11, Dgn).Value = FnlQty

                    '///////////////////////////////////////////////////

                    AutoStuffIns(SN, INm, L, W, H, Ori, FnlQty, Qz, Qy, Qx, FrcL, Rcnt, FnlQty, RemnQty)

                    'Public Sub AutoStuffIns(ByVal SrN As Integer, ByVal INm As String, ByVal L As Double, ByVal W As Double, ByVal H As Double, ByVal Orint As Integer, ByVal Qty As Integer, ByVal Qz As Integer, ByVal Qy As Integer, ByVal Qx As Integer, ByVal FcrL As Integer, ByVal RowCont As Integer, ByVal FnlQtys As Integer, ByVal RemnQtys As Integer)

                    '$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

                    SN = SN + 1
                    Dgn = Dgn + 1
                Loop

            Catch Err As Exception
                MsgBox(Err.Message)
                MsgBox(Err.ToString)
                MessageBox.Show("Error in FlowDgvDataMng", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Cons.Close()
            End Try

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in FlowDgvDataMng", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged

        Try
            chkBxAutoStuff.Checked = False
            chkBxSlideStuff.Checked = False
            chkbxOptStuff.Checked = False
            chkBxPlyStuff.Checked = False
        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in CheckBox1_CheckedChanged", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub chkbxOptStuff_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkbxOptStuff.CheckedChanged

        Try
            chkBxAutoStuff.Checked = False
            chkBxSlideStuff.Checked = False
            CheckBox1.Checked = False
            chkBxPlyStuff.Checked = False

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in chkbxOptStuff_CheckedChanged", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub chkBxPlyStuff_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBxPlyStuff.CheckedChanged

        Try

            chkBxAutoStuff.Checked = False
            chkBxSlideStuff.Checked = False
            CheckBox1.Checked = False
            chkbxOptStuff.Checked = False

        Catch Erx As Exception
            MsgBox(Erx.Message)
            MsgBox(Erx.ToString)
            MessageBox.Show("Error in chkBxPlyStuff_CheckedChanged", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub chkbxManualChng_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkbxManualChng.CheckedChanged

        'Try
        '    If Not SlidStfPosFlg Then

        '        gbPositionChangeBox.Enabled = True
        '        SlidStfPosFlg = True

        '    Else
        '        gbPositionChangeBox.Enabled = False
        '        SlidStfPosFlg = False
        '    End If


        'Catch Ex As Exception
        '    MsgBox(Ex.Message)
        '    MsgBox(Ex.ToString)
        '    MessageBox.Show("Error in chkbxManualChng_CheckedChanged", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try

    End Sub

#End Region

    Private Sub tslblSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tslblSave.Click

        Try
            saveData()

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in Save", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnSave.Click

        Try
            saveData()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in SaveData", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub saveData()

        Try
            If MsgBox("Do you want to save this record?", MsgBoxStyle.Information + vbYesNo, "Stuffing Entry") = MsgBoxResult.Yes Then
                Dim strSQL As String
                Dim comm As New SDO.OleDbCommand
                Dim maxqty1 As Integer
                Dim qty1 As Integer
                For i As Integer = 0 To dgv1.RowCount - 2
                    If TypeOf (dgv1.Item(11, i).Value) Is DBNull Then
                        MsgBox("Invalid quantity at row " & (i + 1).ToString, MsgBoxStyle.Critical + vbOKOnly)
                        Exit Sub
                    Else
                        If Not IsNumeric(dgv1.Item(11, i).Value) Then
                            MsgBox("Invalid quantity at row " & (i + 1).ToString, MsgBoxStyle.Critical + vbOKOnly)
                            Exit Sub
                        End If
                    End If
                Next
                If CmbContainer.Text = "" Then
                    MsgBox("Please Select Container Name", MsgBoxStyle.Information + vbOKOnly, "Stuffing Entry")
                    addenable()
                    CmbContainer.Focus()
                    Exit Sub
                End If
                If conn.State = ConnectionState.Closed Then conn.Open()
                If Str = "Add" Then
                    For i As Integer = 0 To dgv1.RowCount - 2
                        maxqty1 = dgv1.Item(9, i).Value
                        qty1 = dgv1.Item(11, i).Value
                        strSQL = "insert into Ninwarddetail values(" & TxtRecNo.Text & ",#" & DtReceipt.Value & "#,'" & CmbContainer.Text & "'," & _
                        dgv1.Item(0, i).Value & ",'" & dgv1.Item(1, i).Value & "','" & dgv1.Item(2, i).Value & "'," & dgv1.Item(3, i).Value & "," & _
                        dgv1.Item(4, i).Value & "," & dgv1.Item(5, i).Value & "," & dgv1.Item(6, i).Value & "," & maxqty1 & "," & qty1 & _
                        "," & dgv1.Item(7, i).Value & "," & dgv1.Item(8, i).Value & ")"
                        comm.Connection = conn
                        comm.CommandText = strSQL
                        comm.ExecuteNonQuery()
                    Next
                    getAllReceiptNo()
                    Introw = Ds1.Tables!TabIHead.Rows.Count - 1
                    'TxtBind()
                    'conn.close()
                    BFlag = False
                    Call saveenable()

                    MessageBox.Show("Successful the save activity", "P-Stuff info.....", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ElseIf Str = "Edit" Then
                    strSQL = "delete from NInwardDetail where receiptno = " & TxtRecNo.Text
                    comm.Connection = conn
                    comm.CommandText = strSQL
                    If conn.State = ConnectionState.Closed Then conn.Open()
                    comm.ExecuteNonQuery()
                    'conn.close()
                    Str = "Add"
                    Call cmdUpdate_Click(Nothing, Nothing)
                End If
            Else
                MessageBox.Show("Fail the save activity", "P-Stuff info.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in SaveData", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub TransactionMenu_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize

        Try
            pbCSP1.Width = 213
            pbCSP1.Height = 11
            Me.StartPosition = FormStartPosition.CenterScreen

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in resize the menu", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    'Private Sub dgv1_CellLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv1.CellLeave
    '    If dgv1.CurrentCell.ColumnIndex = 11 Then
    '        MsgBox(dgv1.CurrentCell.Value)
    '        dgv1.CurrentCell.Value = CInt(dgv1.CurrentCell.Value)
    '    End If

    'End Sub

    Public UCvt As New List(Of UnitsConvt)

    Public Structure UnitsConvt

        Dim Srn As Integer
        Dim Inm As String
        Dim Pck As String
        Dim Sz As Double
        Dim Ln As Double
        Dim Wd As Double
        Dim Ht As Double
        Dim Ori As Integer
        Dim Wt As Double
        Dim maxQt As Integer
        Dim Qty As Integer

    End Structure

    'Private Sub chkBxMetricUnits_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBxMetricUnits.CheckedChanged

    '    Try
    '        If chkBxMetricUnits.Checked = True Then
    '            chkBxEnglishUnits.Checked = False
    '            chkBxMetricUnits.Checked = True
    '        Else
    '            chkBxEnglishUnits.Checked = True
    '            chkBxMetricUnits.Checked = False
    '        End If

    '    Catch Ex As Exception
    '        MsgBox(Ex.Message)
    '        MsgBox(Ex.ToString)
    '        MessageBox.Show("Error in Unit conversion", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try

    'End Sub

    'Private Sub chkBxEnglishUnits_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBxEnglishUnits.CheckedChanged

    '    Try

    '        If chkBxEnglishUnits.Checked = True Then
    '            chkBxMetricUnits.Checked = False
    '            chkBxEnglishUnits.Checked = True
    '        Else
    '            chkBxMetricUnits.Checked = True
    '            chkBxEnglishUnits.Checked = False
    '        End If

    '    Catch Ex As Exception
    '        MsgBox(Ex.Message)
    '        MsgBox(Ex.ToString)
    '        MessageBox.Show("Error in Unit conversion", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try

    'End Sub

    'Private Sub chkBxMetricUnits_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles chkBxMetricUnits.MouseClick

    '    Try

    '        UCvt.Clear()

    '        If MetUnFlg = False Then

    '            MetUnFlg = True
    '            EngUnFlg = False

    '            If chkBxEnglishUnits.CheckState = CheckState.Checked Then
    '                chkBxEnglishUnits.Checked = False
    '            Else
    '                chkBxMetricUnits.Checked = True
    '                lblUnitsDisplay.Text = "All Dimensions Are In Millimeters"
    '                lblOccupied.Text = "Cu. MM."
    '                lblFree.Text = "Cu. MM."
    '                lblOccupied.Refresh()
    '                lblFree.Refresh()

    '                Dim SrNo As Integer = 0
    '                Dim ItmNm As String = Nothing
    '                Dim Pck As String = Nothing
    '                Dim Sz As Double
    '                Dim Ln As Double
    '                Dim Wd As Double
    '                Dim Ht As Double
    '                Dim Ori As Integer
    '                Dim Wt As Double
    '                Dim mxQt As Integer
    '                Dim Qts As Integer

    '                For Rg = 0 To dgv1.RowCount - 2

    '                    Dim UnVal As UnitsConvt

    '                    SrNo = dgv1.Item(0, Rg).Value
    '                    ItmNm = dgv1.Item(1, Rg).Value
    '                    Pck = dgv1.Item(2, Rg).Value
    '                    Sz = dgv1.Item(3, Rg).Value
    '                    Ln = dgv1.Item(4, Rg).Value
    '                    Wd = dgv1.Item(5, Rg).Value
    '                    Ht = dgv1.Item(6, Rg).Value
    '                    Ori = dgv1.Item(7, Rg).Value
    '                    Wt = dgv1.Item(8, Rg).Value
    '                    mxQt = dgv1.Item(10, Rg).Value
    '                    Qts = dgv1.Item(11, Rg).Value

    '                    'Stop
    '                    UnVal.Srn = SrNo
    '                    UnVal.Inm = ItmNm
    '                    UnVal.Pck = Pck
    '                    UnVal.Sz = Sz * (25.4 * 25.4 * 25.4)
    '                    UnVal.Ln = Ln * 25.4
    '                    UnVal.Wd = Wd * 25.4
    '                    UnVal.Ht = Ht * 25.4
    '                    UnVal.Ori = Ori
    '                    UnVal.Wt = Wt
    '                    UnVal.maxQt = mxQt
    '                    UnVal.Qty = Qts

    '                    UCvt.Add(UnVal)

    '                Next

    '                For Rg = 0 To dgv1.RowCount - 2

    '                    dgv1.Item(0, Rg).Value = UCvt(Rg).Srn
    '                    dgv1.Item(1, Rg).Value = UCvt(Rg).Inm
    '                    dgv1.Item(2, Rg).Value = UCvt(Rg).Pck
    '                    dgv1.Item(3, Rg).Value = UCvt(Rg).Sz
    '                    dgv1.Item(4, Rg).Value = UCvt(Rg).Ln
    '                    dgv1.Item(5, Rg).Value = UCvt(Rg).Wd
    '                    dgv1.Item(6, Rg).Value = UCvt(Rg).Ht
    '                    dgv1.Item(7, Rg).Value = UCvt(Rg).Ori
    '                    dgv1.Item(8, Rg).Value = UCvt(Rg).Wt
    '                    dgv1.Item(10, Rg).Value = UCvt(Rg).maxQt
    '                    dgv1.Item(11, Rg).Value = UCvt(Rg).Qty

    '                    dgv1.Refresh()

    '                Next

    '                dgv1.Refresh()

    '            End If

    '            If Not UnM Then

    '                TxtOccuCbm.Text = Val(TxtOccuCbm.Text) * (25.4 * 25.4 * 25.4)
    '                TxtFreeCbm.Text = Val(TxtFreeCbm.Text) * (25.4 * 25.4 * 25.4)

    '                arc.length = CL * 25.4
    '                arc.width = CW * 25.4
    '                arc.height = CH * 25.4

    '                CL = arc.length
    '                CW = arc.width
    '                CH = arc.height

    '                lblContDim.Text = "Length=" & Format(arc.length, "0.00") & "  Width=" & Format(arc.width, "0.00") & "  Height=" & Format(arc.height, "0.00")
    '                lblContDim.Refresh()

    '                UnM = True
    '                UnE = False
    '            Else
    '                UnM = False

    '            End If

    '            lblContDim.Refresh()

    '        End If

    '    Catch Err As Exception
    '        MsgBox(Err.Message)
    '        MsgBox(Err.ToString)
    '        MessageBox.Show("Error in Unit conversion", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try


    'End Sub

    'Private Sub chkBxEnglishUnits_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles chkBxEnglishUnits.MouseClick

    '    Try

    '        UCvt.Clear()

    '        If EngUnFlg = False Then

    '            EngUnFlg = True
    '            MetUnFlg = False

    '            If chkBxMetricUnits.CheckState = CheckState.Checked Then
    '                chkBxMetricUnits.Checked = False
    '            Else
    '                chkBxEnglishUnits.Checked = True
    '                lblUnitsDisplay.Text = "All Dimensions Are In Inches"
    '                lblOccupied.Text = "Cu. M."
    '                lblFree.Text = "Cu. M."
    '                lblOccupied.Refresh()
    '                lblFree.Refresh()

    '                Dim SrNo As Integer = 0
    '                Dim ItmNm As String = Nothing
    '                Dim Pck As String = Nothing
    '                Dim Sz As Double
    '                Dim Ln As Double
    '                Dim Wd As Double
    '                Dim Ht As Double
    '                Dim Ori As Integer
    '                Dim Wt As Double
    '                Dim mxQt As Integer
    '                Dim Qts As Integer


    '                For Rg = 0 To dgv1.RowCount - 2

    '                    Dim UnVal As UnitsConvt

    '                    SrNo = dgv1.Item(0, Rg).Value
    '                    ItmNm = dgv1.Item(1, Rg).Value
    '                    Pck = dgv1.Item(2, Rg).Value
    '                    Sz = dgv1.Item(3, Rg).Value
    '                    Ln = dgv1.Item(4, Rg).Value
    '                    Wd = dgv1.Item(5, Rg).Value
    '                    Ht = dgv1.Item(6, Rg).Value
    '                    Ori = dgv1.Item(7, Rg).Value
    '                    Wt = dgv1.Item(8, Rg).Value
    '                    mxQt = dgv1.Item(10, Rg).Value
    '                    Qts = dgv1.Item(11, Rg).Value

    '                    'Stop
    '                    UnVal.Srn = SrNo
    '                    UnVal.Inm = ItmNm
    '                    UnVal.Pck = Pck
    '                    UnVal.Sz = Sz / (25.4 * 25.4 * 25.4)
    '                    UnVal.Ln = Ln / 25.4
    '                    UnVal.Wd = Wd / 25.4
    '                    UnVal.Ht = Ht / 25.4
    '                    UnVal.Ori = Ori
    '                    UnVal.Wt = Wt
    '                    UnVal.maxQt = mxQt
    '                    UnVal.Qty = Qts

    '                    UCvt.Add(UnVal)
    '                Next



    '                For Rg = 0 To dgv1.RowCount - 2

    '                    dgv1.Item(0, Rg).Value = UCvt(Rg).Srn
    '                    dgv1.Item(1, Rg).Value = UCvt(Rg).Inm
    '                    dgv1.Item(2, Rg).Value = UCvt(Rg).Pck
    '                    dgv1.Item(3, Rg).Value = UCvt(Rg).Sz
    '                    dgv1.Item(4, Rg).Value = UCvt(Rg).Ln
    '                    dgv1.Item(5, Rg).Value = UCvt(Rg).Wd
    '                    dgv1.Item(6, Rg).Value = UCvt(Rg).Ht
    '                    dgv1.Item(7, Rg).Value = UCvt(Rg).Ori
    '                    dgv1.Item(8, Rg).Value = UCvt(Rg).Wt
    '                    dgv1.Item(10, Rg).Value = UCvt(Rg).maxQt
    '                    dgv1.Item(11, Rg).Value = UCvt(Rg).Qty

    '                    dgv1.Refresh()

    '                Next

    '                dgv1.Refresh()

    '            End If

    '            If Not UnE Then

    '                TxtOccuCbm.Text = Val(TxtOccuCbm.Text) / (25.4 * 25.4 * 25.4)
    '                TxtFreeCbm.Text = Val(TxtFreeCbm.Text) / (25.4 * 25.4 * 25.4)

    '                arc.length = CL / 25.4
    '                arc.width = CW / 25.4
    '                arc.height = CH / 25.4

    '                CL = arc.length
    '                CW = arc.width
    '                CH = arc.height

    '                lblContDim.Text = "Length=" & Format(arc.length, "0.00") & "  Width=" & Format(arc.width, "0.00") & "  Height=" & Format(arc.height, "0.00")
    '                lblContDim.Refresh()

    '                UnE = True
    '                UnM = False
    '            Else
    '                UnE = False
    '            End If

    '            lblContDim.Refresh()

    '        End If

    '    Catch Err As Exception
    '        MsgBox(Err.Message)
    '        MsgBox(Err.ToString)
    '        MessageBox.Show("Error in Unit conversion", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try

    'End Sub

    Public Sub chkBxAutoStuff_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles chkBxAutoStuff.MouseClick

        'Private Sub chkBxAutoStuff_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles chkBxAutoStuff.MouseClick

        Try
            If Not (Str = "UpdateComplete" Or Str = Nothing) Then
                MessageBox.Show("Update Complete the stuffing entry then continue", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Exit Sub
            End If

            '     If Not (AtStf0) Or Not (AtStf1) Then
            '---------------
            CheckBox1.Checked = False
            chkBxSlideStuff.Checked = False
            chkbxOptStuff.Checked = False
            chkBxPlyStuff.Checked = False
            '-------------------
            If Not Mth Then

                Me.Column10.HeaderText = "USQt"
                Mth = True
            Else

                Me.Column10.HeaderText = "MaxQty"
                Mth = False
            End If
            '------------
            If chkBxAutoStuff.Checked = True Then

                If chkBxAutoStuff.Checked = True Then
                    Call DuplDgv()
                End If

                Dgv1Dup.Visible = True

                Call AutoStuffEventTrue()

                'dgv1.Columns(15).Visible = True
                'dgv1.Columns(16).Visible = True

                If chkBxAutoStuffRC.Checked = False Then

                    Call AutostuffFlw()
                    dgv1.Refresh()

                    dgv1.CurrentCell = dgv1(12, dgv1.RowCount - 2)
                    Me.ShowButton_MouseClick(sender, e)

                ElseIf chkBxAutoStuffRC.Checked = True Then

                    Call AutostuffFlwClMn()

                    dgv1.Refresh()

                    ' Exit Sub
                    dgv1.CurrentCell = dgv1(12, dgv1.RowCount - 3)
                    Me.ShowButton_MouseClick(sender, e)

                End If

                '  AtStf1 = True
            ElseIf chkBxAutoStuff.Checked = False Then

                Dgv1Dup.Visible = False

                Call AutoStuffEventFalse()

                'dgv1.Columns(15).Visible = False
                'dgv1.Columns(16).Visible = False

                Call UnCheckedAutostuff()
                TxtBind()
                'Call DbTrackDel()
                'Call DbTrackerDupDel()
                Sauto.Clear()
                dgv1.Refresh()
                '   AtStf0 = True
            End If

            '  Else
            '  AtStf0 = False
            '   End If

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in AutoStuffMouseClick", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub rdbEnglish_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbEnglish.CheckedChanged

        Try

            If rdbEnglish.Checked = True Then
                rdbMetric.Checked = False
                rdbEnglish.Checked = True
            Else
                rdbMetric.Checked = True
                rdbEnglish.Checked = False
            End If

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in Unit conversion", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub rdbEnglish_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles rdbEnglish.MouseClick

        Try

            UCvt.Clear()

            If EngUnFlg = False Then

                EngUnFlg = True
                MetUnFlg = False

                If rdbMetric.Checked = True Then       'If chkBxMetricUnits.CheckState = CheckState.Checked Then
                    rdbMetric.Checked = False          'chkBxMetricUnits.Checked = False
                Else
                    rdbEnglish.Checked = True          'chkBxEnglishUnits.Checked = True
                    '  lblUnitsDisplay.Text = "All Dimensions Are In Inches"
                    lblOccupied.Text = "Cu. M."
                    lblFree.Text = "Cu. M."
                    lblCapacity.Text = "Cu.M"
                    lblOccupied.Refresh()
                    lblFree.Refresh()
                    lblCapacity.Refresh()

                    Dim SrNo As Integer = 0
                    Dim ItmNm As String = Nothing
                    Dim Pck As String = Nothing
                    Dim Sz As Double
                    Dim Ln As Double
                    Dim Wd As Double
                    Dim Ht As Double
                    Dim Ori As Integer
                    Dim Wt As Double
                    Dim mxQt As Integer
                    Dim Qts As Integer

                    For Rg = 0 To dgv1.RowCount - 2

                        Dim UnVal As UnitsConvt

                        SrNo = dgv1.Item(0, Rg).Value
                        ItmNm = dgv1.Item(1, Rg).Value
                        Pck = dgv1.Item(2, Rg).Value
                        Sz = dgv1.Item(3, Rg).Value
                        Ln = dgv1.Item(4, Rg).Value
                        Wd = dgv1.Item(5, Rg).Value
                        Ht = dgv1.Item(6, Rg).Value
                        Ori = dgv1.Item(7, Rg).Value
                        Wt = dgv1.Item(8, Rg).Value
                        mxQt = dgv1.Item(10, Rg).Value
                        Qts = dgv1.Item(11, Rg).Value

                        'Stop
                        UnVal.Srn = SrNo
                        UnVal.Inm = ItmNm
                        UnVal.Pck = Pck
                        UnVal.Sz = Sz / (25.4 * 25.4 * 25.4)
                        UnVal.Ln = Ln / 25.4
                        UnVal.Wd = Wd / 25.4
                        UnVal.Ht = Ht / 25.4
                        UnVal.Ori = Ori
                        UnVal.Wt = Wt
                        UnVal.maxQt = mxQt
                        UnVal.Qty = Qts

                        UCvt.Add(UnVal)
                    Next

                    For Rg = 0 To dgv1.RowCount - 2

                        dgv1.Item(0, Rg).Value = UCvt(Rg).Srn
                        dgv1.Item(1, Rg).Value = UCvt(Rg).Inm
                        dgv1.Item(2, Rg).Value = UCvt(Rg).Pck
                        dgv1.Item(3, Rg).Value = UCvt(Rg).Sz
                        dgv1.Item(4, Rg).Value = UCvt(Rg).Ln
                        dgv1.Item(5, Rg).Value = UCvt(Rg).Wd
                        dgv1.Item(6, Rg).Value = UCvt(Rg).Ht
                        dgv1.Item(7, Rg).Value = UCvt(Rg).Ori
                        dgv1.Item(8, Rg).Value = UCvt(Rg).Wt
                        dgv1.Item(10, Rg).Value = UCvt(Rg).maxQt
                        dgv1.Item(11, Rg).Value = UCvt(Rg).Qty

                        dgv1.Refresh()

                    Next

                    dgv1.Refresh()

                End If

                If Not UnE Then

                    TxtOccuCbm.Text = Val(TxtOccuCbm.Text) / (25.4 * 25.4 * 25.4)
                    TxtFreeCbm.Text = Val(TxtFreeCbm.Text) / (25.4 * 25.4 * 25.4)
                    TxtCapacity.Text = Val(TxtCapacity.Text) / (25.4 * 25.4 * 25.4)

                    arc.length = CL / 25.4
                    arc.width = CW / 25.4
                    arc.height = CH / 25.4

                    CL = arc.length
                    CW = arc.width
                    CH = arc.height

                    lblContDim.Text = "Length = " & Format(arc.length, "0.00") & "  Width = " & Format(arc.width, "0.00") & "  Height = " & Format(arc.height, "0.00")
                    lblContDim.Refresh()

                    UnE = True
                    UnM = False
                Else
                    UnE = False
                End If

                lblContDim.Refresh()

            End If

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in Unit conversion", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub rdbMetric_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbMetric.CheckedChanged

        Try
            If rdbMetric.Checked = True Then
                rdbEnglish.Checked = False
                rdbMetric.Checked = True
            Else
                rdbEnglish.Checked = True
                rdbMetric.Checked = False
            End If

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in Unit conversion", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub rdbMetric_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles rdbMetric.MouseClick

        Try

            UCvt.Clear()

            If MetUnFlg = False Then

                MetUnFlg = True
                EngUnFlg = False

                If rdbEnglish.Checked = True Then           'If chkBxEnglishUnits.CheckState = CheckState.Checked Then
                    rdbEnglish.Checked = False              'chkBxEnglishUnits.Checked = False
                Else
                    rdbMetric.Checked = True                'chkBxMetricUnits.Checked = True
                    '    lblUnitsDisplay.Text = "All Dimensions Are In Millimeters"
                    lblOccupied.Text = "Cu. MM."
                    lblFree.Text = "Cu. MM."
                    lblCapacity.Text = "Cu.MM."
                    lblOccupied.Refresh()
                    lblFree.Refresh()
                    lblCapacity.Refresh()

                    Dim SrNo As Integer = 0
                    Dim ItmNm As String = Nothing
                    Dim Pck As String = Nothing
                    Dim Sz As Double
                    Dim Ln As Double
                    Dim Wd As Double
                    Dim Ht As Double
                    Dim Ori As Integer
                    Dim Wt As Double
                    Dim mxQt As Integer
                    Dim Qts As Integer

                    For Rg = 0 To dgv1.RowCount - 2

                        Dim UnVal As UnitsConvt

                        SrNo = dgv1.Item(0, Rg).Value
                        ItmNm = dgv1.Item(1, Rg).Value
                        Pck = dgv1.Item(2, Rg).Value
                        Sz = dgv1.Item(3, Rg).Value
                        Ln = dgv1.Item(4, Rg).Value
                        Wd = dgv1.Item(5, Rg).Value
                        Ht = dgv1.Item(6, Rg).Value
                        Ori = dgv1.Item(7, Rg).Value
                        Wt = dgv1.Item(8, Rg).Value
                        mxQt = dgv1.Item(10, Rg).Value
                        Qts = dgv1.Item(11, Rg).Value

                        'Stop
                        UnVal.Srn = SrNo
                        UnVal.Inm = ItmNm
                        UnVal.Pck = Pck
                        UnVal.Sz = Sz * (25.4 * 25.4 * 25.4)
                        UnVal.Ln = Ln * 25.4
                        UnVal.Wd = Wd * 25.4
                        UnVal.Ht = Ht * 25.4
                        UnVal.Ori = Ori
                        UnVal.Wt = Wt
                        UnVal.maxQt = mxQt
                        UnVal.Qty = Qts

                        UCvt.Add(UnVal)

                    Next

                    For Rg = 0 To dgv1.RowCount - 2

                        dgv1.Item(0, Rg).Value = UCvt(Rg).Srn
                        dgv1.Item(1, Rg).Value = UCvt(Rg).Inm
                        dgv1.Item(2, Rg).Value = UCvt(Rg).Pck
                        dgv1.Item(3, Rg).Value = UCvt(Rg).Sz
                        dgv1.Item(4, Rg).Value = UCvt(Rg).Ln
                        dgv1.Item(5, Rg).Value = UCvt(Rg).Wd
                        dgv1.Item(6, Rg).Value = UCvt(Rg).Ht
                        dgv1.Item(7, Rg).Value = UCvt(Rg).Ori
                        dgv1.Item(8, Rg).Value = UCvt(Rg).Wt
                        dgv1.Item(10, Rg).Value = UCvt(Rg).maxQt
                        dgv1.Item(11, Rg).Value = UCvt(Rg).Qty

                        dgv1.Refresh()

                    Next

                    dgv1.Refresh()

                End If

                If Not UnM Then

                    TxtOccuCbm.Text = Val(TxtOccuCbm.Text) * (25.4 * 25.4 * 25.4)
                    TxtFreeCbm.Text = Val(TxtFreeCbm.Text) * (25.4 * 25.4 * 25.4)
                    TxtCapacity.Text = Val(TxtCapacity.Text) * (25.4 * 25.4 * 25.4)

                    arc.length = CL * 25.4
                    arc.width = CW * 25.4
                    arc.height = CH * 25.4

                    CL = arc.length
                    CW = arc.width
                    CH = arc.height

                    lblContDim.Text = "Length = " & Format(arc.length, "0.00") & "  Width = " & Format(arc.width, "0.00") & "  Height = " & Format(arc.height, "0.00")
                    lblContDim.Refresh()

                    UnM = True
                    UnE = False
                Else
                    UnM = False

                End If

                lblContDim.Refresh()

            End If

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in Unit conversion", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub dgv1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv1.Click

        Try

            'If CmbContainer.Text = "" Then
            '    MsgBox("Container not selected", MsgBoxStyle.Critical + vbOKOnly)
            '    CmbContainer.Focus()
            '    Exit Sub
            'End If

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in selecting container", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub dgv1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgv1.KeyDown

        Try

            'If CmbContainer.Text = "" Then
            '    MsgBox("Container not selected", MsgBoxStyle.Critical + vbOKOnly)
            '    CmbContainer.Focus()
            '    Exit Sub
            'End If

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in selecting container", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub dgv1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv1.CellEnter

        Try

            'If e.ColumnIndex = 1 Then
            '    dgv1.Tag = dgv1(e.ColumnIndex, e.RowIndex).Value
            'End If

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in Cell Enter", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub dgv1_CellLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv1.CellLeave

        'Try
        '    If e.ColumnIndex = 1 Then

        '        If dgv1(e.ColumnIndex, e.RowIndex).Value <> dgv1.Tag Then
        '            Me.ComboBox_SelectedIndexChanged(sender, e)
        '            'dgv1.CurrentCell = dgv1(10, e.RowIndex)
        '        End If
        '        'dgv1.CurrentCell = dgv1(11, e.RowIndex)
        '    End If

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        '    MsgBox(ex.ToString)
        '    MessageBox.Show("Error in Cell Leave", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try

    End Sub

    Private Sub fill_measurement(ByVal itmnm As String)

        Try
            stk.Clear()

            Dim cmd As New OleDb.OleDbCommand
            Dim rdr As OleDb.OleDbDataReader
            Dim lni As Single
            Dim wdi As Single
            Dim hti As Single

            rwidx = dgv1.CurrentRow.Index

            If conn.State = ConnectionState.Closed Then conn.Open()

            cmd.Connection = conn

            cmd.CommandText = "select lengthf,widthf,heightf,lengthi,widthi,heighti,lengthc,widthc,heightc,lengthm,widthm,heightm,grossweight,packingmode from packmast where packname ='" & itmnm & "'"
            If conn.State = ConnectionState.Closed Then conn.Open()
            rdr = cmd.ExecuteReader
            rdr.Read()
            Try
                lni = Val(Format((rdr("lengthi") + (12 * rdr("lengthf")) + (rdr("lengthc") / 2.538) + (rdr("lengthm") / 25.38)), "0.0000"))
            Catch
                Exit Sub
            End Try
            wdi = Val(Format((rdr("Widthi") + (12 * rdr("Widthf")) + (rdr("Widthc") / 2.538) + (rdr("Widthm") / 25.38)), "0.0000"))
            hti = Val(Format((rdr("heighti") + (12 * rdr("heightf")) + (rdr("heightc") / 2.538) + (rdr("heightm") / 25.38)), "0.0000"))
            dgv1.Item(1, rwidx).Value = itmnm
            dgv1.Item(4, rwidx).Value = lni
            dgv1.Item(5, rwidx).Value = wdi
            dgv1.Item(6, rwidx).Value = hti
            dgv1.Item(3, rwidx).Value = lni * wdi * hti         '/ 61024
            dgv1.Item(2, rwidx).Value = rdr("packingmode")
            dgv1.Item(8, rwidx).Value = rdr("grossweight")
            rdr.Close()
            conn.Close()

            Call gridColor()

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in Datagrid  filling", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub dgv1_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgv1.MouseDoubleClick

        Try
            Dim htinfo As DataGridView.HitTestInfo
            htinfo = dgv1.HitTest(e.X, e.Y)
            Dim coldlg As New ColorDialog
            If htinfo.Type = DataGridViewHitTestType.Cell Or htinfo.ColumnIndex = -1 Then
                If htinfo.ColumnIndex = 0 Or htinfo.ColumnIndex = -1 Then
                    '  Dim ccell As DataGridViewTextBoxCell = dgv1(htinfo.ColumnIndex, htinfo.RowIndex)
                    coldlg.ShowDialog()
                    ' ccell.Style.BackColor = coldlg.Color()
                    'dgv1.CurrentCell = dgv1(ccell.ColumnIndex, ccell.RowIndex + 1)
                    Dim ccell As DataGridViewRowHeaderCell = dgv1.Rows(htinfo.RowIndex).HeaderCell
                    ccell.Style.BackColor = coldlg.Color()
                    If htinfo.ColumnIndex = -1 Then
                        dgv1.CurrentCell = dgv1(ccell.ColumnIndex + 1, ccell.RowIndex + 1)
                    End If
                End If
            End If
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in colour change", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub ShowButton_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles ShowButton.MouseEnter

        Try

            showbutton1.Visible = False
            Call showstuff3D()

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in ShowButton", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub dgv1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgv1.KeyPress

        Try

            'Dim k As Int16

            'Dim mea As MouseEventArgs = New MouseEventArgs(Windows.Forms.MouseButtons.Left, 0, 0, 0, 0)

            'k = Asc(e.KeyChar)

            'If k = 19 Then

            '    Try
            '        dgv1.CurrentCell = dgv1(12, dgv1.RowCount - 2)
            '        Me.ShowButton_MouseClick(sender, mea)
            '    Catch
            '        Exit Sub
            '    End Try

            'End If

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in show key press", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub addcmd()

        Try

            'ToolTip1.SetToolTip(cmdAdd, "Add the container and goods items stuffing entry")

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in addcmd", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub editcmd()

        Try
            'ToolTip1.SetToolTip(cmdEdit, "Edit the container and goods items stuffing entry")
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in editcmd", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub deletecmd()

        Try
            'ToolTip1.SetToolTip(cmdDel, "Delete the stuffing entry")
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in deletecmd", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub firstcmd()

        Try
            'ToolTip1.SetToolTip(cmdFirst, "Go to the first record of stuffing entry")
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in firstcmd", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub previouscmd()

        Try
            'ToolTip1.SetToolTip(cmdPrev, "Go to the previous record of stuffing entry")
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in previouscmd", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub nextcmd()

        Try
            'ToolTip1.SetToolTip(cmdNext, "Go to the next record of stuffing entry")
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in nextcmd", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub lastcmd()

        Try
            'ToolTip1.SetToolTip(cmdLast, "Go to the last record of stuffing entry")
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in lastcmd", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub findcmd()

        Try
            'ToolTip1.SetToolTip(cmdFind, "Find the stuffing entry data")
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in findcmd", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub exitcmd()

        Try
            'ToolTip1.SetToolTip(cmdExit, "Exit the stuffing entry menu")
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in exitcmd", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub selectcontainername()

        Try
            'ToolTip1.SetToolTip(CmbContainer, "Select the container name")
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in selectcontainername", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Protected Sub showstuff3D()

        Try
            'ToolTip1.SetToolTip(ShowButton, "Start the stuffing and show the 3D view")
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in showstuff3D", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Protected Sub showstufflayout()

        Try
            'ToolTip1.SetToolTip(showbutton1, "Start the stuffing and show the layout view")
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in showstufflayout", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Protected Sub updates()

        Try

            'ToolTip1.SetToolTip(cmdUpdate, "Update the stuffing entry")

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in updates", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Protected Sub refreshs()

        Try
            'ToolTip1.SetToolTip(cmdRef, "Refresh the stuffing entry")
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in refreshs", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdAdd_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAdd.MouseEnter

        Try
            ToolTip1.IsBalloon = False
            Call addcmd()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in cmdAdd_MouseEnter", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdDel_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdDel.MouseEnter

        Try
            Call deletecmd()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in cmdDel_MouseEnter", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdEdit_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdEdit.MouseEnter

        Try
            Call editcmd()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in cmdEdit_MouseEnter", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdFirst_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdFirst.MouseEnter

        Try
            Call firstcmd()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in cmdFirst_MouseEnter", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdPrev_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdPrev.MouseEnter

        Try
            Call previouscmd()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in cmdPrev_MouseEnter", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdNext_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdNext.MouseEnter

        Try
            Call nextcmd()

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in cmdNext_MouseEnter", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdLast_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdLast.MouseEnter

        Try
            Call lastcmd()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in cmdLast_MouseEnter", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdFind_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdFind.MouseEnter

        Try

            Call findcmd()

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in cmdFind_MouseEnter", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdExit_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdExit.MouseEnter

        Try
            Call exitcmd()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in cmdExit_MouseEnter", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub showbutton1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles showbutton1.MouseEnter

        Try
            Call showstufflayout()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in showbutton1_MouseEnter", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdUpdate_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdUpdate.MouseEnter

        Try
            Call updates()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in cmdUpdate_MouseEnter", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdRef_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdRef.MouseEnter

        Try
            Call refreshs()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in cmdRef_MouseEnter", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub dgv1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv1.SelectionChanged

        Try
            'With dgv1
            '    If .CurrentCell.ColumnIndex = 2 Then .CurrentCell = dgv1(10, .CurrentRow.Index)
            'End With
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in dgv1_SelectionChanged", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub TransactionMenu_ResizeBegin(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeBegin

        'If Me.WindowState = FormWindowState.Minimized Then
        '    Call MDIForm.BringFront()
        '    Me.TopMost = True
        'ElseIf Me.WindowState = FormWindowState.Maximized Then
        '    Call MDIForm.SendBack()
        'ElseIf Me.WindowState = FormWindowState.Normal Then
        '    Call MDIForm.BringFront()
        '    Me.TopMost = True
        'End If

        Me.Refresh()

    End Sub

    Public Declare Auto Function AnimateWindow Lib "user32" (ByVal hwnd As IntPtr, ByVal time As Integer, ByVal flags As Integer) As Boolean

    Public Enum AnimateStyles

        Slide = 262144 ' We are using a special slide animation.
        Activate = 131072 ' We activate the form for transition.
        Blend = 524288 ' We are specifying a fade effect
        Hide = 65536 ' We hide the form in transition (before bringing it in)
        Center = 16 ' This is how the form will collapse, in this case inwards.
        HOR_Positive = 1 ' Animates form from right to left
        HOR_Negative = 2 ' Animates form from left to right.
        VER_Positive = 4 ' Animates form from top to bottom.
        VER_Negative = 8 ' Animates form from bottom to top.

    End Enum

    Private Sub dgv1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgv1.MouseDown

        Try
            If Str = "Edit" Then

                If e.Button = Windows.Forms.MouseButtons.Right Then
                    Dim hinfo As DataGridView.HitTestInfo
                    hinfo = dgv1.HitTest(e.X, e.Y)
                    If hinfo.Type = DataGridViewHitTestType.RowHeader Then
                        Array.Resize(rowinfo, dgv1.ColumnCount)                     'rowinfo.Resize(rowinfo, dgv1.ColumnCount)
                        For i As Short = 0 To dgv1.ColumnCount - 1
                            rowinfo(i) = dgv1(i, hinfo.RowIndex).Value
                        Next

                    End If
                End If
            End If

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in Selected row mouse down", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub dgv1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgv1.MouseUp

        Try
            If Str = "Edit" Then
                If e.Button = Windows.Forms.MouseButtons.Right Then
                    Dim hinfo As DataGridView.HitTestInfo
                    hinfo = dgv1.HitTest(e.X, e.Y)
                    If hinfo.Type = DataGridViewHitTestType.RowHeader Then
                        Try
                            dgv1.Rows.RemoveAt(rowinfo(0) - 1)
                            dgv1.Rows.Insert(hinfo.RowIndex, rowinfo)

                            'Dim dgrow As DataGridViewRow
                            For i As Short = 0 To dgv1.RowCount - 2
                                dgv1.Rows(i).Cells(0).Value = i + 1
                            Next
                            dgv1.CurrentCell = dgv1(0, hinfo.RowIndex)
                        Catch
                        End Try

                    End If
                End If
            End If

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in selected row mouse up", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub DtReceipt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DtReceipt.LostFocus
        CmbContainer.Focus()
    End Sub

    Dim L As Double
    Dim W As Double
    Dim H As Double

    Private Sub btnContLWH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContLWH.Click

        Try

            TrackBarContBxDor.Enabled = False
            TrackBarContBxDor.Value = 0
            flgDr = False
            btnDoor.Text = "&Door open off"
            TrackBarContBxDor.BackColor = Color.Gainsboro
            DbxFlg = False
            lwhc = True

            Dim chCa As Int16 = 0

            If L = 0 And W = 0 And H = 0 Then
                L = CL
                W = CW
                H = CH
                chCa = 1
            ElseIf CL = L And CW = W And CH = H Then
                chCa = 1
            ElseIf CL = W And CW = H And CH = L Then
                chCa = 2
            ElseIf CL = H And CW = L And CH = W Then
                chCa = 3
            ElseIf CL = W And CW = L And CH = H Then
                chCa = 4
            ElseIf CL = H And CW = W And CH = L Then
                chCa = 5
            ElseIf CL = L And CW = H And CH = W Then
                chCa = 6
            End If

            Select Case chCa

                Case 1
                    CL = W
                    CW = H
                    CH = L
                Case 2
                    CL = H
                    CW = L
                    CH = W
                Case 3
                    CL = W
                    CW = L
                    CH = H
                Case 4
                    CL = H
                    CW = W
                    CH = L
                Case 5
                    CL = L
                    CW = H
                    CH = W
                Case 6
                    CL = L
                    CW = W
                    CH = H
            End Select


            lblContDim.Text = "Length = " & Format(CL, "0.00") & "  Width = " & Format(CW, "0.00") & "  Height = " & Format(CH, "0.00")
            lblContDim.Refresh()

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in container length width height shuffling", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub chkbxtextprint_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkbxtextprint.CheckedChanged

        Try

            If chkbxtextprint.Checked = True Then
                MessageBox.Show("Top front bottom is printing to the geometry so speed is slow", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            ElseIf chkbxtextprint.Checked = False Then
                MessageBox.Show("Top front bottom is not printing to the geometry so speed is fast", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in text printing", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub chkBxAutoStuffRC_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles chkBxAutoStuffRC.MouseClick
        '    ' Call chkBxAutoStuff_MouseClick(sender, e)

        '    Try

        '        CheckBox1.Checked = False
        '        chkBxSlideStuff.Checked = False
        '        chkbxOptStuff.Checked = False
        '        chkBxPlyStuff.Checked = False
        '        '-------------------
        '        If Not Mth Then

        '            Me.Column10.HeaderText = "USQt"
        '            Mth = True
        '        Else

        '            Me.Column10.HeaderText = "MaxQty"
        '            Mth = False
        '        End If
        '        '------------
        '        If chkBxAutoStuffRC.Checked = True Then

        '            If chkBxAutoStuffRC.Checked = True Then
        '                Call DuplDgv()
        '            End If

        '            Dgv1Dup.Visible = True

        '            Call AutoStuffEventTrue()

        '            If chkBxAutoStuffRC.Checked = False Then

        '                Call AutostuffFlw()

        '                dgv1.Refresh()

        '                dgv1.CurrentCell = dgv1(12, dgv1.RowCount - 2)
        '                Me.ShowButton_MouseClick(sender, e)

        '            ElseIf chkBxAutoStuffRC.Checked = True Then

        '                Call AutostuffFlwClMn()

        '                dgv1.Refresh()

        '                dgv1.CurrentCell = dgv1(12, dgv1.RowCount - 3)
        '                Me.ShowButton_MouseClick(sender, e)

        '            End If

        '        ElseIf chkBxAutoStuffRC.Checked = False Then

        '            Dgv1Dup.Visible = False

        '            Call AutoStuffEventFalse()

        '            Call UnCheckedAutostuff()
        '            TxtBind()

        '            Sauto.Clear()
        '            dgv1.Refresh()

        '        End If


        '    Catch Err As Exception
        '        MsgBox(Err.Message)
        '        MsgBox(Err.ToString)
        '        MessageBox.Show("Error in AutoStuffMouseClick", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    End Try

    End Sub

    Private Sub chkbxCG_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles chkbxCG.MouseClick

        Try

            If chkbxCG.Checked = False Then
                CGRoutine()
            End If

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in chkbxCG_MouseClick", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub TBCcg_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TBCcg.MouseClick

        Try

            If TBCcg.SelectedIndex = 2 Then
                txtTareWtCont.Focus()
                txtTareWtCont.SelectAll()
            End If

            If TBCcg.SelectedIndex = 0 Then
                chkbxCG.Focus()
                chkbxCG.Select()
            End If

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in TBCcg_MouseClick", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtTareWtCont_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTareWtCont.KeyPress

        Try
            e.Handled = ValidNumber(e.KeyChar, txtTareWtCont)
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in txtTareWtCont_KeyPress", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub callTrial()

        Try
            Me.Enabled = False
            frmTrial.Show()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in callTrial", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnPilot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPilot.Click

        Try
            Call DeleteWrlOutFiles()

            If Not (Str = "UpdateComplete" Or Str = Nothing) Then
                MessageBox.Show("Update Complete the stuffing entry then continue", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Exit Sub
            End If

            frmTrial_exitFlg = False
            Trl = Nothing
            Cnt = 0
            LstTrl.Clear()
            TrlOFlg = False
            pilotFlg = False

            Try

                Dim CmdTrial As New OleDb.OleDbCommand
                CmdTrial.Connection = conn
                CmdTrial.CommandText = "delete from Trial"
                CmdTrial.ExecuteNonQuery()
            Catch ex As Exception
            End Try

            If Not TrlsFlg Then

                TrlsFlg = True

                If Not pilotFlg Then

                    LstTrl.Clear()

                    Call callTrial()

                    'Exit Sub

                    frmTrial.TrialShow.Visible = False

                    pilotFlg = False        'True
                    Rdb1.Checked = False
                    Rdb2.Checked = False
                    Rdb3.Checked = False
                    Rdb4.Checked = False
                    Rdb5.Checked = False
                    Rdb6.Checked = False
                    Rdb7.Checked = False
                    Rdb8.Checked = False
                    Rdb9.Checked = False
                    Rdb10.Checked = False
                    Rdb11.Checked = False
                    Rdb12.Checked = False
                    Rdb13.Checked = False
                    Rdb14.Checked = False
                    Rdb15.Checked = False
                    Rdb16.Checked = False

                    chkBxAutoStuff.Checked = False
                    chkBxAutoStuffRC.Checked = False
                    Call chkBxAutoStuff_MouseClick(sender, e)
                    dgv1.Refresh()
                    Me.Refresh()

                    btnPilot.BackColor = Color.HotPink
                    chkBxAutoStuff.Checked = True
                    Call chkBxAutoStuff_MouseClick(sender, e)
                    dgv1.Refresh()
                    Me.Refresh()

                    Call generateTable()
                    Call StopStep()

                    If frmTrial_exitFlg Then
                        GoTo JPL
                    End If

                    chkBxAutoStuff.Checked = False
                    Call chkBxAutoStuff_MouseClick(sender, e)
                    dgv1.Refresh()
                    Me.Refresh()
                    chkBxAutoStuff.Checked = True
                    chkBxAutoStuffRC.Checked = True
                    Call chkBxAutoStuff_MouseClick(sender, e)
                    dgv1.Refresh()
                    Me.Refresh()

                    Call generateTable()
                    Call StopStep()

                    If frmTrial_exitFlg Then
                        GoTo JPL
                    End If

                    chkBxAutoStuff.Checked = False
                    chkBxAutoStuffRC.Checked = False
                    Call chkBxAutoStuff_MouseClick(sender, e)
                    dgv1.Refresh()
                    Me.Refresh()
                    chkBxAutoStuff.Checked = True
                    Rdb1.Checked = True
                    Call chkBxAutoStuff_MouseClick(sender, e)
                    dgv1.Refresh()
                    Me.Refresh()

                    Call generateTable()
                    Call StopStep()

                    If frmTrial_exitFlg Then
                        GoTo JPL
                    End If

                    chkBxAutoStuff.Checked = False
                    chkBxAutoStuffRC.Checked = True
                    Call chkBxAutoStuff_MouseClick(sender, e)
                    dgv1.Refresh()
                    Me.Refresh()
                    chkBxAutoStuff.Checked = True
                    Rdb1.Checked = True
                    Call chkBxAutoStuff_MouseClick(sender, e)
                    dgv1.Refresh()
                    Me.Refresh()

                    Call generateTable()
                    Call StopStep()

                    If frmTrial_exitFlg Then
                        GoTo JPL
                    End If

                    chkBxAutoStuff.Checked = False
                    chkBxAutoStuffRC.Checked = False
                    Call chkBxAutoStuff_MouseClick(sender, e)
                    dgv1.Refresh()
                    Me.Refresh()
                    chkBxAutoStuff.Checked = True
                    Rdb2.Checked = True
                    Call chkBxAutoStuff_MouseClick(sender, e)
                    dgv1.Refresh()
                    Me.Refresh()

                    Call generateTable()
                    Call StopStep()

                    If frmTrial_exitFlg Then
                        GoTo JPL
                    End If

                    chkBxAutoStuff.Checked = False
                    chkBxAutoStuffRC.Checked = True
                    Call chkBxAutoStuff_MouseClick(sender, e)
                    dgv1.Refresh()
                    Me.Refresh()
                    chkBxAutoStuff.Checked = True
                    Rdb2.Checked = True
                    Call chkBxAutoStuff_MouseClick(sender, e)
                    dgv1.Refresh()
                    Me.Refresh()

                    Call generateTable()
                    Call StopStep()

                    If frmTrial_exitFlg Then
                        GoTo JPL
                    End If

                    chkBxAutoStuff.Checked = False
                    chkBxAutoStuffRC.Checked = False
                    Call chkBxAutoStuff_MouseClick(sender, e)
                    dgv1.Refresh()
                    Me.Refresh()
                    chkBxAutoStuff.Checked = True
                    Rdb3.Checked = True
                    Call chkBxAutoStuff_MouseClick(sender, e)
                    dgv1.Refresh()
                    Me.Refresh()

                    Call generateTable()
                    Call StopStep()

                    If frmTrial_exitFlg Then
                        GoTo JPL
                    End If

                    chkBxAutoStuff.Checked = False
                    chkBxAutoStuffRC.Checked = True
                    Call chkBxAutoStuff_MouseClick(sender, e)
                    dgv1.Refresh()
                    Me.Refresh()
                    chkBxAutoStuff.Checked = True
                    Rdb3.Checked = True
                    Call chkBxAutoStuff_MouseClick(sender, e)
                    dgv1.Refresh()
                    Me.Refresh()

                    Call generateTable()
                    Call StopStep()

                    If frmTrial_exitFlg Then
                        GoTo JPL
                    End If

                    chkBxAutoStuff.Checked = False
                    chkBxAutoStuffRC.Checked = False
                    Call chkBxAutoStuff_MouseClick(sender, e)
                    dgv1.Refresh()
                    Me.Refresh()
                    chkBxAutoStuff.Checked = True
                    Rdb4.Checked = True
                    Call chkBxAutoStuff_MouseClick(sender, e)
                    dgv1.Refresh()
                    Me.Refresh()

                    Call generateTable()
                    Call StopStep()

                    If frmTrial_exitFlg Then
                        GoTo JPL
                    End If

                    chkBxAutoStuff.Checked = False
                    chkBxAutoStuffRC.Checked = True
                    Call chkBxAutoStuff_MouseClick(sender, e)
                    dgv1.Refresh()
                    Me.Refresh()
                    chkBxAutoStuff.Checked = True
                    Rdb4.Checked = True
                    Call chkBxAutoStuff_MouseClick(sender, e)
                    dgv1.Refresh()
                    Me.Refresh()

                    Call generateTable()
                    Call StopStep()

                    If frmTrial_exitFlg Then
                        GoTo JPL
                    End If

                    chkBxAutoStuff.Checked = False
                    chkBxAutoStuffRC.Checked = False
                    Call chkBxAutoStuff_MouseClick(sender, e)
                    dgv1.Refresh()
                    Me.Refresh()
                    chkBxAutoStuff.Checked = True
                    Rdb5.Checked = True
                    Call chkBxAutoStuff_MouseClick(sender, e)
                    dgv1.Refresh()
                    Me.Refresh()

                    Call generateTable()
                    Call StopStep()

                    If frmTrial_exitFlg Then
                        GoTo JPL
                    End If

                    chkBxAutoStuff.Checked = False
                    chkBxAutoStuffRC.Checked = True
                    Call chkBxAutoStuff_MouseClick(sender, e)
                    dgv1.Refresh()
                    Me.Refresh()
                    chkBxAutoStuff.Checked = True
                    Rdb5.Checked = True
                    Call chkBxAutoStuff_MouseClick(sender, e)
                    dgv1.Refresh()
                    Me.Refresh()

                    Call generateTable()
                    Call StopStep()

                    If frmTrial_exitFlg Then
                        GoTo JPL
                    End If

                    chkBxAutoStuff.Checked = False
                    chkBxAutoStuffRC.Checked = False
                    Call chkBxAutoStuff_MouseClick(sender, e)
                    dgv1.Refresh()
                    Me.Refresh()
                    chkBxAutoStuff.Checked = True
                    Rdb6.Checked = True
                    Call chkBxAutoStuff_MouseClick(sender, e)
                    dgv1.Refresh()
                    Me.Refresh()

                    Call generateTable()
                    Call StopStep()

                    If frmTrial_exitFlg Then
                        GoTo JPL
                    End If

                    chkBxAutoStuff.Checked = False
                    chkBxAutoStuffRC.Checked = True
                    Call chkBxAutoStuff_MouseClick(sender, e)
                    dgv1.Refresh()
                    Me.Refresh()
                    chkBxAutoStuff.Checked = True
                    Rdb6.Checked = True
                    Call chkBxAutoStuff_MouseClick(sender, e)
                    dgv1.Refresh()
                    Me.Refresh()

                    Call generateTable()
                    Call StopStep()

                    If frmTrial_exitFlg Then
                        GoTo JPL
                    End If

                    chkBxAutoStuff.Checked = False
                    chkBxAutoStuffRC.Checked = False
                    Call chkBxAutoStuff_MouseClick(sender, e)
                    dgv1.Refresh()
                    Me.Refresh()
                    chkBxAutoStuff.Checked = True
                    Rdb7.Checked = True
                    Call chkBxAutoStuff_MouseClick(sender, e)
                    dgv1.Refresh()
                    Me.Refresh()

                    Call generateTable()
                    Call StopStep()

                    If frmTrial_exitFlg Then
                        GoTo JPL
                    End If

                    chkBxAutoStuff.Checked = False
                    chkBxAutoStuffRC.Checked = True
                    Call chkBxAutoStuff_MouseClick(sender, e)
                    dgv1.Refresh()
                    Me.Refresh()
                    chkBxAutoStuff.Checked = True
                    Rdb7.Checked = True
                    Call chkBxAutoStuff_MouseClick(sender, e)
                    dgv1.Refresh()
                    Me.Refresh()

                    Call generateTable()
                    Call StopStep()

                    If frmTrial_exitFlg Then
                        GoTo JPL
                    End If

                    chkBxAutoStuff.Checked = False
                    chkBxAutoStuffRC.Checked = False
                    Call chkBxAutoStuff_MouseClick(sender, e)
                    dgv1.Refresh()
                    Me.Refresh()
                    chkBxAutoStuff.Checked = True
                    Rdb8.Checked = True
                    Call chkBxAutoStuff_MouseClick(sender, e)
                    dgv1.Refresh()
                    Me.Refresh()

                    Call generateTable()
                    Call StopStep()

                    If frmTrial_exitFlg Then
                        GoTo JPL
                    End If

                    chkBxAutoStuff.Checked = False
                    chkBxAutoStuffRC.Checked = True
                    Call chkBxAutoStuff_MouseClick(sender, e)
                    dgv1.Refresh()
                    Me.Refresh()
                    chkBxAutoStuff.Checked = True
                    Rdb8.Checked = True
                    Call chkBxAutoStuff_MouseClick(sender, e)
                    dgv1.Refresh()
                    Me.Refresh()

                    Call generateTable()
                    Call StopStep()

                    If frmTrial_exitFlg Then
                        GoTo JPL
                    End If

                    chkBxAutoStuff.Checked = False
                    chkBxAutoStuffRC.Checked = False
                    Call chkBxAutoStuff_MouseClick(sender, e)
                    dgv1.Refresh()
                    Me.Refresh()
                    chkBxAutoStuff.Checked = True
                    Rdb9.Checked = True
                    Call chkBxAutoStuff_MouseClick(sender, e)
                    dgv1.Refresh()
                    Me.Refresh()

                    Call generateTable()
                    Call StopStep()

                    If frmTrial_exitFlg Then
                        GoTo JPL
                    End If

                    chkBxAutoStuff.Checked = False
                    chkBxAutoStuffRC.Checked = True
                    Call chkBxAutoStuff_MouseClick(sender, e)
                    dgv1.Refresh()
                    Me.Refresh()
                    chkBxAutoStuff.Checked = True
                    Rdb9.Checked = True
                    Call chkBxAutoStuff_MouseClick(sender, e)
                    dgv1.Refresh()
                    Me.Refresh()

                    Call generateTable()
                    Call StopStep()

                    If frmTrial_exitFlg Then
                        GoTo JPL
                    End If

                    chkBxAutoStuff.Checked = False
                    chkBxAutoStuffRC.Checked = False
                    Call chkBxAutoStuff_MouseClick(sender, e)
                    dgv1.Refresh()
                    Me.Refresh()
                    chkBxAutoStuff.Checked = True
                    Rdb10.Checked = True
                    Call chkBxAutoStuff_MouseClick(sender, e)
                    dgv1.Refresh()
                    Me.Refresh()

                    Call generateTable()
                    Call StopStep()

                    If frmTrial_exitFlg Then
                        GoTo JPL
                    End If

                    chkBxAutoStuff.Checked = False
                    chkBxAutoStuffRC.Checked = True
                    Call chkBxAutoStuff_MouseClick(sender, e)
                    dgv1.Refresh()
                    Me.Refresh()
                    chkBxAutoStuff.Checked = True
                    Rdb10.Checked = True
                    Call chkBxAutoStuff_MouseClick(sender, e)
                    dgv1.Refresh()
                    Me.Refresh()

                    Call generateTable()
                    Call StopStep()

                    If frmTrial_exitFlg Then
                        GoTo JPL
                    End If

                    chkBxAutoStuff.Checked = False
                    chkBxAutoStuffRC.Checked = False
                    Call chkBxAutoStuff_MouseClick(sender, e)
                    dgv1.Refresh()
                    Me.Refresh()
                    chkBxAutoStuff.Checked = True
                    Rdb11.Checked = True
                    Call chkBxAutoStuff_MouseClick(sender, e)
                    dgv1.Refresh()
                    Me.Refresh()

                    Call generateTable()
                    Call StopStep()

                    If frmTrial_exitFlg Then
                        GoTo JPL
                    End If

                    chkBxAutoStuff.Checked = False
                    chkBxAutoStuffRC.Checked = True
                    Call chkBxAutoStuff_MouseClick(sender, e)
                    dgv1.Refresh()
                    Me.Refresh()
                    chkBxAutoStuff.Checked = True
                    Rdb11.Checked = True
                    Call chkBxAutoStuff_MouseClick(sender, e)
                    dgv1.Refresh()
                    Me.Refresh()

                    Call generateTable()
                    Call StopStep()

                    If frmTrial_exitFlg Then
                        GoTo JPL
                    End If

                    chkBxAutoStuff.Checked = False
                    chkBxAutoStuffRC.Checked = False
                    Call chkBxAutoStuff_MouseClick(sender, e)
                    dgv1.Refresh()
                    Me.Refresh()
                    chkBxAutoStuff.Checked = True
                    Rdb12.Checked = True
                    Call chkBxAutoStuff_MouseClick(sender, e)
                    dgv1.Refresh()
                    Me.Refresh()

                    Call generateTable()
                    Call StopStep()

                    If frmTrial_exitFlg Then
                        GoTo JPL
                    End If

                    chkBxAutoStuff.Checked = False
                    chkBxAutoStuffRC.Checked = True
                    Call chkBxAutoStuff_MouseClick(sender, e)
                    dgv1.Refresh()
                    Me.Refresh()
                    chkBxAutoStuff.Checked = True
                    Rdb12.Checked = True
                    Call chkBxAutoStuff_MouseClick(sender, e)
                    dgv1.Refresh()
                    Me.Refresh()

                    Call generateTable()
                    Call StopStep()

                    If frmTrial_exitFlg Then
                        GoTo JPL
                    End If

                    chkBxAutoStuff.Checked = False
                    chkBxAutoStuffRC.Checked = False
                    Call chkBxAutoStuff_MouseClick(sender, e)
                    dgv1.Refresh()
                    Me.Refresh()
                    chkBxAutoStuff.Checked = True
                    Rdb13.Checked = True
                    Call chkBxAutoStuff_MouseClick(sender, e)
                    dgv1.Refresh()
                    Me.Refresh()

                    Call generateTable()
                    Call StopStep()

                    If frmTrial_exitFlg Then
                        GoTo JPL
                    End If

                    chkBxAutoStuff.Checked = False
                    chkBxAutoStuffRC.Checked = True
                    Call chkBxAutoStuff_MouseClick(sender, e)
                    dgv1.Refresh()
                    Me.Refresh()
                    chkBxAutoStuff.Checked = True
                    Rdb13.Checked = True
                    Call chkBxAutoStuff_MouseClick(sender, e)
                    dgv1.Refresh()
                    Me.Refresh()

                    Call generateTable()
                    Call StopStep()

                    If frmTrial_exitFlg Then
                        GoTo JPL
                    End If

                    chkBxAutoStuff.Checked = False
                    chkBxAutoStuffRC.Checked = False
                    Call chkBxAutoStuff_MouseClick(sender, e)
                    dgv1.Refresh()
                    Me.Refresh()
                    chkBxAutoStuff.Checked = True
                    Rdb14.Checked = True
                    Call chkBxAutoStuff_MouseClick(sender, e)
                    dgv1.Refresh()
                    Me.Refresh()

                    Call generateTable()
                    Call StopStep()

                    If frmTrial_exitFlg Then
                        GoTo JPL
                    End If

                    chkBxAutoStuff.Checked = False
                    chkBxAutoStuffRC.Checked = True
                    Call chkBxAutoStuff_MouseClick(sender, e)
                    dgv1.Refresh()
                    Me.Refresh()
                    chkBxAutoStuff.Checked = True
                    Rdb14.Checked = True
                    Call chkBxAutoStuff_MouseClick(sender, e)
                    dgv1.Refresh()
                    Me.Refresh()

                    Call generateTable()
                    Call StopStep()

                    If frmTrial_exitFlg Then
                        GoTo JPL
                    End If

                    chkBxAutoStuff.Checked = False
                    chkBxAutoStuffRC.Checked = False
                    Call chkBxAutoStuff_MouseClick(sender, e)
                    dgv1.Refresh()
                    Me.Refresh()
                    chkBxAutoStuff.Checked = True
                    Rdb15.Checked = True
                    Call chkBxAutoStuff_MouseClick(sender, e)
                    dgv1.Refresh()
                    Me.Refresh()

                    Call generateTable()
                    Call StopStep()

                    If frmTrial_exitFlg Then
                        GoTo JPL
                    End If

                    chkBxAutoStuff.Checked = False
                    chkBxAutoStuffRC.Checked = True
                    Call chkBxAutoStuff_MouseClick(sender, e)
                    dgv1.Refresh()
                    Me.Refresh()
                    chkBxAutoStuff.Checked = True
                    Rdb15.Checked = True
                    Call chkBxAutoStuff_MouseClick(sender, e)
                    dgv1.Refresh()
                    Me.Refresh()

                    Call generateTable()
                    Call StopStep()

                    If frmTrial_exitFlg Then
                        GoTo JPL
                    End If

                    chkBxAutoStuff.Checked = False
                    chkBxAutoStuffRC.Checked = False
                    Call chkBxAutoStuff_MouseClick(sender, e)
                    dgv1.Refresh()
                    Me.Refresh()
                    chkBxAutoStuff.Checked = True
                    Rdb16.Checked = True
                    Call chkBxAutoStuff_MouseClick(sender, e)
                    dgv1.Refresh()
                    Me.Refresh()

                    Call generateTable()
                    Call StopStep()

                    If frmTrial_exitFlg Then
                        GoTo JPL
                    End If

                    chkBxAutoStuff.Checked = False
                    chkBxAutoStuffRC.Checked = True
                    Call chkBxAutoStuff_MouseClick(sender, e)
                    dgv1.Refresh()
                    Me.Refresh()
                    chkBxAutoStuff.Checked = True
                    Rdb16.Checked = True
                    Call chkBxAutoStuff_MouseClick(sender, e)
                    dgv1.Refresh()
                    Me.Refresh()

                    Call generateTable()
                    Call StopStep()

                    If frmTrial_exitFlg Then
                        GoTo JPL
                    End If
JPL:

                    chkBxAutoStuff.Checked = False
                    chkBxAutoStuffRC.Checked = False
                    Call chkBxAutoStuff_MouseClick(sender, e)
                    dgv1.Refresh()
                    Me.Refresh()
                    Cnt = 0

                    btnPilot.BackColor = Color.MediumTurquoise
                    pilotFlg = False
                    Rdb1.Checked = False
                    Rdb2.Checked = False
                    Rdb3.Checked = False
                    Rdb4.Checked = False
                    Rdb5.Checked = False
                    Rdb6.Checked = False
                    Rdb7.Checked = False
                    Rdb8.Checked = False
                    Rdb9.Checked = False
                    Rdb10.Checked = False
                    Rdb11.Checked = False
                    Rdb12.Checked = False
                    Rdb13.Checked = False
                    Rdb14.Checked = False
                    Rdb15.Checked = False
                    Rdb16.Checked = False

                    frmTrial.TrialShow.Visible = True
                    TrlsFlg = False
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in Pilot", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            frmTrial.chkbxStepTrials.Enabled = True
        End Try

    End Sub

    Public Structure Trials
        Dim SrNo As Short
        Dim LeftQty As Integer
        Dim OccVolP As Double
        Dim Compact As Double
        Dim Rdo As Int16
        Dim RcSep As String
        Dim wrlFN As String
    End Structure

    Dim Trl As New Trials
    Dim Cnt As Integer = 0
    Dim LstTrl As New List(Of Trials)

    Public Sub generateTable()

        Try
            Try
                Trl.LeftQty = 0

                Dim RdP As Int16

                If Rdb1.Checked = True Then
                    RdP = 1
                ElseIf Rdb2.Checked = True Then
                    RdP = 2
                ElseIf Rdb3.Checked = True Then
                    RdP = 3
                ElseIf Rdb4.Checked = True Then
                    RdP = 4
                ElseIf Rdb5.Checked = True Then
                    RdP = 5
                ElseIf Rdb6.Checked = True Then
                    RdP = 6
                ElseIf Rdb7.Checked = True Then
                    RdP = 7
                ElseIf Rdb8.Checked = True Then
                    RdP = 8
                ElseIf Rdb9.Checked = True Then
                    RdP = 9
                ElseIf Rdb10.Checked = True Then
                    RdP = 10
                ElseIf Rdb11.Checked = True Then
                    RdP = 11
                ElseIf Rdb12.Checked = True Then
                    RdP = 12
                ElseIf Rdb13.Checked = True Then
                    RdP = 13
                ElseIf Rdb14.Checked = True Then
                    RdP = 14
                ElseIf Rdb15.Checked = True Then
                    RdP = 15
                ElseIf Rdb16.Checked = True Then
                    RdP = 16
                Else
                    RdP = 0
                End If

                If chkBxAutoStuffRC.Checked = True Then
                    Trl.RcSep = "TRUE"
                ElseIf chkBxAutoStuffRC.Checked = False Then
                    Trl.RcSep = "FALSE"
                Else
                    Trl.RcSep = ""
                End If

                Try
                    For k As Integer = 0 To dgv1.RowCount - 2
                        Trl.LeftQty += dgv1.Item(16, k).Value
                    Next
                Catch
                End Try

                Trl.SrNo = Cnt + 1
                Trl.OccVolP = Me.TxtpercentVolOcc.Text
                Trl.Compact = Me.txtCompactPer.Text
                Trl.Rdo = RdP
                LstTrl.Add(Trl)
                Cnt = Cnt + 1

                If Not (frmTrial.TrialShow.BackColor = Color.HotPink) Then
                    Call AddTrial(Trl.SrNo, Trl.LeftQty, Trl.OccVolP, Trl.Rdo, Trl.RcSep, Trl.Compact)
                End If
            Catch
            End Try

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in Generate table", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub AddTrial(ByVal SrN As Integer, ByVal LeftQty As Integer, ByVal OccVol As Double, ByVal Rdo As Short, ByVal rcSep As String, ByVal Comper As Double)

        Try
            Try

                frmTrial.DgvTrial.Rows.Add()
                frmTrial.DgvTrial.Item(0, SrN - 1).Value = SrN
                frmTrial.DgvTrial.Item(1, SrN - 1).Value = LeftQty
                frmTrial.DgvTrial.Item(2, SrN - 1).Value = OccVol
                frmTrial.DgvTrial.Item(3, SrN - 1).Value = Comper
                frmTrial.DgvTrial.Item(5, SrN - 1).Value = Rdo
                frmTrial.DgvTrial.Item(6, SrN - 1).Value = rcSep
                frmTrial.DgvTrial.Refresh()
                'Dim fStr As String = fileReturn()
                Dim cmd As New OleDb.OleDbCommand
                If conn.State = ConnectionState.Closed Then conn.Open()
                cmd.Connection = conn
                cmd.CommandText = "insert into Trial values(" & SrN & "," & LeftQty & "," & OccVol & "," & Comper & "," & Rdo & ",'" & rcSep & "','" & CurDir() & WrlFn & "')"
                cmd.ExecuteNonQuery()
            Catch
                'MsgBox("Error in add the Trial datagrid value")
            End Try

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in AddTrial", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            frmTrial.DgvTrial.Refresh()
            frmTrial.DgvTrial.Focus()
            frmTrial.DgvTrial.CurrentCell = frmTrial.DgvTrial(0, frmTrial.DgvTrial.RowCount - 1)
            'frmTrial.DgvTrial(0, frmTrial.DgvTrial.RowCount - 1).Selected
        End Try

    End Sub

    Public Function fileReturn() As String

        Try

            Try
                off.Flush()
                off.Close()
            Catch
            End Try
            Dim Str As String = Nothing
            Dim inStream As IoTv.FileStream = New IoTv.FileStream(CurDir() & "\First.wrl", IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.Read)
            Dim strmRead As IoTv.StreamReader = New IoTv.StreamReader(inStream)
            Str = strmRead.ReadToEnd
            Str = CStr(Str)
            inStream.Close()
            strmRead.Close()
            If Not (Str.Length > 0) Then
                Return Nothing
            End If

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in fileReturn", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return Str

    End Function

    Public TrlOFlg As Boolean = False

    Private Sub btnTrlO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTrlO.Click

        '        Try

        '            Dim CmdTrial As New OleDb.OleDbCommand
        '            CmdTrial.Connection = conn
        '            CmdTrial.CommandText = "delete from Trial"
        '            CmdTrial.ExecuteNonQuery()
        '        Catch ex As Exception
        '        End Try

        '        If Not pilotFlg Then

        '            LstTrl.Clear()
        '            frmTrial.TrialShow.Visible = False
        '            Call callTrial()

        '            ' Exit Sub

        '            If Not TrlOFlg Then

        '                TrlOFlg = True

        '            End If

        '            pilotFlg = True
        '            Rdb1.Checked = False
        '            Rdb2.Checked = False
        '            Rdb3.Checked = False
        '            Rdb4.Checked = False
        '            Rdb5.Checked = False
        '            Rdb6.Checked = False
        '            Rdb7.Checked = False
        '            Rdb8.Checked = False
        '            Rdb9.Checked = False
        '            Rdb10.Checked = False
        '            Rdb11.Checked = False
        '            Rdb12.Checked = False
        '            Rdb13.Checked = False
        '            Rdb14.Checked = False
        '            Rdb15.Checked = False
        '            Rdb16.Checked = False

        '            chkBxAutoStuff.Checked = False
        '            chkBxAutoStuffRC.Checked = False
        '            Call chkBxAutoStuff_MouseClick(sender, e)

        '            btnTrlO.BackColor = Color.HotPink
        '            chkBxAutoStuff.Checked = True
        '            Call chkBxAutoStuff_MouseClick(sender, e)
        '            dgv1.Refresh()
        '            Me.Refresh()

        '            Call generateTable()
        '            Call StopStep()

        '            chkBxAutoStuff.Checked = False
        '            Call chkBxAutoStuff_MouseClick(sender, e)
        '            chkBxAutoStuff.Checked = True
        '            chkBxAutoStuffRC.Checked = True
        '            Call chkBxAutoStuff_MouseClick(sender, e)
        '            dgv1.Refresh()
        '            Me.Refresh()

        '            Call generateTable()
        '            Call StopStep()

        '            chkBxAutoStuff.Checked = False
        '            chkBxAutoStuffRC.Checked = False
        '            Call chkBxAutoStuff_MouseClick(sender, e)
        '            chkBxAutoStuff.Checked = True
        '            Rdb1.Checked = True
        '            Call chkBxAutoStuff_MouseClick(sender, e)
        '            dgv1.Refresh()
        '            Me.Refresh()

        '            Call generateTable()
        '            Call StopStep()

        '            chkBxAutoStuff.Checked = False
        '            chkBxAutoStuffRC.Checked = True
        '            Call chkBxAutoStuff_MouseClick(sender, e)
        '            chkBxAutoStuff.Checked = True
        '            Rdb1.Checked = True
        '            Call chkBxAutoStuff_MouseClick(sender, e)
        '            dgv1.Refresh()
        '            Me.Refresh()

        '            Call generateTable()
        '            Call StopStep()

        '            chkBxAutoStuff.Checked = False
        '            chkBxAutoStuffRC.Checked = False
        '            Call chkBxAutoStuff_MouseClick(sender, e)
        '            chkBxAutoStuff.Checked = True
        '            Rdb2.Checked = True
        '            Call chkBxAutoStuff_MouseClick(sender, e)
        '            dgv1.Refresh()
        '            Me.Refresh()

        '            Call generateTable()
        '            Call StopStep()

        '            chkBxAutoStuff.Checked = False
        '            chkBxAutoStuffRC.Checked = True
        '            Call chkBxAutoStuff_MouseClick(sender, e)
        '            chkBxAutoStuff.Checked = True
        '            Rdb2.Checked = True
        '            Call chkBxAutoStuff_MouseClick(sender, e)
        '            dgv1.Refresh()
        '            Me.Refresh()

        '            Call generateTable()
        '            Call StopStep()

        '            chkBxAutoStuff.Checked = False
        '            chkBxAutoStuffRC.Checked = False
        '            Call chkBxAutoStuff_MouseClick(sender, e)
        '            chkBxAutoStuff.Checked = True
        '            Rdb3.Checked = True
        '            Call chkBxAutoStuff_MouseClick(sender, e)
        '            dgv1.Refresh()
        '            Me.Refresh()

        '            Call generateTable()
        '            Call StopStep()

        '            chkBxAutoStuff.Checked = False
        '            chkBxAutoStuffRC.Checked = True
        '            Call chkBxAutoStuff_MouseClick(sender, e)
        '            chkBxAutoStuff.Checked = True
        '            Rdb3.Checked = True
        '            Call chkBxAutoStuff_MouseClick(sender, e)
        '            dgv1.Refresh()
        '            Me.Refresh()

        '            Call generateTable()
        '            Call StopStep()

        '            chkBxAutoStuff.Checked = False
        '            chkBxAutoStuffRC.Checked = False
        '            Call chkBxAutoStuff_MouseClick(sender, e)
        '            chkBxAutoStuff.Checked = True
        '            Rdb4.Checked = True
        '            Call chkBxAutoStuff_MouseClick(sender, e)
        '            dgv1.Refresh()
        '            Me.Refresh()

        '            Call generateTable()
        '            Call StopStep()

        '            chkBxAutoStuff.Checked = False
        '            chkBxAutoStuffRC.Checked = True
        '            Call chkBxAutoStuff_MouseClick(sender, e)
        '            chkBxAutoStuff.Checked = True
        '            Rdb4.Checked = True
        '            Call chkBxAutoStuff_MouseClick(sender, e)
        '            dgv1.Refresh()
        '            Me.Refresh()

        '            Call generateTable()
        '            Call StopStep()

        '            chkBxAutoStuff.Checked = False
        '            chkBxAutoStuffRC.Checked = False
        '            Call chkBxAutoStuff_MouseClick(sender, e)
        '            chkBxAutoStuff.Checked = True
        '            Rdb5.Checked = True
        '            Call chkBxAutoStuff_MouseClick(sender, e)
        '            dgv1.Refresh()
        '            Me.Refresh()

        '            Call generateTable()
        '            Call StopStep()

        '            chkBxAutoStuff.Checked = False
        '            chkBxAutoStuffRC.Checked = True
        '            Call chkBxAutoStuff_MouseClick(sender, e)
        '            chkBxAutoStuff.Checked = True
        '            Rdb5.Checked = True
        '            Call chkBxAutoStuff_MouseClick(sender, e)
        '            dgv1.Refresh()
        '            Me.Refresh()

        '            GoTo Jp

        '            Call generateTable()
        '            Call StopStep()

        '            chkBxAutoStuff.Checked = False
        '            chkBxAutoStuffRC.Checked = False
        '            Call chkBxAutoStuff_MouseClick(sender, e)
        '            chkBxAutoStuff.Checked = True
        '            Rdb6.Checked = True
        '            Call chkBxAutoStuff_MouseClick(sender, e)
        '            dgv1.Refresh()
        '            Me.Refresh()

        '            Call generateTable()
        '            Call StopStep()

        '            chkBxAutoStuff.Checked = False
        '            chkBxAutoStuffRC.Checked = True
        '            Call chkBxAutoStuff_MouseClick(sender, e)
        '            chkBxAutoStuff.Checked = True
        '            Rdb6.Checked = True
        '            Call chkBxAutoStuff_MouseClick(sender, e)
        '            dgv1.Refresh()
        '            Me.Refresh()

        '            Call generateTable()
        '            Call StopStep()

        '            chkBxAutoStuff.Checked = False
        '            chkBxAutoStuffRC.Checked = False
        '            Call chkBxAutoStuff_MouseClick(sender, e)
        '            chkBxAutoStuff.Checked = True
        '            Rdb7.Checked = True
        '            Call chkBxAutoStuff_MouseClick(sender, e)
        '            dgv1.Refresh()
        '            Me.Refresh()

        '            Call generateTable()
        '            Call StopStep()

        '            chkBxAutoStuff.Checked = False
        '            chkBxAutoStuffRC.Checked = True
        '            Call chkBxAutoStuff_MouseClick(sender, e)
        '            chkBxAutoStuff.Checked = True
        '            Rdb7.Checked = True
        '            Call chkBxAutoStuff_MouseClick(sender, e)
        '            dgv1.Refresh()
        '            Me.Refresh()

        '            Call generateTable()
        '            Call StopStep()

        '            chkBxAutoStuff.Checked = False
        '            chkBxAutoStuffRC.Checked = False
        '            Call chkBxAutoStuff_MouseClick(sender, e)
        '            chkBxAutoStuff.Checked = True
        '            Rdb8.Checked = True
        '            Call chkBxAutoStuff_MouseClick(sender, e)
        '            dgv1.Refresh()
        '            Me.Refresh()

        '            Call generateTable()
        '            Call StopStep()

        '            chkBxAutoStuff.Checked = False
        '            chkBxAutoStuffRC.Checked = True
        '            Call chkBxAutoStuff_MouseClick(sender, e)
        '            chkBxAutoStuff.Checked = True
        '            Rdb8.Checked = True
        '            Call chkBxAutoStuff_MouseClick(sender, e)
        '            dgv1.Refresh()
        '            Me.Refresh()

        '            Call generateTable()
        '            Call StopStep()

        '            chkBxAutoStuff.Checked = False
        '            chkBxAutoStuffRC.Checked = False
        '            Call chkBxAutoStuff_MouseClick(sender, e)
        '            chkBxAutoStuff.Checked = True
        '            Rdb9.Checked = True
        '            Call chkBxAutoStuff_MouseClick(sender, e)
        '            dgv1.Refresh()
        '            Me.Refresh()

        '            Call generateTable()
        '            Call StopStep()

        '            chkBxAutoStuff.Checked = False
        '            chkBxAutoStuffRC.Checked = True
        '            Call chkBxAutoStuff_MouseClick(sender, e)
        '            chkBxAutoStuff.Checked = True
        '            Rdb9.Checked = True
        '            Call chkBxAutoStuff_MouseClick(sender, e)
        '            dgv1.Refresh()
        '            Me.Refresh()

        '            Call generateTable()
        '            Call StopStep()

        '            chkBxAutoStuff.Checked = False
        '            chkBxAutoStuffRC.Checked = False
        '            Call chkBxAutoStuff_MouseClick(sender, e)
        '            chkBxAutoStuff.Checked = True
        '            Rdb10.Checked = True
        '            Call chkBxAutoStuff_MouseClick(sender, e)
        '            dgv1.Refresh()
        '            Me.Refresh()

        '            Call generateTable()
        '            Call StopStep()

        '            chkBxAutoStuff.Checked = False
        '            chkBxAutoStuffRC.Checked = True
        '            Call chkBxAutoStuff_MouseClick(sender, e)
        '            chkBxAutoStuff.Checked = True
        '            Rdb10.Checked = True
        '            Call chkBxAutoStuff_MouseClick(sender, e)
        '            dgv1.Refresh()
        '            Me.Refresh()

        '            Call generateTable()
        '            Call StopStep()

        '            chkBxAutoStuff.Checked = False
        '            chkBxAutoStuffRC.Checked = False
        '            Call chkBxAutoStuff_MouseClick(sender, e)
        '            chkBxAutoStuff.Checked = True
        '            Rdb11.Checked = True
        '            Call chkBxAutoStuff_MouseClick(sender, e)
        '            dgv1.Refresh()
        '            Me.Refresh()

        '            Call generateTable()
        '            Call StopStep()

        '            chkBxAutoStuff.Checked = False
        '            chkBxAutoStuffRC.Checked = True
        '            Call chkBxAutoStuff_MouseClick(sender, e)
        '            chkBxAutoStuff.Checked = True
        '            Rdb11.Checked = True
        '            Call chkBxAutoStuff_MouseClick(sender, e)
        '            dgv1.Refresh()
        '            Me.Refresh()

        '            Call generateTable()
        '            Call StopStep()

        '            chkBxAutoStuff.Checked = False
        '            chkBxAutoStuffRC.Checked = False
        '            Call chkBxAutoStuff_MouseClick(sender, e)
        '            chkBxAutoStuff.Checked = True
        '            Rdb12.Checked = True
        '            Call chkBxAutoStuff_MouseClick(sender, e)
        '            dgv1.Refresh()
        '            Me.Refresh()

        '            Call generateTable()
        '            Call StopStep()

        '            chkBxAutoStuff.Checked = False
        '            chkBxAutoStuffRC.Checked = True
        '            Call chkBxAutoStuff_MouseClick(sender, e)
        '            chkBxAutoStuff.Checked = True
        '            Rdb12.Checked = True
        '            Call chkBxAutoStuff_MouseClick(sender, e)
        '            dgv1.Refresh()
        '            Me.Refresh()

        '            Call generateTable()
        '            Call StopStep()

        '            chkBxAutoStuff.Checked = False
        '            chkBxAutoStuffRC.Checked = False
        '            Call chkBxAutoStuff_MouseClick(sender, e)
        '            chkBxAutoStuff.Checked = True
        '            Rdb13.Checked = True
        '            Call chkBxAutoStuff_MouseClick(sender, e)
        '            dgv1.Refresh()
        '            Me.Refresh()

        '            Call generateTable()
        '            Call StopStep()

        '            chkBxAutoStuff.Checked = False
        '            chkBxAutoStuffRC.Checked = True
        '            Call chkBxAutoStuff_MouseClick(sender, e)
        '            chkBxAutoStuff.Checked = True
        '            Rdb13.Checked = True
        '            Call chkBxAutoStuff_MouseClick(sender, e)
        '            dgv1.Refresh()
        '            Me.Refresh()

        '            Call generateTable()
        '            Call StopStep()

        '            chkBxAutoStuff.Checked = False
        '            chkBxAutoStuffRC.Checked = False
        '            Call chkBxAutoStuff_MouseClick(sender, e)
        '            chkBxAutoStuff.Checked = True
        '            Rdb14.Checked = True
        '            Call chkBxAutoStuff_MouseClick(sender, e)
        '            dgv1.Refresh()
        '            Me.Refresh()

        '            Call generateTable()
        '            Call StopStep()

        '            chkBxAutoStuff.Checked = False
        '            chkBxAutoStuffRC.Checked = True
        '            Call chkBxAutoStuff_MouseClick(sender, e)
        '            chkBxAutoStuff.Checked = True
        '            Rdb14.Checked = True
        '            Call chkBxAutoStuff_MouseClick(sender, e)
        '            dgv1.Refresh()
        '            Me.Refresh()

        '            Call generateTable()
        '            Call StopStep()

        '            chkBxAutoStuff.Checked = False
        '            chkBxAutoStuffRC.Checked = False
        '            Call chkBxAutoStuff_MouseClick(sender, e)
        '            chkBxAutoStuff.Checked = True
        '            Rdb15.Checked = True
        '            Call chkBxAutoStuff_MouseClick(sender, e)
        '            dgv1.Refresh()
        '            Me.Refresh()

        '            Call generateTable()
        '            Call StopStep()

        '            chkBxAutoStuff.Checked = False
        '            chkBxAutoStuffRC.Checked = True
        '            Call chkBxAutoStuff_MouseClick(sender, e)
        '            chkBxAutoStuff.Checked = True
        '            Rdb15.Checked = True
        '            Call chkBxAutoStuff_MouseClick(sender, e)
        '            dgv1.Refresh()
        '            Me.Refresh()

        '            Call generateTable()
        '            Call StopStep()

        '            chkBxAutoStuff.Checked = False
        '            chkBxAutoStuffRC.Checked = False
        '            Call chkBxAutoStuff_MouseClick(sender, e)
        '            chkBxAutoStuff.Checked = True
        '            Rdb16.Checked = True
        '            Call chkBxAutoStuff_MouseClick(sender, e)
        '            dgv1.Refresh()
        '            Me.Refresh()

        '            Call generateTable()
        '            Call StopStep()

        '            chkBxAutoStuff.Checked = False
        '            chkBxAutoStuffRC.Checked = True
        '            Call chkBxAutoStuff_MouseClick(sender, e)
        '            chkBxAutoStuff.Checked = True
        '            Rdb16.Checked = True
        '            Call chkBxAutoStuff_MouseClick(sender, e)
        '            dgv1.Refresh()
        '            Me.Refresh()

        '            Call generateTable()
        '            Call StopStep()

        '            chkBxAutoStuff.Checked = False
        '            chkBxAutoStuffRC.Checked = False
        '            Call chkBxAutoStuff_MouseClick(sender, e)
        '            dgv1.Refresh()
        '            Me.Refresh()
        '            Cnt = 0

        '            btnTrlO.BackColor = Color.MediumTurquoise
        '            pilotFlg = False
        '            Rdb1.Checked = False
        '            Rdb2.Checked = False
        '            Rdb3.Checked = False
        '            Rdb4.Checked = False
        '            Rdb5.Checked = False
        '            Rdb6.Checked = False
        '            Rdb7.Checked = False
        '            Rdb8.Checked = False
        '            Rdb9.Checked = False
        '            Rdb10.Checked = False
        '            Rdb11.Checked = False
        '            Rdb12.Checked = False
        '            Rdb13.Checked = False
        '            Rdb14.Checked = False
        '            Rdb15.Checked = False
        '            Rdb16.Checked = False

        '            TrlOFlg = False
        '            frmTrial.DgvTrial.Visible = True

        '        End If

        'Jp:

        '        Call OptTrial(sender, e)


    End Sub

    Public Sub OptTrial(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)

        Try
            Try

                Dim CmdCompt As New OleDb.OleDbCommand
                Dim RdrCompt As OleDb.OleDbDataReader = Nothing

                Dim cmd As New OleDb.OleDbCommand
                Dim cmd1 As New OleDb.OleDbCommand
                Dim cmd2 As New OleDb.OleDbCommand
                Dim rdr1 As OleDb.OleDbDataReader
                Dim rdr2 As OleDb.OleDbDataReader

                If conn.State = ConnectionState.Closed Then conn.Open()
                CmdCompt.Connection = conn

                CmdCompt.CommandText = "select max(Comper) from trial"
                Dim Compact As Double = CmdCompt.ExecuteScalar
                CmdCompt.Dispose()
                conn.Close()

                If conn.State = ConnectionState.Closed Then conn.Open()
                cmd.Connection = conn

                cmd.CommandText = "select count(leftqty) from trial where leftqty = (select min(leftqty) from trial)"

                Dim repRow As Integer = cmd.ExecuteScalar

                cmd.Dispose()
                conn.Close()

                If conn.State = ConnectionState.Closed Then conn.Open()
                cmd2.Connection = conn

                cmd2.CommandText = "Select min(leftqty) from trial"

                Dim MinLQ As Integer = cmd2.ExecuteScalar

                If repRow > 1 Then

                    If conn.State = ConnectionState.Closed Then conn.Open()
                    cmd1.Connection = conn

                    cmd1.CommandText = "select SrNo, LeftQty, OccVolPer, Comper, RdOpt, RCSep, wrlFn from Trial where LeftQty=" & MinLQ
                    rdr2 = cmd1.ExecuteReader

                    Dim j As Integer = 0
                    Try


LpR1:
                        For i As Integer = 0 To frmTrial.DgvTrial.RowCount - 1
                            frmTrial.DgvTrial.Rows.Remove(frmTrial.DgvTrial.Rows(i))
                        Next

                    Catch
                        j += 1
                        If j > 10 Then
                            Exit Try
                        End If
                        GoTo LpR1
                    End Try

                    Dim srn As Integer = 1

                    While (rdr2.Read)

                        Trl.SrNo = rdr2("SrNo")
                        Trl.LeftQty = rdr2("LeftQty")
                        Trl.OccVolP = rdr2("OccVolPer")
                        Trl.Compact = rdr2("Comper")
                        Trl.Rdo = rdr2("RdOpt")
                        Trl.RcSep = rdr2("RCSep")
                        Trl.wrlFN = rdr2("wrlFn")

                        Trl.SrNo = srn

                        frmTrial.DgvTrial.Rows.Add()
                        frmTrial.DgvTrial.Item(0, Trl.SrNo - 1).Value = Trl.SrNo
                        frmTrial.DgvTrial.Item(1, Trl.SrNo - 1).Value = Trl.LeftQty
                        frmTrial.DgvTrial.Item(2, Trl.SrNo - 1).Value = Trl.OccVolP
                        frmTrial.DgvTrial.Item(3, Trl.SrNo - 1).Value = Trl.Compact
                        frmTrial.DgvTrial.Item(5, Trl.SrNo - 1).Value = Trl.Rdo
                        frmTrial.DgvTrial.Item(6, Trl.SrNo - 1).Value = Trl.RcSep
                        frmTrial.DgvTrial.Refresh()
                        srn += 1

                    End While

                    If frmTrial.chkbxCompactShow.Checked = True Then

                        'DeleteTrialDb()

                        AddOptTrialCompactRun(sender, e)

                    Else

                        MessageBox.Show("Optimum results is more than one, Press show button to see the optimum results", Me.Text, MessageBoxButtons.OK)

                    End If

                    TrlOFlg = False
                    pilotFlg = False

                    Exit Sub

                Else
                    If conn.State = ConnectionState.Closed Then conn.Open()
                    cmd1.Connection = conn

                    cmd1.CommandText = "select SrNo, LeftQty, OccVolPer, Comper, RdOpt, RCSep, wrlFn from Trial where LeftQty=" & MinLQ
                    rdr1 = cmd1.ExecuteReader

                    Dim j As Integer = 0
                    Try

LpR:
                        For i As Integer = 0 To frmTrial.DgvTrial.RowCount - 1
                            frmTrial.DgvTrial.Rows.Remove(frmTrial.DgvTrial.Rows(i))
                        Next

                    Catch
                        j += 1
                        If j > 10 Then
                            Exit Try
                        End If
                        GoTo LpR
                    End Try

                    frmTrial.Refresh()

                    Call deleteTablexml("TrialStuff")

                    While (rdr1.Read)

                        Dim SrN As Integer

                        Trl.SrNo = rdr1("SrNo")

                        SrN = Trl.SrNo

                        Trl.LeftQty = rdr1("LeftQty")
                        Trl.OccVolP = rdr1("OccVolPer")
                        Trl.Compact = rdr1("Comper")
                        Trl.Rdo = rdr1("RdOpt")
                        Trl.RcSep = rdr1("RCSep")
                        Trl.wrlFN = rdr1("wrlFn")

                        Trl.SrNo = 1 'Trl.SrNo = Trl.SrNo             'Trl.SrNo = 1

                        frmTrial.DgvTrial.Rows.Add()
                        frmTrial.DgvTrial.Item(0, Trl.SrNo - 1).Value = SrN
                        frmTrial.DgvTrial.Item(1, Trl.SrNo - 1).Value = Trl.LeftQty
                        frmTrial.DgvTrial.Item(2, Trl.SrNo - 1).Value = Trl.OccVolP
                        frmTrial.DgvTrial.Item(3, Trl.SrNo - 1).Value = Trl.Compact
                        frmTrial.DgvTrial.Item(5, Trl.SrNo - 1).Value = Trl.Rdo
                        frmTrial.DgvTrial.Item(6, Trl.SrNo - 1).Value = Trl.RcSep
                        frmTrial.DgvTrial.Refresh()

                        Call InsertTablexml("TrialStuff", New Object() {(SrN), (Trl.LeftQty), (Trl.OccVolP), (Trl.Compact), (Trl.Rdo), CStr(Trl.RcSep), CStr(Trl.wrlFN)})

                    End While

                    '**********************************************************************************************

                    'Call deleteTablexml("TrialStuff")
                    'While (rdr1.Read)
                    '    Trl.SrNo = rdr1("SrNo")
                    '    Trl.LeftQty = rdr1("LeftQty")
                    '    Trl.OccVolP = rdr1("OccVolPer")
                    '    Trl.Compact = rdr1("Comper")
                    '    Trl.Rdo = rdr1("RdOpt")
                    '    Trl.RcSep = rdr1("RCSep")
                    '    Trl.wrlFN = rdr1("wrlFn")
                    '    Call InsertTablexml("TrialStuff", New Object() {(Trl.SrNo), (Trl.LeftQty), (Trl.OccVolP), (Trl.Compact), (Trl.Rdo), CStr(Trl.RcSep), CStr(Trl.wrlFN)})
                    'End While

                    '**********************************************************************************************


                End If
            Catch Err As Exception
                MsgBox(Err.Message)
                MsgBox(Err.ToString)
                MessageBox.Show("Error in Adding data to database", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
            End Try

            TrlOFlg = False
            pilotFlg = False

            Try
                frmTrial.Refresh()
                frmTrial.DgvTrial.CurrentCell = frmTrial.DgvTrial(4, frmTrial.DgvTrial.RowCount - 2)
                'frmTrial.DgvTrial.CurrentCell = frmTrial.DgvTrial(3, frmTrial.DgvTrial.RowCount - 2)
            Catch
            End Try

            frmTrial.TrialShow_MouseClick(sender, e)

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in OptTrial", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub AddOptTrialCompactRun(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)

        Dim Aot As New Trials
        Dim Cmdt As New OleDb.OleDbCommand
        Dim Rdrt As OleDb.OleDbDataReader = Nothing

        frmTrial.DgvTrial.Refresh()

        Try

            For jj As Integer = 0 To frmTrial.DgvTrial.RowCount - 2

                Aot.SrNo = frmTrial.DgvTrial.Item(0, jj).Value
                Aot.LeftQty = frmTrial.DgvTrial.Item(1, jj).Value
                Aot.OccVolP = frmTrial.DgvTrial.Item(2, jj).Value
                Aot.Compact = frmTrial.DgvTrial.Item(3, jj).Value
                Aot.Rdo = frmTrial.DgvTrial.Item(5, jj).Value
                Aot.RcSep = frmTrial.DgvTrial.Item(6, jj).Value
                Dim cmd As New OleDb.OleDbCommand
                If conn.State = ConnectionState.Closed Then conn.Open()
                cmd.Connection = conn
                cmd.CommandText = "insert into Trial values(" & Aot.SrNo & "," & Aot.LeftQty & "," & Aot.OccVolP & "," & Aot.Compact & "," & Aot.Rdo & ",'" & Aot.RcSep & "')"
                cmd.ExecuteNonQuery()
                cmd.Dispose()

            Next

            conn.Close()

            Dim j As Integer = 0
            Try
LpR:
                For i As Integer = 0 To frmTrial.DgvTrial.RowCount - 1
                    frmTrial.DgvTrial.Rows.Remove(frmTrial.DgvTrial.Rows(i))
                Next

            Catch
                j += 1
                If j > 10 Then
                    Exit Try
                End If
                GoTo LpR
            End Try

            If conn.State = ConnectionState.Closed Then conn.Open()
            Cmdt.Connection = conn

            Cmdt.CommandText = "select count(Comper) from trial where Comper = (select max(Comper) from trial)"
            Dim cVal As Integer = Cmdt.ExecuteScalar
            Cmdt.Dispose()
            conn.Close()

            frmTrial.DgvTrial.Refresh()

            Dim cmd2 As New OleDb.OleDbCommand
            If conn.State = ConnectionState.Closed Then conn.Open()
            cmd2.Connection = conn

            cmd2.CommandText = "Select max(Comper) from trial"
            Dim MaxCompt As Double = cmd2.ExecuteScalar

            cmd2.Dispose()
            conn.Close()

            If cVal > 1 Then

                Dim Cmd1 As New OleDb.OleDbCommand
                Dim Rdr1 As OleDb.OleDbDataReader

                If conn.State = ConnectionState.Closed Then conn.Open()
                Cmd1.Connection = conn

                Cmd1.CommandText = "select SrNo, LeftQty, OccVolPer, Comper, RdOpt, RCSep from Trial where Comper=" & MaxCompt
                Rdr1 = Cmd1.ExecuteReader

                Dim srno As Integer = 1

                While (Rdr1.Read)

                    Trl.SrNo = Rdr1("SrNo")
                    Trl.LeftQty = Rdr1("LeftQty")
                    Trl.OccVolP = Rdr1("OccVolPer")
                    Trl.Compact = Rdr1("Comper")
                    Trl.Rdo = Rdr1("RdOpt")
                    Trl.RcSep = Rdr1("RCSep")

                    Trl.SrNo = srno

                    frmTrial.DgvTrial.Rows.Add()
                    frmTrial.DgvTrial.Item(0, Trl.SrNo - 1).Value = Trl.SrNo
                    frmTrial.DgvTrial.Item(1, Trl.SrNo - 1).Value = Trl.LeftQty
                    frmTrial.DgvTrial.Item(2, Trl.SrNo - 1).Value = Trl.OccVolP
                    frmTrial.DgvTrial.Item(3, Trl.SrNo - 1).Value = Trl.Compact
                    frmTrial.DgvTrial.Item(5, Trl.SrNo - 1).Value = Trl.Rdo
                    frmTrial.DgvTrial.Item(6, Trl.SrNo - 1).Value = Trl.RcSep
                    frmTrial.DgvTrial.Refresh()
                    srno += 1

                End While

                MessageBox.Show("Optimum results is more than one, Press show button to see the optimum results", Me.Text, MessageBoxButtons.OK)

                TrlOFlg = False
                pilotFlg = False

                Exit Sub

            Else

                Dim Cmd1 As New OleDb.OleDbCommand
                Dim Rdr1 As OleDb.OleDbDataReader

                If conn.State = ConnectionState.Closed Then conn.Open()
                Cmd1.Connection = conn

                Cmd1.CommandText = "select SrNo, LeftQty, OccVolPer, Comper, RdOpt, RCSep from Trial where Comper=" & MaxCompt
                Rdr1 = Cmd1.ExecuteReader

                While (Rdr1.Read)

                    Trl.SrNo = Rdr1("SrNo")
                    Trl.LeftQty = Rdr1("LeftQty")
                    Trl.OccVolP = Rdr1("OccVolPer")
                    Trl.Compact = Rdr1("Comper")
                    Trl.Rdo = Rdr1("RdOpt")
                    Trl.RcSep = Rdr1("RCSep")

                    Trl.SrNo = 1

                    frmTrial.DgvTrial.Rows.Add()
                    frmTrial.DgvTrial.Item(0, Trl.SrNo - 1).Value = Trl.SrNo
                    frmTrial.DgvTrial.Item(1, Trl.SrNo - 1).Value = Trl.LeftQty
                    frmTrial.DgvTrial.Item(2, Trl.SrNo - 1).Value = Trl.OccVolP
                    frmTrial.DgvTrial.Item(3, Trl.SrNo - 1).Value = Trl.Compact
                    frmTrial.DgvTrial.Item(5, Trl.SrNo - 1).Value = Trl.Rdo
                    frmTrial.DgvTrial.Item(6, Trl.SrNo - 1).Value = Trl.RcSep
                    frmTrial.DgvTrial.Refresh()

                End While
            End If

            TrlOFlg = False
            pilotFlg = False
            frmTrial.DgvTrial.CurrentCell = frmTrial.DgvTrial(4, frmTrial.DgvTrial.RowCount - 2)
            frmTrial.TrialShow_MouseClick(sender, e)

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in AddOptTrialCompactRun", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub DeleteTrialDb()

        Try

            Try
                If conn.State = ConnectionState.Closed Then conn.Open()

                Dim CmdTrial As New OleDb.OleDbCommand
                CmdTrial.Connection = conn
                CmdTrial.CommandText = "delete from Trial"
                CmdTrial.ExecuteNonQuery()

            Catch ex As Exception
            End Try

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in DeleteTrialDb", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnTrlO_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnTrlO.MouseClick

        Try
            SrNWrlFn = 0
            Call DeleteWrlOutFiles()

            If Not (Str = "UpdateComplete" Or Str = Nothing) Then
                MessageBox.Show("Update Complete the stuffing entry then continue", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Exit Sub
            End If

            frmTrial_exitFlg = False

            Trl = Nothing
            Cnt = 0
            LstTrl.Clear()
            TrlOFlg = False
            pilotFlg = False

            Call DeleteTrialDb()

            If Not pilotFlg Then

                LstTrl.Clear()
                frmTrial.TrialShow.Visible = False
                Call callTrial()

                ' Exit Sub

                If Not TrlOFlg Then

                    TrlOFlg = True

                End If

                pilotFlg = True
                Rdb1.Checked = False
                Rdb2.Checked = False
                Rdb3.Checked = False
                Rdb4.Checked = False
                Rdb5.Checked = False
                Rdb6.Checked = False
                Rdb7.Checked = False
                Rdb8.Checked = False
                Rdb9.Checked = False
                Rdb10.Checked = False
                Rdb11.Checked = False
                Rdb12.Checked = False
                Rdb13.Checked = False
                Rdb14.Checked = False
                Rdb15.Checked = False
                Rdb16.Checked = False

                chkBxAutoStuff.Checked = False
                chkBxAutoStuffRC.Checked = False
                Call chkBxAutoStuff_MouseClick(sender, e)
                dgv1.Refresh()
                Me.Refresh()

                If frmTrial_exitFlg Then
                    GoTo JPL
                End If

                btnTrlO.BackColor = Color.HotPink
                chkBxAutoStuff.Checked = True
                Call chkBxAutoStuff_MouseClick(sender, e)
                dgv1.Refresh()
                Me.Refresh()

                Call generateTable()
                'Call StopStep()                        The Comment the Line 8 Sept 2009

                If frmTrial_exitFlg Then
                    GoTo JPL
                End If

                chkBxAutoStuff.Checked = False
                Call chkBxAutoStuff_MouseClick(sender, e)
                dgv1.Refresh()
                Me.Refresh()
                chkBxAutoStuff.Checked = True
                chkBxAutoStuffRC.Checked = True
                Call chkBxAutoStuff_MouseClick(sender, e)
                dgv1.Refresh()
                Me.Refresh()

                Call generateTable()
                'Call StopStep()

                If frmTrial_exitFlg Then
                    GoTo JPL
                End If

                chkBxAutoStuff.Checked = False
                chkBxAutoStuffRC.Checked = False
                Call chkBxAutoStuff_MouseClick(sender, e)
                dgv1.Refresh()
                Me.Refresh()
                chkBxAutoStuff.Checked = True
                Rdb1.Checked = True
                Call chkBxAutoStuff_MouseClick(sender, e)
                dgv1.Refresh()
                Me.Refresh()

                Call generateTable()
                'Call StopStep()

                If frmTrial_exitFlg Then
                    GoTo JPL
                End If

                chkBxAutoStuff.Checked = False
                chkBxAutoStuffRC.Checked = True
                Call chkBxAutoStuff_MouseClick(sender, e)
                dgv1.Refresh()
                Me.Refresh()
                chkBxAutoStuff.Checked = True
                Rdb1.Checked = True
                Call chkBxAutoStuff_MouseClick(sender, e)
                dgv1.Refresh()
                Me.Refresh()

                Call generateTable()
                'Call StopStep()

                If frmTrial_exitFlg Then
                    GoTo JPL
                End If

                chkBxAutoStuff.Checked = False
                chkBxAutoStuffRC.Checked = False
                Call chkBxAutoStuff_MouseClick(sender, e)
                dgv1.Refresh()
                Me.Refresh()
                chkBxAutoStuff.Checked = True
                Rdb2.Checked = True
                Call chkBxAutoStuff_MouseClick(sender, e)
                dgv1.Refresh()
                Me.Refresh()

                Call generateTable()
                'Call StopStep()

                If frmTrial_exitFlg Then
                    GoTo JPL
                End If

                chkBxAutoStuff.Checked = False
                chkBxAutoStuffRC.Checked = True
                Call chkBxAutoStuff_MouseClick(sender, e)
                dgv1.Refresh()
                Me.Refresh()
                chkBxAutoStuff.Checked = True
                Rdb2.Checked = True
                Call chkBxAutoStuff_MouseClick(sender, e)
                dgv1.Refresh()
                Me.Refresh()

                Call generateTable()
                'Call StopStep()

                If frmTrial_exitFlg Then
                    GoTo JPL
                End If

                chkBxAutoStuff.Checked = False
                chkBxAutoStuffRC.Checked = False
                Call chkBxAutoStuff_MouseClick(sender, e)
                dgv1.Refresh()
                Me.Refresh()
                chkBxAutoStuff.Checked = True
                Rdb3.Checked = True
                Call chkBxAutoStuff_MouseClick(sender, e)
                dgv1.Refresh()
                Me.Refresh()

                Call generateTable()
                'Call StopStep()

                If frmTrial_exitFlg Then
                    GoTo JPL
                End If

                chkBxAutoStuff.Checked = False
                chkBxAutoStuffRC.Checked = True
                Call chkBxAutoStuff_MouseClick(sender, e)
                dgv1.Refresh()
                Me.Refresh()
                chkBxAutoStuff.Checked = True
                Rdb3.Checked = True
                Call chkBxAutoStuff_MouseClick(sender, e)
                dgv1.Refresh()
                Me.Refresh()

                Call generateTable()
                'Call StopStep()

                If frmTrial_exitFlg Then
                    GoTo JPL
                End If

                chkBxAutoStuff.Checked = False
                chkBxAutoStuffRC.Checked = False
                Call chkBxAutoStuff_MouseClick(sender, e)
                dgv1.Refresh()
                Me.Refresh()
                chkBxAutoStuff.Checked = True
                Rdb4.Checked = True
                Call chkBxAutoStuff_MouseClick(sender, e)
                dgv1.Refresh()
                Me.Refresh()

                Call generateTable()
                'Call StopStep()

                If frmTrial_exitFlg Then
                    GoTo JPL
                End If

                chkBxAutoStuff.Checked = False
                chkBxAutoStuffRC.Checked = True
                Call chkBxAutoStuff_MouseClick(sender, e)
                dgv1.Refresh()
                Me.Refresh()
                chkBxAutoStuff.Checked = True
                Rdb4.Checked = True
                Call chkBxAutoStuff_MouseClick(sender, e)
                dgv1.Refresh()
                Me.Refresh()

                Call generateTable()
                'Call StopStep()

                If frmTrial_exitFlg Then
                    GoTo JPL
                End If

                'GoTo jpl

                chkBxAutoStuff.Checked = False
                chkBxAutoStuffRC.Checked = False
                Call chkBxAutoStuff_MouseClick(sender, e)
                dgv1.Refresh()
                Me.Refresh()
                chkBxAutoStuff.Checked = True
                Rdb5.Checked = True
                Call chkBxAutoStuff_MouseClick(sender, e)
                dgv1.Refresh()
                Me.Refresh()

                Call generateTable()
                'Call StopStep()

                If frmTrial_exitFlg Then
                    GoTo JPL
                End If

                chkBxAutoStuff.Checked = False
                chkBxAutoStuffRC.Checked = True
                Call chkBxAutoStuff_MouseClick(sender, e)
                dgv1.Refresh()
                Me.Refresh()
                chkBxAutoStuff.Checked = True
                Rdb5.Checked = True
                Call chkBxAutoStuff_MouseClick(sender, e)
                dgv1.Refresh()
                Me.Refresh()

                Call generateTable()
                'Call StopStep()

                If frmTrial_exitFlg Then
                    GoTo JPL
                End If

                chkBxAutoStuff.Checked = False
                chkBxAutoStuffRC.Checked = False
                Call chkBxAutoStuff_MouseClick(sender, e)
                dgv1.Refresh()
                Me.Refresh()
                chkBxAutoStuff.Checked = True
                Rdb6.Checked = True
                Call chkBxAutoStuff_MouseClick(sender, e)
                dgv1.Refresh()
                Me.Refresh()

                Call generateTable()
                'Call StopStep()

                If frmTrial_exitFlg Then
                    GoTo JPL
                End If

                chkBxAutoStuff.Checked = False
                chkBxAutoStuffRC.Checked = True
                Call chkBxAutoStuff_MouseClick(sender, e)
                dgv1.Refresh()
                Me.Refresh()
                chkBxAutoStuff.Checked = True
                Rdb6.Checked = True
                Call chkBxAutoStuff_MouseClick(sender, e)
                dgv1.Refresh()
                Me.Refresh()

                Call generateTable()
                'Call StopStep()

                If frmTrial_exitFlg Then
                    GoTo JPL
                End If

                chkBxAutoStuff.Checked = False
                chkBxAutoStuffRC.Checked = False
                Call chkBxAutoStuff_MouseClick(sender, e)
                dgv1.Refresh()
                Me.Refresh()
                chkBxAutoStuff.Checked = True
                Rdb7.Checked = True
                Call chkBxAutoStuff_MouseClick(sender, e)
                dgv1.Refresh()
                Me.Refresh()

                Call generateTable()
                'Call StopStep()

                If frmTrial_exitFlg Then
                    GoTo JPL
                End If

                chkBxAutoStuff.Checked = False
                chkBxAutoStuffRC.Checked = True
                Call chkBxAutoStuff_MouseClick(sender, e)
                dgv1.Refresh()
                Me.Refresh()
                chkBxAutoStuff.Checked = True
                Rdb7.Checked = True
                Call chkBxAutoStuff_MouseClick(sender, e)
                dgv1.Refresh()
                Me.Refresh()

                Call generateTable()
                'Call StopStep()

                If frmTrial_exitFlg Then
                    GoTo JPL
                End If

                chkBxAutoStuff.Checked = False
                chkBxAutoStuffRC.Checked = False
                Call chkBxAutoStuff_MouseClick(sender, e)
                dgv1.Refresh()
                Me.Refresh()
                chkBxAutoStuff.Checked = True
                Rdb8.Checked = True
                Call chkBxAutoStuff_MouseClick(sender, e)
                dgv1.Refresh()
                Me.Refresh()

                Call generateTable()
                'Call StopStep()

                If frmTrial_exitFlg Then
                    GoTo JPL
                End If

                chkBxAutoStuff.Checked = False
                chkBxAutoStuffRC.Checked = True
                Call chkBxAutoStuff_MouseClick(sender, e)
                dgv1.Refresh()
                Me.Refresh()
                chkBxAutoStuff.Checked = True
                Rdb8.Checked = True
                Call chkBxAutoStuff_MouseClick(sender, e)
                dgv1.Refresh()
                Me.Refresh()

                Call generateTable()
                'Call StopStep()

                If frmTrial_exitFlg Then
                    GoTo JPL
                End If

                chkBxAutoStuff.Checked = False
                chkBxAutoStuffRC.Checked = False
                Call chkBxAutoStuff_MouseClick(sender, e)
                dgv1.Refresh()
                Me.Refresh()
                chkBxAutoStuff.Checked = True
                Rdb9.Checked = True
                Call chkBxAutoStuff_MouseClick(sender, e)
                dgv1.Refresh()
                Me.Refresh()

                Call generateTable()
                'Call StopStep()

                If frmTrial_exitFlg Then
                    GoTo JPL
                End If

                chkBxAutoStuff.Checked = False
                chkBxAutoStuffRC.Checked = True
                Call chkBxAutoStuff_MouseClick(sender, e)
                dgv1.Refresh()
                Me.Refresh()
                chkBxAutoStuff.Checked = True
                Rdb9.Checked = True
                Call chkBxAutoStuff_MouseClick(sender, e)
                dgv1.Refresh()
                Me.Refresh()

                Call generateTable()
                'Call StopStep()

                If frmTrial_exitFlg Then
                    GoTo JPL
                End If

                chkBxAutoStuff.Checked = False
                chkBxAutoStuffRC.Checked = False
                Call chkBxAutoStuff_MouseClick(sender, e)
                dgv1.Refresh()
                Me.Refresh()
                chkBxAutoStuff.Checked = True
                Rdb10.Checked = True
                Call chkBxAutoStuff_MouseClick(sender, e)
                dgv1.Refresh()
                Me.Refresh()

                Call generateTable()
                'Call StopStep()

                If frmTrial_exitFlg Then
                    GoTo JPL
                End If

                chkBxAutoStuff.Checked = False
                chkBxAutoStuffRC.Checked = True
                Call chkBxAutoStuff_MouseClick(sender, e)
                dgv1.Refresh()
                Me.Refresh()
                chkBxAutoStuff.Checked = True
                Rdb10.Checked = True
                Call chkBxAutoStuff_MouseClick(sender, e)
                dgv1.Refresh()
                Me.Refresh()

                Call generateTable()
                'Call StopStep()

                If frmTrial_exitFlg Then
                    GoTo JPL
                End If

                chkBxAutoStuff.Checked = False
                chkBxAutoStuffRC.Checked = False
                Call chkBxAutoStuff_MouseClick(sender, e)
                dgv1.Refresh()
                Me.Refresh()
                chkBxAutoStuff.Checked = True
                Rdb11.Checked = True
                Call chkBxAutoStuff_MouseClick(sender, e)
                dgv1.Refresh()
                Me.Refresh()

                Call generateTable()
                'Call StopStep()

                If frmTrial_exitFlg Then
                    GoTo JPL
                End If

                chkBxAutoStuff.Checked = False
                chkBxAutoStuffRC.Checked = True
                Call chkBxAutoStuff_MouseClick(sender, e)
                dgv1.Refresh()
                Me.Refresh()
                chkBxAutoStuff.Checked = True
                Rdb11.Checked = True
                Call chkBxAutoStuff_MouseClick(sender, e)
                dgv1.Refresh()
                Me.Refresh()

                Call generateTable()
                'Call StopStep()

                If frmTrial_exitFlg Then
                    GoTo JPL
                End If

                chkBxAutoStuff.Checked = False
                chkBxAutoStuffRC.Checked = False
                Call chkBxAutoStuff_MouseClick(sender, e)
                dgv1.Refresh()
                Me.Refresh()
                chkBxAutoStuff.Checked = True
                Rdb12.Checked = True
                Call chkBxAutoStuff_MouseClick(sender, e)
                dgv1.Refresh()
                Me.Refresh()

                Call generateTable()
                'Call StopStep()

                If frmTrial_exitFlg Then
                    GoTo JPL
                End If

                chkBxAutoStuff.Checked = False
                chkBxAutoStuffRC.Checked = True
                Call chkBxAutoStuff_MouseClick(sender, e)
                dgv1.Refresh()
                Me.Refresh()
                chkBxAutoStuff.Checked = True
                Rdb12.Checked = True
                Call chkBxAutoStuff_MouseClick(sender, e)
                dgv1.Refresh()
                Me.Refresh()

                Call generateTable()
                'Call StopStep()

                If frmTrial_exitFlg Then
                    GoTo JPL
                End If

                chkBxAutoStuff.Checked = False
                chkBxAutoStuffRC.Checked = False
                Call chkBxAutoStuff_MouseClick(sender, e)
                dgv1.Refresh()
                Me.Refresh()
                chkBxAutoStuff.Checked = True
                Rdb13.Checked = True
                Call chkBxAutoStuff_MouseClick(sender, e)
                dgv1.Refresh()
                Me.Refresh()

                Call generateTable()
                'Call StopStep()

                If frmTrial_exitFlg Then
                    GoTo JPL
                End If

                chkBxAutoStuff.Checked = False
                chkBxAutoStuffRC.Checked = True
                Call chkBxAutoStuff_MouseClick(sender, e)
                dgv1.Refresh()
                Me.Refresh()
                chkBxAutoStuff.Checked = True
                Rdb13.Checked = True
                Call chkBxAutoStuff_MouseClick(sender, e)
                dgv1.Refresh()
                Me.Refresh()

                Call generateTable()
                'Call StopStep()

                If frmTrial_exitFlg Then
                    GoTo JPL
                End If

                chkBxAutoStuff.Checked = False
                chkBxAutoStuffRC.Checked = False
                Call chkBxAutoStuff_MouseClick(sender, e)
                dgv1.Refresh()
                Me.Refresh()
                chkBxAutoStuff.Checked = True
                Rdb14.Checked = True
                Call chkBxAutoStuff_MouseClick(sender, e)
                dgv1.Refresh()
                Me.Refresh()

                Call generateTable()
                'Call StopStep()

                If frmTrial_exitFlg Then
                    GoTo JPL
                End If

                chkBxAutoStuff.Checked = False
                chkBxAutoStuffRC.Checked = True
                Call chkBxAutoStuff_MouseClick(sender, e)
                dgv1.Refresh()
                Me.Refresh()
                chkBxAutoStuff.Checked = True
                Rdb14.Checked = True
                Call chkBxAutoStuff_MouseClick(sender, e)
                dgv1.Refresh()
                Me.Refresh()

                Call generateTable()
                'Call StopStep()

                If frmTrial_exitFlg Then
                    GoTo JPL
                End If

                chkBxAutoStuff.Checked = False
                chkBxAutoStuffRC.Checked = False
                Call chkBxAutoStuff_MouseClick(sender, e)
                dgv1.Refresh()
                Me.Refresh()
                chkBxAutoStuff.Checked = True
                Rdb15.Checked = True
                Call chkBxAutoStuff_MouseClick(sender, e)
                dgv1.Refresh()
                Me.Refresh()

                Call generateTable()
                'Call StopStep()

                If frmTrial_exitFlg Then
                    GoTo JPL
                End If

                chkBxAutoStuff.Checked = False
                chkBxAutoStuffRC.Checked = True
                Call chkBxAutoStuff_MouseClick(sender, e)
                dgv1.Refresh()
                Me.Refresh()
                chkBxAutoStuff.Checked = True
                Rdb15.Checked = True
                Call chkBxAutoStuff_MouseClick(sender, e)
                dgv1.Refresh()
                Me.Refresh()

                Call generateTable()
                'Call StopStep()

                If frmTrial_exitFlg Then
                    GoTo JPL
                End If

                chkBxAutoStuff.Checked = False
                chkBxAutoStuffRC.Checked = False
                Call chkBxAutoStuff_MouseClick(sender, e)
                dgv1.Refresh()
                Me.Refresh()
                chkBxAutoStuff.Checked = True
                Rdb16.Checked = True
                Call chkBxAutoStuff_MouseClick(sender, e)
                dgv1.Refresh()
                Me.Refresh()

                Call generateTable()
                'Call StopStep()

                If frmTrial_exitFlg Then
                    GoTo JPL
                End If

                chkBxAutoStuff.Checked = False
                chkBxAutoStuffRC.Checked = True
                Call chkBxAutoStuff_MouseClick(sender, e)
                dgv1.Refresh()
                Me.Refresh()
                chkBxAutoStuff.Checked = True
                Rdb16.Checked = True
                Call chkBxAutoStuff_MouseClick(sender, e)
                dgv1.Refresh()
                Me.Refresh()

                Call generateTable()
                'Call StopStep()

                If frmTrial_exitFlg Then
                    GoTo JPL
                End If

JPL:
                chkBxAutoStuff.Checked = False
                chkBxAutoStuffRC.Checked = False
                Call chkBxAutoStuff_MouseClick(sender, e)
                dgv1.Refresh()
                Me.Refresh()
                Cnt = 0

                btnTrlO.BackColor = Color.MediumTurquoise
                pilotFlg = False
                Rdb1.Checked = False
                Rdb2.Checked = False
                Rdb3.Checked = False
                Rdb4.Checked = False
                Rdb5.Checked = False
                Rdb6.Checked = False
                Rdb7.Checked = False
                Rdb8.Checked = False
                Rdb9.Checked = False
                Rdb10.Checked = False
                Rdb11.Checked = False
                Rdb12.Checked = False
                Rdb13.Checked = False
                Rdb14.Checked = False
                Rdb15.Checked = False
                Rdb16.Checked = False

                TrlOFlg = False
                frmTrial.DgvTrial.Visible = True

            End If

            If frmTrial_exitFlg Then
                Exit Sub
            End If

            Call OptTrial(sender, e)

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in TrlO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            frmTrial.chkbxStepTrials.Enabled = True
        End Try

    End Sub

    Private Sub dgv1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv1.LostFocus

        Try
            If dgv1.CurrentCell.ColumnIndex = 12 Or dgv1.CurrentCell.ColumnIndex = 14 Then
                dgv1.StandardTab = False
                Exit Sub
            ElseIf dgv1.CurrentCell.ColumnIndex = 11 Then
                dgv1.StandardTab = True
                dgv1.Columns(1).Selected = True
                dgv1(1, dgv1.RowCount - 2).Selected = True
            End If

            '    dgv1.StandardTab = True
            '    dgv1.Columns(11).Selected = True
            '    dgv1(11, dgv1.RowCount - 2).Selected = True
        Catch
        End Try

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub pnlPbinfo_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlPbinfo.MouseDown

        Try
            xLocUc = pnlPbinfo.Location.X
            yLocUc = pnlPbinfo.Location.Y
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in pnlPbinfo_MouseDown", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub pnlPbinfo_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlPbinfo.MouseUp

        Try

            Dim x As Integer = e.X
            Dim y As Integer = e.Y

            Dim pnlPbMov As System.Drawing.Point = New System.Drawing.Point((xLocUc + x), (yLocUc + y))

            pnlPbinfo.Location = pnlPbMov

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in pnlPbinfo_MouseUp", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnStepTrials_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStepTrials.Click

        frmStep.Show()
        btnStepTrials.BackColor = Color.HotPink
        dgv1.CurrentCell = dgv1(12, dgv1.RowCount - 2)
        ShowButton_MouseClick(sender, e)

    End Sub

    Private Sub NumUdDimnsSizeRatio_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NumUdDimnsSizeRatio.Click

        Try
            NumUdDimnsSizeRatio.Cursor = Cursors.Hand

            szFlg = True

            Dim sfSZ As Double = NumUdDimnsSizeRatio.Value

            ToolStripStatuslblSizeRatio.Text = ":: The size ratio changed and its value is " & sfSZ & "."

            If sfSZ > 0 Then
                szFact = NumUdDimnsSizeRatio.Value * NumUdDimnsSizeRatio.Value
            ElseIf sfSZ < 0 Then
                szFact = 1 / -NumUdDimnsSizeRatio.Value
            Else
                szFlg = False
            End If

        Catch Er As Exception
            MessageBox.Show("The size factor is not manipulated in correct way.")
        Finally
            Me.Refresh()
        End Try

    End Sub

    Private Sub cmdPlan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPlan.Click

        Dim sn As Int16, i As Int16, j As Int16, itmnm As String
        Dim ccell As DataGridViewCell = dgv1.CurrentCell
        Dim bkclr As System.Drawing.Color
        Dim Bo As Int16 = 0

        Try
            btnPilot.Enabled = False
            chkBxAutoStuff.Enabled = False

            Me.pbCSP1.ForeColor = Color.HotPink
            System.Windows.Forms.Application.DoEvents()
            Call TransactionMenu_Resize(sender, e)
            dgv1.SuspendLayout()
            showbutton1.Visible = False

            For i = 0 To dgv1.RowCount - 2

                sn = dgv1(0, i).Value
                itmnm = dgv1(1, i).Value

                bkclr = dgv1.Rows(i).HeaderCell.Style.BackColor

                If bkclr.Name = "0" Then

                    Dim colval As Short = Val(dgv1(0, i).Value)

                    If colval > 7 Then colval = colval - 7

                    Select Case colval
                        Case 1
                            bkclr = Color.Red
                        Case 2
                            bkclr = Color.Green
                        Case 3
                            bkclr = Color.Blue
                        Case 4
                            bkclr = Color.Magenta
                        Case 5
                            bkclr = Color.Cyan
                        Case 6
                            bkclr = Color.Yellow
                        Case 7
                            bkclr = Color.White
                    End Select

                    dgv1.Rows(i).HeaderCell.Style.BackColor = bkclr

                End If

                For j = i + 1 To dgv1.RowCount - 2
                    If dgv1(1, j).Value = itmnm Then
                        dgv1(0, j).Value = sn
                        dgv1.Rows(j).HeaderCell.Style.BackColor = bkclr
                    End If
                Next
            Next
            Try
                dgv1.CurrentCell = ccell
            Catch
            End Try

            If chkBxAutoStuff.Checked = True Then
                For i = 0 To Dgv1Dup.RowCount - 2
                    sn = Dgv1Dup(0, i).Value
                    itmnm = Dgv1Dup(1, i).Value

                    bkclr = Dgv1Dup.Rows(i).HeaderCell.Style.BackColor

                    If bkclr.Name = "0" Then

                        Dim colval As Short = Val(Dgv1Dup(0, i).Value)     'Val(dgv1(0, 1).Value)

                        If colval > 7 Then colval = colval - 7 'If colval > 6 Then colval = colval - 6

                        Select Case colval              'Val(dgv1(0, i).Value)
                            Case 1
                                bkclr = Color.Red
                            Case 2
                                bkclr = Color.Green
                            Case 3
                                bkclr = Color.Blue
                            Case 4
                                bkclr = Color.Magenta
                            Case 5
                                bkclr = Color.Cyan
                            Case 6
                                bkclr = Color.Yellow
                            Case 7
                                bkclr = Color.White
                        End Select

                        Dgv1Dup.Rows(i).HeaderCell.Style.BackColor = bkclr

                    End If

                    For j = i + 1 To Dgv1Dup.RowCount - 2
                        If Dgv1Dup(1, j).Value = itmnm Then
                            Dgv1Dup(0, j).Value = sn
                            Dgv1Dup.Rows(j).HeaderCell.Style.BackColor = bkclr
                        End If
                    Next
                Next

            End If

            ShowStuff.ShowStuffs(Me)
Bindone:
            GC.Collect()

            Dim colqty, colstuff, colbal As Int16

            For i = 0 To dgv1.Columns.Count - 1
                If dgv1.Columns(i).HeaderText.ToLower = "quantity" Then colqty = i
                If dgv1.Columns(i).HeaderText.ToLower = "stuffqty" Then colstuff = i
                If dgv1.Columns(i).HeaderText.ToLower = "balqty" Then colbal = i
            Next

            Try
                Dim ocol As DataGridViewColumn = dgv1.Columns(0)
                For i = 0 To dgv1.RowCount - 2
                    dgv1(0, i).Value = CInt(dgv1(0, i).Value)
                Next

                dgv1.Sort(ocol, 0)
            Catch
            End Try

            i = 0
            Dim col0, col10, col13, col14 As Int16
            Dim xcol0, xcol10, xcol13, xcol14 As Int16

            For i = 0 To dgv1.RowCount - 2
                col0 = dgv1(0, i).Value
                xcol0 = dgv1(0, i + 1).Value
                If col0 = xcol0 Then
                    col10 = Val(dgv1(colqty, i).Value)
                    col13 = Val(dgv1(colstuff, i).Value)
                    col14 = Val(dgv1(colbal, i).Value)
                    xcol10 = Val(dgv1(colqty, i + 1).Value)
                    xcol13 = Val(dgv1(colstuff, i + 1).Value)

                    xcol14 = Val(dgv1(colbal, i + 1).Value)
                    dgv1(colqty, i).Value = col10 + xcol10
                    dgv1(colstuff, i).Value = col13 + xcol13
                    dgv1(colbal, i).Value = col14 + xcol14
                    dgv1(colqty, i + 1).Value = 0
                    dgv1(colstuff, i + 1).Value = 0
                    dgv1(colbal, i + 1).Value = 0
                    dgv1(colqty - 1, i).Value = 0
                End If

            Next

            i = 0
            j = dgv1.RowCount - 2

            Try
                Do While i <= j
                    If dgv1(colqty, i).Value = 0 Then
                        dgv1.Rows.RemoveAt(i)
                        j -= 1
                    Else
                        i += 1
                    End If
                Loop
            Catch
            End Try

            Try
                dgv1.CurrentCell = dgv1(ccell.ColumnIndex, dgv1.RowCount - 2)
            Catch
                Exit Sub
            End Try

            If chkBxAutoStuffRC.Checked = True Then
                Bo += 1
                If Bo > 2 Then
                    GoTo nextp
                End If
                GoTo Bindone
            End If
nextp:
            ShowButton.Visible = False
            showbutton1.Visible = False
            dgv1.ResumeLayout()
            dgv1.ScrollBars = ScrollBars.Both

            If chkBxAutoStuff.Checked = True Then
                Call DuplDgvCl()
            End If

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in Show activity", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            MessageBox.Show("Close application due to fatal error", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Application.Exit()
        Finally
            'Call OLEDBCompactDb()
        End Try

    End Sub

End Class
