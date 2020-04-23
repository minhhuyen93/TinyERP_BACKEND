using System.Configuration;

namespace TinyERP.Common.Configurations
{
    public class ApplicationConfiguration : ConfigurationSection
    {
        private static ApplicationConfiguration instance;
        public static ApplicationConfiguration Instance
        {
            get
            {
                if (ApplicationConfiguration.instance == null)
                {
                    ApplicationConfiguration.instance = ConfigurationManager.GetSection("appConfig") as ApplicationConfiguration;
                }
                return ApplicationConfiguration.instance;
            }
        }

        [ConfigurationProperty("userManagement")]
        public UserManagement UserManagement
        {
            get
            {
                return (UserManagement)this["userManagement"];
            }
        }

        [ConfigurationCollection(typeof(ConnectionCollection), AddItemName = "add", ClearItemsName = "clear", RemoveItemName = "remove")]
        public ConnectionCollection Connections
        {
            get
            {
                ConnectionCollection connections = (ConnectionCollection)base["connections"];
                return connections;
            }
        }
    }
}
