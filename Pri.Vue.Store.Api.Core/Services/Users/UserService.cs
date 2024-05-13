using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Pri.Vue.Store.Api.Core.Entities;
using Pri.Vue.Store.Api.Core.Interfaces.Services;
using Pri.Vue.Store.Api.Core.Models.Results;
using Pri.Vue.Store.Api.Core.Models.Users;
using System.Security.Claims;

namespace Pri.Vue.Store.Api.Core.Services.Users
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IJwtService _jwtService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string _baseAddress;

        public UserService(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IJwtService jwtService,
            IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtService = jwtService;
            _httpContextAccessor = httpContextAccessor;
            _baseAddress = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}";
        }

        public async Task<AuthenticateResultModel> LoginAsync(LoginModel loginModel)
        {
            //check if user exists
            var login = await _signInManager.PasswordSignInAsync(loginModel.Email, loginModel.Password, true, false);
            if (login.Succeeded == false)
            {
                return new AuthenticateResultModel
                {
                    IsSuccess = false,
                    Messages = new List<string> { "Login failed!" }
                };
            }
            var user = await _userManager.FindByEmailAsync(loginModel.Email);
            //user exists => generate token
            //get the claims from database
            var claims = (List<Claim>)await _userManager.GetClaimsAsync(user);
            //add custom claims
            claims.Add(new Claim(ClaimTypes.Name, user.UserName));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
            claims.Add(new Claim(ClaimTypes.DateOfBirth, user.Birthday.ToShortDateString()));
            claims.Add(new Claim(ClaimTypes.Email, user.Email));
            claims.Add(new Claim(ApplicationConstants.ProfileImageClaimTypeName.ToString(), $"{_baseAddress}/{user.ImageUrl}"));
            //generate the token
            var token = _jwtService.GenerateToken(claims);
            //serialize the token
            var serializedToken = _jwtService.SerializeToken(token);
            //return the token
            return new AuthenticateResultModel { IsSuccess = true, Token = serializedToken };
        }

        public async Task<AuthenticateResultModel> RegisterAsync(RegisterModel registerModel)
        {
            //create a user
            var applicationUser = new ApplicationUser
            {
                UserName = registerModel.Email,
                Email = registerModel.Email,
                Birthday = registerModel.Birthday,
            };
            //store in database
            var result = await _userManager.CreateAsync(applicationUser, registerModel.Password);
            if (result.Succeeded == false)
            {
                return new AuthenticateResultModel
                {
                    Messages = new List<string> { "Registration failed!" }
                };
            }
            //get the user and add a claim registration-date
            applicationUser = await _userManager.FindByEmailAsync(registerModel.Email);
            //add claims
            await _userManager.AddClaimAsync(applicationUser, new Claim("registration-date", DateTime.UtcNow.ToString("dd-MM-yyyy")));
            await _userManager.AddClaimAsync(applicationUser, new Claim(ClaimTypes.Role, ApplicationConstants.CustomerRoleName));

            //add default user image to new user and save to database
            applicationUser.ImageUrl = ApplicationConstants.DefaultUserImageUrl;
            await _userManager.UpdateAsync(applicationUser);

            return new AuthenticateResultModel
            {
                IsSuccess = true,
                Messages = new List<string> { "User registered!" }
            };
        }
    }
}
