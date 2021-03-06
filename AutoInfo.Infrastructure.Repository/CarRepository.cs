﻿using AutoInfo.Domain.Core.Entities;
using AutoInfo.Services.EFContext;
using AutoInfo.Services.Repository;
using System.Collections.Generic;

namespace AutoInfo.Infrastructure.Repository
{
    public class CarRepository : ICarRepository
    {
        private IEFDbContext db;

        public CarRepository(IEFDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<Car> GetAll()
        {
            return db.Cars;
        }

        public Car Get(int id)
        {
            return db.Cars.Find(id);
        }

        //с методом Save запутался, поэтому указал его и здесь
        public void Create(Car car)
        {
            db.Cars.Add(car);
            db.Save();
        }

        public void Update(Car car)
        {
            db.Update(car);
            db.Save();
        }

        public void Delete(int id)
        {
            Car car = db.Cars.Find(id);
            if (car != null)
            {
                db.Cars.Remove(car);
                db.Save();
            }


        }
    }
}
