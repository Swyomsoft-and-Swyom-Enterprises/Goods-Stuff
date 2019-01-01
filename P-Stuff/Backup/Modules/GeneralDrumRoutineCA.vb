
'Program Name: -    GeneralDrumRoutineCA.vb
'Programmer Name: - Satwadhir B. Pawar Mob No. :- 9323974665
'Company Name:-     Hazel Infotech LTD. Mumbai
'Project Name: -    Sky Stuff Plus (Container Stuffing)
'Date: -            24 Dec 2K8 11.30 AM (Modified Time)

'Tips: - The code is debugging at that particular dimensions, quantity and sequence.
'        you are decide it the logic happen is correct to that way or its are some 
'        different way the understanding to at your best level is the correct logic 
'        of this particular code block.

'Description: - GeneralDrumRoutineCA is the module which includes general drum routines
'               loop coding to generate drum cross arrangements i.e. the drums are placed 
'               tangent to each other so that the space required in container is minimum
'               as possible. This module contains various routines and functions to 
'               generate the VRML 3D isometric geometry program to display users.

#Region "Imporiing Object"

Imports DCAOlDb = System.Data.OleDb

#End Region

Module GeneralDrumRoutineCA           'General Drum Row Column Arrangement

#Region "Module Decleration"

    Public CDQCAer As New Queue(Of CDArea)            'upto cross arrangement of every row record stored
    Public CDPt As New CDrum                          'Cross drum points are added

    Public DCA As New CDrum                             'Drum cross arrangement 

    Public ConDrm As DCAOlDb.OleDbConnection = New DCAOlDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & CurDir() & "\Drums.mdb;Persist Security Info=False")       'Cross Drum Arrangement database conncetion pool

    Public SgnCA As Boolean = False             'First Cross Row Column Placed
    Public SgnSA As Boolean = False             'First Simple Row Column Placed
    Public FlgCA As Boolean = False             'Cross arrangement flag 
    Public flgXAxis As Boolean = False          'Xaxis Flag for X Axis is Over then stop program writting in VRML

    Public Drmi As New CDrum                        'Drum Length width height initilize
    'Friend ARcaDrm As New CDrum                     'Drum Value Transfered to that for CDrum Class

    Public flgCAqt As Boolean = False           'Drum cross arrangement flag
    Public flgNxtArg As Boolean = False         'Drum cross next argmt flag
    Public Rg As Integer = 0           'Row of datagrid used for quantity checking

    Public XAxis As Double
    Public XAxisRd As Double
    Public FrCaY As Double               'The Formulate equation of Value of Y Direction Height
    Public FrCaYca As Double            'The Last Value of Y in Cross Arangement
    Public P As Integer

    Public XL As Double
    Public YL As Double
    Public ZL As Double

    Dim ArdCA As New CDArea
    Friend DstrtclrCA As String

    Dim DCntCA As New CDMidPoint

    Dim Cmd As New OleDb.OleDbCommand

    Dim AnsW As MsgBoxResult

    Dim DOcc As Integer
    'Public ItrQty As Integer = 0
    Friend DItemNoCA As UInt64
    Friend DItemQtyCA As Integer
    Friend DTotWtCA As Single

    Friend DOccLstCA As New List(Of Integer)
    Friend DQtyLstCA As New List(Of Integer)
    Friend DPlcLstCA As New List(Of Integer)
    Friend DPlcLstfCA As New List(Of Integer)
    Friend DMaxQtyLstCA As New List(Of Integer)

    Friend DOptLstCA As New List(Of StructOcc1)

    Friend DAreaArrCA As New List(Of List(Of String))

    Dim DQCA As New Queue(Of CDArea)
    Dim DQ1CA As New Queue(Of CDArea)
    Dim DQ2CA As New Queue(Of CDArea)

#End Region

#Region "Function Difinition"

    Public Function DCrossStuffArngmt(ByVal DcaArc As CDArea, ByVal DcaAr() As CDArea, ByVal DcaAri() As String, ByVal ArWt() As Single, ByVal SaveOpt As Boolean, ByVal ShowEmpty As Boolean, ByVal OutFile As String, ByVal DrawArc As Boolean, ByVal TranspArr() As Boolean, ByVal TopUp() As Boolean, ByVal TxtOpt As Boolean, ByVal DrawOpt As Boolean, ByVal FindQtyFlg As Boolean, ByVal ChngFlg As Boolean, ByVal ColArr As List(Of List(Of Byte))) As List(Of CDArea)

        Stop

        Dim CDLst2CA As New List(Of CDArea)
        Dim CDStkCA As New Stack(Of CDArea)
        Dim ArmCA As New List(Of Integer)
        Dim LstmCA As New List(Of CDArea)
        Dim TmpLstCA As New List(Of String)
        Dim CDLstjCA As New List(Of CDArea)

        Dim A1CA As New CDArea
        Dim A2CA As New CDArea

        Dim ArtCA As New CDArea
        Dim ArpCA As New CDArea
        Dim AreCA As New CDArea
        Dim AruCA As New CDArea
        Dim ArbCA As New CDArea

        Dim Arm1CA As Integer
        Dim IICA As Integer
        Dim TravalCA As Single

        Dim SzChgCA As Integer = 0

        Dim QtyFlgCA As Boolean = True
        Dim Ans1CA As Boolean

        Dim OrdrCA As Integer
        Dim ColCA As String
        Dim TotArCA As Double
        Dim OldItemQtyCA As Integer = 0

        'DDStop

        Try

            If SaveOpt Then
                configid = InputBox("Enter Config Id")
            End If

            Dim Ptx As New CDPoint

            Ptx.x = DcaArc.DLengths
            Ptx.y = DcaArc.DWidth
            Ptx.z = DcaArc.DHeight

            Stop


            Dim Col1 As New List(Of Byte)
            Col1.Clear()
            Col1.Add(255)
            Col1.Add(255)
            Col1.Add(255)

            ColCA = "r"
            Dim ItmNm As String = ""

            If DrawArc Then
                Dim Ard1CA As New CDArea

                If DrawArc Then
                End If

                ArdCA.DStrtPt.x = DcaArc.DLengths
                ArdCA.DStrtPt.y = 0
                ArdCA.DStrtPt.z = 0
                ArdCA.DLengths = 0.5
                ArdCA.DWidth = DcaArc.DWidth
                ArdCA.DHeight = DcaArc.DHeight

                If DrawOpt Or DrawArc Then

                End If

                Ard1CA.DStrtPt.x = DcaArc.DLengths - 0.01
                Ard1CA.DStrtPt.y = 0
                Ard1CA.DStrtPt.z = 0
                Ard1CA.DLengths = 0.5
                Ard1CA.DWidth = ArdCA.DWidth
                Ard1CA.DHeight = ArdCA.DHeight
            End If

            If DrawOpt Or DrawArc Then
                Col1.Clear()
            End If

            If SaveOpt Then
                Cmd.Connection = connDrums
