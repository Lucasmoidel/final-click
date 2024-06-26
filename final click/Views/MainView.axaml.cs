using Avalonia.Controls;
using Avalonia.Interactivity;
using System;

namespace final_click.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
    }
	int number = 0;
	private void Click_button(object sender, RoutedEventArgs e)
	{
		number++;
		myTextBlock.Text = number.ToString();
	}
	private void AutoClicker(object sender, RoutedEventArgs e)
	{
		Console.WriteLine("auto clicker ");
	}
}
