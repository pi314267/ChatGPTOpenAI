using ChatGPTOpenAI.ViewModels.Base;
using System.Web;

namespace ChatGPTOpenAI.Services;
public class NavigationService : INavigationService
{
    public async Task NavigateToAsync<TViewModel>() where TViewModel : BaseViewModel
    {
        await InternalNavigateToAsync(typeof(TViewModel), null, false);
    }

    public async Task NavigateToAsync<TViewModel>(bool isAbsoluteRoute) where TViewModel : BaseViewModel
    {
        await InternalNavigateToAsync(typeof(TViewModel), null, isAbsoluteRoute);
    }

    public async Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : BaseViewModel
    {
        await InternalNavigateToAsync(typeof(TViewModel), parameter, false);
    }

    public async Task GoBackAsync()
    {
        await Shell.Current.GoToAsync("..");
    }

    public async Task NavigateToAsyncPush(Page page)
    {
        await Shell.Current.Navigation.PushAsync(page);
    }

    async Task InternalNavigateToAsync(Type viewModelType, object parameter, bool isAbsoluteRoute = false)
    {
        var viewName = viewModelType.FullName.Replace("ViewModels", "Views").Replace("ViewModel", "Page");
        string absolutePrefix = isAbsoluteRoute ? "///" : String.Empty;
        if (parameter != null)
        {
            await Shell.Current.GoToAsync(
                $"{absolutePrefix}{viewName}?id={HttpUtility.UrlEncode(parameter.ToString())}");
        }
        else
        {
            await Shell.Current.GoToAsync($"{absolutePrefix}{viewName}");
        }
    }
}
