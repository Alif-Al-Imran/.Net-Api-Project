using BLL.Services;
using FLab.Auth;
using FLab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FLab.Controllers
{
    public class TokenController : ApiController
    {
        [HttpPost]
        [Route("api/login")]
        public HttpResponseMessage Login(LoginModel login)
        {
            try
            {
                var res = AuthService.Authenticate(login.Uname, login.Password);
                if( res != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, res);
                }
                else
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "User not found" });

            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = e.Message });
            }

        }
        [Logged]
        [HttpGet]
        [Route("api/logout")]
        public HttpResponseMessage Logout()
        {
            var token = Request.Headers.Authorization.ToString();
            try
            {
                var res = AuthService.Logout(token);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }

        }
    }
}
