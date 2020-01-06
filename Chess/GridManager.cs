using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;

namespace Chess {

	/// <summary>
	/// Public enum of different grids available, used for setting the grid
	/// </summary>
	public enum GridType { Main, Game, GameOver, Online, Host, Join}

	/// <summary>
	/// Managing object for the application grid.
	/// Used for managing the grid and change the grid and ui elements with one single method
	/// </summary>
	public class GridManager {

		Grid grid; // The application grid
		Style btnStyle; // Button style for game buttons (the chessboard)

		/// <summary>
		/// Constructor for the manager object
		/// </summary>
		/// <param name="grid"></param>
		/// <param name="btnStyle"></param>
		public GridManager(ref Grid grid, Style btnStyle) {
			this.grid = grid;
			this.btnStyle = btnStyle;
		}

		/// <summary>
		/// Public method used for setting the whole grid and ui elements with one call
		/// </summary>
		/// <param name="type"></param>
		public void SetGrid(GridType type) {
			// Reset the grid columns and rows defintions
			grid.ColumnDefinitions.Clear();
			grid.RowDefinitions.Clear();
			// Declare UI element list 
			List<UIElement> controls = new List<UIElement>();

			// Switch case for setting grid/ui elements depending on gridtype
			switch (type) {
				case GridType.Main:
					SetupMain(); // Set grid
					controls = GetMainControls(); // Get ui elements / controlls
					break;
				case GridType.Game:
					SetupGame(); // Set grid
					controls = GetGameControls(); // Get ui elements / controlls
					break;
				case GridType.GameOver:
					SetupGameOver(); // Set grid
					controls = GetGameOverControls(); // Get ui elements / controlls
					break;
				case GridType.Online:
					SetupOnline(); // Set grid
					controls = GetOnlineControls(); // Get ui elements / controlls
					break;
				case GridType.Host:
					SetupHost(); // Set grid
					controls = GetHostControls(); // Get ui elements / controlls
					break;
				case GridType.Join:
					SetupJoin(); // Set grid
					controls = GetJoinControls(); // Get ui elements / controlls
					break;
			}

			grid.Children.Clear(); // Clear the ui elements
			// Fill the grid ui elements with the desired ui elements
			foreach (UIElement ui in controls) 
				grid.Children.Add(ui);
			
		}
		
		/// <summary>
		/// Sets the columndefinitions and rowdefinitions for the main menu
		/// </summary>
		void SetupMain() {
			// Add 3 columns
			for (int i = 0; i < 3; i++)
				grid.ColumnDefinitions.Add(new ColumnDefinition());
			grid.ColumnDefinitions[1].Width = new GridLength(100); // Set the middle columns width to 100
			
			// Add 7 rows
			for (int i = 0; i < 7; i++) {
				RowDefinition row = new RowDefinition();
				if (i == 1) // If it's the second row
					row.Height = new GridLength(75); // Set the height to 75
				else if (i == 2) // If it's the third row
					row.Height = new GridLength(25); // Set the height to 25
				else if (i < 6 && i > 0) // If it's the fourth to next to last row
					row.Height = new GridLength(50); // Set the height to 50
				grid.RowDefinitions.Add(row); // Add the row to rowdefinitions
			}

		}
		/// <summary>
		/// Sets the columndefinitions and rowdefinitions for the main game
		/// </summary>
		void SetupGame() {

			// Set 10 columns and rows
			for(int i = 0; i < 10; i++) {
				ColumnDefinition column = new ColumnDefinition();
				RowDefinition row = new RowDefinition();
				if (i > 0 && i < 9) { // If it's not the first to last column/row
					column.Width = new GridLength(50); // Set the width to 50
					row.Height = new GridLength(50); // Set the height to 50
				}
				grid.ColumnDefinitions.Add(column); // Add the column to the grid
				grid.RowDefinitions.Add(row); // Add the row to the grid
			}

		}
		/// <summary>
		/// Sets the columndefinitions and rowdefinitions for the game over menu
		/// </summary>
		void SetupGameOver() {

			// Add 4 rows and columns
			for(int i = 0; i < 4; i++) {
				grid.ColumnDefinitions.Add(new ColumnDefinition());
				grid.RowDefinitions.Add(new RowDefinition());
				if (i == 2)
					grid.RowDefinitions[i].Height = new GridLength(50);
			}
			// Add one more column
			grid.ColumnDefinitions.Add(new ColumnDefinition());
		
		}
		/// <summary>
		/// Sets the columndefinitions and rowdefinitions for the online menu
		/// </summary>
		void SetupOnline() {

			// Add 4 columns and rows
			for(int i = 0; i < 4; i++) {
				ColumnDefinition column = new ColumnDefinition();
				RowDefinition row = new RowDefinition();
				if (i > 0 && i < 3) { // If it's not the first or last column/row
					column.Width = new GridLength(100); // Set the width to 100
					row.Height = new GridLength(50); // Set the height  to 50
				}
				grid.ColumnDefinitions.Add(column); // Add the column to the grid
				grid.RowDefinitions.Add(row); // Add the row to the grid
			}

		}
		/// <summary>
		/// Sets the columndefinitions and rowdefinitions for the hosting menu
		/// </summary>
		void SetupHost() {

			// Add 4 columns and rows
			for (int i = 0; i < 4; i++) {
				ColumnDefinition column = new ColumnDefinition();
				RowDefinition row = new RowDefinition();
				if (i == 1) { // If it's the second column/row
					column.Width = new GridLength(160); // Set the width to 160
					row.Height = new GridLength(50); // Set the height to 50
				} else if (i == 2) { // If it's the third column/row
					column.Width = new GridLength(70); // Set the width to 70
					row.Height = new GridLength(50); // Set the height to 50
				}
				grid.ColumnDefinitions.Add(column); // Add the column to the grid
				grid.RowDefinitions.Add(row); // Add the row to the grid
			}

		}
		/// <summary>
		/// Sets the columndefinitions and rowdefinitions for the join menu
		/// </summary>
		void SetupJoin() {

			// Add 5 columns
			for (int i = 0; i < 5; i++)
				grid.ColumnDefinitions.Add(new ColumnDefinition());
			grid.ColumnDefinitions[1].Width = new GridLength(125); // Set the second columns width to 125
			grid.ColumnDefinitions[2].Width = new GridLength(25); // Set the third columns width to 25
			grid.ColumnDefinitions[3].Width = new GridLength(75); // Set the fourth columns width to 75

			// Add 4 rows
			for (int i = 0; i < 4; i++) {
				RowDefinition row = new RowDefinition();
				if (i > 0 && i < 3) // If it's not the first or last row
					row.Height = new GridLength(50); // Set the height to 50
				grid.RowDefinitions.Add(row); // Add row to the grid
			}

		}

