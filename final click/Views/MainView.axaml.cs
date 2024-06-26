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
		float number = 0;
		float AutoClickNum = 0;
		float AutoClickPrice = 20;
		float AutoClickMult = 1;
		float AutoClickMultPrice = 100;
		float cps = 0;
		private static Timer aTimer;

		public MainView()
		{
			InitializeComponent();
			cps = AutoClickNum * AutoClickMult;
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

		private void AutoClickerMultiplyer(object sender, RoutedEventArgs e)
		{
			if (number >= AutoClickMultPrice)
			{
				AutoClickMult += (float)0.1;
				number -= AutoClickMultPrice;
				AutoClickMultPrice++;
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
					MainButton.Text = "$" + number.ToString();
					AutoClickPriceText.Text = "$" + AutoClickPrice.ToString();
					AutoCLickNumText.Text = AutoClickNum.ToString();
					AutoClickMultPriceText.Text = "$" + AutoClickMultPrice.ToString();
					AutoMultNumText.Text = AutoClickMult.ToString();
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
					MainButton.Text = "$" + number.ToString();
					AutoClickPriceText.Text = "$" + AutoClickPrice.ToString();
					AutoCLickNumText.Text = AutoClickNum.ToString();
					AutoClickMultPriceText.Text = "$" + AutoClickMultPrice.ToString();
					AutoMultNumText.Text = AutoClickMult.ToString();
					CPSText.Text = "CPS: " + cps.ToString();
				});
			}
		}
	}
}
