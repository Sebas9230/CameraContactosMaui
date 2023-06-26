using HolaMundo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolaMundo.Services
{
    public interface IServicioApi
    {
        public Task<List<Contacto>> ListarContactos();
        public Task<Contacto> ObtenerContacto(string cedula);
        public Task<string> GuardarContacto(Contacto contacto);
        public Task<string> EditarContacto(string cedula, Contacto contacto);
        public Task<string> BorrarContacto(string cedula);
    }
}
