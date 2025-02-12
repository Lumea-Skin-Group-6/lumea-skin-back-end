using BusinessObject;
using DAL.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ExpertiseRepository : IExpertiseRepository
    {
        private readonly AppDbContext _context;
        public ExpertiseRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Add(Expertise expertise)
        {
            _context.Expertises.Add(expertise);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Expertise? expertise = _context.Expertises.FirstOrDefault(x => x.Id == id);
            if (expertise != null)
            {
                _context.Expertises.Remove(expertise);
                _context.SaveChangesAsync();
            }
        }

        public IEnumerable<Expertise> GetAll()
        {
            return _context.Expertises;
        }

        public Expertise? GetById(int id)
        {
            return _context.Expertises.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Expertise expertise)
        {
            Expertise? existingExpertise = _context.Expertises.FirstOrDefault(x => x.Id == expertise.Id);
            if (existingExpertise != null)
            {
                existingExpertise.ExpertiseName = expertise.ExpertiseName;
                _context.SaveChangesAsync();
            }
        }
    }
}
