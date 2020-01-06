using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_online {
	/// <summary>
	/// Player class, one for the white player, one for the black player
	/// Keeps track of whatever is assosiated with the player
	/// e.g. score, colour, pieces...
	/// </summary>
	class Player {

		public List<Chesspiece> pieces; // List of all the player pieces
		public int points; // The players points
		bool isWhite; // Colour of the player, white or black
		public bool hasLost; // Is the kings dead? or still alive

		/// <summary>
		/// Constructor method for the player class
		/// </summary>
		/// <param name="isWhite">Bool whether the player is white or not</param>
		public Player(bool isWhite) {
			pieces = new List<Chesspiece>(); // Declare the list for pieces
			this.isWhite = isWhite; // Set the colour of the player
			points = 0; // Set the score (0 at first obviously)
			hasLost = false; // Set the hasLost bool (false at first obviously)
		}

		/// <summary>
		/// Update method, called in the chessboard object to update whether the player has lost or not (is the king dead or alive)
		/// </summary>
		public void Update() {
			bool isKingAlive = false; // Bool for if the king is alive
			foreach (Chesspiece p in pieces) { // Loop through all of the players pieces
				if (p is King) // if one of the pieces is a king
					isKingAlive = true; // then the king is alive, set the bool to true
			}
			hasLost = !isKingAlive; // If the king is alive, then the player hasn't lost
		}

	}
}
