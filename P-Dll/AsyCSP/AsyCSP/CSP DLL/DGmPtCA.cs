//	Program Name: - DGmPtCA.cs
//	Programmer Name:- Satwadhir B. Pawar Mob No. :- 9323974665
//	Description:-  Finding out drum mid points from the X, Y, Z Starting points from the box Geometry to drum in cross stuff arrangement
//	Company Name:-Hazel Infotech LTD.
//	Project Name: - Container Stuffing Plus
//	Date:- 20 August 2K8 11.28 AM (Modified Time)

//$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

using System;
using System.Reflection;
using System.ComponentModel;
using eCSP.HIL;

[assembly:AssemblyKeyFile("Hazel.CSP_Satwadhir.snk")] 	//037afa5399917ef5
[assembly:AssemblyVersion("1.1.0.0")]
[assembly:CLSCompliant(true)]

namespace DrmMPtCA{
				
     public class DrmGMPt : IComponent{

		private double Xp ;
		private double Yp ;
		private double Zp ;
						
		public double PtX{

			get{return Xp;}
			set{Xp = value;}
		}

		public double PtY{

			get{return Yp;}
			set{Yp = value;}
		}

		public double PtZ{

			get{return Zp;}
			set{Zp = value;}
	}
		
	public double X_DrmCA(double X, double Y, double Z, double R, double H, int Sgn){
			
			if (Sgn == 0 )
			{
				PtX = R ;

			return PtX;
			}

			if (Sgn == 1 )
			{			
				PtX = X * 0.5;			//Calc X Dimns			
		
			return PtX;
			}

			if (Sgn == 2 )
			{
				PtX = Y * 0.5;

			return PtX;			
			}
			
			if (Sgn == 3 )
			{
				PtX = Y + R;

			return PtX;			
			
			}
			
			if (Sgn == 4 )
			{
				PtX = Y;

			return PtX;			
			
			}

		return PtX;
	}

	public double Y_DrmCA(double X, double Y, double Z, double R, double H, int Sgn){
			
			if (Sgn == 0 )
			{
				PtY = R;

			return PtY;		
			}

			if (Sgn == 1 )
			{			
				PtY = Y * 0.5;			//Calc Y Dimns			

			return PtY;
			}

			if (Sgn == 2)
			{
				 PtY = Y + R; 			

			return PtY;			
			}
			
			if (Sgn == 3)
			{
				 PtY = X + R; 			

			return PtY;			
			}

		return PtY;

	}

	public double Z_DrmCA(double X, double Y, double Z, double R, Double H, int Sgn){

			if (Sgn == 0 )
			{
				PtZ = R;

			return PtZ;		
			}				

			if(Sgn == 1)
			{			
				PtZ = Z + R;     		//Drum Radious is always smaller one :: R = Dl Or Dw
						
			return PtZ;
			}

			if(Sgn == 2)
			{	
			   PtZ = Y + Z;  			//Drum Radious is always smaller one :: R = Dl Or Dw
			 						
			return PtZ;
			}
			
			if(Sgn == 3)
			{
			   PtZ = H * 0.5;  			//Drum Radious is always smaller one :: R = Dl Or Dw
			 						
			return PtZ;
			}
			
			if(Sgn == 4)
			{
			   PtZ = Z + (H * 0.5);		//Height of First Row First Column

			return PtZ;
			}
			
		return PtZ;			

	}

		//IComponent implementation
		
		private ISite site;

		public ISite Site{
			get{return site;}
			set{site = value;}
		}

		public event EventHandler Disposed;

		public void Dispose(){
			// Release unmanaged resources
			if(Disposed != null)
				Disposed(this, EventArgs.Empty);
		}
	}

}
















