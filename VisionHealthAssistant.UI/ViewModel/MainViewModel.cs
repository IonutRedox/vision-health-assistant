using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Windows;
using UIVisionHealthAssistant.Helper;
using VisionHealthAssistant.Shared;

namespace UIVisionHealthAssistant.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        #region Constructor
        
        /// <summary>
        /// Parameterless constructor for the main window.
        /// </summary>
        public MainViewModel() {
            InitializeCommands();
            InitializePageStates();
            _pageViewModels = new List<ViewModelBase> {
                new NewsViewModel()
            };
            CurrentPageViewModel = _pageViewModels.First();
        }

        #endregion

        #region Fields

        private List<ViewModelBase> _pageViewModels;
        private ViewModelBase _currentPageViewModel;

        #endregion

        #region Properties

        /// <summary>
        /// Get the application name.
        /// </summary>
        public string AppName { get; } = SharedSettings.AppName;

        /// <summary>
        /// Current view model.
        /// </summary>
        public ViewModelBase CurrentPageViewModel {
            get { return _currentPageViewModel; }
            set {
                if (_currentPageViewModel != value) {
                    _currentPageViewModel = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Retrieves the access to all pages.
        /// </summary>
        public ObservableCollection<bool> PageState { get; private set; }

        #endregion

        #region Commands

        /// <summary>
        /// Command to exit the application.
        /// </summary>
        public RelayCommand ExitCommand { get; private set; }

        /// <summary>
        /// Command to change current view model.
        /// </summary>
        public RelayCommand ChangePageCommand { get; private set; }

        #endregion

        #region Methods
        /// <summary>
        /// Initializes access to the pages.
        /// </summary>
        private void InitializePageStates()
        {
            PageState = new ObservableCollection<bool>();
            PageState.Insert((int)PageType.News, false);
            PageState.Insert((int)PageType.BreakTimer, true);
            PageState.Insert((int)PageType.EyeExercises, true);
            PageState.Insert((int)PageType.Settings, true);
            PageState.Insert((int)PageType.About, true);
        }

        /// <summary>
        /// Closes the window associated with this view-model.
        /// </summary>
        public void CloseWindow(ICloseable window) {
            if (window != null) {
                window.Close();
            }
        }

        /// <summary>
        /// Initializes commands.
        /// </summary>
        public void InitializeCommands() {
            ExitCommand = new RelayCommand(p => CloseWindow((ICloseable)p), p => true);
            ChangePageCommand = new RelayCommand(p => ChangeViewModel(p as string),p=> true);
        }

        /// <summary>
        /// Get specific view model depending on page type.
        /// </summary>
        /// <param name="pageType"></param>
        /// <returns></returns>
        private ViewModelBase GetViewModel(string pageType)
        {
            object viewModel;
            const string Namespace = "UIVisionHealthAssistant.ViewModel.";
            const string ViewModel = "ViewModel";
            string ViewModelClass = string.Join(string.Empty,Namespace, pageType, ViewModel);
            Type type = Assembly.GetExecutingAssembly().GetType(ViewModelClass);
            viewModel = Activator.CreateInstance(type);
            return viewModel as ViewModelBase;
        }

        /// <summary>
        /// Switches the current view model to the target one.
        /// </summary>
        /// <param name="targetViewModel"></param>
        private void ChangeViewModel(string targetPage)
        {
            ViewModelBase targetViewModel = GetViewModel(targetPage);
            if(!_pageViewModels.Any(vm => vm.Type == targetViewModel.Type)) {
                _pageViewModels.Add(targetViewModel);
            }
            PageType oldPageType = CurrentPageViewModel.Type;
            PageType currentPageType = targetViewModel.Type;
            PageState[(int)oldPageType] = true;
            PageState[(int)currentPageType] = false;
            CurrentPageViewModel = _pageViewModels.First(vm => vm.Type == targetViewModel.Type);
        }

        #endregion
    }
}