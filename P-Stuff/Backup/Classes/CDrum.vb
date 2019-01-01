
'Program Name: -    CDrum.vb
'Programmer Name: - Satwadhir B. Pawar Mob No. :- 9323974665
'Company Name:-     Hazel Infotech LTD. Mumbai
'Project Name: -    P-Stuff Plus (Container Stuffing)
'Date: -            23 Dec 2K8 6.07 PM (Modified Time)

'Tips: - The code is debugging at that particular dimensions, quantity and sequence.
'        you are decide it the logic happen is correct to that way or its are some 
'        different way the understanding to at your best level is the correct logic 
'        of this particular code block.

'Description: - CDrum is the class CDrum which is inherited by CDArea and have two 
'               members quantity as Uint64 type and weight as Double type.
'               This class includes various routines and functions which is generating the 
'               drum (cylinder) geometry VRML program. 

Public Class CDrum

#Region " Class Declaration "

    Inherits CDArea

    Public DmQty As UInt64              'Drum quantity is always positive 
    Public DmWt As Double

#End Region

#Region " Routine Definition "

    Public Sub AutoDrawDHDDrmSA(ByVal Fn As String, ByVal Col As String, ByVal Transpx As Single, ByVal Tex As String, ByVal ItmNm As String, ByVal Wt As Single, ByVal QtyFlg As Boolean, ByVal TxtOpt As Boolean, ByVal MatName As String, ByVal Method As Integer, ByVal DataOpt As Boolean, ByVal ShapeOpt As String, ByVal DDia As Double, ByVal DRds As Double, ByVal DHt As Double)               'Auto Draw Drum Simple Arrangement Diameter And Heights Are equal

        'DStop

        Dim Pt As New CDrum
        Dim DmCp As New CDMidPoint
        Dim X As Double
        Dim Z As Double
        Dim Y As Double
        Dim Flg As Int16
        Dim Dia As Double
        Dim Rds As Double
        Dim Ht As Double

        Try
            Pt.DCntPt.X = Me.DStrtPt.x                'Dim CntX As Single = Me.DStrtPt.x
            Pt.DCntPt.Y = Me.DStrtPt.y                'Dim CntY As Single = Me.DStrtPt.y
            Pt.DCntPt.Z = Me.DStrtPt.z                'Dim CntZ As Single = Me.DStrtPt.z

            'DStop

            Dia = DDia
            Rds = DRds
            Ht = DHt

            If Ht = Dia Then                                        'If Ht = Dia Then
                If Pt.DCntPt.X <> 0 Then                            'If CntX <> 0 Then
                    NRDrum = True                                   'NR = True               'Step down to second row
                    GoTo StepDwnDrm                                 'GoTo StepDwn
                End If                                              'End If

                If Pt.DCntPt.Z = 0 Then                             'If CntZ = 0 Then

                    Flg = 0                                         'Flg = 0

                    X = DGmCpt.XDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)                               'X = DCG.GetDX(CntX, CntY, CntZ, Rds, Ht, Flg)       'DmpIR.dll Used

                    Flg = 0                                                                                             'Flg = 0

                    Y = DGmCpt.YDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)                               'Y = DCG.GetDY(CntX, CntY, CntZ, Rds, Ht, Flg)

                    Flg = 0                                                                                             'Flg = 0

                    Z = DGmCpt.ZDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)                               'Z = DCG.GetDZ(CntX, CntY, CntZ, Rds, Ht, Flg)       'Rds + CntZ

                ElseIf Pt.DCntPt.Y = 0 Then                                                                             'ElseIf CntY = 0 Then

                    Flg = 0                                                                                             'Flg = 0

                    X = DGmCpt.XDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)                                'X = DCG.GetDX(CntX, CntY, CntZ, Rds, Ht, Flg)

                    Flg = 0                                                                                             'Flg = 0

                    Y = DGmCpt.YDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)                                'Y = DCG.GetDY(CntX, CntY, CntZ, Rds, Ht, Flg)

                    Flg = 1                                                                                             'Flg = 1

                    Z = DGmCpt.ZDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)                               'Z = DCG.GetDZ(CntX, CntY, CntZ, Rds, Ht, Flg)

                End If                                                                                                  'End If

                If Pt.DCntPt.Y <> 0 Then                                                                                'If CntY <> 0 Then

                    Flg = 3                                                                                             'Flg = 3

                    X = DGmCpt.XDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)                                'X = DCG.GetDX(CntX, CntY, CntZ, Rds, Ht, Flg)       'DmpIR.dll Used

                    Flg = 0                                                                                              'Flg = 0

                    Y = DGmCpt.YDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)                               'Y = DCG.GetDY(CntX, CntY, CntZ, Rds, Ht, Flg)       'first Row Second Column

                    Flg = 1                                                                                             'Flg = 1

                    Z = DGmCpt.ZDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)                               'Z = DCG.GetDZ(CntX, CntY, CntZ, Rds, Ht, Flg)

                End If                                                                                                   'End If

                ''Implement(Here)

