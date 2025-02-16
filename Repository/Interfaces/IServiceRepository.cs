using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IServiceRepository
    {
        Task<IEnumerable<Service>> GetAllAsync();
        Task<Service?> GetByIdAsync(int id);
        Task<Service> AddAsync(Service service);
        Task<Service> UpdateAsync(Service service);
        Task<Service> DeleteAsync(int id);
    }
}
