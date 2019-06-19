using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AutoMapper;
using Caro.Areas.admin.Models;
using Caro.Models;
using Caro.Repository;

namespace Caro.Areas.admin.Controllers
{
    [Authorize(Roles="Admin")]
    public class SchedulesController : Controller
    {
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IMapper _mapper;

        public SchedulesController(IScheduleRepository scheduleRepository, IMapper mapper)
        {
            _scheduleRepository = scheduleRepository;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var carLst = new List<string>();
            var carMakes = _scheduleRepository.GetAllMakes();

            carLst.AddRange(carMakes.Distinct());
            ViewBag.CarMake = new SelectList(carLst);

            var schedules = _scheduleRepository.GetAllSchedules();
            var scheduleViewModel = _mapper.Map<IEnumerable<Schedule>, IEnumerable<ScheduleViewModel>>(schedules);
            return View(scheduleViewModel);
        }

        [HttpPost]
        [OutputCache(Duration = int.MaxValue, VaryByParam ="CarMake")]
        public ActionResult Index(string CarMake)
        {
            var schedules = _scheduleRepository.GetAllSchedules();

            var carLst = new List<string>();
            var carMakes = _scheduleRepository.GetAllMakes();

            carLst.AddRange(carMakes.Distinct());
            ViewBag.CarMake = new SelectList(carLst);

            if (!String.IsNullOrEmpty(CarMake))
            {
                schedules = schedules.Where(s => s.Make.Contains(CarMake));
            }

            var scheduleViewModel = _mapper.Map<IEnumerable<Schedule>, IEnumerable<ScheduleViewModel>>(schedules);
            return View(scheduleViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ScheduleID,modelYear,Make,Model")] ScheduleViewModel scheduleViewModel)
        {
            if (ModelState.IsValid)
            {
                var schedule = _mapper.Map<ScheduleViewModel, Schedule>(scheduleViewModel);
                _scheduleRepository.CreateSchedule(schedule);
                return RedirectToAction("Index");
            }

            return View(scheduleViewModel);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schedule schedule = _scheduleRepository.GetSchedule(id);
            var scheduleViewModel = _mapper.Map<Schedule, ScheduleViewModel>(schedule);
            if (schedule == null)
            {
                return HttpNotFound();
            }
            return View(scheduleViewModel);
        }

        // POST: admin/Schedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _scheduleRepository.RemoveSchedule(id);
            return RedirectToAction("Index");
        }
    }
}
