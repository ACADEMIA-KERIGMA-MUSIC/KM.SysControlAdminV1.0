#region REFERENCIAS
// Referencias Necesarias Para El Correcto Funcionamiento
using KM.SysControlAdmin.BL.Role___BL;
using KM.SysControlAdmin.EN.Role___EN;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


#endregion

namespace KM.SysControlAdmin.WebApp.Controllers.Role___Controller
{
    public class RoleController : Controller
    {
        // Creamos Las Instancias Para Acceder a Los Metodos
        RoleBL roleBL = new RoleBL();

        #region METODO PARA GUARDAR
        // Metodo Para Mostrar La Vista Guardar
        //[Authorize(Roles = "Desarrollador")]
        public IActionResult Create()
        {
            ViewBag.Error = "";
            return View();
        }

        // Metodo Que Recibe y Envia a La Base De Datos
        //[Authorize(Roles = "Desarrollador")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Role role)
        {
            try
            {
                int result = await roleBL.CreateAsync(role);
                TempData["SuccessMessageCreate"] = "Rol Agregado Exitosamente";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(role);
            }
        }
        #endregion
    }
}
