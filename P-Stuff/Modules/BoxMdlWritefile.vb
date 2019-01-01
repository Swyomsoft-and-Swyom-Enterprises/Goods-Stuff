
'Program Name: -    BoxMdlWritefile.vb
'Programmer Name: - Satwadhir B. Pawar Mob No. :- 9323974665
'Company Name:-     Hazel Infotech LTD. Mumbai
'Project Name: -    Sky Stuff Plus (Container Stuffing)
'Date: -            22 Dec 2K8 2.15 PM (Modified Time)

'Tips: - The code is debugging at that particular dimensions, quantity and sequence.
'        you are decide it the logic happen is correct to that way or its are some 
'        different way the understanding to at your best level is the correct logic 
'        of this particular code block.

'Description: - BoxMdlWritefile is the box stuffing module to implements various 
'               routines and function so that the ultimate results in box stuffing 
'               and the vrml programmed written in First.wrl file to show final output 
'               through the Alteros Viewers.

#Region "Importing Object "

Imports System.Drawing
Imports Microsoft.Office.Core
#End Region

Module BoxMdlWritefile

#Region " Module Delcaration "

    Public colopt As Boolean = True
    Public app As Word.Application
    Public Iow As System.IO.StreamWriter

#End Region

#Region " Routine Definition "

    Public Sub StartNewFile(ByVal fNm As String, ByVal kilFNm As Boolean, ByVal fNmExists As Boolean, ByVal pt As Point)

        Try

            Dim dq As Char = Chr(34)

            fNmExists = My.Computer.FileSystem.FileExists(fNm)

            If fNmExists And kilFNm Then
                Kill(fNm)
            End If

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in StartNewFile", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub Strt(ByVal fn As String, ByVal killfile As Boolean, ByVal pt As Point)
        'Stop

        Try

            Dim fileExists As Boolean
            Dim dq As Char = Chr(34)
            fileExists = My.Computer.FileSystem.FileExists(fn)

            If fileExists And killfile Then
                Kill(fn)
            End If

            off = New IO.StreamWriter(fn)               'FileOpen(1, fn, OpenMode.Append)

            off.WriteLine("#VRML V2.0 utf8")
            off.WriteLine("")
            off.WriteLine("#START BOX_STUFF PROGRAMME")
            off.WriteLine("")
            off.WriteLine("Background {")
            off.WriteLine("skyColor 1 1 1")

            off.WriteLine("}")

            off.WriteLine("Transform {")
            off.WriteLine("rotation 1 0 0 -1.57")
            off.WriteLine("children [")

            off.WriteLine("Transform {")
            off.WriteLine("rotation 1 0 0 -3.14")
            off.WriteLine("children [")

            off.WriteLine("Transform {")
            off.WriteLine("rotation 0 0 1 3.14")
            off.WriteLine("children [")

            off.WriteLine("Transform {")
            off.WriteLine("rotation 1 0 0 3.14")
            off.WriteLine("children [")

            off.WriteLine("Transform {")
            off.WriteLine("rotation 0 0 1 -1.57")
            off.WriteLine("children [")

            off.WriteLine("Transform {")
            off.WriteLine("rotation 1 0 0 -1.57")
            off.WriteLine("children [")

            Dim tmp As Single = pt.z

            pt.z = pt.y
            pt.y = -tmp

            off.WriteLine("Transform {")
            off.WriteLine("rotation 0 0 1 3.14")
            off.WriteLine("children [")

            pt.x = -pt.x
            pt.y = -pt.y

            off.WriteLine("Transform {")                'PrintLine(1, "rotation 0 1 0 -1.3258")

            Dim dlg As Single = ((pt.x ^ 2) + (pt.z ^ 2)) ^ 0.5
            Dim oldptz As Single = pt.z
            pt.z = pt.x / (pt.x / dlg)
            off.WriteLine("rotation 0 1 0 -" & CStr(Math.Acos(oldptz / dlg) / 2))
            off.WriteLine("children [")
            pt.z = pt.z * 1.5
            pt.x = pt.x * 0.5
            'pt.z = pt.z / 0.707
            'pt.z = 523

            pt.y = pt.y / 2

            off.WriteLine("Viewpoint {")
            off.WriteLine("position " & pt.x & " " & pt.y & " " & pt.z)

            Dim x1 As Single = pt.x
            Dim y1 As Single = pt.y
            Dim z1 As Single = pt.z
            Dim diglngth As Single = ((pt.x ^ 2) + (pt.y ^ 2)) ^ 0.5
            Dim ang As Single = Math.Atan(pt.x / diglngth)

            off.WriteLine("description " & dq & "a" & dq)

            off.WriteLine("}")
            off.WriteLine("]}")

            off.WriteLine("]}")
            off.WriteLine("]}")

            off.WriteLine("Transform {")
            off.WriteLine("rotation 1 0 0 -1.57")
            off.WriteLine("children [")

            tmp = pt.z
            pt.z = pt.y
            pt.y = -tmp

            off.WriteLine("Transform {")
            off.WriteLine("rotation 0 0 1 3.14")
            off.WriteLine("children [")

            pt.x = -pt.x * 1.5
            pt.y = -pt.y * 0.15

            off.WriteLine("Transform {")
            'PrintLine(1, "rotation 0 1 0 -1.3258")
            dlg = ((pt.x ^ 2) + (pt.z ^ 2)) ^ 0.5
            oldptz = pt.z
            pt.z = pt.x / (pt.x / dlg)
            Dim sfac As Single = 2.3 / Math.Acos(oldptz / dlg)
            off.WriteLine("rotation 0 1 0 -" & CStr(Math.Acos(oldptz / dlg) * sfac))
            off.WriteLine("children [")
            pt.z = pt.z * 2
            pt.x = pt.x * 0.5

            off.WriteLine("Viewpoint {")
            off.WriteLine("position " & pt.x & " " & pt.y & " " & pt.z)

            diglngth = ((pt.x ^ 2) + (pt.y ^ 2)) ^ 0.5
            ang = Math.Atan(pt.x / diglngth)

            off.WriteLine("description " & dq & "b" & dq)

            off.WriteLine("}")
            off.WriteLine("]}")

            off.WriteLine("]}")
            off.WriteLine("]}")

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in strt", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            off.Close()
            conn.Close()
            Exit Sub
        End Try

    End Sub

    Public Sub strt1(ByVal fn As String, ByVal killfile As Boolean)

        Dim fileExists As Boolean
        Dim dq As Char = Chr(34)

        Try

            fileExists = My.Computer.FileSystem.FileExists(fn)

            If fileExists And killfile Then
                Kill(fn)
            End If
            off = New IO.StreamWriter(fn)

            off.WriteLine("#VRML V2.0 utf8")

            off.WriteLine("Transform {")
            off.WriteLine("rotation 1 0 0 -3.14")
            off.WriteLine("children[")
            off.WriteLine("Transform {")
            off.WriteLine("rotation 1 0 0 -3.14")
            off.WriteLine("children [")
            off.WriteLine("Transform {")
            off.WriteLine("rotation 0 0 1 3.14")
            off.WriteLine("children [")
            off.WriteLine("Transform {")
            off.WriteLine("rotation 1 0 0 3.14")
            off.WriteLine("children [")

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in strt1", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub remlastlines(ByVal fn As String, ByVal nooflines As Integer)

        Dim lncnt As Integer
        Dim fnstr As String

        Try

            FileOpen(1, fn, OpenMode.Input)
            Do While Not EOF(1)
                LineInput(1)
                lncnt += 1
            Loop
            lncnt += 1
            FileClose(1)
            If lncnt < nooflines Then
                Exit Sub
            End If
            FileOpen(1, fn, OpenMode.Input)
            FileOpen(2, "c:\temp$$$.$$$", OpenMode.Output)
            For i As Long = 0 To lncnt - nooflines - 2
                fnstr = LineInput(1)
                PrintLine(2, fnstr)
            Next
            FileClose(New Integer() {1, 2})
            Kill(fn)
            Rename("c:\temp$$$.$$$", fn)

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in remlastlines", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub BxTrans(ByVal fNm As String, ByVal StrtPt() As String)

        'Stop

        Try

            off.WriteLine("translation " & CStr(StrtPt(0) & " " & CStr(StrtPt(1)) & " " & CStr(StrtPt(2))))

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in Bxtrans", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub trans(ByVal fn As String, ByVal StrtPt() As String)

        Try

            off.WriteLine("translation " & CStr(StrtPt(0)) & " " & CStr(StrtPt(1)) & " " & CStr(StrtPt(2)))

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in trans", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub AutoTransln(ByVal fn As String, ByVal StrtPt() As String)

        Try

            Iow.WriteLine("translation " & CStr(StrtPt(0)) & " " & CStr(StrtPt(1)) & " " & CStr(StrtPt(2)))

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in AutoTransln", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub SetPolygonBox(ByVal fNm As String, ByVal BxArr As String(), ByVal ItmNm As String, ByVal Wt As Single, ByVal QtyFlg As Boolean)

        Try
            Try

                off.WriteLine("Shape {")
                off.WriteLine("geometry Box {")
                off.WriteLine("size " & BxArr(0) & " " & BxArr(1) & " " & BxArr(2))
                off.WriteLine("}")
            Catch
                Iow.WriteLine("Shape {")
                Iow.WriteLine("geometry Box {")
                Iow.WriteLine("size " & BxArr(0) & " " & BxArr(1) & " " & BxArr(2))
                Iow.WriteLine("}")
            End Try

        Catch Err As Exception
            MsgBox(Err.Message)
            MsgBox(Err.ToString)
            MessageBox.Show("Error in SetPolygonBox", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub SetPolygon(ByVal fn As String, ByVal szarr As String(), ByVal itmnm As String, ByVal wt As Single, ByVal qtyflg As Boolean)

        Dim dq As Char = Chr(34)
        Static qty As Integer           'FileOpen(1, fn, OpenMode.Append)

        Try

            If qtyflg Then
                qty = 1
            End If

            qty += 1

            PlysQty += 1

            off.WriteLine("Shape {")
            off.WriteLine("geometry Box {")
            off.WriteLine("size " & szarr(0) & " " & szarr(1) & " " & szarr(2))
            off.WriteLine("}")

            'Stop
            'off.Close()

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in SetPolygon", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub placecube(ByVal fn As String, ByVal szarr As String(), ByVal itmnm As String, ByVal wt As Single, ByVal qtyflg As Boolean)
        Dim dq As Char = Chr(34)
        'FileOpen(1, fn, OpenMode.Append)
        Static qty As Integer
        If qtyflg Then
            qty = 1
        End If
        'If qty <> 0 Then
        'Form4.placetable("c:\" & itmnm & ".htm", szarr, qty, wt, itmnm)
        'Form4.endhtml("c:\" & itmnm & ".htm")
        'End If

        'Else
        qty += 1
        'End If

        'If qty = 0 Then qty += 1
        'PrintLine(1, "Anchor {")
        'PrintLine(1, "url " & dq & "file:///c:\" & itmnm & ".htm" & dq)
        'PrintLine(1, "parameter " & dq & "target=" & "bottom" & dq)
        'PrintLine(1, "children [")
        off.WriteLine("Shape {")
        off.WriteLine("geometry Box {")
        off.WriteLine("size " & szarr(0) & " " & szarr(1) & " " & szarr(2))
        off.WriteLine("}")
        'FileClose(1)




    End Sub


    Public Sub transp(ByVal fn As String, ByVal grd As String, ByVal col As String)
        'FileOpen(1, fn, OpenMode.Append)
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
                off.WriteLine("diffuseColor 1 1 1")
            End If

            off.WriteLine("transparency " & grd)

            off.WriteLine("}")

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in transp", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub CloseVRML(ByVal fn As String)

        Try

            TransactionMenu.ShowButton.BackColor = Color.MediumTurquoise

            Try
                off.WriteLine("")
                off.WriteLine("")
                off.WriteLine("# $$ Hazel Infotech Ltd Mumbai (www.pristinenterprises.com) $$ #")
                off.Close()
            Catch
                Iow.WriteLine("")
                Iow.WriteLine("#EMPTY AREA")
                Iow.WriteLine("]}]}]}]}]}")
                Iow.WriteLine("")
                Iow.WriteLine("#END BOX_STUFF PROGRAMME")
                Iow.WriteLine("")
                Iow.WriteLine("")
                Iow.WriteLine("# $$ Hazel Infotech Ltd Mumbai (www.pristinenterprises.com) $$ #")
                Iow.Close()
            End Try

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in Closef", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Try
                off.Close()
                conn.Close()
            Catch
                Iow.Close()
            End Try
        End Try

    End Sub

    Public Sub Closef(ByVal fn As String)

        Try

            TransactionMenu.ShowButton.BackColor = Color.MediumTurquoise

            Try

                off.WriteLine("")
                off.WriteLine("#EMPTY AREA")
                off.WriteLine("]}]}]}]}]}")
                off.WriteLine("")
                off.WriteLine("#END BOX_STUFF PROGRAMME")
                off.WriteLine("")
                off.WriteLine("")
            Catch
                Iow.WriteLine("")
                Iow.WriteLine("#EMPTY AREA")
                Iow.WriteLine("]}]}]}]}]}")
                Iow.WriteLine("")
                Iow.WriteLine("#END BOX_STUFF PROGRAMME")
                Iow.WriteLine("")
                Iow.WriteLine("")
                Iow.WriteLine("# $$ Hazel Infotech Ltd $$ #")
            End Try

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in Closef", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub trunct(ByVal fn As String, ByVal i As Integer)

        Dim ln As String
        Dim cnt As Integer = 1

        Try

            FileOpen(1, fn, OpenMode.Input)
            FileOpen(2, "c:\$$$.$$$", OpenMode.Output)
            Do While Not EOF(1)
                ln = LineInput(1)
                If cnt <= i Then
                    PrintLine(2, ln)
                    cnt += 1
                Else
                    FileClose(1)
                    FileClose(2)
                    Exit Do
                End If
            Loop
            Kill(fn)
            Rename("c:\$$$.$$$", fn)

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in ", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    'Public Function itemstuffed(ByVal itmnm As String, ByVal send As Object, ByVal obj As System.Windows.Forms.MouseEventArgs) As Boolean

    '    Dim cmd As New OleDb.OleDbCommand
    '    Dim rdr As OleDb.OleDbDataReader

    '    Try

    '        If conn.State = ConnectionState.Closed Then conn.Open()

    '        cmd.Connection = conn
    '        cmd.CommandText = "select * from stuffdata where itemname ='" & itmnm & "'"
    '        rdr = cmd.ExecuteReader

    '        If Not rdr.HasRows Then
    '            Dim mRs As MsgBoxResult = MessageBox.Show("Item not stuffed. Do you want to stuff", "P-Stuff", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

    '            If mRs = MsgBoxResult.Yes Then

    '                Call TransactionMenu.ShowButton_MouseClick(send, obj)
    '                rdr.Close()
    '                Return True

    '            ElseIf mRs = MsgBoxResult.No Then

    '                MsgBox("Item not stuffed.Cannot show layout")
    '                Return False

    '            End If
    '        Else
    '            rdr.Close()
    '            Return True
    '        End If

    '    Catch Ex As Exception
    '        MsgBox(Ex.Message)
    '        MsgBox(Ex.ToString)
    '        MessageBox.Show("Error in itemstuffed", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try

    ' End Function

    Public Sub strtword(ByRef wdapp As Object)

        wdapp = CreateObject("word.application")
        wdapp.Visible = True

    End Sub

    Public Sub generate(ByVal doc As Word.Document, ByVal itmnm As String, ByVal ret As contret, ByVal itmno As String)

        Dim rdr As OleDb.OleDbDataReader
        Dim rdr1 As OleDb.OleDbDataReader
        Dim cmd As New OleDb.OleDbCommand
        Dim cmd1 As New OleDb.OleDbCommand
        'Stop
        Dim mulfac As Double
        Dim x As Single
        Dim y As Single
        Dim z As Single
        Dim l As Single
        Dim w As Single
        Dim h As Single
        Dim shp As Word.Shape = Nothing
        Dim method As Byte
        Dim method1 As String = Nothing
        Dim qty As Integer
        Dim lst As New List(Of clm)

        Dim lstp As New List(Of clmx)
        Dim orgx As Single
        Dim orgy As Single
        Dim orgz As Single
        Dim totqty As Integer
        Dim qta As New List(Of Integer)
        Dim clra As New List(Of Long)

        Try
            If conn.State = ConnectionState.Closed Then conn.Open()

            qta.Clear()
            clra.Clear()

            cmd.Connection = conn
            cmd.CommandText = "select * from stuffdata where itemname ='" & itmnm & "'"
            rdr = cmd.ExecuteReader

            totqty = 0

            Do While rdr.Read
                totqty += 1
            Loop

            rdr.Close()

            cmd.Connection = conn
            cmd1.Connection = conn
            cmd.CommandText = "select * from stuffdata where left(itemname,9) ='container'"
            rdr = cmd.ExecuteReader
            rdr.Read()

            mulfac = ret.mulfac

            rdr.Close()

            rdr.Close()
            cmd.CommandText = "select distinct x,y,l,w,h,method from stuffdata where itemname ='" & itmnm & "'"
            rdr = cmd.ExecuteReader
            rdr.Read()
            l = rdr("l")
            w = rdr("w")
            h = rdr("h")
            method = rdr("method")
            Dim tmp As Single
            Dim tmp1 As Single
            Select Case method
                Case 1
                    Exit Select
                Case 2
                    tmp = h
                    h = w
                    w = tmp
                    Exit Select
                Case 3
                    tmp = l
                    tmp1 = h
                    l = w
                    h = tmp
                    w = tmp1
                    Exit Select
                Case 4
                    tmp = l
                    l = w
                    w = tmp
                    Exit Select
                Case 5
                    tmp = l
                    l = h
                    h = tmp
                    Exit Select
                Case 6
                    'hlw
                    tmp = l
                    tmp1 = w
                    l = h
                    w = tmp
                    h = tmp1
                    Exit Select
            End Select

            Try

                doc.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 75, 90, 425, 20).Select()
                'doc.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal)

            Catch e As Exception
                Exit Sub
            End Try

            doc.Application.Selection.TypeText("Layout of " & itmnm & "  Size:(" & CStr(l) & "x" & CStr(w) & "x" & CStr(h) & ") Inches (LxWxH), Quantity:" & totqty.ToString)

            rdr.Close()

            cmd.CommandText = "select distinct x,y,z,l,w,method from stuffdata where itemname ='" & itmnm & "' order by x asc, y asc,z desc"
            rdr = cmd.ExecuteReader
            Do While rdr.Read
                orgx = rdr("x")
                orgy = rdr("y")
                x = (rdr("x") * mulfac) + 75.0#
                'y = ret.lst(0).y - (rdr("y") * mulfac) - (rdr("w") * mulfac)
                y = ret.lst(0).y + (rdr("y") * mulfac)
                l = rdr("l") * mulfac
                w = rdr("w") * mulfac
                method = rdr("method")
                cmd1.Connection = conn
                cmd1.CommandText = "select count(*) from stuffdata where x = " & orgx & " and y = " & orgy & " and method = " & CStr(method) & " and itemname = '" & itmnm & "'"
                rdr1 = cmd1.ExecuteReader
                rdr1.Read()
                qty = rdr1(0)
                rdr1.Close()
                Dim clm1 As New clm
                clm1.l = l
                clm1.w = w
                clm1.qty = qty
                clm1.x = x
                clm1.y = y
                clm1.method = method
                lst.Add(clm1)
                cmd1.CommandText = "update stuffdata set qty = " & qty & " where x =" & orgx & " and y = " & orgy & " and method = " & CStr(method)
                cmd1.ExecuteNonQuery()
            Loop

            rdr.Close()
            'Stop
            Dim lst1 As New List(Of List(Of clm))
            Dim lst3 As New List(Of clm)
            lst3.Add(lst(0))
            lst1.Add(lst3)
            Dim ff As Boolean
            For i As Integer = 1 To lst.Count - 1
                Dim col As New clm
                col = lst(i)
                ff = False
                For j As Integer = 0 To lst1.Count - 1
                    If lst1(j)(0).method = col.method AndAlso lst1(j)(0).qty = col.qty Then
                        lst1(j).Add(col)
                        ff = True
                    End If
                Next
                If Not ff Then
                    Dim jj As New List(Of clm)
                    jj.Add(col)
                    lst1.Add(jj)
                End If
            Next
            Dim lstx As New List(Of clm)
            Dim col1 As clm
            Dim clr As Long = RGB(255, 0, 0)

            Dim k As Integer = 1
            For i As Integer = 0 To lst1.Count - 1
                lstx = lst1(i)
                Select Case clr
                    Case RGB(255, 0, 0)
                        clr = RGB(0, 255, 0)
                        Exit Select
                    Case RGB(0, 255, 0)
                        clr = RGB(0, 0, 255)
                        Exit Select
                    Case RGB(0, 0, 255)
                        clr = RGB(255, 255, 0)
                        Exit Select
                    Case RGB(255, 255, 0)
                        clr = RGB(0, 255, 255)
                        Exit Select
                    Case RGB(0, 255, 255)
                        clr = RGB(255, 0, 255)
                        Exit Select
                    Case RGB(255, 0, 255)
                        clr = RGB(255, 0, 0)
                        Exit Select
                End Select

                col1 = lstx(0)
                Select Case col1.method
                    Case 1
                        method1 = "LWH"
                        Exit Select
                    Case 2
                        method1 = "LHW"
                        Exit Select
                    Case 3
                        method1 = "WHL"
                        Exit Select
                    Case 4
                        method1 = "WLH"
                        Exit Select
                    Case 5
                        method1 = "HWL"
                        Exit Select
                    Case 6
                        method1 = "HLW"
                        Exit Select
                End Select

                'shp = doc.Shapes.AddShape(1, pt.x, pt.y, pt.l, pt.w)
                'shp.Select()
                'doc.Application.Selection.ShapeRange.Fill.ForeColor.RGB = clr
                ' doc.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 160, pt.y, 350, 20).Select()
                'doc.Application.Selection.TypeText(CStr(col1.qty) & " Nos Per column,Method-" & method1)

                For j As Integer = 0 To lstx.Count - 1
                    col1 = lstx(j)
                    Try
                        If colopt Then
                            shp = doc.Shapes.AddShape(1, ret.lst(0).x - (col1.x - 75) - col1.l, col1.y, col1.l, col1.w)
                        Else
                            doc.Shapes.AddTextbox(1, ret.lst(0).x - (col1.x - 75) - col1.l, col1.y, col1.l, col1.w).Select()
                            doc.Application.Selection.Font.Size = 8
                            doc.Application.Selection.TypeText(itmno & "-" & k.ToString)
                        End If

                        cmd.CommandText = "update stuffdata set color =" & clr & " where l =" & CSng(Format(col1.l / mulfac, "0.0000")) & " and w = " & CSng(Format(col1.w / mulfac, "0.0000")) & " and method =" & col1.method & " and qty =" & col1.qty
                        cmd.ExecuteNonQuery()

                        k += 1

                    Catch Ex As Exception

                        Exit Sub
                    End Try
                    If colopt Then
                        shp.Select()
                        Try
                            doc.Application.Selection.ShapeRange.Fill.ForeColor.RGB = clr

                        Catch Ex As Exception

                            Exit Sub
                        End Try
                    End If
                    cmd.CommandText = "update stuffdata set color =" & clr & " where l =" & CSng(Format(col1.l / mulfac, "0.0000")) & " and w = " & CSng(Format(col1.w / mulfac, "0.0000")) & " and method =" & col1.method & " and qty =" & col1.qty
                    cmd.ExecuteNonQuery()
                Next
                qta.Add(k)
                clra.Add(clr)

            Next
            Dim colx As Long
            Dim cmd11 As New OleDb.OleDbCommand
            Dim cmd12 As New OleDb.OleDbCommand

            cmd.CommandText = "select distinct z,x,y,l,h,method,color from stuffdata  where itemname = '" & itmnm & "' order by x asc,y asc,z asc"

            If Not rdr.IsClosed Then rdr.Close()
            rdr = cmd.ExecuteReader
            Do While rdr.Read
                orgx = rdr("x")
                orgz = rdr("z")
                x = (rdr("x") * mulfac) + ret.lst(1).x

                z = ret.lst(1).y - (rdr("z") * mulfac) - (rdr("h") * mulfac)
                l = rdr("l") * mulfac
                h = rdr("h") * mulfac
                colx = rdr("color")
                method = rdr("method")
                cmd1.CommandText = "select count(*) from stuffdata where x = " & orgx & " and z = " & orgz & " and method = " & CStr(method)
                rdr1 = cmd1.ExecuteReader
                rdr1.Read()
                qty = rdr1(0)
                rdr1.Close()
                Dim clm1 As New clmx
                clm1.l = l
                clm1.h = h
                clm1.qty = qty
                clm1.x = x
                clm1.z = z
                clm1.method = method
                clm1.color = colx
                lstp.Add(clm1)

            Loop

            Dim lstx1 As New List(Of List(Of clmx))
            Dim lstx3 As New List(Of clmx)
            lstx3.Add(lstp(0))
            lstx1.Add(lstx3)
            Dim ffx As Boolean
            For i As Integer = 1 To lstp.Count - 1
                Dim col As New clmx
                col = lstp(i)
                ffx = False
                For j As Integer = 0 To lstx1.Count - 1
                    If lstx1(j)(0).method = col.method AndAlso lstx1(j)(0).qty = col.qty Then
                        lstx1(j).Add(col)
                        ffx = True
                    End If
                Next
                If Not ffx Then
                    Dim jj As New List(Of clmx)
                    jj.Add(col)
                    lstx1.Add(jj)
                End If
            Next

            Dim lstxx As New List(Of clmx)
            Dim col1x As clmx
            Dim clrx As Long = RGB(255, 0, 0)
            k = 1

            For i As Integer = 0 To lstx1.Count - 1
                lstxx = lstx1(i)
                Select Case clrx
                    Case RGB(255, 0, 0)
                        clr = RGB(0, 255, 0)
                        Exit Select
                    Case RGB(0, 255, 0)
                        clr = RGB(0, 0, 255)
                        Exit Select
                    Case RGB(0, 0, 255)
                        clr = RGB(255, 255, 0)
                        Exit Select
                    Case RGB(255, 255, 0)
                        clr = RGB(0, 255, 255)
                        Exit Select
                    Case RGB(0, 255, 255)
                        clr = RGB(255, 0, 255)
                        Exit Select
                    Case RGB(255, 0, 255)
                        clr = RGB(255, 0, 0)
                        Exit Select
                End Select

                col1x = lstxx(0)
                Select Case col1x.method
                    Case 1
                        method1 = "LWH"
                        Exit Select
                    Case 2
                        method1 = "LHW"
                        Exit Select
                    Case 3
                        method1 = "WHL"
                        Exit Select
                    Case 4
                        method1 = "WLH"
                        Exit Select
                    Case 5
                        method1 = "HWL"
                        Exit Select
                    Case 6
                        method1 = "HLW"
                        Exit Select
                End Select

                For j As Integer = 0 To lstxx.Count - 1
                    col1x = lstxx(j)
                    Try
                        If colopt Then
                            shp = doc.Shapes.AddShape(1, ret.lst(0).x - (col1x.x - 500) - col1x.l, col1x.z, col1x.l, col1x.h)
                        Else

                            doc.Shapes.AddTextbox(1, ret.lst(0).x - (col1x.x - 500) - col1x.l, col1x.z, col1x.l, col1x.h).Select()
                            doc.Application.Selection.Font.Size = 8
                            doc.Application.Selection.TypeText(itmno & "-" & k.ToString)
                            k += 1
                        End If

                    Catch e As Exception
                        Exit Sub
                    End Try
                    If colopt Then
                        shp.Select()
                        doc.Application.Selection.ShapeRange.Fill.ForeColor.RGB = col1x.color
                    End If
                Next

            Next

            If Not rdr.IsClosed Then rdr.Close()
            cmd.CommandText = "select distinct color,l,w,h,qty,method from stuffdata where itemname = '" & itmnm & "'"
            rdr = cmd.ExecuteReader
            Dim ptt As ptx = ret.lst(1)
            Dim ptt1 As New ptx
            ptt1.x = 100
            ptt1.y = ptt.y + 75
            Dim nocol As Integer
            Dim cnt As Integer = 0
            Dim estr As String = Nothing
            Do While rdr.Read
                cmd1.CommandText = "select count(*) from stuffdata where color = '" & rdr("color").ToString & "' and qty = " & rdr("qty").ToString
                rdr1 = cmd1.ExecuteReader
                rdr1.Read()
                nocol = rdr1(0)
                rdr1.Close()

                Select Case rdr("method")
                    Case 1
                        method1 = "LWH"
                        estr = "Top facing top of the container"
                        Exit Select
                    Case 2
                        method1 = "LHW"
                        estr = "Top facing right of the container"
                        Exit Select
                    Case 3
                        method1 = "WHL"
                        estr = "Top facing right of the container"
                        Exit Select
                    Case 4
                        method1 = "WLH"
                        estr = "Top facing top of the container"
                        Exit Select
                    Case 5
                        method1 = "HWL"
                        estr = "Top facing front of the container"
                        Exit Select
                    Case 6
                        method1 = "HLW"
                        estr = "Top facing front of the container"
                        Exit Select
                End Select

                doc.Shapes.AddShape(1, ptt1.x, ptt1.y, rdr("l"), rdr("w")).Select()
                If colopt Then
                    doc.Application.Selection.ShapeRange.Fill.ForeColor.RGB = rdr("color")
                End If
                doc.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, ptt1.x + rdr("l") + 5, ptt1.y, 400, 25).Select()

                Dim cnt1 As Integer
                For jj As Integer = 0 To clra.Count - 1
                    If clra(jj) = rdr("color") Then
                        cnt1 = jj
                        Exit For
                    End If
                Next
                Dim nostrg As String = ""
                If cnt1 = 0 Then
                    nostrg = "1-" & (qta(cnt1) - 1).ToString
                Else
                    nostrg = qta(cnt1 - 1).ToString & "-" & (qta(cnt1) - 1).ToString
                End If
                doc.Application.Selection.TypeText("Total " & nocol.ToString & " Items, " & rdr("qty").ToString & " Per Column," & (nocol / rdr("qty")) & " Columns,Method:" & method1 & " Nos:" & nostrg)
                doc.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, ptt1.x + rdr("l") + 5, ptt1.y + 25, 400, 25).Select()
                doc.Application.Selection.TypeText(estr)
                ptt1.y = ptt1.y + rdr("w") + 10
                doc.Shapes.AddShape(1, ptt1.x, ptt1.y, rdr("l"), rdr("h")).Select()
                If colopt Then
                    doc.Application.Selection.ShapeRange.Fill.ForeColor.RGB = rdr("color")
                End If
                ptt1.y = ptt1.y + rdr("h") + 25

                cnt += 1

            Loop

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in generate", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub generate1(ByVal doc As Word.Document, ByVal itmnm As String, ByVal ret As contret, ByVal itemno As String)

        Dim rdr As OleDb.OleDbDataReader
        Dim cmd As New OleDb.OleDbCommand
        Dim mulfac As Single = ret.mulfac
        Dim l As Single
        Dim w As Single
        Dim h As Single
        Dim x As Single
        Dim y As Single
        Dim z As Single

        Try

            cmd.Connection = conn
            cmd.CommandText = "select * from stuffdata where itemname ='" & itmnm & "'"
            rdr = cmd.ExecuteReader
            'Stop

            Do While rdr.Read
                l = rdr("l") * mulfac
                w = rdr("w") * mulfac
                h = rdr("h") * mulfac
                x = rdr("x") * mulfac
                y = rdr("y") * mulfac
                z = rdr("z") * mulfac
                doc.Shapes.AddTextbox(1, ret.lst(0).x - x - l, ret.lst(0).y + y, l, w)
                doc.Shapes.AddTextbox(1, ret.lst(1).x - x - l, ret.lst(1).y - z - h, l, h)
            Loop

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in generate1", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub generateold(ByVal doc As Word.Document, ByVal itmnm As String, ByVal ret As contret)

        Dim rdr As OleDb.OleDbDataReader
        Dim rdr1 As OleDb.OleDbDataReader
        Dim cmd As New OleDb.OleDbCommand
        Dim cmd1 As New OleDb.OleDbCommand

        Dim mulfac As Double
        Dim x As Single
        Dim y As Single
        Dim z As Single
        Dim l As Single
        Dim w As Single
        Dim h As Single
        Dim shp As Word.Shape
        Dim method As Byte
        Dim method1 As String = Nothing
        Dim qty As Integer
        Dim lst As New List(Of clm)
        Dim lstp As New List(Of clmx)
        Dim orgx As Single
        Dim orgy As Single
        Dim orgz As Single
        Dim totqty As Integer

        Try

            cmd.Connection = conn
            cmd.CommandText = "select * from stuffdata where itemname ='" & itmnm & "'"
            rdr = cmd.ExecuteReader

            If Not rdr.HasRows Then
                MsgBox("Item not stuffed.Cannot show layout")
                Exit Sub
            Else
                totqty = 0
                Do While rdr.Read
                    totqty += 1
                Loop
                rdr.Close()
            End If

            cmd.Connection = conn
            cmd1.Connection = conn
            cmd.CommandText = "select * from stuffdata where left(itemname,9) ='container'"
            rdr = cmd.ExecuteReader
            rdr.Read()

            mulfac = ret.mulfac

            rdr.Close()

            rdr.Close()
            cmd.CommandText = "select distinct x,y,l,w,h,method from stuffdata where itemname ='" & itmnm & "'"
            rdr = cmd.ExecuteReader
            rdr.Read()
            l = rdr("l")
            w = rdr("w")
            h = rdr("h")
            method = rdr("method")
            Dim tmp As Single
            Dim tmp1 As Single
            Select Case method
                Case 1
                    Exit Select
                Case 2
                    tmp = h
                    h = w
                    w = tmp
                    Exit Select
                Case 3
                    tmp = l
                    tmp1 = h
                    l = w
                    h = tmp
                    w = tmp1
                    Exit Select
                Case 4
                    tmp = l
                    l = w
                    w = tmp
                    Exit Select
                Case 5
                    tmp = l
                    l = h
                    h = tmp
                    Exit Select
                Case 6
                    'hlw
                    tmp = l
                    tmp1 = w
                    l = h
                    w = tmp
                    h = tmp1
                    Exit Select
            End Select
            doc.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 75, 90, 425, 20).Select()

            doc.Application.Selection.TypeText("Layout of " & itmnm & "  Size:(" & CStr(l) & "x" & CStr(w) & "x" & CStr(h) & ") Inches (LxWxH), Quantity:" & totqty.ToString)

            rdr.Close()
            cmd.CommandText = "select distinct x,y,l,w,method from stuffdata where itemname ='" & itmnm & "'"
            rdr = cmd.ExecuteReader
            Do While rdr.Read
                orgx = rdr("x")
                orgy = rdr("y")
                x = (rdr("x") * mulfac) + 75.0#
                y = ret.lst(0).y - (rdr("y") * mulfac) - (rdr("w") * mulfac)
                l = rdr("l") * mulfac
                w = rdr("w") * mulfac
                method = rdr("method")
                cmd1.Connection = conn
                cmd1.CommandText = "select count(*) from stuffdata where x = " & orgx & " and y = " & orgy & " and method = " & CStr(method)
                rdr1 = cmd1.ExecuteReader
                rdr1.Read()
                qty = rdr1(0)
                rdr1.Close()
                Dim clm1 As New clm
                clm1.l = l
                clm1.w = w
                clm1.qty = qty
                clm1.x = x
                clm1.y = y
                clm1.method = method
                lst.Add(clm1)
                cmd1.CommandText = "update stuffdata set qty = " & qty & " where x =" & orgx & " and y = " & orgy & " and method = " & CStr(method)
                cmd1.ExecuteNonQuery()
            Loop

            rdr.Close()

            Dim lst1 As New List(Of List(Of clm))
            Dim lst3 As New List(Of clm)
            lst3.Add(lst(0))
            lst1.Add(lst3)
            Dim ff As Boolean
            For i As Integer = 1 To lst.Count - 1
                Dim col As New clm
                col = lst(i)
                ff = False
                For j As Integer = 0 To lst1.Count - 1
                    If lst1(j)(0).method = col.method AndAlso lst1(j)(0).qty = col.qty Then
                        lst1(j).Add(col)
                        ff = True
                    End If
                Next
                If Not ff Then
                    Dim jj As New List(Of clm)
                    jj.Add(col)
                    lst1.Add(jj)
                End If
            Next

            Dim lstx As New List(Of clm)
            Dim col1 As clm
            Dim clr As Long = RGB(255, 0, 0)

            For i As Integer = 0 To lst1.Count - 1
                lstx = lst1(i)
                Select Case clr
                    Case RGB(255, 0, 0)
                        clr = RGB(0, 255, 0)
                        Exit Select
                    Case RGB(0, 255, 0)
                        clr = RGB(0, 0, 255)
                        Exit Select
                    Case RGB(0, 0, 255)
                        clr = RGB(255, 255, 0)
                        Exit Select
                    Case RGB(255, 255, 0)
                        clr = RGB(0, 255, 255)
                        Exit Select
                    Case RGB(0, 255, 255)
                        clr = RGB(255, 0, 255)
                        Exit Select
                    Case RGB(255, 0, 255)
                        clr = RGB(255, 0, 0)
                        Exit Select
                End Select

                col1 = lstx(0)
                Select Case col1.method
                    Case 1
                        method1 = "LWH"
                        Exit Select
                    Case 2
                        method1 = "LHW"
                        Exit Select
                    Case 3
                        method1 = "WHL"
                        Exit Select
                    Case 4
                        method1 = "WLH"
                        Exit Select
                    Case 5
                        method1 = "HWL"
                        Exit Select
                    Case 6
                        method1 = "HLW"
                        Exit Select
                End Select

                For j As Integer = 0 To lstx.Count - 1
                    col1 = lstx(j)
                    shp = doc.Shapes.AddShape(1, col1.x, col1.y, col1.l, col1.w)
                    shp.Select()
                    doc.Application.Selection.ShapeRange.Fill.ForeColor.RGB = clr
                    cmd.CommandText = "update stuffdata set color =" & clr & " where l =" & CSng(Format(col1.l / mulfac, "0.00")) & " and w = " & CSng(Format(col1.w / mulfac, "0.00")) & " and method =" & col1.method & " and qty =" & col1.qty
                    cmd.ExecuteNonQuery()
                Next
            Next

            Dim colx As Long
            Dim cmd11 As New OleDb.OleDbCommand
            Dim cmd12 As New OleDb.OleDbCommand

            cmd.CommandText = "select distinct z,x,y,l,h,method,color from stuffdata  where itemname = '" & itmnm & "' order by y"
            If Not rdr.IsClosed Then rdr.Close()
            rdr = cmd.ExecuteReader
            Do While rdr.Read
                orgx = rdr("x")
                orgz = rdr("z")
                x = (rdr("x") * mulfac) + ret.lst(1).x

                z = ret.lst(1).y - (rdr("z") * mulfac) - (rdr("h") * mulfac)
                l = rdr("l") * mulfac
                h = rdr("h") * mulfac
                colx = rdr("color")
                method = rdr("method")
                cmd1.CommandText = "select count(*) from stuffdata where x = " & orgx & " and z = " & orgz & " and method = " & CStr(method)
                rdr1 = cmd1.ExecuteReader
                rdr1.Read()
                qty = rdr1(0)
                rdr1.Close()
                Dim clm1 As New clmx
                clm1.l = l
                clm1.h = h
                clm1.qty = qty
                clm1.x = x
                clm1.z = z
                clm1.method = method
                clm1.color = colx
                lstp.Add(clm1)
            Loop

            Dim lstx1 As New List(Of List(Of clmx))
            Dim lstx3 As New List(Of clmx)
            lstx3.Add(lstp(0))
            lstx1.Add(lstx3)
            Dim ffx As Boolean
            For i As Integer = 1 To lstp.Count - 1
                Dim col As New clmx
                col = lstp(i)
                ffx = False
                For j As Integer = 0 To lstx1.Count - 1
                    If lstx1(j)(0).method = col.method AndAlso lstx1(j)(0).qty = col.qty Then
                        lstx1(j).Add(col)
                        ffx = True
                    End If
                Next
                If Not ffx Then
                    Dim jj As New List(Of clmx)
                    jj.Add(col)
                    lstx1.Add(jj)
                End If
            Next

            Dim lstxx As New List(Of clmx)
            Dim col1x As clmx
            Dim clrx As Long = RGB(255, 0, 0)

            For i As Integer = 0 To lstx1.Count - 1
                lstxx = lstx1(i)
                Select Case clrx
                    Case RGB(255, 0, 0)
                        clr = RGB(0, 255, 0)
                        Exit Select
                    Case RGB(0, 255, 0)
                        clr = RGB(0, 0, 255)
                        Exit Select
                    Case RGB(0, 0, 255)
                        clr = RGB(255, 255, 0)
                        Exit Select
                    Case RGB(255, 255, 0)
                        clr = RGB(0, 255, 255)
                        Exit Select
                    Case RGB(0, 255, 255)
                        clr = RGB(255, 0, 255)
                        Exit Select
                    Case RGB(255, 0, 255)
                        clr = RGB(255, 0, 0)
                        Exit Select
                End Select

                col1x = lstxx(0)
                Select Case col1x.method
                    Case 1
                        method1 = "LWH"
                        Exit Select
                    Case 2
                        method1 = "LHW"
                        Exit Select
                    Case 3
                        method1 = "WHL"
                        Exit Select
                    Case 4
                        method1 = "WLH"
                        Exit Select
                    Case 5
                        method1 = "HWL"
                        Exit Select
                    Case 6
                        method1 = "HLW"
                        Exit Select
                End Select

                'shp = doc.Shapes.AddShape(1, pt.x, pt.y, pt.l, pt.w)
                'shp.Select()
                'doc.Application.Selection.ShapeRange.Fill.ForeColor.RGB = clr
                'doc.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 160, pt.y, 350, 20).Select()

                'doc.Application.Selection.TypeText(CStr(col1.qty) & " Nos Per column,Method-" & method1)

                For j As Integer = 0 To lstxx.Count - 1
                    col1x = lstxx(j)
                    shp = doc.Shapes.AddShape(1, col1x.x, col1x.z, col1x.l, col1x.h)
                    shp.Select()
                    doc.Application.Selection.ShapeRange.Fill.ForeColor.RGB = col1x.color
                Next
            Next

            If Not rdr.IsClosed Then rdr.Close()
            cmd.CommandText = "select distinct color,l,w,h,qty,method from stuffdata where itemname = '" & itmnm & "'"
            rdr = cmd.ExecuteReader
            Dim ptt As ptx = ret.lst(1)
            Dim ptt1 As New ptx
            ptt1.x = ptt.x
            ptt1.y = ptt.y + 75
            Dim nocol As Integer
            Do While rdr.Read
                cmd1.CommandText = "select count(*) from stuffdata where color = " & rdr("color").ToString & " and qty = " & rdr("qty").ToString
                rdr1 = cmd1.ExecuteReader
                rdr1.Read()
                nocol = rdr1(0)
                rdr1.Close()

                Select Case rdr("method")
                    Case 1
                        method1 = "LWH"
                        Exit Select
                    Case 2
                        method1 = "LHW"
                        Exit Select
                    Case 3
                        method1 = "WHL"
                        Exit Select
                    Case 4
                        method1 = "WLH"
                        Exit Select
                    Case 5
                        method1 = "HWL"
                        Exit Select
                    Case 6
                        method1 = "HLW"
                        Exit Select
                End Select
                'doc.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 0, 0, 0, 0)
                doc.Shapes.AddShape(1, ptt1.x, ptt1.y, rdr("l"), rdr("w")).Select()
                doc.Application.Selection.ShapeRange.Fill.ForeColor.RGB = rdr("color")
                doc.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, ptt1.x + rdr("l") + 5, ptt1.y, 400, 25).Select()
                doc.Application.Selection.TypeText("Total " & nocol.ToString & " Items, " & rdr("qty").ToString & " Per Column," & (nocol / rdr("qty")) & " Columns,Method:" & method1)
                ptt1.y = ptt1.y + rdr("w") + 10
                doc.Shapes.AddShape(1, ptt1.x, ptt1.y, rdr("l"), rdr("h")).Select()
                doc.Application.Selection.ShapeRange.Fill.ForeColor.RGB = rdr("color")
                ptt1.y = ptt1.y + rdr("h") + 25
            Loop

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in generateold", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

