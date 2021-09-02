using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RastreadorDeProblemasAPI.Models.dbModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RastreadorDeProblemasAPI
{
    /// <summary>
    /// Clase de soporte para inicializar la base de datos.
    /// </summary>
    public class InitDB
    {
        /// <summary>
        /// Utilizar la configuración de los "Migrate" para actualizar la base de datos a la versión más nueva
        /// </summary>
        /// <param name="context">contexto de la base de datos del sistema</param>
        public static void UpdateDB(RastreadorProblemasContext context)
        {
            context.Database.Migrate();
        }

        /// <summary>
        /// Crea información por defecto como los edificios, los tipos de GenteFIME y Espacio (Modelos de la BD), entre otros.
        /// </summary>
        /// <param name="context">contexto de la base de datos del sistema</param>
        public static void SeedDefaultData(RastreadorProblemasContext context)
        {

            CreateProblemaEstatusIfNotExists(context, 1, "BAJO");
            CreateProblemaEstatusIfNotExists(context, 2, "MEDIO");
            CreateProblemaEstatusIfNotExists(context, 3, "ALTO");
            CreateProblemaEstatusIfNotExists(context, 4, "URGENTE");

            List<string> listaNombres = new List<string>() { "Eloisa Giner", "Belinda Alcaide", "Carlos Barrio", "Juan Miguel Cardenas", "Mireia Boix", "Jose Tomas Moran", "Florencia Santamaria", "Juan Luis Miralles", "Aitor Alcaraz", "Maria Azucena Huerta", "Jose Domingo Sarmiento", "Anas Garriga" };
            CreateUsuariosIfTableEmpty(context, listaNombres);
        }

        private static ProblemaEstatus CreateProblemaEstatusIfNotExists(RastreadorProblemasContext context, int Id, string descripcion)
        {
            var obj = context.ProblemaEstatuses.Where(x => x.IdProblemaEstatus == Id);
            if (!obj.Any())
            {
                ProblemaEstatus o = new ProblemaEstatus()
                {
                    IdProblemaEstatus = Id,
                    Descripcion = descripcion
                };
                context.ProblemaEstatuses.Add(o);
                context.SaveChanges();
                return o;
            }
            return null;
        }

        private static void CreateUsuariosIfTableEmpty(RastreadorProblemasContext context, List<string> lstNombres)
        {
            if (!context.Usuarios.Any())
            {
                int i = 1;
                foreach (string nombre in lstNombres)
                {
                    Usuario o = new Usuario()
                    {
                        IdUsuario = i,
                        Nombre = nombre
                    };
                    context.Usuarios.Add(o);
                    i++;
                }
                context.SaveChanges();
            }
        }
    }
}