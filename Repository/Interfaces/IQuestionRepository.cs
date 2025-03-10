using BusinessObject;
using DAL.DTOs.RequestModel;
using DAL.DTOs.ResponseModel;

namespace Repository.Interfaces
{
    public interface IQuestionRepository
    {
        Task<IEnumerable<QuestionResponse>> GetAllQuestionAsync();
        Task<QuestionResponse?> GetQuestionByIdAsync(int id);
        Task<QuestionResponse?> AddQuestionAsync(QuestionCreateRequest question); 
        Task<QuestionResponse?> UpdateQuestionAsync(QuestionUpdateRequest question); 
        Task DeleteQuestionAsync(int id);
        Task<SkinAnalysisResultResponse> AnalyzeSkinTypeAsync(List<int> answerIds);
        Task<IEnumerable<QuestionResponseWithAnswer>> GetAllQuestionsWithAnswersAsync();
    }
}
