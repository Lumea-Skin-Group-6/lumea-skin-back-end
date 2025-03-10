using DAL.DTOs.RequestModel;
using DAL.DTOs.ResponseModel;
using Repository.Interfaces;
using Service.Interfaces;

namespace Service.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly IAnswerRepository _answerRepository;

        public AnswerService(IAnswerRepository answerRepository)
        {
            _answerRepository = answerRepository;
        }

        public async Task<AnswerResponse?> AddAnswerAsync(AnswerCreateRequest answer)
        {
            return await _answerRepository.AddAnswerAsync(answer);
        }

        public async Task DeleteAnswerAsync(int answerId)
        {
            await _answerRepository.DeleteAnswerAsync(answerId);
        }

        public async Task<IEnumerable<AnswerResponse>> GetAllAnswersAsync()
        {
            return await _answerRepository.GetAllAnswersAsync();
        }

        public async Task<AnswerResponse?> GetAnswerByIdAsync(int answerId)
        {
            return await _answerRepository.GetAnswerByIdAsync(answerId);
        }

        public async Task<AnswerResponse?> UpdateAnswerAsync(AnswerUpdateRequest answer)
        {
            return await _answerRepository.UpdateAnswerAsync(answer);
        }
    }
}