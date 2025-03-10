using AutoMapper;
using BusinessObject;
using DAL.DBContext;
using DAL.DTOs.RequestModel;
using DAL.DTOs.ResponseModel;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;


namespace Repository.Repositories
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public AnswerRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AnswerResponse>> GetAllAnswersAsync()
        {
            return await _context.Answers
                .Select(t => new AnswerResponse
                { 
                    Id = t.Id, 
                    Content = t.content,
                    DryPoint = t.DryPoint,
                    OilyPoint = t.OilyPoint,
                    SensitivePoint = t.SensitivePoint
                })
                .ToListAsync();
        }

        public async Task<AnswerResponse?> GetAnswerByIdAsync(int answerId)
        {
            var answer = await _context.Answers.FindAsync(answerId);
            return answer != null ?
            new AnswerResponse
            {
                Id = answer.Id,
                Content = answer.content,
                DryPoint = answer.DryPoint,
                OilyPoint = answer.OilyPoint,
                SensitivePoint = answer.SensitivePoint
            } : null;
        }

        public async Task<AnswerResponse?> AddAnswerAsync(AnswerCreateRequest answer)
        {
            var newAnswer = new Answer
            {
                content = answer.Content,
                DryPoint = answer.DryPoint,
                OilyPoint = answer.OilyPoint,
                SensitivePoint = answer.SensitivePoint
            };
            await _context.Answers.AddAsync(newAnswer);
            await _context.SaveChangesAsync();
            return _mapper.Map<AnswerResponse>(newAnswer);
        }

        public async Task<AnswerResponse?> UpdateAnswerAsync(AnswerUpdateRequest answer)
        {
            var existingAnswer = await _context.Answers.FindAsync(answer.Id);
            if (existingAnswer != null)
            {
                existingAnswer.content = answer.Content;
                existingAnswer.DryPoint = answer.DryPoint;
                existingAnswer.SensitivePoint = answer.SensitivePoint;
                existingAnswer.OilyPoint = answer.OilyPoint;
                await _context.SaveChangesAsync();
                return _mapper.Map<AnswerResponse>(existingAnswer);
            }
            return null;
        }

        public async Task DeleteAnswerAsync(int answerId)
        {
            var answer = await _context.Answers.FindAsync(answerId);
            if (answer != null)
            {
                if (answer.question_id != null)
                {
                    throw new Exception("There have been questions related to this answer!");
                }
                _context.Answers.Remove(answer);
                await _context.SaveChangesAsync();
            }
            throw new Exception("Answer not found!");
        }
    }
}