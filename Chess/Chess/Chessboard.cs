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

		//public Button[,] buttons;
		public Dictionary<string, Button> buttons;
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
			buttons = new Dictionary<string, Button>();
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
					buttons.Add(pos.Name, btn);
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
			blueButtons.Clear();
			
			foreach (KeyValuePair<string, Button> entry in buttons) {
				Button b = entry.Value;

				b.BorderBrush = blackBrush;

				foreach(Chesspiece p in pieces) {
					if (p.Pos.BtnName == b.Name)
						b.Content = p.Icon;
					if (selectedButton != null && p.Pos.BtnName == selectedButton.Name) {
						if (state == State.White)
							blueButtons = p.GetMoves(whitePlayer.pieces);
						else if (state == State.Black)
							blueButtons = p.GetMoves(blackPlayer.pieces);
					}
				}

				foreach (Position pos in blueButtons) {
					if (b.Name == pos.BtnName)
						b.BorderBrush = blueBrush;
				}

			}

			if (selectedButton != null)
				selectedButton.BorderBrush = greenBrush;

		}

	}
}
