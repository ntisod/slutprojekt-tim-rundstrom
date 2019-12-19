using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;

namespace Chess_online {
	public enum GridType { Main, Game, GameOver, Online, Host, Join}
	public class GridManager {

		Grid grid;
		Style btnStyle;

		public Grid gridObj { get => grid; }

		public GridManager(ref Grid grid, Style btnStyle) {
			this.grid = grid;
			this.btnStyle = btnStyle;
		}

		// SET DESIRED GRID / CONTROL
		public void SetGrid(GridType type) {
			grid.ColumnDefinitions.Clear();
			grid.RowDefinitions.Clear();
			List<UIElement> controls;

			switch (type) {
				case GridType.Main:
					SetupMain();
					controls = GetMainControls();
					break;
				case GridType.Game:
					SetupGame();
					controls = GetGameControls();
					break;
				case GridType.GameOver:
					SetupGameOver();
					controls = GetGameOverControls();
					break;
				case GridType.Online:
					SetupOnline();
					controls = GetOnlineControls();
					break;
				case GridType.Host:
					SetupHost();
					controls = GetHostControls();
					break;
				case GridType.Join:
					SetupJoin();
					controls = GetJoinControls();
					break;
				default:
					controls = new List<UIElement>();
					break;
			}

			grid.Children.Clear();
			foreach (UIElement ui in controls)
				grid.Children.Add(ui);
			
		}
		
		// GRID SETUP METHODS FOR MAIN MENU
		void SetupMain() {

			for (int i = 0; i < 3; i++)
				grid.ColumnDefinitions.Add(new ColumnDefinition());
			grid.ColumnDefinitions[1].Width = new GridLength(100);
			
			for (int i = 0; i < 7; i++) {
				RowDefinition row = new RowDefinition();
				if (i == 1)
					row.Height = new GridLength(75);
				else if (i == 2)
					row.Height = new GridLength(25);
				else if (i < 6 && i > 0)
					row.Height = new GridLength(50);
				grid.RowDefinitions.Add(row);
			}

		}
		void SetupGame() {

			for(int i = 0; i < 10; i++) {
				ColumnDefinition column = new ColumnDefinition();
				RowDefinition row = new RowDefinition();
				if (i > 0 && i < 9) {
					column.Width = new GridLength(50);
					row.Height = new GridLength(50);
				}
				grid.ColumnDefinitions.Add(column);
				grid.RowDefinitions.Add(row);
			}

		}
		void SetupGameOver() {

			for(int i = 0; i < 4; i++) {
				grid.ColumnDefinitions.Add(new ColumnDefinition());
				grid.RowDefinitions.Add(new RowDefinition());
			}
			grid.ColumnDefinitions.Add(new ColumnDefinition());
		
		}
		void SetupOnline() {

			for(int i = 0; i < 4; i++) {
				ColumnDefinition column = new ColumnDefinition();
				RowDefinition row = new RowDefinition();
				if (i > 0 && i < 3) {
					column.Width = new GridLength(100);
					row.Height = new GridLength(50);
				}
				grid.ColumnDefinitions.Add(column);
				grid.RowDefinitions.Add(row);
			}

		}
		void SetupHost() {

			for (int i = 0; i < 4; i++) {
				ColumnDefinition column = new ColumnDefinition();
				RowDefinition row = new RowDefinition();
				if (i == 1) {
					column.Width = new GridLength(160);
					row.Height = new GridLength(50);
				} else if (i == 2) {
					column.Width = new GridLength(70);
					row.Height = new GridLength(50);
				}
				grid.ColumnDefinitions.Add(column);
				grid.RowDefinitions.Add(row);
			}

		}
		void SetupJoin() {

			for (int i = 0; i < 5; i++)
				grid.ColumnDefinitions.Add(new ColumnDefinition());
			grid.ColumnDefinitions[1].Width = new GridLength(125);
			grid.ColumnDefinitions[2].Width = new GridLength(25);
			grid.ColumnDefinitions[3].Width = new GridLength(75);

			for (int i = 0; i < 4; i++) {
				RowDefinition row = new RowDefinition();
				if (i > 0 && i < 3)
					row.Height = new GridLength(50);
				grid.RowDefinitions.Add(row);
			}

		}

