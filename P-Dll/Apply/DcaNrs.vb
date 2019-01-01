'	Program Name: - DcaNrs.vb
'	Programmer Name:- Satwadhir B. Pawar Mob No. :- 9323974665
'	Description:-  The dimensions of container and the actual dimensions are in some limit, i.e. dimension control of container and also calculation of starting points of drum cross stuff second rows
'	Company Name:-Hazel Infotech LTD.
'	Project Name: - Container Stuffing Plus
'	Date:- 15 July 2K8 12.07 PM (Modified Time)
'
'$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

Imports System
Imports System.Reflection
Imports System.ComponentModel

<assembly:AssemblyKeyFile("Hazel.CSP_Satwadhir.snk")> 	'037afa5399917ef5
<assembly:AssemblyVersion("1.0.0.0")>
<assembly:CLSCompliant(true)>

Namespace DrmCANxtRsPt

	Public Class AreaControl
		Public DistCFlg As Int16 = 0
		Public MDistCalc As Double
		Public DistAdd As Double
		Public DistCSz as Double

	Public Function DCntrlFlag() As Int16
		Dim DTchk As Double = MDistCalc + DistAdd
		If Not DTchk <= DistCSz Then
			DistCFlg = 1
		Else 
			DistCFlg = 2
		End If

		Return DistCFlg

	 End Function

  End Class

	Public Class NxtCptSDH
		Public CntX As Double
		Public CntY As Double
		Public CntZ As Double
	
		Public CtDHt As Double		
		Public CtDR As Double		

		Public CL As Double		
		Public CW As Double		
		Public CH As Double		
	
		Public PsDHt As Double		
		Public PsDR As Double		
		
		Public Sgn As Int16 = 0
		
	Public Function Dpt_X(ByVal _X As Double, ByVal _Y As Double, ByVal _Z As Double, ByVal _CtDHt As Double, ByVal _CtDR As Double, ByVal _CL As Double, ByVal _CW As Double, ByVal _CH As Double, ByVal _PsDHt As Double, ByVal _PsDR As Double) As Double
	
		If Sgn = 0 Then

			Dim Dia As Double = 2 * _CtDR

			CntX = _X + _PsDR + Dia
		
			If CntX < _CW Then
		
				CntX = _X + _PsDR		

			Else

				CntX = _CtDR				

			End If
		
		Return CntX		

		End If

		If Sgn = 1 Then
		
			Dim RDif As Double = _CtDR - _PsDR

			CntX = _X + _PsDR		
			CntX = CntX + RDif
		
		Return CntX 		

		End If

	Return CntX

	End Function

	Public Function Dpt_Y(ByVal _X As Double, ByVal _Y As Double, ByVal _Z As Double, ByVal _CtDHt As Double, ByVal _CtDR As Double, ByVal _CL As Double, ByVal _CW As Double, ByVal _CH As Double, ByVal _PsDHt As Double, ByVal _PsDR As Double) As Double
	
		If Sgn = 0 Then

			Dim Dia As Double = 2 * _CtDR
			
			Dim Val As Double = _Y - _PsDR

						
			Val = (2 * _PsDR) - _Y

			CntY = _Y + Val + _PsDR + Dia
		
			If CntY < _CL Then
		
				CntY = Val + _Y

			Else

				CntY = CntY + _CtDR				

			End If
		End If

		If Sgn = 1 Then

			Dim Dia As Double = 2 * _CtDR
			
			Dim Val As Double = _Y - _PsDR
						
			Val = (2 * _PsDR) - _Y

			CntY = _Y + Val + _PsDR + Dia
		
			If CntY < _CL Then
		
				CntY = Val + _Y

			Else

				CntY = CntY + _CtDR				

			End If
		End If

	Return CntY

	End Function

	Public Function Dpt_Z(ByVal _X As Double, ByVal _Y As Double, ByVal _Z As Double, ByVal _CtDHt As Double, ByVal _CtDR As Double, ByVal _CL As Double, ByVal _CW As Double, ByVal _CH As Double, ByVal _PsDHt As Double, ByVal _PsDR As Double) As Double
	
		_Z = _Z + (_PsDHt * 0.5) 		
		
		CntZ = _Z + _CtDHt
		
		If CntZ < _CH Then
		
			CntZ = _Z + (_CtDHt * 0.5)

		Else

			CntZ = 0				

		End If

	Return CntZ

	End Function
	
  End Class

End Namespace
