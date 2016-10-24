using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba
{
    public class Usuario
    {
        public int id { get; set; }
        public string apellido { get; set; }
        public string nombre { get; set; }
        public int? plan_id { get; set; }
        public List<int> permisos { get; set; }
        public int rol_seleccionado_id { get; set; }

    }
}
