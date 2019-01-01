//	Program Name: - CSPContnr.cs
//	Programmer Name:- Satwadhir B. Pawar Mob No. :- 9323974665
//	Description:-  Container Dimention Calculated here 
//	Company Name:-Hazel Infotech LTD.
//	Project Name: - Container Stuffing Plus
//	Date:- 26 May 2K8 10.10 AM (Modified Time)

//$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

using System;
using System.Reflection;
using System.ComponentModel;

[assembly:AssemblyKeyFile("Hazel.CSP_Satwadhir.snk")] 	//037afa5399917ef5
[assembly:AssemblyVersion("1.0.0.0")]
[assembly:CLSCompliant(true)]


namespace CSPContnr{

   public class Satwa{

		public double cX;
		public double cY;
		public double cZ;
		public double Dngl;

// Dim Dlg As Single = ((Pt.x ^ 2) + (Pt.z ^ 2)) ^ 0.5

	public double Diagonal(){
		double Dlg = 0;
		double X = cX;
		double Z = cZ;

		Dlg = System.Math.Pow((System.Math.Pow(X, 2.0) + System.Math.Pow(Z, 2.0)), 0.5);
		return Dlg;
		}

 // Pt.z = Pt.x / (Pt.x / Dlg)
		
	public double Z_Point(){
		double Dlg = Dngl;
		double X = cX;
		double Z = 0;

		Z = (X / (X / Dlg));
		
		return Z;
		
		}

// Pt.z = Pt.z * 1.5

	public double Z_Pt(){
		double Z = cZ;

		return Z * 1.5;
		
		}
	
// Pt.x = Pt.x * 0.5
	
	public double X_Pt(){
		double X = cX;

		return X * 0.5;
		
		}

// Pt.y = Pt.y / 2

	public double Y_Pt(){
		double Y = cY;

		return Y * 0.5;
		
		}

// Dim Ang As Single = Math.Atan(Pt.x / DigLngth)

	public double AnglTan(){
		double X = cX;
		double Dlg = Dngl;
		double Angl = 0;
		
		Angl = System.Math.Atan(X / Dlg);

		return Angl;
			
		}

// Dim sFac As Single = 2.3 / Math.Acos(OldPtz / Dlg)

	public double sFactor(){
		double Z = cZ;
		double Dlg = Dngl;
		double sFactr = 0;
		
		sFactr = 2.3 / (System.Math.Acos(Z / Dlg));

		return sFactr;
			
		}


	}
}