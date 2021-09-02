using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RastreadorDeProblemasAPI.Models.dbModels;

namespace RastreadorDeProblemasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProblemaEstatusController : ControllerBase
    {
        private readonly RastreadorProblemasContext _context;

        public ProblemaEstatusController(RastreadorProblemasContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Devuelve una lista de todos los Estatus de problema.
        /// </summary>
        /// <remarks>
        /// Devuelve una lista de todos los registros de Estatus de problema existententes en la BD.
        /// </remarks>
        /// <response code="200">Regresa los registros de Estatus.</response>
        /// <response code="500">Ocurre si hay un error imprevisto del lado del servidor.</response>  
        // GET: api/ProblemaEstatus
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ProblemaEstatus>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<ProblemaEstatus>>> GetProblemaEstatuses()
        {
            return await _context.ProblemaEstatuses.ToListAsync();
        }
    }
}
