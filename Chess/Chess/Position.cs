﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess {
	class Position {

		string column;
		int columnInt;
		int row;
		string name;

		public string Column { get => column; }
		public int ColumnInt { get => columnInt; }
		public int Row { get => row; }
		public string Name { get => name; }

		public Position(int columnInt, int row)
		{
			this.columnInt = columnInt;
			this.row = row;
			column = ((char)(64 + columnInt)).ToString();
			name = $"{column}{row}";
		}

		public static bool operator ==(Position pos1, Position pos2)
		{
			if (pos1.column == pos2.column && pos1.row == pos2.row)
				return true;
			return false;
		}
		public static bool operator !=(Position pos1, Position pos2)
		{
			if (pos1.column == pos2.column && pos1.row == pos2.row)
				return false;
			return true;
		}

	}
}