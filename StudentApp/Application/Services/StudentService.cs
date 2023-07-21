using Application.Dto;
using Application.Services.Abstractions;
using Application.Validators.Abstractions;
using AutoMapper;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class StudentService : IStudentServices
    {
        private readonly IStudentRepositiory _studentRepository;
        private readonly IStudentValidator _studentValidator;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepositiory studentRepositiory, IStudentValidator studentValidator, IMapper mapper)
        {
            _studentRepository = studentRepositiory;
            _studentValidator = studentValidator;
            _mapper = mapper;
        }

        public ListStudentDto GetAllStudent()
        {
            var students = _studentRepository.GetAll();
            return _mapper.Map<ListStudentDto>(students);
        }


        public StudentDetailDto GetStudentById(int id)
        {
            var student= _studentRepository.GetById(id);
            return _mapper.Map<StudentDetailDto>(student);
        }


        public StudentDto CreateStudent(CreateStudentDto newStudent)
        {
            _studentValidator.Validate(newStudent);
            var student = _mapper.Map<Student>(newStudent);
            _studentRepository.Add(student);
            return _mapper.Map<StudentDto>(student);
        }

        public void UpdateStudent(UpdateStudentDto updateStudent)
        {
            _studentValidator.Validate(updateStudent);
            var existingStudent = _studentRepository.GetById(updateStudent.Id);
            var student = _mapper.Map(updateStudent, existingStudent);
            _studentRepository.Update(student);
        }

        public void DeleteStudent(int id)
        {
            _studentValidator.Validate(id);
            var student = _studentRepository.GetById(id);
            _studentRepository.Delete(student);
        }

        
    }
}
