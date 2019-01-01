
'Program Name: -    GenFlow.vb
'Programmer Name: - Satwadhir B. Pawar Mob No. :- 9323974665
'Company Name:-     Hazel Infotech LTD. Mumbai
'Project Name: -    Sky Stuff Plus (Container Stuffing)
'Date: -            23 Dec 2K8 12.40 PM (Modified Time)

'Tips: - The code is debugging at that particular dimensions, quantity and sequence.
'        you are decide it the logic happen is correct to that way or its are some 
'        different way the understanding to at your best level is the correct logic 
'        of this particular code block.

'Description: - GenFlow is the module which containing the routine functions so 
'               that the goods geometry is placed in to the container is shown VRML programmatically.

Module GenFlow

#Region " Function Definitions "

    Public Function FlowStuffOptm(ByVal RArc As Region, ByVal RAr() As Region, ByVal RAri() As String, ByVal RArWt() As Single, ByVal SaveOpt As Boolean, ByVal ShowEmpty As Boolean, ByVal OutFile As String, ByVal DrawArc As Boolean, ByVal TranspArr() As Boolean, ByVal Topup() As Boolean, ByVal TxtOpt As Boolean, ByVal DrawOpt As Boolean, ByVal FindQtyFlg As Boolean, ByVal ChngFlg As Boolean, ByVal ColArr As List(Of List(Of Byte))) As List(Of Region)

        'Stop
        Dim CBLst2 As New List(Of Region)           'Dim stk2 As New List(Of Area)
        Dim CBLst1 As New Queue(Of Region)          'Dim stk1 As New Stack(Of Area)

        'Dim art As New Area
        'Dim arp As New Area
        'Dim are As New Area
        'Dim aru As New Area
        'Dim arb As New Area
        'Dim q As New Queue(Of Area)
        'Dim q1 As New Queue(Of Area)
        'Dim q2 As New Queue(Of Area)

        'Dim ans1 As Boolean
        Dim SzChg As Integer = 0
        Dim Cmd As New OleDb.OleDbCommand

        Dim Qtyflg As Boolean = True
        'Dim traval As Single
        Dim Ard As New Region           'Dim Ard As New Area
        'Dim arm As New List(Of Integer)
        'Dim arm1 As Integer
        'Dim lstm As New List(Of Area)
        'Dim a1 As New Area
        'Dim a2 As New Area
        'Dim Ordr As Integer
        Dim TotAr As Double
        'Dim tmplst As New List(Of String)
        'Dim Answ As MsgBoxResult

        'Dim olditemqty As Integer = 0
        Dim Col As String
        'Dim ii As Integer

        Dim LstJ As New List(Of Region)            'Dim stkj As New List(Of Area)

        'Try

        If SaveOpt Then
            configid = InputBox("Enter Config Id")
        End If

        Dim Ptx As New Point

        Ptx.x = RArc.length
        Ptx.y = RArc.width
        Ptx.z = RArc.height

        Dim Col1 As New List(Of Byte)

        Col1.Clear()
        Col1.Add(255)
        Col1.Add(255)
        Col1.Add(255)
        Col = "1"

        Dim Itmnm As String = ""

        If DrawArc Then

            Dim Ard1 As New Region          'Dim ard1 As New Area

            If DrawArc Then

            End If

            Ard.StrtPt.x = RArc.length
            Ard.StrtPt.y = 0
            Ard.StrtPt.z = 0
            Ard.length = 0.5
            Ard.width = RArc.width
            Ard.height = RArc.height

            If DrawOpt Or DrawArc Then

            End If

            Ard1.StrtPt.x = RArc.length - 0.01
            Ard1.StrtPt.y = 0
            Ard1.StrtPt.z = 0
            Ard1.length = 0.5
            Ard1.width = Ard.width
            Ard1.height = Ard.height

            If DrawOpt Or DrawArc Then

                Col1.Clear()
            End If

        End If

        If SaveOpt Then
            Cmd.Connection = conn
