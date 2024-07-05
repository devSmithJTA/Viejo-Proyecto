using Microsoft.AspNetCore.Mvc;
using Business;
using Data;

namespace AplicacionPUNTONET.Controllers
{
    public class HomeController : Controller
    {
        private readonly EmpleadosManager _empleadosManager;

        public HomeController()
        {
            _empleadosManager = new EmpleadosManager(Config.GetConString());
        }

        // Listar todos los empleados
        public IActionResult Index()
        {
            var empleados = _empleadosManager.ObtenerEmpleados();
            return View(empleados);
        }

        // Mostrar el formulario de creación
        public IActionResult Create()
        {
            return View();
        }

        // Procesar el formulario de creación
        [HttpPost]
        public IActionResult Create(Empleados empleados)
        {
            if (ModelState.IsValid)
            {
                _empleadosManager.InsertarCliente(empleados);
                return RedirectToAction("Index");
            }
            return View(empleados);
        }

        // Mostrar el formulario de edición
        public IActionResult Edit(int id)
        {
            var empleado = _empleadosManager.ObtenerEmpleados().FirstOrDefault(e => e.IdEmpleado == id);
            if (empleado == null)
            {
                return NotFound();
            }
            return View(empleado);
        }

        // Procesar el formulario de edición
        [HttpPost]
        public IActionResult Edit(Empleados empleados)
        {
            if (ModelState.IsValid)
            {
                _empleadosManager.EditarEmpleado(empleados);
                return RedirectToAction("Index");
            }
            return View(empleados);
        }

        // Mostrar la confirmación de eliminación
        public IActionResult Delete(int id)
        {
            var empleado = _empleadosManager.ObtenerEmpleados().FirstOrDefault(e => e.IdEmpleado == id);
            if (empleado == null)
            {
                return NotFound();
            }
            return View(empleado);
        }

        // Procesar la eliminación
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _empleadosManager.EliminarEmpleado(id);
            return RedirectToAction("Index");
        }
    }
}
