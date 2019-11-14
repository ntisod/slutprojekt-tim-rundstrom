using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Threading.Tasks;

namespace Chess {
	abstract class Chesspiece {

		string icon;
		Position pos;
		bool isWhite;
		int value;

		public string Icon { get => icon; }
		public Position Pos { get => pos; }
		public bool IsWhite { get => isWhite; }
		public int Value { get => value; }

		public Chesspiece(string icon, Position pos, bool isWhite, int value) {
			this.icon = icon;
			this.pos = pos;
			this.isWhite = isWhite;
			this.value = value;
		}
		public abstract List<Position> GetMoves(List<Chesspiece> teamPieces);

		public virtual void MovePiece(Position position) {
			pos = position;
		}

	}
}
