using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingCorners.Validation;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            this.rentalDal = rentalDal;
        }

        public IResult Add(Rental rentals)
        {
            ValidationTool.Validate(new RentalValidator(), rentals);
            if (rentals.RentDate != null && rentals.ReturnDate != null)
            {
                rentalDal.Add(rentals);
                return new SuccessResult();
            }
            else
            {
                return new ErrorResult();
            }
        }

        public IResult Delete(Rental rentals)
        {
            rentalDal.Delete(rentals);
            return new SuccessResult();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(rentalDal.Get(r => r.Id == rentalId));
        }

        public IDataResult<Rental> GetCarByCustomerId(int customerId)
        {
            return new SuccessDataResult<Rental>(rentalDal.Get(r => r.CustomerId == customerId));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(rentalDal.GetRentalDetails());
        }

        public IDataResult<Rental> GetRentalsByCarId(int carId)
        {
            return new SuccessDataResult<Rental>(rentalDal.Get(r => r.CarId == carId));
        }

        public IResult Update(Rental rentals)
        {
            rentalDal.Update(rentals);
            return new SuccessResult();
        }
    }
}
