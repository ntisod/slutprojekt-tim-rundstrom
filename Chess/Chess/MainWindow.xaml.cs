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

namespace Chess {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	/// 
	public enum State { White, Black, GameOver }
	public partial class MainWindow : Window {

		Chessboard board;

		public MainWindow() {
			InitializeComponent();
			Start();
		}

		void Start() {
			board = new Chessboard();
			SetButtonEvents();

			// Add all buttons to grid
			foreach(KeyValuePair<string, Button> b in board.buttons) {
				b.Value.Style = FindResource("ChessCell") as Style;
				grid.Children.Add(b.Value);
			}

			whitePoints.Text = $"White points: {board.whitePlayer.points}";
			blackPoints.Text = $"Black points: {board.blackPlayer.points}";

			board.whitePlayer.pieces.Add(new Pawn(new Position(2, 3), true));
			board.blackPlayer.pieces.Add(new Pawn(new Position(5, 7), false));

			board.Update();
		}

		void SetButtonEvents() {

			board.buttons[new Position(1, 8).Name].Click += new RoutedEventHandler(Btn_A8_Click);
			board.buttons[new Position(1, 7).Name].Click += new RoutedEventHandler(Btn_A7_Click);
			board.buttons[new Position(1, 6).Name].Click += new RoutedEventHandler(Btn_A6_Click);
			board.buttons[new Position(1, 5).Name].Click += new RoutedEventHandler(Btn_A5_Click);
			board.buttons[new Position(1, 4).Name].Click += new RoutedEventHandler(Btn_A4_Click);
			board.buttons[new Position(1, 3).Name].Click += new RoutedEventHandler(Btn_A3_Click);
			board.buttons[new Position(1, 2).Name].Click += new RoutedEventHandler(Btn_A2_Click);
			board.buttons[new Position(1, 1).Name].Click += new RoutedEventHandler(Btn_A1_Click);

			board.buttons[new Position(2, 8).Name].Click += new RoutedEventHandler(Btn_B8_Click);
			board.buttons[new Position(2, 7).Name].Click += new RoutedEventHandler(Btn_B7_Click);
			board.buttons[new Position(2, 6).Name].Click += new RoutedEventHandler(Btn_B6_Click);
			board.buttons[new Position(2, 5).Name].Click += new RoutedEventHandler(Btn_B5_Click);
			board.buttons[new Position(2, 4).Name].Click += new RoutedEventHandler(Btn_B4_Click);
			board.buttons[new Position(2, 3).Name].Click += new RoutedEventHandler(Btn_B3_Click);
			board.buttons[new Position(2, 2).Name].Click += new RoutedEventHandler(Btn_B2_Click);
			board.buttons[new Position(2, 1).Name].Click += new RoutedEventHandler(Btn_B1_Click);

			board.buttons[new Position(3, 8).Name].Click += new RoutedEventHandler(Btn_C8_Click);
			board.buttons[new Position(3, 7).Name].Click += new RoutedEventHandler(Btn_C7_Click);
			board.buttons[new Position(3, 6).Name].Click += new RoutedEventHandler(Btn_C6_Click);
			board.buttons[new Position(3, 5).Name].Click += new RoutedEventHandler(Btn_C5_Click);
			board.buttons[new Position(3, 4).Name].Click += new RoutedEventHandler(Btn_C4_Click);
			board.buttons[new Position(3, 3).Name].Click += new RoutedEventHandler(Btn_C3_Click);
			board.buttons[new Position(3, 2).Name].Click += new RoutedEventHandler(Btn_C2_Click);
			board.buttons[new Position(3, 1).Name].Click += new RoutedEventHandler(Btn_C1_Click);

			board.buttons[new Position(4, 8).Name].Click += new RoutedEventHandler(Btn_D8_Click);
			board.buttons[new Position(4, 7).Name].Click += new RoutedEventHandler(Btn_D7_Click);
			board.buttons[new Position(4, 6).Name].Click += new RoutedEventHandler(Btn_D6_Click);
			board.buttons[new Position(4, 5).Name].Click += new RoutedEventHandler(Btn_D5_Click);
			board.buttons[new Position(4, 4).Name].Click += new RoutedEventHandler(Btn_D4_Click);
			board.buttons[new Position(4, 3).Name].Click += new RoutedEventHandler(Btn_D3_Click);
			board.buttons[new Position(4, 2).Name].Click += new RoutedEventHandler(Btn_D2_Click);
			board.buttons[new Position(4, 1).Name].Click += new RoutedEventHandler(Btn_D1_Click);

			board.buttons[new Position(5, 8).Name].Click += new RoutedEventHandler(Btn_E8_Click);
			board.buttons[new Position(5, 7).Name].Click += new RoutedEventHandler(Btn_E7_Click);
			board.buttons[new Position(5, 6).Name].Click += new RoutedEventHandler(Btn_E6_Click);
			board.buttons[new Position(5, 5).Name].Click += new RoutedEventHandler(Btn_E5_Click);
			board.buttons[new Position(5, 4).Name].Click += new RoutedEventHandler(Btn_E4_Click);
			board.buttons[new Position(5, 3).Name].Click += new RoutedEventHandler(Btn_E3_Click);
			board.buttons[new Position(5, 2).Name].Click += new RoutedEventHandler(Btn_E2_Click);
			board.buttons[new Position(5, 1).Name].Click += new RoutedEventHandler(Btn_E1_Click);

			board.buttons[new Position(6, 8).Name].Click += new RoutedEventHandler(Btn_F8_Click);
			board.buttons[new Position(6, 7).Name].Click += new RoutedEventHandler(Btn_F7_Click);
			board.buttons[new Position(6, 6).Name].Click += new RoutedEventHandler(Btn_F6_Click);
			board.buttons[new Position(6, 5).Name].Click += new RoutedEventHandler(Btn_F5_Click);
			board.buttons[new Position(6, 4).Name].Click += new RoutedEventHandler(Btn_F4_Click);
			board.buttons[new Position(6, 3).Name].Click += new RoutedEventHandler(Btn_F3_Click);
			board.buttons[new Position(6, 2).Name].Click += new RoutedEventHandler(Btn_F2_Click);
			board.buttons[new Position(6, 1).Name].Click += new RoutedEventHandler(Btn_F1_Click);

			board.buttons[new Position(7, 8).Name].Click += new RoutedEventHandler(Btn_G8_Click);
			board.buttons[new Position(7, 7).Name].Click += new RoutedEventHandler(Btn_G7_Click);
			board.buttons[new Position(7, 6).Name].Click += new RoutedEventHandler(Btn_G6_Click);
			board.buttons[new Position(7, 5).Name].Click += new RoutedEventHandler(Btn_G5_Click);
			board.buttons[new Position(7, 4).Name].Click += new RoutedEventHandler(Btn_G4_Click);
			board.buttons[new Position(7, 3).Name].Click += new RoutedEventHandler(Btn_G3_Click);
			board.buttons[new Position(7, 2).Name].Click += new RoutedEventHandler(Btn_G2_Click);
			board.buttons[new Position(7, 1).Name].Click += new RoutedEventHandler(Btn_G1_Click);

			board.buttons[new Position(8, 8).Name].Click += new RoutedEventHandler(Btn_H8_Click);
			board.buttons[new Position(8, 7).Name].Click += new RoutedEventHandler(Btn_H7_Click);
			board.buttons[new Position(8, 6).Name].Click += new RoutedEventHandler(Btn_H6_Click);
			board.buttons[new Position(8, 5).Name].Click += new RoutedEventHandler(Btn_H5_Click);
			board.buttons[new Position(8, 4).Name].Click += new RoutedEventHandler(Btn_H4_Click);
			board.buttons[new Position(8, 3).Name].Click += new RoutedEventHandler(Btn_H3_Click);
			board.buttons[new Position(8, 2).Name].Click += new RoutedEventHandler(Btn_H2_Click);
			board.buttons[new Position(8, 1).Name].Click += new RoutedEventHandler(Btn_H1_Click);
		}