#End Region

#Region " Function Definition "

    Public Function generatecontainer(ByVal wdapp As Word.Application, ByVal dt As String, ByVal recptno As String) As contret

        Dim doc As Word.Document
        Dim rdr As OleDb.OleDbDataReader
        Dim cmd As New OleDb.OleDbCommand
        Dim contln As Single
        Dim contwd As Single
        Dim contht As Single
        Dim mulfac As Double
        Dim shp As Word.Shape
        Dim contname As String
        Dim splt
        Dim ret As New contret

        Try

            If conn.State = ConnectionState.Closed Then conn.Open()

            doc = app.Documents.Add()

            doc.PageSetup.PageHeight = 1584

            cmd.Connection = conn
            cmd.CommandText = "select * from stuffdata where left(itemname,9) like 'container'"
            rdr = cmd.ExecuteReader
            rdr.Read()
            contln = rdr("l")
            contwd = rdr("w")
            contht = rdr("h")
            contname = rdr("itemname")
            splt = Split(contname, "-")
            contname = splt(0)

            mulfac = 400 / contln
            doc.SnapToGrid = False
            doc.SnapToShapes = False

            doc.Shapes.AddTextbox(1, 75, 125, 100, 25).Select()
            doc.Application.Selection.TypeText("Stuffing No:" & recptno)

            doc.Shapes.AddTextbox(1, 200, 125, 100, 25).Select()
            doc.Application.Selection.TypeText("Date:" & dt)

            doc.Shapes.AddTextbox(1, 75, 155, 400, 25).Select()
            doc.Application.Selection.TypeText("Container:" & contname & " Size:" & contln.ToString & "x" & contwd.ToString & "x" & contht.ToString & "LxWxH (inches)")

            shp = doc.Shapes.AddShape(1, 100.0#, 185.0#, 400, contwd * mulfac)
            shp.Select()
            wdapp.Selection.ShapeRange.Line.Weight = 3.0#

            doc.Shapes.AddTextbox(1, 75, 185, 25, contwd * mulfac).Select()
            doc.Application.Selection.TypeText("DOOR")

            doc.Shapes.AddTextbox(1, 100, 180 + contwd * mulfac + 10, 100, 25).Select()
            doc.Application.Selection.TypeText("Top View")

            shp = doc.Shapes.AddShape(1, 100.0#, 185.0# + contwd * mulfac + 50, 400, contht * mulfac)
            shp.Select()
            wdapp.Selection.ShapeRange.Line.Weight = 3.0#


            doc.Shapes.AddTextbox(1, 100, 180 + contwd * mulfac + 70 + contht * mulfac, 100, 25).Select()
            doc.Application.Selection.TypeText("Side View")

            doc.Shapes.AddTextbox(1, 75, 185.0# + contwd * mulfac + 50, 25, contht * mulfac).Select()
            doc.Application.Selection.TypeText("DOOR")

            'shp = doc.Shapes.AddShape(1, 75.0# + 400 + 100, 125.0# + contwd * mulfac + 100, mulfac * contwd, contht * mulfac)
            'shp.Select()
            'wdapp.Selection.ShapeRange.Line.Weight = 3.0#

            Dim lst As New List(Of ptx)
            Dim p1 As New ptx
            Dim p2 As New ptx
            Dim p3 As New ptx

            p1.x = 100 + 400
            'p1.y = 185 + (contwd * mulfac)
            p1.y = 185
            p1.l = 400
            p1.w = contwd * mulfac

            p2.x = 100 + 400
            p2.y = 185 + (contwd * mulfac) + 50 + (contht * mulfac)
            p2.l = 400
            p2.w = contht * mulfac

            p3.x = 75 + 400 + 100
            p3.y = p2.y
            p3.l = contwd * mulfac
            p3.w = contht * mulfac

            lst.Add(p1)
            lst.Add(p2)
            lst.Add(p3)
            ret.lst = lst
            ret.mulfac = mulfac

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in ", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return ret

    End Function

    Public Function generatecontainerold(ByVal wdapp As Word.Application, ByVal dt As String, ByVal recptno As String) As contret

        Dim doc As Word.Document
        Dim rdr As OleDb.OleDbDataReader
        Dim cmd As New OleDb.OleDbCommand
        Dim contln As Single
        Dim contwd As Single
        Dim contht As Single
        Dim mulfac As Double
        Dim shp As Word.Shape
        Dim contname As String
        Dim splt
        Dim ret As New contret

        Try
            doc = wdapp.Documents.Add()

            cmd.Connection = conn
            cmd.CommandText = "select * from stuffdata where left(itemname,9) like 'container'"
            rdr = cmd.ExecuteReader
            rdr.Read()
            contln = rdr("l")
            contwd = rdr("w")
            contht = rdr("h")
            contname = rdr("itemname")
            splt = Split(contname, "-")
            contname = splt(1)

            mulfac = 400 / contln
            doc.SnapToGrid = False
            doc.SnapToShapes = False
            'doc.PageSetup.PageWidth = 400 + (mulfac * contwd) + 100 + 75 + 50
            'doc.PageSetup.PageHeight = (mulfac * contwd) + (mulfac * contht) + 300

            doc.Shapes.AddTextbox(1, 75, 125, 100, 25).Select()
            doc.Application.Selection.TypeText("Stuffing No:" & recptno)

            doc.Shapes.AddTextbox(1, 200, 125, 100, 25).Select()
            doc.Application.Selection.TypeText("Date:" & dt)

            doc.Shapes.AddTextbox(1, 75, 155, 400, 25).Select()
            doc.Application.Selection.TypeText("Container:" & contname & " Size:" & contln.ToString & "x" & contwd.ToString & "x" & contht.ToString & "LxWxH (inches)")

            shp = doc.Shapes.AddShape(1, 75.0#, 185.0#, 400, contwd * mulfac)
            shp.Select()
            wdapp.Selection.ShapeRange.Line.Weight = 3.0#

            doc.Shapes.AddTextbox(1, 475, 185, 25, contwd * mulfac).Select()
            doc.Application.Selection.TypeText("DOOR")

            doc.Shapes.AddTextbox(1, 75, 180 + contwd * mulfac + 10, 100, 25).Select()
            doc.Application.Selection.TypeText("Top View")

            shp = doc.Shapes.AddShape(1, 75.0#, 185.0# + contwd * mulfac + 50, 400, contht * mulfac)
            shp.Select()
            wdapp.Selection.ShapeRange.Line.Weight = 3.0#

            doc.Shapes.AddTextbox(1, 75, 180 + contwd * mulfac + 70 + contht * mulfac, 100, 25).Select()
            doc.Application.Selection.TypeText("Side View")

            doc.Shapes.AddTextbox(1, 475, 185.0# + contwd * mulfac + 50, 25, contht * mulfac).Select()
            doc.Application.Selection.TypeText("DOOR")

            'shp = doc.Shapes.AddShape(1, 75.0# + 400 + 100, 125.0# + contwd * mulfac + 100, mulfac * contwd, contht * mulfac)
            'shp.Select()
            'wdapp.Selection.ShapeRange.Line.Weight = 3.0#

            Dim lst As New List(Of ptx)
            Dim p1 As New ptx
            Dim p2 As New ptx
            Dim p3 As New ptx

            Dim lstold As New List(Of ptx)
            Dim p11 As New ptx
            Dim p21 As New ptx
            Dim p31 As New ptx

            p1.x = 75
            p1.y = 185 + (contwd * mulfac)
            p1.l = 400
            p1.w = contwd * mulfac

            p2.x = 75
            p2.y = 185 + (contwd * mulfac) + 50 + (contht * mulfac)
            p2.l = 400
            p2.w = contht * mulfac

            p3.x = 75 + 400 + 100
            p3.y = p2.y
            p3.l = contwd * mulfac
            p3.w = contht * mulfac

            lst.Add(p1)
            lst.Add(p2)
            lst.Add(p3)
            ret.lst = lst
            ret.mulfac = mulfac

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox(ex.ToString)
            MessageBox.Show("Error in ", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return ret

    End Function

    Public Function findend(ByVal fn As String) As Integer

        Dim ln As String
        Dim cnt As Integer = 1

        Try

            FileOpen(1, fn, OpenMode.Input)

            Do While Not EOF(1)
                ln = LineInput(1)
                If ln <> "#Empty Area" Then
                    cnt += 1
                Else
                    Exit Do
                End If
            Loop

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in findend", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            FileClose(1)
        End Try

        Return cnt

    End Function

#End Region

#Region " Structure Definition "

    Structure clm

        Public x As Single
        Public y As Single
        Public l As Single
        Public w As Single
        Public qty As Integer
        Public method As Byte

    End Structure

    Structure clmx

        Public x As Single
        Public z As Single
        Public l As Single
        Public h As Single
        Public qty As Integer
        Public method As Byte
        Public color As Long

    End Structure

    Structure ptx

        Public x As Single
        Public y As Single
        Public l As Single
        Public w As Single

    End Structure

    Structure contret

        Public lst As List(Of ptx)
        Public mulfac As Single

    End Structure

#End Region

End Module


