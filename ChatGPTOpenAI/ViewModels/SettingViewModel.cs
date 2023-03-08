using ChatGPTOpenAI.ViewModels.Base;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace ChatGPTOpenAI.ViewModels;

public partial class SettingViewModel : BaseViewModel
{
  
    [ObservableProperty]
    public string apiKey;


    public SettingViewModel()
    {
        ApiKey = System.Environment.GetEnvironmentVariable("OPENAI_API_KEY");
    }

    [RelayCommand]
    private void SaveApiKey()
    {
        System.Environment.SetEnvironmentVariable("OPENAI_API_KEY", ApiKey);
        Application.Current.MainPage.DisplayAlert("Success", "API Key saved.", "OK");
    }
}
