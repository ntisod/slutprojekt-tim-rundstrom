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
		Button selectedButton;
		Button opponentSelecedButton;
		List<Position> blueButtons;
		List<Chesspiece> allPieces;

		Player whitePlayer;
		Player blackPlayer;

		bool whitesTurn;

		bool playOnline;
		bool isLocal;
		bool localWhite;

		public bool LocalWhite { get => localWhite; }

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

			if (playOnline && isLocal)
				localWhite = true;
			else if (playOnline && !isLocal)
				localWhite = false;
			
			SetPieces();
			UpdateBoard();
		}
		void SetTextBlocks() {
			foreach (TextBlock tb in MainWindow.gridManager.FindVisualChildren<TextBlock>(MainWindow.gridManager.gridObj)) {
				if (tb.Name == "whitePointsTb")
					tb.Text = $"White Points: {whitePlayer.points}";
				if (tb.Name == "blackPointsTb")
					tb.Text = $"Black Points: {blackPlayer.points}";
				if (tb.Name == "turnTb") {
					if (whitesTurn)
						tb.Text = "Whites turn";
					else
						tb.Text = "Blacks turn";

				}
				if (tb.Name == "colorTb" && playOnline) {

					if (localWhite)
						tb.Text = "White";
					else
						tb.Text = "Black";

				}
			}
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

		public string GetVictory() {
			if (whitePlayer.hasLost || blackPlayer.points > whitePlayer.points)
				return "Blacks Win!";
			else if (blackPlayer.hasLost || whitePlayer.points > blackPlayer.points)
				return "Whites Win!";
			else
				return "It's a tie!";
		}

		public void ButtonPress(Position position) {

			// GET ACTION
			string actionMessage = GetAction(position);
			MessageBox.Show(actionMessage);
			if (playOnline) {
				if (whitesTurn == localWhite) {
					if (isLocal)
						MainWindow.server.Send(actionMessage);
					else
						MainWindow.client.Send(actionMessage);
					UpdateOnline(actionMessage);
				}
			} else 
				UpdateOffline(actionMessage);
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
				if (selectedButton.Name == position.btnName)
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
						actionMessage += "E-";
				}
			}
			actionMessage += position.name;
			return actionMessage;
		}

		public void UpdateOffline(string message) {

			// Update according to message
			string turn = message[0].ToString();
			string action = message[2].ToString();

			int columnInt = Convert.ToChar(message[4]) - 64;
			int row = Convert.ToInt32(message[5].ToString());
			Position position = new Position(columnInt, row);


			// Update list of all pieces
			allPieces = whitePlayer.pieces.ToList();
			allPieces.AddRange(blackPlayer.pieces);

			if (turn == "W" && whitesTurn || turn == "B" && !whitesTurn) {

				if (action == "S")
					Select(position);
				else if (action == "S")
					opponentSelecedButton = buttons[position.name];
				else if (action == "D") {
					selectedButton = null;
					opponentSelecedButton = null;
				} else if (action == "M") {
					MoveTo(selectedButton, position);
					whitesTurn = whitesTurn ? false : true;
				} else if (action == "M") {
					MoveTo(opponentSelecedButton, position);
					whitesTurn = whitesTurn ? false : true;
				}
			}
			UpdateBoard();


		}

		public void UpdateOnline(string message) {

			// Update according to message
			string turn = message[0].ToString();
			string action = message[2].ToString();
			
			int columnInt = Convert.ToChar(message[4]) - 64;
			int row = Convert.ToInt32(message[5].ToString());
			Position position = new Position(columnInt, row);


			// Update list of all pieces
			allPieces = whitePlayer.pieces.ToList();
			allPieces.AddRange(blackPlayer.pieces);
			
			if (turn == "W" && whitesTurn || turn == "B" && !whitesTurn) {

				if (action == "S" && whitesTurn == localWhite)
					Select(position);
				else if (action == "S" && whitesTurn != localWhite)
					opponentSelecedButton = buttons[position.name];
				else if (action == "D") {
					selectedButton = null;
					opponentSelecedButton = null;
				} else if (action == "M" && whitesTurn == localWhite) {
					MoveTo(selectedButton, position);
					whitesTurn = whitesTurn ? false : true;
				} else if (action == "M" && whitesTurn != localWhite) {
					MoveTo(opponentSelecedButton, position);
					whitesTurn = whitesTurn ? false : true;
				}
			}
			UpdateBoard();

		}

		void UpdateBoard() {
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
				buttons[p.Pos.name].Content = p.Icon; // Update each piece icon	
			}

			// Get the bluebuttons if a button is selected
			SetBlueButtons(selectedButton);
			SetBlueButtons(opponentSelecedButton);

			// Go through every bluebutton and set the stroke
			if (selectedButton != null) {
				foreach (Position pos in blueButtons) {
					try {
						buttons[pos.name].BorderBrush = blueBrush;
					} catch (KeyNotFoundException) {
						// Just ignore error, button is outside the chessboards boarders
					}
				}
			}

			// color the selected button
			if (selectedButton != null)
				selectedButton.BorderBrush = greenBrush;

			// Update players
			whitePlayer.Update();
			blackPlayer.Update();

			SetTextBlocks();

			if (whitePlayer.hasLost || blackPlayer.hasLost) {
				MainWindow.gridManager.SetGrid(GridType.GameOver);
			}
		}

		void SetBlueButtons(Button btn) {
			foreach (Chesspiece p in allPieces) {
				if (btn != null && p.Pos.btnName == btn.Name)
					blueButtons = p.GetMoves(allPieces);
			}
		}

		void Select(Position position) {
			foreach (Chesspiece piece in allPieces) {
				if (piece.Pos == position) {
					if (piece.IsWhite == localWhite) {
						selectedButton = buttons[position.name];
					}
				}
			}
		}

		void MoveTo(Button btn, Position position) {
			SetBlueButtons(btn);
			foreach (Position pos in blueButtons) {
				if (position == pos) {
					Attack(position);
					foreach (Chesspiece p in allPieces) {
						if (btn.Name == p.Pos.btnName)
							p.MovePiece(position);
					}
					selectedButton = null;
				}
			}
		}
		void Attack(Position position) {

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
