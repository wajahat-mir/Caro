using Caro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Caro.Repository
{
    public class MaintainenceRepository : IMaintainenceRepository
    {
        private ApplicationDbContext _db;
        public MaintainenceRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Maintainence> GetAllMaintainence(int carId)
        {
            return _db.Maintainences.Where(x => x.CarId == carId).ToList();
        }

        public Maintainence GetMaintainence (int? id)
        {
            return _db.Maintainences.Find(id);
        }

        public void CreateMaintainence(Maintainence maintainence)
        {
            _db.Maintainences.Add(maintainence);
            _db.SaveChanges();
            return;
        }

        public void RemoveMaintainence(int id)
        {
            Maintainence maintainence = GetMaintainence(id);
            _db.Maintainences.Remove(maintainence);
            _db.SaveChanges();
            return;
        }
    }

    public interface IMaintainenceRepository
    {
        IEnumerable<Maintainence> GetAllMaintainence(int carId);
        Maintainence GetMaintainence(int? id);
        void CreateMaintainence(Maintainence maintainence);
        void RemoveMaintainence(int id);
    }
}