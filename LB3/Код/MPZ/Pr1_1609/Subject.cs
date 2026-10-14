using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Pr1_1609
{
    public class Subject : IEntity
    {
        public int Id { get; set; }
        public string SubjectName { get; set; }
        public int Hour {  get; set; }

        public Subject(string subjectName, int hour)
        {
            SubjectName = subjectName;
            Hour = hour;
        }
        public override string ToString()
        {
            return $"{Id} {SubjectName} {Hour}";
        }
    }
}
