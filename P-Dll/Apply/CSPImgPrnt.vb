'	Program Name: - CSPImgPrnt.vb
'	Programmer Name:- Satwadhir B. Pawar Mob No. :- 9323974665
'	Description:-  The text name is print to the PNG Image
'	Company Name:-Hazel Infotech LTD.
'	Project Name: - Container Stuffing Plus
'	Date:- 22 June 2K9 10.30 AM (Modified Time)
'
'$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

Imports System
Imports System.Reflection
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Imaging
'Imports eCSP.HIL

<assembly:AssemblyKeyFile("Hazel.CSP_Satwadhir.snk")> 	'037afa5399917ef5
<assembly:AssemblyVersion("1.0.0.0")>
<assembly:CLSCompliant(true)>

Namespace MkTxtToImgP

	Public Class TxtToImgP
		
		Public ImgFlNm As String
		Public PrintTxt As String

	Public Function PrintPNGImage(ByVal ImgFlNm As String, ByVal PrintTxt As String) As Boolean


	        Try

			Dim FontColor As Color = Color.Black
			Dim BackColor As Color = Color.White
			Dim FontName As String = "Times New Roman"
			Dim FontSize As Integer = 14
			Dim Height As Integer = 30
			Dim Width As Integer = 89
			Dim objBitmap As New Bitmap(Width, Height, PixelFormat.Format24bppRgb)
			Dim objGraphics As Graphics = Graphics.FromImage(objBitmap)
			Dim objFont As New Font(FontName, FontSize, FontStyle.Bold, GraphicsUnit.Pixel)

			Dim X1, Y1 As Single
			Dim fs As Integer = CInt(FontSize / 2)
			Dim sl As Integer = PrintTxt.Length

			X1 = CInt((Width / 2) - (2 * fs)) - (4 * sl)
			Y1 = CInt((Height / 2) - fs)

			Dim objPoint As New PointF(X1, Y1)
			Dim objBrushForeColor As New SolidBrush(FontColor)
			Dim objBrushBackColor As New SolidBrush(BackColor)
			
			objGraphics.FillRectangle(objBrushBackColor, 0, 0, Width, Height)
			objGraphics.DrawString(PrintTxt, objFont, objBrushForeColor, objPoint)
			objBitmap.Save(ImgFlNm, ImageFormat.Png)
	
	        Catch Ex As Exception
        		MsgBox(Ex.Message)
			Msgbox(Ex.ToString)    
		End Try

	End Function

	  End Class

End Namespace
