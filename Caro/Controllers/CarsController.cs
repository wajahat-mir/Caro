using System.Collections.Generic;
using System.Net;
using System.Security.Claims;
using System.Web.Mvc;
using AutoMapper;
using Caro.Models;
using Caro.Repository;
using Caro.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Http;

namespace Caro.Controllers
{
    public class CarsController : Controller
    {
        private ICarRepository _carRepository;
        private IMapper _mapper;
        private readonly IUserService _userService;

        public CarsController(ICarRepository carRepository, IMapper mapper, IUserService userService)
        {
            _carRepository = carRepository;
            _mapper = mapper;
            _userService = userService;
        }

        public ActionResult Index()
        {
            string userId = _userService.GetCurrentUserId(User);
            var cars = _carRepository.GetAllCars(userId);
            var carViewModel = _mapper.Map<IEnumerable<Car>, IEnumerable<CarViewModel>>(cars);
            return View(carViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CarId,Plate,modelYear,Make,Model,Color,currentMileage,lastWashed")] CarViewModel carViewModel)
        {
            if (ModelState.IsValid)
            {
                var car = _mapper.Map<CarViewModel, Car>(carViewModel);
                car.ApplicationUserID = User.Identity.GetUserId();
                _carRepository.CreateCar(car);
                return RedirectToAction("Index");
            }

            return View(carViewModel);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = _carRepository.GetCar(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            var carViewModel = _mapper.Map<Car, CarViewModel>(car);
            return View(carViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CarId,Plate,modelYear,Make,Model,Color,currentMileage,lastWashed")] CarViewModel carViewModel)
        {
            if (ModelState.IsValid)
            {
                var car = _mapper.Map<CarViewModel, Car>(carViewModel);
                car.ApplicationUserID = User.Identity.GetUserId();
                _carRepository.UpdateCar(car);
                return RedirectToAction("Index");
            }
            return View(carViewModel);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = _carRepository.GetCar(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _carRepository.RemoveCar(id);
            return RedirectToAction("Index");
        }
    }
}
