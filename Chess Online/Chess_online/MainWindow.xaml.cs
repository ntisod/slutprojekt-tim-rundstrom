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
	public partial class MainWindow : Window {

		// Static attributes
		public static Grid gridObject;
		public static GridManager gridManager; // Control and manage grid + ui elements
		public static Chessboard board; // Game board
		public static Server server; // Server for hosting online
		public static Client client; // Client for joining online

		public MainWindow() {
			InitializeComponent();

			gridObject = grid;

			// Get the game button style
			Style style = FindResource("ChessCell") as Style;

			// Declare attributes
			gridManager = new GridManager(ref grid, style);
			board = new Chessboard();
			server = new Server();
			client = new Client();

			// Set grid and controls to main menu
			gridManager.SetGrid(GridType.Main);
		}
		

	}
}
