using System.Collections.Generic;

namespace WebApi_Camiones.Datos.ViewModels
{
    public class CamioneroVM
    {
      
        public string Nombres { get; set; }
        public string Apellido_Paterno { get; set; }
        public string Apellido_Materno { get; set; }
        public string Numero_telefono { get; set; }
    }
    public class CamioneroWithCamionesVM
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellido_Paterno { get; set; }
        public string Apellido_Materno { get; set; }
        public string Numero_telefono { get; set; }
        //propiedades de navegacion (en esta parte es donde espesificamos las relaciones)
        public List<int> NumeroCamion { get; set; }
        public List<string> Placas { get; set; }

    }
}
