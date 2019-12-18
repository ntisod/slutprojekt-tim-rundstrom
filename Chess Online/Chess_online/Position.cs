using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_online {
	public class Position {

		public readonly string column;
		public readonly int columnInt;
		public readonly int row;
		public readonly string name;
		public readonly string btnName;
		
		public Position(int columnInt, int row) {
			this.columnInt = columnInt;
			this.row = row;
			column = ((char)(64 + columnInt)).ToString();
			name = $"{column}{row}";
			btnName = $"Btn{name}";
		}

		public static bool operator ==(Position pos1, Position pos2) {
			if (pos1.column == pos2.column && pos1.row == pos2.row)
				return true;
			return false;
		}
		public static bool operator !=(Position pos1, Position pos2) {
			if (pos1.column == pos2.column && pos1.row == pos2.row)
				return false;
			return true;
		}

	}
}
