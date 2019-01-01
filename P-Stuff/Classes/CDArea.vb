
'Program Name: -    CDArea.vb
'Programmer Name: - Satwadhir B. Pawar Mob No. :- 9323974665
'Company Name:-     Hazel Infotech LTD. Mumbai
'Project Name: -    P Stuff Plus (Container Stuffing)
'Date: -            24 Dec 2K8 10.21 AM (Modified Time)

'Tips: - The code is debugging at that particular dimensions, quantity and sequence.
'        you are decide it the logic happen is correct to that way or its are some 
'        different way the understanding to at your best level is the correct logic 
'        of this particular code block.

'Description: - CDArea is the drum (cylinder) geometry stuffing class which includes length 
'               width height and radious of type double and two instances starting points of
'               CDPoint class and center point of CDMidPoint class. This class contains various 
'               routines and functions to write down the 3D geometry VRML program of drum 
'               geometry stuffing.

#Region " Importing Object "

Imports DistArCntrlFlg

#End Region

Public Class CDArea

#Region " Class Declaration "

    'Class Drum Area included DLength & DWidth as Diameter, Height & Radious

    Public DLengths As Double
    Public DWidth As Double
    Public DHeight As Double
    Public DRadius As Double

    Public DStrtPt As New CDPoint       'Starting point of Drum
    Public DCntPt As New CDMidPoint     'Center Point Of Drum

#End Region

