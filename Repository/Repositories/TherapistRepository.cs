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
    public class TherapistRepository : ITherapistRepository
    {

        private readonly AppDbContext _context;

        public TherapistRepository(AppDbContext context)
        {
            _context = context;
        }
        public void AddTherapist(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public void DeleteTherapist(Employee employee)
        {
            _context.Employees.Remove(employee);
            _context.SaveChanges();
        }

        public List<Employee> GetAllTherapist()
        {
            return _context.Employees.ToList();
        }

        public Employee GetTherapistById(int id)
        {
            return _context.Employees.Find(id);
        }

        public void UpdateTherapist(Employee employee)
        {
            _context.Employees.Update(employee);
            _context.SaveChanges();
        }
    }
}
