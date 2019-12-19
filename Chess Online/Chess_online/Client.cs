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
	/// <summary>
	/// Client object for online chess.
	/// Use for listening for actions by the server (opponent)
	/// Send and recieve messages / actions
	/// </summary>
	public class Client {

		TcpClient tcpClient; // tcp object
		Thread clientThread; // Thread for listening in on the server in the background

		/// <summary>
		/// Constructor for client object
		/// Declare values for objects
		/// </summary>
		public Client() {
			tcpClient = new TcpClient();
			clientThread = new Thread(ClientCycle);

			clientThread.IsBackground = true;
		}

		/// <summary>
		/// Connects to the server and starts the background thread
		/// </summary>
		/// <param name="hostname"></param>
		/// <param name="port"></param>
		public void Start(string hostname, int port) {
		
			tcpClient.Connect(hostname, port); // connect to the server
			clientThread.Start(); // start the server cycle

		}

		/// <summary>
		/// Infinite cycle for the background client thread
		/// Used to listening on the server
		/// Taking whatever the server sends and updates the board accordingly
		/// </summary>
		void ClientCycle() {
			// Infinite listening loop
			while (true) {
				string message = Recieve(); // Recieve message from the server

				// Gain access into the main thread
				Application.Current.Dispatcher.Invoke(() => {
					// Update the board accordingly to the message from the server
					MainWindow.board.UpdateOnline(message); 
				});
			}
		}

		/// <summary>
		/// Send param message to server
		/// </summary>
		/// <param name="message"></param>
		public void Send(string message) {
			try {
				NetworkStream tcpStream = tcpClient.GetStream(); // Get TcpStream to send message
				byte[] bMessage = Encoding.ASCII.GetBytes(message); // Encode the message into a buffer
				tcpStream.Write(bMessage, 0, bMessage.Length); // Write to server using TcpStream
			} catch (Exception) {
			}
		}

		/// <summary>
		/// Recieve a message from the server
		/// </summary>
		/// <returns>message from server</returns>
		public string Recieve() {
			NetworkStream tcpStream = tcpClient.GetStream(); // Get TcpStream to recieve message

			byte[] bRead = new byte[256]; // Declare a byte buffer
			int bReadSize = tcpStream.Read(bRead, 0, bRead.Length); // Get a message using the buffer

			// Convert the message into a string
			string read = "";
			for (int i = 0; i < bReadSize; i++) {
				read += Convert.ToChar(bRead[i]); // Add char from buffer to string
			}

			// Return the message in a string form
			return read;
		}


	}

}
