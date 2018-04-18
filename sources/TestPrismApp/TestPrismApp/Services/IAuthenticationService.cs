using System.Threading.Tasks;

namespace TestPrismApp.Services
{
    public interface IAuthenticationService
    {
        bool IsAuthenticated { get; }
        string LoggedUser { get; }

        Task<bool> LoginAsync(string username);
    }
}
