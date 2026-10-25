using System.Security.Claims;
using System.Threading.Channels;

using System;

namespace Pr1_1609
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            DB db = new DB();
            DepartmentServyses departmentServices = new DepartmentServyses(db);

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n==================================================");
                Console.WriteLine("    СИСТЕМА АВТОМАТИЗАЦІЇ УНІВЕРСИТЕТУ      ");
                Console.WriteLine("==================================================");
                Console.WriteLine("1. Переглянути всі дані (тут і студенти, і адреси, і предмети)");
                Console.WriteLine("2. Управління студентами (Додати студента)");
                Console.WriteLine("3. Управління адресами (Додати адресу)");
                Console.WriteLine("4. Управління групами (Додати групу)");
                Console.WriteLine("5. Управління предметами (Додати предмет)");
                Console.WriteLine("6. Закріпити предмет за групою");
                Console.WriteLine("7. Знайти студента за прізвищем");
                Console.WriteLine("8. Розрахувати навантаження на студента");
                Console.WriteLine("0. Вихід");
                Console.Write("Оберіть пункт меню: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        departmentServices.GetAllInformationAboutStudients();
                        break;
                    case "2":
                        Console.Write("Ім'я: "); string fn = Console.ReadLine();
                        Console.Write("Прізвище: "); string ln = Console.ReadLine();
                        Console.Write("Вік: "); int age = int.Parse(Console.ReadLine() ?? "18");
                        Console.Write("ID групи: "); int gId = int.Parse(Console.ReadLine() ?? "1");
                        departmentServices.RegisterStudent(fn, ln, age, gId, "Не вказано");
                        break;
                    case "3":
                        Console.Write("Текст адреси: "); string adr = Console.ReadLine();
                        Console.Write("ID студента: "); int sId = int.Parse(Console.ReadLine() ?? "1");
                        departmentServices.AddAddress(adr, sId);
                        break;
                    case "4":
                        Console.Write("Назва групи (напр. ІПЗ-36): "); string gName = Console.ReadLine();
                        departmentServices.AddGroup(gName);
                        break;
                    case "5":
                        Console.Write("Назва предмета: "); string subName = Console.ReadLine();
                        Console.Write("Кількість годин: "); int hours = int.Parse(Console.ReadLine() ?? "100");
                        departmentServices.AddSubject(subName, hours);
                        break;
                    case "6":
                        Console.Write("ID групи: "); int grid = int.Parse(Console.ReadLine() ?? "1");
                        Console.Write("ID предмета: "); int subid = int.Parse(Console.ReadLine() ?? "1");
                        departmentServices.AddGroupSubject(grid, subid);
                        break;
                    case "7":
                        Console.Write("Введіть прізвище студента: "); string searchLn = Console.ReadLine();
                        departmentServices.GetStudentInfoByLastName(searchLn);
                        break;
                    case "8":
                        Console.Write("Введіть ID студента: "); int stWorkId = int.Parse(Console.ReadLine() ?? "1");
                        departmentServices.GetStudentWorkload(stWorkId);
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Спробуйте ще раз, невірний вибір.");
                        break;
                }
            }
        }
    }
}
