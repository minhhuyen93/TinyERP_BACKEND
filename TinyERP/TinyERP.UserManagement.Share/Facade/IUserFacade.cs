using System.Threading.Tasks;
using TinyERP.UserManagement.Share.Dtos;

namespace TinyERP.UserManagement.Share.Facade
{
    public interface IUserFacade
    {
        Task<int> CreateAuthor(AuthorDto request);
        Task<AuthorInfo> GetAuthorInfo(int id);
    }
}
