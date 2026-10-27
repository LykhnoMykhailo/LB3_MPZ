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

        public void UpdateStudent(int id, string firstName, string lastName, int age, int groupId)
        {
            var oldStudent = db.DBStudent.GetItem(id);
            if (oldStudent != null)
            {
                Student newStudent = new Student(firstName, lastName, age, groupId);
                db.DBStudent.UpdateItem(oldStudent, newStudent);
                Console.WriteLine($"[Успішно] Дані студента з ID {id} оновлено.");
            }
            else
            {
                Console.WriteLine("[Помилка] Студента не знайдено.");
            }
        }

        public void DeleteStudent(int studentId)
        {
            var student = db.DBStudent.GetItem(studentId);
            if (student != null)
            {
                db.DBStudent.DeleteItem(student);
                var address = db.DBAdrress.Items.FirstOrDefault(a => a.StudentId == studentId);
                if (address != null) db.DBAdrress.DeleteItem(address);
                Console.WriteLine($"[Успішно] Студента з ID {studentId} видалено.");
            }
            else
            {
                Console.WriteLine("[Помилка] Студента не знайдено.");
            }
        }

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

        public void UpdateAddress(int studentId, string newAddressText)
        {
            var address = db.DBAdrress.Items.FirstOrDefault(a => a.StudentId == studentId);
            if (address != null)
            {
                address.StudentAdrress = newAddressText;
                Console.WriteLine($"[Успішно] Адресу для студента з ID {studentId} оновлено.");
            }
            else
            {
                Address newAddr = new Address(newAddressText, studentId);
                db.DBAdrress.AddItem(newAddr);
                Console.WriteLine($"[Успішно] Адресу для студента з ID {studentId} створено.");
            }
        }

        public void DeleteAddress(int studentId)
        {
            var address = db.DBAdrress.Items.FirstOrDefault(a => a.StudentId == studentId);
            if (address != null)
            {
                db.DBAdrress.DeleteItem(address);
                Console.WriteLine($"[Успішно] Адресу для студента з ID {studentId} видалено.");
            }
            else
            {
                Console.WriteLine("[Помилка] Адресу для цього студента не знайдено.");
            }
        }

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

        public void DeleteSubject(int id)
        {
            var subj = db.DBSubject.GetItem(id);
            if (subj != null)
            {
                db.DBSubject.DeleteItem(subj);
                Console.WriteLine($"[Успішно] Предмет ID {id} видалено.");
            }
            else
            {
                Console.WriteLine("[Помилка] Предмет не знайдено.");
            }
        }

        public void AddGroupSubject(int groupId, int subjectId)
        {
            GroupSubject gs = new GroupSubject(groupId, subjectId);
            db.DBgroupSubject.AddItem(gs);
            Console.WriteLine($"[Успішно] Закріплено предмет ID {subjectId} за групою ID {groupId}");
        }

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

            var address = db.DBAdrress.Items.FirstOrDefault(a => a.StudentId == student.Id);
            if (address != null) Console.WriteLine($"Адреса: {address.StudentAdrress}");

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