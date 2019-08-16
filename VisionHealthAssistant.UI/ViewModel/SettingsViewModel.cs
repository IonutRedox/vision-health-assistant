using VisionHealthAssistant.Shared;

namespace VisionHealthAssistant.UI.ViewModel
{
    public class SettingsViewModel : ViewModelBase
    {
        #region Constructor

        public SettingsViewModel()
        {
            Type = PageType.Settings;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Initializes commands.
        /// </summary>
        protected override void InitializeCommands()
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
