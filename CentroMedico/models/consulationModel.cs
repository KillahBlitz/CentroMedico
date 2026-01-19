using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CentroMedico.models
{
    public class consulationModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        public int patient_id { get; set; }
        public DateTime date { get; set; }
        public float weight { get; set; }
        public float height { get; set; }
        public float pc { get; set; }
        public string observations { get; set; }
        public string type_consultation { get; set; }
        public float temperature { get; set; }
        public float heart_rate { get; set; }
        public float respiratory_rate { get; set; }
        public string support_studies { get; set; }
        public string diagnosis_treatment { get; set; }
     
    }
}