		/// <summary>
		/// Gets the ui elements / controls for the main menu
		/// </summary>
		/// <returns>List of UI Elements</returns>
		List<UIElement> GetMainControls() {
			// Declare list of ui controls to later return
			List<UIElement> controls = new List<UIElement>();

			// Declare a new textblock
			TextBlock main_Text = UIElementConstructors.TextBlockConstructor("CHESS", "main_tb", 40, TextAlignment.Center, HorizontalAlignment.Center, VerticalAlignment.Top, 0, 1, 3);
			controls.Add(main_Text); // Add to controls list

			// Declare a new textblock
			TextBlock author_Text = UIElementConstructors.TextBlockConstructor("By: Tim Rundström", "autor_tb", 15, TextAlignment.Center, HorizontalAlignment.Center, VerticalAlignment.Bottom, 0, 1, 3);
			controls.Add(author_Text); // Add to controls list

			// Declare a new button
			Button single_Btn = UIElementConstructors.ButtonContructor("Single", "single_btn", 20, 5, Play_Single_Btn_Click, 1, 3, 1);
			controls.Add(single_Btn); // Add to controls list

			// Declare a new button
			Button online_Btn = UIElementConstructors.ButtonContructor("Online", "online_btn", 20, 5, Online_Btn_Click, 1, 4, 1);
			controls.Add(online_Btn); // Add to controls list

			// Declare a new button
			Button quit_Btn = UIElementConstructors.ButtonContructor("Quit", "quit_btn", 20, 5, Quit_Btn_Click, 1, 5, 1);
			controls.Add(quit_Btn); // Add to controls list

			// Return controls
			return controls;
		}
		
