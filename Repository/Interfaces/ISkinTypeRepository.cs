using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface ISkinTypeRepository
    {
        Task<IEnumerable<SkinType>> GetAllAsync();
        Task<IEnumerable<SkinType>> GetByIdsAsync(List<int> ids);
        Task<SkinType?> GetByIdAsync(int id);
        Task<SkinType?> AddAsync(SkinType skinType);
        Task<SkinType?> UpdateAsync(SkinType skinType);
        Task DeleteAsync(int id);
    }

}
