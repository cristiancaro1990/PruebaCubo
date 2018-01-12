using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PruebaSumatoriaCubo.Web.Models.ViewModels
{
    public class InicioViewModel
    {
        /// <summary>
        /// Operaciones
        /// </summary>
        [DataType(DataType.MultilineText)]
        [Display(Name = "Operaciones")]
        public string Operaciones { get; set; }

        /// <summary>
        /// Operaciones
        /// </summary>
        [DataType(DataType.MultilineText)]
        [Display(Name = "Salida")]
        public string Salida { get; set; }
    }
}