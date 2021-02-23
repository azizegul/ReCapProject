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
    public class UserManager : IUserService
    {
        IUserDal userDal;

        public UserManager(IUserDal userDal)
        {
            this.userDal = userDal;
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User users)
        {
            ValidationTool.Validate(new UserValidator(), users);
            if (users.FistName.Length > 2 && users.LastName.Length > 2 && users.Email != null)
            {
                userDal.Add(users);
                return new SuccessResult();
            }
            else
            {
                return new ErrorResult();
            }
        }

        public IResult Delete(User users)
        {
            userDal.Delete(users);
            return new SuccessResult();

        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(userDal.GetAll());
        }

        public IResult Update(User users)
        {
            userDal.Update(users);
            return new SuccessResult();

        }
    }
}
