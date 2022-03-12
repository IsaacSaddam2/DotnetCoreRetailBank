using AuthenticationAPI.Models;

namespace AuthenticationAPI.Repository
{
    public interface ILoginRepository
    {
        UserResponse Login(UserRequest userRequest);
    }
}