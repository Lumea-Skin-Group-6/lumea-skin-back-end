using BusinessObject;
using DAL.DBContext;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;

namespace Repository.Repositories
{
    public class ExpertiseRepository : IExpertiseRepository
    {
        private readonly AppDbContext _context;

        public ExpertiseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Expertise> AddAsync(Expertise expertise)
        {
            await _context.Expertises.AddAsync(expertise);
            await _context.SaveChangesAsync();
            return expertise;
        }

        public async Task<Expertise> DeleteAsync(int id)
        {
            Expertise? expertise = _context.Expertises.FirstOrDefault(x => x.Id == id);
            if (expertise == null)
            {
                throw new InvalidOperationException("Expertise not found.");
            }

            _context.Expertises.Remove(expertise);
            await _context.SaveChangesAsync();
            return expertise;
        }

        public async Task<IEnumerable<Expertise>> GetAllAsync()
        {
            return await _context.Expertises.ToListAsync();
        }

        public async Task<Expertise?> GetByIdAsync(int id)
        {
            return await _context.Expertises.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<IEnumerable<Expertise>> GetByIdsAsync(List<int> ids)
        {
            return await _context.Expertises
                .Where(st => ids.Contains(st.Id))
                .ToListAsync();
        }

        public async Task<Expertise> UpdateAsync(Expertise expertise)
        {
            Expertise? existingExpertise = await _context.Expertises.FirstOrDefaultAsync(x => x.Id == expertise.Id);
            if (existingExpertise == null)
            {
                throw new InvalidOperationException("Expertise not found.");
            }

            existingExpertise.ExpertiseName = expertise.ExpertiseName;
            await _context.SaveChangesAsync();
            return existingExpertise;
        }
    }
}