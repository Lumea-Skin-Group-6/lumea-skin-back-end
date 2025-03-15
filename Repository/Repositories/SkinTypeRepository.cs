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
        public async Task<SkinType> AddAsync(SkinType skinType)
        {
            await _context.SkinTypes.AddAsync(skinType);
            await _context.SaveChangesAsync();
            return skinType;
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
            return await _context.SkinTypes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<SkinType> UpdateAsync(SkinType skinType)
        {
            SkinType? existingModel = await _context.SkinTypes.FirstOrDefaultAsync(x => x.Id == skinType.Id);
            if (existingModel == null)
            {
                throw new InvalidOperationException("Skin type not found.");
            }

            existingModel.Description = skinType.Description;
            existingModel.Name = skinType.Name;
            existingModel.MinOily = skinType.MinOily;
            existingModel.MaxOily = skinType.MaxOily;
            existingModel.MinDry = skinType.MinDry;
            existingModel.MaxDry = skinType.MaxDry;
            existingModel.MinSensitive = skinType.MinSensitive;
            existingModel.MaxSensitive = skinType.MaxSensitive;

            await _context.SaveChangesAsync();
            return existingModel;
        }
    }
}
