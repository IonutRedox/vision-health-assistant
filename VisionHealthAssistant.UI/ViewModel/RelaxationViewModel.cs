using System;
using System.Windows.Threading;
using VisionHealthAssistant.UI.Helper;

namespace VisionHealthAssistant.UI.ViewModel
{
    public class RelaxationViewModel : ViewModelBase
    {
        #region Fields

        private DispatcherTimer _timer;
        private int _counter;
        private readonly int _duration;
        private string _remainingTime;
        private bool? _dialogResult;

        #endregion

        #region Constructor

        public RelaxationViewModel(string message,int duration)
        {
            if(string.IsNullOrWhiteSpace(message)) {
                throw new ArgumentNullException(message);
            }

            if(duration <= 0) {
                throw new ArgumentNullException(nameof(duration));
            }


            Message = message;
            _duration = duration;
            RemainingTime = BreakTimerHelper.GetFormattedTimeFromMinutes(duration);
            InitializeTimer();
            InitializeCommands();
        }

        #endregion

        #region Properties

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
        /// Gets or sets the remaining time.
        /// </summary>
        public string RemainingTime
        {
            get { return _remainingTime; }
            set {
                if(_remainingTime != value) {
                    _remainingTime = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets the message.
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Whether the relaxation has ben manually stopped.
        /// </summary>
        public bool IsManuallyStopped { get; private set; }

        #endregion

        #region Methods

        /// <summary>
        /// Initializes commands.
        /// </summary>
        protected override void InitializeCommands()
        {
            StopTimerCommand = new RelayCommand(p => StopTimer(),p => CanStopTimer());
        }

        /// <summary>
        /// Stops the timer.
        /// </summary>
        private void StopTimer()
        {
            _timer.Stop();
            _timer.Tick -= OnTimerTick;
            IsManuallyStopped = _duration * 60 == _counter ? false : true;
            DialogResult = true;
        }


        /// <summary>
        /// Whether the timer can be stopped.
        /// </summary>
        /// <returns></returns>
        private bool CanStopTimer()
        {
            return true;
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
        }

        /// <summary>
        /// Called when timer tick event raises.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTimerTick(object sender,EventArgs e)
        {
            _counter++;
            int seconds = _duration * 60 - _counter;
            RemainingTime = BreakTimerHelper.GetFormattedTimeFromSeconds(seconds);
            if(seconds == 0) {
                StopTimerCommand.Execute(null);
            }
        }

        #endregion

        #region Commands 

        /// <summary>
        /// Gets or sets the stop timer command.
        /// </summary>
        public RelayCommand StopTimerCommand { get; private set; }

        #endregion
    }
}
