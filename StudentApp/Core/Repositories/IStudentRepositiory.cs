using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IStudentRepositiory
    {
        Student GetById(int id);
        IQueryable<Student> GetAll();
        Student Add(Student student);
        void Update (Student student);
        void Delete(Student student);
    }
}
