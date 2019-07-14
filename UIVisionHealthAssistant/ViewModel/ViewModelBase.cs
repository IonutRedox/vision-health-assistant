using System.ComponentModel;

namespace UIVisionHealthAssistant.ViewModel
{
    public class ViewModelBase: INotifyPropertyChanged
    {
        #region Notify changes

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) {
            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(name));
        }

        #endregion
    }
}