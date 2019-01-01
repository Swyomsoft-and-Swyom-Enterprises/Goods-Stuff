
'Program Name: -    InwardEntry.vb
'Programmer Name: - Satwadhir B. Pawar Mob No. :- 9323974665
'Company Name:-     Hazel Infotech LTD. Mumbai
'Project Name: -    Sky Stuff Plus (Container Stuffing)
'Date: -            23 Dec 2K8 2.17 PM (Modified Time)

'Tips: - The code is debugging at that particular dimensions, quantity and sequence.
'        you are decide it the logic happen is correct to that way or its are some 
'        different way the understanding to at your best level is the correct logic 
'        of this particular code block.

'Description: - InwardEntry is the form to containing the inward entry of the data.

#Region " Importing Object "

Imports sdo = System.Data.OleDb

#End Region

Public NotInheritable Class InwardEntry
    Inherits System.Windows.Forms.Form

#Region " Class Declaration "

    Dim browser As String = "cosmo"
    Private ds As New DataSet
    Private introw As Integer
    Dim da As OleDb.OleDbDataAdapter
    Dim itmnm1 As String
    Dim i As Integer
    Dim str As String
    Dim rwidx As Integer
    Dim contarr(2) As Double
    Dim arc As New Area
    Dim stk1 As New List(Of Area)
    Dim itmnm As String
    Dim stkmm As New List(Of Area)
    Dim totvol As Double
    Dim eflag As Boolean = False
    Public colval As String = "r"
    Public colarr As New List(Of List(Of Byte))
    Dim cnt As Integer = 0
    Dim showemp As Boolean
    Dim lstx As New List(Of List(Of List(Of Object)))

    Dim app As Object
    Dim appx As Object

#End Region

