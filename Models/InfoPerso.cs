using System.Collections.Specialized;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TPLOCAL1.Models;
namespace TPLOCAL1.Models
{
    public class InfoPerso
    {
        [Required(ErrorMessage = "Veuillez introduire un Nom.")]
        public string Nom { get; set; }
        [Required(ErrorMessage = "Veuillez introduire un Prénom.")]
        public string? Prenom { get; set; }
        [Required(ErrorMessage = "Veuillez choisir le Sexe.")]
        public string? Sexe { get; set; }
        [Required(ErrorMessage = "Veuillez introduire une Adresse.")]
        public string? Adresse { get; set; }
        [Required(ErrorMessage = "Veuillez introduire un Code Postal.")]
        [RegularExpression(@"^\d{5}$", ErrorMessage = "Le Code Postal doit comporter exactement 5 chiffres.")]
        public string? CodePostal { get; set; }
        [Required(ErrorMessage = "Veuillez introduire une Ville.")]
        public string? Ville { get; set; }
        [Required(ErrorMessage = "Veuillez introduire une Adresse Mail.")]
        [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$", ErrorMessage = "Le Format du Mail n'est pas Valide")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Veuillez choisir une Date de début de Formation .")]
        [Range(typeof(DateTime), "", "1/1/2021", ErrorMessage = "La date doit être antérieure au 01/01/2021.")]
        public DateTime? Date { get; set; }
        [Required(ErrorMessage = "Veuillez choisir une Formation Suivie.")]
        public string? Cours { get; set; }
     
        public string? Cobol { get; set; }
        public string? CSharp { get; set; }


        public static List<string> SexeOption { get; } = new List<string> { "Homme", "Femme", "Autre" };
        public static List<string> CoursOption { get; } = new List<string> { "Formation Cobol", "Formation par objet", "Formation à double compétence" };
    }
}
