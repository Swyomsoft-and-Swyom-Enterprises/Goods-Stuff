
'Program Name: -    GenDRoutineSACAMdl.vb
'Programmer Name: - Satwadhir B. Pawar Mob No. :- 9323974665
'Company Name:-     Hazel Infotech LTD. Mumbai
'Project Name: -    Sky Stuff Plus (Container Stuffing)
'Date: -            24 Dec 2K8 11.35 AM (Modified Time)

'Tips: - The code is debugging at that particular dimensions, quantity and sequence.
'        you are decide it the logic happen is correct to that way or its are some 
'        different way the understanding to at your best level is the correct logic 
'        of this particular code block.

'Description: - GenDRoutineSACAMdl this module include various routine and functions
'               which is generating the 3D isometric geometry program of simple and cross 
'               arrangement of drum (cylinder) geometry.

Module GenDRoutineSACAMdl

#Region " Module Declaration "

    Friend siSW As IO.StreamWriter

    Public CDLst As New List(Of CDArea)             'Public CDLst As New List(Of CDArea)
    Friend DrmCDLst As New List(Of CDrum)

    Public LCAQty As New List(Of UInt64)                'Cross drum quantity check

    Dim Ard As New CDArea

    Dim AnsW As MsgBoxResult

    Dim DHDq As New Queue(Of CDArea)

    Dim Dq As New CDrum                      ' for Drum dimensions

    Public stpDrum As Integer = 1

    Friend DMaxQtyLst As New List(Of Integer)
    Friend LstR1StArr As New List(Of StructR1)
    Friend DLstD1StArr As New List(Of StructDrm1)
    Friend DQtyArr As New List(Of StructE1)

    Friend DqtylstSA As New List(Of Integer)
    Friend DplclstSA As New List(Of Integer)
    Friend DplclstfSA As New List(Of Integer)

    Friend DareaarrSA As New List(Of List(Of String))
    Friend DstrtclrSA As String

    'Friend QtyLst As New List(Of Integer)
    'Friend LstSav As New List(Of List(Of CDArea))
    Friend DrmAreaArrSA As New List(Of List(Of String))

    Friend DtotwtSA As Single

    Friend DItemNoSA As UInt64        'Friend DItemNo As Integer
    Friend DItemQtySa As UInt64        'Friend DItemQty As Integer

    Dim OccLst As New List(Of Integer)
    Dim OptLst As New List(Of StructOcc1)

    Dim Q As New Queue(Of CDArea)

    Public Dtxtopt As Boolean = True

    Dim Occ As Integer

    Public E1StE2 As New StructE1

    Dim Cmd As New OleDb.OleDbCommand

#End Region

