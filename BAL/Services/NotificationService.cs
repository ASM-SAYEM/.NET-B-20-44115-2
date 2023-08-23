using AutoMapper;
using BAL.DTOs;
using DAL;
using DAL.EF;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BAL.Services
{
    public class NotificationService
    {

        public static NotificationDTO SendNotification(string serviceProviderName, string message, string adminUserName)
        {
            var notification = new Notification
            {
                ServiceProviderName = serviceProviderName,
                Message = message,
                DateSent = DateTime.Now,
                SentByAdminUserName = adminUserName
            };

            var addedNotification = DataAccessFactory.NotificationData().Add(notification);

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Notification, NotificationDTO>();
            });

            var mapper = new Mapper(cfg);
            var mappedNotification = mapper.Map<NotificationDTO>(addedNotification);

            return mappedNotification;
        }


        public static List<NotificationDTO> Get()
        {
            var data = DataAccessFactory.NotificationData().Get();
            var cfg = new MapperConfiguration(c =>
            {

                c.CreateMap<Notification, NotificationDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<NotificationDTO>>(data);
            return mapped;
        }

        public static NotificationDTO Get(int id)
        {
            var data = DataAccessFactory.NotificationData().Get();

            var cfg = new MapperConfiguration(c => {
                //c.CreateMap<FeedbackDTO, Feedback>();
                c.CreateMap<Notification, NotificationDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<NotificationDTO>(data);
            return mapped;
        }


    }
}