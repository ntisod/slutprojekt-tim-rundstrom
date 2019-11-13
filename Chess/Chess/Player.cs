using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Chess {
	class Player {

		public List<Chesspiece> pieces;
		public int points;
		bool isWhite;
		bool hasLost;

		public Player(bool isWhite) {
			pieces = new List<Chesspiece>();
			this.isWhite = isWhite;
			points = 0;
			hasLost = false;
		}

		

	}
}
