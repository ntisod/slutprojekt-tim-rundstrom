using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;

namespace Chess_online {
	public enum GridType { Main, Game, Online, Host, Join}
	public class GridManager {

		Grid grid;
		Style btnStyle;

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

			ColumnDefinition col1 = new ColumnDefinition();
			ColumnDefinition col2 = new ColumnDefinition();
			col2.Width = new GridLength(100);
			ColumnDefinition col3 = new ColumnDefinition();
			grid.ColumnDefinitions.Add(col1);
			grid.ColumnDefinitions.Add(col2);
			grid.ColumnDefinitions.Add(col3);

			RowDefinition row1 = new RowDefinition();
			RowDefinition row2 = new RowDefinition();
			row2.Height = new GridLength(75);
			RowDefinition row3 = new RowDefinition();
			row3.Height = new GridLength(25);
			RowDefinition row4 = new RowDefinition();
			row4.Height = new GridLength(50);
			RowDefinition row5 = new RowDefinition();
			row5.Height = new GridLength(50);
			RowDefinition row6 = new RowDefinition();
			row6.Height = new GridLength(50);
			RowDefinition row7 = new RowDefinition();
			grid.RowDefinitions.Add(row1);
			grid.RowDefinitions.Add(row2);
			grid.RowDefinitions.Add(row3);
			grid.RowDefinitions.Add(row4);
			grid.RowDefinitions.Add(row5);
			grid.RowDefinitions.Add(row6);
			grid.RowDefinitions.Add(row7);

		}
		void SetupGame() {

			ColumnDefinition col1 = new ColumnDefinition();
			ColumnDefinition col2 = new ColumnDefinition();
			col2.Width = new GridLength(50);
			ColumnDefinition col3 = new ColumnDefinition();
			col3.Width = new GridLength(50);
			ColumnDefinition col4 = new ColumnDefinition();
			col4.Width = new GridLength(50);
			ColumnDefinition col5 = new ColumnDefinition();
			col5.Width = new GridLength(50);
			ColumnDefinition col6 = new ColumnDefinition();
			col6.Width = new GridLength(50);
			ColumnDefinition col7 = new ColumnDefinition();
			col7.Width = new GridLength(50);
			ColumnDefinition col8 = new ColumnDefinition();
			col8.Width = new GridLength(50);
			ColumnDefinition col9 = new ColumnDefinition();
			col9.Width = new GridLength(50);
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
			row2.Height = new GridLength(50);
			RowDefinition row3 = new RowDefinition();
			row3.Height = new GridLength(50);
			RowDefinition row4 = new RowDefinition();
			row4.Height = new GridLength(50);
			RowDefinition row5 = new RowDefinition();
			row5.Height = new GridLength(50);
			RowDefinition row6 = new RowDefinition();
			row6.Height = new GridLength(50);
			RowDefinition row7 = new RowDefinition();
			row7.Height = new GridLength(50);
			RowDefinition row8 = new RowDefinition();
			row8.Height = new GridLength(50);
			RowDefinition row9 = new RowDefinition();
			row9.Height = new GridLength(50);
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
		void SetupOnline() {
			ColumnDefinition col1 = new ColumnDefinition();
			ColumnDefinition col2 = new ColumnDefinition();
			col2.Width = new GridLength(100);
			ColumnDefinition col3 = new ColumnDefinition();
			col3.Width = new GridLength(100);
			ColumnDefinition col4 = new ColumnDefinition();
			grid.ColumnDefinitions.Add(col1);
			grid.ColumnDefinitions.Add(col2);
			grid.ColumnDefinitions.Add(col3);
			grid.ColumnDefinitions.Add(col4);

			RowDefinition row1 = new RowDefinition();
			RowDefinition row2 = new RowDefinition();
			row2.Height = new GridLength(50);
			RowDefinition row3 = new RowDefinition();
			row3.Height = new GridLength(50);
			RowDefinition row4 = new RowDefinition();
			grid.RowDefinitions.Add(row1);
			grid.RowDefinitions.Add(row2);
			grid.RowDefinitions.Add(row3);
			grid.RowDefinitions.Add(row4);
		}
		void SetupHost() {
			ColumnDefinition col1 = new ColumnDefinition();
			ColumnDefinition col2 = new ColumnDefinition();
			col2.Width = new GridLength(160);
			ColumnDefinition col3 = new ColumnDefinition();
			col3.Width = new GridLength(70);
			ColumnDefinition col4 = new ColumnDefinition();
			grid.ColumnDefinitions.Add(col1);
			grid.ColumnDefinitions.Add(col2);
			grid.ColumnDefinitions.Add(col3);
			grid.ColumnDefinitions.Add(col4);

			RowDefinition row1 = new RowDefinition();
			RowDefinition row2 = new RowDefinition();
			row2.Height = new GridLength(50);
			RowDefinition row3 = new RowDefinition();
			row3.Height = new GridLength(50);
			RowDefinition row4 = new RowDefinition();
			grid.RowDefinitions.Add(row1);
			grid.RowDefinitions.Add(row2);
			grid.RowDefinitions.Add(row3);
			grid.RowDefinitions.Add(row4);
		}
		void SetupJoin() {
			ColumnDefinition col1 = new ColumnDefinition();
			ColumnDefinition col2 = new ColumnDefinition();
			col2.Width = new GridLength(125);
			ColumnDefinition col3 = new ColumnDefinition();
			col3.Width = new GridLength(25);
			ColumnDefinition col4 = new ColumnDefinition();
			col4.Width = new GridLength(75);
			ColumnDefinition col5 = new ColumnDefinition();
			grid.ColumnDefinitions.Add(col1);
			grid.ColumnDefinitions.Add(col2);
			grid.ColumnDefinitions.Add(col3);
			grid.ColumnDefinitions.Add(col4);
			grid.ColumnDefinitions.Add(col5);

			RowDefinition row1 = new RowDefinition();
			RowDefinition row2 = new RowDefinition();
			row2.Height = new GridLength(50);
			RowDefinition row3 = new RowDefinition();
			row3.Height = new GridLength(50);
			RowDefinition row4 = new RowDefinition();
			grid.RowDefinitions.Add(row1);
			grid.RowDefinitions.Add(row2);
			grid.RowDefinitions.Add(row3);
			grid.RowDefinitions.Add(row4);
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


			for (int i = 0; i < 8; i++) {
				TextBlock tb = new TextBlock();
				tb.Text = (i + 1).ToString();
				tb.HorizontalAlignment = HorizontalAlignment.Right;
				tb.VerticalAlignment = VerticalAlignment.Center;
				Grid.SetColumn(tb, 0);
				Grid.SetRow(tb, 8 - i);
				controls.Add(tb);
			}

			for(int i = 0; i < 8; i++) {
				TextBlock tb = new TextBlock();
				tb.Text = ((char)(65 + i)).ToString();
				tb.HorizontalAlignment = HorizontalAlignment.Center;
				tb.VerticalAlignment = VerticalAlignment.Top;
				Grid.SetColumn(tb, i + 1);
				Grid.SetRow(tb, 9);
				controls.Add(tb);
			}

			MainWindow.board.buttons.Clear();
			bool white = true;
			for (int i = 0; i < 8; i++) {
				for (int j = 0; j < 8; j++) {
					Position pos = new Position(j + 1, 8 - i);
					Button btn = new Button();
					btn.Name = pos.BtnName;
					Grid.SetColumn(btn, j + 1);
					Grid.SetRow(btn, i + 1);
					btn.FontSize = 40;
					if (white) {
						btn.Background = new SolidColorBrush(Colors.White);
						white = false;
					} else {
						btn.Background = new SolidColorBrush(Colors.Gray);
						white = true;
					}
					btn.BorderBrush = new SolidColorBrush(Colors.Black);
					btn.BorderThickness = new Thickness(3);
					btn.Padding = new Thickness(0, -5, 0, 0);
					btn.Margin = new Thickness(2);
					MainWindow.board.buttons.Add(pos.Name, btn);
					controls.Add(btn);
				}
				white = white ? false : true;

			}

			foreach (UIElement ui in controls) {
				if (ui is Button) {
					Button btn = (Button)ui;
					btn.Style = btnStyle;
				}
			}

			SetGameButtonEvents();
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

			Button ref_Button = new Button();
			ref_Button.Content = "Ref";
			ref_Button.FontSize = 20;
			ref_Button.Margin = new Thickness(5);
			ref_Button.Width = 35;
			ref_Button.Height = 35;
			ref_Button.HorizontalAlignment = HorizontalAlignment.Left;
			ref_Button.Click += Refresh_Host_Btn_Click;
			Grid.SetColumn(ref_Button, 3);
			Grid.SetRow(ref_Button, 1);
			controls.Add(ref_Button);

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

		// HOST MENU BUTTON
		void Refresh_Host_Btn_Click(object sender, RoutedEventArgs e) {
			SetGrid(GridType.Host);
		}

		// JOIN MENU BUTTON	
		void Connect_Btn_Click(object sender, RoutedEventArgs e) {
			string address = "";
			string port = "";
			int portInt;

			foreach (TextBox tb in FindVisualChildren<TextBox>(grid)) {
				if (tb.Name == "address_Textbox")
					address = tb.Text;
				if (tb.Name == "port_Textbox")
					port = tb.Text;
			}

			// TEST
			address = "127.0.0.1";
			port = "81";

			try {
				portInt = Convert.ToInt32(port);
				MainWindow.client.Start(address, portInt);

				SetGrid(GridType.Game);
				MainWindow.board.SetupGame(true, false);
			} catch (Exception) {
			}
			
		}

		// Find objects in grid.children
		public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject {
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

			MainWindow.board.buttons[new Position(1, 8).Name].Click += new RoutedEventHandler(Btn_A8_Click);
			MainWindow.board.buttons[new Position(1, 7).Name].Click += new RoutedEventHandler(Btn_A7_Click);
			MainWindow.board.buttons[new Position(1, 6).Name].Click += new RoutedEventHandler(Btn_A6_Click);
			MainWindow.board.buttons[new Position(1, 5).Name].Click += new RoutedEventHandler(Btn_A5_Click);
			MainWindow.board.buttons[new Position(1, 4).Name].Click += new RoutedEventHandler(Btn_A4_Click);
			MainWindow.board.buttons[new Position(1, 3).Name].Click += new RoutedEventHandler(Btn_A3_Click);
			MainWindow.board.buttons[new Position(1, 2).Name].Click += new RoutedEventHandler(Btn_A2_Click);
			MainWindow.board.buttons[new Position(1, 1).Name].Click += new RoutedEventHandler(Btn_A1_Click);

			MainWindow.board.buttons[new Position(2, 8).Name].Click += new RoutedEventHandler(Btn_B8_Click);
			MainWindow.board.buttons[new Position(2, 7).Name].Click += new RoutedEventHandler(Btn_B7_Click);
			MainWindow.board.buttons[new Position(2, 6).Name].Click += new RoutedEventHandler(Btn_B6_Click);
			MainWindow.board.buttons[new Position(2, 5).Name].Click += new RoutedEventHandler(Btn_B5_Click);
			MainWindow.board.buttons[new Position(2, 4).Name].Click += new RoutedEventHandler(Btn_B4_Click);
			MainWindow.board.buttons[new Position(2, 3).Name].Click += new RoutedEventHandler(Btn_B3_Click);
			MainWindow.board.buttons[new Position(2, 2).Name].Click += new RoutedEventHandler(Btn_B2_Click);
			MainWindow.board.buttons[new Position(2, 1).Name].Click += new RoutedEventHandler(Btn_B1_Click);

			MainWindow.board.buttons[new Position(3, 8).Name].Click += new RoutedEventHandler(Btn_C8_Click);
			MainWindow.board.buttons[new Position(3, 7).Name].Click += new RoutedEventHandler(Btn_C7_Click);
			MainWindow.board.buttons[new Position(3, 6).Name].Click += new RoutedEventHandler(Btn_C6_Click);
			MainWindow.board.buttons[new Position(3, 5).Name].Click += new RoutedEventHandler(Btn_C5_Click);
			MainWindow.board.buttons[new Position(3, 4).Name].Click += new RoutedEventHandler(Btn_C4_Click);
			MainWindow.board.buttons[new Position(3, 3).Name].Click += new RoutedEventHandler(Btn_C3_Click);
			MainWindow.board.buttons[new Position(3, 2).Name].Click += new RoutedEventHandler(Btn_C2_Click);
			MainWindow.board.buttons[new Position(3, 1).Name].Click += new RoutedEventHandler(Btn_C1_Click);

			MainWindow.board.buttons[new Position(4, 8).Name].Click += new RoutedEventHandler(Btn_D8_Click);
			MainWindow.board.buttons[new Position(4, 7).Name].Click += new RoutedEventHandler(Btn_D7_Click);
			MainWindow.board.buttons[new Position(4, 6).Name].Click += new RoutedEventHandler(Btn_D6_Click);
			MainWindow.board.buttons[new Position(4, 5).Name].Click += new RoutedEventHandler(Btn_D5_Click);
			MainWindow.board.buttons[new Position(4, 4).Name].Click += new RoutedEventHandler(Btn_D4_Click);
			MainWindow.board.buttons[new Position(4, 3).Name].Click += new RoutedEventHandler(Btn_D3_Click);
			MainWindow.board.buttons[new Position(4, 2).Name].Click += new RoutedEventHandler(Btn_D2_Click);
			MainWindow.board.buttons[new Position(4, 1).Name].Click += new RoutedEventHandler(Btn_D1_Click);

			MainWindow.board.buttons[new Position(5, 8).Name].Click += new RoutedEventHandler(Btn_E8_Click);
			MainWindow.board.buttons[new Position(5, 7).Name].Click += new RoutedEventHandler(Btn_E7_Click);
			MainWindow.board.buttons[new Position(5, 6).Name].Click += new RoutedEventHandler(Btn_E6_Click);
			MainWindow.board.buttons[new Position(5, 5).Name].Click += new RoutedEventHandler(Btn_E5_Click);
			MainWindow.board.buttons[new Position(5, 4).Name].Click += new RoutedEventHandler(Btn_E4_Click);
			MainWindow.board.buttons[new Position(5, 3).Name].Click += new RoutedEventHandler(Btn_E3_Click);
			MainWindow.board.buttons[new Position(5, 2).Name].Click += new RoutedEventHandler(Btn_E2_Click);
			MainWindow.board.buttons[new Position(5, 1).Name].Click += new RoutedEventHandler(Btn_E1_Click);

			MainWindow.board.buttons[new Position(6, 8).Name].Click += new RoutedEventHandler(Btn_F8_Click);
			MainWindow.board.buttons[new Position(6, 7).Name].Click += new RoutedEventHandler(Btn_F7_Click);
			MainWindow.board.buttons[new Position(6, 6).Name].Click += new RoutedEventHandler(Btn_F6_Click);
			MainWindow.board.buttons[new Position(6, 5).Name].Click += new RoutedEventHandler(Btn_F5_Click);
			MainWindow.board.buttons[new Position(6, 4).Name].Click += new RoutedEventHandler(Btn_F4_Click);
			MainWindow.board.buttons[new Position(6, 3).Name].Click += new RoutedEventHandler(Btn_F3_Click);
			MainWindow.board.buttons[new Position(6, 2).Name].Click += new RoutedEventHandler(Btn_F2_Click);
			MainWindow.board.buttons[new Position(6, 1).Name].Click += new RoutedEventHandler(Btn_F1_Click);

			MainWindow.board.buttons[new Position(7, 8).Name].Click += new RoutedEventHandler(Btn_G8_Click);
			MainWindow.board.buttons[new Position(7, 7).Name].Click += new RoutedEventHandler(Btn_G7_Click);
			MainWindow.board.buttons[new Position(7, 6).Name].Click += new RoutedEventHandler(Btn_G6_Click);
			MainWindow.board.buttons[new Position(7, 5).Name].Click += new RoutedEventHandler(Btn_G5_Click);
			MainWindow.board.buttons[new Position(7, 4).Name].Click += new RoutedEventHandler(Btn_G4_Click);
			MainWindow.board.buttons[new Position(7, 3).Name].Click += new RoutedEventHandler(Btn_G3_Click);
			MainWindow.board.buttons[new Position(7, 2).Name].Click += new RoutedEventHandler(Btn_G2_Click);
			MainWindow.board.buttons[new Position(7, 1).Name].Click += new RoutedEventHandler(Btn_G1_Click);

			MainWindow.board.buttons[new Position(8, 8).Name].Click += new RoutedEventHandler(Btn_H8_Click);
			MainWindow.board.buttons[new Position(8, 7).Name].Click += new RoutedEventHandler(Btn_H7_Click);
			MainWindow.board.buttons[new Position(8, 6).Name].Click += new RoutedEventHandler(Btn_H6_Click);
			MainWindow.board.buttons[new Position(8, 5).Name].Click += new RoutedEventHandler(Btn_H5_Click);
			MainWindow.board.buttons[new Position(8, 4).Name].Click += new RoutedEventHandler(Btn_H4_Click);
			MainWindow.board.buttons[new Position(8, 3).Name].Click += new RoutedEventHandler(Btn_H3_Click);
			MainWindow.board.buttons[new Position(8, 2).Name].Click += new RoutedEventHandler(Btn_H2_Click);
			MainWindow.board.buttons[new Position(8, 1).Name].Click += new RoutedEventHandler(Btn_H1_Click);
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
