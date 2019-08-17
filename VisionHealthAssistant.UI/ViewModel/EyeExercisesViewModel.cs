using VisionHealthAssistant.Shared;

namespace VisionHealthAssistant.UI.ViewModel
{
    public class EyeExercisesViewModel : ViewModelBase
    {
        #region Constructor

        public EyeExercisesViewModel()
        {
            Type = Pages.EyeExercises;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Initializes commands.
        /// </summary>
        protected override void InitializeCommands()
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
