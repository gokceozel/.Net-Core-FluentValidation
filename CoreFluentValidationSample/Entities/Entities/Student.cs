using System.Collections.Generic;

namespace Data.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int  Age { get; set; }
        public ICollection<Address> Address { get; set; }
    }
}
