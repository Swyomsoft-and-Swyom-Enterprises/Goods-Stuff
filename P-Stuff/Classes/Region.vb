
'Program Name: -    Region.vb
'Programmer Name: - Satwadhir B. Pawar Mob No. :- 9323974665
'Company Name:-     Hazel Infotech LTD. Mumbai
'Project Name: -    Sky Stuff Plus (Container Stuffing)
'Date: -            23 Dec 2K8 3.05 PM (Modified Time)

'Tips: - The code is debugging at that particular dimensions, quantity and sequence.
'        you are decide it the logic happen is correct to that way or its are some 
'        different way the understanding to at your best level is the correct logic 
'        of this particular code block.

'Description: - Region is the inherited class of area and this is two instances ‘All’ is the class
'               Area object and the ‘RegPt’ is the Point class instance.
'               This class is various methods and functions which would used to generate VRML
'               geometry display program of the goods geometry.

#Region " Importing Object "

Imports CSPContnr       'CSPContnr.dll used here
Imports DBxContnr

#End Region

Public Class Region
    Inherits Area

#Region " Class Declaration "

    Public All As New Area
    Public RegPt As New Point

#End Region

#Region " Function Definition "

    Public Function WrVrmlBoxContnrStrt(ByVal fNm As String, ByVal KillFile As Boolean, ByVal Pts As Region)

        Try

            Dim pt As Point = Pts.RegPt

            Dim fileExists As Boolean
            Dim dq As Char = Chr(34)

            Dim CSP As Satwa = New Satwa            'CSPContnr.dll used here

            fileExists = My.Computer.FileSystem.FileExists(fNm)

            If fileExists And KillFile Then
                Kill(fNm)
            End If

            Iow = New IO.StreamWriter(fNm)

            Iow.WriteLine("#VRML V2.0 utf8")
            Iow.WriteLine("")
            Iow.WriteLine("#START BOX_STUFF PROGRAMME")
            Iow.WriteLine("")
            Iow.WriteLine("Background {")
            Iow.WriteLine("skyColor 1 1 1")

            Iow.WriteLine("}")

            '**********
            Iow.WriteLine("Transform {")
            Iow.WriteLine("rotation 1 0 0 -1.570796327")
            Iow.WriteLine("children [")

            Iow.WriteLine("Transform {")
            Iow.WriteLine("rotation 1 0 0 -3.141592654")
            Iow.WriteLine("children [")

            Iow.WriteLine("Transform {")
            Iow.WriteLine("rotation 0 0 1 3.141592654")
            Iow.WriteLine("children [")

            Iow.WriteLine("Transform {")
            Iow.WriteLine("rotation 1 0 0 3.141592654")
            Iow.WriteLine("children [")

            Iow.WriteLine("Transform {")
            Iow.WriteLine("rotation 0 0 1 -1.570796327")
            Iow.WriteLine("children [")

            Iow.WriteLine("Transform {")
            Iow.WriteLine("rotation 1 0 0 -1.570796327")
            Iow.WriteLine("children [")

            Dim Mom As Single = pt.z

            pt.z = pt.y
            pt.y = -Mom

            Iow.WriteLine("Transform {")
            Iow.WriteLine("rotation 0 0 1 3.141592654")
            Iow.WriteLine("children [")

            pt.x = -pt.x
            pt.y = -pt.y

            Iow.WriteLine("Transform {")

            CSP.cX = pt.x
            CSP.cZ = pt.z

            Dim Dlg As Single = CSP.Diagonal()

            Dim OldPtz As Single = pt.z

            CSP.cX = pt.x
            CSP.Dngl = Dlg

            pt.z = CSP.Z_Point()

            Iow.WriteLine("rotation 0 1 0 -" & CStr(Math.Acos(OldPtz / Dlg) / 2))
            Iow.WriteLine("children [")

            CSP.cZ = pt.z
            CSP.cX = pt.x
            CSP.cY = pt.y

            pt.z = CSP.Z_Pt()
            pt.x = CSP.X_Pt()
            pt.y = CSP.Y_Pt()

            Iow.WriteLine("Viewpoint {")
            Iow.WriteLine("position " & pt.x & " " & pt.y & " " & pt.z)

            Dim x1 As Single = pt.x
            Dim y1 As Single = pt.y
            Dim z1 As Single = pt.z

            CSP.cX = pt.x
            CSP.cZ = pt.y

            Dim DigLngth As Single = CSP.Diagonal()

            CSP.cX = pt.x
            CSP.Dngl = DigLngth
            Dim Ang As Single = CSP.AnglTan()

            Iow.WriteLine("description " & dq & "a" & dq)

            Iow.WriteLine("}")
            Iow.WriteLine("]}")

            Iow.WriteLine("]}")
            Iow.WriteLine("]}")

            Iow.WriteLine("Transform {")
            Iow.WriteLine("rotation 1 0 0 -1.570796327")
            Iow.WriteLine("children [")

            Mom = pt.z
            pt.z = pt.y
            pt.y = -Mom

            Iow.WriteLine("Transform {")
            Iow.WriteLine("rotation 0 0 1 3.141592654")
            Iow.WriteLine("children [")

            pt.x = -pt.x * 1.5
            pt.y = -pt.y * 0.15

            Iow.WriteLine("Transform {")

            CSP.cX = -pt.x
            CSP.cZ = -pt.z
            Dlg = CSP.Diagonal()

            OldPtz = pt.z

            CSP.cX = pt.x
            CSP.Dngl = Dlg
            pt.z = CSP.Z_Point()

            CSP.cZ = OldPtz
            CSP.Dngl = Dlg

            Dim sFac As Single = CSP.sFactor()

            Iow.WriteLine("rotation 0 1 0 -" & CStr(Math.Acos(OldPtz / Dlg) * sFac))
            Iow.WriteLine("children [")

            pt.z = pt.z * 2
            pt.x = pt.x * 0.5

            Iow.WriteLine("Viewpoint {")
            Iow.WriteLine("position " & pt.x & " " & pt.y & " " & pt.z)

            CSP.cX = pt.x
            CSP.cZ = pt.y

            DigLngth = CSP.Diagonal()

            CSP.cX = pt.x
            CSP.Dngl = DigLngth

            Ang = CSP.AnglTan()

            Iow.WriteLine("description " & dq & "b" & dq)

            Iow.WriteLine("}")
            Iow.WriteLine("]}")

            Iow.WriteLine("]}")
            Iow.WriteLine("]}")

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MsgBox(Ex.ToString)
            MessageBox.Show("Error in WrVrmlBoxContnrStrt " & vbCrLf & "VRML Programme writting is failure!", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Iow.Close()
            Return Nothing
            MessageBox.Show("Application is terminating")
            Application.Exit()

        End Try
        '**********
        Return Nothing

    End Function

#End Region

#Region " Routine Definition "

    Public Sub AutoDrawsRegn(ByVal fn As String, ByVal col As String, ByVal transpx As Single, ByVal tex As String, ByVal itmnm As String, ByVal wt As Single, ByVal qtyflg As Boolean, ByVal txtopt As Boolean, ByVal matname As String, ByVal method As Integer, ByVal dataopt As Boolean, ByVal shapeopt As String)
        'Stop
        Try
            Dim Sect As New Region

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
            MessageBox.Show("Error in AutoDraws" & vbCrLf & "VRML Programme writting is failure!", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    Public Sub AutoDrawsBxDrRegnOpn1(ByVal fn As String, ByVal col As String, ByVal transpx As Single, ByVal tex As String, ByVal itmnm As String, ByVal wt As Single, ByVal qtyflg As Boolean, ByVal txtopt As Boolean, ByVal matname As String, ByVal method As Integer, ByVal dataopt As Boolean, ByVal shapeopt As String)

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
            MessageBox.Show("Error in AutoDraw" & vbCrLf & "VRML Programme writting is failure!", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    Public Sub AutoDrawsBxDrRegnOpn2(ByVal fn As String, ByVal col As String, ByVal transpx As Single, ByVal tex As String, ByVal itmnm As String, ByVal wt As Single, ByVal qtyflg As Boolean, ByVal txtopt As Boolean, ByVal matname As String, ByVal method As Integer, ByVal dataopt As Boolean, ByVal shapeopt As String)
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
            MessageBox.Show("Error in AutoDraw" & vbCrLf & "VRML Programme writting is failure!", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

#End Region

End Class
