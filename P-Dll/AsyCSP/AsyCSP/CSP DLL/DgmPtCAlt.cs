//	Program Name: - DgmPtCAlt.cs
//	Programmer Name:- Satwadhir B. Pawar Mob No. :- 9323974665
//	Description:-  Finding out drum mid points from the X, Y, Z Starting points from the box Geometry to drum in Cross Arrangement
//	Company Name:-Hazel Infotech LTD.
//	Project Name: - Container Stuffing Plus
//	Date:- 20 August 2K8 10.55 AM (Modified Time)

//$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

using System;
using System.Reflection;
using System.ComponentModel;
using eCSP.HIL;

[assembly:AssemblyKeyFile("Hazel.CSP_Satwadhir.snk")]	//037afa5399917ef5
[assembly:AssemblyVersion("1.1.0.0")]
[assembly:CLSCompliant(true)]

namespace DrmCrossArgmt{

		public class DrmGMCord : IComponent{
			
			private double R1;
			private double R2;
			private double R3;		
			private double Gap; 
			private double Rds;
			private int DFlg;
			
			private double Xpt;
			private double Ypt;
			private double Zpt;

			private double XdPt;
			private double YdPt;
			private double ZdPt;

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
	
			get{return DFlg;}
			set{DFlg = value;}
		}

		public double DXpt{

			get{return Xpt;}
			set{Xpt = value;}
		}

		public double DYpt{
			
			get{return Ypt;}
			set{Ypt = value;}
		}

		public double DZpt{
			
			get{return Zpt;}
			set{Zpt = value;}
		}

//***********************************************************************************************************************
		
		public double DrmXpt{

			get{return XdPt;}
			set{XdPt = value;}
		}

		public double DrmYpt{

			get{return YdPt;}
			set{YdPt = value;}
		}

		public double DrmZpt{

			get{return ZdPt;}
			set{ZdPt = value;}
		}		

	public double DCrPlmntXpt(double X, double Y, double Z, double R, double H, int Sgn){
			
			if (Sgn == 0 )
			{

				DXpt = X + (R * 2);

			return DXpt;
			}

			if (Sgn == 1 )
			{
			
				DXpt = (X * 2) + (R * 2);		//Calc X Dimns			
		
			return DXpt;
			}

			if (Sgn == 2 )
			{

				DXpt = Y + (R * 2);

			return DXpt;			
			}
			
			if (Sgn == 3 )
			{

				DXpt = Y + R;

			return DXpt;						
			}
			
			if (Sgn == 4 )
			{

				DXpt = Y;

			return DXpt;		
			}
			
			if (Sgn == 5 )
			{

				DXpt = X + R;

			return DXpt;		
			}

			return DXpt;			
		}

	public double DCrPlmntDY(double X, double Y, double Z, double R, double H, int Sgn){
			
			if (Sgn == 0 )
			{

				DYpt = R;

			return DYpt;		
			}

			if (Sgn == 1 )
			{
			
				DYpt = Y * 0.5;		//Calc Y Dimns			

			return DYpt;
			}

			if (Sgn == 2)
			{			

				 DYpt = Y + R; 			

			return DYpt;			
			}
			
			if (Sgn == 3)
			{			

				 DYpt = X + R; 			

			return DYpt;			
			}

			return DYpt;
		}
	
	public double DCrPlmntZpt(double X, double Y, double Z, double R, Double H, int Sgn){

			if (Sgn == 0 )
			{
				DZpt = R;

			return DZpt;		
			}
			
			if(Sgn == 1)
			{ 
			
			DZpt = Z + R;     //Drum Radious is always smaller one :: R = Dl Or Dw
						
			return DZpt;
			}

			if(Sgn == 2)
			{
	
			 DZpt = Y + Z;  		//Drum Radious is always smaller one :: R = Dl Or Dw
			 						
			return DZpt;
			}
			
			if(Sgn == 3)
			{

			 DZpt = H * 0.5;  		//Drum Radious is always smaller one :: R = Dl Or Dw
			 						
			return DZpt;
			}
			
			return DZpt;			
		}
		
