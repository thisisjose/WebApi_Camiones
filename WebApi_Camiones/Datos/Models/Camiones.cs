using System.Collections.Generic;

namespace WebApi_Camiones.Datos.Models
{
    public class Camiones
    {
        public int Id { get; set; }
        public string Placas { get; set; }
        public string Modelo {  get; set; }


        public List<Camionero_Camiones> Camionero_Camion { get; set; }
    }
}
