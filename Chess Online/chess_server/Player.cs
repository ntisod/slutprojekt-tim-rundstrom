using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace chess_server {
	class Player {

		public Socket socket;
		int ID;
		bool isWhite;
		public bool yourTurn;
		int points;

		public Player(int ID, bool isWhite, Socket socket) {

			this.socket = socket;
			this.ID = ID;
			this.isWhite = isWhite;
			yourTurn = isWhite;
			points = 0;

		}

	}
}
