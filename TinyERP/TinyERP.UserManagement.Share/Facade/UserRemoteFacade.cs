using System.Threading.Tasks;
using TinyERP.Common.Configurations;
using TinyERP.Common.Connector;
using TinyERP.Common.Enums;
using TinyERP.UserManagement.Share.Dtos;

namespace TinyERP.UserManagement.Share.Facade
{
    internal class UserRemoteFacade : IUserFacade
    {
        public async Task<int> CreateAuthor(AuthorDto request)
        {
            IConnector connector = ConnectorFactory.Create(ConnectorType.Json);
            string url = $"{ApplicationConfiguration.Instance.UserManagement.EndPoint.Url}/api/users";
            return await connector.Post<int>(url, request);
        }

        public async Task<AuthorInfo> GetAuthorInfo(int id)
        {
            IConnector connector = ConnectorFactory.Create(ConnectorType.Json);
            string url = $"{ApplicationConfiguration.Instance.UserManagement.EndPoint.Url}/api/users/{id}/authorInfo";
            return await connector.Get<AuthorInfo>(url);
        }
    }
}
