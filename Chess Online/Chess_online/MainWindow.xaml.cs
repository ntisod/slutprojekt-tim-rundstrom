using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace Chess_online {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>

	/*
	 * ------------------------------------------------
	 * 
	 * THREADS (ONLINE):
	 * 1. MAIN THREAD (USER INPUTS AND CONTROLS)
	 * 
	 * 2. SERVER LISTEN (SERVER PART LISTENING)
	 * 
	 * 3. CLIENT LISTEN (CLIENT PART LISTENING)
	 * 
	 * THREADS (OFFLINE):
	 * 1. MAIN THREAD (USER INPUTS AND CONTROLS)
	 * 
	 * ------------------------------------------------
	 * 
	 * ON HOST:
	 * START SERVER AND A CLIENT (CONNECT CLIENT TO SELF / SERVER)
	 * DISPLAY CURRENT ADDRESS AND PORT
	 * WAIT FOR SECOND CLIENT TO CONNECT
	 * START GAME
	 * 
	 * ON JOIN:
	 * INPUT ADDRESS AND PORT
	 * CONNECT TO SERVER
	 * START GAME
	 * 
	 * ON SINGLE:
	 * START GAME
	 * 
	 * ------------------------------------------------
	 * 
	 */

	public partial class MainWindow : Window {

		public static GridManager gridManager;
		public static Chessboard board;
		public static Server server;
		public static Client client;

		public MainWindow() {
			InitializeComponent();

			// Get the game button style
			Style style = FindResource("ChessCell") as Style;

			// Declare grid manager and set it to main menu grid.
			gridManager = new GridManager(ref grid, style);
			board = new Chessboard();
			server = new Server();
			client = new Client();


			// Set active grid and controls (main menu)
			gridManager.SetGrid(GridType.Main);

			// DEBUGGING
			//grid.ShowGridLines = true;
		}


	}
}
