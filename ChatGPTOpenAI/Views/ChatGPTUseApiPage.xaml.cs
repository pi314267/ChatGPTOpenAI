using ChatGPTOpenAI.ViewModels;

namespace ChatGPTOpenAI.Views;

public partial class ChatGPTUseApiPage : ContentPage
{
	public ChatGPTUseApiPage()
	{
		InitializeComponent();
        var vm = new ChatGPTUseApiViewModel();
        this.BindingContext = vm;

    }
}