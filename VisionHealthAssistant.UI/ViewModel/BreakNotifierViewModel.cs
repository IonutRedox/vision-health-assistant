using System;
using System.Windows.Threading;
using VisionHealthAssistant.UI.Helper;

namespace VisionHealthAssistant.UI.ViewModel
{
    public class BreakNotifierViewModel : ViewModelBase
    {
        #region Fields

        private DispatcherTimer _timer;
        private int _seconds;
        private bool? _dialogResult;
        private string _nextBreakMessage;

        #endregion

        #region Constructor

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="seconds"></param>
        public BreakNotifierViewModel(int seconds)
        {
            _seconds = seconds;
            InitializeCommands();
            InitializeTimer();
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Determines whether the user stopped timer.
        /// </summary>
        public bool IsManuallyStopped { get; private set; }

        /// <summary>
        ///     Determine whether the user skipped next break.
        /// </summary>
        public bool IsNextBreakSkipped { get; private set; }

        /// <summary>
        /// Gets or sets a signal to close the window associated with this view model.
        /// </summary>
        public bool? DialogResult
        {
            get { return _dialogResult; }
            private set {
                if(_dialogResult != value) {
                    _dialogResult = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        ///     User message related to next break.
        /// </summary>
        public string NextBreakMessage
        {
            get { return _nextBreakMessage; }
            set {
                if(!string.Equals(_nextBreakMessage,value)) {
                    _nextBreakMessage = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion

        #region Commands

        /// <summary>
        ///     Stop timer command.
        /// </summary>
        public RelayCommand StopCommand { get; private set; }

        /// <summary>
        ///     Skip next break command.
        /// </summary>
        public RelayCommand SkipCommand { get; private set; }

        #endregion

        #region Methods

        /// <summary>
        ///     Initializes commands.
        /// </summary>
        protected override void InitializeCommands()
        {
            StopCommand = new RelayCommand(action => {
                StopTimer();
                IsManuallyStopped = true;
            },p => CanStopTimer());

            SkipCommand = new RelayCommand(action => {
                StopTimer();
                IsNextBreakSkipped = true;
            },p => CanStopTimer());
        }

        /// <summary>
        /// Initializes the timer.
        /// </summary>
        private void InitializeTimer()
        {
            _timer = new DispatcherTimer();
            _timer.Tick += OnTimerTick;
            _timer.Interval = new TimeSpan(0,0,1);
            _timer.Start();
            SetNextBreakMessage(_seconds);
        }

        private void StopTimer()
        {
            _timer.Stop();
            _timer.Tick -= OnTimerTick;
            DialogResult = true;
        }

        /// <summary>
        ///     Whether timer can be stopped.
        /// </summary>
        /// <returns></returns>
        private bool CanStopTimer()
        {
            return true;
        }


        /// <summary>
        ///     Timer tick.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTimerTick(object sender,EventArgs e)
        {
            if(_seconds == 0) {
                StopTimer();
            } else {
                _seconds--;
            }
            SetNextBreakMessage(_seconds);
        }

        /// <summary>
        ///     Sets next break message.
        /// </summary>
        /// <param name="seconds"></param>
        private void SetNextBreakMessage(int seconds)
        {
            NextBreakMessage = $"Next break will start in {seconds} seconds";
        }

        #endregion
    }
}
