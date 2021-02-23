using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingCorners.Validation;
using Core.Utilities;
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

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
           
            brandDal.Add(brand);
            return new ErrorResult(Messages.CarNameInvalid);
        }

        public IResult Delete(Brand brand)
        {
            brandDal.Delete(brand);
            return new ErrorResult(Messages.CarDeleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(brandDal.GetAll());
        }

        public IDataResult<Brand> GetById(int brandId)
        {
            return new SuccessDataResult<Brand>(brandDal.Get(b => b.Id == brandId));
        }

        public IResult Update(Brand brand)
        {
            brandDal.Update(brand);
            return new ErrorResult(Messages.CarUpdated);
        }
    }
}
