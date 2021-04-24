using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;

namespace Models
{
    public class AttendanceCourseIdModel
    {
        public List<Attendance> Attendances { get; set; }
        public SelectList Id { get; set; }
        public string AttendanceId { get; set; }
        public string SearchString { get; set; }
    }
}
