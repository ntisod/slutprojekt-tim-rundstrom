using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Chess_online {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>

	public partial class MainWindow : Window {

		public MainWindow() {
			InitializeComponent();
			
			GridManager newGrid = new GridManager(GridType.Main);
			SetGrid(newGrid);

			grid.ShowGridLines = true;
		}


		public void SetGrid(GridManager newGrid) {

			List<ColumnDefinition> columns = newGrid.Columns;
			List<RowDefinition> rows = newGrid.Rows;
			List<Control> controls = newGrid.Controls;

			//grid.ColumnDefinitions.Clear();
			//grid.RowDefinitions.Clear();
			//grid.Children.Clear();

			foreach (ColumnDefinition column in columns)
				grid.ColumnDefinitions.Add(column);

			foreach (RowDefinition row in rows)
				grid.RowDefinitions.Add(row);

			foreach (Control control in controls)
				grid.Children.Add(control);

		}
	}
}
