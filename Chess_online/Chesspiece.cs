using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_online {
	/// <summary>
	/// Abstract class for chesspieces, used for store pieces in list using polymorphism and basic attributes and methods all pieces have.
	/// </summary>
	abstract class Chesspiece {

		string icon; // Icon to display on the buttons (what the piece looks like e.g. ♙)
		Position pos; // What position is the piece on
		bool isWhite; // Is the piece white, or black
		int value; // What value does the piece have

		// Getters
		public string Icon { get => icon; }
		public Position Pos { get => pos; }
		public bool IsWhite { get => isWhite; }
		public int Value { get => value; }

		/// <summary>
		/// Contructor for the chesspiece object, used by class children
		/// </summary>
		/// <param name="icon">Chesspieces icon</param>
		/// <param name="pos">Chesspieces position</param>
		/// <param name="isWhite">Chesspieces colour</param>
		/// <param name="value">Chesspieces value</param>
		public Chesspiece(string icon, Position pos, bool isWhite, int value) {
			// Set values
			this.icon = icon;
			this.pos = pos;
			this.isWhite = isWhite;
			this.value = value;
		}

		/// <summary>
		/// Abstract method that returns a list of position that the piece can move to. Override in class children
		/// </summary>
		/// <param name="pieces">All pieces, white and black, to see if moves are obstructed</param>
		/// <returns>List of positions that the piece can move to</returns>
		public abstract List<Position> GetMoves(List<Chesspiece> pieces);

		/// <summary>
		/// Virtual method that changes the pieces position, overridden by the Pawn piece
		/// </summary>
		/// <param name="position">Position to move to</param>
		public virtual void MovePiece(Position position) {
			pos = position; // Update the position
		}

	}
}
