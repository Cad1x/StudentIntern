using System;
using System.ComponentModel.DataAnnotations;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Praktyki2022.Model
{
    public class Student 
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Imię jest wymagane.")]
        [StringLength(50, ErrorMessage = "Imię nie może przekraczać 50 znaków.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Nazwisko jest wymagane.")]
        [StringLength(50, ErrorMessage = "Nazwisko nie może przekraczać 50 znaków.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Adres email jest wymagany.")]
        [StringLength(100, ErrorMessage = "Adres email nie może przekraczać 100 znaków.")]
        [EmailAddress(ErrorMessage = "Niepoprawny format adresu email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Data urodzenia jest wymagana.")]
        [MinimumAge(18, ErrorMessage = "Student musi mieć skończone 18 lat.")]
        public DateOnly DateOfBirth { get; set; }

        [Required(ErrorMessage = "Rok rejestracji na studia jest wymagany.")]
        public int StudyStartYear { get; set; }
    }
}