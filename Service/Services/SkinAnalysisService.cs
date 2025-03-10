using DAL.DTOs.ResponseModel;
using Repository.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class SkinAnalysisService : ISkinAnalysisService
    {
        private readonly IQuestionRepository _questionRepository;

        public SkinAnalysisService(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }
        public async Task<SkinAnalysisResultResponse> AnalyzeSkinTypeAsync(List<int> answerIds)
        {
            return await _questionRepository.AnalyzeSkinTypeAsync(answerIds);
        }
    }
}
