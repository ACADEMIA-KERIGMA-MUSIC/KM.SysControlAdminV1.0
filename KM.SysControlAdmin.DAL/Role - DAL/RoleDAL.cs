#region REFERENCIAS
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Referencias Necesarias Para El Corrrecto Funcionamiento
using KM.SysControlAdmin.EN.Role___EN;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

#endregion

namespace KM.SysControlAdmin.DAL.Role___DAL
{
    public class RoleDAL
    {
        #region METODO PARA VALIDAR UNICA EXISTENCIA DEL REGISTRO
        // Metodo Para Validar La Unica Existencia De Un Registro y No Haber Duplicidad
        private static async Task<bool> ExistRol(Role role, ContextDB dbContext)
        {
            bool result = false;
            var roles = await dbContext.Role.FirstOrDefaultAsync(r => r.Name == role.Name && r.Id != role.Id);
            if (roles != null && roles.Id > 0 && roles.Name == role.Name)
                result = true;
            return result;
        }
        #endregion

        #region METODO PARA VALIDAR CARACTERES PERMITIDOS EN EL NOMBRE DEL ROL
        // Metodo Para Validar Los Caracteres Permitidos En El Nombre Del Rol
        private static void ValidateRoleCharacters(string nameRol)
        {
            // Validación de que el nombre del rol solo contiene letras
            if (!Regex.IsMatch(nameRol, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ/ ]+$"))
            {
                throw new Exception("Debes Ingresar Unicamente Letras");
            }
        }
        #endregion

        #region METODO PARA GUARDAR
        // Metodo Para Guardar Un Nuevo Registro En La Base De Datos
        public static async Task<int> CreateAsync(Role role)
        {
            int result = 0;
            using (var dbContext = new ContextDB())
            {
                ValidateRoleCharacters(role.Name);
                bool rolExists = await ExistRol(role, dbContext);
                if (rolExists == false)
                {
                    dbContext.Role.Add(role);
                    result = await dbContext.SaveChangesAsync();
                }
                else
                    throw new Exception("Rol Ya Existente, Vuelve a Intentarlo");
            }
            return result;
        }
        #endregion
    }
}
