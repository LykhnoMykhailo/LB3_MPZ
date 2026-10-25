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
        // ===  1: Управління даними щодо студента (Create) ===
        public void RegisterStudent(string firstName, string lastName, int age, int groupId, string addressText)
        {
            Student newStudent = new Student(firstName, lastName, age, groupId);
            db.DBStudent.AddItem(newStudent);

            Address newAddress = new Address(addressText, newStudent.Id);
            db.DBAdrress.AddItem(newAddress);

            Console.WriteLine($"[Успішно] Студента {firstName} {lastName} додано з ID: {newStudent.Id}");
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
        // ===  2: Управління даними щодо адреси студента (CRUD) ===
        public void AddAddress(string addressText, int studentId)
        {
            Address addr = new Address(addressText, studentId);
            db.DBAdrress.AddItem(addr);
            Console.WriteLine($"[Успішно] Додано адресу для студента ID {studentId}");
        }

        public void PrintAllAddresses()
        {
            foreach (var a in db.DBAdrress.Items) Console.WriteLine(a);
        }

        // ===  3: Управління даними щодо груп (CRUD) ===
        public void AddGroup(string groupName)
        {
            Group g = new Group(groupName);
            db.DBGroup.AddItem(g);
            Console.WriteLine($"[Успішно] Групу '{groupName}' додано з ID: {g.Id}");
        }

        public void PrintAllGroups()
        {
            foreach (var g in db.DBGroup.Items) Console.WriteLine(g);
        }

        // ===  4: Управління даними щодо предметів (CRUD) ===
        public void AddSubject(string subjectName, int hours)
        {
            Subject s = new Subject(subjectName, hours);
            db.DBSubject.AddItem(s);
            Console.WriteLine($"[Успішно] Предмет '{subjectName}' додано з ID: {s.Id}");
        }

        public void PrintAllSubjects()
        {
            foreach (var s in db.DBSubject.Items) Console.WriteLine(s);
        }

        // ===  5: Управління закріпленням груп за предметами ===
        public void AddGroupSubject(int groupId, int subjectId)
        {
            GroupSubject gs = new GroupSubject(groupId, subjectId);
            db.DBgroupSubject.AddItem(gs);
            Console.WriteLine($"[Успішно] Закріплено предмет ID {subjectId} за групою ID {groupId}");
        }

        // ===  7: Отримання всіх даних щодо студента за прізвищем ===
        public void GetStudentInfoByLastName(string lastName)
        {
            var student = db.DBStudent.Items.FirstOrDefault(s => s.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase));
            if (student == null)
            {
                Console.WriteLine($"[Помилка] Студента з прізвищем '{lastName}' не знайдено.");
                return;
            }

            Console.WriteLine($"\n--- Знайдено студента ---");
            Console.WriteLine(student);

            // Виводимо адресу
            var address = db.DBAdrress.Items.FirstOrDefault(a => a.StudentId == student.Id);
            if (address != null) Console.WriteLine($"Адреса: {address.StudentAdrress}");

            // Виводимо групу та предмети
            var group = db.DBGroup.Items.FirstOrDefault(g => g.Id == student.GroupId);
            if (group != null)
            {
                Console.WriteLine($"Група: {group.GroupName}");
                Console.WriteLine("Предмети групи:");
                foreach (var gs in db.DBgroupSubject.Items.Where(x => x.GroupId == group.Id))
                {
                    var subj = db.DBSubject.Items.FirstOrDefault(sub => sub.Id == gs.SubjectID);
                    if (subj != null) Console.WriteLine($" - {subj.SubjectName} ({subj.Hour} год.)");
                }
            }
        }

        // ===  8: Отримання навантаження на студента (сума годин предметів його групи) ===
        public void GetStudentWorkload(int studentId)
        {
            var student = db.DBStudent.GetItem(studentId);
            if (student == null)
            {
                Console.WriteLine("[Помилка] Студента не знайдено.");
                return;
            }

            int totalHours = 0;
            foreach (var gs in db.DBgroupSubject.Items.Where(x => x.GroupId == student.GroupId))
            {
                var subj = db.DBSubject.Items.FirstOrDefault(sub => sub.Id == gs.SubjectID);
                if (subj != null) totalHours += subj.Hour;
            }

            Console.WriteLine($"\nСтудент: {student.FirstName} {student.LastName} (група ID: {student.GroupId})");
            Console.WriteLine($"Загальне навчальне навантаження: {totalHours} годин.");
        }
    }
}
