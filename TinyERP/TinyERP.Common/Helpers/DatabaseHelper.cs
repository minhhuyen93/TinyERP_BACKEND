using TinyERP.Common.Configurations;
using TinyERP.Common.Exceptions;

namespace TinyERP.Common.Helpers
{
    public class DatabaseHelper
    {
        public static string GetConnection<TContext>()
        {
            string connectionString = string.Empty;
            ConnectionElement connectionElement = ApplicationConfiguration.Instance.Connections[typeof(TContext).FullName];
            if (connectionElement == null)
            {
                throw new NotFoundException("Can not found connection configuration");
            }
            connectionString = $"Data Source={connectionElement.Server}; Initial Catalog={connectionElement.DatabaseName}; User Id={connectionElement.User}; password={connectionElement.Password}";
            return connectionString;
        }
    }
}
