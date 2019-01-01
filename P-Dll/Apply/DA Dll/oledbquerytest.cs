using System;
using System.Data;
using System.Data.OleDb;

class Test{

	public static void Main(){
		OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db\\sales.mdb");
		con.Open();
		OleDbCommand cmd = new OleDbCommand("select pno, price, stock from products", con);
		OleDbDataReader reader = cmd.ExecuteReader();
		while(reader.Read())
			Console.WriteLine("{0, -6}{1, 10:0.00}{2, 8}", reader.GetInt32(0), reader[1], reader["stock"]);
		reader.Close();
		con.Close();
	}
}













