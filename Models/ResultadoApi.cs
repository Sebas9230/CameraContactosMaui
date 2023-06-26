using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolaMundo.Models
{
    internal class ResultadoApi
    {
        public string httpResponseCode { get; set; }

        public List<Contacto> listaContactos { get; set; }

        public Contacto contacto { get; set; }
    }
}
