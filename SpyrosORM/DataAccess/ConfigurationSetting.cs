using System.Configuration;

namespace SpyrosORM.DataAccess
{
    public class ConfigurationSetting
    {
        /// <summary>
        /// 
        /// </summary>
        public Configuration DllConfig { get;  }
        /// <summary>
        /// 
        /// </summary>
        public ConfigurationSetting()
        {
            DllConfig = ConfigurationManager.OpenExeConfiguration(this.GetType().Assembly.Location);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sectionName"></param>
        /// <returns></returns>
        public AppSettingsSection LoadConfigsSection(string sectionName)
        {
            return (AppSettingsSection)DllConfig.GetSection(sectionName);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sectionName"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetConfigValue(string sectionName, string key)
        {
            return LoadConfigsSection(sectionName).Settings[key].Value;
        }

    }
}