		/// <summary>
		/// Gets the ui elements / controls for the game
		/// </summary>
		/// <returns>List of UI Elements</returns>
		List<UIElement> GetGameControls() {
			// Declare list of ui controls to later return
			List<UIElement> controls = new List<UIElement>();

			// Declare a new textblock
			TextBlock whitePointsTb = UIElementConstructors.TextBlockConstructor("", "whitePointsTb", 15, TextAlignment.Center, HorizontalAlignment.Center, VerticalAlignment.Center, 0, 0, 3);
			controls.Add(whitePointsTb); // Add to controls list

			// Declare a new textblock
			TextBlock blackPointsTb = UIElementConstructors.TextBlockConstructor("", "blackPointsTb", 15, TextAlignment.Center, HorizontalAlignment.Center, VerticalAlignment.Center, 7, 0, 3);
			controls.Add(blackPointsTb); // Add to controls list

			// Declare a new textblock
			TextBlock turnTb = UIElementConstructors.TextBlockConstructor("", "turnTb", 20, TextAlignment.Center, HorizontalAlignment.Center, VerticalAlignment.Center, 3, 0, 4);
			controls.Add(turnTb); // Add to controls list

			// Declare a new textblock
			TextBlock colorTb = UIElementConstructors.TextBlockConstructor("", "colorTb", 12, TextAlignment.Center, HorizontalAlignment.Center, VerticalAlignment.Bottom, 3, 0, 4);
			controls.Add(colorTb); // Add to controls list

			// Create row numbers and column letters (8x8)
			for (int i = 0; i < 8; i++) {
				// Declare a new horizontal textblock
				TextBlock horizontalTb = UIElementConstructors.TextBlockConstructor((i + 1).ToString(), "horizontalTb", 12, TextAlignment.Center, HorizontalAlignment.Right, VerticalAlignment.Center, 0, 8-i, 1);
				controls.Add(horizontalTb); // Add to controls list

				// Declare a new vertical textblock
				TextBlock verticalTb = UIElementConstructors.TextBlockConstructor(((char)(65 + i)).ToString(), "verticalTb", 12, TextAlignment.Center, HorizontalAlignment.Center, VerticalAlignment.Top, i+1, 9, 1);
				controls.Add(verticalTb); // Add to controls list
			}

			MainWindow.board.buttons.Clear(); // Clear buttons list (clear up leftovers of last game)
			// Bool for determining whether the button should have a white or black background
			bool white = true;

			// Create chessboard (8x8 grid of buttons)
			for (int i = 0; i < 8; i++) {
				for (int j = 0; j < 8; j++) {
					Position pos = new Position(j + 1, 8 - i); // Get its position
					Button btn = UIElementConstructors.ButtonContructor("", pos.btnName, 40, 2, null, j + 1, i + 1, 1);

					if (white)
						btn.Background = new SolidColorBrush(Colors.White); // Set background white
					else
						btn.Background = new SolidColorBrush(Colors.Gray); // Set background black (gray)

					white = !white; // Switch so next button is another colour
					btn.BorderBrush = new SolidColorBrush(Colors.Black); // Set a black border
					btn.BorderThickness = new Thickness(3); // Set a border thickness of 3
					btn.Padding = new Thickness(0, -5, 0, 0); // Give a negative padding on top (lift up text)
					btn.Style = btnStyle; // Set the style

					MainWindow.board.buttons.Add(pos.name, btn); // Add to buttons dictionary in board object
					controls.Add(btn); // Add to controls
				}
				white = !white;  // Switch background colour order, so that the next rows colour is adjacent
			}

			SetGameButtonEvents(); // Set all the events to the buttons
			return controls; // return controls
		}
		
		/// <summary>
		/// Gets the ui elements / controls for the game over menu
		/// </summary>
		/// <returns>List of UI Elements</returns>
		List<UIElement> GetGameOverControls() {
			// Declare list of ui controls to later return
			List<UIElement> controls = new List<UIElement>();

			// Declare a new textblock
			TextBlock tb = UIElementConstructors.TextBlockConstructor(MainWindow.board.GetVictory(), "victoryTb", 50, TextAlignment.Center, HorizontalAlignment.Center, VerticalAlignment.Center, 1, 1, 3);
			controls.Add(tb); // Add to controls

			// Declare a new button
			Button btn = UIElementConstructors.ButtonContructor("Main menu", "mainMenuBtn", 20, 0, Menu_Btn_Click, 2, 2, 1);
			controls.Add(btn); // Add to controls

			// return list of controls
			return controls;
		}
		
		/// <summary>
		/// Gets the ui elements / controls for the online menu
		/// </summary>
		/// <returns>List of UI Elements</returns>
		List<UIElement> GetOnlineControls() {
			// Declare list of ui controls to later return
			List<UIElement> controls = new List<UIElement>();

			// Declare a new button
			Button host_Btn = UIElementConstructors.ButtonContructor("Host", "hostBtn", 20, 5, Host_Btn_Click, 1, 1, 1);
			controls.Add(host_Btn); // Add to controls

			// Declare a new button
			Button join_Btn = UIElementConstructors.ButtonContructor("Join", "join_Btn", 20, 5, Join_Btn_Click, 2, 1, 1);
			controls.Add(join_Btn); // Add to controls

			// Declare a new button
			Button back_Btn = UIElementConstructors.ButtonContructor("Back", "back_Btn", 20, 5, Menu_Btn_Click, 1, 2, 2);
			controls.Add(back_Btn); // Add to controls

			// Return the list of controls
			return controls;
		}

