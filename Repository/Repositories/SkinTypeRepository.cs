using BusinessObject;
using DAL.DBContext;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class SkinTypeRepository : ISkinTypeRepository
    {
        private readonly AppDbContext _context;

        public SkinTypeRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<SkinType> GetAllSkinType()
        {
            return _context.SkinTypes.ToList();
        }
        public async Task<SkinType> DeleteAsync(int id)
        {
            SkinType? skinType = await _context.SkinTypes.FirstOrDefaultAsync(x => x.Id == id);
            if (skinType == null)
            {
                throw new InvalidOperationException("Skin type not found.");
            }

            _context.SkinTypes.Remove(skinType);
            await _context.SaveChangesAsync();
            return skinType;
        }

        public async Task<IEnumerable<SkinType>> GetAllAsync()
        {
            return await _context.SkinTypes.ToListAsync();
        }

        public async Task<SkinType?> GetByIdAsync(int id)
        {
            return await _context.SkinTypes.FirstOrDefaultAsync(st => st.Id == id);
        }

        public async Task<SkinType?> AddAsync(SkinType skinType)
        {
            await _context.SkinTypes.AddAsync(skinType);
            await _context.SaveChangesAsync();
            return skinType;
        }
        public async Task<IEnumerable<SkinType>> GetByIdsAsync(List<int> ids)
        {
            return await _context.SkinTypes
                .Where(st => ids.Contains(st.Id))
                .ToListAsync();
        }

        public async Task<SkinType?> UpdateAsync(SkinType skinType)
        {
            var existingSkinType = await _context.SkinTypes
                .FirstOrDefaultAsync(st => st.Id == skinType.Id);

            if (existingSkinType == null)
            {
                throw new InvalidOperationException("SkinType not found.");
            }

            // Update basic properties
            existingSkinType.Name = skinType.Name;
            existingSkinType.Description = skinType.Description;
            existingSkinType.MinDry = skinType.MinDry;
            existingSkinType.MaxDry = skinType.MaxDry;
            existingSkinType.MinOily = skinType.MinOily;
            existingSkinType.MaxOily = skinType.MaxOily;
            existingSkinType.MinSensitive = skinType.MinSensitive;
            existingSkinType.MaxSensitive = skinType.MaxSensitive;

            await _context.SaveChangesAsync();
            return existingSkinType;
        }
    }
}
