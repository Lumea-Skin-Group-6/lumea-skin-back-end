using AutoMapper;
using AutoMapper.QueryableExtensions;
using BusinessObject;
using DAL.DBContext;
using DAL.DTOs.RequestModel;
using DAL.DTOs.ResponseModel;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<QuestionResponse?> GetQuestionByIdAsync(int id) { 
            return await _context.Questions
                        .ProjectTo<QuestionResponse>(_mapper.ConfigurationProvider)
                        .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<QuestionResponse?> AddQuestionAsync(QuestionCreateRequest question)
        {
            var newQuestion = _mapper.Map<Question>(question);
            await _context.Questions.AddAsync(newQuestion);
            await _context.SaveChangesAsync();
            return _mapper.Map<QuestionResponse>(newQuestion);
        }


        public async Task<QuestionResponse?> UpdateQuestionAsync(QuestionUpdateRequest question)
        {
            var existingQuestion = await _context.Questions.FirstOrDefaultAsync(x => x.Id == question.Id);
            if (existingQuestion == null)
            {
                throw new InvalidOperationException("Question not found.");
            }

            // Use AutoMapper to update the existing entity without replacing it
            _mapper.Map(question, existingQuestion);

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
    }
}

