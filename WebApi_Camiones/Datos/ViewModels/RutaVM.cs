using System;
using System.Collections.Generic;

namespace WebApi_Camiones.Datos.ViewModels
{
    public class RutaVM
    {
        public DateTime Hora_llegada { get; set; }
        public DateTime Hora_salida { get; set; }
        public int Cantidad_maxima { get; set; }
        public int Cantidad_estimada { get; set; }
    }
    public class CamionWithRutaVM
    {
        public DateTime Hora_llegada { get; set; }
        public DateTime Hora_salida { get; set; }
        public int Cantidad_maxima { get; set; }
        public int Cantidad_estimada { get; set; }


        //propiedades de navegacion (en esta parte es donde espesificamos las relaciones)
        public List<int> NumeroRuta { get; set; }
    }
}
