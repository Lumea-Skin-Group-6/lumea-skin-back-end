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
            ServiceModel? service = await _context.Services
                .Include(s => s.SkinTypeServices)
                .Include(s => s.ServiceExpertises)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (service == null)
            {
                throw new InvalidOperationException("Service not found.");
            }

            _context.ServiceSkinTypes.RemoveRange(service.SkinTypeServices);
            _context.ServiceExpertises.RemoveRange(service.ServiceExpertises);
            _context.Services.Remove(service);

            await _context.SaveChangesAsync();
            return service;
        }

        public async Task<IEnumerable<ServiceModel>> GetAllAsync()
        {
            return await _context.Services
                .Include(s => s.SkinTypeServices)
                .ThenInclude(t => t.SkinType)
                .Include(s => s.ServiceExpertises)
                .ThenInclude(e => e.Expertise)
                .ToListAsync();
        }

        public async Task<ServiceModel?> GetByIdAsync(int id)
        {
            return await _context.Services
                .Include(s => s.SkinTypeServices)
                .ThenInclude(t => t.SkinType)
                .Include(s => s.ServiceExpertises)
                .ThenInclude(e => e.Expertise)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ServiceModel> UpdateAsync(ServiceModel service)
        {
            ServiceModel? existingService = await _context.Services
                .Include(s => s.SkinTypeServices)
                .Include(s => s.ServiceExpertises)
                .FirstOrDefaultAsync(x => x.Id == service.Id);

            if (existingService == null)
            {
                throw new InvalidOperationException("Service not found.");
            }

            // Update basic properties
            existingService.Name = service.Name;
            existingService.ImageUrl = service.ImageUrl;
            existingService.ImageUrl2 = service.ImageUrl2;
            existingService.ImageUrl3 = service.ImageUrl3;
            existingService.Price = service.Price;
            existingService.Description = service.Description;
            existingService.RecommendedPeriodStartTime = service.RecommendedPeriodStartTime;
            existingService.RecommendedPeriodEndTime = service.RecommendedPeriodEndTime;
            existingService.Duration = service.Duration;
            existingService.ExperienceRequired = service.ExperienceRequired;
            existingService.RecommendedAge = service.RecommendedAge;
            existingService.Type = service.Type;
            existingService.NumberOfTreatment = service.NumberOfTreatment;

            // Update related SkinTypes
            var existingSkinTypes = existingService.SkinTypeServices.ToList();
            var newSkinTypes = service.SkinTypeServices.ToList();

            // Remove SkinTypes that are no longer in the new list
            foreach (var oldItem in existingSkinTypes)
            {
                if (!newSkinTypes.Any(n => n.SkinTypeId == oldItem.SkinTypeId))
                {
                    existingService.SkinTypeServices.Remove(oldItem);
                }
            }

            // Add only new SkinTypes that were not in the old list
            foreach (var newItem in newSkinTypes)
            {
                if (!existingSkinTypes.Any(e => e.SkinTypeId == newItem.SkinTypeId))
                {
                    existingService.SkinTypeServices.Add(newItem);
                }
            }

            // Update related Expertises
            var existingExpertises = existingService.ServiceExpertises.ToList();
            var newExpertises = service.ServiceExpertises.ToList();

            // Remove Expertises that are no longer in the new list
            foreach (var oldItem in existingExpertises)
            {
                if (!newExpertises.Any(n => n.ExpertiseId == oldItem.ExpertiseId))
                {
                    existingService.ServiceExpertises.Remove(oldItem);
                }
            }

            // Add only new Expertises that were not in the old list
            foreach (var newItem in newExpertises)
            {
                if (!existingExpertises.Any(e => e.ExpertiseId == newItem.ExpertiseId))
                {
                    existingService.ServiceExpertises.Add(newItem);
                }
            }

            await _context.SaveChangesAsync();
            return existingService;
        }
    }

}