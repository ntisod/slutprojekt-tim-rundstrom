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
		Socket client;

		public Server() {
			tcpListener = new TcpListener(IPAddress.Parse(IP), port);
			serverThread = new Thread(ListenCycle);

			serverThread.IsBackground = true;
		}

		public void Start() {
			tcpListener.Start();
			serverThread.Start();
		}


		void ListenCycle() {
			try {
				client = tcpListener.AcceptSocket();

				Application.Current.Dispatcher.Invoke(() => {
					MainWindow.gridManager.SetGrid(GridType.Game);
					MainWindow.board.SetupGame(true, true);
				});

				while (true) {
					string message = Recieve();


					Application.Current.Dispatcher.Invoke(() => {
						MainWindow.board.Update(message);
					});
				}


			} catch (Exception) {
			}
		}

		public void Send(string message) {
			Byte[] bSend = Encoding.ASCII.GetBytes(message);
			client.Send(bSend);
		}
		string Recieve() {

			Byte[] bRead = new Byte[256];
			int bReadSize = client.Receive(bRead);

			string read = "";
			for (int i = 0; i < bReadSize; i++)
				read += Convert.ToChar(bRead[i]);

			return read;
		}

	}



}
