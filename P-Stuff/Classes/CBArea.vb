
'Program Name: -    CBArea.vb
'Programmer Name: - Satwadhir B. Pawar Mob No. :- 9323974665
'Company Name:-     Hazel Infotech LTD. Mumbai
'Project Name: -    Sky Stuff Plus (Container Stuffing)
'Date: -            22 Dec 2K8 2.30 PM (Modified Time)

'Tips: - The code is debugging at that particular dimensions, quantity and sequence.
'        you are decide it the logic happen is correct to that way or its are some 
'        different way the understanding to at your best level is the correct logic 
'        of this particular code block.

'Description: - CBArea is containing the class Area which has three members length 
'               width and height and one Point object StrtPt containing Point class  
'               members X Y Z all in Double type. Class area is containing the routine 
'               and functions to changing the starting point of placing goods object in 
'               three dimensional vrml programming this is main class to manipulate area 
'               volume and the starting points of 3D object. 

#Region " Importing Object "

Imports DBxContnr
Imports MkTxtToImgP

#End Region

Public Class Area

#Region " Class Declaration "

    Public StrtPt As New Point        'StrtPt is the startpoint of polygon >>'StrtPt' is an instance of a 'Point' class is created
    Public length As Double
    Public width As Double
    Public height As Double

#End Region

