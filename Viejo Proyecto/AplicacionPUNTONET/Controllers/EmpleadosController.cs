using Microsoft.AspNetCore.Mvc;
using Business;
using Data;

namespace AplicacionPUNTONET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly EmpleadosManager _empleadosManager;

        public EmpleadosController()
        {
            _empleadosManager = new EmpleadosManager(Config.GetConString());
        }

        // POST: api/Empleados
        [HttpPost]
        public IActionResult Post([FromBody] Empleados empleados)
        {
            if (ModelState.IsValid)
            {
                int result = _empleadosManager.InsertarCliente(empleados);
                return CreatedAtAction(nameof(Post), new { id = result }, empleados);
            }
            return BadRequest(ModelState);
        }

        // GET: api/Empleados
        [HttpGet]
        public IActionResult Get()
        {
            var empleados = _empleadosManager.ObtenerEmpleados();
            return Ok(empleados);
        }

        // GET: api/Empleados/{id}
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var empleado = _empleadosManager.ObtenerEmpleados().FirstOrDefault(e => e.IdEmpleado == id);
            if (empleado == null)
            {
                return NotFound();
            }
            return Ok(empleado);
        }

        // PUT: api/Empleados/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Empleados empleados)
        {
            if (ModelState.IsValid)
            {
                empleados.IdEmpleado = id;
                int result = _empleadosManager.EditarEmpleado(empleados);
                if (result > 0)
                {
                    return Ok();
                }
                return NotFound();
            }
            return BadRequest(ModelState);
        }

        // DELETE: api/Empleados/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            int result = _empleadosManager.EliminarEmpleado(id);
            if (result > 0)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
