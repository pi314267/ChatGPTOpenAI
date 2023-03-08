using ChatGPTOpenAI.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPTOpenAI.Services;

public interface INavigationService
{
    Task NavigateToAsync<TViewModel>() where TViewModel : BaseViewModel;

    Task NavigateToAsync<TViewModel>(bool isAbsoluteRoute) where TViewModel : BaseViewModel;

    Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : BaseViewModel;

    Task NavigateToAsyncPush(Page page);

    Task GoBackAsync();
}
