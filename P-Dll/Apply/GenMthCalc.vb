Imports System
Imports System.Reflection
Imports System.ComponentModel

<Assembly: AssemblyKeyFile("Hazel.CSP_Satwadhir.snk")>      '037afa5399917ef5
<Assembly: AssemblyVersion("1.1.0.0")> 
<Assembly: CLSCompliant(True)> 

Namespace GenLibMth

    Public Class GenMthCalc

        Dim ValD As String = Nothing


        Public Function CalC(ByVal Input As String) As String

            If Input = "" Then
                Return ""
                Exit Function
            End If

            Dim Split As String() = Nothing
            Dim result As String() = Nothing
            Dim In1 As Double = 0
            Dim In2 As Double = 0
            Dim sgn As String = "+-*/"

            Dim s1 As String = "+"
            Dim s2 As String = "-"
            Dim s3 As String = "*"
            Dim s4 As String = "/"

            Dim FResult As String = Nothing

            Try
                Try
                    result = (Input.Split(CChar(s1)))
                    In1 = CDbl(result(0))
                    In2 = CDbl(result(1))
                    Split = s1.Split(CChar(Input))
                    sgn = Split(0)
                Catch ex As Exception
                End Try

                Try
                    result = (Input.Split(CChar(s2)))
                    In1 = CDbl(result(0))
                    In2 = CDbl(result(1))
                    Split = s2.Split(CChar(Input))
                    sgn = Split(0)
                Catch ex As Exception
                End Try

                Try
                    result = (Input.Split(CChar(s3)))
                    In1 = CDbl(result(0))
                    In2 = CDbl(result(1))
                    Split = s3.Split(CChar(Input))
                    sgn = Split(0)
                Catch ex As Exception
                End Try

                Try
                    result = (Input.Split(CChar(s4)))
                    In1 = CDbl(result(0))
                    In2 = CDbl(result(1))
                    Split = s4.Split(CChar(Input))
                    sgn = Split(0)
                Catch ex As Exception
                End Try

                If sgn = "+" Then
                    FResult = CStr(In1 + In2)
                ElseIf sgn = "-" Then
                    FResult = CStr(In1 - In2)
                ElseIf sgn = "*" Then
                    FResult = CStr(In1 * In2)
                ElseIf sgn = "/" Then
                    FResult = CStr(In1 / In2)
                Else
                    MsgBox("Invalid entering the value")
                End If

                Return FResult

            Catch Err As Exception
                MsgBox(Err.Message)
                MsgBox(Err.ToString)
            End Try

            Return FResult

        End Function

    End Class

End Namespace

