using SchoolChallenge.Models.Entity;

namespace SchoolChallenge.Models
{
    public class Teacher : EntityBase
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}