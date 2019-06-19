using Caro.Areas.admin.Models;
using Caro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Caro.Areas.admin.Repository
{
    public class ServiceRepository : IServiceRepository
    {
        private ApplicationDbContext _db;
        public ServiceRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Service> GetAllServices(int id)
        {
            var services = _db.Services.Where(s => s.ScheduleID == id).ToList();
            return services;
        }

        public Service FindService(int? id)
        {
            return _db.Services.Find(id);
        }

        public void CreateService(Service service)
        {
            _db.Services.Add(service);
            _db.SaveChanges();
        }

        public void RemoveService(int id)
        {
            Service service = _db.Services.Find(id);
            _db.Services.Remove(service);
            _db.SaveChanges();
        }
    }

    public interface IServiceRepository
    {
        IEnumerable<Service> GetAllServices(int id);
        Service FindService(int? id);
        void CreateService(Service service);
        void RemoveService(int id);
    }
}