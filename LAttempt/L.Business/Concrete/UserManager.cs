using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using L.Business.Abstract;
using L.DataAccess.Abstract;
using L.Entities.Concrete;

namespace L.Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }


        public List<User> GetAll()
        {
            return _userDal.GetAll();
        }

        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public User GetSingle(User user)
        {
            return _userDal.GetSingle(user);
        }

        public bool AuthenticateUser(string username, string password)
        {
            return _userDal.AuthenticateUser(username, password);
        }
    }
}
