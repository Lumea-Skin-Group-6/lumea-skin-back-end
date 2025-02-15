using AutoMapper;
using BusinessObject;
using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.MapAndPaginate
{
    public class AutoMapper : Profile
    {
        public AutoMapper() 
        {
            QuestionProfile();
        }

        private void QuestionProfile()
        {
            CreateMap<Question, QuestionDTO>().ReverseMap();
        }
    }
}
