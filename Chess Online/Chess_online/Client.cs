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

			clientThread.IsBackground = true;
		}

		public void Start(string hostname, int port) {
		
			tcpClient.Connect(hostname, port);
			clientThread.Start();

		}

		public void Stop() {
			try {
				Send("END");
				clientThread.Abort();
				clientThread = new Thread(ClientCycle);
				clientThread.IsBackground = true;
				tcpClient.Close();
			} catch (Exception) {
			}
		}


		void ClientCycle() {
			while (true) {
				string message = Recieve();

				if (message == "END")
					break;

				Application.Current.Dispatcher.Invoke(() => {
					MainWindow.board.UpdateOnline(message);
				});
			}
			Send("END");
			Application.Current.Dispatcher.Invoke(() => {
				MainWindow.gridManager.SetGrid(GridType.Main);
			});
			MessageBox.Show("Game ended prematurely.");
			tcpClient.Close();
		}
		
		public void Send(string message) {
			try {
				NetworkStream tcpStream = tcpClient.GetStream();
				byte[] bMessage = Encoding.ASCII.GetBytes(message);
				tcpStream.Write(bMessage, 0, bMessage.Length);
			} catch (Exception InvalidOperationException) {
			}
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
