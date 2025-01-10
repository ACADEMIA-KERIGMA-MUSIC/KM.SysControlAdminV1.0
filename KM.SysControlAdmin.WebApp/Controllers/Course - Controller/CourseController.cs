﻿#region REFERENCIAS
// Referencias Necesarias Para El Correcto Funcionamiento
using KM.SysControlAdmin.BL.Course___BL;
using KM.SysControlAdmin.BL.Schedule___BL;
using KM.SysControlAdmin.BL.Trainer___BL;
using KM.SysControlAdmin.EN.Course___EN;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


#endregion

namespace KM.SysControlAdmin.WebApp.Controllers.Course___Controller
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Roles = "Desarrollador, Administrador, Secretario/a")]
    public class CourseController : Controller
    {
        // Creamos las instancias para acceder a los metodos
        CourseBL courseBL = new CourseBL();
        TrainerBL trainerBL = new TrainerBL();
        ScheduleBL scheduleBL = new ScheduleBL();

        #region METODO PARA CREAR
        // Accion Para Mostrar La Vista De Crear
        [Authorize(Roles = "Desarrollador, Administrador, Secretario/a")]
        public async Task<IActionResult> Create()
        {
            ViewBag.Trainers = await trainerBL.GetAllAsync();
            ViewBag.Schedule = await scheduleBL.GetAllAsync();
            ViewBag.Error = "";
            return View();
        }

        // Accion Que Recibe Los Datos Del Formulario Para Ser Enviados a La BD
        [Authorize(Roles = "Desarrollador, Administrador, Secretario/a")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Course course)
        {
            try
            {
                course.DateCreated = DateTime.Now;
                course.DateModification = DateTime.Now;
                int result = await courseBL.CreateAsync(course);
                TempData["SuccessMessageCreate"] = "Curso Agregado Exitosamente";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.Trainers = await trainerBL.GetAllAsync();
                ViewBag.Schedule = await scheduleBL.GetAllAsync();
                return View(course);
            }
        }
        #endregion

        #region METODO PARA MOSTRAR INDEX
        // Accion Para Mostrar La Vista Index
        [Authorize(Roles = "Desarrollador, Administrador, Secretario/a")]
        public async Task<IActionResult> Index(Course course = null!)
        {
            if (course == null)
                course = new Course();

            var courses = await courseBL.SearchIncludeScheduleAndTrainerAsync(course);
            var trainer = await trainerBL.GetAllAsync();
            var schedule = await scheduleBL.GetAllAsync();

            ViewBag.Trainers = trainer;
            ViewBag.Schedule = schedule;
            return View(courses);
        }
        #endregion

        #region METODO PARA MODIFICAR
        // Acción que muestra la vista de modificar
        [Authorize(Roles = "Desarrollador, Administrador, Secretario/a")]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                Course course = await courseBL.GetByIdAsync(new Course { Id = id });
                if (course == null)
                {
                    return NotFound();
                }
                ViewBag.Trainers = await trainerBL.GetAllAsync();
                ViewBag.Schedule = await scheduleBL.GetAllAsync();
                return View(course);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // Acción que recibe los datos del formulario para ser enviados a la base de datos
        [Authorize(Roles = "Desarrollador, Administrador, Secretario/a")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Course course)
        {
            try
            {
                if (id != course.Id)
                {
                    return BadRequest();
                }
                course.DateModification = DateTime.Now;
                int result = await courseBL.UpdateAsync(course);
                TempData["SuccessMessageUpdate"] = "Curso Modificado Exitosamente";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.Trainers = await trainerBL.GetAllAsync();
                ViewBag.Schedule = await scheduleBL.GetAllAsync();
                return View(course);
            }
        }
        #endregion
    }
}