#Region " Functions definitions "

    Public Function unionyp(ByVal ar As Area) As Boolean

        If ar.StrtPt.y = Me.StrtPt.y + Me.width AndAlso ar.StrtPt.x > Me.StrtPt.x AndAlso ar.StrtPt.x < Me.StrtPt.x + Me.length AndAlso ar.StrtPt.z = Me.StrtPt.z AndAlso ar.height = Me.height Then

            Return True

        Else

            Return False

        End If

    End Function

    Public Function uniony(ByVal ar As Area) As List(Of Area)

        Dim ar1 As New Area
        Dim ar2 As New Area
        Dim lstret As New List(Of Area)

        ar1.StrtPt.x = ar.StrtPt.x
        ar1.StrtPt.y = Me.StrtPt.y
        ar1.StrtPt.z = Me.StrtPt.z
        ar1.length = Me.length - (ar.StrtPt.x - Me.StrtPt.x)
        ar1.width = Me.width + ar.width
        ar1.height = Me.height

        ar2.StrtPt.x = Me.StrtPt.x + Me.length
        ar2.StrtPt.y = ar.StrtPt.y
        ar2.StrtPt.z = Me.StrtPt.z
        ar2.length = ar.length - ((Me.StrtPt.x + Me.length) - ar.StrtPt.x)
        ar2.width = ar.width
        ar2.height = Me.height

        lstret.Add(ar1)
        lstret.Add(ar2)

        Return lstret

    End Function

    Public Function UnionItrXWad(ByVal Ar As Area) As Area

        Dim ArRet As New Area

        Dim x As Double = Me.StrtPt.x
        Dim y As Double = Me.StrtPt.y
        Dim z As Double = Me.StrtPt.z
        Dim l As Double = Me.length
        Dim w As Double = Me.width
        Dim h As Double = Me.height

        Try
            ArRet.length = -1
            ArRet.width = -1
            ArRet.height = -1

            If Ar Is Nothing Then
                Return Nothing
            End If

            If Me.length = Ar.length And Me.width = Ar.width Then
                If Me.StrtPt.x = Ar.StrtPt.x AndAlso Me.StrtPt.y = Ar.StrtPt.y Then

                    If Me.StrtPt.z = Ar.StrtPt.z + Ar.height Then
                        ArRet.length = Me.length
                        ArRet.width = Me.width
                        ArRet.height = Me.height + Ar.height
                        ArRet.StrtPt.x = Me.StrtPt.x
                        ArRet.StrtPt.y = Me.StrtPt.y
                        ArRet.StrtPt.z = Ar.StrtPt.z
                    End If

                    If Me.StrtPt.z = Me.StrtPt.z + Me.height Then
                        ArRet.length = Me.length
                        ArRet.width = Me.width
                        ArRet.height = Me.height + Ar.height
                        ArRet.StrtPt.x = Me.StrtPt.x
                        ArRet.StrtPt.y = Me.StrtPt.y
                        ArRet.StrtPt.z = Me.StrtPt.z
                    End If
                End If
            End If

            If Me.length = Ar.length And Me.height = Ar.height Then

                If Me.StrtPt.x = Ar.StrtPt.x AndAlso Me.StrtPt.z = Ar.StrtPt.z Then

                    If Me.StrtPt.y = Ar.StrtPt.y + Ar.width Then
                        ArRet.length = Me.length
                        ArRet.width = Me.width + Ar.width
                        ArRet.height = Me.height
                        ArRet.StrtPt.x = Me.StrtPt.x
                        ArRet.StrtPt.y = Ar.StrtPt.y
                        ArRet.StrtPt.z = Me.StrtPt.z
                    End If

                    If Ar.StrtPt.y = Me.StrtPt.y + Me.width Then
                        ArRet.length = Me.length
                        ArRet.width = Me.width + Ar.width
                        ArRet.height = Me.height
                        ArRet.StrtPt.x = Me.StrtPt.x
                        ArRet.StrtPt.y = Me.StrtPt.y
                        ArRet.StrtPt.z = Me.StrtPt.z
                    End If

                End If
            End If

            If Me.width = Ar.width And Me.height = Ar.height Then
                If Me.StrtPt.y = Ar.StrtPt.y AndAlso Me.StrtPt.z = Ar.StrtPt.z Then

                    If Me.StrtPt.x = Ar.StrtPt.x + Ar.length Then
                        ArRet.length = Me.length + Ar.length
                        ArRet.width = Me.width
                        ArRet.height = Me.height
                        ArRet.StrtPt.x = Ar.StrtPt.x
                        ArRet.StrtPt.y = Me.StrtPt.y
                        ArRet.StrtPt.z = Me.StrtPt.z
                    End If

                    If Ar.StrtPt.x = Me.StrtPt.x + Me.length Then
                        ArRet.length = Me.length + Ar.length
                        ArRet.width = Me.width
                        ArRet.height = Me.height
                        ArRet.StrtPt.x = Me.StrtPt.x
                        ArRet.StrtPt.y = Me.StrtPt.y
                        ArRet.StrtPt.z = Me.StrtPt.z

                    End If

                End If
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in UnionItrXWad", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        If ArRet.length = -1 Then
            Return Nothing
        Else
            Return ArRet
        End If

    End Function

    Public Function UnionItrX(ByVal ar As Area) As Area

        If Bitemqty = 10 Then
            'Stop
        End If

        Dim arret As New Area

        'Dim aa As New CDArea

        Dim X As Double = Me.StrtPt.x
        Dim Y As Double = Me.StrtPt.y
        Dim Z As Double = Me.StrtPt.z

        Dim L As Double = Me.length
        Dim W As Double = Me.width
        Dim H As Double = Me.height

        Try
            arret.length = -1
            arret.width = -1
            arret.height = -1

            If ar Is Nothing Then
                Return Nothing
            End If

            If Me.length = ar.length And Me.width = ar.width Then
                If Me.StrtPt.x = ar.StrtPt.x AndAlso Me.StrtPt.y = ar.StrtPt.y Then

                    If Me.StrtPt.z = ar.StrtPt.z + ar.height Then
                        arret.length = Me.length
                        arret.width = Me.width
                        arret.height = Me.height + ar.height
                        arret.StrtPt.x = Me.StrtPt.x
                        arret.StrtPt.y = Me.StrtPt.y
                        arret.StrtPt.z = ar.StrtPt.z
                    End If

                    If ar.StrtPt.z = Me.StrtPt.z + Me.height Then
                        arret.length = Me.length
                        arret.width = Me.width
                        arret.height = Me.height + ar.height
                        arret.StrtPt.x = Me.StrtPt.x
                        arret.StrtPt.y = Me.StrtPt.y
                        arret.StrtPt.z = Me.StrtPt.z
                    End If
                End If

            End If

            ''
            If Me.length = ar.length And Me.height = ar.height Then

                If Me.StrtPt.x = ar.StrtPt.x AndAlso Me.StrtPt.z = ar.StrtPt.z Then

                    If Me.StrtPt.y = ar.StrtPt.y + ar.width Then
                        arret.length = Me.length
                        arret.width = Me.width + ar.width
                        arret.height = Me.height
                        arret.StrtPt.x = Me.StrtPt.x
                        arret.StrtPt.y = ar.StrtPt.y
                        arret.StrtPt.z = Me.StrtPt.z
                    End If

                    If ar.StrtPt.y = Me.StrtPt.y + Me.width Then
                        arret.length = Me.length
                        arret.width = Me.width + ar.width
                        arret.height = Me.height
                        arret.StrtPt.x = Me.StrtPt.x
                        arret.StrtPt.y = Me.StrtPt.y
                        arret.StrtPt.z = Me.StrtPt.z
                    End If

                End If
            End If

            If Me.width = ar.width And Me.height = ar.height Then
                If Me.StrtPt.y = ar.StrtPt.y AndAlso Me.StrtPt.z = ar.StrtPt.z Then

                    If Me.StrtPt.x = ar.StrtPt.x + ar.length Then
                        arret.length = Me.length + ar.length
                        arret.width = Me.width
                        arret.height = Me.height
                        arret.StrtPt.x = ar.StrtPt.x
                        arret.StrtPt.y = Me.StrtPt.y
                        arret.StrtPt.z = Me.StrtPt.z

                    End If

                    If ar.StrtPt.x = Me.StrtPt.x + Me.length Then
                        arret.length = Me.length + ar.length
                        arret.width = Me.width
                        arret.height = Me.height
                        arret.StrtPt.x = Me.StrtPt.x
                        arret.StrtPt.y = Me.StrtPt.y
                        arret.StrtPt.z = Me.StrtPt.z

                    End If

                End If
            End If

            'If Me.width > ar.width AndAlso Me.length > ar.length AndAlso Me.height > ar.height Then

            '    If ar.StrtPt.x < Me.StrtPt.x AndAlso ar.StrtPt.y < Me.StrtPt.y AndAlso ar.StrtPt.z < Me.StrtPt.z Then

            '        arret.length = ar.length
            '        arret.width = ar.StrtPt.y + ar.width
            '        arret.height = Me.StrtPt.z
            '        arret.StrtPt.x = Me.StrtPt.x
            '        arret.StrtPt.y = ar.StrtPt.y + ar.width
            '        arret.StrtPt.z = Me.StrtPt.z

            '    End If

            'End If


        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in UnionItrX" & vbCrLf & "VRML Programme writting logic is failure!", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'MsgBox("Exception :: In method 'UnionItrX'  " & vbCrLf & "VRML Programme writting logic is failure!")
            conn.Close()
            off.Close()
        End Try

        If arret.length = -1 Then
            Return Nothing
        Else
            Return arret
        End If

    End Function

    Public Function subtract_Mild(ByVal a1 As Area) As Queue(Of Area)

        'EStop

        Dim ar As New Queue(Of Area)

        Dim ar1 As New Area

        Dim ar2 As New Area

        Dim ar3 As New Area

        Try

            a1.StrtPt.x = Math.Round(a1.StrtPt.x, 4)

            a1.StrtPt.y = Math.Round(a1.StrtPt.y, 4)

            a1.StrtPt.z = Math.Round(a1.StrtPt.z, 4)


            a1.length = Math.Round(a1.length, 4)

            a1.width = Math.Round(a1.width, 4)

            a1.height = Math.Round(a1.height, 4)



            If a1.StrtPt <> Me.StrtPt Then

                Return Nothing

            End If


            If a1.length > Me.length OrElse a1.width > Me.width OrElse a1.height > Me.height Then

                Return Nothing

            End If

            If a1.length < Me.length Then

                ar3.StrtPt.x = Me.StrtPt.x + a1.length

                ar3.StrtPt.y = Me.StrtPt.y

                ar3.StrtPt.z = Me.StrtPt.z

                ar3.length = (Me.length - a1.length) - (a1.length * 0.5)

                ar3.width = Me.width

                ar3.height = Me.height

                If ar3.isvalid Then

                    ar.Enqueue(ar3)

                End If

            End If


            If a1.width < Me.width Then

                ar2.StrtPt.x = Me.StrtPt.x

                ar2.StrtPt.y = Me.StrtPt.y + a1.width

                ar2.StrtPt.z = Me.StrtPt.z

                ar2.length = a1.length

                ar2.width = (Me.width - a1.width) - (a1.width * 0.5)

                ar2.height = Me.height

                If ar2.isvalid Then

                    ar.Enqueue(ar2)

                End If

            End If


            If a1.height < Me.height Then

                ar1.length = a1.length

                ar1.width = a1.width

                ar1.height = (Me.height - a1.height)

                ar1.StrtPt.x = Me.StrtPt.x

                ar1.StrtPt.y = Me.StrtPt.y

                ar1.StrtPt.z = Me.StrtPt.z + (a1.height)

                If ar1.isvalid Then

                    ar.Enqueue(ar1)

                End If

            End If

            Return ar

        Catch Er As Exception

            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in subtract", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return Nothing

            conn.Close()

            off.Close()

        End Try

    End Function

    Public Function SubtarctBx(ByVal A1 As Area) As Queue(Of Area) 'Public Function subtarct(ByVal A1 As Area) As Queue(Of Area)  '          

        'Stop

        Dim ArS As New Queue(Of Area)
        Dim Ar1 As New Area
        Dim Ar2 As New Area
        Dim Ar3 As New Area

        Try
            A1.StrtPt.x = Math.Round(A1.StrtPt.x, 5)
            A1.StrtPt.y = Math.Round(A1.StrtPt.y, 5)
            A1.StrtPt.z = Math.Round(A1.StrtPt.z, 5)

            A1.length = Math.Round(A1.length, 5)
            A1.width = Math.Round(A1.width, 5)
            A1.height = Math.Round(A1.height)

            Dim CL As Double = Lbc
            Dim CW As Double = Wbc
            Dim CH As Double = Hbc

            If A1.StrtPt <> Me.StrtPt Then

                Return Nothing

            End If

            If A1.length > Me.length OrElse A1.width > Me.width OrElse A1.height > Me.height Then

                Return Nothing

            End If

            If A1.length < Me.length Then

                Ar3.StrtPt.x = Me.StrtPt.x + A1.length

                Ar3.StrtPt.y = Me.StrtPt.y

                Ar3.StrtPt.z = Me.StrtPt.z

                Ar3.length = Me.length - A1.length     'Ar3.length = (Me.length - A1.length) - (A1.length * 0.5)

                Ar3.width = Me.width

                Ar3.height = Me.height

                If Ar3.isvalid Then

                    ArS.Enqueue(Ar3)

                End If

            End If

            If A1.width < Me.width Then

                Ar2.StrtPt.x = Me.StrtPt.x

                Ar2.StrtPt.y = Me.StrtPt.y + A1.width

                Ar2.StrtPt.z = Me.StrtPt.z

                Ar2.length = A1.length

                Ar2.width = (Me.width - A1.width)         'Ar2.width = (Me.width - A1.width) - (A1.width * 0.5)

                Ar2.height = Me.height

                If Ar2.isvalid Then

                    ArS.Enqueue(Ar2)

                End If

            End If

            If A1.height < Me.height Then

                Ar1.length = A1.length

                Ar1.width = A1.width

                Ar1.height = (Me.height - A1.height)

                Ar1.StrtPt.x = Me.StrtPt.x

                Ar1.StrtPt.y = Me.StrtPt.y

                Ar1.StrtPt.z = Me.StrtPt.z + A1.height
               
                If Ar1.isvalid Then

                    ArS.Enqueue(Ar1)

                End If

            End If

            'Stop

            '=====

            Dim ChtCont As Double = Ar1.StrtPt.z + Hbi

            If Ar1.StrtPt.z > CH Then
                Return Nothing
            End If

            '=====

            Return ArS

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in SubtarctBx", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return ArS

    End Function

    Public Function SubtractWad(ByVal A1 As Area) As Queue(Of Area)

        'Implements from here 12 Nov 2K8

        Dim Ar As New Queue(Of Area)

        Dim ArHt As New Area
        Dim ArWd As New Area
        Dim ArLn As New Area

        Dim X As Double = Me.StrtPt.x
        Dim Y As Double = Me.StrtPt.y
        Dim Z As Double = Me.StrtPt.z

        Dim Ht As Double = Me.height
        Dim Wd As Double = Me.width
        Dim Ln As Double = Me.length

        Try
            A1.StrtPt.x = Math.Round(A1.StrtPt.x, 4)
            A1.StrtPt.y = Math.Round(A1.StrtPt.y, 4)
            A1.StrtPt.z = Math.Round(A1.StrtPt.z, 4)

            A1.length = Math.Round(A1.length, 4)
            A1.width = Math.Round(A1.width, 4)
            A1.height = Math.Round(A1.height, 4)

            If A1.StrtPt <> Me.StrtPt Then
                Return Nothing
            End If

            If A1.length > Me.length OrElse A1.width > Me.width OrElse A1.height > Me.height Then
                Return Nothing
            End If

            If A1.length < Me.length Then
                ArLn.StrtPt.x = Me.StrtPt.x + A1.length
                ArLn.StrtPt.y = Me.StrtPt.y
                ArLn.StrtPt.z = Me.StrtPt.z
                ArLn.length = Me.length - A1.length
                ArLn.width = Me.width
                ArLn.height = Me.height
                If ArLn.IsValidWad Then
                    Ar.Enqueue(ArLn)
                End If
            End If

            If A1.width < Me.width Then
                ArWd.StrtPt.x = Me.StrtPt.x
                ArWd.StrtPt.y = Me.StrtPt.y + A1.width
                ArWd.StrtPt.z = Me.StrtPt.z
                ArWd.length = Me.length
                ArWd.width = Me.width - A1.width
                ArWd.height = Me.height
                If ArWd.IsValidWad Then
                    Ar.Enqueue(ArWd)
                End If
            End If

            If A1.height < Me.height Then
                ArHt.StrtPt.x = Me.StrtPt.x
                ArHt.StrtPt.y = Me.StrtPt.y
                ArHt.StrtPt.z = Me.StrtPt.z + A1.height
                ArHt.length = Me.length
                ArHt.width = Me.width
                ArHt.height = Me.height - A1.height
                If ArWd.IsValidWad Then
                    Ar.Enqueue(ArHt)
                End If
            End If

            Return Ar

        Catch Exr As Exception
            MsgBox(Exr.Message)
            MsgBox(Exr.ToString)
            MessageBox.Show("Error in SubtractWad", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try

        Return Nothing

    End Function

    'Public Function VolumeSubtract(ByVal BxVol As CVolume, ByVal OriV As CVolume) As Queue(Of CVolume)
    Public Function VolumeSubtract(ByVal BxVol As Area, ByVal OriV As Area) As Queue(Of Area)

        Dim VolRet As New Queue(Of Area)
        Dim vol1 As New Area
        Dim vol2 As New Area
        Dim vol3 As New Area
        Dim vol4 As New Area

        BxVol.length = Math.Round(BxVol.length, 4)
        BxVol.width = Math.Round(BxVol.width, 4)
        BxVol.height = Math.Round(BxVol.height, 4)

        BxVol.StrtPt.x = Math.Round(BxVol.StrtPt.x)
        BxVol.StrtPt.y = Math.Round(BxVol.StrtPt.y)
        BxVol.StrtPt.z = Math.Round(BxVol.StrtPt.z)

        If BxVol.StrtPt <> Me.StrtPt Then
            Return Nothing
        End If

        If BxVol.length > Me.length OrElse BxVol.width > Me.width OrElse BxVol.height > Me.height Then
            Return Nothing
        End If

        If BxVol.length < Me.length Then

            vol4.StrtPt.x = Me.StrtPt.x + BxVol.length
            vol4.StrtPt.y = Me.StrtPt.y
            vol4.StrtPt.z = Me.StrtPt.z

            vol4.Length = Me.length - BxVol.length
            vol4.Width = Me.width
            vol4.Height = Me.height

            If vol4.isvalid Then
                VolRet.Enqueue(vol4)
            End If

        End If

        If BxVol.length < Me.length AndAlso BxVol.width < Me.width Then

            vol3.StrtPt.x = Me.StrtPt.x + BxVol.length
            vol3.StrtPt.y = Me.StrtPt.y + BxVol.width
            vol3.StrtPt.z = Me.StrtPt.z

            vol3.Length = Me.length - BxVol.length
            vol3.Width = Me.width - BxVol.width
            vol3.Height = Me.StrtPt.z

            If vol3.isvalid Then
                VolRet.Enqueue(vol3)
            End If

        End If

        If BxVol.width < Me.width Then

            vol2.StrtPt.x = Me.StrtPt.x
            vol2.StrtPt.y = Me.StrtPt.y + BxVol.width
            vol2.StrtPt.z = Me.StrtPt.z

            vol2.Length = Me.length
            vol2.Width = Me.width - BxVol.width
            vol2.Height = Me.height

            If vol2.isvalid Then
                VolRet.Enqueue(vol2)
            End If

        End If

        If BxVol.height < Me.height Then

            vol1.StrtPt.x = Me.StrtPt.x
            vol1.StrtPt.y = Me.StrtPt.y
            vol1.StrtPt.z = Me.StrtPt.z + BxVol.height

            vol1.Length = Me.length
            vol1.Width = Me.width
            vol1.Height = Me.height - BxVol.height

            If vol1.isvalid Then
                VolRet.Enqueue(vol1)
            End If

        End If

        Return VolRet

    End Function

    Public Function subtract(ByVal a1 As Area) As Queue(Of Area)   'Orig

        'Dim BxVol As Area = a1

        ''=========================================================================

        ''Dim qs As New Queue(Of Area)
        ''Dim aes As New Area

        ''aes.length = CL
        ''aes.width = CW
        ''aes.height = CH

        ''aes.StrtPt.x = a1.StrtPt.x
        ''aes.StrtPt.y = a1.StrtPt.y
        ''aes.StrtPt.z = a1.StrtPt.z

        ''qs = a1.VolumeSubtract(a1, aes)

        If BitemqtyInr = 46 Then
            'Stop
        End If

        If BitemqtyInr = 53 Or BitemqtyInr = 54 Then
            'Stop
        End If

        Dim ar As New Queue(Of Area)
        Dim ar1 As New Area
        Dim ar2 As New Area
        Dim ar3 As New Area

        Try
            a1.StrtPt.x = Math.Round(a1.StrtPt.x, 4)
            a1.StrtPt.y = Math.Round(a1.StrtPt.y, 4)
            a1.StrtPt.z = Math.Round(a1.StrtPt.z, 4)

            a1.length = Math.Round(a1.length, 4)
            a1.width = Math.Round(a1.width, 4)
            a1.height = Math.Round(a1.height, 4)

            Dim Xx As Double = a1.StrtPt.x
            Dim Yy As Double = a1.StrtPt.y
            Dim Zz As Double = a1.StrtPt.z

            Dim Lnx As Double = a1.length
            Dim Wdy As Double = a1.width
            Dim Htz As Double = a1.height

            Dim X As Double = Me.StrtPt.x
            Dim Y As Double = Me.StrtPt.y
            Dim Z As Double = Me.StrtPt.z

            Dim Ln As Double = Me.length
            Dim Wd As Double = Me.width
            Dim Ht As Double = Me.height

            If a1.StrtPt <> Me.StrtPt Then
                Return Nothing
            End If

            If a1.length > Me.length OrElse a1.width > Me.width OrElse a1.height > Me.height Then
                Return Nothing
            End If

            If a1.length < Me.length Then
                ar3.StrtPt.x = Me.StrtPt.x + a1.length
                ar3.StrtPt.y = Me.StrtPt.y
                ar3.StrtPt.z = Me.StrtPt.z
                ar3.length = Me.length - a1.length
                ar3.width = Me.width
                ar3.height = Me.height
                If ar3.isvalid Then
                    ar.Enqueue(ar3)
                End If
            End If

            If a1.width < Me.width Then
                ar2.StrtPt.x = Me.StrtPt.x
                ar2.StrtPt.y = Me.StrtPt.y + a1.width
                ar2.StrtPt.z = Me.StrtPt.z
                ar2.length = a1.length
                ar2.width = Me.width - a1.width
                ar2.height = Me.height
                If ar2.isvalid Then
                    ar.Enqueue(ar2)
                End If
            End If

            If a1.height < Me.height Then
                ar1.length = a1.length
                ar1.width = a1.width
                ar1.height = Me.height - a1.height
                ar1.StrtPt.x = Me.StrtPt.x
                ar1.StrtPt.y = Me.StrtPt.y

                ar1.StrtPt.z = Me.StrtPt.z + (a1.height)

                If ar1.isvalid Then
                    ar.Enqueue(ar1)
                End If
            End If

            Return ar


            ''================================================================================================================================================
            ''Stop

            'Dim VolRet As New Queue(Of Area)
            'Dim vol1 As New Area
            'Dim vol2 As New Area
            'Dim vol3 As New Area
            'Dim vol4 As New Area

            'BxVol.length = Math.Round(BxVol.length, 4)
            'BxVol.width = Math.Round(BxVol.width, 4)
            'BxVol.height = Math.Round(BxVol.height, 4)

            'BxVol.StrtPt.x = Math.Round(BxVol.StrtPt.x)
            'BxVol.StrtPt.y = Math.Round(BxVol.StrtPt.y)
            'BxVol.StrtPt.z = Math.Round(BxVol.StrtPt.z)

            'If BxVol.StrtPt <> Me.StrtPt Then
            '    Return Nothing
            'End If

            'If BxVol.length > Me.length OrElse BxVol.width > Me.width OrElse BxVol.height > Me.height Then
            '    Return Nothing
            'End If

            'If BxVol.length < Me.length Then

            '    vol4.StrtPt.x = Me.StrtPt.x + BxVol.length
            '    vol4.StrtPt.y = Me.StrtPt.y
            '    vol4.StrtPt.z = Me.StrtPt.z

            '    vol4.length = Me.length - BxVol.length
            '    vol4.width = Me.width - (Me.width - BxVol.width)
            '    vol4.height = Me.height

            '    If vol4.isvalid Then
            '        VolRet.Enqueue(vol4)
            '    End If

            'End If

            'If BxVol.length < Me.length AndAlso BxVol.width < Me.width Then

            '    vol3.StrtPt.x = Me.StrtPt.x + BxVol.length
            '    vol3.StrtPt.y = Me.StrtPt.y + BxVol.width
            '    vol3.StrtPt.z = Me.StrtPt.z

            '    vol3.length = Me.length - BxVol.length
            '    vol3.width = Me.width - BxVol.width
            '    vol3.height = Me.height

            '    If vol3.isvalid Then
            '        VolRet.Enqueue(vol3)
            '    End If

            'End If

            'If BxVol.width < Me.width Then

            '    vol2.StrtPt.x = Me.StrtPt.x
            '    vol2.StrtPt.y = Me.StrtPt.y + BxVol.width
            '    vol2.StrtPt.z = Me.StrtPt.z

            '    vol2.length = BxVol.length
            '    vol2.width = Me.width - BxVol.width
            '    vol2.height = Me.height

            '    If vol2.isvalid Then
            '        VolRet.Enqueue(vol2)
            '    End If

            'End If

            'If BxVol.height < Me.height Then

            '    vol1.StrtPt.x = Me.StrtPt.x
            '    vol1.StrtPt.y = Me.StrtPt.y
            '    vol1.StrtPt.z = Me.StrtPt.z + BxVol.height

            '    vol1.length = BxVol.length
            '    vol1.width = BxVol.width
            '    vol1.height = Me.height - BxVol.height

            '    If vol1.isvalid Then
            '        VolRet.Enqueue(vol1)
            '    End If

            'End If

            'Return VolRet



        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in subtract", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
            conn.Close()
            off.Close()
        End Try

    End Function

    '//////////////
    'Dim cmd As New OleDb.OleDbCommand
    'cmd.Connection = conn
    'cmd.CommandText = "insert into stuffdata values('" & matname & "'," & CStr(Me.StrtPt.x) & "," & CStr(Me.StrtPt.y) & "," & CStr(Me.StrtPt.z) & "," & CStr(Me.length) & "," & CStr(Me.width) & "," & CStr(Me.height) & "," & CStr(method) & ",'" & col & "','" & tex & "',0)"
    'cmd.ExecuteNonQuery()
    '/////////////

    Public Function SubAction(ByVal Par As Area, ByVal PArINm() As String, ByVal ImgNm As String) As Queue(Of Area)

        'Stop

        '*******************************************
        If BitemqtyInr = 9 Then

            'Stop
            'MsgBox("OK")
            'off.Close()
        End If

        If BitemqtyInr > 39 Then

            'Stop
            'off.Close()

        End If
        '*******************************************

        Try

            Dim PrvAr As New Region

            PrvAr.All.length = Math.Round(Par.length, 4)
            PrvAr.All.width = Math.Round(Par.width, 4)
            PrvAr.All.height = Math.Round(Par.height, 4)

            PrvAr.All.StrtPt.x = Math.Round(Par.StrtPt.x, 4)
            PrvAr.All.StrtPt.y = Math.Round(Par.StrtPt.y, 4)
            PrvAr.All.StrtPt.z = Math.Round(Par.StrtPt.z, 4)

            If PrvAr.All.StrtPt.x = 28 And PrvAr.All.StrtPt.y = 10 Then
                'Stop
            End If

            ''##################################

            Dim ICnt As Int16 = BitemqtyInr - 2         'Dim ICnt As Int16 = BitemqtyInr - 1
            Dim GdsNm As String = PArINm(ICnt)
            'Dim lblNM As String = "1"

            'If lblNM <> ImgNm Then

            '    If conn.State = ConnectionState.Closed Then conn.Open()
            '    Dim ODc As New OleDb.OleDbCommand

            '    ODc.Connection = conn
            '    ODc.CommandText = "insert into pgCord values (" & CStr(Gdn) & ",'" & GdsNm & "'," & CStr(PrvAr.All.StrtPt.x) & "," & CStr(PrvAr.All.StrtPt.y) & "," & CStr(PrvAr.All.StrtPt.z) & ")"
            '    ODc.ExecuteNonQuery()

            '    Gdn += 1

            'End If

            ''##################################

            'Dim Gdn As Int16 = CInt(Convert.ToInt16(ImgNm))

            'Do While Gdn = CInt(Convert.ToInt16(ImgNm))             'Do While Gdn = Gdn + 1 Or Gdn = 1

            '    If conn.State = ConnectionState.Closed Then conn.Open()
            '    Dim ODc As New OleDb.OleDbCommand

            '    ODc.Connection = conn
            '    ODc.CommandText = "insert into pgCord values (" & CStr(Gdn) & ",'" & GdsNm & "'," & CStr(PrvAr.All.length) & "," & CStr(PrvAr.All.width) & "," & CStr(PrvAr.All.height) & ")"
            '    ODc.ExecuteNonQuery()

            '    Gdn += 1

            'Loop


            'If 1 Then       'If ImgNm = "1" Or ImgNm = "2" Then       'If ICnt = 0 Then

            '    If conn.State = ConnectionState.Closed Then conn.Open()

            '    Dim Cmd As New OleDb.OleDbCommand
            '    Cmd.Connection = conn
            '    Cmd.CommandText = "delete from pgRecord"
            '    Cmd.ExecuteNonQuery()

            '    Dim OCmd As New OleDb.OleDbCommand
            '    OCmd.Connection = conn
            '    OCmd.CommandText = "insert into pgRecord values ('" & GdsNm & "'," & CStr(PrvAr.All.length) & "," & CStr(PrvAr.All.width) & "," & CStr(PrvAr.All.height) & "," & CStr(PrvAr.All.StrtPt.x) & "," & CStr(PrvAr.All.StrtPt.y) & "," & CStr(PrvAr.All.StrtPt.z) & ")"
            '    OCmd.ExecuteNonQuery()

            'End If
            'off.Close()
            '#####
            'Stop
            '#####
        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in SubAction of Recorder", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        'Try

        '    If Cons.State = ConnectionState.Closed Then Cons.Open()
        '    Dim CmdR As New OleDb.OleDbCommand
        '    Dim RdrR As OleDb.OleDbDataReader
        '    CmdR.Connection = Cons

        '    CmdR.CommandText = "select XtL, YtW, ZtH from pgRecord"
        '    RdrR = CmdR.ExecuteReader

        '    Dim ArR As New Region
        '    Dim ArC As New Region

        '    Do While (RdrR.Read())

        '        ArR.All.StrtPt.x = RdrR("XtL")
        '        ArR.All.StrtPt.y = RdrR("YtW")
        '        ArR.All.StrtPt.z = RdrR("ZtH")

        '    Loop

        '    If Cons.State = ConnectionState.Closed Then Cons.Open()
        '    Dim CmdC As New OleDb.OleDbCommand
        '    Dim RdrC As OleDb.OleDbDataReader
        '    CmdC.Connection = Cons

        '    CmdC.CommandText = "select Xln, Ywd, Zht from pgCord where Gdn = 1"
        '    RdrC = CmdC.ExecuteReader

        '    Do While (RdrC.Read())

        '        ArC.All.StrtPt.x = RdrC("Xln")
        '        ArC.All.StrtPt.y = RdrC("Ywd")
        '        ArC.All.StrtPt.z = RdrC("Zht")

        '    Loop

        '    'Stop

        '    If ArC.All.StrtPt.x < ArR.All.StrtPt.x Then
        '        Stop
        '    End If
        'Catch Er As Exception
        '    MsgBox(Er.Message)
        '    MessageBox.Show("Error in SubAction Query Records", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try

        '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

        'off.Close()
        'If conn.State = ConnectionState.Closed Then conn.Open()

        'Dim Cmds As New OleDb.OleDbCommand
        'Cmds.Connection = conn
        'Cmds.CommandText = "delete XtL,YtW,ZtH from pgRecord"
        'Cmds.ExecuteNonQuery()

        '*************************************************************************************
        '*************************************************************************************

        Dim X As Double = Me.StrtPt.x
        Dim Y As Double = Me.StrtPt.y
        Dim Z As Double = Me.StrtPt.z

        Dim Len As Double = Me.length
        Dim wid As Double = Me.width
        Dim Hei As Double = Me.height

        Dim a1 As Area = Par
        Dim ar As New Queue(Of Area)
        Dim Ar1 As New Region       'Dim ar1 As New Area
        Dim Ar2 As New Region       'Dim ar2 As New Area
        Dim Ar3 As New Region       'Dim ar3 As New Area

        Try

            a1.StrtPt.x = Math.Round(a1.StrtPt.x, 4)
            a1.StrtPt.y = Math.Round(a1.StrtPt.y, 4)
            a1.StrtPt.z = Math.Round(a1.StrtPt.z, 4)

            a1.length = Math.Round(a1.length, 4)
            a1.width = Math.Round(a1.width, 4)
            a1.height = Math.Round(a1.height, 4)

            If a1.StrtPt <> Me.StrtPt Then
                Return Nothing
            End If

            If a1.length > Me.length OrElse a1.width > Me.width OrElse a1.height > Me.height Then
                Return Nothing
            End If

            If a1.length < Me.length Then
                Ar3.StrtPt.x = Me.StrtPt.x + a1.length
                Ar3.StrtPt.y = Me.StrtPt.y
                Ar3.StrtPt.z = Me.StrtPt.z
                Ar3.length = Me.length - a1.length
                Ar3.width = Me.width
                Ar3.height = Me.height
                If Ar3.isvalid Then
                    ar.Enqueue(Ar3)
                End If
            End If
            'off.Close()

            'If Me.StrtPt.x > a1.length Then
            '    Ar2.StrtPt.x = Me.StrtPt.x
            '    Ar2.StrtPt.y = Me.StrtPt.y - Me.StrtPt.y
            '    Ar2.StrtPt.z = Me.StrtPt.z
            '    Ar2.length = a1.length
            '    Ar2.width = Me.width
            '    Ar2.height = Me.height
            '    If Ar2.isvalid Then
            '        ar.Enqueue(Ar2)
            '    End If

            'ElseIf a1.width < Me.width Then

            If a1.width < Me.width Then
                Ar2.StrtPt.x = Me.StrtPt.x
                Ar2.StrtPt.y = Me.StrtPt.y + a1.width
                Ar2.StrtPt.z = Me.StrtPt.z
                Ar2.length = a1.length
                Ar2.width = Me.width - a1.width
                Ar2.height = Me.height
                If Ar2.isvalid Then
                    ar.Enqueue(Ar2)
                End If
            End If

            If a1.height < Me.height Then
                Ar1.length = a1.length
                Ar1.width = a1.width
                Ar1.height = Me.height - a1.height
                Ar1.StrtPt.x = Me.StrtPt.x
                Ar1.StrtPt.y = Me.StrtPt.y

                Ar1.StrtPt.z = Me.StrtPt.z + (a1.height)

                If Ar1.isvalid Then
                    ar.Enqueue(Ar1)
                End If
            End If

            Return ar

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in SubAction", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
            conn.Close()
            off.Close()
        End Try
        'Stop
        '*************************************************************************************
        '*************************************************************************************
    End Function

    'Public Function SdOps(ByVal pr As Area, ByVal ImgNm As String) As Queue(Of Area)

    '    Dim X As Double = Me.StrtPt.x
    '    Dim Y As Double = Me.StrtPt.y
    '    Dim Z As Double = Me.StrtPt.z

    '    Dim Len As Double = Me.length
    '    Dim wid As Double = Me.width
    '    Dim Hei As Double = Me.height

    '    Dim ArSa As New Area
    '    Dim qPr As New Queue(Of Area)
    '    Dim prL As New Area
    '    Dim prW As New Area
    '    Dim prH As New Area
    '    Dim ItmNm As String = "1"

    '    If pr.length > Me.length OrElse pr.width > Me.width OrElse pr.height > Me.height Then
    '        Return Nothing
    '    End If

    '    If ItmNm <> ImgNm Then

    '    End If

    '    If pr.length < Me.length AndAlso pr.StrtPt.x < Xl3d Then

    '        prL.StrtPt.x = pr.StrtPt.x + Me.length
    '        prL.StrtPt.y = Me.StrtPt.y
    '        prL.StrtPt.z = Me.StrtPt.z
    '        prL.length = Me.length - pr.length
    '        prL.width = Me.width
    '        prL.height = Me.height

    '        If prL.CheckOut Then
    '            qPr.Enqueue(prL)
    '        End If
    '    End If

    '    If pr.width < Me.width AndAlso pr.StrtPt.y < Yl3d Then

    '        prW.StrtPt.x = Me.StrtPt.x
    '        prW.StrtPt.y = pr.StrtPt.y + Me.StrtPt.y
    '        prW.StrtPt.z = Me.StrtPt.z
    '        prW.length = Me.length
    '        prW.width = Me.width - pr.width
    '        prW.height = Me.height

    '        If prW.CheckOut Then
    '            qPr.Enqueue(prW)
    '        End If
    '    End If

    '    If pr.height < Me.height AndAlso pr.StrtPt.z < Zl3d Then

    '        prH.StrtPt.x = Me.StrtPt.x
    '        prH.StrtPt.y = Me.StrtPt.y
    '        prH.StrtPt.z = pr.StrtPt.z + Me.StrtPt.z
    '        prH.length = Me.length
    '        prH.width = Me.width
    '        prH.height = pr.StrtPt.z + Me.StrtPt.z

    '        If prH.CheckOut Then
    '            qPr.Enqueue(prH)
    '        End If

    '    End If

    '    Return qPr

    'End Function

    Public Function subtractx(ByVal a1 As Area) As Queue(Of Area)

        Dim ar As New Queue(Of Area)
        Dim ar1 As New Area
        Dim ar2 As New Area
        Dim ar3 As New Area

        If a1.StrtPt <> Me.StrtPt Then
            Return Nothing
        End If

        If a1.length > Me.length OrElse a1.width > Me.width OrElse a1.height > Me.height Then
            Return Nothing
        End If

        If a1.length < Me.length Then
            ar3.StrtPt.x = Me.StrtPt.x + a1.length
            ar3.StrtPt.y = Me.StrtPt.y
            ar3.StrtPt.z = Me.StrtPt.z
            ar3.length = Me.length - a1.length
            ar3.width = a1.width
            ar3.height = Me.height
            If ar3.isvalid Then
                ar.Enqueue(ar3)
            End If
        End If

        If a1.width < Me.width Then
            ar2.StrtPt.x = Me.StrtPt.x
            ar2.StrtPt.y = Me.StrtPt.y + a1.width
            ar2.StrtPt.z = Me.StrtPt.z
            ar2.length = Me.length
            ar2.width = Me.width - a1.width
            ar2.height = Me.height
            If ar2.isvalid Then
                ar.Enqueue(ar2)
            End If
        End If

        If a1.height < Me.height Then
            ar1.length = a1.length
            ar1.width = a1.width
            ar1.height = Me.height - a1.height
            ar1.StrtPt.x = Me.StrtPt.x
            ar1.StrtPt.y = Me.StrtPt.y

            ar1.StrtPt.z = Me.StrtPt.z + (a1.height)

            If ar1.isvalid Then
                ar.Enqueue(ar1)
            End If
        End If

        Return ar

    End Function

    Public Function subtractold1(ByVal a1 As Area) As Queue(Of Area)

        Dim ar As New Queue(Of Area)
        Dim ar1 As New Area
        Dim ar2 As New Area
        Dim ar3 As New Area

        If a1.StrtPt <> Me.StrtPt Then
            Return Nothing
        End If

        If a1.length > Me.length OrElse a1.width > Me.width OrElse a1.height > Me.height Then
            Return Nothing
        End If

        If a1.length < Me.length Then
            ar3.StrtPt.x = Me.StrtPt.x + a1.length
            ar3.StrtPt.y = Me.StrtPt.y
            ar3.StrtPt.z = Me.StrtPt.z
            ar3.length = Me.length - a1.length
            ar3.width = a1.width
            ar3.height = Me.height
            If ar3.isvalid Then
                ar.Enqueue(ar3)
            End If
        End If

        If a1.width < Me.width Then
            ar2.StrtPt.x = Me.StrtPt.x
            ar2.StrtPt.y = Me.StrtPt.y + a1.width
            ar2.StrtPt.z = Me.StrtPt.z
            ar2.length = Me.length
            ar2.width = Me.width - a1.width
            ar2.height = Me.height
            If ar2.isvalid Then
                ar.Enqueue(ar2)
            End If
        End If

        If a1.height < Me.height Then
            ar1.length = a1.length
            ar1.width = a1.width
            ar1.height = Me.height - a1.height
            ar1.StrtPt.x = Me.StrtPt.x
            ar1.StrtPt.y = Me.StrtPt.y

            ar1.StrtPt.z = Me.StrtPt.z + (a1.height)

            If ar1.isvalid Then
                ar.Enqueue(ar1)
            End If
        End If

        Return ar

    End Function

    Public Function CheckOut() As Boolean

        Try

            If Me.length = 0 OrElse Me.height = 0 OrElse Me.width = 0 Then
                Return False
            Else
                Return True
            End If

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in CheckOut", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function

    Public Function isvalid() As Boolean

        Try

            If Me.width = 0 OrElse Me.height = 0 OrElse Me.length = 0 Then
                Return True
            Else
                Return True
            End If

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in isvalid", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function

    Public Function IsValidWad() As Boolean

        Try

            If Me.width = 0 OrElse Me.height = 0 OrElse Me.length = 0 Then
                Return False
            Else
                Return True
            End If

        Catch Erx As Exception
            MsgBox(Erx.Message)
            MsgBox(Erx.ToString)
            MessageBox.Show("Error in IsValidWad", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function

#End Region

    'Public Function subtract(ByVal a1 As Area) As Queue(Of Area)  'Milind1

    '    Dim ar As New Queue(Of Area)

    '    Dim ar1 As New Area

    '    Dim ar2 As New Area

    '    Dim ar3 As New Area


    '    Try

    '        a1.StrtPt.x = Math.Round(a1.StrtPt.x, 4)

    '        a1.StrtPt.y = Math.Round(a1.StrtPt.y, 4)

    '        a1.StrtPt.z = Math.Round(a1.StrtPt.z, 4)



    '        a1.length = Math.Round(a1.length, 4)

    '        a1.width = Math.Round(a1.width, 4)

    '        a1.height = Math.Round(a1.height, 4)



    '        If a1.StrtPt <> Me.StrtPt Then

    '            Return Nothing

    '        End If



    '        If a1.length > Me.length OrElse a1.width > Me.width OrElse a1.height > Me.height Then

    '            Return Nothing

    '        End If



    '        If a1.length < Me.length Then

    '            ar3.StrtPt.x = Me.StrtPt.x + a1.length

    '            ar3.StrtPt.y = Me.StrtPt.y

    '            ar3.StrtPt.z = Me.StrtPt.z

    '            ar3.length = (Me.length - a1.length) - (a1.length * 0.5)

    '            ar3.width = Me.width

    '            ar3.height = Me.height

    '            If ar3.isvalid Then

    '                ar.Enqueue(ar3)

    '            End If

    '        End If



    '        If a1.width < Me.width Then

    '            ar2.StrtPt.x = Me.StrtPt.x

    '            ar2.StrtPt.y = Me.StrtPt.y + a1.width

    '            ar2.StrtPt.z = Me.StrtPt.z

    '            ar2.length = a1.length

    '            ar2.width = (Me.width - a1.width) - (a1.width * 0.5)

    '            ar2.height = Me.height

    '            If ar2.isvalid Then

    '                ar.Enqueue(ar2)

    '            End If



    '        End If



    '        If a1.height < Me.height Then



    '            ar1.length = a1.length

    '            ar1.width = a1.width

    '            ar1.height = (Me.height - a1.height)


    '            ar1.StrtPt.x = Me.StrtPt.x

    '            ar1.StrtPt.y = Me.StrtPt.y

    '            ar1.StrtPt.z = Me.StrtPt.z + (a1.height)


    '            If ar1.isvalid Then

    '                ar.Enqueue(ar1)

    '            End If

    '        End If

    '        Return ar

    '    Catch Er As Exception

    '        MsgBox(Er.Message)

    '        MessageBox.Show("Error in subtract", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)

    '        Return Nothing

    '        conn.Close()

    '        off.Close()

    '    End Try

    'End Function

#Region " Routine definitions "

    Public Sub AutoDrawBxDr(ByVal fn As String, ByVal col As String, ByVal transpx As Single, ByVal tex As String, ByVal itmnm As String, ByVal wt As Single, ByVal qtyflg As Boolean, ByVal txtopt As Boolean, ByVal matname As String, ByVal method As Integer, ByVal dataopt As Boolean, ByVal shapeopt As String)

        'Stop

        Dim Dq As Char = Chr(34)

        Try

            off.WriteLine("Transform {")
            FileClose(1)

            Dim Bdo As New Rotation

            Dim BdoStrtPtx As Double = 0
            Dim BdoStrtPty As Double = 0
            Dim BdoStrtPtz As Double = 0
            Dim BdoAngle As Double = 0

            Rotan(fn, New String() {CStr(BdoStrtPtx), CStr(BdoStrtPty), CStr(BdoStrtPtz)}, BdoAngle)

            trans(fn, New String() {CStr(Me.StrtPt.x), CStr(Me.StrtPt.y), CStr(Me.StrtPt.z)})
            off.WriteLine("children [")
            off.WriteLine("Transform {")
            FileClose(1)

            trans(fn, New String() {CStr(Me.length / 2), CStr(Me.width / 2), CStr(Me.height / 2)})

            off.WriteLine("children [")
            FileClose(1)

            If shapeopt = "b" Then
                SetPolygon(fn, New String() {CStr(Me.length), CStr(Me.width), CStr(Me.height)}, itmnm, wt, qtyflg)       'SetPolygon is method to create Box with x y z dimensions
            Else
                '---------------- 
            End If

            off.WriteLine("appearance Appearance {")
            If tex <> "" Then
                off.WriteLine("texture ImageTexture {")
                off.WriteLine("url " & Dq & tex & Dq)
                off.WriteLine("}")
            End If

            off.WriteLine("material Material {")
            FileClose(1)

            DifusColr(fn, transpx, col)    'Method transp is Diffuser color R G B and Transparancy

            Dim Grd As String = Nothing

            Transprncy(fn, Grd, col)    'Visiblity or transparancy is managed

            off.WriteLine("}")
            off.WriteLine("}")

            FileClose(1)

            '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

            '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

            'fileopen(1, fn, OpenMode.Append)

            off.WriteLine("]")
            off.WriteLine("}")
            off.WriteLine("]")
            off.WriteLine("}")
            off.WriteLine("")
            FileClose(1)

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in AutoDrawBxDrOpn" & vbCrLf & "VRML Programme writting is failure!", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            FileClose(1)
            conn.Close()
            off.Close()
            'Form8.Close()

            Application.Exit()
        Finally
            FileClose()
        End Try

        Try
            If dataopt Then
                Dim cmd As New OleDb.OleDbCommand
                cmd.Connection = conn
                cmd.CommandText = "insert into stuffdata values('" & matname & "'," & CStr(Me.StrtPt.x) & "," & CStr(Me.StrtPt.y) & "," & CStr(Me.StrtPt.z) & "," & CStr(Me.length) & "," & CStr(Me.width) & "," & CStr(Me.height) & "," & CStr(method) & ",'" & col & "','" & tex & "',0)"
                cmd.ExecuteNonQuery()
                'conn.Close()  'Do not Close Connection Here 

            End If

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in AutoDrawBxDrOpn" & vbCrLf & "Data insert connection failure!", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            conn.Close()
            off.Close()
        End Try

    End Sub

    Public Sub AutoDrawBxDrOpn1(ByVal fn As String, ByVal col As String, ByVal transpx As Single, ByVal tex As String, ByVal itmnm As String, ByVal wt As Single, ByVal qtyflg As Boolean, ByVal txtopt As Boolean, ByVal matname As String, ByVal method As Integer, ByVal dataopt As Boolean, ByVal shapeopt As String)

        'Stop

        Dim X As Double = Me.StrtPt.x
        Dim Y As Double = Me.StrtPt.y
        Dim Z As Double = Me.StrtPt.z

        Dim L As Double = Me.length
        Dim W As Double = Me.width
        Dim H As Double = Me.height

        Dim Dbx As New DBxCntDor()

        Dim dq As Char = Chr(34)

        Try

            off.WriteLine("Transform {")        ' off.WriteLine  => fileopen(1, fn, OpenMode.Append)
            FileClose(1)

            Dim BdoPtx As Double = 0
            Dim BdoPty As Double = 0
            Dim BdoPtz As Double = 0
            Dim BdoAngle As Double = 0

            If DbxFlgO Then

                BdoPtz = 1
                Dbx.AngRad = OpnDeg
                BdoAngle = Dbx.AngRadCalc()

                Rotan(fn, New String() {CStr(BdoPtx), CStr(BdoPty), CStr(BdoPtz)}, BdoAngle)

            End If

            trans(fn, New String() {CStr(Me.StrtPt.x), CStr(Me.StrtPt.y), CStr(Me.StrtPt.z)})
            off.WriteLine("children [")
            off.WriteLine("Transform {")
            FileClose(1)

            If shapeopt = "b" Then     ' Shape of output is Box
                trans(fn, New String() {CStr(Me.length / 2), CStr(Me.width / 2), CStr(Me.height / 2)})
            Else
                trans(fn, New String() {CStr(Me.length), CStr(Me.length), CStr(Me.height / 2)})
            End If

            off.WriteLine("children [")
            FileClose(1)

            If shapeopt = "b" Then
                SetPolygon(fn, New String() {CStr(Me.length), CStr(Me.width), CStr(Me.height)}, itmnm, wt, qtyflg)       'SetPolygon is method to create Box with x y z dimensions
            Else
                '---------------- 
            End If

            off.WriteLine("appearance Appearance {")
            If tex <> "" Then
                off.WriteLine("texture ImageTexture {")
                off.WriteLine("url " & dq & tex & dq)
                off.WriteLine("}")
            End If

            off.WriteLine("material Material {")
            FileClose(1)

            'transp(fn, transpx, col)    'Method transp is Diffuser color R G B and Transparancy

            DifusColr(fn, transpx, col)    'Method transp is Diffuser color R G B and Transparancy

            'Stop

            If DbxFlgO Then
                transpx = "0"
            End If

            Transprncy(fn, transpx, col)    'Visiblity or transparancy is managed

            off.WriteLine("}")
            off.WriteLine("}")

            FileClose(1)

            '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

            '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

            'fileopen(1, fn, OpenMode.Append)

            off.WriteLine("]")
            off.WriteLine("}")
            off.WriteLine("]")
            off.WriteLine("}")
            off.WriteLine("")
            FileClose(1)

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Fatal error in AutoDraw" & vbCrLf & "VRML Programme writting is failure!", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            FileClose(1)
            conn.Close()
            off.Close()
            'Form8.Close()
            'MsgBox("Exception :: In method 'AutoDraw'  " & vbCrLf & "Due to an error application exit!...")
            Application.Exit()
        Finally
            FileClose()
        End Try

        If dataopt Then
            Dim cmd As New OleDb.OleDbCommand
            cmd.Connection = conn
            cmd.CommandText = "insert into stuffdata values('" & matname & "'," & CStr(Me.StrtPt.x) & "," & CStr(Me.StrtPt.y) & "," & CStr(Me.StrtPt.z) & "," & CStr(Me.length) & "," & CStr(Me.width) & "," & CStr(Me.height) & "," & CStr(method) & ",'" & col & "','" & tex & "',0)"
            cmd.ExecuteNonQuery()
            'conn.Close()  'Do not Close Connection Here 

        End If

    End Sub

    Public Sub AutoDrawBxDrOpn2(ByVal fn As String, ByVal col As String, ByVal transpx As Single, ByVal tex As String, ByVal itmnm As String, ByVal wt As Single, ByVal qtyflg As Boolean, ByVal txtopt As Boolean, ByVal matname As String, ByVal method As Integer, ByVal dataopt As Boolean, ByVal shapeopt As String)
        'Stop
        Dim X As Double = Me.StrtPt.x
        Dim Y As Double = Me.StrtPt.y
        Dim Z As Double = Me.StrtPt.z

        Dim Ln As Double = Me.length
        Dim Wd As Double = Me.width
        Dim Ht As Double = Me.height

        Dim Dbx As New DBxCntDor()

        Dim dq As Char = Chr(34)

        Try
            off.WriteLine("Transform {")        ' off.WriteLine  => fileopen(1, fn, OpenMode.Append)
            FileClose(1)

            'Dim BdoPtx As Double = 0
            'Dim BdoPty As Double = 0
            'Dim BdoPtz As Double = 0
            'Dim BdoAngle As Double = 0
            'If DbxFlgO Then
            '    BdoPtz = 1
            '    Dbx.AngRad = 360 - OpnDeg
            '    BdoAngle = Dbx.AngRadCalc()
            '    Stop
            '    off.Close()
            '    Rotan(fn, New String() {CStr(BdoPtx), CStr(BdoPty), CStr(BdoPtz)}, BdoAngle)
            'End If

            trans(fn, New String() {CStr(Me.StrtPt.x), CStr(Me.StrtPt.y), CStr(Me.StrtPt.z)})
            off.WriteLine("children [")
            off.WriteLine("Transform {")
            FileClose(1)

            'Stop

            '!!!!!

            Dim BdoPtx As Double = 0
            Dim BdoPty As Double = 0
            Dim BdoPtz As Double = 0
            Dim BdoAngle As Double = 0

            If DbxFlgO Then
                'Stop
                BdoPtz = 1
                Dbx.AngRad = 360 - OpnDeg
                BdoAngle = Dbx.AngRadCalc()
                'Stop
                'off.Close()
                Rotan(fn, New String() {CStr(BdoPtx), CStr(BdoPty), CStr(BdoPtz)}, BdoAngle)
            End If

            '!!!!!

            Dim Drw As Double = Me.width * 0.5

            Dim Ldy As Double = Math.Cos(BdoAngle) * Drw

            Drw = (Drw * 4)
            Ldy = Drw - Ldy

            Drw = Me.width * 0.5

            Dim Ldx As Double = Math.Sin(BdoAngle) * Drw

            Ldx = Math.Round(Ldx, 2)
            Ldy = Math.Round(Ldy, 2)

            'Stop

            If shapeopt = "b" Then     ' Shape of output is Box

                trans(fn, New String() {CStr(Ldx), CStr(Ldy), CStr(Me.height * 0.5)})
                'trans(fn, New String() {CStr(Me.length / 2), CStr(Me.width / 2), CStr(Me.height / 2)})
            Else
                trans(fn, New String() {CStr(Me.length), CStr(Me.length), CStr(Me.height / 2)})
            End If

            off.WriteLine("children [")
            FileClose(1)

            If shapeopt = "b" Then
                SetPolygon(fn, New String() {CStr(Me.length), CStr(Me.width), CStr(Me.height)}, itmnm, wt, qtyflg)       'SetPolygon is method to create Box with x y z dimensions
            Else
                '---------------- 
            End If

            off.WriteLine("appearance Appearance {")
            If tex <> "" Then
                off.WriteLine("texture ImageTexture {")
                off.WriteLine("url " & dq & tex & dq)
                off.WriteLine("}")
            End If

            off.WriteLine("material Material {")
            FileClose(1)

            'transp(fn, transpx, col)    'Method transp is Diffuser color R G B and Transparancy

            DifusColr(fn, transpx, col)    'Method transp is Diffuser color R G B and Transparancy

            'Stop

            If DbxFlgO Then
                transpx = "0"
            End If

            Transprncy(fn, transpx, col)    'Visiblity or transparancy is managed

            off.WriteLine("}")
            off.WriteLine("}")

            FileClose(1)

            '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

            '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

            'fileopen(1, fn, OpenMode.Append)

            off.WriteLine("]")
            off.WriteLine("}")
            off.WriteLine("]")
            off.WriteLine("}")
            off.WriteLine("")
            FileClose(1)

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Fatal error in AutoDraw" & vbCrLf & "VRML Programme writting is failure!", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            FileClose(1)
            conn.Close()
            off.Close()
            'Form8.Close()
            'MsgBox("Exception :: In method 'AutoDraw'  " & vbCrLf & "Due to an error application exit!...")
            Application.Exit()
        Finally
            FileClose()
        End Try

        If dataopt Then
            Dim cmd As New OleDb.OleDbCommand
            cmd.Connection = conn
            cmd.CommandText = "insert into stuffdata values('" & matname & "'," & CStr(Me.StrtPt.x) & "," & CStr(Me.StrtPt.y) & "," & CStr(Me.StrtPt.z) & "," & CStr(Me.length) & "," & CStr(Me.width) & "," & CStr(Me.height) & "," & CStr(method) & ",'" & col & "','" & tex & "',0)"
            cmd.ExecuteNonQuery()
            'conn.Close()  'Do not Close Connection Here 

        End If

    End Sub

    Public Sub AutoDrawsBxDrOpn1(ByVal fn As String, ByVal col As String, ByVal transpx As Single, ByVal tex As String, ByVal itmnm As String, ByVal wt As Single, ByVal qtyflg As Boolean, ByVal txtopt As Boolean, ByVal matname As String, ByVal method As Integer, ByVal dataopt As Boolean, ByVal shapeopt As String)

        'Stop

        Dim X As Double = Me.StrtPt.x
        Dim Y As Double = Me.StrtPt.y
        Dim Z As Double = Me.StrtPt.z

        Dim Dbx As New DBxCntDor()

        Dim dq As Char = Chr(34)

        Try

            Iow.WriteLine("Transform {")        ' off.WriteLine  => fileopen(1, fn, OpenMode.Append)
            FileClose(1)

            Dim BdoPtx As Double = 0
            Dim BdoPty As Double = 0
            Dim BdoPtz As Double = 0
            Dim BdoAngle As Double = 0

            If DbxFlgO Then

                BdoPtz = 1
                Dbx.AngRad = OpnDeg
                BdoAngle = Dbx.AngRadCalc()

                Rotans(fn, New String() {CStr(BdoPtx), CStr(BdoPty), CStr(BdoPtz)}, BdoAngle)

            End If

            AutoTransln(fn, New String() {CStr(Me.StrtPt.x), CStr(Me.StrtPt.y), CStr(Me.StrtPt.z)})
            Iow.WriteLine("children [")
            Iow.WriteLine("Transform {")
            FileClose(1)

            If shapeopt = "b" Then     ' Shape of output is Box
                AutoTransln(fn, New String() {CStr(Me.length / 2), CStr(Me.width / 2), CStr(Me.height / 2)})
            Else
                AutoTransln(fn, New String() {CStr(Me.length), CStr(Me.length), CStr(Me.height / 2)})
            End If

            Iow.WriteLine("children [")
            FileClose(1)

            If shapeopt = "b" Then
                SetPolygonBox(fn, New String() {CStr(Me.length), CStr(Me.width), CStr(Me.height)}, itmnm, wt, qtyflg)       'SetPolygon is method to create Box with x y z dimensions
            Else
                '---------------- 
            End If

            Iow.WriteLine("appearance Appearance {")
            If tex <> "" Then
                Iow.WriteLine("texture ImageTexture {")
                Iow.WriteLine("url " & dq & tex & dq)
                Iow.WriteLine("}")
            End If

            Iow.WriteLine("material Material {")
            FileClose(1)

            'transp(fn, transpx, col)    'Method transp is Diffuser color R G B and Transparancy

            DifusColr(fn, transpx, col)    'Method transp is Diffuser color R G B and Transparancy

            'Stop

            If DbxFlgO Then
                transpx = "0"
            End If

            Transprncy(fn, transpx, col)    'Visiblity or transparancy is managed

            Iow.WriteLine("}")
            Iow.WriteLine("}")

            FileClose(1)

            '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

            '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

            'fileopen(1, fn, OpenMode.Append)

            Iow.WriteLine("]")
            Iow.WriteLine("}")
            Iow.WriteLine("]")
            Iow.WriteLine("}")
            Iow.WriteLine("")
            FileClose(1)

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Fatal error in AutoDraw" & vbCrLf & "VRML Programme writting is failure!", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            FileClose(1)
            conn.Close()
            off.Close()
            'Form8.Close()
            'MsgBox("Exception :: In method 'AutoDraw'  " & vbCrLf & "Due to an error application exit!...")
            Application.Exit()
        Finally
            FileClose()
        End Try

        If dataopt Then
            Dim cmd As New OleDb.OleDbCommand
            cmd.Connection = conn
            cmd.CommandText = "insert into stuffdata values('" & matname & "'," & CStr(Me.StrtPt.x) & "," & CStr(Me.StrtPt.y) & "," & CStr(Me.StrtPt.z) & "," & CStr(Me.length) & "," & CStr(Me.width) & "," & CStr(Me.height) & "," & CStr(method) & ",'" & col & "','" & tex & "',0)"
            cmd.ExecuteNonQuery()
            'conn.Close()  'Do not Close Connection Here 

        End If

    End Sub

    Public Sub AutoDrawsBxDrOpn2(ByVal fn As String, ByVal col As String, ByVal transpx As Single, ByVal tex As String, ByVal itmnm As String, ByVal wt As Single, ByVal qtyflg As Boolean, ByVal txtopt As Boolean, ByVal matname As String, ByVal method As Integer, ByVal dataopt As Boolean, ByVal shapeopt As String)
        'Stop
        Dim X As Double = Me.StrtPt.x
        Dim Y As Double = Me.StrtPt.y
        Dim Z As Double = Me.StrtPt.z

        Dim Dbx As New DBxCntDor()

        Dim dq As Char = Chr(34)

        Try
            Iow.WriteLine("Transform {")        ' off.WriteLine  => fileopen(1, fn, OpenMode.Append)
            FileClose(1)
            AutoTransln(fn, New String() {CStr(Me.StrtPt.x), CStr(Me.StrtPt.y), CStr(Me.StrtPt.z)})
            Iow.WriteLine("children [")
            Iow.WriteLine("Transform {")
            FileClose(1)

            'Stop
            '!!!!!
            Dim BdoPtx As Double = 0
            Dim BdoPty As Double = 0
            Dim BdoPtz As Double = 0
            Dim BdoAngle As Double = 0

            If DbxFlgO Then
                BdoPtz = 1
                Dbx.AngRad = 360 - OpnDeg
                BdoAngle = Dbx.AngRadCalc()

                Rotans(fn, New String() {CStr(BdoPtx), CStr(BdoPty), CStr(BdoPtz)}, BdoAngle)
            End If

            Dim Drw As Double = Me.width * 0.5

            Dim Ldy As Double = Math.Cos(BdoAngle) * Drw

            Drw = (Drw * 4)
            Ldy = Drw - Ldy

            Drw = Me.width * 0.5

            Dim Ldx As Double = Math.Sin(BdoAngle) * Drw

            Ldx = Math.Round(Ldx, 2)
            Ldy = Math.Round(Ldy, 2)

            If shapeopt = "b" Then     ' Shape of output is Box

                AutoTransln(fn, New String() {CStr(Ldx), CStr(Ldy), CStr(Me.height * 0.5)})
            Else
                AutoTransln(fn, New String() {CStr(Me.length), CStr(Me.length), CStr(Me.height / 2)})
            End If

            Iow.WriteLine("children [")
            FileClose(1)

            If shapeopt = "b" Then
                SetPolygonBox(fn, New String() {CStr(Me.length), CStr(Me.width), CStr(Me.height)}, itmnm, wt, qtyflg)       'SetPolygon is method to create Box with x y z dimensions
            Else
                '---------------- 
            End If

            Iow.WriteLine("appearance Appearance {")
            If tex <> "" Then
                Iow.WriteLine("texture ImageTexture {")
                Iow.WriteLine("url " & dq & tex & dq)
                Iow.WriteLine("}")
            End If

            Iow.WriteLine("material Material {")
            FileClose(1)

            DifusColr(fn, transpx, col)    'Method transp is Diffuser color R G B and Transparancy

            If DbxFlgO Then
                transpx = "0"
            End If

            Transprncy(fn, transpx, col)    'Visiblity or transparancy is managed

            Iow.WriteLine("}")
            Iow.WriteLine("}")

            FileClose(1)

            Iow.WriteLine("]")
            Iow.WriteLine("}")
            Iow.WriteLine("]")
            Iow.WriteLine("}")
            Iow.WriteLine("")
            FileClose(1)

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Fatal error in AutoDraw" & vbCrLf & "VRML Programme writting is failure!", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            FileClose(1)
            conn.Close()
            off.Close()
            Application.Exit()
        Finally
            FileClose()
        End Try

        If dataopt Then
            Dim cmd As New OleDb.OleDbCommand
            cmd.Connection = conn
            cmd.CommandText = "insert into stuffdata values('" & matname & "'," & CStr(Me.StrtPt.x) & "," & CStr(Me.StrtPt.y) & "," & CStr(Me.StrtPt.z) & "," & CStr(Me.length) & "," & CStr(Me.width) & "," & CStr(Me.height) & "," & CStr(method) & ",'" & col & "','" & tex & "',0)"
            cmd.ExecuteNonQuery()
            'conn.Close()  'Do not Close Connection Here 

        End If

    End Sub

    Public Sub IncSrNumPrnt(ByVal SrnPrnt As String, ByVal IncSrOpt As Boolean, ByVal Method As Integer, ByVal ItmNm As String)

        Try

            Dim dq As Char = Chr(34)

            If IncSrOpt Then
                'fileopen(1, fn, OpenMode.Append)

                'attention

                Dim txtcol As String = "diffuseColor 1 1 1"

                Dim sz As Double

                off.WriteLine("Transform {")
                off.WriteLine("translation 0 " & CStr(Me.width * 1.05 * 0.5) & " 0")           'off.WriteLine("translation 0 " & CStr(Me.width * 1.05 / 2) & " 0")
                off.WriteLine("children [")
                off.WriteLine("Transform {")
                off.WriteLine("rotation 0 1 0 -3.14")
                off.WriteLine("children")
                off.WriteLine("Transform {")
                off.WriteLine("rotation 1 0 0 -1.57")
                off.WriteLine("children")
                off.WriteLine("Shape {")
                off.WriteLine("geometry Text {")

                If Method = 1 Or Method = 5 Then
                    ItmNm = SrnPrnt
                End If
                If Method = 2 Then
                    ItmNm = SrnPrnt
                End If
                If Method = 3 Then
                    ItmNm = SrnPrnt
                End If
                If Method = 4 Then
                    ItmNm = SrnPrnt
                End If
                If Method = 6 Then
                    ItmNm = SrnPrnt
                End If

                off.WriteLine("string " & dq & ItmNm & dq)
                off.WriteLine("maxExtent " & Me.length)
                off.WriteLine("fontStyle FontStyle {")
                sz = Me.width * 3
                off.WriteLine("size " & CStr(sz))
                off.WriteLine("justify [" & dq & "MIDDLE" & dq & "," & dq & "MIDDLE" & dq & "]")

                off.WriteLine("}")
                off.WriteLine("}")
                off.WriteLine("appearance Appearance {")
                off.WriteLine("material Material {")
                off.WriteLine(txtcol)
                off.WriteLine("transparency 0")
                off.WriteLine("}")
                off.WriteLine("}")
                off.WriteLine("}")
                off.WriteLine("}")
                off.WriteLine("}")
                off.WriteLine("]")
                off.WriteLine("}")

                off.WriteLine("Transform {")
                off.WriteLine("translation 0 -" & CStr(Me.width * 1.05 * 0.5) & " 0")           'off.WriteLine("translation 0 -" & CStr(Me.width * 1.05 / 2) & " 0")
                off.WriteLine("children [")
                off.WriteLine("Transform {")
                off.WriteLine("rotation 1 0 0 1.57")
                off.WriteLine("children")
                off.WriteLine("Shape {")
                off.WriteLine("geometry Text {")

                If Method = 1 Or Method = 5 Then
                    ItmNm = SrnPrnt
                End If
                If Method = 2 Then
                    ItmNm = SrnPrnt
                End If
                If Method = 3 Then
                    ItmNm = SrnPrnt
                End If
                If Method = 4 Then
                    ItmNm = SrnPrnt
                End If
                If Method = 6 Then
                    ItmNm = SrnPrnt
                End If

                off.WriteLine("string " & dq & ItmNm & dq)
                off.WriteLine("maxExtent " & Me.length)
                off.WriteLine("fontStyle FontStyle {")
                sz = Me.width * 3
                off.WriteLine("size " & CStr(sz))
                off.WriteLine("justify [" & dq & "MIDDLE" & dq & "," & dq & "MIDDLE" & dq & "]")
                off.WriteLine("}")
                off.WriteLine("}")
                off.WriteLine("appearance Appearance {")
                off.WriteLine("material Material {")
                off.WriteLine(txtcol)
                off.WriteLine("transparency 0")
                off.WriteLine("}")
                off.WriteLine("}")
                off.WriteLine("}")
                off.WriteLine("}")
                off.WriteLine("]")
                off.WriteLine("}")

                off.WriteLine("Transform {")
                off.WriteLine("translation " & CStr(Me.length * 1.05 * 0.5) & " 0 0")            'off.WriteLine("translation " & CStr(Me.length * 1.05 / 2) & " 0 0")
                off.WriteLine("children [")
                off.WriteLine("Transform {")
                off.WriteLine("rotation 1 0 0 1.57")
                off.WriteLine("children")
                off.WriteLine("Transform {")
                off.WriteLine("rotation 0 1 0 1.57")
                off.WriteLine("children")
                off.WriteLine("Shape {")
                off.WriteLine("geometry Text {")

                If Method = 1 Or Method = 2 Then
                    ItmNm = SrnPrnt
                End If
                If Method = 3 Then
                    ItmNm = SrnPrnt
                End If
                If Method = 4 Then
                    ItmNm = SrnPrnt
                End If
                If Method = 5 Then
                    ItmNm = SrnPrnt
                End If
                If Method = 6 Then
                    ItmNm = SrnPrnt
                End If

                off.WriteLine("string " & dq & ItmNm & dq)
                off.WriteLine("maxExtent " & Me.width)
                off.WriteLine("fontStyle FontStyle {")
                sz = Me.length * 3
                off.WriteLine("size " & CStr(sz))
                off.WriteLine("justify [" & dq & "MIDDLE" & dq & "," & dq & "MIDDLE" & dq & "]")
                off.WriteLine("}")
                off.WriteLine("}")
                off.WriteLine("appearance Appearance {")
                off.WriteLine("material Material {")
                off.WriteLine(txtcol)
                off.WriteLine("transparency 0")
                off.WriteLine("}")
                off.WriteLine("}")
                off.WriteLine("}")
                off.WriteLine("}")
                off.WriteLine("}")
                off.WriteLine("]")
                off.WriteLine("}")

                off.WriteLine("Transform {")
                off.WriteLine("translation -" & CStr(Me.length * 1.05 * 0.5) & " 0 0")             'off.WriteLine("translation -" & CStr(Me.length * 1.05 / 2) & " 0 0")
                off.WriteLine("children [")
                off.WriteLine("Transform {")
                off.WriteLine("rotation 1 0 0 1.57")
                off.WriteLine("children")
                off.WriteLine("Transform {")
                off.WriteLine("rotation 0 1 0 -1.57")
                off.WriteLine("children")
                off.WriteLine("Shape {")
                off.WriteLine("geometry Text {")

                If Method = 1 Or Method = 2 Then
                    ItmNm = SrnPrnt
                End If
                If Method = 3 Then
                    ItmNm = SrnPrnt
                End If
                If Method = 4 Then
                    ItmNm = SrnPrnt
                End If
                If Method = 5 Then
                    ItmNm = SrnPrnt
                End If
                If Method = 6 Then
                    ItmNm = SrnPrnt
                End If

                off.WriteLine("string " & dq & ItmNm & dq)
                off.WriteLine("maxExtent " & Me.width)
                off.WriteLine("fontStyle FontStyle {")
                sz = Me.length * 3
                off.WriteLine("size " & CStr(sz))
                off.WriteLine("justify [" & dq & "MIDDLE" & dq & "," & dq & "MIDDLE" & dq & "]")
                off.WriteLine("}")
                off.WriteLine("}")
                off.WriteLine("appearance Appearance {")
                off.WriteLine("material Material {")
                off.WriteLine(txtcol)
                off.WriteLine("transparency 0")
                off.WriteLine("}")
                off.WriteLine("}")
                off.WriteLine("}")
                off.WriteLine("}")
                off.WriteLine("}")
                off.WriteLine("]")
                off.WriteLine("}")

                off.WriteLine("Transform {")
                off.WriteLine("translation 0 0 " & CStr(Me.height * 1.05 * 0.5))      'off.WriteLine("translation 0 0 " & CStr(Me.height * 1.05 / 2))
                off.WriteLine("children [")
                off.WriteLine("Transform {")
                off.WriteLine("rotation 0 0 1 1.57")
                off.WriteLine("children")
                off.WriteLine("Shape {")
                off.WriteLine("geometry Text {")

                If Method = 1 Or Method = 4 Then
                    ItmNm = SrnPrnt
                End If
                If Method = 2 Then
                    ItmNm = SrnPrnt
                End If
                If Method = 3 Then
                    ItmNm = SrnPrnt
                End If
                If Method = 5 Then
                    ItmNm = SrnPrnt
                End If
                If Method = 6 Then
                    ItmNm = SrnPrnt
                End If

                off.WriteLine("string " & dq & ItmNm & dq)
                off.WriteLine("maxExtent " & Me.width)
                off.WriteLine("fontStyle FontStyle {")
                sz = Me.height * 3
                off.WriteLine("size " & CStr(sz))
                off.WriteLine("justify [" & dq & "MIDDLE" & dq & "," & dq & "MIDDLE" & dq & "]")
                off.WriteLine("}")
                off.WriteLine("}")
                off.WriteLine("appearance Appearance {")
                off.WriteLine("material Material {")
                off.WriteLine(txtcol)
                off.WriteLine("transparency 0")
                off.WriteLine("}")
                off.WriteLine("}")
                off.WriteLine("}")
                off.WriteLine("}")
                off.WriteLine("]")
                off.WriteLine("}")

                off.WriteLine("Transform {")
                off.WriteLine("translation 0 0 -" & CStr(Me.height * 1.05 * 0.5))        'off.WriteLine("translation 0 0 -" & CStr(Me.height * 1.05 / 2))
                off.WriteLine("children [")
                off.WriteLine("Transform {")
                off.WriteLine("rotation 0 0 1 1.57")
                off.WriteLine("children")
                off.WriteLine("Shape {")
                off.WriteLine("geometry Text {")

                If Method = 1 Or Method = 4 Then
                    ItmNm = SrnPrnt
                End If
                If Method = 2 Then
                    ItmNm = SrnPrnt
                End If
                If Method = 3 Then
                    ItmNm = SrnPrnt
                End If
                If Method = 5 Then
                    ItmNm = SrnPrnt
                End If
                If Method = 6 Then
                    ItmNm = SrnPrnt
                End If

                off.WriteLine("string " & dq & ItmNm & dq)
                off.WriteLine("maxExtent " & Me.width)
                off.WriteLine("fontStyle FontStyle {")
                sz = Me.height * 3
                off.WriteLine("size " & CStr(sz))
                off.WriteLine("justify [" & dq & "MIDDLE" & dq & "," & dq & "MIDDLE" & dq & "]")
                off.WriteLine("}")
                off.WriteLine("}")
                off.WriteLine("appearance Appearance {")
                off.WriteLine("material Material {")
                off.WriteLine(txtcol)
                off.WriteLine("transparency 0")
                off.WriteLine("}")
                off.WriteLine("}")
                off.WriteLine("}")
                off.WriteLine("}")
                off.WriteLine("]")
                off.WriteLine("}")

                FileClose(1)
            End If

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in IncSrNumPrnt", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub LBLMethodPrnt(ByVal TxtOpt As Boolean, ByVal Method As Integer, ByVal Itmnm As String)

        'Stop

        'TxtOpt = True

        Try

            Dim dq As Char = Chr(34)

            If TxtOpt Then
                'fileopen(1, fn, OpenMode.Append)

                'attention

                Dim txtcol As String = "diffuseColor 1 1 1"

                Dim sz As Double

                off.WriteLine("Transform {")
                off.WriteLine("translation 0 " & CStr(Me.width * 1.05 * 0.5) & " 0")           'off.WriteLine("translation 0 " & CStr(Me.width * 1.05 / 2) & " 0")
                off.WriteLine("children [")
                off.WriteLine("Transform {")
                off.WriteLine("rotation 0 1 0 -3.14")
                off.WriteLine("children")
                off.WriteLine("Transform {")
                off.WriteLine("rotation 1 0 0 -1.57")
                off.WriteLine("children")
                off.WriteLine("Shape {")
                off.WriteLine("geometry Text {")

                If Method = 1 Or Method = 5 Then
                    Itmnm = "R"
                End If
                If Method = 2 Then
                    Itmnm = "T"
                End If
                If Method = 3 Then
                    Itmnm = "T"
                End If
                If Method = 4 Then
                    Itmnm = "BK"
                End If
                If Method = 6 Then
                    Itmnm = "BK"
                End If

                off.WriteLine("string " & dq & Itmnm & dq)
                off.WriteLine("maxExtent " & Me.length)
                off.WriteLine("fontStyle FontStyle {")
                sz = Me.width * 3
                off.WriteLine("size " & CStr(sz))
                off.WriteLine("justify [" & dq & "MIDDLE" & dq & "," & dq & "MIDDLE" & dq & "]")

                off.WriteLine("}")
                off.WriteLine("}")
                off.WriteLine("appearance Appearance {")
                off.WriteLine("material Material {")
                off.WriteLine(txtcol)
                off.WriteLine("transparency 0")
                off.WriteLine("}")
                off.WriteLine("}")
                off.WriteLine("}")
                off.WriteLine("}")
                off.WriteLine("}")
                off.WriteLine("]")
                off.WriteLine("}")

                off.WriteLine("Transform {")
                off.WriteLine("translation 0 -" & CStr(Me.width * 1.05 * 0.5) & " 0")           'off.WriteLine("translation 0 -" & CStr(Me.width * 1.05 / 2) & " 0")
                off.WriteLine("children [")
                off.WriteLine("Transform {")
                off.WriteLine("rotation 1 0 0 1.57")
                off.WriteLine("children")
                off.WriteLine("Shape {")
                off.WriteLine("geometry Text {")

                If Method = 1 Or Method = 5 Then
                    Itmnm = "L"
                End If
                If Method = 2 Then
                    Itmnm = "BT"
                End If
                If Method = 3 Then
                    Itmnm = "BT"
                End If
                If Method = 4 Then
                    Itmnm = "F"
                End If
                If Method = 6 Then
                    Itmnm = "F"
                End If

                off.WriteLine("string " & dq & Itmnm & dq)
                off.WriteLine("maxExtent " & Me.length)
                off.WriteLine("fontStyle FontStyle {")
                sz = Me.width * 3
                off.WriteLine("size " & CStr(sz))
                off.WriteLine("justify [" & dq & "MIDDLE" & dq & "," & dq & "MIDDLE" & dq & "]")
                off.WriteLine("}")
                off.WriteLine("}")
                off.WriteLine("appearance Appearance {")
                off.WriteLine("material Material {")
                off.WriteLine(txtcol)
                off.WriteLine("transparency 0")
                off.WriteLine("}")
                off.WriteLine("}")
                off.WriteLine("}")
                off.WriteLine("}")
                off.WriteLine("]")
                off.WriteLine("}")

                off.WriteLine("Transform {")
                off.WriteLine("translation " & CStr(Me.length * 1.05 * 0.5) & " 0 0")            'off.WriteLine("translation " & CStr(Me.length * 1.05 / 2) & " 0 0")
                off.WriteLine("children [")
                off.WriteLine("Transform {")
                off.WriteLine("rotation 1 0 0 1.57")
                off.WriteLine("children")
                off.WriteLine("Transform {")
                off.WriteLine("rotation 0 1 0 1.57")
                off.WriteLine("children")
                off.WriteLine("Shape {")
                off.WriteLine("geometry Text {")

                If Method = 1 Or Method = 2 Then
                    Itmnm = "F"
                End If
                If Method = 3 Then
                    Itmnm = "R"
                End If
                If Method = 4 Then
                    Itmnm = "R"
                End If
                If Method = 5 Then
                    Itmnm = "T"
                End If
                If Method = 6 Then
                    Itmnm = "T"
                End If

                off.WriteLine("string " & dq & Itmnm & dq)
                off.WriteLine("maxExtent " & Me.width)
                off.WriteLine("fontStyle FontStyle {")
                sz = Me.length * 3
                off.WriteLine("size " & CStr(sz))
                off.WriteLine("justify [" & dq & "MIDDLE" & dq & "," & dq & "MIDDLE" & dq & "]")
                off.WriteLine("}")
                off.WriteLine("}")
                off.WriteLine("appearance Appearance {")
                off.WriteLine("material Material {")
                off.WriteLine(txtcol)
                off.WriteLine("transparency 0")
                off.WriteLine("}")
                off.WriteLine("}")
                off.WriteLine("}")
                off.WriteLine("}")
                off.WriteLine("}")
                off.WriteLine("]")
                off.WriteLine("}")

                off.WriteLine("Transform {")
                off.WriteLine("translation -" & CStr(Me.length * 1.05 * 0.5) & " 0 0")             'off.WriteLine("translation -" & CStr(Me.length * 1.05 / 2) & " 0 0")
                off.WriteLine("children [")
                off.WriteLine("Transform {")
                off.WriteLine("rotation 1 0 0 1.57")
                off.WriteLine("children")
                off.WriteLine("Transform {")
                off.WriteLine("rotation 0 1 0 -1.57")
                off.WriteLine("children")
                off.WriteLine("Shape {")
                off.WriteLine("geometry Text {")

                If Method = 1 Or Method = 2 Then
                    Itmnm = "BK"
                End If
                If Method = 3 Then
                    Itmnm = "L"
                End If
                If Method = 4 Then
                    Itmnm = "L"
                End If
                If Method = 5 Then
                    Itmnm = "BT"
                End If
                If Method = 6 Then
                    Itmnm = "BT"
                End If

                off.WriteLine("string " & dq & Itmnm & dq)
                off.WriteLine("maxExtent " & Me.width)
                off.WriteLine("fontStyle FontStyle {")
                sz = Me.length * 3
                off.WriteLine("size " & CStr(sz))
                off.WriteLine("justify [" & dq & "MIDDLE" & dq & "," & dq & "MIDDLE" & dq & "]")
                off.WriteLine("}")
                off.WriteLine("}")
                off.WriteLine("appearance Appearance {")
                off.WriteLine("material Material {")
                off.WriteLine(txtcol)
                off.WriteLine("transparency 0")
                off.WriteLine("}")
                off.WriteLine("}")
                off.WriteLine("}")
                off.WriteLine("}")
                off.WriteLine("}")
                off.WriteLine("]")
                off.WriteLine("}")

                off.WriteLine("Transform {")
                off.WriteLine("translation 0 0 " & CStr(Me.height * 1.05 * 0.5))      'off.WriteLine("translation 0 0 " & CStr(Me.height * 1.05 / 2))
                off.WriteLine("children [")
                off.WriteLine("Transform {")
                off.WriteLine("rotation 0 0 1 1.57")
                off.WriteLine("children")
                off.WriteLine("Shape {")
                off.WriteLine("geometry Text {")

                If Method = 1 Or Method = 4 Then
                    Itmnm = "T"
                End If
                If Method = 2 Then
                    Itmnm = "L"
                End If
                If Method = 3 Then
                    Itmnm = "F"
                End If
                If Method = 5 Then
                    Itmnm = "BK"
                End If
                If Method = 6 Then
                    Itmnm = "F"
                End If

                off.WriteLine("string " & dq & Itmnm & dq)
                off.WriteLine("maxExtent " & Me.width)
                off.WriteLine("fontStyle FontStyle {")
                sz = Me.height * 3
                off.WriteLine("size " & CStr(sz))
                off.WriteLine("justify [" & dq & "MIDDLE" & dq & "," & dq & "MIDDLE" & dq & "]")
                off.WriteLine("}")
                off.WriteLine("}")
                off.WriteLine("appearance Appearance {")
                off.WriteLine("material Material {")
                off.WriteLine(txtcol)
                off.WriteLine("transparency 0")
                off.WriteLine("}")
                off.WriteLine("}")
                off.WriteLine("}")
                off.WriteLine("}")
                off.WriteLine("]")
                off.WriteLine("}")

                off.WriteLine("Transform {")
                off.WriteLine("translation 0 0 -" & CStr(Me.height * 1.05 * 0.5))        'off.WriteLine("translation 0 0 -" & CStr(Me.height * 1.05 / 2))
                off.WriteLine("children [")
                off.WriteLine("Transform {")
                off.WriteLine("rotation 0 0 1 1.57")
                off.WriteLine("children")
                off.WriteLine("Shape {")
                off.WriteLine("geometry Text {")

                If Method = 1 Or Method = 4 Then
                    Itmnm = "BT"
                End If
                If Method = 2 Then
                    Itmnm = "R"
                End If
                If Method = 3 Then
                    Itmnm = "BK"
                End If
                If Method = 5 Then
                    Itmnm = "F"
                End If
                If Method = 6 Then
                    Itmnm = "R"
                End If

                off.WriteLine("string " & dq & Itmnm & dq)
                off.WriteLine("maxExtent " & Me.width)
                off.WriteLine("fontStyle FontStyle {")
                sz = Me.height * 3
                off.WriteLine("size " & CStr(sz))
                off.WriteLine("justify [" & dq & "MIDDLE" & dq & "," & dq & "MIDDLE" & dq & "]")
                off.WriteLine("}")
                off.WriteLine("}")
                off.WriteLine("appearance Appearance {")
                off.WriteLine("material Material {")
                off.WriteLine(txtcol)
                off.WriteLine("transparency 0")
                off.WriteLine("}")
                off.WriteLine("}")
                off.WriteLine("}")
                off.WriteLine("}")
                off.WriteLine("]")
                off.WriteLine("}")

                FileClose(1)
            End If

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in LBLMethodPrnt", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub AutoDrawBoxes(ByVal FNm As String, ByVal Col As String, ByVal Transpx As Single, ByVal Tex As String, ByVal Itmnm As String, ByVal Wt As Single, ByVal QtyFlg As Boolean, ByVal TxtOpt As Boolean, ByVal MatName As String, ByVal Method As Integer, ByVal DataOpt As Boolean, ByVal ShapeOpt As String)

        'Stop

        Try

            Dim X As Double = Me.StrtPt.x
            Dim Y As Double = Me.StrtPt.y
            Dim Z As Double = Me.StrtPt.z

            If Bitemqty = BitemqtyUsr Then
                'Me.StrtPt.y = Me.StrtPt.y - 5
            End If

            'Stop

            Dim dq As Char = Chr(34)

            off.WriteLine("Transform {")
            FileClose(1)

            BxTrans(FNm, New String() {CStr(Me.StrtPt.x), CStr(Me.StrtPt.y), CStr(Me.StrtPt.z)})

            off.WriteLine("children [")
            off.WriteLine("Transform {")
            FileClose(1)

            If ShapeOpt = "b" Then     ' Shape of output is Box

                BxTrans(FNm, New String() {CStr(Me.length / 2), CStr(Me.width / 2), CStr(Me.height / 2)})

            Else

                BxTrans(FNm, New String() {CStr(Me.length), CStr(Me.length), CStr(Me.height / 2)})

            End If

            off.WriteLine("children [")
            FileClose(1)

            If ShapeOpt = "b" Then

                SetPolygonBox(FNm, New String() {CStr(Me.length), CStr(Me.width), CStr(Me.height)}, Itmnm, Wt, QtyFlg)       'SetPolygon is method to create Box with x y z dimensions

            Else

            End If

            off.WriteLine("appearance Appearance {")

            If Tex <> "" Then
                off.WriteLine("texture ImageTexture {")
                off.WriteLine("url " & dq & Tex & dq)
                off.WriteLine("}")
            End If

            off.WriteLine("material Material {")
            FileClose(1)

            DifusColr(FNm, Transpx, Col)    'Method transp is Diffuser color R G B and Transparancy

            'Stop

            If DbxFlgO Then
                Transpx = "0"
            End If

            Transprncy(FNm, Transpx, Col)    'Visiblity or transparancy is managed

            off.WriteLine("}")
            off.WriteLine("}")

            FileClose(1)

            '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

            Stop

            '=========================================

            If TransactionMenu.chkBxSlideStuff.Checked Then

                Dim InsrNm As String = Convert.ToString(BitemqtyInr)

                IncSrNumPrnt(InsrNm, TransactionMenu.chkBxSlideStuff.Checked, Method, Itmnm)

            End If

            '=========================================

            TxtOpt = False

            LBLMethodPrnt(TxtOpt, Method, Itmnm)       'Method name printing on the box is done here

            'If TxtOpt Then

            '    'fileopen(1, fn, OpenMode.Append)

            '    'attention

            '    Dim txtcol As String = "diffuseColor 1 1 1"

            '    Dim sz As Double

            '    off.WriteLine("Transform {")
            '    off.WriteLine("translation 0 " & CStr(Me.width * 1.05 / 2) & " 0")
            '    off.WriteLine("children [")
            '    off.WriteLine("Transform {")
            '    off.WriteLine("rotation 0 1 0 -3.14")
            '    off.WriteLine("children")
            '    off.WriteLine("Transform {")
            '    off.WriteLine("rotation 1 0 0 -1.57")
            '    off.WriteLine("children")
            '    off.WriteLine("Shape {")
            '    off.WriteLine("geometry Text {")

            '    If Method = 1 Or Method = 5 Then
            '        Itmnm = "R"
            '    End If
            '    If Method = 2 Then
            '        Itmnm = "T"
            '    End If
            '    If Method = 3 Then
            '        Itmnm = "T"
            '    End If
            '    If Method = 4 Then
            '        Itmnm = "BK"
            '    End If
            '    If Method = 6 Then
            '        Itmnm = "BK"
            '    End If

            '    off.WriteLine("string " & dq & Itmnm & dq)
            '    off.WriteLine("maxExtent " & Me.length)
            '    off.WriteLine("fontStyle FontStyle {")
            '    sz = Me.width * 3
            '    off.WriteLine("size " & CStr(sz))
            '    off.WriteLine("justify [" & dq & "MIDDLE" & dq & "," & dq & "MIDDLE" & dq & "]")

            '    off.WriteLine("}")
            '    off.WriteLine("}")
            '    off.WriteLine("appearance Appearance {")
            '    off.WriteLine("material Material {")
            '    off.WriteLine(txtcol)
            '    off.WriteLine("transparency 0")
            '    off.WriteLine("}")
            '    off.WriteLine("}")
            '    off.WriteLine("}")
            '    off.WriteLine("}")
            '    off.WriteLine("}")
            '    off.WriteLine("]")
            '    off.WriteLine("}")

            '    off.WriteLine("Transform {")
            '    off.WriteLine("translation 0 -" & CStr(Me.width * 1.05 / 2) & " 0")
            '    off.WriteLine("children [")
            '    off.WriteLine("Transform {")
            '    off.WriteLine("rotation 1 0 0 1.57")
            '    off.WriteLine("children")
            '    off.WriteLine("Shape {")
            '    off.WriteLine("geometry Text {")
            '    If Method = 1 Or Method = 5 Then
            '        Itmnm = "L"
            '    End If
            '    If Method = 2 Then
            '        Itmnm = "BT"
            '    End If
            '    If Method = 3 Then
            '        Itmnm = "BT"
            '    End If
            '    If Method = 4 Then
            '        Itmnm = "F"
            '    End If
            '    If Method = 6 Then
            '        Itmnm = "F"
            '    End If
            '    off.WriteLine("string " & dq & Itmnm & dq)
            '    off.WriteLine("maxExtent " & Me.length)
            '    off.WriteLine("fontStyle FontStyle {")
            '    sz = Me.width * 3
            '    off.WriteLine("size " & CStr(sz))
            '    off.WriteLine("justify [" & dq & "MIDDLE" & dq & "," & dq & "MIDDLE" & dq & "]")
            '    off.WriteLine("}")
            '    off.WriteLine("}")
            '    off.WriteLine("appearance Appearance {")
            '    off.WriteLine("material Material {")
            '    off.WriteLine(txtcol)
            '    off.WriteLine("transparency 0")
            '    off.WriteLine("}")
            '    off.WriteLine("}")
            '    off.WriteLine("}")
            '    off.WriteLine("}")
            '    off.WriteLine("]")
            '    off.WriteLine("}")

            '    off.WriteLine("Transform {")
            '    off.WriteLine("translation " & CStr(Me.length * 1.05 / 2) & " 0 0")
            '    off.WriteLine("children [")
            '    off.WriteLine("Transform {")
            '    off.WriteLine("rotation 1 0 0 1.57")
            '    off.WriteLine("children")
            '    off.WriteLine("Transform {")
            '    off.WriteLine("rotation 0 1 0 1.57")
            '    off.WriteLine("children")
            '    off.WriteLine("Shape {")
            '    off.WriteLine("geometry Text {")

            '    If Method = 1 Or Method = 2 Then
            '        Itmnm = "F"
            '    End If
            '    If Method = 3 Then
            '        Itmnm = "R"
            '    End If
            '    If Method = 4 Then
            '        Itmnm = "R"
            '    End If
            '    If Method = 5 Then
            '        Itmnm = "T"
            '    End If
            '    If Method = 6 Then
            '        Itmnm = "T"
            '    End If

            '    off.WriteLine("string " & dq & Itmnm & dq)
            '    off.WriteLine("maxExtent " & Me.width)
            '    off.WriteLine("fontStyle FontStyle {")
            '    sz = Me.length * 3
            '    off.WriteLine("size " & CStr(sz))
            '    off.WriteLine("justify [" & dq & "MIDDLE" & dq & "," & dq & "MIDDLE" & dq & "]")
            '    off.WriteLine("}")
            '    off.WriteLine("}")
            '    off.WriteLine("appearance Appearance {")
            '    off.WriteLine("material Material {")
            '    off.WriteLine(txtcol)
            '    off.WriteLine("transparency 0")
            '    off.WriteLine("}")
            '    off.WriteLine("}")
            '    off.WriteLine("}")
            '    off.WriteLine("}")
            '    off.WriteLine("}")
            '    off.WriteLine("]")
            '    off.WriteLine("}")

            '    off.WriteLine("Transform {")
            '    off.WriteLine("translation -" & CStr(Me.length * 1.05 / 2) & " 0 0")
            '    off.WriteLine("children [")
            '    off.WriteLine("Transform {")
            '    off.WriteLine("rotation 1 0 0 1.57")
            '    off.WriteLine("children")
            '    off.WriteLine("Transform {")
            '    off.WriteLine("rotation 0 1 0 -1.57")
            '    off.WriteLine("children")
            '    off.WriteLine("Shape {")
            '    off.WriteLine("geometry Text {")

            '    If Method = 1 Or Method = 2 Then
            '        Itmnm = "BK"
            '    End If
            '    If Method = 3 Then
            '        Itmnm = "L"
            '    End If
            '    If Method = 4 Then
            '        Itmnm = "L"
            '    End If
            '    If Method = 5 Then
            '        Itmnm = "BT"
            '    End If
            '    If Method = 6 Then
            '        Itmnm = "BT"
            '    End If

            '    off.WriteLine("string " & dq & Itmnm & dq)
            '    off.WriteLine("maxExtent " & Me.width)
            '    off.WriteLine("fontStyle FontStyle {")
            '    sz = Me.length * 3
            '    off.WriteLine("size " & CStr(sz))
            '    off.WriteLine("justify [" & dq & "MIDDLE" & dq & "," & dq & "MIDDLE" & dq & "]")
            '    off.WriteLine("}")
            '    off.WriteLine("}")
            '    off.WriteLine("appearance Appearance {")
            '    off.WriteLine("material Material {")
            '    off.WriteLine(txtcol)
            '    off.WriteLine("transparency 0")
            '    off.WriteLine("}")
            '    off.WriteLine("}")
            '    off.WriteLine("}")
            '    off.WriteLine("}")
            '    off.WriteLine("}")
            '    off.WriteLine("]")
            '    off.WriteLine("}")

            '    off.WriteLine("Transform {")
            '    off.WriteLine("translation 0 0 " & CStr(Me.height * 1.05 / 2))
            '    off.WriteLine("children [")
            '    off.WriteLine("Transform {")
            '    off.WriteLine("rotation 0 0 1 1.57")
            '    off.WriteLine("children")
            '    off.WriteLine("Shape {")
            '    off.WriteLine("geometry Text {")
            '    If Method = 1 Or Method = 4 Then
            '        Itmnm = "T"
            '    End If
            '    If Method = 2 Then
            '        Itmnm = "L"
            '    End If
            '    If Method = 3 Then
            '        Itmnm = "F"
            '    End If
            '    If Method = 5 Then
            '        Itmnm = "BK"
            '    End If
            '    If Method = 6 Then
            '        Itmnm = "F"
            '    End If

            '    off.WriteLine("string " & dq & Itmnm & dq)
            '    off.WriteLine("maxExtent " & Me.width)
            '    off.WriteLine("fontStyle FontStyle {")
            '    sz = Me.height * 3
            '    off.WriteLine("size " & CStr(sz))
            '    off.WriteLine("justify [" & dq & "MIDDLE" & dq & "," & dq & "MIDDLE" & dq & "]")
            '    off.WriteLine("}")
            '    off.WriteLine("}")
            '    off.WriteLine("appearance Appearance {")
            '    off.WriteLine("material Material {")
            '    off.WriteLine(txtcol)
            '    off.WriteLine("transparency 0")
            '    off.WriteLine("}")
            '    off.WriteLine("}")
            '    off.WriteLine("}")
            '    off.WriteLine("}")
            '    off.WriteLine("]")
            '    off.WriteLine("}")

            '    off.WriteLine("Transform {")
            '    off.WriteLine("translation 0 0 -" & CStr(Me.height * 1.05 / 2))
            '    off.WriteLine("children [")
            '    off.WriteLine("Transform {")
            '    off.WriteLine("rotation 0 0 1 1.57")
            '    off.WriteLine("children")
            '    off.WriteLine("Shape {")
            '    off.WriteLine("geometry Text {")

            '    If Method = 1 Or Method = 4 Then
            '        Itmnm = "BT"
            '    End If
            '    If Method = 2 Then
            '        Itmnm = "R"
            '    End If
            '    If Method = 3 Then
            '        Itmnm = "BK"
            '    End If
            '    If Method = 5 Then
            '        Itmnm = "F"
            '    End If
            '    If Method = 6 Then
            '        Itmnm = "R"
            '    End If

            '    off.WriteLine("string " & dq & Itmnm & dq)
            '    off.WriteLine("maxExtent " & Me.width)
            '    off.WriteLine("fontStyle FontStyle {")
            '    sz = Me.height * 3
            '    off.WriteLine("size " & CStr(sz))
            '    off.WriteLine("justify [" & dq & "MIDDLE" & dq & "," & dq & "MIDDLE" & dq & "]")
            '    off.WriteLine("}")
            '    off.WriteLine("}")
            '    off.WriteLine("appearance Appearance {")
            '    off.WriteLine("material Material {")
            '    off.WriteLine(txtcol)
            '    off.WriteLine("transparency 0")
            '    off.WriteLine("}")
            '    off.WriteLine("}")
            '    off.WriteLine("}")
            '    off.WriteLine("}")
            '    off.WriteLine("]")
            '    off.WriteLine("}")

            '    FileClose(1)
            'End If

            '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

            'fileopen(1, fn, OpenMode.Append)

            off.WriteLine("]")
            off.WriteLine("}")
            off.WriteLine("]")
            off.WriteLine("}")
            off.WriteLine("")
            FileClose(1)

            'Stop

            'off.Close()

            'Stop

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Fatal error in AutoDraw" & vbCrLf & "VRML Programme writting is failure!", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            FileClose(1)
            conn.Close()
            off.Close()
            'Form8.Close()
            'MsgBox("Exception :: In method 'AutoDraw'  " & vbCrLf & "Due to an error application exit!...")
            MessageBox.Show("Application exit!... ", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Application.Exit()
        Finally
            FileClose()
        End Try

        'Stop

        Try
            If DataOpt Then
                Dim cmd As New OleDb.OleDbCommand
                cmd.Connection = conn
                cmd.CommandText = "insert into stuffdata values('" & MatName & "'," & CStr(Me.StrtPt.x) & "," & CStr(Me.StrtPt.y) & "," & CStr(Me.StrtPt.z) & "," & CStr(Me.length) & "," & CStr(Me.width) & "," & CStr(Me.height) & "," & CStr(Method) & ",'" & Col & "','" & Tex & "',0)"
                cmd.ExecuteNonQuery()
                'conn.Close()  'Do not Close Connection Here 

                InsrtBxData(MatName, Me.StrtPt.x, Me.StrtPt.y, Me.StrtPt.z, Me.length, Me.width, Me.height, Method, Col, Tex, BitemqtyInr)

            End If
        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in AutoDraw" & vbCrLf & "Data insert connection failure!", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'MsgBox("Exception :: In Method 'AutoDraw'  " & vbCrLf & "Data insert connection failure!")
            conn.Close()
            off.Close()
        End Try

    End Sub

    Public Sub AutoDrawBox(ByVal FNm As String, ByVal Col As String, ByVal Transpx As Single, ByVal Tex As String, ByVal Itmnm As String, ByVal Wt As Single, ByVal QtyFlg As Boolean, ByVal TxtOpt As Boolean, ByVal MatName As String, ByVal Method As Integer, ByVal DataOpt As Boolean, ByVal ShapeOpt As String)

        'Stop

        Try

            Dim X As Double = Me.StrtPt.x
            Dim Y As Double = Me.StrtPt.y
            Dim Z As Double = Me.StrtPt.z
            Dim Length As Double = Me.length
            Dim Width As Double = Me.width
            Dim Height As Double = Me.height

            If Bitemqty = BitemqtyUsr Then
                'Me.StrtPt.y = Me.StrtPt.y - 5
            End If

            'Stop

            Dim dq As Char = Chr(34)

            off.WriteLine("Transform {")
            FileClose(1)

            BxTrans(FNm, New String() {CStr(Me.StrtPt.x), CStr(Me.StrtPt.y), CStr(Me.StrtPt.z)})

            off.WriteLine("children [")
            off.WriteLine("Transform {")
            FileClose(1)

            If ShapeOpt = "b" Then     'Shape of output is Box

                Dim Xb As Double = Me.length * 0.5
                Dim Yb As Double = Me.width * 0.5
                Dim Zb As Double = Me.height * 0.5

                'Stop
                '================================

                If PosChngFlg Then

                    If BitemqtyInr >= QtyPosPt0 AndAlso BitemqtyInr <= QtyPosPt1 Then
                        'Stop

                        Xb = Xb + XPosPt
                        Yb = Yb + YPosPt
                        Zb = Zb + ZPosPt

                    End If


                End If

                '================================

                'Me.length = Xb
                'Me.width = Yb
                'Me.height = Zb

                'BxTrans(FNm, New String() {CStr(Me.length), CStr(Me.width), CStr(Me.height)})

                BxTrans(FNm, New String() {CStr(Xb), CStr(Yb), CStr(Zb)})       'BxTrans(FNm, New String() {CStr(Me.length / 2), CStr(Me.width / 2), CStr(Me.height / 2)})

            Else

                BxTrans(FNm, New String() {CStr(Me.length), CStr(Me.length), CStr(Me.height * 0.5)})      'BxTrans(FNm, New String() {CStr(Me.length), CStr(Me.length), CStr(Me.height / 2)})

            End If

            off.WriteLine("children [")
            FileClose(1)

            If ShapeOpt = "b" Then

                SetPolygonBox(FNm, New String() {CStr(Me.length), CStr(Me.width), CStr(Me.height)}, Itmnm, Wt, QtyFlg)       'SetPolygon is method to create Box with x y z dimensions

            Else

            End If

            off.WriteLine("appearance Appearance {")

            If Tex <> "" Then
                off.WriteLine("texture ImageTexture {")
                off.WriteLine("url " & dq & Tex & dq)
                off.WriteLine("}")
            End If

            off.WriteLine("material Material {")
            FileClose(1)

            DifusColr(FNm, Transpx, Col)    'Method transp is Diffuser color R G B and Transparancy

            'Stop

            If DbxFlgO Then
                Transpx = "0"
            End If

            Transprncy(FNm, Transpx, Col)    'Visiblity or transparancy is managed

            off.WriteLine("}")
            off.WriteLine("}")

            FileClose(1)

            '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

            'Stop
            '=========================================

            If TransactionMenu.chkBxSlideStuff.Checked Then

                Dim InsrNm As String = Convert.ToString(BitemqtyInr)

                IncSrNumPrnt(InsrNm, TransactionMenu.chkBxSlideStuff.Checked, Method, Itmnm)        'Count Number of box is printing in this routine

            End If

            '=========================================

            'Stop

            TxtOpt = False

            LBLMethodPrnt(TxtOpt, Method, Itmnm)       'Method name printing on the box is done here

            '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

            'fileopen(1, fn, OpenMode.Append)

            off.WriteLine("]")
            off.WriteLine("}")
            off.WriteLine("]")
            off.WriteLine("}")
            off.WriteLine("")
            FileClose(1)

            'Stop

            'off.Close()

            'Stop

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Fatal error in AutoDraw" & vbCrLf & "VRML Programme writting is failure!", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            FileClose(1)
            conn.Close()
            off.Close()
            'Form8.Close()
            'MsgBox("Exception :: In method 'AutoDraw'  " & vbCrLf & "Due to an error application exit!...")
            MessageBox.Show("Application exit!... ", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Application.Exit()
        Finally
            FileClose()
        End Try

        'Stop

        Try
            If DataOpt Then
                Dim cmd As New OleDb.OleDbCommand
                cmd.Connection = conn
                cmd.CommandText = "insert into stuffdata values('" & MatName & "'," & CStr(Me.StrtPt.x) & "," & CStr(Me.StrtPt.y) & "," & CStr(Me.StrtPt.z) & "," & CStr(Me.length) & "," & CStr(Me.width) & "," & CStr(Me.height) & "," & CStr(Method) & ",'" & Col & "','" & Tex & "',0)"
                cmd.ExecuteNonQuery()
                'conn.Close()  'Do not Close Connection Here 

                InsrtBxData(MatName, Me.StrtPt.x, Me.StrtPt.y, Me.StrtPt.z, Me.length, Me.width, Me.height, Method, Col, Tex, BitemqtyInr)

            End If

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in AutoDraw" & vbCrLf & "Data insert connection failure!", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'MsgBox("Exception :: In Method 'AutoDraw'  " & vbCrLf & "Data insert connection failure!")
            conn.Close()
            off.Close()
        End Try

    End Sub

    Public Sub Known_Value()

        Dim X As Double = Me.StrtPt.x
        Dim Y As Double = Me.StrtPt.y
        Dim Z As Double = Me.StrtPt.z

        Dim Ln As Double = Me.length
        Dim Wd As Double = Me.width
        Dim Ht As Double = Me.height

    End Sub

    Public Sub WadAutoDraw(ByVal fN As String, ByVal Col As String, ByVal Transpx As Single, ByVal Tex As String, ByVal ItmNm As String, ByVal Wt As Single, ByVal QtyFlg As Boolean, ByVal TxtOpt As Boolean, ByVal MatName As String, ByVal Method As Integer, ByVal DataOpt As Boolean, ByVal ShapeOpt As String)

        Dim dq As Char = Chr(34)

        Try
            Dim xX As Double = Me.StrtPt.x
            Dim yY As Double = Me.StrtPt.y
            Dim zZ As Double = Me.StrtPt.z

            off.WriteLine("Transform {")

            TransWad(fN, New String() {CStr(Me.StrtPt.x), CStr(Me.StrtPt.y), CStr(Me.StrtPt.z)})

            off.WriteLine("children [")

            off.WriteLine("Transform {")
            FileClose(1)

            TransWad(fN, New String() {CStr(Me.length * 0.5), CStr(Me.width * 0.5), CStr(Me.height * 0.5)})

            off.WriteLine("children [")
            FileClose(1)

            SetPolygonWad(fN, New String() {CStr(Me.length), CStr(Me.width), CStr(Me.height)}, ItmNm, Wt, QtyFlg)

            off.WriteLine("appearance Appearance {")

            If Tex <> "" Then
                off.WriteLine("texture ImageTexture {")
                off.WriteLine("url " & dq & Tex & dq)
                off.WriteLine("}")
            End If

            off.WriteLine("material Material {")
            FileClose(1)

            DifusColrWad(fN, Transpx, Col)

            TransWad(fN, Transpx, Col)

            off.WriteLine("}")
            off.WriteLine("}")
            FileClose(1)

            off.WriteLine("]")
            off.WriteLine("}")
            off.WriteLine("]")
            off.WriteLine("}")
            off.WriteLine("")

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in WadAutoDraw", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Function VertexBox(ByVal MtlNm As String, ByVal Mthd As Integer, ByVal ItmNo As String) As Boolean                      'Public Sub VertexBox(ByVal MtlNm As String, ByVal Mthd As Integer)

        If BitemqtyInr = 251 Then
            'Stop
            'off.Close()
        End If

        Dim vI As New Vertex
        Dim vII As New Vertex
        Dim vIII As New Vertex
        Dim vIV As New Vertex
        Dim vV As New Vertex
        Dim vVI As New Vertex
        Dim vVII As New Vertex
        Dim vVIII As New Vertex

        Dim X As Double = Me.StrtPt.x
        Dim Y As Double = Me.StrtPt.y
        Dim Z As Double = Me.StrtPt.z

        Dim L As Double = Me.length
        Dim W As Double = Me.width
        Dim H As Double = Me.height

        Dim Inc As Boolean = False

        L = L + X
        W = W + Y
        H = H + Z

        If L > CL Or W > CW Or H > CH Then
            Inc = True
        Else
            Inc = False
        End If

        '###########################################

        'Dim Var As New Area

        'For k As Integer = 0 To stk.Count - 1

        '    Var = stk(stk.Count - 1)

        '    If Var.StrtPt.x = 34 AndAlso Var.StrtPt.y = 60 Then
        '        'Stop
        '        Exit For
        '        'off.Close()
        '    End If

        '    If BitemqtyInr = 46 Then

        '        'Stop

        '    End If

        '    Var = UnionItrX(Var)

        'Next
        '###########################################

        If Me.StrtPt.x = 0 AndAlso Me.StrtPt.y = 0 AndAlso Me.StrtPt.z = 0 Then
            'Stop

            vI.Vx = Me.StrtPt.x
            vI.Vy = Me.StrtPt.y
            vI.Vz = Me.StrtPt.z

            vII.Vx = Me.StrtPt.x
            vII.Vy = Me.StrtPt.y + Me.width
            vII.Vz = Me.StrtPt.z

            vIII.Vx = Me.StrtPt.x + Me.length
            vIII.Vy = Me.StrtPt.y + Me.width
            vIII.Vz = Me.StrtPt.z

            vIV.Vx = Me.StrtPt.x + Me.length
            vIV.Vy = Me.StrtPt.y
            vIV.Vz = Me.StrtPt.z

            vV.Vx = Me.StrtPt.x + Me.length
            vV.Vy = Me.StrtPt.y
            vV.Vz = Me.StrtPt.z + Me.height

            vVI.Vx = Me.StrtPt.x
            vVI.Vy = Me.StrtPt.y
            vVI.Vz = Me.StrtPt.z + Me.height

            vVII.Vx = Me.StrtPt.x
            vVII.Vy = Me.StrtPt.y + Me.width
            vVII.Vz = Me.StrtPt.z + Me.height

            vVIII.Vx = Me.StrtPt.x + Me.length
            vVIII.Vy = Me.StrtPt.y + Me.width
            vVIII.Vz = Me.StrtPt.z + Me.height

            'Stop

        End If

        If Me.StrtPt.x = 0 AndAlso Me.StrtPt.y = 0 AndAlso Me.StrtPt.z <> 0 Then

            '$$$$$
            'Stop
            '$$$$$

            vI.Vx = Me.StrtPt.x
            vI.Vy = Me.StrtPt.y
            vI.Vz = Me.StrtPt.z + Me.height

            vII.Vx = Me.StrtPt.x
            vII.Vy = Me.StrtPt.y + Me.width
            vII.Vz = Me.StrtPt.z + Me.height

            vIII.Vx = Me.StrtPt.x + Me.length
            vIII.Vy = Me.StrtPt.y + Me.width
            vIII.Vz = Me.StrtPt.z + Me.height

            vIV.Vx = Me.StrtPt.x + Me.length
            vIV.Vy = Me.StrtPt.y
            vIV.Vz = Me.StrtPt.z + Me.height

            vV.Vx = Me.StrtPt.x + Me.length
            vV.Vy = Me.StrtPt.y
            vV.Vz = Me.StrtPt.z + Me.height

            vVI.Vx = Me.StrtPt.x
            vVI.Vy = Me.StrtPt.y
            vVI.Vz = Me.StrtPt.z + Me.height

            vVII.Vx = Me.StrtPt.x
            vVII.Vy = Me.StrtPt.y + Me.width
            vVII.Vz = Me.StrtPt.z + Me.height

            vVIII.Vx = Me.StrtPt.x + Me.length
            vVIII.Vy = Me.StrtPt.y + Me.width
            vVIII.Vz = Me.StrtPt.z + Me.height

        End If

        If Me.StrtPt.x = 0 AndAlso Me.StrtPt.y <> 0 AndAlso Me.StrtPt.z = 0 Then

            '*****
            'Stop
            '*****

            vI.Vx = Me.StrtPt.x
            vI.Vy = Me.StrtPt.y
            vI.Vz = Me.StrtPt.z

            vII.Vx = Me.StrtPt.x
            vII.Vy = Me.StrtPt.y + Me.width
            vII.Vz = Me.StrtPt.z

            vIII.Vx = Me.StrtPt.x + Me.length
            vIII.Vy = Me.StrtPt.y + Me.width
            vIII.Vz = Me.StrtPt.z

            vIV.Vx = Me.StrtPt.x + Me.length
            vIV.Vy = Me.StrtPt.y
            vIV.Vz = Me.StrtPt.z

            vV.Vx = Me.StrtPt.x + Me.length
            vV.Vy = Me.StrtPt.y
            vV.Vz = Me.StrtPt.z + Me.height

            vVI.Vx = Me.StrtPt.x
            vVI.Vy = Me.StrtPt.y
            vVI.Vz = Me.StrtPt.z + Me.height

            vVII.Vx = Me.StrtPt.x
            vVII.Vy = Me.StrtPt.y + Me.width
            vVII.Vz = Me.StrtPt.z + Me.height

            vVIII.Vx = Me.StrtPt.x + Me.length
            vVIII.Vy = Me.StrtPt.y + Me.width
            vVIII.Vz = Me.StrtPt.z + Me.height

        End If

        If Me.StrtPt.x = 0 AndAlso Me.StrtPt.y <> 0 AndAlso Me.StrtPt.z <> 0 Then

            '*****
            'Stop
            '*****

            vI.Vx = Me.StrtPt.x
            vI.Vy = Me.StrtPt.y
            vI.Vz = Me.StrtPt.z

            vII.Vx = Me.StrtPt.x
            vII.Vy = Me.StrtPt.y + Me.width
            vII.Vz = Me.StrtPt.z

            vIII.Vx = Me.StrtPt.x + Me.length
            vIII.Vy = Me.StrtPt.y + Me.width
            vIII.Vz = Me.StrtPt.z

            vIV.Vx = Me.StrtPt.x + Me.length
            vIV.Vy = Me.StrtPt.y
            vIV.Vz = Me.StrtPt.z

            vV.Vx = Me.StrtPt.x + Me.length
            vV.Vy = Me.StrtPt.y
            vV.Vz = Me.StrtPt.z + Me.height

            vVI.Vx = Me.StrtPt.x
            vVI.Vy = Me.StrtPt.y
            vVI.Vz = Me.StrtPt.z + Me.height

            vVII.Vx = Me.StrtPt.x
            vVII.Vy = Me.StrtPt.y + Me.width
            vVII.Vz = Me.StrtPt.z + Me.height

            vVIII.Vx = Me.StrtPt.x + Me.length
            vVIII.Vy = Me.StrtPt.y + Me.width
            vVIII.Vz = Me.StrtPt.z + Me.height

        End If

        If Me.StrtPt.x <> 0 AndAlso Me.StrtPt.y = 0 AndAlso Me.StrtPt.z = 0 Then

            '^^^^^
            'Stop
            '^^^^^

            vI.Vx = Me.StrtPt.x
            vI.Vy = Me.StrtPt.y
            vI.Vz = Me.StrtPt.z

            vII.Vx = Me.StrtPt.x
            vII.Vy = Me.StrtPt.y + Me.width
            vII.Vz = Me.StrtPt.z

            vIII.Vx = Me.StrtPt.x + Me.length
            vIII.Vy = Me.StrtPt.y + Me.width
            vIII.Vz = Me.StrtPt.z

            vIV.Vx = Me.StrtPt.x + Me.length
            vIV.Vy = Me.StrtPt.y
            vIV.Vz = Me.StrtPt.z

            vV.Vx = Me.StrtPt.x + Me.length
            vV.Vy = Me.StrtPt.y
            vV.Vz = Me.StrtPt.z + Me.height

            vVI.Vx = Me.StrtPt.x
            vVI.Vy = Me.StrtPt.y
            vVI.Vz = Me.StrtPt.z + Me.height

            vVII.Vx = Me.StrtPt.x
            vVII.Vy = Me.StrtPt.y + Me.width
            vVII.Vz = Me.StrtPt.z + Me.height

            vVIII.Vx = Me.StrtPt.x + Me.length
            vVIII.Vy = Me.StrtPt.y + Me.width
            vVIII.Vz = Me.StrtPt.z + Me.height

        End If

        If Me.StrtPt.x <> 0 AndAlso Me.StrtPt.y = 0 AndAlso Me.StrtPt.z <> 0 Then

            'Stop

            vI.Vx = Me.StrtPt.x
            vI.Vy = Me.StrtPt.y
            vI.Vz = Me.StrtPt.z

            vII.Vx = Me.StrtPt.x
            vII.Vy = Me.StrtPt.y + Me.width
            vII.Vz = Me.StrtPt.z

            vIII.Vx = Me.StrtPt.x + Me.length
            vIII.Vy = Me.StrtPt.y + Me.width
            vIII.Vz = Me.StrtPt.z

            vIV.Vx = Me.StrtPt.x + Me.length
            vIV.Vy = Me.StrtPt.y
            vIV.Vz = Me.StrtPt.z

            vV.Vx = Me.StrtPt.x + Me.length
            vV.Vy = Me.StrtPt.y
            vV.Vz = Me.StrtPt.z + Me.height

            vVI.Vx = Me.StrtPt.x
            vVI.Vy = Me.StrtPt.y
            vVI.Vz = Me.StrtPt.z + Me.height

            vVII.Vx = Me.StrtPt.x
            vVII.Vy = Me.StrtPt.y + Me.width
            vVII.Vz = Me.StrtPt.z + Me.height

            vVIII.Vx = Me.StrtPt.x + Me.length
            vVIII.Vy = Me.StrtPt.y + Me.width
            vVIII.Vz = Me.StrtPt.z + Me.height

        End If

        If Me.StrtPt.x <> 0 AndAlso Me.StrtPt.y <> 0 AndAlso Me.StrtPt.z = 0 Then

            'Stop

            vI.Vx = Me.StrtPt.x
            vI.Vy = Me.StrtPt.y
            vI.Vz = Me.StrtPt.z

            vII.Vx = Me.StrtPt.x
            vII.Vy = Me.StrtPt.y + Me.width
            vII.Vz = Me.StrtPt.z

            vIII.Vx = Me.StrtPt.x + Me.length
            vIII.Vy = Me.StrtPt.y + Me.width
            vIII.Vz = Me.StrtPt.z

            vIV.Vx = Me.StrtPt.x + Me.length
            vIV.Vy = Me.StrtPt.y
            vIV.Vz = Me.StrtPt.z

            vV.Vx = Me.StrtPt.x + Me.length
            vV.Vy = Me.StrtPt.y
            vV.Vz = Me.StrtPt.z + Me.height

            vVI.Vx = Me.StrtPt.x
            vVI.Vy = Me.StrtPt.y
            vVI.Vz = Me.StrtPt.z + Me.height

            vVII.Vx = Me.StrtPt.x
            vVII.Vy = Me.StrtPt.y + Me.width
            vVII.Vz = Me.StrtPt.z + Me.height

            vVIII.Vx = Me.StrtPt.x + Me.length
            vVIII.Vy = Me.StrtPt.y + Me.width
            vVIII.Vz = Me.StrtPt.z + Me.height

        End If

        If Me.StrtPt.x <> 0 AndAlso Me.StrtPt.y <> 0 AndAlso Me.StrtPt.z <> 0 Then

            vI.Vx = Me.StrtPt.x
            vI.Vy = Me.StrtPt.y
            vI.Vz = Me.StrtPt.z

            vII.Vx = Me.StrtPt.x
            vII.Vy = Me.StrtPt.y + Me.width
            vII.Vz = Me.StrtPt.z

            vIII.Vx = Me.StrtPt.x + Me.length
            vIII.Vy = Me.StrtPt.y + Me.width
            vIII.Vz = Me.StrtPt.z

            vIV.Vx = Me.StrtPt.x + Me.length
            vIV.Vy = Me.StrtPt.y
            vIV.Vz = Me.StrtPt.z

            vV.Vx = Me.StrtPt.x + Me.length
            vV.Vy = Me.StrtPt.y
            vV.Vz = Me.StrtPt.z + Me.height

            vVI.Vx = Me.StrtPt.x
            vVI.Vy = Me.StrtPt.y
            vVI.Vz = Me.StrtPt.z + Me.height

            vVII.Vx = Me.StrtPt.x
            vVII.Vy = Me.StrtPt.y + Me.width
            vVII.Vz = Me.StrtPt.z + Me.height

            vVIII.Vx = Me.StrtPt.x + Me.length
            vVIII.Vy = Me.StrtPt.y + Me.width
            vVIII.Vz = Me.StrtPt.z + Me.height

        End If

        'Stop

        Dim LstVertx As New List(Of Vertex)
        Dim LstVtxLst As New List(Of List(Of Vertex))

        LstVertx.Add(vI)
        LstVertx.Add(vII)
        LstVertx.Add(vIII)
        LstVertx.Add(vIV)
        LstVertx.Add(vV)
        LstVertx.Add(vVI)
        LstVertx.Add(vVII)
        LstVertx.Add(vVIII)

        LstVtxLst.Add(LstVertx)

        VertexBoxInsrt(LstVtxLst, MtlNm, Mthd)

        'Stop

        'Implements from here

        Return Inc

    End Function

    'Public vI As New Vertex
    'Public vII As New Vertex
    'Public vIII As New Vertex
    'Public vIV As New Vertex
    'Public vV As New Vertex
    'Public vVI As New Vertex
    'Public vVII As New Vertex
    'Public vVIII As New Vertex

    Public Function PVertexBox(ByVal MtlNm As String, ByVal Mthd As Integer, ByVal ItmNo As String) As Boolean                      'Public Sub VertexBox(ByVal MtlNm As String, ByVal Mthd As Integer)

        If BitemqtyInr = 251 Then
            'Stop
            'off.Close()
        End If

        Dim vI As New Vertex
        Dim vII As New Vertex
        Dim vIII As New Vertex
        Dim vIV As New Vertex
        Dim vV As New Vertex
        Dim vVI As New Vertex
        Dim vVII As New Vertex
        Dim vVIII As New Vertex

        Dim X As Double = Me.StrtPt.x
        Dim Y As Double = Me.StrtPt.y
        Dim Z As Double = Me.StrtPt.z

        Dim L As Double = Me.length
        Dim W As Double = Me.width
        Dim H As Double = Me.height

        Dim Inc As Boolean = False

        L = L + X
        W = W + Y
        H = H + Z

        If L > CL Or W > CW Or H > CH Then
            Inc = True
            Return Inc
        Else
            Inc = False

        End If

        Try

            If CInt(ItmNo) >= "3" Then

                If vertxINo <> ItmNo Then

                    vIV.Vx = Me.StrtPt.x + Me.length
                    vIV.Vy = Me.StrtPt.y

                    bVx = vIV.Vx
                    bVXx = Me.StrtPt.x
                    bVy = vIV.Vy

                    vertxINo = ItmNo

                End If

                vII.Vx = Me.StrtPt.x
                vII.Vy = Me.StrtPt.y + Me.width

                If bVx > vII.Vx AndAlso bVy < vII.Vy AndAlso vII.Vx > bVXx Then
                    Inc = True
                    Return Inc
                Else
                    Inc = False
                End If

                'Stop

                'off.Close()

            End If
        Catch
            Stop
        End Try

        Return Inc

    End Function

    Public Sub AutoDraw(ByVal fn As String, ByVal col As String, ByVal transpx As Single, ByVal tex As String, ByVal itmnm As String, ByVal wt As Single, ByVal qtyflg As Boolean, ByVal txtopt As Boolean, ByVal matname As String, ByVal method As Integer, ByVal dataopt As Boolean, ByVal shapeopt As String, ByVal Imgno As String)

        'Stop

        Dim InFlg As Boolean = False

        If TransactionMenu.chkbxWadStuff1.Checked Then

            InFlg = PVertexBox(matname, method, Imgno)

        Else

            InFlg = VertexBox(matname, method, Imgno)

        End If

        Try
            'off.Close()

            Dim X As Double = Me.StrtPt.x
            Dim Y As Double = Me.StrtPt.y
            Dim Z As Double = Me.StrtPt.z

            Dim L As Double = Me.length
            Dim W As Double = Me.width
            Dim H As Double = Me.height

            If Bitemqty = BitemqtyUsr Then
                'Me.StrtPt.y = Me.StrtPt.y - 5
            End If

            'Stop

            If Not InFlg Then

                Dim Dbx As New DBxCntDor()

                'Stop

                Dim dq As Char = Chr(34)

                off.WriteLine("Transform {")        ' off.WriteLine  => fileopen(1, fn, OpenMode.Append)
                FileClose(1)

                Dim BdoPtx As Double = 0
                Dim BdoPty As Double = 0
                Dim BdoPtz As Double = 0
                Dim BdoAngle As Double = 0

                If DbxFlgO Then

                    BdoPtz = 1
                    Dbx.AngRad = OpnDeg
                    BdoAngle = Dbx.AngRadCalc()

                    Rotan(fn, New String() {CStr(BdoPtx), CStr(BdoPty), CStr(BdoPtz)}, BdoAngle)

                End If

                trans(fn, New String() {CStr(Me.StrtPt.x), CStr(Me.StrtPt.y), CStr(Me.StrtPt.z)})
                off.WriteLine("children [")
                off.WriteLine("Transform {")
                FileClose(1)

                If shapeopt = "b" Then     ' Shape of output is Box
                    trans(fn, New String() {CStr(Me.length * 0.5), CStr(Me.width * 0.5), CStr(Me.height * 0.5)})      'trans(fn, New String() {CStr(Me.length / 2), CStr(Me.width / 2), CStr(Me.height / 2)})       
                Else
                    trans(fn, New String() {CStr(Me.length), CStr(Me.length), CStr(Me.height * 0.5)})     'trans(fn, New String() {CStr(Me.length), CStr(Me.length), CStr(Me.height / 2)})
                End If

                off.WriteLine("children [")
                FileClose(1)

                If shapeopt = "b" Then
                    SetPolygon(fn, New String() {CStr(Me.length), CStr(Me.width), CStr(Me.height)}, itmnm, wt, qtyflg)       'SetPolygon is method to create Box with x y z dimensions

                    'off.Close()
                    'Stop

                Else
                    '---------------- 
                End If

                off.WriteLine("appearance Appearance {")
                If tex <> "" Then
                    off.WriteLine("texture ImageTexture {")

                    If TransactionMenu.chkbxINmPrint.Checked = True Then

                        Try

                            If Not TransactionMenu.chkbxTBPrint.Checked = True Then

                                Dim iPng As New TxtToImgP

                                iPng.PrintTxt = itmnm
                                iPng.FntSz = 12

                                iPng.ImgFlNm = CurDir() & "\Graphics/" & iPng.PrintTxt & ".png"

                                If ImgStrINm <> itmnm Then
                                    iPng.PrintPNGImage(iPng.ImgFlNm, iPng.PrintTxt, iPng.FntSz)
                                End If

                                ImgStrINm = itmnm
                                tex = iPng.ImgFlNm

                            Else

                                off.WriteLine("url " & dq & " " & dq)

                            End If

                        Catch Err As Exception
                            MsgBox(Err.Message)
                            MsgBox(Err.ToString)
                            MessageBox.Show("Error in Image Printing Text", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try

                        off.WriteLine("url " & dq & tex & dq)
                    Else

                        'If Not TransactionMenu.chkbxTBPrint.Checked = True Then

                        off.WriteLine("url " & dq & tex & dq)

                        'Else

                        'off.WriteLine("url " & dq & " " & dq)

                        'End If

                    End If
                    off.WriteLine("}")
                End If

                off.WriteLine("material Material {")
                FileClose(1)

                'transp(fn, transpx, col)    'Method transp is Diffuser color R G B and Transparancy

                DifusColr(fn, transpx, col)    'Method transp is Diffuser color R G B and Transparancy

                'Stop

                If DbxFlgO Then
                    transpx = "0"
                End If

                Transprncy(fn, transpx, col)    'Visiblity or transparancy is managed

                off.WriteLine("}")
                off.WriteLine("}")

                FileClose(1)

                '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                txtopt = TransactionMenu.chkbxtextprint.Checked
                txtRfac = 5000

                If txtopt Then

                    off.WriteLine("")
                    off.WriteLine("# Text print start")
                    off.WriteLine("")

                    'fileopen(1, fn, OpenMode.Append)

                    'attention

                    Dim txtcol As String = "diffuseColor 1 1 1"

                    Dim sz As Double
                    off.WriteLine("Transform {")
                    off.WriteLine("translation 0 " & CStr(Me.width * 1.05 / 2) & " 0")
                    off.WriteLine("children [")
                    off.WriteLine("Transform {")
                    off.WriteLine("rotation 0 1 0 -3.14")
                    off.WriteLine("children")
                    off.WriteLine("Transform {")
                    off.WriteLine("rotation 1 0 0 -1.57")
                    off.WriteLine("children")
                    off.WriteLine("Shape {")
                    off.WriteLine("geometry Text {")
                    If method = 1 Or method = 5 Then
                        itmnm = "R"
                    End If
                    If method = 2 Then
                        itmnm = "T"
                    End If
                    If method = 3 Then
                        itmnm = "T"
                    End If
                    If method = 4 Then
                        itmnm = "BK"
                    End If
                    If method = 6 Then
                        itmnm = "BK"
                    End If
                    off.WriteLine("string " & dq & itmnm & dq)
                    off.WriteLine("maxExtent " & Me.length * txtRfac)        'off.WriteLine("maxExtent " & Me.length)
                    off.WriteLine("fontStyle FontStyle {")
                    sz = Me.width * txtRfac        'sz = Me.width * 3
                    off.WriteLine("size " & CStr(sz))
                    off.WriteLine("justify [" & dq & "MIDDLE" & dq & "," & dq & "MIDDLE" & dq & "]")

                    off.WriteLine("}")
                    off.WriteLine("}")
                    off.WriteLine("appearance Appearance {")
                    off.WriteLine("material Material {")
                    off.WriteLine(txtcol)
                    off.WriteLine("transparency 0")
                    off.WriteLine("}")
                    off.WriteLine("}")
                    off.WriteLine("}")
                    off.WriteLine("}")
                    off.WriteLine("}")
                    off.WriteLine("]")
                    off.WriteLine("}")

                    off.WriteLine("Transform {")
                    off.WriteLine("translation 0 -" & CStr(Me.width * 1.05 / 2) & " 0")
                    off.WriteLine("children [")
                    off.WriteLine("Transform {")
                    off.WriteLine("rotation 1 0 0 1.57")
                    off.WriteLine("children")
                    off.WriteLine("Shape {")
                    off.WriteLine("geometry Text {")
                    If method = 1 Or method = 5 Then
                        itmnm = "L"
                    End If
                    If method = 2 Then
                        itmnm = "BT"
                    End If
                    If method = 3 Then
                        itmnm = "BT"
                    End If
                    If method = 4 Then
                        itmnm = "F"
                    End If
                    If method = 6 Then
                        itmnm = "F"
                    End If
                    off.WriteLine("string " & dq & itmnm & dq)
                    off.WriteLine("maxExtent " & Me.length * txtRfac)             'off.WriteLine("maxExtent " & Me.length)
                    off.WriteLine("fontStyle FontStyle {")
                    sz = Me.width * txtRfac                'sz = Me.width * 3
                    off.WriteLine("size " & CStr(sz))
                    off.WriteLine("justify [" & dq & "MIDDLE" & dq & "," & dq & "MIDDLE" & dq & "]")
                    off.WriteLine("}")
                    off.WriteLine("}")
                    off.WriteLine("appearance Appearance {")
                    off.WriteLine("material Material {")
                    off.WriteLine(txtcol)
                    off.WriteLine("transparency 0")
                    off.WriteLine("}")
                    off.WriteLine("}")
                    off.WriteLine("}")
                    off.WriteLine("}")
                    off.WriteLine("]")
                    off.WriteLine("}")

                    off.WriteLine("Transform {")
                    off.WriteLine("translation " & CStr(Me.length * 1.05 / 2) & " 0 0")
                    off.WriteLine("children [")
                    off.WriteLine("Transform {")
                    off.WriteLine("rotation 1 0 0 1.57")
                    off.WriteLine("children")
                    off.WriteLine("Transform {")
                    off.WriteLine("rotation 0 1 0 1.57")
                    off.WriteLine("children")
                    off.WriteLine("Shape {")
                    off.WriteLine("geometry Text {")
                    If method = 1 Or method = 2 Then
                        itmnm = "F"
                    End If
                    If method = 3 Then
                        itmnm = "R"
                    End If
                    If method = 4 Then
                        itmnm = "R"
                    End If
                    If method = 5 Then
                        itmnm = "T"
                    End If
                    If method = 6 Then
                        itmnm = "T"
                    End If
                    off.WriteLine("string " & dq & itmnm & dq)
                    off.WriteLine("maxExtent " & Me.width * txtRfac)      'off.WriteLine("maxExtent " & Me.width)
                    off.WriteLine("fontStyle FontStyle {")
                    sz = Me.length * txtRfac              'sz = Me.length * 3
                    off.WriteLine("size " & CStr(sz))
                    off.WriteLine("justify [" & dq & "MIDDLE" & dq & "," & dq & "MIDDLE" & dq & "]")
                    off.WriteLine("}")
                    off.WriteLine("}")
                    off.WriteLine("appearance Appearance {")
                    off.WriteLine("material Material {")
                    off.WriteLine(txtcol)
                    off.WriteLine("transparency 0")
                    off.WriteLine("}")
                    off.WriteLine("}")
                    off.WriteLine("}")
                    off.WriteLine("}")
                    off.WriteLine("}")
                    off.WriteLine("]")
                    off.WriteLine("}")

                    off.WriteLine("Transform {")
                    off.WriteLine("translation -" & CStr(Me.length * 1.05 / 2) & " 0 0")
                    off.WriteLine("children [")
                    off.WriteLine("Transform {")
                    off.WriteLine("rotation 1 0 0 1.57")
                    off.WriteLine("children")
                    off.WriteLine("Transform {")
                    off.WriteLine("rotation 0 1 0 -1.57")
                    off.WriteLine("children")
                    off.WriteLine("Shape {")
                    off.WriteLine("geometry Text {")
                    If method = 1 Or method = 2 Then
                        itmnm = "BK"
                    End If
                    If method = 3 Then
                        itmnm = "L"
                    End If
                    If method = 4 Then
                        itmnm = "L"
                    End If
                    If method = 5 Then
                        itmnm = "BT"
                    End If
                    If method = 6 Then
                        itmnm = "BT"
                    End If
                    off.WriteLine("string " & dq & itmnm & dq)
                    off.WriteLine("maxExtent " & Me.width * txtRfac)              'off.WriteLine("maxExtent " & Me.width)
                    off.WriteLine("fontStyle FontStyle {")
                    sz = Me.length * txtRfac   'sz = Me.length * 3
                    off.WriteLine("size " & CStr(sz))
                    off.WriteLine("justify [" & dq & "MIDDLE" & dq & "," & dq & "MIDDLE" & dq & "]")
                    off.WriteLine("}")
                    off.WriteLine("}")
                    off.WriteLine("appearance Appearance {")
                    off.WriteLine("material Material {")
                    off.WriteLine(txtcol)
                    off.WriteLine("transparency 0")
                    off.WriteLine("}")
                    off.WriteLine("}")
                    off.WriteLine("}")
                    off.WriteLine("}")
                    off.WriteLine("}")
                    off.WriteLine("]")
                    off.WriteLine("}")

                    off.WriteLine("Transform {")
                    off.WriteLine("translation 0 0 " & CStr(Me.height * 1.05 / 2))
                    off.WriteLine("children [")
                    off.WriteLine("Transform {")
                    off.WriteLine("rotation 0 0 1 1.57")
                    off.WriteLine("children")
                    off.WriteLine("Shape {")
                    off.WriteLine("geometry Text {")
                    If method = 1 Or method = 4 Then
                        itmnm = "T"
                    End If
                    If method = 2 Then
                        itmnm = "L"
                    End If
                    If method = 3 Then
                        itmnm = "F"
                    End If
                    If method = 5 Then
                        itmnm = "BK"
                    End If
                    If method = 6 Then
                        itmnm = "F"
                    End If

                    off.WriteLine("string " & dq & itmnm & dq)
                    off.WriteLine("maxExtent " & Me.width * txtRfac)          'off.WriteLine("maxExtent " & Me.width)
                    off.WriteLine("fontStyle FontStyle {")
                    sz = Me.height * txtRfac                       'sz = Me.height * 3
                    off.WriteLine("size " & CStr(sz))
                    off.WriteLine("justify [" & dq & "MIDDLE" & dq & "," & dq & "MIDDLE" & dq & "]")
                    off.WriteLine("}")
                    off.WriteLine("}")
                    off.WriteLine("appearance Appearance {")
                    off.WriteLine("material Material {")
                    off.WriteLine(txtcol)
                    off.WriteLine("transparency 0")
                    off.WriteLine("}")
                    off.WriteLine("}")
                    off.WriteLine("}")
                    off.WriteLine("}")
                    off.WriteLine("]")
                    off.WriteLine("}")

                    off.WriteLine("Transform {")
                    off.WriteLine("translation 0 0 -" & CStr(Me.height * 1.05 / 2))
                    off.WriteLine("children [")
                    off.WriteLine("Transform {")
                    off.WriteLine("rotation 0 0 1 1.57")
                    off.WriteLine("children")
                    off.WriteLine("Shape {")
                    off.WriteLine("geometry Text {")

                    If method = 1 Or method = 4 Then
                        itmnm = "BT"
                    End If
                    If method = 2 Then
                        itmnm = "R"
                    End If
                    If method = 3 Then
                        itmnm = "BK"
                    End If
                    If method = 5 Then
                        itmnm = "F"
                    End If
                    If method = 6 Then
                        itmnm = "R"
                    End If

                    off.WriteLine("string " & dq & itmnm & dq)
                    off.WriteLine("maxExtent " & Me.width * txtRfac)              'off.WriteLine("maxExtent " & Me.width)
                    off.WriteLine("fontStyle FontStyle {")
                    sz = Me.height * txtRfac               'sz = Me.height * 3
                    off.WriteLine("size " & CStr(sz))
                    off.WriteLine("justify [" & dq & "MIDDLE" & dq & "," & dq & "MIDDLE" & dq & "]")
                    off.WriteLine("}")
                    off.WriteLine("}")
                    off.WriteLine("appearance Appearance {")
                    off.WriteLine("material Material {")
                    off.WriteLine(txtcol)
                    off.WriteLine("transparency 0")
                    off.WriteLine("}")
                    off.WriteLine("}")
                    off.WriteLine("}")
                    off.WriteLine("}")
                    off.WriteLine("]")
                    off.WriteLine("}")

                    FileClose(1)
                End If

                off.WriteLine("")
                'off.WriteLine("# Text print end")
                off.WriteLine("")

                '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

                'fileopen(1, fn, OpenMode.Append)

                off.WriteLine("]")
                off.WriteLine("}")
                off.WriteLine("]")
                off.WriteLine("}")
                off.WriteLine("")
                FileClose(1)

                'Stop
                'off.Close()
                'Stop

            End If

            'Top Bottom Right Left wirtting program

            If TransactionMenu.chkbxTBPrint.Checked = True Then

                If Not (method = 0) Then

                    Call TBLRFBKBT(method, col)

                End If

            End If

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Fatal error in AutoDraw" & vbCrLf & "VRML Programme writting is failure!", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            FileClose(1)
            conn.Close()
            off.Close()
            'Form8.Close()
            'MsgBox("Exception :: In method 'AutoDraw'  " & vbCrLf & "Due to an error application exit!...")
            Application.Exit()
        Finally
            FileClose()
        End Try

        'Stop

        Call DataBaseEntry(matname, method, col, tex, wt, dataopt)

        'Try

        '    If TransactionMenu.chkbxCG.Checked Then

        '        Call CGGenrate(matname, Me.StrtPt.x, Me.StrtPt.y, Me.StrtPt.z, Me.length, Me.width, Me.height, method, col, tex, wt)

        '    End If

        '    If dataopt Then
        '        Dim cmd As New OleDb.OleDbCommand
        '        cmd.Connection = conn
        '        'cmd.CommandText = "insert into stuffdata values('" & matname & "'," & CStr(Me.StrtPt.x) & "," & CStr(Me.StrtPt.y) & "," & CStr(Me.StrtPt.z) & "," & CStr(Me.length) & "," & CStr(Me.width) & "," & CStr(Me.height) & "," & CStr(method) & ",'" & col & "','" & tex & "',0)"
        '        cmd.CommandText = "insert into stuffdata values('" & matname & "'," & CStr(Me.StrtPt.x) & "," & CStr(Me.StrtPt.y) & "," & CStr(Me.StrtPt.z) & "," & CStr(Me.length) & "," & CStr(Me.width) & "," & CStr(Me.height) & "," & CStr(method) & ",'" & col & "','" & tex & "'," & wt & ")"
        '        cmd.ExecuteNonQuery()
        '        'conn.Close()  'Do not Close Connection Here 
        '        InsrtBxData(matname, Me.StrtPt.x, Me.StrtPt.y, Me.StrtPt.z, Me.length, Me.width, Me.height, method, col, tex, BitemqtyInr)

        '    End If

        'Catch Ex As Exception
        '    MsgBox(Ex.Message)
        '    MsgBox(Ex.ToString)
        '    MessageBox.Show("Error in AutoDraw" & vbCrLf & "Data insert connection failure!", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    'MsgBox("Exception :: In Method 'AutoDraw'  " & vbCrLf & "Data insert connection failure!")
        '    conn.Close()
        '    off.Close()
        'End Try

    End Sub

    Public Function TBLRFBKBT(ByVal method As Integer, ByVal col As String) As Boolean

        Dim itmnmFNm As String = Nothing
        Dim dq As Char = Chr(34)

        Try

            If method = 1 Or method = 5 Then
                itmnmFNm = CurDir() & "\Graphics\T-054e7fa2-befe-4db6-a098-8fef5509e84a.png"
            End If
            If method = 2 Then
                itmnmFNm = CurDir() & "\Graphics\BK-48c0e8b4-a031-4652-9ad2-4f616528189d.png"
            End If
            If method = 3 Then
                itmnmFNm = CurDir() & "\Graphics\BK-48c0e8b4-a031-4652-9ad2-4f616528189d.png"
            End If
            If method = 4 Then
                itmnmFNm = CurDir() & "\Graphics\R-3868a583-f03f-4dff-9c3a-d22e897685fb.png"
            End If
            If method = 6 Then
                itmnmFNm = CurDir() & "\Graphics\R-3868a583-f03f-4dff-9c3a-d22e897685fb.png"
            End If
            off.WriteLine("")
            off.WriteLine("Transform {")
            off.WriteLine("rotation 0 0 1 -1.570796327")
            off.WriteLine("translation " & (Me.length * 0.5 + Me.StrtPt.x) & " " & (Me.width * 0.5 + Me.StrtPt.y) & " " & (Me.height * 0.5 + Me.StrtPt.z))
            off.WriteLine("children [")
            off.WriteLine("Transform {")
            If (Me.height * 0.5) > 0 Then
                off.WriteLine("translation 0 0 " & Me.height * 0.5)
            Else
                off.WriteLine("translation 0 0 " & (Me.height * 0.5 + Me.StrtPt.z))
            End If
            off.WriteLine("children [")
            off.WriteLine("Shape {")
            off.WriteLine("geometry Box {")
            off.WriteLine("size " & (Me.width * 0.5) & " " & (Me.length * 0.5) & " 0.1")
            off.WriteLine("}")
            off.WriteLine("appearance Appearance {")
            off.WriteLine("texture ImageTexture {")
            off.WriteLine("url " & dq & itmnmFNm & dq)
            off.WriteLine("}")
            off.WriteLine("material Material {")
            If col.Length > 1 Then
                off.WriteLine("diffuseColor " & col)
            Else
                off.WriteLine("diffuseColor 1 1 1")
            End If
            off.WriteLine("transparency 0")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("]")
            off.WriteLine("}")
            off.WriteLine("]")
            off.WriteLine("}")
            off.WriteLine("")
            '================================================
            If method = 1 Or method = 5 Then
                itmnmFNm = CurDir() & "\Graphics\BT-26223d07-cc80-40ec-9945-aad002e9f4f4.png"
            End If
            If method = 2 Then
                itmnmFNm = CurDir() & "\Graphics\F-e8ea8b78-2ccb-4f0d-a22e-64a8faffc325.png"
            End If
            If method = 3 Then
                itmnmFNm = CurDir() & "\Graphics\F-e8ea8b78-2ccb-4f0d-a22e-64a8faffc325.png"
            End If
            If method = 4 Then
                itmnmFNm = CurDir() & "\Graphics\L-c4a59ad4-cad6-4027-a782-4b440ace4e47.png"
            End If
            If method = 6 Then
                itmnmFNm = CurDir() & "\Graphics\L-c4a59ad4-cad6-4027-a782-4b440ace4e47.png"
            End If
            off.WriteLine("Transform {")
            off.WriteLine("rotation 0 0 1 -1.570796327")
            off.WriteLine("translation " & (Me.length * 0.5 + Me.StrtPt.x) & " " & (Me.width * 0.5 + Me.StrtPt.y) & " " & (Me.height * 0.5 + Me.StrtPt.z))
            off.WriteLine("children [")
            off.WriteLine("Transform {")
            off.WriteLine("translation 0 0 -" & (Me.height * 0.5))
            off.WriteLine("children [")
            off.WriteLine("Shape {")
            off.WriteLine("geometry Box {")
            off.WriteLine("size " & (Me.width * 0.5) & " " & (Me.length * 0.5) & " 0.1")
            off.WriteLine("}")
            off.WriteLine("appearance Appearance {")
            off.WriteLine("texture ImageTexture {")
            off.WriteLine("url " & dq & itmnmFNm & dq)
            off.WriteLine("}")
            off.WriteLine("material Material {")
            If col.Length > 1 Then
                off.WriteLine("diffuseColor " & col)
            Else
                off.WriteLine("diffuseColor 1 1 1")
            End If
            off.WriteLine("transparency 0")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("]")
            off.WriteLine("}")
            off.WriteLine("]")
            off.WriteLine("}")
            off.WriteLine("")
            '==========================================================================
            If method = 1 Or method = 2 Then
                itmnmFNm = CurDir() & "\Graphics\L-c4a59ad4-cad6-4027-a782-4b440ace4e47.png"
            End If
            If method = 3 Then
                itmnmFNm = CurDir() & "\Graphics\T-054e7fa2-befe-4db6-a098-8fef5509e84a.png"
            End If
            If method = 4 Then
                itmnmFNm = CurDir() & "\Graphics\T-054e7fa2-befe-4db6-a098-8fef5509e84a.png"
            End If
            If method = 5 Then
                itmnmFNm = CurDir() & "\Graphics\BK-48c0e8b4-a031-4652-9ad2-4f616528189d.png"
            End If
            If method = 6 Then
                itmnmFNm = CurDir() & "\Graphics\BK-48c0e8b4-a031-4652-9ad2-4f616528189d.png"
            End If
            off.WriteLine("Transform {")
            off.WriteLine("rotation 0 0 1 3.141592654")
            off.WriteLine("translation " & (Me.length * 0.5 + Me.StrtPt.x) & " " & (Me.width * 0.5 + Me.StrtPt.y) & " " & (Me.height * 0.5 + Me.StrtPt.z))
            off.WriteLine("children [")
            off.WriteLine("Transform {")
            off.WriteLine("translation 0 " & (Me.width * 0.5) & " 0")
            off.WriteLine("children [")
            off.WriteLine("Shape {")
            off.WriteLine("geometry Box {")
            off.WriteLine("size " & (Me.length * 0.5) & " 0.1 " & (Me.height * 0.5))
            off.WriteLine("}")
            off.WriteLine("appearance Appearance {")
            off.WriteLine("texture ImageTexture {")
            off.WriteLine("url " & dq & itmnmFNm & dq)
            off.WriteLine("}")
            off.WriteLine("material Material {")
            If col.Length > 1 Then
                off.WriteLine("diffuseColor " & col)
            Else
                off.WriteLine("diffuseColor 1 1 1")
            End If
            off.WriteLine("transparency 0")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("]")
            off.WriteLine("}")
            off.WriteLine("]")
            off.WriteLine("}")
            off.WriteLine("")
            '================================================================================================
            If method = 1 Or method = 2 Then
                itmnmFNm = CurDir() & "\Graphics\R-3868a583-f03f-4dff-9c3a-d22e897685fb.png"
            End If
            If method = 3 Then
                itmnmFNm = CurDir() & "\Graphics\BT-26223d07-cc80-40ec-9945-aad002e9f4f4.png"
            End If
            If method = 4 Then
                itmnmFNm = CurDir() & "\Graphics\BT-26223d07-cc80-40ec-9945-aad002e9f4f4.png"
            End If
            If method = 5 Then
                itmnmFNm = CurDir() & "\Graphics\F-e8ea8b78-2ccb-4f0d-a22e-64a8faffc325.png"
            End If
            If method = 6 Then
                itmnmFNm = CurDir() & "\Graphics\F-e8ea8b78-2ccb-4f0d-a22e-64a8faffc325.png"
            End If
            off.WriteLine("Transform {")
            off.WriteLine("rotation 0 0 1 3.141592654")
            off.WriteLine("translation " & (Me.length * 0.5 + Me.StrtPt.x) & " " & (Me.width * 0.5 + Me.StrtPt.y) & " " & (Me.height * 0.5 + Me.StrtPt.z))
            off.WriteLine("children [")
            off.WriteLine("Transform {")
            off.WriteLine("translation 0 -" & (Me.width * 0.5) & " 0")
            off.WriteLine("children [")
            off.WriteLine("Shape {")
            off.WriteLine("geometry Box {")
            off.WriteLine("size " & (Me.length * 0.5) & " 0.1 " & (Me.height * 0.5))
            off.WriteLine("}")
            off.WriteLine("appearance Appearance {")
            off.WriteLine("texture ImageTexture {")
            off.WriteLine("url " & dq & itmnmFNm & dq)
            off.WriteLine("}")
            off.WriteLine("material Material {")
            If col.Length > 1 Then
                off.WriteLine("diffuseColor " & col)
            Else
                off.WriteLine("diffuseColor 1 1 1")
            End If
            off.WriteLine("transparency 0")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("]")
            off.WriteLine("}")
            off.WriteLine("]")
            off.WriteLine("}")
            off.WriteLine("")
            '===========================================================================================
            If method = 1 Or method = 4 Then
                itmnmFNm = CurDir() & "\Graphics\BK-48c0e8b4-a031-4652-9ad2-4f616528189d.png"
            End If
            If method = 2 Then
                itmnmFNm = CurDir() & "\Graphics\BT-26223d07-cc80-40ec-9945-aad002e9f4f4.png"
            End If
            If method = 3 Then
                itmnmFNm = CurDir() & "\Graphics\L-c4a59ad4-cad6-4027-a782-4b440ace4e47.png"
            End If
            If method = 5 Then
                itmnmFNm = CurDir() & "\Graphics\R-3868a583-f03f-4dff-9c3a-d22e897685fb.png"
            End If
            If method = 6 Then
                itmnmFNm = CurDir() & "\Graphics\L-c4a59ad4-cad6-4027-a782-4b440ace4e47.png"
            End If
            off.WriteLine("Transform {")
            off.WriteLine("rotation 0 0 1 1.570796327")
            off.WriteLine("translation " & (Me.length * 0.5 + Me.StrtPt.x) & " " & (Me.width * 0.5 + Me.StrtPt.y) & " " & (Me.height * 0.5 + Me.StrtPt.z))
            off.WriteLine("children [")
            off.WriteLine("Transform {")
            off.WriteLine("translation 0 " & (Me.length * 0.5) & " 0")
            off.WriteLine("children [")
            off.WriteLine("Shape {")
            off.WriteLine("geometry Box {")
            off.WriteLine("size " & (Me.width * 0.5) & " 0.1 " & (Me.height * 0.5))
            off.WriteLine("}")
            off.WriteLine("appearance Appearance {")
            off.WriteLine("texture ImageTexture {")
            off.WriteLine("url " & dq & itmnmFNm & dq)
            off.WriteLine("}")
            off.WriteLine("material Material {")
            If col.Length > 1 Then
                off.WriteLine("diffuseColor " & col)
            Else
                off.WriteLine("diffuseColor 1 1 1")
            End If
            off.WriteLine("transparency 0")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("]")
            off.WriteLine("}")
            off.WriteLine("]")
            off.WriteLine("}")
            off.WriteLine("")
            '==========================================================================================================
            If method = 1 Or method = 4 Then
                itmnmFNm = CurDir() & "\Graphics\F-e8ea8b78-2ccb-4f0d-a22e-64a8faffc325.png"
            End If
            If method = 2 Then
                itmnmFNm = CurDir() & "\Graphics\T-054e7fa2-befe-4db6-a098-8fef5509e84a.png"
            End If
            If method = 3 Then
                itmnmFNm = CurDir() & "\Graphics\R-3868a583-f03f-4dff-9c3a-d22e897685fb.png"
            End If
            If method = 5 Then
                itmnmFNm = CurDir() & "\Graphics\L-c4a59ad4-cad6-4027-a782-4b440ace4e47.png"
            End If
            If method = 6 Then
                itmnmFNm = CurDir() & "\Graphics\T-054e7fa2-befe-4db6-a098-8fef5509e84a.png"
            End If
            off.WriteLine("Transform {")
            off.WriteLine("rotation 0 0 1 1.570796327")
            off.WriteLine("translation " & (Me.length * 0.5 + Me.StrtPt.x) & " " & (Me.width * 0.5 + Me.StrtPt.y) & " " & (Me.height * 0.5 + Me.StrtPt.z))
            off.WriteLine("children [")
            off.WriteLine("Transform {")
            off.WriteLine("translation 0 -" & (Me.length * 0.5) & " 0")
            off.WriteLine("children [")
            off.WriteLine("Shape {")
            off.WriteLine("geometry Box {")
            off.WriteLine("size " & (Me.width * 0.5) & " 0.1 " & (Me.height * 0.5))
            off.WriteLine("}")
            off.WriteLine("appearance Appearance {")
            off.WriteLine("texture ImageTexture {")
            off.WriteLine("url " & dq & itmnmFNm & dq)
            off.WriteLine("}")
            off.WriteLine("material Material {")
            If col.Length > 1 Then
                off.WriteLine("diffuseColor " & col)
            Else
                off.WriteLine("diffuseColor 1 1 1")
            End If
            off.WriteLine("transparency 0")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("]")
            off.WriteLine("}")
            off.WriteLine("]")
            off.WriteLine("}")
            off.WriteLine("")

            FileClose(1)

        Catch Er As Exception
            MsgBox(Er.Message)
            MsgBox(Er.ToString)
            MessageBox.Show("Error in TBLRFBKBT", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return True

    End Function


    Public Function TBLRFBKBT_DUDO(ByVal method As Integer) As Boolean

        'Dim method As Integer
        Dim itmnmFNm As String = Nothing
        Dim dq As Char = Chr(34)

        If method = 1 Or method = 5 Then
            'itmnm = "R"
            itmnmFNm = CurDir() & "\Graphics\R-3868a583-f03f-4dff-9c3a-d22e897685fb.png"
        End If
        If method = 2 Then
            'itmnm = "T"
            itmnmFNm = CurDir() & "\Graphics\T-054e7fa2-befe-4db6-a098-8fef5509e84a.png"
        End If
        If method = 3 Then
            'itmnm = "T"
            itmnmFNm = CurDir() & "\Graphics\T-054e7fa2-befe-4db6-a098-8fef5509e84a.png"
        End If
        If method = 4 Then
            'itmnm = "BK"
            itmnmFNm = CurDir() & "\Graphics\BK-48c0e8b4-a031-4652-9ad2-4f616528189d.png"
        End If
        If method = 6 Then
            'itmnm = "BK"
            itmnmFNm = CurDir() & "\Graphics\BK-48c0e8b4-a031-4652-9ad2-4f616528189d.png"
        End If

        off.WriteLine("")

        off.WriteLine("Transform {")
        off.WriteLine("rotation 0 0 1 -1.570796327")
        'off.WriteLine("translation 116 46 47")

        off.WriteLine("translation " & Me.length * 0.5 & " " & Me.width * 0.5 & " " & Me.height * 0.5)

        off.WriteLine("children [")
        off.WriteLine("Transform {")
        'off.WriteLine("translation 0 0 47")

        off.WriteLine("translation 0 0 " & Me.height * 0.5)

        off.WriteLine("children [")
        off.WriteLine("Shape {")
        off.WriteLine("geometry Box {")
        'off.WriteLine("size 46 116 0.1")

        off.WriteLine("size " & Me.width * 0.5 & " " & Me.length * 0.5 & " 0.1")

        off.WriteLine("}")
        off.WriteLine("appearance Appearance {")
        off.WriteLine("texture ImageTexture {")

        'off.WriteLine("C:\Documents and Settings\Administrator\Desktop\T.png")

        off.WriteLine("url " & itmnmFNm)

        off.WriteLine("}")
        off.WriteLine("material Material {")
        off.WriteLine("diffuseColor 1 1 1")
        off.WriteLine("transparency 0")
        off.WriteLine("}")
        off.WriteLine("}")
        off.WriteLine("}")
        off.WriteLine("]")
        off.WriteLine("}")
        off.WriteLine("]")
        off.WriteLine("}")

        off.WriteLine("")




        '================================================


        If method = 1 Or method = 5 Then
            'itmnm = "L"
            itmnmFNm = CurDir() & "\Graphics\L-c4a59ad4-cad6-4027-a782-4b440ace4e47.png"
        End If
        If method = 2 Then
            'itmnm = "BT"
            itmnmFNm = CurDir() & "\Graphics\BT-26223d07-cc80-40ec-9945-aad002e9f4f4.png"
        End If
        If method = 3 Then
            'itmnm = "BT"
            itmnmFNm = CurDir() & "\Graphics\BT-26223d07-cc80-40ec-9945-aad002e9f4f4.png"
        End If
        If method = 4 Then
            'itmnm = "F"
            itmnmFNm = CurDir() & "\Graphics\F-e8ea8b78-2ccb-4f0d-a22e-64a8faffc325.png"
        End If
        If method = 6 Then
            'itmnm = "F"
            itmnmFNm = CurDir() & "\Graphics\F-e8ea8b78-2ccb-4f0d-a22e-64a8faffc325.png"
        End If



        off.WriteLine("Transform {")
        off.WriteLine("rotation 0 0 1 -1.570796327")

        'off.WriteLine("translation 116 46 47")

        off.WriteLine("translation " & Me.length * 0.5 & " " & Me.width * 0.5 & " " & Me.height * 0.5)

        off.WriteLine("children [")
        off.WriteLine("Transform {")


        'off.WriteLine("translation 0 0 -47")

        off.WriteLine("translation 0 0 -" & Me.height * 0.5)


        off.WriteLine("children [")
        off.WriteLine("Shape {")
        off.WriteLine("geometry Box {")


        'off.WriteLine("size 46 116 0.1")

        off.WriteLine("size " & Me.width * 0.5 & " " & Me.length * 0.5 & " 0.1")


        off.WriteLine("}")
        off.WriteLine("appearance Appearance {")
        off.WriteLine("texture ImageTexture {")


        'off.WriteLine("url C:\Documents and Settings\Administrator\Desktop\BT.png")
        off.WriteLine("url " & itmnmFNm)


        off.WriteLine("}")
        off.WriteLine("material Material {")
        off.WriteLine("diffuseColor 1 1 1")
        off.WriteLine("transparency 0")
        off.WriteLine("}")
        off.WriteLine("}")
        off.WriteLine("}")
        off.WriteLine("]")
        off.WriteLine("}")
        off.WriteLine("]")
        off.WriteLine("}")

        off.WriteLine("")

        '==========================================================================



        If method = 1 Or method = 2 Then
            'itmnm = "F"
            itmnmFNm = CurDir() & "\Graphics\F-e8ea8b78-2ccb-4f0d-a22e-64a8faffc325.png"
        End If
        If method = 3 Then
            'itmnm = "R"
            itmnmFNm = CurDir() & "\Graphics\R-3868a583-f03f-4dff-9c3a-d22e897685fb.png"
        End If
        If method = 4 Then
            'itmnm = "R"
            itmnmFNm = CurDir() & "\Graphics\R-3868a583-f03f-4dff-9c3a-d22e897685fb.png"
        End If
        If method = 5 Then
            'itmnm = "T"
            itmnmFNm = CurDir() & "\Graphics\T-054e7fa2-befe-4db6-a098-8fef5509e84a.png"
        End If
        If method = 6 Then
            'itmnm = "T"
            itmnmFNm = CurDir() & "\Graphics\T-054e7fa2-befe-4db6-a098-8fef5509e84a.png"
        End If






        off.WriteLine("Transform {")
        off.WriteLine("rotation 0 0 1 3.141592654")


        off.WriteLine("translation 116 46 47")

        off.WriteLine("translation " & Me.length * 0.5 & " " & Me.width * 0.5 & " " & Me.height * 0.5)


        off.WriteLine("children [")
        off.WriteLine("Transform {")

        'off.WriteLine("translation 0 46 0")

        off.WriteLine("translation 0 " & Me.width * 0.5 & " 0")




        off.WriteLine("children [")
        off.WriteLine("Shape {")
        off.WriteLine("geometry Box {")


        off.WriteLine("size 116 0.1 47")
        off.WriteLine("size " & Me.length * 0.5 & " 0.1 " & Me.height * 0.5)



        off.WriteLine("}")
        off.WriteLine("appearance Appearance {")
        off.WriteLine("texture ImageTexture {")


        'off.WriteLine("url C:\Documents and Settings\Administrator\Desktop\L.png")

        off.WriteLine("url " & itmnmFNm)



        off.WriteLine("}")
        off.WriteLine("material Material {")
        off.WriteLine("diffuseColor 1 1 1")
        off.WriteLine("transparency 0")
        off.WriteLine("}")
        off.WriteLine("}")
        off.WriteLine("}")
        off.WriteLine("]")
        off.WriteLine("}")
        off.WriteLine("]")
        off.WriteLine("}")

        off.WriteLine("")


        '================================================================================================



        If method = 1 Or method = 2 Then
            'itmnm = "BK"
            itmnmFNm = CurDir() & "\Graphics\BK-48c0e8b4-a031-4652-9ad2-4f616528189d.png"
        End If
        If method = 3 Then
            'itmnm = "L"
            itmnmFNm = CurDir() & "\Graphics\L-c4a59ad4-cad6-4027-a782-4b440ace4e47.png"
        End If
        If method = 4 Then
            'itmnm = "L"
            itmnmFNm = CurDir() & "\Graphics\L-c4a59ad4-cad6-4027-a782-4b440ace4e47.png"
        End If
        If method = 5 Then
            'itmnm = "BT"
            itmnmFNm = CurDir() & "\Graphics\BT-26223d07-cc80-40ec-9945-aad002e9f4f4.png"
        End If
        If method = 6 Then
            'itmnm = "BT"
            itmnmFNm = CurDir() & "\Graphics\BT-26223d07-cc80-40ec-9945-aad002e9f4f4.png"
        End If








        off.WriteLine("Transform {")
        off.WriteLine("rotation 0 0 1 3.141592654")

        'off.WriteLine("translation 116 46 47")

        off.WriteLine("translation " & Me.length * 0.5 & " " & Me.width * 0.5 & " " & Me.height * 0.5)



        off.WriteLine("children [")
        off.WriteLine("Transform {")


        off.WriteLine("translation 0 -46 0")


        off.WriteLine("translation 0 -" & Me.width * 0.5 & " 0")


        off.WriteLine("children [")
        off.WriteLine("Shape {")
        off.WriteLine("geometry Box {")


        off.WriteLine("size 116 0.1 47")

        off.WriteLine("size " & Me.length * 0.5 & " 0.1 " & Me.height * 0.5)



        off.WriteLine("}")
        off.WriteLine("appearance Appearance {")
        off.WriteLine("texture ImageTexture {")


        'off.WriteLine("url C:\Documents and Settings\Administrator\Desktop\R.png")


        off.WriteLine("url " & itmnmFNm)


        off.WriteLine("}")
        off.WriteLine("material Material {")
        off.WriteLine("diffuseColor 1 1 1")
        off.WriteLine("transparency 0")
        off.WriteLine("}")
        off.WriteLine("}")
        off.WriteLine("}")
        off.WriteLine("]")
        off.WriteLine("}")
        off.WriteLine("]")
        off.WriteLine("}")

        off.WriteLine("")

        '===========================================================================================


        If method = 1 Or method = 4 Then
            'itmnm = "T"
            itmnmFNm = CurDir() & "\Graphics\T-054e7fa2-befe-4db6-a098-8fef5509e84a.png"
        End If
        If method = 2 Then
            'itmnm = "L"
            itmnmFNm = CurDir() & "\Graphics\L-c4a59ad4-cad6-4027-a782-4b440ace4e47.png"
        End If
        If method = 3 Then
            'itmnm = "F"
            itmnmFNm = CurDir() & "\Graphics\F-e8ea8b78-2ccb-4f0d-a22e-64a8faffc325.png"
        End If
        If method = 5 Then
            'itmnm = "BK"
            itmnmFNm = CurDir() & "\Graphics\BK-48c0e8b4-a031-4652-9ad2-4f616528189d.png"
        End If
        If method = 6 Then
            'itmnm = "F"
            itmnmFNm = CurDir() & "\Graphics\F-e8ea8b78-2ccb-4f0d-a22e-64a8faffc325.png"
        End If



        off.WriteLine("Transform {")
        off.WriteLine("rotation 0 0 1 1.570796327")


        'off.WriteLine("translation 116 46 47")

        off.WriteLine("translation " & Me.length * 0.5 & " " & Me.width * 0.5 & " " & Me.height * 0.5)


        off.WriteLine("children [")
        off.WriteLine("Transform {")


        off.WriteLine("translation 0 116 0")


        off.WriteLine("translation 0 " & Me.length * 0.5 & " 0")




        off.WriteLine("children [")
        off.WriteLine("Shape {")
        off.WriteLine("geometry Box {")

        'off.WriteLine("size 46 0.1 47")

        off.WriteLine("size " & Me.width * 0.5 & " 0.1 " & Me.height * 0.5)


        off.WriteLine("}")
        off.WriteLine("appearance Appearance {")
        off.WriteLine("texture ImageTexture {")


        'off.WriteLine("url C:\Documents and Settings\Administrator\Desktop\BK.png")


        off.WriteLine("url " & itmnmFNm)



        off.WriteLine("}")
        off.WriteLine("material Material {")
        off.WriteLine("diffuseColor 1 1 1")
        off.WriteLine("transparency 0")
        off.WriteLine("}")
        off.WriteLine("}")
        off.WriteLine("}")
        off.WriteLine("]")
        off.WriteLine("}")
        off.WriteLine("]")
        off.WriteLine("}")

        off.WriteLine("")


        '==========================================================================================================




        If method = 1 Or method = 4 Then
            'itmnm = "BT"
            itmnmFNm = CurDir() & "\Graphics\BT-26223d07-cc80-40ec-9945-aad002e9f4f4.png"
        End If
        If method = 2 Then
            'itmnm = "R"
            itmnmFNm = CurDir() & "\Graphics\R-3868a583-f03f-4dff-9c3a-d22e897685fb.png"
        End If
        If method = 3 Then
            'itmnm = "BK"
            itmnmFNm = CurDir() & "\Graphics\BK-48c0e8b4-a031-4652-9ad2-4f616528189d.png"
        End If
        If method = 5 Then
            'itmnm = "F"
            itmnmFNm = CurDir() & "\Graphics\F-e8ea8b78-2ccb-4f0d-a22e-64a8faffc325.png"
        End If
        If method = 6 Then
            'itmnm = "R"
            itmnmFNm = CurDir() & "\Graphics\R-3868a583-f03f-4dff-9c3a-d22e897685fb.png"
        End If



        off.WriteLine("Transform {")
        off.WriteLine("rotation 0 0 1 1.570796327")


        'off.WriteLine("translation 116 46 47")

        off.WriteLine("translation " & Me.length * 0.5 & " " & Me.width * 0.5 & " " & Me.height * 0.5)


        off.WriteLine("children [")
        off.WriteLine("Transform {")


        'off.WriteLine("translation 0 -116 0")

        off.WriteLine("translation 0 -" & Me.length * 0.5 & " 0")


        off.WriteLine("children [")
        off.WriteLine("Shape {")
        off.WriteLine("geometry Box {")

        'off.WriteLine("size 46 0.1 47")

        off.WriteLine("size " & Me.width * 0.5 & " 0.1 " & Me.height * 0.5)


        off.WriteLine("}")
        off.WriteLine("appearance Appearance {")
        off.WriteLine("texture ImageTexture {")


        'off.WriteLine("url C:\Documents and Settings\Administrator\Desktop\F.png")

        off.WriteLine("url " & itmnmFNm)

        off.WriteLine("}")
        off.WriteLine("material Material {")
        off.WriteLine("diffuseColor 1 1 1")
        off.WriteLine("transparency 0")
        off.WriteLine("}")
        off.WriteLine("}")
        off.WriteLine("}")
        off.WriteLine("]")
        off.WriteLine("}")
        off.WriteLine("]")
        off.WriteLine("}")

        off.WriteLine("")

        FileClose(1)

        Return True

    End Function

    Public Sub DataBaseEntry(ByVal matname As String, ByVal method As Integer, ByVal col As String, ByVal tex As String, ByVal wt As Single, ByVal dataopt As Boolean)

        Try

            If TransactionMenu.chkbxCG.Checked Then

                Call CGGenrate(matname, Me.StrtPt.x, Me.StrtPt.y, Me.StrtPt.z, Me.length, Me.width, Me.height, method, col, tex, wt)

            End If

            If dataopt Then
                Dim cmd As New OleDb.OleDbCommand
                cmd.Connection = conn
                'cmd.CommandText = "insert into stuffdata values('" & matname & "'," & CStr(Me.StrtPt.x) & "," & CStr(Me.StrtPt.y) & "," & CStr(Me.StrtPt.z) & "," & CStr(Me.length) & "," & CStr(Me.width) & "," & CStr(Me.height) & "," & CStr(method) & ",'" & col & "','" & tex & "',0)"
                cmd.CommandText = "insert into stuffdata values('" & matname & "'," & CStr(Me.StrtPt.x) & "," & CStr(Me.StrtPt.y) & "," & CStr(Me.StrtPt.z) & "," & CStr(Me.length) & "," & CStr(Me.width) & "," & CStr(Me.height) & "," & CStr(method) & ",'" & col & "','" & tex & "'," & wt & ")"
                cmd.ExecuteNonQuery()
                'conn.Close()  'Do not Close Connection Here 
                InsrtBxData(matname, Me.StrtPt.x, Me.StrtPt.y, Me.StrtPt.z, Me.length, Me.width, Me.height, method, col, tex, BitemqtyInr)

            End If

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in AutoDraw" & vbCrLf & "Data insert connection failure!", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'MsgBox("Exception :: In Method 'AutoDraw'  " & vbCrLf & "Data insert connection failure!")
            conn.Close()
            off.Close()
        End Try

    End Sub

    Public Sub Orig_AutoDraw(ByVal fn As String, ByVal col As String, ByVal transpx As Single, ByVal tex As String, ByVal itmnm As String, ByVal wt As Single, ByVal qtyflg As Boolean, ByVal txtopt As Boolean, ByVal matname As String, ByVal method As Integer, ByVal dataopt As Boolean, ByVal shapeopt As String)

        'Stop

        Dim InFlg As Boolean = False

        InFlg = VertexBox(matname, method, itmnm)

        Try
            'off.Close()

            Dim X As Double = Me.StrtPt.x
            Dim Y As Double = Me.StrtPt.y
            Dim Z As Double = Me.StrtPt.z

            Dim L As Double = Me.length
            Dim W As Double = Me.width
            Dim H As Double = Me.height

            If Bitemqty = BitemqtyUsr Then
                'Me.StrtPt.y = Me.StrtPt.y - 5
            End If

            'Stop

            If Not InFlg Then

                Dim Dbx As New DBxCntDor()

                'Stop

                Dim dq As Char = Chr(34)

                off.WriteLine("Transform {")        ' off.WriteLine  => fileopen(1, fn, OpenMode.Append)
                FileClose(1)

                Dim BdoPtx As Double = 0
                Dim BdoPty As Double = 0
                Dim BdoPtz As Double = 0
                Dim BdoAngle As Double = 0

                If DbxFlgO Then

                    BdoPtz = 1
                    Dbx.AngRad = OpnDeg
                    BdoAngle = Dbx.AngRadCalc()

                    Rotan(fn, New String() {CStr(BdoPtx), CStr(BdoPty), CStr(BdoPtz)}, BdoAngle)

                End If

                trans(fn, New String() {CStr(Me.StrtPt.x), CStr(Me.StrtPt.y), CStr(Me.StrtPt.z)})
                off.WriteLine("children [")
                off.WriteLine("Transform {")
                FileClose(1)

                If shapeopt = "b" Then     ' Shape of output is Box
                    trans(fn, New String() {CStr(Me.length * 0.5), CStr(Me.width * 0.5), CStr(Me.height * 0.5)})      'trans(fn, New String() {CStr(Me.length / 2), CStr(Me.width / 2), CStr(Me.height / 2)})       
                Else
                    trans(fn, New String() {CStr(Me.length), CStr(Me.length), CStr(Me.height * 0.5)})     'trans(fn, New String() {CStr(Me.length), CStr(Me.length), CStr(Me.height / 2)})
                End If

                off.WriteLine("children [")
                FileClose(1)

                If shapeopt = "b" Then
                    SetPolygon(fn, New String() {CStr(Me.length), CStr(Me.width), CStr(Me.height)}, itmnm, wt, qtyflg)       'SetPolygon is method to create Box with x y z dimensions

                    'off.Close()
                    'Stop

                Else
                    '---------------- 
                End If

                off.WriteLine("appearance Appearance {")
                If tex <> "" Then
                    off.WriteLine("texture ImageTexture {")
                    off.WriteLine("url " & dq & tex & dq)
                    off.WriteLine("}")
                End If

                off.WriteLine("material Material {")
                FileClose(1)

                'transp(fn, transpx, col)    'Method transp is Diffuser color R G B and Transparancy

                DifusColr(fn, transpx, col)    'Method transp is Diffuser color R G B and Transparancy

                'Stop

                If DbxFlgO Then
                    transpx = "0"
                End If

                Transprncy(fn, transpx, col)    'Visiblity or transparancy is managed

                off.WriteLine("}")
                off.WriteLine("}")

                FileClose(1)

                '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                txtopt = False
                If txtopt Then
                    'fileopen(1, fn, OpenMode.Append)

                    'attention

                    Dim txtcol As String = "diffuseColor 1 1 1"

                    Dim sz As Double
                    off.WriteLine("Transform {")
                    off.WriteLine("translation 0 " & CStr(Me.width * 1.05 / 2) & " 0")
                    off.WriteLine("children [")
                    off.WriteLine("Transform {")
                    off.WriteLine("rotation 0 1 0 -3.14")
                    off.WriteLine("children")
                    off.WriteLine("Transform {")
                    off.WriteLine("rotation 1 0 0 -1.57")
                    off.WriteLine("children")
                    off.WriteLine("Shape {")
                    off.WriteLine("geometry Text {")
                    If method = 1 Or method = 5 Then
                        itmnm = "R"
                    End If
                    If method = 2 Then
                        itmnm = "T"
                    End If
                    If method = 3 Then
                        itmnm = "T"
                    End If
                    If method = 4 Then
                        itmnm = "BK"
                    End If
                    If method = 6 Then
                        itmnm = "BK"
                    End If
                    off.WriteLine("string " & dq & itmnm & dq)
                    off.WriteLine("maxExtent " & Me.length)
                    off.WriteLine("fontStyle FontStyle {")
                    sz = Me.width * 3
                    off.WriteLine("size " & CStr(sz))
                    off.WriteLine("justify [" & dq & "MIDDLE" & dq & "," & dq & "MIDDLE" & dq & "]")

                    off.WriteLine("}")
                    off.WriteLine("}")
                    off.WriteLine("appearance Appearance {")
                    off.WriteLine("material Material {")
                    off.WriteLine(txtcol)
                    off.WriteLine("transparency 0")
                    off.WriteLine("}")
                    off.WriteLine("}")
                    off.WriteLine("}")
                    off.WriteLine("}")
                    off.WriteLine("}")
                    off.WriteLine("]")
                    off.WriteLine("}")

                    off.WriteLine("Transform {")
                    off.WriteLine("translation 0 -" & CStr(Me.width * 1.05 / 2) & " 0")
                    off.WriteLine("children [")
                    off.WriteLine("Transform {")
                    off.WriteLine("rotation 1 0 0 1.57")
                    off.WriteLine("children")
                    off.WriteLine("Shape {")
                    off.WriteLine("geometry Text {")
                    If method = 1 Or method = 5 Then
                        itmnm = "L"
                    End If
                    If method = 2 Then
                        itmnm = "BT"
                    End If
                    If method = 3 Then
                        itmnm = "BT"
                    End If
                    If method = 4 Then
                        itmnm = "F"
                    End If
                    If method = 6 Then
                        itmnm = "F"
                    End If
                    off.WriteLine("string " & dq & itmnm & dq)
                    off.WriteLine("maxExtent " & Me.length)
                    off.WriteLine("fontStyle FontStyle {")
                    sz = Me.width * 3
                    off.WriteLine("size " & CStr(sz))
                    off.WriteLine("justify [" & dq & "MIDDLE" & dq & "," & dq & "MIDDLE" & dq & "]")
                    off.WriteLine("}")
                    off.WriteLine("}")
                    off.WriteLine("appearance Appearance {")
                    off.WriteLine("material Material {")
                    off.WriteLine(txtcol)
                    off.WriteLine("transparency 0")
                    off.WriteLine("}")
                    off.WriteLine("}")
                    off.WriteLine("}")
                    off.WriteLine("}")
                    off.WriteLine("]")
                    off.WriteLine("}")

                    off.WriteLine("Transform {")
                    off.WriteLine("translation " & CStr(Me.length * 1.05 / 2) & " 0 0")
                    off.WriteLine("children [")
                    off.WriteLine("Transform {")
                    off.WriteLine("rotation 1 0 0 1.57")
                    off.WriteLine("children")
                    off.WriteLine("Transform {")
                    off.WriteLine("rotation 0 1 0 1.57")
                    off.WriteLine("children")
                    off.WriteLine("Shape {")
                    off.WriteLine("geometry Text {")
                    If method = 1 Or method = 2 Then
                        itmnm = "F"
                    End If
                    If method = 3 Then
                        itmnm = "R"
                    End If
                    If method = 4 Then
                        itmnm = "R"
                    End If
                    If method = 5 Then
                        itmnm = "T"
                    End If
                    If method = 6 Then
                        itmnm = "T"
                    End If
                    off.WriteLine("string " & dq & itmnm & dq)
                    off.WriteLine("maxExtent " & Me.width)
                    off.WriteLine("fontStyle FontStyle {")
                    sz = Me.length * 3
                    off.WriteLine("size " & CStr(sz))
                    off.WriteLine("justify [" & dq & "MIDDLE" & dq & "," & dq & "MIDDLE" & dq & "]")
                    off.WriteLine("}")
                    off.WriteLine("}")
                    off.WriteLine("appearance Appearance {")
                    off.WriteLine("material Material {")
                    off.WriteLine(txtcol)
                    off.WriteLine("transparency 0")
                    off.WriteLine("}")
                    off.WriteLine("}")
                    off.WriteLine("}")
                    off.WriteLine("}")
                    off.WriteLine("}")
                    off.WriteLine("]")
                    off.WriteLine("}")

                    off.WriteLine("Transform {")
                    off.WriteLine("translation -" & CStr(Me.length * 1.05 / 2) & " 0 0")
                    off.WriteLine("children [")
                    off.WriteLine("Transform {")
                    off.WriteLine("rotation 1 0 0 1.57")
                    off.WriteLine("children")
                    off.WriteLine("Transform {")
                    off.WriteLine("rotation 0 1 0 -1.57")
                    off.WriteLine("children")
                    off.WriteLine("Shape {")
                    off.WriteLine("geometry Text {")
                    If method = 1 Or method = 2 Then
                        itmnm = "BK"
                    End If
                    If method = 3 Then
                        itmnm = "L"
                    End If
                    If method = 4 Then
                        itmnm = "L"
                    End If
                    If method = 5 Then
                        itmnm = "BT"
                    End If
                    If method = 6 Then
                        itmnm = "BT"
                    End If
                    off.WriteLine("string " & dq & itmnm & dq)
                    off.WriteLine("maxExtent " & Me.width)
                    off.WriteLine("fontStyle FontStyle {")
                    sz = Me.length * 3
                    off.WriteLine("size " & CStr(sz))
                    off.WriteLine("justify [" & dq & "MIDDLE" & dq & "," & dq & "MIDDLE" & dq & "]")
                    off.WriteLine("}")
                    off.WriteLine("}")
                    off.WriteLine("appearance Appearance {")
                    off.WriteLine("material Material {")
                    off.WriteLine(txtcol)
                    off.WriteLine("transparency 0")
                    off.WriteLine("}")
                    off.WriteLine("}")
                    off.WriteLine("}")
                    off.WriteLine("}")
                    off.WriteLine("}")
                    off.WriteLine("]")
                    off.WriteLine("}")

                    off.WriteLine("Transform {")
                    off.WriteLine("translation 0 0 " & CStr(Me.height * 1.05 / 2))
                    off.WriteLine("children [")
                    off.WriteLine("Transform {")
                    off.WriteLine("rotation 0 0 1 1.57")
                    off.WriteLine("children")
                    off.WriteLine("Shape {")
                    off.WriteLine("geometry Text {")
                    If method = 1 Or method = 4 Then
                        itmnm = "T"
                    End If
                    If method = 2 Then
                        itmnm = "L"
                    End If
                    If method = 3 Then
                        itmnm = "F"
                    End If
                    If method = 5 Then
                        itmnm = "BK"
                    End If
                    If method = 6 Then
                        itmnm = "F"
                    End If

                    off.WriteLine("string " & dq & itmnm & dq)
                    off.WriteLine("maxExtent " & Me.width)
                    off.WriteLine("fontStyle FontStyle {")
                    sz = Me.height * 3
                    off.WriteLine("size " & CStr(sz))
                    off.WriteLine("justify [" & dq & "MIDDLE" & dq & "," & dq & "MIDDLE" & dq & "]")
                    off.WriteLine("}")
                    off.WriteLine("}")
                    off.WriteLine("appearance Appearance {")
                    off.WriteLine("material Material {")
                    off.WriteLine(txtcol)
                    off.WriteLine("transparency 0")
                    off.WriteLine("}")
                    off.WriteLine("}")
                    off.WriteLine("}")
                    off.WriteLine("}")
                    off.WriteLine("]")
                    off.WriteLine("}")

                    off.WriteLine("Transform {")
                    off.WriteLine("translation 0 0 -" & CStr(Me.height * 1.05 / 2))
                    off.WriteLine("children [")
                    off.WriteLine("Transform {")
                    off.WriteLine("rotation 0 0 1 1.57")
                    off.WriteLine("children")
                    off.WriteLine("Shape {")
                    off.WriteLine("geometry Text {")

                    If method = 1 Or method = 4 Then
                        itmnm = "BT"
                    End If
                    If method = 2 Then
                        itmnm = "R"
                    End If
                    If method = 3 Then
                        itmnm = "BK"
                    End If
                    If method = 5 Then
                        itmnm = "F"
                    End If
                    If method = 6 Then
                        itmnm = "R"
                    End If

                    off.WriteLine("string " & dq & itmnm & dq)
                    off.WriteLine("maxExtent " & Me.width)
                    off.WriteLine("fontStyle FontStyle {")
                    sz = Me.height * 3
                    off.WriteLine("size " & CStr(sz))
                    off.WriteLine("justify [" & dq & "MIDDLE" & dq & "," & dq & "MIDDLE" & dq & "]")
                    off.WriteLine("}")
                    off.WriteLine("}")
                    off.WriteLine("appearance Appearance {")
                    off.WriteLine("material Material {")
                    off.WriteLine(txtcol)
                    off.WriteLine("transparency 0")
                    off.WriteLine("}")
                    off.WriteLine("}")
                    off.WriteLine("}")
                    off.WriteLine("}")
                    off.WriteLine("]")
                    off.WriteLine("}")

                    FileClose(1)
                End If
                '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

                'fileopen(1, fn, OpenMode.Append)

                off.WriteLine("]")
                off.WriteLine("}")
                off.WriteLine("]")
                off.WriteLine("}")
                off.WriteLine("")
                FileClose(1)

                'Stop
                'off.Close()
                'Stop

            End If

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Fatal error in AutoDraw" & vbCrLf & "VRML Programme writting is failure!", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            FileClose(1)
            conn.Close()
            off.Close()
            'Form8.Close()
            'MsgBox("Exception :: In method 'AutoDraw'  " & vbCrLf & "Due to an error application exit!...")
            Application.Exit()
        Finally
            FileClose()
        End Try

        'Stop

        Try
            If dataopt Then
                Dim cmd As New OleDb.OleDbCommand
                cmd.Connection = conn
                cmd.CommandText = "insert into stuffdata values('" & matname & "'," & CStr(Me.StrtPt.x) & "," & CStr(Me.StrtPt.y) & "," & CStr(Me.StrtPt.z) & "," & CStr(Me.length) & "," & CStr(Me.width) & "," & CStr(Me.height) & "," & CStr(method) & ",'" & col & "','" & tex & "',0)"
                cmd.ExecuteNonQuery()
                'conn.Close()  'Do not Close Connection Here 
                InsrtBxData(matname, Me.StrtPt.x, Me.StrtPt.y, Me.StrtPt.z, Me.length, Me.width, Me.height, method, col, tex, BitemqtyInr)

            End If

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in AutoDraw" & vbCrLf & "Data insert connection failure!", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'MsgBox("Exception :: In Method 'AutoDraw'  " & vbCrLf & "Data insert connection failure!")
            conn.Close()
            off.Close()
        End Try

    End Sub

    Public Sub draw(ByVal fn As String, ByVal col As String, ByVal transpx As Single, ByVal tex As String, ByVal itmnm As String, ByVal wt As Single, ByVal qtyflg As Boolean, ByVal txtopt As Boolean, ByVal matname As String, ByVal method As Integer, ByVal dataopt As Boolean, ByVal shapeopt As String)
        Dim dq As Char = Chr(34)
        'fileopen(1, fn, OpenMode.Append)
        off.WriteLine("Transform {")

        FileClose(1)
        trans(fn, New String() {CStr(Me.StrtPt.x), CStr(Me.StrtPt.y), CStr(Me.StrtPt.z)})
        'fileopen(1, fn, OpenMode.Append)
        off.WriteLine("children [")
        off.WriteLine("Transform {")
        FileClose(1)
        'next line is commented out today
        If shapeopt = "b" Then
            trans(fn, New String() {CStr(Me.length / 2), CStr(Me.width / 2), CStr(Me.height / 2)})
        Else
            'next line is added today
            trans(fn, New String() {CStr(Me.length), CStr(Me.length), CStr(Me.height / 2)})
        End If
        'fileopen(1, fn, OpenMode.Append)
        off.WriteLine("children [")
        FileClose(1)
        'next 3 lines are new
        If shapeopt = "c" Then
            off.WriteLine("Transform {")
            off.WriteLine("rotation 1 0 0 -1.57")
            off.WriteLine("children [")
        End If
        'watch next 2 lines
        If shapeopt = "b" Then
            placecube(fn, New String() {CStr(Me.length), CStr(Me.width), CStr(Me.height)}, itmnm, wt, qtyflg)
        Else
            'placecyl(fn, New String() {CStr(Me.length), CStr(Me.width), CStr(Me.height)}, itmnm, wt, qtyflg)
        End If
        'fileopen(1, fn, OpenMode.Append)
        off.WriteLine("appearance Appearance {")
        If tex <> "" Then
            off.WriteLine("texture ImageTexture {")
            off.WriteLine("url " & dq & tex & dq)
            off.WriteLine("}")
        End If
        'If UCase(col) <> "R" Then
        off.WriteLine("material Material {")
        'End If
        FileClose(1)
        transp(fn, transpx, col)
        'fileopen(1, fn, OpenMode.Append)
        off.WriteLine("}")
        off.WriteLine("}")
        'next line is new
        If shapeopt = "c" Then
            off.WriteLine("]}")
        End If
        'off.writeline( "]")
        'off.writeline( "}")
        FileClose(1)
        txtopt = False
        If txtopt Then
            'fileopen(1, fn, OpenMode.Append)

            'attention

            Dim txtcol As String = "diffuseColor 1 1 1"
            'If UCase(col) = "R" Then
            '    txtcol = "diffuseColor 0 1 0"
            'End If
            'If UCase(col) = "G" Then
            '    txtcol = "diffuseColor 0 0 1"
            'End If
            'If UCase(col) = "B" Then
            '    txtcol = "diffuseColor 1 0 0"
            'End If
            Dim sz As Double
            off.WriteLine("Transform {")
            off.WriteLine("translation 0 " & CStr(Me.width * 1.05 / 2) & " 0")
            off.WriteLine("children [")
            off.WriteLine("Transform {")
            off.WriteLine("rotation 0 1 0 -3.14")
            off.WriteLine("children")
            off.WriteLine("Transform {")
            off.WriteLine("rotation 1 0 0 -1.57")
            off.WriteLine("children")
            off.WriteLine("Shape {")
            off.WriteLine("geometry Text {")
            If method = 1 Or method = 5 Then
                itmnm = "R"
            End If
            If method = 2 Then
                itmnm = "T"
            End If
            If method = 3 Then
                itmnm = "T"
            End If
            If method = 4 Then
                itmnm = "BK"
            End If
            If method = 6 Then
                itmnm = "BK"
            End If
            off.WriteLine("string " & dq & itmnm & dq)
            off.WriteLine("maxExtent " & Me.length)
            off.WriteLine("fontStyle FontStyle {")
            sz = Me.width * 3
            off.WriteLine("size " & CStr(sz))
            off.WriteLine("justify [" & dq & "MIDDLE" & dq & "," & dq & "MIDDLE" & dq & "]")

            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("appearance Appearance {")
            off.WriteLine("material Material {")
            off.WriteLine(txtcol)
            off.WriteLine("transparency 0")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("]")
            off.WriteLine("}")

            off.WriteLine("Transform {")
            off.WriteLine("translation 0 -" & CStr(Me.width * 1.05 / 2) & " 0")
            off.WriteLine("children [")
            off.WriteLine("Transform {")
            off.WriteLine("rotation 1 0 0 1.57")
            off.WriteLine("children")
            off.WriteLine("Shape {")
            off.WriteLine("geometry Text {")
            If method = 1 Or method = 5 Then
                itmnm = "L"
            End If
            If method = 2 Then
                itmnm = "BT"
            End If
            If method = 3 Then
                itmnm = "BT"
            End If
            If method = 4 Then
                itmnm = "F"
            End If
            If method = 6 Then
                itmnm = "F"
            End If
            off.WriteLine("string " & dq & itmnm & dq)
            off.WriteLine("maxExtent " & Me.length)
            off.WriteLine("fontStyle FontStyle {")
            sz = Me.width * 3
            off.WriteLine("size " & CStr(sz))
            off.WriteLine("justify [" & dq & "MIDDLE" & dq & "," & dq & "MIDDLE" & dq & "]")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("appearance Appearance {")
            off.WriteLine("material Material {")
            off.WriteLine(txtcol)
            off.WriteLine("transparency 0")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("]")
            off.WriteLine("}")

            off.WriteLine("Transform {")
            off.WriteLine("translation " & CStr(Me.length * 1.05 / 2) & " 0 0")
            off.WriteLine("children [")
            off.WriteLine("Transform {")
            off.WriteLine("rotation 1 0 0 1.57")
            off.WriteLine("children")
            off.WriteLine("Transform {")
            off.WriteLine("rotation 0 1 0 1.57")
            off.WriteLine("children")
            off.WriteLine("Shape {")
            off.WriteLine("geometry Text {")
            If method = 1 Or method = 2 Then
                itmnm = "F"
            End If
            If method = 3 Then
                itmnm = "R"
            End If
            If method = 4 Then
                itmnm = "R"
            End If
            If method = 5 Then
                itmnm = "T"
            End If
            If method = 6 Then
                itmnm = "T"
            End If
            off.WriteLine("string " & dq & itmnm & dq)
            off.WriteLine("maxExtent " & Me.width)
            off.WriteLine("fontStyle FontStyle {")
            sz = Me.length * 3
            off.WriteLine("size " & CStr(sz))
            off.WriteLine("justify [" & dq & "MIDDLE" & dq & "," & dq & "MIDDLE" & dq & "]")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("appearance Appearance {")
            off.WriteLine("material Material {")
            off.WriteLine(txtcol)
            off.WriteLine("transparency 0")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("]")
            off.WriteLine("}")



            off.WriteLine("Transform {")
            off.WriteLine("translation -" & CStr(Me.length * 1.05 / 2) & " 0 0")
            off.WriteLine("children [")
            off.WriteLine("Transform {")
            off.WriteLine("rotation 1 0 0 1.57")
            off.WriteLine("children")
            off.WriteLine("Transform {")
            off.WriteLine("rotation 0 1 0 -1.57")
            off.WriteLine("children")
            off.WriteLine("Shape {")
            off.WriteLine("geometry Text {")
            If method = 1 Or method = 2 Then
                itmnm = "BK"
            End If
            If method = 3 Then
                itmnm = "L"
            End If
            If method = 4 Then
                itmnm = "L"
            End If
            If method = 5 Then
                itmnm = "BT"
            End If
            If method = 6 Then
                itmnm = "BT"
            End If
            off.WriteLine("string " & dq & itmnm & dq)
            off.WriteLine("maxExtent " & Me.width)
            off.WriteLine("fontStyle FontStyle {")
            sz = Me.length * 3
            off.WriteLine("size " & CStr(sz))
            off.WriteLine("justify [" & dq & "MIDDLE" & dq & "," & dq & "MIDDLE" & dq & "]")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("appearance Appearance {")
            off.WriteLine("material Material {")
            off.WriteLine(txtcol)
            off.WriteLine("transparency 0")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("]")
            off.WriteLine("}")


            off.WriteLine("Transform {")
            off.WriteLine("translation 0 0 " & CStr(Me.height * 1.05 / 2))
            off.WriteLine("children [")
            off.WriteLine("Transform {")
            off.WriteLine("rotation 0 0 1 1.57")
            off.WriteLine("children")
            off.WriteLine("Shape {")
            off.WriteLine("geometry Text {")
            If method = 1 Or method = 4 Then
                itmnm = "T"
            End If
            If method = 2 Then
                itmnm = "L"
            End If
            If method = 3 Then
                itmnm = "F"
            End If
            If method = 5 Then
                itmnm = "BK"
            End If
            If method = 6 Then
                itmnm = "F"
            End If
            off.WriteLine("string " & dq & itmnm & dq)
            off.WriteLine("maxExtent " & Me.width)
            off.WriteLine("fontStyle FontStyle {")
            sz = Me.height * 3
            off.WriteLine("size " & CStr(sz))
            off.WriteLine("justify [" & dq & "MIDDLE" & dq & "," & dq & "MIDDLE" & dq & "]")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("appearance Appearance {")
            off.WriteLine("material Material {")
            off.WriteLine(txtcol)
            off.WriteLine("transparency 0")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("]")
            off.WriteLine("}")


            off.WriteLine("Transform {")
            off.WriteLine("translation 0 0 -" & CStr(Me.height * 1.05 / 2))
            off.WriteLine("children [")
            off.WriteLine("Transform {")
            off.WriteLine("rotation 0 0 1 1.57")
            off.WriteLine("children")
            off.WriteLine("Shape {")
            off.WriteLine("geometry Text {")
            If method = 1 Or method = 4 Then
                itmnm = "BT"
            End If
            If method = 2 Then
                itmnm = "R"
            End If
            If method = 3 Then
                itmnm = "BK"
            End If
            If method = 5 Then
                itmnm = "F"
            End If
            If method = 6 Then
                itmnm = "R"
            End If
            off.WriteLine("string " & dq & itmnm & dq)
            off.WriteLine("maxExtent " & Me.width)
            off.WriteLine("fontStyle FontStyle {")
            sz = Me.height * 3
            off.WriteLine("size " & CStr(sz))
            off.WriteLine("justify [" & dq & "MIDDLE" & dq & "," & dq & "MIDDLE" & dq & "]")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("appearance Appearance {")
            off.WriteLine("material Material {")
            off.WriteLine(txtcol)
            off.WriteLine("transparency 0")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("]")
            off.WriteLine("}")
            FileClose(1)
        End If

        'attention

        'fileopen(1, fn, OpenMode.Append)

        off.WriteLine("]")
        off.WriteLine("}")
        off.WriteLine("]")
        off.WriteLine("}")
        FileClose(1)

        If dataopt Then
            Dim cmd As New OleDb.OleDbCommand
            cmd.Connection = conn
            cmd.CommandText = "insert into stuffdata values('" & matname & "'," & CStr(Me.StrtPt.x) & "," & CStr(Me.StrtPt.y) & "," & CStr(Me.StrtPt.z) & "," & CStr(Me.length) & "," & CStr(Me.width) & "," & CStr(Me.height) & "," & CStr(method) & ",'" & col & "','" & tex & "',0)"
            cmd.ExecuteNonQuery()
        End If



    End Sub

    Public Sub AutoDraw_Wad(ByVal fn As String, ByVal col As String, ByVal transpx As Single, ByVal tex As String, ByVal itmnm As String, ByVal wt As Single, ByVal qtyflg As Boolean, ByVal txtopt As Boolean, ByVal matname As String, ByVal method As Integer, ByVal dataopt As Boolean, ByVal shapeopt As String)

        'Stop

        Try

            Dim X As Double = Me.StrtPt.x
            Dim Y As Double = Me.StrtPt.y
            Dim Z As Double = Me.StrtPt.z


            Dim dq As Char = Chr(34)

            off.WriteLine("Transform {")        ' off.WriteLine  => fileopen(1, fn, OpenMode.Append)
            FileClose(1)

            trans(fn, New String() {CStr(Me.StrtPt.x), CStr(Me.StrtPt.y), CStr(Me.StrtPt.z)})
            off.WriteLine("children [")
            off.WriteLine("Transform {")
            FileClose(1)

            trans(fn, New String() {CStr(Me.length * 0.5), CStr(Me.width * 0.5), CStr(Me.height * 0.5)})      'trans(fn, New String() {CStr(Me.length / 2), CStr(Me.width / 2), CStr(Me.height / 2)})       

            off.WriteLine("children [")
            FileClose(1)


            SetPolygon(fn, New String() {CStr(Me.length), CStr(Me.width), CStr(Me.height)}, itmnm, wt, qtyflg)       'SetPolygon is method to create Box with x y z dimensions

            off.WriteLine("appearance Appearance {")

            If tex <> "" Then
                off.WriteLine("texture ImageTexture {")
                off.WriteLine("url " & dq & tex & dq)
                off.WriteLine("}")
            End If

            off.WriteLine("material Material {")
            FileClose(1)

            DifusColr(fn, transpx, col)    'Method transp is Diffuser color R G B and Transparancy

            Transprncy(fn, transpx, col)    'Visiblity or transparancy is managed

            off.WriteLine("}")
            off.WriteLine("}")

            FileClose(1)

            off.WriteLine("]")
            off.WriteLine("}")
            off.WriteLine("]")
            off.WriteLine("}")
            off.WriteLine("")
            FileClose(1)

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Fatal error in AutoDraw" & vbCrLf & "VRML Programme writting is failure!", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            FileClose(1)
            conn.Close()
            off.Close()
            Application.Exit()
        Finally
            FileClose()
        End Try

        Try
            If dataopt Then
                Dim cmd As New OleDb.OleDbCommand
                cmd.Connection = conn
                cmd.CommandText = "insert into stuffdata values('" & matname & "'," & CStr(Me.StrtPt.x) & "," & CStr(Me.StrtPt.y) & "," & CStr(Me.StrtPt.z) & "," & CStr(Me.length) & "," & CStr(Me.width) & "," & CStr(Me.height) & "," & CStr(method) & ",'" & col & "','" & tex & "',0)"
                cmd.ExecuteNonQuery()
                InsrtBxData(matname, Me.StrtPt.x, Me.StrtPt.y, Me.StrtPt.z, Me.length, Me.width, Me.height, method, col, tex, BitemqtyInr)
            End If

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in AutoDraw" & vbCrLf & "Data insert connection failure!", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            conn.Close()
            off.Close()
        End Try

    End Sub

    Public Sub AutoDrawPly(ByVal fn As String, ByVal col As String, ByVal transpx As Single, ByVal tex As String, ByVal itmnm As String, ByVal wt As Single, ByVal qtyflg As Boolean, ByVal txtopt As Boolean, ByVal matname As String, ByVal method As Integer, ByVal dataopt As Boolean, ByVal shapeopt As String)

        Try
            Dim X As Double = Me.StrtPt.x
            Dim Y As Double = Me.StrtPt.y
            Dim Z As Double = Me.StrtPt.z

            Dim Dbx As New DBxCntDor()

            Dim dq As Char = Chr(34)

            off.WriteLine("Transform {")
            FileClose(1)

            trans(fn, New String() {CStr(Me.StrtPt.x), CStr(Me.StrtPt.y), CStr(Me.StrtPt.z)})
            off.WriteLine("children [")
            off.WriteLine("Transform {")
            FileClose(1)

            If shapeopt = "b" Then     ' Shape of output is Box
                trans(fn, New String() {CStr(Me.length * 0.5), CStr(Me.width * 0.5), CStr(Me.height * 0.5)})      'trans(fn, New String() {CStr(Me.length / 2), CStr(Me.width / 2), CStr(Me.height / 2)})       
            Else
                trans(fn, New String() {CStr(Me.length), CStr(Me.length), CStr(Me.height * 0.5)})     'trans(fn, New String() {CStr(Me.length), CStr(Me.length), CStr(Me.height / 2)})
            End If

            off.WriteLine("children [")
            FileClose(1)

            If shapeopt = "b" Then
                SetPolygon(fn, New String() {CStr(Me.length), CStr(Me.width), CStr(Me.height)}, itmnm, wt, qtyflg)       'SetPolygon is method to create Box with x y z dimensions
            Else
                '---------------- 
            End If

            off.WriteLine("appearance Appearance {")
            If tex <> "" Then
                off.WriteLine("texture ImageTexture {")
                off.WriteLine("url " & dq & tex & dq)
                off.WriteLine("}")
            End If

            off.WriteLine("material Material {")
            FileClose(1)

            DifusColr(fn, transpx, col)    'Method transp is Diffuser color R G B and Transparancy

            Transprncy(fn, transpx, col)    'Visiblity or transparancy is managed

            off.WriteLine("}")
            off.WriteLine("}")

            FileClose(1)

            'fileopen(1, fn, OpenMode.Append)

            off.WriteLine("]")
            off.WriteLine("}")
            off.WriteLine("]")
            off.WriteLine("}")
            off.WriteLine("")
            FileClose(1)

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Fatal error in AutoDraw" & vbCrLf & "VRML Programme writting is failure!", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            FileClose(1)
            conn.Close()
            off.Close()
            Application.Exit()
        Finally
            FileClose()
        End Try

        'Stop
        Try
            If dataopt Then
                Dim cmd As New OleDb.OleDbCommand
                cmd.Connection = conn
                cmd.CommandText = "insert into stuffdata values('" & matname & "'," & CStr(Me.StrtPt.x) & "," & CStr(Me.StrtPt.y) & "," & CStr(Me.StrtPt.z) & "," & CStr(Me.length) & "," & CStr(Me.width) & "," & CStr(Me.height) & "," & CStr(method) & ",'" & col & "','" & tex & "',0)"
                cmd.ExecuteNonQuery()
                'conn.Close()  'Do not Close Connection Here 
                InsrtBxData(matname, Me.StrtPt.x, Me.StrtPt.y, Me.StrtPt.z, Me.length, Me.width, Me.height, method, col, tex, BitemqtyInr)
            End If

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in AutoDrawPly" & vbCrLf & "Data insert connection failure!", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            conn.Close()
            off.Close()
        End Try

    End Sub

    Public Sub Auto3DBx_Move(ByVal FN As String, ByVal Col As String, ByVal Transpx As Single, ByVal Tex As String, ByVal Itmnm As String, ByVal Wt As Single, ByVal QtyFlg As Boolean, ByVal TxtOpt As Boolean, ByVal MatName As String, ByVal Method As Integer, ByVal DataOpt As Boolean, ByVal ShapeOpt As String, ByVal ImgNm As String)

        'Try
        '    Dim dq As Char = Chr(34)
        '    Dim X As Double = Me.StrtPt.x
        '    Dim Y As Double = Me.StrtPt.y
        '    Dim Z As Double = Me.StrtPt.z

        '    off.WriteLine("Transform {")
        '    FileClose(1)

        '    BxTrans(FNm, New String() {CStr(Me.StrtPt.x), CStr(Me.StrtPt.y), CStr(Me.StrtPt.z)})

        '    off.WriteLine("children [")
        '    off.WriteLine("Transform {")
        '    FileClose(1)

        '    If ShapeOpt = "b" Then

        '    End If

        '    Dim Xbx As Double = Me.length * 0.5
        '    Dim Ybx As Double = Me.width * 0.5
        '    Dim Zbx As Double = Me.height * 0.5

        '    BxTrans(FNm, New String() {CStr(Xbx), CStr(Ybx), CStr(Zbx)})

        '    off.WriteLine("children [")

        '    SetPolygon(FNm, New String() {CStr(Me.length), CStr(Me.width), CStr(Me.height)}, Itmnm, Wt, QtyFlg)

        '    off.WriteLine("appearance Appearance {")

        '    If Tex <> "" Then
        '        off.WriteLine("texture ImageTexture {")
        '        off.WriteLine("url " & dq & Tex & dq)
        '        off.WriteLine("}")
        '    End If

        '    DiffCol(FNm, Transpx, Col)    'Method transp is Diffuser color R G B and Transparancy

        '    Transprncy(FNm, Transpx, Col)    'Visiblity or transparancy is managed

        '    off.WriteLine("}")
        '    off.WriteLine("}")

        '    FileClose(1)

        '    off.WriteLine("]")
        '    off.WriteLine("}")
        '    off.WriteLine("]")
        '    off.WriteLine("}")
        '    off.WriteLine("")
        '    FileClose(1)

        'Catch Err As Exception
        '    MsgBox(Err.Message)
        '    MessageBox.Show("Error in Auto3DBx", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try


        '////////////////////////////////////////////////////////


        '##################################

        'If lblNM <> ImgNm Then

        '    lblNM = ImgNm

        '    If Cons.State = ConnectionState.Closed Then Cons.Open()
        '    Dim CmdR As New OleDb.OleDbCommand
        '    Dim RdrR As OleDb.OleDbDataReader
        '    CmdR.Connection = Cons

        '    CmdR.CommandText = "select INm, XtL, YtW, ZtH from pgRecord"
        '    RdrR = CmdR.ExecuteReader

        '    Do While (RdrR.Read())

        '        Inm = RdrR("INm")
        '        Xl3d = RdrR("XtL")
        '        Yl3d = RdrR("YtW")
        '        Zl3d = RdrR("ZtH")

        '        If conn.State = ConnectionState.Closed Then conn.Open()
        '        Dim ODc As New OleDb.OleDbCommand

        '        ODc.Connection = conn
        '        ODc.CommandText = "insert into pgCord values (" & CStr(Gdn) & ",'" & Inm & "'," & CStr(Xl3d) & "," & CStr(Yl3d) & "," & CStr(Zl3d) & ")"
        '        ODc.ExecuteNonQuery()

        '    Loop

        '    Gdn += 1

        'End If

        '###########

        Try

            Dim X As Double = Me.StrtPt.x
            Dim Y As Double = Me.StrtPt.y
            Dim Z As Double = Me.StrtPt.z

            Dim Len As Double = Me.length
            Dim wid As Double = Me.width
            Dim Hei As Double = Me.height

            Dim dq As Char = Chr(34)

            off.WriteLine("Transform {")        ' off.WriteLine  => fileopen(1, fn, OpenMode.Append)
            FileClose(1)

            Dim BdoPtx As Double = 0
            Dim BdoPty As Double = 0
            Dim BdoPtz As Double = 0
            Dim BdoAngle As Double = 0

            trans(FN, New String() {CStr(Me.StrtPt.x), CStr(Me.StrtPt.y), CStr(Me.StrtPt.z)})

            '*****^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

            'Dim Ytm As Double = Y - Me.width
            ''Dim Ytm As Double = Y - Yl3d

            'If Ytm > Yl3d Then
            '    '    '    X = X - Me.length
            '    X = X - Xl3d
            '    '    '    'Y = Y - Yl3d
            'End If

            'If Y > Yl3d Then
            '    X = X - Xl3d
            'End If

            'trans(FN, New String() {CStr(X), CStr(Y), CStr(Z)})

            '*****^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

            off.WriteLine("children [")
            off.WriteLine("Transform {")
            FileClose(1)

            If ShapeOpt = "b" Then     ' Shape of output is Box
                trans(FN, New String() {CStr(Me.length * 0.5), CStr(Me.width * 0.5), CStr(Me.height * 0.5)})      'trans(fn, New String() {CStr(Me.length / 2), CStr(Me.width / 2), CStr(Me.height / 2)})       
            Else
                trans(FN, New String() {CStr(Me.length), CStr(Me.length), CStr(Me.height * 0.5)})     'trans(fn, New String() {CStr(Me.length), CStr(Me.length), CStr(Me.height / 2)})
            End If

            off.WriteLine("children [")
            FileClose(1)

            If ShapeOpt = "b" Then
                SetPolygon(FN, New String() {CStr(Me.length), CStr(Me.width), CStr(Me.height)}, Itmnm, Wt, QtyFlg)       'SetPolygon is method to create Box with x y z dimensions

                'off.Close()
                'Stop

            Else
                '---------------- 
            End If

            off.WriteLine("appearance Appearance {")
            If Tex <> "" Then
                off.WriteLine("texture ImageTexture {")
                off.WriteLine("url " & dq & Tex & dq)
                off.WriteLine("}")
            End If

            off.WriteLine("material Material {")
            FileClose(1)

            DifusColr(FN, Transpx, Col)    'Method transp is Diffuser color R G B and Transparancy

            Transprncy(FN, Transpx, Col)    'Visiblity or transparancy is managed

            off.WriteLine("}")
            off.WriteLine("}")

            FileClose(1)

            'fileopen(1, fn, OpenMode.Append)

            off.WriteLine("]")
            off.WriteLine("}")
            off.WriteLine("]")
            off.WriteLine("}")
            off.WriteLine("")
            FileClose(1)

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Fatal error in AutoDraw" & vbCrLf & "VRML Programme writting is failure!", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            FileClose(1)
            conn.Close()
            off.Close()
            'Form8.Close()
            'MsgBox("Exception :: In method 'AutoDraw'  " & vbCrLf & "Due to an error application exit!...")
            Application.Exit()
        Finally
            FileClose()
        End Try
        'Stop

        '&&&&&&&&&&&&&&&&&&

        'If conn.State = ConnectionState.Closed Then conn.Open()

        'Dim Cmd As New OleDb.OleDbCommand
        'Cmd.Connection = conn
        'Cmd.CommandText = "delete from pgRecord"
        'Cmd.ExecuteNonQuery()

        'Dim OCmd As New OleDb.OleDbCommand
        'OCmd.Connection = conn
        'OCmd.CommandText = "insert into pgRecord values ('" & Itmnm & "'," & CStr(Me.length) & "," & CStr(Me.width) & "," & CStr(Me.height) & "," & CStr(Me.StrtPt.x) & "," & CStr(Me.StrtPt.y) & "," & CStr(Me.StrtPt.z) & ")"
        'OCmd.ExecuteNonQuery()

        '&&&&&&&&&&&&&&&&&&

        Try
            If DataOpt Then
                Dim cmdc As New OleDb.OleDbCommand
                cmdc.Connection = conn
                cmdc.CommandText = "insert into stuffdata values('" & MatName & "'," & CStr(Me.StrtPt.x) & "," & CStr(Me.StrtPt.y) & "," & CStr(Me.StrtPt.z) & "," & CStr(Me.length) & "," & CStr(Me.width) & "," & CStr(Me.height) & "," & CStr(Method) & ",'" & Col & "','" & Tex & "',0)"
                cmdc.ExecuteNonQuery()
                'conn.Close()  'Do not Close Connection Here 
                InsrtBxData(MatName, Me.StrtPt.x, Me.StrtPt.y, Me.StrtPt.z, Me.length, Me.width, Me.height, Method, Col, Tex, BitemqtyInr)

            End If

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in AutoDraw" & vbCrLf & "Data insert connection failure!", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'MsgBox("Exception :: In Method 'AutoDraw'  " & vbCrLf & "Data insert connection failure!")
            conn.Close()
            off.Close()
        End Try

        '////////////////////////////////////////////////////////

    End Sub

    Public Function SdOps(ByVal pr As Area, ByVal ImgNm As String) As Queue(Of Area)

        Dim X As Double = Me.StrtPt.x
        Dim Y As Double = Me.StrtPt.y
        Dim Z As Double = Me.StrtPt.z

        Dim Len As Double = Me.length
        Dim wid As Double = Me.width
        Dim Hei As Double = Me.height

        Dim ArSa As New Area
        Dim qPr As New Queue(Of Area)
        Dim prL As New Area
        Dim prW As New Area
        Dim prH As New Area
        Dim ItmNm As String = "1"

        If pr.length > Me.length OrElse pr.width > Me.width OrElse pr.height > Me.height Then
            Return Nothing
        End If

        If ItmNm <> ImgNm Then
            Stop
        End If

        If pr.length < Me.length AndAlso pr.StrtPt.x < Xl3d Then

            prL.StrtPt.x = pr.StrtPt.x + Me.length
            prL.StrtPt.y = Me.StrtPt.y
            prL.StrtPt.z = Me.StrtPt.z
            prL.length = Me.length - pr.length
            prL.width = Me.width
            prL.height = Me.height

            If prL.CheckOut Then
                qPr.Enqueue(prL)
            End If
        End If

        If pr.width < Me.width AndAlso pr.StrtPt.y < Yl3d Then

            prW.StrtPt.x = Me.StrtPt.x
            prW.StrtPt.y = pr.StrtPt.y + Me.StrtPt.y
            prW.StrtPt.z = Me.StrtPt.z
            prW.length = Me.length
            prW.width = Me.width - pr.width
            prW.height = Me.height

            If prW.CheckOut Then
                qPr.Enqueue(prW)
            End If
        End If

        If pr.height < Me.height AndAlso pr.StrtPt.z < Zl3d Then

            prH.StrtPt.x = Me.StrtPt.x
            prH.StrtPt.y = Me.StrtPt.y
            prH.StrtPt.z = pr.StrtPt.z + Me.StrtPt.z
            prH.length = Me.length
            prH.width = Me.width
            prH.height = pr.StrtPt.z + Me.StrtPt.z

            If prH.CheckOut Then
                qPr.Enqueue(prH)
            End If

        End If

        Return qPr

    End Function

    Public Sub Auto3DBx(ByVal FN As String, ByVal Col As String, ByVal Transpx As Single, ByVal Tex As String, ByVal Itmnm As String, ByVal Wt As Single, ByVal QtyFlg As Boolean, ByVal TxtOpt As Boolean, ByVal MatName As String, ByVal Method As Integer, ByVal DataOpt As Boolean, ByVal ShapeOpt As String, ByVal ImgNm As String)

        'Try
        '    Dim dq As Char = Chr(34)
        '    Dim X As Double = Me.StrtPt.x
        '    Dim Y As Double = Me.StrtPt.y
        '    Dim Z As Double = Me.StrtPt.z

        '    off.WriteLine("Transform {")
        '    FileClose(1)

        '    BxTrans(FNm, New String() {CStr(Me.StrtPt.x), CStr(Me.StrtPt.y), CStr(Me.StrtPt.z)})

        '    off.WriteLine("children [")
        '    off.WriteLine("Transform {")
        '    FileClose(1)

        '    If ShapeOpt = "b" Then

        '    End If

        '    Dim Xbx As Double = Me.length * 0.5
        '    Dim Ybx As Double = Me.width * 0.5
        '    Dim Zbx As Double = Me.height * 0.5

        '    BxTrans(FNm, New String() {CStr(Xbx), CStr(Ybx), CStr(Zbx)})

        '    off.WriteLine("children [")

        '    SetPolygon(FNm, New String() {CStr(Me.length), CStr(Me.width), CStr(Me.height)}, Itmnm, Wt, QtyFlg)

        '    off.WriteLine("appearance Appearance {")

        '    If Tex <> "" Then
        '        off.WriteLine("texture ImageTexture {")
        '        off.WriteLine("url " & dq & Tex & dq)
        '        off.WriteLine("}")
        '    End If

        '    DiffCol(FNm, Transpx, Col)    'Method transp is Diffuser color R G B and Transparancy

        '    Transprncy(FNm, Transpx, Col)    'Visiblity or transparancy is managed

        '    off.WriteLine("}")
        '    off.WriteLine("}")

        '    FileClose(1)

        '    off.WriteLine("]")
        '    off.WriteLine("}")
        '    off.WriteLine("]")
        '    off.WriteLine("}")
        '    off.WriteLine("")
        '    FileClose(1)

        'Catch Err As Exception
        '    MsgBox(Err.Message)
        '    MessageBox.Show("Error in Auto3DBx", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try


        '////////////////////////////////////////////////////////


        '##################################

        'If Bitemqty = 198 Then
        '    Stop
        'End If

        'If Bitemqty = 15 Then
        '    Stop
        'End If



        Try

            If lblNM <> ImgNm Then

                lblNM = ImgNm

                If Cons.State = ConnectionState.Closed Then Cons.Open()
                Dim CmdR As New OleDb.OleDbCommand
                Dim RdrR As OleDb.OleDbDataReader
                CmdR.Connection = Cons

                CmdR.CommandText = "select INm, XtL, YtW, ZtH from pgRecord"
                RdrR = CmdR.ExecuteReader

                Do While (RdrR.Read())

                    Inm = RdrR("INm")
                    Xl3d = RdrR("XtL")
                    Yl3d = RdrR("YtW")
                    Zl3d = RdrR("ZtH")

                    If conn.State = ConnectionState.Closed Then conn.Open()
                    Dim ODc As New OleDb.OleDbCommand

                    ODc.Connection = conn
                    ODc.CommandText = "insert into pgCord values (" & CStr(Gdn) & ",'" & Inm & "'," & CStr(Xl3d) & "," & CStr(Yl3d) & "," & CStr(Zl3d) & ")"
                    ODc.ExecuteNonQuery()

                Loop

                Gdn += 1

            End If

        Catch ex As Exception
            '    MsgBox(ex.Message)
            '    MsgBox(ex.ToString)
            '    MessageBox.Show("Error in Auto3DBx", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


        '###########

        Try

            Dim X As Double = Me.StrtPt.x
            Dim Y As Double = Me.StrtPt.y
            Dim Z As Double = Me.StrtPt.z

            Dim Len As Double = Me.length
            Dim wid As Double = Me.width
            Dim Hei As Double = Me.height

            'Dim flg_RiCnt As Boolean = False

            If ImgNm = "1" Then

                If Z = 0 AndAlso Y = 0 Then

                    If Not flg_RiCnt Then
                        RiCnt = 0
                        flg_RiCnt = True
                    Else
                        RiCnt += 1
                    End If

                End If

            End If

            Dim dq As Char = Chr(34)

            off.WriteLine("Transform {")        ' off.WriteLine  => fileopen(1, fn, OpenMode.Append)
            FileClose(1)

            'trans(FN, New String() {CStr(Me.StrtPt.x), CStr(Me.StrtPt.y), CStr(Me.StrtPt.z)})

            ' If Gdn = 0 Or Gdn = 1 Then

            '######################
            'If Bitemqty = 13 Then
            '    Stop
            'End If
            '######################

            'Dim Ytm As Double = Y - Me.length

            Dim Ytm As Double = 0

            Ytm = Y - Me.length

            'Dim Ytm As Double = Y - Me.width
            'Dim Ytm As Double = Y - Yl3d

            If Ytm > Yl3d Then
                '    '    X = X - Me.length

                If RiCnt = 1 Then
                    X = X - Xl3d
                End If

                If RiCnt >= 2 Then
                    'Dim rtX As Double = X - Xl3d
                    Dim rtX As Double = 0
                    rtX = X - Xl3d
                    X = X - rtX
                End If

                '    '    Y = Y - Yl3d
            End If

            'End If

            'If Y > Yl3d Then
            '    X = X - Xl3d
            'End If

            trans(FN, New String() {CStr(X), CStr(Y), CStr(Z)})

            off.WriteLine("children [")
            off.WriteLine("Transform {")
            FileClose(1)

            If ShapeOpt = "b" Then     ' Shape of output is Box
                trans(FN, New String() {CStr(Me.length * 0.5), CStr(Me.width * 0.5), CStr(Me.height * 0.5)})      'trans(fn, New String() {CStr(Me.length / 2), CStr(Me.width / 2), CStr(Me.height / 2)})       
            Else
                trans(FN, New String() {CStr(Me.length), CStr(Me.length), CStr(Me.height * 0.5)})     'trans(fn, New String() {CStr(Me.length), CStr(Me.length), CStr(Me.height / 2)})
            End If

            off.WriteLine("children [")
            FileClose(1)

            If ShapeOpt = "b" Then
                SetPolygon(FN, New String() {CStr(Me.length), CStr(Me.width), CStr(Me.height)}, Itmnm, Wt, QtyFlg)       'SetPolygon is method to create Box with x y z dimensions

            Else
                '---------------- 
            End If

            off.WriteLine("appearance Appearance {")
            If Tex <> "" Then
                off.WriteLine("texture ImageTexture {")
                off.WriteLine("url " & dq & Tex & dq)
                off.WriteLine("}")
            End If

            off.WriteLine("material Material {")
            FileClose(1)

            DifusColr(FN, Transpx, Col)    'Method transp is Diffuser color R G B and Transparancy

            Transprncy(FN, Transpx, Col)    'Visiblity or transparancy is managed

            off.WriteLine("}")
            off.WriteLine("}")

            FileClose(1)

            'fileopen(1, fn, OpenMode.Append)

            off.WriteLine("]")
            off.WriteLine("}")
            off.WriteLine("]")
            off.WriteLine("}")
            off.WriteLine("")
            FileClose(1)

            'Stop
            'off.Close()

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Fatal error in AutoDraw" & vbCrLf & "VRML Programme writting is failure!", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            FileClose(1)
            conn.Close()
            off.Close()
            'Form8.Close()
            'MsgBox("Exception :: In method 'AutoDraw'  " & vbCrLf & "Due to an error application exit!...")
            Application.Exit()
        Finally
            FileClose()
        End Try
        'Stop

        '&&&&&&&&&&&&&&&&&&

        If conn.State = ConnectionState.Closed Then conn.Open()

        Dim Cmd As New OleDb.OleDbCommand
        Cmd.Connection = conn
        Cmd.CommandText = "delete from pgRecord"
        Cmd.ExecuteNonQuery()

        Dim OCmd As New OleDb.OleDbCommand
        OCmd.Connection = conn
        OCmd.CommandText = "insert into pgRecord values ('" & Itmnm & "'," & CStr(Me.length) & "," & CStr(Me.width) & "," & CStr(Me.height) & "," & CStr(Me.StrtPt.x) & "," & CStr(Me.StrtPt.y) & "," & CStr(Me.StrtPt.z) & ")"
        OCmd.ExecuteNonQuery()

        '&&&&&&&&&&&&&&&&&&

        Try
            If DataOpt Then
                Dim cmdc As New OleDb.OleDbCommand
                cmdc.Connection = conn
                cmdc.CommandText = "insert into stuffdata values('" & MatName & "'," & CStr(Me.StrtPt.x) & "," & CStr(Me.StrtPt.y) & "," & CStr(Me.StrtPt.z) & "," & CStr(Me.length) & "," & CStr(Me.width) & "," & CStr(Me.height) & "," & CStr(Method) & ",'" & Col & "','" & Tex & "',0)"
                cmdc.ExecuteNonQuery()
                'conn.Close()  'Do not Close Connection Here 
                InsrtBxData(MatName, Me.StrtPt.x, Me.StrtPt.y, Me.StrtPt.z, Me.length, Me.width, Me.height, Method, Col, Tex, BitemqtyInr)

            End If

            'Stop
            'off.Close()

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in AutoDraw" & vbCrLf & "Data insert connection failure!", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'MsgBox("Exception :: In Method 'AutoDraw'  " & vbCrLf & "Data insert connection failure!")

            'conn.Close()
            'off.Close()
        End Try

        '////////////////////////////////////////////////////////

    End Sub

    Public Sub AutoDrawLBL(ByVal fn As String, ByVal col As String, ByVal transpx As Single, ByVal tex As String, ByVal itmnm As String, ByVal wt As Single, ByVal qtyflg As Boolean, ByVal txtopt As Boolean, ByVal matname As String, ByVal method As Integer, ByVal dataopt As Boolean, ByVal shapeopt As String)

        'Stop

        Try

            Dim X As Double = Me.StrtPt.x
            Dim Y As Double = Me.StrtPt.y
            Dim Z As Double = Me.StrtPt.z

            'Stop

            Dim dq As Char = Chr(34)

            off.WriteLine("Transform {")        ' off.WriteLine  => fileopen(1, fn, OpenMode.Append)
            FileClose(1)

            trans(fn, New String() {CStr(Me.StrtPt.x), CStr(Me.StrtPt.y), CStr(Me.StrtPt.z)})
            off.WriteLine("children [")
            off.WriteLine("Transform {")
            FileClose(1)

            If shapeopt = "b" Then     ' Shape of output is Box
                trans(fn, New String() {CStr(Me.length * 0.5), CStr(Me.width * 0.5), CStr(Me.height * 0.5)})      'trans(fn, New String() {CStr(Me.length / 2), CStr(Me.width / 2), CStr(Me.height / 2)})       
            Else
                trans(fn, New String() {CStr(Me.length), CStr(Me.length), CStr(Me.height * 0.5)})     'trans(fn, New String() {CStr(Me.length), CStr(Me.length), CStr(Me.height / 2)})
            End If

            off.WriteLine("children [")
            FileClose(1)

            If shapeopt = "b" Then
                SetPolygon(fn, New String() {CStr(Me.length), CStr(Me.width), CStr(Me.height)}, itmnm, wt, qtyflg)       'SetPolygon is method to create Box with x y z dimensions

                'off.Close()
                'Stop

            Else
                '---------------- 
            End If

            off.WriteLine("appearance Appearance {")

            If tex <> "" Then
                off.WriteLine("texture ImageTexture {")
                off.WriteLine("url " & dq & tex & dq)
                off.WriteLine("}")
            End If

            off.WriteLine("material Material {")
            FileClose(1)

            DifusColr(fn, transpx, col)    'Method transp is Diffuser color R G B and Transparancy

            'Stop

            If DbxFlgO Then
                transpx = "0"
            End If

            Transprncy(fn, transpx, col)    'Visiblity or transparancy is managed

            off.WriteLine("}")
            off.WriteLine("}")

            FileClose(1)

            '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
            'txtopt = False
            'If txtopt Then
            '    'fileopen(1, fn, OpenMode.Append)

            '    'attention

            '    Dim txtcol As String = "diffuseColor 1 1 1"

            '    Dim sz As Double
            '    off.WriteLine("Transform {")
            '    off.WriteLine("translation 0 " & CStr(Me.width * 1.05 / 2) & " 0")
            '    off.WriteLine("children [")
            '    off.WriteLine("Transform {")
            '    off.WriteLine("rotation 0 1 0 -3.14")
            '    off.WriteLine("children")
            '    off.WriteLine("Transform {")
            '    off.WriteLine("rotation 1 0 0 -1.57")
            '    off.WriteLine("children")
            '    off.WriteLine("Shape {")
            '    off.WriteLine("geometry Text {")
            '    If method = 1 Or method = 5 Then
            '        itmnm = "R"
            '    End If
            '    If method = 2 Then
            '        itmnm = "T"
            '    End If
            '    If method = 3 Then
            '        itmnm = "T"
            '    End If
            '    If method = 4 Then
            '        itmnm = "BK"
            '    End If
            '    If method = 6 Then
            '        itmnm = "BK"
            '    End If
            '    off.WriteLine("string " & dq & itmnm & dq)
            '    off.WriteLine("maxExtent " & Me.length)
            '    off.WriteLine("fontStyle FontStyle {")
            '    sz = Me.width * 3
            '    off.WriteLine("size " & CStr(sz))
            '    off.WriteLine("justify [" & dq & "MIDDLE" & dq & "," & dq & "MIDDLE" & dq & "]")

            '    off.WriteLine("}")
            '    off.WriteLine("}")
            '    off.WriteLine("appearance Appearance {")
            '    off.WriteLine("material Material {")
            '    off.WriteLine(txtcol)
            '    off.WriteLine("transparency 0")
            '    off.WriteLine("}")
            '    off.WriteLine("}")
            '    off.WriteLine("}")
            '    off.WriteLine("}")
            '    off.WriteLine("}")
            '    off.WriteLine("]")
            '    off.WriteLine("}")

            '    off.WriteLine("Transform {")
            '    off.WriteLine("translation 0 -" & CStr(Me.width * 1.05 / 2) & " 0")
            '    off.WriteLine("children [")
            '    off.WriteLine("Transform {")
            '    off.WriteLine("rotation 1 0 0 1.57")
            '    off.WriteLine("children")
            '    off.WriteLine("Shape {")
            '    off.WriteLine("geometry Text {")
            '    If method = 1 Or method = 5 Then
            '        itmnm = "L"
            '    End If
            '    If method = 2 Then
            '        itmnm = "BT"
            '    End If
            '    If method = 3 Then
            '        itmnm = "BT"
            '    End If
            '    If method = 4 Then
            '        itmnm = "F"
            '    End If
            '    If method = 6 Then
            '        itmnm = "F"
            '    End If
            '    off.WriteLine("string " & dq & itmnm & dq)
            '    off.WriteLine("maxExtent " & Me.length)
            '    off.WriteLine("fontStyle FontStyle {")
            '    sz = Me.width * 3
            '    off.WriteLine("size " & CStr(sz))
            '    off.WriteLine("justify [" & dq & "MIDDLE" & dq & "," & dq & "MIDDLE" & dq & "]")
            '    off.WriteLine("}")
            '    off.WriteLine("}")
            '    off.WriteLine("appearance Appearance {")
            '    off.WriteLine("material Material {")
            '    off.WriteLine(txtcol)
            '    off.WriteLine("transparency 0")
            '    off.WriteLine("}")
            '    off.WriteLine("}")
            '    off.WriteLine("}")
            '    off.WriteLine("}")
            '    off.WriteLine("]")
            '    off.WriteLine("}")

            '    off.WriteLine("Transform {")
            '    off.WriteLine("translation " & CStr(Me.length * 1.05 / 2) & " 0 0")
            '    off.WriteLine("children [")
            '    off.WriteLine("Transform {")
            '    off.WriteLine("rotation 1 0 0 1.57")
            '    off.WriteLine("children")
            '    off.WriteLine("Transform {")
            '    off.WriteLine("rotation 0 1 0 1.57")
            '    off.WriteLine("children")
            '    off.WriteLine("Shape {")
            '    off.WriteLine("geometry Text {")
            '    If method = 1 Or method = 2 Then
            '        itmnm = "F"
            '    End If
            '    If method = 3 Then
            '        itmnm = "R"
            '    End If
            '    If method = 4 Then
            '        itmnm = "R"
            '    End If
            '    If method = 5 Then
            '        itmnm = "T"
            '    End If
            '    If method = 6 Then
            '        itmnm = "T"
            '    End If
            '    off.WriteLine("string " & dq & itmnm & dq)
            '    off.WriteLine("maxExtent " & Me.width)
            '    off.WriteLine("fontStyle FontStyle {")
            '    sz = Me.length * 3
            '    off.WriteLine("size " & CStr(sz))
            '    off.WriteLine("justify [" & dq & "MIDDLE" & dq & "," & dq & "MIDDLE" & dq & "]")
            '    off.WriteLine("}")
            '    off.WriteLine("}")
            '    off.WriteLine("appearance Appearance {")
            '    off.WriteLine("material Material {")
            '    off.WriteLine(txtcol)
            '    off.WriteLine("transparency 0")
            '    off.WriteLine("}")
            '    off.WriteLine("}")
            '    off.WriteLine("}")
            '    off.WriteLine("}")
            '    off.WriteLine("}")
            '    off.WriteLine("]")
            '    off.WriteLine("}")

            '    off.WriteLine("Transform {")
            '    off.WriteLine("translation -" & CStr(Me.length * 1.05 / 2) & " 0 0")
            '    off.WriteLine("children [")
            '    off.WriteLine("Transform {")
            '    off.WriteLine("rotation 1 0 0 1.57")
            '    off.WriteLine("children")
            '    off.WriteLine("Transform {")
            '    off.WriteLine("rotation 0 1 0 -1.57")
            '    off.WriteLine("children")
            '    off.WriteLine("Shape {")
            '    off.WriteLine("geometry Text {")
            '    If method = 1 Or method = 2 Then
            '        itmnm = "BK"
            '    End If
            '    If method = 3 Then
            '        itmnm = "L"
            '    End If
            '    If method = 4 Then
            '        itmnm = "L"
            '    End If
            '    If method = 5 Then
            '        itmnm = "BT"
            '    End If
            '    If method = 6 Then
            '        itmnm = "BT"
            '    End If
            '    off.WriteLine("string " & dq & itmnm & dq)
            '    off.WriteLine("maxExtent " & Me.width)
            '    off.WriteLine("fontStyle FontStyle {")
            '    sz = Me.length * 3
            '    off.WriteLine("size " & CStr(sz))
            '    off.WriteLine("justify [" & dq & "MIDDLE" & dq & "," & dq & "MIDDLE" & dq & "]")
            '    off.WriteLine("}")
            '    off.WriteLine("}")
            '    off.WriteLine("appearance Appearance {")
            '    off.WriteLine("material Material {")
            '    off.WriteLine(txtcol)
            '    off.WriteLine("transparency 0")
            '    off.WriteLine("}")
            '    off.WriteLine("}")
            '    off.WriteLine("}")
            '    off.WriteLine("}")
            '    off.WriteLine("}")
            '    off.WriteLine("]")
            '    off.WriteLine("}")

            '    off.WriteLine("Transform {")
            '    off.WriteLine("translation 0 0 " & CStr(Me.height * 1.05 / 2))
            '    off.WriteLine("children [")
            '    off.WriteLine("Transform {")
            '    off.WriteLine("rotation 0 0 1 1.57")
            '    off.WriteLine("children")
            '    off.WriteLine("Shape {")
            '    off.WriteLine("geometry Text {")
            '    If method = 1 Or method = 4 Then
            '        itmnm = "T"
            '    End If
            '    If method = 2 Then
            '        itmnm = "L"
            '    End If
            '    If method = 3 Then
            '        itmnm = "F"
            '    End If
            '    If method = 5 Then
            '        itmnm = "BK"
            '    End If
            '    If method = 6 Then
            '        itmnm = "F"
            '    End If

            '    off.WriteLine("string " & dq & itmnm & dq)
            '    off.WriteLine("maxExtent " & Me.width)
            '    off.WriteLine("fontStyle FontStyle {")
            '    sz = Me.height * 3
            '    off.WriteLine("size " & CStr(sz))
            '    off.WriteLine("justify [" & dq & "MIDDLE" & dq & "," & dq & "MIDDLE" & dq & "]")
            '    off.WriteLine("}")
            '    off.WriteLine("}")
            '    off.WriteLine("appearance Appearance {")
            '    off.WriteLine("material Material {")
            '    off.WriteLine(txtcol)
            '    off.WriteLine("transparency 0")
            '    off.WriteLine("}")
            '    off.WriteLine("}")
            '    off.WriteLine("}")
            '    off.WriteLine("}")
            '    off.WriteLine("]")
            '    off.WriteLine("}")

            '    off.WriteLine("Transform {")
            '    off.WriteLine("translation 0 0 -" & CStr(Me.height * 1.05 / 2))
            '    off.WriteLine("children [")
            '    off.WriteLine("Transform {")
            '    off.WriteLine("rotation 0 0 1 1.57")
            '    off.WriteLine("children")
            '    off.WriteLine("Shape {")
            '    off.WriteLine("geometry Text {")

            '    If method = 1 Or method = 4 Then
            '        itmnm = "BT"
            '    End If
            '    If method = 2 Then
            '        itmnm = "R"
            '    End If
            '    If method = 3 Then
            '        itmnm = "BK"
            '    End If
            '    If method = 5 Then
            '        itmnm = "F"
            '    End If
            '    If method = 6 Then
            '        itmnm = "R"
            '    End If

            '    off.WriteLine("string " & dq & itmnm & dq)
            '    off.WriteLine("maxExtent " & Me.width)
            '    off.WriteLine("fontStyle FontStyle {")
            '    sz = Me.height * 3
            '    off.WriteLine("size " & CStr(sz))
            '    off.WriteLine("justify [" & dq & "MIDDLE" & dq & "," & dq & "MIDDLE" & dq & "]")
            '    off.WriteLine("}")
            '    off.WriteLine("}")
            '    off.WriteLine("appearance Appearance {")
            '    off.WriteLine("material Material {")
            '    off.WriteLine(txtcol)
            '    off.WriteLine("transparency 0")
            '    off.WriteLine("}")
            '    off.WriteLine("}")
            '    off.WriteLine("}")
            '    off.WriteLine("}")
            '    off.WriteLine("]")
            '    off.WriteLine("}")

            '    FileClose(1)
            'End If

            'Stop


            Dim InsrNm As String = Convert.ToString(arl(BitemqtyInr - 1))

            IncSrNumPrnt(InsrNm, ADclFlg, method, itmnm)

            'Stop

            '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

            'fileopen(1, fn, OpenMode.Append)

            off.WriteLine("]")
            off.WriteLine("}")
            off.WriteLine("]")
            off.WriteLine("}")
            off.WriteLine("")
            FileClose(1)

            'Stop

            'off.Close()

            'Stop

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Fatal error in AutoDraw" & vbCrLf & "VRML Programme writting is failure!", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            FileClose(1)
            conn.Close()
            off.Close()
            'Form8.Close()
            'MsgBox("Exception :: In method 'AutoDraw'  " & vbCrLf & "Due to an error application exit!...")
            Application.Exit()
        Finally
            FileClose()
        End Try

        'Stop

        Try
            If dataopt Then
                Dim cmd As New OleDb.OleDbCommand
                cmd.Connection = conn
                cmd.CommandText = "insert into stuffdata values('" & matname & "'," & CStr(Me.StrtPt.x) & "," & CStr(Me.StrtPt.y) & "," & CStr(Me.StrtPt.z) & "," & CStr(Me.length) & "," & CStr(Me.width) & "," & CStr(Me.height) & "," & CStr(method) & ",'" & col & "','" & tex & "',0)"
                cmd.ExecuteNonQuery()
                'conn.Close()  'Do not Close Connection Here 

                InsrtBxData(matname, Me.StrtPt.x, Me.StrtPt.y, Me.StrtPt.z, Me.length, Me.width, Me.height, method, col, tex, BitemqtyInr)

            End If
        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in AutoDraw" & vbCrLf & "Data insert connection failure!", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'MsgBox("Exception :: In Method 'AutoDraw'  " & vbCrLf & "Data insert connection failure!")
            conn.Close()
            off.Close()
        End Try

    End Sub

    '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
    Public Sub drawold(ByVal fn As String, ByVal col As String, ByVal transpx As Single, ByVal tex As String, ByVal itmnm As String, ByVal wt As Single, ByVal qtyflg As Boolean, ByVal txtopt As Boolean, ByVal matname As String, ByVal method As Integer, ByVal dataopt As Boolean)

        Dim dq As Char = Chr(34)
        'FileOpen(1, fn, OpenMode.Append)

        'PrintLine(1, "Transform {")
        off.WriteLine("Transform {")

        'FileClose(1)
        trans(fn, New String() {CStr(Me.StrtPt.x), CStr(Me.StrtPt.y), CStr(Me.StrtPt.z)})

        off.WriteLine("children [")

        off.WriteLine("Transform {")

        trans(fn, New String() {CStr(Me.length / 2), CStr(Me.width / 2), CStr(Me.height / 2)})

        off.WriteLine("children [")

        SetPolygon(fn, New String() {CStr(Me.length), CStr(Me.width), CStr(Me.height)}, itmnm, wt, qtyflg)

        off.WriteLine("appearance Appearance {")

        If tex <> "" Then

            off.WriteLine("texture ImageTexture {")

            off.WriteLine("url " & dq & tex & dq)
            off.WriteLine("}")

        End If

        off.WriteLine("material Material {")

        transp(fn, transpx, col)

        off.WriteLine("}")
        off.WriteLine("}")
        off.WriteLine("}")
        'off.WriteLine("}")
        off.WriteLine("]")
        off.WriteLine("}")
        off.WriteLine("]")
        off.WriteLine("}")

        If txtopt Then

            Dim txtcol As String = "diffuseColor 1 1 1"

            Dim sz As Double

            off.WriteLine("Transform {")
            off.WriteLine("translation 0 " & CStr(Me.width * 1.05 / 2) & " 0")

            off.WriteLine("children [")

            off.WriteLine("Transform {")
            off.WriteLine("rotation 0 1 0 -3.14")

            off.WriteLine("children [")

            off.WriteLine("Transform {")
            off.WriteLine("rotation 1 0 0 -1.57")

            off.WriteLine("children [")
            off.WriteLine("Shape {")
            off.WriteLine("geometry Text {")

            If method = 1 Or method = 5 Then
                itmnm = "R"
            End If
            If method = 2 Then
                itmnm = "T"
            End If
            If method = 3 Then
                itmnm = "T"
            End If
            If method = 4 Then
                itmnm = "BK"
            End If
            If method = 6 Then
                itmnm = "BK"
            End If

            off.WriteLine("string " & dq & itmnm & dq)
            off.WriteLine("maxExtent " & Me.length)
            off.WriteLine("fontStyle FontStyle {")
            sz = Me.width * 3

            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("size " & CStr(sz))
            off.WriteLine("justify [" & dq & "MIDDLE" & dq & "," & dq & "MIDDLE" & dq & "]")
            off.WriteLine("}")
            off.WriteLine("}")

            off.WriteLine("appearance Appearance {")
            off.WriteLine("material Material {")
            off.WriteLine(txtcol)
            off.WriteLine(txtcol)

            off.WriteLine("transparency 0")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("]")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("]")
            off.WriteLine("}")

            off.WriteLine("Transform {")
            off.WriteLine("translation 0 -" & CStr(Me.width * 1.05 / 2) & " 0")

            off.WriteLine("children [")

            off.WriteLine("Transform {")
            off.WriteLine("rotation 1 0 0 1.57")
            off.WriteLine("rotation 1 0 0 1.57")

            off.WriteLine("children [")
            off.WriteLine("Shape {")
            off.WriteLine("geometry Text {")

            If method = 1 Or method = 5 Then
                itmnm = "L"
            End If
            If method = 2 Then
                itmnm = "BT"
            End If
            If method = 3 Then
                itmnm = "BT"
            End If
            If method = 4 Then
                itmnm = "F"
            End If
            If method = 6 Then
                itmnm = "F"
            End If

            off.WriteLine("string " & dq & itmnm & dq)
            off.WriteLine("maxExtent " & Me.length)
            off.WriteLine("fontStyle FontStyle {")
            sz = Me.width * 3

            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("size " & CStr(sz))
            off.WriteLine("justify [" & dq & "MIDDLE" & dq & "," & dq & "MIDDLE" & dq & "]")
            off.WriteLine("}")
            off.WriteLine("}")

            off.WriteLine("appearance Appearance {")
            off.WriteLine("material Material {")
            off.WriteLine(txtcol)

            off.WriteLine("transparency 0")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("]")
            off.WriteLine("}")

            off.WriteLine("Transform {")
            off.WriteLine("translation " & CStr(Me.length * 1.05 / 2) & " 0 0")

            off.WriteLine("children [")

            off.WriteLine("Transform {")
            off.WriteLine("rotation 1 0 0 1.57")

            off.WriteLine("children [")

            off.WriteLine("Transform {")
            off.WriteLine("rotation 0 1 0 1.57")

            off.WriteLine("children [")
            off.WriteLine("Shape {")
            off.WriteLine("geometry Text {")

            If method = 1 Or method = 2 Then
                itmnm = "F"
            End If
            If method = 3 Then
                itmnm = "R"
            End If
            If method = 4 Then
                itmnm = "R"
            End If
            If method = 5 Then
                itmnm = "T"
            End If
            If method = 6 Then
                itmnm = "T"
            End If

            off.WriteLine("string " & dq & itmnm & dq)
            off.WriteLine("maxExtent " & Me.length)
            off.WriteLine("fontStyle FontStyle {")
            sz = Me.length * 3

            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("size " & CStr(sz))
            off.WriteLine("justify [" & dq & "MIDDLE" & dq & "," & dq & "MIDDLE" & dq & "]")
            off.WriteLine("}")
            off.WriteLine("}")

            off.WriteLine("appearance Appearance {")
            off.WriteLine("material Material {")
            off.WriteLine(txtcol)

            off.WriteLine("transparency 0")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("]")
            off.WriteLine("}")

            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("]")
            off.WriteLine("}")

            off.WriteLine("Transform {")
            off.WriteLine("translation -" & CStr(Me.length * 1.05 / 2) & " 0 0")

            off.WriteLine("children [")

            off.WriteLine("Transform {")
            off.WriteLine("rotation 1 0 0 1.57")

            off.WriteLine("children [")

            off.WriteLine("Transform {")
            off.WriteLine("rotation 0 1 0 -1.57")

            off.WriteLine("children [")
            off.WriteLine("Shape {")
            off.WriteLine("geometry Text {")

            If method = 1 Or method = 2 Then
                itmnm = "BK"
            End If
            If method = 3 Then
                itmnm = "L"
            End If
            If method = 4 Then
                itmnm = "L"
            End If
            If method = 5 Then
                itmnm = "BT"
            End If
            If method = 6 Then
                itmnm = "BT"
            End If

            off.WriteLine("string " & dq & itmnm & dq)
            off.WriteLine("maxExtent " & Me.length)
            off.WriteLine("fontStyle FontStyle {")
            sz = Me.length * 3

            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("size " & CStr(sz))
            off.WriteLine("justify [" & dq & "MIDDLE" & dq & "," & dq & "MIDDLE" & dq & "]")
            off.WriteLine("}")
            off.WriteLine("}")

            off.WriteLine("appearance Appearance {")
            off.WriteLine("material Material {")
            off.WriteLine(txtcol)

            off.WriteLine("transparency 0")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("]")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("]")
            off.WriteLine("}")

            off.WriteLine("Transform {")
            off.WriteLine("translation 0 0 " & CStr(Me.height * 1.05 / 2))

            off.WriteLine("children [")

            off.WriteLine("Transform {")
            off.WriteLine("rotation 0 0 1 1.57")

            off.WriteLine("children [")
            off.WriteLine("Shape {")
            off.WriteLine("geometry Text {")

            If method = 1 Or method = 4 Then
                itmnm = "T"
            End If
            If method = 2 Then
                itmnm = "L"
            End If
            If method = 3 Then
                itmnm = "F"
            End If
            If method = 5 Then
                itmnm = "BK"
            End If
            If method = 6 Then
                itmnm = "F"
            End If

            'PrintLine(1, "string " & dq & itmnm & dq)
            'PrintLine(1, "maxExtent " & Me.width)
            'PrintLine(1, "fontStyle FontStyle {")
            off.WriteLine("string " & dq & itmnm & dq)
            off.WriteLine("maxExtent " & Me.length)
            off.WriteLine("fontStyle FontStyle {")
            sz = Me.height * 3

            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("size " & CStr(sz))
            off.WriteLine("justify [" & dq & "MIDDLE" & dq & "," & dq & "MIDDLE" & dq & "]")
            off.WriteLine("}")
            off.WriteLine("}")

            off.WriteLine("appearance Appearance {")
            off.WriteLine("material Material {")
            off.WriteLine(txtcol)

            off.WriteLine("transparency 0")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("]")
            off.WriteLine("}")

            off.WriteLine("Transform {")
            off.WriteLine("translation 0 0 -" & CStr(Me.height * 1.05 / 2))

            off.WriteLine("children [")

            off.WriteLine("Transform {")
            off.WriteLine("rotation 0 0 1 1.57")

            off.WriteLine("children [")
            off.WriteLine("Shape {")
            off.WriteLine("geometry Text {")

            If method = 1 Or method = 4 Then
                itmnm = "BT"
            End If
            If method = 2 Then
                itmnm = "R"
            End If
            If method = 3 Then
                itmnm = "BK"
            End If
            If method = 5 Then
                itmnm = "F"
            End If
            If method = 6 Then
                itmnm = "R"
            End If

            off.WriteLine("string " & dq & itmnm & dq)
            off.WriteLine("maxExtent " & Me.length)
            off.WriteLine("fontStyle FontStyle {")
            sz = Me.height * 3

            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("size " & CStr(sz))
            off.WriteLine("justify [" & dq & "MIDDLE" & dq & "," & dq & "MIDDLE" & dq & "]")
            off.WriteLine("}")
            off.WriteLine("}")

            off.WriteLine("appearance Appearance {")
            off.WriteLine("material Material {")
            off.WriteLine(txtcol)

            off.WriteLine("transparency 0")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("]")
            off.WriteLine("}")

            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("}")
            off.WriteLine("]")
            off.WriteLine("}")

        End If

        off.WriteLine("]")
        off.WriteLine("}")

        If dataopt Then

            Dim cmd As New OleDb.OleDbCommand
            cmd.Connection = conn
            If matname = "container" Then matname += "-" & InwardEntry.cmbcontainer.Text
            cmd.CommandText = "insert into stuffdata values('" & matname & "'," & Format(Me.StrtPt.x, "0.0000") & "," & Format(Me.StrtPt.y, "0.0000") & "," & Format(Me.StrtPt.z, "0.0000") & "," & Format(Me.length, "0.0000") & "," & Format(Me.width, "0.0000") & "," & Format(Me.height, "0.0000") & "," & CStr(method) & ",0,0)"
            If conn.State = ConnectionState.Closed Then conn.Open()
            cmd.ExecuteNonQuery()

        End If

        If Me.StrtPt.x = 155 AndAlso Me.StrtPt.y = 50 AndAlso Me.StrtPt.z = 80 Then
            ' Stop
        End If
        '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
    End Sub

    Public Sub AutoDraws(ByVal fn As String, ByVal col As String, ByVal transpx As Single, ByVal tex As String, ByVal itmnm As String, ByVal wt As Single, ByVal qtyflg As Boolean, ByVal txtopt As Boolean, ByVal matname As String, ByVal method As Integer, ByVal dataopt As Boolean, ByVal shapeopt As String)

        Stop

        Try
            Dim X As Double = Me.StrtPt.x
            Dim Y As Double = Me.StrtPt.y
            Dim Z As Double = Me.StrtPt.z

            'Stop

            Dim dq As Char = Chr(34)

            Iow.WriteLine("Transform {")        ' off.WriteLine  => fileopen(1, fn, OpenMode.Append)

            AutoTransln(fn, New String() {CStr(Me.StrtPt.x), CStr(Me.StrtPt.y), CStr(Me.StrtPt.z)})

            Iow.WriteLine("children [")
            Iow.WriteLine("Transform {")
            FileClose(1)

            AutoTransln(fn, New String() {CStr(Me.length * 0.5), CStr(Me.width * 0.5), CStr(Me.height * 0.5)})      'trans(fn, New String() {CStr(Me.length / 2), CStr(Me.width / 2), CStr(Me.height / 2)})       

            Iow.WriteLine("children [")
            FileClose(1)

            SetPolygonBox(fn, New String() {CStr(Me.length), CStr(Me.width), CStr(Me.height)}, itmnm, wt, qtyflg)       'SetPolygon is method to create Box with x y z dimensions

            Iow.WriteLine("appearance Appearance {")

            If tex <> "" Then
                Iow.WriteLine("texture ImageTexture {")
                Iow.WriteLine("url " & dq & tex & dq)
                Iow.WriteLine("}")
            End If

            Iow.WriteLine("material Material {")
            FileClose(1)

            DifusColr(fn, transpx, col)    'Method transp is Diffuser color R G B and Transparancy
            Transprncy(fn, transpx, col)   'Visiblity or transparancy is managed

            Iow.WriteLine("}")
            Iow.WriteLine("}")
            FileClose(1)
            Iow.WriteLine("]")
            Iow.WriteLine("}")
            Iow.WriteLine("]")
            Iow.WriteLine("}")
            Iow.WriteLine("")
            FileClose(1)

        Catch Ex As Exception

            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Fatal error in AutoDraws" & vbCrLf & "VRML Programme writting is failure!", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            FileClose(1)
            conn.Close()
            Iow.Close()
            Application.Exit()

        Finally
            FileClose()
        End Try

        Try

            If dataopt Then
                Dim cmd As New OleDb.OleDbCommand
                cmd.Connection = conn
                cmd.CommandText = "insert into stuffdata values('" & matname & "'," & CStr(Me.StrtPt.x) & "," & CStr(Me.StrtPt.y) & "," & CStr(Me.StrtPt.z) & "," & CStr(Me.length) & "," & CStr(Me.width) & "," & CStr(Me.height) & "," & CStr(method) & ",'" & col & "','" & tex & "',0)"
                cmd.ExecuteNonQuery()
                'conn.Close()  'Do not Close Connection Here 
                InsrtBxData(matname, Me.StrtPt.x, Me.StrtPt.y, Me.StrtPt.z, Me.length, Me.width, Me.height, method, col, tex, BitemqtyInr)
            End If

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in AutoDraws" & vbCrLf & "Data insert connection failure!", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            conn.Close()
            Iow.Close()
        End Try

    End Sub

#End Region

    Protected Overrides Sub Finalize()

        MyBase.Finalize()

    End Sub

End Class
