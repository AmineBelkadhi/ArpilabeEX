using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ArpilabeApp.Models
{
    public partial class Personne
    {
        public int Id { get; set; }

        [Required]
        public string Nom { get; set; }

        [Required]
        public string Prenom { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string NumTel { get; set; }

        public string Note { get; set; }

        [Required]
        public string Departement { get; set; }

        public string DateNaissance { get; set; }
    }
}
