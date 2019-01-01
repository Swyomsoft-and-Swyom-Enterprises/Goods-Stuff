
'Program Name: -    ContainerMaster.vb
'Programmer Name: - Satwadhir B. Pawar Mob No. :- 9323974665
'Company Name:-     Hazel Infotech LTD. Mumbai
'Project Name: -    P-Stuff Plus (Container Stuffing)
'Date: -            23 Dec 2K8 5.00 PM (Modified Time)

'Tips: - The code is debugging at that particular dimensions, quantity and sequence.
'        you are decide it the logic happen is correct to that way or its are some 
'        different way the understanding to at your best level is the correct logic 
'        of this particular code block.

'Description: - Container has different types and sizes, so entering the particular usage 
'               container, use the form according to the container length width height 
'               inserting to store the specific container for next activity.

#Region " Importing Object "

Imports SDO = System.Data.OleDb
Imports MSScriptControl

#End Region

Public NotInheritable Class ContainerMaster
    Inherits System.Windows.Forms.Form

#Region " Class Declaration "

    Private ds As New DataSet
    Private introw As Integer
    Dim da As New SDO.OleDbDataAdapter
    Dim str As String
    Dim N As Integer
    Dim BFlag As Boolean

#End Region

#Region " Routine Definitions "

    Public Sub Txtclear()

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
        ContainerDetails.Enabled = False

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
        ContainerDetails.Enabled = False

    End Sub

    Public Sub TotalSize()

        Try
            Dim totalsizeic As Single
            totallengthic = (Val(txtlengthf.Text) * 12) + (Val(txtlengthi.Text)) + (Val(txtlengthc.Text) * 0.3937) + (Val(txtlengthm.Text) * 0.03937) ' Check Conversion Chart In Report
            totallengthic = FormatNumber(totallengthic, 4, , , False)
            totalwidthic = (Val(txtwidthf.Text) * 12) + (Val(txtwidthi.Text)) + (Val(txtwidthc.Text) * 0.3937) + (Val(txtwidthm.Text) * 0.03937)
            totalwidthic = FormatNumber(totalwidthic, 4, , , False)
            totalheightic = (Val(txtheightf.Text) * 12) + (Val(txtheighti.Text)) + (Val(txtheightc.Text) * 0.3937) + (Val(txtheightm.Text) * 0.03937)
            totalheightic = FormatNumber(totalheightic, 4, , , False)
            totalsizeic = Val(totallengthic) * Val(totalwidthic) * Val(totalheightic)
            totalsizemc = Val(totalsizeic) * 0.000016387064               '/ 61024
            txttotalsize.Text = totalsizemc
            txttotalsize.Text = FormatNumber(totalsizemc, 4, , , False)
            txttotalsizef.Text = FormatNumber((Val(txttotalsize.Text) * 35.314), 4, , , False)
            txttotalsizef.Text = FormatNumber((txttotalsizef.Text), 4, , , False)
            If Val(txttotalsize.Text) = 0 Then txttotalsize.Text = ""
            If Val(txttotalsizef.Text) = 0 Then txttotalsizef.Text = ""

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in TotalSize", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'MsgBox(Ex.Message, MsgBoxStyle.Critical, "TotalSize Routine")
        End Try

    End Sub

    Public Sub STotalSize()

        Try
            Dim totalsizeic As Single
            totallengthic = (Val(Stxtlengthf.Text) * 12) + (Val(Stxtlengthi.Text)) + (Val(Stxtlengthc.Text) * 0.3937) + (Val(Stxtlengthm.Text) * 0.03937) ' Check Conversion Chart In Report
            totallengthic = FormatNumber(totallengthic, 4, , , False)
            totalwidthic = (Val(Stxtwidthf.Text) * 12) + (Val(Stxtwidthi.Text)) + (Val(Stxtwidthc.Text) * 0.3937) + (Val(Stxtwidthm.Text) * 0.03937)
            totalwidthic = FormatNumber(totalwidthic, 4, , , False)
            totalheightic = (Val(Stxtheightf.Text) * 12) + (Val(Stxtheighti.Text)) + (Val(Stxtheightc.Text) * 0.3937) + (Val(Stxtheightm.Text) * 0.03937)
            totalheightic = FormatNumber(totalheightic, 4, , , False)
            totalsizeic = Val(totallengthic) * Val(totalwidthic) * Val(totalheightic)
            totalsizemc = Val(totalsizeic) * 0.000016387064               '/ 61024
            txttotalsize.Text = totalsizemc
            txttotalsize.Text = FormatNumber(totalsizemc, 4, , , False)
            txttotalsizef.Text = FormatNumber((Val(txttotalsize.Text) * 35.314), 4, , , False)
            txttotalsizef.Text = FormatNumber((txttotalsizef.Text), 4, , , False)
            If Val(txttotalsize.Text) = 0 Then txttotalsize.Text = ""
            If Val(txttotalsizef.Text) = 0 Then txttotalsizef.Text = ""

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in STotalSize", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'MsgBox(Ex.Message, MsgBoxStyle.Critical, "TotalSize Routine")
        End Try

    End Sub

    Private Sub ContainerMaster_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DoubleClick

        If ColDlgCntMst.ShowDialog Then
            Me.BackColor = ColDlgCntMst.Color
        End If

    End Sub

    Private Sub ContainerMaster_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Call MDIForm.BringFront()
    End Sub

    Private Sub ContainerMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        If e.KeyCode = Keys.Escape Then Close()

    End Sub

    Private Sub ContainerMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            Me.Cursor = Cursors.WaitCursor

            DisplayActivity.Close()
            'btnBoxType.Enabled = False

            'Me.Top = 65 : Me.Left = 130
            Me.StartPosition = FormStartPosition.CenterScreen
            BFlag = False
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            FillDataSet()
            ContainerDetails.Enabled = False
            Label1.Visible = False
            txtcontno.Visible = False
            cmdUpdate.Enabled = False
            cmdRef.Enabled = False
            txtcontname.Focus()
            If ds.Tables!Text.Rows.Count = 0 Then
                Call NoRecorddisplay()
                Call Txtclear()
                Exit Sub
            ElseIf ds.Tables!Text.Rows.Count - 1 >= 0 Then
                introw = ds.Tables!Text.Rows.Count - 1
                Call txtbind()
                Call loadenable()
            End If
            cmdAdd.TabIndex = 0
            cmdLast_Click(Nothing, Nothing)

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in ContainerMaster_Load", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub txtbind()

        Try

            txtcontno.Text = IIf(IsDBNull(ds.Tables!Text.Rows(introw).Item("ContainerNo")), "", ds.Tables!Text.Rows(introw).Item("ContainerNo"))
            txtcontname.Text = IIf(IsDBNull(ds.Tables!Text.Rows(introw).Item("ContainerName")), "", ds.Tables!Text.Rows(introw).Item("ContainerName"))
            If Val(ds.Tables!Text.Rows(introw).Item("LengthF")) = 0 Then
                txtlengthf.Text = ""
            Else
                txtlengthf.Text = Val(ds.Tables!Text.Rows(introw).Item("LengthF"))
            End If

            If Val(ds.Tables!Text.Rows(introw).Item("WidthF")) = 0 Then
                txtwidthf.Text = ""
            Else
                txtwidthf.Text = ds.Tables!Text.Rows(introw).Item("WidthF")
            End If

            If Val(ds.Tables!Text.Rows(introw).Item("HeightF")) = 0 Then
                txtheightf.Text = ""
            Else
                txtheightf.Text = ds.Tables!Text.Rows(introw).Item("HeightF")
            End If

            If Val(ds.Tables!Text.Rows(introw).Item("LengthI")) = 0 Then
                txtlengthi.Text = ""
            Else
                txtlengthi.Text = ds.Tables!Text.Rows(introw).Item("LengthI")
            End If

            If Val(ds.Tables!Text.Rows(introw).Item("WidthI")) = 0 Then
                txtwidthi.Text = ""
            Else
                txtwidthi.Text = ds.Tables!Text.Rows(introw).Item("WidthI")
            End If

            If Val(ds.Tables!Text.Rows(introw).Item("HeightI")) = 0 Then
                txtheighti.Text = ""
            Else
                txtheighti.Text = ds.Tables!Text.Rows(introw).Item("HeightI")
            End If

            If Val(ds.Tables!Text.Rows(introw).Item("LengthC")) = 0 Then
                txtlengthc.Text = ""
            Else
                txtlengthc.Text = ds.Tables!Text.Rows(introw).Item("LengthC")
            End If

            If Val(ds.Tables!Text.Rows(introw).Item("WidthC")) = 0 Then
                txtwidthc.Text = ""
            Else
                txtwidthc.Text = ds.Tables!Text.Rows(introw).Item("WidthC")
            End If

            If Val(ds.Tables!Text.Rows(introw).Item("HeightC")) = 0 Then
                txtheightc.Text = ""
            Else
                txtheightc.Text = ds.Tables!Text.Rows(introw).Item("HeightC")
            End If

            If Val(ds.Tables!Text.Rows(introw).Item("LengthM")) = 0 Then
                txtlengthm.Text = ""
            Else
                txtlengthm.Text = (ds.Tables!Text.Rows(introw).Item("LengthM"))
            End If

            If Val(ds.Tables!Text.Rows(introw).Item("WidthM")) = 0 Then
                txtwidthm.Text = ""
            Else
                txtwidthm.Text = ds.Tables!Text.Rows(introw).Item("WidthM")
            End If

            If Val(ds.Tables!Text.Rows(introw).Item("HeightM")) = 0 Then
                txtheightm.Text = ""
            Else
                txtheightm.Text = ds.Tables!Text.Rows(introw).Item("HeightM")
            End If

            txtloadkg.Text = FormatNumber(IIf(IsDBNull(ds.Tables!Text.Rows(introw).Item("PayLoad")), "", ds.Tables!Text.Rows(introw).Item("PayLoad")), 2, , , False)
            If Val(txtloadkg.Text) = 0 Then txtloadkg.Text = ""
            txtloadlbs.Text = FormatNumber(IIf(IsDBNull(ds.Tables!Text.Rows(introw).Item("PayLoad") * 2.2045), "", ds.Tables!Text.Rows(introw).Item("PayLoad") * 2.2045), 2, , , False)
            If Val(txtloadlbs.Text) = 0 Then txtloadlbs.Text = ""
            txttotalsize.Text = FormatNumber(IIf(IsDBNull(ds.Tables!Text.Rows(introw).Item("TotalSize")), "", ds.Tables!Text.Rows(introw).Item("TotalSize")), 4, , , False)
            If Val(txttotalsize.Text) = 0 Then txttotalsize.Text = ""
            txttotalsizef.Text = FormatNumber(IIf(IsDBNull(ds.Tables!Text.Rows(introw).Item("TotalSizeF")), "", ds.Tables!Text.Rows(introw).Item("TotalSizeF")), 4, , , False)
            If Val(txttotalsizef.Text) = 0 Then txttotalsizef.Text = ""

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in txtbind", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub FillDataSet()

        Try

            Dim strSQL As String
            strSQL = "select * from ContainerMaster"
            Dim da As New SDO.OleDbDataAdapter(strSQL, conn)
            If ds.Tables.CanRemove(ds.Tables("Text")) Then
                ds.Tables("Text").Rows.Clear()
                ds.Tables("Text").Columns.Clear()
            End If
            da.Fill(ds, "Text")
            da = Nothing

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in FillDataSet", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click

        Try

            Txtclear()
            addenable()
            str = "Add"
            ContainerDetails.Enabled = True
            txtcontname.Focus()
            BFlag = True

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in cmdAdd_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click

        Try

            str = "Edit"
            editenable()
            ContainerDetails.Enabled = True
            txtcontname.Focus()
            BFlag = True

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in cmdEdit_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDel.Click

        Try

            Dim comm As New SDO.OleDbCommand 'delete
            If MsgBox("Are you sure you want to delete this Record?", MsgBoxStyle.YesNo + vbCritical, "Container Master") = MsgBoxResult.Yes Then
                Dim strId As String
                strId = FCount("Select Count(ContainerName) as ContainerName1  from NInwardDetail where ContainerName='" & Trim(txtcontname.Text) & "'")
                If strId = 0 Then
                    comm = New SDO.OleDbCommand("Delete from ContainerMaster where ContainerNo=" & Val(txtcontno.Text), conn)
                    If conn.State = ConnectionState.Closed Then conn.Open()
                    Try
                        comm.ExecuteNonQuery()
                        FillDataSet()
                        If ds.Tables!Text.Rows.Count = 0 Then
                            Call Txtclear()
                            Call NoRecorddisplay()
                            cmdAdd.Focus()
                            Exit Sub
                        Else
                            introw = ds.Tables!Text.Rows.Count - 1
                            Call Txtclear()
                            Call txtbind()
                        End If
                    Catch Ex As Exception

                        MsgBox(Ex.Message, MsgBoxStyle.Critical, "Error in :: cmdDel_Click Procedure")

                    End Try
                Else
                    MsgBox("Cannot delete the record. It is being used!", MsgBoxStyle.Critical, "Container Master")
                    Exit Sub
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in cmdDel_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click

        Try
            Call gbDim1_Click(sender, e)
            Dim strSQL As String
            Dim comm As SDO.OleDbCommand
            If Trim(txtcontname.Text) = "" Then
                MsgBox("Please enter Container Name.", MsgBoxStyle.Exclamation, "Container Master")
                addenable()
                txtcontname.Focus()
                Exit Sub
            End If
            If str = "Add" Then
                '-------Check Duplicate Record
                Dim strId As String
                strId = FCount("Select Count(ContainerName) as ContainerName1  from ContainerMaster where ContainerName='" & Trim(txtcontname.Text) & "'")
                If strId <> 0 Then
                    MsgBox("Dublicate Container name should not allow", MsgBoxStyle.Exclamation, "Container Master")
                    txtcontname.Focus()
                    Exit Sub
                End If
                '--------------------
                Dim Str1 As String
                Str1 = "Select Max(ContainerNo) As CId from ContainerMaster"
                txtcontno.Text = GenId(Str1)
                strSQL = "Insert into ContainerMaster(ContainerNo,ContainerName,LengthF,WidthF,HeightF,LengthI,WidthI,HeightI,"
                strSQL = strSQL & "LengthC,WidthC,HeightC,LengthM,WidthM,HeightM,Payload,TotalSize,TotalSizeF)"
                strSQL = strSQL & "values(" & Val(txtcontno.Text) & ", '" & Replace(Trim(txtcontname.Text), "'", "`") & "', " & Val(txtlengthf.Text) & ", " & Val(txtwidthf.Text) & ","
                strSQL = strSQL & " " & Val(txtheightf.Text) & ", " & Val(txtlengthi.Text) & ", " & Val(txtwidthi.Text) & ", " & Val(txtheighti.Text) & ", "
                strSQL = strSQL & " " & Val(txtlengthc.Text) & ", " & Val(txtwidthc.Text) & "," & Val(txtheightc.Text) & ", " & Val(txtlengthm.Text) & ", "
                strSQL = strSQL & " " & Val(txtwidthm.Text) & ", " & Val(txtheightm.Text) & ", " & Val(txtloadkg.Text) & ", " & Val(txttotalsize.Text) & ", "
                strSQL = strSQL & " " & Val(txttotalsizef.Text) & ") "
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
                    ContainerDetails.Enabled = False
                    cmdAdd.Focus()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                    Exit Sub
                End Try
            ElseIf str = "Edit" Then
                strSQL = "Update ContainerMaster set ContainerName='" & Replace(Trim(txtcontname.Text), "'", "`") & "', LengthF=" & Val(txtlengthf.Text) & ","
                strSQL = strSQL & " WidthF=" & Val(txtwidthf.Text) & ", HeightF=" & Val(txtheightf.Text) & ", LengthI=" & Val(txtlengthi.Text) & ","
                strSQL = strSQL & " WidthI=" & Val(txtwidthi.Text) & ", HeightI=" & Val(txtheighti.Text) & ", LengthC=" & Val(txtlengthc.Text) & ","
                strSQL = strSQL & " WidthC=" & Val(txtwidthc.Text) & ", HeightC=" & Val(txtheightc.Text) & ", LengthM=" & Val(txtlengthm.Text) & ","
                strSQL = strSQL & " WidthM=" & Val(txtwidthm.Text) & ", HeightM=" & Val(txtheightm.Text) & ", Payload=" & Val(txtloadkg.Text) & ","
                strSQL = strSQL & " TotalSize=" & Val(txttotalsize.Text) & ",TotalSizeF=" & Val(txttotalsizef.Text) & " where ContainerNo =" & Val(txtcontno.Text) & ""

                comm = New SDO.OleDbCommand(strSQL, conn)
                Try
                    If conn.State = ConnectionState.Closed Then conn.Open()
                    comm.ExecuteNonQuery()
                    FillDataSet()
                    txtbind()
                    conn.Close()
                    BFlag = False
                    saveenable()
                    ContainerDetails.Enabled = False
                    cmdAdd.Focus()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                    Exit Sub
                End Try
                ' cmdLast_Click(Nothing, Nothing)
            End If

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in cmdUpdate", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdRef_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRef.Click

        Try

            Dim comm As New SDO.OleDbCommand 'delete
            If MsgBox("Are you sure you want to refresh this record?", MsgBoxStyle.YesNo + vbInformation, "Container Master") = MsgBoxResult.Yes Then
                If ds.Tables!Text.Rows.Count = 0 Then
                    Call Txtclear()
                    Call NoRecorddisplay()
                    introw = 0
                    BFlag = False
                    cmdAdd.Focus()
                    Exit Sub
                ElseIf introw > 0 Or introw <= ds.Tables!Text.Rows.Count - 1 Then
                    refenable()
                    Txtclear()
                    txtbind()
                    BFlag = False
                    cmdAdd.Focus()
                End If
            Else
                txtcontname.Focus()
                Exit Sub
            End If

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in cmdRef_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click

        Try

            Dim comm As SDO.OleDbCommand
            If BFlag = True Then
                If MsgBox("Do you want to save this record?", MsgBoxStyle.YesNo + vbExclamation, "Container Master") = MsgBoxResult.Yes Then
                    If Trim(txtcontname.Text) = "" Then
                        MsgBox("Please enter Container Name.", MsgBoxStyle.Exclamation)
                        addenable()
                        txtcontname.Focus()
                        Exit Sub
                    End If
                    Dim strSQL As String
                    '----------------
                    If str = "Add" Then
                        '-------Check Duplicate Record
                        Dim strId As String
                        strId = FCount("Select Count(ContainerName) as ContainerName1  from ContainerMaster where ContainerName='" & Trim(txtcontname.Text) & "'")
                        If strId <> 0 Then
                            MsgBox("Dublicate Container name should not allow", MsgBoxStyle.Exclamation, "Container Master")
                            txtcontname.Focus()
                            Exit Sub
                        End If
                        '--------------------
                        Dim Str1 As String
                        Str1 = "Select Max(ContainerNo) As CId from ContainerMaster"
                        txtcontno.Text = GenId(Str1)
                        strSQL = "Insert into ContainerMaster(ContainerNo,ContainerName,LengthF,WidthF,HeightF,LengthI,WidthI,HeightI,"
                        strSQL = strSQL & "LengthC,WidthC,HeightC,LengthM,WidthM,HeightM,Payload,TotalSize,TotalSizeF)"
                        strSQL = strSQL & "values(" & Val(txtcontno.Text) & ", '" & Replace(Trim(txtcontname.Text), "'", "`") & "', " & Val(txtlengthf.Text) & ", " & Val(txtwidthf.Text) & ","
                        strSQL = strSQL & " " & Val(txtheightf.Text) & ", " & Val(txtlengthi.Text) & ", " & Val(txtwidthi.Text) & ", " & Val(txtheighti.Text) & ", "
                        strSQL = strSQL & " " & Val(txtlengthc.Text) & ", " & Val(txtwidthc.Text) & "," & Val(txtheightc.Text) & ", " & Val(txtlengthm.Text) & ", "
                        strSQL = strSQL & " " & Val(txtwidthm.Text) & ", " & Val(txtheightm.Text) & ", " & Val(txtloadkg.Text) & ", " & Val(txttotalsize.Text) & ", "
                        strSQL = strSQL & " " & Val(txttotalsizef.Text) & ") "

                        comm = New SDO.OleDbCommand(strSQL, conn)
                        Try
                            If conn.State = ConnectionState.Closed Then conn.Open()
                            comm.ExecuteNonQuery()
                            FillDataSet()
                            introw = ds.Tables!Text.Rows.Count - 1
                            txtbind()
                            conn.Close()
                            cmdAdd.Focus()
                            BFlag = False
                            Call saveenable()
                            Close()
                        Catch ex As Exception
                            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error in procedure cmdExit_Click")
                            MsgBox(ex.ToString)
                            MessageBox.Show("Error in cmdExit_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End Try

                    ElseIf str = "Edit" Then
                        strSQL = "Update ContainerMaster set ContainerName='" & Replace(Trim(txtcontname.Text), "'", "`") & "', LengthF=" & Val(txtlengthf.Text) & ","
                        strSQL = strSQL & " WidthF=" & Val(txtwidthf.Text) & ", HeightF=" & Val(txtheightf.Text) & ", LengthI=" & Val(txtlengthi.Text) & ","
                        strSQL = strSQL & " WidthI=" & Val(txtwidthi.Text) & ", HeightI=" & Val(txtheighti.Text) & ", LengthC=" & Val(txtlengthc.Text) & ","
                        strSQL = strSQL & " WidthC=" & Val(txtwidthc.Text) & ", HeightC=" & Val(txtheightc.Text) & ", LengthM=" & Val(txtlengthm.Text) & ","
                        strSQL = strSQL & " WidthM=" & Val(txtwidthm.Text) & ", HeightM=" & Val(txtheightm.Text) & ", Payload=" & Val(txtloadkg.Text) & ","
                        strSQL = strSQL & " TotalSize=" & Val(txttotalsize.Text) & ",TotalSizeF=" & Val(txttotalsizef.Text) & " where ContainerNo =" & Val(txtcontno.Text) & ""
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
                            Close()
                        Catch ex As Exception
                            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error in procedure cmdExit_Click")
                            MsgBox(ex.ToString)
                            MessageBox.Show("Error in cmdExit_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End Try
                    End If
                Else
                    Close()
                End If
            Else
                Close()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
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

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
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

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
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

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
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

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in cmdLast_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in cmdFind_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtcontno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcontno.GotFocus

        Try
            txtcontno.Select(0, 10)
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in txtcontno_GotFocus", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtcontname_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcontname.GotFocus

        Try

            txtcontname.Select(0, 50)

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in txtcontname_GotFocus", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtloadkg_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtloadkg.GotFocus

        Try
            txtloadkg.Select(0, 10)
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in txtloadkg_GotFocus", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtloadkg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtloadkg.KeyDown

        Try

            If txtloadkg.Text <> "" And e.KeyCode = Keys.Enter Then
                txtloadlbs.Text = FormatNumber((Val(txtloadkg.Text) * 2.2045), 2, , , False)
                txtlengthf.Focus()
            End If

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in txtloadkg_KeyDown", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtheightm_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtheightm.GotFocus

        Try

            txtheightm.Select(0, 10)

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in txtheightm_GotFocus", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtlengthf_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtlengthf.DoubleClick

        Try
            Calculation.btnOk.Visible = False
            Calculation.Show()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in txtlengthf_DoubleClick", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtlengthf_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtlengthf.GotFocus

        Try
            txtlengthf.Select(0, 10)
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in txtlengthf_GotFocus", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtwidthf_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtwidthf.GotFocus

        Try
            txtwidthf.Select(0, 10)
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in txtwidthf_GotFocus", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtheightf_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtheightf.GotFocus

        Try
            txtheightf.Select(0, 10)
        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in txtheightf_GotFocus", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtlengthi_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtlengthi.GotFocus

        Try

            txtlengthi.Select(0, 10)

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in txtlengthi_GotFocus", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtwidthi_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtwidthi.GotFocus

        Try
            txtwidthi.Select(0, 10)
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in txtwidthi_GotFocus", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtlengthc_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtlengthc.GotFocus

        Try
            txtlengthc.Select(0, 10)
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in txtlengthc_GotFocus", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtwidthc_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtwidthc.GotFocus

        Try
            txtwidthc.Select(0, 10)
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in txtwidthc_GotFocus", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtheightc_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtheightc.GotFocus

        Try

            txtheightc.Select(0, 10)

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in txtheightc_GotFocus", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtlengthm_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtlengthm.GotFocus

        Try
            txtlengthm.Select(0, 10)
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in txtlengthm_GotFocus", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtwidthm_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtwidthm.GotFocus

        Try
            txtwidthm.Select(0, 10)
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in txtwidthm_GotFocus", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtheighti_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtheighti.GotFocus

        Try
            txtheighti.Select(0, 10)
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in txtheighti_GotFocus", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtcontname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtcontname.KeyDown

        Try

            If e.KeyCode = Keys.Enter Then
                txtloadkg.Focus()
            End If

            'If e.KeyCode = 39 Then txtloadkg.Focus()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in txtcontname_KeyDown", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtlengthf_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtlengthf.KeyDown

        Try
            If e.KeyCode = Keys.Enter Then txtlengthi.Focus()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in txtlengthf_KeyDown", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtlengthi_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtlengthi.KeyDown

        Try
            If e.KeyCode = Keys.Enter Then txtlengthc.Focus()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in txtlengthi_KeyDown", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtlengthc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtlengthc.KeyDown

        Try
            If e.KeyCode = Keys.Enter Then txtlengthm.Focus()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in txtlengthc_KeyDown", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtlengthm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtlengthm.KeyDown

        Try
            If e.KeyCode = Keys.Enter Then txtwidthf.Focus()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in txtlengthm_KeyDown", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtwidthf_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtwidthf.KeyDown

        Try
            If e.KeyCode = Keys.Enter Then txtwidthi.Focus()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in txtwidthf_KeyDown", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtwidthi_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtwidthi.KeyDown

        Try
            If e.KeyCode = Keys.Enter Then txtwidthc.Focus()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in txtwidthi_KeyDown", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtwidthc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtwidthc.KeyDown

        Try
            If e.KeyCode = Keys.Enter Then txtwidthm.Focus()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in txtwidthc_KeyDown", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtwidthm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtwidthm.KeyDown

        Try
            If e.KeyCode = Keys.Enter Then txtheightf.Focus()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in txtwidthm_keyDown", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtheightf_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtheightf.KeyDown

        Try
            If e.KeyCode = Keys.Enter Then txtheighti.Focus()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in txtheightf_KeyDown", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtheighti_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtheighti.KeyDown

        Try
            If e.KeyCode = Keys.Enter Then txtheightc.Focus()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in txtheighti_KeyDown", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtheightc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtheightc.KeyDown

        Try
            If e.KeyCode = Keys.Enter Then txtheightm.Focus()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in txtheightc_KeyDown", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtheightm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtheightm.KeyDown

        Try
            If e.KeyCode = Keys.Enter Then cmdUpdate.Focus()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in txtheightm_KeyDown", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtheightm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtheightm.LostFocus

        Try
            Call TotalSize()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in txtheightm_LostFocus", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdHelp.Click

        Try

            Process.Start(CurDir() & "\HelpContainerStuff\Index.chm")

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in cmdHelp_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtloadkg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtloadkg.KeyPress

        Try
            e.Handled = ValidNumber(e.KeyChar, txtloadkg)

            'Dim k As Integer
            'k = Asc(e.KeyChar)
            'Select Case k
            '    Case 48 To 57, 8, 13, 32
            '    Case 45
            '    Case Else
            '        k = 0
            'End Select
            'If k = 0 Then
            '    e.Handled = True
            'Else
            '    e.Handled = False
            'End If

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in txtloadkg_KeyPress", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdUpdate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmdUpdate.KeyDown

        Try
            If e.KeyCode = Keys.Enter Then
                cmdAdd.Focus() : cmdUpdate_Click(Nothing, Nothing)
            Else
                Exit Sub
            End If
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in cmdUpdate_KeyDown", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub NoRecorddisplay()

        Try
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
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in NoRecorddisplay", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtcontname_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcontname.LostFocus

        Try
            txtcontname.Text = Replace(txtcontname.Text, "'", "`")
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in txtcontname_LostFocus", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtheightc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtheightc.LostFocus

        Try
            Call TotalSize()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in txtheightc_LostFocus", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtheightf_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtheightf.LostFocus

        Try
            Call TotalSize()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in txtheightf_LostFocus", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtheighti_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtheighti.LostFocus

        Try
            Call TotalSize()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in txtheighti_LostFocus", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtlengthc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtlengthc.LostFocus

        Try
            Call TotalSize()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in txtlengthc_LostFocus", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtlengthf_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtlengthf.LostFocus

        Try
            Call TotalSize()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in txtlengthf_LostFocus", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtlengthi_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtlengthi.LostFocus

        Try
            Call TotalSize()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in txtlengthi_LostFocus", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtlengthm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtlengthm.LostFocus

        Try
            Call TotalSize()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in txtlenghtm_LostFocus", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtwidthc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtwidthc.LostFocus

        Try
            Call TotalSize()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in txtwidthc_LostFocus", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtwidthf_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtwidthf.LostFocus

        Try
            Call TotalSize()
        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in txtwidthf_LostFocus", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtwidthi_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtwidthi.LostFocus

        Try
            Call TotalSize()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in txtwidthi_LostFocus", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtwidthm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtwidthm.LostFocus

        Try
            Call TotalSize()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in txtwidthm_LostFocus", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Try
            ActivitySettings.Show()
            ActivitySettings.Focus()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in btnSettings_Click", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
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
                ShowBoxContMst(sender, e)
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
            Me.Close()
            GC.Collect()

            Try
                DisplayActivity.lblDisplayActivity.Visible = True
                DisplayActivity.lblDisplayActivity.Text = "Please wait..." & vbCrLf & "Drum Container master activity show"
                DisplayActivity.Show()
                Me.Dispose(True)
            Catch ex As Exception
                Exit Try
            Finally
                ContainerMasterDrum.Show()
                DisplayActivity.lblDisplayActivity.Text = ""
                DisplayActivity.lblDisplayActivity.Visible = False
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

    Private Sub tsbtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnAdd.Click

        Try
            Call gbDim1_Click(sender, e)
            cmdAdd_Click(sender, e)

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in tsbtnAdd_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tslblAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tslblAdd.Click

        Try
            Call gbDim1_Click(sender, e)
            cmdAdd_Click(sender, e)

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in tslblAdd_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnEdit.Click

        Try
            Call gbDim1_Click(sender, e)
            cmdEdit_Click(sender, e)

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in tsbtnEdit_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tslblEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tslblEdit.Click

        Try
            Call gbDim1_Click(sender, e)
            cmdEdit_Click(sender, e)

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in tslblEdit_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnDelete.Click

        Try
            Call gbDim1_Click(sender, e)
            cmdDel_Click(sender, e)

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in tsbtnDelete_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tslblDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tslblDelete.Click

        Try
            Call gbDim1_Click(sender, e)
            cmdDel_Click(sender, e)

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in tslblDelete_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbtnFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnFirst.Click

        Try
            Call gbDim1_Click(sender, e)
            cmdFirst_Click(sender, e)

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in tsbtnFirst_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tslblFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tslblFirst.Click

        Try
            Call gbDim1_Click(sender, e)
            cmdFirst_Click(sender, e)

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in tslblFirst_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbtnPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnPrev.Click

        Try
            Call gbDim1_Click(sender, e)
            cmdPrev_Click(sender, e)

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in tsbtnPrev_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tslblPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tslblPrev.Click

        Try
            Call gbDim1_Click(sender, e)
            cmdPrev_Click(sender, e)

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in tslblPrev_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnNext.Click

        Try
            Call gbDim1_Click(sender, e)
            cmdNext_Click(sender, e)

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in tsbtnNext_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tslblNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tslblNext.Click

        Try
            Call gbDim1_Click(sender, e)
            cmdNext_Click(sender, e)

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in tslblNext_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbtnLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnLast.Click

        Try
            Call gbDim1_Click(sender, e)
            cmdLast_Click(sender, e)

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in tsbtnLast_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tslblLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tslblLast.Click

        Try
            Call gbDim1_Click(sender, e)
            cmdLast_Click(sender, e)

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in tslblLast_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tslblFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tslblFind.Click

        Try
            Call gbDim1_Click(sender, e)
            cmdFind_Click(sender, e)

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in tslblFind_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnFind.Click

        Try

            cmdFind_Click(sender, e)

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in tsbtnFind_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbtnHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnHelp.Click

        Try
            Call gbDim1_Click(sender, e)
            cmdHelp_Click(sender, e)

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in tsbtnHelp_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tslbl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tslbl.Click

        Try
            Call gbDim1_Click(sender, e)
            cmdHelp_Click(sender, e)

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in tsbtnHelp_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tsbtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnExit.Click

        Try
            Call gbDim1_Click(sender, e)
            cmdExit_Click(sender, e)

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in tsbtnExit_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tslblExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tslblExit.Click

        Try
            Call gbDim1_Click(sender, e)
            cmdExit_Click(sender, e)

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in tslblExit_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

#End Region

    Private Sub gbDim0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles gbDim0.Click

        Try

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

            Call STotalSize()
            Call TotalSize()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in gbDim0_Click", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub gbDim1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles gbDim1.Click


        Try

            gbDim1.Visible = False

            If Stxtlengthf.Text = "" Or Stxtwidthf.Text = "" Or Stxtheightf.Text = "" Or Stxtlengthi.Text = "" Or Stxtwidthi.Text = "" Or Stxtheighti.Text = "" Or Stxtlengthc.Text = "" Or Stxtwidthc.Text = "" Or Stxtheightc.Text = "" Or Stxtlengthm.Text = "" Or Stxtwidthm.Text = "" Or Stxtheightm.Text = "" Then
                GoTo NxtLp
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

NxtLp:

            Call STotalSize()
            Call TotalSize()

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in gbDim1_Click", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Function VCalc(ByVal inVal As String) As String

        Try

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

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in VCalc", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return inVal

    End Function

    Private Sub Stxtheightc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Stxtheightc.LostFocus

        Try
            Stxtheightc.Text = VCalc(Stxtheightc.Text)
            Call STotalSize()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in Stxtheightc_LostFocus", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Stxtheightf_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Stxtheightf.LostFocus

        Try
            Stxtheightf.Text = VCalc(Stxtheightf.Text)
            Call STotalSize()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in Stxtheightf_LostFocus", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Stxtheighti_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Stxtheighti.LostFocus

        Try
            Stxtheighti.Text = VCalc(Stxtheighti.Text)
            Call STotalSize()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in Stxtheighti_LostFocus", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Stxtheightm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Stxtheightm.LostFocus

        Try
            Stxtheightm.Text = VCalc(Stxtheightm.Text)
            Call STotalSize()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in Stxtheightm_LostFocus", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Stxtlengthc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Stxtlengthc.LostFocus

        Try
            Stxtlengthc.Text = VCalc(Stxtlengthc.Text)
            Call STotalSize()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in Stxtlengthc_LostFocus", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Stxtlengthf_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Stxtlengthf.LostFocus

        Try
            Stxtlengthf.Text = VCalc(Stxtlengthf.Text)
            Call STotalSize()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in Stxtlengthf_LostFocus", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Stxtlengthi_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Stxtlengthi.LostFocus

        Try
            Stxtlengthi.Text = VCalc(Stxtlengthi.Text)
            Call STotalSize()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in Stxtlengthi_LostFocus", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Stxtlengthm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Stxtlengthm.LostFocus

        Try
            Stxtlengthm.Text = VCalc(Stxtlengthm.Text)
            Call STotalSize()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in Stxtlengthm_LostFocus", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Stxtwidthc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Stxtwidthc.LostFocus

        Try
            Stxtwidthc.Text = VCalc(Stxtwidthc.Text)
            Call STotalSize()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in Stxtwidthc_LostFocus", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Stxtwidthf_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Stxtwidthf.LostFocus

        Try
            Stxtwidthf.Text = VCalc(Stxtwidthf.Text)
            Call STotalSize()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in Stxtwidthf_LostFocus", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Stxtwidthi_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Stxtwidthi.LostFocus

        Try
            Stxtwidthi.Text = VCalc(Stxtwidthi.Text)
            Call STotalSize()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in Stxtwidthi_LostFocus", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Stxtwidthm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Stxtwidthm.LostFocus

        Try
            Stxtwidthm.Text = VCalc(Stxtwidthm.Text)
            Call STotalSize()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in Stxtwidthm_LostFocus", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub gbDim1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles gbDim1.LostFocus

        Try
            Call gbDim1_Click(sender, e)
        Catch err As Exception
            MsgBox(err.Message)
            MsgBox(err.ToString)
            MessageBox.Show("Error in gbDim1_LostFocus", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdUpdate_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdUpdate.MouseEnter

        Try
            Call updates()
            Call gbDim1_Click(sender, e)
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in cmdUpdate_MouseEnter", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdUpdate_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdUpdate.MouseHover

        Try
            Call gbDim1_Click(sender, e)
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in cmdUpdate_MouseHover", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Protected Sub add()

        Try
            'ToolTip.SetToolTip(cmdAdd, "Add the container data into the master")
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in add", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Protected Sub edit()

        Try
            'ToolTip.SetToolTip(cmdEdit, "Edit the container data into the master")
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in edit", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Protected Sub delete()

        Try
            'ToolTip.SetToolTip(cmdDel, "Edit the container data into the master")
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in delete", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Protected Sub first()

        Try
            'ToolTip.SetToolTip(cmdFirst, "Go to the first record of the container master")
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in first", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Protected Sub previous()

        Try
            'ToolTip.SetToolTip(cmdPrev, "Go to the previous record of the container master")
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in previous", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Protected Sub nexts()

        Try
            'ToolTip.SetToolTip(cmdNext, "Go to the next record of the master")
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in nexts", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Protected Sub last()

        Try
            'ToolTip.SetToolTip(cmdLast, "Go to the last record of the master")
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in last", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Protected Sub find()

        Try
            'ToolTip.SetToolTip(cmdFind, "Find the record of container master")
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in find", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Protected Sub help()

        Try
            'ToolTip.SetToolTip(cmdHelp, "Help of the application")
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in help", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Protected Sub exits()

        Try
            'ToolTip.SetToolTip(cmdExit, "Exit the container master")
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in exits", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Protected Sub containername()

        Try
            'ToolTip.SetToolTip(txtcontname, "Enter the container identity name")
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in containername", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Protected Sub loads()

        Try
            'ToolTip.SetToolTip(txtloadkg, "Enter the weight in kg. Of load carrying capacity of the container")
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in loads", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Protected Sub flength()

        Try
            'ToolTip.SetToolTip(Stxtlengthf, "Enter the length in feet unit")
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in flength", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Protected Sub ilength()

        Try
            'ToolTip.SetToolTip(Stxtlengthi, "Enter the length in inch unit")
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in ilength", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Protected Sub clength()

        Try
            'ToolTip.SetToolTip(Stxtlengthc, "Enter the length in centimeter unit")
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in clength", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Protected Sub mlength()

        Try
            'ToolTip.SetToolTip(Stxtlengthm, "Enter the length in millimeter unit")
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in mlength", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Protected Sub fwidth()

        Try
            'ToolTip.SetToolTip(Stxtwidthf, "Enter the width in feet unit")
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in fwidth", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Protected Sub iwidth()

        Try
            'ToolTip.SetToolTip(Stxtwidthi, "Enter the width in inch unit")
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in iwidth", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Protected Sub cwidth()

        Try
            'ToolTip.SetToolTip(Stxtwidthc, "Enter the width in centimeter unit")
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in cwidth", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Protected Sub mwidth()

        Try
            'ToolTip.SetToolTip(Stxtwidthm, "Enter the width in millimeter unit")
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in mwidth", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Protected Sub fheight()

        Try
            'ToolTip.SetToolTip(Stxtheightf, "Enter the height in feet unit")
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in fheight", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Protected Sub iheight()

        Try
            'ToolTip.SetToolTip(Stxtheighti, "Enter the height in inch unit")
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in iheight", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Protected Sub cheight()

        Try
            'ToolTip.SetToolTip(Stxtheightc, "Enter the height in centimeter unit")
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in cheight", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Protected Sub mheight()

        Try
            'ToolTip.SetToolTip(Stxtheightm, "Enter the height in millimeter unit")
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in mheight", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Protected Sub updates()

        Try
            'ToolTip.SetToolTip(cmdUpdate, "Update the container master")
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in updates", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Protected Sub refreshs()

        Try
            'ToolTip.SetToolTip(cmdRef, "Refresh the container master")
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in refreshs", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdAdd_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAdd.MouseEnter

        Try
            Call add()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Errror in cmdAdd_MouseEnter", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdEdit_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdEdit.MouseEnter

        Try
            Call edit()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in cmdEdit_MouseEnter", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdDel_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdDel.MouseEnter

        Try
            Call delete()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in cmdDel_MouseEnter", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdFirst_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdFirst.MouseEnter

        Try
            Call first()
        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in cmdFirst_MouseEnter", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdPrev_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdPrev.MouseEnter

        Try
            Call previous()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in cmdPrev_MouseEnter", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdNext_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdNext.MouseEnter

        Try
            Call nexts()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in cmdNext_MouseEnter", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdLast_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdLast.MouseEnter

        Try
            Call last()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in cmdLast_MouseEnter", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdFind_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdFind.MouseEnter

        Try
            Call find()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in cmdFind_MouseEnter", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdHelp_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdHelp.MouseEnter

        Try
            Call help()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in cmdHelp_MouseEnter", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdExit_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdExit.MouseEnter

        Try
            Call exits()
        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in cmdExit_MouseEnter", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtcontname_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcontname.MouseEnter

        Try
            Call containername()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in txtcontname_MouseEnter", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtloadkg_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtloadkg.MouseEnter

        Try
            Call loads()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in txtloadkg_MouseEnter", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Stxtlengthf_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Stxtlengthf.MouseEnter

        Try
            Call flength()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in Stxtlengthf_MouseEnter", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Stxtlengthi_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Stxtlengthi.MouseEnter

        Try
            Call ilength()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in Stxtlengthi_MouseEnter", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Stxtlengthc_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Stxtlengthc.MouseEnter

        Try
            Call clength()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in Stxtlengthc_MouseEnter", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Stxtlengthm_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Stxtlengthm.MouseEnter

        Try
            Call mlength()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in Stxtlengthm_MouseEnter", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Stxtwidthf_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Stxtwidthf.MouseEnter

        Try
            Call fwidth()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in Stxtwidthf_MouseEnter", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Stxtwidthi_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Stxtwidthi.MouseEnter

        Try
            Call iwidth()
        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in Stxtwidthi_MouseEnter", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Stxtwidthc_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Stxtwidthc.MouseEnter

        Try
            Call cwidth()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in Stxtwidthc_MouseEnter", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Stxtwidthm_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Stxtwidthm.MouseEnter

        Try
            Call mwidth()
        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in Stxtwidthm_MouseEnter", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Stxtheightf_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Stxtheightf.MouseEnter

        Try
            Call fheight()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in Stxtheightf_MouseEnter", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Stxtheighti_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Stxtheighti.MouseEnter

        Try
            Call iheight()
        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in Stxtheighti_MouseEnter", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Stxtheightc_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Stxtheightc.MouseEnter

        Try
            Call cheight()
        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in Stxtheightc_MouseEnter", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Stxtheightm_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Stxtheightm.MouseEnter

        Try
            Call mheight()
        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in Stxtheightm_MouseEnter", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub


End Class

#Region " Test Code "

Public Class xx

    Public Delegate Sub cc(ByVal d As Integer)

    Public Sub bb(ByVal ss As cc)
        ss(2)
    End Sub

End Class

#End Region


