using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr1_1609
{
    public class Address:IEntity
    {
        public int Id {  get; set; }

        public string StudentAdrress { get; set; }

        public int StudentId {  get; set; }

        public Address(string studentAdrress, int studentId)
        {
            StudentAdrress = studentAdrress;
            StudentId = studentId;
        }
        public override string ToString()
        {
            return $"{Id} {StudentAdrress} {StudentId}";
        }
    }
}
