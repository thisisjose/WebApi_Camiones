using WebApi_Camiones.Datos.Models;
using WebApi_Camiones.Datos.ViewModels;

using System;
using Api_Camiones.Datos;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace WebApi_Camiones.Datos.Services
{
    public class CamionerosService
    {
        private AppDbContext _context;
        public CamionerosService(AppDbContext context)
        {
            _context = context;
        }
        public void AgregarCamionero(CamioneroVM camionero)
        {
            var _camionero =  new Camionero()
            { 
               Nombres = camionero.Nombres,
               Apellido_Paterno=camionero.Apellido_Paterno,
               Apellido_Materno=camionero.Apellido_Materno,
               Numero_telefono=camionero.Numero_telefono
            };
            _context.camioneros.Add(_camionero);
            _context.SaveChanges();
        }

        //  public List<Camionero> GetAllCamioneros()=>_context.camioneros.ToList();
        public List<CamioneroWithCamionesVM> GetAllCamioneros()
        {
            var camioneros = _context.camioneros
                .Select(camionero => new CamioneroWithCamionesVM()
                {
                    Id= camionero.Id,
                    Nombres = camionero.Nombres,
                    Apellido_Paterno = camionero.Apellido_Paterno,
                    Apellido_Materno = camionero.Apellido_Materno,
                    Numero_telefono = camionero.Numero_telefono,
                    NumeroCamion = camionero.Camionero_Camion
                        .Select(n => n.Camion.Id).ToList(),
                    Placas = camionero.Camionero_Camion
                        .Select(n => n.Camion.Placas).ToList(),
                }).ToList();
            if (camioneros != null)
                return camioneros;
            else
                throw new Exception($"No hay camioneros registrados");
        }

        public Camionero GetCamionerosByID(int Id)
        {
            var camionero= _context.camioneros.FirstOrDefault(n => n.Id == Id);
            if (camionero != null)
            return camionero;
            else
                throw new Exception($"El camionero con el id {Id} no existe");
        }
        public Camionero EditarCamionero(int Id, CamioneroVM camionero)
        {
           var _camionero= _context.camioneros.FirstOrDefault(n => n.Id == Id);

            if (_camionero != null)
            {
                _camionero.Nombres = camionero.Nombres;
                _camionero.Apellido_Paterno = camionero.Apellido_Paterno;
                _camionero.Apellido_Materno = camionero.Apellido_Materno;
                _camionero.Numero_telefono = camionero.Numero_telefono;
                _context.SaveChanges();//importante no olvidar nunca
            }
            return _camionero;
        }

        public void EliminarPorID(int Id)
        {
            var _camionero = _context.camioneros.FirstOrDefault(n => n.Id == Id);

            if (_camionero != null)
            {
                _context.camioneros.Remove(_camionero);
                _context.SaveChanges();//importante no olvidar nunca
                throw new Exception($"El camionero con id {_camionero.Id} se elimino correctamente");
            }
            else
                throw new Exception($"El camionero con el id {Id} no existe");
        }

        public CamioneroWithCamionesVM GetCamioneroWithCamiones(int _IdCamionero)
        {
            var _camionero = _context.camioneros.Where(n => n.Id == _IdCamionero).Select(n => new CamioneroWithCamionesVM()
            {
                Nombres = n.Nombres,
                Apellido_Paterno = n.Apellido_Paterno,
                Apellido_Materno = n.Apellido_Materno,
                Numero_telefono = n.Numero_telefono,
                NumeroCamion = n.Camionero_Camion.Select(n => n.Camion.Id).ToList(),
                Placas = n.Camionero_Camion.Select(n => n.Camion.Placas).ToList(),

            }).FirstOrDefault();

            if (_camionero != null)
                return _camionero;
            else
                throw new Exception($"El camionero con el id {_camionero.Id} no existe");


        }
    }
}
