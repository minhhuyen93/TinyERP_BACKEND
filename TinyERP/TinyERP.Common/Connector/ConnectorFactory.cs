using TinyERP.Common.Enums;

namespace TinyERP.Common.Connector
{
    public class ConnectorFactory
    {
        public static IConnector Create(ConnectorType type)
        {
            switch (type)
            {
                case ConnectorType.Json:
                default:
                    return new JSonConnector();
            }
        }
    }
}
