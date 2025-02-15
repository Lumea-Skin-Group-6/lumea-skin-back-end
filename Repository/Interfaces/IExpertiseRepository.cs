using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IExpertiseRepository
    {
        IEnumerable<Expertise> GetAll();
        Expertise? GetById(int id);
        void Add(Expertise expertise);
        void Update(Expertise expertise);
        void Delete(int id);
    }
}
