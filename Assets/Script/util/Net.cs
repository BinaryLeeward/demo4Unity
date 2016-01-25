using UnityEngine;
using System;
using System.Collections;
using System.Net.Sockets;
using System.Linq;
using com.binaryleeward.entity;

namespace com.binaryleeward.util{

	public class Net{

		public static void TestClient(){
		try{
			Int32 port = 9999;
			TcpClient cli = new TcpClient ("localhost", port);
			User u = new User();
			u.Id = 1;
			u.Name = "unity";
				string json = JsonUtil.Serialize(u);
			Byte[] jsonByte = System.Text.Encoding.UTF8.GetBytes(json);
			Byte[] data = new Byte[1+2+jsonByte.Length]; 
			NetworkStream ns = cli.GetStream();
			data[0] = (byte)2;

				
			Debug.Log(jsonByte.Length);
			Debug.Log(BitConverter.ToString(jsonByte));
			BitConverter.GetBytes((Int16)jsonByte.Length).CopyTo(data,1);
				jsonByte.CopyTo(data,3);
			ns.Write(data,0,data.Length);

			//data = new byte[256];
			//Int32 bytes = ns.Read(data, 0, data.Length);
			//string response = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
			//Debug.Log(response);
			ns.Close();
			cli.Close();
		}catch(Exception e){
				Debug.Log(e.Message);
			}
		}
	}

}