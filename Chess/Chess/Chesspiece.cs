using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Threading.Tasks;

namespace Chess {
	abstract class Chesspiece {

		public string piece;
		public Position position;
		public bool isWhite;
		public int value;

		public Chesspiece(string piece, Position position, bool isWhite, int value) {
			this.piece = piece;
			this.position = position;
			this.isWhite = isWhite;
			this.value = value;
		}
		public abstract List<Position> GetMoves(List<Chesspiece> teamPieces);

		public virtual void MovePiece(Position position) {
			this.position = position;
		}

	}
}
