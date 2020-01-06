using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess{
	/// <summary>
	/// Bishop class, child of the chesspiece class
	/// Used for the bishop chesspiece
	/// </summary>
	class Bishop : Chesspiece {

		/// <summary>
		/// Constructor that creates a bishop object
		/// </summary>
		/// <param name="pos">Where to place the piece</param>
		/// <param name="isWhite">What colour is the piece</param>
		public Bishop(Position pos, bool isWhite) : base(isWhite ? "♗":"♝", pos, isWhite, 3) {
		}

		/// <summary>
		/// Override method that returns a list of positions that the bishop can make
		/// </summary>
		/// <param name="pieces">All pieces, white and black, to see if moves are obstructed</param>
		/// <returns>list of positions that the bishop can make</returns>
		public override List<Position> GetMoves(List<Chesspiece> pieces) {
			List<Position> moves = new List<Position>(); // Declare list of moves to later return

			//
			// Moves to the right and up
			//		
			bool isBlocked = false; // Bool to check if position is blocked
			int row = Pos.row; // int for the new row, the loop increases the columns, while this increases the row of each move
			for (int i = Pos.columnInt + 1; i <= 8; i++) {
				row++; // increment the row
				foreach(Chesspiece p in pieces) { // Loop through all the pieces
					if (i == p.Pos.columnInt && row == p.Pos.row) { // Is there a piece in the way
						isBlocked = true; // the path is blocked
						if (p.IsWhite != IsWhite) // Is the piece in the way the other colour?
							moves.Add(new Position(i, row)); // Then add the move to the move list (attackable)
					}
				}

				// If the path is not blocked
				if (!isBlocked)
					moves.Add(new Position(i, row)); // then add the move to the list
			}

			//
			// Moves to the left and up
			//
			isBlocked = false; // reset blocked bool
			row = Pos.row; // reset the variable
			for (int i = Pos.columnInt - 1; i > 0; i--) {
				row++; // increment the row
				foreach (Chesspiece p in pieces) { // Loop through all the pieces
					if (i == p.Pos.columnInt && row == p.Pos.row) { // Is there a piece in the way
						isBlocked = true; // the path is blocked
						if (p.IsWhite != IsWhite) // Is the piece in the way the other colour?
							moves.Add(new Position(i, row)); // Then add the move to the move list (attackable)
					}
				}

				// If the path is not blocked
				if (!isBlocked)
					moves.Add(new Position(i, row)); // then add the move to the list
			}

			//
			// Moves to the right and down
			//
			isBlocked = false; // reset blocked bool
			row = Pos.row; // reset the variable
			for (int i = Pos.columnInt + 1; i <= 8; i++) {
				row--; // decrement the row
				foreach (Chesspiece p in pieces) { // Loop through all the pieces
					if (i == p.Pos.columnInt && row == p.Pos.row) { // Is there a piece in the way
						isBlocked = true; // the path is blocked
						if (p.IsWhite != IsWhite) // Is the piece in the way the other colour?
							moves.Add(new Position(i, row)); // Then add the move to the move list (attackable)
					}
				}

				// If the path is not blocked
				if (!isBlocked)
					moves.Add(new Position(i, row)); // then add the move to the list
			}

			//
			// Moves to the left and down
			//
			isBlocked = false; // reset blocked bool
			row = Pos.row; // reset the variable
			for (int i = Pos.columnInt - 1; i > 0; i--) {
				row--; // decrement the row
				foreach (Chesspiece p in pieces) { // Loop through all the pieces
					if (i == p.Pos.columnInt && row == p.Pos.row) { // Is there a piece in the way
						isBlocked = true; // the path is blocked
						if (p.IsWhite != IsWhite) // Is the piece in the way the other colour?
							moves.Add(new Position(i, row)); // Then add the move to the move list (attackable)
					}
				}

				// If the path is not blocked
				if (!isBlocked)
					moves.Add(new Position(i, row)); // then add the move to the list
			}

			return moves; // return the list of moves the bishop can make
		}

	}
}
