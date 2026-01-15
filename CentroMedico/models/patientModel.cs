using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CentroMedico.models
{
    internal class patientModel
    {
        public int id { get; set; }
        [Key]
        public string name { get; set; }
        public string age { get; set; }
        public string type_patient { get; set; }
        public float weight { get; set; }
        public float height { get; set; }
        public int total_consultations { get; set; }
        public DateTime birthdate { get; set; }
        public string apgar { get; set; }
        public string blood_type { get; set; }
    }
}
