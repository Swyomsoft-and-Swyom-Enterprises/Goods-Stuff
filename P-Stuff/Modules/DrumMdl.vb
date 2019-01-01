
'Program Name: -    DrumMdl.vb
'Programmer Name: - Satwadhir B. Pawar Mob No. :- 9323974665
'Company Name:-     Hazel Infotech LTD. Mumbai
'Project Name: -    P-Stuff Plus (Container Stuffing)
'Date: -            23 Dec 2K8 5.40 PM (Modified Time)

'Tips: - The code is debugging at that particular dimensions, quantity and sequence.
'        you are decide it the logic happen is correct to that way or its are some 
'        different way the understanding to at your best level is the correct logic 
'        of this particular code block.

'Description: - DrumMdl is the drum item placing module which is used to generating
'               the 3D VRML Code written in to First.wrl file to shown the drum isometric 3D view. 
'               These are various routines and function which can generate the final output of the
'               VRML programming to view to user by Alteros viewers.

#Region "Importing Object "

Imports DrumMidPt
Imports DrumCtrPt
Imports DrmCANxtRsPt
Imports SDOleDb = System.Data.OleDb

#End Region

Module DrumMdl

#Region " Module Declaration "

    Public DCG As DCenterPt = New DCenterPt()      'DmpIR.dll Used

    Public DCP As DMiddlePt = New DMiddlePt()      'DcpIR.dll Used

    Public DcaNp As NxtCptSDH = New NxtCptSDH()     'DcaNrs.dll Used

    Public SrNo As Integer = 1          'Insert table DrumStuffCA

    Public Numb As Int64 = 1       'Drum Program Number
    Public Sign As UInt16          'Drum Dll Flag set

    Public DiaFlg As Boolean = False        'Master CartonEntry
    Public FlgArngmnt As Boolean = False    'Simple Or Cross Arrangement

    Public _2D As Double = 0                  'Check wther its first second row or third row

    Public DQtyMax As Boolean = False       'Maximum Quantity Find out By these Flag is used

    Public DTotalLengthsic As Single
    Public DTotalWidthic As Single
    Public DTotalHeightic As Single

    Public DTotalDiameterc As Single

    Public DQTpUpI As Boolean       'Use in Class TransactionsMenu  ==>> Sub ComboBox_SelectedIndexChanged

    Public SMaxQtyIDrm As Integer    'Use in Class TransactionsMenu  ==>> Sub ComboBox_SelectedIndexChanged

    'Private Shared exitFlag As Boolean = False
    Public PieFlag As Boolean = False

    Public CL As Double = 0
    Public CW As Double = 0
    Public CH As Double = 0

    Public DDia As Double = 0
    Public DDiaL As Double = 0
    Public DDiaW As Double = 0
    Public DHt As Double = 0
    Public DRds As Double = 0

    Public DpHt As Double = 0       'previous values stored
    Public DpRds As Double = 0

    Dim Count As UInt32 = 0       'Inserting count in side next row arrangement

    Public SS As Integer
    Public NR As Boolean = False
    Public flgDHD As Boolean = False         'Drum Dia. Ht. Different Flag
    Public CAFRA As Boolean = False                 'Cross arrangement first row in datagrid check

    Dim DCnt As New CDMidPoint          ' Used in DrumGeomCylDHE

    Friend DrmRWidx As Integer      'Drum rowindex value

    Public LstSav As New List(Of List(Of CDArea))

#End Region

