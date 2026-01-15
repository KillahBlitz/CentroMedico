using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CentroMedico.models
{
    internal class historyModel
    {
        public int id { get; set; }
        [Key]
        public string name { get; set; }
        public string history { get; set; }
        public string type_history { get; set; }

    }
}
