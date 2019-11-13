using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Chess {
	class Chessboard {

		public Button[,] buttons;
		public Player whitePlayer;
		public Player blackPlayer;
		public Button selectedButton;
		public List<Position> blueButtons;
		public State state;

		public Chessboard() {
			buttons = new Button[8, 8];
			whitePlayer = new Player(true);
			blackPlayer = new Player(false);
			blueButtons = new List<Position>();
			state = State.White;
			selectedButton = null;

			bool white = true;
			for(int i = 0; i < 8; i++) {
				for(int j = 0; j < 8; j++) {
					Position pos = new Position(j + 1, 8 - i);
					Button btn = new Button();
					btn.Name = $"Btn_{pos.Column}{pos.Row}";
					Grid.SetColumn(btn, j + 1);
					Grid.SetRow(btn, i + 2);
					btn.FontSize = 50;
					if (white) {
						btn.Background = new SolidColorBrush(Colors.White);
						white = false;
					} else {
						btn.Background = new SolidColorBrush(Colors.Gray);
						white = true;
					}
					btn.BorderBrush = new SolidColorBrush(Colors.Black);
					btn.BorderThickness = new Thickness(5);
					btn.Padding = new Thickness(0, -5, 0, 0);
					btn.Margin = new Thickness(5);
					buttons[i, j] = btn;
				}
				white = white ? false : true;
			}
		}

		public void Update() {

			
			foreach (Button b in buttons) {
				b.Content = "";
				foreach (Chesspiece p in whitePlayer.pieces) {
					if (b.Name == $"Btn_{p.position.Name}")
						b.Content = p.piece;
				}
				b.BorderBrush = new SolidColorBrush(Colors.Black);
				foreach(Position pos in blueButtons) {
					if (b.Name == $"Btn_{pos.Name}")
						b.BorderBrush = new SolidColorBrush(Colors.LightBlue);
				}
			}


			if (selectedButton != null)
				selectedButton.BorderBrush = new SolidColorBrush(Colors.LightGreen);
		}

		public void MoveTo(Position position) {
			if (state == State.White) {
				foreach(Chesspiece p in whitePlayer.pieces) {
					if (selectedButton.Name == $"Btn_{p.position.Name}") {
						foreach(Position pos in blueButtons) {
							if (pos == position) {
								p.MovePiece(position);
								state = State.Black;
							}
						}
					}
				}
			} else if (state == State.Black) {
				foreach (Chesspiece p in blackPlayer.pieces) {
					if (selectedButton.Name == $"Btn_{p.position.Name}") {
						foreach (Position pos in blueButtons) {
							if (pos == position) {
								p.MovePiece(position);
								state = State.White;
							}
						}
					}
				}
			}
			Unselect();
			blueButtons.Clear();
		}

		public bool Occupation(Position position, bool isWhite) {

			foreach (Button b in buttons) {
				if (isWhite) {
					foreach (Chesspiece p in whitePlayer.pieces) {
						if (b.Name == $"Btn_{p.position.Name}")
							return true;
					}
				} else {
					foreach (Chesspiece p in blackPlayer.pieces) {
						if (b.Name == $"Btn_{p.position.Name}")
							return true;
					}
				}
			}
			return false;
		}

		public void Select(Position position) {
			foreach(Button b in buttons) {
				if (b.Name == $"Btn_{position.Name}")
					selectedButton = b;
			}
			if (state == State.White) {
				foreach(Chesspiece p in whitePlayer.pieces) {
					if (p.position == position)
						blueButtons = p.GetMoves(whitePlayer.pieces);
				}
			} else if (state == State.Black) {
				foreach(Chesspiece p in blackPlayer.pieces) {
					if (p.position == position)
						blueButtons = p.GetMoves(blackPlayer.pieces);
				}
			}
		}

		public void Unselect() {
			selectedButton = null;
			blueButtons.Clear();
		}

	}
}
