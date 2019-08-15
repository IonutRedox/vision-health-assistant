using System.ComponentModel;
using System.Runtime.CompilerServices;
using VisionHealthAssistant.Shared;

namespace UIVisionHealthAssistant.ViewModel
{
    public class ViewModelBase: INotifyPropertyChanged
    {
        #region Properties

        /// <summary>
        /// Gets the type of the page.
        /// </summary>
        public PageType Type { get; protected set; }

        #endregion

        #region Notify changes

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name="") {
            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(name));
        }

        #endregion
    }
}