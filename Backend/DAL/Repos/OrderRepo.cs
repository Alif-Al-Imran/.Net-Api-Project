using DAL.Interfaces;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class OrderRepo : Repo, IRepo<Order, int, bool>
    {
        public bool Create(Order obj)
        {
            db.Orders.Add(obj);
            return (db.SaveChanges() > 0);
        }

        public bool Delete(int id)
        {
            var exorder = db.Orders.Find(id);
            db.Orders.Remove(exorder);
            return (db.SaveChanges() > 0);
        }

        public List<Order> Read()
        {
            return db.Orders.ToList();
        }

        public Order Read(int id)
        {
            return db.Orders.Find(id);
        }

        public bool Update(Order obj)
        {
            var excat = db.Orders.Find(obj.Id);
            db.Entry(excat).CurrentValues.SetValues(obj);
            return (db.SaveChanges() > 0);
        }
    }
}
