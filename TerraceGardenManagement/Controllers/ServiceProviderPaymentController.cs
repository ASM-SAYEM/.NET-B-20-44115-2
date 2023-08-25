using BAL.DTOs;
using BAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TerraceGardenManagement.Controllers
{
    public class ServiceProviderPaymentController : ApiController
    {

        [HttpGet]
        [Route("api/ServiceProviderPayment/All")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = ServiceProviderPaymentService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);

            }
        }

        [HttpGet]
        [Route("api/ServiceProviderPayment/{id:int}")]
        public HttpResponseMessage GetPayment(int id)
        {
            try
            {
                var data = ServiceProviderPaymentService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);



            }
        }



        [HttpPost]
        [Route("api/ServiceProviderPayment/add")]
        public HttpResponseMessage AddPayment(ServiceProviderPaymentDTO sp)
        {
            try
            {
                var res = ServiceProviderPaymentService.Add(sp);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        //

        [HttpPost]
        [Route("api/ServiceProviderPayment/addWithNotification")]
        public HttpResponseMessage AddPaymentTo(ServiceProviderPaymentDTO sp)
        {
            try
            {
                var res = ServiceProviderPaymentService.AddPaymentTo(sp);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        //


        [HttpPost]
        [Route("api/ServiceProviderPayment/update")]
        public HttpResponseMessage UpdatePayment(ServiceProviderPaymentDTO sp)
        {
            try
            {
                var res = ServiceProviderPaymentService.Update(sp);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }




        [HttpDelete]
        [Route("api/ServiceProviderPayment/delete/{id:int}")]
        public HttpResponseMessage DeletePayment(int id)
        {
            try
            {
                var res = ServiceProviderPaymentService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }



        }


        //[HttpPost]
        //[Route("api/ServiceProviderPayment/AddPayment")]
        //public HttpResponseMessage AddPaymentTo(ServiceProviderPaymentDTO payment)
        //{
        //    try
        //    {
        //        var res = ServiceProviderPaymentService.AddPaymentTo(payment);
        //        return Request.CreateResponse(HttpStatusCode.OK, res);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
        //    }
        //}
    }
}
