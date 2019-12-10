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

		Thread serverThread1;
		Thread serverThread2;
		Socket client1;
		Socket client2;

		public Server() {
			tcpListener = new TcpListener(IPAddress.Parse(IP), port);
			serverThread1 = new Thread(Client_1_ListningCycle);
			serverThread2 = new Thread(Client_2_ListningCycle);
		}

		public void Start() {
			tcpListener.Start();

			try {
				client1 = tcpListener.AcceptSocket();
				client2 = tcpListener.AcceptSocket();

				MainWindow.board.SetupGame(true);
				MainWindow.gridManager.SetGrid(GridType.Game);

				serverThread1.Start();
				serverThread2.Start();
			} catch (Exception) {
				tcpListener.Stop();
			}
		}

		void Client_1_ListningCycle() {

			ListenCycle(ref client1);

		}
		void Client_2_ListningCycle() {

			ListenCycle(ref client2);

		}

		void ListenCycle(ref Socket socket) {

			while (true) {

				string message = Recieve(ref socket);

				if (message == "helo") {
					Send("helo to yo");
				} else {
					Send("Nani??");
				}

			}

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
