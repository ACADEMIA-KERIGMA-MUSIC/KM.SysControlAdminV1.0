using KM.SysControlAdmin.BL.Course___BL;
using KM.SysControlAdmin.BL.CourseAssignment___BL;
using KM.SysControlAdmin.BL.Schedule___BL;
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
        ScheduleBL scheduleBL = new ScheduleBL();

        [Authorize(Roles = "Desarrollador, Administrador, Secretario/a, Instructor/Docente, Alumno/a")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Desarrollador, Administrador")]
        public async Task<IActionResult> Dashboard()
        {
            // Horarios
            int totalHorarios = await scheduleBL.GetTotalCountAsync(); // Total de horarios
            int totalHorariosActivos = await scheduleBL.GetTotalActiveScheduleAsync(); // Total de horarios activos
            int totalHorariosInactivos = await scheduleBL.GetTotalInactiveScheduleAsync(); // Total de horarios inactivos

            // Instructores
            int totalInstructores = await trainerBL.GetTotalCountAsync(); // Total de instructores
            var (totalMasculino, totalFemenino) = await trainerBL.GetTotalGenderAsync(); // Total de instructores por genero: masculino y femenino
            var (totalActivos, totalInactivos) = await trainerBL.GetTotalByStatusAsync(); // Total de instructores por estado: Activo e Inactivo

            // Alumnos


            // ViewData Horarios
            ViewData["TotalHorarios"] = totalHorarios; // Total de horarios
            ViewData["TotalHorariosActivos"] = totalHorariosActivos; // Total de horarios activos
            ViewData["TotalHorariosInactivos"] = totalHorariosInactivos; // Total de horarios inactivos

            // ViewData Instructores
            ViewData["TotalInstructores"] = totalInstructores; // Total de instructores
            ViewData["TotalInstructoresMasculinos"] = totalMasculino; // Total de instructores por genero masculino
            ViewData["TotalInstructoresFemeninos"] = totalFemenino; // Total de instructores por genero femenino
            ViewData["TotalInstructoresActivos"] = totalActivos; // Total de instructores por estado activo
            ViewData["TotalInstructoresInactivos"] = totalInactivos; // Total de instructores por estado inactivo

            // ViewData Alumnos


            return View();
        }
    }
}
