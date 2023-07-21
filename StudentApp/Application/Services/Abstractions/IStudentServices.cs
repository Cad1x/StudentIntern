using Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Abstractions
{
    public interface IStudentServices
    {
        ListStudentDto GetAllStudent();
        StudentDetailDto GetStudentById(int id);
        StudentDto CreateStudent(CreateStudentDto newStudent);
        void UpdateStudent(UpdateStudentDto updateStudent);  
        void DeleteStudent(int id);


    }
}
