using System.Windows;
using UIVisionHealthAssistant.Helper;

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
        }

        #endregion

        #region Fields
    
        #endregion

        #region Properties

        /// <summary>
        /// Get the application name.
        /// </summary>
        public string AppName { get; } = "Vision Health Assistant";

        #endregion

        #region Commands

        /// <summary>
        /// Command to exit the application.
        /// </summary>
        public RelayCommand ExitCommand { get; private set; }

        #endregion

        #region Methods

        /// <summary>
        /// Closes the window associated with this view-model.
        /// </summary>
        public void CloseWindow() {
            Application.Current.Shutdown();
        }

        public void InitializeCommands() {
            ExitCommand = new RelayCommand(execute => CloseWindow());
        }

        #endregion
    }
}