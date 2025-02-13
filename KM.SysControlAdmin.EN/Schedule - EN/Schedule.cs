﻿#region REFERENCIAS
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Referencias Necesarias Para El Correcto Funcionamiento
using System.ComponentModel.DataAnnotations;
using KM.SysControlAdmin.EN.Course___EN;
using System.ComponentModel.DataAnnotations.Schema;

#endregion

namespace KM.SysControlAdmin.EN.Schedule___EN
{
    public class Schedule
    {
        #region ATRIBUTOS DE LA ENTIDAD
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "La hora de inicio es requerida")]
        [Display(Name = "Hora de Inicio")]
        [DataType(DataType.Time)]
        public TimeSpan StartTime { get; set; }

        [Required(ErrorMessage = "La hora de fin es requerida")]
        [Display(Name = "Hora de Finalización")]
        [DataType(DataType.Time)]
        public TimeSpan EndTime { get; set; }
        #endregion

        #region ATRIBUTOS NO MAPEABLES
        // Propiedad para formatear la hora automáticamente
        [NotMapped]
        public string StartTimeFormatted => StartTime.ToString(@"hh\:mm");
        [NotMapped]
        public string EndTimeFormatted => EndTime.ToString(@"hh\:mm");
        #endregion

        public List<Course> Course { get; set; } = new List<Course>(); // Propiedad de navegacion
    }
}
