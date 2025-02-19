using DAL.DTOs.RequestModel;
using DAL.DTOs.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IQuestionService
    {
        Task<IEnumerable<QuestionResponse>> GetAllQuestionAsync();
        Task<QuestionResponse?> GetQuestionByIdAsync(int id);
        Task<QuestionResponse?> AddQuestionAsync(QuestionCreateRequest question);
        Task<QuestionResponse?> UpdateQuestionAsync(QuestionUpdateRequest question);
        Task DeleteQuestionAsync(int id);
    }
}
