using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess_client {
	class Player {

		public readonly int ID;
		bool isWhite;
		public bool yourTurn;
		int points;

		public Player(int ID, bool isWhite) {
			this.ID = ID;
			this.isWhite = isWhite;
			yourTurn = isWhite;
			points = 0;
		}


	}
}
