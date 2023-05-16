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
    public class CatagoryController : ApiController
    {
        [HttpGet]
        [Route("api/catagory")]
        public HttpResponseMessage Catagories()
        {
            try
            {
                var data = CatagoryService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
        [HttpPost]
        [Route("api/catagory/create")]
        public HttpResponseMessage Create(Catagory obj)
        {
            try
            {
                var data = CatagoryService.Create(obj);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
        [HttpPost]
        [Route("api/catagory/update")]
        public HttpResponseMessage Update(Catagory obj)
        {
            try
            {
                var data = CatagoryService.Update(obj);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
        [HttpGet]
        [Route("api/catagory/{id}")]
        public HttpResponseMessage Catagory(int id)
        {
            try
            {
                var data = CatagoryService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
        [HttpGet]
        [Route("api/catagory/delete/{id}")]
        public HttpResponseMessage DeleteCatagory(int id)
        {
            var res = CatagoryService.DeleteCatagory(id);
            return Request.CreateResponse(HttpStatusCode.OK, res);

        }
        [HttpGet]
        [Route("api/catagory/{id}/products")]
        public HttpResponseMessage CatPro(int id)
        {
            try
            {
                var data = CatagoryService.GetwithProducts(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
    }
}
