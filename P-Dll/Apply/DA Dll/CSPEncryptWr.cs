//Discription :=> Programme written here finally when stream closed then encrypt these program to security of standard purpose when required use whataver needed by decrypting it, And also Written the one file to others file.
//Make Date :=> 10 May 2K8, 10.22 AM
//Programar :=> Satwadhir Pawar 9323974665
//Project :=> Hazel Infotech ->> Container Stuff


namespace CSPEncriptWr{
   public class Parag{
		public string Ifile;
		public string Ofile;
		public string DEKey;
		public int De;
	
	private static void Encrypt(System.IO.Stream source, System.IO.Stream target, string key){
		byte[] buffer = new byte[key.Length];
		while(source.Position < source.Length){
			int n = source.Read(buffer, 0, buffer.Length);
			for(int i = 0; i < n; i++)
				buffer[i] = (byte) (buffer[i] ^ key[i]);
			target.Write(buffer, 0, n);
		}
	}
	
	private static void WriterDPEWR(System.IO.Stream source, System.IO.Stream target){
		byte[] buffer = new byte[source.Length];
		while(source.Position < source.Length){
			int n = source.Read(buffer, 0, buffer.Length);
			for(int i = 0; i < n; i++)
				buffer[i] = buffer[i];	
			target.Write(buffer, 0, n);
		}
	}
		
	public int DEncript(){
				if(De == 1){
			using(System.IO.FileStream fin = new System.IO.FileStream(Ifile, System.IO.FileMode.Open)){
			using(System.IO.FileStream fout = new System.IO.FileStream(Ofile, System.IO.FileMode.Create)){
				Encrypt(fin, fout, DEKey);	
			}
			}			
			}
			return De;
		}
		
	public int WrProgCSP(){
				if(De == 5){
			using(System.IO.FileStream Fin = new System.IO.FileStream(Ifile, System.IO.FileMode.Open)){
			using(System.IO.FileStream Fout = new System.IO.FileStream(Ofile, System.IO.FileMode.OpenOrCreate)){
				WriterDPEWR(Fin, Fout);
			}
			}
			}
			return De;
		}	

		}
	}
