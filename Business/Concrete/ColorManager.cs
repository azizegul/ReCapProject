using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingCorners.Validation;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal colorDal;

        public ColorManager(IColorDal colorDal)
        {
            this.colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            ValidationTool.Validate(new ColorValidator(), color);
            colorDal.Add(color);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Color color)
        {
            colorDal.Delete(color);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(colorDal.GetAll(), Messages.CarListed);
        }

        public IDataResult<Color> GetById(int colorId)
        {
            return new SuccessDataResult<Color>(colorDal.Get(c => c.Id == colorId));
        }

        public IResult Update(Color color)
        {
            colorDal.Update(color);
            return new SuccessResult(Messages.CarUpdated);
        }
    }
}
