using System;
using System.Collections.Generic;
using CentroMedico.Database;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentroMedico.presenters
{
    public class principalPresenter
    {
        public static void initDataBase()
        {
            using (var db = new ConsultorioContext())
            {
                db.Database.EnsureCreated();
            }
        }
    }
}
