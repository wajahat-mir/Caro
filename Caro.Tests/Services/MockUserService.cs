using Caro.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Caro.Tests.Services
{
    public static class MockUserService
    {
        public static Mock<IUserService> BuildMockUser()
        {
            return new Mock<IUserService>();
        }

        public static Mock<IUserService> AddFunction(this Mock<IUserService> user, string functionName)
        {
            switch (functionName)
            {
                case "GetCurrentUserId":
                    user.Setup(u => u.GetCurrentUserId(It.IsAny<IPrincipal>())).Returns(It.IsAny<string>);
                    break;
                default:
                    break;
            }

            return user;
        }
    }
}
