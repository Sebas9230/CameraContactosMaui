using HolaMundo.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HolaMundo.Services
{
    public class ServicioApi : IServicioApi
    {

        private static string _baseUrl;

        public ServicioApi()
        {
           _baseUrl = "http://10.0.2.2:5179/";
        }

        public async Task<List<Contacto>> ListarContactos()
        {
            List<Contacto> productos = new List<Contacto>();
            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            var response = await cliente.GetAsync("/api/v1/Contacto");
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<ResultadoApi>(json_response);
                productos = resultado.listaContactos;
            }
            return productos;
        }

        public async Task<Contacto> ObtenerContacto(string cedula)
        {
            Contacto producto = new Contacto();
            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            var response = await cliente.GetAsync($"/api/v1/Contacto/{cedula}");
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<ResultadoApi>(json_response);
                producto = resultado.contacto;
            }
            return producto;
        }

        public async Task<string> GuardarContacto(Contacto contacto)
        {
            string httpsResponseCode = HttpStatusCode.BadRequest.ToString();
            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            var content = new StringContent(JsonConvert.SerializeObject(contacto), Encoding.UTF8, "application/json");
            var response = await cliente.PostAsync("/api/v1/Contacto/", content);
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<ResultadoApi>(json_response);
                httpsResponseCode = resultado.httpResponseCode;
            }
            return httpsResponseCode;
        }

        public async Task<string> BorrarContacto(string cedula)
        {
            string httpsResponseCode = HttpStatusCode.BadRequest.ToString();
            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            var response = await cliente.DeleteAsync($"/api/v1/Contacto/{cedula}");
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<ResultadoApi>(json_response);
                httpsResponseCode = resultado.httpResponseCode;
            }
            return httpsResponseCode;
        }

        public async Task<string> EditarContacto(string cedula, Contacto contacto)
        {
            string httpsResponseCode = HttpStatusCode.BadRequest.ToString();
            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            var content = new StringContent(JsonConvert.SerializeObject(contacto), Encoding.UTF8, "application/json");
            var response = await cliente.PutAsync($"/api/v1/Contacto/{cedula}", content);
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<ResultadoApi>(json_response);
                httpsResponseCode = resultado.httpResponseCode;
            }
            return httpsResponseCode;
        }

    }
}
