using DAL.DTOs.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ISkinAnalysisService
    {
        Task<SkinAnalysisResultResponse?> AnalyzeSkinTypeAsync(List<int> answerIds);
    }
}
