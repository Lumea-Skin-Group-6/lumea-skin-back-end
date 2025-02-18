using DAL.DTOs.RequestModel;
using DAL.DTOs.ResponseModel;
using Repository.Interfaces;
using Service.Interfaces;


namespace Service.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;

        public TagService(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task<IEnumerable<TagResponse>> GetAllTagsAsync()
        {
            return await _tagRepository.GetAllTagsAsync();
        }

        public async Task<TagResponse> GetTagByIdAsync(int tagId)
        {
            return await _tagRepository.GetTagByIdAsync(tagId);
        }

        public async Task AddTagAsync(TagCreateRequest tag)
        {
            await _tagRepository.AddTagAsync(tag);
        }

        public async Task UpdateTagAsync(TagUpdateRequest tag)
        {
            await _tagRepository.UpdateTagAsync(tag);
        }

        public async Task DeleteTagAsync(int tagId)
        {
            await _tagRepository.DeleteTagAsync(tagId);
        }
    }
}