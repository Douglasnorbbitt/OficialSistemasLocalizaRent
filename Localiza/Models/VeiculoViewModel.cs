using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Localiza.Models
{
    public class VeiculoViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} é requerido")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "{0} é requerido")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "{0} é requerido")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "{0} é requerido")]
        public string Quilometragem { get; set; }
    }
}
