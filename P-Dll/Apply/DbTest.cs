using CSPDbSrt;
using System;

class Client{
	
	public static void Main(){
		

	DgvManage Dm = new DgvManage();
		try{
			int flg = Dm.DgvSort();
			
		}catch(Exception ex){
			Console.WriteLine("Order failed : {0}", ex.Message);
		}
	
		

	}
}