#Region " Function Definition "

    Public Function DrmUnionItrPtDHD(ByVal DAr1 As CDArea, ByVal DAr2 As CDArea) As List(Of CDArea)
        'Public Function DrmUnionItrPtDHD(ByVal Ar1 As CDArea, ByVal Ar2 As CDArea) As List(Of CDArea)

        '@@@@@
        'DStop
        '@@@@@

        Dim DArRet1 As New CDArea
        Dim DrmArRet1 As New CDrum
        Dim DArRet2 As New CDArea
        Dim DrmArRet2 As New CDArea
        Dim DLstRet As New List(Of CDArea)
        Dim DrmLstRet As New List(Of CDrum)

        Try

            '******************************************************************
            '******************************************************************

            DAr1.DStrtPt.x = Math.Round(DAr1.DStrtPt.x, 5)               'Ar1.DStrtPt.x = Math.Round(Ar1.DStrtPt.x, 4)
            DAr1.DStrtPt.y = Math.Round(DAr1.DStrtPt.y, 5)               'Ar1.DStrtPt.y = Math.Round(Ar1.DStrtPt.y, 4)
            DAr1.DStrtPt.z = Math.Round(DAr1.DStrtPt.z, 5)               'Ar1.DStrtPt.z = Math.Round(Ar1.DStrtPt.z, 4)

            DAr1.DLengths = Math.Round(DAr1.DLengths, 5)                 'Ar1.DLengths = Math.Round(Ar1.DLengths, 4)
            DAr1.DWidth = Math.Round(DAr1.DWidth, 5)                     'Ar1.DWidth = Math.Round(Ar1.DWidth, 4)
            DAr1.DHeight = Math.Round(DAr1.DHeight, 5)                   'Ar1.DHeight = Math.Round(Ar1.DHeight, 4)
            DAr1.DRadius = Math.Round(DAr1.DRadius, 5)

            DAr2.DStrtPt.x = Math.Round(DAr2.DStrtPt.x, 5)               'Ar2.DStrtPt.x = Math.Round(Ar2.DStrtPt.x, 4)
            DAr2.DStrtPt.y = Math.Round(DAr2.DStrtPt.y, 5)               'Ar2.DStrtPt.y = Math.Round(Ar2.DStrtPt.y, 4)
            DAr2.DStrtPt.z = Math.Round(DAr2.DStrtPt.z, 5)               'Ar2.DStrtPt.z = Math.Round(Ar2.DStrtPt.z, 4)

            DAr2.DLengths = Math.Round(DAr2.DLengths, 5)                 'Ar2.DLengths = Math.Round(Ar2.DLengths, 4)
            DAr2.DWidth = Math.Round(DAr2.DWidth, 5)                     'Ar2.DWidth = Math.Round(Ar2.DWidth, 4)
            DAr2.DHeight = Math.Round(DAr2.DHeight, 5)                   'Ar2.DHeight = Math.Round(Ar2.DHeight, 4)
            DAr2.DRadius = Math.Round(DAr2.DRadius, 5)

            If DAr1.DStrtPt.y = DAr2.DStrtPt.y AndAlso DAr1.DStrtPt.z = DAr2.DStrtPt.z AndAlso DAr1.DHeight = DAr2.DHeight Then
                If (DAr2.DStrtPt.x = (DAr2.DStrtPt.x + DAr1.DLengths)) Then
                    If DAr1.DWidth = DAr2.DWidth Then
                        DArRet1.DStrtPt.x = DAr1.DStrtPt.x
                        DArRet1.DStrtPt.y = DAr1.DStrtPt.y
                        DArRet1.DStrtPt.z = DAr1.DStrtPt.z
                        DArRet1.DLengths = DAr1.DLengths + DAr2.DLengths
                        DArRet1.DWidth = DAr1.DWidth
                        DArRet1.DHeight = DAr1.DHeight
                        DArRet1.DRadius = DAr1.DRadius

                        DArRet2.DStrtPt.x = 0
                        DArRet2.DStrtPt.y = 0
                        DArRet2.DStrtPt.z = 0
                        DArRet2.DLengths = 0
                        DArRet2.DWidth = 0
                        DArRet2.DHeight = 0

                        DLstRet.Add(DArRet1)
                        DLstRet.Add(DArRet2)

                        Return DLstRet

                    Else

                        If DAr1.DWidth < DAr2.DWidth Then

                            DArRet1.DStrtPt.x = DAr1.DStrtPt.x
                            DArRet1.DStrtPt.y = DAr1.DStrtPt.y
                            DArRet1.DStrtPt.z = DAr1.DStrtPt.z
                            DArRet1.DLengths = DAr1.DLengths + DAr2.DLengths
                            DArRet1.DWidth = DAr1.DWidth
                            DArRet1.DHeight = DAr1.DHeight

                            DArRet2.DStrtPt.x = DAr2.DStrtPt.x
                            DArRet2.DStrtPt.y = DAr1.DStrtPt.y + DAr1.DWidth
                            DArRet2.DStrtPt.z = DAr1.DStrtPt.z
                            DArRet2.DLengths = DAr2.DLengths
                            DArRet2.DWidth = DAr2.DWidth - DAr1.DWidth
                            DArRet2.DHeight = DAr2.DHeight

                            DLstRet.Add(DArRet1)
                            DLstRet.Add(DArRet2)

                            Return DLstRet

                        End If

                        If DAr2.DWidth < DAr1.DWidth Then

                            DArRet1.DStrtPt.x = DAr1.DStrtPt.x
                            DArRet1.DStrtPt.y = DAr1.DStrtPt.y
                            DArRet1.DStrtPt.z = DAr1.DStrtPt.z
                            DArRet1.DLengths = DAr1.DLengths + DAr2.DLengths
                            DArRet1.DWidth = DAr2.DWidth
                            DArRet1.DHeight = DAr1.DHeight

                            DArRet2.DStrtPt.x = DAr1.DStrtPt.x
                            DArRet2.DStrtPt.y = DAr2.DStrtPt.y + DAr2.DWidth
                            DArRet2.DStrtPt.z = DAr1.DStrtPt.z
                            DArRet2.DLengths = DAr1.DLengths
                            DArRet2.DWidth = DAr1.DWidth - DAr2.DWidth
                            DArRet2.DHeight = DAr2.DHeight

                            DLstRet.Add(DArRet1)
                            DLstRet.Add(DArRet2)

                            Return DLstRet

                        End If

                    End If

                End If

                If (DAr1.DStrtPt.x = (DAr2.DStrtPt.x + DAr2.DLengths)) Then
                    If DAr1.DWidth = DAr2.DWidth Then

                        DArRet1.DStrtPt.x = DAr2.DStrtPt.x
                        DArRet1.DStrtPt.y = DAr2.DStrtPt.y
                        DArRet1.DStrtPt.z = DAr2.DStrtPt.z
                        DArRet1.DLengths = DAr1.DLengths + DAr2.DLengths
                        DArRet1.DWidth = DAr1.DWidth
                        DArRet1.DHeight = DAr1.DHeight

                        DArRet2.DStrtPt.x = 0
                        DArRet2.DStrtPt.y = 0
                        DArRet2.DStrtPt.z = 0
                        DArRet2.DLengths = 0
                        DArRet2.DWidth = 0
                        DArRet2.DHeight = 0

                        DLstRet.Add(DArRet1)
                        DLstRet.Add(DArRet2)

                        Return DLstRet

                    Else

                        If DAr2.DWidth < DAr1.DWidth Then

                            DArRet1.DStrtPt.x = DAr2.DStrtPt.x
                            DArRet1.DStrtPt.y = DAr2.DStrtPt.y
                            DArRet1.DStrtPt.z = DAr2.DStrtPt.z
                            DArRet1.DLengths = DAr2.DLengths + DAr1.DLengths
                            DArRet1.DWidth = DAr2.DWidth
                            DArRet1.DHeight = DAr2.DHeight

                            DArRet2.DStrtPt.x = DAr1.DStrtPt.x
                            DArRet2.DStrtPt.y = DAr2.DStrtPt.y + DAr2.DWidth
                            DArRet2.DStrtPt.z = DAr2.DStrtPt.z
                            DArRet2.DLengths = DAr1.DLengths
                            DArRet2.DWidth = DAr1.DWidth - DAr2.DWidth
                            DArRet2.DHeight = DAr1.DHeight

                            DLstRet.Add(DArRet1)
                            DLstRet.Add(DArRet2)

                            Return DLstRet

                        End If

                        If DAr1.DWidth < DAr2.DWidth Then

                            DArRet1.DStrtPt.x = DAr2.DStrtPt.x
                            DArRet1.DStrtPt.y = DAr2.DStrtPt.y
                            DArRet1.DStrtPt.z = DAr2.DStrtPt.z
                            DArRet1.DLengths = DAr2.DLengths + DAr1.DLengths
                            DArRet1.DWidth = DAr1.DWidth
                            DArRet1.DHeight = DAr2.DHeight

                            DArRet2.DStrtPt.x = DAr2.DStrtPt.x
                            DArRet2.DStrtPt.y = DAr1.DStrtPt.y + DAr1.DWidth
                            DArRet2.DStrtPt.z = DAr2.DStrtPt.z
                            DArRet2.DLengths = DAr2.DLengths
                            DArRet2.DWidth = DAr2.DWidth - DAr1.DWidth
                            DArRet2.DHeight = DAr1.DHeight

                            DLstRet.Add(DArRet1)
                            DLstRet.Add(DArRet2)

                            Return DLstRet

                        End If

                    End If

                End If

            End If

            DArRet1.DStrtPt.x = DAr1.DStrtPt.x
            DArRet1.DStrtPt.y = DAr1.DStrtPt.y
            DArRet1.DStrtPt.z = DAr1.DStrtPt.z
            DArRet1.DLengths = DAr1.DLengths + DAr2.DLengths

            If DAr1.DWidth < DAr2.DWidth Then
                DArRet1.DWidth = DAr1.DWidth
            Else
                DArRet1.DWidth = DAr2.DWidth
            End If
            DArRet1.DHeight = DAr1.DHeight

            If DAr1.DStrtPt.y = DAr2.DStrtPt.y Then
                DArRet2.DStrtPt.y = DAr1.DStrtPt.y + DAr1.DWidth
            Else
                DArRet2.DStrtPt.y = DAr2.DStrtPt.y
            End If
            DArRet2.DStrtPt.z = DAr2.DStrtPt.z
            If DAr2.DWidth < DAr1.DWidth Then
                DArRet2.DLengths = DAr1.DLengths
                DArRet2.DStrtPt.x = DAr1.DStrtPt.x
            Else
                DArRet2.DLengths = DAr2.DLengths
                DArRet2.DStrtPt.x = DAr2.DStrtPt.x
            End If
            DArRet2.DWidth = Math.Abs(DAr2.DWidth - DAr1.DWidth)
            DArRet2.DHeight = DAr2.DHeight

            If DAr1.DStrtPt.x = DAr2.DStrtPt.x AndAlso DAr1.DLengths < DAr2.DLengths AndAlso DAr2.DStrtPt.y = DAr1.DStrtPt.y + DAr1.DWidth Then
                DArRet1.DLengths = DAr1.DLengths
                DArRet1.DWidth = DAr1.DWidth + DAr2.DWidth
                DArRet1.DHeight = DAr1.DHeight

                DArRet2.DStrtPt.x = DAr1.DStrtPt.x + DAr1.DLengths
                DArRet2.DStrtPt.y = DAr2.DStrtPt.y
                DArRet2.DStrtPt.z = DAr1.DStrtPt.z
                DArRet2.DLengths = DAr2.DLengths - DAr1.DLengths
                DArRet2.DWidth = DAr2.DWidth
                DArRet2.DHeight = DAr1.DHeight
            End If

            If DAr1.DStrtPt.x < DAr2.DStrtPt.x AndAlso Math.Abs(DAr2.DStrtPt.y - DAr1.DStrtPt.y - DAr1.DWidth) < 0.00001 AndAlso Math.Abs(DAr1.DStrtPt.x + DAr1.DLengths - DAr2.DStrtPt.x - DAr2.DLengths) < 0.00001 Then
                DArRet1.DStrtPt.x = DAr2.DStrtPt.x
                DArRet1.DStrtPt.y = DAr1.DStrtPt.y
                DArRet1.DStrtPt.z = DAr1.DStrtPt.z
                DArRet1.DLengths = DAr2.DLengths
                DArRet1.DWidth = DAr1.DWidth + DAr2.DWidth
                DArRet1.DHeight = DAr1.DHeight

                DArRet2.DStrtPt.x = DAr1.DStrtPt.x
                DArRet2.DStrtPt.y = DAr1.DStrtPt.y
                DArRet2.DStrtPt.z = DAr1.DStrtPt.z
                DArRet2.DLengths = DAr2.DLengths - DAr1.DLengths
                DArRet2.DWidth = DAr1.DWidth
                DArRet2.DHeight = DAr1.DHeight
            End If

            DLstRet.Add(DArRet1)
            DLstRet.Add(DArRet2)

            Return DLstRet

            '******************************************************************
            '******************************************************************
        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in DrumUnionItrPDHE", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try

    End Function

    Public Function DrmMrgXDHD(ByVal Lst As List(Of CDArea), ByVal Ar As CDArea, ByRef Chngd As Boolean) As List(Of CDrum)          'Public Function DrmMrgXDHD(ByVal Lst As List(Of CDArea), ByVal Ar As CDArea, ByRef Chngd As Boolean) As List(Of CDArea)

        '$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
        Stop
        '$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
        Dim LstDrm As New List(Of CDrum)
        Dim DAr1 As New CDrum                       'Dim Ar1 As New CDArea
        Dim DAr2 As New CDrum                       'Dim Ar2 As New CDArea
        Dim DArX As New CDrum                       'Dim Arx As New CDArea
        Dim DLstRet As New List(Of CDrum)          'Dim LstRet As New List(Of CDArea)
        Dim j As Integer = 0
        Dim k As Integer = 0
        Dim Lst1 As New List(Of Integer)

        Try
            For n As Integer = 0 To Lst.Count - 1

                DAr1 = Lst(n)

                If DAr1.DStrtPt.x = Ar.DStrtPt.x + Ar.DLengths AndAlso DAr1.DWidth = Ar.DWidth AndAlso Ar.DHeight = DAr1.DHeight AndAlso DAr1.DStrtPt.y = Ar.DStrtPt.y AndAlso DAr1.DStrtPt.z Then

                    j = n

                End If

                If DAr1.DStrtPt.x = Ar.DStrtPt.x AndAlso DAr1.DStrtPt.y = Ar.DStrtPt.y AndAlso DAr1.DStrtPt.z = Ar.DStrtPt.z AndAlso DAr1.DLengths = Ar.DLengths AndAlso DAr1.DWidth = Ar.DWidth AndAlso DAr1.DHeight = Ar.DHeight Then

                    k = n

                End If

            Next

            For p As Integer = 0 To Lst.Count - 1
                Try
                    LstDrm.Add(Lst(p))
                Catch
                    Exit Try
                End Try
            Next

            'Try
            '    For i As Integer = 0 To Lst.Count - 1
            '        Ar1 = Lst(i)

            '        If Ar1.DStrtPt.x = Ar.DStrtPt.x + Ar.DLengths AndAlso Ar1.DWidth = Ar.DWidth AndAlso Ar.DHeight = Ar1.DHeight AndAlso Ar1.DStrtPt.y = Ar.DStrtPt.y AndAlso Ar1.DStrtPt.z = Ar.DStrtPt.z Then
            '            j = i
            '        End If

            '        If Ar1.DStrtPt.x = Ar.DStrtPt.x AndAlso Ar1.DStrtPt.y = Ar.DStrtPt.y AndAlso Ar1.DStrtPt.z = Ar.DStrtPt.z AndAlso Ar1.DLengths = Ar.DLengths AndAlso Ar1.DWidth = Ar.DWidth AndAlso Ar1.DHeight = Ar.DHeight Then
            '            k = i
            '        End If
            '    Next

            If j <> 0 AndAlso k <> 0 Then

                DAr1 = Lst(j)
                DAr2 = Lst(k)
                DArX.DStrtPt.x = DAr2.DStrtPt.x
                DArX.DStrtPt.y = DAr2.DStrtPt.y
                DArX.DStrtPt.z = DAr2.DStrtPt.z
                DArX.DLengths = DAr1.DLengths + DAr2.DLengths
                DArX.DWidth = DAr1.DWidth
                DArX.DHeight = DAr1.DHeight
                DArX.DRadius = DAr1.DRadius

                For m As Integer = 0 To Lst.Count - 1

                    If n <> j AndAlso n <> k Then

                        DLstRet.Add(Lst(n))

                    End If

                Next

                DLstRet.Add(DArX)
                Chngd = True
                Return DLstRet

            Else

                Chngd = False
                Return LstDrm

            End If

            '    If j <> 0 AndAlso k <> 0 Then
            '        Ar1 = Lst(j)
            '        Ar2 = Lst(k)
            '        Arx.DStrtPt.x = Ar2.DStrtPt.x
            '        Arx.DStrtPt.y = Ar2.DStrtPt.y
            '        Arx.DStrtPt.z = Ar2.DStrtPt.z
            '        Arx.DLengths = Ar1.DLengths + Ar2.DLengths
            '        Arx.DWidth = Ar1.DWidth
            '        Arx.DHeight = Ar1.DHeight

            '        For i As Integer = 0 To Lst.Count - 1
            '            If i <> j AndAlso i <> k Then
            '                LstRet.Add(Lst(i))
            '            End If
            '        Next

            '        LstRet.Add(Arx)
            '        Chngd = True
            '        Return LstRet
            '    Else
            '        Chngd = False
            '        Return Lst
            '    End If

        Catch Erx As Exception
            MsgBox(Erx.Message)
            MsgBox(Erx.ToString)
            MessageBox.Show("Error in DrumMrgXDHD", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try

    End Function

    Public Function DFCount(ByVal StrQry As String) As Integer

        Try
            Dim Cmd As New SDOleDb.OleDbCommand
            With Cmd
                If connDrums.State = ConnectionState.Closed Then
                    connDrums.Open()
                End If
                Cmd.Connection = connDrums
                Cmd.CommandType = CommandType.Text
                Cmd.CommandText = StrQry
                DFCount = Val(Cmd.ExecuteScalar().ToString)
            End With

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in DFCount", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function

    Public Function DGenId(ByVal StrQry As String) As Integer 'maxId +1

        Try
            Dim Cmd As New SDOleDb.OleDbCommand
            With Cmd
                If connDrums.State = ConnectionState.Closed Then
                    connDrums.Open()
                End If
                Cmd.Connection = connDrums
                Cmd.CommandType = CommandType.Text
                Cmd.CommandText = StrQry
                DGenId = Val(Cmd.ExecuteScalar().ToString)
                DGenId = DGenId + 1

            End With

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in DGenId", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function

    Public Function DFindOpt(ByVal stk As List(Of CDArea), ByVal ar As CDArea, ByVal tpup As Boolean) As Integer

        Dim StAl As New List(Of StructArwi)
        Dim Cmd As New OleDb.OleDbCommand
        Cmd.Connection = connDrums
        Dim ILst As New List(Of Integer)
        Dim Ar1 As New CDArea

        Dim Ordr As Integer

        Dim Arw As New StructArwi

        Try

            For i As Integer = 0 To stk.Count - 1

                If StuffPlus.DFtIp(stk.Item(i), ar, tpup) Then
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

            Dim iii As DataRow()
            iii = DGetf("DTemp2", "", "z desc ,x asc,y asc")
            If iii.Length = 1 Then
                Return -1
            End If
            Ordr = iii(0)("i")

            Return Ordr

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in DFindOpt", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function

    Public Function DFindOptCA(ByVal stk As List(Of CDArea), ByVal ar As CDArea, ByVal tpup As Boolean) As Integer

        Dim StAl As New List(Of StructArwi)
        Dim Cmd As New OleDb.OleDbCommand
        Cmd.Connection = connDrums
        Dim ILst As New List(Of Integer)
        Dim Ar1 As New CDArea

        Dim Ordr As Integer

        Dim Arw As New StructArwi

        Try

            For i As Integer = 0 To stk.Count - 1

                If StuffPlus.DFtIpCA(stk.Item(i), ar, tpup) Then
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

            Dim iii As DataRow()
            iii = DGetf("DTemp2", "", "z desc ,x asc,y asc")
            If iii.Length = 1 Then
                Return -1
            End If
            Ordr = iii(0)("i")

            Return Ordr

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in DFindOptCA", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function

    Public Function DFindOptCANxt(ByVal DStk As List(Of CDArea), ByVal DAr As CDArea, ByVal tpup As Boolean) As Integer

        Dim StAl As New List(Of StructArwi)
        Dim Cmd As New OleDb.OleDbCommand
        Cmd.Connection = connDrums
        Dim ILst As New List(Of Integer)
        Dim Ar1 As New CDArea

        Dim Ordr As Integer

        Try

            Dim Arw As New StructArwi
            For i As Integer = 0 To stk.Count - 1

                If StuffPlus.DFtIpCA(DStk.Item(i), DAr, tpup) Then         'If StuffPlus.DFtIpCA(stk.Item(i), ar, tpup) Then
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

            Dim iii As DataRow()
            iii = DGetf("DTemp2", "", "z desc ,x asc,y asc")
            If iii.Length = 1 Then
                Return -1
            End If
            Ordr = iii(0)("i")

            Return Ordr

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in DFindOptCANxt", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function

#End Region

#Region " Routine Definition "

    Public Sub DrumCM(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Try

            ContainerMasterDrum.Show()

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in DrumCM", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub ShowBoxContMst(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Try
            ContainerMaster.Show()

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in ShowBoxContMst", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub ShowBoxCartMst(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Try

            MasterCartonEntry.Show()

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in ShowBoxCartMst", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub ShowMasterCartDrmEntry(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Try

            MasterCartonDrmEntry.Show()

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in ShowMasterCartDrmEntry", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub DrumStuffingActivity()

        Try
            TransactionsMenu.Show()

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in DrumStuffingActivity", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub DeleteTable(ByVal TbName As String)

        Try
            Dim Dtmm As New System.Data.DataTable

            Dim asdf As New System.Xml.XmlDataDocument
            asdf.DataSet.ReadXml(CurDir() & "/" & TbName & ".xml")
            Dtmm = asdf.DataSet.Tables(0)
            Do While Dtmm.Rows.Count > 1
                Dtmm.Rows(Dtmm.Rows.Count - 1).BeginEdit()
                Dtmm.Rows(Dtmm.Rows.Count - 1).Delete()
                Dtmm.AcceptChanges()

            Loop
            asdf.Save(CurDir() & "/" & TbName & ".xml")

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            'MessageBox.Show("Error in 'DrumDeleteTable' procedure in DrumMdl.", "Error .....", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
            MessageBox.Show("Error in DeleteTable", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Structure StructArwi

        Public ar As CDArea
        Public ordr As Integer

    End Structure

    Public Sub DProgressBarRunning()

        Try
            'TransactionsMenu.Focus()
            TransactionsMenu.pbCSPD.Value = TransactionsMenu.pbCSPD.Value + 2
            If TransactionsMenu.pbCSPD.Value = 100 Then
                TransactionsMenu.pbCSPD.Value = 0
                TransactionsMenu.Focus()
            End If

            DEventful()

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in DProgressBarRunning", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub GapVisibleF()

        TransactionsMenu.lblGf.Visible = False
        TransactionsMenu.lblGp.Visible = False
        TransactionsMenu.lblGi.Visible = False
        TransactionsMenu.lblGc.Visible = False
        TransactionsMenu.lblGm.Visible = False
        TransactionsMenu.lblDrn.Visible = False
        TransactionsMenu.btnDirection.Visible = False
        TransactionsMenu.txtGapf.Visible = False
        TransactionsMenu.txtGapi.Visible = False
        TransactionsMenu.txtGapc.Visible = False
        TransactionsMenu.txtGapm.Visible = False

    End Sub

    Public Sub DHSDrums()

        Try

            DisplayPicture.Show()

        Catch Ex As Exception

            Exit Try

        End Try

    End Sub

    Public Sub DrumTTGeom(ByVal fNm As String, ByVal Col As String, ByVal Transpx As Single, ByVal Tex As String, ByVal ItmNm As String, ByVal Wt As Single, ByVal QtyFlg As Boolean, ByVal TxtOpt As Boolean, ByVal MatName As String, ByVal Method As Integer, ByVal DataOpt As Boolean, ByVal ShapeOpt As String, ByVal X As Double, ByVal Z As Double, ByVal Y As Double, ByVal Rds As Double)

        DCnt.X = X
        DCnt.Y = Y
        DCnt.Z = Z

        Stop

        Try
            Dim Dq As Char = Chr(34)

            siSW.WriteLine("Transform {")
            FileClose(1)

            DrumTrnslnCylDHED(fNm, New String() {CStr(DCnt.X), CStr(DCnt.Z), CStr(DCnt.Y)})

        Catch Err As Exception
            siSW.Close()
            connDrums.Close()
            ConDrm.Close()
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in DrumTTGeom", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub DrmGeomCylCA(ByVal fNm As String, ByVal DCol As String, ByVal TransPx As Single, ByVal Tex As String, ByVal ItmNm As String, ByVal Wt As Single, ByVal FlgQty As Boolean, ByVal Txtopt As Boolean, ByVal MatNm As String, ByVal Method As Integer, ByVal DataOpt As Boolean, ByVal ShapeOpt As String, ByVal X As Double, ByVal Z As Double, ByVal Y As Double, ByVal Rds As Double)

        DCnt.X = X
        DCnt.Y = Y
        DCnt.Z = Z

        Try
            Dim Dq As Char = Chr(34)

            siSW.WriteLine("Transform {")
            FileClose(1)

            Static REO As Short = 0

            If DCnt.Y = Rds Then
                REO = 1
            Else
                REO = REO + 1
            End If

            DrmTranslnCylCA(fNm, New String() {CStr(DCnt.X), CStr(DCnt.Z), CStr(DCnt.Y)})

            IDrumStuffDHED(MatNm, DCnt.X, DCnt.Z, DCnt.Y, DRds, DHt, Method, Tex, DCol)

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in DrmGeomCylCA", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub DrumGeomCylDHED(ByVal fNm As String, ByVal Col As String, ByVal Transpx As Single, ByVal Tex As String, ByVal ItmNm As String, ByVal Wt As Single, ByVal QtyFlg As Boolean, ByVal TxtOpt As Boolean, ByVal MatName As String, ByVal Method As Integer, ByVal DataOpt As Boolean, ByVal ShapeOpt As String, ByVal X As Double, ByVal Z As Double, ByVal Y As Double, ByVal Rds As Double)

        'siSW.WriteLine("")
        'siSW.WriteLine("# Item Program No is : " & Numb)
        'siSW.WriteLine("")

        'Numb += 1
        'Stop

        DCnt.X = X
        DCnt.Y = Y
        DCnt.Z = Z

        Try
            Dim Dq As Char = Chr(34)

            siSW.WriteLine("Transform {")
            FileClose(1)

            Static REO As Short = 0

            If DCnt.Y = Rds Then
                REO = 1
            Else
                REO = REO + 1
            End If

            DrumTrnslnCylDHED(fNm, New String() {CStr(DCnt.X), CStr(DCnt.Z), CStr(DCnt.Y)})

            IDrumStuffDHED(MatName, DCnt.X, DCnt.Z, DCnt.Y, DRds, DHt, Method, Tex, Col)    'Insert value in DrumStuffCA

        Catch Ex As Exception
            siSW.Close()
            connDrums.Close()
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in DrumGeomCylDHED", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub IDrumStuffDHED(ByVal MatName As String, ByVal X As Double, ByVal Z As Double, ByVal Y As Double, ByVal R As Double, ByVal H As Double, ByVal Method As Integer, ByVal Tex As String, ByVal Colr As String)

        DrmNxtArngmtDHE(X, Y, Z, R, H, MatName, SrNo)      'The last Dimnsions are stored in file

        If connDrums.State = ConnectionState.Closed Then connDrums.Open()
        'Stop
        Try

            Dim Cmd As New OleDb.OleDbCommand
            Cmd.Connection = connDrums
            Cmd.CommandText = "insert into DrumStuffCA values(" & CStr(SrNo) & ",'" & MatName & "'," & CStr(X) & "," & CStr(Y) & "," & CStr(Z) & "," & CStr(CL) & "," & CStr(CW) & "," & CStr(CH) & "," & CStr(DHt) & "," & CStr(DRds) & "," & CStr(Method) & ",'" & Colr & "','" & Tex & "',0)"
            Cmd.ExecuteNonQuery()

            'connDrums.Close()  'Do not Close Connection Here 

            SrNo += 1

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            connDrums.Close()
            MessageBox.Show("Error in IDrumStuffDHE", "Error....." & vbCrLf & "Data insert connection failure!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub DrmNxtArngmtDHE(ByVal pX As Double, ByVal pY As Double, ByVal pZ As Double, ByVal pR As Double, ByVal pH As Double, ByVal pNm As String, ByVal pSeq As Double)

        Dim Xf As String = Convert.ToString(pX)
        Dim Yf As String = Convert.ToString(pY)
        Dim Zf As String = Convert.ToString(pZ)
        Dim Rf As String = Convert.ToString(pR)
        Dim Hf As String = Convert.ToString(pH)
        Dim fSeq As String = Convert.ToString(pSeq)

        Dim LastData As String = CurDir() & "\Sat.CSP"

        Dim Sw As New System.IO.StreamWriter(LastData, False)

        Try

            Sw.WriteLine("X = " & Xf)
            Sw.WriteLine("Y = " & Yf)
            Sw.WriteLine("Z = " & Zf)
            Sw.WriteLine("R = " & Rf)
            Sw.WriteLine("H = " & Hf)
            Sw.WriteLine("Item Name = " & pNm)
            Sw.WriteLine("Final Sequance = " & fSeq)

            Sw.Close()

        Catch Ex As Exception
            Sw.Close()
            connDrums.Close()
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in DrmNxtArngmtDHE", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Sw.Close()
        End Try

    End Sub

    Public Sub DrmTranslnCylCA(ByVal fNm As String, ByVal DmPt() As String)

        Try

            siSW.WriteLine("translation -" & CStr(DmPt(0)) & " " & CStr(DmPt(1)) & " -" & CStr(DmPt(2)))
            'siSW.WriteLine("translation -" & CStr(DmPt(0)) & " " & CStr(DmPt(1)) & " -" & CStr(DmPt(2)))

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in DrmTranslnCylCA", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub DrumTrnslnCylDHED(ByVal fNm As String, ByVal DCntPt() As String)

        Try

            siSW.WriteLine("translation -" & CStr(DCntPt(0)) & " " & CStr(DCntPt(1)) & " -" & CStr(DCntPt(2)))

        Catch Err As Exception
            siSW.Close()
            connDrums.Close()
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in DrumTrnslnCylDHED", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub DrmRotnCylCA(ByVal fNm As String)

        Try

            siSW.WriteLine("rotation 0 0 0 0")

        Catch Err As Exception
            siSW.Close()
            connDrums.Close()
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in DrmRotnCylCA", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub DrumRotnCylDHED(ByVal fNm As String)

        Try

            siSW.WriteLine("rotation 0 0 0 0")          'rotation 0 0 0 0

        Catch Err As Exception
            siSW.Close()
            connDrums.Close()
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in DrumRotnCylDHED", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub DrumTrnspCylDHED(ByVal fNm As String, ByVal Grd As String, ByVal Col As String)

        Try

            If Col = "r" Then
                siSW.WriteLine("material Material { diffuseColor 1 0 0 ")
                siSW.WriteLine("transparency " & Grd & " }")
            ElseIf Col = "g" Then
                siSW.WriteLine("material Material { diffuseColor 0 1 0 ")
                siSW.WriteLine("transparency " & Grd & " }")
            ElseIf Col = "b" Then
                siSW.WriteLine("material Material { diffuseColor 0 0 1 ")
                siSW.WriteLine("transparency " & Grd & " }")
            ElseIf Col = "m" Then
                siSW.WriteLine("material Material { diffuseColor 0 1 1 ")
                siSW.WriteLine("transparency " & Grd & " }")
            ElseIf Col = "c" Then
                siSW.WriteLine("material Material { diffuseColor 1 0 1 ")
                siSW.WriteLine("transparency " & Grd & " }")
            ElseIf Col = "y" Then
                siSW.WriteLine("material Material { diffuseColor 1 1 0 ")
                siSW.WriteLine("transparency " & Grd & " }")
            Else
                siSW.WriteLine("material Material { diffuseColor 1 1 1 ")
                siSW.WriteLine("transparency " & Grd & " }")
            End If

        Catch Err As Exception
            siSW.Close()
            connDrums.Close()
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in DrumTrnspCylDHED", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub TranspDrmCA(ByVal fNm As String, ByVal GrD As String, ByVal colDrm As String)

        Try

            If colDrm = "r" Then
                siSW.WriteLine("material Material { diffuseColor 1 0 0 ")
                siSW.WriteLine("transparency " & GrD & " }")
            ElseIf colDrm = "g" Then
                siSW.WriteLine("material Material { diffuseColor 0 1 0 ")
                siSW.WriteLine("transparency " & GrD & " }")
            ElseIf colDrm = "b" Then
                siSW.WriteLine("material Material { diffuseColor 0 0 1 ")
                siSW.WriteLine("transparency " & GrD & " }")
            ElseIf colDrm = "m" Then
                siSW.WriteLine("material Material { diffuseColor 0 1 1 ")
                siSW.WriteLine("transparency " & GrD & " }")
            ElseIf colDrm = "c" Then
                siSW.WriteLine("material Material { diffuseColor 1 0 1 ")
                siSW.WriteLine("transparency " & GrD & " }")
            ElseIf colDrm = "y" Then
                siSW.WriteLine("material Material { diffuseColor 1 1 0 ")
                siSW.WriteLine("transparency " & GrD & " }")
            Else
                siSW.WriteLine("material Material { diffuseColor 1 1 1 ")
                siSW.WriteLine("transparency " & GrD & " }")
            End If

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in TranspDrm", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub DrumGCylDHED(ByVal fNm As String, ByVal DCmPt() As String)

        Try

            siSW.WriteLine("geometry Cylinder { radius " & CStr(DCmPt(0)) & " height " & CStr(DCmPt(1)) & " }")

            siSW.WriteLine("}")
            siSW.WriteLine("}")

        Catch err As Exception
            siSW.Close()
            connDrums.Close()
            MsgBox(err.Message)
            MsgBox(err.ToString)
            MessageBox.Show("Error in DrumGCylDHED", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        '$$$$$
        'Stop
        '$$$$$
        'siSW.Close()
        'connDrums.Close()

    End Sub

    Public Sub DrmGCylDHDCA(ByVal fNm As String, ByVal DCmPt() As String)

        Try
            siSW.WriteLine("geometry Cylinder { radius " & CStr(DCmPt(0)) & " height " & CStr(DCmPt(1)) & " }")

            siSW.WriteLine("}")
            siSW.WriteLine("}")

        Catch Err As Exception
            siSW.Close()
            connDrums.Close()
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in DrmGCylDHDCA", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub ICANxtInDummy(ByVal Xe As Double, ByVal Ye As Double, ByVal Ze As Double, ByVal Rr As Double, ByVal CL As Double, ByVal CW As Double, ByVal CH As Double, ByVal Dgm As Integer)
        'DDStop

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

    Public Sub DInCANxt(ByVal Xme As Double, ByVal Yme As Double, ByVal Zme As Double, ByVal Xg As Double, ByVal Yg As Double, ByVal Zg As Double)

        'Stop

        'Dim Count As UInt32 = 0
        Try

            If ConDrm.State = ConnectionState.Closed Then ConDrm.Open()

            Dim CmdAt As New OleDb.OleDbCommand

            CmdAt.Connection = ConDrm
            CmdAt.CommandText = "insert into DCANxt (SrNo, Xme, Yme, Zme, Xg, Yg, Zg) values (" & CStr(Count) & "," & CStr(Xme) & "," & CStr(Yme) & "," & CStr(Zme) & "," & CStr(Xg) & "," & CStr(Yg) & "," & CStr(Zg) & ")"
            CmdAt.ExecuteNonQuery()

            Count += 1

            'Stop

            If Count = 33 Then
                'Stop
                MsgBox("Ok")

                'Stop

            End If

            'Stop

        Catch Err As Exception
            ConDrm.Close()
            siSW.Close()
            connDrums.Close()
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in DInCANxt", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub CARDel_Dummy()

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

    Public Sub DCANxtDel()

        Dim CmdAt As New OleDb.OleDbCommand

        Try
            Try
                If ConDrm.State = ConnectionState.Closed Then ConDrm.Open()

                CmdAt.Connection = ConDrm
                CmdAt.CommandText = "delete from DCANxt"
                CmdAt.ExecuteNonQuery()

            Catch Err As Exception
                ConDrm.Dispose()
                ConDrm.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\Drums.mdb;Persist Security Info=False"
                ConDrm.Open()
                CmdAt.Connection = Nothing
                CmdAt.Connection = ConDrm
                CmdAt.CommandText = ""
                CmdAt.CommandText = "delete from DCANxt"
                CmdAt.ExecuteNonQuery()
                MsgBox(Err.Message, MsgBoxStyle.Critical, "Error in DCANxtDel")
            End Try

        Catch Ex As Exception
            ConDrm.Close()
            connDrums.Close()
            siSW.Close()
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in DCANxtDel", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    'Public Function UnPushDrumDHD(ByVal CDLstx As List(Of CDArea), ByVal Ar As CDArea) As List(Of CDArea)

    '    Stop

    '    Dim LstS1 As New List(Of CDArea)
    '    Dim A1 As CDArea
    '    Dim DA1 As New CDrum
    '    Dim Flag As Boolean = False

    '    Dim Lsty As New List(Of CDArea)
    '    Dim Arar As CDArea()
    '    Dim Arf As New CDArea
    '    Dim Kk As New List(Of CDArea)
    '    Dim Kk1 As New List(Of CDArea)

    '    Try
    '        Ar.DStrtPt.x = Math.Round(Ar.DStrtPt.x, 5)
    '        Ar.DStrtPt.y = Math.Round(Ar.DStrtPt.y, 5)
    '        Ar.DStrtPt.z = Math.Round(Ar.DStrtPt.z, 5)

    '        Ar.DLengths = Math.Round(Ar.DLengths, 5)
    '        Ar.DWidth = Math.Round(Ar.DWidth, 5)
    '        Ar.DHeight = Math.Round(Ar.DHeight, 5)
    '        Ar.DRadius = Math.Round(Ar.DRadius, 5)

    '        For k As Integer = 0 To Lsty.Count - 1
    '            CDLstx.Add(Lsty(k))
    '        Next

    '        Arar = CDLstx.ToArray

    '        'Dim n As Integer
    '        'For n As Integer = LBound(DArar) To UBound(DArar)
    '        '    DA1 = DArar(n)
    '        'Next

    '        For i As Integer = LBound(Arar) To UBound(Arar)              ' For n As Integer = LBound(DArar) To UBound(DArar)         
    '            A1 = Arar(i)


    '            If DA1.UnionItrX_DrumDHD(Ar) Is Nothing Then     'If A1.DrumUnionItrXDHE(Ar) Is Nothing Then       

    '            Else

    '                Flag = True
    '            End If

    '        Next
    '        If Not Flag Then

    '            CDLstx.Add(Ar)

    '            Return CDLstx
    '        Else

    '            Arf = Nothing
    '            Kk.Clear()

    '            Do While CDLstx.Count > 0

    '                A1 = CDLstx.Item(CDLstx.Count - 1)

    '                A1.DStrtPt.x = Math.Round(A1.DStrtPt.x, 4)
    '                A1.DStrtPt.y = Math.Round(A1.DStrtPt.y, 4)
    '                A1.DStrtPt.z = Math.Round(A1.DStrtPt.z, 4)

    '                A1.DLengths = Math.Round(A1.DLengths, 4)
    '                A1.DWidth = Math.Round(A1.DWidth, 4)
    '                A1.DHeight = Math.Round(A1.DHeight, 4)
    '                A1.DRadius = Math.Round(A1.DRadius, 4)

    '                CDLstx.RemoveAt(CDLstx.Count - 1)

    '                If DA1.UnionItrX_DrumDHD(Ar) Is Nothing Then             'If A1.DrumUnionItrXDHE(Ar) Is Nothing Then

    '                    LstS1.Add(A1)

    '                Else
    '                    Arf = DA1.UnionItrX_DrumDHD(Ar)           'Arf = A1.DrumUnionItrXDHE(Ar)
    '                    Kk.Add(Arf)
    '                    Kk1.Add(A1)

    '                End If

    '            Loop
    '        End If

    '        Dim iii As DataRow()
    '        Dim ii As Integer

    '        DeleteTable("DTemp4")

    '        Dim Ar1 As New CDArea

    '        If Kk.Count = 1 Then
    '            LstS1.Add(Kk(0))

    '        Else
    '            For i As Integer = 0 To Kk.Count - 1
    '                Ar1 = Kk(i)
    '                DInsertTable("DTemp4", New Object() {CStr(Ar1.DStrtPt.x), CStr(Ar1.DStrtPt.y), CStr(Ar1.DStrtPt.z), CStr(i)})
    '            Next

    '            iii = DGetf("DTemp4", "", "z asc ,x asc ,y asc")
    '            ii = iii(0)("i")

    '            For i As Integer = 0 To Kk.Count - 1

    '                If i = ii Then

    '                    LstS1.Add(Kk(i))

    '                Else

    '                    LstS1.Add(Kk1(i))

    '                End If

    '            Next
    '        End If

    '        Return LstS1

    '    Catch Err As Exception
    '        MsgBox(Err.Message)
    '        MessageBox.Show("Error in DrumUnPushDHE", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        Return Nothing
    '    End Try

    'End Function

#End Region

End Module

