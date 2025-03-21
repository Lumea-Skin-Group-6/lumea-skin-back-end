using AutoMapper;
using AutoMapper.QueryableExtensions;
using BusinessObject;
using DAL.DBContext;
using DAL.DTOs.RequestModel;
using DAL.DTOs.ResponseModel;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;


namespace Repository.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public QuestionRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<QuestionResponse>> GetAllQuestionAsync()
        {
            return await _context.Questions
                .ProjectTo<QuestionResponse>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<QuestionResponseWithAnswer?> GetQuestionByIdAsync(int id)
        {
            return await _context.Questions
                .ProjectTo<QuestionResponseWithAnswer>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<QuestionResponse?> AddQuestionAsync(QuestionCreateRequest question)
        {
            var newQuestion = _mapper.Map<Question>(question);
            if (question.AnswerIds != null && question.AnswerIds.Any())
            {
                var answers = await _context.Answers.Where(a => question.AnswerIds.Contains(a.Id)).ToListAsync();
                foreach (var answer in answers)
                {
                    answer.question_id = newQuestion.Id;
                    answer.question = newQuestion;
                }
                newQuestion.Answers = answers;
            }
            await _context.Questions.AddAsync(newQuestion);
            await _context.SaveChangesAsync();
            return _mapper.Map<QuestionResponse>(newQuestion);
        }


        public async Task<QuestionResponse?> UpdateQuestionAsync(QuestionUpdateRequest question)
        {
            var existingQuestion = await _context.Questions
                .Include(q => q.Answers)
                .FirstOrDefaultAsync(x => x.Id == question.Id);

            if (existingQuestion == null)
            {
                return null;
            }

            // Use AutoMapper to update the existing entity without replacing it
            _mapper.Map(question, existingQuestion);

            if (question.AnswerIds != null)
            {
                // Fetch new answers
                var newAnswers = await _context.Answers
                    .Where(a => question.AnswerIds.Contains(a.Id))
                    .ToListAsync();

                // Remove answers not in the updated list
                var answersToRemove = existingQuestion.Answers
                    .Where(a => !question.AnswerIds.Contains(a.Id))
                    .ToList();

                foreach (var answer in answersToRemove)
                {
                    answer.question_id = null; // Remove the relationship
                    answer.question = null;
                }

                // Assign new answers
                foreach (var answer in newAnswers)
                {
                    answer.question_id = existingQuestion.Id;
                    answer.question = existingQuestion;
                }

                existingQuestion.Answers = newAnswers;
            }
            else
            {
                foreach (var answer in existingQuestion.Answers)
                {
                    answer.question_id = null;
                    answer.question = null;
                }
                existingQuestion.Answers.Clear();
            }

            await _context.SaveChangesAsync();
            return _mapper.Map<QuestionResponse>(existingQuestion);
        }

        public async Task DeleteQuestionAsync(int id)
        {
            var existingQuestion = _context.Questions.FirstOrDefault(x => x.Id == id);
            if (existingQuestion == null)
            {
                throw new InvalidOperationException("Question not found.");
            }
            
            _context.Questions.Remove(existingQuestion);
            await _context.SaveChangesAsync();
        }

        public async Task<SkinAnalysisResultResponse?> AnalyzeSkinTypeAsync(List<int> answerIds)
        {
            var answers = await _context.Answers
                .Where(a => answerIds.Contains(a.Id))
                .ToListAsync();

            if (!answers.Any())
            {
                throw new Exception("No valid answers found.");
            }

            int totalDry = answers.Sum(a => a.DryPoint);
            int totalOily = answers.Sum(a => a.OilyPoint);
            int totalSensitive = answers.Sum(a => a.SensitivePoint);

            var skinType = await _context.SkinTypes
                .FirstOrDefaultAsync(st => totalDry >= st.MinDry && totalDry <= st.MaxDry
                                        && totalOily >= st.MinOily && totalOily <= st.MaxOily
                                        && totalSensitive >= st.MinSensitive && totalSensitive <= st.MaxSensitive);

            if (skinType == null)
            {
                return null;
            }

            var recommendedServices = await _context.Services
                .Where(s => s.SkinTypeServices.Any(st => st.SkinType.Id == skinType.Id))
                .ToListAsync();

            return new SkinAnalysisResultResponse
            {
                SkinType = skinType.Name,
                Description = skinType.Description,
                RecommendedServices = _mapper.Map<List<ServiceResponseModel>>(recommendedServices)
            };
        }

        public async Task<IEnumerable<QuestionResponseWithAnswer>> GetAllQuestionsWithAnswersAsync()
        {
            var questions = await _context.Questions
                .Where(q => q.Active)
                .Include(q => q.Answers) // Ensure answers are loaded
                .ToListAsync();

            return _mapper.Map<List<QuestionResponseWithAnswer>>(questions);
        }
    }
}