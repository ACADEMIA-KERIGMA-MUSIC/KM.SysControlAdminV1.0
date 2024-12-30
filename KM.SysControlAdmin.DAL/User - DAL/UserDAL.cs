#region REFERENCIAS
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// Referencias Necesarias Para El Correcto Funcionamiento
using System.Security.Cryptography;
using System.Text;
using KM.SysControlAdmin.EN.User___EN;
using Microsoft.EntityFrameworkCore;


#endregion

namespace KM.SysControlAdmin.DAL.User___DAL
{
    public class UserDAL
    {
        #region METODO PARA ENCRIPTAR
        // Metodo Para Encriptar Via MD5 El Password
        private static void EncryptMD5(User user)
        {
            using (var md5 = MD5.Create())
            {
                var result = md5.ComputeHash(Encoding.ASCII.GetBytes(user.Password));
                var encryptedStr = "";
                for (int i = 0; i < result.Length; i++)
                {
                    encryptedStr += result[i].ToString("x2").ToLower();
                }
                user.Password = encryptedStr;
            }
        }
        #endregion

        #region METODO PARA VALIDAR EXISTENCIA DEL USUARIO
        // Metodo Para Validar La Existencia o No De Un Usuario
        private static async Task<bool> ExistsUser(User user, ContextDB dbContext)
        {
            bool result = false;
            var userLoginExists = await dbContext.User.FirstOrDefaultAsync(u => u.Email == user.Email && u.Id != user.Id);
            if (userLoginExists != null && userLoginExists.Id > 0 && userLoginExists.Email == user.Email)
                result = true;

            return result;
        }
        #endregion

        #region METODO PARA GUARDAR
        // Metodo Para Guardar Un Nuevo Registro En La Base De Datos
        public static async Task<int> CreateAsync(User user)
        {
            int result = 0;
            using (var dbContext = new ContextDB())
            {
                bool UserExists = await ExistsUser(user, dbContext);
                if (UserExists == false)
                {
                    user.DateCreated = DateTime.Now;
                    user.DateModification = DateTime.Now;
                    EncryptMD5(user);
                    dbContext.User.Add(user);
                    result = await dbContext.SaveChangesAsync();
                }
                else
                    throw new Exception("Usuario Ya Existente, Vuelve a Intentarlo.");
            }
            return result;
        }
        #endregion
    }
}