		// GET METHODS FOR MAIN MENU CONTROLS (BUTTONS)
		List<UIElement> GetMainControls() {
			List<UIElement> controls = new List<UIElement>();

			TextBlock main_Text = new TextBlock();
			main_Text.Text = "CHESS";
			main_Text.FontSize = 40;
			main_Text.TextAlignment = TextAlignment.Center;
			main_Text.HorizontalAlignment = HorizontalAlignment.Center;
			main_Text.VerticalAlignment = VerticalAlignment.Top;
			Grid.SetColumn(main_Text, 0);
			Grid.SetRow(main_Text, 1);
			Grid.SetColumnSpan(main_Text, 3);
			controls.Add(main_Text);

			TextBlock author_Text = new TextBlock();
			author_Text.Text = "By: Tim Rundström";
			author_Text.FontSize = 15;
			author_Text.TextAlignment = TextAlignment.Center;
			author_Text.HorizontalAlignment = HorizontalAlignment.Center;
			author_Text.VerticalAlignment = VerticalAlignment.Bottom;
			Grid.SetColumn(author_Text, 0);
			Grid.SetRow(author_Text, 1);
			Grid.SetColumnSpan(author_Text, 3);
			controls.Add(author_Text);

			Button single_Btn = new Button();
			single_Btn.Content = "Single";
			single_Btn.FontSize = 20;
			single_Btn.Margin = new Thickness(5);
			single_Btn.Click += Play_Single_Btn_Click;
			Grid.SetColumn(single_Btn, 1);
			Grid.SetRow(single_Btn, 3);
			controls.Add(single_Btn);

			Button online_Btn = new Button();
			online_Btn.Content = "Online";
			online_Btn.FontSize = 20;
			online_Btn.Margin = new Thickness(5);
			online_Btn.Click += Online_Btn_Click;
			Grid.SetColumn(online_Btn, 1);
			Grid.SetRow(online_Btn, 4);
			controls.Add(online_Btn);

			Button quit_Btn = new Button();
			quit_Btn.Content = "Quit";
			quit_Btn.FontSize = 20;
			quit_Btn.Margin = new Thickness(5);
			quit_Btn.Click += Quit_Btn_Click;
			Grid.SetColumn(quit_Btn, 1);
			Grid.SetRow(quit_Btn, 5);
			controls.Add(quit_Btn);

			return controls;
		}
		List<UIElement> GetGameControls() {
			List<UIElement> controls = new List<UIElement>();

			TextBlock whitePointsTb = new TextBlock();
			whitePointsTb.Name = "whitePointsTb";
			whitePointsTb.TextAlignment = TextAlignment.Center;
			whitePointsTb.HorizontalAlignment = HorizontalAlignment.Center;
			whitePointsTb.VerticalAlignment = VerticalAlignment.Center;
			Grid.SetColumn(whitePointsTb, 0);
			Grid.SetRow(whitePointsTb, 0);
			Grid.SetColumnSpan(whitePointsTb, 3);
			whitePointsTb.FontSize = 15;
			controls.Add(whitePointsTb);

			TextBlock blackPointsTb = new TextBlock();
			blackPointsTb.Name = "blackPointsTb";
			blackPointsTb.TextAlignment = TextAlignment.Center;
			blackPointsTb.HorizontalAlignment = HorizontalAlignment.Center;
			blackPointsTb.VerticalAlignment = VerticalAlignment.Center;
			Grid.SetColumn(blackPointsTb, 7);
			Grid.SetRow(blackPointsTb, 0);
			Grid.SetColumnSpan(blackPointsTb, 3);
			blackPointsTb.FontSize = 15;
			controls.Add(blackPointsTb);

			TextBlock turnTb = new TextBlock();
			turnTb.Name = "turnTb";
			turnTb.TextAlignment = TextAlignment.Center;
			turnTb.HorizontalAlignment = HorizontalAlignment.Center;
			turnTb.VerticalAlignment = VerticalAlignment.Center;
			Grid.SetColumn(turnTb, 3);
			Grid.SetRow(turnTb, 0);
			Grid.SetColumnSpan(turnTb, 4);
			turnTb.FontSize = 20;
			controls.Add(turnTb);

			TextBlock colorTb = new TextBlock();
			colorTb.Name = "colorTb";
			colorTb.TextAlignment = TextAlignment.Center;
			colorTb.HorizontalAlignment = HorizontalAlignment.Center;
			colorTb.VerticalAlignment = VerticalAlignment.Bottom;
			Grid.SetColumn(colorTb, 3);
			Grid.SetRow(colorTb, 0);
			Grid.SetColumnSpan(colorTb, 4);
			colorTb.FontSize = 12;
			controls.Add(colorTb);

			for (int i = 0; i < 8; i++) {
				TextBlock horizontalTb = new TextBlock();
				horizontalTb.Text = (i + 1).ToString();
				horizontalTb.HorizontalAlignment = HorizontalAlignment.Right;
				horizontalTb.VerticalAlignment = VerticalAlignment.Center;
				Grid.SetColumn(horizontalTb, 0);
				Grid.SetRow(horizontalTb, 8 - i);
				controls.Add(horizontalTb);

				TextBlock verticalTb = new TextBlock();
				verticalTb.Text = ((char)(65 + i)).ToString();
				verticalTb.HorizontalAlignment = HorizontalAlignment.Center;
				verticalTb.VerticalAlignment = VerticalAlignment.Top;
				Grid.SetColumn(verticalTb, i + 1);
				Grid.SetRow(verticalTb, 9);
				controls.Add(verticalTb);
			}

			MainWindow.board.buttons.Clear();
			bool white = true;
			for (int i = 0; i < 8; i++) {
				for (int j = 0; j < 8; j++) {
					Position pos = new Position(j + 1, 8 - i);
					Button btn = new Button();

					Grid.SetColumn(btn, j + 1);
					Grid.SetRow(btn, i + 1);

					btn.Name = pos.btnName;
					btn.FontSize = 40;

					if (white)
						btn.Background = new SolidColorBrush(Colors.White);
					else
						btn.Background = new SolidColorBrush(Colors.Gray);
					white = white ? false : true;

					btn.BorderBrush = new SolidColorBrush(Colors.Black);
					btn.BorderThickness = new Thickness(3);
					btn.Padding = new Thickness(0, -5, 0, 0);
					btn.Margin = new Thickness(2);
					btn.Style = btnStyle;

					MainWindow.board.buttons.Add(pos.name, btn);
					controls.Add(btn);
				}
				white = white ? false : true;
			}

			SetGameButtonEvents();
			return controls;
		}
		List<UIElement> GetGameOverControls() {
			List<UIElement> controls = new List<UIElement>();

			TextBlock tb = new TextBlock();
			tb.FontSize = 50;
			tb.HorizontalAlignment = HorizontalAlignment.Center;
			tb.VerticalAlignment = VerticalAlignment.Center;
			tb.TextAlignment = TextAlignment.Center;
			Grid.SetColumn(tb, 1);
			Grid.SetRow(tb, 1);
			Grid.SetColumnSpan(tb, 3);
			tb.Text = MainWindow.board.GetVictory();
			controls.Add(tb);

			Button btn = new Button();
			btn.FontSize = 20;
			btn.Content = "Main menu";
			btn.HorizontalAlignment = HorizontalAlignment.Center;
			btn.VerticalAlignment = VerticalAlignment.Center;
			Grid.SetColumn(btn, 2);
			Grid.SetRow(btn, 2);
			btn.Click += Menu_Btn_Click;
			controls.Add(btn);

			return controls;
		}
		List<UIElement> GetOnlineControls() {
			List<UIElement> controls = new List<UIElement>();

			Button host_Btn = new Button();
			host_Btn.Content = "Host";
			host_Btn.FontSize = 20;
			host_Btn.Margin = new Thickness(5);
			host_Btn.Click += Host_Btn_Click;
			Grid.SetColumn(host_Btn, 1);
			Grid.SetRow(host_Btn, 1);
			controls.Add(host_Btn);

			Button join_Btn = new Button();
			join_Btn.Content = "Join";
			join_Btn.FontSize = 20;
			join_Btn.Margin = new Thickness(5);
			join_Btn.Click += Join_Btn_Click;
			Grid.SetColumn(join_Btn, 2);
			Grid.SetRow(join_Btn, 1);
			controls.Add(join_Btn);

			Button back_Btn = new Button();
			back_Btn.Content = "Back";
			back_Btn.FontSize = 20;
			back_Btn.Margin = new Thickness(5);
			back_Btn.Click += Menu_Btn_Click;
			Grid.SetColumn(back_Btn, 1);
			Grid.SetRow(back_Btn, 2);
			back_Btn.SetValue(Grid.ColumnSpanProperty, 2);
			controls.Add(back_Btn);


			return controls;
		}
		List<UIElement> GetHostControls() {
			List<UIElement> controls = new List<UIElement>();

			string ip = MainWindow.server.IP;
			string port = MainWindow.server.port.ToString();

			TextBlock address_Text = new TextBlock();
			address_Text.Name = "address_TextBlock";
			address_Text.Text = ip;
			address_Text.FontSize = 20;
			address_Text.Margin = new Thickness(5);

			Border border1 = new Border();
			border1.BorderBrush = new SolidColorBrush(Colors.Black);
			border1.BorderThickness = new Thickness(1);
			border1.Margin = new Thickness(5);
			Grid.SetColumn(border1, 1);
			Grid.SetRow(border1, 1);
			border1.Child = address_Text;
			controls.Add(border1);

			TextBlock port_Text = new TextBlock();
			address_Text.Name = "port_TextBlock";
			port_Text.Text = port;
			port_Text.FontSize = 20;
			port_Text.Margin = new Thickness(5);

			Border border2 = new Border();
			border2.BorderBrush = new SolidColorBrush(Colors.Black);
			border2.BorderThickness = new Thickness(1);
			border2.Margin = new Thickness(5);
			Grid.SetColumn(border2, 2);
			Grid.SetRow(border2, 1);
			border2.Child = port_Text;
			controls.Add(border2);

			Button back_Btn = new Button();
			back_Btn.Content = "Back";
			back_Btn.FontSize = 20;
			back_Btn.Margin = new Thickness(5);
			back_Btn.Click += Online_Btn_Click;
			Grid.SetColumn(back_Btn, 1);
			Grid.SetRow(back_Btn, 2);
			back_Btn.SetValue(Grid.ColumnSpanProperty, 2);
			controls.Add(back_Btn);

			return controls;
		}
		List<UIElement> GetJoinControls() {
			List<UIElement> controls = new List<UIElement>();

			TextBox address_Text = new TextBox();
			address_Text.Name = "address_Textbox";
			address_Text.FontSize = 20;
			address_Text.Margin = new Thickness(5);
			address_Text.Padding = new Thickness(0, 5, 0, 0);
			Grid.SetColumn(address_Text, 1);
			Grid.SetRow(address_Text, 1);
			Grid.SetColumnSpan(address_Text, 2);
			controls.Add(address_Text);

			TextBox port_Text = new TextBox();
			port_Text.Name = "port_Textbox";
			port_Text.FontSize = 20;
			port_Text.Margin = new Thickness(5);
			port_Text.Padding = new Thickness(0, 5, 0, 0);
			Grid.SetColumn(port_Text, 3);
			Grid.SetRow(port_Text, 1);
			controls.Add(port_Text);

			Button connect_Btn = new Button();
			connect_Btn.Content = "Connect";
			connect_Btn.FontSize = 20;
			connect_Btn.Margin = new Thickness(5);
			connect_Btn.Click += Connect_Btn_Click;
			Grid.SetColumn(connect_Btn, 1);
			Grid.SetRow(connect_Btn, 2);
			controls.Add(connect_Btn);

			Button back_Btn = new Button();
			back_Btn.Content = "Back";
			back_Btn.FontSize = 20;
			back_Btn.Margin = new Thickness(5);
			back_Btn.Click += Online_Btn_Click;
			Grid.SetColumn(back_Btn, 2);
			Grid.SetRow(back_Btn, 2);
			Grid.SetColumnSpan(back_Btn, 2);
			controls.Add(back_Btn);

			return controls;
		}
		
