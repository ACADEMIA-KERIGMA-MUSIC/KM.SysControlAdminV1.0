#region REFERENCIAS
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Referencias Necesarias Para El Correcto Funcionamiento
using KM.SysControlAdmin.EN.CourseAssignment___EN;
using Microsoft.EntityFrameworkCore;


#endregion

namespace KM.SysControlAdmin.DAL.CourseAssignment___DAL
{
    public class CourseAssignmentDAL
    {
        #region METODO PARA VALIDAR UNICA EXISTENCIA DEL REGISTRO
        // Metodo Para Validar La Unica Existencia De Un Registro y No Haber Duplicidad
        private static async Task<bool> ExistCourseAssignment(CourseAssignment courseAssignment, ContextDB contextDB)
        {
            bool result = false;
            var courseAssignments = await contextDB.CourseAssignment.FirstOrDefaultAsync(c => c.IdStudent == courseAssignment.IdStudent && c.IdCourse == courseAssignment.IdCourse && c.Id != courseAssignment.Id);
            if (courseAssignments != null && courseAssignments.Id > 0 && courseAssignments.IdStudent == courseAssignment.IdStudent && courseAssignments.IdCourse == courseAssignment.IdCourse)
                result = true;
            return result;
        }
        #endregion

        #region METODO PARA CREAR
        // Metodo Para Guardar Un Nuevo Registro En La Base De Datos
        public static async Task<int> CreateAsync(CourseAssignment courseAssignment)
        {
            int result = 0;
            // Un bloque de conexion que mientras se permanezca en el bloque la base de datos permanecera abierta y al terminar se destruira
            using (var dbContext = new ContextDB())
            {
                bool courseAssignmentExists = await ExistCourseAssignment(courseAssignment, dbContext);
                if (courseAssignmentExists == false)
                {
                    dbContext.CourseAssignment.Add(courseAssignment);
                    result = await dbContext.SaveChangesAsync();
                }
                else
                    throw new Exception("Asignacion Ya Existente, Vuelve a Intentarlo Nuevamente");
            }
            return result;
        }
        #endregion
    }
}
