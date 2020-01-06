using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Chess_online {
	/// <summary>
	/// Pawn class, child of the chesspiece class
	/// Used for the pawn chesspiece
	/// </summary>
	class Pawn : Chesspiece {

		bool untouched; // Has the pawn been moved atleast once? (The pawn can move two squares only on its first turn)

		/// <summary>
		/// Constructor that creates a pawn object
		/// </summary>
		/// <param name="pos">Where to place the piece</param>
		/// <param name="isWhite">What colour is the piece</param>
		public Pawn(Position position, bool isWhite) : base(isWhite ? "♙" : "♟", position, isWhite, 1) {
			untouched = true; // Yes its untouched, its brand new
		}

		/// <summary>
		/// Override method that returns a list of positions that the pawn can make
		/// </summary>
		/// <param name="pieces">All pieces, white and black, to see if moves are obstructed</param>
		/// <returns>list of positions that the pawn can make</returns>
		public override List<Position> GetMoves(List<Chesspiece> pieces) {
			List<Position> moves = new List<Position>(); // Declare a list of moves to later fill and return

			int direction = IsWhite ? 1 : -1; // Get the direction (whites only move up, blacks only move down)
			List<Position> potentialMoves = new List<Position>() {
				new Position(Pos.columnInt, Pos.row + (1 * direction)),
				new Position(Pos.columnInt, Pos.row + (2 * direction)),
				new Position(Pos.columnInt + 1, Pos.row + (1 * direction)),
				new Position(Pos.columnInt - 1, Pos.row + (1 * direction))
			};

			bool firstBlocked = false, secondBlocked = false; // Bools to check if positions are blocked

			// See if any of those positions are blocked by another piece
			foreach (Position pos in potentialMoves) { // Go through potential moves

				foreach (Chesspiece p in pieces) { // Go through all pieces
					if (p.Pos == pos) { // If a piece shares the same position as a potential move
						if (p.IsWhite != IsWhite) { // Is the piece a different colour?
							if (p.Pos == potentialMoves[2] || p.Pos == potentialMoves[3]) // If so is it one of the attack positions?
								moves.Add(pos); // If so, then add that potential position to the moves list
						}
						if (p.Pos == potentialMoves[0]) // If the piece in the first move (right in front of it)
							firstBlocked = true; // If so, then the first is blocked
						if (p.Pos == potentialMoves[1]) // If the piece is in the second move (two squares in front)
							secondBlocked = true; // If so then the second is blocked
					}
				}

			}

			if (!firstBlocked) { // If the first position is free
				moves.Add(potentialMoves[0]); // Then add the move 
				if (!secondBlocked && untouched) // if the second position is also free, and the pawn is untouched
					moves.Add(potentialMoves[1]); // Then add the move
			}
			
			return moves; // return a list of all moves
		}

		/// <summary>
		/// Override method for moving the piece, to change the untouched variable
		/// </summary>
		/// <param name="position">Where to move</param>
		public override void MovePiece(Position position) {
			base.MovePiece(position); // Execute the base class's method
			untouched = false; // Set the untouched bool to false, the piece has been moved atleast once
		}

	}
}
