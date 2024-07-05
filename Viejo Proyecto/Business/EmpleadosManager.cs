using Data;
using DataAccess;
using System.Collections.Generic;

namespace Business
{
    public class EmpleadosManager
    {
        private readonly EmpleadosData _empleadosData;

        public EmpleadosManager(string constring)
        {
            _empleadosData = new EmpleadosData(constring);
        }

        public int InsertarCliente(Empleados empleados)
        {
            return _empleadosData.InsertarEmpleados(empleados);
        }

        public IEnumerable<Empleados> ObtenerEmpleados()
        {
            return _empleadosData.ObtenerTodosLosEmpleados();
        }

        public int EliminarEmpleado(int idEmpleado)
        {
            return _empleadosData.EliminarEmpleado(idEmpleado);
        }

        public int EditarEmpleado(Empleados empleados)
        {
            return _empleadosData.EditarEmpleado(empleados);
        }
    }
}
