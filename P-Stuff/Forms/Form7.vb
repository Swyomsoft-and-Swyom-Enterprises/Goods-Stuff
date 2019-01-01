
'Program Name: -    Form7.vb
'Programmer Name: - Satwadhir B. Pawar Mob No. :- 9323974665
'Company Name:-     Hazel Infotech LTD. Mumbai
'Project Name: -    Sky Stuff Plus (Container Stuffing)
'Date: -            24 Dec 2K8 11.40 AM (Modified Time)

'Tips: - The code is debugging at that particular dimensions, quantity and sequence.
'        you are decide it the logic happen is correct to that way or its are some 
'        different way the understanding to at your best level is the correct logic 
'        of this particular code block.

'Description: - Form7 is the displaying the 3D VRML program writing in to file is 
'               done in this form and shown the Alteros viewers output.
'               This form contents various routine and functions to utilize as to
'               generate the VRML program.
'               Also this form contents the class surf. 

Public NotInheritable Class Form7
    Inherits System.Windows.Forms.Form

#Region " Class Definition "

    Public cntf As Integer
    Public cnt As Integer

#End Region

#Region " Routine Definition "

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim cmd As New OleDb.OleDbCommand
        Dim rdr As OleDb.OleDbDataReader
        Dim contsurf As New surf
        Dim wsurf As New surf
        Dim cl As Single
        Dim cw As Single
        Dim stk As New List(Of surf)

        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            cmd.Connection = conn

            cmd.CommandText = "delete from surf"
            cmd.ExecuteNonQuery()

            cmd.CommandText = "select l,w,h from stuffdata where itemname = 'container'"
            rdr = cmd.ExecuteReader
            rdr.Read()
            Dim ptx As New Point
            ptx.x = rdr("l")
            ptx.y = rdr("w")
            ptx.z = rdr("h")
            Dim arc As New Area
            arc.StrtPt.x = 0
            arc.StrtPt.y = 0
            arc.StrtPt.z = 0
            arc.length = ptx.x
            arc.width = ptx.y
            arc.height = ptx.z
            Strt(CurDir() & "\first.wrl", True, ptx)

            arc.AutoDraw(CurDir() & "\first.wrl", 1, 0.5, "", "", 0, True, False, "container", 0, True, "b", "1")
            Dim ard As New Area
            ard.StrtPt.x = arc.length
            ard.StrtPt.y = 0
            ard.StrtPt.z = 0
            ard.length = 0.5
            ard.width = arc.width
            ard.height = arc.height

            ard.AutoDraw(CurDir() & "\first.wrl", "", 0, "file:///c:\contdoor.png", "", 0, True, False, "door", 0, False, "b", "1")
            Dim ard1 As New Area
            ard1.StrtPt.x = arc.length - 0.01
            ard1.StrtPt.y = 0
            ard1.StrtPt.z = 0
            ard1.length = 0.5
            ard1.width = ard.width
            ard1.height = ard.height
            ard1.AutoDraw(CurDir() & "\first.wrl", "b", 0, "file:///c:\contdoor.png", "", 0, True, False, "door1", 0, False, "b", "1")

            Try

            Catch ex1 As ArrayTypeMismatchException

            Catch ex As Exception

            End Try

            contsurf.StrtPt.x = 0
            contsurf.StrtPt.y = 0
            contsurf.StrtPt.z = 0
            cl = rdr("l")
            cw = rdr("w")
            rdr.Close()
            contsurf.l = cl
            contsurf.w = cw
            contsurf.insert()

            cmd.CommandText = "select * from surf order by z,y,x"
            rdr = cmd.ExecuteReader
            cntf = 1

            Do While rdr.Read

                wsurf.StrtPt.x = rdr("x")
                wsurf.StrtPt.y = rdr("y")
                wsurf.StrtPt.z = rdr("z")
                wsurf.l = rdr("l")
                wsurf.w = rdr("w")
                rdr.Close()

                cmd.CommandText = "select * from stuffdata where x=" & wsurf.StrtPt.x & " and y=" & wsurf.StrtPt.y & " and z=" & wsurf.StrtPt.z & " and itemname <> 'container'"
                rdr = cmd.ExecuteReader

                If rdr.Read Then

                    Dim ar As New Area
                    Dim s1 As New surf
                    Dim sl As New List(Of surf)
                    Dim col As String
                    Dim img As String
                    ar.StrtPt.x = rdr("x")
                    ar.StrtPt.y = rdr("y")
                    ar.StrtPt.z = rdr("z")
                    ar.length = rdr("l")
                    ar.width = rdr("w")
                    ar.height = rdr("h")
                    col = rdr("color")
                    img = rdr("imgname")

                    ar.AutoDraw(CurDir() & "\first.wrl", col, 0, img, "", 0, True, False, "", 0, True, "b", "1")
                    If cntf Mod CInt(TextBox1.Text) = 0 And cntf <> 0 And cntf >= cnt Then
                        Closef(CurDir() & "\first.wrl")

                        Dim mm() As System.Diagnostics.Process

                        mm = Process.GetProcesses
                        For i As Integer = LBound(mm) To UBound(mm)
                            If mm(i).MainWindowTitle.Length = 10 Then
                                If mm(i).MainWindowTitle.Substring(0, 7).ToLower() = "alteros" Then
                                    mm(i).Kill()
                                    Exit For
                                End If
