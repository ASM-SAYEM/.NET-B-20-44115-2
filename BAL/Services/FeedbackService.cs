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
    public class FeedbackService
    {
        public static List<FeedbackDTO> Get()
        {
            var data = DataAccessFactory.FeedbackData().Get();
            var cfg = new MapperConfiguration(c =>
            {

                c.CreateMap<Feedback, FeedbackDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<FeedbackDTO>>(data);
            return mapped;
        }

        public static FeedbackDTO Get(int id)
        {
            var data = DataAccessFactory.FeedbackData().Get();

            var cfg = new MapperConfiguration(c => {
                //c.CreateMap<FeedbackDTO, Feedback>();
                c.CreateMap<Feedback, FeedbackDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<FeedbackDTO>(data);
            return mapped;
        }

        public static Feedback Add(FeedbackDTO feedback)
        {


            var cfg = new MapperConfiguration(c => {
                c.CreateMap<FeedbackDTO, Feedback>();

            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Feedback>(feedback);
            var data = DataAccessFactory.FeedbackData().Add(mapped);

            return data;

        }

        public static Feedback Update(FeedbackDTO feedback)
        {


            var cfg = new MapperConfiguration(c => {
                c.CreateMap<FeedbackDTO, Feedback>();

            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Feedback>(feedback);
            var data = DataAccessFactory.FeedbackData().Update(mapped);

            return data;

        }

        public static bool Delete(int id)
        {
            var data = DataAccessFactory.FeedbackData().Delete(id);

            return data;

        }
    }
}