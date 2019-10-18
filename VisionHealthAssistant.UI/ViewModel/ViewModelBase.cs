using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using VisionHealthAssistant.Shared;

namespace VisionHealthAssistant.UI.ViewModel
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        #region Properties

        /// <summary>
        /// Gets the type of the page.
        /// </summary>
        public Pages Type { get; protected set; }

        #endregion

        #region Methods

        /// <summary>
        /// Initializes commands.
        /// </summary>
        protected abstract void InitializeCommands();

        /// <summary>
        /// Attaches to events.
        /// </summary>
        protected virtual void AttachEvents()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes all attached events.
        /// </summary>
        protected virtual void RemoveEvents()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Notify changes

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(name));
        }

        #endregion
    }
}