StepDwnDrm:     'StepDwn:
                If NRDrum Then                                                                                          'If NR Then

                    If Pt.DCntPt.Z = 0 Then                                                                             'If CntZ = 0 Then

                        Flg = 0                                                                                         'Flg = 0

                        X = DGmCpt.XDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)                           'X = DCG.GetDX(CntX, CntY, CntZ, Rds, Ht, Flg)       'DmpIR.dll Used

                        Flg = 3                                                                                          'Flg = 3

                        Y = DGmCpt.YDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)                           'Y = DCG.GetDY(CntX, CntY, CntZ, Rds, Ht, Flg)

                        Flg = 0                                                                                         'Flg = 0

                        Z = DGmCpt.ZDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)                           'Z = DCG.GetDZ(CntX, CntY, CntZ, Rds, Ht, Flg)       'Rds + CntZ

                    Else                                                                                                'Else

                        Flg = 0

                        X = DGmCpt.XDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                        Flg = 3

                        Y = DGmCpt.YDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                        Flg = 1

                        Z = DGmCpt.ZDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                    End If

                    If Pt.DCntPt.Y <> 0 Then

                        Flg = 3

                        X = DGmCpt.XDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                        Flg = 3

                        Y = DGmCpt.YDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                        Flg = 1

                        Z = DGmCpt.ZDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                    End If

                End If

            End If

            'Height and Diameter are different

            If Ht <> Dia Then

                If Pt.DCntPt.X <> 0 Then                  'If CntX <> 0 Then
                    DHDNRDrum = True                      'Step down to second row
                    GoTo DHDStepDwn
                End If

                If Pt.DCntPt.Z = 0 AndAlso Pt.DCntPt.Y = 0 Then

                    Flg = 0

                    X = DGmCpt.XDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                    Flg = 0

                    Y = DGmCpt.YDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                    Flg = 3

                    Z = DGmCpt.ZDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                Else

                    Flg = 0

                    X = DGmCpt.XDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                    Flg = 0

                    Y = DGmCpt.YDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                    Flg = 4

                    Z = DGmCpt.ZDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                End If

                If Pt.DCntPt.Y <> 0 Then

                    Flg = 3

                    X = DGmCpt.XDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                    Flg = 3

                    Y = DGmCpt.YDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                    Flg = 4

                    Z = DGmCpt.ZDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                End If

