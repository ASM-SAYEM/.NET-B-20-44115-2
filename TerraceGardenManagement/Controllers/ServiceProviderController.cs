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
    public class ServiceProviderController : ApiController
    {
        [HttpGet]
        [Route("api/ServiceProvider/all")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = ServiceProviderService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);

            }
        }

        [HttpGet]
        [Route("api/ServiceProvider/{id:int}")]
        public HttpResponseMessage GetServiceProvider(int id)
        {
            try
            {
                var data = ServiceProviderService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);



            }
        }


        [HttpPost]
        [Route("api/ServiceProvider/add")]
        public HttpResponseMessage AddServiceProvider(ServiceProviderDTO serviceProvider)
        {
            try
            {
                var res = ServiceProviderService.Create(serviceProvider);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }



        [HttpPost]
        [Route("api/ServiceProvider/update")]
        public HttpResponseMessage UpdateFeedback(ServiceProviderDTO serviceProvider)
        {
            try
            {
                var res = ServiceProviderService.Update(serviceProvider);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }




        [HttpDelete]
        [Route("api/ServiceProvider/delete/{id:int}")]
        public HttpResponseMessage DeleteServiceProvider(int id)
        {
            try
            {
                var res = ServiceProviderService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }

        }

        //For notifications....................
        [HttpPost]
        [Route("api/ServiceProvider/SendNotification")]
        public HttpResponseMessage SendNotification(NotificationDTO notification)
        {
            try
            {
                var res = NotificationService.SendNotification(notification.ServiceProviderName, notification.Message, notification.SentByAdminUserName);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
