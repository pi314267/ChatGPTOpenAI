
using System.Runtime.CompilerServices;
using ChatGPTOpenAI.Services;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ChatGPTOpenAI.ViewModels.Base;


public partial class BaseViewModel : ObservableObject
{
    public INavigationService Navigation => DependencyService.Get<INavigationService>();

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotBusy))]
    public bool isBusy;

    public bool IsNotBusy => !IsBusy;

    [ObservableProperty]
    public bool title;


    //bool isBusy = false;
    //string title = string.Empty;
    //public bool IsBusy
    //{
    //    get { return this.isBusy; }
    //    set { SetProperty(ref this.isBusy, value); }
    //}

    //public string Title
    //{
    //    get { return this.title; }
    //    set { SetProperty(ref this.title, value); }
    //}

    protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
    {
        if (EqualityComparer<T>.Default.Equals(backingStore, value))
            return false;

        backingStore = value;
        onChanged?.Invoke();
        OnPropertyChanged(propertyName);
        return true;
    }



}
