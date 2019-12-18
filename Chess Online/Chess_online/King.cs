using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_online {
	class King : Chesspiece{

		public King(Position pos, bool isWhite) : base(isWhite ? "♔" : "♚", pos, isWhite, 100) {

		}

		public override List<Position> GetMoves(List<Chesspiece> pieces) {
			List<Position> moves = new List<Position>();
			List<Position> potentialMoves = new List<Position>() {
				new Position(Pos.columnInt+1, Pos.row+1),
				new Position(Pos.columnInt+1, Pos.row),
				new Position(Pos.columnInt+1, Pos.row-1),
				new Position(Pos.columnInt, Pos.row+1),
				new Position(Pos.columnInt, Pos.row-1),
				new Position(Pos.columnInt-1, Pos.row+1),
				new Position(Pos.columnInt-1, Pos.row),
				new Position(Pos.columnInt-1, Pos.row-1),
			};

			foreach (Position pos in potentialMoves){

				bool isBlocked = false;
				foreach (Chesspiece p in pieces) {
					if (pos == p.Pos) {
						isBlocked = true;
						if (p.IsWhite != IsWhite)
							moves.Add(pos);
					}
				}
				if (!isBlocked)
					moves.Add(pos);
			}

			return moves;
		}

	}
}
