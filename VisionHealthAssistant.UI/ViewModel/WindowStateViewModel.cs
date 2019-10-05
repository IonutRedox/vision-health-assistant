using System.Windows;
using VisionHealthAssistant.UI.Helper;

namespace VisionHealthAssistant.UI.ViewModel
{
    public class WindowStateViewModel : ViewModelBase
    {
        #region Fields

        private bool _isMaximized;
        private bool _isRestoredDown;

        #endregion

        #region Constructors

        public WindowStateViewModel()
        {
            InitializeCommands();
            IsMaximized = false;
            IsRestoredDown = true;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Whether the window is maximized.
        /// </summary>
        public bool IsMaximized
        {
            get { return _isMaximized; }
            set {
                if(_isMaximized != value) {
                    _isMaximized = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Whether the window is restored down.
        /// </summary>
        public bool IsRestoredDown
        {
            get { return _isRestoredDown; }
            set {
                if(_isRestoredDown != value) {
                    _isRestoredDown = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion

        #region Commands

        /// <summary>
        /// Gets or sets the minimize window command.
        /// </summary>
        public RelayCommand MinimizeCommand { get; private set; }

        /// <summary>
        /// Gets or sets the maximize window command.
        /// </summary>
        public RelayCommand MaximizeCommand { get; private set; }

        /// <summary>
        /// Gets or sets the close window command.
        /// </summary>
        public RelayCommand CloseCommand { get; private set; }

        /// <summary>
        /// Gets or sets the restore down window command.
        /// </summary>
        public RelayCommand RestoreDownCommand { get; private set; }

        #endregion

        #region Methods

        /// <summary>
        /// Initializes commands.
        /// </summary>
        protected override void InitializeCommands()
        {
            MinimizeCommand = new RelayCommand(p => MinimizeWindow((MainWindow)p),p => true);
            MaximizeCommand = new RelayCommand(p => MaximizeWindow((MainWindow)p),p => true);
            RestoreDownCommand = new RelayCommand(p => RestoreDownWindow((MainWindow)p),p => true);
            CloseCommand = new RelayCommand(p => CloseWindow((MainWindow)p),p => true);
        }

        /// <summary>
        /// Minimizes the window.
        /// </summary>
        private void MinimizeWindow(object obj)
        {
            MainWindow mainWindow = obj as MainWindow;
            SystemCommands.MinimizeWindow(mainWindow);
        }

        /// <summary>
        /// Maximizes the window.
        /// </summary>
        private void MaximizeWindow(object obj)
        {
            MainWindow mainWindow = obj as MainWindow;
            SystemCommands.MaximizeWindow(mainWindow);
            SwapMaximizedAndRestoredDownStates();
        }

        /// <summary>
        /// Restores down the window.
        /// </summary>
        /// <param name="obj"></param>
        private void RestoreDownWindow(object obj)
        {
            MainWindow mainWindow = obj as MainWindow;
            SystemCommands.RestoreWindow(mainWindow);
            SwapMaximizedAndRestoredDownStates();
        }

        /// <summary>
        /// Closes the window.
        /// </summary>
        private void CloseWindow(object obj)
        {
            MainWindow mainWindow = obj as MainWindow;
            SystemCommands.CloseWindow(mainWindow);
        }

        /// <summary>
        /// Swaps the maximized and restord down states.
        /// </summary>
        private void SwapMaximizedAndRestoredDownStates()
        {
            IsMaximized = !IsMaximized;
            IsRestoredDown = !IsRestoredDown;
        }

        #endregion
    }
}
