using VisionHealthAssistant.Shared;

namespace VisionHealthAssistant.UI.ViewModel
{
    public class AboutViewModel : ViewModelBase
    {
        #region Constructor

        public AboutViewModel()
        {
            Type = PageType.About;
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
