using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface ITherapistRepository
    {
        void AddTherapist(Employee employee);

        List<Employee> GetAllTherapist();

        void UpdateTherapist(Employee employee);

        void DeleteTherapist(Employee employee);

        Employee GetTherapistById(int id);
    }
}
