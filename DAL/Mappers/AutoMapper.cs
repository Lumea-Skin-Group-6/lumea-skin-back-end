using AutoMapper;
using BusinessObject;
using DAL.DTOs.RequestModel;
using DAL.DTOs.ResponseModel;

namespace DAL.Mappers
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            QuestionProfile();
            AnswerProfile();
            SkinTypeProfile();
        }

        private void QuestionProfile()
        {
            CreateMap<QuestionCreateRequest, Question>()
                .ForMember(dest => dest.UpdatedAt,
                    opt => opt.MapFrom(src => DateTime.UtcNow)); // Set UpdatedAt manually
            CreateMap<Question, QuestionResponse>().ReverseMap();
            CreateMap<QuestionUpdateRequest, Question>()
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));
            CreateMap<QuestionResponseWithAnswer, Question>().ReverseMap();
        }

        private void AnswerProfile()
        {
            CreateMap<AnswerCreateRequest, Answer>();
            CreateMap<Answer, AnswerResponse>().ReverseMap();
            CreateMap<AnswerUpdateRequest, Answer>();
        }

        private void SkinTypeProfile()
        {
            CreateMap<SkinType, SkinTypeResponse>().ReverseMap();
        }
    }
}