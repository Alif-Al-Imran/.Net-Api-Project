using DAL.Interfaces;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class CatagoryRepo:Repo, IRepo<Catagory, int, bool>
    {
        public bool Create(Catagory obj)
        {
            db.Catagories.Add(obj);
            return (db.SaveChanges() > 0);
        }

        public bool Delete(int id)
        {
            var excat=db.Catagories.Find(id);
            db.Catagories.Remove(excat);
            return (db.SaveChanges() > 0);
        }

        public List<Catagory> Read()
        {
            return db.Catagories.ToList();
        }

        public Catagory Read(int id)
        {
            return db.Catagories.Find(id);
        }

        public bool Update(Catagory obj)
        {
            var excat = db.Catagories.Find(obj.Id);
            db.Entry(excat).CurrentValues.SetValues(obj);
            return (db.SaveChanges() > 0);
        }
    }
}
