using AutoMapper;
using BAL.DTOs;
using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BAL.Services
{
    public class AdminService
    {
        public static List<AdminDTO> Get()
        {
            var data = DataAccessFactory.AdminData().Get();
            var cfg = new MapperConfiguration(c =>
            {
                //c.CreateMap<ClientDTO, Client>();
                c.CreateMap<Admin, AdminDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<AdminDTO>>(data);
            return mapped;
        }

        public static AdminDTO Get(string UserName)
        {
            var data = DataAccessFactory.ClientData().Get(UserName);

            var cfg = new MapperConfiguration(c =>
            {
                //c.CreateMap<ClientDTO, Client>();
                c.CreateMap<Admin, AdminDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<AdminDTO>(data);
            return mapped;
        }

        public static Admin Create(AdminDTO admin)
        {


            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<AdminDTO, Admin>();

            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Admin>(admin);
            var data = DataAccessFactory.AdminData().Add(mapped);

            return data;

        }

        public static Admin Update(AdminDTO admin)
        {


            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<AdminDTO, Admin>();

            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Admin>(admin);
            var data = DataAccessFactory.AdminData().Update(mapped);

            return data;

        }

        public static bool Delete(string UserName)
        {
            var data = DataAccessFactory.AdminData().Delete(UserName);

            return data;

        }


        //For notification...........................................
        public static NotificationDTO SendNotification(string serviceProviderName, string message)
        {
            // Create a new notification
            var notification = new Notification
            {
                ServiceProviderName = serviceProviderName,
                Message = message,
                DateSent = DateTime.Now
            };

            // Save the notification in the database
            var addedNotification = DataAccessFactory.NotificationData().Add(notification);

            // Map the added notification to a DTO and return
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Notification, NotificationDTO>();
            });

            var mapper = new Mapper(cfg);
            var mappedNotification = mapper.Map<NotificationDTO>(addedNotification);

            return mappedNotification;
        }

    }
}