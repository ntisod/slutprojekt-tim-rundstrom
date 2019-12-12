using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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
		}

		public void ButtonPress(Position position) {

			// GET ACTION

			string actionMessage;

			if (isLocal) {
				// Send it to client through server and then update it in Update method
				actionMessage = $"Server says: {position.Name}";
				MainWindow.server.Send(actionMessage);
				Update(actionMessage);
			} else {
				// Send it to server through client
				actionMessage = $"Client says: {position.Name}";
				MainWindow.client.Send(actionMessage);
			}

		}
		
		public void Update(string message) {

			// Update according to message
			MessageBox.Show(message);

		}

	}
}
