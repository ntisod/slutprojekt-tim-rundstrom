using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows;

namespace Chess {
	/// <summary>
	/// Client object for online chess.
	/// Use for listening for actions by the server (opponent)
	/// Send and recieve messages / actions
	/// </summary>
	public class Client {

		public TcpClient tcpClient; // tcp object
		Thread clientThread; // Thread for listening in on the server in the background

		bool running; // bool to determine if clientcycle should listen to the server

		public bool Running { get => running; } // Public getter for the running bool, to se if client is up and running

		/// <summary>
		/// Constructor for client object
		/// Declare values for objects
		/// </summary>
		public Client() {
			// Declare objects
			tcpClient = new TcpClient();
			clientThread = new Thread(ClientCycle);

			clientThread.IsBackground = true; // Set the client thread to a background thread, automatically closes
			clientThread.Start(); // Start the thread
		}

		/// <summary>
		/// Connects to the server and starts the background thread
		/// </summary>
		/// <param name="hostname"></param>
		/// <param name="port"></param>
		public void Start(string hostname, int port) {
		
			tcpClient.Connect(hostname, port); // connect to the server
			running = true; // Start listening to messages from server

		}

		public void Stop() {
			running = false; // don't listen for messages
			tcpClient.Close(); // close tcpClient
			tcpClient = new TcpClient(); // Refresh it with a new object, only way to reuse it
		}

		/// <summary>
		/// Infinite cycle for the background client thread
		/// Used to listening on the server
		/// Taking whatever the server sends and updates the board accordingly
		/// </summary>
		void ClientCycle() {
			// Infinite listening loop
			while (true) {
				while (running) {
					string message = Recieve(); // Recieve message from the server

					if (message == "GAME OVER") { // In case message from server is GAME OVER; they left early
						Application.Current.Dispatcher.Invoke(() => {
							MainWindow.gridManager.SetGrid(GridType.GameOver); // Set game over grid, you can't play against no one
							MessageBox.Show("Game ended abruptly.\nOpponent unexpectedly left the game."); // Popup a small messagebox, explaining why it ended
							Stop();
						});
					}

					// Gain access into the main thread
					Application.Current.Dispatcher.Invoke(() => {
							// Update the board accordingly to the message from the server
							MainWindow.board.UpdateOnline(message);
						});
						
				}
				Thread.Sleep(500); // wait for .5s, less traffic
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
			byte[] bRead = new byte[256]; // Declare a byte buffer
			int bReadSize = 0;

			try {
				NetworkStream tcpStream = tcpClient.GetStream(); // Get TcpStream to recieve message
				bReadSize = tcpStream.Read(bRead, 0, bRead.Length); // Get a message using the buffer
			} catch (Exception) {
			}

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
