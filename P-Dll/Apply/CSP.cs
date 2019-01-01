//	Program Name: - CSP.cs
//	Programmer Name:- Satwadhir B. Pawar Mob No. :- 9323974665
//	Description:-  All dll versioning master dll
//	Company Name:-Hazel Infotech LTD.
//	Project Name: - Container Stuffing Plus
//	Date:- 19 August 2K8 10.48 AM (Modified Time)

//$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

using System;
using System.Reflection;
using System.ComponentModel;

[assembly:AssemblyKeyFile("Hazel.CSP_Satwadhir.snk")] 	//037afa5399917ef5
[assembly:AssemblyVersion("1.1.0.0")]
[assembly:CLSCompliant(true)]

namespace CSP.HIL{

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