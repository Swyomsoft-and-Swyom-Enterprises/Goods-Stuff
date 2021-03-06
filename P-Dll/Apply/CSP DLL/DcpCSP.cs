//	Program Name: - DcpCSP.cs
//	Programmer Name:- Satwadhir B. Pawar Mob No. :- 9323974665
//	Description:-  Finding out drum mid points from the X, Y, Z Starting points from the boxes
//	Company Name:-Hazel Infotech LTD.
//	Project Name: - Container Stuffing Plus
//	Date:- 31 May 2K8 3.02 PM (Modified Time)

//$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

using System;
using System.Reflection;
using System.ComponentModel;

[assembly:AssemblyKeyFile("Hazel.CSP_Satwadhir.snk")] 	//037afa5399917ef5
[assembly:AssemblyVersion("1.0.0.0")]
[assembly:CLSCompliant(true)]

namespace DrumCtrPt{
		
		public class DMiddlePt : IComponent{

		private double Xx ;
		private double Yy ;
		private double Zz ;
		private double Rds ;
		private double Ht ;
		private int Flg;

		public double DX{

			get{return Xx;}
			set{Xx = value;}
		}

		public double DY{

			get{return Yy;}
			set{Yy = value;}
		}

		public double DZ{

			get{return Zz;}
			set{Zz = value;}
		}
	
		public double DR{

			get{return Rds;}
			set{Rds = value;}
		}

		public double DH{

			get{return Ht;}
			set{Ht = value;}
		}

		public int Sgn{

			get{return Flg;}
			set{Flg = value;}
		}

	public double SetDX(double X, double Y, double Z, double R, double H, int Sgn){
			
			if (Sgn == 0 )
			{
				DX = R +0.01;

			return DX;
			}

			if (Sgn == 1 )
			{			
				DX = X * 0.5 + 0.01;		//Calc X Dimns			
		
			return DX;
			}

			if (Sgn == 2 )
			{
				DX = Y * 0.5 + 0.01;

			return DX;			
			}
			
			if (Sgn == 3 )
			{
				DX = Y + R;

			return DX;			
			
			}
			
			if (Sgn == 4 )
			{
				DX = Y;

			return DX;			
			
			}
			return DX;
			
		}

	public double SetDY(double X, double Y, double Z, double R, double H, int Sgn){
			
			if (Sgn == 0 )
			{
				DY = R;

			return DY;
		
			}

			if (Sgn == 1 )
			{			
				DY = Y * 0.5;		//Calc Y Dimns			

			return DY;
			}

			if (Sgn == 2)
			{
				 DY = Y + R; 			

			return DY;			
			}
			
			if (Sgn == 3)
			{
				 DY = X + R; 			

			return DY;			
			}

			return DY;
		}

	
	public double SetDZ(double X, double Y, double Z, double R, Double H, int Sgn){

			if (Sgn == 0 )
			{
				DZ = R;

			return DZ;
		
			}				

			if(Sgn == 1)
			{			
				DZ = Z + (H * 0.5);     //Drum Radious is always smaller one :: R = Dl Or Dw
						
			return DZ;
			}

			if(Sgn == 2)
			{	
				 DZ = Y + Z;  		//Drum Radious is always smaller one :: R = Dl Or Dw
			 						
			return DZ;
			}
			
			if(Sgn == 3)
			{
			 	DZ = H * 0.5;  		//Drum Radious is always smaller one :: R = Dl Or Dw
			 						
			return DZ;
			}			
			return DZ;
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
