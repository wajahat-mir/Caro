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

namespace Caro.Controllers
{
    [Authorize]
    public class MaintainencesController : Controller
    {
        private readonly IMaintainenceRepository _maintainenceRepository;
        private readonly IMapper _mapper;

        public MaintainencesController(IMaintainenceRepository maintainenceRepository, IMapper mapper)
        {
            _maintainenceRepository = maintainenceRepository;
            _mapper = mapper;
        }

        // GET: Maintainences
        public ActionResult Index(int id)
        {
            if (id < 1)
                RedirectToAction("Index", "Cars");
            ViewData["carId"] = id;
            IEnumerable<Maintainence> maintainences = _maintainenceRepository.GetAllMaintainence(id);
            var maintainenceViewModels = _mapper.Map<IEnumerable<Maintainence>, IEnumerable<MaintainenceViewModel>>(maintainences);
            return View(maintainenceViewModels);
        }

        // GET: Maintainences/Create
        public ActionResult Create(int id)
        {
            ViewData["carId"] = id.ToString();
            Session["carId"] = id;
            return View();
        }

        // POST: Maintainences/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaintainenceId,dateMaintained,mileageMaintained,service")] MaintainenceViewModel maintainenceViewModel)
        {
            string carId = Session["carId"].ToString();
            if (ModelState.IsValid)
            {
                var maintainence = _mapper.Map<MaintainenceViewModel, Maintainence>(maintainenceViewModel);
                maintainence.CarId = int.Parse(carId);
                _maintainenceRepository.CreateMaintainence(maintainence);

                return RedirectToAction("Index", new { id = carId });
            }
            return View(maintainenceViewModel);
        }

         // GET: Maintainences/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maintainence maintainence = _maintainenceRepository.GetMaintainence(id);
            ViewData["carId"] = maintainence.CarId;
            if (maintainence == null)
            {
                return HttpNotFound();
            }
            var maintainenceViewModel = _mapper.Map<Maintainence, MaintainenceViewModel>(maintainence);
            return View(maintainenceViewModel);
        }

        // POST: Maintainences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Maintainence maintainence = _maintainenceRepository.GetMaintainence(id);
            _maintainenceRepository.RemoveMaintainence(id);
            return RedirectToAction("Index", new { id = maintainence.CarId});
        }
    }
}