y:
            Try
                Cmd.ExecuteNonQuery()
            Catch ec As Exception
                If ec.Message = "Cannot open any more tables." Then
                    conn.Close()
                    conn.Dispose()
                    OleDb.OleDbConnection.ReleaseObjectPool()
                    Cmd.Dispose()
                    GC.Collect()

                    conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & CurDir() & "\container.mdb;Persist Security Info=False"

                    conn.Open()
                    GoTo y
                End If

            End Try
            id1 += 1
        End If

        RArc.StrtPt.x = 0         'arc.StrtPt.x = 0
        RArc.StrtPt.y = 0         'arc.StrtPt.y = 0
        RArc.StrtPt.z = 0         'arc.StrtPt.z = 0

        Dim j As Integer = 0
        TotAr = 0
        Bareaarr.Clear()

        For i As Integer = 0 To CBLst.Count - 1             'For i As Integer = 0 To stk.Count - 1
            CBLst2.Add(CBLst(i))                            'stk2.Add(stk(i))
        Next                                                'Next    

        Bitemqty = 0
        Btotwt = 0

        'Stop

        If Not IsNothing(RAri) Then                         'If Not IsNothing(ari) Then

            TransactionMenu.lblStatus.Visible = True        'Form8.Show()
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

        End If

        For i As Integer = 0 To Bqtylst.Count - 1
            Bplclst.Add(Bqtylst(i) - 1)
        Next

        fullflag = False
        'olditemqty = 0

        Dim Imgname As String = "1"

        'Do While Not CBLst.Count = 0 And j <= UBound(RAr)      'Do While Not stk.Count = 0 And j <= UBound(ar)

        '    If j > 0 Then
        '        If RAri(j) <> RAri(j - 1) Then
        '            Imgname = (CInt(Imgname) + 1).ToString
        '        End If
        '    End If

        '    ordr = 0

        '    If chkwt Then
        '        Btotwt += RArWt(j)                                  'Btotwt += arwt(j)

        '        If Btotwt >= contcap Then

        '            Answ = MsgBox("Maximum weight capacity of the container is reached" & vbCrLf & "Do you want to proceed?", MsgBoxStyle.YesNo)
        '            If Answ = MsgBoxResult.No Then
        '                fullflag = True
        '                Exit Do

        '            Else
        '                fullflag = False
        '                chkwt = False
        '            End If

        '        End If
        '    End If

        '    If j = 0 Then
        '        Col = Bstrtclr
        '    End If

        If j > 0 And Not IsNothing(RAri) Then          'If j > 0 And Not IsNothing(ari) Then

            If RAri(j - 1) <> RAri(j) Then             'If ari(j - 1) <> ari(j) Then

                RE2 = New RE1                                 'e2 = New e1
                RE2.Qty = Bitemqty                            'e2.qty = Bitemqty
                RE2.Itmnm = RAri(j - 1)                       'e2.itmnm = ari(j - 1)
                LstJ = New List(Of Region)                    'stkj = New List(Of Area)
                For jj As Integer = 0 To CBLst.Count - 1      'For jj As Integer = 0 To stk.Count - 1
                    LstJ.Add(CBLst(jj))                       'stkj.Add(stk(jj))
                Next

                RE2.CBStk = LstJ                                 'e2.stk = stkj
                If DrawOpt Then
                    QtyArrflw.Add(RE2)
                End If

                If Bqtylst.Count > 0 Then

                End If

                Bmaxqtylst.Add(Bitemqty)

                'Form8.Label1.Text = "Stuffing item:" & ari(j)
                'Form8.Label1.Refresh()

                TransactionMenu.lblStatusINm.Text = "Stuffing item : " & RAri(j)
                TransactionMenu.lblStatusINm.Refresh()
            Else
                'Form8.Label1.Text = "Stuffing item:" & ari(j)
                'Form8.Label1.Refresh()

                TransactionMenu.lblStatusINm.Text = "Stuffing item : " & RAri(j)
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

                If DrawOpt Then
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

        '    'Stop

        '    If DrawOpt Then
        '        If j > 0 Then

        '            If RAri(j - 1) <> RAri(j) Then

        '                Bitemqty = 0

        '                If Col = "r" Then
        '                    Col = "g"
        '                ElseIf Col = "g" Then
        '                    Col = "b"
        '                ElseIf Col = "b" Then
        '                    Col = "m"
        '                ElseIf Col = "m" Then
        '                    Col = "c"
        '                ElseIf Col = "c" Then
        '                    Col = "y"
        '                End If

        '                SzChg += 1
        '                Qtyflg = True

        '            Else
        '                Qtyflg = False
        '            End If
        '        End If
        '    End If

        'Loop

        Return Nothing

    End Function

#End Region

End Module
