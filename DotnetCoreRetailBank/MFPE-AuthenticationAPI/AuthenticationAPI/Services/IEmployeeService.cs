using AuthenticationAPI.Models;

namespace AuthenticationAPI.Repository
{
    public interface IEmployeeService
    {
        UserResponse CheckUser(UserRequest userRequest);
    }
}