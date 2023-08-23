using BAL.DTOs;
using BAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TerraceGardenManagement.AuthFilters;

namespace TerraceGardenManagement.Controllers
{
    public class AdminController : ApiController
    {
        [Logged]
        [HttpGet]
        [Route("api/Admin/All")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = AdminService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);

            }
        }

        [HttpGet]
        [Route("api/Admin/UserName/{UserName}")]
        public HttpResponseMessage GetM(string UserName)
        {
            try
            {
                var data = AdminService.Get(UserName);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);



            }
        }



        [HttpPost]
        [Route("api/Admin/add")]
        public HttpResponseMessage AddMembers(AdminDTO sp)
        {
            try
            {
                var res = AdminService.Create(sp);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }



        [HttpPost]
        [Route("api/Admin/update")]
        public HttpResponseMessage Update(AdminDTO sp)
        {
            try
            {
                var res = AdminService.Update(sp);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }




        [HttpDelete]
        [Route("api/Admin/delete/{uname}")]
        public HttpResponseMessage DeleteAdmin(string uname)
        {
            try
            {
                var res = AdminService.Delete(uname);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }

        }


        //For Notifications.............................

        [HttpPost]
        [Route("api/Admin/SendNotification")]
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
