using AutoMapper;
using Caro.Controllers;
using Caro.Models;
using Caro.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Caro.Tests.Controllers
{
    [TestClass]
    public class CarsControllerTest
    {
        [TestMethod]
        public void Index()
        {
            var repo = new Mock<ICarRepository>();
            repo.Setup(r => r.GetAllCars("123"))
                .Returns(GetTestCars());

            CarViewModel carViewModel = new CarViewModel();
            var mapper = new Mock<IMapper>();
            mapper.Setup(x => x.Map<CarViewModel>(It.IsAny<Car>()))
                .Returns(carViewModel);

            var user = new Mock<IPrincipal>();


            var controller = new CarsController(repo.Object, mapper.Object);
        }


        private List<Car> GetTestCars()
        {
            var cars = new List<Car>()
                {
                    new Car{ Make="Lexus", ApplicationUserID="123"},
                    new Car{ Make="Toyota", ApplicationUserID="123"},
                    new Car{ Make="Acura", ApplicationUserID="321"}
                };
            return cars;
        }
    }
}
