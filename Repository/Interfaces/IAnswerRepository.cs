using DAL.DTOs.RequestModel;
using DAL.DTOs.ResponseModel;

namespace Repository.Interfaces
{
    public interface IAnswerRepository
    {
        Task<IEnumerable<AnswerResponse>> GetAllAnswersAsync();
        Task<AnswerResponse?> GetAnswerByIdAsync(int answerId);
        Task<AnswerResponse?> AddAnswerAsync(AnswerCreateRequest answer);
        Task<AnswerResponse?> UpdateAnswerAsync(AnswerUpdateRequest answer);
        Task DeleteAnswerAsync(int answerId);
    }

}
