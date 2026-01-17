using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CentroMedico.models
{
    public class patientModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        public int age { get; set; }
        public int age_mounth { get; set; }
        public string type_patient { get; set; } = "General";
        public float weight { get; set; }
        public float height { get; set; }
        public int total_consulation { get; set; }
        public DateTime birthdate { get; set; }
        public string apgar { get; set; }
        public string blood_type { get; set; }
        
        [NotMapped]
        public DateOnly? ultimateDate { get; set; }
    }
}