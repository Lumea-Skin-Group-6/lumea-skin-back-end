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
    public class SkinTypeServiceRepository : ISkinTypeServiceRepository
    {
        private readonly AppDbContext _context;

        public SkinTypeServiceRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddSkinTypeService(SkinTypeService skinTypeService)
        {
             _context.ServiceSkinTypes.Add(skinTypeService);
             _context.SaveChanges();
        }
    }
}
