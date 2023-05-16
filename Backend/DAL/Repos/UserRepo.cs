using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Model;

namespace DAL.Repos
{
    internal class UserRepo : Repo, IRepo<User, string, bool>, IAuth<bool>
    {
        public bool Authenticate(string username, string password)
        {
            var data = db.Users.FirstOrDefault(u => u.id.Equals(username) &&
            u.Password.Equals(password));
            if(data != null) return true;
            return false;
        }
        public bool Create(User obj)
        {
            db.Users.Add(obj);
            return (db.SaveChanges() > 0);
        }

        public bool Delete(string id)
        {
            var excat = db.Users.Find(id);
            db.Users.Remove(excat);
            return (db.SaveChanges() > 0);
        }

        public List<User> Read()
        {
            return db.Users.ToList();
        }

        public User Read(string id)
        {
            return db.Users.Find(id);
        }

        public bool Update(User obj)
        {
            var excat = db.Users.Find(obj.id);
            db.Entry(excat).CurrentValues.SetValues(obj);
            return (db.SaveChanges() > 0);
        }
    }
}
