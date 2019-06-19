using Caro.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Caro.Repository
{
    public class CarRepository : ICarRepository
    {
        private ApplicationDbContext _db;
        public CarRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Car> GetAllCars(string userId)
        {
            return  _db.Cars.Where(x => x.ApplicationUserID == userId).ToList();
        }

        public Car GetCar(int? id)
        {
            return _db.Cars.Find(id);
        }

        public void CreateCar(Car car)
        {
            _db.Cars.Add(car);
            _db.SaveChanges();
            return;
        }

        public void UpdateCar(Car car)
        {
            _db.Entry(car).State = EntityState.Modified;
            _db.SaveChanges();
            return;
        }

        public void RemoveCar(int id)
        {
            Car car = GetCar(id);
            _db.Cars.Remove(car);
            _db.SaveChanges();
            return;
        }
    }

    public interface ICarRepository
    {
        IEnumerable<Car> GetAllCars(string userId);

        Car GetCar(int? id);

        void CreateCar(Car car);

        void UpdateCar(Car car);

        void RemoveCar(int id);
    }
}