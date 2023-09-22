using RastreadorDeProblemasAPI.Models.dbModels;
using RastreadorDeProblemasAPI.Models.DTO;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RastreadorDeProblemasAPI.Models.SwaggerExamples
{
    public class ProblemaResponseExample : IExamplesProvider<ProblemaDTO>
    {
        public ProblemaDTO GetExamples()
        {
            return new ProblemaDTO() { IdProblema = 15, Descripcion = "Mandar papelería de altas y bajas de empleados.", IdUsuarioAsignado = 12, UsuarioNombre = "Anas Garriga", IdProblemaEstatus = 2, ProblemaEstatusNombre = "MEDIO", ColorEstatusProblema = "warning", IdentificadorAlumno = 2021541 };
        }
    }
}
