using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Caro.Models;
using Caro.Repository;
using Microsoft.AspNet.Identity;

namespace Caro.Controllers
{
    public class DashboardController : Controller
    {
        private ICarRepository _carRepository;
        private IScheduleRepository _scheduleRepository;
        private IMapper _mapper;
        private readonly IMaintainenceRepository _maintainenceRepository;

        public DashboardController(ICarRepository carRepository, IMapper mapper, IScheduleRepository scheduleRepository,
            IMaintainenceRepository maintainenceRepository)
        {
            _carRepository = carRepository;
            _mapper = mapper;
            _scheduleRepository = scheduleRepository;
            _maintainenceRepository = maintainenceRepository;
        }
        
        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();
            var cars = _carRepository.GetAllCars(userId);
            var dashboardViewModels = _mapper.Map<IEnumerable<Car>, IEnumerable<DashboardViewModel>>(cars);

            UpdateStatus(dashboardViewModels);

            return View(dashboardViewModels);
        }

        [NonAction]
        public void UpdateStatus(IEnumerable<DashboardViewModel> dashboardViewModels)
        {
            foreach(DashboardViewModel car in dashboardViewModels)
            {
                car.Status = FindStatus(car);
            }
        }

        public string FindStatus(DashboardViewModel car)
        {
            string Status = "";

            var currentStatus = _maintainenceRepository.GetAllMaintainence(car.CarId);
            var carSchedule = _scheduleRepository.GetSchedule(car.modelYear, car.Make, car.Model);

            // need to add more detailed logic here
            // for now I have a silly stop gap

            Status = "Maintained";

            return Status;
        }
    }
}
