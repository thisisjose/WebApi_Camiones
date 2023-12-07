using System;
using System.Collections.Generic;

namespace WebApi_Camiones.Datos.Models
{
    public class Ruta
    {
        public int Id { get; set; }
        public DateTime Hora_llegada { get; set; }
        public DateTime Hora_salida { get; set; }
        public int Cantidad_maxima { get; set; }
        public int Cantidad_estimada { get; set; }
        //propiedades de navegacion (en esta parte es donde espesificamos las relaciones)
        public List<Camion_Ruta> Camion_Ruta { get; set; }
    }
}
//Camiones va a ser como mi books