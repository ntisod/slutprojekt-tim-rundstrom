using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Chess_online {
	/// <summary>
	/// The game board.
	/// 
	/// Controls and hold all objects associated with the game
	/// </summary>
	public class Chessboard {

		public Dictionary<string, Button> buttons; // Dictionary of all buttons, keyed to their names
		Button selectedButton; // The selected button, if there is one (green border)
		Button opponentSelecedButton; // The opponents selected button, if there is one and is played online
		List<Position> blueButtons; // List of all the available moves if a chesspiece is selected
		List<Chesspiece> allPieces; // Full list of all pieces, for easier access

		Player whitePlayer; // The white player (default serverside)
		Player blackPlayer; // The black player

		bool whitesTurn; // Bool to track whos turn it is, white or black

		bool playGameOnline; // Bool to check if the game is played online
		bool isServerLocal; // if it is online, is this the server or client?
		
		/// <summary>
		/// Constructor method for the class
		/// </summary>
		public Chessboard() {
			// Declare objects
			buttons = new Dictionary<string, Button>();
			blueButtons = new List<Position>();
			allPieces = new List<Chesspiece>();
			whitePlayer = new Player(true);
			blackPlayer = new Player(false);
		}
		
		/// <summary>
		/// Run before starting a new game, resets all scores, chesspieces and turns.
		/// </summary>
		/// <param name="playOnline"></param>
		/// <param name="isLocal"></param>
		public void SetupGame(bool playGameOnline, bool isServerLocal) {
			// Reset scores
			whitePlayer.points = 0;
			blackPlayer.points = 0;

			whitesTurn = true; // Set turn to whites
			selectedButton = null; // Deselect the selected button, in case there are leftovers from last game

			// Set game settings (Is it online or offline, server or client)
			this.playGameOnline = playGameOnline;
			this.isServerLocal = isServerLocal;

			SetPieces(); // Fill the board with Chesspieces
			UpdateBoardVisually(); // Update board one time (necessary)
		}

		/// <summary>
		/// Updates all textblocks on the game menu
		/// Points, turns and player color
		/// </summary>
		void SetTextBlocks() {
			
			// Go through all textblocks, using the FindVisualChildren method in gridmanager
			foreach (TextBlock tb in MainWindow.gridManager.FindVisualChildren<TextBlock>(MainWindow.gridObject)) {
				// Points textblocks
				if (tb.Name == "whitePointsTb") // If it has the name whitePointsTb, it is the white player points textblock
					tb.Text = $"White Points: {whitePlayer.points}"; // Set the text with the appropriate points
				if (tb.Name == "blackPointsTb") // If it has the name blackPointsTb, it is the black player points textblock
					tb.Text = $"Black Points: {blackPlayer.points}"; // Set the text with the appropriate points

				// Turn textblock
				if (tb.Name == "turnTb") { // If the textblock is named turnTb
					if (whitesTurn) // Is it whites turn?
						tb.Text = "Whites turn"; // Then set text to whites turn
					else
						tb.Text = "Blacks turn"; // Otherwhise set the text to blacks turn

				}

				// Player color textblock
				if (tb.Name == "colorTb" && playGameOnline) { // If the textblock is named colorTb
															  
					// Is the game played locally (is this server side)
					if (isServerLocal) // Then set the text to whichever color you play as (server is white, client is black)
						tb.Text = "White";
					else
						tb.Text = "Black";

				}
			}
		}

		/// <summary>
		/// Creates and fills the chessboard with chesspieces, run at the start of the game
		/// </summary>
		void SetPieces() {
			// Clear any remaining chesspieces from previous games
			whitePlayer.pieces.Clear(); 
			blackPlayer.pieces.Clear();

			//
			// Create them by adding the piece directly in the player pieces list<Chesspiece>
			//

			// Pawns
			// Loop through their positions easily
			for (int i = 1; i <= 8; i++) {
				whitePlayer.pieces.Add(new Pawn(new Position(i, 2), true));
				blackPlayer.pieces.Add(new Pawn(new Position(i, 7), false));
			}
			// Bishops
			whitePlayer.pieces.Add(new Bishop(new Position(3, 1), true));
			whitePlayer.pieces.Add(new Bishop(new Position(6, 1), true));
			blackPlayer.pieces.Add(new Bishop(new Position(3, 8), false));
			blackPlayer.pieces.Add(new Bishop(new Position(6, 8), false));
			// Knights
			whitePlayer.pieces.Add(new Knight(new Position(2, 1), true));
			whitePlayer.pieces.Add(new Knight(new Position(7, 1), true));
			blackPlayer.pieces.Add(new Knight(new Position(2, 8), false));
			blackPlayer.pieces.Add(new Knight(new Position(7, 8), false));
			// Rooks
			whitePlayer.pieces.Add(new Rook(new Position(1, 1), true));
			whitePlayer.pieces.Add(new Rook(new Position(8, 1), true));
			blackPlayer.pieces.Add(new Rook(new Position(1, 8), false));
			blackPlayer.pieces.Add(new Rook(new Position(8, 8), false));
			// Queens
			whitePlayer.pieces.Add(new Queen(new Position(4, 1), true));
			blackPlayer.pieces.Add(new Queen(new Position(4, 8), false));
			// Kings
			whitePlayer.pieces.Add(new King(new Position(5, 1), true));
			blackPlayer.pieces.Add(new King(new Position(5, 8), false));

		}

		/// <summary>
		/// Get method to see which player is the winner is the game was to end now
		/// Called when the grid is set to GameOver to display the message
		/// Winner is determined whether a king is dead or a player has higher score
		/// Tie happens if no king is dead and the score is equal to one another
		/// </summary>
		/// <returns>
		/// The victory message in string format (Whites win, Blacks win or Tie)
		/// </returns>
		public string GetVictory() {
			if (whitePlayer.hasLost || blackPlayer.points > whitePlayer.points) // Is the white king dead or does the black player have higher score?
				return "Blacks Win!"; // Then the blacks win
			else if (blackPlayer.hasLost || whitePlayer.points > blackPlayer.points) // Is the black king dead or does the white player have higher score?
				return "Whites Win!"; // Then the whites win
			else // If none of those are true then the score must be the same
				return "It's a tie!"; // Then it's a tie
			// No other outcome is possible
		}

		/// <summary>
		/// Called whenever a button on the game board is pressed (a chess square)
		/// e.g. A4 is pressed, then this method is called with A4 as argument
		/// </summary>
		/// <param name="position"></param>
		public void ButtonPress(Position position) {

			// GET ACTION
			string actionMessage = GetAction(position); // What should happen?
			//format: e.g. 'W-M-A4' = whites move to A4

			if (playGameOnline) { // Is the game played online or offline
				//If its online
				if (whitesTurn == isServerLocal) { // Is it your turn? If not, do nothing 
					if (isServerLocal) // Is this server side?
						MainWindow.server.Send(actionMessage); // Send action to client
					else // If not, then it's client side
						MainWindow.client.Send(actionMessage); // Send action to server
					UpdateOnline(actionMessage); // Update board according to the action
				}
			} else  // Game is played offline
				UpdateOffline(actionMessage); // Update board according to the action
		}
		
		/// <summary>
		/// Sets up an action in string format. 
		/// Who makes move? white or black
		/// What do they do? Select, deselect or move?
		/// If they move, where to they move? argument
		/// </summary>
		/// <param name="position"></param>
		/// <returns>Action in string format, e.g. W-M-A4 (white move to A4)</returns>
		string GetAction(Position position) {
			string actionMessage = ""; // Action string, to be filled

			if (whitesTurn) // Is it the whites turn?
				actionMessage += "W-"; // Then add white as the 'movemaker'
			else // Otherwise
				actionMessage += "B-"; // Add black

			if (selectedButton == null) // If no button is selected
				actionMessage += "S-"; // The the action is a selection
			else { // if there is a button selected

				if (selectedButton.Name == position.btnName) // If the selected button is the same as the one pressed
					actionMessage += "D-"; // Then the action should be deselect
				else { // If the selected button is not the same as the button pressed

					bool move = false; // declare move bool, to see if the selected chesspiece is able to move to the pressed button
					foreach (Position pos in blueButtons) {  // Loop through all the bluebuttons (moveable positions)
						if (pos == position) // if the pressed button is within the bluebuttons list
							move = true; // Set move bool to true, the move is acceptable
					}
					if (move) // If the move is acceptable
						actionMessage += "M-"; // add move to action
					else // Otherwise
						actionMessage += "E-"; // Add error to action, illegal move
				}
			}
			actionMessage += position.name; // Lastly add the pressed button to the action message
			return actionMessage; // Return the aciton in string format
		}

		/// <summary>
		/// The offline update method that handles the action
		/// e.g. selects, deselects or moves
		/// UpdateOnline is used when played online to easier handle the actions (other if statements)
		/// </summary>
		/// <param name="message"></param>
		public void UpdateOffline(string message) {

			// Decypher the action
			string turn = message[0].ToString(); // Get the turn (index at 0)
			string action = message[2].ToString(); // Get the action itself (index at 2)

			int columnInt = Convert.ToChar(message[4]) - 64; // Get the column (index at 4)
			int row = Convert.ToInt32(message[5].ToString()); // Get the row (index at 5)
			Position position = new Position(columnInt, row); // Convert into a position object

			// Update list of all pieces
			allPieces = whitePlayer.pieces.ToList(); // Add white pieces to the list
			allPieces.AddRange(blackPlayer.pieces); // Add the black pieces to the list

			// Update the board accordinly to the action
			// Is it the same turn as the one who pressed the button? e.g. is it white that pressed the button AND whites turn
			if (turn == "W" && whitesTurn || turn == "B" && !whitesTurn) { // If true

				if (action == "S") // Is the action select?
					Select(position); // Then select the position
				else if (action == "D") { // Is the action deselect?
					selectedButton = null; // Then deselect; set to null
				} else if (action == "M") { // Is the action move?
					MoveTo(selectedButton, position); // The the selected chesspiece to the desired position
					whitesTurn = !whitesTurn; // Switch turn 
				}
			}
			UpdateBoardVisually(); // Update the board visually
		}

		/// <summary>
		/// The online update method that handles the action
		/// e.g. selectsm deselects or moves
		/// UpdateOffline is used when played offline to easier handle the actions (other is statements)
		/// </summary>
		/// <param name="message"></param>
		public void UpdateOnline(string message) {

			// Decypher the action
			string turn = "";
			string action = "";
			Position position = new Position(0, 0);
			if (message.Length >= 6 && message != "GAME OVER") { // If the message is intact (not a faulty message) or 'GAME OVER'
				turn = message[0].ToString(); // Get turn (index at 0)
				action = message[2].ToString(); // Get action (index at 2)

				int columnInt = Convert.ToChar(message[4]) - 64; // Get position column (index at 4) and convert into columnInt
				int row = Convert.ToInt32(message[5].ToString()); // Get position row (index at 5)
				position = new Position(columnInt, row); // Set the position accordinly
			}

			// Update list of all pieces
			allPieces = whitePlayer.pieces.ToList(); // add white pieces
			allPieces.AddRange(blackPlayer.pieces); // add black pieces

			// Update the board accordinly to the action
			// Is it the same turn as the one who pressed the button? e.g. is it white that pressed the button AND whites turn
			if (turn == "W" && whitesTurn || turn == "B" && !whitesTurn) { // If true

				// Is the action select AND should it be visible to the player? e.g. select only visible to whoever selected
				if (action == "S" && whitesTurn == isServerLocal) 
					Select(position); // Then select the position
				else if (action == "S" && whitesTurn != isServerLocal) // The action is select however it shouldn't be visible to the player
					opponentSelecedButton = buttons[position.name]; // Set the opponentSelectedButton to the selected button
				else if (action == "D") { // Is the action deselect? Then deselect
					selectedButton = null; // Set selectedbutton to null
					opponentSelecedButton = null; // and the opponentselectedbutton
				} else if (action == "M") { // Is the action move?
					if (whitesTurn == isServerLocal) // Is it you that are moving?
						MoveTo(selectedButton, position); // Then move using the selected button
					else // It's the opponent that is moving
						MoveTo(opponentSelecedButton, position); // Move using the opponent selected button
					whitesTurn = !whitesTurn; // Switch turns
				}
			}
			UpdateBoardVisually(); // Update to board visually

		}

		/// <summary>
		/// Updates the board visually for the user (does not handle actions, only visuals)
		/// Sets borders, updates textblocks, updates scores, updates players etc.
		/// </summary>
		void UpdateBoardVisually() {
			// Declare the brushcolors for the borders
			Brush blackBrush = new SolidColorBrush(Colors.Black); // Black border
			Brush blueBrush = new SolidColorBrush(Colors.LightBlue); // Blue border
			Brush greenBrush = new SolidColorBrush(Colors.LightGreen); // Green border

			// Update list of all pieces
			allPieces = whitePlayer.pieces.ToList(); // Add white pieces to the list
			allPieces.AddRange(blackPlayer.pieces); // Add black pieces to the list

			// Reset bluebuttons
			blueButtons.Clear(); // Will be updated further down

			// Go through and reset buttons content and borders
			foreach (KeyValuePair<string, Button> entry in buttons) {
				Button b = entry.Value; // The button at hand (the value out of the keyvaluepair <string, button>)

				b.BorderBrush = blackBrush; // reset the stroke (border)
				b.Content = ""; // reset the content
			}

			// Go through all pieces and set their icons at the appropriate places
			foreach (Chesspiece p in allPieces) {
				// Set content of the chessbutton (chesssquare) that has the same position as the chesspiece
				buttons[p.Pos.name].Content = p.Icon;
			}

			// Get the bluebuttons out of the selected (or opponent selected) piece
			SetBlueButtons(selectedButton);
			SetBlueButtons(opponentSelecedButton);

			// Go through every bluebutton and set the stroke, only if its one of your pieces, opponent doesn't see your bluebuttons
			if (selectedButton != null) { // If the selected button isn't null (its your turn)
				foreach (Position pos in blueButtons) { // Loop through blue buttons
					try {
						buttons[pos.name].BorderBrush = blueBrush; // Try to set the stroke (border) to blue
					} catch (KeyNotFoundException) { // Error, blue button not in the list
						// Just ignore error, button is outside the chessboards boarders and therefor doesn't exist
					}
				}
			}

			// color the selected button
			if (selectedButton != null)
				selectedButton.BorderBrush = greenBrush;

			// Update players
			whitePlayer.Update();
			blackPlayer.Update();

			// Update all the textblocks (points, turn, player color)
			SetTextBlocks();

			// Check if game has been won
			if (whitePlayer.hasLost || blackPlayer.hasLost) { // If a king is dead 
				MainWindow.gridManager.SetGrid(GridType.GameOver); // Set the grid to game over
				// End server connection
				if (isServerLocal) // Are you the server?
					MainWindow.server.Stop(); // Stop the server
				else // No? you're the client
					MainWindow.client.Stop(); // Stop the client
			}
		}

		/// <summary>
		/// Gets and then sets the bluebuttons from the button in argument
		/// </summary>
		/// <param name="btn">Chesspiece to which bluebuttons to get</param>
		void SetBlueButtons(Button btn) {
			foreach (Chesspiece p in allPieces) { // Loop through all chesspieces
				if (btn != null && p.Pos.btnName == btn.Name) // If the button exists AND is the button in argument
					blueButtons = p.GetMoves(allPieces); // Set the bluebuttons to the piece's moves (GetMoves)
			}
		}

		/// <summary>
		/// Sets the selectedButton object to the button that shares the arguments position
		/// </summary>
		/// <param name="position">the buttons position</param>
		void Select(Position position) {
			// Loop through all the pieces on the board
			foreach (Chesspiece piece in allPieces) {
				if (piece.Pos == position) { // If the piece has the same position as the desired button to select
					if (playGameOnline) { // If the game is played online
						if (piece.IsWhite == isServerLocal) // If the piece shares the same colour as the local player
							selectedButton = buttons[position.name]; // Set the selected button
					} else { // The game is played offline
						if (piece.IsWhite == whitesTurn) // Is it the piece's colours turn?
							selectedButton = buttons[position.name]; // If so, then select the piece
					}
				}
			}
		}

		/// <summary>
		/// Moves a piece from one button to another button with a position as the second argument
		/// </summary>
		/// <param name="btn">Move from this position (selected button)</param>
		/// <param name="position">Move to this position</param>
		void MoveTo(Button btn, Position position) {
			SetBlueButtons(btn); // Get the blue buttons from the btn

			foreach (Position pos in blueButtons) { // Go through the blue buttons
				if (position == pos) { // Is the position you want to move to in the blue buttons list?
					Attack(position); // The try to 'attack' that position, see method for more information
					foreach (Chesspiece p in allPieces) { // Go through all pieces
						if (btn.Name == p.Pos.btnName) // Find the piece that you want to move
							p.MovePiece(position); // Move its position
					}
					selectedButton = null; // Deselect the selected button, it's not your turn anymore
				}
			}
		}
		
		/// <summary>
		/// Checks if a piece is occupied and if so, kills the piece in that spot and rewards players with points
		/// </summary>
		/// <param name="position">Position to attack</param>
		void Attack(Position position) {

			// Go through all pieces
			foreach (Chesspiece p in allPieces) {

				// If the piece is the one we're seeking
				if (p.Pos == position) {
					// then kill it and give the opposite player the corresponding points

					if (p.IsWhite) { // If the piece is white
						whitePlayer.pieces.Remove(p); // Then remove the piece from white players pieces list (kill the piece)
						blackPlayer.points += p.Value; // Reward blackplayer with points
					} else { // If the piece is black
						blackPlayer.pieces.Remove(p); // Then remove the piece from black players pieces list (kill the piece)
						whitePlayer.points += p.Value; // Reward whiteplayer with points
					}
				}

			}

		}

	}
}
