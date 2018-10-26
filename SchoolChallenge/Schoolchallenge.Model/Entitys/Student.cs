using SchoolChallenge.Models.Entity;

namespace SchoolChallenge.Models
{
    /// <summary>
    /// Student object
    /// </summary>
    public class Student : EntityBase
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool HasScholarship { get; set; }        
    }
}