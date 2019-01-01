
'Program Name: -    StuffPlus.vb
'Programmer Name: - Satwadhir B. Pawar Mob No. :- 9323974665
'Company Name:-     Hazel Infotech LTD. Mumbai
'Project Name: -    Sky Stuff Plus (Container Stuffing)
'Date: -            23 Dec 2K8 3.45 PM (Modified Time)

'Tips: - The code is debugging at that particular dimensions, quantity and sequence.
'        you are decide it the logic happen is correct to that way or its are some 
'        different way the understanding to at your best level is the correct logic 
'        of this particular code block.

'Description: - StuffPlus is the form it’s is containing certain useful routines and 
'               functions in goods geometry stuffing.

Public NotInheritable Class StuffPlus
    Inherits System.Windows.Forms.Form

#Region " Class Declaration "

    Dim AddFlg As Integer
    Dim Qtyf As Boolean = False

#End Region

#Region " Function Definition "

    Public Function DFtIp(ByVal Arc As CDArea, ByVal Ari As CDArea, ByVal TpUp As Boolean) As Boolean

        'stop
        'Deside weather horizontal or vertical axis of item drums is placed.

        Dim Clength As Double = Arc.DLengths
        Dim Cwidth As Double = Arc.DWidth
        Dim Cheight As Double = Arc.DHeight

        Dim Ilength As Double = Ari.DLengths
        Dim Iwidth As Double = Ari.DWidth
        Dim Iheight As Double = Ari.DHeight

        Dim Lstl As New List(Of String)
        Dim Lstw As New List(Of String)
        Dim Lsth As New List(Of String)
        Dim Ordr As New List(Of List(Of String))
        Dim Ordr1 As New List(Of String)
        Dim Out As New List(Of String)
        Dim Itm As String

        If Ilength <= Clength Then
            Lstl.Add("clength")
        End If

        If Ilength <= Cwidth Then
            Lstl.Add("cwidth")
        End If

        If Not TpUp Then
            If Ilength <= Cheight Then
                Lstl.Add("cheight")
            End If
        End If

        If Iwidth <= Clength Then
            Lstw.Add("clength")
        End If

        If Iwidth <= Cwidth Then
            Lstw.Add("cwidth")
        End If

        If Not TpUp Then
            If Iwidth <= Cheight Then
                Lstw.Add("cheight")
            End If
        End If

        If Not TpUp Then
            If Iheight <= Clength Then
                Lsth.Add("clength")
            End If

            If Iheight <= Cwidth Then
                Lsth.Add("cwidth")
            End If
        End If

        If Iheight <= Cheight Then
            Lsth.Add("cheight")
        End If

        Dim Cnt1 As Byte = Lstl.Count
        Dim Cnt2 As Byte = Lstw.Count
        Dim Cnt3 As Byte = Lsth.Count

        If Cnt1 = 0 OrElse Cnt2 = 0 OrElse Cnt3 = 0 Then
            Return False
        Else
            If Cnt1 <= Cnt2 AndAlso Cnt1 <= Cnt3 Then
                Ordr.Add(Lstl)
                Ordr1.Add("l")
                If Cnt2 <= Cnt3 Then
                    Ordr.Add(Lstw)
                    Ordr1.Add("w")
                    Ordr.Add(Lsth)
                    Ordr1.Add("h")
                Else
                    Ordr.Add(Lsth)
                    Ordr1.Add("h")
                    Ordr.Add(Lstw)
                    Ordr1.Add("w")
                End If
            End If

            If Cnt2 <= Cnt1 AndAlso Cnt2 <= Cnt3 AndAlso Ordr.Count = 0 Then
                Ordr.Add(Lstw)
                Ordr1.Add("w")
                If Cnt1 <= Cnt3 Then
                    Ordr.Add(Lstl)
                    Ordr1.Add("l")
                    Ordr.Add(Lsth)
                    Ordr1.Add("h")
                Else
                    Ordr.Add(Lsth)
                    Ordr1.Add("h")
                    Ordr.Add(Lstl)
                    Ordr1.Add("l")
                End If
            End If

            If Cnt3 <= Cnt1 AndAlso Cnt3 <= Cnt2 AndAlso Ordr.Count = 0 Then
                Ordr.Add(Lsth)
                Ordr1.Add("h")
                If Cnt1 <= Cnt2 Then
                    Ordr.Add(Lstl)
                    Ordr1.Add("l")
                    Ordr.Add(Lstw)
                    Ordr1.Add("w")
                Else
                    Ordr.Add(Lstw)
                    Ordr1.Add("w")
                    Ordr.Add(Lstl)
                    Ordr1.Add("l")
                End If
            End If

            Dim Lst1 As New List(Of String)
            Dim Lst2 As New List(Of String)
            Dim Lst3 As New List(Of String)
            Dim Pos1 As String
            Dim Pos2 As String
            Dim Pos3 As String

            Lst1 = Ordr(0)
            Lst2 = Ordr(1)
            Lst3 = Ordr(2)
            Pos1 = Ordr1(0)
            Pos2 = Ordr1(1)
            Pos3 = Ordr1(2)
            Itm = Lst1(0)
            Out.Add(Pos1 & "-" & Itm)
            Call Remv(Lst2, Itm)
            Call Remv(Lst3, Itm)

            If Lst2.Count = 0 OrElse Lst3.Count = 0 Then
                Return False
            Else
                Itm = Lst2(0)
                Out.Add(Pos2 & "-" & Itm)
                Call Remv(Lst3, Itm)
                If Lst3.Count = 0 Then
                    Return False
                Else
                    Itm = Lst3(0)
                    Out.Add(Pos3 & "-" & Itm)
                End If
            End If
        End If
        Dim ItmArr As Object
        For i As Integer = 0 To 2
            Itm = Out(i)
            ItmArr = Split(Itm, "-")

            If ItmArr(1) = "clength" Then

                If ItmArr(0) = "w" Then
                    'ari.length = iwidth
                End If

                If ItmArr(0) = "l" Then
                    'ari.length = ilength
                End If

                If ItmArr(0) = "h" Then
                    'ari.length = iheight
                End If

            End If

            If ItmArr(1) = "cwidth" Then

                If ItmArr(0) = "w" Then

                End If

                If ItmArr(0) = "l" Then

                End If

                If ItmArr(0) = "h" Then

                End If

            End If

            If ItmArr(1) = "cheight" Then

                If ItmArr(0) = "w" Then

                End If

                If ItmArr(0) = "l" Then

                End If

                If ItmArr(0) = "h" Then

                End If

            End If

        Next

        Return True

    End Function

    Public Function DFtIpCA(ByVal Arc As CDArea, ByVal Ari As CDArea, ByVal TpUp As Boolean) As Boolean

        'Stop
        'Deside weather horizontal or vertical axis of item drums is placed.

        Dim Clength As Double = Arc.DLengths        'Reamining Container L W H
        Dim Cwidth As Double = Arc.DWidth
        Dim Cheight As Double = Arc.DHeight

        Dim Ilength As Double = Ari.DLengths        'Current Iteam L W H
        Dim Iwidth As Double = Ari.DWidth
        Dim Iheight As Double = Ari.DHeight

        Dim Lstl As New List(Of String)
        Dim Lstw As New List(Of String)
        Dim Lsth As New List(Of String)
        Dim Ordr As New List(Of List(Of String))
        Dim Ordr1 As New List(Of String)
        Dim Out As New List(Of String)
        Dim Itm As String

        If Ilength <= Clength Then
            Lstl.Add("clength")
        End If

        If Ilength <= Cwidth Then
            Lstl.Add("cwidth")
        End If

        If Not TpUp Then
            If Ilength <= Cheight Then
                Lstl.Add("cheight")
            End If
        End If

        If Iwidth <= Clength Then
            Lstw.Add("clength")
        End If

        If Iwidth <= Cwidth Then
            Lstw.Add("cwidth")
        End If

        If Not TpUp Then
            If Iwidth <= Cheight Then
                Lstw.Add("cheight")
            End If
        End If

        If Not TpUp Then
            If Iheight <= Clength Then
                Lsth.Add("clength")
            End If

            If Iheight <= Cwidth Then
                Lsth.Add("cwidth")
            End If
        End If

        If Iheight <= Cheight Then
            Lsth.Add("cheight")
        End If

        Dim Cnt1 As Byte = Lstl.Count
        Dim Cnt2 As Byte = Lstw.Count
        Dim Cnt3 As Byte = Lsth.Count

        If Cnt1 = 0 OrElse Cnt2 = 0 OrElse Cnt3 = 0 Then
            Return False
        Else
            If Cnt1 <= Cnt2 AndAlso Cnt1 <= Cnt3 Then
                Ordr.Add(Lstl)
                Ordr1.Add("l")
                If Cnt2 <= Cnt3 Then
                    Ordr.Add(Lstw)
                    Ordr1.Add("w")
                    Ordr.Add(Lsth)
                    Ordr1.Add("h")
                Else
                    Ordr.Add(Lsth)
                    Ordr1.Add("h")
                    Ordr.Add(Lstw)
                    Ordr1.Add("w")
                End If
            End If

            If Cnt2 <= Cnt1 AndAlso Cnt2 <= Cnt3 AndAlso Ordr.Count = 0 Then
                Ordr.Add(Lstw)
                Ordr1.Add("w")
                If Cnt1 <= Cnt3 Then
                    Ordr.Add(Lstl)
                    Ordr1.Add("l")
                    Ordr.Add(Lsth)
                    Ordr1.Add("h")
                Else
                    Ordr.Add(Lsth)
                    Ordr1.Add("h")
                    Ordr.Add(Lstl)
                    Ordr1.Add("l")
                End If
            End If

            If Cnt3 <= Cnt1 AndAlso Cnt3 <= Cnt2 AndAlso Ordr.Count = 0 Then
                Ordr.Add(Lsth)
                Ordr1.Add("h")
                If Cnt1 <= Cnt2 Then
                    Ordr.Add(Lstl)
                    Ordr1.Add("l")
                    Ordr.Add(Lstw)
                    Ordr1.Add("w")
                Else
                    Ordr.Add(Lstw)
                    Ordr1.Add("w")
                    Ordr.Add(Lstl)
                    Ordr1.Add("l")
                End If
            End If

            Dim Lst1 As New List(Of String)
            Dim Lst2 As New List(Of String)
            Dim Lst3 As New List(Of String)
            Dim Pos1 As String
            Dim Pos2 As String
            Dim Pos3 As String

            Lst1 = Ordr(0)
            Lst2 = Ordr(1)
            Lst3 = Ordr(2)
            Pos1 = Ordr1(0)
            Pos2 = Ordr1(1)
            Pos3 = Ordr1(2)
            Itm = Lst1(0)
            Out.Add(Pos1 & "-" & Itm)
            Call Remv(Lst2, Itm)
            Call Remv(Lst3, Itm)

            If Lst2.Count = 0 OrElse Lst3.Count = 0 Then
                Return False
            Else
                Itm = Lst2(0)
                Out.Add(Pos2 & "-" & Itm)
                Call Remv(Lst3, Itm)
                If Lst3.Count = 0 Then
                    Return False
                Else
                    Itm = Lst3(0)
                    Out.Add(Pos3 & "-" & Itm)
                End If
            End If
        End If

        Dim ItmArr As Object

        For i As Integer = 0 To 2

            Itm = Out(i)
            ItmArr = Split(Itm, "-")

            If ItmArr(1) = "clength" Then

                If ItmArr(0) = "w" Then
                    'ari.length = iwidth
                End If

                If ItmArr(0) = "l" Then
                    'ari.length = ilength
                End If

                If ItmArr(0) = "h" Then
                    'ari.length = iheight
                End If

            End If

            If ItmArr(1) = "cwidth" Then

                If ItmArr(0) = "w" Then

                End If

                If ItmArr(0) = "l" Then

                End If

                If ItmArr(0) = "h" Then

                End If

            End If

            If ItmArr(1) = "cheight" Then

                If ItmArr(0) = "w" Then

                End If

                If ItmArr(0) = "l" Then

                End If

                If ItmArr(0) = "h" Then

                End If

            End If

        Next

        Return True

    End Function

    Public Function DFtIpCANxt(ByVal Arc As CDArea, ByVal Ari As CDArea, ByVal TpUp As Boolean) As Boolean

        'Stop
        'Deside weather horizontal or vertical axis of item drums is placed.

        Dim Clength As Double = Arc.DLengths        'Reamining Container L W H
        Dim Cwidth As Double = Arc.DWidth
        Dim Cheight As Double = Arc.DHeight

        Dim Ilength As Double = Ari.DLengths        'Current Iteam L W H
        Dim Iwidth As Double = Ari.DWidth
        Dim Iheight As Double = Ari.DHeight

        Dim Lstl As New List(Of String)
        Dim Lstw As New List(Of String)
        Dim Lsth As New List(Of String)
        Dim Ordr As New List(Of List(Of String))
        Dim Ordr1 As New List(Of String)
        Dim Out As New List(Of String)
        Dim Itm As String

        If Ilength <= Clength Then
            Lstl.Add("clength")
        End If

        If Ilength <= Cwidth Then
            Lstl.Add("cwidth")
        End If

        If Not TpUp Then
            If Ilength <= Cheight Then
                Lstl.Add("cheight")
            End If
        End If

        If Iwidth <= Clength Then
            Lstw.Add("clength")
        End If

        If Iwidth <= Cwidth Then
            Lstw.Add("cwidth")
        End If

        If Not TpUp Then
            If Iwidth <= Cheight Then
                Lstw.Add("cheight")
            End If
        End If

        If Not TpUp Then
            If Iheight <= Clength Then
                Lsth.Add("clength")
            End If

            If Iheight <= Cwidth Then
                Lsth.Add("cwidth")
            End If
        End If

        If Iheight <= Cheight Then
            Lsth.Add("cheight")
        End If

        Dim Cnt1 As Byte = Lstl.Count
        Dim Cnt2 As Byte = Lstw.Count
        Dim Cnt3 As Byte = Lsth.Count

        If Cnt1 = 0 OrElse Cnt2 = 0 OrElse Cnt3 = 0 Then
            Return False
        Else
            If Cnt1 <= Cnt2 AndAlso Cnt1 <= Cnt3 Then
                Ordr.Add(Lstl)
                Ordr1.Add("l")
                If Cnt2 <= Cnt3 Then
                    Ordr.Add(Lstw)
                    Ordr1.Add("w")
                    Ordr.Add(Lsth)
                    Ordr1.Add("h")
                Else
                    Ordr.Add(Lsth)
                    Ordr1.Add("h")
                    Ordr.Add(Lstw)
                    Ordr1.Add("w")
                End If
            End If

            If Cnt2 <= Cnt1 AndAlso Cnt2 <= Cnt3 AndAlso Ordr.Count = 0 Then
                Ordr.Add(Lstw)
                Ordr1.Add("w")
                If Cnt1 <= Cnt3 Then
                    Ordr.Add(Lstl)
                    Ordr1.Add("l")
                    Ordr.Add(Lsth)
                    Ordr1.Add("h")
                Else
                    Ordr.Add(Lsth)
                    Ordr1.Add("h")
                    Ordr.Add(Lstl)
                    Ordr1.Add("l")
                End If
            End If

            If Cnt3 <= Cnt1 AndAlso Cnt3 <= Cnt2 AndAlso Ordr.Count = 0 Then
                Ordr.Add(Lsth)
                Ordr1.Add("h")
                If Cnt1 <= Cnt2 Then
                    Ordr.Add(Lstl)
                    Ordr1.Add("l")
                    Ordr.Add(Lstw)
                    Ordr1.Add("w")
                Else
                    Ordr.Add(Lstw)
                    Ordr1.Add("w")
                    Ordr.Add(Lstl)
                    Ordr1.Add("l")
                End If
            End If

            Dim Lst1 As New List(Of String)
            Dim Lst2 As New List(Of String)
            Dim Lst3 As New List(Of String)
            Dim Pos1 As String
            Dim Pos2 As String
            Dim Pos3 As String

            Lst1 = Ordr(0)
            Lst2 = Ordr(1)
            Lst3 = Ordr(2)
            Pos1 = Ordr1(0)
            Pos2 = Ordr1(1)
            Pos3 = Ordr1(2)
            Itm = Lst1(0)
            Out.Add(Pos1 & "-" & Itm)
            Call Remv(Lst2, Itm)
            Call Remv(Lst3, Itm)

            If Lst2.Count = 0 OrElse Lst3.Count = 0 Then
                Return False
            Else
                Itm = Lst2(0)
                Out.Add(Pos2 & "-" & Itm)
                Call Remv(Lst3, Itm)
                If Lst3.Count = 0 Then
                    Return False
                Else
                    Itm = Lst3(0)
                    Out.Add(Pos3 & "-" & Itm)
                End If
            End If
        End If

        Dim ItmArr As Object

        For i As Integer = 0 To 2

            Itm = Out(i)
            ItmArr = Split(Itm, "-")

            If ItmArr(1) = "clength" Then

                If ItmArr(0) = "w" Then
                    'ari.length = iwidth
                End If

                If ItmArr(0) = "l" Then
                    'ari.length = ilength
                End If

                If ItmArr(0) = "h" Then
                    'ari.length = iheight
                End If

            End If

            If ItmArr(1) = "cwidth" Then

                If ItmArr(0) = "w" Then

                End If

                If ItmArr(0) = "l" Then

                End If

                If ItmArr(0) = "h" Then

                End If

            End If

            If ItmArr(1) = "cheight" Then

                If ItmArr(0) = "w" Then

                End If

                If ItmArr(0) = "l" Then

                End If

                If ItmArr(0) = "h" Then

                End If

            End If

        Next

        Return True

    End Function

    Public Sub Remv(ByVal Lst As List(Of String), ByVal Itm As String)

        Try

            For i As Integer = 0 To Lst.Count - 1

                Lst.Remove(Itm)

            Next

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in Remv", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Dim Flg As Boolean = False

    Public Function DrumFtIpDHE(ByVal Arc As CDArea, ByVal Ari As CDArea, ByVal TpUp As Boolean) As Boolean

        'stop
        'Deside weather horizontal or vertical axis of item drums is placed.
        Dim Clength As Double = Arc.DLengths
        Dim Cwidth As Double = Arc.DWidth
        Dim Cheight As Double = Arc.DHeight

        Dim Ilength As Double = Ari.DLengths
        Dim Iwidth As Double = Ari.DWidth
        Dim Iheight As Double = Ari.DHeight

        Dim Lstl As New List(Of String)
        Dim Lstw As New List(Of String)
        Dim Lsth As New List(Of String)
        Dim Ordr As New List(Of List(Of String))
        Dim Ordr1 As New List(Of String)
        Dim Out As New List(Of String)
        Dim Itm As String

        Try
            If Ilength <= Clength Then
                Lstl.Add("clength")
            End If

            If Ilength <= Cwidth Then
                Lstl.Add("cwidth")
            End If

            If Not TpUp Then
                If Ilength <= Cheight Then
                    Lstl.Add("cheight")
                End If
            End If

            If Iwidth <= Clength Then
                Lstw.Add("clength")
            End If

            If Iwidth <= Cwidth Then
                Lstw.Add("cwidth")
            End If

            If Not TpUp Then
                If Iwidth <= Cheight Then
                    Lstw.Add("cheight")
                End If
            End If

            If Not TpUp Then
                If Iheight <= Clength Then
                    Lsth.Add("clength")
                End If

                If Iheight <= Cwidth Then
                    Lsth.Add("cwidth")
                End If
            End If

            If Iheight <= Cheight Then
                Lsth.Add("cheight")
            End If

            Dim Cnt1 As Byte = Lstl.Count
            Dim Cnt2 As Byte = Lstw.Count
            Dim Cnt3 As Byte = Lsth.Count

            If Cnt1 = 0 OrElse Cnt2 = 0 OrElse Cnt3 = 0 Then
                Return False
            Else
                If Cnt1 <= Cnt2 AndAlso Cnt1 <= Cnt3 Then
                    Ordr.Add(Lstl)
                    Ordr1.Add("l")
                    If Cnt2 <= Cnt3 Then
                        Ordr.Add(Lstw)
                        Ordr1.Add("w")
                        Ordr.Add(Lsth)
                        Ordr1.Add("h")
                    Else
                        Ordr.Add(Lsth)
                        Ordr1.Add("h")
                        Ordr.Add(Lstw)
                        Ordr1.Add("w")
                    End If
                End If

                If Cnt2 <= Cnt1 AndAlso Cnt2 <= Cnt3 AndAlso Ordr.Count = 0 Then
                    Ordr.Add(Lstw)
                    Ordr1.Add("w")
                    If Cnt1 <= Cnt3 Then
                        Ordr.Add(Lstl)
                        Ordr1.Add("l")
                        Ordr.Add(Lsth)
                        Ordr1.Add("h")
                    Else
                        Ordr.Add(Lsth)
                        Ordr1.Add("h")
                        Ordr.Add(Lstl)
                        Ordr1.Add("l")
                    End If
                End If

                If Cnt3 <= Cnt1 AndAlso Cnt3 <= Cnt2 AndAlso Ordr.Count = 0 Then
                    Ordr.Add(Lsth)
                    Ordr1.Add("h")
                    If Cnt1 <= Cnt2 Then
                        Ordr.Add(Lstl)
                        Ordr1.Add("l")
                        Ordr.Add(Lstw)
                        Ordr1.Add("w")
                    Else
                        Ordr.Add(Lstw)
                        Ordr1.Add("w")
                        Ordr.Add(Lstl)
                        Ordr1.Add("l")
                    End If
                End If

                Dim Lst1 As New List(Of String)
                Dim Lst2 As New List(Of String)
                Dim Lst3 As New List(Of String)
                Dim Pos1 As String
                Dim Pos2 As String
                Dim Pos3 As String

                Lst1 = Ordr(0)
                Lst2 = Ordr(1)
                Lst3 = Ordr(2)
                Pos1 = Ordr1(0)
                Pos2 = Ordr1(1)
                Pos3 = Ordr1(2)
                Itm = Lst1(0)
                Out.Add(Pos1 & "-" & Itm)
                Call Remv(Lst2, Itm)
                Call Remv(Lst3, Itm)

                If Lst2.Count = 0 OrElse Lst3.Count = 0 Then
                    Return False
                Else
                    Itm = Lst2(0)
                    Out.Add(Pos2 & "-" & Itm)
                    Call Remv(Lst3, Itm)
                    If Lst3.Count = 0 Then
                        Return False
                    Else
                        Itm = Lst3(0)
                        Out.Add(Pos3 & "-" & Itm)
                    End If
                End If
            End If
            Dim ItmArr As Object
            For i As Integer = 0 To 2
                Itm = Out(i)
                ItmArr = Split(Itm, "-")

                If ItmArr(1) = "clength" Then

                    If ItmArr(0) = "w" Then
                        'ari.length = iwidth
                    End If

                    If ItmArr(0) = "l" Then
                        'ari.length = ilength
                    End If

                    If ItmArr(0) = "h" Then
                        'ari.length = iheight
                    End If

                End If

                If ItmArr(1) = "cwidth" Then

                    If ItmArr(0) = "w" Then

                    End If

                    If ItmArr(0) = "l" Then

                    End If

                    If ItmArr(0) = "h" Then

                    End If

                End If

                If ItmArr(1) = "cheight" Then

                    If ItmArr(0) = "w" Then

                    End If

                    If ItmArr(0) = "l" Then

                    End If

                    If ItmArr(0) = "h" Then

                    End If

                End If

            Next

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in DrumFtIpDHE", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return True

    End Function

    Public Function DrumFtIpDHD(ByVal Arc As CDArea, ByVal Ari As CDArea, ByVal TpUp As Boolean) As Boolean
        'DStop
        'Deside weather horizontal or vertical axis of item drums is placed.
        Dim Clength As Double = Arc.DLengths
        Dim Cwidth As Double = Arc.DWidth
        Dim Cheight As Double = Arc.DHeight

        Dim Ilength As Double = Ari.DLengths
        Dim Iwidth As Double = Ari.DWidth
        Dim Iheight As Double = Ari.DHeight
        Dim Iradius As Double = Ari.DRadius

        Dim Lstl As New List(Of String)
        Dim Lstw As New List(Of String)
        Dim Lsth As New List(Of String)
        Dim Ordr As New List(Of List(Of String))
        Dim Ordr1 As New List(Of String)
        Dim Out As New List(Of String)
        Dim Itm As String

        Try
            If Ilength <= Clength Then
                Lstl.Add("clength")
            End If

            If Ilength <= Cwidth Then
                Lstl.Add("cwidth")
            End If

            If Not TpUp Then
                If Ilength <= Cheight Then
                    Lstl.Add("cheight")
                End If
            End If

            If Iwidth <= Clength Then
                Lstw.Add("clength")
            End If

            If Iwidth <= Cwidth Then
                Lstw.Add("cwidth")
            End If

            If Not TpUp Then
                If Iwidth <= Cheight Then
                    Lstw.Add("cheight")
                End If
            End If

            If Not TpUp Then
                If Iheight <= Clength Then
                    Lsth.Add("clength")
                End If

                If Iheight <= Cwidth Then
                    Lsth.Add("cwidth")
                End If
            End If

            If Iheight <= Cheight Then
                Lsth.Add("cheight")
            End If

            Dim Cnt1 As Byte = Lstl.Count
            Dim Cnt2 As Byte = Lstw.Count
            Dim Cnt3 As Byte = Lsth.Count

            If Cnt1 = 0 OrElse Cnt2 = 0 OrElse Cnt3 = 0 Then
                Return False
            Else
                If Cnt1 <= Cnt2 AndAlso Cnt1 <= Cnt3 Then
                    Ordr.Add(Lstl)
                    Ordr1.Add("l")
                    If Cnt2 <= Cnt3 Then
                        Ordr.Add(Lstw)
                        Ordr1.Add("w")
                        Ordr.Add(Lsth)
                        Ordr1.Add("h")
                    Else
                        Ordr.Add(Lsth)
                        Ordr1.Add("h")
                        Ordr.Add(Lstw)
                        Ordr1.Add("w")
                    End If
                End If

                If Cnt2 <= Cnt1 AndAlso Cnt2 <= Cnt3 AndAlso Ordr.Count = 0 Then
                    Ordr.Add(Lstw)
                    Ordr1.Add("w")
                    If Cnt1 <= Cnt3 Then
                        Ordr.Add(Lstl)
                        Ordr1.Add("l")
                        Ordr.Add(Lsth)
                        Ordr1.Add("h")
                    Else
                        Ordr.Add(Lsth)
                        Ordr1.Add("h")
                        Ordr.Add(Lstl)
                        Ordr1.Add("l")
                    End If
                End If

                If Cnt3 <= Cnt1 AndAlso Cnt3 <= Cnt2 AndAlso Ordr.Count = 0 Then
                    Ordr.Add(Lsth)
                    Ordr1.Add("h")
                    If Cnt1 <= Cnt2 Then
                        Ordr.Add(Lstl)
                        Ordr1.Add("l")
                        Ordr.Add(Lstw)
                        Ordr1.Add("w")
                    Else
                        Ordr.Add(Lstw)
                        Ordr1.Add("w")
                        Ordr.Add(Lstl)
                        Ordr1.Add("l")
                    End If
                End If

                Dim Lst1 As New List(Of String)
                Dim Lst2 As New List(Of String)
                Dim Lst3 As New List(Of String)
                Dim Pos1 As String
                Dim Pos2 As String
                Dim Pos3 As String

                Lst1 = Ordr(0)
                Lst2 = Ordr(1)
                Lst3 = Ordr(2)
                Pos1 = Ordr1(0)
                Pos2 = Ordr1(1)
                Pos3 = Ordr1(2)
                Itm = Lst1(0)
                Out.Add(Pos1 & "-" & Itm)
                Call Remv(Lst2, Itm)
                Call Remv(Lst3, Itm)

                If Lst2.Count = 0 OrElse Lst3.Count = 0 Then
                    Return False
                Else
                    Itm = Lst2(0)
                    Out.Add(Pos2 & "-" & Itm)
                    Call Remv(Lst3, Itm)
                    If Lst3.Count = 0 Then
                        Return False
                    Else
                        Itm = Lst3(0)
                        Out.Add(Pos3 & "-" & Itm)
                    End If
                End If
            End If
            Dim ItmArr As Object
            For i As Integer = 0 To 2
                Itm = Out(i)
                ItmArr = Split(Itm, "-")

                If ItmArr(1) = "clength" Then

                    If ItmArr(0) = "w" Then
                        'ari.length = iwidth
                    End If

                    If ItmArr(0) = "l" Then
                        'ari.length = ilength
                    End If

                    If ItmArr(0) = "h" Then
                        'ari.length = iheight
                    End If

                End If

                If ItmArr(1) = "cwidth" Then

                    If ItmArr(0) = "w" Then

                    End If

                    If ItmArr(0) = "l" Then

                    End If

                    If ItmArr(0) = "h" Then

                    End If

                End If

                If ItmArr(1) = "cheight" Then

                    If ItmArr(0) = "w" Then

                    End If

                    If ItmArr(0) = "l" Then

                    End If

                    If ItmArr(0) = "h" Then

                    End If

                End If

            Next

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in DrumFtIpDHD", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'DStop

        Return True

    End Function

