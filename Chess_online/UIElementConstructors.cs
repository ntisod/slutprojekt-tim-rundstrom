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
		/// <param name="text">What text should the button have in its content</param>
		/// <param name="name">What name should the button have</param>
		/// <param name="fontsize">What fontsize should the text in its content be</param>
		/// <param name="margin">What margins does the button have</param>
		/// <param name="clickevent">Which method is its clickevent</param>
		/// <param name="column">Which column does the button belong in</param>
		/// <param name="row">Which row does the button belong in</param>
		/// <param name="columnspan">How many columns does the button span over</param>
		/// <returns>A button object tailored to the arguments</returns>
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
		/// <param name="text">What text should the textblock display</param>
		/// <param name="name">What name does the textblock have</param>
		/// <param name="fontsize">What fontsize does the text have</param>
		/// <param name="textAlignment">What alignment does the text have</param>
		/// <param name="horizontalAlignment">What horizontal alignment does the whole textblock have</param>
		/// <param name="verticalAlignment">What vertical alignment does the whole textblock have</param>
		/// <param name="column">Which column does the textblock belong in</param>
		/// <param name="row">Which row does the textblock belong in</param>
		/// <param name="columnspan">How many columns does the textblock span over</param>
		/// <returns>A textblock object tailored to the arguments</returns>
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
		/// <param name="colour">What colour is the border</param>
		/// <param name="thickness">How thick is the border</param>
		/// <param name="margin">How much margin does the border have</param>
		/// <param name="column">Which column does the border belong in</param>
		/// <param name="row">Which row does the border belong in</param>
		/// <returns>A border object tailored to the arguments</returns>
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
		/// <param name="name">What name does the textbox have</param>
		/// <param name="fontsize">What fontsize should the text have</param>
		/// <param name="margin">What margin does the textbox have</param>
		/// <param name="topPadding">what top padding does the textbox have</param>
		/// <param name="column">which column does the textbox belong in</param>
		/// <param name="row">which row does the textbox belong in</param>
		/// <param name="columnspan">how many columns does the textbox span over</param>
		/// <returns>A textbox object tailored to the arguments</returns>
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
