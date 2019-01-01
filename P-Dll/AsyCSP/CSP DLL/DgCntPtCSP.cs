//	Program Name: - DgCntPtCSP.cs
//	Programmer Name:- Satwadhir B. Pawar Mob No. :- 9323974665
//	Description:-  Finding out drum mid points from the X, Y, Z Starting points from the box Geometry to drum
//	Company Name:-Hazel Infotech LTD.
//	Project Name: - Container Stuffing Plus
//	Date:- 20 August 2K8 10.41 AM (Modified Time)

//$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

using System;
using System.Reflection;
using System.ComponentModel;
using eCSP.HIL;

[assembly:AssemblyKeyFile("Hazel.CSP_Satwadhir.snk")] 	//037afa5399917ef5
[assembly:AssemblyVersion("1.1.0.0")]
[assembly:CLSCompliant(true)]

namespace DgCntPt{
				
		public class DgeomCntPt : IComponent{

		private double Xpt ;
		private double Ypt ;
		private double Zpt ;
		
		public double DrmPtX{

			get{return Xpt;}
			set{Xpt = value;}
		}

		public double DrmPtY{

			get{return Ypt;}
			set{Ypt = value;}
		}

		public double DrmPtZ{

			get{return Zpt;}
			set{Zpt = value;}
		}		

	public double DgX(double X, double Y, double Z, double R, double H, int Sgn){
			
			if (Sgn == 0 )
			{
				DrmPtX = R ;

			return DrmPtX;
			}

			if (Sgn == 1 )
			{			
				DrmPtX = X * 0.5;			//Calc X Dimns			
		
			return DrmPtX;
			}

			if (Sgn == 2 )
			{
				DrmPtX = Y * 0.5;

			return DrmPtX;			
			}
			
			if (Sgn == 3 )
			{
				DrmPtX = Y + R;

			return DrmPtX;			
			
			}
			
			if (Sgn == 4 )
			{
				DrmPtX = Y;

			return DrmPtX;			
			
			}
		return DrmPtX;
	}

	public double DgY(double X, double Y, double Z, double R, double H, int Sgn){
			
			if (Sgn == 0 )
			{
				DrmPtY = R;

			return DrmPtY;		
			}

			if (Sgn == 1 )
			{			
				DrmPtY = Y * 0.5;			//Calc Y Dimns			

			return DrmPtY;
			}

			if (Sgn == 2)
			{
				 DrmPtY = Y + R; 			

			return DrmPtY;			
			}
			
			if (Sgn == 3)
			{
				 DrmPtY = X + R; 			

			return DrmPtY;			
			}

		return DrmPtY;
		}

	public double DgZ(double X, double Y, double Z, double R, Double H, int Sgn){

			if (Sgn == 0 )
			{
				DrmPtZ = R;

			return DrmPtZ;		
			}				

			if(Sgn == 1)
			{			
				DrmPtZ = Z + R;     		//Drum Radious is always smaller one :: R = Dl Or Dw
						
			return DrmPtZ;
			}

			if(Sgn == 2)
			{	
			   DrmPtZ = Y + Z;  			//Drum Radious is always smaller one :: R = Dl Or Dw
			 						
			return DrmPtZ;
			}
			
			if(Sgn == 3)
			{
			   DrmPtZ = H * 0.5;  			//Drum Radious is always smaller one :: R = Dl Or Dw
			 						
			return DrmPtZ;
			}
			
		return DrmPtZ;			
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
