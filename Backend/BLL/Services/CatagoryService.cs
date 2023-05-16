using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CatagoryService
    {
        public static bool Create(Catagory obj)
        {
            var res = DataAccessFactory.CatagoryData().Create(obj);
            return res;
        }
        public static bool Update(Catagory obj)
        {
            var res = DataAccessFactory.CatagoryData().Update(obj);
            return res;
        }
        public static List<CatagoryDTO> Get()
        {
            var data = DataAccessFactory.CatagoryData().Read();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Catagory, CatagoryDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<CatagoryDTO>>(data);
            return mapped;

        }
        public static CatagoryDTO Get(int id)
        {
            var data = DataAccessFactory.CatagoryData().Read(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Catagory, CatagoryDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<CatagoryDTO>(data);
            return mapped;

        }
        
        public static bool DeleteCatagory(int id)
        {
            var res = DataAccessFactory.CatagoryData().Delete(id);
            return res;
        }
        public static CatProDTO GetwithProducts(int id)
        {
            var data = DataAccessFactory.CatagoryData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Catagory, CatProDTO>();
                c.CreateMap<Product, ProductDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<CatProDTO>(data);
            return mapped;
        }
    }
}
