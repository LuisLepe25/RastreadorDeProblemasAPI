using RastreadorDeProblemasAPI.Models.CustomErrors;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RastreadorDeProblemasAPI.Models.SwaggerExamples
{
    public class ApiErrorExamples : IExamplesProvider<ApiError>
    {
        public ApiError GetExamples()
        {
            return new ApiError(500, "Internal Server Error", "Error desconocido.");
        }
    }

}
