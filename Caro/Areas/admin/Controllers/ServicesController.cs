using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Caro.Areas.admin.Models;
using Caro.Areas.admin.Repository;
using Caro.Models;

namespace Caro.Areas.admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ServicesController : Controller
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IMapper _mapper;

        public ServicesController(IServiceRepository serviceRepository, IMapper mapper)
        {
            _serviceRepository = serviceRepository;
            _mapper = mapper;
        }

        public ActionResult Index(int id)
        {
            if (id < 1)
                RedirectToAction("Index", "Schedules");
            ViewData["scheduleId"] = id;

            var services = _serviceRepository.GetAllServices(id);
            var servicesViewModel = _mapper.Map<IEnumerable<Service>, IEnumerable<ServiceViewModel>>(services);
            return View(servicesViewModel);
        }

        public ActionResult Create(int id)
        {
            ViewData["scheduleId"] = id.ToString();
            Session["scheduleId"] = id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ServiceId,perMileage,service")] ServiceViewModel serviceViewModel)
        {
            string scheduleId = Session["scheduleId"].ToString();
            if (ModelState.IsValid)
            {
                var service = _mapper.Map<ServiceViewModel,Service>(serviceViewModel);
                service.ScheduleID = int.Parse(scheduleId);
                _serviceRepository.CreateService(service);
                return RedirectToAction("Index", new { id = scheduleId });
            }
            return View(serviceViewModel);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = _serviceRepository.FindService(id);
            var serviceViewModel = _mapper.Map<Service, ServiceViewModel>(service);

            ViewData["scheduleId"] = service.ScheduleID;
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(serviceViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Service service = _serviceRepository.FindService(id);
            _serviceRepository.RemoveService(id);
            return RedirectToAction("Index", new { id = service.ScheduleID });
        }
    }
}
