using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace chess_client {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public enum GameStage { Menu, Singleplayer, Multiplayer}
	public partial class MainWindow : Window {

		static NetworkConnection network;
		static Chessboard board;

		static GameStage stage = GameStage.Menu;


		public MainWindow() {
			InitializeComponent();

			grid.ShowGridLines = true;

			SetupMenu();
			Title = "CHESS";

		}
		
		void SetupMenu() {
			stage = GameStage.Menu;
			SetupGrid();

			Button singleButton = new Button();
			Grid.SetColumn(singleButton, 1);
			Grid.SetRow(singleButton, 1);
			singleButton.Content = "Play!";
			singleButton.VerticalContentAlignment = VerticalAlignment.Center;
			singleButton.HorizontalContentAlignment = HorizontalAlignment.Center;
			singleButton.Margin = new Thickness(5);
			singleButton.Click += new RoutedEventHandler(SingleButton);

			Button multiButton = new Button();
			Grid.SetColumn(multiButton, 1);
			Grid.SetRow(multiButton, 2);
			multiButton.Content = "Online!";
			multiButton.VerticalContentAlignment = VerticalAlignment.Center;
			multiButton.HorizontalContentAlignment = HorizontalAlignment.Center;
			multiButton.Margin = new Thickness(5);
			multiButton.Click += new RoutedEventHandler(MultiButton);

			Button quitButton = new Button();
			Grid.SetColumn(quitButton, 1);
			Grid.SetRow(quitButton, 3);
			quitButton.Content = "Quit";
			quitButton.VerticalContentAlignment = VerticalAlignment.Center;
			quitButton.HorizontalContentAlignment = HorizontalAlignment.Center;
			quitButton.Margin = new Thickness(5);
			quitButton.Click += new RoutedEventHandler(QuitButton);

			grid.Children.Add(singleButton);
			grid.Children.Add(multiButton);
			grid.Children.Add(quitButton);

		}
		void SetupSingle() {
			stage = GameStage.Singleplayer;
			SetupGrid();
		}
		void SetupOnline() {
			stage = GameStage.Multiplayer;
			SetupGrid();
			/*
			// Setup network connection
			network = new NetworkConnection();

			// Get data for players
			string playerSetup = network.Recieve();

			// Setup Chessboard
			board = new Chessboard(playerSetup);
			Title = $"CHESS - Player {board.player1.ID}";

			// Start new thread for listening to the server
			Thread listenThread = new Thread(network.ListenThread);
			listenThread.Start();
			*/
		}
		void SetupGrid() {
			grid.Children.Clear();
			grid.RowDefinitions.Clear();
			grid.ColumnDefinitions.Clear();

			if (stage == GameStage.Menu) {
				ColumnDefinition col1 = new ColumnDefinition();
				ColumnDefinition col2 = new ColumnDefinition();
				col2.Width = new GridLength(100);
				ColumnDefinition col3 = new ColumnDefinition();
				grid.ColumnDefinitions.Add(col1);
				grid.ColumnDefinitions.Add(col2);
				grid.ColumnDefinitions.Add(col3);

				RowDefinition row1 = new RowDefinition();
				RowDefinition row2 = new RowDefinition();
				row2.Height = new GridLength(50);
				RowDefinition row3 = new RowDefinition();
				row3.Height = new GridLength(50);
				RowDefinition row4 = new RowDefinition();
				row4.Height = new GridLength(50);
				RowDefinition row5 = new RowDefinition();
				grid.RowDefinitions.Add(row1);
				grid.RowDefinitions.Add(row2);
				grid.RowDefinitions.Add(row3);
				grid.RowDefinitions.Add(row4);
				grid.RowDefinitions.Add(row5);
			} else {
				ColumnDefinition col1 = new ColumnDefinition();
				ColumnDefinition col2 = new ColumnDefinition();
				ColumnDefinition col3 = new ColumnDefinition();
				ColumnDefinition col4 = new ColumnDefinition();
				ColumnDefinition col5 = new ColumnDefinition();
				ColumnDefinition col6 = new ColumnDefinition();
				ColumnDefinition col7 = new ColumnDefinition();
				ColumnDefinition col8 = new ColumnDefinition();
				ColumnDefinition col9 = new ColumnDefinition();
				ColumnDefinition col10 = new ColumnDefinition();

				grid.ColumnDefinitions.Add(col1);
				grid.ColumnDefinitions.Add(col2);
				grid.ColumnDefinitions.Add(col3);
				grid.ColumnDefinitions.Add(col4);
				grid.ColumnDefinitions.Add(col5);
				grid.ColumnDefinitions.Add(col6);
				grid.ColumnDefinitions.Add(col7);
				grid.ColumnDefinitions.Add(col8);
				grid.ColumnDefinitions.Add(col9);
				grid.ColumnDefinitions.Add(col10);

				RowDefinition row1 = new RowDefinition();
				RowDefinition row2 = new RowDefinition();
				RowDefinition row3 = new RowDefinition();
				RowDefinition row4 = new RowDefinition();
				RowDefinition row5 = new RowDefinition();
				RowDefinition row6 = new RowDefinition();
				RowDefinition row7 = new RowDefinition();
				RowDefinition row8 = new RowDefinition();
				RowDefinition row9 = new RowDefinition();
				RowDefinition row10 = new RowDefinition();

				grid.RowDefinitions.Add(row1);
				grid.RowDefinitions.Add(row2);
				grid.RowDefinitions.Add(row3);
				grid.RowDefinitions.Add(row4);
				grid.RowDefinitions.Add(row5);
				grid.RowDefinitions.Add(row6);
				grid.RowDefinitions.Add(row7);
				grid.RowDefinitions.Add(row8);
				grid.RowDefinitions.Add(row9);
				grid.RowDefinitions.Add(row10);
			}
			
		}

		// MENU BUTTONS
		void SingleButton(object sender, RoutedEventArgs e) {
			SetupSingle();
		}
		void MultiButton(object sender, RoutedEventArgs e) {
			SetupOnline();
		}
		void QuitButton(object sender, RoutedEventArgs e) {
			Application.Current.Shutdown();
		}


		public static void UpdateBoard(string message) {
			board.Update(message);
		}

		void ButtonPress(Position position) {
		}
		
	}
}
