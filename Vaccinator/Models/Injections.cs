using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Vaccinator.Models
{
    public class Injection
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "N° du lot")]
        public int Lot { get; set; }

        [Required]
        [Display(Name = "Marque du vaccin")]
        [MaxLength(30)]
        public string Marque { get; set; }

        [Display(Name = "Date de la première injection")]
        [Required]
        public DateTime DatePremier { get; set; }

        [Display(Name = "Date du Rappel")]
        [Required]
        public DateTime DateRappel { get; set; }

        [Required]
        public virtual Personne Personne { get; set; }

        [Required]
        public virtual Vaccin Vaccin { get; set; }



    }
}