		public double GetTrnglArea(double Rds1, double Rds2, double Rds3, double Gapx){
			
			double Area, S;
			double AL = Rds1 + Rds2 + Gapx;
			double B = Rds2 + Rds3;
			double C = Rds1 + Rds3;

			S = (AL + B + C) * 0.5;
			
			Area = S * ((S - AL) * (S - B) * (S - C));
			
			Area = Math.Pow(Area, 0.5);
			Area = Math.Round(Area, 5);
			return Area;		
		}
		
		public double GetAltitudeY(double Rds1, double Rds2, double Rds3, double Gapx){
		
				double AltitudeY, A;
				double L = Rds1 + Rds2 + Gapx;
				
				A = GetTrnglArea(Rds1, Rds2, Rds3, Gapx);
				
				AltitudeY = (2 * A) / L;
				AltitudeY = Math.Round(AltitudeY, 5);
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
				BaseX = Math.Round(BaseX, 5);
				return BaseX;
		}

		public double GetDepthZ(double Rds1, double Rds2, double Rds3, double Gapx){
				
				double DepthZ;

				DepthZ = Gapx;
				DepthZ = Math.Round(DepthZ, 5);
				return DepthZ;
		}

		public double GetLa(double Rds1, double Rds2, double Rds3, double Gapx){
								
				return Math.Round((Rds1 + Rds2 + Gapx), 5);

		}

//&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&		
		
	public double XDrumPt(double X, double Y, double Z, double R, double H, int Sgn){
			
			if (Sgn == 0 )
			{
				DrmXpt = R ;

			return DrmXpt;
			}

			if (Sgn == 1 )
			{			
				DrmXpt = X * 0.5;			//Calc X Dimns			
		
			return DrmXpt;
			}

			if (Sgn == 2 )
			{
				DrmXpt = Y * 0.5;

			return DrmXpt;			
			}
			
			if (Sgn == 3 )
			{
				DrmXpt = Y + R;

			return DrmXpt;			
			}
			
			if (Sgn == 4 )
			{
				DrmXpt = Y;

			return DrmXpt;			
			}

			if (Sgn == 5 )
			{

				DrmXpt = X + R;

			return DrmXpt;		
			}

		return DrmXpt;
	}

	public double YDrumPt(double X, double Y, double Z, double R, double H, int Sgn){
			
			if (Sgn == 0 )
			{
				DrmYpt = R;

			return DrmYpt;		
			}

			if (Sgn == 1 )
			{			
				DrmYpt = Y * 0.5;			//Calc Y Dimns			

			return DrmYpt;
			}

			if (Sgn == 2)
			{
				 DrmYpt = Y + R; 			

			return DrmYpt;			
			}
			
			if (Sgn == 3)
			{
				 DrmYpt = X + R; 			

			return DrmYpt;			
			}

		return DrmYpt;
		}

	public double ZDrumPt(double X, double Y, double Z, double R, Double H, int Sgn){

			if (Sgn == 0 )
			{
				DrmZpt = R;

			return DrmZpt;		
			}				

			if(Sgn == 1)
			{			
				DrmZpt = Z + R;     		//Drum Radious is always smaller one :: R = Dl Or Dw
						
			return DrmZpt;
			}

			if(Sgn == 2)
			{	
			   DrmZpt = Y + Z;  			//Drum Radious is always smaller one :: R = Dl Or Dw
			 						
			return DrmZpt;
			}
			
			if(Sgn == 3)
			{
			   DrmZpt = H * 0.5;  			//Drum Radious is always smaller one :: R = Dl Or Dw
			 						
			return DrmZpt;
			}
			
			if(Sgn == 4)
			{
			   DrmZpt = Z + (H * 0.5);		//Height of First Row First Column

			return DrmZpt;
			}
			
		return DrmZpt;			
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

