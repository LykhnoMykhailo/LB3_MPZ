using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr1_1609
{
    public class GroupSubject : IEntity
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int SubjectID { get; set; }

        public GroupSubject(int groupId, int subjectID)
        {
            GroupId = groupId;
            SubjectID = subjectID;
        }
        public override string ToString()
        {
            return $"{Id} {GroupId} {SubjectID}";
        }
    }
}
