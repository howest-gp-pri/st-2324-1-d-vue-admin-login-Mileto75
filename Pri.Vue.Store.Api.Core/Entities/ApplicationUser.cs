using Microsoft.AspNetCore.Identity;

namespace Pri.Vue.Store.Api.Core.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime Birthday { get; set; }
        public string ImageUrl { get; set; }
    }
}