#Region " Function Definition "

    Public Function DFindCandidate1(ByVal q As List(Of CDArea), ByVal ar As CDArea, ByVal tpup As Boolean) As List(Of Integer)

        Dim Lst As New List(Of Integer)
        Dim Lst2 As New List(Of Integer)
        Dim RetLst As New Queue
        Dim Ar1 As New CDArea
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
        Dim Arr As CDArea
        Dim Lstt As New List(Of Integer)

        Try

            For i As Integer = 0 To q.Count - 1
                Ar1 = q(i)

                If Not StuffPlus.DFtIp(Ar1, ar, tpup) Then

                    '10sd
                    'Stop
                    If Ar1.DLengths >= ar.DLengths AndAlso Ar1.DHeight >= ar.DHeight AndAlso Ar1.DWidth > ar.DWidth Then
                        Stop
                        Lst.Add(i)
                        Lst1.Add(Ar1)

                    End If
                End If
            Next

            For j As Integer = 0 To Lst1.Count - 1
                Arr = Lst1(j)

                For i As Integer = 0 To q.Count - 1
                    Ar1 = q(i)

                    If (Math.Abs(Ar1.DStrtPt.y - Arr.DStrtPt.y - Arr.DWidth) < 0.0001) AndAlso Ar1.DStrtPt.z = Arr.DStrtPt.z AndAlso Ar1.DWidth + Arr.DWidth >= ar.DWidth Then
                        TLst.Add(Arr)
                        TLst1.Add(Ar1)
                        Lst2.Add(Lst(j))
                        Lstf.Add(i)

                    End If
                Next

            Next

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in DFindCandidate1", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Try
            Cmd.Connection = connDrums
            Cmd.CommandText = "delete from temp3"
            Cmd.ExecuteNonQuery()
        Catch e As Exception
            connDrums.Dispose()
            connDrums.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\Drums.mdb;Persist Security Info=False"
            connDrums.Open()
            Cmd.Cancel()
            Cmd.Connection = Nothing
            Cmd.Connection = connDrums
            Cmd.CommandText = ""
            Cmd.CommandText = "delete from temp3"
            Cmd.ExecuteNonQuery()
        End Try

        For i As Integer = 0 To TLst.Count - 1
            ArCon = TLst(i)
            Ordr = Lst2(i)
            Ordr1 = Lstf(i)

            Try
                Cmd.Connection = connDrums
                Cmd.CommandText = "insert into temp3 values(" & CStr(ArCon.DStrtPt.x) & "," & CStr(ArCon.DStrtPt.y) & "," & CStr(ArCon.DStrtPt.z) & "," & CStr(Ordr) & "," & CStr(Ordr1) & ")"
                Cmd.ExecuteNonQuery()

            Catch Ex As Exception
                Cmd.Cancel()

                Cmd.Connection = Nothing
                Cmd.Connection = connDrums
                Cmd.CommandText = ""
                Cmd.CommandText = "delete from temp3"
                Cmd.ExecuteNonQuery()
            End Try

        Next

        Try
            Cmd.CommandText = "select * from temp3 order by z desc ,x asc,y asc"
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

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in DFindCandidate1", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try

    End Function

    Public Function DrumStuffQt(ByVal dArc As CDArea, ByVal dAr() As CDArea, ByVal dAri() As String, ByVal ArWt() As Single, ByVal SaveOpt As Boolean, ByVal ShowEmpty As Boolean, ByVal OutFile As String, ByVal DrawArc As Boolean, ByVal TranspArr() As Boolean, ByVal TopUp() As Boolean, ByVal TxtOpt As Boolean, ByVal DrawOpt As Boolean, ByVal FindQtyFlg As Boolean, ByVal ChngFlg As Boolean, ByVal ColArr As List(Of List(Of Byte))) As List(Of CDArea)
        'Stop
        'Actual Drums Stuffing functions is to calculate the maximum quantity

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

            CrPtx.DStrtPt.x = dArc.DLengths        'Ptx.x = Arc.DLengths
            CrPtx.DStrtPt.y = dArc.DWidth          'Ptx.y = Arc.DWidth
            CrPtx.DStrtPt.z = dArc.DHeight         'Ptx.z = Arc.DHeight

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

                Ard.DStrtPt.x = dArc.DLengths
                Ard.DStrtPt.y = 0
                Ard.DStrtPt.z = 0
                Ard.DLengths = 0.5
                Ard.DWidth = dArc.DWidth
                Ard.DHeight = dArc.DHeight

                If DrawOpt Or DrawArc Then

                End If

                Ard1.DStrtPt.x = dArc.DLengths - 0.01
                Ard1.DStrtPt.y = 0
                Ard1.DStrtPt.z = 0
                Ard1.DLengths = 0.5
                Ard1.DWidth = Ard.DWidth
                Ard1.DHeight = Ard.DHeight
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

            dArc.DStrtPt.x = 0
            dArc.DStrtPt.y = 0
            dArc.DStrtPt.z = 0

            Dim j As Integer = 0
            ToTAr = 0
            DrmAreaArrSA.Clear()

            'Stop

            For i As Integer = 0 To CDLst.Count - 1
                CDLst2.Add(CDLst(i))
            Next

            DItemQtySa = 0
            DtotwtSA = 0

            If Not IsNothing(dAri) Then
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
                    If dAri(j) <> dAri(j - 1) Then
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
                If j > 0 And Not IsNothing(dAri) Then
                    If dAri(j - 1) <> dAri(j) Then
                        E1StE2 = New StructE1
                        E1StE2.Qty = DItemQtySa
                        E1StE2.ItmNm = dAri(j - 1)
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

                        TransactionsMenu.lblStatusINm.Text = "  Stuffing item : " & dAri(j)
                        TransactionsMenu.lblStatusINm.Refresh()
                    Else

                        TransactionsMenu.lblStatusINm.Text = "  Stuffing item : " & dAri(j)
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

                        If dAri(j - 1) <> dAri(j) Then

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

                    Stop

                    LstM = DrmUnionItrPtDHD(CDLst(ArM(0)), CDLst(ArM(1))) 'LstM = DrumUnionItrPDHE(CDLst(Arn(0)), CDLst(Arn(1)))

                    B1 = LstM(0)
                    B2 = LstM(1)
                End If

                If ArM Is Nothing And ArM1 = -1 Then
                    If DrawOpt Then

                    End If

                    For m As Integer = j To UBound(dAri) - 1

                        If dAri(m) <> dAri(j) Then
                            j = m

                            GoTo dLP

                        End If
                    Next

                    j = UBound(dAri) + 1

                    GoTo DLP

                Else

                    If ArN Is Nothing And ArM1 = -1 Then

                        If DrawOpt Then

                        End If

                        For m As Integer = j To UBound(dAri) - 1
                            If dAri(m) <> dAri(j) Then
                                j = m
                                GoTo DLP

                            End If
                        Next

                        j = UBound(dAri)

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

                    Dq.DLengths = dAr(j).DLengths              'Dim Dln As Double = Ar(j).DLengths
                    Dq.DWidth = dAr(j).DWidth                  'Dim Dwd As Double = Ar(j).DWidth
                    Dq.DHeight = dAr(j).DHeight                'Dim Dht As Double = Ar(j).DHeight
                    Dq.DRadius = dAr(j).DRadius                 'Dim Drds As Double = Ar(j).DRadius

                    ARDrum.DLengths = DAR(j).DLengths        'Value are transfered to CDrum 
                    ARDrum.DWidth = DAR(j).DWidth
                    ARDrum.DHeight = DAR(j).DHeight
                    ARDrum.DRadius = DAR(j).DRadius

                    'DStop

                    Dim Nm As String = dAri(j)
                    Dim P As Integer = j

                    If IID = 1 Then

                        dAr(P).DLengths = Dq.DLengths
                        dAr(P).DWidth = Dq.DWidth
                        dAr(P).DHeight = Dq.DHeight
                        dAr(P).DRadius = Dq.DRadius

                        ARDrum.DLengths = Dq.DLengths
                        ARDrum.DWidth = Dq.DWidth
                        ARDrum.DHeight = Dq.DHeight
                        ARDrum.DRadius = Dq.DRadius

                    End If

                    If IID = 2 Then

                        dAr(P).DLengths = Dq.DLengths        'Ar(P).DLengths = Dln
                        dAr(P).DWidth = Dq.DWidth            'Ar(P).DWidth = Dht
                        dAr(P).DHeight = Dq.DHeight          'Ar(P).DHeight = Dwd
                        dAr(P).DRadius = Dq.DRadius

                        ARDrum.DLengths = Dq.DLengths
                        ARDrum.DWidth = Dq.DWidth
                        ARDrum.DHeight = Dq.DHeight
                        ARDrum.DRadius = Dq.DRadius

                    End If

                    If IID = 3 Then

                        dAr(P).DLengths = Dq.DLengths             'Ar(P).DLengths = Dwd
                        dAr(P).DWidth = Dq.DWidth                 'Ar(P).DWidth = Dht
                        dAr(P).DHeight = Dq.DHeight               'Ar(P).DHeight = Dln
                        dAr(P).DRadius = Dq.DRadius

                        ARDrum.DLengths = Dq.DLengths
                        ARDrum.DWidth = Dq.DWidth
                        ARDrum.DHeight = Dq.DHeight
                        ARDrum.DRadius = Dq.DRadius

                    End If

                    If IID = 4 Then

                        dAr(P).DLengths = Dq.DLengths            'Ar(P).DLengths = Dwd
                        dAr(P).DWidth = Dq.DWidth                'Ar(P).DWidth = Dln
                        dAr(P).DHeight = Dq.DHeight               'Ar(P).DHeight = Dht
                        dAr(P).DRadius = Dq.DRadius

                        ARDrum.DLengths = Dq.DLengths
                        ARDrum.DWidth = Dq.DWidth
                        ARDrum.DHeight = Dq.DHeight
                        ARDrum.DRadius = Dq.DRadius

                    End If

                    If IID = 5 Then

                        dAr(P).DLengths = Dq.DLengths              'Ar(P).DLengths = Dht
                        dAr(P).DWidth = Dq.DWidth                  'Ar(P).DWidth = Dwd
                        dAr(P).DHeight = Dq.DHeight                'Ar(P).DHeight = Dln
                        dAr(P).DRadius = Dq.DRadius

                        ARDrum.DLengths = Dq.DLengths
                        ARDrum.DWidth = Dq.DWidth
                        ARDrum.DHeight = Dq.DHeight
                        ARDrum.DRadius = Dq.DRadius

                    End If

                    If IID = 6 Then

                        dAr(P).DLengths = Dq.DLengths        'Ar(P).DLengths = Dht
                        dAr(P).DWidth = Dq.DWidth            'Ar(P).DWidth = Dln
                        dAr(P).DHeight = Dq.DHeight          'Ar(P).DHeight = Dwd
                        dAr(P).DRadius = Dq.DRadius

                        ARDrum.DLengths = Dq.DLengths
                        ARDrum.DWidth = Dq.DWidth
                        ARDrum.DHeight = Dq.DHeight
                        ARDrum.DRadius = Dq.DRadius

                    End If

                End If

                '##################################
                'DStop
                '##################################

                Dim Flg As Boolean = Math.Abs(((DAR(j).DLengths * DAR(j).DWidth * DAR(j).DHeight) * Qty) - (ArT.DLengths * ArT.DWidth * ArT.DHeight)) < 0.01

                Dq.DmQty = DrumFindQtyDHD(dAri, j)         'Dim Mm As Integer = DrumFindQtyDHE(Ari, j)

                'From here implements 4 June 2K8

                'DStop

                If Dq.DmQty >= Qty And Flg Then               'If Mm >= Qty And Flg Then

                    If DrawOpt Then

                        If TranspArr(j) Then
                            DTraval = 0.8
                        Else
                            DTraval = 0
                        End If

                        dAr(j).DStrtPt.x = ArT.DStrtPt.x            'DArT.DStrtPt.x = ArT.DStrtPt.x
                        dAr(j).DStrtPt.y = ArT.DStrtPt.y            'DArT.DStrtPt.y = ArT.DStrtPt.y
                        dAr(j).DStrtPt.z = ArT.DStrtPt.z            'DArT.DStrtPt.z = ArT.DStrtPt.z

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
                        If dAri(j) <> dAri(j - 1) Then
                            TmpLst.Add(dAri(j - 1))
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

                'Stop

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
                        MessageBox.Show("The dimensioning adequacy in radius and diameter", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If

                '$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

                If DrawOpt Then
                    TxtOpt = True

                    'Implement Here/ 10 April 2008 //Modified 26 May 2K8 2.51 PM

                    'Stop

                    'Following Method always keep Commenting not used here
                    'ARDrum.AutoDrawDHDDrmSA(OutFile, Col, DTraval, "s" & ImgName & ".png", dAri(j), ArWt(j), QtyFlg, TxtOpt, dAri(j), IID, True, "b", DDia, DRds, DHt)             'AR(j).AutoDrawDrmSADHE(OutFile, Col, DTraval, "s" & ImgName & ".png", Ari(j), ArWt(j), QtyFlg, TxtOpt, Ari(j), IID, True, "b", DDia, DRds, DHt)

                    'DStop
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

                If Not IsNothing(dAri) Then
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
                StR1n1.ItmNm = dAri(j)

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
                E1StE2.ItmNm = dAri(j - 1)
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
                If UBound(dAri) <> -1 Then
                    TmpLst.Add(dAri(j - 1))
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

    Public Function DrumQtStuff(ByVal Arc As CDArea, ByVal Ar() As CDArea, ByVal Ari() As String, ByVal ArWt() As Single, ByVal SaveOpt As Boolean, ByVal ShowEmpty As Boolean, ByVal OutFile As String, ByVal DrawArc As Boolean, ByVal TranspArr() As Boolean, ByVal TopUp() As Boolean, ByVal TxtOpt As Boolean, ByVal DrawOpt As Boolean, ByVal FindQtyFlg As Boolean, ByVal ChngFlg As Boolean, ByVal ColArr As List(Of List(Of Byte))) As List(Of CDArea)
        'Stop
        'Actual Drums Stuffing functions is to calculate the maximum quantity

        Dim CDLst2 As New List(Of CDArea)
        Dim CDStk As New Stack(Of CDArea)
        Dim Arm As New List(Of Integer)
        Dim Lstm As New List(Of CDArea)
        Dim TmpLst As New List(Of String)
        Dim CDLstj As New List(Of CDArea)

        Dim A1 As New CDArea
        Dim A2 As New CDArea

        Dim Art As New CDArea
        Dim Arp As New CDArea
        Dim Are As New CDArea
        Dim Aru As New CDArea
        Dim Arb As New CDArea

        Dim Arm1 As Integer
        Dim DII As Integer
        Dim Traval As Single

        Dim SzChg As Integer = 0

        Dim QtyFlg As Boolean = True
        Dim DAns1 As Boolean

        Dim Ordr As Integer
        Dim Col As String = Nothing
        Dim TotAr As Double
        Dim OldItemQty As Integer = 0

        Try

            If SaveOpt Then
                configid = InputBox("Enter Config Id")
            End If

            Dim Ptx As New CDPoint

            Ptx.x = Arc.DLengths
            Ptx.y = Arc.DWidth
            Ptx.z = Arc.DHeight

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

                Ard.DStrtPt.x = Arc.DLengths
                Ard.DStrtPt.y = 0
                Ard.DStrtPt.z = 0
                Ard.DLengths = 0.5
                Ard.DWidth = Arc.DWidth
                Ard.DHeight = Arc.DHeight

                If DrawOpt Or DrawArc Then

                End If

                Ard1.DStrtPt.x = Arc.DLengths - 0.01
                Ard1.DStrtPt.y = 0
                Ard1.DStrtPt.z = 0
                Ard1.DLengths = 0.5
                Ard1.DWidth = Ard.DWidth
                Ard1.DHeight = Ard.DHeight
            End If

            If DrawOpt Or DrawArc Then
                Col1.Clear()
            End If

            DItemQtySa = 0        'Change the posion of Qty.
            DtotwtSA = 0

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

            Arc.DStrtPt.x = 0
            Arc.DStrtPt.y = 0
            Arc.DStrtPt.z = 0

            Dim j As Integer = 0
            TotAr = 0
            DareaarrSA.Clear()

            '$$$$$$$$$$$$$$$$$$$$$$$
            'Stop
            '$$$$$$$$$$$$$$$$$$$$$$$

            For i As Integer = 0 To CDLst.Count - 1
                CDLst2.Add(CDLst(i))
            Next

            'DItemQty = 0
            'Dtotwt = 0
            If Not IsNothing(Ari) Then
                'Progress8.Show()
                TransactionsMenu.lblStatus.Visible = True
                TransactionsMenu.lblStatusINm.Visible = True
                If DrawOpt Then
                    'Progress8.btnStatus.Visible = False
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

            Do While Not CDLst.Count = 0 And j <= UBound(Ar)

                If j > 0 Then
                    If Ari(j) <> Ari(j - 1) Then
                        ImgName = (CInt(ImgName) + 1).ToString
                    End If
                End If

                Ordr = 0

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
                If j > 0 And Not IsNothing(Ari) Then
                    If Ari(j - 1) <> Ari(j) Then
                        E1StE2 = New StructE1
                        E1StE2.Qty = DItemQtySa
                        E1StE2.ItmNm = Ari(j - 1)
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

                        TransactionsMenu.lblStatusINm.Text = "  Stuffing item : " & Ari(j)
                        TransactionsMenu.lblStatusINm.Refresh()
                    Else

                        TransactionsMenu.lblStatusINm.Text = "  Stuffing item : " & Ari(j)
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

                        If Ari(j - 1) <> Ari(j) Then

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
                '*********
                'Stop
                '*********
                Arm1 = DFindOpt(CDLst, Ar(j), TopUp(j))
                '*********
                'Stop
                '*********
                Art = Nothing
                If Arm1 <> -1 Then
                    Art = CDLst(Arm1)
                End If

                Dim Arn As New List(Of Integer)
                Dim Lstn As New List(Of CDArea)

                Dim B1 As New CDArea
                Dim B2 As New CDArea
                Dim Pos1 As Integer

                Arm = Nothing
                Arn = Nothing
                '*********
                'Stop
                '*********
                Arn = DFindCandidate1(CDLst, Ar(j), TopUp(j))
                '*********
                'Stop
                '*********
                Pos1 = 0
                If Not Arn Is Nothing Then
                    Pos1 = 0
                Else

                    Dim Arxx As New CDArea

                    Arxx.DLengths = Ar(j).DWidth
                    Arxx.DWidth = Ar(j).DLengths
                    Arxx.DHeight = Ar(j).DHeight

                    Arn = DFindCandidate1(CDLst, Arxx, TopUp(j))

                    If Not Arn Is Nothing Then
                        Pos1 = 1
                    Else
                        If Not TopUp(j) Then
                            Arxx.DLengths = Ar(j).DLengths
                            Arxx.DWidth = Ar(j).DHeight
                            Arxx.DHeight = Ar(j).DWidth

                            Arn = DFindCandidate1(CDLst, Arxx, False)

                            If Not Arn Is Nothing Then
                                Pos1 = 2
                            End If
                        End If
                    End If
                End If

                If Arn Is Nothing Then
                    Arm = DFindCandidate(CDLst, Ar(j))
                    If Not Arm Is Nothing Then
                        If Arm(0) = Arm1 Then Arm = Nothing
                    End If
                End If
                If Not Arm Is Nothing Then
                    Lstm = DUnionItrP(CDLst(Arm(0)), CDLst(Arm(1)))
                    A1 = Lstm(0)
                    A2 = Lstm(1)
                End If

                If Not Arn Is Nothing Then

                    Lstm = DUnionItrP(CDLst(Arn(0)), CDLst(Arn(1)))
                    B1 = Lstm(0)
                    B2 = Lstm(1)
                End If

                If Arm Is Nothing And Arm1 = -1 Then
                    If DrawOpt Then

                    End If

                    For m As Integer = j To UBound(Ari) - 1
                        If Ari(m) <> Ari(j) Then
                            j = m

                            GoTo LP

                        End If
                    Next
                    j = UBound(Ari) + 1

                    'Stop

                    GoTo LP

                Else
                    If Arn Is Nothing And Arm1 = -1 Then
                        If DrawOpt Then

                        End If

                        For m As Integer = j To UBound(Ari) - 1
                            If Ari(m) <> Ari(j) Then
                                j = m
                                GoTo LP

                            End If
                        Next
                        j = UBound(Ari)

                    End If
                End If

                If Not Arm Is Nothing Or Not Arn Is Nothing Then

                    Cmd.Connection = connDrums

                    DeleteTable("DTemp2")
z:

                    Ordr = 0
                    If Not Arm Is Nothing Then

                        DInsertTable("DTemp2", New Object() {CStr(A1.DStrtPt.x), CStr(A1.DStrtPt.y), CStr(A1.DStrtPt.z), CStr(1)})
                    End If

                    If Not Arn Is Nothing Then
                        DInsertTable("DTemp2", New Object() {CStr(B1.DStrtPt.x), CStr(B1.DStrtPt.y), CStr(B1.DStrtPt.z), CStr(2)})

                    End If

                    If Not Art Is Nothing Then
                        DInsertTable("DTemp2", New Object() {CStr(Art.DStrtPt.x), CStr(Art.DStrtPt.y), CStr(Art.DStrtPt.z), CStr(3)})

                    End If

                    Dim Rwx As DataRow() = Nothing

                    Try
                        If Not Arm Is Nothing Then

                            Rwx = DGetf("DTemp2", "", "z DESC ,x ASC,y ASC")
                        End If

                        If Not Arn Is Nothing Then

                            Rwx = DGetf("DTemp2", "", "z DESC ,x ASC,y ASC")
                        End If

                        If Arn Is Nothing And Arm Is Nothing Then

                            Rwx = DGetf("DTemp2", "", "z DESC ,x ASC")
                        End If

                        If Arm Is Nothing And Arn Is Nothing Then

                            Rwx = DGetf("DTemp2", "", "z DESC ,x ASC,y ASC")
                        End If

                    Catch Ex As Exception

                        MsgBox(Ex.Message, MsgBoxStyle.Critical, "Exception :: In Function 'Stuff' " & vbCrLf & "Programme Running is failure!")

                    Finally
                        Ordr = Rwx(0)("i")
                    End Try

                    If Ordr = 3 Then
                        CDLst.RemoveAt(Arm1)
                    Else
                        If Ordr = 1 Then
                            Art = A1
                            CDLst.RemoveAt(Arm(0))
                            If Arm(0) < Arm(1) Then
                                CDLst.RemoveAt(Arm(1) - 1)
                            Else
                                CDLst.RemoveAt(Arm(1))
                            End If

                            CDLst = DUnPush(CDLst, A2)

                        End If
                        If Ordr = 2 Then
                            If Pos1 = 1 Then
                                Dim tmp As Double = Ar(j).DWidth
                                Ar(j).DWidth = Ar(j).DLengths
                                Ar(j).DLengths = tmp
                            End If

                            If Pos1 = 2 Then
                                Dim tmp As Double = Ar(j).DHeight
                                Ar(j).DHeight = Ar(j).DWidth
                                Ar(j).DWidth = tmp
                            End If

                            Art = B1
                            CDLst.RemoveAt(Arn(0))
                            If Arn(0) < Arn(1) Then
                                CDLst.RemoveAt(Arn(1) - 1)
                            Else
                                CDLst.RemoveAt(Arn(1))
                            End If

                            CDLst.Add(B2)

                        End If
                        If Ordr = 3 Then
                            CDLst.RemoveAt(Arm1)
                        End If
                    End If
                Else

                    If Arm1 <> -1 Then
                        CDLst.RemoveAt(Arm1)
                    End If
                End If

                Dim Qty As Integer
                If ChngFlg Then
                    '######
                    'Stop
                    '########
                    DII = DFindOptMethod(Ar(j), Art, Qty, TopUp(j))

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

                    Dim Dln As Double = Ar(j).DLengths
                    Dim Dwd As Double = Ar(j).DWidth
                    Dim Dht As Double = Ar(j).DHeight

                    'Stop

                    Dim Nm As String = Ari(j)
                    Dim P As Integer = j

                    If DII = 1 Then

                    End If

                    If DII = 2 Then
                        Ar(P).DLengths = Dln
                        Ar(P).DWidth = Dht
                        Ar(P).DHeight = Dwd

                    End If

                    If DII = 3 Then
                        Ar(P).DLengths = Dwd
                        Ar(P).DWidth = Dht
                        Ar(P).DHeight = Dln

                    End If

                    If DII = 4 Then
                        Ar(P).DLengths = Dwd
                        Ar(P).DWidth = Dln
                        Ar(P).DHeight = Dht

                    End If

                    If DII = 5 Then
                        Ar(P).DLengths = Dht
                        Ar(P).DWidth = Dwd
                        Ar(P).DHeight = Dln

                    End If

                    If DII = 6 Then
                        Ar(P).DLengths = Dht
                        Ar(P).DWidth = Dln
                        Ar(P).DHeight = Dwd

                    End If

                End If

                Dim Flg As Boolean = Math.Abs(((Ar(j).DLengths * Ar(j).DWidth * Ar(j).DHeight) * Qty) - (Art.DLengths * Art.DWidth * Art.DHeight)) < 0.01

                Dim Mm As Integer = Dfindqty(Ari, j)

                If Mm >= Qty And Flg Then

                    If DrawOpt Then
                        If TranspArr(j) Then
                            Traval = 0.8
                        Else
                            Traval = 0
                        End If
                        Ar(j).DStrtPt.x = Art.DStrtPt.x
                        Ar(j).DStrtPt.y = Art.DStrtPt.y
                        Ar(j).DStrtPt.z = Art.DStrtPt.z

                        'Following Method always keep Commenting not used here

                        'Ar(j).AutoDraw(OutFile, Col, traval, "file:///c:/t2.png", Ari(j), ArWt(j), QtyFlg, TxtOpt, "", 0, True, "c")

                        j += Qty
                        DItemQtySa += Qty
                    Else
                        j += Qty

                        DItemQtySa += Qty
                        DplclstSA(DItemNoSA) = DItemQtySa
                        DtotwtSA += ArWt(j)
                        GoTo LP
                    End If

                End If

                Arm = Nothing
                Arn = Nothing

                Ar(j).DStrtPt.x = Art.DStrtPt.x

                Ar(j).DStrtPt.y = Art.DStrtPt.y
                Ar(j).DStrtPt.z = Art.DStrtPt.z

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
                        Traval = 0.8
                    Else
                        Traval = 0
                    End If
                End If
                If j = UBound(Ar) Then

                End If

                If DrawOpt Then
                    If j <> 0 Then
                        If Ari(j) <> Ari(j - 1) Then
                            TmpLst.Add(Ari(j - 1))
                            TmpLst.Add(CStr(TotAr))
                            DareaarrSA.Add(TmpLst)
                            TotAr = 0
                            TotAr = TotAr + (Ar(j).DLengths * Ar(j).DWidth * Ar(j).DHeight)
                        Else
                            TotAr = TotAr + (Ar(j).DLengths * Ar(j).DWidth * Ar(j).DHeight)
                        End If
                    Else
                        TotAr = TotAr + (Ar(j).DLengths * Ar(j).DWidth * Ar(j).DHeight)
                    End If
                End If

                'Stop

                '$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

                DDiaL = Ar(j).DLengths
                DDiaW = Ar(j).DWidth

                DHt = Ar(j).DHeight

                If DDiaL = DDiaW Then

                    DDia = DDiaL
                    DRds = DDia * 0.5
                Else
                    DDia = (DDiaL + DDiaW) * 0.5

                End If

                '$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

                If DrawOpt Then
                    TxtOpt = True

                    'Following Method always keep Commenting not used here

                    'Ar(j).AutoDrawDrmSAQty(OutFile, Col, Traval, "s" & ImgName & ".png", Ari(j), ArWt(j), QtyFlg, TxtOpt, Ari(j), DII, True, "b", DDia, DRds, DHt)

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

                If Not IsNothing(Ari) Then

                    '*********************************************
                    'Stop
                    Progress8.iQty = DItemQtySa
                    'Form8.i = itemqty
                    TransactionsMenu.lblStatus.Text = " Numbers ::   " & CStr(DItemQtySa) & "    -> Items stuffed"
                    TransactionsMenu.btnStatus.Visible = True

                    DEventful()
                    TransactionsMenu.pbCSPD.Visible = True

                    DProgressBarRunning()
                    'PB()

                    If DItemQtySa > 160 Then
                        'Stop
                    End If

                    TransactionsMenu.lblStatus.Refresh()
                    System.Windows.Forms.Application.DoEvents()
                    '*********************************************

                    If exflg Then
                        exflg = False
                        GoTo LP
                    End If
                End If

                Q = Art.DSubtract(Ar(j))

                Dim Dd As New CDArea
                If Not Q Is Nothing Then
                    If CDLst.Count = 0 Then
                        Do While Not Q.Count = 0

                            Dd = Q.Dequeue

                            CDLst.Add(Dd)

                        Loop
                    Else

                        Do While Q.Count > 0
                            Arb = Q.Dequeue
                            DAns1 = False

                            CDLst = DUnPush(CDLst, Arb)

                        Loop

                    End If

                End If

                Dim Ans2 As Boolean
                For i As Integer = 0 To CDLst.Count - 1

                    Dim Arx As New CDArea

                    Arx = CDLst(i)

                    CDLst = DMrgX(CDLst, Arx, Ans2)

                    If Ans2 Then
                        Exit For
                    End If

                Next

                Dim StR1n1 As New StructR1

                Dim CDAnn As New CDArea

                CDAnn.DLengths = Ar(j).DLengths
                CDAnn.DWidth = Ar(j).DWidth
                CDAnn.DHeight = Ar(j).DHeight
                CDAnn.DStrtPt.x = Ar(j).DStrtPt.x
                CDAnn.DStrtPt.y = Ar(j).DStrtPt.y
                CDAnn.DStrtPt.z = Ar(j).DStrtPt.z

                StR1n1.Ar = CDAnn
                StR1n1.Method = DII
                StR1n1.ItmNm = Ari(j)

                Dim Lstmmm As New List(Of CDArea)

                For Kk As Integer = 0 To CDLst.Count - 1
                    Lstmmm.Add(CDLst(Kk))
                Next

                StR1n1.R1CDLst = Lstmmm

                LstR1StArr.Add(StR1n1)

                j += 1
LP:
            Loop

            'Fff()

            '$$$$$
            'Stop
            '$$$$$
            If j > 0 Then
                E1StE2 = New StructE1
                E1StE2.Qty = DItemQtySa
                E1StE2.ItmNm = Ari(j - 1)
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

            If UBound(Ar) >= j Then
                fullflag = True
            End If

            If FindQtyFlg Then
                CDLst.Clear()
                For i As Integer = 0 To CDLst.Count - 1
                    If Not Dchk1(CDLst2(i), CDLst) Then
                        If Not Dchk11(CDLst2(i), CDLst) Then
                            CDLst.Add(CDLst2(i))
                        End If
                    End If
                Next
            End If

            If DrawOpt Then
                If UBound(Ari) <> -1 Then
                    TmpLst.Add(Ari(j - 1))
                    TmpLst.Add(CStr(TotAr))
                    DareaarrSA.Add(TmpLst)
                End If
            End If

        Catch Err As Exception
            MsgBox(Err.Message)
            MessageBox.Show("Error in DrumQtStuff" & vbCrLf & "Data Stuffing failure!", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            siSW.Close()
            connDrums.Close()
            CDLst.Clear()
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

        Return CDLst

    End Function

    Public Function Dfindqty(ByVal itmarr() As String, ByVal strtpos As Integer) As Integer

        Dim nm As String = itmarr(strtpos)
        Dim i As Integer

        Try
            For i = strtpos To UBound(itmarr)
                If itmarr(i) <> nm Then
                    Exit For
                End If
            Next
            Return i - strtpos

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in Dfindqty", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function

    Public Function Dchk11(ByVal Ar1 As CDArea, ByRef Q As List(Of CDArea)) As Boolean

        Dim Ar As New CDArea
        Dim A1 As New CDArea
        Dim A2 As New CDArea
        Dim j As Integer = -1

        Try
            For i As Integer = 0 To Q.Count - 1
                Ar = Q(i)
                If Ar1.DStrtPt.y > Ar.DStrtPt.y AndAlso Ar1.DStrtPt.x = Ar.DStrtPt.x + Ar.DLengths AndAlso Ar1.DStrtPt.y + Ar1.DWidth = Ar.DStrtPt.y + Ar.DWidth AndAlso Ar1.DStrtPt.z = Ar.DStrtPt.z AndAlso Ar.DHeight = Ar1.DHeight Then
                    j = i
                    Exit For
                End If

            Next

            If j <> -1 Then
                Q.RemoveAt(j)

                A1.DStrtPt.x = Ar.DStrtPt.x
                A1.DStrtPt.y = Ar.DStrtPt.y
                A1.DStrtPt.z = Ar.DStrtPt.z
                A1.DLengths = Ar.DLengths
                A1.DWidth = Ar.DWidth - Ar1.DWidth
                A1.DHeight = Ar.DHeight

                A2.DStrtPt.x = Ar.DStrtPt.x
                A2.DStrtPt.y = Ar1.DStrtPt.y
                A2.DStrtPt.z = Ar1.DStrtPt.z
                A2.DLengths = Ar.DLengths + Ar1.DLengths
                A2.DWidth = Ar1.DWidth
                A2.DHeight = Ar1.DHeight

                Q = DUnPush(Q, A1)
                Q = DUnPush(Q, A2)
                Return True
            Else
                Return False
            End If

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in Dchk11", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function

    Public Function Dchk1(ByVal ar As CDArea, ByVal q As List(Of CDArea)) As Boolean

        Dim Ar1 As New CDArea
        Dim Ar2 As New CDArea
        Dim A1 As New CDArea
        Dim A2 As New CDArea
        Dim A3 As New CDArea
        Dim j As Integer = -1

        Try
            For i As Integer = 0 To q.Count - 1
                Ar1 = q(i)
                If Ar1.DStrtPt.y = ar.DStrtPt.y + ar.DWidth AndAlso ar.DHeight = Ar1.DHeight AndAlso ar.DStrtPt.z = Ar1.DStrtPt.z Then

                    If Ar1.DStrtPt.x > ar.DStrtPt.x AndAlso Ar1.DStrtPt.x < ar.DStrtPt.x + ar.DLengths Then
                        j = i
                        Exit For
                    End If
                End If
            Next

            Dim k As Integer = -1

            If j <> -1 Then
                For i As Integer = 0 To q.Count - 1
                    Ar2 = q(i)
                    If Ar2.DStrtPt.y < ar.DStrtPt.y AndAlso Ar2.DStrtPt.y + Ar2.DWidth = ar.DStrtPt.y + ar.DWidth AndAlso Ar2.DStrtPt.x = ar.DStrtPt.x + ar.DLengths AndAlso Ar2.DHeight = ar.DHeight AndAlso Ar2.DStrtPt.z = ar.DStrtPt.z Then
                        k = i
                        Exit For
                    End If
                Next
            End If

            If j <> -1 AndAlso k <> -1 Then
                A1.DStrtPt.x = ar.DStrtPt.x
                A1.DStrtPt.y = ar.DStrtPt.y
                A1.DStrtPt.z = ar.DStrtPt.z
                A1.DLengths = Math.Abs(Ar1.DStrtPt.x - ar.DStrtPt.x)
                A1.DWidth = ar.DWidth
                A1.DHeight = ar.DHeight

                A2.DStrtPt.x = A1.DStrtPt.x + A1.DLengths
                A2.DStrtPt.y = A1.DStrtPt.y
                A2.DStrtPt.z = A1.DStrtPt.z
                A2.DLengths = Ar1.DLengths
                A2.DWidth = ar.DWidth + Ar1.DWidth
                A2.DHeight = Ar1.DHeight

                A3.DStrtPt.x = Ar2.DStrtPt.x
                A3.DStrtPt.y = Ar2.DStrtPt.y
                A3.DStrtPt.z = Ar2.DStrtPt.z
                A3.DLengths = Ar2.DLengths
                A3.DWidth = Ar2.DWidth - ar.DWidth
                A3.DHeight = ar.DHeight

                Return True
            Else
                Return False

            End If

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in Dchk1", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function

    Public Function DMrgX(ByVal Lst As List(Of CDArea), ByVal Ar As CDArea, ByRef Chngd As Boolean) As List(Of CDArea)

        Dim Ar1 As New CDArea
        Dim Ar2 As New CDArea
        Dim Arx As New CDArea
        Dim LstRet As New List(Of CDArea)
        Dim j As Integer = 0
        Dim k As Integer = 0
        Dim Lst1 As New List(Of Integer)

        Try

            For i As Integer = 0 To Lst.Count - 1
                Ar1 = Lst(i)

                If Ar1.DStrtPt.x = Ar.DStrtPt.x + Ar.DLengths AndAlso Ar1.DWidth = Ar.DWidth AndAlso Ar.DHeight = Ar1.DHeight AndAlso Ar1.DStrtPt.y = Ar.DStrtPt.y AndAlso Ar1.DStrtPt.z = Ar.DStrtPt.z Then
                    j = i
                End If

                If Ar1.DStrtPt.x = Ar.DStrtPt.x AndAlso Ar1.DStrtPt.y = Ar.DStrtPt.y AndAlso Ar1.DStrtPt.z = Ar.DStrtPt.z AndAlso Ar1.DLengths = Ar.DLengths AndAlso Ar1.DWidth = Ar.DWidth AndAlso Ar1.DHeight = Ar.DHeight Then
                    k = i
                End If
            Next

            If j <> 0 AndAlso k <> 0 Then
                Ar1 = Lst(j)
                Ar2 = Lst(k)
                Arx.DStrtPt.x = Ar2.DStrtPt.x
                Arx.DStrtPt.y = Ar2.DStrtPt.y
                Arx.DStrtPt.z = Ar2.DStrtPt.z
                Arx.DLengths = Ar1.DLengths + Ar2.DLengths
                Arx.DWidth = Ar1.DWidth
                Arx.DHeight = Ar1.DHeight

                For i As Integer = 0 To Lst.Count - 1
                    If i <> j AndAlso i <> k Then
                        LstRet.Add(Lst(i))
                    End If
                Next
                LstRet.Add(Arx)
                Chngd = True
                Return LstRet
            Else
                Chngd = False
                Return Lst
            End If

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in DMrgX", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return Nothing

    End Function

    Public Function DFindOptMethod(ByVal Ar1 As CDArea, ByVal Ar2 As CDArea, ByRef MaxQty1 As Integer, ByVal TpUp As Boolean) As Integer        'Findout optimum quantity using the area or say dimensions of X, Y, Z in the Container

        Dim Dln1 As Double = Ar1.DLengths
        Dim Dwd1 As Double = Ar1.DWidth
        Dim Dht1 As Double = Ar1.DHeight

        Dim Dln2 As Double = Ar2.DLengths
        Dim Dwd2 As Double = Ar2.DWidth
        Dim Dht2 As Double = Ar2.DHeight

        Dim Dqty1 As Integer = 0
        Dim Dqty2 As Integer = 0
        Dim Dqty3 As Integer = 0
        Dim Dqty4 As Integer = 0
        Dim Dqty5 As Integer = 0
        Dim Dqty6 As Integer = 0

        Dim Dqtypos As String

        Try

            If Dln2 >= Dln1 AndAlso Dwd2 >= Dwd1 AndAlso Dht2 >= Dht1 Then
                Dqty1 = Fix(Dln2 / Dln1) * Fix(Dwd2 / Dwd1) * Fix(Dht2 / Dht1)
            Else
                Dqty1 = 0
            End If
            If Not TpUp Then

                If Dln2 >= Dln1 AndAlso Dwd2 >= Dht1 AndAlso Dht2 >= Dwd1 Then
                    Dqty2 = Fix(Dln2 / Dln1) * Fix(Dwd2 / Dht1) * Fix(Dht2 / Dwd1)
                Else
                    Dqty2 = 0
                End If

                If Dln2 >= Dwd1 AndAlso Dwd2 >= Dht1 AndAlso Dht2 >= Dln1 Then
                    Dqty3 = Fix(Dln2 / Dwd1) * Fix(Dwd2 / Dht1) * Fix(Dht2 / Dln1)
                Else
                    Dqty3 = 0
                End If

            End If

            If Dln2 >= Dwd1 AndAlso Dwd2 >= Dln1 AndAlso Dht2 >= Dht1 Then
                Dqty4 = Fix(Dln2 / Dwd1) * Fix(Dwd2 / Dln1) * Fix(Dht2 / Dht1)
            Else
                Dqty4 = 0
            End If

            If Not TpUp Then

                If Dln2 >= Dht1 AndAlso Dwd2 >= Dwd1 AndAlso Dht2 >= Dln1 Then
                    Dqty5 = Fix(Dln2 / Dht1) * Fix(Dwd2 / Dwd1) * Fix(Dht2 / Dln1)
                Else
                    Dqty5 = 0
                End If

                If Dln2 >= Dht1 AndAlso Dwd2 >= Dln1 AndAlso Dht2 >= Dwd1 Then
                    Dqty6 = Fix(Dln2 / Dht1) * Fix(Dwd2 / Dln1) * Fix(Dht2 / Dwd1)
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

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in DFindOptMethod", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return 0

    End Function

    Public Function DFindCandidate(ByVal Q As List(Of CDArea), ByVal Ar As CDArea) As List(Of Integer)

        Dim Lst As New List(Of Integer)
        Dim Lst2 As New List(Of Integer)
        Dim RetLst As New Queue
        Dim Ar1 As New CDArea
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
        Dim Arr As CDArea
        Dim Lstt As New List(Of Integer)

        Try
            For i As Integer = 0 To Q.Count - 1
                Ar1 = Q(i)

                If Ar1.DWidth >= Ar.DWidth AndAlso Ar1.DHeight >= Ar.DHeight Then
                    Lst.Add(i)
                    Lst1.Add(Ar1)
                End If
            Next

            For j As Integer = 0 To Lst1.Count - 1
                Arr = Lst1(j)

                For i As Integer = 0 To Q.Count - 1
                    Ar1 = Q(i)

                    If Ar1.DStrtPt.x = Arr.DStrtPt.x + Arr.DLengths AndAlso Ar1.DLengths + Arr.DLengths >= Ar.DLengths AndAlso (Ar1.DStrtPt.y = Arr.DStrtPt.y OrElse Ar1.DStrtPt.y + Ar1.DWidth = Arr.DStrtPt.y + Arr.DWidth) AndAlso Ar1.DStrtPt.z = Arr.DStrtPt.z AndAlso Ar1.DStrtPt.y <= Arr.DStrtPt.y Then
                        TLst.Add(Arr)
                        TLst1.Add(Ar1)
                        Lst2.Add(Lst(j))
                        Lstf.Add(i)

                    End If
                Next
            Next

            Try
                Cmd.Connection = connDrums
                Cmd.CommandText = "delete from temp3"
                Cmd.ExecuteNonQuery()
            Catch e As Exception
                connDrums.Dispose()
                connDrums.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\Drums.mdb;Persist Security Info=False"
                connDrums.Open()
                Cmd.Cancel()
                Cmd.Connection = Nothing
                Cmd.Connection = connDrums
                Cmd.CommandText = ""
                Cmd.CommandText = "delete from temp3"
                Cmd.ExecuteNonQuery()
            End Try

            For i As Integer = 0 To TLst.Count - 1
                ArCon = TLst(i)
                Ordr = Lst2(i)
                Ordr1 = Lstf(i)
                Try
                    Cmd.Connection = connDrums
                    Cmd.CommandText = "insert into temp3 values(" & CStr(ArCon.DStrtPt.x) & "," & CStr(ArCon.DStrtPt.y) & "," & CStr(ArCon.DStrtPt.z) & "," & CStr(Ordr) & "," & CStr(Ordr1) & ")"
                    Cmd.ExecuteNonQuery()
                Catch e As Exception
                    Cmd.Cancel()
                    Cmd.Connection = Nothing
                    Cmd.Connection = connDrums
                    Cmd.CommandText = ""
                    Cmd.CommandText = "delete from temp3"
                    Cmd.ExecuteNonQuery()
                End Try

            Next

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in DFindCandidate", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try

        Try
            Cmd.CommandText = "select * from temp3 order by z desc ,x asc,y asc"
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

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in DFindCandidate", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try

    End Function

    Public Function DUnionItrP(ByVal Ar1 As CDArea, ByVal Ar2 As CDArea) As List(Of CDArea)

        Dim ArRet1 As New CDArea
        Dim ArRet2 As New CDArea
        Dim LstRet As New List(Of CDArea)

        Try
            Ar1.DStrtPt.x = Math.Round(Ar1.DStrtPt.x, 4)
            Ar1.DStrtPt.y = Math.Round(Ar1.DStrtPt.y, 4)
            Ar1.DStrtPt.z = Math.Round(Ar1.DStrtPt.z, 4)

            Ar1.DLengths = Math.Round(Ar1.DLengths, 4)
            Ar1.DWidth = Math.Round(Ar1.DWidth, 4)
            Ar1.DHeight = Math.Round(Ar1.DHeight, 4)

            Ar2.DStrtPt.x = Math.Round(Ar2.DStrtPt.x, 4)
            Ar2.DStrtPt.y = Math.Round(Ar2.DStrtPt.y, 4)
            Ar2.DStrtPt.z = Math.Round(Ar2.DStrtPt.z, 4)

            Ar2.DLengths = Math.Round(Ar2.DLengths, 4)
            Ar2.DWidth = Math.Round(Ar2.DWidth, 4)
            Ar2.DHeight = Math.Round(Ar2.DHeight, 4)

            If Ar1.DStrtPt.y = Ar2.DStrtPt.y AndAlso Ar1.DStrtPt.z = Ar2.DStrtPt.z AndAlso Ar1.DHeight = Ar2.DHeight Then

                If (Ar2.DStrtPt.x = (Ar1.DStrtPt.x + Ar1.DLengths)) Then

                    If Ar1.DWidth = Ar2.DWidth Then

                        ArRet1.DStrtPt.x = Ar1.DStrtPt.x
                        ArRet1.DStrtPt.y = Ar1.DStrtPt.y
                        ArRet1.DStrtPt.z = Ar1.DStrtPt.z
                        ArRet1.DLengths = Ar1.DLengths + Ar2.DLengths
                        ArRet1.DWidth = Ar1.DWidth
                        ArRet1.DHeight = Ar1.DHeight

                        ArRet2.DStrtPt.x = 0
                        ArRet2.DStrtPt.y = 0
                        ArRet2.DStrtPt.z = 0
                        ArRet2.DLengths = 0
                        ArRet2.DWidth = 0
                        ArRet2.DHeight = 0

                        LstRet.Add(ArRet1)
                        LstRet.Add(ArRet2)

                        Return LstRet

                    Else

                        If Ar1.DWidth < Ar2.DWidth Then

                            ArRet1.DStrtPt.x = Ar1.DStrtPt.x
                            ArRet1.DStrtPt.y = Ar1.DStrtPt.y
                            ArRet1.DStrtPt.z = Ar1.DStrtPt.z
                            ArRet1.DLengths = Ar1.DLengths + Ar2.DLengths
                            ArRet1.DWidth = Ar1.DWidth
                            ArRet1.DHeight = Ar1.DHeight

                            ArRet2.DStrtPt.x = Ar2.DStrtPt.x
                            ArRet2.DStrtPt.y = Ar1.DStrtPt.y + Ar1.DWidth
                            ArRet2.DStrtPt.z = Ar1.DStrtPt.z
                            ArRet2.DLengths = Ar2.DLengths
                            ArRet2.DWidth = Ar2.DWidth - Ar1.DWidth
                            ArRet2.DHeight = Ar2.DHeight

                            LstRet.Add(ArRet1)
                            LstRet.Add(ArRet2)

                            Return LstRet

                        End If

                        If Ar2.DWidth < Ar1.DWidth Then

                            ArRet1.DStrtPt.x = Ar1.DStrtPt.x
                            ArRet1.DStrtPt.y = Ar1.DStrtPt.y
                            ArRet1.DStrtPt.z = Ar1.DStrtPt.z
                            ArRet1.DLengths = Ar1.DLengths + Ar2.DLengths
                            ArRet1.DWidth = Ar2.DWidth
                            ArRet1.DHeight = Ar1.DHeight

                            ArRet2.DStrtPt.x = Ar1.DStrtPt.x
                            ArRet2.DStrtPt.y = Ar2.DStrtPt.y + Ar2.DWidth
                            ArRet2.DStrtPt.z = Ar1.DStrtPt.z
                            ArRet2.DLengths = Ar1.DLengths
                            ArRet2.DWidth = Ar1.DWidth - Ar2.DWidth
                            ArRet2.DHeight = Ar2.DHeight

                            LstRet.Add(ArRet1)
                            LstRet.Add(ArRet2)

                            Return LstRet

                        End If
                    End If

                End If

                If (Ar1.DStrtPt.x = (Ar2.DStrtPt.x + Ar2.DLengths)) Then

                    If Ar1.DWidth = Ar2.DWidth Then

                        ArRet1.DStrtPt.x = Ar2.DStrtPt.x
                        ArRet1.DStrtPt.y = Ar2.DStrtPt.y
                        ArRet1.DStrtPt.z = Ar2.DStrtPt.z
                        ArRet1.DLengths = Ar1.DLengths + Ar2.DLengths
                        ArRet1.DWidth = Ar1.DWidth
                        ArRet1.DHeight = Ar1.DHeight

                        ArRet2.DStrtPt.x = 0
                        ArRet2.DStrtPt.y = 0
                        ArRet2.DStrtPt.z = 0
                        ArRet2.DLengths = 0
                        ArRet2.DWidth = 0
                        ArRet2.DHeight = 0

                        LstRet.Add(ArRet1)
                        LstRet.Add(ArRet2)

                        Return LstRet

                    Else

                        If Ar2.DWidth < Ar1.DWidth Then

                            ArRet1.DStrtPt.x = Ar2.DStrtPt.x
                            ArRet1.DStrtPt.y = Ar2.DStrtPt.y
                            ArRet1.DStrtPt.z = Ar2.DStrtPt.z
                            ArRet1.DLengths = Ar2.DLengths + Ar1.DLengths
                            ArRet1.DWidth = Ar2.DWidth
                            ArRet1.DHeight = Ar2.DHeight

                            ArRet2.DStrtPt.x = Ar1.DStrtPt.x
                            ArRet2.DStrtPt.y = Ar2.DStrtPt.y + Ar2.DWidth
                            ArRet2.DStrtPt.z = Ar2.DStrtPt.z
                            ArRet2.DLengths = Ar1.DLengths
                            ArRet2.DWidth = Ar1.DWidth - Ar2.DWidth
                            ArRet2.DHeight = Ar1.DHeight

                            LstRet.Add(ArRet1)
                            LstRet.Add(ArRet2)

                            Return LstRet

                        End If

                        If Ar1.DWidth < Ar2.DWidth Then

                            ArRet1.DStrtPt.x = Ar2.DStrtPt.x
                            ArRet1.DStrtPt.y = Ar2.DStrtPt.y
                            ArRet1.DStrtPt.z = Ar2.DStrtPt.z
                            ArRet1.DLengths = Ar2.DLengths + Ar1.DLengths
                            ArRet1.DWidth = Ar1.DWidth
                            ArRet1.DHeight = Ar2.DHeight

                            ArRet2.DStrtPt.x = Ar2.DStrtPt.x
                            ArRet2.DStrtPt.y = Ar1.DStrtPt.y + Ar1.DWidth
                            ArRet2.DStrtPt.z = Ar2.DStrtPt.z
                            ArRet2.DLengths = Ar2.DLengths
                            ArRet2.DWidth = Ar2.DWidth - Ar1.DWidth
                            ArRet2.DHeight = Ar1.DHeight

                            LstRet.Add(ArRet1)
                            LstRet.Add(ArRet2)

                            Return LstRet

                        End If

                    End If

                End If

            End If

            ArRet1.DStrtPt.x = Ar1.DStrtPt.x
            ArRet1.DStrtPt.y = Ar1.DStrtPt.y
            ArRet1.DStrtPt.z = Ar1.DStrtPt.z
            ArRet1.DLengths = Ar1.DLengths + Ar2.DLengths

            If Ar1.DWidth < Ar2.DWidth Then

                ArRet1.DWidth = Ar1.DWidth

            Else

                ArRet1.DWidth = Ar2.DWidth

            End If

            ArRet1.DHeight = Ar1.DHeight

            If Ar1.DStrtPt.y = Ar2.DStrtPt.y Then

                ArRet2.DStrtPt.y = Ar1.DStrtPt.y + Ar1.DWidth

            Else

                ArRet2.DStrtPt.y = Ar2.DStrtPt.y

            End If

            ArRet2.DStrtPt.z = Ar2.DStrtPt.z

            If Ar2.DWidth < Ar1.DWidth Then

                ArRet2.DLengths = Ar1.DLengths
                ArRet2.DStrtPt.x = Ar1.DStrtPt.x

            Else

                ArRet2.DLengths = Ar2.DLengths
                ArRet2.DStrtPt.x = Ar2.DStrtPt.x

            End If

            ArRet2.DWidth = Math.Abs(Ar2.DWidth - Ar1.DWidth)
            ArRet2.DHeight = Ar2.DHeight


            If Ar1.DStrtPt.x = Ar2.DStrtPt.x AndAlso Ar1.DLengths < Ar2.DLengths AndAlso Ar2.DStrtPt.y = Ar1.DStrtPt.y + Ar1.DWidth Then

                ArRet1.DLengths = Ar1.DLengths
                ArRet1.DWidth = Ar1.DWidth + Ar2.DWidth
                ArRet1.DHeight = Ar1.DHeight

                ArRet2.DStrtPt.x = Ar1.DStrtPt.x + Ar1.DLengths
                ArRet2.DStrtPt.y = Ar2.DStrtPt.y
                ArRet2.DStrtPt.z = Ar1.DStrtPt.z
                ArRet2.DLengths = Ar2.DLengths - Ar1.DLengths
                ArRet2.DWidth = Ar2.DWidth
                ArRet2.DHeight = Ar1.DHeight

            End If

            If Ar1.DStrtPt.x < Ar2.DStrtPt.x AndAlso Math.Abs(Ar2.DStrtPt.y - Ar1.DStrtPt.y - Ar1.DWidth) < 0.00001 AndAlso Math.Abs(Ar1.DStrtPt.x + Ar1.DLengths - Ar2.DStrtPt.x - Ar2.DLengths) < 0.00001 Then

                ArRet1.DStrtPt.x = Ar2.DStrtPt.x
                ArRet1.DStrtPt.y = Ar1.DStrtPt.y
                ArRet1.DStrtPt.z = Ar1.DStrtPt.z
                ArRet1.DLengths = Ar2.DLengths
                ArRet1.DWidth = Ar1.DWidth + Ar2.DWidth
                ArRet1.DHeight = Ar1.DHeight

                ArRet2.DStrtPt.x = Ar1.DStrtPt.x
                ArRet2.DStrtPt.y = Ar1.DStrtPt.y
                ArRet2.DStrtPt.z = Ar1.DStrtPt.z
                ArRet2.DLengths = Ar2.DLengths - Ar1.DLengths
                ArRet2.DWidth = Ar1.DWidth
                ArRet2.DHeight = Ar1.DHeight

            End If

            LstRet.Add(ArRet1)
            LstRet.Add(ArRet2)

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in DUnionItrP", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return LstRet

    End Function

    Public Function DUnPush(ByVal CDLstx As List(Of CDArea), ByVal Ar As CDArea) As List(Of CDArea)

        Dim LstS1 As New List(Of CDArea)
        Dim A1 As CDArea
        Dim Flag As Boolean = False

        Dim Lsty As New List(Of CDArea)
        Dim Arar As CDArea()
        Dim Arf As New CDArea
        Dim Kk As New List(Of CDArea)
        Dim Kk1 As New List(Of CDArea)

        Try
            Ar.DStrtPt.x = Math.Round(Ar.DStrtPt.x, 4)
            Ar.DStrtPt.y = Math.Round(Ar.DStrtPt.y, 4)
            Ar.DStrtPt.z = Math.Round(Ar.DStrtPt.z, 4)

            Ar.DLengths = Math.Round(Ar.DLengths, 4)
            Ar.DWidth = Math.Round(Ar.DWidth, 4)
            Ar.DHeight = Math.Round(Ar.DHeight, 4)

            For i As Integer = 0 To Lsty.Count - 1
                CDLstx.Add(Lsty(i))
            Next

            Arar = CDLstx.ToArray

            For i As Integer = LBound(Arar) To UBound(Arar)
                A1 = Arar(i)

                If A1.DUnionItrX(Ar) Is Nothing Then

                Else

                    Flag = True
                End If

            Next

            If Not Flag Then

                CDLstx.Add(Ar)

                Return CDLstx
            Else

                Arf = Nothing
                Kk.Clear()
                Do While CDLstx.Count > 0
                    A1 = CDLstx.Item(CDLstx.Count - 1)

                    A1.DStrtPt.x = Math.Round(A1.DStrtPt.x, 4)
                    A1.DStrtPt.y = Math.Round(A1.DStrtPt.y, 4)
                    A1.DStrtPt.z = Math.Round(A1.DStrtPt.z, 4)

                    A1.DLengths = Math.Round(A1.DLengths, 4)
                    A1.DWidth = Math.Round(A1.DWidth, 4)
                    A1.DHeight = Math.Round(A1.DHeight, 4)

                    CDLstx.RemoveAt(CDLstx.Count - 1)

                    If A1.DUnionItrX(Ar) Is Nothing Then

                        LstS1.Add(A1)

                    Else
                        Arf = A1.DUnionItrX(Ar)
                        Kk.Add(Arf)
                        Kk1.Add(A1)
                    End If
                Loop

            End If

            Dim iii As DataRow()
            Dim ii As Integer

            DeleteTable("DTemp4")

            Dim Ar1 As New CDArea

            If Kk.Count = 1 Then

                LstS1.Add(Kk(0))

            Else
                For i As Integer = 0 To Kk.Count - 1
                    Ar1 = Kk(i)
                    DInsertTable("DTemp4", New Object() {CStr(Ar1.DStrtPt.x), CStr(Ar1.DStrtPt.y), CStr(Ar1.DStrtPt.z), CStr(i)})
                Next

                iii = DGetf("DTemp4", "", "z asc ,x asc ,y asc")
                ii = iii(0)("i")


                For i As Integer = 0 To Kk.Count - 1
                    If i = ii Then
                        LstS1.Add(Kk(i))
                    Else
                        LstS1.Add(Kk1(i))
                    End If
                Next
            End If

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in DUnPush", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return LstS1

    End Function

    Public Function DGetf(ByVal TbName As String, ByVal Fltr As String, ByVal SrtCol As String) As DataRow()        'Enter the values in to the Xml file and also making Schema of this

        Dim GfDt As New System.Data.DataTable
        Dim Rw() As DataRow = Nothing
        Dim XmlDd As New System.Xml.XmlDataDocument
        Dim XmlRdr As Xml.XmlReader

        Try
            XmlRdr = Xml.XmlReader.Create(CurDir() & "/" & TbName & ".xml")
            XmlRdr.Settings.Schemas.Add(vbNull, CurDir() & "/" & TbName & ".xsd")

            XmlDd.DataSet.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema
            XmlDd.DataSet.ReadXml(XmlRdr, XmlReadMode.InferTypedSchema)

            Rw = XmlDd.DataSet.Tables(0).Select(Fltr, SrtCol)
            XmlRdr.Close()

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in DGetf", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return Rw

    End Function

    Public Function DrumStuffDHE(ByVal Arc As CDArea, ByVal Ar() As CDArea, ByVal Ari() As String, ByVal ArWt() As Single, ByVal SaveOpt As Boolean, ByVal ShowEmpty As Boolean, ByVal OutFile As String, ByVal DrawArc As Boolean, ByVal TranspArr() As Boolean, ByVal TopUp() As Boolean, ByVal TxtOpt As Boolean, ByVal DrawOpt As Boolean, ByVal FindQtyFlg As Boolean, ByVal ChngFlg As Boolean, ByVal ColArr As List(Of List(Of Byte))) As List(Of CDArea)        'Drum stuffing in diameter and height of drums are equal
        'Stop
        Try
            Dim CDLst2 As New List(Of CDArea)
            Dim CDStk As New Stack(Of CDArea)
            Dim Arm As New List(Of Integer)
            Dim Lstm As New List(Of CDArea)
            Dim TmpLst As New List(Of String)
            Dim CDLstj As New List(Of CDArea)

            Dim A1 As New CDArea
            Dim A2 As New CDArea

            Dim Art As New CDArea
            Dim Arp As New CDArea
            Dim Are As New CDArea
            Dim Aru As New CDArea
            Dim Arb As New CDArea

            Dim Arm1 As Integer
            Dim II As Integer
            Dim Traval As Single

            Dim SzChg As Integer = 0

            Dim QtyFlg As Boolean = True
            Dim Ans1 As Boolean

            Dim Ordr As Integer
            Dim Col As String = Nothing
            Dim TotAr As Double
            Dim OldItemQty As Integer = 0

            Try

                If SaveOpt Then
                    configid = InputBox("Enter Config Id")
                End If

                Dim Ptx As New CDPoint

                Ptx.x = Arc.DLengths
                Ptx.y = Arc.DWidth
                Ptx.z = Arc.DHeight

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

                    Ard.DStrtPt.x = Arc.DLengths
                    Ard.DStrtPt.y = 0
                    Ard.DStrtPt.z = 0
                    Ard.DLengths = 0.5
                    Ard.DWidth = Arc.DWidth
                    Ard.DHeight = Arc.DHeight

                    If DrawOpt Or DrawArc Then

                    End If

                    Ard1.DStrtPt.x = Arc.DLengths - 0.01
                    Ard1.DStrtPt.y = 0
                    Ard1.DStrtPt.z = 0
                    Ard1.DLengths = 0.5
                    Ard1.DWidth = Ard.DWidth
                    Ard1.DHeight = Ard.DHeight

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

                Arc.DStrtPt.x = 0
                Arc.DStrtPt.y = 0
                Arc.DStrtPt.z = 0

                Dim j As Integer = 0
                TotAr = 0
                DrmAreaArrSA.Clear()

                'Stop

                For i As Integer = 0 To CDLst.Count - 1
                    CDLst2.Add(CDLst(i))
                Next

                DItemQtySa = 0
                DtotwtSA = 0

                If Not IsNothing(Ari) Then
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

                Do While Not CDLst.Count = 0 And j <= UBound(Ar)

                    If j > 0 Then
                        If Ari(j) <> Ari(j - 1) Then
                            ImgName = (CInt(ImgName) + 1).ToString
                        End If
                    End If

                    Ordr = 0

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

                    If j > 0 And Not IsNothing(Ari) Then

                        If Ari(j - 1) <> Ari(j) Then
                            E1StE2 = New StructE1
                            E1StE2.Qty = DItemQtySa
                            E1StE2.ItmNm = Ari(j - 1)
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

                            TransactionsMenu.lblStatusINm.Text = "  Stuffing item : " & Ari(j)
                            TransactionsMenu.lblStatusINm.Refresh()
                        Else

                            TransactionsMenu.lblStatusINm.Text = "  Stuffing item : " & Ari(j)
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

                            If Ari(j - 1) <> Ari(j) Then

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

                    'Stop

                    Arm1 = DrumFindOptDHE(CDLst, Ar(j), TopUp(j))

                    Art = Nothing
                    If Arm1 <> -1 Then
                        Art = CDLst(Arm1)
                    End If

                    Dim Arn As New List(Of Integer)
                    Dim Lstn As New List(Of CDArea)

                    Dim B1 As New CDArea
                    Dim B2 As New CDArea
                    Dim Pos1 As Integer

                    Arm = Nothing
                    Arn = Nothing

                    'Stop

                    Arn = DrumFindCandidate1DHE(CDLst, Ar(j), TopUp(j))

                    'Stop

                    Pos1 = 0
                    If Not Arn Is Nothing Then
                        Pos1 = 0
                    Else

                        Dim Arxx As New CDArea

                        Arxx.DLengths = Ar(j).DWidth
                        Arxx.DWidth = Ar(j).DLengths
                        Arxx.DHeight = Ar(j).DHeight

                        Arn = DrumFindCandidate1DHE(CDLst, Arxx, TopUp(j))

                        If Not Arn Is Nothing Then
                            Pos1 = 1
                        Else
                            If Not TopUp(j) Then
                                Arxx.DLengths = Ar(j).DLengths
                                Arxx.DWidth = Ar(j).DHeight
                                Arxx.DHeight = Ar(j).DWidth

                                Arn = DrumFindCandidate1DHE(CDLst, Arxx, False)

                                If Not Arn Is Nothing Then
                                    Pos1 = 2
                                End If
                            End If
                        End If
                    End If

                    'Stop

                    If Arn Is Nothing Then

                        Arm = DrumFindCandidateDHE(CDLst, Ar(j))
                        'Stop
                        If Not Arm Is Nothing Then
                            If Arm(0) = Arm1 Then Arm = Nothing
                        End If
                    End If

                    If Not Arm Is Nothing Then

                        Lstm = DrumUnionItrPDHE(CDLst(Arm(0)), CDLst(Arm(1)))

                        'Stop

                        A1 = Lstm(0)
                        A2 = Lstm(1)

                    End If

                    If Not Arn Is Nothing Then

                        Lstm = DrumUnionItrPDHE(CDLst(Arn(0)), CDLst(Arn(1)))

                        B1 = Lstm(0)
                        B2 = Lstm(1)

                    End If

                    If Arm Is Nothing And Arm1 = -1 Then
                        If DrawOpt Then

                        End If

                        For m As Integer = j To UBound(Ari) - 1
                            If Ari(m) <> Ari(j) Then
                                j = m

                                GoTo LP

                            End If
                        Next

                        j = UBound(Ari) + 1

                        GoTo LP

                    Else
                        If Arn Is Nothing And Arm1 = -1 Then
                            If DrawOpt Then

                            End If

                            For m As Integer = j To UBound(Ari) - 1
                                If Ari(m) <> Ari(j) Then
                                    j = m
                                    GoTo LP

                                End If
                            Next
                            j = UBound(Ari)

                        End If
                    End If

                    If Not Arm Is Nothing Or Not Arn Is Nothing Then


                        Cmd.Connection = connDrums

                        DeleteTable("DTemp2")
z:

                        Ordr = 0
                        If Not Arm Is Nothing Then

                            DInsertTable("DTemp2", New Object() {CStr(A1.DStrtPt.x), CStr(A1.DStrtPt.y), CStr(A1.DStrtPt.z), CStr(1)})
                        End If

                        If Not Arn Is Nothing Then
                            DInsertTable("DTemp2", New Object() {CStr(B1.DStrtPt.x), CStr(B1.DStrtPt.y), CStr(B1.DStrtPt.z), CStr(2)})

                        End If

                        If Not Art Is Nothing Then
                            DInsertTable("DTemp2", New Object() {CStr(Art.DStrtPt.x), CStr(Art.DStrtPt.y), CStr(Art.DStrtPt.z), CStr(3)})

                        End If

                        Dim Rwx As DataRow() = Nothing

                        Try
                            If Not Arm Is Nothing Then

                                Rwx = DGetf("DTemp2", "", "z DESC ,x ASC,y ASC")
                            End If

                            If Not Arn Is Nothing Then

                                Rwx = DGetf("DTemp2", "", "z DESC ,x ASC,y ASC")
                            End If

                            If Arn Is Nothing And Arm Is Nothing Then

                                Rwx = DGetf("DTemp2", "", "z DESC ,x ASC")
                            End If

                            If Arm Is Nothing And Arn Is Nothing Then

                                Rwx = DGetf("DTemp2", "", "z DESC ,x ASC,y ASC")
                            End If

                        Catch Ex As Exception

                            MsgBox(Ex.Message, MsgBoxStyle.Critical, "Exception :: In Function 'Stuff' " & vbCrLf & "Programme Running is failure!")

                        Finally
                            Ordr = Rwx(0)("i")
                        End Try

                        If Ordr = 3 Then
                            CDLst.RemoveAt(Arm1)
                        Else
                            If Ordr = 1 Then
                                Art = A1
                                CDLst.RemoveAt(Arm(0))
                                If Arm(0) < Arm(1) Then
                                    CDLst.RemoveAt(Arm(1) - 1)
                                Else
                                    CDLst.RemoveAt(Arm(1))
                                End If
                                'Stop
                                CDLst = DrumUnPushDHE(CDLst, A2)

                            End If

                            If Ordr = 2 Then
                                If Pos1 = 1 Then
                                    Dim tmp As Double = Ar(j).DWidth
                                    Ar(j).DWidth = Ar(j).DLengths
                                    Ar(j).DLengths = tmp
                                End If

                                If Pos1 = 2 Then
                                    Dim tmp As Double = Ar(j).DHeight
                                    Ar(j).DHeight = Ar(j).DWidth
                                    Ar(j).DWidth = tmp
                                End If

                                Art = B1
                                CDLst.RemoveAt(Arn(0))
                                If Arn(0) < Arn(1) Then
                                    CDLst.RemoveAt(Arn(1) - 1)
                                Else
                                    CDLst.RemoveAt(Arn(1))
                                End If

                                CDLst.Add(B2)

                            End If
                            If Ordr = 3 Then
                                CDLst.RemoveAt(Arm1)
                            End If
                        End If
                    Else

                        If Arm1 <> -1 Then
                            CDLst.RemoveAt(Arm1)
                        End If
                    End If

                    Dim Qty As Integer
                    If ChngFlg Then
                        '######
                        'Stop
                        '########
                        II = DrumFindOptMethodDHE(Ar(j), Art, Qty, TopUp(j))

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

                        Dim Dln As Double = Ar(j).DLengths
                        Dim Dwd As Double = Ar(j).DWidth
                        Dim Dht As Double = Ar(j).DHeight

                        'Stop

                        Dim Nm As String = Ari(j)
                        Dim P As Integer = j

                        If II = 1 Then

                        End If

                        If II = 2 Then
                            Ar(P).DLengths = Dln
                            Ar(P).DWidth = Dht
                            Ar(P).DHeight = Dwd

                        End If

                        If II = 3 Then
                            Ar(P).DLengths = Dwd
                            Ar(P).DWidth = Dht
                            Ar(P).DHeight = Dln

                        End If

                        If II = 4 Then
                            Ar(P).DLengths = Dwd
                            Ar(P).DWidth = Dln
                            Ar(P).DHeight = Dht

                        End If

                        If II = 5 Then
                            Ar(P).DLengths = Dht
                            Ar(P).DWidth = Dwd
                            Ar(P).DHeight = Dln

                        End If

                        If II = 6 Then
                            Ar(P).DLengths = Dht
                            Ar(P).DWidth = Dln
                            Ar(P).DHeight = Dwd

                        End If

                    End If

                    Dim Flg As Boolean = Math.Abs(((Ar(j).DLengths * Ar(j).DWidth * Ar(j).DHeight) * Qty) - (Art.DLengths * Art.DWidth * Art.DHeight)) < 0.01

                    Dim Mm As Integer = DrumFindQtyDHE(Ari, j)

                    If Mm >= Qty And Flg Then

                        If DrawOpt Then
                            If TranspArr(j) Then
                                Traval = 0.8
                            Else
                                Traval = 0
                            End If
                            Ar(j).DStrtPt.x = Art.DStrtPt.x
                            Ar(j).DStrtPt.y = Art.DStrtPt.y
                            Ar(j).DStrtPt.z = Art.DStrtPt.z

                            'Remain as it is commented do not use
                            'Ar(j).AutoDraw(OutFile, Col, traval, "file:///c:/t2.png", Ari(j), ArWt(j), QtyFlg, TxtOpt, "", 0, True, "c")
                            j += Qty
                            DItemQtySa += Qty
                        Else
                            j += Qty

                            DItemQtySa += Qty
                            DplclstSA(DItemNoSA) = DItemQtySa
                            DtotwtSA += ArWt(j)
                            GoTo LP
                        End If

                    End If

                    Arm = Nothing
                    Arn = Nothing

                    Ar(j).DStrtPt.x = Art.DStrtPt.x
                    Ar(j).DStrtPt.y = Art.DStrtPt.y
                    Ar(j).DStrtPt.z = Art.DStrtPt.z

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
                            Traval = 0.8
                        Else
                            Traval = 0
                        End If
                    End If
                    If j = UBound(Ar) Then

                    End If
                    If DrawOpt Then
                        If j <> 0 Then
                            If Ari(j) <> Ari(j - 1) Then
                                TmpLst.Add(Ari(j - 1))
                                TmpLst.Add(CStr(TotAr))
                                DrmAreaArrSA.Add(TmpLst)
                                TotAr = 0
                                TotAr = TotAr + (Ar(j).DLengths * Ar(j).DWidth * Ar(j).DHeight)
                            Else
                                TotAr = TotAr + (Ar(j).DLengths * Ar(j).DWidth * Ar(j).DHeight)
                            End If
                        Else
                            TotAr = TotAr + (Ar(j).DLengths * Ar(j).DWidth * Ar(j).DHeight)
                        End If
                    End If

                    '$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

                    DDiaL = Ar(j).DLengths
                    DDiaW = Ar(j).DWidth

                    DHt = Ar(j).DHeight

                    If DDiaL = DDiaW Then

                        DDia = DDiaL
                        DRds = DDia * 0.5
                    Else
                        DDia = (DDiaL + DDiaW) * 0.5

                    End If

                    '$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

                    If DrawOpt Then
                        TxtOpt = True

                        'Implement Here/ 10 April 2008 //Modified 26 May 2K8 2.51 PM

                        'Stop

                        Ar(j).AutoDrawDrmSADHE(OutFile, Col, Traval, "s" & ImgName & ".png", Ari(j), ArWt(j), QtyFlg, TxtOpt, Ari(j), II, True, "b", DDia, DRds, DHt)

                        'Stop

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

                    If Not IsNothing(Ari) Then
                        '*********************************************
                        'Stop
                        Progress8.iQty = DItemQtySa
                        TransactionsMenu.lblStatus.Text = " Numbers ::   " & CStr(DItemQtySa) & "    -> Items stuffed"
                        TransactionsMenu.btnStatus.Visible = True

                        DEventful()
                        TransactionsMenu.pbCSPD.Visible = True
                        'PB()
                        DProgressBarRunning()

                        If DItemQtySa > 20 Then

                            'Stop
                            'MsgBox("Ok")
                            'Stop

                        End If

                        TransactionsMenu.lblStatus.Refresh()
                        System.Windows.Forms.Application.DoEvents()
                        '*********************************************

                        If exflg Then
                            exflg = False
                            GoTo LP
                        End If
                    End If

                    'Stop

                    Q = Art.DrumSubtractDHE(Ar(j))

                    'Stop

                    Dim Dd As New CDArea

                    If Not Q Is Nothing Then
                        If CDLst.Count = 0 Then
                            Do While Not Q.Count = 0

                                Dd = Q.Dequeue

                                CDLst.Add(Dd)

                            Loop
                        Else
                            Do While Q.Count > 0
                                Arb = Q.Dequeue
                                Ans1 = False

                                CDLst = DrumUnPushDHE(CDLst, Arb)

                            Loop

                        End If

                    End If

                    Dim Ans2 As Boolean

                    For i As Integer = 0 To CDLst.Count - 1

                        Dim Arx As New CDArea

                        Arx = CDLst(i)

                        CDLst = DrumMrgXDHE(CDLst, Arx, Ans2)

                        If Ans2 Then
                            Exit For
                        End If
                    Next

                    Dim StR1n1 As New StructR1

                    Dim CDAnn As New CDArea

                    CDAnn.DLengths = Ar(j).DLengths
                    CDAnn.DWidth = Ar(j).DWidth
                    CDAnn.DHeight = Ar(j).DHeight
                    CDAnn.DStrtPt.x = Ar(j).DStrtPt.x
                    CDAnn.DStrtPt.y = Ar(j).DStrtPt.y
                    CDAnn.DStrtPt.z = Ar(j).DStrtPt.z

                    StR1n1.Ar = CDAnn
                    StR1n1.Method = II
                    StR1n1.ItmNm = Ari(j)

                    Dim Lstmmm As New List(Of CDArea)

                    For Kk As Integer = 0 To CDLst.Count - 1
                        Lstmmm.Add(CDLst(Kk))
                    Next

                    StR1n1.R1CDLst = Lstmmm

                    LstR1StArr.Add(StR1n1)

                    j += 1
LP:
                Loop

                DrumFffDHE()

                '$$$$$
                'Stop
                '$$$$$

                If j > 0 Then
                    E1StE2 = New StructE1
                    E1StE2.Qty = DItemQtySa
                    E1StE2.ItmNm = Ari(j - 1)
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

                If UBound(Ar) >= j Then
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
                    If UBound(Ari) <> -1 Then
                        TmpLst.Add(Ari(j - 1))
                        TmpLst.Add(CStr(TotAr))
                        DrmAreaArrSA.Add(TmpLst)
                    End If
                End If

            Catch Ex As Exception
                MsgBox(Ex.Message)
                MsgBox(Ex.ToString)
                MessageBox.Show("Error in DrumStuffDHE" & vbCrLf & "Data Stuffing failure!", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
        Catch Err As Exception
            Return Nothing
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in DrumStuffDHE", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return CDLst

    End Function

    Public Function Drumchk11DHE(ByVal Ar1 As CDArea, ByRef Q As List(Of CDArea)) As Boolean

        Dim Ar As New CDArea
        Dim A1 As New CDArea
        Dim A2 As New CDArea
        Dim j As Integer = -1

        Try
            For i As Integer = 0 To Q.Count - 1

                Ar = Q(i)
                If Ar1.DStrtPt.y > Ar.DStrtPt.y AndAlso Ar1.DStrtPt.x = Ar.DStrtPt.x + Ar.DLengths AndAlso Ar1.DStrtPt.y + Ar1.DWidth = Ar.DStrtPt.y + Ar.DWidth AndAlso Ar1.DStrtPt.z = Ar.DStrtPt.z AndAlso Ar.DHeight = Ar1.DHeight Then
                    j = i
                    Exit For
                End If
            Next

            If j <> -1 Then

                Q.RemoveAt(j)

                A1.DStrtPt.x = Ar.DStrtPt.x
                A1.DStrtPt.y = Ar.DStrtPt.y
                A1.DStrtPt.z = Ar.DStrtPt.z
                A1.DLengths = Ar.DLengths
                A1.DWidth = Ar.DWidth - Ar1.DWidth
                A1.DHeight = Ar.DHeight

                A2.DStrtPt.x = Ar.DStrtPt.x
                A2.DStrtPt.y = Ar1.DStrtPt.y
                A2.DStrtPt.z = Ar1.DStrtPt.z
                A2.DLengths = Ar.DLengths + Ar1.DLengths
                A2.DWidth = Ar1.DWidth
                A2.DHeight = Ar1.DHeight

                Q = DrumUnPushDHE(Q, A1)
                Q = DrumUnPushDHE(Q, A2)
                Return True
            Else
                Return False
            End If
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in Drumchk11DHE", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function

    Public Function Drumchk1DHE(ByVal ar As CDArea, ByVal q As List(Of CDArea)) As Boolean

        Dim Ar1 As New CDArea
        Dim Ar2 As New CDArea
        Dim A1 As New CDArea
        Dim A2 As New CDArea
        Dim A3 As New CDArea
        Dim j As Integer = -1

        Try
            For i As Integer = 0 To q.Count - 1
                Ar1 = q(i)
                If Ar1.DStrtPt.y = ar.DStrtPt.y + ar.DWidth AndAlso ar.DHeight = Ar1.DHeight AndAlso ar.DStrtPt.z = Ar1.DStrtPt.z Then

                    If Ar1.DStrtPt.x > ar.DStrtPt.x AndAlso Ar1.DStrtPt.x < ar.DStrtPt.x + ar.DLengths Then
                        j = i
                        Exit For
                    End If
                End If
            Next

            Dim k As Integer = -1

            If j <> -1 Then
                For i As Integer = 0 To q.Count - 1
                    Ar2 = q(i)
                    If Ar2.DStrtPt.y < ar.DStrtPt.y AndAlso Ar2.DStrtPt.y + Ar2.DWidth = ar.DStrtPt.y + ar.DWidth AndAlso Ar2.DStrtPt.x = ar.DStrtPt.x + ar.DLengths AndAlso Ar2.DHeight = ar.DHeight AndAlso Ar2.DStrtPt.z = ar.DStrtPt.z Then
                        k = i
                        Exit For
                    End If
                Next
            End If

            If j <> -1 AndAlso k <> -1 Then
                A1.DStrtPt.x = ar.DStrtPt.x
                A1.DStrtPt.y = ar.DStrtPt.y
                A1.DStrtPt.z = ar.DStrtPt.z
                A1.DLengths = Math.Abs(Ar1.DStrtPt.x - ar.DStrtPt.x)
                A1.DWidth = ar.DWidth
                A1.DHeight = ar.DHeight

                A2.DStrtPt.x = A1.DStrtPt.x + A1.DLengths
                A2.DStrtPt.y = A1.DStrtPt.y
                A2.DStrtPt.z = A1.DStrtPt.z
                A2.DLengths = Ar1.DLengths
                A2.DWidth = ar.DWidth + Ar1.DWidth
                A2.DHeight = Ar1.DHeight

                A3.DStrtPt.x = Ar2.DStrtPt.x
                A3.DStrtPt.y = Ar2.DStrtPt.y
                A3.DStrtPt.z = Ar2.DStrtPt.z
                A3.DLengths = Ar2.DLengths
                A3.DWidth = Ar2.DWidth - ar.DWidth
                A3.DHeight = ar.DHeight

                Return True
            Else
                Return False

            End If
        Catch Exr As Exception
            MsgBox(Exr.Message)
            MsgBox(Exr.ToString)
            MessageBox.Show("Error in Drumchk1DHE", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function


    Public Function DrumMrgXDHE(ByVal Lst As List(Of CDArea), ByVal Ar As CDArea, ByRef Chngd As Boolean) As List(Of CDArea)

        Dim Ar1 As New CDArea
        Dim Ar2 As New CDArea
        Dim Arx As New CDArea
        Dim LstRet As New List(Of CDArea)
        Dim j As Integer = 0
        Dim k As Integer = 0
        Dim Lst1 As New List(Of Integer)

        Try
            For i As Integer = 0 To Lst.Count - 1
                Ar1 = Lst(i)

                If Ar1.DStrtPt.x = Ar.DStrtPt.x + Ar.DLengths AndAlso Ar1.DWidth = Ar.DWidth AndAlso Ar.DHeight = Ar1.DHeight AndAlso Ar1.DStrtPt.y = Ar.DStrtPt.y AndAlso Ar1.DStrtPt.z = Ar.DStrtPt.z Then
                    j = i
                End If

                If Ar1.DStrtPt.x = Ar.DStrtPt.x AndAlso Ar1.DStrtPt.y = Ar.DStrtPt.y AndAlso Ar1.DStrtPt.z = Ar.DStrtPt.z AndAlso Ar1.DLengths = Ar.DLengths AndAlso Ar1.DWidth = Ar.DWidth AndAlso Ar1.DHeight = Ar.DHeight Then
                    k = i
                End If
            Next

            If j <> 0 AndAlso k <> 0 Then
                Ar1 = Lst(j)
                Ar2 = Lst(k)
                Arx.DStrtPt.x = Ar2.DStrtPt.x
                Arx.DStrtPt.y = Ar2.DStrtPt.y
                Arx.DStrtPt.z = Ar2.DStrtPt.z
                Arx.DLengths = Ar1.DLengths + Ar2.DLengths
                Arx.DWidth = Ar1.DWidth
                Arx.DHeight = Ar1.DHeight

                For i As Integer = 0 To Lst.Count - 1
                    If i <> j AndAlso i <> k Then
                        LstRet.Add(Lst(i))
                    End If
                Next

                LstRet.Add(Arx)
                Chngd = True
                Return LstRet
            Else
                Chngd = False
                Return Lst
            End If
        Catch Erx As Exception
            MsgBox(Erx.Message)
            MsgBox(Erx.ToString)
            MessageBox.Show("Error in DrumMrgXDHE", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try

    End Function

    Public Function DrumFindOptDHE(ByVal stk As List(Of CDArea), ByVal ar As CDArea, ByVal tpup As Boolean) As Integer
        'Stop
        Dim StAl As New List(Of StructArwi)
        Dim Cmd As New OleDb.OleDbCommand
        Cmd.Connection = connDrums
        Dim ILst As New List(Of Integer)
        Dim Ar1 As New CDArea

        Dim Ordr As Integer

        Dim Arw As New StructArwi

        Try

            For i As Integer = 0 To stk.Count - 1

                If StuffPlus.DrumFtIpDHE(stk.Item(i), ar, tpup) Then

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

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in DrumFindOptDHE", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try

        Return Ordr

    End Function

    Public Function DrumFindCandidate1DHE(ByVal q As List(Of CDArea), ByVal ar As CDArea, ByVal tpup As Boolean) As List(Of Integer)

        Dim Lst As New List(Of Integer)
        Dim Lst2 As New List(Of Integer)
        Dim RetLst As New Queue
        Dim Ar1 As New CDArea
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
        Dim Arr As CDArea
        Dim Lstt As New List(Of Integer)

        Try
            For i As Integer = 0 To q.Count - 1
                Ar1 = q(i)

                If Not StuffPlus.DrumFtIpDHE(Ar1, ar, tpup) Then

                    '10sd
                    'Stop
                    If Ar1.DLengths >= ar.DLengths AndAlso Ar1.DHeight >= ar.DHeight AndAlso Ar1.DWidth > ar.DWidth Then
                        'Stop
                        Lst.Add(i)
                        Lst1.Add(Ar1)

                    End If
                End If
            Next

            For j As Integer = 0 To Lst1.Count - 1
                Arr = Lst1(j)

                For i As Integer = 0 To q.Count - 1
                    Ar1 = q(i)

                    If (Math.Abs(Ar1.DStrtPt.y - Arr.DStrtPt.y - Arr.DWidth) < 0.0001) AndAlso Ar1.DStrtPt.z = Arr.DStrtPt.z AndAlso Ar1.DWidth + Arr.DWidth >= ar.DWidth Then
                        TLst.Add(Arr)
                        TLst1.Add(Ar1)
                        Lst2.Add(Lst(j))
                        Lstf.Add(i)

                    End If
                Next
            Next

            Try
                Cmd.Connection = connDrums
                Cmd.CommandText = "delete from temp3"
                Cmd.ExecuteNonQuery()
            Catch e As Exception
                connDrums.Dispose()
                connDrums.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\Drums.mdb;Persist Security Info=False"
                connDrums.Open()
                Cmd.Cancel()
                Cmd.Connection = Nothing
                Cmd.Connection = connDrums
                Cmd.CommandText = ""
                Cmd.CommandText = "delete from temp3"
                Cmd.ExecuteNonQuery()
            End Try
            For i As Integer = 0 To TLst.Count - 1
                ArCon = TLst(i)
                Ordr = Lst2(i)
                Ordr1 = Lstf(i)
                Try
                    Cmd.Connection = connDrums
                    Cmd.CommandText = "insert into temp3 values(" & CStr(ArCon.DStrtPt.x) & "," & CStr(ArCon.DStrtPt.y) & "," & CStr(ArCon.DStrtPt.z) & "," & CStr(Ordr) & "," & CStr(Ordr1) & ")"
                    Cmd.ExecuteNonQuery()

                Catch e As Exception
                    Cmd.Cancel()

                    Cmd.Connection = Nothing
                    Cmd.Connection = connDrums
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
                Lstt.Add(Ordr)
                Lstt.Add(Ordr1)
                Lstret.Add(Lstt)
                Return Lstt
            Else
                Return Nothing
            End If
        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in DrumFindCandidate1DHE", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try

    End Function

    Public Function DrumFindCandidate1DHECA(ByVal q As List(Of CDArea), ByVal ar As CDArea, ByVal tpup As Boolean) As List(Of Integer)
        'DStop
        Dim Lst As New List(Of Integer)
        Dim Lst2 As New List(Of Integer)
        Dim RetLst As New Queue
        Dim Ar1 As New CDArea
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
        Dim Arr As CDArea
        Dim Lstt As New List(Of Integer)

        Try
            For i As Integer = 0 To q.Count - 1
                Ar1 = q(i)

                If Not StuffPlus.DFtIpCA(Ar1, ar, tpup) Then

                    '10sd

                    'DDDStop

                    If Ar1.DLengths >= ar.DLengths AndAlso Ar1.DHeight >= ar.DHeight AndAlso Ar1.DWidth > ar.DWidth Then
                        Stop
                        Lst.Add(i)
                        Lst1.Add(Ar1)

                    End If
                End If
            Next

            'DStop

            For j As Integer = 0 To Lst1.Count - 1
                Arr = Lst1(j)

                For i As Integer = 0 To q.Count - 1
                    Ar1 = q(i)

                    If (Math.Abs(Ar1.DStrtPt.y - Arr.DStrtPt.y - Arr.DWidth) < 0.0001) AndAlso Ar1.DStrtPt.z = Arr.DStrtPt.z AndAlso Ar1.DWidth + Arr.DWidth >= ar.DWidth Then
                        TLst.Add(Arr)
                        TLst1.Add(Ar1)
                        Lst2.Add(Lst(j))
                        Lstf.Add(i)

                    End If
                Next
            Next

            Try
                Cmd.Connection = connDrums
                Cmd.CommandText = "delete from temp3"
                Cmd.ExecuteNonQuery()
            Catch e As Exception
                connDrums.Dispose()
                connDrums.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\Drums.mdb;Persist Security Info=False"
                connDrums.Open()
                Cmd.Cancel()
                Cmd.Connection = Nothing
                Cmd.Connection = connDrums
                Cmd.CommandText = ""
                Cmd.CommandText = "delete from temp3"
                Cmd.ExecuteNonQuery()
            End Try
            For i As Integer = 0 To TLst.Count - 1
                ArCon = TLst(i)
                Ordr = Lst2(i)
                Ordr1 = Lstf(i)
                Try
                    Cmd.Connection = connDrums
                    Cmd.CommandText = "insert into temp3 values(" & CStr(ArCon.DStrtPt.x) & "," & CStr(ArCon.DStrtPt.y) & "," & CStr(ArCon.DStrtPt.z) & "," & CStr(Ordr) & "," & CStr(Ordr1) & ")"
                    Cmd.ExecuteNonQuery()

                Catch e As Exception
                    Cmd.Cancel()

                    Cmd.Connection = Nothing
                    Cmd.Connection = connDrums
                    Cmd.CommandText = ""
                    Cmd.CommandText = "delete from temp3"
                    Cmd.ExecuteNonQuery()
                End Try

            Next
            'DStop
            Cmd.CommandText = "select * from temp3 order by z desc ,x asc,y asc"
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
        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in DrumFindCandidate1DHE", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try

    End Function

    Public Function DrumFindCandidate1DHECANxt(ByVal q As List(Of CDArea), ByVal ar As CDArea, ByVal tpup As Boolean) As List(Of Integer)

        'DDDStop

        Dim Lst As New List(Of Integer)
        Dim Lst2 As New List(Of Integer)
        Dim RetLst As New Queue
        Dim Ar1 As New CDArea
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
        Dim Arr As CDArea
        Dim Lstt As New List(Of Integer)

        Try
            For i As Integer = 0 To q.Count - 1
                Ar1 = q(i)

                If Not StuffPlus.DFtIpCANxt(Ar1, ar, tpup) Then

                    'Dstop

                    If Ar1.DLengths >= ar.DLengths AndAlso Ar1.DHeight >= ar.DHeight AndAlso Ar1.DWidth > ar.DWidth Then
                        Stop
                        Lst.Add(i)
                        Lst1.Add(Ar1)

                    End If
                End If
            Next

            'DStop

            For j As Integer = 0 To Lst1.Count - 1

                Arr = Lst1(j)

                For i As Integer = 0 To q.Count - 1
                    Ar1 = q(i)

                    If (Math.Abs(Ar1.DStrtPt.y - Arr.DStrtPt.y - Arr.DWidth) < 0.0001) AndAlso Ar1.DStrtPt.z = Arr.DStrtPt.z AndAlso Ar1.DWidth + Arr.DWidth >= ar.DWidth Then
                        TLst.Add(Arr)
                        TLst1.Add(Ar1)
                        Lst2.Add(Lst(j))
                        Lstf.Add(i)

                    End If
                Next
            Next

            Try

                Cmd.Connection = connDrums
                Cmd.CommandText = "delete from temp3"
                Cmd.ExecuteNonQuery()

            Catch e As Exception

                connDrums.Dispose()
                connDrums.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\Drums.mdb;Persist Security Info=False"
                connDrums.Open()
                Cmd.Cancel()
                Cmd.Connection = Nothing
                Cmd.Connection = connDrums
                Cmd.CommandText = ""
                Cmd.CommandText = "delete from temp3"
                Cmd.ExecuteNonQuery()

            End Try

            For i As Integer = 0 To TLst.Count - 1

                ArCon = TLst(i)
                Ordr = Lst2(i)
                Ordr1 = Lstf(i)
                Try
                    Cmd.Connection = connDrums
                    Cmd.CommandText = "insert into temp3 values(" & CStr(ArCon.DStrtPt.x) & "," & CStr(ArCon.DStrtPt.y) & "," & CStr(ArCon.DStrtPt.z) & "," & CStr(Ordr) & "," & CStr(Ordr1) & ")"
                    Cmd.ExecuteNonQuery()

                Catch e As Exception
                    Cmd.Cancel()

                    Cmd.Connection = Nothing
                    Cmd.Connection = connDrums
                    Cmd.CommandText = ""
                    Cmd.CommandText = "delete from temp3"
                    Cmd.ExecuteNonQuery()
                End Try

            Next

            'DStop

            Cmd.CommandText = "select * from temp3 order by z desc ,x asc,y asc"
            Rdr = Cmd.ExecuteReader
            Rdr.Read()

            'DDDStop

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

            'DDDStop

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in DrumFindCandidate1DHECANxt", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try

    End Function

    Public Function DrumFindCandidateDHE(ByVal Q As List(Of CDArea), ByVal Ar As CDArea) As List(Of Integer)

        Dim Lst As New List(Of Integer)
        Dim Lst2 As New List(Of Integer)
        Dim RetLst As New Queue
        Dim Ar1 As New CDArea
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
        Dim Arr As CDArea
        Dim Lstt As New List(Of Integer)

        Try
            For i As Integer = 0 To Q.Count - 1
                Ar1 = Q(i)

                If Ar1.DWidth >= Ar.DWidth AndAlso Ar1.DHeight >= Ar.DHeight Then
                    Lst.Add(i)
                    Lst1.Add(Ar1)
                End If
            Next

            For j As Integer = 0 To Lst1.Count - 1
                Arr = Lst1(j)

                For i As Integer = 0 To Q.Count - 1
                    Ar1 = Q(i)

                    If Ar1.DStrtPt.x = Arr.DStrtPt.x + Arr.DLengths AndAlso Ar1.DLengths + Arr.DLengths >= Ar.DLengths AndAlso (Ar1.DStrtPt.y = Arr.DStrtPt.y OrElse Ar1.DStrtPt.y + Ar1.DWidth = Arr.DStrtPt.y + Arr.DWidth) AndAlso Ar1.DStrtPt.z = Arr.DStrtPt.z AndAlso Ar1.DStrtPt.y <= Arr.DStrtPt.y Then
                        TLst.Add(Arr)
                        TLst1.Add(Ar1)
                        Lst2.Add(Lst(j))
                        Lstf.Add(i)
                    End If
                Next
            Next

            Try
                Cmd.Connection = connDrums
                Cmd.CommandText = "delete from temp3"
                Cmd.ExecuteNonQuery()
            Catch e As Exception
                connDrums.Dispose()
                connDrums.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\Drums.mdb;Persist Security Info=False"
                connDrums.Open()
                Cmd.Cancel()
                Cmd.Connection = Nothing
                Cmd.Connection = connDrums
                Cmd.CommandText = ""
                Cmd.CommandText = "delete from temp3"
                Cmd.ExecuteNonQuery()
            End Try

            For i As Integer = 0 To TLst.Count - 1
                ArCon = TLst(i)
                Ordr = Lst2(i)
                Ordr1 = Lstf(i)

                Try
                    Cmd.Connection = connDrums
                    Cmd.CommandText = "insert into temp3 values(" & CStr(ArCon.DStrtPt.x) & "," & CStr(ArCon.DStrtPt.y) & "," & CStr(ArCon.DStrtPt.z) & "," & CStr(Ordr) & "," & CStr(Ordr1) & ")"
                    Cmd.ExecuteNonQuery()
                Catch e As Exception
                    Cmd.Cancel()
                    Cmd.Connection = Nothing
                    Cmd.Connection = connDrums
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
            MessageBox.Show("Error in DrumFindCandidateDHE", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try

    End Function

    Public Function DrumFindCandidateDHECA(ByVal DAri As CDArea, ByVal DQ As List(Of CDArea)) As List(Of Integer)
        'DDStop
        Dim Lst As New List(Of Integer)
        Dim Lst2 As New List(Of Integer)
        Dim RetLst As New Queue
        Dim Ar1 As New CDArea
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
        Dim Arr As CDArea
        Dim Lstt As New List(Of Integer)

        Try
            For i As Integer = 0 To Q.Count - 1
                Ar1 = DQ(i)

                If Ar1.DWidth >= DAri.DWidth AndAlso Ar1.DHeight >= DAri.DHeight Then
                    Lst.Add(i)
                    Lst1.Add(Ar1)
                End If
            Next

            For j As Integer = 0 To Lst1.Count - 1
                Arr = Lst1(j)

                For i As Integer = 0 To Q.Count - 1
                    Ar1 = DQ(i)

                    If Ar1.DStrtPt.x = Arr.DStrtPt.x + Arr.DLengths AndAlso Ar1.DLengths + Arr.DLengths >= DAri.DLengths AndAlso (Ar1.DStrtPt.y = Arr.DStrtPt.y OrElse Ar1.DStrtPt.y + Ar1.DWidth = Arr.DStrtPt.y + Arr.DWidth) AndAlso Ar1.DStrtPt.z = Arr.DStrtPt.z AndAlso Ar1.DStrtPt.y <= Arr.DStrtPt.y Then
                        TLst.Add(Arr)
                        TLst1.Add(Ar1)
                        Lst2.Add(Lst(j))
                        Lstf.Add(i)
                    End If
                Next
            Next

            Try
                Cmd.Connection = connDrums
                Cmd.CommandText = "delete from temp3"
                Cmd.ExecuteNonQuery()
            Catch e As Exception
                connDrums.Dispose()
                connDrums.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\Drums.mdb;Persist Security Info=False"
                connDrums.Open()
                Cmd.Cancel()
                Cmd.Connection = Nothing
                Cmd.Connection = connDrums
                Cmd.CommandText = ""
                Cmd.CommandText = "delete from temp3"
                Cmd.ExecuteNonQuery()
            End Try

            For i As Integer = 0 To TLst.Count - 1
                ArCon = TLst(i)
                Ordr = Lst2(i)
                Ordr1 = Lstf(i)

                Try
                    Cmd.Connection = connDrums
                    Cmd.CommandText = "insert into temp3 values(" & CStr(ArCon.DStrtPt.x) & "," & CStr(ArCon.DStrtPt.y) & "," & CStr(ArCon.DStrtPt.z) & "," & CStr(Ordr) & "," & CStr(Ordr1) & ")"
                    Cmd.ExecuteNonQuery()
                Catch e As Exception
                    Cmd.Cancel()
                    Cmd.Connection = Nothing
                    Cmd.Connection = connDrums
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
            MessageBox.Show("Error in DrumFindCandidateDHE", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try

    End Function

    Public Function DrumFindCandidateDHECANxt(ByVal DAri As CDArea, ByVal DQ As List(Of CDArea)) As List(Of Integer)

        'DDStop

        Dim Lst As New List(Of Integer)
        Dim Lst2 As New List(Of Integer)
        Dim RetLst As New Queue
        Dim Ar1 As New CDArea
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
        Dim Arr As CDArea
        Dim Lstt As New List(Of Integer)

        Try
            For i As Integer = 0 To Q.Count - 1
                Ar1 = DQ(i)

                If Ar1.DWidth >= DAri.DWidth AndAlso Ar1.DHeight >= DAri.DHeight Then
                    Lst.Add(i)
                    Lst1.Add(Ar1)
                End If
            Next

            For j As Integer = 0 To Lst1.Count - 1
                Arr = Lst1(j)

                For i As Integer = 0 To Q.Count - 1
                    Ar1 = DQ(i)

                    If Ar1.DStrtPt.x = Arr.DStrtPt.x + Arr.DLengths AndAlso Ar1.DLengths + Arr.DLengths >= DAri.DLengths AndAlso (Ar1.DStrtPt.y = Arr.DStrtPt.y OrElse Ar1.DStrtPt.y + Ar1.DWidth = Arr.DStrtPt.y + Arr.DWidth) AndAlso Ar1.DStrtPt.z = Arr.DStrtPt.z AndAlso Ar1.DStrtPt.y <= Arr.DStrtPt.y Then
                        TLst.Add(Arr)
                        TLst1.Add(Ar1)
                        Lst2.Add(Lst(j))
                        Lstf.Add(i)
                    End If
                Next
            Next

            Try
                Cmd.Connection = connDrums
                Cmd.CommandText = "delete from temp3"
                Cmd.ExecuteNonQuery()
            Catch e As Exception
                connDrums.Dispose()
                connDrums.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\Drums.mdb;Persist Security Info=False"
                connDrums.Open()
                Cmd.Cancel()
                Cmd.Connection = Nothing
                Cmd.Connection = connDrums
                Cmd.CommandText = ""
                Cmd.CommandText = "delete from temp3"
                Cmd.ExecuteNonQuery()
            End Try

            For i As Integer = 0 To TLst.Count - 1
                ArCon = TLst(i)
                Ordr = Lst2(i)
                Ordr1 = Lstf(i)

                Try
                    Cmd.Connection = connDrums
                    Cmd.CommandText = "insert into temp3 values(" & CStr(ArCon.DStrtPt.x) & "," & CStr(ArCon.DStrtPt.y) & "," & CStr(ArCon.DStrtPt.z) & "," & CStr(Ordr) & "," & CStr(Ordr1) & ")"
                    Cmd.ExecuteNonQuery()
                Catch e As Exception
                    Cmd.Cancel()
                    Cmd.Connection = Nothing
                    Cmd.Connection = connDrums
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
            MessageBox.Show("Error in DrumFindCandidateDHECANxt", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try

    End Function

    Public Function DrumUnionItrPDHE(ByVal Ar1 As CDArea, ByVal Ar2 As CDArea) As List(Of CDArea)

        Dim ArRet1 As New CDArea
        Dim ArRet2 As New CDArea
        Dim LstRet As New List(Of CDArea)

        Try
            Ar1.DStrtPt.x = Math.Round(Ar1.DStrtPt.x, 4)
            Ar1.DStrtPt.y = Math.Round(Ar1.DStrtPt.y, 4)
            Ar1.DStrtPt.z = Math.Round(Ar1.DStrtPt.z, 4)

            Ar1.DLengths = Math.Round(Ar1.DLengths, 4)
            Ar1.DWidth = Math.Round(Ar1.DWidth, 4)
            Ar1.DHeight = Math.Round(Ar1.DHeight, 4)

            Ar2.DStrtPt.x = Math.Round(Ar2.DStrtPt.x, 4)
            Ar2.DStrtPt.y = Math.Round(Ar2.DStrtPt.y, 4)
            Ar2.DStrtPt.z = Math.Round(Ar2.DStrtPt.z, 4)

            Ar2.DLengths = Math.Round(Ar2.DLengths, 4)
            Ar2.DWidth = Math.Round(Ar2.DWidth, 4)
            Ar2.DHeight = Math.Round(Ar2.DHeight, 4)

            If Ar1.DStrtPt.y = Ar2.DStrtPt.y AndAlso Ar1.DStrtPt.z = Ar2.DStrtPt.z AndAlso Ar1.DHeight = Ar2.DHeight Then
                If (Ar2.DStrtPt.x = (Ar1.DStrtPt.x + Ar1.DLengths)) Then
                    If Ar1.DWidth = Ar2.DWidth Then
                        ArRet1.DStrtPt.x = Ar1.DStrtPt.x
                        ArRet1.DStrtPt.y = Ar1.DStrtPt.y
                        ArRet1.DStrtPt.z = Ar1.DStrtPt.z
                        ArRet1.DLengths = Ar1.DLengths + Ar2.DLengths
                        ArRet1.DWidth = Ar1.DWidth
                        ArRet1.DHeight = Ar1.DHeight

                        ArRet2.DStrtPt.x = 0
                        ArRet2.DStrtPt.y = 0
                        ArRet2.DStrtPt.z = 0
                        ArRet2.DLengths = 0
                        ArRet2.DWidth = 0
                        ArRet2.DHeight = 0

                        LstRet.Add(ArRet1)
                        LstRet.Add(ArRet2)

                        Return LstRet

                    Else

                        If Ar1.DWidth < Ar2.DWidth Then

                            ArRet1.DStrtPt.x = Ar1.DStrtPt.x
                            ArRet1.DStrtPt.y = Ar1.DStrtPt.y
                            ArRet1.DStrtPt.z = Ar1.DStrtPt.z
                            ArRet1.DLengths = Ar1.DLengths + Ar2.DLengths
                            ArRet1.DWidth = Ar1.DWidth
                            ArRet1.DHeight = Ar1.DHeight

                            ArRet2.DStrtPt.x = Ar2.DStrtPt.x
                            ArRet2.DStrtPt.y = Ar1.DStrtPt.y + Ar1.DWidth
                            ArRet2.DStrtPt.z = Ar1.DStrtPt.z
                            ArRet2.DLengths = Ar2.DLengths
                            ArRet2.DWidth = Ar2.DWidth - Ar1.DWidth
                            ArRet2.DHeight = Ar2.DHeight

                            LstRet.Add(ArRet1)
                            LstRet.Add(ArRet2)

                            Return LstRet

                        End If

                        If Ar2.DWidth < Ar1.DWidth Then

                            ArRet1.DStrtPt.x = Ar1.DStrtPt.x
                            ArRet1.DStrtPt.y = Ar1.DStrtPt.y
                            ArRet1.DStrtPt.z = Ar1.DStrtPt.z
                            ArRet1.DLengths = Ar1.DLengths + Ar2.DLengths
                            ArRet1.DWidth = Ar2.DWidth
                            ArRet1.DHeight = Ar1.DHeight

                            ArRet2.DStrtPt.x = Ar1.DStrtPt.x
                            ArRet2.DStrtPt.y = Ar2.DStrtPt.y + Ar2.DWidth
                            ArRet2.DStrtPt.z = Ar1.DStrtPt.z
                            ArRet2.DLengths = Ar1.DLengths
                            ArRet2.DWidth = Ar1.DWidth - Ar2.DWidth
                            ArRet2.DHeight = Ar2.DHeight

                            LstRet.Add(ArRet1)
                            LstRet.Add(ArRet2)

                            Return LstRet
                        End If
                    End If

                End If

                If (Ar1.DStrtPt.x = (Ar2.DStrtPt.x + Ar2.DLengths)) Then

                    If Ar1.DWidth = Ar2.DWidth Then

                        ArRet1.DStrtPt.x = Ar2.DStrtPt.x
                        ArRet1.DStrtPt.y = Ar2.DStrtPt.y
                        ArRet1.DStrtPt.z = Ar2.DStrtPt.z
                        ArRet1.DLengths = Ar1.DLengths + Ar2.DLengths
                        ArRet1.DWidth = Ar1.DWidth
                        ArRet1.DHeight = Ar1.DHeight

                        ArRet2.DStrtPt.x = 0
                        ArRet2.DStrtPt.y = 0
                        ArRet2.DStrtPt.z = 0
                        ArRet2.DLengths = 0
                        ArRet2.DWidth = 0
                        ArRet2.DHeight = 0

                        LstRet.Add(ArRet1)
                        LstRet.Add(ArRet2)

                        Return LstRet

                    Else

                        If Ar2.DWidth < Ar1.DWidth Then

                            ArRet1.DStrtPt.x = Ar2.DStrtPt.x
                            ArRet1.DStrtPt.y = Ar2.DStrtPt.y
                            ArRet1.DStrtPt.z = Ar2.DStrtPt.z
                            ArRet1.DLengths = Ar2.DLengths + Ar1.DLengths
                            ArRet1.DWidth = Ar2.DWidth
                            ArRet1.DHeight = Ar2.DHeight

                            ArRet2.DStrtPt.x = Ar1.DStrtPt.x
                            ArRet2.DStrtPt.y = Ar2.DStrtPt.y + Ar2.DWidth
                            ArRet2.DStrtPt.z = Ar2.DStrtPt.z
                            ArRet2.DLengths = Ar1.DLengths
                            ArRet2.DWidth = Ar1.DWidth - Ar2.DWidth
                            ArRet2.DHeight = Ar1.DHeight

                            LstRet.Add(ArRet1)
                            LstRet.Add(ArRet2)

                            Return LstRet

                        End If

                        If Ar1.DWidth < Ar2.DWidth Then

                            ArRet1.DStrtPt.x = Ar2.DStrtPt.x
                            ArRet1.DStrtPt.y = Ar2.DStrtPt.y
                            ArRet1.DStrtPt.z = Ar2.DStrtPt.z
                            ArRet1.DLengths = Ar2.DLengths + Ar1.DLengths
                            ArRet1.DWidth = Ar1.DWidth
                            ArRet1.DHeight = Ar2.DHeight

                            ArRet2.DStrtPt.x = Ar2.DStrtPt.x
                            ArRet2.DStrtPt.y = Ar1.DStrtPt.y + Ar1.DWidth
                            ArRet2.DStrtPt.z = Ar2.DStrtPt.z
                            ArRet2.DLengths = Ar2.DLengths
                            ArRet2.DWidth = Ar2.DWidth - Ar1.DWidth
                            ArRet2.DHeight = Ar1.DHeight

                            LstRet.Add(ArRet1)
                            LstRet.Add(ArRet2)

                            Return LstRet
                        End If
                    End If
                End If
            End If

            ArRet1.DStrtPt.x = Ar1.DStrtPt.x
            ArRet1.DStrtPt.y = Ar1.DStrtPt.y
            ArRet1.DStrtPt.z = Ar1.DStrtPt.z
            ArRet1.DLengths = Ar1.DLengths + Ar2.DLengths
            If Ar1.DWidth < Ar2.DWidth Then
                ArRet1.DWidth = Ar1.DWidth
            Else
                ArRet1.DWidth = Ar2.DWidth
            End If
            ArRet1.DHeight = Ar1.DHeight

            If Ar1.DStrtPt.y = Ar2.DStrtPt.y Then
                ArRet2.DStrtPt.y = Ar1.DStrtPt.y + Ar1.DWidth
            Else
                ArRet2.DStrtPt.y = Ar2.DStrtPt.y
            End If
            ArRet2.DStrtPt.z = Ar2.DStrtPt.z
            If Ar2.DWidth < Ar1.DWidth Then
                ArRet2.DLengths = Ar1.DLengths
                ArRet2.DStrtPt.x = Ar1.DStrtPt.x
            Else
                ArRet2.DLengths = Ar2.DLengths
                ArRet2.DStrtPt.x = Ar2.DStrtPt.x
            End If
            ArRet2.DWidth = Math.Abs(Ar2.DWidth - Ar1.DWidth)
            ArRet2.DHeight = Ar2.DHeight

            If Ar1.DStrtPt.x = Ar2.DStrtPt.x AndAlso Ar1.DLengths < Ar2.DLengths AndAlso Ar2.DStrtPt.y = Ar1.DStrtPt.y + Ar1.DWidth Then
                ArRet1.DLengths = Ar1.DLengths
                ArRet1.DWidth = Ar1.DWidth + Ar2.DWidth
                ArRet1.DHeight = Ar1.DHeight

                ArRet2.DStrtPt.x = Ar1.DStrtPt.x + Ar1.DLengths
                ArRet2.DStrtPt.y = Ar2.DStrtPt.y
                ArRet2.DStrtPt.z = Ar1.DStrtPt.z
                ArRet2.DLengths = Ar2.DLengths - Ar1.DLengths
                ArRet2.DWidth = Ar2.DWidth
                ArRet2.DHeight = Ar1.DHeight
            End If

            If Ar1.DStrtPt.x < Ar2.DStrtPt.x AndAlso Math.Abs(Ar2.DStrtPt.y - Ar1.DStrtPt.y - Ar1.DWidth) < 0.00001 AndAlso Math.Abs(Ar1.DStrtPt.x + Ar1.DLengths - Ar2.DStrtPt.x - Ar2.DLengths) < 0.00001 Then
                ArRet1.DStrtPt.x = Ar2.DStrtPt.x
                ArRet1.DStrtPt.y = Ar1.DStrtPt.y
                ArRet1.DStrtPt.z = Ar1.DStrtPt.z
                ArRet1.DLengths = Ar2.DLengths
                ArRet1.DWidth = Ar1.DWidth + Ar2.DWidth
                ArRet1.DHeight = Ar1.DHeight

                ArRet2.DStrtPt.x = Ar1.DStrtPt.x
                ArRet2.DStrtPt.y = Ar1.DStrtPt.y
                ArRet2.DStrtPt.z = Ar1.DStrtPt.z
                ArRet2.DLengths = Ar2.DLengths - Ar1.DLengths
                ArRet2.DWidth = Ar1.DWidth
                ArRet2.DHeight = Ar1.DHeight
            End If

            LstRet.Add(ArRet1)
            LstRet.Add(ArRet2)

            Return LstRet

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in DrumUnionItrPDHE", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try

    End Function

    Public Function DrumUnionItrPDHECA(ByVal Ar1 As CDArea, ByVal Ar2 As CDArea) As List(Of CDArea)

        Dim ArRet1 As New CDArea
        Dim ArRet2 As New CDArea
        Dim LstRet As New List(Of CDArea)

        Try
            Ar1.DStrtPt.x = Math.Round(Ar1.DStrtPt.x, 4)
            Ar1.DStrtPt.y = Math.Round(Ar1.DStrtPt.y, 4)
            Ar1.DStrtPt.z = Math.Round(Ar1.DStrtPt.z, 4)

            Ar1.DLengths = Math.Round(Ar1.DLengths, 4)
            Ar1.DWidth = Math.Round(Ar1.DWidth, 4)
            Ar1.DHeight = Math.Round(Ar1.DHeight, 4)

            Ar2.DStrtPt.x = Math.Round(Ar2.DStrtPt.x, 4)
            Ar2.DStrtPt.y = Math.Round(Ar2.DStrtPt.y, 4)
            Ar2.DStrtPt.z = Math.Round(Ar2.DStrtPt.z, 4)

            Ar2.DLengths = Math.Round(Ar2.DLengths, 4)
            Ar2.DWidth = Math.Round(Ar2.DWidth, 4)
            Ar2.DHeight = Math.Round(Ar2.DHeight, 4)

            If Ar1.DStrtPt.y = Ar2.DStrtPt.y AndAlso Ar1.DStrtPt.z = Ar2.DStrtPt.z AndAlso Ar1.DHeight = Ar2.DHeight Then
                If (Ar2.DStrtPt.x = (Ar1.DStrtPt.x + Ar1.DLengths)) Then
                    If Ar1.DWidth = Ar2.DWidth Then
                        ArRet1.DStrtPt.x = Ar1.DStrtPt.x
                        ArRet1.DStrtPt.y = Ar1.DStrtPt.y
                        ArRet1.DStrtPt.z = Ar1.DStrtPt.z
                        ArRet1.DLengths = Ar1.DLengths + Ar2.DLengths
                        ArRet1.DWidth = Ar1.DWidth
                        ArRet1.DHeight = Ar1.DHeight

                        ArRet2.DStrtPt.x = 0
                        ArRet2.DStrtPt.y = 0
                        ArRet2.DStrtPt.z = 0
                        ArRet2.DLengths = 0
                        ArRet2.DWidth = 0
                        ArRet2.DHeight = 0

                        LstRet.Add(ArRet1)
                        LstRet.Add(ArRet2)

                        Return LstRet

                    Else

                        If Ar1.DWidth < Ar2.DWidth Then

                            ArRet1.DStrtPt.x = Ar1.DStrtPt.x
                            ArRet1.DStrtPt.y = Ar1.DStrtPt.y
                            ArRet1.DStrtPt.z = Ar1.DStrtPt.z
                            ArRet1.DLengths = Ar1.DLengths + Ar2.DLengths
                            ArRet1.DWidth = Ar1.DWidth
                            ArRet1.DHeight = Ar1.DHeight

                            ArRet2.DStrtPt.x = Ar2.DStrtPt.x
                            ArRet2.DStrtPt.y = Ar1.DStrtPt.y + Ar1.DWidth
                            ArRet2.DStrtPt.z = Ar1.DStrtPt.z
                            ArRet2.DLengths = Ar2.DLengths
                            ArRet2.DWidth = Ar2.DWidth - Ar1.DWidth
                            ArRet2.DHeight = Ar2.DHeight

                            LstRet.Add(ArRet1)
                            LstRet.Add(ArRet2)

                            Return LstRet

                        End If

                        If Ar2.DWidth < Ar1.DWidth Then

                            ArRet1.DStrtPt.x = Ar1.DStrtPt.x
                            ArRet1.DStrtPt.y = Ar1.DStrtPt.y
                            ArRet1.DStrtPt.z = Ar1.DStrtPt.z
                            ArRet1.DLengths = Ar1.DLengths + Ar2.DLengths
                            ArRet1.DWidth = Ar2.DWidth
                            ArRet1.DHeight = Ar1.DHeight

                            ArRet2.DStrtPt.x = Ar1.DStrtPt.x
                            ArRet2.DStrtPt.y = Ar2.DStrtPt.y + Ar2.DWidth
                            ArRet2.DStrtPt.z = Ar1.DStrtPt.z
                            ArRet2.DLengths = Ar1.DLengths
                            ArRet2.DWidth = Ar1.DWidth - Ar2.DWidth
                            ArRet2.DHeight = Ar2.DHeight

                            LstRet.Add(ArRet1)
                            LstRet.Add(ArRet2)

                            Return LstRet
                        End If
                    End If

                End If

                If (Ar1.DStrtPt.x = (Ar2.DStrtPt.x + Ar2.DLengths)) Then

                    If Ar1.DWidth = Ar2.DWidth Then

                        ArRet1.DStrtPt.x = Ar2.DStrtPt.x
                        ArRet1.DStrtPt.y = Ar2.DStrtPt.y
                        ArRet1.DStrtPt.z = Ar2.DStrtPt.z
                        ArRet1.DLengths = Ar1.DLengths + Ar2.DLengths
                        ArRet1.DWidth = Ar1.DWidth
                        ArRet1.DHeight = Ar1.DHeight

                        ArRet2.DStrtPt.x = 0
                        ArRet2.DStrtPt.y = 0
                        ArRet2.DStrtPt.z = 0
                        ArRet2.DLengths = 0
                        ArRet2.DWidth = 0
                        ArRet2.DHeight = 0

                        LstRet.Add(ArRet1)
                        LstRet.Add(ArRet2)

                        Return LstRet

                    Else

                        If Ar2.DWidth < Ar1.DWidth Then

                            ArRet1.DStrtPt.x = Ar2.DStrtPt.x
                            ArRet1.DStrtPt.y = Ar2.DStrtPt.y
                            ArRet1.DStrtPt.z = Ar2.DStrtPt.z
                            ArRet1.DLengths = Ar2.DLengths + Ar1.DLengths
                            ArRet1.DWidth = Ar2.DWidth
                            ArRet1.DHeight = Ar2.DHeight

                            ArRet2.DStrtPt.x = Ar1.DStrtPt.x
                            ArRet2.DStrtPt.y = Ar2.DStrtPt.y + Ar2.DWidth
                            ArRet2.DStrtPt.z = Ar2.DStrtPt.z
                            ArRet2.DLengths = Ar1.DLengths
                            ArRet2.DWidth = Ar1.DWidth - Ar2.DWidth
                            ArRet2.DHeight = Ar1.DHeight

                            LstRet.Add(ArRet1)
                            LstRet.Add(ArRet2)

                            Return LstRet

                        End If

                        If Ar1.DWidth < Ar2.DWidth Then

                            ArRet1.DStrtPt.x = Ar2.DStrtPt.x
                            ArRet1.DStrtPt.y = Ar2.DStrtPt.y
                            ArRet1.DStrtPt.z = Ar2.DStrtPt.z
                            ArRet1.DLengths = Ar2.DLengths + Ar1.DLengths
                            ArRet1.DWidth = Ar1.DWidth
                            ArRet1.DHeight = Ar2.DHeight

                            ArRet2.DStrtPt.x = Ar2.DStrtPt.x
                            ArRet2.DStrtPt.y = Ar1.DStrtPt.y + Ar1.DWidth
                            ArRet2.DStrtPt.z = Ar2.DStrtPt.z
                            ArRet2.DLengths = Ar2.DLengths
                            ArRet2.DWidth = Ar2.DWidth - Ar1.DWidth
                            ArRet2.DHeight = Ar1.DHeight

                            LstRet.Add(ArRet1)
                            LstRet.Add(ArRet2)

                            Return LstRet
                        End If
                    End If
                End If
            End If

            ArRet1.DStrtPt.x = Ar1.DStrtPt.x
            ArRet1.DStrtPt.y = Ar1.DStrtPt.y
            ArRet1.DStrtPt.z = Ar1.DStrtPt.z
            ArRet1.DLengths = Ar1.DLengths + Ar2.DLengths
            If Ar1.DWidth < Ar2.DWidth Then
                ArRet1.DWidth = Ar1.DWidth
            Else
                ArRet1.DWidth = Ar2.DWidth
            End If
            ArRet1.DHeight = Ar1.DHeight

            If Ar1.DStrtPt.y = Ar2.DStrtPt.y Then
                ArRet2.DStrtPt.y = Ar1.DStrtPt.y + Ar1.DWidth
            Else
                ArRet2.DStrtPt.y = Ar2.DStrtPt.y
            End If
            ArRet2.DStrtPt.z = Ar2.DStrtPt.z
            If Ar2.DWidth < Ar1.DWidth Then
                ArRet2.DLengths = Ar1.DLengths
                ArRet2.DStrtPt.x = Ar1.DStrtPt.x
            Else
                ArRet2.DLengths = Ar2.DLengths
                ArRet2.DStrtPt.x = Ar2.DStrtPt.x
            End If
            ArRet2.DWidth = Math.Abs(Ar2.DWidth - Ar1.DWidth)
            ArRet2.DHeight = Ar2.DHeight

            If Ar1.DStrtPt.x = Ar2.DStrtPt.x AndAlso Ar1.DLengths < Ar2.DLengths AndAlso Ar2.DStrtPt.y = Ar1.DStrtPt.y + Ar1.DWidth Then
                ArRet1.DLengths = Ar1.DLengths
                ArRet1.DWidth = Ar1.DWidth + Ar2.DWidth
                ArRet1.DHeight = Ar1.DHeight

                ArRet2.DStrtPt.x = Ar1.DStrtPt.x + Ar1.DLengths
                ArRet2.DStrtPt.y = Ar2.DStrtPt.y
                ArRet2.DStrtPt.z = Ar1.DStrtPt.z
                ArRet2.DLengths = Ar2.DLengths - Ar1.DLengths
                ArRet2.DWidth = Ar2.DWidth
                ArRet2.DHeight = Ar1.DHeight
            End If

            If Ar1.DStrtPt.x < Ar2.DStrtPt.x AndAlso Math.Abs(Ar2.DStrtPt.y - Ar1.DStrtPt.y - Ar1.DWidth) < 0.00001 AndAlso Math.Abs(Ar1.DStrtPt.x + Ar1.DLengths - Ar2.DStrtPt.x - Ar2.DLengths) < 0.00001 Then
                ArRet1.DStrtPt.x = Ar2.DStrtPt.x
                ArRet1.DStrtPt.y = Ar1.DStrtPt.y
                ArRet1.DStrtPt.z = Ar1.DStrtPt.z
                ArRet1.DLengths = Ar2.DLengths
                ArRet1.DWidth = Ar1.DWidth + Ar2.DWidth
                ArRet1.DHeight = Ar1.DHeight

                ArRet2.DStrtPt.x = Ar1.DStrtPt.x
                ArRet2.DStrtPt.y = Ar1.DStrtPt.y
                ArRet2.DStrtPt.z = Ar1.DStrtPt.z
                ArRet2.DLengths = Ar2.DLengths - Ar1.DLengths
                ArRet2.DWidth = Ar1.DWidth
                ArRet2.DHeight = Ar1.DHeight
            End If

            LstRet.Add(ArRet1)
            LstRet.Add(ArRet2)

            Return LstRet

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in DrumUnionItrPDHECA", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try

    End Function

    Public Function DrumUnionItrPDHECANxt(ByVal Ar1 As CDArea, ByVal Ar2 As CDArea) As List(Of CDArea)

        Dim ArRet1 As New CDArea
        Dim ArRet2 As New CDArea
        Dim LstRet As New List(Of CDArea)

        Try
            Ar1.DStrtPt.x = Math.Round(Ar1.DStrtPt.x, 4)
            Ar1.DStrtPt.y = Math.Round(Ar1.DStrtPt.y, 4)
            Ar1.DStrtPt.z = Math.Round(Ar1.DStrtPt.z, 4)

            Ar1.DLengths = Math.Round(Ar1.DLengths, 4)
            Ar1.DWidth = Math.Round(Ar1.DWidth, 4)
            Ar1.DHeight = Math.Round(Ar1.DHeight, 4)

            Ar2.DStrtPt.x = Math.Round(Ar2.DStrtPt.x, 4)
            Ar2.DStrtPt.y = Math.Round(Ar2.DStrtPt.y, 4)
            Ar2.DStrtPt.z = Math.Round(Ar2.DStrtPt.z, 4)

            Ar2.DLengths = Math.Round(Ar2.DLengths, 4)
            Ar2.DWidth = Math.Round(Ar2.DWidth, 4)
            Ar2.DHeight = Math.Round(Ar2.DHeight, 4)

            If Ar1.DStrtPt.y = Ar2.DStrtPt.y AndAlso Ar1.DStrtPt.z = Ar2.DStrtPt.z AndAlso Ar1.DHeight = Ar2.DHeight Then
                If (Ar2.DStrtPt.x = (Ar1.DStrtPt.x + Ar1.DLengths)) Then
                    If Ar1.DWidth = Ar2.DWidth Then
                        ArRet1.DStrtPt.x = Ar1.DStrtPt.x
                        ArRet1.DStrtPt.y = Ar1.DStrtPt.y
                        ArRet1.DStrtPt.z = Ar1.DStrtPt.z
                        ArRet1.DLengths = Ar1.DLengths + Ar2.DLengths
                        ArRet1.DWidth = Ar1.DWidth
                        ArRet1.DHeight = Ar1.DHeight

                        ArRet2.DStrtPt.x = 0
                        ArRet2.DStrtPt.y = 0
                        ArRet2.DStrtPt.z = 0
                        ArRet2.DLengths = 0
                        ArRet2.DWidth = 0
                        ArRet2.DHeight = 0

                        LstRet.Add(ArRet1)
                        LstRet.Add(ArRet2)

                        Return LstRet

                    Else

                        If Ar1.DWidth < Ar2.DWidth Then

                            ArRet1.DStrtPt.x = Ar1.DStrtPt.x
                            ArRet1.DStrtPt.y = Ar1.DStrtPt.y
                            ArRet1.DStrtPt.z = Ar1.DStrtPt.z
                            ArRet1.DLengths = Ar1.DLengths + Ar2.DLengths
                            ArRet1.DWidth = Ar1.DWidth
                            ArRet1.DHeight = Ar1.DHeight

                            ArRet2.DStrtPt.x = Ar2.DStrtPt.x
                            ArRet2.DStrtPt.y = Ar1.DStrtPt.y + Ar1.DWidth
                            ArRet2.DStrtPt.z = Ar1.DStrtPt.z
                            ArRet2.DLengths = Ar2.DLengths
                            ArRet2.DWidth = Ar2.DWidth - Ar1.DWidth
                            ArRet2.DHeight = Ar2.DHeight

                            LstRet.Add(ArRet1)
                            LstRet.Add(ArRet2)

                            Return LstRet

                        End If

                        If Ar2.DWidth < Ar1.DWidth Then

                            ArRet1.DStrtPt.x = Ar1.DStrtPt.x
                            ArRet1.DStrtPt.y = Ar1.DStrtPt.y
                            ArRet1.DStrtPt.z = Ar1.DStrtPt.z
                            ArRet1.DLengths = Ar1.DLengths + Ar2.DLengths
                            ArRet1.DWidth = Ar2.DWidth
                            ArRet1.DHeight = Ar1.DHeight

                            ArRet2.DStrtPt.x = Ar1.DStrtPt.x
                            ArRet2.DStrtPt.y = Ar2.DStrtPt.y + Ar2.DWidth
                            ArRet2.DStrtPt.z = Ar1.DStrtPt.z
                            ArRet2.DLengths = Ar1.DLengths
                            ArRet2.DWidth = Ar1.DWidth - Ar2.DWidth
                            ArRet2.DHeight = Ar2.DHeight

                            LstRet.Add(ArRet1)
                            LstRet.Add(ArRet2)

                            Return LstRet
                        End If
                    End If

                End If

                If (Ar1.DStrtPt.x = (Ar2.DStrtPt.x + Ar2.DLengths)) Then

                    If Ar1.DWidth = Ar2.DWidth Then

                        ArRet1.DStrtPt.x = Ar2.DStrtPt.x
                        ArRet1.DStrtPt.y = Ar2.DStrtPt.y
                        ArRet1.DStrtPt.z = Ar2.DStrtPt.z
                        ArRet1.DLengths = Ar1.DLengths + Ar2.DLengths
                        ArRet1.DWidth = Ar1.DWidth
                        ArRet1.DHeight = Ar1.DHeight

                        ArRet2.DStrtPt.x = 0
                        ArRet2.DStrtPt.y = 0
                        ArRet2.DStrtPt.z = 0
                        ArRet2.DLengths = 0
                        ArRet2.DWidth = 0
                        ArRet2.DHeight = 0

                        LstRet.Add(ArRet1)
                        LstRet.Add(ArRet2)

                        Return LstRet

                    Else

                        If Ar2.DWidth < Ar1.DWidth Then

                            ArRet1.DStrtPt.x = Ar2.DStrtPt.x
                            ArRet1.DStrtPt.y = Ar2.DStrtPt.y
                            ArRet1.DStrtPt.z = Ar2.DStrtPt.z
                            ArRet1.DLengths = Ar2.DLengths + Ar1.DLengths
                            ArRet1.DWidth = Ar2.DWidth
                            ArRet1.DHeight = Ar2.DHeight

                            ArRet2.DStrtPt.x = Ar1.DStrtPt.x
                            ArRet2.DStrtPt.y = Ar2.DStrtPt.y + Ar2.DWidth
                            ArRet2.DStrtPt.z = Ar2.DStrtPt.z
                            ArRet2.DLengths = Ar1.DLengths
                            ArRet2.DWidth = Ar1.DWidth - Ar2.DWidth
                            ArRet2.DHeight = Ar1.DHeight

                            LstRet.Add(ArRet1)
                            LstRet.Add(ArRet2)

                            Return LstRet

                        End If

                        If Ar1.DWidth < Ar2.DWidth Then

                            ArRet1.DStrtPt.x = Ar2.DStrtPt.x
                            ArRet1.DStrtPt.y = Ar2.DStrtPt.y
                            ArRet1.DStrtPt.z = Ar2.DStrtPt.z
                            ArRet1.DLengths = Ar2.DLengths + Ar1.DLengths
                            ArRet1.DWidth = Ar1.DWidth
                            ArRet1.DHeight = Ar2.DHeight

                            ArRet2.DStrtPt.x = Ar2.DStrtPt.x
                            ArRet2.DStrtPt.y = Ar1.DStrtPt.y + Ar1.DWidth
                            ArRet2.DStrtPt.z = Ar2.DStrtPt.z
                            ArRet2.DLengths = Ar2.DLengths
                            ArRet2.DWidth = Ar2.DWidth - Ar1.DWidth
                            ArRet2.DHeight = Ar1.DHeight

                            LstRet.Add(ArRet1)
                            LstRet.Add(ArRet2)

                            Return LstRet
                        End If
                    End If
                End If
            End If

            ArRet1.DStrtPt.x = Ar1.DStrtPt.x
            ArRet1.DStrtPt.y = Ar1.DStrtPt.y
            ArRet1.DStrtPt.z = Ar1.DStrtPt.z
            ArRet1.DLengths = Ar1.DLengths + Ar2.DLengths
            If Ar1.DWidth < Ar2.DWidth Then
                ArRet1.DWidth = Ar1.DWidth
            Else
                ArRet1.DWidth = Ar2.DWidth
            End If
            ArRet1.DHeight = Ar1.DHeight

            If Ar1.DStrtPt.y = Ar2.DStrtPt.y Then
                ArRet2.DStrtPt.y = Ar1.DStrtPt.y + Ar1.DWidth
            Else
                ArRet2.DStrtPt.y = Ar2.DStrtPt.y
            End If
            ArRet2.DStrtPt.z = Ar2.DStrtPt.z
            If Ar2.DWidth < Ar1.DWidth Then
                ArRet2.DLengths = Ar1.DLengths
                ArRet2.DStrtPt.x = Ar1.DStrtPt.x
            Else
                ArRet2.DLengths = Ar2.DLengths
                ArRet2.DStrtPt.x = Ar2.DStrtPt.x
            End If
            ArRet2.DWidth = Math.Abs(Ar2.DWidth - Ar1.DWidth)
            ArRet2.DHeight = Ar2.DHeight

            If Ar1.DStrtPt.x = Ar2.DStrtPt.x AndAlso Ar1.DLengths < Ar2.DLengths AndAlso Ar2.DStrtPt.y = Ar1.DStrtPt.y + Ar1.DWidth Then
                ArRet1.DLengths = Ar1.DLengths
                ArRet1.DWidth = Ar1.DWidth + Ar2.DWidth
                ArRet1.DHeight = Ar1.DHeight

                ArRet2.DStrtPt.x = Ar1.DStrtPt.x + Ar1.DLengths
                ArRet2.DStrtPt.y = Ar2.DStrtPt.y
                ArRet2.DStrtPt.z = Ar1.DStrtPt.z
                ArRet2.DLengths = Ar2.DLengths - Ar1.DLengths
                ArRet2.DWidth = Ar2.DWidth
                ArRet2.DHeight = Ar1.DHeight
            End If

            If Ar1.DStrtPt.x < Ar2.DStrtPt.x AndAlso Math.Abs(Ar2.DStrtPt.y - Ar1.DStrtPt.y - Ar1.DWidth) < 0.00001 AndAlso Math.Abs(Ar1.DStrtPt.x + Ar1.DLengths - Ar2.DStrtPt.x - Ar2.DLengths) < 0.00001 Then
                ArRet1.DStrtPt.x = Ar2.DStrtPt.x
                ArRet1.DStrtPt.y = Ar1.DStrtPt.y
                ArRet1.DStrtPt.z = Ar1.DStrtPt.z
                ArRet1.DLengths = Ar2.DLengths
                ArRet1.DWidth = Ar1.DWidth + Ar2.DWidth
                ArRet1.DHeight = Ar1.DHeight

                ArRet2.DStrtPt.x = Ar1.DStrtPt.x
                ArRet2.DStrtPt.y = Ar1.DStrtPt.y
                ArRet2.DStrtPt.z = Ar1.DStrtPt.z
                ArRet2.DLengths = Ar2.DLengths - Ar1.DLengths
                ArRet2.DWidth = Ar1.DWidth
                ArRet2.DHeight = Ar1.DHeight
            End If

            LstRet.Add(ArRet1)
            LstRet.Add(ArRet2)

            Return LstRet

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in DrumUnionItrPDHECANxt", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try

    End Function

    Public Function DrumUnPushDHE(ByVal CDLstx As List(Of CDArea), ByVal Ar As CDArea) As List(Of CDArea)

        Dim LstS1 As New List(Of CDArea)
        Dim A1 As CDArea
        Dim Flag As Boolean = False

        Dim Lsty As New List(Of CDArea)
        Dim Arar As CDArea()
        Dim Arf As New CDArea
        Dim Kk As New List(Of CDArea)
        Dim Kk1 As New List(Of CDArea)

        Try
            Ar.DStrtPt.x = Math.Round(Ar.DStrtPt.x, 4)
            Ar.DStrtPt.y = Math.Round(Ar.DStrtPt.y, 4)
            Ar.DStrtPt.z = Math.Round(Ar.DStrtPt.z, 4)

            Ar.DLengths = Math.Round(Ar.DLengths, 4)
            Ar.DWidth = Math.Round(Ar.DWidth, 4)
            Ar.DHeight = Math.Round(Ar.DHeight, 4)

            For i As Integer = 0 To Lsty.Count - 1
                CDLstx.Add(Lsty(i))
            Next

            Arar = CDLstx.ToArray

            For i As Integer = LBound(Arar) To UBound(Arar)
                A1 = Arar(i)

                If A1.DrumUnionItrXDHE(Ar) Is Nothing Then

                Else

                    Flag = True
                End If

            Next

            If Not Flag Then

                CDLstx.Add(Ar)

                Return CDLstx
            Else

                Arf = Nothing
                Kk.Clear()
                Do While CDLstx.Count > 0
                    A1 = CDLstx.Item(CDLstx.Count - 1)

                    A1.DStrtPt.x = Math.Round(A1.DStrtPt.x, 4)
                    A1.DStrtPt.y = Math.Round(A1.DStrtPt.y, 4)
                    A1.DStrtPt.z = Math.Round(A1.DStrtPt.z, 4)

                    A1.DLengths = Math.Round(A1.DLengths, 4)
                    A1.DWidth = Math.Round(A1.DWidth, 4)
                    A1.DHeight = Math.Round(A1.DHeight, 4)

                    CDLstx.RemoveAt(CDLstx.Count - 1)

                    If A1.DrumUnionItrXDHE(Ar) Is Nothing Then

                        LstS1.Add(A1)

                    Else
                        Arf = A1.DrumUnionItrXDHE(Ar)
                        Kk.Add(Arf)
                        Kk1.Add(A1)

                    End If

                Loop

            End If

            Dim iii As DataRow()
            Dim ii As Integer

            DeleteTable("DTemp4")

            Dim Ar1 As New CDArea

            If Kk.Count = 1 Then
                LstS1.Add(Kk(0))

            Else
                For i As Integer = 0 To Kk.Count - 1
                    Ar1 = Kk(i)
                    DInsertTable("DTemp4", New Object() {CStr(Ar1.DStrtPt.x), CStr(Ar1.DStrtPt.y), CStr(Ar1.DStrtPt.z), CStr(i)})
                Next

                iii = DGetf("DTemp4", "", "z asc ,x asc ,y asc")
                ii = iii(0)("i")

                For i As Integer = 0 To Kk.Count - 1

                    If i = ii Then

                        LstS1.Add(Kk(i))

                    Else

                        LstS1.Add(Kk1(i))

                    End If

                Next
            End If

            Return LstS1

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in DrumUnPushDHE", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try

    End Function

    Public Function DrumFindOptMethodDHE(ByVal Ar1 As CDArea, ByVal Ar2 As CDArea, ByRef MaxQty1 As Integer, ByVal TpUp As Boolean) As Integer
        'Stop
        Dim Dln1 As Double = Ar1.DLengths
        Dim Dwd1 As Double = Ar1.DWidth
        Dim Dht1 As Double = Ar1.DHeight

        Dim Dln2 As Double = Ar2.DLengths
        Dim Dwd2 As Double = Ar2.DWidth
        Dim Dht2 As Double = Ar2.DHeight

        Dim Dqty1 As Integer = 0
        Dim Dqty2 As Integer = 0
        Dim Dqty3 As Integer = 0
        Dim Dqty4 As Integer = 0
        Dim Dqty5 As Integer = 0
        Dim Dqty6 As Integer = 0

        Dim Dqtypos As String

        Try
            If Dln2 >= Dln1 AndAlso Dwd2 >= Dwd1 AndAlso Dht2 >= Dht1 Then
                Dqty1 = Fix(Dln2 / Dln1) * Fix(Dwd2 / Dwd1) * Fix(Dht2 / Dht1)
            Else
                Dqty1 = 0
            End If
            If Not TpUp Then

                If Dln2 >= Dln1 AndAlso Dwd2 >= Dht1 AndAlso Dht2 >= Dwd1 Then
                    Dqty2 = Fix(Dln2 / Dln1) * Fix(Dwd2 / Dht1) * Fix(Dht2 / Dwd1)
                Else
                    Dqty2 = 0
                End If

                If Dln2 >= Dwd1 AndAlso Dwd2 >= Dht1 AndAlso Dht2 >= Dln1 Then
                    Dqty3 = Fix(Dln2 / Dwd1) * Fix(Dwd2 / Dht1) * Fix(Dht2 / Dln1)
                Else
                    Dqty3 = 0
                End If

            End If

            If Dln2 >= Dwd1 AndAlso Dwd2 >= Dln1 AndAlso Dht2 >= Dht1 Then
                Dqty4 = Fix(Dln2 / Dwd1) * Fix(Dwd2 / Dln1) * Fix(Dht2 / Dht1)
            Else
                Dqty4 = 0
            End If

            If Not TpUp Then

                If Dln2 >= Dht1 AndAlso Dwd2 >= Dwd1 AndAlso Dht2 >= Dln1 Then
                    Dqty5 = Fix(Dln2 / Dht1) * Fix(Dwd2 / Dwd1) * Fix(Dht2 / Dln1)
                Else
                    Dqty5 = 0
                End If

                If Dln2 >= Dht1 AndAlso Dwd2 >= Dln1 AndAlso Dht2 >= Dwd1 Then
                    Dqty6 = Fix(Dln2 / Dht1) * Fix(Dwd2 / Dln1) * Fix(Dht2 / Dwd1)
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

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in DrumFindOptMethodDHE", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try

    End Function

    Public Function DrumFindOptMethodDHECA(ByVal Ar1 As CDArea, ByVal Ar2 As CDArea, ByRef MaxQty1 As Integer, ByVal TpUp As Boolean) As Integer

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

            Occ = 0
            OccLst.Clear()

            If MaxQty1 = DQty1 Then
                Occ += 1
                OccLst.Add(1)
            End If

            If MaxQty1 = DQty2 Then
                Occ += 1
                OccLst.Add(2)
            End If

            If MaxQty1 = DQty3 Then
                Occ += 1
                OccLst.Add(3)
            End If

            If MaxQty1 = DQty4 Then
                Occ += 1
                OccLst.Add(4)
            End If

            If MaxQty1 = DQty5 Then
                Occ += 1
                OccLst.Add(5)
            End If

            If MaxQty1 = DQty6 Then
                Occ += 1
                OccLst.Add(6)
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

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in DrumFindOptMethodDHECA", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try

    End Function

    Public Function DrumFindQtyDHE(ByVal ItmArr() As String, ByVal StrtPos As Integer) As Integer

        Dim Nm As String = ItmArr(StrtPos)
        Dim i As Integer
        Try
            For i = StrtPos To UBound(ItmArr)
                If ItmArr(i) <> Nm Then
                    Exit For
                End If
            Next
            Return i - StrtPos
        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in DrumFindQtyDHE", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try

    End Function

    Public Function DHDUnPush(ByVal CDLstx As List(Of CDArea), ByVal Ar As CDArea) As List(Of CDArea)
        'Stop
        Dim LstS1 As New List(Of CDArea)
        Dim A1 As CDArea
        Dim Flag As Boolean = False

        Dim Lsty As New List(Of CDArea)
        Dim Arar As CDArea()
        Dim Arf As New CDArea
        Dim Kk As New List(Of CDArea)
        Dim Kk1 As New List(Of CDArea)

        Dim CADrm As New List(Of CDrum)
        Dim Dca As New List(Of Integer)

        Try
            Ar.DStrtPt.x = Math.Round(Ar.DStrtPt.x, 4)
            Ar.DStrtPt.y = Math.Round(Ar.DStrtPt.y, 4)
            Ar.DStrtPt.z = Math.Round(Ar.DStrtPt.z, 4)

            Ar.DLengths = Math.Round(Ar.DLengths, 4)
            Ar.DWidth = Math.Round(Ar.DWidth, 4)
            Ar.DHeight = Math.Round(Ar.DHeight, 4)

            'Stop

            For i As Integer = 0 To Lsty.Count - 1
                CDLstx.Add(Lsty(i))
            Next

            Arar = CDLstx.ToArray

            For i As Integer = LBound(Arar) To UBound(Arar)
                A1 = Arar(i)

                If A1.DHVUnionItrX(Ar) Is Nothing Then

                Else

                    Flag = True
                End If

            Next

            'Stop

            If Not Flag Then

                CDLstx.Add(Ar)

                Return CDLstx
            Else

                Arf = Nothing
                Kk.Clear()

                Do While CDLstx.Count > 0
                    A1 = CDLstx.Item(CDLstx.Count - 1)

                    A1.DStrtPt.x = Math.Round(A1.DStrtPt.x, 4)
                    A1.DStrtPt.y = Math.Round(A1.DStrtPt.y, 4)
                    A1.DStrtPt.z = Math.Round(A1.DStrtPt.z, 4)

                    A1.DLengths = Math.Round(A1.DLengths, 4)
                    A1.DWidth = Math.Round(A1.DWidth, 4)
                    A1.DHeight = Math.Round(A1.DHeight, 4)

                    CDLstx.RemoveAt(CDLstx.Count - 1)
                    If A1.DHVUnionItrX(Ar) Is Nothing Then

                        LstS1.Add(A1)

                    Else
                        Arf = A1.DHVUnionItrX(Ar)
                        Kk.Add(Arf)
                        Kk1.Add(A1)

                    End If

                Loop

            End If
            Dim iii As DataRow()
            Dim ii As Integer
            DeleteTable("DTemp4")
            Dim Ar1 As New CDArea

            If Kk.Count = 1 Then
                LstS1.Add(Kk(0))

            Else
                For i As Integer = 0 To Kk.Count - 1
                    Ar1 = Kk(i)
                    DInsertTable("DTemp4", New Object() {CStr(Ar1.DStrtPt.x), CStr(Ar1.DStrtPt.y), CStr(Ar1.DStrtPt.z), CStr(i)})
                Next

                iii = DGetf("DTemp4", "", "z asc ,x asc ,y asc")
                ii = iii(0)("i")

                For i As Integer = 0 To Kk.Count - 1

                    If i = ii Then

                        LstS1.Add(Kk(i))

                    Else

                        LstS1.Add(Kk1(i))

                    End If

                Next
            End If

        Catch Err As Exception
            Return Nothing
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in DHDUnPush", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return LstS1
        Stop
    End Function

    Public Function DHDUnPushCANxt(ByVal CDLstx As List(Of CDArea), ByVal Ar As CDArea) As List(Of CDArea)

        Stop

        Dim LstS1 As New List(Of CDArea)
        Dim A1 As CDArea
        Dim Flag As Boolean = False

        Dim Lsty As New List(Of CDArea)
        Dim Arar As CDArea()
        Dim Arf As New CDArea
        Dim Kk As New List(Of CDArea)
        Dim Kk1 As New List(Of CDArea)

        Dim CADrm As New List(Of CDrum)
        Dim Dca As New List(Of Integer)

        Try
            Ar.DStrtPt.x = Math.Round(Ar.DStrtPt.x, 4)
            Ar.DStrtPt.y = Math.Round(Ar.DStrtPt.y, 4)
            Ar.DStrtPt.z = Math.Round(Ar.DStrtPt.z, 4)

            Ar.DLengths = Math.Round(Ar.DLengths, 4)
            Ar.DWidth = Math.Round(Ar.DWidth, 4)
            Ar.DHeight = Math.Round(Ar.DHeight, 4)

            'Stop

            For i As Integer = 0 To Lsty.Count - 1
                CDLstx.Add(Lsty(i))
            Next

            Arar = CDLstx.ToArray

            For i As Integer = LBound(Arar) To UBound(Arar)
                A1 = Arar(i)

                If A1.DHVUnionItrXCANxt(Ar) Is Nothing Then             'If A1.DHVUnionItrX(Ar) Is Nothing Then

                Else

                    Flag = True
                End If

            Next

            'Stop

            If Not Flag Then

                CDLstx.Add(Ar)

                Return CDLstx
            Else

                Arf = Nothing
                Kk.Clear()

                Do While CDLstx.Count > 0
                    A1 = CDLstx.Item(CDLstx.Count - 1)

                    A1.DStrtPt.x = Math.Round(A1.DStrtPt.x, 4)
                    A1.DStrtPt.y = Math.Round(A1.DStrtPt.y, 4)
                    A1.DStrtPt.z = Math.Round(A1.DStrtPt.z, 4)

                    A1.DLengths = Math.Round(A1.DLengths, 4)
                    A1.DWidth = Math.Round(A1.DWidth, 4)
                    A1.DHeight = Math.Round(A1.DHeight, 4)

                    CDLstx.RemoveAt(CDLstx.Count - 1)

                    If A1.DHVUnionItrXCANxt(Ar) Is Nothing Then                            'If A1.DHVUnionItrX(Ar) Is Nothing Then

                        LstS1.Add(A1)

                    Else

                        Arf = A1.DHVUnionItrXCANxt(Ar)                               'Arf = A1.DHVUnionItrX(Ar)
                        Kk.Add(Arf)
                        Kk1.Add(A1)

                    End If

                Loop

            End If

            Dim iii As DataRow()
            Dim ii As Integer

            DeleteTable("DTemp4")

            Dim Ar1 As New CDArea

            If Kk.Count = 1 Then

                LstS1.Add(Kk(0))

            Else

                For i As Integer = 0 To Kk.Count - 1
                    Ar1 = Kk(i)
                    DInsertTable("DTemp4", New Object() {CStr(Ar1.DStrtPt.x), CStr(Ar1.DStrtPt.y), CStr(Ar1.DStrtPt.z), CStr(i)})
                Next

                iii = DGetf("DTemp4", "", "z asc ,x asc ,y asc")
                ii = iii(0)("i")

                For i As Integer = 0 To Kk.Count - 1
                    If i = ii Then

                        LstS1.Add(Kk(i))

                    Else

                        LstS1.Add(Kk1(i))

                    End If

                Next
            End If

        Catch Err As Exception
            Return Nothing
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in DHDUnPushCANxt", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return LstS1

        Stop

    End Function

    Public Function DHVMrgX(ByVal Lst As List(Of CDArea), ByVal Ar As CDArea, ByRef Chngd As Boolean) As List(Of CDArea)

        'DStop

        Dim Ar1 As New CDArea
        Dim Ar2 As New CDArea
        Dim Arx As New CDArea
        Dim LstRet As New List(Of CDArea)
        Dim j As Integer = 0
        Dim k As Integer = 0
        Dim Lst1 As New List(Of Integer)

        Try

            For i As Integer = 0 To Lst.Count - 1
                Ar1 = Lst(i)

                If Ar1.DStrtPt.x = Ar.DStrtPt.x + Ar.DLengths AndAlso Ar1.DWidth = Ar.DWidth AndAlso Ar.DHeight = Ar1.DHeight AndAlso Ar1.DStrtPt.y = Ar.DStrtPt.y AndAlso Ar1.DStrtPt.z = Ar.DStrtPt.z Then
                    j = i
                End If

                If Ar1.DStrtPt.x = Ar.DStrtPt.x AndAlso Ar1.DStrtPt.y = Ar.DStrtPt.y AndAlso Ar1.DStrtPt.z = Ar.DStrtPt.z AndAlso Ar1.DLengths = Ar.DLengths AndAlso Ar1.DWidth = Ar.DWidth AndAlso Ar1.DHeight = Ar.DHeight Then
                    k = i
                End If
            Next

            'DDDStop

            If j <> 0 AndAlso k <> 0 Then
                Ar1 = Lst(j)
                Ar2 = Lst(k)
                Arx.DStrtPt.x = Ar2.DStrtPt.x
                Arx.DStrtPt.y = Ar2.DStrtPt.y
                Arx.DStrtPt.z = Ar2.DStrtPt.z
                Arx.DLengths = Ar1.DLengths + Ar2.DLengths
                Arx.DWidth = Ar1.DWidth
                Arx.DHeight = Ar1.DHeight

                'Stop

                For i As Integer = 0 To Lst.Count - 1
                    If i <> j AndAlso i <> k Then
                        LstRet.Add(Lst(i))
                    End If
                Next
                LstRet.Add(Arx)
                Chngd = True
                Return LstRet
            Else
                Chngd = False
                Return Lst
            End If

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in DHVMrgX", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try

    End Function

#End Region

#Region " Routine Definition "

    Public Sub DEventful()

        TransactionsMenu.Cursor = Cursors.WaitCursor
        TransactionsMenu.btnStatus.Cursor = Cursors.Hand
        TransactionsMenu.cmdExit.Cursor = Cursors.Hand
        TransactionsMenu.cmdAdd.Enabled = False
        TransactionsMenu.cmdDel.Enabled = False
        TransactionsMenu.cmdUpdate.Enabled = False
        TransactionsMenu.cmdRef.Enabled = False
        TransactionsMenu.cmdFirst.Enabled = False
        TransactionsMenu.cmdNext.Enabled = False
        TransactionsMenu.cmdPrev.Enabled = False
        TransactionsMenu.cmdLast.Enabled = False
        TransactionsMenu.cmdFind.Enabled = False
        TransactionsMenu.cmdEdit.Enabled = False
        TransactionsMenu.txtGapc.Enabled = False
        TransactionsMenu.txtGapf.Enabled = False
        TransactionsMenu.txtGapi.Enabled = False
        TransactionsMenu.txtGapm.Enabled = False
        TransactionsMenu.btnDirection.Enabled = False
        TransactionsMenu.chkbxArrangement.Enabled = False
        TransactionsMenu.cmdExit.Enabled = True

        TransactionsMenu.DgvI.Enabled = False
        'TransactionsMenu.btnSettings.Enabled = False
        'TransactionsMenu.btnBoxType.Enabled = False
        'TransactionsMenu.btnBoxDrumType.Enabled = False
        'TransactionsMenu.btnOthertype.Enabled = False

    End Sub

    Public Sub DEventless()

        TransactionsMenu.Cursor = Cursors.Default
        TransactionsMenu.cmdExit.Cursor = Cursors.Default
        TransactionsMenu.DgvI.Cursor = Cursors.Default
        TransactionsMenu.cmdAdd.Enabled = True
        TransactionsMenu.cmdDel.Enabled = True
        TransactionsMenu.cmdUpdate.Enabled = True
        TransactionsMenu.cmdRef.Enabled = True
        TransactionsMenu.cmdFirst.Enabled = True
        TransactionsMenu.cmdNext.Enabled = True
        TransactionsMenu.cmdPrev.Enabled = True
        TransactionsMenu.cmdLast.Enabled = True
        TransactionsMenu.cmdFind.Enabled = True
        TransactionsMenu.cmdEdit.Enabled = True
        TransactionsMenu.cmdExit.Enabled = True
        TransactionsMenu.txtGapc.Enabled = True
        TransactionsMenu.txtGapf.Enabled = True
        TransactionsMenu.txtGapi.Enabled = True
        TransactionsMenu.txtGapm.Enabled = True
        TransactionsMenu.btnDirection.Enabled = True
        TransactionsMenu.chkbxArrangement.Enabled = True
        TransactionsMenu.btnDirection.Text = "X ----->"

        TransactionsMenu.DgvI.Enabled = True
        'TransactionsMenu.btnSettings.Enabled = True
        'TransactionsMenu.btnBoxType.Enabled = True
        'TransactionsMenu.btnBoxDrumType.Enabled = True
        'TransactionsMenu.btnOthertype.Enabled = True
        'TransactionsMenu.btnDrumtype.Enabled = True
        TransactionsMenu.pbCSPD.Value = 0
        TransactionsMenu.pbCSPD.Visible = False
        TransactionsMenu.btnStatus.Visible = False
        TransactionsMenu.lblStatus.Text = ""
        TransactionsMenu.lblStatusINm.Text = ""
        TransactionsMenu.lblStatus.Visible = False
        TransactionsMenu.lblStatusINm.Visible = False

    End Sub

    Public Sub DInsertTable(ByVal TbName As String, ByVal Vals() As Object)     'Insert Data into the Xml File Whichever is passing

        Dim DInsTab As New System.Data.DataTable

        Dim XmlDd As New System.Xml.XmlDataDocument

        Try

            XmlDd.DataSet.ReadXml(CurDir() & "/" & TbName & ".xml")
            DInsTab = XmlDd.DataSet.Tables(0)
            DInsTab.Rows.Add(Vals)
            XmlDd.Save(CurDir() & "/" & TbName & ".xml")

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in DInsertTable", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Friend Sub DrumFffDHE()

        Try
            Dim cmde As New OleDb.OleDbCommand
            cmde.Connection = connDrums
            cmde.CommandText = "delete from empty"
            cmde.ExecuteNonQuery()

            For i As Integer = 0 To CDLst.Count - 1
                cmde.CommandText = "insert into empty values (" & CStr(CDLst(i).DStrtPt.x) & "," & CStr(CDLst(i).DStrtPt.y) & "," & CStr(CDLst(i).DStrtPt.z) & "," & CStr(CDLst(i).DLengths) & "," & CStr(CDLst(i).DWidth) & "," & CStr(CDLst(i).DHeight) & ")"
                cmde.ExecuteNonQuery()

            Next

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in DrumFffDHE", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            connDrums.Close()
        End Try

    End Sub

#End Region

#Region " Structure definition "

    Public Structure StructOcc1

        Public j As Integer
        Public j1 As List(Of Integer)
        Public CDLstSt As List(Of CDArea)

    End Structure

    Public Structure StructE1

        Public ItmNm As String
        Public Qty As Integer
        Public E1StLst As List(Of CDArea)

    End Structure

    Public Structure StructR1

        Public Ar As CDArea
        Public Method As Integer
        Public ItmNm As String
        Public R1CDLst As List(Of CDArea)

    End Structure

    Public Structure StructDrm1

        Public DAr As CDrum
        Public DrmMethod As Integer
        Public INm As String
        Public D1CDLst As List(Of CDrum)

    End Structure

#End Region

End Module
