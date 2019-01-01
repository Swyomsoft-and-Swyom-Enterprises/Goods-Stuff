//	Program Name: - DrmGmPtCSP.cs
//	Programmer Name:- Satwadhir B. Pawar Mob No. :- 9323974665
//	Description:-  Finding out drum mid points from the X, Y, Z Starting points from the box Geometry to drum
//	Company Name:-Hazel Infotech LTD.
//	Project Name: - Container Stuffing Plus
//	Date:- 23 July 2K8 9.44 PM (Modified Time)

//$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

using System;
using System.Reflection;
using System.ComponentModel;

[assembly:AssemblyKeyFile("Hazel.CSP_Satwadhir.snk")] 	//037afa5399917ef5
[assembly:AssemblyVersion("1.0.0.0")]
[assembly:CLSCompliant(true)]

namespace DrumGmCntPt{
				
     public class DrmGeomCntPt : IComponent{

		private double Xd ;
		private double Yd ;
		private double Zd ;
						
		public double DrmX{

			get{return Xd;}
			set{Xd = value;}
		}

		public double DrmY{

			get{return Yd;}
			set{Yd = value;}
		}

		public double DrmZ{

			get{return Zd;}
			set{Zd = value;}
	}
		
	public double XDrum(double X, double Y, double Z, double R, double H, int Sgn){
			
			if (Sgn == 0 )
			{
				DrmX = R ;

			return DrmX;
			}

			if (Sgn == 1 )
			{			
				DrmX = X * 0.5;			//Calc X Dimns			
		
			return DrmX;
			}

			if (Sgn == 2 )
			{
				DrmX = Y * 0.5;

			return DrmX;			
			}
			
			if (Sgn == 3 )
			{
				DrmX = Y + R;

			return DrmX;			
			
			}
			
			if (Sgn == 4 )
			{
				DrmX = Y;

			return DrmX;			
			
			}

		return DrmX;
	}

	public double YDrum(double X, double Y, double Z, double R, double H, int Sgn){
			
			if (Sgn == 0 )
			{
				DrmY = R;

			return DrmY;		
			}

			if (Sgn == 1 )
			{			
				DrmY = Y * 0.5;			//Calc Y Dimns			

			return DrmY;
			}

			if (Sgn == 2)
			{
				 DrmY = Y + R; 			

			return DrmY;			
			}
			
			if (Sgn == 3)
			{
				 DrmY = X + R; 			

			return DrmY;			
			}

		return DrmY;

	}

	public double ZDrum(double X, double Y, double Z, double R, Double H, int Sgn){

			if (Sgn == 0 )
			{
				DrmZ = R;

			return DrmZ;		
			}				

			if(Sgn == 1)
			{			
				DrmZ = Z + R;     		//Drum Radious is always smaller one :: R = Dl Or Dw
						
			return DrmZ;
			}

			if(Sgn == 2)
			{	
			   DrmZ = Y + Z;  			//Drum Radious is always smaller one :: R = Dl Or Dw
			 						
			return DrmZ;
			}
			
			if(Sgn == 3)
			{
			   DrmZ = H * 0.5;  			//Drum Radious is always smaller one :: R = Dl Or Dw
			 						
			return DrmZ;
			}
			
			if(Sgn == 4)
			{
			   DrmZ = Z + (H * 0.5);		//Height of First Row First Column

			return DrmZ;
			}
			
		return DrmZ;			

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
