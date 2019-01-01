
'Program Name: -    DrumNItmMdl.vb
'Programmer Name: - Satwadhir B. Pawar Mob No. :- 9323974665
'Company Name:-     Hazel Infotech LTD. Mumbai
'Project Name: -    P-Stuff Plus (Container Stuffing)
'Date: -            23 Dec 2K8 5.30 PM (Modified Time)

'Tips: - The code is debugging at that particular dimensions, quantity and sequence.
'        you are decide it the logic happen is correct to that way or its are some 
'        different way the understanding to at your best level is the correct logic 
'        of this particular code block.

'Description: - DrumNItmMdl is the drum next item placing module which is used to generating
'               the 3D VRML Code written in to First.wrl file to shown the drum isometric 3D view. 
'               These are various routines and function which can generate the final output of the
'               VRML programming to view to user by Alteros viewers.

#Region " Importing Object "

Imports DrumGmCntPt
Imports DrmFindQty

#End Region

Module DrumNItmMdl

#Region " Module Declaration "

    Public DGmCpt As New DrmGeomCntPt()       'DrmGmPtCSP.dll used here
    Public DrmQt As New DrumQty()             'DCalcQty.dll used here


    'Public DMpt As New DMidPt()       'DrmGmPtCSP.dll used here

    Dim D As New CDrum                      ' for Drum dimensions

    Public NRDrum As Boolean = False        'Drums simple row arrangement flag DHE
    Public DHDNRDrum As Boolean = False        'Drums simple row arrangement flag DHD

    Friend DHDQ As New Queue(Of CDArea)        'Dim DHDQ As New Queue(Of CDArea) 

    Dim ArD As New CDrum
    Dim Cmd As New OleDb.OleDbCommand
    Dim AnsW As MsgBoxResult
    Dim Occ As Integer
    Dim OccLst As New List(Of Integer)
    Dim OptLst As New List(Of StructOcc1)

#End Region

