using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media.TextFormatting;

namespace final_click.ViewModels;

public class MainViewModel : ViewModelBase
{
    public string Greeting => "click to start";
	public int AutoClick => 0;
	public string AutoClickDefaultPice => "$20";
	public string CPSStart => "CPS: 0";
}

