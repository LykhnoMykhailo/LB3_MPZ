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
                Console.WriteLine("    СИСТЕМА АВТОМАТИЗАЦІЇ УНІВЕРСИТЕТУ (Головне)   ");
                Console.WriteLine("==================================================");
                Console.WriteLine("1. Переглянути загальний звіт (Всі дані)");
                Console.WriteLine("2. Управління Студентами");
                Console.WriteLine("3. Управління Адресами");
                Console.WriteLine("4. Управління Групами");
                Console.WriteLine("5. Управління Предметами");
                Console.WriteLine("6. Закріплення предметів за групами");
                Console.WriteLine("7. Пошук студента за прізвищем");
                Console.WriteLine("8. Розрахувати навантаження на студента");
                Console.WriteLine("0. Вихід");
                Console.Write("Оберіть розділ: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        departmentServices.GetAllInformationAboutStudients();
                        break;

                    case "2": // Управління студентами
                        ShowStudentMenu(departmentServices);
                        break;

                    case "3": // Управління адресами
                        ShowAddressMenu(departmentServices);
                        break;

                    case "4": // Управління групами
                        ShowGroupMenu(departmentServices);
                        break;

                    case "5": // Управління предметами
                        ShowSubjectMenu(departmentServices);
                        break;

                    case "6":
                        Console.Write("Введіть ID групи: "); int grid = int.Parse(Console.ReadLine() ?? "1");
                        Console.Write("Введіть ID предмета: "); int subid = int.Parse(Console.ReadLine() ?? "1");
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
                        Console.WriteLine("Невірний вибір, спробуйте ще раз.");
                        break;
                }
            }
        }

        // --- Підменю: Адреси ---
        private static void ShowAddressMenu(DepartmentServyses ds)
        {
            bool back = false;
            while (!back)
            {
                Console.WriteLine("\n--- РОЗДІЛ: Управління адресами ---");
                Console.WriteLine("1. Переглянути всі адреси");
                Console.WriteLine("2. Додати адресу");
                Console.WriteLine("3. Змінити/Оновити адресу (за ID студента)");
                Console.WriteLine("4. Видалити адресу (за ID студента)");
                Console.WriteLine("0. Назад у головне меню");
                Console.Write("Оберіть дію: ");

                string subChoice = Console.ReadLine();
                Console.WriteLine();

                switch (subChoice)
                {
                    case "1":
                        ds.PrintAllAddresses();
                        break;
                    case "2":
                        Console.Write("Введіть ID студента: ");
                        int sId = int.Parse(Console.ReadLine() ?? "1");
                        Console.Write("Введіть текст адреси (місто): ");
                        string adr = Console.ReadLine() ?? "";
                        ds.AddAddress(adr, sId);
                        break;
                    case "3":
                        Console.Write("Введіть ID студента, чию адресу треба змінити: ");
                        int upId = int.Parse(Console.ReadLine() ?? "1");
                        Console.Write("Введіть нову адресу: ");
                        string newAdr = Console.ReadLine() ?? "";
                        ds.UpdateAddress(upId, newAdr);
                        break;
                    case "4":
                        Console.Write("Введіть ID студента, чию адресу треба видалити: ");
                        int delId = int.Parse(Console.ReadLine() ?? "1");
                        ds.DeleteAddress(delId);
                        break;
                    case "0":
                        back = true;
                        break;
                    default:
                        Console.WriteLine("Невірний вибір.");
                        break;
                }
            }
        }

        // --- Підменю: Студенти ---
        private static void ShowStudentMenu(DepartmentServyses ds)
        {
            bool back = false;
            while (!back)
            {
                Console.WriteLine("\n--- РОЗДІЛ: Управління студентами ---");
                Console.WriteLine("1. Додати студента");
                Console.WriteLine("2. Оновити дані студента");
                Console.WriteLine("3. Видалити студента");
                Console.WriteLine("0. Назад у головне меню");
                Console.Write("Оберіть дію: ");

                string subChoice = Console.ReadLine();
                Console.WriteLine();

                switch (subChoice)
                {
                    case "1":
                        Console.Write("Ім'я: "); string fn = Console.ReadLine();
                        Console.Write("Прізвище: "); string ln = Console.ReadLine();
                        Console.Write("Вік: "); int age = int.Parse(Console.ReadLine() ?? "18");
                        Console.Write("ID групи: "); int gId = int.Parse(Console.ReadLine() ?? "1");
                        Console.Write("Адреса: "); string addr = Console.ReadLine() ?? "Не вказано";
                        ds.RegisterStudent(fn, ln, age, gId, addr);
                        break;
                    case "2":
                        Console.Write("Введіть ID студента для оновлення: ");
                        int upId = int.Parse(Console.ReadLine() ?? "0");
                        Console.Write("Нове ім'я: "); string uFn = Console.ReadLine();
                        Console.Write("Нове прізвище: "); string uLn = Console.ReadLine();
                        Console.Write("Новий вік: "); int uAge = int.Parse(Console.ReadLine() ?? "18");
                        Console.Write("Новий ID групи: "); int uGId = int.Parse(Console.ReadLine() ?? "1");
                        ds.UpdateStudent(upId, uFn, uLn, uAge, uGId);
                        break;
                    case "3":
                        Console.Write("Введіть ID студента для видалення: ");
                        int delId = int.Parse(Console.ReadLine() ?? "0");
                        ds.DeleteStudent(delId);
                        break;
                    case "0":
                        back = true;
                        break;
                    default:
                        Console.WriteLine("Невірний вибір.");
                        break;
                }
            }
        }

        // --- Підменю: Групи ---
        private static void ShowGroupMenu(DepartmentServyses ds)
        {
            bool back = false;
            while (!back)
            {
                Console.WriteLine("\n--- РОЗДІЛ: Управління групами ---");
                Console.WriteLine("1. Переглянути всі групи");
                Console.WriteLine("2. Додати групу");
                Console.WriteLine("0. Назад у головне меню");
                Console.Write("Оберіть дію: ");

                string subChoice = Console.ReadLine();
                Console.WriteLine();

                switch (subChoice)
                {
                    case "1":
                        ds.PrintAllGroups();
                        break;
                    case "2":
                        Console.Write("Назва групи: "); string gName = Console.ReadLine();
                        ds.AddGroup(gName);
                        break;
                    case "0":
                        back = true;
                        break;
                    default:
                        Console.WriteLine("Невірний вибір.");
                        break;
                }
            }
        }

        // --- Підменю: Предмети ---
        private static void ShowSubjectMenu(DepartmentServyses ds)
        {
            bool back = false;
            while (!back)
            {
                Console.WriteLine("\n--- РОЗДІЛ: Управління предметами ---");
                Console.WriteLine("1. Переглянути всі предмети");
                Console.WriteLine("2. Додати предмет");
                Console.WriteLine("3. Видалити предмет");
                Console.WriteLine("0. Назад у головне меню");
                Console.Write("Оберіть дію: ");

                string subChoice = Console.ReadLine();
                Console.WriteLine();

                switch (subChoice)
                {
                    case "1":
                        ds.PrintAllSubjects();
                        break;
                    case "2":
                        Console.Write("Назва предмета: "); string sName = Console.ReadLine();
                        Console.Write("Кількість годин: "); int hours = int.Parse(Console.ReadLine() ?? "100");
                        ds.AddSubject(sName, hours);
                        break;
                    case "3":
                        Console.Write("ID предмета для видалення: "); int sId = int.Parse(Console.ReadLine() ?? "0");
                        ds.DeleteSubject(sId);
                        break;
                    case "0":
                        back = true;
                        break;
                    default:
                        Console.WriteLine("Невірний вибір.");
                        break;
                }
            }
        }
    }
}