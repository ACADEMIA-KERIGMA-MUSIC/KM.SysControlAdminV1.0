#region REFERENCIAS
// Referencias Necesarias Para El Correcto Funcionamiento
using KM.SysControlAdmin.BL.Student___BL;
using KM.SysControlAdmin.BL.User___BL;
using KM.SysControlAdmin.EN.Student___EN;
using KM.SysControlAdmin.EN.User___EN;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace KM.SysControlAdmin.WebApp.Controllers.Student___Controller
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Roles = "Desarrollador, Administrador, Secretario/a")]
    public class StudentController : Controller
    {
        // Creamos Una Instancia Para Acceder a Los Metodos
        StudentBL studentBL = new StudentBL();
        UserBL userBL = new UserBL();

        #region METODO PARA CREAR (ALUMNO BECADO)
        // Accion Para Mostrar La Vista De Crear
        [Authorize(Roles = "Desarrollador, Administrador, Secretario/a")]
        public ActionResult CreateScholarshipForm()
        {
            ViewBag.Error = "";
            return View();
        }

        // Accion Que Recibe Los Datos Del Formulario Para Ser Enviados a La BD
        [Authorize(Roles = "Desarrollador, Administrador, Secretario/a")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateScholarshipForm(Student student, IFormFile imagen)
        {
            try
            {
                // Mapeo de img a ArrayByte
                if (imagen != null && imagen.Length > 0)
                {
                    byte[] imagenData = null!;
                    using (var memoryStream = new MemoryStream())
                    {
                        await imagen.CopyToAsync(memoryStream);
                        imagenData = memoryStream.ToArray();
                    }
                    student.ImageData = imagenData; // Asigna el array de bytes al campo de la imagen en tu modelo Membership
                }
                student.DateCreated = DateTime.Now;
                student.DateModification = DateTime.Now;
                if (student.ProjectCode != "" && student.ParticipantCode != "")
                {
                    int result = await studentBL.CreateAsync(student);
                }

                // Crear un nuevo objeto de tipo User y mapear las propiedades de Trainer con Server
                var user = new User
                {
                    IdRole = 4,
                    Name = student.Name,
                    LastName = student.LastName,
                    Email = student.Email,
                    Password = student.Password,
                    Status = student.Status,
                    DateCreated = student.DateCreated,
                    DateModification = student.DateModification,
                    ImageData = student.ImageData,
                };

                // Guardar en la tabla User
                if (student.ProjectCode != "" && student.ParticipantCode != "")
                {
                    int resultUser = await userBL.CreateAsync(user);
                }
                TempData["SuccessMessageCreate"] = "Estudiante Agregado Exitosamente";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(student);
            }
        }
        #endregion

        #region METODO PARA CREAR (ALUMNO EXTERNO)
        // Accion Para Mostrar La Vista De Crear
        [Authorize(Roles = "Desarrollador, Administrador, Secretario/a")]
        public ActionResult CreateExternalForm()
        {
            ViewBag.Error = "";
            return View();
        }

        // Accion Que Recibe Los Datos Del Formulario Para Ser Enviados a La BD
        [Authorize(Roles = "Desarrollador, Administrador, Secretario/a")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCreateExternalFormForm1(Student student, IFormFile imagen)
        {
            try
            {
                // Mapeo de img a ArrayByte
                if (imagen != null && imagen.Length > 0)
                {
                    byte[] imagenData = null!;
                    using (var memoryStream = new MemoryStream())
                    {
                        await imagen.CopyToAsync(memoryStream);
                        imagenData = memoryStream.ToArray();
                    }
                    student.ImageData = imagenData; // Asigna el array de bytes al campo de la imagen en tu modelo Membership
                }
                student.DateCreated = DateTime.Now;
                student.DateModification = DateTime.Now;
                int result = await studentBL.CreateAsync(student);

                // Crear un nuevo objeto de tipo User y mapear las propiedades de Trainer con Server
                var user = new User
                {
                    IdRole = 4,
                    Name = student.Name,
                    LastName = student.LastName,
                    Email = student.Email,
                    Password = student.Password,
                    Status = student.Status,
                    DateCreated = student.DateCreated,
                    DateModification = student.DateModification,
                    ImageData = student.ImageData,
                };

                // Guardar en la tabla User
                int resultUser = await userBL.CreateAsync(user);
                TempData["SuccessMessageCreate"] = "Estudiante Agregado Exitosamente";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(student);
            }
        }
        #endregion
    }
}
