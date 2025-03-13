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
            int totalHorarios = await scheduleBL.GetTotalCountAsync(); // Total de horarios
            int totalHorariosActivos = await scheduleBL.GetTotalActiveScheduleAsync(); // Total de horarios activos
            int totalHorariosInactivos = await scheduleBL.GetTotalInactiveScheduleAsync(); // Total de horarios inactivos

            ViewData["TotalHorarios"] = totalHorarios; // Total de horarios
            ViewData["TotalHorariosActivos"] = totalHorariosActivos; // Total de horarios activos
            ViewData["TotalHorariosInactivos"] = totalHorariosInactivos; // Total de horarios inactivos


            return View();
        }
    }
}
