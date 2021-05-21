using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class TeacherCourseVM
    {
        public List<Course> courses { get; set; }

        public string SearchString { get; set; }
    }
}
