using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess {
	/// <summary>
	/// Rook class, child of the chesspiece class
	/// Used for the rook chesspiece
	/// </summary>
	class Rook : Chesspiece {

		/// <summary>
		/// Constructor that creates a rook object
		/// </summary>
		/// <param name="pos">Where to place the piece</param>
		/// <param name="isWhite">What colour is the piece</param>
		public Rook(Position position, bool isWhite) : base(isWhite ? "♖" : "♜", position, isWhite, 5) {
		}


		/// <summary>
		/// Override method that returns a list of positions that the rook can make
		/// </summary>
		/// <param name="pieces">All pieces, white and black, to see if moves are obstructed</param>
		/// <returns>list of positions that the rook can make</returns>
		public override List<Position> GetMoves(List<Chesspiece> pieces) {
			List<Position> moves = new List<Position>(); // Create a list of positions to later return

			bool isBlocked = false; // Bool to check if position is blocked
			// Moves to the right
			// Loop through every move to the right
			for(int i = Pos.columnInt + 1; i <= 8; i++) {
				if (!isBlocked) { // if nothing has blocked it yet
					foreach (Chesspiece p in pieces) { // Go through every piece
						if (i == p.Pos.columnInt && Pos.row == p.Pos.row) { // Is there a chesspiece in the way
							isBlocked = true; // Set blocked to true (you cant move past something)
							if (p.IsWhite != IsWhite) // Is the chesspiece in the way the other colour?
								moves.Add(new Position(i, Pos.row)); // If so, add it to the move list (attackable)
						}
					}
					// Was there any chesspiece in the way? if not...
					if (!isBlocked)
						moves.Add(new Position(i, Pos.row)); // Then add the move to the move list
				}
			}

			isBlocked = false; // reset the blocked bool
			// Moves downwards
			for(int i = Pos.row - 1; i > 0; i--) {
				if (!isBlocked) { // if nothing has blocked it yet
					foreach (Chesspiece p in pieces) { // Go through every piece
						if (i == p.Pos.row && Pos.columnInt == p.Pos.columnInt) { // Is there a chesspiece in the way
							isBlocked = true; // Set blocked to true (you cant move past something)
							if (p.IsWhite != IsWhite) // Is the chesspiece in the way the other colour?
								moves.Add(new Position(Pos.columnInt, i)); // If so, add it to the move list (attackable)
						}
					}
					// Was there any chesspiece in the way? if not...
					if (!isBlocked)
						moves.Add(new Position(Pos.columnInt, i)); // Then add the move to the move list
				}
			}

			isBlocked = false; // reset the blocked bool
			// Moves to the left
			for(int i = Pos.columnInt - 1; i > 0; i--) {
				if (!isBlocked) { // if nothing has blocked it yet
					foreach (Chesspiece p in pieces) { // Go through every piece
						if (i == p.Pos.columnInt && Pos.row == p.Pos.row) { // Is there a chesspiece in the way
							isBlocked = true; // Set blocked to true (you cant move past something)
							if (p.IsWhite != IsWhite) // Is the chesspiece in the way the other colour?
								moves.Add(new Position(i, Pos.row)); // If so, add it to the move list (attackable)
						}
					}
					// Was there any chesspiece in the way? if not...
					if (!isBlocked)
						moves.Add(new Position(i, Pos.row)); // Then add the move to the move list
				}
			}

			isBlocked = false; // reset the blocked bool
			// Moves upwards
			for(int i = Pos.row + 1; i <= 8; i++) {
				if (!isBlocked) { // if nothing has blocked it yet
					foreach (Chesspiece p in pieces) { // Go through every piece
						if (i == p.Pos.row && Pos.columnInt == p.Pos.columnInt) { // Is there a chesspiece in the way
							isBlocked = true; // Set blocked to true (you cant move past something)
							if (p.IsWhite != IsWhite) // Is the chesspiece in the way the other colour?
								moves.Add(new Position(Pos.columnInt, i)); // If so, add it to the move list (attackable)
						}
					}
					// Was there any chesspiece in the way? if not...
					if (!isBlocked)
						moves.Add(new Position(Pos.columnInt, i)); // Then add the move to the move list
				}
			}

			return moves; // return the list of moves
		}

	}
}
