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
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }
        public Employee GetEmployeeByAccountId(int id)
        {
            return _context.Employees.FirstOrDefault(x => x.AccountId == id);
        }
    }
}
