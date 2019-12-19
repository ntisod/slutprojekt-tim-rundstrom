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

	public class NetworkConnection {

		// TCP Connections
		TcpListener tcpListener;
		TcpClient tcpClient;

		public readonly string serverIP = "127.0.0.1";
		public readonly int serverPort = 81;

		string connectAdress;
		int connectPort;

		Thread backgroundThread;
		Socket clientSocket;

		bool hosting;
		bool listen;

		public bool Hosting { get => hosting; }

		public NetworkConnection() {
			tcpListener = new TcpListener(IPAddress.Parse(serverIP), serverPort);
			tcpClient = new TcpClient();

			backgroundThread = new Thread(BackgroundCycle);
			backgroundThread.IsBackground = true;
		}

		public void Host() {
			if (!listen) {
				hosting = true;
				listen = true; backgroundThread.Start();
			}
		}
		public void Connect(string adress, int port) {
			if (!listen) {
				hosting = false;
				listen = true;
				backgroundThread.Start();
			}
		}

		public void Stop() {
			try {
				if (hosting)
					tcpListener.Stop();
				else
					tcpClient.Close();
				listen = false;
			} catch (Exception) {
			}
		}

		public void Send(string message) {

			if (hosting) {
				Byte[] bSend = Encoding.ASCII.GetBytes(message);
				clientSocket.Send(bSend);
			} else {
				NetworkStream tcpStream = tcpClient.GetStream();
				byte[] bMessage = Encoding.ASCII.GetBytes(message);
				tcpStream.Write(bMessage, 0, bMessage.Length);
			}

		}

		string Recieve() {
			if (hosting) {
				Byte[] bRead = new Byte[256];
				int bReadSize = clientSocket.Receive(bRead);

				string read = "";
				for (int i = 0; i < bReadSize; i++)
					read += Convert.ToChar(bRead[i]);

				return read;
			} else {
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

		void BackgroundCycle() {

			try {

				while (true) {
					if (listen) {
						if (hosting) {
							tcpListener.Start();
							clientSocket = tcpListener.AcceptSocket();
							//ReachMainThread(SetupGameAsHost);
							Application.Current.Dispatcher.Invoke(() => {
								MainWindow.gridManager.SetGrid(GridType.Game);
								MainWindow.board.SetupGame(true, true);
							});
						} else {
							tcpClient.Connect(connectAdress, connectPort);
						}

						while (true) {

							string message = Recieve();

							if (message == "END") {
								Application.Current.Dispatcher.Invoke(() => {
									MainWindow.gridManager.SetGrid(GridType.Main);
								});
								break;
							}

							UpdateBoard(message);
						}
						Stop();
					}

				}
			} catch (Exception e) {
				MessageBox.Show(e.ToString());
			}
		}

		void ReachMainThread(Action action) {
			Application.Current.Dispatcher.Invoke(() => {
				action();
			});
		}

		void UpdateBoard(string message) {
			Application.Current.Dispatcher.Invoke(() => {
				MainWindow.board.UpdateOnline(message);
			});
		}
		void ExitGame() {
			MainWindow.gridManager.SetGrid(GridType.Main);
		}
		void SetupGameAsHost() {
			MainWindow.gridManager.SetGrid(GridType.Game);
			MainWindow.board.SetupGame(true, true);
		}

	}
}
