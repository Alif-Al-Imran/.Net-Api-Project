using BLL.Services;
using DAL.Model;
using FLab.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace FLab.Controllers
{
    [EnableCors("*", "*", "*")]
    public class UserController : ApiController
    {
        [HttpGet]
        [Route("api/user")]
        public HttpResponseMessage Users()
        {
            try
            {
                var data = UserService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
        [HttpPost]
        [Route("api/user/create")]
        public HttpResponseMessage Create(User obj)
        {
            try
            {
                var data = UserService.Create(obj);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
        [HttpPost]
        [Route("api/user/update")]
        public HttpResponseMessage Update(User obj)
        {
            try
            {
                var data = UserService.Update(obj);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
        [HttpGet]
        [Route("api/user/{id}")]
        public HttpResponseMessage UserGet(string id)
        {
            try
            {
                var data = UserService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
        [Logged]
        [HttpGet]
        [Route("api/user/delete/{id}")]
        public HttpResponseMessage UserCatagory(string id)
        {
            var res = UserService.DeleteUser(id);
            return Request.CreateResponse(HttpStatusCode.OK, res);

        }
    }
}
