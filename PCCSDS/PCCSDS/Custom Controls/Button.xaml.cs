﻿using System;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PCCSDS
{
	/// <summary>
	/// Interaction logic for Button.xaml
	/// </summary>
	public partial class Button : UserControl
	{
		public Button()
		{
			InitializeComponent();

			UpdateButton();
		}

		public enum ButtonType
		{
			Primary,
			Secondary,
			Warning
		}

		private ButtonType _type;

		/// <summary>
		/// Type of the button
		/// </summary>
		public ButtonType Type
		{
			get
			{
				return _type;
			}
			set
			{
				_type = value;
				UpdateButton();
			}
		}

		private string _text;

		/// <summary>
		/// The text that should be appeared on the Button
		/// </summary>
		public string Text
		{
			get
			{
				return _text;
			}
			set
			{
				_text = value;
				UpdateButton();
			}
		}

		private void UpdateButton()
		{
			TextContent.Content = Text;
			TextContent.FontFamily = FontFamily;
			TextContent.FontSize = FontSize;


			switch (Type)
			{
				case ButtonType.Primary:
					RectangularContent.Fill = new SolidColorBrush(Colors.Maroon);
					TextContent.Foreground = new SolidColorBrush(Colors.White);
					break;
				case ButtonType.Secondary:
					RectangularContent.Fill = new SolidColorBrush(Colors.White);
					TextContent.Foreground = new SolidColorBrush(Colors.Maroon);
					break;
				case ButtonType.Warning:
					RectangularContent.Fill = new SolidColorBrush(Colors.Red);
					TextContent.Foreground = new SolidColorBrush(Colors.White);
					break;
			}
		}

		private void RectangularContent_MouseDown(object sender, MouseButtonEventArgs e)
		{

			DoubleAnimation OpacityAnimation = new DoubleAnimation();
			OpacityAnimation.From = RectangularContent.Opacity;
			OpacityAnimation.To = 0.8d;
			OpacityAnimation.Duration = TimeSpan.FromMilliseconds(200);

			RectangularContent.BeginAnimation(OpacityProperty, OpacityAnimation);

			DoubleAnimation circulator_dissappearing = new DoubleAnimation();
			circulator_dissappearing.From = Circulator.Opacity;
			circulator_dissappearing.To = 1;
			circulator_dissappearing.Duration = TimeSpan.FromMilliseconds(100);
			circulator_dissappearing.EasingFunction = new ExponentialEase();

			Circulator.BeginAnimation(OpacityProperty, circulator_dissappearing);

			DoubleAnimation increment = new DoubleAnimation(0, 200, new Duration(TimeSpan.FromMilliseconds(800)));
			increment.EasingFunction = new QuarticEase();
			Circulator.BeginAnimation(WidthProperty, increment);
			Circulator.BeginAnimation(HeightProperty, increment);
		}


		private void RectangularContent_MouseLeave(object sender, MouseEventArgs e)
		{

			DoubleAnimation OpacityAnimation = new DoubleAnimation();
			OpacityAnimation.From = RectangularContent.Opacity;
			OpacityAnimation.To = 1;
			OpacityAnimation.Duration = TimeSpan.FromMilliseconds(200);

			RectangularContent.BeginAnimation(OpacityProperty, OpacityAnimation);

			DoubleAnimation circulator_dissappearing = new DoubleAnimation();
			circulator_dissappearing.From = Circulator.Opacity;
			circulator_dissappearing.To = 0;
			circulator_dissappearing.Duration = TimeSpan.FromMilliseconds(400);
			circulator_dissappearing.EasingFunction = new ExponentialEase();

			Circulator.BeginAnimation(OpacityProperty, circulator_dissappearing);
		}


		private void RectangularContent_MouseUp(object sender, MouseButtonEventArgs e)
		{
			DoubleAnimation OpacityAnimation = new DoubleAnimation();
			OpacityAnimation.From = RectangularContent.Opacity;
			OpacityAnimation.To = 1;
			OpacityAnimation.Duration = TimeSpan.FromMilliseconds(200);

			RectangularContent.BeginAnimation(OpacityProperty, OpacityAnimation);

			DoubleAnimation circulator_dissappearing = new DoubleAnimation();
			circulator_dissappearing.From = Circulator.Opacity;
			circulator_dissappearing.To = 0;
			circulator_dissappearing.Duration = TimeSpan.FromMilliseconds(400);
			circulator_dissappearing.EasingFunction = new ExponentialEase();

			Circulator.BeginAnimation(OpacityProperty, circulator_dissappearing);

		}

	}
}