#Region " Routine Definitions "

    Public Sub AutoDrawDrm(ByVal Fn As String, ByVal Col As String, ByVal Transpx As Single, ByVal Tex As String, ByVal ItmNm As String, ByVal Wt As Single, ByVal QtyFlg As Boolean, ByVal TxtOpt As Boolean, ByVal MatName As String, ByVal Method As Integer, ByVal DataOpt As Boolean, ByVal ShapeOpt As String)

        Try

            Dim Dq As Char = Chr(34)

            siSW.WriteLine("Transform {")
            FileClose(1)

            TrnslnDrm(Fn, New String() {CStr(Me.DStrtPt.x), CStr(Me.DStrtPt.y), CStr(Me.DStrtPt.z)})
            siSW.WriteLine("children [")
            siSW.WriteLine("Transform {")
            FileClose(1)

            If ShapeOpt = "B" Then

                TrnslnDrm(Fn, New String() {CStr(Me.DLengths / 2), CStr(Me.DWidth / 2), CStr(Me.DHeight / 2)})
            Else
                TrnslnDrm(Fn, New String() {CStr(Me.DLengths), CStr(Me.DLengths), CStr(Me.DHeight / 2)})
            End If

            siSW.WriteLine("children [")
            FileClose(1)

            If ShapeOpt = "B" Then
                SetPolygonDrm(Fn, New String() {CStr(Me.DLengths), CStr(Me.DWidth), CStr(Me.DHeight)}, ItmNm, Wt, QtyFlg)       'SetPolygon is method to create Box with x y z dimensions

            Else
                '---------------- 
            End If

            siSW.WriteLine("appearance Appearance {")
            If Tex <> "" Then
                siSW.WriteLine("texture ImageTexture {")
                siSW.WriteLine("url " & Dq & Tex & Dq)
                siSW.WriteLine("}")
            End If

            siSW.WriteLine("material Material {")
            FileClose(1)

            TrnspcyDrm(Fn, Transpx, Col)    'Method transp is Diffuser color R G B and Transparancy

            siSW.WriteLine("}")
            siSW.WriteLine("}")

            FileClose(1)
            siSW.WriteLine("]")
            siSW.WriteLine("}")
            siSW.WriteLine("]")
            siSW.WriteLine("}")

            FileClose(1)

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MessageBox.Show("Error in AutoDrawDrm" & vbCrLf & "VRML Programme writting is failure!", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            FileClose(1)

            TransactionsMenu.lblStatus.Visible = False             'Form8.Close()

            'MsgBox("Error in AutoDrawDrm 'AutoDrawDrm'  " & vbCrLf & "Due to an error application exit!...")
            siSW.Close()
            connDrums.Close()
            Application.Exit()
        Finally
            FileClose()
        End Try

        Dim No As Short = 0

        Try
            If DataOpt Then

                If connDrums.State = ConnectionState.Closed Then connDrums.Open()

                Dim Cmd As New OleDb.OleDbCommand
                Cmd.Connection = connDrums
                Cmd.CommandText = "insert into DrumStuffdata values(" & CStr(No) & ",'" & MatName & "'," & CStr(Me.DStrtPt.x) & "," & CStr(Me.DStrtPt.y) & "," & CStr(Me.DStrtPt.z) & "," & CStr(Me.DLengths) & "," & CStr(Me.DWidth) & "," & CStr(Me.DHeight) & "," & CStr(DHt) & "," & CStr(DRds) & "," & CStr(Method) & ",'" & Col & "','" & Tex & "',0)"
                Cmd.ExecuteNonQuery()

                connDrums.Close()

                Dim CmdCADel As New OleDb.OleDbCommand

                If connDrums.State = ConnectionState.Closed Then connDrums.Open()

                CmdCADel.Connection = connDrums
                CmdCADel.CommandText = "delete from DrumStuffCA"
                CmdCADel.ExecuteNonQuery()

                Cmd.Connection = connDrums
                Cmd.CommandText = "insert into DrumStuffCA values(" & CStr(No) & ",'" & MatName & "'," & CStr(Me.DStrtPt.x) & "," & CStr(Me.DStrtPt.y) & "," & CStr(Me.DStrtPt.z) & "," & CStr(Me.DLengths) & "," & CStr(Me.DWidth) & "," & CStr(Me.DHeight) & "," & CStr(DHt) & "," & CStr(DRds) & "," & CStr(Method) & ",'" & Col & "','" & Tex & "',0)"
                Cmd.ExecuteNonQuery()

            End If

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MessageBox.Show("Error in AutoDrawDrm" & vbCrLf & "Data insert connection failure!", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            siSW.Close()
            connDrums.Close()
        End Try

    End Sub

    Public Sub TrnspcyDrm(ByVal fNm As String, ByVal Grd As String, ByVal Col As String)

        Try

            If Col = "r" Then
                siSW.WriteLine("diffuseColor 1 0 0")
            ElseIf Col = "g" Then
                siSW.WriteLine("diffuseColor 0 1 0")
            ElseIf Col = "b" Then
                siSW.WriteLine("diffuseColor 0 0 1")
            ElseIf Col = "m" Then
                siSW.WriteLine("diffuseColor 0 1 1")
            ElseIf Col = "c" Then
                siSW.WriteLine("diffuseColor 1 0 1")
            ElseIf Col = "y" Then
                siSW.WriteLine("diffuseColor 1 1 0")
            Else
                siSW.WriteLine("diffuseColor 1 1 1")
            End If
            siSW.WriteLine("transparency " & Grd)
            siSW.WriteLine("}")

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MessageBox.Show("Error in TrnspcyDrm" & vbCrLf & "Data write connection failure!", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            siSW.Close()
            connDrums.Close()
        End Try

    End Sub

    Public Sub SetPolygonDrm(ByVal fNm As String, ByVal SzArr As String(), ByVal ItmNm As String, ByVal Wt As Single, ByVal QtyFlg As Boolean)

        Dim Dq As Char = Chr(34)

        Static Qty As Integer

        Try
            If QtyFlg Then
                Qty = 1
            End If

            Qty += 1

            siSW.WriteLine("Shape {")
            siSW.WriteLine("geometry Box {")
            siSW.WriteLine("size " & SzArr(0) & " " & SzArr(1) & " " & SzArr(2))
            siSW.WriteLine("}")

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MessageBox.Show("Error in SetPolygonDrm", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub TrnslnDrm(ByVal fn As String, ByVal DStrtPt() As String)

        Try
            siSW.WriteLine("translation " & CStr(DStrtPt(0)) & " " & CStr(DStrtPt(1)) & " " & CStr(DStrtPt(2)))
        Catch Ex As Exception
            MsgBox(Ex.Message)
            MessageBox.Show("Error in TrnslnDrm", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub AutoDrawDrmSADHE(ByVal Fn As String, ByVal Col As String, ByVal Transpx As Single, ByVal Tex As String, ByVal ItmNm As String, ByVal Wt As Single, ByVal QtyFlg As Boolean, ByVal TxtOpt As Boolean, ByVal MatName As String, ByVal Method As Integer, ByVal DataOpt As Boolean, ByVal ShapeOpt As String, ByVal DDia As Double, ByVal DRds As Double, ByVal DHt As Double)          'Auto Draw Drum Simple Arrangement Diameter And Heights Are equal
        'Stop
        Try
            Dim CntX As Double = Me.DStrtPt.x           'Dim CntX As Single = Me.DStrtPt.x
            Dim CntY As Double = Me.DStrtPt.y           'Dim CntY As Single = Me.DStrtPt.y
            Dim CntZ As Double = Me.DStrtPt.z           'Dim CntZ As Single = Me.DStrtPt.z

            Dim Dia As Double = DDia
            Dim Rds As Double = DRds
            Dim Ht As Double = DHt

            '$$$$$ DrumMidPt.DLL Used $$$$$

            Dim X As Double
            Dim Z As Double
            Dim Y As Double
            Dim Flg As Integer

            If Ht = Dia Then

                If CntX <> 0 Then
                    NR = True               'Step down to second row
                    GoTo StepDwn
                End If

                If CntZ = 0 Then

                    Flg = 0

                    X = DCG.GetDX(CntX, CntY, CntZ, Rds, Ht, Flg)       'DmpIR.dll Used

                    Flg = 0

                    Y = DCG.GetDY(CntX, CntY, CntZ, Rds, Ht, Flg)

                    Flg = 0

                    Z = DCG.GetDZ(CntX, CntY, CntZ, Rds, Ht, Flg)       'Rds + CntZ

                ElseIf CntY = 0 Then

                    Flg = 0

                    X = DCG.GetDX(CntX, CntY, CntZ, Rds, Ht, Flg)

                    Flg = 0

                    Y = DCG.GetDY(CntX, CntY, CntZ, Rds, Ht, Flg)

                    Flg = 1

                    Z = DCG.GetDZ(CntX, CntY, CntZ, Rds, Ht, Flg)

                End If

                If CntY <> 0 Then

                    Flg = 3

                    X = DCG.GetDX(CntX, CntY, CntZ, Rds, Ht, Flg)       'DmpIR.dll Used

                    Flg = 0

                    Y = DCG.GetDY(CntX, CntY, CntZ, Rds, Ht, Flg)       'first Row Second Column

                    Flg = 1

                    Z = DCG.GetDZ(CntX, CntY, CntZ, Rds, Ht, Flg)

                End If

                'Implement(Here)

StepDwn:
                If NR Then

                    If CntZ = 0 Then

                        Flg = 0

                        X = DCG.GetDX(CntX, CntY, CntZ, Rds, Ht, Flg)       'DmpIR.dll Used

                        Flg = 3

                        Y = DCG.GetDY(CntX, CntY, CntZ, Rds, Ht, Flg)

                        Flg = 0

                        Z = DCG.GetDZ(CntX, CntY, CntZ, Rds, Ht, Flg)       'Rds + CntZ

                    Else

                        Flg = 0

                        X = DCG.GetDX(CntX, CntY, CntZ, Rds, Ht, Flg)

                        Flg = 3

                        Y = DCG.GetDY(CntX, CntY, CntZ, Rds, Ht, Flg)

                        Flg = 1

                        Z = DCG.GetDZ(CntX, CntY, CntZ, Rds, Ht, Flg)

                    End If

                    If CntY <> 0 Then

                        Flg = 3

                        X = DCG.GetDX(CntX, CntY, CntZ, Rds, Ht, Flg)       'DmpIR.dll Used

                        Flg = 3

                        Y = DCG.GetDY(CntX, CntY, CntZ, Rds, Ht, Flg)       'Second Row Second Column

                        Flg = 1

                        Z = DCG.GetDZ(CntX, CntY, CntZ, Rds, Ht, Flg)

                    End If

                End If

            End If

            'Height and Diameter are different

            If Ht <> Dia Then       '#################################


                If CntZ = 0 AndAlso CntY = 0 Then

                    Flg = 0

                    X = DCP.SetDX(CntX, CntY, CntZ, Rds, Ht, Flg)       'DmpIR.dll Used

                    Flg = 0

                    Y = DCP.SetDY(CntX, CntY, CntZ, Rds, Ht, Flg)

                    Flg = 3

                    Z = DCP.SetDZ(CntX, CntY, CntZ, Rds, Ht, Flg)       'Rds + CntZ

                Else 'If CntY = 0 Then

                    Flg = 0

                    X = DCP.SetDX(CntX, CntY, CntZ, Rds, Ht, Flg)

                    Flg = 0

                    Y = DCP.SetDY(CntX, CntY, CntZ, Rds, Ht, Flg)       'DmpIR.dll Used


                    Flg = 4

                    Z = DCP.SetDZ(CntX, CntY, CntZ, Rds, Ht, Flg)

                End If

                If CntY <> 0 Then

                    Flg = 3

                    X = DCP.SetDX(CntX, CntY, CntZ, Rds, Ht, Flg)       'DmpIR.dll Used

                    Flg = 0

                    Y = DCP.SetDY(CntX, CntY, CntZ, Rds, Ht, Flg)       'first Row Second Column

                    Flg = 1

                    Z = DCP.SetDZ(CntX, CntY, CntZ, Rds, Ht, Flg)

                End If

            End If

            Dim DmCp As New CDMidPoint

            DmCp.DRds = Rds
            DmCp.DHt = Ht

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
                MessageBox.Show("Error in AutoDrawDrmSADHE", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
                connDrums.Close()
                siSW.Close()
            End Try

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MessageBox.Show("Error in AutoDrawDrmSADHE", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            connDrums.Close()
            siSW.Close()
        End Try

    End Sub


#End Region

#Region " Function Definitions "

    Public Function DUnionItrX(ByVal ar As CDArea) As CDArea        'Check the iteratively dimensions of box type like items 

        Dim Arret As New CDArea

        Try
            Arret.DLengths = -1
            Arret.DWidth = -1
            Arret.DHeight = -1

            If ar Is Nothing Then
                Return Nothing
            End If

            If Me.DLengths = ar.DLengths And Me.DWidth = ar.DWidth Then
                If Me.DStrtPt.x = ar.DStrtPt.x AndAlso Me.DStrtPt.y = ar.DStrtPt.y Then

                    If Me.DStrtPt.z = ar.DStrtPt.z + ar.DHeight Then
                        Arret.DLengths = Me.DLengths
                        Arret.DWidth = Me.DWidth
                        Arret.DHeight = Me.DHeight + ar.DHeight
                        Arret.DStrtPt.x = Me.DStrtPt.x
                        Arret.DStrtPt.y = Me.DStrtPt.y
                        Arret.DStrtPt.z = ar.DStrtPt.z
                    End If

                    If ar.DStrtPt.z = Me.DStrtPt.z + Me.DHeight Then
                        Arret.DLengths = Me.DLengths
                        Arret.DWidth = Me.DWidth
                        Arret.DHeight = Me.DHeight + ar.DHeight
                        Arret.DStrtPt.x = Me.DStrtPt.x
                        Arret.DStrtPt.y = Me.DStrtPt.y
                        Arret.DStrtPt.z = Me.DStrtPt.z
                    End If
                End If

            End If

            If Me.DLengths = ar.DLengths And Me.DHeight = ar.DHeight Then

                If Me.DStrtPt.x = ar.DStrtPt.x AndAlso Me.DStrtPt.z = ar.DStrtPt.z Then

                    If Me.DStrtPt.y = ar.DStrtPt.y + ar.DWidth Then
                        Arret.DLengths = Me.DLengths
                        Arret.DWidth = Me.DWidth + ar.DWidth
                        Arret.DHeight = Me.DHeight
                        Arret.DStrtPt.x = Me.DStrtPt.x
                        Arret.DStrtPt.y = ar.DStrtPt.y
                        Arret.DStrtPt.z = Me.DStrtPt.z
                    End If

                    If ar.DStrtPt.y = Me.DStrtPt.y + Me.DWidth Then
                        Arret.DLengths = Me.DLengths
                        Arret.DWidth = Me.DWidth + ar.DWidth
                        Arret.DHeight = Me.DHeight
                        Arret.DStrtPt.x = Me.DStrtPt.x
                        Arret.DStrtPt.y = Me.DStrtPt.y
                        Arret.DStrtPt.z = Me.DStrtPt.z

                    End If

                End If
            End If

            If Me.DWidth = ar.DWidth And Me.DHeight = ar.DHeight Then
                If Me.DStrtPt.y = ar.DStrtPt.y AndAlso Me.DStrtPt.z = ar.DStrtPt.z Then

                    If Me.DStrtPt.x = ar.DStrtPt.x + ar.DLengths Then
                        Arret.DLengths = Me.DLengths + ar.DLengths
                        Arret.DWidth = Me.DWidth
                        Arret.DHeight = Me.DHeight
                        Arret.DStrtPt.x = ar.DStrtPt.x
                        Arret.DStrtPt.y = Me.DStrtPt.y
                        Arret.DStrtPt.z = Me.DStrtPt.z
                    End If

                    If ar.DStrtPt.x = Me.DStrtPt.x + Me.DLengths Then
                        Arret.DLengths = Me.DLengths + ar.DLengths
                        Arret.DWidth = Me.DWidth
                        Arret.DHeight = Me.DHeight
                        Arret.DStrtPt.x = Me.DStrtPt.x
                        Arret.DStrtPt.y = Me.DStrtPt.y
                        Arret.DStrtPt.z = Me.DStrtPt.z

                    End If

                End If
            End If

        Catch Ex As Exception  '18 March 2008 //Modified 17 May 2K8 11.52 PM
            MsgBox(Ex.Message)
            MessageBox.Show("Error in DUnionItrX" & vbCrLf & "VRML Programme writting logic is failure!", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'MsgBox("Exception :: In method 'DUnionItrX'  " & vbCrLf & "VRML Programme writting logic is failure!")
            connDrums.Close()
            siSW.Close()
        End Try

        If Arret.DLengths = -1 Then
            Return Nothing
        Else
            Return Arret
        End If

    End Function

    Public Function DSubtract(ByVal A1 As CDArea) As Queue(Of CDArea)

        Dim Ar As New Queue(Of CDArea)
        Dim Ar1 As New CDArea
        Dim Ar2 As New CDArea
        Dim Ar3 As New CDArea

        A1.DStrtPt.x = Math.Round(A1.DStrtPt.x, 4)
        A1.DStrtPt.y = Math.Round(A1.DStrtPt.y, 4)
        A1.DStrtPt.z = Math.Round(A1.DStrtPt.z, 4)

        A1.DLengths = Math.Round(A1.DLengths, 4)
        A1.DWidth = Math.Round(A1.DWidth, 4)
        A1.DHeight = Math.Round(A1.DHeight, 4)

        If A1.DStrtPt <> Me.DStrtPt Then
            Return Nothing
        End If

        If A1.DLengths > Me.DLengths OrElse A1.DWidth > Me.DWidth OrElse A1.DHeight > Me.DHeight Then
            Return Nothing
        End If

        If A1.DLengths < Me.DLengths Then
            Ar3.DStrtPt.x = Me.DStrtPt.x + A1.DLengths
            Ar3.DStrtPt.y = Me.DStrtPt.y
            Ar3.DStrtPt.z = Me.DStrtPt.z
            Ar3.DLengths = Me.DLengths - A1.DLengths
            Ar3.DWidth = Me.DWidth
            Ar3.DHeight = Me.DHeight
            If Ar3.DIsValid Then
                Ar.Enqueue(Ar3)
            End If
        End If

        If A1.DWidth < Me.DWidth Then
            Ar2.DStrtPt.x = Me.DStrtPt.x
            Ar2.DStrtPt.y = Me.DStrtPt.y + A1.DWidth
            Ar2.DStrtPt.z = Me.DStrtPt.z
            Ar2.DLengths = A1.DLengths
            Ar2.DWidth = Me.DWidth - A1.DWidth
            Ar2.DHeight = Me.DHeight
            If Ar2.DIsValid Then
                Ar.Enqueue(Ar2)
            End If
        End If

        If A1.DHeight < Me.DHeight Then
            Ar1.DLengths = A1.DLengths
            Ar1.DWidth = A1.DWidth
            Ar1.DHeight = Me.DHeight - A1.DHeight
            Ar1.DStrtPt.x = Me.DStrtPt.x
            Ar1.DStrtPt.y = Me.DStrtPt.y

            Ar1.DStrtPt.z = Me.DStrtPt.z + (A1.DHeight)

            If Ar1.DIsValid Then
                Ar.Enqueue(Ar1)
            End If
        End If

        Return Ar

    End Function

    Public Function DIsValid() As Boolean

        If Me.DWidth = 0 OrElse Me.DHeight = 0 OrElse Me.DLengths = 0 Then
            Return False
        Else
            Return True
        End If

    End Function

    Public Function DrumUnionItrXDHE(ByVal ar As CDArea) As CDArea

        Dim Arret As New CDArea

        Try

            Arret.DLengths = -1
            Arret.DWidth = -1
            Arret.DHeight = -1

            If ar Is Nothing Then
                Return Nothing
            End If

            If Me.DLengths = ar.DLengths And Me.DWidth = ar.DWidth Then
                If Me.DStrtPt.x = ar.DStrtPt.x AndAlso Me.DStrtPt.y = ar.DStrtPt.y Then

                    If Me.DStrtPt.z = ar.DStrtPt.z + ar.DHeight Then
                        Arret.DLengths = Me.DLengths
                        Arret.DWidth = Me.DWidth
                        Arret.DHeight = Me.DHeight + ar.DHeight
                        Arret.DStrtPt.x = Me.DStrtPt.x
                        Arret.DStrtPt.y = Me.DStrtPt.y
                        Arret.DStrtPt.z = ar.DStrtPt.z
                    End If

                    If ar.DStrtPt.z = Me.DStrtPt.z + Me.DHeight Then
                        Arret.DLengths = Me.DLengths
                        Arret.DWidth = Me.DWidth
                        Arret.DHeight = Me.DHeight + ar.DHeight
                        Arret.DStrtPt.x = Me.DStrtPt.x
                        Arret.DStrtPt.y = Me.DStrtPt.y
                        Arret.DStrtPt.z = Me.DStrtPt.z
                    End If
                End If

            End If

            If Me.DLengths = ar.DLengths And Me.DHeight = ar.DHeight Then

                If Me.DStrtPt.x = ar.DStrtPt.x AndAlso Me.DStrtPt.z = ar.DStrtPt.z Then

                    If Me.DStrtPt.y = ar.DStrtPt.y + ar.DWidth Then
                        Arret.DLengths = Me.DLengths
                        Arret.DWidth = Me.DWidth + ar.DWidth
                        Arret.DHeight = Me.DHeight
                        Arret.DStrtPt.x = Me.DStrtPt.x
                        Arret.DStrtPt.y = ar.DStrtPt.y
                        Arret.DStrtPt.z = Me.DStrtPt.z
                    End If


                    If ar.DStrtPt.y = Me.DStrtPt.y + Me.DWidth Then
                        Arret.DLengths = Me.DLengths
                        Arret.DWidth = Me.DWidth + ar.DWidth
                        Arret.DHeight = Me.DHeight
                        Arret.DStrtPt.x = Me.DStrtPt.x
                        Arret.DStrtPt.y = Me.DStrtPt.y
                        Arret.DStrtPt.z = Me.DStrtPt.z

                    End If

                End If
            End If

            If Me.DWidth = ar.DWidth And Me.DHeight = ar.DHeight Then
                If Me.DStrtPt.y = ar.DStrtPt.y AndAlso Me.DStrtPt.z = ar.DStrtPt.z Then

                    If Me.DStrtPt.x = ar.DStrtPt.x + ar.DLengths Then
                        Arret.DLengths = Me.DLengths + ar.DLengths
                        Arret.DWidth = Me.DWidth
                        Arret.DHeight = Me.DHeight
                        Arret.DStrtPt.x = ar.DStrtPt.x
                        Arret.DStrtPt.y = Me.DStrtPt.y
                        Arret.DStrtPt.z = Me.DStrtPt.z
                    End If


                    If ar.DStrtPt.x = Me.DStrtPt.x + Me.DLengths Then
                        Arret.DLengths = Me.DLengths + ar.DLengths
                        Arret.DWidth = Me.DWidth
                        Arret.DHeight = Me.DHeight
                        Arret.DStrtPt.x = Me.DStrtPt.x
                        Arret.DStrtPt.y = Me.DStrtPt.y
                        Arret.DStrtPt.z = Me.DStrtPt.z

                    End If

                End If
            End If

        Catch Ex As Exception  '18 March 2008
            MsgBox(Ex.Message)
            MessageBox.Show("Error in DrumUnionItrXDHE", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            connDrums.Close()
            siSW.Close()
            'MsgBox("Exception :: In method 'UnionItrX'  " & vbCrLf & "VRML Programme writting logic is failure!")

        End Try

        If Arret.DLengths = -1 Then
            Return Nothing
        Else
            Return Arret
        End If

    End Function

    Public Function DrumSubtractDHE(ByVal A1 As CDArea) As Queue(Of CDArea)

        Dim Ar As New Queue(Of CDArea)
        Dim Ar1 As New CDArea
        Dim Ar2 As New CDArea
        Dim Ar3 As New CDArea

        Try
            A1.DStrtPt.x = Math.Round(A1.DStrtPt.x, 5)
            A1.DStrtPt.y = Math.Round(A1.DStrtPt.y, 5)
            A1.DStrtPt.z = Math.Round(A1.DStrtPt.z, 5)

            A1.DLengths = Math.Round(A1.DLengths, 5)
            A1.DWidth = Math.Round(A1.DWidth, 5)
            A1.DHeight = Math.Round(A1.DHeight, 5)

            If A1.DStrtPt <> Me.DStrtPt Then
                Return Nothing
            End If

            If A1.DLengths > Me.DLengths OrElse A1.DWidth > Me.DWidth OrElse A1.DHeight > Me.DHeight Then
                Return Nothing
            End If

            If A1.DLengths < Me.DLengths Then
                Ar3.DStrtPt.x = Me.DStrtPt.x + A1.DLengths
                Ar3.DStrtPt.y = Me.DStrtPt.y
                Ar3.DStrtPt.z = Me.DStrtPt.z
                Ar3.DLengths = Me.DLengths - A1.DLengths
                Ar3.DWidth = Me.DWidth
                Ar3.DHeight = Me.DHeight
                If Ar3.DrumIsValidDHE Then
                    Ar.Enqueue(Ar3)
                End If
            End If

            If A1.DWidth < Me.DWidth Then
                Ar2.DStrtPt.x = Me.DStrtPt.x
                Ar2.DStrtPt.y = Me.DStrtPt.y + A1.DWidth
                Ar2.DStrtPt.z = Me.DStrtPt.z
                Ar2.DLengths = A1.DLengths
                Ar2.DWidth = Me.DWidth - A1.DWidth
                Ar2.DHeight = Me.DHeight
                If Ar2.DrumIsValidDHE Then
                    Ar.Enqueue(Ar2)
                End If
            End If

            If A1.DHeight < Me.DHeight Then
                Ar1.DLengths = A1.DLengths
                Ar1.DWidth = A1.DWidth
                Ar1.DHeight = Me.DHeight - A1.DHeight
                Ar1.DStrtPt.x = Me.DStrtPt.x
                Ar1.DStrtPt.y = Me.DStrtPt.y

                Ar1.DStrtPt.z = Me.DStrtPt.z + (A1.DHeight)

                If Ar1.DrumIsValidDHE Then
                    Ar.Enqueue(Ar1)
                End If
            End If

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MessageBox.Show("Error in DrumSubtractDHE", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return Ar

    End Function

    Public Function DrumIsValidDHE() As Boolean

        If Me.DWidth = 0 OrElse Me.DHeight = 0 OrElse Me.DLengths = 0 Then
            Return False
        Else
            Return True
        End If

    End Function

    Public Function DrmSubtractCA(ByVal ALp As CDArea) As Queue(Of CDArea)

        Stop

        Dim Ar As New Queue(Of CDArea)
        Dim Ar1 As New CDArea
        Dim Ar2 As New CDArea
        Dim Ar3 As New CDArea

        Stop

        Dim DsF As AreaControl = New AreaControl()      'Use DcFlgCSP.dll 

        Try
            ALp.DStrtPt.x = Math.Round(ALp.DStrtPt.x, 5)
            ALp.DStrtPt.y = Math.Round(ALp.DStrtPt.y, 5)
            ALp.DStrtPt.z = Math.Round(ALp.DStrtPt.z, 5)

            'If ALp.DStrtPt >= ALp.DStrtPt Then

            Me.DHeight = ALp.DStrtPt.z
            Me.DLengths = ALp.DStrtPt.y
            Me.DWidth = ALp.DStrtPt.x

            'End If

            ALp.DLengths = Math.Round(ALp.DLengths, 5)
            ALp.DWidth = Math.Round(ALp.DWidth, 5)
            ALp.DHeight = Math.Round(ALp.DHeight, 5)

            If ALp.DStrtPt <> ALp.DStrtPt Then
                Return Nothing
            End If


            If ALp.DLengths > Me.DLengths OrElse ALp.DWidth > Me.DWidth OrElse ALp.DHeight > Me.DHeight Then
                Return Nothing
            End If

            If ALp.DLengths < Me.DLengths Then
                Ar3.DStrtPt.x = Me.DStrtPt.x + ALp.DLengths
                Ar3.DStrtPt.y = Me.DStrtPt.y
                Ar3.DStrtPt.z = Me.DStrtPt.z
                Ar3.DLengths = Me.DLengths - ALp.DLengths
                Ar3.DWidth = Me.DWidth
                Ar3.DHeight = Me.DHeight
                If Ar3.DrumIsValidDHE Then
                    Ar.Enqueue(Ar3)
                End If
            End If

            If ALp.DWidth < Me.DWidth Then
                Ar2.DStrtPt.x = Me.DStrtPt.x
                Ar2.DStrtPt.y = Me.DStrtPt.y + ALp.DWidth
                Ar2.DStrtPt.z = Me.DStrtPt.z
                Ar2.DLengths = ALp.DLengths
                Ar2.DWidth = Me.DWidth - ALp.DWidth
                Ar2.DHeight = Me.DHeight
                If Ar2.DrumIsValidDHE Then
                    Ar.Enqueue(Ar2)
                End If
            End If

            If ALp.DHeight < Me.DHeight Then
                Ar1.DLengths = ALp.DLengths
                Ar1.DWidth = ALp.DWidth
                Ar1.DHeight = Me.DHeight - ALp.DHeight
                Ar1.DStrtPt.x = Me.DStrtPt.x
                Ar1.DStrtPt.y = Me.DStrtPt.y

                Ar1.DStrtPt.z = Me.DStrtPt.z + (ALp.DHeight)

                If Ar1.DrumIsValidDHE Then
                    Ar.Enqueue(Ar1)
                End If

            End If

            DsF.MDistCalc = Ar1.DStrtPt.z               'Use DcFlgCSP.dll 
            DsF.DistAdd = DHt
            DsF.DistCSz = CH
            Dim DChk As Int16 = 0
            DChk = DsF.DCntrlFlag()

            If DChk = 1 Then
                Return Nothing
            End If

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MessageBox.Show("Error in DrmSubtractCA", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return Ar

        'Stop

    End Function

    Public Function DrumSubtractDHD(ByVal A1 As CDArea) As Queue(Of CDArea)

        'Stop
        Dim Ar As New Queue(Of CDArea)
        Dim Ar1 As New CDArea
        Dim Ar2 As New CDArea
        Dim Ar3 As New CDArea

        Dim DsF As AreaControl = New AreaControl()      'Use DcFlgCSP.dll 

        Try
            A1.DStrtPt.x = Math.Round(A1.DStrtPt.x, 5)
            A1.DStrtPt.y = Math.Round(A1.DStrtPt.y, 5)
            A1.DStrtPt.z = Math.Round(A1.DStrtPt.z, 5)

            A1.DLengths = Math.Round(A1.DLengths, 5)
            A1.DWidth = Math.Round(A1.DWidth, 5)
            A1.DHeight = Math.Round(A1.DHeight, 5)

            Dim Length As Double = Me.DLengths
            Dim Width As Double = Me.DWidth
            Dim Height As Double = Me.DHeight

            'Stop

            If A1.DStrtPt <> Me.DStrtPt Then
                Return Nothing
            End If

            If A1.DLengths > Me.DLengths OrElse A1.DWidth > Me.DWidth OrElse A1.DHeight > Me.DHeight Then
                Return Nothing
            End If

            If A1.DLengths < Me.DLengths Then
                Ar3.DStrtPt.x = Me.DStrtPt.x + A1.DLengths
                Ar3.DStrtPt.y = Me.DStrtPt.y
                Ar3.DStrtPt.z = Me.DStrtPt.z
                Ar3.DLengths = Me.DLengths - A1.DLengths
                Ar3.DWidth = Me.DWidth
                Ar3.DHeight = Me.DHeight
                If Ar3.DrumIsValidDHE Then
                    Ar.Enqueue(Ar3)
                End If
            End If

            If A1.DWidth < Me.DWidth Then
                Ar2.DStrtPt.x = Me.DStrtPt.x
                Ar2.DStrtPt.y = Me.DStrtPt.y + A1.DWidth
                Ar2.DStrtPt.z = Me.DStrtPt.z
                Ar2.DLengths = A1.DLengths
                Ar2.DWidth = Me.DWidth - A1.DWidth
                Ar2.DHeight = Me.DHeight
                If Ar2.DrumIsValidDHE Then
                    Ar.Enqueue(Ar2)
                End If
            End If

            If A1.DHeight < Me.DHeight Then
                Ar1.DLengths = A1.DLengths
                Ar1.DWidth = A1.DWidth
                Ar1.DHeight = Me.DHeight - A1.DHeight
                Ar1.DStrtPt.x = Me.DStrtPt.x
                Ar1.DStrtPt.y = Me.DStrtPt.y

                Ar1.DStrtPt.z = Me.DStrtPt.z + (A1.DHeight)

                If Ar1.DrumIsValidDHE Then
                    Ar.Enqueue(Ar1)
                End If

            End If

            DsF.MDistCalc = Ar1.DStrtPt.z               'Use DcFlgCSP.dll 
            DsF.DistAdd = DHt
            DsF.DistCSz = CH

            Dim DChk As Int16 = 0
            DChk = DsF.DCntrlFlag()

            If DChk = 1 Then
                Return Nothing
            End If

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MessageBox.Show("Error in DrumSubtractDHD", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Ar
        'Stop

    End Function

    Public Function DHVUnionItrXCANxt(ByVal DAr As CDArea) As CDArea

        'aStop

        Dim Arret As New CDArea

        Try

            Arret.DLengths = -1
            Arret.DWidth = -1
            Arret.DHeight = -1

            If DAr Is Nothing Then
                Return Nothing
            End If

            If Me.DLengths = DAr.DLengths And Me.DWidth = DAr.DWidth Then
                If Me.DStrtPt.x = DAr.DStrtPt.x AndAlso Me.DStrtPt.y = DAr.DStrtPt.y Then

                    If Me.DStrtPt.z = DAr.DStrtPt.z + DAr.DHeight Then
                        Arret.DLengths = Me.DLengths
                        Arret.DWidth = Me.DWidth
                        Arret.DHeight = Me.DHeight + DAr.DHeight
                        Arret.DStrtPt.x = Me.DStrtPt.x
                        Arret.DStrtPt.y = Me.DStrtPt.y
                        Arret.DStrtPt.z = DAr.DStrtPt.z
                    End If

                    If DAr.DStrtPt.z = Me.DStrtPt.z + Me.DHeight Then
                        Arret.DLengths = Me.DLengths
                        Arret.DWidth = Me.DWidth
                        Arret.DHeight = Me.DHeight + DAr.DHeight
                        Arret.DStrtPt.x = Me.DStrtPt.x
                        Arret.DStrtPt.y = Me.DStrtPt.y
                        Arret.DStrtPt.z = Me.DStrtPt.z
                    End If
                End If

            End If

            If Me.DLengths = DAr.DLengths And Me.DHeight = DAr.DHeight Then

                If Me.DStrtPt.x = DAr.DStrtPt.x AndAlso Me.DStrtPt.z = DAr.DStrtPt.z Then

                    If Me.DStrtPt.y = DAr.DStrtPt.y + DAr.DWidth Then
                        Arret.DLengths = Me.DLengths
                        Arret.DWidth = Me.DWidth + DAr.DWidth
                        Arret.DHeight = Me.DHeight
                        Arret.DStrtPt.x = Me.DStrtPt.x
                        Arret.DStrtPt.y = DAr.DStrtPt.y
                        Arret.DStrtPt.z = Me.DStrtPt.z
                    End If

                    If DAr.DStrtPt.y = Me.DStrtPt.y + Me.DWidth Then
                        Arret.DLengths = Me.DLengths
                        Arret.DWidth = Me.DWidth + DAr.DWidth
                        Arret.DHeight = Me.DHeight
                        Arret.DStrtPt.x = Me.DStrtPt.x
                        Arret.DStrtPt.y = Me.DStrtPt.y
                        Arret.DStrtPt.z = Me.DStrtPt.z

                    End If

                End If
            End If

            If Me.DWidth = DAr.DWidth And Me.DHeight = DAr.DHeight Then
                If Me.DStrtPt.y = DAr.DStrtPt.y AndAlso Me.DStrtPt.z = DAr.DStrtPt.z Then

                    If Me.DStrtPt.x = DAr.DStrtPt.x + DAr.DLengths Then
                        Arret.DLengths = Me.DLengths + DAr.DLengths
                        Arret.DWidth = Me.DWidth
                        Arret.DHeight = Me.DHeight
                        Arret.DStrtPt.x = DAr.DStrtPt.x
                        Arret.DStrtPt.y = Me.DStrtPt.y
                        Arret.DStrtPt.z = Me.DStrtPt.z
                    End If

                    If DAr.DStrtPt.x = Me.DStrtPt.x + Me.DLengths Then
                        Arret.DLengths = Me.DLengths + DAr.DLengths
                        Arret.DWidth = Me.DWidth
                        Arret.DHeight = Me.DHeight
                        Arret.DStrtPt.x = Me.DStrtPt.x
                        Arret.DStrtPt.y = Me.DStrtPt.y
                        Arret.DStrtPt.z = Me.DStrtPt.z

                    End If

                End If
            End If

        Catch Ex As Exception  '8 May 2008
            MsgBox(Ex.Message)
            'MessageBox.Show("Error in DHVUnionItrX" & vbCrLf & "VRML Programme writting logic is failure!", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            MessageBox.Show("Error in DHVUnionItrXCANxt", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        If Arret.DLengths = -1 Then
            Return Nothing
        Else
            Return Arret
        End If

    End Function

    Public Function DHVUnionItrX(ByVal ar As CDArea) As CDArea

        'aStop

        Dim Arret As New CDArea

        Try

            Arret.DLengths = -1
            Arret.DWidth = -1
            Arret.DHeight = -1

            If ar Is Nothing Then
                Return Nothing
            End If

            If Me.DLengths = ar.DLengths And Me.DWidth = ar.DWidth Then
                If Me.DStrtPt.x = ar.DStrtPt.x AndAlso Me.DStrtPt.y = ar.DStrtPt.y Then

                    If Me.DStrtPt.z = ar.DStrtPt.z + ar.DHeight Then
                        Arret.DLengths = Me.DLengths
                        Arret.DWidth = Me.DWidth
                        Arret.DHeight = Me.DHeight + ar.DHeight
                        Arret.DStrtPt.x = Me.DStrtPt.x
                        Arret.DStrtPt.y = Me.DStrtPt.y
                        Arret.DStrtPt.z = ar.DStrtPt.z
                    End If

                    If ar.DStrtPt.z = Me.DStrtPt.z + Me.DHeight Then
                        Arret.DLengths = Me.DLengths
                        Arret.DWidth = Me.DWidth
                        Arret.DHeight = Me.DHeight + ar.DHeight
                        Arret.DStrtPt.x = Me.DStrtPt.x
                        Arret.DStrtPt.y = Me.DStrtPt.y
                        Arret.DStrtPt.z = Me.DStrtPt.z
                    End If
                End If

            End If

            If Me.DLengths = ar.DLengths And Me.DHeight = ar.DHeight Then

                If Me.DStrtPt.x = ar.DStrtPt.x AndAlso Me.DStrtPt.z = ar.DStrtPt.z Then

                    If Me.DStrtPt.y = ar.DStrtPt.y + ar.DWidth Then
                        Arret.DLengths = Me.DLengths
                        Arret.DWidth = Me.DWidth + ar.DWidth
                        Arret.DHeight = Me.DHeight
                        Arret.DStrtPt.x = Me.DStrtPt.x
                        Arret.DStrtPt.y = ar.DStrtPt.y
                        Arret.DStrtPt.z = Me.DStrtPt.z
                    End If


                    If ar.DStrtPt.y = Me.DStrtPt.y + Me.DWidth Then
                        Arret.DLengths = Me.DLengths
                        Arret.DWidth = Me.DWidth + ar.DWidth
                        Arret.DHeight = Me.DHeight
                        Arret.DStrtPt.x = Me.DStrtPt.x
                        Arret.DStrtPt.y = Me.DStrtPt.y
                        Arret.DStrtPt.z = Me.DStrtPt.z

                    End If

                End If
            End If

            If Me.DWidth = ar.DWidth And Me.DHeight = ar.DHeight Then
                If Me.DStrtPt.y = ar.DStrtPt.y AndAlso Me.DStrtPt.z = ar.DStrtPt.z Then

                    If Me.DStrtPt.x = ar.DStrtPt.x + ar.DLengths Then
                        Arret.DLengths = Me.DLengths + ar.DLengths
                        Arret.DWidth = Me.DWidth
                        Arret.DHeight = Me.DHeight
                        Arret.DStrtPt.x = ar.DStrtPt.x
                        Arret.DStrtPt.y = Me.DStrtPt.y
                        Arret.DStrtPt.z = Me.DStrtPt.z
                    End If

                    If ar.DStrtPt.x = Me.DStrtPt.x + Me.DLengths Then
                        Arret.DLengths = Me.DLengths + ar.DLengths
                        Arret.DWidth = Me.DWidth
                        Arret.DHeight = Me.DHeight
                        Arret.DStrtPt.x = Me.DStrtPt.x
                        Arret.DStrtPt.y = Me.DStrtPt.y
                        Arret.DStrtPt.z = Me.DStrtPt.z

                    End If

                End If
            End If

        Catch Ex As Exception  '8 May 2008
            MsgBox(Ex.Message)
            MessageBox.Show("Error in DHVUnionItrX" & vbCrLf & "VRML Programme writting logic is failure!", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        If Arret.DLengths = -1 Then
            Return Nothing
        Else
            Return Arret
        End If

    End Function

    Public Function DrmNextIArgStrt(ByVal DrmI As CDArea, ByVal DCRm As CDArea) As Queue(Of CDArea)
        'Stop
        Dim Ar As New Queue(Of CDArea)
        Dim Ar1 As New CDArea
        Dim Ar2 As New CDArea
        Dim Ar3 As New CDArea

        Dim DsF As AreaControl = New AreaControl()      'Use DcFlgCSP.dll 

        Try
            DrmI.DStrtPt.x = Math.Round(DrmI.DStrtPt.x, 5)
            DrmI.DStrtPt.y = Math.Round(DrmI.DStrtPt.y, 5)
            DrmI.DStrtPt.z = Math.Round(DrmI.DStrtPt.z, 5)

            DrmI.DLengths = Math.Round(DrmI.DLengths, 5)
            DrmI.DWidth = Math.Round(DrmI.DWidth, 5)
            DrmI.DHeight = Math.Round(DrmI.DHeight, 5)

            If DrmI.DStrtPt <> Me.DStrtPt Then
                Return Nothing
            End If

            If DrmI.DLengths > Me.DLengths OrElse DrmI.DWidth > Me.DWidth OrElse DrmI.DHeight > Me.DHeight Then
                Return Nothing
            End If

            If DrmI.DStrtPt.x < Me.DLengths Then                    'If DrmI.DLengths < Me.DLengths Then
                Ar3.DStrtPt.x = Me.DStrtPt.x + (DCRm.DWidth / 2)    'Ar3.DStrtPt.x = Me.DStrtPt.x + DrmI.DLengths
                Ar3.DStrtPt.y = Me.DStrtPt.y
                Ar3.DStrtPt.z = Me.DStrtPt.z
                Ar3.DLengths = Me.DStrtPt.y                         'Ar3.DLengths = Me.DLengths - DrmI.DLengths
                Ar3.DWidth = Me.DWidth
                Ar3.DHeight = Me.DHeight
                If Ar3.DrumIsValidDHE Then
                    Ar.Enqueue(Ar3)
                End If
            End If

            If DrmI.DWidth < Me.DWidth Then
                Ar2.DStrtPt.x = Me.DStrtPt.x
                Ar2.DStrtPt.y = Me.DStrtPt.y + DrmI.DWidth
                Ar2.DStrtPt.z = Me.DStrtPt.z
                Ar2.DLengths = DrmI.DLengths
                Ar2.DWidth = Me.DWidth - DrmI.DWidth
                Ar2.DHeight = Me.DHeight
                If Ar2.DrumIsValidDHE Then
                    Ar.Enqueue(Ar2)
                End If
            End If

            If DrmI.DHeight < Me.DHeight Then
                Ar1.DLengths = DrmI.DLengths
                Ar1.DWidth = DrmI.DWidth
                Ar1.DHeight = Me.DHeight - DrmI.DHeight
                Ar1.DStrtPt.x = Me.DStrtPt.x
                Ar1.DStrtPt.y = Me.DStrtPt.y

                Ar1.DStrtPt.z = Me.DStrtPt.z + (DrmI.DHeight)

                If Ar1.DrumIsValidDHE Then
                    Ar.Enqueue(Ar1)
                End If

            End If

            DsF.MDistCalc = Ar1.DStrtPt.z               'Use DcFlgCSP.dll 
            DsF.DistAdd = DHt
            DsF.DistCSz = CH

            Dim DChk As Int16 = 0
            DChk = DsF.DCntrlFlag()

            If DChk = 1 Then
                Return Nothing
            End If

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MessageBox.Show("Error in DrumSubtractDHD", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return Ar

        Stop

    End Function

    Public Sub AutoDrawDrmCANxt(ByVal Fn As String, ByVal Col As String, ByVal Transpx As Single, ByVal Tex As String, ByVal ItmNm As String, ByVal Wt As Single, ByVal QtyFlg As Boolean, ByVal TxtOpt As Boolean, ByVal MatName As String, ByVal Method As Integer, ByVal DataOpt As Boolean, ByVal ShapeOpt As String, ByVal DDia As Double, ByVal DRds As Double, ByVal DHt As Double)             'Automatic Drawing Drum of Cross Arrangement
        'DDStop

        Dim DPt As New CDrum

        Try
            'Dim DCAPt As New CDXArngmt

            'From here impliments 25 June 2008

            'Stop

            DPt.DCntPt.X = Me.DStrtPt.x
            DPt.DCntPt.Y = Me.DStrtPt.y
            DPt.DCntPt.Z = Me.DStrtPt.z
            DPt.DHeight = DHt
            DPt.DRadius = DRds

            _2D = DPt.DRadius * 4       'Up to second row of drum placed

            'SStop

            'siSW.Close()
            'Dim CntX As Single = Me.DStrtPt.x
            'Dim CntY As Single = Me.DStrtPt.y
            'Dim CntZ As Single = Me.DStrtPt.z

            If DPt.DHeight = DDia Then                'If Ht = Dia Then

                If DPt.DCntPt.X <> 0 Then                 'If CntX <> 0 Then
                    DCaNR = True                             'Step down to second row
                    GoTo StpDwnCA
                End If

                If DPt.DCntPt.Z = 0 Then                       'If CntZ = 0 Then

                    DcaFlg = 0
                    DPt.DStrtPt.x = DCAgmPt.XDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)

                    DcaFlg = 0
                    DPt.DStrtPt.y = DCAgmPt.YDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)                             'Y = DCG.GetDY(CntX, CntY, CntZ, Rds, Ht, Flg)

                    DcaFlg = 0
                    DPt.DStrtPt.z = DCAgmPt.ZDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)                  'Z = DCG.GetDZ(CntX, CntY, CntZ, Rds, Ht, Flg)       'Rds + CntZ

                ElseIf DPt.DCntPt.Y = 0 Then                                 'ElseIf CntY = 0 Then

                    DcaFlg = 0
                    DPt.DStrtPt.x = DCAgmPt.XDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)

                    DcaFlg = 0
                    DPt.DStrtPt.y = DCAgmPt.YDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)                             'Y = DCG.GetDY(CntX, CntY, CntZ, Rds, Ht, Flg)

                    DcaFlg = 1
                    DPt.DStrtPt.z = DCAgmPt.ZDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)                  'Z = DCG.GetDZ(CntX, CntY, CntZ, Rds, Ht, Flg)       'Rds + CntZ

                End If

                If DPt.DCntPt.Y <> 0 Then                                    'If CntY <> 0 Then

                    DcaFlg = 3
                    DPt.DStrtPt.x = DCAgmPt.XDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)                    'X = DCG.GetDX(CntX, CntY, CntZ, Rds, Ht, Flg)

                    DcaFlg = 0
                    DPt.DStrtPt.y = DCAgmPt.YDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)                 'Y = DCG.GetDY(CntX, CntY, CntZ, Rds, Ht, Flg)       'first Row Second Column

                    DcaFlg = 1
                    DPt.DStrtPt.z = DCAgmPt.ZDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)                  'Z = DCG.GetDZ(CntX, CntY, CntZ, Rds, Ht, Flg)

                End If

            End If

StpDwnCA:

            If DCaNR Then                                                'If NR Then

                If DPt.DCntPt.Z = 0 Then                                  'If CntZ = 0 Then

                    DcaFlg = 0                                            'Flg = 0
                    DPt.DStrtPt.x = DCAgmPt.XDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)          'X = DCG.GetDX(CntX, CntY, CntZ, Rds, Ht, Flg)

                    DcaFlg = 3
                    DPt.DStrtPt.y = DCAgmPt.YDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)            'Y = DCG.GetDY(CntX, CntY, CntZ, Rds, Ht, Flg)

                    DcaFlg = 0
                    DPt.DStrtPt.z = DCAgmPt.ZDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)         'Z = DCG.GetDZ(CntX, CntY, CntZ, Rds, Ht, Flg)       'Rds + CntZ

                Else

                    DcaFlg = 0
                    DPt.DStrtPt.x = DCAgmPt.XDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)          'X = DCG.GetDX(CntX, CntY, CntZ, Rds, Ht, Flg)

                    DcaFlg = 3
                    DPt.DStrtPt.y = DCAgmPt.YDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)            'Y = DCG.GetDY(CntX, CntY, CntZ, Rds, Ht, Flg)

                    DcaFlg = 1
                    DPt.DStrtPt.z = DCAgmPt.ZDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)         'Z = DCG.GetDZ(CntX, CntY, CntZ, Rds, Ht, Flg)

                End If

                If DPt.DCntPt.Y <> 0 Then                        'If CntY <> 0 Then
                    DcaFlg = 3
                    DPt.DStrtPt.x = DCAgmPt.XDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)          'X = DCG.GetDX(CntX, CntY, CntZ, Rds, Ht, Flg)

                    DcaFlg = 3
                    DPt.DStrtPt.y = DCAgmPt.YDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)            'Y = DCG.GetDY(CntX, CntY, CntZ, Rds, Ht, Flg)       'Second Row Second Column

                    DcaFlg = 1
                    DPt.DStrtPt.z = DCAgmPt.ZDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)         'Z = DCG.GetDZ(CntX, CntY, CntZ, Rds, Ht, Flg)
                End If

            End If

            'Height and Diameter are different

            '***************************************************************##########

            If DPt.DHeight <> DDia Then                          'If Ht <> Dia Then

                If DPt.DCntPt.X <> 0 Then                   'If Pt.DCntPt.X <> 0 Then                  'If CntX <> 0 Then
                    DHDNRDrum = True                        'Step down to second row
                    GoTo DHDStepDwn
                End If

                If DPt.DCntPt.Z = 0 AndAlso DPt.DCntPt.Y = 0 Then               'If Pt.DCntPt.Z = 0 AndAlso Pt.DCntPt.Y = 0 Then

                    DcaFlg = 0                                                                                               'Flg = 0
                    DPt.DStrtPt.x = DCAgmPt.XDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)          'X = DCG.GetDX(CntX, CntY, CntZ, Rds, Ht, Flg)        'X = DGmCpt.XDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                    DcaFlg = 0                                                                                               'Flg = 0
                    DPt.DStrtPt.y = DCAgmPt.YDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)            'Y = DCG.GetDY(CntX, CntY, CntZ, Rds, Ht, Flg)       'Second Row Second Column   'Y = DGmCpt.YDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                    DcaFlg = 3                                                                                               'Flg = 3
                    DPt.DStrtPt.z = DCAgmPt.ZDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)         'Z = DCG.GetDZ(CntX, CntY, CntZ, Rds, Ht, Flg)         'Z = DGmCpt.ZDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                Else

                    DcaFlg = 0                                                                                               'Flg = 0
                    DPt.DStrtPt.x = DCAgmPt.XDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)          'X = DCG.GetDX(CntX, CntY, CntZ, Rds, Ht, Flg)            'X = DGmCpt.XDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                    DcaFlg = 0                                                                                              'Flg = 0
                    DPt.DStrtPt.y = DCAgmPt.YDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)            'Y = DCG.GetDY(CntX, CntY, CntZ, Rds, Ht, Flg)       'Second Row Second Column      'Y = DGmCpt.YDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                    DcaFlg = 4                                                                                              'Flg = 4
                    DPt.DStrtPt.z = DCAgmPt.ZDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)         'Z = DCG.GetDZ(CntX, CntY, CntZ, Rds, Ht, Flg)              'Z = DGmCpt.ZDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                End If

                If DPt.DCntPt.Y <> 0 Then                                                                               'If Pt.DCntPt.Y <> 0 Then

                    DcaFlg = 3                                                                                          'Flg = 3
                    DPt.DStrtPt.x = DCAgmPt.XDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)          'X = DCG.GetDX(CntX, CntY, CntZ, Rds, Ht, Flg)            'X = DGmCpt.XDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                    DcaFlg = 3                                                                                               'Flg = 3
                    DPt.DStrtPt.y = DCAgmPt.YDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)            'Y = DCG.GetDY(CntX, CntY, CntZ, Rds, Ht, Flg)       'Second Row Second Column          'Y = DGmCpt.YDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                    DcaFlg = 4                                                                                              'Flg = 4
                    DPt.DStrtPt.z = DCAgmPt.ZDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)         'Z = DCG.GetDZ(CntX, CntY, CntZ, Rds, Ht, Flg)              'Z = DGmCpt.ZDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                End If

