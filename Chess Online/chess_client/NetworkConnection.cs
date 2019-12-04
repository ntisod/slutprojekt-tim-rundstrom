using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows;
using System.Windows.Controls;

namespace chess_client {
	class NetworkConnection {

		string address;
		int port;
		TcpClient tcpClient;

		public NetworkConnection() {
			address = "127.0.0.1";
			port = 8001;
			tcpClient = new TcpClient();
			tcpClient.Connect(address, port);
		}
		
		public void ListenThread() {
			while (true) {
				string message = Recieve();

				Application.Current.Dispatcher.Invoke(() => {
					MainWindow.UpdateBoard(message);
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

		public void Close() {
			tcpClient.Close();
		}
		
	}
}