DHDStepDwn:

                'aStop        '9 june 2K8 4.13 PM modified      8 May 2k8 12.33 PM

                If DHDNRDrum Then

                    If Pt.DCntPt.Z = 0 Then                                    'If CntZ = 0 Then

                        Flg = 0

                        X = DGmCpt.XDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)           'X = DCP.SetDX(CntX, CntY, CntZ, Rds, Ht, Flg)       'DmpIR.dll Used

                        Flg = 3

                        Y = DGmCpt.YDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)         'Y = DCP.SetDY(CntX, CntY, CntZ, Rds, Ht, Flg)

                        Flg = 3

                        Z = DGmCpt.ZDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)           'Z = DCP.SetDZ(CntX, CntY, CntZ, Rds, Ht, Flg)       'Rds + CntZ

                    Else

                        Flg = 0

                        X = DGmCpt.XDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)              'X = DCP.SetDX(CntX, CntY, CntZ, Rds, Ht, Flg)

                        Flg = 3

                        Y = DGmCpt.YDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)               'Y = DCP.SetDY(CntX, CntY, CntZ, Rds, Ht, Flg)

                        Flg = 4

                        Z = DGmCpt.ZDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)               'Z = DCP.SetDZ(CntX, CntY, CntZ, Rds, Ht, Flg)


                    End If


                    If Pt.DCntPt.Y <> 0 Then                                  'If CntY <> 0 Then

                        'aStop modified 9 June 2K8 4.52 PM       '8 May 2k8 1.07 PM

                        Flg = 3

                        X = DGmCpt.XDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)                  'X = DCP.SetDX(CntX, CntY, CntZ, Rds, Ht, Flg)       'DmpIR.dll Used

                        Flg = 3

                        Y = DGmCpt.YDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, DHt, Flg)                 'Y = DCP.SetDY(CntX, CntY, CntZ, Rds, Ht, Flg)       'Second Row Second Column

                        Flg = 4

                        Z = DGmCpt.ZDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, DHt, Flg)                   'Z = DCP.SetDZ(CntX, CntY, CntZ, Rds, Ht, Flg)

                    End If

                End If

            End If



            '            If Ht <> Dia Then       '#################################

            '                If CntZ = 0 AndAlso CntY = 0 Then

            '                    Flg = 0

            '                    X = DCP.SetDX(CntX, CntY, CntZ, Rds, Ht, Flg)       'DmpIR.dll Used

            '                    Flg = 0

            '                    Y = DCP.SetDY(CntX, CntY, CntZ, Rds, Ht, Flg)

            '                    Flg = 3

            '                    Z = DCP.SetDZ(CntX, CntY, CntZ, Rds, Ht, Flg)       'Rds + CntZ

            '                Else 'If CntY = 0 Then

            '                    Flg = 0

            '                    X = DCP.SetDX(CntX, CntY, CntZ, Rds, Ht, Flg)

            '                    Flg = 0

            '                    Y = DCP.SetDY(CntX, CntY, CntZ, Rds, Ht, Flg)       'DmpIR.dll Used


            '                    Flg = 1

            '                    Z = DCP.SetDZ(CntX, CntY, CntZ, Rds, Ht, Flg)

            '                End If

            '                If CntY <> 0 Then

            '                    Flg = 3

            '                    X = DCP.SetDX(CntX, CntY, CntZ, Rds, Ht, Flg)       'DmpIR.dll Used

            '                    Flg = 0

            '                    Y = DCP.SetDY(CntX, CntY, CntZ, Rds, Ht, Flg)       'first Row Second Column

            '                    Flg = 1

            '                    Z = DCP.SetDZ(CntX, CntY, CntZ, Rds, Ht, Flg)

            '                End If

            '            End If



            DmCp.DRds = Rds
            DmCp.DHt = Ht


            Pt.DCntPt.X = X
            Pt.DCntPt.Y = Y
            Pt.DCntPt.Z = Z
            Pt.DCntPt.DHt = DmCp.DHt
            Pt.DCntPt.DRds = DmCp.DRds


            If SS = 0 Then
                'siSW.WriteLine("]}]}]}]}]}")
            End If

            SS += 1

            'If SS = 2000 Then

            'Stop
            'siSW.Close()

            'End If

            siSW.WriteLine("")

            Try

                DrumGeomCylDHED(Fn, Col, Transpx, Tex, ItmNm, Wt, QtyFlg, TxtOpt, MatName, Method, DataOpt, ShapeOpt, X, Z, Y, Rds)
                DrumRotnCylDHED(Fn)

                siSW.WriteLine("children Shape {")
                siSW.WriteLine("appearance Appearance {")

                DrumTrnspCylDHED(Fn, Transpx, Col)

                Dim Dq As Char = Chr(34)

                If Tex <> "" Then
                    siSW.WriteLine("texture ImageTexture { url " & Dq & Tex & Dq & " }")
                End If

                siSW.WriteLine("}")

                DrumGCylDHED(Fn, New String() {CStr(DmCp.DRds), CStr(DmCp.DHt)})

            Catch Ex As Exception
                MsgBox(Ex.Message)
                MessageBox.Show("Error in AutoDrawDHDDrmSA", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
                connDrums.Close()
                siSW.Close()
            End Try

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MessageBox.Show("Error in AutoDrawDHDDrmSA", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            connDrums.Close()
            siSW.Close()
        End Try

    End Sub

    Public Sub AutoDrawDHDDrmSACA(ByVal Fn As String, ByVal Col As String, ByVal Transpx As Single, ByVal Tex As String, ByVal ItmNm As String, ByVal Wt As Single, ByVal QtyFlg As Boolean, ByVal TxtOpt As Boolean, ByVal MatName As String, ByVal Method As Integer, ByVal DataOpt As Boolean, ByVal ShapeOpt As String, ByVal DDia As Double, ByVal DRds As Double, ByVal DHt As Double)

        'Stop

        'siSW.Close()

        Dim Pt As New CDrum
        Dim DmCp As New CDMidPoint
        Dim X As Double
        Dim Z As Double
        Dim Y As Double
        Dim Flg As Int16
        Dim Dia As Double
        Dim Rds As Double
        Dim Ht As Double

        'Stop

        Dim tL As Double = CL
        Dim tW As Double = CW
        Dim tH As Double = CH

        Dim Xcs As Double = XL
        Dim Ycs As Double = YL
        Dim Zcs As Double = ZL

        Dim Xme As Double = Me.DStrtPt.x
        Dim Yme As Double = Me.DStrtPt.y
        Dim Zme As Double = Me.DStrtPt.z

        'Stop

        If _2D < YL Then
            'Me.DStrtPt.x = YL + DpRds
        Else
            'Me.DStrtPt.x = YL + DpRds
        End If

        'Stop

        Xg = Xg + DDia
        Yg = Yg + DDia
        Zg = Zg + DDia


        'Stop

        'siSW.Close()

        If Not FRFlg Then

            If Xg < tW Xor Zg < tH Then

                Me.DStrtPt.x = YL + DpRds

            Else

                FRFlg = True

            End If

        End If

        'Implements from here 25 July 2K8

        'Stop

        Try
            Pt.DCntPt.X = Me.DStrtPt.x
            Pt.DCntPt.Y = Me.DStrtPt.y
            Pt.DCntPt.Z = Me.DStrtPt.z

            Dia = DDia
            Rds = DRds
            Ht = DHt

            If Ht = Dia Then
                If Pt.DCntPt.X <> 0 Then
                    NRDrum = True
                    GoTo StepDwnDrm
                End If

                If Pt.DCntPt.Z = 0 Then

                    Flg = 0

                    'Pt.DStrtPt.x = DGmCpt.XDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)
                    Pt.DStrtPt.x = DmPt.X_DrmCA(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                    Flg = 0

                    Pt.DStrtPt.y = DmPt.Y_DrmCA(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)
                    'Pt.DStrtPt.y = DGmCpt.YDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                    Flg = 0

                    Pt.DStrtPt.z = DmPt.Z_DrmCA(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)
                    'Pt.DStrtPt.z = DGmCpt.ZDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                ElseIf Pt.DCntPt.Y = 0 Then

                    Flg = 0

                    'Pt.DStrtPt.x = DGmCpt.XDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)
                    Pt.DStrtPt.x = DmPt.X_DrmCA(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                    Flg = 0

                    'Pt.DStrtPt.y = DGmCpt.YDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)
                    Pt.DStrtPt.y = DmPt.Y_DrmCA(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                    Flg = 1

                    'Pt.DStrtPt.z = DGmCpt.ZDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)
                    Pt.DStrtPt.z = DmPt.Z_DrmCA(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                End If

                If Pt.DCntPt.Y <> 0 Then

                    Flg = 3

                    'Pt.DStrtPt.x = DGmCpt.XDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)
                    Pt.DStrtPt.x = DmPt.X_DrmCA(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                    Flg = 0

                    Pt.DStrtPt.y = DmPt.Y_DrmCA(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)
                    'Pt.DStrtPt.y = DGmCpt.YDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                    Flg = 1

                    'Pt.DStrtPt.z = DGmCpt.ZDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)
                    Pt.DStrtPt.z = DmPt.Z_DrmCA(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                End If



StepDwnDrm:
                If NRDrum Then

                    If Pt.DCntPt.Z = 0 Then

                        Flg = 0

                        'Pt.DStrtPt.x = DGmCpt.XDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)
                        Pt.DStrtPt.x = DmPt.X_DrmCA(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                        Flg = 3

                        'Pt.DStrtPt.y = DGmCpt.YDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)
                        Pt.DStrtPt.y = DmPt.Y_DrmCA(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                        Flg = 0

                        'Pt.DStrtPt.z = DGmCpt.ZDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)
                        Pt.DStrtPt.z = DmPt.Z_DrmCA(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                    Else

                        Flg = 0

                        'Pt.DStrtPt.x = DGmCpt.XDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)
                        Pt.DStrtPt.x = DmPt.X_DrmCA(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                        Flg = 3

                        Pt.DStrtPt.y = DGmCpt.YDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                        Flg = 1

                        Pt.DStrtPt.z = DGmCpt.ZDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                    End If

                    If Pt.DCntPt.Y <> 0 Then

                        Flg = 3

                        Pt.DStrtPt.x = DGmCpt.XDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                        Flg = 3

                        Pt.DStrtPt.y = DGmCpt.YDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                        Flg = 1

                        Pt.DStrtPt.z = DGmCpt.ZDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                    End If

                End If

            End If

            'Height and Diameter are different

            If Ht <> Dia Then

                If Pt.DCntPt.X <> 0 Then
                    DHDNRDrum = True
                    GoTo DHDStepDwn
                End If

                If Pt.DCntPt.Z = 0 AndAlso Pt.DCntPt.Y = 0 Then

                    Flg = 0

                    Pt.DStrtPt.x = DGmCpt.XDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                    Flg = 0

                    Pt.DStrtPt.y = DGmCpt.YDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                    Flg = 3

                    Pt.DStrtPt.z = DGmCpt.ZDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                Else

                    Flg = 0

                    Pt.DStrtPt.x = DGmCpt.XDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                    Flg = 0

                    Pt.DStrtPt.y = DGmCpt.YDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                    Flg = 4

                    Pt.DStrtPt.z = DGmCpt.ZDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                End If

                If Pt.DCntPt.Y <> 0 Then

                    Flg = 3

                    Pt.DStrtPt.x = DGmCpt.XDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                    Flg = 3

                    Pt.DStrtPt.y = DGmCpt.YDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                    Flg = 4

                    Pt.DStrtPt.z = DGmCpt.ZDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                End If

DHDStepDwn:

                If DHDNRDrum Then

                    If Pt.DCntPt.Z = 0 Then

                        Flg = 0

                        Pt.DStrtPt.x = DGmCpt.XDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                        Flg = 3

                        Pt.DStrtPt.y = DGmCpt.YDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                        Flg = 3

                        Pt.DStrtPt.z = DGmCpt.ZDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                    Else

                        Flg = 0

                        Pt.DStrtPt.x = DGmCpt.XDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                        Flg = 3

                        Pt.DStrtPt.y = DGmCpt.YDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                        Flg = 4

                        Pt.DStrtPt.z = DGmCpt.ZDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                    End If

                    If Pt.DCntPt.Y <> 0 Then                                  'If CntY <> 0 Then

                        'aStop modified 9 June 2K8 4.52 PM       '8 May 2k8 1.07 PM

                        Flg = 3

                        Pt.DStrtPt.x = DGmCpt.XDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                        Flg = 3

                        Pt.DStrtPt.y = DGmCpt.YDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, DHt, Flg)

                        Flg = 4

                        Pt.DStrtPt.z = DGmCpt.ZDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, DHt, Flg)

                    End If

                End If

            End If

            X = Pt.DStrtPt.x
            Y = Pt.DStrtPt.y
            Z = Pt.DStrtPt.z

            Dim Dpt As New CDrum

            DmCp.DRds = Rds
            DmCp.DHt = Ht

            Pt.DCntPt.X = X
            Pt.DCntPt.Y = Y
            Pt.DCntPt.Z = Z
            Pt.DCntPt.DHt = DmCp.DHt
            Pt.DCntPt.DRds = DmCp.DRds

            If SS = 0 Then
                'siSW.WriteLine("]}]}]}]}]}")
            End If

            SS += 1

            'Stop

            Dpt.DStrtPt.x = Pt.DCntPt.X
            Dpt.DStrtPt.y = Pt.DCntPt.Y
            Dpt.DStrtPt.z = Pt.DCntPt.Z
            Dpt.DCntPt.DHt = Pt.DCntPt.DHt
            Dpt.DCntPt.DRds = Pt.DCntPt.DRds

            Xg = Dpt.DStrtPt.x
            Yg = Dpt.DStrtPt.y
            Zg = Dpt.DStrtPt.z

            'Insert to database
            DInCANxt(Xme, Yme, Zme, Dpt.DStrtPt.x, Dpt.DStrtPt.y, Dpt.DStrtPt.z)

            'Stop

            siSW.WriteLine("")

            Try

                DrmGeomCylCA(Fn, Col, Transpx, Tex, ItmNm, Wt, QtyFlg, TxtOpt, MatName, Method, DataOpt, ShapeOpt, X, Z, Y, Rds)            'DrumGeomCylDHED(Fn, Col, Transpx, Tex, ItmNm, Wt, QtyFlg, TxtOpt, MatName, Method, DataOpt, ShapeOpt, X, Z, Y, Rds)
                DrmRotnCylCA(Fn)                                                                                                            'DrumRotnCylDHED(Fn)

                siSW.WriteLine("children Shape {")
                siSW.WriteLine("appearance Appearance {")

                TranspDrmCA(Fn, Transpx, Col)                                    'DrumTrnspCylDHED(Fn, Transpx, Col)

                Dim Dq As Char = Chr(34)

                If Tex <> "" Then
                    siSW.WriteLine("texture ImageTexture { url " & Dq & Tex & Dq & " }")
                End If

                siSW.WriteLine("}")

                DrmGCylDHDCA(Fn, New String() {CStr(DmCp.DRds), CStr(DmCp.DHt)})            'DrumGCylDHED(Fn, New String() {CStr(DmCp.DRds), CStr(DmCp.DHt)})

            Catch Ex As Exception
                MsgBox(Ex.Message)
                MessageBox.Show("Error in AutoDrawDHDDrmSA", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
                connDrums.Close()
                siSW.Close()
            End Try

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MessageBox.Show("Error in AutoDrawDHDDrmSA", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            connDrums.Close()
            siSW.Close()
        End Try

    End Sub

    Public Sub AutoDrawDHDDrmSACADUP(ByVal Fn As String, ByVal Col As String, ByVal Transpx As Single, ByVal Tex As String, ByVal ItmNm As String, ByVal Wt As Single, ByVal QtyFlg As Boolean, ByVal TxtOpt As Boolean, ByVal MatName As String, ByVal Method As Integer, ByVal DataOpt As Boolean, ByVal ShapeOpt As String, ByVal DDia As Double, ByVal DRds As Double, ByVal DHt As Double)

        Stop

        'siSW.Close()

        Dim Pt As New CDrum
        Dim DmCp As New CDMidPoint
        Dim X As Double
        Dim Z As Double
        Dim Y As Double
        Dim Flg As Int16
        Dim Dia As Double
        Dim Rds As Double
        Dim Ht As Double

        Stop

        Dim tL As Double = CL
        Dim tW As Double = CW
        Dim tH As Double = CH

        Dim Xcs As Double = XL
        Dim Ycs As Double = YL
        Dim Zcs As Double = ZL

        Dim Xme As Double = Me.DStrtPt.x
        Dim Yme As Double = Me.DStrtPt.y
        Dim Zme As Double = Me.DStrtPt.z

        Stop

        If _2D < YL Then
            'Me.DStrtPt.x = YL + DpRds
        Else
            'Me.DStrtPt.x = YL + DpRds
        End If



        Stop

        Try
            Pt.DCntPt.X = Me.DStrtPt.x                'Dim CntX As Single = Me.DStrtPt.x
            Pt.DCntPt.Y = Me.DStrtPt.y                'Dim CntY As Single = Me.DStrtPt.y
            Pt.DCntPt.Z = Me.DStrtPt.z                'Dim CntZ As Single = Me.DStrtPt.z

            Stop

            Dia = DDia
            Rds = DRds
            Ht = DHt

            If Ht = Dia Then                                        'If Ht = Dia Then
                If Pt.DCntPt.X <> 0 Then                            'If CntX <> 0 Then
                    NRDrum = True                                   'NR = True               'Step down to second row
                    GoTo StepDwnDrm                                 'GoTo StepDwn
                End If                                              'End If

                If Pt.DCntPt.Z = 0 Then                             'If CntZ = 0 Then

                    Flg = 0                                         'Flg = 0

                    'X = DGmCpt.XDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)                               'X = DCG.GetDX(CntX, CntY, CntZ, Rds, Ht, Flg)       'DmpIR.dll Used
                    Pt.DStrtPt.x = DGmCpt.XDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                    'Pt.DStrtPt.x = DGmCpt.XDCAt(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                    'Implements from 23 July 2K8


                    Flg = 0                                                                                             'Flg = 0

                    'Y = DGmCpt.YDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)                               'Y = DCG.GetDY(CntX, CntY, CntZ, Rds, Ht, Flg)
                    Pt.DStrtPt.y = DGmCpt.YDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                    Flg = 0                                                                                             'Flg = 0

                    'Z = DGmCpt.ZDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)                               'Z = DCG.GetDZ(CntX, CntY, CntZ, Rds, Ht, Flg)       'Rds + CntZ
                    Pt.DStrtPt.z = DGmCpt.ZDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                ElseIf Pt.DCntPt.Y = 0 Then                                                                             'ElseIf CntY = 0 Then

                    Flg = 0                                                                                             'Flg = 0

                    'X = DGmCpt.XDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)                                'X = DCG.GetDX(CntX, CntY, CntZ, Rds, Ht, Flg)
                    Pt.DStrtPt.x = DGmCpt.XDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                    Flg = 0                                                                                             'Flg = 0

                    Pt.DStrtPt.y = DGmCpt.YDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)                                'Y = DCG.GetDY(CntX, CntY, CntZ, Rds, Ht, Flg)

                    Flg = 1                                                                                             'Flg = 1

                    Pt.DStrtPt.z = DGmCpt.ZDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)                               'Z = DCG.GetDZ(CntX, CntY, CntZ, Rds, Ht, Flg)

                End If                                                                                                  'End If

                If Pt.DCntPt.Y <> 0 Then                                                                                'If CntY <> 0 Then

                    Flg = 3                                                                                             'Flg = 3

                    Pt.DStrtPt.x = DGmCpt.XDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)                                'X = DCG.GetDX(CntX, CntY, CntZ, Rds, Ht, Flg)       'DmpIR.dll Used

                    Flg = 0                                                                                              'Flg = 0

                    Pt.DStrtPt.y = DGmCpt.YDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)                               'Y = DCG.GetDY(CntX, CntY, CntZ, Rds, Ht, Flg)       'first Row Second Column

                    Flg = 1                                                                                             'Flg = 1

                    Pt.DStrtPt.z = DGmCpt.ZDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)                               'Z = DCG.GetDZ(CntX, CntY, CntZ, Rds, Ht, Flg)

                End If                                                                                                   'End If

                ''Implement(Here)

StepDwnDrm:     'StepDwn:
                If NRDrum Then                                                                                          'If NR Then

                    If Pt.DCntPt.Z = 0 Then                                                                             'If CntZ = 0 Then

                        Flg = 0                                                                                         'Flg = 0
                        'Pt.DStrtPt.x = DGmCpt.DrmCAtX(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)
                        Pt.DStrtPt.x = DGmCpt.XDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)                           'X = DCG.GetDX(CntX, CntY, CntZ, Rds, Ht, Flg)       'DmpIR.dll Used

                        Flg = 3                                                                                          'Flg = 3

                        Pt.DStrtPt.y = DGmCpt.YDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)                           'Y = DCG.GetDY(CntX, CntY, CntZ, Rds, Ht, Flg)

                        Flg = 0                                                                                         'Flg = 0

                        Pt.DStrtPt.z = DGmCpt.ZDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)                           'Z = DCG.GetDZ(CntX, CntY, CntZ, Rds, Ht, Flg)       'Rds + CntZ

                    Else                                                                                                'Else

                        Flg = 0
                        'Pt.DStrtPt.x = DGmCpt.DrmCAtX(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)
                        Pt.DStrtPt.x = DGmCpt.XDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                        Flg = 3

                        Pt.DStrtPt.y = DGmCpt.YDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                        Flg = 1

                        Pt.DStrtPt.z = DGmCpt.ZDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                    End If

                    If Pt.DCntPt.Y <> 0 Then

                        Flg = 3

                        Pt.DStrtPt.x = DGmCpt.XDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                        Flg = 3

                        Pt.DStrtPt.y = DGmCpt.YDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                        Flg = 1

                        Pt.DStrtPt.z = DGmCpt.ZDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                    End If

                End If

            End If

            'Height and Diameter are different

            If Ht <> Dia Then

                If Pt.DCntPt.X <> 0 Then                  'If CntX <> 0 Then
                    DHDNRDrum = True                      'Step down to second row
                    GoTo DHDStepDwn
                End If

                If Pt.DCntPt.Z = 0 AndAlso Pt.DCntPt.Y = 0 Then

                    Flg = 0

                    Pt.DStrtPt.x = DGmCpt.XDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                    Flg = 0

                    Pt.DStrtPt.y = DGmCpt.YDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                    Flg = 3

                    Pt.DStrtPt.z = DGmCpt.ZDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                Else

                    Flg = 0

                    Pt.DStrtPt.x = DGmCpt.XDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                    Flg = 0

                    Pt.DStrtPt.y = DGmCpt.YDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                    Flg = 4

                    Pt.DStrtPt.z = DGmCpt.ZDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                End If

                If Pt.DCntPt.Y <> 0 Then

                    Flg = 3

                    Pt.DStrtPt.x = DGmCpt.XDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                    Flg = 3

                    Pt.DStrtPt.y = DGmCpt.YDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                    Flg = 4

                    Pt.DStrtPt.z = DGmCpt.ZDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                End If

DHDStepDwn:

                'aStop        '9 june 2K8 4.13 PM modified      8 May 2k8 12.33 PM

                If DHDNRDrum Then

                    If Pt.DCntPt.Z = 0 Then                                    'If CntZ = 0 Then

                        Flg = 0

                        Pt.DStrtPt.x = DGmCpt.XDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)           'X = DCP.SetDX(CntX, CntY, CntZ, Rds, Ht, Flg)       'DmpIR.dll Used

                        Flg = 3

                        Pt.DStrtPt.y = DGmCpt.YDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)         'Y = DCP.SetDY(CntX, CntY, CntZ, Rds, Ht, Flg)

                        Flg = 3

                        Pt.DStrtPt.z = DGmCpt.ZDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)           'Z = DCP.SetDZ(CntX, CntY, CntZ, Rds, Ht, Flg)       'Rds + CntZ

                    Else

                        Flg = 0

                        Pt.DStrtPt.x = DGmCpt.XDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)              'X = DCP.SetDX(CntX, CntY, CntZ, Rds, Ht, Flg)

                        Flg = 3

                        Pt.DStrtPt.y = DGmCpt.YDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)               'Y = DCP.SetDY(CntX, CntY, CntZ, Rds, Ht, Flg)

                        Flg = 4

                        Pt.DStrtPt.z = DGmCpt.ZDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)               'Z = DCP.SetDZ(CntX, CntY, CntZ, Rds, Ht, Flg)

                    End If

                    If Pt.DCntPt.Y <> 0 Then                                  'If CntY <> 0 Then

                        'aStop modified 9 June 2K8 4.52 PM       '8 May 2k8 1.07 PM

                        Flg = 3

                        Pt.DStrtPt.x = DGmCpt.XDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)                  'X = DCP.SetDX(CntX, CntY, CntZ, Rds, Ht, Flg)       'DmpIR.dll Used

                        Flg = 3

                        Pt.DStrtPt.y = DGmCpt.YDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, DHt, Flg)                 'Y = DCP.SetDY(CntX, CntY, CntZ, Rds, Ht, Flg)       'Second Row Second Column

                        Flg = 4

                        Pt.DStrtPt.z = DGmCpt.ZDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, DHt, Flg)                   'Z = DCP.SetDZ(CntX, CntY, CntZ, Rds, Ht, Flg)

                    End If

                End If

            End If



            X = Pt.DStrtPt.x
            Y = Pt.DStrtPt.y
            Z = Pt.DStrtPt.z

            Dim Dpt As New CDrum

            DmCp.DRds = Rds
            DmCp.DHt = Ht


            Pt.DCntPt.X = X
            Pt.DCntPt.Y = Y
            Pt.DCntPt.Z = Z
            Pt.DCntPt.DHt = DmCp.DHt
            Pt.DCntPt.DRds = DmCp.DRds

            If SS = 0 Then
                'siSW.WriteLine("]}]}]}]}]}")
            End If

            SS += 1

            'If SS = 2000 Then

            'Stop
            'siSW.Close()

            'End If

            Stop

            Dpt.DStrtPt.x = Pt.DCntPt.X
            Dpt.DStrtPt.y = Pt.DCntPt.Y
            Dpt.DStrtPt.z = Pt.DCntPt.Z
            Dpt.DCntPt.DHt = Pt.DCntPt.DHt
            Dpt.DCntPt.DRds = Pt.DCntPt.DRds

            'Public Sub DInCANxt(ByVal Xme As Double, ByVal Yme As Double, ByVal Zme As Double, ByVal Xg As Double, ByVal Yg As Double, ByVal Zg As Double)

            DInCANxt(Xme, Yme, Zme, Dpt.DStrtPt.x, Dpt.DStrtPt.y, Dpt.DStrtPt.z)

            'Stop

            siSW.WriteLine("")

            Try

                DrumGeomCylDHED(Fn, Col, Transpx, Tex, ItmNm, Wt, QtyFlg, TxtOpt, MatName, Method, DataOpt, ShapeOpt, X, Z, Y, Rds)
                DrumRotnCylDHED(Fn)

                siSW.WriteLine("children Shape {")
                siSW.WriteLine("appearance Appearance {")

                DrumTrnspCylDHED(Fn, Transpx, Col)

                Dim Dq As Char = Chr(34)

                If Tex <> "" Then
                    siSW.WriteLine("texture ImageTexture { url " & Dq & Tex & Dq & " }")
                End If

                siSW.WriteLine("}")

                DrumGCylDHED(Fn, New String() {CStr(DmCp.DRds), CStr(DmCp.DHt)})

            Catch Ex As Exception
                MsgBox(Ex.Message)
                MessageBox.Show("Error in AutoDrawDHDDrmSA", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
                connDrums.Close()
                siSW.Close()
            End Try

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MessageBox.Show("Error in AutoDrawDHDDrmSA", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            connDrums.Close()
            siSW.Close()
        End Try

    End Sub

    Public Overloads Sub AutoPlotDrmCA(ByVal Fn As String, ByVal Col As String, ByVal Transpx As Single, ByVal Tex As String, ByVal ItmNm As String, ByVal Wt As Single, ByVal QtyFlg As Boolean, ByVal TxtOpt As Boolean, ByVal MatName As String, ByVal Method As Integer, ByVal DataOpt As Boolean, ByVal ShapeOpt As String, ByVal DDia As Double, ByVal DRds As Double, ByVal DHt As Double)             'Automatic Drawing Drum of Cross Arrangement

        Stop

        Dim DCPt As New CDrum

        Try

            DCPt.DCntPt.X = Me.DStrtPt.x
            DCPt.DCntPt.Y = Me.DStrtPt.y
            DCPt.DCntPt.Z = Me.DStrtPt.z
            DCPt.DHeight = DHt
            DCPt.DRadius = DRds

            Dim Rds As Double = DCPt.DRadius

            Dim PsHt As Double = DpHt
            Dim PsDR As Double = DpRds

            Stop


            'DCA_PullValY(DCPt.DCntPt.X, DCPt.DCntPt.Y, DCPt.DCntPt.Z, DCPt.DHeight, DCPt.DRadius, CL, CW, CH, PsHt, PsDR)


            '*********************************************************************************

            'DCPt.DStrtPt.x = DCPt.DCntPt.X + PsDR

            'Dim val As Double = DCPt.DCntPt.Y - PsDR

            'DCPt.DStrtPt.y = val

            'val = (2 * PsDR) - DCPt.DStrtPt.y

            'DCPt.DStrtPt.y = DCPt.DStrtPt.y + val


            'Dim THt As Double = DCPt.DCntPt.Z + PsDR + PsHt

            'If THt < CH Then
            '    DCPt.DStrtPt.z = DCPt.DCntPt.Z + PsDR
            '    DCPt.DStrtPt.z = DCPt.DStrtPt.z + (DCPt.DHeight / 2)
            'Else
            '    'DCPt.DStrtPt.z = DCPt.DHeight / 2
            '    DCPt.DStrtPt.z = 0
            'End If

            '*********************************************************************************

            '(ByVal _X As Double, ByVal _Y As Double, ByVal _Z As Double, ByVal _CtDHt As Double, ByVal _CtDR As Double, ByVal _CL As Double, ByVal _CW As Double, ByVal _CH As Double, ByVal _PsDHt As Double, ByVal _PsDR As Double) As Double

            '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

            Stop

            'Implements from 11 July 2K8 

            'DCPt.DStrtPt.x = DcaNp.Dpt_X(DCPt.DCntPt.X, DCPt.DCntPt.Y, DCPt.DCntPt.Z, DCPt.DHeight, DCPt.DRadius, CL, CW, CH, PsHt, PsDR)
            'DCPt.DStrtPt.y = DcaNp.Dpt_Y(DCPt.DCntPt.X, DCPt.DCntPt.Y, DCPt.DCntPt.Z, DCPt.DHeight, DCPt.DRadius, CL, CW, CH, PsHt, PsDR)
            'DCPt.DStrtPt.z = DcaNp.Dpt_Z(DCPt.DCntPt.X, DCPt.DCntPt.Y, DCPt.DCntPt.Z, DCPt.DHeight, DCPt.DRadius, CL, CW, CH, PsHt, PsDR)

            Stop

            '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

            'Dim x As Double = DCPt.DStrtPt.x
            'Dim y As Double = DCPt.DStrtPt.y
            'Dim z As Double = DCPt.DStrtPt.z

            'DCPt.DCntPt.X = DCPt.DStrtPt.x
            'DCPt.DCntPt.Y = DCPt.DStrtPt.y
            'DCPt.DCntPt.Z = DCPt.DStrtPt.z

            Stop


            If DCPt.DHeight = DDia Then                'If Ht = Dia Then

                If DCPt.DCntPt.X <> 0 Then                 'If CntX <> 0 Then
                    DCaNR = True                             'Step down to second row
                    'GoTo StpDwnCA
                End If

                If DCPt.DStrtPt.z = 0 Then               'If DCPt.DCntPt.Z = 0 Then                       'If CntZ = 0 Then

                    DcaFlg = 5
                    DCPt.DStrtPt.x = DCAgmPt.XDrumPt(DCPt.DCntPt.X, DCPt.DCntPt.Y, DCPt.DCntPt.Z, DRds, DHt, DcaFlg)

                    DcaFlg = 2
                    DCPt.DStrtPt.y = DCAgmPt.YDrumPt(DCPt.DCntPt.X, DCPt.DCntPt.Y, DCPt.DCntPt.Z, DRds, DHt, DcaFlg)                             'Y = DCG.GetDY(CntX, CntY, CntZ, Rds, Ht, Flg)

                    DcaFlg = 3
                    DCPt.DStrtPt.z = DCAgmPt.ZDrumPt(DCPt.DCntPt.X, DCPt.DCntPt.Y, DCPt.DCntPt.Z, DRds, DHt, DcaFlg)                  'Z = DCG.GetDZ(CntX, CntY, CntZ, Rds, Ht, Flg)       'Rds + CntZ

                ElseIf DCPt.DCntPt.Y = 0 Then                                 'ElseIf CntY = 0 Then

                    DcaFlg = 0
                    DCPt.DStrtPt.x = DCAgmPt.XDrumPt(DCPt.DCntPt.X, DCPt.DCntPt.Y, DCPt.DCntPt.Z, DRds, DHt, DcaFlg)

                    DcaFlg = 0
                    DCPt.DStrtPt.y = DCAgmPt.YDrumPt(DCPt.DCntPt.X, DCPt.DCntPt.Y, DCPt.DCntPt.Z, DRds, DHt, DcaFlg)                             'Y = DCG.GetDY(CntX, CntY, CntZ, Rds, Ht, Flg)

                    DcaFlg = 1
                    DCPt.DStrtPt.z = DCAgmPt.ZDrumPt(DCPt.DCntPt.X, DCPt.DCntPt.Y, DCPt.DCntPt.Z, DRds, DHt, DcaFlg)                  'Z = DCG.GetDZ(CntX, CntY, CntZ, Rds, Ht, Flg)       'Rds + CntZ

                End If
            End If

            Dim DmCp As New CDMidPoint

            DmCp.DRds = DCPt.DRadius
            DmCp.DHt = DCPt.DHeight

            DrumTTGeom(Fn, Col, Transpx, Tex, ItmNm, Wt, QtyFlg, TxtOpt, MatName, Method, DataOpt, ShapeOpt, DCPt.DStrtPt.x, DCPt.DStrtPt.z, DCPt.DStrtPt.y, Rds)
            DrumRotnCylDHED(Fn)

            siSW.WriteLine("children Shape {")
            siSW.WriteLine("appearance Appearance {")

            Stop

            DrumTrnspCylDHED(Fn, Transpx, Col)


            Dim Dq As Char = Chr(34)

            Stop

            If Tex <> "" Then
                siSW.WriteLine("texture ImageTexture { url " & Dq & Tex & Dq & " }")
            End If

            siSW.WriteLine("}")

            'DrumGCylDHED(Fn, New String() {CStr(DmCp.DRds), CStr(DmCp.DHt)})

            GCylCADrm(Fn, New String() {CStr(DmCp.DRds), CStr(DmCp.DHt)})

            Stop

            'siSW.Close()

        Catch Err As Exception
            MsgBox(Err.Message)
            MessageBox.Show("Error in AutoPlotDrmCA", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            siSW.Close()
            ConDrm.Close()
            connDrums.Close()
        End Try

    End Sub

#End Region


    'Public Interface IDrumStuff
    '    Sub DrumStuff(ByVal DArc As CDArea, ByVal DAR() As CDArea, ByVal DAri() As String, ByVal ArWt() As Single, ByVal SaveOpt As Boolean, ByVal ShowEmpty As Boolean, ByVal OutFile As String, ByVal DrawArc As Boolean, ByVal TranspArr() As Boolean, ByVal TopUp() As Boolean, ByVal TxtOpt As Boolean, ByVal DrawOpt As Boolean, ByVal FindQtyFlg As Boolean, ByVal ChngFlg As Boolean, ByVal ColArr As List(Of List(Of Byte))) 'As List(Of CDArea)
    'End Interface

End Class
