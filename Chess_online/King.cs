using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_online {
	/// <summary>
	/// King class, child of the chesspiece class
	/// Used for the king chesspiece
	/// </summary>
	class King : Chesspiece{

		/// <summary>
		/// Constructor that creates a king object
		/// </summary>
		/// <param name="pos">Where to place the piece</param>
		/// <param name="isWhite">What colour is the piece</param>
		public King(Position pos, bool isWhite) : base(isWhite ? "♔" : "♚", pos, isWhite, 100) {
		}

		/// <summary>
		/// Override method that returns a list of positions that the king can make
		/// </summary>
		/// <param name="pieces">All pieces, white and black, to see if moves are obstructed</param>
		/// <returns>list of positions that the king can make</returns>
		public override List<Position> GetMoves(List<Chesspiece> pieces) {
			List<Position> moves = new List<Position>(); // Declare list of moves to later return

			List<Position> potentialMoves = new List<Position>() { // Create a new list of all possible moves a king can make
				new Position(Pos.columnInt+1, Pos.row+1),
				new Position(Pos.columnInt+1, Pos.row),
				new Position(Pos.columnInt+1, Pos.row-1),
				new Position(Pos.columnInt, Pos.row+1),
				new Position(Pos.columnInt, Pos.row-1),
				new Position(Pos.columnInt-1, Pos.row+1),
				new Position(Pos.columnInt-1, Pos.row),
				new Position(Pos.columnInt-1, Pos.row-1),
			};

			// See if any of those positions are blocked by another piece
			foreach (Position pos in potentialMoves){ // Go through the potential moves
				bool isBlocked = false; // Bool to check if position is blocked

				foreach (Chesspiece p in pieces) { // Go through pieces
					if (pos == p.Pos) { // If a piece shares the position as one of the moves
						isBlocked = true; // Then it's blocked
						if (p.IsWhite != IsWhite) // Unless it's another colour (attackable)
							moves.Add(pos); // Add the move (if it's occupied by another colour)
					}
				}
				if (!isBlocked) // If the position is not blocked
					moves.Add(pos); // Add the move
			}

			return moves; // Return all the moves the king can make from its current position
		}

	}
}
