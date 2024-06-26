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
		int AutoClickMult = 1;
		int cps = 0;
		Avalonia.Controls.TextBlock MainCount = null;
		private static Timer aTimer;

		public MainView()
		{
			InitializeComponent();
			int cps = AutoClickNum * AutoClickMult;
			aTimer = new System.Timers.Timer();
			aTimer.Interval = 1000;
			aTimer.Elapsed += AutoUpdate;
			aTimer.AutoReset = true;
			aTimer.Enabled = true;
		}

		private void Click_button(object sender, RoutedEventArgs e)
		{
			number++;
			GameStarted = true;
			Update();
		}

		private void AutoClicker(object sender, RoutedEventArgs e)
		{
			if (number >= AutoClickPrice)
			{
				Console.WriteLine("auto clicker");
				AutoClickNum++;
				number -= AutoClickPrice;
				AutoClickPrice++;
				Update();

			}
			
		}

		public void AutoUpdate(object source, ElapsedEventArgs e)
		{
			if (GameStarted == true)
			{
				cps = AutoClickNum * AutoClickMult;

				number += cps;

				// Dispatch UI update to the UI thread
				Dispatcher.UIThread.InvokeAsync(() => {
					myTextBlock.Text = "$" + number.ToString();
					AutoClickPriceText.Text = "$" + AutoClickPrice.ToString();
					AutoText.Text = AutoClickNum.ToString();
					CPSText.Text = "CPS: " + cps.ToString();
				});
			}
		}

		public void Update()
		{
			if (GameStarted == true)
			{
				// Dispatch UI update to the UI thread
				Dispatcher.UIThread.InvokeAsync(() => {
					myTextBlock.Text = "$" + number.ToString();
					AutoClickPriceText.Text = "$" + AutoClickPrice.ToString();
					AutoText.Text = AutoClickNum.ToString();
					CPSText.Text = "CPS: " + cps.ToString();
				});
			}
		}
	}
}
