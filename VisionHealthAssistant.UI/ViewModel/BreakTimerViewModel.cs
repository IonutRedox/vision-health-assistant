using VisionHealthAssistant.Shared;
using VisionHealthAssistant.UI.Model;

namespace VisionHealthAssistant.UI.ViewModel
{
    public class BreakTimerViewModel : ViewModelBase
    {
        #region Constructor

        public BreakTimerViewModel()
        {
            Type = PageType.BreakTimer;
            BreakTimer = new BreakTimer {
                Frequency = 0,
                Length = 0,
                IdleResetTime = 0
            };
        }

        #endregion

        #region Fields 



        #endregion

        #region Properties

        /// <summary>
        /// Gets the page info.
        /// </summary>
        public string Info { get; } = "    Break timer notifies you to take regular breaks at specified time intervals to maintain eyes health.Please consider the minute as unit of measurement.";

        /// <summary>
        /// Gets the break timer.
        /// </summary>
        public BreakTimer BreakTimer { get; }

        #endregion

    }
}