
'Program Name: -    DrumWriteFileMdl.vb
'Programmer Name: - Satwadhir B. Pawar Mob No. :- 9323974665
'Company Name:-     Hazel Infotech LTD. Mumbai
'Project Name: -    P-Stuff Plus (Container Stuffing)
'Date: -            23 Dec 2K8 5.15 PM (Modified Time)

'Tips: - The code is debugging at that particular dimensions, quantity and sequence.
'        you are decide it the logic happen is correct to that way or its are some 
'        different way the understanding to at your best level is the correct logic 
'        of this particular code block.

'Description: - DrumWriteFileMdl is the module in this project to write the First.wrl
'               file output which containing the drum (cylinder) geometry VRML program 
'               to utilizing the various routines and functions manipulation output.

#Region "Importing Object "

Imports CSPContnr       'CSPContnr.dll used here
Imports DrmCrossArgmt   'DgmPtCAlt.dll used here

#End Region

Module DrumWriteFileMdl

#Region " Module Declaration "

    Public DCAgmPt As New DrmGMCord()           'DgmPtCAlt.dll used here
    Friend DrumFileOP As String = Nothing       'The Drum File Paths Saved
    Public DcaFlg As Int16                      'Drum cross arrangement flag
    Friend DCntCA As New CDMidPoint             'Cross drum middle point
    Public DXA As New CDArngmtCA                 'Cross arrangement database stored instance

    Public DrmReptSgn As Boolean = False        'Repeat drum avoided
    Public Xlmt As Double
    Public Ylmt As Double
    Public TotYdrct As Double
    Public CANxtFlg As Boolean = False       'Next Cross arangement Flag used
    Public DrmQtysr As Integer         'Quantity for single row in transaction menu call
    Public ItrQty As Integer = 0

    Public LstDxA As List(Of CDArngmtCA)

    Public SN As Short = 1      'Drum insert arrangement

    Public DCaNR As Boolean = False    'Drum cross arrangement flag

#End Region

