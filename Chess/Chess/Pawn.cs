﻿using System;
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

			int c = IsWhite ? 1 : -1;
			moves.Add(new Position(Pos.ColumnInt, Pos.Row + 1 * c));
			if (untouched)
				moves.Add(new Position(Pos.ColumnInt, Pos.Row + 2 * c));

			foreach (Chesspiece p in teamPieces) {
				if (untouched) {
					if (p.Pos == moves[1])
						moves.RemoveAt(1);
				}
				if (p.Pos == moves[0])
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
