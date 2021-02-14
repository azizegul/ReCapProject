using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{

    public class EfCarDal : EfEntityRepositoryBase<Car, CarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarContext context = new CarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.Id
                             join clr in context.Colors on c.ColorId equals clr.Id
                             select new CarDetailDto
                             {
                                 Id = c.Id,
                                 BrandName = b.BrandName,
                                 ColorName = clr.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 CarDescription = c.Description
                             };
                return result.ToList();
            }

        }
    }
}
