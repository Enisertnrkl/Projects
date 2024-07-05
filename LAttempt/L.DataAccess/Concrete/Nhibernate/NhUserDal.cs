using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using L.DataAccess.Abstract;
using L.Entities.Concrete;

namespace L.DataAccess.Concrete.NHibernate
{
    internal class NhUserDal : IUserDal
    {
        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetSingle(User user)
        {
            throw new NotImplementedException();
        }

        public bool AuthenticateUser(string username, string password)
        {
            throw new NotImplementedException();
        }

        public void Add(User user)
        {
            throw new NotImplementedException();
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }

        public void Delete(User user)
        {
            throw new NotImplementedException();
        }
    }
}
