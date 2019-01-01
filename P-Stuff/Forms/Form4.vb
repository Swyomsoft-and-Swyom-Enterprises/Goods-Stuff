
'Program Name: -    Form4.vb (P-Stuff Container Stuffing Plus)
'Programmer Name: - Satwadhir B. Pawar Mob No. :- 9323974665
'Company Name:-     Hazel Infotech LTD. Mumbai
'Project Name: -    P-Stuff Plus (Container Stuffing)
'Date: -            24 Dec 2K8 10.33 AM (Modified Time)

'Tips: - The code is debugging at that particular dimensions, quantity and sequence.
'        you are decide it the logic happen is correct to that way or its are some 
'        different way the understanding to at your best level is the correct logic 
'        of this particular code block.

'Description: - Form4 is the P-Container Stuffing plus form which is done the stuffing
'               activity of goods geometry.this is various routine and functions which includes 
'               the manipulation of geometry stuffing plans to generate the VRML program of stuffing.

Public NotInheritable Class Form4
    Inherits System.Windows.Forms.Form

#Region " Class Declaration "

    Dim contarr(2) As Double
    Dim stk1 As New List(Of Area)
    Dim stk2 As New List(Of Area)
    Dim stkmm As New List(Of Area)
    Dim totvol As Double
    Dim mulfac As Double
    Dim arc As New Area
    Dim qtyf As Boolean = False
    Dim rowlvflg As Boolean = False
    Dim stp As Integer
    Dim cntm As Integer = 1
    Dim totqty = 25
    Dim totqty1 As Integer = 0
    Dim drwstp As Integer
    Dim addflg As Integer
    Dim cntflg As Boolean = False
    Dim rwidx As Integer
    Dim flg1 As Boolean = True
    Dim sortflag As Boolean
    Dim button1flag As Boolean = False
    Dim itmnm As String
    Dim maxqtyflg As Boolean

#End Region