DHDStepDwn:

                'aStop        '9 june 2K8 4.13 PM modified      8 May 2k8 12.33 PM

                If DHDNRDrum Then

                    If DPt.DCntPt.Z = 0 Then                                                                                'If Pt.DCntPt.Z = 0 Then                            'If CntZ = 0 Then

                        DcaFlg = 0                                                                                              'Flg = 0
                        DPt.DStrtPt.x = DCAgmPt.XDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)          'X = DCG.GetDX(CntX, CntY, CntZ, Rds, Ht, Flg)            'X = DGmCpt.XDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)           'X = DCP.SetDX(CntX, CntY, CntZ, Rds, Ht, Flg)       'DmpIR.dll Used

                        DcaFlg = 3                                                                                                  'Flg = 3
                        DPt.DStrtPt.y = DCAgmPt.YDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)            'Y = DCG.GetDY(CntX, CntY, CntZ, Rds, Ht, Flg)       'Second Row Second Column       'Y = DGmCpt.YDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)         'Y = DCP.SetDY(CntX, CntY, CntZ, Rds, Ht, Flg)

                        DcaFlg = 3                                                                                          'Flg = 3
                        DPt.DStrtPt.z = DCAgmPt.ZDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)         'Z = DCG.GetDZ(CntX, CntY, CntZ, Rds, Ht, Flg)          'Z = DGmCpt.ZDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)           'Z = DCP.SetDZ(CntX, CntY, CntZ, Rds, Ht, Flg)       'Rds + CntZ

                    Else

                        DcaFlg = 0                                                                                               'Flg = 0
                        DPt.DStrtPt.x = DCAgmPt.XDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)          'X = DCG.GetDX(CntX, CntY, CntZ, Rds, Ht, Flg)             'X = DGmCpt.XDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)              'X = DCP.SetDX(CntX, CntY, CntZ, Rds, Ht, Flg)

                        DcaFlg = 3                                                                                              'Flg = 3
                        DPt.DStrtPt.y = DCAgmPt.YDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)            'Y = DCG.GetDY(CntX, CntY, CntZ, Rds, Ht, Flg)       'Second Row Second Column      'Y = DGmCpt.YDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)               'Y = DCP.SetDY(CntX, CntY, CntZ, Rds, Ht, Flg)

                        DcaFlg = 4                                                                                               'Flg = 4
                        DPt.DStrtPt.z = DCAgmPt.ZDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)         'Z = DCG.GetDZ(CntX, CntY, CntZ, Rds, Ht, Flg)         'Z = DGmCpt.ZDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)               'Z = DCP.SetDZ(CntX, CntY, CntZ, Rds, Ht, Flg)

                    End If

                    If DPt.DCntPt.Y <> 0 Then                              'If Pt.DCntPt.Y <> 0 Then                                  'If CntY <> 0 Then

                        'aStop modified 9 June 2K8 4.52 PM       '8 May 2k8 1.07 PM

                        DcaFlg = 3                                                                                              'Flg = 3
                        DPt.DStrtPt.x = DCAgmPt.XDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)          'X = DCG.GetDX(CntX, CntY, CntZ, Rds, Ht, Flg)        'X = DGmCpt.XDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)                  'X = DCP.SetDX(CntX, CntY, CntZ, Rds, Ht, Flg)       'DmpIR.dll Used

                        DcaFlg = 3                                                                                               'Flg = 3
                        DPt.DStrtPt.y = DCAgmPt.YDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)            'Y = DCG.GetDY(CntX, CntY, CntZ, Rds, Ht, Flg)       'Second Row Second Column      'Y = DGmCpt.YDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, DHt, Flg)                 'Y = DCP.SetDY(CntX, CntY, CntZ, Rds, Ht, Flg)       'Second Row Second Column

                        DcaFlg = 4                                                                                              'Flg = 4
                        DPt.DStrtPt.z = DCAgmPt.ZDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)         'Z = DCG.GetDZ(CntX, CntY, CntZ, Rds, Ht, Flg)         'Z = DGmCpt.ZDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, DHt, Flg)                   'Z = DCP.SetDZ(CntX, CntY, CntZ, Rds, Ht, Flg)

                    End If

                End If

            End If

            DPt.DCntPt.X = DPt.DStrtPt.x
            DPt.DCntPt.Y = DPt.DStrtPt.y
            DPt.DCntPt.Z = DPt.DStrtPt.z
            DPt.DCntPt.DHt = DPt.DHeight
            DPt.DCntPt.DRds = DPt.DRadius

        Catch Err As Exception
            MsgBox(Err.Message)
            MessageBox.Show("Error in CSP library", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        '***************************************************************##########

        '***********************************************************************************************
        '***********************************************************************************************
        'Inserting the values in the generic database
        '***********************************************************************************************
        'For j As Integer = 0 To Dqty

        '    Ar(UBound(Ar)) = New CDArea
        '    Ar(UBound(Ar)).DLengths = Dln
        '    Ar(UBound(Ar)).DWidth = Dwd
        '    Ar(UBound(Ar)).DHeight = DHt
        '    Ari(UBound(Ari)) = DItmNm1
        '    ArWt(UBound(ArWt)) = Dwt
        '    TranspArr(UBound(TranspArr)) = transp()
        '    TopUp(UBound(TopUp)) = TpUp

        '    ColArr.Add(LstCol)

        'ReDim Preserve Ar(UBound(Ar) + 1)
        'ReDim Preserve Ari(UBound(Ari) + 1)
        'ReDim Preserve ArWt(UBound(ArWt) + 1)
        'ReDim Preserve TranspArr(UBound(TranspArr) + 1)
        'ReDim Preserve TopUp(UBound(TopUp) + 1)
        'Next

        'DDStop

        If ItrQty = 15 Then

            'Stop

            'siSW.Close()

        End If

        Try                  'Cross drum arrangements points stored in that points

            CADimnsAdd(DPt.DStrtPt.x, DPt.DStrtPt.y, DPt.DStrtPt.z, DPt.DHeight, DPt.DRadius)

        Catch ex As Exception
            MsgBox(ex.Message)
            MessageBox.Show("Error in AutoDrawDrmCA", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'DDStop

        '***********************************************************************************************

        DPt.DRadius = DRds        'Dim DmCp As New CDMidPoint

        DPt.DHeight = DHt         'DmCp.DRds = DRds

        'DmCp.DHt = DHt

        If SS = 0 Then
            ''siSW.WriteLine("]}]}]}]}]}")
        End If
        SS += 1

        'siSW.WriteLine("")
        siSW.WriteLine("")
        'siSW.WriteLine("#SS No:- " & SS)
        'siSW.WriteLine("")
        'siSW.WriteLine("")

        Try

            'DDStop

            'siSW.WriteLine("Transform {")

            DCAGeomCyl(Fn, Col, Transpx, Tex, ItmNm, Wt, QtyFlg, TxtOpt, MatName, Method, DataOpt, ShapeOpt, DPt.DStrtPt.x, DPt.DStrtPt.z, DPt.DStrtPt.y, DRds)

            'siSW.Close()
            'connDrums.Close()

            If FlgCA Then
                'Stop
                Exit Sub
            End If

            If flgXAxis Then
                Exit Sub
            End If

            RotnDrm(Fn)

            siSW.WriteLine("children Shape {")
            siSW.WriteLine("appearance Appearance {")

            'Col = "r"
            TrnspDrm(Fn, Transpx, Col)

            Dim Dq As Char = Chr(34)

            If Tex <> "" Then
                siSW.WriteLine("texture ImageTexture { url " & Dq & Tex & Dq & " }")
            End If

            siSW.WriteLine("}")

            GDrmCA(Fn, New String() {CStr(DPt.DRadius), CStr(DPt.DHeight)})         'GCylCA(Fn, New String() {CStr(DmCp.DRds), CStr(DmCp.DHt)})

        Catch Ex As Exception
            siSW.Close()
            connDrums.Close()
            MsgBox(Ex.Message)
            MessageBox.Show("Error in AutoDrawDrmCANxt", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        '******************************************************************************************************

    End Sub

    Public Sub AutoDrawDrmCA(ByVal Fn As String, ByVal Col As String, ByVal Transpx As Single, ByVal Tex As String, ByVal ItmNm As String, ByVal Wt As Single, ByVal QtyFlg As Boolean, ByVal TxtOpt As Boolean, ByVal MatName As String, ByVal Method As Integer, ByVal DataOpt As Boolean, ByVal ShapeOpt As String, ByVal DDia As Double, ByVal DRds As Double, ByVal DHt As Double)             'Automatic Drawing Drum of Cross Arrangement
        'DDStop

        Dim DPt As New CDrum

        Try
            'Dim DCAPt As New CDXArngmt

            'From here impliments 25 June 2008

            'Stop

            DPt.DCntPt.X = Me.DStrtPt.x
            DPt.DCntPt.Y = Me.DStrtPt.y
            DPt.DCntPt.Z = Me.DStrtPt.z
            DPt.DHeight = DHt
            DPt.DRadius = DRds

            _2D = DPt.DRadius * 4       'Up to second row of drum placed

            'SStop

            'siSW.Close()
            'Dim CntX As Single = Me.DStrtPt.x
            'Dim CntY As Single = Me.DStrtPt.y
            'Dim CntZ As Single = Me.DStrtPt.z

            If DPt.DHeight = DDia Then                'If Ht = Dia Then

                If DPt.DCntPt.X <> 0 Then                 'If CntX <> 0 Then
                    DCaNR = True                             'Step down to second row
                    GoTo StpDwnCA
                End If

                If DPt.DCntPt.Z = 0 Then                       'If CntZ = 0 Then

                    DcaFlg = 0
                    DPt.DStrtPt.x = DCAgmPt.XDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)

                    DcaFlg = 0
                    DPt.DStrtPt.y = DCAgmPt.YDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)                             'Y = DCG.GetDY(CntX, CntY, CntZ, Rds, Ht, Flg)

                    DcaFlg = 0
                    DPt.DStrtPt.z = DCAgmPt.ZDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)                  'Z = DCG.GetDZ(CntX, CntY, CntZ, Rds, Ht, Flg)       'Rds + CntZ

                ElseIf DPt.DCntPt.Y = 0 Then                                 'ElseIf CntY = 0 Then

                    DcaFlg = 0
                    DPt.DStrtPt.x = DCAgmPt.XDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)

                    DcaFlg = 0
                    DPt.DStrtPt.y = DCAgmPt.YDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)                             'Y = DCG.GetDY(CntX, CntY, CntZ, Rds, Ht, Flg)

                    DcaFlg = 1
                    DPt.DStrtPt.z = DCAgmPt.ZDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)                  'Z = DCG.GetDZ(CntX, CntY, CntZ, Rds, Ht, Flg)       'Rds + CntZ

                End If

                If DPt.DCntPt.Y <> 0 Then                                    'If CntY <> 0 Then

                    DcaFlg = 3
                    DPt.DStrtPt.x = DCAgmPt.XDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)                    'X = DCG.GetDX(CntX, CntY, CntZ, Rds, Ht, Flg)

                    DcaFlg = 0
                    DPt.DStrtPt.y = DCAgmPt.YDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)                 'Y = DCG.GetDY(CntX, CntY, CntZ, Rds, Ht, Flg)       'first Row Second Column

                    DcaFlg = 1
                    DPt.DStrtPt.z = DCAgmPt.ZDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)                  'Z = DCG.GetDZ(CntX, CntY, CntZ, Rds, Ht, Flg)

                End If

            End If

