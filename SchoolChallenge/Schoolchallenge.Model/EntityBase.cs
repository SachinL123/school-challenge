using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolChallenge.Models.Entity
{
    public class EntityBase
    {
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}