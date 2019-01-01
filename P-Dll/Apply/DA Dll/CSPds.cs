//Discription :=> The Data Store in the database is finally collect and insert in to others database table
//Make Date :=> 16 May 2K8, 11.44 AM
//Programar :=> Satwadhir Pawar 9323974665
//Project :=> Hazel Infotech ->> Container Stuff

namespace CSPds{
	public class CSPWritter{
			
		public string DbPath;
		public string DbQueryi;
		public string DbQuerys;
			

			private static void DbInsert(double x, double y, double z, double r, double h){			
				System.Data.OleDb.OleDbConnection con = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=DbPath;Persist Security Info=False");
				con.Open();
				System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand(DbQueryi, con);
				Cmd.System.Data.OleDb.ExecuteNonQuery();
			}

			public int DbWritter(){	
				double X;
				double Y;
				double Z;
				double R;
				double H;							
				System.Data.OleDb.OleDbConnection con = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=DbPath;Persist Security Info=False");
				con.Open();
				System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand(DbQuerys, con);
				System.Data.OleDb.OleDbDataReader reader = cmd.System.Data.OleDb.ExecuteReader();
				while(reader.Read()){				
					X = reader("Xx")
					Y = reader("Yy")
					Z = reader("Zz")
					R = reader("Rr")
					H = reader("DHt")					
					DbInsert(X, Y, Z, R, H);
				}				
				reader.Close();
				con.Close();
			}	
	}

}
