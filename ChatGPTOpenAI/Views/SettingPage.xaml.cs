using ChatGPTOpenAI.ViewModels;

namespace ChatGPTOpenAI.Views;

public partial class SettingPage : ContentPage
{
	public SettingPage()
	{
		InitializeComponent();
        var viewModel = new SettingViewModel();
        BindingContext = viewModel;
    }
}