#Region " Routine Definition "

    Private Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim arx As New List(Of Area)
        Dim a1 As New Area
        Dim a2 As New Area

        Dim arx1 As New ArrayList
        'Form19.Button1.SendToBack()

        If units = "i" Then
            mulfac = 1
        ElseIf units = "m" Then
            mulfac = 25.4
        End If

        If seqopt = 1 Then
            Button1.Enabled = False
        End If

        Dim cmd As New OleDb.OleDbCommand
        Dim cmd1 As New OleDb.OleDbCommand
        Dim cmd2 As New OleDb.OleDbCommand
        Dim rdr As OleDb.OleDbDataReader

        Dim cc As DataGridViewComboBoxColumn
        Dim dd As DataGridViewComboBoxColumn

        Dim adpt As New OleDb.OleDbDataAdapter
        Dim adpt1 As New OleDb.OleDbDataAdapter
        Dim ds As New DataSet("mytable")
        Dim tbl As New DataTable
        Dim tbl1 As New DataTable
        Dim tbl2 As New DataTable
        Dim tbl3 As New DataTable

        Dim ar1 As New Area
        Dim ar2 As New Area
        Dim nn As Boolean = True

        ar1.length = 27
        ar1.height = 24
        ar1.width = 12
        ar2.length = 8
        ar2.height = 25
        ar2.width = 24

        cmd.Connection = conn
        cmd.CommandText = "select distinct containername from containermaster"
        cmd1.Connection = conn
        cmd1.CommandText = "select distinct itemname from itemmaster"
        cmd2.Connection = conn
        cmd2.CommandText = "select customername from customermaster"

        rdr = cmd.ExecuteReader()
        adpt.SelectCommand = cmd1
        adpt.Fill(tbl)
        adpt1.SelectCommand = cmd2
        adpt1.Fill(tbl3)
        Do While rdr.Read
            CmbContainer.Items.Add(rdr.Item(0))
        Loop
        rdr.Close()

        DataGridView1.AutoGenerateColumns = False

        cc = DataGridView1.Columns(1)
        cc.DataSource = tbl
        cc.DisplayMember = "itemname"
        cc.ValueMember = "itemname"

        dd = DataGridView1.Columns(0)
        dd.DataSource = tbl3
        dd.DisplayMember = "customername"
        dd.ValueMember = "customername"

    End Sub

    Private Sub CmbContainer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbContainer.SelectedIndexChanged

        Try

            Dim rdr As OleDb.OleDbDataReader
            Dim cmd As New OleDb.OleDbCommand
            cmd.Connection = conn
            'cmd.Connection = Cons
            Dim length As Single
            Dim width As Single
            Dim height As Single

            cmd.CommandText = "select length,width,height,payload from containermaster where containername ='" & CmbContainer.Text & "'"
            rdr = cmd.ExecuteReader
            rdr.Read()
            length = rdr.Item("length")
            width = rdr.Item("Width")
            height = rdr.Item("height")
            contcap = rdr.Item("payload")
            Label1.Text = "Length=" & CStr(length * mulfac)
            Label2.Text = "Width=" & CStr(width * mulfac)
            Label3.Text = "Height=" & CStr(height * mulfac)
            Label5.Text = "Volume=" & CStr(length * width * height * mulfac * mulfac * mulfac)
            Label9.Text = CStr(contcap) & " kg"
            contarr(0) = length * mulfac
            contarr(1) = width * mulfac
            contarr(2) = height * mulfac
            arc.length = contarr(0)
            arc.width = contarr(1)
            arc.height = contarr(2)
            stk.Clear()
            stkn.Clear()
            stk.Add(arc)
            stkn.Add(arc)
            Button3.Enabled = True
            rdr.Close()

            If DataGridView1.RowCount = 0 Then
                DataGridView1.Rows.Add()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            MessageBox.Show("Error in SelectedIndexChanged", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub DataGridView1_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        rwidx = e.RowIndex
    End Sub

    Private Sub DataGridView1_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellValidated
        Dim i As Integer
        Button4.Enabled = True

        If e.ColumnIndex = 4 Then

        End If

        If e.ColumnIndex = 0 Then

        End If

        Dim j1 As Integer
        If DataGridView1.RowCount = 1 Then
            j1 = 0
        Else
            j1 = DataGridView1.RowCount - 2
        End If
        i = j1 + 1

        If seqopt = 2 Then
            If Not button1flag Then
                Button1_Click(Nothing, Nothing)
            End If

        Else
            If DataGridView1.AllowUserToAddRows = False Then
                If IsNothing(DataGridView1.Item(9, DataGridView1.RowCount - 1).Value) OrElse LCase(DataGridView1.Item(9, DataGridView1.RowCount - 1).Value.GetType.Name = "int32") OrElse DataGridView1.Item(9, DataGridView1.RowCount - 1).Value = 0 Then

                Else
                    If DataGridView1.Item(10, DataGridView1.RowCount - 1).Value < DataGridView1.Item(5, DataGridView1.RowCount - 1).Value Then
                        If maxqtyflg Then
                            MsgBox("Requested value " & CStr(DataGridView1.Item(5, DataGridView1.RowCount - 1).Value) & " is greater than maximum vlaue")
                            DataGridView1.Item(5, DataGridView1.RowCount - 1).Value = DataGridView1.Item(10, DataGridView1.RowCount - 1).Value
                        End If
                    End If
                End If
            Else
                If IsNothing(DataGridView1.Item(10, DataGridView1.RowCount - 2).Value) OrElse LCase(DataGridView1.Item(10, DataGridView1.RowCount - 2).Value.GetType.Name = "int32") OrElse DataGridView1.Item(10, DataGridView1.RowCount - 2).Value = 0 Then

                Else
                    If IsNumeric(DataGridView1.Item(10, DataGridView1.RowCount - 2).Value) And IsNumeric(DataGridView1.Item(5, DataGridView1.RowCount - 2).Value) Then
                        If DataGridView1.Item(10, DataGridView1.RowCount - 2).Value < DataGridView1.Item(5, DataGridView1.RowCount - 2).Value Then
                            If maxqtyflg Then
                                MsgBox("Requested value " & CStr(DataGridView1.Item(5, DataGridView1.RowCount - 2).Value) & " is greater than maximum value")
                                DataGridView1.Item(5, DataGridView1.RowCount - 2).Value = DataGridView1.Item(10, DataGridView1.RowCount - 2).Value
                            End If
                        End If
                    End If
                End If

            End If

        End If
        Button2.Enabled = True
        Button5.Enabled = True

        If qtyf Then
            If seqopt = 2 Then

            Else
                DataGridView1.Item(8, i).Value = i + 1
            End If
            Button2.Enabled = True
            Button5.Enabled = True
        Else
            Button2.Enabled = False

        End If

        Dim nn As Integer
        If DataGridView1.RowCount = 1 Then
            nn = 0
        Else
            nn = DataGridView1.RowCount - 2
        End If

        For i1 As Integer = 0 To nn
            If IsNothing(DataGridView1.Item(5, i1).Value) Then
                qtyf = False
                Exit For
            Else
                If Not IsNumeric(DataGridView1.Item(5, i1).Value) Then
                    qtyf = False
                    Exit For
                Else
                    If DataGridView1.Item(5, i1).Value.ToString.Contains(".") Then
                        qtyf = False
                        Exit For
                    End If

                    If DataGridView1.Item(5, i1).Value <= 0 Then
                        qtyf = False
                        Exit For
                    End If

                End If
            End If
            If DataGridView1.Item(1, i1).Value = "" Or IsNothing(DataGridView1.Item(1, i1)) Then
                qtyf = False
                Exit For
            End If

            If DataGridView1.Item(2, i1).Value.ToString = "" Then
                MsgBox("Item not selected in row " & CStr(i + 1))
                DataGridView1.AllowUserToAddRows = False
                qtyf = False
                Exit For
            End If
        Next

        If Not qtyf Then

            Button2.Enabled = False
        Else
            DataGridView1.AllowUserToAddRows = True
            Button2.Enabled = True
        End If
    End Sub

    Private Sub DataGridView1_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged

        Try

            Dim cmd As New OleDb.OleDbCommand
            Dim rdr As OleDb.OleDbDataReader
            Dim itmnm As String
            Dim adpt As New OleDb.OleDbDataAdapter
            Dim tbl As New DataTable
            Dim j As Integer

            Dim lni As Single
            Dim wdi As Single
            Dim hti As Single

            If qtyf Then
                If e.ColumnIndex = 5 Then
                End If
            End If
            If conn.State = ConnectionState.Open Then
                cmd.Connection = conn
                If e.RowIndex >= 0 And e.ColumnIndex = 0 Then

                    j = DataGridView1.Rows.Count
                    cmd.CommandText = "delete from temp"
                    cmd.ExecuteNonQuery()

                    flg = False

                End If

                If e.ColumnIndex = 7 And e.RowIndex <> -1 Then

                End If

                If e.ColumnIndex = 8 And e.RowIndex <> -1 Then
                    Dim method As String = DataGridView1.Item(e.ColumnIndex, e.RowIndex).Value
                    itmnm = DataGridView1.Item(1, e.RowIndex).Value
                    If Not itmnm Is Nothing Then
                        cmd.CommandText = "select lengthf,widthf,heightf,lengthi,widthi,heighti,lengthc,widthc,heightc,lengthm,widthm,heightm,wightkg from itemmaster where itemname ='" & itmnm & "'"
                        rdr = cmd.ExecuteReader
                        rdr.Read()
                        lni = rdr("lengthi") + (12 * rdr("lengthf")) + (rdr("lengthc") / 2.54) + (rdr("lengthm") / 25.4)
                        wdi = rdr("Widthi") + (12 * rdr("Widthf")) + (rdr("Widthc") / 2.54) + (rdr("Widthm") / 25.4)
                        hti = rdr("heighti") + (12 * rdr("heightf")) + (rdr("heightc") / 2.54) + (rdr("heightm") / 25.4)
                        rdr.Close()
                        If method = "WLH" Then
                            DataGridView1.Item(1, e.RowIndex).Value = wdi
                            DataGridView1.Item(2, e.RowIndex).Value = lni
                            DataGridView1.Item(3, e.RowIndex).Value = hti
                        End If

                        If method = "WHL" Then
                            DataGridView1.Item(1, e.RowIndex).Value = wdi
                            DataGridView1.Item(2, e.RowIndex).Value = hti
                            DataGridView1.Item(3, e.RowIndex).Value = lni
                        End If

                        If method = "HLW" Then
                            DataGridView1.Item(1, e.RowIndex).Value = hti
                            DataGridView1.Item(2, e.RowIndex).Value = lni
                            DataGridView1.Item(3, e.RowIndex).Value = wdi
                        End If

                        If method = "HWL" Then
                            DataGridView1.Item(1, e.RowIndex).Value = hti
                            DataGridView1.Item(2, e.RowIndex).Value = wdi
                            DataGridView1.Item(3, e.RowIndex).Value = lni
                        End If

                        If method = "LHW" Then
                            DataGridView1.Item(1, e.RowIndex).Value = lni
                            DataGridView1.Item(2, e.RowIndex).Value = hti
                            DataGridView1.Item(3, e.RowIndex).Value = wdi
                        End If

                        If method = "LWH" Then
                            DataGridView1.Item(1, e.RowIndex).Value = lni
                            DataGridView1.Item(2, e.RowIndex).Value = wdi
                            DataGridView1.Item(3, e.RowIndex).Value = hti
                        End If

                        Call Button1_Click(Nothing, Nothing)

                    End If

                End If

                If qtyf Then
                    If e.ColumnIndex = 6 And e.RowIndex <> -1 And addflg <> e.RowIndex Then

                        addflg = -1
                    End If
                End If

                If e.ColumnIndex = 5 Then
                    If e.RowIndex <> -1 Then
                        If CStr(DataGridView1.Item(e.ColumnIndex, e.RowIndex).Value) <> "" And IsNumeric(DataGridView1.Item(e.ColumnIndex, e.RowIndex).Value) Then
                            If DataGridView1.Item(e.ColumnIndex, e.RowIndex).Value > 0 And Not (CStr(DataGridView1.Item(e.ColumnIndex, e.RowIndex).Value)).Contains(".") Then
                                If Not IsNothing(DataGridView1.Item(2, e.RowIndex).Value) Then
                                    qtyf = True
                                End If
                            End If
                        End If
                    End If
                End If
            End If

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in DataGridView1_CellValueChanged", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub updseq()

        Dim cmd As New OleDb.OleDbCommand
        Dim cmd1 As New OleDb.OleDbCommand
        Dim rdr As OleDb.OleDbDataReader
        Dim outarr As New List(Of String)
        Dim itm As String
        Dim itmarr As Object

        Dim itmnm As Integer
        Dim seqs As String

        flg = True
        cmd.Connection = conn
        cmd1.Connection = conn
        cmd1.CommandText = "delete from temp1"
        cmd1.ExecuteNonQuery()

        cmd.CommandText = "select * from temp order by (width * height * length * qty) desc"
        rdr = cmd.ExecuteReader
        Dim Seq As Integer = 1
        Do While rdr.Read

            outarr.Add(rdr.Item("rowcnt") & "-" & CStr(Seq))
            Seq += 1
        Loop
        rdr.Close()
        For i As Integer = 0 To outarr.Count - 1
            itm = outarr(i)
            itmarr = itm.Split("-")
            itmnm = itmarr(0)
            seqs = itmarr(1)

            DataGridView1.Item(8, itmnm).Value = seqs
            If seqs = 1 Then
                TextBox1.Text = DataGridView1.Item(5, itmnm).Value
            End If

        Next

    End Sub

    Dim flg As Boolean = False

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim cmdtxt As String
        Dim j As Integer
        Dim cmd As New OleDb.OleDbCommand
        cmd.Connection = conn
        j = DataGridView1.Rows.Count
        cmd.CommandText = "delete from temp"
        cmd.ExecuteNonQuery()
        For i As Integer = 0 To j - 2
            cmdtxt = "insert into temp values('" & DataGridView1.Item(1, i).Value & "'," & DataGridView1.Item(2, i).Value & ","
            cmdtxt = cmdtxt & DataGridView1.Item(3, i).Value & "," & DataGridView1.Item(4, i).Value & "," & DataGridView1.Item(5, i).Value & "," & CStr(i) & ")"
            cmd.CommandText = cmdtxt
            cmd.ExecuteNonQuery()
        Next

        updseq()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        button1flag = True
        CheckBox3.Enabled = False
        Dim cnt As Integer = 0
        Dim dupflg As Boolean = False

        cnt = 0
        If seqopt = 2 Then
            Try

                DataGridView1.Sort(DataGridView1.Columns(9), System.ComponentModel.ListSortDirection.Ascending)
            Catch e1 As Exception
                Exit Sub
            End Try
        End If

        Do While cnt <> DataGridView1.RowCount - 1

            If cnt <> DataGridView1.RowCount Then
                If DataGridView1.Item(1, cnt).Value = DataGridView1.Item(1, cnt + 1).Value Then
                    DataGridView1.Item(5, cnt).Value = CInt(DataGridView1.Item(5, cnt).Value) + CInt(DataGridView1.Item(5, cnt + 1).Value)
                    DataGridView1.Rows.Remove(DataGridView1.Rows(cnt + 1))
                    dupflg = True
                    cnt -= 1
                End If
            End If
            cnt += 1

        Loop

        If dupflg Then

            For i As Integer = 0 To DataGridView1.RowCount - 1
                DataGridView1.Item(8, i).Value = i + 1
            Next
            TextBox1.Text = CStr(DataGridView1.Item(5, 0).Value)

        End If

        Dim ar() As Area
        Dim ari() As String
        Dim arwt() As Single
        Dim ar1 As New Area
        Dim ln As Double
        Dim wd As Double
        Dim ht As Double
        Dim qty As Integer
        Dim seq As Integer
        Dim itmnm As String
        Dim wt As String
        Dim transparr() As Boolean
        Dim transp As Boolean
        Dim topup() As Boolean
        Dim tpup As Boolean
        Dim rowno As Integer
        ReDim ar(0)
        ReDim ari(0)
        ReDim arwt(0)
        ReDim transparr(0)
        ReDim topup(0)
        Dim cmd As New OleDb.OleDbCommand
        Dim rdr As OleDb.OleDbDataReader
        Dim qtyf As Boolean = True
        Dim cntx As Integer = 0

        Dim totqty As Integer = 0
        Dim plcqty As Integer = 0

        Dim k As Integer
        Dim m As Integer

        cmd.Connection = conn
        cmd.CommandText = "delete from temp1"
        cmd.ExecuteNonQuery()

        If CmbContainer.Text = "" Then
            MsgBox("Container not selected")
            CmbContainer.Focus()
            Exit Sub
        End If

        For i As Integer = 0 To DataGridView1.RowCount - 2
            If Not IsNumeric(DataGridView1.Item(5, i).Value) Then
                MsgBox("Invalid quantity at row " & CStr(i + 1))

                For x As Integer = 0 To DataGridView1.RowCount - 1
                    For j As Integer = 0 To DataGridView1.ColumnCount - 1
                        DataGridView1.Item(j, x).Selected = False
                    Next
                Next

                DataGridView1.Item(5, i).Selected = True
                qtyf = False
                Exit For

            Else
                If DataGridView1(5, i).Value <= 0 Then
                    MsgBox("Invalid quantity at row " & CStr(i + 1))

                    For x As Integer = 0 To DataGridView1.RowCount - 1
                        For j As Integer = 0 To DataGridView1.ColumnCount - 1
                            DataGridView1.Item(j, x).Selected = False
                        Next
                    Next

                    DataGridView1.Item(5, i).Selected = True

                    qtyf = False
                    Exit For
                End If

                If DataGridView1.Item(5, i).Value.ToString.Contains(".") Then
                    MsgBox("Invalid quantity at row " & CStr(i + 1))

                    For x As Integer = 0 To DataGridView1.RowCount - 1
                        For j As Integer = 0 To DataGridView1.ColumnCount - 1
                            DataGridView1.Item(j, x).Selected = False
                        Next
                    Next

                    DataGridView1.Item(5, i).Selected = True

                    qtyf = False
                    Exit For
                End If
            End If
        Next

        Dim i1, j1 As Integer
        Dim extflg As Boolean = False
        If qtyf Then
            Bplclst.Clear()
            Bqtylst.Clear()
            For i1 = 0 To DataGridView1.Rows.Count - 2

                itmnm = DataGridView1.Item(1, i1).Value
                ln = DataGridView1.Item(2, i1).Value
                wd = DataGridView1.Item(3, i1).Value
                ht = DataGridView1.Item(4, i1).Value
                qty = DataGridView1.Item(5, i1).Value
                wt = DataGridView1.Item(6, i1).Value
                seq = DataGridView1.Item(8, i1).Value
                transp = DataGridView1.Item(9, i1).Value
                tpup = DataGridView1.Item(7, i1).Value
                Bqtylst.Add(qty)

                For j1 = 0 To qty - 1
                    totqty1 += 1
                    cmd.CommandText = "insert into temp1 values ('" & itmnm & "'," & CStr(ln) & "," & CStr(wd) & "," & CStr(ht) & "," & CStr(qty) & "," & CStr(wt) & "," & CStr(seq) & "," & CStr(transp) & "," & CStr(tpup) & ")"
                    cmd.ExecuteNonQuery()
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

            totqty = 0
            For i As Integer = 0 To Bqtylst.Count - 1
                totqty = totqty + Bqtylst(i)
            Next

            plcqty = 0
            For i As Integer = 0 To Bplclstf.Count - 1
                plcqty = plcqty + Bplclstf(i)
            Next

            If plcqty + CInt(TextBox1.Text) > totqty Then
                MsgBox("Step quantity you entered exeeds maximum Quantity" & vbCrLf & "Resseting step quantity")
                TextBox1.Text = CStr(totqty - plcqty)
                Exit Sub
            End If

            cmd.CommandText = "select * from temp1 order by seq"
            rdr = cmd.ExecuteReader()
            cnt = 0

            If CheckBox2.Checked = False Then

            End If
            Do While rdr.Read

                qtyf = True

                itmnm = rdr.Item("itmnm")
                ln = rdr.Item("ln")
                wd = rdr.Item("wd")
                ht = rdr.Item("ht")

                wt = rdr.Item("wt")
                transp = rdr.Item("transp")
                tpup = rdr.Item("tpup")
                seq = rdr.Item("seq")
                rowno = findrowno(DataGridView1, 9, seq)

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

            Loop
            rdr.Close()
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
            Dim topup2() As Boolean

            ReDim ar2(0)
            ReDim ari2(0)
            ReDim arwt2(0)
            ReDim transparr2(0)
            ReDim topup2(0)
            drwstp = drwstp + CInt(TextBox1.Text)

            For i As Integer = 0 To drwstp - 1
                ar2(UBound(ar2)) = ar(i)
                ari2(UBound(ari2)) = ari(i)
                arwt2(UBound(arwt2)) = arwt(i)
                transparr2(UBound(transparr2)) = transparr(i)
                topup2(UBound(topup2)) = topup(i)
                ReDim Preserve ar2(UBound(ar2) + 1)
                ReDim Preserve ari2(UBound(ari2) + 1)
                ReDim Preserve arwt2(UBound(arwt2) + 1)
                ReDim Preserve transparr2(UBound(transparr2) + 1)
                ReDim Preserve topup2(UBound(topup2) + 1)
            Next

            ReDim Preserve ar2(UBound(ar2) - 1)
            ReDim Preserve ari2(UBound(ari2) - 1)
            ReDim Preserve arwt2(UBound(arwt2) - 1)
            ReDim Preserve transparr2(UBound(transparr2) - 1)
            ReDim Preserve topup2(UBound(topup2) - 1)

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

                If fullflag = True Then
                    MsgBox("Container is full and some items were not placed." & vbCrLf & "Please check placed items details in the grid")
                    DataGridView1.Enabled = False
                    Button2.Enabled = False
                    TextBox1.Enabled = False
                    CheckBox3.Enabled = False
                End If
                Dim are As Area
                stkmm.Clear()
                For r As Integer = 0 To stk2.Count - 1
                    are = New Area
                    are.StrtPt.x = stk2(r).StrtPt.x
                    are.StrtPt.y = stk2(r).StrtPt.y
                    are.StrtPt.z = stk2(r).StrtPt.z
                    are.length = stk2(r).length
                    are.width = stk2(r).width
                    are.height = stk2(r).height
                    stkmm.Add(are)
                Next
                stk.Clear()
                ReDim ar2(0)
                ReDim ar2(0)
                ReDim ari2(0)
                ReDim arwt2(0)
                ReDim transparr2(0)
                ReDim topup2(0)

                For i As Integer = 0 To Bitemno

                    DataGridView1.Item(11, i).Value = Bplclst(i) + 1
                    If CInt(DataGridView1.Item(11, i).Value) < CInt(DataGridView1.Item(5, i).Value) Then
                        MsgBox(DataGridView1.Item(5, i).Value.ToString & " no of " & DataGridView1.Item(1, i).Value & " cannot be placed." & vbCrLf & DataGridView1.Item(11, i).Value & " placed.")
                        DataGridView1.Item(5, i).Value = DataGridView1.Item(11, i).Value
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

                If k = Bplclstf.Count - 1 And Bplclstf(k) = Bqtylst(k) Then
                    TextBox1.Text = ""
                    TextBox1.Enabled = False
                    MsgBox("All items placed")
                    Button2.Enabled = False
                    DataGridView1.Enabled = False

                    Exit Sub
                End If

                If Bplclstf(k) = Bqtylst(k) Then
                    TextBox1.Text = CStr(Bqtylst(k + 1))
                Else
                    TextBox1.Text = Bqtylst(k) - Bplclstf(k)
                End If

            Else
                If DataGridView1.RowCount > 1 Then
                    If ar.Length <> 0 Then

                    End If
                Else
                    MsgBox("No items Selected")
                End If

            End If
        End If

        If stp >= 99999 Then

        End If

        If CheckBox2.Checked = True Then
            If cnt = 0 Then
                'MsgBox("All Items Stuffed")
            End If
        End If

    End Sub

    Public Function findrowno(ByVal grd As DataGridView, ByVal colno As Integer, ByVal seq As Object) As Integer

        For i As Integer = 0 To grd.RowCount - 1
            If grd.Item(colno, i).Value = seq Then
                Return i
            End If
        Next
        Return -1

    End Function

    Public Sub strthtml(ByVal fn As String, ByVal itmnm As String)

        Dim dq As Char = Chr(34)
        FileOpen(3, fn, OpenMode.Append)
        PrintLine(3, "<html>")
        PrintLine(3, "<head>")
        PrintLine(3, "<title>New Page 2</title>")

        PrintLine(3, "</head>")
        PrintLine(3, "<body>")
        PrintLine(3, "<table border=" & dq & "1" & dq & " cellpadding=" & dq & "0" & dq & " cellspacing=" & dq & "0" & dq & " style=" & dq & "border-collapse: collapse" & dq & " width=" & dq & "100%" & dq & ">")
        FileClose(3)

    End Sub

    Public Sub placetable(ByVal fn As String, ByVal szarr() As String, ByVal qty As Integer, ByVal wt As Single, ByVal itmnm As String)

        Dim dq As Char = Chr(34)
        FileOpen(2, fn, OpenMode.Output)
        PrintLine(2, "<html>")
        PrintLine(2, "<head>")
        PrintLine(2, "<title>" & itmnm & "</title>")
        PrintLine(2, "</head>")
        PrintLine(2, "<body>")
        PrintLine(2, "<p><font size=" & dq & "5" & dq & " color=red><b>" & itmnm & "</b></font></p>")
        Dim totvol As Single = CSng(szarr(0)) * CSng(szarr(1)) * CSng(szarr(2)) * qty
        Dim totwt1 As Single = wt * qty
        PrintLine(2, "<p><font size=" & dq & "3" & dq & " color=blue>Total Volume:" & CStr(totvol) & "</font></p>")
        PrintLine(2, "<p><font size=" & dq & "3" & dq & " color=green>Total Weight:" & CStr(totwt1) & "</font></p>")
        PrintLine(2, "<table border=" & dq & "1" & dq & " cellpadding=" & dq & "0" & dq & " cellspacing=" & dq & "0" & dq & " style=" & dq & "border-collapse: collapse" & dq & " width=" & dq & "100%" & dq & ">")
        PrintLine(2, "<tr>")
        PrintLine(2, "<td width=" & dq & "16.66%" & dq & ">" & "Length" & "</td>")
        PrintLine(2, "<td width=" & dq & "16.66%" & dq & ">" & "Width" & "</td>")
        PrintLine(2, "<td width=" & dq & "16.66%" & dq & ">" & "Height" & "</td>")
        PrintLine(2, "<td width=" & dq & "16.66%" & dq & ">" & "Weight" & "</td>")
        PrintLine(2, "<td width=" & dq & "16.66%" & dq & ">" & "Volume" & "</td>")
        PrintLine(2, "<td width=" & dq & "16.66%" & dq & ">" & "Quantity" & "</td>")
        PrintLine(2, "</tr>")

        PrintLine(2, "<tr>")
        PrintLine(2, "<td width=" & dq & "16.66%" & dq & ">" & szarr(0) & "</td>")
        PrintLine(2, "<td width=" & dq & "16.66%" & dq & ">" & szarr(1) & "</td>")
        PrintLine(2, "<td width=" & dq & "16.66%" & dq & ">" & szarr(2) & "</td>")
        PrintLine(2, "<td width=" & dq & "16.66%" & dq & ">" & CStr(wt) & "</td>")
        'PrintLine(2, "<td width=" & dq & "16.66%" & dq & ">" & CStr(totvol \ qty) & "</td>")
        PrintLine(2, "<td width=" & dq & "16.66%" & dq & ">" & CStr(qty) & "</td>")
        qty = 0
        PrintLine(2, "</tr>")
        FileClose(2)

    End Sub

    Public Sub endhtml(ByVal fn As String)

        FileOpen(2, fn, OpenMode.Append)
        PrintLine(2, "</table>")
        PrintLine(2, "</body>")
        PrintLine(2, "</html>")
        FileClose(2)

    End Sub

    Private Sub DataGridView1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DataGridView1.RowsAdded

        addflg = e.RowIndex

        DataGridView1.Item(5, e.RowIndex).Value = "0"

        If seqopt = 1 Then
            For i As Integer = 0 To DataGridView1.RowCount - 1
                DataGridView1.Item(8, i).Value = i + 1
            Next
        Else

        End If

        If Not flg1 Then

        End If

        If seqopt = 1 Then
            If DataGridView1.RowCount > 1 Then
                TextBox1.Text = CStr(DataGridView1.Item(5, 0).Value)
            End If
        End If

    End Sub

    'Public Function WadFtip(ByVal arc As Area, ByVal ari As Area, ByVal tpup As Boolean) As Boolean

    '    Dim clength As Double = arc.length
    '    Dim cwidth As Double = arc.width
    '    Dim cheight As Double = arc.height

    '    Dim ilength As Double = ari.length
    '    Dim iwidth As Double = ari.width
    '    Dim iheight As Double = ari.height

    '    Dim pX As Double = arc.StrtPt.x
    '    Dim pY As Double = arc.StrtPt.y
    '    Dim pZ As Double = arc.StrtPt.z

    '    Dim lstl As New List(Of String)
    '    Dim lstw As New List(Of String)
    '    Dim lsth As New List(Of String)
    '    Dim ordr As New List(Of List(Of String))
    '    Dim ordr1 As New List(Of String)
    '    Dim out As New List(Of String)
    '    Dim itm As String

    '    If ilength <= clength Then
    '        lstl.Add("clength")
    '    End If

    '    If ilength <= cwidth Then
    '        lstl.Add("cwidth")
    '    End If

    '    If Not tpup Then
    '        If ilength <= cheight Then
    '            lstl.Add("cheight")
    '        End If
    '    End If

    '    If iwidth <= clength Then
    '        lstw.Add("clength")
    '    End If

    '    If iwidth <= cwidth Then
    '        lstw.Add("cwidth")
    '    End If

    '    If Not tpup Then
    '        If iwidth <= cheight Then
    '            lstw.Add("cheight")
    '        End If
    '    End If

    '    If Not tpup Then
    '        If iheight <= clength Then
    '            lsth.Add("clength")
    '        End If

    '        If iheight <= cwidth Then
    '            lsth.Add("cwidth")
    '        End If
    '    End If

    '    If iheight <= cheight Then
    '        lsth.Add("cheight")
    '    End If

    '    Dim cnt1 As Byte = lstl.Count
    '    Dim cnt2 As Byte = lstw.Count
    '    Dim cnt3 As Byte = lsth.Count

    '    If cnt1 = 0 OrElse cnt2 = 0 OrElse cnt3 = 0 Then
    '        Return False
    '    Else
    '        If cnt1 <= cnt2 AndAlso cnt1 <= cnt3 Then
    '            ordr.Add(lstl)
    '            ordr1.Add("l")
    '            If cnt2 <= cnt3 Then
    '                ordr.Add(lstw)
    '                ordr1.Add("w")
    '                ordr.Add(lsth)
    '                ordr1.Add("h")
    '            Else
    '                ordr.Add(lsth)
    '                ordr1.Add("h")
    '                ordr.Add(lstw)
    '                ordr1.Add("w")
    '            End If
    '        End If

    '        If cnt2 <= cnt1 AndAlso cnt2 <= cnt3 AndAlso ordr.Count = 0 Then
    '            ordr.Add(lstw)
    '            ordr1.Add("w")
    '            If cnt1 <= cnt3 Then
    '                ordr.Add(lstl)
    '                ordr1.Add("l")
    '                ordr.Add(lsth)
    '                ordr1.Add("h")
    '            Else
    '                ordr.Add(lsth)
    '                ordr1.Add("h")
    '                ordr.Add(lstl)
    '                ordr1.Add("l")
    '            End If
    '        End If

    '        If cnt3 <= cnt1 AndAlso cnt3 <= cnt2 AndAlso ordr.Count = 0 Then
    '            ordr.Add(lsth)
    '            ordr1.Add("h")
    '            If cnt1 <= cnt2 Then
    '                ordr.Add(lstl)
    '                ordr1.Add("l")
    '                ordr.Add(lstw)
    '                ordr1.Add("w")
    '            Else
    '                ordr.Add(lstw)
    '                ordr1.Add("w")
    '                ordr.Add(lstl)
    '                ordr1.Add("l")
    '            End If
    '        End If
    '        Dim lst1 As New List(Of String)
    '        Dim lst2 As New List(Of String)
    '        Dim lst3 As New List(Of String)
    '        Dim pos1 As String
    '        Dim pos2 As String
    '        Dim pos3 As String

    '        lst1 = ordr(0)
    '        lst2 = ordr(1)
    '        lst3 = ordr(2)
    '        pos1 = ordr1(0)
    '        pos2 = ordr1(1)
    '        pos3 = ordr1(2)
    '        itm = lst1(0)
    '        out.Add(pos1 & "-" & itm)
    '        Call WadRemv(lst2, itm)
    '        Call WadRemv(lst3, itm)

    '        If lst2.Count = 0 OrElse lst3.Count = 0 Then
    '            Return False
    '        Else
    '            itm = lst2(0)
    '            out.Add(pos2 & "-" & itm)
    '            Call WadRemv(lst3, itm)
    '            If lst3.Count = 0 Then
    '                Return False
    '            Else
    '                itm = lst3(0)
    '                out.Add(pos3 & "-" & itm)
    '            End If
    '        End If
    '    End If
    '    Dim itmarr As Object
    '    For i As Integer = 0 To 2
    '        itm = out(i)
    '        itmarr = Split(itm, "-")

    '        If itmarr(1) = "clength" Then

    '            If itmarr(0) = "w" Then
    '                'ari.length = iwidth   'Comment it unused it at orig
    '            End If

    '            If itmarr(0) = "l" Then
    '                'ari.length = ilength   'Comment it unused it at orig     
    '            End If

    '            If itmarr(0) = "h" Then
    '                'ari.length = iheight    'Comment it unused it at orig
    '            End If

    '        End If

    '        If itmarr(1) = "cwidth" Then

    '            If itmarr(0) = "w" Then

    '            End If

    '            If itmarr(0) = "l" Then

    '            End If

    '            If itmarr(0) = "h" Then

    '            End If

    '        End If

    '        If itmarr(1) = "cheight" Then

    '            If itmarr(0) = "w" Then

    '            End If

    '            If itmarr(0) = "l" Then

    '            End If

    '            If itmarr(0) = "h" Then

    '            End If

    '        End If
    '    Next

    '    Return True

    'End Function

    Public Function ftip(ByVal arc As Area, ByVal ari As Area, ByVal tpup As Boolean) As Boolean

        Dim clength As Double = arc.length
        Dim cwidth As Double = arc.width
        Dim cheight As Double = arc.height

        Dim ilength As Double = ari.length
        Dim iwidth As Double = ari.width
        Dim iheight As Double = ari.height

        Dim pXc As Double = arc.StrtPt.x
        Dim pYc As Double = arc.StrtPt.y
        Dim pZc As Double = arc.StrtPt.z

        Dim pXi As Double = ari.StrtPt.x
        Dim pYi As Double = ari.StrtPt.y
        Dim pZi As Double = ari.StrtPt.z

        Dim lstl As New List(Of String)
        Dim lstw As New List(Of String)
        Dim lsth As New List(Of String)
        Dim ordr As New List(Of List(Of String))
        Dim ordr1 As New List(Of String)
        Dim out As New List(Of String)
        Dim itm As String

        If ilength <= clength Then
            lstl.Add("clength")
        End If

        If ilength <= cwidth Then
            lstl.Add("cwidth")
        End If

        If Not tpup Then
            If ilength <= cheight Then
                lstl.Add("cheight")
            End If
        End If

        If iwidth <= clength Then
            lstw.Add("clength")
        End If

        If iwidth <= cwidth Then
            lstw.Add("cwidth")
        End If

        If Not tpup Then
            If iwidth <= cheight Then
                lstw.Add("cheight")
            End If
        End If

        If Not tpup Then
            If iheight <= clength Then
                lsth.Add("clength")
            End If

            If iheight <= cwidth Then
                lsth.Add("cwidth")
            End If
        End If

        If iheight <= cheight Then
            lsth.Add("cheight")
        End If

        Dim cnt1 As Byte = lstl.Count
        Dim cnt2 As Byte = lstw.Count
        Dim cnt3 As Byte = lsth.Count

        If cnt1 = 0 OrElse cnt2 = 0 OrElse cnt3 = 0 Then
            Return False
        Else
            If cnt1 <= cnt2 AndAlso cnt1 <= cnt3 Then
                ordr.Add(lstl)
                ordr1.Add("l")
                If cnt2 <= cnt3 Then
                    ordr.Add(lstw)
                    ordr1.Add("w")
                    ordr.Add(lsth)
                    ordr1.Add("h")
                Else
                    ordr.Add(lsth)
                    ordr1.Add("h")
                    ordr.Add(lstw)
                    ordr1.Add("w")
                End If
            End If

            If cnt2 <= cnt1 AndAlso cnt2 <= cnt3 AndAlso ordr.Count = 0 Then
                ordr.Add(lstw)
                ordr1.Add("w")
                If cnt1 <= cnt3 Then
                    ordr.Add(lstl)
                    ordr1.Add("l")
                    ordr.Add(lsth)
                    ordr1.Add("h")
                Else
                    ordr.Add(lsth)
                    ordr1.Add("h")
                    ordr.Add(lstl)
                    ordr1.Add("l")
                End If
            End If

            If cnt3 <= cnt1 AndAlso cnt3 <= cnt2 AndAlso ordr.Count = 0 Then
                ordr.Add(lsth)
                ordr1.Add("h")
                If cnt1 <= cnt2 Then
                    ordr.Add(lstl)
                    ordr1.Add("l")
                    ordr.Add(lstw)
                    ordr1.Add("w")
                Else
                    ordr.Add(lstw)
                    ordr1.Add("w")
                    ordr.Add(lstl)
                    ordr1.Add("l")
                End If
            End If

            Dim lst1 As New List(Of String)
            Dim lst2 As New List(Of String)
            Dim lst3 As New List(Of String)
            Dim pos1 As String
            Dim pos2 As String
            Dim pos3 As String

            lst1 = ordr(0)
            lst2 = ordr(1)
            lst3 = ordr(2)
            pos1 = ordr1(0)
            pos2 = ordr1(1)
            pos3 = ordr1(2)
            itm = lst1(0)
            out.Add(pos1 & "-" & itm)
            Call remv(lst2, itm)
            Call remv(lst3, itm)

            If lst2.Count = 0 OrElse lst3.Count = 0 Then
                Return False
            Else
                itm = lst2(0)
                out.Add(pos2 & "-" & itm)
                Call remv(lst3, itm)
                If lst3.Count = 0 Then
                    Return False
                Else
                    itm = lst3(0)
                    out.Add(pos3 & "-" & itm)
                End If
            End If
        End If

        Dim itmarr As Object
        For i As Integer = 0 To 2
            itm = out(i)
            itmarr = Split(itm, "-")

            If itmarr(1) = "clength" Then

                If itmarr(0) = "w" Then
                    'ari.length = iwidth   'Comment it unused it at orig
                End If

                If itmarr(0) = "l" Then
                    'ari.length = ilength   'Comment it unused it at orig     
                End If

                If itmarr(0) = "h" Then
                    'ari.length = iheight    'Comment it unused it at orig
                End If

            End If

            If itmarr(1) = "cwidth" Then

                If itmarr(0) = "w" Then

                End If

                If itmarr(0) = "l" Then

                End If

                If itmarr(0) = "h" Then

                End If

            End If

            If itmarr(1) = "cheight" Then

                If itmarr(0) = "w" Then

                End If

                If itmarr(0) = "l" Then

                End If

                If itmarr(0) = "h" Then

                End If

            End If
        Next

        Return True

    End Function

    Public Function ftipx(ByVal arc As Area, ByVal ari As Area, ByVal tpup As Boolean) As Boolean

        Dim clength As Double = arc.length
        Dim cwidth As Double = arc.width
        Dim cheight As Double = arc.height

        Dim ilength As Double = ari.length
        Dim iwidth As Double = ari.width
        Dim iheight As Double = ari.height

        If ilength <= clength AndAlso iwidth <= cwidth AndAlso iheight <= cheight Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Sub remv(ByVal lst As List(Of String), ByVal itm As String)

        Try

            For i As Integer = 0 To lst.Count - 1
                lst.Remove(itm)
            Next

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in remv", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

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

        totvol = 0
        If stkmm.Count = 0 And Bareaarr.Count = 0 Then
            stkmm.Add(arc)
        End If
        For i As Integer = 0 To stkmm.Count - 1
            ar = stkmm(i)
            x = ar.StrtPt.x
            y = ar.StrtPt.y
            z = ar.StrtPt.z
            ln = ar.length
            wd = ar.width
            ht = ar.height
            vol = ln * wd * ht
            totvol = totvol + vol

        Next

        If Bareaarr.Count > 0 Then
            lst = Bareaarr(0)

            totvol1 = 0
            For i As Integer = 0 To lst.Count - 1 Step 2

                totvol1 = totvol1 + CDbl(lst(i + 1))
            Next
        End If

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        For i As Integer = 0 To DataGridView1.Rows.Count - 2
            If DataGridView1.Rows(i).Selected Then
                DataGridView1.Rows.Remove(DataGridView1.Rows(i))
                Exit Sub
            End If
        Next
        If DataGridView1.RowCount = 1 Then
            Button2.Enabled = False
            Button4.Enabled = False

        End If

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click

        Try
            Dim ar() As Area
            Dim ari() As String
            Dim arwt() As Single
            Dim ar1 As New Area

            Dim ln As Double
            Dim wd As Double
            Dim ht As Double
            Dim qty As Integer
            Dim seq As Integer
            Dim itmnm As String
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
            Dim rdr As OleDb.OleDbDataReader

            Dim cnt As Integer = 0
            cmd.Connection = conn
            cmd.CommandText = "delete from temp1"
            cmd.ExecuteNonQuery()
            Bmaxqtylst.Clear()
            If CmbContainer.Text = "" Then
                If cntflg Then
                    MsgBox("Container not selected")
                    CmbContainer.Focus()
                    DataGridView1.AllowUserToAddRows = False
                    Exit Sub
                End If
            Else

                If Not IsNothing(DataGridView1.Item(10, DataGridView1.RowCount - 1).Value) AndAlso LCase(DataGridView1.Item(10, DataGridView1.RowCount - 1).Value.GetType.Name = "int32") OrElse DataGridView1.Item(10, DataGridView1.RowCount - 1).Value <> 0 Then
                    DataGridView1.AllowUserToAddRows = True
                End If
            End If

            For i As Integer = 0 To DataGridView1.Rows.Count - 2

                itmnm = ListBox1.Items(i).ToString
                ln = DataGridView1.Item(2, i).Value
                wd = DataGridView1.Item(3, i).Value
                ht = DataGridView1.Item(4, i).Value
                qty = DataGridView1.Item(5, i).Value

                wt = DataGridView1.Item(6, i).Value
                seq = DataGridView1.Item(8, i).Value
                transp = DataGridView1.Item(9, i).Value
                tpup = DataGridView1.Item(7, i).Value
                DataGridView1.Item(11, i).Value = ""
                cmd.CommandText = "insert into temp1 values ('" & itmnm & "'," & CStr(ln) & "," & CStr(wd) & "," & CStr(ht) & "," & CStr(qty) & "," & CStr(wt) & "," & CStr(seq) & "," & CStr(transp) & "," & CStr(tpup) & ")"
                cmd.ExecuteNonQuery()
            Next i

            cmd.CommandText = "select * from temp1 order by seq"
            rdr = cmd.ExecuteReader()
            cnt = 0

            If CheckBox2.Checked = False Then
                stp = 99999
            End If
            Do While rdr.Read And cnt < stp And qtyf

                qtyf = True
                For i As Integer = 0 To DataGridView1.RowCount - 3
                    If Not IsNumeric(DataGridView1.Item(5, i).Value) Then
                        If DataGridView1.Item(4, i).Value.ToString.Contains(".") Then

                            MsgBox("Invalid quantity at row " & CStr(i + 1))

                            For x As Integer = 0 To DataGridView1.RowCount - 1
                                For j As Integer = 0 To DataGridView1.ColumnCount - 1
                                    DataGridView1.Item(j, x).Selected = False
                                Next
                            Next

                            DataGridView1.Item(5, i).Selected = True

                            qtyf = False
                            Exit For
                        End If
                    Else
                        If DataGridView1(5, i).Value <= 0 Then
                            MsgBox("Invalid quantity at row " & CStr(i + 1))

                            For x As Integer = 0 To DataGridView1.RowCount - 1
                                For j As Integer = 0 To DataGridView1.ColumnCount - 1
                                    DataGridView1.Item(j, x).Selected = False
                                Next
                            Next

                            DataGridView1.Item(5, i).Selected = True

                            qtyf = False
                            Exit For
                        End If
                    End If
                Next

                If qtyf Then
                    itmnm = rdr.Item("itmnm")
                    ln = rdr.Item("ln")
                    wd = rdr.Item("wd")
                    ht = rdr.Item("ht")
                    qty = rdr.Item("qty")
                    wt = rdr.Item("wt")
                    transp = rdr.Item("transp")
                    tpup = rdr.Item("tpup")
                    seq = rdr.Item("seq")

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
                    cnt += 1
                End If
            Loop
            rdr.Close()
            stp += 1

            If stp = DataGridView1.RowCount Then
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
            Dim outfile As String = CurDir() & "\first.wrl"
            If ar.Length > 0 Then

                If stk.Count = 0 Then stk.Add(arc)

                DataGridView1.Item(10, 0).Value = Bmaxqtylst(0)
                If CInt(DataGridView1.Item(5, 0).Value) > Bmaxqtylst(0) Then
                    DataGridView1.Item(5, 0).Value = Bmaxqtylst(0)
                End If

                For mmm As Integer = 1 To Bmaxqtylst.Count - 1
                    If IsNothing(DataGridView1.Item(10, mmm).Value) Then
                        DataGridView1.Item(10, mmm).Value = Bmaxqtylst(mmm) - Bmaxqtylst(mmm - 1)
                    End If
                    If CInt(DataGridView1.Item(5, mmm).Value) > Bmaxqtylst(mmm) - Bmaxqtylst(mmm - 1) Then
                        DataGridView1.Item(5, mmm).Value = Bmaxqtylst(mmm) - Bmaxqtylst(mmm - 1)
                    End If
                Next
                Bmaxqtylst.Clear()

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
                    MsgBox("No items Selected")

                End If

            End If

            Dim mm As New Area
            Dim mm1 As New Area

            Dim vol1 As Double = 0
            Dim vol2 As Double = 0
            Dim maxqty As Integer
            Dim arx As New List(Of Area)

            mm.length = DataGridView1.Item(2, DataGridView1.RowCount - 1).Value
            mm.width = DataGridView1.Item(3, DataGridView1.RowCount - 1).Value
            mm.height = DataGridView1.Item(4, DataGridView1.RowCount - 1).Value

            itmnm = ListBox1.Items(DataGridView1.RowCount - 1).ToString

            vol1 = mm.length * mm.height * mm.width

            If vol1 <> 0 Then
                For j As Integer = 0 To stk.Count - 1
                    mm1 = stk(j)
                    vol2 = vol2 + (mm1.length * mm1.width * mm1.height)

                Next

                maxqty = vol2 \ vol1
                ReDim ar(0)
                ReDim ari(0)
                For j As Integer = 0 To maxqty - 1
                    ar(UBound(ar)) = New Area
                    ar(UBound(ar)).length = mm.length
                    ar(UBound(ar)).width = mm.width
                    ar(UBound(ar)).height = mm.height
                    ari(UBound(ari)) = itmnm

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

                ReDim ar(0)
                ReDim ari(0)
                ReDim arwt(0)
                ReDim transparr(0)
                ReDim topup(0)
                'Stop
                If CInt(DataGridView1.Item(5, DataGridView1.RowCount - 1).Value) > Bitemqty Then
                    If maxqtyflg Then
                        MsgBox("Requested Quantity " & DataGridView1.Item(5, DataGridView1.RowCount - 2).Value & " is greater than maximum quatity")
                        DataGridView1.Item(5, DataGridView1.RowCount - 1).Value = Bitemqty
                    End If
                End If

                DataGridView1.Item(10, DataGridView1.RowCount - 1).Value = Bitemqty

                Form8.Close()
                Bitemqty = 0
                stk.Clear()
                stk.Add(arc)
            Else

            End If
            cntflg = True
            stk.Clear()
        Catch Ex As Exception
            MsgBox(Ex.Message, MsgBoxStyle.Critical, "Exception :: In Event 'Button5_Click'  " & vbCrLf & "Programme Running is failure!")
        End Try

    End Sub

    Private Sub ComboBox_SelectedIndexChanged( _
      ByVal sender As Object, ByVal e As EventArgs)

        Dim comboBox1 As ComboBox = CType(sender, ComboBox)
        itmnm = comboBox1.Text
        Dim cmd As New OleDb.OleDbCommand
        Dim rdr As OleDb.OleDbDataReader
        Dim lni As Single
        Dim wdi As Single
        Dim hti As Single
        cmd.Connection = conn
        cmd.CommandText = "select lengthf,widthf,heightf,lengthi,widthi,heighti,lengthc,widthc,heightc,lengthm,widthm,heightm,wightkg from itemmaster where itemname ='" & itmnm & "'"
        rdr = cmd.ExecuteReader
        rdr.Read()
        Try
            lni = rdr("lengthi") + (12 * rdr("lengthf")) + (rdr("lengthc") / 2.54) + (rdr("lengthm") / 25.4)
        Catch
            Exit Sub
        End Try
        wdi = rdr("Widthi") + (12 * rdr("Widthf")) + (rdr("Widthc") / 2.54) + (rdr("Widthm") / 25.4)
        hti = rdr("heighti") + (12 * rdr("heightf")) + (rdr("heightc") / 2.54) + (rdr("heightm") / 25.4)
        DataGridView1.Item(2, rwidx).Value = lni * mulfac
        DataGridView1.Item(3, rwidx).Value = wdi * mulfac
        DataGridView1.Item(4, rwidx).Value = hti * mulfac
        DataGridView1.Item(6, rwidx).Value = rdr.Item("wightkg")

        ListBox1.Items.Add(sender.text)
        seqopt = 1
        If seqopt = 1 Then
            Dim ans = MsgBox("Do you want to calculate maximum quantity?", MsgBoxStyle.YesNo + vbExclamation)
            If ans = MsgBoxResult.Yes Then
                Button5_Click(Nothing, Nothing)
                maxqtyflg = True
            Else
                maxqtyflg = False
            End If
        End If
        rdr.Close()

    End Sub

    Private Sub DataGridView1_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DataGridView1.EditingControlShowing

        Dim combo As ComboBox
        Try

            combo = CType(e.Control, ComboBox)
        Catch except As InvalidCastException
            Exit Sub
        End Try

        If (combo IsNot Nothing) Then
            RemoveHandler combo.DropDownClosed, _
                New EventHandler(AddressOf ComboBox_SelectedIndexChanged)

            AddHandler combo.DropDownClosed, _
              New EventHandler(AddressOf ComboBox_SelectedIndexChanged)

        End If

    End Sub

    Public Sub button5click()

        flg1 = False

        If DataGridView1.RowCount = 0 Then
            Exit Sub
        End If

        For i As Integer = 0 To DataGridView1.RowCount - 2
            If Not IsNumeric(DataGridView1.Item(4, i).Value) Then
                MsgBox("Invalid quantity at row " & CStr(i + 1))
                DataGridView1.AllowUserToAddRows = False
                flg1 = True

            Else
                If DataGridView1(4, i).Value <= 0 Then
                    MsgBox("Invalid quantity at row " & CStr(i + 1))
                    DataGridView1.AllowUserToAddRows = False
                    flg1 = True

                End If

                If DataGridView1.Item(4, i).Value.ToString.Contains(".") Then
                    MsgBox("Invalid quantity at row " & CStr(i + 1))

                    DataGridView1.AllowUserToAddRows = False

                    flg1 = True

                End If
            End If

        Next

        If Not flg1 Then
            DataGridView1.AllowUserToAddRows = True
        End If

    End Sub

    Private Sub DataGridView1_RowValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.RowValidated

        If DataGridView1.Rows(e.RowIndex).ReadOnly = False Then
            If DataGridView1.Item(5, e.RowIndex).Value <> "0" AndAlso IsNumeric(DataGridView1.Item(5, e.RowIndex).Value) Then
                If qtyf Then
                    If e.RowIndex <> DataGridView1.RowCount - 1 Then
                        DataGridView1.Rows(e.RowIndex).ReadOnly = True
                    End If

                Else
                    DataGridView1.Rows(e.RowIndex).ReadOnly = False
                    Exit Sub
                End If
            End If
        End If

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click

        DataGridView1.AllowUserToAddRows = False
        Do While DataGridView1.RowCount > 0
            DataGridView1.Rows.Remove(DataGridView1.Rows(DataGridView1.RowCount - 1))
        Loop
        CmbContainer.Enabled = True
        CheckBox3.Enabled = True
        stk.Clear()
        Bitemqty = 0
        TextBox1.Text = ""
        TextBox1.Enabled = True
        totvol = 0
        qtyf = False
        drwstp = 0
        DataGridView1.Enabled = True

    End Sub

    Private Sub CheckBox3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox3.CheckedChanged

        Dim totcnt As Integer = 0
        If DataGridView1.RowCount > 0 Then
            For i As Integer = 0 To DataGridView1.RowCount - 1
                totcnt = totcnt + CInt(DataGridView1.Item(5, i).Value)
            Next
        End If
        TextBox1.Text = totcnt

    End Sub

    Private Sub DataGridView1_RowLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.RowLeave

        If Not qtyf Then
            DataGridView1.AllowUserToAddRows = False
            Button2.Enabled = False
        Else
            DataGridView1.AllowUserToAddRows = True
            Button2.Enabled = True
        End If

    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

#End Region

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

End Class
