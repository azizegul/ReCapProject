using Business.Abstract;
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

        public IResult Add(User users)
        {
            if (users.FistName.Length > 2 && users.LastName.Length > 2 && users.Email != null)
            {
                userDal.Add(users);
                return new SuccessResult();
            }
            else
            {
                return new ErrorResult(Messages.NameInValid);
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
