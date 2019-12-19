using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess {
	class Queen : Chesspiece {

		public Queen(Position pos, bool isWhite) : base(isWhite ? "♕":"♛", pos, isWhite, 9) {

		}

		public override List<Position> GetMoves(List<Chesspiece> pieces) {
			Bishop tempBishop = new Bishop(Pos, IsWhite);
			Rook tempRook = new Rook(Pos, IsWhite);

			List<Position> moves = tempBishop.GetMoves(pieces).ToList();
			moves.AddRange(tempRook.GetMoves(pieces));

			return moves;
		}

	}
}
