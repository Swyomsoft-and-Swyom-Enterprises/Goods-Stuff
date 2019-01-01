
'Program Name: -    DrmCANxtMdl.vb
'Programmer Name: - Satwadhir B. Pawar Mob No. :- 9323974665
'Company Name:-     Hazel Infotech LTD. Mumbai
'Project Name: -    P-Stuff Plus (Container Stuffing)
'Date: -            23 Dec 2K8 5.46 PM (Modified Time)

'Tips: - The code is debugging at that particular dimensions, quantity and sequence.
'        you are decide it the logic happen is correct to that way or its are some 
'        different way the understanding to at your best level is the correct logic 
'        of this particular code block.

'Description: - DrmCANxtMdl is the drum cross arrangement next item placed stuffing
'               module which is the various routine and function which places the cross 
'               arrangement of drum (cylinder) geometry.

#Region " Importing object "

Imports DrmMPtCA
Imports System

#End Region

Module DrmCANxtMdl

#Region " Module Declaration "

    Dim DArD As New CDrum
    Dim CmdB As New OleDb.OleDbCommand

    Dim Drm As New CDrum                      ' for Drum dimensions

    Public DmPt As New DrmGMPt()         'cross arrangement point  using DGmPtCA.dll

    Public Xg As Double = 0
    Public Yg As Double = 0
    Public Zg As Double = 0

    Public FRFlg As Boolean = False

    Dim DAnsW As MsgBoxResult
    Dim DOcc As Integer
    Dim DOccLst As New List(Of Integer)
    Dim DOptLst As New List(Of StructOcc1)

    '$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

    Dim QOccLst As New List(Of Integer)
    Dim QOcc As Integer

#End Region

#Region " Function Definition "

    Public Function DrumStuffCANxt(ByVal DArc As CDArea, ByVal DAR() As CDArea, ByVal DAri() As String, ByVal ArWt() As Single, ByVal SaveOpt As Boolean, ByVal ShowEmpty As Boolean, ByVal OutFile As String, ByVal DrawArc As Boolean, ByVal TranspArr() As Boolean, ByVal TopUp() As Boolean, ByVal TxtOpt As Boolean, ByVal DrawOpt As Boolean, ByVal FindQtyFlg As Boolean, ByVal ChngFlg As Boolean, ByVal ImgName As String, ByVal ColArr As List(Of List(Of Byte))) As List(Of CDArea)

        'Impliments from here 18 july 2k8

        'Stop

        Dim CDLst2 As New List(Of CDArea)
        Dim CDStk As New Stack(Of CDArea)
        Dim ArM As New List(Of Integer)
        Dim LstM As New List(Of CDArea)
        Dim TmpLst As New List(Of String)
        Dim CDLstj As New List(Of CDArea)

        Dim A1 As New CDArea
        Dim A2 As New CDArea

        Dim ARDrum As New CDrum
        'Dim DAR() As CDrum
        'Dim DrmArea() As CDrum = Nothing               'for ByVal AR() As CDArea

        Dim ArT As New CDArea
        Dim DArT As New CDrum
        Dim ArP As New CDArea
        Dim ArE As New CDArea
        Dim ArU As New CDArea
        Dim ArB As New CDArea
        Dim DArB As New CDrum

        Dim ArM1 As Integer
        Dim IID As Integer
        Dim DTraval As Single

        Dim SzChg As Integer = 0

        Dim QtyFlg As Boolean = True
        Dim DHDAns1 As Boolean

        Dim OrdR As Integer
        Dim Col As String = Nothing
        Dim ToTAr As Double
        Dim OldItemQty As Integer = 0

        Try

            If SaveOpt Then
                configid = InputBox("Enter Config Id")
            End If

            Dim CrPtx As New CDrum                'Dim Ptx As New CDPoint

            CrPtx.DStrtPt.x = DArc.DLengths        'Ptx.x = Arc.DLengths
            CrPtx.DStrtPt.y = DArc.DWidth          'Ptx.y = Arc.DWidth
            CrPtx.DStrtPt.z = DArc.DHeight         'Ptx.z = Arc.DHeight

            'Stop

            Dim Col1 As New List(Of Byte)
            Col1.Clear()
            Col1.Add(255)
            Col1.Add(255)
            Col1.Add(255)

            'Col = "1"
            Dim ItmNm As String = ""

            If DrawArc Then
                Dim Ard1 As New CDArea
                If DrawArc Then
                End If

                DArD.DStrtPt.x = DArc.DLengths
                DArD.DStrtPt.y = 0
                DArD.DStrtPt.z = 0
                DArD.DLengths = 0.5
                DArD.DWidth = DArc.DWidth
                DArD.DHeight = DArc.DHeight

                If DrawOpt Or DrawArc Then

                End If

                Ard1.DStrtPt.x = DArc.DLengths - 0.01
                Ard1.DStrtPt.y = 0
                Ard1.DStrtPt.z = 0
                Ard1.DLengths = 0.5
                Ard1.DWidth = DArD.DWidth
                Ard1.DHeight = DArD.DHeight
            End If

            'Stop

            If DrawOpt Or DrawArc Then
                Col1.Clear()
            End If

            If SaveOpt Then
                CmdB.Connection = connDrums
