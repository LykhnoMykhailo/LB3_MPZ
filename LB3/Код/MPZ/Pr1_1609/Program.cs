using System.Security.Claims;
using System.Threading.Channels;

namespace Pr1_1609
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student student1 = new Student("Іван", "Петренко", 18,2);
            Student student2 = new Student("Петро", "Романенко", 19,2);
            Student student3 = new Student("Роман", "Василенко", 20,1 );
            DBItem<Student> DBStudent = new DBItem<Student>();
            DBStudent.AddItem(student1);
            DBStudent.AddItem(student2);
            DBStudent.AddItem(student3);

            Address address1 = new Address("Київ", 3);
            Address address2 = new Address("Черкаси",1);
            Address address3 = new Address("Полтава",2);

            DBItem<Address> DBAdrress = new DBItem<Address>();
            DBAdrress.AddItem(address1);
            DBAdrress.AddItem(address2);
            DBAdrress.AddItem(address3);

            Group group1 = new Group("ІПЗ-34");
            Group group2 = new Group("ІПЗ-35");
            DBItem<Group> DBGroup = new DBItem<Group>();
            DBGroup.AddItem(group1);
            DBGroup.AddItem(group2);

            Subject subject1 = new Subject("Програмування", 100);
            Subject subject2 = new Subject("Математика", 200);
            Subject subject3 = new Subject("Англійська мова", 300);

            DBItem<Subject> DBSubject = new DBItem<Subject>();
            DBSubject.AddItem(subject1);     
            DBSubject.AddItem(subject2);
            DBSubject.AddItem(subject3);


            GroupSubject groupSubject1 = new GroupSubject(1, 2);
            GroupSubject groupSubject2 = new GroupSubject(1, 3);
            GroupSubject groupSubject3 = new GroupSubject(2, 1);
            GroupSubject groupSubject4 = new GroupSubject(2, 2);
            DBItem<GroupSubject> DBgroupSubject = new DBItem<GroupSubject>();
            DBgroupSubject.AddItem(groupSubject1);
            DBgroupSubject.AddItem(groupSubject2);
            DBgroupSubject.AddItem(groupSubject3);
            DBgroupSubject.AddItem(groupSubject4);


            foreach (Student student in DBStudent.Items)
            {
                Console.WriteLine(student);
                foreach (Address adrress in DBAdrress.Items)
                {
                    if (student.Id == adrress.StudentId)
                    {
                        Console.WriteLine("\t"+adrress);
                    }
                }
                foreach (Group group in DBGroup.Items)
                {
                    if (student.GroupId == group.Id)
                    {
                        Console.WriteLine("\t"+group);
                        foreach (GroupSubject groupSubject in DBgroupSubject.Items)
                        {
                            if (groupSubject.GroupId == group.Id)
                            {
                                foreach(Subject subject in DBSubject.Items)
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
