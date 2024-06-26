using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Threading;
using System;
using System.Timers;

namespace final_click.Views
{
	public partial class MainView : UserControl
	{
		bool GameStarted = false;
		int number = 0;
		int AutoClickNum = 0;
		int AutoClickPrice = 20;
		int AutoClickMult = 0;
		int cps = 0;
		Avalonia.Controls.TextBlock MainCount = null;
		private static Timer aTimer;

		public MainView()
		{
			InitializeComponent();
			int cps = AutoClickNum * AutoClickMult;
			aTimer = new System.Timers.Timer();
			aTimer.Interval = 1000;
			aTimer.Elapsed += Update;
			aTimer.AutoReset = true;
			aTimer.Enabled = true;
		}

		private void Click_button(object sender, RoutedEventArgs e)
		{
			number++;
			myTextBlock.Text = "$" + number.ToString();
			MainCount = myTextBlock;
			GameStarted = true;
		}

		private void AutoClicker(object sender, RoutedEventArgs e)
		{
			if (number >= AutoClickPrice)
			{
				Console.WriteLine("auto clicker");
				AutoClickNum++;
				number -= AutoClickPrice;
				AutoText.Text = AutoClickNum.ToString();
				myTextBlock.Text = "$" + number.ToString();
				AutoClickPrice++;
				AutoClickPriceText.Text = "$" + AutoClickPrice.ToString();

			}
			
		}

		public void Update(object source, ElapsedEventArgs e)
		{
			if (GameStarted == true)
			{
				number += AutoClickNum;

				// Dispatch UI update to the UI thread
				Dispatcher.UIThread.InvokeAsync(() =>{ myTextBlock.Text = "$" + number.ToString(); });
			}
		}
	}
}
