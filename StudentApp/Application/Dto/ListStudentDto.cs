using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class ListStudentDto
    {
        public int Count { get; set; } 
        public IEnumerable<StudentDto> Students { get; set; }
    }
}
