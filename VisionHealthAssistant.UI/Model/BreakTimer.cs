using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace VisionHealthAssistant.UI.Model
{
    public class BreakTimer : INotifyPropertyChanged
    {
        #region Fields

        private int _frequency;
        private int _length;
        private int _idleResetTime;
        private string _message;
        private bool _isPlaySoundActive;
        private bool _isIdleResetActive;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets break frequency
        /// </summary>
        public int Frequency
        {
            get { return _frequency; }
            set {
                if ( _frequency != value ) {
                    _frequency = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets break length
        /// </summary>
        public int Length
        {
            get { return _length; }
            set {
                if ( _length != value ) {
                    _length = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets idle reset time
        /// </summary>
        public int IdleResetTime
        {
            get { return _idleResetTime; }
            set {
                if ( _idleResetTime != value ) {
                    _idleResetTime = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets break message
        /// </summary>
        public string Message
        {
            get { return _message; }
            set {
                if ( _message != value ) {
                    _message = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets break sound play state
        /// </summary>
        public bool IsPlaySoundActive
        {
            get { return _isPlaySoundActive; }
            set {
                if ( _isPlaySoundActive != value ) {
                    _isPlaySoundActive = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets break idle reset state
        /// </summary>
        public bool IsIdleResetActive
        {
            get { return _isIdleResetActive; }
            set {
                if ( _isIdleResetActive != value ) {
                    _isIdleResetActive = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(name));
        }

        #endregion
    }
}
