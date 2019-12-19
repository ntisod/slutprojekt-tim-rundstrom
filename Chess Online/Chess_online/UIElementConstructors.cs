using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows;

namespace Chess_online {
	/// <summary>
	/// Use for easy construction of uielements programmatically
	/// </summary>
	public static class UIElementConstructors {

		/// <summary>
		/// Creates and return a button tailored to your arguments
		/// </summary>
		/// <param name="text"></param>
		/// <param name="name"></param>
		/// <param name="fontsize"></param>
		/// <param name="margin"></param>
		/// <param name="clickevent"></param>
		/// <param name="column"></param>
		/// <param name="row"></param>
		/// <param name="columnspan"></param>
		/// <returns></returns>
		public static Button ButtonContructor(string text, string name, int fontsize, int margin, RoutedEventHandler clickevent, int column, int row, int columnspan) {
			// Declare a new button
			Button btn = new Button();
			btn.Content = text; // Set text
			btn.Name = name; // Set name
			btn.FontSize = fontsize; // Set fontsize
			btn.Margin = new Thickness(margin); // Give a marign of a thickness of 5
			if (clickevent != null)
				btn.Click += clickevent; // Add button click
			Grid.SetColumn(btn, column); // Set column
			Grid.SetRow(btn, row); // Set row
			Grid.SetColumnSpan(btn, columnspan);
			return btn;
		}
		/// <summary>
		/// Creates and return a textblock tailored to your arguments
		/// </summary>
		/// <param name="text"></param>
		/// <param name="name"></param>
		/// <param name="fontsize"></param>
		/// <param name="textAlignment"></param>
		/// <param name="horizontalAlignment"></param>
		/// <param name="verticalAlignment"></param>
		/// <param name="column"></param>
		/// <param name="row"></param>
		/// <param name="columnspan"></param>
		/// <returns></returns>
		public static TextBlock TextBlockConstructor(string text, string name, int fontsize, TextAlignment textAlignment, HorizontalAlignment horizontalAlignment, VerticalAlignment verticalAlignment, int column, int row, int columnspan) {

			// Declare a new textblock
			TextBlock tb = new TextBlock();
			tb.Text = text; // Set text
			tb.Name = name;
			tb.FontSize = fontsize; // Set fontsize
			tb.TextAlignment = textAlignment; // Align the text
			tb.HorizontalAlignment = horizontalAlignment; // Align the textblock horizontally
			tb.VerticalAlignment = verticalAlignment;  // Align the textblock vertically
			Grid.SetColumn(tb, column); // Set column
			Grid.SetRow(tb, row); // Set row
			Grid.SetColumnSpan(tb, columnspan); // Set column span
			return tb;

		}
		
		/// <summary>
		/// Creates and return a border tailored to your arguments
		/// </summary>
		/// <param name="colour"></param>
		/// <param name="thickness"></param>
		/// <param name="margin"></param>
		/// <param name="column"></param>
		/// <param name="row"></param>
		/// <returns></returns>
		public static Border BorderConstructor(Color colour, int thickness, int margin, int column, int row) {
			// Declare a new border for address_Text
			Border border = new Border();
			border.BorderBrush = new SolidColorBrush(colour); // Set a black border
			border.BorderThickness = new Thickness(thickness); // Set borderthickness to 1
			border.Margin = new Thickness(margin); // Give a margin of thickness 5
			Grid.SetColumn(border, column); // Set column
			Grid.SetRow(border, row); // Set row
			return border;
		}

		/// <summary>
		/// Creates and return a textbox tailored to your arguments
		/// </summary>
		/// <param name="name"></param>
		/// <param name="fontsize"></param>
		/// <param name="margin"></param>
		/// <param name="topPadding"></param>
		/// <param name="column"></param>
		/// <param name="row"></param>
		/// <param name="columnspan"></param>
		/// <returns></returns>
		public static TextBox TextBoxConstructor(string name, int fontsize, int margin, int topPadding, int column, int row, int columnspan) {
			// Declare a new textbox
			TextBox tb = new TextBox();
			tb.Name = name; // Set name
			tb.FontSize = fontsize; // Set fontsize
			tb.Margin = new Thickness(margin); // Give a margin of a thickness of 5
			tb.Padding = new Thickness(0, topPadding, 0, 0); // Give a top padding of 5
			Grid.SetColumn(tb, column); // Set column
			Grid.SetRow(tb, row); // Set row
			Grid.SetColumnSpan(tb, columnspan); // Set columnspan
			return tb;
		}
 
	}
}
