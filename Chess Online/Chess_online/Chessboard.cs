using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Chess_online {
	public class Chessboard {

		public Dictionary<string, Button> buttons;
		bool playOnline;
		bool isLocal;

		public Chessboard() {
			buttons = new Dictionary<string, Button>();
		}

		public void SetupGame(bool playOnline, bool isLocal) {
			this.playOnline = playOnline;
			this.isLocal = isLocal;

			SetupButtons()
		}
		
		void SetupButtons() {

		}

	}
}
