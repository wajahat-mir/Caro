using AutoMapper;
using Caro.Areas.admin.Repository;
using Caro.Controllers;
using Caro.Models;
using Caro.Profiles;
using Caro.Repository;
using Caro.Services;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Mvc5;

namespace Caro
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            var mapper = MappingProfile.InitializeAutoMapper().CreateMapper();

            container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<ManageController>(new InjectionConstructor());

            container.RegisterInstance<IMapper>(mapper);
            container.RegisterType<ApplicationDbContext>();
            container.RegisterType<ICarRepository, CarRepository>();
            container.RegisterType<IMaintainenceRepository, MaintainenceRepository>();

            container.RegisterType<IScheduleRepository, ScheduleRepository>();
            container.RegisterType<IServiceRepository, ServiceRepository>();

            container.RegisterType<IUserService, UserService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}