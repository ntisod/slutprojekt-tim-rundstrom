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

		bool running = false; // bool to determine if servercycle should accept a socket

		public bool Running { get => running; } // Public getter for the running bool, to se if server is up and running

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
			
			serverThread = new Thread(ListenCycle); // Declare the background thread
			serverThread.IsBackground = true; // Set the thread to background task
			serverThread.Start(); // Start the listener thread
		}

		/// <summary>
		/// Public method thats starts the host
		/// sets the running bool to true, thus finds a socket in the serverthread
		/// </summary>
		public void Start() {
			int portCounter = 0; // int to add to port in case its unavailable
			while (true) {
				try {
					// Declare the listener on the local address
					tcpListener = new TcpListener(IPAddress.Parse(IP), port + portCounter); // setup new listener
					tcpListener.Start(); // try to start listener, exception if its unavailable
					port = port + portCounter; // update port
					break; // break out of loop, the connection has been set
				} catch (Exception) { // In case its unavailable
					portCounter++; // increase the port number, and go again through the loop
				}
			}
			running = true; // Start listening for sockets
		}		

		/// <summary>
		/// Publid method that stops the host
		/// sets the running bool to false, thus not listening for a socket in the serverthread since the tcplistener is closed.
		/// </summary>
		public void Stop() {
			running = false; // Stop listening for new sockets
			if (tcpListener != null) // If its not on startup, aka tcpListener isn't null
				tcpListener.Stop(); // Stop it
			client = null; // set the client socket null aswell, better to make sure its closed
		}

		/// <summary>
		/// Infinite cycle for the background server thread
		/// Used to listening on the client socket
		/// Taking whatever the client sends and updates the board accordingly
		/// </summary>
		void ListenCycle() {
			while (true) {

				if (running) { // Go through listening cycle

					try {
						client = tcpListener.AcceptSocket(); // Wait for a client to connect
															 // Launch the game inside the main thread
						Application.Current.Dispatcher.Invoke(() => { // Gains access to the main thread
							MainWindow.gridManager.SetGrid(GridType.Game); // Set the grid
							MainWindow.board.SetupGame(true, true); // Setup the gameboard
						});

						// The infinite listening loop
						while (running) {
							string message = Recieve(); // Recieve a message from the clients

							if (message == "GAME OVER") { // In case message from server is GAME OVER; they left early
								Application.Current.Dispatcher.Invoke(() => {
									MainWindow.gridManager.SetGrid(GridType.GameOver); // Set game over grid, you can't play against no one
									MessageBox.Show("Game ended abruptly.\nOpponent unexpectedly left the game."); // Popup a small messagebox, explaining why it ended
									Stop();
								});
							}

							// Gain access to the main thread
							Application.Current.Dispatcher.Invoke(() => {
								MainWindow.board.UpdateOnline(message); // Update the board using the recieved message
							});
						}
					} catch (Exception) {
					}

				} else {
					Thread.Sleep(500); // Wait for .5s, less traffic
				}
			}
		}

		/// <summary>
		/// Send param message to client
		/// </summary>
		/// <param name="message"></param>
		public void Send(string message) {
			Byte[] bSend = Encoding.ASCII.GetBytes(message); // Encode the string message to a byte array
			try {
				client.Send(bSend); // send the byte array to the client
			} catch (NullReferenceException) {
				// Ignore error, happens when program is quit while in the online menu since the server is running, but no client has yet connected
			}
		}
		/// <summary>
		/// Recieve a message from the client
		/// </summary>
		/// <returns>message from the client</returns>
		string Recieve() {

			Byte[] bRead = new Byte[256]; // Declare byte array bugger
			int bReadSize = 0;
			try {
				bReadSize = client.Receive(bRead); // Recieve the message into the buffer
			} catch (Exception) {
			}
			// Convert into a string
			string read = "";
			for (int i = 0; i < bReadSize; i++)
				read += Convert.ToChar(bRead[i]); // Add char from buffer into the string

			// Return the recieved message in a string form
			return read;
		}

	}



}