Repeat:

                Try
                    CmdB.ExecuteNonQuery()

                Catch Ex As Exception
                    If Ex.Message = "Cannot open any more tables." Then
                        connDrums.Close()
                        connDrums.Dispose()
                        OleDb.OleDbConnection.ReleaseObjectPool()
                        CmdB.Dispose()
                        GC.Collect()

                        connDrums.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\Drums.mdb;Persist Security Info=False"

                        connDrums.Open()
                        GoTo Repeat
                    End If
                End Try
                id1 += 1

            End If

            DArc.DStrtPt.x = 0
            DArc.DStrtPt.y = 0
            DArc.DStrtPt.z = 0

            Dim j As Integer = 0
            ToTAr = 0
            DrmAreaArrSA.Clear()

            'Stop

            For i As Integer = 0 To CDLst.Count - 1
                CDLst2.Add(CDLst(i))
            Next

            DItemQtySa = 0
            DtotwtSA = 0

            If Not IsNothing(DAri) Then
                'Progress8.Show()
                TransactionsMenu.lblStatus.Visible = True
                TransactionsMenu.lblStatusINm.Visible = True

                If DrawOpt Then
                    Progress8.btnStatus.Visible = False
                    TransactionsMenu.btnStatus.Visible = False

                End If
                'Progress8.Focus()
                TransactionsMenu.lblStatus.Focus()
                TransactionsMenu.lblStatusINm.Focus()
            End If

            For i As Integer = 0 To DqtylstSA.Count - 1
                DplclstSA.Add(DqtylstSA(i) - 1)
            Next

            fullflag = False
            OldItemQty = 0

            'Dim ImgName As String = "1"

            'Stop

            Do While Not CDLst.Count = 0 And j <= UBound(DAR)

                If j > 0 Then
                    If DAri(j) <> DAri(j - 1) Then
                        ImgName = (CInt(ImgName) + 1).ToString
                    End If
                End If

                OrdR = 0

                If chkwt Then
                    DtotwtSA += ArWt(j)
                    If DtotwtSA >= contcap Then

                        DAnsW = MsgBox("Maximum weight capacity of the container is reached" & vbCrLf & "Do you want to proceed?", MsgBoxStyle.YesNo)

                        If DAnsW = MsgBoxResult.No Then
                            fullflag = True

                            Exit Do

                        Else
                            fullflag = False
                            chkwt = False
                        End If

                    End If
                End If

                '+++++++++++++++++++++++++++++++++++++

                If j = 0 Then
                    Col = DstrtclrSA
                End If
                If j > 0 And Not IsNothing(DAri) Then
                    If DAri(j - 1) <> DAri(j) Then
                        E1StE2 = New StructE1
                        E1StE2.Qty = DItemQtySa
                        E1StE2.ItmNm = DAri(j - 1)
                        CDLstj = New List(Of CDArea)
                        For jj As Integer = 0 To CDLst.Count - 1
                            CDLstj.Add(CDLst(jj))
                        Next

                        E1StE2.E1StLst = CDLstj
                        If DrawOpt Then
                            DQtyArr.Add(E1StE2)
                        End If
                        If DqtylstSA.Count > 0 Then

                        End If

                        DMaxQtyLst.Add(DItemQtySa)

                        TransactionsMenu.lblStatusINm.Text = "  Stuffing item : " & DAri(j)
                        TransactionsMenu.lblStatusINm.Refresh()
                    Else

                        TransactionsMenu.lblStatusINm.Text = "  Stuffing item : " & DAri(j)
                        TransactionsMenu.lblStatusINm.Refresh()
                    End If
                Else
                    If j > 0 Then
                        TransactionsMenu.lblStatusINm.Visible = True
                        If DrawOpt Then
                            TransactionsMenu.btnStatus.Visible = True
                            'Form8.Button1.Visible = False
                        End If
                        TransactionsMenu.lblStatusINm.Text = "Finding Maximum Quantity...."
                        TransactionsMenu.lblStatusINm.Refresh()
                    End If
                End If

                '+++++++++++++++++++++++++++++++++++++

                'Col = "g"

                'Stop
                If DrawOpt Then
                    If j > 0 Then

                        If DAri(j - 1) <> DAri(j) Then

                            DItemQtySa = 0

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

                            SzChg += 1

                            QtyFlg = True

                        Else
                            QtyFlg = False
                        End If
                    End If
                End If

                If SzChg <> 2 Then

                Else

                End If

                'DStop

                'The start manupulation***********************************************************

                ArM1 = DrumFindOptDHD(CDLst, DAR(j), TopUp(j))

                'DStop

                'siSW.Close()

                ArT = Nothing
                DArT = Nothing
                If ArM1 <> -1 Then
                    ArT = CDLst(ArM1)
                End If

                Dim ArN As New List(Of Integer)
                Dim Lstn As New List(Of CDArea)

                Dim B1 As New CDArea
                Dim B2 As New CDArea
                Dim Pos1 As Integer

                ArM = Nothing
                ArN = Nothing

                'DStop

                ArN = DrumFindCandidate1DHD(CDLst, DAR(j), TopUp(j))

                'DStop

                Pos1 = 0
                If Not ArN Is Nothing Then
                    Pos1 = 0
                Else

                    Dim ARxX As New CDrum                   'The drum class inherits from CDArea

                    ARxX.DLengths = DAR(j).DWidth
                    ARxX.DWidth = DAR(j).DLengths
                    ARxX.DHeight = DAR(j).DHeight
                    ARxX.DRadius = DAR(j).DRadius

                    ArN = DrumFindCandidate1DHD(CDLst, ARxX, TopUp(j))

                    '****************************
                    'DStop
                    '****************************

                    If Not ArN Is Nothing Then
                        Pos1 = 1
                    Else
                        If Not TopUp(j) Then
                            ARxX.DLengths = DAR(j).DLengths
                            ARxX.DWidth = DAR(j).DHeight
                            ARxX.DHeight = DAR(j).DWidth
                            ARxX.DRadius = DAR(j).DRadius

                            ArN = DrumFindCandidate1DHD(CDLst, ARxX, False)

                            If Not ArN Is Nothing Then
                                Pos1 = 2
                            End If
                        End If
                    End If
                End If

                'DStop

                If ArN Is Nothing Then

                    ArM = DHDFindCandidateDrum(CDLst, DAR(j))        'ArM = DrumFindCandidateDHE(CDLst, Ar(j))

                    '****************************
                    'DStop
                    '****************************

                    If Not ArM Is Nothing Then
                        If ArM(0) = ArM1 Then ArM = Nothing
                    End If
                End If

                If Not ArM Is Nothing Then

                    '555555555555555555555555555555555
                    'DStop
                    '555555555555555555555555555555555

                    LstM = DrmUnionItrPtDHD(CDLst(ArM(0)), CDLst(ArM(1)))

                    'DStop

                    A1 = LstM(0)
                    A2 = LstM(1)
                End If

                If Not ArN Is Nothing Then

                    'DStop

                    LstM = DrmUnionItrPtDHD(CDLst(ArM(0)), CDLst(ArM(1))) 'LstM = DrumUnionItrPDHE(CDLst(Arn(0)), CDLst(Arn(1)))

                    B1 = LstM(0)
                    B2 = LstM(1)
                End If

                If ArM Is Nothing And ArM1 = -1 Then
                    If DrawOpt Then

                    End If

                    For m As Integer = j To UBound(DAri) - 1

                        If DAri(m) <> DAri(j) Then
                            j = m

                            GoTo dLP

                        End If
                    Next

                    j = UBound(DAri) + 1

                    GoTo DLP

                Else

                    If ArN Is Nothing And ArM1 = -1 Then

                        If DrawOpt Then

                        End If

                        For m As Integer = j To UBound(DAri) - 1
                            If DAri(m) <> DAri(j) Then
                                j = m
                                GoTo DLP

                            End If
                        Next

                        j = UBound(DAri)

                    End If
                End If

                If Not ArM Is Nothing Or Not ArN Is Nothing Then

                    CmdB.Connection = connDrums

                    DeleteTable("DTemp2")
