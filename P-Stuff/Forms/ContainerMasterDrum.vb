
'Program Name: -    ContainerMasterDrum.vb
'Programmer Name: - Satwadhir B. Pawar Mob No. :- 9323974665
'Company Name:-     Hazel Infotech LTD. Mumbai
'Project Name: -    P-Stuff Plus (Container Stuffing)
'Date: -            23 Dec 2K8 5.07 PM (Modified Time)

'Tips: - The code is debugging at that particular dimensions, quantity and sequence.
'        you are decide it the logic happen is correct to that way or its are some 
'        different way the understanding to at your best level is the correct logic 
'        of this particular code block.

'Description: - Container has different types and sizes, so entering the particular usage 
'               container, use the form according to the container length width height 
'               inserting to store the specific container for next activity.

#Region " Importing Object "

Imports SDOleDb = System.Data.OleDb

#End Region

Public NotInheritable Class ContainerMasterDrum
    Inherits System.Windows.Forms.Form

#Region " Class Declaration "

    Private Ds As New DataSet
    Private IntRow As Integer
    Dim DA As New SDOleDb.OleDbDataAdapter

    Public TotalLengthsic As Single
    Public TotalWidthic As Single

    Dim DStr As String
    Dim DFlag As Boolean

#End Region

#Region " Routine Definitions "

    Private Sub ContainerMasterDrum_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Close()
    End Sub

    Private Sub ContainerMasterDrum_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try

            DisplayActivity.Close()
            'btnDrumtype.Enabled = False

            Me.Top = 65 : Me.Left = 130

            DFlag = False
            If connDrums.State = ConnectionState.Closed Then
                connDrums.Open()
            End If

            FillDataSet()

            ContainerDetails.Enabled = False

            Label1.Visible = False
            txtcontno.Visible = False
            cmdUpdate.Enabled = False
            cmdRef.Enabled = False

            txtcontname.Focus()

            If Ds.Tables!Text.Rows.Count = 0 Then
                Call DNoRecorddisplay()
                Call DTxtClear()
                Exit Sub
            ElseIf Ds.Tables!Text.Rows.Count - 1 >= 0 Then
                IntRow = Ds.Tables!Text.Rows.Count - 1
                Call DTxtBind()
                Call DLoadenable()
            End If
            cmdAdd.TabIndex = 0
            cmdLast_Click(Nothing, Nothing)

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in ContainerMasterDrum_Load", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub DLoadenable()

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

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click

        DTxtClear()
        DAddEnable()
        DStr = "Add"
        ContainerDetails.Enabled = True
        txtcontname.Focus()
        DFlag = True

    End Sub

    Private Sub DAddEnable()

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

        DStr = "Edit"
        DEditenable()
        ContainerDetails.Enabled = True
        txtcontname.Focus()
        DFlag = True

    End Sub

    Private Sub DEditenable()

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

        Try

            Dim cmD As New SDOleDb.OleDbCommand  'delete

            If MsgBox("Are you sure you want to delete this Record?", MsgBoxStyle.YesNo + vbCritical, "Container Master") = MsgBoxResult.Yes Then
                Dim strId As String

                strId = FCount("Select Count(ContainerName) as ContainerName1  from NInwardDetail where ContainerName='" & Trim(txtcontname.Text) & "'")

                If strId = 0 Then
                    cmD = New SDOleDb.OleDbCommand("Delete from ContainerMaster where ContainerNo=" & Val(txtcontno.Text), connDrums)
                    If connDrums.State = ConnectionState.Closed Then connDrums.Open()
                    Try
                        cmD.ExecuteNonQuery()

                        FillDataSet()

                        If Ds.Tables!Text.Rows.Count = 0 Then
                            Call DTxtClear()
                            Call DNoRecorddisplay()

                            cmdAdd.Focus()
                            Exit Sub
                        Else
                            IntRow = Ds.Tables!Text.Rows.Count - 1
                            Call DTxtClear()
                            Call DTxtBind()
                        End If

                    Catch Ex As Exception

                        MsgBox(Ex.Message, MsgBoxStyle.Critical, "Error in :: cmdDel_Click Procedure")

                    End Try
                Else
                    MsgBox("Cannot delete the record. It is being used!", MsgBoxStyle.Critical, "Container Master")
                    Exit Sub
                End If
            End If

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in cmdDel", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub DTxtBind()

        Try
            txtcontno.Text = IIf(IsDBNull(Ds.Tables!Text.Rows(IntRow).Item("ContainerNo")), "", Ds.Tables!Text.Rows(IntRow).Item("ContainerNo"))
            txtcontname.Text = IIf(IsDBNull(Ds.Tables!Text.Rows(IntRow).Item("ContainerName")), "", Ds.Tables!Text.Rows(IntRow).Item("ContainerName"))
            If Val(Ds.Tables!Text.Rows(IntRow).Item("LengthF")) = 0 Then
                txtlengthf.Text = ""
            Else
                txtlengthf.Text = Val(Ds.Tables!Text.Rows(IntRow).Item("LengthF"))
            End If

            If Val(Ds.Tables!Text.Rows(IntRow).Item("WidthF")) = 0 Then
                txtwidthf.Text = ""
            Else
                txtwidthf.Text = Ds.Tables!Text.Rows(IntRow).Item("WidthF")
            End If

            If Val(Ds.Tables!Text.Rows(IntRow).Item("HeightF")) = 0 Then
                txtheightf.Text = ""
            Else
                txtheightf.Text = Ds.Tables!Text.Rows(IntRow).Item("HeightF")
            End If

            If Val(Ds.Tables!Text.Rows(IntRow).Item("LengthI")) = 0 Then
                txtlengthi.Text = ""
            Else
                txtlengthi.Text = Ds.Tables!Text.Rows(IntRow).Item("LengthI")
            End If

            If Val(Ds.Tables!Text.Rows(IntRow).Item("WidthI")) = 0 Then
                txtwidthi.Text = ""
            Else
                txtwidthi.Text = Ds.Tables!Text.Rows(IntRow).Item("WidthI")
            End If

            If Val(Ds.Tables!Text.Rows(IntRow).Item("HeightI")) = 0 Then
                txtheighti.Text = ""
            Else
                txtheighti.Text = Ds.Tables!Text.Rows(IntRow).Item("HeightI")
            End If

            If Val(Ds.Tables!Text.Rows(IntRow).Item("LengthC")) = 0 Then
                txtlengthc.Text = ""
            Else
                txtlengthc.Text = Ds.Tables!Text.Rows(IntRow).Item("LengthC")
            End If

            If Val(Ds.Tables!Text.Rows(IntRow).Item("WidthC")) = 0 Then
                txtwidthc.Text = ""
            Else
                txtwidthc.Text = Ds.Tables!Text.Rows(IntRow).Item("WidthC")
            End If

            If Val(Ds.Tables!Text.Rows(IntRow).Item("HeightC")) = 0 Then
                txtheightc.Text = ""
            Else
                txtheightc.Text = Ds.Tables!Text.Rows(IntRow).Item("HeightC")
            End If

            If Val(Ds.Tables!Text.Rows(IntRow).Item("LengthM")) = 0 Then
                txtlengthm.Text = ""
            Else
                txtlengthm.Text = (Ds.Tables!Text.Rows(IntRow).Item("LengthM"))
            End If

            If Val(Ds.Tables!Text.Rows(IntRow).Item("WidthM")) = 0 Then
                txtwidthm.Text = ""
            Else
                txtwidthm.Text = Ds.Tables!Text.Rows(IntRow).Item("WidthM")
            End If

            If Val(Ds.Tables!Text.Rows(IntRow).Item("HeightM")) = 0 Then
                txtheightm.Text = ""
            Else
                txtheightm.Text = Ds.Tables!Text.Rows(IntRow).Item("HeightM")
            End If

            txtloadkg.Text = FormatNumber(IIf(IsDBNull(Ds.Tables!Text.Rows(IntRow).Item("PayLoad")), "", Ds.Tables!Text.Rows(IntRow).Item("PayLoad")), 2, , , False)
            If Val(txtloadkg.Text) = 0 Then txtloadkg.Text = ""
            txtloadlbs.Text = FormatNumber(IIf(IsDBNull(Ds.Tables!Text.Rows(IntRow).Item("PayLoad") * 2.2045), "", Ds.Tables!Text.Rows(IntRow).Item("PayLoad") * 2.2045), 2, , , False)
            If Val(txtloadlbs.Text) = 0 Then txtloadlbs.Text = ""
            txttotalsize.Text = FormatNumber(IIf(IsDBNull(Ds.Tables!Text.Rows(IntRow).Item("TotalSize")), "", Ds.Tables!Text.Rows(IntRow).Item("TotalSize")), 4, , , False)
            If Val(txttotalsize.Text) = 0 Then txttotalsize.Text = ""
            txttotalsizef.Text = FormatNumber(IIf(IsDBNull(Ds.Tables!Text.Rows(IntRow).Item("TotalSizeF")), "", Ds.Tables!Text.Rows(IntRow).Item("TotalSizeF")), 4, , , False)
            If Val(txttotalsizef.Text) = 0 Then txttotalsizef.Text = ""

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in DTxtBind", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub DNoRecorddisplay()

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
        ContainerDetails.Enabled = False

    End Sub

    Public Sub DTxtClear()

        txtcontno.Text = 0
        txtcontname.Text = ""
        txtloadkg.Text = ""
        txtloadlbs.Text = ""
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

    End Sub

    Private Sub FillDataSet()

        Dim strSQL As String
        Try
            strSQL = "select * from ContainerMaster"
            Dim da As New SDOleDb.OleDbDataAdapter(strSQL, connDrums)
            If Ds.Tables.CanRemove(Ds.Tables("Text")) Then
                Ds.Tables("Text").Rows.Clear()
                Ds.Tables("Text").Columns.Clear()
            End If
            da.Fill(Ds, "Text")
            da = Nothing

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in FillDataSet", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFirst.Click

        Try

            If Ds.Tables!Text.Rows.Count - 1 >= 0 Then
                IntRow = 0
                DTxtBind()
                cmdEdit.Enabled = True
                cmdDel.Enabled = True

            End If

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in the cmdFirst_Click ", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrev.Click

        Try
            If IntRow > 0 Then
                IntRow = IntRow - 1
                DTxtBind()
            End If
            cmdEdit.Enabled = True
            cmdDel.Enabled = True

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in the cmdPrev_Click ", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNext.Click

        Try
            If IntRow < Ds.Tables!Text.Rows.Count - 1 Then
                IntRow = IntRow + 1
                DTxtBind()
            End If
            cmdEdit.Enabled = True
            cmdDel.Enabled = True
        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in the cmdNext_Click ", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLast.Click

        Try
            If Ds.Tables!Text.Rows.Count - 1 >= 0 Then
                IntRow = Ds.Tables!Text.Rows.Count - 1
                Call DTxtBind()
                cmdEdit.Enabled = True
                cmdDel.Enabled = True
            End If
        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in the cmdLast_Click ", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFind.Click

        Try
            DT = "ContainerMaster"
            FindStr = "Select ContainerNo,ContainerName,LengthF,WidthF,HeightF,LengthI,WidthI,HeightI,LengthC,WidthC,HeightC,LengthM,WidthM,HeightM,PayLoad,TotalSize,TotalSizeF FROM ContainerMaster ORDER BY ContainerName"
            title = "Container"
            frmSearch.ShowDialog()
            Me.ActivateMdiChild(frmSearch)
            frmSearch.Txtsearch.Focus()
        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in the cmdFind_Click ", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdHelp.Click

        Try
            Process.Start(CurDir() & "\HelpContainerStuff\Container Master.chm")
        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in the cmdHelp_Click ", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click

        Dim Comm As SDOleDb.OleDbCommand

        Try
            If DFlag = True Then
                If MsgBox("Do you want to save this record?", MsgBoxStyle.YesNo + vbExclamation, "Container Master") = MsgBoxResult.Yes Then
                    If Trim(txtcontname.Text) = "" Then
                        MsgBox("Please enter Container Name.", MsgBoxStyle.Exclamation)
                        DAddEnable()
                        txtcontname.Focus()
                        Exit Sub
                    End If

                    Dim strSQL As String

                    '----------------

                    If DStr = "Add" Then
                        '-------Check Duplicate Record
                        Dim strId As String
                        strId = DFCount("Select Count(ContainerName) as ContainerName1  from ContainerMaster where ContainerName='" & Trim(txtcontname.Text) & "'")
                        If strId <> 0 Then
                            MsgBox("Dublicate Container name should not allow", MsgBoxStyle.Exclamation, "Container Master")
                            txtcontname.Focus()
                            Exit Sub
                        End If

                        '--------------------

                        Dim Str1 As String

                        Str1 = "Select Max(ContainerNo) As CId from ContainerMaster"
                        txtcontno.Text = DGenId(Str1)
                        strSQL = "Insert into ContainerMaster(ContainerNo,ContainerName,LengthF,WidthF,HeightF,LengthI,WidthI,HeightI,"
                        strSQL = strSQL & "LengthC,WidthC,HeightC,LengthM,WidthM,HeightM,Payload,TotalSize,TotalSizeF)"
                        strSQL = strSQL & "values(" & Val(txtcontno.Text) & ", '" & Replace(Trim(txtcontname.Text), "'", "`") & "', " & Val(txtlengthf.Text) & ", " & Val(txtwidthf.Text) & ","
                        strSQL = strSQL & " " & Val(txtheightf.Text) & ", " & Val(txtlengthi.Text) & ", " & Val(txtwidthi.Text) & ", " & Val(txtheighti.Text) & ", "
                        strSQL = strSQL & " " & Val(txtlengthc.Text) & ", " & Val(txtwidthc.Text) & "," & Val(txtheightc.Text) & ", " & Val(txtlengthm.Text) & ", "
                        strSQL = strSQL & " " & Val(txtwidthm.Text) & ", " & Val(txtheightm.Text) & ", " & Val(txtloadkg.Text) & ", " & Val(txttotalsize.Text) & ", "
                        strSQL = strSQL & " " & Val(txttotalsizef.Text) & ") "

                        Comm = New SDOleDb.OleDbCommand(strSQL, connDrums)

                        Try
                            If connDrums.State = ConnectionState.Closed Then connDrums.Open()
                            Comm.ExecuteNonQuery()
                            FillDataSet()
                            IntRow = Ds.Tables!Text.Rows.Count - 1
                            DTxtBind()
                            connDrums.Close()
                            cmdAdd.Focus()
                            DFlag = False
                            Call DSaveEnable()
                            Close()
                        Catch ex As Exception
                            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error in procedure cmdExit_Click")
                            Exit Sub
                        End Try
                    ElseIf DStr = "Edit" Then
                        strSQL = "Update ContainerMaster set ContainerName='" & Replace(Trim(txtcontname.Text), "'", "`") & "', LengthF=" & Val(txtlengthf.Text) & ","
                        strSQL = strSQL & " WidthF=" & Val(txtwidthf.Text) & ", HeightF=" & Val(txtheightf.Text) & ", LengthI=" & Val(txtlengthi.Text) & ","
                        strSQL = strSQL & " WidthI=" & Val(txtwidthi.Text) & ", HeightI=" & Val(txtheighti.Text) & ", LengthC=" & Val(txtlengthc.Text) & ","
                        strSQL = strSQL & " WidthC=" & Val(txtwidthc.Text) & ", HeightC=" & Val(txtheightc.Text) & ", LengthM=" & Val(txtlengthm.Text) & ","
                        strSQL = strSQL & " WidthM=" & Val(txtwidthm.Text) & ", HeightM=" & Val(txtheightm.Text) & ", Payload=" & Val(txtloadkg.Text) & ","
                        strSQL = strSQL & " TotalSize=" & Val(txttotalsize.Text) & ",TotalSizeF=" & Val(txttotalsizef.Text) & " where ContainerNo =" & Val(txtcontno.Text) & ""
                        Comm = New SDOleDb.OleDbCommand(strSQL, connDrums)

                        Try
                            If connDrums.State = ConnectionState.Closed Then connDrums.Open()
                            Comm.ExecuteNonQuery()
                            FillDataSet()
                            DTxtBind()
                            connDrums.Close()
                            cmdAdd.Focus()
                            DFlag = False
                            Call DSaveEnable()
                            Close()
                        Catch Ex As Exception
                            MsgBox(Ex.Message, MsgBoxStyle.Critical, "Error in procedure cmdExit_Click")
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
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in the cmdExit_Click ", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub DSaveEnable()

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
        ContainerDetails.Enabled = False

    End Sub

    'Private Sub ContainerMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
    '    If e.KeyCode = Keys.Escape Then Close()
    'End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click

        Dim strSQL As String
        Dim Comm As SDOleDb.OleDbCommand

        Try
            If Trim(txtcontname.Text) = "" Then
                MsgBox("Please enter Container Name.", MsgBoxStyle.Exclamation, "Container Master")
                DAddEnable()
                txtcontname.Focus()
                Exit Sub
            End If

            If DStr = "Add" Then
                '-------Check Duplicate Record
                Dim strId As String
                strId = DFCount("Select Count(ContainerName) as ContainerName1  from ContainerMaster where ContainerName='" & Trim(txtcontname.Text) & "'")
                If strId <> 0 Then
                    MsgBox("Dublicate Container name should not allow", MsgBoxStyle.Exclamation, "Container Master")
                    txtcontname.Focus()
                    Exit Sub
                End If
                '--------------------
                Dim Str1 As String
                Str1 = "Select Max(ContainerNo) As CId from ContainerMaster"
                txtcontno.Text = DGenId(Str1)
                strSQL = "Insert into ContainerMaster(ContainerNo,ContainerName,LengthF,WidthF,HeightF,LengthI,WidthI,HeightI,"
                strSQL = strSQL & "LengthC,WidthC,HeightC,LengthM,WidthM,HeightM,Payload,TotalSize,TotalSizeF)"
                strSQL = strSQL & "values(" & Val(txtcontno.Text) & ", '" & Replace(Trim(txtcontname.Text), "'", "`") & "', " & Val(txtlengthf.Text) & ", " & Val(txtwidthf.Text) & ","
                strSQL = strSQL & " " & Val(txtheightf.Text) & ", " & Val(txtlengthi.Text) & ", " & Val(txtwidthi.Text) & ", " & Val(txtheighti.Text) & ", "
                strSQL = strSQL & " " & Val(txtlengthc.Text) & ", " & Val(txtwidthc.Text) & "," & Val(txtheightc.Text) & ", " & Val(txtlengthm.Text) & ", "
                strSQL = strSQL & " " & Val(txtwidthm.Text) & ", " & Val(txtheightm.Text) & ", " & Val(txtloadkg.Text) & ", " & Val(txttotalsize.Text) & ", "
                strSQL = strSQL & " " & Val(txttotalsizef.Text) & ") "

                Comm = New SDOleDb.OleDbCommand(strSQL, connDrums)
                Try
                    If connDrums.State = ConnectionState.Closed Then connDrums.Open()
                    Comm.ExecuteNonQuery()
                    FillDataSet()
                    IntRow = Ds.Tables!Text.Rows.Count - 1
                    DTxtBind()
                    connDrums.Close()
                    DFlag = False

                    Call DSaveEnable()

                    ContainerDetails.Enabled = False
                    cmdAdd.Focus()

                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                    Exit Sub

                End Try

            ElseIf DStr = "Edit" Then
                strSQL = "Update ContainerMaster set ContainerName='" & Replace(Trim(txtcontname.Text), "'", "`") & "', LengthF=" & Val(txtlengthf.Text) & ","
                strSQL = strSQL & " WidthF=" & Val(txtwidthf.Text) & ", HeightF=" & Val(txtheightf.Text) & ", LengthI=" & Val(txtlengthi.Text) & ","
                strSQL = strSQL & " WidthI=" & Val(txtwidthi.Text) & ", HeightI=" & Val(txtheighti.Text) & ", LengthC=" & Val(txtlengthc.Text) & ","
                strSQL = strSQL & " WidthC=" & Val(txtwidthc.Text) & ", HeightC=" & Val(txtheightc.Text) & ", LengthM=" & Val(txtlengthm.Text) & ","
                strSQL = strSQL & " WidthM=" & Val(txtwidthm.Text) & ", HeightM=" & Val(txtheightm.Text) & ", Payload=" & Val(txtloadkg.Text) & ","
                strSQL = strSQL & " TotalSize=" & Val(txttotalsize.Text) & ",TotalSizeF=" & Val(txttotalsizef.Text) & " where ContainerNo =" & Val(txtcontno.Text) & ""

                Comm = New SDOleDb.OleDbCommand(strSQL, connDrums)
                Try
                    If connDrums.State = ConnectionState.Closed Then connDrums.Open()
                    Comm.ExecuteNonQuery()

                    FillDataSet()

                    DTxtBind()
                    connDrums.Close()
                    DFlag = False
                    DSaveEnable()
                    ContainerDetails.Enabled = False
                    cmdAdd.Focus()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                    Exit Sub
                End Try

            End If
        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in the cmdUpdate_Click ", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdRef_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRef.Click

        Dim Comm As New SDOleDb.OleDbCommand        'delete

        Try
            If MsgBox("Are you sure you want to refresh this record?", MsgBoxStyle.YesNo + vbInformation, "Container Master") = MsgBoxResult.Yes Then

                If Ds.Tables!Text.Rows.Count = 0 Then
                    Call DTxtClear()
                    Call DNoRecorddisplay()
                    IntRow = 0
                    DFlag = False
                    cmdAdd.Focus()
                    Exit Sub
                ElseIf IntRow > 0 Or IntRow <= Ds.Tables!Text.Rows.Count - 1 Then
                    DRefEnable()
                    DTxtClear()
                    DTxtBind()
                    DFlag = False
                    cmdAdd.Focus()
                End If
            Else
                txtcontname.Focus()
                Exit Sub
            End If
        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in the cmdRef_Click ", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub DRefEnable()

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
        ContainerDetails.Enabled = False

    End Sub

    Private Sub txtcontno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcontno.GotFocus

        txtcontno.Select(0, 10)

    End Sub

    Private Sub txtcontname_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcontname.GotFocus

        txtcontname.Select(0, 50)

    End Sub

    Private Sub txtloadkg_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtloadkg.GotFocus

        txtloadkg.Select(0, 10)

    End Sub

    Private Sub txtloadkg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtloadkg.KeyDown

        If txtloadkg.Text <> "" And e.KeyCode = Keys.Enter Then
            txtloadlbs.Text = FormatNumber((Val(txtloadkg.Text) * 2.2045), 2, , , False)
            txtlengthf.Focus()
        End If

    End Sub

    Private Sub txtheightm_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtheightm.GotFocus

        txtheightm.Select(0, 10)

    End Sub

    Private Sub txtlengthf_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtlengthf.GotFocus

        txtlengthf.Select(0, 10)

    End Sub

    Private Sub txtwidthf_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtwidthf.GotFocus

        txtwidthf.Select(0, 10)

    End Sub

    Private Sub txtheightf_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtheightf.GotFocus

        txtheightf.Select(0, 10)

    End Sub

    Private Sub txtlengthi_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtlengthi.GotFocus

        txtlengthi.Select(0, 10)

    End Sub

    Private Sub txtwidthi_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtwidthi.GotFocus

        txtwidthi.Select(0, 10)

    End Sub

    Private Sub txtlengthc_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtlengthc.GotFocus

        txtlengthc.Select(0, 10)

    End Sub

    Private Sub txtwidthc_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtwidthc.GotFocus

        txtwidthc.Select(0, 10)

    End Sub

    Private Sub txtheightc_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtheightc.GotFocus

        txtheightc.Select(0, 10)

    End Sub

    Private Sub txtlengthm_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtlengthm.GotFocus

        txtlengthm.Select(0, 10)

    End Sub

    Private Sub txtwidthm_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtwidthm.GotFocus

        txtwidthm.Select(0, 10)

    End Sub

    Private Sub txtheighti_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtheighti.GotFocus

        txtheighti.Select(0, 10)

    End Sub

    Private Sub txtcontname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtcontname.KeyDown

        If e.KeyCode = Keys.Enter Then
            txtloadkg.Focus()
        End If

        'If e.KeyCode = 39 Then txtloadkg.Focus()
    End Sub

    Private Sub txtlengthf_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtlengthf.KeyDown

        If e.KeyCode = Keys.Enter Then txtlengthi.Focus()

    End Sub

    Private Sub txtlengthi_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtlengthi.KeyDown

        If e.KeyCode = Keys.Enter Then txtlengthc.Focus()

    End Sub

    Private Sub txtlengthc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtlengthc.KeyDown

        If e.KeyCode = Keys.Enter Then txtlengthm.Focus()

    End Sub

    Private Sub txtlengthm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtlengthm.KeyDown

        If e.KeyCode = Keys.Enter Then txtwidthf.Focus()

    End Sub

    Private Sub txtwidthf_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtwidthf.KeyDown

        If e.KeyCode = Keys.Enter Then txtwidthi.Focus()

    End Sub

    Private Sub txtwidthi_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtwidthi.KeyDown

        If e.KeyCode = Keys.Enter Then txtwidthc.Focus()

    End Sub

    Private Sub txtwidthc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtwidthc.KeyDown

        If e.KeyCode = Keys.Enter Then txtwidthm.Focus()

    End Sub

    Private Sub txtwidthm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtwidthm.KeyDown

        If e.KeyCode = Keys.Enter Then txtheightf.Focus()

    End Sub

    Private Sub txtheightf_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtheightf.KeyDown

        If e.KeyCode = Keys.Enter Then txtheighti.Focus()

    End Sub

    Private Sub txtheighti_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtheighti.KeyDown

        If e.KeyCode = Keys.Enter Then txtheightc.Focus()

    End Sub

    Private Sub txtheightc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtheightc.KeyDown

        If e.KeyCode = Keys.Enter Then txtheightm.Focus()

    End Sub

    Private Sub txtheightm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtheightm.KeyDown

        If e.KeyCode = Keys.Enter Then cmdUpdate.Focus()

    End Sub

    Public Sub DTotalSize()

        Try
            Dim TotalSizeic As Single

            TotalLengthsic = (Val(txtlengthf.Text) * 12) + (Val(txtlengthi.Text)) + (Val(txtlengthc.Text) * 0.3937) + (Val(txtlengthm.Text) * 0.03937) ' Check Conversion Chart In Report
            TotalLengthsic = FormatNumber(TotalLengthsic, 4, , , False)
            TotalWidthic = (Val(txtwidthf.Text) * 12) + (Val(txtwidthi.Text)) + (Val(txtwidthc.Text) * 0.3937) + (Val(txtwidthm.Text) * 0.03937)
            TotalWidthic = FormatNumber(TotalWidthic, 4, , , False)
            totalheightic = (Val(txtheightf.Text) * 12) + (Val(txtheighti.Text)) + (Val(txtheightc.Text) * 0.3937) + (Val(txtheightm.Text) * 0.03937)
            totalheightic = FormatNumber(totalheightic, 4, , , False)

            TotalSizeic = Val(TotalLengthsic) * Val(TotalWidthic) * Val(totalheightic)
            totalsizemc = Val(TotalSizeic) * 0.000016387064               '/ 61024

            txttotalsize.Text = totalsizemc
            txttotalsize.Text = FormatNumber(totalsizemc, 4, , , False)
            txttotalsizef.Text = FormatNumber((Val(txttotalsize.Text) * 35.314), 4, , , False)
            txttotalsizef.Text = FormatNumber((txttotalsizef.Text), 4, , , False)
            If Val(txttotalsize.Text) = 0 Then txttotalsize.Text = ""
            If Val(txttotalsizef.Text) = 0 Then txttotalsizef.Text = ""

        Catch Ex As Exception

            MsgBox(Ex.Message, MsgBoxStyle.Critical, "TotalSize Procedure")
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in DTotalSize", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub txtheightm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtheightm.LostFocus

        Call DTotalSize()

    End Sub

    Private Sub txtheightc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtheightc.LostFocus

        Call DTotalSize()

    End Sub

    Private Sub txtheightf_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtheightf.LostFocus

        Call DTotalSize()

    End Sub

    Private Sub txtheighti_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtheighti.LostFocus

        Call DTotalSize()

    End Sub

    Private Sub txtlengthc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtlengthc.LostFocus

        Call DTotalSize()

    End Sub

    Private Sub txtlengthf_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtlengthf.LostFocus

        Call DTotalSize()

    End Sub

    Private Sub txtlengthi_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtlengthi.LostFocus

        Call DTotalSize()

    End Sub

    Private Sub txtlengthm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtlengthm.LostFocus

        Call DTotalSize()

    End Sub

    Private Sub txtwidthc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtwidthc.LostFocus

        Call DTotalSize()

    End Sub

    Private Sub txtwidthf_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtwidthf.LostFocus

        Call DTotalSize()

    End Sub

    Private Sub txtwidthi_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtwidthi.LostFocus

        Call DTotalSize()

    End Sub

    Private Sub txtwidthm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtwidthm.LostFocus

        Call DTotalSize()

    End Sub


    'Private Sub tsbtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    Try

    '        Call cmdExit_Click(sender, e)

    '    Catch Err As Exception
    '        MsgBox(Err.Message)
    '        MessageBox.Show("Error in tsbtnExit_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try

    'End Sub

    'Private Sub tslblExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    Try

    '        Call cmdExit_Click(sender, e)

    '    Catch Err As Exception
    '        MsgBox(Err.Message)
    '        MessageBox.Show("Error in tsbtnExit_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try

    'End Sub

    'Private Sub tslblHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    Try

    '        Call cmdHelp_Click(sender, e)

    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '        MessageBox.Show("Error in tslblHelp_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try

    'End Sub

    'Private Sub tsbtnHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    Try

    '        Call cmdHelp_Click(sender, e)

    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '        MessageBox.Show("Error in tsbtnHelp_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try

    'End Sub

    'Private Sub tslblFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    Try

    '        Call cmdFind_Click(sender, e)

    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '        MessageBox.Show("Error in tslblFind_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try

    'End Sub

    'Private Sub tsbtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    Try

    '        Call cmdFind_Click(sender, e)

    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '        MessageBox.Show("Error in tslblFind_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try

    'End Sub

    'Private Sub tslblLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    Try

    '        Call cmdLast_Click(sender, e)

    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '        MessageBox.Show("Error in tslblLast_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try

    'End Sub

    'Private Sub tsbtnLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    Try

    '        Call cmdLast_Click(sender, e)

    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '        MessageBox.Show("Error in tsbtnLast_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try

    'End Sub

    'Private Sub tslblNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    Try
    '        Call cmdNext_Click(sender, e)

    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '        MessageBox.Show("Error in tslblNext_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try

    'End Sub

    'Private Sub tsbtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    Try
    '        Call cmdNext_Click(sender, e)

    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '        MessageBox.Show("Error in tsbtnNext_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try

    'End Sub

    'Private Sub tslblPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    Try
    '        Call cmdPrev_Click(sender, e)

    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '        MessageBox.Show("Error in tslblPrev_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try

    'End Sub

    'Private Sub tsbtnPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    Try
    '        Call cmdPrev_Click(sender, e)

    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '        MessageBox.Show("Error in tsbtnPrev_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try

    'End Sub

    Private Sub tsbtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnAdd.Click

        Try

            Call cmdAdd_Click(sender, e)

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in tsbtnAdd_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tslblAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tslblAdd.Click

        Try

            Call cmdAdd_Click(sender, e)

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in tslblAdd_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnEdit.Click

        Try

            Call cmdEdit_Click(sender, e)

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in tsbtnEdit_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tslblEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tslblEdit.Click

        Try

            Call cmdEdit_Click(sender, e)

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in tslblEdit_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnDelete.Click

        Try

            Call cmdDel_Click(sender, e)

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in tsbtnDelete_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tslblDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tslblDelete.Click

        Try

            Call cmdDel_Click(sender, e)

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in tslblDelete_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbtnFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnFirst.Click

        Try
            Call cmdFirst_Click(sender, e)
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in tsbtnFirst_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tslblFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tslblFirst.Click

        Try
            Call cmdFirst_Click(sender, e)
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in tslblFirst_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbtnPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnPrev.Click

        Try

            Call cmdPrev_Click(sender, e)

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in tsbtnPrev_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tslblPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tslblPrev.Click

        Try

            Call cmdPrev_Click(sender, e)

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in tslblPrev_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnNext.Click

        Try

            Call cmdNext_Click(sender, e)

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in tsbtnNext_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tslblNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tslblNext.Click

        Try
            Call cmdNext_Click(sender, e)
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in tsbtnNext_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbtnLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnLast.Click

        Try
            Call cmdLast_Click(sender, e)
        Catch err As Exception
            MsgBox(err.Message)
            MsgBox(err.ToString)
            MessageBox.Show("Error in tsbtnNext_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tslblLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tslblLast.Click

        Try
            Call cmdLast_Click(sender, e)
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in tsbtnNext_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnFind.Click

        Try
            Call cmdFind_Click(sender, e)
        Catch err As Exception
            MsgBox(err.Message)
            MsgBox(err.ToString)
            MessageBox.Show("Error in tsbtnNext_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tslblFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tslblFind.Click

        Try

            Call cmdFind_Click(sender, e)

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in tsbtnNext_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbtnHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnHelp.Click

        Try

            Call cmdHelp_Click(sender, e)

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in tsbtnNext_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tslbl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tslbl.Click

        Try

            Call cmdHelp_Click(sender, e)

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in tsbtnNext_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnExit.Click

        Try

            Call cmdExit_Click(sender, e)

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in tsbtnNext_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tslblExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tslblExit.Click

        Try

            Call cmdExit_Click(sender, e)

        Catch err As Exception
            MsgBox(err.Message)
            MsgBox(err.ToString)
            MessageBox.Show("Error in tsbtnNext_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbtnBoxTCM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnBoxTCM.Click

        Try

            MDIForm.Focus()
            Me.Close()
            GC.Collect()

            Try
                DisplayActivity.lblDisplayActivity.Visible = True
                DisplayActivity.lblDisplayActivity.Text = "Please wait..." & vbCrLf & "Box Container master activity show"
                DisplayActivity.Show()
                Me.Dispose(True)
            Catch ex As Exception
                Exit Try
            Finally
                ContainerMaster.Show()
                DisplayActivity.lblDisplayActivity.Text = ""
                DisplayActivity.lblDisplayActivity.Visible = False
            End Try

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
                DrumCM(sender, e)
            End Try

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
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

    Private Sub tsbtnRestart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnRestart.Click

        MDIForm.Focus()
        GC.Collect()
        Try
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

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in tsbtnRestart_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Box3DViewerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Box3DViewerToolStripMenuItem.Click

        Dim fNm As String = "C:\CSP.Box.wrl"

        Try

            Process.Start("C:\Program Files\Alteros 3D\alteros.exe", fNm)

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in Box3DViewerToolStripMenuItem_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Drum3DViewerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Drum3DViewerToolStripMenuItem.Click

        Dim fNm As String = "C:\CSP.Drum.wrl"

        Try

            Process.Start("C:\Program Files\Alteros 3D\alteros.exe", fNm)

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in Drum3DViewerToolStripMenuItem_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub BoxDrum3DViewerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BoxDrum3DViewerToolStripMenuItem.Click

        MessageBox.Show(" Work in progress ", "Info.....", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub Other3DViewerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Other3DViewerToolStripMenuItem.Click

        MessageBox.Show(" Work in progress ", "Info.....", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

#End Region

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    
End Class
