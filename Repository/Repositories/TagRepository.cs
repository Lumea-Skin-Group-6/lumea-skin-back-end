using BusinessObject;
using DAL.DBContext;
using DAL.DTOs.RequestModel;
using DAL.DTOs.ResponseModel;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;


namespace Repository.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly AppDbContext _context;

        public TagRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TagResponse>> GetAllTagsAsync()
        {
            return await _context.Answers
                .Select(t => new TagResponse { tag_id = t.tag_id, name = t.name })
                .ToListAsync();
        }

        public async Task<TagResponse> GetTagByIdAsync(int tagId)
        {
            var tag = await _context.Answers.FindAsync(tagId);
            return tag != null ? new TagResponse { tag_id = tag.tag_id, name = tag.name } : null;
        }

        public async Task AddTagAsync(TagCreateRequest tag)
        {
            var newTag = new Answer { name = tag.name };
            _context.Answers.Add(newTag);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTagAsync(TagUpdateRequest tag)
        {
            var existingTag = await _context.Answers.FindAsync(tag.tag_id);
            if (existingTag != null)
            {
                existingTag.name = tag.name;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteTagAsync(int tagId)
        {
            var tag = await _context.Answers.FindAsync(tagId);
            if (tag != null)
            {
                _context.Answers.Remove(tag);
                await _context.SaveChangesAsync();
            }
        }
    }
}