using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Windows.Forms;

namespace VisionHealthAssistant.UI.Managers
{
    /// <summary>
    ///     User configuration manager
    /// </summary>
    public static class UserConfigurationManager
    {
        #region Fields

        private static readonly string _configurationFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),Shared.SharedSettings.AppName);
        private static readonly string _configurationFile = "VHA_config.json";
        private static readonly string _configurationFilePath = Path.Combine(_configurationFolderPath,_configurationFile);

        #endregion

        #region Methods

        /// <summary>
        ///     Saves user configuration to disk.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public static void Save<T>(T entity)
        {
            string key = entity.GetType().Name;
            JToken value = JToken.FromObject(entity);
            JObject serializedEntity = new JObject(new JProperty(key,value));

            if(!File.Exists(_configurationFilePath)) {
                File.WriteAllText(_configurationFilePath,serializedEntity.ToString());
                return;
            }

            string entityName = typeof(T).Name;
            string jsonContent = File.ReadAllText(_configurationFilePath);

            JObject root = JObject.Parse(jsonContent);
            JObject node = (JObject)root[entityName];

            if(node == null) {
                root.Add(key,value);
            } else {
                root[entityName] = value;
            }
            File.WriteAllText(_configurationFilePath,root.ToString());
        }

        /// <summary>
        ///     Loads user configuration from disk.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Load<T>()
        {
            if(!Directory.Exists(_configurationFolderPath)) {
                Directory.CreateDirectory(_configurationFolderPath);
                return default;
            }

            T entity;
            string entityName = typeof(T).Name;
            string jsonContent = File.ReadAllText(_configurationFilePath);
            JObject root = JObject.Parse(jsonContent);
            entity = root[entityName].ToObject<T>();

            return entity;
        }

        #endregion
    }
}
