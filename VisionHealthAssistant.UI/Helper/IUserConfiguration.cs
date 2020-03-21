
namespace VisionHealthAssistant.UI.Helper
{
    /// <summary>
    ///     User configuration interface
    /// </summary>
    public interface IUserConfiguration
    {
        /// <summary>
        ///     Saves user configuration to disk.
        /// </summary>
        void SaveUserConfiguration();

        /// <summary>
        ///     Loads user configuration from disk.
        /// </summary>
        void LoadUserConfiguration();
    }
}