#Region " Function Definition "

    Friend Function WrVrmlDrmContnrStrt(ByVal KillFile As Boolean, ByVal fNm As String, ByVal Pt As CDPoint)

        Try
            Dim fileExists As Boolean
            Dim Dq As Char = Chr(34)

            Dim CSP As Satwa = New Satwa            'CSPContnr.dll used here

            fileExists = My.Computer.FileSystem.FileExists(fNm)

            If fileExists And KillFile Then
                Kill(fNm)
            End If

            siSW = New IO.StreamWriter(fNm)          'FileOpen(1, fn, OpenMode.Append)

            siSW.WriteLine("#VRML V2.0 utf8")
            siSW.WriteLine("")
            siSW.WriteLine("#START DRUM_STUFF PROGRAMME")
            siSW.WriteLine("")
            siSW.WriteLine("Background {")
            siSW.WriteLine("skyColor 1 1 1")

            siSW.WriteLine("}")

            siSW.WriteLine("Transform {")
            siSW.WriteLine("rotation 1 0 0 -1.570796327")
            siSW.WriteLine("children [")

            siSW.WriteLine("Transform {")
            siSW.WriteLine("rotation 1 0 0 -3.141592654")
            siSW.WriteLine("children [")

            siSW.WriteLine("Transform {")
            siSW.WriteLine("rotation 0 0 1 3.141592654")
            siSW.WriteLine("children [")

            siSW.WriteLine("Transform {")
            siSW.WriteLine("rotation 1 0 0 3.141592654")
            siSW.WriteLine("children [")

            siSW.WriteLine("Transform {")
            siSW.WriteLine("rotation 0 0 1 -1.570796327")
            siSW.WriteLine("children [")

            siSW.WriteLine("Transform {")
            siSW.WriteLine("rotation 1 0 0 -1.570796327")
            siSW.WriteLine("children [")

            Dim Mom As Single = Pt.z

            Pt.z = Pt.y
            Pt.y = -Mom

            siSW.WriteLine("Transform {")
            siSW.WriteLine("rotation 0 0 1 3.141592654")
            siSW.WriteLine("children [")

            Pt.x = -Pt.x
            Pt.y = -Pt.y

            siSW.WriteLine("Transform {")

            CSP.cX = Pt.x           'CSPContnr.dll used here
            CSP.cZ = Pt.z

            'Dim Diagnl As Single = CSP.Diagonal()

            'Dim Dlg As Single = ((Pt.x ^ 2) + (Pt.z ^ 2)) ^ 0.5

            Dim Dlg As Single = CSP.Diagonal()      'CSPContnr.dll used here

            Dim OldPtz As Single = Pt.z

            CSP.cX = Pt.x       'CSPContnr.dll used here
            CSP.Dngl = Dlg

            'Dim Z As Double = CSP.Z_Point()
            'Pt.z = Pt.x / (Pt.x / Dlg)

            Pt.z = CSP.Z_Point()        'CSPContnr.dll used here

            siSW.WriteLine("rotation 0 1 0 -" & CStr(Math.Acos(OldPtz / Dlg) / 2))
            siSW.WriteLine("children [")

            'Pt.z = Pt.z * 1.5
            'Pt.x = Pt.x * 0.5

            'Pt.y = Pt.y / 2

            CSP.cZ = Pt.z                   'CSPContnr.dll used here
            CSP.cX = Pt.x
            CSP.cY = Pt.y

            'Dim Z As Double = CSP.Z_Pt()
            'Dim X As Double = CSP.X_Pt()
            'Dim Y As Double = CSP.Y_Pt()

            Pt.z = CSP.Z_Pt()               'CSPContnr.dll used here
            Pt.x = CSP.X_Pt()
            Pt.y = CSP.Y_Pt()

            siSW.WriteLine("Viewpoint {")
            siSW.WriteLine("position " & Pt.x & " " & Pt.y & " " & Pt.z)

            Dim x1 As Single = Pt.x
            Dim y1 As Single = Pt.y
            Dim z1 As Single = Pt.z

            CSP.cX = Pt.x       'CSPContnr.dll used here
            CSP.cZ = Pt.y

            'Dim DigLngth As Single = ((Pt.x ^ 2) + (Pt.y ^ 2)) ^ 0.5

            Dim DigLngth As Single = CSP.Diagonal()     'CSPContnr.dll used here

            CSP.cX = Pt.x
            CSP.Dngl = DigLngth                     'CSPContnr.dll used here
            Dim Ang As Single = CSP.AnglTan()       'Dim Ang As Single = Math.Atan(Pt.x / DigLngth)

            siSW.WriteLine("description " & Dq & "a" & Dq)

            siSW.WriteLine("}")
            siSW.WriteLine("]}")

            siSW.WriteLine("]}")
            siSW.WriteLine("]}")

            siSW.WriteLine("Transform {")
            siSW.WriteLine("rotation 1 0 0 -1.570796327")
            siSW.WriteLine("children [")

            Mom = Pt.z
            Pt.z = Pt.y
            Pt.y = -Mom

            siSW.WriteLine("Transform {")
            siSW.WriteLine("rotation 0 0 1 3.141592654")
            siSW.WriteLine("children [")

            Pt.x = -Pt.x * 1.5
            Pt.y = -Pt.y * 0.15

            siSW.WriteLine("Transform {")

            CSP.cX = -Pt.x
            CSP.cZ = -Pt.z              'CSPContnr.dll used here

            Dlg = CSP.Diagonal()

            'Dlg = ((Pt.x ^ 2) + (Pt.z ^ 2)) ^ 0.5
            OldPtz = Pt.z

            CSP.cX = Pt.x
            CSP.Dngl = Dlg              'CSPContnr.dll used here
            Pt.z = CSP.Z_Point()

            'Pt.z = Pt.x / (Pt.x / Dlg)

            CSP.cZ = OldPtz
            CSP.Dngl = Dlg                      'CSPContnr.dll used here

            Dim sFac As Single = CSP.sFactor()       'Dim sFac As Single = 2.3 / Math.Acos(OldPtz / Dlg)

            siSW.WriteLine("rotation 0 1 0 -" & CStr(Math.Acos(OldPtz / Dlg) * sFac))
            siSW.WriteLine("children [")

            Pt.z = Pt.z * 2
            Pt.x = Pt.x * 0.5

            siSW.WriteLine("Viewpoint {")
            siSW.WriteLine("position " & Pt.x & " " & Pt.y & " " & Pt.z)

            CSP.cX = Pt.x
            CSP.cZ = Pt.y                       'CSPContnr.dll used here

            DigLngth = CSP.Diagonal()

            'DigLngth = ((Pt.x ^ 2) + (Pt.y ^ 2)) ^ 0.5
            CSP.cX = Pt.x
            CSP.Dngl = DigLngth

            Ang = CSP.AnglTan()

            'Ang = Math.Atan(Pt.x / DigLngth)

            siSW.WriteLine("description " & Dq & "b" & Dq)

            siSW.WriteLine("}")
            siSW.WriteLine("]}")

            siSW.WriteLine("]}")
            siSW.WriteLine("]}")

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in WrVrmlStrt " & vbCrLf & "VRML Programme writting is failure!", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            siSW.Close()
            Return Nothing
            Exit Function
        End Try
        Return Nothing

    End Function

    Friend Function WrVrmlDrmContnrStrt(ByVal fNm As String, ByVal KillFile As Boolean, ByVal Pt As CDrum)

        Try
            Dim fileExists As Boolean
            Dim Dq As Char = Chr(34)

            Dim CSP As Satwa = New Satwa            'CSPContnr.dll used here

            fileExists = My.Computer.FileSystem.FileExists(fNm)

            If fileExists And KillFile Then
                Kill(fNm)
            End If

            siSW = New IO.StreamWriter(fNm)          'FileOpen(1, fn, OpenMode.Append)

            siSW.WriteLine("#VRML V2.0 utf8")
            siSW.WriteLine("")
            siSW.WriteLine("#START DRUM_STUFF PROGRAMME")
            siSW.WriteLine("")
            siSW.WriteLine("Background {")
            siSW.WriteLine("skyColor 1 1 1")

            siSW.WriteLine("}")

            siSW.WriteLine("Transform {")
            siSW.WriteLine("rotation 1 0 0 -1.570796327")
            siSW.WriteLine("children [")

            siSW.WriteLine("Transform {")
            siSW.WriteLine("rotation 1 0 0 -3.141592654")
            siSW.WriteLine("children [")

            siSW.WriteLine("Transform {")
            siSW.WriteLine("rotation 0 0 1 3.141592654")
            siSW.WriteLine("children [")

            siSW.WriteLine("Transform {")
            siSW.WriteLine("rotation 1 0 0 3.141592654")
            siSW.WriteLine("children [")

            siSW.WriteLine("Transform {")
            siSW.WriteLine("rotation 0 0 1 -1.570796327")
            siSW.WriteLine("children [")

            siSW.WriteLine("Transform {")
            siSW.WriteLine("rotation 1 0 0 -1.570796327")
            siSW.WriteLine("children [")

            Dim Mom As Single = Pt.DStrtPt.z           'Dim Mom As Single = Pt.z

            Pt.DStrtPt.z = Pt.DStrtPt.y                 'Pt.z = Pt.y

            Pt.DStrtPt.z = -Mom                         'Pt.y = -Mom

            siSW.WriteLine("Transform {")
            siSW.WriteLine("rotation 0 0 1 3.141592654")
            siSW.WriteLine("children [")

            Pt.DStrtPt.x = -Pt.DStrtPt.x                'Pt.x = -Pt.x
            Pt.DStrtPt.y = -Pt.DStrtPt.y               'Pt.y = -Pt.y

            siSW.WriteLine("Transform {")

            CSP.cX = Pt.DStrtPt.x                'CSP.cX = Pt.x           'CSPContnr.dll used here
            CSP.cZ = Pt.DStrtPt.z                 'CSP.cZ = Pt.z

            'Dim Diagnl As Single = CSP.Diagonal()

            'Dim Dlg As Single = ((Pt.x ^ 2) + (Pt.z ^ 2)) ^ 0.5

            Dim Dlg As Single = CSP.Diagonal()      'CSPContnr.dll used here

            Dim OldPtz As Single = Pt.DStrtPt.z     'Dim OldPtz As Single = Pt.z

            CSP.cX = Pt.DStrtPt.x                   'CSP.cX = Pt.x       'CSPContnr.dll used here
            CSP.Dngl = Dlg

            'Dim Z As Double = CSP.Z_Point()
            'Pt.z = Pt.x / (Pt.x / Dlg)

            Pt.DStrtPt.z = CSP.Z_Point              'Pt.z = CSP.Z_Point()        'CSPContnr.dll used here

            siSW.WriteLine("rotation 0 1 0 -" & CStr(Math.Acos(OldPtz / Dlg) / 2))
            siSW.WriteLine("children [")

            'Pt.z = Pt.z * 1.5
            'Pt.x = Pt.x * 0.5

            'Pt.y = Pt.y / 2

            CSP.cZ = Pt.DStrtPt.z                'CSP.cZ = Pt.z                   'CSPContnr.dll used here
            CSP.cX = Pt.DStrtPt.x                'CSP.cX = Pt.x
            CSP.cY = Pt.DStrtPt.y                'CSP.cY = Pt.y

            Pt.DStrtPt.z = CSP.Z_Pt()            'Pt.z = CSP.Z_Pt()               'CSPContnr.dll used here
            Pt.DStrtPt.x = CSP.X_Pt()            'Pt.x = CSP.X_Pt()
            Pt.DStrtPt.y = CSP.Y_Pt()            'Pt.y = CSP.Y_Pt()

            siSW.WriteLine("Viewpoint {")
            siSW.WriteLine("position " & Pt.DStrtPt.x & " " & Pt.DStrtPt.y & " " & Pt.DStrtPt.z)            'siSW.WriteLine("position " & Pt.x & " " & Pt.y & " " & Pt.z)

            Dim x1 As Single = Pt.DStrtPt.x                    'Dim x1 As Single = Pt.x
            Dim y1 As Single = Pt.DStrtPt.y                    'Dim y1 As Single = Pt.y
            Dim z1 As Single = Pt.DStrtPt.z                    'Dim z1 As Single = Pt.z

            CSP.cX = Pt.DStrtPt.x                               'CSP.cX = Pt.x       'CSPContnr.dll used here
            CSP.cZ = Pt.DStrtPt.y                               'CSP.cZ = Pt.y

            'Dim DigLngth As Single = ((Pt.x ^ 2) + (Pt.y ^ 2)) ^ 0.5

            Dim DigLngth As Single = CSP.Diagonal()     'CSPContnr.dll used here

            CSP.cX = Pt.DStrtPt.x                                'CSP.cX = Pt.x
            CSP.Dngl = DigLngth                     'CSPContnr.dll used here
            Dim Ang As Single = CSP.AnglTan()       'Dim Ang As Single = Math.Atan(Pt.x / DigLngth)

            siSW.WriteLine("description " & Dq & "a" & Dq)

            siSW.WriteLine("}")
            siSW.WriteLine("]}")

            siSW.WriteLine("]}")
            siSW.WriteLine("]}")

            siSW.WriteLine("Transform {")
            siSW.WriteLine("rotation 1 0 0 -1.570796327")
            siSW.WriteLine("children [")

            Mom = Pt.DStrtPt.z                                       'Mom = Pt.z
            Pt.DStrtPt.z = Pt.DStrtPt.y                              'Pt.z = Pt.y
            Pt.DStrtPt.y = -Mom                                      'Pt.y = -Mom

            siSW.WriteLine("Transform {")
            siSW.WriteLine("rotation 0 0 1 3.141592654")
            siSW.WriteLine("children [")

            Pt.DStrtPt.x = -Pt.DStrtPt.x * 1.5                      'Pt.x = -Pt.x * 1.5
            Pt.DStrtPt.y = -Pt.DStrtPt.y * 0.15                                     'Pt.y = -Pt.y * 0.15

            siSW.WriteLine("Transform {")

            CSP.cX = -Pt.DStrtPt.x                               'CSP.cX = -Pt.x
            CSP.cZ = -Pt.DStrtPt.z                       'CSP.cZ = -Pt.z              'CSPContnr.dll used here

            Dlg = CSP.Diagonal()

            'Dlg = ((Pt.x ^ 2) + (Pt.z ^ 2)) ^ 0.5
            OldPtz = Pt.DStrtPt.z                        'OldPtz = Pt.z

            CSP.cX = Pt.DStrtPt.x                'CSP.cX = Pt.x
            CSP.Dngl = Dlg              'CSPContnr.dll used here
            Pt.DStrtPt.z = CSP.Z_Point()        'Pt.z = CSP.Z_Point()

            'Pt.z = Pt.x / (Pt.x / Dlg)

            CSP.cZ = OldPtz
            CSP.Dngl = Dlg                      'CSPContnr.dll used here

            Dim sFac As Single = CSP.sFactor()       'Dim sFac As Single = 2.3 / Math.Acos(OldPtz / Dlg)

            siSW.WriteLine("rotation 0 1 0 -" & CStr(Math.Acos(OldPtz / Dlg) * sFac))
            siSW.WriteLine("children [")

            Pt.DStrtPt.z = Pt.DStrtPt.z * 2                            'Pt.z = Pt.z * 2
            Pt.DStrtPt.x = Pt.DStrtPt.x * 0.5                          'Pt.x = Pt.x * 0.5

            siSW.WriteLine("Viewpoint {")
            siSW.WriteLine("position " & Pt.DStrtPt.x & " " & Pt.DStrtPt.y & " " & Pt.DStrtPt.z)            'siSW.WriteLine("position " & Pt.x & " " & Pt.y & " " & Pt.z)

            CSP.cX = Pt.DStrtPt.x               'CSP.cX = Pt.x
            CSP.cZ = Pt.DStrtPt.y               'CSP.cZ = Pt.y                       'CSPContnr.dll used here

            DigLngth = CSP.Diagonal()

            'DigLngth = ((Pt.x ^ 2) + (Pt.y ^ 2)) ^ 0.5
            CSP.cX = Pt.DStrtPt.x                            'CSP.cX = Pt.x
            CSP.Dngl = DigLngth

            Ang = CSP.AnglTan()

            'Ang = Math.Atan(Pt.x / DigLngth)

            siSW.WriteLine("description " & Dq & "b" & Dq)

            siSW.WriteLine("}")
            siSW.WriteLine("]}")

            siSW.WriteLine("]}")
            siSW.WriteLine("]}")

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in WrVrmlStrt " & vbCrLf & "VRML Programme writting is failure!", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            siSW.Close()
            Return Nothing
            Exit Function
        End Try

        Return Nothing

    End Function

