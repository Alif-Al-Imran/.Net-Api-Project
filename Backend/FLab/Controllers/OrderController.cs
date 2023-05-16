using BLL.Services;
using DAL.Model;
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
    public class OrderController : ApiController
    {
        [HttpGet]
        [Route("api/orders")]
        public HttpResponseMessage Orders()
        {
            try
            {
                var data = OrderService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = e.Message });
            }
        }
        [HttpPost]
        [Route("api/order/create")]
        public HttpResponseMessage Create(Order obj)
        {
            try
            {
                var data = OrderService.Create(obj);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
        [HttpPost]
        [Route("api/order/update")]
        public HttpResponseMessage Update(Order obj)
        {
            try
            {
                var data = OrderService.Update(obj);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
        [HttpGet]
        [Route("api/order/{id}")]
        public HttpResponseMessage Order(int id)
        {
            try
            {
                var data = OrderService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
        [HttpGet]
        [Route("api/order/delete/{id}")]
        public HttpResponseMessage DeleteOrder(int id)
        {
            var res = OrderService.DeleteOrder(id);
            return Request.CreateResponse(HttpStatusCode.OK, res);

        }
    }
}

