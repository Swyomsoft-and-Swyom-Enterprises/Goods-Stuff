//	Program Name: - CSPs.cs
//	Programmer Name:- Satwadhir B. Pawar Mob No. :- 9323974665
//	Description:-  All dll versioning master dll
//	Company Name:-Hazel Infotech LTD.
//	Project Name: - Container Stuffing Plus
//	Date:- 22 May 2K9 10.59 AM / 4 Jully 2k9 12.44 PM (Modified Time)

//$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

using System;
using System.Reflection;
using System.ComponentModel;

[assembly:AssemblyKeyFile("Hazel.CSP_Satwadhir.snk")] 	//037afa5399917ef5
[assembly:AssemblyVersion("1.1.0.0")]
[assembly:CLSCompliant(true)]

namespace eCSP.HIL{

	public class Resolution{

		private double CnrVI;        
		private double CnrVII; 

	    public double VI{

			get{return CnrVI;}
			set{CnrVI = value;}
		}
        
	    public double VII{

			get{return CnrVII;}
			set{CnrVII = value;}
		}
	
	   public double Part()
		{
			return Convert.ToInt32(Math.Ceiling(VI / VII));
		}
		
	   public double Swell()
		{
			return Convert.ToInt32(Math.Floor(VI * VII));
		}
	  
	   public double Total()
		{
			return Convert.ToInt32(Math.Floor(VI + VII));
		}
		
	   public double WithTake()
		{
			return Convert.ToInt32(Math.Floor(VI - VII));
		}

	   public double Truncate()
		{
			return Convert.ToInt32(Math.Floor(VI));
		}

	}

      	public class CSPs : IComponent{
		
		private double DateTime;

	    public double DtTm{
	    
		get{return DateTime;}
		set{DateTime = value;}
	     }

	//public abstract void CSPValidate(double amount);

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