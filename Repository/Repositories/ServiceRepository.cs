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
        public void Add(Service service)
        {
            _context.Services.Add(service);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Service? service = _context.Services.FirstOrDefault(x => x.Id == id);
            if (service == null)
            {
                throw new InvalidOperationException("Service not found.");
            }
            _context.Services.Remove(service);
            _context.SaveChangesAsync();
        }

        public IEnumerable<Service> GetAll()
        {
            return _context.Services
                .Include(s => s.ServiceTags)
                .Include(s => s.ServiceExpertises);
        }

        public Service? GetById(int id)
        {
            return _context.Services
                .Include(s => s.ServiceTags)
                .Include(s => s.ServiceExpertises)
                .FirstOrDefault(x => x.Id == id);
        }

        public void Update(Service service)
        {
            Service? existingService = _context.Services.FirstOrDefault(x => x.Id == service.Id);
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
            _context.SaveChangesAsync();
        }
    }
}
