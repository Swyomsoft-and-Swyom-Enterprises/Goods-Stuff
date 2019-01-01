//	Program Name: - CSPDbtracK.cs
//	Programmer Name:- Satwadhir B. Pawar Mob No. :- 9323974665
//	Description:-  Database related query stuff is done through these assembly
//	Company Name:-Hazel Infotech LTD.
//	Project Name: - Container Stuffing Plus
//	Date:- 29 July 2K8 4.13 AM (Modified Time)

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

		public int DgvSort(){
		
		OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db\\sales.mdb");
		con.Open();
		OleDbCommand cmd = new OleDbCommand("select pno, price, stock from products", con);
		OleDbDataReader reader = cmd.ExecuteReader();
		while(reader.Read())
			Console.WriteLine("{0, -6}{1, 10:0.00}{2, 8}", reader.GetInt32(0), reader[1], reader["stock"]);
		reader.Close();
		con.Close();
		
		return 0;		
		
		}

		public int DgvDbFill(int SrNo, string INm, string Pck, double Sz, double L, double W, double H, int Ori, double Wt, int MxQty, int Qty){
		
		OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source= \\container.mdb;Persist Security Info=False");
		con.Open();
		OleDbCommand cmd = new OleDbCommand();

		cmd.CommandText = "insert into BoxaA values (SrNo, 'INm', 'Pck', Sz)";


		//cmd.CommandText = "select pno, price, stock from products";
		//	OleDbCommand cmd = new OleDbCommand("select pno, price, stock from products", con);
		OleDbDataReader reader = cmd.ExecuteReader();
		while(reader.Read())
			Console.WriteLine("{0, -6}{1, 10:0.00}{2, 8}", reader.GetInt32(0), reader[1], reader["stock"]);
		reader.Close();
		con.Close();
		
		return 0;		
		
		}
		
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