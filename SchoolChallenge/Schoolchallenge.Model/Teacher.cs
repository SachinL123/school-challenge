using SchoolChallenge.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolChallenge.Models
{
    public class Teacher : EntityBase
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}