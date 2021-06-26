
using Audiology.Domain.DTO;
using System.Threading.Tasks;

namespace Audiology.Domain
{
    public interface IAccountService
    {
        UserType IsValidUser(UserDto userDto);
    }
}
