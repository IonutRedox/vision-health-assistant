using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Windows;
using VisionHealthAssistant.Shared;
using VisionHealthAssistant.UI.Helper;

namespace VisionHealthAssistant.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        #region Constructor

        /// <summary>
        /// Parameterless constructor for the main window.
        /// </summary>
        public MainViewModel()
        {
            InitializeCommands();
            InitializePageStates();
            SelectFirstPage();
        }

        #endregion

        #region Fields

        private List<ViewModelBase> _pageViewModels;
        private ViewModelBase _currentPageViewModel;
        private WindowState _windowState;

        #endregion

        #region Properties

        /// <summary>
        /// Get the application name.
        /// </summary>
        public string AppName { get; } = SharedSettings.AppName;

        /// <summary>
        /// Current view model.
        /// </summary>
        public ViewModelBase CurrentPageViewModel
        {
            get { return _currentPageViewModel; }
            set {
                if(_currentPageViewModel != value) {
                    _currentPageViewModel = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the window state.
        /// </summary>
        public WindowState WindowState
        {
            get { return _windowState; }
            set {
                if(_windowState != value) {
                    _windowState = value;
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
        /// Command to minimize the window.
        /// </summary>
        public RelayCommand MinimizeWindowCommand { get; private set; }

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
            WindowState = WindowState.Normal;
            PageState = new ObservableCollection<bool>();
            PageState.Insert((int)Pages.News,false);
            PageState.Insert((int)Pages.BreakTimer,true);
            PageState.Insert((int)Pages.EyeExercises,true);
            PageState.Insert((int)Pages.Settings,true);
            PageState.Insert((int)Pages.About,true);
        }

        /// <summary>
        /// Closes the window associated with this view-model.
        /// </summary>
        private void Exit(ICloseable window)
        {
            if(window != null) {
                window.Close();
                SaveViewModelConfigurations();
            }
        }

        /// <summary>
        /// Changes the current state of the window to minimized.
        /// </summary>
        private void MinimizeWindow()
        {
            WindowState = WindowState.Minimized;
        }

        /// <summary>
        ///     Save user configurations per viewmodels.
        /// </summary>
        private void SaveViewModelConfigurations()
        {
            BreakTimerViewModel breakTimerViewModel =(BreakTimerViewModel)_pageViewModels.Single(vm => vm is BreakTimerViewModel);
            if(breakTimerViewModel != null) {
                breakTimerViewModel.SaveUserConfiguration();
            }
        }



        /// <summary>
        /// Initializes commands.
        /// </summary>
        protected override void InitializeCommands()
        {
            MinimizeWindowCommand = new RelayCommand(p => MinimizeWindow(),p => true);
            ExitCommand = new RelayCommand(p => Exit((ICloseable)p),p => true);
            ChangePageCommand = new RelayCommand(p => ChangeViewModel(p as string),p => true);
        }

        /// <summary>
        /// Selects the first page.
        /// </summary>
        private void SelectFirstPage()
        {
            _pageViewModels = new List<ViewModelBase> {
                new NewsViewModel()
            };
            CurrentPageViewModel = _pageViewModels.First();
        }

        /// <summary>
        /// Get specific view model depending on page type.
        /// </summary>
        /// <param name="Pages"></param>
        /// <returns></returns>
        private ViewModelBase GetViewModel(string Pages)
        {
            object viewModel;
            const string Namespace = "VisionHealthAssistant.UI.ViewModel.";
            const string ViewModel = "ViewModel";
            string ViewModelClass = string.Join(string.Empty,Namespace,Pages,ViewModel);
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
            Pages oldPages = CurrentPageViewModel.Type;
            Pages currentPages = targetViewModel.Type;
            PageState[(int)oldPages] = true;
            PageState[(int)currentPages] = false;
            CurrentPageViewModel = _pageViewModels.First(vm => vm.Type == targetViewModel.Type);
        }

        #endregion
    }
}