using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CentroMedico.models
{
    public class historyModel
    {
        public int id { get; set; }
        public int patient_id { get; set; }
        public string name { get; set; }
        public string history { get; set; }
        public string type_history { get; set; }

    }
}