		public void SetVictor(string message) {
			foreach (KeyValuePair<string, Button> b in board.buttons)
				grid.Children.Remove(b.Value);
			GameOverTxt.Text = message;
			board.state = State.GameOver;
		}

		private void Btn_Reset_Click(object sender, RoutedEventArgs e) {

			MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure?", "Restart Game", MessageBoxButton.YesNo);
			if (messageBoxResult == MessageBoxResult.Yes) {
				SetVictor("");
				Start();
			}

		}

		void ButtonPress(Position position) {
		
			if (board.state == State.White) {
				if (board.selectedButton == null) {
					foreach (Chesspiece p in board.whitePlayer.pieces) {
						if (p.Pos == position)
							board.selectedButton = board.buttons[position.Name];
					}
				} else {
					if (position.BtnName == board.selectedButton.Name)
						board.selectedButton = null;
				}
			} else if (board.state == State.Black) {
				if (board.selectedButton == null) {
					foreach(Chesspiece p in board.blackPlayer.pieces) {
						if (p.Pos == position)
							board.selectedButton = board.buttons[position.Name];
					}
				} else {
					if (position.BtnName == board.selectedButton.Name)
						board.selectedButton = null;
				}
			}

			whitePoints.Text = $"White points: {board.whitePlayer.points}";
			blackPoints.Text = $"Black points: {board.blackPlayer.points}";

			if (board.whitePlayer.hasLost)
				SetVictor("Blacks Won!");
			else if (board.blackPlayer.hasLost)
				SetVictor("Whites Won!");

			board.Update();
		}

