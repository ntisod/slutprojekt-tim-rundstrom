using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Chess_online {
	public class Chessboard {

		public Dictionary<string, Button> buttons;
		public Button selectedButton;
		List<Position> blueButtons;
		List<Chesspiece> allPieces;

		Player whitePlayer;
		Player blackPlayer;

		bool whitesTurn;

		bool playOnline;
		bool isLocal;
		bool localWhite;

		public Chessboard() {
			buttons = new Dictionary<string, Button>();
			blueButtons = new List<Position>();
			allPieces = new List<Chesspiece>();
			whitePlayer = new Player(true);
			blackPlayer = new Player(false);
		}

		public void SetupGame(bool playOnline, bool isLocal) { 
			whitesTurn = true;
			selectedButton = null;
			this.playOnline = playOnline;
			this.isLocal = isLocal;

			if (playOnline) {
				if (isLocal)
					localWhite = true;
				else
					localWhite = false;
			}
			SetPieces();
			UpdateBoard(true);
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

		public void ButtonPress(Position position) {

			// GET ACTION
			string actionMessage = GetAction(position);
			if (playOnline) {
				if (whitesTurn == localWhite) {
					if (isLocal)
						MainWindow.server.Send(actionMessage);
					else
						MainWindow.client.Send(actionMessage);
					Update(actionMessage);
				}
			} else 
				Update(actionMessage);
		}
		
		string GetAction(Position position) {
			string actionMessage = "";

			if (whitesTurn)
				actionMessage += "W-";
			else
				actionMessage += "B-";
			if (selectedButton == null)
				actionMessage += "S-";
			else {
				if (selectedButton.Name == position.BtnName)
					actionMessage += "D-";
				else {
					bool move = false;
					foreach (Position pos in blueButtons) {
						if (pos == position)
							move = true;
					}
					if (move)
						actionMessage += "M-";
					else
						actionMessage = "";
				}
			}
			actionMessage += position.Name;
			return actionMessage;
		}

		public void Update(string message) {

			// Update according to message

			if (message.Length != 0) {

				Position position = new Position(message.Substring(4));

				char action = message[2];
				if (action == 'S') {
					


				} else if (action == 'D') {

					selectedButton = null;
					blueButtons.Clear();

				} else if (action == 'M') {



				}

			}
			bool showMoves;
			if (playOnline) {
				if (whitesTurn == localWhite)
					showMoves = true;
				else
					showMoves = false;
			} else
				showMoves = true;

			UpdateBoard(showMoves);

		}

		void UpdateBoard(bool showMoves) {
			// Set brush colours
			Brush blackBrush = new SolidColorBrush(Colors.Black);
			Brush blueBrush = new SolidColorBrush(Colors.LightBlue);
			Brush greenBrush = new SolidColorBrush(Colors.LightGreen);

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
				if (selectedButton != null && p.Pos.BtnName == selectedButton.Name)
					blueButtons = p.GetMoves(allPieces);
			}

			// Go through every bluebutton and set the stroke
			if (showMoves) {
				foreach (Position pos in blueButtons) {
					try {
						buttons[pos.Name].BorderBrush = blueBrush;
					} catch (System.Collections.Generic.KeyNotFoundException) {
						// Just ignore error, button is outside the chessboards boarders
					}
				}
			}

			// color the selected button
			if (selectedButton != null && showMoves)
				selectedButton.BorderBrush = greenBrush;

			// Update players
			whitePlayer.Update();
			blackPlayer.Update();
		}


	}
}