StpDwnCA:

            If DCaNR Then                                                'If NR Then

                If DPt.DCntPt.Z = 0 Then                                  'If CntZ = 0 Then

                    DcaFlg = 0                                            'Flg = 0
                    DPt.DStrtPt.x = DCAgmPt.XDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)          'X = DCG.GetDX(CntX, CntY, CntZ, Rds, Ht, Flg)

                    DcaFlg = 3
                    DPt.DStrtPt.y = DCAgmPt.YDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)            'Y = DCG.GetDY(CntX, CntY, CntZ, Rds, Ht, Flg)

                    DcaFlg = 0
                    DPt.DStrtPt.z = DCAgmPt.ZDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)         'Z = DCG.GetDZ(CntX, CntY, CntZ, Rds, Ht, Flg)       'Rds + CntZ

                Else

                    DcaFlg = 0
                    DPt.DStrtPt.x = DCAgmPt.XDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)          'X = DCG.GetDX(CntX, CntY, CntZ, Rds, Ht, Flg)

                    DcaFlg = 3
                    DPt.DStrtPt.y = DCAgmPt.YDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)            'Y = DCG.GetDY(CntX, CntY, CntZ, Rds, Ht, Flg)

                    DcaFlg = 1
                    DPt.DStrtPt.z = DCAgmPt.ZDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)         'Z = DCG.GetDZ(CntX, CntY, CntZ, Rds, Ht, Flg)

                End If

                If DPt.DCntPt.Y <> 0 Then                        'If CntY <> 0 Then
                    DcaFlg = 3
                    DPt.DStrtPt.x = DCAgmPt.XDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)          'X = DCG.GetDX(CntX, CntY, CntZ, Rds, Ht, Flg)

                    DcaFlg = 3
                    DPt.DStrtPt.y = DCAgmPt.YDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)            'Y = DCG.GetDY(CntX, CntY, CntZ, Rds, Ht, Flg)       'Second Row Second Column

                    DcaFlg = 1
                    DPt.DStrtPt.z = DCAgmPt.ZDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)         'Z = DCG.GetDZ(CntX, CntY, CntZ, Rds, Ht, Flg)
                End If

            End If

            'Height and Diameter are different

            '***************************************************************##########

            If DPt.DHeight <> DDia Then                          'If Ht <> Dia Then

                If DPt.DCntPt.X <> 0 Then                   'If Pt.DCntPt.X <> 0 Then                  'If CntX <> 0 Then
                    DHDNRDrum = True                        'Step down to second row
                    GoTo DHDStepDwn
                End If

                If DPt.DCntPt.Z = 0 AndAlso DPt.DCntPt.Y = 0 Then               'If Pt.DCntPt.Z = 0 AndAlso Pt.DCntPt.Y = 0 Then

                    DcaFlg = 0                                                                                               'Flg = 0
                    DPt.DStrtPt.x = DCAgmPt.XDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)          'X = DCG.GetDX(CntX, CntY, CntZ, Rds, Ht, Flg)        'X = DGmCpt.XDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                    DcaFlg = 0                                                                                               'Flg = 0
                    DPt.DStrtPt.y = DCAgmPt.YDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)            'Y = DCG.GetDY(CntX, CntY, CntZ, Rds, Ht, Flg)       'Second Row Second Column   'Y = DGmCpt.YDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                    DcaFlg = 3                                                                                               'Flg = 3
                    DPt.DStrtPt.z = DCAgmPt.ZDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)         'Z = DCG.GetDZ(CntX, CntY, CntZ, Rds, Ht, Flg)         'Z = DGmCpt.ZDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                Else

                    DcaFlg = 0                                                                                               'Flg = 0
                    DPt.DStrtPt.x = DCAgmPt.XDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)          'X = DCG.GetDX(CntX, CntY, CntZ, Rds, Ht, Flg)            'X = DGmCpt.XDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                    DcaFlg = 0                                                                                              'Flg = 0
                    DPt.DStrtPt.y = DCAgmPt.YDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)            'Y = DCG.GetDY(CntX, CntY, CntZ, Rds, Ht, Flg)       'Second Row Second Column      'Y = DGmCpt.YDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                    DcaFlg = 4                                                                                              'Flg = 4
                    DPt.DStrtPt.z = DCAgmPt.ZDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)         'Z = DCG.GetDZ(CntX, CntY, CntZ, Rds, Ht, Flg)              'Z = DGmCpt.ZDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                End If

                If DPt.DCntPt.Y <> 0 Then                                                                               'If Pt.DCntPt.Y <> 0 Then

                    DcaFlg = 3                                                                                          'Flg = 3
                    DPt.DStrtPt.x = DCAgmPt.XDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)          'X = DCG.GetDX(CntX, CntY, CntZ, Rds, Ht, Flg)            'X = DGmCpt.XDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                    DcaFlg = 3                                                                                               'Flg = 3
                    DPt.DStrtPt.y = DCAgmPt.YDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)            'Y = DCG.GetDY(CntX, CntY, CntZ, Rds, Ht, Flg)       'Second Row Second Column          'Y = DGmCpt.YDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                    DcaFlg = 4                                                                                              'Flg = 4
                    DPt.DStrtPt.z = DCAgmPt.ZDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)         'Z = DCG.GetDZ(CntX, CntY, CntZ, Rds, Ht, Flg)              'Z = DGmCpt.ZDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)

                End If

