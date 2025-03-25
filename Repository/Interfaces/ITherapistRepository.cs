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
        Task<IEnumerable<Account>> GetAllAsync();
        Task<Account?> GetByIdAsync(int id);
        Task<Account> AddAsync(Account account);
        Task<Account> UpdateAsync(Account account);
        Task<Account> DeleteAsync(int id);

        Task<IEnumerable<Account>> GetAllTherapistByListExpertiseID(ICollection<int> expertiseID);

    }
}
