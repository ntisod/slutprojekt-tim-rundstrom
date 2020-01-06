using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess {
	/// <summary>
	/// Position class to easy keep track of chesspieces and buttons position, e.g. A4 (first column, forth row)
	/// </summary>
	public class Position {

		// Object variables (readonly, the object is as is and doesn't change)
		public readonly string column; // Column, displayed as a letter
		public readonly int columnInt; // Column, displayed as a number
		public readonly int row; // Row, displayed asa number
		public readonly string name; // Name, column and number combined e.g. A4
		public readonly string btnName; // Button name, column and number combined with 'Btn' specified e.g. BtnA4
		
		/// <summary>
		/// Class constructor, creates a position using the columnint and row arguments
		/// </summary>
		/// <param name="columnInt">Which column is the position (in numeration)</param>
		/// <param name="row">Which row is the position (in numeration)</param>
		public Position(int columnInt, int row) {
			this.columnInt = columnInt; // Set columnint
			this.row = row; // Set row
			column = ((char)(64 + columnInt)).ToString(); // Convert the columnint to a letter
			name = $"{column}{row}"; // concatenate the column and row into a name
			btnName = $"Btn{name}"; // concatenate the column and row together with 'Btn' for a button name
		}

		/// <summary>
		/// Comparator between two positions
		/// To see if position1 == position2
		/// </summary>
		/// <param name="pos1">First position to compare</param>
		/// <param name="pos2">Second position to compare</param>
		/// <returns>a bool value whether the two positions are the same or not</returns>
		public static bool operator ==(Position pos1, Position pos2) {
			if (pos1.name == pos2.name) // Is the two positions the same? (names should be the same)
				return true; // then return true
			return false; // otherwise return false
		}
		public static bool operator !=(Position pos1, Position pos2) {
			if (pos1.name == pos2.name) // Is the two positions the same? (names should be the same)
				return false; // then return false (we wan't the opposite, !=)
			return true; // otherwise return true
		}

	}
}