Repeat:

                Try
                    Cmd.ExecuteNonQuery()

                Catch Ex As Exception
                    If Ex.Message = "Cannot open any more tables." Then
                        connDrums.Close()
                        connDrums.Dispose()
                        OleDb.OleDbConnection.ReleaseObjectPool()
                        Cmd.Dispose()
                        GC.Collect()

                        connDrums.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\Drums.mdb;Persist Security Info=False"

                        connDrums.Open()
                        GoTo Repeat
                    End If
                End Try
                id1 += 1

            End If

            DcaArc.DStrtPt.x = 0
            DcaArc.DStrtPt.y = 0
            DcaArc.DStrtPt.z = 0

            Dim j As Integer = 0
            TotArCA = 0
            DAreaArrCA.Clear()
            For i As Integer = 0 To CDLst.Count - 1
                CDLst2CA.Add(CDLst(i))
            Next
            DItemQtyCA = 0
            DTotWtCA = 0
            If Not IsNothing(DcaAri) Then
                'Progress8.Show()
                TransactionsMenu.lblStatus.Visible = True
                If DrawOpt Then
                    Progress8.btnStatus.Visible = False
                    TransactionsMenu.btnStatus.Visible = False

                End If
                'Progress8.Focus()
                TransactionsMenu.lblStatus.Focus()
            End If

            For i As Integer = 0 To DQtyLstCA.Count - 1
                DPlcLstCA.Add(DQtyLstCA(i) - 1)
            Next

            fullflag = False
            OldItemQtyCA = 0
            Dim ImgName As String = "1"

            Do While Not CDLst.Count = 0 And j <= UBound(DcaAr)             'Starting the stuff placement loop
                'DDStop
                If j > 0 Then
                    If DcaAri(j) <> DcaAri(j - 1) Then
                        ImgName = (CInt(ImgName) + 1).ToString
                    End If
                End If

                OrdrCA = 0

                If chkwt Then
                    DTotWtCA += ArWt(j)
                    If DTotWtCA >= contcap Then

                        AnsW = MsgBox("Maximum weight capacity of the container is reached" & vbCrLf & "Do you want to proceed?", MsgBoxStyle.YesNo)
                        If AnsW = MsgBoxResult.No Then
                            fullflag = True

                            Exit Do

                        Else
                            fullflag = False

                            chkwt = False
                        End If

                    End If
                End If

                '+++++++++++++++++++++++++++++++++++++

                If DrawOpt Then
                    If j > 0 Then

                        If DcaAri(j - 1) <> DcaAri(j) Then

                            DItemQtyCA = 0

                            If ColCA = "r" Then
                                ColCA = "g"
                            ElseIf ColCA = "g" Then
                                ColCA = "b"
                            ElseIf ColCA = "b" Then
                                ColCA = "m"
                            ElseIf ColCA = "m" Then
                                ColCA = "c"
                            ElseIf ColCA = "c" Then
                                ColCA = "y"
                            End If

                            SzChgCA += 1

                            QtyFlgCA = True

                        Else
                            QtyFlgCA = False
                        End If
                    End If
                End If

                If SzChgCA <> 2 Then

                Else

                End If

                'DDDStop

                'The start manupulation of cross arrangement ***********************************************************

                Arm1CA = DFindOptCA(CDLst, DcaAr(j), TopUp(j))             'Arm1 = FindOpt(CDLst, Ar(j), TopUp(j))     impliment


                'DDDStop

                ArtCA = Nothing
                If Arm1CA <> -1 Then
                    ArtCA = CDLst(Arm1CA)
                End If

                Dim ArnCA As New List(Of Integer)
                Dim LstnCA As New List(Of CDArea)

                Dim B1 As New CDArea
                Dim B2 As New CDArea
                Dim Pos1 As Integer

                ArmCA = Nothing
                ArnCA = Nothing

                'DDDStop

                ArnCA = DrumFindCandidate1DHECA(CDLst, DcaAr(j), TopUp(j))          'Arn = FindCandidate1(CDLst, Ar(j), TopUp(j))           impliment
                '3sd

                'DDDStop

                Pos1 = 0
                If Not ArnCA Is Nothing Then
                    Pos1 = 0
                Else

                    Dim Arxx As New CDArea

                    Arxx.DLengths = DcaAr(j).DWidth
                    Arxx.DWidth = DcaAr(j).DLengths
                    Arxx.DHeight = DcaAr(j).DHeight

                    Stop

                    ArnCA = DrumFindCandidate1DHECA(CDLst, DcaAr(j), TopUp(j))        'Arn = FindCandidate1(CDLst, Arxx, TopUp(j))            impliment

                    'DDDStop

                    If Not ArnCA Is Nothing Then
                        Pos1 = 1
                    Else
                        If Not TopUp(j) Then
                            Arxx.DLengths = DcaAr(j).DLengths
                            Arxx.DWidth = DcaAr(j).DHeight
                            Arxx.DHeight = DcaAr(j).DWidth

                            'DDDStop

                            ArnCA = DrumFindCandidate1DHECA(CDLst, DcaAr(j), TopUp(j))           'Arn = FindCandidate1(CDLst, Arxx, False)           impliment

                            'DDDStop

                            If Not ArnCA Is Nothing Then
                                Pos1 = 2
                            End If
                        End If
                    End If
                End If

                'DDDStop

                If ArnCA Is Nothing Then

                    'DDDStop

                    ArmCA = DrumFindCandidateDHECA(DcaAr(j), CDLst)                    'Arm = FindCandidate(CDLst, Ar(j))              impliment

                    'DDDStop

                    If Not ArmCA Is Nothing Then
                        If ArmCA(0) = Arm1CA Then ArmCA = Nothing
                    End If
                End If

                'DDDStop

                If Not ArmCA Is Nothing Then

                    Stop

                    LstmCA = DrumUnionItrPDHECA(CDLst(ArmCA(0)), CDLst(ArmCA(1)))             'Lstm = UnionItrP(CDLst(Arm(0)), CDLst(Arm(1)))         impliment
                    A1CA = LstmCA(0)
                    A2CA = LstmCA(1)
                End If

                If Not ArnCA Is Nothing Then

                    Stop
                    LstmCA = DrumUnionItrPDHECA(CDLst(ArmCA(0)), CDLst(ArmCA(1)))             'Lstm = UnionItrP(CDLst(Arn(0)), CDLst(Arn(1)))         impliment
                    B1 = LstmCA(0)
                    B2 = LstmCA(1)
                End If

                'DDDStop

                If ArmCA Is Nothing And Arm1CA = -1 Then
                    If DrawOpt Then

                    End If

                    For m As Integer = j To UBound(DcaAri) - 1
                        If DcaAri(m) <> DcaAri(j) Then
                            j = m

                            GoTo LP

                        End If
                    Next
                    j = UBound(DcaAri) + 1

                    GoTo LP

                Else
                    If ArnCA Is Nothing And Arm1CA = -1 Then
                        If DrawOpt Then

                        End If

                        For m As Integer = j To UBound(DcaAri) - 1
                            If DcaAri(m) <> DcaAri(j) Then
                                j = m
                                GoTo LP

                            End If
                        Next
                        j = UBound(DcaAri)

                    End If
                End If

                'DDStop

                If Not ArmCA Is Nothing Or Not ArnCA Is Nothing Then

                    Cmd.Connection = connDrums

                    DeleteTable("DTemp2")

                    'DrmZz:

                    OrdrCA = 0
                    If Not ArmCA Is Nothing Then

                        DInsertTable("DTemp2", New Object() {CStr(A1CA.DStrtPt.x), CStr(A1CA.DStrtPt.y), CStr(A1CA.DStrtPt.z), CStr(1)})           'impliment
                    End If

                    If Not ArnCA Is Nothing Then
                        DInsertTable("DTemp2", New Object() {CStr(B1.DStrtPt.x), CStr(B1.DStrtPt.y), CStr(B1.DStrtPt.z), CStr(2)})           'impliment

                    End If

                    If Not ArtCA Is Nothing Then
                        DInsertTable("DTemp2", New Object() {CStr(ArtCA.DStrtPt.x), CStr(ArtCA.DStrtPt.y), CStr(ArtCA.DStrtPt.z), CStr(3)})        'impliment

                    End If

                    Dim RwCA As DataRow() = Nothing

                    Try
                        If Not ArmCA Is Nothing Then

                            RwCA = DGetf("DTemp2", "", "z DESC ,x ASC,y ASC")
                        End If

                        If Not ArnCA Is Nothing Then

                            RwCA = DGetf("DTemp2", "", "z DESC ,x ASC,y ASC")
                        End If

                        If ArnCA Is Nothing And ArmCA Is Nothing Then

                            RwCA = DGetf("DTemp2", "", "z DESC ,x ASC")
                        End If

                        If ArmCA Is Nothing And ArnCA Is Nothing Then

                            RwCA = DGetf("DTemp2", "", "z DESC ,x ASC,y ASC")
                        End If

                    Catch Err As Exception
                        MsgBox(Err.Message)
                        MsgBox(Err.ToString)
                        MessageBox.Show("Error in DCrossStuff" & vbCrLf & "Programme Running is failure!", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Finally
                        OrdrCA = RwCA(0)("i")
                    End Try

                    Stop

                    If OrdrCA = 3 Then
                        CDLst.RemoveAt(Arm1CA)
                    Else
                        If OrdrCA = 1 Then
                            ArtCA = A1CA
                            CDLst.RemoveAt(ArmCA(0))
                            If ArmCA(0) < ArmCA(1) Then
                                CDLst.RemoveAt(ArmCA(1) - 1)
                            Else
                                CDLst.RemoveAt(ArmCA(1))
                            End If

                            CDLst = DHDUnPush(CDLst, ArbCA) 'CDLst = UnPush(CDLst, A2)              impliment

                        End If
                        If OrdrCA = 2 Then
                            If Pos1 = 1 Then
                                Dim tmp As Double = DcaAr(j).DWidth
                                DcaAr(j).DWidth = DcaAr(j).DLengths
                                DcaAr(j).DLengths = tmp
                            End If

                            If Pos1 = 2 Then
                                Dim tmp As Double = DcaAr(j).DHeight
                                DcaAr(j).DHeight = DcaAr(j).DWidth
                                DcaAr(j).DWidth = tmp
                            End If

                            ArtCA = B1
                            CDLst.RemoveAt(ArnCA(0))
                            If ArnCA(0) < ArnCA(1) Then
                                CDLst.RemoveAt(ArnCA(1) - 1)
                            Else
                                CDLst.RemoveAt(ArnCA(1))
                            End If

                            CDLst.Add(B2)

                        End If
                        If OrdrCA = 3 Then
                            CDLst.RemoveAt(Arm1CA)
                        End If
                    End If
                Else

                    If Arm1CA <> -1 Then
                        CDLst.RemoveAt(Arm1CA)
                    End If
                End If

                Dim Qty As Integer
                If ChngFlg Then

                    '######
                    'DDDStop
                    '########

                    IICA = DrumFindOptMethodDHECA(DcaAr(j), ArtCA, Qty, TopUp(j))               'II = FindOptMethod(Ar(j), Art, Qty, TopUp(j))          impliment

                    'DDDStop

                    If DOcc > 1 Then

                        Dim OccLst1 As New List(Of Integer)

                        For i As Integer = 0 To DOccLstCA.Count - 1
                            OccLst1.Add(DOccLstCA(i))
                        Next

                        Dim Strctm1 As New StructOcc1

                        Strctm1.j = j
                        Strctm1.j1 = OccLst1
                        Strctm1.CDLstSt = CDLst
                        DOptLstCA.Add(Strctm1)

                    End If

                    Drmi.DLengths = DcaAr(j).DLengths
                    Drmi.DWidth = DcaAr(j).DWidth
                    Drmi.DHeight = DcaAr(j).DHeight

                    'ARcaDrm.DLengths = DcaAr(j).DLengths
                    'ARcaDrm.DWidth = DcaAr(j).DWidth
                    'ARcaDrm.DHeight = DcaAr(j).DHeight

                    'Dim Dln As Double = Ar(j).DLengths
                    'Dim Dwd As Double = Ar(j).DWidth
                    'Dim Dht As Double = Ar(j).DHeight

                    'DDDStop

                    Dim Nm As String = DcaAri(j)
                    Dim P As Integer = j

                    If IICA = 1 Then
                        DcaAr(P).DLengths = Drmi.DLengths
                        DcaAr(P).DWidth = Drmi.DWidth
                        DcaAr(P).DHeight = Drmi.DHeight

                    End If

                    If IICA = 2 Then
                        DcaAr(P).DLengths = Drmi.DLengths
                        DcaAr(P).DWidth = Drmi.DWidth
                        DcaAr(P).DHeight = Drmi.DHeight

                    End If

                    If IICA = 3 Then
                        DcaAr(P).DLengths = Drmi.DLengths
                        DcaAr(P).DWidth = Drmi.DWidth
                        DcaAr(P).DHeight = Drmi.DHeight

                    End If

                    If IICA = 4 Then
                        DcaAr(P).DLengths = Drmi.DLengths
                        DcaAr(P).DWidth = Drmi.DWidth
                        DcaAr(P).DHeight = Drmi.DHeight

                    End If

                    If IICA = 5 Then
                        DcaAr(P).DLengths = Drmi.DLengths
                        DcaAr(P).DWidth = Drmi.DWidth
                        DcaAr(P).DHeight = Drmi.DHeight

                    End If

                    If IICA = 6 Then
                        DcaAr(P).DLengths = Drmi.DLengths
                        DcaAr(P).DWidth = Drmi.DWidth
                        DcaAr(P).DHeight = Drmi.DHeight

                    End If

                End If

                Dim Flg As Boolean = Math.Abs(((DcaAr(j).DLengths * DcaAr(j).DWidth * DcaAr(j).DHeight) * Qty) - (ArtCA.DLengths * ArtCA.DWidth * ArtCA.DHeight)) < 0.01


                Drmi.DmQty = DrmQt.DFindQty(DcaAri, j)             'Use DCalcQty.dll 

                'DDDStop

                If Drmi.DmQty >= Qty And Flg Then                         'If Mm >= Qty And Flg Then

                    If DrawOpt Then
                        If TranspArr(j) Then
                            TravalCA = 0.8
                        Else
                            TravalCA = 0
                        End If
                        DcaAr(j).DStrtPt.x = ArtCA.DStrtPt.x
                        DcaAr(j).DStrtPt.y = ArtCA.DStrtPt.y
                        DcaAr(j).DStrtPt.z = ArtCA.DStrtPt.z

                        'Remain as it is commented do not use
                        'Ar(j).AutoDraw(OutFile, Col, traval, "file:///c:/t2.png", Ari(j), ArWt(j), QtyFlg, TxtOpt, "", 0, True, "c")
                        j += Qty
                        DItemQtyCA += Qty
                    Else
                        j += Qty

                        DItemQtyCA += Qty
                        DPlcLstCA(DItemNoCA) = DItemQtyCA               'impliment
                        DTotWtCA += ArWt(j)
                        GoTo LP
                    End If

                End If

                ArmCA = Nothing
                ArnCA = Nothing

                DcaAr(j).DStrtPt.x = ArtCA.DStrtPt.x
                DcaAr(j).DStrtPt.y = ArtCA.DStrtPt.y
                DcaAr(j).DStrtPt.z = ArtCA.DStrtPt.z

                If SaveOpt Then

ML:
                    Try
                        Cmd.ExecuteNonQuery()
                    Catch ec As Exception
                        If ec.Message = "Cannot open any more tables." Then
                            connDrums.Close()
                            connDrums.Dispose()
                            OleDb.OleDbConnection.ReleaseObjectPool()
                            Cmd.Dispose()
                            GC.Collect()

                            connDrums.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\Drums.mdb;Persist Security Info=False"

                            connDrums.Open()
                            GoTo ML
                        End If

                    End Try
                    id1 += 1
                End If

                If DrawOpt Then

                    If TranspArr(j) Then
                        TravalCA = 0.8
                    Else
                        TravalCA = 0
                    End If
                End If
                If j = UBound(DcaAr) Then

                End If
                If DrawOpt Then
                    If j <> 0 Then
                        If DcaAri(j) <> DcaAri(j - 1) Then
                            TmpLstCA.Add(DcaAri(j - 1))
                            TmpLstCA.Add(CStr(TotArCA))
                            DAreaArrCA.Add(TmpLstCA)
                            TotArCA = 0
                            TotArCA = TotArCA + (DcaAr(j).DLengths * DcaAr(j).DWidth * DcaAr(j).DHeight)
                        Else
                            TotArCA = TotArCA + (DcaAr(j).DLengths * DcaAr(j).DWidth * DcaAr(j).DHeight)
                        End If
                    Else
                        TotArCA = TotArCA + (DcaAr(j).DLengths * DcaAr(j).DWidth * DcaAr(j).DHeight)
                    End If
                End If

                'DDDStop


                Dim Radius As Double = 0

                DDiaL = DcaAr(j).DLengths
                DDiaW = DcaAr(j).DWidth
                DRds = DcaAr(j).DRadius
                DHt = DcaAr(j).DHeight

                DpRds = DRds            'Previous value assign
                DpHt = DHt

                If DDiaL = DDiaW Then
                    DDia = DDiaL
                    Radius = DDia * 0.5
                    If Radius <> DRds Then
                        MessageBox.Show("The dimensioning adequacy in radius and diameter in cross arrangement", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If

                '$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

                If DrawOpt Then
                    TxtOpt = True

                    'DDDStop

                    DcaAr(j).AutoDrawDrmCA(OutFile, ColCA, TravalCA, "s" & ImgName & ".png", DcaAri(j), ArWt(j), QtyFlgCA, TxtOpt, DcaAri(j), IICA, True, "b", DDia, DRds, DHt)

                    If FlgCA Then

                        If Not flgCAqt Then

                            Stop
                            DbCrsStuff(OutFile, ColCA, TravalCA, "s" & ImgName & ".png", DcaAri(j), ArWt(j), QtyFlgCA, TxtOpt, DcaAri(j), IICA, True, "b", DDia, DRds, DHt)

                        Else

                            '%%%%%%%%%%%%%%%%%%%%%%%%%

                            If flgCAqt Then

                                Do While Not CDQCAer.Count = 0

                                    DCA = CDQCAer.Dequeue
                                    CDLst.Add(DCA)

                                Loop
                                Return CDLst
                            End If

                            Stop

                            '%%%%%%%%%%%%%%%%%%%%%%%%%

                            GoTo OutLp

                        End If

                        If Not flgCAqt Then

                            Stop

                            CDQCAer = DPlaceCA(OutFile, ColCA, TravalCA, "s" & ImgName & ".png", DcaAri(j), ArWt(j), QtyFlgCA, TxtOpt, DcaAri(j), IICA, True, "b", DDia, DRds, DHt)

                            Stop

                        Else

                            '%%%%%%%%%%%%%%%%%%%%%%%%%

                            If flgCAqt Then

                                Do While Not CDQCAer.Count = 0

                                    DCA = CDQCAer.Dequeue
                                    CDLst.Add(DCA)

                                Loop
                                Return CDLst
                            End If

                            Stop

                            '%%%%%%%%%%%%%%%%%%%%%%%%%

                            GoTo outlp

                        End If

                        If Not flgCAqt Then

                            Stop

                            CDQCAer = DArgmtNxt(OutFile, ColCA, TravalCA, "s" & ImgName & ".png", DcaAri(j), ArWt(j), QtyFlgCA, TxtOpt, DcaAri(j), IICA, True, "b", DDia, DRds, DHt)

                            Stop

                        Else

                            '%%%%%%%%%%%%%%%%%%%%%%%%%

                            If flgCAqt Then

                                Do While Not CDQCAer.Count = 0

                                    DCA = CDQCAer.Dequeue
                                    CDLst.Add(DCA)

                                Loop

                                Stop

                                'New Changes Here Done 12 July 2K8

                                flgNxtArg = True


                                GoTo OutLp
                                'Return CDLst

                            End If

                            Stop

                            '%%%%%%%%%%%%%%%%%%%%%%%%%

                            GoTo OutLp

                        End If

                        'DCArngmt = True

                        Stop

                        '%%%%%%%%%%%%%%%%%%%%%%%%%

                        If flgCAqt Then

                            Do While Not CDQCAer.Count = 0

                                DCA = CDQCAer.Dequeue
                                CDLst.Add(DCA)

                            Loop

                            Stop

                            'Return CDLst
                            flgNxtArg = True
                            GoTo OutLp

                            Stop

                        End If

                        Stop

                        '%%%%%%%%%%%%%%%%%%%%%%%%%

                        'Exit Try

                        Stop

                        'connDrums.Close()
                        'siSW.Close()

                    End If

                    'DDDStop

                    'DCA = CDQCAer.Dequeue
                    'CDLst.Add(DCA)
                    'DDStop

                    '*****************************************************************************
                    If DQtyLstCA.Count > 0 Then

                        DPlcLstCA(DrmRWidx) = DItemQtyCA

                    End If

                    DItemQtyCA += 1

                Else
                    DItemQtyCA += 1
                    DTotWtCA += ArWt(j)
                End If

                'DDDsStop

                If Not IsNothing(DcaAri) Then

                    '*********************************************
                    'DDDStop

                    If DItemQtyCA = 20 Then
                        MsgBox("OK")
                        Stop
                        'siSW.Close()

                    End If

                    'siSW.Close()

                    DCountCSQ(ItrQty)       'ItemQty)              'Count Cross stuffed Quantity              impliment

                    Stop

                    'Progress8.i = ItemQty
                    'TransactionsMenu.lblStatus.Text = " Please wait " & CStr(Dot) & ""
                    'TransactionsMenu.lblStatus.Text = " Numbers ::   " & CStr(ItemQty) & "    -> Items stuffed"
                    'TransactionsMenu.lblStatus.Text = "Cross stuff arrangement in progress :: " & CStr(ItemQty) & Chr(13) & vbCr & "       Please wait ....."
                    'TransactionsMenu.btnStatus.Visible = True

                    'Eventful()

                    'TransactionsMenu.lblStatus.Refresh()
                    'System.Windows.Forms.Application.DoEvents()

                    'Impliment from here 30 June 2008 

                    '*********************************************
                    '7sd
                    'DDDStop

                    'siSW.Close()

                    If exflg Then
                        exflg = False
                        GoTo LP
                    End If
                End If

                'CrossArngmtx:
                'If FlgCA Then
                'siSW.Close()
                'Stop
                'siSW.Close()
                'Q = Art.SubtractCA(Ar(j))
                'Return CDLst
                'Exit Function
                'End If

OutLp:

                'DDDStop


                'DQCA = ArtCA.DrumSubtractDHD(DcaAr(j))          'Q = Art.Subtract(Ar(j))                'impliment


                '******************************************************************************************

                If flgCAqt Then

                    'If flgCAqt Then

                    '    Do While Not CDQCAer.Count = 0

                    '        DCA = CDQCAer.Dequeue

                    '        CDLst.Add(DCA)

                    '        'Stop

                    '    Loop

                    '    Stop

                    '    flgCAqt = False

                    'End If

                    'DCA = CDQCAer.Dequeue

                    'CDLst.Add(DCA)

                    'DDStop

                Else

                    Stop

                    'Implements from  12 July 2K8

                    DQCA = ArtCA.DrumSubtractDHD(DcaAr(j))          'Q = Art.Subtract(Ar(j))                'impliment

                    Stop

                End If

                Stop

                'GoTo Direct
                '^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

                'Next row arrangement of row start here

                If flgNxtArg Then


                    Stop

                    Dim Dcpt As New CDrum                          'Last position of drum value assigns 

                    Dcpt.DStrtPt.x = DCA.DStrtPt.x
                    Dcpt.DStrtPt.y = DCA.DStrtPt.y
                    Dcpt.DStrtPt.z = DCA.DStrtPt.z

                    Dcpt.DCntPt.X = DCA.DStrtPt.x
                    Dcpt.DCntPt.Y = DCA.DStrtPt.y
                    Dcpt.DCntPt.Z = DCA.DStrtPt.z

                    Dcpt.DmQty = DCA.DmQty

                    XL = DCA.DStrtPt.x
                    YL = DCA.DStrtPt.y
                    ZL = DCA.DStrtPt.z

                    Dim DnApt As New CDArea

                    DnApt.DStrtPt.x = DCA.DStrtPt.x
                    DnApt.DStrtPt.y = DCA.DStrtPt.y
                    DnApt.DStrtPt.z = DCA.DStrtPt.z

                    DnApt.DCntPt.X = DCA.DStrtPt.x
                    DnApt.DCntPt.Y = DCA.DStrtPt.y
                    DnApt.DCntPt.Z = DCA.DStrtPt.z

                    Stop


                    Dim DArCA As New CDrum

                    '*********************************************************************************************
                    ' Dim j As Integer = Dcpt.DmQty + 1

                    j = Dcpt.DmQty + 1

                    Dim DNos As Integer = DcaAr.Length()

                    Dim dB As New CDArea

                    If DNos > Dcpt.DmQty Then                      'If Drmi.DmQty >= Qty And Flg Then                         'If Mm >= Qty And Flg Then

                        DArCA.DHeight = DcaAr(j).DHeight
                        DArCA.DLengths = DcaAr(j).DLengths
                        DArCA.DWidth = DcaAr(j).DWidth

                        DArCA.DStrtPt.x = DnApt.DCntPt.X
                        DArCA.DStrtPt.y = DnApt.DCntPt.Y
                        DArCA.DStrtPt.z = DnApt.DCntPt.Z

                        'DcaAr(j).DStrtPt.x = DArCA.DStrtPt.x
                        'DcaAr(j).DStrtPt.y = DArCA.DStrtPt.y
                        'DcaAr(j).DStrtPt.z = DArCA.DStrtPt.z

                        dB.DHeight = DArCA.DHeight                   'DnApt.DHeight = DArCA.DHeight
                        dB.DLengths = DArCA.DLengths                 'DnApt.DLengths = DArCA.DLengths
                        dB.DWidth = DArCA.DWidth                     'DnApt.DWidth = DArCA.DWidth

                        DnApt.DLengths = DcaArc.DLengths - DnApt.DStrtPt.y          'Reamining container present LWH calculated
                        DnApt.DWidth = DcaArc.DWidth - DnApt.DStrtPt.x
                        DnApt.DHeight = DcaArc.DHeight - DnApt.DStrtPt.z

                    End If

                    '*****************************************************************

                    Stop

                    Dim DImgName As String = "1"

                    ''Do While Not CDLst.Count = 0 And j <= UBound(DcaAr)             'Starting the stuff placement loop
                    ''Stop
                    'If j > 0 Then
                    '    If DcaAri(j) <> DcaAri(j - 1) Then
                    '        DImgName = (CInt(DImgName) + 1).ToString
                    '    End If
                    'End If

                    ' Dim QtyFlgCA As Boolean = True

                    'Dim K As Integer = Dcpt.DmQty + 1

                    'Dim DColCA As String = "b"

                    'If DrawOpt Then
                    '    If K > 0 Then

                    '        If DcaAri(K - 1) <> DcaAri(K) Then

                    '            If DColCA = "r" Then
                    '                DColCA = "g"
                    '            ElseIf DColCA = "g" Then
                    '                DColCA = "b"
                    '            ElseIf DColCA = "b" Then
                    '                DColCA = "m"
                    '            ElseIf DColCA = "m" Then
                    '                DColCA = "c"
                    '            ElseIf DColCA = "c" Then
                    '                DColCA = "y"
                    '            End If
                    '            QtyFlgCA = True
                    '        Else
                    '            QtyFlgCA = False
                    '        End If
                    '    End If
                    'End If


                    '*****************************************************************
                    '####################################################################

                    Dim DArItm() As CDArea
                    Dim DAri2() As String
                    Dim DArwt2() As Single
                    Dim DTranspArr2() As Boolean

                    ReDim DArItm(0)
                    ReDim DAri2(0)
                    ReDim DArwt2(0)
                    ReDim DTranspArr2(0)

                    'DStop
                    For L As Integer = Dcpt.DmQty + 1 To DNos - 1

                        DcaAr(L).DStrtPt.x = DArCA.DStrtPt.x
                        DcaAr(L).DStrtPt.y = DArCA.DStrtPt.y
                        DcaAr(L).DStrtPt.z = DArCA.DStrtPt.z

                    Next

                    For M As Integer = Dcpt.DmQty + 1 To DNos - 1

                        DArItm(UBound(DArItm)) = DcaAr(M)
                        DAri2(UBound(DAri2)) = DcaAri(M)
                        DArwt2(UBound(DArwt2)) = ArWt(M)
                        DTranspArr2(UBound(DTranspArr2)) = TranspArr(M)

                        ReDim Preserve DArItm(UBound(DArItm) + 1)
                        ReDim Preserve DAri2(UBound(DAri2) + 1)
                        ReDim Preserve DArwt2(UBound(DArwt2) + 1)
                        ReDim Preserve DTranspArr2(UBound(DTranspArr2) + 1)
                        ReDim Preserve TopUp(UBound(TopUp) + 1)
                    Next

                    ReDim Preserve DArItm(UBound(DArItm) - 1)
                    ReDim Preserve DAri2(UBound(DAri2) - 1)
                    ReDim Preserve DArwt2(UBound(DArwt2) - 1)
                    ReDim Preserve DTranspArr2(UBound(DTranspArr2) - 1)


                    Stop

                    Do While Not CDLst.Count = 0 And j <= UBound(DcaAr)             'Starting reamining stuff placement loop

                        Stop

                        If j > 0 Then
                            If DcaAri(j) <> DcaAri(j - 1) Then
                                DImgName = (CInt(DImgName) + 1).ToString
                            End If
                        End If


                        Stop



                        Dim K As Integer = Dcpt.DmQty + 1

                        'Dim DColCA As String = "b"

                        If DrawOpt Then
                            If K > 0 Then

                                If DcaAri(K - 1) <> DcaAri(K) Then

                                    If ColCA = "r" Then
                                        ColCA = "g"
                                    ElseIf ColCA = "g" Then
                                        ColCA = "b"
                                    ElseIf ColCA = "b" Then
                                        ColCA = "m"
                                    ElseIf ColCA = "m" Then
                                        ColCA = "c"
                                    ElseIf ColCA = "c" Then
                                        ColCA = "y"
                                    End If
                                    QtyFlgCA = True
                                Else
                                    QtyFlgCA = False
                                End If
                            End If
                        End If

                        Stop

                        'The second dgv row start manupulation of cross arrangement ***********************************************************

                        Arm1CA = DFindOptCA(CDLst, DcaAr(j), TopUp(j))             'Arm1 = FindOpt(CDLst, Ar(j), TopUp(j))     impliment


                        Stop

                        ArtCA = Nothing
                        If Arm1CA <> -1 Then
                            ArtCA = CDLst(Arm1CA)
                        End If

                        'Dim ArnCA As New List(Of Integer)
                        'Dim LstnCA As New List(Of CDArea)

                        'Dim B1 As New CDArea
                        'Dim B2 As New CDArea
                        'Dim Pos1 As Integer

                        ArmCA = Nothing
                        ArnCA = Nothing

                        Stop

                        ArnCA = DrumFindCandidate1DHECA(CDLst, DcaAr(j), TopUp(j))          'Arn = FindCandidate1(CDLst, Ar(j), TopUp(j))           impliment
                        '3sd

                        Stop

                        Pos1 = 0
                        If Not ArnCA Is Nothing Then
                            Pos1 = 0
                        Else

                            Dim Arxx As New CDArea

                            Arxx.DLengths = DcaAr(j).DWidth
                            Arxx.DWidth = DcaAr(j).DLengths
                            Arxx.DHeight = DcaAr(j).DHeight

                            Stop

                            ArnCA = DrumFindCandidate1DHECA(CDLst, DcaAr(j), TopUp(j))        'Arn = FindCandidate1(CDLst, Arxx, TopUp(j))            impliment

                            Stop

                            If Not ArnCA Is Nothing Then
                                Pos1 = 1
                            Else
                                If Not TopUp(j) Then
                                    Arxx.DLengths = DcaAr(j).DLengths
                                    Arxx.DWidth = DcaAr(j).DHeight
                                    Arxx.DHeight = DcaAr(j).DWidth

                                    Stop

                                    ArnCA = DrumFindCandidate1DHECA(CDLst, DcaAr(j), TopUp(j))           'Arn = FindCandidate1(CDLst, Arxx, False)           impliment

                                    Stop

                                    If Not ArnCA Is Nothing Then
                                        Pos1 = 2
                                    End If
                                End If
                            End If
                        End If

                        Stop

                        If ArnCA Is Nothing Then

                            Stop

                            ArmCA = DrumFindCandidateDHECA(DcaAr(j), CDLst)                    'Arm = FindCandidate(CDLst, Ar(j))              impliment

                            Stop

                            If Not ArmCA Is Nothing Then
                                If ArmCA(0) = Arm1CA Then ArmCA = Nothing
                            End If
                        End If

                        Stop

                        If Not ArmCA Is Nothing Then

                            Stop

                            LstmCA = DrumUnionItrPDHECA(CDLst(ArmCA(0)), CDLst(ArmCA(1)))             'Lstm = UnionItrP(CDLst(Arm(0)), CDLst(Arm(1)))         impliment
                            A1CA = LstmCA(0)
                            A2CA = LstmCA(1)
                        End If

                        If Not ArnCA Is Nothing Then

                            Stop
                            LstmCA = DrumUnionItrPDHECA(CDLst(ArmCA(0)), CDLst(ArmCA(1)))             'Lstm = UnionItrP(CDLst(Arn(0)), CDLst(Arn(1)))         impliment
                            B1 = LstmCA(0)
                            B2 = LstmCA(1)
                        End If

                        Stop

                        If ArmCA Is Nothing And Arm1CA = -1 Then
                            If DrawOpt Then

                            End If

                            For m As Integer = j To UBound(DcaAri) - 1
                                If DcaAri(m) <> DcaAri(j) Then
                                    j = m

                                    GoTo LP

                                End If
                            Next
                            j = UBound(DcaAri) + 1

                            GoTo LP

                        Else
                            If ArnCA Is Nothing And Arm1CA = -1 Then
                                If DrawOpt Then

                                End If

                                For m As Integer = j To UBound(DcaAri) - 1
                                    If DcaAri(m) <> DcaAri(j) Then
                                        j = m
                                        GoTo LP

                                    End If
                                Next
                                j = UBound(DcaAri)

                            End If
                        End If


                        Stop


                        If Not ArmCA Is Nothing Or Not ArnCA Is Nothing Then

                            Cmd.Connection = connDrums

                            DeleteTable("DTemp2")

                            'DrmZz:

                            OrdrCA = 0
                            If Not ArmCA Is Nothing Then

                                DInsertTable("DTemp2", New Object() {CStr(A1CA.DStrtPt.x), CStr(A1CA.DStrtPt.y), CStr(A1CA.DStrtPt.z), CStr(1)})           'impliment
                            End If

                            If Not ArnCA Is Nothing Then
                                DInsertTable("DTemp2", New Object() {CStr(B1.DStrtPt.x), CStr(B1.DStrtPt.y), CStr(B1.DStrtPt.z), CStr(2)})           'impliment

                            End If

                            If Not ArtCA Is Nothing Then
                                DInsertTable("DTemp2", New Object() {CStr(ArtCA.DStrtPt.x), CStr(ArtCA.DStrtPt.y), CStr(ArtCA.DStrtPt.z), CStr(3)})        'impliment

                            End If

                            Stop

                            Dim RwCA As DataRow() = Nothing

                            Try
                                If Not ArmCA Is Nothing Then

                                    RwCA = DGetf("DTemp2", "", "z DESC ,x ASC,y ASC")
                                End If

                                If Not ArnCA Is Nothing Then

                                    RwCA = DGetf("DTemp2", "", "z DESC ,x ASC,y ASC")
                                End If

                                If ArnCA Is Nothing And ArmCA Is Nothing Then

                                    RwCA = DGetf("DTemp2", "", "z DESC ,x ASC")
                                End If

                                If ArmCA Is Nothing And ArnCA Is Nothing Then

                                    RwCA = DGetf("DTemp2", "", "z DESC ,x ASC,y ASC")
                                End If

                            Catch Err As Exception
                                MsgBox(Err.Message)
                                MsgBox(Err.ToString)
                                MessageBox.Show("Error in DCrossStuff" & vbCrLf & "Programme Running is failure!", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Finally
                                OrdrCA = RwCA(0)("i")
                            End Try

                            Stop

                            If OrdrCA = 3 Then
                                CDLst.RemoveAt(Arm1CA)
                            Else
                                If OrdrCA = 1 Then
                                    ArtCA = A1CA
                                    CDLst.RemoveAt(ArmCA(0))
                                    If ArmCA(0) < ArmCA(1) Then
                                        CDLst.RemoveAt(ArmCA(1) - 1)
                                    Else
                                        CDLst.RemoveAt(ArmCA(1))
                                    End If

                                    CDLst = DHDUnPush(CDLst, ArbCA) 'CDLst = UnPush(CDLst, A2)              impliment

                                End If
                                If OrdrCA = 2 Then
                                    If Pos1 = 1 Then
                                        Dim tmp As Double = DcaAr(j).DWidth
                                        DcaAr(j).DWidth = DcaAr(j).DLengths
                                        DcaAr(j).DLengths = tmp
                                    End If

                                    If Pos1 = 2 Then
                                        Dim tmp As Double = DcaAr(j).DHeight
                                        DcaAr(j).DHeight = DcaAr(j).DWidth
                                        DcaAr(j).DWidth = tmp
                                    End If

                                    ArtCA = B1
                                    CDLst.RemoveAt(ArnCA(0))
                                    If ArnCA(0) < ArnCA(1) Then
                                        CDLst.RemoveAt(ArnCA(1) - 1)
                                    Else
                                        CDLst.RemoveAt(ArnCA(1))
                                    End If

                                    CDLst.Add(B2)

                                End If
                                If OrdrCA = 3 Then
                                    CDLst.RemoveAt(Arm1CA)
                                End If
                            End If
                        Else

                            If Arm1CA <> -1 Then
                                CDLst.RemoveAt(Arm1CA)
                            End If
                        End If

                        Stop



                        'Impliments 14 July 2K8 From here.....


                        'Dim Qty As Integer
                        If ChngFlg Then

                            '######
                            Stop
                            '########

                            IICA = DrumFindOptMethodDHECA(DcaAr(j), ArtCA, Qty, TopUp(j))               'II = FindOptMethod(Ar(j), Art, Qty, TopUp(j))          impliment

                            Stop

                            If DOcc > 1 Then

                                Dim OccLst1 As New List(Of Integer)

                                For i As Integer = 0 To DOccLstCA.Count - 1
                                    OccLst1.Add(DOccLstCA(i))
                                Next

                                Dim Strctm1 As New StructOcc1

                                Strctm1.j = j
                                Strctm1.j1 = OccLst1
                                Strctm1.CDLstSt = CDLst
                                DOptLstCA.Add(Strctm1)

                            End If

                            Drmi.DLengths = DcaAr(j).DLengths
                            Drmi.DWidth = DcaAr(j).DWidth
                            Drmi.DHeight = DcaAr(j).DHeight

                            'ARcaDrm.DLengths = DcaAr(j).DLengths
                            'ARcaDrm.DWidth = DcaAr(j).DWidth
                            'ARcaDrm.DHeight = DcaAr(j).DHeight

                            'Dim Dln As Double = Ar(j).DLengths
                            'Dim Dwd As Double = Ar(j).DWidth
                            'Dim Dht As Double = Ar(j).DHeight

                            Stop

                            Dim Nm As String = DcaAri(j)
                            Dim P As Integer = j

                            If IICA = 1 Then
                                DcaAr(P).DLengths = Drmi.DLengths
                                DcaAr(P).DWidth = Drmi.DWidth
                                DcaAr(P).DHeight = Drmi.DHeight

                            End If

                            If IICA = 2 Then
                                DcaAr(P).DLengths = Drmi.DLengths
                                DcaAr(P).DWidth = Drmi.DWidth
                                DcaAr(P).DHeight = Drmi.DHeight

                            End If

                            If IICA = 3 Then
                                DcaAr(P).DLengths = Drmi.DLengths
                                DcaAr(P).DWidth = Drmi.DWidth
                                DcaAr(P).DHeight = Drmi.DHeight

                            End If

                            If IICA = 4 Then
                                DcaAr(P).DLengths = Drmi.DLengths
                                DcaAr(P).DWidth = Drmi.DWidth
                                DcaAr(P).DHeight = Drmi.DHeight

                            End If

                            If IICA = 5 Then
                                DcaAr(P).DLengths = Drmi.DLengths
                                DcaAr(P).DWidth = Drmi.DWidth
                                DcaAr(P).DHeight = Drmi.DHeight

                            End If

                            If IICA = 6 Then
                                DcaAr(P).DLengths = Drmi.DLengths
                                DcaAr(P).DWidth = Drmi.DWidth
                                DcaAr(P).DHeight = Drmi.DHeight

                            End If

                        End If

                        Stop

                        'Dim Flg As Boolean = Math.Abs(((DcaAr(j).DLengths * DcaAr(j).DWidth * DcaAr(j).DHeight) * Qty) - (ArtCA.DLengths * ArtCA.DWidth * ArtCA.DHeight)) < 0.01

                        Flg = Math.Abs(((DcaAr(j).DLengths * DcaAr(j).DWidth * DcaAr(j).DHeight) * Qty) - (ArtCA.DLengths * ArtCA.DWidth * ArtCA.DHeight)) < 0.01


                        Drmi.DmQty = DrmQt.DFindQty(DcaAri, j)             'Use DCalcQty.dll 


                        'Stop

                        If Drmi.DmQty >= Qty And Flg Then                         'If Mm >= Qty And Flg Then

                            If DrawOpt Then
                                If TranspArr(j) Then
                                    TravalCA = 0.8
                                Else
                                    TravalCA = 0
                                End If

                                'DcaAr(j).DStrtPt.x = ArtCA.DStrtPt.x
                                'DcaAr(j).DStrtPt.y = ArtCA.DStrtPt.y
                                'DcaAr(j).DStrtPt.z = ArtCA.DStrtPt.z

                                'Remain as it is commented do not use
                                'Ar(j).AutoDraw(OutFile, Col, traval, "file:///c:/t2.png", Ari(j), ArWt(j), QtyFlg, TxtOpt, "", 0, True, "c")
                                j += Qty
                                DItemQtyCA += Qty
                            Else
                                j += Qty

                                DItemQtyCA += Qty
                                DPlcLstCA(DItemNoCA) = DItemQtyCA               'impliment
                                DTotWtCA += ArWt(j)
                                GoTo LP
                            End If

                        End If

                        ArmCA = Nothing
                        ArnCA = Nothing

                        'DcaAr(j).DStrtPt.x = ArtCA.DStrtPt.x
                        'DcaAr(j).DStrtPt.y = ArtCA.DStrtPt.y
                        'DcaAr(j).DStrtPt.z = ArtCA.DStrtPt.z

                        If SaveOpt Then

CAML:
                            Try
                                Cmd.ExecuteNonQuery()
                            Catch ec As Exception
                                If ec.Message = "Cannot open any more tables." Then
                                    connDrums.Close()
                                    connDrums.Dispose()
                                    OleDb.OleDbConnection.ReleaseObjectPool()
                                    Cmd.Dispose()
                                    GC.Collect()

                                    connDrums.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\Drums.mdb;Persist Security Info=False"

                                    connDrums.Open()
                                    GoTo CAML
                                End If

                            End Try
                            id1 += 1
                        End If

                        If DrawOpt Then

                            If TranspArr(j) Then
                                TravalCA = 0.8
                            Else
                                TravalCA = 0
                            End If
                        End If

                        If j = UBound(DcaAr) Then

                        End If

                        If DrawOpt Then
                            If j <> 0 Then
                                If DcaAri(j) <> DcaAri(j - 1) Then
                                    TmpLstCA.Add(DcaAri(j - 1))
                                    TmpLstCA.Add(CStr(TotArCA))
                                    DAreaArrCA.Add(TmpLstCA)
                                    TotArCA = 0
                                    TotArCA = TotArCA + (DcaAr(j).DLengths * DcaAr(j).DWidth * DcaAr(j).DHeight)
                                Else
                                    TotArCA = TotArCA + (DcaAr(j).DLengths * DcaAr(j).DWidth * DcaAr(j).DHeight)
                                End If
                            Else
                                TotArCA = TotArCA + (DcaAr(j).DLengths * DcaAr(j).DWidth * DcaAr(j).DHeight)
                            End If
                        End If

                        Stop


                        'Dim Radius As Double = 0
                        Radius = 0

                        DDiaL = DcaAr(j).DLengths
                        DDiaW = DcaAr(j).DWidth
                        DRds = DcaAr(j).DRadius
                        DHt = DcaAr(j).DHeight

                        Dim pRds As Double = DpRds             '= DRds            'Previous value assign
                        Dim pHt As Double = DpHt                 ' = DHt

                        DpRds = DpRds
                        DpHt = DpHt


                        If DDiaL = DDiaW Then
                            DDia = DDiaL
                            Radius = DDia * 0.5
                            If Radius <> DRds Then
                                MessageBox.Show("The dimensioning adequacy in radius and diameter in cross arrangement", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        End If

                        '$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

                        Dim ODca As New CDrum

                        ODca.DStrtPt.x = DcaAr(j).DStrtPt.x
                        ODca.DStrtPt.y = DcaAr(j).DStrtPt.y
                        ODca.DStrtPt.z = DcaAr(j).DStrtPt.z

                        Stop

                        If DrawOpt Then
                            TxtOpt = True

                            'Stop

                            Dcpt.AutoPlotDrmCA(OutFile, ColCA, TravalCA, "s" & DImgName & ".png", DcaAri(j), ArWt(j), QtyFlgCA, TxtOpt, DcaAri(j), IICA, True, "b", DDia, DRds, DHt)

                            'DcaAr(j).AutoPlotDrmCA(OutFile, ColCA, TravalCA, "s" & DImgName & ".png", DcaAri(j), ArWt(j), QtyFlgCA, TxtOpt, DcaAri(j), IICA, True, "b", DDia, DRds, DHt)

                            DItemQtyCA = ItrQty

                            'siSW.Close()


                            If DQtyLstCA.Count > 0 Then

                                DPlcLstCA(DrmRWidx) = DItemQtyCA

                            End If

                            DItemQtyCA += 1

                        Else
                            DItemQtyCA += 1
                            DTotWtCA += ArWt(j)
                        End If

                        Stop

                        'siSW.Close()

                        If Not IsNothing(DcaAri) Then

                            '*********************************************
                            Stop

                            If DItemQtyCA = 20 Then
                                'MsgBox("OK")
                                Stop
                                'siSW.Close()

                            End If

                            ItrQty = DItemQtyCA

                            'siSW.Close()

                            DCountCSQ(ItrQty)       'ItemQty)              'Count Cross stuffed Quantity              impliment

                            'Stop

                            'Progress8.i = ItemQty
                            'TransactionsMenu.lblStatus.Text = " Please wait " & CStr(Dot) & ""
                            'TransactionsMenu.lblStatus.Text = " Numbers ::   " & CStr(ItemQty) & "    -> Items stuffed"
                            'TransactionsMenu.lblStatus.Text = "Cross stuff arrangement in progress :: " & CStr(ItemQty) & Chr(13) & vbCr & "       Please wait ....."
                            'TransactionsMenu.btnStatus.Visible = True
                            'Eventful()
                            'TransactionsMenu.lblStatus.Refresh()
                            'System.Windows.Forms.Application.DoEvents()

                            'Impliment from here 30 June 2008 
                            '*********************************************
                            '7sd
                            'Stop
                            'siSW.Close()
                            'If exflg Then
                            '    exflg = False
                            '    GoTo LP
                            'End If
                        End If


                        '***********************
                        'Stop
                        '***********************

                        'Impliments 15 July 2K8

                        '***********************
                        'Stop
                        '***********************

                        'Stop

                        Dim ODcat As New CDArea

                        'ODcat.DStrtPt.x = DcaAr(j).DStrtPt.x
                        'ODcat.DStrtPt.y = DcaAr(j).DStrtPt.y
                        'ODcat.DStrtPt.z = DcaAr(j).DStrtPt.z

                        'Stop

                        ' siSW.Close()



                        'Bridge function to assign the proper location of dimensions to that proper veriable

                        ' DQCA = DcaAr(j).BridgeED(DcaAr(j), ArItm(j))

                        'Stop






                        'DQCA = ArtCA.DrumSubtractDHD(DcaAr(j))          'Q = Art.Subtract(Ar(j))                'impliment

                        DQCA = ODca.DrumSubtractDHDCA(DcaAr(j))
                        '****************************

                        siSW.Close()


                        'Stop





                        '//////////////////////////////////////

                        Dim DdCA As New CDArea

                        If Not DQCA Is Nothing Then
                            If CDLst.Count = 0 Then
                                Do While Not DQCA.Count = 0

                                    DdCA = DQCA.Dequeue

                                    CDLst.Add(DdCA)

                                Loop
                            Else
                                Do While DQCA.Count > 0
                                    ArbCA = DQCA.Dequeue
                                    Ans1CA = False

                                    'Stop

                                    'siSW.Close()


                                    CDLst = DHDUnPush(CDLst, ArbCA) 'CDLst = UnPush(CDLst, Arb)         impliment

                                    Stop

                                Loop

                                Stop

                            End If

                        End If

                        Dim AnsCA2 As Boolean

                        For i As Integer = 0 To CDLst.Count - 1

                            Dim Arx As New CDArea

                            Arx = CDLst(i)


                            'siSW.Close()


                            CDLst = DHVMrgX(CDLst, Arx, AnsCA2)       'CDLst = MrgX(CDLst, Arx, Ans2)             impliment

                            '9sd

                            Stop

                            If AnsCA2 Then
                                Exit For
                            End If


                        Next

                        'Stop

                        'siSW.Close()


                        Dim StR1n1CA As New StructR1

                        Dim CDAnnCA As New CDArea

                        CDAnnCA.DLengths = DcaAr(j).DLengths
                        CDAnnCA.DWidth = DcaAr(j).DWidth
                        CDAnnCA.DHeight = DcaAr(j).DHeight
                        CDAnnCA.DStrtPt.x = DcaAr(j).DStrtPt.x
                        CDAnnCA.DStrtPt.y = DcaAr(j).DStrtPt.y
                        CDAnnCA.DStrtPt.z = DcaAr(j).DStrtPt.z

                        StR1n1CA.Ar = CDAnnCA
                        StR1n1CA.Method = IICA
                        StR1n1CA.ItmNm = DcaAri(j)

                        Dim LstmmmCA As New List(Of CDArea)

                        For Kk As Integer = 0 To CDLst.Count - 1
                            LstmmmCA.Add(CDLst(Kk))
                        Next

                        'Stop

                        StR1n1CA.R1CDLst = LstmmmCA

                        LstR1StArr.Add(StR1n1CA)

                        j += 1

                        'siSW.Close()


                        '//////////////////////////////////////































































                        'Stop

                    Loop



                    'Implements from here 13 July 2K8





                    'DQCA = ArtCA.DrmSubtractCA(DcaAr(j))          'Q = Art.Subtract(Ar(j))                'impliment

                End If



                '^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

                '******************************************************************************************
                'Direct:

                '                If flgNxtArg Then

                '                    DQCA = ArtCA.DrumSubtractDHD(DcaAr(j))

                '                End If

                'DHDQ = ArtCA.DrumSubtractDHD(DcaAr(j))          'Q = Art.Subtract(Ar(j))                'impliment

                '######  DQCA = ArtCA.DrumSubtractDHD(DcaAr(j))          'Q = Art.Subtract(Ar(j))                'impliment

                '8sd
                'DDStop

                Dim Dd As New CDArea

                If Not DQCA Is Nothing Then
                    If CDLst.Count = 0 Then
                        Do While Not DQCA.Count = 0

                            Dd = DQCA.Dequeue

                            CDLst.Add(Dd)

                        Loop
                    Else
                        Do While DQCA.Count > 0
                            ArbCA = DQCA.Dequeue
                            Ans1CA = False

                            'Stop

                            CDLst = DHDUnPush(CDLst, ArbCA) 'CDLst = UnPush(CDLst, Arb)         impliment

                            'Stop

                        Loop

                        'Stop

                    End If

                End If

                Dim Ans2 As Boolean

                For i As Integer = 0 To CDLst.Count - 1

                    Dim Arx As New CDArea

                    Arx = CDLst(i)

                    CDLst = DHVMrgX(CDLst, Arx, Ans2)       'CDLst = MrgX(CDLst, Arx, Ans2)             impliment

                    '9sd

                    'Stop

                    If Ans2 Then
                        Exit For
                    End If


                Next

                'Stop

                Dim StR1n1 As New StructR1

                Dim CDAnn As New CDArea

                CDAnn.DLengths = DcaAr(j).DLengths
                CDAnn.DWidth = DcaAr(j).DWidth
                CDAnn.DHeight = DcaAr(j).DHeight
                CDAnn.DStrtPt.x = DcaAr(j).DStrtPt.x
                CDAnn.DStrtPt.y = DcaAr(j).DStrtPt.y
                CDAnn.DStrtPt.z = DcaAr(j).DStrtPt.z

                StR1n1.Ar = CDAnn
                StR1n1.Method = IICA
                StR1n1.ItmNm = DcaAri(j)

                Dim Lstmmm As New List(Of CDArea)

                For Kk As Integer = 0 To CDLst.Count - 1
                    Lstmmm.Add(CDLst(Kk))
                Next

                'Stop

                'siSW.Close()


                StR1n1.R1CDLst = Lstmmm

                LstR1StArr.Add(StR1n1)

                j += 1


LP:
            Loop

            DItemQtyCA = ItrQty

            'Fff()

            '$$$$$
            'Stop
            '$$$$$

            If j > 0 Then
                E1StE2 = New StructE1
                E1StE2.Qty = DItemQtyCA
                E1StE2.ItmNm = DcaAri(j - 1)
            End If

            CDLstjCA = New List(Of CDArea)

            For jj As Integer = 0 To CDLst.Count - 1
                CDLstjCA.Add(CDLst(jj))
            Next

            E1StE2.E1StLst = CDLstjCA

            If DrawOpt Then
                'qtyarr.Add(E1StE2)
                DQtyArr.Add(E1StE2)
            End If

            DMaxQtyLstCA.Add(DItemQtyCA)

            'Form8.Close()
            TransactionsMenu.btnStatus.Visible = False
            TransactionsMenu.lblStatus.Visible = False

            Eventless()

            If UBound(DcaAr) >= j Then
                fullflag = True
            End If

            If FindQtyFlg Then
                CDLst.Clear()
                For i As Integer = 0 To CDLst.Count - 1                   ' impliment
                    If Not Drumchk1DHE(CDLst2CA(i), CDLst) Then
                        If Not Drumchk11DHE(CDLst2CA(i), CDLst) Then
                            CDLst.Add(CDLst2CA(i))
                        End If
                    End If
                Next
            End If

            If DrawOpt Then
                If UBound(DcaAri) <> -1 Then
                    TmpLstCA.Add(DcaAri(j - 1))
                    TmpLstCA.Add(CStr(TotArCA))
                    DAreaArrCA.Add(TmpLstCA)
                End If
            End If

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in DCrossStuff" & vbCrLf & "Data Stuffing failure!", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'Application.Exit()
        Finally

            connDrums.Close()
        End Try

        If DrawOpt Or DrawArc Then
        End If
        QtyFlgCA = True
        connDrums.Dispose()
        connDrums.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\Drums.mdb;Persist Security Info=False"
        connDrums.Open()

        Return CDLst

    End Function

    Public Function CADimnsAdd(ByVal x As Double, ByVal y As Double, ByVal z As Double, ByVal DH As Double, ByVal DR As Double)

        'Stop

        Try

            DCA.DCntPt.X = x + DR
            DCA.DCntPt.Y = y + DR
            DCA.DCntPt.Z = z + DR

            DCA.DmQty = ItrQty

            DCA.DStrtPt.x = x
            DCA.DStrtPt.y = y
            DCA.DStrtPt.z = z

            DCA.DLengths = y + (DR * 2)
            DCA.DWidth = x + (DR * 2)
            DCA.DHeight = z + (DR * 2)

            CDPt.DCntPt.X = DCA.DCntPt.X
            CDPt.DCntPt.Y = DCA.DCntPt.Y
            CDPt.DCntPt.Z = DCA.DCntPt.Z
            CDPt.DmQty = DCA.DmQty

            CDPt.DStrtPt.x = DCA.DStrtPt.x
            CDPt.DStrtPt.y = DCA.DStrtPt.y
            CDPt.DStrtPt.z = DCA.DStrtPt.z

            CDPt.DHeight = DH
            CDPt.DRadius = DR

            CDQCAer.Enqueue(CDPt)


        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in CADimnsAdd", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return CDQCAer

    End Function

    'Drum single grid row cross stuff arrangement

    Public Function DSgrCrossStuff(ByVal DcaArc As CDArea, ByVal DcaAr() As CDArea, ByVal DcaAri() As String, ByVal ArWt() As Single, ByVal SaveOpt As Boolean, ByVal ShowEmpty As Boolean, ByVal OutFile As String, ByVal DrawArc As Boolean, ByVal TranspArr() As Boolean, ByVal TopUp() As Boolean, ByVal TxtOpt As Boolean, ByVal DrawOpt As Boolean, ByVal FindQtyFlg As Boolean, ByVal ChngFlg As Boolean, ByVal ColArr As List(Of List(Of Byte))) As List(Of CDArea)

        'DDStop

        Dim CDLst2CA As New List(Of CDArea)
        Dim CDStkCA As New Stack(Of CDArea)
        Dim ArmCA As New List(Of Integer)
        Dim LstmCA As New List(Of CDArea)
        Dim TmpLstCA As New List(Of String)
        Dim CDLstjCA As New List(Of CDArea)

        Dim A1CA As New CDArea
        Dim A2CA As New CDArea

        Dim ArtCA As New CDArea
        Dim ArpCA As New CDArea
        Dim AreCA As New CDArea
        Dim AruCA As New CDArea
        Dim ArbCA As New CDArea

        Dim Arm1CA As Integer
        Dim IICA As Integer
        Dim TravalCA As Single

        Dim SzChgCA As Integer = 0

        Dim QtyFlgCA As Boolean = True
        Dim Ans1CA As Boolean

        Dim OrdrCA As Integer
        Dim ColCA As String
        Dim TotArCA As Double
        Dim OldItemQtyCA As Integer = 0

        'DDStop

        Try

            If SaveOpt Then
                configid = InputBox("Enter Config Id")
            End If

            Dim Ptx As New CDPoint

            Ptx.x = DcaArc.DLengths
            Ptx.y = DcaArc.DWidth
            Ptx.z = DcaArc.DHeight

            Dim Col1 As New List(Of Byte)
            Col1.Clear()
            Col1.Add(255)
            Col1.Add(255)
            Col1.Add(255)

            ColCA = "r"
            Dim ItmNm As String = ""

            If DrawArc Then
                Dim Ard1CA As New CDArea

                If DrawArc Then
                End If

                ArdCA.DStrtPt.x = DcaArc.DLengths
                ArdCA.DStrtPt.y = 0
                ArdCA.DStrtPt.z = 0
                ArdCA.DLengths = 0.5
                ArdCA.DWidth = DcaArc.DWidth
                ArdCA.DHeight = DcaArc.DHeight

                If DrawOpt Or DrawArc Then

                End If

                Ard1CA.DStrtPt.x = DcaArc.DLengths - 0.01
                Ard1CA.DStrtPt.y = 0
                Ard1CA.DStrtPt.z = 0
                Ard1CA.DLengths = 0.5
                Ard1CA.DWidth = ArdCA.DWidth
                Ard1CA.DHeight = ArdCA.DHeight
            End If

            If DrawOpt Or DrawArc Then
                Col1.Clear()
            End If

            If SaveOpt Then
                Cmd.Connection = connDrums
Repeat:

                Try
                    Cmd.ExecuteNonQuery()

                Catch Ex As Exception
                    If Ex.Message = "Cannot open any more tables." Then
                        connDrums.Close()
                        connDrums.Dispose()
                        OleDb.OleDbConnection.ReleaseObjectPool()
                        Cmd.Dispose()
                        GC.Collect()

                        connDrums.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\Drums.mdb;Persist Security Info=False"

                        connDrums.Open()
                        GoTo Repeat
                    End If
                End Try
                id1 += 1

            End If

            DcaArc.DStrtPt.x = 0
            DcaArc.DStrtPt.y = 0
            DcaArc.DStrtPt.z = 0

            Dim j As Integer = 0
            TotArCA = 0
            DAreaArrCA.Clear()
            For i As Integer = 0 To CDLst.Count - 1
                CDLst2CA.Add(CDLst(i))
            Next
            DItemQtyCA = 0
            DTotWtCA = 0
            If Not IsNothing(DcaAri) Then
                'Progress8.Show()
                TransactionsMenu.lblStatus.Visible = True
                If DrawOpt Then
                    Progress8.btnStatus.Visible = False
                    TransactionsMenu.btnStatus.Visible = False

                End If
                'Progress8.Focus()
                TransactionsMenu.lblStatus.Focus()
            End If

            For i As Integer = 0 To DQtyLstCA.Count - 1
                DPlcLstCA.Add(DQtyLstCA(i) - 1)
            Next

            fullflag = False
            OldItemQtyCA = 0
            Dim ImgName As String = "1"

            Do While Not CDLst.Count = 0 And j <= UBound(DcaAr)             'Starting the stuff placement loop
                'Stop
                If j > 0 Then
                    If DcaAri(j) <> DcaAri(j - 1) Then
                        ImgName = (CInt(ImgName) + 1).ToString
                    End If
                End If

                OrdrCA = 0

                If chkwt Then
                    DTotWtCA += ArWt(j)
                    If DTotWtCA >= contcap Then

                        AnsW = MsgBox("Maximum weight capacity of the container is reached" & vbCrLf & "Do you want to proceed?", MsgBoxStyle.YesNo)
                        If AnsW = MsgBoxResult.No Then
                            fullflag = True

                            Exit Do

                        Else
                            fullflag = False

                            chkwt = False
                        End If

                    End If
                End If

                '+++++++++++++++++++++++++++++++++++++

                If DrawOpt Then
                    If j > 0 Then

                        If DcaAri(j - 1) <> DcaAri(j) Then

                            DItemQtyCA = 0

                            If ColCA = "r" Then
                                ColCA = "g"
                            ElseIf ColCA = "g" Then
                                ColCA = "b"
                            ElseIf ColCA = "b" Then
                                ColCA = "m"
                            ElseIf ColCA = "m" Then
                                ColCA = "c"
                            ElseIf ColCA = "c" Then
                                ColCA = "y"
                            End If

                            SzChgCA += 1

                            QtyFlgCA = True

                        Else
                            QtyFlgCA = False
                        End If
                    End If
                End If

                If SzChgCA <> 2 Then

                Else

                End If

                'DDStop

                'The start manupulation of cross arrangement ***********************************************************

                Arm1CA = DFindOptCA(CDLst, DcaAr(j), TopUp(j))             'Arm1 = FindOpt(CDLst, Ar(j), TopUp(j))     impliment

                '2sd

                'From here impliment 24 june 2008

                'DDStop

                ArtCA = Nothing
                If Arm1CA <> -1 Then
                    ArtCA = CDLst(Arm1CA)
                End If

                Dim ArnCA As New List(Of Integer)
                Dim LstnCA As New List(Of CDArea)

                Dim B1 As New CDArea
                Dim B2 As New CDArea
                Dim Pos1 As Integer

                ArmCA = Nothing
                ArnCA = Nothing

                ArnCA = DrumFindCandidate1DHECA(CDLst, DcaAr(j), TopUp(j))          'Arn = FindCandidate1(CDLst, Ar(j), TopUp(j))           impliment
                '3sd

                'DDStop
                Pos1 = 0
                If Not ArnCA Is Nothing Then
                    Pos1 = 0
                Else

                    Dim Arxx As New CDArea

                    Arxx.DLengths = DcaAr(j).DWidth
                    Arxx.DWidth = DcaAr(j).DLengths
                    Arxx.DHeight = DcaAr(j).DHeight

                    ArnCA = DrumFindCandidate1DHECA(CDLst, DcaAr(j), TopUp(j))        'Arn = FindCandidate1(CDLst, Arxx, TopUp(j))            impliment

                    If Not ArnCA Is Nothing Then
                        Pos1 = 1
                    Else
                        If Not TopUp(j) Then
                            Arxx.DLengths = DcaAr(j).DLengths
                            Arxx.DWidth = DcaAr(j).DHeight
                            Arxx.DHeight = DcaAr(j).DWidth

                            ArnCA = DrumFindCandidate1DHECA(CDLst, DcaAr(j), TopUp(j))           'Arn = FindCandidate1(CDLst, Arxx, False)           impliment

                            If Not ArnCA Is Nothing Then
                                Pos1 = 2
                            End If
                        End If
                    End If
                End If
                'DDStop
                If ArnCA Is Nothing Then
                    'DDStop
                    ArmCA = DrumFindCandidateDHECA(DcaAr(j), CDLst)                    'Arm = FindCandidate(CDLst, Ar(j))              impliment
                    If Not ArmCA Is Nothing Then
                        If ArmCA(0) = Arm1CA Then ArmCA = Nothing
                    End If
                End If
                'DDStop

                If Not ArmCA Is Nothing Then

                    'Stop
                    LstmCA = DrumUnionItrPDHECA(CDLst(ArmCA(0)), CDLst(ArmCA(1)))             'Lstm = UnionItrP(CDLst(Arm(0)), CDLst(Arm(1)))         impliment
                    A1CA = LstmCA(0)
                    A2CA = LstmCA(1)
                End If

                If Not ArnCA Is Nothing Then

                    LstmCA = DrumUnionItrPDHECA(CDLst(ArmCA(0)), CDLst(ArmCA(1)))             'Lstm = UnionItrP(CDLst(Arn(0)), CDLst(Arn(1)))         impliment
                    B1 = LstmCA(0)
                    B2 = LstmCA(1)
                End If

                If ArmCA Is Nothing And Arm1CA = -1 Then
                    If DrawOpt Then

                    End If

                    For m As Integer = j To UBound(DcaAri) - 1
                        If DcaAri(m) <> DcaAri(j) Then
                            j = m

                            GoTo LP

                        End If
                    Next
                    j = UBound(DcaAri) + 1

                    GoTo LP

                Else
                    If ArnCA Is Nothing And Arm1CA = -1 Then
                        If DrawOpt Then

                        End If

                        For m As Integer = j To UBound(DcaAri) - 1
                            If DcaAri(m) <> DcaAri(j) Then
                                j = m
                                GoTo LP

                            End If
                        Next
                        j = UBound(DcaAri)

                    End If
                End If

                'DDStop

                If Not ArmCA Is Nothing Or Not ArnCA Is Nothing Then

                    Cmd.Connection = connDrums

                    DeleteTable("DTemp2")
DrmZz:
                    OrdrCA = 0
                    If Not ArmCA Is Nothing Then

                        DInsertTable("DTemp2", New Object() {CStr(A1CA.DStrtPt.x), CStr(A1CA.DStrtPt.y), CStr(A1CA.DStrtPt.z), CStr(1)})           'impliment
                    End If

                    If Not ArnCA Is Nothing Then
                        DInsertTable("DTemp2", New Object() {CStr(B1.DStrtPt.x), CStr(B1.DStrtPt.y), CStr(B1.DStrtPt.z), CStr(2)})           'impliment

                    End If

                    If Not ArtCA Is Nothing Then
                        DInsertTable("DTemp2", New Object() {CStr(ArtCA.DStrtPt.x), CStr(ArtCA.DStrtPt.y), CStr(ArtCA.DStrtPt.z), CStr(3)})        'impliment

                    End If

                    Dim RwCA As DataRow() = Nothing

                    Try
                        If Not ArmCA Is Nothing Then

                            RwCA = DGetf("DTemp2", "", "z DESC ,x ASC,y ASC")
                        End If

                        If Not ArnCA Is Nothing Then

                            RwCA = DGetf("DTemp2", "", "z DESC ,x ASC,y ASC")
                        End If

                        If ArnCA Is Nothing And ArmCA Is Nothing Then

                            RwCA = DGetf("DTemp2", "", "z DESC ,x ASC")
                        End If

                        If ArmCA Is Nothing And ArnCA Is Nothing Then

                            RwCA = DGetf("DTemp2", "", "z DESC ,x ASC,y ASC")
                        End If

                    Catch Err As Exception
                        MsgBox(Err.Message)
                        MsgBox(Err.ToString)
                        MessageBox.Show("Error in DCrossStuff" & vbCrLf & "Programme Running is failure!", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Finally
                        OrdrCA = RwCA(0)("i")
                    End Try

                    Stop

                    If OrdrCA = 3 Then
                        CDLst.RemoveAt(Arm1CA)
                    Else
                        If OrdrCA = 1 Then
                            ArtCA = A1CA
                            CDLst.RemoveAt(ArmCA(0))
                            If ArmCA(0) < ArmCA(1) Then
                                CDLst.RemoveAt(ArmCA(1) - 1)
                            Else
                                CDLst.RemoveAt(ArmCA(1))
                            End If

                            CDLst = DHDUnPush(CDLst, ArbCA) 'CDLst = UnPush(CDLst, A2)              impliment

                        End If
                        If OrdrCA = 2 Then
                            If Pos1 = 1 Then
                                Dim tmp As Double = DcaAr(j).DWidth
                                DcaAr(j).DWidth = DcaAr(j).DLengths
                                DcaAr(j).DLengths = tmp
                            End If

                            If Pos1 = 2 Then
                                Dim tmp As Double = DcaAr(j).DHeight
                                DcaAr(j).DHeight = DcaAr(j).DWidth
                                DcaAr(j).DWidth = tmp
                            End If

                            ArtCA = B1
                            CDLst.RemoveAt(ArnCA(0))
                            If ArnCA(0) < ArnCA(1) Then
                                CDLst.RemoveAt(ArnCA(1) - 1)
                            Else
                                CDLst.RemoveAt(ArnCA(1))
                            End If

                            CDLst.Add(B2)

                        End If
                        If OrdrCA = 3 Then
                            CDLst.RemoveAt(Arm1CA)
                        End If
                    End If
                Else

                    If Arm1CA <> -1 Then
                        CDLst.RemoveAt(Arm1CA)
                    End If
                End If

                Dim Qty As Integer
                If ChngFlg Then
                    '######
                    'DDStop
                    '########
                    IICA = DrumFindOptMethodDHECA(DcaAr(j), ArtCA, Qty, TopUp(j))               'II = FindOptMethod(Ar(j), Art, Qty, TopUp(j))          impliment

                    'DDStop

                    If DOcc > 1 Then

                        Dim OccLst1 As New List(Of Integer)

                        For i As Integer = 0 To DOccLstCA.Count - 1
                            OccLst1.Add(DOccLstCA(i))
                        Next

                        Dim Strctm1 As New StructOcc1

                        Strctm1.j = j
                        Strctm1.j1 = OccLst1
                        Strctm1.CDLstSt = CDLst
                        DOptLstCA.Add(Strctm1)
                    End If

                    Drmi.DLengths = DcaAr(j).DLengths
                    Drmi.DWidth = DcaAr(j).DWidth
                    Drmi.DHeight = DcaAr(j).DHeight

                    'ARcaDrm.DLengths = DcaAr(j).DLengths
                    'ARcaDrm.DWidth = DcaAr(j).DWidth
                    'ARcaDrm.DHeight = DcaAr(j).DHeight

                    'Dim Dln As Double = Ar(j).DLengths
                    'Dim Dwd As Double = Ar(j).DWidth
                    'Dim Dht As Double = Ar(j).DHeight

                    'Stop

                    Dim Nm As String = DcaAri(j)
                    Dim P As Integer = j

                    If IICA = 1 Then
                        DcaAr(P).DLengths = Drmi.DLengths      'Dln
                        DcaAr(P).DWidth = Drmi.DWidth          'Dwd
                        DcaAr(P).DHeight = Drmi.DHeight        'Dht

                    End If

                    If IICA = 2 Then
                        DcaAr(P).DLengths = Drmi.DLengths       'Dln
                        DcaAr(P).DWidth = Drmi.DWidth           'Dwd
                        DcaAr(P).DHeight = Drmi.DHeight         'Dht

                    End If

                    If IICA = 3 Then
                        DcaAr(P).DLengths = Drmi.DLengths        'Dln
                        DcaAr(P).DWidth = Drmi.DWidth            'Dwd
                        DcaAr(P).DHeight = Drmi.DHeight          'Dht

                    End If

                    If IICA = 4 Then
                        DcaAr(P).DLengths = Drmi.DLengths        'Dln
                        DcaAr(P).DWidth = Drmi.DWidth            'Dwd
                        DcaAr(P).DHeight = Drmi.DHeight          'Dht

                    End If

                    If IICA = 5 Then
                        DcaAr(P).DLengths = Drmi.DLengths         'Dln
                        DcaAr(P).DWidth = Drmi.DWidth             'Dwd
                        DcaAr(P).DHeight = Drmi.DHeight           'Dht

                    End If

                    If IICA = 6 Then
                        DcaAr(P).DLengths = Drmi.DLengths          'Dln
                        DcaAr(P).DWidth = Drmi.DWidth              'Dwd
                        DcaAr(P).DHeight = Drmi.DHeight            'Dht

                    End If

                End If

                Dim Flg As Boolean = Math.Abs(((DcaAr(j).DLengths * DcaAr(j).DWidth * DcaAr(j).DHeight) * Qty) - (ArtCA.DLengths * ArtCA.DWidth * ArtCA.DHeight)) < 0.01

                'Dim Mm As Integer = findqty(Ari, j)
                Drmi.DmQty = DrmQt.DFindQty(DcaAri, j)             'Use DCalcQty.dll 

                'DDStop

                If Drmi.DmQty >= Qty And Flg Then                         'If Mm >= Qty And Flg Then

                    If DrawOpt Then
                        If TranspArr(j) Then
                            TravalCA = 0.8
                        Else
                            TravalCA = 0
                        End If
                        DcaAr(j).DStrtPt.x = ArtCA.DStrtPt.x
                        DcaAr(j).DStrtPt.y = ArtCA.DStrtPt.y
                        DcaAr(j).DStrtPt.z = ArtCA.DStrtPt.z

                        'Remain as it is commented do not use
                        'Ar(j).AutoDraw(OutFile, Col, traval, "file:///c:/t2.png", Ari(j), ArWt(j), QtyFlg, TxtOpt, "", 0, True, "c")
                        j += Qty
                        DItemQtyCA += Qty
                    Else
                        j += Qty

                        DItemQtyCA += Qty
                        DPlcLstCA(DItemNoCA) = DItemQtyCA               'impliment
                        DTotWtCA += ArWt(j)
                        GoTo LP
                    End If

                End If

                ArmCA = Nothing
                ArnCA = Nothing

                DcaAr(j).DStrtPt.x = ArtCA.DStrtPt.x
                DcaAr(j).DStrtPt.y = ArtCA.DStrtPt.y
                DcaAr(j).DStrtPt.z = ArtCA.DStrtPt.z

                If SaveOpt Then

ML:
                    Try
                        Cmd.ExecuteNonQuery()
                    Catch ec As Exception
                        If ec.Message = "Cannot open any more tables." Then
                            connDrums.Close()
                            connDrums.Dispose()
                            OleDb.OleDbConnection.ReleaseObjectPool()
                            Cmd.Dispose()
                            GC.Collect()

                            connDrums.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\Drums.mdb;Persist Security Info=False"

                            connDrums.Open()
                            GoTo ML
                        End If

                    End Try
                    id1 += 1
                End If

                If DrawOpt Then

                    If TranspArr(j) Then
                        TravalCA = 0.8
                    Else
                        TravalCA = 0
                    End If
                End If
                If j = UBound(DcaAr) Then

                End If
                If DrawOpt Then
                    If j <> 0 Then
                        If DcaAri(j) <> DcaAri(j - 1) Then
                            TmpLstCA.Add(DcaAri(j - 1))
                            TmpLstCA.Add(CStr(TotArCA))
                            DAreaArrCA.Add(TmpLstCA)
                            TotArCA = 0
                            TotArCA = TotArCA + (DcaAr(j).DLengths * DcaAr(j).DWidth * DcaAr(j).DHeight)
                        Else
                            TotArCA = TotArCA + (DcaAr(j).DLengths * DcaAr(j).DWidth * DcaAr(j).DHeight)
                        End If
                    Else
                        TotArCA = TotArCA + (DcaAr(j).DLengths * DcaAr(j).DWidth * DcaAr(j).DHeight)
                    End If
                End If

                'Stop


                ''$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$ Old

                'DDiaL = Ar(j).DLengths
                'DDiaW = Ar(j).DWidth
                'DHt = Ar(j).DHeight

                'If DDiaL = DDiaW Then

                '    DDia = DDiaL
                '    DRds = DDia * 0.5
                'Else
                '    DDia = (DDiaL + DDiaW) * 0.5

                'End If

                ''$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
                'DDStop
                '$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$ New
                Dim Radius As Double = 0

                DDiaL = DcaAr(j).DLengths
                DDiaW = DcaAr(j).DWidth
                DRds = DcaAr(j).DRadius
                DHt = DcaAr(j).DHeight

                DpRds = DRds            'Previous value assign
                DpHt = DHt

                If DDiaL = DDiaW Then
                    DDia = DDiaL
                    Radius = DDia * 0.5
                    If Radius <> DRds Then
                        MessageBox.Show("The dimensioning adequacy in radius and diameter in cross arrangement", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If

                '$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

                'Stop

                'flgCAqt = False             'Initialise flag in cross arrangement

                If DrawOpt Then
                    TxtOpt = True

                    'Implement Here/ 20 April 2008 (old prototype development)
                    '5sd

                    'DDStop

                    'From here impliments 25 June 2008
                    'siSW.Close()
                    'If Not flgCAqt Then
                    'Ar(j).AutoDrawDrmCA(OutFile, ColCA, TravalCA, "s" & ImgName & ".png", Ari(j), ArWt(j), QtyFlgCA, TxtOpt, Ari(j), IICA, True, "b", DDia, DRds, DHt)         'impliment

                    DcaAr(j).AutoDrawDrmCA(OutFile, ColCA, TravalCA, "s" & ImgName & ".png", DcaAri(j), ArWt(j), QtyFlgCA, TxtOpt, DcaAri(j), IICA, True, "b", DDia, DRds, DHt)

                    'Else
                    'GoTo OutLp
                    'End If

                    If FlgCA Then
                        'GoTo CrossArngmtx
                        'Stop
                        'MsgBox("Continue")

                        ' siSW.Close()

                        'DDStop

                        'From here impliment 1 July 2008 for second row of grid

                        'Impliment inside routine for first row iteam grid row placed make it and then check grid row and second iteam placedby using generic type database here from 28 June 2008

                        If Not flgCAqt Then

                            'DDStop

                            DbCrsStuff(OutFile, ColCA, TravalCA, "s" & ImgName & ".png", DcaAri(j), ArWt(j), QtyFlgCA, TxtOpt, DcaAri(j), IICA, True, "b", DDia, DRds, DHt)

                        Else

                            '%%%%%%%%%%%%%%%%%%%%%%%%%

                            If flgCAqt Then

                                Do While Not CDQCAer.Count = 0

                                    DCA = CDQCAer.Dequeue
                                    CDLst.Add(DCA)

                                Loop
                                Return CDLst
                            End If

                            'DDStop

                            '%%%%%%%%%%%%%%%%%%%%%%%%%

                            GoTo OutLp

                        End If

                        If Not flgCAqt Then

                            'DDStop

                            CDQCAer = DPlaceCA(OutFile, ColCA, TravalCA, "s" & ImgName & ".png", DcaAri(j), ArWt(j), QtyFlgCA, TxtOpt, DcaAri(j), IICA, True, "b", DDia, DRds, DHt)

                            'DDStop

                        Else

                            '%%%%%%%%%%%%%%%%%%%%%%%%%

                            If flgCAqt Then

                                Do While Not CDQCAer.Count = 0

                                    DCA = CDQCAer.Dequeue
                                    CDLst.Add(DCA)

                                Loop
                                Return CDLst
                            End If

                            'DDStop

                            '%%%%%%%%%%%%%%%%%%%%%%%%%

                            GoTo outlp

                        End If

                        If Not flgCAqt Then

                            'DDStop

                            CDQCAer = DArgmtNxt(OutFile, ColCA, TravalCA, "s" & ImgName & ".png", DcaAri(j), ArWt(j), QtyFlgCA, TxtOpt, DcaAri(j), IICA, True, "b", DDia, DRds, DHt)

                            'DDStop

                        Else

                            '%%%%%%%%%%%%%%%%%%%%%%%%%

                            If flgCAqt Then

                                Do While Not CDQCAer.Count = 0

                                    DCA = CDQCAer.Dequeue
                                    CDLst.Add(DCA)

                                Loop
                                Return CDLst
                            End If

                            'DDStop

                            '%%%%%%%%%%%%%%%%%%%%%%%%%

                            GoTo OutLp

                        End If

                        'DCArngmt = True

                        'Stop

                        '%%%%%%%%%%%%%%%%%%%%%%%%%

                        If flgCAqt Then

                            Do While Not CDQCAer.Count = 0

                                DCA = CDQCAer.Dequeue
                                CDLst.Add(DCA)

                            Loop

                            Return CDLst

                            Stop

                        End If

                        'Stop

                        '%%%%%%%%%%%%%%%%%%%%%%%%%

                        Exit Try

                        'Stop

                        'connDrums.Close()
                        'siSW.Close()

                    End If

                    'DDStop
                    'DCA = CDQCAer.Dequeue
                    'CDLst.Add(DCA)
                    'DDStop

                    '*****************************************************************************
                    If DQtyLstCA.Count > 0 Then
                        DPlcLstCA(DrmRWidx) = DItemQtyCA

                    End If

                    DItemQtyCA += 1

                Else
                    DItemQtyCA += 1
                    DTotWtCA += ArWt(j)
                End If

                'DDStop

                If Not IsNothing(DcaAri) Then

                    '*********************************************
                    ' Do While Not Q.Count = 0
                    'Dd = Q.Dequeue
                    'CDLst.Add(Dd)
                    'Loop                   
                    'Dim Dot As String = "....."
                    If DItemQtyCA = 12 Then

                        'Stop
                        'siSW.Close()

                    End If

                    'siSW.Close()

                    DCountCSQ(ItrQty)       'ItemQty)              'Count Cross stuffed Quantity              impliment

                    'DDStop

                    'Progress8.i = ItemQty
                    'TransactionsMenu.lblStatus.Text = " Please wait " & CStr(Dot) & ""
                    'TransactionsMenu.lblStatus.Text = " Numbers ::   " & CStr(ItemQty) & "    -> Items stuffed"
                    'TransactionsMenu.lblStatus.Text = "Cross stuff arrangement in progress :: " & CStr(ItemQty) & Chr(13) & vbCr & "       Please wait ....."
                    'TransactionsMenu.btnStatus.Visible = True

                    'Eventful()

                    'TransactionsMenu.lblStatus.Refresh()
                    'System.Windows.Forms.Application.DoEvents()

                    'Impliment from here 30 June 2008 

                    '*********************************************
                    '7sd
                    'DDStop

                    'siSW.Close()

                    If exflg Then
                        exflg = False
                        GoTo LP
                    End If
                End If

                'CrossArngmtx:
                'If FlgCA Then
                'siSW.Close()
                'Stop
                'siSW.Close()
                'Q = Art.SubtractCA(Ar(j))
                'Return CDLst
                'Exit Function
                'End If

OutLp:

                'DDStop

                'Impliment here just add values inside the the CDLst.Add()

                '******************************************************************************************

                If flgCAqt Then

                    'If flgCAqt Then

                    '    Do While Not CDQCAer.Count = 0

                    '        DCA = CDQCAer.Dequeue

                    '        CDLst.Add(DCA)

                    '        'Stop

                    '    Loop

                    '    Stop

                    '    flgCAqt = False

                    'End If

                    'DCA = CDQCAer.Dequeue

                    'CDLst.Add(DCA)

                    'DDStop

                Else

                    DQCA = ArtCA.DrumSubtractDHD(DcaAr(j))          'Q = Art.Subtract(Ar(j))                'impliment

                End If



                '******************************************************************************************

                'DHDQ = ArtCA.DrumSubtractDHD(DcaAr(j))          'Q = Art.Subtract(Ar(j))                'impliment

                '######  DQCA = ArtCA.DrumSubtractDHD(DcaAr(j))          'Q = Art.Subtract(Ar(j))                'impliment

                '8sd
                'DDStop

                Dim Dd As New CDArea
                If Not DQCA Is Nothing Then
                    If CDLst.Count = 0 Then
                        Do While Not DQCA.Count = 0

                            Dd = DQCA.Dequeue

                            CDLst.Add(Dd)

                        Loop
                    Else
                        Do While DQCA.Count > 0
                            ArbCA = DQCA.Dequeue
                            Ans1CA = False

                            CDLst = DHDUnPush(CDLst, ArbCA) 'CDLst = UnPush(CDLst, Arb)         impliment

                        Loop

                    End If

                End If

                Dim Ans2 As Boolean

                For i As Integer = 0 To CDLst.Count - 1

                    Dim Arx As New CDArea

                    Arx = CDLst(i)

                    CDLst = DHVMrgX(CDLst, Arx, Ans2)       'CDLst = MrgX(CDLst, Arx, Ans2)             impliment

                    '9sd
                    'DDStop

                    If Ans2 Then
                        Exit For
                    End If


                Next

                'DDStop

                Dim StR1n1 As New StructR1

                Dim CDAnn As New CDArea

                CDAnn.DLengths = DcaAr(j).DLengths
                CDAnn.DWidth = DcaAr(j).DWidth
                CDAnn.DHeight = DcaAr(j).DHeight
                CDAnn.DStrtPt.x = DcaAr(j).DStrtPt.x
                CDAnn.DStrtPt.y = DcaAr(j).DStrtPt.y
                CDAnn.DStrtPt.z = DcaAr(j).DStrtPt.z

                StR1n1.Ar = CDAnn
                StR1n1.Method = IICA
                StR1n1.ItmNm = DcaAri(j)

                Dim Lstmmm As New List(Of CDArea)

                For Kk As Integer = 0 To CDLst.Count - 1
                    Lstmmm.Add(CDLst(Kk))
                Next

                StR1n1.R1CDLst = Lstmmm

                LstR1StArr.Add(StR1n1)

                j += 1


LP:
            Loop

            DItemQtyCA = ItrQty

            'Fff()

            '$$$$$
            'Stop
            '$$$$$
            If j > 0 Then
                E1StE2 = New StructE1
                E1StE2.Qty = DItemQtyCA
                E1StE2.ItmNm = DcaAri(j - 1)
            End If

            CDLstjCA = New List(Of CDArea)
            For jj As Integer = 0 To CDLst.Count - 1
                CDLstjCA.Add(CDLst(jj))
            Next
            E1StE2.E1StLst = CDLstjCA
            If DrawOpt Then
                'QtyArr.Add(E1StE2)             impliment
            End If
            DMaxQtyLstCA.Add(DItemQtyCA)

            'Form8.Close()
            TransactionsMenu.btnStatus.Visible = False
            TransactionsMenu.lblStatus.Visible = False

            Eventless()

            If UBound(DcaAr) >= j Then
                fullflag = True
            End If

            If FindQtyFlg Then
                CDLst.Clear()
                For i As Integer = 0 To CDLst.Count - 1                   ' impliment
                    If Not Drumchk1DHE(CDLst2CA(i), CDLst) Then
                        If Not Drumchk11DHE(CDLst2CA(i), CDLst) Then
                            CDLst.Add(CDLst2CA(i))
                        End If
                    End If
                Next
            End If

            If DrawOpt Then
                If UBound(DcaAri) <> -1 Then
                    TmpLstCA.Add(DcaAri(j - 1))
                    TmpLstCA.Add(CStr(TotArCA))
                    DAreaArrCA.Add(TmpLstCA)
                End If
            End If

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in DCrossStuff" & vbCrLf & "Data Stuffing failure!", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'Application.Exit()
        Finally

            connDrums.Close()
        End Try

        If DrawOpt Or DrawArc Then
        End If
        QtyFlgCA = True
        connDrums.Dispose()
        connDrums.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\Drums.mdb;Persist Security Info=False"
        connDrums.Open()

        Return CDLst

    End Function

    'Drum multiple grid cross stuff arrangement

    Public Function DNxtgrCrossStuff(ByVal DcaArc As CDArea, ByVal DcaAr() As CDArea, ByVal DcaAri() As String, ByVal ArWt() As Single, ByVal SaveOpt As Boolean, ByVal ShowEmpty As Boolean, ByVal OutFile As String, ByVal DrawArc As Boolean, ByVal TranspArr() As Boolean, ByVal TopUp() As Boolean, ByVal TxtOpt As Boolean, ByVal DrawOpt As Boolean, ByVal FindQtyFlg As Boolean, ByVal ChngFlg As Boolean, ByVal ColArr As List(Of List(Of Byte))) As List(Of CDArea)

        'DDDStop
        Try

            'CDLst = DSgrCrossStuff(DcaArc, DcaAr, DcaAri, ArWt, SaveOpt, ShowEmpty, OutFile, DrawArc, TranspArr, TopUp, TxtOpt, DrawOpt, FindQtyFlg, ChngFlg, ColArr)

            CDLst = DrmCrsStuffArngmt(DcaArc, DcaAr, DcaAri, ArWt, SaveOpt, ShowEmpty, OutFile, DrawArc, TranspArr, TopUp, TxtOpt, DrawOpt, FindQtyFlg, ChngFlg, ColArr)

            'DDDStop

            'siSW.Close()



        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in DNxtgrCrossStuff", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return CDLst

    End Function

    'Drum multiple grid cross stuff arrangement

    Public Function DMgrCrossStuff(ByVal DcaArc As CDArea, ByVal DcaAr() As CDArea, ByVal DcaAri() As String, ByVal ArWt() As Single, ByVal SaveOpt As Boolean, ByVal ShowEmpty As Boolean, ByVal OutFile As String, ByVal DrawArc As Boolean, ByVal TranspArr() As Boolean, ByVal TopUp() As Boolean, ByVal TxtOpt As Boolean, ByVal DrawOpt As Boolean, ByVal FindQtyFlg As Boolean, ByVal ChngFlg As Boolean, ByVal ColArr As List(Of List(Of Byte))) As List(Of CDArea)

        Stop

        'Impliments here from 3 July 2K8

        'Dim DCAqt As New List(Of CDArea)
        Try

            Try

                'CDLst = DSgrCrossStuff(DcaArc, DcaAr, DcaAri, ArWt, SaveOpt, ShowEmpty, OutFile, DrawArc, TranspArr, TopUp, TxtOpt, DrawOpt, FindQtyFlg, ChngFlg, ColArr)

                CDLst = DCrossStuffArngmt(DcaArc, DcaAr, DcaAri, ArWt, SaveOpt, ShowEmpty, OutFile, DrawArc, TranspArr, TopUp, TxtOpt, DrawOpt, FindQtyFlg, ChngFlg, ColArr)

                Stop

                'siSW.Close()


                Dim Dcpt As New CDrum                          'Last position of drum value assigns 

                Dcpt.DStrtPt.x = DCA.DStrtPt.x
                Dcpt.DStrtPt.y = DCA.DStrtPt.y
                Dcpt.DStrtPt.z = DCA.DStrtPt.z

                Dcpt.DCntPt.X = DCA.DStrtPt.x
                Dcpt.DCntPt.Y = DCA.DStrtPt.y
                Dcpt.DCntPt.Z = DCA.DStrtPt.z

                Dcpt.DmQty = DCA.DmQty

                Dim x As Double = DCA.DStrtPt.x
                Dim y As Double = DCA.DStrtPt.y
                Dim z As Double = DCA.DStrtPt.z

                Dim DnApt As New CDArea

                DnApt.DStrtPt.x = DCA.DStrtPt.x
                DnApt.DStrtPt.y = DCA.DStrtPt.y
                DnApt.DStrtPt.z = DCA.DStrtPt.z

                DnApt.DCntPt.X = DCA.DStrtPt.x
                DnApt.DCntPt.Y = DCA.DStrtPt.y
                DnApt.DCntPt.Z = DCA.DStrtPt.z


                'DnApt.DHeight = DArCA.DHeight
                'DnApt.DLengths = DArCA.DLengths
                'DnApt.DWidth = DArCA.DWidth


                'Stop


                'DnApt.DrmNextIArgStrt(DnApt, DnApt)


                'Stop



                'siSW.Close()

                Stop



                Dim CDLstCA As Queue(Of List(Of CDArea)) = Nothing

                'Do While Not CDLst.Count - 3 = 0
                '    'Dim DNos As Integer = DcaAr.Length()

                '    If CDLst.Count > 0 Then
                '        If DcaAr.Length() Then

                '        End If
                '    End If
                'Loop



                Stop


                Dim DArCA As New CDrum

                '*********************************************************************************************
                Dim j As Integer = Dcpt.DmQty + 1

                Dim DNos As Integer = DcaAr.Length()

                Dim dB As New CDArea

                If DNos > Dcpt.DmQty Then                      'If Drmi.DmQty >= Qty And Flg Then                         'If Mm >= Qty And Flg Then

                    DArCA.DHeight = DcaAr(j).DHeight
                    DArCA.DLengths = DcaAr(j).DLengths
                    DArCA.DWidth = DcaAr(j).DWidth

                    dB.DHeight = DArCA.DHeight                   'DnApt.DHeight = DArCA.DHeight
                    dB.DLengths = DArCA.DLengths                 'DnApt.DLengths = DArCA.DLengths
                    dB.DWidth = DArCA.DWidth                     'DnApt.DWidth = DArCA.DWidth

                    DnApt.DLengths = DcaArc.DLengths - DnApt.DStrtPt.y          'Reamining container present LWH calculated
                    DnApt.DWidth = DcaArc.DWidth - DnApt.DStrtPt.x
                    DnApt.DHeight = DcaArc.DHeight - DnApt.DStrtPt.z

                End If

                '*****************************************************************

                Dim DImgName As String = "1"

                'Do While Not CDLst.Count = 0 And j <= UBound(DcaAr)             'Starting the stuff placement loop
                'Stop
                If j > 0 Then
                    If DcaAri(j) <> DcaAri(j - 1) Then
                        DImgName = (CInt(DImgName) + 1).ToString
                    End If
                End If

                Dim QtyFlgCA As Boolean = True

                Dim K As Integer = Dcpt.DmQty + 1

                Dim DColCA As String = "b"

                If DrawOpt Then
                    If K > 0 Then

                        If DcaAri(K - 1) <> DcaAri(K) Then

                            If DColCA = "r" Then
                                DColCA = "g"
                            ElseIf DColCA = "g" Then
                                DColCA = "b"
                            ElseIf DColCA = "b" Then
                                DColCA = "m"
                            ElseIf DColCA = "m" Then
                                DColCA = "c"
                            ElseIf DColCA = "c" Then
                                DColCA = "y"
                            End If
                            QtyFlgCA = True
                        Else
                            QtyFlgCA = False
                        End If
                    End If
                End If


                '*****************************************************************
                '####################################################################

                Dim ArItm() As CDArea
                Dim Ari2() As String
                Dim Arwt2() As Single
                Dim TranspArr2() As Boolean

                ReDim ArItm(0)
                ReDim Ari2(0)
                ReDim Arwt2(0)
                ReDim TranspArr2(0)

                'DStop
                Dim L As Integer = Dcpt.DmQty + 1

                For M As Integer = Dcpt.DmQty + 1 To DNos - 1

                    ArItm(UBound(ArItm)) = DcaAr(M)
                    Ari2(UBound(Ari2)) = DcaAri(M)
                    Arwt2(UBound(Arwt2)) = ArWt(M)
                    TranspArr2(UBound(TranspArr2)) = TranspArr(M)

                    ReDim Preserve ArItm(UBound(ArItm) + 1)
                    ReDim Preserve Ari2(UBound(Ari2) + 1)
                    ReDim Preserve Arwt2(UBound(Arwt2) + 1)
                    ReDim Preserve TranspArr2(UBound(TranspArr2) + 1)
                    ReDim Preserve TopUp(UBound(TopUp) + 1)
                Next

                ReDim Preserve ArItm(UBound(ArItm) - 1)
                ReDim Preserve Ari2(UBound(Ari2) - 1)
                ReDim Preserve Arwt2(UBound(Arwt2) - 1)
                ReDim Preserve TranspArr2(UBound(TranspArr2) - 1)




                'Stop


                'ArItm(j).DrmNextIArgStrt(DnApt, DnApt)


                'Stop


                Stop

                '9 July 2K8 Implements here 

                'DnApt.DrmNextIArgStrt(DnApt, dB)


                Stop



                '    If DrawOpt Then
                '        If TranspArr(j) Then
                '            TravalCA = 0.8
                '        Else
                '            TravalCA = 0
                '        End If
                '        DcaAr(j).DStrtPt.x = ArtCA.DStrtPt.x
                '        DcaAr(j).DStrtPt.y = ArtCA.DStrtPt.y
                '        DcaAr(j).DStrtPt.z = ArtCA.DStrtPt.z

                '        'Remain as it is commented do not use
                '        'Ar(j).AutoDraw(OutFile, Col, traval, "file:///c:/t2.png", Ari(j), ArWt(j), QtyFlg, TxtOpt, "", 0, True, "c")
                '        j += Qty
                '        DItemQtyCA += Qty
                '    Else
                '        j += Qty

                '        DItemQtyCA += Qty
                '        DPlcLstCA(DItemNoCA) = DItemQtyCA               'impliment
                '        DTotWtCA += ArWt(j)
                '        GoTo LP
                '    End If

                'End If

                '*********************************************************************************************


                '        Dim CDLst2CA As New List(Of CDArea)
                '        Dim CDStkCA As New Stack(Of CDArea)
                Dim ArmCA As New List(Of Integer)
                Dim LstmCA As New List(Of CDArea)
                '        Dim TmpLstCA As New List(Of String)
                '        Dim CDLstjCA As New List(Of CDArea)

                Dim A1CA As New CDArea
                Dim A2CA As New CDArea

                Dim ArtCA As New CDArea
                '        Dim ArpCA As New CDArea
                '        Dim AreCA As New CDArea
                '        Dim AruCA As New CDArea
                '        Dim ArbCA As New CDArea

                Dim Arm1CA As Integer
                Dim IICAn As Integer
                Dim TravalCA As Single

                '        Dim SzChgCA As Integer = 0

                '        Dim QtyFlgCA As Boolean = True
                '        'Dim Ans1CA As Boolean

                '        Dim OrdrCA As Integer
                '        Dim ColCA As String
                '        Dim TotArCA As Double
                '        Dim OldItemQtyCA As Integer = 0

                '        Stop

                '        'MessageBox.Show(" Cross arrangement in single row done! ")


                '        'Impliments here from 3 July 2K8

                '        'Try

                '        '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

                '        If SaveOpt Then
                '            configid = InputBox("Enter Config Id")
                '        End If

                '        Dim Ptx As New CDPoint

                '        Ptx.x = DcaArc.DLengths
                '        Ptx.y = DcaArc.DWidth
                '        Ptx.z = DcaArc.DHeight

                '        Dim Col1 As New List(Of Byte)
                '        Col1.Clear()
                '        Col1.Add(255)
                '        Col1.Add(255)
                '        Col1.Add(255)

                '        ColCA = "r"
                '        Dim ItmNm As String = ""

                '        If DrawArc Then
                '            Dim Ard1CA As New CDArea

                '            If DrawArc Then
                '            End If

                '            ArdCA.DStrtPt.x = DcaArc.DLengths
                '            ArdCA.DStrtPt.y = 0
                '            ArdCA.DStrtPt.z = 0
                '            ArdCA.DLengths = 0.5
                '            ArdCA.DWidth = DcaArc.DWidth
                '            ArdCA.DHeight = DcaArc.DHeight

                '            If DrawOpt Or DrawArc Then

                '            End If

                '            Ard1CA.DStrtPt.x = DcaArc.DLengths - 0.01
                '            Ard1CA.DStrtPt.y = 0
                '            Ard1CA.DStrtPt.z = 0
                '            Ard1CA.DLengths = 0.5
                '            Ard1CA.DWidth = ArdCA.DWidth
                '            Ard1CA.DHeight = ArdCA.DHeight
                '        End If

                '        If DrawOpt Or DrawArc Then
                '            Col1.Clear()
                '        End If

                '        If SaveOpt Then
                '            Cmd.Connection = connDrums
                'Repeat:

                '            Try
                '                Cmd.ExecuteNonQuery()

                '            Catch Ex As Exception
                '                If Ex.Message = "Cannot open any more tables." Then
                '                    connDrums.Close()
                '                    connDrums.Dispose()
                '                    OleDb.OleDbConnection.ReleaseObjectPool()
                '                    Cmd.Dispose()
                '                    GC.Collect()

                '                    connDrums.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\Drums.mdb;Persist Security Info=False"

                '                    connDrums.Open()
                '                    GoTo Repeat
                '                End If
                '            End Try
                '            id1 += 1

                '        End If

                '        DcaArc.DStrtPt.x = 0
                '        DcaArc.DStrtPt.y = 0
                '        DcaArc.DStrtPt.z = 0

                '        Dim j As Integer = 0
                '        TotArCA = 0
                '        DAreaArrCA.Clear()
                '        For i As Integer = 0 To CDLst.Count - 1
                '            CDLst2CA.Add(CDLst(i))
                '        Next
                '        DItemQtyCA = 0
                '        DTotWtCA = 0
                '        If Not IsNothing(DcaAri) Then
                '            'Progress8.Show()
                '            TransactionsMenu.lblStatus.Visible = True
                '            If DrawOpt Then
                '                Progress8.btnStatus.Visible = False
                '                TransactionsMenu.btnStatus.Visible = False

                '            End If
                '            'Progress8.Focus()
                '            TransactionsMenu.lblStatus.Focus()
                '        End If

                '        For i As Integer = 0 To DQtyLstCA.Count - 1
                '            DPlcLstCA.Add(DQtyLstCA(i) - 1)
                '        Next

                '        fullflag = False
                '        OldItemQtyCA = 0
                '        Dim ImgName As String = "1"

                '        'Do While Not CDLst.Count = 0 And j <= UBound(DcaAr)             'Starting the stuff placement loop
                '        Stop
                '        If j > 0 Then
                '            If DcaAri(j) <> DcaAri(j - 1) Then
                '                ImgName = (CInt(ImgName) + 1).ToString
                '            End If
                '        End If

                '        OrdrCA = 0

                '        If chkwt Then
                '            DTotWtCA += ArWt(j)
                '            If DTotWtCA >= contcap Then

                '                AnsW = MsgBox("Maximum weight capacity of the container is reached" & vbCrLf & "Do you want to proceed?", MsgBoxStyle.YesNo)
                '                If AnsW = MsgBoxResult.No Then
                '                    fullflag = True

                '                    'Exit Do

                '                Else

                '                    fullflag = False
                '                    chkwt = False

                '                End If

                '            End If
                '        End If

                '        '+++++++++++++++++++++++++++++++++++++

                '        If DrawOpt Then
                '            If j > 0 Then

                '                If DcaAri(j - 1) <> DcaAri(j) Then

                '                    DItemQtyCA = 0

                '                    If ColCA = "r" Then
                '                        ColCA = "g"
                '                    ElseIf ColCA = "g" Then
                '                        ColCA = "b"
                '                    ElseIf ColCA = "b" Then
                '                        ColCA = "m"
                '                    ElseIf ColCA = "m" Then
                '                        ColCA = "c"
                '                    ElseIf ColCA = "c" Then
                '                        ColCA = "y"
                '                    End If

                '                    SzChgCA += 1

                '                    QtyFlgCA = True

                '                Else
                '                    QtyFlgCA = False
                '                End If
                '            End If
                '        End If

                '        If SzChgCA <> 2 Then

                '        Else

                '        End If

                '        Stop

                '        'The start manupulation of cross arrangement ***********************************************************

                '######################
                'Stop
                '######################

                'siSW.Close()


                'Arm1CA = DFindOptCA(CDLst, DcaAr(j), TopUp(j))             'Arm1 = FindOpt(CDLst, Ar(j), TopUp(j))     impliment

                '######################
                'Stop
                '######################

                '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

                'From here impliment 24 june 2008

                'DDStop

                ArtCA = Nothing
                If Arm1CA <> -1 Then
                    ArtCA = CDLst(Arm1CA)
                End If

                Dim ArnCA As New List(Of Integer)
                Dim LstnCA As New List(Of CDArea)

                Dim B1 As New CDArea
                Dim B2 As New CDArea
                Dim Pos1 As Integer

                ArmCA = Nothing
                ArnCA = Nothing

                Stop

                '^ ArnCA = DrumFindCandidate1DHECA(CDLst, DcaAr(j), TopUp(j))          'Arn = FindCandidate1(CDLst, Ar(j), TopUp(j))           impliment

                Stop



                Pos1 = 0
                If Not ArnCA Is Nothing Then
                    Pos1 = 0
                Else

                    Dim Arxx As New CDArea

                    Arxx.DLengths = DcaAr(j).DWidth
                    Arxx.DWidth = DcaAr(j).DLengths
                    Arxx.DHeight = DcaAr(j).DHeight

                    Stop

                    '^ ArnCA = DrumFindCandidate1DHECA(CDLst, DcaAr(j), TopUp(j))        'Arn = FindCandidate1(CDLst, Arxx, TopUp(j))            impliment

                    Stop

                    If Not ArnCA Is Nothing Then
                        Pos1 = 1
                    Else
                        If Not TopUp(j) Then
                            Arxx.DLengths = DcaAr(j).DLengths
                            Arxx.DWidth = DcaAr(j).DHeight
                            Arxx.DHeight = DcaAr(j).DWidth

                            Stop

                            '^ ArnCA = DrumFindCandidate1DHECA(CDLst, DcaAr(j), TopUp(j))           'Arn = FindCandidate1(CDLst, Arxx, False)           impliment

                            Stop

                            If Not ArnCA Is Nothing Then
                                Pos1 = 2
                            End If
                        End If
                    End If
                End If
                Stop
                If ArnCA Is Nothing Then
                    Stop
                    'ArmCA = DrumFindCandidateDHECA(DcaAr(j), CDLst)                    'Arm = FindCandidate(CDLst, Ar(j))              impliment
                    If Not ArmCA Is Nothing Then
                        If ArmCA(0) = Arm1CA Then ArmCA = Nothing
                    End If
                End If
                Stop

                If Not ArmCA Is Nothing Then

                    Stop
                    'LstmCA = DrumUnionItrPDHECA(CDLst(ArmCA(0)), CDLst(ArmCA(1)))             'Lstm = UnionItrP(CDLst(Arm(0)), CDLst(Arm(1)))         impliment
                    A1CA = LstmCA(0)
                    A2CA = LstmCA(1)
                End If

                If Not ArnCA Is Nothing Then

                    'LstmCA = DrumUnionItrPDHECA(CDLst(ArmCA(0)), CDLst(ArmCA(1)))             'Lstm = UnionItrP(CDLst(Arn(0)), CDLst(Arn(1)))         impliment
                    B1 = LstmCA(0)
                    B2 = LstmCA(1)
                End If

                If ArmCA Is Nothing And Arm1CA = -1 Then
                    If DrawOpt Then

                    End If

                    For m As Integer = j To UBound(DcaAri) - 1
                        If DcaAri(m) <> DcaAri(j) Then
                            j = m

                            GoTo LP

                        End If
                    Next
                    j = UBound(DcaAri) + 1

                    GoTo LP

                Else
                    If ArnCA Is Nothing And Arm1CA = -1 Then
                        If DrawOpt Then

                        End If

                        For m As Integer = j To UBound(DcaAri) - 1
                            If DcaAri(m) <> DcaAri(j) Then
                                j = m
                                GoTo LP

                            End If
                        Next
                        j = UBound(DcaAri)

                    End If
                End If

                Stop

                If Not ArmCA Is Nothing Or Not ArnCA Is Nothing Then

                    Cmd.Connection = connDrums

                    DeleteTable("DTemp2")
DrmZz:
                    'OrdrCA = 0
                    If Not ArmCA Is Nothing Then

                        DInsertTable("DTemp2", New Object() {CStr(A1CA.DStrtPt.x), CStr(A1CA.DStrtPt.y), CStr(A1CA.DStrtPt.z), CStr(1)})           'impliment
                    End If

                    If Not ArnCA Is Nothing Then
                        DInsertTable("DTemp2", New Object() {CStr(B1.DStrtPt.x), CStr(B1.DStrtPt.y), CStr(B1.DStrtPt.z), CStr(2)})           'impliment

                    End If

                    If Not ArtCA Is Nothing Then
                        DInsertTable("DTemp2", New Object() {CStr(ArtCA.DStrtPt.x), CStr(ArtCA.DStrtPt.y), CStr(ArtCA.DStrtPt.z), CStr(3)})        'impliment

                    End If

                    Dim RwCA As DataRow() = Nothing

                    Try
                        If Not ArmCA Is Nothing Then

                            RwCA = DGetf("DTemp2", "", "z DESC ,x ASC,y ASC")
                        End If

                        If Not ArnCA Is Nothing Then

                            RwCA = DGetf("DTemp2", "", "z DESC ,x ASC,y ASC")
                        End If

                        If ArnCA Is Nothing And ArmCA Is Nothing Then

                            RwCA = DGetf("DTemp2", "", "z DESC ,x ASC")
                        End If

                        If ArmCA Is Nothing And ArnCA Is Nothing Then

                            RwCA = DGetf("DTemp2", "", "z DESC ,x ASC,y ASC")
                        End If

                    Catch Err As Exception
                        MsgBox(Err.Message)
                        MsgBox(Err.ToString)
                        MessageBox.Show("Error in DCrossStuff" & vbCrLf & "Programme Running is failure!", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Finally
                        'OrdrCA = RwCA(0)("i")
                    End Try

                    Stop

                    'If OrdrCA = 3 Then
                    '    CDLst.RemoveAt(Arm1CA)
                    'Else
                    '    'If OrdrCA = 1 Then
                    '    '    ArtCA = A1CA
                    '    '    CDLst.RemoveAt(ArmCA(0))
                    '    '    If ArmCA(0) < ArmCA(1) Then
                    '    '        CDLst.RemoveAt(ArmCA(1) - 1)
                    '    '    Else
                    '    '        CDLst.RemoveAt(ArmCA(1))
                    '    '    End If

                    '    '    'CDLst = DHDUnPush(CDLst, ArbCA) 'CDLst = UnPush(CDLst, A2)              impliment

                    'End If
                    'If OrdrCA = 2 Then
                    '    If Pos1 = 1 Then
                    '        Dim tmp As Double = DcaAr(j).DWidth
                    '        DcaAr(j).DWidth = DcaAr(j).DLengths
                    '        DcaAr(j).DLengths = tmp
                    '    End If

                    '    If Pos1 = 2 Then
                    '        Dim tmp As Double = DcaAr(j).DHeight
                    '        DcaAr(j).DHeight = DcaAr(j).DWidth
                    '        DcaAr(j).DWidth = tmp
                    '    End If

                    '    ArtCA = B1
                    '    CDLst.RemoveAt(ArnCA(0))
                    '    If ArnCA(0) < ArnCA(1) Then
                    '        CDLst.RemoveAt(ArnCA(1) - 1)
                    '    Else
                    '        CDLst.RemoveAt(ArnCA(1))
                    '    End If

                    '    CDLst.Add(B2)

                    'End If
                    'If OrdrCA = 3 Then
                    '    CDLst.RemoveAt(Arm1CA)
                    'End If
                End If
                'Else

                If Arm1CA <> -1 Then
                    CDLst.RemoveAt(Arm1CA)
                End If
                'End If


                Stop

                'From here impliments 8 july 2008

                '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@$%^&


                Dim Qty As Integer
                If ChngFlg Then
                    '######
                    Stop
                    '########
                    IICAn = DrumFindOptMethodDHECA(DcaAr(j), ArtCA, Qty, TopUp(j))               'II = FindOptMethod(Ar(j), Art, Qty, TopUp(j))          impliment

                    Stop

                    If DOcc > 1 Then

                        Dim OccLst1 As New List(Of Integer)

                        For i As Integer = 0 To DOccLstCA.Count - 1
                            OccLst1.Add(DOccLstCA(i))
                        Next

                        Dim Strctm1 As New StructOcc1

                        Strctm1.j = j
                        Strctm1.j1 = OccLst1
                        Strctm1.CDLstSt = CDLst
                        DOptLstCA.Add(Strctm1)
                    End If

                    Drmi.DLengths = DcaAr(j).DLengths
                    Drmi.DWidth = DcaAr(j).DWidth
                    Drmi.DHeight = DcaAr(j).DHeight

                    'Stop

                    Dim Nm As String = DcaAri(j)
                    Dim P As Integer = j

                    If IICAn = 1 Then
                        DcaAr(P).DLengths = Drmi.DLengths      'Dln
                        DcaAr(P).DWidth = Drmi.DWidth          'Dwd
                        DcaAr(P).DHeight = Drmi.DHeight        'Dht

                    End If

                    If IICAn = 2 Then
                        DcaAr(P).DLengths = Drmi.DLengths       'Dln
                        DcaAr(P).DWidth = Drmi.DWidth           'Dwd
                        DcaAr(P).DHeight = Drmi.DHeight         'Dht

                    End If

                    If IICAn = 3 Then
                        DcaAr(P).DLengths = Drmi.DLengths        'Dln
                        DcaAr(P).DWidth = Drmi.DWidth            'Dwd
                        DcaAr(P).DHeight = Drmi.DHeight          'Dht

                    End If

                    If IICAn = 4 Then
                        DcaAr(P).DLengths = Drmi.DLengths        'Dln
                        DcaAr(P).DWidth = Drmi.DWidth            'Dwd
                        DcaAr(P).DHeight = Drmi.DHeight          'Dht

                    End If

                    If IICAn = 5 Then
                        DcaAr(P).DLengths = Drmi.DLengths         'Dln
                        DcaAr(P).DWidth = Drmi.DWidth             'Dwd
                        DcaAr(P).DHeight = Drmi.DHeight           'Dht

                    End If

                    If IICAn = 6 Then
                        DcaAr(P).DLengths = Drmi.DLengths          'Dln
                        DcaAr(P).DWidth = Drmi.DWidth              'Dwd
                        DcaAr(P).DHeight = Drmi.DHeight            'Dht

                    End If

                End If

                Dim Flg As Boolean = Math.Abs(((DcaAr(j).DLengths * DcaAr(j).DWidth * DcaAr(j).DHeight) * Qty) - (ArtCA.DLengths * ArtCA.DWidth * ArtCA.DHeight)) < 0.01

                'Dim Mm As Integer = findqty(Ari, j)
                Drmi.DmQty = DrmQt.DFindQty(DcaAri, j)             'Use DCalcQty.dll 

                Stop

                If Drmi.DmQty >= Qty And Flg Then                         'If Mm >= Qty And Flg Then

                    If DrawOpt Then
                        If TranspArr(j) Then
                            TravalCA = 0.8
                        Else
                            TravalCA = 0
                        End If

                        Stop

                        DcaAr(j).DStrtPt.x = ArtCA.DStrtPt.x
                        DcaAr(j).DStrtPt.y = ArtCA.DStrtPt.y
                        DcaAr(j).DStrtPt.z = ArtCA.DStrtPt.z

                        'Remain as it is commented do not use
                        'Ar(j).AutoDraw(OutFile, Col, traval, "file:///c:/t2.png", Ari(j), ArWt(j), QtyFlg, TxtOpt, "", 0, True, "c")
                        j += Qty
                        DItemQtyCA += Qty
                    Else
                        j += Qty

                        DItemQtyCA += Qty
                        DPlcLstCA(DItemNoCA) = DItemQtyCA               'impliment
                        DTotWtCA += ArWt(j)
                        GoTo LP
                    End If

                End If

                ArmCA = Nothing
                ArnCA = Nothing

                Stop

                DcaAr(j).DStrtPt.x = ArtCA.DStrtPt.x
                DcaAr(j).DStrtPt.y = ArtCA.DStrtPt.y
                DcaAr(j).DStrtPt.z = ArtCA.DStrtPt.z

                Stop

                If SaveOpt Then

ML:
                    Try
                        Cmd.ExecuteNonQuery()
                    Catch ec As Exception
                        If ec.Message = "Cannot open any more tables." Then
                            connDrums.Close()
                            connDrums.Dispose()
                            OleDb.OleDbConnection.ReleaseObjectPool()
                            Cmd.Dispose()
                            GC.Collect()

                            connDrums.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\Drums.mdb;Persist Security Info=False"

                            connDrums.Open()
                            GoTo ML
                        End If

                    End Try
                    id1 += 1
                End If

                'If DrawOpt Then

                '    If TranspArr(j) Then
                '        TravalCA = 0.8
                '    Else
                '        TravalCA = 0
                '    End If
                'End If
                'If j = UBound(DcaAr) Then

                'End If
                'If DrawOpt Then
                '    If j <> 0 Then
                '        If DcaAri(j) <> DcaAri(j - 1) Then
                '            TmpLstCA.Add(DcaAri(j - 1))
                '            TmpLstCA.Add(CStr(TotArCA))
                '            DAreaArrCA.Add(TmpLstCA)
                '            TotArCA = 0
                '            TotArCA = TotArCA + (DcaAr(j).DLengths * DcaAr(j).DWidth * DcaAr(j).DHeight)
                '        Else
                '            TotArCA = TotArCA + (DcaAr(j).DLengths * DcaAr(j).DWidth * DcaAr(j).DHeight)
                '        End If
                '    Else
                '        TotArCA = TotArCA + (DcaAr(j).DLengths * DcaAr(j).DWidth * DcaAr(j).DHeight)
                '    End If
                'End If

                'Stop


                ''$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$ Old

                'DDiaL = Ar(j).DLengths
                'DDiaW = Ar(j).DWidth
                'DHt = Ar(j).DHeight

                'If DDiaL = DDiaW Then

                '    DDia = DDiaL
                '    DRds = DDia * 0.5
                'Else
                '    DDia = (DDiaL + DDiaW) * 0.5

                'End If

                ''$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
                'Stop
                '$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$ New
                Dim Radius As Double = 0

                DDiaL = DcaAr(j).DLengths
                DDiaW = DcaAr(j).DWidth
                DRds = DcaAr(j).DRadius
                DHt = DcaAr(j).DHeight

                If DDiaL = DDiaW Then
                    DDia = DDiaL
                    Radius = DDia * 0.5
                    If Radius <> DRds Then
                        MessageBox.Show("The dimensioning adequacy in radius and diameter in cross arrangement", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If

                '$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

                'Stop

                'flgCAqt = False             'Initialise flag in cross arrangement

                If DrawOpt Then
                    TxtOpt = True

                    'Implement Here/ 20 April 2008 (old prototype development)
                    '5sd

                    'Stop

                    'From here impliments 25 June 2008
                    'siSW.Close()
                    'If Not flgCAqt Then
                    'Ar(j).AutoDrawDrmCA(OutFile, ColCA, TravalCA, "s" & ImgName & ".png", Ari(j), ArWt(j), QtyFlgCA, TxtOpt, Ari(j), IICA, True, "b", DDia, DRds, DHt)         'impliment

                    'Stop

                    Dcpt.AutoPlotDrmCA(OutFile, DColCA, TravalCA, "s" & DImgName & ".png", DcaAri(j), ArWt(j), QtyFlgCA, TxtOpt, DcaAri(j), IICAn, True, "b", DDia, DRds, DHt)

                    'DcaAr(j).AutoPlotDrmCA(OutFile, DColCA, TravalCA, "s" & DImgName & ".png", DcaAri(j), ArWt(j), QtyFlgCA, TxtOpt, DcaAri(j), IICAn, True, "b", DDia, DRds, DHt)

                    'Stop

                    '10 July 2k8 Implements from here

                    siSW.Close()

                    'Stop

                    'Else
                    'GoTo OutLp
                    'End If

                    If FlgCA Then
                        'GoTo CrossArngmtx
                        'Stop
                        'MsgBox("Continue")

                        ' siSW.Close()

                        'DDStop

                        'From here impliment 1 July 2008 for second row of grid

                        'Impliment inside routine for first row iteam grid row placed make it and then check grid row and second iteam placedby using generic type database here from 28 June 2008

                        If Not flgCAqt Then

                            'DDStop

                            'DbCrsStuff(OutFile, ColCA, TravalCA, "s" & ImgName & ".png", DcaAri(j), ArWt(j), QtyFlgCA, TxtOpt, DcaAri(j), IICA, True, "b", DDia, DRds, DHt)

                        Else

                            '%%%%%%%%%%%%%%%%%%%%%%%%%

                            If flgCAqt Then

                                Do While Not CDQCAer.Count = 0

                                    DCA = CDQCAer.Dequeue
                                    CDLst.Add(DCA)

                                Loop
                                'Return CDLst
                            End If

                            'DDStop

                            '%%%%%%%%%%%%%%%%%%%%%%%%%

                            'GoTo OutLp

                        End If

                        If Not flgCAqt Then

                            'DDStop

                            'CDQCAer = DPlaceCA(OutFile, ColCA, TravalCA, "s" & ImgName & ".png", DcaAri(j), ArWt(j), QtyFlgCA, TxtOpt, DcaAri(j), IICA, True, "b", DDia, DRds, DHt)

                            'DDStop

                        Else

                            '%%%%%%%%%%%%%%%%%%%%%%%%%

                            If flgCAqt Then

                                Do While Not CDQCAer.Count = 0

                                    DCA = CDQCAer.Dequeue
                                    CDLst.Add(DCA)

                                Loop
                                Return CDLst
                            End If

                            'DDStop

                            '%%%%%%%%%%%%%%%%%%%%%%%%%

                            'GoTo outlp

                        End If

                        If Not flgCAqt Then

                            'DDStop

                            'CDQCAer = DArgmtNxt(OutFile, ColCA, TravalCA, "s" & ImgName & ".png", DcaAri(j), ArWt(j), QtyFlgCA, TxtOpt, DcaAri(j), IICA, True, "b", DDia, DRds, DHt)

                            'DDStop

                        Else

                            '%%%%%%%%%%%%%%%%%%%%%%%%%

                            If flgCAqt Then

                                Do While Not CDQCAer.Count = 0

                                    DCA = CDQCAer.Dequeue
                                    CDLst.Add(DCA)

                                Loop
                                Return CDLst
                            End If

                            'DDStop

                            '%%%%%%%%%%%%%%%%%%%%%%%%%

                            'GoTo OutLp

                        End If

                        'DCArngmt = True

                        'Stop

                        '%%%%%%%%%%%%%%%%%%%%%%%%%

                        If flgCAqt Then

                            Do While Not CDQCAer.Count = 0

                                DCA = CDQCAer.Dequeue
                                CDLst.Add(DCA)

                            Loop

                            Return CDLst

                            Stop

                        End If

                        Stop

                        '%%%%%%%%%%%%%%%%%%%%%%%%%

                        Exit Try

                        'Stop

                        'connDrums.Close()
                        'siSW.Close()

                    End If

                    'DDStop
                    'DCA = CDQCAer.Dequeue
                    'CDLst.Add(DCA)
                    'DDStop

                    '*****************************************************************************
                    If DQtyLstCA.Count > 0 Then
                        DPlcLstCA(DrmRWidx) = DItemQtyCA

                    End If

                    DItemQtyCA += 1

                Else
                    DItemQtyCA += 1
                    DTotWtCA += ArWt(j)
                End If

                'DDStop

                If Not IsNothing(DcaAri) Then

                    '*********************************************
                    ' Do While Not Q.Count = 0
                    'Dd = Q.Dequeue
                    'CDLst.Add(Dd)
                    'Loop                   
                    'Dim Dot As String = "....."
                    If DItemQtyCA = 12 Then

                        'Stop
                        'siSW.Close()

                    End If

                    'siSW.Close()

                    DCountCSQ(ItrQty)       'ItemQty)              'Count Cross stuffed Quantity              impliment

                    'DDStop

                    'Progress8.i = ItemQty
                    'TransactionsMenu.lblStatus.Text = " Please wait " & CStr(Dot) & ""
                    'TransactionsMenu.lblStatus.Text = " Numbers ::   " & CStr(ItemQty) & "    -> Items stuffed"
                    'TransactionsMenu.lblStatus.Text = "Cross stuff arrangement in progress :: " & CStr(ItemQty) & Chr(13) & vbCr & "       Please wait ....."
                    'TransactionsMenu.btnStatus.Visible = True

                    'Eventful()

                    'TransactionsMenu.lblStatus.Refresh()
                    'System.Windows.Forms.Application.DoEvents()

                    'Impliment from here 30 June 2008 

                    '*********************************************
                    '7sd
                    'DDStop

                    'siSW.Close()

                    If exflg Then
                        exflg = False
                        GoTo LP
                    End If
                End If

                'CrossArngmtx:
                'If FlgCA Then
                'siSW.Close()
                'Stop
                'siSW.Close()
                'Q = Art.SubtractCA(Ar(j))
                'Return CDLst
                'Exit Function
                'End If

                'OutLp:

                'DDStop

                'Impliment here just add values inside the the CDLst.Add()

                '******************************************************************************************

                If flgCAqt Then

                    'If flgCAqt Then

                    '    Do While Not CDQCAer.Count = 0

                    '        DCA = CDQCAer.Dequeue

                    '        CDLst.Add(DCA)

                    '        'Stop

                    '    Loop

                    '    Stop

                    '    flgCAqt = False

                    'End If

                    'DCA = CDQCAer.Dequeue

                    'CDLst.Add(DCA)

                    'DDStop

                Else

                    DQCA = ArtCA.DrumSubtractDHD(DcaAr(j))          'Q = Art.Subtract(Ar(j))                'impliment

                End If

                'siSW.Close()



                DQCA = ArtCA.DrumSubtractDHD(DcaAr(j))          'Q = Art.Subtract(Ar(j))                'impliment

                '******************************************************************************************

                'DHDQ = ArtCA.DrumSubtractDHD(DcaAr(j))          'Q = Art.Subtract(Ar(j))                'impliment

                '######  DQCA = ArtCA.DrumSubtractDHD(DcaAr(j))          'Q = Art.Subtract(Ar(j))                'impliment

                '8sd
                'DDStop

                Dim Dd As New CDArea
                If Not DQCA Is Nothing Then
                    If CDLst.Count = 0 Then
                        Do While Not DQCA.Count = 0

                            Dd = DQCA.Dequeue

                            CDLst.Add(Dd)

                        Loop
                    Else
                        Do While DQCA.Count > 0
                            'ArbCA = DQCA.Dequeue
                            'Ans1CA = False

                            'CDLst = DHDUnPush(CDLst, ArbCA) 'CDLst = UnPush(CDLst, Arb)         impliment

                        Loop

                    End If

                End If

                Dim Ans2 As Boolean

                For i As Integer = 0 To CDLst.Count - 1

                    Dim Arx As New CDArea

                    Arx = CDLst(i)

                    CDLst = DHVMrgX(CDLst, Arx, Ans2)       'CDLst = MrgX(CDLst, Arx, Ans2)             impliment

                    '9sd
                    'DDStop

                    If Ans2 Then
                        Exit For
                    End If


                Next

                'DDStop

                Dim StR1n1 As New StructR1

                Dim CDAnn As New CDArea

                CDAnn.DLengths = DcaAr(j).DLengths
                CDAnn.DWidth = DcaAr(j).DWidth
                CDAnn.DHeight = DcaAr(j).DHeight
                CDAnn.DStrtPt.x = DcaAr(j).DStrtPt.x
                CDAnn.DStrtPt.y = DcaAr(j).DStrtPt.y
                CDAnn.DStrtPt.z = DcaAr(j).DStrtPt.z

                StR1n1.Ar = CDAnn
                StR1n1.Method = IICAn
                StR1n1.ItmNm = DcaAri(j)

                Dim Lstmmm As New List(Of CDArea)

                For Kk As Integer = 0 To CDLst.Count - 1
                    Lstmmm.Add(CDLst(Kk))
                Next

                StR1n1.R1CDLst = Lstmmm

                LstR1StArr.Add(StR1n1)

                j += 1


LP:
                'Loop

                DItemQtyCA = ItrQty

                'Fff()

                '$$$$$
                'Stop
                '$$$$$
                If j > 0 Then
                    E1StE2 = New StructE1
                    E1StE2.Qty = DItemQtyCA
                    E1StE2.ItmNm = DcaAri(j - 1)
                End If

                'CDLstjCA = New List(Of CDArea)
                For jj As Integer = 0 To CDLst.Count - 1
                    'CDLstjCA.Add(CDLst(jj))
                Next
                'E1StE2.E1StLst = CDLstjCA
                If DrawOpt Then
                    'QtyArr.Add(E1StE2)             impliment
                End If
                DMaxQtyLstCA.Add(DItemQtyCA)

                'Form8.Close()
                TransactionsMenu.btnStatus.Visible = False
                TransactionsMenu.lblStatus.Visible = False

                Eventless()

                If UBound(DcaAr) >= j Then
                    fullflag = True
                End If

                'If FindQtyFlg Then
                CDLst.Clear()
                '    For i As Integer = 0 To CDLst.Count - 1                   ' impliment
                '            If Not Drumchk1DHE(CDLst2CA(i), CDLst) Then
                '                If Not Drumchk11DHE(CDLst2CA(i), CDLst) Then
                '                    CDLst.Add(CDLst2CA(i))
                '                End If
                '            End If
                '        Next
                'End If

                If DrawOpt Then
                    If UBound(DcaAri) <> -1 Then
                        'TmpLstCA.Add(DcaAri(j - 1))
                        'TmpLstCA.Add(CStr(TotArCA))
                        'DAreaArrCA.Add(TmpLstCA)
                    End If
                End If

            Catch Ex As Exception
                MsgBox(Ex.Message)
                MsgBox(Ex.ToString)
                MessageBox.Show("Error in DCrossStuff" & vbCrLf & "Data Stuffing failure!", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'Application.Exit()
            Finally

                connDrums.Close()
            End Try

            If DrawOpt Or DrawArc Then
            End If
            'QtyFlgCA = True
            connDrums.Dispose()
            connDrums.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\Drums.mdb;Persist Security Info=False"
            connDrums.Open()

            Return CDLst



            '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

            '        '2sd



            '        Stop


        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in DMgrCrossStuff", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return CDLst

    End Function

    Public Function DrmCrsStuffArngmt(ByVal DcaArc As CDArea, ByVal DcaAr() As CDArea, ByVal DcaAri() As String, ByVal ArWt() As Single, ByVal SaveOpt As Boolean, ByVal ShowEmpty As Boolean, ByVal OutFile As String, ByVal DrawArc As Boolean, ByVal TranspArr() As Boolean, ByVal TopUp() As Boolean, ByVal TxtOpt As Boolean, ByVal DrawOpt As Boolean, ByVal FindQtyFlg As Boolean, ByVal ChngFlg As Boolean, ByVal ColArr As List(Of List(Of Byte))) As List(Of CDArea)

        'DDDStop

        Dim CDLst2CA As New List(Of CDArea)
        Dim CDStkCA As New Stack(Of CDArea)
        Dim ArmCA As New List(Of Integer)
        Dim LstmCA As New List(Of CDArea)
        Dim TmpLstCA As New List(Of String)
        Dim CDLstjCA As New List(Of CDArea)

        Dim A1CA As New CDArea
        Dim A2CA As New CDArea

        Dim ArtCA As New CDArea
        Dim ArpCA As New CDArea
        Dim AreCA As New CDArea
        Dim AruCA As New CDArea
        Dim ArbCA As New CDArea

        Dim Arm1CA As Integer
        Dim IICA As Integer
        Dim TravalCA As Single

        Dim SzChgCA As Integer = 0

        Dim QtyFlgCA As Boolean = True
        Dim Ans1CA As Boolean

        Dim OrdrCA As Integer
        Dim ColCA As String
        Dim TotArCA As Double
        Dim OldItemQtyCA As Integer = 0

        'DDStop

        Try

            If SaveOpt Then
                configid = InputBox("Enter Config Id")
            End If

            Dim Ptx As New CDPoint

            Ptx.x = DcaArc.DLengths
            Ptx.y = DcaArc.DWidth
            Ptx.z = DcaArc.DHeight

            'DDDStop

            'DcaArc.DLengths = 276
            'DcaArc.DWidth = 92
            'DcaArc.DHeight = 94


            Dim Col1 As New List(Of Byte)
            Col1.Clear()
            Col1.Add(255)
            Col1.Add(255)
            Col1.Add(255)

            ColCA = "r"
            Dim ItmNm As String = ""

            If DrawArc Then
                Dim Ard1CA As New CDArea

                If DrawArc Then
                End If

                ArdCA.DStrtPt.x = DcaArc.DLengths
                ArdCA.DStrtPt.y = 0
                ArdCA.DStrtPt.z = 0
                ArdCA.DLengths = 0.5
                ArdCA.DWidth = DcaArc.DWidth
                ArdCA.DHeight = DcaArc.DHeight

                If DrawOpt Or DrawArc Then

                End If

                Ard1CA.DStrtPt.x = DcaArc.DLengths - 0.01
                Ard1CA.DStrtPt.y = 0
                Ard1CA.DStrtPt.z = 0
                Ard1CA.DLengths = 0.5
                Ard1CA.DWidth = ArdCA.DWidth
                Ard1CA.DHeight = ArdCA.DHeight
            End If

            If DrawOpt Or DrawArc Then
                Col1.Clear()
            End If

            If SaveOpt Then
                Cmd.Connection = connDrums
Repeat:

                Try
                    Cmd.ExecuteNonQuery()

                Catch Ex As Exception
                    If Ex.Message = "Cannot open any more tables." Then
                        connDrums.Close()
                        connDrums.Dispose()
                        OleDb.OleDbConnection.ReleaseObjectPool()
                        Cmd.Dispose()
                        GC.Collect()

                        connDrums.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\Drums.mdb;Persist Security Info=False"

                        connDrums.Open()
                        GoTo Repeat
                    End If
                End Try
                id1 += 1

            End If

            DcaArc.DStrtPt.x = 0
            DcaArc.DStrtPt.y = 0
            DcaArc.DStrtPt.z = 0

            Dim j As Integer = 0
            TotArCA = 0
            DAreaArrCA.Clear()
            For i As Integer = 0 To CDLst.Count - 1
                CDLst2CA.Add(CDLst(i))
            Next
            DItemQtyCA = 0
            DTotWtCA = 0
            If Not IsNothing(DcaAri) Then
                'Progress8.Show()
                TransactionsMenu.lblStatus.Visible = True
                If DrawOpt Then
                    Progress8.btnStatus.Visible = False
                    TransactionsMenu.btnStatus.Visible = False

                End If
                'Progress8.Focus()
                TransactionsMenu.lblStatus.Focus()
            End If

            For i As Integer = 0 To DQtyLstCA.Count - 1
                DPlcLstCA.Add(DQtyLstCA(i) - 1)
            Next

            fullflag = False
            OldItemQtyCA = 0
            Dim ImgName As String = "1"

            Do While Not CDLst.Count = 0 And j <= UBound(DcaAr)             'Starting the stuff placement loop
                'DDStop
                If j > 0 Then
                    If DcaAri(j) <> DcaAri(j - 1) Then
                        ImgName = (CInt(ImgName) + 1).ToString
                    End If
                End If

                OrdrCA = 0

                If chkwt Then
                    DTotWtCA += ArWt(j)
                    If DTotWtCA >= contcap Then

                        AnsW = MsgBox("Maximum weight capacity of the container is reached" & vbCrLf & "Do you want to proceed?", MsgBoxStyle.YesNo)
                        If AnsW = MsgBoxResult.No Then
                            fullflag = True

                            Exit Do

                        Else
                            fullflag = False

                            chkwt = False
                        End If

                    End If
                End If

                '+++++++++++++++++++++++++++++++++++++

                If DrawOpt Then
                    If j > 0 Then

                        If DcaAri(j - 1) <> DcaAri(j) Then

                            DItemQtyCA = 0

                            If ColCA = "r" Then
                                ColCA = "g"
                            ElseIf ColCA = "g" Then
                                ColCA = "b"
                            ElseIf ColCA = "b" Then
                                ColCA = "m"
                            ElseIf ColCA = "m" Then
                                ColCA = "c"
                            ElseIf ColCA = "c" Then
                                ColCA = "y"
                            End If

                            SzChgCA += 1

                            QtyFlgCA = True

                        Else
                            QtyFlgCA = False
                        End If
                    End If
                End If

                If SzChgCA <> 2 Then

                Else

                End If

                'DDDStop

                'The start manupulation of cross arrangement ***********************************************************

                Arm1CA = DFindOptCA(CDLst, DcaAr(j), TopUp(j))

                'Arm1CA = DFindOptCANxt(CDLst, DcaAr(j), TopUp(j))

                'DDDStop

                ArtCA = Nothing
                If Arm1CA <> -1 Then
                    ArtCA = CDLst(Arm1CA)
                End If

                Dim ArnCA As New List(Of Integer)
                Dim LstnCA As New List(Of CDArea)

                Dim B1 As New CDArea
                Dim B2 As New CDArea
                Dim Pos1 As Integer

                ArmCA = Nothing
                ArnCA = Nothing

                'DDDStop

                ArnCA = DrumFindCandidate1DHECA(CDLst, DcaAr(j), TopUp(j))

                'ArnCA = DrumFindCandidate1DHECANxt(CDLst, DcaAr(j), TopUp(j))

                '3sd

                'DDDStop

                Pos1 = 0
                If Not ArnCA Is Nothing Then
                    Pos1 = 0
                Else

                    Dim Arxx As New CDArea

                    Arxx.DLengths = DcaAr(j).DWidth
                    Arxx.DWidth = DcaAr(j).DLengths
                    Arxx.DHeight = DcaAr(j).DHeight

                    'DDDStop

                    ArnCA = DrumFindCandidate1DHECA(CDLst, DcaAr(j), TopUp(j))
                    'ArnCA = DrumFindCandidate1DHECANxt(CDLst, DcaAr(j), TopUp(j))

                    'DDDStop

                    If Not ArnCA Is Nothing Then
                        Pos1 = 1
                    Else
                        If Not TopUp(j) Then
                            Arxx.DLengths = DcaAr(j).DLengths
                            Arxx.DWidth = DcaAr(j).DHeight
                            Arxx.DHeight = DcaAr(j).DWidth

                            'DDDStop

                            ArnCA = DrumFindCandidate1DHECA(CDLst, DcaAr(j), TopUp(j))

                            'ArnCA = DrumFindCandidate1DHECANxt(CDLst, DcaAr(j), TopUp(j))

                            'DDDStop

                            If Not ArnCA Is Nothing Then
                                Pos1 = 2
                            End If
                        End If
                    End If
                End If

                'DDDStop

                If ArnCA Is Nothing Then

                    'DDDStop

                    ArmCA = DrumFindCandidateDHECA(DcaAr(j), CDLst)
                    'ArmCA = DrumFindCandidateDHECANxt(DcaAr(j), CDLst)

                    'DDDStop

                    If Not ArmCA Is Nothing Then
                        If ArmCA(0) = Arm1CA Then ArmCA = Nothing
                    End If

                End If

                'DDDStop

                If Not ArmCA Is Nothing Then

                    Stop

                    LstmCA = DrumUnionItrPDHECA(CDLst(ArmCA(0)), CDLst(ArmCA(1)))

                    'LstmCA = DrumUnionItrPDHECANxt(CDLst(ArmCA(0)), CDLst(ArmCA(1)))

                    A1CA = LstmCA(0)
                    A2CA = LstmCA(1)

                End If

                If Not ArnCA Is Nothing Then

                    Stop

                    LstmCA = DrumUnionItrPDHECA(CDLst(ArmCA(0)), CDLst(ArmCA(1)))

                    'LstmCA = DrumUnionItrPDHECANxt(CDLst(ArmCA(0)), CDLst(ArmCA(1)))

                    B1 = LstmCA(0)
                    B2 = LstmCA(1)
                End If

                'DDDStop

                If ArmCA Is Nothing And Arm1CA = -1 Then
                    If DrawOpt Then

                    End If

                    For m As Integer = j To UBound(DcaAri) - 1
                        If DcaAri(m) <> DcaAri(j) Then
                            j = m

                            GoTo LP

                        End If
                    Next

                    'Stop
                    j = UBound(DcaAri) + 1

                    GoTo LP

                Else
                    If ArnCA Is Nothing And Arm1CA = -1 Then
                        If DrawOpt Then

                        End If

                        For m As Integer = j To UBound(DcaAri) - 1
                            If DcaAri(m) <> DcaAri(j) Then
                                j = m
                                GoTo LP

                            End If
                        Next
                        j = UBound(DcaAri)

                    End If
                End If

                'DDStop

                If Not ArmCA Is Nothing Or Not ArnCA Is Nothing Then

                    Cmd.Connection = connDrums

                    DeleteTable("DTemp2")

                    'DrmZz:

                    OrdrCA = 0
                    If Not ArmCA Is Nothing Then

                        DInsertTable("DTemp2", New Object() {CStr(A1CA.DStrtPt.x), CStr(A1CA.DStrtPt.y), CStr(A1CA.DStrtPt.z), CStr(1)})           'impliment
                    End If

                    If Not ArnCA Is Nothing Then
                        DInsertTable("DTemp2", New Object() {CStr(B1.DStrtPt.x), CStr(B1.DStrtPt.y), CStr(B1.DStrtPt.z), CStr(2)})           'impliment

                    End If

                    If Not ArtCA Is Nothing Then
                        DInsertTable("DTemp2", New Object() {CStr(ArtCA.DStrtPt.x), CStr(ArtCA.DStrtPt.y), CStr(ArtCA.DStrtPt.z), CStr(3)})        'impliment

                    End If

                    Dim RwCA As DataRow() = Nothing

                    Try
                        If Not ArmCA Is Nothing Then

                            RwCA = DGetf("DTemp2", "", "z DESC ,x ASC,y ASC")
                        End If

                        If Not ArnCA Is Nothing Then

                            RwCA = DGetf("DTemp2", "", "z DESC ,x ASC,y ASC")
                        End If

                        If ArnCA Is Nothing And ArmCA Is Nothing Then

                            RwCA = DGetf("DTemp2", "", "z DESC ,x ASC")
                        End If

                        If ArmCA Is Nothing And ArnCA Is Nothing Then

                            RwCA = DGetf("DTemp2", "", "z DESC ,x ASC,y ASC")
                        End If

                    Catch Err As Exception

                        MsgBox(Err.Message)
                        MsgBox(Err.ToString)
                        MessageBox.Show("Error in DrmCrsStuffArngmt" & vbCrLf & "Programme Running is failure!", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    Finally

                        OrdrCA = RwCA(0)("i")

                    End Try

                    Stop

                    If OrdrCA = 3 Then

                        CDLst.RemoveAt(Arm1CA)

                    Else
                        If OrdrCA = 1 Then

                            ArtCA = A1CA

                            CDLst.RemoveAt(ArmCA(0))

                            If ArmCA(0) < ArmCA(1) Then
                                CDLst.RemoveAt(ArmCA(1) - 1)
                            Else
                                CDLst.RemoveAt(ArmCA(1))
                            End If

                            CDLst = DHDUnPush(CDLst, ArbCA) 'CDLst = UnPush(CDLst, A2)              impliment

                            'CDLst = DHDUnPushCANxt(CDLst, ArbCA)


                            'Impliments from here 17 July 2K8


                        End If

                        If OrdrCA = 2 Then
                            If Pos1 = 1 Then
                                Dim tmp As Double = DcaAr(j).DWidth
                                DcaAr(j).DWidth = DcaAr(j).DLengths
                                DcaAr(j).DLengths = tmp
                            End If

                            If Pos1 = 2 Then
                                Dim tmp As Double = DcaAr(j).DHeight
                                DcaAr(j).DHeight = DcaAr(j).DWidth
                                DcaAr(j).DWidth = tmp
                            End If

                            ArtCA = B1
                            CDLst.RemoveAt(ArnCA(0))
                            If ArnCA(0) < ArnCA(1) Then
                                CDLst.RemoveAt(ArnCA(1) - 1)
                            Else
                                CDLst.RemoveAt(ArnCA(1))
                            End If

                            CDLst.Add(B2)

                        End If
                        If OrdrCA = 3 Then
                            CDLst.RemoveAt(Arm1CA)
                        End If
                    End If
                Else

                    If Arm1CA <> -1 Then
                        CDLst.RemoveAt(Arm1CA)
                    End If
                End If

                Dim Qty As Integer
                If ChngFlg Then

                    '######
                    'DDDStop
                    '########

                    IICA = DrumFindOptMethodDHECA(DcaAr(j), ArtCA, Qty, TopUp(j))               'II = FindOptMethod(Ar(j), Art, Qty, TopUp(j))          impliment

                    'IICA = DrumFindOptMethodCANxt(DcaAr(j), ArtCA, Qty, TopUp(j))

                    'DDDStop

                    If DOcc > 1 Then

                        Dim OccLst1 As New List(Of Integer)

                        For i As Integer = 0 To DOccLstCA.Count - 1
                            OccLst1.Add(DOccLstCA(i))
                        Next

                        Dim Strctm1 As New StructOcc1

                        Strctm1.j = j
                        Strctm1.j1 = OccLst1
                        Strctm1.CDLstSt = CDLst
                        DOptLstCA.Add(Strctm1)

                    End If

                    Drmi.DLengths = DcaAr(j).DLengths
                    Drmi.DWidth = DcaAr(j).DWidth
                    Drmi.DHeight = DcaAr(j).DHeight

                    'ARcaDrm.DLengths = DcaAr(j).DLengths
                    'ARcaDrm.DWidth = DcaAr(j).DWidth
                    'ARcaDrm.DHeight = DcaAr(j).DHeight

                    'Dim Dln As Double = Ar(j).DLengths
                    'Dim Dwd As Double = Ar(j).DWidth
                    'Dim Dht As Double = Ar(j).DHeight

                    'DDDStop

                    Dim Nm As String = DcaAri(j)
                    Dim P As Integer = j

                    If IICA = 1 Then

                        DcaAr(P).DLengths = Drmi.DLengths
                        DcaAr(P).DWidth = Drmi.DWidth
                        DcaAr(P).DHeight = Drmi.DHeight

                    End If

                    If IICA = 2 Then

                        DcaAr(P).DLengths = Drmi.DLengths
                        DcaAr(P).DWidth = Drmi.DWidth
                        DcaAr(P).DHeight = Drmi.DHeight

                    End If

                    If IICA = 3 Then

                        DcaAr(P).DLengths = Drmi.DLengths
                        DcaAr(P).DWidth = Drmi.DWidth
                        DcaAr(P).DHeight = Drmi.DHeight

                    End If

                    If IICA = 4 Then

                        DcaAr(P).DLengths = Drmi.DLengths
                        DcaAr(P).DWidth = Drmi.DWidth
                        DcaAr(P).DHeight = Drmi.DHeight

                    End If

                    If IICA = 5 Then

                        DcaAr(P).DLengths = Drmi.DLengths
                        DcaAr(P).DWidth = Drmi.DWidth
                        DcaAr(P).DHeight = Drmi.DHeight

                    End If

                    If IICA = 6 Then

                        DcaAr(P).DLengths = Drmi.DLengths
                        DcaAr(P).DWidth = Drmi.DWidth
                        DcaAr(P).DHeight = Drmi.DHeight

                    End If

                End If

                Dim Flg As Boolean = Math.Abs(((DcaAr(j).DLengths * DcaAr(j).DWidth * DcaAr(j).DHeight) * Qty) - (ArtCA.DLengths * ArtCA.DWidth * ArtCA.DHeight)) < 0.01

                Drmi.DmQty = DrmQt.DFindQty(DcaAri, j)             'Use DCalcQty.dll 

                'DDDStop

                If Drmi.DmQty >= Qty And Flg Then                         'If Mm >= Qty And Flg Then

                    If DrawOpt Then

                        If TranspArr(j) Then
                            TravalCA = 0.8
                        Else
                            TravalCA = 0
                        End If

                        DcaAr(j).DStrtPt.x = ArtCA.DStrtPt.x
                        DcaAr(j).DStrtPt.y = ArtCA.DStrtPt.y
                        DcaAr(j).DStrtPt.z = ArtCA.DStrtPt.z

                        'Remain as it is commented do not use
                        'Ar(j).AutoDraw(OutFile, Col, traval, "file:///c:/t2.png", Ari(j), ArWt(j), QtyFlg, TxtOpt, "", 0, True, "c")
                        j += Qty
                        DItemQtyCA += Qty

                    Else

                        j += Qty

                        DItemQtyCA += Qty
                        DPlcLstCA(DItemNoCA) = DItemQtyCA               'impliment
                        DTotWtCA += ArWt(j)
                        GoTo LP

                    End If

                End If

                ArmCA = Nothing
                ArnCA = Nothing

                DcaAr(j).DStrtPt.x = ArtCA.DStrtPt.x
                DcaAr(j).DStrtPt.y = ArtCA.DStrtPt.y
                DcaAr(j).DStrtPt.z = ArtCA.DStrtPt.z

                If SaveOpt Then

ML:
                    Try
                        Cmd.ExecuteNonQuery()
                    Catch ec As Exception
                        If ec.Message = "Cannot open any more tables." Then
                            connDrums.Close()
                            connDrums.Dispose()
                            OleDb.OleDbConnection.ReleaseObjectPool()
                            Cmd.Dispose()
                            GC.Collect()

                            connDrums.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\Drums.mdb;Persist Security Info=False"

                            connDrums.Open()

                            GoTo ML

                        End If

                    End Try
                    id1 += 1
                End If

                If DrawOpt Then

                    If TranspArr(j) Then
                        TravalCA = 0.8
                    Else
                        TravalCA = 0
                    End If
                End If

                If j = UBound(DcaAr) Then

                End If

                If DrawOpt Then
                    If j <> 0 Then
                        If DcaAri(j) <> DcaAri(j - 1) Then
                            TmpLstCA.Add(DcaAri(j - 1))
                            TmpLstCA.Add(CStr(TotArCA))
                            DAreaArrCA.Add(TmpLstCA)
                            TotArCA = 0
                            TotArCA = TotArCA + (DcaAr(j).DLengths * DcaAr(j).DWidth * DcaAr(j).DHeight)
                        Else
                            TotArCA = TotArCA + (DcaAr(j).DLengths * DcaAr(j).DWidth * DcaAr(j).DHeight)
                        End If
                    Else
                        TotArCA = TotArCA + (DcaAr(j).DLengths * DcaAr(j).DWidth * DcaAr(j).DHeight)
                    End If
                End If

                'DDDStop

                Dim Radius As Double = 0

                DDiaL = DcaAr(j).DLengths
                DDiaW = DcaAr(j).DWidth
                DRds = DcaAr(j).DRadius
                DHt = DcaAr(j).DHeight

                DpRds = DRds            'Previous value assign
                DpHt = DHt

                If DDiaL = DDiaW Then
                    DDia = DDiaL
                    Radius = DDia * 0.5
                    If Radius <> DRds Then
                        MessageBox.Show("The dimensioning adequacy in radius and diameter in cross arrangement", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If

                '$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

                If DrawOpt Then
                    TxtOpt = True

                    'DDDStop

                    DcaAr(j).AutoDrawDrmCA(OutFile, ColCA, TravalCA, "s" & ImgName & ".png", DcaAri(j), ArWt(j), QtyFlgCA, TxtOpt, DcaAri(j), IICA, True, "b", DDia, DRds, DHt)

                    'DDDStop

                    'DcaAr(j).AutoDrawDrmCANxt(OutFile, ColCA, TravalCA, "s" & ImgName & ".png", DcaAri(j), ArWt(j), QtyFlgCA, TxtOpt, DcaAri(j), IICA, True, "b", DDia, DRds, DHt)

                    If FlgCA Then

                        If Not flgCAqt Then

                            'DDDStop
                            DbCrsStuff(OutFile, ColCA, TravalCA, "s" & ImgName & ".png", DcaAri(j), ArWt(j), QtyFlgCA, TxtOpt, DcaAri(j), IICA, True, "b", DDia, DRds, DHt)

                        Else

                            '%%%%%%%%%%%%%%%%%%%%%%%%%

                            If flgCAqt Then

                                Do While Not CDQCAer.Count = 0

                                    DCA = CDQCAer.Dequeue
                                    CDLst.Add(DCA)

                                Loop
                                Return CDLst
                            End If

                            Stop

                            '%%%%%%%%%%%%%%%%%%%%%%%%%

                            GoTo OutLp

                        End If

                        If Not flgCAqt Then

                            'DDDStop

                            CDQCAer = DPlaceCA(OutFile, ColCA, TravalCA, "s" & ImgName & ".png", DcaAri(j), ArWt(j), QtyFlgCA, TxtOpt, DcaAri(j), IICA, True, "b", DDia, DRds, DHt)

                            'DDDStop

                        Else

                            '%%%%%%%%%%%%%%%%%%%%%%%%%

                            If flgCAqt Then

                                Do While Not CDQCAer.Count = 0

                                    DCA = CDQCAer.Dequeue
                                    CDLst.Add(DCA)

                                Loop
                                Return CDLst
                            End If

                            'DDDStop

                            '%%%%%%%%%%%%%%%%%%%%%%%%%

                            GoTo outlp

                        End If

                        If Not flgCAqt Then

                            'DDDStop

                            CDQCAer = DArgmtNxt(OutFile, ColCA, TravalCA, "s" & ImgName & ".png", DcaAri(j), ArWt(j), QtyFlgCA, TxtOpt, DcaAri(j), IICA, True, "b", DDia, DRds, DHt)

                            'DDDStop

                        Else

                            '%%%%%%%%%%%%%%%%%%%%%%%%%

                            If flgCAqt Then

                                Do While Not CDQCAer.Count = 0

                                    DCA = CDQCAer.Dequeue
                                    CDLst.Add(DCA)

                                Loop

                                'DDDStop

                                'New Changes Here Done 12 July 2K8

                                flgNxtArg = True


                                GoTo OutLp
                                'Return CDLst

                            End If

                            'DDDStop

                            '%%%%%%%%%%%%%%%%%%%%%%%%%

                            GoTo OutLp

                        End If

                        'DCArngmt = True

                        'DDDStop

                        '%%%%%%%%%%%%%%%%%%%%%%%%%

                        If flgCAqt Then

                            Do While Not CDQCAer.Count = 0

                                DCA = CDQCAer.Dequeue
                                CDLst.Add(DCA)

                            Loop

                            'DsStop

                            'Return CDLst
                            flgNxtArg = True
                            GoTo OutLp

                            'DsStop

                        End If

                        'DDDStop

                        '%%%%%%%%%%%%%%%%%%%%%%%%%

                        'Exit Try

                        'Stop

                        'connDrums.Close()
                        'siSW.Close()

                    End If

                    'DDDStop

                    'DCA = CDQCAer.Dequeue
                    'CDLst.Add(DCA)
                    'DDStop

                    '*****************************************************************************
                    If DQtyLstCA.Count > 0 Then

                        DPlcLstCA(DrmRWidx) = DItemQtyCA

                    End If

                    DItemQtyCA += 1

                Else
                    DItemQtyCA += 1
                    DTotWtCA += ArWt(j)
                End If

                'DDDsStop

                If Not IsNothing(DcaAri) Then

                    '*********************************************
                    'DDDStop

                    If DItemQtyCA = 20 Then
                        'MsgBox("OK")
                        'Stop
                        'siSW.Close()

                    End If

                    'siSW.Close()

                    DCountCSQ(ItrQty)       'ItemQty)              'Count Cross stuffed Quantity              impliment

                    'DDDStop

                    'siSW.Close()

                    'DDDStop


                    'Progress8.i = ItemQty
                    'TransactionsMenu.lblStatus.Text = " Please wait " & CStr(Dot) & ""
                    'TransactionsMenu.lblStatus.Text = " Numbers ::   " & CStr(ItemQty) & "    -> Items stuffed"
                    'TransactionsMenu.lblStatus.Text = "Cross stuff arrangement in progress :: " & CStr(ItemQty) & Chr(13) & vbCr & "       Please wait ....."
                    'TransactionsMenu.btnStatus.Visible = True

                    'Eventful()

                    'TransactionsMenu.lblStatus.Refresh()
                    'System.Windows.Forms.Application.DoEvents()

                    'Impliment from here 30 June 2008 

                    '*********************************************
                    '7sd
                    'DDDStop

                    'siSW.Close()

                    If exflg Then
                        exflg = False
                        GoTo LP
                    End If
                End If

                'CrossArngmtx:
                'If FlgCA Then
                'siSW.Close()
                'Stop
                'siSW.Close()
                'Q = Art.SubtractCA(Ar(j))
                'Return CDLst
                'Exit Function
                'End If

OutLp:

                'DDDStop


                'DQCA = ArtCA.DrumSubtractDHD(DcaAr(j))          'Q = Art.Subtract(Ar(j))                'impliment


                '******************************************************************************************

                If flgCAqt Then

                    'If flgCAqt Then

                    '    Do While Not CDQCAer.Count = 0

                    '        DCA = CDQCAer.Dequeue

                    '        CDLst.Add(DCA)

                    '        'Stop

                    '    Loop

                    '    Stop

                    '    flgCAqt = False

                    'End If

                    'DCA = CDQCAer.Dequeue

                    'CDLst.Add(DCA)

                    'DDStop

                Else

                    'DDDStop

                    'Implements from  12 July 2K8

                    DQCA = ArtCA.DrumSubtractDHD(DcaAr(j))          'Q = Art.Subtract(Ar(j))                'impliment

                    'DDDStop

                End If

                'DDDStop

                'GoTo Direct
                '^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

                'Next row arrangement of row start here

                If flgNxtArg Then

                    Dim CDLst2 As New List(Of CDArea)

                    'DDDStop

                    '111    &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                    ' ''&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

                    ' '' CDLst = DrmCrsStuffArngmt(DcaArc, DcaAr, DcaAri, ArWt, SaveOpt, ShowEmpty, OutFile, DrawArc, TranspArr, TopUp, TxtOpt, DrawOpt, FindQtyFlg, ChngFlg, ColArr)

                    ' ''CDLst2 = DrumStuff(DcaArc, DcaAr, DcaAri, ArWt, SaveOpt, ShowEmpty, OutFile, True, TranspArr, TopUp, TxtOpt, DrawOpt, FindQtyFlg, ChngFlg, ColArr)

                    ''CDLst2 = DrumStuffCANxt(DcaArc, DcaAr, DcaAri, ArWt, SaveOpt, ShowEmpty, OutFile, True, TranspArr, TopUp, TxtOpt, DrawOpt, FindQtyFlg, ChngFlg, ColArr)

                    'CDLst2 = DrumStuffCANxt(DcaArc, DArItm, DAri2, ArWt, SaveOpt, ShowEmpty, OutFile, True, TranspArr, TopUp, TxtOpt, DrawOpt, FindQtyFlg, ChngFlg, DImgName, ColArr)

                    ' ''CDLst2 = DrmCrsStuffArngmt(DcaArc, DcaAr, DcaAri, ArWt, SaveOpt, ShowEmpty, OutFile, True, TranspArr, TopUp, TxtOpt, DrawOpt, FindQtyFlg, ChngFlg, ColArr)

                    ' ''Public Function DrmCrsStuffArngmt(ByVal DcaArc As CDArea, ByVal DcaAr() As CDArea, ByVal DcaAri() As String, ByVal ArWt() As Single, ByVal SaveOpt As Boolean, ByVal ShowEmpty As Boolean, ByVal OutFile As String, ByVal DrawArc As Boolean, ByVal TranspArr() As Boolean, ByVal TopUp() As Boolean, ByVal TxtOpt As Boolean, ByVal DrawOpt As Boolean, ByVal FindQtyFlg As Boolean, ByVal ChngFlg As Boolean, ByVal ColArr As List(Of List(Of Byte))) As List(Of CDArea)

                    ' ''&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

                    ' ''&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

                    ' ''&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

                    ' ''&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

                    'DsStop

                    Dim Dcpt As New CDrum                          'Last position of drum value assigns 

                    Dcpt.DStrtPt.x = DCA.DStrtPt.x
                    Dcpt.DStrtPt.y = DCA.DStrtPt.y
                    Dcpt.DStrtPt.z = DCA.DStrtPt.z

                    Dcpt.DCntPt.X = DCA.DCntPt.X
                    Dcpt.DCntPt.Y = DCA.DCntPt.Y
                    Dcpt.DCntPt.Z = DCA.DCntPt.Z

                    Dcpt.DmQty = DCA.DmQty

                    XL = DCA.DStrtPt.x
                    YL = DCA.DStrtPt.y
                    ZL = DCA.DStrtPt.z

                    Dim DnApt As New CDArea

                    DnApt.DStrtPt.x = DCA.DStrtPt.x
                    DnApt.DStrtPt.y = DCA.DStrtPt.y
                    DnApt.DStrtPt.z = DCA.DStrtPt.z

                    DnApt.DCntPt.X = DCA.DStrtPt.x
                    DnApt.DCntPt.Y = DCA.DStrtPt.y
                    DnApt.DCntPt.Z = DCA.DStrtPt.z

                    'DsStop

                    'siSW.Close()

                    'DsStop

                    Dim DArCA As New CDrum

                    '*********************************************************************************************
                    ' Dim j As Integer = Dcpt.DmQty + 1

                    j = Dcpt.DmQty + 1

                    Dim DNos As Integer = DcaAr.Length()

                    Dim dB As New CDArea

                    If DNos > Dcpt.DmQty Then                      'If Drmi.DmQty >= Qty And Flg Then                         'If Mm >= Qty And Flg Then

                        DArCA.DHeight = DcaAr(j).DHeight
                        DArCA.DLengths = DcaAr(j).DLengths
                        DArCA.DWidth = DcaAr(j).DWidth

                        DArCA.DStrtPt.x = DnApt.DCntPt.X
                        DArCA.DStrtPt.y = DnApt.DCntPt.Y
                        DArCA.DStrtPt.z = DnApt.DCntPt.Z

                        'DcaAr(j).DStrtPt.x = DArCA.DStrtPt.x
                        'DcaAr(j).DStrtPt.y = DArCA.DStrtPt.y
                        'DcaAr(j).DStrtPt.z = DArCA.DStrtPt.z

                        dB.DHeight = DArCA.DHeight                   'DnApt.DHeight = DArCA.DHeight
                        dB.DLengths = DArCA.DLengths                 'DnApt.DLengths = DArCA.DLengths
                        dB.DWidth = DArCA.DWidth                     'DnApt.DWidth = DArCA.DWidth

                        DnApt.DLengths = DcaArc.DLengths - DnApt.DStrtPt.y          'Reamining container present LWH calculated
                        DnApt.DWidth = DcaArc.DWidth - DnApt.DStrtPt.x
                        DnApt.DHeight = DcaArc.DHeight - DnApt.DStrtPt.z

                    End If

                    'DsStop

                    Dim DImgName As String = "1"

                    '####################################################################

                    Dim DArItm() As CDArea
                    Dim DAri2() As String
                    Dim DArwt2() As Single
                    Dim DTranspArr2() As Boolean

                    ReDim DArItm(0)
                    ReDim DAri2(0)
                    ReDim DArwt2(0)
                    ReDim DTranspArr2(0)

                    'DDDStop

                    For L As Integer = Dcpt.DmQty + 1 To DNos - 1

                        DcaAr(L).DStrtPt.x = DArCA.DStrtPt.x
                        DcaAr(L).DStrtPt.y = DArCA.DStrtPt.y
                        DcaAr(L).DStrtPt.z = DArCA.DStrtPt.z

                    Next

                    For M As Integer = Dcpt.DmQty + 1 To DNos - 1

                        DArItm(UBound(DArItm)) = DcaAr(M)
                        DAri2(UBound(DAri2)) = DcaAri(M)
                        DArwt2(UBound(DArwt2)) = ArWt(M)
                        DTranspArr2(UBound(DTranspArr2)) = TranspArr(M)

                        ReDim Preserve DArItm(UBound(DArItm) + 1)
                        ReDim Preserve DAri2(UBound(DAri2) + 1)
                        ReDim Preserve DArwt2(UBound(DArwt2) + 1)
                        ReDim Preserve DTranspArr2(UBound(DTranspArr2) + 1)
                        ReDim Preserve TopUp(UBound(TopUp) + 1)
                    Next

                    ReDim Preserve DArItm(UBound(DArItm) - 1)
                    ReDim Preserve DAri2(UBound(DAri2) - 1)
                    ReDim Preserve DArwt2(UBound(DArwt2) - 1)
                    ReDim Preserve DTranspArr2(UBound(DTranspArr2) - 1)

                    'DDDStop

                    'siSW.Close()

                    'Stop

                    If j > 0 Then
                        If DcaAri(j) <> DcaAri(j - 1) Then
                            DImgName = (CInt(DImgName) + 1).ToString
                        End If
                    End If

                    'Stop

                    Dim K As Integer = Dcpt.DmQty + 1

                    'Dim DColCA As String = "b"

                    If DrawOpt Then
                        If K > 0 Then

                            If DcaAri(K - 1) <> DcaAri(K) Then

                                If ColCA = "r" Then
                                    ColCA = "g"
                                ElseIf ColCA = "g" Then
                                    ColCA = "b"
                                ElseIf ColCA = "b" Then
                                    ColCA = "m"
                                ElseIf ColCA = "m" Then
                                    ColCA = "c"
                                ElseIf ColCA = "c" Then
                                    ColCA = "y"
                                End If
                                QtyFlgCA = True
                            Else
                                QtyFlgCA = False
                            End If
                        End If
                    End If

                    'DsStop

                    'Implements From 19 July 2k8 

                    ''&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

                    '' CDLst = DrmCrsStuffArngmt(DcaArc, DcaAr, DcaAri, ArWt, SaveOpt, ShowEmpty, OutFile, DrawArc, TranspArr, TopUp, TxtOpt, DrawOpt, FindQtyFlg, ChngFlg, ColArr)

                    ''CDLst2 = DrumStuff(DcaArc, DcaAr, DcaAri, ArWt, SaveOpt, ShowEmpty, OutFile, True, TranspArr, TopUp, TxtOpt, DrawOpt, FindQtyFlg, ChngFlg, ColArr)

                    '#$#$#$CDLst2 = DrumStuffCANxt(DcaArc, DcaAr, DcaAri, ArWt, SaveOpt, ShowEmpty, OutFile, True, TranspArr, TopUp, TxtOpt, DrawOpt, FindQtyFlg, ChngFlg, DImgName, ColArr)

                    CDLst2 = DrumStuffCANxt(DcaArc, DArItm, DAri2, ArWt, SaveOpt, ShowEmpty, OutFile, True, TranspArr, TopUp, TxtOpt, DrawOpt, FindQtyFlg, ChngFlg, DImgName, ColArr)

                    ''CDLst2 = DrmCrsStuffArngmt(DcaArc, DcaAr, DcaAri, ArWt, SaveOpt, ShowEmpty, OutFile, True, TranspArr, TopUp, TxtOpt, DrawOpt, FindQtyFlg, ChngFlg, ColArr)

                    ''Public Function DrmCrsStuffArngmt(ByVal DcaArc As CDArea, ByVal DcaAr() As CDArea, ByVal DcaAri() As String, ByVal ArWt() As Single, ByVal SaveOpt As Boolean, ByVal ShowEmpty As Boolean, ByVal OutFile As String, ByVal DrawArc As Boolean, ByVal TranspArr() As Boolean, ByVal TopUp() As Boolean, ByVal TxtOpt As Boolean, ByVal DrawOpt As Boolean, ByVal FindQtyFlg As Boolean, ByVal ChngFlg As Boolean, ByVal ColArr As List(Of List(Of Byte))) As List(Of CDArea)

                    ''&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

                    ''&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

                    ''&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

                    ''&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

                    'End If

                    'DsStop

                    'siSW.Close()

                    'DsStop

                    '#############

                    Return CDLst

                    Exit Function


                End If



                '^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

                '******************************************************************************************
                'Direct:

                '                If flgNxtArg Then

                '                    DQCA = ArtCA.DrumSubtractDHD(DcaAr(j))

                '                End If

                'DHDQ = ArtCA.DrumSubtractDHD(DcaAr(j))          'Q = Art.Subtract(Ar(j))                'impliment

                '######  DQCA = ArtCA.DrumSubtractDHD(DcaAr(j))          'Q = Art.Subtract(Ar(j))                'impliment

                '8sd
                'DDStop

                Dim Dd As New CDArea

                If Not DQCA Is Nothing Then
                    If CDLst.Count = 0 Then
                        Do While Not DQCA.Count = 0

                            Dd = DQCA.Dequeue

                            CDLst.Add(Dd)

                        Loop
                    Else
                        Do While DQCA.Count > 0
                            ArbCA = DQCA.Dequeue
                            Ans1CA = False

                            'Stop

                            CDLst = DHDUnPush(CDLst, ArbCA) 'CDLst = UnPush(CDLst, Arb)         impliment

                            'Stop

                        Loop

                        'Stop

                    End If

                End If

                Dim Ans2 As Boolean

                For i As Integer = 0 To CDLst.Count - 1

                    Dim Arx As New CDArea

                    Arx = CDLst(i)

                    CDLst = DHVMrgX(CDLst, Arx, Ans2)       'CDLst = MrgX(CDLst, Arx, Ans2)             impliment

                    '9sd

                    'Stop

                    If Ans2 Then
                        Exit For
                    End If


                Next

                'Stop

                Dim StR1n1 As New StructR1

                Dim CDAnn As New CDArea

                CDAnn.DLengths = DcaAr(j).DLengths
                CDAnn.DWidth = DcaAr(j).DWidth
                CDAnn.DHeight = DcaAr(j).DHeight
                CDAnn.DStrtPt.x = DcaAr(j).DStrtPt.x
                CDAnn.DStrtPt.y = DcaAr(j).DStrtPt.y
                CDAnn.DStrtPt.z = DcaAr(j).DStrtPt.z

                StR1n1.Ar = CDAnn
                StR1n1.Method = IICA
                StR1n1.ItmNm = DcaAri(j)

                Dim Lstmmm As New List(Of CDArea)

                For Kk As Integer = 0 To CDLst.Count - 1
                    Lstmmm.Add(CDLst(Kk))
                Next

                'Stop

                'siSW.Close()


                StR1n1.R1CDLst = Lstmmm

                LstR1StArr.Add(StR1n1)

                j += 1


LP:
            Loop

            DItemQtyCA = ItrQty

            'Fff()

            '$$$$$
            'DsStop
            '$$$$$

            If j > 0 Then
                E1StE2 = New StructE1
                E1StE2.Qty = DItemQtyCA
                E1StE2.ItmNm = DcaAri(j - 1)
            End If

            CDLstjCA = New List(Of CDArea)

            For jj As Integer = 0 To CDLst.Count - 1
                CDLstjCA.Add(CDLst(jj))
            Next

            E1StE2.E1StLst = CDLstjCA

            If DrawOpt Then
                'qtyarr.Add(E1StE2)
                DQtyArr.Add(E1StE2)
            End If

            DMaxQtyLstCA.Add(DItemQtyCA)

            'Form8.Close()
            TransactionsMenu.btnStatus.Visible = False
            TransactionsMenu.lblStatus.Visible = False

            Eventless()

            If UBound(DcaAr) >= j Then
                fullflag = True
            End If

            If FindQtyFlg Then
                CDLst.Clear()
                For i As Integer = 0 To CDLst.Count - 1                   ' impliment
                    If Not Drumchk1DHE(CDLst2CA(i), CDLst) Then
                        If Not Drumchk11DHE(CDLst2CA(i), CDLst) Then
                            CDLst.Add(CDLst2CA(i))
                        End If
                    End If
                Next
            End If

            If DrawOpt Then
                If UBound(DcaAri) <> -1 Then
                    TmpLstCA.Add(DcaAri(j - 1))
                    TmpLstCA.Add(CStr(TotArCA))
                    DAreaArrCA.Add(TmpLstCA)
                End If
            End If

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in DrmCrsStuffArngmt" & vbCrLf & "Data Stuffing failure!", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'Application.Exit()
        Finally

            connDrums.Close()
        End Try

        If DrawOpt Or DrawArc Then
        End If
        QtyFlgCA = True
        connDrums.Dispose()
        connDrums.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\Drums.mdb;Persist Security Info=False"
        connDrums.Open()

        Return CDLst

    End Function

#End Region

#Region "Routine Definition"

    Public Sub GapVisibleT()

        TransactionsMenu.lblGf.Visible = True
        TransactionsMenu.lblGp.Visible = True
        TransactionsMenu.lblGi.Visible = True
        TransactionsMenu.lblGc.Visible = True
        TransactionsMenu.lblGm.Visible = True
        TransactionsMenu.lblDrn.Visible = True
        TransactionsMenu.btnDirection.Visible = True
        TransactionsMenu.txtGapf.Visible = True
        TransactionsMenu.txtGapi.Visible = True
        TransactionsMenu.txtGapc.Visible = True
        TransactionsMenu.txtGapm.Visible = True

    End Sub

    Public Sub SARDel()

        Try
            If connDrums.State = ConnectionState.Closed Then connDrums.Open()

            Dim CmdSAd As New OleDb.OleDbCommand
            Try
                CmdSAd.Connection = connDrums
                CmdSAd.CommandText = "delete from SArngmt"
                CmdSAd.ExecuteNonQuery()
            Catch e As Exception
                connDrums.Dispose()
                connDrums.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\Drums.mdb;Persist Security Info=False"
                connDrums.Open()
                CmdSAd.Cancel()
                CmdSAd.Connection = Nothing
                CmdSAd.Connection = connDrums
                CmdSAd.CommandText = ""
                CmdSAd.CommandText = "delete from SArngmt"
                CmdSAd.ExecuteNonQuery()

            Finally
                connDrums.Close()
            End Try
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in SARDel", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            siSW.Close()
            connDrums.Close()
        End Try

    End Sub

    Public Sub CARDel()

        Try
            If connDrums.State = ConnectionState.Closed Then connDrums.Open()

            Dim CmdSAd As New OleDb.OleDbCommand
            Try
                CmdSAd.Connection = connDrums
                CmdSAd.CommandText = "delete from CArngmt"
                CmdSAd.ExecuteNonQuery()
            Catch Ex As Exception
                connDrums.Dispose()
                connDrums.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\Drums.mdb;Persist Security Info=False"
                connDrums.Open()
                CmdSAd.Cancel()
                CmdSAd.Connection = Nothing
                CmdSAd.Connection = connDrums
                CmdSAd.CommandText = ""
                CmdSAd.CommandText = "delete from CArngmt"
                CmdSAd.ExecuteNonQuery()

                MsgBox(Ex.Message, MsgBoxStyle.Critical, "Error in 'CARDel'")
            End Try
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in CARDel", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            connDrums.Close()
            siSW.Close()
        End Try

    End Sub

    Public Sub DbCrsStuff(ByVal Fn As String, ByVal Col As String, ByVal Transpx As Single, ByVal Tex As String, ByVal ItmNm As String, ByVal Wt As Single, ByVal QtyFlg As Boolean, ByVal TxtOpt As Boolean, ByVal MatName As String, ByVal Method As Integer, ByVal DataOpt As Boolean, ByVal ShapeOpt As String, ByVal DDia As Double, ByVal DRds As Double, ByVal DHt As Double)

        CARDel()

        Dim S As Integer = 1

        Dim EXx As Double

        Try

            If ConDrm.State = ConnectionState.Closed Then ConDrm.Open()
            Dim CmdE As New OleDb.OleDbCommand
            Dim RdrE As OleDb.OleDbDataReader
            CmdE.Connection = ConDrm

            CmdE.CommandText = "select CL, CW, CH, Xx, Zz, Yy, Rr, DGM from SArngmt where DGM = 1"
            RdrE = CmdE.ExecuteReader

            Dim X As Double
            Dim Y As Double
            Dim Z As Double
            Dim L As Double
            Dim W As Double
            Dim H As Double
            Dim R As Double
            Static dGM As Short
            Static dupDgm As Short = 0

            Dim Flg As Boolean = False

            Do While (RdrE.Read())

                L = RdrE("CL")

                W = RdrE("CW")

                H = RdrE("CH")

                X = RdrE("Xx")

                Z = RdrE("Zz")

                Y = RdrE("Yy")

                R = RdrE("Rr")

                dGM = RdrE("DGM")

                IExtract(X, Y, Z, R, L, W, H, dGM)           '1 Insert value to CArngmt database

            Loop

            RdrE.Close()
            ConDrm.Close()

            If ConDrm.State = ConnectionState.Closed Then ConDrm.Open()
            Dim CmdEx As New OleDb.OleDbCommand
            Dim RdrEx As OleDb.OleDbDataReader
            CmdEx.Connection = ConDrm

            CmdEx.CommandText = "select CL, CW, CH, Xx, Zz, Yy, Rr from SArngmt where DGM = 1"
            RdrEx = CmdE.ExecuteReader

            Do While (RdrEx.Read())

                L = RdrEx("CL")

                W = RdrEx("CW")

                H = RdrEx("CH")

                X = RdrEx("Xx")

                X = X + (R * 2)

                Z = RdrEx("Zz")

                Y = RdrEx("Yy")

                R = RdrEx("Rr")

                IExtract(X, Y, Z, R, L, W, H, dupDgm)           '2 Insert value to CArngmt database

            Loop

            RdrEx.Close()
            ConDrm.Close()

            EXx = X + (R * 2)

            If Not EXx < W Then
                Exit Sub
            End If

            RdrEx.Close()

nxtCA:

            S += 1

            If ConDrm.State = ConnectionState.Closed Then ConDrm.Open()
            Dim CmdEx1 As New OleDb.OleDbCommand
            Dim RdrEx1 As OleDb.OleDbDataReader
            CmdEx1.Connection = ConDrm

            CmdEx1.CommandText = "select CL, CW, CH, Xx, Zz, Yy, Rr from SArngmt where DGM = 1"
            RdrEx1 = CmdE.ExecuteReader

            Do While (RdrEx1.Read())

                L = RdrEx1("CL")

                W = RdrEx1("CW")

                H = RdrEx1("CH")

                X = RdrEx1("Xx")

                X = X + (R * 2) * S

                Z = RdrEx1("Zz")

                Y = RdrEx1("Yy")

                R = RdrEx1("Rr")

                IExtract(X, Y, Z, R, L, W, H, dupDgm)           '3... Insert value to CArngmt database

            Loop

            RdrEx1.Close()

            EXx = X + (R * 2)

            If Not EXx < W Then

                FrCaYca = Y

                Exit Try
            End If
            GoTo nxtCA

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in DbCrsStuff", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally

            ConDrm.Close()

        End Try

    End Sub

    Public Sub IExtract(ByVal Xe As Double, ByVal Ye As Double, ByVal Ze As Double, ByVal Rr As Double, ByVal CL As Double, ByVal CW As Double, ByVal CH As Double, ByVal Dgm As Integer)
        'DDStop
        P += 1
        Try

            If ConDrm.State = ConnectionState.Closed Then ConDrm.Open()

            Dim CmdCA As New OleDb.OleDbCommand

            CmdCA.Connection = ConDrm
            CmdCA.CommandText = "insert into CArngmt (SrN, Xca, Zca, Yca, Rdca, CL, CW, CH, DGM) values (" & CStr(P) & "," & CStr(Xe) & "," & CStr(Ze) & "," & CStr(Ye) & "," & CStr(Rr) & "," & CStr(CL) & "," & CStr(CW) & "," & CStr(CH) & "," & CStr(Dgm) & ")"
            CmdCA.ExecuteNonQuery()
        Catch Ex As Exception
            ConDrm.Close()
            siSW.Close()
            connDrums.Close()
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in IExtract" & vbCrLf & "Data insert connection failure!", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'MsgBox("Exception :: In Method 'Extract'  " & vbCrLf & "Data insert connection failure!")
        End Try
    End Sub

    '(DCPt.DCntPt.X, DCPt.DCntPt.Y, DCPt.DCntPt.Z, DCPt.DHeight, DCPt.DRadius, CL, CW, CH, PsHt, PsDR)

    Public Sub DCA_PullValY(ByVal Xca As Double, ByVal Yca As Double, ByVal Zca As Double, ByVal CtHt As Double, ByVal CtRds As Double, ByVal CL As Double, ByVal CW As Double, ByVal CH As Double, ByVal PsHt As Double, ByVal PsRds As Double)

        Stop

        Try

            If ConDrm.State = ConnectionState.Closed Then ConDrm.Open()
            Dim CmdEx1 As New OleDb.OleDbCommand
            Dim CmdE As New OleDb.OleDbCommand
            Dim RdrEx1 As OleDb.OleDbDataReader
            CmdEx1.Connection = ConDrm

            'CmdEx1.CommandText = "select CL, CW, CH, Xx, Zz, Yy, Rr from SArngmt where DGM = 1"
            CmdEx1.CommandText = "Select Max(Yy) from DrumStuffCA where Yy < " & CStr(Yca)
            RdrEx1 = CmdEx1.ExecuteReader

            Do While (RdrEx1.Read())

                'L = RdrEx1("CL")

                'W = RdrEx1("CW")

                'H = RdrEx1("CH")

                'X = RdrEx1("Xx")

                'X = X + (R * 2) * S

                'Z = RdrEx1("Zz")

                'Y = RdrEx1("Yy")

                'R = RdrEx1("Rr")



            Loop

            RdrEx1.Close()


        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in DCA_PullValY", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

#End Region

  End Module
