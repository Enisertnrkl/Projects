using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using L.Entities.Concrete;

namespace L.Business.Abstract
{
    public interface IUserService
    {
        List<User> GetAll();
        void Add(User user);
        User GetSingle(User user);
        bool AuthenticateUser(string username, string password);
    }
}
