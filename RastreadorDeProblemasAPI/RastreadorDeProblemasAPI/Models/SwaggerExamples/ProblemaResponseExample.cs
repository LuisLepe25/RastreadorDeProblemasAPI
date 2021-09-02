using RastreadorDeProblemasAPI.Models.dbModels;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RastreadorDeProblemasAPI.Models.SwaggerExamples
{
    public class ProblemaResponseExample : IExamplesProvider<Problema>
    {
        public Problema GetExamples()
        {
            return new Problema() { IdProblema = 15, Descripcion = "Mandar papelería de altas y bajas de empleados.", IdUsuarioAsignado = 13, IdProblemaEstatus = 2, IdentificadorAlumno = 2021541 };
        }
    }
}
