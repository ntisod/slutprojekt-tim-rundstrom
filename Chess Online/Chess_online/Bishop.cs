using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_online {
	class Bishop : Chesspiece {

		public Bishop(Position pos, bool isWhite) : base(isWhite ? "♗":"♝", pos, isWhite, 3) {

		}

		public override List<Position> GetMoves(List<Chesspiece> pieces) {
			List<Position> moves = new List<Position>();

			bool isBlocked = false;
			// Right up moves
			int row = Pos.Row;
			for (int i = Pos.ColumnInt + 1; i <= 8; i++) {
				row++;
				foreach(Chesspiece p in pieces) {
					if (i == p.Pos.ColumnInt && row == p.Pos.Row) {
						isBlocked = true;
						if (p.IsWhite != IsWhite)
							moves.Add(new Position(i, row));
					}
				}

				if (!isBlocked)
					moves.Add(new Position(i, row));
			}

			isBlocked = false;
			// Left up moves
			row = Pos.Row;
			for (int i = Pos.ColumnInt - 1; i > 0; i--) {
				row++;
				foreach(Chesspiece p in pieces) {
					if (i == p.Pos.ColumnInt && row == p.Pos.Row) {
						isBlocked = true;
						if (p.IsWhite != IsWhite)
							moves.Add(new Position(i, row));
					}
				}

				if (!isBlocked)
					moves.Add(new Position(i, row));
			}

			isBlocked = false;
			//Right down moves
			row = Pos.Row;
			for (int i = Pos.ColumnInt + 1; i <= 8; i++) {
				row--;
				foreach (Chesspiece p in pieces) {
					if (i == p.Pos.ColumnInt && row == p.Pos.Row) {
						isBlocked = true;
						if (p.IsWhite != IsWhite)
							moves.Add(new Position(i, row));
					}
				}

				if (!isBlocked)
					moves.Add(new Position(i, row));
			}

			isBlocked = false;
			// Left down moves
			row = Pos.Row;
			for (int i = Pos.ColumnInt - 1; i > 0; i--) {
				row--;
				foreach (Chesspiece p in pieces) {
					if (i == p.Pos.ColumnInt && row == p.Pos.Row) {
						isBlocked = true;
						if (p.IsWhite != IsWhite)
							moves.Add(new Position(i, row));
					}
				}

				if (!isBlocked)
					moves.Add(new Position(i, row));
			}

			return moves;
		}

	}
}
