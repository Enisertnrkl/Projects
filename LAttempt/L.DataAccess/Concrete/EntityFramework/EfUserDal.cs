using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using L.DataAccess.Abstract;
using L.Entities.Concrete;

namespace L.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal: IUserDal
    {
        private EfLContext _context = new EfLContext();
        public List<User> GetAll()
        {
                return _context.Users.ToList();
        }

        public User GetSingle(User user)
        {
                return _context.Users.FirstOrDefault(user);
        }

        public void Add(User user)
        {
                _context.Users.Add(user);
                _context.SaveChanges();
        }

        public void Update(User user)
        {
                _context.Users.Update(user);
                _context.SaveChanges();
        }

        public void Delete(User user)
        {
                _context.Users.Remove(user);
                _context.SaveChanges();
        }

        public bool AuthenticateUser(string username, string password)
        {
            var userExists = _context.Users.SingleOrDefault(u => u.UserName == username && u.Password == password);
            return userExists != null;
        }
    }
}
