using Application.Dto;
using Application.Validators.Abstractions;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Application.Validators
{
    public class StudentValidator : IStudentValidator
    {
        private readonly IStudentRepositiory _studentRepositiory;

        public StudentValidator(IStudentRepositiory studentRepositiory)
        {
            _studentRepositiory = studentRepositiory;
        }

        public void Validate(CreateStudentDto student)
        {
            ValidateFirstName(student.FirstName);
            ValidateLastName(student.LastName);
            ValidateEmail(student.Email);
            ValidateDateOfBirth(student.DateOfBirth);
            ValidateStudyStartYear(student.StudyStartYear);
        }

        public void Validate(UpdateStudentDto student)
        {
            IsExist(student.Id);
            ValidateFirstName(student.FirstName);
            ValidateLastName(student.LastName);
            ValidateEmail(student.Email);
            ValidateDateOfBirth(student.DateOfBirth);
            ValidateStudyStartYear(student.StudyStartYear);

        }

        private void ValidateStudyStartYear(int? studyStartYear)
        {
            if (!studyStartYear.HasValue)
            {
                throw new Exception("Rok rozpoczęcia studiów jest wymagany.");
            }
        }

        private void ValidateDateOfBirth(DateOnly? dateOfBirth)
        {
            if (!dateOfBirth.HasValue)
            {
                throw new Exception("Data urodzenia jest wymagana.");
            }

            DateOnly today = DateOnly.FromDateTime(DateTime.Today);
            DateOnly minDateOfBirth = today.AddYears(-18);

            if (dateOfBirth > minDateOfBirth)
            {
                throw new Exception("Osoba musi mieć co najmniej 18 lat.");
            }
        }

        private void ValidateEmail(string email)
        {
            ValidateString(email, "Email", 100);

            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            if (!Regex.IsMatch(email, emailPattern))
            {
                throw new Exception("Nieprawidłowy format adresu email.");
            }
        }


        private void ValidateLastName(string lastName)
        {
            ValidateString(lastName, "Nazwisko", 50);
        }

        private void ValidateFirstName(string firstName)
        {
            ValidateString(firstName, "Imię", 50);

        }

       

        public void Validate(int studentId)
        {
            IsExist(studentId);  
        }

        private void IsExist(int id)
        {
            var student = _studentRepositiory.GetById(id);
            if (student is null) 
            {
                throw new Exception($"Student with ID {id} does not exist.");

            }
        }


        public static void ValidateString(string value, string field, int maxLength)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new Exception($"{field} jest wymagane.");
            }

            if (value.Length > maxLength)
            {
                throw new Exception($"{field} nie może przekraczać {maxLength} znaków.");
            }
        }




    }
}
