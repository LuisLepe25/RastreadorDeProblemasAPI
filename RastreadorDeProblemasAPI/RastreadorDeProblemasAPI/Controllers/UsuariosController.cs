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
    public class UsuariosController : ControllerBase
    {
        private readonly RastreadorProblemasContext _context;

        public UsuariosController(RastreadorProblemasContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Devuelve una lista de todos los Usuarios.
        /// </summary>
        /// <remarks>
        /// Devuelve una lista de todos los registros de Usuarios existententes en la BD.
        /// </remarks>
        /// <response code="200">Regresa los registros de usuario.</response>
        /// <response code="500">Ocurre si hay un error imprevisto del lado del servidor.</response>  
        // GET: api/Usuarios
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Usuario>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }
    }
}
