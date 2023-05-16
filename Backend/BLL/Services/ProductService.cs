using AutoMapper;
using BLL.DTOs;
using DAL.Model;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ProductService
    {
        public static bool Create(Product obj)
        {
            var res = DataAccessFactory.ProductData().Create(obj);
            return res;
        }
        public static bool Update(Product obj)
        {
            var res = DataAccessFactory.ProductData().Update(obj);
            return res;
        }
        public static List<ProductDTO> Get()
        {
            var data = DataAccessFactory.ProductData().Read();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Product, ProductDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<ProductDTO>>(data);
            return mapped;

        }
        public static ProductDTO Get(int id)
        {
            var data = DataAccessFactory.ProductData().Read(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Product, ProductDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<ProductDTO>(data);
            return mapped;

        }

        public static bool DeleteProduct(int id)
        {
            var res = DataAccessFactory.ProductData().Delete(id);
            return res;
        }
        
    }
}
