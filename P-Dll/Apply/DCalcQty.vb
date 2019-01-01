'	Program Name: - DCalcQty.vb
'	Programmer Name:- Satwadhir B. Pawar Mob No. :- 9323974665
'	Description:-  The quantity of items to placed at container is find out
'	Company Name:-Hazel Infotech LTD.
'	Project Name: - Container Stuffing Plus
'	Date:- 21 June 2K8 11.56 PM (Modified Time)
'
'$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

Imports System
Imports System.Reflection
Imports System.ComponentModel

<assembly:AssemblyKeyFile("Hazel.CSP_Satwadhir.snk")> 	'037afa5399917ef5
<assembly:AssemblyVersion("1.0.0.0")>
<assembly:CLSCompliant(true)>

Namespace DrmFindQty

	Public Class DrumQty
		Public ItemArr() As String
		Public StrtPos As Integer

	Public Function DFindQty(ByVal Itmarr() As String, ByVal StrtPos As Integer) As Integer

	Dim nm As String = Itmarr(StrtPos)
        Dim i As Integer

        Try

            For i = strtpos To UBound(Itmarr)

                If itmarr(i) <> nm Then
                    Exit For
                End If

            Next

            Return i - strtpos

        Catch Ex As Exception
            
	End Try

    End Function

	  End Class

End Namespace
