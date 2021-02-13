using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDay { get; set; }
        //public Grade Grade { get; set; }
        public Address Address { get; set; }
        public Gender Gender { get; set; }
    }
}
