//	Program Name: - CSPDbtracK.cs
//	Programmer Name:- Satwadhir B. Pawar Mob No. :- 9323974665
//	Description:-  Database related query stuff is done through these assembly
//	Company Name:-Hazel Infotech LTD.
//	Project Name: - Container Stuffing Plus
//	Date:- 12 Augest 2K8 2.44 PM (Modified Time)

using System;
using System.Data;
using System.Data.OleDb;
using System.Reflection;
using System.ComponentModel;

[assembly:AssemblyKeyFile("Hazel.CSP_Satwadhir.snk")] 		//037afa5399917ef5
[assembly:AssemblyVersion("1.0.0.0")]
[assembly:CLSCompliant(true)]


namespace CSPDbSrt{

	public class DgvManage : IComponent{

		
		public bool DgvDbOrientFlg(int Orient){
			
			if (Orient == 6)
			{
				return true;
			}
			
			if (Orient == 2)
			{
				return false;
			}
		return false;
		}
		
		public double DbDimPerim(double L, double W, double H){
		
			return L + W + H;			

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