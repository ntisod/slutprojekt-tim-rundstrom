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

		public Dictionary<string, Button> buttons;
		public Button selectedButton;
		List<Position> blueButtons;

		List<Chesspiece> allPieces;

		public Player whitePlayer;
		public Player blackPlayer;

		public State state;

		Brush blackBrush;
		Brush blueBrush;
		Brush greenBrush;

		public List<Position> BlueButtons { get => blueButtons; }

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

		public void SetPieces() {
			//
			// Whites
			//

			// Pawns
			for (int i = 1; i <= 8; i++) {
				whitePlayer.pieces.Add(new Pawn(new Position(i, 2), true));
			}
			// Bishops
			whitePlayer.pieces.Add(new Bishop(new Position(3, 1), true));
			whitePlayer.pieces.Add(new Bishop(new Position(6, 1), true));
			// Knights
			whitePlayer.pieces.Add(new Knight(new Position(2, 1), true));
			whitePlayer.pieces.Add(new Knight(new Position(7, 1), true));
			// Rooks
			whitePlayer.pieces.Add(new Rook(new Position(1, 1), true));
			whitePlayer.pieces.Add(new Rook(new Position(8, 1), true));
			// Queen
			whitePlayer.pieces.Add(new Queen(new Position(4, 1), true));
			// King
			whitePlayer.pieces.Add(new King(new Position(5, 1), true));

			//
			// Blacks
			//

			//Pawns
			for (int i = 1; i <= 8; i++) {
				blackPlayer.pieces.Add(new Pawn(new Position(i, 7), false));
			}
			// Bishops
			blackPlayer.pieces.Add(new Bishop(new Position(3, 8), false));
			blackPlayer.pieces.Add(new Bishop(new Position(6, 8), false));
			// Knights
			blackPlayer.pieces.Add(new Knight(new Position(2, 8), false));
			blackPlayer.pieces.Add(new Knight(new Position(7, 8), false));
			// Rooks
			blackPlayer.pieces.Add(new Rook(new Position(1, 8), false));
			blackPlayer.pieces.Add(new Rook(new Position(8, 8), false));
			// Queen
			blackPlayer.pieces.Add(new Queen(new Position(4, 8), false));
			// King
			blackPlayer.pieces.Add(new King(new Position(5, 8), false));
		}

		public void Update() {

			// Update list of all pieces
			allPieces = whitePlayer.pieces.ToList();
			allPieces.AddRange(blackPlayer.pieces);

			// Reset bluebuttons
			blueButtons.Clear();

			// Go through and reset buttons
			foreach (KeyValuePair<string, Button> entry in buttons) {
				Button b = entry.Value;

				b.BorderBrush = blackBrush; // reset the stroke
				b.Content = ""; // reset the content

			}

			// Go through pieces
			foreach (Chesspiece p in allPieces) {
				buttons[p.Pos.Name].Content = p.Icon; // Update each piece icon

				// Get the bluebuttons if a button is selected
				if(selectedButton != null && p.Pos.BtnName == selectedButton.Name)
					blueButtons = p.GetMoves(allPieces);
			}

			// Go through every bluebutton and set the stroke
			foreach (Position pos in blueButtons) {
				try {
					buttons[pos.Name].BorderBrush = blueBrush;
				} catch (System.Collections.Generic.KeyNotFoundException) {
					// Just ignore error, button is outside the chessboards boarders
				}
			}

			// color the selected button
			if (selectedButton != null)
				selectedButton.BorderBrush = greenBrush;

			// Update players
			whitePlayer.Update();
			blackPlayer.Update();

		}

		public void MoveTo(Position position) {

			foreach (Position pos in blueButtons) {
				if (position == pos) {
					Attack(position);
					foreach(Chesspiece p in allPieces) {
						if (selectedButton.Name == p.Pos.BtnName)
							p.MovePiece(position);
					}
					selectedButton = null;
					state = state == State.White ? State.Black : State.White;
				}
			}

		}


		// Bruh
		public void Attack(Position position) {

			// Go through all pieces
			foreach (Chesspiece p in allPieces) {

				// If the piece is the one we're seeking
				if (p.Pos == position) {
					// then kill it and give the opposite player the corresponding points

					if (p.IsWhite) {
						whitePlayer.pieces.Remove(p);
						blackPlayer.points += p.Value;
					} else {
						blackPlayer.pieces.Remove(p);
						whitePlayer.points += p.Value;
					}
				}

			}

		}

	}
}
