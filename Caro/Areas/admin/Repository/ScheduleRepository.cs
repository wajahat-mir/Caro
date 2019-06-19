using Caro.Models;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

namespace Caro.Repository
{
    public class ScheduleRepository : IScheduleRepository
    {
        private ApplicationDbContext _db;
        public ScheduleRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public Schedule GetSchedule(string Year, string Make, string Model)
        {
            var carSchedule = _db.Schedules
                            .Include(s => s.services)
                            .Where(schedule => schedule.modelYear == Year
                            && schedule.Make == Make
                            && schedule.Model == Model)
                            .FirstOrDefault();

            return carSchedule;

        }

        public IEnumerable<Schedule> GetAllSchedules()
        {
            return _db.Schedules.ToList();
        }

        public IEnumerable<string> GetAllMakes()
        {
            return _db.Schedules.Select(s => s.Make);
        }

        public Schedule GetSchedule(int? id)
        {
            return _db.Schedules.Find(id);
        }

        public void CreateSchedule(Schedule schedule)
        {
            _db.Schedules.Add(schedule);
            _db.SaveChanges();
            return;
        }

        public void RemoveSchedule(int id)
        {
            Schedule schedule = GetSchedule(id);
            _db.Schedules.Remove(schedule);
            _db.SaveChanges();
            return;
        }
    }

    public interface IScheduleRepository
    {
        Schedule GetSchedule(string Year, string Make, string Model);
        IEnumerable<string> GetAllMakes();
        IEnumerable<Schedule> GetAllSchedules();
        Schedule GetSchedule(int? id);
        void CreateSchedule(Schedule schedule);
        void RemoveSchedule(int id);
    }
}