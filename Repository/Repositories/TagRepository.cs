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
    public class TagRepository : ITagRepository
    {
        private readonly AppDbContext _context;

        public TagRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TagResponse>> GetAllTagsAsync()
        {
            return await _context.Tags
                .Select(t => new TagResponse { tag_id = t.tag_id, name = t.name })
                .ToListAsync();
        }

        public async Task<TagResponse> GetTagByIdAsync(int tagId)
        {
            var tag = await _context.Tags.FindAsync(tagId);
            return tag != null ? new TagResponse {tag_id = tag.tag_id, name = tag.name } : null;
        }

        public async Task AddTagAsync(TagCreateRequest tag)
        {
            var newTag = new Tag { name = tag.name };
            _context.Tags.Add(newTag);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTagAsync(TagUpdateRequest tag)
        {
            var existingTag = await _context.Tags.FindAsync(tag.tag_id);
            if (existingTag != null)
            {
                existingTag.name = tag.name;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteTagAsync(int tagId)
        {
            var tag = await _context.Tags.FindAsync(tagId);
            if (tag != null)
            {
                _context.Tags.Remove(tag);
                await _context.SaveChangesAsync();
            }
        }
    }

}
