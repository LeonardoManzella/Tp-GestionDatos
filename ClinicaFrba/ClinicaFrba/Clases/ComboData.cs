using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Clases
{
    public class ComboData
    {
        public Int32 identificador { get; set; }
        public String descripcion { get; set; }

        public ComboData(object id, object desc)
        {
            this.descripcion = desc.ToString();
            this.identificador = Int32.Parse(id.ToString());
        }
    }
}
