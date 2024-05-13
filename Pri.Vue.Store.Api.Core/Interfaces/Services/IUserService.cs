using Pri.Vue.Store.Api.Core.Models.Results;
using Pri.Vue.Store.Api.Core.Models.Users;

namespace Pri.Vue.Store.Api.Core.Interfaces.Services
{
    public interface IUserService
    {
        Task<AuthenticateResultModel> RegisterAsync(RegisterModel registerModel);
        Task<AuthenticateResultModel> LoginAsync(LoginModel loginModel);
    }
}
