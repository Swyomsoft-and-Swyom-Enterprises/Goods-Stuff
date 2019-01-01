'	Program Name: - DcpCSP.cs
'	Programmer Name:- Satwadhir B. Pawar Mob No. :- 9323974665
'	Description:-  The dimensions of container and the actual dimensions are in some limit, i.e. dimension control of container
'	Company Name:-Hazel Infotech LTD.
'	Project Name: - Container Stuffing Plus
'	Date:- 20 August 2K8 10.45 AM (Modified Time)
'
'$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

Imports System
Imports System.Reflection
Imports System.ComponentModel
Imports eCSP.HIL

<assembly:AssemblyKeyFile("Hazel.CSP_Satwadhir.snk")> 	'037afa5399917ef5
<assembly:AssemblyVersion("1.1.0.0")>
<assembly:CLSCompliant(true)>

Namespace DistArCntrlFlg

	Public Class AreaControl
		Public DistCFlg As Int16 = 0
		Public MDistCalc As Double
		Public DistAdd As Double
		Public DistCSz as Double

	Public Function DCntrlFlag() as Int16
		Dim DTchk As Double = MDistCalc + DistAdd
		If Not DTchk <= DistCSz Then
			DistCFlg = 1
		Else 
			DistCFlg = 2
		End If

		Return DistCFlg

	 End Function

  End Class

End Namespace
