﻿#region REFERENCIAS
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Referencias Necesarias Para El Correcto Funcionamiento
using KM.SysControlAdmin.DAL.Student___DAL;
using KM.SysControlAdmin.EN.Student___EN;

#endregion

namespace KM.SysControlAdmin.BL.Student___BL
{
    public class StudentBL
    {
        #region METODO PARA CREAR
        // Metodo Para Guardar Un Nuevo Registro
        public async Task<int> CreateAsync(Student student)
        {
            return await StudentDAL.CreateAsync(student);
        }
        #endregion

        #region METODO PARA MOSTRAR
        // Metodo Para Mostrar Una Lista De Registros
        public async Task<List<Student>> GetAllAsync()
        {
            return await StudentDAL.GetAllAsync();
        }
        #endregion

        #region METODO PARA MOSTRAR POR ID
        // Metodo Para Mostrar Un Registro Especifico Bajo Un Id
        public async Task<Student> GetByIdAsync(Student student)
        {
            return await StudentDAL.GetByIdAsync(student);
        }

        // Metodo para que admita int al hacer uso del metodo antecesor para automatizacion
        public async Task<Student> GetByIdAsync(int id)
        {
            // Crear una instancia de Membership y asignarle el ID
            var student = new Student { Id = id };

            // Llamar al método existente con el objeto Membership
            return await StudentDAL.GetByIdAsync(student);
        }
        #endregion

        #region METODO PARA BUSCAR
        // Metodo Para Buscar Registros Existentes
        public async Task<List<Student>> SearchAsync(Student student)
        {
            return await StudentDAL.SearchAsync(student);
        }
        #endregion

        #region METODO PARA MODIFICAR
        // Metodo Para Guardar Un Nuevo Registro
        public async Task<int> UpdateAsync(Student student)
        {
            return await StudentDAL.UpdateAsync(student);
        }
        #endregion

        #region METODO PARA ELIMINAR
        // Metodo Para Eliminar Un Registro Existente En La Base De Datos
        public async Task<int> DeleteAsync(Student student)
        {
            return await StudentDAL.DeleteAsync(student);
        }
        #endregion

        #region METODO PARA OBTENER LA CANTIDAD DE ESTUDIANTES
        // Método para obtener la cantidad total de estudiantes
        public async Task<int> GetTotalCountAsync()
        {
            return await StudentDAL.GetTotalCountAsync();
        }
        #endregion

        #region METODO PARA OBTENER LA CANTIDAD DE ALUMNOS ACTIVOS
        // Método para obtener la cantidad de alumnos activos
        public async Task<int> GetActiveStudentsCountAsync()
        {
            return await StudentDAL.GetActiveStudentsCountAsync();
        }
        #endregion

        #region METODO PARA OBTENER LA CANTIDAD DE ALUMNOS BECADOS
        // Método para obtener la cantidad de alumnos becados
        public async Task<int> GetScholarshipStudentsCountAsync()
        {
            return await StudentDAL.GetScholarshipStudentsCountAsync();
        }
        #endregion

        #region METODO PARA OBTENER LA CANTIDAD DE ALUMNOS EXTERNOS
        // Método para obtener la cantidad de alumnos externos
        public async Task<int> GetExternalStudentsCountAsync()
        {
            return await StudentDAL.GetExternalStudentsCountAsync();
        }
        #endregion
    }
}