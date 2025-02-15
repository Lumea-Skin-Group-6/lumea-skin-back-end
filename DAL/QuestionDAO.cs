using DAL.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class QuestionDAO
    {
        private readonly AppDbContext _context;

        public QuestionDAO(AppDbContext context)
        {
            _context = context;
        }
    }
}
