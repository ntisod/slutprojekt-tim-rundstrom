using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Chess {
	class Pawn : Chesspiece {

		bool untouched;

		public Pawn(Position position, bool isWhite) : base(isWhite ? "♙" : "♟", position, isWhite, 1) {
			untouched = true;
		}

		public override List<Position> GetMoves(List<Chesspiece> teamPieces) {
			List<Position> moves = new List<Position>();

			moves.Add(new Position(position.ColumnInt, position.Row + 1));
			if (untouched)
				moves.Add(new Position(position.ColumnInt, position.Row + 2));

			foreach (Chesspiece p in teamPieces) {
				if (untouched) {
					if (p.position == moves[1])
						moves.RemoveAt(1);
				}
				if (p.position == moves[0])
					moves.Clear();
			}

			return moves;
		}

		public override void MovePiece(Position position) {
			base.MovePiece(position);
			untouched = false;
		}

	}
}
