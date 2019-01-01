using System;
using System.Reflection;
using System.ComponentModel;

[assembly:AssemblyKeyFile("Hazel.CSP_Satwadhir.snk")] 	//037afa5399917ef5
[assembly:AssemblyVersion("1.0.0.0")]
[assembly:CLSCompliant(true)]

namespace DrumCSP{
				
		public class CDrum : IComponent{
		
			private double Qty;
			private double Wt;
			public double x;
			public double y;
			public double z;

		public double DmQty{
			get{return Qty;}
			set{Qty = value;}
		}
		
		public double DmWt{
			get{return Wt;}
			set{Wt = value;}
		}

		//IComponent Implimentation	
		private ISite site;
		
		public ISite Site{
			get{return site;}
			set{site = value;}
		}

		public event EventHandler Disposed;

		public void Dispose(){
			//Release unmanaged resources
			
			if(Disposed != null)				
				Disposed(this, EventArgs.Empty);

		}

}			



}