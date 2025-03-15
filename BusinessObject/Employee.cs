using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BusinessObject
{
    [Table("employees")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("account_id")]
        public int AccountId { get; set; }

        public Account Account { get; set; }

        [Column("role_type")]
        public string Type { get; set; }

        [JsonIgnore]
        public ICollection<Slot> Slots { get; set; }
        
        public ICollection<TherapistExpertise> TherapistExpertises { get; set; }
    }

}
