using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess {
	class Rook : Chesspiece {

		public Rook(Position position, bool isWhite) : base(isWhite ? "♖" : "♜", position, isWhite, 5) {

		}

		
		public override List<Position> GetMoves(List<Chesspiece> pieces) {
			List<Position> moves = new List<Position>();

			bool isBlocked = false;
			// Right moves
			for(int i = Pos.ColumnInt + 1; i <= 8; i++) {
				if (!isBlocked) {
					foreach (Chesspiece p in pieces) {
						if (i == p.Pos.ColumnInt && Pos.Row == p.Pos.Row) {
							isBlocked = true;
							if (p.IsWhite != IsWhite)
								moves.Add(new Position(i, Pos.Row));
						}
					}
					if (!isBlocked)
						moves.Add(new Position(i, Pos.Row));
				}
			}

			isBlocked = false;
			// Down moves
			for(int i = Pos.Row - 1; i > 0; i--) {
				if (!isBlocked) {
					foreach (Chesspiece p in pieces) {
						if (i == p.Pos.Row && Pos.ColumnInt == p.Pos.ColumnInt) {
							isBlocked = true;
							if (p.IsWhite != IsWhite)
								moves.Add(new Position(Pos.ColumnInt, i));
						}
					}
					if (!isBlocked)
						moves.Add(new Position(Pos.ColumnInt, i));
				}
			}

			isBlocked = false;
			// Left moves
			for(int i = Pos.ColumnInt - 1; i > 0; i--) {
				if (!isBlocked) {
					foreach (Chesspiece p in pieces) {
						if (i == p.Pos.ColumnInt && Pos.Row == p.Pos.Row) {
							isBlocked = true;
							if (p.IsWhite != IsWhite)
								moves.Add(new Position(i, Pos.Row));
						}
					}
					if (!isBlocked)
						moves.Add(new Position(i, Pos.Row));
				}
			}

			isBlocked = false;
			// Up moves
			for(int i = Pos.Row + 1; i <= 8; i++) {
				if (!isBlocked) {
					foreach (Chesspiece p in pieces) {
						if (i == p.Pos.Row && Pos.ColumnInt == p.Pos.ColumnInt) {
							isBlocked = true;
							if (p.IsWhite != IsWhite)
								moves.Add(new Position(Pos.ColumnInt, i));
						}
					}
					if (!isBlocked)
						moves.Add(new Position(Pos.ColumnInt, i));
				}
			}

			return moves;
		}

	}
}
