using System.Globalization;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Avalonia_BVE5_Motor_Assistance.ViewModels;

public partial class StartWindowViewModel : ViewModelBase
{
    #region ctors

    public StartWindowViewModel()
    {
        CurrentViewModel = HistoryViewModel;
    }

    #endregion

    #region properties

    [ObservableProperty] private ViewModelBase _currentViewModel;

    [ObservableProperty] private HistoryViewModel _historyViewModel = new();

    [ObservableProperty] private NewFileViewModel _newFileViewModel = new();

    [ObservableProperty] private OpenFileViewModel _openFileViewModel = new();

    [ObservableProperty] private SettingsViewModel _settings = new();

    #endregion

    #region commands

    [RelayCommand]
    public void GoHistoryCommand()
    {
        CurrentViewModel = _historyViewModel;
    }

    [RelayCommand]
    public void GoNewFileCommand()
    {
        CurrentViewModel = _newFileViewModel;
    }

    #endregion
}