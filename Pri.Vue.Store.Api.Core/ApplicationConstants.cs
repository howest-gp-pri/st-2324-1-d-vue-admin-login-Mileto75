using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Vue.Store.Api.Core
{
    public class ApplicationConstants
    {
        public const string DefaultCategoryImageUrl = "images/categories/default.jpg";
        public const string DefaultProductImageUrl = "images/products/default.jpg";
        public const string DefaultUserImageUrl = "images/users/default.png";
        public const string AdminPolicyName = "AdminOnly";
        public const string CustomerRoleName = "Customer";
        public const string AdminRoleName = "Admin";

        public const string ProfileImageClaimTypeName = "profile-image";
    }
}
