using Caro.Models;
using Caro.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caro.Tests.Services
{
    static class MockReposService
    {
        public static Mock<ICarRepository> BuildMockCarRepo()
        {
            return new Mock<ICarRepository>(); ;
        }

        public static Mock<ICarRepository> AddFunction(this Mock<ICarRepository> repo, string functionName)
        {
            switch (functionName)
            {
                case "GetAllCars":
                    repo.Setup(r => r.GetAllCars(It.IsAny<string>())).Returns(GetTestCars());
                    break;
                default:
                    break;
            }

            return repo;
        }

        private static List<Car> GetTestCars()
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