		/// <summary>
		/// Gets the ui elements / controls for the host menu
		/// </summary>
		/// <returns>List of UI Elements</returns>
		List<UIElement> GetHostControls() {
			// Declare list of ui controls to later return
			List<UIElement> controls = new List<UIElement>();

			string ip = MainWindow.server.IP; // Get hosting ip
			string port = MainWindow.server.port.ToString(); // Get hosting port

			// Declare a new textblock
			TextBlock address_tb = new TextBlock();
			address_tb.Name = "address_TextBlock"; // Set name
			address_tb.Text = ip; // Set text
			address_tb.FontSize = 20; // Set fontsize
			address_tb.Margin = new Thickness(5); // Give a margin of thickness 5

			// Declare a new border for address_Text
			Border address_border = UIElementConstructors.BorderConstructor(Colors.Black, 1, 5, 1, 1);
			address_border.Child = address_tb; // Add address_tb as child of border element
			controls.Add(address_border); // Add border to controls;

			// Declare a new textblock
			TextBlock port_tb = new TextBlock();
			address_tb.Name = "port_TextBlock"; // Set name
			port_tb.Text = port; // Set text
			port_tb.FontSize = 20; // Set fontsize
			port_tb.Margin = new Thickness(5); // Give a margin of thickness 5

			// Declare a new border for address_Text
			Border port_border = UIElementConstructors.BorderConstructor(Colors.Black, 1, 5, 2, 1);
			port_border.Child = port_tb; // Add port_tb as child of border element
			controls.Add(port_border); // Add border to controls;

			// Declare a new button
			Button back_Btn = UIElementConstructors.ButtonContructor("Back", "backBtn", 20, 5, Online_Btn_Click, 1, 2, 2);
			controls.Add(back_Btn); // Add button to controls

			// return list of controls
			return controls;
		}

		/// <summary>
		/// Gets the ui elements / controls for the join menu
		/// </summary>
		/// <returns>List of UI Elements</returns>
		List<UIElement> GetJoinControls() {
			// Declare list of ui controls to later return
			List<UIElement> controls = new List<UIElement>();

			// Declare a new textbox
			TextBox address_Text = UIElementConstructors.TextBoxConstructor("address_Text", 20, 5, 5, 1, 1, 2);
			controls.Add(address_Text); // Add textbox to controls

			// Declare a new textbox
			TextBox port_Text = UIElementConstructors.TextBoxConstructor("port_Text", 20, 5, 5, 3, 1, 1);
			controls.Add(port_Text); // Add textbox of controls

			// Declare a new button
			Button connect_Btn = UIElementConstructors.ButtonContructor("Connect", "connectBtn", 20, 5, Connect_Btn_Click, 1, 2, 1);
			controls.Add(connect_Btn); // Add button to controls

			// Declare a new button
			Button back_Btn = UIElementConstructors.ButtonContructor("Back", "backBtn", 20, 5, Online_Btn_Click, 2, 2, 2);
			controls.Add(back_Btn); // Add button to controls

			return controls;
		}
		
		/// <summary>
		/// Starts a solo game
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void Play_Single_Btn_Click(object sender, RoutedEventArgs e) {
			SetGrid(GridType.Game);
			MainWindow.board.SetupGame(false, true);
		}
		/// <summary>
		/// Go to online menu
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void Online_Btn_Click(object sender, RoutedEventArgs e) {
			SetGrid(GridType.Online);
			MainWindow.server.Stop();
		}
		/// <summary>
		/// Quit application
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void Quit_Btn_Click(object sender, RoutedEventArgs e) {
			Application.Current.Shutdown();
		}

		/// <summary>
		/// Go to host menu
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void Host_Btn_Click(object sender, RoutedEventArgs e) {
			MainWindow.server.Start();
			SetGrid(GridType.Host);
		}
		/// <summary>
		/// Go to join menu
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void Join_Btn_Click(object sender, RoutedEventArgs e) {
			SetGrid(GridType.Join);
		}
		/// <summary>
		/// Go to main menu
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void Menu_Btn_Click(object sender, RoutedEventArgs e) {
			SetGrid(GridType.Main);
		}
		
		/// <summary>
		/// Connect to server
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void Connect_Btn_Click(object sender, RoutedEventArgs e) {
			string address = "";
			string port = "";

			// Find textboxes in grid.children
			foreach (TextBox tb in FindVisualChildren<TextBox>(grid)) {
				if (tb.Name == "address_Text") // If it is named "address_Textbox"
					address = tb.Text; // Take its value as IP address
				if (tb.Name == "port_Text") // If it is named "port_Textbox"
					port = tb.Text; // Take its value as port
			}

			try { // Try to connect
				MainWindow.client.Start(address, Convert.ToInt32(port)); // Start up client with address + port
				SetGrid(GridType.Game); // Set grid to game
				MainWindow.board.SetupGame(true, false); // Setup gameboard
			} catch (Exception) {
				// Couldn't connect to server, wrong ip and/or port
				// Display messagebox
				MessageBox.Show("Server not found.\nPlease make sure the IP adress and port is correct.");
			}

		}

