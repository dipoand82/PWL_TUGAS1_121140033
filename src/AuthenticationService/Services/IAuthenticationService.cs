using System.Threading.Tasks;

namespace AuthenticationService.Services
{
    public interface IAuthenticationService
    {
        Task<string> Login(string email, string password);
        Task Logout(string token);
    }
}
