using TinyERP.UserManagement.Share.Dtos;

namespace TinyERP.UserManagement.Services
{
    public interface IUserService
    {
        int CreateAuthor(AuthorDto request);
        AuthorInfo GetAuthorInfo(int id);
    }
}
