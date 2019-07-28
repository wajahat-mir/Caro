using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace Caro.Services
{
    public interface IUserService
    {
        string GetCurrentUserId(IPrincipal User);
    }

    public class UserService : IUserService
    {
        public string GetCurrentUserId(IPrincipal User)
        {
            return User.Identity.GetUserId();
        }
    }
}