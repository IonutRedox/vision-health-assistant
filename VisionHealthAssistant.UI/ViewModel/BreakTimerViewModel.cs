using System;
using System.Windows.Threading;
using VisionHealthAssistant.Shared;
using VisionHealthAssistant.UI.Helper;
using VisionHealthAssistant.UI.Model;
using VisionHealthAssistant.UI.View;

namespace VisionHealthAssistant.UI.ViewModel
{
    public class BreakTimerViewModel : ViewModelBase
    {
        #region Fields 

        private DispatcherTimer _timer;
        private int _counter;
        private string _remainingTime;
        private bool _isNotRunning;
        private bool _isPaused;

        #endregion

        #region Constructor

        /// <summary>
        /// Parameterless constructor for break timer.
        /// </summary>
        public BreakTimerViewModel()
        {
            Type = Pages.BreakTimer;
            InitializeCommands();
            InitializeTimer();
            BreakTimer = new BreakTimer { Frequency = 0,Length = 0,IdleResetTime = 0 };
            RemainingTime = BreakTimerHelper.GetFormattedTimeFromMinutes(BreakTimer.Frequency);
            IsNotRunning = true;
        }

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


        /// <summary>
        /// Determines whether the timer is running.
        /// </summary>
        public bool IsNotRunning
        {
            get { return _isNotRunning; }
            set {
                if(_isNotRunning != value) {
                    _isNotRunning = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the remaining time until the next break.
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

        /// <summary>
        /// Start timer command.
        /// </summary>
        public RelayCommand StartTimerCommand { get; private set; }

        /// <summary>
        /// Stop timer command.
        /// </summary>
        public RelayCommand StopTimerCommand { get; private set; }

        /// <summary>
        /// Pause timer command.
        /// </summary>
        public RelayCommand PauseTimerCommand { get; private set; }


        #endregion

        #region Methods

        /// <summary>
        /// Initializes commands
        /// </summary>
        protected override void InitializeCommands()
        {
            StartTimerCommand = new RelayCommand(p => StartTimer(),p => CanStartTimer());
            StopTimerCommand = new RelayCommand(p => StopTimer(),p => CanStopTimer());
            PauseTimerCommand = new RelayCommand(p => PauseTimer(),p => CanPauseTimer());

            IncreaseFrequencyCommand = new RelayCommand(p => {
                BreakTimer.Frequency++;
                RemainingTime = BreakTimerHelper.GetFormattedTimeFromMinutes(BreakTimer.Frequency);
            },p => IsNotRunning);

            IncreaseLengthCommand = new RelayCommand(p => {
                BreakTimer.Length++;
            },p => IsNotRunning);

            IncreaseIdleResetTimeCommand = new RelayCommand(p => {
                BreakTimer.IdleResetTime++;
            },p => IsNotRunning);

            DecreaseFrequencyCommand = new RelayCommand(p => {
                BreakTimer.Frequency--;
                RemainingTime = BreakTimerHelper.GetFormattedTimeFromMinutes(BreakTimer.Frequency);
            },p => BreakTimer.Frequency > 0 && IsNotRunning);

            DecreaseLengthCommand = new RelayCommand(p => {
                BreakTimer.Length--;
            },p => BreakTimer.Length > 0 && IsNotRunning);

            DecreaseIdleResetTimeCommand = new RelayCommand(p => {
                BreakTimer.IdleResetTime--;
            },p => BreakTimer.IdleResetTime > 0 && IsNotRunning);
        }

        /// <summary>
        /// Timer tick event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTimerTick(object sender,EventArgs e)
        {
            _counter++;
            int seconds = BreakTimer.Frequency * 60 - _counter;
            RemainingTime = BreakTimerHelper.GetFormattedTimeFromSeconds(seconds);
            if(seconds == 0) {
                _counter = 0;
                StopTimerCommand.Execute(null);
                StartRelaxation();
            }
        }

        /// <summary>
        /// Starts timer.
        /// </summary>
        private void StartTimer()
        {
            _timer.Start();
            IsNotRunning = false;
            _isPaused = false;
        }

        /// <summary>
        /// Determines whether the timer can be started.
        /// </summary>
        private bool CanStartTimer()
        {
            return IsNotRunning && BreakTimer.Frequency > 0 && BreakTimer.Length > 0 && !string.IsNullOrWhiteSpace(BreakTimer.Message) && (!BreakTimer.IsIdleResetActive || BreakTimer.IsIdleResetActive && BreakTimer.IdleResetTime > 0);
        }

        /// <summary>
        /// Stop the timer.
        /// </summary>
        private void StopTimer()
        {
            _timer.Stop();
            RemainingTime = BreakTimerHelper.GetFormattedTimeFromMinutes(BreakTimer.Frequency);
            _counter = 0;
            IsNotRunning = true;
            _isPaused = false;
        }

        /// <summary>
        /// Whether the timer can be stopped.
        /// </summary>
        /// <returns></returns>
        private bool CanStopTimer()
        {
            return _timer.IsEnabled || _isPaused;
        }

        /// <summary>
        /// Pause the timer.
        /// </summary>
        private void PauseTimer()
        {
            _timer.Stop();
            _isPaused = true;
            IsNotRunning = true;
        }


        /// <summary>
        /// Whether the timer can be paused.
        /// </summary>
        /// <returns></returns>
        private bool CanPauseTimer()
        {
            return _timer.IsEnabled;
        }

        /// <summary>
        /// Initializes the timer.
        /// </summary>
        private void InitializeTimer()
        {
            _timer = new DispatcherTimer();
            _timer.Tick += OnTimerTick;
            _timer.Interval = new TimeSpan(0,0,1);
        }

        /// <summary>
        /// Start the relaxation.
        /// </summary>
        private void StartRelaxation()
        {
            RelaxationViewModel relaxationViewModel = new RelaxationViewModel(BreakTimer.Message,BreakTimer.Length);
            RelaxationView relaxationView = new RelaxationView { DataContext = relaxationViewModel };
            if(relaxationView.ShowDialog() == true && !relaxationViewModel.IsManuallyStopped) {
                StartTimer();
            }
        }


        #endregion

    }
}