#Region " Routine Definition "

    Private Sub txtclear()

        txtreceiptno.Text = ""
        cmbcontainer.Text = ""

    End Sub

    Public Sub loadenable()

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

    Public Sub addenable()

        cmdAdd.Enabled = False
        cmdEdit.Enabled = False
        cmdDel.Enabled = False
        cmdUpdate.Enabled = True
        cmdRef.Enabled = False
        cmdExit.Enabled = True
        cmdFirst.Enabled = False
        cmdNext.Enabled = False
        cmdPrev.Enabled = False
        cmdLast.Enabled = False
        cmdFind.Enabled = False

        Dim cmd As New OleDb.OleDbCommand
        Dim rdr As OleDb.OleDbDataReader

        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            cmd.Connection = conn
            cmd.CommandText = "select max(receiptno) from Ninwarddetail"
            rdr = cmd.ExecuteReader
            If rdr.Read() Then
                If IsDBNull(rdr(0)) Then
                    txtreceiptno.Text = "1"
                Else
                    txtreceiptno.Text = rdr(0) + 1
                End If

            Else
                txtreceiptno.Text = "1"
            End If

            Do While DataGridView1.RowCount > 1
                DataGridView1.Rows.Remove(DataGridView1.Rows(DataGridView1.RowCount - 2))
            Loop

        Catch Exr As Exception
            MsgBox(Exr.Message)
            MsgBox(Exr.ToString)
            MessageBox.Show("Error in addenable", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub editenable()

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

    End Sub

    Public Sub saveenable()

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

    Public Sub refenable()

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

    Private Sub filldataset()

        Dim strSQL As String
        Try
            strSQL = "select * from InwardDetail"
            Dim da As New sdo.OleDbDataAdapter(strSQL, conn)
            If ds.Tables.CanRemove(ds.Tables("Text")) Then
                ds.Tables("Text").Rows.Clear()
                ds.Tables("Text").Rows.Clear()
            End If
            da.Fill(ds, "Text")
            da = Nothing
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in filldataset", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtbind()

        Try
            txtreceiptno.Text = IIf(IsDBNull(ds.Tables!Text.Rows(introw).Item("ReceiptNo")), "", ds.Tables!Text.Rows(introw).Item("ReceiptNo"))
            cmbcontainer.Text = IIf(IsDBNull(ds.Tables!Text.Rows(introw).Item("ContainerName")), "", ds.Tables!Text.Rows(introw).Item("ContainerName"))
        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in txtbind", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click

        DataGridView1.Enabled = False
        txtclear()
        addenable()
        str = "Add"

        cmbcontainer.Focus()
        cmdRef.Enabled = True

    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click

        editenable()
        str = "Edit"

        cmbcontainer.Focus()

    End Sub

    Private Sub cmdDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDel.Click

        Dim comm As New sdo.OleDbCommand

        Try
            If MsgBox("Are you sure you want to delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Critical, "Confirmation") = MsgBoxResult.Yes Then
                If conn.State = ConnectionState.Closed Then conn.Open()
                comm = New sdo.OleDbCommand("Delete from NInwardDetail where ReceiptNo=" & Val(txtreceiptno.Text), conn)

                Try
                    comm.ExecuteNonQuery()
                    cnt -= 1
                    Call InwardEntry_Load(Nothing, Nothing)

                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical + vbOKOnly)
                End Try
            End If

        Catch Ez As Exception
            MsgBox(Ez.Message)
            MsgBox(Ez.ToString)
            MessageBox.Show("Error in cmdDel_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click

        Dim strSQL As String
        Dim comm As New sdo.OleDbCommand
        Dim maxqty1 As Integer
        Dim qty1 As Integer

        Try
            For i As Integer = 0 To DataGridView1.RowCount - 1
                If TypeOf (DataGridView1.Item(10, i).Value) Is DBNull Then
                    MsgBox("Invalid quantity at row " & (i + 1).ToString, MsgBoxStyle.Critical + vbOKOnly)
                    Exit Sub
                Else
                    If Not IsNumeric(DataGridView1.Item(10, i).Value) Then
                        MsgBox("Invalid quantity at row " & (i + 1).ToString, MsgBoxStyle.Critical + vbOKOnly)
                        Exit Sub

                    End If
                End If
            Next
            If cmbcontainer.Text = "" Then
                MsgBox("Enter Container Name", MsgBoxStyle.Critical + vbOKOnly)
                addenable()
                cmbcontainer.Focus()
                Exit Sub
            End If
            If conn.State = ConnectionState.Closed Then conn.Open()
            If str = "Add" Then
                For i As Integer = 0 To DataGridView1.RowCount - 2

                    maxqty1 = DataGridView1.Item(9, i).Value
                    qty1 = DataGridView1.Item(10, i).Value
                    strSQL = "insert into Ninwarddetail values(" & txtreceiptno.Text & ",#" & DateTimePicker1.Value & "#,'" & cmbcontainer.Text & "'," & _
                    DataGridView1.Item(0, i).Value & ",'" & DataGridView1.Item(1, i).Value & "','" & DataGridView1.Item(2, i).Value & "'," & DataGridView1.Item(3, i).Value & "," & _
                    DataGridView1.Item(4, i).Value & "," & DataGridView1.Item(5, i).Value & "," & DataGridView1.Item(6, i).Value & "," & DataGridView1.Item(7, i).Value & "," & DataGridView1.Item(8, i).Value & _
                    "," & maxqty1 & "," & qty1 & ")"
                    comm.Connection = conn
                    comm.CommandText = strSQL
                    comm.ExecuteNonQuery()

                Next

            End If

            If str = "Edit" Then
                strSQL = "delete from NInwardDetail where receiptno = " & txtreceiptno.Text
                comm.Connection = conn
                comm.CommandText = strSQL
                comm.ExecuteNonQuery()
                str = "Add"
                Call cmdUpdate_Click(Nothing, Nothing)

            End If

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

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in cmdUpdate_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdRef_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRef.Click

        Try
            refenable()
            txtclear()
            filldataset()
            If introw > 0 Or ds.Tables!Text.Rows.Count = -1 Then
                introw = introw
                txtbind()
            End If
            Do While Not DataGridView1.RowCount = 0
                Try
                    DataGridView1.Rows.Remove(DataGridView1.Rows(0))
                Catch ee As Exception
                    If ee.Message = "Uncommitted new row cannot be deleted." Then
                        DataGridView1.Enabled = False
                        DataGridView1.Enabled = False
                        cmdAdd.Enabled = True
                        cmdDel.Enabled = False
                        cmdEdit.Enabled = False
                        cmdFirst.Enabled = False
                        cmdLast.Enabled = False
                        cmdExit.Enabled = True
                        cmdNext.Enabled = False
                        cmdPrev.Enabled = False
                        cmdAdd.Focus()
                        Exit Sub
                    End If
                End Try

            Loop
            DataGridView1.Enabled = False
            cmdAdd.Enabled = True
            cmdDel.Enabled = False
            cmdEdit.Enabled = False
            cmdFirst.Enabled = False
            cmdLast.Enabled = False
            cmdExit.Enabled = True
            cmdNext.Enabled = False
            cmdPrev.Enabled = False
            cmdAdd.Focus()
        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in cmdRef_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click

        Me.Dispose(True)
        Me.Close()

    End Sub

    Private Sub cmdFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFirst.Click

        Dim lstd As New List(Of List(Of Object))
        Dim lste As New List(Of Object)

        Try
            Do While DataGridView1.RowCount > 1
                DataGridView1.Rows.Remove(DataGridView1.Rows(DataGridView1.RowCount - 2))
            Loop
            cnt = 0
            lstd = lstx(cnt)
            lste = lstd(0)
            txtreceiptno.Text = lste(0)
            DateTimePicker1.Value = lste(1)
            cmbcontainer.Text = lste(2)

            For i As Integer = 0 To lstd.Count - 1
                Try
                    lste = lstd(i)
                    '            If DataGridView1.RowCount <> 0 Then
                    DataGridView1.Rows.Add()
                    'End If
                    DataGridView1.Item(0, i).Value = lste(3)
                    DataGridView1.Item(1, i).Value = lste(4)
                    DataGridView1.Item(2, i).Value = lste(5)
                    DataGridView1.Item(3, i).Value = lste(6)
                    DataGridView1.Item(4, i).Value = lste(7)
                    DataGridView1.Item(5, i).Value = lste(8)
                    DataGridView1.Item(6, i).Value = lste(9)
                    DataGridView1.Item(7, i).Value = lste(10)
                    DataGridView1.Item(8, i).Value = lste(11)
                    DataGridView1.Item(9, i).Value = lste(12)
                    DataGridView1.Item(10, i).Value = lste(13)
                Catch

                End Try
            Next

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in cmdFirst_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNext.Click

        cnt += 1
        Try
            If cnt < lstx.Count Then
                Do While DataGridView1.RowCount > 1
                    DataGridView1.Rows.Remove(DataGridView1.Rows(DataGridView1.RowCount - 2))
                Loop
                Dim lstd As New List(Of List(Of Object))
                Dim lste As New List(Of Object)

                lstd = lstx(cnt)
                lste = lstd(0)
                txtreceiptno.Text = lste(0)
                DateTimePicker1.Value = lste(1)
                cmbcontainer.Text = lste(2)
                For i As Integer = 0 To lstd.Count - 1
                    Try
                        lste = lstd(i)

                        DataGridView1.Rows.Add()

                        DataGridView1.Item(0, i).Value = lste(3)
                        DataGridView1.Item(1, i).Value = lste(4)
                        DataGridView1.Item(2, i).Value = lste(5)
                        DataGridView1.Item(3, i).Value = lste(6)
                        DataGridView1.Item(4, i).Value = lste(7)
                        DataGridView1.Item(5, i).Value = lste(8)
                        DataGridView1.Item(6, i).Value = lste(9)
                        DataGridView1.Item(7, i).Value = lste(10)
                        DataGridView1.Item(8, i).Value = lste(11)
                        DataGridView1.Item(9, i).Value = lste(12)
                        DataGridView1.Item(10, i).Value = lste(13)
                    Catch

                    End Try
                Next
            Else
                cnt -= 1

            End If

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in cmdNext_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrev.Click

        cnt -= 1

        Try
            If cnt >= 0 Then
                Do While DataGridView1.RowCount > 1
                    DataGridView1.Rows.Remove(DataGridView1.Rows(DataGridView1.RowCount - 2))
                Loop
                Dim lstd As New List(Of List(Of Object))
                Dim lste As New List(Of Object)

                lstd = lstx(cnt)
                lste = lstd(0)
                txtreceiptno.Text = lste(0)
                DateTimePicker1.Value = lste(1)
                cmbcontainer.Text = lste(2)
                For i As Integer = 0 To lstd.Count - 1
                    Try
                        lste = lstd(i)

                        DataGridView1.Rows.Add()

                        DataGridView1.Item(0, i).Value = lste(3)
                        DataGridView1.Item(1, i).Value = lste(4)
                        DataGridView1.Item(2, i).Value = lste(5)
                        DataGridView1.Item(3, i).Value = lste(6)
                        DataGridView1.Item(4, i).Value = lste(7)
                        DataGridView1.Item(5, i).Value = lste(8)
                        DataGridView1.Item(6, i).Value = lste(9)
                        DataGridView1.Item(7, i).Value = lste(10)
                        DataGridView1.Item(8, i).Value = lste(11)
                        DataGridView1.Item(9, i).Value = lste(12)
                        DataGridView1.Item(10, i).Value = lste(13)
                    Catch

                    End Try
                Next
            Else
                cnt += 1

            End If

        Catch er As Exception
            MsgBox(er.Message)
            MsgBox(er.ToString)
            MessageBox.Show("Error in cmdPrev_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLast.Click

        Dim cmd As New OleDb.OleDbCommand
        Dim rdr As OleDb.OleDbDataReader

        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            cmd.Connection = conn
            cmd.CommandText = "select * from NInwardDetail"
            rdr = cmd.ExecuteReader
            cnt = lstx.Count - 1

            Do While DataGridView1.RowCount > 1
                DataGridView1.Rows.Remove(DataGridView1.Rows(DataGridView1.RowCount - 2))
            Loop
            Dim lstd As New List(Of List(Of Object))
            Dim lste As New List(Of Object)

            lstd = lstx(cnt)
            lste = lstd(0)
            txtreceiptno.Text = lste(0)
            DateTimePicker1.Value = lste(1)
            cmbcontainer.Text = lste(2)

            For i As Integer = 0 To lstd.Count - 1
                Try
                    lste = lstd(i)

                    DataGridView1.Rows.Add()

                    DataGridView1.Item(0, i).Value = lste(3)
                    DataGridView1.Item(1, i).Value = lste(4)
                    DataGridView1.Item(2, i).Value = lste(5)
                    DataGridView1.Item(3, i).Value = lste(6)
                    DataGridView1.Item(4, i).Value = lste(7)
                    DataGridView1.Item(5, i).Value = lste(8)
                    DataGridView1.Item(6, i).Value = lste(9)
                    DataGridView1.Item(7, i).Value = lste(10)
                    DataGridView1.Item(8, i).Value = lste(11)
                    DataGridView1.Item(9, i).Value = lste(12)
                    DataGridView1.Item(10, i).Value = lste(13)
                Catch

                End Try
            Next

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in ", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFind.Click

        DT = "InwardHead"
        FindStr = "select    "

    End Sub

    Private Sub DataGridView1_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        Dim ans As MsgBoxResult

        rwidx = e.RowIndex
        Dim rowno1 As Integer = rwidx

        Try
            If e.ColumnIndex = 13 Then
                'If itemstuffed(DataGridView1.Item(1, rowno1).Value, sender, e) Then
                '    strtword(app)

                '    Dim lst As contret
                '    lst = generatecontainer(app, DateTimePicker1.Value.ToString, txtreceiptno.Text)

                '    generate(app.Documents.Item(1), DataGridView1.Item(1, rowno1).Value, lst, DataGridView1.Item(0, rowno1).Value)
                '    Exit Sub
                'Else
                '    Exit Sub

                'End If
            End If

            If e.ColumnIndex = 11 Or e.ColumnIndex = 12 Or e.ColumnIndex = 13 Then

                If DataGridView1.Item(1, rowno1).Value Is Nothing _
            OrElse DataGridView1.Item(10, rowno1).Value Is Nothing _
            OrElse Not IsNumeric(DataGridView1.Item(10, rowno1).Value) _
            OrElse CInt(DataGridView1.Item(10, rowno1).Value) <= 0 _
            OrElse DataGridView1.Item(10, rowno1).Value.ToString.Contains(".") _
            Then
                    If e.ColumnIndex <> 13 Then
                        MsgBox("Cannot show this item." & ControlChars.CrLf & "Item name not selected or quantity is invalid", MsgBoxStyle.Critical + vbOKOnly)
                        Exit Sub
                    End If

                End If

                If e.ColumnIndex <> 13 Then

                    ans = MsgBoxResult.Yes
                    If ans = MsgBoxResult.Yes Then
                        For i As Integer = 0 To DataGridView1.RowCount - 1
                            If DataGridView1.Item(1, i).Value Is Nothing _
                            OrElse DataGridView1.Item(8, i).Value Is Nothing _
                            OrElse DataGridView1.Item(10, i).Value Is Nothing _
                            OrElse Not IsNumeric(DataGridView1.Item(8, i).Value) _
                            OrElse Not IsNumeric(DataGridView1.Item(10, i).Value) _
                            OrElse CInt(DataGridView1.Item(8, i).Value) < 0 _
                            OrElse CInt(DataGridView1.Item(10, i).Value) <= 0 _
                            OrElse DataGridView1.Item(10, i).Value.ToString.Contains(".") _
                            OrElse DataGridView1.Item(10, i).Value.ToString.Contains(".") _
                            Then
                                Try
                                    DataGridView1.Rows.Remove(DataGridView1.Rows(i))
                                Catch
                                    Exit For
                                End Try
                                i -= 1
                                If i < rowno1 Then

                                End If
                            End If
                        Next
                    Else
                        Exit Sub
                    End If
                End If

                If cmbcontainer.Text = "" Then
                    MsgBox("Container not selected", MsgBoxStyle.Critical + vbOKOnly)
                    cmbcontainer.Focus()
                    Exit Sub
                End If

                Dim stk1 As New List(Of Area)
                Dim stk2 As New List(Of Area)

                Dim qtyf As Boolean = False
                Dim rowlvflg As Boolean = False
                Dim stp As Integer
                Dim cntm As Integer = 1
                Dim totqty = 25
                Dim totqty1 As Integer = 0
                Dim drwstp As Integer

                Dim cntflg As Boolean = False

                Dim flg1 As Boolean = True

                Dim button1flag As Boolean = False
                Dim itmnm As String

                button1flag = True
                Dim cnt As Integer = 0
                Dim dupflg As Boolean = False

                cnt = 0

                Dim ar() As Area

                Dim ari() As String
                Dim arwt() As Single
                Dim ar1 As New Area
                Dim ln As Double
                Dim wd As Double
                Dim ht As Double
                Dim qty As Integer
                Dim seq As Integer
                Dim wt As String
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

                Dim cntx As Integer = 0

                Dim plcqty As Integer = 0

                Dim k As Integer
                Dim m As Integer

                Dim r As Byte
                Dim g As Byte
                Dim b As Byte

                deltab("temp1")

                If cmbcontainer.Text = "" Then
                    MsgBox("Container not selected", MsgBoxStyle.Critical + vbOKOnly)
                    cmbcontainer.Focus()
                    Exit Sub
                End If

                Dim i1, j1 As Integer
                Dim extflg As Boolean = False
                Bplclst.Clear()
                Bqtylst.Clear()
                Dim col As System.Drawing.Color
                Dim zz As Integer
                For i1 = 0 To rowno1

                    itmnm = DataGridView1.Item(1, i1).Value
                    ln = DataGridView1.Item(4, i1).Value
                    wd = DataGridView1.Item(5, i1).Value
                    ht = DataGridView1.Item(6, i1).Value
                    qty = DataGridView1.Item(10, i1).Value

                    zz = System.Drawing.ColorTranslator.ToWin32(col)
                    r = col.R
                    g = col.G
                    b = col.B
                    r = System.Drawing.ColorTranslator.FromWin32(RGB(r, g, b)).R
                    g = System.Drawing.ColorTranslator.FromWin32(RGB(r, g, b)).G
                    b = System.Drawing.ColorTranslator.FromWin32(RGB(r, g, b)).B

                    wt = 1
                    seq = DataGridView1.Item(0, i1).Value
                    transp = False
                    tpup = IIf(DataGridView1.Item(7, i1).Value = "6", False, True)
                    Bqtylst.Add(qty)

                    For j1 = 0 To qty - 1
                        totqty1 += 1

                        instab("temp1", New Object() {itmnm, CStr(ln), CStr(wd), CStr(ht), CStr(qty), CStr(wt), CStr(seq), CStr(transp), CStr(tpup)})

                    Next

                Next i1

                Bplclstf.Clear()
                For i As Integer = 0 To Bplclst.Count - 1
                    Bplclstf.Add(Bplclst(i) + 1)
                Next

                For m = 0 To Bplclstf.Count - 1
                    If Bplclstf(m) = 0 Then
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

                totqty = 0
                For i As Integer = 0 To Bqtylst.Count - 1
                    totqty = totqty + Bqtylst(i)
                Next

                plcqty = 0
                For i As Integer = 0 To Bplclstf.Count - 1
                    plcqty = plcqty + Bplclstf(i)
                Next

                Dim rdr1 As DataRow()
                rdr1 = getf("temp1", "", "seq ASC")

                For i As Integer = 1 To rdr1.Length - 1
                    qtyf = True

                    itmnm = rdr1(i)("itmnm")
                    ln = rdr1(i)("ln")
                    wd = rdr1(i)("wd")
                    ht = rdr1(i)("ht")
                    qty = rdr1(i)("qty")
                    wt = rdr1(i)("wt")
                    transp = rdr1(i)("transp")
                    tpup = rdr1(i)("tpup")
                    seq = rdr1(i)("seq")

                    ar1.length = ln
                    ar1.width = wd
                    ar1.height = ht
                    ar1.StrtPt.x = 0
                    ar1.StrtPt.y = 0
                    ar1.StrtPt.z = 0

                    ar(UBound(ar)) = New Area
                    ar(UBound(ar)).length = ar1.length
                    ar(UBound(ar)).width = ar1.width
                    ar(UBound(ar)).height = ar1.height
                    ari(UBound(ari)) = itmnm
                    arwt(UBound(arwt)) = wt
                    transparr(UBound(transparr)) = transp
                    topup(UBound(topup)) = tpup
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
                stp += 1

                Dim ar2() As Area
                Dim ari2() As String
                Dim arwt2() As Single
                Dim transparr2() As Boolean

                ReDim ar2(0)
                ReDim ari2(0)
                ReDim arwt2(0)
                ReDim transparr2(0)

                For i As Integer = 0 To totqty - 1
                    ar2(UBound(ar2)) = ar(i)
                    ari2(UBound(ari2)) = ari(i)
                    arwt2(UBound(arwt2)) = arwt(i)
                    transparr2(UBound(transparr2)) = transparr(i)

                    ReDim Preserve ar2(UBound(ar2) + 1)
                    ReDim Preserve ari2(UBound(ari2) + 1)
                    ReDim Preserve arwt2(UBound(arwt2) + 1)
                    ReDim Preserve transparr2(UBound(transparr2) + 1)
                    ReDim Preserve topup(UBound(topup) + 1)
                Next

                ReDim Preserve ar2(UBound(ar2) - 1)
                ReDim Preserve ari2(UBound(ari2) - 1)
                ReDim Preserve arwt2(UBound(arwt2) - 1)
                ReDim Preserve transparr2(UBound(transparr2) - 1)
                ReDim Preserve topup(UBound(topup) - 1)

                If stp = DataGridView1.RowCount Then
                    stp = 0
                    cnt = 0
                End If

                arc.StrtPt.x = 0
                arc.StrtPt.y = 0
                arc.StrtPt.z = 0
                arc.length = contarr(0)
                arc.width = contarr(1)
                arc.height = contarr(2)
                qty = 0
                Dim outfile As String = CurDir() & "\first.wrl"
                If ar.Length > 0 Then

                    If stk.Count = 0 Then stk.Add(arc)
                    Bitemqty = 0
                    Bplclst.Clear()
                    Btxtopt = False
                    If e.ColumnIndex = 11 Then
                        stk2 = Stuffx(arc, ar2, ari2, arwt2, False, False, outfile, True, transparr2, topup, Btxtopt, True, False, True, colarr)
                        showemp = False
                    ElseIf e.ColumnIndex = 12 Then
                        '      stk2 = BoxStuff(arc, ar2, ari2, arwt2, False, False, outfile, True, transparr2, topup, Btxtopt, False, False, True, colarr)
                        showemp = True
                    End If

                    Dim are As Area
                    stkmm.Clear()
                    For rr As Integer = 0 To stk2.Count - 1
                        are = New Area
                        are.StrtPt.x = stk2(rr).StrtPt.x
                        are.StrtPt.y = stk2(rr).StrtPt.y
                        are.StrtPt.z = stk2(rr).StrtPt.z
                        are.length = stk2(rr).length
                        are.width = stk2(rr).width
                        are.height = stk2(rr).height
                        stkmm.Add(are)
                    Next
                    stk.Clear()
                    ReDim ar2(0)
                    ReDim ar2(0)
                    ReDim ari2(0)
                    ReDim arwt2(0)
                    ReDim transparr2(0)
                    ReDim topup(0)

                    For i As Integer = 0 To Bitemno

                        If CInt(DataGridView1.Item(10, i).Value) > Bplclst(i) + 1 Then
                            Dim qtyv As Integer
                            If Bplclst(i) <= 0 Then
                                qtyv = 0
                            Else
                                qtyv = Bplclst(i) + 1
                            End If
                            MsgBox(DataGridView1.Item(10, i).Value.ToString & " no of " & DataGridView1.Item(1, i).Value & " cannot be placed." & vbCrLf & CStr(qtyv) & " placed.", MsgBoxStyle.Information + vbOKOnly)
                            DataGridView1.Item(10, i).Value = qtyv
                            drwstp = drwstp - Bqtylst(i) + Bplclst(i) + 1
                            Bqtylst(i) = Bplclst(i) + 1

                        End If

                    Next

                    Bplclstf.Clear()
                    For i As Integer = 0 To Bplclst.Count - 1
                        Bplclstf.Add(Bplclst(i) + 1)
                    Next

                    k = 0
                    For m = 0 To Bplclstf.Count - 1
                        If Bplclstf(m) = 0 Then
                            k = m - 1
                            Exit For
                        End If
                    Next

                    If k = 0 Then
                        k = m - 1
                    End If

                    totqty = 0
                    For i As Integer = 0 To Bqtylst.Count - 1
                        totqty = totqty + Bqtylst(i)
                    Next

                    plcqty = 0
                    For i As Integer = 0 To Bplclstf.Count - 1
                        plcqty = plcqty + Bplclstf(i)
                    Next

                    Do While Not DataGridView2.RowCount = 0
                        Try
                            DataGridView2.Rows.Remove(DataGridView2.Rows(0))
                        Catch
                            Exit Do
                        End Try
                    Loop
                    Do While Not DataGridView3.RowCount = 0
                        Try
                            DataGridView3.Rows.Remove(DataGridView3.Rows(0))
                        Catch
                            Exit Do
                        End Try
                    Loop
                    Call Button3_Click(Nothing, Nothing)

                End If
                Dim dq As Char = Chr(34)
                Try

                    Process.Start("c:\Program Files\Alteros 3D\alteros.exe")
                Catch Ex As Exception

                    MsgBox(Ex.Message, MsgBoxStyle.Critical, "Exception :: In Event DataGridView_CellMouseClick " & vbCrLf & "VRML Programme Running Failure!")

                End Try
            End If

        Catch ERR As Exception
            MsgBox(ERR.Message)
            MsgBox(ERR.ToString)
            MessageBox.Show("Error in DataGridView1_CellMouseClick", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub DataGridView1_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged

        Dim totvol As Double = 0
        Dim totwt As Double = 0

        Try
            For i As Integer = 0 To DataGridView1.RowCount - 1
                totvol = totvol + (CDbl(DataGridView1.Item(3, i).Value) * CDbl(DataGridView1.Item(10, i).Value))
                totwt = totwt + CDbl(DataGridView1.Item(8, i).Value)
            Next
            TextBox3.Text = Format(totvol, "0.0000")
            TextBox4.Text = Format(totwt, "0.0000")
            TextBox5.Text = Format((arc.length * arc.width * arc.height * 0.000016387064) - totvol, "0.0000")
            If TextBox2.Text = "" Then TextBox2.Text = "0"
            TextBox6.Text = Format(CDbl(TextBox2.Text) - CDbl(TextBox4.Text), "0.0000")

        Catch er As Exception
            MsgBox(er.Message)
            MsgBox(er.ToString)
            MessageBox.Show("Error in DataGridView1_CellValueChanged", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub DataGridView1_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DataGridView1.DataError

        Exit Sub

    End Sub

    Private Sub DataGridView1_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DataGridView1.EditingControlShowing

        On Error Resume Next
        Dim combo As ComboBox
        Dim txtbx As TextBox


        If cmbcontainer.Text = "" Then
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

    Private Sub ComboBox_SelectedIndexChanged( _
      ByVal sender As Object, ByVal e As EventArgs)

        Dim comboBox1 As ComboBox = CType(sender, ComboBox)
        Dim tpup1 As Boolean

        Try
            If DataGridView1.CurrentCell.ColumnIndex = 1 Then
                itmnm = sender.text
                tpup1 = IIf(DataGridView1.Item(7, rwidx).Value = "6", False, True)
            Else
                itmnm = DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value
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
            rdr = cmd.ExecuteReader
            rdr.Read()
            Try
                lni = Val(Format((rdr("lengthi") + (12 * rdr("lengthf")) + (rdr("lengthc") / 2.54) + (rdr("lengthm") / 25.4)), "0.0000"))
            Catch
                Exit Sub
            End Try

            wdi = Val(Format((rdr("Widthi") + (12 * rdr("Widthf")) + (rdr("Widthc") / 2.54) + (rdr("Widthm") / 25.4)), "0.0000"))
            hti = Val(Format((rdr("heighti") + (12 * rdr("heightf")) + (rdr("heightc") / 2.54) + (rdr("heightm") / 25.4)), "0.0000"))
            DataGridView1.Item(1, rwidx).Value = itmnm
            DataGridView1.Item(4, rwidx).Value = lni
            DataGridView1.Item(5, rwidx).Value = wdi
            DataGridView1.Item(6, rwidx).Value = hti
            DataGridView1.Item(3, rwidx).Value = lni * wdi * hti * 0.000016387064
            DataGridView1.Item(2, rwidx).Value = rdr("packingmode")
            DataGridView1.Item(8, rwidx).Value = rdr("grossweight")
            Dim ans = MsgBox("Do you want to calculate maximum quantity?", MsgBoxStyle.YesNo)

            If ans = MsgBoxResult.Yes Then
                stk.Clear()
                stk.Add(arc)
                maxqty1 = CalcMxmQty(rwidx, tpup1)

            End If

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in ComboBox_SelectedIndexChanged", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim ar As New Area
        Dim x As Double
        Dim y As Double
        Dim z As Double
        Dim ln As Double
        Dim wd As Double
        Dim ht As Double
        Dim vol As Double
        Dim totvol1 As Double

        Dim lst As New List(Of String)

        Try
            totvol = 0
            If stkmm.Count = 0 And Bareaarr.Count = 0 Then
                If Not showemp Then
                    stkmm.Add(arc)
                Else
                    MsgBox("Container Is Fully Occupied. No Empty Area Left", MsgBoxStyle.Critical + vbOKOnly)
                    Exit Sub
                End If
            End If
            For i As Integer = 0 To stkmm.Count - 1
                ar = stkmm(i)
                If showemp Then
                    ar.AutoDraw(CurDir() & "\first.wrl", "r", 0, "", CStr(i + 1), 0, False, True, "E", 0, False, "b", "1")

                End If
                x = ar.StrtPt.x
                y = ar.StrtPt.y
                z = ar.StrtPt.z
                ln = ar.length
                wd = ar.width
                ht = ar.height
                vol = ln * wd * ht
                totvol = totvol + vol
                DataGridView2.Rows.Add(CStr(i + 1), CStr(x), CStr(y), CStr(z), CStr(ln), CStr(wd), CStr(ht), vol)
                If DataGridView2.RowCount = 0 Then
                    MsgBox("All rows deleted")
                End If
            Next

            If Bareaarr.Count > 0 Then
                lst = Bareaarr(0)

                totvol1 = 0
                For i As Integer = 0 To lst.Count - 1 Step 2
                    DataGridView3.Rows.Add(lst(i), lst(i + 1))
                    totvol1 = totvol1 + CDbl(lst(i + 1))
                Next
            End If
            DataGridView3.Rows.Add("Total Occupied", CStr(totvol1))
            DataGridView3.Rows.Add("Empty", CStr(totvol))
            Label9.Text = "Total occupied area(Cbm):" & Format((totvol1 * 0.000016387064), "0.0000") & " Total empty area(Cbm):" & Format((totvol * 0.000016387064), "0.0000")
        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in Button3_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Function CalcMxmQty(ByVal rowno1 As Integer, ByVal tpupx As Boolean)

        Dim ar() As Area
        Dim ari() As String
        Dim arwt() As Single
        Dim ar1 As New Area

        Dim ln As Double
        Dim wd As Double
        Dim ht As Double
        Dim qty As Integer
        Dim seq As Integer
        Dim itmnm1 As String
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

        Try

            deltab("temp1")

            If cmbcontainer.Text = "" Then
                MsgBox("Container not selected")
                cmbcontainer.Focus()
                Return Nothing
                Exit Function
            End If

            For i As Integer = 0 To rowno1 - 1
                If DataGridView1.Item(10, i).Value Is Nothing OrElse Not IsNumeric(DataGridView1.Item(10, i).Value) OrElse DataGridView1.Item(10, i).Value.ToString.Contains(".") OrElse CInt(DataGridView1.Item(10, i).Value) <= 0 Then
                    MsgBox("Invalid quantity at row " & CStr(i + 1))
                    Return Nothing
                    Exit Function
                End If

            Next

            For i As Integer = 0 To rowno1

                itmnm1 = DataGridView1.Item(1, i).Value
                ln = DataGridView1.Item(4, i).Value
                wd = DataGridView1.Item(5, i).Value
                ht = DataGridView1.Item(6, i).Value
                If i = rowno1 Then
                    qty = 0
                Else
                    qty = DataGridView1.Item(10, i).Value
                End If

                wt = 1
                seq = DataGridView1.Item(0, i).Value
                transp = False
                If rowno1 = 0 Then
                    tpup = tpupx
                Else
                    tpup = IIf(DataGridView1.Item(7, i).Value = "6", False, True)
                End If

                DataGridView1.Item(11, i).Value = ""

                instab("temp1", New Object() {itmnm1, CStr(ln), CStr(wd), CStr(ht), CStr(qty), CStr(wt), CStr(seq), CStr(transp), CStr(tpup)})

            Next i

            Dim rdr1 As DataRow()
            rdr1 = getf("temp1", "", "seq ASC")
            cnt = 0

            For i As Integer = 1 To rdr1.Length - 2

                itmnm1 = rdr1(i)("itmnm")
                ln = rdr1(i)("ln")
                wd = rdr1(i)("wd")
                ht = rdr1(i)("ht")
                qty = rdr1(i)("qty")
                wt = rdr1(i)("wt")
                transp = rdr1(i)("transp")
                tpup = rdr1(i)("tpup")
                seq = rdr1(i)("seq")
                Bqtylst.Add(qty)

                ar1.length = ln
                ar1.width = wd
                ar1.height = ht
                ar1.StrtPt.x = 0
                ar1.StrtPt.y = 0
                ar1.StrtPt.z = 0
                For j As Integer = 0 To qty
                    ar(UBound(ar)) = New Area
                    ar(UBound(ar)).length = ar1.length
                    ar(UBound(ar)).width = ar1.width
                    ar(UBound(ar)).height = ar1.height
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
            Next

            stpBox += 1

            If stpBox = DataGridView1.RowCount Then
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
            Dim outfile As String = CurDir() & "\first.wrl"
            If ar.Length > 0 Then

                If stk.Count = 0 Then stk.Add(arc)
                ' stk1 = BoxStuff(arc, ar, ari, arwt, False, False, outfile, False, transparr, topup, Btxtopt, False, False, True, colarr)

                Bplclst.Clear()

                ReDim ar(0)
                ReDim ari(0)
                ReDim arwt(0)
                ReDim transparr(0)
                ReDim topup(0)

                MsgBox(Bitemqty)

            Else
                If DataGridView1.RowCount > 1 Then
                    If ar.Length <> 0 Then
                        For i As Integer = 0 To DataGridView1.RowCount - 1
                            For j As Integer = 0 To DataGridView1.ColumnCount - 1
                                DataGridView1.Item(j, i).Style.BackColor = Color.White
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
                mm.length = DataGridView1.Item(4, rowno1).Value
                mm.width = DataGridView1.Item(5, rowno1).Value
                mm.height = DataGridView1.Item(6, rowno1).Value

                tpup = tpupx
            Else
                mm.length = DataGridView1.Item(4, 0).Value
                mm.width = DataGridView1.Item(5, 0).Value
                mm.height = DataGridView1.Item(6, 0).Value

                tpup = tpupx
                Bqtylst.Add(-1)
            End If

            vol1 = mm.length * mm.height * mm.width

            If vol1 <> 0 Then
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
                    ari(UBound(ari)) = itmnm
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

                '        Call BoxStuff(arc, ar, ari, arwt, False, False, "", False, Nothing, topup, False, False, False, True, colarr)

                ReDim ar(0)
                ReDim ari(0)
                ReDim arwt(0)
                ReDim transparr(0)
                ReDim topup(0)

                If CInt(DataGridView1.Item(10, DataGridView1.RowCount - 1).Value) > Bitemqty Then
                    MsgBox("Requested Quantity " & DataGridView1.Item(10, DataGridView1.RowCount - 2).Value & " is greater than maximum quatity")
                    DataGridView1.Item(10, DataGridView1.RowCount - 1).Value = Bitemqty
                End If

                DataGridView1.Item(9, rowno1).Value = Bitemqty

                Form8.Close()
                Bitemqty = 0
                stk.Clear()
                stk.Add(arc)
            Else

            End If

            Return Bitemqty
        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in CalcMxmQty", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            stk.Clear()
            stk.Add(arc)
        End Try

        Return Bitemqty

    End Function

    Private Sub InwardEntry_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        If e.KeyCode = Keys.Escape Then Close()

    End Sub

    Private Sub InwardEntry_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim cmd As New OleDb.OleDbCommand
        Dim cmd1 As New OleDb.OleDbCommand
        Dim cmd2 As New OleDb.OleDbCommand
        Dim rdr As OleDb.OleDbDataReader
        Dim adpt As New OleDb.OleDbDataAdapter
        Dim adpt1 As New OleDb.OleDbDataAdapter
        Dim tbl As New DataTable
        Dim tbl1 As New DataTable
        Dim cc As DataGridViewComboBoxColumn

        Dim rdr1 As OleDb.OleDbDataReader
        cmdUpdate.Enabled = False
        cmdRef.Enabled = False

        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            cmd.Connection = conn
            cmd.CommandText = "select distinct containername from containermaster"
            cmd1.Connection = conn
            cmd1.CommandText = "select distinct packname from packmast"
            cmd2.Connection = conn
            cmd2.CommandText = "select distinct packtype from packtype"
            rdr = cmd.ExecuteReader()
            adpt.SelectCommand = cmd1
            adpt.Fill(tbl)
            adpt1.SelectCommand = cmd2
            adpt1.Fill(tbl1)

            Do While rdr.Read

                cmbcontainer.Items.Add(rdr.Item(0))

            Loop

            rdr.Close()
            DataGridView1.AutoGenerateColumns = False

            cc = DataGridView1.Columns(1)
            cc.DataSource = tbl
            cc.DisplayMember = "packname"
            cc.ValueMember = "packname"

            Dim cmd3 As New OleDb.OleDbCommand
            Dim cmd4 As New OleDb.OleDbCommand
            Dim rno As Long
            Dim rdr2 As OleDb.OleDbDataReader
            cmd3.Connection = conn
            cmd4.Connection = conn
            cmd3.CommandText = "select distinct receiptno from NInwardDetail order by receiptno"
            rdr1 = cmd3.ExecuteReader

            lstx.Clear()

            Do While rdr1.Read

                rno = rdr1(0)
                cmd4.CommandText = "select * from NInwardDetail where receiptno=" & rno & " order by serialno"

                rdr2 = cmd4.ExecuteReader
                Dim lstv As New List(Of List(Of Object))

                Do While rdr2.Read
                    Dim lst1 As New List(Of Object)
                    For i As Integer = 0 To rdr2.FieldCount - 1
                        lst1.Add(rdr2(i))
                    Next
                    lstv.Add(lst1)
                Loop

                rdr2.Close()
                lstx.Add(lstv)

            Loop

            Dim lstd As New List(Of List(Of Object))
            Dim lste As New List(Of Object)
            If lstx.Count > 0 Then
                lstd = lstx(lstx.Count - 1)
                lste = lstd(0)
                txtreceiptno.Text = lste(0)
                DateTimePicker1.Value = lste(1)
                cmbcontainer.Text = lste(2)

                For i As Integer = 0 To lstd.Count - 1
                    Try
                        lste = lstd(i)

                        DataGridView1.Rows.Add()

                        DataGridView1.Item(0, i).Value = lste(3)
                        DataGridView1.Item(1, i).Value = lste(4)
                        DataGridView1.Item(2, i).Value = lste(5)
                        DataGridView1.Item(3, i).Value = lste(6)
                        DataGridView1.Item(4, i).Value = lste(7)
                        DataGridView1.Item(5, i).Value = lste(8)
                        DataGridView1.Item(6, i).Value = lste(9)
                        DataGridView1.Item(7, i).Value = lste(10)
                        DataGridView1.Item(8, i).Value = lste(11)
                        DataGridView1.Item(9, i).Value = lste(12)
                        DataGridView1.Item(10, i).Value = lste(13)
                    Catch

                    End Try
                Next
            Else
                cmdDel.Enabled = False
                cmdFirst.Enabled = False
                cmdLast.Enabled = False
                cmdAdd.Enabled = True
                cmdNext.Enabled = False
                cmdPrev.Enabled = False
                cmdEdit.Enabled = False
                cmdFind.Enabled = False
                DataGridView1.Enabled = False
                txtclear()

                Do While Not DataGridView1.RowCount = 0
                    Try
                        DataGridView1.Rows.Remove(DataGridView1.Rows(0))
                    Catch ee As Exception
                        If ee.Message = "Uncommitted new row cannot be deleted." Then
                            Exit Sub
                        End If
                    End Try
                Loop
            End If
        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in InwardEntry_Load", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub DataGridView1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DataGridView1.RowsAdded

        Dim clm As DataGridViewComboBoxCell

        Try
            clm = DataGridView1.Item(7, e.RowIndex)
            clm.Items.AddRange(New Object() {"6", "2"})
            clm.Value = "6"

            DataGridView1.Item(0, e.RowIndex).Value = e.RowIndex + 1
            DataGridView1.Item(3, e.RowIndex).Value = 0
            DataGridView1.Item(4, e.RowIndex).Value = 0
            DataGridView1.Item(5, e.RowIndex).Value = 0
            DataGridView1.Item(6, e.RowIndex).Value = 0
            DataGridView1.Item(9, e.RowIndex).Value = 0
            DataGridView1.Item(10, e.RowIndex).Value = 0

            Dim totvol As Double = 0
            Dim totwt As Double = 0
            For i As Integer = 0 To DataGridView1.RowCount - 1
                totvol = totvol + (CDbl(DataGridView1.Item(3, i).Value) * CDbl(DataGridView1.Item(10, i).Value))
                totwt = totwt + CDbl(DataGridView1.Item(8, i).Value)
            Next
            For i As Integer = 0 To DataGridView1.RowCount - 1

                DataGridView1.Item(0, i).Value = i + 1

            Next
            TextBox3.Text = Format(totvol, "0.0000")
            TextBox4.Text = Format(totwt, "0.0000")
            TextBox5.Text = Format((arc.length * arc.width * arc.height * 0.000016387064) - totvol, "0.0000")
            If TextBox2.Text = "" Then TextBox2.Text = "0"
            TextBox6.Text = Format(CDbl(TextBox2.Text) - CDbl(TextBox4.Text), "0.0000")
        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in DataGridView1_RowsAdded", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub DataGridView1_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DataGridView1.RowsRemoved

        Try
            For i As Integer = 0 To DataGridView1.RowCount - 1

                DataGridView1.Item(0, i).Value = i + 1

            Next

            For i As Integer = e.RowIndex To DataGridView1.RowCount - 1
                DataGridView1.Item(9, i).Value = "0"
                DataGridView1.Item(10, i).Value = "0"
            Next
        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in DataGridView1_RowsRemoved", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmbcontainer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcontainer.Click

        DataGridView1.Enabled = True

    End Sub

    Private Sub CmbContainer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbcontainer.SelectedIndexChanged

        Try
            Dim rdr As OleDb.OleDbDataReader
            Dim cmd As New OleDb.OleDbCommand
            cmd.Connection = conn

            Dim lni As Single
            Dim wdi As Single
            Dim hti As Single

            cmd.CommandText = "select lengthf,widthf,heightf,lengthi,widthi,heighti,lengthc,widthc,heightc,lengthm,widthm,heightm,payload from containermaster where containername ='" & cmbcontainer.Text & "'"
            rdr = cmd.ExecuteReader
            rdr.Read()

            Try

                lni = rdr("lengthi") + (12 * rdr("lengthf")) + (rdr("lengthc") / 2.54) + (rdr("lengthm") / 25.4)

            Catch Ex As Exception

                MsgBox(Ex.Message)
                MsgBox(Ex.ToString)
                MsgBox(Ex.Message, MsgBoxStyle.Critical, "Exception :: In Event 'cmbcontainer_SelectedindexChaged'" & vbCrLf & "Programme Running is failure!")

                Exit Sub

            End Try

            wdi = rdr("Widthi") + (12 * rdr("Widthf")) + (rdr("Widthc") / 2.54) + (rdr("Widthm") / 25.4)
            hti = rdr("heighti") + (12 * rdr("heightf")) + (rdr("heightc") / 2.54) + (rdr("heightm") / 25.4)

            Label5.Text = "Length=" & Format(lni, "0.00") & " Width=" & Format(wdi, "0.00") & " Height=" & Format(hti, "0.00")
            TextBox2.Text = Format(rdr("payload"), "0.0000")
            contcap = rdr("payload")
            contarr(0) = lni
            contarr(1) = wdi
            contarr(2) = hti
            arc.length = contarr(0)
            arc.width = contarr(1)
            arc.height = contarr(2)
            TextBox1.Text = Format((arc.length * arc.width * arc.height * 0.000016387064))
            stk.Clear()
            stk.Add(arc)
            rdr.Close()

        Catch er As Exception
            MsgBox(er.Message)
            MsgBox(er.ToString)
            MessageBox.Show("Error in CmbContainer_SelectedIndexChanged", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            stk.Clear()
            stk.Add(arc)

        End Try

    End Sub

    Private Sub DataGridView2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        Dim ar As New Area

        Dim doc As Object

        Try
            If e.ColumnIndex = 8 Then
                ar.StrtPt.x = DataGridView2.Item(1, e.RowIndex).Value
                ar.StrtPt.y = DataGridView2.Item(2, e.RowIndex).Value
                ar.StrtPt.z = DataGridView2.Item(3, e.RowIndex).Value
                ar.length = DataGridView2.Item(4, e.RowIndex).Value
                ar.width = DataGridView2.Item(5, e.RowIndex).Value
                ar.height = DataGridView2.Item(6, e.RowIndex).Value
                strtword(app)

                Dim lst As contret
                lst = generatecontainer(app, DateTimePicker1.Value.ToString, txtreceiptno.Text)
                doc = app.Documents.Add()
                doc.Shapes.AddShape(1, ar.StrtPt.x * lst.mulfac, ar.StrtPt.y * lst.mulfac, ar.length * lst.mulfac, ar.width * lst.mulfac).Select()
                app.Selection.ShapeRange.Fill.BackColor.RGB = RGB(0, 0, 255)
            End If

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in DataGridView2_CellContentClick", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

#End Region

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

End Class
