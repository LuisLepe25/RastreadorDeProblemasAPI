using RastreadorDeProblemasAPI.Models.dbModels;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RastreadorDeProblemasAPI.Models.SwaggerExamples
{
    public class ProblemaRequestExample : IExamplesProvider<Problema>
    {
        public Problema GetExamples()
        {
            return new Problema() { IdProblema = 0, Descripcion = "Se descompuso la computadora.", IdUsuarioAsignado = 12, IdProblemaEstatus = 3, IdentificadorAlumno = 2021541 };
        }
    }
}
