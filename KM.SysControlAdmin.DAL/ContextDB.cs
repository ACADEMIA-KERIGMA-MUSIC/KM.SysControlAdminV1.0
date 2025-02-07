﻿#region REFERENCIAS
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Referencias Necesarias Para El Correcto Funcionamiento
using Microsoft.EntityFrameworkCore;
using KM.SysControlAdmin.EN.Role___EN;
using KM.SysControlAdmin.EN.User___EN;
using KM.SysControlAdmin.EN.Schedule___EN;
using KM.SysControlAdmin.EN.Trainer___EN;
using KM.SysControlAdmin.EN.Course___EN;
using KM.SysControlAdmin.EN.Student___EN;
using KM.SysControlAdmin.EN.CourseAssignment___EN;


#endregion

namespace KM.SysControlAdmin.DAL
{
    public class ContextDB : DbContext
    {
        #region REFERENCIAS DE TABLAS DE LA BD
        //Coleccion que hace referencia a las tablas de la base de datos
        public DbSet<Role> Role { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Schedule> Schedule { get; set; }
        public DbSet<Trainer> Trainer { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<CourseAssignment> CourseAssignment { get; set; }
        #endregion

        #region STRING DE CONEXION
        // Metodo de Conexion a la Base de Datos
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=192.250.231.31;Initial Catalog=KMSysControlAdminDB;User=eliqsv_asistenciaAdmin;Password=m3929&kDd;Trust Server Certificate=True"); // String de Conexion
        }
        #endregion
    }
}
