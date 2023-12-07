using System.Collections.Generic;

namespace WebApi_Camiones.Datos.Models
{
    public class Camionero
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellido_Paterno { get; set; }
        public string Apellido_Materno { get; set; }
        public string Numero_telefono { get; set; }
        //propiedades de navegacion (en esta parte es donde espesificamos las relaciones)
        public List<Camionero_Camiones> Camionero_Camion { get; set; }
    }
  
}
