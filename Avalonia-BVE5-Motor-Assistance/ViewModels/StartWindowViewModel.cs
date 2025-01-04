using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Avalonia_BVE5_Motor_Assistance.ViewModels
{
    public partial class StartWindowViewModel : ViewModelBase
    {
        #region properties

        [ObservableProperty] private ViewModelBase _currentViewModel;

        [ObservableProperty] private HistoryViewModel _historyViewModel = new HistoryViewModel();

        [ObservableProperty] private NewFileViewModel _newFileViewModel = new NewFileViewModel();

        [ObservableProperty] private OpenFileViewModel _openFileViewModel = new OpenFileViewModel();

        [ObservableProperty] private SettingsViewModel _settings = new SettingsViewModel();

        #endregion
        
        #region ctors
 
        public StartWindowViewModel()
        {
            CurrentViewModel = HistoryViewModel;
        }
 
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
}