using RastreadorDeProblemasAPI.Models.dbModels;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RastreadorDeProblemasAPI.Models.SwaggerExamples
{
    public class ProblemasExamples : IExamplesProvider<IEnumerable<Problema>>
    {
        public IEnumerable<Problema> GetExamples()
        {
            List<Problema> problemas = new List<Problema>();
            problemas.Add(new Problema() { IdProblema = 1, Descripcion = "Se descompuso el equipo de trabajo.", IdUsuarioAsignado = 12, IdProblemaEstatus = 3, IdentificadorAlumno = 2021541 });
            problemas.Add(new Problema() { IdProblema = 2, Descripcion = "Karla le pegó a Miriam en la cara.", IdUsuarioAsignado = 23, IdProblemaEstatus = 4, IdentificadorAlumno = 2021541 });
            problemas.Add(new Problema() { IdProblema = 3, Descripcion = "Tirar la basura de la oficina.", IdUsuarioAsignado = 44, IdProblemaEstatus = 1, IdentificadorAlumno = 2021541 });
            problemas.Add(new Problema() { IdProblema = 4, Descripcion = "Terminar el proyecto de cotizaciones.", IdUsuarioAsignado = 27, IdProblemaEstatus = 2, IdentificadorAlumno = 2021541 });

            return problemas;
        }
    }
}