#Region " Function Definition "

    Public Function DrumStuff(ByVal DArc As CDArea, ByVal DAR() As CDArea, ByVal DAri() As String, ByVal ArWt() As Single, ByVal SaveOpt As Boolean, ByVal ShowEmpty As Boolean, ByVal OutFile As String, ByVal DrawArc As Boolean, ByVal TranspArr() As Boolean, ByVal TopUp() As Boolean, ByVal TxtOpt As Boolean, ByVal DrawOpt As Boolean, ByVal FindQtyFlg As Boolean, ByVal ChngFlg As Boolean, ByVal ColArr As List(Of List(Of Byte))) As List(Of CDArea)
        'DStop
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

            'DStop

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

                ArD.DStrtPt.x = DArc.DLengths
                ArD.DStrtPt.y = 0
                ArD.DStrtPt.z = 0
                ArD.DLengths = 0.5
                ArD.DWidth = DArc.DWidth
                ArD.DHeight = DArc.DHeight

                If DrawOpt Or DrawArc Then

                End If

                Ard1.DStrtPt.x = DArc.DLengths - 0.01
                Ard1.DStrtPt.y = 0
                Ard1.DStrtPt.z = 0
                Ard1.DLengths = 0.5
                Ard1.DWidth = ArD.DWidth
                Ard1.DHeight = ArD.DHeight
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
            Dim ImgName As String = "1"

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

                    Cmd.Connection = connDrums

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

                    If Occ > 1 Then

                        Dim OccLst1 As New List(Of Integer)

                        For i As Integer = 0 To OccLst.Count - 1
                            OccLst1.Add(OccLst(i))
                        Next

                        Dim Strctm1 As New StructOcc1

                        Strctm1.j = j
                        Strctm1.j1 = OccLst1
                        Strctm1.CDLstSt = CDLst
                        OptLst.Add(Strctm1)
                    End If

                    D.DLengths = DAR(j).DLengths              'Dim Dln As Double = Ar(j).DLengths
                    D.DWidth = DAR(j).DWidth                  'Dim Dwd As Double = Ar(j).DWidth
                    D.DHeight = DAR(j).DHeight                'Dim Dht As Double = Ar(j).DHeight
                    D.DRadius = DAR(j).DRadius                 'Dim Drds As Double = Ar(j).DRadius

                    ARDrum.DLengths = DAR(j).DLengths        'Value are transfered to CDrum 
                    ARDrum.DWidth = DAR(j).DWidth
                    ARDrum.DHeight = DAR(j).DHeight
                    ARDrum.DRadius = DAR(j).DRadius

                    'DStop

                    Dim Nm As String = DAri(j)
                    Dim P As Integer = j

                    If IID = 1 Then

                        DAR(P).DLengths = D.DLengths
                        DAR(P).DWidth = D.DWidth
                        DAR(P).DHeight = D.DHeight
                        DAR(P).DRadius = D.DRadius

                        ARDrum.DLengths = D.DLengths
                        ARDrum.DWidth = D.DWidth
                        ARDrum.DHeight = D.DHeight
                        ARDrum.DRadius = D.DRadius

                    End If

                    If IID = 2 Then

                        DAR(P).DLengths = D.DLengths        'Ar(P).DLengths = Dln
                        DAR(P).DWidth = D.DWidth            'Ar(P).DWidth = Dht
                        DAR(P).DHeight = D.DHeight          'Ar(P).DHeight = Dwd
                        DAR(P).DRadius = D.DRadius

                        ARDrum.DLengths = D.DLengths
                        ARDrum.DWidth = D.DWidth
                        ARDrum.DHeight = D.DHeight
                        ARDrum.DRadius = D.DRadius

                    End If

                    If IID = 3 Then

                        DAR(P).DLengths = D.DLengths             'Ar(P).DLengths = Dwd
                        DAR(P).DWidth = D.DWidth                 'Ar(P).DWidth = Dht
                        DAR(P).DHeight = D.DHeight               'Ar(P).DHeight = Dln
                        DAR(P).DRadius = D.DRadius

                        ARDrum.DLengths = D.DLengths
                        ARDrum.DWidth = D.DWidth
                        ARDrum.DHeight = D.DHeight
                        ARDrum.DRadius = D.DRadius

                    End If

                    If IID = 4 Then

                        DAR(P).DLengths = D.DLengths            'Ar(P).DLengths = Dwd
                        DAR(P).DWidth = D.DWidth                'Ar(P).DWidth = Dln
                        DAR(P).DHeight = D.DHeight               'Ar(P).DHeight = Dht
                        DAR(P).DRadius = D.DRadius

                        ARDrum.DLengths = D.DLengths
                        ARDrum.DWidth = D.DWidth
                        ARDrum.DHeight = D.DHeight
                        ARDrum.DRadius = D.DRadius

                    End If

                    If IID = 5 Then

                        DAR(P).DLengths = D.DLengths              'Ar(P).DLengths = Dht
                        DAR(P).DWidth = D.DWidth                  'Ar(P).DWidth = Dwd
                        DAR(P).DHeight = D.DHeight                'Ar(P).DHeight = Dln
                        DAR(P).DRadius = D.DRadius

                        ARDrum.DLengths = D.DLengths
                        ARDrum.DWidth = D.DWidth
                        ARDrum.DHeight = D.DHeight
                        ARDrum.DRadius = D.DRadius

                    End If

                    If IID = 6 Then

                        DAR(P).DLengths = D.DLengths        'Ar(P).DLengths = Dht
                        DAR(P).DWidth = D.DWidth            'Ar(P).DWidth = Dln
                        DAR(P).DHeight = D.DHeight          'Ar(P).DHeight = Dwd
                        DAR(P).DRadius = D.DRadius

                        ARDrum.DLengths = D.DLengths
                        ARDrum.DWidth = D.DWidth
                        ARDrum.DHeight = D.DHeight
                        ARDrum.DRadius = D.DRadius

                    End If

                End If

                '##################################
                'DStop
                '##################################

                Dim Flg As Boolean = Math.Abs(((DAR(j).DLengths * DAR(j).DWidth * DAR(j).DHeight) * Qty) - (ArT.DLengths * ArT.DWidth * ArT.DHeight)) < 0.01

                'D.DmQty = DrumFindQtyDHD(DAri, j)         'Dim Mm As Integer = DrumFindQtyDHE(Ari, j)

                'From here implements 4 June 2K8


                D.DmQty = DrmQt.DFindQty(DAri, j)               'use DCalcQty.dll


                'DStop

                If D.DmQty >= Qty And Flg Then               'If Mm >= Qty And Flg Then

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

                    ARDrum.AutoDrawDHDDrmSA(OutFile, Col, DTraval, "s" & ImgName & ".png", DAri(j), ArWt(j), QtyFlg, TxtOpt, DAri(j), IID, True, "b", DDia, DRds, DHt)

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

    Public Function DrumFindOptDHD(ByVal stk As List(Of CDArea), ByVal ar As CDArea, ByVal tpup As Boolean) As Integer
        'DStop
        Dim StAl As New List(Of StructArwi)
        Dim Cmd As New OleDb.OleDbCommand
        Cmd.Connection = connDrums
        Dim ILst As New List(Of Integer)
        Dim Ar1 As New CDArea

        Dim Ordr As Integer

        Dim Arw As New StructArwi

        Try

            For i As Integer = 0 To stk.Count - 1

                If StuffPlus.DrumFtIpDHD(stk.Item(i), ar, tpup) Then

                    Arw.ar = CDLst.Item(i)
                    Arw.ordr = i
                    StAl.Add(Arw)
                    ILst.Add(i)

                End If
            Next

            DeleteTable("DTemp2")

            Dim ArL As New ArrayList
            For i As Integer = 0 To StAl.Count - 1
                Ar1 = StAl(i).ar

                DInsertTable("DTemp2", New Object() {CStr(Ar1.DStrtPt.x), CStr(Ar1.DStrtPt.y), CStr(Ar1.DStrtPt.z), CStr(ILst(i))})

                ArL.Add(StAl(i))
            Next

            Dim III As DataRow()
            III = DGetf("DTemp2", "", "z desc ,x asc,y asc")
            If III.Length = 1 Then
                Return -1
            End If
            Ordr = III(0)("i")

        Catch err As Exception
            MsgBox(err.Message)
            MsgBox(err.ToString)
            MessageBox.Show("Error in DrumFindOptDHD", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try

        Return Ordr

    End Function

    Public Function DrumFindCandidate1DHD(ByVal DHDq As List(Of CDArea), ByVal DHD As CDArea, ByVal TpUp As Boolean) As List(Of Integer)
        'DStop
        Dim Lst As New List(Of Integer)
        Dim Lst2 As New List(Of Integer)
        Dim RetLst As New Queue
        Dim AR1 As New CDArea
        Dim Cnt As Integer = 0
        Dim Cmd As New OleDb.OleDbCommand
        Dim Rdr As OleDb.OleDbDataReader
        Dim Ordr As Integer
        Dim Ordr1 As Integer
        Dim Q1 As New List(Of CDArea)
        Dim Q2 As New List(Of CDArea)
        Dim Q3 As New List(Of CDArea)
        Dim Lst1 As New List(Of CDArea)
        Dim ELst As New List(Of List(Of CDArea))
        Dim TLst As New List(Of CDArea)
        Dim TLst1 As New List(Of CDArea)

        Dim ArCon As CDArea

        Dim Lstf As New List(Of Integer)
        Dim LstRet As New List(Of List(Of Integer))
        Dim ArR As CDArea
        Dim LstT As New List(Of Integer)

        Try

            For i As Integer = 0 To DHDq.Count - 1
                AR1 = DHDq(i)

                If Not StuffPlus.DrumFtIpDHD(AR1, DHD, TpUp) Then

                    '10sd
                    'DStop
                    If AR1.DLengths >= DHD.DLengths AndAlso AR1.DHeight >= DHD.DHeight AndAlso AR1.DWidth > DHD.DWidth Then
                        'DStop
                        Lst.Add(i)
                        Lst1.Add(AR1)

                    End If
                End If
            Next

            For j As Integer = 0 To Lst1.Count - 1
                ArR = Lst1(j)

                For i As Integer = 0 To DHDq.Count - 1
                    AR1 = DHDq(i)

                    If (Math.Abs(AR1.DStrtPt.y - ArR.DStrtPt.y - ArR.DWidth) < 0.0001) AndAlso AR1.DStrtPt.z = ArR.DStrtPt.z AndAlso AR1.DWidth + ArR.DWidth >= DHD.DWidth Then
                        TLst.Add(ArR)
                        TLst1.Add(AR1)
                        Lst2.Add(Lst(j))
                        Lstf.Add(i)

                    End If
                Next
            Next

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in DrumFindCandidate1DHD", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'MessageBox.Show(Ex.Message, "DrumFindCandidate1DHD", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Try
            'DStop
            If connDrums.State = ConnectionState.Closed Then connDrums.Open()
            Cmd.Connection = connDrums
            Cmd.CommandText = "delete from DHDTemp3"
            Cmd.ExecuteNonQuery()
            'DStop
        Catch e As Exception
            connDrums.Dispose()
            connDrums.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\Drums.mdb;Persist Security Info=False"
            connDrums.Open()
            Cmd.Cancel()
            Cmd.Connection = Nothing
            Cmd.Connection = connDrums
            Cmd.CommandText = ""
            Cmd.CommandText = "delete from DHDTemp3"
            Cmd.ExecuteNonQuery()
        End Try

        For i As Integer = 0 To TLst.Count - 1
            ArCon = TLst(i)
            Ordr = Lst2(i)
            Ordr1 = Lstf(i)
            Try
                Cmd.Connection = connDrums
                Cmd.CommandText = "insert into DHDTemp3 values(" & CStr(ArCon.DStrtPt.x) & "," & CStr(ArCon.DStrtPt.y) & "," & CStr(ArCon.DStrtPt.z) & "," & CStr(Ordr) & "," & CStr(Ordr1) & ")"
                Cmd.ExecuteNonQuery()

            Catch e As Exception
                Cmd.Cancel()

                Cmd.Connection = Nothing
                Cmd.Connection = connDrums
                Cmd.CommandText = ""
                Cmd.CommandText = "delete from DHDTemp3"
                Cmd.ExecuteNonQuery()
            End Try
        Next

        Cmd.CommandText = "select * from DHDTemp3 order by z desc ,x asc,y asc"
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

    End Function

    Public Function DHDFindCandidateDrum(ByVal Q As List(Of CDArea), ByVal Ar As CDArea) As List(Of Integer)
        '###########################################
        'DStop
        '###########################################
        Dim Lst As New List(Of Integer)
        Dim Lst2 As New List(Of Integer)
        Dim RetLst As New Queue
        Dim AR1 As New CDArea
        Dim Cnt As Integer = 0
        Dim Cmd As New OleDb.OleDbCommand
        Dim Rdr As OleDb.OleDbDataReader
        Dim Ordr As Integer
        Dim Ordr1 As Integer
        Dim Q1 As New List(Of CDArea)
        Dim Q2 As New List(Of CDArea)
        Dim Q3 As New List(Of CDArea)
        Dim Lst1 As New List(Of CDArea)
        Dim ELst As New List(Of List(Of CDArea))
        Dim TLst As New List(Of CDArea)
        Dim TLst1 As New List(Of CDArea)

        Dim ArCon As CDArea
        Dim Lstf As New List(Of Integer)
        Dim Lstret As New List(Of List(Of Integer))
        Dim ArR As CDArea
        Dim Lstt As New List(Of Integer)

        Try
            For i As Integer = 0 To Q.Count - 1
                AR1 = Q(i)

                If AR1.DWidth >= Ar.DWidth AndAlso AR1.DHeight >= Ar.DHeight Then
                    Lst.Add(i)
                    Lst1.Add(AR1)
                End If
                'Stop
                'If AR1.DWidth >= Ar.DWidth AndAlso AR1.DHeight >= Ar.DHeight AndAlso AR1.DLengths >= Ar.DLengths Then
                '    Lst.Add(i)
                '    Lst1.Add(AR1)
                'End If
            Next

            For j As Integer = 0 To Lst1.Count - 1
                ArR = Lst1(j)

                For i As Integer = 0 To Q.Count - 1
                    AR1 = Q(i)

                    If AR1.DStrtPt.x = ArR.DStrtPt.x + ArR.DLengths AndAlso AR1.DLengths + ArR.DLengths >= Ar.DLengths AndAlso (AR1.DStrtPt.y = ArR.DStrtPt.y OrElse AR1.DStrtPt.y + AR1.DWidth = ArR.DStrtPt.y + ArR.DWidth) AndAlso AR1.DStrtPt.z = ArR.DStrtPt.z AndAlso AR1.DStrtPt.y <= ArR.DStrtPt.y Then
                        TLst.Add(ArR)
                        TLst1.Add(AR1)
                        Lst2.Add(Lst(j))
                        Lstf.Add(i)

                    End If
                Next
            Next

            Try
                If connDrums.State = ConnectionState.Closed Then connDrums.Open()

                Cmd.Connection = connDrums
                Cmd.CommandText = "delete from DHDTemp3"
                Cmd.ExecuteNonQuery()
            Catch e As Exception
                connDrums.Dispose()
                connDrums.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\Drums.mdb;Persist Security Info=False"
                connDrums.Open()
                Cmd.Cancel()
                Cmd.Connection = Nothing
                Cmd.Connection = connDrums
                Cmd.CommandText = ""
                Cmd.CommandText = "delete from DHDTemp3"
                Cmd.ExecuteNonQuery()
            End Try
            For i As Integer = 0 To TLst.Count - 1
                ArCon = TLst(i)
                Ordr = Lst2(i)
                Ordr1 = Lstf(i)

                Try
                    If connDrums.State = ConnectionState.Closed Then connDrums.Open()

                    Cmd.Connection = connDrums
                    Cmd.CommandText = "insert into DHDTemp3 values(" & CStr(ArCon.DStrtPt.x) & "," & CStr(ArCon.DStrtPt.y) & "," & CStr(ArCon.DStrtPt.z) & "," & CStr(Ordr) & "," & CStr(Ordr1) & ")"
                    Cmd.ExecuteNonQuery()
                Catch e As Exception
                    Cmd.Cancel()
                    Cmd.Connection = Nothing
                    Cmd.Connection = connDrums
                    Cmd.CommandText = ""
                    Cmd.CommandText = "delete from DHDTemp3"
                    Cmd.ExecuteNonQuery()
                End Try
            Next

            Cmd.CommandText = "select * from DHDTemp3 order by z desc ,x asc,y asc"
            Rdr = Cmd.ExecuteReader
            Rdr.Read()

            If Rdr.HasRows Then
                Ordr = Rdr.Item("i")
                Ordr1 = Rdr.Item("j")
                Lstt.Add(Ordr)
                Lstt.Add(Ordr1)
                Lstret.Add(Lstt)
                Return Lstt
            Else
                Return Nothing
            End If



        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in DHDFindCandidate", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            connDrums.Close()
            Return Nothing
            GC.Collect()
        End Try

    End Function

    Public Function DHDFindOptMethodDrum(ByVal ARItem As CDArea, ByVal ARContnr As CDArea, ByRef MaxQty1 As Integer, ByVal TpUp As Boolean) As Integer

        '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        'DStop
        '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

        'Dim M As List(Of list(of CDrum)

        Dim iM As New CDrum
        Dim cM As New CDrum
        Dim Dqtypos As String

        iM.DLengths = ARItem.DLengths                    'Dim Dln1 As Double = ARItem.DLengths
        iM.DWidth = ARItem.DWidth                        'Dim Dwd1 As Double = ARItem.DWidth
        iM.DHeight = ARItem.DHeight                      'Dim Dht1 As Double = ARItem.DHeight
        iM.DRadius = ARItem.DRadius                      'Dim Drds1 As Double = ARItem.DRadius

        cM.DLengths = ARContnr.DLengths                  'Dim Dln2 As Double = ARContnr.DLengths
        cM.DWidth = ARContnr.DWidth                      'Dim Dwd2 As Double = ARContnr.DWidth
        cM.DHeight = ARContnr.DHeight                    'Dim Dht2 As Double = ARContnr.DHeight

        Dim Dqty1 As UInt64 = 0                           'Dim Dqty1 As Integer = 0
        Dim Dqty2 As UInt64 = 0                           'Dim Dqty2 As Integer = 0
        Dim Dqty3 As UInt64 = 0                           'Dim Dqty3 As Integer = 0
        Dim Dqty4 As UInt64 = 0                           'Dim Dqty4 As Integer = 0
        Dim Dqty5 As UInt64 = 0                           'Dim Dqty5 As Integer = 0 
        Dim Dqty6 As UInt64 = 0                           'Dim Dqty6 As Integer = 0

        Try
            If cM.DLengths >= iM.DLengths AndAlso cM.DWidth >= iM.DWidth AndAlso cM.DHeight >= iM.DHeight Then          'If Dln2 >= Dln1 AndAlso Dwd2 >= Dwd1 AndAlso Dht2 >= Dht1 Then
                Dqty1 = Fix(cM.DLengths / iM.DLengths) * Fix(cM.DWidth / iM.DWidth) * Fix(cM.DHeight / iM.DHeight)      'Dqty1 = Fix(Dln2 / Dln1) * Fix(Dwd2 / Dwd1) * Fix(Dht2 / Dht1)
            Else
                Dqty1 = 0
            End If

            If Not TpUp Then

                If cM.DLengths >= iM.DLengths AndAlso cM.DWidth >= iM.DHeight AndAlso cM.DHeight >= iM.DWidth Then      'If Dln2 >= Dln1 AndAlso Dwd2 >= Dht1 AndAlso Dht2 >= Dwd1 Then
                    Dqty2 = Fix(cM.DLengths / iM.DLengths) * Fix(cM.DWidth / iM.DHeight) * Fix(cM.DHeight / iM.DWidth)
                Else
                    Dqty2 = 0
                End If

                If cM.DLengths >= iM.DWidth AndAlso cM.DWidth >= iM.DHeight AndAlso cM.DHeight >= iM.DLengths Then          'If Dln2 >= Dwd1 AndAlso Dwd2 >= Dht1 AndAlso Dht2 >= Dln1 Then
                    Dqty3 = Fix(cM.DLengths / iM.DWidth) * Fix(cM.DWidth / iM.DHeight) * Fix(cM.DHeight / iM.DLengths)      'Dqty3 = Fix(Dln2 / Dwd1) * Fix(Dwd2 / Dht1) * Fix(Dht2 / Dln1)
                Else
                    Dqty3 = 0
                End If

            End If

            If cM.DLengths >= iM.DWidth AndAlso cM.DWidth >= iM.DLengths AndAlso cM.DHeight >= iM.DHeight Then              'If Dln2 >= Dwd1 AndAlso Dwd2 >= Dln1 AndAlso Dht2 >= Dht1 Then
                Dqty4 = Fix(cM.DLengths / iM.DWidth) * Fix(cM.DWidth / iM.DLengths) * Fix(cM.DHeight / iM.DHeight)          'Dqty4 = Fix(Dln2 / Dwd1) * Fix(Dwd2 / Dln1) * Fix(Dht2 / Dht1)
            Else
                Dqty4 = 0
            End If

            If Not TpUp Then

                If cM.DLengths >= iM.DHeight AndAlso cM.DWidth > iM.DWidth AndAlso cM.DHeight >= iM.DLengths Then           'If Dln2 >= Dht1 AndAlso Dwd2 >= Dwd1 AndAlso Dht2 >= Dln1 Then
                    Dqty5 = Fix(cM.DLengths / iM.DHeight) * Fix(cM.DWidth / iM.DWidth) * Fix(cM.DHeight / iM.DLengths)      'Dqty5 = Fix(Dln2 / Dht1) * Fix(Dwd2 / Dwd1) * Fix(Dht2 / Dln1)
                Else
                    Dqty5 = 5
                End If

                If cM.DLengths >= iM.DHeight AndAlso cM.DWidth >= iM.DLengths AndAlso cM.DHeight >= iM.DWidth Then          'If Dln2 >= Dht1 AndAlso Dwd2 >= Dln1 AndAlso Dht2 >= Dwd1 Then
                    Dqty6 = Fix(cM.DLengths / iM.DHeight) * Fix(cM.DWidth / iM.DLengths) * Fix(cM.DHeight / iM.DWidth)      'Dqty6 = Fix(Dln2 / Dht1) * Fix(Dwd2 / Dln1) * Fix(Dht2 / Dwd1)
                Else
                    Dqty6 = 0
                End If

            End If

            MaxQty1 = Dqty1
            Dqtypos = "1"

            If Not TpUp Then
                If Dqty2 > MaxQty1 Then
                    MaxQty1 = Dqty2
                    Dqtypos = "2"
                End If

                If Dqty3 > MaxQty1 Then
                    MaxQty1 = Dqty3
                    Dqtypos = "3"
                End If
            End If

            If Dqty4 > MaxQty1 Then
                MaxQty1 = Dqty4
                Dqtypos = "4"
            End If

            If Not TpUp Then
                If Dqty5 > MaxQty1 Then
                    MaxQty1 = Dqty5
                    Dqtypos = "5"
                End If

                If Dqty6 > MaxQty1 Then
                    MaxQty1 = Dqty6
                    Dqtypos = "6"
                End If
            End If

            Occ = 0
            OccLst.Clear()

            If MaxQty1 = Dqty1 Then
                Occ += 1
                OccLst.Add(1)
            End If

            If MaxQty1 = Dqty2 Then
                Occ += 1
                OccLst.Add(2)
            End If

            If MaxQty1 = Dqty3 Then
                Occ += 1
                OccLst.Add(3)
            End If

            If MaxQty1 = Dqty4 Then
                Occ += 1
                OccLst.Add(4)
            End If

            If MaxQty1 = Dqty5 Then
                Occ += 1
                OccLst.Add(5)
            End If

            If MaxQty1 = Dqty6 Then
                Occ += 1
                OccLst.Add(6)
            End If

            If MaxQty1 = Dqty1 Then
                Dqtypos = "1"
            End If

            If Dqtypos = "1" Then
                Return 1
            End If

            If Dqtypos = "2" Then
                Return 2
            End If

            If Dqtypos = "3" Then
                Return 3
            End If

            If Dqtypos = "4" Then
                Return 4
            End If

            If Dqtypos = "5" Then
                Return 5
            End If

            If Dqtypos = "6" Then
                Return 6
            End If

            Return 0
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in DHDFindOptMethodDrum", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try

    End Function

    Public Function DrumFindQtyDHD(ByVal ItmArr() As String, ByVal StrtPos As Integer) As Integer

        Dim Nm As String = ItmArr(StrtPos)
        Dim L As Integer

        Try
            For L = StrtPos To UBound(ItmArr)
                If ItmArr(L) <> Nm Then
                    Exit For
                End If
            Next
            Return L - StrtPos
        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in DrumFindQtyDHD", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try

    End Function

#End Region

End Module