		private void Btn_A1_Click(object sender, RoutedEventArgs e) {
			ButtonPress(new Position(1, 1));
		}
		private void Btn_A2_Click(object sender, RoutedEventArgs e) {
			ButtonPress(new Position(1, 2));
		}
		private void Btn_A3_Click(object sender, RoutedEventArgs e) {
			ButtonPress(new Position(1, 3));
		}
		private void Btn_A4_Click(object sender, RoutedEventArgs e) {
			ButtonPress(new Position(1, 4));
		}
		private void Btn_A5_Click(object sender, RoutedEventArgs e) {
			ButtonPress(new Position(1, 5));
		}
		private void Btn_A6_Click(object sender, RoutedEventArgs e) {
			ButtonPress(new Position(1, 6));
		}
		private void Btn_A7_Click(object sender, RoutedEventArgs e) {
			ButtonPress(new Position(1, 7));
		}
		private void Btn_A8_Click(object sender, RoutedEventArgs e) {
			ButtonPress(new Position(1, 8));
		}
		private void Btn_B1_Click(object sender, RoutedEventArgs e) {
			ButtonPress(new Position(2, 1));
		}
		private void Btn_B2_Click(object sender, RoutedEventArgs e) {
			ButtonPress(new Position(2, 2));
		}
		private void Btn_B3_Click(object sender, RoutedEventArgs e) {
			ButtonPress(new Position(2, 3));
		}
		private void Btn_B4_Click(object sender, RoutedEventArgs e) {
			ButtonPress(new Position(2, 4));
		}
		private void Btn_B5_Click(object sender, RoutedEventArgs e) {
			ButtonPress(new Position(2, 5));
		}
		private void Btn_B6_Click(object sender, RoutedEventArgs e) {
			ButtonPress(new Position(2, 6));
		}
		private void Btn_B7_Click(object sender, RoutedEventArgs e) {
			ButtonPress(new Position(2, 7));
		}
		private void Btn_B8_Click(object sender, RoutedEventArgs e) {
			ButtonPress(new Position(2, 8));
		}
		private void Btn_C1_Click(object sender, RoutedEventArgs e) {
			ButtonPress(new Position(3, 1));
		}
		private void Btn_C2_Click(object sender, RoutedEventArgs e) {
			ButtonPress(new Position(3, 2));
		}
		private void Btn_C3_Click(object sender, RoutedEventArgs e) {
			ButtonPress(new Position(3, 3));
		}
		private void Btn_C4_Click(object sender, RoutedEventArgs e) {
			ButtonPress(new Position(3, 4));
		}
		private void Btn_C5_Click(object sender, RoutedEventArgs e) {
			ButtonPress(new Position(3, 5));
		}
		private void Btn_C6_Click(object sender, RoutedEventArgs e) {
			ButtonPress(new Position(3, 6));
		}
		private void Btn_C7_Click(object sender, RoutedEventArgs e) {
			ButtonPress(new Position(3, 7));
		}
		private void Btn_C8_Click(object sender, RoutedEventArgs e) {
			ButtonPress(new Position(3, 8));
		}
		private void Btn_D1_Click(object sender, RoutedEventArgs e) {
			ButtonPress(new Position(4, 1));
		}
		private void Btn_D2_Click(object sender, RoutedEventArgs e) {
			ButtonPress(new Position(4, 2));
		}
		private void Btn_D3_Click(object sender, RoutedEventArgs e) {
			ButtonPress(new Position(4, 3));
		}
		private void Btn_D4_Click(object sender, RoutedEventArgs e) {
			ButtonPress(new Position(4, 4));
		}
		private void Btn_D5_Click(object sender, RoutedEventArgs e) {
			ButtonPress(new Position(4, 5));
		}
		private void Btn_D6_Click(object sender, RoutedEventArgs e) {
			ButtonPress(new Position(4, 6));
		}
		private void Btn_D7_Click(object sender, RoutedEventArgs e) {
			ButtonPress(new Position(4, 7));
		}
		private void Btn_D8_Click(object sender, RoutedEventArgs e) {
			ButtonPress(new Position(4, 8));
		}
		private void Btn_E1_Click(object sender, RoutedEventArgs e) {
			ButtonPress(new Position(5, 1));
		}
		private void Btn_E2_Click(object sender, RoutedEventArgs e) {
			ButtonPress(new Position(5, 2));
		}
		private void Btn_E3_Click(object sender, RoutedEventArgs e) {
			ButtonPress(new Position(5, 3));
		}
		private void Btn_E4_Click(object sender, RoutedEventArgs e) {
			ButtonPress(new Position(5, 4));
		}
		private void Btn_E5_Click(object sender, RoutedEventArgs e) {
			ButtonPress(new Position(5, 5));
		}
		private void Btn_E6_Click(object sender, RoutedEventArgs e) {
			ButtonPress(new Position(5, 6));
		}
		private void Btn_E7_Click(object sender, RoutedEventArgs e) {
			ButtonPress(new Position(5, 7));
		}
		private void Btn_E8_Click(object sender, RoutedEventArgs e) {
			ButtonPress(new Position(5, 8));
		}
		private void Btn_F1_Click(object sender, RoutedEventArgs e) {
			ButtonPress(new Position(6, 1));
		}
		private void Btn_F2_Click(object sender, RoutedEventArgs e) {
			ButtonPress(new Position(6, 2));
		}
		private void Btn_F3_Click(object sender, RoutedEventArgs e) {
			ButtonPress(new Position(6, 3));
		}
		private void Btn_F4_Click(object sender, RoutedEventArgs e) {
			ButtonPress(new Position(6, 4));
		}
		private void Btn_F5_Click(object sender, RoutedEventArgs e) {
			ButtonPress(new Position(6, 5));
		}
		private void Btn_F6_Click(object sender, RoutedEventArgs e) {
			ButtonPress(new Position(6, 6));
		}
		private void Btn_F7_Click(object sender, RoutedEventArgs e) {
			ButtonPress(new Position(6, 7));
		}
		private void Btn_F8_Click(object sender, RoutedEventArgs e) {
			ButtonPress(new Position(6, 8));
		}
		private void Btn_G1_Click(object sender, RoutedEventArgs e) {
			ButtonPress(new Position(7, 1));
		}
		private void Btn_G2_Click(object sender, RoutedEventArgs e) {
			ButtonPress(new Position(7, 2));
		}
		private void Btn_G3_Click(object sender, RoutedEventArgs e) {
			ButtonPress(new Position(7, 3));
		}
		private void Btn_G4_Click(object sender, RoutedEventArgs e) {
			ButtonPress(new Position(7, 4));
		}
		private void Btn_G5_Click(object sender, RoutedEventArgs e) {
			ButtonPress(new Position(7, 5));
		}
		private void Btn_G6_Click(object sender, RoutedEventArgs e) {
			ButtonPress(new Position(7, 6));
		}
		private void Btn_G7_Click(object sender, RoutedEventArgs e) {
			ButtonPress(new Position(7, 7));
		}
		private void Btn_G8_Click(object sender, RoutedEventArgs e) {
			ButtonPress(new Position(7, 8));
		}
		private void Btn_H1_Click(object sender, RoutedEventArgs e) {
			ButtonPress(new Position(8, 1));
		}
		private void Btn_H2_Click(object sender, RoutedEventArgs e) {
			ButtonPress(new Position(8, 2));
		}
		private void Btn_H3_Click(object sender, RoutedEventArgs e) {
			ButtonPress(new Position(8, 3));
		}
		private void Btn_H4_Click(object sender, RoutedEventArgs e) {
			ButtonPress(new Position(8, 4));
		}
		private void Btn_H5_Click(object sender, RoutedEventArgs e) {
			ButtonPress(new Position(8, 5));
		}
		private void Btn_H6_Click(object sender, RoutedEventArgs e) {
			ButtonPress(new Position(8, 6));
		}
		private void Btn_H7_Click(object sender, RoutedEventArgs e) {
			ButtonPress(new Position(8, 7));
		}
		private void Btn_H8_Click(object sender, RoutedEventArgs e) {
			ButtonPress(new Position(8, 8));
		}
	}
}
