using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Pr1_1609
{
    public class DepartmentServyses
    {
        DB db;

        public DepartmentServyses(DB db)
        {
            this.db = db;
        }

        public void GetAllInformationAboutStudients()
        {
            foreach (Student student in db.DBStudent.Items)
            {
                Console.WriteLine(student);
                foreach (Address adrress in db.DBAdrress.Items)
                {
                    if (student.Id == adrress.StudentId)
                    {
                        Console.WriteLine("\t" + adrress);
                    }
                }
                foreach (Group group in db.DBGroup.Items)
                {
                    if (student.GroupId == group.Id)
                    {
                        Console.WriteLine("\t" + group);
                        foreach (GroupSubject groupSubject in db.DBgroupSubject.Items)
                        {
                            if (groupSubject.GroupId == group.Id)
                            {
                                foreach (Subject subject in db.DBSubject.Items)
                                {
                                    if (subject.Id == groupSubject.SubjectID)
                                    {
                                        Console.WriteLine("\t\t" + subject);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
