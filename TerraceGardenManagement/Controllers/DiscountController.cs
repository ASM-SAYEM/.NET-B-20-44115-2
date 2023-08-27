using BAL.DTOs;
using BAL.Services;
using Microsoft.AspNetCore.Cors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TerraceGardenManagement.AuthFilters;

namespace TerraceGardenManagement.Controllers
{

    [EnableCors("*")]
    [AdminAccess]
    public class DiscountController : ApiController
    {

        [HttpGet]
        [Route("api/Discount/All")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = DiscountService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);

            }
        }

        [HttpGet]
        [Route("api/Discount/{id:int}")]
        public HttpResponseMessage GetDiscount(int id)
        {
            try
            {
                var data = DiscountService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);



            }
        }

        [HttpGet]
        [Route("api/Discount/{percentage:double}")]
        public HttpResponseMessage GetPercentage(double percentage)
        {
            try
            {
                var data = DiscountService.Get(Convert.ToInt32(percentage));
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);



            }
        }


        [HttpPost]
        [Route("api/Discount/add")]
        public HttpResponseMessage AddDiscount(DiscountDTO ds)
        {
            try
            {
                var res = DiscountService.Create(ds);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }



        [HttpPost]
        [Route("api/Discount/update")]
        public HttpResponseMessage UpdateDiscount(DiscountDTO ds)
        {
            try
            {
                var res = DiscountService.Update(ds);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }




        [HttpDelete]
        [Route("api/Discount/delete/{id:int}")]
        public HttpResponseMessage DeleteDiscount(int id)
        {
            try
            {
                var res = DiscountService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }



        }
    }
}