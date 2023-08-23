using AutoMapper;
using BAL.DTOs;
using DAL.EF.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BAL.Services
{
    public class DiscountService
    {
        public static List<DiscountDTO> Get()
        {
            var data = DataAccessFactory.DiscountData().Get();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Discount, DiscountDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<DiscountDTO>>(data);
            return mapped;
        }

        public static DiscountDTO Get(int id)
        {
            var data = DataAccessFactory.DiscountData().Get(id);

            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Discount, DiscountDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<DiscountDTO>(data);
            return mapped;
        }

        //
        public static DiscountDTO GetPercentage(double percentage)
        {
            var data = DataAccessFactory.DiscountData().GetPercentage(percentage);

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Discount, DiscountDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<DiscountDTO>(data);
            return mapped;
        }

        public static Discount Create(DiscountDTO discount)
        {


            var cfg = new MapperConfiguration(c => {
                c.CreateMap<DiscountDTO, Discount>();

            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Discount>(discount);
            var data = DataAccessFactory.DiscountData().Add(mapped);

            return data;

        }

        public static Discount Update(DiscountDTO discount)
        {


            var cfg = new MapperConfiguration(c => {
                c.CreateMap<DiscountDTO, Discount>();

            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Discount>(discount);
            var data = DataAccessFactory.DiscountData().Update(mapped);

            return data;

        }

        public static bool Delete(int id)
        {
            var data = DataAccessFactory.DiscountData().Delete(id);

            return data;

        }

        public double CalculateDiscount(double baseprice, string UserName)
        {
            string Type = ClientService.GetType(UserName);
            // ClientService.GetType(UserName);

            if (Type == "Regular")
            {
                return baseprice - (baseprice * 0.1);//10
            }
            else if (Type == "Membership")
            {
                return baseprice - (baseprice * 0.2);//30
            }
            else if (Type == "VIP")
            {
                return baseprice * (1 - (10 / 200));//40
            }
            else
            {
                // Default discount for other client types
                return 10000 * (1 - (10 / 300));
            }
        }
    }
}