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
	/// Hosting object for online chess.
	/// Use for listening for actions by the client (opponent)
	/// Send and recieve messages / actions
	/// </summary>
	public class Server {

		TcpListener tcpListener; // tcp object
		public string IP = "ERROR"; // Listening ip address
		public int port = 8080; // Listening port

		Thread serverThread; // Thread for listening in on the client in the background
		Socket client; // Socket to which the client connects to
		
		/// <summary>
		/// Constructor for the server object
		/// Gets and sets IP address and declares objects
		/// </summary>
		public Server() {
			// Get the local ip address for the hosting PC
			var host = Dns.GetHostEntry(Dns.GetHostName()); // Get addresses connected to PC
			foreach (var ip in host.AddressList) {
				if (ip.AddressFamily == AddressFamily.InterNetwork) { // Get the IPv4 address
					IP = ip.ToString(); // Set the attribute to the local IPv4 address
				}
			}

			tcpListener = new TcpListener(IPAddress.Parse(IP), port); // Declare the listener on the local address
			serverThread = new Thread(ListenCycle); // Declare the background thread
			serverThread.IsBackground = true; // Set the thread to background task
		}

		/// <summary>
		/// Public method thats starts the host
		/// Starts the TcpListener and server thread
		/// </summary>
		public void Start() {
			tcpListener.Start(); // Start listener
			serverThread.Start(); // Start the listener thread
		}		

		/// <summary>
		/// Infinite cycle for the background server thread
		/// Used to listening on the client socket
		/// Taking whatever the client sends and updates the board accordingly
		/// </summary>
		void ListenCycle() {
			try {
				client = tcpListener.AcceptSocket(); // Wait for a client to connect

				// Launch the game inside the main thread
				Application.Current.Dispatcher.Invoke(() => { // Gains access to the main thread
					MainWindow.gridManager.SetGrid(GridType.Game); // Set the grid
					MainWindow.board.SetupGame(true, true); // Setup the gameboard
				});

				// The infinite listening loop
				while (true) { 
					string message = Recieve(); // Recieve a message from the client
					
					// Gain access to the main thread
					Application.Current.Dispatcher.Invoke(() => {
						MainWindow.board.UpdateOnline(message); // Update the board using the recieved message
					});
				}
				
			} catch (Exception) {
			}
		}

		/// <summary>
		/// Send param message to client
		/// </summary>
		/// <param name="message"></param>
		public void Send(string message) {
			Byte[] bSend = Encoding.ASCII.GetBytes(message); // Encode the string message to a byte array
			client.Send(bSend); // send the byte array to the client
		}
		/// <summary>
		/// Recieve a message from the client
		/// </summary>
		/// <returns>message from the client</returns>
		string Recieve() {

			Byte[] bRead = new Byte[256]; // Declare byte array bugger
			int bReadSize = client.Receive(bRead); // Recieve the message into the buffer

			// Convert into a string
			string read = "";
			for (int i = 0; i < bReadSize; i++)
				read += Convert.ToChar(bRead[i]); // Add char from buffer into the string

			// Return the recieved message in a string form
			return read;
		}

	}



}
