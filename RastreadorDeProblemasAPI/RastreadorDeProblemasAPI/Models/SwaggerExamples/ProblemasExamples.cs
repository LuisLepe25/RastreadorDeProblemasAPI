using RastreadorDeProblemasAPI.Models.dbModels;
using RastreadorDeProblemasAPI.Models.DTO;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RastreadorDeProblemasAPI.Models.SwaggerExamples
{
    public class ProblemasExamples : IExamplesProvider<IEnumerable<ProblemaDTO>>
    {
        public IEnumerable<ProblemaDTO> GetExamples()
        {
            List<ProblemaDTO> problemas = new List<ProblemaDTO>();
            problemas.Add(new ProblemaDTO() { IdProblema = 1, Descripcion = "Se descompuso el equipo de trabajo.", IdUsuarioAsignado = 12, UsuarioNombre = "Anas Garriga", IdProblemaEstatus = 3, ProblemaEstatusNombre = "ALTO", ColorEstatusProblema = "warning", IdentificadorAlumno = 2021541 });
            problemas.Add(new ProblemaDTO() { IdProblema = 2, Descripcion = "Karla le pegó a Miriam en la cara.", IdUsuarioAsignado = 23, UsuarioNombre = "Pedro Sanchez", IdProblemaEstatus = 4, ProblemaEstatusNombre = "URGENTE", ColorEstatusProblema = "danger", IdentificadorAlumno = 2021541 });
            problemas.Add(new ProblemaDTO() { IdProblema = 3, Descripcion = "Tirar la basura de la oficina.", IdUsuarioAsignado = 44, UsuarioNombre = "Luis Lepe", IdProblemaEstatus = 1, ProblemaEstatusNombre = "BAJO", ColorEstatusProblema = "info", IdentificadorAlumno = 2021541 });
            problemas.Add(new ProblemaDTO() { IdProblema = 4, Descripcion = "Terminar el proyecto de cotizaciones.", IdUsuarioAsignado = 27, UsuarioNombre = "Santa Lucia", IdProblemaEstatus = 2, ProblemaEstatusNombre = "MEDIO", ColorEstatusProblema = "primary", IdentificadorAlumno = 2021541 });

            return problemas;
        }
    }
}
