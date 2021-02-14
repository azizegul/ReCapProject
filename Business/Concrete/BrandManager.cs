using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            this.brandDal = brandDal;
        }

        public void Add(Brand brand)
        {
            brandDal.Add(brand);
        }

        public void Delete(Brand brand)
        {
            brandDal.Delete(brand);
        }

        public List<Brand> GetAll()
        {
            return brandDal.GetAll();
        }

        public Brand GetById(int brandId)
        {
            return brandDal.Get(b => b.Id == brandId);
        }

        public void Update(Brand brand)
        {
            brandDal.Update(brand);
        }
    }
}
