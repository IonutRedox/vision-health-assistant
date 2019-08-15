using VisionHealthAssistant.Shared;

namespace UIVisionHealthAssistant.ViewModel
{
    public class BreakTimerViewModel : ViewModelBase
    {
        #region Fields 

        public string Info { get; } = "    Break timer notifies you to take regular breaks at specified time intervals to maintain eyes health.Please consider the minute as unit of measurement.";

        #endregion

        #region Constructor

        public BreakTimerViewModel()
        {
            Type = PageType.BreakTimer;
        }

        #endregion
    }
}