using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace chess_server {
	class Server {

		readonly IPAddress address = IPAddress.Parse("127.0.0.1");
		readonly int port = 8001;
		TcpListener tcpListener;
		Player player1;
		Player player2;
		Thread mainThread;
		Thread serverThread;

		public Server(Thread mainThread) {
			this.mainThread = mainThread;
			tcpListener = new TcpListener(address, port);
		}

		public void Start() {
			tcpListener.Start();
			serverThread = new Thread(ServerCycle);
		}

		public void Stop() {
			serverThread.Abort();
			tcpListener.Stop();
		}

		void ServerCycle() {

			try {
				ConnectPlayers();

				while (true) {

					if (player1.yourTurn)
						Console.WriteLine("Player 1 turn...\n");
					else if (player2.yourTurn)
						Console.WriteLine("Player 2 turn...\n");
					else
						Console.WriteLine("No ones turn... something's wrong \n");

					// Listen to sockets
					string read = GetMessage();
					Console.WriteLine($"Incoming message: \n{read}\n");

					// Calculate
					player1.yourTurn = !player1.yourTurn;
					player2.yourTurn = !player2.yourTurn;





					// Set Respond Message
					string message = string.Empty;

					// Respond
					Console.WriteLine($"Sending message:\n{message}\n");
					Byte[] bSend = Encoding.ASCII.GetBytes(message);
					player1.socket.Send(bSend);
					player2.socket.Send(bSend);
				}


			} catch (Exception e) {

			}

		}

		void ConnectPlayers() {
			Console.WriteLine("Väntar på anslutning av spelare 1...");
			Socket socket1 = tcpListener.AcceptSocket();
			player1 = new Player(1, true, socket1);
			Byte[] bSetup = Encoding.ASCII.GetBytes("1t");
			player1.socket.Send(bSetup);
			Console.WriteLine("Spelare 1 ansluten\n" + player1.socket.RemoteEndPoint + "\n\n");


			Console.WriteLine("Väntar på anslutning av spelare 2...");
			Socket socket2 = tcpListener.AcceptSocket();
			player2 = new Player(2, false, socket2);
			bSetup = Encoding.ASCII.GetBytes("2f");
			player2.socket.Send(bSetup);
			Console.WriteLine("Spelare 2 ansluten\n" + player2.socket.RemoteEndPoint + "\n\n");
		}

		string GetMessage() {
			Byte[] bRead = new Byte[256];
			int bReadSize = 0;

			if (player1.yourTurn)
				bReadSize = player1.socket.Receive(bRead);
			else
				bReadSize = player2.socket.Receive(bRead);

			string read = "";
			for (int i = 0; i < bReadSize; i++)
				read += Convert.ToChar(bRead[i]);

			return read;
		}

	}
}
