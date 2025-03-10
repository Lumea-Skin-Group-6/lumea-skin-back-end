using DAL.DTOs.RequestModel;
using DAL.DTOs.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IAnswerService
    {
        Task<IEnumerable<AnswerResponse>> GetAllAnswersAsync();
        Task<AnswerResponse?> GetAnswerByIdAsync(int answerId);
        Task<AnswerResponse?> AddAnswerAsync(AnswerCreateRequest answer);
        Task<AnswerResponse?> UpdateAnswerAsync(AnswerUpdateRequest answer);
        Task DeleteAnswerAsync(int answerId);
    }

}
