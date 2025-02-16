using BusinessObject;
using DAL.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly AppDbContext _context;
        public ServiceRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Service> AddAsync(Service service)
        {
            await _context.Services.AddAsync(service);
            await _context.SaveChangesAsync();
            return service;
        }

        public async Task<Service> DeleteAsync(int id)
        {
            Service? service = await _context.Services.FirstOrDefaultAsync(x => x.Id == id);
            if (service == null)
            {
                throw new InvalidOperationException("Service not found.");
            }
            _context.Services.Remove(service);
            await _context.SaveChangesAsync();
            return service;
        }

        public async Task<IEnumerable<Service>> GetAllAsync()
        {
            return await _context.Services
                .Include(s => s.ServiceTags)
                .ThenInclude(t => t.Tag)
                .Include(s => s.ServiceExpertises)
                .ThenInclude(e => e.Expertise)
                .ToListAsync();
        }

        public async Task<Service?> GetByIdAsync(int id)
        {
            return await _context.Services
                .Include(s => s.ServiceTags)
                .ThenInclude(t => t.Tag)
                .Include(s => s.ServiceExpertises)
                .ThenInclude(e => e.Expertise)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Service> UpdateAsync(Service service)
        {
            Service? existingService = await _context.Services.FirstOrDefaultAsync(x => x.Id == service.Id);
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
