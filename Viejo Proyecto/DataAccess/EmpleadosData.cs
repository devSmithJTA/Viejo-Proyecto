using Dapper;
using Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class EmpleadosData
    {
        public string? constring { get; set; }
        public EmpleadosData(string constring)
        {
            this.constring = constring;
        }
        public int InsertarEmpleados(Empleados empleados)
        {
            using (var connection = new SqlConnection(constring))
            {
                string procedure = "InsertarEmpleado";

                var parametros = new
                {
                    empleados.IdEmpleado,
                    empleados.Nombre,
                    empleados.Apellido,
                    empleados.FechaNacimiento,
                    empleados.Salario,
                    empleados.DepartamentoId
                };

                var result = connection.Query<string>(procedure, parametros, commandType: CommandType.StoredProcedure).FirstOrDefault();
                return Convert.ToInt32(result);
            }
        }

        // Método para obtener todos los empleados
        public IEnumerable<Empleados> ObtenerTodosLosEmpleados()
        {
            using (var connection = new SqlConnection(constring))
            {
                string procedure = "ObtenerEmpleados";
                return connection.Query<Empleados>(procedure, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        // Método para eliminar un empleado por Id
        public int EliminarEmpleado(int idEmpleado)
        {
            using (var connection = new SqlConnection(constring))
            {
                string procedure = "EliminarEmpleado";
                var parametros = new { IdEmpleado = idEmpleado };
                var result = connection.Query<int>(procedure, parametros, commandType: CommandType.StoredProcedure).FirstOrDefault();
                return result;  // Devuelve el número de filas afectadas
            }
        }

        // Método para editar un empleado
        public int EditarEmpleado(Empleados empleados)
        {
            using (var connection = new SqlConnection(constring))
            {
                string procedure = "EditarEmpleados";

                var parametros = new
                {
                    empleados.IdEmpleado,
                    empleados.Nombre,
                    empleados.Apellido,
                    empleados.FechaNacimiento,
                    empleados.Salario,
                    empleados.DepartamentoId
                };

                var result = connection.Query<int>(procedure, parametros, commandType: CommandType.StoredProcedure).FirstOrDefault();
                return result;  // Devuelve el número de filas afectadas
            }
        }
    }
}
