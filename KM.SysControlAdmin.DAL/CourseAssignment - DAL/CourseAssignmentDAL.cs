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
            // Verificar si ya existe una asignación con el mismo estudiante y curso
            var courseAssignments = await contextDB.CourseAssignment.FirstOrDefaultAsync(c =>
                c.IdStudent == courseAssignment.IdStudent &&
                c.IdCourse == courseAssignment.IdCourse &&
                c.Id != courseAssignment.Id);

            if (courseAssignments != null &&
                courseAssignments.Id > 0 &&
                courseAssignments.IdStudent == courseAssignment.IdStudent &&
                courseAssignments.IdCourse == courseAssignment.IdCourse)
            {
                return true;
            }

            // Verificar si el estudiante está inactivo
            var student = await contextDB.Student.FirstOrDefaultAsync(c => c.Id == courseAssignment.IdStudent);
            if (student != null && student.Status == 2)
            {
                throw new Exception("No se puede agregar la asignacion ya que el Alumno/a no esta activo.");
            }

            // Verificar si el curso está inactivo
            var course = await contextDB.Course.FirstOrDefaultAsync(c => c.Id == courseAssignment.IdCourse);
            if (course != null && course.Status == 2)
            {
                throw new Exception("No se puede agregar la asignacion ya que el Curso no esta activo.");
            }

            return false; // Solo devolvemos false si ambas validaciones no fallaron
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

        #region METODO PARA MOSTRAR
        // Metodo Para Mostrar La Lista De Registros
        public static async Task<List<CourseAssignment>> GetAllAsync()
        {
            var courseAssignments = new List<CourseAssignment>();
            using (var dbContext = new ContextDB())
            {
                courseAssignments = await dbContext.CourseAssignment.ToListAsync();
            }
            return courseAssignments;
        }
        #endregion

        #region METODO PARA OBTENER POR ID
        // Metodo Para Mostrar Un Registro En Base A Su Id
        public static async Task<CourseAssignment> GetByIdAsync(CourseAssignment courseAssignment)
        {
            var courseAssignmentDB = new CourseAssignment();
            using (var dbContext = new ContextDB())
            {
                courseAssignmentDB = await dbContext.CourseAssignment.FirstOrDefaultAsync(c => c.Id == courseAssignment.Id);
            }
            return courseAssignmentDB!;
        }
        #endregion

        #region METODO PARA BUSCAR REGISTROS MEDIANTE EL USO DE FILTROS
        // Metodo Para Buscar Por Filtros
        // IQueryable es una interfaz que toma un coleccion a la cual se le pueden implementar multiples consultas (Filtros)
        internal static IQueryable<CourseAssignment> QuerySelect(IQueryable<CourseAssignment> query, CourseAssignment courseAssignment)
        {
            // Por ID
            if (courseAssignment.Id > 0)
                query = query.Where(c => c.Id == courseAssignment.Id);

            // Por Estudiante
            if (courseAssignment.IdStudent > 0)
                query = query.Where(c => c.IdStudent == courseAssignment.IdStudent);

            // Por Curso
            if (courseAssignment.IdCourse > 0)
                query = query.Where(c => c.IdCourse == courseAssignment.IdCourse);

            // Ordenamos de Manera Desendente
            query = query.OrderByDescending(c => c.Id).AsQueryable();

            return query;
        }
        #endregion

        #region METODO PARA BUSCAR
        // Metodo para Buscar Registros Existentes
        public static async Task<List<CourseAssignment>> SearchAsync(CourseAssignment courseAssignment)
        {
            var courseAssignments = new List<CourseAssignment>();
            using (var dbContext = new ContextDB())
            {
                var select = dbContext.CourseAssignment.AsQueryable();
                select = QuerySelect(select, courseAssignment);
                courseAssignments = await select.ToListAsync();
            }
            return courseAssignments;
        }
        #endregion

        #region METODO PARA INCLUIR MEMBRESIA Y PRIVILEGIOS
        // Método que incluye el membresia y el privilegio para la búsqueda
        public static async Task<List<CourseAssignment>> SearchIncludeAsync(CourseAssignment courseAssignment)
        {
            var courseAssignments = new List<CourseAssignment>();
            using (var dbContext = new ContextDB())
            {
                var select = dbContext.CourseAssignment.AsQueryable();
                select = QuerySelect(select, courseAssignment).Include(c => c.Student).Include(c => c.Course).AsQueryable();
                courseAssignments = await select.ToListAsync();
            }
            return courseAssignments;
        }
        #endregion

        #region METODO PARA ELIMINAR
        // Metodo Para Eliminar Un Registro Existente En La Base De Datos
        public static async Task<int> DeleteAsync(CourseAssignment courseAssignment)
        {
            int result = 0;
            // Un bloque de conexion que mientras se permanezca en el bloque la base de datos permanecera abierta y al terminar se destruira
            using (var dbContext = new ContextDB())
            {
                var courseAssignmentDB = await dbContext.CourseAssignment.FirstOrDefaultAsync(c => c.Id == courseAssignment.Id);
                if (courseAssignmentDB != null)
                {
                    dbContext.CourseAssignment.Remove(courseAssignmentDB);
                    result = await dbContext.SaveChangesAsync();
                }
            }
            return result;
        }
        #endregion

        #region METODO PARA MODIFICAR
        // Metodo Para Modificar Un Registro Existente De La Base De Datos
        public static async Task<int> UpdateAsync(CourseAssignment courseAssignment)
        {
            int result = 0;
            using (var dbContext = new ContextDB())
            {
                var courseAssignmentDB = await dbContext.CourseAssignment.FirstOrDefaultAsync(c => c.Id == courseAssignment.Id);
                if (courseAssignmentDB != null)
                {
                    bool courseAssignmentExists = await ExistCourseAssignment(courseAssignment, dbContext);
                    if (courseAssignmentExists == false)
                    {
                        courseAssignmentDB.IdStudent = courseAssignment.IdStudent;
                        courseAssignmentDB.IdCourse = courseAssignment.IdCourse;
                        courseAssignmentDB.DateModification = courseAssignment.DateModification;

                        dbContext.Update(courseAssignmentDB);
                        result = await dbContext.SaveChangesAsync();
                    }
                    else
                    {
                        throw new Exception("Asignacion Ya Existente, Vuelve a Intentarlo Nuevamente");
                    }
                }
                else
                {
                    throw new Exception("Asignacion No Encontrada Para Actualizar.");
                }
            }
            return result;
        }
        #endregion

        #region METODO PARA OBTENER LOS 4 CURSOS CON MAS ASIGNACIONES
        public static async Task<List<CourseAssignment>> GetTopCoursesAsync()
        {
            using (var dbContext = new ContextDB())
            {
                return await dbContext.Course
                    .Select(c => new CourseAssignment
                    {
                        CourseName = c.Name,
                        AssignmentCount = dbContext.CourseAssignment.Count(a => a.IdCourse == c.Id)
                    })
                    .OrderByDescending(c => c.AssignmentCount)
                    .Take(4)
                    .ToListAsync();
            }
        }
        #endregion
    }
}
