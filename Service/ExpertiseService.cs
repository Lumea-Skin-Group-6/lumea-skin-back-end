using BusinessObject;
using DAL.DTO.Expertise;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ExpertiseService : IExpertiseService
    {
        private readonly IExpertiseRepository _repository;
        public ExpertiseService(IExpertiseRepository repository)
        {
            _repository = repository;
        }
        public void Add(AddExpertiseDTO expertise)
        {
            _repository.Add(new Expertise
            {
                ExpertiseName = expertise.ExpertiseName,
            });
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public IEnumerable<ExpertiseDTO> GetAll()
        {
            return _repository.GetAll().Select(e => new ExpertiseDTO
            {
                Id = e.Id,
                ExpertiseName = e.ExpertiseName,
            });
        }

        public ExpertiseDTO? GetById(int id)
        {
            Expertise? expertise = _repository.GetById(id);
            if (expertise == null)
            {
                return null;
            }
            return new ExpertiseDTO
            {
                Id = expertise.Id,
                ExpertiseName = expertise.ExpertiseName,
            };
        }

        public void Update(int id, UpdateExpertiseDTO expertise)
        {
            _repository.Update(new Expertise
            {
                Id = id,
                ExpertiseName = expertise.ExpertiseName
            });
        }
    }
}
