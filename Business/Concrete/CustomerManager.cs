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
    public class CustomerManager : ICustomerService
    {
        ICustomerDal customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            this.customerDal = customerDal;
        }

        public IResult Add(Customer customers)
        {
            ValidationTool.Validate(new CustomerValidator(), customers);
            customerDal.Add(customers);
            return new SuccessResult(Messages.CustomerAdded);
        }

        public IResult Delete(Customer customers)
        {
            customerDal.Delete(customers);
            return new SuccessResult(Messages.CustomerDeleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(customerDal.GetAll());
        }

        public IDataResult<List<CustomerDetailDto>> GetCustomerDetails()
        {
            return new SuccessDataResult<List<CustomerDetailDto>>(customerDal.GetCustomerDetails());
        }

        public IResult Update(Customer customers)
        {
            customerDal.Delete(customers);
            return new SuccessResult(Messages.CustomerUpdated);
        }
    }
}
