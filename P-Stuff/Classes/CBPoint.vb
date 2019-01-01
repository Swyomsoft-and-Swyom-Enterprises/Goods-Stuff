
'Program Name: -    CBPoint.vb
'Programmer Name: - Satwadhir B. Pawar Mob No. :- 9323974665
'Company Name:-     Hazel Infotech LTD. Mumbai
'Project Name: -    Sky Stuff Plus (Container Stuffing)
'Date: -            22 Dec 2K8 4.55 PM (Modified Time)

'Tips: - The code is debugging at that particular dimensions, quantity and sequence.
'        you are decide it the logic happen is correct to that way or its are some 
'        different way the understanding to at your best level is the correct logic 
'        of this particular code block.

'Description: - CBPoint is the class Point which containing the starting points of 
'               geometry goods i.e. box starting points X Y Z in double Type and this 
'               class has certain shared operator overloading of points to return true false results.
'               The another class in that file is class vertex which containing Vx Vy Vz 
'               points Double type which uses as containing three points for box geometry.

#Region " Importing Object "

Imports System
Imports Microsoft.VisualBasic
Imports System.Runtime.InteropServices

#End Region

Public Class Point

#Region "Point Class Declaration "

    'The box points

    Public x As Double
    Public y As Double
    Public z As Double

#End Region

#Region "Operator over function"

    Public Shared Operator =(ByVal p1 As Point, ByVal p2 As Point) As Boolean

        If p1.x = p2.x AndAlso p1.y = p2.y AndAlso p1.z = p2.z Then
            Return True
        End If

    End Operator

    Public Shared Operator <>(ByVal p1 As Point, ByVal p2 As Point) As Boolean

        If p1.x <> p2.x OrElse p1.y <> p2.y OrElse p1.z <> p2.z Then
            Return True
        End If

    End Operator

    Public Shared Operator <=(ByVal Pt1 As Point, ByVal Pt2 As Point) As Boolean

    End Operator

    Public Shared Operator >=(ByVal Pt1 As Point, ByVal Pt2 As Point) As Boolean

    End Operator

#End Region

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

End Class


Public Class Vertex

#Region "Vertex Class Declaration "

    Public Vx As Double
    Public Vy As Double
    Public Vz As Double

#End Region

End Class

#Region " Test Code "

Enum Bool
    [False] = 0
    [True]
End Enum 'Bool

<StructLayout(LayoutKind.Sequential)> _
Public Structure Points
    Public x As Integer
    Public y As Integer
End Structure 'Point

<StructLayout(LayoutKind.Explicit)> _
Public Structure Rect
    <FieldOffset(0)> Public left As Integer
    <FieldOffset(4)> Public top As Integer
    <FieldOffset(8)> Public right As Integer
    <FieldOffset(12)> Public bottom As Integer

End Structure 'Rect

Class LibWrapper
    <DllImport("user32.dll", CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Function PtInRect(ByRef r As Rect, ByVal p As System.Drawing.Point) As Bool
    End Function

    '<DllImport("SSP.exe", CallingConvention:=CallingConvention.StdCall)> _
    '    Public Shared Function stuff(ByVal Arc As Area, ByVal Ar() As Area, ByVal Ari() As String, ByVal ArWt() As Single, ByVal SaveOpt As Boolean, ByVal ShowEmpty As Boolean, ByVal OutFile As String, ByVal DrawArc As Boolean, ByVal TranspArr() As Boolean, ByVal TopUp() As Boolean, ByVal TxtOpt As Boolean, ByVal DrawOpt As Boolean, ByVal FindQtyFlg As Boolean, ByVal ChngFlg As Boolean, ByVal ColArr As List(Of List(Of Byte))) As List(Of Area)
    'End Function

End Class 'LibWrapper

Public Class RectBox

    Public Shared Sub Main()

        Try

            Dim bPointInRect As Bool = 0
            Dim myRect As New Rect()
            myRect.left = 10
            myRect.right = 100
            myRect.top = 10
            myRect.bottom = 100
            Dim myPoint As New System.Drawing.Point
            myPoint.X = 151
            myPoint.Y = 151

            bPointInRect = LibWrapper.PtInRect(myRect, myPoint)

            If bPointInRect = Bool.True Then
                MessageBox.Show("Point lies within the Rect")
                'Console.WriteLine("Point lies within the Rect")
            Else
                MessageBox.Show("Point did not lies within the Rect")
                'Console.WriteLine("Point did not lies within the Rect")
            End If

        Catch e As Exception
            MsgBox(e.Message)
            MsgBox(e.ToString)
            MessageBox.Show("Error in main", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'Console.WriteLine(("Exception : " + e.Message.ToString()))
        End Try
    End Sub 'Main

    Public Sub xxxx()
        Call Main()
    End Sub

End Class 'TestApplication

#End Region

