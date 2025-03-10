using DAL.DTOs.RequestModel;
using DAL.DTOs.ResponseModel;
using Repository.Interfaces;
using Service.Interfaces;


namespace Service.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionService(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task<QuestionResponse?> AddQuestionAsync(QuestionCreateRequest question)
        {
            return await _questionRepository.AddQuestionAsync(question);
        }

        public async Task DeleteQuestionAsync(int id)
        {
            await _questionRepository.DeleteQuestionAsync(id);
        }

        public async Task<IEnumerable<QuestionResponse>> GetAllQuestionAsync()
        {
            return await _questionRepository.GetAllQuestionAsync();
        }

        public async Task<IEnumerable<QuestionResponseWithAnswer>> GetAllQuestionsWithAnswersAsync()
        {
            return await _questionRepository.GetAllQuestionsWithAnswersAsync();
        }

        public async Task<QuestionResponse?> GetQuestionByIdAsync(int id)
        {
            return await _questionRepository.GetQuestionByIdAsync(id);
        }

        public async Task<QuestionResponse?> UpdateQuestionAsync(QuestionUpdateRequest question)
        {
            return await _questionRepository.UpdateQuestionAsync(question);
        }
    }
}
