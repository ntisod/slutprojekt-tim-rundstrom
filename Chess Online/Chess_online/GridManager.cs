using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace Chess_online {
	public enum GridType { Main, Single, Online}
	public class GridManager {

		List<ColumnDefinition> columns;
		List<RowDefinition> rows;
		List<Control> controls;

		public List<ColumnDefinition> Columns { get => columns; }
		public List<RowDefinition> Rows { get => rows; }
		public List<Control> Controls{ get => controls; }

		public GridManager(GridType gridType) {

			columns = new List<ColumnDefinition>();
			rows = new List<RowDefinition>();
			controls = new List<Control>();

			switch (gridType) {
				case GridType.Main:
					break;
				case GridType.Single:
					break;
				case GridType.Online:
					break;
			}
		}

		void SetupMain() {

			ColumnDefinition col1 = new ColumnDefinition();
			ColumnDefinition col2 = new ColumnDefinition();
			col2.Width = new GridLength(100);
			ColumnDefinition col3 = new ColumnDefinition();
			columns.Add(col1);
			columns.Add(col2);
			columns.Add(col3);

			RowDefinition row1 = new RowDefinition();
			RowDefinition row2 = new RowDefinition();
			row2.Height = new GridLength(50);
			RowDefinition row3 = new RowDefinition();
			row3.Height = new GridLength(50);
			RowDefinition row4 = new RowDefinition();
			row4.Height = new GridLength(50);
			RowDefinition row5 = new RowDefinition();
			rows.Add(row1);
			rows.Add(row2);
			rows.Add(row3);
			rows.Add(row4);
			rows.Add(row5); 

		}
		void SetupSingle() {

		}
		void SetupOnline() {

		}
		
		

	}
}
