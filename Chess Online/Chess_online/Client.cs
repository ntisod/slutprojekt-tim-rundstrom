using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Chess_online {
	public class Client {

		string address;
		int port = 8001;
		TcpClient tcpClient;

		public Client() {
			tcpClient = new TcpClient();
		}

		public void Connect(string address) {
			this.address = address;
			tcpClient.Connect(this.address, port);
		}

		public void ListenThread() {
			while (true) {
				string message = Recieve();

				Application.Current.Dispatcher.Invoke(() => {
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