		/// <summary>
		/// Get children of grid of the specific type T
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="grid"></param>
		/// <returns></returns>
		public IEnumerable<T> FindVisualChildren<T>(DependencyObject grid) where T : DependencyObject {
			// For loop through all children in grid
			for (int i = 0; i < VisualTreeHelper.GetChildrenCount(grid); i++) {
				// Get the child object
				DependencyObject child = VisualTreeHelper.GetChild(grid, i);
				// If the child exists and is inherited from DependencyObject
				if (child != null && child is T) {
					yield return (T)child; // Yield the result
				}

				// Go through the childs children (As in how address_Textbox is a child of address_Border)
				foreach (T childOfChild in FindVisualChildren<T>(child)) {
					yield return childOfChild; // Yield them
				}
			}
		}

		/// <summary>
		/// Sets the click events of every button in the dictionary in the board object
		/// </summary>
		void SetGameButtonEvents() {
			MainWindow.board.buttons[new Position(1, 8).name].Click += new RoutedEventHandler(Btn_A8_Click);
			MainWindow.board.buttons[new Position(1, 7).name].Click += new RoutedEventHandler(Btn_A7_Click);
			MainWindow.board.buttons[new Position(1, 6).name].Click += new RoutedEventHandler(Btn_A6_Click);
			MainWindow.board.buttons[new Position(1, 5).name].Click += new RoutedEventHandler(Btn_A5_Click);
			MainWindow.board.buttons[new Position(1, 4).name].Click += new RoutedEventHandler(Btn_A4_Click);
			MainWindow.board.buttons[new Position(1, 3).name].Click += new RoutedEventHandler(Btn_A3_Click);
			MainWindow.board.buttons[new Position(1, 2).name].Click += new RoutedEventHandler(Btn_A2_Click);
			MainWindow.board.buttons[new Position(1, 1).name].Click += new RoutedEventHandler(Btn_A1_Click);

			MainWindow.board.buttons[new Position(2, 8).name].Click += new RoutedEventHandler(Btn_B8_Click);
			MainWindow.board.buttons[new Position(2, 7).name].Click += new RoutedEventHandler(Btn_B7_Click);
			MainWindow.board.buttons[new Position(2, 6).name].Click += new RoutedEventHandler(Btn_B6_Click);
			MainWindow.board.buttons[new Position(2, 5).name].Click += new RoutedEventHandler(Btn_B5_Click);
			MainWindow.board.buttons[new Position(2, 4).name].Click += new RoutedEventHandler(Btn_B4_Click);
			MainWindow.board.buttons[new Position(2, 3).name].Click += new RoutedEventHandler(Btn_B3_Click);
			MainWindow.board.buttons[new Position(2, 2).name].Click += new RoutedEventHandler(Btn_B2_Click);
			MainWindow.board.buttons[new Position(2, 1).name].Click += new RoutedEventHandler(Btn_B1_Click);

			MainWindow.board.buttons[new Position(3, 8).name].Click += new RoutedEventHandler(Btn_C8_Click);
			MainWindow.board.buttons[new Position(3, 7).name].Click += new RoutedEventHandler(Btn_C7_Click);
			MainWindow.board.buttons[new Position(3, 6).name].Click += new RoutedEventHandler(Btn_C6_Click);
			MainWindow.board.buttons[new Position(3, 5).name].Click += new RoutedEventHandler(Btn_C5_Click);
			MainWindow.board.buttons[new Position(3, 4).name].Click += new RoutedEventHandler(Btn_C4_Click);
			MainWindow.board.buttons[new Position(3, 3).name].Click += new RoutedEventHandler(Btn_C3_Click);
			MainWindow.board.buttons[new Position(3, 2).name].Click += new RoutedEventHandler(Btn_C2_Click);
			MainWindow.board.buttons[new Position(3, 1).name].Click += new RoutedEventHandler(Btn_C1_Click);

			MainWindow.board.buttons[new Position(4, 8).name].Click += new RoutedEventHandler(Btn_D8_Click);
			MainWindow.board.buttons[new Position(4, 7).name].Click += new RoutedEventHandler(Btn_D7_Click);
			MainWindow.board.buttons[new Position(4, 6).name].Click += new RoutedEventHandler(Btn_D6_Click);
			MainWindow.board.buttons[new Position(4, 5).name].Click += new RoutedEventHandler(Btn_D5_Click);
			MainWindow.board.buttons[new Position(4, 4).name].Click += new RoutedEventHandler(Btn_D4_Click);
			MainWindow.board.buttons[new Position(4, 3).name].Click += new RoutedEventHandler(Btn_D3_Click);
			MainWindow.board.buttons[new Position(4, 2).name].Click += new RoutedEventHandler(Btn_D2_Click);
			MainWindow.board.buttons[new Position(4, 1).name].Click += new RoutedEventHandler(Btn_D1_Click);

			MainWindow.board.buttons[new Position(5, 8).name].Click += new RoutedEventHandler(Btn_E8_Click);
			MainWindow.board.buttons[new Position(5, 7).name].Click += new RoutedEventHandler(Btn_E7_Click);
			MainWindow.board.buttons[new Position(5, 6).name].Click += new RoutedEventHandler(Btn_E6_Click);
			MainWindow.board.buttons[new Position(5, 5).name].Click += new RoutedEventHandler(Btn_E5_Click);
			MainWindow.board.buttons[new Position(5, 4).name].Click += new RoutedEventHandler(Btn_E4_Click);
			MainWindow.board.buttons[new Position(5, 3).name].Click += new RoutedEventHandler(Btn_E3_Click);
			MainWindow.board.buttons[new Position(5, 2).name].Click += new RoutedEventHandler(Btn_E2_Click);
			MainWindow.board.buttons[new Position(5, 1).name].Click += new RoutedEventHandler(Btn_E1_Click);

			MainWindow.board.buttons[new Position(6, 8).name].Click += new RoutedEventHandler(Btn_F8_Click);
			MainWindow.board.buttons[new Position(6, 7).name].Click += new RoutedEventHandler(Btn_F7_Click);
			MainWindow.board.buttons[new Position(6, 6).name].Click += new RoutedEventHandler(Btn_F6_Click);
			MainWindow.board.buttons[new Position(6, 5).name].Click += new RoutedEventHandler(Btn_F5_Click);
			MainWindow.board.buttons[new Position(6, 4).name].Click += new RoutedEventHandler(Btn_F4_Click);
			MainWindow.board.buttons[new Position(6, 3).name].Click += new RoutedEventHandler(Btn_F3_Click);
			MainWindow.board.buttons[new Position(6, 2).name].Click += new RoutedEventHandler(Btn_F2_Click);
			MainWindow.board.buttons[new Position(6, 1).name].Click += new RoutedEventHandler(Btn_F1_Click);

			MainWindow.board.buttons[new Position(7, 8).name].Click += new RoutedEventHandler(Btn_G8_Click);
			MainWindow.board.buttons[new Position(7, 7).name].Click += new RoutedEventHandler(Btn_G7_Click);
			MainWindow.board.buttons[new Position(7, 6).name].Click += new RoutedEventHandler(Btn_G6_Click);
			MainWindow.board.buttons[new Position(7, 5).name].Click += new RoutedEventHandler(Btn_G5_Click);
			MainWindow.board.buttons[new Position(7, 4).name].Click += new RoutedEventHandler(Btn_G4_Click);
			MainWindow.board.buttons[new Position(7, 3).name].Click += new RoutedEventHandler(Btn_G3_Click);
			MainWindow.board.buttons[new Position(7, 2).name].Click += new RoutedEventHandler(Btn_G2_Click);
			MainWindow.board.buttons[new Position(7, 1).name].Click += new RoutedEventHandler(Btn_G1_Click);

			MainWindow.board.buttons[new Position(8, 8).name].Click += new RoutedEventHandler(Btn_H8_Click);
			MainWindow.board.buttons[new Position(8, 7).name].Click += new RoutedEventHandler(Btn_H7_Click);
			MainWindow.board.buttons[new Position(8, 6).name].Click += new RoutedEventHandler(Btn_H6_Click);
			MainWindow.board.buttons[new Position(8, 5).name].Click += new RoutedEventHandler(Btn_H5_Click);
			MainWindow.board.buttons[new Position(8, 4).name].Click += new RoutedEventHandler(Btn_H4_Click);
			MainWindow.board.buttons[new Position(8, 3).name].Click += new RoutedEventHandler(Btn_H3_Click);
			MainWindow.board.buttons[new Position(8, 2).name].Click += new RoutedEventHandler(Btn_H2_Click);
			MainWindow.board.buttons[new Position(8, 1).name].Click += new RoutedEventHandler(Btn_H1_Click);
		}

