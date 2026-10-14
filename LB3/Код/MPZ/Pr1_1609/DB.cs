using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr1_1609
{
    public class DB
    {
        public DBItem<Student> DBStudent { get; set; } = new DBItem<Student>();
        public DBItem<Address> DBAdrress { get; set; } = new DBItem<Address>();
        public DBItem<Group> DBGroup { get; set; } = new DBItem<Group>();
        public DBItem<Subject> DBSubject { get; set; } = new DBItem<Subject>();
        public DBItem<GroupSubject> DBgroupSubject { get; set; } = new DBItem<GroupSubject>();
        public DB()
        {
            Inicialize();
        }
        public void Inicialize()
        {
            InicializeStudents();
            InicializeAddress();
            InicializeGroup();
            InicializeSubject();
            InicializeGroupSubject();
        }
        public void InicializeStudents()
        {
            Student student1 = new Student("Іван", "Петренко", 18, 2);
            Student student2 = new Student("Петро", "Романенко", 19, 2);
            Student student3 = new Student("Роман", "Василенко", 20, 1);
            DBStudent.AddItem(student1);
            DBStudent.AddItem(student2);
            DBStudent.AddItem(student3);
        }
        public void InicializeAddress() 
        {
            Address address1 = new Address("Київ", 3);
            Address address2 = new Address("Черкаси", 1);
            Address address3 = new Address("Полтава", 2);
            DBAdrress.AddItem(address1);
            DBAdrress.AddItem(address2);
            DBAdrress.AddItem(address3);
        }
        public void InicializeGroup()
        {
            Group group1 = new Group("ІПЗ-34");
            Group group2 = new Group("ІПЗ-35");
            DBGroup.AddItem(group1);
            DBGroup.AddItem(group2);
        }
        public void InicializeSubject()
        {
            Subject subject1 = new Subject("Програмування", 100);
            Subject subject2 = new Subject("Математика", 200);
            Subject subject3 = new Subject("Англійська мова", 300);
            DBSubject.AddItem(subject1);
            DBSubject.AddItem(subject2);
            DBSubject.AddItem(subject3);
        }
        public void InicializeGroupSubject()
        {
            GroupSubject groupSubject1 = new GroupSubject(1, 2);
            GroupSubject groupSubject2 = new GroupSubject(1, 3);
            GroupSubject groupSubject3 = new GroupSubject(2, 1);
            GroupSubject groupSubject4 = new GroupSubject(2, 2);
            DBgroupSubject.AddItem(groupSubject1);
            DBgroupSubject.AddItem(groupSubject2);
            DBgroupSubject.AddItem(groupSubject3);
            DBgroupSubject.AddItem(groupSubject4);
        }
        
    }
}
