using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal carDal;

        public CarManager(ICarDal carDal)
        {
            this.carDal = carDal;
        }
        public List<Car> GetAll()
        {
            return carDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return carDal.GetAll(k => k.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return carDal.GetAll(k => k.ColorId == id);
        }

        public void Add(Car car)
        {
            if (car.Description.Length <= 2)
            {
                Console.WriteLine("Araba ismi minimum 2 karakter olmalıdır");
                return;
            }
            if (car.DailyPrice <= 0)
            {
                Console.WriteLine("Araba günlük fiyatı 0'dan büyük olmalıdır");
                return;
            }

            carDal.Add(car);
        }
    }
}
