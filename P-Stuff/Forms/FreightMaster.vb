
'Program Name: -    FreightMaster.vb
'Programmer Name: - Satwadhir B. Pawar Mob No. :- 9323974665
'Company Name:-     Hazel Infotech LTD. Mumbai
'Project Name: -    Sky Stuff Plus (Container Stuffing)
'Date: -            24 Dec 2K8 12.07 PM (Modified Time)

'Tips: - The code is debugging at that particular dimensions, quantity and sequence.
'        you are decide it the logic happen is correct to that way or its are some 
'        different way the understanding to at your best level is the correct logic 
'        of this particular code block.

'Description: - FreightMaster is the form which containing the fright information i.e.
'               Fright id country name fright name etc. this information is 
'               required for stuffing of goods.

#Region " Importing Object "

Imports SDO = System.Data.OleDb

#End Region

Public NotInheritable Class FreightMaster
    Inherits System.Windows.Forms.Form

#Region " Class Declaration "

    Private ds As New DataSet
    Private introw As Integer
    Dim da As New SDO.OleDbDataAdapter
    Dim i As Integer
    Dim str As String
    Dim BFlag As Boolean

#End Region

#Region " Routine Definition "

    Public Sub txtclear()
        txtfreightid.Text = ""
        txtfreight.Text = ""
        CmbCountry.SelectedIndex = 0
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
        FreightDetails.Enabled = False

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
        FreightDetails.Enabled = True

    End Sub

    Private Sub editenable()

        cmdAdd.Enabled = False
        cmdEdit.Enabled = False
        cmdDel.Enabled = False
        cmdRef.Enabled = True
        cmdUpdate.Enabled = True
        cmdExit.Enabled = True
        cmdFirst.Enabled = False
        cmdNext.Enabled = False
        cmdPrev.Enabled = False
        cmdLast.Enabled = False
        cmdFind.Enabled = False
        FreightDetails.Enabled = True

    End Sub

    Private Sub saveenable()

        cmdAdd.Enabled = True
        cmdEdit.Enabled = True
        cmdDel.Enabled = True
        cmdRef.Enabled = False
        cmdUpdate.Enabled = False
        cmdExit.Enabled = True
        cmdFirst.Enabled = True
        cmdNext.Enabled = True
        cmdPrev.Enabled = True
        cmdLast.Enabled = True
        cmdFind.Enabled = True
        FreightDetails.Enabled = False

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
        FreightDetails.Enabled = False

    End Sub

    Private Sub FreightMaster_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DoubleClick

        If ColDlgFM.ShowDialog Then
            Me.BackColor = ColDlgFM.Color
        End If

    End Sub

    Private Sub FreightMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        If e.KeyCode = Keys.Escape Then Close()

    End Sub

    Private Sub FreightMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            'Me.Top = 65 : Me.Left = 130

            Me.StartPosition = FormStartPosition.CenterScreen       'Starting form at center screen 

            BFlag = False
            Dim StrSQL As String
            FillDataSet()
            FreightDetails.Enabled = False
            lblfreightid.Visible = False
            txtfreightid.Visible = False

            StrSQL = "Select * From country order by country "
            da = New SDO.OleDbDataAdapter(StrSQL, conn)
            If ds.Tables.CanRemove(ds.Tables!Tabcountry) Then
                ds.Tables!Tabcountry.Clear()
                ds.Tables.Remove(ds.Tables!Tabcountry)
            End If
            da.Fill(ds, "Tabcountry")
            CmbCountry.Items.Clear()
            For i = 0 To ds.Tables("Tabcountry").Rows.Count - 1
                If Me.CmbCountry.Items.Contains(ds.Tables("Tabcountry").Rows(i).Item("country")) = False Then
                    Me.CmbCountry.Items.Add(Trim(ds.Tables("Tabcountry").Rows(i).Item("country")))
                End If
            Next
            If ds.Tables!Text.Rows.Count = 0 Then
                Call NoRecorddisplay()
                Call txtclear()
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
            MessageBox.Show("Error in FreightMaster_Load", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click

        txtclear()
        addenable()
        str = "Add"
        BFlag = True
        CmbCountry.Focus()

    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click

        editenable()
        str = "Edit"
        BFlag = True
        CmbCountry.Focus()

    End Sub

    Private Sub cmdDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDel.Click

        Dim comm As New SDO.OleDbCommand

        Try
            If MsgBox("Are you sure you want to delete this record?", MsgBoxStyle.YesNo + vbCritical, "Freight Master") = MsgBoxResult.Yes Then
                comm = New SDO.OleDbCommand("Delete from FreightSea where Freight=" & Val(txtfreight.Text), conn)
                If conn.State = ConnectionState.Closed Then conn.Open()
                Try
                    comm.ExecuteNonQuery()
                    FillDataSet()
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
                Catch Ex As Exception
                    MsgBox(Ex.Message)
                End Try

            End If

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MessageBox.Show("Error in cmdDel_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub FillDataSet()

        Dim strSql As String

        Try
            strSql = "Select * from FreightSea"
            Dim da As New SDO.OleDbDataAdapter(strSql, conn)
            If ds.Tables.CanRemove(ds.Tables("Text")) Then
                ds.Tables("Text").Rows.Clear()
                ds.Tables("Text").Columns.Clear()
            End If
            da.Fill(ds, "Text")
            da = Nothing
        Catch Ex As Exception
            MsgBox(Ex.Message)
            MessageBox.Show("Error in FillDataSet", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtbind()

        Try
            txtfreightid.Text = IIf(IsDBNull(ds.Tables!Text.Rows(introw).Item("FreightId")), "", ds.Tables!Text.Rows(introw).Item("FreightId"))
            txtfreight.Text = IIf(IsDBNull(ds.Tables!Text.Rows(introw).Item("Freight")), "", ds.Tables!Text.Rows(introw).Item("Freight"))
            CmbCountry.DropDownStyle = ComboBoxStyle.DropDown
            CmbCountry.Text = Trim(ds.Tables!Text.Rows(introw).Item("Country"))
        Catch Ex As Exception
            MsgBox(Ex.Message)
            MessageBox.Show("Error in txtbind", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click

        Dim strSQL As String
        Dim comm As SDO.OleDbCommand

        Try
            If Trim(txtfreight.Text) = "" Then
                MsgBox("Please enter Freight.", MsgBoxStyle.Exclamation, "Freight Master")
                addenable()
                txtfreight.Text = ""
                txtfreight.Focus()
                Exit Sub
            End If

            If str = "Add" Then
                str = "Select Max(FreightId) As FId from FreightSea"
                txtfreightid.Text = GenId(str)
                strSQL = ""
                strSQL = "Insert into FreightSea (FreightId,Freight,Country)"
                strSQL = strSQL & " values(" & Val(txtfreightid.Text) & " ," & Val(txtfreight.Text) & ", '" & Trim(CmbCountry.Text) & "')"
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
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                    Exit Sub
                End Try
            ElseIf str = "Edit" Then
                strSQL = "Update FreightSea set Freight=" & Val(txtfreight.Text) & ",Country=' " & Trim(CmbCountry.Text) & " ' where FreightId=" & Val(txtfreightid.Text)
                comm = New SDO.OleDbCommand(strSQL, conn)

                Try
                    If conn.State = ConnectionState.Closed Then conn.Open()
                    comm.ExecuteNonQuery()
                    FillDataSet()
                    txtbind()
                    conn.Close()
                    BFlag = False
                    saveenable()
                    cmdAdd.Focus()
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
            If MsgBox("Are you sure you want to refresh this record?", MsgBoxStyle.YesNo + vbInformation, "Freight Master") = MsgBoxResult.Yes Then
                If ds.Tables!Text.Rows.Count = 0 Then
                    Call txtclear()
                    Call NoRecorddisplay()
                    introw = 0
                    BFlag = False
                    cmdAdd.Focus()
                    Exit Sub
                ElseIf introw > 0 Or introw <= ds.Tables!Text.Rows.Count - 1 Then
                    refenable()
                    txtclear()
                    txtbind()
                    BFlag = False
                    cmdAdd.Focus()
                End If
            Else
                CmbCountry.Focus()
                Exit Sub
            End If
        Catch Ex As Exception
            MsgBox(Ex.Message)
            MessageBox.Show("Error in cmdRef_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click

        Dim strSQL As String
        Dim comm As SDO.OleDbCommand

        Try
            If BFlag = True Then
                If MsgBox("Do you want to save this record?", MsgBoxStyle.YesNo + vbExclamation, "Freight Master") = MsgBoxResult.Yes Then
                    If Trim(txtfreight.Text) = "" Then
                        MsgBox("Please enter Freight.", MsgBoxStyle.Exclamation, "Freight Master")
                        addenable()
                        txtfreight.Text = ""
                        txtfreight.Focus()
                        Exit Sub
                    End If
                    If str = "Add" Then
                        str = "Select Max(FreightId) As FId from FreightSea"
                        txtfreightid.Text = GenId(str)
                        strSQL = ""
                        strSQL = "Insert into FreightSea (FreightId,Freight,Country)"
                        strSQL = strSQL & " values(" & Val(txtfreightid.Text) & " ," & Val(txtfreight.Text) & ", '" & Trim(CmbCountry.Text) & "')"
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
                            Close()
                        Catch ex As Exception
                            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                            Exit Sub
                        End Try
                    ElseIf str = "Edit" Then
                        strSQL = "Update FreightSea set Freight=" & Val(txtfreight.Text) & ",Country=' " & Trim(CmbCountry.Text) & " ' where FreightId=" & Val(txtfreightid.Text)
                        comm = New SDO.OleDbCommand(strSQL, conn)
                        Try
                            If conn.State = ConnectionState.Closed Then conn.Open()
                            comm.ExecuteNonQuery()
                            FillDataSet()
                            txtbind()
                            conn.Close()
                            BFlag = False
                            saveenable()
                            cmdAdd.Focus()
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
            DT = "FreightSea"
            FindStr = "SELECT Country,Freight,FreightId FROM FreightSea ORDER BY Freight"
            title = "Freight"
            frmSearch.ShowDialog()
            frmSearch.Txtsearch.Focus()
            Me.ActivateMdiChild(frmSearch)
            frmSearch.Txtsearch.Focus()
        Catch ex As Exception
            MsgBox(ex.Message)
            MessageBox.Show("Error in cmdFind_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtfreight_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtfreight.KeyDown

        If e.KeyCode = Keys.Enter Then cmdUpdate.Focus()

    End Sub

    Private Sub CmbCountry_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbCountry.Click

        CmbCountry.DropDownStyle = ComboBoxStyle.DropDownList

    End Sub

    Private Sub CmbCountry_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbCountry.KeyDown

        CmbCountry.DropDownStyle = ComboBoxStyle.DropDownList
        If e.KeyCode = Keys.Enter Then txtfreight.Focus()

    End Sub

    Private Sub txtfreight_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtfreight.KeyPress

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

    Private Sub cmdHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdHelp.Click

        Try
            Process.Start(CurDir() & "\HelpContainerStuff\Freight Master.chm")
        Catch Ex As Exception
            MsgBox(Ex.Message)
            MessageBox.Show("Error in cmdHelp_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

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
        FreightDetails.Enabled = False

    End Sub

    Private Sub txtfreight_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtfreight.LostFocus

        txtfreight.Text = Replace(txtfreight.Text, "'", "`")

    End Sub

#End Region

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

End Class