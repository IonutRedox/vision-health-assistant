using VisionHealthAssistant.Shared;

namespace VisionHealthAssistant.UI.ViewModel
{
    public class NewsViewModel : ViewModelBase
    {
        #region Constructor

        public NewsViewModel()
        {
            Type = PageType.News;
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
