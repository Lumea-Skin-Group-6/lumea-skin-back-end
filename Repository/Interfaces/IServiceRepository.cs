using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    internal interface IServiceRepository
    {
        IEnumerable<Service> GetAll();
        Service? GetById(int id);
        void Add(Service service);
        void Update(Service service);
        void Delete(int id);
    }
}
