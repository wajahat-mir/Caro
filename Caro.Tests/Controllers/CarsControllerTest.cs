using AutoMapper;
using Caro.Controllers;
using Caro.Models;
using Caro.Profiles;
using Caro.Repository;
using Caro.Services;
using Caro.Tests.Services;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web.Mvc;
using Xunit;

namespace Caro.Tests.Controllers
{
    public class CarsControllerTest
    {
        private static IMapper mapper = MappingProfile.InitializeAutoMapper().CreateMapper();

        [Fact]
        public void Index()
        {
            var repo = MockReposService.BuildMockCarRepo().AddFunction("GetAllCars");
            var userServiceMock = MockUserService.BuildMockUser().AddFunction("GetCurrentUserId");
            
            var controller = new CarsController(repo.Object, mapper, userServiceMock.Object);
            var result = controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<CarViewModel>>(viewResult.ViewData.Model);
            Assert.Equal(3, model.Count());
        }


        
    }
}
