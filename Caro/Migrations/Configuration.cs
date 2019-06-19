namespace Caro.Migrations
{
    using Caro.Areas.admin.Models;
    using Caro.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Caro.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Caro.Models.ApplicationDbContext context)
        {
            if(context.Schedules.Count() == 0)
            {
                context.Schedules.AddOrUpdate<Schedule>(new Schedule()
                {
                    modelYear = "2015",
                    Make = "Lexus",
                    Model = "IS",
                    services = new List<Service>()
                {
                    new Service(){ perMileage = 8000, service = Maintain.OilChange},
                    new Service(){ perMileage = 25000, service = Maintain.YearlyMaintainence},
                    new Service(){ perMileage = 100000, service = Maintain.Transmission},
                    new Service(){ perMileage = 50000, service = Maintain.Brakes}
                }
                });

                context.Schedules.AddOrUpdate<Schedule>(new Schedule()
                {
                    modelYear = "2010",
                    Make = "Toyota",
                    Model = "Camry",
                    services = new List<Service>()
                {
                    new Service(){ perMileage = 8000, service = Maintain.OilChange},
                    new Service(){ perMileage = 25000, service = Maintain.YearlyMaintainence},
                    new Service(){ perMileage = 100000, service = Maintain.Transmission},
                    new Service(){ perMileage = 50000, service = Maintain.Brakes}
                }
                });
            }
        }
    }
}
