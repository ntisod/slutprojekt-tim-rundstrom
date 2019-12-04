using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace chess_client {
	class Chessboard {
		public Player player1;
		public Player player2;

		public Chessboard(string playerSetup) {

			string id = playerSetup.Substring(0, 1);
			if (id == "1") {
				if (playerSetup.Substring(1, 1) == "t") {
					player1 = new Player(1, true);
					player2 = new Player(2, false);
				} else {
					player1 = new Player(1, false);
					player2 = new Player(2, true);
				}
			} else {
				if (playerSetup.Substring(1, 1) == "t") {
					player1 = new Player(2, true);
					player2 = new Player(1, false);
				} else {
					player1 = new Player(2, false);
					player2 = new Player(1, true);
				}
			}
		}

		public void Update(string message) {
			// Get a list of methods to execute from message
			List<Action> actions = DecypherMessage(message);

			// Execute said methods
			foreach (Action action in actions)
				action();
		}

		List<Action> DecypherMessage(string message) {
			List<Action> actions = new List<Action>();



			return actions;
		}

	}
}
