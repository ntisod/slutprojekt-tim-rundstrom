using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace Chess_online {
	public enum GridType { Main, Single, Online, Host, Join}
	public class GridManager {

		Grid grid;

		public GridManager(Grid grid) {
			this.grid = grid;
		}

		// SET DESIRED GRID / CONTROL
		public void SetGrid(GridType type) {
			grid.ColumnDefinitions.Clear();
			grid.RowDefinitions.Clear();

			switch (type) {
				case GridType.Main:
					SetupMain();
					break;
				case GridType.Single:
					SetupSingle();
					break;
				case GridType.Online:
					SetupOnline();
					break;
				case GridType.Host:
					SetupHost();
					break;
				case GridType.Join:
					SetupJoin();
					break;
			}
		}
		public void SetControls(GridType type) {

			List<UIElement> controls = GetControls(type);

			grid.Children.Clear();
			foreach (UIElement control in controls)
				grid.Children.Add(control);

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

		}
		void SetupSingle() {

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
			SetupOnline();
		}
		void SetupJoin() {
			SetupOnline();
		}

		// GET DESIRED CONTROL
		List<UIElement> GetControls(GridType type) {
			switch (type) {
				case GridType.Main:
					return GetMainControls();
				case GridType.Single:
					return GetSingeControls();
				case GridType.Online:
					return GetOnlineControls();
				case GridType.Host:
					return GetHostControls();
				case GridType.Join:
					return GetJoinControls();
			}
			return null;
		}

		// GET METHODS FOR MAIN MENU CONTROLS (BUTTONS)
		List<UIElement> GetMainControls() {
			List<UIElement> controls = new List<UIElement>();

			Button single_Btn = new Button();
			single_Btn.Content = "Single";
			single_Btn.FontSize = 20;
			single_Btn.Margin = new Thickness(5);
			single_Btn.Click += Single_Btn_Click;
			Grid.SetColumn(single_Btn, 1);
			Grid.SetRow(single_Btn, 1);
			controls.Add(single_Btn);

			Button online_Btn = new Button();
			online_Btn.Content = "Online";
			online_Btn.FontSize = 20;
			online_Btn.Margin = new Thickness(5);
			online_Btn.Click += Online_Btn_Click;
			Grid.SetColumn(online_Btn, 1);
			Grid.SetRow(online_Btn, 2);
			controls.Add(online_Btn);

			Button quit_Btn = new Button();
			quit_Btn.Content = "Quit";
			quit_Btn.FontSize = 20;
			quit_Btn.Margin = new Thickness(5);
			quit_Btn.Click += Quit_Btn_Click;
			Grid.SetColumn(quit_Btn, 1);
			Grid.SetRow(quit_Btn, 3);
			controls.Add(quit_Btn);

			return controls;
		}
		List<UIElement> GetSingeControls() {
			List<UIElement> controls = new List<UIElement>();

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

			TextBlock address_Text = new TextBlock();
			address_Text.Text = "ADDRESS";
			address_Text.FontSize = 20;
			address_Text.Margin = new Thickness(5);
			Grid.SetColumn(address_Text, 1);
			Grid.SetRow(address_Text, 1);
			controls.Add(address_Text);

			TextBlock port_Text = new TextBlock();
			port_Text.Text = "PORT";
			port_Text.FontSize = 20;
			port_Text.Margin = new Thickness(5);
			Grid.SetColumn(port_Text, 2);
			Grid.SetRow(port_Text, 1);
			controls.Add(port_Text);

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
			address_Text.FontSize = 20;
			address_Text.Margin = new Thickness(5);
			Grid.SetColumn(address_Text, 1);
			Grid.SetRow(address_Text, 1);
			controls.Add(address_Text);

			TextBox port_Text = new TextBox();
			port_Text.FontSize = 20;
			port_Text.Margin = new Thickness(5);
			Grid.SetColumn(port_Text, 2);
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
			controls.Add(back_Btn);

			return controls;
		}

		// MAIN MENU BUTTONS
		void Single_Btn_Click(object sender, RoutedEventArgs e) {

			SetControls(GridType.Single);
			MainWindow.gridManager.SetGrid(GridType.Single);

		}
		void Online_Btn_Click(object sender, RoutedEventArgs e) {

			SetControls(GridType.Online);
			MainWindow.gridManager.SetGrid(GridType.Online);

		}
		void Quit_Btn_Click(object sender, RoutedEventArgs e) {

			Application.Current.Shutdown();

		}

		// ONLINE MENU BUTTONS
		void Host_Btn_Click(object sender, RoutedEventArgs e) {
			SetGrid(GridType.Host);
			SetControls(GridType.Host);
		}
		void Join_Btn_Click(object sender, RoutedEventArgs e) {
			SetGrid(GridType.Join);
			SetControls(GridType.Join);
		}
		void Menu_Btn_Click(object sender, RoutedEventArgs e) {
			SetGrid(GridType.Main);
			SetControls(GridType.Main);
		}

		// JOIN MENU BUTTON	
		void Connect_Btn_Click(object sender, RoutedEventArgs e) {

		}
	}
}
