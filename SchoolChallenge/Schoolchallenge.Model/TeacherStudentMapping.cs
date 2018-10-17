using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolChallenge.Models.Entity
{
    public class TeacherStudentMapping : EntityBase
    {
        public int TeacherStudentMappingId { get; set; }
        public int TeacherId { get; set; }
        public int StudentId { get; set; }
    }
}