#End Region

#Region " Routine Definition "

    Public Sub ThreeDViewerDrumDHE()

        Try

            DEventless()
            Stuff_Viewers.Show()
            Stuff_Viewers.Focus()

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in ThreeDViewerDrumDHE" & vbCrLf & "DVRML Programme Running is failure!", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TransactionsMenu.Close()
        Finally

            If FlgArngmnt = False Then
                'Stop
                'DSAData()           'Arrange table when Simple arrangement is done

                'This is Cancel right now see later //DT 2 May 2K8 9.55 AM

            End If

            siSW.Close()
            connDrums.Close()
            GC.Collect()
        End Try

    End Sub

    Public Sub DrumFinalOutPutWriter()

        Try

            Dim DT As DateTime = DateTime.Now

            Dim DtTm As String = DT.ToString("dd/MM/yyyy :hh:mm:ss tt")

            Dim dtmFile As String = DT.ToString("ddMMyyhms")
            Dim Wifile As String = CurDir() & "\Drum.wrl"
            Dim Wofile As String = CurDir() & "\Stuff Viewers files\StuffOPTDrum\" & dtmFile & ".wrl"
            Dim F As Int16 = 1

            EDWr.De = F
            EDWr.Ifile = Wifile
            EDWr.Ofile = Wofile
            EDWr.DEKey = "C$P"

            F = EDWr.DEncript()

            IFOPWrDrum(dtmFile)

            '''''''''''''''''''''''
            DrumFileOP = "CSP.Drum"
            '''''''''''''''''''''''

            Wifile = CurDir() & "\Drum.wrl"
            Wofile = "C:\" & DrumFileOP & ".wrl"
            F = 5
            EDWr.De = F

            EDWr.De = F
            EDWr.Ifile = Wifile
            EDWr.Ofile = Wofile

            F = EDWr.WrProgCSP()

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in DrumFinalOutPutWriter", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub

    Public Sub IFOPWrDrum(ByVal CSPID As String)

        Try
            If connT.State = ConnectionState.Closed Then connT.Open()
            Dim Cmds As New OleDb.OleDbCommand

            Cmds.Connection = connT
            Cmds.CommandText = "insert into OPFileDrum values(" & CStr(CSPID) & ")"
            Cmds.ExecuteNonQuery()
        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in IFOPWr", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            connT.Close()
        Finally
            connT.Close()
        End Try

    End Sub

    Public Sub TrnslnDrm(ByVal fNm As String, ByVal DCntPt() As String)

        Try

            siSW.WriteLine("translation -" & CStr(DCntPt(0)) & " " & CStr(DCntPt(1)) & " -" & CStr(DCntPt(2)))

        Catch Err As Exception
            connDrums.Close()
            siSW.Close()
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in TrnslnDrm", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub SARInsrt(ByVal X As Double, ByVal Z As Double, ByVal Y As Double, ByVal Rds As Double, ByVal ReO As Short, ByVal Dgm As Short, ByVal CDL As Double, ByVal CDW As Double, ByVal CDH As Double)

        Dim CmdSA As New OleDb.OleDbCommand

        Try
            If connDrums.State = ConnectionState.Closed Then connDrums.Open()

            CmdSA.Connection = connDrums
            CmdSA.CommandText = "insert into SArngmt (CL, CW, CH, SRN, Xx, Zz, Yy, Rr, DHt, EO, DGM) values (" & CStr(CDL) & "," & CStr(CDW) & "," & CStr(CDH) & "," & CStr(SN) & "," & CStr(DCntCA.X) & "," & CStr(DCntCA.Z) & "," & CStr(DCntCA.Y) & "," & CStr(Rds) & "," & CStr(DHt) & "," & CStr(ReO) & "," & CStr(Dgm) & ")"
            CmdSA.ExecuteNonQuery()

            SN += 1

        Catch Ex As Exception
            connDrums.Close()
            siSW.Close()
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in SARInsrt" & vbCrLf & "Data insert connection failure!", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub IDrumStuff(ByVal MatName As String, ByVal X As Double, ByVal Z As Double, ByVal Y As Double, ByVal R As Double, ByVal H As Double, ByVal Method As Integer, ByVal Tex As String, ByVal Colr As String)

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
            connDrums.Close()
            siSW.Close()
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in IDrumStuff" & vbCrLf & "Data insert connection failure!", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub DCAGeomCyl(ByVal fNm As String, ByVal Col As String, ByVal Transpx As Single, ByVal Tex As String, ByVal ItmNm As String, ByVal Wt As Single, ByVal QtyFlg As Boolean, ByVal TxtOpt As Boolean, ByVal MatName As String, ByVal Method As Integer, ByVal DataOpt As Boolean, ByVal ShapeOpt As String, ByVal X As Double, ByVal Z As Double, ByVal Y As Double, ByVal Rds As Double)

        'DDStop

        'siSW.Close()
        DCntCA.X = X
        DCntCA.Y = Y
        DCntCA.Z = Z

        'If SS = 31 Then

        'Stop
        'siSW.Close()
        ' End If

        SS += 1
        'siSW.WriteLine("")

        ' siSW.WriteLine("")
        'siSW.WriteLine("#SS No:- " & SS)
        ' siSW.WriteLine("")
        'siSW.WriteLine("")

        Try
            Dim Dq As Char = Chr(34)

            Static REO As Short = 0
            Static DGM As Short = 0

            If DCntCA.Y = Rds Then
                REO = 1
            Else
                REO = REO + 1
            End If

            'Stop

            If REO = 1 Then

                siSW.WriteLine("Transform {")
                FileClose(1)

                TrnslnDrm(fNm, New String() {CStr(DCntCA.X), CStr(DCntCA.Z), CStr(DCntCA.Y)})
                SARInsrt(DCntCA.X, DCntCA.Z, DCntCA.Y, Rds, REO, DGM, CL, CW, CH)       'Data inserting    'Remove Comments // 
                IDrumStuff(MatName, DCntCA.X, DCntCA.Z, DCntCA.Y, DRds, DHt, Method, Tex, Col)      'Insert Data to DrumStuffCA

            Else
                'Stop
                SgnCA = True            'These Flag is true then Generate cross Arrangement in following by Using Dll

            End If

            If SgnCA = True Then

                'Stop
                Dim Xx As Double
                Dim Yy As Double
                Dim Zz As Double

                Dim Rr1 As Double = Rds
                Dim Rr2 As Double = Rds
                Dim Rr3 As Double = Rds
                Dim La As Double
                Dim DGapx = 0


                'Impliment here from 28 July 2008


                Xx = DCAgmPt.GetBaseX(Rr1, Rr2, Rr3, DGapx)             '*Xx = CA.GetBaseX(Rr1, Rr2, Rr3, DGapx)
                Yy = DCAgmPt.GetAltitudeY(Rr1, Rr2, Rr3, DGapx)              '*Yy = CA.GetAltitudeY(Rr1, Rr2, Rr3, DGapx)

                'Yy = Math.Round(Yy, 4)                          'Formulation Done in CrossArngmt.dll
                'DDStop
                FrCaY = Yy


                Zz = DCAgmPt.GetDepthZ(0, 0, 0, DCntCA.Z)          '*Zz = CA.GetDepthZ(0, 0, 0, DCntCA.Z)
                La = DCAgmPt.GetLa(Rr1, Rr2, Rr3, DGapx)                 '*La = CA.GetLa(Rr1, Rr2, Rr3, DGapx)

                'Implement here X ---->>

                'Stop

                If DCntCA.X = Rds Then
                    DCntCA.X = Xx
                Else
                    'Stop
                    FlgCA = True
                    'siSW.Close()
                    Exit Sub

                End If

                DCntCA.Y = Rds + Yy


                Dim Diamtr As Double = Rds * 2

                If DCntCA.X = Diamtr Then
                    DGM = 1

                Else
                    DGM += 1
                End If

                XAxis += Xx             'X Axis Limitation check Width of container
                XAxisRd = Xx + DRds

                If XAxisRd > CW Then
                    flgXAxis = True
                    Exit Sub
                End If

                If XAxis > CW Then
                    flgXAxis = True
                    'Exit Sub
                End If


                siSW.WriteLine("Transform {")
                FileClose(1)

                TrnslnDrm(fNm, New String() {CStr(DCntCA.X), CStr(DCntCA.Z), CStr(DCntCA.Y)})

                SARInsrt(DCntCA.X, DCntCA.Z, DCntCA.Y, Rds, REO, DGM, CL, CW, CH)       'Data inserting    'Remove Comments // 
                IDrumStuff(MatName, DCntCA.X, DCntCA.Z, DCntCA.Y, DRds, DHt, Method, Tex, Col)      'Insert Data to DrumStuffCA
            End If

        Catch Ex As Exception
            connDrums.Close()
            siSW.Close()
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in DCAGeomCyl", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub GDrmCA(ByVal fNm As String, ByVal DCmPt() As String)

        siSW.WriteLine("geometry Cylinder { radius " & CStr(DCmPt(0)) & " height " & CStr(DCmPt(1)) & " }")

        siSW.WriteLine("}")
        siSW.WriteLine("}")

        ItrQty += 1

        '$$$$$
        'Stop
        '$$$$$
        'siSW.Close()

    End Sub

    Public Sub RotnDrm(ByVal fNm As String)

        Try
            siSW.WriteLine("rotation 0 0 0 0")

        Catch Err As Exception
            connDrums.Close()
            siSW.Close()
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in RotnCyl", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub TrnspDrm(ByVal fNm As String, ByVal Grd As String, ByVal Col As String)
        'Stop
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
            connDrums.Close()
            siSW.Close()
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in TrnspDrm", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Function DPlaceCA(ByVal Fn As String, ByVal Col As String, ByVal Transpx As Single, ByVal Tex As String, ByVal ItmNm As String, ByVal Wt As Single, ByVal QtyFlg As Boolean, ByVal TxtOpt As Boolean, ByVal MatName As String, ByVal Method As Integer, ByVal DataOpt As Boolean, ByVal ShapeOpt As String, ByVal DDia As Double, ByVal DRds As Double, ByVal DHt As Double)

        connDrums.Close()

        Dim DPts As New CDrum

        'Stop
        'siSW.Close()

        Dim Xc As Double
        Dim Yc As Double
        Dim Zc As Double
        'Dim DiaCA As Double = 2 * DRds

        If connDrums.State = ConnectionState.Closed Then connDrums.Open()
        Dim CmdPCA As New OleDb.OleDbCommand
        Dim RdrPCA As OleDb.OleDbDataReader

        Try

            'Stop

            If DrmReptSgn Then

                CmdPCA.Connection = connDrums

                CmdPCA.CommandText = "select Xca, Zca, Yca from CArngmt"

                'Implement here for Qty 25 April 2K8

            Else
                CmdPCA.Connection = connDrums
                CmdPCA.CommandText = "select Xca, Zca, Yca from CArngmt where NOT DGM"
            End If

            DrmReptSgn = True
            'Stop

            RdrPCA = CmdPCA.ExecuteReader

            Do While (RdrPCA.Read())

                Xc = RdrPCA("Xca")
                Zc = RdrPCA("Zca")

                If CANxtFlg = False Then
                    Yc = RdrPCA("Yca")
                End If

                If CANxtFlg = True Then
                    Yc = TotYdrct
                    FrCaYca = Yc
                End If

                siSW.WriteLine("")

                Xlmt = Xc + DRds
                'Stop
                If Xlmt > CW Then
                    'Stop
                    Exit Try
                End If

                If Not flgCAqt Then

                    If Not flgCAqt Then

                        siSW.WriteLine("Transform {")
                        FileClose(1)

                        IDrumStuff(MatName, Xc, Zc, Yc, DRds, DHt, Method, Tex, Col)

                        TrnslnDrm(Fn, New String() {CStr(Xc), CStr(Zc), CStr(Yc)})

                        RotnDrm(Fn)         'Rotndrm(Fn)

                        siSW.WriteLine("children Shape {")
                        siSW.WriteLine("appearance Appearance {")

                        'Col = "r"
                        TrnspDrm(Fn, Transpx, Col)

                        Dim Dq As Char = Chr(34)

                        If Tex <> "" Then
                            siSW.WriteLine("texture ImageTexture { url " & Dq & Tex & Dq & " }")
                        End If

                        siSW.WriteLine("}")

                        'DDStop

                        DPts.DCntPt.X = Xc
                        DPts.DCntPt.Y = Yc
                        DPts.DCntPt.Z = Zc
                        DPts.DHeight = DHt
                        DPts.DRadius = DRds

                        Try                  'Cross drum arrangements points stored in that points

                            CADimnsAdd(DPts.DCntPt.X, DPts.DCntPt.Y, DPts.DCntPt.Z, DPts.DHeight, DPts.DRadius)

                        Catch Ex As Exception
                            MsgBox(Ex.Message)
                            MsgBox(Ex.ToString)
                            MessageBox.Show("Error in AutoDrawDrmCA", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try


                        GCylCADrm(Fn, New String() {CStr(DRds), CStr(DHt)})

                    Else
                        Return CDQCAer
                        Exit Function
                    End If

                Else
                    Return CDQCAer
                    Exit Function
                End If

            Loop

            connDrums.Close()

        Catch Ex As Exception
            connDrums.Dispose()
            connDrums.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\Drums.mdb;Persist Security Info=False"
            connDrums.Open()
            CmdPCA.Cancel()
            CmdPCA.Connection = Nothing
            CmdPCA.Connection = connDrums
            CmdPCA.CommandText = ""
            CmdPCA.CommandText = "delete from CArngmt"
            CmdPCA.ExecuteNonQuery()
            connDrums.Close()
        Finally
            connDrums.Close()
            ConDrm.Close()
        End Try

        Return CDQCAer

    End Function

    Public Sub GCylCADrm(ByVal fNm As String, ByVal DCmPt() As String)
        
        siSW.WriteLine("geometry Cylinder { radius " & CStr(DCmPt(0)) & " height " & CStr(DCmPt(1)) & " }")

        siSW.WriteLine("}")
        siSW.WriteLine("}")

        'If SS = 33 Then

        'Stop
        ' siSW.Close()
        'End If
        '$$$$$
        'Stop
        '$$$$$
        'siSW.Close()

        Dim DQtyCa As Integer

        DQtyCa = DrmQtysr

        DrmQtysr += 1
        DCACount(DrmQtysr)

    End Sub

    Public Sub DCountCSQ(ByVal ItmQty As Integer)

        'DDStop

        Progress8.iQty = ItrQty             'Progress8.i = ItrQty    'ItemQty

        DrmQtysr = ItrQty                   'ItemQty

        If DrmQtysr > 21 Then
            'Stop
            'MsgBox("Ok")
            'Stop
        End If

        If ItrQty = (LCAQty(0) - 1) Then

            'DDStop
            flgCAqt = True
        End If

        'TransactionsMenu.lblStatus.Text = " Please wait " & CStr(Dot) & ""
        'TransactionsMenu.lblStatus.Text = " Numbers ::   " & CStr(ItemQty) & "    -> Items stuffed"
        'TransactionsMenu.lblStatus.Text = "Cross stuff arrangement in progress :: " & CStr(ItemQty) & Chr(13) & vbCr & "       Please wait ....."
        'TransactionsMenu.lblStatus.Text = " Numbers ::   " & CStr(ItemQty) & "    -> Items stuffed"

        TransactionsMenu.lblStatus.Text = " Numbers ::   " & CStr(ItrQty) & "    -> Items stuffed"

        TransactionsMenu.btnStatus.Visible = True

        TransactionsMenu.lblStatus.Refresh()
        System.Windows.Forms.Application.DoEvents()

        DEventful()
        TransactionsMenu.pbCSPD.Visible = True
        DProgressBarRunning()

    End Sub

    Public Sub DCACount(ByVal CAQty As Integer)

        'DDStop


        'From 2 July Impliments Here 

        If DrmQtysr > 21 Then
            'Stop
            'MsgBox("Ok")
            'Stop
        End If

        If ItrQty = (LCAQty(0) - 1) Then

            'DDStop
            flgCAqt = True

        End If

        TransactionsMenu.lblStatus.Text = " Numbers ::   " & CStr(CAQty) & "    -> Items stuffed"
        TransactionsMenu.btnStatus.Visible = True
        ItrQty = CAQty
        TransactionsMenu.lblStatus.Refresh()
        System.Windows.Forms.Application.DoEvents()
        DEventful()
        TransactionsMenu.pbCSPD.Visible = True
        DProgressBarRunning()

        'DDDStop

        'siSW.Close()


    End Sub

    Public Function DArgmtNxt(ByVal Fn As String, ByVal Col As String, ByVal Transpx As Single, ByVal Tex As String, ByVal ItmNm As String, ByVal Wt As Single, ByVal QtyFlg As Boolean, ByVal TxtOpt As Boolean, ByVal MatName As String, ByVal Method As Integer, ByVal DataOpt As Boolean, ByVal ShapeOpt As String, ByVal DDia As Double, ByVal DRds As Double, ByVal DHt As Double)

        Dim DPtca As New CDrum

DNCA:
        Dim Ydirct As Double
        Dim Yprev As Double
        Dim Ylimt As Double

        Yprev = FrCaYca

        Ydirct = FrCaY

        TotYdrct = FrCaYca + FrCaY

        Ylimt = (TotYdrct + DRds)

        If CL < Ylimt Then
            'Stop
            Return CDQCAer
            Exit Function
        End If


        'Stop


        '$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
        'Stop

        Dim Xcn As Double
        Dim Ycn As Double
        Dim Zcn As Double
        connDrums.Close()
        If connDrums.State = ConnectionState.Closed Then connDrums.Open()
        Dim CmdNCA As New OleDb.OleDbCommand
        Dim RdrNCA As OleDb.OleDbDataReader


        'If DrmReptSgn Then

        Try
            CmdNCA.Connection = connDrums

            CmdNCA.CommandText = "select Xx, Zz from SArngmt where DGM = 0"
            RdrNCA = CmdNCA.ExecuteReader

            Do While (RdrNCA.Read())

                Xcn = RdrNCA("Xx")
                Zcn = RdrNCA("Zz")
                Ycn = TotYdrct

                FrCaYca = Ycn       'Previous value Initialize


                IDrumStuff(MatName, Xcn, Zcn, Ycn, DRds, DHt, Method, Tex, Col)

                siSW.WriteLine("")

                If Not flgCAqt Then

                    siSW.WriteLine("Transform {")
                    FileClose(1)

                    TrnslnDrm(Fn, New String() {CStr(Xcn), CStr(Zcn), CStr(Ycn)})

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

                    'DDStop

                    DPtca.DCntPt.X = Xcn
                    DPtca.DCntPt.Y = Ycn
                    DPtca.DCntPt.Z = Zcn
                    DPtca.DHeight = DHt
                    DPtca.DRadius = DRds

                    'DDStop

                    Try                  'Cross drum arrangements points stored in that points

                        CADimnsAdd(DPtca.DCntPt.X, DPtca.DCntPt.Y, DPtca.DCntPt.Z, DPtca.DHeight, DPtca.DRadius)

                    Catch Ex As Exception
                        MsgBox(Ex.Message)
                        MsgBox(Ex.ToString)
                        MessageBox.Show("Error in AutoDrawDrmCA", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try

                    GCylCADrm(Fn, New String() {CStr(DRds), CStr(DHt)})

                Else
                    Return CDQCAer
                    Exit Function
                End If

            Loop

        Catch Ex As Exception
            connDrums.Dispose()
            connDrums.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\Drums.mdb;Persist Security Info=False"
            connDrums.Open()
            CmdNCA.Cancel()
            CmdNCA.Connection = Nothing
            CmdNCA.Connection = connDrums
            CmdNCA.CommandText = ""
            CmdNCA.CommandText = "delete from CArngmt"
            CmdNCA.ExecuteNonQuery()
            connDrums.Close()

        Finally
            ' Stop
            connDrums.Close()
            ConDrm.Close()
        End Try


        'End If

        '$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

        Yprev = FrCaYca
        'Stop
        Ydirct = FrCaY

        TotYdrct = FrCaYca + FrCaY

        Ylimt = (TotYdrct + DRds)

        If CL < Ylimt Then
            Return CDQCAer
            Exit Function
        Else
            CANxtFlg = True
        End If

        If Not flgCAqt Then

            CDQCAer = DPlaceCA(Fn, Col, Transpx, Tex, ItmNm, Wt, QtyFlg, TxtOpt, MatName, Method, DataOpt, ShapeOpt, DDia, DRds, DHt)

            'DDStop

        Else
            Return CDQCAer
            Exit Function
        End If

        'DStop
        GoTo DNCA
        Stop
        connDrums.Close()
        siSW.Close()

        Return CDQCAer

    End Function

#End Region

End Module
