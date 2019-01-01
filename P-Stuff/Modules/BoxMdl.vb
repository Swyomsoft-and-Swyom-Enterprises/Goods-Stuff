
'Program Name: -    BoxMdl.vb
'Programmer Name: - Satwadhir B. Pawar Mob No. :- 9323974665
'Company Name:-     Hazel Infotech LTD. Mumbai
'Project Name: -    Sky Stuff Plus (Container Stuffing)
'Date: -            22 Dec 2K8 12.23 PM (Modified Time)

'Tips: - The code is debugging at that particular dimensions, quantity and sequence.
'        you are decide it the logic happen is correct to that way or its are some 
'        different way the understanding to at your best level is the correct logic 
'        of this particular code block.

'Description: - BoxMdl is the box stuffing module to implements various routines and 
'               functions so that to got the ultimate results in box stuffing.

#Region "Importing Object"

Imports System.Drawing
Imports CSPDbSrt
Imports DrmFindQty
'Imports SDo = System.Data.OracleClient

#End Region

Module BoxMdl

#Region "Module Declaration"

    'Public OConn As SDo.OracleConnection = New OracleClient.OracleConnection("Data Source=;User ID=satwadhir;Password=login")

    Friend dbdll As New DgvManage()          'Public DbDll As New DgvManage()        'use CSPDbtracK.dll

    'Public cReslt As Double = 0            'Calculation is assign the final results
    'Public Rdgv1 As Integer = 0           'row index in datagrid
    'Public Cdgv1 As Integer = 0           'column index in datagrid


    Public myFormHt As Integer = Screen.PrimaryScreen.WorkingArea.Height               'The form width height position
    Public myFormWd As Integer = Screen.PrimaryScreen.WorkingArea.Width

    Public ADflg As Boolean = False         'Quantity sort flag
    Public AoFlg As Boolean = False         'Orientation flag
    Public ADsFlg As Boolean = False         'Dimensions flag
    Public ADmsFlg As Boolean = False         'Dimensions flag
    Public ADabFlg As Boolean = False        'Alphabetical sort flag
    Public ADclFlg As Boolean = False            'Carton lable flag 
    Public SrNFlg As Boolean = False             'Serial number flag for sr. no. wise sort

    Public AdRefFlg As Boolean = False

    Public BxQty As New DrumQty()             'DCalcQty.dll used here

    Public flgDGV1 As Boolean = False            'Data grid view flag

    Public mClk As Boolean = False          'Mouse click show button option

    Public DbxFlg As Boolean = False             'Door of box container flag
    Public DbxFlgO As Boolean = False           'Org flg opn dr
    Public DrBxOpn As Boolean = False            'Track bar door open
    Public Mth As Boolean = False                'Match quantity its reamining and extra added quantity

    Public OpnDeg As Double = 0                 'open door degree
    Public TrnsGrd As Double = 0                'open door trnsparancy to see inside

    Public XPosPt As Double = 0
    Public YPosPt As Double = 0
    Public ZPosPt As Double = 0
    Public QtyPosPt0 As Double = 0               'Starting quantity to shifting position
    Public QtyPosPt1 As Double = 0               'Ending quantity to shifting position
    Public arl() As String                      'Lable writing to box
    Public lblNM As String = "1"                'Imagename of box quantity in Auto3DBx
    Public Inm As String = Nothing              'Image name assign in Auto3DBx
    Public Xl3d As Double                         'Last Value in X Cordinate point in Auto3DBx
    Public Yl3d As Double                         'Last Value in Y Cordinate point in Auto3DBx
    Public Zl3d As Double                         'Last Value in Z Cordinate point in Auto3DBx

    Public flg_RiCnt As Boolean = False          'Row count item initializing flag
    Public flgPause As Boolean = False           'Stop the loop in seconds
    Public SlidStfPosFlg As Boolean = False      'Slide stuff position flag  
    Public SecPause As Int64 = 0                 'pause seconds
    Public Gdn As Int16 = 1                      'Count of goods in SubAction
    Public PBCl As Int16 = 0                     'Box stuff Progressbar color change
    Public RiCnt As Int16                        'Row count of item is initializing

    Public Lbi As Double = 0                    'Box item dimensions
    Public Wbi As Double = 0
    Public Hbi As Double = 0

    'Public Yax As Double = 0                     'Dimensions of Y axis arrangement in general stuff to wad stuff

    Public Ydm As Double = 0                     'Shifting the dimensions

    Public PlyDrwLst As New List(Of Area)         'PlyStuff Reamining Dimensions of when placing first quantity

    Public Lbc As Double = 0                    'Box container dimensions
    Public Wbc As Double = 0
    Public Hbc As Double = 0

    Public xMax As Double = 0        'CollectArt x axis maximum value
    Public fXmax As Double = 0        'CollectArt final maximum x axis value
    Public CAimgnm As String = Nothing   'CollectArt image names
    Public CAflg As Boolean = False          'CollectArt y axis flag

    Public vertxINo As String = "2"         'VertexBox function img no stored
    Public bVx As Double = 0
    Public bVy As Double = 0
    Public bVXx As Double = 0

    Public PSrtShw As Boolean = False
    Public myProcess As Process = Nothing

    Public wad4flg As Boolean = False

    Public PlyIno As Integer = 0                   'Ply stuff
    Public PlyInm As String = Nothing
    Public txtRfac As Double = 0
    Public PlysQty As Integer = 0
    Public ImgStrINm As String = Nothing
    Public Str As String = Nothing

    Public WrlFn As String = "\First.wrl"              'Nothing            'The Out file of 3D program file name

#End Region

#Region "Structure Definition"

    Public Structure RE1
        Public Itmnm As String
        Public Qty As Integer
        Public CBStk As List(Of Region)

    End Structure

    Public Structure e1
        Public itmnm As String
        Public qty As Integer
        Public stk As List(Of Area)

    End Structure

    Public Structure E1Wad

        Public ItmNm As String
        Public Qty As Integer
        Public Stk As List(Of Area)

    End Structure

    Public Structure r1

        Public ar As Area
        Public method As Integer
        Public itmnm As String
        Public stk As List(Of Area)

    End Structure

    Public Structure R1Wad

        Public Ar As Area
        Public Mthd As Integer
        Public ItmNm As String
        Public Stk As List(Of Area)

    End Structure

#End Region

