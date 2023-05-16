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
    public class UserService
    {
        public static bool Create(User obj)
        {
            var res = DataAccessFactory.UserData().Create(obj);
            return res;
        }
        public static bool Update(User obj)
        {
            var res = DataAccessFactory.UserData().Update(obj);
            return res;
        }
        public static List<UserDTO> Get()
        {
            var data = DataAccessFactory.UserData().Read();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<User, UserDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<UserDTO>>(data);
            return mapped;

        }
        public static UserDTO Get(string id)
        {
            var data = DataAccessFactory.UserData().Read(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<User, UserDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<UserDTO>(data);
            return mapped;

        }

        public static bool DeleteUser(string id)
        {
            var res = DataAccessFactory.UserData().Delete(id);
            return res;
        }
    }
}
