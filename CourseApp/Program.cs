using CourseApp.Controllers;
using CourseApp.Helpers;
using DomainLayer.Entitties;
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
            CourseGroupController _courseGroupController = new CourseGroupController();
            Helper.PrintConsole(ConsoleColor.Blue, "Select one option!");
            Console.WriteLine("\n====== COURSE GROUP MENU ======");
            Console.WriteLine("1. Create");
            Console.WriteLine("2. Update");
            Console.WriteLine("3. Delete");
            Console.WriteLine("4. GetById");
            Console.WriteLine("5. GetAll");
            Console.WriteLine("6. GetAllByTeacherName");
            Console.WriteLine("7. GetAllByRoom");
            Console.WriteLine("8. SearchByName");
            Console.WriteLine("0. Back");
            Console.ResetColor();
            while (true)
            {


            SelectOption: string SelectOption = Console.ReadLine();

                int selectNumberOption;
                bool isSelectOption = int.TryParse(SelectOption, out selectNumberOption);
                if (isSelectOption)
                {
                    switch (selectNumberOption)
                    {
                        case 1:
                            _courseGroupController.Create();
                            goto SelectOption;


                        case 2:
                            _courseGroupController.Delete();
                            goto SelectOption;

                        case 3:
                            _courseGroupController.GetById();
                            goto SelectOption;
                        case 4:
                            _courseGroupController.GetAll();
                            goto SelectOption;
                        //case 5:
                        //    _courseGroupController.GetAllByTeacherName();
                        //    goto SelectOption;
                        //case 6:
                        //    _courseGroupController.GetAllByRoom();
                        //    goto SelectOption;
                        //case 7:
                        //    _courseGroupController.Exit();
                        //    goto SelectOption;



                    }



                }
            }

        }
    }
}




