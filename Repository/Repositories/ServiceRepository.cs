using BusinessObject;
using DAL.DBContext;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;

namespace Repository.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly AppDbContext _context;

        public ServiceRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceModel> AddAsync(ServiceModel service)
        {
            await _context.Services.AddAsync(service);
            await _context.SaveChangesAsync();
            return service;
        }

        public async Task<ServiceModel> DeleteAsync(int id)
        {
            ServiceModel? service = await _context.Services.FirstOrDefaultAsync(x => x.Id == id);
            if (service == null)
            {
                throw new InvalidOperationException("Service not found.");
            }

            _context.Services.Remove(service);
            await _context.SaveChangesAsync();
            return service;
        }

        public async Task<IEnumerable<ServiceModel>> GetAllAsync()
        {
            return await _context.Services
                .Include(s => s.ServiceTags)
                .ThenInclude(t => t.Tag)
                .Include(s => s.ServiceExpertises)
                .ThenInclude(e => e.Expertise)
                .ToListAsync();
        }

        public async Task<ServiceModel?> GetByIdAsync(int id)
        {
            return await _context.Services
                .Include(s => s.ServiceTags)
                .ThenInclude(t => t.Tag)
                .Include(s => s.ServiceExpertises)
                .ThenInclude(e => e.Expertise)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ServiceModel> UpdateAsync(ServiceModel service)
        {
            ServiceModel? existingService = await _context.Services.FirstOrDefaultAsync(x => x.Id == service.Id);
            if (existingService == null)
            {
                throw new InvalidOperationException("Service not found.");
            }

            existingService.Price = service.Price;
            existingService.ExperienceRequired = service.ExperienceRequired;
            existingService.Name = service.Name;
            existingService.Description = service.Description;
            existingService.RecommendedPeriodEndTime = service.RecommendedPeriodEndTime;
            existingService.RecommendedPeriodStartTime = service.RecommendedPeriodStartTime;
            existingService.ImageUrl = service.ImageUrl;
            existingService.Duration = service.Duration;
            existingService.Type = service.Type;
            existingService.NumberOfTreatment = service.NumberOfTreatment;
            existingService.ServiceTags = service.ServiceTags;
            existingService.ServiceExpertises = service.ServiceExpertises;
            await _context.SaveChangesAsync();
            return existingService;
        }
    }
}