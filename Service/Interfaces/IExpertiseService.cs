using BusinessObject;
using DAL.DTO.Expertise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IExpertiseService
    {
        IEnumerable<ExpertiseDTO> GetAll();
        ExpertiseDTO? GetById(int id);
        void Add(AddExpertiseDTO expertise);
        void Update(int id, UpdateExpertiseDTO expertise);
        void Delete(int id);
    }
}
