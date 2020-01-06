using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess {
	/// <summary>
	/// Knight class, child of the chesspiece class
	/// Used for the knight chesspiece
	/// </summary>
	class Knight : Chesspiece{

		/// <summary>
		/// Constructor that creates a knight object
		/// </summary>
		/// <param name="pos">Where to place the piece</param>
		/// <param name="isWhite">What colour is the piece</param>
		public Knight(Position pos, bool isWhite) : base(isWhite ? "♘":"♞", pos, isWhite, 3) {
		}


		/// <summary>
		/// Override method that returns a list of positions that the knight can make
		/// </summary>
		/// <param name="pieces">All pieces, white and black, to see if moves are obstructed</param>
		/// <returns>list of positions that the knight can make</returns>
		public override List<Position> GetMoves(List<Chesspiece> pieces) {
			List<Position> moves = new List<Position>(); // Declare list of moves to later return

			List<Position> potentialMoves = new List<Position>() { // Create a new list of all possible moves a knight can make
				new Position(Pos.columnInt + 2, Pos.row + 1),
				new Position(Pos.columnInt - 2, Pos.row + 1),
				new Position(Pos.columnInt + 2, Pos.row - 1),
				new Position(Pos.columnInt - 2, Pos.row - 1),
				new Position(Pos.columnInt + 1, Pos.row + 2), 
				new Position(Pos.columnInt - 1, Pos.row + 2),
				new Position(Pos.columnInt + 1, Pos.row - 2),
				new Position(Pos.columnInt - 1, Pos.row - 2),
			};

			// See if any of those positions are blocked by another piece
			foreach (Position pos in potentialMoves) { // Go through the potential moves
				bool isBlocked = false; // Bool to check if position is blocked

				foreach (Chesspiece p in pieces) { // Go through all the pieces

					if (p.Pos == pos) { // If a piece shares the position as one of the potential moves
						isBlocked = true; // Position is blocked
						if (p.IsWhite != IsWhite) // Unless its another colour, than it's killable
							moves.Add(pos); // Then add the position to moves
					}
				}

				if (!isBlocked) // If a position isn't blocked
					moves.Add(pos); // Then add the move to the list

			}

			return moves; // Return the list of all available moves
		}

	}
}
