using Api_Camiones.Datos;
using System.Collections.Generic;
using System;
using WebApi_Camiones.Datos.Models;
using WebApi_Camiones.Datos.ViewModels;
using System.Linq;

namespace WebApi_Camiones.Datos.Services
{
    public class MonitoreoService
    {
        private readonly AppDbContext _context;

        public MonitoreoService(AppDbContext context)
        {
            _context = context;
        }

        public List<CamionWithRutaVM> GetAllRutas()
        {
            var rutas = _context.rutas
                .Select(ruta => new CamionWithRutaVM
                {
                    Hora_llegada = ruta.Hora_llegada,
                    Hora_salida = ruta.Hora_salida,
                    Cantidad_maxima = ruta.Cantidad_maxima,
                    Cantidad_estimada = ruta.Cantidad_estimada,
                    NumeroRuta = ruta.Camion_Ruta.Select(n => n.Camion.Id).ToList(),
                })
                .ToList();

            return rutas;
        }

        public Ruta GetRutaById(int id) => _context.rutas.FirstOrDefault(ruta => ruta.Id == id);

        public void AgregarRuta(RutaVM ruta)
        {
            var nuevaRuta = new Ruta
            {
                Hora_llegada = ruta.Hora_llegada,
                Hora_salida = ruta.Hora_salida,
                Cantidad_maxima = ruta.Cantidad_maxima,
                Cantidad_estimada = ruta.Cantidad_estimada,
            };

            _context.rutas.Add(nuevaRuta);
            _context.SaveChanges();
        }

        public Ruta EditarRuta(int id, RutaVM ruta)
        {
            var rutaExistente = _context.rutas.FirstOrDefault(r => r.Id == id);

            if (rutaExistente != null)
            {
                rutaExistente.Hora_llegada = ruta.Hora_llegada;
                rutaExistente.Hora_salida = ruta.Hora_salida;
                rutaExistente.Cantidad_maxima = ruta.Cantidad_maxima;
                rutaExistente.Cantidad_estimada = ruta.Cantidad_estimada;

                _context.SaveChanges();
            }

            return rutaExistente;
        }

        public void EliminarRuta(int id)
        {
            var rutaAEliminar = _context.rutas.FirstOrDefault(r => r.Id == id);

            if (rutaAEliminar != null)
            {
                _context.rutas.Remove(rutaAEliminar);
                _context.SaveChanges();
            }
        }

        public CamionWithRutaVM GetRutaWithCamiones(int idRuta)
        {
            var ruta = _context.rutas
                .Where(r => r.Id == idRuta)
                .Select(r => new CamionWithRutaVM
                {
                    Hora_llegada = r.Hora_llegada,
                    Hora_salida = r.Hora_salida,
                    Cantidad_maxima = r.Cantidad_maxima,
                    Cantidad_estimada = r.Cantidad_estimada,
                    NumeroRuta = r.Camion_Ruta.Select(n => n.Camion.Id).ToList(),
                })
                .FirstOrDefault();

            return ruta;
        }
    }
}