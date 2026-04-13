using CourseApp.Controllers;
using CourseApp.Helpers;
using DomainLayer.Entitties;
using RepositoryLayer.Repositories.Implementations;
using ServiceLayer.Services.Implementations;
using ServiceLayer.Services.Interfaces;
using System.ComponentModel.Design;
using System.Text.RegularExpressions;
namespace CourseApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CourseGroupRepository groupRepository = new();
            StudentRepository studentRepository = new();

            IGroupService groupService = new GroupService(groupRepository);
            IStudentService studentService = new StudentService(studentRepository, groupService);

            CourseGroupController courseGroupController = new CourseGroupController(groupService);
            StudentController studentController = new StudentController(studentService);

            while (true)
            {
                Console.Clear();
                Helper.PrintConsole(ConsoleColor.Cyan, "\n========== MAIN MENU ==========");
                Console.WriteLine("1. Course Group Menu");
                Console.WriteLine("2. Student Menu");
                Console.WriteLine("0. Exit");

            MainInput:
                Console.Write("Enter your choice: ");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out int mainChoice))
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Please enter a number!");
                    goto MainInput;
                }

                switch (mainChoice)
                {
                    case 1:
                        CourseGroupMenu(courseGroupController);
                        break;
                    case 2:
                        StudentMenu(studentController);
                        break;
                    case 0:
                        return;
                    default:
                        Helper.PrintConsole(ConsoleColor.Red, "Wrong choice!");
                        goto MainInput;
                }
            }
        }

        static void CourseGroupMenu(CourseGroupController controller)
        {
            while (true)
            {
                Helper.PrintConsole(ConsoleColor.Cyan, "\n====== COURSE GROUP MENU ======");
                Console.WriteLine("1. Create\n2. Update\n3. Delete\n4. GetById\n0. Back");

                Console.Write("Choice: ");
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    if (choice == 0) break;
                    switch (choice)
                    {
                        case 1: controller.Create(); break;
                        case 2: controller.Update(); break; 
                        case 3: controller.Delete(); break;
                        case 4: controller.GetById(); break;
                    }
                }
            }
        }

        static void StudentMenu(StudentController controller)
        {
            while (true)
            {
                Helper.PrintConsole(ConsoleColor.Cyan, "\n========== STUDENT MENU ==========");
                Console.WriteLine("1. Create\n2. Delete\n3. Update\n4. GetById\n0. Back");

                Console.Write("Choice: ");
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    if (choice == 0) break;
                    switch (choice)
                    {
                        case 1: StudentController.Create(); break;
                        case 2: controller.Delete(); break;
                        case 3: controller.Update(); break;
                        case 4: controller.GetById(); break;
                    }
                }
            }
        }
    }
}
