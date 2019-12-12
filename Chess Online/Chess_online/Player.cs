using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_online {
	class Player {

		public List<Chesspiece> pieces;
		public int points;
		bool isWhite;
		public bool hasLost;

		public Player(bool isWhite) {
			pieces = new List<Chesspiece>();
			this.isWhite = isWhite;
			points = 0;
			hasLost = false;
		}

		public void Update() {
			bool isKingAlive = false;
			foreach (Chesspiece p in pieces) {
				if (p is King)
					isKingAlive = true;
			}
			hasLost = !isKingAlive;
		}

	}
}
