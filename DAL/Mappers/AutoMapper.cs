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
            ServiceProfile();
            ExpertiseProfile();
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

        private void ServiceProfile()
        {
            CreateMap<ServiceModel, ServiceResponseModel>()
               .ForMember(dest => dest.SkinTypeServices, opt => opt.MapFrom(src => src.SkinTypeServices.Select(sts => sts.SkinType)))
               .ForMember(dest => dest.ServiceExpertises, opt => opt.MapFrom(src => src.ServiceExpertises.Select(se => se.Expertise)))
               .ReverseMap();
            CreateMap<ServiceModel, AddServiceRequestModel>().ReverseMap();
            CreateMap<ServiceModel, UpdateServiceRequestModel>().ReverseMap();
        }

        private void ExpertiseProfile()
        {
            CreateMap<Expertise, ExpertiseResponseModel>().ReverseMap();
        }
    }
}