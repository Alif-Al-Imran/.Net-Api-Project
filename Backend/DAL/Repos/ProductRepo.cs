using DAL.Interfaces;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class ProductRepo : Repo, IRepo<Product, int, bool>
    {
        public bool Create(Product obj)
        {
            db.Products.Add(obj);
            return (db.SaveChanges() > 0);
        }

        public bool Delete(int id)
        {
            var excat = db.Products.Find(id);
            db.Products.Remove(excat);
            return (db.SaveChanges() > 0);
        }

        public List<Product> Read()
        {
            return db.Products.ToList();
        }

        public Product Read(int id)
        {
            return db.Products.Find(id);
        }

        public bool Update(Product obj)
        {
            var excat = db.Products.Find(obj.Id);
            db.Entry(excat).CurrentValues.SetValues(obj);
            return (db.SaveChanges() > 0);
        }
    }
}
