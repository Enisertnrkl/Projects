using L.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
       User AuthenticateUser(string username, string password);
    }
}