z:
                    OrdR = 0
                    If Not ArM Is Nothing Then

                        DInsertTable("DTemp2", New Object() {CStr(A1.DStrtPt.x), CStr(A1.DStrtPt.y), CStr(A1.DStrtPt.z), CStr(1)})
                    End If

                    If Not ArN Is Nothing Then
                        DInsertTable("DTemp2", New Object() {CStr(B1.DStrtPt.x), CStr(B1.DStrtPt.y), CStr(B1.DStrtPt.z), CStr(2)})

                    End If

                    If Not ArT Is Nothing Then
                        DInsertTable("DTemp2", New Object() {CStr(ArT.DStrtPt.x), CStr(ArT.DStrtPt.y), CStr(ArT.DStrtPt.z), CStr(3)})

                    End If

                    Dim Rwx As DataRow() = Nothing

                    Try
                        If Not ArM Is Nothing Then

                            Rwx = DGetf("DTemp2", "", "z DESC ,x ASC,y ASC")
                        End If

                        If Not ArN Is Nothing Then

                            Rwx = DGetf("DTemp2", "", "z DESC ,x ASC,y ASC")
                        End If

                        If ArN Is Nothing And ArM Is Nothing Then

                            Rwx = DGetf("DTemp2", "", "z DESC ,x ASC")
                        End If

                        If ArM Is Nothing And ArN Is Nothing Then

                            Rwx = DGetf("DTemp2", "", "z DESC ,x ASC,y ASC")
                        End If

                    Catch Ex As Exception
                        MsgBox(Ex.Message)
                        MsgBox(Ex.ToString)
                        MessageBox.Show("Error in DGetf on DrumStuff", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        'DialogBox.DisplayError(this, "An unknown error has occured", Ex.StackTrace
                    Finally
                        OrdR = Rwx(0)("i")
                    End Try

                    If OrdR = 3 Then
                        CDLst.RemoveAt(ArM1)
                    Else
                        If OrdR = 1 Then
                            ArT = A1
                            CDLst.RemoveAt(ArM(0))
                            If ArM(0) < ArM(1) Then
                                CDLst.RemoveAt(ArM(1) - 1)
                            Else
                                CDLst.RemoveAt(ArM(1))
                            End If

                            'DStop
                            CDLst = DHDUnPush(CDLst, A2)         ' CDLst = UnPushDrumDHD(CDLst, A2)  'CDLst = DrumUnPushDHE(CDLst, A2)

                        End If
                        If OrdR = 2 Then
                            If Pos1 = 1 Then
                                Dim tmp As Double = DAR(j).DWidth
                                DAR(j).DWidth = DAR(j).DLengths
                                DAR(j).DLengths = tmp
                            End If

                            If Pos1 = 2 Then
                                Dim tmp As Double = DAR(j).DHeight
                                DAR(j).DHeight = DAR(j).DWidth
                                DAR(j).DWidth = tmp
                            End If

                            ArT = B1
                            CDLst.RemoveAt(ArN(0))
                            If ArN(0) < ArN(1) Then
                                CDLst.RemoveAt(ArN(1) - 1)
                            Else
                                CDLst.RemoveAt(ArN(1))
                            End If

                            CDLst.Add(B2)

                        End If
                        If OrdR = 3 Then
                            CDLst.RemoveAt(ArM1)
                        End If
                    End If
                Else

                    If ArM1 <> -1 Then
                        CDLst.RemoveAt(ArM1)
                    End If
                End If

                Dim Qty As Integer
                If ChngFlg Then
                    '######
                    'DStop
                    '########
                    'IID = DrumFindOptMethodDHE(Ar(j), ArT, Qty, TopUp(j))

                    IID = DHDFindOptMethodDrum(DAR(j), ArT, Qty, TopUp(j))

                    'DStop

                    If DOcc > 1 Then

                        Dim OccLst1 As New List(Of Integer)

                        For i As Integer = 0 To DOccLst.Count - 1
                            OccLst1.Add(DOccLst(i))
                        Next

                        Dim Strctm1 As New StructOcc1

                        Strctm1.j = j
                        Strctm1.j1 = OccLst1
                        Strctm1.CDLstSt = CDLst
                        DOptLst.Add(Strctm1)
                    End If

                    Drm.DLengths = DAR(j).DLengths              'Dim Dln As Double = Ar(j).DLengths
                    Drm.DWidth = DAR(j).DWidth                  'Dim Dwd As Double = Ar(j).DWidth
                    Drm.DHeight = DAR(j).DHeight                'Dim Dht As Double = Ar(j).DHeight
                    Drm.DRadius = DAR(j).DRadius                 'Dim Drds As Double = Ar(j).DRadius

                    ARDrum.DLengths = DAR(j).DLengths        'Value are transfered to CDrum 
                    ARDrum.DWidth = DAR(j).DWidth
                    ARDrum.DHeight = DAR(j).DHeight
                    ARDrum.DRadius = DAR(j).DRadius

                    'DStop

                    Dim Nm As String = DAri(j)
                    Dim P As Integer = j

                    If IID = 1 Then

                        DAR(P).DLengths = Drm.DLengths
                        DAR(P).DWidth = Drm.DWidth
                        DAR(P).DHeight = Drm.DHeight
                        DAR(P).DRadius = Drm.DRadius

                        ARDrum.DLengths = Drm.DLengths
                        ARDrum.DWidth = Drm.DWidth
                        ARDrum.DHeight = Drm.DHeight
                        ARDrum.DRadius = Drm.DRadius

                    End If

                    If IID = 2 Then

                        DAR(P).DLengths = Drm.DLengths        'Ar(P).DLengths = Dln
                        DAR(P).DWidth = Drm.DWidth            'Ar(P).DWidth = Dht
                        DAR(P).DHeight = Drm.DHeight          'Ar(P).DHeight = Dwd
                        DAR(P).DRadius = Drm.DRadius

                        ARDrum.DLengths = Drm.DLengths
                        ARDrum.DWidth = Drm.DWidth
                        ARDrum.DHeight = Drm.DHeight
                        ARDrum.DRadius = Drm.DRadius

                    End If

                    If IID = 3 Then

                        DAR(P).DLengths = Drm.DLengths             'Ar(P).DLengths = Dwd
                        DAR(P).DWidth = Drm.DWidth                 'Ar(P).DWidth = Dht
                        DAR(P).DHeight = Drm.DHeight               'Ar(P).DHeight = Dln
                        DAR(P).DRadius = Drm.DRadius

                        ARDrum.DLengths = Drm.DLengths
                        ARDrum.DWidth = Drm.DWidth
                        ARDrum.DHeight = Drm.DHeight
                        ARDrum.DRadius = Drm.DRadius

                    End If

                    If IID = 4 Then

                        DAR(P).DLengths = Drm.DLengths            'Ar(P).DLengths = Dwd
                        DAR(P).DWidth = Drm.DWidth                'Ar(P).DWidth = Dln
                        DAR(P).DHeight = Drm.DHeight               'Ar(P).DHeight = Dht
                        DAR(P).DRadius = Drm.DRadius

                        ARDrum.DLengths = Drm.DLengths
                        ARDrum.DWidth = Drm.DWidth
                        ARDrum.DHeight = Drm.DHeight
                        ARDrum.DRadius = Drm.DRadius

                    End If

                    If IID = 5 Then

                        DAR(P).DLengths = Drm.DLengths              'Ar(P).DLengths = Dht
                        DAR(P).DWidth = Drm.DWidth                  'Ar(P).DWidth = Dwd
                        DAR(P).DHeight = Drm.DHeight                'Ar(P).DHeight = Dln
                        DAR(P).DRadius = Drm.DRadius

                        ARDrum.DLengths = Drm.DLengths
                        ARDrum.DWidth = Drm.DWidth
                        ARDrum.DHeight = Drm.DHeight
                        ARDrum.DRadius = Drm.DRadius

                    End If

                    If IID = 6 Then

                        DAR(P).DLengths = Drm.DLengths        'Ar(P).DLengths = Dht
                        DAR(P).DWidth = Drm.DWidth            'Ar(P).DWidth = Dln
                        DAR(P).DHeight = Drm.DHeight          'Ar(P).DHeight = Dwd
                        DAR(P).DRadius = Drm.DRadius

                        ARDrum.DLengths = Drm.DLengths
                        ARDrum.DWidth = Drm.DWidth
                        ARDrum.DHeight = Drm.DHeight
                        ARDrum.DRadius = Drm.DRadius

                    End If

                End If

                '##################################
                'DStop
                '##################################

                Dim Flg As Boolean = Math.Abs(((DAR(j).DLengths * DAR(j).DWidth * DAR(j).DHeight) * Qty) - (ArT.DLengths * ArT.DWidth * ArT.DHeight)) < 0.01

                'D.DmQty = DrumFindQtyDHD(DAri, j)         'Dim Mm As Integer = DrumFindQtyDHE(Ari, j)

                'From here implements 4 June 2K8


                Drm.DmQty = DrmQt.DFindQty(DAri, j)               'use DCalcQty.dll


                'DStop

                If Drm.DmQty >= Qty And Flg Then               'If Mm >= Qty And Flg Then

                    If DrawOpt Then

                        If TranspArr(j) Then
                            DTraval = 0.8
                        Else
                            DTraval = 0
                        End If

                        DAR(j).DStrtPt.x = ArT.DStrtPt.x            'DArT.DStrtPt.x = ArT.DStrtPt.x
                        DAR(j).DStrtPt.y = ArT.DStrtPt.y            'DArT.DStrtPt.y = ArT.DStrtPt.y
                        DAR(j).DStrtPt.z = ArT.DStrtPt.z            'DArT.DStrtPt.z = ArT.DStrtPt.z

                        'Remain as it is commented do not use
                        'Ar(j).AutoDraw(OutFile, Col, traval, "file:///c:/t2.png", Ari(j), ArWt(j), QtyFlg, TxtOpt, "", 0, True, "c")

                        j += Qty
                        DItemQtySa += Qty
                    Else
                        j += Qty

                        DItemQtySa += Qty
                        DplclstSA(DItemNoSA) = DItemQtySa
                        DtotwtSA += ArWt(j)
                        GoTo DLP
                    End If

                End If

                'DStop

                ArM = Nothing
                ArN = Nothing

                DAR(j).DStrtPt.x = ArT.DStrtPt.x        'DArT.DStrtPt.x = ArT.DStrtPt.x
                DAR(j).DStrtPt.y = ArT.DStrtPt.y        'DArT.DStrtPt.y = ArT.DStrtPt.y
                DAR(j).DStrtPt.z = ArT.DStrtPt.z        'DArT.DStrtPt.z = ArT.DStrtPt.z

                ARDrum.DStrtPt.x = ArT.DStrtPt.x
                ARDrum.DStrtPt.y = ArT.DStrtPt.y
                ARDrum.DStrtPt.z = ArT.DStrtPt.z

                If SaveOpt Then
DML:
                    Try
                        CmdB.ExecuteNonQuery()
                    Catch ec As Exception
                        If ec.Message = "Cannot open any more tables." Then
                            connDrums.Close()
                            connDrums.Dispose()
                            OleDb.OleDbConnection.ReleaseObjectPool()
                            CmdB.Dispose()
                            GC.Collect()

                            connDrums.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\Drums.mdb;Persist Security Info=False"

                            connDrums.Open()
                            GoTo DML
                        End If

                    End Try
                    id1 += 1
                End If

                If DrawOpt Then

                    If TranspArr(j) Then
                        DTraval = 0.8
                    Else
                        DTraval = 0
                    End If
                End If
                If j = UBound(DAR) Then

                End If
                If DrawOpt Then
                    If j <> 0 Then
                        If DAri(j) <> DAri(j - 1) Then
                            TmpLst.Add(DAri(j - 1))
                            TmpLst.Add(CStr(ToTAr))
                            DrmAreaArrSA.Add(TmpLst)
                            ToTAr = 0
                            ToTAr = ToTAr + (DAR(j).DLengths * DAR(j).DWidth * DAR(j).DHeight)
                        Else
                            ToTAr = ToTAr + (DAR(j).DLengths * DAR(j).DWidth * DAR(j).DHeight)
                        End If
                    Else
                        ToTAr = ToTAr + (DAR(j).DLengths * DAR(j).DWidth * DAR(j).DHeight)
                    End If
                End If

                'DStop

                '$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
                Dim Radius As Double = 0

                DDiaL = DAR(j).DLengths
                DDiaW = DAR(j).DWidth
                DRds = DAR(j).DRadius
                DHt = DAR(j).DHeight

                If DDiaL = DDiaW Then
                    DDia = DDiaL
                    Radius = DDia * 0.5
                    If Radius <> DRds Then
                        MessageBox.Show("The dimensioning adequacy in radius and diameter in simple arrangement", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If

                '$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

                If DrawOpt Then
                    TxtOpt = True

                    'Implement Here/ 10 April 2008 //Modified 26 May 2K8 2.51 PM

                    'Stop

                    'AR(j).AutoDrawDrmSADHE(OutFile, Col, DTraval, "s" & ImgName & ".png", Ari(j), ArWt(j), QtyFlg, TxtOpt, Ari(j), IID, True, "b", DDia, DRds, DHt)

                    ARDrum.AutoDrawDHDDrmSACA(OutFile, Col, DTraval, "s" & ImgName & ".png", DAri(j), ArWt(j), QtyFlg, TxtOpt, DAri(j), IID, True, "b", DDia, DRds, DHt)

                    'Stop

                    'siSW.Close()

                    If DqtylstSA.Count > 0 Then
                        DplclstSA(DrmRWidx) = DItemQtySa

                    End If

                    DItemQtySa += 1

                Else
                    DItemQtySa += 1
                    DtotwtSA += ArWt(j)
                End If
                If DqtylstSA.Count > 1 Then
                    DplclstSA(DrmRWidx) = DItemQtySa - 1
                    DMaxQtyLst.Add(DItemQtySa - 1)
                End If

                If Not IsNothing(DAri) Then
                    '*********************************************
                    'DStop
                    'siSW.Close()
                    Progress8.iQty = DItemQtySa
                    TransactionsMenu.lblStatus.Text = " Numbers ::   " & CStr(DItemQtySa) & "    -> Items stuffed"
                    TransactionsMenu.btnStatus.Visible = True

                    DEventful()
                    TransactionsMenu.pbCSPD.Visible = True
                    'PB()
                    DProgressBarRunning()

                    'siSW.Close()

                    If DItemQtySa > 50 Then
                        'Stop
                        'siSW.Close()
                    End If

                    TransactionsMenu.lblStatus.Refresh()
                    System.Windows.Forms.Application.DoEvents()
                    '*********************************************
                    If exflg Then
                        exflg = False
                        GoTo DLP
                    End If
                End If

                'DStop

                DHDQ = ArT.DrumSubtractDHD(DAR(j))

                'DStop

                Dim Dd As New CDArea

                If Not DHDQ Is Nothing Then

                    If CDLst.Count = 0 Then
                        Do While Not DHDQ.Count = 0

                            Dd = DHDQ.Dequeue

                            CDLst.Add(Dd)

                        Loop
                    Else
                        Do While DHDQ.Count > 0
                            ArB = DHDQ.Dequeue
                            DHDAns1 = False

                            CDLst = DHDUnPush(CDLst, ArB)

                            'impliment 8 May 2K8

                        Loop

                    End If

                End If

                Dim Ans2 As Boolean

                For i As Integer = 0 To CDLst.Count - 1

                    Dim Arx As New CDArea

                    Arx = CDLst(i)

                    'DStop

                    CDLst = DHVMrgX(CDLst, Arx, Ans2)

                    'DStop

                    If Ans2 Then
                        Exit For
                    End If

                Next

                '8 May 2K8 11.37 AM

                Dim StR1n1 As New StructR1

                Dim CDAnn As New CDArea

                CDAnn.DLengths = DAR(j).DLengths
                CDAnn.DWidth = DAR(j).DWidth
                CDAnn.DHeight = DAR(j).DHeight
                CDAnn.DStrtPt.x = DAR(j).DStrtPt.x
                CDAnn.DStrtPt.y = DAR(j).DStrtPt.y
                CDAnn.DStrtPt.z = DAR(j).DStrtPt.z

                StR1n1.Ar = CDAnn
                StR1n1.Method = IID
                StR1n1.ItmNm = DAri(j)

                Dim Lstmmm As New List(Of CDArea)

                For Kk As Integer = 0 To CDLst.Count - 1
                    Lstmmm.Add(CDLst(Kk))
                Next

                StR1n1.R1CDLst = Lstmmm

                LstR1StArr.Add(StR1n1)

                j += 1

DLP:
            Loop

            DrumFffDHE()

            '$$$$$
            'Stop
            '$$$$$
            If j > 0 Then
                E1StE2 = New StructE1
                E1StE2.Qty = DItemQtySa
                E1StE2.ItmNm = DAri(j - 1)
            End If

            CDLstj = New List(Of CDArea)

            For jj As Integer = 0 To CDLst.Count - 1
                CDLstj.Add(CDLst(jj))
            Next

            E1StE2.E1StLst = CDLstj

            If DrawOpt Then
                DQtyArr.Add(E1StE2)
            End If

            DMaxQtyLst.Add(DItemQtySa)

            'Form8.Close()
            TransactionsMenu.btnStatus.Visible = False
            TransactionsMenu.lblStatus.Visible = False
            TransactionsMenu.lblStatusINm.Visible = False
            TransactionsMenu.pbCSPD.Visible = False
            DEventless()

            If UBound(DAR) >= j Then
                fullflag = True
            End If

            If FindQtyFlg Then
                CDLst.Clear()
                For i As Integer = 0 To CDLst.Count - 1
                    If Not Drumchk1DHE(CDLst2(i), CDLst) Then
                        If Not Drumchk11DHE(CDLst2(i), CDLst) Then
                            CDLst.Add(CDLst2(i))
                        End If
                    End If
                Next
            End If

            If DrawOpt Then
                If UBound(DAri) <> -1 Then
                    TmpLst.Add(DAri(j - 1))
                    TmpLst.Add(CStr(ToTAr))
                    DrmAreaArrSA.Add(TmpLst)
                End If
            End If

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in DrumStuff" & vbCrLf & "Data Stuffing failure!", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            connDrums.Close()
            siSW.Close()
            'Application.Exit()
        Finally
            connDrums.Close()
        End Try

        If DrawOpt Or DrawArc Then

        End If
        QtyFlg = True
        connDrums.Dispose()
        connDrums.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\Drums.mdb;Persist Security Info=False"
        connDrums.Open()
        'Stop
        Return CDLst

    End Function

    Public Function DrumFindOptMethodCANxt(ByVal Ar1 As CDArea, ByVal Ar2 As CDArea, ByRef MaxQty1 As Integer, ByVal TpUp As Boolean) As Integer

        '$$$$$$$$$$$$$$$$
        'DDStop
        '$$$$$$$$$$$$$$$$

        Dim Di As New CDrum
        Dim Dc As New CDrum

        'The Quantity are always positive number
        Dim DQty1 As UInt32 = 0                         'Dim Dqty1 As Integer = 0
        Dim DQty2 As UInt32 = 0                         'Dim Dqty2 As Integer = 0
        Dim DQty3 As UInt32 = 0                         'Dim Dqty3 As Integer = 0
        Dim DQty4 As UInt32 = 0                         'Dim Dqty4 As Integer = 0
        Dim DQty5 As UInt32 = 0                         'Dim Dqty5 As Integer = 0
        Dim DQty6 As UInt32 = 0                         'Dim Dqty6 As Integer = 0

        Dim DQtyPos As String

        Try
            Di.DLengths = Ar1.DLengths                      'Dim Dln1 As Double = Ar1.DLengths
            Di.DWidth = Ar1.DWidth                          'Dim Dwd1 As Double = Ar1.DWidth
            Di.DHeight = Ar1.DHeight                        'Dim Dht1 As Double = Ar1.DHeight

            Dc.DLengths = Ar2.DLengths                      'Dim Dln2 As Double = Ar2.DLengths
            Dc.DWidth = Ar2.DWidth                          'Dim Dwd2 As Double = Ar2.DWidth
            Dc.DHeight = Ar2.DHeight                        'Dim Dht2 As Double = Ar2.DHeight

            If Dc.DLengths >= Di.DLengths AndAlso Dc.DWidth >= Di.DWidth AndAlso Dc.DHeight >= Di.DHeight Then                      'If Dln2 >= Dln1 AndAlso Dwd2 >= Dwd1 AndAlso Dht2 >= Dht1 Then
                DQty1 = Fix(Dc.DLengths / Di.DLengths) * Fix(Dc.DWidth / Di.DWidth) * Fix(Dc.DHeight / Di.DHeight)                  'DQty1 = Fix(Dln2 / Dln1) * Fix(Dwd2 / Dwd1) * Fix(Dht2 / Dht1)
            Else                                                                                                                    'Else     
                DQty1 = 0                                                                                                           'DQty1 = 0
            End If                                                                                                                  'End If

            If Not TpUp Then                                                                                                        'If Not TpUp Then
                If Dc.DLengths >= Di.DLengths AndAlso Dc.DWidth >= Di.DHeight AndAlso Dc.DHeight >= Di.DWidth Then                  'If Dln2 >= Dln1 AndAlso Dwd2 >= Dht1 AndAlso Dht2 >= Dwd1 Then
                    DQty2 = Fix(Dc.DLengths / Di.DLengths) * Fix(Dc.DWidth / Di.DHeight) * Fix(Dc.DHeight / Di.DWidth)              'DQty2 = Fix(Dln2 / Dln1) * Fix(Dwd2 / Dht1) * Fix(Dht2 / Dwd1)
                Else                                                                                                                'Else
                    DQty2 = 0                                                                                                       'DQty2 = 0
                End If                                                                                                              'End If

                If Dc.DLengths >= Di.DWidth AndAlso Dc.DWidth >= Di.DHeight AndAlso Dc.DHeight >= Di.DLengths Then                  'If Dln2 >= Dwd1 AndAlso Dwd2 >= Dht1 AndAlso Dht2 >= Dln1 Then
                    DQty3 = Fix(Dc.DLengths / Di.DWidth) * Fix(Dc.DWidth / Di.DHeight) * Fix(Dc.DHeight / Di.DLengths)              'DQty3 = Fix(Dln2 / Dwd1) * Fix(Dwd2 / Dht1) * Fix(Dht2 / Dln1)
                Else                                                                                                                'Else
                    DQty3 = 0                                                                                                       'End If                                                                                                       'DQty3 = 0
                End If

            End If                                                                                                                   'End If     

            If Dc.DLengths >= Di.DWidth AndAlso Dc.DWidth >= Di.DLengths AndAlso Dc.DHeight >= Di.DHeight Then                      'If Dln2 >= Dwd1 AndAlso Dwd2 >= Dln1 AndAlso Dht2 >= Dht1 Then
                DQty4 = Fix(Dc.DLengths / Di.DWidth) * Fix(Dc.DWidth / Di.DLengths) * Fix(Dc.DHeight / Di.DHeight)                  'DQty4 = Fix(Dln2 / Dwd1) * Fix(Dwd2 / Dln1) * Fix(Dht2 / Dht1)
            Else                                                                                                                    'Else
                DQty4 = 0                                                                                                           'DQty4 = 0
            End If                                                                                                                  'End If

            If Not TpUp Then                                                                                                        'If Not TpUp Then      

                If Dc.DLengths >= Di.DHeight AndAlso Dc.DWidth >= Di.DWidth AndAlso Dc.DHeight >= Di.DLengths Then                  'If Dln2 >= Dht1 AndAlso Dwd2 >= Dwd1 AndAlso Dht2 >= Dln1 Then
                    DQty5 = Fix(Dc.DLengths / Di.DHeight) * Fix(Dc.DWidth / Di.DWidth) * Fix(Dc.DHeight / Di.DLengths)              'DQty5 = Fix(Dln2 / Dht1) * Fix(Dwd2 / Dwd1) * Fix(Dht2 / Dln1)
                Else                                                                                                                'Else
                    DQty5 = 0                                                                                                       'DQty5 = 0
                End If                                                                                                              'End If

                If Dc.DLengths >= Di.DHeight AndAlso Dc.DWidth >= Di.DLengths AndAlso Dc.DHeight >= Di.DWidth Then                  'If Dln2 >= Dht1 AndAlso Dwd2 >= Dln1 AndAlso Dht2 >= Dwd1 Then
                    DQty6 = Fix(Dc.DLengths / Di.DHeight) * Fix(Dc.DWidth / Di.DLengths) * Fix(Dc.DHeight / Di.DWidth)              'DQty6 = Fix(Dln2 / Dht1) * Fix(Dwd2 / Dln1) * Fix(Dht2 / Dwd1)
                Else                                                                                                                'Else
                    DQty6 = 0                                                                                                       'DQty6 = 0
                End If                                                                                                              'End If
            End If                                                                                                                  'End If    

            MaxQty1 = DQty1
            DQtyPos = "1"

            If Not TpUp Then
                If DQty2 > MaxQty1 Then
                    MaxQty1 = DQty2
                    DQtyPos = "2"
                End If

                If DQty3 > MaxQty1 Then
                    MaxQty1 = DQty3
                    DQtyPos = "3"
                End If
            End If

            If DQty4 > MaxQty1 Then
                MaxQty1 = DQty4
                DQtyPos = "4"
            End If

            If Not TpUp Then
                If DQty5 > MaxQty1 Then
                    MaxQty1 = DQty5
                    DQtyPos = "5"
                End If

                If DQty6 > MaxQty1 Then
                    MaxQty1 = DQty6
                    DQtyPos = "6"
                End If
            End If

            QOcc = 0
            QOccLst.Clear()

            If MaxQty1 = DQty1 Then
                QOcc += 1
                QOccLst.Add(1)
            End If

            If MaxQty1 = DQty2 Then
                QOcc += 1
                QOccLst.Add(2)
            End If

            If MaxQty1 = DQty3 Then
                QOcc += 1
                QOccLst.Add(3)
            End If

            If MaxQty1 = DQty4 Then
                QOcc += 1
                QOccLst.Add(4)
            End If

            If MaxQty1 = DQty5 Then
                QOcc += 1
                QOccLst.Add(5)
            End If

            If MaxQty1 = DQty6 Then
                QOcc += 1
                QOccLst.Add(6)
            End If

            If MaxQty1 = DQty1 Then
                DQtyPos = "1"
            End If

            If DQtyPos = "1" Then
                Return 1
            End If

            If DQtyPos = "2" Then
                Return 2
            End If

            If DQtyPos = "3" Then
                Return 3
            End If

            If DQtyPos = "4" Then
                Return 4
            End If

            If DQtyPos = "5" Then
                Return 5
            End If

            If DQtyPos = "6" Then
                Return 6
            End If

            Return 0

        Catch er As Exception
            MsgBox(er.Message)
            MsgBox(er.ToString)
            MessageBox.Show("Error in DrumFindOptMethodCANxt", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try

    End Function

#End Region

End Module
