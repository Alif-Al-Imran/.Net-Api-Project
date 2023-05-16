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
    public class ProductController : ApiController
    {
        [HttpGet]
        [Route("api/product")]
        public HttpResponseMessage Products()
        {
            try
            {
                var data = ProductService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
        [HttpPost]
        [Route("api/product/create")]
        public HttpResponseMessage Create(Product obj)
        {
            try
            {
                var data = ProductService.Create(obj);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
        [HttpPost]
        [Route("api/product/update")]
        public HttpResponseMessage Update(Product obj)
        {
            try
            {
                var data = ProductService.Update(obj);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
        [HttpGet]
        [Route("api/product/{id}")]
        public HttpResponseMessage Product(int id)
        {
            try
            {
                var data = ProductService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
        [HttpGet]
        [Route("api/product/delete/{id}")]
        public HttpResponseMessage DeleteProduct(int id)
        {
            var res = ProductService.DeleteProduct(id);
            return Request.CreateResponse(HttpStatusCode.OK, res);

        }
    }
}
