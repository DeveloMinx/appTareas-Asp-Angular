using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackPTecnica.Models;
using System.Threading;
using System.Threading.Tasks;
using Task = BackPTecnica.Models.Task;

namespace BackPTecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareaController : ControllerBase
    {

        private readonly TareasContext _baseDatos;

        public TareaController(TareasContext baseDatos)
        {
            _baseDatos = baseDatos;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var listaTareas = await _baseDatos.Tasks.ToListAsync();
            return Ok(listaTareas);
        }

        [HttpPost]
        [Route("Agregar")]
        public async Task<IActionResult> Agregar([FromBody] Task request)
        {
            await _baseDatos.Tasks.AddAsync(request);
            await _baseDatos.SaveChangesAsync();
            return Ok(request);
        }

        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var tareaEliminar = await _baseDatos.Tasks.FindAsync(id);

            if (tareaEliminar == null)
                return BadRequest("No existe la tarea");

            _baseDatos.Tasks.Remove(tareaEliminar);
            await _baseDatos.SaveChangesAsync();
            return Ok();

        }


    }
}

