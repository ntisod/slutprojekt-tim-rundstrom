using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_online {
	class Rook : Chesspiece {

		public Rook(Position position, bool isWhite) : base(isWhite ? "♖" : "♜", position, isWhite, 5) {

		}

		
		public override List<Position> GetMoves(List<Chesspiece> pieces) {
			List<Position> moves = new List<Position>();

			bool isBlocked = false;
			// Right moves
			for(int i = Pos.columnInt + 1; i <= 8; i++) {
				if (!isBlocked) {
					foreach (Chesspiece p in pieces) {
						if (i == p.Pos.columnInt && Pos.row == p.Pos.row) {
							isBlocked = true;
							if (p.IsWhite != IsWhite)
								moves.Add(new Position(i, Pos.row));
						}
					}
					if (!isBlocked)
						moves.Add(new Position(i, Pos.row));
				}
			}

			isBlocked = false;
			// Down moves
			for(int i = Pos.row - 1; i > 0; i--) {
				if (!isBlocked) {
					foreach (Chesspiece p in pieces) {
						if (i == p.Pos.row && Pos.columnInt == p.Pos.columnInt) {
							isBlocked = true;
							if (p.IsWhite != IsWhite)
								moves.Add(new Position(Pos.columnInt, i));
						}
					}
					if (!isBlocked)
						moves.Add(new Position(Pos.columnInt, i));
				}
			}

			isBlocked = false;
			// Left moves
			for(int i = Pos.columnInt - 1; i > 0; i--) {
				if (!isBlocked) {
					foreach (Chesspiece p in pieces) {
						if (i == p.Pos.columnInt && Pos.row == p.Pos.row) {
							isBlocked = true;
							if (p.IsWhite != IsWhite)
								moves.Add(new Position(i, Pos.row));
						}
					}
					if (!isBlocked)
						moves.Add(new Position(i, Pos.row));
				}
			}

			isBlocked = false;
			// Up moves
			for(int i = Pos.row + 1; i <= 8; i++) {
				if (!isBlocked) {
					foreach (Chesspiece p in pieces) {
						if (i == p.Pos.row && Pos.columnInt == p.Pos.columnInt) {
							isBlocked = true;
							if (p.IsWhite != IsWhite)
								moves.Add(new Position(Pos.columnInt, i));
						}
					}
					if (!isBlocked)
						moves.Add(new Position(Pos.columnInt, i));
				}
			}

			return moves;
		}

	}
}