		//
		// Click events for all game buttons that redirect to ButtonPress() in the board object with it's position as argument
		//
		void Btn_A1_Click(object sender, RoutedEventArgs e) {
			MainWindow.board.ButtonPress(new Position(1, 1));
		}
		void Btn_A2_Click(object sender, RoutedEventArgs e) {
			MainWindow.board.ButtonPress(new Position(1, 2));
		}
		void Btn_A3_Click(object sender, RoutedEventArgs e) {
			MainWindow.board.ButtonPress(new Position(1, 3));
		}
		void Btn_A4_Click(object sender, RoutedEventArgs e) {
			MainWindow.board.ButtonPress(new Position(1, 4));
		}
		void Btn_A5_Click(object sender, RoutedEventArgs e) {
			MainWindow.board.ButtonPress(new Position(1, 5));
		}
		void Btn_A6_Click(object sender, RoutedEventArgs e) {
			MainWindow.board.ButtonPress(new Position(1, 6));
		}
		void Btn_A7_Click(object sender, RoutedEventArgs e) {
			MainWindow.board.ButtonPress(new Position(1, 7));
		}
		void Btn_A8_Click(object sender, RoutedEventArgs e) {
			MainWindow.board.ButtonPress(new Position(1, 8));
		}
		void Btn_B1_Click(object sender, RoutedEventArgs e) {
			MainWindow.board.ButtonPress(new Position(2, 1));
		}
		void Btn_B2_Click(object sender, RoutedEventArgs e) {
			MainWindow.board.ButtonPress(new Position(2, 2));
		}
		void Btn_B3_Click(object sender, RoutedEventArgs e) {
			MainWindow.board.ButtonPress(new Position(2, 3));
		}
		void Btn_B4_Click(object sender, RoutedEventArgs e) {
			MainWindow.board.ButtonPress(new Position(2, 4));
		}
		void Btn_B5_Click(object sender, RoutedEventArgs e) {
			MainWindow.board.ButtonPress(new Position(2, 5));
		}
		void Btn_B6_Click(object sender, RoutedEventArgs e) {
			MainWindow.board.ButtonPress(new Position(2, 6));
		}
		void Btn_B7_Click(object sender, RoutedEventArgs e) {
			MainWindow.board.ButtonPress(new Position(2, 7));
		}
		void Btn_B8_Click(object sender, RoutedEventArgs e) {
			MainWindow.board.ButtonPress(new Position(2, 8));
		}
		void Btn_C1_Click(object sender, RoutedEventArgs e) {
			MainWindow.board.ButtonPress(new Position(3, 1));
		}
		void Btn_C2_Click(object sender, RoutedEventArgs e) {
			MainWindow.board.ButtonPress(new Position(3, 2));
		}
		void Btn_C3_Click(object sender, RoutedEventArgs e) {
			MainWindow.board.ButtonPress(new Position(3, 3));
		}
		void Btn_C4_Click(object sender, RoutedEventArgs e) {
			MainWindow.board.ButtonPress(new Position(3, 4));
		}
		void Btn_C5_Click(object sender, RoutedEventArgs e) {
			MainWindow.board.ButtonPress(new Position(3, 5));
		}
		void Btn_C6_Click(object sender, RoutedEventArgs e) {
			MainWindow.board.ButtonPress(new Position(3, 6));
		}
		void Btn_C7_Click(object sender, RoutedEventArgs e) {
			MainWindow.board.ButtonPress(new Position(3, 7));
		}
		void Btn_C8_Click(object sender, RoutedEventArgs e) {
			MainWindow.board.ButtonPress(new Position(3, 8));
		}
		void Btn_D1_Click(object sender, RoutedEventArgs e) {
			MainWindow.board.ButtonPress(new Position(4, 1));
		}
		void Btn_D2_Click(object sender, RoutedEventArgs e) {
			MainWindow.board.ButtonPress(new Position(4, 2));
		}
		void Btn_D3_Click(object sender, RoutedEventArgs e) {
			MainWindow.board.ButtonPress(new Position(4, 3));
		}
		void Btn_D4_Click(object sender, RoutedEventArgs e) {
			MainWindow.board.ButtonPress(new Position(4, 4));
		}
		void Btn_D5_Click(object sender, RoutedEventArgs e) {
			MainWindow.board.ButtonPress(new Position(4, 5));
		}
		void Btn_D6_Click(object sender, RoutedEventArgs e) {
			MainWindow.board.ButtonPress(new Position(4, 6));
		}
		void Btn_D7_Click(object sender, RoutedEventArgs e) {
			MainWindow.board.ButtonPress(new Position(4, 7));
		}
		void Btn_D8_Click(object sender, RoutedEventArgs e) {
			MainWindow.board.ButtonPress(new Position(4, 8));
		}
		void Btn_E1_Click(object sender, RoutedEventArgs e) {
			MainWindow.board.ButtonPress(new Position(5, 1));
		}
		void Btn_E2_Click(object sender, RoutedEventArgs e) {
			MainWindow.board.ButtonPress(new Position(5, 2));
		}
		void Btn_E3_Click(object sender, RoutedEventArgs e) {
			MainWindow.board.ButtonPress(new Position(5, 3));
		}
		void Btn_E4_Click(object sender, RoutedEventArgs e) {
			MainWindow.board.ButtonPress(new Position(5, 4));
		}
		void Btn_E5_Click(object sender, RoutedEventArgs e) {
			MainWindow.board.ButtonPress(new Position(5, 5));
		}
		void Btn_E6_Click(object sender, RoutedEventArgs e) {
			MainWindow.board.ButtonPress(new Position(5, 6));
		}
		void Btn_E7_Click(object sender, RoutedEventArgs e) {
			MainWindow.board.ButtonPress(new Position(5, 7));
		}
		void Btn_E8_Click(object sender, RoutedEventArgs e) {
			MainWindow.board.ButtonPress(new Position(5, 8));
		}
		void Btn_F1_Click(object sender, RoutedEventArgs e) {
			MainWindow.board.ButtonPress(new Position(6, 1));
		}
		void Btn_F2_Click(object sender, RoutedEventArgs e) {
			MainWindow.board.ButtonPress(new Position(6, 2));
		}
		void Btn_F3_Click(object sender, RoutedEventArgs e) {
			MainWindow.board.ButtonPress(new Position(6, 3));
		}
		void Btn_F4_Click(object sender, RoutedEventArgs e) {
			MainWindow.board.ButtonPress(new Position(6, 4));
		}
		void Btn_F5_Click(object sender, RoutedEventArgs e) {
			MainWindow.board.ButtonPress(new Position(6, 5));
		}
		void Btn_F6_Click(object sender, RoutedEventArgs e) {
			MainWindow.board.ButtonPress(new Position(6, 6));
		}
		void Btn_F7_Click(object sender, RoutedEventArgs e) {
			MainWindow.board.ButtonPress(new Position(6, 7));
		}
		void Btn_F8_Click(object sender, RoutedEventArgs e) {
			MainWindow.board.ButtonPress(new Position(6, 8));
		}
		void Btn_G1_Click(object sender, RoutedEventArgs e) {
			MainWindow.board.ButtonPress(new Position(7, 1));
		}
		void Btn_G2_Click(object sender, RoutedEventArgs e) {
			MainWindow.board.ButtonPress(new Position(7, 2));
		}
		void Btn_G3_Click(object sender, RoutedEventArgs e) {
			MainWindow.board.ButtonPress(new Position(7, 3));
		}
		void Btn_G4_Click(object sender, RoutedEventArgs e) {
			MainWindow.board.ButtonPress(new Position(7, 4));
		}
		void Btn_G5_Click(object sender, RoutedEventArgs e) {
			MainWindow.board.ButtonPress(new Position(7, 5));
		}
		void Btn_G6_Click(object sender, RoutedEventArgs e) {
			MainWindow.board.ButtonPress(new Position(7, 6));
		}
		void Btn_G7_Click(object sender, RoutedEventArgs e) {
			MainWindow.board.ButtonPress(new Position(7, 7));
		}
		void Btn_G8_Click(object sender, RoutedEventArgs e) {
			MainWindow.board.ButtonPress(new Position(7, 8));
		}
		void Btn_H1_Click(object sender, RoutedEventArgs e) {
			MainWindow.board.ButtonPress(new Position(8, 1));
		}
		void Btn_H2_Click(object sender, RoutedEventArgs e) {
			MainWindow.board.ButtonPress(new Position(8, 2));
		}
		void Btn_H3_Click(object sender, RoutedEventArgs e) {
			MainWindow.board.ButtonPress(new Position(8, 3));
		}
		void Btn_H4_Click(object sender, RoutedEventArgs e) {
			MainWindow.board.ButtonPress(new Position(8, 4));
		}
		void Btn_H5_Click(object sender, RoutedEventArgs e) {
			MainWindow.board.ButtonPress(new Position(8, 5));
		}
		void Btn_H6_Click(object sender, RoutedEventArgs e) {
			MainWindow.board.ButtonPress(new Position(8, 6));
		}
		void Btn_H7_Click(object sender, RoutedEventArgs e) {
			MainWindow.board.ButtonPress(new Position(8, 7));
		}
		void Btn_H8_Click(object sender, RoutedEventArgs e) {
			MainWindow.board.ButtonPress(new Position(8, 8));
		}

	}
}
