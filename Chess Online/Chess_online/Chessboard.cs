using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Chess_online {
	public class Chessboard {

		public Server server;
		public Client client;


		public Dictionary<string, Button> buttons;
		bool playOnline;

		public Chessboard() {
			server = new Server();
			client = new Client();

			buttons = new Dictionary<string, Button>();
		}

		public void SetupGame(bool playOnline) {
			this.playOnline = playOnline;

			if (playOnline) {

			}
		}
	}
}
