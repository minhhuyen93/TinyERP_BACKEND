using System.Threading.Tasks;

namespace TinyERP.Common.Connector
{
    public interface IConnector
    {
        Task<T> Post<T>(string url, object requestObject);
        Task<T> Get<T>(string url);
    }
}
