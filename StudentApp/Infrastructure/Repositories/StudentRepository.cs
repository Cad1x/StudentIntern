using Core.Repositories;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepositiory
    {
        private readonly StudentAppContext _context;
        public StudentRepository(StudentAppContext context) 
        {
            _context = context;
        }

        public IQueryable<Student> GetAll() 
        {
            return _context.Students;
        }

        public Student GetById(int id)
                => _context.Students.SingleOrDefault(x => x.Id == id);
        
        public Student Add(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return student;
        }

        public void Delete(Student student)
        {
            _context.Students.Remove(student);
            _context.SaveChanges();
            
        }

        public void Update(Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
        }
    }
}
