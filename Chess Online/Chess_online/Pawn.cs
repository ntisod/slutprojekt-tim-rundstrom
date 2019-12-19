﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Chess_online {
	class Pawn : Chesspiece {

		bool untouched;

		public Pawn(Position position, bool isWhite) : base(isWhite ? "♙" : "♟", position, isWhite, 1) {
			untouched = true;
		}

		public override List<Position> GetMoves(List<Chesspiece> pieces) {
			List<Position> moves = new List<Position>();

			int c = IsWhite ? 1 : -1;
			moves.Add(new Position(Pos.columnInt, Pos.row + 1 * c));
			if (untouched)
				moves.Add(new Position(Pos.columnInt, Pos.row + 2 * c));

			foreach (Chesspiece p in pieces) {

				if (p.IsWhite == IsWhite) {
					if (untouched) {
						if (p.Pos == moves[1])
							moves.RemoveAt(1);
					}
					if (p.Pos == moves[0])
						moves.Clear();
				} else {

					if (p.Pos.columnInt == Pos.columnInt + 1 && p.Pos.row == (Pos.row + (1 * c))) {
						moves.Add(p.Pos);
					}

					if (p.Pos.columnInt == Pos.columnInt - 1 && p.Pos.row == (Pos.row + (1 * c))) {
						moves.Add(p.Pos);
					}

				}

			}

			return moves;
		}

		public override void MovePiece(Position position) {
			base.MovePiece(position);
			untouched = false;
		}

	}
}