DHDStepDwn:

                'aStop        '9 june 2K8 4.13 PM modified      8 May 2k8 12.33 PM

                If DHDNRDrum Then

                    If DPt.DCntPt.Z = 0 Then                                                                                'If Pt.DCntPt.Z = 0 Then                            'If CntZ = 0 Then

                        DcaFlg = 0                                                                                              'Flg = 0
                        DPt.DStrtPt.x = DCAgmPt.XDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)          'X = DCG.GetDX(CntX, CntY, CntZ, Rds, Ht, Flg)            'X = DGmCpt.XDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)           'X = DCP.SetDX(CntX, CntY, CntZ, Rds, Ht, Flg)       'DmpIR.dll Used

                        DcaFlg = 3                                                                                                  'Flg = 3
                        DPt.DStrtPt.y = DCAgmPt.YDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)            'Y = DCG.GetDY(CntX, CntY, CntZ, Rds, Ht, Flg)       'Second Row Second Column       'Y = DGmCpt.YDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)         'Y = DCP.SetDY(CntX, CntY, CntZ, Rds, Ht, Flg)

                        DcaFlg = 3                                                                                          'Flg = 3
                        DPt.DStrtPt.z = DCAgmPt.ZDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)         'Z = DCG.GetDZ(CntX, CntY, CntZ, Rds, Ht, Flg)          'Z = DGmCpt.ZDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)           'Z = DCP.SetDZ(CntX, CntY, CntZ, Rds, Ht, Flg)       'Rds + CntZ

                    Else

                        DcaFlg = 0                                                                                               'Flg = 0
                        DPt.DStrtPt.x = DCAgmPt.XDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)          'X = DCG.GetDX(CntX, CntY, CntZ, Rds, Ht, Flg)             'X = DGmCpt.XDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)              'X = DCP.SetDX(CntX, CntY, CntZ, Rds, Ht, Flg)

                        DcaFlg = 3                                                                                              'Flg = 3
                        DPt.DStrtPt.y = DCAgmPt.YDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)            'Y = DCG.GetDY(CntX, CntY, CntZ, Rds, Ht, Flg)       'Second Row Second Column      'Y = DGmCpt.YDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)               'Y = DCP.SetDY(CntX, CntY, CntZ, Rds, Ht, Flg)

                        DcaFlg = 4                                                                                               'Flg = 4
                        DPt.DStrtPt.z = DCAgmPt.ZDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)         'Z = DCG.GetDZ(CntX, CntY, CntZ, Rds, Ht, Flg)         'Z = DGmCpt.ZDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)               'Z = DCP.SetDZ(CntX, CntY, CntZ, Rds, Ht, Flg)

                    End If

                    If DPt.DCntPt.Y <> 0 Then                              'If Pt.DCntPt.Y <> 0 Then                                  'If CntY <> 0 Then

                        'aStop modified 9 June 2K8 4.52 PM       '8 May 2k8 1.07 PM

                        DcaFlg = 3                                                                                              'Flg = 3
                        DPt.DStrtPt.x = DCAgmPt.XDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)          'X = DCG.GetDX(CntX, CntY, CntZ, Rds, Ht, Flg)        'X = DGmCpt.XDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, Ht, Flg)                  'X = DCP.SetDX(CntX, CntY, CntZ, Rds, Ht, Flg)       'DmpIR.dll Used

                        DcaFlg = 3                                                                                               'Flg = 3
                        DPt.DStrtPt.y = DCAgmPt.YDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)            'Y = DCG.GetDY(CntX, CntY, CntZ, Rds, Ht, Flg)       'Second Row Second Column      'Y = DGmCpt.YDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, DHt, Flg)                 'Y = DCP.SetDY(CntX, CntY, CntZ, Rds, Ht, Flg)       'Second Row Second Column

                        DcaFlg = 4                                                                                              'Flg = 4
                        DPt.DStrtPt.z = DCAgmPt.ZDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)         'Z = DCG.GetDZ(CntX, CntY, CntZ, Rds, Ht, Flg)         'Z = DGmCpt.ZDrum(Pt.DCntPt.X, Pt.DCntPt.Y, Pt.DCntPt.Z, Rds, DHt, Flg)                   'Z = DCP.SetDZ(CntX, CntY, CntZ, Rds, Ht, Flg)

                    End If

                End If

            End If

            DPt.DCntPt.X = DPt.DStrtPt.x
            DPt.DCntPt.Y = DPt.DStrtPt.y
            DPt.DCntPt.Z = DPt.DStrtPt.z
            DPt.DCntPt.DHt = DPt.DHeight
            DPt.DCntPt.DRds = DPt.DRadius

        Catch Err As Exception
            MsgBox(Err.Message)
            MessageBox.Show("Error in CSP library", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        '***************************************************************##########

        '***********************************************************************************************
        '***********************************************************************************************
        'Inserting the values in the generic database
        '***********************************************************************************************
        'For j As Integer = 0 To Dqty

        '    Ar(UBound(Ar)) = New CDArea
        '    Ar(UBound(Ar)).DLengths = Dln
        '    Ar(UBound(Ar)).DWidth = Dwd
        '    Ar(UBound(Ar)).DHeight = DHt
        '    Ari(UBound(Ari)) = DItmNm1
        '    ArWt(UBound(ArWt)) = Dwt
        '    TranspArr(UBound(TranspArr)) = transp()
        '    TopUp(UBound(TopUp)) = TpUp

        '    ColArr.Add(LstCol)

        'ReDim Preserve Ar(UBound(Ar) + 1)
        'ReDim Preserve Ari(UBound(Ari) + 1)
        'ReDim Preserve ArWt(UBound(ArWt) + 1)
        'ReDim Preserve TranspArr(UBound(TranspArr) + 1)
        'ReDim Preserve TopUp(UBound(TopUp) + 1)
        'Next

        'DDStop

        If ItrQty = 15 Then

            'Stop

            'siSW.Close()

        End If



        Try                  'Cross drum arrangements points stored in that points

            CADimnsAdd(DPt.DStrtPt.x, DPt.DStrtPt.y, DPt.DStrtPt.z, DPt.DHeight, DPt.DRadius)

        Catch ex As Exception
            MsgBox(ex.Message)
            MessageBox.Show("Error in AutoDrawDrmCA", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'DDStop

        '***********************************************************************************************

        DPt.DRadius = DRds        'Dim DmCp As New CDMidPoint

        DPt.DHeight = DHt         'DmCp.DRds = DRds

        'DmCp.DHt = DHt

        If SS = 0 Then
            ''siSW.WriteLine("]}]}]}]}]}")
        End If
        SS += 1

        'siSW.WriteLine("")
        siSW.WriteLine("")
        'siSW.WriteLine("#SS No:- " & SS)
        'siSW.WriteLine("")
        'siSW.WriteLine("")

        Try

            'DDStop

            'siSW.WriteLine("Transform {")

            DCAGeomCyl(Fn, Col, Transpx, Tex, ItmNm, Wt, QtyFlg, TxtOpt, MatName, Method, DataOpt, ShapeOpt, DPt.DStrtPt.x, DPt.DStrtPt.z, DPt.DStrtPt.y, DRds)

            'siSW.Close()
            'connDrums.Close()

            If FlgCA Then
                'Stop
                Exit Sub
            End If

            If flgXAxis Then
                Exit Sub
            End If

            RotnDrm(Fn)

            siSW.WriteLine("children Shape {")
            siSW.WriteLine("appearance Appearance {")

            'Col = "r"
            TrnspDrm(Fn, Transpx, Col)

            Dim Dq As Char = Chr(34)

            If Tex <> "" Then
                siSW.WriteLine("texture ImageTexture { url " & Dq & Tex & Dq & " }")
            End If

            siSW.WriteLine("}")

            GDrmCA(Fn, New String() {CStr(DPt.DRadius), CStr(DPt.DHeight)})         'GCylCA(Fn, New String() {CStr(DmCp.DRds), CStr(DmCp.DHt)})

        Catch Ex As Exception
            siSW.Close()
            connDrums.Close()
            MsgBox(Ex.Message)
            MessageBox.Show("Error in AutoDrawDrmCA", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        '******************************************************************************************************

    End Sub

    Public Sub AutoPlotDrmCA(ByVal Fn As String, ByVal Col As String, ByVal Transpx As Single, ByVal Tex As String, ByVal ItmNm As String, ByVal Wt As Single, ByVal QtyFlg As Boolean, ByVal TxtOpt As Boolean, ByVal MatName As String, ByVal Method As Integer, ByVal DataOpt As Boolean, ByVal ShapeOpt As String, ByVal DDia As Double, ByVal DRds As Double, ByVal DHt As Double)             'Automatic Drawing Drum of Cross Arrangement

        Dim DCPt As New CDrum

        Try

            Dim Xpt As Double = Me.DStrtPt.x
            Dim Ypt As Double = Me.DStrtPt.y
            Dim Zpt As Double = Me.DStrtPt.z

            DCPt.DCntPt.X = Me.DStrtPt.x
            DCPt.DCntPt.Y = Me.DStrtPt.y
            DCPt.DCntPt.Z = Me.DStrtPt.z
            DCPt.DHeight = DHt
            DCPt.DRadius = DRds


            Dim D2 As Double = _2D

            Stop
            Dim Val As Double = 0
            Dim Rds As Double = DCPt.DRadius

            Dim Ht As Double = DpHt
            Dim DR As Double = DpRds
            Dim THt As Double = 0

            Stop

            If _2D > DCPt.DCntPt.Y Then

                Stop

                '******************************************************************

                DCPt.DStrtPt.x = DCPt.DCntPt.X + DR

                Val = DCPt.DCntPt.Y - DR

                DCPt.DStrtPt.y = Val

                Val = (2 * DR) - DCPt.DStrtPt.y

                DCPt.DStrtPt.y = DCPt.DStrtPt.y + Val


                THt = DCPt.DCntPt.Z + DR + Ht

                If THt < CH Then
                    DCPt.DStrtPt.x = Xpt - DR
                    DCPt.DStrtPt.z = DCPt.DCntPt.Z + DR
                    'DCPt.DStrtPt.z = DCPt.DStrtPt.z + (DCPt.DHeight / 2)
                Else
                    'DCPt.DStrtPt.z = DCPt.DHeight / 2
                    DCPt.DStrtPt.z = 0
                End If

                '******************************************************************

            Else

                '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&



                MsgBox("Ok Third row placing.....")



                '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

            End If




            DCPt.DCntPt.X = DCPt.DStrtPt.x
            DCPt.DCntPt.Y = DCPt.DStrtPt.y
            DCPt.DCntPt.Z = DCPt.DStrtPt.z


            Stop



            If DCPt.DHeight = DDia Then                'If Ht = Dia Then

                If DCPt.DCntPt.X <> 0 Then                 'If CntX <> 0 Then
                    DCaNR = True                             'Step down to second row
                    GoTo StpDwnCA
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

                Stop

                If DCPt.DCntPt.Y <> 0 Then                          'If DPt.DCntPt.Y <> 0 Then                                    'If CntY <> 0 Then

                    'If THt < CH Then

                    'DcaFlg = 0

                    'DCPt.DStrtPt.x = DCAgmPt.XDrumPt(DCPt.DCntPt.X, DCPt.DCntPt.Y, DCPt.DCntPt.Z, DRds, DHt, DcaFlg)                                             'DPt.DStrtPt.x = DCAgmPt.XDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)                    'X = DCG.GetDX(CntX, CntY, CntZ, Rds, Ht, Flg)

                    'Else

                    DcaFlg = 5

                    DCPt.DStrtPt.x = DCAgmPt.XDrumPt(DCPt.DCntPt.X, DCPt.DCntPt.Y, DCPt.DCntPt.Z, DRds, DHt, DcaFlg)                                             'DPt.DStrtPt.x = DCAgmPt.XDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)                    'X = DCG.GetDX(CntX, CntY, CntZ, Rds, Ht, Flg)

                    'End If

                    DcaFlg = 2
                    DCPt.DStrtPt.y = DCAgmPt.YDrumPt(DCPt.DCntPt.X, DCPt.DCntPt.Y, DCPt.DCntPt.Z, DRds, DHt, DcaFlg)                 'Y = DCG.GetDY(CntX, CntY, CntZ, Rds, Ht, Flg)       'first Row Second Column                               'DPt.DStrtPt.y = DCAgmPt.YDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)                 'Y = DCG.GetDY(CntX, CntY, CntZ, Rds, Ht, Flg)       'first Row Second Column

                    DcaFlg = 1
                    DCPt.DStrtPt.z = DCAgmPt.ZDrumPt(DCPt.DCntPt.X, DCPt.DCntPt.Y, DCPt.DCntPt.Z, DRds, DHt, DcaFlg)                                                  'DPt.DStrtPt.z = DCAgmPt.ZDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)                  'Z = DCG.GetDZ(CntX, CntY, CntZ, Rds, Ht, Flg)

                End If

            End If

            '###################

            'Implements from here 16 July 2K8


StpDwnCA:

            If DCaNR Then                                                'If NR Then

                If DCPt.DCntPt.Z = 0 Then            'If DPt.DCntPt.Z = 0 Then                                  'If CntZ = 0 Then

                    DcaFlg = 0                                            'Flg = 0
                    DCPt.DStrtPt.x = DCAgmPt.XDrumPt(DCPt.DCntPt.X, DCPt.DCntPt.Y, DCPt.DCntPt.Z, DRds, DHt, DcaFlg)          'DPt.DStrtPt.x = DCAgmPt.XDrumPt(DPt.DCntPt.X, DPt.DCntPt.Y, DPt.DCntPt.Z, DRds, DHt, DcaFlg)          'X = DCG.GetDX(CntX, CntY, CntZ, Rds, Ht, Flg)

                    DcaFlg = 3
                    DCPt.DStrtPt.y = DCAgmPt.YDrumPt(DCPt.DCntPt.X, DCPt.DCntPt.Y, DCPt.DCntPt.Z, DRds, DHt, DcaFlg)            'Y = DCG.GetDY(CntX, CntY, CntZ, Rds, Ht, Flg)

                    DcaFlg = 0
                    DCPt.DStrtPt.z = DCAgmPt.ZDrumPt(DCPt.DCntPt.X, DCPt.DCntPt.Y, DCPt.DCntPt.Z, DRds, DHt, DcaFlg)         'Z = DCG.GetDZ(CntX, CntY, CntZ, Rds, Ht, Flg)       'Rds + CntZ

                Else

                    DcaFlg = 0
                    DCPt.DStrtPt.x = DCAgmPt.XDrumPt(DCPt.DCntPt.X, DCPt.DCntPt.Y, DCPt.DCntPt.Z, DRds, DHt, DcaFlg)          'X = DCG.GetDX(CntX, CntY, CntZ, Rds, Ht, Flg)

                    DcaFlg = 3
                    DCPt.DStrtPt.y = DCAgmPt.YDrumPt(DCPt.DCntPt.X, DCPt.DCntPt.Y, DCPt.DCntPt.Z, DRds, DHt, DcaFlg)            'Y = DCG.GetDY(CntX, CntY, CntZ, Rds, Ht, Flg)

                    DcaFlg = 1
                    DCPt.DStrtPt.z = DCAgmPt.ZDrumPt(DCPt.DCntPt.X, DCPt.DCntPt.Y, DCPt.DCntPt.Z, DRds, DHt, DcaFlg)         'Z = DCG.GetDZ(CntX, CntY, CntZ, Rds, Ht, Flg)

                End If

                If DCPt.DCntPt.Y <> 0 Then                        'If CntY <> 0 Then

                    DcaFlg = 5
                    DCPt.DStrtPt.x = DCAgmPt.XDrumPt(DCPt.DCntPt.X, DCPt.DCntPt.Y, DCPt.DCntPt.Z, DRds, DHt, DcaFlg)          'X = DCG.GetDX(CntX, CntY, CntZ, Rds, Ht, Flg)

                    DcaFlg = 2
                    DCPt.DStrtPt.y = DCAgmPt.YDrumPt(DCPt.DCntPt.X, DCPt.DCntPt.Y, DCPt.DCntPt.Z, DRds, DHt, DcaFlg)            'Y = DCG.GetDY(CntX, CntY, CntZ, Rds, Ht, Flg)       'Second Row Second Column

                    DcaFlg = 1
                    DCPt.DStrtPt.z = DCAgmPt.ZDrumPt(DCPt.DCntPt.X, DCPt.DCntPt.Y, DCPt.DCntPt.Z, DRds, DHt, DcaFlg)         'Z = DCG.GetDZ(CntX, CntY, CntZ, Rds, Ht, Flg)

                End If

            End If

            'Height and Diameter are different

            '###################








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

            DrumGCylDHED(Fn, New String() {CStr(DmCp.DRds), CStr(DmCp.DHt)})

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

    Public Function DrumSubtractDHDCA(ByVal A1 As CDArea) As Queue(Of CDArea)
        'Stop
        Dim Ar As New Queue(Of CDArea)
        Dim Ar1 As New CDArea
        Dim Ar2 As New CDArea
        Dim Ar3 As New CDArea

        'Dim DsF As AreaControl = New AreaControl()      'Use DcFlgCSP.dll 

        Try
            A1.DStrtPt.x = Math.Round(A1.DStrtPt.x, 5)
            A1.DStrtPt.y = Math.Round(A1.DStrtPt.y, 5)
            A1.DStrtPt.z = Math.Round(A1.DStrtPt.z, 5)

            A1.DLengths = Math.Round(A1.DLengths, 5)
            A1.DWidth = Math.Round(A1.DWidth, 5)
            A1.DHeight = Math.Round(A1.DHeight, 5)

            If A1.DStrtPt <> Me.DStrtPt Then
                Return Nothing
            End If

            'Me.DLengths = 197
            'Me.DWidth = 48
            'Me.DHeight = 94

            If A1.DLengths > Me.DLengths OrElse A1.DWidth > Me.DWidth OrElse A1.DHeight > Me.DHeight Then
                Return Nothing
            End If

            If A1.DLengths < Me.DLengths Then
                Ar3.DStrtPt.x = Me.DStrtPt.x + A1.DLengths
                Ar3.DStrtPt.y = Me.DStrtPt.y
                Ar3.DStrtPt.z = Me.DStrtPt.z
                Ar3.DLengths = Me.DLengths - A1.DLengths
                Ar3.DWidth = Me.DWidth
                Ar3.DHeight = Me.DHeight
                If Ar3.DrumIsValidDHE Then
                    Ar.Enqueue(Ar3)
                End If
            End If

            If A1.DWidth < Me.DWidth Then
                Ar2.DStrtPt.x = Me.DStrtPt.x
                Ar2.DStrtPt.y = Me.DStrtPt.y + A1.DWidth
                Ar2.DStrtPt.z = Me.DStrtPt.z
                Ar2.DLengths = A1.DLengths
                Ar2.DWidth = Me.DWidth - A1.DWidth
                Ar2.DHeight = Me.DHeight
                If Ar2.DrumIsValidDHE Then
                    Ar.Enqueue(Ar2)
                End If
            End If

            If A1.DHeight < Me.DHeight Then
                Ar1.DLengths = A1.DLengths
                Ar1.DWidth = A1.DWidth
                Ar1.DHeight = Me.DHeight - A1.DHeight
                Ar1.DStrtPt.x = Me.DStrtPt.x
                Ar1.DStrtPt.y = Me.DStrtPt.y

                Ar1.DStrtPt.z = Me.DStrtPt.z + (A1.DHeight)

                If Ar1.DrumIsValidDHE Then
                    Ar.Enqueue(Ar1)
                End If

            End If

            'DsF.MDistCalc = Ar1.DStrtPt.z               'Use DcFlgCSP.dll 
            'DsF.DistAdd = DHt
            'DsF.DistCSz = CH

            'Dim DChk As Int16 = 0
            'DChk = DsF.DCntrlFlag()

            'If DChk = 1 Then
            '    Return Nothing
            'End If

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MessageBox.Show("Error in DrumSubtractDHD", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return Ar

        'Stop

    End Function

    Public Function BridgeED(ByVal DrmI As CDArea, ByVal DRdm As CDArea) As Queue(Of CDArea)

        Stop

        Dim Ar As New Queue(Of CDArea)
        Dim Ar0 As New CDArea
        Dim Ar1 As New CDArea
        Dim Ar2 As New CDArea

        Dim DsF As AreaControl = New AreaControl()      'Use DcFlgCSP.dll 

        Try
            DrmI.DStrtPt.x = Math.Round(DrmI.DStrtPt.x, 5)
            DrmI.DStrtPt.y = Math.Round(DrmI.DStrtPt.y, 5)
            DrmI.DStrtPt.z = Math.Round(DrmI.DStrtPt.z, 5)

            DrmI.DLengths = Math.Round(DrmI.DLengths, 5)
            DrmI.DWidth = Math.Round(DrmI.DWidth, 5)
            DrmI.DHeight = Math.Round(DrmI.DHeight, 5)

            DRdm.DStrtPt.x = Math.Round(DRdm.DStrtPt.x, 5)
            DRdm.DStrtPt.y = Math.Round(DRdm.DStrtPt.y, 5)
            DRdm.DStrtPt.z = Math.Round(DRdm.DStrtPt.z, 5)

            DRdm.DLengths = Math.Round(DRdm.DLengths, 5)
            DRdm.DWidth = Math.Round(DRdm.DWidth, 5)
            DRdm.DHeight = Math.Round(DRdm.DHeight, 5)

            Stop

            If DrmI.DStrtPt <> Me.DStrtPt Then
                Return Nothing
            End If

            If DrmI.DLengths > Me.DLengths OrElse DrmI.DWidth > Me.DWidth OrElse DrmI.DHeight > Me.DHeight Then
                Return Nothing
            End If

            If DrmI.DStrtPt.x < Me.DLengths Then                    'If DrmI.DLengths < Me.DLengths Then
                Ar2.DStrtPt.x = Me.DStrtPt.x + (DRdm.DWidth / 2)    'Ar3.DStrtPt.x = Me.DStrtPt.x + DrmI.DLengths
                Ar2.DStrtPt.y = Me.DStrtPt.y
                Ar2.DStrtPt.z = Me.DStrtPt.z
                Ar2.DLengths = Me.DStrtPt.y                         'Ar3.DLengths = Me.DLengths - DrmI.DLengths
                Ar2.DWidth = Me.DWidth
                Ar2.DHeight = Me.DHeight
                If Ar2.DrumIsValidDHE Then
                    Ar.Enqueue(Ar2)
                End If
            End If

            If DrmI.DWidth < Me.DWidth Then
                Ar1.DStrtPt.x = Me.DStrtPt.x
                Ar1.DStrtPt.y = Me.DStrtPt.y + DrmI.DWidth
                Ar1.DStrtPt.z = Me.DStrtPt.z
                Ar1.DLengths = DrmI.DLengths
                Ar1.DWidth = Me.DWidth - DrmI.DWidth
                Ar1.DHeight = Me.DHeight
                If Ar1.DrumIsValidDHE Then
                    Ar.Enqueue(Ar1)
                End If
            End If

            If DrmI.DHeight < Me.DHeight Then
                Ar0.DLengths = DrmI.DLengths
                Ar0.DWidth = DrmI.DWidth
                Ar0.DHeight = Me.DHeight - DrmI.DHeight
                Ar0.DStrtPt.x = Me.DStrtPt.x
                Ar0.DStrtPt.y = Me.DStrtPt.y

                Ar0.DStrtPt.z = Me.DStrtPt.z + (DrmI.DHeight)

                If Ar0.DrumIsValidDHE Then
                    Ar.Enqueue(Ar0)
                End If

            End If

            DsF.MDistCalc = Ar1.DStrtPt.z               'Use DcFlgCSP.dll 
            DsF.DistAdd = DHt
            DsF.DistCSz = CH

            Dim DChk As Int16 = 0
            DChk = DsF.DCntrlFlag()

            If DChk = 1 Then
                Return Nothing
            End If

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MessageBox.Show("Error in BridgeED", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return Ar

        Stop

    End Function

#End Region

End Class
