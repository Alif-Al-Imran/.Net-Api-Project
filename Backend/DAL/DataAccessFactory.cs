using DAL.Interfaces;
using DAL.Model;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<User, string, bool> UserData()
        {
            return new UserRepo();
        }
        public static IRepo<Order, int, bool> OrderData()
        {
            return new OrderRepo();
        }
        public static IRepo<Product, int, bool> ProductData()
        {
            return new ProductRepo();
        }
        public static IRepo<Catagory, int, bool> CatagoryData()
        {
            return new CatagoryRepo();
        }
        public static IAuth<bool> AuthData()
        {
            return new UserRepo();
        }
        public static IRepo<Token, string, Token> TokenData()
        {
            return new TokenRepo();
        }
    }
}
