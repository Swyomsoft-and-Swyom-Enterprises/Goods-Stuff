
'Program Name: -   GenRoutines.vb
'Programmer Name: - Satwadhir B. Pawar Mob No. :- 9323974665
'Company Name:-     Hazel Infotech LTD. Mumbai
'Project Name: -    Sky Stuff Plus (Container Stuffing)
'Date: -            23 Dec 2K8 11.30 AM (Modified Time)

'Tips: - The code is debugging at that particular dimensions, quantity and sequence.
'        you are decide it the logic happen is correct to that way or its are some 
'        different way the understanding to at your best level is the correct logic 
'        of this particular code block.

'Description: - GenRoutines is the general routine module in box geometry stuffing module 
'               which is the various routines and functions to finalize the output of VRML 
'               program of 3D geometry to write in First.wrl file to display the output. 

#Region " Importing Object "

Imports CSPEncriptWr
Imports DrmFindQty
Imports OptMthd
#End Region

Module genroutines

#Region " Moudule Declaration "

    Public off As IO.StreamWriter 'Public off As New IO.StreamWriter(CurDir() & "\first.wrl")
    Public offs As IO.StreamWriter

    'Public EDWr As Parag = New Parag()  'CSPEncryptWr.dll Usage :: Encrypt, Decrypt the program file and write files
    Friend EDWr As Parag = New Parag()  'CSPEncryptWr.dll Usage :: Encrypt, Decrypt the program file and write files

    Public mQty As DrumQty = New DrumQty    'DcalcQty.dll Usage :: Finding maximum quantity of drum or boxes 

    Public exflg As Boolean
    Public xcnt As Integer
    Public xcnt1 As Integer
    Public stksav As New List(Of List(Of Area))
    Dim Occ As Integer
    Dim OccLst As New List(Of Integer)
    Dim OptLst As New List(Of occ1)
    Public Bstrtclr As String
    Public Bahistarr As New List(Of r1)
    Public BHistArr As New List(Of R1Wad)
    Public plclst As New List(Of Integer)
    Public StopFlg As Boolean = False           'Stop Button stop flag is declared

    Public qtylst As New List(Of Integer)
    Public areaarr As New List(Of List(Of String))
    Public totwt As Single
    Public strtclr As String
    Public maxqtylst As New List(Of Integer)
    Public ahistarr As New List(Of r1)

    Public txtopt As Boolean = True

    Public n As Single
    Public RE2 As New RE1
    Public e2 As New e1
    Public E2Wad As New E1Wad
    Friend QtyArrflw As New List(Of RE1)
    Friend qtyarr As New List(Of e1)
    Public QtyArrWad As New List(Of E1Wad)
    Public configid As String
    Public itemn As String
    Public itemn1 As String
    Public xid As Integer

    Public id1 As Integer
    Public stpBox As Integer = 1

    Public Bareaarr As New List(Of List(Of String))
    Public units As String = "i"
    Friend BoxFileOP As String = Nothing         'The box file path saved.

    Public Btxtopt As Boolean = True

    Public WithEvents vv As DataGridViewCheckBoxColumn
    Public Bitemqty As Integer                          'Auto generated quantity
    Public BxItmQty As Int64 = 0                         'Maximum Quantity Calculated
    Public BitemqtyInr As Int64 = 1                         'Incremented quantity

    Public BitemqtyUsr As Integer                       'user changing starting point

    Public PosChngFlg As Boolean = False                         'User position chane in goods

    Public itemno As Integer
    Public stp As Integer = 1
    Public itemqty As Integer

    Public stk As New List(Of Area)
    Public CBLst As New List(Of Region)

    Public stkn As New List(Of Area)
    Public seqopt As Integer
    Public Bqtylst As New List(Of Integer)
    Public Bplclst As New List(Of Integer)
    Public Bplclstf As New List(Of Integer)
    Public fullflag As Boolean = False
    Public contcap As Single
    Public Btotwt As Single
    Public Bitemno As Integer
    Public chkwt As Boolean
    Public Bmaxqtylst As New List(Of Integer)
    Public Bclsflg As Boolean
    'Dim totqty As Integer

    Public stkl As New Stack(Of a1)

    Dim arc As New Area

    Dim stkn1 As Stack(Of Integer)

    Public Bcol As String                   'Color of box items

    Public StpMthd As Integer = 1            'The step show in method change
    Public stpFlg As Boolean = False         'The step show first time is not shown the view flag

    Public MetUnFlg As Boolean = False          'The metric units change flag
    Public EngUnFlg As Boolean = False           'The english units change flag

    Public StepCount As Integer = 1             'The Step Trials Counts Value

    Public setLinkFlg As Boolean = False

#End Region

#Region " Function Definition "

    Public Function BoxStuff_Optm(ByVal arc As Area, ByVal ar() As Area, ByVal ari() As String, ByVal arwt() As Single, ByVal saveopt As Boolean, ByVal showempty As Boolean, ByVal outfile As String, ByVal drawarc As Boolean, ByVal transparr() As Boolean, ByVal topup() As Boolean, ByVal txtopt As Boolean, ByVal drawopt As Boolean, ByVal findqtyflg As Boolean, ByVal chngflg As Boolean, ByVal colarr As List(Of List(Of Byte))) As List(Of Area)

        MessageBox.Show("Optimum stuffing shown here", "Optimum stuff info.....", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Return Nothing

    End Function

    Public Function MoveBoxStuff(ByVal arc As Area, ByVal ar() As Area, ByVal ari() As String, ByVal arwt() As Single, ByVal saveopt As Boolean, ByVal showempty As Boolean, ByVal outfile As String, ByVal drawarc As Boolean, ByVal transparr() As Boolean, ByVal topup() As Boolean, ByVal txtopt As Boolean, ByVal drawopt As Boolean, ByVal findqtyflg As Boolean, ByVal chngflg As Boolean, ByVal colarr As List(Of List(Of Byte))) As List(Of Area)

        'Stop

        Dim stk2 As New List(Of Area)
        Dim stk1 As New Stack(Of Area)
        Dim art As New Area
        Dim arp As New Area
        Dim are As New Area
        Dim aru As New Area
        Dim arb As New Area
        Dim q As New Queue(Of Area)
        Dim q1 As New Queue(Of Area)
        Dim q2 As New Queue(Of Area)

        Dim ans1 As Boolean
        Dim szchg As Integer = 0
        Dim cmd As New OleDb.OleDbCommand

        Dim qtyflg As Boolean = True
        Dim traval As Single
        Dim ard As New Area
        Dim arm As New List(Of Integer)
        Dim arm1 As Integer
        Dim lstm As New List(Of Area)
        Dim a1 As New Area
        Dim a2 As New Area
        Dim ordr As Integer
        Dim totar As Double
        Dim tmplst As New List(Of String)
        Dim answ As MsgBoxResult

        Dim olditemqty As Integer = 0
        Dim col As String
        Dim ii As Integer

        Dim stkj As New List(Of Area)

        Try
            If saveopt Then

                configid = InputBox("Enter Config Id")

            End If

            Dim ptx As New Point

            ptx.x = arc.length
            ptx.y = arc.width
            ptx.z = arc.height

            Dim col1 As New List(Of Byte)

            col1.Clear()
            col1.Add(255)
            col1.Add(255)
            col1.Add(255)
            col = "1"

            Dim itmnm As String = ""

            If drawarc Then
                Dim ard1 As New Area
                If drawarc Then

                End If
                ard.StrtPt.x = arc.length
                ard.StrtPt.y = 0
                ard.StrtPt.z = 0
                ard.length = 0.5
                ard.width = arc.width
                ard.height = arc.height

                If drawopt Or drawarc Then

                End If

                ard1.StrtPt.x = arc.length - 0.01
                ard1.StrtPt.y = 0
                ard1.StrtPt.z = 0
                ard1.length = 0.5
                ard1.width = ard.width
                ard1.height = ard.height

                If drawopt Or drawarc Then

                    col1.Clear()

                End If

            End If

            If saveopt Then

                cmd.Connection = conn
y:
                Try
                    cmd.ExecuteNonQuery()
                Catch ec As Exception

                    If ec.Message = "Cannot open any more tables." Then
                        conn.Close()
                        conn.Dispose()
                        OleDb.OleDbConnection.ReleaseObjectPool()
                        cmd.Dispose()
                        GC.Collect()

                        conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\container.mdb;Persist Security Info=False"

                        conn.Open()
                        GoTo y
                    End If

                End Try
                id1 += 1
            End If

            arc.StrtPt.x = 0
            arc.StrtPt.y = 0
            arc.StrtPt.z = 0

            Dim j As Integer = 0
            totar = 0
            Bareaarr.Clear()

            For i As Integer = 0 To stk.Count - 1
                stk2.Add(stk(i))
            Next

            Bitemqty = 0
            Btotwt = 0

            'Stop

            If Not IsNothing(ari) Then

                'Form8.Show()
                TransactionMenu.lblStatus.Visible = True
                TransactionMenu.lblStatusINm.Visible = True
                TransactionMenu.btnStatus.Visible = True

                '@
                TransactionMenu.btnPause.Visible = True
                TransactionMenu.mtxtbxPause.Visible = True
                TransactionMenu.lblSec.Visible = True

                TransactionMenu.pbCSP1.Visible = True
                ProgressBarRunning()

                If drawopt Then

                    'Form8.Button1.Visible = False
                    TransactionMenu.btnStatus.Visible = True

                    '@
                    TransactionMenu.btnPause.Visible = True
                    TransactionMenu.mtxtbxPause.Visible = True
                    TransactionMenu.lblSec.Visible = True

                End If

                'Form8.Focus()
                TransactionMenu.lblStatus.Focus()
            End If

            For i As Integer = 0 To Bqtylst.Count - 1
                Bplclst.Add(Bqtylst(i) - 1)
            Next

            'Stop

            Try
                If conn.State = ConnectionState.Closed Then conn.Open()

                Dim Cmdm As New OleDb.OleDbCommand
                Cmd.Connection = conn
                cmd.CommandText = "delete from pgCord"
                Cmd.ExecuteNonQuery()

            Catch ex As Exception
                MsgBox(ex.Message)
                MsgBox(ex.ToString)
                MessageBox.Show("Error in Delete in pgCord", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            fullflag = False
            olditemqty = 0
            Dim imgname As String = "1"

            Do While Not stk.Count = 0 And j <= UBound(ar)      'Loop to write automatic stuffing

                'Stop

                Dim Count As Int16 = j

                'Stop

                If j > 0 Then
                    If ari(j) <> ari(j - 1) Then
                        imgname = (CInt(imgname) + 1).ToString
                    End If
                End If

                ordr = 0

                If chkwt Then

                    Btotwt += arwt(j)

                    If Btotwt >= contcap Then

                        answ = MsgBox("Maximum weight capacity of the container is reached" & vbCrLf & "Do you want to proceed?", MsgBoxStyle.YesNo)
                        If answ = MsgBoxResult.No Then
                            fullflag = True
                            Exit Do

                        Else
                            fullflag = False
                            chkwt = False
                        End If

                    End If
                End If

                If j = 0 Then

                    col = Bstrtclr

                End If

                If j > 0 And Not IsNothing(ari) Then

                    If ari(j - 1) <> ari(j) Then

                        e2 = New e1
                        e2.qty = Bitemqty
                        e2.itmnm = ari(j - 1)
                        stkj = New List(Of Area)

                        For jj As Integer = 0 To stk.Count - 1
                            stkj.Add(stk(jj))
                        Next

                        e2.stk = stkj

                        If drawopt Then
                            qtyarr.Add(e2)
                        End If

                        If Bqtylst.Count > 0 Then

                        End If

                        Bmaxqtylst.Add(Bitemqty)

                        'Form8.Label1.Text = "Stuffing item:" & ari(j)
                        'Form8.Label1.Refresh()

                        TransactionMenu.lblStatusINm.Text = "Stuffing item : " & ari(j)
                        TransactionMenu.lblStatusINm.Refresh()
                    Else
                        'Form8.Label1.Text = "Stuffing item:" & ari(j)
                        'Form8.Label1.Refresh()

                        TransactionMenu.lblStatusINm.Text = "Stuffing item : " & ari(j)
                        TransactionMenu.lblStatusINm.Refresh()
                    End If

                Else
                    If j > 0 Then
                        'Form8.Show()
                        TransactionMenu.lblStatus.Visible = True
                        TransactionMenu.lblStatusINm.Visible = True
                        TransactionMenu.btnStatus.Visible = True

                        '@
                        TransactionMenu.btnPause.Visible = True
                        TransactionMenu.mtxtbxPause.Visible = True
                        TransactionMenu.lblSec.Visible = True

                        TransactionMenu.pbCSP1.Visible = True
                        ProgressBarRunning()

                        If drawopt Then
                            'Form8.Button1.Visible = False
                            TransactionMenu.btnStatus.Visible = False

                            '@
                            TransactionMenu.btnPause.Visible = False
                            TransactionMenu.lblSec.Visible = False
                            TransactionMenu.mtxtbxPause.Visible = False

                        End If

                        'Form8.Label1.Text = "Finding Maximum Quantity ....."
                        'Form8.Label1.Refresh()

                        TransactionMenu.lblStatus.Text = "Finding Maximum Quantity ....."
                        TransactionMenu.lblStatus.Refresh()

                    End If
                End If

                'Stop

                If drawopt Then

                    If j > 0 Then

                        If ari(j - 1) <> ari(j) Then

                            Bitemqty = 0

                            If col = "r" Then
                                col = "g"
                            ElseIf col = "g" Then
                                col = "b"
                            ElseIf col = "b" Then
                                col = "m"
                            ElseIf col = "m" Then
                                col = "c"
                            ElseIf col = "c" Then
                                col = "y"
                            End If

                            szchg += 1
                            qtyflg = True

                        Else
                            qtyflg = False
                        End If
                    End If
                End If

                If szchg <> 2 Then

                Else

                End If

                'Dim Qw As Area

                'Dim W As List(Of Area) = stk
                'Qw = W(j)
                'Qw = stk(j)


                'Stop

                stk = VertexReturn(stk, ar(j), topup(j))

                
                arm1 = findopt(stk, ar(j), topup(j))

                'Stop

                art = Nothing

                If arm1 <> -1 Then
                    art = stk(arm1)
                End If

                Dim arn As New List(Of Integer)
                Dim lstn As New List(Of Area)
                Dim b1 As New Area
                Dim b2 As New Area
                Dim pos1 As Integer
                arm = Nothing
                arn = Nothing

                'Stop

                arn = findcandidate1(stk, ar(j), topup(j))

                'Stop

                pos1 = 0

                If Not arn Is Nothing Then

                    pos1 = 0

                Else

                    Dim arxx As New Area

                    arxx.length = ar(j).width
                    arxx.width = ar(j).length
                    arxx.height = ar(j).height

                    arn = findcandidate1(stk, arxx, topup(j))

                    'Stop

                    If Not arn Is Nothing Then
                        pos1 = 1
                    Else
                        If Not topup(j) Then

                            arxx.length = ar(j).length
                            arxx.width = ar(j).height
                            arxx.height = ar(j).width

                            arn = findcandidate1(stk, arxx, False)

                            'Stop

                            If Not arn Is Nothing Then
                                pos1 = 2
                            End If
                        End If
                    End If
                End If

                'Stop

                If arn Is Nothing Then

                    'Stop

                    arm = findcandidate_Move(stk, ar(j))
                    'arm = findcandidate1x(stk, ar(j))
                    'arm = Action_Candidate(stk, ar(j))

                    'Stop

                    If Not arm Is Nothing Then
                        If arm(0) = arm1 Then arm = Nothing
                    End If
                End If

                'If Not arm Is Nothing Then
                '    'Stop
                '    lstm = unionp(stk(arm(0)), stk(arm(1)))

                '    'Stop
                '    a1 = lstm(0)
                '    a2 = lstm(1)
                'End If

                'If Not arn Is Nothing Then
                '    'Stop
                '    lstm = unionp(stk(arn(0)), stk(arn(1)))
                '    'Stop
                '    b1 = lstm(0)
                '    b2 = lstm(1)
                'End If

                If arm Is Nothing And arm1 = -1 Then
                    If drawopt Then

                    End If

                    For m As Integer = j To UBound(ari) - 1
                        If ari(m) <> ari(j) Then
                            j = m

                            GoTo lp

                        End If
                    Next
                    j = UBound(ari) + 1

                    GoTo lp

                Else
                    If arn Is Nothing And arm1 = -1 Then
                        If drawopt Then

                        End If

                        For m As Integer = j To UBound(ari) - 1
                            If ari(m) <> ari(j) Then
                                j = m
                                GoTo lp

                            End If
                        Next
                        j = UBound(ari)

                    End If
                End If

                'Stop

                If Not arm Is Nothing Or Not arn Is Nothing Then

                    cmd.Connection = conn

                    DelTab("temp2")
z:

                    ordr = 0
                    If Not arm Is Nothing Then

                        instab("temp2", New Object() {CStr(a1.StrtPt.x), CStr(a1.StrtPt.y), CStr(a1.StrtPt.z), CStr(1)})
                    End If

                    If Not arn Is Nothing Then
                        instab("temp2", New Object() {CStr(b1.StrtPt.x), CStr(b1.StrtPt.y), CStr(b1.StrtPt.z), CStr(2)})

                    End If

                    If Not art Is Nothing Then
                        instab("temp2", New Object() {CStr(art.StrtPt.x), CStr(art.StrtPt.y), CStr(art.StrtPt.z), CStr(3)})

                    End If

                    'Stop

                    Dim rwx As DataRow() = Nothing

                    Try
                        If Not arm Is Nothing Then

                            rwx = getf("temp2", "", "z DESC ,x ASC,y ASC")
                        End If

                        If Not arn Is Nothing Then

                            rwx = getf("temp2", "", "z DESC ,x ASC,y ASC")
                        End If

                        If arn Is Nothing And arm Is Nothing Then

                            rwx = getf("temp2", "", "z DESC ,x ASC")
                        End If

                        If arm Is Nothing And arn Is Nothing Then

                            rwx = getf("temp2", "", "z DESC ,x ASC,y ASC")
                        End If

                    Catch Ex As Exception

                        MsgBox(Ex.Message, MsgBoxStyle.Critical, "Exception :: In Function 'Stuff' " & vbCrLf & "Programme Running is failure!")
                        MsgBox(Ex.Message)
                        MsgBox(Ex.ToString)
                        MessageBox.Show("Error in MoveBoxStuff", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    Finally
                        ordr = rwx(0)("i")
                    End Try

                    If ordr = 3 Then
                        stk.RemoveAt(arm1)
                    Else
                        If ordr = 1 Then
                            art = a1
                            stk.RemoveAt(arm(0))
                            If arm(0) < arm(1) Then
                                stk.RemoveAt(arm(1) - 1)
                            Else
                                stk.RemoveAt(arm(1))
                            End If

                            stk = UnPush(stk, a2)

                        End If

                        If ordr = 2 Then

                            If pos1 = 1 Then

                                Dim tmp As Double = ar(j).width
                                ar(j).width = ar(j).length
                                ar(j).length = tmp
                            End If

                            If pos1 = 2 Then

                                Dim tmp As Double = ar(j).height
                                ar(j).height = ar(j).width
                                ar(j).width = tmp

                            End If

                            art = b1
                            stk.RemoveAt(arn(0))
                            If arn(0) < arn(1) Then
                                stk.RemoveAt(arn(1) - 1)
                            Else
                                stk.RemoveAt(arn(1))
                            End If

                            stk.Add(b2)

                        End If

                        If ordr = 3 Then

                            stk.RemoveAt(arm1)

                        End If

                    End If

                Else

                    If arm1 <> -1 Then

                        stk.RemoveAt(arm1)

                    End If

                End If

                'Stop

                Dim qty As Integer
                If chngflg Then

                    'Stop

                    ii = FinestOptMethod(ar(j), art, qty, topup(j))

                    'Stop

                    If Occ > 1 Then

                        Dim occlst1 As New List(Of Integer)

                        For i As Integer = 0 To OccLst.Count - 1

                            occlst1.Add(OccLst(i))

                        Next

                        Dim mmm1 As New occ1

                        mmm1.j = j
                        mmm1.j1 = occlst1
                        mmm1.stk = stk
                        OptLst.Add(mmm1)

                    End If

                    Dim ln As Double = ar(j).length
                    Dim wd As Double = ar(j).width
                    Dim ht As Double = ar(j).height

                    Dim nm As String = ari(j)
                    Dim p As Integer = j

                    'Stop
                    If ii = 1 Then

                        ar(p).length = ln
                        ar(p).width = wd
                        ar(p).height = ht

                    End If

                    If ii = 2 Then

                        ar(p).length = ln
                        ar(p).width = ht
                        ar(p).height = wd

                    End If

                    If ii = 3 Then

                        ar(p).length = wd
                        ar(p).width = ht
                        ar(p).height = ln

                    End If

                    If ii = 4 Then

                        ar(p).length = wd
                        ar(p).width = ln
                        ar(p).height = ht

                    End If

                    If ii = 5 Then

                        ar(p).length = ht
                        ar(p).width = wd
                        ar(p).height = ln

                    End If

                    If ii = 6 Then

                        ar(p).length = ht
                        ar(p).width = ln
                        ar(p).height = wd

                    End If

                End If

                'Stop

                Dim flg As Boolean = Math.Abs(((ar(j).length * ar(j).width * ar(j).height) * qty) - (art.length * art.width * art.height)) < 0.01

                Dim Mm As Int64 = BxQty.DFindQty(ari, j)        'Dim mm As Integer = findqty(ari, j)

                'Stop

                If Mm >= qty And flg Then

                    'Stop

                    If drawopt Then

                        If transparr(j) Then

                            traval = 0.8

                        Else

                            traval = 0

                        End If

                        ar(j).StrtPt.x = art.StrtPt.x
                        ar(j).StrtPt.y = art.StrtPt.y
                        ar(j).StrtPt.z = art.StrtPt.z

                        ar(j).AutoDraw(outfile, col, traval, "file:///c:/t2.png", ari(j), arwt(j), qtyflg, txtopt, "", 0, True, "c", "1")

                        j += qty

                        Bitemqty += qty

                    Else

                        j += qty

                        Bitemqty += qty
                        Bplclst(Bitemno) = Bitemqty
                        Btotwt += arwt(j)

                        GoTo lp

                    End If

                End If

                arm = Nothing
                arn = Nothing

                ar(j).StrtPt.x = art.StrtPt.x
                ar(j).StrtPt.y = art.StrtPt.y
                ar(j).StrtPt.z = art.StrtPt.z

                If saveopt Then
m:
                    Try
                        cmd.ExecuteNonQuery()
                    Catch ec As Exception
                        If ec.Message = "Cannot open any more tables." Then
                            conn.Close()
                            conn.Dispose()
                            OleDb.OleDbConnection.ReleaseObjectPool()
                            cmd.Dispose()
                            GC.Collect()

                            conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\container.mdb;Persist Security Info=False"

                            conn.Open()
                            GoTo m
                        End If

                    End Try

                    id1 += 1

                End If

                If drawopt Then

                    If transparr(j) Then

                        traval = 0.8

                    Else

                        traval = 0

                    End If

                End If

                If j = UBound(ar) Then

                End If

                If drawopt Then

                    If j <> 0 Then

                        If ari(j) <> ari(j - 1) Then

                            tmplst.Add(ari(j - 1))
                            tmplst.Add(CStr(totar))
                            Bareaarr.Add(tmplst)
                            totar = 0
                            totar = totar + (ar(j).length * ar(j).width * ar(j).height)

                        Else

                            totar = totar + (ar(j).length * ar(j).width * ar(j).height)

                        End If

                    Else

                        totar = totar + (ar(j).length * ar(j).width * ar(j).height)

                    End If

                End If

                'Stop
                'q = art.SubAction(ar(j), ari, imgname)         'Under developed function from 1 Oct 2k8

                If drawopt Then

                    txtopt = True

                    'Stop
                    If TransactionMenu.chkbxManualChng.Checked Then

                        ar(j).AutoDrawBox(outfile, col, traval, "file:///c:/s" & imgname & ".png", ari(j), arwt(j), qtyflg, txtopt, ari(j), ii, True, "b")
                        GoTo ManulPos
                    End If

                    If Not TransactionMenu.chkbxOptStuff.Checked Then

                        ar(j).Auto3DBx_Move(outfile, col, traval, "file:///c:/s" & imgname & ".png", ari(j), arwt(j), qtyflg, txtopt, ari(j), ii, True, "b", imgname)
                    Else
                        ar(j).Auto3DBx(outfile, col, traval, "file:///c:/s" & imgname & ".png", ari(j), arwt(j), qtyflg, txtopt, ari(j), ii, True, "b", imgname)

                    End If
                    'Stop
ManulPos:

                    If Bqtylst.Count > 0 Then
                        Bplclst(rwidx) = Bitemqty

                    End If

                    Bitemqty += 1

                Else
                    Bitemqty += 1
                    Btotwt += arwt(j)
                End If

                If Bqtylst.Count > 1 Then

                    Bplclst(rwidx) = Bitemqty - 1
                    Bmaxqtylst.Add(Bitemqty - 1)

                End If

                'Stop

                If Not IsNothing(ari) Then
                    Form8.i = Bitemqty
                    'Form8.Label2.Text = CStr(itemqty) & " Items stuffed"
                    'Form8.Label2.Refresh()

                    'TransactionsMenu.lblStatus.Text = " Numbers ::   " & CStr(itemqty) & "    -> Items stuffed"

                    TransactionMenu.lblStatus.Visible = True
                    'TransactionMenu.lblStatus.Text = CStr(itemqty) & " Items stuffed"

                    '$$$$$

                    'TransactionMenu.lblStatus.Text = " Numbers ::   " & CStr(bitemqty) & "    -> Items stuffed"
                    'TransactionMenu.lblStatus.Refresh()

                    'TransactionMenu.pbCSP1.Visible = True
                    'ProgressBarRunning()

                    '$$$$$

                    'Stop

                    BoxCounterRw(Bitemqty, BitemqtyInr, ari(j))

                    If Bitemqty = 350 Then
                        'Stop
                        'MsgBox("OK")

                    End If

                    If Bitemqty = 9 Then

                        'Stop
                        'MsgBox("OK")
                        'off.Close()
                    End If

                    'Stop

                    '*****

                    If flgPause Then

                        PauseSec(SecPause)

                    End If
                    '*****

                    'Stop
                    'off.Close()
                    System.Windows.Forms.Application.DoEvents()

                    'If BitemqtyInr = 216 Then
                    '    Stop
                    '    'off.Close()
                    'End If

                    If exflg Then
                        exflg = False
                        GoTo lp
                    End If
                End If

                'Stop

                'off.Close()

                off.WriteLine("")
                off.WriteLine("# Program. No:- " & BitemqtyInr)
                off.WriteLine("")

                q = art.SubAction(ar(j), ari, imgname)         'Under developed function from 1 Oct 2k8

                '****************************************************
                '****************************************************

                'q = art.SdOps(ar(j), imgname)

                '****************************************************
                '****************************************************

                'If Not q Is Nothing Then
                '    Dim arre() As Area
                '    arre = q.ToArray
                '    For i As Integer = 0 To UBound(arre)
                '        'If j = 66 Then Stop

                '        'Dim nn As Boolean = isgarb(arre(i), j, ar)

                '        isgarb(arre(i), j, ar)

                '    Next

                'End If

                'off.Close()

                'q = art.subtract(ar(j))

                'Stop

                If BitemqtyInr = 359 Then

                    'Stop
                    'MsgBox("Ok")
                    'Stop
                End If

                '$$$$$$$$$$$$$$$$$$$$$$$$$$$

                Dim dd As New Area
                If Not q Is Nothing Then
                    If stk.Count = 0 Then

                        Do While Not q.Count = 0

                            dd = q.Dequeue

                            stk.Add(dd)

                        Loop
                    Else
                        Do While q.Count > 0
                            arb = q.Dequeue
                            ans1 = False

                            'Stop

                            stk = UnPush(stk, arb)
                            'Stop
                        Loop
                    End If
                End If

                '$$$$$$$$$$$$$$$$$$$$$$$$$$$

                '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

                'Stop

                'Dim ans2 As Boolean


                'Stop

                'For i As Integer = 0 To stk.Count - 1
                '    Dim arx As New Area
                '    arx = stk(i)

                '    'Stop

                '    'off.Close()

                '    stk = MrgX(stk, arx, ans2)

                '    'Stop

                '    If ans2 Then
                '        Exit For
                '    End If

                'Next


                '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
                If BitemqtyInr = 9 Then

                    'Stop
                    'MsgBox("OK")
                    'off.Close()
                End If

                If BitemqtyInr > 39 Then

                    'Stop
                    'off.Close()

                End If

                'Stop

                Dim nn1 As New r1
                Dim nn As New Area
                nn.length = ar(j).length
                nn.width = ar(j).width
                nn.height = ar(j).height
                nn.StrtPt.x = ar(j).StrtPt.x
                nn.StrtPt.y = ar(j).StrtPt.y
                nn.StrtPt.z = ar(j).StrtPt.z
                nn1.ar = nn
                nn1.method = ii
                nn1.itmnm = ari(j)

                Dim mmm As New List(Of Area)

                For kk As Integer = 0 To stk.Count - 1
                    mmm.Add(stk(kk))
                Next

                nn1.stk = mmm

                Bahistarr.Add(nn1)

                j += 1

                'off.Close()

                'Stop
lp:
            Loop

            fff()

            If j > 0 Then
                e2 = New e1
                e2.qty = Bitemqty
                e2.itmnm = ari(j - 1)
            End If

            stkj = New List(Of Area)
            For jj As Integer = 0 To stk.Count - 1
                stkj.Add(stk(jj))
            Next
            e2.stk = stkj
            If drawopt Then
                qtyarr.Add(e2)
            End If
            Bmaxqtylst.Add(Bitemqty)
            'Form8.Close()

            TransactionMenu.lblStatus.Visible = False
            TransactionMenu.lblStatusINm.Visible = False
            TransactionMenu.btnStatus.Visible = False
            '@
            TransactionMenu.btnPause.Visible = False
            TransactionMenu.lblSec.Visible = False
            TransactionMenu.mtxtbxPause.Visible = False

            TransactionMenu.pbCSP1.Visible = False

            Eventless()

            If UBound(ar) >= j Then
                fullflag = True
            End If

            If findqtyflg Then
                stk.Clear()
                For i As Integer = 0 To stk.Count - 1
                    If Not chk1(stk2(i), stk) Then
                        If Not chk11(stk2(i), stk) Then
                            stk.Add(stk2(i))
                        End If
                    End If
                Next
            End If

            If drawopt Then
                If UBound(ari) <> -1 Then
                    tmplst.Add(ari(j - 1))
                    tmplst.Add(CStr(totar))
                    Bareaarr.Add(tmplst)
                End If
            End If

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Fatal error in MoveBoxStuff" & vbCrLf & "Data Stuffing failure!", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            MsgBox("Application Exit!")
            GC.Collect()
            Application.Exit()
        Finally
            conn.Close()
        End Try

        If drawopt Or drawarc Then

        End If
        qtyflg = True
        conn.Dispose()
        conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\container.mdb;Persist Security Info=False"
        conn.Open()

        Return stk

    End Function

    Public Function BoxLableStuff(ByVal arc As Area, ByVal ar() As Area, ByVal ari() As String, ByVal arwt() As Single, ByVal saveopt As Boolean, ByVal showempty As Boolean, ByVal outfile As String, ByVal drawarc As Boolean, ByVal transparr() As Boolean, ByVal topup() As Boolean, ByVal txtopt As Boolean, ByVal drawopt As Boolean, ByVal findqtyflg As Boolean, ByVal chngflg As Boolean, ByVal colarr As List(Of List(Of Byte))) As List(Of Area)

        'Stop

        Dim stk2 As New List(Of Area)
        Dim stk1 As New Stack(Of Area)
        Dim art As New Area
        Dim arp As New Area
        Dim are As New Area
        Dim aru As New Area
        Dim arb As New Area
        Dim q As New Queue(Of Area)
        Dim q1 As New Queue(Of Area)
        Dim q2 As New Queue(Of Area)

        Dim ans1 As Boolean
        Dim szchg As Integer = 0
        Dim cmd As New OleDb.OleDbCommand

        Dim qtyflg As Boolean = True
        Dim traval As Single
        Dim ard As New Area
        Dim arm As New List(Of Integer)
        Dim arm1 As Integer
        Dim lstm As New List(Of Area)
        Dim a1 As New Area
        Dim a2 As New Area
        Dim ordr As Integer
        Dim totar As Double
        Dim tmplst As New List(Of String)
        Dim answ As MsgBoxResult

        Dim olditemqty As Integer = 0
        Dim col As String
        Dim ii As Integer

        Dim stkj As New List(Of Area)

        Try
            If saveopt Then

                configid = InputBox("Enter Config Id")

            End If

            Dim ptx As New Point

            ptx.x = arc.length
            ptx.y = arc.width
            ptx.z = arc.height

            Dim col1 As New List(Of Byte)

            col1.Clear()
            col1.Add(255)
            col1.Add(255)
            col1.Add(255)
            col = "1"

            Dim itmnm As String = ""

            If drawarc Then
                Dim ard1 As New Area
                If drawarc Then

                End If
                ard.StrtPt.x = arc.length
                ard.StrtPt.y = 0
                ard.StrtPt.z = 0
                ard.length = 0.5
                ard.width = arc.width
                ard.height = arc.height

                If drawopt Or drawarc Then

                End If

                ard1.StrtPt.x = arc.length - 0.01
                ard1.StrtPt.y = 0
                ard1.StrtPt.z = 0
                ard1.length = 0.5
                ard1.width = ard.width
                ard1.height = ard.height

                If drawopt Or drawarc Then

                    col1.Clear()

                End If

            End If

            If saveopt Then

                cmd.Connection = conn
y:
                Try
                    cmd.ExecuteNonQuery()
                Catch ec As Exception

                    If ec.Message = "Cannot open any more tables." Then
                        conn.Close()
                        conn.Dispose()
                        OleDb.OleDbConnection.ReleaseObjectPool()
                        cmd.Dispose()
                        GC.Collect()

                        conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\container.mdb;Persist Security Info=False"

                        conn.Open()
                        GoTo y
                    End If

                End Try
                id1 += 1
            End If

            arc.StrtPt.x = 0
            arc.StrtPt.y = 0
            arc.StrtPt.z = 0

            Dim j As Integer = 0
            totar = 0
            Bareaarr.Clear()

            For i As Integer = 0 To stk.Count - 1
                stk2.Add(stk(i))
            Next

            Bitemqty = 0
            Btotwt = 0

            'Stop

            If Not IsNothing(ari) Then

                'Form8.Show()
                TransactionMenu.lblStatus.Visible = True
                TransactionMenu.lblStatusINm.Visible = True
                TransactionMenu.btnStatus.Visible = True

                '@
                TransactionMenu.btnPause.Visible = True
                TransactionMenu.mtxtbxPause.Visible = True
                TransactionMenu.lblSec.Visible = True

                TransactionMenu.pbCSP1.Visible = True
                ProgressBarRunning()

                If drawopt Then

                    'Form8.Button1.Visible = False
                    TransactionMenu.btnStatus.Visible = True

                    '@
                    TransactionMenu.btnPause.Visible = True
                    TransactionMenu.mtxtbxPause.Visible = True
                    TransactionMenu.lblSec.Visible = True

                End If

                'Form8.Focus()
                TransactionMenu.lblStatus.Focus()
            End If

            For i As Integer = 0 To Bqtylst.Count - 1
                Bplclst.Add(Bqtylst(i) - 1)
            Next

            fullflag = False
            olditemqty = 0
            Dim imgname As String = "1"

            Do While Not stk.Count = 0 And j <= UBound(ar)      'Loop to write automatic stuffing

                If j > 0 Then
                    If ari(j) <> ari(j - 1) Then
                        imgname = (CInt(imgname) + 1).ToString
                    End If
                End If

                ordr = 0

                If chkwt Then

                    Btotwt += arwt(j)

                    If Btotwt >= contcap Then

                        answ = MsgBox("Maximum weight capacity of the container is reached" & vbCrLf & "Do you want to proceed?", MsgBoxStyle.YesNo)
                        If answ = MsgBoxResult.No Then
                            fullflag = True

                            Exit Do

                        Else
                            fullflag = False

                            chkwt = False
                        End If

                    End If
                End If

                If j = 0 Then

                    col = Bstrtclr

                End If

                If j > 0 And Not IsNothing(ari) Then

                    If ari(j - 1) <> ari(j) Then

                        e2 = New e1
                        e2.qty = Bitemqty
                        e2.itmnm = ari(j - 1)
                        stkj = New List(Of Area)

                        For jj As Integer = 0 To stk.Count - 1
                            stkj.Add(stk(jj))
                        Next

                        e2.stk = stkj

                        If drawopt Then
                            qtyarr.Add(e2)
                        End If

                        If Bqtylst.Count > 0 Then

                        End If

                        Bmaxqtylst.Add(Bitemqty)

                        'Form8.Label1.Text = "Stuffing item:" & ari(j)
                        'Form8.Label1.Refresh()

                        TransactionMenu.lblStatusINm.Text = "Stuffing item : " & ari(j)
                        TransactionMenu.lblStatusINm.Refresh()
                    Else
                        'Form8.Label1.Text = "Stuffing item:" & ari(j)
                        'Form8.Label1.Refresh()

                        TransactionMenu.lblStatusINm.Text = "Stuffing item : " & ari(j)
                        TransactionMenu.lblStatusINm.Refresh()
                    End If

                Else
                    If j > 0 Then
                        'Form8.Show()
                        TransactionMenu.lblStatus.Visible = True
                        TransactionMenu.lblStatusINm.Visible = True
                        TransactionMenu.btnStatus.Visible = True

                        '@
                        TransactionMenu.btnPause.Visible = True
                        TransactionMenu.mtxtbxPause.Visible = True
                        TransactionMenu.lblSec.Visible = True

                        TransactionMenu.pbCSP1.Visible = True
                        ProgressBarRunning()

                        If drawopt Then
                            'Form8.Button1.Visible = False
                            TransactionMenu.btnStatus.Visible = False

                            '@
                            TransactionMenu.btnPause.Visible = False
                            TransactionMenu.lblSec.Visible = False
                            TransactionMenu.mtxtbxPause.Visible = False

                        End If

                        'Form8.Label1.Text = "Finding Maximum Quantity ....."
                        'Form8.Label1.Refresh()

                        TransactionMenu.lblStatus.Text = "Finding Maximum Quantity ....."
                        TransactionMenu.lblStatus.Refresh()

                    End If
                End If

                'Stop

                If drawopt Then

                    If j > 0 Then

                        If ari(j - 1) <> ari(j) Then

                            Bitemqty = 0

                            If col = "r" Then
                                col = "g"
                            ElseIf col = "g" Then
                                col = "b"
                            ElseIf col = "b" Then
                                col = "m"
                            ElseIf col = "m" Then
                                col = "c"
                            ElseIf col = "c" Then
                                col = "y"
                            End If

                            szchg += 1
                            qtyflg = True

                        Else
                            qtyflg = False
                        End If
                    End If
                End If

                If szchg <> 2 Then

                Else

                End If

                'Stop

                arm1 = findopt(stk, ar(j), topup(j))

                'Stop

                art = Nothing

                If arm1 <> -1 Then
                    art = stk(arm1)
                End If

                Dim arn As New List(Of Integer)
                Dim lstn As New List(Of Area)
                Dim b1 As New Area
                Dim b2 As New Area
                Dim pos1 As Integer
                arm = Nothing
                arn = Nothing

                'Stop

                arn = findcandidate1(stk, ar(j), topup(j))

                'Stop

                pos1 = 0

                If Not arn Is Nothing Then

                    pos1 = 0

                Else

                    Dim arxx As New Area

                    arxx.length = ar(j).width
                    arxx.width = ar(j).length
                    arxx.height = ar(j).height

                    arn = findcandidate1(stk, arxx, topup(j))

                    'Stop

                    If Not arn Is Nothing Then
                        pos1 = 1
                    Else
                        If Not topup(j) Then

                            arxx.length = ar(j).length
                            arxx.width = ar(j).height
                            arxx.height = ar(j).width

                            arn = findcandidate1(stk, arxx, False)

                            'Stop

                            If Not arn Is Nothing Then
                                pos1 = 2
                            End If
                        End If
                    End If
                End If

                'Stop

                If arn Is Nothing Then

                    'Stop

                    arm = findcandidate(stk, ar(j))

                    'Stop

                    If Not arm Is Nothing Then
                        If arm(0) = arm1 Then arm = Nothing
                    End If
                End If
                If Not arm Is Nothing Then

                    'Stop

                    lstm = unionp(stk(arm(0)), stk(arm(1)))

                    'Stop

                    a1 = lstm(0)
                    a2 = lstm(1)
                End If

                If Not arn Is Nothing Then

                    'Stop

                    lstm = unionp(stk(arn(0)), stk(arn(1)))

                    'Stop

                    b1 = lstm(0)
                    b2 = lstm(1)
                End If

                If arm Is Nothing And arm1 = -1 Then
                    If drawopt Then

                    End If

                    For m As Integer = j To UBound(ari) - 1
                        If ari(m) <> ari(j) Then
                            j = m

                            GoTo lp

                        End If
                    Next
                    j = UBound(ari) + 1

                    GoTo lp

                Else
                    If arn Is Nothing And arm1 = -1 Then
                        If drawopt Then

                        End If

                        For m As Integer = j To UBound(ari) - 1
                            If ari(m) <> ari(j) Then
                                j = m
                                GoTo lp

                            End If
                        Next
                        j = UBound(ari)

                    End If
                End If


                If Not arm Is Nothing Or Not arn Is Nothing Then

                    cmd.Connection = conn

                    DelTab("temp2")
z:

                    ordr = 0
                    If Not arm Is Nothing Then

                        instab("temp2", New Object() {CStr(a1.StrtPt.x), CStr(a1.StrtPt.y), CStr(a1.StrtPt.z), CStr(1)})
                    End If

                    If Not arn Is Nothing Then
                        instab("temp2", New Object() {CStr(b1.StrtPt.x), CStr(b1.StrtPt.y), CStr(b1.StrtPt.z), CStr(2)})

                    End If

                    If Not art Is Nothing Then
                        instab("temp2", New Object() {CStr(art.StrtPt.x), CStr(art.StrtPt.y), CStr(art.StrtPt.z), CStr(3)})

                    End If

                    Dim rwx As DataRow() = Nothing

                    Try
                        If Not arm Is Nothing Then

                            rwx = getf("temp2", "", "z DESC ,x ASC,y ASC")
                        End If

                        If Not arn Is Nothing Then

                            rwx = getf("temp2", "", "z DESC ,x ASC,y ASC")
                        End If

                        If arn Is Nothing And arm Is Nothing Then

                            rwx = getf("temp2", "", "z DESC ,x ASC")
                        End If

                        If arm Is Nothing And arn Is Nothing Then

                            rwx = getf("temp2", "", "z DESC ,x ASC,y ASC")
                        End If

                    Catch Ex As Exception

                        MsgBox(Ex.Message, MsgBoxStyle.Critical, "Exception :: In Function 'Stuff' " & vbCrLf & "Programme Running is failure!")
                        MsgBox(Ex.Message)
                        MsgBox(Ex.ToString)
                        MessageBox.Show("Error in BoxLableStuff", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    Finally
                        ordr = rwx(0)("i")
                    End Try

                    If ordr = 3 Then
                        stk.RemoveAt(arm1)
                    Else
                        If ordr = 1 Then
                            art = a1
                            stk.RemoveAt(arm(0))
                            If arm(0) < arm(1) Then
                                stk.RemoveAt(arm(1) - 1)
                            Else
                                stk.RemoveAt(arm(1))
                            End If

                            stk = UnPush(stk, a2)

                        End If
                        If ordr = 2 Then

                            If pos1 = 1 Then

                                Dim tmp As Double = ar(j).width
                                ar(j).width = ar(j).length
                                ar(j).length = tmp
                            End If

                            If pos1 = 2 Then

                                Dim tmp As Double = ar(j).height
                                ar(j).height = ar(j).width
                                ar(j).width = tmp

                            End If

                            art = b1
                            stk.RemoveAt(arn(0))
                            If arn(0) < arn(1) Then
                                stk.RemoveAt(arn(1) - 1)
                            Else
                                stk.RemoveAt(arn(1))
                            End If

                            stk.Add(b2)

                        End If

                        If ordr = 3 Then

                            stk.RemoveAt(arm1)

                        End If

                    End If

                Else

                    If arm1 <> -1 Then

                        stk.RemoveAt(arm1)

                    End If

                End If

                'Stop

                Dim qty As Integer
                If chngflg Then

                    'Stop

                    'This method is find out the maximum quantity is placed in the container 
                    'in particular way that the as maximum quantity is fit into it.

                    ii = FinestOptMethod(ar(j), art, qty, topup(j))

                    'Stop

                    If occ > 1 Then

                        Dim occlst1 As New List(Of Integer)

                        For i As Integer = 0 To occlst.Count - 1

                            occlst1.Add(occlst(i))

                        Next

                        Dim mmm1 As New occ1

                        mmm1.j = j
                        mmm1.j1 = occlst1
                        mmm1.stk = stk
                        optlst.Add(mmm1)

                    End If

                    Dim ln As Double = ar(j).length
                    Dim wd As Double = ar(j).width
                    Dim ht As Double = ar(j).height
                    Dim nm As String = ari(j)
                    Dim p As Integer = j

                    'Stop

                    If ii = 1 Then

                        ar(p).length = ln
                        ar(p).width = wd
                        ar(p).height = ht

                    End If

                    If ii = 2 Then

                        ar(p).length = ln
                        ar(p).width = ht
                        ar(p).height = wd

                    End If

                    If ii = 3 Then

                        ar(p).length = wd
                        ar(p).width = ht
                        ar(p).height = ln

                    End If

                    If ii = 4 Then

                        ar(p).length = wd
                        ar(p).width = ln
                        ar(p).height = ht

                    End If

                    If ii = 5 Then

                        ar(p).length = ht
                        ar(p).width = wd
                        ar(p).height = ln

                    End If

                    If ii = 6 Then

                        ar(p).length = ht
                        ar(p).width = ln
                        ar(p).height = wd

                    End If

                End If

                'Stop

                Dim flg As Boolean = Math.Abs(((ar(j).length * ar(j).width * ar(j).height) * qty) - (art.length * art.width * art.height)) < 0.01

                Dim Mm As Int64 = BxQty.DFindQty(ari, j)        'Dim mm As Integer = findqty(ari, j)

                'Stop

                If Mm >= qty And flg Then

                    'Stop

                    If drawopt Then

                        If transparr(j) Then

                            traval = 0.8

                        Else

                            traval = 0

                        End If

                        ar(j).StrtPt.x = art.StrtPt.x
                        ar(j).StrtPt.y = art.StrtPt.y
                        ar(j).StrtPt.z = art.StrtPt.z

                        ar(j).AutoDraw(outfile, col, traval, "file:///c:/t2.png", ari(j), arwt(j), qtyflg, txtopt, "", 0, True, "c", "1")

                        j += qty

                        Bitemqty += qty

                    Else

                        j += qty

                        Bitemqty += qty
                        Bplclst(Bitemno) = Bitemqty
                        Btotwt += arwt(j)

                        GoTo lp

                    End If

                End If

                arm = Nothing
                arn = Nothing

                ar(j).StrtPt.x = art.StrtPt.x
                ar(j).StrtPt.y = art.StrtPt.y
                ar(j).StrtPt.z = art.StrtPt.z

                If saveopt Then
m:
                    Try
                        cmd.ExecuteNonQuery()
                    Catch ec As Exception
                        If ec.Message = "Cannot open any more tables." Then
                            conn.Close()
                            conn.Dispose()
                            OleDb.OleDbConnection.ReleaseObjectPool()
                            cmd.Dispose()
                            GC.Collect()

                            conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\container.mdb;Persist Security Info=False"

                            conn.Open()
                            GoTo m
                        End If

                    End Try

                    id1 += 1

                End If

                If drawopt Then

                    If transparr(j) Then

                        traval = 0.8

                    Else

                        traval = 0

                    End If

                End If

                If j = UBound(ar) Then

                End If

                If drawopt Then

                    If j <> 0 Then

                        If ari(j) <> ari(j - 1) Then

                            tmplst.Add(ari(j - 1))
                            tmplst.Add(CStr(totar))
                            Bareaarr.Add(tmplst)
                            totar = 0
                            totar = totar + (ar(j).length * ar(j).width * ar(j).height)

                        Else

                            totar = totar + (ar(j).length * ar(j).width * ar(j).height)

                        End If

                    Else

                        totar = totar + (ar(j).length * ar(j).width * ar(j).height)

                    End If

                End If

                'Stop

                If drawopt Then

                    txtopt = True

                    'Stop

                    ' To drawing (writing) the main geometry program in VRML in to the First.wrl
                    ' file is done in this routine.

                    ar(j).AutoDrawBox(outfile, col, traval, "file:///c:/s" & imgname & ".png", ari(j), arwt(j), qtyflg, txtopt, ari(j), ii, True, "b")

                    'Stop

                    If Bqtylst.Count > 0 Then
                        Bplclst(rwidx) = Bitemqty

                    End If

                    Bitemqty += 1

                Else
                    Bitemqty += 1
                    Btotwt += arwt(j)
                End If

                If Bqtylst.Count > 1 Then

                    Bplclst(rwidx) = Bitemqty - 1
                    Bmaxqtylst.Add(Bitemqty - 1)

                End If

                'Stop

                If Not IsNothing(ari) Then
                    Form8.i = Bitemqty
                    'Form8.Label2.Text = CStr(itemqty) & " Items stuffed"
                    'Form8.Label2.Refresh()

                    'TransactionsMenu.lblStatus.Text = " Numbers ::   " & CStr(itemqty) & "    -> Items stuffed"

                    TransactionMenu.lblStatus.Visible = True
                    'TransactionMenu.lblStatus.Text = CStr(itemqty) & " Items stuffed"

                    '$$$$$

                    'TransactionMenu.lblStatus.Text = " Numbers ::   " & CStr(bitemqty) & "    -> Items stuffed"
                    'TransactionMenu.lblStatus.Refresh()

                    'TransactionMenu.pbCSP1.Visible = True
                    'ProgressBarRunning()

                    '$$$$$

                    'Stop

                    BoxCounterRw(Bitemqty, BitemqtyInr, ari(j))

                    If Bitemqty = 350 Then
                        'Stop
                        'MsgBox("OK")

                    End If

                    If Bitemqty = 9 Then

                        'Stop
                        'MsgBox("OK")

                    End If


                    'If BitemqtyInr = 359 Then

                    '    Stop
                    '    MsgBox("Ok")

                    'End If


                    'Stop

                    '*****

                    If flgPause Then

                        PauseSec(SecPause)

                    End If

                    '*****
                    'Stop
                    'off.Close()
                    System.Windows.Forms.Application.DoEvents()
                    If exflg Then
                        exflg = False
                        GoTo lp
                    End If
                End If

                'Stop

                'off.Close()

                q = art.subtract(ar(j))

                'Stop

                If BitemqtyInr = 359 Then

                    'Stop
                    'MsgBox("Ok")
                    'Stop
                End If

                '$$$$$$$$$$$$$$$$$$$$$$$$$$$

                'Impements from here 21 August 2K8

                Dim dd As New Area
                If Not q Is Nothing Then
                    If stk.Count = 0 Then

                        Do While Not q.Count = 0

                            dd = q.Dequeue

                            stk.Add(dd)

                        Loop
                    Else
                        Do While q.Count > 0
                            arb = q.Dequeue
                            ans1 = False

                            'Stop

                            stk = UnPush(stk, arb)

                            'Stop

                        Loop

                    End If

                End If

                '$$$$$$$$$$$$$$$$$$$$$$$$$$$










                '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

                'Stop

                'Dim ans2 As Boolean


                'Stop



                'For i As Integer = 0 To stk.Count - 1
                '    Dim arx As New Area
                '    arx = stk(i)

                '    'Stop

                '    'off.Close()

                '    stk = MrgX(stk, arx, ans2)

                '    'Stop

                '    If ans2 Then
                '        Exit For
                '    End If

                'Next


                '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@


                'Stop

                Dim nn1 As New r1
                Dim nn As New Area
                nn.length = ar(j).length
                nn.width = ar(j).width
                nn.height = ar(j).height
                nn.StrtPt.x = ar(j).StrtPt.x
                nn.StrtPt.y = ar(j).StrtPt.y
                nn.StrtPt.z = ar(j).StrtPt.z
                nn1.ar = nn
                nn1.method = ii
                nn1.itmnm = ari(j)
                Dim mmm As New List(Of Area)

                For kk As Integer = 0 To stk.Count - 1
                    mmm.Add(stk(kk))
                Next

                nn1.stk = mmm

                Bahistarr.Add(nn1)

                j += 1

                'Stop

lp:
            Loop

            fff()

            If j > 0 Then
                e2 = New e1
                e2.qty = Bitemqty
                e2.itmnm = ari(j - 1)
            End If

            stkj = New List(Of Area)
            For jj As Integer = 0 To stk.Count - 1
                stkj.Add(stk(jj))
            Next
            e2.stk = stkj
            If drawopt Then
                qtyarr.Add(e2)
            End If
            Bmaxqtylst.Add(Bitemqty)
            'Form8.Close()

            TransactionMenu.lblStatus.Visible = False
            TransactionMenu.lblStatusINm.Visible = False
            TransactionMenu.btnStatus.Visible = False

            '@
            TransactionMenu.btnPause.Visible = False
            TransactionMenu.lblSec.Visible = False
            TransactionMenu.mtxtbxPause.Visible = False


            TransactionMenu.pbCSP1.Visible = False

            Eventless()

            If UBound(ar) >= j Then
                fullflag = True
            End If

            If findqtyflg Then
                stk.Clear()
                For i As Integer = 0 To stk.Count - 1
                    If Not chk1(stk2(i), stk) Then
                        If Not chk11(stk2(i), stk) Then
                            stk.Add(stk2(i))
                        End If
                    End If
                Next
            End If

            If drawopt Then
                If UBound(ari) <> -1 Then
                    tmplst.Add(ari(j - 1))
                    tmplst.Add(CStr(totar))
                    Bareaarr.Add(tmplst)
                End If
            End If

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Fatal error in 'Stuff'" & vbCrLf & "Data Stuffing failure!", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            MsgBox("Application Exit!")
            GC.Collect()
            Application.Exit()
        Finally
            conn.Close()
        End Try

        If drawopt Or drawarc Then

        End If
        qtyflg = True
        conn.Dispose()
        conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\container.mdb;Persist Security Info=False"
        conn.Open()

        Return stk

    End Function

    Public Function BoxLBLStuff(ByVal arc As Area, ByVal ar() As Area, ByVal ari() As String, ByVal arl() As String, ByVal arwt() As Single, ByVal saveopt As Boolean, ByVal showempty As Boolean, ByVal outfile As String, ByVal drawarc As Boolean, ByVal transparr() As Boolean, ByVal topup() As Boolean, ByVal txtopt As Boolean, ByVal drawopt As Boolean, ByVal findqtyflg As Boolean, ByVal chngflg As Boolean, ByVal colarr As List(Of List(Of Byte))) As List(Of Area)

        'Implements from here to make another orientation and change all loops to hat arrangements 13 Aug 2k8

        'Stop

        Dim stk2 As New List(Of Area)
        Dim stk1 As New Stack(Of Area)
        Dim art As New Area
        Dim arp As New Area
        Dim are As New Area
        Dim aru As New Area
        Dim arb As New Area
        Dim q As New Queue(Of Area)
        Dim q1 As New Queue(Of Area)
        Dim q2 As New Queue(Of Area)
        Dim ans1 As Boolean
        Dim szchg As Integer = 0
        Dim cmd As New OleDb.OleDbCommand
        Dim qtyflg As Boolean = True
        Dim traval As Single
        Dim ard As New Area
        Dim arm As New List(Of Integer)
        Dim arm1 As Integer
        Dim lstm As New List(Of Area)
        Dim a1 As New Area
        Dim a2 As New Area
        Dim ordr As Integer
        Dim totar As Double
        Dim tmplst As New List(Of String)
        Dim answ As MsgBoxResult
        Dim olditemqty As Integer = 0
        Dim col As String
        Dim ii As Integer
        Dim stkj As New List(Of Area)

        Try
            If saveopt Then
                configid = InputBox("Enter Config Id")
            End If

            Dim ptx As New Point

            ptx.x = arc.length
            ptx.y = arc.width
            ptx.z = arc.height

            Dim col1 As New List(Of Byte)
            col1.Clear()
            col1.Add(255)
            col1.Add(255)
            col1.Add(255)
            col = "1"

            Dim itmnm As String = ""

            If drawarc Then
                Dim ard1 As New Area
                If drawarc Then
                End If

                ard.StrtPt.x = arc.length
                ard.StrtPt.y = 0
                ard.StrtPt.z = 0
                ard.length = 0.5
                ard.width = arc.width
                ard.height = arc.height

                If drawopt Or drawarc Then

                End If

                ard1.StrtPt.x = arc.length - 0.01
                ard1.StrtPt.y = 0
                ard1.StrtPt.z = 0
                ard1.length = 0.5
                ard1.width = ard.width
                ard1.height = ard.height

                If drawopt Or drawarc Then

                    col1.Clear()
                End If

            End If

            If saveopt Then
                cmd.Connection = conn
y:
                Try
                    cmd.ExecuteNonQuery()
                Catch ec As Exception
                    If ec.Message = "Cannot open any more tables." Then
                        conn.Close()
                        conn.Dispose()
                        OleDb.OleDbConnection.ReleaseObjectPool()
                        cmd.Dispose()
                        GC.Collect()

                        conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\container.mdb;Persist Security Info=False"

                        conn.Open()
                        GoTo y
                    End If

                End Try
                id1 += 1
            End If

            arc.StrtPt.x = 0
            arc.StrtPt.y = 0
            arc.StrtPt.z = 0

            Dim j As Integer = 0
            totar = 0
            Bareaarr.Clear()

            For i As Integer = 0 To stk.Count - 1
                stk2.Add(stk(i))
            Next

            Bitemqty = 0
            Btotwt = 0

            'Stop

            If Not IsNothing(ari) Then
                'Form8.Show()
                TransactionMenu.lblStatus.Visible = True
                TransactionMenu.lblStatusINm.Visible = True
                TransactionMenu.btnStatus.Visible = True

                '@
                TransactionMenu.btnPause.Visible = True
                TransactionMenu.mtxtbxPause.Visible = True
                TransactionMenu.lblSec.Visible = True

                TransactionMenu.pbCSP1.Visible = True
                ProgressBarRunning()

                If drawopt Then
                    'Form8.Button1.Visible = False
                    TransactionMenu.btnStatus.Visible = True

                    '@
                    TransactionMenu.btnPause.Visible = True
                    TransactionMenu.mtxtbxPause.Visible = True
                    TransactionMenu.lblSec.Visible = True

                End If

                'Form8.Focus()
                TransactionMenu.lblStatus.Focus()
            End If

            For i As Integer = 0 To Bqtylst.Count - 1
                Bplclst.Add(Bqtylst(i) - 1)
            Next

            fullflag = False
            olditemqty = 0
            Dim imgname As String = "1"
            Do While Not stk.Count = 0 And j <= UBound(ar)

                If j > 0 Then
                    If ari(j) <> ari(j - 1) Then
                        imgname = (CInt(imgname) + 1).ToString
                    End If
                End If

                ordr = 0

                If chkwt Then
                    Btotwt += arwt(j)
                    If Btotwt >= contcap Then

                        answ = MsgBox("Maximum weight capacity of the container is reached" & vbCrLf & "Do you want to proceed?", MsgBoxStyle.YesNo)
                        If answ = MsgBoxResult.No Then
                            fullflag = True

                            Exit Do

                        Else
                            fullflag = False

                            chkwt = False
                        End If

                    End If
                End If

                If j = 0 Then
                    col = Bstrtclr
                End If
                If j > 0 And Not IsNothing(ari) Then
                    If ari(j - 1) <> ari(j) Then
                        e2 = New e1
                        e2.qty = Bitemqty
                        e2.itmnm = ari(j - 1)
                        stkj = New List(Of Area)
                        For jj As Integer = 0 To stk.Count - 1
                            stkj.Add(stk(jj))
                        Next

                        e2.stk = stkj
                        If drawopt Then
                            qtyarr.Add(e2)
                        End If
                        If Bqtylst.Count > 0 Then

                        End If

                        Bmaxqtylst.Add(Bitemqty)

                        'Form8.Label1.Text = "Stuffing item:" & ari(j)
                        'Form8.Label1.Refresh()

                        TransactionMenu.lblStatusINm.Text = "Stuffing item : " & ari(j)
                        TransactionMenu.lblStatusINm.Refresh()
                    Else
                        'Form8.Label1.Text = "Stuffing item:" & ari(j)
                        'Form8.Label1.Refresh()

                        TransactionMenu.lblStatusINm.Text = "Stuffing item : " & ari(j)
                        TransactionMenu.lblStatusINm.Refresh()
                    End If
                Else
                    If j > 0 Then
                        'Form8.Show()
                        TransactionMenu.lblStatus.Visible = True
                        TransactionMenu.lblStatusINm.Visible = True
                        TransactionMenu.btnStatus.Visible = True

                        '@
                        TransactionMenu.btnPause.Visible = True
                        TransactionMenu.mtxtbxPause.Visible = True
                        TransactionMenu.lblSec.Visible = True

                        TransactionMenu.pbCSP1.Visible = True
                        ProgressBarRunning()

                        If drawopt Then
                            'Form8.Button1.Visible = False
                            TransactionMenu.btnStatus.Visible = False

                            '@
                            TransactionMenu.btnPause.Visible = False
                            TransactionMenu.lblSec.Visible = False
                            TransactionMenu.mtxtbxPause.Visible = False

                        End If

                        'Form8.Label1.Text = "Finding Maximum Quantity ....."
                        'Form8.Label1.Refresh()

                        TransactionMenu.lblStatus.Text = "Finding Maximum Quantity ....."
                        TransactionMenu.lblStatus.Refresh()
                    End If
                End If

                'Stop

                If drawopt Then
                    If j > 0 Then

                        If ari(j - 1) <> ari(j) Then

                            Bitemqty = 0

                            If col = "r" Then
                                col = "g"
                            ElseIf col = "g" Then
                                col = "b"
                            ElseIf col = "b" Then
                                col = "m"
                            ElseIf col = "m" Then
                                col = "c"
                            ElseIf col = "c" Then
                                col = "y"
                            End If

                            szchg += 1
                            qtyflg = True

                        Else
                            qtyflg = False
                        End If
                    End If
                End If

                If szchg <> 2 Then

                Else

                End If

                'Stop

                arm1 = findopt(stk, ar(j), topup(j))

                'Stop

                art = Nothing

                If arm1 <> -1 Then
                    art = stk(arm1)
                End If

                Dim arn As New List(Of Integer)
                Dim lstn As New List(Of Area)
                Dim b1 As New Area
                Dim b2 As New Area
                Dim pos1 As Integer
                arm = Nothing
                arn = Nothing

                'Stop

                arn = findcandidate1(stk, ar(j), topup(j))

                'Stop

                pos1 = 0

                If Not arn Is Nothing Then
                    pos1 = 0
                Else
                    Dim arxx As New Area

                    arxx.length = ar(j).width
                    arxx.width = ar(j).length
                    arxx.height = ar(j).height

                    arn = findcandidate1(stk, arxx, topup(j))

                    'Stop

                    If Not arn Is Nothing Then
                        pos1 = 1
                    Else
                        If Not topup(j) Then
                            arxx.length = ar(j).length
                            arxx.width = ar(j).height
                            arxx.height = ar(j).width

                            arn = findcandidate1(stk, arxx, False)

                            'Stop

                            If Not arn Is Nothing Then
                                pos1 = 2
                            End If
                        End If
                    End If
                End If
                'Stop
                If arn Is Nothing Then
                    'Stop
                    arm = findcandidate(stk, ar(j))
                    'Stop
                    If Not arm Is Nothing Then
                        If arm(0) = arm1 Then arm = Nothing
                    End If
                End If

                If Not arm Is Nothing Then
                    'Stop
                    lstm = unionp(stk(arm(0)), stk(arm(1)))
                    'Stop
                    a1 = lstm(0)
                    a2 = lstm(1)
                End If

                If Not arn Is Nothing Then
                    'Stop
                    lstm = unionp(stk(arn(0)), stk(arn(1)))
                    'Stop
                    b1 = lstm(0)
                    b2 = lstm(1)
                End If

                If arm Is Nothing And arm1 = -1 Then
                    If drawopt Then
                    End If

                    For m As Integer = j To UBound(ari) - 1
                        If ari(m) <> ari(j) Then
                            j = m
                            GoTo lp
                        End If
                    Next
                    j = UBound(ari) + 1

                    GoTo lp

                Else

                    If arn Is Nothing And arm1 = -1 Then
                        If drawopt Then

                        End If

                        For m As Integer = j To UBound(ari) - 1
                            If ari(m) <> ari(j) Then
                                j = m
                                GoTo lp

                            End If
                        Next
                        j = UBound(ari)

                    End If
                End If

                If Not arm Is Nothing Or Not arn Is Nothing Then

                    cmd.Connection = conn

                    DelTab("temp2")
z:

                    ordr = 0
                    If Not arm Is Nothing Then

                        instab("temp2", New Object() {CStr(a1.StrtPt.x), CStr(a1.StrtPt.y), CStr(a1.StrtPt.z), CStr(1)})
                    End If

                    If Not arn Is Nothing Then
                        instab("temp2", New Object() {CStr(b1.StrtPt.x), CStr(b1.StrtPt.y), CStr(b1.StrtPt.z), CStr(2)})

                    End If

                    If Not art Is Nothing Then
                        instab("temp2", New Object() {CStr(art.StrtPt.x), CStr(art.StrtPt.y), CStr(art.StrtPt.z), CStr(3)})

                    End If

                    Dim rwx As DataRow() = Nothing

                    Try
                        If Not arm Is Nothing Then

                            rwx = getf("temp2", "", "z DESC ,x ASC,y ASC")
                        End If

                        If Not arn Is Nothing Then

                            rwx = getf("temp2", "", "z DESC ,x ASC,y ASC")
                        End If

                        If arn Is Nothing And arm Is Nothing Then

                            rwx = getf("temp2", "", "z DESC ,x ASC")
                        End If

                        If arm Is Nothing And arn Is Nothing Then

                            rwx = getf("temp2", "", "z DESC ,x ASC,y ASC")
                        End If

                    Catch Ex As Exception

                        MsgBox(Ex.Message, MsgBoxStyle.Critical, "Exception :: In Function 'Stuff' " & vbCrLf & "Programme Running is failure!")
                        MsgBox(Ex.Message)
                        MsgBox(Ex.ToString)
                        MessageBox.Show("Error in BoxLBLStuff", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    Finally
                        ordr = rwx(0)("i")
                    End Try

                    If ordr = 3 Then
                        stk.RemoveAt(arm1)
                    Else
                        If ordr = 1 Then
                            art = a1
                            stk.RemoveAt(arm(0))
                            If arm(0) < arm(1) Then
                                stk.RemoveAt(arm(1) - 1)
                            Else
                                stk.RemoveAt(arm(1))
                            End If

                            stk = UnPush(stk, a2)

                        End If
                        If ordr = 2 Then
                            If pos1 = 1 Then
                                Dim tmp As Double = ar(j).width
                                ar(j).width = ar(j).length
                                ar(j).length = tmp
                            End If

                            If pos1 = 2 Then
                                Dim tmp As Double = ar(j).height
                                ar(j).height = ar(j).width
                                ar(j).width = tmp
                            End If

                            art = b1
                            stk.RemoveAt(arn(0))
                            If arn(0) < arn(1) Then
                                stk.RemoveAt(arn(1) - 1)
                            Else
                                stk.RemoveAt(arn(1))
                            End If

                            stk.Add(b2)

                        End If
                        If ordr = 3 Then
                            stk.RemoveAt(arm1)
                        End If
                    End If
                Else
                    If arm1 <> -1 Then
                        stk.RemoveAt(arm1)
                    End If
                End If

                'Stop

                Dim qty As Integer
                If chngflg Then

                    'Stop
                    ' This method is find out the maximum quantity is placed in the container in 
                    ' particular way that the as maximum quantity is fit into it.

                    ii = FindOptMethod(ar(j), art, qty, topup(j))

                    'Stop

                    If occ > 1 Then
                        Dim occlst1 As New List(Of Integer)

                        For i As Integer = 0 To occlst.Count - 1
                            occlst1.Add(occlst(i))
                        Next

                        Dim mmm1 As New occ1
                        mmm1.j = j
                        mmm1.j1 = occlst1
                        mmm1.stk = stk
                        optlst.Add(mmm1)

                    End If

                    Dim ln As Double = ar(j).length
                    Dim wd As Double = ar(j).width
                    Dim ht As Double = ar(j).height

                    Dim nm As String = ari(j)
                    Dim p As Integer = j

                    If ii = 1 Then

                        ar(p).length = ln
                        ar(p).width = wd
                        ar(p).height = ht

                    End If

                    If ii = 2 Then
                        ar(p).length = ln
                        ar(p).width = ht
                        ar(p).height = wd

                    End If

                    If ii = 3 Then
                        ar(p).length = wd
                        ar(p).width = ht
                        ar(p).height = ln

                    End If

                    If ii = 4 Then
                        ar(p).length = wd
                        ar(p).width = ln
                        ar(p).height = ht

                    End If

                    If ii = 5 Then
                        ar(p).length = ht
                        ar(p).width = wd
                        ar(p).height = ln

                    End If

                    If ii = 6 Then
                        ar(p).length = ht
                        ar(p).width = ln
                        ar(p).height = wd

                    End If

                End If

                Dim flg As Boolean = Math.Abs(((ar(j).length * ar(j).width * ar(j).height) * qty) - (art.length * art.width * art.height)) < 0.01

                Dim mm As Integer = findqty(ari, j)

                'Stop

                If mm >= qty And flg Then

                    'Stop

                    If drawopt Then
                        If transparr(j) Then
                            traval = 0.8
                        Else
                            traval = 0
                        End If
                        ar(j).StrtPt.x = art.StrtPt.x
                        ar(j).StrtPt.y = art.StrtPt.y
                        ar(j).StrtPt.z = art.StrtPt.z
                        ar(j).AutoDrawLBL(outfile, col, traval, "file:///c:/t2.png", ari(j), arwt(j), qtyflg, txtopt, "", 0, True, "c")
                        j += qty
                        Bitemqty += qty
                    Else
                        j += qty

                        Bitemqty += qty
                        Bplclst(Bitemno) = Bitemqty
                        Btotwt += arwt(j)
                        GoTo lp
                    End If

                End If

                arm = Nothing
                arn = Nothing

                ar(j).StrtPt.x = art.StrtPt.x
                ar(j).StrtPt.y = art.StrtPt.y
                ar(j).StrtPt.z = art.StrtPt.z

                If saveopt Then
m:
                    Try
                        cmd.ExecuteNonQuery()
                    Catch ec As Exception
                        If ec.Message = "Cannot open any more tables." Then
                            conn.Close()
                            conn.Dispose()
                            OleDb.OleDbConnection.ReleaseObjectPool()
                            cmd.Dispose()
                            GC.Collect()

                            conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\container.mdb;Persist Security Info=False"

                            conn.Open()
                            GoTo m
                        End If

                    End Try
                    id1 += 1
                End If

                If drawopt Then

                    If transparr(j) Then
                        traval = 0.8
                    Else
                        traval = 0
                    End If
                End If

                If j = UBound(ar) Then

                End If

                If drawopt Then

                    If j <> 0 Then

                        If ari(j) <> ari(j - 1) Then

                            tmplst.Add(ari(j - 1))
                            tmplst.Add(CStr(totar))
                            Bareaarr.Add(tmplst)
                            totar = 0
                            totar = totar + (ar(j).length * ar(j).width * ar(j).height)

                        Else

                            totar = totar + (ar(j).length * ar(j).width * ar(j).height)

                        End If

                    Else

                        totar = totar + (ar(j).length * ar(j).width * ar(j).height)

                    End If
                End If

                'Stop

                If drawopt Then
                    txtopt = True

                    'Stop

                    ar(j).AutoDrawLBL(outfile, col, traval, "file:///c:/s" & imgname & ".png", ari(j), arwt(j), qtyflg, txtopt, ari(j), ii, True, "b")

                    'Stop

                    If Bqtylst.Count > 0 Then
                        Bplclst(rwidx) = Bitemqty

                    End If

                    Bitemqty += 1

                Else
                    Bitemqty += 1
                    Btotwt += arwt(j)
                End If

                If Bqtylst.Count > 1 Then
                    Bplclst(rwidx) = Bitemqty - 1
                    Bmaxqtylst.Add(Bitemqty - 1)
                End If

                'Stop

                If Not IsNothing(ari) Then
                    Form8.i = Bitemqty
                    'Form8.Label2.Text = CStr(itemqty) & " Items stuffed"
                    'Form8.Label2.Refresh()

                    'TransactionsMenu.lblStatus.Text = " Numbers ::   " & CStr(itemqty) & "    -> Items stuffed"

                    TransactionMenu.lblStatus.Visible = True
                    'TransactionMenu.lblStatus.Text = CStr(itemqty) & " Items stuffed"

                    '$$$$$

                    'TransactionMenu.lblStatus.Text = " Numbers ::   " & CStr(bitemqty) & "    -> Items stuffed"
                    'TransactionMenu.lblStatus.Refresh()

                    'TransactionMenu.pbCSP1.Visible = True
                    'ProgressBarRunning()

                    '$$$$$

                    'Stop

                    BoxCounterRw(Bitemqty, BitemqtyInr, ari(j))

                    If Bitemqty = 350 Then
                        'Stop
                        'MsgBox("OK")

                    End If

                    If Bitemqty = 9 Then

                        'Stop
                        'MsgBox("OK")

                    End If

                    If BitemqtyInr = 359 Then

                        'Stop
                        'MsgBox("Ok")

                    End If

                    'Stop

                    '*****

                    If flgPause Then

                        PauseSec(SecPause)

                    End If
                    '*****

                    'Stop

                    'off.Close()

                    System.Windows.Forms.Application.DoEvents()
                    If exflg Then
                        exflg = False
                        GoTo lp
                    End If
                End If

                'Stop

                'off.Close()

                q = art.subtract(ar(j))

                'Stop

                Dim dd As New Area
                If Not q Is Nothing Then
                    If stk.Count = 0 Then

                        Do While Not q.Count = 0

                            dd = q.Dequeue

                            stk.Add(dd)

                        Loop
                    Else
                        Do While q.Count > 0
                            arb = q.Dequeue
                            ans1 = False

                            'Stop

                            stk = UnPush(stk, arb)

                            'Stop
                        Loop

                    End If

                End If

                'Stop

                Dim ans2 As Boolean

                For i As Integer = 0 To stk.Count - 1
                    Dim arx As New Area
                    arx = stk(i)

                    'Stop

                    'off.Close()

                    stk = MrgX(stk, arx, ans2)

                    'Stop

                    If ans2 Then
                        Exit For
                    End If

                Next

                'Stop

                Dim nn1 As New r1
                Dim nn As New Area
                nn.length = ar(j).length
                nn.width = ar(j).width
                nn.height = ar(j).height
                nn.StrtPt.x = ar(j).StrtPt.x
                nn.StrtPt.y = ar(j).StrtPt.y
                nn.StrtPt.z = ar(j).StrtPt.z
                nn1.ar = nn
                nn1.method = ii
                nn1.itmnm = ari(j)
                Dim mmm As New List(Of Area)

                For kk As Integer = 0 To stk.Count - 1
                    mmm.Add(stk(kk))
                Next

                nn1.stk = mmm

                Bahistarr.Add(nn1)

                j += 1

                'Stop
lp:
            Loop

            fff()

            If j > 0 Then
                e2 = New e1
                e2.qty = Bitemqty
                e2.itmnm = ari(j - 1)
            End If

            stkj = New List(Of Area)
            For jj As Integer = 0 To stk.Count - 1
                stkj.Add(stk(jj))
            Next
            e2.stk = stkj
            If drawopt Then
                qtyarr.Add(e2)
            End If
            Bmaxqtylst.Add(Bitemqty)
            'Form8.Close()

            TransactionMenu.lblStatus.Visible = False
            TransactionMenu.lblStatusINm.Visible = False
            TransactionMenu.btnStatus.Visible = False

            '@
            TransactionMenu.btnPause.Visible = False
            TransactionMenu.lblSec.Visible = False
            TransactionMenu.mtxtbxPause.Visible = False


            TransactionMenu.pbCSP1.Visible = False

            Eventless()

            If UBound(ar) >= j Then
                fullflag = True
            End If

            If findqtyflg Then
                stk.Clear()
                For i As Integer = 0 To stk.Count - 1
                    If Not chk1(stk2(i), stk) Then
                        If Not chk11(stk2(i), stk) Then
                            stk.Add(stk2(i))
                        End If
                    End If
                Next
            End If

            If drawopt Then
                If UBound(ari) <> -1 Then
                    tmplst.Add(ari(j - 1))
                    tmplst.Add(CStr(totar))
                    Bareaarr.Add(tmplst)
                End If
            End If

            'Stop

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Fatal error in BoxLBLStuff" & vbCrLf & "Data Stuffing failure!", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            MsgBox("Application Exit!")
            GC.Collect()
            Application.Exit()
        Finally
            conn.Close()
        End Try

        If drawopt Or drawarc Then

        End If

        qtyflg = True
        conn.Dispose()
        conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\container.mdb;Persist Security Info=False"
        conn.Open()

        Return stk

    End Function

    Public Function WadBoxStuff(ByVal Arc As Area, ByVal Ar() As Area, ByVal Ari() As String, ByVal ArWt() As Single, ByVal SaveOpt As Boolean, ByVal ShowEmpty As Boolean, ByVal OutFile As String, ByVal DrawArc As Boolean, ByVal TranspArr() As Boolean, ByVal TopUp() As Boolean, ByVal TxtOpt As Boolean, ByVal DrawOpt As Boolean, ByVal FindQtyFlg As Boolean, ByVal ChngFlg As Boolean, ByVal ColArr As List(Of List(Of Byte))) As List(Of Area)

        Stop

        Dim Lst2 As New List(Of Area)
        Dim Lst1 As New List(Of Area)
        Dim Art As New Area
        Dim Arp As New Area
        Dim Are As New Area
        Dim Aru As New Area
        Dim Arb As New Area
        Dim Q As New Queue(Of Area)
        Dim Q1 As New Queue(Of Area)
        Dim Q2 As New Queue(Of Area)
        Dim Cmd As New OleDb.OleDbCommand
        Dim Ans As MsgBoxResult
        Dim stkj As New List(Of Area)
        Dim Col As String = Nothing
        Dim TmpLst As New List(Of String)
        Dim TotAr As Double
        Dim Lstm As New List(Of Area)
        Dim A1 As New Area
        Dim A2 As New Area
       
        Dim QtyFlg As Boolean = True
        Dim Ans1 As Boolean

        Dim Ordr As Integer
        Dim Arm1 As Integer
        Dim IMth As Int64
        Dim Traval As Single

        Try

            Dim Ptx As New Point

            Ptx.x = Arc.length
            Ptx.y = Arc.width
            Ptx.z = Arc.height


            If SaveOpt Then
                Cmd.Connection = conn

                Try
Dblp:
                    Cmd.ExecuteNonQuery()

                Catch Ex As Exception
                    If Ex.Message = "Cannot open any more tables." Then
                        conn.Close()
                        conn.Dispose()
                        OleDb.OleDbConnection.ReleaseObjectPool()
                        Cmd.Dispose()
                        GC.Collect()
                        conn.ConnectionString = "Provider=Microsoft.jet.OLEDB.4.0;Data Source = " & CurDir() & "\container.mdb;Persist Security Info=False"
                        conn.Open()
                        GoTo Dblp
                    End If

                End Try
            End If

            Arc.StrtPt.x = 0            'Initializing the area of container xyz points
            Arc.StrtPt.y = 0
            Arc.StrtPt.z = 0

            Dim j As Integer = 0
            Bareaarr.Clear()

            If Not IsNothing(Ari) Then
                TransactionMenu.lblStatus.Visible = True
                TransactionMenu.lblStatusINm.Visible = True
                TransactionMenu.btnStatus.Visible = True

                TransactionMenu.btnPause.Visible = True
                TransactionMenu.mtxtbxPause.Visible = True
                TransactionMenu.lblSec.Visible = True

                TransactionMenu.pbCSP1.Visible = True

                ProgressBarRunning()

                If DrawOpt Then

                    TransactionMenu.btnStatus.Visible = True
                    TransactionMenu.btnPause.Visible = True
                    TransactionMenu.mtxtbxPause.Visible = True
                    TransactionMenu.lblSec.Visible = True

                End If
                TransactionMenu.lblStatus.Focus()
                TransactionMenu.lblStatusINm.Focus()
            End If

            For i As Integer = 0 To Bqtylst.Count - 1
                Bplclst.Add(Bqtylst(i) - 1)
            Next

            fullflag = False

            Dim ImgName As String = "1"

            Do While Not stk.Count = 0 And j <= UBound(Ar)

                If j > 0 Then
                    If Ari(j) <> Ari(j - 1) Then
                        ImgName = (CInt(ImgName) + 1).ToString
                    End If

                End If

                If chkwt Then
                    Btotwt += ArWt(j)
                    If Btotwt >= contcap Then

                        Ans = MsgBox("Maximum weight capacity of the container is reached" & vbCrLf & "Do you want to proceed?", MsgBoxStyle.YesNo)

                        If Ans = MsgBoxResult.No Then
                            fullflag = True

                            Exit Do
                        Else
                            fullflag = False
                            chkwt = False

                        End If
                    End If
                End If

                If j = 0 Then
                    Col = Bstrtclr
                End If

                If j > 0 And IsNothing(Ari) Then

                    If Ari(j - 1) <> Ari(j) Then

                        e2 = New e1
                        e2.qty = Bitemqty
                        e2.itmnm = Ari(j - 1)
                        stkj = New List(Of Area)
                        For jj As Integer = 0 To stk.Count - 1
                            stkj.Add(stk(jj))
                        Next
                        e2.stk = stkj
                        If DrawOpt Then
                            qtyarr.Add(e2)
                        End If

                        Bmaxqtylst.Add(Bitemqty)

                        TransactionMenu.lblStatusINm.Text = "Stuffing Item : " & Ari(j)
                        TransactionMenu.lblStatusINm.Refresh()

                    Else

                        TransactionMenu.lblStatusINm.Text = "Stuffing Item : " & Ari(j)
                        TransactionMenu.lblStatusINm.Refresh()
                    End If

                Else
                    If j > 0 Then
                        TransactionMenu.lblStatus.Visible = True
                        TransactionMenu.lblStatusINm.Visible = True
                        TransactionMenu.btnStatus.Visible = True

                        '@
                        TransactionMenu.btnPause.Visible = True
                        TransactionMenu.mtxtbxPause.Visible = True
                        TransactionMenu.lblSec.Visible = True

                        TransactionMenu.pbCSP1.Visible = True
                        ProgressBarRunning()

                        If DrawOpt Then
                            TransactionMenu.btnStatus.Visible = False

                            TransactionMenu.btnPause.Visible = False
                            TransactionMenu.lblSec.Visible = False
                            TransactionMenu.mtxtbxPause.Visible = False

                        End If
                        TransactionMenu.lblStatus.Text = "Finding Maximum Quantity ....."
                        TransactionMenu.lblStatus.Refresh()
                    End If
                End If

                If DrawOpt Then
                    If j > 0 Then

                        If Ari(j - 1) <> Ari(j) Then

                            Bitemqty = 0

                            If Col = "r" Then
                                Col = "g"
                            ElseIf Col = "g" Then
                                Col = "b"
                            ElseIf Col = "b" Then
                                Col = "m"
                            ElseIf Col = "m" Then
                                Col = "c"
                            ElseIf Col = "c" Then
                                Col = "y"
                            End If

                        Else

                        End If
                    End If
                End If

                Arm1 = WadFindOpt(stk, Ar(j), TopUp(j))


                'Stop

                If Arm1 <> -1 Then
                    Art = stk(Arm1)
                End If

                Dim Arn As List(Of Integer)
                Dim Arm As New List(Of Integer)
                Dim B1 As New Area
                Dim B2 As New Area
                Dim Pos1 As Integer

                Arn = Nothing
                Arm = Nothing

                Arn = FindCandidate1Wad(stk, Ar(j), TopUp(j))

                Pos1 = 0

                If Not Arn Is Nothing Then
                    Pos1 = 0
                Else
                    Dim Arxx As New Area

                    Arxx.length = Ar(j).width
                    Arxx.width = Ar(j).length
                    Arxx.height = Ar(j).height

                    Arn = FindCandidate1Wad(stk, Arxx, TopUp(j))

                    If Not Arn Is Nothing Then
                        Pos1 = 1
                    Else
                        If Not TopUp(j) Then

                            Arxx.length = Ar(j).length
                            Arxx.width = Ar(j).width
                            Arxx.height = Ar(j).height

                            Arn = FindCandidate1Wad(stk, Arxx, False)

                            If Not Arn Is Nothing Then
                                Pos1 = 2
                            End If
                        End If
                    End If
                End If


                If Arn Is Nothing Then

                    Arm = FindCandidateWad(stk, Ar(j))

                    If Not Arm Is Nothing Then

                        If Arm(0) = Arm1 Then Arm = Nothing

                    End If
                End If

                If Not Arm Is Nothing Then

                    Lstm = UnionPtWad(stk(Arm(0)), stk(Arm(1)))

                    A1 = Lstm(0)
                    A2 = Lstm(1)
                End If

                If Not Arn Is Nothing Then

                    Lstm = UnionPtWad(stk(Arn(0)), stk(Arn(1)))

                    b1 = Lstm(0)
                    b2 = Lstm(0)
                End If


                If Arm Is Nothing And Arm1 = -1 Then

                    For m As Integer = j To UBound(Ari) - 1

                        If Ari(m) <> Ari(j) Then

                            j = m

                            GoTo Lp

                        End If
                    Next

                    j = UBound(Ari) + 1

                    GoTo LP

                Else

                    If Arn Is Nothing And Arm1 = -1 Then

                        For m As Integer = j To UBound(Ari) - 1

                            If Ari(m) <> Ari(j) Then

                                j = m

                                GoTo LP

                            End If
                        Next

                        j = UBound(Ari)

                        GoTo LP

                    End If

                End If


                If Not Arm Is Nothing Or Not Arn Is Nothing Then

                    If conn.State = ConnectionState.Closed Then conn.Open()

                    Cmd.Connection = conn

                    DelTabWad("temp2")

                    ordr = 0

                End If

                Dim Qty As Integer = 0

                If ChngFlg Then

                    ' This method is find out the maximum quantity is placed in the container in 
                    ' particular way that the as maximum quantity is fit into it.

                    IMth = WadFindOptMethod(Ar(j), Art, Qty, TopUp(j))

                    If Occ > 1 Then
                        Dim Occlst1 As New List(Of Integer)

                        For i As Integer = 0 To OccLst.Count - 1
                            Occlst1.Add(OccLst(j))
                        Next

                        Dim sss1 As New occ1
                        sss1.j = j
                        sss1.j1 = Occlst1
                        sss1.stk = stk
                        OptLst.Add(sss1)
                    End If

                    Dim Ln As Double = Ar(j).length
                    Dim Wd As Double = Ar(j).width
                    Dim Ht As Double = Ar(j).height

                    Dim Nm As String = Ari(j)
                    Dim k As Integer = j

                    If IMth = 1 Then

                        Ar(k).length = Ln
                        Ar(k).width = Wd
                        Ar(k).height = Ht

                    End If

                    If IMth = 2 Then

                        Ar(k).length = Ln
                        Ar(k).width = Ht
                        Ar(k).height = Wd

                    End If

                    If IMth = 3 Then

                        Ar(k).length = Wd
                        Ar(k).width = Ht
                        Ar(k).height = Ln

                    End If

                    If IMth = 4 Then

                        Ar(k).length = Wd
                        Ar(k).width = Ln
                        Ar(k).height = Ht

                    End If

                    If IMth = 5 Then

                        Ar(k).length = Ht
                        Ar(k).width = Wd
                        Ar(k).height = Ln

                    End If

                    If IMth = 6 Then

                        Ar(k).length = Ht
                        Ar(k).width = Ln
                        Ar(k).height = Wd

                    End If

                End If

                'Stop

                Dim Flg As Boolean = Math.Abs((Ar(j).length * Ar(j).width * Ar(j).height * Qty) - (Ar(j).length * Ar(j).width * Ar(j).height)) < 0.01

                Dim MxQty As Integer = mQty.DFindQty(Ari, j)        'Using DCalcQty.dll

                If MxQty >= Qty And Flg Then

                    If DrawOpt Then

                        If TranspArr(j) Then
                            Traval = 0.8
                        Else
                            Traval = 0
                        End If
                        Ar(j).StrtPt.x = Art.StrtPt.x
                        Ar(j).StrtPt.y = Art.StrtPt.y
                        Ar(j).StrtPt.z = Art.StrtPt.z

                        Ar(j).WadAutoDraw(OutFile, Col, Traval, "file:///c:/t2.png", Ari(j), ArWt(j), QtyFlg, TxtOpt, "", 0, True, "c")
                        j += Qty
                        Bitemqty += Qty
                    Else
                        j += Qty

                        Bitemqty += Qty
                        Bplclst(Bitemno) = Bitemqty
                        Btotwt += ArWt(j)
                        GoTo LP
                    End If

                End If

                'Implements from here 11 Nov 2K8

                Ar(j).StrtPt.x = Art.StrtPt.x
                Ar(j).StrtPt.y = Art.StrtPt.y
                Ar(j).StrtPt.z = Art.StrtPt.z

                If SaveOpt Then
dBLps:
                    Try
                        Cmd.ExecuteNonQuery()
                    Catch ex As Exception
                        If ex.Message = "Cannot open any more tables." Then
                            conn.Close()
                            conn.Dispose()
                            OleDb.OleDbConnection.ReleaseObjectPool()
                            Cmd.Dispose()
                            GC.Collect()

                            conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\container.mdb;Persist Security Info=false"
                            conn.Open()
                            GoTo dBLps

                        End If
                    End Try

                    id1 += 1

                End If

                If DrawOpt Then

                    If j <> 0 Then

                        If Ari(j) <> Ari(j - 1) Then
                            TmpLst.Add(Ari(j - 1))
                            TmpLst.Add(CStr(TotAr))
                            Bareaarr.Add(TmpLst)
                            TotAr = 0
                            TotAr = TotAr + (Ar(j).length * Ar(j).width * Ar(j).height)

                        Else

                            TotAr = TotAr + (Ar(j).length * Ar(j).width * Ar(j).height)

                        End If

                    Else

                        TotAr = TotAr + (Ar(j).length * Ar(j).width * Ar(j).height)

                    End If
                End If

                Dim Ml As New Area

                Ml.length = Ar(j).length
                Ml.width = Ar(j).width
                Ml.height = Ar(j).height
                Ml.StrtPt.x = Ar(j).StrtPt.x
                Ml.StrtPt.y = Ar(j).StrtPt.y
                Ml.StrtPt.z = Ar(j).StrtPt.z

                If DrawOpt Then
                    TxtOpt = True

                    Ar(j).WadAutoDraw(OutFile, Col, Traval, "file:///c:/s" & ImgName & ".png", Ari(j), ArWt(j), QtyFlg, TxtOpt, Ari(j), IMth, True, "b")

                    If Bqtylst.Count > 0 Then
                        Bplclst(rwidx) = Bitemqty
                        Bitemqty += 1
                    End If

                    Bitemqty += 1

                Else
                    Bitemqty += 1
                    Btotwt = ArWt(j)

                End If

                If Bqtylst.Count > 1 Then
                    Bplclst(rwidx) = Bitemqty - 1
                    Bmaxqtylst.Add(Bitemqty - 1)
                End If

                If Not IsNothing(Ari) Then
                    Form8.i = Bitemqty

                    TransactionMenu.lblStatus.Visible = True
                    TransactionMenu.lblStatusINm.Visible = True

                    BoxCounterRw(Bitemqty, BitemqtyInr, Ari(j))

                End If

                System.Windows.Forms.Application.DoEvents()

                off.WriteLine("")
                off.WriteLine("# Program. No:- " & BitemqtyInr)
                off.WriteLine("")


                Q = Art.SubtractWad(Ar(j))

                Dim DD As New Area

                If Not Q Is Nothing Then
                    If stk.Count = 0 Then
                        Do While Q.Count = 0
                            DD = Q.Dequeue
                            stk.Add(DD)
                        Loop


                    Else
                        Do While Q.Count > 0
                            Ans1 = False
                            Arb = Q.Dequeue
                            stk = UnPushWad(stk, Arb)
                        Loop

                    End If
                End If

                Dim Ans2 As Boolean

                For i As Integer = 0 To stk.Count - 1
                    Dim Arx As New Area
                    Arx = stk(i)

                    stk = MrgX(stk, Arx, Ans2)

                    If Ans2 Then
                        Exit For
                    End If

                Next

                Dim PP1 As New R1Wad
                Dim PP As New Area

                PP.StrtPt.x = Ar(j).StrtPt.x
                PP.StrtPt.y = Ar(j).StrtPt.y
                PP.StrtPt.z = Ar(j).StrtPt.z
                PP.length = Ar(j).length
                PP.width = Ar(j).width
                PP.height = Ar(j).height
                PP1.Ar = PP
                PP1.Mthd = IMth
                PP1.ItmNm = Ari(j)

                Dim Sss As New List(Of Area)

                For l As Integer = 0 To stk.Count - 1
                    Sss.Add(stk(l))
                Next

                PP1.Stk = Sss
                BHistArr.Add(PP1)

                j += 1


LP:
            Loop

            FffWad()

            If j > 0 Then

                E2Wad = New E1Wad
                E2Wad.Qty = Bitemqty
                E2Wad.ItmNm = Ari(j - 1)

            End If

            stkj = New List(Of Area)

            For Kk As Integer = 0 To stk.Count - 1
                stkj.Add(stk(Kk))
            Next

            E2Wad.Stk = stkj

            If DrawOpt Then
                QtyArrWad.Add(E2Wad)
            End If

            Bmaxqtylst.Add(Bitemqty)

            TransactionMenu.lblStatus.Visible = False
            TransactionMenu.lblStatusINm.Visible = False
            TransactionMenu.btnStatus.Visible = False

            TransactionMenu.btnPause.Visible = False
            TransactionMenu.lblSec.Visible = False
            TransactionMenu.mtxtbxPause.Visible = False

            TransactionMenu.pbCSP1.Visible = False

            Eventless()

            If UBound(Ar) >= j Then
                fullflag = True
            End If

            If FindQtyFlg Then
                stk.Clear()
                For i As Integer = 0 To stk.Count - 1
                    If Not Chk1Wad(Lst2(i), stk) Then
                        If Not chk11(Lst2(i), stk) Then
                            stk.Add(Lst2(i))
                        End If

                    End If

                Next

            End If

            If DrawOpt Then
                If UBound(Ari) <> -1 Then
                    TmpLst.Add(Ari(j - 1))
                    TmpLst.Add(CStr(TotAr))
                    Bareaarr.Add(TmpLst)
                End If

            End If

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Fatal error in WadBoxStuff", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            MsgBox("Application Exit!")
            off.Close()
            conn.Close()
            siSW.Close()
            ConDrm.Close()
            GC.Collect()
            Application.Exit()
        Finally
            conn.Close()
        End Try

        Return stk

    End Function

    ''    Public Function stuff(ByVal arc As Area, ByVal ar() As Area, ByVal ari() As String, ByVal arwt() As Single, ByVal saveopt As Boolean, ByVal showempty As Boolean, ByVal outfile As String, ByVal drawarc As Boolean, ByVal transparr() As Boolean, ByVal topup() As Boolean, ByVal txtopt As Boolean, ByVal drawopt As Boolean, ByVal findqtyflg As Boolean, ByVal chngflg As Boolean, ByVal colarr As List(Of List(Of Byte))) As List(Of Area)
    ''        Dim stk As New Stack(Of Area)
    ''        Dim stk2 As New List(Of Area)
    ''        Dim stk1 As New Stack(Of Area)
    ''        Dim art As New Area
    ''        Dim arp As New Area
    ''        Dim are As New Area
    ''        Dim aru As New Area
    ''        Dim arb As New Area
    ''        Dim q As New Queue(Of Area)
    ''        Dim q1 As New Queue(Of Area)
    ''        Dim q2 As New Queue(Of Area)
    ''        Dim ans As Boolean
    ''        Dim ans1 As Boolean
    ''        Dim szchg As Integer = 0
    ''        Dim cmd As New OleDb.OleDbCommand
    ''        Dim rdr As OleDb.OleDbDataReader
    ''        Dim qtyflg As Boolean = True
    ''        Dim traval As Single
    ''        Dim ard As New Area
    ''        Dim arm As New List(Of Integer)
    ''        Dim arm1 As Integer
    ''        Dim lstm As New List(Of Area)
    ''        Dim a1 As New Area
    ''        Dim a2 As New Area
    ''        Dim ordr As Integer
    ''        Dim totar As Double
    ''        Dim tmplst As New List(Of String)
    ''        Dim answ As MsgBoxResult
    ''        Dim jplus As Integer
    ''        Dim olditemqty As Integer = 0
    ''        Dim col As String
    ''        Dim ii As Integer

    ''        Dim stkj As New List(Of Area)
    ''        qtyarr.Clear()




    ''        If saveopt Then
    ''            conn.Open()
    ''            configid = InputBox("Enter Config Id")
    ''        End If
    ''        Dim ptx As New Point
    ''        ptx.x = arc.length * 1.6
    ''        ptx.y = arc.width * 1.6
    ''        ptx.z = arc.height * 0.5
    ''        ptx.x = arc.length * 1.6
    ''        ptx.y = arc.width * 0.75
    ''        ptx.z = arc.height * 1.75
    ''        ptx.x = arc.length
    ''        ptx.y = arc.width
    ''        ptx.z = arc.height
    ''        If drawopt Or drawarc Then
    ''            Strt(outfile, True, ptx)
    ''        End If
    ''        trans(outfile, New String() {CStr(arc.length / 2), CStr(arc.width / 2), CStr(arc.height / 2)})
    ''        transp(outfile, "0.5", col)
    ''        placecube(outfile, New String() {CStr(arc.length), CStr(arc.width), CStr(arc.height)})
    ''        Dim col1 As New List(Of Byte)
    ''        col1.Clear()
    ''        col1.Add(255)
    ''        col1.Add(255)
    ''        col1.Add(255)
    ''        col = "1"
    ''        Dim itmnm As String = ""
    ''        If drawarc Then
    ''            Dim ard1 As New Area
    ''            If drawarc Then
    ''                arc.draw(outfile, col, 0.5, "", itmnm, 0, True, False, "container", 0, True)
    ''            End If
    ''            ard.StrtPt.x = arc.length
    ''            ard.StrtPt.y = 0
    ''            ard.StrtPt.z = 0
    ''            ard.length = 0.5
    ''            ard.width = arc.width
    ''            ard.height = arc.height
    ''            If drawopt Or drawarc Then
    ''                col1.Clear()
    ''                col1.Add(255)
    ''                col1.Add(0)
    ''                col1.Add(0)
    ''                ard.draw(outfile, "", 0, "file:///c:\contdoor.png", "", 0, True, False, "door", 0, False)
    ''            End If
    ''            ard1.StrtPt.x = arc.length - 0.01
    ''            ard1.StrtPt.y = 0
    ''            ard1.StrtPt.z = 0
    ''            ard1.length = 0.5
    ''            ard1.width = ard.width
    ''            ard1.height = ard.height
    ''            If drawopt Or drawarc Then
    ''                ard1.draw(outfile, "b", 0, "file:///c:\contdoor.png", "", 0, True, False, "door1", 0, False)
    ''                col1.Clear()
    ''            End If
    ''            FileOpen(1, outfile, OpenMode.Append)
    ''            PrintLine(1, "Shape { ")
    ''            PrintLine(1, "geometry IndexedFaceSet {")
    ''            PrintLine(1, "solid TRUE")
    ''            PrintLine(1, "coord Coordinate {")
    ''            PrintLine(1, "point [ " & CStr(ard.StrtPt.x - 0.01) & " 0 0, " & CStr(ard.StrtPt.x - 0.01) & " " & CStr(ard.width) & " 0, " & CStr(ard.StrtPt.x - 0.01) & " " & CStr(ard.width) & " " & CStr(ard.height) & ", " & CStr(ard.StrtPt.x - 0.01) & " 0 " & CStr(ard.height) & " ]")
    ''            PrintLine(1, "}")
    ''            PrintLine(1, "coordIndex [ 0, 1, 2, 3, -1 ]")
    ''            PrintLine(1, "}}")
    ''            FileClose(1)







    ''        End If
    ''        If saveopt Then
    ''            cmd.Connection = conn
    ''            cmd.CommandText = "insert into config (configid,id,strtx,strty,strtz,length,width,height,col,transp,tex) values('" & configid & "','" & CStr(id1) & "',0,0,0," & CStr(arc.length) & "," & CStr(arc.width) & "," & CStr(arc.height) & ",'" & col & "',0.5,'')"
    ''y:
    ''            Try
    ''                cmd.ExecuteNonQuery()
    ''            Catch ec As Exception
    ''                If ec.Message = "Cannot open any more tables." Then
    ''                    conn.Close()
    ''                    conn.Dispose()
    ''                    OleDb.OleDbConnection.ReleaseObjectPool()
    ''                    cmd.Dispose()
    ''                    GC.Collect()

    ''                    conn = Nothing
    ''                    conn = New OleDb.OleDbConnection
    ''                    conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\container.mdb;Persist Security Info=False"

    ''                    conn.Open()
    ''                    GoTo y
    ''                End If

    ''            End Try
    ''            id1 += 1
    ''        End If

    ''        trans(outfile, New String() {CStr(-arc.length / 2), CStr(-arc.width / 2), CStr(-arc.height / 2)})

    ''        texture(outfile, "file:///c:/t2.png")

    ''        arc.StrtPt.x = 0
    ''        arc.StrtPt.y = 0
    ''        arc.StrtPt.z = 0

    ''        stk.Add(arc)

    ''        Dim j As Integer = 0
    ''        totar = 0
    ''        Bareaarr.Clear()
    ''        For i As Integer = 0 To stk.Count - 1
    ''            stk2.Add(stk(i))
    ''        Next
    ''        itemqty = 0
    ''        Btotwt = 0
    ''        If Not IsNothing(ari) Then
    ''            Form8.Show()
    ''            If drawopt Then
    ''                Form8.Button1.Visible = False
    ''            End If
    ''            Form8.Focus()
    ''        End If

    ''        For i As Integer = 0 To Bqtylst.Count - 1
    ''            Bplclst.Add(Bqtylst(i) - 1)
    ''        Next
    ''        itemno = 0
    ''        fullflag = False
    ''        olditemqty = 0
    ''        Dim imgname As String = "1"
    ''        Do While Not stk.Count = 0 And j <= UBound(ar)
    ''            If j = 172 Then Stop
    ''            If j > 0 Then
    ''                If ari(j) <> ari(j - 1) Then
    ''                    imgname = (CInt(imgname) + 1).ToString
    ''                End If
    ''            End If
    ''            If j = 225 Then Stop
    ''            If LCase(ari(j)) = "item03" Then Stop
    ''            ordr = 0
    ''            If j = 86 Then Stop
    ''            If j = 307 Then Stop
    ''            If j = 20 Then Stop
    ''            Dim qx As New Queue(Of Area)
    ''            For i As Integer = 0 To stk.Count - 1
    ''                qx.Enqueue(stk(i))
    ''            Next


    ''            For i As Integer = 0 To stk.Count - 1
    ''                arb = stk(i)
    ''                stk = UnPush(stk, arb)
    ''            Next




    ''            If j = 40 Then Stop
    ''            If ari(j) = "A18" Then Stop
    ''            If j = 6 Then Stop
    ''            col = colarr(j)
    ''            If chkwt Then
    ''                Btotwt += arwt(j)
    ''                If Btotwt >= contcap Then

    ''                    answ = MsgBox("Maximum weight capacity of the container is reached" & vbCrLf & "Do you want to proceed?", MsgBoxStyle.YesNo)
    ''                    If answ = MsgBoxResult.No Then
    ''                        fullflag = True
    ''                        j = UBound(ar) + 1
    ''                        Exit Do
    ''                        GoTo lp
    ''                    Else
    ''                        fullflag = False
    ''                        j = UBound(ar) + 1
    ''                        chkwt = False
    ''                    End If

    ''                End If
    ''            End If

    ''            If j = 0 Then
    ''                col = Bstrtclr

    ''                putcol(outfile, col)
    ''            End If
    ''            If ari(j) = "ITEM06" Then Stop




    ''            If j > 0 And Not IsNothing(ari) Then
    ''                If ari(j - 1) <> ari(j) Then
    ''                    e2 = New e1
    ''                    e2.qty = itemqty
    ''                    e2.itmnm = ari(j - 1)
    ''                    stkj = New List(Of Area)
    ''                    For jj As Integer = 0 To stk.Count - 1
    ''                        stkj.Add(stk(jj))
    ''                    Next
    ''                    e2.stk = stkj
    ''                    If drawopt Then
    ''                        qtyarr.Add(e2)
    ''                    End If
    ''                    If Bqtylst.Count > 0 Then
    ''                        plclst(itemno) = itemqty - 1
    ''                        plclst(itemno + 1) = plclst(itemno + 1) + 1
    ''                    End If

    ''                    Bmaxqtylst.Add(itemqty)
    ''                    itemno += 1


    ''                    Form8.Label1.Text = "Stuffing item:" & ari(j)
    ''                    Form8.Label1.Refresh()
    ''                Else
    ''                    itemno += 1
    ''                    Form8.Label1.Text = "Stuffing item:" & ari(j)
    ''                    Form8.Label1.Refresh()
    ''                End If
    ''            Else
    ''                If j > 0 Then
    ''                    Form8.Show()
    ''                    If drawopt Then
    ''                        Form8.Button1.Visible = False
    ''                    End If
    ''                    Form8.Label1.Text = "Finding Maximum Quantity...."
    ''                    Form8.Label1.Refresh()
    ''                End If
    ''            End If




    ''            If drawopt Then
    ''                If j > 0 Then
    ''                    If ar(j - 1).length <> ar(j).length Or ar(j - 1).width <> ar(j).width Or ar(j - 1).height <> ar(j).height Then
    ''                        If ari(j - 1) <> ari(j) Then
    ''                            MsgBox(itemqty)
    ''                            itemqty = 0
    ''                            totwt = 0
    ''                            If col = "r" Then
    ''                                col = "g"
    ''                            ElseIf col = "g" Then
    ''                                col = "b"
    ''                            ElseIf col = "b" Then
    ''                                col = "m"
    ''                            ElseIf col = "m" Then
    ''                                col = "c"
    ''                            ElseIf col = "c" Then
    ''                                col = "y"
    ''                            End If
    ''                            putcol(outfile, col)
    ''                            szchg += 1
    ''                            qtyflg = True

    ''                        Else
    ''                            qtyflg = False
    ''                        End If
    ''                    End If
    ''                End If

    ''                If szchg <> 2 Then
    ''                    transp(outfile, 0.5, "1")
    ''                    putcol(outfile, col)
    ''                Else
    ''                    putcol(outfile, col)
    ''                End If



    ''                If j = 13 Then
    ''                    Closef(outfile)
    ''                    Process.Start(outfile)
    ''                    Stop
    ''                End If
    ''                q1 = q1draw(q1, ar(j), ari(j), arwt(j), ans, True, outfile, qtyflg, transparr(j))
    ''                If ans Then
    ''                    j += 1
    ''                    GoTo lp
    ''                End If
    ''                arm1 = findopt(stk, ar(j), topup(j))
    ''                art = Nothing
    ''                If arm1 <> -1 Then
    ''                    art = stk(arm1)


    ''                End If

    ''                Dim aru1 As New List(Of Integer)
    ''                aru1 = findaru1(stk, ar(j), topup(j))


    ''                Dim arn As New List(Of Integer)
    ''                Dim lstn As New List(Of Area)
    ''                Dim b1 As New Area
    ''                Dim b2 As New Area
    ''                Dim pos1 As Integer
    ''                arm = Nothing
    ''                arn = Nothing
    ''                If j = 16 Then Stop
    ''                arn = findcandidate1(stk, ar(j), topup(j))
    ''                pos1 = 0
    ''                If Not arn Is Nothing Then
    ''                    pos1 = 0
    ''                Else
    ''                    Dim arxx As New Area
    ''                    arxx.length = ar(j).width
    ''                    arxx.width = ar(j).length
    ''                    arxx.height = ar(j).height
    ''                    arn = findcandidate1(stk, arxx, topup(j))
    ''                    If Not arn Is Nothing Then
    ''                        pos1 = 1
    ''                    Else
    ''                        If Not topup(j) Then
    ''                            arxx.length = ar(j).length
    ''                            arxx.width = ar(j).height
    ''                            arxx.height = ar(j).width
    ''                            arn = findcandidate1(stk, arxx, False)
    ''                            If Not arn Is Nothing Then
    ''                                pos1 = 2
    ''                            End If
    ''                        End If
    ''                    End If
    ''                End If
    ''                If arn Is Nothing Then
    ''                    arm = findcandidate(stk, ar(j))
    ''                    If Not arm Is Nothing Then
    ''                        If arm(0) = arm1 Then arm = Nothing
    ''                    End If
    ''                End If
    ''                If Not arm Is Nothing Then
    ''                    lstm = unionp(stk(arm(0)), stk(arm(1)))
    ''                    a1 = lstm(0)
    ''                    a2 = lstm(1)
    ''                End If

    ''                If Not arn Is Nothing Then

    ''                    lstm = unionp(stk(arn(0)), stk(arn(1)))
    ''                    b1 = lstm(0)
    ''                    b2 = lstm(1)
    ''                End If

    ''                art = findopt(stk, ar(j))

    ''                If arm Is Nothing And arm1 = -1 Then
    ''                    If drawopt Then
    ''                        Closef(outfile)
    ''                        clsflg = True
    ''                    End If
    ''                    If drawopt Then
    ''                        plclst(itemno) = plclst(itemno) - 1
    ''                    End If

    ''                    For m As Integer = j To UBound(ari) - 1
    ''                        If ari(m) <> ari(j) Then
    ''                            j = m
    ''                            Exit Do
    ''                            GoTo lp
    ''                            Exit For
    ''                        End If
    ''                    Next
    ''                    j = UBound(ari) + 1
    ''                    maxqtylst.Add(itemqty)
    ''                    GoTo lp
    ''                    Return stk
    ''                Else
    ''                    If arn Is Nothing And arm1 = -1 Then
    ''                        If drawopt Then
    ''                            Closef(outfile)
    ''                            clsflg = True
    ''                        End If
    ''                        If drawopt Then
    ''                            plclst(plclst.Count - 1) = plclst(plclst.Count - 1) - 1
    ''                        End If

    ''                        For m As Integer = j To UBound(ari) - 1
    ''                            If ari(m) <> ari(j) Then
    ''                                j = m
    ''                                GoTo lp
    ''                                Exit Do
    ''                                Exit For
    ''                            End If
    ''                        Next
    ''                        j = UBound(ari)
    ''                        maxqtylst.Add(itemqty)
    ''                        GoTo lp
    ''                        Return stk

    ''                    End If
    ''                End If


    ''                If Not arm Is Nothing Or Not arn Is Nothing Then
    ''                    If Not arm Is Nothing Then
    ''                        cmd.Connection = conn
    ''                        cmd.CommandText = "delete from temp2"
    ''                        DelTab("temp2")
    ''z:
    ''                        Try
    ''                            cmd.ExecuteNonQuery()
    ''                        Catch ec As Exception
    ''                            If ec.Message = "Cannot open any more tables." Then
    ''                                conn.Close()
    ''                                conn.Dispose()
    ''                                OleDb.OleDbConnection.ReleaseObjectPool()
    ''                                cmd.Dispose()
    ''                                GC.Collect()

    ''                                'conn = Nothing
    ''                                'conn = New OleDb.OleDbConnection
    ''                                conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\container.mdb;Persist Security Info=False"

    ''                                conn.Open()
    ''                                GoTo z
    ''                            End If

    ''                        End Try
    ''                        ordr = 0
    ''                        If Not arm Is Nothing Then
    ''                    dim aa as New Object()  { CStr(a1.strtpt.x), CStr(a1.strtpt.y), CStr(a1.strtpt.z), CStr(1)}
    ''                            cmd.CommandText = "insert into temp2 values(" & CStr(a1.StrtPt.x) & "," & CStr(a1.StrtPt.y) & "," & CStr(a1.StrtPt.z) & "," & CStr(1) & ")"
    ''                            instab("temp2", New Object() {CStr(a1.StrtPt.x), CStr(a1.StrtPt.y), CStr(a1.StrtPt.z), CStr(1)})
    ''w:
    ''                            Try
    ''                                cmd.ExecuteNonQuery()
    ''                            Catch ec As Exception
    ''                                If ec.Message = "Cannot open any more tables." Then
    ''                                    conn.Close()
    ''                                    conn.Dispose()
    ''                                    OleDb.OleDbConnection.ReleaseObjectPool()
    ''                                    cmd.Dispose()
    ''                                    GC.Collect()
    ''                                    'conn = Nothing
    ''                                    'conn = New OleDb.OleDbConnection
    ''                                    conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\container.mdb;Persist Security Info=False"

    ''                                    conn.Open()
    ''                                    GoTo w
    ''                                End If

    ''                            End Try
    ''                            arm = Nothing
    ''                        End If

    ''                        If Not arn Is Nothing Then
    ''                            instab("temp2", New Object() {CStr(b1.StrtPt.x), CStr(b1.StrtPt.y), CStr(b1.StrtPt.z), CStr(2)})
    ''                            cmd.CommandText = "insert into temp2 values(" & CStr(b1.StrtPt.x) & "," & CStr(b1.StrtPt.y) & "," & CStr(b1.StrtPt.z) & "," & CStr(2) & ")"
    ''a:
    ''                            Try
    ''                                cmd.ExecuteNonQuery()
    ''                            Catch ec As Exception
    ''                                If ec.Message = "Cannot open any more tables." Then
    ''                                    conn.Close()
    ''                                    conn.Dispose()
    ''                                    OleDb.OleDbConnection.ReleaseObjectPool()
    ''                                    cmd.Dispose()
    ''                                    GC.Collect()

    ''                                    'conn = Nothing
    ''                                    'conn = New OleDb.OleDbConnection
    ''                                    conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\container.mdb;Persist Security Info=False"

    ''                                    conn.Open()
    ''                                    GoTo a
    ''                                End If

    ''                            End Try
    ''                            arn = Nothing
    ''                        End If

    ''                        If Not art Is Nothing Then
    ''                            instab("temp2", New Object() {CStr(art.StrtPt.x), CStr(art.StrtPt.y), CStr(art.StrtPt.z), CStr(3)})
    ''                            cmd.CommandText = "insert into temp2 values(" & CStr(art.StrtPt.x) & "," & CStr(art.StrtPt.y) & "," & CStr(art.StrtPt.z) & "," & CStr(3) & ")"
    ''b:
    ''                            Try
    ''                                cmd.ExecuteNonQuery()
    ''                            Catch ec As Exception
    ''                                If ec.Message = "Cannot open any more tables." Then
    ''                                    conn.Close()
    ''                                    conn.Dispose()
    ''                                    leDbConnection.ReleaseObjectPool()
    ''                                    cmd.Dispose()
    ''                                    GC.Collect()
    ''                                    'conn = Nothing
    ''                                    'conn = New OleDb.OleDbConnection
    ''                                    conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\container.mdb;Persist Security Info=False"

    ''                                    conn.Open()
    ''                                    GoTo b
    ''                                End If

    ''                            End Try
    ''                        End If

    ''                        cmd.CommandText = "select * from temp2 order by z desc ,x asc,y asc"
    ''                        Dim rwx As DataRow()
    ''                        If Not arm Is Nothing Then
    ''                            cmd.CommandText = "select * from temp2 order by z desc ,x asc,y asc"
    ''                            rwx = getf("temp2", "", "z DESC ,x ASC,y ASC")
    ''                        End If

    ''                        If Not arn Is Nothing Then
    ''                            cmd.CommandText = "select * from temp2 order by z desc ,x asc,y asc"
    ''                            rwx = getf("temp2", "", "z DESC ,x ASC,y ASC")
    ''                        End If

    ''                        If arn Is Nothing And arm Is Nothing Then
    ''                            cmd.CommandText = "select * from temp2 order by z desc, x asc"
    ''                            rwx = getf("temp2", "", "z DESC ,x ASC")
    ''                        End If

    ''                        If arm Is Nothing And arn Is Nothing Then
    ''                            cmd.CommandText = "select * from temp2 order by z desc ,x asc,y asc"
    ''                            rwx = getf("temp2", "", "z DESC ,x ASC,y ASC")
    ''                        End If
    ''                        Try
    ''                            rdr = cmd.ExecuteReader
    ''                        Catch
    ''                            conn.Dispose()
    ''                            conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\container.mdb;Persist Security Info=False"
    ''                            conn.Open()
    ''                            rdr = cmd.ExecuteReader
    ''                        End Try
    ''                        rdr.Read()
    ''                        ordr = rdr.Item("i")
    ''                        rdr.Close()
    ''                        attention()
    ''                        ordr = rwx(0)("i")

    ''                        If ordr = 3 Then
    ''                            stk.RemoveAt(arm1)
    ''                        Else
    ''                            If ordr = 1 Then
    ''                                art = a1
    ''                                stk.RemoveAt(arm(0))
    ''                                If arm(0) < arm(1) Then
    ''                                    stk.RemoveAt(arm(1) - 1)
    ''                                Else
    ''                                    stk.RemoveAt(arm(1))
    ''                                End If
    ''                                If Not chk1(a2, stk) Then
    ''                                    UnPush(stk, a2)
    ''                                    stk.Add(a2)
    ''                                    stk = UnPush(stk, a2)
    ''                                End If
    ''                            End If
    ''                            If ordr = 2 Then
    ''                                If pos1 = 1 Then
    ''                                    Dim tmp As Double = ar(j).width
    ''                                    ar(j).width = ar(j).length
    ''                                    ar(j).length = tmp
    ''                                End If

    ''                                If pos1 = 2 Then
    ''                                    Dim tmp As Double = ar(j).height
    ''                                    ar(j).height = ar(j).width
    ''                                    ar(j).width = tmp
    ''                                End If


    ''                                art = b1
    ''                                stk.RemoveAt(arn(0))
    ''                                If arn(0) < arn(1) Then
    ''                                    stk.RemoveAt(arn(1) - 1)
    ''                                Else
    ''                                    stk.RemoveAt(arn(1))
    ''                                End If
    ''                                If Not chk1(b2, stk) Then
    ''                                    stk.Add(b2)
    ''                                End If
    ''                            End If
    ''                            If ordr = 3 Then
    ''                                stk.RemoveAt(arm1)
    ''                            End If
    ''                        End If
    ''                    Else
    ''                        art = stk(arm1)
    ''                        If arm1 <> -1 Then
    ''                            stk.RemoveAt(arm1)
    ''                        End If
    ''                    End If

    ''                    attention(start)

    ''                    Dim qty As Integer
    ''                    If chngflg Then
    ''                        ii = FindOptMethod(ar(j), art, qty, topup(j))
    ''                        If Occ > 1 Then
    ''                            Dim occlst1 As New List(Of Integer)
    ''                            For i As Integer = 0 To OccLst.Count - 1
    ''                                occlst1.Add(OccLst(i))
    ''                            Next
    ''                            Dim mmm1 As New occ1
    ''                            mmm1.j = j
    ''                            mmm1.j1 = occlst1
    ''                            mmm1.stk = stk
    ''                            OptLst.Add(mmm1)
    ''                        End If
    ''                        Dim ln As Double = ar(j).length
    ''                        Dim wd As Double = ar(j).width
    ''                        Dim ht As Double = ar(j).height

    ''                        For p As Integer = j To j + qty

    ''                            Dim nm As String = ari(j)
    ''                            Dim p As Integer = j


    ''                            Do While Not p >= UBound(ari) - 1 AndAlso ari(p) <> ari(p + 1)
    ''                                If ii = 1 Then
    ''                                    Exit Do
    ''                                End If

    ''                                If ii = 2 Then
    ''                                    ar(p).length = ln
    ''                                    ar(p).width = ht
    ''                                    ar(p).height = wd
    ''                                    Exit Do
    ''                                End If

    ''                                If ii = 3 Then
    ''                                    ar(p).length = wd
    ''                                    ar(p).width = ht
    ''                                    ar(p).height = ln
    ''                                    Exit Do
    ''                                End If

    ''                                If ii = 4 Then
    ''                                    ar(p).length = wd
    ''                                    ar(p).width = ln
    ''                                    ar(p).height = ht
    ''                                    Exit Do
    ''                                End If

    ''                                If ii = 5 Then
    ''                                    ar(p).length = ht
    ''                                    ar(p).width = wd
    ''                                    ar(p).height = ln
    ''                                    Exit Do
    ''                                End If

    ''                                If ii = 6 Then
    ''                                    ar(p).length = ht
    ''                                    ar(p).width = ln
    ''                                    ar(p).height = wd
    ''                                    Exit Do
    ''                                End If

    ''                                p += 1
    ''                            Loop

    ''                        Next




    ''                    End If

    ''                    Dim flg As Boolean = Math.Abs(((ar(j).length * ar(j).width * ar(j).height) * qty) - (art.length * art.width * art.height)) < 0.01
    ''                    Dim mm As Integer = findqty(ari, j)
    ''                    If j = 6 Then Stop
    ''                    If mm >= qty And flg Then
    ''                        Stop
    ''                        If drawopt Then
    ''                            If transparr(j) Then
    ''                                traval = 0.8
    ''                            Else
    ''                                traval = 0
    ''                            End If
    ''                            ar(j).StrtPt.x = art.StrtPt.x
    ''                            ar(j).StrtPt.y = art.StrtPt.y
    ''                            ar(j).StrtPt.z = art.StrtPt.z
    ''                            ar(j).draw(outfile, col, traval, "file:///c:/t2.png", ari(j), arwt(j), qtyflg, txtopt, "", 0, True, "c")
    ''                            drwopt(art, ar(j), outfile, col, traval, ari(j), arwt(j), qtyflg, txtopt)

    ''                            j += qty
    ''                            itemqty += qty
    ''                        Else
    ''                            j += qty

    ''                            itemqty += qty
    ''                            Bplclst(itemno) = itemqty
    ''                            Btotwt += arwt(j)
    ''                            GoTo lp
    ''                        End If

    ''                    End If


    ''            attention end

    ''                    art = stk.Pop
    ''                    If Form4.ftip(art, ar(j)) Then
    ''                        If art.length >= ar(j).length AndAlso art.width >= ar(j).width AndAlso art.height >= ar(j).height Then
    ''                            arm = Nothing
    ''                            arn = Nothing
    ''                            ar(j).StrtPt.x = art.StrtPt.x

    ''                            ar(j).StrtPt.y = art.StrtPt.y
    ''                            ar(j).StrtPt.z = art.StrtPt.z
    ''                            trans(outfile, New String() {CStr(art.StrtPt.x), CStr(art.StrtPt.y), CStr(art.StrtPt.z)})
    ''                            trans(outfile, New String() {CStr(ar(j).length / 2), CStr(ar(j).width / 2), CStr(ar(j).height / 2)})
    ''                            placecube(outfile, New String() {CStr(ar(j).length), CStr(ar(j).width), CStr(ar(j).height)})

    ''                            If saveopt Then
    ''                                Da.InsertCommand.CommandText = "insert into config (configid,id,strtx,strty,strtz,length,width,height,col,transp,tex) values('" & configid & "','" & CStr(id1) & "'," & CStr(art.StrtPt.x) & "," & CStr(art.StrtPt.y) & "," & art.StrtPt.z & "," & CStr(ar(j).length) & "," & CStr(ar(j).width) & "," & CStr(ar(j).height) & ",'" & col & "',0,'')"
    ''                                Da.InsertCommand.ExecuteNonQuery()
    ''                                cmd.CommandText = "insert into config (configid,id,strtx,strty,strtz,length,width,height,col,transp,tex) values('" & configid & "','" & CStr(id1) & "'," & CStr(art.StrtPt.x) & "," & CStr(art.StrtPt.y) & "," & art.StrtPt.z & "," & CStr(ar(j).length) & "," & CStr(ar(j).width) & "," & CStr(ar(j).height) & ",'" & col & "',0,'')"
    ''m:
    ''                                Try
    ''                                    cmd.ExecuteNonQuery()
    ''                                Catch ec As Exception
    ''                                    If ec.Message = "Cannot open any more tables." Then
    ''                                        conn.Close()
    ''                                        conn.Dispose()
    ''                                        OleDb.OleDbConnection.ReleaseObjectPool()
    ''                                        cmd.Dispose()
    ''                                        GC.Collect()

    ''                                        conn = Nothing
    ''                                        conn = New OleDb.OleDbConnection
    ''                                        conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\container.mdb;Persist Security Info=False"

    ''                                        conn.Open()
    ''                                        GoTo m
    ''                                    End If

    ''                                End Try
    ''                                id1 += 1
    ''                            End If

    ''                            trans(outfile, New String() {CStr(-art.StrtPt.x), CStr(-art.StrtPt.y), CStr(-art.StrtPt.z)})
    ''                            trans(outfile, New String() {CStr(-ar(j).length / 2), CStr(-ar(j).width / 2), CStr(-ar(j).height / 2)})

    ''                            If drawopt Then

    ''                                If transparr(j) Then
    ''                                    traval = 0.8
    ''                                Else
    ''                                    traval = 0
    ''                                End If
    ''                            End If
    ''                            If j = UBound(ar) Then
    ''                                Stop
    ''                            End If
    ''                            If drawopt Then
    ''                                If j <> 0 Then
    ''                                    If ari(j) <> ari(j - 1) Then
    ''                                        tmplst.Add(ari(j - 1))
    ''                                        tmplst.Add(CStr(totar))
    ''                                        Bareaarr.Add(tmplst)
    ''                                        totar = 0
    ''                                        totar = totar + (ar(j).length * ar(j).width * ar(j).height)
    ''                                    Else
    ''                                        totar = totar + (ar(j).length * ar(j).width * ar(j).height)
    ''                                    End If
    ''                                Else
    ''                                    totar = totar + (ar(j).length * ar(j).width * ar(j).height)
    ''                                End If
    ''                            End If
    ''                            If drawopt Then
    ''                                txtopt = True
    ''                                ar(j).draw(outfile, col, traval, "file:///c:/s" & imgname & ".png", ari(j), arwt(j), qtyflg, txtopt, ari(j), ii, True, "b")
    ''                                If Bqtylst.Count > 0 Then
    ''                                    Bplclst(rwidx) = itemqty

    ''                                End If


    ''                                itemqty += 1

    ''                            Else
    ''                                itemqty += 1
    ''                                Btotwt += arwt(j)
    ''                            End If
    ''                            If Bqtylst.Count > 1 Then
    ''                                Bplclst(rwidx) = itemqty - 1
    ''                                Bmaxqtylst.Add(itemqty - 1)
    ''                            End If
    ''                            If Not IsNothing(ari) Then
    ''                                Form8.i = itemqty
    ''                                Form8.Label2.Text = CStr(itemqty) & " items stuffed"
    ''                                Form8.Label2.Refresh()
    ''                                System.Windows.Forms.Application.DoEvents()
    ''                                If exflg Then
    ''                                    exflg = False
    ''                                    GoTo lp
    ''                                End If
    ''                            End If
    ''                            If ordr = 3 OrElse ordr = 0 Then
    ''                                q = art.subtract(ar(j))
    ''                            End If
    ''                            If Not q Is Nothing Then
    ''                                Dim arre() As Area
    ''                                arre = q.ToArray
    ''                                For i As Integer = 0 To UBound(arre)
    ''                                    'If j = 66 Then Stop
    ''                                    Dim nn As Boolean = isgarb(arre(i), j, ar)

    ''                                Next

    ''                            End If


    ''                            Dim dd As New Area
    ''                            If Not q Is Nothing Then
    ''                                If stk.Count = 0 Then
    ''                                    Do While Not q.Count = 0
    ''                                        stk.Push(q.Dequeue)
    ''                                        dd = q.Dequeue
    ''                                        If Not chk1(dd, stk) Then
    ''                                            If Not chk11(dd, stk) Then
    ''                                                stk.Add(dd)
    ''                                            End If
    ''                                        End If


    ''                                    Loop
    ''                                Else
    ''                                    Do While q.Count > 0
    ''                                        arb = q.Dequeue
    ''                                        ans1 = False
    ''                                        q1 = qpush1(q1, arb, ans1)
    ''                                        If Not ans1 Then
    ''                                            If Not chk1(arb, stk) Then
    ''                                                If Not chk11(arb, stk) Then
    ''                                                    stk = UnPush(stk, arb)
    ''                                                End If
    ''                                            End If
    ''                                        End If
    ''                                    Loop

    ''                                End If

    ''                            End If
    ''                            Dim ans2 As Boolean
    ''                            For i As Integer = 0 To stk.Count - 1
    ''                                Dim arx As New Area
    ''                                arx = stk(i)
    ''                                stk = MrgX(stk, arx, ans2)
    ''                                If ans2 Then
    ''                                    Exit For
    ''                                End If


    ''                            Next

    ''                            Dim nn1 As New r1
    ''                            Dim nn As New Area
    ''                            nn.length = ar(j).length
    ''                            nn.width = ar(j).width
    ''                            nn.height = ar(j).height
    ''                            nn.StrtPt.x = ar(j).StrtPt.x
    ''                            nn.StrtPt.y = ar(j).StrtPt.y
    ''                            nn.StrtPt.z = ar(j).StrtPt.z
    ''                            nn1.ar = nn
    ''                            nn1.method = ii
    ''                            nn1.itmnm = ari(j)
    ''                            Dim mmm As New List(Of Area)
    ''                            For kk As Integer = 0 To stk.Count - 1
    ''                                mmm.Add(stk(kk))
    ''                            Next

    ''                            nn1.stk = mmm

    ''                            Bahistarr.Add(nn1)

    ''                            j += 1
    ''                            If j = 400 Then Stop
    ''                        Else
    ''                            q1.Enqueue(art)

    ''                            qpush(q1, art, ans1)
    ''                        End If
    ''lp:

    ''        Loop
    ''        fff()
    ''        Stop

    ''        If j > 0 Then
    ''            e2 = New e1
    ''            e2.qty = itemqty
    ''            e2.itmnm = ari(j - 1)
    ''        End If

    ''        stkj = New List(Of Area)
    ''        For jj As Integer = 0 To stk.Count - 1
    ''            stkj.Add(stk(jj))
    ''        Next
    ''        e2.stk = stkj
    ''        If drawopt Then
    ''            qtyarr.Add(e2)
    ''        End If
    ''        Bmaxqtylst.Add(itemqty)
    ''        Form8.Close()
    ''        If UBound(ar) >= j Then
    ''            fullflag = True
    ''        End If
    ''        MsgBox(itemqty)
    ''        If findqtyflg Then
    ''            stk.Clear()
    ''            For i As Integer = 0 To stk.Count - 1
    ''                If Not chk1(stk2(i), stk) Then
    ''                    If Not chk11(stk2(i), stk) Then
    ''                        stk.Add(stk2(i))
    ''                    End If
    ''                End If
    ''            Next
    ''        End If

    ''        If drawopt Then
    ''            If UBound(ari) <> -1 Then
    ''                tmplst.Add(ari(j - 1))
    ''                tmplst.Add(CStr(totar))
    ''                Bareaarr.Add(tmplst)
    ''            End If
    ''        End If


    ''        If saveopt Then
    ''            saveempty("c:\stuff.mdb", q1, stk, configid)
    ''        End If
    ''        If showempty Then
    ''            showempt(q1, stk)
    ''        End If

    ''        If drawopt Or drawarc Then
    ''            Closef(outfile)
    ''        End If
    ''        qtyflg = True
    ''        conn.Dispose()
    ''        conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\container.mdb;Persist Security Info=False"
    ''        conn.Open()

    ''        Return stk


    ''    End Function

    Public Function stuffQtyMx(ByVal arc As Area, ByVal ar() As Area, ByVal ari() As String, ByVal arwt() As Single, ByVal saveopt As Boolean, ByVal showempty As Boolean, ByVal outfile As String, ByVal drawarc As Boolean, ByVal transparr() As Boolean, ByVal topup() As Boolean, ByVal txtopt As Boolean, ByVal drawopt As Boolean, ByVal findqtyflg As Boolean, ByVal chngflg As Boolean, ByVal colarr As List(Of List(Of Byte))) As List(Of Area)
        'Dim stk As New Stack(Of Area)
        Dim stk2 As New List(Of Area)
        Dim stk1 As New Stack(Of Area)
        Dim art As New Area
        Dim arp As New Area
        Dim are As New Area
        Dim aru As New Area
        Dim arb As New Area
        Dim q As New Queue(Of Area)
        Dim q1 As New Queue(Of Area)
        Dim q2 As New Queue(Of Area)
        Dim ans As Boolean = True
        Dim ans1 As Boolean
        Dim szchg As Integer = 0
        Dim cmd As New OleDb.OleDbCommand
        Dim rdr As OleDb.OleDbDataReader = Nothing
        Dim qtyflg As Boolean = True
        Dim traval As Single
        Dim ard As New Area
        Dim arm As New List(Of Integer)
        Dim arm1 As Integer
        Dim lstm As New List(Of Area)
        Dim a1 As New Area
        Dim a2 As New Area
        Dim ordr As Integer
        Dim totar As Double
        Dim tmplst As New List(Of String)
        Dim answ As MsgBoxResult
        Dim jplus As Integer = 0
        Dim olditemqty As Integer = 0
        Dim col As String
        Dim ii As Integer

        Dim stkj As New List(Of Area)
        'qtyarr.Clear()




        If saveopt Then
            'conn.Open()
            configid = InputBox("Enter Config Id")
        End If
        Dim ptx As New Point
        'ptx.x = arc.length * 1.6
        'ptx.y = arc.width * 1.6
        'ptx.z = arc.height * 0.5
        'ptx.x = arc.length * 1.6
        'ptx.y = arc.width * 0.75
        'ptx.z = arc.height * 1.75
        ptx.x = arc.length
        ptx.y = arc.width
        ptx.z = arc.height
        'If drawopt Or drawarc Then
        'strt(outfile, True, ptx)
        'End If
        'trans(outfile, New String() {CStr(arc.length / 2), CStr(arc.width / 2), CStr(arc.height / 2)})
        'transp(outfile, "0.5", col)
        'placecube(outfile, New String() {CStr(arc.length), CStr(arc.width), CStr(arc.height)})
        Dim col1 As New List(Of Byte)
        col1.Clear()
        col1.Add(255)
        col1.Add(255)
        col1.Add(255)
        col = "1"
        Dim itmnm As String = ""
        If drawarc Then
            Dim ard1 As New Area
            If drawarc Then
                'arc.draw(outfile, col, 0.5, "", itmnm, 0, True, False, "container", 0, True)
            End If
            ard.StrtPt.x = arc.length
            ard.StrtPt.y = 0
            ard.StrtPt.z = 0
            ard.length = 0.5
            ard.width = arc.width
            ard.height = arc.height
            If drawopt Or drawarc Then
                'col1.Clear()
                'col1.Add(255)
                'col1.Add(0)
                'col1.Add(0)
                'ard.draw(outfile, "", 0, "file:///c:\contdoor.png", "", 0, True, False, "door", 0, False)
            End If
            ard1.StrtPt.x = arc.length - 0.01
            ard1.StrtPt.y = 0
            ard1.StrtPt.z = 0
            ard1.length = 0.5
            ard1.width = ard.width
            ard1.height = ard.height
            If drawopt Or drawarc Then
                'ard1.draw(outfile, "b", 0, "file:///c:\contdoor.png", "", 0, True, False, "door1", 0, False)
                col1.Clear()
            End If
            'FileOpen(1, outfile, OpenMode.Append)
            'PrintLine(1, "Shape { ")
            'PrintLine(1, "geometry IndexedFaceSet {")
            'PrintLine(1, "solid TRUE")
            'PrintLine(1, "coord Coordinate {")
            'PrintLine(1, "point [ " & CStr(ard.strtpt.x - 0.01) & " 0 0, " & CStr(ard.strtpt.x - 0.01) & " " & CStr(ard.width) & " 0, " & CStr(ard.strtpt.x - 0.01) & " " & CStr(ard.width) & " " & CStr(ard.height) & ", " & CStr(ard.strtpt.x - 0.01) & " 0 " & CStr(ard.height) & " ]")
            'PrintLine(1, "}")
            'PrintLine(1, "coordIndex [ 0, 1, 2, 3, -1 ]")
            'PrintLine(1, "}}")
            'FileClose(1)







        End If
        If saveopt Then
            cmd.Connection = conn
            'cmd.CommandText = "insert into config (configid,id,strtx,strty,strtz,length,width,height,col,transp,tex) values('" & configid & "','" & CStr(id1) & "',0,0,0," & CStr(arc.length) & "," & CStr(arc.width) & "," & CStr(arc.height) & ",'" & col & "',0.5,'')"
y:
            Try
                cmd.ExecuteNonQuery()
            Catch ec As Exception
                If ec.Message = "Cannot open any more tables." Then
                    conn.Close()
                    conn.Dispose()
                    OleDb.OleDbConnection.ReleaseObjectPool()
                    cmd.Dispose()
                    GC.Collect()

                    'conn = Nothing
                    'conn = New OleDb.OleDbConnection
                    conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\container.mdb;Persist Security Info=False"

                    conn.Open()
                    GoTo y
                End If

            End Try
            id1 += 1
        End If

        'trans(outfile, New String() {CStr(-arc.length / 2), CStr(-arc.width / 2), CStr(-arc.height / 2)})

        'texture(outfile, "file:///c:/t2.png")

        arc.StrtPt.x = 0
        arc.StrtPt.y = 0
        arc.StrtPt.z = 0

        'stk.Add(arc)

        Dim j As Integer = 0
        totar = 0
        Bareaarr.Clear()
        For i As Integer = 0 To stk.Count - 1
            stk2.Add(stk(i))
        Next
        itemqty = 0
        Btotwt = 0
        If Not IsNothing(ari) Then
            Form8.Show()
            If drawopt Then
                Form8.Button1.Visible = False
            End If
            Form8.Focus()
        End If

        For i As Integer = 0 To Bqtylst.Count - 1
            Bplclst.Add(Bqtylst(i) - 1)
        Next
        'itemno = 0
        fullflag = False
        olditemqty = 0
        Dim imgname As String = "1"
        Do While Not stk.Count = 0 And j <= UBound(ar)
            'If j = 172 Then Stop
            If j > 0 Then
                If ari(j) <> ari(j - 1) Then
                    imgname = (CInt(imgname) + 1).ToString
                End If
            End If
            'If j = 225 Then Stop
            'If LCase(ari(j)) = "item03" Then Stop
            ordr = 0
            'If j = 86 Then Stop
            'If j = 307 Then Stop
            'If j = 20 Then Stop
            'Dim qx As New Queue(Of Area)
            'For i As Integer = 0 To stk.Count - 1
            '    qx.Enqueue(stk(i))
            'Next


            'For i As Integer = 0 To stk.Count - 1
            '    arb = stk(i)
            '    stk = unpush(stk, arb)
            'Next




            'If j = 40 Then Stop
            'If ari(j) = "A18" Then Stop
            'If j = 6 Then Stop
            'col = colarr(j)
            If chkwt Then
                Btotwt += arwt(j)
                If Btotwt >= contcap Then

                    answ = MsgBox("Maximum weight capacity of the container is reached" & vbCrLf & "Do you want to proceed?", MsgBoxStyle.YesNo)
                    If answ = MsgBoxResult.No Then
                        fullflag = True
                        'j = UBound(ar) + 1
                        Exit Do
                        'GoTo lp
                    Else
                        fullflag = False
                        'j = UBound(ar) + 1
                        chkwt = False
                    End If

                End If
            End If

            If j = 0 Then
                col = Bstrtclr

                'putcol(outfile, col)
            End If
            'If ari(j) = "ITEM06" Then Stop




            If j > 0 And Not IsNothing(ari) Then
                If ari(j - 1) <> ari(j) Then
                    e2 = New e1
                    e2.qty = itemqty
                    e2.itmnm = ari(j - 1)
                    stkj = New List(Of Area)
                    For jj As Integer = 0 To stk.Count - 1
                        stkj.Add(stk(jj))
                    Next
                    e2.stk = stkj
                    If drawopt Then
                        qtyarr.Add(e2)
                    End If
                    If Bqtylst.Count > 0 Then
                        'plclst(itemno) = itemqty - 1
                        'plclst(itemno + 1) = plclst(itemno + 1) + 1
                    End If

                    Bmaxqtylst.Add(itemqty)
                    'itemno += 1


                    Form8.Label1.Text = "Stuffing item:" & ari(j)
                    Form8.Label1.Refresh()
                Else
                    'itemno += 1
                    Form8.Label1.Text = "Stuffing item:" & ari(j)
                    Form8.Label1.Refresh()
                End If
            Else
                If j > 0 Then
                    Form8.Show()
                    If drawopt Then
                        Form8.Button1.Visible = False
                    End If
                    Form8.Label1.Text = "Finding Maximum Quantity...."
                    Form8.Label1.Refresh()
                End If
            End If




            If drawopt Then
                If j > 0 Then
                    'If ar(j - 1).length <> ar(j).length Or ar(j - 1).width <> ar(j).width Or ar(j - 1).height <> ar(j).height Then
                    If ari(j - 1) <> ari(j) Then
                        'MsgBox(itemqty)
                        itemqty = 0
                        'totwt = 0
                        If col = "r" Then
                            col = "g"
                        ElseIf col = "g" Then
                            col = "b"
                        ElseIf col = "b" Then
                            col = "m"
                        ElseIf col = "m" Then
                            col = "c"
                        ElseIf col = "c" Then
                            col = "y"
                        End If
                        'putcol(outfile, col)
                        szchg += 1
                        qtyflg = True

                    Else
                        qtyflg = False
                    End If
                End If
            End If

            If szchg <> 2 Then
                'transp(outfile, 0.5, "1")
                'putcol(outfile, col)
            Else
                'putcol(outfile, col)
            End If



            'If j = 13 Then
            'closef(outfile)
            'Process.Start(outfile)
            'Stop
            'End If
            'q1 = q1draw(q1, ar(j), ari(j), arwt(j), ans, True, outfile, qtyflg, transparr(j))
            'If ans Then
            'j += 1
            'GoTo lp
            'End If
            arm1 = findopt(stk, ar(j), topup(j))
            art = Nothing
            If arm1 <> -1 Then
                art = stk(arm1)


            End If

            'Dim aru1 As New List(Of Integer)
            'aru1 = findaru1(stk, ar(j), topup(j))


            Dim arn As New List(Of Integer)
            Dim lstn As New List(Of Area)
            Dim b1 As New Area
            Dim b2 As New Area
            Dim pos1 As Integer
            arm = Nothing
            arn = Nothing
            'If j = 16 Then Stop
            arn = findcandidate1(stk, ar(j), topup(j))
            pos1 = 0
            If Not arn Is Nothing Then
                pos1 = 0
            Else
                Dim arxx As New Area
                arxx.length = ar(j).width
                arxx.width = ar(j).length
                arxx.height = ar(j).height
                arn = findcandidate1(stk, arxx, topup(j))
                If Not arn Is Nothing Then
                    pos1 = 1
                Else
                    If Not topup(j) Then
                        arxx.length = ar(j).length
                        arxx.width = ar(j).height
                        arxx.height = ar(j).width
                        arn = findcandidate1(stk, arxx, False)
                        If Not arn Is Nothing Then
                            pos1 = 2
                        End If
                    End If
                End If
            End If
            If arn Is Nothing Then
                arm = findcandidate(stk, ar(j))
                If Not arm Is Nothing Then
                    If arm(0) = arm1 Then arm = Nothing
                End If
            End If
            If Not arm Is Nothing Then
                lstm = unionp(stk(arm(0)), stk(arm(1)))
                a1 = lstm(0)
                a2 = lstm(1)
            End If

            If Not arn Is Nothing Then

                lstm = unionp(stk(arn(0)), stk(arn(1)))
                b1 = lstm(0)
                b2 = lstm(1)
            End If

            'art = findopt(stk, ar(j))

            If arm Is Nothing And arm1 = -1 Then
                If drawopt Then
                    'closef(outfile)
                    'clsflg = True
                End If
                'If drawopt Then
                'plclst(itemno) = plclst(itemno) - 1
                'End If

                For m As Integer = j To UBound(ari) - 1
                    If ari(m) <> ari(j) Then
                        j = m
                        'Exit Do
                        GoTo lp
                        'Exit For
                    End If
                Next
                j = UBound(ari) + 1
                'maxqtylst.Add(itemqty)
                GoTo lp
                'Return stk
            Else
                If arn Is Nothing And arm1 = -1 Then
                    If drawopt Then
                        'closef(outfile)
                        'clsflg = True 
                    End If
                    'If drawopt Then
                    'plclst(plclst.Count - 1) = plclst(plclst.Count - 1) - 1
                    'End If

                    For m As Integer = j To UBound(ari) - 1
                        If ari(m) <> ari(j) Then
                            j = m
                            GoTo lp
                            'Exit Do
                            'Exit For
                        End If
                    Next
                    j = UBound(ari)
                    'maxqtylst.Add(itemqty)
                    'GoTo lp
                    'Return stk

                End If
            End If


            If Not arm Is Nothing Or Not arn Is Nothing Then
                'If Not arm Is Nothing Then
                cmd.Connection = conn
                'cmd.CommandText = "delete from temp2"
                DelTab("temp2")
z:
                'Try
                '    cmd.ExecuteNonQuery()
                'Catch ec As Exception
                '    If ec.Message = "Cannot open any more tables." Then
                '        conn.Close()
                '        conn.Dispose()
                '        OleDb.OleDbConnection.ReleaseObjectPool()
                '        cmd.Dispose()
                '        GC.Collect()

                '        'conn = Nothing
                '        'conn = New OleDb.OleDbConnection
                '        conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\container.mdb;Persist Security Info=False"

                '        conn.Open()
                '        GoTo z
                '    End If

                'End Try
                ordr = 0
                If Not arm Is Nothing Then
                    'dim aa as New Object()  { CStr(a1.strtpt.x), CStr(a1.strtpt.y), CStr(a1.strtpt.z), CStr(1)}
                    'cmd.CommandText = "insert into temp2 values(" & CStr(a1.strtpt.x) & "," & CStr(a1.strtpt.y) & "," & CStr(a1.strtpt.z) & "," & CStr(1) & ")"
                    instab("temp2", New Object() {CStr(a1.StrtPt.x), CStr(a1.StrtPt.y), CStr(a1.StrtPt.z), CStr(1)})
                    'w:
                    '                    Try
                    '                        cmd.ExecuteNonQuery()
                    '                    Catch ec As Exception
                    '                        If ec.Message = "Cannot open any more tables." Then
                    '                            conn.Close()
                    '                            conn.Dispose()
                    '                            OleDb.OleDbConnection.ReleaseObjectPool()
                    '                            cmd.Dispose()
                    '                            GC.Collect()
                    '                            'conn = Nothing
                    '                            'conn = New OleDb.OleDbConnection
                    '                            conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\container.mdb;Persist Security Info=False"

                    '                            conn.Open()
                    '                            GoTo w
                    '                        End If

                    '                    End Try
                    'arm = Nothing
                End If

                If Not arn Is Nothing Then
                    instab("temp2", New Object() {CStr(b1.StrtPt.x), CStr(b1.StrtPt.y), CStr(b1.StrtPt.z), CStr(2)})
                    '                    cmd.CommandText = "insert into temp2 values(" & CStr(b1.strtpt.x) & "," & CStr(b1.strtpt.y) & "," & CStr(b1.strtpt.z) & "," & CStr(2) & ")"
                    'a:
                    '                    Try
                    '                        cmd.ExecuteNonQuery()
                    '                    Catch ec As Exception
                    '                        If ec.Message = "Cannot open any more tables." Then
                    '                            conn.Close()
                    '                            conn.Dispose()
                    '                            OleDb.OleDbConnection.ReleaseObjectPool()
                    '                            cmd.Dispose()
                    '                            GC.Collect()

                    '                            'conn = Nothing
                    '                            'conn = New OleDb.OleDbConnection
                    '                            conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\container.mdb;Persist Security Info=False"

                    '                            conn.Open()
                    '                            GoTo a
                    '                        End If

                    '                    End Try
                    'arn = Nothing
                End If

                If Not art Is Nothing Then
                    instab("temp2", New Object() {CStr(art.StrtPt.x), CStr(art.StrtPt.y), CStr(art.StrtPt.z), CStr(3)})
                    '                    cmd.CommandText = "insert into temp2 values(" & CStr(art.strtpt.x) & "," & CStr(art.strtpt.y) & "," & CStr(art.strtpt.z) & "," & CStr(3) & ")"
                    'b:
                    '                    Try
                    '                        cmd.ExecuteNonQuery()
                    '                    Catch ec As Exception
                    '                        If ec.Message = "Cannot open any more tables." Then
                    '                            conn.Close()
                    '                            conn.Dispose()
                    '                                   leDbConnection.ReleaseObjectPool()
                    '                            cmd.Dispose()
                    '                            GC.Collect()
                    '                            'conn = Nothing
                    '                            'conn = New OleDb.OleDbConnection
                    '                            conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\container.mdb;Persist Security Info=False"

                    '                            conn.Open()
                    '                            GoTo b
                    '                        End If

                    '                    End Try
                End If

                'cmd.CommandText = "select * from temp2 order by z desc ,x asc,y asc"
                Dim rwx As DataRow() = Nothing
                If Not arm Is Nothing Then
                    'cmd.CommandText = "select * from temp2 order by z desc ,x asc,y asc"
                    rwx = getf("temp2", "", "z DESC ,x ASC,y ASC")
                End If

                If Not arn Is Nothing Then
                    'cmd.CommandText = "select * from temp2 order by z desc ,x asc,y asc"
                    rwx = getf("temp2", "", "z DESC ,x ASC,y ASC")
                End If

                If arn Is Nothing And arm Is Nothing Then
                    'cmd.CommandText = "select * from temp2 order by z desc, x asc"
                    rwx = getf("temp2", "", "z DESC ,x ASC")
                End If

                If arm Is Nothing And arn Is Nothing Then
                    'cmd.CommandText = "select * from temp2 order by z desc ,x asc,y asc"
                    rwx = getf("temp2", "", "z DESC ,x ASC,y ASC")
                End If
                'Try
                'rdr = cmd.ExecuteReader
                'Catch
                'conn.Dispose()
                'conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\container.mdb;Persist Security Info=False"
                'conn.Open()
                'rdr = cmd.ExecuteReader
                'End Try
                'rdr.Read()
                'ordr = rdr.Item("i")
                'rdr.Close()
                'attention
                ordr = rwx(0)("i")

                If ordr = 3 Then
                    stk.RemoveAt(arm1)
                Else
                    If ordr = 1 Then
                        art = a1
                        stk.RemoveAt(arm(0))
                        If arm(0) < arm(1) Then
                            stk.RemoveAt(arm(1) - 1)
                        Else
                            stk.RemoveAt(arm(1))
                        End If
                        'If Not chk1(a2, stk) Then
                        'unpush(stk, a2)
                        'stk.Add(a2)
                        stk = UnPush(stk, a2)
                        'End If
                    End If
                    If ordr = 2 Then
                        If pos1 = 1 Then
                            Dim tmp As Double = ar(j).width
                            ar(j).width = ar(j).length
                            ar(j).length = tmp
                        End If

                        If pos1 = 2 Then
                            Dim tmp As Double = ar(j).height
                            ar(j).height = ar(j).width
                            ar(j).width = tmp
                        End If


                        art = b1
                        stk.RemoveAt(arn(0))
                        If arn(0) < arn(1) Then
                            stk.RemoveAt(arn(1) - 1)
                        Else
                            stk.RemoveAt(arn(1))
                        End If
                        'If Not chk1(b2, stk) Then
                        stk.Add(b2)
                        'End If
                    End If
                    If ordr = 3 Then
                        stk.RemoveAt(arm1)
                    End If
                End If
            Else
                'art = stk(arm1)
                If arm1 <> -1 Then
                    stk.RemoveAt(arm1)
                End If
            End If

            'attention start

            Dim qty As Integer
            If chngflg Then
                ii = FindOptMethod(ar(j), art, qty, topup(j))
                If Occ > 1 Then
                    Dim occlst1 As New List(Of Integer)
                    For i As Integer = 0 To OccLst.Count - 1
                        occlst1.Add(OccLst(i))
                    Next
                    Dim mmm1 As New occ1
                    mmm1.j = j
                    mmm1.j1 = occlst1
                    mmm1.stk = stk
                    OptLst.Add(mmm1)
                End If
                Dim ln As Double = ar(j).length
                Dim wd As Double = ar(j).width
                Dim ht As Double = ar(j).height

                'For p As Integer = j To j + qty

                Dim nm As String = ari(j)
                Dim p As Integer = j


                'Do While Not p >= UBound(ari) - 1 AndAlso ari(p) <> ari(p + 1)
                If ii = 1 Then
                    'Exit Do
                End If

                If ii = 2 Then
                    ar(p).length = ln
                    ar(p).width = ht
                    ar(p).height = wd
                    'Exit Do
                End If

                If ii = 3 Then
                    ar(p).length = wd
                    ar(p).width = ht
                    ar(p).height = ln
                    'Exit Do
                End If

                If ii = 4 Then
                    ar(p).length = wd
                    ar(p).width = ln
                    ar(p).height = ht
                    'Exit Do
                End If

                If ii = 5 Then
                    ar(p).length = ht
                    ar(p).width = wd
                    ar(p).height = ln
                    'Exit Do
                End If

                If ii = 6 Then
                    ar(p).length = ht
                    ar(p).width = ln
                    ar(p).height = wd
                    'Exit Do
                End If

                'p += 1
                'Loop

                'Next




            End If

            Dim flg As Boolean = Math.Abs(((ar(j).length * ar(j).width * ar(j).height) * qty) - (art.length * art.width * art.height)) < 0.01
            Dim mm As Integer = findqty(ari, j)
            'If j = 6 Then Stop
            If mm >= qty And flg Then
                Stop
                If drawopt Then
                    If transparr(j) Then
                        traval = 0.8
                    Else
                        traval = 0
                    End If
                    ar(j).StrtPt.x = art.StrtPt.x
                    ar(j).StrtPt.y = art.StrtPt.y
                    ar(j).StrtPt.z = art.StrtPt.z
                    ar(j).draw(outfile, col, traval, "file:///c:/t2.png", ari(j), arwt(j), qtyflg, txtopt, "", 0, True, "c")
                    'drwopt(art, ar(j), outfile, col, traval, ari(j), arwt(j), qtyflg, txtopt)

                    j += qty
                    itemqty += qty
                Else
                    j += qty

                    itemqty += qty
                    Bplclst(itemno) = itemqty
                    Btotwt += arwt(j)
                    GoTo lp
                End If

            End If


            'attention end

            'art = stk.Pop
            'If Form4.ftip(art, ar(j)) Then
            'If art.length >= ar(j).length AndAlso art.width >= ar(j).width AndAlso art.height >= ar(j).height Then
            arm = Nothing
            arn = Nothing
            ar(j).StrtPt.x = art.StrtPt.x

            ar(j).StrtPt.y = art.StrtPt.y
            ar(j).StrtPt.z = art.StrtPt.z
            'trans(outfile, New String() {CStr(art.strtpt.x), CStr(art.strtpt.y), CStr(art.strtpt.z)})
            'trans(outfile, New String() {CStr(ar(j).length / 2), CStr(ar(j).width / 2), CStr(ar(j).height / 2)})
            'placecube(outfile, New String() {CStr(ar(j).length), CStr(ar(j).width), CStr(ar(j).height)})

            If saveopt Then
                'Da.InsertCommand.CommandText = "insert into config (configid,id,strtx,strty,strtz,length,width,height,col,transp,tex) values('" & configid & "','" & CStr(id1) & "'," & CStr(art.strtpt.x) & "," & CStr(art.strtpt.y) & "," & art.strtpt.z & "," & CStr(ar(j).length) & "," & CStr(ar(j).width) & "," & CStr(ar(j).height) & ",'" & col & "',0,'')"
                'Da.InsertCommand.ExecuteNonQuery()
                'cmd.CommandText = "insert into config (configid,id,strtx,strty,strtz,length,width,height,col,transp,tex) values('" & configid & "','" & CStr(id1) & "'," & CStr(art.strtpt.x) & "," & CStr(art.strtpt.y) & "," & art.strtpt.z & "," & CStr(ar(j).length) & "," & CStr(ar(j).width) & "," & CStr(ar(j).height) & ",'" & col & "',0,'')"
m:
                Try
                    cmd.ExecuteNonQuery()
                Catch ec As Exception
                    If ec.Message = "Cannot open any more tables." Then
                        conn.Close()
                        conn.Dispose()
                        OleDb.OleDbConnection.ReleaseObjectPool()
                        cmd.Dispose()
                        GC.Collect()

                        'conn = Nothing
                        'conn = New OleDb.OleDbConnection
                        conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\container.mdb;Persist Security Info=False"

                        conn.Open()
                        GoTo m
                    End If

                End Try
                id1 += 1
            End If

            'trans(outfile, New String() {CStr(-art.strtpt.x), CStr(-art.strtpt.y), CStr(-art.strtpt.z)})
            'trans(outfile, New String() {CStr(-ar(j).length / 2), CStr(-ar(j).width / 2), CStr(-ar(j).height / 2)})

            If drawopt Then

                If transparr(j) Then
                    traval = 0.8
                Else
                    traval = 0
                End If
            End If
            If j = UBound(ar) Then
                'Stop
            End If
            If drawopt Then
                If j <> 0 Then
                    If ari(j) <> ari(j - 1) Then
                        tmplst.Add(ari(j - 1))
                        tmplst.Add(CStr(totar))
                        Bareaarr.Add(tmplst)
                        totar = 0
                        totar = totar + (ar(j).length * ar(j).width * ar(j).height)
                    Else
                        totar = totar + (ar(j).length * ar(j).width * ar(j).height)
                    End If
                Else
                    totar = totar + (ar(j).length * ar(j).width * ar(j).height)
                End If
            End If
            If drawopt Then
                txtopt = True
                ar(j).draw(outfile, col, traval, "file:///c:/s" & imgname & ".png", ari(j), arwt(j), qtyflg, txtopt, ari(j), ii, True, "b")
                If Bqtylst.Count > 0 Then
                    Bplclst(rwidx) = itemqty

                End If


                itemqty += 1

            Else
                itemqty += 1
                Btotwt += arwt(j)
            End If
            If Bqtylst.Count > 1 Then
                Bplclst(rwidx) = itemqty - 1
                Bmaxqtylst.Add(itemqty - 1)
            End If
            If Not IsNothing(ari) Then
                Form8.i = itemqty
                Form8.Label2.Text = CStr(itemqty) & " items stuffed"
                Form8.Label2.Refresh()
                System.Windows.Forms.Application.DoEvents()
                If exflg Then
                    exflg = False
                    GoTo lp
                End If
            End If
            'If ordr = 3 OrElse ordr = 0 Then
            q = art.subtract(ar(j))
            'End If
            'If Not q Is Nothing Then
            '    Dim arre() As Area
            '    arre = q.ToArray
            '    For i As Integer = 0 To UBound(arre)
            '        'If j = 66 Then Stop
            '        Dim nn As Boolean = isgarb(arre(i), j, ar)

            '    Next

            'End If


            Dim dd As New Area
            If Not q Is Nothing Then
                If stk.Count = 0 Then
                    Do While Not q.Count = 0
                        'stk.Push(q.Dequeue)
                        dd = q.Dequeue
                        'If Not chk1(dd, stk) Then
                        'If Not chk11(dd, stk) Then
                        stk.Add(dd)
                        'End If
                        'End If


                    Loop
                Else
                    Do While q.Count > 0
                        arb = q.Dequeue
                        ans1 = False
                        'q1 = qpush1(q1, arb, ans1)
                        'If Not ans1 Then
                        'If Not chk1(arb, stk) Then
                        'If Not chk11(arb, stk) Then
                        stk = UnPush(stk, arb)
                        'End If
                        'End If
                        'End If
                    Loop

                End If

            End If
            Dim ans2 As Boolean
            For i As Integer = 0 To stk.Count - 1
                Dim arx As New Area
                arx = stk(i)
                stk = MrgX(stk, arx, ans2)
                If ans2 Then
                    Exit For
                End If


            Next

            Dim nn1 As New r1
            Dim nn As New Area
            nn.length = ar(j).length
            nn.width = ar(j).width
            nn.height = ar(j).height
            nn.StrtPt.x = ar(j).StrtPt.x
            nn.StrtPt.y = ar(j).StrtPt.y
            nn.StrtPt.z = ar(j).StrtPt.z
            nn1.ar = nn
            nn1.method = ii
            nn1.itmnm = ari(j)
            Dim mmm As New List(Of Area)
            For kk As Integer = 0 To stk.Count - 1
                mmm.Add(stk(kk))
            Next

            nn1.stk = mmm

            Bahistarr.Add(nn1)

            j += 1
            'If j = 400 Then Stop
            'Else
            'q1.Enqueue(art)

            'qpush(q1, art, ans1)
            'End If
lp:

        Loop
        fff()
        'Stop

        If j > 0 Then
            e2 = New e1
            e2.qty = itemqty
            e2.itmnm = ari(j - 1)
        End If

        stkj = New List(Of Area)
        For jj As Integer = 0 To stk.Count - 1
            stkj.Add(stk(jj))
        Next
        e2.stk = stkj
        If drawopt Then
            qtyarr.Add(e2)
        End If
        Bmaxqtylst.Add(itemqty)
        Form8.Close()
        If UBound(ar) >= j Then
            fullflag = True
        End If
        'MsgBox(itemqty)
        If findqtyflg Then
            stk.Clear()
            For i As Integer = 0 To stk.Count - 1
                If Not chk1(stk2(i), stk) Then
                    If Not chk11(stk2(i), stk) Then
                        stk.Add(stk2(i))
                    End If
                End If
            Next
        End If

        If drawopt Then
            If UBound(ari) <> -1 Then
                tmplst.Add(ari(j - 1))
                tmplst.Add(CStr(totar))
                Bareaarr.Add(tmplst)
            End If
        End If


        'If saveopt Then
        'saveempty("c:\stuff.mdb", q1, stk, configid)
        'End If
        'If showempty Then
        'showempt(q1, stk)
        'End If

        If drawopt Or drawarc Then
            'closef(outfile)
        End If
        qtyflg = True
        conn.Dispose()
        conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\container.mdb;Persist Security Info=False"
        conn.Open()

        Return stk


    End Function

    Public Function stuff(ByVal arc As Area, ByVal ar() As Area, ByVal ari() As String, ByVal arwt() As Single, ByVal saveopt As Boolean, ByVal showempty As Boolean, ByVal outfile As String, ByVal drawarc As Boolean, ByVal transparr() As Boolean, ByVal topup() As Boolean, ByVal txtopt As Boolean, ByVal drawopt As Boolean, ByVal findqtyflg As Boolean, ByVal chngflg As Boolean, ByVal colarr As List(Of List(Of Byte))) As List(Of Area)

        'stk.Clear()

        'Dim stk As New Stack(Of Area)
        Dim stk2 As New List(Of Area)
        Dim stk1 As New Stack(Of Area)
        Dim art As New Area
        Dim arp As New Area
        Dim are As New Area
        Dim aru As New Area
        Dim arb As New Area
        Dim q As New Queue(Of Area)
        Dim q1 As New Queue(Of Area)
        Dim q2 As New Queue(Of Area)
        Dim ans As Boolean = True
        Dim ans1 As Boolean
        Dim szchg As Integer = 0
        Dim cmd As New OleDb.OleDbCommand
        Dim rdr As OleDb.OleDbDataReader = Nothing
        Dim qtyflg As Boolean = True
        Dim traval As Single
        Dim ard As New Area
        Dim arm As New List(Of Integer)
        Dim arm1 As Integer
        Dim lstm As New List(Of Area)
        Dim a1 As New Area
        Dim a2 As New Area
        Dim ordr As Integer
        Dim totar As Double
        Dim tmplst As New List(Of String)
        Dim answ As MsgBoxResult
        Dim jplus As Integer = 0
        Dim olditemqty As Integer = 0
        Dim col As String
        Dim ii As Integer

        Dim stkj As New List(Of Area)
        'qtyarr.Clear()

        If saveopt Then
            'conn.Open()
            configid = InputBox("Enter Config Id")
        End If
        Dim ptx As New point
        'ptx.x = arc.length * 1.6
        'ptx.y = arc.width * 1.6
        'ptx.z = arc.height * 0.5
        'ptx.x = arc.length * 1.6
        'ptx.y = arc.width * 0.75
        'ptx.z = arc.height * 1.75
        ptx.x = arc.length
        ptx.y = arc.width
        ptx.z = arc.height
        'If drawopt Or drawarc Then
        'strt(outfile, True, ptx)
        'End If
        'trans(outfile, New String() {CStr(arc.length / 2), CStr(arc.width / 2), CStr(arc.height / 2)})
        'transp(outfile, "0.5", col)
        'placecube(outfile, New String() {CStr(arc.length), CStr(arc.width), CStr(arc.height)})
        Dim col1 As New List(Of Byte)
        col1.Clear()
        col1.Add(255)
        col1.Add(255)
        col1.Add(255)
        col = "1"
        Dim itmnm As String = ""
        If drawarc Then
            Dim ard1 As New Area
            If drawarc Then
                'arc.draw(outfile, col, 0.5, "", itmnm, 0, True, False, "container", 0, True)
            End If
            ard.strtpt.x = arc.length
            ard.strtpt.y = 0
            ard.strtpt.z = 0
            ard.length = 0.5
            ard.width = arc.width
            ard.height = arc.height
            If drawopt Or drawarc Then
                'col1.Clear()
                'col1.Add(255)
                'col1.Add(0)
                'col1.Add(0)
                'ard.draw(outfile, "", 0, "file:///c:\contdoor.png", "", 0, True, False, "door", 0, False)
            End If
            ard1.strtpt.x = arc.length - 0.01
            ard1.strtpt.y = 0
            ard1.strtpt.z = 0
            ard1.length = 0.5
            ard1.width = ard.width
            ard1.height = ard.height
            If drawopt Or drawarc Then
                'ard1.draw(outfile, "b", 0, "file:///c:\contdoor.png", "", 0, True, False, "door1", 0, False)
                col1.Clear()
            End If
            'FileOpen(1, outfile, OpenMode.Append)
            'PrintLine(1, "Shape { ")
            'PrintLine(1, "geometry IndexedFaceSet {")
            'PrintLine(1, "solid TRUE")
            'PrintLine(1, "coord Coordinate {")
            'PrintLine(1, "point [ " & CStr(ard.strtpt.x - 0.01) & " 0 0, " & CStr(ard.strtpt.x - 0.01) & " " & CStr(ard.width) & " 0, " & CStr(ard.strtpt.x - 0.01) & " " & CStr(ard.width) & " " & CStr(ard.height) & ", " & CStr(ard.strtpt.x - 0.01) & " 0 " & CStr(ard.height) & " ]")
            'PrintLine(1, "}")
            'PrintLine(1, "coordIndex [ 0, 1, 2, 3, -1 ]")
            'PrintLine(1, "}}")
            'FileClose(1)

        End If
        If saveopt Then
            cmd.Connection = conn
            'cmd.CommandText = "insert into config (configid,id,strtx,strty,strtz,length,width,height,col,transp,tex) values('" & configid & "','" & CStr(id1) & "',0,0,0," & CStr(arc.length) & "," & CStr(arc.width) & "," & CStr(arc.height) & ",'" & col & "',0.5,'')"
y:
            Try
                cmd.ExecuteNonQuery()
            Catch ec As Exception
                If ec.Message = "Cannot open any more tables." Then
                    conn.Close()
                    conn.Dispose()
                    OleDb.OleDbConnection.ReleaseObjectPool()
                    cmd.Dispose()
                    GC.Collect()

                    'conn = Nothing
                    'conn = New OleDb.OleDbConnection
                    conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\container.mdb;Persist Security Info=False"

                    conn.Open()
                    GoTo y
                End If

            End Try
            id1 += 1
        End If

        'trans(outfile, New String() {CStr(-arc.length / 2), CStr(-arc.width / 2), CStr(-arc.height / 2)})

        'texture(outfile, "file:///c:/t2.png")

        arc.strtpt.x = 0
        arc.strtpt.y = 0
        arc.strtpt.z = 0

        'stk.Add(arc)

        Dim j As Integer = 0 '' shailesh
        totar = 0
        areaarr.Clear()
        For i As Integer = 0 To stk.Count - 1
            stk2.Add(stk(i))
        Next
        itemqty = 0
        totwt = 0
        If Not IsNothing(ari) Then
            Form8.Show()
            If drawopt Then
                Form8.Button1.Visible = False
            End If
            Form8.Focus()
        End If

        For i As Integer = 0 To qtylst.Count - 1
            plclst.Add(qtylst(i) - 1)
        Next
        'itemno = 0
        fullflag = False
        olditemqty = 0
        Dim imgname As String = "1"
        Do While Not stk.Count = 0 And j <= UBound(ar)

            'If j = 172 Then Stop
            If j > 0 Then
                If ari(j) <> ari(j - 1) Then
                    imgname = (CInt(imgname) + 1).ToString
                End If
            End If
            'If j = 225 Then Stop
            'If LCase(ari(j)) = "item03" Then Stop
            ordr = 0
            'If j = 86 Then Stop
            'If j = 307 Then Stop
            'If j = 20 Then Stop
            'Dim qx As New Queue(Of Area)
            'For i As Integer = 0 To stk.Count - 1
            '    qx.Enqueue(stk(i))
            'Next


            'For i As Integer = 0 To stk.Count - 1
            '    arb = stk(i)
            '    stk = unpush(stk, arb)
            'Next

            'If j = 40 Then Stop
            'If ari(j) = "A18" Then Stop
            'If j = 6 Then Stop
            'col = colarr(j)
            If chkwt Then
                totwt += arwt(j)
                If totwt >= contcap Then

                    answ = MsgBox("Maximum weight capacity of the container is reached" & vbCrLf & "Do you want to proceed?", MsgBoxStyle.YesNo)
                    If answ = MsgBoxResult.No Then
                        fullflag = True
                        'j = UBound(ar) + 1
                        Exit Do
                        'GoTo lp
                    Else
                        fullflag = False
                        'j = UBound(ar) + 1
                        chkwt = False
                    End If

                End If
            End If

            If j = 0 Then
                col = strtclr

                'putcol(outfile, col)
            End If
            'If ari(j) = "ITEM06" Then Stop


            If j > 0 And Not IsNothing(ari) Then
                If ari(j - 1) <> ari(j) Then
                    e2 = New e1
                    e2.qty = itemqty
                    e2.itmnm = ari(j - 1)
                    stkj = New List(Of Area)
                    For jj As Integer = 0 To stk.Count - 1
                        stkj.Add(stk(jj))
                    Next
                    e2.stk = stkj
                    If drawopt Then
                        qtyarr.Add(e2)
                    End If
                    If qtylst.Count > 0 Then
                        'plclst(itemno) = itemqty - 1
                        'plclst(itemno + 1) = plclst(itemno + 1) + 1
                    End If

                    maxqtylst.Add(itemqty)
                    'itemno += 1

                    Form8.Label1.Text = "Stuffing item:" & ari(j)
                    Form8.Label1.Refresh()
                Else
                    'itemno += 1
                    Form8.Label1.Text = "Stuffing item:" & ari(j)
                    Form8.Label1.Refresh()
                End If
            Else
                If j > 0 Then
                    Form8.Show()
                    If drawopt Then
                        Form8.Button1.Visible = False
                    End If
                    Form8.Label1.Text = "Finding Maximum Quantity...."
                    Form8.Label1.Refresh()
                End If
            End If

            If drawopt Then
                If j > 0 Then
                    'If ar(j - 1).length <> ar(j).length Or ar(j - 1).width <> ar(j).width Or ar(j - 1).height <> ar(j).height Then
                    If ari(j - 1) <> ari(j) Then
                        'MsgBox(itemqty)
                        itemqty = 0
                        'totwt = 0
                        If col = "r" Then
                            col = "g"
                        ElseIf col = "g" Then
                            col = "b"
                        ElseIf col = "b" Then
                            col = "m"
                        ElseIf col = "m" Then
                            col = "c"
                        ElseIf col = "c" Then
                            col = "y"
                        End If
                        'putcol(outfile, col)
                        szchg += 1
                        qtyflg = True

                    Else
                        qtyflg = False
                    End If
                End If
            End If

            If szchg <> 2 Then
                'transp(outfile, 0.5, "1")
                'putcol(outfile, col)
            Else
                'putcol(outfile, col)
            End If

            'If j = 13 Then
            'closef(outfile)
            'Process.Start(outfile)
            'Stop
            'End If
            'q1 = q1draw(q1, ar(j), ari(j), arwt(j), ans, True, outfile, qtyflg, transparr(j))
            'If ans Then
            'j += 1
            'GoTo lp
            'End If
            arm1 = findopt(stk, ar(j), topup(j))
            art = Nothing
            If arm1 <> -1 Then
                art = stk(arm1)
            End If

            'Dim aru1 As New List(Of Integer)
            'aru1 = findaru1(stk, ar(j), topup(j))

            Dim arn As New List(Of Integer)
            Dim lstn As New List(Of Area)
            Dim b1 As New Area
            Dim b2 As New Area
            Dim pos1 As Integer
            arm = Nothing
            arn = Nothing
            'If j = 16 Then Stop
            arn = findcandidate1(stk, ar(j), topup(j))
            pos1 = 0
            If Not arn Is Nothing Then
                pos1 = 0
            Else
                Dim arxx As New Area
                arxx.length = ar(j).width
                arxx.width = ar(j).length
                arxx.height = ar(j).height
                arn = findcandidate1(stk, arxx, topup(j))
                If Not arn Is Nothing Then
                    pos1 = 1
                Else
                    If Not topup(j) Then
                        arxx.length = ar(j).length
                        arxx.width = ar(j).height
                        arxx.height = ar(j).width
                        arn = findcandidate1(stk, arxx, False)
                        If Not arn Is Nothing Then
                            pos1 = 2
                        End If
                    End If
                End If
            End If
            If arn Is Nothing Then
                arm = findcandidate(stk, ar(j))
                If Not arm Is Nothing Then
                    If arm(0) = arm1 Then arm = Nothing
                End If
            End If
            If Not arm Is Nothing Then
                lstm = unionp(stk(arm(0)), stk(arm(1)))
                a1 = lstm(0)
                a2 = lstm(1)
            End If

            If Not arn Is Nothing Then

                lstm = unionp(stk(arn(0)), stk(arn(1)))
                b1 = lstm(0)
                b2 = lstm(1)
            End If

            'art = findopt(stk, ar(j))

            If arm Is Nothing And arm1 = -1 Then
                If drawopt Then
                    'closef(outfile)
                    'clsflg = True
                End If
                'If drawopt Then
                'plclst(itemno) = plclst(itemno) - 1
                'End If

                For m As Integer = j To UBound(ari) - 1
                    If ari(m) <> ari(j) Then
                        j = m
                        'Exit Do
                        GoTo lp
                        'Exit For
                    End If
                Next
                j = UBound(ari) + 1
                'maxqtylst.Add(itemqty)
                GoTo lp
                'Return stk
            Else
                If arn Is Nothing And arm1 = -1 Then
                    If drawopt Then
                        'closef(outfile)
                        'clsflg = True 
                    End If
                    'If drawopt Then
                    'plclst(plclst.Count - 1) = plclst(plclst.Count - 1) - 1
                    'End If

                    For m As Integer = j To UBound(ari) - 1
                        If ari(m) <> ari(j) Then
                            j = m
                            GoTo lp
                            'Exit Do
                            'Exit For
                        End If
                    Next
                    j = UBound(ari)
                    'maxqtylst.Add(itemqty)
                    'GoTo lp
                    'Return stk

                End If
            End If


            If Not arm Is Nothing Or Not arn Is Nothing Then
                'If Not arm Is Nothing Then
                cmd.Connection = conn
                'cmd.CommandText = "delete from temp2"
                DelTab("temp2")
z:
                'Try
                '    cmd.ExecuteNonQuery()
                'Catch ec As Exception
                '    If ec.Message = "Cannot open any more tables." Then
                '        conn.Close()
                '        conn.Dispose()
                '        OleDb.OleDbConnection.ReleaseObjectPool()
                '        cmd.Dispose()
                '        GC.Collect()

                '        'conn = Nothing
                '        'conn = New OleDb.OleDbConnection
                '        conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\container.mdb;Persist Security Info=False"

                '        conn.Open()
                '        GoTo z
                '    End If

                'End Try
                ordr = 0
                If Not arm Is Nothing Then
                    'dim aa as New Object()  { CStr(a1.strtpt.x), CStr(a1.strtpt.y), CStr(a1.strtpt.z), CStr(1)}
                    'cmd.CommandText = "insert into temp2 values(" & CStr(a1.strtpt.x) & "," & CStr(a1.strtpt.y) & "," & CStr(a1.strtpt.z) & "," & CStr(1) & ")"
                    instab("temp2", New Object() {CStr(a1.StrtPt.x), CStr(a1.StrtPt.y), CStr(a1.StrtPt.z), CStr(1)})
                    'w:
                    '                    Try
                    '                        cmd.ExecuteNonQuery()
                    '                    Catch ec As Exception
                    '                        If ec.Message = "Cannot open any more tables." Then
                    '                            conn.Close()
                    '                            conn.Dispose()
                    '                            OleDb.OleDbConnection.ReleaseObjectPool()
                    '                            cmd.Dispose()
                    '                            GC.Collect()
                    '                            'conn = Nothing
                    '                            'conn = New OleDb.OleDbConnection
                    '                            conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\container.mdb;Persist Security Info=False"

                    '                            conn.Open()
                    '                            GoTo w
                    '                        End If

                    '                    End Try
                    'arm = Nothing
                End If

                If Not arn Is Nothing Then
                    instab("temp2", New Object() {CStr(b1.StrtPt.x), CStr(b1.StrtPt.y), CStr(b1.StrtPt.z), CStr(2)})
                    '                    cmd.CommandText = "insert into temp2 values(" & CStr(b1.strtpt.x) & "," & CStr(b1.strtpt.y) & "," & CStr(b1.strtpt.z) & "," & CStr(2) & ")"
                    'a:
                    '                    Try
                    '                        cmd.ExecuteNonQuery()
                    '                    Catch ec As Exception
                    '                        If ec.Message = "Cannot open any more tables." Then
                    '                            conn.Close()
                    '                            conn.Dispose()
                    '                            OleDb.OleDbConnection.ReleaseObjectPool()
                    '                            cmd.Dispose()
                    '                            GC.Collect()

                    '                            'conn = Nothing
                    '                            'conn = New OleDb.OleDbConnection
                    '                            conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\container.mdb;Persist Security Info=False"

                    '                            conn.Open()
                    '                            GoTo a
                    '                        End If

                    '                    End Try
                    'arn = Nothing
                End If

                If Not art Is Nothing Then
                    instab("temp2", New Object() {CStr(art.StrtPt.x), CStr(art.StrtPt.y), CStr(art.StrtPt.z), CStr(3)})
                    '                    cmd.CommandText = "insert into temp2 values(" & CStr(art.strtpt.x) & "," & CStr(art.strtpt.y) & "," & CStr(art.strtpt.z) & "," & CStr(3) & ")"
                    'b:
                    '                    Try
                    '                        cmd.ExecuteNonQuery()
                    '                    Catch ec As Exception
                    '                        If ec.Message = "Cannot open any more tables." Then
                    '                            conn.Close()
                    '                            conn.Dispose()
                    '                                   leDbConnection.ReleaseObjectPool()
                    '                            cmd.Dispose()
                    '                            GC.Collect()
                    '                            'conn = Nothing
                    '                            'conn = New OleDb.OleDbConnection
                    '                            conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\container.mdb;Persist Security Info=False"

                    '                            conn.Open()
                    '                            GoTo b
                    '                        End If

                    '                    End Try
                End If

                'cmd.CommandText = "select * from temp2 order by z desc ,x asc,y asc"
                Dim rwx As DataRow() = Nothing
                If Not arm Is Nothing Then
                    'cmd.CommandText = "select * from temp2 order by z desc ,x asc,y asc"
                    rwx = getf("temp2", "", "z DESC ,x ASC,y ASC")
                End If

                If Not arn Is Nothing Then
                    'cmd.CommandText = "select * from temp2 order by z desc ,x asc,y asc"
                    rwx = getf("temp2", "", "z DESC ,x ASC,y ASC")
                End If

                If arn Is Nothing And arm Is Nothing Then
                    'cmd.CommandText = "select * from temp2 order by z desc, x asc"
                    rwx = getf("temp2", "", "z DESC ,x ASC")
                End If

                If arm Is Nothing And arn Is Nothing Then
                    'cmd.CommandText = "select * from temp2 order by z desc ,x asc,y asc"
                    rwx = getf("temp2", "", "z DESC ,x ASC,y ASC")
                End If
                'Try
                'rdr = cmd.ExecuteReader
                'Catch
                'conn.Dispose()
                'conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\container.mdb;Persist Security Info=False"
                'conn.Open()
                'rdr = cmd.ExecuteReader
                'End Try
                'rdr.Read()
                'ordr = rdr.Item("i")
                'rdr.Close()
                'attention
                ordr = rwx(0)("i")

                If ordr = 3 Then
                    stk.RemoveAt(arm1)
                Else
                    If ordr = 1 Then
                        art = a1
                        stk.RemoveAt(arm(0))
                        If arm(0) < arm(1) Then
                            stk.RemoveAt(arm(1) - 1)
                        Else
                            stk.RemoveAt(arm(1))
                        End If
                        'If Not chk1(a2, stk) Then
                        'unpush(stk, a2)
                        'stk.Add(a2)
                        stk = UnPush(stk, a2)
                        'End If
                    End If
                    If ordr = 2 Then
                        If pos1 = 1 Then
                            Dim tmp As Double = ar(j).width
                            ar(j).width = ar(j).length
                            ar(j).length = tmp
                        End If

                        If pos1 = 2 Then
                            Dim tmp As Double = ar(j).height
                            ar(j).height = ar(j).width
                            ar(j).width = tmp
                        End If


                        art = b1
                        stk.RemoveAt(arn(0))
                        If arn(0) < arn(1) Then
                            stk.RemoveAt(arn(1) - 1)
                        Else
                            stk.RemoveAt(arn(1))
                        End If
                        'If Not chk1(b2, stk) Then
                        stk.Add(b2)
                        'End If
                    End If
                    If ordr = 3 Then
                        stk.RemoveAt(arm1)
                    End If
                End If
            Else
                'art = stk(arm1)
                If arm1 <> -1 Then
                    stk.RemoveAt(arm1)
                End If
            End If

            'attention start

            Dim qty As Integer
            If chngflg Then
                ii = FindOptMethod(ar(j), art, qty, topup(j))
                If Occ > 1 Then
                    Dim occlst1 As New List(Of Integer)
                    For i As Integer = 0 To OccLst.Count - 1
                        occlst1.Add(OccLst(i))
                    Next
                    Dim mmm1 As New occ1
                    mmm1.j = j
                    mmm1.j1 = occlst1
                    mmm1.stk = stk
                    OptLst.Add(mmm1)
                End If
                Dim ln As Double = ar(j).length
                Dim wd As Double = ar(j).width
                Dim ht As Double = ar(j).height

                'For p As Integer = j To j + qty

                Dim nm As String = ari(j)
                Dim p As Integer = j


                'Do While Not p >= UBound(ari) - 1 AndAlso ari(p) <> ari(p + 1)
                If ii = 1 Then
                    'Exit Do
                End If

                If ii = 2 Then
                    ar(p).length = ln
                    ar(p).width = ht
                    ar(p).height = wd
                    'Exit Do
                End If

                If ii = 3 Then
                    ar(p).length = wd
                    ar(p).width = ht
                    ar(p).height = ln
                    'Exit Do
                End If

                If ii = 4 Then
                    ar(p).length = wd
                    ar(p).width = ln
                    ar(p).height = ht
                    'Exit Do
                End If

                If ii = 5 Then
                    ar(p).length = ht
                    ar(p).width = wd
                    ar(p).height = ln
                    'Exit Do
                End If

                If ii = 6 Then
                    ar(p).length = ht
                    ar(p).width = ln
                    ar(p).height = wd
                    'Exit Do
                End If

                'p += 1
                'Loop

                'Next

            End If

            Dim flg As Boolean = Math.Abs(((ar(j).length * ar(j).width * ar(j).height) * qty) - (art.length * art.width * art.height)) < 0.01
            Dim mm As Integer = findqty(ari, j)
            'If j = 6 Then Stop
            ''//////// removed on 06.03.2009 ////////////////////

            'If mm >= qty And flg Then
            '    Stop
            '    If drawopt Then
            '        If transparr(j) Then
            '            traval = 0.8
            '        Else
            '            traval = 0
            '        End If
            '        ar(j).StrtPt.x = art.StrtPt.x
            '        ar(j).StrtPt.y = art.StrtPt.y
            '        ar(j).StrtPt.z = art.StrtPt.z
            '        ar(j).draw(outfile, col, traval, "file:///c:/t2.png", ari(j), arwt(j), qtyflg, txtopt, "", 0, True, "c")
            '        'drwopt(art, ar(j), outfile, col, traval, ari(j), arwt(j), qtyflg, txtopt)

            '        j += qty
            '        itemqty += qty
            '    Else
            '        j += qty

            '        itemqty += qty
            '        plclst(itemno) = itemqty
            '        totwt += arwt(j)
            '        GoTo lp
            '    End If

            'End If
            ''//////////////////////////////////////////////

            'attention end

            'art = stk.Pop
            'If Form4.ftip(art, ar(j)) Then
            'If art.length >= ar(j).length AndAlso art.width >= ar(j).width AndAlso art.height >= ar(j).height Then
            arm = Nothing
            arn = Nothing
            ar(j).StrtPt.x = art.StrtPt.x

            ar(j).StrtPt.y = art.StrtPt.y
            ar(j).StrtPt.z = art.StrtPt.z
            'trans(outfile, New String() {CStr(art.strtpt.x), CStr(art.strtpt.y), CStr(art.strtpt.z)})
            'trans(outfile, New String() {CStr(ar(j).length / 2), CStr(ar(j).width / 2), CStr(ar(j).height / 2)})
            'placecube(outfile, New String() {CStr(ar(j).length), CStr(ar(j).width), CStr(ar(j).height)})

            If saveopt Then
                'Da.InsertCommand.CommandText = "insert into config (configid,id,strtx,strty,strtz,length,width,height,col,transp,tex) values('" & configid & "','" & CStr(id1) & "'," & CStr(art.strtpt.x) & "," & CStr(art.strtpt.y) & "," & art.strtpt.z & "," & CStr(ar(j).length) & "," & CStr(ar(j).width) & "," & CStr(ar(j).height) & ",'" & col & "',0,'')"
                'Da.InsertCommand.ExecuteNonQuery()
                'cmd.CommandText = "insert into config (configid,id,strtx,strty,strtz,length,width,height,col,transp,tex) values('" & configid & "','" & CStr(id1) & "'," & CStr(art.strtpt.x) & "," & CStr(art.strtpt.y) & "," & art.strtpt.z & "," & CStr(ar(j).length) & "," & CStr(ar(j).width) & "," & CStr(ar(j).height) & ",'" & col & "',0,'')"
m:
                Try
                    cmd.ExecuteNonQuery()
                Catch ec As Exception
                    If ec.Message = "Cannot open any more tables." Then
                        conn.Close()
                        conn.Dispose()
                        OleDb.OleDbConnection.ReleaseObjectPool()
                        cmd.Dispose()
                        GC.Collect()

                        'conn = Nothing
                        'conn = New OleDb.OleDbConnection
                        conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\container.mdb;Persist Security Info=False"

                        conn.Open()
                        GoTo m
                    End If

                End Try
                id1 += 1
            End If

            'trans(outfile, New String() {CStr(-art.strtpt.x), CStr(-art.strtpt.y), CStr(-art.strtpt.z)})
            'trans(outfile, New String() {CStr(-ar(j).length / 2), CStr(-ar(j).width / 2), CStr(-ar(j).height / 2)})

            If drawopt Then

                If transparr(j) Then
                    traval = 0.8
                Else
                    traval = 0
                End If
            End If
            If j = UBound(ar) - 1 Then
                'Stop
            End If
            If drawopt Then
                If j <> 0 Then
                    If ari(j) <> ari(j - 1) Then
                        tmplst.Add(ari(j - 1))
                        tmplst.Add(CStr(totar))
                        areaarr.Add(tmplst)
                        totar = 0
                        totar = totar + (ar(j).length * ar(j).width * ar(j).height)
                    Else
                        totar = totar + (ar(j).length * ar(j).width * ar(j).height)
                    End If
                Else
                    totar = totar + (ar(j).length * ar(j).width * ar(j).height)
                End If
            End If
            If drawopt Then
                txtopt = True
                ar(j).draw(outfile, col, traval, "file:///c:/s" & imgname & ".png", ari(j), arwt(j), qtyflg, txtopt, ari(j), ii, True, "b")
                If qtylst.Count > 0 Then
                    plclst(rwidx) = itemqty

                End If


                itemqty += 1

            Else
                itemqty += 1
                totwt += arwt(j)
            End If
            If qtylst.Count > 1 Then
                plclst(rwidx) = itemqty - 1
                maxqtylst.Add(itemqty - 1)
            End If
            If Not IsNothing(ari) Then
                Form8.i = itemqty
                Form8.Label2.Text = CStr(itemqty) & " items stuffed"
                Form8.Label2.Refresh()
                System.Windows.Forms.Application.DoEvents()
                If exflg Then
                    exflg = False
                    GoTo lp
                End If
            End If
            'If ordr = 3 OrElse ordr = 0 Then
            q = art.subtract(ar(j))
            'End If
            'If Not q Is Nothing Then
            '    Dim arre() As Area
            '    arre = q.ToArray
            '    For i As Integer = 0 To UBound(arre)
            '        'If j = 66 Then Stop
            '        Dim nn As Boolean = isgarb(arre(i), j, ar)

            '    Next

            'End If


            Dim dd As New Area
            If Not q Is Nothing Then
                If stk.Count = 0 Then
                    Do While Not q.Count = 0
                        'stk.Push(q.Dequeue)
                        dd = q.Dequeue
                        'If Not chk1(dd, stk) Then
                        'If Not chk11(dd, stk) Then
                        stk.Add(dd)
                        'End If
                        'End If


                    Loop
                Else
                    Do While q.Count > 0
                        arb = q.Dequeue
                        ans1 = False
                        'q1 = qpush1(q1, arb, ans1)
                        'If Not ans1 Then
                        'If Not chk1(arb, stk) Then
                        'If Not chk11(arb, stk) Then
                        stk = UnPush(stk, arb)
                        'End If
                        'End If
                        'End If
                    Loop

                End If

            End If
            Dim ans2 As Boolean
            For i As Integer = 0 To stk.Count - 1
                Dim arx As New Area
                arx = stk(i)
                stk = MrgX(stk, arx, ans2)
                If ans2 Then
                    Exit For
                End If


            Next

            Dim nn1 As New r1
            Dim nn As New Area
            nn.length = ar(j).length
            nn.width = ar(j).width
            nn.height = ar(j).height
            nn.StrtPt.x = ar(j).StrtPt.x
            nn.StrtPt.y = ar(j).StrtPt.y
            nn.StrtPt.z = ar(j).StrtPt.z
            nn1.ar = nn
            nn1.method = ii
            nn1.itmnm = ari(j)
            Dim mmm As New List(Of Area)
            For kk As Integer = 0 To stk.Count - 1
                mmm.Add(stk(kk))
            Next

            nn1.stk = mmm

            ahistarr.Add(nn1)

            j += 1
            'If j = 400 Then Stop
            'Else
            'q1.Enqueue(art)

            'qpush(q1, art, ans1)
            'End If
lp:

        Loop
        fff()
        'Stop

        If j > 0 Then
            e2 = New e1
            e2.qty = itemqty
            e2.itmnm = ari(j - 1)
        End If

        stkj = New List(Of Area)
        For jj As Integer = 0 To stk.Count - 1
            stkj.Add(stk(jj))
        Next
        e2.stk = stkj
        If drawopt Then
            qtyarr.Add(e2)
        End If
        maxqtylst.Add(itemqty)
        Form8.Close()
        If UBound(ar) >= j Then
            fullflag = True
        End If
        'MsgBox(itemqty)
        If findqtyflg Then
            stk.Clear()
            For i As Integer = 0 To stk.Count - 1
                If Not chk1(stk2(i), stk) Then
                    If Not chk11(stk2(i), stk) Then
                        stk.Add(stk2(i))
                    End If
                End If
            Next
        End If

        If drawopt Then
            If UBound(ari) <> -1 Then
                tmplst.Add(ari(j - 1))
                tmplst.Add(CStr(totar))
                areaarr.Add(tmplst)
            End If
        End If


        'If saveopt Then
        'saveempty("c:\stuff.mdb", q1, stk, configid)
        'End If
        'If showempty Then
        'showempt(q1, stk)
        'End If

        If drawopt Or drawarc Then
            'closef(outfile)
        End If
        qtyflg = True
        conn.Dispose()
        conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\container.mdb;Persist Security Info=False"
        conn.Open()

        Return stk


    End Function

    Public Function stuff_orig(ByVal arc As Area, ByVal ar() As Area, ByVal ari() As String, ByVal arwt() As Single, ByVal saveopt As Boolean, ByVal showempty As Boolean, ByVal outfile As String, ByVal drawarc As Boolean, ByVal transparr() As Boolean, ByVal topup() As Boolean, ByVal txtopt As Boolean, ByVal drawopt As Boolean, ByVal findqtyflg As Boolean, ByVal chngflg As Boolean, ByVal colarr As List(Of List(Of Byte))) As List(Of Area)

        Dim stk2 As New List(Of Area)
        Dim stk1 As New Stack(Of Area)
        Dim art As New Area
        Dim arp As New Area
        Dim are As New Area
        Dim aru As New Area
        Dim arb As New Area
        Dim q As New Queue(Of Area)
        Dim q1 As New Queue(Of Area)
        Dim q2 As New Queue(Of Area)
        Dim ans1 As Boolean
        Dim szchg As Integer = 0
        Dim cmd As New OleDb.OleDbCommand
        Dim qtyflg As Boolean = True
        Dim traval As Single
        Dim ard As New Area
        Dim arm As New List(Of Integer)
        Dim arm1 As Integer
        Dim lstm As New List(Of Area)
        Dim a1 As New Area
        Dim a2 As New Area
        Dim ordr As Integer
        Dim totar As Double
        Dim tmplst As New List(Of String)
        Dim answ As MsgBoxResult
        Dim olditemqty As Integer = 0
        Dim col As String
        Dim ii As Integer
        Dim stkj As New List(Of Area)

        If saveopt Then

            configid = InputBox("Enter Config Id")
        End If
        Dim ptx As New Point

        ptx.x = arc.length
        ptx.y = arc.width
        ptx.z = arc.height

        Dim col1 As New List(Of Byte)
        col1.Clear()
        col1.Add(255)
        col1.Add(255)
        col1.Add(255)
        col = "1"
        Dim itmnm As String = ""

        If drawarc Then
            Dim ard1 As New Area
            If drawarc Then

            End If
            ard.StrtPt.x = arc.length
            ard.StrtPt.y = 0
            ard.StrtPt.z = 0
            ard.length = 0.5
            ard.width = arc.width
            ard.height = arc.height
            If drawopt Or drawarc Then

            End If
            ard1.StrtPt.x = arc.length - 0.01
            ard1.StrtPt.y = 0
            ard1.StrtPt.z = 0
            ard1.length = 0.5
            ard1.width = ard.width
            ard1.height = ard.height
            If drawopt Or drawarc Then

                col1.Clear()
            End If
        End If

        If saveopt Then
            cmd.Connection = conn

y:
            Try
                cmd.ExecuteNonQuery()
            Catch ec As Exception
                If ec.Message = "Cannot open any more tables." Then
                    conn.Close()
                    conn.Dispose()
                    OleDb.OleDbConnection.ReleaseObjectPool()
                    cmd.Dispose()
                    GC.Collect()

                    conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\container.mdb;Persist Security Info=False"

                    conn.Open()
                    GoTo y
                End If

            End Try
            id1 += 1
        End If

        arc.StrtPt.x = 0
        arc.StrtPt.y = 0
        arc.StrtPt.z = 0

        Dim j As Integer = 0
        totar = 0
        Bareaarr.Clear()
        For i As Integer = 0 To stk.Count - 1
            stk2.Add(stk(i))
        Next
        Bitemqty = 0
        Btotwt = 0
        If Not IsNothing(ari) Then
            Form8.Show()
            If drawopt Then
                Form8.Button1.Visible = False
            End If
            Form8.Focus()
        End If

        For i As Integer = 0 To Bqtylst.Count - 1
            Bplclst.Add(Bqtylst(i) - 1)
        Next

        fullflag = False
        olditemqty = 0
        Dim imgname As String = "1"
        Do While Not stk.Count = 0 And j <= UBound(ar)

            If j > 0 Then
                If ari(j) <> ari(j - 1) Then
                    imgname = (CInt(imgname) + 1).ToString
                End If
            End If

            ordr = 0

            If chkwt Then
                Btotwt += arwt(j)
                If Btotwt >= contcap Then

                    answ = MsgBox("Maximum weight capacity of the container is reached" & vbCrLf & "Do you want to proceed?", MsgBoxStyle.YesNo)
                    If answ = MsgBoxResult.No Then
                        fullflag = True

                        Exit Do

                    Else
                        fullflag = False

                        chkwt = False
                    End If

                End If
            End If

            If j = 0 Then
                col = Bstrtclr
            End If

            If j > 0 And Not IsNothing(ari) Then
                If ari(j - 1) <> ari(j) Then
                    e2 = New e1
                    e2.qty = Bitemqty
                    e2.itmnm = ari(j - 1)
                    stkj = New List(Of Area)
                    For jj As Integer = 0 To stk.Count - 1
                        stkj.Add(stk(jj))
                    Next
                    e2.stk = stkj
                    If drawopt Then
                        qtyarr.Add(e2)
                    End If
                    If Bqtylst.Count > 0 Then

                    End If

                    Bmaxqtylst.Add(Bitemqty)


                    Form8.Label1.Text = "Stuffing item:" & ari(j)
                    Form8.Label1.Refresh()
                Else
                    Form8.Label1.Text = "Stuffing item:" & ari(j)
                    Form8.Label1.Refresh()
                End If
            Else
                If j > 0 Then
                    Form8.Show()
                    If drawopt Then
                        Form8.Button1.Visible = False
                    End If
                    Form8.Label1.Text = "Finding Maximum Quantity...."
                    Form8.Label1.Refresh()
                End If
            End If


            If drawopt Then
                If j > 0 Then

                    If ari(j - 1) <> ari(j) Then

                        Bitemqty = 0

                        If col = "r" Then
                            col = "g"
                        ElseIf col = "g" Then
                            col = "b"
                        ElseIf col = "b" Then
                            col = "m"
                        ElseIf col = "m" Then
                            col = "c"
                        ElseIf col = "c" Then
                            col = "y"
                        End If

                        szchg += 1
                        qtyflg = True

                    Else
                        qtyflg = False
                    End If
                End If
            End If

            If szchg <> 2 Then

            Else

            End If

            arm1 = findopt(stk, ar(j), topup(j))
            art = Nothing

            If arm1 <> -1 Then
                art = stk(arm1)
            End If

            Dim arn As New List(Of Integer)
            Dim lstn As New List(Of Area)
            Dim b1 As New Area
            Dim b2 As New Area
            Dim pos1 As Integer
            arm = Nothing
            arn = Nothing

            arn = findcandidate1(stk, ar(j), topup(j))
            pos1 = 0
            If Not arn Is Nothing Then
                pos1 = 0
            Else
                Dim arxx As New Area
                arxx.length = ar(j).width
                arxx.width = ar(j).length
                arxx.height = ar(j).height
                arn = findcandidate1(stk, arxx, topup(j))
                If Not arn Is Nothing Then
                    pos1 = 1
                Else
                    If Not topup(j) Then
                        arxx.length = ar(j).length
                        arxx.width = ar(j).height
                        arxx.height = ar(j).width
                        arn = findcandidate1(stk, arxx, False)
                        If Not arn Is Nothing Then
                            pos1 = 2
                        End If
                    End If
                End If
            End If
            If arn Is Nothing Then
                arm = findcandidate(stk, ar(j))
                If Not arm Is Nothing Then
                    If arm(0) = arm1 Then arm = Nothing
                End If
            End If
            If Not arm Is Nothing Then
                lstm = unionp(stk(arm(0)), stk(arm(1)))
                a1 = lstm(0)
                a2 = lstm(1)
            End If

            If Not arn Is Nothing Then

                lstm = unionp(stk(arn(0)), stk(arn(1)))
                b1 = lstm(0)
                b2 = lstm(1)
            End If


            If arm Is Nothing And arm1 = -1 Then
                If drawopt Then

                End If

                For m As Integer = j To UBound(ari) - 1
                    If ari(m) <> ari(j) Then
                        j = m

                        GoTo lp

                    End If
                Next
                j = UBound(ari) + 1

                GoTo lp

            Else
                If arn Is Nothing And arm1 = -1 Then
                    If drawopt Then

                    End If


                    For m As Integer = j To UBound(ari) - 1
                        If ari(m) <> ari(j) Then
                            j = m
                            GoTo lp

                        End If
                    Next
                    j = UBound(ari)

                End If
            End If

            If Not arm Is Nothing Or Not arn Is Nothing Then

                cmd.Connection = conn

                DelTab("temp2")
z:

                ordr = 0
                If Not arm Is Nothing Then

                    instab("temp2", New Object() {CStr(a1.StrtPt.x), CStr(a1.StrtPt.y), CStr(a1.StrtPt.z), CStr(1)})

                End If

                If Not arn Is Nothing Then
                    instab("temp2", New Object() {CStr(b1.StrtPt.x), CStr(b1.StrtPt.y), CStr(b1.StrtPt.z), CStr(2)})

                End If

                If Not art Is Nothing Then
                    instab("temp2", New Object() {CStr(art.StrtPt.x), CStr(art.StrtPt.y), CStr(art.StrtPt.z), CStr(3)})

                End If

                Dim rwx As DataRow() = Nothing
                If Not arm Is Nothing Then

                    rwx = getf("temp2", "", "z DESC ,x ASC,y ASC")
                End If

                If Not arn Is Nothing Then

                    rwx = getf("temp2", "", "z DESC ,x ASC,y ASC")
                End If

                If arn Is Nothing And arm Is Nothing Then

                    rwx = getf("temp2", "", "z DESC ,x ASC")
                End If

                If arm Is Nothing And arn Is Nothing Then

                    rwx = getf("temp2", "", "z DESC ,x ASC,y ASC")
                End If

                ordr = rwx(0)("i")

                If ordr = 3 Then
                    stk.RemoveAt(arm1)
                Else
                    If ordr = 1 Then
                        art = a1
                        stk.RemoveAt(arm(0))
                        If arm(0) < arm(1) Then
                            stk.RemoveAt(arm(1) - 1)
                        Else
                            stk.RemoveAt(arm(1))
                        End If

                        stk = UnPush(stk, a2)

                    End If
                    If ordr = 2 Then
                        If pos1 = 1 Then
                            Dim tmp As Double = ar(j).width
                            ar(j).width = ar(j).length
                            ar(j).length = tmp
                        End If

                        If pos1 = 2 Then
                            Dim tmp As Double = ar(j).height
                            ar(j).height = ar(j).width
                            ar(j).width = tmp
                        End If

                        art = b1
                        stk.RemoveAt(arn(0))
                        If arn(0) < arn(1) Then
                            stk.RemoveAt(arn(1) - 1)
                        Else
                            stk.RemoveAt(arn(1))
                        End If

                        stk.Add(b2)

                    End If
                    If ordr = 3 Then
                        stk.RemoveAt(arm1)
                    End If
                End If
            Else

                If arm1 <> -1 Then
                    stk.RemoveAt(arm1)
                End If
            End If

            'attention start

            Dim qty As Integer
            If chngflg Then
                ii = FindOptMethod(ar(j), art, qty, topup(j))
                If Occ > 1 Then
                    Dim occlst1 As New List(Of Integer)
                    For i As Integer = 0 To OccLst.Count - 1
                        occlst1.Add(OccLst(i))
                    Next
                    Dim mmm1 As New occ1
                    mmm1.j = j
                    mmm1.j1 = occlst1
                    mmm1.stk = stk
                    OptLst.Add(mmm1)
                End If
                Dim ln As Double = ar(j).length
                Dim wd As Double = ar(j).width
                Dim ht As Double = ar(j).height

                Dim nm As String = ari(j)
                Dim p As Integer = j

                If ii = 1 Then

                End If

                If ii = 2 Then
                    ar(p).length = ln
                    ar(p).width = ht
                    ar(p).height = wd

                End If

                If ii = 3 Then
                    ar(p).length = wd
                    ar(p).width = ht
                    ar(p).height = ln

                End If

                If ii = 4 Then
                    ar(p).length = wd
                    ar(p).width = ln
                    ar(p).height = ht

                End If

                If ii = 5 Then
                    ar(p).length = ht
                    ar(p).width = wd
                    ar(p).height = ln

                End If

                If ii = 6 Then
                    ar(p).length = ht
                    ar(p).width = ln
                    ar(p).height = wd

                End If

            End If

            Dim flg As Boolean = Math.Abs(((ar(j).length * ar(j).width * ar(j).height) * qty) - (art.length * art.width * art.height)) < 0.01
            Dim mm As Integer = findqty(ari, j)

            If mm >= qty And flg Then

                If drawopt Then
                    If transparr(j) Then
                        traval = 0.8
                    Else
                        traval = 0
                    End If
                    ar(j).StrtPt.x = art.StrtPt.x
                    ar(j).StrtPt.y = art.StrtPt.y
                    ar(j).StrtPt.z = art.StrtPt.z

                    j += qty
                    Bitemqty += qty
                Else
                    j += qty

                    Bitemqty += qty
                    Bplclst(Bitemno) = Bitemqty
                    Btotwt += arwt(j)
                    GoTo lp
                End If

            End If

            'attention end


            arm = Nothing
            arn = Nothing
            ar(j).StrtPt.x = art.StrtPt.x

            ar(j).StrtPt.y = art.StrtPt.y
            ar(j).StrtPt.z = art.StrtPt.z

            If saveopt Then

m:
                Try
                    cmd.ExecuteNonQuery()
                Catch ec As Exception
                    If ec.Message = "Cannot open any more tables." Then
                        conn.Close()
                        conn.Dispose()
                        OleDb.OleDbConnection.ReleaseObjectPool()
                        cmd.Dispose()
                        GC.Collect()

                        conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\container.mdb;Persist Security Info=False"

                        conn.Open()
                        GoTo m
                    End If

                End Try
                id1 += 1
            End If

            If drawopt Then

                If transparr(j) Then
                    traval = 0.8
                Else
                    traval = 0
                End If
            End If
            If j = UBound(ar) Then

            End If
            If drawopt Then
                If j <> 0 Then
                    If ari(j) <> ari(j - 1) Then
                        tmplst.Add(ari(j - 1))
                        tmplst.Add(CStr(totar))
                        Bareaarr.Add(tmplst)
                        totar = 0
                        totar = totar + (ar(j).length * ar(j).width * ar(j).height)
                    Else
                        totar = totar + (ar(j).length * ar(j).width * ar(j).height)
                    End If
                Else
                    totar = totar + (ar(j).length * ar(j).width * ar(j).height)
                End If
            End If
            If drawopt Then
                txtopt = True

                If Bqtylst.Count > 0 Then
                    Bplclst(rwidx) = Bitemqty

                End If


                Bitemqty += 1

            Else
                Bitemqty += 1
                Btotwt += arwt(j)
            End If
            If Bqtylst.Count > 1 Then
                Bplclst(rwidx) = Bitemqty - 1
                Bmaxqtylst.Add(Bitemqty - 1)
            End If
            If Not IsNothing(ari) Then
                Form8.i = Bitemqty
                Form8.Label2.Text = CStr(Bitemqty) & " items stuffed"
                Form8.Label2.Refresh()
                System.Windows.Forms.Application.DoEvents()
                If exflg Then
                    exflg = False
                    GoTo lp
                End If
            End If

            q = art.subtract(ar(j))

            Dim dd As New Area
            If Not q Is Nothing Then
                If stk.Count = 0 Then
                    Do While Not q.Count = 0

                        dd = q.Dequeue

                        stk.Add(dd)

                    Loop
                Else
                    Do While q.Count > 0
                        arb = q.Dequeue
                        ans1 = False

                        stk = UnPush(stk, arb)

                    Loop

                End If

            End If
            Dim ans2 As Boolean
            For i As Integer = 0 To stk.Count - 1
                Dim arx As New Area
                arx = stk(i)
                stk = MrgX(stk, arx, ans2)
                If ans2 Then
                    Exit For
                End If

            Next

            Dim nn1 As New r1
            Dim nn As New Area
            nn.length = ar(j).length
            nn.width = ar(j).width
            nn.height = ar(j).height
            nn.StrtPt.x = ar(j).StrtPt.x
            nn.StrtPt.y = ar(j).StrtPt.y
            nn.StrtPt.z = ar(j).StrtPt.z
            nn1.ar = nn
            nn1.method = ii
            nn1.itmnm = ari(j)
            Dim mmm As New List(Of Area)
            For kk As Integer = 0 To stk.Count - 1
                mmm.Add(stk(kk))
            Next

            nn1.stk = mmm

            Bahistarr.Add(nn1)

            j += 1

lp:

        Loop
        fff()

        BxItmQty = Bitemqty

        If j > 0 Then
            e2 = New e1
            e2.qty = Bitemqty
            e2.itmnm = ari(j - 1)
        End If

        stkj = New List(Of Area)
        For jj As Integer = 0 To stk.Count - 1
            stkj.Add(stk(jj))
        Next
        e2.stk = stkj
        If drawopt Then
            qtyarr.Add(e2)
        End If
        Bmaxqtylst.Add(Bitemqty)
        Form8.Close()
        If UBound(ar) >= j Then
            fullflag = True
        End If

        If findqtyflg Then
            'stk.Clear()
            For i As Integer = 0 To stk.Count - 1
                If Not chk1(stk2(i), stk) Then
                    If Not chk11(stk2(i), stk) Then
                        stk.Add(stk2(i))
                    End If
                End If
            Next
        End If

        If drawopt Then
            If UBound(ari) <> -1 Then
                tmplst.Add(ari(j - 1))
                tmplst.Add(CStr(totar))
                Bareaarr.Add(tmplst)
            End If
        End If

        If drawopt Or drawarc Then

        End If
        qtyflg = True
        conn.Dispose()
        conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\container.mdb;Persist Security Info=False"
        conn.Open()

        Return stk

    End Function

    ' This is the stuffing of boxes geometry function which is to be looping to stuff 
    ' the box geometry. This function includes various routines and functions to manipulate 
    ' the geometry program calculations in looping structure.

    Public Function BoxStuff(ByVal arc As Area, ByVal ar() As Area, ByVal ari() As String, ByVal arwt() As Single, ByVal saveopt As Boolean, ByVal showempty As Boolean, ByVal outfile As String, ByVal drawarc As Boolean, ByVal transparr() As Boolean, ByVal topup() As Boolean, ByVal txtopt As Boolean, ByVal drawopt As Boolean, ByVal findqtyflg As Boolean, ByVal chngflg As Boolean, ByVal colarr As List(Of List(Of Byte)), ByVal dgv1 As DataGridView) As List(Of Area)

        BxItmQty = 0
        Dim stk2 As New List(Of Area)
        Dim stk1 As New Stack(Of Area)
        Dim art As New Area
        Dim arp As New Area
        Dim are As New Area
        Dim aru As New Area
        Dim arb As New Area
        Dim q As New Queue(Of Area)
        Dim q1 As New Queue(Of Area)
        Dim q2 As New Queue(Of Area)

        Dim ans1 As Boolean
        Dim szchg As Integer = 0
        Dim cmd As New OleDb.OleDbCommand

        Dim qtyflg As Boolean = True
        Dim traval As Single
        Dim ard As New Area
        Dim arm As New List(Of Integer)
        Dim arm1 As Integer
        Dim lstm As New List(Of Area)
        Dim a1 As New Area
        Dim a2 As New Area
        Dim ordr As Integer
        Dim totar As Double
        Dim tmplst As New List(Of String)
        Dim answ As MsgBoxResult

        Dim olditemqty As Integer = 0
        'Dim col As String   ==========>>>   Dim Bcol As String
        Dim ii As Integer

        Dim Yax As Double = 0

        Dim stkj As New List(Of Area)

        Try
            If saveopt Then
                configid = InputBox("Enter Config Id")
            End If

            Dim ptx As New Point

            ptx.x = arc.length
            ptx.y = arc.width
            ptx.z = arc.height

            Dim col1 As New List(Of Byte)
            col1.Clear()
            col1.Add(255)
            col1.Add(255)
            col1.Add(255)
            Bcol = "1"

            Dim itmnm As String = ""

            If drawarc Then
                Dim ard1 As New Area
                If drawarc Then
                End If

                ard.StrtPt.x = arc.length
                ard.StrtPt.y = 0
                ard.StrtPt.z = 0
                ard.length = 0.5
                ard.width = arc.width
                ard.height = arc.height

                If drawopt Or drawarc Then

                End If

                ard1.StrtPt.x = arc.length - 0.01
                ard1.StrtPt.y = 0
                ard1.StrtPt.z = 0
                ard1.length = 0.5
                ard1.width = ard.width
                ard1.height = ard.height

                If drawopt Or drawarc Then
                    col1.Clear()
                End If

            End If

            If saveopt Then
                cmd.Connection = conn
y:
                Try
                    cmd.ExecuteNonQuery()
                Catch ec As Exception
                    If ec.Message = "Cannot open any more tables." Then
                        conn.Close()
                        conn.Dispose()
                        OleDb.OleDbConnection.ReleaseObjectPool()
                        cmd.Dispose()
                        GC.Collect()
                        conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\container.mdb;Persist Security Info=False"
                        conn.Open()
                        GoTo y
                    End If

                End Try
                id1 += 1
            End If

            arc.StrtPt.x = 0        'Initializing the area of container xyz points
            arc.StrtPt.y = 0
            arc.StrtPt.z = 0

            Dim j As Integer = 0
            totar = 0
            Bareaarr.Clear()

            For i As Integer = 0 To stk.Count - 1
                stk2.Add(stk(i))
            Next

            Bitemqty = 0
            Btotwt = 0

            'Stop

            If Not IsNothing(ari) Then
                'Form8.Show()
                TransactionMenu.lblStatus.Visible = True
                TransactionMenu.lblStatusINm.Visible = True
                TransactionMenu.btnStatus.Visible = True

                '@
                TransactionMenu.btnPause.Visible = True
                TransactionMenu.mtxtbxPause.Visible = True
                TransactionMenu.lblSec.Visible = True
                TransactionMenu.pnlPbinfo.Visible = True
                TransactionMenu.pnlsp.Visible = True

                TransactionMenu.pbCSP1.Visible = True
                ProgressBarRunning()

                If drawopt Then
                    'Form8.Button1.Visible = False
                    TransactionMenu.btnStatus.Visible = True

                    '@
                    TransactionMenu.btnPause.Visible = True
                    TransactionMenu.mtxtbxPause.Visible = True
                    TransactionMenu.lblSec.Visible = True
                    TransactionMenu.pnlPbinfo.Visible = True
                    TransactionMenu.pnlsp.Visible = True

                End If

                'Form8.Focus()
                TransactionMenu.lblStatus.Focus()
                TransactionMenu.lblStatusINm.Focus()
            End If

            For i As Integer = 0 To Bqtylst.Count - 1
                Bplclst.Add(Bqtylst(i) - 1)
            Next

            fullflag = False
            olditemqty = 0
            Dim imgname As String = "1"

            xMax = 0            'Initializing the CollectArt data
            fXmax = 0
            CAimgnm = Nothing
            CAflg = False

            vertxINo = "2"        'Initialising in VertexBox Finction
            bVx = 0
            bVy = 0
            bVXx = 0

            Dim StepCount As Integer = 1

            If TransactionMenu.btnStepTrials.BackColor = Color.HotPink Then

                DeleteWrlOutFilesStepTrial()

                off.Flush()

                'off.WriteLine("")
                'off.WriteLine("]}]}]}]}]}")
                'off.WriteLine("")
                'off.Flush()

                Dim stpFnm As String = CurDir() & "\OutPut\Firststp" & StepCount & ".wrl"

                frmStep.AddSteps(StepCount)

                StepCount += 1

                off.Flush()

                My.Computer.FileSystem.CopyFile(outfile, stpFnm, True)

                frmStep.AddSteps(StepCount)

                offs = New IO.StreamWriter(stpFnm, True)
                offs.AutoFlush = True
                offs.Flush()
                offs.WriteLine("")
                offs.WriteLine("]}]}]}]}]}")
                offs.WriteLine("")
                offs.Flush()
                offs.Dispose()
                offs.Close()

                If TransactionMenu.chkbxStpShow.Checked Then
                    Call StepNows(stpFnm)
                End If

            End If

            'If TransactionMenu.chkbxStpShow.Checked Then
            '    'MessageBox.Show("The showing empty container.", "P-Stuff info.....", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    Call StepNow()
            'End If

            Dim scFlg As Boolean = False
            Dim RiQ As Int16 = 0
            Dim BalQty As Int64 = 0

            Try
                Do While (TransactionMenu.dgv1.RowCount - 2)

                    TransactionMenu.dgv1.Item(15, RiQ).Value = ""
                    TransactionMenu.dgv1.Item(16, RiQ).Value = ""
                    RiQ += 1

                Loop
            Catch
            End Try

            off.WriteLine("#***************************************************************************")

            RiQ = 0
            ' Dim RiQNo As Integer = imgname
            Dim ccell As DataGridViewCell = dgv1.CurrentCell
            Dim bcol1 As String = "0 0 0"

            Do While Not stk.Count = 0 And j <= UBound(ar)

                'Dim Lc As Integer = j

                'Stop

                Dim srno1 As Int16

                dgv1.CurrentCell = dgv1(0, srno1)

                If j = 0 Then
                    TransactionMenu.pbCSP1.ForeColor = dgv1.Rows(srno1).HeaderCell.Style.BackColor
                    With dgv1.Rows(srno1).HeaderCell.Style.BackColor
                        bcol1 = Math.Round(.R / 255, 2) & " " & Math.Round(.G / 255, 2) & " " & Math.Round(.B / 255, 2)
                    End With
                    If bcol1 <> "0 0 0" Then Bcol = bcol1 Else Bcol = imgname
                End If

                If j > 0 Then

                    If ari(j) <> ari(j - 1) Then
                        '      RiQNo = CInt(RiQNo) + 1

                        For srno1 = srno1 To dgv1.RowCount - 2
                            If dgv1(1, srno1).Value = ari(j) Then
                                imgname = dgv1(0, srno1).Value
                                dgv1.CurrentCell = dgv1(0, srno1)
                                With dgv1.Rows(srno1).HeaderCell.Style.BackColor
                                    TransactionMenu.pbCSP1.ForeColor = dgv1.Rows(srno1).HeaderCell.Style.BackColor
                                    bcol1 = Math.Round(.R / 255, 2) & " " & Math.Round(.G / 255, 2) & " " & Math.Round(.B / 255, 2)
                                End With
                                If bcol1 <> "0 0 0" Then Bcol = bcol1 Else Bcol = imgname
                                Exit For

                            End If
                        Next
                        'imgname = (CInt(imgname) + 1).ToString
                        'RiQ = Val((CInt(imgname) - 2).ToString)

                        RiQ = dgv1.CurrentRow.Index - 1

                        '  RiQ = RiQNo + 1
                        Dim mRslt As MsgBoxResult

                        If Not scFlg Then

                            'mRslt = MessageBox.Show("The '" & ari(j - 1) & "' stuffing completed." & vbNewLine & "The ' " & Bitemqty & " ' number of item stuffed.", "Stuffing Entry.....", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)

                            TransactionMenu.dgv1.Item(15, RiQ).Value = Bitemqty

                            BalQty = TransactionMenu.dgv1.Item(11, RiQ).Value

                            BalQty = BalQty - Bitemqty

                            If BalQty < 0 Then
                                BalQty = 0
                            End If

                            TransactionMenu.dgv1.Item(16, RiQ).Value = BalQty

                            TransactionMenu.dgv1.Refresh()

                            If mRslt = MsgBoxResult.Cancel Then
                                scFlg = True
                            End If

                        Else

                            TransactionMenu.dgv1.Item(15, RiQ).Value = Bitemqty

                            BalQty = TransactionMenu.dgv1.Item(11, RiQ).Value
                            BalQty = BalQty - Bitemqty
                            TransactionMenu.dgv1.Item(16, RiQ).Value = BalQty

                            TransactionMenu.dgv1.Refresh()

                        End If

                        'If TransactionMenu.chkbxStpShow.Checked Then
                        '    MessageBox.Show("The '" & ari(j - 1) & "' stuffing completed.", "Stuffing Entry.....", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        '    Call StepNow()
                        'End If

                    End If
                End If

                ordr = 0

                If chkwt Then
                    Btotwt += arwt(j)
                    If Btotwt >= contcap Then

                        answ = MsgBox("Maximum weight capacity of the container is reached" & vbCrLf & "Do you want to proceed?", MsgBoxStyle.YesNo)

                        If answ = MsgBoxResult.No Then
                            fullflag = True

                            Exit Do

                        Else
                            fullflag = False

                            chkwt = False
                        End If

                    End If
                End If
                If j = 0 Then
                    With dgv1.Rows(0).HeaderCell.Style.BackColor
                        bcol1 = Math.Round(.R / 255, 2) & " " & Math.Round(.G / 255, 2) & " " & Math.Round(.B / 255, 2)
                    End With
                    If bcol1 <> "0 0 0" Then Bcol = bcol1 ' Else Bcol = Bstrtclr
                End If

                If j > 0 And Not IsNothing(ari) Then
                    If ari(j - 1) <> ari(j) Then
                        e2 = New e1
                        e2.qty = Bitemqty
                        e2.itmnm = ari(j - 1)
                        stkj = New List(Of Area)

                        For jj As Integer = 0 To stk.Count - 1
                            stkj.Add(stk(jj))
                        Next

                        e2.stk = stkj
                        If drawopt Then
                            qtyarr.Add(e2)
                        End If
                        If Bqtylst.Count > 0 Then

                        End If

                        Bmaxqtylst.Add(Bitemqty)

                        'Form8.Label1.Text = "Stuffing item:" & ari(j)
                        'Form8.Label1.Refresh()

                        'TransactionMenu.lblStatusINm.Text = "Stuffing item : " & ari(j)
                        'TransactionMenu.lblStatusINm.Refresh()
                    Else
                        'Form8.Label1.Text = "Stuffing item:" & ari(j)
                        'Form8.Label1.Refresh()

                        'TransactionMenu.lblStatusINm.Text = "Stuffing item : " & ari(j)
                        'TransactionMenu.lblStatusINm.Refresh()
                    End If
                Else
                    If j > 0 Then
                        'Form8.Show()
                        TransactionMenu.lblStatus.Visible = True
                        TransactionMenu.lblStatusINm.Visible = True
                        TransactionMenu.btnStatus.Visible = True

                        '@
                        TransactionMenu.btnPause.Visible = True
                        TransactionMenu.mtxtbxPause.Visible = True
                        TransactionMenu.lblSec.Visible = True
                        TransactionMenu.pnlPbinfo.Visible = True
                        TransactionMenu.pnlsp.Visible = True

                        TransactionMenu.pbCSP1.Visible = True
                        ProgressBarRunning()

                        If drawopt Then
                            'Form8.Button1.Visible = False
                            TransactionMenu.btnStatus.Visible = False

                            '@
                            TransactionMenu.btnPause.Visible = False
                            TransactionMenu.lblSec.Visible = False
                            TransactionMenu.mtxtbxPause.Visible = False
                            TransactionMenu.pnlPbinfo.Visible = False
                            TransactionMenu.pnlsp.Visible = False
                        End If

                        'Form8.Label1.Text = "Finding Maximum Quantity ....."
                        'Form8.Label1.Refresh()

                        TransactionMenu.lblStatus.Text = "Finding Maximum Quantity ....."
                        TransactionMenu.lblStatus.Refresh()
                    End If
                End If

                'Stop

                If drawopt Then
                    If j > 0 Then

                        If ari(j - 1) <> ari(j) Then

                            Bitemqty = 0
                            If Bcol.Length = 1 Then
                                Dim colnum As Short = Val(imgname)
                                colnum = IIf(colnum > 6, colnum - 6, colnum)
                                Select Case colnum
                                    Case 1
                                        Bcol = "r"
                                    Case 2
                                        Bcol = "g"
                                    Case 3
                                        Bcol = "b"
                                    Case 4
                                        Bcol = "m"
                                    Case 5
                                        Bcol = "c"
                                    Case 6
                                        Bcol = "y"
                                End Select

                                'If Bcol = "r" Then
                                '    Bcol = "g"
                                'ElseIf Bcol = "g" Then
                                '    Bcol = "b"
                                'ElseIf Bcol = "b" Then
                                '    Bcol = "m"
                                'ElseIf Bcol = "m" Then
                                '    Bcol = "c"
                                'ElseIf Bcol = "c" Then
                                '    Bcol = "y"
                                'ElseIf Bcol = "y" Then
                                '    Bcol = "r"
                                'End If
                            End If
                            szchg += 1
                            qtyflg = True

                        Else

                            qtyflg = False
                        End If
                    Else
                        If Bcol = "1" Then Bcol = "r"
                    End If
                End If

                If szchg <> 2 Then

                Else

                End If

                'Stop

                If BitemqtyInr = 138 Then

                    'Stop

                    'off.Close()
                End If

                '$$$$$$$$$$$$$$$$$$

                arm1 = findopt(stk, ar(j), topup(j))

                'Stop

                Try

                    Dim Ars As New Area

                    'Assigning the previous value to selected value so that the CollectArt 
                    'is to do the manipulation of that data.

                    Ars = art

                    art = Nothing

                    Dim ImgNm As String = Nothing

                    ImgNm = TransactionMenu.txtWadBox.Text

                    If ImgNm = "" Then ImgNm = "1"

                    If arm1 <> -1 Then

                        art = stk(arm1)

                        If TransactionMenu.chkbxWadStuff.Checked Or TransactionMenu.chkbxWadStuff0.Checked Or TransactionMenu.chkbxWadStuff2.Checked Then

                            If imgname <> "1" AndAlso Not (CInt(imgname) <= CInt(ImgNm)) Then

                                ' This is the function to shift the box geometry in container so 
                                ' that to optimize the space of container. 

                                If TransactionMenu.chkbxWadStuff.Checked Then

                                    art = SCollectArt(art, arm1, Ars, ar(j), imgname)
                                    'art = PCollectArt(art, arm1, Ars, ar(j), imgname)

                                ElseIf TransactionMenu.chkbxWadStuff0.Checked Then

                                    art = CollectArt(art, arm1, Ars, ar(j), imgname)

                                ElseIf TransactionMenu.chkbxWadStuff2.Checked Then

                                    art = BCollectArt(art, arm1, Ars, ar(j), imgname)

                                End If

                            End If
                        End If
                    End If

                Catch Ex As Exception
                    MsgBox(Ex.Message)
                    MsgBox(Ex.ToString)
                    MessageBox.Show("Warnning in CollectArt", "Warnning.....", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    'Stop
                End Try

                '$$$$$$$$$$$$$$$$$$

                Dim arn As New List(Of Integer)
                Dim lstn As New List(Of Area)
                Dim b1 As New Area
                Dim b2 As New Area
                Dim pos1 As Integer
                arm = Nothing
                arn = Nothing

                'Stop

                arn = findcandidate1(stk, ar(j), topup(j))

                'Stop

                pos1 = 0

                If Not arn Is Nothing Then
                    pos1 = 0
                Else
                    Dim arxx As New Area

                    arxx.length = ar(j).width
                    arxx.width = ar(j).length
                    arxx.height = ar(j).height

                    arxx.StrtPt.x = ar(j).StrtPt.x
                    arxx.StrtPt.y = ar(j).StrtPt.y
                    arxx.StrtPt.z = ar(j).StrtPt.z

                    arn = findcandidate1(stk, arxx, topup(j))

                    'Stop

                    If Not arn Is Nothing Then
                        pos1 = 1
                    Else
                        If Not topup(j) Then
                            arxx.length = ar(j).length
                            arxx.width = ar(j).height
                            arxx.height = ar(j).width

                            arxx.StrtPt.x = ar(j).StrtPt.x
                            arxx.StrtPt.y = ar(j).StrtPt.y
                            arxx.StrtPt.z = ar(j).StrtPt.z

                            arn = findcandidate1(stk, arxx, False)

                            'Stop

                            If Not arn Is Nothing Then
                                pos1 = 2
                            End If
                        End If
                    End If
                End If

                'Stop

                If arn Is Nothing Then

                    'Stop

                    arm = findcandidate(stk, ar(j))

                    'Stop

                    If Bitemqty = 127 Then
                        'Stop
                        'off.Close()
                        'Application.Exit()
                    End If

                    'Stop

                    'Stop

                    If Not arm Is Nothing Then
                        If arm(0) = arm1 Then arm = Nothing
                    End If
                End If
                If Not arm Is Nothing Then

                    'Stop

                    lstm = unionp(stk(arm(0)), stk(arm(1)))

                    'Stop

                    a1 = lstm(0)
                    a2 = lstm(1)
                End If

                If Not arn Is Nothing Then

                    'Stop

                    lstm = unionp(stk(arn(0)), stk(arn(1)))

                    'Stop
                    b1 = lstm(0)
                    b2 = lstm(1)

                End If

                If arm Is Nothing And arm1 = -1 Then

                    If drawopt Then

                    End If

                    For m As Integer = j To UBound(ari) - 1
                        If ari(m) <> ari(j) Then
                            j = m

                            GoTo lp

                        End If
                    Next
                    j = UBound(ari) + 1

                    GoTo lp

                Else
                    If arn Is Nothing And arm1 = -1 Then

                        If drawopt Then

                        End If

                        For m As Integer = j To UBound(ari) - 1
                            If ari(m) <> ari(j) Then
                                j = m
                                GoTo lp

                            End If
                        Next
                        j = UBound(ari)

                    End If
                End If

                If Not arm Is Nothing Or Not arn Is Nothing Then

                    cmd.Connection = conn

                    DelTab("temp2")
z:
                    ordr = 0
                    If Not arm Is Nothing Then

                        instab("temp2", New Object() {CStr(a1.StrtPt.x), CStr(a1.StrtPt.y), CStr(a1.StrtPt.z), CStr(1)})

                    End If

                    If Not arn Is Nothing Then

                        instab("temp2", New Object() {CStr(b1.StrtPt.x), CStr(b1.StrtPt.y), CStr(b1.StrtPt.z), CStr(2)})

                    End If

                    If Not art Is Nothing Then

                        instab("temp2", New Object() {CStr(art.StrtPt.x), CStr(art.StrtPt.y), CStr(art.StrtPt.z), CStr(3)})

                    End If

                    Dim rwx As DataRow() = Nothing

                    Try
                        If Not arm Is Nothing Then

                            rwx = getf("temp2", "", "z DESC ,x ASC,y ASC")

                        End If

                        If Not arn Is Nothing Then

                            rwx = getf("temp2", "", "z DESC ,x ASC,y ASC")

                        End If

                        If arn Is Nothing And arm Is Nothing Then

                            rwx = getf("temp2", "", "z DESC ,x ASC")

                        End If

                        If arm Is Nothing And arn Is Nothing Then

                            rwx = getf("temp2", "", "z DESC ,x ASC,y ASC")

                        End If

                    Catch Err As Exception

                        MsgBox(Err.Message)
                        MsgBox(Err.ToString)
                        MessageBox.Show("Error in BoxStuff", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        'MsgBox(Ex.Message, MsgBoxStyle.Critical, "Exception :: In Function 'Stuff' " & vbCrLf & "Programme Running is failure!")

                    Finally
                        ordr = rwx(0)("i")
                    End Try

                    If ordr = 3 Then
                        stk.RemoveAt(arm1)
                    Else
                        If ordr = 1 Then
                            art = a1
                            stk.RemoveAt(arm(0))
                            If arm(0) < arm(1) Then
                                stk.RemoveAt(arm(1) - 1)
                            Else
                                stk.RemoveAt(arm(1))
                            End If

                            stk = UnPush(stk, a2)

                        End If

                        If ordr = 2 Then
                            If pos1 = 1 Then
                                Dim tmp As Double = ar(j).width
                                ar(j).width = ar(j).length
                                ar(j).length = tmp
                            End If

                            If pos1 = 2 Then
                                Dim tmp As Double = ar(j).height
                                ar(j).height = ar(j).width
                                ar(j).width = tmp
                            End If

                            art = b1
                            stk.RemoveAt(arn(0))
                            If arn(0) < arn(1) Then
                                stk.RemoveAt(arn(1) - 1)
                            Else
                                stk.RemoveAt(arn(1))
                            End If

                            stk.Add(b2)

                        End If
                        If ordr = 3 Then
                            stk.RemoveAt(arm1)
                        End If
                    End If
                Else
                    If arm1 <> -1 Then
                        stk.RemoveAt(arm1)
                    End If
                End If

                Dim qty As Integer

                If chngflg Then

                    'Stop

                    '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

                    Dim optmFnd As New OptMthd.OptMthd.FndOptMthd
                    Dim BxPt As New OptMthd.OptMthd.FndOptMthd.Areas
                    Dim ContPt As New OptMthd.OptMthd.FndOptMthd.Areas

                    BxPt.length = ar(j).length
                    BxPt.width = ar(j).width
                    BxPt.height = ar(j).height
                    BxPt.StrtPt.x = ar(j).StrtPt.x
                    BxPt.StrtPt.y = ar(j).StrtPt.y
                    BxPt.StrtPt.z = ar(j).StrtPt.z

                    ContPt.length = art.length
                    ContPt.width = art.width
                    ContPt.height = art.height
                    ContPt.StrtPt.x = art.StrtPt.x
                    ContPt.StrtPt.y = art.StrtPt.y
                    ContPt.StrtPt.z = art.StrtPt.z

                    ii = optmFnd.FindOptMethod(BxPt, ContPt, qty, topup(j))

                    '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

                    If Occ > 1 Then
                        Dim occlst1 As New List(Of Integer)

                        For i As Integer = 0 To OccLst.Count - 1
                            occlst1.Add(OccLst(i))
                        Next

                        Dim mmm1 As New occ1
                        mmm1.j = j
                        mmm1.j1 = occlst1
                        mmm1.stk = stk
                        OptLst.Add(mmm1)
                    End If

                    Dim ln As Double = ar(j).length
                    Dim wd As Double = ar(j).width
                    Dim ht As Double = ar(j).height

                    Dim Xx As Double = ar(j).StrtPt.x
                    Dim Yy As Double = ar(j).StrtPt.y
                    Dim Zz As Double = ar(j).StrtPt.z

                    Dim nm As String = ari(j)
                    Dim p As Integer = j

                    'Stop

                    If StpMthd <> ii Then

                        If TransactionMenu.btnStepTrials.BackColor = Color.HotPink Then

                            Dim stpFnm As String = CurDir() & "\OutPut\Firststp" & StepCount & ".wrl"

                            StepCount += 1

                            off.Flush()

                            My.Computer.FileSystem.CopyFile(outfile, stpFnm, False)

                            frmStep.AddSteps(StepCount)

                            offs = New IO.StreamWriter(stpFnm, True)
                            offs.AutoFlush = True
                            offs.Flush()
                            offs.WriteLine("")
                            offs.WriteLine("]}]}]}]}]}")
                            offs.WriteLine("")
                            offs.Flush()
                            offs.Dispose()
                            offs.Close()

                            If TransactionMenu.chkbxStpShow.Checked Then
                                Call StepNows(stpFnm)
                            End If

                            'off.WriteLine("")
                            'off.WriteLine("]}]}]}]}]}")
                            'off.WriteLine("")
                            'off.Flush()
                            Try
                                off.Flush()
                            Catch ex As Exception

                            End Try

                            'MsgBox("OK")

                        End If

                        If stpFlg Then

                            'If TransactionMenu.chkbxStpShow.Checked Then
                            '    'MessageBox.Show("The orientation of the stuffing items is changed." & "The '" & ari(j) & "' stuffing progress.", "P-Stuff info.....", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            '    Call StepNow()
                            'End If

                        End If

                        stpFlg = True

                    End If

                    StpMthd = ii

                    'ar(p).length = ln
                    'ar(p).width = wd
                    'ar(p).height = ht

                    If ii = 1 Then

                        ar(p).length = ln
                        ar(p).width = wd
                        ar(p).height = ht

                    End If

                    If ii = 2 Then
                        ar(p).length = ln
                        ar(p).width = ht
                        ar(p).height = wd

                    End If

                    If ii = 3 Then
                        ar(p).length = wd
                        ar(p).width = ht
                        ar(p).height = ln

                    End If

                    If ii = 4 Then
                        ar(p).length = wd
                        ar(p).width = ln
                        ar(p).height = ht

                    End If

                    If ii = 5 Then
                        ar(p).length = ht
                        ar(p).width = wd
                        ar(p).height = ln

                    End If

                    If ii = 6 Then
                        ar(p).length = ht
                        ar(p).width = ln
                        ar(p).height = wd

                    End If

                End If

                Dim flg As Boolean = Math.Abs(((ar(j).length * ar(j).width * ar(j).height) * qty) - (art.length * art.width * art.height)) < 0.01

                'Dim mm As Integer = findqty(ari, j)

                'Stop

                'Implements from here

                '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

                'If mm >= qty And flg Then

                '    'Stop

                '    If drawopt Then
                '        If transparr(j) Then
                '            traval = 0.8
                '        Else
                '            traval = 0
                '        End If
                '        ar(j).StrtPt.x = art.StrtPt.x
                '        ar(j).StrtPt.y = art.StrtPt.y
                '        ar(j).StrtPt.z = art.StrtPt.z
                '        ar(j).AutoDraw(outfile, Bcol, traval, "file:///c:/t2.png", ari(j), arwt(j), qtyflg, txtopt, "", 0, True, "c")
                '        j += qty
                '        Bitemqty += qty
                '    Else
                '        j += qty

                '        Bitemqty += qty
                '        Bplclst(Bitemno) = Bitemqty
                '        Btotwt += arwt(j)
                '        GoTo lp
                '    End If

                'End If

                '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

                arm = Nothing
                arn = Nothing

                '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
                '                Dim Wl As Double = 0

                '                If art.StrtPt.z = 0 And imgname <> "1" Then
                '                    'Stop
                '                    Wl = Ydm + ar(j).width
                '                    Ydm = art.StrtPt.y



                '                End If

                '                If art.StrtPt.y <> Wl + ar(j).width Then

                '                    'Dim Yl As Double = art.StrtPt.y - Wl


                '                    If imgname = "1" Then
                '                        GoTo Nxt
                '                    End If

                '                    ar(j).StrtPt.x = art.StrtPt.x
                '                    ar(j).StrtPt.y = art.StrtPt.y - Wl
                '                    ar(j).StrtPt.z = art.StrtPt.z

                '                Else

                'Nxt:
                '                    ar(j).StrtPt.x = art.StrtPt.x
                '                    ar(j).StrtPt.y = art.StrtPt.y
                '                    ar(j).StrtPt.z = art.StrtPt.z


                '                End If


                ar(j).StrtPt.x = art.StrtPt.x
                ar(j).StrtPt.y = art.StrtPt.y
                ar(j).StrtPt.z = art.StrtPt.z

                '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

                If saveopt Then
m:
                    Try
                        cmd.ExecuteNonQuery()
                    Catch ec As Exception
                        If ec.Message = "Cannot open any more tables." Then
                            conn.Close()
                            conn.Dispose()
                            OleDb.OleDbConnection.ReleaseObjectPool()
                            cmd.Dispose()
                            GC.Collect()

                            conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\container.mdb;Persist Security Info=False"

                            conn.Open()
                            GoTo m
                        End If

                    End Try
                    id1 += 1
                End If

                If drawopt Then

                    If transparr(j) Then
                        traval = 0.8
                    Else
                        traval = 0
                    End If
                End If

                If j = UBound(ar) Then

                End If

                If drawopt Then

                    If j <> 0 Then

                        If ari(j) <> ari(j - 1) Then

                            tmplst.Add(ari(j - 1))
                            tmplst.Add(CStr(totar))
                            Bareaarr.Add(tmplst)
                            totar = 0
                            totar = totar + (ar(j).length * ar(j).width * ar(j).height)

                        Else

                            totar = totar + (ar(j).length * ar(j).width * ar(j).height)

                        End If

                    Else

                        totar = totar + (ar(j).length * ar(j).width * ar(j).height)

                    End If
                End If

                '######################

                'off.WriteLine("")

                'off.WriteLine("# Program number " & BitemqtyInr)

                'off.WriteLine("")

                '######################

                'Stop

                Dim nl As New Area

                nl.length = ar(j).length
                nl.width = ar(j).width
                nl.height = ar(j).height
                nl.StrtPt.x = ar(j).StrtPt.x
                nl.StrtPt.y = ar(j).StrtPt.y
                nl.StrtPt.z = ar(j).StrtPt.z

                'If imgname <> "1" Then

                '    If nl.StrtPt.y > Yax Then
                '        ar(j).StrtPt.y = Yax
                '    End If

                'End If

                '######################

                'Stop

                If j = 2 Then

                    'Stop

                End If

                'off.Close()

                If drawopt Then
                    txtopt = True

                    'Stop

                    ' To drawing (writing) the main geometry program in VRML in to the
                    ' First.wrl file is done in this routine.

                    'ar(j).AutoDraw(outfile, Bcol, traval, "file:///c:/s" & imgname & ".png", ari(j), arwt(j), qtyflg, txtopt, ari(j), ii, True, "b")
                    'ar(j).AutoDraw(outfile, Bcol, traval, "file:///c:/s" & imgname & ".png", ari(j), arwt(j), qtyflg, txtopt, ari(j), ii, True, "b", imgname)

                    'If Not TransactionMenu.pilotFlg Then
                    ar(j).AutoDraw(outfile, Bcol, traval, CurDir() & "\Graphics/s" & imgname & ".png", ari(j), arwt(j), qtyflg, txtopt, ari(j), ii, True, "b", imgname)
                    'Else
                    'ar(j).DataBaseEntry(ari(j), ii, Bcol, CurDir() & "\Graphics/s" & imgname & ".png", arwt(j), True)
                    'End If


                    Try
                        If Bqtylst.Count > 0 Then
                            Bplclst(rwidx) = Bitemqty
                        End If
                    Catch
                    End Try

                    Bitemqty += 1

                    If BitemqtyInr = 59 Then
                        'Stop
                        'off.Flush()
                        'off.Close()
                        'MsgBox("OK")
                        'Stop
                    End If

                Else
                    Bitemqty += 1
                    Btotwt += arwt(j)
                End If

                Try
                    If Bqtylst.Count > 1 Then
                        Bplclst(rwidx) = Bitemqty - 1
                        Bmaxqtylst.Add(Bitemqty - 1)
                    End If
                Catch
                End Try

                'Stop

                If Not IsNothing(ari) Then
                    Form8.i = Bitemqty
                    'Form8.Label2.Text = CStr(itemqty) & " Items stuffed"
                    'Form8.Label2.Refresh()

                    'TransactionsMenu.lblStatus.Text = " Numbers ::   " & CStr(itemqty) & "    -> Items stuffed"

                    TransactionMenu.lblStatus.Visible = True
                    'TransactionMenu.lblStatus.Text = CStr(itemqty) & " Items stuffed"

                    '$$$$$

                    'TransactionMenu.lblStatus.Text = " Numbers ::   " & CStr(bitemqty) & "    -> Items stuffed"
                    'TransactionMenu.lblStatus.Refresh()

                    'TransactionMenu.pbCSP1.Visible = True
                    'ProgressBarRunning()

                    '$$$$$

                    'Stop

                    BoxCounterRw(Bitemqty, BitemqtyInr, ari(j))

                    If Bitemqty = 9 Then

                        'Stop
                        'off.Close()

                        'MsgBox("OK")

                    End If

                    If BitemqtyInr = 136 Then

                        'Stop
                        'off.Close()

                    End If

                    'off.Close()


                    'Stop

                    '*****

                    If flgPause Then

                        PauseSec(SecPause)

                    End If
                    '*****

                    'Stop

                    'off.Close()

                    off.WriteLine("")

                    off.WriteLine("#***************************************************************************")
                    off.WriteLine("")
                    off.WriteLine("#    The Program Count is " & j + 1)
                    off.WriteLine("")
                    off.WriteLine("#***************************************************************************")

                    off.WriteLine("")

                    'If (j + 1) = 67 Then
                    '    MsgBox("Ok")
                    '    Stop
                    'End If

                    'If j = 67 Then
                    '    MsgBox("Ok")
                    '    Stop
                    'End If

                    System.Windows.Forms.Application.DoEvents()

                    'Uncomment the 4 lines below
                    'If exflg Then
                    '    exflg = False
                    '    GoTo lp
                    'End If
                End If

                'Stop

                '@!!!!!

                'off.WriteLine("")

                '@!!!!!

                Dim Lln As Double = art.length
                Dim Wwd As Double = art.width
                Dim Hht As Double = art.height

                'Dim Xx As Double = art.StrtPt.x
                'Dim Yy As Double = art.StrtPt.y
                'Dim Zz As Double = art.StrtPt.z

                'Dim Lns As Double = ar(j).length
                'Dim Wds As Double = ar(j).width
                'Dim Hts As Double = ar(j).height

                'Dim Xxs As Double = ar(j).StrtPt.x
                'Dim Yys As Double = ar(j).StrtPt.y
                'Dim Zzs As Double = ar(j).StrtPt.z

                q = art.subtract(ar(j))


                '###########################################
                'Dim Var As New Area

                'For k As Integer = 0 To stk.Count - 1

                '    Var = stk(k)

                '    If Var.StrtPt.x = 34 AndAlso Var.StrtPt.y = 60 Then
                '        Stop
                '        Exit For
                '        'off.Close()
                '    End If

                'Next
                '###########################################

                'Stop

                'off.Close()

                Dim dd As New Area

                If imgname <> "1" Then

                    'Try

                    '    Yax = stk.Item(stk.Count - 1).StrtPt.y

                    'Catch Ex As Exception
                    '    MsgBox(Ex.Message)
                    '    MsgBox(Ex.ToString)
                    '    MessageBox.Show("Error in assigning the value of Y axis in wad stuff", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    'End Try

                End If

                '*
                If Not q Is Nothing Then

                    If stk.Count = 0 Then

                        Do While Not q.Count = 0

                            dd = q.Dequeue

                            stk.Add(dd)

                        Loop

                    Else

                        Do While q.Count > 0
                            arb = q.Dequeue
                            ans1 = False

                            'Stop

                            stk = UnPush(stk, arb)

                            'Stop

                        Loop

                    End If

                End If

                '*

                'Stop

                If j > 2 Then

                    'Stop

                End If

                Dim ans2 As Boolean

                For i As Integer = 0 To stk.Count - 1
                    Dim arx As New Area
                    arx = stk(i)

                    'Stop

                    'off.Close()
                    'Dim JIL As Integer = j

                    stk = MrgX(stk, arx, ans2)

                    'Stop

                    If ans2 Then
                        Exit For
                    End If

                Next

                'Stop

                Dim nn1 As New r1

                Dim nn As New Area

                '#################################

                ar(j).Known_Value()

                '#################################

                nn.length = ar(j).length
                nn.width = ar(j).width
                nn.height = ar(j).height
                nn.StrtPt.x = ar(j).StrtPt.x
                nn.StrtPt.y = ar(j).StrtPt.y
                nn.StrtPt.z = ar(j).StrtPt.z
                nn1.ar = nn
                nn1.method = ii
                nn1.itmnm = ari(j)

                Dim mmm As New List(Of Area)

                For kk As Integer = 0 To stk.Count - 1
                    mmm.Add(stk(kk))
                Next

                nn1.stk = mmm

                Bahistarr.Add(nn1)

                j += 1


                'Stop
lp:
            Loop

            'Stop
            'RiQ += 1
            RiQ = dgv1.CurrentRow.Index
            TransactionMenu.dgv1.Item(15, RiQ).Value = Bitemqty

            BalQty = TransactionMenu.dgv1.Item(11, RiQ).Value
            BalQty = BalQty - Bitemqty

            If BalQty < 0 Then
                BalQty = 0
            End If

            TransactionMenu.dgv1(16, RiQ).Value = BalQty

            TransactionMenu.dgv1.Refresh()

            BxItmQty = Bitemqty

            fff()

            If j > 0 Then
                e2 = New e1
                e2.qty = Bitemqty
                e2.itmnm = ari(j - 1)
            End If

            stkj = New List(Of Area)
            For jj As Integer = 0 To stk.Count - 1
                stkj.Add(stk(jj))
            Next
            e2.stk = stkj
            If drawopt Then
                qtyarr.Add(e2)
            End If
            Bmaxqtylst.Add(Bitemqty)
            'Form8.Close()

            TransactionMenu.lblStatus.Visible = False
            TransactionMenu.lblStatusINm.Visible = False
            TransactionMenu.btnStatus.Visible = False

            '@
            TransactionMenu.btnPause.Visible = False
            TransactionMenu.lblSec.Visible = False
            TransactionMenu.mtxtbxPause.Visible = False
            TransactionMenu.pnlPbinfo.Visible = False
            TransactionMenu.pnlsp.Visible = False

            TransactionMenu.pbCSP1.Visible = False

            Eventless()

            Try
                If UBound(ar) >= j Then
                    fullflag = True
                End If

                If findqtyflg Then
                    stk.Clear()
                    For i As Integer = 0 To stk.Count - 1
                        If Not chk1(stk2(i), stk) Then
                            If Not chk11(stk2(i), stk) Then
                                stk.Add(stk2(i))
                            End If
                        End If
                    Next
                End If

                If drawopt Then
                    If UBound(ari) <> -1 Then
                        tmplst.Add(ari(j - 1))
                        tmplst.Add(CStr(totar))
                        Bareaarr.Add(tmplst)
                    End If
                End If

                'Implements from here 4 oct 2k8
                dgv1.CurrentCell = ccell

            Catch
            End Try

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Fatal error in BoxStuff" & vbCrLf & "Data Stuffing failure!", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            MsgBox("Application Exit!")
            off.Close()
            conn.Close()
            siSW.Close()
            ConDrm.Close()
            GC.Collect()
            Application.Exit()
        Finally
            conn.Close()
        End Try

        If drawopt Or drawarc Then

        End If
        qtyflg = True
        conn.Dispose()
        conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\container.mdb;Persist Security Info=False"
        conn.Open()

        Return stk

    End Function

    Public Function BoxStuff_MQt(ByVal arc As Area, ByVal ar() As Area, ByVal ari() As String, ByVal arwt() As Single, ByVal saveopt As Boolean, ByVal showempty As Boolean, ByVal outfile As String, ByVal drawarc As Boolean, ByVal transparr() As Boolean, ByVal topup() As Boolean, ByVal txtopt As Boolean, ByVal drawopt As Boolean, ByVal findqtyflg As Boolean, ByVal chngflg As Boolean, ByVal colarr As List(Of List(Of Byte))) As List(Of Area)

        Dim stk2 As New List(Of Area)
        Dim stk1 As New Stack(Of Area)
        Dim art As New Area
        Dim arp As New Area
        Dim are As New Area
        Dim aru As New Area
        Dim arb As New Area
        Dim q As New Queue(Of Area)
        Dim q1 As New Queue(Of Area)
        Dim q2 As New Queue(Of Area)

        Dim ans1 As Boolean
        Dim szchg As Integer = 0
        Dim cmd As New OleDb.OleDbCommand

        Dim qtyflg As Boolean = True
        Dim traval As Single
        Dim ard As New Area
        Dim arm As New List(Of Integer)
        Dim arm1 As Integer
        Dim lstm As New List(Of Area)
        Dim a1 As New Area
        Dim a2 As New Area
        Dim ordr As Integer
        Dim totar As Double
        Dim tmplst As New List(Of String)
        Dim answ As MsgBoxResult

        Dim olditemqty As Integer = 0
        Dim col As String
        Dim ii As Integer

        Dim stkj As New List(Of Area)

        Try
            If saveopt Then
                configid = InputBox("Enter Config Id")
            End If

            Dim ptx As New Point

            ptx.x = arc.length
            ptx.y = arc.width
            ptx.z = arc.height

            Dim col1 As New List(Of Byte)
            col1.Clear()
            col1.Add(255)
            col1.Add(255)
            col1.Add(255)
            col = "1"

            Dim itmnm As String = ""

            If drawarc Then
                Dim ard1 As New Area
                If drawarc Then

                End If
                ard.StrtPt.x = arc.length
                ard.StrtPt.y = 0
                ard.StrtPt.z = 0
                ard.length = 0.5
                ard.width = arc.width
                ard.height = arc.height

                If drawopt Or drawarc Then

                End If

                ard1.StrtPt.x = arc.length - 0.01
                ard1.StrtPt.y = 0
                ard1.StrtPt.z = 0
                ard1.length = 0.5
                ard1.width = ard.width
                ard1.height = ard.height

                If drawopt Or drawarc Then

                    col1.Clear()
                End If

            End If

            If saveopt Then
                cmd.Connection = conn
y:
                Try
                    cmd.ExecuteNonQuery()
                Catch ec As Exception
                    If ec.Message = "Cannot open any more tables." Then
                        conn.Close()
                        conn.Dispose()
                        OleDb.OleDbConnection.ReleaseObjectPool()
                        cmd.Dispose()
                        GC.Collect()

                        conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\container.mdb;Persist Security Info=False"

                        conn.Open()
                        GoTo y
                    End If

                End Try
                id1 += 1
            End If

            arc.StrtPt.x = 0
            arc.StrtPt.y = 0
            arc.StrtPt.z = 0

            Dim j As Integer = 0
            totar = 0
            Bareaarr.Clear()

            For i As Integer = 0 To stk.Count - 1
                stk2.Add(stk(i))
            Next

            Bitemqty = 0
            Btotwt = 0

            'Stop

            If Not IsNothing(ari) Then
                'Form8.Show()
                TransactionMenu.lblStatus.Visible = True
                TransactionMenu.lblStatusINm.Visible = True
                TransactionMenu.btnStatus.Visible = True

                '@
                TransactionMenu.btnPause.Visible = True
                TransactionMenu.mtxtbxPause.Visible = True
                TransactionMenu.lblSec.Visible = True

                TransactionMenu.pbCSP1.Visible = True
                ProgressBarRunning()

                If drawopt Then
                    'Form8.Button1.Visible = False
                    TransactionMenu.btnStatus.Visible = True

                    '@
                    TransactionMenu.btnPause.Visible = True
                    TransactionMenu.mtxtbxPause.Visible = True
                    TransactionMenu.lblSec.Visible = True

                End If

                'Form8.Focus()
                TransactionMenu.lblStatus.Focus()
            End If

            For i As Integer = 0 To Bqtylst.Count - 1
                Bplclst.Add(Bqtylst(i) - 1)
            Next

            fullflag = False
            olditemqty = 0
            Dim imgname As String = "1"

            Do While Not stk.Count = 0 And j <= UBound(ar)

                If j > 0 Then
                    If ari(j) <> ari(j - 1) Then
                        imgname = (CInt(imgname) + 1).ToString
                    End If
                End If

                ordr = 0

                If chkwt Then
                    Btotwt += arwt(j)
                    If Btotwt >= contcap Then

                        answ = MsgBox("Maximum weight capacity of the container is reached" & vbCrLf & "Do you want to proceed?", MsgBoxStyle.YesNo)
                        If answ = MsgBoxResult.No Then
                            fullflag = True

                            Exit Do

                        Else
                            fullflag = False

                            chkwt = False
                        End If

                    End If
                End If

                If j = 0 Then
                    col = Bstrtclr
                End If
                If j > 0 And Not IsNothing(ari) Then
                    If ari(j - 1) <> ari(j) Then
                        e2 = New e1
                        e2.qty = Bitemqty
                        e2.itmnm = ari(j - 1)
                        stkj = New List(Of Area)
                        For jj As Integer = 0 To stk.Count - 1
                            stkj.Add(stk(jj))
                        Next

                        e2.stk = stkj
                        If drawopt Then
                            qtyarr.Add(e2)
                        End If
                        If Bqtylst.Count > 0 Then

                        End If

                        Bmaxqtylst.Add(Bitemqty)

                        'Form8.Label1.Text = "Stuffing item:" & ari(j)
                        'Form8.Label1.Refresh()

                        TransactionMenu.lblStatusINm.Text = "Stuffing item : " & ari(j)
                        TransactionMenu.lblStatusINm.Refresh()
                    Else
                        'Form8.Label1.Text = "Stuffing item:" & ari(j)
                        'Form8.Label1.Refresh()

                        TransactionMenu.lblStatusINm.Text = "Stuffing item : " & ari(j)
                        TransactionMenu.lblStatusINm.Refresh()
                    End If
                Else
                    If j > 0 Then
                        'Form8.Show()
                        TransactionMenu.lblStatus.Visible = True
                        TransactionMenu.lblStatusINm.Visible = True
                        TransactionMenu.btnStatus.Visible = True

                        '@
                        TransactionMenu.btnPause.Visible = True
                        TransactionMenu.mtxtbxPause.Visible = True
                        TransactionMenu.lblSec.Visible = True

                        TransactionMenu.pbCSP1.Visible = True
                        ProgressBarRunning()

                        If drawopt Then
                            'Form8.Button1.Visible = False
                            TransactionMenu.btnStatus.Visible = False

                            '@
                            TransactionMenu.btnPause.Visible = False
                            TransactionMenu.lblSec.Visible = False
                            TransactionMenu.mtxtbxPause.Visible = False

                        End If

                        'Form8.Label1.Text = "Finding Maximum Quantity ....."
                        'Form8.Label1.Refresh()

                        TransactionMenu.lblStatus.Text = "Finding Maximum Quantity ....."
                        TransactionMenu.lblStatus.Refresh()
                    End If
                End If

                'Stop

                If drawopt Then
                    If j > 0 Then

                        If ari(j - 1) <> ari(j) Then

                            Bitemqty = 0

                            If col = "r" Then
                                col = "g"
                            ElseIf col = "g" Then
                                col = "b"
                            ElseIf col = "b" Then
                                col = "m"
                            ElseIf col = "m" Then
                                col = "c"
                            ElseIf col = "c" Then
                                col = "y"
                            End If

                            szchg += 1
                            qtyflg = True

                        Else
                            qtyflg = False
                        End If
                    End If
                End If

                If szchg <> 2 Then

                Else

                End If

                'Stop

                arm1 = findopt(stk, ar(j), topup(j))

                'Stop

                art = Nothing

                If arm1 <> -1 Then
                    art = stk(arm1)
                End If

                Dim arn As New List(Of Integer)
                Dim lstn As New List(Of Area)
                Dim b1 As New Area
                Dim b2 As New Area
                Dim pos1 As Integer
                arm = Nothing
                arn = Nothing

                'Stop

                arn = findcandidate1(stk, ar(j), topup(j))

                'Stop

                pos1 = 0

                If Not arn Is Nothing Then
                    pos1 = 0
                Else
                    Dim arxx As New Area

                    arxx.length = ar(j).width
                    arxx.width = ar(j).length
                    arxx.height = ar(j).height

                    arn = findcandidate1(stk, arxx, topup(j))

                    'Stop

                    If Not arn Is Nothing Then
                        pos1 = 1
                    Else
                        If Not topup(j) Then
                            arxx.length = ar(j).length
                            arxx.width = ar(j).height
                            arxx.height = ar(j).width

                            arn = findcandidate1(stk, arxx, False)

                            'Stop

                            If Not arn Is Nothing Then
                                pos1 = 2
                            End If
                        End If
                    End If
                End If

                'Stop

                If arn Is Nothing Then

                    'Stop

                    arm = findcandidate(stk, ar(j))


                    If Bitemqty = 127 Then
                        'Stop
                        'off.Close()
                        'Application.Exit()
                    End If

                    'Stop

                    'Stop

                    If Not arm Is Nothing Then
                        If arm(0) = arm1 Then arm = Nothing
                    End If
                End If
                If Not arm Is Nothing Then

                    'Stop

                    lstm = unionp(stk(arm(0)), stk(arm(1)))

                    'Stop

                    a1 = lstm(0)
                    a2 = lstm(1)
                End If

                If Not arn Is Nothing Then

                    'Stop

                    lstm = unionp(stk(arn(0)), stk(arn(1)))

                    'Stop
                    b1 = lstm(0)
                    b2 = lstm(1)

                End If

                If arm Is Nothing And arm1 = -1 Then

                    If drawopt Then

                    End If

                    For m As Integer = j To UBound(ari) - 1
                        If ari(m) <> ari(j) Then
                            j = m

                            GoTo lp

                        End If
                    Next
                    j = UBound(ari) + 1

                    GoTo lp

                Else

                    If arn Is Nothing And arm1 = -1 Then

                        If drawopt Then

                        End If

                        For m As Integer = j To UBound(ari) - 1
                            If ari(m) <> ari(j) Then
                                j = m
                                GoTo lp

                            End If
                        Next
                        j = UBound(ari)

                    End If

                End If

                If Not arm Is Nothing Or Not arn Is Nothing Then

                    cmd.Connection = conn

                    DelTab("temp2")
z:
                    ordr = 0
                    If Not arm Is Nothing Then

                        instab("temp2", New Object() {CStr(a1.StrtPt.x), CStr(a1.StrtPt.y), CStr(a1.StrtPt.z), CStr(1)})
                    End If

                    If Not arn Is Nothing Then
                        instab("temp2", New Object() {CStr(b1.StrtPt.x), CStr(b1.StrtPt.y), CStr(b1.StrtPt.z), CStr(2)})

                    End If

                    If Not art Is Nothing Then
                        instab("temp2", New Object() {CStr(art.StrtPt.x), CStr(art.StrtPt.y), CStr(art.StrtPt.z), CStr(3)})

                    End If

                    Dim rwx As DataRow() = Nothing

                    Try
                        If Not arm Is Nothing Then

                            rwx = getf("temp2", "", "z DESC ,x ASC,y ASC")
                        End If

                        If Not arn Is Nothing Then

                            rwx = getf("temp2", "", "z DESC ,x ASC,y ASC")
                        End If

                        If arn Is Nothing And arm Is Nothing Then

                            rwx = getf("temp2", "", "z DESC ,x ASC")
                        End If

                        If arm Is Nothing And arn Is Nothing Then

                            rwx = getf("temp2", "", "z DESC ,x ASC,y ASC")
                        End If

                    Catch Err As Exception

                        MsgBox(Err.Message)
                        MsgBox(Err.ToString)
                        MessageBox.Show("Error in BoxStuff_MQt", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        'MsgBox(Ex.Message, MsgBoxStyle.Critical, "Exception :: In Function 'Stuff' " & vbCrLf & "Programme Running is failure!")

                    Finally
                        ordr = rwx(0)("i")
                    End Try

                    If ordr = 3 Then
                        stk.RemoveAt(arm1)
                    Else
                        If ordr = 1 Then
                            art = a1
                            stk.RemoveAt(arm(0))
                            If arm(0) < arm(1) Then
                                stk.RemoveAt(arm(1) - 1)
                            Else
                                stk.RemoveAt(arm(1))
                            End If

                            stk = UnPush(stk, a2)

                        End If

                        If ordr = 2 Then
                            If pos1 = 1 Then
                                Dim tmp As Double = ar(j).width
                                ar(j).width = ar(j).length
                                ar(j).length = tmp
                            End If

                            If pos1 = 2 Then
                                Dim tmp As Double = ar(j).height
                                ar(j).height = ar(j).width
                                ar(j).width = tmp
                            End If

                            art = b1
                            stk.RemoveAt(arn(0))
                            If arn(0) < arn(1) Then
                                stk.RemoveAt(arn(1) - 1)
                            Else
                                stk.RemoveAt(arn(1))
                            End If

                            stk.Add(b2)

                        End If
                        If ordr = 3 Then
                            stk.RemoveAt(arm1)
                        End If
                    End If
                Else
                    If arm1 <> -1 Then
                        stk.RemoveAt(arm1)
                    End If
                End If

                'Stop

                Dim qty As Integer
                If chngflg Then

                    'Stop

                    ' This method is find out the maximum quantity is placed in the container 
                    ' in particular way that the as maximum quantity is fit into it.

                    ii = FindOptMethod(ar(j), art, qty, topup(j))

                    'Stop

                    If occ > 1 Then
                        Dim occlst1 As New List(Of Integer)

                        For i As Integer = 0 To occlst.Count - 1
                            occlst1.Add(occlst(i))
                        Next

                        Dim mmm1 As New occ1
                        mmm1.j = j
                        mmm1.j1 = occlst1
                        mmm1.stk = stk
                        optlst.Add(mmm1)
                    End If

                    Dim ln As Double = ar(j).length
                    Dim wd As Double = ar(j).width
                    Dim ht As Double = ar(j).height

                    Dim nm As String = ari(j)
                    Dim p As Integer = j

                    If ii = 1 Then

                        ar(p).length = ln
                        ar(p).width = wd
                        ar(p).height = ht

                    End If

                    If ii = 2 Then
                        ar(p).length = ln
                        ar(p).width = ht
                        ar(p).height = wd

                    End If

                    If ii = 3 Then
                        ar(p).length = wd
                        ar(p).width = ht
                        ar(p).height = ln

                    End If

                    If ii = 4 Then
                        ar(p).length = wd
                        ar(p).width = ln
                        ar(p).height = ht

                    End If

                    If ii = 5 Then
                        ar(p).length = ht
                        ar(p).width = wd
                        ar(p).height = ln

                    End If

                    If ii = 6 Then
                        ar(p).length = ht
                        ar(p).width = ln
                        ar(p).height = wd

                    End If

                End If

                Dim flg As Boolean = Math.Abs(((ar(j).length * ar(j).width * ar(j).height) * qty) - (art.length * art.width * art.height)) < 0.01

                Dim mm As Integer = findqty(ari, j)

                'Stop

                If mm >= qty And flg Then

                    'Stop

                    If drawopt Then
                        If transparr(j) Then
                            traval = 0.8
                        Else
                            traval = 0
                        End If
                        ar(j).StrtPt.x = art.StrtPt.x
                        ar(j).StrtPt.y = art.StrtPt.y
                        ar(j).StrtPt.z = art.StrtPt.z
                        'ar(j).AutoDraw(outfile, col, traval, "file:///c:/t2.png", ari(j), arwt(j), qtyflg, txtopt, "", 0, True, "c")
                        j += qty
                        Bitemqty += qty
                    Else
                        j += qty

                        Bitemqty += qty
                        Bplclst(Bitemno) = Bitemqty
                        Btotwt += arwt(j)
                        GoTo lp
                    End If

                End If

                arm = Nothing
                arn = Nothing

                ar(j).StrtPt.x = art.StrtPt.x
                ar(j).StrtPt.y = art.StrtPt.y
                ar(j).StrtPt.z = art.StrtPt.z

                If saveopt Then
m:
                    Try
                        cmd.ExecuteNonQuery()
                    Catch ec As Exception
                        If ec.Message = "Cannot open any more tables." Then
                            conn.Close()
                            conn.Dispose()
                            OleDb.OleDbConnection.ReleaseObjectPool()
                            cmd.Dispose()
                            GC.Collect()

                            conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\container.mdb;Persist Security Info=False"

                            conn.Open()
                            GoTo m
                        End If

                    End Try
                    id1 += 1
                End If

                If drawopt Then

                    If transparr(j) Then
                        traval = 0.8
                    Else
                        traval = 0
                    End If
                End If

                If j = UBound(ar) Then

                End If

                If drawopt Then

                    If j <> 0 Then

                        If ari(j) <> ari(j - 1) Then

                            tmplst.Add(ari(j - 1))
                            tmplst.Add(CStr(totar))
                            Bareaarr.Add(tmplst)
                            totar = 0
                            totar = totar + (ar(j).length * ar(j).width * ar(j).height)

                        Else

                            totar = totar + (ar(j).length * ar(j).width * ar(j).height)

                        End If

                    Else

                        totar = totar + (ar(j).length * ar(j).width * ar(j).height)

                    End If
                End If

                'Stop

                If drawopt Then
                    txtopt = True

                    'Stop

                    'ar(j).AutoDraw(outfile, col, traval, "file:///c:/s" & imgname & ".png", ari(j), arwt(j), qtyflg, txtopt, ari(j), ii, True, "b")

                    'Stop

                    If Bqtylst.Count > 0 Then
                        Bplclst(rwidx) = Bitemqty

                    End If

                    Bitemqty += 1

                Else
                    Bitemqty += 1
                    Btotwt += arwt(j)
                End If

                If Bqtylst.Count > 1 Then
                    Bplclst(rwidx) = Bitemqty - 1
                    Bmaxqtylst.Add(Bitemqty - 1)
                End If

                'Stop

                If Not IsNothing(ari) Then
                    Form8.i = Bitemqty
                    'Form8.Label2.Text = CStr(itemqty) & " Items stuffed"
                    'Form8.Label2.Refresh()

                    'TransactionsMenu.lblStatus.Text = " Numbers ::   " & CStr(itemqty) & "    -> Items stuffed"

                    TransactionMenu.lblStatus.Visible = True
                    'TransactionMenu.lblStatus.Text = CStr(itemqty) & " Items stuffed"

                    '$$$$$

                    'TransactionMenu.lblStatus.Text = " Numbers ::   " & CStr(bitemqty) & "    -> Items stuffed"
                    'TransactionMenu.lblStatus.Refresh()

                    'TransactionMenu.pbCSP1.Visible = True
                    'ProgressBarRunning()

                    '$$$$$

                    'Stop

                    BoxCounterRw(Bitemqty, BitemqtyInr, ari(j))

                    If Bitemqty = 350 Then
                        'Stop
                        'MsgBox("OK")

                    End If

                    If Bitemqty = 9 Then

                        'Stop
                        'off.Close()

                        'MsgBox("OK")

                    End If

                    If BitemqtyInr = 359 Then

                        'Stop
                        'MsgBox("Ok")

                    End If

                    If BitemqtyInr = 69 Then

                        'Stop
                        'off.Close()

                    End If

                    'Stop

                    '*****

                    If flgPause Then

                        PauseSec(SecPause)

                    End If
                    '*****

                    'Stop

                    'off.Close()


                    System.Windows.Forms.Application.DoEvents()
                    If exflg Then
                        exflg = False
                        GoTo lp
                    End If
                End If

                'Stop

                '@!!!!!

                off.WriteLine("")
                
                '@!!!!!


                q = art.subtract(ar(j))

                'Stop

                Dim dd As New Area

                If Not q Is Nothing Then

                    If stk.Count = 0 Then

                        Do While Not q.Count = 0

                            dd = q.Dequeue

                            stk.Add(dd)

                        Loop

                    Else

                        Do While q.Count > 0
                            arb = q.Dequeue
                            ans1 = False

                            'Stop

                            stk = UnPush(stk, arb)

                            'Stop

                        Loop

                    End If

                End If

                'Stop

                Dim ans2 As Boolean

                For i As Integer = 0 To stk.Count - 1
                    Dim arx As New Area
                    arx = stk(i)

                    'Stop

                    'off.Close()

                    stk = MrgX(stk, arx, ans2)

                    'Stop

                    If ans2 Then
                        Exit For
                    End If

                Next

                'Stop

                Dim nn1 As New r1

                Dim nn As New Area

                nn.length = ar(j).length
                nn.width = ar(j).width
                nn.height = ar(j).height
                nn.StrtPt.x = ar(j).StrtPt.x
                nn.StrtPt.y = ar(j).StrtPt.y
                nn.StrtPt.z = ar(j).StrtPt.z
                nn1.ar = nn
                nn1.method = ii
                nn1.itmnm = ari(j)

                Dim mmm As New List(Of Area)

                For kk As Integer = 0 To stk.Count - 1
                    mmm.Add(stk(kk))
                Next

                nn1.stk = mmm

                Bahistarr.Add(nn1)

                j += 1

               
lp:
            Loop

            fff()

            If j > 0 Then
                e2 = New e1
                e2.qty = Bitemqty
                e2.itmnm = ari(j - 1)
            End If

            stkj = New List(Of Area)
            For jj As Integer = 0 To stk.Count - 1
                stkj.Add(stk(jj))
            Next
            e2.stk = stkj
            If drawopt Then
                qtyarr.Add(e2)
            End If
            Bmaxqtylst.Add(Bitemqty)
            'Form8.Close()

            TransactionMenu.lblStatus.Visible = False
            TransactionMenu.lblStatusINm.Visible = False
            TransactionMenu.btnStatus.Visible = False

            '@
            TransactionMenu.btnPause.Visible = False
            TransactionMenu.lblSec.Visible = False
            TransactionMenu.mtxtbxPause.Visible = False

            TransactionMenu.pbCSP1.Visible = False

            Eventless()

            If UBound(ar) >= j Then
                fullflag = True
            End If

            If findqtyflg Then
                stk.Clear()
                For i As Integer = 0 To stk.Count - 1
                    If Not chk1(stk2(i), stk) Then
                        If Not chk11(stk2(i), stk) Then
                            stk.Add(stk2(i))
                        End If
                    End If
                Next
            End If

            If drawopt Then
                If UBound(ari) <> -1 Then
                    tmplst.Add(ari(j - 1))
                    tmplst.Add(CStr(totar))
                    Bareaarr.Add(tmplst)
                End If
            End If

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in BoxStuff_MQt" & vbCrLf & "Data Stuffing failure!", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            MsgBox("Application Exit!")
            off.Close()
            conn.Close()
            siSW.Close()
            ConDrm.Close()
            GC.Collect()
            Application.Exit()
        Finally
            conn.Close()
        End Try

        If drawopt Or drawarc Then

        End If
        qtyflg = True
        conn.Dispose()
        conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\container.mdb;Persist Security Info=False"
        conn.Open()

        Return stk

    End Function

    Private Function isgarb(ByVal ar1 As Area, ByVal j As Integer, ByVal ar() As Area) As Boolean

        Dim retval As Boolean = True

        Try
            For i As Integer = j To UBound(ar)
                If canaccom(ar1, ar(i)) Then
                    Return False
                End If
            Next

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in isgarb", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return True

    End Function

    Public Function canaccom(ByVal a1 As Area, ByVal a2 As Area) As Boolean

        Try

            Dim a3 As New Area
            Dim a4 As New Area
            a3.length = a1.length
            a3.width = a1.width
            a3.height = a1.height
            a4.length = a2.length
            a4.width = a2.width
            a4.height = a2.height
            If a3.subtract(a4) Is Nothing Then
                Return False
            Else
                Return True
            End If

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in canaccom", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function

    Public Function drwopt(ByVal ar1 As Area, ByVal ar2 As Area, ByVal fl As String, ByVal col As String, ByVal traval As Single, ByVal itmnm As String, ByVal wt As Single, ByVal qtyflg As Boolean, ByVal txtopt As Boolean, ByVal qty As Integer, ByVal drawopt As Boolean, ByRef outqty As Integer) As List(Of Area)

        Dim retlst As New List(Of Area)
        Try

            Dim lncnt As Integer
            Dim wdcnt As Integer
            Dim htcnt As Integer
            Dim ar As New Area

            lncnt = CInt(Math.Floor(ar1.length / ar2.length))
            wdcnt = CInt(Math.Floor(ar1.width / ar2.width))
            htcnt = CInt(Math.Floor(ar1.height / ar2.height))

            ar.length = ar2.length
            ar.width = ar2.width
            ar.height = ar2.height

            Dim cnt As Integer = 0

            For i As Integer = 0 To htcnt - 1

                ar.StrtPt.z = ar2.StrtPt.z + (i * ar.height)

                For k As Integer = 0 To lncnt - 1

                    ar.StrtPt.x = ar2.StrtPt.x + (k * ar.length)

                    For j As Integer = 0 To wdcnt - 1

                        ar.StrtPt.y = ar2.StrtPt.y + (j * ar.width)

                        cnt += 1

                        If cnt > qty Then
                            outqty = cnt
                            Return Nothing
                            Exit Function
                        End If

                        'Call ProgressBarRunning()

                        If drawopt Then
                            'ar.AutoDraw("c:\addd.wrl", "r", 0, "file:///c:/t2.png", itmnm, wt, qtyflg, txtopt, itmnm, 0, True, "b")
                            'ar.AutoDraw(CurDir() & "\First.wrl", "r", 0, "file:///c:/s1.png", itmnm, wt, qtyflg, txtopt, itmnm, 0, True, "b", "1")

                            ar.AutoDraw(CurDir() & "\First.wrl", "r", 0, CurDir() & "\Graphics/s1.png", itmnm, wt, qtyflg, txtopt, itmnm, 0, True, "b", "1")

                        End If
                    Next

                Next
                'Stop
            Next

            Dim arr1 As New Area
            Dim arr2 As New Area
            Dim arr3 As New Area

            arr1.StrtPt.x = CDbl(Format(ar1.StrtPt.x + (ar2.length * lncnt), "0.0000"))
            arr1.StrtPt.y = CDbl(Format(ar1.StrtPt.y, "0.0000"))
            arr1.StrtPt.z = ar1.StrtPt.z
            arr1.length = CDbl(Format(ar1.length - (ar2.length * lncnt), "0.0000"))
            arr1.width = ar1.width
            arr1.height = ar1.height

            arr2.StrtPt.x = ar1.StrtPt.x
            arr2.StrtPt.y = ar1.StrtPt.y
            arr2.StrtPt.z = CDbl(Format(ar1.StrtPt.z + (ar2.height * htcnt), "0.0000"))
            arr2.length = ar2.length * lncnt
            arr2.width = ar2.width * wdcnt
            arr2.height = CDbl(Format(ar1.height - (ar2.height * htcnt), "0.0000"))

            arr3.StrtPt.x = ar1.StrtPt.x
            arr3.StrtPt.y = CDbl(Format(ar1.StrtPt.y + (ar2.width * wdcnt), "0.0000"))
            arr3.StrtPt.z = ar1.StrtPt.z
            arr3.length = ar2.length * lncnt
            arr3.width = CDbl(Format(ar1.width - (ar2.width * wdcnt), "0.0000"))
            arr3.height = ar2.height * htcnt

            If arr1.length > 0 AndAlso arr1.width > 0 AndAlso arr1.height > 0 Then
                retlst.Add(arr1)
            End If

            If arr2.length > 0 AndAlso arr2.width > 0 AndAlso arr2.height > 0 Then
                retlst.Add(arr2)
            End If

            If arr3.length > 0 AndAlso arr3.width > 0 AndAlso arr3.height > 0 Then
                retlst.Add(arr3)
            End If

            outqty = cnt
            Return retlst

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in drwopt", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return retlst

    End Function

    Public Function findqty(ByVal itmarr() As String, ByVal strtpos As Integer) As Integer

        Try

            Dim nm As String = itmarr(strtpos)
            Dim i As Integer

            For i = strtpos To UBound(itmarr)
                If itmarr(i) <> nm Then
                    Exit For
                End If
            Next

            Return i - strtpos

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in findqty", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function

    Public Structure arwi

        Public ar As Area
        Public ordr As Integer

    End Structure

    Public Function WadFindOpt(ByVal Bstk As List(Of Area), ByVal Ar As Area, ByVal TpUp As Boolean) As Integer

        Dim Al As New List(Of arwi)
        Dim Cmd As New OleDb.OleDbCommand
        Cmd.Connection = conn
        Dim iLst As New List(Of Integer)
        Dim Ar1 As New Area
        Dim Ordr As Integer
        Dim Arw As New arwi

        Try
            For i As Integer = 0 To Bstk.Count - 1
                If WadFtip(Bstk.Item(i), Ar, TpUp) Then                 'If Form4.WadFtip(Bstk.Item(i), Ar, TpUp) Then

                    Arw.ar = Bstk.Item(i)
                    Arw.ordr = i
                    Al.Add(Arw)

                    iLst.Add(i)
                End If
            Next

            'Stop

            DelTabWad("temp2")

            Dim arl As New ArrayList
            For i As Integer = 0 To Al.Count - 1
                Ar1 = Al(i).ar
                InstabWad("temp2", New Object() {CStr(Ar1.StrtPt.x), CStr(Ar1.StrtPt.y), CStr(Ar1.StrtPt.z), CStr(iLst(i))})

                arl.Add(Al(i))
            Next

            'Stop

            Dim iii As DataRow()

            iii = GetfWad("temp2", "", "z desc ,x asc,y asc")

            'iii = getf("temp2", "", "z asc ,x desc,y desc")

            If iii.Length = 1 Then
                Return -1
            End If
            Ordr = iii(0)("i")

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in findopt", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return Ordr

    End Function

    Public Function VertexReturn(ByVal Stk As List(Of Area), ByVal Ar As Area, ByVal TpUp As Boolean) As List(Of Area)

        
        Return Stk

    End Function

    Public Function findopt(ByVal stk As List(Of Area), ByVal ar As Area, ByVal tpup As Boolean) As Integer

        Dim al As New List(Of arwi)
        Dim cmd As New OleDb.OleDbCommand
        cmd.Connection = conn
        Dim ilst As New List(Of Integer)
        Dim ar1 As New Area
        Dim ordr As Integer
        Dim arw As New arwi

        Try
            For i As Integer = 0 To stk.Count - 1

                If Form4.ftip(stk.Item(i), ar, tpup) Then

                    arw.ar = stk.Item(i)
                    arw.ordr = i
                    al.Add(arw)

                    ilst.Add(i)

                End If
            Next

            'Stop

            DelTab("temp2")

            Dim arl As New ArrayList

            For i As Integer = 0 To al.Count - 1
                ar1 = al(i).ar
                instab("temp2", New Object() {CStr(ar1.StrtPt.x), CStr(ar1.StrtPt.y), CStr(ar1.StrtPt.z), CStr(ilst(i))})

                arl.Add(al(i))
            Next

            'Stop

            Dim iii As DataRow()

            iii = getf("temp2", "", "z desc ,x asc,y asc")

            'iii = getf("temp2", "", "z asc ,x desc,y desc")

            If iii.Length = 1 Then
                Return -1
            End If
            ordr = iii(0)("i")

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in findopt", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return ordr

    End Function

    Public Function findoptx(ByVal stk As List(Of Area), ByVal ar As Area, ByVal tpup As Boolean) As Integer

        Dim al As New List(Of arwi)
        Dim cmd As New OleDb.OleDbCommand
        cmd.Connection = conn
        Dim ilst As New List(Of Integer)
        Dim ar1 As New Area
        Dim ordr As Integer
        Dim arw As New arwi

        Try
            For i As Integer = 0 To stk.Count - 1
                If Form4.ftip(stk.Item(i), ar, tpup) Then
                    arw.ar = stk.Item(i)
                    arw.ordr = i
                    al.Add(arw)

                    ilst.Add(i)
                End If
            Next

            DelTab("temp5")

            Dim arl As New ArrayList
            For i As Integer = 0 To al.Count - 1
                ar1 = al(i).ar
                instab("temp5", New Object() {CStr(ar1.StrtPt.x), CStr(ar1.StrtPt.y), CStr(ar1.StrtPt.z), CStr(ilst(i))})

                arl.Add(al(i))
            Next
            Dim iii As DataRow()

            iii = getf("temp5", "", "z asc ,x asc ,y asc")
            If iii.Length = 1 Then
                Return -1
            End If
            ordr = iii(0)("i")
            If ordr = 9999 Then
                ordr = iii(1)("i")
            End If

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in findoptx", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return ordr

    End Function

    Public Function UnPushWad(ByVal StkX As List(Of Area), ByVal Ar As Area) As List(Of Area)

        Dim S1 As New List(Of Area)
        Dim A1 As Area
        Dim Flag As Boolean = False

        Dim Stky As New List(Of Area)
        Dim ArAr As Area()
        Dim Arf As New Area
        Dim Kk As New List(Of Area)
        Dim Kk1 As New List(Of Area)

        Try
            Ar.StrtPt.x = Math.Round(Ar.StrtPt.x, 4)
            Ar.StrtPt.y = Math.Round(Ar.StrtPt.y, 4)
            Ar.StrtPt.z = Math.Round(Ar.StrtPt.z, 4)

            Ar.length = Math.Round(Ar.length, 4)
            Ar.width = Math.Round(Ar.width, 4)
            Ar.height = Math.Round(Ar.height, 4)

            For i As Integer = 0 To Stky.Count - 1
                StkX.Add(Stky(i))
            Next

            ArAr = StkX.ToArray

            For j As Integer = LBound(ArAr) To UBound(ArAr)
                A1 = ArAr(j)

                If A1.UnionItrXWad(Ar) Is Nothing Then

                Else
                    Flag = True
                End If

            Next

            If Not Flag Then

                StkX.Add(Ar)
                Return StkX

            Else

                Arf = Nothing
                Kk.Clear()

                Do While StkX.Count > 0

                    A1 = StkX.Item(StkX.Count - 1)

                    A1.StrtPt.x = Math.Round(A1.StrtPt.x)
                    A1.StrtPt.y = Math.Round(A1.StrtPt.y)
                    A1.StrtPt.z = Math.Round(A1.StrtPt.z)

                    A1.length = Math.Round(A1.length)
                    A1.width = Math.Round(A1.width)
                    A1.height = Math.Round(A1.height)

                    StkX.RemoveAt(StkX.Count - 1)

                    If A1.UnionItrXWad(Ar) Is Nothing Then

                        S1.Add(A1)

                    Else

                        Arf = A1.UnionItrXWad(Ar)
                        Kk.Add(Arf)
                        Kk1.Add(A1)

                    End If

                Loop

            End If

            Dim III As DataRow()
            Dim II As Integer
            DelTabWad("temp4")
            Dim Ar1 As New Area

            If Kk.Count = 1 Then

                S1.Add(Kk(0))

            Else
                For i As Integer = 0 To Kk.Count - 1
                    Ar1 = Kk(i)
                    InstabWad("temp4", New Object() {CStr(Ar1.StrtPt.x), CStr(Ar1.StrtPt.y), CStr(Ar1.StrtPt.z), CStr(i)})
                Next

                III = GetfWad("temp4", "", "z asc, x asc, y asc")
                II = III(0)("i")

                For j As Integer = 0 To Kk.Count - 1

                    If j = II Then
                        S1.Add(Kk(j))
                    Else
                        S1.Add(Kk1(j))
                    End If
                Next

            End If

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in UnPushWad", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return S1

    End Function

    Public Function UnPush(ByVal stkx As List(Of Area), ByVal ar As Area) As List(Of Area)
        'Stop
        Dim s1 As New List(Of Area)
        Dim a1 As Area
        Dim flag As Boolean = False

        Dim stky As New List(Of Area)
        Dim arar As Area()
        Dim arf As New Area
        Dim kk As New List(Of Area)
        Dim kk1 As New List(Of Area)

        Try

            ar.StrtPt.x = Math.Round(ar.StrtPt.x, 4)
            ar.StrtPt.y = Math.Round(ar.StrtPt.y, 4)
            ar.StrtPt.z = Math.Round(ar.StrtPt.z, 4)

            ar.length = Math.Round(ar.length, 4)
            ar.width = Math.Round(ar.width, 4)
            ar.height = Math.Round(ar.height, 4)

            Dim X As Double = ar.StrtPt.x
            Dim Y As Double = ar.StrtPt.y
            Dim Z As Double = ar.StrtPt.z

            Dim Ln As Double = ar.length
            Dim Wd As Double = ar.width
            Dim Ht As Double = ar.height

            For i As Integer = 0 To stky.Count - 1
                stkx.Add(stky(i))
            Next

            arar = stkx.ToArray


            'The commented it

            'For i As Integer = LBound(arar) To UBound(arar)
            '    a1 = arar(i)

            '    If a1.UnionItrX(ar) Is Nothing Then

            '    Else

            '        flag = True
            '    End If

            'Next

            If Not flag Then

                stkx.Add(ar)

                Return stkx
            Else

                arf = Nothing
                kk.Clear()

                Do While stkx.Count > 0

                    a1 = stkx.Item(stkx.Count - 1)

                    a1.StrtPt.x = Math.Round(a1.StrtPt.x, 4)
                    a1.StrtPt.y = Math.Round(a1.StrtPt.y, 4)
                    a1.StrtPt.z = Math.Round(a1.StrtPt.z, 4)

                    a1.length = Math.Round(a1.length, 4)
                    a1.width = Math.Round(a1.width, 4)
                    a1.height = Math.Round(a1.height, 4)

                    stkx.RemoveAt(stkx.Count - 1)

                    If a1.UnionItrX(ar) Is Nothing Then

                        s1.Add(a1)

                    Else
                        arf = a1.UnionItrX(ar)
                        kk.Add(arf)
                        kk1.Add(a1)

                    End If

                Loop

            End If

            Dim iii As DataRow()
            Dim ii As Integer
            DelTab("temp4")
            Dim ar1 As New Area

            If kk.Count = 1 Then
                s1.Add(kk(0))

            Else
                For i As Integer = 0 To kk.Count - 1
                    ar1 = kk(i)
                    instab("temp4", New Object() {CStr(ar1.StrtPt.x), CStr(ar1.StrtPt.y), CStr(ar1.StrtPt.z), CStr(i)})
                Next

                iii = getf("temp4", "", "z asc ,x asc ,y asc")
                ii = iii(0)("i")

                For i As Integer = 0 To kk.Count - 1
                    If i = ii Then

                        s1.Add(kk(i))

                    Else

                        s1.Add(kk1(i))

                    End If

                Next
            End If

            '###########################################
            'Dim Var As New Area

            'For k As Integer = 0 To stk.Count - 1

            '    Var = stk(k)

            '    If Var.StrtPt.x = 34 AndAlso Var.StrtPt.y = 60 Then

            '    End If

            'Next
            '###########################################

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in UnPush", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return s1

    End Function

    Public Function qpush(ByVal stkx As Queue(Of Area), ByVal ar As Area, ByRef ans As Boolean) As Queue(Of Area)

        Dim s1 As New Queue(Of Area)
        Dim a1 As Area
        Dim flag As Boolean = False
        Dim stky As New Stack(Of Area)
        Dim arar As Area()

        Try
            arar = stkx.ToArray

            For i As Integer = LBound(arar) To UBound(arar)
                a1 = arar(i)

                If a1.UnionItrX(ar) Is Nothing Then

                Else

                    flag = True
                    ans = True
                End If

            Next

            If Not flag Then

                stkx.Enqueue(ar)
                Return stkx
            Else

                Do While stkx.Count > 0
                    a1 = stkx.Dequeue
                    If a1.UnionItrX(ar) Is Nothing Then
                        s1.Enqueue(a1)
                    Else
                        s1.Enqueue(a1.UnionItrX(ar))

                    End If

                Loop

            End If

            Dim s2 As New Queue(Of Area)

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in qpush", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return s1

    End Function

    Public Function qpush1(ByVal stkx As Queue(Of Area), ByVal ar As Area, ByRef ans As Boolean) As Queue(Of Area)

        Dim s1 As New Queue(Of Area)
        Dim a1 As Area
        Dim flag As Boolean = False
        Dim stky As New Stack(Of Area)
        Dim arar As Area()

        Try

            arar = stkx.ToArray
            ans = False
            For i As Integer = LBound(arar) To UBound(arar)
                a1 = arar(i)

                If a1.UnionItrX(ar) Is Nothing Then

                Else

                    flag = True
                    ans = True
                End If

            Next

            If Not flag Then

                Return stkx
            Else

                Do While stkx.Count > 0
                    a1 = stkx.Dequeue
                    If a1.UnionItrX(ar) Is Nothing Then
                        s1.Enqueue(a1)
                    Else
                        s1.Enqueue(a1.UnionItrX(ar))

                    End If

                Loop

            End If

            Dim s2 As New Queue(Of Area)

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in qpush1", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return s1

    End Function

    Function q1draw(ByRef q1 As Queue(Of Area), ByVal ar As Area, ByVal itmnm As String, ByVal wt As Single, ByRef ans As Boolean, ByVal saveopt As Boolean, ByVal outfile As String, ByVal qtyflg As Boolean, ByVal transpflg As Boolean) As Queue(Of Area)

        Dim q2 As New Queue(Of Area)
        Dim q3 As New Queue(Of Area)
        Dim q4 As New Queue(Of Area)
        Dim q5 As New Queue(Of Area)
        Dim q6 As New Queue(Of Area)
        Dim q7 As New Queue(Of Area)
        Dim q8 As New Queue(Of Area)
        Dim qa As New Queue(Of Area)
        Dim qb As New Queue(Of Area)
        Dim qc As New Queue(Of Area)
        Dim qd As New Queue(Of Area)
        Dim qe As New Queue(Of Area)
        Dim qf As New Queue(Of Area)
        Dim qw As New Queue(Of Area)
        Dim qa1 As New Queue(Of Area)
        Dim qa2 As New Queue(Of Area)
        Dim qa3 As New Queue(Of Area)
        Dim ar1 As New Area
        Dim ar2 As New Area
        Dim ara As New Area
        Dim arb As New Area
        Dim arc As New Area
        Dim ard As New Area
        Dim are As New Area
        Dim arm As New Area
        Dim arx As New Area
        Dim stkj As New Stack(Of Area)
        Dim cnt1 As Integer
        Dim cnt2 As Integer
        Dim j As Integer
        Dim drawpos As Integer
        Dim traval As Single

        ans = False

        Try
            Dim placed As Boolean = False
            Dim flg As Boolean
            Dim ert As New Integer
            Dim cmd As New OleDb.OleDbCommand

            For j = 0 To q1.Count - 1
                ar1 = q1.Dequeue
                q2.Enqueue(ar1)
                q3.Enqueue(ar1)
                qa.Enqueue(ar1)
                qc.Enqueue(ar1)
                qe.Enqueue(ar1)
            Next

            If drawpos = -1 Then
                ans = False
                Return q3
            Else
                ans = True
                For i As Integer = 0 To q3.Count - 1
                    ar1 = q3.Dequeue
                    If i = drawpos Then
                        ar.StrtPt.x = ar1.StrtPt.x
                        ar.StrtPt.y = ar1.StrtPt.y
                        ar.StrtPt.z = ar1.StrtPt.z
                        cmd.Connection = conn
                        If saveopt Then

                            id1 += 1
                        End If

                        If transpflg Then
                            traval = 0.8
                        Else
                            traval = 0
                        End If
                        Dim col As String = ""
                        ar.AutoDraw(outfile, col, traval, "file:///c:/t2.png", itmnm, wt, qtyflg, True, itmnm, 0, True, "b", "1")

                        ar.StrtPt.x = ar1.StrtPt.x
                        ar.StrtPt.y = ar1.StrtPt.y
                        ar.StrtPt.z = ar1.StrtPt.z
                        q5 = ar1.subtract(ar)
                        If Not q5 Is Nothing Then
                            Do While q5.Count > 0
                                arc = q5.Dequeue
                                q6.Enqueue(arc)
                                qb.Enqueue(arc)
                                qd.Enqueue(arc)
                                qf.Enqueue(arc)
                            Loop

                            cnt1 = qa.Count
                            cnt2 = q6.Count

                            For x As Integer = 0 To qa.Count - 1

                                ara = qa.Dequeue

                                If x <> drawpos Then
                                    qa.Enqueue(ara)
                                    flg = False

                                    For y As Integer = 0 To q6.Count - 1
                                        arb = q6.Dequeue

                                        If ara.UnionItrX(arb) Is Nothing Then

                                            q6.Enqueue(arb)

                                        Else

                                            arx = (ara.UnionItrX(arb))
                                            flg = True
                                            Exit For

                                        End If

                                    Next

                                    If flg Then
                                        q4.Enqueue(arx)
                                    Else
                                        q4.Enqueue(ara)
                                    End If
                                End If

                            Next

                            For p As Integer = 0 To q6.Count - 1
                                qa1.Enqueue(q6.Dequeue)
                            Next

                            qa2 = revque(qa1)

                            For r As Integer = 0 To qa2.Count - 1
                                qa3.Enqueue(qa2.Dequeue)
                            Next

                            For r As Integer = 0 To q4.Count - 1
                                qa3.Enqueue(q4.Dequeue)
                            Next

                            Return qa3

                        End If
                    End If

                Next
            End If

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in q1draw", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try

        Return Nothing

    End Function

    Public Function revque(ByVal q As Queue(Of Area)) As Queue(Of Area)

        Dim ar As New Area
        Dim stk As New Stack(Of Area)
        Dim qax As New Queue(Of Area)

        Try
            For i As Integer = 0 To q.Count - 1
                ar = q.Dequeue
                stk.Push(ar)
                q.Enqueue(ar)
            Next
            For i As Integer = 0 To stk.Count - 1
                qax.Enqueue(stk.Pop)
            Next
        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in revque", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return qax

    End Function

    Public Function Drwidx(ByVal q As Queue(Of Area), ByVal ar As Area, ByVal tpup As Boolean) As Integer

        Dim ar1 As New Area

        Try
            For i As Integer = 0 To q.Count - 1
                ar1 = q.Dequeue

                If Form4.ftip(ar1, ar, tpup) Then
                    Return i
                End If
            Next

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in Drwidx", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return -1

    End Function

    Public Function findcandidateold(ByVal q As List(Of Area), ByVal ar As Area) As List(Of Integer)

        Dim lst As New List(Of Integer)
        Dim lst2 As New List(Of Integer)
        Dim retlst As New Queue
        Dim ar1 As New Area
        Dim cnt As Integer = 0
        Dim cmd As New OleDb.OleDbCommand
        Dim rdr As OleDb.OleDbDataReader
        Dim ordr As Integer
        Dim ordr1 As Integer
        Dim q1 As New List(Of Area)
        Dim q2 As New List(Of Area)
        Dim q3 As New List(Of Area)
        Dim lst1 As New List(Of Area)
        Dim elst As New List(Of List(Of Area))
        Dim tlst As New List(Of Area)
        Dim tlst1 As New List(Of Area)

        Dim arcon As Area
        Dim lstf As New List(Of Integer)
        Dim lstret As New List(Of List(Of Integer))
        Dim arr As Area
        Dim lstt As New List(Of Integer)

        Try
            For i As Integer = 0 To q.Count - 1
                ar1 = q(i)

                If ar1.width >= ar.width AndAlso ar1.height >= ar.height Then
                    If ar1.length > 3 Then
                        lst.Add(i)
                        lst1.Add(ar1)
                    End If
                End If
            Next

            For j As Integer = 0 To lst1.Count - 1

                arr = lst1(j)

                For i As Integer = 0 To q.Count - 1
                    ar1 = q(i)

                    If ar1.StrtPt.x = arr.StrtPt.x + arr.length AndAlso ar1.StrtPt.y <= arr.StrtPt.y AndAlso ar1.StrtPt.y + ar1.width = arr.StrtPt.y + arr.width AndAlso ar1.StrtPt.z = arr.StrtPt.z Then
                        tlst.Add(arr)
                        tlst1.Add(ar1)
                        lst2.Add(lst(j))
                        lstf.Add(i)

                    End If
                Next

            Next

            Try
                cmd.Connection = conn
                cmd.CommandText = "delete from temp3"
                cmd.ExecuteNonQuery()

            Catch e As Exception
                cmd.Cancel()
                cmd.Connection = Nothing
                cmd.Connection = conn
                cmd.CommandText = ""
                cmd.CommandText = "delete from temp3"
                cmd.ExecuteNonQuery()
            End Try
            For i As Integer = 0 To tlst.Count - 1
                arcon = tlst(i)
                ordr = lst2(i)
                ordr1 = lstf(i)
                Try
                    cmd.Connection = conn
                    cmd.CommandText = "insert into temp3 values(" & CStr(arcon.StrtPt.x) & "," & CStr(arcon.StrtPt.y) & "," & CStr(arcon.StrtPt.z) & "," & CStr(ordr) & "," & CStr(ordr1) & ")"
                    cmd.ExecuteNonQuery()
                Catch e As Exception
                    cmd.Cancel()
                    cmd.Connection = Nothing
                    cmd.Connection = conn
                    cmd.CommandText = ""
                    cmd.CommandText = "delete from temp3"
                    cmd.ExecuteNonQuery()
                End Try

            Next

            cmd.CommandText = "select * from temp3 order by z desc ,x asc,y asc"
            rdr = cmd.ExecuteReader
            rdr.Read()
            If rdr.HasRows Then
                ordr = rdr.Item("i")
                ordr1 = rdr.Item("j")
                lstt.Add(ordr)
                lstt.Add(ordr1)
                lstret.Add(lstt)
                Return lstt
            Else
                Return Nothing
            End If
        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in findcandidateold", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try

    End Function

    Public Function FindCandidate1Wad(ByVal Q As List(Of Area), ByVal Ar As Area, ByVal TpUp As Boolean) As List(Of Integer)

        Dim Lst As New List(Of Integer)
        Dim Lst2 As New List(Of Integer)
        Dim RetLst As New Queue
        Dim Ar1 As New Area
        Dim Cnt As Integer = 0
        Dim Cmd As New OleDb.OleDbCommand
        Dim Rdr As OleDb.OleDbDataReader
        Dim Ordr As Integer
        Dim Ordr1 As Integer
        Dim Q1 As New List(Of Area)
        Dim Q2 As New List(Of Area)
        Dim Q3 As New List(Of Area)
        Dim Lst1 As New List(Of Area)
        Dim ELst As New List(Of List(Of Area))
        Dim TLst As New List(Of Area)
        Dim TLst1 As New List(Of Area)

        Dim ArCon As Area
        Dim Lstf As New List(Of Integer)
        Dim LstRet As New List(Of List(Of Integer))
        Dim Arr As Area
        Dim LstT As New List(Of Integer)

        Try
            For i As Integer = 0 To Q.Count - 1
                Ar1 = Q(i)

                If Not WadFtip(Ar1, Ar, TpUp) Then

                    If Ar1.length >= Ar.length AndAlso Ar1.width >= Ar.width AndAlso Ar1.height >= Ar.height Then

                        Lst.Add(i)
                        Lst1.Add(Ar1)

                    End If
                End If
            Next

            For j As Integer = 0 To Lst1.Count - 1

                Arr = Lst1(j)

                For i As Integer = 0 To Q.Count - 1

                    Ar1 = Q(i)

                    If (Math.Abs(Ar1.StrtPt.y - Arr.StrtPt.y - Arr.width) < 0.0001) AndAlso Ar1.StrtPt.z = Arr.StrtPt.z AndAlso Ar1.width + Arr.width >= Ar.width Then

                        TLst.Add(Arr)
                        TLst1.Add(Ar1)
                        Lst2.Add(Lst(j))
                        Lstf.Add(i)

                    End If
                Next
            Next

            Try
                Cmd.Connection = conn
                Cmd.CommandText = "delete from temp3"
                Cmd.ExecuteNonQuery()
            Catch e As Exception
                conn.Dispose()
                conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\container.mdb;Persist Security Info=False"
                conn.Open()
                Cmd.Cancel()
                Cmd.Connection = Nothing
                Cmd.Connection = conn
                Cmd.CommandText = ""
                Cmd.CommandText = "delete from temp3"
                Cmd.ExecuteNonQuery()
            End Try

            For i As Integer = 0 To TLst.Count - 1
                ArCon = TLst(i)
                Ordr = Lst2(i)
                Ordr1 = Lstf(i)
                Try
                    Cmd.Connection = conn
                    Cmd.CommandText = "insert into temp3 values(" & CStr(ArCon.StrtPt.x) & "," & CStr(ArCon.StrtPt.y) & "," & CStr(ArCon.StrtPt.z) & "," & CStr(Ordr) & "," & CStr(Ordr1) & ")"
                    Cmd.ExecuteNonQuery()

                Catch e As Exception
                    Cmd.Cancel()

                    Cmd.Connection = Nothing
                    Cmd.Connection = conn
                    Cmd.CommandText = ""
                    Cmd.CommandText = "delete from temp3"
                    Cmd.ExecuteNonQuery()
                End Try

            Next

            Cmd.CommandText = "select * from temp3 order by z desc ,x asc,y asc"
            Rdr = Cmd.ExecuteReader
            Rdr.Read()
            If Rdr.HasRows Then
                Ordr = Rdr.Item("i")
                Ordr1 = Rdr.Item("j")
                LstT.Add(Ordr)
                LstT.Add(Ordr1)
                LstRet.Add(LstT)
                Return LstT
            Else
                Return Nothing
            End If

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in FindCandidate1Wad", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try

    End Function

    Public Function findcandidate1(ByVal q As List(Of Area), ByVal ar As Area, ByVal tpup As Boolean) As List(Of Integer)

        Dim lst As New List(Of Integer)
        Dim lst2 As New List(Of Integer)
        Dim retlst As New Queue
        Dim ar1 As New Area
        Dim cnt As Integer = 0
        Dim cmd As New OleDb.OleDbCommand
        Dim rdr As OleDb.OleDbDataReader
        Dim ordr As Integer
        Dim ordr1 As Integer
        Dim q1 As New List(Of Area)
        Dim q2 As New List(Of Area)
        Dim q3 As New List(Of Area)
        Dim lst1 As New List(Of Area)
        Dim elst As New List(Of List(Of Area))
        Dim tlst As New List(Of Area)
        Dim tlst1 As New List(Of Area)

        Dim arcon As Area
        Dim lstf As New List(Of Integer)
        Dim lstret As New List(Of List(Of Integer))
        Dim arr As Area
        Dim lstt As New List(Of Integer)

        Try
            For i As Integer = 0 To q.Count - 1
                ar1 = q(i)

                If Not Form4.ftip(ar1, ar, tpup) Then

                    If ar1.length >= ar.length AndAlso ar1.height >= ar.height AndAlso ar1.width > ar.width Then

                        lst.Add(i)
                        lst1.Add(ar1)

                    End If
                End If
            Next

            For j As Integer = 0 To lst1.Count - 1
                arr = lst1(j)

                For i As Integer = 0 To q.Count - 1
                    ar1 = q(i)

                    If (Math.Abs(ar1.StrtPt.y - arr.StrtPt.y - arr.width) < 0.0001) AndAlso ar1.StrtPt.z = arr.StrtPt.z AndAlso ar1.width + arr.width >= ar.width Then
                        tlst.Add(arr)
                        tlst1.Add(ar1)
                        lst2.Add(lst(j))
                        lstf.Add(i)

                    End If
                Next

            Next

            Try
                cmd.Connection = conn
                cmd.CommandText = "delete from temp3"
                cmd.ExecuteNonQuery()
            Catch e As Exception
                conn.Dispose()
                conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\container.mdb;Persist Security Info=False"
                conn.Open()
                cmd.Cancel()
                cmd.Connection = Nothing
                cmd.Connection = conn
                cmd.CommandText = ""
                cmd.CommandText = "delete from temp3"
                cmd.ExecuteNonQuery()
            End Try

            For i As Integer = 0 To tlst.Count - 1
                arcon = tlst(i)
                ordr = lst2(i)
                ordr1 = lstf(i)
                Try
                    cmd.Connection = conn
                    cmd.CommandText = "insert into temp3 values(" & CStr(arcon.StrtPt.x) & "," & CStr(arcon.StrtPt.y) & "," & CStr(arcon.StrtPt.z) & "," & CStr(ordr) & "," & CStr(ordr1) & ")"
                    cmd.ExecuteNonQuery()

                Catch e As Exception
                    cmd.Cancel()

                    cmd.Connection = Nothing
                    cmd.Connection = conn
                    cmd.CommandText = ""
                    cmd.CommandText = "delete from temp3"
                    cmd.ExecuteNonQuery()
                End Try

            Next

            cmd.CommandText = "select * from temp3 order by z desc, x asc, y asc"
            rdr = cmd.ExecuteReader
            rdr.Read()
            If rdr.HasRows Then
                ordr = rdr.Item("i")
                ordr1 = rdr.Item("j")
                lstt.Add(ordr)
                lstt.Add(ordr1)
                lstret.Add(lstt)
                Return lstt
            Else
                Return Nothing
            End If
        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in findcandidate1", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try

    End Function

    Public Function findcandidate11(ByVal q As List(Of Area), ByVal ar As Area) As List(Of Integer)

        Dim lst As New List(Of Integer)
        Dim lst2 As New List(Of Integer)
        Dim retlst As New Queue
        Dim ar1 As New Area
        Dim cnt As Integer = 0
        Dim cmd As New OleDb.OleDbCommand

        Dim ordr As Integer
        Dim ordr1 As Integer
        Dim q1 As New List(Of Area)
        Dim q2 As New List(Of Area)
        Dim q3 As New List(Of Area)
        Dim lst1 As New List(Of Area)
        Dim elst As New List(Of List(Of Area))
        Dim tlst As New List(Of Area)
        Dim tlst1 As New List(Of Area)

        Dim arcon As Area
        Dim lstf As New List(Of Integer)
        Dim lstret As New List(Of List(Of Integer))
        Dim arr As Area
        Dim lstt As New List(Of Integer)
        Dim rwx As DataRow()

        Try
            For i As Integer = 0 To q.Count - 1
                ar1 = q(i)

                If ar1.length >= ar.length AndAlso ar1.height >= ar.height AndAlso ar1.width < ar.width Then

                    lst.Add(i)
                    lst1.Add(ar1)

                End If
            Next

            For j As Integer = 0 To lst1.Count - 1
                arr = lst1(j)

                For i As Integer = 0 To q.Count - 1
                    ar1 = q(i)

                    If ar1.StrtPt.y = arr.StrtPt.y + arr.width And arr.StrtPt.x <= ar1.StrtPt.x AndAlso arr.StrtPt.x + arr.length = ar1.StrtPt.x + ar1.length AndAlso ar1.StrtPt.z = arr.StrtPt.z AndAlso arr.width + ar1.width >= ar.width Then
                        tlst.Add(arr)
                        tlst1.Add(ar1)
                        lst2.Add(lst(j))
                        lstf.Add(i)

                    End If
                Next

            Next

            DelTab("temp3")

            For i As Integer = 0 To tlst.Count - 1
                arcon = tlst(i)
                ordr = lst2(i)
                ordr1 = lstf(i)
                instab("temp3", New Object() {CStr(arcon.StrtPt.x), CStr(arcon.StrtPt.y), CStr(arcon.StrtPt.z), CStr(ordr), CStr(ordr1)})

            Next

            rwx = getf("temp3", "", "z desc,x asc,y asc")

            If rwx.GetLength(0) = 1 Then
                Return Nothing
            Else
                ordr = rwx(0)("i")
                ordr1 = rwx(0)("j")
                lstt.Add(ordr)
                lstt.Add(ordr1)
                lstret.Add(lstt)
            End If

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in findcandidate11", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        If ordr = -1 Then
            Return Nothing
        Else
            Return lstt
        End If

    End Function

    Public Function findcandidate1x(ByVal q As List(Of Area), ByVal ar As Area) As List(Of Integer)

        Dim lst As New List(Of Integer)
        Dim lst2 As New List(Of Integer)
        Dim retlst As New Queue
        Dim ar1 As New Area
        Dim cnt As Integer = 0
        Dim cmd As New OleDb.OleDbCommand
        Dim rdr As OleDb.OleDbDataReader
        Dim ordr As Integer
        Dim ordr1 As Integer
        Dim q1 As New List(Of Area)
        Dim q2 As New List(Of Area)
        Dim q3 As New List(Of Area)

        Dim lst1 As New List(Of Area)
        Dim elst As New List(Of List(Of Area))
        Dim tlst As New List(Of Area)
        Dim tlst1 As New List(Of Area)

        Dim arcon As Area
        Dim lstf As New List(Of Integer)
        Dim lstret As New List(Of List(Of Integer))
        Dim arr As Area
        Dim lstt As New List(Of Integer)

        Try
            For i As Integer = 0 To q.Count - 1
                ar1 = q(i)

                If ar1.length >= ar.length AndAlso ar1.height >= ar.height Then

                    lst.Add(i)
                    lst1.Add(ar1)

                End If
            Next

            For j As Integer = 0 To lst1.Count - 1
                arr = lst1(j)

                For i As Integer = 0 To q.Count - 1
                    ar1 = q(i)

                    If ar1.StrtPt.y = arr.StrtPt.y + arr.width And arr.StrtPt.x <= ar1.StrtPt.x AndAlso arr.StrtPt.x + arr.length = ar1.StrtPt.x + ar1.length AndAlso ar1.StrtPt.z = arr.StrtPt.z Then
                        'If ar1.StrtPt.x = arr.StrtPt.x + arr.length AndAlso ar1.length + arr.length >= ar.length AndAlso (ar1.StrtPt.y = arr.StrtPt.y OrElse ar1.StrtPt.y + ar1.width = arr.StrtPt.y + arr.width) AndAlso ar1.StrtPt.z = arr.StrtPt.z AndAlso ar1.StrtPt.y <= arr.StrtPt.y Then
                        tlst.Add(arr)
                        tlst1.Add(ar1)
                        lst2.Add(lst(j))
                        lstf.Add(i)

                    End If
                Next

            Next

            Try
                cmd.Connection = conn
                cmd.CommandText = "delete from temp3"
                cmd.ExecuteNonQuery()
            Catch e As Exception
                conn.Dispose()
                conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\container.mdb;Persist Security Info=False"
                conn.Open()
                cmd.Cancel()
                cmd.Connection = Nothing
                cmd.Connection = conn
                cmd.CommandText = ""
                cmd.CommandText = "delete from temp3"
                cmd.ExecuteNonQuery()
            End Try
            For i As Integer = 0 To tlst.Count - 1
                arcon = tlst(i)
                ordr = lst2(i)
                ordr1 = lstf(i)
                Try
                    cmd.Connection = conn
                    cmd.CommandText = "insert into temp3 values(" & CStr(arcon.StrtPt.x) & "," & CStr(arcon.StrtPt.y) & "," & CStr(arcon.StrtPt.z) & "," & CStr(ordr) & "," & CStr(ordr1) & ")"
                    cmd.ExecuteNonQuery()

                Catch e As Exception

                    cmd.Cancel()

                    cmd.Connection = Nothing
                    cmd.Connection = conn
                    cmd.CommandText = ""
                    cmd.CommandText = "delete from temp3"
                    cmd.ExecuteNonQuery()
                End Try

            Next

            cmd.CommandText = "select * from temp3 order by z asc ,x asc,y asc"
            rdr = cmd.ExecuteReader
            rdr.Read()
            If rdr.HasRows Then
                ordr = rdr.Item("i")
                ordr1 = rdr.Item("j")
                lstt.Add(ordr)
                lstt.Add(ordr1)
                lstret.Add(lstt)
                Return lstt
            Else
                Return Nothing
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in findcandidate1x", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try

    End Function

    Public Function unionp1(ByVal ar1 As Area, ByVal ar2 As Area) As List(Of Area)

        Dim arret1 As New Area
        Dim arret2 As New Area
        Dim lstret As New List(Of Area)
        Try
            arret1.StrtPt.x = ar1.StrtPt.x
            arret1.StrtPt.y = ar1.StrtPt.y
            arret1.StrtPt.z = ar1.StrtPt.z
            arret1.length = ar1.length + ar2.length
            arret1.width = ar1.width
            arret1.height = ar1.height

            arret2.StrtPt.x = ar2.StrtPt.x
            arret2.StrtPt.y = ar2.StrtPt.y
            arret2.StrtPt.z = ar2.StrtPt.z
            arret2.length = ar2.length
            arret2.width = ar2.width - ar1.width
            arret2.height = ar2.height

            lstret.Add(arret1)
            lstret.Add(arret2)

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in unionp1", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return lstret

    End Function

    Public Function UnionPtWad(ByVal Ar1 As Area, ByVal Ar2 As Area) As List(Of Area)

        Dim ArRet1 As New Area
        Dim ArRet2 As New Area
        Dim LstRet As New List(Of Area)

        Try
            Ar1.StrtPt.x = Math.Round(Ar1.StrtPt.x, 4)
            Ar1.StrtPt.y = Math.Round(Ar1.StrtPt.y, 4)
            Ar1.StrtPt.z = Math.Round(Ar1.StrtPt.z, 4)

            Ar1.length = Math.Round(Ar1.length, 4)
            Ar1.width = Math.Round(Ar1.width, 4)
            Ar1.height = Math.Round(Ar1.height, 4)

            Ar2.StrtPt.x = Math.Round(Ar2.StrtPt.x, 4)
            Ar2.StrtPt.y = Math.Round(Ar2.StrtPt.y, 4)
            Ar2.StrtPt.z = Math.Round(Ar2.StrtPt.z, 4)

            Ar2.length = Math.Round(Ar2.length, 4)
            Ar2.width = Math.Round(Ar2.width, 4)
            Ar2.height = Math.Round(Ar2.height, 4)

            If Ar1.StrtPt.y = Ar2.StrtPt.y AndAlso Ar1.StrtPt.z = Ar2.StrtPt.z AndAlso Ar1.height = Ar2.height Then

                If Ar2.StrtPt.x = (Ar1.StrtPt.x + Ar1.length) Then

                    If Ar1.width = Ar2.width Then
                        ArRet1.StrtPt.x = Ar1.StrtPt.x
                        ArRet1.StrtPt.y = Ar1.StrtPt.y
                        ArRet1.StrtPt.z = Ar1.StrtPt.z
                        ArRet1.length = Ar1.length + Ar2.length
                        ArRet1.width = Ar1.width
                        ArRet1.height = Ar1.height

                        ArRet2.StrtPt.x = 0
                        ArRet2.StrtPt.y = 0
                        ArRet2.StrtPt.z = 0
                        ArRet2.length = 0
                        ArRet2.width = 0
                        ArRet2.height = 0

                        LstRet.Add(ArRet1)
                        LstRet.Add(ArRet2)

                        Return LstRet

                    Else

                        If Ar1.width < Ar2.width Then

                            ArRet1.StrtPt.x = Ar1.StrtPt.x
                            ArRet1.StrtPt.y = Ar1.StrtPt.y
                            ArRet1.StrtPt.z = Ar1.StrtPt.z
                            ArRet1.length = Ar1.length + Ar2.length

                            ArRet2.StrtPt.x = Ar2.StrtPt.x
                            ArRet2.StrtPt.y = Ar1.StrtPt.y + Ar1.width
                            ArRet2.StrtPt.z = Ar1.StrtPt.z

                            ArRet2.length = Ar2.length
                            ArRet2.width = Ar2.width - Ar1.width
                            ArRet2.height = Ar2.height

                            LstRet.Add(ArRet1)
                            LstRet.Add(ArRet2)

                        End If

                        If Ar2.width < Ar1.width Then

                            ArRet1.StrtPt.x = Ar1.StrtPt.x
                            ArRet1.StrtPt.y = Ar1.StrtPt.y
                            ArRet1.StrtPt.z = Ar1.StrtPt.z
                            ArRet1.length = Ar1.length + Ar2.length
                            ArRet1.width = Ar2.width
                            ArRet1.height = Ar1.height

                            ArRet2.StrtPt.x = Ar1.StrtPt.x
                            ArRet2.StrtPt.y = Ar2.StrtPt.y + Ar2.width
                            ArRet2.StrtPt.z = Ar1.StrtPt.z
                            ArRet2.length = Ar1.length
                            ArRet2.width = Ar1.width - Ar2.width
                            ArRet2.height = Ar2.height

                            LstRet.Add(ArRet1)
                            LstRet.Add(ArRet2)

                            Return LstRet

                        End If

                    End If

                End If

                If (Ar1.StrtPt.x = (Ar2.StrtPt.x + Ar2.length)) Then
                    If Ar1.width = Ar2.width Then

                        ArRet1.StrtPt.x = Ar2.StrtPt.x
                        ArRet1.StrtPt.y = Ar2.StrtPt.y
                        ArRet1.StrtPt.z = Ar2.StrtPt.z
                        ArRet1.length = Ar1.length + Ar2.length
                        ArRet1.width = Ar1.width
                        ArRet1.height = Ar1.height

                        ArRet2.StrtPt.x = 0
                        ArRet2.StrtPt.y = 0
                        ArRet2.StrtPt.z = 0
                        ArRet2.length = 0
                        ArRet2.width = 0
                        ArRet2.height = 0

                        LstRet.Add(ArRet1)
                        LstRet.Add(ArRet2)

                        Return LstRet

                    Else

                        If Ar2.width < Ar1.width Then

                            ArRet1.StrtPt.x = Ar2.StrtPt.x
                            ArRet1.StrtPt.y = Ar2.StrtPt.y
                            ArRet1.StrtPt.z = Ar2.StrtPt.z
                            ArRet1.length = Ar2.length + Ar1.length
                            ArRet1.width = Ar2.width
                            ArRet1.height = Ar2.height

                            ArRet2.StrtPt.x = Ar1.StrtPt.x
                            ArRet2.StrtPt.y = Ar2.StrtPt.y + Ar2.width
                            ArRet2.StrtPt.z = Ar2.StrtPt.z
                            ArRet2.length = Ar2.length
                            ArRet2.width = Ar2.width - Ar1.width
                            ArRet2.height = Ar1.height

                            LstRet.Add(ArRet1)
                            LstRet.Add(ArRet2)

                            Return LstRet

                        End If

                        If Ar1.width < Ar2.width Then

                            ArRet1.StrtPt.x = Ar2.StrtPt.x
                            ArRet1.StrtPt.y = Ar2.StrtPt.y
                            ArRet1.StrtPt.z = Ar2.StrtPt.z
                            ArRet1.length = Ar2.length + Ar1.length
                            ArRet1.width = Ar1.width
                            ArRet1.height = Ar2.height

                            ArRet2.StrtPt.x = Ar2.StrtPt.x
                            ArRet2.StrtPt.y = Ar1.StrtPt.y + Ar1.width
                            ArRet2.StrtPt.z = Ar2.StrtPt.z
                            ArRet2.length = Ar2.length
                            ArRet2.width = Ar2.width - Ar1.width
                            ArRet2.height = Ar1.height

                            LstRet.Add(ArRet1)
                            LstRet.Add(ArRet2)

                            Return LstRet

                        End If
                    End If
                End If
            End If

            ArRet1.StrtPt.x = Ar1.StrtPt.x
            ArRet1.StrtPt.y = Ar1.StrtPt.y
            ArRet1.StrtPt.z = Ar1.StrtPt.z
            ArRet1.length = Ar1.length + Ar2.length

            If Ar1.width < Ar2.width Then
                ArRet1.width = Ar1.width
            Else
                ArRet1.width = Ar2.width
            End If

            ArRet1.height = Ar1.height

            If Ar1.StrtPt.y = Ar2.StrtPt.y Then
                ArRet2.StrtPt.y = Ar1.StrtPt.y + Ar1.width
            Else
                ArRet2.StrtPt.y = Ar2.StrtPt.y
            End If

            ArRet2.StrtPt.z = Ar2.StrtPt.z

            If Ar2.width < Ar1.width Then
                ArRet2.length = Ar1.length
                ArRet2.StrtPt.x = Ar1.StrtPt.x
            Else
                ArRet2.length = Ar2.length
                ArRet2.StrtPt.x = Ar2.StrtPt.x
            End If

            ArRet2.width = Math.Abs(Ar2.width - Ar1.width)
            ArRet2.height = Ar2.height

            If Ar1.StrtPt.x = Ar2.StrtPt.x AndAlso Ar1.length < Ar2.length AndAlso Ar2.StrtPt.y = Ar1.StrtPt.y + Ar1.width Then

                ArRet1.length = Ar1.length
                ArRet1.width = Ar1.width + Ar2.width
                ArRet1.height = Ar1.height

                ArRet2.StrtPt.x = Ar1.StrtPt.x + Ar1.length
                ArRet2.StrtPt.y = Ar2.StrtPt.y
                ArRet2.StrtPt.z = Ar1.StrtPt.z
                ArRet2.length = Ar2.length - Ar1.length
                ArRet2.width = Ar2.width
                ArRet2.height = Ar1.height

            End If

            If Ar1.StrtPt.x < Ar2.StrtPt.x AndAlso Math.Abs(Ar2.StrtPt.y - Ar1.StrtPt.y - Ar1.width) < 0.00001 AndAlso Math.Abs(Ar1.StrtPt.x + Ar1.length - Ar2.StrtPt.x - Ar2.length) < 0.00001 Then

                ArRet1.StrtPt.x = Ar2.StrtPt.x
                ArRet1.StrtPt.y = Ar1.StrtPt.y
                ArRet1.StrtPt.z = Ar1.StrtPt.z
                ArRet1.length = Ar2.length
                ArRet1.width = Ar1.width + Ar2.width
                ArRet1.height = Ar1.height

                ArRet2.StrtPt.x = Ar1.StrtPt.x
                ArRet2.StrtPt.y = Ar1.StrtPt.y
                ArRet2.StrtPt.z = Ar1.StrtPt.z
                ArRet2.length = Ar2.length - Ar1.length
                ArRet2.width = Ar1.width
                ArRet2.height = Ar1.height

            End If

            LstRet.Add(ArRet1)
            LstRet.Add(ArRet2)

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in UnionPtWad", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return LstRet

    End Function

    Public Function unionp(ByVal ar1 As Area, ByVal ar2 As Area) As List(Of Area)

        Dim arret1 As New Area
        Dim arret2 As New Area
        Dim lstret As New List(Of Area)

        Try
            ar1.StrtPt.x = Math.Round(ar1.StrtPt.x, 4)
            ar1.StrtPt.y = Math.Round(ar1.StrtPt.y, 4)
            ar1.StrtPt.z = Math.Round(ar1.StrtPt.z, 4)

            ar1.length = Math.Round(ar1.length, 4)
            ar1.width = Math.Round(ar1.width, 4)
            ar1.height = Math.Round(ar1.height, 4)

            ar2.StrtPt.x = Math.Round(ar2.StrtPt.x, 4)
            ar2.StrtPt.y = Math.Round(ar2.StrtPt.y, 4)
            ar2.StrtPt.z = Math.Round(ar2.StrtPt.z, 4)

            ar2.length = Math.Round(ar2.length, 4)
            ar2.width = Math.Round(ar2.width, 4)
            ar2.height = Math.Round(ar2.height, 4)

            If ar1.StrtPt.y = ar2.StrtPt.y AndAlso ar1.StrtPt.z = ar2.StrtPt.z AndAlso ar1.height = ar2.height Then
                If (ar2.StrtPt.x = (ar1.StrtPt.x + ar1.length)) Then
                    If ar1.width = ar2.width Then
                        arret1.StrtPt.x = ar1.StrtPt.x
                        arret1.StrtPt.y = ar1.StrtPt.y
                        arret1.StrtPt.z = ar1.StrtPt.z
                        arret1.length = ar1.length + ar2.length
                        arret1.width = ar1.width
                        arret1.height = ar1.height

                        arret2.StrtPt.x = 0
                        arret2.StrtPt.y = 0
                        arret2.StrtPt.z = 0
                        arret2.length = 0
                        arret2.width = 0
                        arret2.height = 0

                        lstret.Add(arret1)
                        lstret.Add(arret2)

                        Return lstret

                    Else

                        If ar1.width < ar2.width Then

                            arret1.StrtPt.x = ar1.StrtPt.x
                            arret1.StrtPt.y = ar1.StrtPt.y
                            arret1.StrtPt.z = ar1.StrtPt.z
                            arret1.length = ar1.length + ar2.length
                            arret1.width = ar1.width
                            arret1.height = ar1.height

                            arret2.StrtPt.x = ar2.StrtPt.x
                            arret2.StrtPt.y = ar1.StrtPt.y + ar1.width
                            arret2.StrtPt.z = ar1.StrtPt.z
                            arret2.length = ar2.length
                            arret2.width = ar2.width - ar1.width
                            arret2.height = ar2.height

                            lstret.Add(arret1)
                            lstret.Add(arret2)

                            Return lstret

                        End If

                        If ar2.width < ar1.width Then

                            arret1.StrtPt.x = ar1.StrtPt.x
                            arret1.StrtPt.y = ar1.StrtPt.y
                            arret1.StrtPt.z = ar1.StrtPt.z
                            arret1.length = ar1.length + ar2.length
                            arret1.width = ar2.width
                            arret1.height = ar1.height

                            arret2.StrtPt.x = ar1.StrtPt.x
                            arret2.StrtPt.y = ar2.StrtPt.y + ar2.width
                            arret2.StrtPt.z = ar1.StrtPt.z
                            arret2.length = ar1.length
                            arret2.width = ar1.width - ar2.width
                            arret2.height = ar2.height

                            lstret.Add(arret1)
                            lstret.Add(arret2)

                            Return lstret

                        End If

                    End If

                End If

                If (ar1.StrtPt.x = (ar2.StrtPt.x + ar2.length)) Then
                    If ar1.width = ar2.width Then

                        arret1.StrtPt.x = ar2.StrtPt.x
                        arret1.StrtPt.y = ar2.StrtPt.y
                        arret1.StrtPt.z = ar2.StrtPt.z
                        arret1.length = ar1.length + ar2.length
                        arret1.width = ar1.width
                        arret1.height = ar1.height

                        arret2.StrtPt.x = 0
                        arret2.StrtPt.y = 0
                        arret2.StrtPt.z = 0
                        arret2.length = 0
                        arret2.width = 0
                        arret2.height = 0

                        lstret.Add(arret1)
                        lstret.Add(arret2)

                        Return lstret

                    Else

                        If ar2.width < ar1.width Then

                            arret1.StrtPt.x = ar2.StrtPt.x
                            arret1.StrtPt.y = ar2.StrtPt.y
                            arret1.StrtPt.z = ar2.StrtPt.z
                            arret1.length = ar2.length + ar1.length
                            arret1.width = ar2.width
                            arret1.height = ar2.height

                            arret2.StrtPt.x = ar1.StrtPt.x
                            arret2.StrtPt.y = ar2.StrtPt.y + ar2.width
                            arret2.StrtPt.z = ar2.StrtPt.z
                            arret2.length = ar1.length
                            arret2.width = ar1.width - ar2.width
                            arret2.height = ar1.height

                            lstret.Add(arret1)
                            lstret.Add(arret2)

                            Return lstret

                        End If

                        If ar1.width < ar2.width Then

                            arret1.StrtPt.x = ar2.StrtPt.x
                            arret1.StrtPt.y = ar2.StrtPt.y
                            arret1.StrtPt.z = ar2.StrtPt.z
                            arret1.length = ar2.length + ar1.length
                            arret1.width = ar1.width
                            arret1.height = ar2.height

                            arret2.StrtPt.x = ar2.StrtPt.x
                            arret2.StrtPt.y = ar1.StrtPt.y + ar1.width
                            arret2.StrtPt.z = ar2.StrtPt.z
                            arret2.length = ar2.length
                            arret2.width = ar2.width - ar1.width
                            arret2.height = ar1.height

                            lstret.Add(arret1)
                            lstret.Add(arret2)

                            Return lstret

                        End If

                    End If

                End If

            End If

            arret1.StrtPt.x = ar1.StrtPt.x
            arret1.StrtPt.y = ar1.StrtPt.y
            arret1.StrtPt.z = ar1.StrtPt.z
            arret1.length = ar1.length + ar2.length

            If ar1.width < ar2.width Then
                arret1.width = ar1.width
            Else
                arret1.width = ar2.width
            End If

            arret1.height = ar1.height

            If ar1.StrtPt.y = ar2.StrtPt.y Then
                arret2.StrtPt.y = ar1.StrtPt.y + ar1.width
            Else
                arret2.StrtPt.y = ar2.StrtPt.y
            End If

            arret2.StrtPt.z = ar2.StrtPt.z

            If ar2.width < ar1.width Then
                arret2.length = ar1.length
                arret2.StrtPt.x = ar1.StrtPt.x
            Else
                arret2.length = ar2.length
                arret2.StrtPt.x = ar2.StrtPt.x
            End If

            arret2.width = Math.Abs(ar2.width - ar1.width)
            arret2.height = ar2.height

            If ar1.StrtPt.x = ar2.StrtPt.x AndAlso ar1.length < ar2.length AndAlso ar2.StrtPt.y = ar1.StrtPt.y + ar1.width Then
                arret1.length = ar1.length
                arret1.width = ar1.width + ar2.width
                arret1.height = ar1.height

                arret2.StrtPt.x = ar1.StrtPt.x + ar1.length
                arret2.StrtPt.y = ar2.StrtPt.y
                arret2.StrtPt.z = ar1.StrtPt.z
                arret2.length = ar2.length - ar1.length
                arret2.width = ar2.width
                arret2.height = ar1.height
            End If

            If ar1.StrtPt.x < ar2.StrtPt.x AndAlso Math.Abs(ar2.StrtPt.y - ar1.StrtPt.y - ar1.width) < 0.00001 AndAlso Math.Abs(ar1.StrtPt.x + ar1.length - ar2.StrtPt.x - ar2.length) < 0.00001 Then
                arret1.StrtPt.x = ar2.StrtPt.x
                arret1.StrtPt.y = ar1.StrtPt.y
                arret1.StrtPt.z = ar1.StrtPt.z
                arret1.length = ar2.length
                arret1.width = ar1.width + ar2.width
                arret1.height = ar1.height

                arret2.StrtPt.x = ar1.StrtPt.x
                arret2.StrtPt.y = ar1.StrtPt.y
                arret2.StrtPt.z = ar1.StrtPt.z
                arret2.length = ar2.length - ar1.length
                arret2.width = ar1.width
                arret2.height = ar1.height
            End If

            lstret.Add(arret1)
            lstret.Add(arret2)

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in unionp", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return lstret

    End Function

    Public Function unionpx(ByVal ar1 As Area, ByVal ar2 As Area) As List(Of Area)

        Dim arret1 As New Area
        Dim arret2 As New Area
        Dim lstret As New List(Of Area)

        Try
            arret2.StrtPt.x = ar1.StrtPt.x
            arret2.StrtPt.y = ar1.StrtPt.y
            arret2.StrtPt.z = ar1.StrtPt.z
            arret2.length = Math.Abs(ar1.length - ar2.length)

            arret2.width = ar1.width

            arret2.height = ar1.height

            arret1.StrtPt.y = ar1.StrtPt.y

            arret1.StrtPt.z = ar2.StrtPt.z

            arret1.length = ar2.length
            arret1.StrtPt.x = ar2.StrtPt.x

            arret1.width = Math.Abs(ar2.width + ar1.width)
            arret1.height = ar2.height

            lstret.Add(arret1)
            lstret.Add(arret2)

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in unionpx", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return lstret

    End Function

    Public Function unionpold(ByVal ar1 As Area, ByVal ar2 As Area) As List(Of Area)

        Dim arret1 As New Area
        Dim arret2 As New Area
        Dim lstret As New List(Of Area)

        Try
            arret1.StrtPt.x = ar2.StrtPt.x
            arret1.StrtPt.y = ar1.StrtPt.y
            arret1.StrtPt.z = ar1.StrtPt.z
            arret1.length = ar2.length
            arret1.width = ar1.width + ar2.width
            arret1.height = ar1.height

            arret2.StrtPt.x = ar1.StrtPt.x
            arret2.StrtPt.y = ar1.StrtPt.y
            arret2.StrtPt.z = ar1.StrtPt.z
            arret2.length = ar1.length - ar2.length
            arret2.width = ar1.width
            arret2.height = ar1.height

            lstret.Add(arret1)
            lstret.Add(arret2)

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in unionpold", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return lstret

    End Function

    Public Function findmaxqty(ByVal q As List(Of Area), ByVal ar11 As Area) As Integer

        Bitemqty = 0
        Dim ar() As Area
        Dim ari() As String
        Dim arwt() As Single
        Dim ar1 As New Area
        Dim arc As New Area

        Dim transparr() As Boolean

        Dim topup() As Boolean

        ReDim ar(0)
        ReDim ari(0)
        ReDim arwt(0)
        ReDim transparr(0)
        ReDim topup(0)
        Dim cmd As New OleDb.OleDbCommand

        Dim qtyf As Boolean = True
        Dim cnt As Integer = 0
        Dim perqty As Integer

        Dim iq1 As Integer

        Try
            DelTab("temp1")
x:
            ReDim Preserve ar(0)
            ar(0) = ar11

            iq1 = 0
            Dim q1 As New List(Of Area)
            For j As Integer = 0 To q.Count - 1
                For i As Integer = 0 To q.Count - 1
                    q1.Add(q(i))
                Next
                If q.Count = 0 Then Exit For
                perqty = findperqty(q(j), ar11)
                For i As Integer = 0 To perqty
                    ReDim Preserve ar(UBound(ar) + 1)
                    ar(UBound(ar)) = ar11
                Next
                Bitemqty = 0

                stk.Clear()
                ReDim ar(0)
                ReDim ari(0)
                ReDim arwt(0)
                ReDim transparr(0)
                ReDim topup(0)
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in findmaxqty", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return iq1

    End Function

    Public Function findperqty(ByVal ar1 As Area, ByVal ar2 As Area) As Integer

        Dim ln1 As Double = ar1.length
        Dim wd1 As Double = ar1.width
        Dim ht1 As Double = ar1.height


        Dim ln2 As Double = ar2.length
        Dim wd2 As Double = ar2.width
        Dim ht2 As Double = ar2.height

        Return (ln1 * wd1 * ht1) \ (ln2 * wd2 * ht2)

    End Function

    Public Sub chng(ByVal ar1 As Area, ByVal ar2 As Area)

        Dim olditemqty = Bitemqty
        Dim ln As Double = ar1.length
        Dim wd As Double = ar1.width
        Dim ht As Double = ar1.height
        Dim volar1 As Double = ar1.length * ar1.width * ar1.height
        Dim volar2 As Double = ar2.length * ar2.width * ar2.height
        Dim maxqty = (volar2 \ volar1) + 1
        Dim qty1 As Integer
        Dim qty2 As Integer
        Dim qty3 As Integer
        Dim qty4 As Integer
        Dim qty5 As Integer
        Dim qty6 As Integer
        Dim maxqty1 As Integer
        Dim qtypos As String
        Dim stkx As New List(Of Area)

        Try
            For i As Integer = 0 To stk.Count - 1
                stkx.Add(stk(i))
            Next

            Dim arr() As Area
            ReDim arr(0)
            For i As Long = 0 To maxqty
                arr(UBound(arr)) = ar1
                ReDim Preserve arr(UBound(arr) + 1)
            Next
            ReDim Preserve arr(UBound(arr) - 1)

            stk.Clear()
            ReDim arr(0)
            ar2 = Nothing

            qty1 = Bitemqty

            stk.Clear()
            For i As Integer = 0 To stkx.Count - 1

                stk.Add(stkx(i))
            Next

            Bitemqty = 0

            ar1.length = ln
            ar1.width = ht
            ar1.height = wd

            ReDim arr(0)
            For i As Long = 0 To maxqty
                arr(UBound(arr)) = ar1
                ReDim Preserve arr(UBound(arr) + 1)
            Next
            ReDim Preserve arr(UBound(arr) - 1)

            ar2 = Nothing
            ReDim arr(0)

            qty2 = Bitemqty

            stk.Clear()
            For i As Integer = 0 To stkx.Count - 1

                stk.Add(stkx(i))
            Next

            Bitemqty = 0

            ar1.length = wd
            ar1.width = ht
            ar1.height = ln

            ReDim arr(0)
            For i As Long = 0 To maxqty
                arr(UBound(arr)) = ar1
                ReDim Preserve arr(UBound(arr) + 1)
            Next
            ReDim Preserve arr(UBound(arr) - 1)

            qty3 = Bitemqty

            stk.Clear()
            For i As Integer = 0 To stkx.Count - 1

                stk.Add(stkx(i))
            Next

            Bitemqty = 0

            ar1.length = wd
            ar1.width = ln
            ar1.height = ht

            ReDim arr(0)
            For i As Long = 0 To maxqty
                arr(UBound(arr)) = ar1
                ReDim Preserve arr(UBound(arr) + 1)
            Next
            ReDim Preserve arr(UBound(arr) - 1)

            qty4 = Bitemqty

            stk.Clear()
            For i As Integer = 0 To stkx.Count - 1

                stk.Add(stkx(i))
            Next

            Bitemqty = 0

            ar1.length = ht
            ar1.width = wd
            ar1.height = ln

            ReDim arr(0)
            For i As Long = 0 To maxqty
                arr(UBound(arr)) = ar1
                ReDim Preserve arr(UBound(arr) + 1)
            Next
            ReDim Preserve arr(UBound(arr) - 1)
            'stuff(ar2, arr, Nothing, Nothing, False, False, "", False, Nothing, Nothing, False, False, True, False)

            qty5 = Bitemqty

            stk.Clear()

            For i As Integer = 0 To stkx.Count - 1

                stk.Add(stkx(i))
            Next

            Bitemqty = 0

            ar1.length = ht
            ar1.width = ln
            ar1.height = wd

            ReDim arr(0)
            For i As Long = 0 To maxqty
                arr(UBound(arr)) = ar1
                ReDim Preserve arr(UBound(arr) + 1)
            Next
            ReDim Preserve arr(UBound(arr) - 1)

            qty6 = Bitemqty

            stk.Clear()
            For i As Integer = 0 To stkx.Count - 1

                stk.Add(stkx(i))
            Next

            maxqty1 = qty1
            qtypos = "1"

            If qty2 > maxqty1 Then
                maxqty = qty2
                qtypos = "2"
            End If

            If qty3 > maxqty Then
                maxqty = qty3
                qtypos = "3"
            End If

            If qty4 > maxqty Then
                maxqty = qty4
                qtypos = "4"
            End If

            If qty5 > maxqty Then
                maxqty = qty5
                qtypos = "5"
            End If

            If qty6 > maxqty Then
                maxqty = qty6
                qtypos = "6"
            End If

            If qtypos = "1" Then
                ar1.length = ln
                ar1.width = wd
                ar1.height = ht
            End If

            If qtypos = "2" Then
                ar1.length = ln
                ar1.width = ht
                ar1.height = wd
            End If


            If qtypos = "3" Then
                ar1.length = wd
                ar1.width = ht
                ar1.height = ln
            End If


            If qtypos = "4" Then
                ar1.length = wd
                ar1.width = ln
                ar1.height = ht
            End If

            If qtypos = "5" Then
                ar1.length = ht
                ar1.width = wd
                ar1.height = ln
            End If


            If qtypos = "6" Then
                ar1.length = ht
                ar1.width = ln
                ar1.height = wd
            End If

            Bitemqty = olditemqty

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in chng", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Function findoptmethodold(ByVal ar1 As Area, ByVal ar2 As Area, ByRef maxqty1 As Integer) As Integer

        Dim olditemqty = Bitemqty
        Dim ln As Double = ar1.length
        Dim wd As Double = ar1.width
        Dim ht As Double = ar1.height
        Dim volar1 As Double = ar1.length * ar1.width * ar1.height
        Dim volar2 As Double = ar2.length * ar2.width * ar2.height
        Dim maxqty = (volar2 \ volar1) + 1
        Dim qty1 As Integer
        Dim qty2 As Integer
        Dim qty3 As Integer
        Dim qty4 As Integer
        Dim qty5 As Integer
        Dim qty6 As Integer

        Dim qtypos As String
        Dim stkx As New List(Of Area)
        Dim stky As New List(Of Area)

        Bitemqty = 0

        Try
            For i As Integer = 0 To stk.Count - 1
                stkx.Add(stk(i))
            Next
            stk.Clear()

            stk.Add(ar2)
            Dim arr() As Area
            ReDim arr(0)

            For i As Long = 0 To maxqty
                arr(UBound(arr)) = ar1
                ReDim Preserve arr(UBound(arr) + 1)
            Next

            ReDim Preserve arr(UBound(arr) - 1)

            qty1 = Bitemqty

            stk.Clear()

            stk.Add(ar2)

            Bitemqty = 0

            ar1.length = ln
            ar1.width = ht
            ar1.height = wd

            ReDim arr(0)

            For i As Long = 0 To maxqty
                arr(UBound(arr)) = ar1
                ReDim Preserve arr(UBound(arr) + 1)
            Next

            ReDim Preserve arr(UBound(arr) - 1)

            qty2 = Bitemqty

            stk.Clear()

            stk.Add(ar2)

            Bitemqty = 0

            ar1.length = wd
            ar1.width = ht
            ar1.height = ln

            ReDim arr(0)

            For i As Long = 0 To maxqty

                arr(UBound(arr)) = ar1

                ReDim Preserve arr(UBound(arr) + 1)

            Next

            ReDim Preserve arr(UBound(arr) - 1)

            qty3 = Bitemqty

            stk.Clear()

            stk.Add(ar2)

            Bitemqty = 0

            ar1.length = wd
            ar1.width = ln
            ar1.height = ht

            ReDim arr(0)

            For i As Long = 0 To maxqty

                arr(UBound(arr)) = ar1
                ReDim Preserve arr(UBound(arr) + 1)

            Next

            ReDim Preserve arr(UBound(arr) - 1)

            qty4 = Bitemqty

            stk.Clear()
            stk.Add(ar2)

            Bitemqty = 0

            ar1.length = ht
            ar1.width = wd
            ar1.height = ln

            ReDim arr(0)

            For i As Long = 0 To maxqty

                arr(UBound(arr)) = ar1
                ReDim Preserve arr(UBound(arr) + 1)

            Next

            ReDim Preserve arr(UBound(arr) - 1)

            qty5 = Bitemqty

            stk.Clear()
            stk.Add(ar2)

            Bitemqty = 0

            ar1.length = ht
            ar1.width = ln
            ar1.height = wd

            ReDim arr(0)

            For i As Long = 0 To maxqty

                arr(UBound(arr)) = ar1
                ReDim Preserve arr(UBound(arr) + 1)

            Next

            ReDim Preserve arr(UBound(arr) - 1)

            qty6 = Bitemqty

            stk.Clear()
            For i As Integer = 0 To stkx.Count - 1
                stk.Add(stkx(i))
            Next
            ar1.length = ln
            ar1.width = wd
            ar1.height = ht

            maxqty1 = qty1
            qtypos = "1"

            If qty2 > maxqty1 Then
                maxqty1 = qty2
                qtypos = "2"
            End If

            If qty3 > maxqty1 Then
                maxqty1 = qty3
                qtypos = "3"
            End If

            If qty4 > maxqty1 Then
                maxqty1 = qty4
                qtypos = "4"
            End If

            If qty5 > maxqty1 Then
                maxqty1 = qty5
                qtypos = "5"
            End If

            If qty6 > maxqty1 Then
                maxqty1 = qty6
                qtypos = "6"
            End If

            If maxqty1 = qty1 Then
                qtypos = 1
            End If

            If qtypos = "1" Then
                Return 1
            End If

            If qtypos = "2" Then
                Return 2
            End If

            If qtypos = "3" Then
                Return 3
            End If

            If qtypos = "4" Then
                Return 4
            End If

            If qtypos = "5" Then
                Return 5
            End If

            If qtypos = "6" Then
                Return 6
            End If

            Bitemqty = olditemqty

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in findoptmethodold", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function

    Public Function FinestOptMethod(ByVal ar1 As Area, ByVal ar2 As Area, ByRef maxqty1 As Integer, ByVal tpup As Boolean) As Integer

        Dim ln1 As Double = ar1.length
        Dim wd1 As Double = ar1.width
        Dim ht1 As Double = ar1.height

        Dim ln2 As Double = ar2.length
        Dim wd2 As Double = ar2.width
        Dim ht2 As Double = ar2.height

        'Dim qty1 As Integer = 0
        'Dim qty2 As Integer = 0
        'Dim qty3 As Integer = 0
        'Dim qty4 As Integer = 0
        'Dim qty5 As Integer = 0
        'Dim qty6 As Integer = 0

        Dim qty1 As Int64 = 0
        Dim qty2 As Int64 = 0
        Dim qty3 As Int64 = 0
        Dim qty4 As Int64 = 0
        Dim qty5 As Int64 = 0
        Dim qty6 As Int64 = 0

        Dim qtypos As String

        Try
            If ln2 >= ln1 AndAlso wd2 >= wd1 AndAlso ht2 >= ht1 Then
                qty1 = Fix(ln2 / ln1) * Fix(wd2 / wd1) * Fix(ht2 / ht1)
            Else
                qty1 = 0
            End If

            If Not tpup Then

                If ln2 >= ln1 AndAlso wd2 >= ht1 AndAlso ht2 >= wd1 Then

                    qty2 = Fix(ln2 / ln1) * Fix(wd2 / ht1) * Fix(ht2 / wd1)

                Else
                    qty2 = 0
                End If

                If ln2 >= wd1 AndAlso wd2 >= ht1 AndAlso ht2 >= ln1 Then
                    qty3 = Fix(ln2 / wd1) * Fix(wd2 / ht1) * Fix(ht2 / ln1)
                Else
                    qty3 = 0
                End If

            End If

            If ln2 >= wd1 AndAlso wd2 >= ln1 AndAlso ht2 >= ht1 Then
                qty4 = Fix(ln2 / wd1) * Fix(wd2 / ln1) * Fix(ht2 / ht1)
            Else
                qty4 = 0
            End If

            If Not tpup Then

                If ln2 >= ht1 AndAlso wd2 >= wd1 AndAlso ht2 >= ln1 Then
                    qty5 = Fix(ln2 / ht1) * Fix(wd2 / wd1) * Fix(ht2 / ln1)
                Else
                    qty5 = 0
                End If

                If ln2 >= ht1 AndAlso wd2 >= ln1 AndAlso ht2 >= wd1 Then
                    qty6 = Fix(ln2 / ht1) * Fix(wd2 / ln1) * Fix(ht2 / wd1)
                Else
                    qty6 = 0
                End If

            End If

            maxqty1 = qty1
            qtypos = "1"

            If Not tpup Then

                If qty2 > maxqty1 Then
                    maxqty1 = qty2
                    qtypos = "2"
                End If

                If qty3 > maxqty1 Then
                    maxqty1 = qty3
                    qtypos = "3"
                End If
            End If

            If qty4 > maxqty1 Then
                maxqty1 = qty4
                qtypos = "4"
            End If

            If Not tpup Then

                If qty5 > maxqty1 Then
                    maxqty1 = qty5
                    qtypos = "5"
                End If

                If qty6 > maxqty1 Then
                    maxqty1 = qty6
                    qtypos = "6"
                End If
            End If

            Occ = 0
            OccLst.Clear()

            If maxqty1 = qty1 Then
                Occ += 1
                OccLst.Add(1)
            End If

            If maxqty1 = qty2 Then
                Occ += 1
                OccLst.Add(2)
            End If

            If maxqty1 = qty3 Then
                Occ += 1
                OccLst.Add(3)
            End If

            If maxqty1 = qty4 Then
                Occ += 1
                OccLst.Add(4)
            End If

            If maxqty1 = qty5 Then
                Occ += 1
                OccLst.Add(5)
            End If

            If maxqty1 = qty6 Then
                Occ += 1
                OccLst.Add(6)
            End If

            If maxqty1 = qty1 Then
                qtypos = "1"
            End If

            If qtypos = "1" Then
                Return 1
            End If

            If qtypos = "2" Then
                Return 2
            End If

            If qtypos = "3" Then
                Return 3
            End If

            If qtypos = "4" Then
                Return 4
            End If

            If qtypos = "5" Then
                Return 5
            End If

            If qtypos = "6" Then
                Return 6
            End If

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in FinestOptMethod", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return 1

    End Function

    Public Function FindOptMethod(ByVal ar1 As Area, ByVal ar2 As Area, ByRef maxqty1 As Integer, ByVal tpup As Boolean) As Integer
        'Orig func
        Dim ln1 As Double = ar1.length
        Dim wd1 As Double = ar1.width
        Dim ht1 As Double = ar1.height

        Dim ln2 As Double = ar2.length
        Dim wd2 As Double = ar2.width
        Dim ht2 As Double = ar2.height

        Dim qty1 As Integer = 0
        Dim qty2 As Integer = 0
        Dim qty3 As Integer = 0
        Dim qty4 As Integer = 0
        Dim qty5 As Integer = 0
        Dim qty6 As Integer = 0

        Dim qtypos As String

        Try

            If ln2 >= ln1 AndAlso wd2 >= wd1 AndAlso ht2 >= ht1 Then
                qty1 = Fix(ln2 / ln1) * Fix(wd2 / wd1) * Fix(ht2 / ht1)
            Else
                qty1 = 0
            End If
            If Not tpup Then

                If ln2 >= ln1 AndAlso wd2 >= ht1 AndAlso ht2 >= wd1 Then
                    qty2 = Fix(ln2 / ln1) * Fix(wd2 / ht1) * Fix(ht2 / wd1)
                Else
                    qty2 = 0
                End If

                If ln2 >= wd1 AndAlso wd2 >= ht1 AndAlso ht2 >= ln1 Then
                    qty3 = Fix(ln2 / wd1) * Fix(wd2 / ht1) * Fix(ht2 / ln1)
                Else
                    qty3 = 0
                End If

            End If

            If ln2 >= wd1 AndAlso wd2 >= ln1 AndAlso ht2 >= ht1 Then
                qty4 = Fix(ln2 / wd1) * Fix(wd2 / ln1) * Fix(ht2 / ht1)
            Else
                qty4 = 0
            End If

            If Not tpup Then

                If ln2 >= ht1 AndAlso wd2 >= wd1 AndAlso ht2 >= ln1 Then
                    qty5 = Fix(ln2 / ht1) * Fix(wd2 / wd1) * Fix(ht2 / ln1)
                Else
                    qty5 = 0
                End If

                If ln2 >= ht1 AndAlso wd2 >= ln1 AndAlso ht2 >= wd1 Then
                    qty6 = Fix(ln2 / ht1) * Fix(wd2 / ln1) * Fix(ht2 / wd1)
                Else
                    qty6 = 0
                End If

            End If

            maxqty1 = qty1
            qtypos = "1"

            If Not tpup Then
                If qty2 > maxqty1 Then
                    maxqty1 = qty2
                    qtypos = "2"
                End If

                If qty3 > maxqty1 Then
                    maxqty1 = qty3
                    qtypos = "3"
                End If
            End If

            If qty4 > maxqty1 Then
                maxqty1 = qty4
                qtypos = "4"
            End If

            If Not tpup Then
                If qty5 > maxqty1 Then
                    maxqty1 = qty5
                    qtypos = "5"
                End If

                If qty6 > maxqty1 Then
                    maxqty1 = qty6
                    qtypos = "6"
                End If
            End If

            Occ = 0
            OccLst.Clear()

            If maxqty1 = qty1 Then
                Occ += 1
                OccLst.Add(1)
            End If

            If maxqty1 = qty2 Then
                Occ += 1
                OccLst.Add(2)
            End If

            If maxqty1 = qty3 Then
                Occ += 1
                OccLst.Add(3)
            End If

            If maxqty1 = qty4 Then
                Occ += 1
                OccLst.Add(4)
            End If

            If maxqty1 = qty5 Then
                Occ += 1
                OccLst.Add(5)
            End If

            If maxqty1 = qty6 Then
                Occ += 1
                OccLst.Add(6)
            End If

            If maxqty1 = qty1 Then
                qtypos = "1"
            End If

            If qtypos = "1" Then
                Return 1
            End If

            If qtypos = "2" Then
                Return 2
            End If

            If qtypos = "3" Then
                Return 3
            End If

            If qtypos = "4" Then
                Return 4
            End If

            If qtypos = "5" Then
                Return 5
            End If

            If qtypos = "6" Then
                Return 6
            End If

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in FindOptMethod ", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return 1

    End Function

    ' This method is find out the maximum quantity is placed in the container in 
    ' particular way that the as maximum quantity is fit into it.

    'Public Function FindOptMethod(ByVal ar1 As Area, ByVal ar2 As Area, ByRef maxqty1 As Integer, ByVal tpup As Boolean) As Integer
    Public Function WadFindOptMethod(ByVal Ari As Area, ByVal ArRem As Area, ByRef MaxQty As Integer, ByVal TpUp As Boolean) As Integer

        'Stop
        Dim foMi As New Region
        Dim foMr As New Region

        foMi.length = Ari.length                'Dim ln1 As Double = ar1.length
        foMi.width = Ari.width                  'Dim wd1 As Double = ar1.width
        foMi.height = Ari.height                'Dim ht1 As Double = ar1.height

        foMr.length = ArRem.length              'Dim ln2 As Double = ar2.length
        foMr.width = ArRem.width                'Dim wd2 As Double = ar2.width
        foMr.height = ArRem.height              'Dim ht2 As Double = ar2.height

        Dim Qty1 As Int64 = 0                   'Dim qty1 As Integer = 0
        Dim Qty2 As Int64 = 0                   'Dim qty2 As Integer = 0
        Dim Qty3 As Int64 = 0                   'Dim qty3 As Integer = 0
        Dim Qty4 As Int64 = 0                   'Dim qty4 As Integer = 0
        Dim Qty5 As Int64 = 0                   'Dim qty5 As Integer = 0
        Dim Qty6 As Int64 = 0                   'Dim qty6 As Integer = 0

        Dim QtyPos As String                    'Dim qtypos As String

        Try
            If foMr.length >= foMi.length AndAlso foMr.width >= foMi.width AndAlso foMr.height >= foMi.height Then             'If ln2 >= ln1 AndAlso wd2 >= wd1 AndAlso ht2 >= ht1 Then
                Qty1 = Fix(foMr.length / foMi.length) * Fix(foMr.width / foMi.width) * Fix(foMr.height / foMi.height)                'Qty1 = Fix(ln2 / ln1) * Fix(wd2 / wd1) * Fix(ht2 / ht1)
            Else
                Qty1 = 0
            End If

            If Not TpUp Then

                If foMr.length >= foMi.length AndAlso foMr.width >= foMi.height AndAlso foMr.height >= foMi.width Then           'If ln2 >= ln1 AndAlso wd2 >= ht1 AndAlso ht2 >= wd1 Then

                    Qty2 = Fix(foMr.length / foMi.length) * Fix(foMr.width / foMi.height) * Fix(foMr.height / foMi.width)                 'Qty2 = Fix(ln2 / ln1) * Fix(wd2 / ht1) * Fix(ht2 / wd1)

                Else
                    Qty2 = 0
                End If

                If foMr.length >= foMi.width AndAlso foMr.width >= foMi.height AndAlso foMr.height >= foMi.length Then                'If ln2 >= wd1 AndAlso wd2 >= ht1 AndAlso ht2 >= ln1 Then
                    Qty3 = Fix(foMr.length / foMi.width) * Fix(foMr.width / foMi.height) * Fix(foMr.height / foMi.length)                           'Qty3 = Fix(ln2 / wd1) * Fix(wd2 / ht1) * Fix(ht2 / ln1)
                Else
                    Qty3 = 0
                End If

            End If

            If foMr.length >= foMi.width AndAlso foMr.width >= foMi.length AndAlso foMr.height >= foMi.height Then                  'If ln2 >= wd1 AndAlso wd2 >= ln1 AndAlso ht2 >= ht1 Then
                Qty4 = Fix(foMr.length / foMi.width) * Fix(foMr.width / foMi.length) * Fix(foMr.height / foMi.height)                                 'Qty4 = Fix(ln2 / wd1) * Fix(wd2 / ln1) * Fix(ht2 / ht1)
            Else
                Qty4 = 0
            End If

            If Not TpUp Then

                If foMr.length >= foMi.height AndAlso foMr.width >= foMi.width AndAlso foMr.height >= foMi.length Then              'If ln2 >= ht1 AndAlso wd2 >= wd1 AndAlso ht2 >= ln1 Then
                    Qty5 = Fix(foMr.length / foMi.height) * Fix(foMr.width / foMi.width) * Fix(foMr.height / foMi.length)                                    'Qty5 = Fix(ln2 / ht1) * Fix(wd2 / wd1) * Fix(ht2 / ln1)
                Else
                    Qty5 = 0
                End If

                If foMr.length >= foMi.height AndAlso foMr.width >= foMi.length AndAlso foMr.height >= foMi.width Then               'If ln2 >= ht1 AndAlso wd2 >= ln1 AndAlso ht2 >= wd1 Then
                    Qty6 = Fix(foMr.length / foMi.height) * Fix(foMr.width / foMi.length) * Fix(foMr.height / foMi.width)                                   'Qty6 = Fix(ln2 / ht1) * Fix(wd2 / ln1) * Fix(ht2 / wd1)
                Else
                    Qty6 = 0
                End If

            End If

            MaxQty = Qty1                            'maxqty1 = Qty1
            QtyPos = "1"

            If Not TpUp Then                            'If Not TpUp Then
                If Qty2 > MaxQty Then                       'If Qty2 > maxqty1 Then
                    MaxQty = Qty2                                   'maxqty1 = Qty2
                    QtyPos = "2"
                End If

                If Qty3 > MaxQty Then                   'If Qty3 > maxqty1 Then
                    MaxQty = Qty3                             'maxqty1 = Qty3
                    QtyPos = "3"
                End If
            End If

            If Qty4 > MaxQty Then                       'If Qty4 > maxqty1 Then
                MaxQty = Qty4                                     'maxqty1 = Qty4
                QtyPos = "4"
            End If

            If Not TpUp Then
                If Qty5 > MaxQty Then                   'If Qty5 > maxqty1 Then
                    MaxQty = Qty5                               'maxqty1 = Qty5
                    QtyPos = "5"
                End If

                If Qty6 > MaxQty Then                   'If Qty6 > maxqty1 Then
                    MaxQty = Qty6                                 'maxqty1 = Qty6
                    QtyPos = "6"
                End If
            End If

            Occ = 0
            OccLst.Clear()

            If MaxQty = Qty1 Then                         'If maxqty1 = Qty1 Then
                Occ += 1
                OccLst.Add(1)
            End If

            If MaxQty = Qty2 Then                          'If maxqty1 = Qty2 Then
                Occ += 1
                OccLst.Add(2)
            End If

            If MaxQty = Qty3 Then                           'If maxqty1 = Qty3 Then
                Occ += 1
                OccLst.Add(3)
            End If

            If MaxQty = Qty4 Then                        'If maxqty1 = Qty4 Then
                Occ += 1
                OccLst.Add(4)
            End If

            If MaxQty = Qty5 Then                           'If maxqty1 = Qty5 Then
                Occ += 1
                OccLst.Add(5)
            End If

            If MaxQty = Qty6 Then                       'If maxqty1 = Qty6 Then
                Occ += 1
                OccLst.Add(6)
            End If

            If MaxQty = Qty1 Then                       'If maxqty1 = Qty1 Then
                QtyPos = "1"
            End If

            If QtyPos = "1" Then
                Return 1
            End If

            If QtyPos = "2" Then
                Return 2
            End If

            If QtyPos = "3" Then
                Return 3
            End If

            If QtyPos = "4" Then
                Return 4
            End If

            If QtyPos = "5" Then
                Return 5
            End If

            If QtyPos = "6" Then
                Return 6
            End If

        Catch er As Exception
            MsgBox(er.Message)
            MsgBox(er.ToString)
            MessageBox.Show("Error in FindOptMethod", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return 1

    End Function

    Public Function mxqt(ByVal ar As Area, ByVal tpup As Boolean) As Integer

        Dim qty1 As Integer = 0
        Dim qty As Integer = 0
        Dim ar1 As New Area
        Dim ii As Integer

        Try
            For i As Integer = 0 To stkn.Count - 1
                ar1 = stkn(i)
                ii = FindOptMethod(ar, ar1, qty, tpup)

                Dim ln As Double = ar.length
                Dim wd As Double = ar.width
                Dim ht As Double = ar.height

                If ii = 1 Then

                    'Exit Do
                End If

                If ii = 2 Then
                    ar.length = ln
                    ar.width = ht
                    ar.height = wd
                    'Exit Do
                End If

                If ii = 3 Then
                    ar.length = wd
                    ar.width = ht
                    ar.height = ln
                    'Exit Do
                End If

                If ii = 4 Then
                    ar.length = wd
                    ar.width = ln
                    ar.height = ht
                    'Exit Do
                End If

                If ii = 5 Then
                    ar.length = ht
                    ar.width = wd
                    ar.height = ln
                    'Exit Do
                End If

                If ii = 6 Then
                    ar.length = ht
                    ar.width = ln
                    ar.height = wd
                    'Exit Do
                End If

                qty1 = qty1 + qty
                qty = 0
            Next

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in mxqt", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return qty1

    End Function

    Public Function FindCandidateWad(ByVal Q As List(Of Area), ByVal Ar As Area) As List(Of Integer)

        Dim Lst As New List(Of Integer)
        Dim Lst2 As New List(Of Integer)
        Dim RetLst As New Queue
        Dim Ar1 As New Area
        Dim Cnt As Integer = 0
        Dim Cmd As New OleDb.OleDbCommand
        Dim Rdr As OleDb.OleDbDataReader
        Dim Ordr As Integer
        Dim Ordr1 As Integer
        Dim Q1 As New List(Of Area)
        Dim Q2 As New List(Of Area)
        Dim Q3 As New List(Of Area)
        Dim Lst1 As New List(Of Area)
        Dim ELst As New List(Of List(Of Area))
        Dim TLst As New List(Of Area)
        Dim TLst1 As New List(Of Area)

        Dim ArCon As Area
        Dim LstF As New List(Of Integer)
        Dim LstRet As New List(Of List(Of Integer))
        Dim Arr As Area
        Dim LstT As New List(Of Integer)

        Try
            For i As Integer = 0 To Q.Count - 1
                Ar1 = Q(i)

                If Ar1.width >= Ar.width AndAlso Ar1.height >= Ar.height Then
                    Lst.Add(i)
                    Lst1.Add(Ar1)
                End If

            Next

            For j As Integer = 0 To Lst1.Count - 1
                Arr = Lst1(j)

                For i As Integer = 0 To Q.Count - 1
                    Ar1 = Q(i)

                    If Ar1.StrtPt.x = Arr.StrtPt.x + Arr.length AndAlso Ar1.length + Arr.length = Ar.length AndAlso (Ar1.StrtPt.y = Arr.StrtPt.y OrElse Ar1.StrtPt.y + Ar1.width = Arr.StrtPt.y + Arr.width) AndAlso Ar1.StrtPt.z = Arr.StrtPt.z Then
                        TLst.Add(Arr)
                        TLst1.Add(Ar1)
                        Lst2.Add(Lst(j))
                        LstF.Add(i)

                    End If
                Next
            Next

            Try
                Cmd.Connection = conn
                Cmd.CommandText = "delete from temp3"
                Cmd.ExecuteNonQuery()
            Catch e As Exception
                conn.Dispose()
                conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\container.mdb;Persist Security Info=False"
                conn.Open()
                Cmd.Cancel()
                Cmd.Connection = Nothing
                Cmd.Connection = conn
                Cmd.CommandText = ""
                Cmd.CommandText = "delete from temp3"
                Cmd.ExecuteNonQuery()
            End Try

            For i As Integer = 0 To TLst.Count - 1
                ArCon = TLst(i)
                Ordr = Lst2(i)
                Ordr1 = LstF(i)

                Try
                    Cmd.Connection = conn
                    Cmd.CommandText = "insert into temp3 values(" & CStr(ArCon.StrtPt.x) & "," & CStr(ArCon.StrtPt.y) & "," & CStr(ArCon.StrtPt.z) & "," & CStr(Ordr) & "," & CStr(Ordr1) & ")"
                    Cmd.ExecuteNonQuery()

                Catch ex As Exception
                    Cmd.Cancel()
                    Cmd.Connection = Nothing
                    Cmd.Connection = conn
                    Cmd.CommandText = ""
                    Cmd.CommandText = "delete from temp3"
                    Cmd.ExecuteNonQuery()
                End Try
            Next

            Cmd.CommandText = "Select * from temp3 order by z desc, x asc, y asc"
            Rdr = Cmd.ExecuteReader
            Rdr.Read()

            If Rdr.HasRows Then
                Ordr = Rdr.Item("i")
                Ordr1 = Rdr.Item("j")
                LstT.Add(Ordr)
                LstT.Add(Ordr1)
                LstRet.Add(LstT)
                Return LstT
            Else
                Return Nothing
            End If

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in FindCandidateWad", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try

    End Function

    'orig
    Public Function findcandidate(ByVal q As List(Of Area), ByVal ar As Area) As List(Of Integer)

        Dim lst As New List(Of Integer)
        Dim lst2 As New List(Of Integer)
        Dim retlst As New Queue
        Dim ar1 As New Area
        Dim cnt As Integer = 0
        Dim cmd As New OleDb.OleDbCommand
        Dim rdr As OleDb.OleDbDataReader
        Dim ordr As Integer
        Dim ordr1 As Integer
        Dim q1 As New List(Of Area)
        Dim q2 As New List(Of Area)
        Dim q3 As New List(Of Area)
        Dim lst1 As New List(Of Area)
        Dim elst As New List(Of List(Of Area))
        Dim tlst As New List(Of Area)
        Dim tlst1 As New List(Of Area)

        Dim arcon As Area
        Dim lstf As New List(Of Integer)
        Dim lstret As New List(Of List(Of Integer))
        Dim arr As Area
        Dim lstt As New List(Of Integer)

        Try
            For i As Integer = 0 To q.Count - 1
                ar1 = q(i)

                If ar1.width >= ar.width AndAlso ar1.height >= ar.height Then
                    lst.Add(i)
                    lst1.Add(ar1)
                End If

            Next

            For j As Integer = 0 To lst1.Count - 1
                arr = lst1(j)

                For i As Integer = 0 To q.Count - 1
                    ar1 = q(i)

                    If ar1.StrtPt.x = arr.StrtPt.x + arr.length AndAlso ar1.length + arr.length >= ar.length AndAlso (ar1.StrtPt.y = arr.StrtPt.y OrElse ar1.StrtPt.y + ar1.width = arr.StrtPt.y + arr.width) AndAlso ar1.StrtPt.z = arr.StrtPt.z AndAlso ar1.StrtPt.y <= arr.StrtPt.y Then
                        tlst.Add(arr)
                        tlst1.Add(ar1)
                        lst2.Add(lst(j))
                        lstf.Add(i)

                    End If
                Next
            Next

            Try
                cmd.Connection = conn
                cmd.CommandText = "delete from temp3"
                cmd.ExecuteNonQuery()
            Catch e As Exception
                conn.Dispose()
                conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\container.mdb;Persist Security Info=False"
                conn.Open()
                cmd.Cancel()
                cmd.Connection = Nothing
                cmd.Connection = conn
                cmd.CommandText = ""
                cmd.CommandText = "delete from temp3"
                cmd.ExecuteNonQuery()
            End Try

            For i As Integer = 0 To tlst.Count - 1
                arcon = tlst(i)
                ordr = lst2(i)
                ordr1 = lstf(i)
                Try
                    cmd.Connection = conn
                    cmd.CommandText = "insert into temp3 values(" & CStr(arcon.StrtPt.x) & "," & CStr(arcon.StrtPt.y) & "," & CStr(arcon.StrtPt.z) & "," & CStr(ordr) & "," & CStr(ordr1) & ")"
                    cmd.ExecuteNonQuery()
                Catch e As Exception
                    cmd.Cancel()
                    cmd.Connection = Nothing
                    cmd.Connection = conn
                    cmd.CommandText = ""
                    cmd.CommandText = "delete from temp3"
                    cmd.ExecuteNonQuery()
                End Try

            Next

            cmd.CommandText = "select * from temp3 order by z desc, x asc, y asc"
            rdr = cmd.ExecuteReader
            rdr.Read()
            If rdr.HasRows Then
                ordr = rdr.Item("i")
                ordr1 = rdr.Item("j")
                lstt.Add(ordr)
                lstt.Add(ordr1)
                lstret.Add(lstt)
                Return lstt
            Else
                Return Nothing
            End If

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in findcandidate", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try

    End Function

    Public Function findcandidate_Move(ByVal q As List(Of Area), ByVal ar As Area) As List(Of Integer)

        'Stop
        'off.Close()
        Dim lst As New List(Of Integer)
        Dim lst2 As New List(Of Integer)
        Dim retlst As New Queue
        Dim ar1 As New Area
        Dim cnt As Integer = 0
        Dim cmd As New OleDb.OleDbCommand
        Dim rdr As OleDb.OleDbDataReader
        Dim ordr As Integer
        Dim ordr1 As Integer
        Dim q1 As New List(Of Area)
        Dim q2 As New List(Of Area)
        Dim q3 As New List(Of Area)
        Dim lst1 As New List(Of Area)
        Dim elst As New List(Of List(Of Area))
        Dim tlst As New List(Of Area)
        Dim tlst1 As New List(Of Area)

        Dim arcon As Area
        Dim lstf As New List(Of Integer)
        Dim lstret As New List(Of List(Of Integer))
        Dim arr As Area
        Dim lstt As New List(Of Integer)

        Try
            'Stop

            'If Bitemqty = 60 Then
            '    Stop
            '    'off.Close()
            'End If

            For i As Integer = 0 To q.Count - 1
                ar1 = q(i)

                Dim X As Double = ar1.StrtPt.x
                Dim Y As Double = ar1.StrtPt.y
                Dim Z As Double = ar1.StrtPt.z

                'If ar1.width >= ar.width AndAlso ar1.height >= ar.height Then
                '    lst.Add(i)
                '    lst1.Add(ar1)
                'End If

                'Stop

                If ar1.width >= ar.width AndAlso ar1.height >= ar.height AndAlso ar1.length >= ar.length Then

                    'Stop

                    lst.Add(i)
                    lst1.Add(ar1)
                End If

            Next

            For j As Integer = 0 To lst1.Count - 1
                arr = lst1(j)

                For i As Integer = 0 To q.Count - 1
                    ar1 = q(i)

                    If ar1.StrtPt.x = arr.StrtPt.x + arr.length AndAlso ar1.length + arr.length >= ar.length AndAlso (ar1.StrtPt.y = arr.StrtPt.y OrElse ar1.StrtPt.y + ar1.width = arr.StrtPt.y + arr.width) AndAlso ar1.StrtPt.z = arr.StrtPt.z AndAlso ar1.StrtPt.y <= arr.StrtPt.y Then

                        tlst.Add(arr)
                        tlst1.Add(ar1)
                        lst2.Add(lst(j))
                        lstf.Add(i)

                    End If
                Next
            Next

            Try
                cmd.Connection = conn
                cmd.CommandText = "delete from temp3"
                cmd.ExecuteNonQuery()
            Catch e As Exception
                conn.Dispose()
                conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\container.mdb;Persist Security Info=False"
                conn.Open()
                cmd.Cancel()
                cmd.Connection = Nothing
                cmd.Connection = conn
                cmd.CommandText = ""
                cmd.CommandText = "delete from temp3"
                cmd.ExecuteNonQuery()
            End Try

            For i As Integer = 0 To tlst.Count - 1
                arcon = tlst(i)
                ordr = lst2(i)
                ordr1 = lstf(i)
                Try
                    cmd.Connection = conn
                    cmd.CommandText = "insert into temp3 values(" & CStr(arcon.StrtPt.x) & "," & CStr(arcon.StrtPt.y) & "," & CStr(arcon.StrtPt.z) & "," & CStr(ordr) & "," & CStr(ordr1) & ")"
                    cmd.ExecuteNonQuery()
                Catch e As Exception
                    cmd.Cancel()
                    cmd.Connection = Nothing
                    cmd.Connection = conn
                    cmd.CommandText = ""
                    cmd.CommandText = "delete from temp3"
                    cmd.ExecuteNonQuery()
                End Try

            Next

            cmd.CommandText = "select * from temp3 order by z desc ,x asc,y asc"
            'cmd.CommandText = "select * from temp3 order by z asc, x asc, y asc"
            rdr = cmd.ExecuteReader
            rdr.Read()
            If rdr.HasRows Then
                ordr = rdr.Item("i")
                ordr1 = rdr.Item("j")
                lstt.Add(ordr)
                lstt.Add(ordr1)
                lstret.Add(lstt)
                Return lstt
            Else
                Return Nothing
            End If

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in findcandidate", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try

    End Function

    Public Function Action_Candidate(ByVal q As List(Of Area), ByVal ar As Area) As List(Of Integer)

        'Stop
        'off.Close()
        Dim lst As New List(Of Integer)
        Dim lst2 As New List(Of Integer)
        Dim retlst As New Queue
        Dim ar1 As New Area
        Dim cnt As Integer = 0
        Dim cmd As New OleDb.OleDbCommand
        Dim rdr As OleDb.OleDbDataReader
        Dim ordr As Integer
        Dim ordr1 As Integer
        Dim q1 As New List(Of Area)
        Dim q2 As New List(Of Area)
        Dim q3 As New List(Of Area)
        Dim lst1 As New List(Of Area)
        Dim elst As New List(Of List(Of Area))
        Dim tlst As New List(Of Area)
        Dim tlst1 As New List(Of Area)

        Dim arcon As Area
        Dim lstf As New List(Of Integer)
        Dim lstret As New List(Of List(Of Integer))
        Dim arr As Area
        Dim lstt As New List(Of Integer)

        Dim CntLst As New List(Of Integer)
        Dim AraLst As New List(Of Area)
        Dim flgAC As Boolean = False

        Try
            'Stop

            If Bitemqty = 60 Then
                'Stop
                'off.Close()
                flgAC = True
            End If

            For K As Integer = 0 To q.Count - 1
                ar1 = q(K)

                If ar1.width >= ar.width AndAlso ar1.height >= ar.height Then
                    CntLst.Add(K)
                    AraLst.Add(ar1)
                End If
            Next

            For i As Integer = 0 To q.Count - 1
                ar1 = q(i)

                Dim X As Double = ar1.StrtPt.x
                Dim Y As Double = ar1.StrtPt.y
                Dim Z As Double = ar1.StrtPt.z

                'If ar1.width >= ar.width AndAlso ar1.height >= ar.height Then
                '    lst.Add(i)
                '    lst1.Add(ar1)
                'End If
                'Stop

                If ar1.width >= ar.width AndAlso ar1.height >= ar.height AndAlso ar1.length >= ar.length Then
                    'Stop
                    lst.Add(i)
                    lst1.Add(ar1)
                End If
            Next

            For j As Integer = 0 To lst1.Count - 1
                If Not flgAC Then
                    arr = lst1(j)
                Else
                    arr = AraLst(j)
                End If

                For i As Integer = 0 To q.Count - 1
                    ar1 = q(i)

                    If ar1.StrtPt.x = arr.StrtPt.x + arr.length AndAlso ar1.length + arr.length >= ar.length AndAlso (ar1.StrtPt.y = arr.StrtPt.y OrElse ar1.StrtPt.y + ar1.width = arr.StrtPt.y + arr.width) AndAlso ar1.StrtPt.z = arr.StrtPt.z AndAlso ar1.StrtPt.y <= arr.StrtPt.y Then
                        tlst.Add(arr)
                        tlst1.Add(ar1)
                        lst2.Add(lst(j))
                        lstf.Add(i)

                    End If
                Next
            Next

            Try

                cmd.Connection = conn
                cmd.CommandText = "delete from temp3"
                cmd.ExecuteNonQuery()

            Catch e As Exception
                conn.Dispose()
                conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\container.mdb;Persist Security Info=False"
                conn.Open()
                cmd.Cancel()
                cmd.Connection = Nothing
                cmd.Connection = conn
                cmd.CommandText = ""
                cmd.CommandText = "delete from temp3"
                cmd.ExecuteNonQuery()
            End Try

            For i As Integer = 0 To tlst.Count - 1

                arcon = tlst(i)
                ordr = lst2(i)
                ordr1 = lstf(i)

                Try
                    cmd.Connection = conn
                    cmd.CommandText = "insert into temp3 values(" & CStr(arcon.StrtPt.x) & "," & CStr(arcon.StrtPt.y) & "," & CStr(arcon.StrtPt.z) & "," & CStr(ordr) & "," & CStr(ordr1) & ")"
                    cmd.ExecuteNonQuery()
                Catch e As Exception
                    cmd.Cancel()
                    cmd.Connection = Nothing
                    cmd.Connection = conn
                    cmd.CommandText = ""
                    cmd.CommandText = "delete from temp3"
                    cmd.ExecuteNonQuery()
                End Try

            Next

            cmd.CommandText = "select * from temp3 order by z desc ,x asc,y asc"
            rdr = cmd.ExecuteReader
            rdr.Read()
            If rdr.HasRows Then
                ordr = rdr.Item("i")
                ordr1 = rdr.Item("j")
                lstt.Add(ordr)
                lstt.Add(ordr1)
                lstret.Add(lstt)
                Return lstt
            Else
                Return Nothing
            End If

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in findcandidate", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try

    End Function

    'Public Function findcandidate(ByVal q As List(Of Area), ByVal ar As Area) As List(Of Integer)

    '    Dim lst As New List(Of Integer)
    '    Dim lst2 As New List(Of Integer)
    '    Dim retlst As New Queue
    '    Dim ar1 As New Area
    '    Dim cnt As Integer = 0
    '    Dim cmd As New OleDb.OleDbCommand
    '    Dim rdr As OleDb.OleDbDataReader
    '    Dim ordr As Integer
    '    Dim ordr1 As Integer
    '    Dim q1 As New List(Of Area)
    '    Dim q2 As New List(Of Area)
    '    Dim q3 As New List(Of Area)
    '    Dim lst1 As New List(Of Area)
    '    Dim elst As New List(Of List(Of Area))
    '    Dim tlst As New List(Of Area)
    '    Dim tlst1 As New List(Of Area)

    '    Dim arcon As Area
    '    Dim lstf As New List(Of Integer)
    '    Dim lstret As New List(Of List(Of Integer))
    '    Dim arr As Area
    '    Dim lstt As New List(Of Integer)

    '    Try
    '        For i As Integer = 0 To q.Count - 1
    '            ar1 = q(i)

    '            If ar1.width >= ar.width AndAlso ar1.height >= ar.height Then
    '                lst.Add(i)
    '                lst1.Add(ar1)
    '            End If
    '        Next

    '        For j As Integer = 0 To lst1.Count - 1
    '            arr = lst1(j)

    '            For i As Integer = 0 To q.Count - 1
    '                ar1 = q(i)

    '                If ar1.StrtPt.x = arr.StrtPt.x + arr.length AndAlso ar1.length + arr.length >= ar.length AndAlso (ar1.StrtPt.y = arr.StrtPt.y OrElse ar1.StrtPt.y + ar1.width = arr.StrtPt.y + arr.width) AndAlso ar1.StrtPt.z = arr.StrtPt.z AndAlso ar1.StrtPt.y <= arr.StrtPt.y Then
    '                    If ar1.StrtPt.y = arr.StrtPt.y + arr.width AndAlso ar1.width + arr.width >= ar.width AndAlso (ar1.StrtPt.x = arr.StrtPt.x OrElse ar1.StrtPt.x + ar1.length = arr.StrtPt.x + arr.length) AndAlso ar1.StrtPt.z = arr.StrtPt.z AndAlso ar1.StrtPt.x <= arr.StrtPt.x Then
    '                        'If ar1.StrtPt.z = arr.StrtPt.z + arr.height AndAlso ar1.height + arr.height >= ar.height AndAlso (ar1.StrtPt.x = arr.StrtPt.x OrElse ar1.StrtPt.x + ar1.length = arr.StrtPt.x + arr.length) AndAlso (ar1.StrtPt.y = arr.StrtPt.y OrElse ar1.StrtPt.y + ar1.width = arr.StrtPt.y + arr.width) AndAlso ar1.StrtPt.x = arr.StrtPt.x AndAlso ar1.StrtPt.y = arr.StrtPt.y AndAlso ar1.StrtPt.x <= arr.StrtPt.x AndAlso ar1.StrtPt.y <= arr.StrtPt.y Then
    '                        ' If ar1.StrtPt.z = arr.StrtPt.z + arr.height AndAlso ar1.height + arr.height >= ar.height AndAlso (ar1.StrtPt.x = arr.StrtPt.x OrElse ar1.StrtPt.x + ar1.length = arr.StrtPt.x + arr.length) AndAlso ar1.StrtPt.x = arr.StrtPt.x AndAlso ar1.StrtPt.y = arr.StrtPt.y AndAlso ar1.StrtPt.y <= arr.StrtPt.y Then

    '                        tlst.Add(arr)
    '                        tlst1.Add(ar1)
    '                        lst2.Add(lst(j))
    '                        lstf.Add(i)

    '                    End If

    '                End If


    '                '   End If
    '            Next
    '        Next

    '        Try
    '            cmd.Connection = conn
    '            cmd.CommandText = "delete from temp3"
    '            cmd.ExecuteNonQuery()
    '        Catch e As Exception
    '            conn.Dispose()
    '            conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\container.mdb;Persist Security Info=False"
    '            conn.Open()
    '            cmd.Cancel()
    '            cmd.Connection = Nothing
    '            cmd.Connection = conn
    '            cmd.CommandText = ""
    '            cmd.CommandText = "delete from temp3"
    '            cmd.ExecuteNonQuery()
    '        End Try

    '        For i As Integer = 0 To tlst.Count - 1
    '            arcon = tlst(i)
    '            ordr = lst2(i)
    '            ordr1 = lstf(i)
    '            Try
    '                cmd.Connection = conn
    '                cmd.CommandText = "insert into temp3 values(" & CStr(arcon.StrtPt.x) & "," & CStr(arcon.StrtPt.y) & "," & CStr(arcon.StrtPt.z) & "," & CStr(ordr) & "," & CStr(ordr1) & ")"
    '                cmd.ExecuteNonQuery()
    '            Catch e As Exception
    '                cmd.Cancel()
    '                cmd.Connection = Nothing
    '                cmd.Connection = conn
    '                cmd.CommandText = ""
    '                cmd.CommandText = "delete from temp3"
    '                cmd.ExecuteNonQuery()
    '            End Try

    '        Next

    '        cmd.CommandText = "select * from temp3 order by z desc ,x asc,y asc"
    '        rdr = cmd.ExecuteReader
    '        rdr.Read()
    '        If rdr.HasRows Then
    '            ordr = rdr.Item("i")
    '            ordr1 = rdr.Item("j")
    '            lstt.Add(ordr)
    '            lstt.Add(ordr1)
    '            lstret.Add(lstt)
    '            Return lstt
    '        Else
    '            Return Nothing
    '        End If
    '    Catch Err As Exception
    '        MsgBox(Err.Message)
    '        MessageBox.Show("Error in findcandidate", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        Return Nothing
    '    End Try

    'End Function

    Public Function Chk1Wad(ByVal Ar As Area, ByVal Q As List(Of Area)) As Boolean

        Dim Ar1 As New Area
        Dim Ar2 As New Area
        Dim A1 As New Area
        Dim A2 As New Area
        Dim A3 As New Area
        Dim j As Integer = -1

        Try
            For i As Integer = 0 To Q.Count - 1
                Ar1 = Q(i)

                If Ar1.StrtPt.y = Ar.StrtPt.y + Ar.width AndAlso Ar.height = Ar1.height AndAlso Ar.StrtPt.z = Ar1.StrtPt.z Then

                    If Ar1.StrtPt.x > Ar.StrtPt.x AndAlso Ar1.StrtPt.x < Ar.StrtPt.x + Ar.length Then
                        j = i
                        Exit For
                    End If

                End If

            Next

            Dim K As Integer = -1

            If j <> -1 Then
                For i As Integer = 0 To Q.Count - 1
                    Ar2 = Q(i)

                    If Ar2.StrtPt.y < Ar.StrtPt.y AndAlso Ar2.StrtPt.y + Ar2.width = Ar.StrtPt.y + Ar.width AndAlso Ar2.StrtPt.z = Ar.StrtPt.z Then
                        K = i
                        Exit For
                    End If

                Next
            End If

            If j <> -1 AndAlso K <> -1 Then

                A1.StrtPt.x = Ar.StrtPt.x
                A1.StrtPt.y = Ar.StrtPt.y
                A1.StrtPt.z = Ar.StrtPt.z
                A1.length = Math.Abs(Ar1.StrtPt.x - Ar.StrtPt.x)
                A1.width = Ar.width
                A1.height = Ar.height

                A2.StrtPt.x = A1.StrtPt.x + A1.length
                A2.StrtPt.y = A1.StrtPt.y
                A2.StrtPt.z = A1.StrtPt.z
                A2.length = Ar1.length
                A2.width = Ar.width + Ar1.width
                A2.height = Ar1.height

                A3.StrtPt.x = Ar2.StrtPt.x
                A3.StrtPt.y = Ar2.StrtPt.y
                A3.StrtPt.z = Ar2.StrtPt.z
                A3.length = Ar2.length
                A3.width = Ar2.width - Ar.width
                A3.height = Ar.height

                Return True
            Else
                Return False

            End If

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in Chk1Wad", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function

    Public Function chk1(ByVal ar As Area, ByVal q As List(Of Area)) As Boolean

        Dim ar1 As New Area
        Dim ar2 As New Area
        Dim a1 As New Area
        Dim a2 As New Area
        Dim a3 As New Area
        Dim j As Integer = -1

        Try
            For i As Integer = 0 To q.Count - 1
                ar1 = q(i)
                If ar1.StrtPt.y = ar.StrtPt.y + ar.width AndAlso ar.height = ar1.height AndAlso ar.StrtPt.z = ar1.StrtPt.z Then

                    If ar1.StrtPt.x > ar.StrtPt.x AndAlso ar1.StrtPt.x < ar.StrtPt.x + ar.length Then
                        j = i
                        Exit For
                    End If
                End If
            Next

            Dim k As Integer = -1

            If j <> -1 Then
                For i As Integer = 0 To q.Count - 1
                    ar2 = q(i)
                    If ar2.StrtPt.y < ar.StrtPt.y AndAlso ar2.StrtPt.y + ar2.width = ar.StrtPt.y + ar.width AndAlso ar2.StrtPt.x = ar.StrtPt.x + ar.length AndAlso ar2.height = ar.height AndAlso ar2.StrtPt.z = ar.StrtPt.z Then
                        k = i
                        Exit For
                    End If
                Next
            End If

            If j <> -1 AndAlso k <> -1 Then

                a1.StrtPt.x = ar.StrtPt.x
                a1.StrtPt.y = ar.StrtPt.y
                a1.StrtPt.z = ar.StrtPt.z
                a1.length = Math.Abs(ar1.StrtPt.x - ar.StrtPt.x)
                a1.width = ar.width
                a1.height = ar.height

                a2.StrtPt.x = a1.StrtPt.x + a1.length
                a2.StrtPt.y = a1.StrtPt.y
                a2.StrtPt.z = a1.StrtPt.z
                a2.length = ar1.length
                a2.width = ar.width + ar1.width
                a2.height = ar1.height

                a3.StrtPt.x = ar2.StrtPt.x
                a3.StrtPt.y = ar2.StrtPt.y
                a3.StrtPt.z = ar2.StrtPt.z
                a3.length = ar2.length
                a3.width = ar2.width - ar.width
                a3.height = ar.height

                Return True
            Else
                Return False

            End If

        Catch exr As Exception
            MsgBox(exr.Message)
            MsgBox(exr.ToString)
            MessageBox.Show("Error in chk1", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function

    Public Function Chk11Wad(ByVal Ar1 As Area, ByRef Q As List(Of Area)) As Boolean

        Dim Ar As New Area
        Dim A1 As New Area
        Dim A2 As New Area
        Dim j As Integer = -1

        Try

            For i As Integer = 0 To Q.Count - 1
                Ar = Q(i)
                If Ar1.StrtPt.y > Ar.StrtPt.y AndAlso Ar1.StrtPt.x = Ar.StrtPt.x + Ar.length AndAlso Ar.height = Ar1.height Then
                    j = i
                    Exit For
                End If
            Next

            If j <> -1 Then
                Q.RemoveAt(j)
            End If

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in Chk11Wad", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function

    Public Function chk11(ByVal ar1 As Area, ByRef q As List(Of Area)) As Boolean

        Dim ar As New Area
        Dim a1 As New Area
        Dim a2 As New Area
        Dim j As Integer = -1

        Try
            For i As Integer = 0 To q.Count - 1
                ar = q(i)
                If ar1.StrtPt.y > ar.StrtPt.y AndAlso ar1.StrtPt.x = ar.StrtPt.x + ar.length AndAlso ar1.StrtPt.y + ar1.width = ar.StrtPt.y + ar.width AndAlso ar1.StrtPt.z = ar.StrtPt.z AndAlso ar.height = ar1.height Then
                    j = i
                    Exit For
                End If

            Next

            If j <> -1 Then
                q.RemoveAt(j)

                a1.StrtPt.x = ar.StrtPt.x
                a1.StrtPt.y = ar.StrtPt.y
                a1.StrtPt.z = ar.StrtPt.z
                a1.length = ar.length
                a1.width = ar.width - ar1.width
                a1.height = ar.height

                a2.StrtPt.x = ar.StrtPt.x
                a2.StrtPt.y = ar1.StrtPt.y
                a2.StrtPt.z = ar1.StrtPt.z
                a2.length = ar.length + ar1.length
                a2.width = ar1.width
                a2.height = ar1.height

                q = UnPush(q, a1)
                q = UnPush(q, a2)
                Return True
            Else
                Return False
            End If

        Catch EXR As Exception
            MsgBox(EXR.Message)
            MsgBox(EXR.ToString)
            MessageBox.Show("Error in chk11", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function

    Public Function chk1old(ByVal ar As Area, ByVal q As List(Of Area)) As Boolean

        Dim ar1 As New Area
        Dim a1 As New Area
        Dim a2 As New Area
        Dim j As Integer = -1

        Try
            For i As Integer = 0 To q.Count - 1

                ar1 = q(i)

                If ar1.StrtPt.y = ar.StrtPt.y + ar.width AndAlso ar.height = ar1.height AndAlso ar.StrtPt.z = ar1.StrtPt.z Then

                    If ar1.StrtPt.x > ar.StrtPt.x AndAlso ar1.StrtPt.x < ar.StrtPt.x + ar.length Then
                        j = i
                        Exit For
                    End If
                End If
            Next

            If j <> -1 Then

                If ar.length < ar1.length Then
                    a1.StrtPt.x = ar.StrtPt.x
                    a1.StrtPt.y = ar.StrtPt.y
                    a1.StrtPt.z = ar.StrtPt.z

                    a1.length = Math.Abs(-ar.length + ar1.length)
                    a1.width = ar.width
                    a1.height = ar.height

                    a2.StrtPt.x = a1.StrtPt.x + a1.length
                    a2.StrtPt.y = a1.StrtPt.y
                    a2.StrtPt.z = a1.StrtPt.z

                    a2.length = ar1.length
                    a2.width = ar1.width + ar.width
                    a2.height = a1.height

                    q.RemoveAt(j)
                    UnPush(q, a2)
                    UnPush(q, a1)

                    Return True
                End If
            End If

            Return False

        Catch err As Exception
            MsgBox(err.Message)
            MsgBox(err.ToString)
            MessageBox.Show("Error in chk1old", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function

    Public Function chk2(ByVal ar As Area, ByVal q As List(Of Area)) As Integer

        Dim ar1 As New Area

        Try

            For i As Integer = 0 To q.Count - 1
                ar1 = q(i)
                If ar.StrtPt.y = ar1.StrtPt.y + ar1.width AndAlso ar.height = ar1.height AndAlso ar.StrtPt.z = ar1.StrtPt.z Then
                    If ar.StrtPt.x > ar1.StrtPt.x AndAlso ar.StrtPt.x < ar1.StrtPt.x + ar1.length Then
                        Return i
                    End If
                End If
            Next

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in chk2", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return -1

    End Function

    Public Function findaru1(ByVal q As List(Of Area), ByVal ar As Area, ByVal tpup As Boolean) As List(Of Integer)

        Dim ar1 As New Area
        Dim i1 As Integer

        Try
            For i As Integer = 0 To q.Count - 1
                ar1 = q(i)
                If Not Form4.ftip(ar1, ar, tpup) Then
                    i1 = chk1(ar1, q)
                End If

            Next

        Catch exw As Exception
            MsgBox(exw.Message)
            MsgBox(exw.ToString)
            MessageBox.Show("Error in findaru1", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return Nothing

    End Function

    Public Function findsupp(ByVal ar As Area, ByVal q As List(Of Area)) As Area

        Dim ar1 As New Area
        Try
            For i As Integer = 0 To q.Count - 1
                ar1 = q(i)
                If ar1.StrtPt.x = ar.StrtPt.x + ar.length AndAlso ar1.StrtPt.y + ar1.width = ar.StrtPt.y + ar.width Then
                    If ar.StrtPt.z = ar1.StrtPt.z AndAlso ar.height = ar1.height Then

                    End If

                End If

            Next

        Catch WR As Exception
            MsgBox(WR.Message)
            MsgBox(WR.ToString)
            MessageBox.Show("Error in findsupp", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return Nothing

    End Function

    Public Function UnionItrX(ByVal ar1 As Area, ByVal ar2 As Area) As List(Of Area)

        Dim arret1 As New Area
        Dim arret2 As New Area

        Try

            If ar2.StrtPt.y = ar1.StrtPt.y + ar1.width AndAlso ar1.height = ar2.height AndAlso ar1.StrtPt.z = ar2.StrtPt.z Then
                If ar2.StrtPt.x > ar1.StrtPt.x AndAlso ar2.StrtPt.x < ar1.StrtPt.x + ar1.length Then
                    arret1.StrtPt.x = ar1.StrtPt.x
                    arret1.StrtPt.y = ar1.StrtPt.y
                    arret1.StrtPt.z = ar1.StrtPt.z

                End If
            End If

        Catch DR As Exception
            MsgBox(DR.Message)
            MsgBox(DR.ToString)
            MessageBox.Show("Error in UnionItrX", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try

        Return Nothing

    End Function

    Public Function GetfWad(ByVal TbNm As String, ByVal Fltr As String, ByVal SrtCol As String) As DataRow()

        Dim pp As New System.Data.DataTable
        Dim Rw() As DataRow = Nothing
        Dim Sxml As New System.Xml.XmlDataDocument
        Dim RXml As Xml.XmlReader

        Try
            RXml = Xml.XmlReader.Create(CurDir() & "/" & TbNm & ".xml")
            RXml.Settings.Schemas.Add(vbNull, CurDir() & "/" & TbNm & ".xsd")

            Sxml.DataSet.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema
            Sxml.DataSet.ReadXml(RXml, XmlReadMode.InferTypedSchema)

            Rw = Sxml.DataSet.Tables(0).Select(Fltr, SrtCol)
            RXml.Close()

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in GetfWad", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return Rw

    End Function

    Public Function getf(ByVal tbname As String, ByVal fltr As String, ByVal srtcol As String) As DataRow()

        Dim mm As New System.Data.DataTable
        Dim rw() As DataRow = Nothing
        Dim asdf As New System.Xml.XmlDataDocument
        Dim nn1 As Xml.XmlReader

        Try

            nn1 = Xml.XmlReader.Create(CurDir() & "/" & tbname & ".xml")
            nn1.Settings.Schemas.Add(vbNull, CurDir() & "/" & tbname & ".xsd")

            asdf.DataSet.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema
            asdf.DataSet.ReadXml(nn1, XmlReadMode.InferTypedSchema)

            rw = asdf.DataSet.Tables(0).Select(fltr, srtcol)
            nn1.Close()

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in getf", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return rw

    End Function

    Public Function Stuffx(ByVal arc As Area, ByVal ar() As Area, ByVal ari() As String, ByVal arwt() As Single, ByVal saveopt As Boolean, ByVal showempty As Boolean, ByVal outfile As String, ByVal drawarc As Boolean, ByVal transparr() As Boolean, ByVal topup() As Boolean, ByVal txtopt As Boolean, ByVal drawopt As Boolean, ByVal findqtyflg As Boolean, ByVal chngflg As Boolean, ByVal colarr As List(Of List(Of Byte))) As List(Of Area)

        Dim stk2 As New List(Of Area)
        Dim stk1 As New Stack(Of Area)
        Dim art As New Area
        Dim arp As New Area
        Dim are As New Area
        Dim aru As New Area
        Dim arb As New Area
        Dim q As New Queue(Of Area)
        Dim q1 As New Queue(Of Area)
        Dim q2 As New Queue(Of Area)

        Dim ans1 As Boolean
        Dim szchg As Integer = 0
        Dim cmd As New OleDb.OleDbCommand

        Dim qtyflg As Boolean = True
        Dim traval As Single
        Dim ard As New Area
        Dim arm As New List(Of Integer)
        Dim arm1 As Integer
        Dim lstm As New List(Of Area)
        Dim a1 As New Area
        Dim a2 As New Area
        Dim ordr As Integer
        Dim totar As Double
        Dim tmplst As New List(Of String)
        Dim answ As MsgBoxResult
        Dim olditemqty As Integer = 0
        Dim col As String
        Dim ii As Integer
        Dim lorg As Single
        Dim worg As Single
        Dim horg As Single

        Try
            For i As Integer = LBound(ar) To UBound(ar)
                Dim mindim As Double = ar(i).height
                Dim md As String = "h"
                If ar(i).length < mindim Then
                    md = "l"
                    mindim = ar(i).length
                End If

                If ar(i).width < mindim Then
                    md = "w"
                    mindim = ar(i).width
                End If

                If md = "h" Then
                    Exit For
                End If

                If md = "l" Then
                    ar(i).length = ar(i).height
                    ar(i).height = mindim
                End If

                If md = "w" Then
                    ar(i).width = ar(i).height
                    ar(i).height = mindim
                End If

            Next

            If drawopt Then
                cmd.Connection = conn

x:
                Try
                    cmd.ExecuteNonQuery()
                Catch ec As Exception
                    If ec.Message = "Cannot open any more tables." Then
                        conn.Close()
                        conn.Dispose()
                        OleDb.OleDbConnection.ReleaseObjectPool()
                        cmd.Dispose()
                        GC.Collect()

                        conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\container.mdb;Persist Security Info=False"

                        conn.Open()

                        GoTo x

                    End If

                End Try
            End If

            If saveopt Then

            End If
            Dim ptx As New Point

            ptx.x = arc.length
            ptx.y = arc.width
            ptx.z = arc.height
            If drawopt Or drawarc Then

            End If

            Dim col1 As New List(Of Byte)
            col1.Clear()
            col1.Add(255)
            col1.Add(255)
            col1.Add(255)
            col = "1"
            Dim itmnm As String = ""
            If drawarc Then
                Dim ard1 As New Area
                If drawarc Then
                    itmnm = "container"
                    arc.AutoDraw(outfile, col, 0.5, "", itmnm, 0, True, False, "container", 0, True, "b", "1")
                End If
                ard.StrtPt.x = arc.length
                ard.StrtPt.y = 0
                ard.StrtPt.z = 0
                ard.length = 0.5
                ard.width = arc.width
                ard.height = arc.height
                If drawopt Or drawarc Then

                    ard.AutoDraw(outfile, "", 0, "file:///c:\contdoor.png", "", 0, True, False, "door", 0, False, "b", "1")
                End If
                ard1.StrtPt.x = arc.length - 0.01
                ard1.StrtPt.y = 0
                ard1.StrtPt.z = 0
                ard1.length = 0.5
                ard1.width = ard.width
                ard1.height = ard.height
                If drawopt Or drawarc Then
                    ard1.AutoDraw(outfile, "b", 0, "file:///c:\contdoor.png", "", 0, True, False, "door1", 0, False, "b", "1")
                    col1.Clear()
                End If

            End If
            If saveopt Then

            End If

            arc.StrtPt.x = 0            ' Initializing the starting points
            arc.StrtPt.y = 0
            arc.StrtPt.z = 0

            Dim j As Integer = 0
            totar = 0
            Bareaarr.Clear()
            For i As Integer = 0 To stk.Count - 1
                stk2.Add(stk(i))
            Next
            Bitemqty = 0

            If Not IsNothing(ari) Then
                'Form8.Show()

                TransactionMenu.lblStatus.Visible = True
                TransactionMenu.lblStatusINm.Visible = True

                TransactionMenu.btnStatus.Visible = True

                '@
                TransactionMenu.btnPause.Visible = True
                TransactionMenu.mtxtbxPause.Visible = True
                TransactionMenu.lblSec.Visible = True

                TransactionMenu.pbCSP1.Visible = True
                ProgressBarRunning()

                If drawopt Then
                    'Form8.Button1.Visible = False

                    TransactionMenu.btnStatus.Visible = False

                    '@
                    TransactionMenu.btnPause.Visible = False
                    TransactionMenu.lblSec.Visible = False
                    TransactionMenu.mtxtbxPause.Visible = False

                End If
                'Form8.Focus()
                TransactionMenu.lblStatus.Focus()
            End If

            For i As Integer = 0 To Bqtylst.Count - 1
                Bplclst.Add(-1)
            Next

            fullflag = False
            olditemqty = 0
            If saveopt Then
                DelTab("temp7")

            End If
            stksav.Clear()
            Do While Not stk.Count = 0 And j <= UBound(ar)

                lorg = ar(j).length
                worg = ar(j).width
                horg = ar(j).height

                ordr = 0

                If j = 0 Then
                    col = "r"

                End If

                If Bqtylst.Count > 0 Then
                    Bplclst(Bitemno) = Bitemqty

                End If

                If j > 0 And Not IsNothing(ari) Then

                    If ari(j - 1) <> ari(j) Then

                        If Bqtylst.Count > 0 Then
                            Bplclst(Bitemno) = Bitemqty - 1

                        End If

                        Bmaxqtylst.Add(Bitemqty)
                        Bitemno += 1

                        'Form8.Label1.Text = "Stuffing item:" & ari(j)
                        'Form8.Label1.Refresh()

                        TransactionMenu.lblStatus.Visible = True
                        TransactionMenu.lblStatusINm.Visible = True
                        TransactionMenu.lblStatus.Text = "Stuffing item:" & ari(j)
                        TransactionMenu.lblStatus.Refresh()

                        TransactionMenu.pbCSP1.Visible = True
                        ProgressBarRunning()

                    Else

                        'Form8.Label1.Text = "Stuffing item:" & ari(j)
                        'Form8.Label1.Refresh()

                        TransactionMenu.lblStatus.Visible = True
                        TransactionMenu.lblStatusINm.Visible = True
                        TransactionMenu.lblStatus.Text = "Stuffing item:" & ari(j)
                        TransactionMenu.lblStatus.Refresh()

                        TransactionMenu.pbCSP1.Visible = True
                        ProgressBarRunning()

                    End If

                Else

                    If j > 0 Then
                        'Form8.Show()

                        TransactionMenu.lblStatus.Visible = True
                        TransactionMenu.lblStatusINm.Visible = True
                        TransactionMenu.btnStatus.Visible = True

                        '@
                        TransactionMenu.btnPause.Visible = True
                        TransactionMenu.mtxtbxPause.Visible = True
                        TransactionMenu.lblSec.Visible = True

                        TransactionMenu.pbCSP1.Visible = True
                        ProgressBarRunning()

                        If drawopt Then

                            'Form8.Button1.Visible = False
                            TransactionMenu.btnStatus.Visible = False

                            '@
                            TransactionMenu.btnPause.Visible = False
                            TransactionMenu.lblSec.Visible = False
                            TransactionMenu.mtxtbxPause.Visible = False

                        End If
                        'Form8.Label1.Text = "Finding Maximum Quantity ....."
                        'Form8.Label1.Refresh()

                        TransactionMenu.lblStatus.Text = "Finding Maximum Quantity ....."
                        TransactionMenu.lblStatus.Refresh()

                    End If
                End If

                If drawopt Then
                    If j > 0 Then

                        If ari(j - 1) <> ari(j) Then

                            Bitemqty = 0

                            If col = "r" Then
                                col = "g"
                            ElseIf col = "g" Then
                                col = "b"
                            ElseIf col = "b" Then
                                col = "m"
                            ElseIf col = "m" Then
                                col = "c"
                            ElseIf col = "c" Then
                                col = "y"
                            End If

                            szchg += 1
                            qtyflg = True

                        Else
                            qtyflg = False
                        End If
                    End If
                End If

                arm1 = findoptx(stk, ar(j), topup(j))
                art = Nothing
                If arm1 <> -1 Then
                    art = stk(arm1)

                End If

                Dim arn As New List(Of Integer)
                Dim lstn As New List(Of Area)
                Dim b1 As New Area
                Dim b2 As New Area
                arm = Nothing
                arn = Nothing
                arn = findcandidate1x(stk, ar(j))

                Dim lstk As New List(Of Area)
                If Not arm Is Nothing Then
                    Dim lstt As New List(Of Area)
                    For i As Integer = 0 To arm.Count - 1
                        lstt.Add(stk(arm(i)))
                    Next
                    lstk = mergez(lstt)

                End If
                Dim arlst As New List(Of Area)
                If Not arn Is Nothing Then
                    lstm = unionpx(stk(arn(0)), stk(arn(1)))
                    b1 = lstm(0)
                    b2 = lstm(1)

                End If

                If arm Is Nothing And arm1 = -1 Then
                    If drawopt Then

                    End If

                    Bplclst(Bitemno) = Bplclst(Bitemno) - 1

                    For m As Integer = j To UBound(ari) - 1
                        If ari(m) <> ari(j) Then
                            j = m

                            GoTo lp

                        End If
                    Next
                    j = UBound(ari) + 1

                    GoTo lp

                Else
                    If arn Is Nothing And arm1 = -1 Then
                        If drawopt Then

                        End If

                        Bplclst(Bplclst.Count - 1) = Bplclst(Bplclst.Count - 1) - 1

                        For m As Integer = j To UBound(ari) - 1
                            If ari(m) <> ari(j) Then
                                j = m
                                GoTo lp

                            End If
                        Next
                        j = UBound(ari)

                    End If
                End If

                If Not arm Is Nothing Or Not arn Is Nothing Then

                    DelTab("temp5")
z:

                    ordr = 0
                    If Not arm Is Nothing Then

                        a1 = lstk(0)
                        instab("temp5", New Object() {CStr(a1.StrtPt.x), CStr(a1.StrtPt.y), CStr(a1.StrtPt.z), CStr(1)})

                    End If

                    If Not arn Is Nothing Then
                        instab("temp5", New Object() {CStr(b1.StrtPt.x), CStr(b1.StrtPt.y), CStr(b1.StrtPt.z), CStr(2)})

                    End If

                    If Not art Is Nothing Then
                        instab("temp5", New Object() {CStr(art.StrtPt.x), CStr(art.StrtPt.y), CStr(art.StrtPt.z), CStr(3)})

                    End If

                    Dim rwx As DataRow() = Nothing
                    If Not arm Is Nothing Then

                        rwx = getf("temp5", "", "z asc ,x asc ,y asc")
                    End If

                    If Not arn Is Nothing Then

                        rwx = getf("temp5", "", "z asc ,x asc ,y asc")
                    End If

                    If arn Is Nothing And arm Is Nothing Then

                        rwx = getf("temp5", "", "z asc ,x asc ,y asc")
                    End If

                    If arm Is Nothing And arn Is Nothing Then

                        rwx = getf("temp5", "", "z asc ,x asc ,y asc")
                    End If

                    ordr = rwx(0)("i")

                    If ordr = 3 Then
                        stk.RemoveAt(arm1)
                    Else
                        If ordr = 1 Then

                            For i As Integer = 1 To lstk.Count - 1
                                stk.Add(lstk(i))
                            Next

                            art = a1
                            arm.Sort()
                            arm.Reverse()

                            For i As Integer = 0 To arm.Count - 1
                                stk.RemoveAt(arm(i))
                            Next

                        End If
                        If ordr = 2 Then

                            art = b1
                            arn.Sort()
                            arn.Reverse()

                            For i As Integer = 0 To arn.Count - 1
                                stk.RemoveAt(arn(i))
                            Next

                        End If
                        If ordr = 3 Then
                            stk.RemoveAt(arm1)
                        End If
                    End If
                Else

                    If arm1 <> -1 Then
                        stk.RemoveAt(arm1)
                    End If
                End If

                Dim qty As Integer
                If chngflg Then

                    ' This method is find out the maximum quantity is placed in the container
                    ' in particular way that the as maximum quantity is fit into it.

                    ii = FindOptMethod(ar(j), art, qty, topup(j))

                    Dim ln As Double = ar(j).length
                    Dim wd As Double = ar(j).width
                    Dim ht As Double = ar(j).height

                    Dim nm As String = ari(j)
                    Dim p As Integer = j

                    If ii = 1 Then

                    End If

                    If ii = 2 Then
                        ar(p).length = ln
                        ar(p).width = ht
                        ar(p).height = wd

                    End If

                    If ii = 3 Then
                        ar(p).length = wd
                        ar(p).width = ht
                        ar(p).height = ln

                    End If

                    If ii = 4 Then
                        ar(p).length = wd
                        ar(p).width = ln
                        ar(p).height = ht

                    End If

                    If ii = 5 Then
                        ar(p).length = ht
                        ar(p).width = wd
                        ar(p).height = ln

                    End If

                    If ii = 6 Then
                        ar(p).length = ht
                        ar(p).width = ln
                        ar(p).height = wd

                    End If

                End If

                Dim flg As Boolean = ar(j).length * ar(j).width * ar(j).height * qty = art.length * art.width * art.height
                Dim mm As Integer = findqty(ari, j)
                If mm >= qty And flg Then

                    If drawopt Then

                    Else
                        j += qty - 1

                        Bitemqty += qty - 1
                        Bplclst(Bitemno) = Bitemqty

                    End If

                End If

                arm = Nothing
                arn = Nothing
                ar(j).StrtPt.x = art.StrtPt.x
                ar(j).StrtPt.y = art.StrtPt.y
                ar(j).StrtPt.z = art.StrtPt.z

                If saveopt Then

                End If

                If drawopt Then

                    If transparr(j) Then
                        traval = 0.8
                    Else
                        traval = 0
                    End If
                End If
                If j = UBound(ar) Then

                End If
                If drawopt Then
                    If j <> 0 Then
                        If ari(j) <> ari(j - 1) Then
                            tmplst.Add(ari(j - 1))
                            tmplst.Add(CStr(totar))
                            Bareaarr.Add(tmplst)
                            totar = 0
                            totar = totar + (ar(j).length * ar(j).width * ar(j).height)
                        Else
                            totar = totar + (ar(j).length * ar(j).width * ar(j).height)
                        End If
                    Else
                        totar = totar + (ar(j).length * ar(j).width * ar(j).height)
                    End If
                End If

                If drawopt Then
                    txtopt = True

                    xcnt += 1


                    If ar(j).length = lorg AndAlso ar(j).width = worg AndAlso ar(j).height = horg Then
                        ii = 1
                    End If

                    If ar(j).length = lorg AndAlso ar(j).width = horg Then
                        ii = 2
                    End If

                    If ar(j).length = worg AndAlso ar(j).width = horg Then
                        ii = 3
                    End If

                    If ar(j).length = worg AndAlso ar(j).width = lorg Then
                        ii = 4
                    End If

                    If ar(j).length = horg AndAlso ar(j).height = lorg Then
                        ii = 5
                    End If

                    If ar(j).length = horg AndAlso ar(j).width = lorg Then
                        ii = 6
                    End If

                    ar(j).AutoDraw(outfile, col, traval, "file:///c:/t2.png", ari(j), arwt(j), qtyflg, txtopt, ari(j), ii, True, "b", "1")

                    Bitemqty += 1
                    Btotwt += arwt(j)
                Else
                    Bitemqty += 1
                    Btotwt += arwt(j)
                End If
                If saveopt Then
                    instab("temp7", New Object() {j, ari(j), ar(j).StrtPt.x, ar(j).StrtPt.y, ar(j).StrtPt.z, ar(j).length, ar(j).width, ar(j).height, col})
                End If

                If saveopt Then
                    If chkwt Then

                        If Btotwt >= contcap Then

                            answ = MsgBox("Maximum weight capacity of the container is reached" & vbCrLf & "Do you want to proceed?", MsgBoxStyle.YesNo)
                            If answ = MsgBoxResult.No Then
                                fullflag = True

                                If saveopt Then
                                    xcnt = j
                                End If
                                chkwt = True

                                If saveopt Then
                                    Dim sts As New List(Of Area)
                                    For jj As Integer = 0 To stk.Count - 1

                                        sts.Add(stk(jj))
                                    Next
                                    stksav.Add(sts)
                                End If
                                Exit Do

                            Else
                                fullflag = False
                                chkwt = False
                            End If
                        End If

                    End If
                End If

                If Bqtylst.Count > 1 Then
                    Bplclst(Bitemno) = Bitemqty - 1
                    Bmaxqtylst.Add(Bitemqty - 1)
                End If
                If Not IsNothing(ari) Then
                    Form8.i = Bitemqty
                    'Form8.Label2.Text = CStr(itemqty) & " Items stuffed"
                    'Form8.Label2.Refresh()
''Satwadhir Pawar 9/18/2005 12:31:11 PM
                    ''-----------------------------------

                    'TransactionMenu.lblStatus.Visible = True
                    ''TransactionMenu.lblStatus.Text = CStr(itemqty) & " Items stuffed"
                    'TransactionMenu.lblStatus.Text = " Numbers ::   " & CStr(Bitemqty) & "    -> Items stuffed"
                    'TransactionMenu.lblStatus.Refresh()

                    ''-----------------------------------

                    TransactionMenu.pbCSP1.Visible = True
                    ProgressBarRunning()

                    System.Windows.Forms.Application.DoEvents()
                    If exflg Then
                        exflg = False
                        GoTo lp
                    End If
                End If

                q = art.subtractx(ar(j))

                Dim dd As New Area
                If Not q Is Nothing Then
                    If stk.Count = 0 Then
                        Do While Not q.Count = 0

                            dd = q.Dequeue

                            stk.Add(dd)

                        Loop
                    Else
                        Do While q.Count > 0
                            arb = q.Dequeue
                            ans1 = False

                            stk = UnPush(stk, arb)

                        Loop

                    End If

                End If

                j += 1

lp:
                If saveopt Then
                    Dim sts As New List(Of Area)
                    For jj As Integer = 0 To stk.Count - 1

                        sts.Add(stk(jj))
                    Next
                    stksav.Add(sts)
                End If

            Loop

            Bmaxqtylst.Add(Bitemqty)
            'Form8.Close()

            TransactionMenu.btnStatus.Visible = False

            '@
            TransactionMenu.btnPause.Visible = False
            TransactionMenu.lblSec.Visible = False
            TransactionMenu.mtxtbxPause.Visible = False

            TransactionMenu.lblStatus.Visible = False
            TransactionMenu.lblStatusINm.Visible = False

            TransactionMenu.pbCSP1.Visible = False

            Eventless()

            If UBound(ar) >= j Then
                fullflag = True
            End If

            If findqtyflg Then
                stk.Clear()
                For i As Integer = 0 To stk.Count - 1
                    If Not chk1(stk2(i), stk) Then
                        If Not chk11(stk2(i), stk) Then
                            stk.Add(stk2(i))
                        End If
                    End If
                Next
            End If

            If j > 0 Then
                If drawopt Then
                    If UBound(ari) <> -1 Then
                        tmplst.Add(ari(j - 1))
                        tmplst.Add(CStr(totar))
                        Bareaarr.Add(tmplst)
                    End If
                End If
            End If

            If drawopt Or drawarc Then

            End If
            qtyflg = True
            conn.Dispose()
            conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\container.mdb;Persist Security Info=False"
            conn.Open()

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in stuffx", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return stk

    End Function

    Public Function isx(ByVal ar1 As Area, ByVal ar2 As Area) As Boolean

        Try
            If ar2.StrtPt.y = ar1.StrtPt.y + ar1.width And ar1.StrtPt.x >= ar2.StrtPt.x AndAlso ar1.StrtPt.x + ar1.length = ar2.StrtPt.x + ar2.length AndAlso ar2.StrtPt.z = ar1.StrtPt.z AndAlso ar1.height = ar2.height Then
                Return True
            Else
                Return False
            End If
        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in isx", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function

    Public Function isx1(ByVal ar1 As Area, ByVal ar2 As Area) As Boolean

        Try
            If ar1.StrtPt.y = ar2.StrtPt.y + ar2.width And ar2.StrtPt.x <= ar1.StrtPt.x AndAlso ar1.StrtPt.x + ar1.length = ar2.StrtPt.x + ar2.length AndAlso ar2.StrtPt.z = ar1.StrtPt.z AndAlso ar1.height = ar2.height Then
                Return True
            Else
                Return False
            End If

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in isx1", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function

    Public Function mergex(ByVal ar1 As Area, ByVal ar2 As Area) As List(Of Area)

        Dim arret1 As New Area
        Dim arret2 As New Area
        Dim lstret As New List(Of Area)

        Try
            arret1.StrtPt.x = ar1.StrtPt.x
            arret1.StrtPt.y = ar1.StrtPt.y
            arret1.StrtPt.z = ar1.StrtPt.z
            arret1.length = ar1.length
            arret1.width = ar1.width + ar2.width
            arret1.height = ar1.height

            arret2.StrtPt.x = ar2.StrtPt.x
            arret2.StrtPt.y = ar2.StrtPt.y
            arret2.StrtPt.z = ar2.StrtPt.z
            arret2.length = ar2.length - ar1.length
            arret2.width = ar2.width
            arret2.height = ar2.height

            lstret.Add(arret1)
            lstret.Add(arret2)

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in mergex", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return lstret

    End Function

    Public Function mergey(ByVal lsti As List(Of Area)) As List(Of Area)

        Dim arp As New Area
        Dim lstret As New List(Of Area)

        Try
            arp.StrtPt.x = lsti(0).StrtPt.x
            arp.StrtPt.y = lsti(0).StrtPt.y
            arp.StrtPt.z = lsti(0).StrtPt.z
            arp.length = lsti(0).length
            arp.width = 0
            For i As Integer = 0 To lsti.Count - 1
                arp.width += lsti(i).width
            Next
            arp.height = lsti(0).height
            lstret.Add(arp)
            For i As Integer = 1 To lsti.Count - 1
                Dim ar As New Area
                ar.StrtPt.x = lsti(i).StrtPt.x
                ar.StrtPt.y = lsti(i).StrtPt.y
                ar.StrtPt.z = lsti(i).StrtPt.z
                ar.length = lsti(i).length - arp.length
                ar.width = lsti(i).width
                ar.height = lsti(i).height
                lstret.Add(ar)
                ar = Nothing
            Next
        Catch err As Exception
            MsgBox(err.Message)
            MsgBox(err.ToString)
            MessageBox.Show("Error in mergey", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return lstret

    End Function

    Public Function mergez(ByVal lsti As List(Of Area)) As List(Of Area)

        Dim arp As New Area
        Dim lstret As New List(Of Area)
        Try
            arp.StrtPt.x = lsti(lsti.Count - 1).StrtPt.x
            arp.StrtPt.y = lsti(0).StrtPt.y
            arp.StrtPt.z = lsti(0).StrtPt.z
            arp.length = lsti(lsti.Count - 1).length
            arp.width = 0
            For i As Integer = 0 To lsti.Count - 1
                arp.width += lsti(i).width
            Next
            arp.height = lsti(0).height
            lstret.Add(arp)
            For i As Integer = 0 To lsti.Count - 2
                Dim ar As New Area
                ar.StrtPt.x = lsti(i).StrtPt.x
                ar.StrtPt.y = lsti(i).StrtPt.y
                ar.StrtPt.z = lsti(i).StrtPt.z
                ar.length = lsti(i).length - arp.length
                ar.width = lsti(i).width
                ar.height = lsti(i).height
                lstret.Add(ar)
                ar = Nothing
            Next
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in mergez", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return lstret

    End Function

    Public Function gtst(ByVal lst As List(Of Area), ByVal ar As Area) As List(Of Integer)

        Dim lstret As New List(Of Integer)
        Dim lsttem As New List(Of Area)
        Dim rwx() As System.Data.DataRow
        Dim lst1 As New List(Of Integer)
        Dim lst2 As New List(Of List(Of Integer))
        Dim lstret1 As New List(Of Integer)

        Try
            For i As Integer = 0 To lst.Count - 1
                If lst(i).length >= ar.length AndAlso lst(i).width < ar.width AndAlso lst(i).height >= ar.height Then
                    lstret.Add(i)
                    lsttem.Add(lst(i))
                End If
            Next

            DelTab("temp2")
            For i As Integer = 0 To lsttem.Count - 1
                instab("temp2", New Object() {CStr(lsttem(i).StrtPt.x), CStr(lsttem(i).StrtPt.y), CStr(lsttem(i).StrtPt.z), CStr(lstret(i))})
            Next i
            rwx = getf("temp2", "", "y ASC")

            For i As Integer = 1 To UBound(rwx)
                lst1.Add(rwx(i)("i"))

            Next

            Dim ok As Boolean = False
            Dim arx As New Area
            Dim arx1 As New Area
            Dim arx2 As New Area
            Dim arx3 As New Area
            For i As Integer = 0 To lst1.Count - 1
                arx = lst(lst1(i))
                For j As Integer = 0 To lst.Count - 1
                    arx1 = lst(j)
                    If isx(arx, arx1) Then
                        If ar.width <= arx.width + arx1.width Then
                            lstret1.Add(i)
                            lstret1.Add(j)
                            Return lstret1
                        Else
                            For k As Integer = 0 To lst.Count - 1
                                arx2 = lst(k)
                                If isx(arx1, arx2) Then
                                    If ar.width <= arx.width + arx1.width + arx2.width Then
                                        lstret1.Add(i)
                                        lstret1.Add(j)
                                        lstret1.Add(k)
                                        Return lstret1
                                    Else
                                        For m As Integer = 0 To lst.Count - 1
                                            arx3 = lst(m)
                                            If isx(arx2, arx3) Then
                                                If ar.width <= arx.width + arx1.width + arx2.width + arx3.width Then
                                                    lstret1.Add(i)
                                                    lstret1.Add(j)
                                                    lstret1.Add(k)
                                                    lstret1.Add(m)
                                                    Return lstret1
                                                End If
                                            End If
                                        Next
                                    End If
                                End If
                            Next
                        End If
                    Else
                    End If
                Next
            Next

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in gtst", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return Nothing

    End Function

    Public Function gtst1(ByVal lst As List(Of Area), ByVal ar As Area) As List(Of Integer)

        Dim lstret As New List(Of Integer)
        Dim lsttem As New List(Of Area)
        Dim rwx() As System.Data.DataRow
        Dim lst1 As New List(Of Integer)
        Dim lst2 As New List(Of List(Of Integer))
        Dim lstret1 As New List(Of Integer)

        Try

            For i As Integer = 0 To lst.Count - 1
                If lst(i).length >= ar.length AndAlso lst(i).width < ar.width AndAlso lst(i).height >= ar.height Then
                    lstret.Add(i)
                    lsttem.Add(lst(i))
                End If

            Next

            DelTab("temp2")
            For i As Integer = 0 To lsttem.Count - 1
                instab("temp2", New Object() {CStr(lsttem(i).StrtPt.x), CStr(lsttem(i).StrtPt.y), CStr(lsttem(i).StrtPt.z), CStr(lstret(i))})
            Next i
            rwx = getf("temp2", "", "y ASC")

            For i As Integer = 1 To UBound(rwx)
                lst1.Add(rwx(i)("i"))

            Next

            Dim ok As Boolean = False
            Dim arx As New Area
            Dim arx1 As New Area
            Dim arx2 As New Area
            Dim arx3 As New Area
            For i As Integer = 0 To lst1.Count - 1
                arx = lst(lst1(i))
                For j As Integer = 0 To lst.Count - 1
                    arx1 = lst(j)
                    If isx1(arx1, arx) Then
                        If ar.width <= arx.width + arx1.width Then
                            lstret1.Add(lst1(i))
                            lstret1.Add(j)
                            Return lstret1
                        Else
                            For k As Integer = 0 To lst.Count - 1
                                arx2 = lst(k)
                                If isx1(arx2, arx1) Then
                                    If ar.width <= arx.width + arx1.width + arx2.width Then
                                        lstret1.Add(lst1(i))
                                        lstret1.Add(j)
                                        lstret1.Add(k)
                                        Return lstret1
                                    Else
                                        For m As Integer = 0 To lst.Count - 1
                                            arx3 = lst(m)
                                            If isx1(arx3, arx2) Then
                                                If ar.width <= arx.width + arx1.width + arx2.width + arx3.width Then
                                                    lstret1.Add(lst1(i))
                                                    lstret1.Add(j)
                                                    lstret1.Add(k)
                                                    lstret1.Add(m)
                                                    Return lstret1
                                                End If
                                            End If
                                        Next
                                    End If
                                End If
                            Next
                        End If
                    Else
                    End If
                Next
            Next

        Catch en As Exception
            MsgBox(en.Message)
            MsgBox(en.ToString)
            MessageBox.Show("Error in gtst1", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return Nothing

    End Function

    Public Sub FffWad()

        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim Cmdf As New OleDb.OleDbCommand
            Cmdf.Connection = conn
            Cmdf.CommandText = "delete from empty"
            Cmdf.ExecuteNonQuery()
            For i As Integer = 0 To stk.Count - 1
                Cmdf.CommandText = "insert into empty values (" & CStr(stk(i).StrtPt.x) & "," & CStr(stk(i).StrtPt.y) & "," & CStr(stk(i).StrtPt.z) & "," & CStr(stk(i).length) & "," & CStr(stk(i).width) & "," & CStr(stk(i).height) & ")"
                Cmdf.ExecuteNonQuery()
            Next

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in FffWad", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Sub fff()
        'Stop
        Try

            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim cmde As New OleDb.OleDbCommand
            cmde.Connection = conn
            cmde.CommandText = "delete from empty"
            cmde.ExecuteNonQuery()

            For i As Integer = 0 To stk.Count - 1
                cmde.CommandText = "insert into empty values (" & CStr(stk(i).StrtPt.x) & "," & CStr(stk(i).StrtPt.y) & "," & CStr(stk(i).StrtPt.z) & "," & CStr(stk(i).length) & "," & CStr(stk(i).width) & "," & CStr(stk(i).height) & ")"
                cmde.ExecuteNonQuery()
            Next

            'Stop

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in fff" & vbCrLf & "Data insert connection failure!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'MsgBox("Exception :: In Method 'fff'  " & vbCrLf & "Data insert connection failure!")
        Finally
            conn.Close()
        End Try

    End Sub

    Public Function ispresent(ByVal lst As List(Of Area), ByVal ar As Area) As Boolean

        Dim ar1 As New Area

        Try

            For i As Integer = 0 To lst.Count - 1
                ar1 = lst(i)
                If ar1.StrtPt.x = ar.StrtPt.x AndAlso ar1.StrtPt.y = ar.StrtPt.y AndAlso ar1.StrtPt.z = ar.StrtPt.z Then
                    Return True
                End If
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in ispresent", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return False

    End Function

    Public Function findmatchidx(ByVal arr1 As List(Of e1), ByVal arr2 As List(Of e1)) As Integer

        Try

            If arr1.Count = 0 Then
                Return -1
            End If
            If arr2.Count > arr1.Count Then
                Return arr1.Count
            End If
            For i As Integer = 0 To arr2.Count - 1
                If arr2(i).qty <> arr1(i).qty OrElse arr2(i).itmnm <> arr1(i).itmnm Then
                    Return i
                End If
            Next

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in findmatchidx", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return arr2.Count

    End Function

    Public Function stuffnew(ByVal ar As List(Of Area), ByVal topup As List(Of Boolean))

        Dim stknew As New Stack(Of occ1)
        Dim elem As New occ1
        Dim iii As Integer
        Dim arc1 As New Area
        Dim llst As New List(Of Area)

        Try
            arc1.StrtPt.x = arc.StrtPt.x
            arc1.StrtPt.y = arc.StrtPt.y
            arc1.StrtPt.z = arc.StrtPt.z

            arc1.StrtPt.x = arc.StrtPt.x
            arc1.StrtPt.y = arc.StrtPt.y
            arc1.StrtPt.z = arc.StrtPt.z

            arc1.length = arc.length
            arc1.width = arc.width
            arc1.height = arc.height
            FindOptMethod(ar(0), arc, iii, topup(0))
            elem.j = 0
            elem.j1 = OccLst
            elem.stk.Add(arc1)
            stknew.Push(elem)
            Dim occ2 As occ1
            Dim j As Integer
            Dim optlst As List(Of Integer)
            Dim stkx As List(Of Area) = Nothing
            Dim arm1 As Integer
            Dim art As Area
            Do While stknew.Count > 0
                occ2 = stknew.Pop
                j = occ2.j
                optlst = occ2.j1
                Dim stk As New List(Of Area)
                stk = occ2.stk
                arm1 = findopt(stkx, ar(j), topup(j))

                art = Nothing
                If arm1 <> -1 Then
                    art = stkx(arm1)
                End If
                Dim q As New Queue(Of Area)
                Dim arn As New List(Of Integer)
                Dim arm As New List(Of Integer)
                Dim lstn As New List(Of Area)
                Dim b1 As New Area
                Dim b2 As New Area
                Dim a1 As New Area
                Dim a2 As New Area
                Dim pos1 As Integer
                Dim lstm As New List(Of Area)
                arm = Nothing
                arn = Nothing

                arn = findcandidate1(stk, ar(j), topup(j))
                pos1 = 0
                If Not arn Is Nothing Then
                    pos1 = 0
                Else
                    Dim arxx As New Area
                    arxx.length = ar(j).width
                    arxx.width = ar(j).length
                    arxx.height = ar(j).height
                    arn = findcandidate1(stk, arxx, topup(j))
                    If Not arn Is Nothing Then
                        pos1 = 1
                    Else
                        If Not topup(j) Then
                            arxx.length = ar(j).length
                            arxx.width = ar(j).height
                            arxx.height = ar(j).width
                            arn = findcandidate1(stk, arxx, False)
                            If Not arn Is Nothing Then
                                pos1 = 2
                            End If
                        End If
                    End If
                End If
                If arn Is Nothing Then
                    arm = findcandidate(stk, ar(j))
                    If Not arm Is Nothing Then
                        If arm(0) = arm1 Then arm = Nothing
                    End If
                End If
                If Not arm Is Nothing Then
                    lstm = unionp(stk(arm(0)), stk(arm(1)))
                    a1 = lstm(0)
                    a2 = lstm(1)
                End If

                If Not arn Is Nothing Then

                    lstm = unionp(stk(arn(0)), stk(arn(1)))
                    b1 = lstm(0)
                    b2 = lstm(1)
                End If

                Dim ordr As Integer = 0
                Dim cmd As New OleDb.OleDbCommand

                If Not arm Is Nothing Or Not arn Is Nothing Then
                    DelTab("temp2")

                    ordr = 0
                    If Not arm Is Nothing Then

                        instab("temp2", New Object() {CStr(a1.StrtPt.x), CStr(a1.StrtPt.y), CStr(a1.StrtPt.z), CStr(1)})

                    End If

                    If Not arn Is Nothing Then
                        instab("temp2", New Object() {CStr(b1.StrtPt.x), CStr(b1.StrtPt.y), CStr(b1.StrtPt.z), CStr(2)})
                    End If

                    If Not art Is Nothing Then
                        instab("temp2", New Object() {CStr(art.StrtPt.x), CStr(art.StrtPt.y), CStr(art.StrtPt.z), CStr(3)})
                    End If

                    Dim rwx As DataRow() = Nothing
                    If Not arm Is Nothing Then

                        rwx = getf("temp2", "", "z DESC ,x ASC,y ASC")
                    End If

                    If Not arn Is Nothing Then

                        rwx = getf("temp2", "", "z DESC ,x ASC,y ASC")
                    End If

                    If arn Is Nothing And arm Is Nothing Then

                        rwx = getf("temp2", "", "z DESC ,x ASC")
                    End If

                    If arm Is Nothing And arn Is Nothing Then

                        rwx = getf("temp2", "", "z DESC ,x ASC,y ASC")
                    End If

                    ordr = rwx(0)("i")

                    If ordr = 3 Then
                        stk.RemoveAt(arm1)
                    Else
                        If ordr = 1 Then
                            art = a1
                            stk.RemoveAt(arm(0))
                            If arm(0) < arm(1) Then
                                stk.RemoveAt(arm(1) - 1)
                            Else
                                stk.RemoveAt(arm(1))
                            End If

                            stk.Add(a2)

                        End If
                        If ordr = 2 Then
                            If pos1 = 1 Then
                                Dim tmp As Double = ar(j).width
                                ar(j).width = ar(j).length
                                ar(j).length = tmp
                            End If

                            If pos1 = 2 Then
                                Dim tmp As Double = ar(j).height
                                ar(j).height = ar(j).width
                                ar(j).width = tmp
                            End If


                            art = b1
                            stk.RemoveAt(arn(0))
                            If arn(0) < arn(1) Then
                                stk.RemoveAt(arn(1) - 1)
                            Else
                                stk.RemoveAt(arn(1))
                            End If

                            stk.Add(b2)

                        End If
                        If ordr = 3 Then
                            stk.RemoveAt(arm1)
                        End If
                    End If
                Else
                    If arm1 <> -1 Then
                        stk.RemoveAt(arm1)
                    End If
                End If
                Dim qty As Integer

                FindOptMethod(ar(j), art, qty, topup(j))

                arm = Nothing
                arn = Nothing
                ar(j).StrtPt.x = art.StrtPt.x
                ar(j).StrtPt.y = art.StrtPt.y
                ar(j).StrtPt.z = art.StrtPt.z

                Dim occlst1 As New List(Of Integer)
                For i As Integer = 0 To OccLst.Count - 1
                    occlst1.Add(OccLst(i))
                Next

                q = art.subtract(ar(j))

                Dim arb As Area
                Dim dd As New Area
                If Not q Is Nothing Then
                    If stk.Count = 0 Then
                        Do While Not q.Count = 0

                            dd = q.Dequeue
                            If Not chk1(dd, stk) Then
                                If Not chk11(dd, stk) Then
                                    stk.Add(dd)
                                End If
                            End If
                        Loop
                    Else
                        Do While q.Count > 0
                            arb = q.Dequeue

                            If Not chk1(arb, stk) Then
                                If Not chk11(arb, stk) Then
                                    stk = UnPush(stk, arb)
                                End If
                            End If

                        Loop

                    End If

                End If

                Dim mmm1 As New a1
                mmm1.j = j
                mmm1.stk = stk
                stkl.Push(mmm1)
            Loop

        Catch Ers As Exception
            MsgBox(Ers.Message)
            MsgBox(Ers.ToString)
            MessageBox.Show("Error in stuffnew", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return Nothing

    End Function

    Public Function stuffnew1(ByVal ar As List(Of Area), ByVal topup As List(Of Boolean))

        Dim j As Integer
        Dim stk As New List(Of Area)
        Dim stka As New List(Of Area)
        Dim ai As a1
        Dim ai1 As a1

        Try
            Do While stkl.Count > 0
                Dim arr As New Area
                Dim arr1 As New Area
                Dim i1 As Integer
                Dim tp As Boolean
                Dim uu As Integer
                Dim q As New Queue(Of Area)
                ai = stkl.Pop
                If ai.j = -1 Then
                    j = ai.j + 1
                Else
                    j = ai.j
                End If
                If j = ar.Count Then
                    GoTo lp
                End If

                stk = ai.stk
                stka.Clear()

                For i As Integer = 0 To stk.Count - 1

                    stka.Add(stk(i))
                Next
                arr = ar(j)
                tp = topup(j)
                i1 = findopt(stka, arr, tp)
                arr1 = stka(i1)
                stka.RemoveAt(i1)
                FindOptMethod(arr, arr1, uu, tp)
                Dim ii As Integer

                Dim ln As Double = ar(j).length
                Dim wd As Double = ar(j).width
                Dim ht As Double = ar(j).height

                Dim stkb As New List(Of Area)

                For jj As Integer = 0 To stka.Count - 1
                    stkb.Add(stka(jj))
                Next

                For i As Integer = 0 To OccLst.Count - 1
                    ii = OccLst(i)
                    Dim arp As New Area

                    arp.StrtPt.x = ar(j).StrtPt.x
                    arp.StrtPt.y = ar(j).StrtPt.y
                    arp.StrtPt.z = ar(j).StrtPt.z
                    arp.length = ar(j).length
                    arp.width = ar(j).width
                    arp.height = ar(j).height

                    If ii = 1 Then

                    End If

                    If ii = 2 Then
                        arp.length = ln
                        arp.width = ht
                        arp.height = wd
                    End If

                    If ii = 3 Then
                        arp.length = wd
                        arp.width = ht
                        arp.height = ln
                    End If

                    If ii = 4 Then
                        arp.length = wd
                        arp.width = ln
                        arp.height = ht
                    End If

                    If ii = 5 Then
                        arp.length = ht
                        arp.width = wd
                        arp.height = ln
                    End If

                    If ii = 6 Then
                        arp.length = ht
                        arp.width = ln
                        arp.height = wd
                    End If

                    arp.StrtPt.x = arr1.StrtPt.x
                    arp.StrtPt.y = arr1.StrtPt.y
                    arp.StrtPt.z = arr1.StrtPt.z

                    q = arr1.subtract(arp)

                    Dim dd As New Area
                    Dim flg As Boolean = False
                    If q.Count > 0 Then flg = True

                    stka.Clear()

                    For jj As Integer = 0 To stkb.Count - 1
                        stka.Add(stkb(jj))
                    Next
                    Do While Not q.Count = 0
                        dd = q.Dequeue
                        stka.Add(dd)

                    Loop

                    ai1.j = j + 1
                    ai1.stk = stka
                    If ai1.j < ar.Count Then
                        stkl.Push(ai1)
                    End If

                Next

                stuffnew1(ar, topup)
lp:
            Loop

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in stuffnew1", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        Return Nothing

    End Function

    Public Function MrgXWad(ByVal Lst As List(Of Area), ByVal Ar As Area, ByVal Chngd As Boolean) As List(Of Area)

        Dim Ar1 As New Area
        Dim Ar2 As New Area
        Dim Arx As New Area
        Dim LstRet As New List(Of Area)
        Dim j As Integer = 0
        Dim k As Integer = 0
        Dim Lst1 As New List(Of Integer)

        Try

            For i As Integer = 0 To Lst.Count - 1
                Ar1 = Lst(i)

                If Ar1.StrtPt.x = Ar.StrtPt.x + Ar.length AndAlso Ar1.width = Ar.width AndAlso Ar.height = Ar1.height AndAlso Ar1.StrtPt.y = Ar.StrtPt.z = Ar.StrtPt.z Then
                    j = i
                End If

                If Ar1.StrtPt.x = Ar.StrtPt.x AndAlso Ar1.StrtPt.y = Ar.StrtPt.y AndAlso Ar1.StrtPt.z = Ar.StrtPt.z Then
                    k = i
                End If

            Next

            If j <> 0 AndAlso k <> 0 Then
                Ar1 = Lst(j)
                Ar2 = Lst(k)
                Arx.StrtPt.x = Ar1.StrtPt.x
                Arx.StrtPt.y = Ar1.StrtPt.y
                Arx.StrtPt.z = Ar1.StrtPt.z
                Arx.length = Ar1.length
                Arx.width = Ar1.width
                Arx.height = Ar1.height

                For i As Integer = 0 To Lst.Count - 1
                    If i <> j AndAlso i <> k Then
                        LstRet.Add(Lst(i))
                    End If
                Next
                LstRet.Add(Arx)

            End If

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in MrgXWad", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Nothing
    End Function

    Public Function MrgX(ByVal lst As List(Of Area), ByVal ar As Area, ByRef chngd As Boolean) As List(Of Area)

        Dim ar1 As New Area
        Dim ar2 As New Area
        Dim arx As New Area
        Dim lstret As New List(Of Area)
        Dim j As Integer = 0
        Dim k As Integer = 0
        Dim lst1 As New List(Of Integer)

        Try
            For i As Integer = 0 To lst.Count - 1
                ar1 = lst(i)

                If ar1.StrtPt.x = ar.StrtPt.x + ar.length AndAlso ar1.width = ar.width AndAlso ar.height = ar1.height AndAlso ar1.StrtPt.y = ar.StrtPt.y AndAlso ar1.StrtPt.z = ar.StrtPt.z Then
                    j = i
                End If

                If ar1.StrtPt.x = ar.StrtPt.x AndAlso ar1.StrtPt.y = ar.StrtPt.y AndAlso ar1.StrtPt.z = ar.StrtPt.z AndAlso ar1.length = ar.length AndAlso ar1.width = ar.width AndAlso ar1.height = ar.height Then
                    k = i
                End If

            Next


            If j <> 0 AndAlso k <> 0 Then 'If j <> 0 Or k <> 0 Then           
                'Stop
                ar1 = lst(j)
                ar2 = lst(k)
                arx.StrtPt.x = ar2.StrtPt.x
                arx.StrtPt.y = ar2.StrtPt.y
                arx.StrtPt.z = ar2.StrtPt.z
                arx.length = ar1.length + ar2.length
                arx.width = ar1.width
                arx.height = ar1.height

                For i As Integer = 0 To lst.Count - 1
                    If i <> j AndAlso i <> k Then
                        lstret.Add(lst(i))
                    End If
                Next
                lstret.Add(arx)
                chngd = True
                Return lstret
            Else
                chngd = False
                Return lst
            End If

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in MrgX", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try

    End Function

    Public Function Stuffy(ByVal arc As Area, ByVal ar As Area, ByVal drwarc As Boolean, ByVal drawopt As Boolean, ByVal qty2 As Integer, ByVal itmnm As String) As Integer

        'Stop
        Dim qty As Integer
        Dim lst As New List(Of Area)
        Dim ar1 As New Area
        Dim ard As New Area
        Dim ard1 As New Area

        Dim TotQtys As Int64 = 0


        Try
            ar1.StrtPt.x = ar.StrtPt.x
            ar1.StrtPt.y = ar.StrtPt.y
            ar1.StrtPt.z = ar.StrtPt.z
            ar1.length = ar.length
            ar1.width = ar.width
            ar1.height = ar.height

            'If drwarc Then
            '    ard.StrtPt.x = arc.length
            '    ard.StrtPt.y = 0
            '    ard.StrtPt.z = 0
            '    ard.length = 0.5
            '    ard.width = arc.width
            '    ard.height = arc.height

            '    ard.AutoDraw("c:\addd.wrl", "", 0, "file:///c:\contdoor.png", "", 0, True, False, "door", 0, False, "b")
            '    ard1.StrtPt.x = arc.length - 0.01
            '    ard1.StrtPt.y = 0
            '    ard1.StrtPt.z = 0
            '    ard1.length = 0.5
            '    ard1.width = ard.width
            '    ard1.height = ard.height
            '    ard1.AutoDraw("c:\ardd.wrl", "b", 0, "file:///c:\contdoor.png", "", 0, True, False, "door1", 0, False, "b")

            '    arc.AutoDraw("c:\addd.wrl", "r", 0.5, "", "", 1, False, False, "", 1, False, "b")
            'End If

            '==========================================================================================================================================


            'Dim ii As Integer = FindOptMethod(ar1, arc, qty, False)


            Dim Fom As New OptMthd.OptMthd.FndOptMthd

            Dim cAr1 As New OptMthd.OptMthd.FndOptMthd.Areas

            Dim cArc As New OptMthd.OptMthd.FndOptMthd.Areas

            cAr1.length = ar1.length
            cAr1.width = ar1.width
            cAr1.height = ar1.height
            cAr1.StrtPt.x = ar1.StrtPt.x
            cAr1.StrtPt.y = ar1.StrtPt.y
            cAr1.StrtPt.z = ar1.StrtPt.z

            cArc.length = arc.length
            cArc.width = arc.width
            cArc.height = arc.height
            cArc.StrtPt.x = arc.StrtPt.x
            cArc.StrtPt.y = arc.StrtPt.y
            cArc.StrtPt.z = arc.StrtPt.z

            Dim ii As Integer = Fom.FindOptMethod(cAr1, cArc, qty, False)

            If qty > 0 Then
                Dim ln As Double = ar1.length
                Dim wd As Double = ar1.width
                Dim ht As Double = ar1.height

                If ii = 1 Then
                    ar1.length = ln
                    ar1.width = wd
                    ar1.height = ht

                End If

                If ii = 2 Then
                    ar1.length = ln
                    ar1.width = ht
                    ar1.height = wd

                End If

                If ii = 3 Then
                    ar1.length = wd
                    ar1.width = ht
                    ar1.height = ln

                End If

                If ii = 4 Then
                    ar1.length = wd
                    ar1.width = ln
                    ar1.height = ht

                End If

                If ii = 5 Then
                    ar1.length = ht
                    ar1.width = wd
                    ar1.height = ln

                End If

                If ii = 6 Then
                    ar1.length = ht
                    ar1.width = ln
                    ar1.height = wd

                End If

                Dim mm As New List(Of Area)
                Dim qty1 As Integer

                mm = drwopt(arc, ar1, "", "", 1, itmnm, 1, False, False, qty2, drawopt, qty)
                TotQtys = TotQtys + qty
                Dim art As New Area
                Dim qtyx As Integer = qty2 - TotQtys
                If Not mm Is Nothing Then
                    For i As Integer = 0 To mm.Count - 1
                        art.StrtPt.x = mm(i).StrtPt.x
                        art.StrtPt.y = mm(i).StrtPt.y
                        art.StrtPt.z = mm(i).StrtPt.z
                        art.length = mm(i).length
                        art.width = mm(i).width
                        art.height = mm(i).height
                        ar1.StrtPt.x = art.StrtPt.x
                        ar1.StrtPt.y = art.StrtPt.y
                        ar1.StrtPt.z = art.StrtPt.z
                        If qtyx > 0 Then
                            qty1 = Stuffy(art, ar1, False, True, qtyx, itmnm)
                        End If

                    Next
                    mm.Clear()
                End If
            End If

        Catch Ers As Exception
            MsgBox(Ers.Message)
            MsgBox(Ers.ToString)
            MessageBox.Show("Error in Stuffy", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return TotQtys

    End Function

#End Region

#Region " Routine Definitions "

    Public Sub placecyl(ByVal cont As Area, ByVal rad As Single, ByVal ht As Single, ByVal qty As Integer)

        Dim w As Single = cont.width
        Dim dia As Single = rad * 2
        Dim rwqty As Integer = w \ dia
        Dim odstx As Single = cont.width Mod dia
        Dim odsty As Single = ((dia ^ 2) - (odstx ^ 2)) ^ 0.5
        Dim colqty As Integer = qty \ rwqty
        Dim x As Single = 0
        Dim y As Single = 0

        Try
            For i As Integer = 0 To colqty - 1
                For j As Integer = 0 To rwqty - 1
                    Dim cyl1 As New cylinder
                    cyl1.cntr.x = 0
                    cyl1.cntr.y = y
                    cyl1.cntr.z = x
                    cyl1.radius = rad
                    cyl1.height = ht
                    x = x + dia
                    cyl1.AutoDraw("c:\gg.wrl", "r", "", 0)
                Next
                x = 0
                y = y + odsty
            Next
        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in placecyl", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    ' Progress bar is to shown the progress of the operation of stuffing the goods in to the container.
    ' The one progress bar is completed the approximately 50 quantities is placed in to the container.

    Public Sub ProgressBarRunning()

        Try
            'TransactionMenu.Focus()
            TransactionMenu.pbCSP1.Value = TransactionMenu.pbCSP1.Value + 2
            If TransactionMenu.pbCSP1.Value = 100 Then
                TransactionMenu.pbCSP1.Value = 0
                TransactionMenu.Focus()
                TransactionMenu.Refresh()
            End If

            'PBColorchng()
            Eventful()

        Catch Ep As Exception
            MsgBox(Ep.Message)
            MsgBox(Ep.ToString)
            MessageBox.Show("Error in ProgressBarRunning", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub PBColorchng()

        PBCl = (Rnd() * 20) + (Rnd() * 40) + (Rnd() * 30)
        TransactionMenu.pbCSP1.ForeColor = Color.FromArgb(PBCl)

    End Sub

    Public Sub Eventful()

        Try
            TransactionMenu.dgv1.Enabled = False
            TransactionMenu.cmdAdd.Enabled = False
            TransactionMenu.cmdEdit.Enabled = False
            TransactionMenu.cmdDel.Enabled = False
            TransactionMenu.cmdFirst.Enabled = False
            TransactionMenu.cmdPrev.Enabled = False
            TransactionMenu.cmdNext.Enabled = False
            TransactionMenu.cmdLast.Enabled = False
            TransactionMenu.cmdFind.Enabled = False
            'TransactionMenu.btnSettings.Enabled = False
            'TransactionMenu.btnBoxType.Enabled = False
            'TransactionMenu.btnDrumtype.Enabled = False
            'TransactionMenu.btnBoxDrumType.Enabled = False
            'TransactionMenu.btnOthertype.Enabled = False
            TransactionMenu.cmdUpdate.Enabled = False
            TransactionMenu.cmdRef.Enabled = False
            TransactionMenu.Button1.Enabled = False
            TransactionMenu.Button2.Enabled = False

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in Eventful", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub Eventless()

        Try

            TransactionMenu.dgv1.Enabled = True
            TransactionMenu.cmdAdd.Enabled = True
            TransactionMenu.cmdEdit.Enabled = True
            TransactionMenu.cmdDel.Enabled = True
            TransactionMenu.cmdFirst.Enabled = True
            TransactionMenu.cmdPrev.Enabled = True
            TransactionMenu.cmdNext.Enabled = True
            TransactionMenu.cmdLast.Enabled = True
            TransactionMenu.cmdFind.Enabled = True
            'TransactionMenu.btnSettings.Enabled = True
            'TransactionMenu.btnDrumtype.Enabled = True
            'TransactionMenu.btnBoxDrumType.Enabled = True
            'TransactionMenu.btnOthertype.Enabled = True
            TransactionMenu.cmdUpdate.Enabled = True
            TransactionMenu.cmdRef.Enabled = True
            TransactionMenu.Button1.Enabled = True
            TransactionMenu.Button2.Enabled = True
            'TransactionMenu.btnBoxType.Enabled = True

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in Eventless", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub FinalOutPutWriter()

        Try

            Dim DT As DateTime = DateTime.Now
            Dim DtTm As String = DT.ToString("dd/MM/yyyy :hh:mm:ss tt")
            Dim dtmFile As String = DT.ToString("ddMMyyhms")
            Dim Wifile As String = CurDir() & "\Box.wrl"
            Dim Wofile As String = CurDir() & "\Stuff Viewers files\StuffOPTBox\" & dtmFile & ".wrl"
            Dim F As Int16 = 1

            EDWr.De = F
            EDWr.Ifile = Wifile
            EDWr.Ofile = Wofile
            EDWr.DEKey = "C$P"

            F = EDWr.DEncript()

            IFOPWr(dtmFile)

            BoxFileOP = "CSP.Box"

            Wifile = CurDir() & "\Box.wrl"
            Wofile = "C:\" & BoxFileOP & ".wrl"
            F = 5
            EDWr.De = F

            EDWr.De = F
            EDWr.Ifile = Wifile
            EDWr.Ofile = Wofile

            F = EDWr.WrProgCSP()

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in FinalOutPutWriter", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub

    Public Sub IFOPWr(ByVal CSPID As String)

        Try

            If connT.State = ConnectionState.Closed Then connT.Open()
            Dim Cmds As New OleDb.OleDbCommand

            Cmds.Connection = connT
            Cmds.CommandText = "insert into OPFileBox values(" & CStr(CSPID) & ")"
            Cmds.ExecuteNonQuery()

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in IFOPWr", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'MsgBox("Exception :: In Method 'IFOPWr'  " & vbCrLf & "Data insert connection failure!")
            connT.Close()
        Finally
            connT.Close()
        End Try

    End Sub

    Public Sub DelTabWad(ByVal TbNm As String)

        Dim SddTb As New System.Data.DataTable

        Try
            Dim SxDd As New System.Xml.XmlDataDocument
            SxDd.DataSet.ReadXml(CurDir() & "/" & TbNm & ".xml")
            SddTb = SxDd.DataSet.Tables(0)

            Do While SddTb.Rows.Count > 1
                SddTb.Rows(SddTb.Rows.Count - 1).BeginEdit()
                SddTb.Rows(SddTb.Rows.Count - 1).Delete()
                SddTb.AcceptChanges()
            Loop

            SxDd.Save(CurDir() & "/" & TbNm & ".xml")

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in DelTabWad ", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub DelTab(ByVal tbname As String)

        Dim mm As New System.Data.DataTable

        Try
            Dim asdf As New System.Xml.XmlDataDocument
            asdf.DataSet.ReadXml(CurDir() & "/" & tbname & ".xml")
            mm = asdf.DataSet.Tables(0)

            Do While mm.Rows.Count > 1
                mm.Rows(mm.Rows.Count - 1).BeginEdit()
                mm.Rows(mm.Rows.Count - 1).Delete()
                mm.AcceptChanges()
            Loop

            asdf.Save(CurDir() & "/" & tbname & ".xml")

        Catch Ex As Exception

            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in DelTab", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Public Sub TabXmlDel(ByVal TbNm As String)

        Dim Sdd As System.Data.DataTable

        Try
            Dim Sxx As New System.Xml.XmlDataDocument
            Sxx.DataSet.ReadXml(CurDir() & "/" & TbNm & ".xml")
            Sdd = Sxx.DataSet.Tables(0)

            Do While Sdd.Rows.Count > 1

                Sdd.Rows(Sdd.Rows.Count - 1).BeginEdit()
                Sdd.Rows(Sdd.Rows.Count - 1).Delete()
                Sdd.AcceptChanges()
            Loop

            Sxx.Save(CurDir() & "/" & TbNm & ".xml")

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in TabXmlDel", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub InstabWad(ByVal TbNm As String, ByVal Vals() As Object)

        Dim pp As New System.Data.DataTable
        Dim Sadf As New System.Xml.XmlDataDocument

        Try

            Sadf.DataSet.ReadXml(CurDir() & "/" & TbNm & ".xml")
            pp = Sadf.DataSet.Tables(0)
            pp.Rows.Add(Vals)
            Sadf.Save(CurDir() & "/" & TbNm & ".xml")

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in InstabWad", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub instab(ByVal tbname As String, ByVal vals() As Object)

        Dim mm As New System.Data.DataTable

        Dim asdf As New System.Xml.XmlDataDocument

        Try

            asdf.DataSet.ReadXml(CurDir() & "/" & tbname & ".xml")
            mm = asdf.DataSet.Tables(0)
            mm.Rows.Add(vals)
            asdf.Save(CurDir() & "/" & tbname & ".xml")

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in instab", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub stuffnewcont()

        arc.StrtPt.x = 0
        arc.StrtPt.y = 0
        arc.StrtPt.z = 0
        arc.length = 1
        arc.width = 2
        arc.height = 2
        Dim lst As New List(Of Area)
        Dim tpup As New List(Of Boolean)

        Try
            For i As Integer = 0 To 3
                Dim a1 As New Area
                Dim tp As Boolean = False
                a1.length = 1
                a1.width = 1
                a1.height = 1
                lst.Add(a1)

                tpup.Add(tp)
            Next

            Dim mmmm As New a1
            mmmm.j = -1
            Dim uuu As New List(Of Area)
            uuu.Add(arc)
            mmmm.stk = uuu
            stkl.Push(mmmm)
            stuffnew1(lst, tpup)
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in ", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub stuffpar()

        Dim arc1 As New Area

        Try
            arc1.StrtPt.x = arc.StrtPt.x
            arc1.StrtPt.y = arc.StrtPt.y
            arc1.StrtPt.z = arc.StrtPt.z
            arc1.length = arc.length
            arc1.width = arc.width
            arc1.height = arc.height
            Dim lst As New List(Of Area)
            Dim arr1 As New Stack(Of List(Of Area))

            lst.Add(arc1)
            arr1.Push(lst)
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in stuffpar", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

#End Region

#Region " Structure Definition "

    Public Structure a1

        Public j As Integer
        Public stk As List(Of Area)

    End Structure

    Public Structure occ1

        Public j As Integer
        Public j1 As List(Of Integer)
        Public stk As List(Of Area)

    End Structure

#End Region

    Public Function ValidNumber(ByVal ckey As Char, ByVal ocontrol As TextBox) As Bool
        Dim k As Integer = Asc(ckey)
        If Not (Char.IsNumber(ckey) Or ckey = "." Or k = Keys.Enter Or k = Keys.Back Or k = Keys.Space Or ckey = "-") Then
            Return True
        Else
            Dim strtext As String = ocontrol.Text
            If occurs(strtext, ".") > 1 Then
                MsgBox("You can only have only one decimal point", , "Invalid Numbers")
                Return True
            End If
            If occurs(strtext, "-") > 1 Then
                MsgBox("You can only have only one minus sign", , "Invalid Numbers")
                Return True
            End If
            If occurs(strtext, "-") = 1 Then
                If strtext.StartsWith("-") Then
                Else
                    MsgBox("Minus sign should be in the start of numbers", , "Invalid Numbers")
                    Return True
                End If
            End If
        End If
    End Function

    Public Function occurs(ByVal StrText As String, ByVal cText As Char) As Short

        Return StrText.Length - StrText.Replace(cText, "").Length

    End Function

End Module