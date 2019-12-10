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

	public class Client {

		TcpClient tcpClient;
		Thread clientThread;

		public Client() {
			tcpClient = new TcpClient();
			clientThread = new Thread(ClientCycle);
		}

		public void Start(string hostname, int port) {
		
			tcpClient.Connect(hostname, port);
			clientThread.Start();

		}

		void ClientCycle() {

			while (true) {

				string message = Recieve();

				Application.Current.Dispatcher.Invoke(() => {
					MainWindow.gridManager.UpdateGame(message);
				});
			
			}

		}
		
		public void Send(string message) {
			NetworkStream tcpStream = tcpClient.GetStream();
			byte[] bMessage = Encoding.ASCII.GetBytes(message);
			tcpStream.Write(bMessage, 0, bMessage.Length);
		}

		public string Recieve() {
			NetworkStream tcpStream = tcpClient.GetStream();

			byte[] bRead = new byte[256];
			int bReadSize = tcpStream.Read(bRead, 0, bRead.Length);

			string read = "";
			for (int i = 0; i < bReadSize; i++) {
				read += Convert.ToChar(bRead[i]);
			}
			return read;
		}


	}

}
