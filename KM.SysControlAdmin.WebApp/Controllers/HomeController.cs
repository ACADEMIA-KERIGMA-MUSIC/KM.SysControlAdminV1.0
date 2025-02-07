using KM.SysControlAdmin.BL.Course___BL;
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

            ViewData["TotalAlumnos"] = totalAlumnos;
            ViewData["TotalAlumnosActivos"] = totalAlumnosActivos;
            ViewData["TotalCursosActivos"] = totalCursosActivos;
            ViewData["TotalInstructores"] = totalInstructores;
            ViewData["TotalBecados"] = totalBecados;
            ViewData["TotalExternos"] = totalExternos;
            ViewData["TotalCursos"] = totalCursos;
            ViewData["TotalCursosInactivos"] = totalCursosInactivos;

            return View();
        }
    }
}
