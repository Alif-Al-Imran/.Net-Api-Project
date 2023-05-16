using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Model;

namespace BLL.Services
{
    public class OrderService
    {
        public static List<OrderDTO> Get()
        {
            var data = DataAccessFactory.OrderData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Order, OrderDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<OrderDTO>>(data);
            return mapped;
        }

        public static OrderDTO Get(int id)
        {
            var data = DataAccessFactory.OrderData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Order, OrderDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<OrderDTO>(data);
            return mapped;
        }
        public static bool Create(Order obj)
        {
            var res = DataAccessFactory.OrderData().Create(obj);
            return res;
        }
        public static bool Update(Order obj)
        {
            var res = DataAccessFactory.OrderData().Update(obj);
            return res;
        }
        public static bool DeleteOrder(int id)
        {
            var res = DataAccessFactory.OrderData().Delete(id);
            return res;
        }
    }
}
