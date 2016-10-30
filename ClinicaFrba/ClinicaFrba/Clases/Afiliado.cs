﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Clases
{
    public class Afiliado
    {
        public int id { get; set; }
        public string apellido { get; set; }
        public string nombre { get; set; }
        public char sexo { get; set; }
        public int? plan_id { get; set; }
        public string tipo_doc {get;set;}
        public int nro_doc { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string e_mail { get; set; }
        public DateTime fecha_nac { get; set; }
        public int estado_civil { get; set; }
    }
}