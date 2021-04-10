using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vaccinator.Models
{

    public enum Sexe
    {
        Homme,
        Femme
    }

    public enum Residence
    {
        Resident,
        Personnel
    }

    public class Personne
    {   
        public int  Id {get; set;}

        [MaxLength(25)]
        [Display(Name = "Nom de Famille")]
        [Required]
        public string Nom { get; set; }

        [MaxLength(25)]
        [Display(Name = "Prénom")]
        [Required]
        public string Prenom { get; set; }

        [Display(Name = "Date de naissance")]
        [Required]
        public  DateTime DateDeNaissance { get; set; }

        [Required]
        [EnumDataType(typeof(Sexe))]
        public virtual Sexe sexe { get; set; }

        [Required]
        [EnumDataType(typeof(Residence))]
        public virtual Residence residence { get; set; }

    }
}
