using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id=1, BrandId=1, ColorId=1, DailyPrice=65000, ModelYear=2010, Description="CLIO"},
                new Car{Id=2, BrandId=2, ColorId=1, DailyPrice=180000, ModelYear=2015, Description="OPEL CORSA"},
                new Car{Id=3, BrandId=2, ColorId=2, DailyPrice=147000, ModelYear=2015, Description="OPEL ASTRA"},
                new Car{Id=4, BrandId=3, ColorId=3, DailyPrice=200000, ModelYear=2019, Description="BMW"},
                new Car{Id=5, BrandId=3, ColorId=2, DailyPrice=98000, ModelYear=2009, Description="CIVIC"},
                new Car{Id=6, BrandId=3, ColorId=1, DailyPrice=150000, ModelYear=2014, Description="MİCRA."}

            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(k => k.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(k => k.Id == id).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(k => k.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
        }
    }
}
