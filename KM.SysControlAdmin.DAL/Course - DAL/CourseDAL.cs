#region REFERENCIAS
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Referencias Necesarias Para El Correcto Funcionamiento
using KM.SysControlAdmin.EN.Course___EN;
using Microsoft.EntityFrameworkCore;

#endregion

namespace KM.SysControlAdmin.DAL.Course___DAL
{
    public class CourseDAL
    {
        #region METODO PARA VALIDAR UNICA EXISTENCIA DEL REGISTRO
        // Metodo Para Validar La Unica Existencia De Un Registro y No Haber Duplicidad
        private static async Task<bool> ExistCourse(Course course, ContextDB contextDB)
        {
            bool result = false;
            var courses = await contextDB.Course.FirstOrDefaultAsync(c => c.Code == course.Code && c.Id != course.Id);
            if (courses != null && courses.Id > 0 && courses.Code == course.Code)
                result = true;
            return result;
        }
        #endregion

        #region METODO PARA CREAR
        // Metodo Para Guardar Un Nuevo Registro En La Base De Datos
        public static async Task<int> CreateAsync(Course course)
        {
            int result = 0;
            // Un bloque de conexion que mientras se permanezca en el bloque la base de datos permanecera abierta y al terminar se destruira
            using (var dbContext = new ContextDB())
            {
                bool courseExists = await ExistCourse(course, dbContext);
                if (courseExists == false)
                {
                    dbContext.Course.Add(course);
                    result = await dbContext.SaveChangesAsync();
                }
                else
                    throw new Exception("Curso Ya Existente, Vuelve a Intentarlo Nuevamente");
            }
            return result;
        }
        #endregion
    }
}
