using VisionHealthAssistant.Shared;
using VisionHealthAssistant.UI.Helper;
using VisionHealthAssistant.UI.Model;

namespace VisionHealthAssistant.UI.ViewModel
{
    public class BreakTimerViewModel : ViewModelBase
    {
        #region Constructor

        public BreakTimerViewModel()
        {
            Type = PageType.BreakTimer;
            InitializeCommands();
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

        #region Commands 

        /// <summary>
        /// Increases the break timer frequency.
        /// </summary>
        public RelayCommand IncreaseFrequencyCommand { get; private set; }
        
        /// <summary>
        /// Decreases the break timer frequency.
        /// </summary>
        public RelayCommand DecreaseFrequencyCommand { get; private set; }

        /// <summary>
        /// Increases  the break timer length.
        /// </summary>
        public RelayCommand IncreaseLengthCommand { get; private set; }

        /// <summary>
        /// Decreases the break timer length.
        /// </summary>
        public RelayCommand DecreaseLengthCommand { get; private set; }

        /// <summary>
        /// Increases the break timer idle reset time.
        /// </summary>
        public RelayCommand IncreaseIdleResetTimeCommand { get; private set; }

        /// <summary>
        /// Decreases the break timer idle reset time.
        /// </summary>
        public RelayCommand DecreaseIdleResetTimeCommand { get; private set; }


        #endregion

        #region Methods

        /// <summary>
        /// Initializes commands
        /// </summary>
        protected override void InitializeCommands()
        {
            IncreaseFrequencyCommand = new RelayCommand(p => { BreakTimer.Frequency++; },p => true);
            IncreaseLengthCommand = new RelayCommand(p => { BreakTimer.Length++; },p => true);
            IncreaseIdleResetTimeCommand = new RelayCommand(p => { BreakTimer.IdleResetTime++; },p => true);

            DecreaseFrequencyCommand = new RelayCommand(p => { BreakTimer.Frequency--; },p => BreakTimer.Frequency>0);
            DecreaseLengthCommand = new RelayCommand(p => { BreakTimer.Length--; },p => BreakTimer.Length>0);
            DecreaseIdleResetTimeCommand = new RelayCommand(p => { BreakTimer.IdleResetTime--; },p => BreakTimer.IdleResetTime>0);
        }

        #endregion

    }
}