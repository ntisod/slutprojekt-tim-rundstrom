using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows;

namespace Chess_online {

	public class Server {

		TcpListener tcpListener;
		public readonly string IP = "127.0.0.1";
		public readonly int port = 81;

		Thread serverThread;
		Socket client1;
		Socket client2;

		public Server() {
			tcpListener = new TcpListener(IPAddress.Parse(IP), port);
			serverThread = new Thread(ServerCycle);
		}

		public void Start() {
			serverThread.Start();
		}

		void ServerCycle() {

		}

		void Send(string message) {
			Byte[] bSend = Encoding.ASCII.GetBytes(message);
			client1.Send(bSend);
			client2.Send(bSend);
		}
		string Recieve(ref Socket socket) {

			Byte[] bRead = new Byte[256];
			int bReadSize = socket.Receive(bRead);

			string read = "";
			for (int i = 0; i < bReadSize; i++)
				read += Convert.ToChar(bRead[i]);

			return read;
		}

	}



}