#Region "Routine Definitions"

    Public Sub StepNows(ByVal TempFile As String)

        Try
            off.Flush()
        Catch
        End Try

        Try
            Try
                Process.Start(TempFile)
            Catch ex As Exception
                Process.Start("C:\Program Files\Alteros 3D\alteros.exe", TempFile)
            End Try
        Catch ex As Exception
            Process.Start(TempFile)
        End Try

    End Sub

    Public Sub StepNow()

        Try
            off.Flush()
        Catch
        End Try

        'Dim Rsm As MsgBoxResult
        Dim Proc As Process = Nothing

        'Rsm = MessageBox.Show("You wana go to the next step ?" & vbNewLine & "Go to next step close the Alteros 3D ", "Step show info.....", MessageBoxButtons.YesNo, MessageBoxIcon.Information)

        'If Rsm = MsgBoxResult.Yes Then

        Try
            myProcess.Close()
        Catch
        End Try

        Dim TempFile As String = CurDir() & "\First.wrl"      'Dim TempFile As String = "C:\Program Files\Alteros 3D\alteros.exe"

        Try
            Try
                Process.Start(TempFile)
            Catch ex As Exception
                myProcess = Process.Start("C:\Program Files\Alteros 3D\alteros.exe", TempFile)
            End Try
        Catch ex As Exception
            myProcess = Process.Start(TempFile)
        End Try

        'If Not PSrtShw Then
        '    NextStepShow.lblNxtStpinfo.Text = "Go to next step close the Alteros 3D "
        '    NextStepShow.ShowDialog()
        '    PSrtShw = True
        'End If

        'MessageBox.Show("Go to next step close the Alteros 3D ", "Step show info.....", MessageBoxButtons.OK, MessageBoxIcon.Information)


        'Dim docclose As Boolean

        'Do While Not docclose

        '    Try

        '        If myProcess Is Nothing Then Exit Do

        '        Dim exittime = myProcess.ExitTime

        '        If exittime <= Now() Then

        '            docclose = True

        '        End If

        '    Catch ex As Exception

        '    End Try

        'Loop

        'Else
        Try
            myProcess.Close()
        Catch
        End Try

        TransactionMenu.chkbxStpShow.Checked = False

        'End If


    End Sub

    Public Sub StepShow()

        Try

            Dim Alteros As String = "C:\Program Files\Alteros 3D\alteros.exe"
            Dim Rsm As MsgBoxResult
            Dim Proc As Process = Nothing

            Rsm = MessageBox.Show("You wana go to the next step ?", "Step show", MessageBoxButtons.YesNo, MessageBoxIcon.Information)

            If Rsm = MsgBoxResult.Yes Then

                Try
                    Proc.Close()
                Catch
                End Try

                Proc = Process.Start(Alteros)



            ElseIf Rsm = MsgBoxResult.No Then

                Proc.Close()

            End If

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in StepShow", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub StartViewer()

        Try

            Dim FName As String = CurDir() & "\First.wrl"
            Process.Start("c:\Program Files\Alteros 3D\alteros.exe", FName)

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in Alteros 3D running", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            conn.Close()
            off.Close()
            MessageBox.Show("Fatal error in StartViewer", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            MsgBox("Exit Application")
            Application.Exit()
        End Try

    End Sub

    Public Sub PngStarter()

        Try
            Process.Start(CurDir() & "\PNGMaker.exe")

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in btnCartonLabel_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub PauseSec(ByVal Secnd As Int64)

        Try

            Secnd = Secnd * 1000
            System.Threading.Thread.Sleep(Secnd)
            flgPause = False
            TransactionMenu.btnPause.BackColor = Color.DarkSeaGreen

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in PauseSec", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub AutoStuffIns(ByVal SrN As Integer, ByVal INm As String, ByVal L As Double, ByVal W As Double, ByVal H As Double, ByVal Orint As Integer, ByVal Qty As Integer, ByVal Qz As Integer, ByVal Qy As Integer, ByVal Qx As Integer, ByVal FcrL As Integer, ByVal RowCont As Integer, ByVal FnlQtys As Integer, ByVal RemnQtys As Integer)

        Try
            Dim Cmd As New OleDb.OleDbCommand
            If Cons.State = ConnectionState.Closed Then Cons.Open()

            L = Format(L, "0.00")
            W = Format(W, "0.00")
            H = Format(H, "0.00")

            Cmd.Connection = Cons
            Cmd.CommandText = "insert into AutoStuff values (" & CStr(SrN) & ",'" & INm & "'," & CStr(L) & "," & CStr(W) & "," & CStr(H) & "," & CStr(Orint) & "," & CStr(Qty) & "," & CStr(Qz) & "," & CStr(Qy) & "," & CStr(Qx) & "," & CStr(FcrL) & "," & CStr(RowCont) & "," & CStr(FnlQtys) & "," & CStr(RemnQtys) & ")"
            Cmd.ExecuteNonQuery()

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in AutoStuffIns", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub DbTrackIns(ByVal SrN As Integer, ByVal INm As String, ByVal Pck As String, ByVal Sz As Double, ByVal L As Double, ByVal W As Double, ByVal H As Double, ByVal Ori As Integer, ByVal Wt As Double, ByVal MxQty As Int64, ByVal UQty As Int64)

        Try
            Dim cmd As New OleDb.OleDbCommand
            If Cons.State = ConnectionState.Closed Then Cons.Open()
            cmd.Connection = Cons
            cmd.CommandText = "insert into BoxaA values (" & CStr(SrN) & ",'" & INm & "','" & Pck & "'," & CStr(Sz) & "," & CStr(L) & "," & CStr(W) & "," & CStr(H) & "," & CStr(Ori) & "," & CStr(Wt) & "," & CStr(MxQty) & "," & CStr(UQty) & ")"
            cmd.ExecuteNonQuery()

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.Message)
            MessageBox.Show("Error in DbTrack" & vbCrLf & "Data insert connection failure!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub DbTrackDupIns(ByVal SrN As Integer, ByVal INm As String, ByVal Pck As String, ByVal Sz As String, ByVal L As Double, ByVal W As Double, ByVal H As Double, ByVal Ori As Integer, ByVal Wt As Double, ByVal MxQty As Int64, ByVal UQty As Int64)

        Try
            L = Format(L, "0.00")
            W = Format(W, "0.00")
            H = Format(H, "0.00")
            Wt = Format(Wt, "0.00")

            Dim Cmd As New OleDb.OleDbCommand
            If Cons.State = ConnectionState.Closed Then Cons.Open()
            Cmd.Connection = Cons
            Cmd.CommandText = "insert into BoxaADpt values (" & CStr(SrN) & ",'" & INm & "','" & Pck & "'," & CStr(Sz) & "," & CStr(L) & "," & CStr(W) & "," & CStr(H) & "," & CStr(Ori) & "," & CStr(Wt) & "," & CStr(MxQty) & "," & CStr(UQty) & ")"
            Cmd.ExecuteNonQuery()

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in DbTrackDupIns", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub DbTrackerPerimDel()

        Try
            Dim Cmdp As New OleDb.OleDbCommand
            If Cons.State = ConnectionState.Closed Then Cons.Open()
            Cmdp.Connection = Cons
            Cmdp.CommandText = "delete from BoxAPerim"
            Cmdp.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in DbTrackerPeriDel", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cons.Close()
        End Try

    End Sub

    Public Sub DbTrackerPerimIns()

        Dim SrN As Int32 = 0
        Dim INm As String = Nothing
        Dim Pck As String = Nothing
        Dim Sz As Double = 0
        Dim L As Double = 0
        Dim W As Double = 0
        Dim H As Double = 0
        Dim Ori As Int16 = 0
        Dim Wt As Double = 0
        Dim MxQty As Int32 = 0
        Dim UQty As Int32 = 0

        Try
            If Cons.State = ConnectionState.Closed Then Cons.Open()
            Dim Cmdp As New OleDb.OleDbCommand
            Dim Rdrp As OleDb.OleDbDataReader
            Cmdp.Connection = Cons

            Cmdp.CommandText = "select SrNo, ItmName, Pack, Sizes, Length, Width, Height, Orient, Wt, MaxQty, Qty from BoxaA"
            Rdrp = Cmdp.ExecuteReader

            Do While (Rdrp.Read())
                SrN = Rdrp("SrNo")
                INm = Rdrp("ItmName")
                Pck = Rdrp("Pack")
                Sz = Rdrp("Sizes")
                L = Rdrp("Length")
                W = Rdrp("Width")
                H = Rdrp("Height")
                Ori = Rdrp("Orient")
                Wt = Rdrp("Wt")
                MxQty = Rdrp("MaxQty")
                UQty = Rdrp("Qty")
                DbTrackDupIns(SrN, INm, Pck, Sz, L, W, H, Ori, Wt, MxQty, UQty, DbDll.DbDimPerim(L, W, H))
            Loop

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in DbTrackerPerimIns", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub CompactPer()

        Dim cmdCmpt As New OleDb.OleDbCommand
        Dim perFac As Double
        Dim maxLComp As Double
        Dim maxWComp As Double
        Dim maxHComp As Double

        Try

            If Cons.State = ConnectionState.Closed Then Cons.Open()
            cmdCmpt.Connection = Cons

            Try
                cmdCmpt.CommandText = "select max(x) from stuffdata"
                maxLComp = cmdCmpt.ExecuteScalar
                cmdCmpt.Dispose()
                cmdCmpt.Connection = Cons
                cmdCmpt.CommandText = "select max(y) from stuffdata"
                maxWComp = cmdCmpt.ExecuteScalar
                cmdCmpt.Dispose()
                cmdCmpt.Connection = Cons
                cmdCmpt.CommandText = "select max(z) from stuffdata"
                maxHComp = cmdCmpt.ExecuteScalar
                cmdCmpt.Dispose()
            Catch
            End Try

            'perFac = CL * 0.01
            'maxLComp = maxLComp / perFac
            'maxLComp = Format((maxLComp), "0.00")

            'perFac = CW * 0.01
            'maxWComp = maxWComp / perFac
            'maxWComp = Format((maxWComp), "0.00")

            'perFac = CH * 0.01
            'maxHComp = maxHComp / perFac
            'maxHComp = Format((maxHComp), "0.00")

            'TransactionMenu.txtCompactPer.Text = Format(((maxLComp + maxWComp + maxHComp) / 3), "0.00")
            'TransactionMenu.Refresh()

            '*********************************************************
            perFac = CL * 0.01
            maxLComp = maxLComp / perFac
            maxLComp = Format((100 - maxLComp), "0.00")
            TransactionMenu.txtCompactPer.Text = maxLComp
            TransactionMenu.txtCompactPer.Refresh()
            TransactionMenu.Refresh()
            '*********************************************************

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in CompctPer", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cons.Close()
        End Try

    End Sub

    Public Sub cgManipulation()

        Try

            Dim cgP As New Point
            Dim cgRod As Double
            Dim cgRds As Double

            If Cons.State = ConnectionState.Closed Then Cons.Open()
            Dim Cmdcg As New OleDb.OleDbCommand
            'Dim Rdrcg As OleDb.OleDbDataReader
            Cmdcg.Connection = Cons

            Dim str1 As String = "select sum(Wt) "
            Dim str2 As String = "select sum(XMoment) "
            Dim str3 As String = "select sum(YMoment) "
            Dim str4 As String = "select sum(ZMoment) "
            Dim str5 As String = "from CGsGen"

            Dim TWt As Double
            Dim Xmom As Double
            Dim Ymom As Double
            Dim Zmom As Double

            Try
                Cmdcg.CommandText = str1 + str5
                TWt = Cmdcg.ExecuteScalar

                Cmdcg.CommandText = str2 + str5
                Xmom = Cmdcg.ExecuteScalar

                Cmdcg.CommandText = str3 + str5
                Ymom = Cmdcg.ExecuteScalar

                Cmdcg.CommandText = str4 + str5
                Zmom = Cmdcg.ExecuteScalar
            Catch
            End Try

            Dim BalXl As Double = CL * 0.5
            Dim BalYw As Double = CW * 0.5
            Dim BalZh As Double = CH * 0.5

            Dim Xwt As Double = Xmom
            Dim Ywt As Double = Ymom
            Dim Zwt As Double = Zmom

            Xmom = Format((Xmom / TWt), "0.00")
            Ymom = Format((Ymom / TWt), "0.00")
            Zmom = Format((Zmom / TWt), "0.00")

            Xwt = TWt - (Xwt / BalXl)
            Ywt = TWt - (Ywt / BalYw)
            Zwt = TWt - (Zwt / BalZh)

            If Xwt < 0 Then
                Xwt = -Xwt
            End If
            If Ywt < 0 Then
                Ywt = -Ywt
            End If
            If Zwt < 0 Then
                Zwt = -Zwt
            End If

            Dim avgWt As Double = Format(((Xwt + Ywt + Zwt) / 3), "0.00")


            Dim unit As String = Nothing

            If TransactionMenu.rdbMetric.Checked = True Then
                units = " MM."
            Else
                units = " Inch."
            End If

            cgP.z = Zmom
            cgP.y = Xmom
            cgP.x = Ymom

            If Not TransactionMenu.pilotFlg Then
                TransactionMenu.lblCG.Text = "Center of gravity in length wise is " & Xmom & vbCrLf & " width wise " & Ymom & " height wise " & Zmom & units
            End If

            Xmom = (CL * 0.5) - Xmom
            Ymom = (CW * 0.5) - Ymom
            Zmom = (CH * 0.5) - Zmom

            Xmom = Format(Xmom, "0.00")
            Ymom = Format(Ymom, "0.00")
            Zmom = Format(Zmom, "0.00")

            If Not TransactionMenu.pilotFlg Then
                TransactionMenu.lblCGoffset.Text = "Center of gravity offset in length wise is " & Xmom & vbCrLf & " width wise " & Ymom & " height wise " & Zmom & units
                TransactionMenu.AutoSize = True
                TransactionMenu.lblBalWt.Text = "The balance weight is " & avgWt & " Kg. from " & vbCrLf & "CG to length is " & Xmom & " ,from CG to width is " & Ymom & vbCrLf & " and from CG to Height is " & Zmom & " " & units
            End If

            TransactionMenu.lblCG.Visible = True
            TransactionMenu.lblCGoffset.Visible = True
            TransactionMenu.lblCG.Refresh()
            TransactionMenu.lblCGoffset.Refresh()

            'Stop

            If TransactionMenu.rdbEnglish.Checked = True Then
                cgRod = 700
                cgRds = 1
            ElseIf TransactionMenu.rdbMetric.Checked = True Then
                cgRod = 700 * 25.4
                cgRds = 1 * 25.4
            Else
                cgRod = 1000
                cgRod = 55
            End If

            Dim Xw As Double = cgP.x
            Dim Yl As Double = cgP.y
            Dim Zl As Double = cgP.z            '((zFac) * 0.5)
            Dim dQ As Char = Chr(34)

            off.WriteLine("")
            off.WriteLine("#    Center of gravity bar drawing program starts")
            off.WriteLine("")
            off.WriteLine("Transform {")
            off.WriteLine("translation -" & Xw & " " & Zl & " -" & Yl)
            off.WriteLine("rotation 0 0 0 0")
            off.WriteLine("children Shape {")
            off.WriteLine("appearance Appearance {")
            off.WriteLine("material Material { diffuseColor 1 0 0 ")
            off.WriteLine("transparency 0 }")
            off.WriteLine("texture ImageTexture { url " & dQ & "" & dQ & " }")
            off.WriteLine("}")
            off.WriteLine("geometry Cylinder { radius " & cgRds & " height " & cgRod & " }")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("")

            off.WriteLine("")
            off.WriteLine("Transform {")
            off.WriteLine("translation -" & Xw & " " & Zl & " -" & Yl)
            off.WriteLine("rotation 0 0 0 1.57")
            off.WriteLine("children Shape {")
            off.WriteLine("appearance Appearance {")
            off.WriteLine("material Material { diffuseColor 1 1 0 ")
            off.WriteLine("transparency 0 }")
            off.WriteLine("texture ImageTexture { url " & dQ & "" & dQ & " }")
            off.WriteLine("}")
            off.WriteLine("geometry Cylinder { radius " & cgRds & " height " & cgRod & " }")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("")

            off.WriteLine("")
            off.WriteLine("Transform {")
            off.WriteLine("translation -" & Xw & " " & Zl & " -" & Yl)
            off.WriteLine("rotation " & Zl & " 0 0 1.57")
            off.WriteLine("children Shape {")
            off.WriteLine("appearance Appearance {")
            off.WriteLine("material Material { diffuseColor 0 1 1 ")
            off.WriteLine("transparency 0 }")
            off.WriteLine("texture ImageTexture { url " & dQ & "" & dQ & " }")
            off.WriteLine("}")
            off.WriteLine("geometry Cylinder { radius " & cgRds & " height " & cgRod & " }")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("")
            off.WriteLine("#    Center of gravity bar drawing program is end ")
            off.WriteLine("")

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in DbTrackerPerimIns", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cons.Close()
        End Try

    End Sub

    Public Sub CGRoutine()
        Try
            With TransactionMenu
                .lblCG.Visible = False
                .lblCGoffset.Visible = False
                .lblCG.Text = ""
                .lblCGoffset.Text = ""
                .lblBalWt.Text = ""
                .chkbxCG.Checked = False
            End With
        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in CGRoutine", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub DbTrackDupIns(ByVal SrN As Integer, ByVal INm As String, ByVal Pck As String, ByVal Sz As String, ByVal L As Double, ByVal W As Double, ByVal H As Double, ByVal Ori As Integer, ByVal Wt As Double, ByVal MxQty As Int64, ByVal UQty As Int64, ByVal Perim As Double)
        'Stop
        Try
            Dim Cmdp As New OleDb.OleDbCommand

            If Cons.State = ConnectionState.Closed Then Cons.Open()

            Cmdp.Connection = Cons

            Cmdp.CommandText = "insert into BoxAPerim values (" & CStr(SrN) & ",'" & INm & "','" & Pck & "'," & CStr(Sz) & "," & CStr(L) & "," & CStr(W) & "," & CStr(H) & "," & CStr(Ori) & "," & CStr(Wt) & "," & CStr(MxQty) & "," & CStr(UQty) & "," & CStr(Perim) & ")"
            Cmdp.ExecuteNonQuery()

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in DbTrackDupIns", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub DbTrackerDupDel()

        Try
            Dim cmd As New OleDb.OleDbCommand

            If Cons.State = ConnectionState.Closed Then Cons.Open()

            cmd.Connection = Cons
            cmd.CommandText = "delete from BoxaADpt"
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in DbTrackerDupDel", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cons.Close()
        End Try

    End Sub

    Public Sub UpdateDataBaseBind()

        Try

            TransactionMenu.Dispose()
            TransactionMenu.Close()
            Call MDIForm.SendBack()
            TransactionMenu.MdiParent = MDIForm
            TransactionMenu.Show()
            TransactionMenu.BringToFront()

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in UpdateDataBaseBind", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub DbTrackDel()
        'Stop
        Try
            Dim cmd As New OleDb.OleDbCommand
            Dim CmdAS As New OleDb.OleDbCommand
            Dim cmdBD As New OleDb.OleDbCommand

            If Cons.State = ConnectionState.Closed Then Cons.Open()

            cmd.Connection = Cons
            cmd.CommandText = "delete from BoxaA"
            cmd.ExecuteNonQuery()

            cmdBD.Connection = Cons
            cmdBD.CommandText = "delete from BoxaADpt"
            cmdBD.ExecuteNonQuery()

            CmdAS.Connection = Cons
            CmdAS.CommandText = "delete from AutoStuff"
            CmdAS.ExecuteNonQuery()

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in DbTrackDel", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cons.Close()
        End Try

    End Sub

    Public Sub BoxStuffingActivity()

        TransactionMenu.Show()

    End Sub

    'Public Sub ProgProcess(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles panel1.Paint

    '        Dim X As Single
    '        Dim Y As Single
    '        Dim p As Single


    '        X = 7000
    '        Y = 5500
    '        p = 1500

    '        bw = txtBedWid.Text * p
    '        fsd = txtFSD.Text * p
    '        fb = txtFreBrd.Text * p
    '        lnecbl = txtLneCBL.Text * p
    '        lgl = txtLftGrdLvl.Text * p
    '        rgl = txtRhtGrdLvl.Text * p
    '        lnetoprl = txtLneTopRL.Text * p

    'Line (X, Y)-(X + bw, Y) 'Bed Width.
    'Line (X + bw, Y)-(X + bw + rgl / 100, Y - rgl / 100) ' Right Sloping Line.
    'Line (X + bw + rgl / 100, Y - rgl / 100)-(X + bw + rgl / 100 + 700, Y - rgl / 100) 'Right Horizantal Line.
    'Print "RGL="; rgl / p
    'Line (X, Y)-(X - lgl / 100, Y - lgl / 100) 'Left Sloping Line.
    'Line (X - lgl / 100, Y - lgl / 100)-(X - lgl / 100 - 1200, Y - lgl / 100) 'Left Horizantal Line.
    'Print "LGL="; lgl / p
    'Line (X - 800, Y - fsd)-(X + bw + 800, Y - fsd) 'fsd line
    'Print "fsd="; fsd / p

    '        Label1.Caption = bw / p

    'Dim e As PaintEventArgs = Nothing

    'e.Graphics.DrawRectangle(Pens.DarkMagenta, 20, 20, 85, 30)

    '    Public Sub DrawRectangleFloat(ByVal e As PaintEventArgs)
    '        ' Create pen.
    'Dim e As New PaintEventArgs()

    'Private Sub panel1_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles panel1.Paint

    'Dim blackPen As New Pen(Color.Black, 3)
    '' Create location and size of rectangle.
    'Dim x As Single = 0.0F
    'Dim y As Single = 0.0F
    'Dim width As Single = 200.0F
    'Dim height As Single = 200.0F
    '' Draw rectangle to screen.
    '    e.Graphics.DrawRectangle(blackPen, x, y, width, height)
    ''    End Sub

    'End Sub

    Public Sub Rotan(ByVal fn As String, ByVal RStrtPt() As String, ByVal Ang As Double)

        Try

            Ang = Math.Round(Ang, 2)

            off.WriteLine("rotation " & CStr(RStrtPt(0)) & " " & CStr(RStrtPt(1)) & " " & CStr(RStrtPt(2)) & " " & CStr(Ang))

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in Rotan", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub Rotans(ByVal fn As String, ByVal RStrtPt() As String, ByVal Ang As Double)

        Try

            Ang = Math.Round(Ang, 2)

            Iow.WriteLine("rotation " & CStr(RStrtPt(0)) & " " & CStr(RStrtPt(1)) & " " & CStr(RStrtPt(2)) & " " & CStr(Ang))

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in Rotan", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub DiffCol(ByVal fn As String, ByVal Grd As String, ByVal Col As String)

        Try

            If Col = "r" Then
                off.WriteLine("diffuseColor 1 0 0")
            ElseIf Col = "g" Then
                off.WriteLine("diffuseColor 0 1 0")
            ElseIf Col = "b" Then
                off.WriteLine("diffuseColor 0 0 1")
            ElseIf Col = "m" Then
                off.WriteLine("diffuseColor 0 1 1")
            ElseIf Col = "c" Then
                off.WriteLine("diffuseColor 1 0 1")
            ElseIf Col = "y" Then
                off.WriteLine("diffuseColor 1 1 0")
            Else
                off.WriteLine("diffuseColor 1 1 1")
            End If

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in DiiffCol", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub DifusColr(ByVal fn As String, ByVal grd As String, ByVal col As String)

        Try
            Try
                If col = "r" Then
                    off.WriteLine("diffuseColor 1 0 0")
                    'PrintLine(1, "material USE Matr")
                ElseIf col = "g" Then
                    off.WriteLine("diffuseColor 0 1 0")
                ElseIf col = "b" Then
                    off.WriteLine("diffuseColor 0 0 1")
                ElseIf col = "m" Then
                    off.WriteLine("diffuseColor 0 1 1")
                ElseIf col = "c" Then
                    off.WriteLine("diffuseColor 1 0 1")
                ElseIf col = "y" Then
                    off.WriteLine("diffuseColor 1 1 0")
                Else
                    If col.Length > 1 Then
                        off.WriteLine("diffuseColor " & col)
                    Else
                        off.WriteLine("diffuseColor 1 1 1")
                    End If
                End If
            Catch
                If col = "r" Then
                    Iow.WriteLine("diffuseColor 1 0 0")
                    'PrintLine(1, "material USE Matr")
                ElseIf col = "g" Then
                    Iow.WriteLine("diffuseColor 0 1 0")
                ElseIf col = "b" Then
                    Iow.WriteLine("diffuseColor 0 0 1")
                ElseIf col = "m" Then
                    Iow.WriteLine("diffuseColor 0 1 1")
                ElseIf col = "c" Then
                    Iow.WriteLine("diffuseColor 1 0 1")
                ElseIf col = "y" Then
                    Iow.WriteLine("diffuseColor 1 1 0")
                Else
                    If col.Length > 1 Then
                        Iow.WriteLine("diffuseColor " & col)
                    Else
                        Iow.WriteLine("diffuseColor 1 1 1")
                    End If
                    '                Iow.WriteLine("diffuseColor 1 1 1")
                End If
            End Try

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in DiffColr", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub Transprncy(ByVal FNm As String, ByVal Grd As String, ByVal Col As String)

        Try
            Try
                off.WriteLine("transparency " & Grd)
                off.WriteLine("}")
            Catch
                Iow.WriteLine("transparency " & Grd)
                Iow.WriteLine("}")
            End Try

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in Transprncy", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub BoxCounterRw(ByVal DgCntR As Int64, ByVal BxIncQt As Int64, ByVal Inm As String)

        Try

            TransactionMenu.lblStatus.Text = "Stuffing item :: " & Inm & Chr(13) & "Numbers :: " & CStr(DgCntR) & " -> Items stuffed && " & vbCrLf & "Incremental count :: " & CStr(BxIncQt)
            TransactionMenu.lblStatus.Refresh()

            TransactionMenu.pbCSP1.Visible = True
            ProgressBarRunning()

            BitemqtyInr = BitemqtyInr + 1

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in BoxCounterRw", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub InsrtBxData(ByVal MtrlNm As String, ByVal X As Double, ByVal Y As Double, ByVal z As Double, ByVal L As Double, ByVal W As Double, ByVal H As Double, ByVal Method As Integer, ByVal Col As String, ByVal png As String, ByVal Qtybx As Int64)

        'Stop
        Try
            Dim Cmd As New OleDb.OleDbCommand
            Cmd.Connection = conn
            Cmd.CommandText = "insert into BoxStuffData values('" & MtrlNm & "'," & CStr(X) & "," & CStr(Y) & "," & CStr(z) & "," & CStr(L) & "," & CStr(W) & "," & CStr(H) & "," & CStr(Method) & ",'" & Col & "','" & png & "','" & CStr(Qtybx) & "')"
            Cmd.ExecuteNonQuery()
            'conn.Close()  'Do not Close Connection Here 
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in InsrtBxData", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub CGGenrate(ByVal MtlNm As String, ByVal X As Double, ByVal Y As Double, ByVal Z As Double, ByVal Ln As Double, ByVal Wd As Double, ByVal Ht As Double, ByVal Method As Integer, ByVal Col As String, ByVal png As String, ByVal Wt As Double)

        Try
            Dim Xmom As Double
            Dim Ymom As Double
            Dim Zmom As Double

            Xmom = (X + (Ln * 0.5)) * Wt
            Ymom = (Y + (Wd * 0.5)) * Wt
            Zmom = (Z + (Ht * 0.5)) * Wt

            Dim Cmd As New OleDb.OleDbCommand
            Cmd.Connection = conn
            Cmd.CommandText = "insert into CGsGen values('" & MtlNm & "'," & CStr(X) & "," & CStr(Y) & "," & CStr(Z) & "," & CStr(Ln) & "," & CStr(Wd) & "," & CStr(Ht) & "," & CStr(Method) & ",'" & Col & "','" & png & "'," & CStr(Wt) & "," & CStr(Xmom) & "," & CStr(Ymom) & "," & CStr(Zmom) & ")"
            Cmd.ExecuteNonQuery()

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in CGGenrate", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub AutostuffFlw()

        Try
            Call DbTrackDel()
            Call TransactionMenu.InsrtDgvDbAutoStuff()
            Call TransactionMenu.FlowDgvDataMngAutoStuff()
        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in AutostuffFlw", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub AutostuffFlwClMn()

        Try
            Call DbTrackDel()
            Call TransactionMenu.InsrtDgvDbAutoStuff()
            Call TransactionMenu.FlowDgvDataMngAutoStuffRandC()
        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in row & then column type auto stuff", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub FlowDgvChng()

        'Stop
        Try
            DbTrackDel()
            TransactionMenu.InsrtDgvDb()
            TransactionMenu.FlowDgvDataMng()

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in FlowDgvChng", "Error....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub DbsManipulate()

        Try

            'If OConn.State = ConnectionState.Closed Then OConn.Open()

            'Dim cmd As New OracleClient.OracleCommand
            'cmd.Connection = OConn
            'cmd.CommandText = "delete * from STUFFBOXDATA"
            'cmd.ExecuteNonQuery()

            MsgBox("Insert proprely")
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim cmda As New OleDb.OleDbCommand
            Dim Rdr As OleDb.OleDbDataReader
            cmda.Connection = conn
            cmda.CommandText = "select Itemname, x, y, z, l, w, h, method, color, imgname, qty from boxstuffdata"
            Rdr = cmda.ExecuteReader
            Do While (Rdr.Read())
            Loop

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in DbsManipulate", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub WadRemv(ByVal Lst As List(Of String), ByVal Itm As String)

        Try

            For i As Integer = 0 To Lst.Count - 1
                Lst.Remove(Itm)
            Next

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in WadRemv", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub TransWad(ByVal fN As String, ByVal StrtPt() As String)

        Try
            off.WriteLine("translation " & CStr(StrtPt(0)) & " " & CStr(StrtPt(1)) & " " & CStr(StrtPt(2)))
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in TransWad", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub SetPolygonWad(ByVal fN As String, ByVal SzArr() As String, ByVal ItmNm As String, ByVal WtItm As Single, ByVal QtyFlg As Boolean)

        Try
            Dim dq As Char = Chr(34)
            Static Qty As Integer

            If QtyFlg Then
                Qty = 1
            End If

            Qty += 1

            off.WriteLine("Shape {")
            off.WriteLine("geometry Box {")
            off.WriteLine("size " & CStr(SzArr(0)) & " " & CStr(SzArr(1)) & " " & CStr(SzArr(2)))
            off.WriteLine("}")

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in SetPolygonWad", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub DifusColrWad(ByVal fN As String, ByVal Grd As String, ByVal Colr As String)

        Try
            If Colr = "r" Then
                off.WriteLine("diffuseColor 1 0 0")
            ElseIf Colr = "g" Then
                off.WriteLine("diffuseColor 0 1 0")
            ElseIf Colr = "b" Then
                off.WriteLine("diffuseColor 0 0 1")
            ElseIf Colr = "m" Then
                off.WriteLine("diffuseColor 0 1 1")
            ElseIf Colr = "c" Then
                off.WriteLine("diffuseColor 1 0 1")
            ElseIf Colr = "y" Then
                off.WriteLine("diffuseColor 1 1 0")
            Else
                off.WriteLine("diffuseColor 1 1 1")
            End If

        Catch Exx As Exception
            MsgBox(Exx.Message)
            MsgBox(Exx.ToString)
            MessageBox.Show("Error in DifusColrWad", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub TransWad(ByVal fN As String, ByVal Grd As String, ByVal Colr As String)

        Try
            off.WriteLine("Transparency " & Grd)
            off.WriteLine("}")
        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in TransWad", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub VertexBoxInsrt(ByVal LVertx As List(Of List(Of Vertex)), ByVal MtlNm As String, ByVal Mthd As Integer)       'Public Sub VertexBoxInsrt(ByVal MtlNm As String, ByVal vIx As Double, ByVal vIy As Double, ByVal vIz As Double, ByVal vIIx As Double, ByVal vIIy As Double, ByVal vIIz As Double, ByVal vIIIx As Double, ByVal vIIIy As Double, ByVal vIIIz As Double, ByVal vIVx As Double, ByVal vIVy As Double, ByVal vIVz As Double, ByVal vVx As Double, ByVal vVy As Double, ByVal vVz As Double, ByVal vVIx As Double, ByVal vVIy As Double, ByVal vVIz As Double, ByVal vVIIx As Double, ByVal vVIIy As Double, ByVal vVIIz As Double, ByVal vVIIIx As Double, ByVal vVIIIy As Double, ByVal vVIIIz As Double, ByVal Mthd As Integer)

        Dim Qty As Integer = BitemqtyInr

        Dim Cmd As New OleDb.OleDbCommand

        Dim i As Integer
        Dim Vtx As Vertex = LVertx.Item(0).Item(i)

        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            Cmd.Connection = conn
            Cmd.CommandText = "insert into Vertex values(" & CStr(Qty) & ",'" & MtlNm & "'," & CStr(LVertx.Item(0).Item(0).Vx) & "," & CStr(LVertx.Item(0).Item(0).Vy) & "," & CStr(LVertx.Item(0).Item(0).Vz) & "," & CStr(LVertx.Item(0).Item(1).Vx) & "," & CStr(LVertx.Item(0).Item(1).Vy) & "," & CStr(LVertx.Item(0).Item(1).Vz) & "," & CStr(LVertx.Item(0).Item(2).Vx) & "," & CStr(LVertx.Item(0).Item(2).Vy) & "," & CStr(LVertx.Item(0).Item(2).Vz) & "," & CStr(LVertx.Item(0).Item(3).Vx) & "," & CStr(LVertx.Item(0).Item(3).Vy) & "," & CStr(LVertx.Item(0).Item(3).Vz) & "," & CStr(LVertx.Item(0).Item(4).Vx) & "," & CStr(LVertx.Item(0).Item(4).Vy) & "," & CStr(LVertx.Item(0).Item(4).Vz) & "," & CStr(LVertx.Item(0).Item(5).Vx) & "," & CStr(LVertx.Item(0).Item(5).Vy) & "," & CStr(LVertx.Item(0).Item(5).Vz) & "," & CStr(LVertx.Item(0).Item(6).Vx) & "," & CStr(LVertx.Item(0).Item(6).Vy) & "," & CStr(LVertx.Item(0).Item(6).Vz) & "," & CStr(LVertx.Item(0).Item(7).Vx) & "," & CStr(LVertx.Item(0).Item(7).Vy) & "," & CStr(LVertx.Item(0).Item(7).Vz) & "," & CStr(Mthd) & ")"
            Cmd.ExecuteNonQuery()
            'Stop
        Catch exErr As Exception
            MsgBox(exErr.Message)
            MsgBox(exErr.ToString)
            MessageBox.Show("Error in VertexBoxInsrt", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

#Region "Function Definition"

    Public Function StuffPly(ByVal arc As Area, ByVal ar As Area, ByVal drwarc As Boolean, ByVal drawopt As Boolean, ByVal Qty2 As Integer, ByVal ItmNm As String) As Integer
        'Stop
        Try
            Dim TotQty As Integer
            Dim Qty As Integer
            Dim PlyLst As New List(Of Area)
            Dim Ari As New Area

            Dim BxPt As New OptMthd.OptMthd.FndOptMthd.Areas
            Dim CnPt As New OptMthd.OptMthd.FndOptMthd.Areas
            Dim FoptMth As New OptMthd.OptMthd.FndOptMthd

            BxPt.StrtPt.x = ar.StrtPt.x
            BxPt.StrtPt.y = ar.StrtPt.y
            BxPt.StrtPt.z = ar.StrtPt.z
            BxPt.length = ar.length
            BxPt.width = ar.width
            BxPt.height = ar.height

            CnPt.length = arc.length
            CnPt.width = arc.width
            CnPt.height = arc.height

            Ari.StrtPt.x = ar.StrtPt.x
            Ari.StrtPt.y = ar.StrtPt.y
            Ari.StrtPt.z = ar.StrtPt.z
            Ari.length = ar.length
            Ari.width = ar.width
            Ari.height = ar.height

            Dim Mthd As Integer = FoptMth.FindOptMethod(BxPt, CnPt, Qty, False)               'FindOptMethod(Ari, arc, Qty, False)

            If Qty > 0 Then
                Dim ln As Double = Ari.length
                Dim wd As Double = Ari.width
                Dim ht As Double = Ari.height

                If Mthd = 1 Then
                    Ari.length = ln
                    Ari.width = wd
                    Ari.height = ht

                End If

                If Mthd = 2 Then
                    Ari.length = ln
                    Ari.width = ht
                    Ari.height = wd

                End If

                If Mthd = 3 Then
                    Ari.length = wd
                    Ari.width = ht
                    Ari.height = ln

                End If

                If Mthd = 4 Then
                    Ari.length = wd
                    Ari.width = ln
                    Ari.height = ht

                End If

                If Mthd = 5 Then
                    Ari.length = ht
                    Ari.width = wd
                    Ari.height = ln

                End If

                If Mthd = 6 Then
                    Ari.length = ht
                    Ari.width = ln
                    Ari.height = wd

                End If
            End If

            ' Dim PlyDrwLst As New List(Of Area)

            PlyDrwLst = DrawOptPly(arc, Ari, "", "", 1, ItmNm, 1, False, False, Qty2, drawopt, Qty)

            TotQty = TotQty + Qty

            Return TotQty

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in StuffPly", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function

    Public Function DrawOptPly(ByVal ArC As Area, ByVal ArI As Area, ByVal fl As String, ByVal col As String, ByVal traval As Single, ByVal itmnm As String, ByVal wt As Single, ByVal qtyflg As Boolean, ByVal txtopt As Boolean, ByVal qty As Integer, ByVal drawopt As Boolean, ByRef outqty As Integer) As List(Of Area)
        'Stop
        Dim Lncnt As Integer
        Dim Wdcnt As Integer
        Dim Htcnt As Integer
        Dim Ar As New Area
        Dim ArPly As New Area
        Dim RetLst As New List(Of Area)

        Try
            Lncnt = CInt(Math.Floor(ArC.length / ArI.length))
            Wdcnt = CInt(Math.Floor(ArC.width / ArI.width))
            Htcnt = CInt(Math.Floor(ArC.height / ArI.height))

            Dim bcol1 As String = "r"

            With TransactionMenu.dgv1.Rows(PlyIno).HeaderCell.Style.BackColor
                TransactionMenu.pbCSP1.ForeColor = TransactionMenu.dgv1.Rows(PlyIno).HeaderCell.Style.BackColor
                bcol1 = Math.Round(.R / 255, 2) & " " & Math.Round(.G / 255, 2) & " " & Math.Round(.B / 255, 2)
            End With

            If bcol1 <> "0 0 0" Then Bcol = bcol1

            If PlyInm <> itmnm Then
                PlyIno += 1
            End If

            PlyInm = itmnm

            If Bcol.Length = 1 Then
                Dim colnum As Short = PlyIno
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

            End If

            Ar.length = ArI.length
            Ar.width = ArI.width
            Ar.height = ArI.height

            Dim cnt As Integer = 0

            For i As Integer = 0 To Lncnt - 1

                Ar.StrtPt.x = ArI.StrtPt.x + (i * Ar.length)

                ArPly.StrtPt.x = Ar.StrtPt.x
                ArPly.length = i * Ar.length

                For k As Integer = 0 To Htcnt - 1

                    Ar.StrtPt.z = ArI.StrtPt.z + (k * Ar.height)

                    ArPly.StrtPt.z = Ar.StrtPt.z
                    ArPly.height = k * Ar.height

                    For j As Integer = 0 To Wdcnt - 1

                        Ar.StrtPt.y = ArI.StrtPt.y + (j * Ar.width)
                        ArPly.StrtPt.y = Ar.StrtPt.y
                        ArPly.width = j * Ar.width
                        RetLst.Add(ArPly)

                        cnt += 1

                        Call ProgressBarRunning()

                        If cnt > qty Then
                            outqty = cnt
                            Return RetLst
                            Exit Function
                        End If

                        If drawopt Then
                            'Ar.AutoDraw(CurDir() & "\First.wrl", "r", 0, "file:///c:/s1.png", itmnm, wt, qtyflg, txtopt, itmnm, 0, True, "b", "1")
                            Ar.AutoDraw(CurDir() & "\First.wrl", Bcol, 0, CurDir() & "\Graphics/s" & PlyIno & ".png", itmnm, wt, qtyflg, txtopt, itmnm, 0, True, "b", "1")

                        End If
                    Next
                Next

            Next

            RetLst.Add(ArPly)
            Return RetLst

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in DrawOptPly", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return RetLst

    End Function

    Public Function Buncher(ByVal Ln As Double, ByVal Wd As Double, ByVal Ht As Double, ByVal cLn As Double, ByVal cWd As Double, ByVal cHt As Double, ByVal Qtyply As Integer, ByVal tpup As Boolean) As Boolean

        Try

            Dim BxPt As New OptMthd.OptMthd.FndOptMthd.Areas
            Dim ContPt As New OptMthd.OptMthd.FndOptMthd.Areas
            Dim fndOptMthd As New OptMthd.OptMthd.FndOptMthd
            Dim qtyOr As Long = Qtyply

            BxPt.length = Ln
            BxPt.width = Wd
            BxPt.height = Ht

            ContPt.length = cLn
            ContPt.width = cWd
            ContPt.height = cHt

            Dim Omth As Integer = fndOptMthd.FindOptMethod(BxPt, ContPt, Qtyply, tpup)

            If Qtyply > 0 Then

                Dim Bxln As Double = BxPt.length
                Dim Bxwd As Double = BxPt.width
                Dim Bxht As Double = BxPt.height

                If Omth = 1 Then
                    BxPt.length = Bxln
                    BxPt.width = Bxwd
                    BxPt.height = Bxht

                End If

                If Omth = 2 Then
                    BxPt.length = Bxln
                    BxPt.width = Bxht
                    BxPt.height = Bxwd

                End If

                If Omth = 3 Then
                    BxPt.length = Bxwd
                    BxPt.width = Bxht
                    BxPt.height = Bxln

                End If

                If Omth = 4 Then
                    BxPt.length = Bxwd
                    BxPt.width = Bxln
                    BxPt.height = Bxht

                End If

                If Omth = 5 Then
                    BxPt.length = Bxht
                    BxPt.width = Bxwd
                    BxPt.height = Bxln

                End If

                If Omth = 6 Then
                    BxPt.length = Bxht
                    BxPt.width = Bxln
                    BxPt.height = Bxwd

                End If

            End If

            Dim Qxx As Double
            Dim Qyy As Double
            Dim Qzz As Double
            Dim Qz As Long
            Dim Qy As Long
            Dim Qx As Long

            Dim Frcl As Long
            Dim Rcnt As Long
            Dim FnlQty As Long
            Dim RemnQty As Long

            Dim UQty As Long = qtyOr

            Qxx = cLn / BxPt.length
            Qyy = cWd / BxPt.width
            Qzz = cHt / BxPt.height

            Qz = Math.Floor(Qzz)
            Qy = Math.Floor(Qyy)
            Qx = Math.Floor(Qxx)

            Frcl = Qz * Qy
            Rcnt = UQty / Frcl
            FnlQty = Rcnt * Frcl
            RemnQty = UQty - FnlQty

            'If RemnQty < 0 Then
            '    RemnQty = -RemnQty
            'End If

            'If FnlQty = 0 Then
            '    FnlQty = RemnQty
            '    RemnQty = 0
            'End If

            '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            'The final quantity is greater than the user enter quantity the logic to assign the final quantity and reamining quantity

            'If FnlQty > UQty Then
            '    FnlQty = UQty
            '    RemnQty = 0
            'Else
            '    FnlQty = FnlQty
            'End If

            'If FnlQty > UQty Then

            '    Dim cQ As Double = UQty / FrcL

            '    cQ = Math.Floor(cQ)

            '    If Not cQ <= 0 Then

            '        FnlQty = FrcL * cQ

            '        RemnQty = UQty - FnlQty

            '    ElseIf FnlQty > UQty Then

            '        FnlQty = UQty
            '        RemnQty = 0

            '    End If

            'Else

            '    FnlQty = FnlQty
            '    RemnQty = RemnQty

            'End If

            If RemnQty = 0 Then
                Return True
            End If
            If RemnQty <> 0 Then
                Return False
            End If

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in Greater", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return Nothing

    End Function

    Public Function Greater(ByVal Ln As Double, ByVal Wd As Double, ByVal Ht As Double, ByVal cLn As Double, ByVal cWd As Double, ByVal cHt As Double, ByVal Qtyply As Integer, ByVal tpup As Boolean)

        Try
            Dim Max As Double

            Dim BxPt As New OptMthd.OptMthd.FndOptMthd.Areas
            Dim ContPt As New OptMthd.OptMthd.FndOptMthd.Areas
            Dim fndOptMthd As New OptMthd.OptMthd.FndOptMthd

            BxPt.length = Ln
            BxPt.width = Wd
            BxPt.height = Ht

            ContPt.length = cLn
            ContPt.width = cWd
            ContPt.height = cHt

            Dim Omth As Integer = fndOptMthd.FindOptMethod(BxPt, ContPt, Qtyply, tpup)

            If Qtyply > 0 Then

                Dim Bxln As Double = BxPt.length
                Dim Bxwd As Double = BxPt.width
                Dim Bxht As Double = BxPt.height

                If Omth = 1 Then
                    BxPt.length = Bxln
                    BxPt.width = Bxwd
                    BxPt.height = Bxht

                End If

                If Omth = 2 Then
                    BxPt.length = Bxln
                    BxPt.width = Bxht
                    BxPt.height = Bxwd

                End If

                If Omth = 3 Then
                    BxPt.length = Bxwd
                    BxPt.width = Bxht
                    BxPt.height = Bxln

                End If

                If Omth = 4 Then
                    BxPt.length = Bxwd
                    BxPt.width = Bxln
                    BxPt.height = Bxht

                End If

                If Omth = 5 Then
                    BxPt.length = Bxht
                    BxPt.width = Bxwd
                    BxPt.height = Bxln

                End If

                If Omth = 6 Then
                    BxPt.length = Bxht
                    BxPt.width = Bxln
                    BxPt.height = Bxwd

                End If

            End If

            Max = BxPt.length

            'Try

            'If Ln > Wd Then
            '    Max = Ln
            'ElseIf Ln > Ht Then
            '    Max = Ln
            'ElseIf Wd > Ht Then
            '    Max = Wd
            'ElseIf Wd > Ln Then
            '    Max = Wd
            'ElseIf Ht > Ln Then
            '    Max = Ht
            'ElseIf Ht > Ln Then
            '    Max = Ht
            'Else
            '    Return Nothing
            'End If

            If Max > 0 Then
                Return Max
            Else
                Return Nothing
            End If

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in Greater", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return Nothing

    End Function


    ' This function is collecting the value of remaining area (ArtVal) and 
    ' respective vertex points and collecting the previous vertex points (ArsVal) and the current quantity
    ' placed dimensions in area (Arj) of that object also the respective area and vertex points targeting 
    ' index (Arm) value.
    ' These function is to check the placing quantity with respect to next quantity with zero 
    ' gap maintain in between these two quantity if gap is found deduct the gap in particular 
    ' dimensions and also the gap is subtract in to that particular area so the other quantity 
    ' is shifting towards that particular gap and the dimensions are fill in that gap and maintaining 
    ' no gap between the two quantity and occupy the particular area.

    Public Function CollectArt(ByVal ArtVal As Area, ByVal Arm As Integer, ByVal ArsVal As Area, ByVal Arj As Area, ByVal ImgNm As String) As Area

        'Implements from here

        If BitemqtyInr = 53 Or BitemqtyInr = 54 Then
            'Stop
        End If

        If BitemqtyInr = 59 Or BitemqtyInr = 60 Then
            'Stop
        End If

        If CInt(CAimgnm) <> CInt(ImgNm) Then

            fXmax = xMax

        End If

        CAimgnm = ImgNm

        'off.Close()

        Dim cArt As New Area

        If ArtVal.StrtPt.y = ArsVal.StrtPt.y + Arj.width Or ArtVal.StrtPt.x = ArsVal.StrtPt.x Then
            'Stop
            cArt.StrtPt.x = ArtVal.StrtPt.x

            If CAflg Then

                If ArtVal.StrtPt.y = 0 Then
                    cArt.StrtPt.y = ArtVal.StrtPt.y
                ElseIf ArtVal.StrtPt.y <> 0 Then
                    Dim Yax As Double = ArtVal.StrtPt.y - Arj.width
                    cArt.StrtPt.y = ArtVal.StrtPt.y - Yax
                    'cArt.width = ArtVal.width + Yax
                    CAflg = True
                Else
                    CAflg = False
                End If

                'Dim Yax As Double = ArtVal.StrtPt.y - Arj.width
                'cArt.StrtPt.y = ArtVal.StrtPt.y - Yax
            Else
                cArt.StrtPt.y = ArtVal.StrtPt.y
            End If

            cArt.StrtPt.z = ArtVal.StrtPt.z
            cArt.length = ArtVal.length
            cArt.width = ArtVal.width
            cArt.height = ArtVal.height

            xMax = cArt.StrtPt.x + Arj.length


        ElseIf ArtVal.StrtPt.y <> ArsVal.StrtPt.y + Arj.width AndAlso ArtVal.StrtPt.x > ArsVal.StrtPt.x AndAlso ArtVal.StrtPt.y <> 0 Then

            cArt.StrtPt.x = ArtVal.StrtPt.x
            cArt.StrtPt.y = ArsVal.StrtPt.y + Arj.width
            cArt.StrtPt.z = ArtVal.StrtPt.z

            If (cArt.StrtPt.y + Arj.width) > CW Or (cArt.StrtPt.y + Arj.length) > CW Then
                GoTo cNxt
            End If

            Dim Yyas As Double = ArtVal.StrtPt.y - cArt.StrtPt.y

            If Yyas < 0 Then
                Yyas = 0
            End If

            cArt.length = ArtVal.length
            cArt.width = ArtVal.width + Yyas
            cArt.height = ArtVal.height

        Else

            xMax = ArtVal.StrtPt.x + Arj.length

cNxt:

            cArt = ArtVal

            If cArt.StrtPt.x < fXmax Then

                cArt.StrtPt.x = fXmax
                'cArt.StrtPt.y = ArtVal.StrtPt.y
                'cArt.StrtPt.z = ArtVal.StrtPt.z
                'cArt.length = ArtVal.length
                'cArt.width = ArtVal.width
                'cArt.height = ArtVal.height

                If CAflg Then
                    CAflg = False
                Else
                    CAflg = True
                End If

                'If ArtVal.StrtPt.y = 0 Then
                '    cArt.StrtPt.y = ArtVal.StrtPt.y
                'Else
                '    Dim Yax As Double = ArtVal.StrtPt.y - Arj.width
                '    cArt.StrtPt.y = ArtVal.StrtPt.y - Yax
                '    CAflg = True
                'End If

            End If

        End If

        Dim Cmd As New OleDb.OleDbCommand

        Try
            If Not ArtVal Is Nothing Then
                If conn.State = ConnectionState.Closed Then conn.Open()
                Cmd.Connection = conn
                Cmd.CommandText = "insert into ArtData values(" & cArt.length & "," & cArt.width & "," & cArt.height & "," & cArt.StrtPt.x & "," & cArt.StrtPt.y & "," & cArt.StrtPt.z & "," & Arm & "," & Arj.length & "," & Arj.width & "," & Arj.height & ")"
                Cmd.ExecuteNonQuery()
            End If

        Catch Exx As Exception
            MsgBox(Exx.Message)
            MsgBox(Exx.ToString)
            MessageBox.Show("Error in CollectArt", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return cArt

    End Function

    Public Function SCollectArt(ByVal ArtVal As Area, ByVal Arm As Integer, ByVal ArsVal As Area, ByVal Arj As Area, ByVal ImgNm As String) As Area

        'Implements from here

        If BitemqtyInr = 225 Or BitemqtyInr = 226 Then
            'Stop
        End If

        If BitemqtyInr = 56 Or BitemqtyInr = 57 Then
            'Stop
        End If

        If BitemqtyInr = 151 Or BitemqtyInr = 150 Then

        End If
        'Stop

        'off.Close()

        Dim cArt As New Area

        If ArtVal.StrtPt.y = ArsVal.StrtPt.y + Arj.width Or ArtVal.StrtPt.x = ArsVal.StrtPt.x Then
            'Stop
            cArt.StrtPt.x = ArtVal.StrtPt.x
            cArt.StrtPt.y = ArtVal.StrtPt.y
            cArt.StrtPt.z = ArtVal.StrtPt.z
            cArt.length = ArtVal.length
            cArt.width = ArtVal.width
            cArt.height = ArtVal.height

        ElseIf ArtVal.StrtPt.y <> ArsVal.StrtPt.y + Arj.width AndAlso ArtVal.StrtPt.x > ArsVal.StrtPt.x AndAlso ArtVal.StrtPt.y <> 0 Then

            cArt.StrtPt.x = ArtVal.StrtPt.x
            cArt.StrtPt.y = ArsVal.StrtPt.y + Arj.width
            cArt.StrtPt.z = ArtVal.StrtPt.z

            If (cArt.StrtPt.y + Arj.width) > CW Or (cArt.StrtPt.y + Arj.length) > CW Then
                GoTo cNxt
            End If

            Dim Yyas As Double = ArtVal.StrtPt.y - cArt.StrtPt.y

            If Yyas < 0 Then
                Yyas = 0
            End If

            cArt.length = ArtVal.length
            cArt.width = ArtVal.width + Yyas
            cArt.height = ArtVal.height

        Else

cNxt:

            cArt = ArtVal

        End If

        Dim Cmd As New OleDb.OleDbCommand

        Try
            If Not ArtVal Is Nothing Then
                If conn.State = ConnectionState.Closed Then conn.Open()
                Cmd.Connection = conn
                Cmd.CommandText = "insert into ArtData values(" & cArt.length & "," & cArt.width & "," & cArt.height & "," & cArt.StrtPt.x & "," & cArt.StrtPt.y & "," & cArt.StrtPt.z & "," & Arm & "," & Arj.length & "," & Arj.width & "," & Arj.height & ")"
                Cmd.ExecuteNonQuery()
            End If

        Catch Exx As Exception
            MsgBox(Exx.Message)
            MsgBox(Exx.ToString)
            MessageBox.Show("Error in CollectArt", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return cArt

    End Function

    Public Function BCollectArt(ByVal ArtVal As Area, ByVal Arm As Integer, ByVal ArsVal As Area, ByVal Arj As Area, ByVal ImgNm As String) As Area

        'Implements from here

        If BitemqtyInr = 225 Or BitemqtyInr = 226 Then
            'Stop
        End If

        If BitemqtyInr = 56 Or BitemqtyInr = 57 Then
            'Stop
        End If

        'off.Close()

        Dim cArt As New Area

        If ArtVal.StrtPt.y = ArsVal.StrtPt.y + Arj.width Or ArtVal.StrtPt.x = ArsVal.StrtPt.x Then
            'Stop
            cArt.StrtPt.x = ArtVal.StrtPt.x
            cArt.StrtPt.y = ArtVal.StrtPt.y
            cArt.StrtPt.z = ArtVal.StrtPt.z
            cArt.length = ArtVal.length
            cArt.width = ArtVal.width
            cArt.height = ArtVal.height

        ElseIf ArtVal.StrtPt.y <> ArsVal.StrtPt.y + Arj.width AndAlso ArtVal.StrtPt.x > ArsVal.StrtPt.x AndAlso ArtVal.StrtPt.y <> 0 Then

            cArt.StrtPt.x = ArtVal.StrtPt.x
            cArt.StrtPt.y = ArsVal.StrtPt.y + Arj.width
            cArt.StrtPt.z = ArtVal.StrtPt.z


            If (cArt.StrtPt.y + Arj.width) > CW Or (cArt.StrtPt.y + Arj.length) > CW Then
                GoTo cNxt
            End If

            Dim Yyas As Double = ArtVal.StrtPt.y - cArt.StrtPt.y

            Dim YDis As Double = cArt.StrtPt.y + Yyas

            If YDis < cArt.StrtPt.y Then
                cArt.StrtPt.y = YDis
            End If

            If Yyas < 0 Then
                Yyas = 0
            End If

            cArt.length = ArtVal.length
            cArt.width = ArtVal.width + Yyas
            cArt.height = ArtVal.height

        Else

cNxt:

            cArt = ArtVal

        End If

        Dim Cmd As New OleDb.OleDbCommand

        Try
            If Not ArtVal Is Nothing Then
                If conn.State = ConnectionState.Closed Then conn.Open()
                Cmd.Connection = conn
                Cmd.CommandText = "insert into ArtData values(" & cArt.length & "," & cArt.width & "," & cArt.height & "," & cArt.StrtPt.x & "," & cArt.StrtPt.y & "," & cArt.StrtPt.z & "," & Arm & "," & Arj.length & "," & Arj.width & "," & Arj.height & ")"
                Cmd.ExecuteNonQuery()
            End If

        Catch Exx As Exception
            MsgBox(Exx.Message)
            MsgBox(Exx.ToString)
            MessageBox.Show("Error in CollectArt", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return cArt

    End Function

    Public Function PCollectArt(ByVal ArtVal As Area, ByVal Arm As Integer, ByVal ArsVal As Area, ByVal Arj As Area, ByVal ImgNm As String) As Area

        'Implements from here

        If BitemqtyInr = 53 Or BitemqtyInr = 54 Then
            'Stop
        End If

        If BitemqtyInr = 56 Or BitemqtyInr = 57 Then
            'Stop
        End If

        'off.Close()

        Dim cArt As New Area

        If ArtVal.StrtPt.y = ArsVal.StrtPt.y + Arj.width Or ArtVal.StrtPt.x = ArsVal.StrtPt.x Then
            'Stop
            cArt.StrtPt.x = ArtVal.StrtPt.x
            cArt.StrtPt.y = ArtVal.StrtPt.y
            cArt.StrtPt.z = ArtVal.StrtPt.z
            cArt.length = ArtVal.length
            cArt.width = ArtVal.width
            cArt.height = ArtVal.height

        ElseIf ArtVal.StrtPt.y <> ArsVal.StrtPt.y + Arj.width AndAlso ArtVal.StrtPt.x > ArsVal.StrtPt.x AndAlso ArtVal.StrtPt.y <> 0 Then

            cArt.StrtPt.x = ArtVal.StrtPt.x
            cArt.StrtPt.y = ArsVal.StrtPt.y + Arj.width
            cArt.StrtPt.z = ArtVal.StrtPt.z

            If (cArt.StrtPt.y + Arj.width) > CW Or (cArt.StrtPt.y + Arj.length) > CW Then
                GoTo cNxt
            End If

            Dim Yyas As Double = ArtVal.StrtPt.y - cArt.StrtPt.y

            If Yyas < 0 Then
                Yyas = 0
            End If

            cArt.length = ArtVal.length
            cArt.width = ArtVal.width + Yyas
            cArt.height = ArtVal.height

        Else

cNxt:

            cArt = ArtVal

        End If

        Dim Cmd As New OleDb.OleDbCommand

        Try
            If Not ArtVal Is Nothing Then
                If conn.State = ConnectionState.Closed Then conn.Open()
                Cmd.Connection = conn
                Cmd.CommandText = "insert into ArtData values(" & cArt.length & "," & cArt.width & "," & cArt.height & "," & cArt.StrtPt.x & "," & cArt.StrtPt.y & "," & cArt.StrtPt.z & "," & Arm & ")"
                Cmd.ExecuteNonQuery()
            End If

        Catch Exx As Exception
            MsgBox(Exx.Message)
            MsgBox(Exx.ToString)
            MessageBox.Show("Error in CollectArt", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return cArt

    End Function

    Public Function WadFtip(ByVal arc As Area, ByVal ari As Area, ByVal tpup As Boolean) As Boolean

        Dim clength As Double = arc.length
        Dim cwidth As Double = arc.width
        Dim cheight As Double = arc.height

        Dim ilength As Double = ari.length
        Dim iwidth As Double = ari.width
        Dim iheight As Double = ari.height

        Dim pX As Double = arc.StrtPt.x
        Dim pY As Double = arc.StrtPt.y
        Dim pZ As Double = arc.StrtPt.z

        Dim lstl As New List(Of String)
        Dim lstw As New List(Of String)
        Dim lsth As New List(Of String)
        Dim ordr As New List(Of List(Of String))
        Dim ordr1 As New List(Of String)
        Dim out As New List(Of String)
        Dim itm As String

        If ilength <= clength Then
            lstl.Add("clength")
        End If

        If ilength <= cwidth Then
            lstl.Add("cwidth")
        End If

        If Not tpup Then
            If ilength <= cheight Then
                lstl.Add("cheight")
            End If
        End If

        If iwidth <= clength Then
            lstw.Add("clength")
        End If

        If iwidth <= cwidth Then
            lstw.Add("cwidth")
        End If

        If Not tpup Then
            If iwidth <= cheight Then
                lstw.Add("cheight")
            End If
        End If

        If Not tpup Then
            If iheight <= clength Then
                lsth.Add("clength")
            End If

            If iheight <= cwidth Then
                lsth.Add("cwidth")
            End If
        End If

        If iheight <= cheight Then
            lsth.Add("cheight")
        End If

        Dim cnt1 As Byte = lstl.Count
        Dim cnt2 As Byte = lstw.Count
        Dim cnt3 As Byte = lsth.Count

        If cnt1 = 0 OrElse cnt2 = 0 OrElse cnt3 = 0 Then
            Return False
        Else
            If cnt1 <= cnt2 AndAlso cnt1 <= cnt3 Then
                ordr.Add(lstl)
                ordr1.Add("l")
                If cnt2 <= cnt3 Then
                    ordr.Add(lstw)
                    ordr1.Add("w")
                    ordr.Add(lsth)
                    ordr1.Add("h")
                Else
                    ordr.Add(lsth)
                    ordr1.Add("h")
                    ordr.Add(lstw)
                    ordr1.Add("w")
                End If
            End If

            If cnt2 <= cnt1 AndAlso cnt2 <= cnt3 AndAlso ordr.Count = 0 Then
                ordr.Add(lstw)
                ordr1.Add("w")
                If cnt1 <= cnt3 Then
                    ordr.Add(lstl)
                    ordr1.Add("l")
                    ordr.Add(lsth)
                    ordr1.Add("h")
                Else
                    ordr.Add(lsth)
                    ordr1.Add("h")
                    ordr.Add(lstl)
                    ordr1.Add("l")
                End If
            End If

            If cnt3 <= cnt1 AndAlso cnt3 <= cnt2 AndAlso ordr.Count = 0 Then
                ordr.Add(lsth)
                ordr1.Add("h")
                If cnt1 <= cnt2 Then
                    ordr.Add(lstl)
                    ordr1.Add("l")
                    ordr.Add(lstw)
                    ordr1.Add("w")
                Else
                    ordr.Add(lstw)
                    ordr1.Add("w")
                    ordr.Add(lstl)
                    ordr1.Add("l")
                End If
            End If
            Dim lst1 As New List(Of String)
            Dim lst2 As New List(Of String)
            Dim lst3 As New List(Of String)
            Dim pos1 As String
            Dim pos2 As String
            Dim pos3 As String

            lst1 = ordr(0)
            lst2 = ordr(1)
            lst3 = ordr(2)
            pos1 = ordr1(0)
            pos2 = ordr1(1)
            pos3 = ordr1(2)
            itm = lst1(0)
            out.Add(pos1 & "-" & itm)
            Call WadRemv(lst2, itm)
            Call WadRemv(lst3, itm)

            If lst2.Count = 0 OrElse lst3.Count = 0 Then
                Return False
            Else
                itm = lst2(0)
                out.Add(pos2 & "-" & itm)
                Call WadRemv(lst3, itm)
                If lst3.Count = 0 Then
                    Return False
                Else
                    itm = lst3(0)
                    out.Add(pos3 & "-" & itm)
                End If
            End If
        End If
        Dim itmarr As Object
        For i As Integer = 0 To 2
            itm = out(i)
            itmarr = Split(itm, "-")

            If itmarr(1) = "clength" Then

                If itmarr(0) = "w" Then
                    'ari.length = iwidth   'Comment it unused it at orig
                End If

                If itmarr(0) = "l" Then
                    'ari.length = ilength   'Comment it unused it at orig     
                End If

                If itmarr(0) = "h" Then
                    'ari.length = iheight    'Comment it unused it at orig
                End If

            End If

            If itmarr(1) = "cwidth" Then

                If itmarr(0) = "w" Then

                End If

                If itmarr(0) = "l" Then

                End If

                If itmarr(0) = "h" Then

                End If

            End If

            If itmarr(1) = "cheight" Then

                If itmarr(0) = "w" Then

                End If

                If itmarr(0) = "l" Then

                End If

                If itmarr(0) = "h" Then

                End If

            End If
        Next

        Return True

    End Function

#End Region

    Public Sub StopStep()

        Dim docclose As Boolean

        Do While Not docclose

            Try

                If myProcess Is Nothing Then Exit Do

                Dim exittime = myProcess.ExitTime

                If exittime <= Now() Then

                    docclose = True

                End If

            Catch
            End Try

        Loop

        Try
            myProcess.Close()
        Catch
        End Try

    End Sub

    Public Sub DeleteWrlOutFilesStepTrial()

        Try

            Dim fNm As String = CurDir() & "\OutPut\Firststp"

            Dim stpFnm As String = Nothing

            For ii As Integer = 1 To 1000

                stpFnm = fNm & ii & ".wrl"

                Dim fPNm As Boolean = My.Computer.FileSystem.FileExists(stpFnm)

                If fPNm Then
                    Kill(stpFnm)
                Else
                    Exit For
                End If
            Next

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in delete out file in step trial show", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub DeleteWrlOutFiles()

        Try

            Dim fN As String = CurDir() & "\OutPut\first"
            Dim wrlFn As String = Nothing

            For i As Integer = 1 To 1000

                wrlFn = fN & i & ".wrl"

                Dim Fp As Boolean = My.Computer.FileSystem.FileExists(wrlFn)

                If Fp Then
                    Kill(wrlFn)
                Else
                    Exit For
                End If

            Next

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in DeleteWrlOutFiles", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    Public Sub Show3DViewWrlTrials(ByRef fnwrls As String)

        Dim FName As String = fnwrls
        'MsgBox(FName)
        Dim AltPath As String = "C:\Program Files\Alteros 3D\alteros.exe"

        Try
            Try
                Try
                    myProcess = Process.Start(FName)
                    'myProcess = Process.Start(AltPath, FName)
                Catch
                    myProcess = Process.Start(AltPath, FName)
                    myProcess = Process.Start(FName)
                End Try
            Catch
                myProcess = Process.Start(CurDir() & "\First.wrl")
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
            Else
                MsgBox("You have not selected viewer to view 3D Screen")
                conn.Close()
                off.Flush()
                off.Close()
                Exit Sub
            End If

            conn.Close()
            off.Flush()
            off.Close()
        End Try

    End Sub


End Module

Public Class MemoryManagement

    Private Declare Function SetProcessWorkingSetSize Lib "kernel32.dll" (ByVal process As IntPtr, ByVal minimumWorkingSetSize As Integer, ByVal maximumWorkingSetSize As Integer) As Integer

    Public Shared Sub FlushMemory()

        Try
            GC.Collect()
            GC.WaitForPendingFinalizers()
            If (Environment.OSVersion.Platform = PlatformID.Win32NT) Then
                SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1)
            End If
        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in FlushMemory", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            GC.Collect()
        End Try

    End Sub

    
End Class
