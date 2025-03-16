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
    }
}
