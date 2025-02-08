using KM.SysControlAdmin.BL.Course___BL;
using KM.SysControlAdmin.BL.CourseAssignment___BL;
using KM.SysControlAdmin.BL.Student___BL;
using KM.SysControlAdmin.BL.Trainer___BL;
using KM.SysControlAdmin.WebApp.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KM.SysControlAdmin.WebApp.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Roles = "Desarrollador, Administrador, Secretario/a, Instructor/Docente, Alumno/a")]
    public class HomeController : Controller
    {
        // Creamos Una Instancia Para Acceder a Los Metodos
        StudentBL studentBL = new StudentBL();
        CourseBL courseBL = new CourseBL();
        TrainerBL trainerBL = new TrainerBL();
        CourseAssignmentBL courseAssignmentBL = new CourseAssignmentBL();

        [Authorize(Roles = "Desarrollador, Administrador, Secretario/a, Instructor/Docente, Alumno/a")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Desarrollador, Administrador")]
        public async Task<IActionResult> Dashboard()
        {
            int totalAlumnos = await studentBL.GetTotalCountAsync(); // Total de estudiantes
            int totalAlumnosActivos = await studentBL.GetActiveStudentsCountAsync(); // Total de estudiantes activos
            int totalCursosActivos = await courseBL.GetActiveCourseCountAsync();
            int totalInstructores = await trainerBL.GetTotalCountAsync();
            int totalBecados = await studentBL.GetScholarshipStudentsCountAsync();
            int totalExternos = await studentBL.GetExternalStudentsCountAsync();
            int totalCursos = await courseBL.GetCourseCountAsync();
            int totalCursosInactivos = await courseBL.GetInactiveCourseCountAsync();
            var topCourses = await courseAssignmentBL.GetTopCoursesAsync();

            ViewData["TotalAlumnos"] = totalAlumnos;
            ViewData["TotalAlumnosActivos"] = totalAlumnosActivos;
            ViewData["TotalCursosActivos"] = totalCursosActivos;
            ViewData["TotalInstructores"] = totalInstructores;
            ViewData["TotalBecados"] = totalBecados;
            ViewData["TotalExternos"] = totalExternos;
            ViewData["TotalCursos"] = totalCursos;
            ViewData["TotalCursosInactivos"] = totalCursosInactivos;
            // Pasar los datos de los cursos al ViewData para usarlos en la vista
            ViewData["TopCourses"] = topCourses.Select(c => c.CourseName).ToArray();
            ViewData["Assignments"] = topCourses.Select(c => c.AssignmentCount).ToArray();

            return View();
        }

        [AllowAnonymous]
        public IActionResult Error()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult CustomStatusCode(int code)
        {
            ViewBag.StatusCode = code;
            return View("Error");
        }
    }
}
