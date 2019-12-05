using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Chess_online {
	public class Server {

		TcpListener tcpListener;
		string ip;
		public readonly int port = 8088;
		public string IP { get => ip; }

		public Server() {
			tcpListener = new TcpListener(IPAddress.Any, port);
			ip = GetIPAddress();
		}

		public void UpdateIP() {
			ip = GetIPAddress();
		}
		string GetIPAddress() {
			string address = "";
			WebRequest request = WebRequest.Create("http://checkip.dyndns.org/");
			using (WebResponse response = request.GetResponse())
			using (StreamReader stream = new StreamReader(response.GetResponseStream())) {
				address = stream.ReadToEnd();
			}

			int first = address.IndexOf("Address: ") + 9;
			address = address.Substring(first);

			string ip = "";
			for (int i = 0; i < address.Length - 16; i++)
				ip += address[i];

			return ip;
		}

		public void Start() {

		}
		public void Stop() {

		}
	}
}
