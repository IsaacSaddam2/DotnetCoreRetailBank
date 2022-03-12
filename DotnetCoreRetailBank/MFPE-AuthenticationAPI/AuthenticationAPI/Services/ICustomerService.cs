using AuthenticationAPI.Models;

namespace AuthenticationAPI.Repository
{
    public interface ICustomerService
    {
        UserResponse CheckUser(UserRequest userRequest);
    }
}