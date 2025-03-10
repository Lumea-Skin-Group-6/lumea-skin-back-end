using BusinessObject;
using DAL.DBContext;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class ServiceExpertiseRepository : IServiceExpertiseRepository
    {
        private readonly AppDbContext _context;

        public ServiceExpertiseRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddServiceExpertise(ServiceExpertise serviceExpertise)
        {
            _context.ServiceExpertises.Add(serviceExpertise);
            _context.SaveChanges();
        }
    }
}
