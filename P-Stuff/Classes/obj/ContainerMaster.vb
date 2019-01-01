Imports SDO = System.Data.OleDb

Public Class ContainerMaster
    Inherits System.Windows.Forms.Form
    Private ds As New DataSet
    Private introw As Integer
    Dim da As New SDO.OleDbDataAdapter
    Dim str As String
    Dim N As Integer
    Dim BFlag As Boolean

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

    Public Sub totalsize()
        Try
            Dim totalsizeic As Single
            totallengthic = (Val(txtlengthf.Text) * 12) + (Val(txtlengthi.Text)) + (Val(txtlengthc.Text) * 0.390625) + (Val(txtlengthm.Text) * 0.0390625) ' 0.0394
            totallengthic = FormatNumber(totallengthic, 4, , , False)
            totalwidthic = (Val(txtwidthf.Text) * 12) + (Val(txtwidthi.Text)) + (Val(txtwidthc.Text) * 0.390625) + (Val(txtwidthm.Text) * 0.0390625)
            totalwidthic = FormatNumber(totalwidthic, 4, , , False)
            totalheightic = (Val(txtheightf.Text) * 12) + (Val(txtheighti.Text)) + (Val(txtheightc.Text) * 0.390625) + (Val(txtheightm.Text) * 0.0390625)
            totalheightic = FormatNumber(totalheightic, 4, , , False)
            totalsizeic = Val(totallengthic) * Val(totalwidthic) * Val(totalheightic)
            totalsizemc = Val(totalsizeic) / 61024
            txttotalsize.Text = totalsizemc
            txttotalsize.Text = FormatNumber(totalsizemc, 4, , , False)
            txttotalsizef.Text = FormatNumber((Val(txttotalsize.Text) * 35.314), 4, , , False)
            txttotalsizef.Text = FormatNumber((txttotalsizef.Text), 4, , , False)
            If Val(txttotalsize.Text) = 0 Then txttotalsize.Text = ""
            If Val(txttotalsizef.Text) = 0 Then txttotalsizef.Text = ""
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "totalsize")
        End Try
    End Sub

    Private Sub ContainerMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Close()
    End Sub

    Private Sub ContainerMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = 65 : Me.Left = 130
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
    End Sub

    Private Sub txtbind()
        txtcontno.Text = IIf(IsDBNull(ds.Tables!Text.Rows(introw).Item("ContainerNo")), "", ds.Tables!Text.Rows(introw).Item("ContainerNo"))
        txtcontname.Text = IIf(IsDBNull(ds.Tables!Text.Rows(introw).Item("ContainerName")), "", ds.Tables!Text.Rows(introw).Item("ContainerName"))
        If Val(ds.Tables!Text.Rows(introw).Item("LengthF")) = 0 Then
            txtlengthf.Text = ""
        Else
            txtlengthf.Text = Val(ds.Tables!Text.Rows(introw).Item("LengthF"))
        End If
        'txtlengthf.Text = IIf(IsDBNull(ds.Tables!Text.Rows(introw).Item("LengthF")), "", ds.Tables!Text.Rows(introw).Item("LengthF"))
        If Val(ds.Tables!Text.Rows(introw).Item("WidthF")) = 0 Then
            txtwidthf.Text = ""
        Else
            txtwidthf.Text = ds.Tables!Text.Rows(introw).Item("WidthF")
        End If
        'txtwidthf.Text = IIf(IsDBNull(ds.Tables!Text.Rows(introw).Item("WidthF")), "", ds.Tables!Text.Rows(introw).Item("WidthF"))
        If Val(ds.Tables!Text.Rows(introw).Item("HeightF")) = 0 Then
            txtheightf.Text = ""
        Else
            txtheightf.Text = ds.Tables!Text.Rows(introw).Item("HeightF")
        End If
        'txtheightf.Text = IIf(IsDBNull(ds.Tables!Text.Rows(introw).Item("HeightF")), "", ds.Tables!Text.Rows(introw).Item("HeightF"))
        If Val(ds.Tables!Text.Rows(introw).Item("LengthI")) = 0 Then
            txtlengthi.Text = ""
        Else
            txtlengthi.Text = ds.Tables!Text.Rows(introw).Item("LengthI")
        End If
        'txtlengthi.Text = IIf(IsDBNull(ds.Tables!Text.Rows(introw).Item("LengthI")), "", ds.Tables!Text.Rows(introw).Item("LengthI"))
        If Val(ds.Tables!Text.Rows(introw).Item("WidthI")) = 0 Then
            txtwidthi.Text = ""
        Else
            txtwidthi.Text = ds.Tables!Text.Rows(introw).Item("WidthI")
        End If
        'txtwidthi.Text = IIf(IsDBNull(ds.Tables!Text.Rows(introw).Item("WidthI")), "", ds.Tables!Text.Rows(introw).Item("WidthI"))
        If Val(ds.Tables!Text.Rows(introw).Item("HeightI")) = 0 Then
            txtheighti.Text = ""
        Else
            txtheighti.Text = ds.Tables!Text.Rows(introw).Item("HeightI")
        End If
        'txtheighti.Text = IIf(IsDBNull(ds.Tables!Text.Rows(introw).Item("HeightI")), "", ds.Tables!Text.Rows(introw).Item("HeightI"))
        If Val(ds.Tables!Text.Rows(introw).Item("LengthC")) = 0 Then
            txtlengthc.Text = ""
        Else
            txtlengthc.Text = ds.Tables!Text.Rows(introw).Item("LengthC")
        End If
        'txtlengthc.Text = IIf(IsDBNull(ds.Tables!Text.Rows(introw).Item("LengthC")), "", ds.Tables!Text.Rows(introw).Item("LengthC"))
        If Val(ds.Tables!Text.Rows(introw).Item("WidthC")) = 0 Then
            txtwidthc.Text = ""
        Else
            txtwidthc.Text = ds.Tables!Text.Rows(introw).Item("WidthC")
        End If
        'txtwidthc.Text = IIf(IsDBNull(ds.Tables!Text.Rows(introw).Item("WidthC")), "", ds.Tables!Text.Rows(introw).Item("WidthC"))
        If Val(ds.Tables!Text.Rows(introw).Item("HeightC")) = 0 Then
            txtheightc.Text = ""
        Else
            txtheightc.Text = ds.Tables!Text.Rows(introw).Item("HeightC")
        End If
        'txtheightc.Text = IIf(IsDBNull(ds.Tables!Text.Rows(introw).Item("HeightC")), "", ds.Tables!Text.Rows(introw).Item("HeightC"))
        If Val(ds.Tables!Text.Rows(introw).Item("LengthM")) = 0 Then
            txtlengthm.Text = ""
        Else
            txtlengthm.Text = (ds.Tables!Text.Rows(introw).Item("LengthM"))
        End If
        'txtlengthm.Text = IIf(IsDBNull(ds.Tables!Text.Rows(introw).Item("LengthM")), "", ds.Tables!Text.Rows(introw).Item("LengthM"))
        If Val(ds.Tables!Text.Rows(introw).Item("WidthM")) = 0 Then
            txtwidthm.Text = ""
        Else
            txtwidthm.Text = ds.Tables!Text.Rows(introw).Item("WidthM")
        End If
        ' txtwidthm.Text = IIf(IsDBNull(ds.Tables!Text.Rows(introw).Item("WidthM")), "", ds.Tables!Text.Rows(introw).Item("WidthM"))
        If Val(ds.Tables!Text.Rows(introw).Item("HeightM")) = 0 Then
            txtheightm.Text = ""
        Else
            txtheightm.Text = ds.Tables!Text.Rows(introw).Item("HeightM")
        End If
        'txtheightm.Text = IIf(IsDBNull(ds.Tables!Text.Rows(introw).Item("HeightM")), "", ds.Tables!Text.Rows(introw).Item("HeightM"))FormatNumber(MaxSize1, 3, False)
        txtloadkg.Text = FormatNumber(IIf(IsDBNull(ds.Tables!Text.Rows(introw).Item("PayLoad")), "", ds.Tables!Text.Rows(introw).Item("PayLoad")), 2, , , False)
        If Val(txtloadkg.Text) = 0 Then txtloadkg.Text = ""
        txtloadlbs.Text = FormatNumber(IIf(IsDBNull(ds.Tables!Text.Rows(introw).Item("PayLoad") * 2.2045), "", ds.Tables!Text.Rows(introw).Item("PayLoad") * 2.2045), 2, , , False)
        If Val(txtloadlbs.Text) = 0 Then txtloadlbs.Text = ""
        txttotalsize.Text = FormatNumber(IIf(IsDBNull(ds.Tables!Text.Rows(introw).Item("TotalSize")), "", ds.Tables!Text.Rows(introw).Item("TotalSize")), 4, , , False)
        If Val(txttotalsize.Text) = 0 Then txttotalsize.Text = ""
        txttotalsizef.Text = FormatNumber(IIf(IsDBNull(ds.Tables!Text.Rows(introw).Item("TotalSizeF")), "", ds.Tables!Text.Rows(introw).Item("TotalSizeF")), 4, , , False)
        If Val(txttotalsizef.Text) = 0 Then txttotalsizef.Text = ""
    End Sub

    Private Sub FillDataSet()
        Dim strSQL As String
        strSQL = "select * from ContainerMaster"
        Dim da As New SDO.OleDbDataAdapter(strSQL, conn)
        If ds.Tables.CanRemove(ds.Tables("Text")) Then
            ds.Tables("Text").Rows.Clear()
            ds.Tables("Text").Columns.Clear()
        End If
        da.Fill(ds, "Text")
        da = Nothing
    End Sub

 
    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        Txtclear()
        addenable()
        str = "Add"
        ContainerDetails.Enabled = True
        txtcontname.Focus()
        BFlag = True
    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        'Txtclear()
        str = "Edit"
        editenable()
        ContainerDetails.Enabled = True
        txtcontname.Focus()
        BFlag = True
    End Sub

    Private Sub cmdDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDel.Click
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
                    MsgBox(Ex.Message)
                End Try
            Else
                MsgBox("Cannot delete the record. It is being used!", MsgBoxStyle.Critical, "Container Master")
                Exit Sub
            End If
        End If
    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
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
    End Sub

    Private Sub cmdRef_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRef.Click
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
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
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
                        cmdAdd.Focus()
                        BFlag = False
                        Call saveenable()
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
    End Sub

    Private Sub cmdFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFirst.Click
        If ds.Tables!Text.Rows.Count - 1 >= 0 Then
            introw = 0
            txtbind()
            cmdEdit.Enabled = True
            cmdDel.Enabled = True

        End If
    End Sub

    Private Sub cmdNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNext.Click
        If introw < ds.Tables!Text.Rows.Count - 1 Then
            introw = introw + 1
            txtbind()
        End If
        cmdEdit.Enabled = True
        cmdDel.Enabled = True

    End Sub

    Private Sub cmdPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrev.Click
        If introw > 0 Then
            introw = introw - 1
            txtbind()
        End If
        cmdEdit.Enabled = True
        cmdDel.Enabled = True

    End Sub

    Private Sub cmdLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLast.Click
        If ds.Tables!Text.Rows.Count - 1 >= 0 Then
            introw = ds.Tables!Text.Rows.Count - 1
            Call txtbind()
            cmdEdit.Enabled = True
            cmdDel.Enabled = True
        End If
    End Sub

    Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFind.Click
        DT = "ContainerMaster"
        FindStr = "Select ContainerNo,ContainerName,LengthF,WidthF,HeightF,LengthI,WidthI,HeightI,LengthC,WidthC,HeightC,LengthM,WidthM,HeightM,PayLoad,TotalSize,TotalSizeF FROM ContainerMaster ORDER BY ContainerName"
        title = "Container"
        frmSearch.ShowDialog()
        Me.ActivateMdiChild(frmSearch)
        frmSearch.Txtsearch.Focus()
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

    Private Sub txtheightm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtheightm.LostFocus
        Call totalsize()
    End Sub

    Private Sub cmdHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdHelp.Click
        'Process.Start(Application.StartupPath & "\Container Master.chm")
        Process.Start(CurDir() & "\HelpContainerStuff\Container Master.chm")
    End Sub

    Private Sub txtloadkg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtloadkg.KeyPress
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

    Private Sub cmdUpdate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmdUpdate.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmdAdd.Focus() : cmdUpdate_Click(Nothing, Nothing)
        Else
            Exit Sub
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
        ContainerDetails.Enabled = False
    End Sub

    Private Sub txtcontname_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcontname.LostFocus
        txtcontname.Text = Replace(txtcontname.Text, "'", "`")
    End Sub

    Private Sub txtheightm_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtheightm.ValueChanged

    End Sub

    Private Sub txtheightc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtheightc.LostFocus
        Call totalsize()
    End Sub

    Private Sub txtheightf_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtheightf.LostFocus
        Call totalsize()
    End Sub

    Private Sub txtheighti_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtheighti.LostFocus
        Call totalsize()
    End Sub

    Private Sub txtlengthc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtlengthc.LostFocus
        Call totalsize()
    End Sub

    Private Sub txtlengthf_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtlengthf.LostFocus
        Call totalsize()
    End Sub

    Private Sub txtlengthi_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtlengthi.LostFocus
        Call totalsize()
    End Sub

    Private Sub txtlengthm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtlengthm.LostFocus
        Call totalsize()
    End Sub

    Private Sub txtwidthc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtwidthc.LostFocus
        Call totalsize()
    End Sub

    Private Sub txtwidthf_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtwidthf.LostFocus
        Call totalsize()
    End Sub

    Private Sub txtwidthi_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtwidthi.LostFocus
        Call totalsize()
    End Sub

    Private Sub txtwidthm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtwidthm.LostFocus
        Call totalsize()
    End Sub
End Class





