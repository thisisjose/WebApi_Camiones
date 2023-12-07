namespace WebApi_Camiones.Datos.Models
{
    public class Camion_Ruta
    {
        public int Id { get; set; }
        public int IdRuta { get; set; }
        public Ruta ruta { get; set; }
        public int CamionId { get; set; }
        public Camiones Camion { get; set; }


    }
}
