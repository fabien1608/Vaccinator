using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Vaccinator.Models
{
    public class Vaccin
    {
        public int Id { get; set; }

        [MaxLength(30)]
        [Display(Name = "Type de Vaccin")]
        [Required]
        public string TypeV { get; set; }
    }
}
