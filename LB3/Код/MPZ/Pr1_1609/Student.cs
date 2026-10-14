using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr1_1609
{
    public class Student : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public int GroupId { get; set; }
        public Student(string firstName, string lastName, int age, int groupId)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            GroupId = groupId;
        }
        public override string ToString()
        {
            return $"{Id} {FirstName} {LastName} {Age} {GroupId}";
        }
    }
}
