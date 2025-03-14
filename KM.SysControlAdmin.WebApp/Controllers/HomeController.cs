using KM.SysControlAdmin.BL.Course___BL;
using KM.SysControlAdmin.BL.CourseAssignment___BL;
using KM.SysControlAdmin.BL.Schedule___BL;
using KM.SysControlAdmin.BL.Student___BL;
using KM.SysControlAdmin.BL.Trainer___BL;
using KM.SysControlAdmin.BL.User___BL;
using KM.SysControlAdmin.DAL.User___DAL;
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
        UserBL userBL = new UserBL();

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
            int totalAlumnos = await studentBL.GetTotalCountAsync(); // Total de Alumnos
            var (totalbecados, totalexternos) = await studentBL.GetAlumnosByStatusAsync(); // Total de alumnos becados y externos
            var (totalmasculino, totalfemenino) = await studentBL.GetStudentsByGenderAsync(); // Total de alumnos por genero masculino y femenino
            var (totalActivosStudent, totalInactivosStudent) = await studentBL.GetTotalByStatusAsync(); // Total de alumnos por estado: Activo e Inactivo
            var (totalmenoresEdad, totalmayoresEdad) = await studentBL.GetStudentsByAgeCategoryAsync(); // Total de alumnos categorisados por edad
            var ageCategories = studentBL.GetStudentAgeCategories(); // Categorizacion de edad de los alumnos

            // Cursos
            int totalCursos = await courseBL.GetTotalCountAsync(); // Total de cursos
            var (totalActivosCourse, totalInactivosCourse) = await courseBL.GetTotalByStatusAsync(); // Total de cursos por estado: Activo e Inactivo

            // Asignacion de curso
            int totalAsignaciones = await courseAssignmentBL.GetTotalCountAsync(); // Total de asignaciones de curso
            var topCourses = await courseAssignmentBL.GetTopCoursesAsync();

            // Usuarios
            int totalUsuarios = await userBL.GetTotalCountAsync(); // Total de usuarios
            var (totalActivosUser, totalInactivosUser) = await userBL.GetTotalByStatusAsync(); // Total de usuarios por estado: Activo e Inactivo
            var usersByRole = userBL.GetUsersByRole(); // Total de usuarios segun su rol


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
            ViewData["TotalAlumnos"] = totalAlumnos; // Total de alumnos
            ViewData["TotalAlumnosBecados"] = totalbecados; // Total alumnos becados
            ViewData["TotalAlumnosExternos"] = totalexternos; // Total alumnos externos
            ViewData["TotalAlumnosMasculinos"] = totalmasculino; // Total alumnos Masculinos
            ViewData["TotalAlumnosFemeninos"] = totalfemenino; // Total alumnos femeninos
            ViewData["TotalAlumnosActivos"] = totalActivosStudent; // Total alumnos activos
            ViewData["TotalAlumnosInactivos"] = totalInactivosStudent; // Total alumnos inactivos
            ViewData["TotalMenoresEdad"] = totalmenoresEdad; // Total alumnos menores de edad
            ViewData["TotalMayoresEdad"] = totalmayoresEdad; // Total alumnos mayores de edad
            ViewData["TotalNinos"] = ageCategories["Niños (5-12)"]; // Total de alumnos niños
            ViewData["TotalAdolescentes"] = ageCategories["Adolescentes (13-17)"]; // Total de alumnos adolecentes
            ViewData["TotalJovenes"] = ageCategories["Jóvenes (18-25)"]; // Total de alumnos jovenes
            ViewData["TotalAdultos"] = ageCategories["Adultos (26+)"]; // Total de alumnos adultos

            // ViewData Cursos
            ViewData["TotalCursos"] = totalCursos; // Total de cursos
            ViewData["TotalCursosActivos"] = totalActivosCourse; // Total de cursos activos
            ViewData["TotalCursosInactivos"] = totalInactivosCourse; // Total de cursos inactivos

            // ViewData Asignacion de cursos
            ViewData["TotalAsignaciones"] = totalAsignaciones; // Total de asignaciones de cursos
            ViewData["TopCourses"] = topCourses.Select(c => c.CourseName).ToArray(); // Nombre del curso
            ViewData["Assignments"] = topCourses.Select(c => c.AssignmentCount).ToArray(); // Total de asignaciones

            // ViewData Usuarios
            ViewData["TotalUsuarios"] = totalUsuarios; // Total de usuarios
            ViewData["TotalUsuariosActivos"] = totalActivosUser; // Total de usuarios activos
            ViewData["TotalUsuariosInactivos"] = totalInactivosUser; // Total de usuarios inactivos
            ViewData["TotalAdministradores"] = usersByRole["Administradores"]; // Total de usuarios administradores
            ViewData["TotalSecretarios"] = usersByRole["Secretarios"]; // Total de usuarios secretarios
            ViewData["TotalAlumnos"] = usersByRole["Alumnos"]; // Total de usuarios alumnos
            //ViewData["TotalInvitados"] = usersByRole["Invitado"]; // Total de usuarios invitados
            ViewData["TotalInstructores"] = usersByRole["Instructores"]; // Total de usuarios invitados

            return View();
        }
    }
}
