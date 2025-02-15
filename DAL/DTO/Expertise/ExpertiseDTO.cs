
using BusinessObject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DBContext;

namespace DAL.DTO.Expertise
{
    public class UniqueNameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var context = (AppDbContext)validationContext.GetService(typeof(AppDbContext));
            var expertiseName = value as string;

            if (context.Expertises.Any(u => u.ExpertiseName == expertiseName))
            {
                return new ValidationResult("ExpertiseName must be unique.");
            }

            return ValidationResult.Success;
        }
    }

    public class ExpertiseDTO
    {
        public int Id { get; set; }

        public string ExpertiseName { get; set; } = "";
    }
}
