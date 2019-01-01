using System;
using System.Reflection;
using System.ComponentModel;

[assembly:AssemblyKeyFile("Hazel.CSP_Satwadhir.snk")]	//037afa5399917ef5
[assembly:AssemblyVersion("1.0.0.0")]
[assembly:CLSCompliant(true)]

namespace DrmCrossArgmt{

		public class DrmCord : IComponent{
			private double R1 ;
			private double R2 ;
			private double R3 ;		
			private double Gap; 
			private double Rds ;
			private int Flg;
			
			private double Xx ;
			private double Yy ;
			private double Zz ;


		public double DR1{
			get{return R1;}
			set{R1 = value;}
		}

		public double DR2{
			get{return R2;}
			set{R2 = value;}
		}

		public double DR3{
			get{return R3;}
			set{R3 = value;}
		}

		public double DGap{
			get{return Gap;}
			set{Gap = value;}
		}
	
		public double DR{
			get{return Rds;}
			set{Rds = value;}
		}
		
		public int Sgn{
			get{return Flg;}
			set{Flg = value;}
		}

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


	public double GetDX(double X, double Y, double Z, double R, double H, int Sgn){
			
			if (Sgn == 0 )
			{

				DX = X + (R * 2);

			return DX;
			}

			if (Sgn == 1 )
			{
			
				DX = (X * 2) + (R * 2);		//Calc X Dimns			
		
			return DX;
			}

			if (Sgn == 2 )
			{

				DX = Y + (R * 2);

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


	public double GetDY(double X, double Y, double Z, double R, double H, int Sgn){
			
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

	
	public double GetDZ(double X, double Y, double Z, double R, Double H, int Sgn){

			if (Sgn == 0 )
			{

				DZ = R;

			return DZ;
		
			}
				

			if(Sgn == 1)
			{ 
			
			DZ = Z + R;     //Drum Radious is always smaller one :: R = Dl Or Dw
						
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

		
		
		
		
		public double GetTrnglArea(double Rds1, double Rds2, double Rds3, double Gapx){
			double Area, S;
			double AL = Rds1 + Rds2 + Gapx;
			double B = Rds2 + Rds3;
			double C = Rds1 + Rds3;

			S = (AL + B + C) * 0.5;
			
			Area = S * ((S - AL) * (S - B) * (S - C));
			
			Area = Math.Pow(Area, 0.5);
			
			return Area;
		
		}
		
		public double GetAltitudeY(double Rds1, double Rds2, double Rds3, double Gapx){
				double AltitudeY, A;
				double L = Rds1 + Rds2 + Gapx;
				
				A = GetTrnglArea(Rds1, Rds2, Rds3, Gapx);
				
				AltitudeY = (2 * A) / L;
				
				return AltitudeY;
		}

		public double GetBaseX(double Rds1, double Rds2, double Rds3, double Gapx){
				double BaseX, A;
				double AL;
				double B = Rds2 + Rds3;
				double C = Rds1 + Rds3;
				
				AL = GetAltitudeY(Rds1, Rds2, Rds3, Gapx);
				
				A = GetTrnglArea(Rds1, Rds2, Rds3, Gapx);
				
				BaseX = (2 * A) / AL;
				
				return BaseX;
		}

		public double GetDepthZ(double Rds1, double Rds2, double Rds3, double Gapx){
				double DepthZ;

				DepthZ = Gapx;
				
				return DepthZ;
		}

		public double GetLa(double Rds1, double Rds2, double Rds3, double Gapx){
								
				return Rds1 + Rds2 + Gapx;

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
