using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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

        public void Add(Car car)
        {
            if (car.DailyPrice > 0 && car.Description.Length > 2)
            {
                carDal.Add(car);
                Console.WriteLine("Araba eklenmiştir.");
            }
            else
            {
                Console.WriteLine("Hata var");
            }
        }

        public void Delete(Car car)
        {
            carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return carDal.GetAll();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return carDal.GetCarDetails();
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return carDal.GetAll(b => b.BrandId == brandId);
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return carDal.GetAll(c => c.ColorId == colorId);
        }

        public void Update(Car car)
        {
            carDal.Update(car);
        }
    }
}