#End Region

#Region " Routine Definition "

    Private Sub DataGridView1_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged

        Dim Cmd As New OleDb.OleDbCommand
        Dim Rdr As OleDb.OleDbDataReader
        Dim ItmNm As String
        Dim Adpt As New OleDb.OleDbDataAdapter
        Dim Tbl As New DataTable
        Dim j As Integer

        Dim Dlni As Single
        Dim Dwdi As Single
        Dim Dhti As Single

        Try

            If Qtyf Then
                If e.ColumnIndex = 5 Then

                End If
            End If

            If connDrums.State = ConnectionState.Closed Then connDrums.Open()

            If connDrums.State = ConnectionState.Open Then
                Cmd.Connection = connDrums
                If e.RowIndex >= 0 And e.ColumnIndex = 0 Then

                    j = DataGridView1.Rows.Count
                    Cmd.CommandText = "delete from temp"
                    Cmd.ExecuteNonQuery()

                    Flg = False

                End If

                If e.ColumnIndex = 7 And e.RowIndex <> -1 Then

                End If

                If e.ColumnIndex = 8 And e.RowIndex <> -1 Then
                    Dim method As String = DataGridView1.Item(e.ColumnIndex, e.RowIndex).Value
                    ItmNm = DataGridView1.Item(1, e.RowIndex).Value
                    If Not ItmNm Is Nothing Then
                        Cmd.CommandText = "select lengthf,widthf,heightf,lengthi,widthi,heighti,lengthc,widthc,heightc,lengthm,widthm,heightm,wightkg from itemmaster where itemname ='" & ItmNm & "'"
                        Rdr = Cmd.ExecuteReader
                        Rdr.Read()
                        Dlni = Rdr("lengthi") + (12 * Rdr("lengthf")) + (Rdr("lengthc") / 2.54) + (Rdr("lengthm") / 25.4)
                        Dwdi = Rdr("Widthi") + (12 * Rdr("Widthf")) + (Rdr("Widthc") / 2.54) + (Rdr("Widthm") / 25.4)
                        Dhti = Rdr("heighti") + (12 * Rdr("heightf")) + (Rdr("heightc") / 2.54) + (Rdr("heightm") / 25.4)
                        Rdr.Close()
                        If method = "WLH" Then
                            DataGridView1.Item(1, e.RowIndex).Value = Dwdi
                            DataGridView1.Item(2, e.RowIndex).Value = Dlni
                            DataGridView1.Item(3, e.RowIndex).Value = Dhti
                        End If

                        If method = "WHL" Then
                            DataGridView1.Item(1, e.RowIndex).Value = Dwdi
                            DataGridView1.Item(2, e.RowIndex).Value = Dhti
                            DataGridView1.Item(3, e.RowIndex).Value = Dlni
                        End If

                        If method = "HLW" Then
                            DataGridView1.Item(1, e.RowIndex).Value = Dhti
                            DataGridView1.Item(2, e.RowIndex).Value = Dlni
                            DataGridView1.Item(3, e.RowIndex).Value = Dwdi
                        End If

                        If method = "HWL" Then
                            DataGridView1.Item(1, e.RowIndex).Value = Dhti
                            DataGridView1.Item(2, e.RowIndex).Value = Dwdi
                            DataGridView1.Item(3, e.RowIndex).Value = Dlni
                        End If

                        If method = "LHW" Then
                            DataGridView1.Item(1, e.RowIndex).Value = Dlni
                            DataGridView1.Item(2, e.RowIndex).Value = Dhti
                            DataGridView1.Item(3, e.RowIndex).Value = Dwdi
                        End If

                        If method = "LWH" Then
                            DataGridView1.Item(1, e.RowIndex).Value = Dlni
                            DataGridView1.Item(2, e.RowIndex).Value = Dwdi
                            DataGridView1.Item(3, e.RowIndex).Value = Dhti
                        End If

                        Call Button1_Click(Nothing, Nothing)

                    End If
                End If

                If Qtyf Then
                    If e.ColumnIndex = 6 And e.RowIndex <> -1 And AddFlg <> e.RowIndex Then

                        AddFlg = -1
                    End If
                End If

                If e.ColumnIndex = 5 Then
                    If e.RowIndex <> -1 Then
                        If CStr(DataGridView1.Item(e.ColumnIndex, e.RowIndex).Value) <> "" And IsNumeric(DataGridView1.Item(e.ColumnIndex, e.RowIndex).Value) Then
                            If DataGridView1.Item(e.ColumnIndex, e.RowIndex).Value > 0 And Not (CStr(DataGridView1.Item(e.ColumnIndex, e.RowIndex).Value)).Contains(".") Then
                                If Not IsNothing(DataGridView1.Item(2, e.RowIndex).Value) Then
                                    Qtyf = True
                                End If
                            End If

                        End If
                    End If
                End If

            End If
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in DataGridView1_CellValueChanged", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            connDrums.Close()
        End Try

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim CmdTxt As String
        Dim j As Integer
        Dim Cmd As New OleDb.OleDbCommand
        Cmd.Connection = connDrums
        j = DataGridView1.Rows.Count
        Cmd.CommandText = "delete from temp"
        Cmd.ExecuteNonQuery()

        For i As Integer = 0 To j - 2
            CmdTxt = "insert into temp values('" & DataGridView1.Item(1, i).Value & "'," & DataGridView1.Item(2, i).Value & ","
            CmdTxt = CmdTxt & DataGridView1.Item(3, i).Value & "," & DataGridView1.Item(4, i).Value & "," & DataGridView1.Item(5, i).Value & "," & CStr(i) & ")"
            Cmd.CommandText = CmdTxt
            Cmd.ExecuteNonQuery()
        Next

        UpdSeq()

    End Sub

    Private Sub UpdSeq()

        Dim Cmd As New OleDb.OleDbCommand
        Dim Cmd1 As New OleDb.OleDbCommand
        Dim Rdr As OleDb.OleDbDataReader
        Dim Outarr As New List(Of String)
        Dim Itm As String
        Dim ItmArr As Object

        Dim Itmnm As Integer
        Dim Seqs As String

        Try
            Flg = True
            Cmd.Connection = connDrums
            Cmd1.Connection = connDrums
            Cmd1.CommandText = "delete from temp1"
            Cmd1.ExecuteNonQuery()

            Cmd.CommandText = "select * from temp order by (width * height * length * qty) desc"
            Rdr = Cmd.ExecuteReader
            Dim Seq As Integer = 1
            Do While Rdr.Read

                Outarr.Add(Rdr.Item("rowcnt") & "-" & CStr(Seq))
                Seq += 1
            Loop
            Rdr.Close()
            For i As Integer = 0 To Outarr.Count - 1
                Itm = Outarr(i)
                ItmArr = Itm.Split("-")
                Itmnm = ItmArr(0)
                Seqs = ItmArr(1)
                DataGridView1.Item(8, Itmnm).Value = Seqs
                If Seqs = 1 Then
                    TextBox1.Text = DataGridView1.Item(5, Itmnm).Value
                End If
            Next
        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in UpdSeq", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

#End Region

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

End Class