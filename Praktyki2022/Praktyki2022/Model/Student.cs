using System.ComponentModel.DataAnnotations.Schema;

namespace Praktyki2022.Model
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }   
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int StudyStartYear { get; set; }
        
        

    }
}
