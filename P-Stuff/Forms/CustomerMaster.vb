
'Program Name: -    CustomerMaster.vb
'Programmer Name: - Satwadhir B. Pawar Mob No. :- 9323974665
'Company Name:-     Hazel Infotech LTD. Mumbai
'Project Name: -    P-Stuff Plus (Container Stuffing)
'Date: -            22 Dec 2K8 6.02 PM (Modified Time)

'Tips: - The code is debugging at that particular dimensions, quantity and sequence.
'        you are decide it the logic happen is correct to that way or its are some 
'        different way the understanding to at your best level is the correct logic 
'        of this particular code block.

'Description: - Customer information is stored to database so it’s used to further 
'               requirements of stuff activity

#Region " Importing Object "

Imports SDO = System.Data.OleDb

#End Region

Public NotInheritable Class CustomerMaster
    Inherits System.Windows.Forms.Form

#Region " Class Declarations "

    Private ds As New DataSet
    Dim Ds1 As New DataSet
    Private introw As Integer
    Dim str As String
    Dim N As Integer
    Dim da As SDO.OleDbDataAdapter
    Dim BFlag As Boolean

#End Region

#Region " Routine Definitions "

    Public Sub Txtclear()

        txtcustname.Text = ""
        txtcustcode.Text = ""
        txtadd.Text = ""
        CmbCountry.Text = ""
        CmbCountry.SelectedIndex = -1
        txtcity.Text = ""
        txttelno.Text = ""
        txtpincode.Text = ""
        txtmobileno.Text = ""
        txtState.Text = ""

    End Sub

    Private Sub frmloadenable()

        cmdAdd.Enabled = False
        cmdEdit.Enabled = False
        cmdDel.Enabled = False
        cmdUpdate.Enabled = True
        cmdRef.Enabled = True
        cmdExit.Enabled = False
        cmdFirst.Enabled = False
        cmdNext.Enabled = False
        cmdPrev.Enabled = False
        cmdLast.Enabled = False
        cmdFind.Enabled = False
        Group1.Enabled = False

    End Sub

    Private Sub frmaddenable()

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

    Private Sub frmsaveenable()

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

    Private Sub frmeditenable()

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

    Private Sub frmrefenable()

        cmdAdd.Enabled = True
        cmdEdit.Enabled = True
        cmdDel.Enabled = True
        cmdUpdate.Enabled = False
        cmdRef.Enabled = False
        cmdExit.Enabled = True
        cmdFirst.Enabled = True
        cmdNext.Enabled = True
        cmdLast.Enabled = True
        cmdPrev.Enabled = True
        cmdFind.Enabled = True
        Group1.Enabled = False

    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click

        Txtclear()
        frmaddenable()
        str = "Add"
        Group1.Enabled = True
        txtcustname.Focus()
        BFlag = True

    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click

        frmeditenable()
        str = "Edit"
        Group1.Enabled = True
        txtcustname.Focus()
        BFlag = True

    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDel.Click

        Dim Comm As New SDO.OleDbCommand

        Try
            If MsgBox("Are you sure you want to delete this Record?", MsgBoxStyle.YesNo + vbCritical, "Customer Master") = MsgBoxResult.Yes Then
                Comm = New SDO.OleDbCommand("Delete from CustomerMaster where CustomerCode=" & Val(txtcustcode.Text), conn)
                If conn.State = ConnectionState.Closed Then conn.Open()
                Try
                    Comm.ExecuteNonQuery()
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
            End If
        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in the cmdDel_Click ", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click

        Dim str1 As String
        Dim StrSQL As String
        Dim Comm As SDO.OleDbCommand

        Try
            If Trim(txtcustname.Text) = "" Then
                MsgBox("Please Enter Customer Name", MsgBoxStyle.Exclamation, "Customer Master")
                frmaddenable()
                txtcustname.Focus()
                Exit Sub
            End If
            If str = "Add" Then
                '---------------For Chenck Duplicate Record
                Dim strId As String
                strId = FCount("Select Count(CustomerName) as CustomerName1  from CustomerMaster where CustomerName='" & Trim(txtcustname.Text) & "'")
                If strId <> 0 Then
                    MsgBox("Dublicate entry", MsgBoxStyle.Exclamation, "Customer Master")
                    txtcustname.Focus()
                    Exit Sub
                End If
                '------------------
                str1 = "Select Max(CustomerCode) as CId from CustomerMaster"
                txtcustcode.Text = GenId(str1)
                StrSQL = "Insert into CustomerMaster(CustomerCode,CustomerName,Address1,City,Telno1,Telno2,Country,PinCode,State)"
                StrSQL = StrSQL & " values(" & Val(txtcustcode.Text) & ", '" & Replace(Trim(txtcustname.Text), "'", "`") & "', '" & Replace(Trim(txtadd.Text), "'", "`") & "',"
                StrSQL = StrSQL & " '" & Replace(Trim(txtcity.Text), "'", "`") & "', '" & txttelno.Text & "', '" & txtmobileno.Text & "', '" & CmbCountry.Text & "',"
                StrSQL = StrSQL & " '" & txtpincode.Text & "', '" & txtState.Text & "')"
                Comm = New SDO.OleDbCommand(StrSQL, conn)
                Try
                    If conn.State = ConnectionState.Closed Then conn.Open()
                    Comm.ExecuteNonQuery()
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
                StrSQL = "Update CustomerMaster set CustomerName='" & Replace(Trim(txtcustname.Text), "'", "`") & "', Address1='" & (txtadd.Text) & "', City='" & (txtcity.Text) & "',"
                StrSQL = StrSQL & " Telno1='" & txttelno.Text & "',Telno2= '" & txtmobileno.Text & "',Country='" & (CmbCountry.Text) & "',"
                StrSQL = StrSQL & " Pincode='" & txtpincode.Text & "',State='" & txtState.Text & "' where CustomerCode = " & Val(txtcustcode.Text) & ""
                Comm = New SDO.OleDbCommand(StrSQL, conn)
                Try
                    If conn.State = ConnectionState.Closed Then conn.Open()
                    Comm.ExecuteNonQuery()
                    FillDataSet()
                    txtbind()
                    conn.Close()
                    BFlag = False
                    saveenable()
                    Group1.Enabled = False
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

        Dim comm As New SDO.OleDbCommand 'delete

        Try
            If MsgBox("Are you sure you want to refresh this record?", MsgBoxStyle.YesNo + vbInformation, "Customer Master") = MsgBoxResult.Yes Then
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
                txtcustname.Focus()
                Exit Sub
            End If
        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in the cmdRef_Click ", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click

        Dim comm As SDO.OleDbCommand
        Dim StrSQL As String
        Dim Str1 As String

        Try
            If BFlag = True Then
                If MsgBox("Do you want to save this record?", MsgBoxStyle.YesNo + vbExclamation, "Customer Master") = MsgBoxResult.Yes Then
                    If Trim(txtcustname.Text) = "" Then
                        MsgBox("Please Enter Customer Name", MsgBoxStyle.Exclamation, "Customer Master")
                        frmaddenable()
                        txtcustname.Focus()
                        Exit Sub
                    End If
                    If str = "Add" Then
                        '---------Check Duplicate Record
                        Dim strId As String
                        strId = FCount("Select Count(CustomerName) as CustomerName1  from CustomerMaster where CustomerName='" & Trim(txtcustname.Text) & "'")
                        If strId <> 0 Then
                            MsgBox("Dublicate Customer name should not allow", MsgBoxStyle.Exclamation, "Customer Master")
                            txtcustname.Focus()
                            Exit Sub
                        End If
                        '---------------------
                        Str1 = "Select Max(CustomerCode) as CId from CustomerMaster"
                        txtcustcode.Text = GenId(Str1)
                        StrSQL = "Insert into CustomerMaster(CustomerCode,CustomerName,Address1,City,Telno1,Telno2,Country,PinCode)"
                        StrSQL = StrSQL & " values(" & Val(txtcustcode.Text) & ", '" & txtcustname.Text & "', '" & txtadd.Text & "',"
                        StrSQL = StrSQL & " '" & txtcity.Text & "', '" & txttelno.Text & "', '" & txtmobileno.Text & "', '" & CmbCountry.Text & "',"
                        StrSQL = StrSQL & " '" & txtpincode.Text & "')"
                        comm = New SDO.OleDbCommand(StrSQL, conn)
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
                        StrSQL = "Update CustomerMaster set CustomerName='" & txtcustname.Text & "', Address1='" & (txtadd.Text) & "', City='" & (txtcity.Text) & "',"
                        StrSQL = StrSQL & " Telno1='" & txttelno.Text & "',Telno2= '" & txtmobileno.Text & "',Country='" & (CmbCountry.Text) & "',"
                        StrSQL = StrSQL & " Pincode='" & txtpincode.Text & "' where CustomerCode = " & Val(txtcustcode.Text) & ""
                        comm = New SDO.OleDbCommand(StrSQL, conn)
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
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in the cmdFirst_Click ", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNext.Click

        Try
            If introw < ds.Tables!Text.Rows.Count - 1 Then
                introw = introw + 1
                Call txtbind()
            End If
            cmdEdit.Enabled = True
            cmdDel.Enabled = True
        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in the cmdNext_Click ", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrev.Click

        Try
            If introw > 0 Then
                introw = introw - 1
                Call txtbind()
            End If
            cmdEdit.Enabled = True
            cmdDel.Enabled = True
        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in the cmdPrev_Click ", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFind.Click

        Try
            DT = "CustomerMaster"
            FindStr = "SELECT CustomerCode,CustomerName,Address1,City,Telno1,Telno2,Country,PinCode FROM CustomerMaster ORDER BY CustomerName"
            title = "Customer"
            Me.ActivateMdiChild(frmSearch)
            frmSearch.ShowDialog()
            frmSearch.Txtsearch.Focus()
        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in the cmdFind_Click ", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtbind()

        Try
            txtcustcode.Text = IIf(IsDBNull(ds.Tables!Text.Rows(introw).Item("CustomerCode")), "", ds.Tables!Text.Rows(introw).Item("CustomerCode"))
            txtcustname.Text = IIf(IsDBNull(ds.Tables!Text.Rows(introw).Item("CustomerName")), "", ds.Tables!Text.Rows(introw).Item("CustomerName"))
            txtadd.Text = IIf(IsDBNull(ds.Tables!Text.Rows(introw).Item("Address1")), "", ds.Tables!Text.Rows(introw).Item("Address1"))
            txtcity.Text = IIf(IsDBNull(ds.Tables!Text.Rows(introw).Item("City")), "", ds.Tables!Text.Rows(introw).Item("City"))
            CmbCountry.Text = IIf(IsDBNull(ds.Tables!Text.Rows(introw).Item("Country")), "", ds.Tables!Text.Rows(introw).Item("Country"))
            txtpincode.Text = IIf(IsDBNull(ds.Tables!Text.Rows(introw).Item("PinCode")), "", ds.Tables!Text.Rows(introw).Item("PinCode"))
            txttelno.Text = IIf(IsDBNull(ds.Tables!Text.Rows(introw).Item("TelNo1")), "", ds.Tables!Text.Rows(introw).Item("TelNo1"))
            txtmobileno.Text = IIf(IsDBNull(ds.Tables!text.Rows(introw).Item("Telno2")), "", ds.Tables!Text.Rows(introw).Item("Telno2"))
            txtState.Text = IIf(IsDBNull(ds.Tables!Text.Rows(introw).Item("State")), "", ds.Tables!Text.Rows(introw).Item("State"))

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in the txtbind ", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub FillDataSet()

        Dim strSQL As String
        Try
            strSQL = "select * from CustomerMaster"
            Dim da As New SDO.OleDbDataAdapter(strSQL, conn)
            If ds.Tables.CanRemove(ds.Tables("Text")) = True Then
                ds.Tables("Text").Rows.Clear()
                ds.Tables("Text").Columns.Clear()
            End If
            da.Fill(ds, "text")
            da = Nothing

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in the FillDataSet ", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub CustomerMaster_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DoubleClick

        If ColDlgCM.ShowDialog Then
            Me.BackColor = ColDlgCM.Color
        End If

    End Sub

    Private Sub CustomerMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        If e.KeyCode = Keys.Escape Then Close()

    End Sub

    Private Sub CustomerMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            'Me.Top = 65 : Me.Left = 130
            Me.StartPosition = FormStartPosition.CenterScreen
            Me.KeyPreview = True
            BFlag = False
            customercode.Visible = False
            txtcustcode.Visible = False
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            FillDataSet()
            Call getAllCountry()
            If ds.Tables!Text.Rows.Count = 0 Then
                Call NoRecorddisplay()
                Exit Sub
            ElseIf ds.Tables!Text.Rows.Count - 1 >= 0 Then
                introw = ds.Tables!Text.Rows.Count - 1
                Call txtbind()
                Call loadenable()
            End If
            cmdAdd.Focus()

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in the CustomerMaster_Load ", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtcustname_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcustname.GotFocus

        txtcustname.Select(0, 50)

    End Sub

    Private Sub txtcustname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtcustname.KeyDown

        If e.KeyCode = Keys.Enter Then txtadd.Focus()

    End Sub

    Private Sub txtcity_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtcity.KeyDown

        If e.KeyCode = Keys.Enter Then CmbCountry.Focus()

    End Sub

    Private Sub CmbCountry_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbCountry.KeyDown

        If e.KeyCode = Keys.Enter Then txtpincode.Focus()

    End Sub

    Private Sub txtpincode_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpincode.GotFocus

        txtpincode.Select(0, 10)

    End Sub

    Private Sub txtpincode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtpincode.KeyDown

        If e.KeyCode = Keys.Enter Then txttelno.Focus()

    End Sub

    Private Sub txttelno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttelno.GotFocus

        txttelno.Select(0, 30)

    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txttelno.KeyDown

        If e.KeyCode = Keys.Enter Then txtmobileno.Focus()

    End Sub

    Private Sub txtmobileno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtmobileno.GotFocus

        txtmobileno.Select(0, 10)

    End Sub

    Private Sub txtmobileno_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtmobileno.KeyDown

        If e.KeyCode = Keys.Enter Then cmdUpdate.Focus()

    End Sub

    Private Sub txtcity_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcity.KeyPress

        Dim s As Integer
        s = Asc(e.KeyChar)
        Select Case s
            Case 48 To 57, 8, 13, 32
            Case 45
            Case 46
            Case Else
                s = 0
        End Select
        If s = 0 Then
            e.Handled = True
            e.Handled = False
        End If

    End Sub

    Private Sub txtmobileno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmobileno.KeyPress

        Dim s As Integer
        s = Asc(e.KeyChar)
        Select Case s
            Case 48 To 57, 8, 13, 32
            Case 45
            Case 46
            Case Else
                s = 0
        End Select
        If s = 0 Then
            e.Handled = True
        Else
            e.Handled = False
        End If

    End Sub

    Private Sub getAllCountry()

        Dim strSQL As String

        Try
            strSQL = "Select * From country order by country "
            If conn.State = ConnectionState.Closed Then conn.Open()
            da = New SDO.OleDbDataAdapter(strSQL, conn)
            If Ds1.Tables.CanRemove(Ds1.Tables("TabCust")) = True Then
                Ds1.Tables("TabCust").Rows.Clear()
                Ds1.Tables("TabCust").Columns.Clear()
            End If
            da.Fill(Ds1, "TabCust")
            For N = 0 To Ds1.Tables("TabCust").Rows.Count - 1
                If Me.CmbCountry.Items.Contains(Ds1.Tables("TabCust").Rows(N).Item("country")) = False Then
                    Me.CmbCountry.Items.Add(Ds1.Tables("TabCust").Rows(N).Item("country"))
                End If
            Next

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in getAllCountry", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdUpdate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmdUpdate.KeyDown

        Try
            If e.KeyCode = Keys.Enter Then
                cmdAdd.Focus() ': cmdUpdate_Click(Nothing, Nothing)
                'Else
                '    Exit Sub
            End If

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in cmdUpdate_KeyDown", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdHelp.Click

        Try

            Process.Start(CurDir() & "\HelpContainerStuff\Customer Master.chm")

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
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
        Group1.Enabled = False

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
        Group1.Enabled = False

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
        Group1.Enabled = False

    End Sub

    Private Sub txttelno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttelno.KeyPress

        Dim s As Integer
        s = Asc(e.KeyChar)
        Select Case s
            Case 48 To 57, 8, 13, 32
            Case 45
            Case 46
            Case Else
                s = 0
        End Select
        If s = 0 Then
            e.Handled = True
        Else
            e.Handled = False
        End If

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
        Group1.Enabled = False

    End Sub

    Private Sub txtpincode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpincode.KeyPress

        Dim s As Integer
        s = Asc(e.KeyChar)
        Select Case s
            Case 48 To 57, 8, 13, 32
            Case 45
            Case 46
            Case Else
                s = 0
        End Select
        If s = 0 Then
            e.Handled = True
        Else
            e.Handled = False
        End If

    End Sub

    Private Sub txtcustname_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcustname.LostFocus

        txtcustname.Text = Replace(txtcustname.Text, "'", "`")

    End Sub

    Private Sub txtcity_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcity.LostFocus

        txtcity.Text = Replace(txtcity.Text, "'", "`")

    End Sub

    Private Sub txtadd_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtadd.LostFocus

        txtadd.Text = Replace(txtadd.Text, "'", "`")

    End Sub

    Private Sub cmdLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdLast.Click

        Try
            If ds.Tables!Text.Rows.Count - 1 >= 0 Then
                introw = ds.Tables!Text.Rows.Count - 1
                Call txtbind()
                cmdEdit.Enabled = True
                cmdDel.Enabled = True
            End If

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in cmdLast_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

#End Region

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

End Class
