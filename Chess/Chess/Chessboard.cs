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
		List<Chesspiece> pieces;
		public Player whitePlayer;
		public Player blackPlayer;
		public Button selectedButton;
		List<Position> blueButtons;
		public State state;

		Brush blackBrush;
		Brush blueBrush;
		Brush greenBrush;

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
					btn.Name = pos.BtnName;
					Grid.SetColumn(btn, j + 1);
					Grid.SetRow(btn, i + 2);
					btn.FontSize = 10;
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
					buttons[i, j] = btn;
				}
				white = white ? false : true;
			}

			blackBrush = new SolidColorBrush(Colors.Black);
			blueBrush = new SolidColorBrush(Colors.LightBlue);
			greenBrush = new SolidColorBrush(Colors.LightGreen);
		}

		public void Update() {

			pieces = whitePlayer.pieces;
			pieces.AddRange(blackPlayer.pieces);
			
			foreach (Button b in buttons) {
				b.BorderBrush = blackBrush;

				foreach (Position p in blueButtons) {
					if (b.Name == p.BtnName)
						b.BorderBrush = blueBrush;
				}

				foreach (Chesspiece p in pieces) {
					if (b.Name == p.Pos.BtnName)
						b.Content = p.Icon;
				}
				// Test
				b.Content = b.Name;
			}
			
			if (selectedButton != null)
				selectedButton.BorderBrush = greenBrush;

		}

	}
}
