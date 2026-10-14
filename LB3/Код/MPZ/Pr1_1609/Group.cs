using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr1_1609
{
    public class Group : IEntity
    {
        public int Id { get; set; }
        public string GroupName { get; set; }

        public Group(string groupName)
        {
            GroupName = groupName;
        }
        public override string ToString()
        {
            return $"{Id} {GroupName}";
        }
    }
}
