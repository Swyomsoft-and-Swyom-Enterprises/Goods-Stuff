Imports CSPStrtContainer

Imports Microsoft.Win32
Imports System.Threading

Module ShowStuff

    'Public Stk2Th As New List(Of Area)
    'Public ArcTh As New Area
    'Public Ar2Th() As Area
    'Public Ari2Th() As String
    'Public Arwt2Th() As Single
    'Public OutFileTh As String
    'Public transparr2Th() As Boolean
    'Public topupTh() As Boolean
    'Public BtxtoptTh As Boolean = True
    'Public colarrTh As New List(Of List(Of Byte))
    'Public dgv1Th As DataGridView

    Public frmTrial_exitFlg As Boolean = False
    Public TrialShowFlg As Boolean = False
    Dim stkmm As New List(Of Area)
    Dim totvol As Double

    Sub oldshowstuff()
        '        If Not mClk Then

        '            mClk = True

        '            ShowButton.BackColor = Color.Plum

        '            StopFlg = False                               'The stop button stop flag is initialise

        '            stk.Clear()

        '            Xl3d = 0            'Initialising the value in optimum stuff
        '            Yl3d = 0
        '            Zl3d = 0

        '            Try
        '                '======================================================================================================
        '                'If chkBxAutoStuff.Checked Then             'Auto stuff arrange by old method is commented.

        '                '    DrBxOpn = False
        '                '    AutoStuffShow(sender, e)

        '                '    GoTo SBMCEnd

        '                'End If
        '                '======================================================================================================

        'StfSrtAt:

        '                BoxStatusStriplbl.Text = "Stuffing item is progress please wait."
        '                BitemqtyInr = 1

        '                Dim ans As MsgBoxResult

        '                rwidx = dgv1.CurrentCell.RowIndex
        '                Dim rowno1 As Integer = rwidx
        '                Dim plclst1 As New List(Of Integer)
        '                chkwt = True

        '                'Try
        '                If dgv1.CurrentCell.ColumnIndex = 12 Or dgv1.CurrentCell.ColumnIndex = 13 Or dgv1.CurrentCell.ColumnIndex = 14 Then

        '                    If dgv1.Item(1, rowno1).Value Is Nothing _
        '                OrElse dgv1.Item(11, rowno1).Value Is Nothing _
        '                OrElse Not IsNumeric(dgv1.Item(11, rowno1).Value) _
        '                OrElse CInt(dgv1.Item(11, rowno1).Value) <= 0 _
        '                OrElse dgv1.Item(11, rowno1).Value.ToString.Contains(".") _
        '                Then
        '                        If dgv1.CurrentCell.ColumnIndex <> 14 Then
        '                            MsgBox("Cannot show this item." & ControlChars.CrLf & "Item name not selected or quantity is invalid", MsgBoxStyle.Critical + vbOKOnly)
        '                            Exit Function
        '                        End If

        '                    End If
        '                    'End If
        '                    If dgv1.CurrentCell.ColumnIndex <> 14 Then

        '                        ans = MsgBoxResult.Yes
        '                        If ans = MsgBoxResult.Yes Then

        '                            For i As Integer = 0 To dgv1.RowCount - 1

        '                                If dgv1.Item(1, i).Value Is Nothing _
        '                                OrElse dgv1.Item(8, i).Value Is Nothing _
        '                                OrElse dgv1.Item(11, i).Value Is Nothing _
        '                                OrElse Not IsNumeric(dgv1.Item(8, i).Value) _
        '                                OrElse Not IsNumeric(dgv1.Item(11, i).Value) _
        '                                OrElse CInt(dgv1.Item(8, i).Value) < 0 _
        '                                OrElse CInt(dgv1.Item(11, i).Value) <= 0 _
        '                                OrElse dgv1.Item(11, i).Value.ToString.Contains(".") _
        '                                OrElse dgv1.Item(11, i).Value.ToString.Contains(".") _
        '                                Then

        '                                    Try
        '                                        dgv1.Rows.Remove(dgv1.Rows(i))
        '                                    Catch
        '                                        Exit For
        '                                    End Try

        '                                    i -= 1

        '                                    If i < rowno1 Then

        '                                    End If

        '                                End If
        '                            Next
        '                        Else
        '                            Exit Function
        '                        End If
        '                    End If

        '                    If CmbContainer.Text = "" Then
        '                        MsgBox("Container not selected", MsgBoxStyle.Critical + vbOKOnly)
        '                        CmbContainer.Focus()
        '                        Exit Function
        '                    End If

        '                    Bitemno = 0
        '                    Dim e3 As New e1

        '                    Dim qtyarr1 As New List(Of e1)
        '                    qtyarr1.Clear()

        '                    'Stop

        '                    For i As Integer = 0 To rowno1
        '                        e3.itmnm = dgv1.Item(1, i).Value
        '                        e3.qty = dgv1.Item(11, i).Value
        '                        qtyarr1.Add(e3)
        '                    Next

        '                    Dim putqty As Integer

        '                    Dim matchidx As Integer = -1
        '                    TxtFreeCbm.Clear()
        '                    TxtOccuCbm.Clear()

        '                    'Stop

        '                    Dim ptx As New Point
        '                    ptx.x = .ARC.length
        '                    ptx.y = .ARC.width
        '                    ptx.z = .ARC.height

        '                    Lbc = ptx.x
        '                    Wbc = ptx.y
        '                    Hbc = ptx.z
        '                    'Stop

        '                    Strt(CurDir() & "\First.wrl", True, ptx)

        '                    'Stop

        '                    If matchidx = 0 Then matchidx = -1
        '                    If matchidx = -1 Then
        '                        stk.Clear()

        '                        Dim cmd1 As New OleDb.OleDbCommand
        '                        cmd1.Connection = conn
        '                        cmd1.CommandText = "delete from stuffdata"

        '                        Dim CmdB As New OleDb.OleDbCommand
        '                        CmdB.Connection = conn
        '                        CmdB.CommandText = "delete from BoxStuffData"

        '                        Dim CmdW As New OleDb.OleDbCommand
        '                        CmdW.Connection = conn
        '                        CmdW.CommandText = "delete from ArtData"

        '                        Dim CmdVtx As New OleDb.OleDbCommand
        '                        CmdVtx.Connection = conn
        '                        CmdVtx.CommandText = "delete from Vertex"
        'x:

        '                        Try
        '                            cmd1.ExecuteNonQuery()
        '                            CmdB.ExecuteNonQuery()
        '                            CmdW.ExecuteNonQuery()
        '                            CmdVtx.ExecuteNonQuery()
        '                        Catch ec As Exception
        '                            If ec.Message = "Cannot open any more tables." Then
        '                                conn.Close()
        '                                conn.Dispose()
        '                                OleDb.OleDbConnection.ReleaseObjectPool()
        '                                cmd1.Dispose()
        '                                GC.Collect()

        '                                conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\container.mdb;Persist Security Info=False"

        '                                conn.Open()
        '                                GoTo x
        '                            End If

        '                        End Try

        '                        'Stop

        '                        .ARC.AutoDraw(CurDir() & "First.wrl", 1, 0.5, "", "", 0, True, False, "container", 0, True, "b", "1")

        '                        Dim ard As New Area
        '                        Dim ard1 As New Area

        '                        'Stop

        '                        '#######################################
        '                        'Door 1 option begin 
        '                        '#######################################
        '                        If rdb1D.Checked = True Then

        '                            ard.StrtPt.x = .ARC.length
        '                            ard.StrtPt.y = 0
        '                            ard.StrtPt.z = 0
        '                            ard.length = 0.5
        '                            ard.width = .ARC.width
        '                            ard.height = .ARC.height

        '                            If DbxFlg Then
        '                                DbxFlgO = True
        '                            Else
        '                                DbxFlgO = False
        '                            End If

        '                            ard.AutoDraw(CurDir() & "\First.wrl", "", 0, "file:///c:\contdoor.png", "", 0, True, False, "door", 0, False, "b", "1")

        '                            ard1.StrtPt.x = .ARC.length - 0.01
        '                            ard1.StrtPt.y = 0
        '                            ard1.StrtPt.z = 0
        '                            ard1.length = 0.5
        '                            ard1.width = ard.width
        '                            ard1.height = ard.height

        '                            'Stop
        '                            If DbxFlg Then
        '                                DbxFlgO = True
        '                            Else
        '                                DbxFlgO = False
        '                            End If

        '                            ard1.AutoDraw(CurDir() & "First.wrl", "b", 0, "file:///c:\contdoor.png", "", 0, True, False, "door1", 0, False, "b", "1")

        '                            DbxFlgO = False

        '                        End If
        '                        '#######################################
        '                        'Door 1 option End 
        '                        '#######################################

        '                        'Stop

        '                        '#######################################
        '                        'Door 2 option begin 
        '                        '#######################################

        '                        '$$$$$
        '                        'First half door begin 
        '                        '$$$$$

        '                        If rdb2D.Checked = True Then

        '                            ard.StrtPt.x = .ARC.length
        '                            ard.StrtPt.y = 0
        '                            ard.StrtPt.z = 0
        '                            ard.length = 0.5
        '                            ard.width = .ARC.width * 0.5
        '                            ard.height = .ARC.height

        '                            If DbxFlg Then
        '                                DbxFlgO = True
        '                            Else
        '                                DbxFlgO = False
        '                            End If

        '                            ard.AutoDrawBxDrOpn1(CurDir() & "\First.wrl", "", 0, "file:///c:\contdoor.png", "", 0, True, False, "door", 0, False, "b")                                 'ard.AutoDraw(CurDir() & "\Box.wrl", "", 0, "file:///c:\contdoor.png", "", 0, True, False, "door", 0, False, "b")

        '                            ard1.StrtPt.x = .ARC.length - 0.01
        '                            ard1.StrtPt.y = 0
        '                            ard1.StrtPt.z = 0
        '                            ard1.length = 0.5
        '                            ard1.width = ard.width
        '                            ard1.height = ard.height

        '                            'Stop

        '                            If DbxFlg Then
        '                                DbxFlgO = True
        '                            Else
        '                                DbxFlgO = False
        '                            End If

        '                            ard.AutoDrawBxDrOpn1(CurDir() & "\First.wrl", "", 0, "file:///c:\contdoor.png", "", 0, True, False, "door", 0, False, "b")                                 'ard1.AutoDraw(CurDir() & "Box.wrl", "b", 0, "file:///c:\contdoor.png", "", 0, True, False, "door1", 0, False, "b")

        '                            DbxFlgO = False

        '                            '$$$$$
        '                            'First half door end 
        '                            '$$$$$
        '                            'Stop

        '                            '################################################################

        '                            '$$$$$
        '                            'Second half door begin 
        '                            '$$$$$

        '                            'Stop

        '                            ard.StrtPt.x = .ARC.length
        '                            ard.StrtPt.y = 0
        '                            ard.StrtPt.z = 0
        '                            ard.length = 0.5
        '                            ard.width = .ARC.width * 0.5
        '                            ard.height = .ARC.height

        '                            If DbxFlg Then
        '                                DbxFlgO = True
        '                            Else
        '                                DbxFlgO = False
        '                            End If

        '                            ard.AutoDrawBxDrOpn2(CurDir() & "\First.wrl", "", 0, "file:///c:\contdoor.png", "", 0, True, False, "door", 0, False, "b")

        '                            ard1.StrtPt.x = .ARC.length - 0.01
        '                            ard1.StrtPt.y = 0
        '                            ard1.StrtPt.z = 0
        '                            ard1.length = 0.5
        '                            ard1.width = ard.width
        '                            ard1.height = ard.height

        '                            'Stop

        '                            If DbxFlg Then
        '                                DbxFlgO = True
        '                            Else
        '                                DbxFlgO = False
        '                            End If

        '                            ard.AutoDrawBxDrOpn2(CurDir() & "\First.wrl", "", 0, "file:///c:\contdoor.png", "", 0, True, False, "door", 0, False, "b")

        '                            DbxFlgO = False

        '                            '$$$$$
        '                            'First half door end 
        '                            '$$$$$

        '                        End If

        '                        '#######################################
        '                        'Door 2 option End 
        '                        '#######################################

        '                        'Stop

        '                        Bstrtclr = "r"

        '                        'Stop

        '                    Else

        '                        putqty = 0
        '                        For i As Integer = 0 To matchidx - 1
        '                            putqty += qtyarr1(i).qty
        '                        Next
        '                        stk.Clear()

        '                        If matchidx <> -1 Then
        '                            For i As Integer = 0 To qtyarr(matchidx - 1).stk.Count - 1
        '                                stk.Add(qtyarr(matchidx - 1).stk(i))
        '                            Next
        '                        End If

        '                        'Stop
        '                        .ARC.AutoDraw(CurDir() & "\First.wrl", 1, 0.5, "", "", 0, True, False, "container", 0, True, "b", "1")
        '                        Dim ard As New Area
        '                        ard.StrtPt.x = .ARC.length
        '                        ard.StrtPt.y = 0
        '                        ard.StrtPt.z = 0
        '                        ard.length = 0.5
        '                        ard.width = .ARC.width
        '                        ard.height = .ARC.height

        '                        'Stop
        '                        ard.AutoDraw(CurDir() & "\First.wrl", "", 0, "file:///c:\contdoor.png", "", 0, True, False, "door", 0, False, "b", "1")
        '                        Dim ard1 As New Area
        '                        ard1.StrtPt.x = .ARC.length - 0.01
        '                        ard1.StrtPt.y = 0
        '                        ard1.StrtPt.z = 0
        '                        ard1.length = 0.5
        '                        ard1.width = ard.width
        '                        ard1.height = ard.height

        '                        'Stop

        '                        ard1.AutoDraw(CurDir() & "First.wrl", "b", 0, "file:///c:\contdoor.png", "", 0, True, False, "door1", 0, False, "b", "1")
        '                        Dim col1 As String = "r"
        '                        Bplclst.Clear()
        '                        Bqtylst.Clear()
        '                        Dim qtyx As Integer = 0
        '                        qtyarr.Clear()
        '                        Dim ahistarr1 As New List(Of r1)

        '                        ahistarr1.Clear()
        '                        'Form8.Label1.Text = "Please wait ....."
        '                        'Form8.Label2.Text = ""
        '                        'Form8.Button1.Visible = False
        '                        'Form8.Show()

        '                        btnStatus.Visible = False
        '                        lblStatus.Visible = True
        '                        lblStatusINm.Visible = True

        '                        pbCSP1.Visible = True
        '                        ProgressBarRunning()

        '                        lblStatus.Text = "Please wait ....."

        '                        If dgv1.CurrentCell.ColumnIndex = 12 Then
        '                            showemp = False
        '                        ElseIf dgv1.CurrentCell.ColumnIndex = 13 Then
        '                            showemp = True
        '                        End If

        '                        If stk.Count = 0 Then

        '                            If showemp Then
        '                                MsgBox("Container Is Fully Occupied. No Empty Area Left", MsgBoxStyle.Critical + vbOKOnly)
        '                                Exit Function
        '                            End If

        '                        End If

        '                        Dim ar11 As New Area

        '                        For i As Integer = 0 To stk.Count - 1

        '                            ar11 = stk(i)
        '                            If showemp Then

        '                                ar11.AutoDraw(CurDir() & "First.wrl", "r", 0, "", CStr(i + 1), 0, False, True, "E", 0, False, "b", "1")

        '                            End If

        '                        Next

        '                        If showemp Then

        '                            Try
        '                                Closef(CurDir() & "\First.wrl")
        '                                'Form8.Close()

        '                                lblStatus.Visible = False
        '                                lblStatusINm.Visible = False
        '                                btnStatus.Visible = False

        '                                pbCSP1.Visible = False

        '                                Eventless()

        '                                '#################@@@@@@@@@@@@@@@@@@@@@@@@@@

        '                                'ThreeDViewer()
        '                                '#################@@@@@@@@@@@@@@@@@@@@@@@@@@
        '                                'Dim RsultStr As String

        '                                '##############

        '                                Try

        '                                    Dim FName As String = CurDir() & "\First.wrl"
        '                                    Process.Start("c:\Program Files\Alteros 3D\alteros.exe", FName)

        '                                Catch Err As Exception
        '                                    MsgBox(Err.Message)
        '                                    MsgBox(Err.ToString)
        '                                    MessageBox.Show("Error in Alteros 3D running", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '                                    conn.Close()
        '                                    off.Close()
        '                                    MessageBox.Show("Error in ShowButton", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '                                    MsgBox("Exit Application")
        '                                    Application.Exit()
        '                                End Try

        '                                '##############

        '                                'RsultStr = MsgBox("Do you show stuffing in three dimensional (Isometric) view ?", MsgBoxStyle.YesNo, "3DViewer")
        '                                'If RsultStr = MsgBoxResult.Yes Then

        '                                '    ThreeDViewer() ' (3D)Three Dimentional Arrangement are shown 
        '                                'Else
        '                                '    Dim Str As String

        '                                '    Str = MsgBox("Do you close stuffing entry?", MsgBoxStyle.YesNo, "Stuffing Entry ...")
        '                                '    If Str = MsgBoxResult.Yes Then
        '                                '        Me.Close()
        '                                '    Else
        '                                '        Me.Focus()
        '                                '    End If
        '                                'End If
        '                                'ThreeDViewer() ' (3D)Three Dimentional Arrangement are shown 
        '                                '#################@@@@@@@@@@@@@@@@@@@@@@@@@@

        '                            Catch Ex As Exception
        '                                MsgBox(Ex.Message)
        '                                MsgBox(Ex.ToString)
        '                                MsgBox(Ex.Message, MsgBoxStyle.Critical, "Message :: In method 'MouseClick'  " & vbCrLf & "VRML Programme Running is failure!")
        '                                Me.Close()

        '                            Finally
        '                                'Form8.Close()

        '                                lblStatus.Visible = False
        '                                lblStatusINm.Visible = False
        '                                btnStatus.Visible = False

        '                                pbCSP1.Visible = False

        '                                Eventless()
        '                            End Try

        '                            Exit Function
        '                        End If

        '                        Bitemno = 0

        '                        For i As Integer = 0 To putqty - 1
        '                            qtyx += 1
        '                            Bahistarr(i).ar.AutoDraw(CurDir() & "First.wrl", col1, 0, "file\\\c:\t2.png", Bahistarr(i).itmnm, 0, False, True, "", Bahistarr(i).method, False, "b", "1")
        '                            ahistarr1.Add(Bahistarr(i))
        '                            If i = putqty - 1 Then
        '                                plclst1.Add(qtyx)

        '                                Bqtylst.Add(qtyx)

        '                                Dim m1 As New e1
        '                                m1.itmnm = Bahistarr(i).itmnm
        '                                m1.qty = qtyx
        '                                m1.stk = Bahistarr(i).stk
        '                                qtyarr.Add(m1)

        '                                qtyx = 0
        '                                Exit For

        '                            End If

        '                            If Bahistarr(i).itmnm <> Bahistarr(i + 1).itmnm Then

        '                                Bitemno += 1
        '                                If col1 = "r" Then
        '                                    col1 = "g"
        '                                ElseIf col1 = "g" Then
        '                                    col1 = "b"
        '                                ElseIf col1 = "b" Then
        '                                    col1 = "m"
        '                                ElseIf col1 = "m" Then
        '                                    col1 = "c"
        '                                ElseIf col1 = "c" Then
        '                                    col1 = "y"
        '                                End If
        '                                plclst1.Add(qtyx)
        '                                Bqtylst.Add(qtyx)

        '                                Dim m1 As New e1
        '                                m1.itmnm = Bahistarr(i).itmnm
        '                                m1.qty = qtyx
        '                                m1.stk = Bahistarr(i).stk
        '                                qtyarr.Add(m1)
        '                                qtyx = 0

        '                            End If
        '                        Next

        '                        Bitemno += 1
        '                        'Form8.Close()

        '                        lblStatus.Visible = False
        '                        lblStatusINm.Visible = False
        '                        btnStatus.Visible = False

        '                        pbCSP1.Visible = False

        '                        Eventless()

        '                        Bahistarr.Clear()
        '                        For i As Integer = 0 To ahistarr1.Count - 1
        '                            Bahistarr.Add(ahistarr1(i))
        '                        Next

        '                        Bplclst.Clear()
        '                        For i As Integer = 0 To Bqtylst.Count - 1
        '                            Bplclst.Add(Bqtylst(i) - 1)
        '                        Next

        '                        If col1 = "r" Then
        '                            col1 = "g"
        '                        ElseIf col1 = "g" Then
        '                            col1 = "b"
        '                        ElseIf col1 = "b" Then
        '                            col1 = "m"
        '                        ElseIf col1 = "m" Then
        '                            col1 = "c"
        '                        ElseIf col1 = "c" Then
        '                            col1 = "y"
        '                        End If
        '                        Bstrtclr = col1
        '                        'Stop

        '                    End If
        '                    '*************
        '                    'Stop
        '                    '*************
        '                    Dim Stk1 As New List(Of Area)
        '                    Dim Stk2 As New List(Of Area)

        '                    Dim qtyf As Boolean = False
        '                    Dim rowlvflg As Boolean = False
        '                    Dim stp As Integer
        '                    Dim cntm As Integer = 1
        '                    Dim totqty = 25
        '                    Dim totqty1 As Integer = 0
        '                    Dim drwstp As Integer

        '                    Dim cntflg As Boolean = False

        '                    Dim flg1 As Boolean = True

        '                    Dim button1flag As Boolean = False
        '                    Dim Itmnm As String
        '                    Dim SLbl As String

        '                    button1flag = True
        '                    Dim cnt As Integer = 0
        '                    Dim dupflg As Boolean = False

        '                    cnt = 0

        '                    Dim ar() As Area

        '                    Dim ari() As String
        '                    Dim arwt() As Single
        '                    Dim ar1 As New Area
        '                    Dim ln As Double
        '                    Dim wd As Double
        '                    Dim ht As Double
        '                    Dim qty As Integer
        '                    Dim seq As Integer
        '                    Dim wt As String
        '                    Dim transparr() As Boolean
        '                    Dim transp As Boolean
        '                    Dim topup() As Boolean
        '                    Dim Tpup As Boolean

        '                    ReDim ar(0)
        '                    ReDim ari(0)
        '                    ReDim arwt(0)
        '                    ReDim transparr(0)
        '                    ReDim topup(0)
        '                    ReDim arl(0)

        '                    Dim cmd As New OleDb.OleDbCommand

        '                    Dim cntx As Integer = 0

        '                    Dim plcqty As Integer = 0

        '                    Dim k As Integer
        '                    Dim m As Integer

        '                    DelTab("temp1")

        '                    If CmbContainer.Text = "" Then
        '                        MsgBox("Container not selected", MsgBoxStyle.Critical + vbOKOnly)
        '                        MessageBox.Show("Container not selected", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '                        CmbContainer.Focus()
        '                        Exit Function
        '                    End If

        '                    'Form8.Label1.Text = "Please wait ....."
        '                    'Form8.Label2.Text = ""
        '                    'Form8.Button1.Visible = False
        '                    btnStatus.Visible = False
        '                    'Form8.Show()

        '                    lblStatus.Text = "Please wait ....."
        '                    lblStatus.Visible = True
        '                    lblStatusINm.Visible = True
        '                    btnStatus.Visible = False

        '                    pbCSP1.Visible = True
        '                    ProgressBarRunning()

        '                    System.Windows.Forms.Application.DoEvents()

        '                    Dim i1, j1 As Integer
        '                    Dim extflg As Boolean = False

        '                    Dim zz As Integer

        '                    zz = rowno1

        '                    Dim matchidx1 As Integer
        '                    If matchidx = -1 Then
        '                        matchidx1 = 0
        '                    Else
        '                        matchidx1 = matchidx
        '                    End If

        '                    'Stop

        '                    Try

        '                        If Not ADclFlg Then

        '                            For i1 = matchidx1 To zz

        '                                Itmnm = dgv1.Item(1, i1).Value
        '                                ln = Math.Round(dgv1.Item(4, i1).Value, 4)
        '                                wd = Math.Round(dgv1.Item(5, i1).Value, 4)
        '                                ht = Math.Round(dgv1.Item(6, i1).Value, 4)
        '                                qty = dgv1.Item(11, i1).Value

        '                                wt = dgv1.Item(8, i1).Value
        '                                seq = dgv1.Item(0, i1).Value

        '                                transp = False

        '                                Tpup = IIf(dgv1.Item(7, i1).Value = "6", False, True)

        '                                Bqtylst.Add(qty)

        '                                'Stop

        '                                For j1 = 0 To qty - 1

        '                                    totqty1 += 1

        '                                    qtyf = True

        '                                    ar1.length = ln
        '                                    ar1.width = wd
        '                                    ar1.height = ht
        '                                    ar1.StrtPt.x = 0
        '                                    ar1.StrtPt.y = 0
        '                                    ar1.StrtPt.z = 0
        '                                    ar(UBound(ar)) = New Area
        '                                    ar(UBound(ar)).length = ar1.length
        '                                    ar(UBound(ar)).width = ar1.width
        '                                    ar(UBound(ar)).height = ar1.height
        '                                    ari(UBound(ari)) = Itmnm
        '                                    arwt(UBound(arwt)) = wt
        '                                    transparr(UBound(transparr)) = transp
        '                                    topup(UBound(topup)) = Tpup

        '                                    ReDim Preserve ar(UBound(ar) + 1)
        '                                    ReDim Preserve ari(UBound(ari) + 1)
        '                                    ReDim Preserve arwt(UBound(arwt) + 1)
        '                                    ReDim Preserve transparr(UBound(transparr) + 1)
        '                                    ReDim Preserve topup(UBound(topup) + 1)

        '                                Next

        '                            Next i1

        '                            'Stop

        '                            '!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        '                        Else
        '                            '!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!D

        '                            For i1 = matchidx1 To zz

        '                                Itmnm = dgv1.Item(1, i1).Value
        '                                ln = Math.Round(dgv1.Item(4, i1).Value, 4)
        '                                wd = Math.Round(dgv1.Item(5, i1).Value, 4)
        '                                ht = Math.Round(dgv1.Item(6, i1).Value, 4)
        '                                qty = dgv1.Item(11, i1).Value

        '                                wt = dgv1.Item(8, i1).Value
        '                                seq = dgv1.Item(0, i1).Value
        '                                SLbl = dgv1.Item(15, i1).Value

        '                                If SLbl = Nothing Then
        '                                    SLbl = Itmnm
        '                                End If

        '                                transp = False

        '                                Tpup = IIf(dgv1.Item(7, i1).Value = "6", False, True)

        '                                Bqtylst.Add(qty)

        '                                'Stop

        '                                For j1 = 0 To qty - 1

        '                                    totqty1 += 1

        '                                    qtyf = True

        '                                    ar1.length = ln
        '                                    ar1.width = wd
        '                                    ar1.height = ht
        '                                    ar1.StrtPt.x = 0
        '                                    ar1.StrtPt.y = 0
        '                                    ar1.StrtPt.z = 0
        '                                    ar(UBound(ar)) = New Area
        '                                    ar(UBound(ar)).length = ar1.length
        '                                    ar(UBound(ar)).width = ar1.width
        '                                    ar(UBound(ar)).height = ar1.height
        '                                    ari(UBound(ari)) = Itmnm
        '                                    arwt(UBound(arwt)) = wt
        '                                    transparr(UBound(transparr)) = transp
        '                                    topup(UBound(topup)) = Tpup
        '                                    arl(UBound(arl)) = SLbl

        '                                    ReDim Preserve ar(UBound(ar) + 1)
        '                                    ReDim Preserve ari(UBound(ari) + 1)
        '                                    ReDim Preserve arwt(UBound(arwt) + 1)
        '                                    ReDim Preserve transparr(UBound(transparr) + 1)
        '                                    ReDim Preserve topup(UBound(topup) + 1)
        '                                    ReDim Preserve arl(UBound(arl) + 1)

        '                                Next

        '                            Next i1

        '                            'Stop
        '                            '!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!D

        '                        End If

        '                    Catch Err As Exception
        '                        MsgBox(Err.Message)
        '                        MsgBox(Err.ToString)
        '                        MessageBox.Show("Error in Datagrid entry looping entry to stuffing assigning", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '                    End Try

        '                    Bplclstf.Clear()
        '                    For i As Integer = 0 To Bplclst.Count - 1
        '                        Bplclstf.Add(Bplclst(i) + 1)
        '                    Next

        '                    For m = 0 To Bplclstf.Count - 1
        '                        If Bplclstf(m) = 0 Then
        '                            k = m - 1
        '                            Exit For
        '                        End If
        '                    Next

        '                    If k = 0 Then
        '                        k = m - 1
        '                    End If

        '                    If k = 0 Then
        '                        k = m + 1
        '                    End If

        '                    totqty = 0
        '                    For i As Integer = 0 To Bqtylst.Count - 1
        '                        totqty = totqty + Bqtylst(i)
        '                    Next

        '                    plcqty = 0
        '                    For i As Integer = 0 To Bplclstf.Count - 1
        '                        plcqty = plcqty + Bplclstf(i) - 1
        '                    Next

        '                    ReDim Preserve ar(UBound(ar) - 1)
        '                    ReDim Preserve ari(UBound(ari) - 1)
        '                    ReDim Preserve arwt(UBound(arwt) - 1)
        '                    ReDim Preserve transparr(UBound(transparr) - 1)
        '                    ReDim Preserve topup(UBound(topup) - 1)

        '                    If ADclFlg Then
        '                        ReDim Preserve arl(UBound(arl) - 1)
        '                    End If

        '                    stp += 1

        '                    Dim ar2() As Area
        '                    Dim ari2() As String
        '                    Dim arwt2() As Single
        '                    Dim transparr2() As Boolean

        '                    ReDim ar2(0)
        '                    ReDim ari2(0)
        '                    ReDim arwt2(0)
        '                    ReDim transparr2(0)

        '                    '*************
        '                    'Stop
        '                    '*************
        '                    For i As Integer = LBound(ar) To UBound(ar)

        '                        ar2(UBound(ar2)) = ar(i)
        '                        ari2(UBound(ari2)) = ari(i)
        '                        arwt2(UBound(arwt2)) = arwt(i)
        '                        transparr2(UBound(transparr2)) = transparr(i)
        '                        ReDim Preserve ar2(UBound(ar2) + 1)
        '                        ReDim Preserve ari2(UBound(ari2) + 1)
        '                        ReDim Preserve arwt2(UBound(arwt2) + 1)
        '                        ReDim Preserve transparr2(UBound(transparr2) + 1)
        '                        ReDim Preserve topup(UBound(topup) + 1)

        '                    Next

        '                    ReDim Preserve ar2(UBound(ar2) - 1)
        '                    ReDim Preserve ari2(UBound(ari2) - 1)
        '                    ReDim Preserve arwt2(UBound(arwt2) - 1)
        '                    ReDim Preserve transparr2(UBound(transparr2) - 1)

        '                    Try
        '                        ReDim Preserve topup(UBound(topup) - 1)
        '                    Catch

        '                    End Try

        '                    '*************
        '                    'Stop
        '                    '*************
        '                    If stp = dgv1.RowCount Then
        '                        stp = 0
        '                        cnt = 0
        '                    End If

        '                    .ARC.StrtPt.x = 0
        '                    .ARC.StrtPt.y = 0
        '                    .ARC.StrtPt.z = 0
        '                    ''.ARC.length = contarr(0)
        '                    ''.ARC.width = contarr(1)
        '                    ''.ARC.height = contarr(2)

        '                    .ARC.length = CL
        '                    .ARC.width = CW
        '                    .ARC.height = CH

        '                    qty = 0
        '                    'Form8.Close()

        '                    lblStatus.Visible = False
        '                    lblStatusINm.Visible = False
        '                    btnStatus.Visible = False

        '                    pbCSP1.Visible = False

        '                    Eventless()

        '                    'Stop

        '                    Dim outfile As String = CurDir() & "\First.wrl"

        '                    Try

        '                        Xl3d = 0        'Initialising the optimum stuff
        '                        Yl3d = 0
        '                        Zl3d = 0

        '                        RiCnt = 0
        '                        flg_RiCnt = False

        '                        If conn.State = ConnectionState.Closed Then conn.Open()

        '                        Dim Cmdo As New OleDb.OleDbCommand
        '                        Cmdo.Connection = conn
        '                        Cmdo.CommandText = "delete from pgRecord"
        '                        Cmdo.ExecuteNonQuery()

        '                        Dim CmdOp As New OleDb.OleDbCommand
        '                        CmdOp.Connection = conn
        '                        CmdOp.CommandText = "delete from pgCord"
        '                        CmdOp.ExecuteNonQuery()

        '                    Catch ex As Exception
        '                        MsgBox(ex.Message)
        '                        MsgBox(ex.ToString)
        '                        MessageBox.Show("Error in OptStuff Module", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '                    End Try


        '                    If ar.Length > 0 Then
        '                        If stk.Count = 0 Then stk.Add(.ARC)
        '                        Bitemqty = 0
        '                        Bplclst.Clear()
        '                        Btxtopt = False

        '                        'Stop

        '                        If dgv1.CurrentCell.ColumnIndex = 12 Then

        '                            If chkbxWadStuff.Checked Then

        '                                '###########################################
        '                                Try

        '                                    'MessageBox.Show("Work in progress wad stuff is done", "Wad stuff info.....", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '                                    'Stop
        '                                    'Stk2 = WadBoxStuff(.ARC, ar2, ari2, arwt2, False, False, outfile, True, transparr2, topup, Btxtopt, True, False, True, colarr)

        '                                    Stk2 = BoxStuff(.ARC, ar2, ari2, arwt2, False, False, outfile, True, transparr2, topup, Btxtopt, True, False, True, colarr)

        '                                    mClk = False

        '                                    'Stk2 = Stuffx(.ARC, ar2, ari2, arwt2, False, False, outfile, True, transparr2, topup, Btxtopt, True, False, True, colarr)
        '                                    'LibWrapper.stuff(.ARC, ar2, ari2, arwt2, False, False, outfile, True, transparr2, topup, Btxtopt, True, False, True, colarr)

        '                                    GoTo BxStfEnd

        '                                Catch ex As Exception
        '                                    MsgBox(ex.Message)
        '                                    MsgBox(ex.ToString)
        '                                    MessageBox.Show("Error in Stuff", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '                                End Try

        '                                '###########################################

        '                            End If

        '                            If chkBxPlyStuff.Checked Then

        '                                Try

        '                                    '$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

        '                                    Dim PlyAr As New Area
        '                                    Dim RemAr As New Area
        '                                    Dim PlyCnt As Integer
        '                                    Dim Grt As Double

        '                                    PlyAr.StrtPt.x = 0
        '                                    PlyAr.StrtPt.y = 0
        '                                    PlyAr.StrtPt.z = 0

        '                                    For i As Integer = 0 To dgv1.RowCount - 2

        '                                        qty = dgv1.Item(11, i).Value            'qty = dgv1.Item(11, 0).Value

        '                                        PlyAr.length = Math.Round(dgv1.Item(4, i).Value, 4)         'PlyAr.length = Math.Round(dgv1.Item(4, 0).Value, 4)
        '                                        PlyAr.width = Math.Round(dgv1.Item(5, i).Value, 4)          'PlyAr.width = Math.Round(dgv1.Item(5, 0).Value, 4)
        '                                        PlyAr.height = Math.Round(dgv1.Item(6, i).Value, 4)         'PlyAr.height = Math.Round(dgv1.Item(6, 0).Value, 4)

        '                                        Itmnm = dgv1.Item(1, i).Value           'Itmnm = dgv1.Item(1, 0).Value

        '                                        PlyCnt = StuffPly(.ARC, PlyAr, True, True, qty, Itmnm)

        '                                        RemAr = PlyDrwLst(PlyCnt - 1)

        '                                        Dim Lp As Double
        '                                        Dim Wp As Double
        '                                        Dim Hp As Double

        '                                        Lp = PlyAr.length
        '                                        Wp = PlyAr.width
        '                                        Hp = PlyAr.height

        '                                        Grt = Greater(Lp, Wp, Hp)

        '                                        If Grt = Nothing Then
        '                                            Grt = PlyAr.length
        '                                        End If

        '                                        PlyAr.StrtPt.x = RemAr.StrtPt.x + Grt               'PlyAr.StrtPt.x = RemAr.StrtPt.x + PlyAr.length '
        '                                        PlyAr.StrtPt.y = 0
        '                                        PlyAr.StrtPt.z = 0

        '                                    Next i

        '                                    'Stop

        '                                    Dim ItmPlaced As Int64 = (PlyCnt - 1).ToString

        '                                    MessageBox.Show("In Ply Stuff  out of  " & qty & "  quantity only  " & ItmPlaced & "  placed", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

        '                                    'MsgBox((PlyCnt - 1).ToString & " Items placed")

        '                                    PlyCnt = 0

        '                                    Closef(outfile)

        '                                    '$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

        '                                Catch Exx As Exception
        '                                    MsgBox(Exx.Message)
        '                                    MsgBox(Exx.ToString)
        '                                    MessageBox.Show("Error in Plystuff ShowButton", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '                                End Try

        '                                GoTo PlyEnd
        '                            End If

        '                            If ADclFlg Then
        '                                BoxLBLStuff(.ARC, ar2, ari2, arl, arwt2, False, False, outfile, True, transparr2, topup, Btxtopt, True, False, True, colarr)
        '                                GoTo BxStfEnd
        '                            End If

        '                            If chkBxSlideStuff.Checked Or chkbxOptStuff.Checked Or chkbxManualChng.Checked Then
        '                                MoveBoxStuff(.ARC, ar2, ari2, arwt2, False, False, outfile, True, transparr2, topup, Btxtopt, True, False, True, colarr)
        '                                GoTo BxStfEnd
        '                            End If

        '                            'If chkbxOptStuff.Checked Then
        '                            '    BoxStuff_Optm(.ARC, ar2, ari2, arwt2, False, False, outfile, True, transparr2, topup, Btxtopt, True, False, True, colarr)
        '                            'End If

        '                            If Not CheckBox1.Checked AndAlso Not chkBxSlideStuff.Checked Then

        '                                Stk2 = BoxStuff(.ARC, ar2, ari2, arwt2, False, False, outfile, True, transparr2, topup, Btxtopt, True, False, True, colarr)

        '                            ElseIf CheckBox1.Checked Then

        '                                Dim ar12 As New Area

        '                                qty = dgv1.Item(11, 0).Value

        '                                ar12.StrtPt.x = 0
        '                                ar12.StrtPt.y = 0
        '                                ar12.StrtPt.z = 0
        '                                ar12.length = Math.Round(dgv1.Item(4, 0).Value, 4)
        '                                ar12.width = Math.Round(dgv1.Item(5, 0).Value, 4)
        '                                ar12.height = Math.Round(dgv1.Item(6, 0).Value, 4)

        '                                Dim pt As New Point
        '                                pt.x = ar1.length
        '                                pt.y = ar1.width
        '                                pt.z = ar1.height

        '                                Itmnm = dgv1.Item(1, 0).Value

        '                                '*********
        '                                'Stop
        '                                '*********
        '                                Dim hg As Integer = 0


        '                                totqty = 0

        '                                hg = Stuffy(.ARC, ar12, True, True, qty, Itmnm)

        '                                qty = 0

        '                                MsgBox((hg - 1).ToString & " Items placed", , Me.Text)

        '                                hg = 0

        '                                Closef(outfile)

        '                            End If
        '                            showemp = True

        '                        End If

        'BxStfEnd:
        '                        '****************
        '                        ' Stop
        '                        '****************
        '                        Dim emvol As Double = 0
        '                        For kk As Integer = 0 To stk.Count - 1
        '                            emvol = emvol + (stk(kk).length * stk(kk).width * stk(kk).height)
        '                        Next
        '                        emvol = emvol * (0.0254 * 0.0254 * 0.0254)
        '                        TxtFreeCbm.Text = Format(emvol, "0.000")
        '                        TxtOccuCbm.Text = Format((CDbl(TxtCapacity.Text) - CDbl(TxtFreeCbm.Text)), "0.000")
        '                        If dgv1.CurrentCell.ColumnIndex = 12 Then
        '                            showemp = False
        '                        ElseIf dgv1.CurrentCell.ColumnIndex = 13 Then
        '                            showemp = True
        '                        End If
        '                        Dim mn As Integer = 0

        '                        Dim are As Area
        '                        stkmm.Clear()
        '                        Dim vol1 As Double
        '                        For jjj As Integer = 0 To Stk2.Count - 1
        '                            vol1 = vol1 + (Stk2(jjj).length * Stk2(jjj).width * Stk2(jjj).height)
        '                        Next
        '                        For rr As Integer = 0 To Stk2.Count - 1
        '                            are = New Area
        '                            are.StrtPt.x = Stk2(rr).StrtPt.x
        '                            are.StrtPt.y = Stk2(rr).StrtPt.y
        '                            are.StrtPt.z = Stk2(rr).StrtPt.z
        '                            are.length = Stk2(rr).length
        '                            are.width = Stk2(rr).width
        '                            are.height = Stk2(rr).height
        '                            stkmm.Add(are)
        '                        Next

        '                        stk.Clear()
        '                        ReDim ar2(0)
        '                        ReDim ar2(0)
        '                        ReDim ari2(0)
        '                        ReDim arwt2(0)
        '                        ReDim transparr2(0)
        '                        ReDim topup(0)

        '                        For i As Integer = 0 To Bitemno

        '                            If CInt(dgv1.Item(11, i).Value) > Bqtylst(i) + 1 Then
        '                                Dim qtyv As Integer
        '                                If Bqtylst(i) <= 0 Then
        '                                    qtyv = 0
        '                                Else
        '                                    qtyv = Bqtylst(i) + 1
        '                                End If
        '                                'MsgBox(dgv1.Item(11, i).Value.ToString & " no of " & dgv1.Item(1, i).Value & " cannot be placed." & vbCrLf & CStr(qtyv) & " placed.", MsgBoxStyle.Information + vbOKOnly)

        '                                MessageBox.Show(dgv1.Item(11, i).Value.ToString & " no of " & dgv1.Item(1, i).Value & " cannot be placed. " & vbCrLf & CStr(qtyv) & " placed.", "Stuffing Entry", MessageBoxButtons.OK)

        '                                dgv1.Item(11, i).Value = qtyv

        '                                drwstp = drwstp - Bqtylst(i) + Bplclst(i) + 1
        '                                Bqtylst(i) = Bplclst(i) + 1

        '                            End If
        '                        Next

        '                        If Not CheckBox1.Checked Then

        '                            TxtOccuKgs.Text = Format(CDbl(dgv1.Item(8, dgv1.CurrentCell.RowIndex).Value) * (Bplclst(CInt(dgv1.CurrentCell.RowIndex)) + 1), "0.000")
        '                            TxtFreeKgs.Text = Format(CDbl(TxtPayLoad.Text) - CDbl(TxtOccuKgs.Text), "0.000")

        '                            For i As Integer = 0 To rowno1
        '                                Dim qtyv As Integer = Bplclst(i)
        '                                qtyv += 1
        '                                If CheckBox1.Checked = True Then
        '                                    If fullflag Then
        '                                        'qtyv = xcnt - 1
        '                                        qtyv = xcnt
        '                                    Else
        '                                        qtyv = xcnt
        '                                    End If
        '                                End If
        '                                If CInt(dgv1.Item(11, i).Value) > qtyv Then
        '                                    'MsgBox(dgv1.Item(11, i).Value.ToString & " no of " & dgv1.Item(1, i).Value & " cannot be placed." & vbCrLf & CStr(qtyv) & " placed.", MsgBoxStyle.Information + vbOKOnly)
        '                                    MessageBox.Show(dgv1.Item(11, i).Value.ToString & " no of " & dgv1.Item(1, i).Value & " cannot be placed." & vbCrLf & CStr(qtyv) & " placed.", "Stuffing Entry", MessageBoxButtons.OK)
        '                                    'dgv1.Item(11, i).Value = qtyv
        '                                End If

        '                            Next

        '                            Bplclstf.Clear()
        '                            For i As Integer = 0 To Bplclst.Count - 1
        '                                Bplclstf.Add(Bplclst(i) + 1)
        '                            Next
        '                            k = 0
        '                            For m = 0 To Bplclstf.Count - 1
        '                                If Bplclstf(m) = 0 Then
        '                                    k = m - 1
        '                                    Exit For
        '                                End If
        '                            Next

        '                            If k = 0 Then
        '                                k = m - 1
        '                            End If

        '                            totqty = 0
        '                            Dim bn As Integer
        '                            If matchidx = -1 Then
        '                                bn = 0
        '                            Else
        '                                bn = matchidx
        '                            End If
        '                            For i As Integer = 0 To Bqtylst.Count - 1
        '                                totqty = totqty + Bqtylst(i)
        '                            Next

        '                            plcqty = 0
        '                            For i As Integer = 0 To Bplclstf.Count - 1
        '                                plcqty = plcqty + Bplclstf(i)
        '                            Next

        'SBMCEnd:

        '                            Do While Not dgEmpty.RowCount = 0
        '                                Try
        '                                    dgEmpty.Rows.Remove(dgEmpty.Rows(0))
        '                                Catch
        '                                    Exit Do
        '                                End Try
        '                            Loop

        '                            Do While Not dgUsage.RowCount = 0

        '                                Try
        '                                    dgUsage.Rows.Remove(dgUsage.Rows(0))
        '                                Catch
        '                                    Exit Do
        '                                End Try
        '                            Loop

        '                            Call Button3_Click(Nothing, Nothing)
        '                            Closef(CurDir() & "\First.wrl")

        '                        End If
        '                    End If

        '                    Dim dq As Char = Chr(34)

        '                    'ThreeDViewer()
        '                    '#################@@@@@@@@@@@@@@@@@@@@@@@@@@
        '                    'Dim RsltStr As String
        '                    'Dim RsltSv As String

        '                    'RsltSv = MessageBox.Show("Auto file save ", "Stuff viewer Box file save", MessageBoxButtons.YesNo, MessageBoxIcon.Information)

        '                    'Dim dof As Stuff_Viewers = New Stuff_Viewers
        '                    'dof.DestroyOldFile("C:\CSP.Box.wrl")

        '                    ''If RsltSv = MsgBoxResult.Yes Then
        '                    'FinalOutPutWriter()
        '                    ''Else

        '                    'Stuff_Viewers.Show()
        '                    'Stuff_Viewers.Focus()
        '                    'End If

        '                    'RsltStr = MsgBox("Do you show stuffing in three dimensional (Isometric) view ?", MsgBoxStyle.YesNo, "3DViewer")
        '                    'If RsltStr = MsgBoxResult.Yes Then

        '                    '#####

        '                    'If chkBxAutoStuff.Checked Then                  'If Not chkBxAutoStuff.Checked Then
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
        '                    'End If

        '                    '#####

        '                    'ThreeDViewer() ' (3D)Three Dimentional Arrangement are shown 

        '                    'Else
        '                    'Dim Str As String

        '                    'Str = MsgBox("Do you close stuffing entry?", MsgBoxStyle.YesNo, "Stuffing Entry ...")
        '                    'If Str = MsgBoxResult.Yes Then
        '                    'Me.Close()
        '                    'Else
        '                    'Me.Focus()
        '                    ' End If

        '                    'ThreeDViewer() ' (3D)Three Dimentional Arrangement are shown 
        '                    '#################@@@@@@@@@@@@@@@@@@@@@@@@@@

        '                    Bplclst.Clear()
        '                    Bqtylst.Clear()
        '                    'End If
        '                End If

        '                '________________________________________________'SBMCEnd:

        '                'If chkBxAutoStuff.Checked Then
        '                '    MessageBox.Show("Auto arrangement stuff in randomly quantity managed is done ", "Container stuff Auto arrangement stuff info.....", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '                '    'off.Close()
        '                '    'Iow.Close()
        '                '    chkBxAutoStuff.Checked = False
        '                '    'Me.Column10.Width = 62
        '                '    Me.Column10.HeaderText = "USQt"
        '                '    dgv1.Refresh()
        '                '    ShowButton.Visible = False
        '                '    GoTo StfSrtAt
        '                'End If

        '            Catch Ex As Exception
        '                MsgBox(Ex.Message)
        '                MsgBox(Ex.ToString)
        '                MessageBox.Show("Error in ShowButton_MouseClick" & vbCrLf & "Programme Running is failure!", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '                Try
        '                    conn.Close()
        '                    off.Close()
        '                Catch
        '                    MsgBox("Fatal error..... , Exit Application")
        '                    Application.Exit()
        '                End Try
        '                MessageBox.Show("Fatal error in ShowButton", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '                MsgBox("Exit Application")
        '                Application.Exit()
        '            Finally
        '                Bplclst.Clear()
        '                Bqtylst.Clear()
        '                BoxStatusStriplbl.Text = "Pick the activity"
        '                mClk = False
        '            End Try

        '        End If


        '    End Function

        '    Private Sub dgv1_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles dgv1.Scroll

        '        ShowButton.Visible = False
        '        ShowButton.Top = 0
        '        ShowButton.Left = 0
        '        ShowButton.Width = 0
        '        ShowButton.Height = 0

        '        Try
        '            y1 = dgv1.Rows(0).Height * -(e.OldValue - e.NewValue)
        '            y2 = y2 - y1

        '            If ShowButton.Visible Then
        '                ShowButton.Top = ShowButton.Top - y1
        '            End If


        '        Catch ex As Exception
        '            MsgBox(ex.Message)
        '            MsgBox(ex.ToString)
        '            MessageBox.Show("Error in dgv1_Scroll", "Error....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        End Try


    End Sub

    Public Sub ShowStuffs(ByRef frmObj As TransactionMenu)

        With frmObj

            .lblCG.Visible = False
            .lblCGoffset.Visible = False
            .lblCG.Text = ""
            .lblCGoffset.Text = ""
            .lblBalWt.Text = ""

            System.Windows.Forms.Application.DoEvents()

            If Not mClk Then

                TransactionMenu.pbCSP1.Value = 0

                mClk = True
                .ShowButton.BackColor = Color.Plum

                StopFlg = False                               'The stop button stop flag is initialise

                stk.Clear()

                Xl3d = 0            'Initialising the value in optimum stuff
                Yl3d = 0
                Zl3d = 0
                Bitemno = 0
                Bqtylst.Clear()
                wad4flg = False


StfSrtAt:

                .BoxStatusStriplbl.Text = "Stuffing item is progress please wait."
                BitemqtyInr = 1

                Dim ans As MsgBoxResult

                Try
                    rwidx = .dgv1.CurrentCell.RowIndex
                Catch
                End Try

                Dim rowno1 As Integer = rwidx
                Dim plclst1 As New List(Of Integer)
                chkwt = True

                If .dgv1.Item(1, rowno1).Value Is Nothing _
            OrElse .dgv1.Item(11, rowno1).Value Is Nothing _
            OrElse Not IsNumeric(.dgv1.Item(11, rowno1).Value) _
            OrElse CInt(.dgv1.Item(11, rowno1).Value) <= 0 _
            OrElse .dgv1.Item(11, rowno1).Value.ToString.Contains(".") _
            Then
                    If .dgv1.CurrentCell.ColumnIndex <> 14 Then
                        MsgBox("Cannot show this item." & ControlChars.CrLf & "Item name not selected or quantity is invalid", MsgBoxStyle.Critical + vbOKOnly)
                        Exit Sub
                    End If

                End If

                If .dgv1.CurrentCell.ColumnIndex <> 14 Then

                    ans = MsgBoxResult.Yes
                    If ans = MsgBoxResult.Yes Then

                        For i As Integer = 0 To .dgv1.RowCount - 1

                            If .dgv1.Item(1, i).Value Is Nothing _
                            OrElse .dgv1.Item(8, i).Value Is Nothing _
                            OrElse .dgv1.Item(11, i).Value Is Nothing _
                            OrElse Not IsNumeric(.dgv1.Item(8, i).Value) _
                            OrElse Not IsNumeric(.dgv1.Item(11, i).Value) _
                            OrElse CInt(.dgv1.Item(8, i).Value) < 0 _
                            OrElse CInt(.dgv1.Item(11, i).Value) <= 0 _
                            OrElse .dgv1.Item(11, i).Value.ToString.Contains(".") _
                            OrElse .dgv1.Item(11, i).Value.ToString.Contains(".") _
                            Then

                                Try
                                    .dgv1.Rows.Remove(.dgv1.Rows(i))
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

                If .CmbContainer.Text = "" Then
                    MsgBox("Container not selected", MsgBoxStyle.Critical + vbOKOnly)
                    .CmbContainer.Focus()
                    Exit Sub
                End If

                Bitemno = 0
                Dim e3 As New e1

                Dim qtyarr1 As New List(Of e1)
                qtyarr1.Clear()

                Try
                    For i As Integer = 0 To rowno1
                        e3.itmnm = .dgv1.Item(1, i).Value
                        e3.qty = .dgv1.Item(11, i).Value
                        qtyarr1.Add(e3)
                    Next
                Catch
                End Try

                Dim putqty As Integer

                Dim matchidx As Integer = -1
                .TxtFreeCbm.Clear()
                .TxtOccuCbm.Clear()
                .TxtpercentVolOcc.Clear()
                .txtCompactPer.Clear()

                Dim ptx As New Point

                ptx.x = CL
                ptx.y = CW
                ptx.z = CH

                .arc.length = ptx.x
                .arc.width = ptx.y
                .arc.height = ptx.z

                Lbc = ptx.x
                Wbc = ptx.y
                Hbc = ptx.z

                Dim cspt As New PointStrt
                Dim cspSt As New CSPStrt

                cspt.x = ptx.x
                cspt.y = ptx.y
                cspt.z = ptx.z

                cspSt.FileExists = True
                cspSt.KillFile = True
                cspSt.fNm = CurDir() & WrlFn


                WrlFn = "\First.wrl"

                If TransactionMenu.btnPilot.BackColor = Color.HotPink Or TransactionMenu.pilotFlg = True Then           'If TransactionMenu.pilotFlg = True Then

                    SrNWrlFn += 1

                    WrlFn = "\OutPut\first" & SrNWrlFn & ".wrl"

                    Call StartNewFile(CurDir() & WrlFn, True, False, ptx)

                    off = New IO.StreamWriter(CurDir() & WrlFn)

                    off.AutoFlush = True

                    Try

                        cspSt.StrtContainer(cspt, off)

                    Catch Er As Exception
                        MsgBox(Er.Message)
                        MsgBox(Er.ToString)
                        MessageBox.Show("Error in start container program with trials more than one", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try

                Else

                    Call StartNewFile(CurDir() & WrlFn, True, False, ptx)

                    off = New IO.StreamWriter(CurDir() & WrlFn)

                    off.AutoFlush = True

                    Try

                        cspSt.StrtContainer(cspt, off)

                    Catch Er As Exception
                        MsgBox(Er.Message)
                        MsgBox(Er.ToString)
                        MessageBox.Show("Error in start container program", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try

                End If

                If matchidx = 0 Then matchidx = -1
                If matchidx = -1 Then
                    stk.Clear()

                    Dim cmd1 As New OleDb.OleDbCommand
                    cmd1.Connection = conn
                    cmd1.CommandText = "delete from stuffdata"

                    Dim CmdB As New OleDb.OleDbCommand
                    CmdB.Connection = conn
                    CmdB.CommandText = "delete from BoxStuffData"

                    Dim CmdW As New OleDb.OleDbCommand
                    CmdW.Connection = conn
                    CmdW.CommandText = "delete from ArtData"

                    Dim CmdVtx As New OleDb.OleDbCommand
                    CmdVtx.Connection = conn
                    CmdVtx.CommandText = "delete from Vertex"

                    Dim Cmdcg As New OleDb.OleDbCommand
                    Cmdcg.Connection = conn
                    Cmdcg.CommandText = "delete from CGsGen"
x:

                    Try
                        cmd1.ExecuteNonQuery()
                        CmdB.ExecuteNonQuery()
                        CmdW.ExecuteNonQuery()
                        CmdVtx.ExecuteNonQuery()
                        Cmdcg.ExecuteNonQuery()

                    Catch ec As Exception
                        If ec.Message = "Cannot open any more tables." Then
                            conn.Close()
                            conn.Dispose()
                            OleDb.OleDbConnection.ReleaseObjectPool()
                            cmd1.Dispose()
                            GC.Collect()

                            conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\container.mdb;Persist Security Info=False"

                            conn.Open()
                            GoTo x
                        End If

                    End Try

                    Dim TareWtCont As Double = 0

                    If .chkbxCG.Checked = True Then
                        TareWtCont = .txtTareWtCont.Text
                    End If

                    .arc.AutoDraw(CurDir() & WrlFn, 1, 0.5, "", "", TareWtCont, True, False, "container", 0, True, "b", "1")

                    Dim ard As New Area
                    Dim ard1 As New Area

                    '#######################################
                    'Door 1 option begin 
                    '#######################################

                    If .rdb1D.Checked = True Then

                        ard.StrtPt.x = .arc.length
                        ard.StrtPt.y = 0
                        ard.StrtPt.z = 0
                        ard.length = 0.5
                        ard.width = .arc.width
                        ard.height = .arc.height

                        If DbxFlg Then
                            DbxFlgO = True
                        Else
                            DbxFlgO = False
                        End If

                        ard.AutoDraw(CurDir() & WrlFn, "", 0, CurDir() & "\Graphics\contdoor.png", "", 0, True, False, "door", 0, False, "b", "1")

                        ard1.StrtPt.x = .arc.length - 0.01
                        ard1.StrtPt.y = 0
                        ard1.StrtPt.z = 0
                        ard1.length = 0.5
                        ard1.width = ard.width
                        ard1.height = ard.height

                        If DbxFlg Then
                            DbxFlgO = True
                        Else
                            DbxFlgO = False
                        End If

                        ard1.AutoDraw(CurDir() & WrlFn, "b", 0, CurDir() & "\Graphics\contdoor.png", "", 0, True, False, "door1", 0, False, "b", "1")

                        DbxFlgO = False

                    End If

                    '#######################################
                    'Door 1 option End 
                    '#######################################

                    'Stop

                    '#######################################
                    'Door 2 option begin 
                    '#######################################

                    '$$$$$
                    'First half door begin 
                    '$$$$$

                    If .rdb2D.Checked = True Then

                        ard.StrtPt.x = .arc.length
                        ard.StrtPt.y = 0
                        ard.StrtPt.z = 0
                        ard.length = 0.5
                        ard.width = .arc.width * 0.5
                        ard.height = .arc.height

                        If DbxFlg Then
                            DbxFlgO = True
                        Else
                            DbxFlgO = False
                        End If

                        ard.AutoDrawBxDrOpn1(CurDir() & WrlFn, "", 0, CurDir() & "\Graphics\contdoor.png", "", 0, True, False, "door", 0, False, "b")

                        ard1.StrtPt.x = .arc.length - 0.01
                        ard1.StrtPt.y = 0
                        ard1.StrtPt.z = 0
                        ard1.length = 0.5
                        ard1.width = ard.width
                        ard1.height = ard.height

                        If DbxFlg Then
                            DbxFlgO = True
                        Else
                            DbxFlgO = False
                        End If

                        ard.AutoDrawBxDrOpn1(CurDir() & WrlFn, "", 0, CurDir() & "\Graphics\contdoor.png", "", 0, True, False, "door", 0, False, "b")

                        DbxFlgO = False

                        '$$$$$
                        'First half door end 
                        '$$$$$

                        '################################################################

                        '$$$$$
                        'Second half door begin 
                        '$$$$$

                        ard.StrtPt.x = .arc.length
                        ard.StrtPt.y = 0
                        ard.StrtPt.z = 0
                        ard.length = 0.5
                        ard.width = .arc.width * 0.5
                        ard.height = .arc.height

                        If DbxFlg Then
                            DbxFlgO = True
                        Else
                            DbxFlgO = False
                        End If

                        ard.AutoDrawBxDrOpn2(CurDir() & WrlFn, "", 0, CurDir() & "\Graphics\contdoor.png", "", 0, True, False, "door", 0, False, "b")

                        ard1.StrtPt.x = .arc.length - 0.01
                        ard1.StrtPt.y = 0
                        ard1.StrtPt.z = 0
                        ard1.length = 0.5
                        ard1.width = ard.width
                        ard1.height = ard.height

                        If DbxFlg Then
                            DbxFlgO = True
                        Else
                            DbxFlgO = False
                        End If

                        ard.AutoDrawBxDrOpn2(CurDir() & WrlFn, "", 0, CurDir() & "\Graphics\contdoor.png", "", 0, True, False, "door", 0, False, "b")

                        DbxFlgO = False

                        '$$$$$
                        'First half door end 
                        '$$$$$

                    End If

                    '#######################################
                    'Door 2 option End 
                    '#######################################

                    '***********************************************************************************************************************************************************************

                    Bstrtclr = "r"

                    off.WriteLine("")
                    off.WriteLine("###########################################################################")
                    off.WriteLine("")

                Else

                    putqty = 0
                    For i As Integer = 0 To matchidx - 1
                        putqty += qtyarr1(i).qty
                    Next
                    stk.Clear()

                    If matchidx <> -1 Then
                        For i As Integer = 0 To qtyarr(matchidx - 1).stk.Count - 1
                            stk.Add(qtyarr(matchidx - 1).stk(i))
                        Next
                    End If

                    .arc.AutoDraw(CurDir() & WrlFn, 1, 0.5, CurDir() & "\Graphics\contdoor.png", "", 0, True, False, "container", 0, True, "b", "1")

                    Dim ard As New Area
                    ard.StrtPt.x = .arc.length
                    ard.StrtPt.y = 0
                    ard.StrtPt.z = 0
                    ard.length = 0.5
                    ard.width = .arc.width
                    ard.height = .arc.height

                    ard.AutoDraw(CurDir() & WrlFn, "", 0, CurDir() & "\Graphics\contdoor.png", "", 0, True, False, "door", 0, False, "b", "1")

                    Dim ard1 As New Area
                    ard1.StrtPt.x = .arc.length - 0.01
                    ard1.StrtPt.y = 0
                    ard1.StrtPt.z = 0
                    ard1.length = 0.5
                    ard1.width = ard.width
                    ard1.height = ard.height

                    ard1.AutoDraw(CurDir() & WrlFn, "b", 0, CurDir() & "\Graphics\contdoor.png", "", 0, True, False, "door1", 0, False, "b", "1")

                    Dim col1 As String = "r"
                    Bplclst.Clear()
                    Bqtylst.Clear()
                    Dim qtyx As Integer = 0
                    qtyarr.Clear()
                    Dim ahistarr1 As New List(Of r1)

                    ahistarr1.Clear()

                    .btnStatus.Visible = False
                    .lblStatus.Visible = True
                    .lblStatusINm.Visible = True

                    .pbCSP1.Visible = True
                    ProgressBarRunning()

                    .lblStatus.Text = "Please wait ....."

                    If .dgv1.CurrentCell.ColumnIndex = 12 Then
                        .showemp = False
                    ElseIf .dgv1.CurrentCell.ColumnIndex = 13 Then
                        .showemp = True
                    End If

                    If stk.Count = 0 Then

                        If .showemp Then
                            MsgBox("Container Is Fully Occupied. No Empty Area Left", MsgBoxStyle.Critical + vbOKOnly)
                            Exit Sub
                        End If

                    End If

                    Dim ar11 As New Area

                    For i As Integer = 0 To stk.Count - 1

                        ar11 = stk(i)
                        If .showemp Then
                            ar11.AutoDraw(CurDir() & WrlFn, "r", 0, "", CStr(i + 1), 0, False, True, "E", 0, False, "b", "1")

                        End If

                    Next

                    If .showemp Then

                        Try
                            Closef(CurDir() & WrlFn)

                            .lblStatus.Visible = False
                            .lblStatusINm.Visible = False
                            .btnStatus.Visible = False

                            .pbCSP1.Visible = False

                            Eventless()

                            '#################@@@@@@@@@@@@@@@@@@@@@@@@@@
                            Call Show3DView()
                            '#################@@@@@@@@@@@@@@@@@@@@@@@@@@

                        Catch Ex As Exception
                            MsgBox(Ex.Message)
                            MsgBox(Ex.ToString)
                            MsgBox(Ex.Message, MsgBoxStyle.Critical, "Message :: In method 'MouseClick'  " & vbCrLf & "VRML Programme Running is failure!")
                            .Close()

                        Finally
                            .lblStatus.Visible = False
                            .lblStatusINm.Visible = False
                            .btnStatus.Visible = False

                            .pbCSP1.Visible = False

                            Eventless()
                        End Try

                        Exit Sub
                    End If

                    Bitemno = 0

                    For i As Integer = 0 To putqty - 1
                        qtyx += 1
                        Bahistarr(i).ar.AutoDraw(CurDir() & WrlFn, col1, 0, "file\\\c:\t2.png", Bahistarr(i).itmnm, 0, False, True, "", Bahistarr(i).method, False, "b", "1")

                        ahistarr1.Add(Bahistarr(i))
                        If i = putqty - 1 Then
                            plclst1.Add(qtyx)

                            Bqtylst.Add(qtyx)

                            Dim m1 As New e1
                            m1.itmnm = Bahistarr(i).itmnm
                            m1.qty = qtyx
                            m1.stk = Bahistarr(i).stk
                            qtyarr.Add(m1)

                            qtyx = 0
                            Exit For

                        End If

                        If Bahistarr(i).itmnm <> Bahistarr(i + 1).itmnm Then

                            Bitemno += 1
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
                            plclst1.Add(qtyx)
                            Bqtylst.Add(qtyx)

                            Dim m1 As New e1
                            m1.itmnm = Bahistarr(i).itmnm
                            m1.qty = qtyx
                            m1.stk = Bahistarr(i).stk
                            qtyarr.Add(m1)
                            qtyx = 0

                        End If
                    Next

                    Bitemno += 1

                    .lblStatus.Visible = False
                    .lblStatusINm.Visible = False
                    .btnStatus.Visible = False

                    .pbCSP1.Visible = False

                    Eventless()

                    Bahistarr.Clear()
                    For i As Integer = 0 To ahistarr1.Count - 1
                        Bahistarr.Add(ahistarr1(i))
                    Next

                    Bplclst.Clear()
                    For i As Integer = 0 To Bqtylst.Count - 1
                        Bplclst.Add(Bqtylst(i) - 1)
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
                    Bstrtclr = col1

                End If
                '*************
                'Stop
                '*************
                Dim Stk1 As New List(Of Area)
                Dim Stk2 As New List(Of Area)

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
                Dim Itmnm As String = Nothing
                Dim SLbl As String

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
                Dim wt As String = Nothing
                Dim transparr() As Boolean
                Dim transp As Boolean
                Dim topup() As Boolean
                Dim Tpup As Boolean

                ReDim ar(0)
                ReDim ari(0)
                ReDim arwt(0)
                ReDim transparr(0)
                ReDim topup(0)
                ReDim arl(0)

                Dim cmd As New OleDb.OleDbCommand

                Dim cntx As Integer = 0

                Dim plcqty As Integer = 0

                Dim k As Integer
                Dim m As Integer

                DelTab("temp1")

                If .CmbContainer.Text = "" Then
                    MsgBox("Container not selected", MsgBoxStyle.Critical + vbOKOnly)
                    MessageBox.Show("Container not selected", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    .CmbContainer.Focus()
                    Exit Sub
                End If

                .btnStatus.Visible = False

                .lblStatus.Text = "Please wait ....."
                .lblStatus.Visible = True
                .lblStatusINm.Visible = True
                .btnStatus.Visible = False

                .pbCSP1.Visible = True
                ProgressBarRunning()

                System.Windows.Forms.Application.DoEvents()

                Dim i1, j1 As Integer
                Dim extflg As Boolean = False

                Dim zz As Integer

                zz = rowno1

                Dim matchidx1 As Integer
                If matchidx = -1 Then
                    matchidx1 = 0
                Else
                    matchidx1 = matchidx
                End If

                Try

                    If Not ADclFlg Then

                        For i1 = matchidx1 To zz
                            Try
                                Itmnm = .dgv1.Item(1, i1).Value
                                ln = Math.Round(.dgv1.Item(4, i1).Value, 4)
                                wd = Math.Round(.dgv1.Item(5, i1).Value, 4)
                                ht = Math.Round(.dgv1.Item(6, i1).Value, 4)
                                qty = .dgv1.Item(11, i1).Value

                                wt = .dgv1.Item(8, i1).Value
                                seq = .dgv1.Item(0, i1).Value

                                transp = False

                                Tpup = IIf(.dgv1.Item(7, i1).Value = "6", False, True)

                                Bqtylst.Add(qty)
                            Catch
                            End Try

                            For j1 = 0 To qty - 1

                                totqty1 += 1

                                qtyf = True

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
                                ari(UBound(ari)) = Itmnm
                                arwt(UBound(arwt)) = wt
                                transparr(UBound(transparr)) = transp
                                topup(UBound(topup)) = Tpup

                                ReDim Preserve ar(UBound(ar) + 1)
                                ReDim Preserve ari(UBound(ari) + 1)
                                ReDim Preserve arwt(UBound(arwt) + 1)
                                ReDim Preserve transparr(UBound(transparr) + 1)
                                ReDim Preserve topup(UBound(topup) + 1)

                            Next

                        Next i1


                    Else

                        For i1 = matchidx1 To zz

                            Itmnm = .dgv1.Item(1, i1).Value
                            ln = Math.Round(.dgv1.Item(4, i1).Value, 4)
                            wd = Math.Round(.dgv1.Item(5, i1).Value, 4)
                            ht = Math.Round(.dgv1.Item(6, i1).Value, 4)
                            qty = .dgv1.Item(11, i1).Value

                            wt = .dgv1.Item(8, i1).Value
                            seq = .dgv1.Item(0, i1).Value
                            SLbl = .dgv1.Item(15, i1).Value

                            If SLbl = Nothing Then
                                SLbl = Itmnm
                            End If

                            transp = False

                            Tpup = IIf(.dgv1.Item(7, i1).Value = "6", False, True)

                            Bqtylst.Add(qty)


                            For j1 = 0 To qty - 1

                                totqty1 += 1

                                qtyf = True

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
                                ari(UBound(ari)) = Itmnm
                                arwt(UBound(arwt)) = wt
                                transparr(UBound(transparr)) = transp
                                topup(UBound(topup)) = Tpup
                                arl(UBound(arl)) = SLbl

                                ReDim Preserve ar(UBound(ar) + 1)
                                ReDim Preserve ari(UBound(ari) + 1)
                                ReDim Preserve arwt(UBound(arwt) + 1)
                                ReDim Preserve transparr(UBound(transparr) + 1)
                                ReDim Preserve topup(UBound(topup) + 1)
                                ReDim Preserve arl(UBound(arl) + 1)

                            Next

                        Next i1

                    End If

                Catch Err As Exception
                    MsgBox(Err.Message)
                    MsgBox(Err.ToString)
                    MessageBox.Show("Error in Datagrid entry looping entry to stuffing assigning", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

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
                    plcqty = plcqty + Bplclstf(i) - 1
                Next

                ReDim Preserve ar(UBound(ar) - 1)
                ReDim Preserve ari(UBound(ari) - 1)
                ReDim Preserve arwt(UBound(arwt) - 1)
                ReDim Preserve transparr(UBound(transparr) - 1)
                ReDim Preserve topup(UBound(topup) - 1)

                If ADclFlg Then
                    ReDim Preserve arl(UBound(arl) - 1)
                End If

                stp += 1

                Dim ar2() As Area
                Dim ari2() As String
                Dim arwt2() As Single
                Dim transparr2() As Boolean

                ReDim ar2(0)
                ReDim ari2(0)
                ReDim arwt2(0)
                ReDim transparr2(0)

                For i As Integer = LBound(ar) To UBound(ar)

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

                Try
                    ReDim Preserve topup(UBound(topup) - 1)
                Catch

                End Try

                If stp = .dgv1.RowCount Then
                    stp = 0
                    cnt = 0
                End If

                .arc.StrtPt.x = 0
                .arc.StrtPt.y = 0
                .arc.StrtPt.z = 0

                .arc.length = CL
                .arc.width = CW
                .arc.height = CH

                qty = 0

                .lblStatus.Visible = False
                .lblStatusINm.Visible = False
                .btnStatus.Visible = False

                .pbCSP1.Visible = False

                Eventless()

                Dim outfile As String = CurDir() & WrlFn

                Try

                    Xl3d = 0        'Initialising the optimum stuff
                    Yl3d = 0
                    Zl3d = 0

                    RiCnt = 0
                    flg_RiCnt = False

                    If conn.State = ConnectionState.Closed Then conn.Open()

                    TransactionMenu.lblCG.Text = ""

                    Dim Cmdo As New OleDb.OleDbCommand
                    Cmdo.Connection = conn
                    Cmdo.CommandText = "delete from pgRecord"
                    Cmdo.ExecuteNonQuery()

                    Dim CmdOp As New OleDb.OleDbCommand
                    CmdOp.Connection = conn
                    CmdOp.CommandText = "delete from pgCord"
                    CmdOp.ExecuteNonQuery()

                Catch ex As Exception
                    MsgBox(ex.Message)
                    MsgBox(ex.ToString)
                    MessageBox.Show("Error in OptStuff Module", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

                If ar.Length > 0 Then
                    If stk.Count = 0 Then stk.Add(.arc)
                    Bitemqty = 0
                    Bplclst.Clear()
                    Btxtopt = False

                    If .dgv1.CurrentCell.ColumnIndex = 12 Then

                        If .chkbxWadStuff.Checked Then

                            Try

                                Stk2 = BoxStuff(.arc, ar2, ari2, arwt2, False, False, outfile, True, transparr2, topup, Btxtopt, True, False, True, .colarr, .dgv1)

                                mClk = False

                                GoTo BxStfEnd

                            Catch ex As Exception
                                MsgBox(ex.Message)
                                MsgBox(ex.ToString)
                                MessageBox.Show("Error in Stuff", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End Try

                        End If

                        If .chkBxPlyStuff.Checked Then

                            Try
                                Dim RiQ As Int32 = 0
                                Do While (TransactionMenu.dgv1.RowCount - 2)

                                    .dgv1.Item(15, RiQ).Value = ""
                                    .dgv1.Item(16, RiQ).Value = ""
                                    RiQ += 1
                                Loop
                            Catch
                            Finally
                                .dgv1.Refresh()
                            End Try

                            Try
                                TransactionMenu.pnlPbinfo.Visible = True
                                TransactionMenu.pbCSP1.Visible = True
                                TransactionMenu.lblStatus.Visible = True
                                TransactionMenu.lblStatus.Text = "Please wait….. Stuffing is progress."
                                TransactionMenu.lblStatus.Refresh()

                                PlyIno = 0                  'Ply stuff initiialisation
                                PlyInm = Nothing

                                Dim PlyAr As New Area
                                Dim RemAr As New Area
                                Dim PlyCnt As Integer
                                Dim Grt As Double
                                Dim BunchFlg As Boolean = False
                                Dim ItmPlaced As Int64 = 0

                                PlyAr.StrtPt.x = 0
                                PlyAr.StrtPt.y = 0
                                PlyAr.StrtPt.z = 0

                                For i As Integer = 0 To .dgv1.RowCount - 2

                                    PlysQty = 0

                                    qty = .dgv1.Item(11, i).Value            'qty = .dgv1.Item(11, 0).Value

                                    PlyAr.length = Math.Round(.dgv1.Item(4, i).Value, 4)         'PlyAr.length = Math.Round(.dgv1.Item(4, 0).Value, 4)
                                    PlyAr.width = Math.Round(.dgv1.Item(5, i).Value, 4)          'PlyAr.width = Math.Round(.dgv1.Item(5, 0).Value, 4)
                                    PlyAr.height = Math.Round(.dgv1.Item(6, i).Value, 4)         'PlyAr.height = Math.Round(.dgv1.Item(6, 0).Value, 4)

                                    Itmnm = .dgv1.Item(1, i).Value           'Itmnm = .dgv1.Item(1, 0).Value

                                    Dim Lpt As Double
                                    Dim Wpt As Double
                                    Dim Hpt As Double

                                    Dim cLpt As Double
                                    Dim cWpt As Double
                                    Dim cHpt As Double

                                    Lpt = PlyAr.length
                                    Wpt = PlyAr.width
                                    Hpt = PlyAr.height

                                    cLpt = .arc.length
                                    cWpt = .arc.width
                                    cHpt = .arc.height

                                    BunchFlg = Buncher(Lpt, Wpt, Hpt, cLpt, cWpt, cHpt, qty, False)

                                    PlyCnt = StuffPly(.arc, PlyAr, True, True, qty, Itmnm)

                                    RemAr = PlyDrwLst(PlyCnt - 1)

                                    Dim Lp As Double
                                    Dim Wp As Double
                                    Dim Hp As Double

                                    Dim cLp As Double
                                    Dim cWp As Double
                                    Dim cHp As Double

                                    Lp = PlyAr.length
                                    Wp = PlyAr.width
                                    Hp = PlyAr.height

                                    cLp = .arc.length
                                    cWp = .arc.width
                                    cHp = .arc.height

                                    Grt = Greater(Lp, Wp, Hp, cLp, cWp, cHp, qty, False)

                                    If Grt = Nothing Then
                                        Grt = PlyAr.length
                                    End If

                                    If BunchFlg Then
                                        BunchFlg = False
                                        PlyAr.StrtPt.x = RemAr.StrtPt.x
                                        PlyAr.StrtPt.y = 0
                                        PlyAr.StrtPt.z = 0
                                    Else
                                        PlyAr.StrtPt.x = RemAr.StrtPt.x + Grt               'PlyAr.StrtPt.x = RemAr.StrtPt.x + PlyAr.length '
                                        PlyAr.StrtPt.y = 0
                                        PlyAr.StrtPt.z = 0
                                    End If

                                    ItmPlaced = (PlyCnt - 1).ToString - PlysQty

                                    .dgv1.Item(16, i).Value = ItmPlaced

                                    ItmPlaced = qty - ItmPlaced

                                    .dgv1.Item(15, i).Value = ItmPlaced

                                    .dgv1.Refresh()

                                Next i

                                MessageBox.Show("In Ply Stuff item name '" & Itmnm & "'  out of  " & qty & "  quantity only  " & ItmPlaced & "  placed", .Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

                                PlyCnt = 0

                            Catch Exx As Exception
                                MsgBox(Exx.Message)
                                MsgBox(Exx.ToString)
                                MessageBox.Show("Error in Plystuff ShowButton", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Finally
                                TransactionMenu.pnlPbinfo.Visible = False
                                TransactionMenu.pbCSP1.Visible = False
                                TransactionMenu.lblStatus.Text = ""
                                TransactionMenu.lblStatus.Visible = False
                                Eventless()
                            End Try

                            GoTo PlyEnd
                        End If

                        If ADclFlg Then
                            BoxLBLStuff(.arc, ar2, ari2, arl, arwt2, False, False, outfile, True, transparr2, topup, Btxtopt, True, False, True, .colarr)
                            GoTo BxStfEnd
                        End If

                        If .chkBxPlyStuff.Checked Or .chkbxOptStuff.Checked Or .chkbxManualChng.Checked Then
                            MoveBoxStuff(.arc, ar2, ari2, arwt2, False, False, outfile, True, transparr2, topup, Btxtopt, True, False, True, .colarr)
                            GoTo BxStfEnd
                        End If

                        If Not .CheckBox1.Checked AndAlso Not .chkBxPlyStuff.Checked Then

                            Stk2 = BoxStuff(.arc, ar2, ari2, arwt2, False, False, outfile, True, transparr2, topup, Btxtopt, True, False, True, .colarr, .dgv1)

                        ElseIf .CheckBox1.Checked Then

                            Dim ar12 As New Area

                            qty = .dgv1.Item(11, 0).Value

                            ar12.StrtPt.x = 0
                            ar12.StrtPt.y = 0
                            ar12.StrtPt.z = 0
                            ar12.length = Math.Round(.dgv1.Item(4, 0).Value, 4)
                            ar12.width = Math.Round(.dgv1.Item(5, 0).Value, 4)
                            ar12.height = Math.Round(.dgv1.Item(6, 0).Value, 4)

                            Dim pt As New Point
                            pt.x = ar1.length
                            pt.y = ar1.width
                            pt.z = ar1.height

                            Itmnm = .dgv1.Item(1, 0).Value

                            Dim hg As Integer = 0

                            totqty = 0

                            hg = Stuffy(.arc, ar12, True, True, qty, Itmnm)

                            qty = 0

                            MsgBox((hg - 1).ToString & " Items placed", , .Text)

                            hg = 0

                        End If
                        .showemp = True

                    End If

BxStfEnd:

                    Dim emvol As Double = 0
                    For kk As Integer = 0 To stk.Count - 1
                        emvol = emvol + (stk(kk).length * stk(kk).width * stk(kk).height)
                    Next
                    emvol = emvol * (0.0254 * 0.0254 * 0.0254)
                    .TxtFreeCbm.Text = Format(emvol, "0.000")
                    .TxtOccuCbm.Text = Format((CDbl(.TxtCapacity.Text) - CDbl(.TxtFreeCbm.Text)), "0.000")
                    Dim persFact As Double = CDbl(CDbl(.TxtCapacity.Text) * 0.01)
                    .TxtpercentVolOcc.Text = Format(CDbl(.TxtOccuCbm.Text / persFact), "0.00")
                    Call CompactPer()
                    If .dgv1.CurrentCell.ColumnIndex = 12 Then
                        .showemp = False
                    ElseIf .dgv1.CurrentCell.ColumnIndex = 13 Then
                        .showemp = True
                    End If
                    Dim mn As Integer = 0

                    Dim are As Area
                    stkmm.Clear()
                    Dim vol1 As Double
                    For jjj As Integer = 0 To Stk2.Count - 1
                        vol1 = vol1 + (Stk2(jjj).length * Stk2(jjj).width * Stk2(jjj).height)
                    Next
                    For rr As Integer = 0 To Stk2.Count - 1
                        are = New Area
                        are.StrtPt.x = Stk2(rr).StrtPt.x
                        are.StrtPt.y = Stk2(rr).StrtPt.y
                        are.StrtPt.z = Stk2(rr).StrtPt.z
                        are.length = Stk2(rr).length
                        are.width = Stk2(rr).width
                        are.height = Stk2(rr).height
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

                        If CInt(.dgv1.Item(11, i).Value) > Bqtylst(i) + 1 Then
                            Dim qtyv As Integer
                            If Bqtylst(i) <= 0 Then
                                qtyv = 0
                            Else
                                qtyv = Bqtylst(i) + 1
                            End If

                            If Not TransactionMenu.Enabled = False Then

                                MessageBox.Show(.dgv1.Item(11, i).Value.ToString & " no of " & .dgv1.Item(1, i).Value & " cannot be placed. " & vbCrLf & CStr(qtyv) & " placed.", "Stuffing Entry", MessageBoxButtons.OK)

                            End If

                            drwstp = drwstp - Bqtylst(i) + Bplclst(i) + 1
                            Bqtylst(i) = Bplclst(i) + 1

                        End If
                    Next

                    If Not .CheckBox1.Checked Then

                        Try
                            .TxtOccuKgs.Text = Format(CDbl(.dgv1.Item(8, .dgv1.CurrentCell.RowIndex).Value) * (Bplclst(CInt(.dgv1.CurrentCell.RowIndex)) + 1), "0.000")
                            .TxtFreeKgs.Text = Format(CDbl(.TxtPayLoad.Text) - CDbl(.TxtOccuKgs.Text), "0.000")

                            For i As Integer = 0 To rowno1
                                Dim qtyv As Integer = Bplclst(i)
                                qtyv += 1
                                If .CheckBox1.Checked = True Then
                                    If fullflag Then

                                        qtyv = xcnt
                                    Else
                                        qtyv = xcnt
                                    End If
                                End If
                                If CInt(.dgv1.Item(11, i).Value) > qtyv Then

                                    If Not TransactionMenu.Enabled = False Then

                                        MessageBox.Show(.dgv1.Item(11, i).Value.ToString & " no of " & .dgv1.Item(1, i).Value & " cannot be placed." & vbCrLf & CStr(qtyv) & " placed.", "Stuffing Entry", MessageBoxButtons.OK)

                                    End If

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
                            Dim bn As Integer
                            If matchidx = -1 Then
                                bn = 0
                            Else
                                bn = matchidx
                            End If
                            For i As Integer = 0 To Bqtylst.Count - 1
                                totqty = totqty + Bqtylst(i)
                            Next

                            plcqty = 0
                            For i As Integer = 0 To Bplclstf.Count - 1
                                plcqty = plcqty + Bplclstf(i)
                            Next

                        Catch
                        End Try


SBMCEnd:
                        Do While Not .dgEmpty.RowCount = 0
                            Try
                                .dgEmpty.Rows.Remove(.dgEmpty.Rows(0))
                            Catch
                                Exit Do
                            End Try
                        Loop

                        Do While Not .dgUsage.RowCount = 0

                            Try
                                .dgUsage.Rows.Remove(.dgUsage.Rows(0))
                            Catch
                                Exit Do
                            End Try
                        Loop

                        button3_click(frmObj, .showemp, .arc)

                    End If
                End If

                Dim dq As Char = Chr(34)
PlyEnd:

                Closef(outfile)

                If .chkbxCG.Checked = True Then

                    Call cgManipulation()

                End If

                CloseVRML(outfile) 'Close the VRML File

                If Not TransactionMenu.TrlOFlg And Not TransactionMenu.btnStepTrials.BackColor = Color.HotPink Then

                    Call Show3DView()

                End If

                If TransactionMenu.btnStepTrials.BackColor = Color.HotPink Then
                    MessageBox.Show("The Step Trial’s stuffing is finish.", "Step Trial's", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

                Bplclst.Clear()
                Bqtylst.Clear()

            End If

            conn.Close()
            off.Close()

            .btnPilot.Enabled = True
            .chkBxAutoStuff.Enabled = True
            Bplclst.Clear()
            Bqtylst.Clear()
            .BoxStatusStriplbl.Text = "Pick the activity"
            mClk = False



        End With

    End Sub

    Public Sub ShowStuff(ByRef Oform As TransactionMenu)

        With Oform

            .lblCG.Visible = False
            .lblCGoffset.Visible = False
            .lblCG.Text = ""
            .lblCGoffset.Text = ""
            .lblBalWt.Text = ""

            System.Windows.Forms.Application.DoEvents()

            If Not mClk Then

                TransactionMenu.pbCSP1.Value = 0

                mClk = True
                .ShowButton.BackColor = Color.Plum

                StopFlg = False                               'The stop button stop flag is initialise

                stk.Clear()

                Xl3d = 0            'Initialising the value in optimum stuff
                Yl3d = 0
                Zl3d = 0
                Bitemno = 0
                Bqtylst.Clear()
                wad4flg = False

                Try
                    '======================================================================================================
                    'If chkBxAutoStuff.Checked Then             'Auto stuff arrange by old method is commented.

                    '    DrBxOpn = False
                    '    AutoStuffShow(sender, e)

                    '    GoTo SBMCEnd

                    'End If
                    '======================================================================================================

StfSrtAt:

                    .BoxStatusStriplbl.Text = "Stuffing item is progress please wait."
                    BitemqtyInr = 1

                    Dim ans As MsgBoxResult

                    Try
                        rwidx = .dgv1.CurrentCell.RowIndex
                    Catch
                    End Try

                    Dim rowno1 As Integer = rwidx
                    Dim plclst1 As New List(Of Integer)
                    chkwt = True

                    'Try
                    If .dgv1.CurrentCell.ColumnIndex = 12 Or .dgv1.CurrentCell.ColumnIndex = 13 Or .dgv1.CurrentCell.ColumnIndex = 14 Then

                        If .dgv1.Item(1, rowno1).Value Is Nothing _
                    OrElse .dgv1.Item(11, rowno1).Value Is Nothing _
                    OrElse Not IsNumeric(.dgv1.Item(11, rowno1).Value) _
                    OrElse CInt(.dgv1.Item(11, rowno1).Value) <= 0 _
                    OrElse .dgv1.Item(11, rowno1).Value.ToString.Contains(".") _
                    Then
                            If .dgv1.CurrentCell.ColumnIndex <> 14 Then
                                MsgBox("Cannot show this item." & ControlChars.CrLf & "Item name not selected or quantity is invalid", MsgBoxStyle.Critical + vbOKOnly)
                                Exit Sub
                            End If

                        End If
                        'End If
                        If .dgv1.CurrentCell.ColumnIndex <> 14 Then

                            ans = MsgBoxResult.Yes
                            If ans = MsgBoxResult.Yes Then

                                For i As Integer = 0 To .dgv1.RowCount - 1

                                    If .dgv1.Item(1, i).Value Is Nothing _
                                    OrElse .dgv1.Item(8, i).Value Is Nothing _
                                    OrElse .dgv1.Item(11, i).Value Is Nothing _
                                    OrElse Not IsNumeric(.dgv1.Item(8, i).Value) _
                                    OrElse Not IsNumeric(.dgv1.Item(11, i).Value) _
                                    OrElse CInt(.dgv1.Item(8, i).Value) < 0 _
                                    OrElse CInt(.dgv1.Item(11, i).Value) <= 0 _
                                    OrElse .dgv1.Item(11, i).Value.ToString.Contains(".") _
                                    OrElse .dgv1.Item(11, i).Value.ToString.Contains(".") _
                                    Then

                                        Try
                                            .dgv1.Rows.Remove(.dgv1.Rows(i))
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

                        If .CmbContainer.Text = "" Then
                            MsgBox("Container not selected", MsgBoxStyle.Critical + vbOKOnly)
                            .CmbContainer.Focus()
                            Exit Sub
                        End If

                        Bitemno = 0
                        Dim e3 As New e1

                        Dim qtyarr1 As New List(Of e1)
                        qtyarr1.Clear()
                        'Stop
                        Try
                            For i As Integer = 0 To rowno1
                                e3.itmnm = .dgv1.Item(1, i).Value
                                e3.qty = .dgv1.Item(11, i).Value
                                qtyarr1.Add(e3)
                            Next
                        Catch
                        End Try

                        Dim putqty As Integer

                        Dim matchidx As Integer = -1
                        .TxtFreeCbm.Clear()
                        .TxtOccuCbm.Clear()
                        .TxtpercentVolOcc.Clear()
                        .txtCompactPer.Clear()

                        'Stop

                        Dim ptx As New Point

                        'ptx.x = .arc.length
                        'ptx.y = .arc.width
                        'ptx.z = .arc.height

                        ptx.x = CL
                        ptx.y = CW
                        ptx.z = CH

                        .arc.length = ptx.x
                        .arc.width = ptx.y
                        .arc.height = ptx.z

                        Lbc = ptx.x
                        Wbc = ptx.y
                        Hbc = ptx.z

                        Dim cspt As New PointStrt
                        Dim cspSt As New CSPStrt

                        cspt.x = ptx.x
                        cspt.y = ptx.y
                        cspt.z = ptx.z

                        cspSt.FileExists = True
                        cspSt.KillFile = True
                        cspSt.fNm = CurDir() & WrlFn

                        'Stop

                        WrlFn = "\First.wrl"

                        If TransactionMenu.btnPilot.BackColor = Color.HotPink Or TransactionMenu.pilotFlg = True Then           'If TransactionMenu.pilotFlg = True Then

                            SrNWrlFn += 1

                            WrlFn = "\OutPut\first" & SrNWrlFn & ".wrl"

                            'MsgBox("Ok.........................................")

                            'Strt(CurDir() & WrlFn, True, ptx)      'Orig Routine

                            '   ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^6

                            Call StartNewFile(CurDir() & WrlFn, True, False, ptx)

                            off = New IO.StreamWriter(CurDir() & WrlFn)

                            off.AutoFlush = True

                            Try

                                cspSt.StrtContainer(cspt, off)

                            Catch Er As Exception
                                MsgBox(Er.Message)
                                MsgBox(Er.ToString)
                                MessageBox.Show("Error in start container program with trials more than one", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End Try

                            '   ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^6

                        Else

                            Call StartNewFile(CurDir() & WrlFn, True, False, ptx)

                            off = New IO.StreamWriter(CurDir() & WrlFn)

                            off.AutoFlush = True

                            Try

                                cspSt.StrtContainer(cspt, off)

                            Catch Er As Exception
                                MsgBox(Er.Message)
                                MsgBox(Er.ToString)
                                MessageBox.Show("Error in start container program", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End Try

                            'Strt(CurDir() & "\First.wrl", True, ptx)
                            'Strt(CurDir() & WrlFn, True, ptx) 'Orig replace of asy

                        End If

                        'Strt(CurDir() & "\First.wrl", True, ptx)

                        'Stop
                        If matchidx = 0 Then matchidx = -1
                        If matchidx = -1 Then
                            stk.Clear()

                            Dim cmd1 As New OleDb.OleDbCommand
                            cmd1.Connection = conn
                            cmd1.CommandText = "delete from stuffdata"

                            Dim CmdB As New OleDb.OleDbCommand
                            CmdB.Connection = conn
                            CmdB.CommandText = "delete from BoxStuffData"

                            Dim CmdW As New OleDb.OleDbCommand
                            CmdW.Connection = conn
                            CmdW.CommandText = "delete from ArtData"

                            Dim CmdVtx As New OleDb.OleDbCommand
                            CmdVtx.Connection = conn
                            CmdVtx.CommandText = "delete from Vertex"

                            Dim Cmdcg As New OleDb.OleDbCommand
                            Cmdcg.Connection = conn
                            Cmdcg.CommandText = "delete from CGsGen"
x:

                            Try
                                cmd1.ExecuteNonQuery()
                                CmdB.ExecuteNonQuery()
                                CmdW.ExecuteNonQuery()
                                CmdVtx.ExecuteNonQuery()
                                Cmdcg.ExecuteNonQuery()

                            Catch ec As Exception
                                If ec.Message = "Cannot open any more tables." Then
                                    conn.Close()
                                    conn.Dispose()
                                    OleDb.OleDbConnection.ReleaseObjectPool()
                                    cmd1.Dispose()
                                    GC.Collect()

                                    conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\container.mdb;Persist Security Info=False"

                                    conn.Open()
                                    GoTo x
                                End If

                            End Try

                            Dim TareWtCont As Double = 0

                            If .chkbxCG.Checked = True Then
                                TareWtCont = .txtTareWtCont.Text
                            End If

                            'Stop

                            'If Not (TransactionMenu.pilotFlg) Then
                            '.arc.AutoDraw(CurDir() & "First.wrl", 1, 0.5, "", "", TareWtCont, True, False, "container", 0, True, "b", "1")
                            .arc.AutoDraw(CurDir() & WrlFn, 1, 0.5, "", "", TareWtCont, True, False, "container", 0, True, "b", "1")
                            'End If

                            Dim ard As New Area
                            Dim ard1 As New Area

                            'Stop

                            ''//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                            'Dim lnD As Double = .arc.length
                            'Dim wdD As Double = .arc.width
                            'Dim htD As Double = .arc.height
                            'Dim xD As Double = .arc.StrtPt.x
                            'Dim yD As Double = .arc.StrtPt.y
                            'Dim zD As Double = .arc.StrtPt.z
                            'Dim temp As Double = 0

                            'If wdD > lnD Then
                            '    temp = wdD
                            '    wdD = lnD
                            '    lnD = temp
                            'End If
                            'If htD > lnD Then
                            '    temp = htD
                            '    htD = lnD
                            '    lnD = temp
                            'End If
                            'If wdD > htD Then
                            '    temp = wdD
                            '    wdD = htD
                            '    htD = temp
                            'End If

                            'Dim LcontDor As Double = lnD
                            'Dim WcontDor As Double = wdD
                            'Dim HcontDor As Double = htD

                            ''//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                            ''***********************************************************************************************************************************************************************

                            ''#######################################
                            ''Door 1 option begin 
                            ''#######################################
                            'If .rdb1D.Checked = True Then

                            '    ard.StrtPt.x = LcontDor         '.arc.length
                            '    ard.StrtPt.y = 0
                            '    ard.StrtPt.z = 0
                            '    ard.length = 0.5
                            '    ard.width = WcontDor            '.arc.width
                            '    ard.height = HcontDor           '.arc.height

                            '    If DbxFlg Then
                            '        DbxFlgO = True
                            '    Else
                            '        DbxFlgO = False
                            '    End If

                            '    'ard.AutoDraw(CurDir() & "\First.wrl", "", 0, "file:///c:\contdoor.png", "", 0, True, False, "door", 0, False, "b", "1")

                            '    ard.AutoDraw(CurDir() & "\First.wrl", "", 0, CurDir() & "\Graphics\contdoor.png", "", 0, True, False, "door", 0, False, "b", "1")

                            '    ard1.StrtPt.x = LcontDor - 0.01               '.arc.length - 0.01
                            '    ard1.StrtPt.y = 0
                            '    ard1.StrtPt.z = 0
                            '    ard1.length = 0.5
                            '    ard1.width = ard.width
                            '    ard1.height = ard.height

                            '    'Stop
                            '    If DbxFlg Then
                            '        DbxFlgO = True
                            '    Else
                            '        DbxFlgO = False
                            '    End If

                            '    'ard1.AutoDraw(CurDir() & "First.wrl", "b", 0, "file:///c:\contdoor.png", "", 0, True, False, "door1", 0, False, "b", "1")

                            '    ard1.AutoDraw(CurDir() & "First.wrl", "b", 0, CurDir() & "\Graphics\contdoor.png", "", 0, True, False, "door1", 0, False, "b", "1")

                            '    DbxFlgO = False

                            'End If
                            ''#######################################
                            ''Door 1 option End 
                            ''#######################################

                            ''Stop

                            ''#######################################
                            ''Door 2 option begin 
                            ''#######################################

                            ''$$$$$
                            ''First half door begin 
                            ''$$$$$

                            'If .rdb2D.Checked = True Then

                            '    ard.StrtPt.x = LcontDor             '.arc.length
                            '    ard.StrtPt.y = 0
                            '    ard.StrtPt.z = 0
                            '    ard.length = 0.5
                            '    ard.width = WcontDor * 0.5              '.arc.width * 0.5
                            '    ard.height = HcontDor               '.arc.height

                            '    If DbxFlg Then
                            '        DbxFlgO = True
                            '    Else
                            '        DbxFlgO = False
                            '    End If

                            '    'ard.AutoDrawBxDrOpn1(CurDir() & "\First.wrl", "", 0, "file:///c:\contdoor.png", "", 0, True, False, "door", 0, False, "b")                                 'ard.AutoDraw(CurDir() & "\Box.wrl", "", 0, "file:///c:\contdoor.png", "", 0, True, False, "door", 0, False, "b")

                            '    ard.AutoDrawBxDrOpn1(CurDir() & "\First.wrl", "", 0, CurDir() & "\Graphics\contdoor.png", "", 0, True, False, "door", 0, False, "b")                                 'ard.AutoDraw(CurDir() & "\Box.wrl", "", 0, "file:///c:\contdoor.png", "", 0, True, False, "door", 0, False, "b")

                            '    ard1.StrtPt.x = LcontDor - 0.01           '.arc.length - 0.01
                            '    ard1.StrtPt.y = 0
                            '    ard1.StrtPt.z = 0
                            '    ard1.length = 0.5
                            '    ard1.width = ard.width
                            '    ard1.height = ard.height

                            '    'Stop

                            '    If DbxFlg Then
                            '        DbxFlgO = True
                            '    Else
                            '        DbxFlgO = False
                            '    End If

                            '    'ard.AutoDrawBxDrOpn1(CurDir() & "\First.wrl", "", 0, "file:///c:\contdoor.png", "", 0, True, False, "door", 0, False, "b")                                 'ard1.AutoDraw(CurDir() & "Box.wrl", "b", 0, "file:///c:\contdoor.png", "", 0, True, False, "door1", 0, False, "b")

                            '    ard.AutoDrawBxDrOpn1(CurDir() & "\First.wrl", "", 0, CurDir() & "\Graphics\contdoor.png", "", 0, True, False, "door", 0, False, "b")                                 'ard1.AutoDraw(CurDir() & "Box.wrl", "b", 0, "file:///c:\contdoor.png", "", 0, True, False, "door1", 0, False, "b")

                            '    DbxFlgO = False

                            '    '$$$$$
                            '    'First half door end 
                            '    '$$$$$
                            '    'Stop

                            '    '################################################################

                            '    '$$$$$
                            '    'Second half door begin 
                            '    '$$$$$

                            '    'Stop

                            '    ard.StrtPt.x = LcontDor             '.arc.length
                            '    ard.StrtPt.y = 0
                            '    ard.StrtPt.z = 0
                            '    ard.length = 0.5
                            '    ard.width = WcontDor * 0.5              '.arc.width * 0.5
                            '    ard.height = HcontDor               '.arc.height

                            '    If DbxFlg Then
                            '        DbxFlgO = True
                            '    Else
                            '        DbxFlgO = False
                            '    End If

                            '    'ard.AutoDrawBxDrOpn2(CurDir() & "\First.wrl", "", 0, "file:///c:\contdoor.png", "", 0, True, False, "door", 0, False, "b")

                            '    ard.AutoDrawBxDrOpn2(CurDir() & "\First.wrl", "", 0, CurDir() & "\Graphics\contdoor.png", "", 0, True, False, "door", 0, False, "b")

                            '    ard1.StrtPt.x = LcontDor                '.arc.length - 0.01
                            '    ard1.StrtPt.y = 0
                            '    ard1.StrtPt.z = 0
                            '    ard1.length = 0.5
                            '    ard1.width = ard.width
                            '    ard1.height = ard.height

                            '    'Stop

                            '    If DbxFlg Then
                            '        DbxFlgO = True
                            '    Else
                            '        DbxFlgO = False
                            '    End If

                            '    'ard.AutoDrawBxDrOpn2(CurDir() & "\First.wrl", "", 0, "file:///c:\contdoor.png", "", 0, True, False, "door", 0, False, "b")

                            '    ard.AutoDrawBxDrOpn2(CurDir() & "\First.wrl", "", 0, CurDir() & "\Graphics\contdoor.png", "", 0, True, False, "door", 0, False, "b")

                            '    DbxFlgO = False

                            '    '$$$$$
                            '    'First half door end 
                            '    '$$$$$

                            'End If

                            ''#######################################
                            ''Door 2 option End 
                            ''#######################################

                            ''***********************************************************************************************************************************************************************

                            '***********************************************************************************************************************************************************************

                            '#######################################
                            'Door 1 option begin 
                            '#######################################

                            If .rdb1D.Checked = True Then

                                ard.StrtPt.x = .arc.length
                                ard.StrtPt.y = 0
                                ard.StrtPt.z = 0
                                ard.length = 0.5
                                ard.width = .arc.width
                                ard.height = .arc.height

                                If DbxFlg Then
                                    DbxFlgO = True
                                Else
                                    DbxFlgO = False
                                End If

                                'ard.AutoDraw(CurDir() & "\First.wrl", "", 0, "file:///c:\contdoor.png", "", 0, True, False, "door", 0, False, "b", "1")

                                'If Not (TransactionMenu.pilotFlg) Then
                                'ard.AutoDraw(CurDir() & "\First.wrl", "", 0, CurDir() & "\Graphics\contdoor.png", "", 0, True, False, "door", 0, False, "b", "1")
                                ard.AutoDraw(CurDir() & WrlFn, "", 0, CurDir() & "\Graphics\contdoor.png", "", 0, True, False, "door", 0, False, "b", "1")
                                'End If

                                ard1.StrtPt.x = .arc.length - 0.01
                                ard1.StrtPt.y = 0
                                ard1.StrtPt.z = 0
                                ard1.length = 0.5
                                ard1.width = ard.width
                                ard1.height = ard.height

                                'Stop
                                If DbxFlg Then
                                    DbxFlgO = True
                                Else
                                    DbxFlgO = False
                                End If

                                'ard1.AutoDraw(CurDir() & "First.wrl", "b", 0, "file:///c:\contdoor.png", "", 0, True, False, "door1", 0, False, "b", "1")
                                'If Not (TransactionMenu.pilotFlg) Then
                                'ard1.AutoDraw(CurDir() & "First.wrl", "b", 0, CurDir() & "\Graphics\contdoor.png", "", 0, True, False, "door1", 0, False, "b", "1")
                                ard1.AutoDraw(CurDir() & WrlFn, "b", 0, CurDir() & "\Graphics\contdoor.png", "", 0, True, False, "door1", 0, False, "b", "1")
                                'End If

                                DbxFlgO = False

                            End If
                            '#######################################
                            'Door 1 option End 
                            '#######################################

                            'Stop

                            '#######################################
                            'Door 2 option begin 
                            '#######################################

                            '$$$$$
                            'First half door begin 
                            '$$$$$

                            If .rdb2D.Checked = True Then

                                ard.StrtPt.x = .arc.length
                                ard.StrtPt.y = 0
                                ard.StrtPt.z = 0
                                ard.length = 0.5
                                ard.width = .arc.width * 0.5
                                ard.height = .arc.height

                                If DbxFlg Then
                                    DbxFlgO = True
                                Else
                                    DbxFlgO = False
                                End If

                                'ard.AutoDrawBxDrOpn1(CurDir() & "\First.wrl", "", 0, "file:///c:\contdoor.png", "", 0, True, False, "door", 0, False, "b")                                 'ard.AutoDraw(CurDir() & "\Box.wrl", "", 0, "file:///c:\contdoor.png", "", 0, True, False, "door", 0, False, "b")

                                'If Not (TransactionMenu.pilotFlg) Then
                                'ard.AutoDrawBxDrOpn1(CurDir() & "\First.wrl", "", 0, CurDir() & "\Graphics\contdoor.png", "", 0, True, False, "door", 0, False, "b")                                 'ard.AutoDraw(CurDir() & "\Box.wrl", "", 0, "file:///c:\contdoor.png", "", 0, True, False, "door", 0, False, "b")
                                ard.AutoDrawBxDrOpn1(CurDir() & WrlFn, "", 0, CurDir() & "\Graphics\contdoor.png", "", 0, True, False, "door", 0, False, "b")
                                'End If

                                ard1.StrtPt.x = .arc.length - 0.01
                                ard1.StrtPt.y = 0
                                ard1.StrtPt.z = 0
                                ard1.length = 0.5
                                ard1.width = ard.width
                                ard1.height = ard.height

                                'Stop

                                If DbxFlg Then
                                    DbxFlgO = True
                                Else
                                    DbxFlgO = False
                                End If

                                'ard.AutoDrawBxDrOpn1(CurDir() & "\First.wrl", "", 0, "file:///c:\contdoor.png", "", 0, True, False, "door", 0, False, "b")                                 'ard1.AutoDraw(CurDir() & "Box.wrl", "b", 0, "file:///c:\contdoor.png", "", 0, True, False, "door1", 0, False, "b")
                                'If Not (TransactionMenu.pilotFlg) Then
                                'ard.AutoDrawBxDrOpn1(CurDir() & "\First.wrl", "", 0, CurDir() & "\Graphics\contdoor.png", "", 0, True, False, "door", 0, False, "b")                                 'ard1.AutoDraw(CurDir() & "Box.wrl", "b", 0, "file:///c:\contdoor.png", "", 0, True, False, "door1", 0, False, "b")
                                ard.AutoDrawBxDrOpn1(CurDir() & WrlFn, "", 0, CurDir() & "\Graphics\contdoor.png", "", 0, True, False, "door", 0, False, "b")
                                'End If

                                DbxFlgO = False

                                'off.Close()

                                'Stop

                                
                                '$$$$$
                                'First half door end 
                                '$$$$$
                                'Stop

                                '################################################################

                                '$$$$$
                                'Second half door begin 
                                '$$$$$

                                'Stop

                                ard.StrtPt.x = .arc.length
                                ard.StrtPt.y = 0
                                ard.StrtPt.z = 0
                                ard.length = 0.5
                                ard.width = .arc.width * 0.5
                                ard.height = .arc.height

                                If DbxFlg Then
                                    DbxFlgO = True
                                Else
                                    DbxFlgO = False
                                End If

                                'ard.AutoDrawBxDrOpn2(CurDir() & "\First.wrl", "", 0, "file:///c:\contdoor.png", "", 0, True, False, "door", 0, False, "b")
                                'If Not (TransactionMenu.pilotFlg) Then
                                'ard.AutoDrawBxDrOpn2(CurDir() & "\First.wrl", "", 0, CurDir() & "\Graphics\contdoor.png", "", 0, True, False, "door", 0, False, "b")
                                ard.AutoDrawBxDrOpn2(CurDir() & WrlFn, "", 0, CurDir() & "\Graphics\contdoor.png", "", 0, True, False, "door", 0, False, "b")
                                'End If

                                'off.Close()

                                'Stop

                                ard1.StrtPt.x = .arc.length - 0.01
                                ard1.StrtPt.y = 0
                                ard1.StrtPt.z = 0
                                ard1.length = 0.5
                                ard1.width = ard.width
                                ard1.height = ard.height

                                'Stop

                                If DbxFlg Then
                                    DbxFlgO = True
                                Else
                                    DbxFlgO = False
                                End If

                                'ard.AutoDrawBxDrOpn2(CurDir() & "\First.wrl", "", 0, "file:///c:\contdoor.png", "", 0, True, False, "door", 0, False, "b")
                                'If Not (TransactionMenu.pilotFlg) Then
                                'ard.AutoDrawBxDrOpn2(CurDir() & "\First.wrl", "", 0, CurDir() & "\Graphics\contdoor.png", "", 0, True, False, "door", 0, False, "b")
                                ard.AutoDrawBxDrOpn2(CurDir() & WrlFn, "", 0, CurDir() & "\Graphics\contdoor.png", "", 0, True, False, "door", 0, False, "b")
                                'End If

                                DbxFlgO = False

                                '$$$$$
                                'First half door end 
                                '$$$$$

                            End If

                            '#######################################
                            'Door 2 option End 
                            '#######################################

                            '***********************************************************************************************************************************************************************

                            'Stop

                            Bstrtclr = "r"

                            off.WriteLine("")
                            off.WriteLine("###########################################################################")
                            off.WriteLine("")

                            'Stop

                        Else

                            putqty = 0
                            For i As Integer = 0 To matchidx - 1
                                putqty += qtyarr1(i).qty
                            Next
                            stk.Clear()

                            If matchidx <> -1 Then
                                For i As Integer = 0 To qtyarr(matchidx - 1).stk.Count - 1
                                    stk.Add(qtyarr(matchidx - 1).stk(i))
                                Next
                            End If

                            'Stop       Door image file added
                            'If Not TransactionMenu.pilotFlg Then
                            '.arc.AutoDraw(CurDir() & "\First.wrl", 1, 0.5, CurDir() & "\Graphics\contdoor.png", "", 0, True, False, "container", 0, True, "b", "1")
                            .arc.AutoDraw(CurDir() & WrlFn, 1, 0.5, CurDir() & "\Graphics\contdoor.png", "", 0, True, False, "container", 0, True, "b", "1")
                            'End If

                            Dim ard As New Area
                            ard.StrtPt.x = .arc.length
                            ard.StrtPt.y = 0
                            ard.StrtPt.z = 0
                            ard.length = 0.5
                            ard.width = .arc.width
                            ard.height = .arc.height

                            'Stop
                            'ard.AutoDraw(CurDir() & "\First.wrl", "", 0, "file:///c:\contdoor.png", "", 0, True, False, "door", 0, False, "b", "1")
                            'If Not TransactionMenu.pilotFlg Then
                            'ard.AutoDraw(CurDir() & "\First.wrl", "", 0, CurDir() & "\Graphics\contdoor.png", "", 0, True, False, "door", 0, False, "b", "1")
                            ard.AutoDraw(CurDir() & WrlFn, "", 0, CurDir() & "\Graphics\contdoor.png", "", 0, True, False, "door", 0, False, "b", "1")
                            'End If

                            Dim ard1 As New Area
                            ard1.StrtPt.x = .arc.length - 0.01
                            ard1.StrtPt.y = 0
                            ard1.StrtPt.z = 0
                            ard1.length = 0.5
                            ard1.width = ard.width
                            ard1.height = ard.height

                            'Stop

                            'ard1.AutoDraw(CurDir() & "First.wrl", "b", 0, "file:///c:\contdoor.png", "", 0, True, False, "door1", 0, False, "b", "1")
                            'If Not TransactionMenu.pilotFlg Then
                            'ard1.AutoDraw(CurDir() & "First.wrl", "b", 0, CurDir() & "\Graphics\contdoor.png", "", 0, True, False, "door1", 0, False, "b", "1")
                            ard1.AutoDraw(CurDir() & WrlFn, "b", 0, CurDir() & "\Graphics\contdoor.png", "", 0, True, False, "door1", 0, False, "b", "1")
                            'End If

                            Dim col1 As String = "r"
                            Bplclst.Clear()
                            Bqtylst.Clear()
                            Dim qtyx As Integer = 0
                            qtyarr.Clear()
                            Dim ahistarr1 As New List(Of r1)

                            ahistarr1.Clear()
                            'Form8.Label1.Text = "Please wait ....."
                            'Form8.Label2.Text = ""
                            'Form8.Button1.Visible = False
                            'Form8.Show()

                            .btnStatus.Visible = False
                            .lblStatus.Visible = True
                            .lblStatusINm.Visible = True

                            .pbCSP1.Visible = True
                            ProgressBarRunning()

                            .lblStatus.Text = "Please wait ....."

                            If .dgv1.CurrentCell.ColumnIndex = 12 Then
                                .showemp = False
                            ElseIf .dgv1.CurrentCell.ColumnIndex = 13 Then
                                .showemp = True
                            End If

                            If stk.Count = 0 Then

                                If .showemp Then
                                    MsgBox("Container Is Fully Occupied. No Empty Area Left", MsgBoxStyle.Critical + vbOKOnly)
                                    Exit Sub
                                End If

                            End If

                            Dim ar11 As New Area

                            For i As Integer = 0 To stk.Count - 1

                                ar11 = stk(i)
                                If .showemp Then
                                    'If Not TransactionMenu.pilotFlg Then
                                    'ar11.AutoDraw(CurDir() & "First.wrl", "r", 0, "", CStr(i + 1), 0, False, True, "E", 0, False, "b", "1")
                                    ar11.AutoDraw(CurDir() & WrlFn, "r", 0, "", CStr(i + 1), 0, False, True, "E", 0, False, "b", "1")
                                    'End If
                                End If

                            Next

                            If .showemp Then

                                Try
                                    'Closef(CurDir() & "\First.wrl")
                                    Closef(CurDir() & WrlFn)
                                    'Form8.Close()

                                    .lblStatus.Visible = False
                                    .lblStatusINm.Visible = False
                                    .btnStatus.Visible = False

                                    .pbCSP1.Visible = False

                                    Eventless()

                                    '#################@@@@@@@@@@@@@@@@@@@@@@@@@@

                                    'ThreeDViewer()
                                    '#################@@@@@@@@@@@@@@@@@@@@@@@@@@
                                    'Dim RsultStr As String

                                    '##############

                                    Call Show3DView()

                                    'Try

                                    '    Dim FName As String = CurDir() & "\First.wrl"
                                    '    Process.Start("c:\Program Files\Alteros 3D\alteros.exe", FName)

                                    'Catch Err As Exception
                                    '    MsgBox(Err.Message)
                                    '    MsgBox(Err.ToString)
                                    '    MessageBox.Show("Error in Alteros 3D running", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    '    conn.Close()
                                    '    off.Close()
                                    '    MessageBox.Show("Error in ShowButton", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    '    MsgBox("Exit Application")
                                    '    Application.Exit()
                                    'End Try

                                    '##############

                                    'RsultStr = MsgBox("Do you show stuffing in three dimensional (Isometric) view ?", MsgBoxStyle.YesNo, "3DViewer")
                                    'If RsultStr = MsgBoxResult.Yes Then

                                    '    ThreeDViewer() ' (3D)Three Dimentional Arrangement are shown 
                                    'Else
                                    '    Dim Str As String

                                    '    Str = MsgBox("Do you close stuffing entry?", MsgBoxStyle.YesNo, "Stuffing Entry ...")
                                    '    If Str = MsgBoxResult.Yes Then
                                    '        .Close()
                                    '    Else
                                    '        .Focus()
                                    '    End If
                                    'End If
                                    'ThreeDViewer() ' (3D)Three Dimentional Arrangement are shown 
                                    '#################@@@@@@@@@@@@@@@@@@@@@@@@@@

                                Catch Ex As Exception
                                    MsgBox(Ex.Message)
                                    MsgBox(Ex.ToString)
                                    MsgBox(Ex.Message, MsgBoxStyle.Critical, "Message :: In method 'MouseClick'  " & vbCrLf & "VRML Programme Running is failure!")
                                    .Close()

                                Finally
                                    'Form8.Close()

                                    .lblStatus.Visible = False
                                    .lblStatusINm.Visible = False
                                    .btnStatus.Visible = False

                                    .pbCSP1.Visible = False

                                    Eventless()
                                End Try

                                Exit Sub
                            End If

                            Bitemno = 0

                            For i As Integer = 0 To putqty - 1
                                qtyx += 1
                                'If Not TransactionMenu.pilotFlg Then
                                'Bahistarr(i).ar.AutoDraw(CurDir() & "First.wrl", col1, 0, "file\\\c:\t2.png", Bahistarr(i).itmnm, 0, False, True, "", Bahistarr(i).method, False, "b", "1")
                                Bahistarr(i).ar.AutoDraw(CurDir() & WrlFn, col1, 0, "file\\\c:\t2.png", Bahistarr(i).itmnm, 0, False, True, "", Bahistarr(i).method, False, "b", "1")
                                'End If

                                ahistarr1.Add(Bahistarr(i))
                                If i = putqty - 1 Then
                                    plclst1.Add(qtyx)

                                    Bqtylst.Add(qtyx)

                                    Dim m1 As New e1
                                    m1.itmnm = Bahistarr(i).itmnm
                                    m1.qty = qtyx
                                    m1.stk = Bahistarr(i).stk
                                    qtyarr.Add(m1)

                                    qtyx = 0
                                    Exit For

                                End If

                                If Bahistarr(i).itmnm <> Bahistarr(i + 1).itmnm Then

                                    Bitemno += 1
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
                                    plclst1.Add(qtyx)
                                    Bqtylst.Add(qtyx)

                                    Dim m1 As New e1
                                    m1.itmnm = Bahistarr(i).itmnm
                                    m1.qty = qtyx
                                    m1.stk = Bahistarr(i).stk
                                    qtyarr.Add(m1)
                                    qtyx = 0

                                End If
                            Next

                            Bitemno += 1
                            'Form8.Close()

                            .lblStatus.Visible = False
                            .lblStatusINm.Visible = False
                            .btnStatus.Visible = False

                            .pbCSP1.Visible = False

                            Eventless()

                            Bahistarr.Clear()
                            For i As Integer = 0 To ahistarr1.Count - 1
                                Bahistarr.Add(ahistarr1(i))
                            Next

                            Bplclst.Clear()
                            For i As Integer = 0 To Bqtylst.Count - 1
                                Bplclst.Add(Bqtylst(i) - 1)
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
                            Bstrtclr = col1
                            'Stop

                        End If
                        '*************
                        'Stop
                        '*************
                        Dim Stk1 As New List(Of Area)
                        Dim Stk2 As New List(Of Area)

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
                        Dim Itmnm As String = Nothing
                        Dim SLbl As String

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
                        Dim wt As String = Nothing
                        Dim transparr() As Boolean
                        Dim transp As Boolean
                        Dim topup() As Boolean
                        Dim Tpup As Boolean

                        ReDim ar(0)
                        ReDim ari(0)
                        ReDim arwt(0)
                        ReDim transparr(0)
                        ReDim topup(0)
                        ReDim arl(0)

                        Dim cmd As New OleDb.OleDbCommand

                        Dim cntx As Integer = 0

                        Dim plcqty As Integer = 0

                        Dim k As Integer
                        Dim m As Integer

                        DelTab("temp1")

                        If .CmbContainer.Text = "" Then
                            MsgBox("Container not selected", MsgBoxStyle.Critical + vbOKOnly)
                            MessageBox.Show("Container not selected", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            .CmbContainer.Focus()
                            Exit Sub
                        End If

                        'Form8.Label1.Text = "Please wait ....."
                        'Form8.Label2.Text = ""
                        'Form8.Button1.Visible = False
                        .btnStatus.Visible = False
                        'Form8.Show()

                        .lblStatus.Text = "Please wait ....."
                        .lblStatus.Visible = True
                        .lblStatusINm.Visible = True
                        .btnStatus.Visible = False

                        .pbCSP1.Visible = True
                        ProgressBarRunning()

                        System.Windows.Forms.Application.DoEvents()

                        Dim i1, j1 As Integer
                        Dim extflg As Boolean = False

                        Dim zz As Integer

                        zz = rowno1

                        Dim matchidx1 As Integer
                        If matchidx = -1 Then
                            matchidx1 = 0
                        Else
                            matchidx1 = matchidx
                        End If

                        'Stop

                        Try

                            If Not ADclFlg Then

                                For i1 = matchidx1 To zz
                                    Try
                                        Itmnm = .dgv1.Item(1, i1).Value
                                        ln = Math.Round(.dgv1.Item(4, i1).Value, 4)
                                        wd = Math.Round(.dgv1.Item(5, i1).Value, 4)
                                        ht = Math.Round(.dgv1.Item(6, i1).Value, 4)
                                        qty = .dgv1.Item(11, i1).Value

                                        wt = .dgv1.Item(8, i1).Value
                                        seq = .dgv1.Item(0, i1).Value

                                        transp = False

                                        Tpup = IIf(.dgv1.Item(7, i1).Value = "6", False, True)

                                        Bqtylst.Add(qty)
                                    Catch
                                    End Try

                                    'Stop

                                    For j1 = 0 To qty - 1

                                        totqty1 += 1

                                        qtyf = True

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
                                        ari(UBound(ari)) = Itmnm
                                        arwt(UBound(arwt)) = wt
                                        transparr(UBound(transparr)) = transp
                                        topup(UBound(topup)) = Tpup

                                        ReDim Preserve ar(UBound(ar) + 1)
                                        ReDim Preserve ari(UBound(ari) + 1)
                                        ReDim Preserve arwt(UBound(arwt) + 1)
                                        ReDim Preserve transparr(UBound(transparr) + 1)
                                        ReDim Preserve topup(UBound(topup) + 1)

                                    Next

                                Next i1

                                'Stop

                                '!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                            Else
                                '!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!D

                                For i1 = matchidx1 To zz

                                    Itmnm = .dgv1.Item(1, i1).Value
                                    ln = Math.Round(.dgv1.Item(4, i1).Value, 4)
                                    wd = Math.Round(.dgv1.Item(5, i1).Value, 4)
                                    ht = Math.Round(.dgv1.Item(6, i1).Value, 4)
                                    qty = .dgv1.Item(11, i1).Value

                                    wt = .dgv1.Item(8, i1).Value
                                    seq = .dgv1.Item(0, i1).Value
                                    SLbl = .dgv1.Item(15, i1).Value

                                    If SLbl = Nothing Then
                                        SLbl = Itmnm
                                    End If

                                    transp = False

                                    Tpup = IIf(.dgv1.Item(7, i1).Value = "6", False, True)

                                    Bqtylst.Add(qty)

                                    'Stop

                                    For j1 = 0 To qty - 1

                                        totqty1 += 1

                                        qtyf = True

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
                                        ari(UBound(ari)) = Itmnm
                                        arwt(UBound(arwt)) = wt
                                        transparr(UBound(transparr)) = transp
                                        topup(UBound(topup)) = Tpup
                                        arl(UBound(arl)) = SLbl

                                        ReDim Preserve ar(UBound(ar) + 1)
                                        ReDim Preserve ari(UBound(ari) + 1)
                                        ReDim Preserve arwt(UBound(arwt) + 1)
                                        ReDim Preserve transparr(UBound(transparr) + 1)
                                        ReDim Preserve topup(UBound(topup) + 1)
                                        ReDim Preserve arl(UBound(arl) + 1)

                                    Next

                                Next i1

                                'Stop
                                '!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!D

                            End If

                        Catch Err As Exception
                            MsgBox(Err.Message)
                            MsgBox(Err.ToString)
                            MessageBox.Show("Error in Datagrid entry looping entry to stuffing assigning", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try

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
                            plcqty = plcqty + Bplclstf(i) - 1
                        Next

                        ReDim Preserve ar(UBound(ar) - 1)
                        ReDim Preserve ari(UBound(ari) - 1)
                        ReDim Preserve arwt(UBound(arwt) - 1)
                        ReDim Preserve transparr(UBound(transparr) - 1)
                        ReDim Preserve topup(UBound(topup) - 1)

                        If ADclFlg Then
                            ReDim Preserve arl(UBound(arl) - 1)
                        End If

                        stp += 1

                        Dim ar2() As Area
                        Dim ari2() As String
                        Dim arwt2() As Single
                        Dim transparr2() As Boolean

                        ReDim ar2(0)
                        ReDim ari2(0)
                        ReDim arwt2(0)
                        ReDim transparr2(0)

                        '*************
                        'Stop
                        '*************
                        For i As Integer = LBound(ar) To UBound(ar)

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

                        Try
                            ReDim Preserve topup(UBound(topup) - 1)
                        Catch

                        End Try

                        '*************
                        'Stop
                        '*************
                        If stp = .dgv1.RowCount Then
                            stp = 0
                            cnt = 0
                        End If

                        .arc.StrtPt.x = 0
                        .arc.StrtPt.y = 0
                        .arc.StrtPt.z = 0
                        ''.ARC.length = contarr(0)
                        ''.ARC.width = contarr(1)
                        ''.ARC.height = contarr(2)

                        .arc.length = CL
                        .arc.width = CW
                        .arc.height = CH

                        qty = 0
                        'Form8.Close()

                        .lblStatus.Visible = False
                        .lblStatusINm.Visible = False
                        .btnStatus.Visible = False

                        .pbCSP1.Visible = False

                        Eventless()

                        'Stop

                        'Dim outfile As String = CurDir() & "\First.wrl"
                        Dim outfile As String = CurDir() & WrlFn

                        Try

                            Xl3d = 0        'Initialising the optimum stuff
                            Yl3d = 0
                            Zl3d = 0

                            RiCnt = 0
                            flg_RiCnt = False

                            If conn.State = ConnectionState.Closed Then conn.Open()

                            TransactionMenu.lblCG.Text = ""

                            Dim Cmdo As New OleDb.OleDbCommand
                            Cmdo.Connection = conn
                            Cmdo.CommandText = "delete from pgRecord"
                            Cmdo.ExecuteNonQuery()

                            Dim CmdOp As New OleDb.OleDbCommand
                            CmdOp.Connection = conn
                            CmdOp.CommandText = "delete from pgCord"
                            CmdOp.ExecuteNonQuery()

                        Catch ex As Exception
                            MsgBox(ex.Message)
                            MsgBox(ex.ToString)
                            MessageBox.Show("Error in OptStuff Module", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try

                        If ar.Length > 0 Then
                            If stk.Count = 0 Then stk.Add(.arc)
                            Bitemqty = 0
                            Bplclst.Clear()
                            Btxtopt = False
                            'Stop
                            If .dgv1.CurrentCell.ColumnIndex = 12 Then

                                If .chkbxWadStuff.Checked Then

                                    '###########################################
                                    Try

                                        'MessageBox.Show("Work in progress wad stuff is done", "Wad stuff info.....", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        'Stop
                                        'Stk2 = WadBoxStuff(.ARC, ar2, ari2, arwt2, False, False, outfile, True, transparr2, topup, Btxtopt, True, False, True, colarr)

                                        Stk2 = BoxStuff(.arc, ar2, ari2, arwt2, False, False, outfile, True, transparr2, topup, Btxtopt, True, False, True, .colarr, .dgv1)

                                        mClk = False

                                        'Stk2 = Stuffx(.ARC, ar2, ari2, arwt2, False, False, outfile, True, transparr2, topup, Btxtopt, True, False, True, colarr)
                                        'LibWrapper.stuff(.ARC, ar2, ari2, arwt2, False, False, outfile, True, transparr2, topup, Btxtopt, True, False, True, colarr)

                                        GoTo BxStfEnd

                                    Catch ex As Exception
                                        MsgBox(ex.Message)
                                        MsgBox(ex.ToString)
                                        MessageBox.Show("Error in Stuff", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    End Try

                                    '###########################################

                                End If

                                If .chkBxPlyStuff.Checked Then

                                    Try
                                        Dim RiQ As Int32 = 0
                                        Do While (TransactionMenu.dgv1.RowCount - 2)

                                            .dgv1.Item(15, RiQ).Value = ""
                                            .dgv1.Item(16, RiQ).Value = ""
                                            RiQ += 1
                                        Loop
                                    Catch
                                    Finally
                                        .dgv1.Refresh()
                                    End Try

                                    Try
                                        TransactionMenu.pnlPbinfo.Visible = True
                                        TransactionMenu.pbCSP1.Visible = True
                                        TransactionMenu.lblStatus.Visible = True
                                        TransactionMenu.lblStatus.Text = "Please wait….. Stuffing is progress."
                                        TransactionMenu.lblStatus.Refresh()

                                        PlyIno = 0                  'Ply stuff initiialisation
                                        PlyInm = Nothing

                                        '$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

                                        Dim PlyAr As New Area
                                        Dim RemAr As New Area
                                        Dim PlyCnt As Integer
                                        Dim Grt As Double
                                        Dim BunchFlg As Boolean = False
                                        Dim ItmPlaced As Int64 = 0

                                        PlyAr.StrtPt.x = 0
                                        PlyAr.StrtPt.y = 0
                                        PlyAr.StrtPt.z = 0

                                        For i As Integer = 0 To .dgv1.RowCount - 2

                                            PlysQty = 0

                                            qty = .dgv1.Item(11, i).Value            'qty = .dgv1.Item(11, 0).Value

                                            PlyAr.length = Math.Round(.dgv1.Item(4, i).Value, 4)         'PlyAr.length = Math.Round(.dgv1.Item(4, 0).Value, 4)
                                            PlyAr.width = Math.Round(.dgv1.Item(5, i).Value, 4)          'PlyAr.width = Math.Round(.dgv1.Item(5, 0).Value, 4)
                                            PlyAr.height = Math.Round(.dgv1.Item(6, i).Value, 4)         'PlyAr.height = Math.Round(.dgv1.Item(6, 0).Value, 4)

                                            Itmnm = .dgv1.Item(1, i).Value           'Itmnm = .dgv1.Item(1, 0).Value

                                            Dim Lpt As Double
                                            Dim Wpt As Double
                                            Dim Hpt As Double

                                            Dim cLpt As Double
                                            Dim cWpt As Double
                                            Dim cHpt As Double

                                            Lpt = PlyAr.length
                                            Wpt = PlyAr.width
                                            Hpt = PlyAr.height

                                            cLpt = .arc.length
                                            cWpt = .arc.width
                                            cHpt = .arc.height

                                            BunchFlg = Buncher(Lpt, Wpt, Hpt, cLpt, cWpt, cHpt, qty, False)

                                            PlyCnt = StuffPly(.arc, PlyAr, True, True, qty, Itmnm)

                                            RemAr = PlyDrwLst(PlyCnt - 1)

                                            Dim Lp As Double
                                            Dim Wp As Double
                                            Dim Hp As Double

                                            Dim cLp As Double
                                            Dim cWp As Double
                                            Dim cHp As Double

                                            Lp = PlyAr.length
                                            Wp = PlyAr.width
                                            Hp = PlyAr.height

                                            cLp = .arc.length
                                            cWp = .arc.width
                                            cHp = .arc.height

                                            Grt = Greater(Lp, Wp, Hp, cLp, cWp, cHp, qty, False)

                                            If Grt = Nothing Then
                                                Grt = PlyAr.length
                                            End If

                                            '********************************************************************************************************************************************************
                                            'If RemAr.StrtPt.x = Grt Then                 'If RemAr.StrtPt.x = grtFac Or RemAr.StrtPt.x = Grt Then
                                            'PlyAr.StrtPt.x = RemAr.StrtPt.x
                                            'PlyAr.StrtPt.y = 0
                                            'PlyAr.StrtPt.z = 0
                                            'Else
                                            ' ''PlyAr.StrtPt.x = RemAr.StrtPt.x + Grt               'PlyAr.StrtPt.x = RemAr.StrtPt.x + PlyAr.length '
                                            ' ''PlyAr.StrtPt.y = 0
                                            ' ''PlyAr.StrtPt.z = 0
                                            'End If
                                            '********************************************************************************************************************************************************

                                            If BunchFlg Then
                                                BunchFlg = False
                                                PlyAr.StrtPt.x = RemAr.StrtPt.x
                                                PlyAr.StrtPt.y = 0
                                                PlyAr.StrtPt.z = 0
                                            Else
                                                PlyAr.StrtPt.x = RemAr.StrtPt.x + Grt               'PlyAr.StrtPt.x = RemAr.StrtPt.x + PlyAr.length '
                                                PlyAr.StrtPt.y = 0
                                                PlyAr.StrtPt.z = 0
                                            End If

                                            ItmPlaced = (PlyCnt - 1).ToString - PlysQty

                                            .dgv1.Item(16, i).Value = ItmPlaced

                                            ItmPlaced = qty - ItmPlaced

                                            .dgv1.Item(15, i).Value = ItmPlaced

                                            .dgv1.Refresh()

                                        Next i

                                        'Stop

                                        MessageBox.Show("In Ply Stuff item name '" & Itmnm & "'  out of  " & qty & "  quantity only  " & ItmPlaced & "  placed", .Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

                                        'MsgBox((PlyCnt - 1).ToString & " Items placed")

                                        PlyCnt = 0

                                        'Closef(outfile)

                                        '$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

                                    Catch Exx As Exception
                                        MsgBox(Exx.Message)
                                        MsgBox(Exx.ToString)
                                        MessageBox.Show("Error in Plystuff ShowButton", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    Finally
                                        TransactionMenu.pnlPbinfo.Visible = False
                                        TransactionMenu.pbCSP1.Visible = False
                                        TransactionMenu.lblStatus.Text = ""
                                        TransactionMenu.lblStatus.Visible = False
                                        Eventless()
                                    End Try

                                    GoTo PlyEnd
                                End If

                                If ADclFlg Then
                                    BoxLBLStuff(.arc, ar2, ari2, arl, arwt2, False, False, outfile, True, transparr2, topup, Btxtopt, True, False, True, .colarr)
                                    GoTo BxStfEnd
                                End If

                                If .chkBxPlyStuff.Checked Or .chkbxOptStuff.Checked Or .chkbxManualChng.Checked Then
                                    MoveBoxStuff(.arc, ar2, ari2, arwt2, False, False, outfile, True, transparr2, topup, Btxtopt, True, False, True, .colarr)
                                    GoTo BxStfEnd
                                End If

                                'If .chkbxOptStuff.Checked Then
                                '    BoxStuff_Optm(.ARC, ar2, ari2, arwt2, False, False, outfile, True, transparr2, topup, Btxtopt, True, False, True, colarr)
                                'End If

                                If Not .CheckBox1.Checked AndAlso Not .chkBxPlyStuff.Checked Then


                                    'Dim ThreadStuff As Thread = New Thread(New ThreadStart(AddressOf BoxStuffTh))

                                    'ThreadStuff.Start()

                                    'Thread.Sleep(5000)
                                    Stk2 = BoxStuff(.arc, ar2, ari2, arwt2, False, False, outfile, True, transparr2, topup, Btxtopt, True, False, True, .colarr, .dgv1)

                                ElseIf .CheckBox1.Checked Then

                                    Dim ar12 As New Area

                                    qty = .dgv1.Item(11, 0).Value

                                    ar12.StrtPt.x = 0
                                    ar12.StrtPt.y = 0
                                    ar12.StrtPt.z = 0
                                    ar12.length = Math.Round(.dgv1.Item(4, 0).Value, 4)
                                    ar12.width = Math.Round(.dgv1.Item(5, 0).Value, 4)
                                    ar12.height = Math.Round(.dgv1.Item(6, 0).Value, 4)

                                    Dim pt As New Point
                                    pt.x = ar1.length
                                    pt.y = ar1.width
                                    pt.z = ar1.height

                                    Itmnm = .dgv1.Item(1, 0).Value

                                    '*********
                                    'Stop
                                    '*********
                                    Dim hg As Integer = 0

                                    totqty = 0

                                    hg = Stuffy(.arc, ar12, True, True, qty, Itmnm)

                                    qty = 0

                                    MsgBox((hg - 1).ToString & " Items placed", , .Text)

                                    hg = 0

                                    '' Closef(outfile)      'Close file after writing the CG Program

                                End If
                                .showemp = True

                            End If

BxStfEnd:
                            '****************
                            ' Stop
                            '****************
                            Dim emvol As Double = 0
                            For kk As Integer = 0 To stk.Count - 1
                                emvol = emvol + (stk(kk).length * stk(kk).width * stk(kk).height)
                            Next
                            emvol = emvol * (0.0254 * 0.0254 * 0.0254)
                            .TxtFreeCbm.Text = Format(emvol, "0.000")
                            .TxtOccuCbm.Text = Format((CDbl(.TxtCapacity.Text) - CDbl(.TxtFreeCbm.Text)), "0.000")
                            Dim persFact As Double = CDbl(CDbl(.TxtCapacity.Text) * 0.01)
                            .TxtpercentVolOcc.Text = Format(CDbl(.TxtOccuCbm.Text / persFact), "0.00")
                            Call CompactPer()
                            If .dgv1.CurrentCell.ColumnIndex = 12 Then
                                .showemp = False
                            ElseIf .dgv1.CurrentCell.ColumnIndex = 13 Then
                                .showemp = True
                            End If
                            Dim mn As Integer = 0

                            Dim are As Area
                            stkmm.Clear()
                            Dim vol1 As Double
                            For jjj As Integer = 0 To Stk2.Count - 1
                                vol1 = vol1 + (Stk2(jjj).length * Stk2(jjj).width * Stk2(jjj).height)
                            Next
                            For rr As Integer = 0 To Stk2.Count - 1
                                are = New Area
                                are.StrtPt.x = Stk2(rr).StrtPt.x
                                are.StrtPt.y = Stk2(rr).StrtPt.y
                                are.StrtPt.z = Stk2(rr).StrtPt.z
                                are.length = Stk2(rr).length
                                are.width = Stk2(rr).width
                                are.height = Stk2(rr).height
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

                                If CInt(.dgv1.Item(11, i).Value) > Bqtylst(i) + 1 Then
                                    Dim qtyv As Integer
                                    If Bqtylst(i) <= 0 Then
                                        qtyv = 0
                                    Else
                                        qtyv = Bqtylst(i) + 1
                                    End If
                                    'MsgBox(.dgv1.Item(11, i).Value.ToString & " no of " & .dgv1.Item(1, i).Value & " cannot be placed." & vbCrLf & CStr(qtyv) & " placed.", MsgBoxStyle.Information + vbOKOnly)

                                    If Not TransactionMenu.Enabled = False Then

                                        MessageBox.Show(.dgv1.Item(11, i).Value.ToString & " no of " & .dgv1.Item(1, i).Value & " cannot be placed. " & vbCrLf & CStr(qtyv) & " placed.", "Stuffing Entry", MessageBoxButtons.OK)

                                    End If

                                    drwstp = drwstp - Bqtylst(i) + Bplclst(i) + 1
                                    Bqtylst(i) = Bplclst(i) + 1

                                End If
                            Next

                            If Not .CheckBox1.Checked Then

                                Try
                                    .TxtOccuKgs.Text = Format(CDbl(.dgv1.Item(8, .dgv1.CurrentCell.RowIndex).Value) * (Bplclst(CInt(.dgv1.CurrentCell.RowIndex)) + 1), "0.000")
                                    .TxtFreeKgs.Text = Format(CDbl(.TxtPayLoad.Text) - CDbl(.TxtOccuKgs.Text), "0.000")

                                    For i As Integer = 0 To rowno1
                                        Dim qtyv As Integer = Bplclst(i)
                                        qtyv += 1
                                        If .CheckBox1.Checked = True Then
                                            If fullflag Then
                                                'qtyv = xcnt - 1
                                                qtyv = xcnt
                                            Else
                                                qtyv = xcnt
                                            End If
                                        End If
                                        If CInt(.dgv1.Item(11, i).Value) > qtyv Then
                                            'MsgBox(.dgv1.Item(11, i).Value.ToString & " no of " & .dgv1.Item(1, i).Value & " cannot be placed." & vbCrLf & CStr(qtyv) & " placed.", MsgBoxStyle.Information + vbOKOnly)

                                            If Not TransactionMenu.Enabled = False Then

                                                MessageBox.Show(.dgv1.Item(11, i).Value.ToString & " no of " & .dgv1.Item(1, i).Value & " cannot be placed." & vbCrLf & CStr(qtyv) & " placed.", "Stuffing Entry", MessageBoxButtons.OK)
                                                '.dgv1.Item(11, i).Value = qtyv
                                            End If

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
                                    Dim bn As Integer
                                    If matchidx = -1 Then
                                        bn = 0
                                    Else
                                        bn = matchidx
                                    End If
                                    For i As Integer = 0 To Bqtylst.Count - 1
                                        totqty = totqty + Bqtylst(i)
                                    Next

                                    plcqty = 0
                                    For i As Integer = 0 To Bplclstf.Count - 1
                                        plcqty = plcqty + Bplclstf(i)
                                    Next

                                Catch
                                End Try


SBMCEnd:
                                Do While Not .dgEmpty.RowCount = 0
                                    Try
                                        .dgEmpty.Rows.Remove(.dgEmpty.Rows(0))
                                    Catch
                                        Exit Do
                                    End Try
                                Loop

                                Do While Not .dgUsage.RowCount = 0

                                    Try
                                        .dgUsage.Rows.Remove(.dgUsage.Rows(0))
                                    Catch
                                        Exit Do
                                    End Try
                                Loop

                                button3_click(Oform, .showemp, .arc)
                                ''Closef(CurDir() & "\First.wrl")          'Close file after writing the CG Program

                            End If
                        End If

                        Dim dq As Char = Chr(34)

                        'ThreeDViewer()
                        '#################@@@@@@@@@@@@@@@@@@@@@@@@@@
                        'Dim RsltStr As String
                        'Dim RsltSv As String

                        'RsltSv = MessageBox.Show("Auto file save ", "Stuff viewer Box file save", MessageBoxButtons.YesNo, MessageBoxIcon.Information)

                        'Dim dof As Stuff_Viewers = New Stuff_Viewers
                        'dof.DestroyOldFile("C:\CSP.Box.wrl")

                        ''If RsltSv = MsgBoxResult.Yes Then
                        'FinalOutPutWriter()
                        ''Else

                        'Stuff_Viewers.Show()
                        'Stuff_Viewers.Focus()
                        'End If

                        'RsltStr = MsgBox("Do you show stuffing in three dimensional (Isometric) view ?", MsgBoxStyle.YesNo, "3DViewer")
                        'If RsltStr = MsgBoxResult.Yes Then

                        '#####

                        'If chkBxAutoStuff.Checked Then                  'If Not chkBxAutoStuff.Checked Then
PlyEnd:

                        '*****************************************************************************************************************************************
                        Closef(outfile)

                        If .chkbxCG.Checked = True Then

                            Call cgManipulation()

                        End If

                        CloseVRML(outfile) 'Close the VRML File

                        'If TransactionMenu.btnStepTrials.BackColor = Color.HotPink Then

                        '    Dim stpFnm As String = CurDir() & "\OutPut\Firststp" & StepCount & ".wrl"

                        '    StepCount += 1

                        '    My.Computer.FileSystem.CopyFile(outfile, stpFnm, True)

                        '    frmStep.AddSteps(StepCount)

                        'End If

                        If Not TransactionMenu.TrlOFlg And Not TransactionMenu.btnStepTrials.BackColor = Color.HotPink Then

                            Call Show3DView()

                        End If

                        If TransactionMenu.btnStepTrials.BackColor = Color.HotPink Then
                            MessageBox.Show("The Step Trial’s stuffing is finish.", "Step Trial's", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                        'Try

                        '    Dim FName As String = CurDir() & "\First.wrl"
                        '    Process.Start("c:\Program Files\Alteros 3D\alteros.exe", FName)

                        'Catch Err As Exception
                        '    MsgBox(Err.Message)
                        '    MsgBox(Err.ToString)
                        '    MessageBox.Show("Error in Alteros 3D running", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        '    conn.Close()
                        '    off.Close()
                        '    MessageBox.Show("Fatal error in ShowButton", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        '    MsgBox("Exit Application")
                        '    Application.Exit()
                        'End Try

                        '*****************************************************************************************************************************************

                        'End If

                        '#####

                        'ThreeDViewer() ' (3D)Three Dimentional Arrangement are shown 

                        'Else
                        'Dim Str As String

                        'Str = MsgBox("Do you close stuffing entry?", MsgBoxStyle.YesNo, "Stuffing Entry ...")
                        'If Str = MsgBoxResult.Yes Then
                        '.Close()
                        'Else
                        '.Focus()
                        ' End If

                        'ThreeDViewer() ' (3D)Three Dimentional Arrangement are shown 
                        '#################@@@@@@@@@@@@@@@@@@@@@@@@@@

                        Bplclst.Clear()
                        Bqtylst.Clear()
                        'End If
                    End If

            '________________________________________________'SBMCEnd:

            'If chkBxAutoStuff.Checked Then
            '    MessageBox.Show("Auto arrangement stuff in randomly quantity managed is done ", "Container stuff Auto arrangement stuff info.....", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    'off.Close()
            '    'Iow.Close()
            '    chkBxAutoStuff.Checked = False
            '    '.Column10.Width = 62
            '    .Column10.HeaderText = "USQt"
            '    .dgv1.Refresh()
            '    ShowButton.Visible = False
            '    GoTo StfSrtAt
            'End If

                Catch Ex As Exception
                MsgBox(Ex.Message)
                MsgBox(Ex.ToString)
                MessageBox.Show("Error in ShowButton_MouseClick" & vbCrLf & "Programme Running is failure!", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Try
                    conn.Close()
                    off.Close()
                Catch
                    MsgBox("Fatal error..... , Exit Application")
                    Application.Exit()
                End Try
                MessageBox.Show("Fatal error in ShowButton", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
                MsgBox("Exit Application")
                Application.Exit()
            Finally
                .btnPilot.Enabled = True
                .chkBxAutoStuff.Enabled = True
                Bplclst.Clear()
                Bqtylst.Clear()
                .BoxStatusStriplbl.Text = "Pick the activity"
                mClk = False

            End Try

            End If

        End With
    End Sub

    'Public Sub BoxStuffTh()

    '    Stk2Th = BoxStuff(ArcTh, Ar2Th, Ari2Th, Arwt2Th, False, False, OutFileTh, True, transparr2Th, topupTh, BtxtoptTh, True, False, True, colarrTh, dgv1Th)

    'End Sub

    Public Sub Show3DView()

        Try

            'Try

            '    Dim FName As String = CurDir() & "\First.wrl"
            '    Process.Start("c:\Program Files\Alteros 3D\alteros.exe", FName)

            'Catch Err As Exception
            '    MsgBox(Err.Message)
            '    MsgBox(Err.ToString)
            '    MessageBox.Show("Error in Alteros 3D running", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    conn.Close()
            '    off.Close()
            '    MessageBox.Show("Fatal error in ShowButton", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    MsgBox("Exit Application")
            '    Application.Exit()
            'End Try

            '************************************

            Dim Pwd As String = "satwadhir"

            'Dim FName As String = CurDir() & "\First.wrl"
            Dim FName As String = CurDir() & WrlFn

            Dim AltPath As String = "C:\Program Files\Alteros 3D\alteros.exe"

            Dim Fr As New System.IO.StreamReader(CurDir() & "\CSP.SAT")

            Pwd = Fr.ReadLine()

            Try
                Dim usNm As String = "SATWADHIR\Administrator"

                Dim password As New Security.SecureString()

                'password.AppendChar(Pwd)

                password.AppendChar(Fr.ReadLine())

                Dim dom As String

                dom = "hazelinfo1"

                dom = ""


                Try

                    myProcess = Process.Start(FName)

                    'Pwd = InputBox("Application start enter username, password, domain ")
                    'myProcess = Process.Start(AltPath, FName )
                    ' myProcess = Process.Start(AltPath, FName)
                    'myProcess = Process.Start(AltPath, FName, usNm, password, dom)

                Catch
                    myProcess = Process.Start(FName)
                End Try

            Catch Err As Exception

                Dim thisdir As String = CurDir()
                Dim getfile As New OpenFileDialog
                getfile.FileName = "alteros.*"
                getfile.Title = "Please select the Application to view 3D Screen"
                getfile.Filter = "Alteros application(*.exe)|*.exe|VRML files (*.wrl)|*.wrl|All files (*.*)|*.*"

                getfile.ShowDialog()

                IO.Directory.SetCurrentDirectory(thisdir)

                If getfile.FileName.ToLower.Contains("alteros.exe") Then

                    Process.Start(getfile.FileName, FName)

                    NetfileAssociate.Associate_File("wrl", IO.Path.GetFileName(getfile.FileName), "wrl_auto_file", "3D File", IO.Path.GetFileName(getfile.FileName))

                    'Dim regkey As Microsoft.Win32.RegistryKey

                    'regkey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(".wrl")

                    'If regkey Is Nothing Then
                    '    regkey = Microsoft.Win32.Registry.ClassesRoot.CreateSubKey(".wrl")
                    'End If

                    'regkey = regkey.CreateSubKey("OpenWithList")
                    'regkey.CreateSubKey(IO.Path.GetFileName(getfile.FileName))

                Else
                    MsgBox("You have not selected viewer to view 3D Screen")

                    MessageBox.Show("Please install the proper viewer to display the 3D view of generated stuffing plans and then show the stuffing," & vbCrLf & "Right now application is close due to uninstalled the shown stuffing viewer.", " P - Stuff  [Error in show the stuffing plans to viewer] ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    conn.Close()
                    'off.Flush()
                    'off.Close()
                    Application.Exit()
                    Exit Sub
                End If

                conn.Close()
                off.Flush()
                off.Close()
            End Try

            '************************************
        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in Show3DView", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            MessageBox.Show("Please install the proper viewer to display the 3D view of generated stuffing plans and then show the stuffing," & vbCrLf & "Right now application is close due to uninstalled the shown stuffing viewer.", " P - Stuff  [Error in show the stuffing plans to viewer] ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Application.Exit()
        End Try

    End Sub

    Private Sub button3_click(ByRef oform As TransactionMenu, ByRef showemp As Boolean, ByRef ARC As Container_Stuff.Area)

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
        With oform
            totvol = 0
            If stkmm.Count = 0 And Bareaarr.Count = 0 Then
                If Not showemp Then
                    stkmm.Add(.arc)
                Else
                    MsgBox("Container Is Fully Occupied. No Empty Area Left", MsgBoxStyle.Critical + vbOKOnly)
                    Exit Sub
                End If
            End If
            For i As Integer = 0 To stkmm.Count - 1
                ar = stkmm(i)
                If showemp Then
                    ar.AutoDraw(CurDir() & "\First.wrl", "r", 0, "", CStr(i + 1), 0, False, True, "E", 0, False, "b", "1")

                End If
                x = ar.StrtPt.x
                y = ar.StrtPt.y
                z = ar.StrtPt.z
                ln = ar.length
                wd = ar.width
                ht = ar.height
                vol = ln * wd * ht
                totvol = totvol + vol
                .dgEmpty.Rows.Add(CStr(i + 1), CStr(x), CStr(y), CStr(z), CStr(ln), CStr(wd), CStr(ht), vol)
                If .dgEmpty.RowCount = 0 Then
                    MsgBox("All rows deleted")
                End If
            Next

            If Bareaarr.Count > 0 Then
                lst = Bareaarr(0)

                totvol1 = 0
                For i As Integer = 0 To lst.Count - 1 Step 2
                    .dgUsage.Rows.Add(lst(i), lst(i + 1))
                    totvol1 = totvol1 + CDbl(lst(i + 1))
                Next
            End If
            .dgUsage.Rows.Add("Total Occupied", CStr(totvol1))
            .dgUsage.Rows.Add("Empty", CStr(totvol))
        End With

    End Sub

    Sub AutoStuffShow(ByRef oform As TransactionMenu)
        With oform
            'Stop

            FlowDgvChng()
            'Stop

            Try
                .BoxStatusStriplbl.Text = "Stuffing item is progress please wait."
                BitemqtyInr = 1                                 'Incremental count every time initializes

                Dim ans As MsgBoxResult

                rwidx = .dgv1.CurrentCell.RowIndex
                Dim rowno1 As Integer = rwidx
                Dim plclst1 As New List(Of Integer)
                chkwt = True

                If DrBxOpn Then
                    GoTo CDr
                End If

                'Stop
                If .dgv1.CurrentCell.ColumnIndex = 12 Or .dgv1.CurrentCell.ColumnIndex = 13 Or .dgv1.CurrentCell.ColumnIndex = 14 Then
CDr:
                    If .dgv1.Item(1, rowno1).Value Is Nothing _
                OrElse .dgv1.Item(11, rowno1).Value Is Nothing _
                OrElse Not IsNumeric(.dgv1.Item(11, rowno1).Value) _
                OrElse CInt(.dgv1.Item(11, rowno1).Value) <= 0 _
                OrElse .dgv1.Item(11, rowno1).Value.ToString.Contains(".") _
                Then
                        If .dgv1.CurrentCell.ColumnIndex <> 14 Then
                            MsgBox("Cannot show this item." & ControlChars.CrLf & "Item name not selected or quantity is invalid", MsgBoxStyle.Critical + vbOKOnly)
                            Exit Sub
                        End If

                    End If

                    If .dgv1.CurrentCell.ColumnIndex <> 14 Then

                        ans = MsgBoxResult.Yes
                        If ans = MsgBoxResult.Yes Then

                            For i As Integer = 0 To .dgv1.RowCount - 1

                                If .dgv1.Item(1, i).Value Is Nothing _
                                OrElse .dgv1.Item(8, i).Value Is Nothing _
                                OrElse .dgv1.Item(11, i).Value Is Nothing _
                                OrElse Not IsNumeric(.dgv1.Item(8, i).Value) _
                                OrElse Not IsNumeric(.dgv1.Item(11, i).Value) _
                                OrElse CInt(.dgv1.Item(8, i).Value) < 0 _
                                OrElse CInt(.dgv1.Item(11, i).Value) <= 0 _
                                OrElse .dgv1.Item(11, i).Value.ToString.Contains(".") _
                                OrElse .dgv1.Item(11, i).Value.ToString.Contains(".") _
                                Then

                                    Try
                                        .dgv1.Rows.Remove(.dgv1.Rows(i))
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

                    If .CmbContainer.Text = "" Then
                        MsgBox("Container not selected", MsgBoxStyle.Critical + vbOKOnly)
                        .CmbContainer.Focus()
                        Exit Sub
                    End If

                    Bitemno = 0
                    Dim e3 As New e1

                    Dim qtyarr1 As New List(Of e1)
                    qtyarr1.Clear()

                    For i As Integer = 0 To rowno1
                        e3.itmnm = .dgv1.Item(1, i).Value
                        e3.qty = .dgv1.Item(11, i).Value
                        qtyarr1.Add(e3)
                    Next

                    Dim putqty As Integer

                    Dim matchidx As Integer = -1
                    .TxtFreeCbm.Clear()
                    .TxtOccuCbm.Clear()

                    'Stop

                    Dim Rpt As New Region

                    Rpt.RegPt.x = .arc.length
                    Rpt.RegPt.y = .arc.width
                    Rpt.RegPt.z = .arc.height

                    Rpt.length = .arc.length
                    Rpt.width = .arc.width
                    Rpt.height = .arc.height

                    Lbc = Rpt.RegPt.x
                    Wbc = Rpt.RegPt.y
                    Hbc = Rpt.RegPt.z

                    'Stop

                    Rpt.WrVrmlBoxContnrStrt(CurDir() & "\First.wrl", True, Rpt)

                    If matchidx = 0 Then matchidx = -1
                    If matchidx = -1 Then
                        stk.Clear()

                        Dim cmd1 As New OleDb.OleDbCommand
                        cmd1.Connection = conn
                        cmd1.CommandText = "delete from stuffdata"

                        Dim CmdB As New OleDb.OleDbCommand
                        CmdB.Connection = conn
                        CmdB.CommandText = "delete from BoxStuffData"

                        Dim Cmdcg As New OleDb.OleDbCommand
                        Cmdcg.Connection = conn
                        Cmdcg.CommandText = "delete from CGsGen"
x:

                        Try
                            cmd1.ExecuteNonQuery()
                            CmdB.ExecuteNonQuery()
                            Cmdcg.ExecuteNonQuery()
                        Catch ec As Exception
                            If ec.Message = "Cannot open any more tables." Then
                                conn.Close()
                                conn.Dispose()
                                OleDb.OleDbConnection.ReleaseObjectPool()
                                cmd1.Dispose()
                                GC.Collect()

                                conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\container.mdb;Persist Security Info=False"

                                conn.Open()
                                GoTo x
                            End If

                        End Try

                        'Stop

                        Rpt.AutoDrawsRegn(CurDir() & "First.wrl", 1, 0.5, "", "", 0, True, False, "container", 0, True, "b")                                        '.arc.AutoDraws(CurDir() & "First.wrl", 1, 0.5, "", "", 0, True, False, "container", 0, True, "b")

                        'Stop

                        Dim ard As New Area
                        Dim ard1 As New Area

                        Dim RegB As New Region
                        Dim RegB1 As New Region

                        '#######################################
                        'Door 1 option begin 
                        '#######################################

                        If .rdb1D.Checked = True Then

                            ard.StrtPt.x = .arc.length
                            ard.StrtPt.y = 0
                            ard.StrtPt.z = 0
                            ard.length = 0.5
                            ard.width = .arc.width
                            ard.height = .arc.height

                            RegB.StrtPt.x = ard.StrtPt.x
                            RegB.StrtPt.y = ard.StrtPt.y
                            RegB.StrtPt.z = ard.StrtPt.z
                            RegB.length = ard.length
                            RegB.width = ard.width
                            RegB.height = ard.height

                            If DbxFlg Then
                                DbxFlgO = True
                            Else
                                DbxFlgO = False
                            End If

                            Rpt.AutoDrawsRegn(CurDir() & "First.wrl", 1, 0.5, "", "", 0, True, False, "container", 0, True, "b")                '.arc.AutoDraws(CurDir() & "First.wrl", 1, 0.5, "", "", 0, True, False, "container", 0, True, "b")

                            ard1.StrtPt.x = .arc.length - 0.01
                            ard1.StrtPt.y = 0
                            ard1.StrtPt.z = 0
                            ard1.length = 0.5
                            ard1.width = ard.width
                            ard1.height = ard.height

                            RegB1.StrtPt.x = ard1.StrtPt.x
                            RegB1.StrtPt.y = ard1.StrtPt.y
                            RegB1.StrtPt.z = ard1.StrtPt.z
                            RegB1.length = ard1.length
                            RegB1.width = ard1.width
                            RegB1.height = ard1.height

                            If DbxFlg Then
                                DbxFlgO = True
                            Else
                                DbxFlgO = False
                            End If

                            Rpt.AutoDrawsRegn(CurDir() & "First.wrl", 1, 0.5, "", "", 0, True, False, "container", 0, True, "b")            'ard1.AutoDraws(CurDir() & "First.wrl", "b", 0, "file:///c:\contdoor.png", "", 0, True, False, "door1", 0, False, "b")

                            DbxFlgO = False

                        End If

                        '#######################################
                        'Door 1 option End 
                        '#######################################

                        '******************************************************************

                        '#######################################
                        'Door 2 option begin 
                        '#######################################

                        '$$$$$
                        'First half door begin 
                        '$$$$$

                        If .rdb2D.Checked = True Then

                            ard.StrtPt.x = .arc.length
                            ard.StrtPt.y = 0
                            ard.StrtPt.z = 0
                            ard.length = 0.5
                            ard.width = .arc.width * 0.5
                            ard.height = .arc.height

                            RegB.StrtPt.x = ard.StrtPt.x
                            RegB.StrtPt.y = ard.StrtPt.y
                            RegB.StrtPt.z = ard.StrtPt.z
                            RegB.length = ard.length
                            RegB.width = ard.width
                            RegB.height = ard.height

                            If DbxFlg Then
                                DbxFlgO = True
                            Else
                                DbxFlgO = False
                            End If

                            Rpt.AutoDrawsRegn(CurDir() & "First.wrl", 1, 0.5, "", "", 0, True, False, "container", 0, True, "b")                'ard.AutoDrawsBxDrOpn1(CurDir() & "\First.wrl", "", 0, "file:///c:\contdoor.png", "", 0, True, False, "door", 0, False, "b")                                 'ard.AutoDraw(CurDir() & "\Box.wrl", "", 0, "file:///c:\contdoor.png", "", 0, True, False, "door", 0, False, "b")

                            ard1.StrtPt.x = .arc.length - 0.01
                            ard1.StrtPt.y = 0
                            ard1.StrtPt.z = 0
                            ard1.length = 0.5
                            ard1.width = ard.width
                            ard1.height = ard.height

                            RegB1.StrtPt.x = ard1.StrtPt.x
                            RegB1.StrtPt.y = ard1.StrtPt.y
                            RegB1.StrtPt.z = ard1.StrtPt.z
                            RegB1.length = ard1.length
                            RegB1.width = ard1.width
                            RegB1.height = ard1.height

                            If DbxFlg Then
                                DbxFlgO = True
                            Else
                                DbxFlgO = False
                            End If

                            RegB1.AutoDrawsBxDrRegnOpn1(CurDir() & "\First.wrl", "", 0, "file:///c:\contdoor.png", "", 0, True, False, "door", 0, False, "b")           'ard1.AutoDraw(CurDir() & "Box.wrl", "b", 0, "file:///c:\contdoor.png", "", 0, True, False, "door1", 0, False, "b")             'ard.AutoDrawsBxDrOpn1(CurDir() & "\First.wrl", "", 0, "file:///c:\contdoor.png", "", 0, True, False, "door", 0, False, "b")                                 'ard1.AutoDraw(CurDir() & "Box.wrl", "b", 0, "file:///c:\contdoor.png", "", 0, True, False, "door1", 0, False, "b")

                            DbxFlgO = False

                            '$$$$$
                            'First half door end 
                            '$$$$$

                            '################################################################

                            '$$$$$
                            'Second half door begin 
                            '$$$$$

                            ard.StrtPt.x = .arc.length
                            ard.StrtPt.y = 0
                            ard.StrtPt.z = 0
                            ard.length = 0.5
                            ard.width = .arc.width * 0.5
                            ard.height = .arc.height

                            RegB.StrtPt.x = ard.StrtPt.x
                            RegB.StrtPt.y = ard.StrtPt.y
                            RegB.StrtPt.z = ard.StrtPt.z
                            RegB.length = ard.length
                            RegB.width = ard.width
                            RegB.height = ard.height

                            If DbxFlg Then
                                DbxFlgO = True
                            Else
                                DbxFlgO = False
                            End If

                            RegB.AutoDrawsBxDrRegnOpn2(CurDir() & "\First.wrl", "", 0, "file:///c:\contdoor.png", "", 0, True, False, "door", 0, False, "b")                 'ard.AutoDrawsBxDrOpn2(CurDir() & "\First.wrl", "", 0, "file:///c:\contdoor.png", "", 0, True, False, "door", 0, False, "b")

                            ard1.StrtPt.x = .arc.length - 0.01
                            ard1.StrtPt.y = 0
                            ard1.StrtPt.z = 0
                            ard1.length = 0.5
                            ard1.width = ard.width
                            ard1.height = ard.height

                            RegB1.StrtPt.x = ard1.StrtPt.x
                            RegB1.StrtPt.y = ard1.StrtPt.y
                            RegB1.StrtPt.z = ard1.StrtPt.z
                            RegB1.length = ard1.length
                            RegB1.width = ard1.width
                            RegB1.height = ard1.height

                            'Stop

                            If DbxFlg Then
                                DbxFlgO = True
                            Else
                                DbxFlgO = False
                            End If

                            RegB1.AutoDrawsBxDrRegnOpn2(CurDir() & "\First.wrl", "", 0, "file:///c:\contdoor.png", "", 0, True, False, "door", 0, False, "b")         'ard.AutoDrawsBxDrOpn2(CurDir() & "\First.wrl", "", 0, "file:///c:\contdoor.png", "", 0, True, False, "door", 0, False, "b")

                            DbxFlgO = False

                            '$$$$$
                            'First half door end 
                            '$$$$$

                        End If

                        '#######################################
                        'Door 2 option End 
                        '#######################################

                        Bstrtclr = "r"

                    Else

                        putqty = 0

                        For i As Integer = 0 To matchidx - 1
                            putqty += qtyarr1(i).qty
                        Next

                        stk.Clear()

                        If matchidx <> -1 Then

                            For i As Integer = 0 To qtyarr(matchidx - 1).stk.Count - 1
                                stk.Add(qtyarr(matchidx - 1).stk(i))
                            Next

                        End If

                        'Stop

                        Rpt.AutoDrawsRegn(CurDir() & "\First.wrl", 1, 0.5, "", "", 0, True, False, "container", 0, True, "b")           '.arc.AutoDraws(CurDir() & "\First.wrl", 1, 0.5, "", "", 0, True, False, "container", 0, True, "b")

                        Dim ard As New Area
                        Dim RegB As New Region

                        ard.StrtPt.x = .arc.length
                        ard.StrtPt.y = 0
                        ard.StrtPt.z = 0
                        ard.length = 0.5
                        ard.width = .arc.width
                        ard.height = .arc.height

                        RegB.StrtPt.x = ard.StrtPt.x
                        RegB.StrtPt.y = ard.StrtPt.y
                        RegB.StrtPt.z = ard.StrtPt.z
                        RegB.length = ard.length
                        RegB.width = ard.width
                        RegB.height = ard.height

                        'Stop

                        Rpt.AutoDrawsRegn(CurDir() & "\First.wrl", "", 0, "file:///c:\contdoor.png", "", 0, True, False, "door", 0, False, "b")         'ard.AutoDraws(CurDir() & "\First.wrl", "", 0, "file:///c:\contdoor.png", "", 0, True, False, "door", 0, False, "b")

                        Dim ard1 As New Area

                        Dim RegB1 As New Region

                        ard1.StrtPt.x = .arc.length - 0.01
                        ard1.StrtPt.y = 0
                        ard1.StrtPt.z = 0
                        ard1.length = 0.5
                        ard1.width = ard.width
                        ard1.height = ard.height

                        RegB1.StrtPt.x = ard1.StrtPt.x
                        RegB1.StrtPt.y = ard1.StrtPt.y
                        RegB1.StrtPt.z = ard1.StrtPt.z
                        RegB1.length = ard1.length
                        RegB1.width = ard1.width
                        RegB1.height = ard1.height

                        Stop

                        Rpt.AutoDrawsRegn(CurDir() & "First.wrl", "b", 0, "file:///c:\contdoor.png", "", 0, True, False, "door1", 0, False, "b")       'ard1.AutoDraws(CurDir() & "First.wrl", "b", 0, "file:///c:\contdoor.png", "", 0, True, False, "door1", 0, False, "b")

                        Dim col1 As String = "r"
                        Bplclst.Clear()
                        Bqtylst.Clear()
                        Dim qtyx As Integer = 0
                        qtyarr.Clear()
                        Dim ahistarr1 As New List(Of r1)

                        ahistarr1.Clear()

                        .btnStatus.Visible = False
                        .lblStatus.Visible = True
                        .lblStatusINm.Visible = True

                        .pbCSP1.Visible = True
                        ProgressBarRunning()

                        .lblStatus.Text = "Please wait ....."

                        If .dgv1.CurrentCell.ColumnIndex = 12 Then
                            .showemp = False
                        ElseIf .dgv1.CurrentCell.ColumnIndex = 13 Then
                            .showemp = True
                        End If

                        If stk.Count = 0 Then

                            If .showemp Then
                                MsgBox("Container Is Fully Occupied. No Empty Area Left", MsgBoxStyle.Critical + vbOKOnly)
                                Exit Sub
                            End If

                        End If

                        Dim ar11 As New Area
                        Dim Reg11 As New Region

                        For i As Integer = 0 To stk.Count - 1

                            ar11 = stk(i)
                            If .showemp Then

                                Stop

                                Reg11.AutoDraws(CurDir() & "First.wrl", "r", 0, "", CStr(i + 1), 0, False, True, "E", 0, False, "b")             'ar11.AutoDraws(CurDir() & "First.wrl", "r", 0, "", CStr(i + 1), 0, False, True, "E", 0, False, "b")

                            End If

                        Next

                        If .showemp Then

                            Try
                                Closef(CurDir() & "\First.wrl")
                                'Form8.Close()

                                .lblStatus.Visible = False
                                .lblStatusINm.Visible = False
                                .btnStatus.Visible = False

                                .pbCSP1.Visible = False

                                Eventless()

                                '#################@@@@@@@@@@@@@@@@@@@@@@@@@@

                                'ThreeDViewer()
                                '#################@@@@@@@@@@@@@@@@@@@@@@@@@@
                                'Dim RsultStr As String

                                '##############

                                Try

                                    Dim FName As String = CurDir() & "\First.wrl"
                                    Process.Start("c:\Program Files\Alteros 3D\alteros.exe", FName)

                                Catch Err As Exception
                                    MsgBox(Err.Message)
                                    MsgBox(Err.ToString)
                                    MessageBox.Show("Error in Alteros 3D running", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    conn.Close()
                                    off.Close()
                                    MessageBox.Show("Fatal error in ShowButton", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    MsgBox("Exit Application")
                                    Application.Exit()
                                End Try

                                '#################@@@@@@@@@@@@@@@@@@@@@@@@@@
                                'RsultStr = MsgBox("Do you show stuffing in three dimensional (Isometric) view ?", MsgBoxStyle.YesNo, "3DViewer")
                                'If RsultStr = MsgBoxResult.Yes Then
                                '    ThreeDViewer() ' (3D)Three Dimentional Arrangement are shown 
                                'Else
                                '    Dim Str As String
                                '    Str = MsgBox("Do you close stuffing entry?", MsgBoxStyle.YesNo, "Stuffing Entry ...")
                                '    If Str = MsgBoxResult.Yes Then
                                '        Me.Close()
                                '    Else
                                '        Me.Focus()
                                '    End If
                                'End If
                                'ThreeDViewer() ' (3D)Three Dimentional Arrangement are shown 
                                '#################@@@@@@@@@@@@@@@@@@@@@@@@@@

                            Catch Ex As Exception
                                conn.Close()
                                Iow.Close()
                                MsgBox(Ex.Message)
                                MsgBox(Ex.ToString)
                                MessageBox.Show("Error in ShowButton", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                MsgBox("Exit Application")
                                Application.Exit()
                            Finally
                                .lblStatus.Visible = False
                                .lblStatusINm.Visible = False
                                .btnStatus.Visible = False
                                .pbCSP1.Visible = False
                                Eventless()
                            End Try
                            Exit Sub
                        End If

                        Bitemno = 0

                        For i As Integer = 0 To putqty - 1
                            qtyx += 1
                            Bahistarr(i).ar.AutoDraws(CurDir() & "First.wrl", col1, 0, "file\\\c:\t2.png", Bahistarr(i).itmnm, 0, False, True, "", Bahistarr(i).method, False, "b")

                            ahistarr1.Add(Bahistarr(i))
                            If i = putqty - 1 Then
                                plclst1.Add(qtyx)

                                Bqtylst.Add(qtyx)

                                Dim m1 As New e1
                                m1.itmnm = Bahistarr(i).itmnm
                                m1.qty = qtyx
                                m1.stk = Bahistarr(i).stk
                                qtyarr.Add(m1)

                                qtyx = 0
                                Exit For

                            End If

                            If Bahistarr(i).itmnm <> Bahistarr(i + 1).itmnm Then

                                Bitemno += 1
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
                                plclst1.Add(qtyx)
                                Bqtylst.Add(qtyx)

                                Dim m1 As New e1
                                m1.itmnm = Bahistarr(i).itmnm
                                m1.qty = qtyx
                                m1.stk = Bahistarr(i).stk
                                qtyarr.Add(m1)
                                qtyx = 0

                            End If

                        Next

                        Bitemno += 1

                        .lblStatus.Visible = False
                        .lblStatusINm.Visible = False
                        .btnStatus.Visible = False

                        .pbCSP1.Visible = False

                        Eventless()

                        Bahistarr.Clear()
                        For i As Integer = 0 To ahistarr1.Count - 1
                            Bahistarr.Add(ahistarr1(i))
                        Next

                        Bplclst.Clear()
                        For i As Integer = 0 To Bqtylst.Count - 1
                            Bplclst.Add(Bqtylst(i) - 1)
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
                        Bstrtclr = col1

                    End If

                    If DrBxOpn Then
                        Exit Sub
                    End If

                    '*************
                    'Stop

                    'Iow.Close()

                    '*************************************************************************
                    'Container Writing Program  is finished here
                    '*************************************************************************

                    '*************

                    Dim CBLst1 As New List(Of Region)           'Dim Stk1 As New List(Of Area)
                    Dim CBLst2 As New List(Of Region)           'Dim Stk2 As New List(Of Area)

                    Dim qtyf As Boolean = False
                    Dim rowlvflg As Boolean = False
                    Dim Stp As Integer
                    Dim cntm As Integer = 1
                    Dim totqty = 25
                    Dim totqty1 As Integer = 0
                    'Dim drwstp As Integer

                    Dim cntflg As Boolean = False

                    Dim flg1 As Boolean = True

                    Dim button1flag As Boolean = False
                    Dim Itmnm As String
                    Dim SLbl As String

                    button1flag = True
                    Dim Cnt As Integer = 0
                    Dim dupflg As Boolean = False

                    Cnt = 0

                    Dim ar() As Area
                    Dim RegAr() As Region

                    Dim ari() As String
                    Dim arwt() As Single
                    Dim ar1 As New Area
                    Dim RegAr1 As New Region

                    Dim ln As Double
                    Dim wd As Double
                    Dim ht As Double
                    Dim qty As Integer
                    Dim seq As Integer
                    Dim wt As String
                    Dim transparr() As Boolean
                    Dim transp As Boolean
                    Dim topup() As Boolean
                    Dim Tpup As Boolean

                    ReDim ar(0)
                    ReDim RegAr(0)
                    ReDim ari(0)
                    ReDim arwt(0)
                    ReDim transparr(0)
                    ReDim topup(0)
                    ReDim arl(0)

                    Dim cmd As New OleDb.OleDbCommand
                    Dim cntx As Integer = 0
                    Dim plcqty As Integer = 0
                    Dim k As Integer
                    Dim m As Integer

                    TabXmlDel("temp1")

                    If .CmbContainer.Text = "" Then
                        MsgBox("Container not selected", MsgBoxStyle.Critical + vbOKOnly)
                        MessageBox.Show("Container not selected", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        .CmbContainer.Focus()
                        Exit Sub
                    End If

                    .btnStatus.Visible = False

                    .lblStatus.Text = "Please wait ....."
                    .lblStatus.Visible = True
                    .lblStatusINm.Visible = True
                    .btnStatus.Visible = False

                    .pbCSP1.Visible = True
                    ProgressBarRunning()

                    System.Windows.Forms.Application.DoEvents()

                    'Stop

                    Dim i1, j1 As Integer
                    Dim extflg As Boolean = False
                    Dim zz As Integer

                    zz = rowno1

                    Dim matchidx1 As Integer
                    If matchidx = -1 Then
                        matchidx1 = 0
                    Else
                        matchidx1 = matchidx
                    End If

                    Try
                        For i1 = matchidx1 To zz

                            Itmnm = .dgv1.Item(1, i1).Value
                            ln = Math.Round(.dgv1.Item(4, i1).Value, 4)
                            wd = Math.Round(.dgv1.Item(5, i1).Value, 4)
                            ht = Math.Round(.dgv1.Item(6, i1).Value, 4)
                            qty = .dgv1.Item(11, i1).Value

                            wt = .dgv1.Item(8, i1).Value
                            seq = .dgv1.Item(0, i1).Value
                            SLbl = .dgv1.Item(15, i1).Value

                            If SLbl = Nothing Then
                                SLbl = Itmnm
                            End If

                            transp = False

                            Tpup = IIf(.dgv1.Item(7, i1).Value = "6", False, True)

                            Bqtylst.Add(qty)

                            'Stop

                            For j1 = 0 To qty - 1

                                totqty1 += 1
                                qtyf = True
                                RegAr1.length = ln
                                RegAr1.width = wd
                                RegAr1.height = ht
                                RegAr1.StrtPt.x = 0
                                RegAr1.StrtPt.y = 0
                                RegAr1.StrtPt.z = 0
                                RegAr(UBound(RegAr)) = New Region
                                RegAr(UBound(RegAr)).length = RegAr1.length
                                RegAr(UBound(RegAr)).width = RegAr1.width
                                RegAr(UBound(RegAr)).height = RegAr1.height
                                ari(UBound(ari)) = Itmnm
                                arwt(UBound(arwt)) = wt
                                transparr(UBound(transparr)) = transp
                                topup(UBound(topup)) = Tpup
                                arl(UBound(arl)) = SLbl

                                ReDim Preserve RegAr(UBound(RegAr) + 1)
                                ReDim Preserve ari(UBound(ari) + 1)
                                ReDim Preserve arwt(UBound(arwt) + 1)
                                ReDim Preserve transparr(UBound(transparr) + 1)
                                ReDim Preserve topup(UBound(topup) + 1)
                                ReDim Preserve arl(UBound(arl) + 1)

                            Next

                        Next i1

                        'Stop

                    Catch Err As Exception
                        MsgBox(Err.Message)
                        MsgBox(Err.ToString)
                        MessageBox.Show("Error in Datagrid entry looping entry to stuffing assigning in AutoStuffShow", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try

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
                        plcqty = plcqty + Bplclstf(i) - 1
                    Next

                    ReDim Preserve RegAr(UBound(RegAr) - 1)
                    ReDim Preserve ari(UBound(ari) - 1)
                    ReDim Preserve arwt(UBound(arwt) - 1)
                    ReDim Preserve transparr(UBound(transparr) - 1)
                    ReDim Preserve topup(UBound(topup) - 1)
                    ReDim Preserve arl(UBound(arl) - 1)

                    Stp += 1

                    Dim RegAr2() As Region           'Dim ar2() As Area
                    Dim Ari2() As String             'Dim ari2() As String
                    Dim ArWt2() As Single
                    Dim TranspArr2() As Boolean

                    ReDim RegAr2(0)                      'ReDim ar2(0)
                    ReDim Ari2(0)                        'ReDim ari2(0)
                    ReDim ArWt2(0)                       'ReDim arwt2(0)
                    ReDim TranspArr2(0)

                    '*************
                    'Stop
                    '*************

                    For i As Integer = LBound(RegAr) To UBound(RegAr)       'For i As Integer = LBound(ar) To UBound(ar)

                        RegAr2(UBound(RegAr2)) = RegAr(i)                    'ar2(UBound(ar2)) = ar(i)
                        Ari2(UBound(Ari2)) = ari(i)
                        ArWt2(UBound(ArWt2)) = arwt(i)
                        TranspArr2(UBound(TranspArr2)) = transparr(i)
                        ReDim Preserve RegAr2(UBound(RegAr2) + 1)
                        ReDim Preserve Ari2(UBound(Ari2) + 1)
                        ReDim Preserve ArWt2(UBound(ArWt2) + 1)
                        ReDim Preserve TranspArr2(UBound(TranspArr2) + 1)
                        ReDim Preserve topup(UBound(topup) + 1)

                    Next

                    ReDim Preserve RegAr2(UBound(RegAr2))                   'ReDim Preserve ar2(UBound(ar2) - 1)
                    ReDim Preserve Ari2(UBound(Ari2) - 1)
                    ReDim Preserve ArWt2(UBound(ArWt2) - 1)
                    ReDim Preserve TranspArr2(UBound(TranspArr2) - 1)

                    Try
                        ReDim Preserve topup(UBound(topup) - 1)
                    Catch

                    End Try

                    '*************
                    'Stop
                    '*************

                    If Stp = .dgv1.RowCount Then
                        Stp = 0
                        Cnt = 0
                    End If

                    .RegArc.StrtPt.x = 0              '.arc.StrtPt.x = 0
                    .RegArc.StrtPt.y = 0              '.arc.StrtPt.y = 0
                    .RegArc.StrtPt.y = 0              '.arc.StrtPt.z = 0
                    .RegArc.length = .contarr(0)       '.arc.length = contarr(0)
                    .RegArc.width = .contarr(1)        '.arc.width = contarr(1)
                    .RegArc.height = .contarr(2)       '.arc.height = contarr(2)
                    qty = 0

                    .lblStatus.Visible = False
                    .lblStatusINm.Visible = False
                    .btnStatus.Visible = False

                    .pbCSP1.Visible = False

                    Eventless()

                    Dim FileOut As String = CurDir() & "\First.wrl"

                    If RegAr.Length > 0 Then

                        If CBLst.Count = 0 Then CBLst.Add(.RegArc)
                        Bitemqty = 0
                        Bplclst.Clear()
                        Btxtopt = False

                        'Stop

                        If .dgv1.CurrentCell.ColumnIndex = 12 Then

                            If .chkBxAutoStuff.Checked Then

                                'Stop

                                FlowStuffOptm(.RegArc, RegAr, Ari2, ArWt2, False, False, FileOut, True, TranspArr2, topup, Btxtopt, True, False, True, .colarr)

                            End If

                        End If

                        'BoxStuff(.regarc, RegAr, Ari2, ArWt2, False, False, FileOut, True, TranspArr2, topup, Btxtopt, True, False, True, colarr)
                        'BoxStuff(.arc, ar2, Ari2, ArWt2, False, False, outfile, True, TranspArr2, topup, Btxtopt, True, False, True, colarr)

                    End If

                End If

            Catch Err As Exception
                MsgBox(Err.Message)
                MsgBox(Err.ToString)
                MessageBox.Show("Error in AutoStuffShow", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
                conn.Close()
                off.Close()
                MessageBox.Show("Fatal error in AutoShowButton", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
                MsgBox("Exit Application")
                Application.Exit()
            End Try
        End With
    End Sub

    Public Sub deleteTablexml(ByVal tbName As String)

        Dim dT As New System.Data.DataTable
        Dim xD As New System.Xml.XmlDataDocument

        xD.DataSet.ReadXml(CurDir() & "/" & tbName & ".xml")
        dT = xD.DataSet.Tables(0)

        Do While dT.Rows.Count > 1
            dT.Rows(dT.Rows.Count - 1).BeginEdit()
            dT.Rows(dT.Rows.Count - 1).Delete()
            dT.AcceptChanges()
        Loop

        xD.Save(CurDir() & "/" & tbName & ".xml")

    End Sub

    Public Sub InsertTablexml(ByVal tbName As String, ByVal Vals() As Object)

        Dim dT As New System.Data.DataTable
        Dim xD As New System.Xml.XmlDataDocument

        xD.DataSet.ReadXml(CurDir() & "/" & tbName & ".xml")
        dT = xD.DataSet.Tables(0)
        dT.Rows.Add(Vals)

        xD.Save(CurDir() & "/" & tbName & ".xml")

    End Sub

    Public Function ReadRowxml(ByVal tbName As String, ByVal fltr As String, ByVal srtcol As String) As DataRow()

        Dim dT As New System.Data.DataTable
        Dim dR() As DataRow = Nothing
        Dim xD As New System.Xml.XmlDataDocument
        Dim xRdr As System.Xml.XmlReader

        Try
            xRdr = Xml.XmlReader.Create(CurDir() & "/" & tbName & ".xml")
            xRdr.Settings.Schemas.Add(vbNull, CurDir() & "/" & tbName & ".xsd")
            xD.DataSet.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema
            xD.DataSet.ReadXml(xRdr, XmlReadMode.InferTypedSchema)
            dR = xD.DataSet.Tables(0).Select(fltr, srtcol)
            xRdr.Close()
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in ReadRowxml", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return dR

    End Function

End Module
