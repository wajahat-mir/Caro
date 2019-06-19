using AutoMapper;
using Caro.Areas.admin.Models;
using Caro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Caro.Profiles
{
    public static class MappingProfile
    {
        public static MapperConfiguration InitializeAutoMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Car, CarViewModel>();
                cfg.CreateMap<CarViewModel, Car>();
                cfg.CreateMap<Maintainence, MaintainenceViewModel>();
                cfg.CreateMap<MaintainenceViewModel, Maintainence>();
                cfg.CreateMap<Car, DashboardViewModel>();

                cfg.CreateMap<Schedule, ScheduleViewModel>();
                cfg.CreateMap<ScheduleViewModel, Schedule>();
                cfg.CreateMap<Service, ServiceViewModel>();
                cfg.CreateMap<ServiceViewModel, Service>();
            });
            return config;
        }
    }
}