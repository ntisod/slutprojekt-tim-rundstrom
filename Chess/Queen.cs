using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess {
	/// <summary>
	/// Queen class, child of the chesspiece class
	/// Used for the queen chesspiece
	/// </summary>
	class Queen : Chesspiece {

		/// <summary>
		/// Constructor that creates a queen object
		/// </summary>
		/// <param name="pos">Where to place the piece</param>
		/// <param name="isWhite">What colour is the piece</param>
		public Queen(Position pos, bool isWhite) : base(isWhite ? "♕":"♛", pos, isWhite, 9) {
		}

		/// <summary>
		/// Override method that returns a list of positions that the queen can make
		/// </summary>
		/// <param name="pieces">All pieces, white and black, to see if moves are obstructed</param>
		/// <returns>list of positions that the queen can make</returns>
		public override List<Position> GetMoves(List<Chesspiece> pieces) {
			// The queen uses the same moves as a bishop AND a rook, so you can simply use their moves
			Bishop tempBishop = new Bishop(Pos, IsWhite); // Create a temporary bishop on the same position
			Rook tempRook = new Rook(Pos, IsWhite); // Create a temporary rook on the same position

			// Create the moves list to later return filled with moves
			List<Position> moves = tempBishop.GetMoves(pieces).ToList(); // Give it the bishops moves
			moves.AddRange(tempRook.GetMoves(pieces)); // Add the rooks moves to the list of moves

			return moves; // Return the list of the queens moves (bishop and rooks moves)
		}

	}
}
