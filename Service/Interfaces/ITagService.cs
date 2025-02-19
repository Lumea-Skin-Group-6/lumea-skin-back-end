using DAL.DTOs.RequestModel;
using DAL.DTOs.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ITagService
    {
        Task<IEnumerable<TagResponse>> GetAllTagsAsync();
        Task<TagResponse> GetTagByIdAsync(int tagId);
        Task AddTagAsync(TagCreateRequest tag);
        Task UpdateTagAsync(TagUpdateRequest tag);
        Task DeleteTagAsync(int tagId);
    }

}
