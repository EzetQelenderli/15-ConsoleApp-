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
            helper.PrintConsole(ConsoleColor.Blue, "Select one option!");
            helper.PrintConsole(ConsoleColor.Yellow, "1 - Create Group, 2- Update group   , 3 - Delete Group   , 4 - Get group  by id, 5 - Get all groups  by teacher , 6 - Get all groups by room, 7 - Get all groups   , 8 - Create Student  9 - Update Student   , 10- Get student  by id, 11 - Delete student,12 - Get students   by age, 13 - Get all students  by group id , 14- Search method for groups by name, 15 - Search method for students by name or surname.");
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

                            break;
                        case 4:
                            _courseGroupController.GetById();
                            break;
                    }


                }
                else
                {
                    helper.PrintConsole(ConsoleColor.Red, "Please enter correct option type!");
                    goto SelectOption;

                }
            }



        }
    }

}



