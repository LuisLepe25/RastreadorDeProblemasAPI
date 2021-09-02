using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RastreadorDeProblemasAPI.Models.CustomErrors;
using RastreadorDeProblemasAPI.Models.dbModels;
using RastreadorDeProblemasAPI.Models.SwaggerExamples;
using Swashbuckle.AspNetCore.Filters;

namespace RastreadorDeProblemasAPI.Controllers
{
    /// <summary>
    /// Se encarga de generar todas las peticiones CRUD para controlar y rastrear los problemas de una empresa ficticia.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProblemasController : ControllerBase
    {
        private readonly RastreadorProblemasContext _context;

        public ProblemasController(RastreadorProblemasContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Devuelve una lista de todos los problemas dados de alta por un alumno.
        /// </summary>
        /// <remarks>
        /// Devuelve una lista de todos los registros de problemas dados de alta por un alumno, requiere de la matrícula del alumno para poder traer solo los registros dados de alta por el.
        /// </remarks>
        /// <response code="200">Regresa los registros asociados al alumno especificado.</response>
        /// <response code="400">Ocurre si los parametros proporcionados a la petición son nulos, corruptos, incompletos o de otro tipo de dato.</response>
        /// <response code="500">Ocurre si hay un error imprevisto del lado del servidor.</response>  
        // GET: api/Problemas/all/2092458
        [HttpGet("all/{matricula}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Problema>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerResponseExample(200, typeof(ProblemasExamples))]
        public async Task<ActionResult<IEnumerable<Problema>>> GetProblemas(long matricula)
        {
            try
            {
                var problemas = _context.Problemas.Where(x => x.IdentificadorAlumno == matricula).ToListAsync();

                return await problemas;
            } catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message ?? "Error desconocido.");
            }
        }

        /// <summary>
        /// Devuelve un registro especifico de un problema.
        /// </summary>
        /// <remarks>
        /// Se debe proporcionar un ID númerico a la petición, con esto se devolverá un registro de problema que coincida con el ID proporcionado.
        /// </remarks>
        /// <response code="200">Regresa el registro con el ID especificado.</response>
        /// <response code="400">Ocurre si los parametros proporcionados a la petición son nulos, corruptos, incompletos o de otro tipo de dato.</response>  
        /// <response code="404">Ocurre si no existe un registro con el ID especificado.</response>  
        /// <response code="500">Ocurre si hay un error imprevisto del lado del servidor.</response>  
        // GET: api/Problemas/2092458
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Problema))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(ProblemaResponseExample))]
        public async Task<ActionResult<Problema>> GetProblemaAsync(int id)
        {
            try
            {
                var problema = await _context.Problemas.FindAsync(id);

                if (problema == null)
                {
                    return NotFound();
                }

                return problema;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message ?? "Error desconocido.");
            }
        }

        /// <summary>
        /// Modifica el registro especifico que se solicita.
        /// </summary>
        /// <remarks>
        /// Se debe proporcionar el ID númerico del registro a modificar, además se debe dar una representación en JSON del objeto problema con todos los datos no solo los modificados ya que el modelo se actualiza completamente incluso aunque se haya modificado solo 1 propiedad.
        /// </remarks>
        /// <response code="204">El registro fue modificado exitosamente. No regresa ningún contenido.</response>
        /// <response code="400">Ocurre si los parametros proporcionados a la petición son nulos, corruptos, incompletos o de otro tipo de dato.</response>  
        /// <response code="404">Ocurre si no existe un registro con el ID especificado.</response>  
        /// <response code="500">Ocurre si hay un error imprevisto del lado del servidor.</response>  
        // PUT: api/Problemas/5
        [HttpPut("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerRequestExample(typeof(Problema), typeof(ProblemaRequestExample))]
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(ProblemaResponseExample))]
        public async Task<IActionResult> PutProblema(int id, Problema problema)
        {
            try
            {
                if (id != problema.IdProblema)
                {
                    return BadRequest();
                }

                _context.Entry(problema).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProblemaExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError, "Error desconocido.");
                    }
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message ?? "Error desconocido.");
            }
        }

        /// <summary>
        /// Genera y devuelve un registro de un problema.
        /// </summary>
        /// <remarks>
        /// Genera y devuelve un registro de un problema con los datos que se le envien.
        /// </remarks>
        /// <response code="201">El registro fue creado exitosamente. Regresa el registro de problema que se creó.</response>
        /// <response code="400">Ocurre si los parametros proporcionados a la petición son nulos, corruptos, incompletos o de otro tipo de dato.</response>  
        /// <response code="409">Ocurre si existe un conflicto al generar el registro en la BD.</response>  
        /// <response code="500">Ocurre si hay un error imprevisto del lado del servidor.</response>  
        // POST: api/Problemas
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Problema))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerRequestExample(typeof(Problema), typeof(ProblemaRequestExample))]
        [SwaggerResponseExample(StatusCodes.Status201Created, typeof(ProblemaResponseExample))]
        public async Task<Object> PostProblema(Problema problema)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string Descripcion = String.IsNullOrWhiteSpace(problema.Descripcion) ? throw new ArgumentNullException(nameof(Descripcion)) : problema.Descripcion;
                    int IdProblemaEstatus = problema.IdProblemaEstatus == 0 ? throw new ArgumentNullException(nameof(IdProblemaEstatus)) : problema.IdProblemaEstatus;
                    int IdUsuarioAsignado = problema.IdUsuarioAsignado == 0 ? throw new ArgumentNullException(nameof(IdUsuarioAsignado)) : problema.IdUsuarioAsignado;
                    long IdentificadorAlumno = problema.IdentificadorAlumno == 0 ? throw new ArgumentNullException(nameof(IdentificadorAlumno)) : problema.IdentificadorAlumno;

                    _context.Problemas.Add(problema);
                    try
                    {
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateException ex)
                    {
                        return Conflict();
                    }

                    return CreatedAtAction("GetProblema", new { id = problema.IdProblema }, problema);
                }
                catch (ArgumentNullException e)
                {
                    return BadRequest();
                }

                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message ?? "Error desconocido.");
                }
            } else
            {
                return BadRequest();
            }
            
            
        }

        /// <summary>
        /// Elimina un registro de un problema.
        /// </summary>
        /// <remarks>
        /// Elimina un registro de problema que coincida con el id proporcionado.
        /// </remarks>
        /// <response code="204">El registro fue borrado exitosamente. No regresa ningún contenido.</response>
        /// <response code="400">Ocurre si los parametros proporcionados a la petición son nulos, corruptos, incompletos o de otro tipo de dato.</response>  
        /// <response code="404">Ocurre si no existe un registro con el ID especificado.</response>  
        /// <response code="500">Ocurre si hay un error imprevisto del lado del servidor.</response>  
        // DELETE: api/Problemas/5
        [HttpDelete("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteProblema(int id)
        {
            if(id > 0)
            {
                try
                {
                    var problema = await _context.Problemas.FindAsync(id);
                    if (problema == null)
                    {
                        return NotFound();
                    }

                    _context.Problemas.Remove(problema);
                    await _context.SaveChangesAsync();

                    return NoContent();
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message ?? "Error desconocido.");
                }
            }
            else
            {
                return BadRequest();
            }
        }

        private bool ProblemaExists(int id)
        {
            return _context.Problemas.Any(e => e.IdProblema == id);
        }
    }
}