90:                         End If

                        Next

                        Process.Start("c:\Program Files\Alteros 3D\alteros.exe")

                        cntf += 1
                        cnt = cntf + CInt(TextBox1.Text) - 1
                        Exit Do
                    End If

                    wsurf.delete()
                    s1.StrtPt.x = ar.StrtPt.x
                    s1.StrtPt.y = ar.StrtPt.y
                    s1.StrtPt.z = ar.StrtPt.z
                    s1.l = ar.length
                    s1.w = ar.width
                    sl = wsurf.subs(s1)
                    s1.delete()

                    For i As Integer = 0 To sl.Count - 1
                        If Not subadd2(sl(i)) Then
                            sl(i).insert()
                        End If
                    Next

                    Dim sr3 As New surf
                    sr3.StrtPt.x = ar.StrtPt.x
                    sr3.StrtPt.y = ar.StrtPt.y
                    sr3.StrtPt.z = ar.StrtPt.z + ar.height
                    sr3.l = ar.length
                    sr3.w = ar.width

                    If Not subadd2(sr3) Then
                        sr3.insert()
                    End If

                    rdr.Close()

                    cmd.CommandText = "select * from surf where  g<>'t' order by z desc,x asc,y asc "
                    rdr = cmd.ExecuteReader

                Else
                    rdr.Close()
                    cmd.CommandText = "update surf set g = 't' where x=" & wsurf.StrtPt.x & " and y=" & wsurf.StrtPt.y & " and z=" & wsurf.StrtPt.z
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "select * from surf where order by z desc"
                    rdr = cmd.ExecuteReader
                    cntf -= 1
                End If
                cntf += 1
            Loop
        Catch Ex As Exception
            MsgBox(Ex.Message)
            MessageBox.Show("Error in Button1_Click", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Form7_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim cmd As New OleDb.OleDbCommand
        Dim rdr As OleDb.OleDbDataReader
        Dim contsurf As New surf
        Dim cl As Single
        Dim cw As Single
        Dim stk As New List(Of surf)

        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            cmd.Connection = conn

            cmd.CommandText = "select l,w from stuffdata where itemname = 'container'"
            rdr = cmd.ExecuteReader
            rdr.Read()

            contsurf.StrtPt.x = 0
            contsurf.StrtPt.y = 0
            contsurf.StrtPt.z = 0
            cl = rdr("l")
            cw = rdr("w")
            rdr.Close()
            contsurf.l = cl
            contsurf.w = cw
            stk.Add(contsurf)

            cmd.CommandText = "select * from stuffdata  where itemname<>'container' order by x asc, y asc, z asc"
            rdr = cmd.ExecuteReader

            Do While rdr.Read
                Dim sr As New surf
                Dim sr1 As New surf
                Dim bl As Single
                Dim bw As Single
                Dim bh As Single
                Dim x As Single
                Dim y As Single
                Dim z As Single
                bl = rdr("l")
                bw = rdr("w")
                bh = rdr("h")
                x = rdr("x")
                y = rdr("y")
                z = rdr("z")
                sr.StrtPt.x = x
                sr.StrtPt.y = y
                sr.StrtPt.z = z
                sr.l = bl
                sr.w = bw
                For i As Integer = 0 To stk.Count - 1
                    If stk(i).StrtPt.x = sr.StrtPt.x AndAlso stk(i).StrtPt.y = sr.StrtPt.y AndAlso stk(i).StrtPt.z = sr.StrtPt.z Then
                        sr1 = stk(i)
                        stk.RemoveAt(i)
                        Exit For
                    End If
                Next

                Dim sr2 As New List(Of surf)
                sr2 = sr1.subs(sr)
                For i As Integer = 0 To sr2.Count - 1
                    If Not subadd(stk, sr2(i)) Then
                        stk.Add(sr2(i))
                    End If
                Next
                sr2.Clear()
                Dim sr3 As New surf
                sr3.StrtPt.x = sr.StrtPt.x
                sr3.StrtPt.y = sr.StrtPt.y
                sr3.StrtPt.z = sr.StrtPt.z + bh
                sr3.l = bl
                sr3.w = bw

                If Not subadd(stk, sr3) Then
                    stk.Add(sr3)
                End If

            Loop

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MessageBox.Show("Error in Form7_Load", "Error .....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

#End Region

#Region " Function definition "

    Public Function subadd(ByRef stkx As List(Of surf), ByVal arx As surf) As Boolean

        Dim arx1 As New surf
        Dim arx2 As New surf

        Try
            For i As Integer = 0 To stkx.Count - 1
                arx1.StrtPt.x = stkx(i).StrtPt.x
                arx1.StrtPt.y = stkx(i).StrtPt.y
                arx1.StrtPt.z = stkx(i).StrtPt.z
                arx1.l = stkx(i).l
                arx1.w = stkx(i).w

                If arx.StrtPt.x = arx1.StrtPt.x AndAlso arx1.StrtPt.y + arx1.w = arx.StrtPt.y AndAlso arx.StrtPt.z = arx1.StrtPt.z AndAlso arx.l = arx1.l Then
                    stkx.RemoveAt(i)

                    arx2.StrtPt.x = arx1.StrtPt.x
                    arx2.StrtPt.y = arx1.StrtPt.y
                    arx2.StrtPt.z = arx1.StrtPt.z
                    arx2.l = arx1.l
                    arx2.w = arx1.w + arx.w

                    For j As Integer = 0 To stkx.Count - 1
                        If arx2.StrtPt.y = stkx(j).StrtPt.y AndAlso arx2.StrtPt.x = stkx(j).StrtPt.x + stkx(j).StrtPt.x + stkx(j).l AndAlso arx2.StrtPt.z = stkx(j).StrtPt.z AndAlso arx2.w = stkx(j).w Then
                            Dim arx3 As New surf
                            arx3.StrtPt.x = stkx(j).StrtPt.x
                            arx3.StrtPt.y = stkx(j).StrtPt.y
                            arx3.StrtPt.z = stkx(j).StrtPt.z
                            arx3.l = stkx(j).l + arx2.l
                            arx3.w = arx2.w
                            stkx.Add(arx3)
                            Return True
                        End If

                    Next
                    stkx.Add(arx2)
                    Return True

                End If

            Next

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MessageBox.Show("Error in subadd", "Error .....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return False

    End Function

    Public Function subadd2(ByVal arx As surf) As Boolean

        Dim cmd As New OleDb.OleDbCommand
        Dim rdr As OleDb.OleDbDataReader

        Try
            cmd.CommandText = "select * from surf where y = " & arx.StrtPt.y & " and x = " & arx.StrtPt.x & " - l and z = " & arx.StrtPt.z & " and w = " & arx.w
            cmd.Connection = conn
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                Dim arx4 As New surf
                arx4.StrtPt.x = rdr("x")
                arx4.StrtPt.y = rdr("y")
                arx4.StrtPt.z = rdr("z")
                arx4.w = rdr("w")
                arx4.l = rdr("l") + arx.l
                rdr.Close()
                arx.delete()
                cmd.CommandText = "delete from surf where y = " & arx.StrtPt.y & " and x = " & arx.StrtPt.x & " - l and z = " & arx.StrtPt.z & " and w = " & arx.w
                cmd.ExecuteNonQuery()
                arx4.insert()
                Return True
            Else
                rdr.Close()

            End If

            cmd.CommandText = "select * from surf where y=" & arx.StrtPt.y & " - w and l = " & arx.l & " and x = " & arx.StrtPt.x & " and z = " & arx.StrtPt.z

            cmd.Connection = conn
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                Dim arx1 As New surf
                arx1.StrtPt.x = rdr("x")
                arx1.StrtPt.y = rdr("y")
                arx1.StrtPt.z = rdr("z")
                arx1.l = rdr("l")
                arx1.w = rdr("w") + arx.w
                rdr.Close()
                cmd.CommandText = "delete from surf where y=" & arx.StrtPt.y & " - w and l = " & arx.l & " and x = " & arx.StrtPt.x & " and z = " & arx.StrtPt.z
                cmd.ExecuteNonQuery()
                arx.delete()
                cmd.CommandText = "select * from surf where y = " & arx1.StrtPt.y & " and x = " & arx1.StrtPt.x & " - l and z = " & arx1.StrtPt.z & " and w = " & arx1.w
                rdr = cmd.ExecuteReader
                If rdr.Read Then
                    Dim arx2 As New surf
                    arx2.StrtPt.x = rdr("x")
                    arx2.StrtPt.y = rdr("y")
                    arx2.StrtPt.z = rdr("z")
                    arx2.l = rdr("l") + arx1.l
                    arx2.w = rdr("w")
                    rdr.Close()
                    arx2.insert()
                    cmd.CommandText = "delete from surf where y = " & arx1.StrtPt.y & " and x = " & arx1.StrtPt.x & " - l and z = " & arx1.StrtPt.z & " and w = " & arx1.w
                    cmd.ExecuteNonQuery()
                    Return True
                Else
                    arx1.insert()
                    Return True
                End If

            End If
        Catch Ex As Exception
            MsgBox(Ex.Message)
            MessageBox.Show("Error in subadd2 ", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function

    Public Function subadd1(ByVal arx As surf) As Boolean

        Dim arx1 As New surf
        Dim arx2 As New surf
        Dim cmd As New OleDb.OleDbCommand
        Dim rdr As OleDb.OleDbDataReader
        Dim stkx As New List(Of surf)
        Dim opt As Boolean = False

        Try
            cmd.Connection = conn
            cmd.CommandText = "select * from surf"
            rdr = cmd.ExecuteReader
            Do While rdr.Read
                Dim arxm As New surf
                arxm.StrtPt.x = rdr("x")
                arxm.StrtPt.y = rdr("y")
                arxm.StrtPt.z = rdr("z")
                arxm.l = rdr("l")
                arxm.w = rdr("w")
                stkx.Add(arxm)

            Loop
            rdr.Close()
            cmd.CommandText = "delete from surf"
            cmd.ExecuteNonQuery()
            For i As Integer = 0 To stkx.Count - 1
                arx1.StrtPt.x = stkx(i).StrtPt.x
                arx1.StrtPt.y = stkx(i).StrtPt.y
                arx1.StrtPt.z = stkx(i).StrtPt.z
                arx1.l = stkx(i).l
                arx1.w = stkx(i).w

                If arx.StrtPt.x = arx1.StrtPt.x AndAlso arx1.StrtPt.y + arx1.w = arx.StrtPt.y AndAlso arx.StrtPt.z = arx1.StrtPt.z AndAlso arx.l = arx1.l Then
                    stkx.RemoveAt(i)

                    arx2.StrtPt.x = arx1.StrtPt.x
                    arx2.StrtPt.y = arx1.StrtPt.y
                    arx2.StrtPt.z = arx1.StrtPt.z
                    arx2.l = arx1.l
                    arx2.w = arx1.w + arx.w

                    For j As Integer = 0 To stkx.Count - 1
                        If arx2.StrtPt.y = stkx(j).StrtPt.y AndAlso arx2.StrtPt.x = stkx(j).StrtPt.x + stkx(j).StrtPt.x + stkx(j).l AndAlso arx2.StrtPt.z = stkx(j).StrtPt.z AndAlso arx2.w = stkx(j).w Then
                            Dim arx3 As New surf
                            arx3.StrtPt.x = stkx(j).StrtPt.x
                            arx3.StrtPt.y = stkx(j).StrtPt.y
                            arx3.StrtPt.z = stkx(j).StrtPt.z
                            arx3.l = stkx(j).l + arx2.l
                            arx3.w = arx2.w
                            stkx.Add(arx3)
                            opt = True

                        End If

                    Next
                    stkx.Add(arx2)
                    opt = True
                    opt = True

                End If

            Next

            For i As Integer = 0 To stkx.Count - 1
                Dim arnn As New surf
                arnn.StrtPt.x = stkx(i).StrtPt.x
                arnn.StrtPt.y = stkx(i).StrtPt.y
                arnn.StrtPt.z = stkx(i).StrtPt.z
                arnn.l = stkx(i).l
                arnn.w = stkx(i).w
                arnn.insert()

            Next

            Return opt

        Catch Ex As Exception
            MsgBox(Ex.Message)
            MessageBox.Show("Error in subadd1", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function

#End Region

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

End Class

Public Class surf

#Region " Class Definition "

    Public StrtPt As New Container_Stuff.Point
    Public l As Single
    Public w As Single

#End Region

#Region " Function Definition "

    Public Function subs(ByVal s1 As surf) As List(Of surf)

        Dim lst As New List(Of surf)
        Dim s2 As New surf
        Dim s3 As New surf
        s2.StrtPt.x = Me.StrtPt.x + s1.l
        s2.StrtPt.y = Me.StrtPt.y
        s2.StrtPt.z = Me.StrtPt.z
        s2.l = Me.l - s1.l
        s2.w = Me.w

        s3.StrtPt.x = Me.StrtPt.x
        s3.StrtPt.y = Me.StrtPt.y + s1.w
        s3.StrtPt.z = Me.StrtPt.z
        s3.l = s1.l
        s3.w = Me.w - s1.w

        If Not (Math.Abs(s2.l - 0) < 0.0001) And Not (Math.Abs(s2.w - 0) < 0.0001) Then
            lst.Add(s2)

        End If

        If Not (Math.Abs(s3.l - 0) < 0.0001) And Not (Math.Abs(s3.w - 0) < 0.0001) Then
            lst.Add(s3)

        End If

        Return lst

    End Function

#End Region

#Region " Routine Definition "

    Public Sub insert()

        Dim cmd As New OleDb.OleDbCommand

        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            cmd.Connection = conn

            cmd.CommandText = "insert into surf values(" & Me.StrtPt.x & "," & Me.StrtPt.y & "," & Me.StrtPt.z & "," & Me.l & "," & Me.w & ",'')"
            cmd.ExecuteNonQuery()
        Catch Ex As Exception
            MsgBox(Ex.Message)
            MessageBox.Show("Error in insert", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub delete()

        Dim cmd As New OleDb.OleDbCommand

        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            cmd.Connection = conn

            cmd.CommandText = "delete from surf where x=" & Me.StrtPt.x & " and y=" & Me.StrtPt.y & " and z=" & Me.StrtPt.z
            cmd.ExecuteNonQuery()
        Catch Ex As Exception
            MsgBox(Ex.Message)
            MessageBox.Show("Error in delete", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

#End Region

End Class