		// MAIN MENU BUTTONS
		void Play_Single_Btn_Click(object sender, RoutedEventArgs e) {
			SetGrid(GridType.Game);
			MainWindow.board.SetupGame(false, true);
		}
		void Online_Btn_Click(object sender, RoutedEventArgs e) {
			SetGrid(GridType.Online);
		}
		void Quit_Btn_Click(object sender, RoutedEventArgs e) {
			Application.Current.Shutdown();
		}

		// ONLINE MENU BUTTONS
		void Host_Btn_Click(object sender, RoutedEventArgs e) {
			SetGrid(GridType.Host);
			MainWindow.server.Start();
		}
		void Join_Btn_Click(object sender, RoutedEventArgs e) {
			SetGrid(GridType.Join);
		}
		void Menu_Btn_Click(object sender, RoutedEventArgs e) {
			SetGrid(GridType.Main);
		}
		
		// JOIN MENU BUTTON	
		void Connect_Btn_Click(object sender, RoutedEventArgs e) {
			string address = "";
			string port = "";

			foreach (TextBox tb in FindVisualChildren<TextBox>(grid)) {
				if (tb.Name == "address_Textbox")
					address = tb.Text;
				if (tb.Name == "port_Textbox")
					port = tb.Text;
			}

			try {
				MainWindow.client.Start(address, Convert.ToInt32(port));
				SetGrid(GridType.Game);
				MainWindow.board.SetupGame(true, false);
			} catch (Exception) {
				MessageBox.Show("Server not found.\nPlease make sure the IP adress and port is correct.");
			}

		}

		// Find objects in grid.children
		public IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject {
			if (depObj != null) {
				for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++) {
					DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
					if (child != null && child is T) {
						yield return (T)child;
					}

					foreach (T childOfChild in FindVisualChildren<T>(child)) {
						yield return childOfChild;
					}
				}
			}
		}

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
